Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions

Public Class frmCalcNom

    '*******Variables a utilizar
    '----OTRAS
    Dim asentado As String = ""

    '----DataTables
    Dim dtConceptos As New DataTable
    Dim dtNominaPro As New DataTable
    Dim dtHorasPro As New DataTable
    Dim dtAjustesPro As New DataTable
    Dim dtMovimientos_pro As New DataTable
    Dim dtStatusProc As New DataTable
    Dim dtTurnos As New DataTable
    Dim dtInfonavit As New DataTable
    Dim dtResultadoNomina As New DataTable
    Dim dtDifConceptos As New DataTable
    Dim dtPensAlim As New DataTable
    Dim filtroNomina As String = ""
    Dim dtPerAguiPag As New DataTable
    Dim dtEmplAguiPag As New DataTable
    Dim dtAplicaDescFah As New DataTable
    Dim dtDiasHorarioDesc As New DataTable ' AOS 2023-01-04 para contabilizar los dias de descanso

    '--Var relacionadas a fechas del periodo del pago de la nómina (TA.dbo.periodos.fini_nom y ffin_nom  y tambien para periodos_catorcenal)
    Dim anio As String = ""
    Dim periodo As String = "" ' Periodo semanal de la nomina a procesar
    Dim num_per_sem As String = ""
    Dim nom_cat As Integer = 0 ' indica si aplica o no catorcena
    Dim fIniSem As String = ""
    Dim fFinSem As String = ""
    Dim fIniCat As String = ""
    Dim fFinCat As String = ""
    Dim num_mes As String = ""


    '--Var relacionadas a los periodos que se estarán procesando en el cálculo
    Dim anio1 As String = "", per1 As String = "", tipo_per1 As String = "", anio2 As String = "", per2 As String = "", tipo_per2 As String = ""
    Dim NumMesSem As String = "", NumMesCat As String = "" ' Indica el num de mes en el qeu estamos viviendo para obtener el acumulado de la percep gravada de las ultimas 4 semanas o 2 si es 14nal
    Dim Aj_Sub_Sem As Boolean = False  ' Indica si aplica sub cau para la semanal
    Dim Aj_Sub_Cat As Boolean = False ' Indica si aplica sub cau para la 14nal
    Dim TotPerProc As Integer = 0 ' Total de periodos que se están procesando


    '-- Var relacionadas a los conceptos de nomina a calcular
    '-OTROS
    Dim dtCod_Comp As DataTable
    Dim cod_comp As String = "WME"
    Dim UMA As Double = 0.0
    Dim SALMIN As Double = 0.0
    Dim prima_riesg_imss As Double = 0.0
    Dim cuota_segviv As Double = 0.0
    Dim UMI As Double = 0.0 ' Valor del factor de descuento para Infonavit
    Dim aplDescFah As Boolean = False

    '--HORAS
    Dim HRSNOR As Double = 0.0 ' Horas normales
    Dim HRSFES As Double = 0.0 ' Horas Festivas
    Dim HRSEX2 As Double = 0.0 ' Horas extras dobles
    Dim HRSEX3 As Double = 0.0 ' Horas extras triples
    Dim HRSDOM As Double = 0.0 ' Horas Domingo
    Dim HRSFEL As Double = 0.0 ' Horas festivas laboradas
    Dim HRSINC As Double = 0.0 ' Horas de Incapacidad


    '--DIAS
    Dim DIASPA As Double = 0.0 ' Dias pagados
    Dim DIASDE As Double = 0.0 ' Dias de descando o festivos
    Dim DIASVA As Double = 0.0 ' Dias de vacaciones
    Dim DIASPV As Double = 0.0 ' Dias de prima vacacional
    Dim DIASAG As Double = 0.0 ' Dias de aguinaldo
    Dim DIAUNI As Double = 0.0 ' Días para pago de separación única
    Dim DIACAF As Double = 0.0 ' Días para descuento de cafetería
    Dim DIAINC As Double = 0.0 ' Dias de incapacidad
    Dim DIACVN As Double = 0.0 ' Días de convenio
    Dim _diasImss As Double = 0.0 ' Días para IMSS


    '--PERCEPCIONES
    Dim PERNOR As Double = 0.0 ' PERCEPCION NORMAL
    Dim HONASI As Double = 0.0 ' Sueldos asimilados a salarios (Solo aplica para los practicantes)
    Dim SEPDIA As Double = 0.0 ' PERCEPCION SEPTIMO DIA
    Dim PERFES As Double = 0.0 ' PERCEPCION FESTIVA
    Dim PEREX2 As Double = 0.0 ' PERCEP Extra doble
    Dim PEREX3 As Double = 0.0 ' PERCEP Extra triple
    Dim PRIDOM As Double = 0.0 ' PERCEP Prima dominical
    Dim PERVAC As Double = 0.0 ' PERCEP VACACIONES
    Dim PRIVAC As Double = 0.0 ' PERCEP Prima vacacional
    Dim PERAGI As Double = 0.0 ' PERCEP de aguinaldo
    Dim RETROA As Double = 0.0 ' Retroactivo
    Dim EXEDFA As Double = 0.0 ' Exedente de fondo de ahorro
    Dim PERPTU As Double = 0.0 ' Percpcion de Utilidades PTU
    Dim OTPGRA As Double = 0.0 ' Otras percepciones gravadas
    Dim OTPNOG As Double = 0.0 ' Otras percepciones no gravadas
    Dim SEPUNI As Double = 0.0 ' Separación Unica
    Dim APOCIA As Double = 0.0 '-- Aportacion del FAH Empresa, va como Informativa
    Dim FESLAB As Double = 0.0 '-- Festivo laborado
    Dim PERINC As Double = 0.0 ' --- Percepcion por incapacidad que no afecta al neto ni al total percep
    Dim BONREF As Double = 0.0
    Dim PREEFI As Double = 0.0
    Dim PERDES As Double = 0.0 ' Percepción de horas  festivas
    Dim SUBINC As Double = 0.0 ' Subsidio por incapacidad
    Dim DEVFON As Double = 0.0 ' Devolucion de fonacot
    Dim DEVINF As Double = 0.0 ' Devolución de Infonavit



    Dim BONASI As Double = 0.0 ' BONO ASISTENCIA
    Dim BONDES As Double = 0.0 ' BONO DESPENSA
    Dim DESEFE As Double = 0.0 ' BONO DESPENSA EN EFECTIVO
    Dim BONPRO As Double = 0.0 ' BONO PRODUCTIVIDAD

    Dim LIFAHC As Double = 0.0 ' Liq fondo de ahorro empresa
    Dim LIFAHE As Double = 0.0 ' Liq fondo de ahorro empleado 

    '---Pagos por separación
    Dim PRIANT As Double = 0.0 ' BONO ASISTENCIA
    Dim INDEMN As Double = 0.0 ' BONO ASISTENCIA
    Dim NOREST As Double = 0.0 ' BONO ASISTENCIA

    '--PARTES EXENTAS
    Dim PEXEXT As Double = 0.0 ' Exento del tiempo extra 
    Dim PEXDOM As Double = 0.0 ' Exento de la prima dominical
    Dim PEXVAC As Double = 0.0 ' Exento de la prima vacacional
    Dim PEXAGI As Double = 0.0 ' Exento de aguinaldo
    Dim PEXPAN As Double = 0.0 ' Exento de prima de antiguedad
    Dim PEXIND As Double = 0.0 ' Exento de indemnización
    Dim PEXNOR As Double = 0.0 ' Exento de no restitución
    Dim PEXPTU As Double = 0.0 ' Exento de no Utilidades (PTU)
    Dim PEXFAH As Double = 0.0 ' Exento de la aportacion de FAH de la Empresa


    '--DEDUCCIONES
    Dim ISPT As Double = 0.0   ' ISR Causado
    Dim SUBCAU As Double = 0.0 ' Subsidio al empleo causado
    Dim ISPTRE As Double = 0.0 ' ISR realmenteRETENIDO DEL PERIDOO
    Dim SUBPAG As Double = 0.0 ' Subsidio al empleo realmente pagado
    Dim CUOCAF As Double = 0.0 ' Descuento de cafetería
    Dim DESINF As Double = 0.0 ' Descuento de infonavit
    Dim SEGVIV As Double = 0.0 ' Descuento de Seg vivienda
    Dim IMSS As Double = 0.0   ' Descuento de IMSS
    Dim FNAALC As Double = 0.0 ' Descuento de Fonacot
    Dim LENTES As Double = 0.0 ' Descuento de Lentes
    Dim APOFAH As Double = 0.0 ' Aportación de fondo de ahorro Empleado
    Dim APOFAC As Double = 0.0 ' Aportación de fondo de ahorro Empresa
    Dim AJSUPE As Double = 0.0 ' Ajuste al subsidio causado
    Dim ADEINF As Double = 0.0 ' Préstamo de Infonavit
    Dim ANTSUE As Double = 0.0 ' Anticipo de sueldo
    Dim PENALI As Double = 0.0 ' Pensión alimenticia 1
    Dim OTRASD As Double = 0.0 ' Otras deducciones
    Dim ABOPMO As Double = 0.0 ' Abono préstamo
    Dim ABOINT As Double = 0.0 ' Abono Intereses
    Dim PENAL2 As Double = 0.0 ' Pensión alimenticia 2
    Dim PENAL3 As Double = 0.0 ' Pensión alimenticia 3


    '--TOTALES
    Dim PERGRA As Double = 0.0 ' Total de percep gravable
    Dim PEREXE As Double = 0.0  ' Total de percepción exenta
    Dim TOTPER As Double = 0.0 ' Total de percepciones
    Dim TOTDED As Double = 0.0 ' Total de deducciones
    Dim NETO As Double = 0.0   ' Total Neto

    '--Saldos del fondo de ahorro
    Dim SAFAHC As Double = 0.0 ' - Saldo de Fondo de ahorro Compañía
    Dim SAFAHE As Double = 0.0 ' - Saldo de fondo de ah Empresa

    '--Informativos
    Dim IMPEST As Double = 0.0 ' Impuesto estatal


    '*******Ends 

    Private Sub frmCalcNom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '-- Cargar el año y periodo actual abierto inicializado
        dtCod_Comp = sqlExecute("select COD_COMP from cias where CIA_DEFAULT=1", "PERSONAL")
        If (Not dtCod_Comp.Columns.Contains("Error") And dtCod_Comp.Rows.Count > 0) Then
            Try : cod_comp = dtCod_Comp.Rows(0).Item("cod_comp").ToString.Trim : Catch ex As Exception : cod_comp = "" : End Try
        End If
        CargaDatosIniciales()
    End Sub
    Private Sub CargaDatosIniciales()
        '-- Tomar las fechas de inicio y fin del periodo semanal y catorcenal (si aplica)
        dtStatusProc = sqlExecute("select * from status_proceso", "NOMINA")
        If (Not dtStatusProc.Columns.Contains("Error") And dtStatusProc.Rows.Count > 0) Then
            Try : anio = dtStatusProc.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : anio = "" : End Try
            Try : periodo = dtStatusProc.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : periodo = "" : End Try
            If (anio.Trim <> "" And periodo.Trim <> "") Then
                Dim dtPeriodo As DataTable = sqlExecute("SELECT * from ta.dbo.periodos where ano+PERIODO='" & anio & periodo & "'")
                If (Not dtPeriodo.Columns.Contains("Error") And dtPeriodo.Rows.Count > 0) Then
                    Try : num_per_sem = dtPeriodo.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : num_per_sem = "" : End Try
                    Try : fIniSem = FechaSQL(dtPeriodo.Rows(0).Item("fini_nom").ToString.Trim) : Catch ex As Exception : fIniSem = "" : End Try
                    Try : fFinSem = FechaSQL(dtPeriodo.Rows(0).Item("ffin_nom").ToString.Trim) : Catch ex As Exception : fFinSem = "" : End Try
                    Try : asentado = dtPeriodo.Rows(0).Item("asentado").ToString.Trim : Catch ex As Exception : asentado = "" : End Try
                    Try : nom_cat = dtPeriodo.Rows(0).Item("nom_cat") : Catch ex As Exception : nom_cat = 0 : End Try
                    Try : num_mes = dtPeriodo.Rows(0).Item("num_mes").ToString.Trim : Catch ex As Exception : num_mes = "" : End Try
                End If

                txtAnio.Text = anio
                txtPeriodo.Text = periodo & " del " & fIniSem & " al " & fFinSem

                '----Obtener el total se semanas para descuento de Infonavit
                Dim dtTotSemInfo As DataTable = sqlExecute("select count(periodo) as 'numSemInfo' from periodos where ano='" & anio & "' and  NUM_MES='" & num_mes & "'", "TA")
                If (dtTotSemInfo.Rows.Count > 0) Then
                    Try : totSemDescInfo = Double.Parse(dtTotSemInfo.Rows(0).Item("numSemInfo")) : Catch ex As Exception : totSemDescInfo = 0 : End Try
                End If

                '--- Obtener periodo y empleados de nomina de aguinaldo pagada
                Dim QPerAgui As String = "select * from periodos where ano='" & anio & "' and observaciones like '%aguinaldo%' and PERIODO_ESPECIAL=1"
                Dim QNomAguiPag As String = ""
                Dim per_agui_pag As String = ""
                dtPerAguiPag = sqlExecute(QPerAgui, "TA")
                If (Not dtPerAguiPag.Columns.Contains("Error") And dtPerAguiPag.Rows.Count > 0) Then
                    Try : per_agui_pag = dtPerAguiPag.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : per_agui_pag = "" : End Try

                    QNomAguiPag = "select * from movimientos where ano+periodo='" & anio & per_agui_pag & "' and concepto='PERAGI' and monto<>0 "
                    dtEmplAguiPag = sqlExecute(QNomAguiPag, "NOMINA")
                End If

                '--- Saber si estamos en periodo de descuendo de saldos de Fondo de ahorro
                dtAplicaDescFah = sqlExecute("SELECT * from config_per_liqfah where isnull(activo,0)=1", "NOMINA")
                If (Not dtAplicaDescFah.Columns.Contains("Error") And dtAplicaDescFah.Rows.Count > 0) Then aplDescFah = True

            End If

        Else
            MessageBox.Show("No hay un periodo inicializado a procesar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnCalcGenNom_Click(sender As Object, e As EventArgs) Handles btnCalcGenNom.Click
        If (asentado = "1") Then
            MessageBox.Show("El periodo ya encuentra asentado/cerrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Me.Dispose()
            Exit Sub
        End If
        CalculoNomina(txtAnio.Text.Trim, txtPeriodo.Text.Trim, "G", "procesar=1", "") ' Forma general
    End Sub

    Public Sub GenRepNominaDetalle(ByRef anio As String, periodo As String, nivel_consulta As String, tipo_per As String)
        Try
            Dim dtDatos As New DataTable
            Dim NombreReporte As String = "Nómina detalle"
            Dim query As String = "EXEC ReporteadorNominaTipoPeriodo_pro @Cia = '', @ano = '" & anio & "', @periodo = '" & periodo & _
                               "',@Nivel = '" & nivel_consulta & "', @reloj = '', @TipoPeriodo = '" & tipo_per & "'"
            dtResultadoNomina = sqlExecute(query, "NOMINA")

            If (Not dtResultadoNomina.Columns.Contains("Error") And dtResultadoNomina.Rows.Count > 0) Then

                dtResultadoNomina.Columns.Add("periodos")
                '   PreparaDatos(NombreReporte, dtResultadoNomina)
                NominaProExcel(dtDatos, dtResultadoNomina, False, True, "Nómina detalle", False, "", anio, periodo, tipo_per)

            Else
                MessageBox.Show("No hay información para generar la nómina detalle", "Generación de nómina detalle", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Function GetTiposPer(ByRef FiltroNom As String) As Integer
        Try
            Dim QPer As String = "select distinct ano,periodo,tipo_periodo from nomina_pro where " & FiltroNom & " order by tipo_periodo desc" ' Para que coloque siempre la Sem en 1er lugar
            Dim dtValidaPer As DataTable = sqlExecute(QPer, "NOMINA")

            Dim Q1 As String = ""
            Dim Q2 As String = ""
            Dim dtPer1 As New DataTable
            Dim dtPer2 As New DataTable

            If (Not dtValidaPer.Columns.Contains("Error") And dtValidaPer.Rows.Count > 0) Then

                If (dtValidaPer.Rows.Count = 1) Then ' Es solo un periodo mandado
                    Try : anio1 = dtValidaPer.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : anio1 = "" : End Try
                    Try : per1 = dtValidaPer.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : per1 = "" : End Try
                    Try : tipo_per1 = dtValidaPer.Rows(0).Item("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_per1 = "" : End Try
                    TotPerProc = 1
                End If

                If (dtValidaPer.Rows.Count = 2) Then ' Son los dos periodos que se mandan
                    Try : anio1 = dtValidaPer.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : anio1 = "" : End Try
                    Try : per1 = dtValidaPer.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : per1 = "" : End Try
                    Try : tipo_per1 = dtValidaPer.Rows(0).Item("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_per1 = "" : End Try

                    Try : anio2 = dtValidaPer.Rows(1).Item("ano").ToString.Trim : Catch ex As Exception : anio2 = "" : End Try
                    Try : per2 = dtValidaPer.Rows(1).Item("periodo").ToString.Trim : Catch ex As Exception : per2 = "" : End Try
                    Try : tipo_per2 = dtValidaPer.Rows(1).Item("tipo_periodo").ToString.Trim : Catch ex As Exception : tipo_per2 = "" : End Try

                    TotPerProc = 2
                End If

                '-- Saber si se aplicará ajuste al sub causado en el (los) periodo(s) (Solo es una vez al mes)
                If (TotPerProc = 1) Then
                    If (tipo_per1 = "S") Then Q1 = "select * from periodos where ano+PERIODO='" & anio1 & per1 & "'" Else Q1 = "select * from periodos_catorcenal where ano+PERIODO='" & anio1 & per1 & "'"
                    dtPer1 = sqlExecute(Q1, "TA")
                    If (Not dtPer1.Columns.Contains("Error") And dtPer1.Rows.Count > 0) Then
                        If (tipo_per1 = "S") Then
                            Try : NumMesSem = dtPer1.Rows(0).Item("NUM_MES").ToString.Trim : Catch ex As Exception : NumMesSem = "" : End Try
                            Try : Aj_Sub_Sem = Boolean.Parse(dtPer1.Rows(0).Item("aj_sub")) : Catch ex As Exception : Aj_Sub_Sem = False : End Try
                        End If

                        If (tipo_per1 = "C") Then
                            Try : NumMesCat = dtPer1.Rows(0).Item("NUM_MES").ToString.Trim : Catch ex As Exception : NumMesCat = "" : End Try
                            Try : Aj_Sub_Cat = Boolean.Parse(dtPer1.Rows(0).Item("aj_sub")) : Catch ex As Exception : Aj_Sub_Cat = False : End Try
                        End If
                    End If

                End If

                If (TotPerProc = 2) Then
                    Q1 = "select * from periodos where ano+PERIODO='" & anio1 & per1 & "'"
                    Q2 = "select * from periodos_catorcenal where ano+PERIODO='" & anio2 & per2 & "'"
                    dtPer1 = sqlExecute(Q1, "TA")
                    dtPer2 = sqlExecute(Q2, "TA")
                    If (Not dtPer1.Columns.Contains("Error") And dtPer1.Rows.Count > 0) Then
                        Try : NumMesSem = dtPer1.Rows(0).Item("NUM_MES").ToString.Trim : Catch ex As Exception : NumMesSem = "" : End Try
                        Try : Aj_Sub_Sem = Boolean.Parse(dtPer1.Rows(0).Item("aj_sub")) : Catch ex As Exception : Aj_Sub_Sem = False : End Try
                    End If

                    If (Not dtPer2.Columns.Contains("Error") And dtPer2.Rows.Count > 0) Then
                        Try : NumMesCat = dtPer2.Rows(0).Item("NUM_MES").ToString.Trim : Catch ex As Exception : NumMesCat = "" : End Try
                        Try : Aj_Sub_Cat = Boolean.Parse(dtPer1.Rows(0).Item("aj_sub")) : Catch ex As Exception : Aj_Sub_Cat = False : End Try

                        '- Obtener las  fechas inicio y fin del perido catorcenal
                        Try : fIniCat = FechaSQL(dtPer2.Rows(0).Item("fini_nom").ToString.Trim) : Catch ex As Exception : fIniCat = "" : End Try
                        Try : fFinCat = FechaSQL(dtPer2.Rows(0).Item("ffin_nom").ToString.Trim) : Catch ex As Exception : fFinCat = "" : End Try
                    End If
                End If

            End If

        Catch ex As Exception
            Return -1
        End Try
    End Function

    Public Function CalculoNomina(ByRef anio As String, periodo As String, indicProc As String, _filtroNom As String, _reloj As String) As Integer
        Try
            '---Mostrar Progress
            Dim i As Integer = -1
            frmTrabajando.Text = "Calculando nómina"
            frmTrabajando.Avance.IsRunning = True
            frmTrabajando.lblAvance.Text = "Calculando nómina"
            ActivoTrabajando = True
            frmTrabajando.Show()
            Application.DoEvents()

            If (indicProc = "I") Then CargaDatosIniciales() ' Si viene del recalc a un solo empleado, que cargue datos iniciales

            'A--Validar que exista ya un periodo abierto, es decir, que txtAnio y txtPerido no estén vacíos
            If (anio <> "" And periodo <> "") Then

                Dim qNom As String = ""
                If (indicProc = "G") Then qNom = "select * from nomina_pro order by reloj asc" Else If (indicProc = "I") Then qNom = "select * from nomina_pro where reloj='" & _reloj & "'"
                dtNominaPro = sqlExecute(qNom, "NOMINA")
                If ((dtNominaPro.Columns.Contains("Error")) Or (Not dtNominaPro.Columns.Contains("Error") And dtNominaPro.Rows.Count = 0)) Then
                    MessageBox.Show("No existen empleados para procesar su nómina en este periodo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Function
                Else
                    '--- Si sí hay empleados para procesar su nómina, cargamos todas las tablas que nos van a servir para el cálculo de la nomina
                    If indicProc = "G" Then sqlExecute("truncate table movimientos_pro", "NOMINA") 'Limpiamos la tabla movimientos_pro
                    If indicProc = "G" Then sqlExecute("truncate table movimientos_imss_pro", "NOMINA") 'Limpiamos la tabla movimientos_imss_pro
                    If indicProc = "I" Then sqlExecute("delete from movimientos_pro where reloj='" & _reloj & "'", "NOMINA")
                    If indicProc = "I" Then sqlExecute("delete from movimientos_imss_pro where reloj='" & _reloj & "'", "NOMINA")

                    If indicProc = "G" Then dtHorasPro = sqlExecute("SELECT * from horas_pro", "NOMINA") Else If (indicProc = "I") Then dtHorasPro = sqlExecute("SELECT * from horas_pro where reloj='" & _reloj & "'", "NOMINA")
                    If indicProc = "G" Then dtAjustesPro = sqlExecute("SELECT * from ajustes_pro", "NOMINA") Else If (indicProc = "I") Then dtAjustesPro = sqlExecute("SELECT * from ajustes_pro where reloj='" & _reloj & "'", "NOMINA")
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

                    dtDiasHorarioDesc = sqlExecute("SELECT * from dias ", "PERSONAL") '--- AOS 2023-01-04

                    '-- Obtener los tipos de periodo que se están procesando, y saber si aplicará ajuste al subsidio pagado
                    GetTiposPer(filtroNomina)
                    '--Ends

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
                        saldo_tot_fahc = 0.0
                        saldo_tot_fahe = 0.0

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
                        Dim aguiPag As Integer = 0 ' Saber si ya se le pagó aguinaldo en la nom de agui anual ya al empleado 0 = No, 1 = Si

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

                        '--Obtener la antig en años exacta del empleado
                        Try : AntigEmpleado = Antiguedad_Empleado(alta, Date.Parse(fFinSem)) : Catch ex As Exception : AntigEmpleado = 0 : End Try

                        '--Obtener el tope del integrado para IMSS
                        topeIntImss = 25 * UMA
                        If (integrado < topeIntImss) Then topeIntImss = integrado
                        '----------------Ends Vars

                        '-------------Obtener exentos que ya haya tenido durante al año Nota: Solo entran los periodos que si acumulan (TA.dbo.Periodos_acumula = 1)
                        Dim _TaTipoPer As String = ""
                        'If (tipo_periodo = "S") Then _TaTipoPer = "TA.dbo.periodos"
                        'If (tipo_periodo = "C") Then _TaTipoPer = "TA.dbo.periodos_catorcenal"

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
                        '  Dim activo_info As Boolean = False

                        Try : cobro_segv = Boolean.Parse(drNomPro("cobro_segviv")) : Catch ex As Exception : cobro_segv = False : End Try
                        Try : inicio_cred_info = FechaSQL(drNomPro("inicio_credito")) : Catch ex As Exception : inicio_cred_info = "" : End Try
                        Try : no_cred_info = drNomPro("infonavit_credito").ToString.Trim : Catch ex As Exception : no_cred_info = "" : End Try
                        Try : tipo_cred_info = drNomPro("tipo_credito").ToString.Trim : Catch ex As Exception : tipo_cred_info = "" : End Try
                        Try : cuota_cred_info = Double.Parse(drNomPro("cuota_credito")) : Catch ex As Exception : cuota_cred_info = 0.0 : End Try

                        '------------Ends Datos para el INFONAVIT

                        '---Saber si es baja (finiquito) o no del periodo 
                        Dim drEsbaja As DataRow = Nothing
                        Try : drEsbaja = dtAjustesPro.Select("reloj='" & reloj & "' and concepto='ESBAJA'")(0) : Catch ex As Exception : drEsbaja = Nothing : End Try
                        If (Not IsNothing(drEsbaja)) Then esbaja = 1
                        '---ENDS baja o no

                        '----------Obtener el acumulado de la percep gravada en caso de que aplique ajuste al subsidio
                        If (tipo_periodo = "S" And Aj_Sub_Sem) Then
                            Dim QAjS As String = "select ISNULL(SUM(convert(float,monto)),0) AS 'ACUMPERGRA' from movimientos where RELOJ='" & reloj & "' and ANO='" & anio_empl & "' and concepto='PERGRA' and periodo in " & _
                                "(SELECT PERIODO from TA.dbo.periodos where ANO='" & anio_empl & "' and NUM_MES='" & NumMesSem & "' and acumula=1)"
                            Dim dtQAjs As DataTable = sqlExecute(QAjS, "NOMINA")
                            If (Not dtQAjs.Columns.Contains("Error") And dtQAjs.Rows.Count > 0) Then Try : ACUMPERGRA = Double.Parse(dtQAjs.Rows(0).Item("ACUMPERGRA")) : Catch ex As Exception : ACUMPERGRA = 0 : End Try
                        End If

                        If (tipo_periodo = "C" And Aj_Sub_Cat) Then
                            Dim QAjCat As String = "select ISNULL(SUM(convert(float,monto)),0) AS 'ACUMPERGRA' from movimientos where RELOJ='" & reloj & "' and ANO='" & anio_empl & "' and concepto='PERGRA' and periodo in " & _
    "(SELECT PERIODO from TA.dbo.periodos_catorcenal where ANO='" & anio_empl & "' and NUM_MES='" & NumMesCat & "' and acumula=1)"
                            Dim dtQjCat As DataTable = sqlExecute(QAjCat, "NOMINA")
                            If (Not dtQjCat.Columns.Contains("Error") And dtQjCat.Rows.Count > 0) Then Try : ACUMPERGRA = Double.Parse(dtQjCat.Rows(0).Item("ACUMPERGRA")) : Catch ex As Exception : ACUMPERGRA = 0 : End Try
                        End If
                        '----------Ends obtener el acum de PERGRA

                        '---------------Saber si ya se le pagó el agui en la nomina de aguinaldo Anual

                        Try
                            If (dtEmplAguiPag.Select("reloj='" & reloj & "'").Count > 0) Then aguiPag = 1
                        Catch ex As Exception
                        End Try


                        '*****************************************************************Ir dando el valor a cada uno de los conceptos
                        HRSNOR = 0.0
                        HRSEX2 = 0.0
                        BONASI = 0.0
                        DIACAF = 0
                        HRSFES = 0.0
                        HRSEX3 = 0.0
                        HRSDOM = 0.0
                        HRSFEL = 0.0
                        HRSINC = 0.0

                        DIAUNI = 0.0
                        DIASPA = 0.0
                        DIASVA = 0.0
                        DIASPV = 0.0
                        DIASAG = 0.0
                        FNAALC = 0.0
                        LENTES = 0.0
                        PERNOR = 0.0
                        HONASI = 0.0
                        PEREX2 = 0.0
                        PEREX3 = 0.0
                        PEXEXT = 0.0
                        FESLAB = 0.0
                        PRIDOM = 0.0
                        PEXDOM = 0.0
                        PERVAC = 0.0
                        PRIVAC = 0.0
                        PEXVAC = 0.0
                        PERAGI = 0.0
                        PEXAGI = 0.0
                        RETROA = 0.0
                        BONDES = 0.0
                        DESEFE = 0.0
                        BONPRO = 0.0
                        SEPUNI = 0.0
                        PERPTU = 0.0
                        PEXPTU = 0.0
                        OTPGRA = 0.0
                        OTPNOG = 0.0
                        APOFAH = 0.0
                        EXEDFA = 0.0
                        APOCIA = 0.0
                        PEXFAH = 0.0
                        APOFAC = 0.0
                        ISPT = 0.0
                        SUBCAU = 0.0
                        AJSUPE = 0.0
                        DESINF = 0.0
                        SEGVIV = 0.0
                        ADEINF = 0.0
                        IMSS = 0.0
                        CUOCAF = 0.0
                        ANTSUE = 0.0
                        PENALI = 0.0
                        OTRASD = 0.0
                        ABOPMO = 0.0
                        ABOINT = 0.0
                        PERINC = 0.0
                        DIAINC = 0.0
                        DIACVN = 0.0
                        PENAL2 = 0.0
                        PENAL3 = 0.0
                        BONREF = 0.0
                        PREEFI = 0.0
                        PERDES = 0.0
                        SUBINC = 0.0
                        DEVFON = 0.0
                        DEVINF = 0.0

                        SAFAHC = 0.0
                        SAFAHE = 0.0
                        LIFAHC = 0.0
                        LIFAHE = 0.0
                        _diasImss = 0.0


                        For Each dr As DataRow In dtHorasPro.Select("reloj='" & reloj & "'")
                            Dim concepto As String = "", monto As Double = 0.0
                            Try : concepto = dr("concepto").ToString.Trim : Catch ex As Exception : concepto = "" : End Try
                            Try : monto = Double.Parse(dr("monto")) : Catch ex As Exception : concepto = "" : End Try

                            If (concepto = "HRSNOR") Then HRSNOR += monto : GoTo Sig1
                            If (concepto = "HRSEX2") Then HRSEX2 += monto : GoTo Sig1
                            If (concepto = "HRSEX3") Then HRSEX3 += monto : GoTo Sig1
                            If (concepto = "HRSFES") Then HRSFES += monto : GoTo Sig1
                            If (concepto = "BONASI") Then BONASI += monto : GoTo Sig1
                            If (concepto = "DIACAF") Then DIACAF += monto : GoTo Sig1
                            If (concepto = "HRSDOM") Then HRSDOM += monto : GoTo Sig1
                            If (concepto = "HRSFEL") Then HRSFEL += monto : GoTo Sig1
                            If (concepto = "DIASVA") Then DIASVA += monto : GoTo Sig1
                            If (concepto = "DIASPV") Then DIASPV += monto : GoTo Sig1
                            If (concepto = "DIASAG") Then DIASAG += monto : GoTo Sig1
                            If (concepto = "DIAUNI") Then DIAUNI += monto : GoTo Sig1
                            If (concepto = "DIASPA") Then DIASPA += monto : GoTo Sig1
                            If (concepto = "HRSINC") Then HRSINC += monto : GoTo Sig1
                            If (concepto = "DIAINC") Then DIAINC += monto : GoTo Sig1
                            If (concepto = "DIACVN") Then DIACVN += monto : GoTo Sig1
Sig1:
                            '       If (monto <> 0) Then puente(anio_empl, per_empl, reloj, monto, tipo_nomina, tipo_periodo, concepto, dtConceptos)
                        Next

                        For Each dr2 As DataRow In dtAjustesPro.Select("reloj='" & reloj & "'")
                            Dim concepto As String = "", monto As Double = 0.0
                            Try : concepto = dr2("concepto").ToString.Trim : Catch ex As Exception : concepto = "" : End Try
                            Try : monto = Double.Parse(dr2("monto")) : Catch ex As Exception : concepto = "" : End Try

                            If (concepto = "DIASVA") Then DIASVA += monto : GoTo Sig2
                            If (concepto = "DIASPV") Then DIASPV += monto : GoTo Sig2
                            If (concepto = "DIASAG") Then DIASAG += monto : GoTo Sig2
                            If (concepto = "DIAUNI") Then DIAUNI += monto : GoTo Sig2
                            If (concepto = "FNAALC") Then FNAALC += monto : GoTo Sig2
                            If (concepto = "LENTES") Then LENTES += monto : GoTo Sig2
                            If (concepto = "PERNOR") Then PERNOR += monto : GoTo Sig2
                            If (concepto = "HONASI") Then HONASI += monto : GoTo Sig2
                            If (concepto = "BONASI") Then BONASI += monto : GoTo Sig2
                            If (concepto = "PEREX2") Then PEREX2 += monto : GoTo Sig2
                            If (concepto = "PEREX3") Then PEREX3 += monto : GoTo Sig2
                            If (concepto = "PERDES") Then PERDES += monto : GoTo Sig2
                            If (concepto = "SUBINC") Then SUBINC += monto : GoTo Sig2
                            If (concepto = "DEVFON") Then DEVFON += monto : GoTo Sig2
                            If (concepto = "DEVINF") Then DEVINF += monto : GoTo Sig2
                            If (concepto = "PEXEXT") Then PEXEXT += monto : GoTo Sig2
                            If (concepto = "FESLAB") Then FESLAB += monto : GoTo Sig2
                            If (concepto = "PRIDOM") Then PRIDOM += monto : GoTo Sig2
                            If (concepto = "PEXDOM") Then PEXDOM += monto : GoTo Sig2
                            If (concepto = "PERVAC") Then PERVAC += monto : GoTo Sig2
                            If (concepto = "PRIVAC") Then PRIVAC += monto : GoTo Sig2
                            If (concepto = "PEXVAC") Then PEXVAC += monto : GoTo Sig2
                            If (concepto = "PERAGI") Then PERAGI += monto : GoTo Sig2
                            If (concepto = "PEXAGI") Then PEXAGI += monto : GoTo Sig2
                            If (concepto = "DIASPA") Then DIASPA += monto : GoTo Sig2
                            If (concepto = "RETROA") Then RETROA += monto : GoTo Sig2
                            If (concepto = "BONDES") Then BONDES += monto : GoTo Sig2
                            If (concepto = "DESEFE") Then DESEFE += monto : GoTo Sig2
                            If (concepto = "BONPRO") Then BONPRO += monto : GoTo Sig2
                            If (concepto = "SEPUNI") Then SEPUNI += monto : GoTo Sig2
                            If (concepto = "PERPTU") Then PERPTU += monto : GoTo Sig2
                            If (concepto = "PEXPTU") Then PEXPTU += monto : GoTo Sig2
                            If (concepto = "OTPGRA") Then OTPGRA += monto : GoTo Sig2
                            If (concepto = "OTPNOG") Then OTPNOG += monto : GoTo Sig2
                            If (concepto = "APOFAH") Then APOFAH += monto : GoTo Sig2
                            If (concepto = "EXEDFA") Then EXEDFA += monto : GoTo Sig2
                            If (concepto = "APOCIA") Then APOCIA += monto : GoTo Sig2
                            If (concepto = "PEXFAH") Then PEXFAH += monto : GoTo Sig2
                            If (concepto = "APOFAC") Then APOFAC += monto : GoTo Sig2
                            If (concepto = "ISPT") Then ISPT += monto : GoTo Sig2
                            If (concepto = "SUBCAU") Then SUBCAU += monto : GoTo Sig2
                            If (concepto = "AJSUPE") Then AJSUPE += monto : GoTo Sig2
                            If (concepto = "DESINF") Then DESINF += monto : GoTo Sig2
                            If (concepto = "SEGVIV") Then SEGVIV += monto : GoTo Sig2
                            If (concepto = "ADEINF") Then ADEINF += monto : GoTo Sig2
                            If (concepto = "IMSS") Then IMSS += monto : GoTo Sig2
                            If (concepto = "CUOCAF") Then CUOCAF += monto : GoTo Sig2
                            If (concepto = "ANTSUE") Then ANTSUE += monto : GoTo Sig2
                            If (concepto = "PENALI") Then PENALI += monto : GoTo Sig2
                            If (concepto = "OTRASD") Then OTRASD += monto : GoTo Sig2
                            If (concepto = "ABOPMO") Then ABOPMO += monto : GoTo Sig2
                            If (concepto = "ABOINT") Then ABOINT += monto : GoTo Sig2
                            If (concepto = "DIAINC") Then DIAINC += monto : GoTo Sig2
                            If (concepto = "DIACVN") Then DIACVN += monto : GoTo Sig2
                            If (concepto = "PENAL2") Then PENAL2 += monto : GoTo Sig2
                            If (concepto = "PENAL3") Then PENAL3 += monto : GoTo Sig2
                            If (concepto = "SAFAHC") Then SAFAHC += monto : GoTo Sig2
                            If (concepto = "SAFAHE") Then SAFAHE += monto : GoTo Sig2
                            If (concepto = "LIFAHC") Then SAFAHE += monto : GoTo Sig2
                            If (concepto = "LIFAHE") Then SAFAHE += monto : GoTo Sig2
                            If (concepto = "BONREF") Then BONREF += monto : GoTo Sig2
                            If (concepto = "PREEFI") Then PREEFI += monto : GoTo Sig2
Sig2:
                        Next

                        '***************************Obtener datos de pensiones Alimenticias

                        '--Vars para Pensiones Alimenticias
                        Dim pensAlim1 As String = ""
                        Dim porcPens1 As Double = 0.0
                        Dim pensAlim2 As String = ""
                        Dim porcPens2 As Double = 0.0
                        Dim pensAlim3 As String = ""
                        Dim porcPens3 As Double = 0.0

                        Dim cfPens1 As Double = 0.0, cfPens2 As Double = 0.0, cfPens3 As Double = 0.0


                        For Each drPens As DataRow In dtPensAlim.Select("reloj='" & reloj & "'")
                            Dim _noPens As String = "", _PorcPens As Double = 0.0, _CFijaPens As Double = 0.0

                            Try : _noPens = drPens("pension").ToString.Trim : Catch ex As Exception : _noPens = "" : End Try
                            Try : _PorcPens = Double.Parse(drPens("porc")) : Catch ex As Exception : _PorcPens = 0.0 : End Try
                            Try : _CFijaPens = Double.Parse(drPens("cf")) : Catch ex As Exception : _CFijaPens = 0.0 : End Try

                            If (_PorcPens > 0) Then
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
                            End If

                            If (_CFijaPens > 0) Then
                                Select Case _noPens
                                    Case "1"
                                        pensAlim1 = "1"
                                        cfPens1 = _CFijaPens
                                    Case "2"
                                        pensAlim2 = "2"
                                        cfPens2 = _CFijaPens
                                    Case "3"
                                        pensAlim3 = "3"
                                        cfPens3 = _CFijaPens
                                End Select
                            End If


                        Next

                        '*******************************Validar altas dentro del periodo actual
                        ' Nota: Si por ejemplo las fecha del periodo son del 24/08 al 30/08 y una alta cae entre esos días, se refiere a que es una alta entre periodo
                        '- Para las altas si entra el primer dia, el pago de días es por el total de dias que restan, lo contrario a las bajas que hay que restarle los dias
                        Dim DEntrePer As Integer = 0 '- Días entre periodo
                        Dim DToca As Integer = 0 ' Días que le tocan a pagar
                        Dim AltaEntrePer As Boolean = False  ' Var bool que indica si es un alta entre periodo
                        Dim BajaEntrePer As Boolean = False ' Var bool que indica si es una baja entre del periodo
                        Dim _altad As Date = Convert.ToDateTime(alta)
                        Dim _ffinPerS As Date = Date.Parse(fFinSem)
                        Dim _ffinPerCat As Date

                        If (tipo_periodo = "S") Then
                            DEntrePer = (DateDiff(DateInterval.Day, _altad, _ffinPerS) + 1) - 2
                            If (DEntrePer >= 1 And DEntrePer <= 5) Then
                                DToca = DEntrePer
                                AltaEntrePer = True
                            End If

                        End If

                        If (tipo_periodo = "C") Then
                            Try : _ffinPerCat = Date.Parse(fFinCat) : Catch ex As Exception : _ffinPerCat = Nothing : End Try
                            DEntrePer = (DateDiff(DateInterval.Day, _altad, _ffinPerCat) + 1) - 2
                            If (DEntrePer >= 1 And DEntrePer <= 12) Then
                                DToca = DEntrePer
                                AltaEntrePer = True
                            End If

                        End If

                        '*********************************Validar bajas dentro del periodo actual para su finiquito
                        'NOTA: Si por ejemplo la fecha fin del periodo es del 27/09, al viernes es 25/09, y si su baja es el 21/09 (Primer dia) los dias que le tocan es 1 día en ese caso
                        If (baja <> "") Then
                            esbaja = True
                            Dim _bajaD As Date = Convert.ToDateTime(baja)
                            If (tipo_periodo = "S") Then
                                DEntrePer = (DateDiff(DateInterval.Day, _bajaD, _ffinPerS) + 1) - 2
                                If (DEntrePer >= 1 And DEntrePer <= 5) Then
                                    DToca = 6 - DEntrePer
                                    BajaEntrePer = True
                                End If

                            End If

                            If (tipo_periodo = "C") Then
                                Try : _ffinPerCat = Date.Parse(fFinCat) : Catch ex As Exception : _ffinPerCat = Nothing : End Try
                                DEntrePer = (DateDiff(DateInterval.Day, _bajaD, _ffinPerCat) + 1) - 2
                                If (DEntrePer >= 1 And DEntrePer <= 12) Then
                                    DToca = 13 - DEntrePer
                                    BajaEntrePer = True
                                End If

                            End If

                        End If


                        ' '************************HRSNOR 

                        If (cod_puesto = "00094") Then
                            HRSNOR = 25 ' Se deja fijo las 25 para los pract
                            horas_turno = 25
                            sqlExecute("delete from horas_pro where reloj='" & reloj & "' and concepto='HRSNOR'", "nomina")
                            sqlExecute("insert into horas_pro (ano,periodo,reloj,concepto,descripcion,monto,usuario,fec_hora_registro) VALUES " & _
                             "('" & anio_empl & "','" & per_empl & "','" & reloj & "','HRSNOR','Horas normales'," & HRSNOR & ",'" & Usuario & "',GETDATE())", "nomina")
                            GoTo insertaHoras
                        End If

                        If ((AltaEntrePer Or BajaEntrePer)) Then
                            Dim dtPrimerCalc As DataTable = sqlExecute("select * from primer_calc where reloj='" & reloj & "' and concepto='HRSNOR'", "NOMINA")
                            If (Not dtPrimerCalc.Columns.Contains("Error") And dtPrimerCalc.Rows.Count <= 0) Then
                                HRSNOR = Math.Round((horas_turno / 5) * DToca, 2)
                                sqlExecute("insert into primer_calc values ('" & reloj & "','HRSNOR')", "NOMINA")
                                sqlExecute("delete from horas_pro where reloj='" & reloj & "' and concepto='HRSNOR'", "nomina")
                                sqlExecute("insert into horas_pro (ano,periodo,reloj,concepto,descripcion,monto,usuario,fec_hora_registro) VALUES " & _
                                 "('" & anio_empl & "','" & per_empl & "','" & reloj & "','HRSNOR','Horas normales'," & HRSNOR & ",'" & Usuario & "',GETDATE())", "nomina")
                            End If
                        End If

insertaHoras:
                        '--insertar en movimientos_pro
                        If (HRSNOR <> 0) Then puente(anio_empl, per_empl, reloj, HRSNOR, tipo_nomina, tipo_periodo, "HRSNOR", dtConceptos)

                        '**************************HRSINC -- Horas de incapacidad
                        If (HRSINC <> 0) Then puente(anio_empl, per_empl, reloj, HRSINC, tipo_nomina, tipo_periodo, "HRSINC", dtConceptos)

                        '**************************DIAINC ---- Días de incapacidad
                        If (DIAINC <> 0) Then puente(anio_empl, per_empl, reloj, DIAINC, tipo_nomina, tipo_periodo, "DIAINC", dtConceptos)

                        '**************************DIACVN ---- Días de convenio
                        If (DIACVN <> 0) Then puente(anio_empl, per_empl, reloj, DIACVN, tipo_nomina, tipo_periodo, "DIACVN", dtConceptos)

                        '****************************************DIACAF - Dias para desc de cafetería :: Van a venir en cant de días desde el TA
                        '--insertar en movimientos_pro
                        If (DIACAF <> 0) Then puente(anio_empl, per_empl, reloj, DIACAF, tipo_nomina, tipo_periodo, "DIACAF", dtConceptos)

                        '***********************HRSFES

                        '--insertar en movimientos_pro
                        If (HRSFES <> 0) Then puente(anio_empl, per_empl, reloj, HRSFES, tipo_nomina, tipo_periodo, "HRSFES", dtConceptos)

                        '********************** HRSEX2
                        '--insertar en movimientos_pro
                        If (HRSEX2 <> 0) Then puente(anio_empl, per_empl, reloj, HRSEX2, tipo_nomina, tipo_periodo, "HRSEX2", dtConceptos)


                        '********************** HRSEX3
                        '--insertar en movimientos_pro
                        If (HRSEX3 <> 0) Then puente(anio_empl, per_empl, reloj, HRSEX3, tipo_nomina, tipo_periodo, "HRSEX3", dtConceptos)

                        '**********************HRSDOM -- Horas domingo
                        '--insertar en movimientos_pro
                        If (HRSDOM <> 0) Then puente(anio_empl, per_empl, reloj, HRSDOM, tipo_nomina, tipo_periodo, "HRSDOM", dtConceptos)


                        ' ****************************************HRSFEL -- Horas festivas laboradas
                        '--insertar en movimientos_pro
                        If (HRSFEL <> 0) Then puente(anio_empl, per_empl, reloj, HRSFEL, tipo_nomina, tipo_periodo, "HRSFEL", dtConceptos)

                        '**********************DIASVA -- Días de vacaciones
                        '--insertar en movimientos_pro
                        If (DIASVA <> 0) Then puente(anio_empl, per_empl, reloj, DIASVA, tipo_nomina, tipo_periodo, "DIASVA", dtConceptos)

                        '**********************DIASPV -- Días de prima vacacional

                        If (privac_dias_aniv <> 0.0) Then DIASPV = DIASPV + privac_dias_aniv ' Si es el aniv del empleado, los dias de prima son los que vienen en Nomina_pro
                        If (privac_porc_aniv <> 0.0) Then privac_porc_aniv = privac_porc_aniv / 100
                        If (privac_porc_aniv = 0.0) Then privac_porc_aniv = 0.25 ' Si no trae valor el porc por aniv, se deja por default el 0.25

                        '--insertar en movimientos_pro
                        If (DIASPV <> 0) Then puente(anio_empl, per_empl, reloj, DIASPV, tipo_nomina, tipo_periodo, "DIASPV", dtConceptos)

                        '**********************DIASAG -- Días de aguinaldo
                        If (aguiPag = 1) Then DIASAG = 0.0
                        '--insertar en movimientos_pro
                        If (DIASAG <> 0) Then puente(anio_empl, per_empl, reloj, DIASAG, tipo_nomina, tipo_periodo, "DIASAG", dtConceptos)

                        '***********************DIAUNI -- Días para pago de separación única
                        '--insertar en movimientos_pro
                        If (DIAUNI <> 0) Then puente(anio_empl, per_empl, reloj, DIAUNI, tipo_nomina, tipo_periodo, "DIAUNI", dtConceptos)


                        '**********************PERNOR - CALCULO DE LA PERCEPCION NORMAL

                        '  PERNOR = ((sactual * 7) / horas_turno) * HRSNOR '&&_ Original de antes
                        Dim normal As Double = 0.0
                        Dim _sepdia As Double = 0.0
                        normal = ((sactual * 6) / horas_turno) * HRSNOR
                        _sepdia = normal * 0.16667

                        If (cod_puesto = "00094") Then HONASI = HONASI + normal + _sepdia Else PERNOR = PERNOR + normal + _sepdia



                        '--- Si es finiq no calcular el 1.4
                        '**********************PERVAC - CALCULO DE PERCEPCION DE VACACIONES
                        If (esbaja) Then ' Si es baja que no le sume el 1.4 a la pernor
                            PERVAC = PERVAC + (DIASVA * sactual)
                        Else

                            '--Saber si su horario es de 6 dias
                            Dim item = (From x In dtDiasHorarioDesc.Rows Where x("cod_hora").ToString.Trim = cod_hora And x("DESCANSO").ToString.Trim = "False").ToList
                            If (item.Count >= 6) And tipo_periodo = "S" And DIASVA > 0 Then ' Si los dias de trabajo son 6
                                PERVAC = PERVAC + (DIASVA * sactual)
                                PERNOR = PERNOR + Math.Round((sactual / 6 * DIASVA), 2)
                            Else
                                '---Si no es baja, que si sume el 1.4 proporcial a la pernor
                                Dim _pervacFic As Double = PERVAC + (DIASVA * sactual * 1.4) ' Obtener el total con el 1.4 que es ficticiio
                                PERVAC = PERVAC + (DIASVA * sactual)
                                Dim DifVac As Double = _pervacFic - PERVAC
                                If (cod_puesto = "00094") Then HONASI = HONASI + DifVac Else PERNOR = PERNOR + DifVac ' Sumarle a la PERNOR esa diferencia del 1.4 para no afectar a PERVAC
                            End If

                        End If

                        '--- AOS: 21/04/2021 - Si los días pagados son mayores a 7 Entonces minimizar la PERNOR
                        If (tipo_periodo = "S" And cod_puesto <> "00094") Then
                            Dim diasPag As Double = 0.0
                            diasPag = DIASPA + (Math.Round((PERNOR + SEPDIA + PERFES + PERVAC) / sactual, 2))
                            If (diasPag > 7) Then PERNOR = Math.Round((sactual * 7) - SEPDIA - PERFES - PERVAC, 2)
                        End If

                        If (tipo_periodo = "S" And cod_puesto = "00094") Then
                            Dim diasPag As Double = 0.0
                            diasPag = DIASPA + (Math.Round((HONASI + SEPDIA + PERFES + PERVAC) / sactual, 2))
                            If (diasPag > 7) Then HONASI = Math.Round((sactual * 7) - SEPDIA - PERFES - PERVAC, 2)
                        End If

                        '-- insertar en movimientos_pro
                        If (PERNOR <> 0) Then puente(anio_empl, per_empl, reloj, PERNOR, tipo_nomina, tipo_periodo, "PERNOR", dtConceptos)
                        If (HONASI <> 0) Then puente(anio_empl, per_empl, reloj, HONASI, tipo_nomina, tipo_periodo, "HONASI", dtConceptos)
                        If (PERVAC <> 0) Then puente(anio_empl, per_empl, reloj, PERVAC, tipo_nomina, tipo_periodo, "PERVAC", dtConceptos)

                        If (cod_puesto = "00094") Then GoTo calcPEREX

                        '***********************PERINC - Percepción por incapacidad (Esta solo es ficticia y no afecta al neto ni al total)
                        '2 diasIncap *  sactual * 1.16667 = 637.97 --> base para calc bono despensa, que es la parte de Incap o Convenio
                        'Dim normal_inc As Double = 0.0
                        'Dim sepdia_inc As Double = 0.0
                        'normal_inc = ((sactual * 6) / horas_turno) * HRSINC
                        'sepdia_inc = normal_inc * 0.16667
                        ' PERINC = normal_inc + sepdia_inc
                        Dim TotDiasInci As Double = DIAINC + DIACVN
                        PERINC = TotDiasInci * sactual * 1.16667
                        If (PERINC <> 0) Then puente(anio_empl, per_empl, reloj, PERINC, tipo_nomina, tipo_periodo, "PERINC", dtConceptos)


calcPEREX:

                        '*******************************SUBINC ---- Subsidio por Incapacidad
                        If (SUBINC <> 0) Then puente(anio_empl, per_empl, reloj, SUBINC, tipo_nomina, tipo_periodo, "SUBINC", dtConceptos)

                        '*******************************DEVINF ----Devolucion de infonavit
                        acum_exento = acum_exento + DEVINF
                        If (DEVINF <> 0) Then puente(anio_empl, per_empl, reloj, DEVINF, tipo_nomina, tipo_periodo, "DEVINF", dtConceptos)


                        '*******************************DEVFON ----Devolucion de Fonacot
                        If (DEVFON <> 0) Then puente(anio_empl, per_empl, reloj, DEVFON, tipo_nomina, tipo_periodo, "DEVFON", dtConceptos)

                        '******************************PERDES ---- Percepción festiva
                        Dim _perdes As Double = 0.0
                        _perdes = (((sactual * 6) / horas_turno) * HRSFES) * 0.16667
                        PERDES = PERDES + _perdes

                        If (PERDES <> 0) Then puente(anio_empl, per_empl, reloj, PERDES, tipo_nomina, tipo_periodo, "PERDES", dtConceptos)

                        '**********************PEREX2 - CALCULO DE LA PERCEPCION DOBLE

                        PEREX2 = PEREX2 + (HRSEX2 * 2 * costo_x_hora)

                        '-- insertar en movimientos_pro
                        If (PEREX2 <> 0) Then puente(anio_empl, per_empl, reloj, PEREX2, tipo_nomina, tipo_periodo, "PEREX2", dtConceptos)

                        '**********************PEREX3 - CALCULO DE LA PERCEPCION TRIPLE

                        PEREX3 = PEREX3 + (HRSEX3 * 3 * costo_x_hora)
                        '-- insertar en movimientos_pro
                        If (PEREX3 <> 0) Then puente(anio_empl, per_empl, reloj, PEREX3, tipo_nomina, tipo_periodo, "PEREX3", dtConceptos)

                        '**********************PEXEXT - Percepcion exenta del tiempo extra 

                        Dim topeExeTExtra As Double = 5 * UMA
                        Dim MitadPerEx2 As Double = PEREX2 / 2
                        If (sactual <= SALMIN) Then
                            PEXEXT += PEREX2
                        Else
                            If (MitadPerEx2 >= topeExeTExtra) Then PEXEXT += topeExeTExtra
                            If (MitadPerEx2 < topeExeTExtra) Then PEXEXT += MitadPerEx2
                        End If

                        acum_exento = acum_exento + PEXEXT
                        '-- insertar en movimientos_pro
                        If (PEXEXT <> 0) Then puente(anio_empl, per_empl, reloj, PEXEXT, tipo_nomina, tipo_periodo, "PEXEXT", dtConceptos)


                        '*************************************************FESLAB -- Percepción de Festivo laborado

                        FESLAB = FESLAB + (HRSFEL * 2 * costo_x_hora) ' NOTA: Es por el costo_x_hora ??
                        '-- insertar en movimientos_pro
                        If (FESLAB <> 0) Then puente(anio_empl, per_empl, reloj, FESLAB, tipo_nomina, tipo_periodo, "FESLAB", dtConceptos)

                        If (cod_puesto = "00094") Then GoTo calcAsim1
                        '**********************PRIDOM - CALCULO DE PRIMA DOMINICAL

                        If (tipo_periodo = "C") Then HRSDOM = 0.0 '-- La prima dominical no aplica para los 14nales

                        If (HRSDOM > 0) Then PRIDOM = PRIDOM + (sactual * 0.25)

                        '-- insertar en movimientos_pro
                        If (PRIDOM <> 0) Then puente(anio_empl, per_empl, reloj, PRIDOM, tipo_nomina, tipo_periodo, "PRIDOM", dtConceptos)

                        '**********************PEXDOM - Exento de prima dominical

                        Dim TopeExPrimDom As Double = 1 * UMA
                        If (PRIDOM >= TopeExPrimDom) Then PEXDOM += TopeExPrimDom
                        If (PRIDOM < TopeExPrimDom) Then PEXDOM += PRIDOM
                        acum_exento = acum_exento + PEXDOM

                        '-- insertar en movimientos_pro
                        If (PEXDOM <> 0) Then puente(anio_empl, per_empl, reloj, PEXDOM, tipo_nomina, tipo_periodo, "PEXDOM", dtConceptos)


                        '**********************PRIVAC - CALCULO DE PERCEPCION DE PRIMA VACACIONAL

                        PRIVAC = PRIVAC + (DIASPV * sactual * privac_porc_aniv)

                        '-- insertar en movimientos_pro
                        If (PRIVAC <> 0) Then puente(anio_empl, per_empl, reloj, PRIVAC, tipo_nomina, tipo_periodo, "PRIVAC", dtConceptos)

                        '**********************PEXVAC - CALCULO EXENTO DE LA PRIMA VACACIONAL

                        Dim TopeExePriVac As Double = 15 * UMA
                        TopeExePriVac = TopeExePriVac - acumExeAnioPVac ' Se le resta el exento  que haya tenido ya en el año pagado
                        If (TopeExePriVac <= 0) Then TopeExePriVac = 0
                        If (PRIVAC >= TopeExePriVac) Then PEXVAC += TopeExePriVac
                        If (PRIVAC < TopeExePriVac) Then PEXVAC += PRIVAC
                        acum_exento = acum_exento + PEXVAC

                        '-- insertar en movimientos_pro
                        If (PEXVAC <> 0) Then puente(anio_empl, per_empl, reloj, PEXVAC, tipo_nomina, tipo_periodo, "PEXVAC", dtConceptos)


                        '**********************PERAGI - CALCULO DE PERCEPCION DE AGUINALDO

                        PERAGI = PERAGI + (DIASAG * sactual)
                        'NOTA: Aplicaria que tampoco add aguinaldo manualmente?    If (PERAGI = 1) Then PERAGI = 0.0
                        '-- insertar en movimientos_pro
                        If (PERAGI <> 0) Then puente(anio_empl, per_empl, reloj, PERAGI, tipo_nomina, tipo_periodo, "PERAGI", dtConceptos)


                        '********************** PEXAGI - CALCULO EXENTO  DEL AGUINALDO

                        Dim TopeExeAgui As Double = 30 * UMA
                        TopeExeAgui = TopeExeAgui - acumExeAnioAgui  ' Se le resta el exento que haya tenido en el anio
                        If (TopeExeAgui <= 0) Then TopeExeAgui = 0
                        If (PERAGI >= TopeExeAgui) Then PEXAGI += TopeExeAgui
                        If (PERAGI < TopeExeAgui) Then PEXAGI += PERAGI
                        acum_exento = acum_exento + PEXAGI

                        '-- insertar en movimientos_pro
                        If (PEXAGI <> 0) Then puente(anio_empl, per_empl, reloj, PEXAGI, tipo_nomina, tipo_periodo, "PEXAGI", dtConceptos)

                        '********************** DIASPA - DIAS PAGADOS
calcAsim1:
                        If (cod_puesto = "00094") Then
                            DIASPA = DIASPA + (Math.Round((HONASI + SEPDIA + PERFES + PERVAC) / sactual, 2))
                        Else
                            DIASPA = DIASPA + (Math.Round((PERNOR + SEPDIA + PERFES + PERVAC) / sactual, 2))
                        End If

                        '---Cuando sean finiquitos, no tomar en cuenta el PERVAC
                        '-- insertar en movimientos_pro
                        If (DIASPA <> 0) Then puente(anio_empl, per_empl, reloj, DIASPA, tipo_nomina, tipo_periodo, "DIASPA", dtConceptos)

                        If (cod_puesto = "00094") Then GoTo calcAsim2

                        '********************** RETROA - CALCULO DEL RETROACTIVO

                        '-- insertar en movimientos_pro
                        If (RETROA <> 0) Then puente(anio_empl, per_empl, reloj, RETROA, tipo_nomina, tipo_periodo, "RETROA", dtConceptos)

                        '**********************BONASI - Bono de asistencia  :: Viene calculado desde el TA
                        If (tipo_periodo = "S" And AltaEntrePer) Then
                            BONASI = 100.0
                        End If
                        If (tipo_periodo = "C") Then BONASI = 0.0
                        '-- insertar en movimientos_pro
                        If (BONASI <> 0) Then puente(anio_empl, per_empl, reloj, BONASI, tipo_nomina, tipo_periodo, "BONASI", dtConceptos)

                        '**********************BONDES - Bono de despensa - No suma al neto y está como en ESPECIE
                        Dim topeBondes As Double = 0.0 'Tope del bondes:
                        Dim difTopeBondes As Double = 0.0 ' Diferencia de lo topado
                        '-- Sacar los dias de Incidencia
                        Dim DIASINC As Double = 0.0
                        Dim DiasTope As Double = 0.0
                        DIASINC = (Math.Round((PERINC) / sactual, 2))
                        DiasTope = DIASPA + DIASINC
                        If (DiasTope >= 7 And tipo_periodo = "S") Then DiasTope = 7
                        If (DiasTope >= 14 And tipo_periodo = "C") Then DiasTope = 14
                        '-- Ends
                        topeBondes = DiasTope * UMA

                        If (esbaja = 0) Then
                            BONDES = BONDES + ((PERNOR + PERINC + RETROA + SEPDIA + PERFES + PERVAC) * 0.1)
                        Else ' Si es un finiquito
                            BONDES = BONDES + ((PERNOR + PERINC + RETROA + SEPDIA + PERFES) * 0.1)
                        End If

                        If (BONDES >= topeBondes) Then
                            difTopeBondes = BONDES - topeBondes
                            BONDES = topeBondes
                        End If

                        '-- insertar en movimientos_pro
                        If (BONDES <> 0) Then puente(anio_empl, per_empl, reloj, BONDES, tipo_nomina, tipo_periodo, "BONDES", dtConceptos)


                        '**********************-DESEFE - Bono de despensa pagado en Efectivo
                        DESEFE += difTopeBondes

                        If (tipo_periodo = "C" And cod_tipo <> "G") Then DESEFE = 0

                        If (tipo_periodo = "S") Then DESEFE = 0

                        '-- insertar en movimientos_pro
                        If (DESEFE <> 0) Then puente(anio_empl, per_empl, reloj, DESEFE, tipo_nomina, tipo_periodo, "DESEFE", dtConceptos)

                        '**********************BONPRO - BONO DE PRODUCTIVIDAD
                        '-- insertar en movimientos_pro
                        If (BONPRO <> 0) Then puente(anio_empl, per_empl, reloj, BONPRO, tipo_nomina, tipo_periodo, "BONPRO", dtConceptos)

                        '**********************SEPUNI - Separación única

                        SEPUNI = SEPUNI + (DIAUNI * sactual)
                        '-- insertar en movimientos_pro
                        If (SEPUNI <> 0) Then puente(anio_empl, per_empl, reloj, SEPUNI, tipo_nomina, tipo_periodo, "SEPUNI", dtConceptos)

                        '**********************PERPTU - CALCULO DEL PTU O UTILIDADES (PENDIENTE El calculo del PTU)
                        '-- insertar en movimientos_pro
                        If (PERPTU <> 0) Then puente(anio_empl, per_empl, reloj, PERPTU, tipo_nomina, tipo_periodo, "PERPTU", dtConceptos)


                        '**********************PEXPTU (Pendiente de obtener el exento del PTU)
                        '-- insertar en movimientos_pro
                        If (PEXPTU <> 0) Then puente(anio_empl, per_empl, reloj, PEXPTU, tipo_nomina, tipo_periodo, "PEXPTU", dtConceptos)

                        '**********************OTPGRA - Otras percepcones gravadas
                        If (OTPGRA <> 0) Then puente(anio_empl, per_empl, reloj, OTPGRA, tipo_nomina, tipo_periodo, "OTPGRA", dtConceptos)

                        '**********************OTPNOG - Otras percepciones No gravadas

                        acum_exento = acum_exento + OTPNOG

                        '-- insertar en movimientos_pro
                        If (OTPNOG <> 0) Then puente(anio_empl, per_empl, reloj, OTPNOG, tipo_nomina, tipo_periodo, "OTPNOG", dtConceptos)

                        '**********************APOFAH (DEDUC) - CALCULO DE LA APORTACION DE FONDO DE AHORRO del empleado

                        Dim baseFah As Double = 0.0
                        Dim diasFah As Double = 0.0
                        Dim topeFah As Double = 0.0
                        Dim ExedeFah As Double = 0.0
                        If (esbaja = 0) Then baseFah = ((PERNOR + PERFES + RETROA + SEPDIA + PERVAC) * (13 / 100)) Else baseFah = ((PERNOR + RETROA + PERFES + SEPDIA) * (13 / 100)) ' Si son finiquitos (esbaja=1) no aplica sumar PERVAC
                        diasFah = baseFah / sactual
                        topeFah = diasFah * UMA * 10
                        If (baseFah > topeFah) Then ' Solo si lo que aportó de FAH exede al tope
                            ExedeFah = baseFah - topeFah
                            APOFAH += topeFah
                        Else
                            ExedeFah = 0
                            APOFAH += baseFah
                        End If

                        If (Not aplDescFah) Then APOFAH = 0.0 ' Si no es periodo de desc para Saldos de Fondo de ahorro, no aplica

                        '-- insertar en movimientos_pro
                        If (APOFAH <> 0) Then puente(anio_empl, per_empl, reloj, APOFAH, tipo_nomina, tipo_periodo, "APOFAH", dtConceptos)


                        '********************** EXEDFA (PERCEP) - Exedente de fondo de ahorro (Nota: Esta es una percepción que se le paga al empleado por el exedente que no alcanzó a dar por el tope del FAH)

                        EXEDFA += ExedeFah

                        If (tipo_periodo = "C" And cod_tipo <> "G") Then EXEDFA = 0

                        '-- insertar en movimientos_pro
                        If (EXEDFA <> 0) Then puente(anio_empl, per_empl, reloj, EXEDFA, tipo_nomina, tipo_periodo, "EXEDFA", dtConceptos)

                        '********************** APOCIA (PERCEP) - Aportacion FAH Empresa, y es lo mismo que APOFAH (Deduc)

                        APOCIA += APOFAH

                        '-- insertar en movimientos_pro
                        If (APOCIA <> 0) Then puente(anio_empl, per_empl, reloj, APOCIA, tipo_nomina, tipo_periodo, "APOCIA", dtConceptos)

                        '************************ SAFAHC Y SAFAHE  -- Saldos del fondo de ahorro
                        '-- Buscar el saldo del fondo de ahorro  y Guardarlo en base al periodo semanal
                        GetSaldosFah(anio_empl, num_per_sem, reloj, APOCIA)

                        SAFAHC = saldo_tot_fahc
                        SAFAHE = saldo_tot_fahe


                        If (SAFAHC <> 0) Then puente(anio_empl, per_empl, reloj, SAFAHC, tipo_nomina, tipo_periodo, "SAFAHC", dtConceptos)
                        If (SAFAHE <> 0) Then puente(anio_empl, per_empl, reloj, SAFAHE, tipo_nomina, tipo_periodo, "SAFAHE", dtConceptos)

                        '************************LIFAHC Y LIFAHE (Liquidacion de saldo de fondo de ahorro)
                        '--NOTA (Solo aplica para las bajas)
                        If (esbaja) Then
                            LIFAHC = LIFAHC + saldo_tot_fahc
                            LIFAHE = LIFAHE + saldo_tot_fahe
                        End If

                        acum_exento = acum_exento + LIFAHC + LIFAHE

                        If (LIFAHC <> 0) Then puente(anio_empl, per_empl, reloj, LIFAHC, tipo_nomina, tipo_periodo, "LIFAHC", dtConceptos)
                        If (LIFAHE <> 0) Then puente(anio_empl, per_empl, reloj, LIFAHE, tipo_nomina, tipo_periodo, "LIFAHE", dtConceptos)

                        '*********************** PEXFAH (Exento de APOCIA: Solo como Informativo, y es todo el importe de APOCIA) 

                        PEXFAH += APOCIA
                        acum_exento = acum_exento + PEXFAH
                        '-- insertar en movimientos_pro
                        If (PEXFAH <> 0) Then puente(anio_empl, per_empl, reloj, PEXFAH, tipo_nomina, tipo_periodo, "PEXFAH", dtConceptos)

                        '***********************APOFAC (Deduc) - Fondo de ahorro Empresa y es lo mismo que APOFAH(deduc)

                        APOFAC += APOFAH
                        '-- insertar en movimientos_pro
                        If (APOFAC <> 0) Then puente(anio_empl, per_empl, reloj, APOFAC, tipo_nomina, tipo_periodo, "APOFAC", dtConceptos)

                        '**************************BONREF Bono de refencia
                        If (BONREF <> 0) Then puente(anio_empl, per_empl, reloj, BONREF, tipo_nomina, tipo_periodo, "BONREF", dtConceptos)

                        '**************************PREEFI Premio de eficiencia
                        If (PREEFI <> 0) Then puente(anio_empl, per_empl, reloj, PREEFI, tipo_nomina, tipo_periodo, "PREEFI", dtConceptos)


                        '**********************TOTPER - CALCULO DEL TOTAL DE PERCEPCIONES
calcAsim2:
                        TOTPER = 0.0
                        TOTPER = acum_percep
                        '-- insertar en movimientos_pro
                        '  If (TOTPER <> 0) Then puente(anio_empl, per_empl, reloj, TOTPER, tipo_nomina, tipo_periodo, "TOTPER", dtConceptos)
                        puente(anio_empl, per_empl, reloj, TOTPER, tipo_nomina, tipo_periodo, "TOTPER", dtConceptos)

                        '**********************PEREXE - CALCULO DEL TOTAL DE EXENTO
                        PEREXE = 0.0
                        PEREXE = acum_exento
                        '-- insertar en movimientos_pro
                        If (PEREXE <> 0) Then puente(anio_empl, per_empl, reloj, PEREXE, tipo_nomina, tipo_periodo, "PEREXE", dtConceptos)

                        '**********************PERGRA - CALCULO DEL TOTAL GRAVABLE
                        PERGRA = 0.0
                        PERGRA = TOTPER - PEREXE
                        '-- insertar en movimientos_pro
                        If (PERGRA <> 0) Then puente(anio_empl, per_empl, reloj, PERGRA, tipo_nomina, tipo_periodo, "PERGRA", dtConceptos)


                        '**********************ISPTRE - Cálculo del ISTP (ISR RETENIDO)
                        ISPTRE = 0.0
                        Dim aplica_ajsupe As Integer = 0

                        '---Validar que el empleado tenga al menos un mes para aplicar el subsidio
                        If (Aj_Sub_Sem Or Aj_Sub_Cat) Then
                            Dim diasAplSub As Double = 0.0
                            Try : diasAplSub = DateDiff(DateInterval.Day, Date.Parse(alta), Date.Parse(fFinSem)) : Catch ex As Exception : diasAplSub = 0.0 : End Try
                            If (diasAplSub >= 30) Then
                                aplica_ajsupe = 1
                                ACUMPERGRA += PERGRA
                            End If                         
                        End If

                        ISPTRE = CalcISR(reloj, PERGRA, "M", "Imp", DIASPA, dtAjustesPro, aplica_ajsupe, ACUMPERGRA)
                        If (ISPTRE <> 0) Then puente(anio_empl, per_empl, reloj, ISPTRE, tipo_nomina, tipo_periodo, "ISPTRE", dtConceptos)

                        '**********************SUBPAG  - Subsido al empleo Pagado : NOTA: No se suma al TOTPER, sin embargo, si se contabiliza para el NETO
                        SUBPAG = 0.0
                        SUBPAG = subempleoPagado
                        If (SUBPAG <> 0) Then puente(anio_empl, per_empl, reloj, SUBPAG, tipo_nomina, tipo_periodo, "SUBPAG", dtConceptos)

                        '**********************ISPT   - ISR CAUSADO

                        ISPT += isrCausado
                        If (ISPT <> 0) Then puente(anio_empl, per_empl, reloj, ISPT, tipo_nomina, tipo_periodo, "ISPT", dtConceptos)


                        '**********************SUBCAU - SUBSIDIO CAUSADO

                        SUBCAU += subempleoCausado
                        If (SUBCAU <> 0) Then puente(anio_empl, per_empl, reloj, SUBCAU, tipo_nomina, tipo_periodo, "SUBCAU", dtConceptos)


                        '*********************AJSUPE - Ajuste al subsidio causado (Solo es informativo para saber cuando sub causado aplicó en el mes)

                        AJSUPE += subempleoCausado
                        '-- insertar en movimientos_pro
                        If (AJSUPE <> 0) Then puente(anio_empl, per_empl, reloj, AJSUPE, tipo_nomina, tipo_periodo, "AJSUPE", dtConceptos)

                        If (cod_puesto = "00094") Then GoTo calcAsim3


                        '**********************DESINF - Calculo del descuento de INFONAVIT
                        If (esbaja And HRSNOR = 0) Then
                            GoTo SaltaCalcInfo
                        End If

                        If (tipo_cred_info <> "" And cuota_cred_info <> 0.0) Then
                            DESINF = DESINF + CalcInfonavit(reloj, tipo_cred_info, cuota_cred_info, tipo_nomina, tipo_periodo, UMA, DIASPA, UMI, integrado)
                        End If
SaltaCalcInfo:
                        '-- insertar en movimientos_pro
                        If (DESINF <> 0) Then puente(anio_empl, per_empl, reloj, DESINF, tipo_nomina, tipo_periodo, "DESINF", dtConceptos)

                        '*********************SEGVIV - Seguro de la vivienda
                        'NOTA: Solo descontar una vez al bimestre cuando en INFONAVIT.cobro_segv = 1 y cuando es un nuevo credito de INFONAVIT.cobro_segv = True

                        If (cobro_segv) Then SEGVIV += cuota_segviv ' Si aplica el cobro de seg vivienda

                        '-- insertar en movimientos_pro
                        If (SEGVIV <> 0) Then puente(anio_empl, per_empl, reloj, SEGVIV, tipo_nomina, tipo_periodo, "SEGVIV", dtConceptos)

                        '***********************ADEINF - Préstamo de infonavit
                        '-- insertar en movimientos_pro
                        If (ADEINF <> 0) Then puente(anio_empl, per_empl, reloj, ADEINF, tipo_nomina, tipo_periodo, "ADEINF", dtConceptos)


                        '**********************IMSS - Descuento del IMSS

                        If (esbaja = 1) Then ' En los finiquitos no incluir la pervac para dias IMSS
                            _diasImss = _diasImss + (Math.Round((PERNOR + SEPDIA + PERFES) / sactual, 2))
                        Else
                            _diasImss = _diasImss + (Math.Round((PERNOR + SEPDIA + PERFES + PERVAC) / sactual, 2))
                        End If


                        IMSS = IMSS + CalcImss(anio_empl, per_empl, reloj, tipo_nomina, tipo_periodo, topeIntImss, _diasImss, UMA, prima_riesg_imss)

                        '-- insertar en movimientos_pro
                        If (IMSS <> 0) Then puente(anio_empl, per_empl, reloj, IMSS, tipo_nomina, tipo_periodo, "IMSS", dtConceptos)

                        '**********************FNAALC - Préstamo de FONACOT
                        '-- insertar en movimientos_pro
                        If (FNAALC <> 0) Then puente(anio_empl, per_empl, reloj, FNAALC, tipo_nomina, tipo_periodo, "FNAALC", dtConceptos)

                        '**********************LENTES - Descuento de lentes
                        If (LENTES <> 0) Then puente(anio_empl, per_empl, reloj, LENTES, tipo_nomina, tipo_periodo, "LENTES", dtConceptos)

                        '**********************CUOCAF - Descuento de cafetería

                        CUOCAF = CUOCAF + (DIACAF * 17)

                        '-- insertar en movimientos_pro
                        If (CUOCAF <> 0) Then puente(anio_empl, per_empl, reloj, CUOCAF, tipo_nomina, tipo_periodo, "CUOCAF", dtConceptos)


                        '***********************ANTSUE - Anticipo de sueldo

                        '-- insertar en movimientos_pro
                        If (ANTSUE <> 0) Then puente(anio_empl, per_empl, reloj, ANTSUE, tipo_nomina, tipo_periodo, "ANTSUE", dtConceptos)

                        '**********************PENALI - Pensión alimenticia 1
                        Dim basePens1 As Double = 0.0
                        If (porcPens1 > 0) Then
                            basePens1 = (TOTPER - isrRetenido - IMSS - DESINF - APOFAH) * (porcPens1 / 100)  ' NOTA: Falta incluir el ISRSEP (isr separacion)
                            PENALI = PENALI + basePens1
                        End If
                        If (cfPens1 > 0) Then
                            PENALI = PENALI + cfPens1
                        End If

                        If (PENALI <= 0) Then PENALI = 0
                        '-- insertar en movimientos_pro
                        If (PENALI <> 0) Then puente(anio_empl, per_empl, reloj, PENALI, tipo_nomina, tipo_periodo, "PENALI", dtConceptos)

                        '**********************PENAL2 - Pensión alimenticia 2
                        Dim basePens2 As Double = 0.0
                        If (porcPens2 > 0) Then
                            basePens2 = (TOTPER - isrRetenido - IMSS - DESINF - APOFAH) * (porcPens2 / 100)  ' NOTA: Falta incluir el ISRSEP (isr separacion)
                            PENAL2 = PENAL2 + basePens2
                        End If
                        If (cfPens2 > 0) Then
                            PENAL2 = PENAL2 + cfPens2
                        End If
                        If (PENAL2 <= 0) Then PENAL2 = 0
                        '-- insertar en movimientos_pro
                        If (PENAL2 <> 0) Then puente(anio_empl, per_empl, reloj, PENAL2, tipo_nomina, tipo_periodo, "PENAL2", dtConceptos)

                        '**********************PENAL3 - Pensión alimenticia 3
                        Dim basePens3 As Double = 0.0
                        If (porcPens3 > 0) Then
                            basePens3 = (TOTPER - isrRetenido - IMSS - DESINF - APOFAH) * (porcPens3 / 100)  ' NOTA: Falta incluir el ISRSEP (isr separacion)
                            PENAL3 = PENAL3 + basePens3
                        End If
                        If (cfPens3 > 0) Then
                            PENAL3 = PENAL3 + cfPens3
                        End If
                        If (PENAL3 <= 0) Then PENAL3 = 0
                        '-- insertar en movimientos_pro
                        If (PENAL3 <> 0) Then puente(anio_empl, per_empl, reloj, PENAL3, tipo_nomina, tipo_periodo, "PENAL3", dtConceptos)

                        '**********************OTRASD  - Otras deducciones
                        '-- insertar en movimientos_pro
                        If (OTRASD <> 0) Then puente(anio_empl, per_empl, reloj, OTRASD, tipo_nomina, tipo_periodo, "OTRASD", dtConceptos)

                        '**********************ABOPMO - Abono préstamo
                        '-- insertar en movimientos_pro
                        If (ABOPMO <> 0) Then puente(anio_empl, per_empl, reloj, ABOPMO, tipo_nomina, tipo_periodo, "ABOPMO", dtConceptos)

                        '**********************ABOPMO - Abono Intereses
                        '-- insertar en movimientos_pro
                        If (ABOINT <> 0) Then puente(anio_empl, per_empl, reloj, ABOINT, tipo_nomina, tipo_periodo, "ABOINT", dtConceptos)

calcAsim3:


                        '**********************TOTDED - CALCULO DEL TOTAL DE DEDUCCIONES
                        TOTDED = 0.0
                        TOTDED = acum_deduc
                        '-- insertar en movimientos_pro

                        '---AOS 2022-03-15 : Validación de que si el neto es cero, totded debe de ser cero
                        If (acum_neto <= 0 And acum_percep <= 0) Then TOTDED = 0
                        If (acum_neto <= 0 And acum_percep > 0) Then TOTDED = acum_percep

                        puente(anio_empl, per_empl, reloj, TOTDED, tipo_nomina, tipo_periodo, "TOTDED", dtConceptos)


                        '**********************NETO - CALCULO DEL NETO
                        NETO = acum_neto
                        '-- insertar en movimientos_pro
                        '  If (NETO <> 0) Then puente(anio_empl, per_empl, reloj, NETO, tipo_nomina, tipo_periodo, "NETO", dtConceptos)
                        puente(anio_empl, per_empl, reloj, NETO, tipo_nomina, tipo_periodo, "NETO", dtConceptos)

                        '**********************IMPEST - IMPUESTO ESTATAL (Solo como Informativo)
                        IMPEST = 0.0
                        IMPEST = (PERNOR + PERVAC + PEREX2 + PEREX3 + PRIDOM + PRIVAC + PERAGI + PRIANT + OTPGRA + OTPNOG) * (2.5 / 100)
                        If (IMPEST <> 0) Then puente(anio_empl, per_empl, reloj, IMPEST, tipo_nomina, tipo_periodo, "IMPEST", dtConceptos)

                    Next

                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()

                    If (indicProc = "I") Then
                        GoTo Saltar2
                    End If

                    '------Hacer una copia del cálculo original
                    sqlExecute("DROP TABLE nomina_pro_original", "NOMINA")
                    sqlExecute("DROP TABLE horas_pro_original", "NOMINA")
                    sqlExecute("DROP TABLE ajustes_pro_original", "NOMINA")
                    sqlExecute("DROP TABLE movimientos_pro_original", "NOMINA")
                    sqlExecute("DROP TABLE movimientos_imss_pro_original", "NOMINA")
                    sqlExecute("select * into nomina_pro_original from nomina_pro", "NOMINA")
                    sqlExecute("select * into horas_pro_original from horas_pro", "NOMINA")
                    sqlExecute("select * into ajustes_pro_original from ajustes_pro", "NOMINA")
                    sqlExecute("select * into movimientos_pro_original from movimientos_pro", "NOMINA")
                    sqlExecute("select * into movimientos_imss_pro_original from movimientos_imss_pro", "NOMINA")


                    '---Mensaje con el resúmen
                    If i < 0 Then
                        'No hubo archivos para analizar
                        MessageBox.Show("No se calculó ningun registro", "Cálculo de nómina", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                        Me.Close()
                    Else
                        MessageBox.Show("Proceso concluído satisfactoriamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()

                        'MessageBox.Show(Mensaje & vbCrLf & "   - Se analizaron " & i & " registros" & vbCrLf & _
                        '    "   - " & Insertados & " registros fueron insertados" & vbCrLf & _
                        '    "   - " & Duplicados & " registros se encontraron duplicados" & vbCrLf & _
                        '    "   - " & NoRelacionados & " registros no encontraron relación en personal" & vbCrLf & Now _
                        '    & IIf(NoRelacionados > 0, vbCrLf & vbCrLf & "Empleados no relacionados: " & RelojesNoRelacionados, "") _
                        '    , "Horas importadas", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ''*******************Detectar diferencias, es decir, si hubo conceptos de horas_pro y ajustes_pro que no pasaron a movimientos_pro
                        Dim TotDifConc As Integer = FindDifConcep(dtHorasPro, dtAjustesPro)
                        If TotDifConc > 0 Then

                            '---Nota : dtDifConceptos es el qeu traerá la info para generar el reporte
                            If (Not dtDifConceptos.Columns.Contains("Error") And dtDifConceptos.Rows.Count > 0) Then
                                MessageBox.Show("Se detectaron " & TotDifConc & " conceptos con diferencia que no se incluyeron en la nómina, se generará reporte con el detalle", "Diferencias en conceptos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                                Dim _dtDatos As New DataTable
                                frmVistaPrevia.LlamarReporte("Diferencia en conceptos", dtDifConceptos)
                                frmVistaPrevia.ShowDialog()
                                '  DifConcCalcNom(_dtDatos, dtDifConceptos)
                            End If
                        End If

                        If MessageBox.Show("¿Desea generar el detalle de la nómina?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                            ''--Validar si va solo uno o dos periodos
                            If (TotPerProc = 1) Then
                                GenRepNominaDetalle(anio1, per1, "5", tipo_per1)
                                Me.Close()
                            End If

                            If (TotPerProc = 2) Then
                                GenRepNominaDetalle(anio1, per1, "5", tipo_per1)
                                GenRepNominaDetalle(anio2, per2, "5", tipo_per2)
                                Me.Close()
                            End If

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

    Public Function FindDifConcep(ByVal _dtHrsPro As DataTable, _dtAjustesPro As DataTable) As Integer
        Dim TotDif As Integer = 0
        Dim ano As String = "", periodo As String = "", rj As String = "", concepto As String = "", descripcion As String = "", monto As Double = 0.0, tipo_periodo As String = ""

        Try
            dtMovimientos_pro = sqlExecute("select * from movimientos_pro", "NOMINA")

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

    

End Class