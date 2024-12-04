Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions

Public Class frmCalcAgui

    '*****************VARIABLES GENERALES  A UTILIZAR 

    '***-----Variables
    Dim anio As String = ""
    Dim periodo As String = ""
    Dim fini_nom As String = ""
    Dim ffin_nom As String = ""
    Dim fecha_pago As String = ""
    Dim num_mes As String = ""
    Dim asentado As String = ""
    Dim cod_comp As String = ""
    Dim filtroNomina As String = ""
    Dim UMA As Double = 0.0
    Dim SALMIN As Double = 0.0
    Dim prima_riesg_imss As Double = 0.0
    Dim cuota_segviv As Double = 0.0
    Dim UMI As Double = 0.0 ' Valor del factor de descuento para Infonavit
    Dim tipoNomEsp As String = "agui"

    '*-----Variables del cálculo
    '------PERCEPCI0NES
    Dim DIASPA As Double = 0.0 ' Dias pagados
    Dim DIASAG As Double = 0.0 ' Dias de aguinaldo
    Dim PERAGI As Double = 0.0
    Dim PEXAGI As Double = 0.0
    Dim OTPGRA As Double = 0.0


    '*------DEDUCCIONES
    Dim ISPT As Double = 0.0   ' ISR Causado
    Dim SUBCAU As Double = 0.0 ' Subsidio al empleo causado
    Dim ISPTRE As Double = 0.0 ' ISR realmenteRETENIDO DEL PERIDOO
    Dim SUBPAG As Double = 0.0 ' Subsidio al empleo realmente pagado
    Dim PENALI As Double = 0.0
    Dim PENAL2 As Double = 0.0
    Dim PENAL3 As Double = 0.0
    Dim OTRASD As Double = 0.0

    '--TOTALES
    Dim PERGRA As Double = 0.0 ' Total de percep gravable
    Dim PEREXE As Double = 0.0  ' Total de percepción exenta
    Dim TOTPER As Double = 0.0 ' Total de percepciones
    Dim TOTDED As Double = 0.0 ' Total de deducciones
    Dim NETO As Double = 0.0   ' Total Neto



    '****---DATATABLES 
    Dim dtPeriodoAgui As New DataTable
    Dim dtNominaPro As New DataTable
    Dim dtHorasPro As New DataTable
    Dim dtAjustesPro As New DataTable
    Dim dtPensAlim As New DataTable
    Dim dtConceptos As New DataTable
    Dim dtTurnos As New DataTable
    Dim dtInfonavit As New DataTable
    Dim dtDifConceptos As New DataTable
    Dim dtFactAgui As New DataTable
    Dim dtMovimientos_pro As New DataTable

    Private Sub frmCalcAgui_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '-- Cargar el año y periodo actual abierto inicializado


        '--MODIFICACION: Tipos ausentismo     ERNESTO FEB/21
        tiposAusentismoLista()
        '--
        CargaDatosIniciales()
    End Sub

    Private Sub CargaDatosIniciales()
        Try
            '-----2021-10-28 - AOS: Cargar cod_comp dinámicamente
            Dim dtCod_Comp As DataTable
            dtCod_Comp = sqlExecute("select COD_COMP from cias where CIA_DEFAULT=1", "PERSONAL")
            If (Not dtCod_Comp.Columns.Contains("Error") And dtCod_Comp.Rows.Count > 0) Then
                Try : cod_comp = dtCod_Comp.Rows(0).Item("cod_comp").ToString.Trim : Catch ex As Exception : cod_comp = "" : End Try
            End If

            ''--MODIFICACION: Se modifico para pruebas con anio 2020        ERNESTO FEB2021
            Dim AnioInt As Integer = Date.Now.Year
            '   Dim AnioInt As Integer = 2020 ' PRUEBAS
            '--

            anio = AnioInt.ToString.Trim  ' Tomar el anio actual

            Dim QPerAgui As String = "select * from periodos where ano='" & anio & "' and observaciones like '%aguinaldo%' and PERIODO_ESPECIAL=1"
            dtPeriodoAgui = sqlExecute(QPerAgui, "TA")
            If (Not dtPeriodoAgui.Columns.Contains("Error") And dtPeriodoAgui.Rows.Count > 0) Then
                Try : periodo = dtPeriodoAgui.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : periodo = "" : End Try
                Try : fecha_pago = FechaSQL(dtPeriodoAgui.Rows(0).Item("fecha_pago").ToString.Trim) : Catch ex As Exception : fecha_pago = "" : End Try
                Try : fini_nom = FechaSQL(dtPeriodoAgui.Rows(0).Item("fini_nom").ToString.Trim) : Catch ex As Exception : fini_nom = "" : End Try
                Try : ffin_nom = FechaSQL(dtPeriodoAgui.Rows(0).Item("ffin_nom").ToString.Trim) : Catch ex As Exception : ffin_nom = "" : End Try
                Try : asentado = dtPeriodoAgui.Rows(0).Item("asentado").ToString.Trim : Catch ex As Exception : asentado = "" : End Try
                Try : num_mes = dtPeriodoAgui.Rows(0).Item("num_mes").ToString.Trim : Catch ex As Exception : num_mes = "" : End Try

                txtAnio.Text = anio
                txtPeriodo.Text = periodo & " del " & fini_nom & " al " & ffin_nom
            Else
                MessageBox.Show("No hay un periodo de aguinaldo a inicializar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If


        Catch ex As Exception

            MessageBox.Show("No se pudo inicializar el proceso", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub

        End Try
    End Sub

    '--NUEVA MODIFICACION: Carga la lista de ausentismos    ERNESTO FEB2021
    Private Sub tiposAusentismoLista()

        Try
            Dim dtAusentismos As DataTable
            dtAusentismos = sqlExecute("select rtrim(TIPO_AUS) as TIPO,rtrim(NOMBRE) as NOMBRE from tipo_ausentismo", "TA")

            '--Agrega los ausentismos a un control de listbox
            If dtAusentismos.Rows.Count > 0 Then
                Dim tipo As String : Dim nombre As String
                For Each x As DataRow In dtAusentismos.Rows
                    tipo = x.Item("TIPO")
                    nombre = x.Item("NOMBRE")
                    lstFiltro.Items.Add(tipo & " - " & nombre)
                Next
            End If
        Catch ex As Exception : End Try
    End Sub
    '-- HASTA ACA

    '--NUEVA MODIFICACION: Ocultar paneles  ERNESTO FEB2021
    Private Sub OcultaPaneles(filtros As Boolean, criterios As Boolean)
        gpFiltro.Enabled = filtros
        gpFiltro.Visible = filtros
        gpCriterios.Enabled = criterios
        gpCriterios.Visible = criterios
    End Sub
    '-- HASTA ACA

    Private Sub btnCalcAgui_Click(sender As Object, e As EventArgs) Handles btnCalcAgui.Click
        Try
            If (asentado = "1") Then
                MessageBox.Show("El periodo de aguinaldo ya encuentra asentado/cerrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Me.Close()
                Me.Dispose()
                Exit Sub
            End If
            InicializaProcNomEspecial(txtAnio.Text.Trim, periodo, tipoNomEsp, num_mes)
            ActualizaStatus(txtAnio.Text.Trim, periodo, tipoNomEsp, num_mes)
            CalculoAnualAguinaldo(txtAnio.Text.Trim, txtPeriodo.Text.Trim, "G", "procesar=1", "")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub ActualizaStatus(ByRef anio As String, periodo As String, _tipoNom As String, _numMes As String)
        Try
            Dim dtStProc As DataTable = sqlExecute("select distinct ano,periodo from nomina_pro_esp order by periodo asc", "NOMINA")
            If (Not dtStProc.Columns.Contains("Error") And dtStProc.Rows.Count > 0) Then
                Dim _anioSt As String = "", _perSt As String = ""
                Try : _anioSt = dtStProc.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : _anioSt = "" : End Try
                Try : _perSt = dtStProc.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : _perSt = "" : End Try
                sqlExecute("insert into status_proceso_esp (ano,periodo,avance,usuario,datetime) values ('" & _anioSt & "','" & _perSt & "','2','" & Usuario & "',Getdate())", "NOMINA")
            End If
        Catch ex As Exception

        End Try
    End Sub


    Public Function CalculoAnualAguinaldo(ByRef anio As String, periodo As String, indicProc As String, _filtroNom As String, _reloj As String) As Integer
        Try
            '---Mostrar Progress
            Dim i As Integer = -1
            frmTrabajando.Text = "Calculando aguinaldo"
            frmTrabajando.Avance.IsRunning = True
            frmTrabajando.lblAvance.Text = "Calculando nómina"
            ActivoTrabajando = True
            frmTrabajando.Show()
            Application.DoEvents()

            If (indicProc = "I") Then CargaDatosIniciales() ' Si viene del recalc a un solo empleado, que cargue datos iniciales

            If (anio <> "" And periodo <> "") Then    'A--Validar que exista ya un periodo abierto, es decir, que txtAnio y txtPerido no estén vacíos

                Dim qNom As String = ""
                If (indicProc = "G") Then qNom = "select * from nomina_pro_esp order by reloj asc" Else If (indicProc = "I") Then qNom = "select * from nomina_pro_esp where reloj='" & _reloj & "'"
                dtNominaPro = sqlExecute(qNom, "NOMINA")

                If ((dtNominaPro.Columns.Contains("Error")) Or (Not dtNominaPro.Columns.Contains("Error") And dtNominaPro.Rows.Count = 0)) Then
                    MessageBox.Show("No existen empleados para procesar su nómina en este periodo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Function
                Else

                    '--- Si sí hay empleados para procesar su nómina, cargamos todas las tablas que nos van a servir para el cálculo de la nomina
                    If indicProc = "G" Then sqlExecute("truncate table movimientos_pro_esp", "NOMINA") 'Limpiamos la tabla movimientos_pro
                    If indicProc = "G" Then sqlExecute("truncate table movimientos_imss_pro_esp", "NOMINA") 'Limpiamos la tabla movimientos_imss_pro
                    If indicProc = "I" Then sqlExecute("delete from movimientos_pro_esp where reloj='" & _reloj & "'", "NOMINA")
                    If indicProc = "I" Then sqlExecute("delete from movimientos_imss_pro_esp where reloj='" & _reloj & "'", "NOMINA")

                    If indicProc = "G" Then dtHorasPro = sqlExecute("SELECT * from horas_pro_esp", "NOMINA") Else If (indicProc = "I") Then dtHorasPro = sqlExecute("SELECT * from horas_pro_esp where reloj='" & _reloj & "'", "NOMINA")
                    If indicProc = "G" Then dtAjustesPro = sqlExecute("SELECT * from ajustes_pro_esp", "NOMINA") Else If (indicProc = "I") Then dtAjustesPro = sqlExecute("SELECT * from ajustes_pro_esp where reloj='" & _reloj & "'", "NOMINA")
                    If indicProc = "G" Then dtPensAlim = sqlExecute("select * from ctas_pens_alim", "PERSONAL") Else If (indicProc = "I") Then dtPensAlim = sqlExecute("select * from ctas_pens_alim where reloj='" & _reloj & "'", "PERSONAL")

                    dtConceptos = sqlExecute("SELECT * from conceptos", "NOMINA")
                    dtTurnos = sqlExecute("select * from turnos where COD_COMP='" & cod_comp & "'", "PERSONAL")
                    If indicProc = "G" Then dtInfonavit = sqlExecute("SELECT * from infonavit", "PERSONAL") Else If (indicProc = "I") Then dtInfonavit = sqlExecute("SELECT * from infonavit where reloj='" & _reloj & "'", "PERSONAL")

                    '- Obtener valor de CIAS que se usaran de forma general
                    Dim dtValCias As DataTable = sqlExecute("SELECT * from cias where cod_comp='" & cod_comp & "'", "PERSONAL")
                    If (Not dtValCias.Columns.Contains("Error") And dtValCias.Rows.Count > 0) Then
                        Try : UMA = dtValCias.Rows(0).Item("uma") : Catch ex As Exception : UMA = 0.0 : End Try
                        Try : SALMIN = dtValCias.Rows(0).Item("MINIMO_DF") : Catch ex As Exception : SALMIN = 0.0 : End Try
                        Try : prima_riesg_imss = dtValCias.Rows(0).Item("prima_riesg_imss") : Catch ex As Exception : prima_riesg_imss = 0.0 : End Try
                        Try : cuota_segviv = dtValCias.Rows(0).Item("pago_seg_viv") : Catch ex As Exception : cuota_segviv = 0.0 : End Try
                        Try : UMI = dtValCias.Rows(0).Item("UMI") : Catch ex As Exception : UMA = 0.0 : End Try
                    End If

                    If (indicProc = "G") Then filtroNomina = _filtroNom
                    If (indicProc = "I") Then filtroNomina = _filtroNom & " AND RELOJ='" & _reloj & "'"

                    '-- Obtener los tipos de periodo que se están procesando, y saber si aplicará ajuste al subsidio pagado
                    '     GetTiposPer(filtroNomina)
                    '--Ends

                    '--- Obtener los factores de Aguinaldo
                    Dim QFacAgui As String = "select * from agui where COD_COMP='" & cod_comp & "'"
                    dtFactAgui = sqlExecute(QFacAgui, "PERSONAL")

                    If (indicProc = "I") Then GoTo Saltar1

                    '---Preparar dt que mostrará el resumen en diferencia de conceptos que no se agregaron
                    dtDifConceptos.Rows.Clear()
                    dtDifConceptos.Columns.Clear()
                    dtDifConceptos.Columns.Add("ano", Type.GetType("System.String"))
                    dtDifConceptos.Columns.Add("periodo", Type.GetType("System.String"))
                    dtDifConceptos.Columns.Add("reloj", Type.GetType("System.String"))
                    dtDifConceptos.Columns.Add("concepto", Type.GetType("System.String"))
                    dtDifConceptos.Columns.Add("descripcion", Type.GetType("System.String"))
                    dtDifConceptos.Columns.Add("monto", Type.GetType("System.Double"))
                    dtDifConceptos.Columns.Add("tipo_periodo", Type.GetType("System.String"))
                    '---Ends
Saltar1:

                    '--Mostrar progress
                    frmTrabajando.Avance.IsRunning = False
                    frmTrabajando.lblAvance.Text = "Procesando datos"
                    Application.DoEvents()
                    frmTrabajando.Avance.Maximum = dtNominaPro.Select(filtroNomina).Count

                    For Each drNomPro As DataRow In dtNominaPro.Select(filtroNomina) ' -- Recorrer cada uno de los empleados a calc su nomina que si van a ser procesados

                        '-Variables globales que tienen que inicializarse al calcular cada nomina
                        acum_percep = 0.0
                        acum_deduc = 0.0
                        acum_neto = 0.0
                        acum_exento = 0.0
                        isrCausado = 0.0
                        subempleoCausado = 0.0
                        isrRetenido = 0.0
                        subempleoPagado = 0.0
                        '  saldo_tot_fahc = 0.0
                        '    saldo_tot_fahe = 0.0


                        '----------------Vars por cada empleado a inicializarse por calculo
                        Dim anio_empl As String = ""
                        Dim per_empl As String = ""
                        Dim reloj As String = ""
                        Dim sactual As Double = 0.0
                        Dim integrado As Double = 0.0
                        Dim alta As String = ""
                        Dim baja As String = ""
                        Dim tipo_nomina As String = ""
                        Dim tipo_periodo As String = "" '--Se refiere a si es S(Semanal) o C (14nal)
                        Dim cod_pago As String = ""
                        Dim cod_depto As String = ""
                        Dim cod_turno As String = ""
                        Dim cod_puesto As String = ""
                        Dim cod_hora As String = ""
                        Dim cod_tipo As String = ""
                        Dim cod_clase As String = ""
                        Dim cod_area As String = ""
                        Dim sindicalizado As Integer = 0
                        Dim fah_participa As Integer = 0
                        Dim fah_porcentaje As Double = 0.0
                        Dim horas_turno As Double = 0.0
                        Dim costo_x_hora As Double = 0.0
                        Dim AntigEmpleado As Integer = 0
                        Dim acumExeAnioPVac As Double = 0.0
                        Dim acumExeAnioAgui As Double = 0.0
                        Dim topeIntImss As Double = 0.0
                        Dim esbaja As Integer = 0 ' Indica si es baja del periodo o no
                        Dim privac_porc_aniv As Double = 0.0 ' Indica si la prima_vac se pagará por aniversario
                        Dim privac_dias_aniv As Double = 0.0 ' Indica si la prima_vac se pagará por aniversario
                        Dim ACUMPERGRA As Double = 0.0 ' Acumulado de percep gravada de las semanas anteriores, solo si aplica aj al sub causado en la semana

                        Dim dtMtroDedFiniq As New DataTable
                        Dim hayDedLiqFiniq As Boolean = False
                        Dim myRowDedFin() As DataRow

                        '--Dar el valor para cada var
                        Try : anio_empl = drNomPro("ano").ToString.Trim : Catch ex As Exception : anio_empl = "" : End Try ' Esto porque puede ser Semanal o 14nal y puede cambiar el anio
                        Try : per_empl = drNomPro("periodo").ToString.Trim : Catch ex As Exception : per_empl = "" : End Try ' Esto porque puede ser Semanal o 14nal y cambia el periodo
                        Try : reloj = drNomPro("reloj").ToString.Trim : Catch ex As Exception : reloj = "" : End Try

                        '----Mostrar Progress - avance
                        i += 1
                        frmTrabajando.Avance.Value = i
                        frmTrabajando.lblAvance.Text = reloj
                        Application.DoEvents()
                        '----Ends Avance


                        Try : sactual = Double.Parse(drNomPro("sactual")) : Catch ex As Exception : sactual = 0.0 : End Try
                        Try : integrado = Double.Parse(drNomPro("integrado")) : Catch ex As Exception : integrado = 0.0 : End Try
                        Try : alta = FechaSQL(drNomPro("alta").ToString.Trim) : Catch ex As Exception : alta = "" : End Try
                        Try : baja = FechaSQL(drNomPro("baja").ToString.Trim) : Catch ex As Exception : baja = "" : End Try
                        Try : tipo_nomina = drNomPro("tipo_nomina").ToString.Trim : Catch ex As Exception : tipo_nomina = "" : End Try
                        Try : tipo_periodo = drNomPro("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_periodo = "" : End Try
                        Try : cod_pago = drNomPro("cod_pago").ToString.Trim : Catch ex As Exception : cod_pago = "" : End Try
                        Try : cod_depto = drNomPro("cod_depto").ToString.Trim : Catch ex As Exception : cod_depto = "" : End Try
                        Try : cod_turno = drNomPro("cod_turno").ToString.Trim : Catch ex As Exception : cod_turno = "" : End Try
                        Try : cod_puesto = drNomPro("cod_puesto").ToString.Trim : Catch ex As Exception : cod_puesto = "" : End Try
                        Try : cod_hora = drNomPro("cod_hora").ToString.Trim : Catch ex As Exception : cod_hora = "" : End Try
                        Try : cod_tipo = drNomPro("cod_tipo").ToString.Trim : Catch ex As Exception : cod_tipo = "" : End Try
                        Try : cod_clase = drNomPro("cod_clase").ToString.Trim : Catch ex As Exception : cod_clase = "" : End Try
                        Try : cod_area = drNomPro("cod_area").ToString.Trim : Catch ex As Exception : cod_area = "" : End Try
                        Try : sindicalizado = Integer.Parse(drNomPro("sindicalizado")) : Catch ex As Exception : sindicalizado = 0 : End Try
                        Try : fah_participa = Integer.Parse(drNomPro("fah_participa")) : Catch ex As Exception : fah_participa = 0 : End Try
                        Try : fah_porcentaje = Double.Parse(drNomPro("fah_porcentaje")) : Catch ex As Exception : fah_porcentaje = 0.0 : End Try
                        Try : privac_porc_aniv = Double.Parse(drNomPro("privac_porc")) : Catch ex As Exception : privac_porc_aniv = 0.0 : End Try
                        Try : privac_dias_aniv = Double.Parse(drNomPro("privac_dias")) : Catch ex As Exception : privac_dias_aniv = 0.0 : End Try

                        '-- obtener las horas del turno
                        Dim drowHrsTurno As DataRow = Nothing
                        Try : drowHrsTurno = dtTurnos.Select("cod_turno='" & cod_turno & "'")(0) : Catch ex As Exception : drowHrsTurno = Nothing : End Try
                        If (Not IsNothing(drowHrsTurno)) Then horas_turno = Double.Parse(drowHrsTurno("horas"))

                        costo_x_hora = Math.Round((sactual / 8), 2) ' Costo por hora

                        '--Obtener la antig en años exacta del empleado de su fecha de alta al día actual en que se está calculando el agui
                        Try : AntigEmpleado = Antiguedad_Empleado(alta, Date.Now) : Catch ex As Exception : AntigEmpleado = 0 : End Try

                        '--Obtener el tope del integrado para IMSS
                        topeIntImss = 25 * UMA
                        If (integrado < topeIntImss) Then topeIntImss = integrado
                        '----------------Ends Vars

                        '-------------Obtener exentos que ya haya tenido durante al año Nota: Solo entran los periodos que si acumulan (TA.dbo.Periodos_acumula = 1)
                        Dim _TaTipoPer As String = ""


                        _TaTipoPer = "TA.dbo.periodos" ' Se deja que busque en todos los periodos de la semanal, ya sea si es tipo sem o catorcenal
                        Dim qBuscaExPVac As String = "select ISNULL(SUM(convert(float,monto)),0) AS 'acumExeAnioPVac' from movimientos where RELOJ='" & reloj & "' and ANO='" & anio & "' and concepto='PEXVAC' and periodo in " & _
                        "(select PERIODO from " & _TaTipoPer & " where acumula=1)"
                        Dim qBuscaExAgui As String = "select ISNULL(SUM(convert(float,monto)),0) AS 'acumExeAnioAgui' from movimientos where RELOJ='" & reloj & "' and ANO='" & anio & "' and concepto='PEXAGI' and periodo in " & _
                        "(select PERIODO from " & _TaTipoPer & " where acumula=1)"

                        '-Exento de PrimaVac
                        Dim dtExeAnioPVac As DataTable = sqlExecute(qBuscaExPVac, "NOMINA")
                        If (Not dtExeAnioPVac.Columns.Contains("Error") And dtExeAnioPVac.Rows.Count > 0) Then Try : acumExeAnioPVac = Double.Parse(dtExeAnioPVac.Rows(0).Item("acumExeAnioPVac")) : Catch ex As Exception : acumExeAnioPVac = 0.0 : End Try

                        '-Exento de Aguinaldo
                        Dim dtExeAnioAgui As DataTable = sqlExecute(qBuscaExAgui, "NOMINA")
                        If (Not dtExeAnioAgui.Columns.Contains("Error") And dtExeAnioAgui.Rows.Count > 0) Then Try : acumExeAnioAgui = Double.Parse(dtExeAnioPVac.Rows(0).Item("acumExeAnioAgui")) : Catch ex As Exception : acumExeAnioAgui = 0.0 : End Try
                        '-------------End Exentos del año


                        '-------------Datos para el INFONAVIT
                        Dim cobro_segv As Boolean = False
                        Dim inicio_cred_info As String = ""
                        Dim no_cred_info As String = ""
                        Dim tipo_cred_info As String = ""
                        Dim cuota_cred_info As Double = 0.0
                        Dim susp_cred_info As String = ""

                        Try : cobro_segv = Boolean.Parse(drNomPro("cobro_segviv")) : Catch ex As Exception : cobro_segv = False : End Try
                        Try : inicio_cred_info = FechaSQL(drNomPro("inicio_credito")) : Catch ex As Exception : inicio_cred_info = "" : End Try
                        Try : no_cred_info = drNomPro("infonavit_credito").ToString.Trim : Catch ex As Exception : no_cred_info = "" : End Try
                        Try : tipo_cred_info = drNomPro("tipo_credito").ToString.Trim : Catch ex As Exception : tipo_cred_info = "" : End Try
                        Try : cuota_cred_info = Double.Parse(drNomPro("cuota_credito")) : Catch ex As Exception : cuota_cred_info = 0.0 : End Try
                        '------------Ends Datos para el INFONAVIT


                        '----------Obtener el acumulado de la percep gravada en caso de que aplique ajuste al subsidio
                        '****NOTA: No aplica para Nom de AGUINALDO

                        '                    If (tipo_periodo = "S" And Aj_Sub_Sem) Then
                        '                        Dim QAjS As String = "select ISNULL(SUM(convert(float,monto)),0) AS 'ACUMPERGRA' from movimientos where RELOJ='" & reloj & "' and ANO='" & anio_empl & "' and concepto='PERGRA' and periodo in " & _
                        '                            "(SELECT PERIODO from TA.dbo.periodos where ANO='" & anio_empl & "' and NUM_MES='" & NumMesSem & "' and acumula=1)"
                        '                        Dim dtQAjs As DataTable = sqlExecute(QAjS, "NOMINA")
                        '                        If (Not dtQAjs.Columns.Contains("Error") And dtQAjs.Rows.Count > 0) Then Try : ACUMPERGRA = Double.Parse(dtQAjs.Rows(0).Item("ACUMPERGRA")) : Catch ex As Exception : ACUMPERGRA = 0 : End Try
                        '                    End If

                        '                    If (tipo_periodo = "C" And Aj_Sub_Cat) Then
                        '                        Dim QAjCat As String = "select ISNULL(SUM(convert(float,monto)),0) AS 'ACUMPERGRA' from movimientos where RELOJ='" & reloj & "' and ANO='" & anio_empl & "' and concepto='PERGRA' and periodo in " & _
                        '"(SELECT PERIODO from TA.dbo.periodos_catorcenal where ANO='" & anio_empl & "' and NUM_MES='" & NumMesCat & "' and acumula=1)"
                        '                        Dim dtQjCat As DataTable = sqlExecute(QAjCat, "NOMINA")
                        '                        If (Not dtQjCat.Columns.Contains("Error") And dtQjCat.Rows.Count > 0) Then Try : ACUMPERGRA = Double.Parse(dtQjCat.Rows(0).Item("ACUMPERGRA")) : Catch ex As Exception : ACUMPERGRA = 0 : End Try
                        '                    End If
                        '----------Ends obtener el acum de PERGRA



                        '*****************************************************************Ir dando el valor a cada uno de los conceptos
                        '----NOTA: Sólo los que aplican para Aguinaldo
                        DIASPA = 0.0
                        DIASAG = 0.0
                        PERAGI = 0.0
                        PEXAGI = 0.0
                        OTPGRA = 0.0
                        ISPT = 0.0
                        SUBCAU = 0.0
                        PENALI = 0.0
                        PENAL2 = 0.0
                        PENAL3 = 0.0
                        OTRASD = 0.0

                        For Each dr As DataRow In dtHorasPro.Select("reloj='" & reloj & "'")
                            Dim concepto As String = "", monto As Double = 0.0
                            Try : concepto = dr("concepto").ToString.Trim : Catch ex As Exception : concepto = "" : End Try
                            Try : monto = Double.Parse(dr("monto")) : Catch ex As Exception : concepto = "" : End Try
                            If (concepto = "DIASPA") Then DIASPA += monto : GoTo Sig1
                            If (concepto = "DIASAG") Then DIASAG += monto : GoTo Sig1
Sig1:
                        Next

                        For Each dr2 As DataRow In dtAjustesPro.Select("reloj='" & reloj & "'")
                            Dim concepto As String = "", monto As Double = 0.0
                            Try : concepto = dr2("concepto").ToString.Trim : Catch ex As Exception : concepto = "" : End Try
                            Try : monto = Double.Parse(dr2("monto")) : Catch ex As Exception : concepto = "" : End Try

                            If (concepto = "DIASPA") Then DIASPA += monto : GoTo Sig2
                            If (concepto = "DIASAG") Then DIASAG += monto : GoTo Sig2
                            If (concepto = "PERAGI") Then PERAGI += monto : GoTo Sig2
                            If (concepto = "PEXAGI") Then PEXAGI += monto : GoTo Sig2
                            If (concepto = "OTPGRA") Then OTPGRA += monto : GoTo Sig2
                            If (concepto = "ISPT") Then ISPT += monto : GoTo Sig2
                            If (concepto = "SUBCAU") Then SUBCAU += monto : GoTo Sig2
                            If (concepto = "PENALI") Then PENALI += monto : GoTo Sig2
                            If (concepto = "PENAL2") Then PENAL2 += monto : GoTo Sig2
                            If (concepto = "PENAL3") Then PENAL3 += monto : GoTo Sig2
                            If (concepto = "OTRASD") Then OTRASD += monto : GoTo Sig2

Sig2:
                        Next

                        '--Vars para Pensiones Alimenticias
                        Dim pensAlim1 As String = ""
                        Dim porcPens1 As Double = 0.0
                        Dim pensAlim2 As String = ""
                        Dim porcPens2 As Double = 0.0
                        Dim pensAlim3 As String = ""
                        Dim porcPens3 As Double = 0.0

                        For Each drPens As DataRow In dtPensAlim.Select("reloj='" & reloj & "'")
                            Dim _noPens As String = "", _PorcPens As Double = 0.0

                            Try : _noPens = drPens("pension").ToString.Trim : Catch ex As Exception : _noPens = "" : End Try
                            Try : _PorcPens = Double.Parse(drPens("porc")) : Catch ex As Exception : _PorcPens = 0.0 : End Try

                            Select Case _noPens
                                Case "1"
                                    pensAlim1 = "1"
                                    porcPens1 = _PorcPens
                                Case "2"
                                    pensAlim2 = "2"
                                    porcPens2 = _PorcPens
                                Case "3"
                                    pensAlim3 = "3"
                                    porcPens3 = _PorcPens
                            End Select
                        Next

                        '****************************************************************CALCULAR CADA UNA DE LAS VARIABLES

                        '************************************************************PERCEPCIONES

                        '******************************************* DIASAG  DIAS DE AGUINALDO
                        '--A = dias que le tocan por su antig en anios y tipo de empleado 
                        '--B = 365 días del anio
                        '--C = Son los dias trabajados del trabajador en el anio desde su fecha de alta al 31/12 del anio actual
                        '--X = Dias de ausentismo que hay que restar

                        '--MODIFICACION: Se puso 2020 para pruebas    ERNESTO   FEB/21
                        Dim _FAgui As New Date(Date.Now.Year, 1, 1) ' Fecha para aguinaldo, x Default va a ser el el 01 de Enero del anio actual
                        '  Dim _FAgui As New Date(2020, 1, 1) ' Fecha para aguinaldo, x Default va a ser el el 01 de Enero del anio actual
                        '--

                        Dim _FAlta As Date

                        '--MODIFICACION: Se puso 2020 para pruebas    ERNESTO   FEB/21
                        Dim _FCalcAgui As New Date(Date.Now.Year, 12, 31) ' Da la fecha al 31/12/ del anio actual
                        '  Dim _FCalcAgui As New Date(2020, 12, 31) ' Da la fecha al 31/12/ del anio actual
                        '--

                        _FAlta = Date.Parse(alta)
                        Dim diasAntigEmplTrab As Double = 0.0, diasAguiXAntigXFactor As Double = 0.0, diasAus As Double = 0.0
                        '--NOTA: Falta traernos los diasAus para descontar  a los dias trab del trabajador, y meterlos en un concepto para mostraro también en reporte, pero esto será hasta el prox anio 2021

                        '-----MODIFICACION NUEVA: DE AQUI       ERNESTO FEB/2021
                        '--Ernesto.     Cálculo de días ausentes     13/feb/21
                        Dim dtAusentesDias As DataTable
                        Dim queryAusentes As String

                        queryAusentes = "select tipo_aus,count(tipo_aus) as dias from ausentismo where reloj='" & reloj & "' "

                        '--Comentada para pruebas      ERNESTO  FEB/21
                        queryAusentes = queryAusentes & "and year(fecha) = YEAR(getdate())"
                        ' queryAusentes = queryAusentes & "and year(fecha) = 2020"

                        If txtCriterio.Text <> "" Then
                            queryAusentes = queryAusentes & " and " & txtCriterio.Text
                        End If

                        queryAusentes = queryAusentes & " group by TIPO_AUS"
                        dtAusentesDias = sqlExecute(queryAusentes, "TA")

                        '--Total dias ausentismo    Ernesto feb/21
                        If txtCriterio.Text <> "" Then
                            For Each x As DataRow In dtAusentesDias.Rows
                                diasAus = diasAus + x.Item("dias")
                            Next
                        End If
                        '-----MODIFICACION NUEVA: HASTA ACA       ERNESTO FEB/2021

                        '--Calcular días de antig para Aguinaldo
                        If (_FAlta >= _FAgui) Then _FAgui = _FAlta ' Solo si el alta es mayor al 01/01/anio actual, sacar proporcional de dias del alta a la fecha
                        diasAntigEmplTrab = Antiguedad_Dias(_FAgui, _FCalcAgui) + 1


                        '-----MODIFICACION NUEVA: DE AQUI      ERNESTO FEB/21
                        '-antiguedadDias    -> Dias correspondientes al anio desde su fecha de alta
                        '-diasAntigEmplTrab -> Dias trabajados al anio
                        '-diasAus           -> Dias ausentes al anio

                        Dim antiguedadDias As Double = 0.0
                        antiguedadDias = diasAntigEmplTrab

                        diasAntigEmplTrab = diasAntigEmplTrab - diasAus ' Descontamos los ausentimos del año a los días trabajados
                        If (diasAntigEmplTrab >= 365) Then diasAntigEmplTrab = 365 ' Topar a 365

                        '---Si los conceptos son menores a cero   feb/21      Ernesto
                        If diasAntigEmplTrab < 0 Then diasAntigEmplTrab = 0
                        If antiguedadDias < 0 Then antiguedadDias = 0
                        '-----MODIFICACION NUEVA: HASTA ACA    ERNESTO FEB/21


                        '---Obtener los dias que le tocan por su factor de antiguedad y tipo de empleado
                        Dim drFacAgui As DataRow = Nothing
                        Try : drFacAgui = dtFactAgui.Select("anos=" & AntigEmpleado + 1 & " and cod_tipo='" & cod_tipo & "' and cod_comp='" & cod_comp & "'")(0) : Catch ex As Exception : drFacAgui = Nothing : End Try
                        If (Not IsNothing(drFacAgui)) Then
                            Try : diasAguiXAntigXFactor = Double.Parse(drFacAgui("DIAS")) : Catch ex As Exception : diasAguiXAntigXFactor = 0.0 : End Try
                        End If


                        DIASAG = DIASAG + Math.Round((diasAguiXAntigXFactor / 365) * diasAntigEmplTrab, 2)
                        If (DIASAG <> 0) Then puente_esp(anio_empl, per_empl, reloj, DIASAG, tipo_nomina, tipo_periodo, "DIASAG", dtConceptos)

                        '---------MODIFICACION NUEVA: DE AQUI       ERNESTO     FEB2021
                        '---------Aqui se agregan las variables de aguinaldo(DIACAG,AUSAGI,DIATAG) para insertarlo en la tabla movimientos_pro_esp     Ernesto     feb/21
                        '--DIACAG
                        If (antiguedadDias <> 0) Then puente_esp(anio_empl, per_empl, reloj, antiguedadDias, tipo_nomina, tipo_periodo, "DIACAG", dtConceptos)

                        '--AUSAGI
                        If (diasAus <> 0) Then puente_esp(anio_empl, per_empl, reloj, diasAus, tipo_nomina, tipo_periodo, "AUSAGI", dtConceptos)

                        '--DIATAG
                        If (diasAntigEmplTrab <> 0) Then puente_esp(anio_empl, per_empl, reloj, diasAntigEmplTrab, tipo_nomina, tipo_periodo, "DIATAG", dtConceptos)
                        '------------------------------------------------------------------------------------------------------------------------------------------------
                        '---------MODIFICACION NUEVA: HASTA ACA     ERNESTO         FEB2021

                        '******************************************* DIASPA - DIAS PAGADOS
                        DIASPA = DIASPA + DIASAG
                        If (DIASPA <> 0) Then puente_esp(anio_empl, per_empl, reloj, DIASPA, tipo_nomina, tipo_periodo, "DIASPA", dtConceptos)

                        '---TOTAUS (Total de ausentismos aplicados para el trabajador (diasAus)) PENDIENTE para el prox anio 2021

                        '*******************************************PERAGI - PERCEP DE AGUINALDO
                        PERAGI = PERAGI + (DIASAG * sactual)
                        If (PERAGI <> 0) Then puente_esp(anio_empl, per_empl, reloj, PERAGI, tipo_nomina, tipo_periodo, "PERAGI", dtConceptos)

                        '*******************************************PEXAGI CALCULO EXENTO DE AGINALDO
                        Dim TopeExeAgui As Double = 30 * UMA
                        TopeExeAgui = TopeExeAgui - acumExeAnioAgui  ' Se le resta el exento que haya tenido en el anio
                        If (TopeExeAgui <= 0) Then TopeExeAgui = 0
                        If (PERAGI >= TopeExeAgui) Then PEXAGI += TopeExeAgui
                        If (PERAGI < TopeExeAgui) Then PEXAGI += PERAGI
                        acum_exento = acum_exento + PEXAGI

                        If (PEXAGI <> 0) Then puente_esp(anio_empl, per_empl, reloj, PEXAGI, tipo_nomina, tipo_periodo, "PEXAGI", dtConceptos)

                        '*******************************************OTPGRA - Otras percepcones gravadas
                        If (OTPGRA <> 0) Then puente_esp(anio_empl, per_empl, reloj, OTPGRA, tipo_nomina, tipo_periodo, "OTPGRA", dtConceptos)


                        '********************************************TOTPER - CALCULO DEL TOTAL DE PERCEPCIONES
                        TOTPER = 0.0
                        TOTPER = acum_percep
                        puente_esp(anio_empl, per_empl, reloj, TOTPER, tipo_nomina, tipo_periodo, "TOTPER", dtConceptos)

                        '*********************************************PEREXE - CALCULO DEL TOTAL DE EXENTO
                        PEREXE = 0.0
                        PEREXE = acum_exento
                        '-- insertar en movimientos_pro
                        If (PEREXE <> 0) Then puente_esp(anio_empl, per_empl, reloj, PEREXE, tipo_nomina, tipo_periodo, "PEREXE", dtConceptos)

                        '***********************************************PERGRA - CALCULO DEL TOTAL GRAVABLE
                        PERGRA = 0.0
                        PERGRA = TOTPER - PEREXE
                        '-- insertar en movimientos_pro
                        If (PERGRA <> 0) Then puente_esp(anio_empl, per_empl, reloj, PERGRA, tipo_nomina, tipo_periodo, "PERGRA", dtConceptos)


                        '************************************************************DEDUCCIONES

                        '******************************************ISPTRE - Cálculo del ISTP (ISR RETENIDO)

                        ISPTRE = CalcISR142(reloj, PERGRA, "M", "Imp", DIASPA, dtAjustesPro, 0, ACUMPERGRA, sactual, tipoNomEsp)
                        If (ISPTRE <> 0) Then puente_esp(anio_empl, per_empl, reloj, ISPTRE, tipo_nomina, tipo_periodo, "ISPTRE", dtConceptos)

                        '**********************SUBPAG  - Subsido al empleo Pagado
                        SUBPAG = 0.0
                        SUBPAG = subempleoPagado
                        If (SUBPAG <> 0) Then puente_esp(anio_empl, per_empl, reloj, SUBPAG, tipo_nomina, tipo_periodo, "SUBPAG", dtConceptos)

                        '**********************ISPT   - ISR CAUSADO

                        ISPT += isrCausado
                        If (ISPT <> 0) Then puente_esp(anio_empl, per_empl, reloj, ISPT, tipo_nomina, tipo_periodo, "ISPT", dtConceptos)

                        '**********************SUBCAU - SUBSIDIO CAUSADO

                        SUBCAU += subempleoCausado
                        If (SUBCAU <> 0) Then puente_esp(anio_empl, per_empl, reloj, SUBCAU, tipo_nomina, tipo_periodo, "SUBCAU", dtConceptos)


                        '***********************************************PENALI - Pensión alimenticia 1
                        Dim basePens1 As Double = 0.0
                        basePens1 = (TOTPER - isrRetenido) * (porcPens1 / 100)  ' NOTA: Falta incluir el ISRSEP (isr separacion)
                        PENALI = PENALI + basePens1
                        '-- insertar en movimientos_pro
                        If (PENALI <> 0) Then puente_esp(anio_empl, per_empl, reloj, PENALI, tipo_nomina, tipo_periodo, "PENALI", dtConceptos)

                        '**********************PENAL2 - Pensión alimenticia 2
                        Dim basePens2 As Double = 0.0
                        basePens2 = (TOTPER - isrRetenido) * (porcPens2 / 100)  ' NOTA: Falta incluir el ISRSEP (isr separacion)
                        PENAL2 = PENAL2 + basePens2
                        '-- insertar en movimientos_pro
                        If (PENAL2 <> 0) Then puente_esp(anio_empl, per_empl, reloj, PENAL2, tipo_nomina, tipo_periodo, "PENAL2", dtConceptos)

                        '**********************PENAL3 - Pensión alimenticia 3
                        Dim basePens3 As Double = 0.0
                        basePens3 = (TOTPER - isrRetenido) * (porcPens3 / 100)  ' NOTA: Falta incluir el ISRSEP (isr separacion)
                        PENAL3 = PENAL3 + basePens3
                        '-- insertar en movimientos_pro
                        If (PENAL3 <> 0) Then puente_esp(anio_empl, per_empl, reloj, PENAL3, tipo_nomina, tipo_periodo, "PENAL3", dtConceptos)

                        '**********************OTRASD  - Otras deducciones
                        '-- insertar en movimientos_pro
                        If (OTRASD <> 0) Then puente_esp(anio_empl, per_empl, reloj, OTRASD, tipo_nomina, tipo_periodo, "OTRASD", dtConceptos)

                        '**********************TOTDED - CALCULO DEL TOTAL DE DEDUCCIONES
                        TOTDED = 0.0
                        TOTDED = acum_deduc
                        '---AOS 2022-03-15 : Validación de que si el neto es cero, totded debe de ser cero
                        If acum_neto <= 0 Then TOTDED = 0
                        puente_esp(anio_empl, per_empl, reloj, TOTDED, tipo_nomina, tipo_periodo, "TOTDED", dtConceptos)

                        '**********************NETO - CALCULO DEL NETO
                        NETO = acum_neto
                        puente_esp(anio_empl, per_empl, reloj, NETO, tipo_nomina, tipo_periodo, "NETO", dtConceptos)


                    Next ' --Final de que evalua a un empleado

                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()

                    If (indicProc = "I") Then
                        GoTo Saltar2
                    End If

                    '------Hacer una copia del cálculo original
                    sqlExecute("DROP TABLE nomina_pro_original_esp", "NOMINA")
                    sqlExecute("DROP TABLE horas_pro_original_esp", "NOMINA")
                    sqlExecute("DROP TABLE ajustes_pro_original_esp", "NOMINA")
                    sqlExecute("DROP TABLE movimientos_pro_original_esp", "NOMINA")
                    sqlExecute("DROP TABLE movimientos_imss_pro_original_esp", "NOMINA")
                    sqlExecute("select * into nomina_pro_original_esp from nomina_pro_esp", "NOMINA")
                    sqlExecute("select * into horas_pro_original_esp from horas_pro_esp", "NOMINA")
                    sqlExecute("select * into ajustes_pro_original_esp from ajustes_pro_esp", "NOMINA")
                    sqlExecute("select * into movimientos_pro_original_esp from movimientos_pro_esp", "NOMINA")
                    sqlExecute("select * into movimientos_imss_pro_original_esp from movimientos_imss_pro_esp", "NOMINA")

                    '---Mensaje con el resúmen
                    If i < 0 Then
                        'No hubo archivos para analizar
                        MessageBox.Show("No se calculó ningun registro", "Cálculo de aguinaldo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        Me.Close()
                    Else
                        MessageBox.Show("Proceso concluído satisfactoriamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()

                        ''*******************Detectar diferencias, es decir, si hubo conceptos de horas_pro y ajustes_pro que no pasaron a movimientos_pro
                        Dim TotDifConc As Integer = FindDifConcep_esp(dtHorasPro, dtAjustesPro)
                        If TotDifConc > 0 Then

                            '---Nota : dtDifConceptos es el qeu traerá la info para generar el reporte
                            If (Not dtDifConceptos.Columns.Contains("Error") And dtDifConceptos.Rows.Count > 0) Then
                                MessageBox.Show("Se detectaron " & TotDifConc & " conceptos con diferencia que no se incluyeron en la nómina, se generará reporte con el detalle", "Diferencias en conceptos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                Dim _dtDatos As New DataTable
                                frmVistaPrevia.LlamarReporte("Diferencia en conceptos", dtDifConceptos)
                                frmVistaPrevia.ShowDialog()
                            End If

                        End If

                        If MessageBox.Show("¿Desea generar el detalle de la nómina de aguinaldo?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            GenRepNominaDetalle_esp(anio, periodo, "5", "S", "Agui") ' Semanales
                            GenRepNominaDetalle_esp(anio, periodo, "5", "C", "Agui") ' Catorcenales
                        End If

                    End If

Saltar2:

                End If

            Else
                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()
                MessageBox.Show("No hay un periodo inicializado a procesar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Function
            End If

        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function FindDifConcep_esp(ByVal _dtHrsPro As DataTable, _dtAjustesPro As DataTable) As Integer
        Dim TotDif As Integer = 0
        Dim ano As String = "", periodo As String = "", rj As String = "", concepto As String = "", descripcion As String = "", monto As Double = 0.0, tipo_periodo As String = ""

        Try
            dtMovimientos_pro = sqlExecute("select * from movimientos_pro_esp", "NOMINA")

            For Each drHrs As DataRow In _dtHrsPro.Rows
                Try : ano = drHrs("ano").ToString.Trim : Catch ex As Exception : ano = "" : End Try
                Try : periodo = drHrs("periodo").ToString.Trim : Catch ex As Exception : periodo = "" : End Try
                Try : rj = drHrs("reloj").ToString.Trim : Catch ex As Exception : rj = "" : End Try
                Try : concepto = drHrs("concepto").ToString.Trim : Catch ex As Exception : concepto = "" : End Try
                Try : descripcion = drHrs("descripcion").ToString.Trim : Catch ex As Exception : descripcion = "" : End Try
                Try : monto = Double.Parse(drHrs("monto")) : Catch ex As Exception : monto = 0.0 : End Try

                If (monto > 0 And concepto <> "ESBAJA" And rj <> "" And concepto <> "") Then

                    If (dtMovimientos_pro.Select("reloj='" & rj & "' and concepto='" & concepto & "'").Count = 0) Then  ' Si no lo encontró, agregarlo en el detalle

                        Dim myRow() As DataRow
                        myRow = dtMovimientos_pro.Select("reloj='" & rj & "'")
                        Try : tipo_periodo = myRow(0)("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_periodo = "" : End Try

                        Dim dr As DataRow = dtDifConceptos.NewRow
                        dr("ano") = ano
                        dr("periodo") = periodo
                        dr("reloj") = rj
                        dr("concepto") = concepto
                        dr("descripcion") = descripcion
                        dr("monto") = monto
                        dr("tipo_periodo") = tipo_periodo
                        dtDifConceptos.Rows.Add(dr)
                        TotDif += 1
                    End If

                End If

            Next

            For Each drAj As DataRow In _dtAjustesPro.Rows
                Try : ano = drAj("ano").ToString.Trim : Catch ex As Exception : ano = "" : End Try
                Try : periodo = drAj("periodo").ToString.Trim : Catch ex As Exception : periodo = "" : End Try
                Try : rj = drAj("reloj").ToString.Trim : Catch ex As Exception : rj = "" : End Try
                Try : concepto = drAj("concepto").ToString.Trim : Catch ex As Exception : concepto = "" : End Try
                Try : descripcion = drAj("descrip").ToString.Trim : Catch ex As Exception : descripcion = "" : End Try
                Try : monto = Double.Parse(drAj("monto")) : Catch ex As Exception : monto = 0.0 : End Try

                If (monto > 0 And concepto <> "ESBAJA" And rj <> "" And concepto <> "") Then

                    If (dtMovimientos_pro.Select("reloj='" & rj & "' and concepto='" & concepto & "'").Count = 0) Then  ' Si no lo encontró, agregarlo en el detalle

                        Dim myRow() As DataRow
                        myRow = dtMovimientos_pro.Select("reloj='" & rj & "'")
                        Try : tipo_periodo = myRow(0)("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_periodo = "" : End Try

                        Dim dr As DataRow = dtDifConceptos.NewRow
                        dr("ano") = ano
                        dr("periodo") = periodo
                        dr("reloj") = rj
                        dr("concepto") = concepto
                        dr("descripcion") = descripcion
                        dr("monto") = monto
                        dr("tipo_periodo") = tipo_periodo
                        dtDifConceptos.Rows.Add(dr)
                        TotDif += 1
                    End If

                End If
            Next


            Return TotDif
        Catch ex As Exception
            Return TotDif
        End Try
    End Function

    Public Sub GenRepNominaDetalle_esp(ByRef anio As String, periodo As String, nivel_consulta As String, _tipoPer As String, Optional ByVal nombreNom As String = "")
        Try
            '---NOTA: En este caso como todos van en un solo periodo, se harán semanales y en el periodo especial y saldrán todos juntos:
            'sqlExecute("update nomina_pro_esp set tipo_periodo='S'", "NOMINA")
            'sqlExecute("update movimientos_pro_esp set tipo_periodo='S'", "NOMINA")

            Dim dtDatos As New DataTable
            Dim NombreReporte As String = "Nómina detalle"

            Dim query As String = "EXEC ReporteadorNominaTipoPeriodo_pro_ESP @Cia = '', @ano = '" & anio & "', @periodo = '" & periodo & _
                               "',@Nivel = '" & nivel_consulta & "', @reloj = '', @TipoPeriodo = '" & _tipoPer & "'"


            dtResultadoNomina = sqlExecute(query, "NOMINA")

            If (Not dtResultadoNomina.Columns.Contains("Error") And dtResultadoNomina.Rows.Count > 0) Then

                dtResultadoNomina.Columns.Add("periodos")
                '   PreparaDatos(NombreReporte, dtResultadoNomina)
                NominaProExcel_esp(dtDatos, dtResultadoNomina, False, True, "Nómina detalle", False, "", anio, periodo, _tipoPer, nombreNom)

            Else
                MessageBox.Show("No hay información para generar la nómina detalle", "Generación de nómina detalle", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub

    '--- MODIFICACION NUEVA: DE AQUI        ERNESTO     FEBRERO2021
    Private Sub btnAgregarCriterio_Click(sender As Object, e As EventArgs) Handles btnAgregarCriterio.Click

        Try
            Dim FiltraValor As String = "TIPO_AUS in ("
            Dim ValoresChecados As Boolean

            '--Agregar criterios
            For Each itm As DevComponents.DotNetBar.ListBoxItem In lstFiltro.CheckedItems
                FiltraValor = FiltraValor & "'" & IIf(itm.Text.Substring(0, 2) = "FI", itm.Text.Substring(0, 2), itm.Text.Substring(0, 3)) & "',"
                ValoresChecados = True
            Next

            If ValoresChecados Then
                FiltraValor = FiltraValor.Substring(0, FiltraValor.Length - 1) & ")"
                txtCriterio.Text = FiltraValor
            Else
                txtCriterio.Text = ""
            End If

            '--Mostrar paneles
            OcultaPaneles(False, True)

        Catch ex As Exception : End Try

    End Sub

    '--feb/21
    Private Sub btnCriterio_Click(sender As Object, e As EventArgs) Handles btnCriterio.Click
        OcultaPaneles(True, False)
    End Sub

    '---MODIFICACION NUEVA: HASTA ACA   FEBRERO2021
End Class