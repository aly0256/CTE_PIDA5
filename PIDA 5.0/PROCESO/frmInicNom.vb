Public Class frmInicNom

    Dim dtPeriodos As New DataTable
    Dim dtInfonavit As New DataTable
    Dim dtMtroDed As New DataTable
    Dim dtFactVac As New DataTable
    Dim perActivo As String = ""
    Dim periodo_act As String = ""
    Dim num_mes As String = ""
    Dim filtroPer As String = ""
    Dim nom_cat As String = ""
    Dim dt_periodoCatorcenal As New DataTable
    Dim anioCat As String = ""
    Dim perCat As String = ""
    Dim perSem As String = ""
    Dim FIniCat As Date ' Fecha de incidencia catorcenal
    Dim FFinCat As Date
    Dim privac_dias As Double = 0.0
    Dim privac_porc As Double = 0.0
    Dim dtActFAH As New DataTable
    '--Fechas de pago de nomina tanto sem como Catorcenal
    Dim fini_nom As Date
    Dim ffin_nom As Date
    Dim fini_nom_cat As Date
    Dim ffin_nom_cat As Date

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs)
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmInicNom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtAno As New DataTable
        Dim anio_actual As String = ""
        Try
            anio_actual = Now.Year.ToString.Trim
            dtAno = sqlExecute("select distinct ano from (SELECT ano from periodos union all select ano from periodos_catorcenal union all select ano from periodos_mensual) as ano ", "TA")

            cmbAno.DataSource = dtAno
            cmbAno.SelectedValue = anio_actual


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cmbAno_SelectionChanged(sender As Object, e As DevComponents.AdvTree.AdvTreeNodeEventArgs) Handles cmbAno.SelectionChanged
        Try

            dtPeriodos = sqlExecute("SELECT TOP 1 periodo, fecha_ini, fecha_fin FROM periodos WHERE ano = '" & cmbAno.SelectedValue & "' and isnull(PERIODO_ESPECIAL,0)=0 and isnull(asentado,0)=0 order by periodo asc", "TA")
            If dtPeriodos.Rows.Count > 0 Then
                perActivo = dtPeriodos.Rows(0).Item("periodo")
            End If

            dtPeriodos = sqlExecute("SELECT periodo,fecha_ini,fecha_fin FROM periodos WHERE ano = '" & cmbAno.SelectedValue & "' ORDER BY periodo", "TA")
            cmbPeriodo.DataSource = dtPeriodos
            If perActivo.Length > 0 Then
                cmbPeriodo.SelectedValue = perActivo
            Else
                cmbPeriodo.SelectedIndex = 0
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub btnIniciProcNom_Click(sender As Object, e As EventArgs) Handles btnIniciProcNom.Click
        cmbAno.Enabled = False
        cmbPeriodo.Enabled = False
        btnIniciProcNom.Enabled = False


        Try
            Dim _ano As String = cmbAno.SelectedValue
            Dim _periodo As String = cmbPeriodo.SelectedValue
            perSem = _periodo

            '----Datos de factores de vacaciones y prima vac
            dtFactVac = sqlExecute("select * from vacaciones", "PERSONAL")

            '---Datos de infonavit
            dtInfonavit = sqlExecute("select * from infonavit where activo = 1", "PERSONAL")

            '---Datos del Maestro de deducciones
            Dim QD As String = "select reloj,mtro_ded.CONCEPTO,RTRIM(CONCEPTOS.NOMBRE) AS DESCRIP,NUMCREDITO,ano,PERIODO,status,SALDO_ACT,ABONO_ACT,SEM_RESTAN,anoper_aplicado from MTRO_DED LEFT JOIN CONCEPTOS ON mtro_ded.CONCEPTO = CONCEPTOS.CONCEPTO where isnull(STATUS,0)=1 and isnull(saldo_act,0)>0 and isnull(ABONO_ACT,0)>0 and isnull(anoper_aplicado,'')<'" & _ano & _periodo & "' and ano+PERIODO<='" & _ano & _periodo & "'"
            dtMtroDed = sqlExecute(QD, "NOMINA")

            Dim QP As String = "select * from periodos where ano = '" & _ano & "' and periodo = '" & _periodo & "' and isnull(asentado,0)=0"
            Dim dt_periodos As DataTable = sqlExecute(QP, "TA")





            If (dt_periodos.Columns.Contains("Error") Or dt_periodos.Rows.Count <= 0) Then
                MessageBox.Show("El periodo no puede ser inicializado ya que se encuentra asentado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmbAno.Enabled = True
                cmbPeriodo.Enabled = True
                btnIniciProcNom.Enabled = True
                Exit Sub
            End If

            '    filtroPer = "'S'" ' Filtro qeu determina que empleados va a meter al cálculo si solo semanales o ambos

            If dt_periodos.Rows.Count > 0 Then

                Dim _fecha_ini As Date = dt_periodos.Rows(0)("fecha_ini")
                Dim _fecha_fin As Date = dt_periodos.Rows(0)("fecha_fin")

                '--- AOS: 25/03/2021 - Fechas ininom y finNom que es el periodo de pago de la nomina
                fini_nom = dt_periodos.Rows(0)("fini_nom")
                ffin_nom = dt_periodos.Rows(0)("ffin_nom")


                Try : num_mes = dt_periodos.Rows(0)("NUM_MES").ToString.Trim : Catch ex As Exception : num_mes = "" : End Try
                Try : nom_cat = dt_periodos.Rows(0)("nom_cat").ToString.Trim : Catch ex As Exception : nom_cat = "" : End Try
                '- Determinar si serán ambos periodos sem y cat, o solo semanal
                If (nom_cat = "1") Then filtroPer = "'S','C'" Else filtroPer = "'S'"

                '----Mandar el periodo tanto de los semanales como de los 14nales para meterlos a nomina_pro
                If (nom_cat = "1") Then
                    Dim QC As String = "SELECT TOP 1 periodo, fecha_ini, fecha_fin,fini_nom,ffin_nom FROM periodos_catorcenal WHERE ano = '" & cmbAno.SelectedValue & "' and isnull(PERIODO_ESPECIAL,0)=0 and isnull(asentado,0)=0 order by periodo asc"
                    dt_periodoCatorcenal = sqlExecute(QC, "TA")
                    If (Not dt_periodoCatorcenal.Columns.Contains("Error") And dt_periodos.Rows.Count > 0) Then
                        Try : perCat = dt_periodoCatorcenal.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : perCat = "" : End Try
                        Try : FIniCat = dt_periodoCatorcenal.Rows(0).Item("fecha_ini") : Catch ex As Exception : FIniCat = Nothing : End Try
                        Try : FFinCat = dt_periodoCatorcenal.Rows(0).Item("fecha_fin") : Catch ex As Exception : FFinCat = Nothing : End Try
                        Try : fini_nom_cat = dt_periodoCatorcenal.Rows(0).Item("fini_nom") : Catch ex As Exception : fini_nom_cat = Nothing : End Try
                        Try : ffin_nom_cat = dt_periodoCatorcenal.Rows(0).Item("ffin_nom") : Catch ex As Exception : ffin_nom_cat = Nothing : End Try
                    End If
                End If

                '******* Saber si es el periodo es el inicio del ciclo del FAH para ACTIVAR su descuento
                Dim QFah As String = "select anio_ini,per_ini,anio_fin,per_fin,anio_liq,coment,activo from config_per_liqfah where anio_ini='" & _ano & "' and per_ini='" & _periodo & "'"
                dtActFAH = sqlExecute(QFah, "NOMINA")
                If (dtActFAH.Columns.Contains("Error") Or dtActFAH.Rows.Count > 0) Then
                    sqlExecute("update config_per_liqfah set activo=1 where anio_ini='" & _ano & "' and per_ini='" & _periodo & "'", "NOMINA")
                End If

                'limpiar tablas
                sqlExecute("truncate table primer_calc", "NOMINA")
                sqlExecute("truncate table status_proceso", "NOMINA")
                'Truncate table asegura que la tabla se va a limpiar sin depender del número de registros
                labelEstatus.Text = "Limpiando proceso anterior [1/4]"
                sqlExecute("truncate table nomina_pro", "NOMINA")
                Application.DoEvents()

                labelEstatus.Text = "Limpiando proceso anterior [2/4]"
                sqlExecute("truncate table movimientos_pro", "NOMINA")
                sqlExecute("truncate table movimientos_imss_pro", "NOMINA")
                Application.DoEvents()

                labelEstatus.Text = "Limpiando proceso anterior [3/4]"
                sqlExecute("truncate table ajustes_pro", "NOMINA")
                Application.DoEvents()

                labelEstatus.Text = "Limpiando proceso anterior [4/4]"
                sqlExecute("truncate table horas_pro", "NOMINA")
                Application.DoEvents()

                'Seleccionar empleados activos en el periodo
                ObtenerDatosDesdePersonal(_ano, _periodo, _fecha_ini, _fecha_fin) ' Actualizar nomina_pro desde PERSONALVW y desde INFONAVIT

                ObtenerFiniquitosEnProceso(_ano, _periodo, _fecha_ini, _fecha_fin) ' Los que esten en proceso eliminarlos de nomina_pro

                ObtenerDatosDesdeTA(_ano, _periodo, _fecha_ini, _fecha_fin) ' Actualiza horas_pro desde NOMSEM

                ObtenerDatosDesdeNomina(_ano, _periodo, _fecha_ini, _fecha_fin) ' Actualiza ajustes_pro desde ajustes_nom y mtro_ded


                MessageBox.Show("Proceso inicializado correctamente", "Proceso inicializado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                labelEstatus.Text = ""

                '---Actualizar status_proceso indicando que ya está listo el paso 2 que es Inicializar Nómina
                Dim dtStProc As DataTable = sqlExecute("select distinct ano,periodo from nomina_pro where tipo_periodo='S' order by periodo asc", "NOMINA")
                If (Not dtStProc.Columns.Contains("Error") And dtStProc.Rows.Count > 0) Then
                    Dim _anioSt As String = "", _perSt As String = ""
                    Try : _anioSt = dtStProc.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : _anioSt = "" : End Try
                    Try : _perSt = dtStProc.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : _perSt = "" : End Try
                    sqlExecute("insert into status_proceso (ano,periodo,avance,usuario,datetime) values ('" & _anioSt & "','" & _perSt & "','2','" & Usuario & "',Getdate())", "NOMINA")
                End If
            Else

                MessageBox.Show("El periodo seleccionado no existe o no está correctamente configurado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If


        Catch ex As Exception
            MessageBox.Show("Ocurrió un error al inicializar, último paso: " & labelEstatus.Text, "Error al inicializar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            labelEstatus.Text = ""
        End Try

        cmbAno.Enabled = True
        cmbPeriodo.Enabled = True
        btnIniciProcNom.Enabled = True

    End Sub


    Private Sub ObtenerDatosDesdePersonal(_ano As String, _periodo As String, _fecha_ini As Date, _fecha_fin As Date)
        '  Dim QP As String = "select * from personalvw where alta <= '" & FechaSQL(_fecha_ini) & "' and (baja is null or baja >= '" & FechaSQL(_fecha_fin) & "') order by reloj asc"
        Dim QP As String = "select * from personalvw where  isnull(SACTUAL,0)<>0 and isnull(alta,'')<>'' and (baja is null or baja >= '" & FechaSQL(_fecha_fin) & "') order by reloj asc" ' Aplica a todos lo activos automaticamente
        Dim dtActivos As DataTable = sqlExecute(QP, "PERSONAL")

        Dim empleados_a_importar As Integer = dtActivos.Rows.Count
        Dim contador_empleados As Integer = 1
        periodo_act = _ano.Trim & _periodo.Trim & "A"

        '---Obtener las fec inicio y fin del Periodo anterior para consultar en bitácora para posibles cambios
        Dim per_ant As Integer = Convert.ToInt32(_periodo) - 1
        Dim FiniPerAnt As Date
        Dim FFinPerAnt As Date

        'If (per_ant <= 0) Then per_ant = 1 'Validar que si es a inicio de año no mande cero
        'Dim dtPerAnt As DataTable = sqlExecute("select * from periodos where ano='" & _ano & "' and periodo='" & Integer.Parse(per_ant) & "'", "TA")
        Dim dtPerActual As DataTable = sqlExecute("select * from periodos where ano='" & _ano & "' and periodo='" & _periodo & "'", "TA")
        'If (Not dtPerAnt.Columns.Contains("Error") And dtPerAnt.Rows.Count > 0) Then
        '    FiniPerAnt = dtPerAnt.Rows(0)("fecha_ini")
        '    FFinPerAnt = dtPerAnt.Rows(0)("fecha_fin")
        'End If

        '--- Para consultar en bitacora debe de ser en base a la fecha fin del per ant que es la de incidencia hasta la fecha fin de la fecha del pago de nomina
        If (Not dtPerActual.Columns.Contains("Error") And dtPerActual.Rows.Count > 0) Then
            FiniPerAnt = dtPerActual.Rows(0)("fecha_fin")
            FFinPerAnt = dtPerActual.Rows(0)("ffin_nom")
        End If
        '---Ends

        For Each row_activos As DataRow In dtActivos.Select("tipo_periodo in (" & filtroPer & ")")

            ConsultaBitacoraNomina(dtActivos, row_activos, FiniPerAnt, FFinPerAnt) ' Consulta bitacora para conocer el valor del periodo anterior que es el que se va pagar en nomina (NOTA: No todos los campos aplican)

            Dim _reloj As String = row_activos("reloj").ToString.Trim
            Dim esbaja As Boolean = False

            '---Mandar el Num de periodo qeu le toque si es 14nal
            Dim _tipo_periodo As String = ""
            privac_dias = 0.0
            privac_porc = 0.0

            Try : _tipo_periodo = row_activos("tipo_periodo").ToString.Trim : Catch ex As Exception : _tipo_periodo = "" : End Try
            If (nom_cat = "1" And _tipo_periodo = "C") Then _periodo = perCat Else _periodo = perSem


            labelEstatus.Text = "Importando personal [" & _reloj & "][" & contador_empleados & " de " & empleados_a_importar & "]"
            sqlExecute("insert into nomina_pro (ano, periodo, reloj) values ('" & _ano & "', '" & _periodo & "', '" & _reloj & "')", "nomina")

            sqlExecute("update nomina_pro set procesar = 1 where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
            sqlExecute("update nomina_pro set periodo_act='" & periodo_act & "',mes='" & num_mes & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

            'DUDA, empleados inactivos o empleados a NO procesar, como finiquitos

            sqlExecute("update nomina_pro set cod_comp = '" & IIf(IsDBNull(row_activos("cod_comp")), "", row_activos("cod_comp")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
            sqlExecute("update nomina_pro set cod_planta = '" & IIf(IsDBNull(row_activos("cod_planta")), "", row_activos("cod_planta")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
            sqlExecute("update nomina_pro set cod_depto = '" & IIf(IsDBNull(row_activos("cod_depto")), "", row_activos("cod_depto")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
            sqlExecute("update nomina_pro set cod_area = '" & IIf(IsDBNull(row_activos("cod_area")), "", row_activos("cod_area")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
            sqlExecute("update nomina_pro set cod_super = '" & IIf(IsDBNull(row_activos("cod_super")), "", row_activos("cod_super")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

            sqlExecute("update nomina_pro set tipo_periodo = '" & IIf(IsDBNull(row_activos("tipo_periodo")), "", row_activos("tipo_periodo")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
            sqlExecute("update nomina_pro set cod_tipo = '" & IIf(IsDBNull(row_activos("cod_tipo")), "", row_activos("cod_tipo")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
            sqlExecute("update nomina_pro set cod_clase = '" & IIf(IsDBNull(row_activos("cod_clase")), "", row_activos("cod_clase")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

            sqlExecute("update nomina_pro set cod_turno = '" & IIf(IsDBNull(row_activos("cod_turno")), "", row_activos("cod_turno")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
            sqlExecute("update nomina_pro set cod_hora = '" & IIf(IsDBNull(row_activos("cod_hora")), "", row_activos("cod_hora")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
            sqlExecute("update nomina_pro set cod_puesto = '" & IIf(IsDBNull(row_activos("cod_puesto")), "", row_activos("cod_puesto")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
            sqlExecute("update nomina_pro set cod_costos = '" & IIf(IsDBNull(row_activos("CENTRO_COSTOS")), "", row_activos("CENTRO_COSTOS")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")


            sqlExecute("update nomina_pro set nombres = '" & IIf(IsDBNull(row_activos("nombres")), "", row_activos("nombres")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

            sqlExecute("update nomina_pro set IMSS_PRO = '" & IIf(IsDBNull(row_activos("IMSS")), "", row_activos("IMSS")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
            sqlExecute("update nomina_pro set DIG_VER = '" & IIf(IsDBNull(row_activos("DIG_VER")), "", row_activos("DIG_VER")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
            sqlExecute("update nomina_pro set RFC = '" & IIf(IsDBNull(row_activos("RFC")), "", row_activos("RFC")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
            sqlExecute("update nomina_pro set CURP = '" & IIf(IsDBNull(row_activos("CURP")), "", row_activos("CURP")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")



            sqlExecute("update nomina_pro set sactual = '" & IIf(IsDBNull(row_activos("sactual")), "0", row_activos("sactual")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
            sqlExecute("update nomina_pro set integrado = '" & IIf(IsDBNull(row_activos("integrado")), "0", row_activos("integrado")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

            sqlExecute("update nomina_pro set alta = '" & FechaSQL(row_activos("alta")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

            If Not IsDBNull(row_activos("baja")) Then
                esbaja = True
                sqlExecute("update nomina_pro set baja = '" & FechaSQL(row_activos("baja")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
            End If

            '--COD_TIPO_NOMINA : F -- Finiquitos ; N -- Nomina
            Dim cod_tipo_nomina As String = ""
            If Not IsDBNull(row_activos("baja")) Then cod_tipo_nomina = "F" Else cod_tipo_nomina = "N"
            sqlExecute("update nomina_pro set cod_tipo_nomina = '" & cod_tipo_nomina & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

            '---Obtener los dias de prima vac y el porc  por aniversario en caso de que el empleado esté cumpliendo años de anviersario
            ' AOS - Cambiar a que tome _fecha_ini y _fecha_fin de fini_nom y fin_nom para el calculo de la prima vacacional

            GetDataVac(_reloj.ToString.Trim, row_activos("cod_comp").ToString.Trim, row_activos("cod_tipo").ToString.Trim, FechaSQL(row_activos("alta")), row_activos("tipo_periodo").ToString.Trim, fini_nom, ffin_nom, fini_nom_cat, ffin_nom_cat)
            sqlExecute("update nomina_pro set privac_dias = '" & privac_dias & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
            sqlExecute("update nomina_pro set privac_porc = '" & privac_porc & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina") ' NOTA: Se inserta como viene, si es 25 asi se llena
            '---Ends PrimaVac y Porc PrimaVac

            '***************-Tarjetas y vales 
            Dim CUENTA_BANCO As String = "", CLABE As String = ""
            Try : CUENTA_BANCO = row_activos("CUENTA_BANCO").ToString.Trim : Catch ex As Exception : CUENTA_BANCO = "" : End Try
            Try : CLABE = row_activos("CLABE").ToString.Trim : Catch ex As Exception : CLABE = "" : End Try

            sqlExecute("update nomina_pro set BANCO = '" & IIf(IsDBNull(row_activos("BANCO")), "", row_activos("BANCO")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
            sqlExecute("update nomina_pro set CUENTA_BANCO = '" & CUENTA_BANCO & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
            sqlExecute("update nomina_pro set TARJETA_BANCO = '" & IIf(IsDBNull(row_activos("TARJETA_BANCO")), "", row_activos("TARJETA_BANCO")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
            sqlExecute("update nomina_pro set CLABE = '" & CLABE & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
            sqlExecute("update nomina_pro set CUENTA_BONOS = '" & IIf(IsDBNull(row_activos("CUENTA_BONOS")), "", row_activos("CUENTA_BONOS")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")
            sqlExecute("update nomina_pro set TARJETA_BONOS = '" & IIf(IsDBNull(row_activos("TARJETA_BONOS")), "", row_activos("TARJETA_BONOS")) & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

            '--cod_pago D - Depósito ; E - Efectivo
            Dim cod_pago As String = ""
            If (CUENTA_BANCO = "" And CLABE = "") Then cod_pago = "E" Else cod_pago = "D"
            sqlExecute("update nomina_pro set cod_pago = '" & cod_pago & "' where reloj = '" & _reloj & "' and ano = '" & _ano & "' and periodo = '" & _periodo & "'", "nomina")

            'INFONAVIT
            Dim drInf As DataRow = Nothing
            Try : drInf = dtInfonavit.Select("reloj ='" & _reloj & "'")(0) : Catch ex As Exception : drInf = Nothing : End Try
            If (Not IsNothing(drInf)) Then
                sqlExecute("update nomina_pro set infonavit_credito = '" & drInf("infonavit") & "' where reloj = '" & _reloj & "'", "nomina")
                sqlExecute("update nomina_pro set tipo_credito = '" & drInf("tipo_cred") & "' where reloj = '" & _reloj & "'", "nomina")
                sqlExecute("update nomina_pro set cuota_credito = '" & drInf("cuota_cred") & "' where reloj = '" & _reloj & "'", "nomina")
                sqlExecute("update nomina_pro set inicio_credito = '" & drInf("inicio_cre") & "' where reloj = '" & _reloj & "'", "nomina")
                sqlExecute("update nomina_pro set cobro_segviv= '" & drInf("cobro_segv") & "' where reloj = '" & _reloj & "'", "nomina")

            End If

            '--MAESTRO DE DEDUCCIONES
            For Each drMtDed As DataRow In dtMtroDed.Select("reloj='" & _reloj & "'")
                Dim concepto As String = "", saldo_act As Double = 0.0, abono_act As Double = 0.0, descrip As String = ""

                Try : concepto = drMtDed("concepto").ToString.Trim : Catch ex As Exception : concepto = "" : End Try
                Try : descrip = drMtDed("descrip").ToString.Trim : Catch ex As Exception : descrip = "" : End Try
                Try : saldo_act = drMtDed("saldo_act") : Catch ex As Exception : saldo_act = 0.0 : End Try
                Try : abono_act = drMtDed("abono_act") : Catch ex As Exception : abono_act = 0.0 : End Try


                If (esbaja) Then ' Si es una baja (Finiquito), traerse todo el saldo que debe para que lo descuente
                    abono_act = saldo_act
                End If


                If (saldo_act <= abono_act) Then abono_act = saldo_act

                sqlExecute("insert into ajustes_pro (ano, periodo, reloj,per_ded, concepto,descrip, monto,origen) values ('" & _ano & "', '" & _periodo & "', '" & _reloj & "','D', '" & concepto & "','" & descrip & "', '" & abono_act & "','" & Usuario & "')", "nomina")

            Next

            Application.DoEvents()
            contador_empleados += 1
        Next

        '----Agrupar un solo concepto para aquellos conceptos que se repitan del maestro de deducciones y dejar la suma total del monto por cada concepto
        Try
            Dim QBuscaRep As String = "SELECT ano,periodo,reloj,concepto,descrip,count(*) as totRepetidos from ajustes_pro group by ano,periodo,reloj,concepto,descrip having count(*)>1"
            Dim dtBuscaRep As DataTable = sqlExecute(QBuscaRep, "NOMINA")
            If (Not dtBuscaRep.Columns.Contains("Error") And dtBuscaRep.Rows.Count > 0) Then
                For Each row As DataRow In dtBuscaRep.Rows
                    Dim anio As String = "", per As String = "", rj As String = "", _concepto As String = "", _descrip As String = "", _monto As Double = 0.0

                    Try : anio = row("ano").ToString.Trim : Catch ex As Exception : anio = "" : End Try
                    Try : per = row("periodo").ToString.Trim : Catch ex As Exception : per = "" : End Try
                    Try : rj = row("reloj").ToString.Trim : Catch ex As Exception : rj = "" : End Try
                    Try : _concepto = row("concepto").ToString.Trim : Catch ex As Exception : _concepto = "" : End Try
                    Try : _descrip = row("descrip").ToString.Trim : Catch ex As Exception : _descrip = "" : End Try

                    Dim QMonto As String = "select sum(monto) AS monto,ano,periodo,reloj,concepto from ajustes_pro where ano='" & anio & "' and periodo='" & per & "' and reloj='" & rj & "' and concepto='" & _concepto & "' GROUP BY ano,periodo,reloj,concepto "
                    Dim dtMonto As DataTable = sqlExecute(QMonto, "NOMINA")
                    If (dtMonto.Rows.Count > 0) Then
                        Try : _monto = Double.Parse(dtMonto.Rows(0).Item("monto")) : Catch ex As Exception : _monto = 0.0 : End Try
                    End If

                    sqlExecute("delete from ajustes_pro where ano='" & anio & "' and periodo='" & per & "' and reloj='" & rj & "' and concepto='" & _concepto & "'", "NOMINA")

                    sqlExecute("insert into ajustes_pro (ano, periodo, reloj,per_ded, concepto,descrip, monto,origen) values ('" & anio & "', '" & per & "', '" & rj & "','D', '" & _concepto & "','" & _descrip & "', '" & _monto & "','" & Usuario & "')", "nomina")
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ObtenerFiniquitosEnProceso(_ano As String, _periodo As String, _fecha_ini As Date, _fecha_fin As Date)

        Try
            Dim dtEmpFiniqProc As New DataTable
            Dim QFiniqProc As String = "select n.cod_comp,n.reloj,n.ano,n.Periodo,n.status,p.alta,n.fhacalculo,n.tipo_periodo,isnull(n.asentado_deposito,0)as 'asentado' " & _
                "from nomina_calculo n left outer join PERSONAL.dbo.personalvw p " & _
                "on n.Reloj = p.RELOJ   WHERE n.ANO>='" & _ano & "' and RTRIM(n.status)<>'CANCELADO'"
            dtEmpFiniqProc = sqlExecute(QFiniqProc, "NOMINA")

            Dim empleados_a_descartar As Integer = dtEmpFiniqProc.Rows.Count
            Dim contador_empleados As Integer = 1

            If (empleados_a_descartar > 0) Then
                MessageBox.Show("Hay " & contador_empleados & " empleados que están en proceso de finiquito los cuales no se incluirán en esta nómina", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            For Each row_empl_finq As DataRow In dtEmpFiniqProc.Select("tipo_periodo in (" & filtroPer & ")")

                Dim _reloj As String = "", cod_comp As String = "", ano As String = "", periodo As String = "", status As String = "", alta As String = "", fhacalculo As String = "", tipo_periodo As String = "", asentado As Integer = 0

                Try : _reloj = row_empl_finq("reloj").ToString.Trim : Catch ex As Exception : _reloj = "" : End Try

                labelEstatus.Text = "Eliminando personal [" & _reloj & "][" & contador_empleados & " de " & empleados_a_descartar & "]"

                Try : cod_comp = row_empl_finq("cod_comp").ToString.Trim : Catch ex As Exception : cod_comp = "" : End Try
                Try : ano = row_empl_finq("ano").ToString.Trim : Catch ex As Exception : ano = "" : End Try
                Try : periodo = row_empl_finq("periodo").ToString.Trim : Catch ex As Exception : periodo = "" : End Try
                Try : status = row_empl_finq("status").ToString.Trim : Catch ex As Exception : status = "" : End Try
                Try : alta = FechaSQL(row_empl_finq("alta").ToString.Trim) : Catch ex As Exception : alta = "" : End Try
                Try : fhacalculo = FechaSQL(row_empl_finq("fhacalculo").ToString.Trim) : Catch ex As Exception : fhacalculo = "" : End Try
                Try : tipo_periodo = row_empl_finq("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_periodo = "" : End Try
                Try : asentado = Integer.Parse(row_empl_finq("asentado").ToString.Trim) : Catch ex As Exception : asentado = 0 : End Try

                '--- Validar que la fecha de calculo sea mayor a la fecha de alta del empleado
                Dim fecCalcFiniq As Date = Date.Parse(fhacalculo)
                Dim FecAltaEmpl As Date = Date.Parse(alta)

                If (fecCalcFiniq > FecAltaEmpl) Then
                    If (asentado = 0) Then
                        '--Si no está aun asentado, preguntar si se desea incluir en la nómina actual (/****PENDIENTE)
                        sqlExecute("delete from nomina_pro where reloj='" & _reloj & "' and cod_comp='" & cod_comp & "'", "NOMINA")
                    Else
                        ' - Si ya está asentado, eliminarlo de la nomina automaticamente
                        sqlExecute("delete from nomina_pro where reloj='" & _reloj & "' and cod_comp='" & cod_comp & "'", "NOMINA")
                    End If
                End If

                Application.DoEvents()
                contador_empleados += 1
            Next

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ObtenerDatosDesdeTA(_ano As String, _periodo As String, _fecha_ini As Date, _fecha_fin As Date)
        Dim QC As String = ""
        Dim QS As String = ""
        Dim PerAnt As String = ""
        Dim PerAct As String = ""

        PerAct = _periodo.ToString.Trim
        PerAnt = (Convert.ToInt32(_periodo) - 1).ToString.Trim

        PerAnt = PerAnt.PadLeft(2, "0")

        If (nom_cat = "1") Then  ' --Incluye nomina catorcenal y semenal

            '---Validación para inicio del primer periodo del año
            If (PerAct = "01" And PerAnt = "00") Then
                Dim anioPerAnt As String = ""
                Dim anioPerAct As String = _ano & PerAct

                '-- Buscar el anio ant y el periodo anterior
                Dim anio_ant As String = (Convert.ToInt32(_ano) - 1).ToString.Trim
                Dim QBuscaPerAnt As String = "select top 1 * from periodos where ano='" & anio_ant & "' and isnull(PERIODO_ESPECIAL,0)=0 order by periodo desc"
                Dim dtPerAnt As DataTable = sqlExecute(QBuscaPerAnt, "TA")
                If (Not dtPerAnt.Columns.Contains("Error") And dtPerAnt.Rows.Count > 0) Then
                    Dim _PerAnioAnt As String = ""
                    Try : _PerAnioAnt = dtPerAnt.Rows(0).Item("PERIODO").ToString.Trim : Catch ex As Exception : _PerAnioAnt = "" : End Try
                    anioPerAnt = anio_ant & _PerAnioAnt
                End If
                '--- Ends Busca el anio anterior y el per anterior

                '                QC = "SELECT nomsem.*, p.tipo_periodo AS 'tpo_per' from nomsem left outer join PERSONAL.dbo.personalvw p on nomsem.reloj=p.reloj  where ano+PERIODO in ('" & anioPerAnt & "','" & anioPerAct & "')  and " & _
                '"isnull(p.SACTUAL,0)<>0 and isnull(p.alta,'')<>'' and  (p.baja is null or p.baja >= '" & FechaSQL(_fecha_fin) & "') and p.tipo_periodo in('C')"  ' Todos los activos Catorcenales

                '-----2021-01-21 -- AOS : Que lo tome de NOMINA_PRO que ya trae el dato correcto
                QC = "SELECT n.*, p.tipo_periodo AS 'tpo_per' from nomsem n left outer join NOMINA.dbo.nomina_pro p on n.reloj=p.reloj  where n.ano+n.PERIODO in ('" & anioPerAnt & "','" & anioPerAct & "')  and " & _
"isnull(p.SACTUAL,0)<>0 and isnull(p.alta,'')<>'' and  (p.baja is null or p.baja >= '" & FechaSQL(_fecha_fin) & "') and p.tipo_periodo in('C')"  ' Todos los activos Catorcenales

            Else
                '             QC = "SELECT nomsem.*, p.tipo_periodo AS 'tpo_per' from nomsem left outer join PERSONAL.dbo.personalvw p on nomsem.reloj=p.reloj  where ano = '" & _ano & "' and periodo in ('" & PerAnt & "','" & PerAct & "') and " & _
                '"isnull(p.SACTUAL,0)<>0 and isnull(p.alta,'')<>'' and  (p.baja is null or p.baja >= '" & FechaSQL(_fecha_fin) & "') and p.tipo_periodo in('C')"  ' Todos los activos Catorcenales

                '-----2021-01-21 -- AOS : Que lo tome de NOMINA_PRO que ya trae el dato correcto
                QC = "SELECT n.*, p.tipo_periodo AS 'tpo_per' from nomsem n left outer join NOMINA.dbo.nomina_pro p on n.reloj=p.reloj  where n.ano = '" & _ano & "' and n.periodo in ('" & PerAnt & "','" & PerAct & "') and " & _
"isnull(p.SACTUAL,0)<>0 and isnull(p.alta,'')<>'' and  (p.baja is null or p.baja >= '" & FechaSQL(_fecha_fin) & "') and p.tipo_periodo in('C')"  ' Todos los activos Catorcenales
            End If

            ImportaNomsem(QC, _ano, _periodo, _fecha_ini, _fecha_fin)

            '            QS = "SELECT nomsem.*, p.tipo_periodo AS 'tpo_per' from nomsem left outer join PERSONAL.dbo.personalvw p on nomsem.reloj=p.reloj  where ano = '" & _ano & "' and periodo in ('" & PerAct & "') and " & _
            '"isnull(p.SACTUAL,0)<>0 and isnull(p.alta,'')<>'' and  (p.baja is null or p.baja >= '" & FechaSQL(_fecha_fin) & "') and p.tipo_periodo in('S')"  ' Todos los activos Semanales


            '-----2021-01-21 -- AOS : Que lo tome de NOMINA_PRO que ya trae el dato correcto
            QS = "SELECT n.*, p.tipo_periodo AS 'tpo_per' from nomsem n left outer join NOMINA.dbo.nomina_pro p on n.reloj=p.reloj  where n.ano = '" & _ano & "' and n.periodo in ('" & PerAct & "') and " & _
"isnull(p.SACTUAL,0)<>0 and isnull(p.alta,'')<>'' and  (p.baja is null or p.baja >= '" & FechaSQL(_fecha_fin) & "') and p.tipo_periodo in('S')"  ' Todos los activos Semanales


            ImportaNomsem(QS, _ano, _periodo, _fecha_ini, _fecha_fin)

        Else  ' Solo semanal

            '            QS = "SELECT nomsem.*, p.tipo_periodo AS 'tpo_per' from nomsem left outer join PERSONAL.dbo.personalvw p on nomsem.reloj=p.reloj  where ano = '" & _ano & "' and periodo = '" & _periodo & "' and " & _
            '"isnull(p.SACTUAL,0)<>0 and isnull(p.alta,'')<>'' and (p.baja is null or p.baja >= '" & FechaSQL(_fecha_fin) & "') and p.tipo_periodo in('S')" ' Todos los Semanales

            '-----2021-01-21 -- AOS : Que lo tome de NOMINA_PRO que ya trae el dato correcto
            QS = "SELECT n.*, p.tipo_periodo AS 'tpo_per' from nomsem n left outer join NOMINA.dbo.nomina_pro p on n.reloj=p.reloj  where n.ano = '" & _ano & "' and n.periodo = '" & _periodo & "' and " & _
"isnull(p.SACTUAL,0)<>0 and isnull(p.alta,'')<>'' and (p.baja is null or p.baja >= '" & FechaSQL(_fecha_fin) & "') and p.tipo_periodo in('S')" ' Todos los Semanales

            ImportaNomsem(QS, _ano, _periodo, _fecha_ini, _fecha_fin)
        End If

        '---Eliminar BONASI (Bono de asistencia para los catorcenales)
        Dim QDelBonasi As String = " DELETE FROM horas_pro where concepto='BONASI' and reloj in  " & _
            " (select h.reloj from horas_pro h left outer join nomina_pro n on h.reloj=n.RELOJ where n.tipo_periodo='C' and  h.concepto='BONASI')"
        sqlExecute(QDelBonasi, "NOMINA")


    End Sub

    Private Sub ImportaNomsem(_query As String, _ano As String, _periodo As String, _fecha_ini As Date, _fecha_fin As Date)
        Try

            Dim dt_nomsem As DataTable = sqlExecute(_query, "TA")
            If dt_nomsem.Rows.Count > 0 Then

                Dim contador_empleados As Integer = 1
                Dim empleados_a_importar As Integer = dt_nomsem.Rows.Count

                '--Variables necesarias
                Dim HRSNOR As Double = 0.0, HRSEX2 As Double = 0.0, HRSEX3 As Double = 0.0, HRSDOM As Double = 0.0, BONASI As Double = 0.0, DIACAF As Double = 0.0, DIAINC As Double = 0.0, DIACVN As Double = 0.0
                Dim HRSFES As Double = 0.0, HRSFEL As Double = 0.0

                For Each row_nomsem As DataRow In dt_nomsem.Rows
                    Dim _reloj_nomsem As String = row_nomsem("reloj")

                    '---Mandar el Num de periodo qeu le toque si es 14nal
                    Dim _tipo_periodo As String = ""
                    Try : _tipo_periodo = row_nomsem("tpo_per").ToString.Trim : Catch ex As Exception : _tipo_periodo = "" : End Try
                    If (nom_cat = "1" And _tipo_periodo = "C") Then _periodo = perCat

                    labelEstatus.Text = "Importando asistencia [" & _reloj_nomsem & "][" & contador_empleados & " de " & empleados_a_importar & "]"

                    Try : HRSNOR = Double.Parse(RoundUp(row_nomsem("HRS_NORMALES"), 2)) : Catch ex As Exception : HRSNOR = 0.0 : End Try
                    Try : HRSEX2 = Double.Parse(RoundUp(row_nomsem("HRS_DOBLES"), 2)) : Catch ex As Exception : HRSEX2 = 0.0 : End Try
                    Try : HRSEX3 = Double.Parse(RoundUp(row_nomsem("HRS_TRIPLES"), 2)) : Catch ex As Exception : HRSEX3 = 0.0 : End Try
                    Try : HRSDOM = Double.Parse(RoundUp(row_nomsem("HRS_PRIM_DOM"), 2)) : Catch ex As Exception : HRSDOM = 0.0 : End Try
                    Try : BONASI = Double.Parse(RoundUp(row_nomsem("BONO01"), 2)) : Catch ex As Exception : BONASI = 0.0 : End Try
                    '   Try : DIACAF = Double.Parse(RoundUp(row_nomsem("BONO04"), 2)) : Catch ex As Exception : DIACAF = 0.0 : End Try '  Por lo pronto se deja inhabilitado porque Brenda cargará todo manualmente
                    Try : DIAINC = Double.Parse(RoundUp(row_nomsem("BONO05"), 2)) : Catch ex As Exception : DIAINC = 0.0 : End Try
                    Try : DIACVN = Double.Parse(RoundUp(row_nomsem("BONO06"), 2)) : Catch ex As Exception : DIACVN = 0.0 : End Try
                    Try : HRSFES = Double.Parse(RoundUp(row_nomsem("HRS_FESTIVO"), 2)) : Catch ex As Exception : HRSFES = 0.0 : End Try
                    Try : HRSFEL = Double.Parse(RoundUp(row_nomsem("hrs_fel"), 2)) : Catch ex As Exception : HRSFEL = 0.0 : End Try


                    sqlExecute("insert into horas_pro (ano, periodo, reloj, concepto, monto,descripcion,usuario,fec_hora_registro) values ('" & _ano & "', '" & _periodo & "', '" & _reloj_nomsem & "', 'HRSNOR', '" & HRSNOR & "','Horas normales','" & Usuario & "',getdate())", "nomina")
                    sqlExecute("insert into horas_pro (ano, periodo, reloj, concepto, monto,descripcion,usuario,fec_hora_registro) values ('" & _ano & "', '" & _periodo & "', '" & _reloj_nomsem & "', 'HRSEX2', '" & HRSEX2 & "','Horas dobles','" & Usuario & "',getdate())", "nomina")
                    sqlExecute("insert into horas_pro (ano, periodo, reloj, concepto, monto,descripcion,usuario,fec_hora_registro) values ('" & _ano & "', '" & _periodo & "', '" & _reloj_nomsem & "', 'HRSEX3', '" & HRSEX3 & "','Horas triples','" & Usuario & "',getdate())", "nomina")
                    sqlExecute("insert into horas_pro (ano, periodo, reloj, concepto, monto,descripcion,usuario,fec_hora_registro) values ('" & _ano & "', '" & _periodo & "', '" & _reloj_nomsem & "', 'HRSDOM', '" & HRSDOM & "','Horas domingo','" & Usuario & "',getdate())", "nomina")
                    sqlExecute("insert into horas_pro (ano, periodo, reloj, concepto, monto,descripcion,usuario,fec_hora_registro) values ('" & _ano & "', '" & _periodo & "', '" & _reloj_nomsem & "', 'BONASI', '" & BONASI & "','Monto bono asist','" & Usuario & "',getdate())", "nomina")
                    '    sqlExecute("insert into horas_pro (ano, periodo, reloj, concepto, monto,descripcion,usuario,fec_hora_registro) values ('" & _ano & "', '" & _periodo & "', '" & _reloj_nomsem & "', 'DIACAF', '" & DIACAF & "','Días cafetería','" & Usuario & "',getdate())", "nomina")
                    sqlExecute("insert into horas_pro (ano, periodo, reloj, concepto, monto,descripcion,usuario,fec_hora_registro) values ('" & _ano & "', '" & _periodo & "', '" & _reloj_nomsem & "', 'DIAINC', '" & DIAINC & "','Días incapacidad','" & Usuario & "',getdate())", "nomina")
                    sqlExecute("insert into horas_pro (ano, periodo, reloj, concepto, monto,descripcion,usuario,fec_hora_registro) values ('" & _ano & "', '" & _periodo & "', '" & _reloj_nomsem & "', 'HRSFES', '" & HRSFES & "','Horas festivas','" & Usuario & "',getdate())", "nomina")
                    sqlExecute("insert into horas_pro (ano, periodo, reloj, concepto, monto,descripcion,usuario,fec_hora_registro) values ('" & _ano & "', '" & _periodo & "', '" & _reloj_nomsem & "', 'HRSFEL', '" & HRSFEL & "','Horas festivas laboradas','" & Usuario & "',getdate())", "nomina")

                    contador_empleados += 1

                    Application.DoEvents()
                Next

                '---- Para los catorcenales, sumarizar conceptos y eliminar repetidos
                If (nom_cat = "1") Then
                    Dim QTodos As String = "select h.*,n.tipo_periodo from horas_pro h left outer join nomina_pro n on h.reloj=n.RELOJ where  h.monto>0 and  n.tipo_periodo='C'"
                    Dim dtTodos As DataTable = sqlExecute(QTodos, "NOMINA")
                    If (Not dtTodos.Columns.Contains("Error") And dtTodos.Rows.Count > 0) Then
                        For Each drT As DataRow In dtTodos.Rows
                            Dim reloj As String = "", concepto As String = "", TotalConcep As Integer = 0
                            Try : reloj = drT("reloj").ToString.Trim : Catch ex As Exception : reloj = "" : End Try
                            Try : concepto = drT("concepto").ToString.Trim : Catch ex As Exception : concepto = "" : End Try

                            sqlExecute("update horas_pro set monto=(select ISNULL(SUM(MONTO),0) from horas_pro where concepto='" & concepto & "' AND reloj='" & reloj & "') where concepto='" & concepto & "' AND reloj='" & reloj & "'", "NOMINA") ' Actualizar monto para cada concepto

                            Dim dtTotConcep As DataTable = sqlExecute("select count(concepto) as 'TotalConcep' from  horas_pro where reloj='" & reloj & "' and concepto='" & concepto & "'", "NOMINA")

                            Try : TotalConcep = Integer.Parse(dtTotConcep.Rows(0).Item("TotalConcep")) : Catch ex As Exception : TotalConcep = 0 : End Try
                            If (TotalConcep > 1) Then
                                sqlExecute("WITH Q AS (select TOP 1 * from horas_pro where RELOJ='" & reloj & "' and concepto='" & concepto & "') Delete from Q", "NOMINA") ' Eliminar los repetidoos para dejar uno solo
                            End If


                        Next
                    End If
                End If

                '--- Eliminar todos los conceptos con valores CERO
                sqlExecute("delete from horas_pro where monto=0", "NOMINA")

            Else
                MessageBox.Show("No hay información de Tiempo y Asistencia disponible para el periodo " & _ano & " - " & _periodo, "Información no disponible", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ObtenerDatosDesdeNomina(_ano As String, _periodo As String, _fecha_ini As Date, _fecha_fin As Date)
        'Ajustes misceláneos

        Dim QC As String = ""
        Dim QS As String = ""
        Dim PerAnt As String = ""
        Dim PerAct As String = ""

        PerAct = _periodo.ToString.Trim
        PerAnt = (Convert.ToInt32(_periodo) - 1).ToString.Trim
        PerAnt = PerAnt.PadLeft(2, "0")

        If (nom_cat = "1") Then  ' --Incluye nomina catorcenal y semenal

            If (PerAct = "01" And PerAnt = "00") Then

                Dim anioPerAnt As String = ""
                Dim anioPerAct As String = _ano & PerAct

                '-- Buscar el anio ant y el periodo anterior
                Dim anio_ant As String = (Convert.ToInt32(_ano) - 1).ToString.Trim
                Dim QBuscaPerAnt As String = "select top 1 * from periodos where ano='" & anio_ant & "' and isnull(PERIODO_ESPECIAL,0)=0 order by periodo desc"
                Dim dtPerAnt As DataTable = sqlExecute(QBuscaPerAnt, "TA")
                If (Not dtPerAnt.Columns.Contains("Error") And dtPerAnt.Rows.Count > 0) Then
                    Dim _PerAnioAnt As String = ""
                    Try : _PerAnioAnt = dtPerAnt.Rows(0).Item("PERIODO").ToString.Trim : Catch ex As Exception : _PerAnioAnt = "" : End Try
                    anioPerAnt = anio_ant & _PerAnioAnt
                End If
                '--- Ends Busca el anio anterior y el per anterior

                '                QC = "SELECT ajustes_nom.*, p.tipo_periodo AS 'tpo_per' from ajustes_nom left outer join PERSONAL.dbo.personalvw p on ajustes_nom.reloj=p.reloj  where ano+periodo in ('" & anioPerAnt & "','" & anioPerAct & "') and " & _
                '"isnull(p.SACTUAL,0)<>0 and isnull(p.alta,'')<>'' and (p.baja is null or p.baja >= '" & FechaSQL(_fecha_fin) & "') and p.tipo_periodo in('C')" ' --Todos los activos Catorcenales

                '-------2021-01-21 :: AOS: Que tome el valor de nomina_pro que es el valor correcto
                QC = "SELECT a.*, p.tipo_periodo AS 'tpo_per' from ajustes_nom a left outer join nomina_pro p on a.reloj=p.reloj  where a.ano+a.periodo in ('" & anioPerAnt & "','" & anioPerAct & "') and " & _
"isnull(p.SACTUAL,0)<>0 and isnull(p.alta,'')<>'' and (p.baja is null or p.baja >= '" & FechaSQL(_fecha_fin) & "') and p.tipo_periodo in('C')" ' --Todos los activos Catorcenales


            Else
                '            QC = "SELECT ajustes_nom.*, p.tipo_periodo AS 'tpo_per' from ajustes_nom left outer join PERSONAL.dbo.personalvw p on ajustes_nom.reloj=p.reloj  where ano = '" & _ano & "' and periodo in ('" & PerAnt & "','" & PerAct & "') and " & _
                '"isnull(p.SACTUAL,0)<>0 and isnull(p.alta,'')<>'' and (p.baja is null or p.baja >= '" & FechaSQL(_fecha_fin) & "') and p.tipo_periodo in('C')" ' --Todos los activos Catorcenales

                '-------2021-01-21 :: AOS: Que tome el valor de nomina_pro que es el valor correcto
                QC = "SELECT a.*, p.tipo_periodo AS 'tpo_per' from ajustes_nom a left outer join nomina_pro p on a.reloj=p.reloj  where a.ano = '" & _ano & "' and a.periodo in ('" & PerAnt & "','" & PerAct & "') and " & _
"isnull(p.SACTUAL,0)<>0 and isnull(p.alta,'')<>'' and (p.baja is null or p.baja >= '" & FechaSQL(_fecha_fin) & "') and p.tipo_periodo in('C')" ' --Todos los activos Catorcenales

            End If

            ImportaAjustesNom(QC, _ano, _periodo, _fecha_ini, _fecha_fin)

            '            QS = "SELECT ajustes_nom.*, p.tipo_periodo AS 'tpo_per' from ajustes_nom left outer join PERSONAL.dbo.personalvw p on ajustes_nom.reloj=p.reloj  where ano = '" & _ano & "' and periodo in ('" & PerAct & "') and " & _
            '"isnull(p.SACTUAL,0)<>0 and isnull(p.alta,'')<>'' and (p.baja is null or p.baja >= '" & FechaSQL(_fecha_fin) & "') and p.tipo_periodo in('S')" ' --Todos los activos Semanales

            '-------2021-01-21 :: AOS: Que tome el valor de nomina_pro que es el valor correcto
            QS = "SELECT a.*, p.tipo_periodo AS 'tpo_per' from ajustes_nom a left outer join nomina_pro p on a.reloj=p.reloj  where a.ano = '" & _ano & "' and a.periodo in ('" & PerAct & "') and " & _
"isnull(p.SACTUAL,0)<>0 and isnull(p.alta,'')<>'' and (p.baja is null or p.baja >= '" & FechaSQL(_fecha_fin) & "') and p.tipo_periodo in('S')" ' --Todos los activos Semanales
            ImportaAjustesNom(QS, _ano, _periodo, _fecha_ini, _fecha_fin)

        Else  ' Solo semanal

            'QS = "SELECT ajustes_nom.*, p.tipo_periodo AS 'tpo_per' from ajustes_nom left outer join PERSONAL.dbo.personalvw p on ajustes_nom.reloj=p.reloj  where ano = '" & _ano & "' and periodo = '" & _periodo & "' and " & _
            '                        "isnull(p.SACTUAL,0)<>0 and isnull(p.alta,'')<>'' and (p.baja is null or p.baja >= '" & FechaSQL(_fecha_fin) & "') and p.tipo_periodo in('S')" ' -- Todos los activos Semanales

            '-------2021-01-21 :: AOS: Que tome el valor de nomina_pro que es el valor correcto

            QS = "SELECT a.*, p.tipo_periodo AS 'tpo_per' from ajustes_nom a left outer join nomina_pro p on a.reloj=p.reloj  where a.ano = '" & _ano & "' and a.periodo = '" & _periodo & "' and " & _
                                    "isnull(p.SACTUAL,0)<>0 and isnull(p.alta,'')<>'' and (p.baja is null or p.baja >= '" & FechaSQL(_fecha_fin) & "') and p.tipo_periodo in('S')" ' -- Todos los activos Semanales
            ImportaAjustesNom(QS, _ano, _periodo, _fecha_ini, _fecha_fin)

        End If


    End Sub

    Private Sub ImportaAjustesNom(_query As String, _ano As String, _periodo As String, _fecha_ini As Date, _fecha_fin As Date)
        Try

            Dim dt_nomsem As DataTable = sqlExecute(_query, "nomina")
            If dt_nomsem.Rows.Count > 0 Then

                Dim contador_empleados As Integer = 1
                Dim empleados_a_importar As Integer = dt_nomsem.Rows.Count

                For Each row_nomsem As DataRow In dt_nomsem.Rows
                    Dim _reloj_nomsem As String = row_nomsem("reloj")

                    '---Mandar el Num de periodo qeu le toque si es 14nal
                    Dim _tipo_periodo As String = ""
                    Try : _tipo_periodo = row_nomsem("tpo_per").ToString.Trim : Catch ex As Exception : _tipo_periodo = "" : End Try
                    If (nom_cat = "1" And _tipo_periodo = "C") Then _periodo = perCat


                    labelEstatus.Text = "Importando ajustes [" & _reloj_nomsem & "][" & contador_empleados & " de " & empleados_a_importar & "]"

                    Dim concepto As String = row_nomsem("concepto")
                    Dim monto As Double = RoundUp(IIf(IsDBNull(row_nomsem("monto")), 0, row_nomsem("monto")), 2)
                    Dim comentario As String = ""
                    Try : comentario = row_nomsem("comentario").ToString.Trim : Catch ex As Exception : comentario = "" : End Try
                    sqlExecute("insert into ajustes_pro (ano, periodo, reloj, concepto, monto,comentario) values ('" & _ano & "', '" & _periodo & "', '" & _reloj_nomsem & "', '" & concepto & "', '" & monto & "','" & comentario & "')", "nomina")

                    contador_empleados += 1

                    Application.DoEvents()
                Next
            Else
                MessageBox.Show("No hay información de Ajustes a Nómina disponible para el periodo " & _ano & " - " & _periodo, "Información no disponible", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub GetDataVac(ByRef Reloj As String, cod_comp As String, cod_tipo As String, alta As String, _tipoPer As String, finiSem As Date, ffinSem As Date, _fIniCat As Date, _FFinCat As Date)
        privac_dias = 0.0
        privac_porc = 0.0
        Try
            If (Reloj <> "" And cod_comp <> "" And cod_tipo <> "" And alta <> "") Then
                ' select reloj,alta from personalvw where ALTA>='2019-09-14' and alta<='2019-09-20'
                Dim alta_Orig As Date = Date.Parse(alta)
                Dim anio_actual = Date.Today.Year.ToString.Trim
                Dim mes As String = alta.Substring(5, 2)
                Dim dia As String = alta.Substring(8, 2)
                alta = anio_actual & "-" & mes & "-" & dia
                Dim AltaDate As Date = Date.Parse(alta)
                Dim AniosCumplidos As Integer = 0

                If (_tipoPer = "S") Then

                    ' Comparar fechas
                    If (AltaDate >= finiSem And AltaDate <= ffinSem) Then
                        AniosCumplidos = DateDiff(DateInterval.Year, alta_Orig, AltaDate)

                        Dim drowVac As DataRow = Nothing
                        Try : drowVac = dtFactVac.Select("cod_tipo='" & cod_tipo & "' and anos=" & AniosCumplidos & " and cod_comp='" & cod_comp & "'")(0) : Catch ex As Exception : drowVac = Nothing : End Try
                        If (Not IsNothing(drowVac)) Then
                            privac_dias = drowVac("DIAS")
                            privac_porc = drowVac("POR_PRIMA")
                        End If
                    End If

                End If

                If (_tipoPer = "C") Then
                    ' Comparar fechas
                    If (AltaDate >= _fIniCat And AltaDate <= _FFinCat) Then
                        AniosCumplidos = DateDiff(DateInterval.Year, alta_Orig, AltaDate)

                        Dim drowVac As DataRow = Nothing
                        Try : drowVac = dtFactVac.Select("cod_tipo='" & cod_tipo & "' and anos=" & AniosCumplidos & " and cod_comp='" & cod_comp & "'")(0) : Catch ex As Exception : drowVac = Nothing : End Try
                        If (Not IsNothing(drowVac)) Then
                            privac_dias = drowVac("DIAS")
                            privac_porc = drowVac("POR_PRIMA")
                        End If
                    End If

                End If

            Else
                Exit Sub
            End If

        Catch ex As Exception
            privac_dias = 0.0
            privac_porc = 0.0
        End Try
    End Sub



    Private Sub labelEstatus_Click(sender As Object, e As EventArgs) Handles labelEstatus.Click

    End Sub
End Class