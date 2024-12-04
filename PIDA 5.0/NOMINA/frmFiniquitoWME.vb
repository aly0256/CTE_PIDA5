Public Class frmFiniquitoWME

    Dim dtConcGrid As New DataTable
    Dim dtConceMovimientos As New DataTable
    Dim dtRegistro As New DataTable
    Dim dtCompania As New DataTable
    Dim dtNominaBaseProcesada As New DataTable
    Dim dtPeriodos As New DataTable
    Dim EsAltaMayorAperiodo As Boolean

    Dim Clave As String = ""
    Dim sFechaAltaEmpleado As String = ""
    Public strPeriodo As String = ""
    Dim sUltimaNominaProcesada As String = ""
    Dim TipoEmp As String = ""

    Public EditarAgregar As String = ""
    Public FiltroEditar As String = "1=0"
    Dim CambioFhaBajaFin As Boolean = False
    Dim EsCargaInicial As Boolean = True

    Dim ano_mtro_ded As String = ""
    Dim per_mtro_ded As String = ""
    Dim numcred_mtro_ded As String = ""


#Region "Calculo finiquitos codigo basado de frmCalcNom funcion CalculoNomina"

    '*** Calculo finiquitos codigo basado de frmCalcNom funcion CalculoNomina

    '*******Variables a utilizar
    '----OTRAS

    Dim asentado As String = ""

    '----DataTables
    Dim dtConceptos As New DataTable
    '    Dim dtNominaPro As New DataTable
    Dim dtNominaCalc As New DataTable
    'Dim dtHorasPro As New DataTable
    'Dim dtAjustesPro As New DataTable
    Dim dtAjuestesCalc As New DataTable
    'Dim dtMovimientos_pro As New DataTable
    'Dim dtStatusProc As New DataTable
    Dim dtTurnos As New DataTable
    Dim dtInfonavit As New DataTable
    Dim dtResultadoNomina As New DataTable
    Dim dtDifConceptos As New DataTable
    Dim dtPensAlim As New DataTable
    Dim filtroNomina As String = ""


    '--Var relacionadas a fechas del periodo
    Dim anio As String = ""
    Dim periodo As String = ""
    Dim fIniSem As String = ""
    Dim fFinSem As String = ""
    Dim fIniCat As String = ""
    Dim fFinCat As String = ""

    '--Var relacionadas a los periodos que se estarán procesando en el cálculo
    Dim anio1 As String = "", per1 As String = "", tipo_per1 As String = "", anio2 As String = "", per2 As String = "", tipo_per2 As String = ""
    Dim NumMesSem As String = "", NumMesCat As String = "" ' Indica el num de mes en el qeu estamos viviendo para obtener el acumulado de la percep gravada de las ultimas 4 semanas o 2 si es 14nal
    Dim Aj_Sub_Sem As Boolean = False  ' Indica si aplica sub cau para la semanal
    Dim Aj_Sub_Cat As Boolean = False ' Indica si aplica sub cau para la 14nal
    Dim TotPerProc As Integer = 0 ' Total de periodos que se están procesando


    '-- Var relacionadas a los conceptos de nomina a calcular
    '-OTROS
    Dim dtCod_comp As New DataTable
    Dim cod_comp As String = "WME" ' Por lo pronto se deja fijo el codigo de la compania
    Dim UMA As Double = 0.0
    Dim SALMIN As Double = 0.0
    Dim prima_riesg_imss As Double = 0.0
    Dim cuota_segviv As Double = 0.0
    Dim UMI As Double = 0.0 ' Valor del factor de descuento para Infonavit

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


    '--PERCEPCIONES
    Dim PERNOR As Double = 0.0 ' PERCEPCION NORMAL
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
    Dim LIFAHC As Double = 0.0 ' --- Percepción liquidación fondo de ahorro empresa
    Dim LIFAHE As Double = 0.0 ' --- Percepción liquidación fondo de ahorro empleado

    Dim BONASI As Double = 0.0 ' BONO ASISTENCIA
    Dim BONDES As Double = 0.0 ' BONO DESPENSA
    Dim DESEFE As Double = 0.0 ' BONO DESPENSA EN EFECTIVO
    Dim BONPRO As Double = 0.0 ' BONO PRODUCTIVIDAD

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
    Dim ISRSEP As Double = 0.0 'ISR impuesto por separacion
    Dim SUBPAG As Double = 0.0 ' Subsidio al empleo realmente pagado
    Dim CUOCAF As Double = 0.0 ' Descuento de cafetería
    Dim DESINF As Double = 0.0 ' Descuento de infonavit
    Dim SEGVIV As Double = 0.0 ' Descuento de Seg vivienda
    Dim IMSS As Double = 0.0   ' Descuento de IMSS
    Dim FNAALC As Double = 0.0 ' Descuento de Fonacot
    Dim APOFAH As Double = 0.0 ' Aportación de fondo de ahorro Empleado
    Dim APOFAC As Double = 0.0 ' Aportación de fondo de ahorro Empresa
    Dim AJSUPE As Double = 0.0 ' Ajuste al subsidio causado
    Dim ADEINF As Double = 0.0 ' Préstamo de Infonavit
    Dim ANTSUE As Double = 0.0 ' Anticipo de sueldo
    Dim PENALI As Double = 0.0 ' Pensión alimenticia 1
    Dim OTRASD As Double = 0.0 ' Otras deducciones
    Dim ABOPMO As Double = 0.0 ' Abono préstamo
    Dim PENAL2 As Double = 0.0 ' Pensión alimenticia 2
    Dim PENAL3 As Double = 0.0 ' Pensión alimenticia 3
    Dim TIENDA As Double = 0.0 ' Tienda
    Dim CAPACI As Double = 0.0 ' Descuento capacitacion
    Dim RECFNT As Double = 0.0 ' Recuperacion fonacot
    Dim GASMEE As Double = 0.0 ' Gastos medicos excedente

    '--TOTALES
    Dim PERGRA As Double = 0.0 ' Total de percep gravable
    Dim PEREXE As Double = 0.0  ' Total de percepción exenta
    Dim TOTPER As Double = 0.0 ' Total de percepciones
    Dim TOTDED As Double = 0.0 ' Total de deducciones
    Dim NETO As Double = 0.0   ' Total Neto

    '--Informativos
    Dim IMPEST As Double = 0.0 ' Impuesto estatal

    'SALDOS
    Dim SAFAHC As Double = 0.0  'Saldo fondo de ahorro empresa
    Dim SAFAHE As Double = 0.0  'Saldo fondo de ahorro empleado


    '*******Ends 

    'Variables genericas para conceptos de maestro de deducciones
    Dim dtMaestroDeducciones As New DataTable
    Dim VALOR As Double = 0.0

    Private Sub CargaDatosIniciales()

        'dtStatusProc = sqlExecute("select * from status_proceso", "NOMINA")
        'If (Not dtStatusProc.Columns.Contains("Error") And dtStatusProc.Rows.Count > 0) Then
        '    Try : anio = dtStatusProc.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : anio = "" : End Try
        '    Try : periodo = dtStatusProc.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : periodo = "" : End Try
        '    If (anio.Trim <> "" And periodo.Trim <> "") Then
        '        Dim dtPeriodo As DataTable = sqlExecute("SELECT * from ta.dbo.periodos where ano+PERIODO='" & anio & periodo & "'")
        '        If (Not dtPeriodo.Columns.Contains("Error") And dtPeriodo.Rows.Count > 0) Then
        '            Try : fIniSem = FechaSQL(dtPeriodo.Rows(0).Item("FECHA_INI").ToString.Trim) : Catch ex As Exception : fIniSem = "" : End Try
        '            Try : fFinSem = FechaSQL(dtPeriodo.Rows(0).Item("FECHA_FIN").ToString.Trim) : Catch ex As Exception : fFinSem = "" : End Try
        '            Try : asentado = dtPeriodo.Rows(0).Item("asentado").ToString.Trim : Catch ex As Exception : asentado = "" : End Try
        '        End If


        '        ' txtAnio.Text = anio
        '        ' txtPeriodo.Text = periodo & " del " & fIniSem & " al " & fFinSem
        '    End If

        'Else
        '    MessageBox.Show("No hay un periodo inicializado a procesar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If

        If txtPeriodoCalculo.Text.Trim.Length > 0 Then

            Try : anio = Split(txtPeriodoCalculo.Text.Trim, "-")(0) : Catch ex As Exception : anio = "" : End Try
            Try : periodo = Split(txtPeriodoCalculo.Text.Trim, "-")(1) : Catch ex As Exception : periodo = "" : End Try
            Try : fFinSem = FechaSQL(BajaFiniquito.Value) : Catch ex As Exception : fFinSem = "" : End Try
        Else
            MessageBox.Show("No hay un periodo inicializado para procesar.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

    End Sub

    Public Function CalculoFiniquito(ByRef anio As String, periodo As String, indicProc As String, _filtroNom As String, _reloj As String, _folio As String) As Integer

        Try

            '---Mostrar Progress
            Dim i As Integer = -1
            frmTrabajando.Text = "Calculando finiquito"
            frmTrabajando.Avance.IsRunning = True
            frmTrabajando.lblAvance.Text = "Calculando finiquito"
            ActivoTrabajando = True
            frmTrabajando.Show()
            Application.DoEvents()

            If (indicProc = "I") Then CargaDatosIniciales() ' Si viene del recalc a un solo empleado, que cargue datos iniciales

            'A--Validar que exista un periodo de captura de calculo de finiquito, es decir, que txtPeriodoCalculo no esté vacío
            If (anio <> "" And periodo <> "") Then

                Dim qNom As String = ""
                If (indicProc = "G") Then qNom = "select * from nomina_calculo order by reloj asc" Else If (indicProc = "I") Then qNom = "select * from nomina_calculo where folio = '" & _folio & "' and reloj='" & _reloj & "'"
                dtNominaCalc = sqlExecute(qNom, "NOMINA")
                If ((dtNominaCalc.Columns.Contains("Error")) Or (Not dtNominaCalc.Columns.Contains("Error") And dtNominaCalc.Rows.Count = 0)) Then
                    MessageBox.Show("No existe el empleado para procesar su finiquito en este periodo de captura.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Function
                Else

                    'If indicProc = "G" Then dtHorasPro = sqlExecute("SELECT * from horas_pro", "NOMINA") Else If (indicProc = "I") Then dtHorasPro = sqlExecute("SELECT * from horas_pro where reloj='" & _reloj & "'", "NOMINA")
                    'If indicProc = "G" Then dtAjustesPro = sqlExecute("SELECT * from ajustes_pro", "NOMINA") Else If (indicProc = "I") Then dtAjustesPro = sqlExecute("SELECT * from ajustes_pro where reloj='" & _reloj & "'", "NOMINA")

                    If indicProc = "G" Then dtAjuestesCalc = sqlExecute("SELECT * from ajustes_calculo", "NOMINA") Else If (indicProc = "I") Then dtAjuestesCalc = sqlExecute("SELECT * from ajustes_calculo where folio = '" & _folio & "' and reloj='" & _reloj & "'", "NOMINA")
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
                    'GetTiposPer(filtroNomina)
                    '--Ends

                    If (indicProc = "I") Then GoTo Saltar1

                    ''---Preparar dt que mostrará el resumen en diferencia de conceptos que no se agregaron
                    'dtDifConceptos.Columns.Add("ano", Type.GetType("System.String"))
                    'dtDifConceptos.Columns.Add("periodo", Type.GetType("System.String"))
                    'dtDifConceptos.Columns.Add("reloj", Type.GetType("System.String"))
                    'dtDifConceptos.Columns.Add("concepto", Type.GetType("System.String"))
                    'dtDifConceptos.Columns.Add("descripcion", Type.GetType("System.String"))
                    'dtDifConceptos.Columns.Add("monto", Type.GetType("System.Double"))
                    'dtDifConceptos.Columns.Add("tipo_periodo", Type.GetType("System.String"))
                    '---Ends
Saltar1:

                    '--Mostrar progress
                    frmTrabajando.Avance.IsRunning = False
                    frmTrabajando.lblAvance.Text = "Procesando datos"
                    Application.DoEvents()
                    frmTrabajando.Avance.Maximum = dtNominaCalc.Select(filtroNomina).Count

                    For Each drNomPro As DataRow In dtNominaCalc.Select(filtroNomina) ' -- Recorrer cada uno de los empleados a calc su finiquito que si van a ser procesados

                        '-Variables globales que tienen que inicializarse al calcular cada nomina o finiquito
                        acum_percep = 0.0
                        acum_deduc = 0.0
                        acum_neto = 0.0
                        acum_exento = 0.0
                        isrCausado = 0.0
                        subempleoCausado = 0.0
                        isrRetenido = 0.0
                        subempleoPagado = 0.0

                        '----------------Vars por cada empleado a inicializarse por calculo
                        Dim anio_empl As String = ""
                        Dim per_empl As String = ""
                        Dim finFolio As String = "" '--Folio del finiquito
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

                        '--Dar el valor para cada var
                        Try : anio_empl = drNomPro("ano").ToString.Trim : Catch ex As Exception : anio_empl = "" : End Try ' Esto porque puede ser Semanal o 14nal y puede cambiar el anio
                        Try : per_empl = drNomPro("periodo").ToString.Trim : Catch ex As Exception : per_empl = "" : End Try ' Esto porque puede ser Semanal o 14nal y cambia el periodo
                        Try : reloj = drNomPro("reloj").ToString.Trim : Catch ex As Exception : reloj = "" : End Try
                        Try : finFolio = drNomPro("folio").ToString.Trim : Catch ex As Exception : finFolio = "" : End Try
                        '----Mostrar Progress - avance
                        i += 1
                        frmTrabajando.Avance.Value = i
                        frmTrabajando.lblAvance.Text = reloj
                        Application.DoEvents()

                        Try : sactual = Double.Parse(drNomPro("sactual")) : Catch ex As Exception : sactual = 0.0 : End Try
                        Try : integrado = Double.Parse(drNomPro("integrado")) : Catch ex As Exception : integrado = 0.0 : End Try
                        Try : alta = FechaSQL(drNomPro("alta").ToString.Trim) : Catch ex As Exception : alta = "" : End Try
                        ' Try : baja = FechaSQL(drNomPro("baja").ToString.Trim) : Catch ex As Exception : baja = "" : End Try
                        Try : baja = FechaSQL(drNomPro("baja_fin").ToString.Trim) : Catch ex As Exception : baja = "" : End Try
                        'Try : tipo_nomina = drNomPro("tipo_nomina").ToString.Trim : Catch ex As Exception : tipo_nomina = "" : End Try
                        Try : tipo_nomina = drNomPro("cod_tipo_nomina").ToString.Trim : Catch ex As Exception : tipo_nomina = "" : End Try
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
                        If (tipo_periodo = "S") Then _TaTipoPer = "TA.dbo.periodos"
                        If (tipo_periodo = "C") Then _TaTipoPer = "TA.dbo.periodos_catorcenal"

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


                        ''---Saber si es baja (finiquito) o no del periodo 
                        'Dim drEsbaja As DataRow = Nothing
                        'Try : drEsbaja = dtAjuestesCalc.Select("reloj='" & reloj & "' and folio ='" & _folio & "' and concepto='ESBAJA'")(0) : Catch ex As Exception : drEsbaja = Nothing : End Try
                        'If (Not IsNothing(drEsbaja)) Then esbaja = 1
                        ''---ENDS baja o no

                        'Es finiquito
                        esbaja = 1
                        '---------------

                        '                    '----------Obtener el acumulado de la percep gravada en caso de que aplique ajuste al subsidio
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
                        '                    '----------Ends obtener el acum de PERGRA

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
                        PERNOR = 0.0
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
                        PERINC = 0.0
                        DIAINC = 0.0
                        DIACVN = 0.0
                        PENAL2 = 0.0
                        PENAL3 = 0.0

                        PRIANT = 0.0
                        INDEMN = 0.0
                        NOREST = 0.0
                        LIFAHC = 0.0
                        LIFAHE = 0.0
                        ISRSEP = 0.0

                        PEXPAN = 0.0
                        PEXNOR = 0.0
                        PEXIND = 0.0


                        '********************LAP - Nuevo 
                        Dim dtNoEnlistado As New DataTable
                        VALOR = 0.0
                        dtNoEnlistado.Columns.Add("naturaleza", Type.GetType("System.String"))
                        dtNoEnlistado.Columns.Add("concepto", Type.GetType("System.String"))
                        dtNoEnlistado.Columns.Add("valor", Type.GetType("System.Double"))
                        '*************Fin LAP

                        For Each dr As DataRow In dtAjuestesCalc.Select("reloj='" & reloj & "' and folio ='" & finFolio & "'")
                            Dim concepto As String = "", monto As Double = 0.0, EnListado As Boolean = False
                            Try : concepto = dr("concepto").ToString.Trim : Catch ex As Exception : concepto = "" : End Try
                            Try : monto = Double.Parse(dr("monto")) : Catch ex As Exception : concepto = "" : End Try

                            If (concepto = "HRSNOR") Then HRSNOR += monto : EnListado = True
                            If (concepto = "HRSEX2") Then HRSEX2 += monto : EnListado = True
                            If (concepto = "HRSEX3") Then HRSEX3 += monto : EnListado = True
                            If (concepto = "HRSFES") Then HRSFES += monto : EnListado = True
                            If (concepto = "BONASI") Then BONASI += monto : EnListado = True
                            If (concepto = "DIACAF") Then DIACAF += monto : EnListado = True
                            If (concepto = "HRSDOM") Then HRSDOM += monto : EnListado = True
                            If (concepto = "HRSFEL") Then HRSFEL += monto : EnListado = True
                            If (concepto = "DIASVA") Then DIASVA += monto : EnListado = True
                            If (concepto = "DIASPV") Then DIASPV += monto : EnListado = True
                            If (concepto = "DIASAG") Then DIASAG += monto : EnListado = True
                            If (concepto = "DIAUNI") Then DIAUNI += monto : EnListado = True
                            If (concepto = "DIASPA") Then DIASPA += monto : EnListado = True
                            If (concepto = "HRSINC") Then HRSINC += monto : EnListado = True
                            If (concepto = "DIAINC") Then DIAINC += monto : EnListado = True
                            If (concepto = "DIACVN") Then DIACVN += monto : EnListado = True

                            If (concepto = "FNAALC") Then FNAALC += monto : EnListado = True
                            If (concepto = "PERNOR") Then PERNOR += monto : EnListado = True
                            If (concepto = "PEREX2") Then PEREX2 += monto : EnListado = True
                            If (concepto = "PEREX3") Then PEREX3 += monto : EnListado = True
                            If (concepto = "PEXEXT") Then PEXEXT += monto : EnListado = True
                            If (concepto = "FESLAB") Then FESLAB += monto : EnListado = True
                            If (concepto = "PRIDOM") Then PRIDOM += monto : EnListado = True
                            If (concepto = "PEXDOM") Then PEXDOM += monto : EnListado = True
                            If (concepto = "PERVAC") Then PERVAC += monto : EnListado = True
                            If (concepto = "PRIVAC") Then PRIVAC += monto : EnListado = True
                            If (concepto = "PEXVAC") Then PEXVAC += monto : EnListado = True
                            If (concepto = "PERAGI") Then PERAGI += monto : EnListado = True
                            If (concepto = "PEXAGI") Then PEXAGI += monto : EnListado = True
                            If (concepto = "RETROA") Then RETROA += monto : EnListado = True
                            If (concepto = "BONDES") Then BONDES += monto : EnListado = True
                            If (concepto = "DESEFE") Then DESEFE += monto : EnListado = True
                            If (concepto = "BONPRO") Then BONPRO += monto : EnListado = True
                            If (concepto = "SEPUNI") Then SEPUNI += monto : EnListado = True
                            If (concepto = "PERPTU") Then PERPTU += monto : EnListado = True
                            If (concepto = "PEXPTU") Then PEXPTU += monto : EnListado = True
                            If (concepto = "OTPGRA") Then OTPGRA += monto : EnListado = True
                            If (concepto = "OTPNOG") Then OTPNOG += monto : EnListado = True
                            If (concepto = "APOFAH") Then APOFAH += monto : EnListado = True
                            If (concepto = "EXEDFA") Then EXEDFA += monto : EnListado = True
                            If (concepto = "APOCIA") Then APOCIA += monto : EnListado = True
                            If (concepto = "PEXFAH") Then PEXFAH += monto : EnListado = True
                            If (concepto = "APOFAC") Then APOFAC += monto : EnListado = True
                            If (concepto = "ISPT") Then ISPT += monto : EnListado = True
                            If (concepto = "SUBCAU") Then SUBCAU += monto : EnListado = True
                            If (concepto = "AJSUPE") Then AJSUPE += monto : EnListado = True
                            If (concepto = "DESINF") Then DESINF += monto : EnListado = True
                            If (concepto = "SEGVIV") Then SEGVIV += monto : EnListado = True
                            If (concepto = "ADEINF") Then ADEINF += monto : EnListado = True
                            If (concepto = "IMSS") Then IMSS += monto : EnListado = True
                            If (concepto = "CUOCAF") Then CUOCAF += monto : EnListado = True
                            If (concepto = "ANTSUE") Then ANTSUE += monto : EnListado = True
                            If (concepto = "PENALI") Then PENALI += monto : EnListado = True
                            If (concepto = "OTRASD") Then OTRASD += monto : EnListado = True
                            If (concepto = "ABOPMO") Then ABOPMO += monto : EnListado = True
                            If (concepto = "PENAL2") Then PENAL2 += monto : EnListado = True
                            If (concepto = "PENAL3") Then PENAL3 += monto : EnListado = True

                            If (concepto = "PRIANT") Then PRIANT += monto : EnListado = True
                            If (concepto = "PEXPAN") Then PEXPAN += monto : EnListado = True

                            If (concepto = "INDEMN") Then INDEMN += monto : EnListado = True
                            If (concepto = "PEXIND") Then PEXIND += monto : EnListado = True

                            If (concepto = "NOREST") Then NOREST += monto : EnListado = True
                            If (concepto = "PEXNOR") Then PEXNOR += monto : EnListado = True

                            If (concepto = "LIFAHC") Then LIFAHC += monto : EnListado = True
                            If (concepto = "LIFAHE") Then LIFAHE += monto : EnListado = True


                            If (concepto = "ISRSEP") Then ISRSEP += monto : EnListado = True

                            If concepto.Trim <> "" And Not EnListado Then
                                Dim drConcNoList As DataRow = dtNoEnlistado.NewRow
                                Dim natconce As String = ""
                                Try
                                    VALOR = 0.0
                                    Dim dtNaturaleza As DataTable = sqlExecute("select top 1 ltrim(rtrim(cod_naturaleza)) as 'cod_naturaleza' from conceptos where concepto = '" & concepto.Trim & "' and ltrim(rtrim(isnull(cod_naturaleza,''))) <> '' ", "NOMINA")
                                    natconce = dtNaturaleza.Rows(0).Item("cod_naturaleza").ToString.Trim
                                    drConcNoList("naturaleza") = natconce
                                    drConcNoList("concepto") = concepto.Trim
                                    VALOR = monto
                                    drConcNoList("valor") = VALOR
                                    dtNoEnlistado.Rows.Add(drConcNoList)
                                Catch ex As Exception

                                End Try

                            End If


                        Next
                        '**************************Obtener datos del maestro de deducciones
                        'Dim tabla As String = ""

                        'If (tipo_periodo = "S") Then tabla = "TA.dbo.periodos"
                        'If (tipo_periodo = "C") Then tabla = "TA.dbo.periodos_catorcenal"

                        'tabla = "TA.dbo.periodos"

                        'dtMaestroDeducciones = sqlExecute("with T0 as ( " & vbCr & _
                        '"select * " & vbCr & _
                        '"from conceptos " & vbCr & _
                        '"where finiquito = 1 and APLICA_MTRO_DED = 1 and rtrim(ltrim(isnull(alias_mtro_ded,''))) <> '' " & vbCr & _
                        '"),T1 as( " & vbCr & _
                        '"select reloj, max(ano) as ano, max(periodo) as periodo " & vbCr & _
                        '"from mtro_ded " & vbCr & _
                        '"where exists(select * from " & tabla & " TAperiodos where TAperiodos.ano = mtro_ded.ano and TAperiodos.periodo = mtro_ded.periodo and isnull(periodo_especial,0) = 0) " & vbCr & _
                        '"and reloj = '" & reloj.Trim & "' " & vbCr & _
                        '"group by reloj " & vbCr & _
                        '"),T2 as ( " & vbCr & _
                        '"select * " & vbCr & _
                        '"from mtro_ded " & vbCr & _
                        '"where exists(select * from T1 where T1.RELOJ = mtro_ded.RELOJ and T1.ano = mtro_ded.ANO and T1.periodo = mtro_ded.PERIODO)" & vbCr & _
                        '"),T3 as (" & vbCr & _
                        '"select * from T2 where exists(select concepto from T0 where ltrim(rtrim(T2.CONCEPTO)) = ltrim(rtrim(T0.alias_mtro_ded)))" & vbCr & _
                        '") select ltrim(rtrim(T0.cod_naturaleza)) as 'cod_naturaleza',ltrim(rtrim(T0.CONCEPTO)) as 'concepto',isnull(T3.SALDO_ACT,0) as 'SALDO_ACT' from T0 inner join T3 on T0.alias_mtro_ded = T3.CONCEPTO", "NOMINA")

                        'If dtMaestroDeducciones.Rows.Count > 0 Then

                        '    For Each drNolista As DataRow In dtNoEnlistado.Rows

                        '        Dim drEncontrado As DataRow = Nothing

                        '        Try : drEncontrado = dtMaestroDeducciones.Select("concepto = '" & drNolista("concepto") & "'")(0) : Catch ex As Exception : drEncontrado = Nothing : End Try

                        '        If Not IsNothing(drEncontrado) Then
                        '            Dim CargaValor As Double = 0.0
                        '            Try : CargaValor = drEncontrado("saldo_act") : Catch ex As Exception : CargaValor = 0.0 : End Try
                        '            drNolista("valor") += CargaValor

                        '        End If
                        '    Next

                        'End If

                        'For Each drBuscar As DataRow In dtMaestroDeducciones.Rows

                        '    If Not dtNoEnlistado.Select("concepto = '" & drBuscar("concepto") & "'").Count > 0 Then
                        '        Try

                        '            Dim drAgregar As DataRow = dtNoEnlistado.NewRow
                        '            drAgregar("naturaleza") = drBuscar("cod_naturaleza")
                        '            drAgregar("concepto") = drBuscar("concepto")
                        '            drAgregar("valor") = drBuscar("saldo_act")
                        '            dtNoEnlistado.Rows.Add(drAgregar)

                        '        Catch ex As Exception

                        '        End Try

                        '    End If

                        'Next




                        '***************************Obtener datos de pensiones Alimenticias

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

                        ''*******************************Validar altas dentro del periodo actual
                        '' Nota: Si por ejemplo las fecha del periodo son del 24/08 al 30/08 y una alta cae entre esos días, se refiere a que es una alta entre periodo
                        'Dim DEntrePer As Integer = 0 '- Días entre periodo
                        'Dim AltaEntrePer As Boolean = False  ' Var bool que indica si es un alta entre periodo
                        'Dim _altad As Date = Convert.ToDateTime(alta)
                        'Dim _ffinPerS As Date = Date.Parse(fFinSem)
                        'If (tipo_periodo = "S") Then
                        '    DEntrePer = (DateDiff(DateInterval.Day, _altad, _ffinPerS) + 1) - 2
                        '    If (DEntrePer >= 1 And DEntrePer <= 5) Then AltaEntrePer = True
                        'End If

                        '' '************************HRSNOR 
                        'If (AltaEntrePer) Then
                        '    HRSNOR = Math.Round((horas_turno / 5) * DEntrePer, 2)
                        'End If

                        '--insertar en movimientos_calculo
                        If (HRSNOR <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, HRSNOR, tipo_nomina, tipo_periodo, "HRSNOR", dtConceptos)

                        '**************************HRSINC -- Horas de incapacidad
                        If (HRSINC <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, HRSNOR, tipo_nomina, tipo_periodo, "HRSINC", dtConceptos)

                        '**************************DIAINC ---- Días de incapacidad
                        If (DIAINC <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, DIAINC, tipo_nomina, tipo_periodo, "DIAINC", dtConceptos)

                        '**************************DIACVN ---- Días de convenio
                        If (DIACVN <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, DIACVN, tipo_nomina, tipo_periodo, "DIACVN", dtConceptos)

                        '****************************************DIACAF - Dias para desc de cafetería :: Van a venir en cant de días desde el TA
                        '--insertar en movimientos_calculo
                        If (DIACAF <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, DIACAF, tipo_nomina, tipo_periodo, "DIACAF", dtConceptos)

                        '***********************HRSFES

                        '--insertar en movimientos_calculo
                        If (HRSFES <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, HRSFES, tipo_nomina, tipo_periodo, "HRSFES", dtConceptos)

                        '********************** HRSEX2
                        '--insertar en movimientos_calculo
                        If (HRSEX2 <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, HRSEX2, tipo_nomina, tipo_periodo, "HRSEX2", dtConceptos)


                        '********************** HRSEX3
                        '--insertar en movimientos_calculo
                        If (HRSEX3 <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, HRSEX3, tipo_nomina, tipo_periodo, "HRSEX3", dtConceptos)

                        '**********************HRSDOM -- Horas domingo
                        '--insertar en movimientos_calculo
                        If (HRSDOM <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, HRSDOM, tipo_nomina, tipo_periodo, "HRSDOM", dtConceptos)


                        ' ****************************************HRSFEL -- Horas festivas laboradas
                        '--insertar en movimientos_calculo
                        If (HRSFEL <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, HRSFEL, tipo_nomina, tipo_periodo, "HRSFEL", dtConceptos)

                        '**********************DIASVA -- Días de vacaciones
                        '--insertar en movimientos_calculo
                        If (DIASVA <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, DIASVA, tipo_nomina, tipo_periodo, "DIASVA", dtConceptos)

                        '**********************DIASPV -- Días de prima vacacional

                        If (privac_dias_aniv <> 0.0) Then DIASPV = DIASPV + privac_dias_aniv ' Si es el aniv del empleado, los dias de prima son los que vienen en Nomina_pro
                        If (privac_porc_aniv <> 0.0) Then privac_porc_aniv = privac_porc_aniv / 100
                        If (privac_porc_aniv = 0.0) Then privac_porc_aniv = 0.25 ' Si no trae valor el porc por aniv, se deja por default el 0.25

                        '--insertar en movimientos_calculo
                        If (DIASPV <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, DIASPV, tipo_nomina, tipo_periodo, "DIASPV", dtConceptos)

                        '**********************DIASAG -- Días de aguinaldo
                        '--- Obtener periodo y empleados de nomina de aguinaldo pagada
                        Dim QPerAgui As String = "select * from periodos where ano='" & Year(BajaFiniquito.Value) & "' and observaciones like '%aguinaldo%' and PERIODO_ESPECIAL=1"
                        Dim QNomAguiPag As String = ""
                        Dim per_agui_pag As String = ""
                        Dim dtPerAguiPag As DataTable = sqlExecute(QPerAgui, "TA")
                        Dim dtEmplAguiPag As New DataTable

                        If (Not dtPerAguiPag.Columns.Contains("Error") And dtPerAguiPag.Rows.Count > 0) Then
                            Try : per_agui_pag = dtPerAguiPag.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : per_agui_pag = "" : End Try

                            QNomAguiPag = "select * from movimientos where ano+periodo='" & Year(BajaFiniquito.Value) & per_agui_pag & "' and concepto='PERAGI' and monto<>0 "
                            dtEmplAguiPag = sqlExecute(QNomAguiPag, "NOMINA")
                        End If

                        Dim aguiPag As Integer = 0

                        If dtEmplAguiPag.Rows.Count > 0 Then
                            If (dtEmplAguiPag.Select("reloj='" & reloj & "'").Count > 0) Then aguiPag = 1
                        End If

                        '--insertar en movimientos_calculo
                        If (aguiPag = 1) Then DIASAG = 0.0

                        If (DIASAG <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, DIASAG, tipo_nomina, tipo_periodo, "DIASAG", dtConceptos)

                        '***********************DIAUNI -- Días para pago de separación única
                        '--insertar en movimientos_calculo
                        If (DIAUNI <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, DIAUNI, tipo_nomina, tipo_periodo, "DIAUNI", dtConceptos)

                        '**********************PERNOR - CALCULO DE LA PERCEPCION NORMAL

                        '  PERNOR = ((sactual * 7) / horas_turno) * HRSNOR '&&_ Original de antes
                        Dim normal As Double = 0.0
                        Dim _sepdia As Double = 0.0
                        normal = ((sactual * 6) / horas_turno) * HRSNOR
                        _sepdia = normal * 0.16667
                        PERNOR = PERNOR + normal + _sepdia
                        ' 2,356.90 + 392.82

                        '-- insertar en movimientos_calculo
                        If (PERNOR <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PERNOR, tipo_nomina, tipo_periodo, "PERNOR", dtConceptos)

                        '***********************PERINC - Percepción por incapacidad (Esta solo es ficticia y no afecta al neto ni al total)
                        '2 diasIncap *  sactual * 1.16667 = 637.97 --> base para calc bono despensa, que es la parte de Incap o Convenio
                        'Dim normal_inc As Double = 0.0
                        'Dim sepdia_inc As Double = 0.0
                        'normal_inc = ((sactual * 6) / horas_turno) * HRSINC
                        'sepdia_inc = normal_inc * 0.16667
                        ' PERINC = normal_inc + sepdia_inc
                        Dim TotDiasInci As Double = DIAINC + DIACVN
                        PERINC = TotDiasInci * sactual * 1.16667
                        If (PERINC <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PERINC, tipo_nomina, tipo_periodo, "PERINC", dtConceptos)

                        '**********************PEREX2 - CALCULO DE LA PERCEPCION DOBLE

                        PEREX2 = PEREX2 + (HRSEX2 * 2 * costo_x_hora)

                        '-- insertar en movimientos_calculo
                        If (PEREX2 <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PEREX2, tipo_nomina, tipo_periodo, "PEREX2", dtConceptos)

                        '**********************PEREX3 - CALCULO DE LA PERCEPCION TRIPLE

                        PEREX3 = PEREX3 + (HRSEX3 * 3 * costo_x_hora)
                        '-- insertar en movimientos_calculo
                        If (PEREX3 <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PEREX3, tipo_nomina, tipo_periodo, "PEREX3", dtConceptos)


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
                        '-- insertar en movimientos_calculo
                        If (PEXEXT <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PEXEXT, tipo_nomina, tipo_periodo, "PEXEXT", dtConceptos)

                        '*************************************************FESLAB -- Percepción de Festivo laborado

                        FESLAB = FESLAB + (HRSFEL * 2 * costo_x_hora) ' NOTA: Es por el costo_x_hora ??
                        '-- insertar en movimientos_calculo
                        If (FESLAB <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, FESLAB, tipo_nomina, tipo_periodo, "FESLAB", dtConceptos)

                        '************************************************PRIANT -- Percepción de Prima de antiguedad
                        If (PRIANT <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PRIANT, tipo_nomina, tipo_periodo, "PRIANT", dtConceptos)

                        '************************************************INDEMN -- Percepción de indemnizacion
                        If (INDEMN <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, INDEMN, tipo_nomina, tipo_periodo, "INDEMN", dtConceptos)

                        '************************************************NOREST -- Percepción de No Restitucion
                        If (NOREST <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, NOREST, tipo_nomina, tipo_periodo, "NOREST", dtConceptos)

                        '**********************
                        Dim _90_minimos = UMA * 90
                        Dim _sobra_excento = _90_minimos * AntigEmpleado
                        Dim exento_prima_ant As Double = 0.0

                        '**********************PEXNOR - EXENTO DE NO RESTITUCION
                        Dim _exento_indemnizacion As Double = 0.0

                        If INDEMN > 0 Then

                            If INDEMN >= _sobra_excento Then
                                _exento_indemnizacion = _sobra_excento
                            Else
                                _exento_indemnizacion = INDEMN
                            End If

                            _sobra_excento = _sobra_excento - _exento_indemnizacion

                            PEXIND = _exento_indemnizacion
                        End If

                        acum_exento = acum_exento + PEXIND

                        '-- insertar en movimientos_calculo
                        If (PEXIND <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PEXNOR, tipo_nomina, tipo_periodo, "PEXIND", dtConceptos)

                        '**********************PEXPAN - EXENTO DE PRIMA DE ANTIGUEDAD

                        If PRIANT > 0 Then

                            If PRIANT >= _sobra_excento Then
                                exento_prima_ant = _sobra_excento
                            Else
                                exento_prima_ant = PRIANT
                            End If

                            _sobra_excento = _sobra_excento - exento_prima_ant

                            PEXPAN = exento_prima_ant

                        End If

                        acum_exento = acum_exento + PEXPAN

                        '-- insertar en movimientos_calculo
                        If (PEXPAN <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PEXPAN, tipo_nomina, tipo_periodo, "PEXPAN", dtConceptos)

                        '**********************PEXNOR - EXENTO DE NO RESTITUCION
                        Dim _exento_no_rest As Double = 0.0

                        If NOREST > 0 Then

                            If NOREST >= _sobra_excento Then
                                _exento_no_rest = _sobra_excento
                            Else
                                _exento_no_rest = NOREST
                            End If

                            _sobra_excento = _sobra_excento - _exento_no_rest

                            PEXNOR = _exento_no_rest
                        End If

                        acum_exento = acum_exento + PEXNOR
                        '-- insertar en movimientos_calculo
                        If (PEXNOR <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PEXNOR, tipo_nomina, tipo_periodo, "PEXNOR", dtConceptos)



                        '**********************PRIDOM - CALCULO DE PRIMA DOMINICAL

                        If (HRSDOM > 0) Then PRIDOM = PRIDOM + (sactual * 0.25)

                        '-- insertar en movimientos_calculo
                        If (PRIDOM <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PRIDOM, tipo_nomina, tipo_periodo, "PRIDOM", dtConceptos)

                        '**********************PEXDOM - Exento de prima dominical

                        Dim TopeExPrimDom As Double = 1 * UMA
                        If (PRIDOM >= TopeExPrimDom) Then PEXDOM += TopeExPrimDom
                        If (PRIDOM < TopeExPrimDom) Then PEXDOM += PRIDOM
                        acum_exento = acum_exento + PEXDOM

                        '-- insertar en movimientos_calculo
                        If (PEXDOM <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PEXDOM, tipo_nomina, tipo_periodo, "PEXDOM", dtConceptos)

                        '**********************PERVAC - CALCULO DE PERCEPCION DE VACACIONES

                        PERVAC = PERVAC + (DIASVA * sactual)

                        '-- insertar en movimientos_calculo
                        If (PERVAC <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PERVAC, tipo_nomina, tipo_periodo, "PERVAC", dtConceptos)

                        '**********************PRIVAC - CALCULO DE PERCEPCION DE PRIMA VACACIONAL

                        PRIVAC = PRIVAC + (DIASPV * sactual * privac_porc_aniv)

                        '-- insertar en movimientos_calculo
                        If (PRIVAC <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PRIVAC, tipo_nomina, tipo_periodo, "PRIVAC", dtConceptos)

                        '**********************PEXVAC - CALCULO EXENTO DE LA PRIMA VACACIONAL

                        Dim TopeExePriVac As Double = 15 * UMA
                        TopeExePriVac = TopeExePriVac - acumExeAnioPVac ' Se le resta el exento  que haya tenido ya en el año pagado
                        If (TopeExePriVac <= 0) Then TopeExePriVac = 0
                        If (PRIVAC >= TopeExePriVac) Then PEXVAC += TopeExePriVac
                        If (PRIVAC < TopeExePriVac) Then PEXVAC += PRIVAC
                        acum_exento = acum_exento + PEXVAC

                        '-- insertar en movimientos_calculo
                        If (PEXVAC <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PEXVAC, tipo_nomina, tipo_periodo, "PEXVAC", dtConceptos)


                        '**********************PERAGI - CALCULO DE PERCEPCION DE AGUINALDO

                        PERAGI = PERAGI + (DIASAG * sactual)

                        '-- insertar en movimientos_calculo
                        If (PERAGI <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PERAGI, tipo_nomina, tipo_periodo, "PERAGI", dtConceptos)


                        '********************** PEXAGI - CALCULO EXENTO  DEL AGUINALDO

                        Dim TopeExeAgui As Double = 30 * UMA
                        TopeExeAgui = TopeExeAgui - acumExeAnioAgui  ' Se le resta el exento que haya tenido en el anio
                        If (TopeExeAgui <= 0) Then TopeExeAgui = 0
                        If (PERAGI >= TopeExeAgui) Then PEXAGI += TopeExeAgui
                        If (PERAGI < TopeExeAgui) Then PEXAGI += PERAGI
                        acum_exento = acum_exento + PEXAGI

                        '-- insertar en movimientos_calculo
                        If (PEXAGI <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PEXAGI, tipo_nomina, tipo_periodo, "PEXAGI", dtConceptos)

                        '********************** DIASPA - DIAS PAGADOS

                        DIASPA = DIASPA + (Math.Round((PERNOR + SEPDIA + PERFES + PERVAC) / sactual, 2))

                        '-- insertar en movimientos_calculo
                        If (DIASPA <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, DIASPA, tipo_nomina, tipo_periodo, "DIASPA", dtConceptos)

                        '********************** RETROA - CALCULO DEL RETROACTIVO

                        '-- insertar en movimientos_calculo
                        If (RETROA <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, RETROA, tipo_nomina, tipo_periodo, "RETROA", dtConceptos)

                        '**********************LIFAHC y LIFAHE (Liquidacion de saldo de fondo de ahorro)

                        acum_exento = acum_exento + LIFAHC + LIFAHE

                        If (LIFAHC <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, LIFAHC, tipo_nomina, tipo_periodo, "LIFAHC", dtConceptos)

                        If (LIFAHE <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, LIFAHE, tipo_nomina, tipo_periodo, "LIFAHE", dtConceptos)

                        '**********************BONASI - Bono de asistencia  (Va venir calculado del T&A ?)
                        '-- insertar en movimientos_calculo
                        If (BONASI <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, BONASI, tipo_nomina, tipo_periodo, "BONASI", dtConceptos)

                        '**********************BONDES - Bono de despensa - No suma al neto y está como en ESPECIE

                        'Comentado para que no se genere automaticamente, no olvidar quitar comentario a DESEFE cuando
                        'se vuelva a utilizar este calculo
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


                        '-- insertar en movimientos_calculo
                        If (BONDES <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, BONDES, tipo_nomina, tipo_periodo, "BONDES", dtConceptos)


                        '**********************-DESEFE - Bono de despensa pagado en Efectivo
                        DESEFE += difTopeBondes

                        If (tipo_periodo = "C" And cod_tipo <> "G") Then DESEFE = 0

                        '-- insertar en movimientos_calculo
                        If (DESEFE <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, DESEFE, tipo_nomina, tipo_periodo, "DESEFE", dtConceptos)


                        '**********************BONPRO - BONO DE PRODUCTIVIDAD
                        '-- insertar en movimientos_calculo
                        If (BONPRO <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, BONPRO, tipo_nomina, tipo_periodo, "BONPRO", dtConceptos)

                        '**********************SEPUNI - Separación única

                        SEPUNI = SEPUNI + (DIAUNI * sactual)
                        '-- insertar en movimientos_calculo
                        If (SEPUNI <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, SEPUNI, tipo_nomina, tipo_periodo, "SEPUNI", dtConceptos)

                        '**********************PERPTU - CALCULO DEL PTU O UTILIDADES (PENDIENTE El calculo del PTU)
                        '-- insertar en movimientos_calculo
                        If (PERPTU <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PERPTU, tipo_nomina, tipo_periodo, "PERPTU", dtConceptos)


                        '**********************PEXPTU (Pendiente de obtener el exento del PTU)
                        '-- insertar en movimientos_calculo
                        If (PEXPTU <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PEXPTU, tipo_nomina, tipo_periodo, "PEXPTU", dtConceptos)

                        '**********************OTPGRA - Otras percepcones gravadas
                        If (OTPGRA <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, OTPGRA, tipo_nomina, tipo_periodo, "OTPGRA", dtConceptos)

                        '**********************OTPNOG - Otras percepciones No gravadas

                        acum_exento = acum_exento + OTPNOG

                        '-- insertar en movimientos_calculo
                        If (OTPNOG <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, OTPNOG, tipo_nomina, tipo_periodo, "OTPNOG", dtConceptos)


                        '**********************APOFAH (DEDUC) - CALCULO DE LA APORTACION DE FONDO DE AHORRO del empleado

                        Dim baseFah As Double = 0.0
                        Dim diasFah As Double = 0.0
                        Dim topeFah As Double = 0.0
                        Dim ExedeFah As Double = 0.0
                        'Comentado Para que no se agregue automaticamente
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

                        '-- insertar en movimientos_calculo
                        If (APOFAH <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, APOFAH, tipo_nomina, tipo_periodo, "APOFAH", dtConceptos)


                        '********************** EXEDFA (PERCEP) - Exedente de fondo de ahorro (Nota: Esta es una percepción que se le paga al empleado por el exedente que no alcanzó a dar por el tope del FAH)

                        EXEDFA += ExedeFah

                        If (tipo_periodo = "C" And cod_tipo <> "G") Then EXEDFA = 0

                        '-- insertar en movimientos_calculo
                        If (EXEDFA <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, EXEDFA, tipo_nomina, tipo_periodo, "EXEDFA", dtConceptos)


                        '********************** APOCIA (PERCEP) - Aportacion FAH Empresa, y es lo mismo que APOFAH (Deduc)

                        APOCIA += APOFAH

                        '-- insertar en movimientos_calculo
                        If (APOCIA <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, APOCIA, tipo_nomina, tipo_periodo, "APOCIA", dtConceptos)

                        '*********************** PEXFAH (Exento de APOCIA: Solo como Informativo, y es todo el importe de APOCIA) 

                        PEXFAH += APOCIA
                        acum_exento = acum_exento + PEXFAH
                        '-- insertar en movimientos_calculo
                        If (PEXFAH <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PEXFAH, tipo_nomina, tipo_periodo, "PEXFAH", dtConceptos)


                        '***********************APOFAC (Deduc) - Fondo de ahorro Empresa y es lo mismo que APOFAH(deduc)

                        APOFAC += APOFAH
                        '-- insertar en movimientos_calculo
                        If (APOFAC <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, APOFAC, tipo_nomina, tipo_periodo, "APOFAC", dtConceptos)

                        '**************************Carga lo que no esta en la lista inicial de conceptos
                        '--LAP NUEVO

                        For Each drRow As DataRow In dtNoEnlistado.Select("naturaleza = 'P'")

                            Dim CargarConcepto As String = ""
                            Dim CargarValor As Double = 0.0

                            Try : CargarConcepto = drRow("concepto").ToString.Trim : Catch ex As Exception : CargarConcepto = "" : End Try
                            Try : CargarValor = drRow("valor").ToString.Trim : Catch ex As Exception : CargarValor = 0 : End Try


                            If (CargarValor <> 0 And CargarConcepto.Trim <> "") Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, CargarValor, tipo_nomina, tipo_periodo, CargarConcepto, dtConceptos)

                        Next

                        '**********


                        '**********************TOTPER - CALCULO DEL TOTAL DE PERCEPCIONES
                        TOTPER = 0.0
                        TOTPER = acum_percep
                        '-- insertar en movimientos_calculo
                        '  If (TOTPER <> 0) Then puente(anio_empl, per_empl, reloj, TOTPER, tipo_nomina, tipo_periodo, "TOTPER", dtConceptos)
                        puente_finiquito(anio_empl, per_empl, reloj, finFolio, TOTPER, tipo_nomina, tipo_periodo, "TOTPER", dtConceptos)

                        '**********************PEREXE - CALCULO DEL TOTAL DE EXENTO
                        PEREXE = 0.0
                        PEREXE = acum_exento
                        '-- insertar en movimientos_calculo
                        If (PEREXE <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PEREXE, tipo_nomina, tipo_periodo, "PEREXE", dtConceptos)


                        '*********************PORCENTAJE DE IMPUESTO PARA LA NOREST Y PRIMA DE ANTIGUEDAD
                        ' Dim ispt_mensual_indemnizacion As Double = 0.0
                        Dim sueldo_mensual As Double = sactual * 30.4
                        Dim tasa_impuesto_indemnizacion As Double = 0.0
                        Dim gravado_indemnizacion As Double = 0.0

                        tasa_impuesto_indemnizacion = CalcISRSEP(sueldo_mensual, "Imp", "M")

                        gravado_indemnizacion = Math.Round(PRIANT + NOREST + INDEMN - PEXPAN - PEXNOR - PEXIND, 2)

                        '**********************PERGRA - CALCULO DEL TOTAL GRAVABLE
                        PERGRA = 0.0
                        PERGRA = TOTPER - PEREXE - gravado_indemnizacion
                        '-- insertar en movimientos_calculo
                        If (PERGRA <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PERGRA, tipo_nomina, tipo_periodo, "PERGRA", dtConceptos)

                        '**********************ISRSEP - IMPUESTO POR LIQUIDACION
                        ISRSEP = Math.Round(gravado_indemnizacion * tasa_impuesto_indemnizacion, 2)

                        If (ISRSEP <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, ISRSEP, tipo_nomina, tipo_periodo, "ISRSEP", dtConceptos)

                        '**********************ISPTRE - Cálculo del ISTP (ISR RETENIDO)
                        ISPTRE = 0.0
                        Dim aplica_ajsupe As Integer = 0
                        'If (Aj_Sub_Sem Or Aj_Sub_Cat) Then
                        '    aplica_ajsupe = 1
                        '    ACUMPERGRA += PERGRA
                        'End If

                        ISPTRE = CalcISR(reloj, PERGRA, "M", "Imp", DIASPA, dtAjuestesCalc, aplica_ajsupe, ACUMPERGRA)
                        If (ISPTRE <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, ISPTRE, tipo_nomina, tipo_periodo, "ISPTRE", dtConceptos)

                        '**********************SUBPAG  - Subsido al empleo Pagado
                        SUBPAG = 0.0
                        SUBPAG = subempleoPagado
                        If (SUBPAG <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, SUBPAG, tipo_nomina, tipo_periodo, "SUBPAG", dtConceptos)

                        '**********************ISPT   - ISR CAUSADO

                        ISPT += isrCausado
                        If (ISPT <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, ISPT, tipo_nomina, tipo_periodo, "ISPT", dtConceptos)

                        '**********************SUBCAU - SUBSIDIO CAUSADO

                        SUBCAU += subempleoCausado
                        If (SUBCAU <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, SUBCAU, tipo_nomina, tipo_periodo, "SUBCAU", dtConceptos)


                        '*********************AJSUPE - Ajuste al subsidio causado (Solo es informativo para saber cuando sub causado aplicó en el mes)

                        AJSUPE += subempleoCausado
                        '-- insertar en movimientos_calculo
                        If (AJSUPE <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, AJSUPE, tipo_nomina, tipo_periodo, "AJSUPE", dtConceptos)

                        '**********************DESINF - Calculo del descuento de INFONAVIT

                        If (tipo_cred_info <> "" And cuota_cred_info <> 0.0) Then
                            DESINF = DESINF + CalcInfonavit(reloj, tipo_cred_info, cuota_cred_info, tipo_nomina, tipo_periodo, UMA, DIASPA, UMI, integrado)
                        End If

                        '-- insertar en movimientos_calculo
                        If (DESINF <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, DESINF, tipo_nomina, tipo_periodo, "DESINF", dtConceptos)

                        '*********************SEGVIV - Seguro de la vivienda
                        'NOTA: Solo descontar una vez al bimestre cuando en INFONAVIT.cobro_segv = 1 y cuando es un nuevo credito de INFONAVIT.cobro_segv = True

                        'COMENTADO PARA QUE NO SE AGREGUE AUTOMATICAMENTE
                        If (cobro_segv) Then SEGVIV += cuota_segviv ' Si aplica el cobro de seg vivienda

                        '-- insertar en movimientos_calculo
                        If (SEGVIV <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, SEGVIV, tipo_nomina, tipo_periodo, "SEGVIV", dtConceptos)

                        '***********************ADEINF - Préstamo de infonavit
                        '-- insertar en movimientos_calculo
                        If (ADEINF <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, ADEINF, tipo_nomina, tipo_periodo, "ADEINF", dtConceptos)


                        '**********************IMSS - Descuento del IMSS
                        'COMENTADO PARA QUE NO SE AGREGUE AUTOMATICAMENTE

                        '--Para el cálculo de IMSS no se toma en cuenta las vacaciones
                        Dim dias_imss As Double = 0.0

                        dias_imss = dias_imss + (Math.Round((PERNOR + SEPDIA + PERFES) / sactual, 2))

                        IMSS = IMSS + CalcImss(anio_empl, per_empl, reloj, tipo_nomina, tipo_periodo, topeIntImss, dias_imss, UMA, prima_riesg_imss)

                        '-- insertar en movimientos_calculo
                        If (IMSS <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, IMSS, tipo_nomina, tipo_periodo, "IMSS", dtConceptos)

                        '**********************FNAALC - Préstamo de FONACOT
                        '-- insertar en movimientos_calculo
                        If (FNAALC <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, FNAALC, tipo_nomina, tipo_periodo, "FNAALC", dtConceptos)

                        '**********************CUOCAF - Descuento de cafetería

                        CUOCAF = CUOCAF + (DIACAF * 17)

                        '-- insertar en movimientos_calculo
                        If (CUOCAF <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, CUOCAF, tipo_nomina, tipo_periodo, "CUOCAF", dtConceptos)

                        '***********************ANTSUE - Anticipo de sueldo

                        '-- insertar en movimientos_calculo
                        If (ANTSUE <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, ANTSUE, tipo_nomina, tipo_periodo, "ANTSUE", dtConceptos)

                        '**********************PENALI - Pensión alimenticia 1
                        Dim basePens1 As Double = 0.0
                        basePens1 = (TOTPER - isrRetenido - IMSS - DESINF - APOFAH - ISRSEP) * (porcPens1 / 100)  ' NOTA: Falta incluir el ISRSEP (isr separacion)
                        PENALI = PENALI + basePens1
                        '-- insertar en movimientos_calculo
                        If (PENALI <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PENALI, tipo_nomina, tipo_periodo, "PENALI", dtConceptos)

                        '**********************PENAL2 - Pensión alimenticia 2
                        Dim basePens2 As Double = 0.0
                        basePens2 = (TOTPER - isrRetenido - IMSS - DESINF - APOFAH - ISRSEP) * (porcPens2 / 100)  ' NOTA: Falta incluir el ISRSEP (isr separacion)
                        PENAL2 = PENAL2 + basePens2
                        '-- insertar en movimientos_calculo
                        If (PENAL2 <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PENAL2, tipo_nomina, tipo_periodo, "PENAL2", dtConceptos)

                        '**********************PENAL3 - Pensión alimenticia 3
                        Dim basePens3 As Double = 0.0
                        basePens3 = (TOTPER - isrRetenido - IMSS - DESINF - APOFAH - ISRSEP) * (porcPens3 / 100)  ' NOTA: Falta incluir el ISRSEP (isr separacion)
                        PENAL3 = PENAL3 + basePens3
                        '-- insertar en movimientos_calculo
                        If (PENAL3 <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, PENAL3, tipo_nomina, tipo_periodo, "PENAL3", dtConceptos)

                        '**********************OTRASD  - Otras deducciones
                        '-- insertar en movimientos_calculo
                        If (OTRASD <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, OTRASD, tipo_nomina, tipo_periodo, "OTRASD", dtConceptos)

                        '**********************ABOPMO - Abono préstamo
                        '-- insertar en movimientos_calculo
                        If (ABOPMO <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, ABOPMO, tipo_nomina, tipo_periodo, "ABOPMO", dtConceptos)


                        '**************************Carga lo que no esta en la lista inicial de conceptos
                        '--LAP NUEVO

                        For Each drRow As DataRow In dtNoEnlistado.Select("naturaleza = 'D'")

                            Dim CargarConcepto As String = ""
                            Dim CargarValor As Double = 0.0

                            Try : CargarConcepto = drRow("concepto").ToString.Trim : Catch ex As Exception : CargarConcepto = "" : End Try
                            Try : CargarValor = drRow("valor").ToString.Trim : Catch ex As Exception : CargarValor = 0 : End Try


                            If (CargarValor <> 0 And CargarConcepto.Trim <> "") Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, CargarValor, tipo_nomina, tipo_periodo, CargarConcepto, dtConceptos)

                        Next

                        '**********


                        '**********************TOTDED - CALCULO DEL TOTAL DE DEDUCCIONES
                        TOTDED = 0.0
                        '    TOTDED = ISPTRE + SUBPAG + DESINF + IMSS + FNAALC + CUOCAF + APOFAH
                        TOTDED = acum_deduc
                        '-- insertar en movimientos_calculo
                        '   If (TOTDED <> 0) Then puente(anio_empl, per_empl, reloj, TOTDED, tipo_nomina, tipo_periodo, "TOTDED", dtConceptos)
                        puente_finiquito(anio_empl, per_empl, reloj, finFolio, TOTDED, tipo_nomina, tipo_periodo, "TOTDED", dtConceptos)

                        '**********************NETO - CALCULO DEL NETO
                        NETO = acum_neto
                        '-- insertar en movimientos_calculo
                        '  If (NETO <> 0) Then puente(anio_empl, per_empl, reloj, NETO, tipo_nomina, tipo_periodo, "NETO", dtConceptos)
                        puente_finiquito(anio_empl, per_empl, reloj, finFolio, NETO, tipo_nomina, tipo_periodo, "NETO", dtConceptos)

                        '**********************IMPEST - IMPUESTO ESTATAL (Solo como Informativo)
                        IMPEST = 0.0
                        IMPEST = (PERNOR + PERVAC + PEREX2 + PEREX3 + PRIDOM + PRIVAC + PERAGI + PRIANT + OTPGRA + OTPNOG) * (2.5 / 100)
                        If (IMPEST <> 0) Then puente_finiquito(anio_empl, per_empl, reloj, finFolio, IMPEST, tipo_nomina, tipo_periodo, "IMPEST", dtConceptos)
                    Next

                    ActivoTrabajando = False
                    frmTrabajando.Close()
                    frmTrabajando.Dispose()


                End If


            Else

                ActivoTrabajando = False
                frmTrabajando.Close()
                frmTrabajando.Dispose()
                MessageBox.Show("No hay un periodo en el cual se va procesar el finiquito", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Function

            End If
        Catch ex As Exception
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()
            Return 0
        End Try

    End Function


#End Region

    '*** fin Calculo finiquitos

#Region "CalculosDefault"

    Private Sub lclCalculoDefaultConcepto(ByVal Rj As String, ByVal FBaja As Date)
        Try

            Dim valor As String = FechaSQL(FBaja)
            Dim ExistsDIASVA As Integer = 0
            Dim ExistsDIASPV As Integer = 0
            Dim ExistsDIASAG As Integer = 0

            If (Rj <> "" And valor <> "") Then

                Dim dtEmp As New DataTable
                dtEmp = sqlExecute("SELECT '" & FechaSQL(AltaEmp.Value) & "' as alta,baja,cod_comp,ISNULL(cod_tipo,'') AS cod_tipo,ISNULL(tipo_periodo,'') AS tipo_periodo FROM personal WHERE reloj = '" & Rj & "'")

                '*****************Días de vacaciones
                Dim saldo_dinero As Double = 0.0
                Dim saldo_devengado As Double = 0.0
                Dim DiasVac As Double = 0.0
                Dim QSaldoDin As String = "SELECT TOP 1 saldo_dinero, saldo_tiempo FROM saldos_vacaciones WHERE comentario not in('BAJA') AND reloj = '" & Rj.Trim & _
                          "' ORDER BY fecha_captura DESC,fecha_fin DESC"
                Dim dtSaldoDin As DataTable = sqlExecute(QSaldoDin, "PERSONAL")

                If ((dtSaldoDin.Columns.Contains("Error")) Or (Not dtSaldoDin.Columns.Contains("Error") And dtSaldoDin.Rows.Count = 0)) Then
                    saldo_dinero = 0.0
                    GoTo CalcSaldoDev
                End If
                saldo_dinero = IIf(IsDBNull(dtSaldoDin.Rows(0).Item("saldo_dinero")), 0.0, dtSaldoDin.Rows(0).Item("saldo_dinero"))
CalcSaldoDev:
                '   saldo_devengado = VacacionesDevengadas(Rj.Trim, FBaja)
                saldo_devengado = CalculoDAgDVacDPrVac(dtEmp.Rows(0).Item("alta"), FBaja, dtEmp.Rows(0).Item("cod_tipo"), dtEmp.Rows(0).Item("cod_comp"), 1)
                DiasVac = Math.Round(saldo_dinero + saldo_devengado, 2)

                '******************Dias de prima vacacional
                Dim dias_prima_vac As Double = 0.0
                dias_prima_vac = CalculoDAgDVacDPrVac(dtEmp.Rows(0).Item("alta"), FBaja, dtEmp.Rows(0).Item("cod_tipo"), dtEmp.Rows(0).Item("cod_comp"), 2)

                '--La sig func es para los casos cuando se paga el finiquito y de acuerdo a la FBaja, la Fecha de aniv cae en ese rango, es decir, aun no se le paga, y la funcion hace que se le pague lo que le corresponde por aniv, mas
                '--la parte proporcional de prima que le toca despues de su aniv, por lo que a horita con la func de arriba, solo se  le paga esta parte propr de prima pero no toma en cuenta si se le pagó ya por aniv
                '  dias_prima_vac = CalcPrimaVacacional(Rj.Trim, dtEmp.Rows(0).Item("alta"), FBaja, dtEmp.Rows(0).Item("cod_tipo"), dtEmp.Rows(0).Item("cod_comp"), dtEmp.Rows(0).Item("tipo_periodo")) '2021-10-13 Nueva Funcion Luis Andrade para vacaciones de aniv ya pagadas


                '-----Días de Aguinaldo
                Dim dias_Aguinaldo As Double = 0.0
                dias_Aguinaldo = CalculoDAgDVacDPrVac(dtEmp.Rows(0).Item("alta"), FBaja, dtEmp.Rows(0).Item("cod_tipo"), dtEmp.Rows(0).Item("cod_comp"), 3)

                '--- Obtener periodo y empleados de nomina de aguinaldo pagada
                Dim QPerAgui As String = "select * from periodos where ano='" & Year(FBaja) & "' and observaciones like '%aguinaldo%' and PERIODO_ESPECIAL=1"
                Dim QNomAguiPag As String = ""
                Dim per_agui_pag As String = ""
                Dim dtPerAguiPag As DataTable = sqlExecute(QPerAgui, "TA")
                Dim dtEmplAguiPag As New DataTable

                If (Not dtPerAguiPag.Columns.Contains("Error") And dtPerAguiPag.Rows.Count > 0) Then
                    Try : per_agui_pag = dtPerAguiPag.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : per_agui_pag = "" : End Try

                    QNomAguiPag = "select * from movimientos where ano+periodo='" & Year(FBaja) & per_agui_pag & "' and concepto='PERAGI' and monto<>0 "
                    dtEmplAguiPag = sqlExecute(QNomAguiPag, "NOMINA")
                End If

                Dim aguiPag As Integer = 0

                If dtEmplAguiPag.Rows.Count > 0 Then
                    If (dtEmplAguiPag.Select("reloj='" & Rj.Trim & "'").Count > 0) Then aguiPag = 1
                End If

                If (aguiPag = 1) Then dias_Aguinaldo = 0

                '---------------------------------------

                Dim dtCopia As New DataTable

                Try
                    dtCopia = DirectCast(dgvConceptos.DataSource, DataTable)
                    Dim dtAgregar As New DataTable

                    If dtCopia.Rows.Count > 0 Then

                        ExistsDIASVA = dtCopia.AsEnumerable().Where(Function(conce) conce.Field(Of String)("concepto") = "DIASVA").Count()
                        ExistsDIASPV = dtCopia.AsEnumerable().Where(Function(conce) conce.Field(Of String)("concepto") = "DIASPV").Count()
                        ExistsDIASAG = dtCopia.AsEnumerable().Where(Function(conce) conce.Field(Of String)("concepto") = "DIASAG").Count()

                    End If

                    If DiasVac <> 0 Then

                        If Not ExistsDIASVA > 0 Then

                            dtAgregar = sqlExecute("select top 1 * from conceptos where concepto = 'DIASVA'", "NOMINA")
                            If dtAgregar.Rows.Count > 0 And Not dtAgregar.Columns.Contains("ERROR") Then

                                Dim drAgregar As DataRow = dtCopia.NewRow
                                drAgregar("concepto") = dtAgregar.Rows(0).Item("concepto").ToString.Trim
                                drAgregar("descripcion") = Trim(IIf(IsDBNull(dtAgregar.Rows(0).Item("nombre")), "", dtAgregar.Rows(0).Item("nombre")))
                                drAgregar("monto") = DiasVac
                                drAgregar("factor") = 0

                                dtCopia.Rows.Add(drAgregar)

                            End If

                        Else

                            Dim drConcepto As DataRow = dtCopia.Select("concepto = 'DIASVA'")(0)
                            drConcepto("monto") = DiasVac
                        End If

                    End If

                    If dias_prima_vac <> 0 Then

                        If Not ExistsDIASPV > 0 Then

                            dtAgregar = sqlExecute("select top 1 * from conceptos where concepto = 'DIASPV'", "NOMINA")
                            If dtAgregar.Rows.Count > 0 And Not dtAgregar.Columns.Contains("ERROR") Then

                                Dim drAgregar As DataRow = dtCopia.NewRow
                                drAgregar("concepto") = dtAgregar.Rows(0).Item("concepto").ToString.Trim
                                drAgregar("descripcion") = Trim(IIf(IsDBNull(dtAgregar.Rows(0).Item("nombre")), "", dtAgregar.Rows(0).Item("nombre")))
                                drAgregar("monto") = dias_prima_vac
                                drAgregar("factor") = 0

                                dtCopia.Rows.Add(drAgregar)

                            End If

                        Else

                            Dim drConcepto As DataRow = dtCopia.Select("concepto = 'DIASPV'")(0)
                            drConcepto("monto") = dias_prima_vac
                        End If

                    End If

                    If dias_Aguinaldo <> 0 Then

                        If Not ExistsDIASAG > 0 Then
                            dtAgregar = sqlExecute("select top 1 * from conceptos where concepto = 'DIASAG'", "NOMINA")
                            If dtAgregar.Rows.Count > 0 And Not dtAgregar.Columns.Contains("ERROR") Then

                                Dim drAgregar As DataRow = dtCopia.NewRow
                                drAgregar("concepto") = dtAgregar.Rows(0).Item("concepto").ToString.Trim
                                drAgregar("descripcion") = Trim(IIf(IsDBNull(dtAgregar.Rows(0).Item("nombre")), "", dtAgregar.Rows(0).Item("nombre")))
                                drAgregar("monto") = dias_Aguinaldo
                                drAgregar("factor") = 0

                                dtCopia.Rows.Add(drAgregar)

                            End If
                        Else
                            Dim drConcepto As DataRow = dtCopia.Select("concepto = 'DIASAG'")(0)
                            drConcepto("monto") = dias_Aguinaldo
                        End If

                    ElseIf aguiPag = 1 Then

                        Dim drConcepto As DataRow = Nothing
                        Try : drConcepto = dtCopia.Select("concepto = 'DIASAG'")(0) : Catch ex As Exception : drConcepto = Nothing : End Try

                        If Not drConcepto Is Nothing Then
                            dtCopia.Rows.Remove(drConcepto)
                        End If

                    End If

                    If swantiguedad.Value Then PrimaAntiguedad()
                    If swgratificacion.Value Then Gratificacion()
                    If swdiasano.Value Then NoRestitucion()

                    CargarMtroDed()


                    dgvConceptos.Refresh()

                Catch ex As Exception

                End Try

            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub PrimaAntiguedad()

        Dim prima_ant As Double = 0
        Dim sueldo_diario As Double = 0
        Dim sdo_priant As Double = 0
        Dim integrado As Double = 0
        Dim alta_antiguedad As Date = Nothing
        Dim minimo As Double = 0
        Dim tope As Double = 0
        Dim ant_con_proporcion As Double = 0


        Try
            If swantiguedad.Value Then

                With dtCompania.Rows(0)
                    sueldo_diario = IIf(IsDBNull(.Item("sactual")), 0, .Item("sactual"))
                    minimo = IIf(IsDBNull(.Item("minimo")), 0, .Item("minimo"))
                    alta_antiguedad = IIf(IsNothing(AntigEmp.Value), AltaEmp.Value, AntigEmp.Value)
                    integrado = IIf(IsDBNull(.Item("integrado")), 0, .Item("integrado"))
                End With



                Select Case cmbsueldoprima.Text

                    Case "Diario"

                        sdo_priant = sueldo_diario

                    Case "Integrado"

                        ' sdo_priant = IntegradoNatural(sueldo_diario)
                        sdo_priant = integrado
                End Select

                If sdo_priant > (minimo * 2) Then
                    tope = (minimo * 2)
                Else
                    tope = sdo_priant
                End If

                Dim dias_ant As Double = DateDiff(DateInterval.DayOfYear, alta_antiguedad, BajaFiniquito.Value) + 1
                'Dim dias_pan As Double = Math.Truncate(((12.0 / 365.0) * dias_ant) * 100) / 100.0

                Dim dias_pan As Double = (12.0 / 365.0) * dias_ant

                'ant_con_proporcion = Math.Truncate((dias_pan * tope) * 100.0) / 100.0

                ant_con_proporcion = (dias_pan * tope)

                prima_ant = Math.Round(ant_con_proporcion)

                'prima_ant = Math.Round(prima_ant, 2)

                If prima_ant > 0 Then

                    Dim Exists As Integer = 0
                    Dim copia As DataTable = DirectCast(dgvConceptos.DataSource, DataTable)
                    Exists = copia.AsEnumerable().Where(Function(conce) conce.Field(Of String)("concepto") = "PRIANT").Count

                    If Exists > 0 Then
                        Dim drMofificar As DataRow = copia.Select("concepto = 'PRIANT'")(0)
                        drMofificar("monto") = prima_ant

                    Else

                        Dim dtAgregar As DataTable = sqlExecute("select top 1 * from conceptos where concepto = 'PRIANT'", "NOMINA")
                        If dtAgregar.Rows.Count > 0 And Not dtAgregar.Columns.Contains("ERROR") Then


                            Dim drFila As DataRow = copia.NewRow
                            drFila("concepto") = dtAgregar.Rows(0).Item("concepto").ToString.Trim
                            drFila("descripcion") = Trim(IIf(IsDBNull(dtAgregar.Rows(0).Item("nombre")), "", dtAgregar.Rows(0).Item("nombre")))
                            drFila("monto") = prima_ant
                            drFila("factor") = 0

                            copia.Rows.Add(drFila)
                        Else
                            MessageBox.Show("Error al intentar agregar el concepto 'PRIANT'", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            swantiguedad.Value = False
                        End If


                    End If

                Else
                    MessageBox.Show("No se puede agregar la prima de antiguedad dado que el monto es: " & prima_ant.ToString, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    swantiguedad.Value = False
                End If

            Else

                Try
                    Dim copia As DataTable = DirectCast(dgvConceptos.DataSource, DataTable)
                    Dim drRow As DataRow = copia.Select("concepto ='PRIANT'")(0)
                    copia.Rows.Remove(drRow)
                Catch ex As Exception

                End Try



            End If


        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar calcular la prima de antiguedad del empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NoRestitucion()

        Dim no_rest As Double = 0
        Dim sueldo_diario As Double = 0
        Dim sdo_norest As Double = 0
        Dim alta_antiguedad As Date = Nothing
        Dim ant_norest As Double = 0
        Dim integrado As Double = 0

        Try

            If swdiasano.Value Then

                With dtCompania.Rows(0)
                    sueldo_diario = IIf(IsDBNull(.Item("sactual")), 0, .Item("sactual"))
                    alta_antiguedad = IIf(IsDBNull(.Item("alta_vacacion")), .Item("alta"), .Item("alta_vacacion"))
                    integrado = IIf(IsDBNull(.Item("integrado")), 0, .Item("integrado"))
                End With

                Select Case cmbsueldodias.Text

                    Case "Diario"

                        sdo_norest = sueldo_diario

                    Case "Integrado"

                        'sdo_norest = IntegradoNatural(sueldo_diario)
                        sdo_norest = integrado
                End Select


                Dim dias_norest As Double = DateDiff(DateInterval.Day, alta_antiguedad, BajaFiniquito.Value) + 1
                Dim anios_laborados As Double = dias_norest / 365.0

                ' ant_norest = IIf(anios_laborados < 1, 1, anios_laborados)

                ant_norest = anios_laborados * 20.0

                ' no_rest = ant_norest * 20 * sdo_norest

                no_rest = (ant_norest * sdo_norest)

                If no_rest > 0 Then

                    Dim Exists As Integer = 0
                    Dim copia As DataTable = DirectCast(dgvConceptos.DataSource, DataTable)
                    Exists = copia.AsEnumerable().Where(Function(conce) conce.Field(Of String)("concepto") = "NOREST").Count

                    If Exists > 0 Then
                        Dim drMofificar As DataRow = copia.Select("concepto = 'NOREST'")(0)
                        drMofificar("monto") = no_rest

                    Else

                        Dim dtAgregar As DataTable = sqlExecute("select top 1 * from conceptos where concepto = 'NOREST'", "NOMINA")
                        If dtAgregar.Rows.Count > 0 And Not dtAgregar.Columns.Contains("ERROR") Then


                            Dim drFila As DataRow = copia.NewRow
                            drFila("concepto") = dtAgregar.Rows(0).Item("concepto").ToString.Trim
                            drFila("descripcion") = Trim(IIf(IsDBNull(dtAgregar.Rows(0).Item("nombre")), "", dtAgregar.Rows(0).Item("nombre")))
                            drFila("monto") = no_rest
                            drFila("factor") = 0

                            copia.Rows.Add(drFila)
                        Else
                            MessageBox.Show("Error al intentar agregar el concepto 'NOREST'", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            swdiasano.Value = False
                        End If


                    End If

                Else
                    MessageBox.Show("No se puede agregar la no restitución dado que el monto es: " & no_rest.ToString, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    swdiasano.Value = False
                End If

            Else

                Try
                    Dim copia As DataTable = DirectCast(dgvConceptos.DataSource, DataTable)
                    Dim drRow As DataRow = copia.Select("concepto ='NOREST'")(0)
                    copia.Rows.Remove(drRow)
                Catch ex As Exception

                End Try

            End If


        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar calcular la no restitución del empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Gratificacion()

        Dim gratificacion As Double = 0
        Dim sueldo_diario As Double = 0
        Dim sdo_gratificacion As Double = 0
        Dim dias_gratificacion As Double = 0
        Dim integrado As Double = 0

        Try


            If swgratificacion.Value Then

                With dtCompania.Rows(0)
                    sueldo_diario = IIf(IsDBNull(.Item("sactual")), 0, .Item("sactual"))
                    integrado = IIf(IsDBNull(.Item("integrado")), 0, .Item("integrado"))
                End With

                Select Case cmbsueldograf.Text

                    Case "Diario"

                        sdo_gratificacion = sueldo_diario

                    Case "Integrado"

                        '  sdo_gratificacion = IntegradoNatural(sueldo_diario)
                        sdo_gratificacion = integrado
                End Select

                dias_gratificacion = IIf(IsDBNull(txtNumGratificacion.Value), 0, txtNumGratificacion.Value)

                gratificacion = sdo_gratificacion * dias_gratificacion

                If gratificacion > 0 Then

                    Dim Exists As Integer = 0
                    Dim copia As DataTable = DirectCast(dgvConceptos.DataSource, DataTable)
                    Exists = copia.AsEnumerable().Where(Function(conce) conce.Field(Of String)("concepto") = "INDEMN").Count

                    If Exists > 0 Then
                        Dim drMofificar As DataRow = copia.Select("concepto = 'INDEMN'")(0)
                        drMofificar("monto") = gratificacion

                    Else

                        Dim dtAgregar As DataTable = sqlExecute("select top 1 * from conceptos where concepto = 'INDEMN'", "NOMINA")
                        If dtAgregar.Rows.Count > 0 And Not dtAgregar.Columns.Contains("ERROR") Then


                            Dim drFila As DataRow = copia.NewRow
                            drFila("concepto") = dtAgregar.Rows(0).Item("concepto").ToString.Trim
                            drFila("descripcion") = Trim(IIf(IsDBNull(dtAgregar.Rows(0).Item("nombre")), "", dtAgregar.Rows(0).Item("nombre")))
                            drFila("monto") = gratificacion
                            drFila("factor") = 0

                            copia.Rows.Add(drFila)
                        Else
                            MessageBox.Show("Error al intentar agregar el concepto 'GRATIF'", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            swgratificacion.Value = False
                        End If


                    End If


                Else
                    ' MessageBox.Show("No se puede agregar la gratificación dado que el monto es: " & gratificacion.ToString, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If


            Else

                Try
                    Dim copia As DataTable = DirectCast(dgvConceptos.DataSource, DataTable)
                    Dim drRow As DataRow = copia.Select("concepto ='INDEMN'")(0)
                    copia.Rows.Remove(drRow)
                Catch ex As Exception

                End Try

            End If

        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar calcular la gratificación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarMtroDed()

        Dim lclTipoPeriodo As String = ""
        Dim tabla As String = ""

        Try

            ano_mtro_ded = ""
            per_mtro_ded = ""
            numcred_mtro_ded = ""

            Try : lclTipoPeriodo = dtRegistro.Rows(0).Item("tipo_periodo").ToString.Trim : Catch : lclTipoPeriodo = "" : End Try


            If (lclTipoPeriodo = "S") Then tabla = "TA.dbo.periodos"
            If (lclTipoPeriodo = "C") Then tabla = "TA.dbo.periodos_catorcenal"

            tabla = "TA.dbo.periodos"

            'dtMaestroDeducciones = sqlExecute("with T0 as ( " & vbCr & _
            '"select * " & vbCr & _
            '"from conceptos " & vbCr & _
            '"where finiquito = 1 and rtrim(ltrim(isnull(alias_mtro_ded,''))) <> '' " & vbCr & _
            '"),T1 as( " & vbCr & _
            '"select reloj, max(ano) as ano, max(periodo) as periodo " & vbCr & _
            '"from mtro_ded " & vbCr & _
            '"where exists(select * from " & tabla & " TAperiodos where TAperiodos.ano = mtro_ded.ano and TAperiodos.periodo = mtro_ded.periodo and isnull(periodo_especial,0) = 0) " & vbCr & _
            '"and reloj = '" & txtReloj.Text.Trim & "' " & vbCr & _
            '"group by reloj " & vbCr & _
            '"),T2 as ( " & vbCr & _
            '"select * " & vbCr & _
            '"from mtro_ded " & vbCr & _
            '"where exists(select * from T1 where T1.RELOJ = mtro_ded.RELOJ and T1.ano = mtro_ded.ANO and T1.periodo = mtro_ded.PERIODO)" & vbCr & _
            '"),T3 as (" & vbCr & _
            '"select * from T2 where exists(select concepto from T0 where ltrim(rtrim(T2.CONCEPTO)) = ltrim(rtrim(T0.alias_mtro_ded)))" & vbCr & _
            '") select ltrim(rtrim(T0.cod_naturaleza)) as 'cod_naturaleza',ltrim(rtrim(T0.CONCEPTO)) as 'concepto',isnull(T3.SALDO_ACT,0) as 'SALDO_ACT' from T0 inner join T3 on T0.alias_mtro_ded = T3.CONCEPTO", "NOMINA")

            'dtMaestroDeducciones = sqlExecute("with T0 as ( " & vbCr & _
            '"select * " & vbCr & _
            '"from conceptos " & vbCr & _
            '"where finiquito = 1 and rtrim(ltrim(isnull(alias_mtro_ded,''))) <> '' " & vbCr & _
            '"),T1 as( " & vbCr & _
            '"select reloj, max(ano) as ano, max(periodo) as periodo " & vbCr & _
            '"from mtro_ded " & vbCr & _
            '"where exists(select * from " & tabla & " TAperiodos where TAperiodos.ano = mtro_ded.ano and TAperiodos.periodo = mtro_ded.periodo and isnull(periodo_especial,0) = 0) " & vbCr & _
            '"and reloj = '" & txtReloj.Text.Trim & "' " & vbCr & _
            '"group by reloj " & vbCr & _
            '"),T2 as ( " & vbCr & _
            '"select * " & vbCr & _
            '"from mtro_ded " & vbCr & _
            '"where exists(select * from T1 where T1.RELOJ = mtro_ded.RELOJ and T1.ano = mtro_ded.ANO and T1.periodo = mtro_ded.PERIODO)" & vbCr & _
            '"),T3 as (" & vbCr & _
            '"select * from T2 where exists(select concepto from T0 where ltrim(rtrim(T2.CONCEPTO)) = ltrim(rtrim(T0.alias_mtro_ded)))" & vbCr & _
            '") select T3.ANO,T3.PERIODO,T3.NUMCREDITO,ltrim(rtrim(T0.cod_naturaleza)) as 'cod_naturaleza',ltrim(rtrim(T0.CONCEPTO)) as 'concepto',isnull(T3.SALDO_ACT,0) as 'SALDO_ACT' from T0 inner join T3 on T0.alias_mtro_ded = T3.CONCEPTO", "NOMINA")


            dtMaestroDeducciones = sqlExecute("with T0 as ( " & vbCr & _
       "select * " & vbCr & _
       "from conceptos " & vbCr & _
       "where finiquito = 1 and rtrim(ltrim(isnull(alias_mtro_ded,''))) <> '' " & vbCr & _
       "),T1 as( " & vbCr & _
       "select * from(" & vbCr & _
       "select reloj, max(ano) as ano, max(periodo) as periodo " & vbCr & _
       "from mtro_ded " & vbCr & _
       "where isnull([STATUS],0) = 1 and isnull(SALDO_ACT,0) > 0 " & vbCr & _
       "and reloj = '" & txtReloj.Text.Trim & "' " & vbCr & _
       "group by reloj,ano,PERIODO)tbPendientes" & vbCr & _
       "),T2 as ( " & vbCr & _
       "select * " & vbCr & _
       "from mtro_ded " & vbCr & _
       "where exists(select * from T1 where T1.RELOJ = mtro_ded.RELOJ and T1.ano = mtro_ded.ANO and T1.periodo = mtro_ded.PERIODO)" & vbCr & _
       "),T3 as (" & vbCr & _
       "select * from T2 where exists(select concepto from T0 where ltrim(rtrim(T2.CONCEPTO)) = ltrim(rtrim(T0.alias_mtro_ded)))" & vbCr & _
       ") select T3.ANO,T3.PERIODO,T3.NUMCREDITO,ltrim(rtrim(T0.cod_naturaleza)) as 'cod_naturaleza',ltrim(rtrim(T0.CONCEPTO)) as 'concepto',isnull(T3.SALDO_ACT,0) as 'SALDO_ACT' from T0 inner join T3 on T0.alias_mtro_ded = T3.CONCEPTO order by ano desc, PERIODO desc", "NOMINA")

            If dtMaestroDeducciones.Rows.Count > 0 Then

                Dim copia As DataTable = DirectCast(dgvConceptos.DataSource, DataTable)

                Try : ano_mtro_ded = dtMaestroDeducciones.Rows(0)("ANO") : Catch ex As Exception : ano_mtro_ded = "" : End Try
                Try : per_mtro_ded = dtMaestroDeducciones.Rows(0)("PERIODO") : Catch ex As Exception : per_mtro_ded = "" : End Try
                Try : numcred_mtro_ded = dtMaestroDeducciones.Rows(0)("NUMCREDITO") : Catch ex As Exception : numcred_mtro_ded = "" : End Try

                For Each Row As DataRow In dtMaestroDeducciones.Rows
                    Dim Exists As Integer = 0
                    Dim BuscarConcepto As String = ""
                    Dim sal_act As Double = 0.0

                    Try : BuscarConcepto = Row("concepto").ToString.Trim : Catch ex As Exception : BuscarConcepto = "" : End Try
                    Try : sal_act = Row("SALDO_ACT") : Catch ex As Exception : sal_act = 0.0 : End Try

                    Exists = copia.AsEnumerable().Where(Function(conce) conce.Field(Of String)("concepto") = BuscarConcepto).Count

                    If Exists > 0 Then

                        If sal_act <> 0 Then
                            Dim drMofificar As DataRow = copia.Select("concepto = '" & BuscarConcepto & "'")(0)
                            drMofificar("monto") = sal_act
                        End If

                    Else

                        If sal_act <> 0 And BuscarConcepto.Trim <> "" Then

                            Dim dtAgregar As DataTable = sqlExecute("select top 1 * from conceptos where concepto = '" & BuscarConcepto & "'", "NOMINA")
                            If dtAgregar.Rows.Count > 0 And Not dtAgregar.Columns.Contains("ERROR") Then
                                Dim drFila As DataRow = copia.NewRow
                                drFila("concepto") = dtAgregar.Rows(0).Item("concepto").ToString.Trim
                                drFila("descripcion") = Trim(IIf(IsDBNull(dtAgregar.Rows(0).Item("nombre")), "", dtAgregar.Rows(0).Item("nombre")))
                                drFila("monto") = sal_act
                                drFila("factor") = 0

                                copia.Rows.Add(drFila)
                            End If

                        End If

                    End If

                Next

            End If


        Catch ex As Exception
            ano_mtro_ded = ""
            per_mtro_ded = ""
            numcred_mtro_ded = ""
        End Try

    End Sub

    Private Function IntegradoNatural(ByVal sactual As Double) As Double

        Dim resultado As Double = 0
        Dim sueldo_actual As Double = 0
        Dim factor_integracion As Double = 0
        Dim int_vac_agui As Double = 0
        Dim calc_despensa As Double = 0
        Dim calc_fondo_ahorro As Double = 0

        Try
            With dtCompania.Rows(0)
                factor_integracion = IIf(IsDBNull(.Item("factor_int")), 0, .Item("factor_int"))
            End With

            sueldo_actual = sactual
            int_vac_agui = sueldo_actual * factor_integracion * 30
            calc_despensa = sueldo_actual * 30 * 0.1
            calc_fondo_ahorro = (sueldo_actual * 30 * 9.4) / 100.0
            resultado = (int_vac_agui + calc_despensa + calc_fondo_ahorro) / 30.0


        Catch ex As Exception
            resultado = 0
        End Try

        Return resultado
    End Function

 

#End Region


    Private Sub MostrarInformacion()

        Dim dtPeriodoActual As New DataTable
        Dim drRegistro As DataRow = Nothing

        Dim strSql1 As String = ""
        Dim tiposueldo As String = ""
        Dim _aplica_ajuste As Integer = 0
        Dim _tipo_ajuste As String = ""
        Dim _cantidad As Double = 0
        Dim CampAntigPer As String = ""
        Dim _TipoPeriodo As String = ""
        Dim etiquetaPeriodo As String = ""

        Try

            If dtRegistro.Rows.Count > 0 And (Clave = "EDIT" Or Clave = "NVO") Then

                drRegistro = dtRegistro.Rows(0)

                txtReloj.Text = dtRegistro.Rows(0).Item("reloj")
                txtNombre.Text = dtRegistro.Rows(0).Item("nombres")

                AltaEmp.ValueObject = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("alta")), Nothing, dtRegistro.Rows(0).Item("alta")))

                sFechaAltaEmpleado = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("alta")), "", dtRegistro.Rows(0).Item("alta")))

                If Clave = "NVO" Then
                    CampAntigPer = "alta_vacacion"
                Else
                    CampAntigPer = "alta_antig"
                End If

                AntigEmp.ValueObject = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item(CampAntigPer)), AltaEmp.ValueObject, dtRegistro.Rows(0).Item(CampAntigPer)))

                TipoEmp = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("cod_tipo")), "", dtRegistro.Rows(0).Item("cod_tipo")))

                _TipoPeriodo = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("tipo_periodo")), "", dtRegistro.Rows(0).Item("tipo_periodo")))

                BajaFiniquito.ValueObject = Nothing

                strSql1 = ""

                If Clave = "NVO" Then

                    BajaFiniquito.ValueObject = Now

                    Dim tabla As String = ""

                    If TipoEmp.Trim.ToUpper = "O" Then
                        tabla = "periodos"
                        etiquetaPeriodo = "Semanal - "
                    ElseIf TipoEmp.Trim.ToUpper = "G" Or TipoEmp.Trim.ToUpper = "A" Then
                        tabla = "periodos_catorcenal"
                        etiquetaPeriodo = "Catorcenal - "
                    Else
                        lblPeriododeCaptura.Text = "Periodo de captura: "
                    End If

                    dtPeriodoActual = sqlExecute("select top 1 * from " & tabla & " where convert(date,getdate()) between FECHA_INI and FECHA_FIN and isnull(PERIODO_ESPECIAL,0) = 0", "TA")

                    txtPeriodoCalculo.Text = dtPeriodoActual.Rows(0).Item("ano").ToString.Trim & "-" & dtPeriodoActual.Rows(0).Item("periodo").ToString.Trim

                    Try
                        Dim etiqueta As String = etiquetaPeriodo & Split(txtPeriodoCalculo.Text.Trim, "-")(0) & Split(txtPeriodoCalculo.Text.Trim, "-")(1)
                        lblPeriododeCaptura.Text = "Periodo de captura: " & etiqueta
                    Catch ex As Exception
                        lblPeriododeCaptura.Text = "Periodo de captura:"
                        txtPeriodoCalculo.Text = ""
                    End Try


                    dtNominaBaseProcesada = NominaBase()

                    If TipoEmp.ToUpper.Equals("O") Then

                        lblTipoNomProcesada.Text = "Periodo última nómina semanal procesada"

                        dtPeriodos = dtNominaBaseProcesada

                    ElseIf TipoEmp.ToUpper.Equals("A") Or TipoEmp.ToUpper.Equals("G") Then

                        lblTipoNomProcesada.Text = "Periodo última nómina catorcenal procesada"

                        dtPeriodos = dtNominaBaseProcesada

                    Else

                        lblTipoNomProcesada.Text = "Periodo última nómina procesada"

                        dtPeriodos = dtNominaBaseProcesada
                    End If

                    If dtPeriodos.Columns.Contains("ERROR") Then

                        MessageBox.Show("Se presentó un error al intentar cargar la última nómina procesada", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        cmbPeriodos.SelectedIndex = -1

                    ElseIf Not dtPeriodos.Rows.Count > 0 Then

                        MessageBox.Show("No se localizó la última nómina procesada del empleado '" & txtNombre.Text.Trim & "'.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)


                    Else
                        cmbPeriodos.DataSource = dtPeriodos
                        cmbPeriodos.ValueMember = "unico"
                        cmbPeriodos.DisplayMembers = "unico,año,periodo,fecha_ini,fecha_fin"
                    End If

                    Try
                        cmbPeriodos.SelectedIndex = IIf(dtPeriodos.Rows.Count > 0, 0, -1)
                    Catch ex As Exception
                        sUltimaNominaProcesada = ""
                    End Try

                ElseIf Clave = "EDIT" Then

                    If TipoEmp.ToUpper.Equals("O") Then

                        'strSql1 = "select top 1 (ano+periodo) as 'unico',ano as 'año',periodo,fecha_ini,fecha_fin" & _
                        '    " from periodos" & _
                        '    " where (ano+periodo) = '" & drRegistro("ano") & drRegistro("periodo") & "'"

                        strSql1 = "select top 1 (ano+periodo) as 'unico',ano as 'año',periodo,fecha_ini,fecha_fin" & _
                            " from periodos" & _
                            " where (ano+periodo) = '" & IIf(IsDBNull(drRegistro("ultimanomina")), "", drRegistro("ultimanomina")) & "'"


                        lblTipoNomProcesada.Text = "Periodo última nómina semanal procesada"

                    ElseIf TipoEmp.ToUpper.Equals("A") Or TipoEmp.ToUpper.Equals("G") Then

                        'strSql1 = "select top 1 (ano+periodo) as 'unico',ano as 'año',periodo,fecha_ini,fecha_fin" & _
                        '    " from periodos_catorcenal" & _
                        '    " where (ano+periodo) = '" & drRegistro("ano") & drRegistro("periodo") & "'"

                        strSql1 = "select top 1 (ano+periodo) as 'unico',ano as 'año',periodo,fecha_ini,fecha_fin" & _
                            " from periodos_catorcenal" & _
                            " where (ano+periodo) = '" & IIf(IsDBNull(drRegistro("ultimanomina")), "", drRegistro("ultimanomina")) & "'"

                        lblTipoNomProcesada.Text = "Periodo última nómina catorcenal procesada"

                    Else

                        strSql1 = "select top 1 (ano+periodo) as 'unico',ano as 'año',periodo,fecha_ini,fecha_fin" & _
                            " from periodos" & _
                            " where 1 = 0"

                        lblTipoNomProcesada.Text = "Periodo última nómina procesada"


                    End If

                    dtPeriodos = sqlExecute(strSql1, "TA")

                    If dtPeriodos.Columns.Contains("ERROR") Then

                        MessageBox.Show("Se presentó un error al intentar cargar la última nómina procesada", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        cmbPeriodos.SelectedIndex = -1

                    ElseIf Not dtPeriodos.Rows.Count > 0 Then

                        MessageBox.Show("No se localizó la última nómina procesada del empleado '" & txtNombre.Text.Trim & "'", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        cmbPeriodos.SelectedIndex = -1

                    Else

                        cmbPeriodos.DataSource = dtPeriodos
                        cmbPeriodos.ValueMember = "unico"
                        cmbPeriodos.DisplayMembers = "unico,año,periodo,fecha_ini,fecha_fin"

                        cmbPeriodos.SelectedIndex = 0
                    End If

                Else

                    dtPeriodos.Clear()

                End If


                dtCompania = sqlExecute("select cias.*,personalvw.cod_tipo,personalvw.reloj,personalvw.nombres,personalvw.sactual,personalvw.integrado,personalvw.factor_int,personalvw.alta,personalvw.alta_vacacion,personalvw.cod_hora,personalvw.cod_area,personalvw.FAH_PARTIC,personalvw.FAH_PORCEN from personalvw left join cias on personalvw.cod_comp = cias.cod_comp where reloj = '" & txtReloj.Text.Trim & "'")

                If Clave = "NVO" Then
                    swantiguedad.Value = True
                    PrimaAntiguedad()
                    txtNumGratificacion.Value = 90
                    Exit Sub
                End If



                txtFolio.Text = dtRegistro.Rows(0).Item("folio").ToString
                frmCalcFiniquito.FolioSeleccionado = txtFolio.Text.Trim
                BajaFiniquito.ValueObject = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("baja_fin")), Nothing, dtRegistro.Rows(0).Item("baja_fin")))
                txtNumCheque.Text = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("num_cheque")), "", dtRegistro.Rows(0).Item("num_cheque")))
                strPeriodo = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("ano")), "", dtRegistro.Rows(0).Item("ano")))
                strPeriodo &= Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("periodo")), "", dtRegistro.Rows(0).Item("periodo")))

                '*** NUEVO - 2020-10-15
                Try : ano_mtro_ded = dtRegistro.Rows(0)("ano_mtro_ded") : Catch ex As Exception : ano_mtro_ded = "" : End Try
                Try : per_mtro_ded = dtRegistro.Rows(0)("per_mtro_ded") : Catch ex As Exception : per_mtro_ded = "" : End Try
                '*** ENDS

                Dim tmpPer As String = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("ano")), "", dtRegistro.Rows(0).Item("ano")))
                tmpPer &= "-" & Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("periodo")), "", dtRegistro.Rows(0).Item("periodo")))

                If TipoEmp.Trim.ToUpper = "O" Then
                    etiquetaPeriodo = "Semanal - " & tmpPer.Replace("-", "")
                    lblPeriododeCaptura.Text = "Periodo de captura: " & etiquetaPeriodo
                ElseIf TipoEmp.Trim.ToUpper = "G" Or TipoEmp.Trim.ToUpper = "A" Then
                    etiquetaPeriodo = "Catorcenal - " & tmpPer.Replace("-", "")
                    lblPeriododeCaptura.Text = "Periodo de captura: " & etiquetaPeriodo
                Else
                    lblPeriododeCaptura.Text = "Periodo de captura: "
                End If

                txtPeriodoCalculo.Text = tmpPer

                'cmbPeriodos.SelectedValue = strPeriodo

                Dim UltimaNominaProc As String = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("ultimanomina")), "", dtRegistro.Rows(0).Item("ultimanomina")))

                If UltimaNominaProc.Trim = "" And cmbPeriodos.SelectedIndex >= 0 Then
                    sqlExecute("update nomina_calculo set ultimanomina = '" & cmbPeriodos.SelectedValue.ToString.Trim & "' where (ano+periodo) = '" & strPeriodo & "' and folio = '" & txtFolio.Text.Trim & "'", "NOMINA")
                End If

                swantiguedad.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("prima_antig")), 0, dtRegistro.Rows(0).Item("prima_antig"))

                tiposueldo = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("tipo_sdo_antig")), "", dtRegistro.Rows(0).Item("tipo_sdo_antig")))

                If tiposueldo = "" Or tiposueldo = "Diario" Then
                    cmbsueldoprima.SelectedIndex = 0
                ElseIf tiposueldo = "Integrado" Then
                    cmbsueldoprima.SelectedIndex = 1
                Else
                    cmbsueldoprima.SelectedIndex = 0
                End If

                swgratificacion.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("gratificacion")), 0, dtRegistro.Rows(0).Item("gratificacion"))

                tiposueldo = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("tipo_sdo_grati")), "", dtRegistro.Rows(0).Item("tipo_sdo_grati")))

                If tiposueldo = "" Or tiposueldo = "Diario" Then
                    cmbsueldograf.SelectedIndex = 0
                ElseIf tiposueldo = "Integrado" Then
                    cmbsueldograf.SelectedIndex = 1
                Else
                    cmbsueldograf.SelectedIndex = 0
                End If

                txtNumGratificacion.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("dias_grati")), 0, dtRegistro.Rows(0).Item("dias_grati"))

                swdiasano.Value = IIf(IsDBNull(dtRegistro.Rows(0).Item("20diasano")), 0, dtRegistro.Rows(0).Item("20diasano"))
                tiposueldo = Trim(IIf(IsDBNull(dtRegistro.Rows(0).Item("tipo_sdo_rest")), "", dtRegistro.Rows(0).Item("tipo_sdo_rest")))

                If tiposueldo = "" Or tiposueldo = "Integrado" Then
                    cmbsueldodias.SelectedIndex = 1
                ElseIf tiposueldo = "Diario" Then
                    cmbsueldodias.SelectedIndex = 0
                Else
                    cmbsueldodias.SelectedIndex = 1
                End If

                dtConcGrid = sqlExecute("select ltrim(rtrim(concepto)) as concepto,ltrim(rtrim(descripcion)) as descripcion,monto,factor from ajustes_calculo where folio = '" & dtRegistro.Rows(0).Item("folio") & "' and reloj = '" & dtRegistro.Rows(0).Item("reloj") & "' and (ano+periodo) = '" & strPeriodo & "'", "NOMINA")

                dtConcGrid.DefaultView.Sort = "concepto"

                dgvConceptos.DataSource = dtConcGrid

                dtConceMovimientos = sqlExecute("select ltrim(rtrim(mov.Concepto)) as 'concepto' ,ltrim(rtrim(conceptos.NOMBRE)) as 'descripcion',convert(decimal(38,2),mov.Monto) as 'monto'" & vbCr & _
                                                "from movimientos_calculo mov left join conceptos on mov.Concepto = conceptos.CONCEPTO where folio = '" & dtRegistro.Rows(0).Item("folio") & "' and reloj = '" & dtRegistro.Rows(0).Item("reloj") & "' and (ano+periodo) = '" & strPeriodo & "'", "NOMINA")

                dgMovimientos.DataSource = dtConceMovimientos
            Else

            End If

        Catch ex As Exception

            MessageBox.Show("Se presentó un error al intentar cargar la información completa del empleado.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub

    Private Function NominaBase() As DataTable

        Dim frm As New frmTrabajando

        Dim dtNominaBase As New DataTable
        Dim dtDatos As New DataTable

        Dim strSQL As String = ""

        Try

            dtNominaBase.Columns.Add("unico", GetType(System.String))
            dtNominaBase.Columns.Add("año", GetType(System.String))
            dtNominaBase.Columns.Add("periodo", GetType(System.String))
            dtNominaBase.Columns.Add("fecha_ini", GetType(System.String))
            dtNominaBase.Columns.Add("fecha_fin", GetType(System.String))

            EsAltaMayorAperiodo = False

            strSQL = "declare @Reloj varchar(max) = '" & txtReloj.Text.Trim & "';" & vbCr & _
                            "declare @Alta char(10) = '" & sFechaAltaEmpleado & "';" & vbCr

            Select Case TipoEmp.Trim.ToUpper

                Case Is = "O"

                    'strSQL &= "with S0 as (" & vbCr & _
                    '    "select top 1 (ano+periodo) as 'unico',ano as 'año',periodo,fecha_ini,fecha_fin, 'N' as 'Alta_Mayor' " & vbCr & _
                    '    "from periodos " & vbCr & _
                    '    "WHERE  (ano+periodo) in (select distinct (ano+periodo) as 'periodo' from nomina.dbo.nomina where reloj = @Reloj) and  (periodo_especial IS NULL OR periodo_especial = 0)" & vbCr & _
                    '    "ORDER BY ano DESC,periodo DESC" & vbCr & _
                    '    "),S1 as (" & vbCr & _
                    '    "select top 1 (ano+periodo) as 'unico',ano as 'año',periodo,fecha_ini,fecha_fin,'S' as 'Alta_Mayor' " & vbCr & _
                    '    "from periodos " & vbCr & _
                    '    "where (DATEADD(DAY,-7,@Alta) between fecha_ini and fecha_fin) and (periodo_especial is null or periodo_especial = 0)" & vbCr & _
                    '    "order by ano desc, periodo desc" & vbCr & _
                    '    "),S3 as (" & vbCr & _
                    '    "select * from S0 union select * from S1" & vbCr & _
                    '    ") select top 1 unico,año,periodo,fecha_ini,fecha_fin,Alta_Mayor from S3 order by unico desc"


                    strSQL &= "with S0 as (" & vbCr & _
                   "select (ano+periodo) as 'unico',ano as 'año',periodo,fecha_ini,fecha_fin, 'N' as 'Alta_Mayor' " & vbCr & _
                   "from periodos " & vbCr & _
                   "where (ano+periodo) = coalesce ((" & vbCr & _
                   "select max(nomina.ano+nomina.periodo) as periodo" & vbCr & _
                   "from NOMINA.dbo.nomina inner join periodos" & vbCr & _
                   "on nomina.ano = periodos.ANO and nomina.PERIODO = periodos.periodo" & vbCr & _
                   "where nomina.reloj = @Reloj and isnull(periodos.periodo_especial,0) = 0" & vbCr & _
                   "),'')" & vbCr & _
                   "),S1 as (" & vbCr & _
                   "select  (ano+periodo) as 'unico',ano as 'año',periodo,fecha_ini,fecha_fin,'S' as 'Alta_Mayor' " & vbCr & _
                   "from periodos where (DATEADD(DAY,-7,@Alta) between fecha_ini and fecha_fin) and (periodo_especial is null or periodo_especial = 0) " & vbCr & _
                   "),S3 as (" & vbCr & _
                   "select * from S0 union select * from S1 " & vbCr & _
                   ") select * from S3 where unico = (select max(unico) from (select * from S3) final)"

                Case "A", "G"

                    'strSQL &= "with S0 as (" & vbCr & _
                    '    "select top 1 (ano+periodo) as 'unico',ano as 'año',periodo,fecha_ini,fecha_fin, 'N' as 'Alta_Mayor' " & vbCr & _
                    '    "from periodos_catorcenal " & vbCr & _
                    '    "WHERE  (ano+periodo) in (select distinct (ano+periodo) as 'periodo' from nomina.dbo.nomina where reloj = @Reloj) and  (periodo_especial IS NULL OR periodo_especial = 0)" & vbCr & _
                    '    "ORDER BY ano DESC,periodo DESC" & vbCr & _
                    '    "),S1 as (" & vbCr & _
                    '    "select top 1 (ano+periodo) as 'unico',ano as 'año',periodo,fecha_ini,fecha_fin,'S' as 'Alta_Mayor' " & vbCr & _
                    '    "from periodos_catorcenal " & vbCr & _
                    '    "where (@Alta between fecha_ini and fecha_fin) and (periodo_especial is null or periodo_especial = 0)" & vbCr & _
                    '    "order by ano desc, periodo desc" & vbCr & _
                    '    "),S3 as (" & vbCr & _
                    '    "select * from S0 union select * from S1" & vbCr & _
                    '    ") select top 1 unico,año,periodo,fecha_ini,fecha_fin,Alta_Mayor from S3 order by unico desc"

                    strSQL &= "with S0 as (" & vbCr & _
                   "select (ano+periodo) as 'unico',ano as 'año',periodo,fecha_ini,fecha_fin, 'N' as 'Alta_Mayor' " & vbCr & _
                   "from periodos_catorcenal " & vbCr & _
                   "where (ano+periodo) = coalesce ((" & vbCr & _
                   "select max(nomina.ano+nomina.periodo) as periodo" & vbCr & _
                   "from NOMINA.dbo.nomina inner join periodos_catorcenal " & vbCr & _
                   "on nomina.ano = periodos_catorcenal.ANO and nomina.PERIODO = periodos_catorcenal.periodo " & vbCr & _
                   "where nomina.reloj = @Reloj and isnull(periodos_catorcenal.periodo_especial,0) = 0 " & vbCr & _
                   "),'')" & vbCr & _
                   "),S1 as (" & vbCr & _
                   "select  (ano+periodo) as 'unico',ano as 'año',periodo,fecha_ini,fecha_fin,'S' as 'Alta_Mayor' " & vbCr & _
                   "from periodos_catorcenal where (@Alta between fecha_ini and fecha_fin) and (periodo_especial is null or periodo_especial = 0) " & vbCr & _
                   "),S3 as (" & vbCr & _
                   "select * from S0 union select * from S1 " & vbCr & _
                   ") select top 1 unico,año,periodo,fecha_ini,fecha_fin,Alta_Mayor from S3 order by unico desc"


                Case Else

                    strSQL = ""

            End Select

            If Not strSQL.Trim = "" Then

                If Clave.Trim = "EDIT" Then
                    frm.Show()
                    frm.lblAvance.Text = "Última nómina..."
                    Application.DoEvents()

                End If

                dtDatos = sqlExecute(strSQL, "TA")

                If dtDatos.Rows.Count > 0 Then

                    Dim Row_Datos As DataRow = dtDatos.Rows(0)
                    Dim Row_NominaBase As DataRow = dtNominaBase.NewRow

                    If Row_Datos("Alta_Mayor").ToString.Trim.ToUpper = "S" Then
                        EsAltaMayorAperiodo = True
                    Else
                        EsAltaMayorAperiodo = False
                    End If

                    Row_NominaBase("unico") = Row_Datos("unico")
                    Row_NominaBase("año") = Row_Datos("año")
                    Row_NominaBase("periodo") = Row_Datos("periodo")
                    Row_NominaBase("fecha_ini") = FechaSQL(CDate(Row_Datos("fecha_ini").ToString))
                    Row_NominaBase("fecha_fin") = FechaSQL(CDate(Row_Datos("fecha_fin").ToString))

                    dtNominaBase.Rows.Add(Row_NominaBase)

                End If

            End If


        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar consultar la última nómina procesada del empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ActivoTrabajando = False
        frm.Close()

        Return dtNominaBase

    End Function

    Private Sub HabilitarFiniquito()

        pnlBotFin.Enabled = True
        pnlBotFin.Visible = True

        btnAgregaConcepto.Enabled = Not frmCalcFiniquito.finCancelado
        btnEditar.Enabled = Not frmCalcFiniquito.finCancelado
        EliminaConce.Enabled = Not frmCalcFiniquito.finCancelado
        btnCalcular.Enabled = Not frmCalcFiniquito.finCancelado

        pnlIndemnizacion.Enabled = Not frmCalcFiniquito.finCancelado
        BajaFiniquito.Enabled = Not frmCalcFiniquito.finCancelado

        cmbPeriodos.Enabled = Not frmCalcFiniquito.finCancelado

        txtNumCheque.Enabled = Not frmCalcFiniquito.finCancelado
        btnActuCheque.Enabled = Not frmCalcFiniquito.finCancelado And Clave = "EDIT"

    End Sub


    Private Function InsertarConceptoAjustes(ano As String, periodo As String, folio As String, rl As String, concepto As String, descripcion As String, monto As Double, factor As String) As Boolean
        Dim proceso As Boolean = False
        If sqlExecute("insert into ajustes_calculo(ano,periodo,folio,reloj,concepto,descripcion,monto,factor) values ('" & ano & "','" & periodo & "','" & folio & "','" & rl & "','" & concepto & "','" & descripcion & "'," & monto & ",'" & factor & "')", "NOMINA").Columns.Contains("ERROR") Then
            proceso = False
        Else
            proceso = True
        End If

        Return proceso
    End Function

    Private Sub frmFiniquitoWME_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Try
            Clave = frmCalcFiniquito.Bandera
            frmCalcFiniquito.FolioCapturado = ""
            frmCalcFiniquito.FolioSeleccionado = ""

            Dim sueldo1() As String = {"Diario", "Integrado"}
            Dim sueldo2() As String = {"Diario", "Integrado"}
            Dim sueldo3() As String = {"Diario", "Integrado"}

            lblTipoNomProcesada.Text = "Periodo última nómina procesada"

            Clave = frmCalcFiniquito.Bandera

            dgvConceptos.AutoGenerateColumns = False

            cmbsueldoprima.DataSource = sueldo1
            cmbsueldoprima.Columns(0).Text = "Sueldo"
            cmbsueldoprima.SelectedIndex = 0

            cmbsueldograf.DataSource = sueldo2
            cmbsueldograf.Columns(0).Text = "Sueldo"
            cmbsueldograf.SelectedIndex = 0

            cmbsueldodias.DataSource = sueldo3
            cmbsueldodias.Columns(0).Text = "Sueldo"
            cmbsueldodias.SelectedIndex = 1

            txtNumGratificacion.ValueObject = 0

            dtConcGrid = sqlExecute("select Concepto,Descripcion, Monto,Factor from ajustes_calculo where 0 = 1", "NOMINA")
            dtConcGrid.DefaultView.Sort = "Concepto"
            dgvConceptos.DataSource = dtConcGrid

            '-- Cargar el año y periodo actual abierto inicializado

            dtCod_Comp = sqlExecute("select COD_COMP from cias where CIA_DEFAULT=1", "PERSONAL")
            If (Not dtCod_Comp.Columns.Contains("Error") And dtCod_Comp.Rows.Count > 0) Then
                Try : cod_comp = dtCod_Comp.Rows(0).Item("cod_comp").ToString.Trim : Catch ex As Exception : cod_comp = "" : End Try
            End If

            If Clave = "NVO" Then

                ' AsignarFolio()

                dtRegistro = sqlExecute("select * from personalvw where reloj = '" & frmCalcFiniquito.txtReloj.Text.Trim & "'")

            ElseIf Clave = "EDIT" Then

                dtRegistro = sqlExecute("select * from nomina_calculo where folio = '" & frmCalcFiniquito.Folio.Trim & "' and reloj = '" & frmCalcFiniquito.txtReloj.Text.Trim & "'", "NOMINA")

            End If

            MostrarInformacion()
            HabilitarFiniquito()

            CambioFhaBajaFin = True
            EsCargaInicial = False



        Catch ex As Exception
            MessageBox.Show("Se presentó un error al cargar la ventana. Si el problema persiste contacte al administrador", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmFiniquitoWME_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub dgvConceptos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgvConceptos.DataError
        'Try
        '    dgvConceptos.Rows(e.RowIndex).ErrorText = "El monto debe ser numérico. Favor de verificar."
        '    MessageBox.Show("El monto debe ser numérico. Favor de verificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    e.Cancel = True
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub dgvConceptos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvConceptos.CellEndEdit
        'Try
        '    Dim row As DataGridViewRow = dgvConceptos.CurrentRow

        '    Dim value As Object = row.Cells("ColMonto").Value

        '    If Convert.ToString(value) = String.Empty Then
        '        row.Cells("ColMonto").Value = 0
        '    End If

        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub swantiguedad_ValueChanged(sender As Object, e As EventArgs) Handles swantiguedad.ValueChanged
        If swantiguedad.Value Then
            cmbsueldoprima.Enabled = True
        Else
            cmbsueldoprima.Enabled = False
            cmbsueldoprima.SelectedIndex = 0
        End If

        If Not EsCargaInicial Then PrimaAntiguedad()
    End Sub

    Private Sub swgratificacion_ValueChanged(sender As Object, e As EventArgs) Handles swgratificacion.ValueChanged
        If swgratificacion.Value Then
            cmbsueldograf.Enabled = True
            txtNumGratificacion.Enabled = True
        Else
            cmbsueldograf.Enabled = False
            txtNumGratificacion.Value = 90
            cmbsueldograf.SelectedIndex = 0
            txtNumGratificacion.Enabled = False

        End If

        If Not EsCargaInicial Then Gratificacion()

    End Sub

    Private Sub swdiasano_ValueChanged(sender As Object, e As EventArgs) Handles swdiasano.ValueChanged
        If swdiasano.Value Then
            cmbsueldodias.Enabled = True
        Else
            cmbsueldodias.SelectedIndex = 1
            cmbsueldodias.Enabled = False
        End If

        If Not EsCargaInicial Then NoRestitucion()
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        Try
            If SuperTabControl1.SelectedTabIndex = 0 Then
                btnAgregaConcepto.Enabled = Not frmCalcFiniquito.finCancelado
                btnEditar.Enabled = Not frmCalcFiniquito.finCancelado
                EliminaConce.Enabled = Not frmCalcFiniquito.finCancelado
            Else
                btnAgregaConcepto.Enabled = False
                btnEditar.Enabled = False
                EliminaConce.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAgregaConcepto_Click(sender As Object, e As EventArgs) Handles btnAgregaConcepto.Click
        Try
            EditarAgregar = ""
            EditarAgregar = "NVO"
            frmEditAgreConcepto.ShowDialog(Me)

        Catch ex As Exception
            EditarAgregar = ""
        End Try
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            EditarAgregar = ""
            EditarAgregar = "EDT"

            If dgvConceptos.Rows.Count > 0 Then

                If dgvConceptos.SelectedRows.Count > 0 Then
                    frmEditAgreConcepto.ShowDialog(Me)
                Else
                    MessageBox.Show("Debe seleccionar un concepto para editar. Favor de verificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("No hay conceptos para editar.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception

            EditarAgregar = ""
        End Try
    End Sub

    Private Sub EliminaConce_Click(sender As Object, e As EventArgs) Handles EliminaConce.Click

        Dim cadena As String = ""
        Dim strconcepto As String = ""
        Dim i As Integer = 0

        Try

            If dgvConceptos.Rows.Count > 0 Then

                Dim NumConSel As Integer = dgvConceptos.SelectedRows.Count

                If NumConSel > 0 Then

                    Dim respuesta As DialogResult = MessageBox.Show("Los conceptos seleccionados serán eliminados para el cálculo. ¿Desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                    If respuesta = Windows.Forms.DialogResult.Yes Then
                        cadena = "in("

                        For Each dgvRow As DataGridViewRow In dgvConceptos.SelectedRows
                            strconcepto = Trim(dgvRow.Cells(0).Value)
                            cadena = cadena & "'" & strconcepto & "'" & IIf(i = (NumConSel - 1), "", ",")
                            i = i + 1
                        Next

                        cadena &= ")"


                        Try
                            Dim Copia As DataTable = DirectCast(dgvConceptos.DataSource, DataTable)
                            Dim drRows() As DataRow = Copia.Select("concepto " & cadena)

                            For Each Row As DataRow In drRows

                                Select Case Row("concepto").ToString.Trim

                                    Case "PRIANT"
                                        swantiguedad.Value = False
                                    Case "NOREST"
                                        swdiasano.Value = False
                                    Case "INDEMN"
                                        swgratificacion.Value = False
                                    Case Else

                                        Copia.Rows.Remove(Row)

                                End Select

                            Next


                        Catch ex As Exception
                            MessageBox.Show("Error al intentar eliminar los conceptos seleccionados", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End Try

                    End If

                Else

                    MessageBox.Show("No se ha seleccionado algún concepto para eliminar del cálculo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If

            Else

                MessageBox.Show("No existen conceptos para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar eliminar concepto(s)", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvConceptos_RowLeave(sender As Object, e As DataGridViewCellEventArgs) Handles dgvConceptos.RowLeave
        '  MsgBox("hola")
    End Sub

    Private Sub dgvConceptos_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvConceptos.RowEnter
        'MsgBox("selecciona fila")
    End Sub

    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click

        Dim frm As New frmTrabajando
        Dim strsql As String = ""
        Dim tmpUltimaNomina As String = ""
        Dim continuar As Boolean

        Try

            If Not txtPeriodoCalculo.Text.Trim.Length > 0 Then
                MessageBox.Show("No se ha asignado un periodo de cálculo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If


            If AltaEmp.ValueObject Is Nothing Then
                MessageBox.Show("Fecha de alta en blanco. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                AltaEmp.Focus()
                Exit Sub
            End If


            If AntigEmp.ValueObject Is Nothing Then
                MessageBox.Show("Fecha de alta antiguedad en blanco. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                AntigEmp.Focus()
                Exit Sub
            End If

            If BajaFiniquito.ValueObject Is Nothing Then
                MessageBox.Show("Fecha de finiquito en blanco. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                BajaFiniquito.Focus()
                Exit Sub
            End If

            'If cmbPeriodos.SelectedIndex < 0 Then
            '    MessageBox.Show("Debe seleccionar un periodo. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    cmbPeriodos.Focus()
            '    Exit Sub

            'End If

            If MessageBox.Show("¿Desea realizar algún cambio antes de iniciar con el proceso de cálculo de finiquito?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                Exit Sub
            End If

            If cmbPeriodos.SelectedIndex >= 0 Then

                tmpUltimaNomina = cmbPeriodos.SelectedValue.ToString.Trim
            Else
                tmpUltimaNomina = ""
            End If

            If Not dgvConceptos.Rows.Count > 0 Then

                MessageBox.Show("Para el cálculo debe existir al menos un concepto. Favor de verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub

            End If

            If txtFolio.Text.Trim = "ERROR" Then
                MessageBox.Show("No se puede realizar la captura de finiquito del empleado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            If txtNumCheque.Text.Trim = "" Then
                MessageBox.Show("Debe ingresar el número de cheque.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtNumCheque.Focus()
                Exit Sub
            End If

            'Buscar si el empleado tiene un credito de infonavit activo
            Dim lcldtInfonavit = sqlExecute("select top 1 * from infonavit where reloj = '" & txtReloj.Text.Trim & "' and activo = 1")
            Dim _infonavit_credito_ As String = ""
            Dim _tipo_credito As String = ""
            Dim _cuota_credito As Double = 0.0
            Dim _cobro_segviv_ As Boolean = False
            Dim _inicio_credito As String = ""

            With lcldtInfonavit

                Try : _infonavit_credito_ = IIf(IsDBNull(.Rows(0).Item("infonavit")), "NULL", "'" & .Rows(0).Item("infonavit").ToString.Trim & "'") : Catch ex As Exception : _infonavit_credito_ = "NULL" : End Try
                Try : _tipo_credito = IIf(IsDBNull(.Rows(0).Item("tipo_cred")), "NULL", "'" & .Rows(0).Item("tipo_cred").ToString.Trim & "'") : Catch ex As Exception : _tipo_credito = "NULL" : End Try
                Try : _cuota_credito = IIf(IsDBNull(.Rows(0).Item("cuota_cred")), 0.0, .Rows(0).Item("cuota_cred")) : Catch ex As Exception : _cuota_credito = 0.0 : End Try
                Try : _cobro_segviv_ = IIf(IsDBNull(.Rows(0).Item("cobro_segv")), False, .Rows(0).Item("cobro_segv")) : Catch ex As Exception : _cobro_segviv_ = False : End Try
                Try : _inicio_credito = IIf(IsDBNull(.Rows(0).Item("inicio_cre")), "NULL", "'" & FechaSQL(.Rows(0).Item("inicio_cre"))) & "'" : Catch ex As Exception : _inicio_credito = "NULL" : End Try
            End With


            If txtFolio.Text.Trim = "" And txtFolio.Text.Trim <> "ERROR" Then

                strsql = "insert into nomina_calculo ([status],neto,cod_tipo_nomina,periodo,ano,cod_comp,reloj,nombres,sactual,integrado,alta,baja_fin,alta_antig,cod_puesto,puesto,cod_tipo,"
                strsql &= "prima_antig,tipo_sdo_antig,gratificacion,tipo_sdo_grati,dias_grati,[20diasano],tipo_sdo_rest,captura,usuario,cod_depto,cod_turno,cod_super,cod_hora,cod_clase,"
                strsql &= "cod_planta,tipo_periodo,ultimanomina,fhacalculo,cod_area,fah_participa,fah_porcentaje,infonavit_credito,cuota_credito,tipo_credito,inicio_credito,cobro_segviv,num_cheque,ano_mtro_ded,per_mtro_ded)" & vbCr
                strsql &= " select 'EN PROCESO' as [status],0.0,'F','" & Trim(Split(txtPeriodoCalculo.Text, "-")(1)) & "' as periodo, '" & Trim(Split(txtPeriodoCalculo.Text, "-")(0)) & "' as ano, cod_comp,reloj,nombres,sactual,integrado,"
                strsql &= " '" & FechaSQL(AltaEmp.ValueObject) & "' as alta, '" & FechaSQL(BajaFiniquito.Value) & "' as baja_finqto,'" & IIf(AntigEmp.ValueObject = Nothing, FechaSQL(AltaEmp.ValueObject), FechaSQL(AntigEmp.ValueObject)) & "' as alta_antig,"
                strsql &= "cod_puesto, rtrim(isnull(nombre_puesto,'')) as puesto ,cod_tipo, " & IIf(swantiguedad.Value, 1, 0) & " as prima_antig, '" & cmbsueldoprima.Text.Trim & "' as tipo_sdo_antig, " & IIf(swgratificacion.Value, 1, 0) & " as gratificacion,'" & IIf(swgratificacion.Value, cmbsueldograf.Text.Trim, "") & "' as tipo_sdo_grati, " & IIf(swgratificacion.Value, txtNumGratificacion.Value, 0) & " as dias_grati,"
                strsql &= "" & IIf(swdiasano.Value, 1, 0) & " as [20diasano], '" & cmbsueldodias.Text.Trim & "' as tipo_sdo_rest,getdate(),'" & Usuario & "' as usuario,"
                strsql &= " isnull(cod_depto,'') as cod_depto,isnull(cod_turno,'') as cod_turno,isnull(cod_super,'') as cod_super,isnull(cod_hora,'') as cod_hora,isnull(cod_clase,'') as cod_clase, isnull(cod_planta,'') as cod_planta,isnull(tipo_periodo,'') as tipo_periodo, '" & tmpUltimaNomina & "' as 'ultimanomina', getdate(),cod_area,FAH_PARTIC,FAH_PORCEN,"
                strsql &= "" & _infonavit_credito_ & " as 'infonavit_credito'," & _cuota_credito & " as 'cuota_credito'," & _tipo_credito & " as 'tipo_credito'," & _inicio_credito & " as 'inicio_credito','" & _cobro_segviv_ & "' as cobro_segviv,'" & txtNumCheque.Text.Trim & "' as num_cheque,'" & ano_mtro_ded.Trim & "' as 'ano_mtro_ded','" & per_mtro_ded.Trim & "' as 'per_mtro_ded'" & vbCr
                strsql &= " from personal.dbo.personalvw where reloj = '" & txtReloj.Text.Trim & "'" & vbCr & _
                    "select @@IDENTITY as 'Folio'"

                Dim dtInsertar As DataTable = sqlExecute(strsql, "NOMINA")

                If dtInsertar.Columns.Contains("ERROR") Then

                    MessageBox.Show("No se pudo realizar la alta de finiquito del empleado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                ElseIf dtInsertar.Rows.Count > 0 Then

                    Dim drFolio As DataRow = dtInsertar.Rows(0)
                    Dim valor As Long = IIf(IsDBNull(drFolio("folio")), 0, drFolio("folio"))

                    If valor <= 0 Then
                        txtFolio.Text = "ERROR"
                    Else
                        txtFolio.Text = valor.ToString
                    End If
                Else
                    txtFolio.Text = "ERROR"
                End If


            ElseIf txtFolio.Text.Trim <> "ERRROR" Then

                strsql = "update nomina_calculo set [status] = 'EN PROCESO',neto = 0,sactual = " & dtCompania.Rows(0).Item("sactual") & ",integrado = " & dtCompania.Rows(0).Item("integrado") & ",ano ='" & Trim(Split(txtPeriodoCalculo.Text.Trim, "-")(0)) & "',periodo = '" & Trim(Split(txtPeriodoCalculo.Text.Trim, "-")(1)) & "',baja_fin = '" & FechaSQL(BajaFiniquito.Value) & "',prima_antig = " & IIf(swantiguedad.Value, 1, 0) & ",tipo_sdo_antig = '" & cmbsueldoprima.Text.Trim & "',"
                strsql &= "gratificacion = " & IIf(swgratificacion.Value, 1, 0) & ",dias_grati = " & IIf(swgratificacion.Value, txtNumGratificacion.Value, 0) & ",tipo_sdo_grati = '" & cmbsueldograf.Text.Trim & "',[20diasano] = " & IIf(swdiasano.Value, 1, 0) & ",tipo_sdo_rest = '" & cmbsueldodias.Text.Trim & "',ano_mtro_ded = '" & ano_mtro_ded.Trim & "',per_mtro_ded = '" & per_mtro_ded.Trim & "',"
                strsql &= "fhacalculo = getdate(),usrcalculo = '" & Usuario & "', alta = '" & FechaSQL(AltaEmp.ValueObject) & "', alta_antig = '" & FechaSQL(AntigEmp.ValueObject) & "',fah_participa = '" & IIf(IsDBNull(dtCompania.Rows(0).Item("FAH_PARTIC")), False, dtCompania.Rows(0).Item("FAH_PARTIC")) & "',fah_porcentaje = " & IIf(IsDBNull(dtCompania.Rows(0).Item("FAH_PORCEN")), 0, dtCompania.Rows(0).Item("FAH_PORCEN")) & " where folio = '" & txtFolio.Text.Trim & "' and reloj ='" & txtReloj.Text.Trim & "'"

                If sqlExecute(strsql, "NOMINA").Columns.Contains("ERROR") Then
                    MessageBox.Show("No se pudo actualizar los datos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If sqlExecute("delete from movimientos_calculo where folio = '" & txtFolio.Text.Trim & "' and reloj = '" & txtReloj.Text.Trim & "' ", "NOMINA").Columns.Contains("ERROR") Then
                    MessageBox.Show("Se presentó un error al recalcular el finiquito especial.", "Error en movimientos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If


                If sqlExecute("delete from ajustes_calculo where folio = '" & txtFolio.Text.Trim & "' and reloj = '" & txtReloj.Text.Trim & "' ", "NOMINA").Columns.Contains("ERROR") Then
                    MessageBox.Show("Se presentó un error al recalcular el finiquito especial.", "Error en ajustes", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

            Else

                MessageBox.Show("Existe un problema con el folio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub

            End If


            If Not txtFolio.Text.Trim = "ERROR" Then

                frm.Show()
                Application.DoEvents()

                For Each dgvRow As DataGridViewRow In dgvConceptos.Rows
                    Application.DoEvents()
                    If Not dgvRow.Cells("ColMonto").Value = 0 Then

                        If Not InsertarConceptoAjustes(Trim(Split(txtPeriodoCalculo.Text.Trim, "-")(0)), Trim(Split(txtPeriodoCalculo.Text.Trim, "-")(1)), txtFolio.Text.Trim, txtReloj.Text.Trim, dgvRow.Cells("ColConcepto").Value, dgvRow.Cells("ColDescripcion").Value, dgvRow.Cells("ColMonto").Value, IIf(IsDBNull(dgvRow.Cells("ColFactor").Value), 0, dgvRow.Cells("ColFactor").Value)) Then
                            MessageBox.Show("No se pudo realizar la captura completa de conceptos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            continuar = False
                            Exit For
                        Else
                            continuar = True
                        End If

                    End If


                Next

                If continuar Then

                    Application.DoEvents()
                    '*** Ejecutar calculos

                    Dim pAnio As String = Trim(Split(txtPeriodoCalculo.Text.Trim, "-")(0)).Trim
                    Dim pPeriodo As String = Trim(Split(txtPeriodoCalculo.Text.Trim, "-")(1)).Trim

                    CalculoFiniquito(pAnio, pPeriodo, "I", "ano ='" & pAnio & "' and periodo ='" & pPeriodo & "' and folio = '" & txtFolio.Text.Trim & "'", txtReloj.Text.Trim, txtFolio.Text.Trim)

                    'If sqlExecute("exec calculo '" & txtFolio.Text.Trim & "','" & txtReloj.Text.Trim & "'", "NOMINA").Columns.Contains("ERROR") Then
                    '    MessageBox.Show("No se pudo realizar el calculo del finiquito", "Error calculo finiquito", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    ActivoTrabajando = False
                    '    frm.Close()
                    '    Exit Sub
                    'End If


                    sqlExecute("declare @_folio int = '" & txtFolio.Text.Trim & "'" & vbCr & _
                    "declare @_reloj varchar(max) = '" & txtReloj.Text.Trim & "'" & vbCr & _
                    "declare @_monto decimal(38,2) = convert(decimal(38,2),coalesce((select top 1 monto from movimientos_calculo where concepto = 'NETO' and folio = @_folio and reloj = @_reloj),0))" & vbCr & _
                    "update nomina_calculo set  [status] = 'CALCULADO' , neto = @_monto  where folio = @_folio and reloj = @_reloj", "NOMINA")

                    dtConceMovimientos = sqlExecute("select ltrim(rtrim(mov.Concepto)) as 'concepto' ,ltrim(rtrim(conceptos.NOMBRE)) as 'descripcion',mov.Monto as 'monto'" & vbCr & _
                                "from movimientos_calculo mov left join conceptos on mov.Concepto = conceptos.CONCEPTO where folio = '" & txtFolio.Text.Trim & "' and reloj = '" & txtReloj.Text.Trim & "' and (ano+periodo) = '" & pAnio & pPeriodo & "'", "NOMINA")

                    dgMovimientos.DataSource = dtConceMovimientos

                    Application.DoEvents()
                    ActivoTrabajando = False
                    frm.Close()

                    frmCalcFiniquito.FolioCapturado = txtFolio.Text.Trim
                    frmCalcFiniquito.FolioSeleccionado = txtFolio.Text.Trim
                    SuperTabControl1.SelectedTabIndex = 1
                    btnActuCheque.Enabled = True
                Else

                    ActivoTrabajando = False
                    frm.Close()
                    frmCalcFiniquito.FolioCapturado = ""
                    btnActuCheque.Enabled = False
                End If


            Else
                ActivoTrabajando = False
                frm.Close()
                frmCalcFiniquito.FolioCapturado = "ERROR"
                btnActuCheque.Enabled = False
                MessageBox.Show("Se presentó un error en el folio.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            ActivoTrabajando = False
            frm.Close()
            frmCalcFiniquito.FolioCapturado = "ERROR"
            btnActuCheque.Enabled = False
            MessageBox.Show("Se presentó un error al intentar realizar el calculo de finiquito", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub BajaFiniquito_ValueObjectChanged(sender As Object, e As EventArgs) Handles BajaFiniquito.ValueObjectChanged
        Try

            If IsNothing(BajaFiniquito.Value) Then
                Exit Sub
            End If

            If Clave = "NVO" And Not IsNothing(BajaFiniquito.ValueObject) Then
                lclCalculoDefaultConcepto(txtReloj.Text.Trim, BajaFiniquito.Value)
            ElseIf Clave = "EDIT" And Not IsNothing(BajaFiniquito.ValueObject) And CambioFhaBajaFin Then
                lclCalculoDefaultConcepto(txtReloj.Text.Trim, BajaFiniquito.Value)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbsueldoprima_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsueldoprima.SelectedIndexChanged
        Try
            If swantiguedad.Value Then
                PrimaAntiguedad()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbsueldodias_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsueldodias.SelectedIndexChanged
        Try
            If swdiasano.Value Then
                NoRestitucion()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtNumGratificacion_ValueChanged(sender As Object, e As EventArgs) Handles txtNumGratificacion.ValueChanged
        Try

            If Not EsCargaInicial Then Gratificacion()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbsueldograf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbsueldograf.SelectedIndexChanged
        Try
            If swgratificacion.Value Then
                Gratificacion()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnActuCheque_Click(sender As Object, e As EventArgs) Handles btnActuCheque.Click
        Try

            Dim fl As String = txtFolio.Text.Trim

            If fl <> "" And fl <> "ERROR" Then
                Dim dtActualizaCheque As DataTable = sqlExecute("update nomina_calculo set num_cheque = '" & txtNumCheque.Text.Trim & "'" & vbCr & _
                                                           "where reloj = '" & txtReloj.Text.Trim & "' and folio = '" & txtFolio.Text.Trim & "'" & vbCr & _
                                                           "select @@ROWCOUNT as 'actualizado'", "NOMINA")
                Dim actualizado As Integer = 0
                Try : actualizado = dtActualizaCheque.Rows(0).Item("actualizado") : Catch ex As Exception : actualizado = -1 : End Try

                If actualizado = 0 Then
                    MessageBox.Show("El número de cheque no se pudo actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ElseIf actualizado = -1 Then
                    MessageBox.Show("Error al intentar actualizar el número de cheque. Si el problema perisiste contacte al administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    MessageBox.Show("Número de cheque actualizado.", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            Else
                MessageBox.Show("El número de cheque no se puede actualizar dado que no existe un número de reloj y/o folio asigando al cálculo de finiquito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

           
        Catch ex As Exception

        End Try
    End Sub
End Class