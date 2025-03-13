Imports System.Drawing.Printing
Imports System.Data.SqlClient
Imports System.IO
Imports Outlook = Microsoft.Office.Interop.Outlook  'Jose R Hdez 26 ago 2020 Enviar recibos por correo
Imports System.Text.RegularExpressions


Public Class frmRecibos
    Dim cod_comp As String = ""
    Dim nombre_empresa As String = ""
    Dim dtRecibos As New DataTable      'Tabla con la información completa, lista para los recibos (excepto préstamo y fondo de ahorro=
    Dim dtNomina As New DataTable       'Tabla con la información de nómina                            
    Dim dtMovimientos As New DataTable  'Tabla con la información de movimientos
    Dim dtPersonal As New DataTable     'Tabla con la información de personal
    Dim dtGrupos As New DataTable       'Tabla con la información de los grupos disponibles

    Dim dtMontoHrExtra As New DataTable  ' Tabla que contendrá solo el monto de hora doble o tiple
    Dim dtMovConcExento As New DataTable  'Tabla que contendrá solo el movimiento del conceto exento
    Dim dtTimbrado As New DataTable     ' Tabla que va a contener la informacion de timbrado
    Dim dtTemp As New DataTable

    Dim Iniciando As Boolean = True
    Dim dtMtroDed As New DataTable
    Dim dtSaldosCA As New DataTable

    Public varTodos As Boolean           'variable usada en frmrecibos y frmcantidadempleadosrecibos
    Public varActivoRecibos As Boolean = True   'var para Forma activa(frmrecibos)
    Public varActivoSeleccion As Boolean        'var forma seleccion(frmcantidad..)
    Public varCmbPopOut As Boolean          'cuando el combo se cierra
    Dim EnviadoExitoso As Boolean = False '-----------------Agregado por Antonio par validar si el correo se envio bien o no

    Private Sub frmRecibos_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        sqlClose()
    End Sub

    Private Sub frmRecibos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '-----2021-10-28 - AOS: Cargar cod_comp dinámicamente
        Dim dtCod_Comp As DataTable
        dtCod_Comp = sqlExecute("select COD_COMP from cias where CIA_DEFAULT=1", "PERSONAL")
        If (Not dtCod_Comp.Columns.Contains("Error") And dtCod_Comp.Rows.Count > 0) Then
            Try : cod_comp = dtCod_Comp.Rows(0).Item("cod_comp").ToString.Trim : Catch ex As Exception : cod_comp = "" : End Try
        End If

        Dim dtPeriodo As New DataTable
        Try
            If varTodos Then
                LabelX2.Text = "Modo: Todos los registros"
            Else
                LabelX2.Text = "Modo: Un solo registro"
            End If

            If Not EstructuraSobres() Then
                MessageBox.Show("Hubo un error al crear la estructura del reporte, y no podrán imprimirse los recibos. Favor de verificar.", "Recibos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            cmbCia.DataSource = sqlExecute("SELECT cod_comp,nombre FROM cias ORDER BY cia_default DESC")
            cmbCia.SelectedIndex = 0

            chkTipoPerSem.Checked = True
            chkTipoPerCat.Checked = False
            cmbPeriodos.DataSource = sqlExecute("SELECT ano+periodo as 'seleccionado',periodo,ano,fini_nom as 'fecha_ini',ffin_nom as 'fecha_fin' FROM periodos where isnull(fini_nom,'')<>'' ORDER BY ano DESC,periodo ASC", "TA")
            ListarImpresoras()

            Iniciando = False
            dtPeriodo = sqlExecute("SELECT MAX(ano+periodo) as 'seleccionado' FROM periodos WHERE activo = 1", "TA")
            If dtPeriodo.Rows.Count > 0 Then
                cmbPeriodos.SelectedValue = dtPeriodo.Rows(0).Item("seleccionado")
            Else
                cmbPeriodos.SelectedIndex = 0
            End If

            ActualizaInfo()

        Catch ex As Exception
            Debug.Print("ERROR" & ex.Message)
        End Try
    End Sub

    Private Function EstructuraSobres() As Boolean
        Dim X As Integer
        Try
            'Estructura para reporte
            dtRecibos = New DataTable
            dtRecibos.Columns.Add("GRUPO", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("FOLIO", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("PAGINA", System.Type.GetType("System.Int16"))
            dtRecibos.Columns.Add("COD_TIPO_NOMINA", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("PERIODO", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("ANO", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("MES", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("RELOJ", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("NOMBRES", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("COD_TURNO", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("COD_LINEA", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("COD_DEPTO", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("COD_SUPER", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("COD_HORA", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("COD_TIPO", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("COD_CLASE", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("COD_PLANTA", System.Type.GetType("System.String"))  'Jose Hernandez 2019-Mar-05
            dtRecibos.Columns.Add("IMSS", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("RFC", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("CURP", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("COD_PUESTO", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("cuenta_banco", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("NOMBRE_DEPTO", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("NOMBRE_PUESTO", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("COMPANIA", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("CIA_RFC", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("CIA_REG_PAT", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("DIRECCION_COMPANIA", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("NOMBRE_PLANTA", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("ALTA", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("BAJA", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("COD_PAGO", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("COD_AREA", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("DEPOSITO", System.Type.GetType("System.Boolean"))
            dtRecibos.Columns.Add("HORAS_NORMALES", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("HORAS_DOBLES", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("HORAS_TRIPLES", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("HORAS_FESTIVAS", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("HORAS_DOMINGO", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("HORAS_COMPENSA", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("DIAS_VAC", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("DIAS_AGUI", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("SACTUAL", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("SMENSUAL", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("INTEGRADO", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("NETO", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("OTR_BON", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("AHORRO_EMP", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("AHORRO_EMPR", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("RETIROS", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("AHORRO_TOTAL", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("AHORRO_NETO", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("PRESTAMO", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("FONACOT", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("INFONAVIT", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("APOFAH", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("SAFAHE", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("SAFAHC", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("RETFAH", System.Type.GetType("System.Decimal"))

            For X = 1 To 13
                dtRecibos.Columns.Add("DESC_PER" & X, System.Type.GetType("System.String")) '- Descripcion Percep
                dtRecibos.Columns.Add("CANT_PER" & X, System.Type.GetType("System.Decimal")) '-- Monto Percep
                dtRecibos.Columns.Add("DESC_DED" & X, System.Type.GetType("System.String")) '-- Descripcion Dedud
                dtRecibos.Columns.Add("CANT_DED" & X, System.Type.GetType("System.Decimal")) '-- Monto Deduc
                dtRecibos.Columns.Add("BASE_PER" & X, System.Type.GetType("System.Decimal"))
                dtRecibos.Columns.Add("SALDO_DED" & X, System.Type.GetType("System.Decimal")) '-- Saldo Deduc
                dtRecibos.Columns.Add("COD_SAT_PER" & X, System.Type.GetType("System.String"))  ' Codigo del sat de la percep
                dtRecibos.Columns.Add("COD_SAT_DED" & X, System.Type.GetType("System.String"))  ' Codigo del sat de la Deduc
                dtRecibos.Columns.Add("GRAV_PER" & X, System.Type.GetType("System.Decimal")) ' Monto Gravable de cada percep
                dtRecibos.Columns.Add("EXEN_PER" & X, System.Type.GetType("System.Decimal")) ' Monto Exento de cada percep
                dtRecibos.Columns.Add("U_PER" & X, System.Type.GetType("System.Decimal"))
            Next

            dtRecibos.Columns.Add("TOT_PER", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("TOT_DED", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("SALDO_ISR", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("SEM_ISR", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("BON_DES", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("BON_ASP", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("BON_ESP", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("COMENTARIO", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("FECHA_INI", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("FECHA_FIN", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("FECHA_INI_NOM", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("FECHA_FIN_NOM", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("FECHA_PAGO", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("DIASPAG", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("TOT_GRAV", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("TOT_EXEN", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("ISR", System.Type.GetType("System.Decimal"))
            dtRecibos.Columns.Add("IMPORTE_LETRA", System.Type.GetType("System.String"))

            '----Datos para Timbrado
            dtRecibos.Columns.Add("serie", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("UUID", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("noCertificadoSAT", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("FechaTimbrado", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("sello", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("selloSat", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("selloCFD", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("path_qr", System.Type.GetType("System.String"))
            dtRecibos.Columns.Add("cadenaOriginal", System.Type.GetType("System.String"))


            dtRecibos.Columns.Add("LUNES", System.Type.GetType("System.DateTime"))
            dtRecibos.Columns.Add("MARTES", System.Type.GetType("System.DateTime"))
            dtRecibos.Columns.Add("MIERCOLES", System.Type.GetType("System.DateTime"))
            dtRecibos.Columns.Add("JUEVES", System.Type.GetType("System.DateTime"))
            dtRecibos.Columns.Add("VIERNES", System.Type.GetType("System.DateTime"))
            dtRecibos.Columns.Add("SABADO", System.Type.GetType("System.DateTime"))
            dtRecibos.Columns.Add("DOMINGO", System.Type.GetType("System.DateTime"))

            For X = 1 To 7
                dtRecibos.Columns.Add("E" & X, System.Type.GetType("System.String"))
                dtRecibos.Columns.Add("S" & X, System.Type.GetType("System.String"))
            Next

            For X = 1 To 7
                dtRecibos.Columns.Add("NOR" & X, System.Type.GetType("System.Double"))
                dtRecibos.Columns.Add("EXT" & X, System.Type.GetType("System.Double"))
            Next
            dtRecibos.Columns.Add("CP_SAT", System.Type.GetType("System.String"))
            Return True
        Catch ex As Exception
            Return False
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "EstructuraSObre", ex.HResult, ex.Message)
        End Try
    End Function

    Private Sub ListarImpresoras()
        Dim i As Integer
        Dim pkInstalledPrinters As String
        Dim ndImpresora As DevComponents.AdvTree.Node
        Dim prtdoc As New PrintDocument
        Dim strDefaultPrinter As String = prtdoc.PrinterSettings.PrinterName
        Try

            For Each pkInstalledPrinters In PrinterSettings.InstalledPrinters
                ndImpresora = New DevComponents.AdvTree.Node
                ndImpresora.Name = "Impresora" & i
                ndImpresora.Text = pkInstalledPrinters
                ndImpresora.Image = My.Resources.Printer16

                cmbImpresoras.Nodes.Add(ndImpresora)

                If pkInstalledPrinters = strDefaultPrinter Then
                    cmbImpresoras.SelectedIndex = cmbImpresoras.Nodes.IndexOf(ndImpresora)
                End If
            Next
        Catch ex As Exception
            Stop
        End Try
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Impresion(False)
    End Sub

    Private Sub txtReloj_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtReloj.Validating
        Dim R As String = txtReloj.Text
        If R.Length > 0 Then
            R = R.Trim.PadLeft(LongReloj, "0")
            dtTemporal = sqlExecute("SELECT reloj FROM nomina WHERE reloj = '" & R & "' AND ano+periodo = '" & cmbPeriodos.SelectedValue & "'", "Nomina")
            If dtTemporal.Rows.Count = 0 Then
                If MessageBox.Show("El empleado " & R & " no tiene información de nómina para el periodo seleccionado. Favor de verificar.", "Impresión de recibos", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Retry Then
                    e.Cancel = True
                Else
                    e.Cancel = False
                End If
            End If
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmbPeriodos_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbPeriodos.KeyDown
        If Not cmbPeriodos.IsPopupOpen Then cmbPeriodos.ShowDropDown()
    End Sub

    Private Sub cmbPeriodos_PopupClose(sender As Object, e As EventArgs) Handles cmbPeriodos.PopupClose
        varCmbPopOut = True
        'ActualizaInfo()                 'correcto 25/nov/20
    End Sub

    'Private Sub cmbPeriodos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPeriodos.SelectedValueChanged        'comentado 24/nov/20
    '    'MODIFICADO. ESTABA COMO COMENTARIO ORGINALMENTE. 20/NOV/20
    '    'ActualizaInfo()
    'End Sub

    Private Sub ActualizaInfo(Optional varReloj As String = "")             'Se agrego parametro varReloj       24/nov/20
        Try
            Me.Refresh()                                                    'refrescar
            Dim AnoPeriodo As String = cmbPeriodos.SelectedValue
            Dim tipo_periodo As String = ""
            Dim drPersonal As DataRow
            Dim drRecibo As DataRow
            Dim dtSobre As New DataTable
            Dim Reloj As String

            Dim FI As String = ""
            Dim FF As String = ""
            Dim FECHA_INI_NOM As String = ""
            Dim FECHA_FIN_NOM As String = ""
            Dim FP As String = ""
            Dim M As String = ""
            Dim periodoAdmin As String = ""

            Dim TotPer As Double = 0
            Dim TotDed As Double = 0
            Dim OtrBon As Double = 0
            Dim AhorroEmp As Double = 0
            Dim AhorroEmpr As Double = 0
            Dim Retiros As Double = 0
            Dim AhorroTottal As Double = 0
            Dim Fonacot As Double = 0
            Dim Infonavit As Double = 0
            Dim SaldoISR As Double = 0
            Dim SemISR As Double = 0
            Dim BonDes As Double = 0
            Dim BonAsP As Double = 0

            Dim P As Integer = 0
            Dim D As Integer = 0
            Dim Naturaleza As String
            Dim conc_exento As String ' Obtener concepto Exento
            Dim TOT_GRAV As Double = 0
            Dim TOT_EXEN As Double = 0
            Dim ISR As Double = 0
            Dim BON_DES As Double = 0
            Dim IMPORTE_LETRA As String = ""
            Dim DIASPAG As String = ""

            Dim fInicial As Date

            If dtRecibos.Columns.Count = 0 Or Iniciando Then
                'Si no se ha creado la estructura para los recibos, o está apenas iniciando salir de la subrutina
                Exit Sub
            End If

            'frmTrabajando.Show(Me)
            'frmTrabajando.Text = "Cargando información " & AnoPeriodo
            'frmTrabajando.Avance.Value = 0
            'frmTrabajando.Avance.IsRunning = False
            'frmTrabajando.lblAvance.Text = "Preparando datos..."
            'Application.DoEvents()

            'Clonar la tabla de recibos, para tomar un registro en blanco, pero con la misma estructura
            dtRecibos.Rows.Clear()
            dtSobre = dtRecibos.Clone
            dtSobre.Rows.Add()
            'DataRow para llenar información del registro actual
            drRecibo = dtSobre.Rows(0)

            'Obtener el tipo de periodo
            If (chkTipoPerSem.Checked) Then tipo_periodo = "S"
            If (chkTipoPerCat.Checked) Then tipo_periodo = "C"

            'Obtener rango de fechas del periodo seleccionado
            If tipo_periodo = "C" Then
                dtTemporal = sqlExecute("SELECT fecha_ini,fecha_fin,FECHA_PAGO,mes,periodo,ano,DATEDIFF(dd, FECHA_INI, FECHA_FIN) +1 as DIASPAG,fini_nom,ffin_nom FROM periodos_catorcenal WHERE ano+periodo = '" & AnoPeriodo & "'", "TA")
            Else
                dtTemporal = sqlExecute("SELECT fecha_ini,fecha_fin,FECHA_PAGO,mes,periodo,ano,DATEDIFF(dd, FECHA_INI, FECHA_FIN) +1 as DIASPAG,fini_nom,ffin_nom  FROM periodos WHERE ano+periodo = '" & AnoPeriodo & "'", "TA")
            End If

            If dtTemporal.Rows.Count = 0 Then
                Err.Raise(-1, cmbPeriodos, "Periodo no localizado")
            Else
                'Inicializar variables de rango de fechas y mes
                FI = FechaCortaLetra(dtTemporal.Rows(0).Item("fecha_ini"))
                FF = FechaCortaLetra(dtTemporal.Rows(0).Item("fecha_fin"))
                FECHA_INI_NOM = FechaCortaLetra(dtTemporal.Rows(0).Item("fini_nom"))
                FECHA_FIN_NOM = FechaCortaLetra(dtTemporal.Rows(0).Item("ffin_nom"))
                '   FP = FechaCortaLetra(DateAdd(DateInterval.Day, 5, dtTemporal.Rows(0).Item("fecha_fin")))
                FP = FechaCortaLetra(dtTemporal.Rows(0).Item("FECHA_PAGO"))
                M = IIf(IsDBNull(dtTemporal.Rows(0).Item("mes")), "", dtTemporal.Rows(0).Item("mes")).ToString.Trim
                periodoAdmin = dtTemporal.Rows(0).Item("periodo")
                fInicial = dtTemporal.Rows(0).Item("fecha_ini")
                Dim pt As Integer = Integer.Parse(periodoAdmin)
            End If

            'Obtener lista de números de empleados del periodo
            dtNomina = sqlExecute("SELECT reloj FROM nomina WHERE ano+periodo = '" & AnoPeriodo & "' and tipo_periodo='" & tipo_periodo & "'", "NOMINA")

            'frmTrabajando.Avance.Maximum = dtNomina.Rows.Count
            'Analizar cada empleado

            Dim dtAsist As DataTable = sqlExecute("select reloj, fha_ent_hor, min(entro) as entrada, max(salio) as salida, sum(1) as registros from asist where ano+periodo = '" & AnoPeriodo & "' group by reloj, fha_ent_hor order by reloj, fha_ent_hor", "ta")

            Dim dtAsistHoras As DataTable = sqlExecute("select reloj, fha_ent_hor, sum(round(dbo.HtoD(horas_normales), 2)) as normales, sum(round(dbo.HtoD(extras_autorizadas), 2)) as extras from asist where ano+periodo = '" & AnoPeriodo & "' group by reloj, fha_ent_hor order by reloj, fha_ent_hor", "ta")

            Dim dtAus As DataTable = sqlExecute("select ausentismo.reloj, ausentismo.fecha, ausentismo.tipo_aus from ausentismo left join periodos on ausentismo.fecha between periodos.fecha_ini and periodos.fecha_fin  where periodos.ano = '" & AnoPeriodo.Substring(0, 4) & "' and periodos.periodo = '" & AnoPeriodo.Substring(4, 2) & "' and isnull(periodos.periodo_especial, 0) = 0 ", "ta")

            Dim dtPersonalTodo As New DataTable
            dtPersonalTodo = sqlExecute("SELECT nominavw.* FROM nominaVW WHERE  ano+periodo = '" & _
                                        AnoPeriodo & "' and tipo_periodo='" & tipo_periodo & "'", "Nomina")

            Dim dtMovimientosTodo As New DataTable
            Dim QMovTodo As String = "SELECT movimientos.reloj, movimientos.ano, movimientos.periodo, conceptos.concepto AS CODIGO,conceptos.NOMBRE AS CONCEPTO,conceptos.PRIORIDAD,conceptos.COD_SAT,conc_exento,movimientos.MONTO, " & _
                                           "conceptos.cod_naturaleza,conceptos.UNIDAD," & _
                                           "SUMA_NETO,POSITIVO FROM MOVIMIENTOS LEFT JOIN conceptos ON conceptos.concepto = movimientos.concepto " & _
                                           "WHERE ano+periodo = '" & AnoPeriodo & "' and tipo_periodo='" & tipo_periodo & "' ORDER BY PRIORIDAD,COD_NATURALEZA,CONCEPTO"
            dtMovimientosTodo = sqlExecute(QMovTodo, "Nomina")

            '---Obtener datos de timbrado
            Dim dtTimbradosTodo As New DataTable
            Dim QTimb As String = "select *,('?re=' + emisor + '&rr=' + receptor + '&tt=' + total + '&id=' + UUID) as qr from timbrado where ano+periodo='" & AnoPeriodo & "' and tipo_periodo='" & tipo_periodo.ToString.Trim & "' and cod_comp='" & cod_comp & "'"
            dtTimbradosTodo = sqlExecute(QTimb, "NOMINA")

            '--- Obtener datos del Maestro de deducciones
            dtMtroDed = sqlExecute("select * from mtro_ded", "NOMINA")

            '--AGREGADO MARZO/23
            If (chkTipoPerCat.Checked) Then
                Dim dtPerCat As DataTable = sqlExecute("select ano+PERIODO as anoper from ta.dbo.periodos  where ano+nombre='" & AnoPeriodo & "'", "nomina")
                Dim anoperCat As String = ""
                If (dtPerCat.Rows.Count > 0) Then
                    Try : anoperCat = dtPerCat.Rows(0).Item("anoper").ToString.Trim : Catch ex As Exception : anoperCat = "" : End Try
                End If
                dtSaldosCA = sqlExecute("select * from saldos_ca where ano+periodo='" & anoperCat & "'", "NOMINA")
            End If

            If (chkTipoPerSem.Checked) Then
                dtSaldosCA = sqlExecute("select * from saldos_ca where ano+periodo='" & AnoPeriodo & "'", "NOMINA")
            End If
            '--

            'Agregado nov/20
            Dim filasNomina As Integer                                          '24/nov/2020
            Dim tope As Integer

            If dtNomina.Rows.Count > 0 Then
                filasNomina = dtNomina.Rows.Count                               'Numero de registros. Var real
                tope = filasNomina - 1
            Else
                MessageBox.Show("El periodo seleccionado no contiene datos de empleados", "Error", MessageBoxButtons.OK)
                Exit Sub
            End If

            Dim arr(tope) As String                                             'Arreglo que almacena los registros
            Dim porcentaje As Double = 0                                        'Porcentaje barra progreso
            Dim cont As Integer = 0                                             'Contador

            If varTodos Or varCmbPopOut Then
                'Todos los registros
                For i As Integer = 0 To tope
                    arr(i) = "reloj='" & Trim(dtNomina.Rows(i).Item("reloj").ToString) & "'"
                Next
            Else
                'Un registro
                arr(0) = "reloj='" & Trim(varReloj) & "'"
                filasNomina = 1
                tope = filasNomina
            End If

            If varTodos = False And varCmbPopOut Then
                arr(0) = "reloj='" & Trim(varReloj) & "'"
                filasNomina = 1
                tope = filasNomina
                varCmbPopOut = False
            End If

            ''-------------------------------''
            For i As Integer = 0 To tope                                                    '24/nov/20
                Application.DoEvents()                                                      'para la barra de progreso
                'For Each dRow As DataRow In dtNomina.Rows                                  'For original. Comentado.       24/nov/20
                For Each dRow As DataRow In dtNomina.Select(arr(i).ToString)                'Recorre la datatable de acuerdo al reloj       24/nov/20

                    '-----Iniciar variables en cero de los totales para cada empleado
                    TotPer = 0
                    TotDed = 0
                    TOT_GRAV = 0
                    TOT_EXEN = 0
                    ISR = 0
                    BON_DES = 0
                    IMPORTE_LETRA = ""
                    DIASPAG = "0"
                    '-----Ends

                    Reloj = dRow("reloj")

                    'frmTrabajando.lblAvance.Text = Reloj
                    'frmTrabajando.Avance.Value += 1
                    'Application.DoEvents()

                    'If Not ActivoTrabajando Then
                    '    MessageBox.Show("Los datos de nómina no fueron cargados correctamente.", "Recibos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    'dtRecibos.Rows.Clear()
                    '    Exit Sub
                    'End If

                    'Buscar información de nómina y personal
                    dtPersonal = dtPersonalTodo.Select("reloj = '" & Reloj & "'").CopyToDataTable

                    'Subir datos de nómina y personal a tabla de recibos
                    drPersonal = dtPersonal.Rows(0)
                    dtSobre.Rows.Clear()
                    drRecibo = dtSobre.Rows.Add
                    'For x = 0 To dtSobre.Columns.Count - 1
                    '    dtSobre.Rows(0).Item(x) = DBNull.Value
                    'Next
                    'drRecibo = dtSobre.Rows(0)

                    drRecibo("COD_TIPO_NOMINA") = drPersonal("COD_TIPO_NOMINA")
                    drRecibo("PERIODO") = drPersonal("PERIODO")
                    drRecibo("ANO") = drPersonal("ANO")
                    drRecibo("MES") = M
                    drRecibo("RELOJ") = drPersonal("RELOJ")
                    drRecibo("NOMBRES") = drPersonal("NOMBRES").ToString.Trim
                    drRecibo("COD_TURNO") = drPersonal("COD_TURNO")
                    'drRecibo("COD_LINEA") = drPersonal("COD_LINEA")
                    drRecibo("COD_DEPTO") = drPersonal("COD_DEPTO")
                    drRecibo("COD_SUPER") = drPersonal("COD_SUPER")
                    drRecibo("COD_HORA") = drPersonal("COD_HORA")
                    drRecibo("COD_TIPO") = drPersonal("COD_TIPO")
                    drRecibo("COD_CLASE") = drPersonal("COD_CLASE").ToString.ToUpper.Trim
                    drRecibo("COD_PUESTO") = drPersonal("COD_PUESTO").ToString.ToUpper.Trim
                    drRecibo("COD_PLANTA") = drPersonal("COD_PLANTA").ToString.ToUpper.Trim
                    drRecibo("cuenta_banco") = drPersonal("cuenta").ToString.Trim
                    drRecibo("NOMBRE_DEPTO") = drPersonal("NOMBRE_DEPTO").ToString.ToUpper.Trim
                    drRecibo("NOMBRE_PUESTO") = drPersonal("NOMBRE_PUESTO").ToString.ToUpper.Trim
                    drRecibo("NOMBRE_PLANTA") = drPersonal("NOMBRE_PLANTA").ToString.ToUpper.Trim
                    drRecibo("COMPANIA") = drPersonal("COMPANIA").ToString.Trim
                    drRecibo("CIA_RFC") = drPersonal("CIA_RFC")
                    drRecibo("CIA_REG_PAT") = drPersonal("CIA_REG_PAT")

                    Dim NumImss As String
                    NumImss = IIf(IsDBNull(dtPersonal.Rows(0).Item("NUMIMSS")), "-----", dtPersonal.Rows(0).Item("NUMIMSS"))
                    drRecibo("IMSS") = NumImss.Trim
                    drRecibo("RFC") = IIf(IsDBNull(dtPersonal.Rows(0).Item("RFC")), "-----", dtPersonal.Rows(0).Item("RFC"))
                    drRecibo("CURP") = IIf(IsDBNull(dtPersonal.Rows(0).Item("CURP")), "-----", dtPersonal.Rows(0).Item("CURP"))

                    ' Cod postal SAT
                    Dim cp_sat As String = ""
                    Try : cp_sat = dtPersonal.Rows(0).Item("CP_SAT").ToString.Trim : Catch ex As Exception : cp_sat = "-----" : End Try
                    drRecibo("CP_SAT") = cp_sat


                    drRecibo("ALTA") = FechaCortaLetra(drPersonal("ALTA"))
                    If Not IsDBNull(drPersonal("BAJA")) Then
                        drRecibo("BAJA") = IIf(IsDBNull(drPersonal("BAJA")), "", FechaLetra(drPersonal("BAJA")))
                    End If
                    drRecibo("COD_PAGO") = drPersonal("COD_PAGO")
                    drRecibo("DEPOSITO") = IIf(IsDBNull(drPersonal("COD_PAGO")), "x", drPersonal("COD_PAGO")) = "D"
                    drRecibo("HORAS_NORMALES") = drPersonal("HORAS_NORMALES")
                    drRecibo("HORAS_DOBLES") = drPersonal("HORAS_DOBLES")
                    drRecibo("HORAS_TRIPLES") = drPersonal("HORAS_TRIPLES")
                    drRecibo("HORAS_FESTIVAS") = drPersonal("HORAS_FESTIVAS")
                    drRecibo("HORAS_DOMINGO") = drPersonal("HORAS_DOMINGO")
                    drRecibo("HORAS_COMPENSA") = drPersonal("HORAS_COMPENSA")
                    drRecibo("DIAS_VAC") = drPersonal("DIAS_VAC")
                    drRecibo("DIAS_AGUI") = drPersonal("DIAS_AGUI")
                    drRecibo("SACTUAL") = drPersonal("SACTUAL")
                    drRecibo("SMENSUAL") = Math.Round(drPersonal("SACTUAL") * 30, 2)
                    drRecibo("INTEGRADO") = drPersonal("INTEGRADO")

                    drRecibo("COMENTARIO") = txtComentario.Text
                    drRecibo("FECHA_INI") = FI
                    drRecibo("FECHA_FIN") = FF
                    drRecibo("FECHA_INI_NOM") = FECHA_INI_NOM
                    drRecibo("FECHA_FIN_NOM") = FECHA_FIN_NOM
                    drRecibo("FECHA_PAGO") = FP
                    ' drRecibo("DIASPAG") = DIASPAG

                    drRecibo("LUNES") = fInicial
                    drRecibo("MARTES") = DateAdd(DateInterval.Day, 1, fInicial)
                    drRecibo("MIERCOLES") = DateAdd(DateInterval.Day, 2, fInicial)
                    drRecibo("JUEVES") = DateAdd(DateInterval.Day, 3, fInicial)
                    drRecibo("VIERNES") = DateAdd(DateInterval.Day, 4, fInicial)
                    drRecibo("SABADO") = DateAdd(DateInterval.Day, 5, fInicial)
                    drRecibo("DOMINGO") = DateAdd(DateInterval.Day, 6, fInicial)

                    Try

                        Dim dtdiasSemana As DataTable = New DataTable
                        dtdiasSemana.Columns.Add("num_dia")
                        dtdiasSemana.Columns.Add("nombre_dia")

                        dtdiasSemana.Rows.Add({"1", "lunes"})
                        dtdiasSemana.Rows.Add({"2", "martes"})
                        dtdiasSemana.Rows.Add({"3", "miercoles"})
                        dtdiasSemana.Rows.Add({"4", "jueves"})
                        dtdiasSemana.Rows.Add({"5", "viernes"})
                        dtdiasSemana.Rows.Add({"6", "sabado"})
                        dtdiasSemana.Rows.Add({"7", "domingo"})

                        For Each row_dia_semana As DataRow In dtdiasSemana.Rows
                            Try
                                Try
                                    For Each dAsist As DataRow In dtAsist.Select("reloj = '" & drPersonal("RELOJ") & "' and fha_ent_hor = '" & FechaSQL(drRecibo(row_dia_semana("nombre_dia"))) & "'")
                                        Try
                                            drRecibo("E" & row_dia_semana("num_dia")) = IIf(IsDBNull(dAsist("entrada")), "", "E - " & dAsist("entrada")) & IIf(dAsist("registros") > 1, " *", "")
                                            drRecibo("S" & row_dia_semana("num_dia")) = IIf(IsDBNull(dAsist("salida")), "", "S - " & dAsist("salida"))
                                        Catch ex As Exception

                                        End Try
                                    Next
                                Catch ex As Exception

                                End Try

                                Try
                                    For Each dAsist As DataRow In dtAsistHoras.Select("reloj = '" & drPersonal("RELOJ") & "' and fha_ent_hor = '" & FechaSQL(drRecibo(row_dia_semana("nombre_dia"))) & "'")
                                        Try
                                            drRecibo("NOR" & row_dia_semana("num_dia")) = dAsist("normales")
                                            drRecibo("EXT" & row_dia_semana("num_dia")) = dAsist("extras")
                                        Catch ex As Exception

                                        End Try
                                    Next
                                Catch ex As Exception

                                End Try

                                Try
                                    For Each dAus As DataRow In dtAus.Select("reloj = '" & drPersonal("RELOJ") & "' and fecha = '" & FechaSQL(drRecibo(row_dia_semana("nombre_dia"))) & "'")
                                        Try
                                            drRecibo("E" & row_dia_semana("num_dia")) = dAus("tipo_aus")
                                            drRecibo("S" & row_dia_semana("num_dia")) = ""
                                        Catch ex As Exception

                                        End Try
                                    Next
                                Catch ex As Exception

                                End Try

                            Catch ex As Exception

                            End Try

                        Next

                    Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
                    End Try

                    'Inicializa variables de saldos y totales
                    TotPer = TotalPercepciones(Reloj, AnoPeriodo)
                    TotDed = TotalDeducciones(Reloj, AnoPeriodo)
                    D = 0
                    P = 0

                    'Información de movimientos del empleado en el periodo

                    dtMovimientos = dtMovimientosTodo.Select("reloj = '" & Reloj & "'").CopyToDataTable

                    'Analizar cada movimiento
                    For Each drMovs As DataRow In dtMovimientos.Rows

                        Dim MontoExen As Double = 0
                        Dim UnidadMonto As Double = 0
                        Dim cod_concepto As String = IIf(IsDBNull(drMovs("CODIGO")), "X", drMovs("CODIGO")).ToString.Trim
                        Dim UNIDAD As String = IIf(IsDBNull(drMovs("UNIDAD")), "", drMovs("UNIDAD")).ToString.Trim
                        conc_exento = IIf(IsDBNull(drMovs("conc_exento")), "X", drMovs("conc_exento")).ToString.Trim 'Concepto exento
                        Naturaleza = IIf(IsDBNull(drMovs("cod_naturaleza")), "I", drMovs("cod_naturaleza")).ToString.Trim

                        '----Dias de pago
                        If (cod_concepto.Trim = "DIASPA") Then
                            DIASPAG = drMovs("monto")
                            If (Double.Parse(DIASPAG) >= 30) Then DIASPAG = "30" ' Aplica para las nominas mensuales
                        End If
                        drRecibo("DIASPAG") = DIASPAG
                        '-----End Dias de pago

                        If Naturaleza = "P" Or Naturaleza = "D" Or cod_concepto.Trim = "BONDES" Then
                            If ((drMovs("positivo") And drMovs("suma_neto")) Or drMovs("CODIGO").ToString.Trim = "BONDES") Then ' Si es Perc y suma al neto, o el bono de despensa que se incluye
                                P += 1
                                If P > 13 Then
                                    P = 13
                                    drRecibo("desc_per" & P) = "OTRAS PERCEPCIONES"
                                Else
                                    drRecibo("desc_per" & P) = drMovs("concepto").ToString.Trim
                                End If
                                '  drRecibo("cant_per" & P) = drMovs("monto") + IIf(IsDBNull(drRecibo("cant_per" & P)), 0, drRecibo("cant_per" & P))
                                drRecibo("cant_per" & P) = drMovs("monto")
                                drRecibo("COD_SAT_PER" & P) = drMovs("COD_SAT")

                                '---- AO prueba para ver que es lo que va sumando
                                'Dim _concepto As String = "", _montoTest As Double = 0.0
                                '_concepto = drMovs("concepto").ToString.Trim
                                '_montoTest = drRecibo("cant_per" & P)
                                '---- Ends Prueba

                                TotPer = TotPer + drRecibo("cant_per" & P) ' Ir sumando para obtener el total de percepciones

                                '----------Obtener Unidad  de los conceptos que tengan un concepto para mostrar el monto de la unidad, x ejemplo, el total de hrs dobles o triples
                                If (UNIDAD.Trim <> "") Then
                                    Try
                                        dtMontoHrExtra = dtMovimientosTodo.Select("reloj = '" & Reloj & "' and CODIGO='" & UNIDAD & "'").CopyToDataTable
                                        For Each drMontoUnidad As DataRow In dtMontoHrExtra.Rows
                                            UnidadMonto = drMontoUnidad("monto")
                                            If (UNIDAD.Trim = "HRSNOR") Then UnidadMonto = Math.Round(UnidadMonto / 8, 2) ' Para la percep normal, los dias = hrs/8
                                        Next
                                    Catch ex As Exception

                                    End Try
                                    drRecibo("U_PER" & P) = UnidadMonto
                                End If

                                '---Obtener parte Gravable y exenta de cada percep
                                If (conc_exento.Trim = "X") Then 'Si no tiene ningun concepto exento, va a gravar 100%
                                    drRecibo("GRAV_PER" & P) = drMovs("monto")
                                    TOT_GRAV = TOT_GRAV + drRecibo("GRAV_PER" & P)
                                Else 'Obtener parte Exenta segun del concepto que tenga

                                    'NOTA: CONCEPTOS QUE EXENTAN AL 100%:
                                    If (conc_exento = "BONDES") Then
                                        drRecibo("EXEN_PER" & P) = drMovs("monto")
                                        TOT_EXEN = TOT_EXEN + drRecibo("EXEN_PER" & P)
                                    Else ' Conceptos que tienen parte gravada y parte exenta
                                        ' 1.- Tomar el monto del concepto que es exento segun el concepto que lo trae la variable "conc_exento", y ese valor va a ser el valor exento
                                        ' 2.- Lo gravable = Lo que tengamos en monto - el monto exento
                                        '--NOTA: Lo unico complicado es traernos el monto del concepto exento que esta en este datable
                                        Try
                                            dtMovConcExento = dtMovimientosTodo.Select("reloj = '" & Reloj & "' and CODIGO='" & conc_exento.Trim & "'").CopyToDataTable
                                            For Each drMovExen As DataRow In dtMovConcExento.Rows
                                                MontoExen = drMovExen("monto")
                                            Next
                                        Catch ex As Exception
                                        End Try
                                        '---Para el caso de APOCIA es especial, ya que lo que grava lo trae su valor de exento, y lo que grava es lo contrario
                                        '---14/02/2020: AOS - Ya no es necesario ya que lo exento ya viene en el concepto PEXFAH a partir del periodo 02 del 2020
                                        'If (cod_concepto.Trim = "APOCIA") Then
                                        '    drRecibo("GRAV_PER" & P) = MontoExen
                                        '    drRecibo("EXEN_PER" & P) = drMovs("monto") - MontoExen
                                        '    GoTo Totales
                                        'End If

                                        '--Para todos los demas conceptos lo exento si es lo que traen en su valor de excento
                                        drRecibo("EXEN_PER" & P) = MontoExen
                                        drRecibo("GRAV_PER" & P) = drMovs("monto") - MontoExen

Totales:
                                        TOT_EXEN = TOT_EXEN + drRecibo("EXEN_PER" & P)
                                        TOT_GRAV = TOT_GRAV + drRecibo("GRAV_PER" & P)


                                    End If
                                End If
                                '--------------Termina parte gravable y exenta de cada concepto

                                '----Sumar Bono de despensa
                                If (cod_concepto.Trim = "BONDES") Then BON_DES = BON_DES + drRecibo("cant_per" & P)

                                '------------------DETALLE DE DIAS Y HORAS
                                Select Case drMovs("codigo").ToString.Trim

                                    Case "PERNOR"
                                        drRecibo("BASE_PER" & P) = MontoConcepto_2(dtMovimientosTodo, drRecibo("reloj"), AnoPeriodo, "HRSNOR")
                                    Case "PEREX2"
                                        drRecibo("BASE_PER" & P) = MontoConcepto_2(dtMovimientosTodo, drRecibo("reloj"), AnoPeriodo, "HRSEX2")
                                    Case "PEREX3"
                                        drRecibo("BASE_PER" & P) = MontoConcepto_2(dtMovimientosTodo, drRecibo("reloj"), AnoPeriodo, "HRSEX3")
                                    Case "PERFES"
                                        drRecibo("BASE_PER" & P) = MontoConcepto_2(dtMovimientosTodo, drRecibo("reloj"), AnoPeriodo, "HRSFES")
                                    Case "PERDOM"
                                        drRecibo("BASE_PER" & P) = MontoConcepto_2(dtMovimientosTodo, drRecibo("reloj"), AnoPeriodo, "HRSDOM")
                                    Case "PERVAC"
                                        drRecibo("BASE_PER" & P) = MontoConcepto_2(dtMovimientosTodo, drRecibo("reloj"), AnoPeriodo, "DIASVA")
                                    Case "PERAGI"
                                        drRecibo("BASE_PER" & P) = MontoConcepto_2(dtMovimientosTodo, drRecibo("reloj"), AnoPeriodo, "DIASAG")
                                End Select
                                '-----------------Termina Detalle de dias y horas
                            Else
                                '-------DEDUCCIONES
                                If drMovs("suma_neto") Then
                                    D += 1
                                    If D > 13 Then
                                        D = 13
                                        drRecibo("desc_ded" & D) = "OTRAS DEDUCCIONES"
                                    Else
                                        drRecibo("desc_ded" & D) = drMovs("concepto")

                                        '*************Obtener SALDOS
                                        '- Saldo del fondo de ahorro
                                        Dim Conc As String = drMovs("CODIGO")
                                        If ((Conc.Trim = "APOFAH" Or Conc.Trim = "RETCIA")) Then
                                            Dim ConcsSaldoFAH As String = "'SAFAHC','SAFAHE','RETFAH'"  ' Conceptos que entran para el saldo del fondo de ahorrro por el momento para pruebas, pero queda pendiente de definir
                                            Dim SAFAHC As Double = 0
                                            Dim SAFAHE As Double = 0
                                            Dim RETFAH As Double = 0
                                            Dim QSFAH As String = "SELECT * from movimientos where ano+PERIODO='" & AnoPeriodo & "' and CONCEPTO in(" & ConcsSaldoFAH & ") and reloj='" & Reloj.Trim & "' AND MONTO>0"
                                            Dim dtSaldoFAh As DataTable = sqlExecute(QSFAH, "NOMINA")
                                            If (Not dtSaldoFAh.Columns.Contains("Error") And dtSaldoFAh.Rows.Count > 0) Then
                                                For Each dr As DataRow In dtSaldoFAh.Rows
                                                    Dim Concep As String = IIf(IsDBNull(dr("CONCEPTO")), "", dr("CONCEPTO").ToString.Trim)
                                                    If (Concep.Trim = "SAFAHC") Then SAFAHC = IIf(IsDBNull(dr("MONTO")), 0.0, dr("MONTO"))
                                                    If (Concep.Trim = "SAFAHE") Then SAFAHE = IIf(IsDBNull(dr("MONTO")), 0.0, dr("MONTO"))
                                                    If (Concep.Trim = "RETFAH") Then RETFAH = IIf(IsDBNull(dr("MONTO")), 0.0, dr("MONTO"))
                                                Next
                                            End If

                                            If (Conc.Trim = "APOFAH") Then drRecibo("SAFAHE") = SAFAHE ' Saldo FAH Empleado
                                            If (Conc.Trim = "RETCIA") Then
                                                drRecibo("SAFAHC") = SAFAHC ' Saldo FAH Compañía
                                                drRecibo("RETFAH") = RETFAH ' Retiro si es que tuvo retiro del Fondo de Ahorro
                                            End If
                                        End If
                                        '- Ends Saldo FAH


                                    End If
                                    drRecibo("cant_ded" & D) = drMovs("monto") + IIf(IsDBNull(drRecibo("cant_ded" & D)), 0, drRecibo("cant_ded" & D))
                                    drRecibo("COD_SAT_DED" & D) = drMovs("COD_SAT")
                                    TotDed = TotDed + drRecibo("cant_ded" & D) ' Ir sumando para obtener el total de deducciones
                                    If (cod_concepto.Trim = "ISPTRE") Then ISR = ISR + drRecibo("cant_ded" & D) ' Sumar el ISR para obtener el total de ISR

                                Else
                                    '**** EN ESPECIE ****
                                    'PENDIENTE
                                End If
                            End If
                        End If

                        '--- Obtener los saldos del fondo de ahorro del Maestro de deducciones
                        'For Each drM As DataRow In dtMtroDed.Select("concepto in('SAFAHC','SAFAHE') and reloj='" & Reloj & "'")
                        '    Dim conc As String = "", saldo_act As Double = 0.0
                        '    Try : conc = drM("concepto").ToString.Trim : Catch ex As Exception : conc = "" : End Try
                        '    Try : saldo_act = Double.Parse(drM("saldo_act")) : Catch ex As Exception : saldo_act = 0.0 : End Try

                        '    Select Case conc
                        '        Case "SAFAHE"
                        '            drRecibo("AHORRO_EMP") = saldo_act
                        '        Case "SAFAHC"
                        '            drRecibo("AHORRO_EMPR") = saldo_act
                        '    End Select
                        'Next

                        '----Obtener saldos del Fondo de ahorro en base al año y periodo generado
                        For Each drSalFah As DataRow In dtSaldosCA.Select("concepto in ('SAFAHC','SAFAHE') and reloj='" & Reloj & "'")
                            Dim conc As String = "", saldo_act As Double = 0.0
                            Try : conc = drSalFah("concepto").ToString.Trim : Catch ex As Exception : conc = "" : End Try
                            Try : saldo_act = Double.Parse(drSalFah("saldo_act")) : Catch ex As Exception : saldo_act = 0.0 : End Try

                            Select Case conc
                                Case "SAFAHE"
                                    drRecibo("AHORRO_EMP") = saldo_act
                                Case "SAFAHC"
                                    drRecibo("AHORRO_EMPR") = saldo_act
                            End Select

                        Next


                        'Si es naturaleza A,I o E
                        Select Case drMovs("codigo").ToString.Trim
                            'Case "BONDES"
                            '    drRecibo("bon_des") = drMovs("monto")
                            Case "APOFAH"
                                drRecibo("APOFAH") = drMovs("monto")
                            Case "BONASP"
                                drRecibo("bon_asp") = drMovs("monto")
                                'Case "SAFAHE"
                                '    drRecibo("AHORRO_EMP") = drMovs("monto")
                                'Case "SAFAHC"
                                '    drRecibo("AHORRO_EMPR") = drMovs("monto")
                            Case "SALPFA"
                                drRecibo("PRESTAMO") = drMovs("monto")
                            Case "RETFAH", "SALP1", "SALI1"
                                drRecibo("RETIROS") = IIf(IsDBNull(drRecibo("RETIROS")), 0, drRecibo("RETIROS")) + IIf(IsDBNull(drMovs("monto")), 0, drMovs("monto"))
                            Case "SALFNT"
                                drRecibo("FONACOT") = drMovs("monto")
                            Case "SALADI"
                                drRecibo("INFONAVIT") = drMovs("monto")
                            Case "SEMACO"
                                drRecibo("SEM_ISR") = drMovs("monto")
                            Case "SALIFA"
                                drRecibo("SALDO_ISR") = IIf(IsDBNull(drMovs("monto")), 0, drMovs("monto"))
                            Case "SALICA"
                                drRecibo("SALDO_ISR") = IIf(IsDBNull(drMovs("monto")), 0, -drMovs("monto"))
                            Case "BONOS", "DESEFE"
                                drRecibo("BON_ESP") = IIf(IsDBNull(drRecibo("bon_esp")), 0, drRecibo("bon_esp")) + drMovs("monto")
                        End Select
                    Next

                    '-------Obtener datos de TIMBRADO
                    If (Not dtTimbradosTodo.Columns.Contains("Error") And dtTimbradosTodo.Rows.Count > 0) Then
                        '   For Each dRowTimb As DataRow In dtTimbradosTodo.Rows
                        For Each dRowTimb As DataRow In dtTimbradosTodo.Select("RELOJ='" & Reloj.Trim & "'")
                            Dim drTimb As DataRow = Nothing
                            Try
                                drTimb = dtTimbradosTodo.Select("RELOJ='" & Reloj.Trim & "'")(0)
                            Catch ex As Exception

                            End Try
                            If Not IsNothing(drTimb) Then
                                drRecibo("serie") = drTimb("serie").ToString.Trim
                                drRecibo("UUID") = drTimb("UUID").ToString.Trim
                                drRecibo("noCertificadoSAT") = drTimb("noCertificadoSAT").ToString.Trim
                                drRecibo("FechaTimbrado") = drTimb("FechaTimbrado").ToString.Trim
                                drRecibo("sello") = drTimb("sello").ToString.Trim
                                drRecibo("selloSat") = drTimb("selloSat").ToString.Trim
                                drRecibo("selloCFD") = drTimb("selloCFD").ToString.Trim
                                drRecibo("cadenaOriginal") = "||1.0|" & drTimb("UUID") & "|" & drTimb("FechaTimbrado") & "|" & drTimb("sello") & "|" & drTimb("noCertificadoSAT")

                                'COMENTADO 24/NOV/20            *descomentar al finalizar pruebas
                                ''-----------Generar  Imagen QR
                                Dim qr As Bitmap = GenerateQRCode(drTimb("qr"), Color.Black, Color.White, 6)
                                Dim dtTemp As DataTable = sqlExecute("select path_qr from cias where CIA_DEFAULT=1", "KIOSCO") ' Obtener Path donde se guardan las fotos para generar imagn QR
                                PathFoto = dtTemp.Rows.Item(0).Item("path_qr").ToString.Trim
                                If PathFoto.Substring(PathFoto.Length - 1, 1) <> "\" Then PathFoto = PathFoto & "\"
                                If File.Exists(PathFoto & Reloj.Trim & "qr.bmp") Then File.Delete(PathFoto & Reloj.Trim & "qr.bmp")
                                qr.Save(PathFoto & Reloj.Trim & "qr.bmp", System.Drawing.Imaging.ImageFormat.Bmp)
                                drRecibo("path_qr") = PathFoto & Reloj.Trim & "qr.bmp"
                                ''-----------Ends Gen Imagen QR
                            End If
                        Next

                    End If

                    '-------ENDS
                    'Totales
                    IMPORTE_LETRA = ConvNvo(TotPer - TotDed)                       'comentado 24/nov/20        *descomentar al finalizar pruebas
                    drRecibo("IMPORTE_LETRA") = IMPORTE_LETRA.Trim
                    drRecibo("TOT_PER") = TotPer
                    drRecibo("TOT_DED") = TotDed
                    drRecibo("TOT_GRAV") = TOT_GRAV
                    drRecibo("TOT_EXEN") = TOT_EXEN
                    drRecibo("ISR") = ISR
                    drRecibo("BON_DES") = BON_DES
                    drRecibo("NETO") = TotPer - TotDed
                    drRecibo("AHORRO_TOTAL") = IIf(IsDBNull(drRecibo("AHORRO_EMP")), 0, drRecibo("AHORRO_EMP")) + IIf(IsDBNull(drRecibo("AHORRO_EMPR")), 0, drRecibo("AHORRO_EMPR"))
                    drRecibo("AHORRO_NETO") = IIf(IsDBNull(drRecibo("AHORRO_EMP")), 0, drRecibo("AHORRO_EMP")) + _
                        IIf(IsDBNull(drRecibo("AHORRO_EMPR")), 0, drRecibo("AHORRO_EMPR")) - _
                        (IIf(IsDBNull(drRecibo("RETIROS")), 0, drRecibo("RETIROS")) + (IIf(IsDBNull(drRecibo("PRESTAMO")), 0, drRecibo("PRESTAMO"))))

                    'Insertar el registro en la tabla de los recibos
                    dtRecibos.Merge(dtSobre)
                Next

                'BARRA PROGRESO             24/NOV/20
                cont += 1

                If varActivoSeleccion Then
                    BarraProgreso("RecibosSeleccion", cont, filasNomina)
                End If
                If varActivoSeleccion = False And varActivoRecibos Then
                    BarraProgreso("RecibosPrincipal", cont, filasNomina)
                End If

                'SI ES UN REGISTRO SELECCIONADO
                If varTodos = False And varCmbPopOut = False Then
                    Exit For
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("Se detectó un error durante la carga de información del periodo seleccionado. Favor de verificar" & vbCrLf & vbCrLf & "Error.-" & ex.Message, "Recibos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally

            If Not (dtRecibos.Columns.Count = 0 Or Iniciando) Then
                LlenarGrupos()
            End If
            'ActivoTrabajando = False
            'frmTrabajando.Close()
            'frmTrabajando.Dispose()
        End Try
    End Sub

    Public Sub BarraProgreso(caso As String, x As Integer, fil As Integer)       'funcion añadida    25/nov/20      'correcto
        Dim cont As Integer = 0
        Dim porcentaje As Double

        Select Case caso
            Case "RecibosSeleccion"
                cont += x
                porcentaje = ((cont / fil) * 100).ToString("F2")
                frmCantidadEmpleadosRecibos.lblBarra.Text = "Registro " & cont & " de " & fil & "  -  " & porcentaje & " %"
                frmCantidadEmpleadosRecibos.pbCargarRecibos.Value = (100 / fil) * cont
            Case "RecibosPrincipal"
                cont += x
                porcentaje = ((cont / fil) * 100).ToString("F2")
                pbCarga.Value = (100 / fil) * cont
                If pbCarga.Value < 100 Then
                    LabelX1.Text = porcentaje & " %  -  Cargando periodo seleccionado, espere por favor"
                Else
                    LabelX1.Text = porcentaje & " %  -  Listo"
                End If
        End Select
    End Sub

    Private Function MontoConcepto(dtTabla As DataTable, ByVal Reloj As String, ByVal Ano As String, ByVal Periodo As String, ByVal concepto As String) As Double
        Try
            Return dtTabla.Select("ano = '" & Ano & "' AND periodo = '" & Periodo & "' AND reloj = '" & Reloj & "' AND codigo = '" & concepto & "'")(0)("monto")
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Function MontoConcepto_2(dtTabla As DataTable, ByVal Reloj As String, ByVal AnoPer As String, ByVal concepto As String) As Double
        Try
            Return dtTabla.Select("ano+periodo = '" & AnoPer & "' AND reloj = '" & Reloj & "' AND codigo = '" & concepto & "'")(0)("monto")
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Function MontoConcepto(ByVal Reloj As String, ByVal Ano As String, ByVal Periodo As String, ByVal concepto As String) As Double
        Try
            Dim dtMovs As New DataTable
            Dim monto As Double
            dtMovs = sqlExecute("SELECT monto FROM movimientos WHERE ano = '" & Ano & "' AND periodo = '" & Periodo & _
                                "' AND reloj = '" & Reloj & "' AND concepto = '" & concepto & "'", "nomina")

            If dtMovs.Rows.Count = 0 Then
                monto = 0
            Else
                monto = IIf(IsDBNull(dtMovs.Rows(0).Item("monto")), 0, dtMovs.Rows(0).Item("monto"))
            End If
            Return monto

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

            Return -1
        End Try
    End Function

    Private Sub LlenarGrupos()
        Try
            Dim ndGrupo As DevComponents.AdvTree.Node
            Dim ndOrden As DevComponents.AdvTree.Node
            Dim ndCondicion As DevComponents.AdvTree.Node
            Dim ndTot As DevComponents.AdvTree.Node
            Dim totPer As Decimal
            Dim totDed As Decimal
            Dim totRec As Integer
            Dim cnd() As String

            'Seleccionar datos de los grupos
            dtGrupos = sqlExecute("SELECT * FROM grupos_recibos ORDER BY prioridad", "Nomina")

            'Limpiar el treeview, por si tiene información
            trSeleccion.Nodes.Clear()

            Dim BAJA() As DataRow
            BAJA = dtRecibos.Select("COD_TIPO_NOMINA='B'")

            If (dtRecibos.Rows.Count <= 0 Or dtGrupos.Rows.Count <= 0) Then Exit Sub

            For Each dRow As DataRow In dtGrupos.Rows
                'Insertar cada registro de los grupos
                totPer = 0
                totDed = 0
                totRec = 0

                If dRow("cod_grupo") = "PRE" Then
                    'Si son recibos de préstamo, totalizar otros conceptos
                ElseIf dRow("COD_GRUPO") = "RET" Then
                    'Si son recibos de préstamo, totalizar otros conceptos
                Else

                    For Each dInfo As DataRow In dtRecibos.Select(dRow("condiciones").ToString.Trim)
                        If IsDBNull(dInfo("grupo")) Then
                            totPer += dInfo("TOT_PER")
                            totDed += dInfo("TOT_DED")
                            totRec += 1
                            dInfo("GRUPO") = dRow("COD_GRUPO")
                        Else
                            If dInfo("GRUPO") <> "NO" Then
                                dInfo("GRUPO") = "ERR"
                            End If
                        End If
                    Next
                End If

                'Crear nodo para el grupo
                ndGrupo = New DevComponents.AdvTree.Node
                ndGrupo.Name = dRow("cod_grupo")
                ndGrupo.Text = dRow("nombre")
                ndGrupo.CheckBoxVisible = True
                ndGrupo.Checked = True
                ndGrupo.Expanded = False

                'Columnas de totales en el nodo del grupo
                ndGrupo.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("Tot.Percepciones"))
                ndGrupo.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("Tot.Deducciones"))
                ndGrupo.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("Tot.Neto"))
                ndGrupo.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("# Recibos"))

                'Celdas del nodo de grupo
                ndTot = New DevComponents.AdvTree.Node
                ndTot.Text = FormatCurrency(totPer, 2)
                ndTot.Cells.Add(New DevComponents.AdvTree.Cell(FormatCurrency(totDed, 2)))
                ndTot.Cells.Add(New DevComponents.AdvTree.Cell(FormatCurrency((totPer - totDed), 2)))
                ndTot.Cells.Add(New DevComponents.AdvTree.Cell(totRec))

                'Agregar las celdas al nodo
                ndGrupo.Nodes.Add(ndTot)

                'Modificar el ancho de las columnas

                ndGrupo.NodesColumns(0).Width.Relative = 24
                ndGrupo.NodesColumns(1).Width.Relative = 26
                ndGrupo.NodesColumns(2).Width.Relative = 24
                'ndGrupo.NodesColumns(3).Width.Relative = 18
                ndGrupo.NodesColumns(3).Width.AutoSize = True
                ndGrupo.NodesColumns(3).Width.AutoSizeMinHeader = True

                'Crear subnodo para agregar el orden (cada campo, un nodo)
                ndOrden = New DevComponents.AdvTree.Node
                ndOrden.Name = "Orden"
                ndOrden.Text = "Orden"
                cnd = Split(dRow("orden"), ",")
                For Each it In cnd
                    ndOrden.Nodes.Add(New DevComponents.AdvTree.Node(it.Trim))
                Next

                'Crear subnodo para agregar las condiciones para pertenecer al grupo (cada campo, un nodo)
                ndCondicion = New DevComponents.AdvTree.Node
                ndOrden.Name = "Condiciones"
                ndCondicion.Text = "Condiciones"
                cnd = Split(IIf(IsDBNull(dRow("condiciones")), "", dRow("condiciones")), "AND")
                For Each it In cnd
                    ndCondicion.Nodes.Add(New DevComponents.AdvTree.Node(it.Trim.Replace("(", "").Replace(")", "")))
                Next

                'Agregar al nodo del grupo, los subnodos de orden y condiciones
                ndGrupo.Nodes.Add(ndCondicion)
                ndGrupo.Nodes.Add(ndOrden)

                'Agregar al treeview el nodo del grupo
                trSeleccion.Nodes.Add(ndGrupo)
            Next

            Dim VariosGrupos As Integer
            Dim SinGrupo As Integer

            VariosGrupos = dtRecibos.Select("GRUPO='ERR'").Count
            SinGrupo = dtRecibos.Select("GRUPO IS NULL").Count

            If VariosGrupos > 0 Or SinGrupo > 0 Then
                MessageBox.Show("Se detectaron errores al agrupar los datos." & vbCrLf & "     * " & VariosGrupos & _
                                " empleados pertenecen a más de un grupo" & vbCrLf & "     * " & SinGrupo & " empleados no pertenecen a algún grupo" & _
                                "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("No pudieron ser cargados los grupos de recibos." & vbCrLf & vbCrLf & "Err.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub chkExpandir_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandir.CheckedChanged, CheckBoxX1.CheckedChanged

        If chkExpandir.Checked Then
            trSeleccion.ExpandAll()
        Else
            trSeleccion.CollapseAll()
        End If
    End Sub


    Private Sub chkSeleccionar_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccionar.CheckedChanged, CheckBoxX2.CheckedChanged
        For Each nd As DevComponents.AdvTree.Node In trSeleccion.Nodes
            nd.Checked = chkSeleccionar.Checked
        Next
    End Sub


    Private Sub btnVistaPrevia_Click(sender As Object, e As EventArgs) Handles btnVistaPrevia.Click
        Impresion(True)
    End Sub

    Private Sub Impresion(ByVal VistaPrevia As Boolean)
        Try
            Dim Seleccion As String
            Dim Condiciones As String
            Dim Orden As String = ""
            Dim Grupo As String = ""
            Dim Reporte As String = ""
            Dim OrdenAnt As String = ""
            Dim Folio As Integer = 0
            Dim ContaRenglon As Integer = 0 '-------------------Agregado por Antonio

            Dim extension As String  'Jose R Hdez 26 sep 2020 Enviar recibo por correo
            extension = "PDF"
            Dim dtPathP As DataTable = sqlExecute("select top 1 path_recibos, path_xml from parametros ", "personal")
            Dim PathRecibos As String = ""
            Dim PathXml As String = "" '-----------Agregado por Antonio
            If dtPathP.Rows.Count > 0 Then
                PathRecibos = dtPathP.Rows(0).Item("path_recibos").ToString.TrimEnd
                PathXml = dtPathP.Rows(0).Item("path_xml").ToString.TrimEnd '------Agregado por Antonio
            Else
                PathRecibos = ""
                PathXml = "" '--------Agregado por Antonio
            End If

            Seleccion = tabBuscar.SelectedTab.Name

            For Each dReg As DataRow In dtRecibos.Rows
                dReg("COMENTARIO") = txtComentario.Text.Trim
            Next

            Dim CAT As String = "" '----------------------------------------------------------AGREGADO ANTONIO
            If chkTipoPerSem.Checked = True Then
                CAT = dtRecibos.Rows(0).Item("ano").ToString.Trim & "\S\" & dtRecibos.Rows(0).Item("periodo").ToString.Trim + "\"
            ElseIf chkTipoPerCat.Checked = True Then
                CAT = dtRecibos.Rows(0).Item("ano").ToString.Trim & "\C\" & dtRecibos.Rows(0).Item("periodo").ToString.Trim + "\"
            End If

            Dim PathDeXml As String = PathXml & CAT '---------------------------------Agregado por Antonio
            Dim di As DirectoryInfo = New DirectoryInfo(PathDeXml) '---------------------------------Agregado por Antonio

            Dim nomb As String = "" '---------------Agregado por Antonio
            Dim Valor As String '-----------------Agregado por Antonio

            Select Case Seleccion
                Case "tabSeleccion"
                    'Dim c As Integer
                    'c = trSeleccion.CheckedNodes.Count

                    'If c = 0 Then
                    '    MessageBox.Show("No se seleccionó ningún grupo de recibos a imprimir. Favor de verificar.", "Imprimir recibos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    '    Exit Sub
                    'End If
                    Folio = intFolio.Value

                    dtRecibosGlobal = New DataTable
                    For Each nd As DevComponents.AdvTree.Node In trSeleccion.Nodes
                        If nd.Checked Then
                            Grupo = nd.Name

                            dtTemporal = sqlExecute("SELECT reporte,orden,condiciones FROM grupos_recibos WHERE cod_grupo = '" & Grupo & "'", "nomina")
                            If dtTemporal.Rows.Count > 0 Then
                                Orden = IIf(IsDBNull(dtTemporal.Rows(0).Item("orden")), "", dtTemporal.Rows(0).Item("orden")).ToString.Trim
                                Condiciones = IIf(IsDBNull(dtTemporal.Rows(0).Item("condiciones")), "", dtTemporal.Rows(0).Item("condiciones")).ToString.Trim
                                Reporte = IIf(IsDBNull(dtTemporal.Rows(0).Item("reporte")), "", dtTemporal.Rows(0).Item("reporte")).ToString.Trim
                            Else
                                Condiciones = ""
                                Orden = ""
                            End If

                            If Orden <> OrdenAnt Then
                                Folio = intFolio.Value
                            End If

                            If Grupo = "PRE" Then
                                '    If frmVistaPrevia.EmitirRecibos(Reporte, cmbImpresoras.Text, dtRecibos, Condiciones, Orden, Folio, VistaPrevia) Then
                                '        Folio = Folio + dtRecibos.Rows.Count
                                '        frmVistaPrevia.ShowDialog()
                                '    End If
                                'ElseIf Grupo = "RET" Then
                                '    If frmVistaPrevia.EmitirRecibos(Reporte, cmbImpresoras.Text, dtRecibos, Condiciones, Orden, Folio, VistaPrevia) Then
                                '        Folio = Folio + dtRecibos.Rows.Count
                                '        frmVistaPrevia.ShowDialog()
                                '    End If
                            Else

                                If frmVistaPrevia.EmitirRecibos(Reporte, cmbImpresoras.Text, dtRecibos, Condiciones, Orden, Folio, VistaPrevia) Then
                                    Folio = Folio + dtRecibos.Rows.Count

                                End If
                                If chkMandarCorreos.Checked Then
                                    Folio = intFolio.Value

                                    ''---Mostrar Progress       COMENTADO. 24/NOV/20
                                    Dim i As Integer = -1

                                    'MODIFICACION FRM TRABAJANDO. COMENTAR  20/NOV/20
                                    frmTrabajando.Text = "Enviando recibos por Email"
                                    frmTrabajando.Avance.IsRunning = True
                                    frmTrabajando.lblAvance.Text = "Enviando recibos"
                                    ActivoTrabajando = True
                                    frmTrabajando.Show()
                                    Application.DoEvents()

                                    Try
                                        Dim dtRecibosFiltro = dtRecibos.Select(Condiciones, Orden).CopyToDataTable

                                        '--Mostrar progress. COMENTAR 20/NOV/20
                                        frmTrabajando.Avance.IsRunning = False
                                        frmTrabajando.lblAvance.Text = "Procesando datos"
                                        Application.DoEvents()
                                        frmTrabajando.Avance.Maximum = dtRecibosFiltro.Rows.Count

                                        For Each dRow As DataRow In dtRecibosFiltro.Rows
                                            Try : Reloj = dRow("reloj").ToString.Trim : Catch ex As Exception : Reloj = "" : End Try

                                            dRow("folio") = Folio.ToString.PadLeft(5, "0")
                                            dRow("cod_tipo") = Strings.Left(dRow("cod_tipo"), 1)
                                            VistaPrevia = False ' Para que ya no vuelva a generar el reporte  para vista Previa, EmitirRecibos genera el archivo pdf en la ruta path_recibos para luego mandarlo por correo
                                            frmVistaPrevia.EmitirRecibos(Reporte, cmbImpresoras.Text, dtRecibos.Select("reloj = '" & dRow("reloj") & "'").CopyToDataTable, Condiciones, Orden, Folio, VistaPrevia, PathRecibos & dRow("reloj") & ".pdf")


                                            ''----Mostrar Progress - avance         COMENTADO. 24/NOV/20
                                            i += 1
                                            ''COMENTAR FRMTRABAJANDO 20/NOV/20
                                            frmTrabajando.Avance.Value = i
                                            frmTrabajando.lblAvance.Text = Reloj
                                            Application.DoEvents()


                                            Dim dtEmail = sqlExecute("select email from personalvw  where reloj = " & dRow("reloj"), "personal")
                                            If dtEmail.Rows.Count > 0 Then
                                                Dim PathN As String = "" '---------Agregado por Antonio
                                                For Each Fi In di.GetFiles("*.xml") '----------------------------------------AGREGADO ANTONIO
                                                    PathN = ""
                                                    nomb = Fi.Name
                                                    Dim Arr() As String = nomb.Split("_")
                                                    Valor = Arr(3)
                                                    If Valor = dRow("reloj").ToString.Trim Then
                                                        PathN = PathDeXml & nomb
                                                        Exit For
                                                    End If
                                                Next
                                                EnviarRecibo(dtRecibos.Select("reloj = '" & dRow("reloj") & "'").CopyToDataTable.Rows(0), dtEmail.Rows(0).Item("email").ToString.Trim, PathRecibos & dRow("reloj") & ".pdf", PathN)
                                                If Not dtRecibosGlobal.Columns.Contains("Enviado") Then
                                                    dtRecibosGlobal.Columns.Add("Enviado")
                                                End If
                                                If EnviadoExitoso = True Then
                                                    dtRecibosGlobal.Rows(ContaRenglon)("Enviado") = "Correcto"
                                                Else
                                                    dtRecibosGlobal.Rows(ContaRenglon)("Enviado") = "Error al enviar, posible falta de XML"
                                                End If

                                            End If
                                            Folio += 1
                                            ContaRenglon += 1
                                        Next
                                        EnviadoExitoso = False
                                        ActivoTrabajando = False
                                        frmTrabajando.Close()
                                        frmTrabajando.Dispose()

                                    Catch

                                        ActivoTrabajando = False
                                        frmTrabajando.Close()
                                        frmTrabajando.Dispose()

                                    End Try
                                End If
                            End If
                            OrdenAnt = Orden
                        End If
                    Next
                    If dtRecibosGlobal.Rows.Count > 0 Then
                        Dim sfd As New SaveFileDialog
                        sfd.Filter = "Directorios|*.xls"
                        sfd.FileName = "Recibos Nomina.xls"
                        '    EncabezadoReporte = "RELACION DE RECIBOS SEMANA DEL " & cmbPeriodos.SelectedNode.ToString().Split(",")(3).Split("/")(1) & " de " & MesLetra(Trim(cmbPeriodos.SelectedNode.ToString().Split(",")(3).Split("/")(0))) & " al " & cmbPeriodos.SelectedNode.ToString().Split(",")(4).Split("/")(1) & " " & MesLetra(Trim(cmbPeriodos.SelectedNode.ToString().Split(",")(4).Split("/")(0))) & " " & cmbPeriodos.SelectedNode.ToString().Split(",")(1)
                        If sfd.ShowDialog = DialogResult.OK Then
                            frmVistaPrevia.LlamarReporte("Relacion de Recibos Nomina", dtRecibosGlobal, , , False, sfd.FileName)
                            frmVistaPrevia.ShowDialog()
                        End If
                    End If
                Case "tabEmpleado"
                    dtRecibosGlobal = New DataTable
                    'Reporte = "ReciboWoll_V2" ' --> Este es el que trae el detalle de TA
                    Reporte = "Recibo_nomina"

                    'Jose R Hdez 26 sep 2020 Enviar recibo por correo
                    If frmVistaPrevia.EmitirRecibos(Reporte, cmbImpresoras.Text, dtRecibos, "RELOJ = '" & txtReloj.Text & "'", "RELOJ", intFolio.Value, VistaPrevia, PathRecibos & txtReloj.Text & ".pdf") Then

                    End If
                    If chkMandarCorreos.Checked Then
                        Dim dtEmail = sqlExecute("select email from personalvw  WHERE reloj = " & txtReloj.Text, "personal")
                        If dtEmail.Rows.Count > 0 Then
                            '--Generar recibo en la ruta path_recibos sin volver a mostrar el reporte
                            VistaPrevia = False
                            frmVistaPrevia.EmitirRecibos(Reporte, cmbImpresoras.Text, dtRecibos, "RELOJ = '" & txtReloj.Text & "'", "RELOJ", intFolio.Value, VistaPrevia, PathRecibos & txtReloj.Text & ".pdf")
                            dtRecibos.Select("reloj='" & txtReloj.Text.Trim & "'")
                            For Each Fi In di.GetFiles("*.xml") '-------------------------------------AGREGADO ANTONIO
                                nomb = Fi.Name
                                Dim Arr() As String = nomb.Split("_")
                                Valor = Arr(3)
                                If Valor = txtReloj.Text.Trim Then
                                    PathDeXml = PathDeXml & nomb
                                    Exit For
                                End If
                            Next
                            EnviarRecibo(dtRecibos.Select("reloj='" & txtReloj.Text.Trim & "'")(0), dtEmail.Rows(0).Item("email").ToString.Trim, PathRecibos & txtReloj.Text & ".pdf", PathDeXml)
                            If Not dtRecibosGlobal.Columns.Contains("Enviado") Then
                                dtRecibosGlobal.Columns.Add("Enviado")
                            End If
                            If EnviadoExitoso = True Then
                                dtRecibosGlobal.Rows(ContaRenglon)("Enviado") = "Correcto"
                            Else
                                dtRecibosGlobal.Rows(ContaRenglon)("Enviado") = "Error al enviar, posible falta de XML"
                            End If
                            EnviadoExitoso = False
                        Else
                            MessageBox.Show("Empleado no tiene capturado cuenta de correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        End If
                    End If
                    'if
            End Select
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmbPeriodos_TextChanged(sender As Object, e As EventArgs)

    End Sub


    Private Sub EnviarRecibo(Datos As DataRow, Destino As String, PathRecibo As String, Pathxml As String)
        Try
            Dim mensaje As String = ""
            Dim seleccionTab As String = ""
            seleccionTab = tabBuscar.SelectedTab.Name
            '"<p>" & _
            '"<font face = ""Verdana"" size = ""5""><strong>BRP DE MÉXICO, S.A de C.V.</strong></font><br/>" & _
            '"<font face = ""Verdana"" size = ""2"">" & _
            '"Avenida de las Industrias 2250, Parque Industrial Antonio J. Bermúdez, C.P. 32470<br/>" & _
            '"Ciudad Juárez, Chihuahua, México<br/>" & _
            '"</font>" & _
            '"</p>" & _
            '"<table><tbody style=""font-family:Calibri;""><tr>" & _
            '"<td><strong>Nombre:</strong></td><td>[NOMBRES]</td>" & _
            '"</tr><tr>" & _
            '"<td><strong>Número de reloj:</strong></td><td>[RELOJ]</td>" & _
            '"</tr><tr>" & _
            '"<td><strong>RFC:</strong></td><td>[RFC]</td>" & _
            '"</tr></tbody></table>" & _
            '"<font face = ""Calibri"">" & _
            '"<p>Por medio de este correo electrónico le informamos que ha sido generado su recibo " & _
            '"de nómina correspondiente al periodo <strong>[PERIODO]</strong> del año <strong>[ANO]</strong>, " & _
            '"que comprende las fechas <strong>[FECHA_INI]</strong> al <strong>[FECHA_FIN].</strong> " + txtMensajeExtra1.Text + "</p>" & _
            '"</font>" & _
            '"<table><tbody style=""font-family:Calibri;""><tr>" & _
            '"<td><strong>Folio Fiscal:</strong></td><td>[FOLIO_FISCAL]</td>" & _
            '"</tr><tr>" & _
            '"<td><strong>Fecha de pago:</strong></td><td>[FECHA_PAGO]</td>" & _
            '"</tr><tr>" & _
            '"<td><strong>Total Percepciones:</strong></td><td>[PERCEPCIONES] M.N.</td>" & _
            '"</tr><tr>" & _
            '"<td><strong>Total Deducciones:</strong></td><td>[DEDUCCIONES] M.N.</td>" & _
            '"</tr><tr>" & _
            '"<td><strong>NETO EFECTIVO:</strong></td><td>[NETO] M.N.<br/>" & _
            '"</tr></tbody></table>" & _
            '"<p style = ""padding-top:40px;""><font face = ""Calibri"" size =""0.5"">La información contenida en este correo es confidencial y puede ser legalmente privilegiada. Si usted no es el destinatario intencional, usted no debe leer , abrir, copiar, usar o diseminar esta información. Si usted ha recibido esto por error, rogamos lo notifique inmediatamente al remitente y borre este correo electrónico de su bandeja de entrada.</p></font>"
            'mensaje = mensaje.Replace("[RELOJ]", Datos("reloj"))
            'mensaje = mensaje.Replace("[NOMBRES]", Datos("nombres"))
            'mensaje = mensaje.Replace("[RFC]", Datos("rfc"))
            'mensaje = mensaje.Replace("[NETO]", String.Format("{0:C2}", Datos("neto")))
            'mensaje = mensaje.Replace("[PERCEPCIONES]", String.Format("{0:C2}", Datos("tot_per")))
            'mensaje = mensaje.Replace("[DEDUCCIONES]", String.Format("{0:C2}", Datos("tot_ded")))
            'mensaje = mensaje.Replace("[FOLIO_FISCAL]", Datos("UUID"))
            'mensaje = mensaje.Replace("[FECHA_PAGO]", FechaLetra(Datos("fechapago")))
            'mensaje = mensaje.Replace("[ANO]", Datos("ano"))
            'mensaje = mensaje.Replace("[PERIODO]", Datos("periodo"))
            'mensaje = mensaje.Replace("[FECHA_INI]", Datos("fecha_ini"))
            'mensaje = mensaje.Replace("[FECHA_FIN]", Datos("fecha_fin"))

            Select Case cod_comp
                Case "WME"
                    nombre_empresa = "WME - WOLLSDORF MEXICO , S.A. DE C.V."
                Case "WSM"
                    nombre_empresa = "WSM - WOLLSDORF SALES, S.A. DE C.V."
                Case "CTE"
                    nombre_empresa = "CTE - CTE TRANSPORTE"
                Case "CT2"
                    nombre_empresa = "CTE - CTE TRANSPORTE"
            End Select
            mensaje &= nombre_empresa & vbCrLf
            mensaje &= "Fuente de David 184-1" & vbCrLf
            mensaje &= "Fracc. Jardín de los Lagos" & vbCrLf
            mensaje &= "Cd. Juárez Chih. CP.32650" & vbCrLf

            mensaje &= "Nombre: [NOMBRES]" & vbCrLf
            mensaje &= "Número de reloj: [RELOJ]" & vbCrLf & vbCrLf

            mensaje &= "Por medio de este correo electrónico le informamos que ha sido generado su recibo " & vbCrLf
            mensaje &= "de nómina correspondiente al periodo [PERIODO] del año [ANO], " & vbCrLf
            mensaje &= "que comprende las fechas [FECHA_INI] al [FECHA_FIN]." & vbCrLf & vbCrLf

            mensaje &= "La información contenida en este correo es confidencial y puede ser legalmente privilegiada. Si usted no es el destinatario intencional, usted no debe leer , abrir, copiar, usar o diseminar esta información. Si usted ha recibido esto por error, rogamos lo notifique inmediatamente al remitente y borre este correo electrónico de su bandeja de entrada."

            mensaje = mensaje.Replace("[FECHA_INI]", Datos("fecha_ini_nom"))
            mensaje = mensaje.Replace("[FECHA_FIN]", Datos("fecha_fin_nom"))
            mensaje = mensaje.Replace("[ANO]", Datos("ano"))
            mensaje = mensaje.Replace("[PERIODO]", Datos("periodo"))
            mensaje = mensaje.Replace("[RELOJ]", Datos("reloj"))
            mensaje = mensaje.Replace("[NOMBRES]", Datos("nombres"))

            Dim nombre_periodo As String = "", tp As String = ""
            If (chkTipoPerSem.Checked) Then
                nombre_periodo = "semana"
                tp = "S"
            End If

            If (chkTipoPerCat.Checked) Then
                nombre_periodo = "catorcena"
                tp = "C"
            End If
            If EnviarCorreoSMTP("Recibo de nómina empleado " & Datos("reloj") & "  de la " & nombre_periodo & " " & Datos("periodo") & " del año " & Datos("ano"), mensaje, Destino, PathRecibo, Pathxml) Then
                If (seleccionTab = "tabEmpleado") Then
                    MessageBox.Show("Envio de correcto exitoso: " + Destino, "Correo enviado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ' Enviados = Enviados + 1

                    'lstEnviados.Items.Add(Datos("reloj").ToString & "_" & Datos("periodo").ToString & "_" & Destino)
                    'sqlExecute("update nomina set impresa= '1' where periodo_act = '" & Datos("ano").ToString & Datos("periodo").ToString & "' and reloj = '" & Datos("reloj").ToString & "'")
                End If
                sqlExecute("insert into envio_recibos_det values ('" & Datos("ano") & "','" & Datos("periodo") & "','" & Datos("reloj") & "','" & tp & "','" & Usuario & "',getdate(),1)", "NOMINA") ' Si enviado
                EnviadoExitoso = True
            Else
                If (seleccionTab = "tabEmpleado") Then
                    MessageBox.Show("Ocurrio un error al enviar el correo: " + Destino, "Error en correo", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'NoEnviados = NoEnviados + 1

                    'lstNoEnviados.Items.Add(Datos("reloj").ToString & "_" & Datos("periodo").ToString & "_" & Destino)
                End If
                sqlExecute("insert into envio_recibos_det values ('" & Datos("ano") & "','" & Datos("periodo") & "','" & Datos("reloj") & "','" & tp & "','" & Usuario & "',getdate(),0)", "NOMINA") ' No enviado
                EnviadoExitoso = False
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "EnviarRecibo", Err.Number, ex.Message)
        End Try
    End Sub

    '/****: La sig función manda automaticamente desde el correo desde la pc que se ejecuta el programa , a diferencia de las otras que queda un correo fijo
    'Public Function EnviarCorreoSMTP(Asunto As String, Mensaje As String, Destino As String, Archivo As String, Optional Archivo2 As String = "") As Boolean
    '    Try
    '        Dim m_OutLook As Outlook.Application
    '        Dim mail As Outlook.MailItem
    '        m_OutLook = New Outlook.Application
    '        mail = CType(m_OutLook.CreateItem(Outlook.OlItemType.olMailItem), Outlook.MailItem)
    '        mail.To = "aosw82@gmail.com" 'Destino
    '        mail.Subject = Asunto

    '        Dim body As String = ""

    '        body = Mensaje
    '        mail.Body = body

    '        Dim currentUser As Outlook.AddressEntry
    '        currentUser = m_OutLook.Session.CurrentUser.AddressEntry

    '        Dim objNS As Outlook._NameSpace = m_OutLook.Session


    '        mail.Recipients.ResolveAll()
    '        mail.Attachments.Add(Archivo, Outlook.OlAttachmentType.olByValue)
    '        mail.Save()
    '        mail.Send()
    '    Catch ex As Exception
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
    '    End Try

    'End Function

    Public Function EnviarCorreoSMTP(Asunto As String, Mensaje As String, Destinatario As String, Archivo As String, Optional Archivo2 As String = "") As Boolean
        Try
            Dim r As New System.Web.Mail.MailMessage


            r.Body = Mensaje
            r.BodyEncoding = System.Text.Encoding.UTF8
            '  r.BodyFormat = Web.Mail.MailFormat.Html
            r.BodyFormat = Web.Mail.MailFormat.Text

            r.Subject = Asunto
            ' r.From = "enviorecibos@ctemex.mx" ' Cuenta del cliente 1
            r.From = "enviorecibos@ctemex.mx"
           
            If Archivo.Trim <> "" Then
                r.Attachments.Add(New System.Web.Mail.MailAttachment(Archivo))
            End If

            If Not Archivo2.Equals("") Then
                r.Attachments.Add(New System.Web.Mail.MailAttachment(Archivo2))
            End If

            If (txtCorreoPrueba.Text.Trim <> "") Then
                Destinatario = txtCorreoPrueba.Text.Trim  ' Para pruebas
            End If


            '*-------------Cuenta de PIDA que funciona

            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtsperver") = "smtp.pida.com.mx"
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = "25"
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusing") = 2
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = 1
            '' r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpusessl") = True '*NOTA:  Esta linea no colocarla ya que no aplica
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusername") = "soporte@pida.com.mx"
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/sendpassword") = "Resultados1"
            'r.To() = Destinatario


            '---- Cuenta del cliente 1
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtsperver") = "smtp.gmail.com"
            '' r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = 587 ' Es para TLS, el menos utilizado
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = 465 ' Es para SSL el mas utilizado y con el que se ha probado el envío
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusing") = 2
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = 1
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpusessl") = True
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusername") = "nomina.wollsdorf@gmail.com"
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/sendpassword") = "Wollsdorf.2019"

            '---- Cuenta del cliente 2
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtsperver") = "smtp.mandrillapp.com"
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = 587 ' Es para TSL el mas utilizado es el 25 y con el que se ha probado el envío
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusing") = 2 ' El original es 2; CdoSendUsingPort, valor 2 para enviar el mensaje utilizando la red. Ejemplo: 2
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = 1  ' El original es 0 :: 0= No autentifica; 1= utilizar autent, con user y pass; 2= El current process security context se utiliza para autenticación con el servicio.
            '' r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpusessl") = True ' El orginal está deshabilitado y es True
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusername") = "enviorecibos@ctemex.mx"
            'r.Fields("http://schemas.microsoft.com/cdo/configuration/sendpassword") = "xJCxZP-2hMAK16Deh-Kutw"

            '---- Cuenta del cliente 2
            r.Fields("http://schemas.microsoft.com/cdo/configuration/smtsperver") = "mail.smtp2go.com"
            r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpserverport") = 465 ' Es para SSL el mas utilizado es el 25 y con el que se ha probado el envío
            r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusing") = 2 ' El original es 2; CdoSendUsingPort, valor 2 para enviar el mensaje utilizando la red. Ejemplo: 2
            r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate") = 1  ' El original es 0 :: 0= No autentifica; 1= utilizar autent, con user y pass; 2= El current process security context se utiliza para autenticación con el servicio.
            r.Fields("http://schemas.microsoft.com/cdo/configuration/smtpusessl") = True
            r.Fields("http://schemas.microsoft.com/cdo/configuration/sendusername") = "enviorecibos@ctemex.mx"
            r.Fields("http://schemas.microsoft.com/cdo/configuration/sendpassword") = "hk5uwkkHmlrMO5NE"

            r.To() = Destinatario



            'If CC.Trim <> "" Then
            '    r.Cc = CC
            'End If
            '   System.Web.Mail.SmtpMail.SmtpServer = "smtp.pida.com.mx" ' SMTP Server de PIDA que funciona
            '  System.Web.Mail.SmtpMail.SmtpServer = "smtp.gmail.com" ' SMTP Server de Gmail y es la que usaba el cliente 1
            ' System.Web.Mail.SmtpMail.SmtpServer = "smtp.mandrillapp.com" ' SMTP Server de Gmail y es la que usaba el cliente 2
            System.Web.Mail.SmtpMail.SmtpServer = "mail.smtp2go.com" ' SMTP Server de Gmail y es la que usaba el cliente 2
            System.Web.Mail.SmtpMail.Send(r)
            Return True


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Envio Recib X Correo SMTP", Err.Number, ex.Message)
            '    MsjError = ex.Message
            ' ErrorLog("TareaReportes", System.Reflection.MethodBase.GetCurrentMethod.Name(), "Envio correo SMTP", Err.Number, ex.Message)
            Return False
        End Try

    End Function

    Private Function GenerateQRCode(URL As String, DarkColor As System.Drawing.Color, LightColor As System.Drawing.Color, escala As Integer) As Bitmap
        Dim Encoder As New Gma.QrCodeNet.Encoding.QrEncoder(Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.L)
        Dim Code As Gma.QrCodeNet.Encoding.QrCode = Encoder.Encode(URL)

        Dim contadorx As Integer = 1
        Dim contadory As Integer = 1

        Dim TempBMP As New Bitmap(Code.Matrix.Width * escala, Code.Matrix.Height * escala)
        For X As Integer = 0 To (Code.Matrix.Width) - 1
            For Y As Integer = 0 To (Code.Matrix.Height) - 1
                Try
                    If Code.Matrix.InternalArray(X, Y) Then
                        For i As Integer = 0 To escala Step 1
                            For j As Integer = 0 To escala - 1 Step 1
                                TempBMP.SetPixel((X * escala) + i, (Y * escala) + j, DarkColor)
                            Next
                        Next
                    Else
                        For i As Integer = 0 To escala Step 1
                            For j As Integer = 0 To escala - 1 Step 1
                                TempBMP.SetPixel((X * escala) + i, (Y * escala) + j, LightColor)
                            Next
                        Next
                    End If
                Catch ex As Exception

                End Try
            Next
        Next
        Return TempBMP
    End Function

    Private Sub chkMandarCorreos_CheckedChanged(sender As Object, e As EventArgs) Handles chkMandarCorreos.CheckedChanged

    End Sub

    Private Sub chkTipoPerSem_CheckedChanged(sender As Object, e As EventArgs) Handles chkTipoPerSem.CheckedChanged
        If (chkTipoPerSem.Checked) Then
            chkTipoPerCat.Checked = False
            cmbPeriodos.DataSource = sqlExecute("SELECT ano+periodo as 'seleccionado',periodo,ano,fini_nom as 'fecha_ini',ffin_nom as 'fecha_fin' FROM periodos where isnull(fini_nom,'')<>'' ORDER BY ano DESC,periodo ASC", "TA")

            'Dim dtPeriodo As DataTable
            'dtPeriodo = sqlExecute("SELECT MAX(ano+periodo) as 'seleccionado' FROM periodos WHERE activo = 1", "TA")
            'If dtPeriodo.Rows.Count > 0 Then
            '    cmbPeriodos.SelectedValue = dtPeriodo.Rows(0).Item("seleccionado")
            'Else
            '    cmbPeriodos.SelectedIndex = 0
            'End If
            'ActualizaInfo()

        End If
    End Sub

    Private Sub chkTipoPerCat_CheckedChanged(sender As Object, e As EventArgs) Handles chkTipoPerCat.CheckedChanged
        If (chkTipoPerCat.Checked) Then
            chkTipoPerSem.Checked = False
            cmbPeriodos.DataSource = sqlExecute("SELECT ano+periodo as 'seleccionado',periodo,ano,fini_nom as 'fecha_ini',ffin_nom as 'fecha_fin'  FROM periodos_catorcenal where isnull(fini_nom,'')<>'' ORDER BY ano DESC,periodo ASC", "TA")

            'Dim dtPeriodo As DataTable
            'dtPeriodo = sqlExecute("SELECT MAX(ano+periodo) as 'seleccionado' FROM periodos_catorcenal WHERE activo = 1", "TA")
            'If dtPeriodo.Rows.Count > 0 Then
            '    cmbPeriodos.SelectedValue = dtPeriodo.Rows(0).Item("seleccionado")
            'Else
            '    cmbPeriodos.SelectedIndex = 0
            'End If
            'ActualizaInfo()

        End If
    End Sub

    Private Sub txtCorreoPrueba_Leave(sender As Object, e As EventArgs) Handles txtCorreoPrueba.Leave
        '---Validar que el EMAIL del empleado esté en el formato correcto

        If Not IsValidEmail(txtCorreoPrueba.Text.Trim) Then ' Si no esta en el formato correcto:
            If MessageBox.Show("El correo electrónico tecleado no está en el formato correcto, desea así continuar?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                ' Si no desea continuar y capturarlo correctamente, entonces nos volvemos al control TEXT:
                txtCorreoPrueba.Focus()
            End If
        End If
    End Sub

    Private Function IsValidEmail(ByVal _email As String) As Boolean
        Return Regex.IsMatch(_email, "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
    End Function

    'BUSQUEDA DE EMPLEADOS      24/NOV/2020
    Private Sub btnBuscarEmp_Click(sender As Object, e As EventArgs) Handles btnBuscarEmp.Click     'correcto   25/nov/20
        Try
            frmBuscar.ShowDialog(Me)
            If varTodos = False Then
                ActualizaInfo(txtReloj.Text)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    'Private Sub cmbPeriodos_TextChanged_1(sender As Object, e As EventArgs) Handles cmbPeriodos.TextChanged        'comentado 24/nov/20

    'End Sub

    Private Sub cmbPeriodos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPeriodos.SelectedValueChanged     'añadido nov/20
        If varCmbPopOut Then
            If varTodos Then
                ActualizaInfo()
            Else
                ActualizaInfo(txtReloj.Text)
            End If
            varCmbPopOut = False
        End If
    End Sub
End Class
