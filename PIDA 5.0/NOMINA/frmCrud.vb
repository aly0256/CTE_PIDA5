Imports System.Text.RegularExpressions
Imports System.Globalization
Imports Newtonsoft.Json


Public Class frmCrud

    Dim dtInfo As DataTable
    Dim errLst As New List(Of String)
    Dim nomTabla As String = ""
    Dim tipoModificacion = ""
    Dim infoDic As New Dictionary(Of String, String)
    Dim infoDif As New Dictionary(Of String, Object)
    Dim dtTabla As New DataTable

    Dim panelesControles = Nothing
    Dim dtConceptos As New DataTable
    Dim dtTipoComp As New DataTable
    Dim dtCodClase As New DataTable
    Dim dtTipoNomina As New DataTable
    Dim dtTipoCred As New DataTable

    Dim dicInfoOrig As New Dictionary(Of String, Object)
    Dim dicInfoUsuario As New Dictionary(Of String, Object)
    Dim dicFin As New Dictionary(Of String, Boolean)

    Dim noPanelesPrincipales = 1
    Dim reloj = ""
    Dim edicionDatosMsj As String = ""
    Dim jsonFin = ""

    Public Sub New(tablaCampos As DataTable, Optional tipoMod As String = "", Optional tabla As String = "", Optional infoAdicional As Object = Nothing)

        InitializeComponent()
        dtInfo = tablaCampos.Copy
        nomTabla = infoAdicional("tabla")
        tipoModificacion = tipoMod
        infoDic = infoAdicional
        panelesControles = PanelesInformación(nomTabla)
        InfoDatatables()
        Me.Text = tabla

        '-- Diccionario donde se almacena si los campos de finiquito y finiquito_esp fueron seleccionados por el empleado para la nominaPro
        dicFin.Add("finiquito", False)
        dicFin.Add("finiquito_esp", False)
        '--

        '-- Si es editar, llenar info
        If tipoModificacion = "Editar" Then
            Me.Text = "Editar registro"
            dtTabla = Sqlite.getInstance.sqliteExecute("select * from " & infoDic("tabla") & " where id='" & infoDic("id") & "'")
            reloj = dtTabla.Rows(0)("reloj")
            CargarInformacionEditar(dtTabla, nomTabla, dtInfo)
        Else
            Me.Text = "Agregar registro"
            dtTabla = Sqlite.getInstance.sqliteExecute("SELECT * FROM " & infoDic("tabla") & " limit 0")
            DiccionarioInfo(Nothing, tablaCampos, "Agregar")
            CargarInformacionAgregar(dtTabla, nomTabla, dtInfo)
        End If
    End Sub

#Region "InputFiniquitos"
    ''' <summary>
    ''' Inicializar. Se agrega empleado a nominaPro. Se tomó solo el código necesario de "inicializar" para este paso.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub IncializaEmpleadoNomina(strReloj As String)
        Try
            Dim dtPers = sqlExecute("SELECT DISTINCT P.*, (SELECT top 1 fecha_mantenimiento FROM personal.dbo.bitacora_personal WHERE reloj = p.reloj AND campo='inactivo') as fecha_inac,('1') as factor_dias, " &
                                    "RTRIM(P.NOMBRE) + ' ' + RTRIM(P.APATERNO) + ' ' + RTRIM(P.AMATERNO) as 'nombre_completo', Pl.nombre as 'nombre_planta',  dpto.NOMBRE as 'nombre_dpto' " &
                                    "FROM PERSONAL.dbo.personal AS P " &
                                    "JOIN PERSONAL.dbo.plantas AS Pl on P.COD_PLANTA = Pl.COD_PLANTA AND P.COD_COMP = Pl.COD_COMP " &
                                    "JOIN PERSONAL.dbo.deptos AS DPTO on DPTO.COD_COMP = P.COD_COMP and DPTO.COD_DEPTO = P.COD_DEPTO " &
                                    "WHERE P.COD_COMP in ('CTE') and reloj='" & strReloj & "'")

            Dim dtPeriodos = sqlExecute("SELECT * FROM " & IIf(infoDic("tipoPer") = "sem", "periodos", "periodos_quincenal") & " WHERE ano = '" & infoDic("ano") & "' AND periodo = '" & infoDic("periodo") & "'", "TA")
            Dim FIni As Date = Convert.ToDateTime(dtPeriodos.Rows(0)("fecha_ini"))
            Dim FFin As Date = Convert.ToDateTime(dtPeriodos.Rows(0)("fecha_fin"))

            Dim super = sqlExecute("SELECT * FROM personal.dbo.super where reloj = '" & strReloj & "' ")
            Dim dtNoMes = sqlExecute("select top 1 num_mes from ta.dbo." & IIf(infoDic("tipoPer") = "sem", "periodos", "periodos_quincenal") & " where ano+periodo='" & infoDic("ano") & infoDic("periodo") & "'")
            Dim infonavit = sqlExecute("SELECT TOP 1 * FROM personal.dbo.infonavit WHERE reloj = '" & strReloj & "' Order by FECHA_APLICACION desc")
            Dim vacations = sqlExecute("SELECT * FROM PERSONAL.dbo.vacaciones", "PERSONAL")

            Dim fhaBaja = Nothing
            Dim privac_porc = 0, privac_dias = 0
            Dim sdo_cober = 0, sup = Nothing
            Dim infon = Nothing, tipo_cred = Nothing, cuota_cred = 0D, cobro_segv = False, suspension = False, activo = False, inicio_cre = Nothing

            If infonavit.Rows.Count > 0 Then
                activo = infonavit.Rows(0)("activo")
                infon = IIf(activo And Not IsDBNull(infonavit.Rows(0)("infonavit")), infonavit.Rows(0)("infonavit").Trim, Nothing)
                tipo_cred = IIf(activo And Not IsDBNull(infonavit(0)("tipo_cred")), infonavit.Rows(0)("tipo_cred").Trim, Nothing)
                cuota_cred = IIf(activo And Not IsDBNull(infonavit(0)("cuota_cred")), infonavit.Rows(0)("cuota_cred"), Nothing)
                cobro_segv = IIf(activo And Not IsDBNull(infonavit(0)("cobro_segv")), Convert.ToBoolean(infonavit.Rows(0)("cobro_segv")), False)
                suspension = IIf(activo And Not IsDBNull(infonavit(0)("suspension")), True, Nothing)
                inicio_cre = IIf(activo And Not IsDBNull(infonavit.Rows(0)("inicio_cre")), infonavit.Rows(0)("inicio_cre"), Nothing)
            End If

            If super.Rows.Count > 0 Then : sup = super.Rows(0)("cod_clerk") : End If

            If dtPers.Rows.Count > 0 Then
                For Each item In dtPers.Rows

                    If Not IsDBNull(item("baja")) Then
                        If Convert.ToDateTime(item("baja")) > Convert.ToDateTime(FFin) Then fhaBaja = Nothing Else fhaBaja = item("baja")
                    End If

                    Dim aniversary_antig As Date, aniversary As Date
                    Try : aniversary_antig = DateTime.ParseExact(Convert.ToDateTime(item("alta_vacacion")).ToString("ddMM") & FFin.ToString("yyyy"), "ddMMyyyy", CultureInfo.CurrentCulture)
                    Catch ex As Exception : aniversary_antig = DateTime.ParseExact(Convert.ToDateTime(item("alta_vacacion")).AddDays(-1).ToString("ddMM") & FFin.ToString("yyyy"), "ddMMyyyy", CultureInfo.CurrentCulture)
                    End Try

                    Try : aniversary = DateTime.ParseExact(Convert.ToDateTime(item("alta")).ToString("ddMM") & FFin.ToString("yyyy"), "ddMMyyyy", CultureInfo.CurrentCulture)
                    Catch ex As Exception : aniversary = DateTime.ParseExact(Convert.ToDateTime(item("alta")).AddDays(-1).ToString("ddMM") & FFin.ToString("yyyy"), "ddMMyyyy", CultureInfo.CurrentCulture)
                    End Try

                    If aniversary_antig > FFin Then
                        aniversary_antig = aniversary_antig.AddMonths(-12)
                        aniversary = aniversary.AddMonths(-12)
                    End If

                    If (aniversary_antig >= FFin And aniversary_antig <= FFin) And Integer.Parse(infoDic("periodo")) <= 52 And aniversary_antig <> item("alta_vacacion") Then
                        Dim anos = aniversary_antig.Year() - Convert.ToDateTime(item("alta_vacacion")).Year()
                        Dim vac = (From i In vacations Where i("COD_COMP").ToString.Trim = item("cod_comp").ToString.Trim And i("COD_TIPO").ToString.Trim = item("cod_tipo").ToString.Trim And i("ANOS") = anos).ToList()
                        If vac.Count > 0 Then
                            privac_porc = vac.First()("POR_PRIMA")

                            If ((FFin - Convert.ToDateTime(item("alta").ToString)).TotalDays + 1) / 365 <= 1 Then
                                privac_dias = Math.Round(vac.First()("DIAS") / 365 * ((aniversary_antig - Convert.ToDateTime(item("alta").ToString)).TotalDays + 1), 2)
                            Else
                                privac_dias = vac.First()("DIAS")
                            End If

                        End If
                    End If

                    Sqlite.getInstance().insert(New Dictionary(Of String, Object) From {{"cod_comp", item("cod_comp")},
                                                                                        {"procesar", "True"},
                                                                                        {"retiro_fah", ""},
                                                                                        {"folio", ""},
                                                                                        {"pagina", ""},
                                                                                        {"cod_tipo_nomina", "N"},
                                                                                        {"cod_pago", IIf(Not IsDBNull(item("baja")), "E", item("tipo_pago"))},
                                                                                        {"periodo", infoDic("periodo")},
                                                                                        {"ano", infoDic("ano")},
                                                                                        {"reloj", item("reloj")},
                                                                                        {"nombres", item("nombre_completo")},
                                                                                        {"mes", dtNoMes.Rows(0)("num_mes").ToString.Trim},
                                                                                        {"sactual", item("sactual")},
                                                                                        {"integrado", item("integrado")},
                                                                                        {"cod_depto", item("cod_depto")},
                                                                                        {"cod_turno", item("cod_turno")},
                                                                                        {"cod_puesto", item("cod_puesto")},
                                                                                        {"cod_super", item("cod_super")},
                                                                                        {"cod_hora", item("cod_hora")},
                                                                                        {"cod_tipo", item("cod_tipo")},
                                                                                        {"cod_clase", item("cod_clase")},
                                                                                        {"sindicalizado", item("sindicalizado")},
                                                                                        {"tipo_nomina", IIf(infoDic("tipoPer") = "sem", "S", "Q")},
                                                                                        {"alta", item("alta")},
                                                                                        {"baja", fhaBaja},
                                                                                        {"alta_antig", item("alta_vacacion")},
                                                                                        {"periodo_act", infoDic("ano") & infoDic("periodo")},
                                                                                        {"cod_cate", ""},
                                                                                        {"cod_tipo2", ""},
                                                                                        {"fah_participa", item("fah_partic")},
                                                                                        {"fah_porcentaje", item("fah_porcen")},
                                                                                        {"infonavit_credito", infon},
                                                                                        {"tipo_credito", tipo_cred},
                                                                                        {"cuota_credito", cuota_cred},
                                                                                        {"cobro_segviv", IIf(activo, cobro_segv, 0)},
                                                                                        {"inicio_credito", inicio_cre},
                                                                                        {"calculado", ""},
                                                                                        {"retiro_parcial", ""},
                                                                                        {"cuenta1", item("cuenta_banco")},
                                                                                        {"monto_retiro", ""},
                                                                                        {"curp", item("curp")},
                                                                                        {"cod_area", item("cod_area")},
                                                                                        {"privac_porc", privac_porc},
                                                                                        {"privac_dias", privac_dias},
                                                                                        {"factor_dias", item("factor_dias")},
                                                                                        {"dias_habiles", ""},
                                                                                        {"vales_cta", ""},
                                                                                        {"vales_tarj", ""},
                                                                                        {"sdo_cobertura", sdo_cober},
                                                                                        {"incapacidad", ""},
                                                                                        {"faltas", ""},
                                                                                        {"vacaciones", ""},
                                                                                        {"cod_clerk", sup},
                                                                                        {"finiquito", False},
                                                                                        {"finiquito_esp", False},
                                                                                        {"permiso", ""}}, "nominaPro")
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Miscelaneos. Se cargan los miscelaneos del empleado. Se tomará solo el código indispensable de la función original/
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="relojManual"></param>
    ''' <remarks></remarks>
    Private Sub Miscelaneos(data As Dictionary(Of String, String), relojManual As String, origen As String)
        '== Filtro para empleado que se agrega manualmente
        Dim filtro = IIf(relojManual <> "", "{0} reloj in ('" & relojManual & "')", "")
        Dim dtNominaPro = Sqlite.getInstance.sqliteExecute("select * from nominaPro " & String.Format(filtro, "where"))
        Dim dtAjustesPro = Sqlite.getInstance.sqliteExecute("select * from ajustesPro " & String.Format(filtro, "where"))

        'Se limpian todos los registros de mtro_ded que sean el periodo-año que se va a trabajar y se obtienen los datos de maestro deducciones
        sqlExecute("DELETE FROM NOMINA.dbo.mtro_ded WHERE concepto LIKE 'TIEN%' AND ini_ano ='" & data("ano").ToString.Trim &
                   "' and ini_per = '" & data("periodo").ToString.Trim & "' " & String.Format(filtro, "and"), "NOMINA")

        Dim _mtroDed = sqlExecute("SELECT * FROM NOMINA.dbo.mtro_ded WHERE reloj IN ('" & relojManual & "')")
        Dim tienda_c = sqlExecute("SELECT reloj, MAX(concepto) as concepto FROM NOMINA.dbo.mtro_ded WHERE concepto LIKE 'TIEN%' " & String.Format(filtro, "and") & " GROUP BY reloj")
        Dim rebec_c = sqlExecute("SELECT DISTINCT RELOJ,CONCEPTO,ACTIVO FROM NOMINA.dbo.mtro_ded WHERE concepto LIKE 'REBEC%' " & String.Format(filtro, "and") & " ORDER BY RELOJ,concepto DESC")

        Dim sql = ""

        Dim _dRecib = Sqlite.getInstance.sqliteExecute("SELECT * FROM dtRecib " & String.Format(filtro, "where"))

        '== Inicio y fin del periodo en curso
        Dim infoPer = Sqlite.getInstance.sqliteExecute("select ano,periodo,fecha_ini,fecha_fin from periodosNomPro where ano='" & data("ano") & "' and periodo='" & data("periodo") & "'")
        Dim fhaMin = Nothing
        Dim difReloj = ""

        'Recorriendo _dRecib
        For Each recib In _dRecib.Rows

            '== Para la fecha del concepto DDVFIN
            If difReloj <> recib("reloj") Then difReloj = recib("reloj") : fhaMin = Nothing
            If recib("factor") = 0 Then : recib("factor") = 1 : End If

            'poniendo todas las tiendas en semana = 1
            If recib("concepto").ToString.Contains("TIENDA") And recib("semanas") = 1 Then : recib("semanas") = 1 : End If

            'Identificar el reloj en nomina_pro
            Dim salary = 0D
            If dtNominaPro.Rows.Count > 0 Then : salary = dtNominaPro.Rows(0)("sactual") : End If

            If {"AHOALC", "CAPACI", "CAJPMO", "RECFNT"}.Contains(recib("concepto")) Then

                Dim element = _mtroDed.Select("reloj = '" & recib("reloj").Trim & "' and concepto = '" & recib("concepto").Trim & "' and activo")

                If element.Count > 0 Then
                    If element.First()("ini_per") <> data("periodo") Or element.First()("ini_ano").ToString.Trim <> data("ano") Or element.First()("abono") <> recib("monto") Then
                        sql &= "UPDATE NOMINA.dbo.mtro_ded SET comentario = 'Cancelado por nueva instrucción en periodo semanal " + data("ano") + "/" + data("periodo") & "', activo = '0' WHERE id = '" & element.First()("id") & "'; "
                        sql &= "INSERT INTO NOMINA.dbo.mtro_ded (reloj, concepto, abono, ini_per, ini_ano, activo, fijo, tipo_perio, periodos, ini_saldo, sald_act) values ('" &
                               recib("reloj") & "', '" & recib("concepto") & "', '" & recib("monto") & "', '" & data("periodo") & "', '" & data("ano") & "', '1', '" &
                               {"AHOALC"}.Contains(recib("concepto")) & "', 'S', '" & recib("semanas") & "', '" & recib("saldo") & "', '" & recib("saldo") & "'); "
                    End If
                Else
                    sql &= "INSERT INTO NOMINA.dbo.mtro_ded (reloj, concepto, abono, ini_per, ini_ano, activo, fijo, tipo_perio, periodos, ini_saldo, sald_act) values ('" &
                            recib("reloj") & "', '" & recib("concepto") & "', '" & recib("monto") & "', '" & data("periodo") & "', '" & data("ano") & "', '1', '" &
                            {"AHOALC"}.Contains(recib("concepto")) & "', 'S', '" & recib("semanas") & "', '" & recib("saldo") & "', '" & recib("saldo") & "'); "
                End If

                'Un empleado puede tener varios descuentos de tienda, vamos a agregar los que lleguen con un concepto nuevo IVO 201-06-14
            ElseIf recib("concepto").ToString.Contains("TIENDA") And recib("semanas") > 1 Then
                Dim element = tienda_c.Select("reloj = '" & recib("reloj") & "'")
                Dim counter = 0, concept = "TIEN"
                If element.Count > 0 Then
                    Dim t = Regex.Replace(element.First()("concepto").ToString, "[^0-9]", "")
                    counter = Integer.Parse(IIf(t.Count > 0, t + 1, "0"))
                    concept &= counter.ToString.PadLeft(2, "0")
                Else : concept &= "01" : End If
                sql &= "INSERT INTO NOMINA.dbo.mtro_ded (reloj, concepto, abono, ini_saldo, ini_per, ini_ano, activo, fijo, tipo_perio, periodos, sald_act) values ('" &
                    recib("reloj") & "', '" & concept & "', '" & recib("monto") & "', '" & recib("saldo") & "', '" & data("periodo") & "', '" & data("ano") & "', '1', '0', 'S', '" & recib("semanas") & "', '" & recib("saldo") & "'); "

            ElseIf recib("concepto") = "HRSEXA" Then

                If recib("dobles") > 0 Then
                    Dim element = dtAjustesPro.Select("ano='" & data("ano") & "' and periodo='" & data("periodo") & "' and concepto='HRS2AN'")

                    If element.Count > 0 Then : element.First.Item("monto") = element.First.Item("monto") + recib("dobles")
                        Sqlite.getInstance.sqliteExecute("UPDATE ajustesPro set monto='" & element.First.Item("monto") & "' WHERE reloj='" & recib("reloj") & "' and concepto='HRS2AN'")
                    Else
                        Sqlite.getInstance().insert(New Dictionary(Of String, Object) From {{"ano", data("ano")},
                                                                                            {"periodo", data("periodo")},
                                                                                            {"reloj", recib("reloj")},
                                                                                            {"per_ded", "P"},
                                                                                            {"concepto", "HRS2AN"},
                                                                                            {"descripcion", ""},
                                                                                            {"monto", recib("dobles")},
                                                                                            {"clave", Nothing},
                                                                                            {"origen", origen},
                                                                                            {"usuario", Usuario},
                                                                                            {"datetime", Now},
                                                                                            {"afecta_vac", False},
                                                                                            {"factor", recib("factor")},
                                                                                            {"fecha", recib("fecha")},
                                                                                            {"sueldo", salary},
                                                                                            {"fecha_fox", recib("fecha_fox")},
                                                                                            {"per_aplica", Nothing},
                                                                                            {"ano_aplica", Nothing},
                                                                                            {"saldo", 0}}, "ajustesPro")
                    End If
                End If

                If recib("triples") > 0 Then
                    Dim element = dtAjustesPro.Select("ano='" & data("ano") & "' and periodo='" & data("periodo") & "' and concepto='HRS3AN'")

                    If element.Count > 0 Then : element.First.Item("monto") = element.First.Item("monto") + recib("triples")
                        Sqlite.getInstance.sqliteExecute("UPDATE ajustesPro set monto='" & element.First.Item("monto") & "' WHERE reloj='" & recib("reloj") & "' and concepto='HRS3AN'")
                    Else
                        Sqlite.getInstance().insert(New Dictionary(Of String, Object) From {{"ano", data("ano")},
                                                                                            {"periodo", data("periodo")},
                                                                                            {"reloj", recib("reloj")},
                                                                                            {"per_ded", "P"},
                                                                                            {"concepto", "HRS3AN"},
                                                                                            {"descripcion", ""},
                                                                                            {"monto", recib("triples")},
                                                                                            {"clave", Nothing},
                                                                                            {"origen", origen},
                                                                                            {"usuario", Usuario},
                                                                                            {"datetime", Now},
                                                                                            {"afecta_vac", False},
                                                                                            {"factor", recib("factor")},
                                                                                            {"fecha", recib("fecha")},
                                                                                            {"sueldo", salary},
                                                                                            {"fecha_fox", recib("fecha_fox")},
                                                                                            {"per_aplica", Nothing},
                                                                                            {"ano_aplica", Nothing},
                                                                                            {"saldo", 0}}, "ajustesPro")
                    End If
                End If

            ElseIf recib("concepto").ToString.Trim = "BONOS" Then

                '== Si el no hay detalles en dtRecib, entonces se trata de un concepto con importe, sino entonces es con porcentaje
                If IsDBNull(recib("detalles")) Then
                    Sqlite.getInstance().insert(New Dictionary(Of String, Object) From {{"ano", data("ano")},
                                                                                        {"periodo", data("periodo")},
                                                                                        {"reloj", recib("reloj")},
                                                                                        {"per_ded", "P"},
                                                                                        {"concepto", recib("concepto")},
                                                                                        {"descripcion", ""},
                                                                                        {"monto", recib("monto")},
                                                                                        {"clave", Nothing},
                                                                                        {"origen", origen},
                                                                                        {"usuario", Usuario},
                                                                                        {"datetime", Now},
                                                                                        {"afecta_vac", False},
                                                                                        {"factor", recib("factor")},
                                                                                        {"fecha", recib("fecha")},
                                                                                        {"sueldo", salary},
                                                                                        {"fecha_fox", recib("fecha_fox")},
                                                                                        {"per_aplica", Nothing},
                                                                                        {"ano_aplica", Nothing},
                                                                                        {"saldo", 0}}, "ajustesPro")
                Else
                    '== Se revisa si bono esta vigente
                    Dim detBono = recib("detalles").ToString.Trim
                    Dim strQryMtroDed = ""
                    Dim c = 0 : Dim fechasArr = {Nothing, Nothing}

                    For Each i In detBono.Split(",")
                        fechasArr(c) = Convert.ToDateTime(i.ToString.Split(":")(1)) : c += 1
                        If c > 1 Then Exit For
                    Next

                    '== Si es bono vencido, no incluir y actualizar estatus en maestro de deducciones.
                    Dim fhaValida = fechasArr(1) < Convert.ToDateTime(infoPer.Rows(0)("fecha_ini"))

                    If sqlExecute("select id from nomina.dbo.mtro_ded where reloj='" & recib("reloj") & "' and concepto='" & recib("concepto") & "' and comentario='" & recib("detalles") & "'").Rows.Count = 0 Then
                        If fhaValida Then
                            strQryMtroDed = "insert into nomina.dbo.mtro_ded (reloj,concepto,comentario,tipo_perio,activo,fijo) values " & _
                                            "('" & recib("reloj") & "','" & recib("concepto") & "','" & recib("detalles") & "','" & data("tipoPeriodo") & "',0,1)"
                        Else
                            strQryMtroDed = "insert into nomina.dbo.mtro_ded (reloj,concepto,comentario,tipo_perio,activo,fijo) values " & _
                                            "('" & recib("reloj") & "','" & recib("concepto") & "','" & recib("detalles") & "','" & data("tipoPeriodo") & "',1,1)"
                        End If

                        '== Inserción de bono
                        sqlExecute(strQryMtroDed)
                    End If
                End If

            ElseIf recib("concepto").ToString.Substring(0, 5) = "REBEC" And recib("semanas") > 1 Then            '--- Sección para el concepto REBEC1,REBEC2,etc -- Ernesto -- 18 AGOSTO 2023

                '-- Modificación REBECA [Solo pueden haber dos conceptos REBECA de acuerdo a Ivette -- 21 sep 2023]
                Dim strFiltro = "reloj = '" & recib("reloj").Trim &
                             "' and activo and abono='" & recib("monto") &
                             "' and ini_saldo='" & recib("saldo") &
                             "' and periodos='" & recib("semanas") &
                             "' and sald_act='" & recib("saldo") & "' and concepto like 'REBEC%'"

                Dim element = _mtroDed.Select(strFiltro)

                If element.Count = 0 Then

                    Dim existen As DataTable = ProcesoNomina.infoTabla("reloj='" & recib("reloj").Trim & "'", rebec_c)
                    Dim numRebeca = "REBEC1"

                    If existen.Rows.Count > 0 Then
                        For Each e In existen.Rows
                            If e("concepto") = "REBEC1" And e("activo") Then numRebeca = "REBEC2"
                        Next
                    End If

                    sqlExecute("INSERT INTO NOMINA.dbo.mtro_ded (reloj, concepto, abono, ini_saldo, ini_per, ini_ano, activo, fijo, tipo_perio, periodos, sald_act, comentario) values ('" &
                               recib("reloj") & "', '" & numRebeca & "', '" & recib("monto") &
                               "', '" & recib("saldo") & "', '" & data("periodo") & "', '" & data("ano") & "', '1', '0', 'S', '" & recib("semanas") & "', '" & recib("saldo") &
                               "','Alta sem " & data("ano") & "-" & data("periodo") & "'); ")
                End If

            Else
                Dim element = dtAjustesPro.Select("reloj = '" & recib("reloj") & "' and ano = '" & data("ano") & "' and periodo = '" & data("periodo") & "' and concepto = '" & recib("concepto") & "'")
                Dim monto = 0

                '== Validación especial para el concepto DDVFIN para que tome la fecha minima de los registros que traiga
                If recib("concepto").ToString.Trim = "DDVFIN" Then fhaMin = recib("fecha")

                If element.Count > 0 Then
                    monto = element.First.Item("monto") + recib("monto")

                    '== Validación de fecha mínima para concepto DDVFIN
                    Dim min = recib("concepto").ToString.Trim = "DDVFIN" AndAlso (Convert.ToDateTime(fhaMin) < Convert.ToDateTime(element.First.Item("fecha")))

                    '== Actualizar tabla ajustesPro si ya existe concepto
                    Sqlite.getInstance.sqliteExecute("UPDATE ajustesPro SET " & IIf(min, "fecha='" & fhaMin & "',", "") &
                                                     "monto='" & monto & "' WHERE reloj = '" & recib("reloj") & "' and ano = '" &
                                                     data("ano") & "' and periodo = '" & data("periodo") & "' and concepto = '" & recib("concepto") & "'")
                Else
                    Sqlite.getInstance().insert(New Dictionary(Of String, Object) From {{"ano", data("ano")},
                                                                                        {"periodo", data("periodo")},
                                                                                        {"reloj", recib("reloj")},
                                                                                        {"per_ded", "P"},
                                                                                        {"concepto", recib("concepto")},
                                                                                        {"descripcion", ""},
                                                                                        {"monto", recib("monto")},
                                                                                        {"clave", Nothing},
                                                                                        {"origen", origen},
                                                                                        {"usuario", Usuario},
                                                                                        {"datetime", Now},
                                                                                        {"afecta_vac", False},
                                                                                        {"factor", recib("factor")},
                                                                                        {"fecha", recib("fecha")},
                                                                                        {"sueldo", salary},
                                                                                        {"fecha_fox", recib("fecha_fox")},
                                                                                        {"per_aplica", Nothing},
                                                                                        {"ano_aplica", Nothing},
                                                                                        {"saldo", 0}}, "ajustesPro")
                End If
            End If
        Next

        'Ejecutando sql y recargando mtro_ded
        If tipoModificacion = "Agregar" Then
            Sqlite.getInstance.sqliteExecute("delete from mtro_ded where reloj in ('" & relojManual & "')")
            _mtroDed = sqlExecute(sql & "SELECT * FROM NOMINA.dbo.mtro_ded WHERE reloj IN ('" & relojManual & "') ")
            For Each element In _mtroDed.Rows
                Dim dict As New Dictionary(Of String, Object)
                For Each dataColumn In _mtroDed.Columns : dict.Add(dataColumn.ColumnName, element(dataColumn.ColumnName).ToString()) : Next
                Sqlite.getInstance().insert(dict, "mtroDed")
            Next

        End If

        'Actualizacion de factores IVO 2021-08-03
        'TODO: Marcar en la tabla de conceptos a cuales le vamos a hacer actualizacion de factores
        Dim filter = Sqlite.getInstance.sqliteExecute("SELECT * FROM ajustesPro WHERE concepto in ('DIAC50', 'DIAFIN', 'DIAFJU', 'DIAFUN', 'DIAMAT', 'DIANAC', 'DIAPGO', 'DIAPSG', 'DIASUS', 'DIASVA', 'DIAFCH') " &
                                                      String.Format(filtro, "and"))
        sql = ""
        For Each filt In filter.Rows
            If dtNominaPro.Rows.Count > 0 Then
                sql &= "UPDATE ajustesPro SET factor = '" & dtNominaPro.Rows(0)("factor_dias") & "' WHERE id = '" & filt("id") & "'; "
            End If
        Next
        Sqlite.getInstance.sqliteExecute(sql)

        '********************************************************Boton 1********************************************************
        filter.Clear()

        '== Ajuste al subsidio (Si lo hay)
        Dim dtAjustSub = Sqlite.getInstance.sqliteExecute("SELECT * FROM dtAjusteSubsidio " &
                                                                       "WHERE activo = 'True' " &
                                                                       "AND cast(abono as decimal) > 0 " &
                                                                       "AND (fijo = 'True' or cast(sald_act as decimal) > 0) " &
                                                                       "AND ((cast(ini_ano as integer)<=" & data("ano") & " and cast(ini_per as integer)<=" & data("periodo") &
                                                                       ") or cast(ini_ano as integer)<" & data("ano") & ")) " & String.Format(filtro, "and"))
        '== Maestro de deducciones
        Dim dtMtroDed = Sqlite.getInstance.sqliteExecute("SELECT * FROM mtroDed " &
                                                        "WHERE activo = 'True' " &
                                                        "AND reloj NOT IN (SELECT reloj FROM finiquitosE) " &
                                                        "AND cast(abono as decimal) > 0 " &
                                                        "AND (fijo = 'True' or cast(sald_act as decimal) > 0) " &
                                                        "AND (((cast(ini_ano as integer)<=" & data("ano") & ") and cast(ini_per as integer)<=" &
                                                        data("periodo") & ") or cast(ini_ano as integer)<" & data("ano") & " or ini_per is null) " & String.Format(filtro, "and"))

        '== Filtro
        If dtAjustSub.Rows.Count > 0 Then
            dtAjustSub.Merge(dtMtroDed)
            filter = dtAjustSub
        Else
            filter = dtMtroDed
        End If

        '== Si no se trata de un reloj ingresado manualmente, hacer lo siguiente [18/abril/2023] 
        'If relojManual = "" Then Sqlite.getInstance.sqliteExecute("DELETE FROM ajustesPro WHERE reloj IN (SELECT reloj FROM finiquitosE)")

        For Each item In filter.Rows
            Dim conti = True
            'En la SEM 41-2019 hicimos el cambio de acuerdo a lo solicitado por Marisa, para que no se junten 2 adeudos, en caso de que el empleado
            'tenga 2 adeudos o mas, primero se debe terminar de pagar el primero y hasta la siguiente semana comenzar a descontar el 2o IVO
            If {"ADEIN1", "ADEIN2", "ADEIN3", "ADEIN4", "ADEIN5", "ADEIN6"}.Contains(item("concepto")) Then
                Dim find = Sqlite.getInstance.sqliteExecute("SELECT * FROM ajustesPro WHERE reloj = '" & item("reloj").Trim & "' AND concepto LIKE 'ADEIN%'")
                If find.Rows.Count > 0 Then : conti = False : End If
            End If

            'Solo debemos subir un miscelaneo por empleado por concepto
            'A partir de la sem 43-2019 vamos a incluir los saldos de los conceptos del mtro_ded IVO
            If conti Then
                Dim ajp = Sqlite.getInstance.sqliteExecute("SELECT * FROM ajustesPro WHERE ano = '" & data("ano") & "' and periodo = '" & data("periodo") & "' AND reloj = '" & item("reloj").Trim & "' AND concepto = '" & item("concepto").Trim & "'")
                Dim abono = item("sald_act")
                If ajp.Rows.Count > 0 Then
                    If item("fijo") Or item("abono") <= item("sald_act") Then : abono = item("abono") : End If
                    Sqlite.getInstance().sqliteExecute("UPDATE ajustesPro SET monto = '" & ajp.Rows(0)("monto") + abono & "', saldo = '" & ajp.Rows(0)("saldo") + item("sald_act") & "' WHERE id = '" & ajp.Rows(0)("id") & "' ")
                    'ajp.Rows(0)("monto") += abono
                    'ajp.Rows(0)("saldo") += item("sald_act")
                Else
                    If item("fijo") Or item("abono") <= item("sald_act") Then : abono = item("abono") : End If
                    If dtNominaPro.Rows.Count > 0 Then
                        Sqlite.getInstance().insert(New Dictionary(Of String, Object) From {{"ano", data("ano")},
                                                                                        {"periodo", data("periodo")},
                                                                                        {"reloj", item("reloj")},
                                                                                        {"per_ded", "D"},
                                                                                        {"concepto", item("concepto")},
                                                                                        {"descripcion", IIf(item("concepto").ToString.Trim = "BONOS", item("comentario").ToString.Trim, IIf(relojManual = "", Nothing, ""))},
                                                                                        {"monto", abono},
                                                                                        {"clave", Nothing},
                                                                                        {"origen", origen},
                                                                                        {"usuario", Usuario},
                                                                                        {"datetime", Now},
                                                                                        {"afecta_vac", False},
                                                                                        {"factor", dtNominaPro.Rows(0)("factor_dias")},
                                                                                        {"fecha", Nothing},
                                                                                        {"sueldo", dtNominaPro.Rows(0)("sactual")},
                                                                                        {"fecha_fox", Nothing},
                                                                                        {"per_aplica", data("periodo")},
                                                                                        {"ano_aplica", data("ano")},
                                                                                        {"saldo", item("sald_act")}}, "ajustesPro")
                    End If
                End If
            End If
        Next
    End Sub


      ''' <summary>
    ''' Horas. Se cargan las horas del empleado. Se tomará solo el código indispensable de la función original
    ''' </summary>
    ''' <param name="data"></param>
    ''' <param name="relojManual"></param>
    ''' <remarks></remarks>
    Private Sub Horas(ByRef data As Dictionary(Of String, String), Optional relojManual As String = "")

        Dim counter = 0

        '== Filtro para empleado que se agrega manualmente
        Dim filtroIngresoManual = IIf(relojManual <> "", "{0} reloj in ('" & relojManual & "')", "")
        Dim dtPeriodo = sqlExecute("SELECT ano,periodo,fecha_ini,fecha_fin FROM TA.dbo." & data("tabla") & " WHERE ANO = '" & data("ano") & "' AND PERIODO = '" & data("periodo") & "'", "TA")

        '*** En BRP QTO despues vamos a cargar el complemento de dias IVO
        Dim horas_c = Sqlite.getInstance.sqliteExecute("SELECT * FROM ajustesPro WHERE concepto in ('DIAFES', 'DIAPGO', 'DIANAC', 'DIAFUN', 'DIAMAT', 'DIACOR') or (concepto='DIASVA' and descripcion is null) " & String.Format(filtroIngresoManual, "and"))
        Dim incapacidades_c = Sqlite.getInstance.sqliteExecute("SELECT * FROM ajustesPro WHERE concepto in ('DIAIMA', 'DIAING', 'DIAITR') " & String.Format(filtroIngresoManual, "and"))
        Dim faltas_c = Sqlite.getInstance.sqliteExecute("SELECT * FROM horasPro WHERE concepto in ('DIAFIN','DIAFJU','DIAPSG') " & String.Format(filtroIngresoManual, "and"))

        '-- Separar festivos de normales
        Dim horas_fes = Sqlite.getInstance.sqliteExecute("SELECT reloj,concepto,monto FROM horasPro WHERE concepto in ('DIAFES') " & String.Format(filtroIngresoManual, "and"))


        'select reloj,sum(monto) as monto from ajustes_pro where inlist(concepto,"DIASVA") group by reloj into cursor vacaciones_c
        Dim vacaciones_c = Sqlite.getInstance.sqliteExecute("SELECT * FROM ajustesPro WHERE concepto in ('DIASVA') " & String.Format(filtroIngresoManual, "and"))
        Dim permisos_c = Sqlite.getInstance.sqliteExecute("SELECT * FROM ajustesPro WHERE concepto in ('DIAPGO') " & String.Format(filtroIngresoManual, "and"))
        Dim nominaPro = Sqlite.getInstance.sqliteExecute("SELECT * FROM nominaPro " & String.Format(filtroIngresoManual, "where"))

        For Each employ In nominaPro.Rows
            Try
                Dim _desde = Convert.ToDateTime(FechaSQL(dtPeriodo.Rows(0)("fecha_ini")))
                Dim _altaEmp As New Date
                If Not IsDBNull(employ("alta")) Then : _altaEmp = FechaSQL(employ("alta")) : _desde = IIf(_altaEmp > _desde, _altaEmp, _desde) : End If                                                                           'store iif(nomina_pro.alta>_desde,nomina_pro.alta,_desde) to _desde

                Dim _hasta = Convert.ToDateTime(FechaSQL(dtPeriodo.Rows(0)("fecha_ini")))
                If Not IsDBNull(employ("baja")) Then : _hasta = IIf(Convert.ToDateTime(FechaSQL(dtPeriodo.Rows(0)("fecha_ini"))) >= Convert.ToDateTime(employ("baja")) And Convert.ToDateTime(FechaSQL(dtPeriodo.Rows(0)("fecha_ini"))) <= Convert.ToDateTime(employ("baja")),
                                                                    Convert.ToDateTime(employ("baja")), _hasta) : End If                                                                                                            'store iif(between(nomina_pro.baja,_fecha_ini,_fecha_fin) and !empty(baja),nomina_pro.baja,_hasta) to _hasta

                Dim _dias_nor = DateDiff(DateInterval.Day, Convert.ToDateTime(_desde), Convert.ToDateTime(_hasta)) + 1
                Dim horas_employ = horas_c.Select("reloj='" & employ("reloj").ToString.Trim & "'")
                Dim fes_employ = horas_fes.Select("reloj='" & employ("reloj").ToString.Trim & "'")


                '== Condicion siempre y cuando no sean finiquitos [21 abril 2023. Se descuenta a DIANOR - 'DIAFES', 'DIAPGO', 'DIANAC', 'DIASVA', 'DIAFUN', 'DIAMAT', 'DIACOR' independientemente si es finiquito o no
                If horas_employ.Count > 0 Then : _dias_nor -= (horas_employ.CopyToDataTable.Compute("sum(monto)", "")) : End If                                                                                                    'store _dias_nor-horas_c.monto to _dias_nor
                If fes_employ.Count > 0 Then : _dias_nor -= (fes_employ.CopyToDataTable.Compute("sum(monto)", "")) : End If                                                                                                    'store _dias_nor-horas_c.monto to _dias_nor


                If Not IsDBNull(employ("baja")) Then : _dias_nor = IIf(Convert.ToDateTime(employ("baja")) < Convert.ToDateTime(dtPeriodo.Rows(0)("fecha_ini")), 0, _dias_nor) : End If

                If _dias_nor > 0 Then
                    Sqlite.getInstance().insert(New Dictionary(Of String, Object) From {{"reloj", employ("reloj").ToString.Trim},
                                                                                        {"concepto", "DIANOR"},
                                                                                        {"descripcion", "SUELDO UNIDAD"},
                                                                                        {"monto", _dias_nor},
                                                                                        {"periodo", data("periodo")},
                                                                                        {"ano", data("ano")},
                                                                                        {"usuario", Usuario},
                                                                                        {"datetime", Now()},
                                                                                        {"fecha", Nothing},
                                                                                        {"cod_hora", employ("cod_hora")},
                                                                                        {"factor", 1}}, "horasPro")
                End If

                '*** En BRP QTO no debemos pagar nada cuando el empleado esta incapacitado IVO
                Try : employ("incapacidad") = (From i In incapacidades_c.Rows Where i("reloj") = employ("reloj") Select Integer.Parse(i("monto").ToString)).Sum : Catch ex As Exception : employ("incapacidad") = "0" : End Try
                Try : employ("faltas") = (From i In faltas_c.Rows Where i("reloj") = employ("reloj") Select Integer.Parse(i("monto").ToString)).Sum : Catch ex As Exception : employ("faltas") = "0" : End Try
                Try : employ("vacaciones") = (From i In vacaciones_c.Rows Where i("reloj") = employ("reloj") Select Integer.Parse(i("monto").ToString)).Sum : Catch ex As Exception : employ("vacaciones") = "0" : End Try
                'Try : employ("permiso") = (From i In permisos_c.Rows Where i("reloj") = employ("reloj") Select Integer.Parse(i("monto").ToString)).Sum : Catch ex As Exception : employ("permiso") = "0" : End Try

                '== Actualizar campo de incapacidad y faltas en nominaPro
                Sqlite.getInstance.sqliteExecute("UPDATE nominaPro set incapacidad='" & employ("incapacidad").ToString & "' WHERE reloj='" & employ("reloj").ToString.Trim & "'")
                Sqlite.getInstance.sqliteExecute("UPDATE nominaPro set faltas='" & employ("faltas").ToString & "' WHERE reloj='" & employ("reloj").ToString.Trim & "'")

            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        Next

        Dim relojes = (From i In nominaPro.Rows).Distinct().ToDictionary(Function(x) x("reloj"), Function(x) x("factor_dias"))
        Dim updateHoras = Sqlite.getInstance.sqliteExecute("SELECT * FROM horasPro WHERE concepto in ('DIAC50', 'DIAFIN', 'DIAFJU', 'DIAFUN', 'DIAMAT', 'DIANAC', 'DIAPGO', 'DIAPSG', 'DIASUS', 'DIASVA', 'DIAFCH') " &
                                                           String.Format(filtroIngresoManual, "and"))

        For Each i In updateHoras.Rows
            Try : i("factor") = relojes(i("reloj")) : Catch ex As Exception : End Try
        Next

    End Sub

    ''' <summary>
    ''' Conceptos. Recalcula los conceptos de un empleado que es finiquito [Ingreso a finiquitosN, actualizacion de campos de nominaPro, horas y ajustes]
    ''' </summary>
    ''' <remarks></remarks>
    Private Function CalculaConceptoFiniquitosN(calculaMiscelaneos As Boolean, strReloj As String, origen As String) As Boolean
        Try
            '-- Ingresa registro a finiquitosN
            Dim dtPers = Sqlite.getInstance.sqliteExecute("select reloj,nombres,cod_tipo,alta,sactual,alta_antig as alta_vacacion,cod_comp from nominaPro where reloj='" & strReloj & "'")
            infoDic("tabla") = IIf(infoDic("tipoPer") = "sem", "periodos", "periodos_quincenal")

            '-- Respaldo de registro de finiquito [normal o especial] si es que existe
            If tipoModificacion = "Editar" Then RespaldoRegistroFiniquitos(strReloj, "finiquitosE")

            '-- Se borra de finiquitos [si es que existe]
            Sqlite.getInstance.sqliteExecute("delete from finiquitosN where reloj='" & strReloj & "'")

            ProcesoNomina.CargaFiniquitosNormales(dtPers, infoDic)

            '-- Corroborar que se creó registro
            If Sqlite.getInstance.sqliteExecute("select reloj from finiquitosN where reloj='" & strReloj & "' limit 1").Rows.Count > 0 Then

                '-- Se actualiza info de nominaPro
                Sqlite.getInstance.sqliteExecute("update nominaPro set finiquito='True',folio=null,finiquito_esp='False',cod_tipo_nomina='F',factor_dias='1' where reloj='" & strReloj & "'")

                '-- Para calcular los miscelaneos del empleado [finiquito normal]
                If calculaMiscelaneos Then

                    '-- Se eliminan los conceptos de horas y miscelaneos
                    Sqlite.getInstance.sqliteExecute("delete from ajustesPro where reloj='" & strReloj & "');" &
                                                     "delete from horasPro where reloj='" & strReloj & "' and concepto='DIANOR'")

                    '-- Cargar horas y miscelaneos
                    Miscelaneos(infoDic, strReloj, origen)
                    ProcesoNomina.ConceptosFiniquitosNormales(infoDic, strReloj, ProcesoNomina.sePagoAguiAnual)
                    Horas(infoDic, strReloj)
                    ProcesoNomina.DepurarConceptos(strReloj)
                    ProcesoNomina.SueldoConceptoTabla(infoDic)
                    ProcesoNomina.FactorFiniquito(strReloj)
                    ProcesoNomina.CambiarFormatoFechas(True, strReloj)
                End If
            Else
                MessageBox.Show("El registro del finiquito normal no se pudo generar para el proceso, por favor, verifique los datos del empleado", "Error finiquito normal", MessageBoxButtons.OK, MessageBoxIcon.Error)

                If tipoModificacion = "Editar" Then
                    '-- Restaurar respaldo de registro antes de editar [finiquito especial, si lo hubiera]
                    Dim info As List(Of Dictionary(Of String, Object)) = JsonConvert.DeserializeObject(Of List(Of Dictionary(Of String, Object)))(jsonFin)
                    For Each element In info : Sqlite.getInstance.insert(element, "finiquitosE") : Next
                    jsonFin = ""
                End If

                Return False
            End If

            Return True
        Catch ex As Exception : End Try
    End Function

    ''' <summary>
    ''' Función para respaldar el registro, ya sea de finiquitos normales o especiales durante la edición 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RespaldoRegistroFiniquitos(strReloj As String, tabla As String)
        Try
            For Each f In {"finiquito"}
                If dicInfoOrig(f) = "True" Then
                    Dim dt = Sqlite.getInstance.sqliteExecute("select * from " & tabla & " where reloj='" & strReloj & "' limit 1")

                    If dt.Rows.Count > 0 Then
                        jsonFin = JsonConvert.SerializeObject(tableToDict(dt)).Replace("'", "")
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub


    ''' <summary>
    ''' Tabla a diccionario
    ''' </summary>
    ''' <param name="table"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function tableToDict(table As DataTable) As List(Of Dictionary(Of String, String))
        Dim list As New List(Of Dictionary(Of String, String))
        Dim columns = (From i As DataColumn In table.Columns Select i.ColumnName).ToList
        For Each row In table.Rows
            Dim rowDict As New Dictionary(Of String, String)
            For Each column In columns : rowDict.Add(column, row(column).ToString) : Next
            list.Add(rowDict)
        Next
        Return list
    End Function
#End Region

#Region "Funciones"

    Private Sub FocusReloj(panel As String)
        Try
            Select Case panel
                Case "ajustes" : txtAjustesReloj.Select()
                Case "horas" : txtHorasReloj.Select()
                Case "nomina" : txtNominaReloj.Select()
                Case "empleado" : txtEmpleadoReloj.Select()
            End Select
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Titulo de tabs
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function NombresTitulos() As String
        Try
            Select Case nomTabla
                Case "ajustesPro" : Return "Misceláneos"
                Case "horasPro" : Return "Horas"
                Case "nominaPro"
                    If tipoModificacion = "Agregar" Then Return "Empleado"
                    If tipoModificacion = "Editar" Then Return "Nómina"
            End Select

        Catch ex As Exception : End Try
    End Function


    ''' <summary>
    ''' Función que se encarga de validar y agregar la info. que corresponde al empleado en caso de que en el switch se haya marcado finiquito o finiquito especial, durante la edición
    ''' </summary>
    ''' <remarks></remarks>
    Private Function EditaValidacionFiniquitos(ByRef dicFin As Dictionary(Of String, Boolean), strReloj As String) As Boolean
        Try

            For Each kvp As KeyValuePair(Of String, Boolean) In dicFin

                If kvp.Value = True Then
                    Dim msj = If(kvp.Key = "finiquito", MessageBox.Show("Esta a punto de pasar el empleado '" & strReloj & "' a finiquito normal. Con esta modificación se recalcularán " &
                                                                        "todos los conceptos de horas y miscelaneos. ¿Desea continuar la modificación?" &
                                                                        vbNewLine & vbNewLine & "NOTA: Aquellos conceptos agregados manualmente se conservarán.",
                                                                        "Aviso de modificación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question),
                                                        MessageBox.Show("Esta a punto de pasar el empleado '" & strReloj & "' a finiquito especial. Con esta modificación se eliminarán " &
                                                                        "los conceptos que existan en horas y ajustes. ¿Desea continuar la modificación?",
                                                                        "Aviso de modificación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))

                    If msj = Windows.Forms.DialogResult.OK Then
                        Select Case kvp.Key
                            Case "finiquito"
                                '-- Cálculo de miscelaneos
                                If Not CalculaConceptoFiniquitosN(True, strReloj, "MiscelaneoCRUDFiniquito") Then Return False
                        End Select
                    Else
                        Return False
                    End If

                End If
            Next

            Return True
        Catch ex As Exception

        End Try
    End Function

    ''' <summary>
    ''' Agrega nuevo registro
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AgregaInformacion(strOpcion As String)
        Try

            Select Case strOpcion
                Case "AgregarRegistro"
                    AgregaRegistro()

                Case "AgregarEmpleado"
                    AgregaEmpleado()
            End Select

        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Función para agregar registros (a excepcion de nominaPro)
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AgregaRegistro()
        Try
            Dim datos = ""
            Dim campos = ""
            Dim valor = Nothing
            Dim tipoDato = ""
            Dim strInsert = ""
            Dim validacion = ""
            Dim camposVal = ""

            For Each kvp As KeyValuePair(Of String, Object) In dicInfoUsuario
                tipoDato = dtInfo.Select("campo='" & kvp.Key & "'").First.Item("tipo_dato")
                valor = If(tipoDato = "COMBO", kvp.Value.ToString, kvp.Value)

                campos &= kvp.Key & ","
                datos &= IIf(IsNothing(valor), "NULL", "'" & valor & "'") & ","
                validacion &= kvp.Key & "=" & IIf(IsNothing(valor), "NULL", "'" & valor & "'") & ","
            Next

            If datos.Length > 0 Then
                strInsert = "insert into " & nomTabla & " (" & campos.Substring(0, campos.Length - 1) & "" & If({"ajustesPro", "ajustesLazy", "horasLazy"}.Contains(nomTabla), ",origen", "") &
                             ") values (" & datos.Substring(0, datos.Length - 1) & If({"ajustesPro", "ajustesLazy", "horasLazy"}.Contains(nomTabla), ",'IngresoManual'", "") & ")"

                camposVal = validacion.Substring(0, validacion.Length - 1).Replace(",", " and ").Replace("=NULL", " is null")
                Sqlite.getInstance.sqliteExecute(strInsert)

                If Sqlite.getInstance.sqliteExecute("select id from " & nomTabla & " where " & camposVal).Rows.Count > 0 Then
                    MessageBox.Show("Registro agregado con éxito.", "Ingreso registro", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Ocurrió un error durante la inserción de registro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Se agrega empleado a nómina de acuerdo a la opción seleccionada
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AgregaEmpleado()
        Try
            Dim msj = ""
            Dim msj2 = ""

            Select Case cmbEmpleadoTipoNomina.SelectedItem.ToString
                Case "NORMAL"
                    msj = "Esta a punto de agregar al empleado " & txtEmpleadoReloj.Text & " a los registros de nómina del proceso. ¿Desea continuar?"
                    If MessageBox.Show(msj, "Agregar empleado nómina normal", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                        '-- Incluir empleado a nómina
                        IncializaEmpleadoNomina(txtEmpleadoReloj.Text)
                        ProcesoNomina.CambiarFormatoFechas(True, txtEmpleadoReloj.Text)
                    End If

                Case "FINIQUITO NORMAL"
                    msj = "Se agregará al empleado " & txtEmpleadoReloj.Text & " a nómina como finiquito normal. "
                    msj2 = If(swbEmpleadoMiscelaneos.Value, "Se calcularán los conceptos para horas y miscelaneos. ", "Únicamente se incluirá el registro a nómina sin agregar horas y misceláneos. ")
                    msj &= msj2 & "¿Desea continuar?"

                    If MessageBox.Show(msj, "Agregar empleado finiquito normal", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                        '-- Incluir empleado a nómina
                        IncializaEmpleadoNomina(txtEmpleadoReloj.Text)
                        If swbEmpleadoMiscelaneos.Value Then CalculaConceptoFiniquitosN(True, txtEmpleadoReloj.Text, "MiscelaneoCRUDFiniquito")
                    End If
            End Select


        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Edicion de registros
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EditaInformacion()
        Try
            Dim campos = ""
            Dim strUpd = ""

            For Each kvp As KeyValuePair(Of String, Object) In dicInfoOrig
                Dim tipoDato = dtInfo.Select("campo='" & kvp.Key & "'").First.Item("tipo_dato")
                Dim orig = IIf(IsDBNull(kvp.Value), Nothing, If(tipoDato = "CHAR", kvp.Value.ToString, kvp.Value))
                Dim edit = If(tipoDato = "COMBO", If(IsNothing(dicInfoUsuario(kvp.Key)), Nothing, dicInfoUsuario(kvp.Key).ToString), dicInfoUsuario(kvp.Key))

                If orig <> edit Then
                    edicionDatosMsj &= kvp.Key.Replace("_", " ") & " -- " & IIf(IsNothing(edit), "[vacio]", "[" & edit & "]") & vbNewLine
                    campos &= kvp.Key & "=" & IIf(IsNothing(edit), "NULL", "'" & edit & "'") & ","

                    '-- Validacion especial: 
                    '-Si hay diferencias en los campos de finiquito y finiquito_esp para los controles de nominaPro
                    If nomTabla = "nominaPro" AndAlso ({"finiquito", "finiquito_esp"}.Contains(kvp.Key)) Then
                        dicFin(kvp.Key) = edit
                    End If
                End If
            Next

            If campos.Length > 0 Then
                If MessageBox.Show("¿Desea editar el registro con los siguientes datos?" & vbNewLine & vbNewLine & edicionDatosMsj,
                                   "Edición registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

                    '--- Validación especial:
                    '- Si se habilita switch de finiquito normal
                    '* Se eliminan los conceptos de horas y miscelaneos salvo aquellos ingresados manualmente desde interfaz
                    '* Se elimina de finiquitos especiales
                    '* Se elimina de finiquitos normales
                    '* Se actualiza info de nominaPro

                    '- Si se habilita switch de finiquito especial
                    '* Se eliminan TODOS los conceptos que esten en horas y miscelaneos
                    '* Se elimina de finiquitos normales
                    '* Se elimina de finiquitos especiales
                    '* Se actualiza info de nominaPro

                    '-- Si ocurre algún error durante el ingreso de finiquito, se cancela la actualización
                    If Not EditaValidacionFiniquitos(dicFin, reloj) Then
                        dicFin("finiquito") = False
                        dicFin("finiquito_esp") = False
                        Exit Sub
                    End If

                    strUpd = "update " & nomTabla & " set " & campos.Substring(0, campos.Length - 1) &
                             "" & If({"ajustesPro", "ajustesLazy", "horasLazy"}.Contains(nomTabla), ",origen='EdicionManual'", "") & " where id=" & infoDic("id")

                    Sqlite.getInstance.sqliteExecute(strUpd)
                End If
            End If


        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Valores que se asignan de manera automatica al momento de agregar un nuevo registro
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ValoresAutomaticosCtrl(strReloj As String)
        Try
            Dim dtEmp = Sqlite.getInstance.sqliteExecute("select ano,periodo,cod_hora from nominaPro where reloj='" & strReloj & "' limit 1")

            Select Case nomTabla.ToString.ToLower.Replace("pro", "").Replace("lazy", "")
                Case "horas"
                    txtHorasAno.Text = If(dtEmp.Rows.Count > 0, dtEmp.Rows(0)("ano"), "")
                    txtHorasPeriodo.Text = If(dtEmp.Rows.Count > 0, dtEmp.Rows(0)("periodo"), "")
                    txtHorasCodHora.Text = If(dtEmp.Rows.Count > 0, dtEmp.Rows(0)("cod_hora"), "")
                Case "ajustes"
                    txtAjustesAno.Text = If(dtEmp.Rows.Count > 0, dtEmp.Rows(0)("ano"), "")
                    txtAjustesPeriodo.Text = If(dtEmp.Rows.Count > 0, dtEmp.Rows(0)("periodo"), "")
            End Select

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Información que se requiere de la BD
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InfoDatatables()
        Try
            dtTipoComp = sqlExecute("select distinct tipo_comp as tipocomp from nomina.dbo.sueldo_cobertura")
            dtCodClase = sqlExecute("select distinct cod_clase as codclase from personal.dbo.personal where cod_clase is not null")
            dtConceptos = sqlExecute("select rtrim(concepto) as id,(rtrim(concepto)+' - '+upper(rtrim(c.nombre))) as concepto," &
                                     "(isnull(upper(rtrim(c.cod_naturaleza)),'NO INFO')) as naturaleza " &
                                     "from nomina.dbo.conceptos c " &
                                     "left join nomina.dbo.naturalezas n on c.COD_NATURALEZA=n.COD_NATURALEZA")

            dtTipoNomina = ProcesoNomina.creaDt("tiponomina", "String")
            dtTipoNomina.Rows.Add("NORMAL")
            dtTipoNomina.Rows.Add("FINIQUITO NORMAL")

            dtTipoCred = ProcesoNomina.creaDt("tipocredito", "String")
            dtTipoCred.Rows.Add("Ninguno")
            dtTipoCred.Rows.Add("1")
            dtTipoCred.Rows.Add("2")
            dtTipoCred.Rows.Add("3")

        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Se cargan los controles para el formato de editar registro
    ''' </summary>
    ''' <param name="tabla"></param>
    ''' <remarks></remarks>
    Private Sub CargarInformacionEditar(ByVal dtRegistro As DataTable, nombreTabla As String, dtInfoCamposValidos As DataTable)
        Try
            Dim panel = ""
            Dim campo = ""
            Dim tipo_dato = ""
            Dim activo = False

            '-- Determina el nombre de los paneles con los que se trabajaran
            If {"horasPro", "horasLazy"}.Contains(nombreTabla) Then panel = "horas"
            If {"ajustesPro", "ajustesLazy"}.Contains(nombreTabla) Then panel = "ajustes"
            If {"nominaPro"}.Contains(nombreTabla) Then panel = "nomina" : noPanelesPrincipales = 2

            '-- Guardar info. original en diccionario
            DiccionarioInfo(dtRegistro, dtInfoCamposValidos)

            For Each campos In dtInfoCamposValidos.Select("", "tipo_dato")
                For Each info In dtRegistro.Rows
                    campo = campos("campo").Replace("_", "")
                    tipo_dato = campos("tipo_dato")
                    activo = CBool(campos("activo"))

                    If dtRegistro.Columns.Contains(campos("campo")) Then

                        '-- Info para el control
                        InfoCargaControl(campo, tipo_dato, info(campos("campo")))

                        '-- Si el campo  es válido entonces se muesta el panel del control
                        ctrlInterfaz("pnl" & panel & campo).Visible = True
                        ctrlInterfaz("pnl" & panel & campo).Enabled = ExcepVal(nombreTabla, campos("campo"), activo, "CargarInformacion")
                    End If
                Next
            Next

            '-- 335px si solo hay controles en el primer panel, 630px si se ocupan los dos
            If {"horas", "ajustes"}.Contains(panel) Then
                Me.Size = New Size(380, Me.Height)
                Me.MinimumSize = New Size(Me.Width, Me.Height)
                Me.MaximumSize = New Size(Me.Width, Me.Height)
            Else
                Me.Size = New Size(718, Me.Height)
                Me.MinimumSize = New Size(Me.Width, Me.Height)
                Me.MaximumSize = New Size(Me.Width, Me.Height)
            End If

            '-- Focus de control
            FocusReloj(panel)

        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Se cargan los controles para el formato de agregar registro
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CargarInformacionAgregar(ByVal dtRegistro As DataTable, nombreTabla As String, dtInfoCamposValidos As DataTable)
        Try
            Dim panel = ""
            Dim campo = ""
            Dim tipo_dato = ""
            Dim activo = False

            '-- Determina el nombre de los paneles con los que se trabajaran
            If {"horasPro", "horasLazy"}.Contains(nombreTabla) Then Panel = "horas"
            If {"ajustesPro", "ajustesLazy"}.Contains(nombreTabla) Then Panel = "ajustes"
            If {"nominaPro"}.Contains(nombreTabla) Then panel = "empleado"

            '-- Guardar info. original en diccionario
            'DiccionarioInfo(dtRegistro, dtInfoCamposValidos)

            '-- Controles vacios
            Dim dt = dtRegistro.Clone
            dt.Rows.Add()

            For Each campos In dtInfoCamposValidos.Select("", "tipo_dato")
                For Each info In dt.Rows

                    If dtRegistro.Columns.Contains(campos("campo")) Then
                        campo = campos("campo").Replace("_", "")
                        tipo_dato = campos("tipo_dato")
                        activo = CBool(campos("activo"))

                        '-- Info para el control
                        InfoCargaControl(campo, tipo_dato, info(campos("campo")))

                        '-- Si el campo  es válido entonces se muesta el panel del control
                        ctrlInterfaz("pnl" & panel & campo).Visible = True
                        ctrlInterfaz("pnl" & panel & campo).Enabled = activo
                    End If
                Next
            Next

            '-- 335px si solo hay controles en el primer panel, 630px si se ocupan los dos
            If {"horas", "ajustes"}.Contains(panel) Then
                Me.Size = New Size(380, Me.Height)
                Me.MinimumSize = New Size(Me.Width, Me.Height)
                Me.MaximumSize = New Size(Me.Width, Me.Height)
            Else
                Me.Size = New Size(380, 290)
                Me.MinimumSize = New Size(Me.Width, Me.Height)
                Me.MaximumSize = New Size(Me.Width, Me.Height)
            End If

            '-- Focus de control
            FocusReloj(panel)

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Agrega elementos al combobox
    ''' </summary>
    ''' <param name="combo"></param>
    ''' <param name="dtInfo"></param>
    ''' <remarks></remarks>
    Private Sub AgregarItemsComboBox(ByRef combo As DevComponents.DotNetBar.Controls.ComboBoxEx,
                                     ByVal dtInfo As DataTable,
                                     Optional strFiltroDt As String = "")
        Try
            Dim dt = dtInfo

            '-- Crea un dt solo con las columnas deseadas
            If strFiltroDt <> "" Then
                dt = New DataView(dtInfo, "", "", DataViewRowState.CurrentRows).ToTable("", False, strFiltroDt)
            End If

            For Each elem In dt.Rows
                Dim cmbItem As New DevComponents.Editors.ComboItem
                cmbItem.Text = elem(strFiltroDt)
                cmbItem.TextAlignment = System.Drawing.StringAlignment.Center
                cmbItem.TextLineAlignment = System.Drawing.StringAlignment.Center
                combo.Items.Add(cmbItem)
            Next

            combo.SelectedIndex = -1

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Se guarda la información ingresada por el usuario
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InfoControlUsuario()
        Try
            '--- Crea diccionario con info. actual
            For Each valor In dtInfo.Rows
                Dim tipoDato = dtInfo.Select("campo='" & valor("campo") & "'").First.Item("tipo_dato")
                Dim campo = valor("campo").ToLower.Replace("_", "")
                Dim tabla = valor("tabla")
                Dim nulos = valor("nulos")

                '-- Tipo de dato para acceder al control
                Select Case tipoDato
                    Case "BOOLEAN"
                        dicInfoUsuario(valor("campo")) = ExcepVal(tabla, valor("campo"), ctrlInterfaz(campo).Value, "InfoControlUsuario")
                    Case "CHAR"
                        dicInfoUsuario(valor("campo")) = If(ctrlInterfaz(campo).Text.ToString.Trim = "", Nothing, ctrlInterfaz(campo).Text.ToString)
                    Case "COMBO"
                        If {"sueldoCobertura", "nominaPro"}.Contains(tabla) Then
                            dicInfoUsuario(valor("campo")) = ExcepVal(tabla, valor("campo"), ctrlInterfaz(campo).SelectedItem, "InfoControlUsuario")
                        Else
                            dicInfoUsuario(valor("campo")) = ctrlInterfaz(campo).SelectedValue
                        End If
                    Case "DATE"
                        If {"sueldoCobertura"}.Contains(tabla) And campo = "fhafin" Then
                            dicInfoUsuario(valor("campo")) = IIf(IsNothing(ctrlInterfaz(campo).ValueObject), "1900-01-01", ctrlInterfaz(campo).Text)
                        Else
                            dicInfoUsuario(valor("campo")) = IIf(IsNothing(ctrlInterfaz(campo).ValueObject), Nothing, ctrlInterfaz(campo).Text)
                        End If
                    Case Else
                        If IsNothing(ctrlInterfaz(campo).ValueObject) And {"nominaPro"}.Contains(tabla) And campo = "factordias" Then
                            dicInfoUsuario(valor("campo")) = Nothing
                        Else
                            If IsNothing(ctrlInterfaz(campo).ValueObject) Then
                                dicInfoUsuario(valor("campo")) = IIf(nulos, Nothing, 0)
                            Else
                                dicInfoUsuario(valor("campo")) = ctrlInterfaz(campo).Value
                            End If
                        End If

                End Select
            Next

        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Validar los datos de los controles. Retorna false si validación es incorrecta
    ''' </summary>
    ''' <remarks></remarks>
    Private Function InfoValidacion() As ArrayList
        Try
            Dim errLst As New ArrayList

            For Each kvp As KeyValuePair(Of String, Object) In dicInfoUsuario
                If IsNothing(kvp.Value) And Not (dtInfo.Select("campo='" & kvp.Key & "'").First.Item("nulos")) Then
                    errLst.Add(kvp.Key)
                End If
            Next

            '-- Si al momento de agregar un reloj no existe en personal, mandar error
            If tipoModificacion = "Agregar" Then
                Dim r = If(IsNothing(dicInfoUsuario("reloj")), "", dicInfoUsuario("reloj"))
                Dim dtPersonalComp = sqlExecute("select reloj from personal.dbo.personal where reloj='" & r & "'")
                If dtPersonalComp.Rows.Count = 0 Then
                    If Not errLst.Contains("reloj") Then
                        errLst.Add("reloj - No existe en personal")
                    Else
                        errLst.Remove("reloj")
                        errLst.Add("reloj - No existe en nómina de proceso")
                    End If
                End If
            End If

            Return errLst
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Función para validar la teclas presionadas de los textbox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ValidaTextbox(sender As Object, e As KeyPressEventArgs) Handles txtHorasReloj.KeyPress, txtAjustesReloj.KeyPress,
                                                                                 txtNominaReloj.KeyPress
        Try

            Dim infoFormato = dtInfo.Select("campo='" & sender.name.ToString.Substring(sender.name.ToString.Length - 5, 5) & "' and codigo is not null")

            If infoFormato.Count > 0 Then
                Select Case infoFormato.First.Item("codigo")
                    Case "SoloNumeros"
                        If Not Char.IsNumber(e.KeyChar) And Not (e.KeyChar = Convert.ToChar(Keys.Back)) Then e.KeyChar = Nothing
                    Case "SoloLetras"
                        If Not Char.IsLetter(e.KeyChar) And Not (e.KeyChar = Convert.ToChar(Keys.Back)) Then e.KeyChar = Nothing
                    Case "SoloNumerosLetras"
                        If Not Char.IsLetter(e.KeyChar) And Not Char.IsNumber(e.KeyChar) And Not (e.KeyChar = Convert.ToChar(Keys.Back)) Then e.KeyChar = Nothing
                End Select
            End If
        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Diccionarios con la info original y estructura de diccionario con la info. de los controles
    ''' </summary>
    ''' <param name="dtInfo"></param>
    ''' <param name="dtCamposValidos"></param>
    ''' <remarks></remarks>
    Private Sub DiccionarioInfo(ByVal dtInfo As DataTable, ByVal dtCamposValidos As DataTable, Optional tipoMod As String = "")
        Try
            For Each x In dtCamposValidos.Rows
                If tipoMod = "" Then

                    dicInfoOrig.Add(x("campo"),
                                    ExcepVal(nomTabla, x("campo"), dtInfo.Rows(0)(x("campo")), "DiccionarioInfo"))

                    dicInfoUsuario.Add(x("campo"), Nothing)
                Else
                    dicInfoUsuario.Add(x("campo"), Nothing)
                End If
            Next

        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Función para regresar valores de excepciones bajo ciertas condiciones
    ''' </summary>
    ''' <remarks></remarks>
    Private Function ExcepVal(tabla As String, campo As String, valor As Object, Optional contexto As String = "") As Object
        Try
            Select Case tabla
                Case "ajustesPro"
                Case "ajustesLazy"
                Case "horasPro"
                Case "horasLazy"
                Case "nominaPro"
                    If (contexto = "DiccionarioInfo" And campo = "cobro_segviv") AndAlso valor = "0" Then Return "False"
                    If (contexto = "DiccionarioInfo" And campo = "tipo_credito") AndAlso valor = DBNull.Value Then Return "Ninguno"
                    If (contexto = "InfoControlUsuario" And {"procesar", "cobro_segviv", "finiquito", "finiquito_esp"}.Contains(campo)) AndAlso valor Then Return "True"
                    If (contexto = "InfoControlUsuario" And {"procesar", "cobro_segviv", "finiquito", "finiquito_esp"}.Contains(campo)) AndAlso Not valor Then Return "False"
                    If (contexto = "InfoControlUsuario" And {"sindicalizado"}.Contains(campo)) AndAlso valor Then Return 1
                    If (contexto = "InfoControlUsuario" And {"sindicalizado"}.Contains(campo)) AndAlso Not valor Then Return 0
                    If (contexto = "InfoControlUsuario" And campo = "tipo_Credito") AndAlso valor.ToString = "Ninguno" Then Return Nothing
                Case Else
                    If contexto = "InfoCargaControl" And campo = "concepto" Then Return dtConceptos
                    If contexto = "InfoCargaControl" And campo = "tipocomp" Then Return dtTipoComp
                    If contexto = "InfoCargaControl" And campo = "codclase" Then Return dtCodClase
                    If contexto = "InfoCargaControl" And campo = "tipocredito" Then Return dtTipoCred
                    If contexto = "InfoCargaControl" And campo = "tiponomina" Then Return dtTipoNomina
            End Select

            Return valor

        Catch ex As Exception
            Return valor
        End Try
    End Function

    ''' <summary>
    ''' Se asignan los datos predeterminados a lo controles que lo requieran, es decir, que provienen de un registro de tabla
    ''' </summary>
    ''' <param name="strNomControl"></param>
    ''' <remarks></remarks>
    Private Sub InfoCargaControl(nomCtrl As String, tipoDato As String, dato As Object)
        Try
            Dim d = dato
            Dim val = {DBNull.Value}
            Try : If val(0).Equals(d) Then d = Nothing
            Catch ex As Exception : d = Nothing : End Try

            Select Case tipoDato
                Case "BOOLEAN"
                    If {Nothing, "0", "False"}.Contains(d) Then d = False Else d = True
                    ctrlInterfaz(nomCtrl).Value = d
                Case "CHAR"
                    ctrlInterfaz(nomCtrl).Text = d
                Case "DATE"
                    ctrlInterfaz(nomCtrl).ValueObject = d
                Case "DECIMAL"
                    If IsNothing(d) Then
                        ctrlInterfaz(nomCtrl).ValueObject = Nothing
                    Else
                        ctrlInterfaz(nomCtrl).Value = d
                    End If
                Case "INT"
                    If IsNothing(d) Then
                        ctrlInterfaz(nomCtrl).ValueObject = Nothing
                    Else
                        ctrlInterfaz(nomCtrl).Value = d
                    End If
                Case "COMBO"
                    Dim dt = ExcepVal(Nothing, nomCtrl, Nothing, "InfoCargaControl")

                    If nomCtrl = "concepto" Then
                        ctrlInterfaz(nomCtrl).DataSource = dt

                        If IsNothing(d) Then
                            ctrlInterfaz(nomCtrl).SelectedIndex = -1
                        Else
                            ctrlInterfaz(nomCtrl).SelectedValue = d
                        End If
                    Else
                        Dim cont = 0
                        AgregarItemsComboBox(ctrlInterfaz(nomCtrl), dt, nomCtrl)

                        For Each elem In ctrlInterfaz(nomCtrl).Items
                            If elem.ToString = d Then
                                ctrlInterfaz(nomCtrl).SelectedIndex = cont
                                Exit Sub
                            End If
                            cont += 1
                        Next
                        ctrlInterfaz(nomCtrl).SelectedIndex = 0
                    End If

            End Select

        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Obtiene el control dinámico creado de acuerdo a su nombre
    ''' </summary>
    ''' <param name="strNomControl"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ctrlInterfaz(strNomControl As String) As Object
        Try
            For i As Integer = 0 To noPanelesPrincipales - 1
                For Each ctrl As Panel In panelesControles(i).Controls
                    If IsNothing(ctrl) Then Continue For
                    If ctrl.Name.ToString.ToLower.Contains(strNomControl) Then
                        If strNomControl.Contains("pnl") And ctrl.Name.ToString.ToLower = strNomControl Then
                            Return ctrl
                        Else
                            For Each ctrlPnl In ctrl.Controls
                                Dim flag = ctrlPnl.Name.ToString.ToLower
                                Dim flag2 = flag.Replace(flag.Replace(strNomControl, ""), "")

                                If flag2 = strNomControl Then
                                    Return ctrlPnl
                                End If
                            Next
                        End If
                    End If
                Next
            Next
        Catch ex As Exception : End Try
    End Function

    ''' <summary>
    ''' Se obtienen los paneles principales de controles con los que se trabajarán
    ''' </summary>
    ''' <param name="nombreTabla"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function PanelesInformación(nombreTabla As String) As Object

        Dim contenedorPnl = {Nothing, Nothing, Nothing}

        '-- Horas
        If nombreTabla.ToString.ToLower.Contains("horas") Then
            contenedorPnl(0) = pnlHoras
            contenedorPnl(1) = pnlHoras2
            tabPagHoras.Text = NombresTitulos()
        Else
            tabCompleta.TabPages.Remove(tabPagHoras)
        End If

        '-- Ajustes
        If nombreTabla.ToString.ToLower.Contains("ajustes") Then
            contenedorPnl(0) = pnlAjustes
            contenedorPnl(1) = pnlAjustes2
            tabPagMisc.Text = NombresTitulos()
        Else
            tabCompleta.TabPages.Remove(tabPagMisc)
        End If

        '-- Nomina (editar)
        If nombreTabla.ToString.ToLower.Contains("nominapro") And tipoModificacion = "Editar" Then
            contenedorPnl(0) = pnlNomina
            contenedorPnl(1) = pnlNomina2
            tabPagNominaPro.Text = NombresTitulos()
        Else
            tabCompleta.TabPages.Remove(tabPagNominaPro)
        End If

        '-- Nomina (agregar)
        If nombreTabla.ToString.ToLower.Contains("nominapro") And tipoModificacion = "Agregar" Then
            contenedorPnl(0) = pnlAgregaEmpleado
            tabAgregaEmpleado.Text = NombresTitulos()
        Else
            tabCompleta.TabPages.Remove(tabAgregaEmpleado)
        End If

        Return contenedorPnl
    End Function
#End Region


#Region "Eventos"

    ''' <summary>
    ''' Si cambia el concepto, se cambia la naturaleza y descripción de los respectivos controles
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub InfoCambiaConcepto(sender As Object, e As EventArgs) Handles cmbHorasConcepto.SelectedValueChanged, cmbAjustesConcepto.SelectedValueChanged,
                                                                             cmbHorasConcepto.TextChanged, cmbAjustesConcepto.TextChanged
        Try
            Dim valor = ""

            Select Case sender.name
                Case "cmbHorasConcepto"
                    valor = If(IsNothing(cmbHorasConcepto.SelectedValue), cmbHorasConcepto.Text, cmbHorasConcepto.SelectedValue)
                    txtHorasPerDed.Text = dtConceptos.Select("id='" & valor & "'").First.Item("naturaleza")
                    txtHorasDescripcion.Text = dtConceptos.Select("id='" & valor & "'").First.Item("concepto").ToString.Split("-")(1).Trim
                Case "cmbAjustesConcepto"
                    valor = If(IsNothing(cmbAjustesConcepto.SelectedValue), cmbAjustesConcepto.Text, cmbAjustesConcepto.SelectedValue)
                    txtAjustesPerDed.Text = dtConceptos.Select("id='" & valor & "'").First.Item("naturaleza")
                    txtAjustesDescripcion.Text = dtConceptos.Select("id='" & valor & "'").First.Item("concepto").ToString.Split("-")(1).Trim
            End Select

        Catch ex As Exception
            txtHorasPerDed.Text = "" : txtHorasDescripcion.Text = ""
            txtAjustesPerDed.Text = "" : txtAjustesDescripcion.Text = ""
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Aceptar cambios
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAcept_Click(sender As Object, e As EventArgs) Handles btnAcept.Click
        Try
            Dim errores As New ArrayList
            InfoControlUsuario()
            errores = InfoValidacion()

            If errores.Count = 0 Then
                Me.Cursor = Cursors.WaitCursor
                Select Case tipoModificacion
                    Case "Editar"
                        EditaInformacion()
                    Case "Agregar"
                        If tipoModificacion = "Agregar" And nomTabla = "nominaPro" Then
                            AgregaInformacion("AgregarEmpleado")
                        Else
                            AgregaInformacion("AgregarRegistro")
                        End If
                End Select
                Me.Cursor = Cursors.Default
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("Por favor, ingrese el dato correcto de lo siguiente:" &
                                vbNewLine & vbNewLine &
                                (String.Join(vbNewLine, (From i In errores Select i.ToString.Replace("_", " ")))),
                                "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception : End Try
    End Sub

    Private Sub cmbHorasConcepto_Leave(sender As Object, e As EventArgs) Handles cmbHorasConcepto.Leave
        Try
            If cmbHorasConcepto.Text.Length <= 6 Then
                cmbHorasConcepto.SelectedValue = cmbHorasConcepto.Text
            End If
        Catch ex As Exception : End Try
    End Sub

    Private Sub cmbAjustesConcepto_Leave(sender As Object, e As EventArgs) Handles cmbAjustesConcepto.Leave
        Try
            If cmbAjustesConcepto.Text.Length <= 6 Then
                cmbAjustesConcepto.SelectedValue = cmbAjustesConcepto.Text
            End If
        Catch ex As Exception : End Try
    End Sub

    Private Sub cmbEmpleadoTipoNomina_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbEmpleadoTipoNomina.SelectedValueChanged
        Try
            Select Case cmbEmpleadoTipoNomina.SelectedItem.ToString
                Case "NORMAL"
                    pnlEmpleadoMiscelaneos.Enabled = False
                Case "FINIQUITO NORMAL"
                    pnlEmpleadoMiscelaneos.Enabled = True
            End Select

            swbEmpleadoMiscelaneos.Value = False

        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Al momento de agregar registro, agregar automáticamente ciertos datos de acuerdo al reloj ingresado
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ValoresEstaticos(sender As Object, e As EventArgs) Handles txtHorasReloj.TextChanged, txtAjustesReloj.TextChanged
        Try : ValoresAutomaticosCtrl(sender.Text) : Catch ex As Exception
        End Try
    End Sub
#End Region

  

End Class