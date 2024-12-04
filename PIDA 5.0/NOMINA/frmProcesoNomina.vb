Imports System.IO
Imports System.Text
Imports System.Reflection.MethodBase

Public Class frmProcesoNomina

    '-- No. reportes prenomina generados
    Dim noReportes As Integer = 1

    '-- Datatable para mostrar interfaz
    Dim dtInterfaces As New DataTable

    '-- Tipo dato variable proceso
    Dim tipoVar As String = ""

    '-- Recálculo rapido de un empleado
    Dim recalculo = False

    Dim cellX As Integer = 0
    Dim cellY As Integer = 0

    '-- Relojes para el cálculo individual
    Private nodosReloj As New List(Of String)
    '-- Bandera para indicar si las pantallas de info. estan en blanco
    Private interfaz_inicio = True
    '-- Validaciones para editar, agregar y borrar
    Dim dtCrudProceso As New DataTable
    '-- Nombres de campos de tablas para editar y agregar
    Dim dtInterfazCampos As New DataTable
    '-- Reloj seleccionado
    Dim strReloj = ""
    '-- Id registro
    Dim strId = ""
    '-- Nombres de tablas [datagridview:tablasql:nombreTab]
    Dim nombresTablas() As String = {"dgActiveEmploys:nominaPro", "dgMiscelaneosActual:ajustesPro", "dgHorasActual:horasPro", "dgFiniquitosNormales:finiquitosN", "dgMovimientos:movimientosPro"}
    '-- Ruta donde se guarda el reporte de cálculo ajuste al subsidio
    Dim strRutaAjusteSubsidio = ""
    Dim strRutaReportesPreNom = ""

    '-- Versión de reportes de prenómina
    Dim verRepPrenom = ""

    Private process As New ProcesoNomina
    Private dtStages As New DataTable
    Private dtHistory As New DataTable

    Private options As frmProcesoNominaInicializarOpciones
    Private options2 As frmProcesoNominaInicializarAgui '-- Ventana de inicialización para aguinaldo anual -- Ernesto -- 29 nov 2023

    '-- Diccionario para almacenar los cambios en las tab de los datagrids -- Ernesto
    Private dicTabs As New Dictionary(Of String, String) From {{"Empleados", "nominaPro"},
                                                               {"Horas", "horasPro"},
                                                               {"Miscelaneos", "ajustesPro"}}

    'Columnas a mostrar, key = nombre original, value = nuevo nombre -- Ernesto
    Private activeEmployColToSHow As New Dictionary(Of String, String) From {{"reloj", "Reloj"},
                                                                         {"procesar", "Procesar"},
                                                                         {"nombres", "Nombre"},
                                                                         {"cod_tipo", "Tipo empleado"},
                                                                         {"alta", "Alta"},
                                                                         {"baja", "Baja"},
                                                                         {"alta_antig", "Alta vacaciones"},
                                                                         {"infonavit_credito", "Credito infonavit"},
                                                                         {"tipo_credito", "Tipo credito infonavit"},
                                                                         {"cuota_credito", "Cuota credito infonavit"},
                                                                         {"cobro_segviv", "Seguro vivienda"},
                                                                         {"inicio_credito", "Inicio credito infonavit"},
                                                                         {"integrado", "Sueldo integrado"},
                                                                         {"sactual", "Sueldo"},
                                                                         {"privac_porc", "Porc. prima vacacional"},
                                                                         {"privac_dias", "Días prima vacacional"},
                                                                         {"incapacidad", "Incapacidad"},
                                                                         {"faltas", "Faltas"}}

    Private finiquitosActualColToSHow As New Dictionary(Of String, String) From {{"reloj", "Reloj"},
                                                                                 {"cod_comp", "Código de compañía"},
                                                                                 {"nombre", "Nombre"},
                                                                                 {"cod_tipo", "Tipo de empleado"},
                                                                                 {"baja", "Baja"},
                                                                                 {"alta", "Alta"},
                                                                                 {"sactual", "Salario"},
                                                                                 {"alta_vacacion", "Fecha de antiguedad"},
                                                                                 {"ano", "Año"},
                                                                                 {"fecha_ini", "Fecha de inicio periodo"},
                                                                                 {"fecha_fin", "Fecha de fin periodo"},
                                                                                 {"fecha_pago", "Fecha de pago"},
                                                                                 {"last_period", "Último periodo"},
                                                                                 {"DIASVA", "Días de vacaciones"}}

    '-- Se agrega saldo y origen
    Private ajustesProColToSHow As New Dictionary(Of String, String) From {{"reloj", "Reloj"},
                                                                           {"concepto", "Concepto"},
                                                                           {"descripcion", "Descripción"},
                                                                           {"origen", "Origen"},
                                                                           {"monto", "Monto"},
                                                                           {"fecha", "Fecha"},
                                                                           {"sueldo", "Sueldo"},
                                                                           {"saldo", "Saldo"}}

    '-- Se quito la fecha de captura
    Private hoursActualColToSHow As New Dictionary(Of String, String) From {{"reloj", "Reloj"},
                                                                            {"concepto", "Concepto"},
                                                                            {"descripcion", "Descripción"},
                                                                            {"monto", "Monto"},
                                                                            {"fecha", "Fecha"},
                                                                            {"cod_hora", "Código de horario"}}

    Private movimientosProToShow As New Dictionary(Of String, String) From {{"ano", "Reloj"},
                                                                        {"periodo", "Periodo"},
                                                                        {"tipo_nomina", "Tipo nomina"},
                                                                        {"reloj", "Reloj"},
                                                                        {"concepto", "Concepto"},
                                                                        {"monto", "Monto"}}

    Private data As New Dictionary(Of String, String) From {{"periodo", Nothing},
                                                            {"tipoPersonal", Nothing},
                                                            {"ano", Nothing},
                                                            {"tipoPeriodo", Nothing},
                                                            {"activeMethod", Nothing},
                                                            {"etapa", Nothing},
                                                            {"codComp", Nothing},
                                                            {"tabla", Nothing},
                                                            {"savePath", Nothing}}

    ''' <summary>
    ''' 'Función para bloquear los botones cuando el sistema está cargando datos
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub visualLocked(estatus As Boolean)
        gpDatosPeriodo.Enabled = Not estatus
        gpConsultaReg.Enabled = Not estatus
        tvStages.Enabled = Not estatus
        dgHistory.Enabled = Not estatus
        gpOpciones.Enabled = Not estatus
        If Not estatus Then : txtLoader.Text = "" : End If
    End Sub

    ''' <summary>
    ''' 'Función DoWork del BackgroundWorker1 para ejecutar la carga de archivos en un hilo diferente
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Select Case Me.data("activeMethod")
            Case stepsData.INICIALIZAR
                process.CargaPrevia(Me.data)
                process.Inicializar(Me.data)
            Case stepsData.PROCESAR
                process.Proceso(Me.data, nodosReloj, recalculo)
            Case stepsData.ASENTAR
                process.Asentar(Me.data, nodosReloj)
            Case 4
                '-- Es para cargar datos del historico -- Ernesto
                e.Result = process.restoreProcessStatus(Me.dtHistory.Rows(e.Argument)("id"), Me.data)
            Case 5
                '-- Ejecutar el cálculo de ajuste al subsidio -- Ernesto
                process.AjusteSubsidioMensual(strRutaAjusteSubsidio, Me.data, nodosReloj)
            Case 6
                '-- Reportes de prenomina -- Ernesto
                process.CondensadoReportesNominaBRPQro(cmbPeriodo.SelectedValue & cmbAno.SelectedValue("ano"), verRepPrenom, IIf(rbS.Checked, "S", "Q"), "", data, strRutaReportesPreNom)
            Case 7
                '-- Inicializa ajustes para aguinaldo anual -- 29 nov 2023 -- Ernesto
                process.IniciaAguinaldoAnual(Me.data)
        End Select
    End Sub

    ''' <summary>
    ''' 'Evento ProgressChanged del BackgroundWorker1 para actualizar estatus 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Try
            CircularProgress4.Value = e.ProgressPercentage
            If Not Me.data("etapa") = txtLoader.Text Then : txtLoader.Text = Me.data("etapa") : End If
            Me.updateLogs()
        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' 'Funcion para llenar todos los datagrids
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LlenaDatagrids(Optional agregarEditarHabilitado As Boolean = False,
                              Optional ByRef dataInfo As DevComponents.DotNetBar.Controls.DataGridViewX = Nothing,
                              Optional dtSQLite As DataTable = Nothing,
                              Optional strTabla As String = "")

        Try
            '-- Si los grid se cargan desde un proceso [ya sea input o cálculo] -- Ernesto
            If Not agregarEditarHabilitado Then
                dgActiveEmploys.DataSource = process.NominaPro
                MuestraColumnasDg(dgActiveEmploys, activeEmployColToSHow, "")

                'Llenando datos de FiniquitosN
                dgFiniquitosNormales.DataSource = process.FiniquitosN
                MuestraColumnasDg(dgFiniquitosNormales, finiquitosActualColToSHow, "nombre")

                'Llenando datos de HorasPro
                dgHorasActual.DataSource = process.HorasPro
                MuestraColumnasDg(dgHorasActual, hoursActualColToSHow, "Descripcion")

                'Llenando datos de AjustesPro
                dgMiscelaneosActual.DataSource = process.AjustesPro
                MuestraColumnasDg(dgMiscelaneosActual, ajustesProColToSHow, "Descripcion")

                'Llenando datos de movimientos pro
                dgMovimientos.DataSource = process.MovimientosPro
                MuestraColumnasDg(dgMovimientos, movimientosProToShow, "concepto")
            Else
                '-- Si se tiene que recargar un grid en específico por agregar, editar o borrar un registro para refrescar -- Ernesto
                dataInfo.DataSource = dtSQLite
                MuestraColumnasDg(dataInfo, IIf(strTabla = "nominaPro", activeEmployColToSHow,
                                      IIf(strTabla = "ajustesPro" Or strTabla = "ajustesLazy", ajustesProColToSHow,
                                          IIf(strTabla = "horasPro" Or strTabla = "horasLazy", hoursActualColToSHow,
                                              IIf(strTabla = "finiquitosN" Or strTabla = "finiquitosE", finiquitosActualColToSHow, movimientosProToShow)))),
                                  IIf(strTabla = "nominaPro", "",
                                      IIf(strTabla = "ajustesPro" Or strTabla = "ajustesLazy" Or strTabla = "horasPro" Or strTabla = "horasLazy", "Descripcion",
                                          IIf(strTabla = "finiquitosN" Or strTabla = "finiquitosE", "nombre", "concepto"))))
            End If

            OpcionesCRUD()

        Catch ex As Exception
            ProcesoNomina.log_proceso(GetCurrentMethod().Name, ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' 'Funcion RunWorkerCompleted del BackgroundWorker1 para cuando termina
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        CircularProgress4.Value = 0
        visualLocked(False)

        If process.canceled Then
            process.addLog("Proceso cancelado, verificar notificaciones.", logType.ERR)
            Exit Sub
        End If

        Dim dateNow = DateTime.Now()
        Dim position = stepsData.INICIALIZAR
        Select Case Me.data("activeMethod")
            Case stepsData.INICIALIZAR
                position = stepsData.INICIALIZAR - 1
                MessageBox.Show("Inicialización finalizada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Case stepsData.PROCESAR
                position = stepsData.PROCESAR - 1
                MessageBox.Show("Procesar finalizado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                '-- Solo disponibles después del cálculo -- Ernesto
                btnReportes.Enabled = True
                BotonAjusteSubsidio()

                '-- Se limpia el arreglo de relojes si fue recalculo
                If recalculo Then nodosReloj.Clear()

            Case stepsData.ASENTAR
                position = stepsData.ASENTAR - 1
                MessageBox.Show("Asentar finalizado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Case 4
                '-- Se habilita una vez que se cargo el historial -- Ernesto
                btnReportes.Enabled = True
                BotonAjusteSubsidio()

                changeStepStatus(stepsData.INICIALIZAR - 1, e.Result = stepsData.INICIALIZAR, False)
                changeStepStatus(stepsData.PROCESAR - 1, e.Result = stepsData.PROCESAR, False)
                changeStepStatus(stepsData.ASENTAR - 1, e.Result = stepsData.ASENTAR, False)
                Me.data("periodo") = cmbPeriodo.SelectedValue
                Me.data("tipoPersonal") = IIf(rbS.Checked, "O", "A")
                Me.data("tabla") = IIf(rbS.Checked, "periodos", "periodos_quincenal")
                Me.data("tipoPeriodo") = IIf(rbS.Checked, "S", "Q")
                Me.data("codComp") = "'CTE','CT2'"
                Me.data("ano") = cmbAno.SelectedValue("ano")

                tabHistoricalSteps.SelectedIndex = 0
            Case 5
                '-- Se habilita una vez que se cargo el historial -- Ernesto
                btnReportes.Enabled = True
                BotonAjusteSubsidio()
                updateLogs()
            Case 6
                updateLogs()
            Case 7 '-- Aguinaldo anual -- Ernesto -- 29 nov 2023
                updateLogs()
                MessageBox.Show("Inicialización de aguinaldo anual finalizada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Select

        If txtRelojBusq.Text.ToString.Trim <> "" Then
            RefrescarDatagrid()
        Else
            LlenaDatagrids()
        End If

        If Me.data("activeMethod") < 4 Then : changeStepStatus(position) : updateLogs() : End If
        BackgroundWorker1.CancelAsync()
        process.canceled = False
        interfaz_inicio = False
        recalculo = False
        MostrarVariables()

        '-- Abrir carpeta de reportes si ya se generaron
        If Me.data("activeMethod") = 6 And noReportes > 0 Then
            System.Diagnostics.Process.Start(strRutaReportesPreNom)
        End If
    End Sub

    ''' <summary>
    ''' Muestra solo las columnas deseadas de un datagrid con los nombres asignados
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MuestraColumnasDg(dg As DevComponents.DotNetBar.Controls.DataGridViewX, columns As Dictionary(Of String, String), Optional sizeColumn As String = Nothing)
        Try
            For Each item As DataGridViewColumn In dg.Columns
                If columns.Keys.Contains(item.Name) Then : dg.Columns(item.Name).HeaderCell.Value = columns(item.Name)
                Else : dg.Columns(item.Name).Visible = False : End If
            Next
            If Not sizeColumn Is Nothing Then : dg.Columns(sizeColumn).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : End If
        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Inicializa todos los par[ametros para un nuevo proceso
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Initilize()
        For Each node As TreeNode In tvStages.Nodes
            node.ImageIndex = 0
            node.SelectedImageIndex = 0
        Next
        process.clearLog()
        process.addLog(process.LogsMsg("RESTARTSTAGES"), logType.INFO)
    End Sub

    ''' <summary>
    ''' Se obtienen todos los controles de la forma y se valida se están disponible o no
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ObtenerControles()
        Try
            dtInterfaces = sqlExecute("select * from nomina.dbo.validaciones_procnomina where tipo='Interfaz' and valor in ('1','0')")
            If dtInterfaces.Rows.Count > 0 Then
                Dim val = Nothing
                For Each c In dtInterfaces.Rows
                    For Each control In Me.Controls
                        If TypeOf control Is Panel Then
                            If control.name = c("variable").ToString.Trim Then
                                Try : val = dtInterfaces.Select("variable='" & c("variable").ToString.Trim & "'").First.Item("valor")
                                    control.enabled = strBool.getValue(val)
                                    control.visible = strBool.getValue(val)
                                Catch ex As Exception : Continue For : End Try
                            End If
                        End If
                    Next
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Evento de carga del formulario -- Ernesto
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub frmProcesoNomina_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '-- Nodos de los relojes para el cálculo individual
        calculoRelojes.Nodes.Clear()
        calculoRelojes.ImageList = process.ImgList
        calculoRelojes.Nodes.Add(New TreeNode("Relojes [0]", 0, 0))

        '-- Registros que se pueden editar, agregar y borrar
        dtCrudProceso = sqlExecute("select * from nomina.dbo.validaciones_procnomina where variable in ('interfaz_agregar','interfaz_editar','interfaz_borrar') " &
                                   "and (valor is not null or rtrim(valor)<>'')")
        '-- Habilitar controles desde BD
        ObtenerControles()

        '-- Nodos etapas
        tvStages.Nodes.Clear()
        tvStages.ImageList = process.ImgList
        process.BgWorker = BackgroundWorker1
        For Each it In process.Steps : tvStages.Nodes.Add(New TreeNode(it.Value, 0, 0)) : Next
        cmbAno.DataSource = sqlExecute("SELECT * FROM (SELECT DISTINCT ano FROM periodos UNION SELECT DISTINCT ano FROM periodos_quincenal) AS T ORDER BY ano DESC;", "TA")
        LlenaDatagrids()

        '-- Menus para agregar, editar y borrar deshabilitados por default
        EditarToolStripMenuItem.Enabled = Not interfaz_inicio
        EliminarToolStripMenuItem.Enabled = Not interfaz_inicio
        AdicionarToolStripMenuItem1.Enabled = Not interfaz_inicio
    End Sub

    ''' <summary>
    ''' Evento doble click sobre cada paso, inicializa el paso -- Ernesto
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub tvStages_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvStages.NodeMouseDoubleClick
        If e.Node.SelectedImageIndex = 1 And e.Node.Text <> process.Steps(stepsData.PROCESAR) And e.Node.Text <> process.Steps(stepsData.ASENTAR) Then
            If e.Node.PrevNode Is Nothing Then
                If MessageBox.Show("¿Seguro desea reiniciar el proceso?", "Reiniciar proceso", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                    Initilize()
                    btnCargaPrevia.PerformClick()
                End If
            Else : MessageBox.Show("El paso ya fué aplicado previamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            Exit Sub
        End If

        If e.Node.PrevNode Is Nothing Then : btnCargaPrevia.PerformClick()
        Else
            If MessageBox.Show("¿Seguro desea ejecutar el paso: " & e.Node.Text & "?", "Ejecutar " & e.Node.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                Select Case e.Node.Index + 1
                    Case stepsData.PROCESAR
                        '-- Se cargan las opciones de cálculo
                        '-- Se agrega el mes anterior a las opciones de cálculo -- Ernesto -- 11 oct 2023
                        ProcesoCalculo(False)
                    Case stepsData.ASENTAR
                        If MessageBox.Show("Está a punto de asentar nómina, con esto, se eliminarán los registros existentes en nómina y movimientos, " &
                                          "reemplazándolos con los nuevos. ¿Desea continuar con 'asentar nómina'?",
                                          "Aviso", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = DialogResult.OK Then
                            process.clearLog()
                            process.addLog(String.Format(process.LogsMsg("NEXTSTAGE"), e.Node.Text), logType.INFO)
                            visualLocked(True)
                            Me.data("activeMethod") = stepsData.ASENTAR
                            BackgroundWorker1.RunWorkerAsync()
                            interfaz_inicio = False
                        Else
                            Exit Sub
                        End If
                        changeStepStatus(e.Node.Index)
                End Select
            End If
        End If
    End Sub

    ''' <summary>
    ''' Función para la acción del cálculo en interfaz
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ProcesoCalculo(recalculoRapido As Boolean)
        Try
            Dim mesAnterior = Nothing
            recalculo = recalculoRapido

            Try
                mesAnterior = sqlExecute("select month(fecha_fin) as mes from ta.dbo.periodos where ano+periodo='" & data("ano") & data("periodo") & "'").Rows(0)("mes")
                If mesAnterior - 1 = 0 Then
                    mesAnterior = "Diciembre"
                Else
                    mesAnterior = sqlExecute("select mes_min from personal.dbo.meses where num_mes='" & (mesAnterior - 1).ToString.PadLeft(2, "0") & "'").Rows(0)("mes_min")
                End If
            Catch ex As Exception : mesAnterior = "" : End Try

            If Not recalculoRapido Then
                Dim opt = New frmProcesoNominaCalcularOpciones(process.Options, mesAnterior)
                If opt.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    For Each key In opt.getAllOptions.Keys : process.Options(key) = opt.getAllOptions(key) : Next
                Else
                    Exit Sub
                End If
            Else
                btnLimpiaRelojes.PerformClick()
                Application.DoEvents()
                nodosReloj.Add(strReloj)
            End If

            process.clearLog()
            process.addLog(String.Format(process.LogsMsg("NEXTSTAGE"), "Procesar"), logType.INFO)
            visualLocked(True)
            Me.data("activeMethod") = stepsData.PROCESAR
            BackgroundWorker1.RunWorkerAsync()
            interfaz_inicio = False
            changeStepStatus(1)
        Catch ex As Exception : End Try
    End Sub

    Private Sub tvStages_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvStages.NodeMouseClick
        e.Node.SelectedImageIndex = e.Node.SelectedImageIndex
    End Sub

    ''' <summary>
    ''' Función para actualizar listbox de logs visuales
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub updateLogs()
        Try
            For Each i In process.Logs
                If Not ListBox2.Items.Contains(i.Value) Then : ListBox2.Items.Add(i.Value) : End If
            Next
        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Función para obtener los datos del periodo a partir de la fecha seleccionada
    ''' </summary>
    ''' <param name="searchDate">Fecha seleccionada</param>
    ''' <param name="table">Tabla donde debe seleccionar, se define mediante la selección de si es semanal o quincenal</param>
    ''' <returns>Diccionario con los datos ano, periodo, fecha_ini, echa_fin</returns>
    ''' <remarks></remarks>
    Public Function getPeriodo(searchDate As Date, table As String) As Dictionary(Of String, Object)
        Try
            Dim sql = "SELECT * FROM " & table & " WHERE '" & FechaSQL(searchDate) & "' between FECHA_INI and FECHA_FIN and ano = '" & searchDate.Year & "' and activo = '1'"
            Dim data = sqlExecute("SELECT * FROM " & table & " WHERE '" & FechaSQL(searchDate) & "' between FECHA_INI and FECHA_FIN and ano = '" & searchDate.Year & "' and activo = '1'", "TA")
            Dim result As IEnumerable(Of Dictionary(Of String, Object)) = From r In data.AsEnumerable()
                Select New Dictionary(Of String, Object)() From {
                    {"ano", r.Field(Of String)("ano")},
                    {"periodo", r.Field(Of String)("periodo")},
                    {"fecha_ini", r.Field(Of DateTime)("fecha_ini")},
                    {"fecha_fin", r.Field(Of DateTime)("fecha_fin")}}
            Return result.First()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub changeStepStatus(position As Integer, Optional active As Boolean = False, Optional setLog As Boolean = True)
        Dim Node = tvStages.Nodes.Item(position)
        tvStages.SelectedNode = Node

        Dim change = True
        If Not setLog Then : change = active
        ElseIf Not Node.PrevNode Is Nothing Then
            If Node.PrevNode.SelectedImageIndex <> 1 Then : change = False : End If
        End If

        tvStages.SelectedNode.ImageIndex = IIf(change, 1, 0)
        tvStages.SelectedNode.SelectedImageIndex = IIf(change, 1, 0)

        If setLog Then
            process.addLog(String.Format(process.LogsMsg("NEXTSTAGE"), Node.Text), logType.INFO)
            updateLogs()
        End If
    End Sub

    '-- Modificacion para periodos especiales -- Ernesto -- 29 nov 2023
    Private Sub cmbAno_SelectionChanged(sender As Object, e As DevComponents.AdvTree.AdvTreeNodeEventArgs) Handles cmbAno.SelectionChanged
        If rbS.Checked Or rbE.Checked Then
            loadPeriodo()
        End If
        If rbE.Checked Then
            loadPeriodoEsp()
        End If
    End Sub

    Private Sub loadPeriodo()
        Dim tabla = IIf(rbS.Checked, "periodos", "periodos_quincenal")
        Dim query = "SELECT distinct periodo, convert(varchar, fecha_ini, 103) as Inicio, convert(varchar, fecha_fin, 103) as Fin FROM " &
            tabla & " where ano = '" & cmbAno.SelectedValue("ano") & "'"
        cmbPeriodo.DataSource = sqlExecute(query, "TA")
    End Sub

    '-- Modificacion para periodos especiales -- Ernesto -- 29 nov 2023
    Private Sub rbS_CheckedChanged(sender As Object, e As EventArgs) Handles rbS.CheckedChanged
        If rbS.Checked Then
            If cmbAno.SelectedValue Is Nothing Then : Exit Sub : End If
            loadPeriodo()
            LimpiarNodosPanel()
        End If
    End Sub

    Private Sub btnCargaPrevia_Click(sender As Object, e As EventArgs) Handles btnCargaPrevia.Click
        Me.data("periodo") = cmbPeriodo.SelectedValue
        Me.data("tipoPersonal") = IIf(rbS.Checked, "O", "A")
        Me.data("tabla") = IIf(rbS.Checked, "periodos", "periodos_quincenal")
        Me.data("tipoPeriodo") = IIf(rbS.Checked, "S", "Q")
        Me.data("codComp") = "'CTE','CT2'"
        Me.data("ano") = cmbAno.SelectedValue("ano")
        Me.data("etapa") = "Carga previa"

        '-- Si es periodo especial -- 29 nov 2023 -- Ernesto
        If rbE.Checked Then
            Me.data("tipoPersonal") = "O"
            Me.data("tabla") = "periodos"
            Me.data("tipoPeriodo") = "S"
            Me.data("codComp") = "'CTE','CT2'"
            Me.data("ano") = cmbAno.SelectedValue("ano")
            Me.data("etapa") = "Carga previa especial"
        End If

        '-- Opciones de inicializar: Proceso normal -- 29 nov 2023 -- Ernesto
        If rbS.Checked Or rbQ.Checked Then

            '--- Preguntar al usuario si desea continuar
            If MessageBox.Show("¿Seguro desea ejecutar el paso: Input?", "Input", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                process.clearLog()
                process.clearData()
                process.addLog(String.Format(process.LogsMsg("NEXTSTAGE"), "Inicializar"), logType.INFO)
                visualLocked(True)
                Me.data("activeMethod") = stepsData.INICIALIZAR
                BackgroundWorker1.RunWorkerAsync()
                interfaz_inicio = False
                options = New frmProcesoNominaInicializarOpciones(process.Options)
                For Each key In options.getAllOptions.Keys : process.Options(key) = options.getAllOptions(key) : Next
                data("savePath") = ""
            Else
                Exit Sub
            End If

            'options = New frmProcesoNominaInicializarOpciones(process.Options)

            'If options.ShowDialog() = Windows.Forms.DialogResult.OK Then
            '    For Each key In options.getAllOptions.Keys : process.Options(key) = options.getAllOptions(key) : Next
            '    Dim fbd As New FolderBrowserDialog
            '    fbd.RootFolder = Environment.SpecialFolder.Desktop
            '    fbd.Description = "Seleccionar carpeta de archivos."
            '    If fbd.ShowDialog = Windows.Forms.DialogResult.OK Then : data("savePath") = fbd.SelectedPath : Else : Exit Sub : End If

            '    process.clearLog()
            '    process.clearData()
            '    process.addLog(String.Format(process.LogsMsg("NEXTSTAGE"), "Inicializar"), logType.INFO)

            '    visualLocked(True)
            '    Me.data("activeMethod") = stepsData.INICIALIZAR
            '    BackgroundWorker1.RunWorkerAsync()
            '    interfaz_inicio = False
            'Else
            '    Exit Sub
            'End If
        End If

        '-- Opciones de inicializar: Proceso especial [aguinaldo] -- 29 nov 2023 -- Ernesto
        If rbE.Checked Then
            options2 = New frmProcesoNominaInicializarAgui(process.Options)
            If options2.ShowDialog() = Windows.Forms.DialogResult.OK Then
                For Each key In options2.getAllOptions.Keys : process.Options(key) = options2.getAllOptions(key) : Next
                process.clearLog()
                process.clearData()

                visualLocked(True)
                Me.data("activeMethod") = 7
                BackgroundWorker1.RunWorkerAsync()
                interfaz_inicio = False
            Else
                Exit Sub
            End If
        End If
    End Sub

    ''' <summary>
    ''' Botón que genera los reportes de prenómina -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnReportes_Click(sender As Object, e As EventArgs) Handles btnReportes.Click
        Dim FD As New FolderBrowserDialog
        FD.Description = "Seleccione una ruta para guardar"
        FD.RootFolder = Environment.SpecialFolder.Desktop

        If FD.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim verRep = New frmCapturaVersionReportesPrenom
            verRep.ShowDialog()

            If CInt(verRep.DialogResult) > 0 Then
                strRutaReportesPreNom = FD.SelectedPath.ToString.Trim & "\"
                visualLocked(True)
                Me.data("activeMethod") = 6
                verRepPrenom = CInt(verRep.DialogResult)
                BackgroundWorker1.RunWorkerAsync()
            End If
        End If
    End Sub

    ''' <summary>
    ''' 'Funci[on que retorna cual DataGridViewX se encuentra seleccionado
    ''' </summary>
    ''' <returns>DataGridViewX seleccionado en el tab de la interfaz o Null en caso de que no exista un DataGridViewX en el tab seleccionado</returns>
    ''' <remarks></remarks>
    Private Function getSelectedDataGrid() As DevComponents.DotNetBar.Controls.DataGridViewX
        Dim mainTab As TabControl = TabControl1
        Dim tabControlers = (From i In TabControl1.SelectedTab.Controls Where i.GetType = GetType(TabControl)).ToList
        If tabControlers.Count > 0 Then : mainTab = CType(tabControlers.First(), TabControl) : End If
        Dim datagrid = (From i In mainTab.SelectedTab.Controls Where i.GetType = GetType(DevComponents.DotNetBar.Controls.DataGridViewX)).ToList
        If datagrid.Count > 0 Then : Return CType(datagrid.First(), DevComponents.DotNetBar.Controls.DataGridViewX) : End If
        Return Nothing
    End Function


    ''' <summary>
    ''' 'Evento DrawItem del ListBox2 para pintar los items
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ListBox2_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ListBox2.DrawItem
        'cambiar el DrawMode del listBox a OwnerDrawFixed
        Try
            e.DrawBackground()
            Dim g As Graphics = e.Graphics
            Dim brush As Brush = Brushes.White
            Dim str = ListBox2.Items(e.Index).ToString()

            If (ListBox2.Items(e.Index).ToString().EndsWith(":" & logType.WARN)) Then
                brush = Brushes.Yellow
                str = str.Substring(0, str.Length - 2)
            ElseIf (ListBox2.Items(e.Index).ToString().EndsWith(":" & logType.ERR)) Then
                brush = Brushes.Red
                str = str.Substring(0, str.Length - 2)
            ElseIf (ListBox2.Items(e.Index).ToString().EndsWith(":" & logType.INFO)) Then
                brush = Brushes.LightGreen
                str = str.Substring(0, str.Length - 2)
            End If

            e.DrawFocusRectangle()
            e.Graphics.DrawString(str, e.Font, brush, e.Bounds, StringFormat.GenericDefault)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Función que se encarga de guardar el estado actual del proceso a la tabla nomina.dbo.bitacora_proceso -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub GuardarEstadoDelProcesoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarEstadoDelProcesoToolStripMenuItem.Click
        If MessageBox.Show("¿Desea guardar el estado actual de nómina para la bitácora?", "Guardar versión", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Dim comentario As New frmComentarioVersionProceso
            If comentario.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                process.saveProcessStatus(data, comentario.strComentario)
                Me.Cursor = Cursors.Default
                MessageBox.Show("Se ha realizado el respaldo", "Respaldo bitacora", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub cmbPeriodo_SelectionChanged(sender As Object, e As DevComponents.AdvTree.AdvTreeNodeEventArgs) Handles cmbPeriodo.SelectionChanged
        Try
            '-- Bitacora del proceso [estados guardados] -- Ernesto
            Me.dtHistory = sqlExecute("SELECT version, usuario, datetime, id, etapa, comentario FROM NOMINA.dbo.bitacora_proceso WHERE ano = '" &
                                      cmbAno.SelectedValue("ano") & "' and periodo = '" & cmbPeriodo.SelectedValue & "' order by version ASC")
            dgHistory.DataSource = Me.dtHistory

            MuestraColumnasDg(dgHistory, New Dictionary(Of String, String) From {{"version", "Versión"},
                                                                           {"datetime", "Fecha"}}, "datetime")
            BotonAjusteSubsidio()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Deshabilitar el boton 'ajuste al subsidio' si no corresponde con el periodo -- Ernesto
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub BotonAjusteSubsidio()
        Try
            If rbS.Checked Then
                Dim dtInfoPer = sqlExecute("select (ano+periodo) as periodo,incluir_ajuste_subsidio from ta.dbo.periodos where ano+periodo='" &
                                           cmbAno.SelectedValue("ano") & cmbPeriodo.SelectedValue & "'")
                If dtInfoPer.Rows.Count > 0 Then
                    btnAjusteSubsidio.Enabled = Convert.ToBoolean(dtInfoPer.Rows(0)("incluir_ajuste_subsidio"))
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgHistory_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgHistory.CellDoubleClick
        If MessageBox.Show("¿Seguro desea cargar la versión seleccionada?", "Cargar histórico", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Me.data("activeMethod") = 4
            visualLocked(True)
            BackgroundWorker1.RunWorkerAsync(e.RowIndex)
        End If
    End Sub

    ''' <summary>
    ''' Habilita la opciones CRUD del menu con el click derecho
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OpcionesCRUD()
        Try
            Dim dataG = Me.getSelectedDataGrid()
            If Not dataG Is Nothing Then
                EditarToolStripMenuItem.Enabled = dataG.SelectedRows.Count > 0
                EliminarToolStripMenuItem.Enabled = dataG.SelectedRows.Count > 0
            End If
        Catch ex As Exception
            ProcesoNomina.log_proceso(GetCurrentMethod().Name, ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' Agregar elementos por interfaz. -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AdicionarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AdicionarToolStripMenuItem1.Click
        Try
            '-- Campos para la interfaz para agregar y editar
            Dim filtro = If(txtRelojBusq.Text.ToString.Trim = "", "", "where reloj like '%" & txtRelojBusq.Text.ToString.Trim & "%'")
            dtInterfazCampos = sqlExecute("select * from nomina.dbo.interfaz_procnomina ")
            CargaDataCrudProcess("Agregar", filtro)
        Catch ex As Exception
            ProcesoNomina.log_proceso(GetCurrentMethod().Name, ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' Eliminar elementos por interfaz -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EliminarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem.Click
        Try
            Dim dataG = Me.getSelectedDataGrid()
            dtInterfazCampos = sqlExecute("select * from nomina.dbo.interfaz_procnomina")
            Dim nombreTablaSQL = dtInterfazCampos.Select("nombre_control='" & dataG.Name & "' and tipo_modificacion='Eliminar'").First.Item("tabla")

            If MessageBox.Show("¿Desea eliminar el registro seleccionado? " & vbNewLine, "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

                '-- Si se elimina registro de nominaPro, se elimina de igual forma en finiquitosN y finiquitosE -- Ernesto -- 3 oct 2023
                If nombreTablaSQL = "nominaPro" Then
                    Dim strR = Sqlite.getInstance.sqliteExecute("SELECT reloj,finiquito,finiquito_esp from " & nombreTablaSQL & " WHERE id='" & strId & "'")

                    For Each f In {"finiquito", "finiquito_esp"}
                        If strR.Rows(0)(f) = "True" Then
                            Sqlite.getInstance.sqliteExecute("DELETE from " & If(f = "finiquito", "finiquitosN", "finiquitosE") & " WHERE reloj='" & strR.Rows(0)("reloj") & "'")
                        End If
                    Next
                End If

                '-- Eliminar registro
                Sqlite.getInstance.sqliteExecute("DELETE from " & nombreTablaSQL & " WHERE id='" & strId & "'")
                '-- Tabla sqlite
                Dim dtInfo = Sqlite.getInstance.sqliteExecute("SELECT * FROM " & nombreTablaSQL & If(txtRelojBusq.Text.ToString.Trim = "", "", " WHERE reloj like '%" & txtRelojBusq.Text & "%'"))
                '-- Refrescar grid
                LlenaDatagrids(True, IIf(nombreTablaSQL = "nominaPro", dgActiveEmploys, IIf(nombreTablaSQL = "ajustesPro", dgMiscelaneosActual, dgHorasActual)), dtInfo, nombreTablaSQL)
                '-- Confirmación de eliminación
                If dtInfo.Select("id=" & strId).Count > 0 Then
                    MessageBox.Show("Ha ocurrido un error en la eliminación", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If

        Catch ex As Exception
            ProcesoNomina.log_proceso(GetCurrentMethod().Name, ex.ToString)
        End Try
    End Sub

    ''' <summary>
    ''' Se carga la ventana para editar o agregar registros. -- Ernesto
    ''' </summary>
    ''' <param name="tipoModificacion"></param>
    ''' <param name="filtroReloj"></param>
    ''' <remarks></remarks>
    Private Sub CargaDataCrudProcess(tipoModificacion As String, Optional filtroReloj As String = "")
        Try
            Dim nombreTablaSQL = ""
            Dim tituloVentana = ""
            Dim dataG = Me.getSelectedDataGrid()
            Dim validaciones = NombresColumnasGrid(dataG.Name, tipoModificacion, nombreTablaSQL)
            Dim dtInfoCampos = dtInterfazCampos.Select("nombre_control='" & dataG.Name & "' and tipo_modificacion='" & tipoModificacion & "'").CopyToDataTable

            If Not dataG Is Nothing Then
                '-- Info adicional: sem o quincenal,periodo,anio
                Dim infoAdicional As New Dictionary(Of String, String)
                infoAdicional("tipoPer") = IIf(rbS.Checked, "sem", "qna")
                infoAdicional("periodo") = data("periodo")
                infoAdicional("ano") = data("ano")
                infoAdicional("tabla") = nombreTablaSQL
                infoAdicional("id") = strId
                infoAdicional("tipoPeriodo") = IIf(infoAdicional("tipoPer") = "sem", "S", "Q")

                '-- Titulo de ventana emergente
                tituloVentana = IIf(nombreTablaSQL = "nominaPro", "Empleados",
                                    IIf(nombreTablaSQL = "horasPro", "Horas",
                                            IIf(nombreTablaSQL = "ajustesPro", "Ajustes", "Finiquitos especiales")))

                Dim crud = New frmCrud(dtInfoCampos, tipoModificacion, tituloVentana.ToUpper, infoAdicional)

                If crud.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    '-- Tabla sqlite
                    Dim dtInfo As New DataTable
                    dtInfo = Sqlite.getInstance.sqliteExecute("SELECT * FROM " & nombreTablaSQL & " " & filtroReloj)

                    '-- Refrescar grid
                    LlenaDatagrids(True, IIf(nombreTablaSQL = "nominaPro", dgActiveEmploys, IIf(nombreTablaSQL = "ajustesPro", dgMiscelaneosActual, dgHorasActual)), dtInfo, nombreTablaSQL)
                End If
            End If
        Catch ex As Exception
            ProcesoNomina.log_proceso(GetCurrentMethod().Name, ex.ToString)

        End Try
    End Sub

    ''' <summary>
    ''' Función para validar los campos que se utilizará para agregar o editar registros en la interfaz. -- Ernesto
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function NombresColumnasGrid(nombreDg As String, opcion As String, ByRef nombreTabla As String) As Dictionary(Of String, String)
        Try
            Dim infoCols As New Dictionary(Of String, String)
            nombreTabla = dtInterfazCampos.Select("nombre_control ='" & nombreDg & "' and tipo_modificacion='" & opcion & "'").First().Item("tabla").ToString.Trim

            If dtInterfazCampos.Rows.Count > 0 Then
                For Each campos In dtInterfazCampos.Select("nombre_control ='" & nombreDg & "' and tipo_modificacion='" & opcion & "'")
                    infoCols.Add(campos("campo").ToString.Trim.ToUpper, "")
                Next
            End If

            Return infoCols
        Catch ex As Exception
            ProcesoNomina.log_proceso(GetCurrentMethod().Name, ex.ToString)
            Return Nothing
        End Try

    End Function

    ''' <summary>
    ''' 'Eventos para actualizar las opciones de editar y eliminar en caso de que no tengan registros -- Ernesto
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        OpcionesCRUD()
    End Sub

    ''' <summary>
    ''' 'Eventos para actualizar las opciones de editar y eliminar en caso de que no tengan registros -- Ernesto
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub TabControl2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl2.SelectedIndexChanged
        If TabControl2.SelectedIndex = 0 Then dicTabs("Empleados") = "nominaPro"
        If TabControl2.SelectedIndex = 1 Then dicTabs("Empleados") = "finiquitosN"
        If TabControl2.SelectedIndex = 2 Then dicTabs("Empleados") = "finiquitosE"
        OpcionesCRUD()
    End Sub

    ''' <summary>
    ''' 'Eventos para actualizar las opciones de editar y eliminar en caso de que no tengan registros -- Ernesto
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub TabControl3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl3.SelectedIndexChanged
        If TabControl3.SelectedIndex = 0 Then dicTabs("Horas") = "horasPro"
        OpcionesCRUD()
    End Sub

    ''' <summary>
    ''' 'Eventos para actualizar las opciones de editar y eliminar en caso de que no tengan registros -- Ernesto
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub TabControl4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl4.SelectedIndexChanged
        If TabControl3.SelectedIndex = 0 Then dicTabs("Miscelaneos") = "ajustesPro"
        OpcionesCRUD()
    End Sub

    ''' <summary>
    ''' Agrega un reloj al cálculo personalizado -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CálculoIndividualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CálculoIndividualToolStripMenuItem.Click
        Dim dataG = Me.getSelectedDataGrid()
        If Not dataG Is Nothing And dataG.Rows.Count > 0 Then
            If nodosReloj.Count = 0 OrElse Not nodosReloj.Contains(strReloj) Then
                calculoRelojes.Nodes(0).Nodes.Add(strReloj)
                nodosReloj.Add(strReloj)
                calculoRelojes.Nodes(0).Text = "Relojes [" & nodosReloj.Count & "]"
                TagNumRelojesCalculoIndividual()
                calculoRelojes.ExpandAll()
            End If
        End If
        strReloj = ""
    End Sub

    ''' <summary>
    ''' Eliminar reloj de nodos para cálculo individual. -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EliminarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EliminarToolStripMenuItem1.Click
        Try
            nodosReloj.Remove(calculoRelojes.SelectedNode.Text)
            calculoRelojes.Nodes(0).Nodes(calculoRelojes.SelectedNode.Index).Remove()
            calculoRelojes.Nodes(0).Text = "Relojes [" & nodosReloj.Count & "]"
            TagNumRelojesCalculoIndividual()
        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Menú para eliminar el nodo del cálculo individual. -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub calculoRelojes_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles calculoRelojes.NodeMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right And Not e.Node.ToString.Contains("Relojes") Then
            calculoRelojes.SelectedNode = e.Node
            e.Node.ContextMenuStrip = CMReloj
            e.Node.ContextMenuStrip.Show()
            EliminarToolStripMenuItem1.Enabled = Not (calculoRelojes.SelectedNode.Text = "Relojes [" & nodosReloj.Count & "]")
            EliminarToolStripMenuItem1.Visible = Not (calculoRelojes.SelectedNode.Text = "Relojes [" & nodosReloj.Count & "]")
        End If
    End Sub

    ''' <summary>
    ''' Se habilitan los botones de agregar, editar o borrar según sea válido. -- Ernesto
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub HabilitaMenuEdicion()
        Try
            Dim dataG = Me.getSelectedDataGrid()

            EditarToolStripMenuItem.Enabled = IIf(dtCrudProceso.Rows.Count > 0 And Not interfaz_inicio And dataG.RowCount > 0,
                                                 dtCrudProceso.Select("variable='interfaz_editar' and valor like '%" & dataG.Name & "%'").Count > 0,
                                                 False)

            EliminarToolStripMenuItem.Enabled = IIf(dtCrudProceso.Rows.Count > 0 And Not interfaz_inicio And dataG.RowCount > 0,
                                                 dtCrudProceso.Select("variable='interfaz_borrar' and valor like '%" & dataG.Name & "%'").Count > 0,
                                                 False)

            AdicionarToolStripMenuItem1.Enabled = IIf(dtCrudProceso.Rows.Count > 0 And Not interfaz_inicio And dataG.RowCount >= 0,
                                                 dtCrudProceso.Select("variable='interfaz_agregar' and valor like '%" & dataG.Name & "%'").Count > 0,
                                                 False)

        Catch ex As Exception
            EditarToolStripMenuItem.Enabled = False
            EliminarToolStripMenuItem.Enabled = False
            AdicionarToolStripMenuItem1.Enabled = False
        End Try
    End Sub

    ''' <summary>
    ''' Obtener el reloj del registro -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RelojDataGridSeleccionado(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgActiveEmploys.CellMouseDown, dgFiniquitosNormales.CellMouseDown, dgHorasActual.CellMouseDown,
                                                                                                          dgMiscelaneosActual.CellMouseDown,
                                                                                                         dgMovimientos.CellMouseDown
        Try
            sender.rows(e.RowIndex).selected = True
            strReloj = sender.Item("reloj", e.RowIndex).Value.ToString.Trim
            strId = sender.Item("id", e.RowIndex).Value.ToString.Trim
        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Se obtiene el id y reloj del registro seleccionado de algunos datagrids -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub HabilitarMenuRegistros(sender As Object, e As MouseEventArgs) Handles dgActiveEmploys.MouseDown, dgFiniquitosNormales.MouseDown, dgHorasActual.MouseDown,
                                                                                       dgMiscelaneosActual.MouseDown,
                                                                                      tabHistoricalSteps.MouseDown, MyBase.MouseDown, tvStages.MouseDown, dgHistory.MouseDown,
                                                                                      dgMovimientos.MouseDown, tabRelojes.MouseDown, calculoRelojes.MouseDown,
                                                                                      pnlTituloVentana.MouseDown, pnlIzquierdo.MouseDown, pnlInferior.MouseDown, ListBox2.MouseDown, tvVariables.MouseDown,
                                                                                      pnlEstatus.MouseDown, gpConsultaReg.MouseDown, gpDatosPeriodo.MouseDown, gpOpciones.MouseDown
        Try
            Dim strRestriccion = {"tabHistoricalSteps", "frmProcesoNomina", "tvStages", "dgHistory", "calculoRelojes",
                                  "pnlTituloVentana", "pnlIzquierdo", "pnlInferior", "ListBox2", "tvVariables", "pnlEstatus", "gpConsultaReg", "gpDatosPeriodo", "gpOpciones"}

            '-- Deshabilita crud de opciones -- Ernesto -- 27 oct 2023
            EliminarToolStripMenuItem.Enabled = False
            AdicionarToolStripMenuItem1.Enabled = False
            EditarToolStripMenuItem.Enabled = False

            If strRestriccion.Contains(sender.name) Then
                CálculoIndividualToolStripMenuItem.Enabled = False
                RecalcularToolStripMenuItem.Enabled = False
            Else
                Dim dataG = Me.getSelectedDataGrid()
                HabilitaMenuEdicion()                    '-- Habilita las opciones crud -- Ernesto -- 27 oct 2023

                If Not dataG Is Nothing And dataG.Rows.Count > 0 Then
                    CálculoIndividualToolStripMenuItem.Enabled = True
                    RecalcularToolStripMenuItem.Enabled = True
                Else
                    CálculoIndividualToolStripMenuItem.Enabled = False
                    RecalcularToolStripMenuItem.Enabled = False
                End If

                '-- Obtener reloj e id que está seleccionado por default en la tabla, si no se seleccionó directamente
                strReloj = dataG.Item("reloj", 0).Value.ToString.Trim
                strId = sender.Item("id", 0).Value.ToString.Trim
            End If


        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Solo se permiten números -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtRelojBusq_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRelojBusq.KeyPress
        '-- Sólo números
        If Not Char.IsNumber(e.KeyChar) And Not (e.KeyChar = Convert.ToChar(Keys.Back)) Then e.KeyChar = Nothing
    End Sub

    ''' <summary>
    ''' Se filtran los registros en base al reloj -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtRelojBusq_KeyUp(sender As Object, e As KeyEventArgs) Handles txtRelojBusq.KeyUp
        Try : RefrescarDatagrid() : Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Actualiza el datagrid de acuerdo a txtbox de búsqueda -- Ernesto
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefrescarDatagrid()
        Try
            '-- Controles de interfaz
            Dim dataG = {dgActiveEmploys, dgMiscelaneosActual, dgHorasActual, dgFiniquitosNormales, dgMovimientos}

            '-- Refrescar grid
            For Each ctrl In dataG
                Dim strNomTabla = (From i In nombresTablas Where i.ToString.Contains(ctrl.Name) Select i).ToList.First.ToString.Split(":")(1)
                Dim dtInfo = Sqlite.getInstance.sqliteExecute("SELECT * FROM " & strNomTabla & " WHERE reloj like '%" & txtRelojBusq.Text & "%'")
                LlenaDatagrids(True, ctrl, dtInfo, strNomTabla)
            Next
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Botón para realizar el cálculo de ajuste al subsidio -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAjusteSubsidio_Click(sender As Object, e As EventArgs) Handles btnAjusteSubsidio.Click

        '--- Si se selecciona ajuste de subsidio, marcar ruta de guardado para reporte
        Dim mesAnio = ""
        Try : mesAnio = sqlExecute("select (lower(rtrim(mes)) + ' ' + ANO) as mes from ta.dbo.periodos where ano+periodo='" & data("ano") & data("periodo") & "'").Rows(0)("mes")
        Catch ex As Exception : mesAnio = "" : End Try

        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.FileName = "BRP QRO ajuste subsidio mensual " & mesAnio & ".xlsx"
        saveFileDialog1.Filter = "Excel File|*.xlsx"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            strRutaAjusteSubsidio = saveFileDialog1.FileName.ToString()
            visualLocked(True)
            Me.data("activeMethod") = 5
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    ''' <summary>
    ''' Función para agregar un conjunto de relojes ingresados desde un textbox para el cálculo individual -- Ernesto
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddRljsCalcIndv()
        Try
            '-- Se obtienen todos los relojes que se pueden procesar de nominaPro
            Dim dtNom = Sqlite.getInstance.sqliteExecute("select reloj from nominaPro where procesar='True'")

            '-- Se valida la cadena de texto, y se ingresan los relojes a la pestaña de cálculo individual
            If dtNom.Rows.Count > 0 Then
                If txtCalcIndv.Text.ToString.Trim <> "" Then
                    Dim cadena = txtCalcIndv.Text.ToString.Trim.Split(",")
                    For Each strVal In cadena
                        If dtNom.Select("reloj='" & strVal & "'").Count > 0 Then
                            If nodosReloj.Count = 0 OrElse Not nodosReloj.Contains(strVal) Then
                                calculoRelojes.Nodes(0).Nodes.Add(strVal)
                                nodosReloj.Add(strVal)
                                calculoRelojes.Nodes(0).Text = "Relojes [" & nodosReloj.Count & "]"
                                TagNumRelojesCalculoIndividual()
                            End If
                        End If
                    Next
                    calculoRelojes.ExpandAll()
                End If
            End If

        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Conjuntos de relojes para cálculo individual -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAgregaRelojes_Click(sender As Object, e As EventArgs) Handles btnAgregaRelojes.Click
        AddRljsCalcIndv()
    End Sub

    Private Sub txtCalcIndv_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCalcIndv.KeyPress
        '-- Sólo números y comas
        If Not Char.IsNumber(e.KeyChar) And Not (e.KeyChar = Convert.ToChar(Keys.Back)) And Not e.KeyChar = "," Then e.KeyChar = Nothing
    End Sub

    ''' <summary>
    ''' Botón para exportar la información existente en el listbox de avisos a un txt -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnLogAvisos_Click(sender As Object, e As EventArgs)
        Try
            If ListBox2.Items.Count > 0 Then
                Dim dlgGuardar As New SaveFileDialog()
                dlgGuardar.FileName = "LogAvisos_" & data("ano") & data("periodo") & " " & Date.Now.ToString("yyyy-MM-dd HH:mm:ss tt").Replace(":", " ") & "txt"
                dlgGuardar.Filter = "Text file|*.txt"
                dlgGuardar.FilterIndex = 2
                dlgGuardar.RestoreDirectory = True

                If dlgGuardar.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim objWriter As New System.IO.StreamWriter(dlgGuardar.FileName.ToString)

                    For Each strVal In ListBox2.Items
                        objWriter.WriteLine(strVal)
                    Next

                    objWriter.Close()

                    If File.Exists(dlgGuardar.FileName.ToString) Then
                        MessageBox.Show("Archivo de texto de log de avisos creado con éxito.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("No se pudo exportar el log de avisos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End If
            Else
                MessageBox.Show("Sin elementos del log para exportar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Error al intentar exportar el log de avisos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Botón para generar los registros de movimientosPro y movimientos compensacion en un excel -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Try
            Dim MovimientosPro = process.tableToExcelPackage(process.MovimientosPro, "Movimientos")
            process.saveExcelFile("MovimientosPro", MovimientosPro)

            Dim movimientosComp = process.tableToExcelPackage(process.MovimientosCompensacion, "MovimientosComp")
            process.saveExcelFile("MovimientosComp", movimientosComp)

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Aparece tooltip con información de las versiones de la bitacora del proceso -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgHistory_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgHistory.CellMouseEnter
        Try

            If (e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0) And ((cellX & "," & cellY) <> (e.ColumnIndex & "," & e.RowIndex)) Then
                cellX = e.ColumnIndex
                cellY = e.RowIndex
                Dim superTooltip As New DevComponents.DotNetBar.SuperTooltipInfo

                superTooltip.HeaderText = "Versión: " & Me.dtHistory.Rows(cellY).Item("version")
                superTooltip.BodyText = If(IsDBNull(Me.dtHistory.Rows(cellY).Item("comentario")), "-Sin comentario-", Me.dtHistory.Rows(cellY).Item("comentario"))
                superTooltip.FooterText = "Fecha y hora: " & Me.dtHistory.Rows(cellY).Item("datetime")
                tooltipBitacora.SetSuperTooltip(dgHistory, superTooltip)
                tooltipBitacora.ShowTooltip(dgHistory)
            End If

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Ventana para realizar modificaciones manuales a la base de datos sqlite -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnEditcionManual_Click(sender As Object, e As EventArgs)
        'frmEdicionSQLite.ShowDialog()
        'frmEdicionSQLite.Focus()
    End Sub

    ''' <summary>
    ''' Doble click en el registro para editar -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EditarDobleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgActiveEmploys.CellMouseDoubleClick, dgFiniquitosNormales.CellMouseDoubleClick,
                                                                                                 dgHorasActual.CellMouseDoubleClick,
                                                                                                 dgMiscelaneosActual.CellMouseDoubleClick
        Try
            Dim filtro = If(txtRelojBusq.Text.ToString.Trim = "", "", "where reloj like '%" & txtRelojBusq.Text.ToString.Trim & "%'")
            dtInterfazCampos = sqlExecute("select * from nomina.dbo.interfaz_procnomina ")
            CargaDataCrudProcess("Editar", filtro)
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Edicion de registro -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub EditarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditarToolStripMenuItem.Click
        Dim filtro = If(txtRelojBusq.Text.ToString.Trim = "", "", "where reloj like '%" & txtRelojBusq.Text.ToString.Trim & "%'")
        dtInterfazCampos = sqlExecute("select * from nomina.dbo.interfaz_procnomina ")
        CargaDataCrudProcess("Editar", filtro)
    End Sub

    ''' <summary>
    ''' Control para habilitar un periodo especial -- Ernesto -- 18 oct 2023
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub rbE_CheckedChanged(sender As Object, e As EventArgs) Handles rbE.CheckedChanged
        Try
            If rbE.Checked Then
                loadPeriodoEsp()
                LimpiarNodosPanel()
            End If
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Carga periodo especial  -- Ernesto -- 18 oct 2023
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub loadPeriodoEsp()
        Dim query = "SELECT distinct periodo, convert(varchar, fecha_ini, 103) as Inicio, convert(varchar, fecha_fin, 103) as Fin FROM periodos where ano = '" & cmbAno.SelectedValue("ano") &
                    "' and isnull(periodo_especial,0)=1"
        cmbPeriodo.DataSource = sqlExecute(query, "TA")
    End Sub

    ''' <summary>
    ''' Se limpian los nodos del panel de selección dependiendo si trata de un periodo normal o especial [aguinaldo] -- Ernesto -- 19 oct 2023
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LimpiarNodosPanel()
        Try
            Dim dicInfo As New Dictionary(Of Integer, String)
            tvStages.Nodes.Clear()
            tvStages.ImageList = process.ImgList
            If rbS.Checked Or rbQ.Checked Then dicInfo = process.Steps
            If rbE.Checked Then dicInfo = process.Steps2
            For Each it In dicInfo : tvStages.Nodes.Add(New TreeNode(it.Value, 0, 0)) : Next
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Leyenda de número de relojes que se encuentran en el cálculo individual -- Ernesto -- 29 nov 2023
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub TagNumRelojesCalculoIndividual()
        Try
            If nodosReloj.Count > 0 Then
                tabRelojes.TabPages("Individual").Text = "Cálculo individual [" & nodosReloj.Count & "]"
            Else
                tabRelojes.TabPages("Individual").Text = "Cálculo individual"
            End If
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Mostrar las variables del proceso en la interfaz
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MostrarVariables()
        Try
            If process.Options.Count > 0 Then
                Dim cont = 0, cont2 = 0
                Dim varCalculo = {"periodo_aguinaldo", "sua_pagado_mes_anterior", "incluir_ajuste_subsidio"}
                tvVariables.Nodes.Clear()
                tvVariables.Nodes.Add("INPUT")
                tvVariables.Nodes.Add("CALCULO")
                tvVariables.Nodes.Add("DATOS PERIODO")

                For Each x As KeyValuePair(Of String, Object) In process.Options
                    If varCalculo.Contains(x.Key) Then
                        tvVariables.Nodes(1).Nodes.Add(New TreeNode(x.Key))
                        tvVariables.Nodes(1).Nodes(cont2).Nodes.Add(New TreeNode(x.Value))
                        cont2 += 1
                    Else
                        tvVariables.Nodes(0).Nodes.Add(New TreeNode(x.Key))
                        tvVariables.Nodes(0).Nodes(cont).Nodes.Add(New TreeNode(x.Value))
                        cont += 1
                    End If
                Next

                cont = 0
                For Each y As KeyValuePair(Of String, String) In process.PeriodoInfo
                    tvVariables.Nodes(2).Nodes.Add(New TreeNode(y.Key))
                    tvVariables.Nodes(2).Nodes(cont).Nodes.Add(New TreeNode(y.Value))
                    cont += 1
                Next

                tvVariables.Nodes(0).Expand()
                tvVariables.Nodes(1).Expand()
                tvVariables.Nodes(2).Expand()
            End If
        Catch ex As Exception

        End Try
    End Sub


    ''' <summary>
    ''' Recálculo rapido de empleado -- Ernesto - 14 marzo 2024
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub RecalcularToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecalcularToolStripMenuItem.Click
        Try : ProcesoCalculo(True) : Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Limpiar todos los relojes seleccionados -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnLimpiaRelojes_Click(sender As Object, e As EventArgs) Handles btnLimpiaRelojes.Click
        Try
            calculoRelojes.Nodes(0).Nodes.Clear()
            nodosReloj.Clear()
            calculoRelojes.Nodes(0).Text = "Relojes [" & nodosReloj.Count & "]"
            TagNumRelojesCalculoIndividual()
        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Limpiar lista de relojes para calculo del textbox -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnLimpiaLista_Click(sender As Object, e As EventArgs) Handles btnLimpiaLista.Click
        Try : txtCalcIndv.Text = "" : Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Borra cuadro de búsqueda -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try : txtRelojBusq.Text = "" : RefrescarDatagrid() : Catch ex As Exception : End Try
    End Sub


#Region "Variables de proceso"
    ''' <summary>
    ''' Treeview de variables del proceso -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub tvVariables_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvVariables.NodeMouseDoubleClick
        Try
            Dim arrDic = {process.Options, process.PeriodoInfo}

            For Each arr In arrDic
                For Each x In arr
                    Try
                        If (e.Node.Text = x.Value.ToString) And (x.Key = e.Node.Parent.Text) Then
                            txtVariable.Text = x.Key
                            VariablesProceso(x.Key, x.Value)
                            btnAceptaVar.Enabled = If(tipoVar = "", False, True)
                            btnCancelaVar.Enabled = True
                        End If
                    Catch ex As Exception : End Try
                Next
            Next

        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Edicion de variable proceso -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAceptaVar_Click(sender As Object, e As EventArgs) Handles btnAceptaVar.Click
        Try
            Dim arrDic = {process.Options, process.PeriodoInfo}
            Dim cont = 0

            For Each arr In arrDic
                For Each x In arr
                    Try
                        If x.Key = txtVariable.Text Then
                            Dim val = Nothing
                            Select Case tipoVar
                                Case "DATE"
                                    val = If(IsNothing(dtiVar.ValueObject), "", FechaSQL(dtiVar.Value))
                                Case "BOOLEAN"
                                    val = swbVar.Value.ToString
                                Case "TEXT"
                                    val = txtVar.Text.Trim
                            End Select
                            If cont = 0 Then process.Options(x.key) = val Else process.PeriodoInfo(x.key) = val
                            tipoVar = ""
                            GoTo continua
                        End If
                    Catch ex As Exception : End Try
                Next
                cont += 1
            Next

continua:
            MostrarVariables()
            ReestableceCtrlsVariables()
            txtVariable.Text = Nothing
            txtVar.Visible = True
            btnAceptaVar.Enabled = False
            btnCancelaVar.Enabled = False
        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Valida las variables del proceso para el treeview -- Ernesto
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub VariablesProceso(variable As String, valor As String)
        Try
            Dim dtVar = sqlExecute("select * from nomina.dbo.validaciones_procnomina where tipo='Variable_proceso'")
            Dim val As Object = If(IsNothing(valor) OrElse valor.ToString.Trim = "", Nothing, valor)
            ReestableceCtrlsVariables()

            '-- Info para tipo periodo y año
            Dim dtTipoPer = sqlExecute("select tipo_periodo from personal.dbo.tipo_periodo")
            Dim dtAnio = sqlExecute("select distinct ano from ta.dbo." & data("tabla") & " order by ano desc")

            If dtVar.Rows.Count > 0 Then
                Dim arrDic = {process.Options, process.PeriodoInfo}

                For Each arr In arrDic
                    For Each d In arr
                        If d.key = variable Then
                            For Each var In dtVar.Select("variable='" & d.key & "'")
                                Select Case var.Item("valor")
                                    Case "DATE"
                                        dtiVar.Value = val
                                        dtiVar.Enabled = True
                                        dtiVar.Visible = True
                                        dtiVar.Dock = DockStyle.Left
                                        dtiVar.Size = New Size(110, 20)
                                        dtiVar.Focus()
                                    Case "BOOLEAN"
                                        swbVar.Value = If(IsNothing(val), False, strBool.getValue(val))
                                        swbVar.Enabled = True
                                        swbVar.Visible = True
                                        swbVar.Dock = DockStyle.Left
                                        swbVar.Size = New Size(110, 20)
                                        swbVar.Focus()
                                    Case "TEXT"
                                        txtVar.Text = val
                                        txtVar.Enabled = True
                                        txtVar.Visible = True
                                        txtVar.Dock = DockStyle.Fill
                                        txtVar.Focus()
                                End Select
                                tipoVar = var.Item("valor")
                                Exit Sub
                            Next
                        End If
                    Next
                Next
            End If

            txtVar.Text = valor.ToString
            txtVar.Enabled = False
            txtVar.Visible = True
            txtVar.Dock = DockStyle.Fill
            txtVar.Focus()

        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Reestablecer controles de variables a su estado original -- Ernesto
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReestableceCtrlsVariables()
        Try
            tipoVar = ""
            dtiVar.Enabled = False : dtiVar.Visible = False : dtiVar.Value = Nothing
            swbVar.Enabled = False : swbVar.Visible = False : swbVar.Value = False
            txtVar.Enabled = False : txtVar.Visible = False : txtVar.Text = Nothing
        Catch ex As Exception : End Try
    End Sub

    ''' <summary>
    ''' Cancela edicion de variable de proceso -- Ernesto
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCancelaVar_Click(sender As Object, e As EventArgs) Handles btnCancelaVar.Click
        ReestableceCtrlsVariables()
        txtVariable.Text = Nothing
        txtVar.Text = Nothing
        txtVar.Enabled = False
        txtVar.Visible = True
        btnAceptaVar.Enabled = False
        btnCancelaVar.Enabled = False
    End Sub
#End Region

    Private Sub btnAjustesSistema_Click(sender As Object, e As EventArgs) Handles btnAjustesSistema.Click
        Dim dialogo = New frmAjustesProcesoNom(cmbAno.SelectedValue("ano"),
                                             cmbPeriodo.SelectedValue.ToString.Substring(0, 2),
                                             IIf(rbS.Checked, "S", "Q"))
        dialogo.ShowDialog()
        dialogo.Focus()
    End Sub


End Class