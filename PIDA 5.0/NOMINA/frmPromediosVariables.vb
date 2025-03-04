Imports Microsoft.VisualBasic
Imports OfficeOpenXml
Imports Newtonsoft.Json

Public Class frmPromediosVariables
    Dim FechaProyeccion As String = ""
    Dim FechaProyeccionINI As String = ""
    Dim dtPersonal As New DataTable
    Dim dtHistory As New DataTable
    Dim cellX As Integer = 0
    Dim cellY As Integer = 0

    Private Sub frmPromediosVariables_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicializateComponents()
    End Sub


#Region "Funciones para edicion de los datos"

#Region "Mostrar Historial, Guardar Proceso y Cargar Proceso"
    Private Sub dgHistorial_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgHistorial.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            If MessageBox.Show("¿Seguro desea cargar la versión seleccionada?", "Cargar histórico", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
                Dim selectedRow As DataGridViewRow = dgHistorial.Rows(e.RowIndex)
                Dim idBitacora As String = selectedRow.Cells("id").Value.ToString()
                Dim registro = sqlExecute("select * from bitacora_promedios where id = " & idBitacora & "", "Nomina")
                If Not IsDBNull(registro) Then
                    Dim dataTable As DataTable = JsonConvert.DeserializeObject(Of DataTable)(registro.Rows(0)("json_datosPromedios"))
                    Dim dataTablePeriodos As DataTable = JsonConvert.DeserializeObject(Of DataTable)(registro.Rows(0)("json_periodos"))
                    Dim dataTablePeriodosQuincenales As DataTable = JsonConvert.DeserializeObject(Of DataTable)(registro.Rows(0)("json_periodosQuincenal"))
                    dtPersonal = New DataTable
                    dtPersonal = dataTable.Copy()
                    ActualizarResultados(dtPersonal)
                    dgSemanasIncluidas.DataSource = dataTablePeriodos
                    dgQuincenasIncluidas.DataSource = dataTablePeriodosQuincenales
                End If
            End If
        End If
    End Sub

    Private Sub bimestres_SelectionChanged(sender As Object, e As DevComponents.AdvTree.AdvTreeNodeEventArgs) Handles cmbBimestre.SelectionChanged, cmbAnos.SelectionChanged
        Try
            dtHistory = sqlExecute("SELECT versiones, usuario, datetime, id, comentario FROM NOMINA.dbo.bitacora_promedios WHERE ano = '" & cmbAnos.SelectedValue.ToString & "' and bimestre = '" & cmbBimestre.SelectedValue.ToString & "' order by versiones ASC")
            dgHistorial.DataSource = dtHistory
            showDatagrid(dgHistorial, New Dictionary(Of String, String) From {{"versiones", "Versión"},
                                                                           {"datetime", "Fecha"}}, "datetime")

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

    Private Sub GuardarProceso(comentVersion As String)
        Dim dtPeriodos = dgSemanasIncluidas.DataSource
        Dim dtPeriodosQuincenas = dgQuincenasIncluidas.DataSource
        Dim selectedYear As String = cmbAnos.SelectedValue.ToString.Trim
        Dim selectedBimestre As String = cmbBimestre.SelectedValue.ToString.Trim

        Dim query = "INSERT INTO NOMINA.dbo.bitacora_promedios (ano, bimestre, versiones, usuario, json_periodos, json_periodosQuincenal, json_datosPromedios, " &
               "json_data, comentario) " &
               "values ('" & selectedYear & "', " &
               "'" & selectedBimestre & "', " &
               "(SELECT COALESCE(max(versiones),0)+1 AS versiones FROM NOMINA.dbo.bitacora_promedios where ano = '" & selectedYear & "' and bimestre = '" & selectedBimestre & "'), " &
               "'" & Usuario & "', " &
               "'" & JsonConvert.SerializeObject(dtPeriodos) & "', " &
               "'" & JsonConvert.SerializeObject(dtPeriodosQuincenas) & "', " &
               "'" & JsonConvert.SerializeObject(dtPersonal) & "', " &
               "''," &
               "'" & comentVersion & "')"
        sqlExecute(query, "NOMINA")
    End Sub

    Private Sub btnGuardarEstado_Click(sender As Object, e As EventArgs) Handles btnGuardarEstado.Click
        If MessageBox.Show("¿Desea guardar el estado actual de los datos para la bitácora?", "Guardar versión", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Dim comentario As New frmComentarioVersionProceso
            If comentario.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Me.Cursor = Cursors.WaitCursor
                GuardarProceso(comentario.strComentario)
                Me.Cursor = Cursors.Default
                MessageBox.Show("Se ha realizado el respaldo", "Respaldo bitacora", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
#End Region

#Region "Modificar Ausentismos o incapacides y recalcular"
    Private Sub dgPromediosEnviar_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgPromediosEnviar.CellValueChanged
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Try
                Dim columnName As String = dgPromediosEnviar.Columns(e.ColumnIndex).Name
                If columnName = "Ausentismos" Or columnName = "Incapacidades" Then
                    'cambiarSeleccion(e)
                    Dim reloj = dgPromediosEnviar.Rows(e.RowIndex).Cells("reloj").Value
                    Dim row = dtPersonal.Select("reloj = '" & reloj & "'").FirstOrDefault()
                    row(columnName) = Convert.ToUInt32(dgPromediosEnviar.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                    ActualizarResultados(dtPersonal)
                End If
                If columnName = "nvo_fct_int" Or columnName = "nvo_pro_var" Or columnName = "integrado_imss" Then
                    Dim reloj = dgPromediosEnviar.Rows(e.RowIndex).Cells("reloj").Value
                    Dim row = dtPersonal.Select("reloj = '" & reloj & "'").FirstOrDefault()
                    row(columnName) = Convert.ToDecimal(dgPromediosEnviar.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                    ActualizarResultados(dtPersonal)
                End If
            Catch ex As Exception
                ActualizarResultados(dtPersonal)
            End Try
        End If

    End Sub

    Private Sub dgPromediosNoEnviar_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgPromediosNoEnviar.CellValueChanged
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Try
                Dim columnName As String = dgPromediosNoEnviar.Columns(e.ColumnIndex).Name
                If columnName = "Ausentismos" Or columnName = "Incapacidades" Then
                    'cambiarSeleccion(e)
                    Dim reloj = dgPromediosNoEnviar.Rows(e.RowIndex).Cells("reloj").Value
                    Dim row = dtPersonal.Select("reloj = '" & reloj & "'").FirstOrDefault()
                    row(columnName) = Convert.ToUInt32(dgPromediosNoEnviar.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                    ActualizarResultados(dtPersonal)
                End If
                If columnName = "nvo_fct_int" Or columnName = "nvo_pro_var" Or columnName = "integrado_imss" Then
                    Dim reloj = dgPromediosNoEnviar.Rows(e.RowIndex).Cells("reloj").Value
                    Dim row = dtPersonal.Select("reloj = '" & reloj & "'").FirstOrDefault()
                    row(columnName) = Convert.ToDecimal(dgPromediosNoEnviar.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                    ActualizarResultados(dtPersonal)
                End If
            Catch ex As Exception
                ActualizarResultados(dtPersonal)
            End Try
        End If
    End Sub

    Private Sub cambiarSeleccion(e As DataGridViewCellEventArgs)
        Dim UMA As Decimal = dgPromediosEnviar.Rows(e.RowIndex).Cells("UMA").Value
        Dim bondesGravadoActual As Decimal = dgPromediosEnviar.Rows(e.RowIndex).Cells("bondes_gravado").Value
        Dim reloj As String = dgPromediosEnviar.Rows(e.RowIndex).Cells("Reloj").Value
        Dim ausentismos As Integer = dgPromediosEnviar.Rows(e.RowIndex).Cells("Ausentismos").Value
        Dim incapacidades As Integer = dgPromediosEnviar.Rows(e.RowIndex).Cells("Incapacidades").Value
        Dim dias As Integer = dgPromediosEnviar.Rows(e.RowIndex).Cells("Dias").Value
        Dim totalDias As Integer = dias - ausentismos + incapacidades
        Dim BondesActual As Decimal = dgPromediosEnviar.Rows(e.RowIndex).Cells("BONDES").Value
        Dim bondexExcento = Math.Min(totalDias * UMA * 0.4D, BondesActual)
        Dim Total As Decimal = dgPromediosEnviar.Rows(e.RowIndex).Cells("TOTAL").Value
        Dim nvoFctIntegracion As Decimal = dgPromediosEnviar.Rows(e.RowIndex).Cells("nvo_fct_int").Value
        Dim SalarioActual As Decimal = dgPromediosEnviar.Rows(e.RowIndex).Cells("SACTUAL").Value
        Dim totalSinBondesGravado As Decimal = Total - bondesGravadoActual
        Dim bondesGravado As Decimal = BondesActual - bondexExcento
        Dim TOPE = UMA * 25
        Total = totalSinBondesGravado + bondesGravado
        Dim provar As Decimal
        If (totalDias <> 0) Then
            Try
                provar = Math.Round(Total / totalDias, 2)
            Catch ex As Exception
                provar = 0
            End Try
        Else
            provar = 0
        End If
        Dim nvo_pro_var As Decimal = provar
        Dim nvoIntegrado = RoundUp(SalarioActual * nvoFctIntegracion + provar, 2)
        Dim integradoIMSS As Decimal
        If (nvoIntegrado < TOPE) Then
            integradoIMSS = nvoIntegrado
        Else
            integradoIMSS = TOPE
        End If
        Dim row As DataRow = dtPersonal.Select("reloj = '" & reloj & "'").FirstOrDefault()
        Try
            row("Total") = Total
            row("Total_dias") = totalDias
            row("bondes_exento") = bondexExcento
            row("pro_var") = provar
            row("nvo_pro_var") = nvo_pro_var
            row("nvo_integrado") = nvoIntegrado
            row("integrado_imss") = integradoIMSS
            row("ausentismos") = ausentismos
            row("incapacidades") = incapacidades
            row("bondes_gravado") = bondesGravado
            ActualizarResultados(dtPersonal)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cambiarSeleccionNoEnviar(e As DataGridViewCellEventArgs)
        Dim UMA As Decimal = dgPromediosEnviar.Rows(e.RowIndex).Cells("UMA").Value
        Dim bondesGravadoActual As Decimal = dgPromediosNoEnviar.Rows(e.RowIndex).Cells("bondes_gravado").Value
        Dim reloj As String = dgPromediosNoEnviar.Rows(e.RowIndex).Cells("Reloj").Value
        Dim ausentismos As Integer = dgPromediosNoEnviar.Rows(e.RowIndex).Cells("Ausentismos").Value
        Dim incapacidades As Integer = dgPromediosNoEnviar.Rows(e.RowIndex).Cells("Incapacidades").Value
        Dim dias As Integer = dgPromediosNoEnviar.Rows(e.RowIndex).Cells("Dias").Value
        Dim totalDias As Integer = dias - ausentismos + incapacidades
        Dim BondesActual As Decimal = dgPromediosNoEnviar.Rows(e.RowIndex).Cells("BONDES").Value
        Dim bondexExcento = Math.Min(totalDias * UMA * 0.4D, BondesActual)
        Dim Total As Decimal = dgPromediosNoEnviar.Rows(e.RowIndex).Cells("TOTAL").Value
        Dim nvoFctIntegracion As Decimal = dgPromediosNoEnviar.Rows(e.RowIndex).Cells("nvo_fct_int").Value
        Dim SalarioActual As Decimal = dgPromediosNoEnviar.Rows(e.RowIndex).Cells("SACTUAL").Value
        Dim totalSinBondesGravado As Decimal = Total - bondesGravadoActual
        Dim bondesGravado As Decimal = BondesActual - bondexExcento
        Dim TOPE = UMA * 25
        Total = totalSinBondesGravado + bondesGravado
        Dim provar As Decimal
        If (totalDias <> 0) Then
            Try
                provar = Math.Round(Total / totalDias, 2)
            Catch ex As Exception
                provar = 0
            End Try
        Else
            provar = 0
        End If
        Dim nvo_pro_var As Decimal = provar
        Dim nvoIntegrado = RoundUp(SalarioActual * nvoFctIntegracion + provar, 2)
        Dim integradoIMSS As Decimal
        If (nvoIntegrado < TOPE) Then
            integradoIMSS = nvoIntegrado
        Else
            integradoIMSS = TOPE
        End If
        Dim row As DataRow = dtPersonal.Select("reloj = '" & reloj & "'").FirstOrDefault()
        Try
            row("Total") = Total
            row("Total_dias") = totalDias
            row("bondes_exento") = bondexExcento
            row("pro_var") = provar
            row("nvo_pro_var") = nvo_pro_var
            row("nvo_integrado") = nvoIntegrado
            row("integrado_imss") = integradoIMSS
            row("ausentismos") = ausentismos
            row("incapacidades") = incapacidades
            row("bondes_gravado") = bondesGravado
            ActualizarResultados(dtPersonal)
        Catch ex As Exception

        End Try
    End Sub
#End Region

#Region "Mover registros entre secciones"
    Private Sub dgPromediosEnviar_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgPromediosEnviar.CellMouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                dgPromediosEnviar.Rows(e.RowIndex).Selected = True
                Dim reloj As String = dgPromediosEnviar.Rows(e.RowIndex).Cells("Reloj").Value
                MandarANoEnviarMenuItem.Text = "Mandar a la sección de No Enviar: " & reloj & ""
                ContextMenuStripGridEnviar.Show(Cursor.Position.X, Cursor.Position.Y)

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub MandarANoEnviarMenuItem_Click(sender As Object, e As EventArgs) Handles MandarANoEnviarMenuItem.Click
        Dim reloj = MandarANoEnviarMenuItem.Text.Split(" ")(7)
        Dim fila As DataRow = dtPersonal.AsEnumerable().FirstOrDefault(Function(row) row.Field(Of String)("Reloj").Trim = reloj)

        ' Si se encontró la fila, modifica la columna "Activo"
        If fila IsNot Nothing Then
            fila("COMENTARIO") = "NO ENVIAR - Revisado Manualmente"
            fila("REPORTAR_IMSS") = "FALSE"
        End If
        ActualizarResultados(dtPersonal)
    End Sub

    Private Sub dgPromediosNoEnviar_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgPromediosNoEnviar.CellMouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                dgPromediosNoEnviar.Rows(e.RowIndex).Selected = True
                Dim reloj As String = dgPromediosNoEnviar.Rows(e.RowIndex).Cells("Reloj").Value
                MandarAEnviarMenuItem.Text = "Mandar a la sección de Enviar: " & reloj & ""
                ContextMenuStripGridNoEnviar.Show(Cursor.Position.X, Cursor.Position.Y)

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub MandarAEnviarMenuItem_Click(sender As Object, e As EventArgs) Handles MandarAEnviarMenuItem.Click
        Dim reloj = MandarAEnviarMenuItem.Text.Split(" ")(6)
        Dim fila As DataRow = dtPersonal.AsEnumerable().FirstOrDefault(Function(row) row.Field(Of String)("Reloj").Trim = reloj)

        ' Si se encontró la fila, modifica la columna "Activo"
        If fila IsNot Nothing Then
            fila("COMENTARIO") = "ENVIAR - Revisado Manualmente"
            fila("REPORTAR_IMSS") = "TRUE"
        End If
        ActualizarResultados(dtPersonal)
    End Sub

#End Region

#End Region

#Region "Funciones auxiliares"
    Private Sub showDatagrid(dg As DevComponents.DotNetBar.Controls.DataGridViewX, columns As Dictionary(Of String, String), Optional sizeColumn As String = Nothing)
        Try
            For Each item As DataGridViewColumn In dg.Columns
                If columns.Keys.Contains(item.Name) Then : dg.Columns(item.Name).HeaderCell.Value = columns(item.Name)
                Else : dg.Columns(item.Name).Visible = False : End If
            Next
            If Not sizeColumn Is Nothing Then : dg.Columns(sizeColumn).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill : End If
        Catch ex As Exception : End Try
    End Sub

    Private Sub dgHistorial_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgHistorial.CellMouseEnter
        Try

            If (e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0) And ((cellX & "," & cellY) <> (e.ColumnIndex & "," & e.RowIndex)) Then
                cellX = e.ColumnIndex
                cellY = e.RowIndex
                Dim superTooltip As New DevComponents.DotNetBar.SuperTooltipInfo

                superTooltip.HeaderText = "Versión: " & Me.dtHistory.Rows(cellY).Item("versiones")
                superTooltip.BodyText = If(IsDBNull(Me.dtHistory.Rows(cellY).Item("comentario")), "-Sin comentario-", Me.dtHistory.Rows(cellY).Item("comentario"))
                superTooltip.FooterText = "Fecha y hora: " & Me.dtHistory.Rows(cellY).Item("datetime")
                tooltipBitacora.SetSuperTooltip(dgHistorial, superTooltip)
                tooltipBitacora.ShowTooltip(dgHistorial)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgPromediosEnviar_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgPromediosEnviar.DataBindingComplete
        For Each column As DataGridViewColumn In dgPromediosEnviar.Columns
            ' Deshabilitar la edición por defecto
            column.ReadOnly = True
        Next

        Try
            dgPromediosEnviar.Columns("Ausentismos").ReadOnly = False
            dgPromediosEnviar.Columns("Incapacidades").ReadOnly = False
            dgPromediosEnviar.Columns("nvo_fct_int").ReadOnly = False
            dgPromediosEnviar.Columns("nvo_pro_var").ReadOnly = False
            dgPromediosEnviar.Columns("integrado_imss").ReadOnly = False

            Dim columnasOcultar As String() = {"curp", "apaterno", "umf", "amaterno", "nombre", "COD_COMP", "IMSS", "dig_ver", "FHA_ULT_MO", "UMA"}

            ' Ocultar las columnas especificadas si existen
            For Each col As String In columnasOcultar
                If dgPromediosEnviar.Columns.Contains(col) Then
                    dgPromediosEnviar.Columns(col).Visible = False
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgPromediosNoEnviar_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgPromediosNoEnviar.DataBindingComplete
        For Each column As DataGridViewColumn In dgPromediosNoEnviar.Columns
            ' Deshabilitar la edición por defecto
            column.ReadOnly = True
        Next
        Try
            ' Habilitar la edición solo en columnas específicas
            dgPromediosNoEnviar.Columns("Ausentismos").ReadOnly = False
            dgPromediosNoEnviar.Columns("Incapacidades").ReadOnly = False
            dgPromediosNoEnviar.Columns("nvo_fct_int").ReadOnly = False
            dgPromediosNoEnviar.Columns("nvo_pro_var").ReadOnly = False
            dgPromediosNoEnviar.Columns("integrado_imss").ReadOnly = False
            Dim columnasOcultar As String() = {"curp", "apaterno", "umf", "amaterno", "nombre", "COD_COMP", "IMSS", "dig_ver", "FHA_ULT_MO", "UMA"}

            ' Ocultar las columnas especificadas si existen
            For Each col As String In columnasOcultar
                If dgPromediosNoEnviar.Columns.Contains(col) Then
                    dgPromediosNoEnviar.Columns(col).Visible = False
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub inicializateComponents()
        Dim anos As DataTable = sqlExecute("select Distinct(ano) as ANO from periodos order by ANO desc", "TA")
        Dim dtBimestres As New DataTable()
        dtBimestres.Columns.Add("Bimestre", GetType(Integer))
        Dim bimestres = Enumerable.Range(1, 6).Select(Function(i) dtBimestres.Rows.Add(i)).ToArray()
        cmbAnos.DataSource = anos
        cmbBimestre.DataSource = dtBimestres
        cmbAnos.DisplayMembers = "ANO"
        cmbAnos.ValueMember = "ANO"
        cmbBimestre.DisplayMembers = "Bimestre"
        cmbBimestre.ValueMember = "Bimestre"
    End Sub
#End Region

#Region "Funciones para calcular promedios variables"

    Private Sub btnGenerarPromedio_Click(sender As Object, e As EventArgs) Handles btnGenerarPromedio.Click

        Try
            btnGenerarExcel.Enabled = False
            dgPromediosEnviar.DataSource = Nothing
            dgPromediosNoEnviar.DataSource = Nothing
            'Ano y bimestre seleccionado para el reporte
            Dim selectedYear As String = cmbAnos.SelectedValue.ToString.Trim
            Dim selectedBimestre As String = cmbBimestre.SelectedValue.ToString.Trim


            'Fecha Inicio y fecha final del bimestre
            Dim mesNatural = ObtenerFechasBimestre(selectedYear, selectedBimestre)

            'Periodos semanales y quincenales del bimestre
            Dim periodoSeleccionado = GetPeriodoSeleccionado(selectedYear, selectedBimestre)
            Dim periodoQuincenaSeleccionado = GetPeriodoQuincenaSeleccionado(selectedYear, selectedBimestre)

            'Obtener fecha primer semana y ultima semana
            Dim primeraSemana = periodoSeleccionado.AsEnumerable() _
              .Where(Function(row) row.Field(Of Object)("PERIODO_ESPECIAL") <> 1) _
              .OrderBy(Function(row) Convert.ToDateTime(row.Field(Of Date)("FECHA_INI"))) _
                          .FirstOrDefault()
            Dim ultimaSemana = periodoSeleccionado.AsEnumerable() _
                          .Where(Function(row) row.Field(Of Object)("PERIODO_ESPECIAL") <> 1) _
                          .OrderByDescending(Function(row) Convert.ToDateTime(row.Field(Of Date)("FECHA_INI"))) _
                          .FirstOrDefault()
            Dim semanasEspeciales = periodoSeleccionado.AsEnumerable() _
                          .Where(Function(row) row.Field(Of Object)("PERIODO_ESPECIAL") = 1) _
                          .OrderBy(Function(row) Convert.ToDateTime(row.Field(Of Date)("FECHA_INI")))

            'Calcular fecha de proyeccion

            Dim proximoBimestre = ObtenerFechasBimestre(selectedYear, selectedBimestre + 1)
            Try : FechaProyeccion = proximoBimestre.Rows(0)("FECHA_FIN") : Catch ex As Exception : FechaProyeccion = "" : End Try
            Try : FechaProyeccionINI = proximoBimestre.Rows(0)("FECHA_INI") : Catch ex As Exception : FechaProyeccionINI = "" : End Try

            'Seccion 1 - Datos del personal
            dtPersonal = GetPersonalData(mesNatural, ultimaSemana)
            dtPersonal = SetPersonalUMA(dtPersonal)

            'Seccion 2 - Calculo de Total Dias
            'Cambio en CTE - los Dias, ausentismos e incapacidades se calculan a partir de las fechas del primer y ultimo periodo semanal
            dtPersonal = CalculateTotalDays(dtPersonal, primeraSemana, ultimaSemana)

            'Seccion 3 - BONOS
            Dim dtBonos = GetBonList(periodoSeleccionado, periodoQuincenaSeleccionado)
            dtPersonal = CalculateBondes(dtPersonal, dtBonos)
            dtPersonal = CalculateDinamicBon(dtPersonal, dtBonos)

            'Seccion 4 - Nuevo Integrado
            CalculatePromedioVariable(dtPersonal)
            CalculateAntiguedad(dtPersonal)
            CalculateFactorIntegracion(dtPersonal)
            CalculateNvoProVar(dtPersonal)
            CalculateNvoIntegrado(dtPersonal)
            CalculateIntegradoIMSS(dtPersonal)

            'Seccion 5 - Definir Envio del integrado IMSS
            ReporteAIMSS(dtPersonal, mesNatural)

            'Cargar resultados
            CargarResultados(dtPersonal, periodoSeleccionado, periodoQuincenaSeleccionado)
        Catch ex As Exception
            MessageBox.Show("No fue posible cargar los datos con los parametros seleccionados, verifique los datos ingresados.", "Error")
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
        'GENERAR EXCEL
        'GenerarLibroPromediosVariables(dtPersonal)

    End Sub

    Private Sub CargarResultados(dtPersonal As DataTable, periodoSeleccionado As DataTable, periodoQuincenaSeleccionado As DataTable)
        Dim rowsCorrecto() As DataRow = dtPersonal.Select("REPORTAR_IMSS = 'TRUE'")
        Dim personalCorrecto As New DataTable
        If rowsCorrecto.Length > 0 Then
            personalCorrecto = rowsCorrecto.CopyToDataTable()
        Else
            personalCorrecto = dtPersonal.Clone()
        End If

        Dim rowsIncorrecto() As DataRow = dtPersonal.Select("REPORTAR_IMSS = 'FALSE'")
        Dim personalIncorrecto As New DataTable
        If rowsIncorrecto.Length > 0 Then
            personalIncorrecto = rowsIncorrecto.CopyToDataTable()
        Else
            personalIncorrecto = dtPersonal.Clone()
        End If

        dgPromediosEnviar.DataSource = personalCorrecto
        dgPromediosNoEnviar.DataSource = personalIncorrecto

        dgSemanasIncluidas.DataSource = periodoSeleccionado
        dgQuincenasIncluidas.DataSource = periodoQuincenaSeleccionado

        btnGenerarExcel.Enabled = True
        btnGuardarEstado.Enabled = True
        btnGenerarReportes.Enabled = True
    End Sub

    Private Sub ActualizarResultados(dtPersonal As DataTable)
        Dim rowsCorrecto() As DataRow = dtPersonal.Select("REPORTAR_IMSS = 'TRUE'")
        Dim personalCorrecto As New DataTable
        If rowsCorrecto.Length > 0 Then
            personalCorrecto = rowsCorrecto.CopyToDataTable()
        Else
            personalCorrecto = dtPersonal.Clone()
        End If

        Dim rowsIncorrecto() As DataRow = dtPersonal.Select("REPORTAR_IMSS = 'FALSE'")
        Dim personalIncorrecto As New DataTable
        If rowsIncorrecto.Length > 0 Then
            personalIncorrecto = rowsIncorrecto.CopyToDataTable()
        Else
            personalIncorrecto = dtPersonal.Clone()
        End If
        dgPromediosEnviar.DataSource = New DataTable
        dgPromediosEnviar.DataSource = personalCorrecto
        dgPromediosNoEnviar.DataSource = New DataTable
        dgPromediosNoEnviar.DataSource = personalIncorrecto

        btnGenerarExcel.Enabled = True
        btnGuardarEstado.Enabled = True
        btnGenerarReportes.Enabled = True
    End Sub

    Private Function GetDateLimit(selectedYear As String, selectedBimestre As String) As DataTable
        Dim result As DataTable = sqlExecute("SELECT  MIN(FECHA_INI) AS FECHA_INI, MAX(FECHA_FIN) AS FECHA_FIN FROM (SELECT MIN(FECHA_INI) AS FECHA_INI, MAX(FECHA_FIN) AS FECHA_FIN  FROM periodos_quincenal WHERE bimestre_periodo = '" & selectedYear + selectedBimestre & "' UNION ALL SELECT MIN(FECHA_INI) AS FECHA_INI, MAX(FECHA_FIN) AS FECHA_FIN  FROM periodos  WHERE bimestre_periodo = '" & selectedYear + selectedBimestre & "') AS union_result;", "TA")
        Return result
    End Function

    Private Function SetPersonalUMA(dtPersonal As DataTable) As DataTable
        ' Obtener los datos de UMA desde la base de datos
        Dim dtUMAS As DataTable = sqlExecute("SELECT cod_comp, UMA FROM cias", "personal")

        ' Añadir la columna UMA a dtPersonal si no existe
        If Not dtPersonal.Columns.Contains("UMA") Then
            dtPersonal.Columns.Add("UMA", GetType(Decimal))
        End If

        ' Recorrer cada fila de dtPersonal
        For Each row As DataRow In dtPersonal.Rows
            Dim codComp As String = row("COD_COMP").ToString()

            ' Buscar el valor de UMA en dtUMAS
            Dim umaRows() As DataRow = dtUMAS.Select("cod_comp = '" & codComp & "'")

            ' Asignar el valor de UMA a la columna UMA en dtPersonal
            If umaRows.Length > 0 Then
                Dim uma As Decimal = Convert.ToDecimal(umaRows(0)("UMA"))
                row("UMA") = uma
            Else
                ' Si no se encuentra el cod_comp, asignar un valor por defecto (por ejemplo, 0)
                row("UMA") = 0D
            End If
        Next

        Return dtPersonal
    End Function

    Private Function GetBonList(periodoSeleccionado As DataTable, periodoQuincenaSeleccionado As DataTable) As DataTable
        ' Construir la lista para periodos semanales
        Dim periodosSemanalList As String = String.Join(" OR ",
            From row In periodoSeleccionado.AsEnumerable()
            Select "(m.ano = " & row("ano") & " AND m.periodo = " & row("periodo") & ")")

        ' Construir la lista para periodos quincenales
        Dim periodosQuincenalList As String = String.Join(" OR ",
            From row In periodoQuincenaSeleccionado.AsEnumerable()
            Select "(m.ano = " & row("ano") & " AND m.periodo = " & row("periodo") & ")")

        ' Verificar si ambas listas están vacías
        If String.IsNullOrWhiteSpace(periodosSemanalList) AndAlso String.IsNullOrWhiteSpace(periodosQuincenalList) Then
            Return New DataTable()
        End If

        ' Generar la consulta SQL
        Dim query As String = "SELECT m.RELOJ, m.CONCEPTO, SUM(m.MONTO) AS TOTAL_POR_CONCEPTO_Y_RELOJ " &
                              "FROM movimientosvw m " &
                              "WHERE provar = 1 "

        If Not String.IsNullOrWhiteSpace(periodosSemanalList) Then
            query &= "AND (m.tipo_periodo = 'S' AND (" & periodosSemanalList & ")) "
        End If

        If Not String.IsNullOrWhiteSpace(periodosQuincenalList) Then
            If Not String.IsNullOrWhiteSpace(periodosSemanalList) Then
                query &= "OR (m.tipo_periodo = 'Q' AND (" & periodosQuincenalList & ")) "
            Else
                query &= "AND (m.tipo_periodo = 'Q' AND (" & periodosQuincenalList & ")) "
            End If
        End If

        query &= "GROUP BY m.CONCEPTO, m.RELOJ;"

        ' Ejecutar la consulta
        Dim result As DataTable = sqlExecute(query, "NOMINA")
        Return result
    End Function

    Function ObtenerFechasBimestre(selectedYear As Integer, selectedBimestre As Integer) As DataTable
        ' Crear el DataTable con las columnas FECHA_INI y FECHA_FIN
        Dim dt As New DataTable("Bimestre")
        dt.Columns.Add("FECHA_INI", GetType(DateTime))
        dt.Columns.Add("FECHA_FIN", GetType(DateTime))

        ' Definir los meses de inicio de cada bimestre
        Dim mesesInicio As Integer() = {1, 3, 5, 7, 9, 11}

        ' Validar el número del bimestre
        If selectedBimestre < 1 OrElse selectedBimestre > 7 Then
            Return dt ' Devuelve un DataTable vacío para número de bimestre no válido
        End If

        Dim mesInicio As Integer
        Dim inicio As DateTime
        Dim fin As DateTime

        If selectedBimestre = 7 Then
            ' Para el bimestre 7, obtener el primer bimestre del año siguiente
            selectedYear += 1
            mesInicio = mesesInicio(0) ' Enero
        Else
            mesInicio = mesesInicio(selectedBimestre - 1)
        End If

        inicio = New DateTime(selectedYear, mesInicio, 1)
        If mesInicio = 11 AndAlso selectedBimestre <> 7 Then
            ' Para el último bimestre del año actual
            fin = New DateTime(selectedYear + 1, 1, 1).AddDays(-1)
        Else
            ' Para otros bimestres, la fecha final es el último día del mes siguiente al final del bimestre
            fin = New DateTime(selectedYear, mesInicio + 2, 1).AddDays(-1)
        End If

        ' Agregar la fila al DataTable
        dt.Rows.Add(inicio, fin)

        Return dt
    End Function

    Private Function GetPeriodoSeleccionado(selectedYear As String, selectedBimestre As Integer) As DataTable
        Return sqlExecute("SELECT ano, periodo,FECHA_INI,FECHA_FIN,FECHA_PAGO,PERIODO_ESPECIAL FROM periodos WHERE bimestre_periodo = '" & selectedYear & selectedBimestre & "'", "TA")
    End Function

    Private Function GetPeriodoQuincenaSeleccionado(selectedYear As String, selectedBimestre As String) As DataTable
        Return sqlExecute("SELECT ano,periodo,FECHA_INI,FECHA_FIN,FECHA_PAGO,PERIODO_ESPECIAL FROM periodos_quincenal where bimestre_periodo = '" & selectedYear & selectedBimestre & "'", "TA")
    End Function

    Private Function GetPersonalData(dtFechaLimiteBajas As DataTable, dtFechaLimiteAltas As DataRow) As DataTable
        Dim fechaLimiteBajas As DateTime = dtFechaLimiteBajas.Rows(0)("FECHA_FIN")
        Dim fechaLimiteAltas As DateTime = dtFechaLimiteAltas("FECHA_FIN")

        Return sqlExecute("SELECT RELOJ,curp,apaterno,umf,amaterno,nombre,COD_COMP,IMSS,dig_ver,FHA_ULT_MO, nombres, CASE WHEN COD_CLASE = 'G' THEN 'G' ELSE COD_TIPO END AS COD_TIPO, COD_CLASE, ALTA, BAJA, alta_vacacion, SACTUAL, FACTOR_INT, PRO_VAR, INTEGRADO " &
                         "FROM personalvw " &
                         "WHERE (BAJA IS NULL OR BAJA > '" & fechaLimiteBajas.ToString("yyyy-MM-dd") & "') AND (ALTA <= '" & fechaLimiteAltas.ToString("yyyy-MM-dd") & "') AND (alta_vacacion IS NOT NULL) " &
                         "ORDER BY RELOJ", "personal")
    End Function

    Private Function CalculateTotalDays(dtPersonal As DataTable, primeraSemana As DataRow, ultimaSemana As DataRow) As DataTable
        Dim fechaInicioPeriodo As DateTime = primeraSemana("FECHA_INI")
        Dim fechaFinPeriodo As DateTime = ultimaSemana("FECHA_FIN")

        ' Añadir columnas solo una vez
        dtPersonal.Columns.Add("Dias", GetType(Integer))
        dtPersonal.Columns.Add("Ausentismos", GetType(Integer))
        dtPersonal.Columns.Add("Incapacidades", GetType(Integer))
        dtPersonal.Columns.Add("Total_Dias", GetType(Integer))

        ' Crear un diccionario para ausentismos e incapacidades para acceder más rápido
        Dim ausentismosDict As New Dictionary(Of String, Integer)
        Dim incapacidadesDict As New Dictionary(Of String, Integer)

        ' Obtener ausentismos
        Dim dtAusentismos As DataTable = sqlExecute("SELECT reloj, COUNT(reloj) AS cuantos FROM ausentismo WHERE fecha BETWEEN '" & fechaInicioPeriodo.ToString("yyyy-MM-dd") & "' AND '" & fechaFinPeriodo.ToString("yyyy-MM-dd") & "' AND tipo_aus NOT IN ('VAC','FES','MAT','NAC','FUN','PMA','LIC','COR','PGO','C50','16','MED','17','PAR','MAR','BER','SAL','C50','DES','DFI','PSG','INA','ING','INR','INV','IMA','MAT','RT','EG','INA') GROUP BY reloj ORDER BY reloj", "TA")
        For Each row As DataRow In dtAusentismos.Rows
            ausentismosDict(row("reloj").ToString()) = CInt(row("cuantos"))
        Next

        ' Obtener incapacidades
        Dim dtIncapacidades As DataTable = sqlExecute("SELECT reloj, COUNT(reloj) AS cuantos FROM ausentismo WHERE fecha BETWEEN '" & fechaInicioPeriodo.ToString("yyyy-MM-dd") & "' AND '" & fechaFinPeriodo.ToString("yyyy-MM-dd") & "' AND tipo_aus IN ('INA','ING','INR','INV','IMA','MAT','RT','EG','INA') GROUP BY reloj ORDER BY reloj", "TA")
        For Each row As DataRow In dtIncapacidades.Rows
            incapacidadesDict(row("reloj").ToString()) = CInt(row("cuantos"))
        Next

        ' Calcular días, ausentismos e incapacidades
        For Each personalRow As DataRow In dtPersonal.Rows
            Dim fechaAltaEmpleado As Date = CDate(personalRow("ALTA"))
            Dim dias As Integer

            If fechaAltaEmpleado >= fechaInicioPeriodo AndAlso fechaAltaEmpleado <= fechaFinPeriodo Then
                dias = (fechaFinPeriodo - fechaAltaEmpleado).Days + 1
            Else
                dias = (fechaFinPeriodo - fechaInicioPeriodo).Days + 1
            End If

            personalRow("Dias") = dias

            Dim relojActual As String = personalRow("RELOJ").ToString()
            Dim cantidadAusentismos As Integer = If(ausentismosDict.ContainsKey(relojActual), ausentismosDict(relojActual), 0)
            Dim cantidadIncapacidades As Integer = If(incapacidadesDict.ContainsKey(relojActual), incapacidadesDict(relojActual), 0)

            personalRow("Ausentismos") = cantidadAusentismos
            personalRow("Incapacidades") = cantidadIncapacidades
            personalRow("Total_Dias") = dias - cantidadAusentismos - cantidadIncapacidades
        Next

        Return dtPersonal
    End Function

    Private Function CalculateBondes(dtPersonal As DataTable, dtBonos As DataTable) As DataTable
        dtPersonal.Columns.Add("BONDES", GetType(Decimal))
        dtPersonal.Columns.Add("bondes_exento", GetType(Decimal))
        dtPersonal.Columns.Add("bondes_gravado", GetType(Decimal))

        ' Pre-filtrar los conceptos relevantes para BONDES
        Dim conceptosBondes As String() = {"BONDES", "BONPA1", "BONPA2", "BONPA3"}

        For Each row As DataRow In dtPersonal.Rows
            Dim relojActual As String = row("RELOJ").ToString()
            Dim bondesSum As Decimal = 0
            Dim uma As Decimal = row("UMA")

            ' Filtrar solo los registros del empleado actual y conceptos relevantes
            bondesSum = dtBonos.AsEnumerable() _
                .Where(Function(dr) dr.Field(Of String)("RELOJ") = relojActual AndAlso conceptosBondes.Contains(dr.Field(Of String)("CONCEPTO").Trim())) _
                .Sum(Function(dr) dr.Field(Of Double)("TOTAL_POR_CONCEPTO_Y_RELOJ"))

            row("BONDES") = RoundUp(bondesSum, 2)

            ' Calcular Bono Exento y Gravado
            Dim dias As Integer = Convert.ToInt32(row("Total_Dias"))
            Dim valorBonoExcento As Decimal = Math.Min(dias * uma * 0.4D, bondesSum)

            row("bondes_exento") = Math.Round(valorBonoExcento, 2)
            row("bondes_gravado") = Math.Round(bondesSum - valorBonoExcento, 2)
        Next

        Return dtPersonal
    End Function

    Private Function CalculateDinamicBon(dtPersonal As DataTable, dtBonos As DataTable) As DataTable
        Dim dtTotalBonos As New DataTable
        dtTotalBonos.Columns.Add("RELOJ", GetType(String))
        dtTotalBonos.Columns.Add("TOTAL", GetType(Decimal))

        Dim conceptosExcluidos As String() = {"BONDES", "BONPA1", "BONPA2", "BONPA3"}

        For Each row As DataRow In dtPersonal.Rows
            Dim relojActual As String = row("RELOJ").ToString()
            Dim sumatoriaTotal As Decimal = Convert.ToDecimal(row("bondes_gravado"))

            ' Filtrar y procesar bonos dinámicos
            Dim rowsDinamicBonos = dtBonos.AsEnumerable() _
                .Where(Function(dr) dr.Field(Of String)("RELOJ") = relojActual AndAlso Not conceptosExcluidos.Contains(dr.Field(Of String)("CONCEPTO").Trim()))

            For Each dr In rowsDinamicBonos
                Dim nombreBonoDinamicoActual As String = dr.Field(Of String)("CONCEPTO").Trim()
                If Not dtPersonal.Columns.Contains(nombreBonoDinamicoActual) Then
                    dtPersonal.Columns.Add(nombreBonoDinamicoActual, GetType(Decimal))
                End If

                Dim monto As Decimal = Math.Round(dr.Field(Of Double)("TOTAL_POR_CONCEPTO_Y_RELOJ"), 3)
                row(nombreBonoDinamicoActual) = monto
                sumatoriaTotal += monto
            Next

            dtTotalBonos.Rows.Add(relojActual, sumatoriaTotal)
        Next

        ' Asignar los totales de bonos al DataTable
        dtPersonal.Columns.Add("Total", GetType(Decimal))
        For Each row As DataRow In dtPersonal.Rows
            Dim relojActual As String = row("RELOJ").ToString()
            Dim totalRow As DataRow = dtTotalBonos.AsEnumerable().FirstOrDefault(Function(r) r.Field(Of String)("RELOJ") = relojActual)
            row("Total") = If(totalRow IsNot Nothing, Math.Round(totalRow.Field(Of Decimal)("TOTAL"), 3), 0D)
        Next

        Return dtPersonal
    End Function

    Private Sub CalculatePromedioVariable(dtPersonal As DataTable)
        dtPersonal.Columns.Add("pro_var")

        For row As Integer = 0 To dtPersonal.Rows.Count - 1
            If (dtPersonal.Rows(row)("Total_Dias") <> 0) Then
                Try
                    dtPersonal.Rows(row)("pro_var") = Math.Round(dtPersonal.Rows(row)("Total") / dtPersonal.Rows(row)("Total_Dias"), 2)
                Catch ex As Exception
                    dtPersonal.Rows(row)("pro_var") = 0
                End Try
            Else
                dtPersonal.Rows(row)("pro_var") = 0
            End If
        Next
    End Sub

    Private Sub CalculateAntiguedad(dtPersonal As DataTable)
        dtPersonal.Columns.Add("nvo_antiguedad")

        For row As Integer = 0 To dtPersonal.Rows.Count - 1
            Dim diferencia As Integer = SIFECHA(dtPersonal.Rows(row)("alta_vacacion"), FechaProyeccion)
            dtPersonal.Rows(row)("nvo_antiguedad") = diferencia + 1
        Next
    End Sub

    Private Sub CalculateFactorIntegracion(dtPersonal As DataTable)
        dtPersonal.Columns.Add("nvo_fct_int")

        Dim dtFactores As DataTable = sqlExecute("SELECT * FROM factores", "personal")

        For row As Integer = 0 To dtPersonal.Rows.Count - 1
            Dim antiguedad As Integer = dtPersonal.Rows(row)("nvo_antiguedad")
            Dim cod_tipo As String = dtPersonal.Rows(row)("COD_TIPO")
            Dim cod_comp As String = dtPersonal.Rows(row)("COD_COMP")
            Dim filtro As String = "ANOS = " & antiguedad & " AND COD_TIPO = '" & cod_tipo & "' AND COD_COMP = '" & cod_comp & "'"
            Dim factores As DataRow = dtFactores.Select(filtro).FirstOrDefault()
            If factores IsNot Nothing Then
                dtPersonal.Rows(row)("nvo_fct_int") = factores("FACTOR_INT")
            Else
                dtPersonal.Rows(row)("nvo_fct_int") = 0
            End If
        Next
    End Sub

    Private Sub CalculateNvoProVar(dtPersonal As DataTable)
        dtPersonal.Columns.Add("nvo_pro_var")

        For row As Integer = 0 To dtPersonal.Rows.Count - 1
            dtPersonal.Rows(row)("nvo_pro_var") = dtPersonal.Rows(row)("pro_var")
        Next
    End Sub

    Private Sub CalculateNvoIntegrado(dtPersonal As DataTable)
        dtPersonal.Columns.Add("nvo_integrado")

        For row As Integer = 0 To dtPersonal.Rows.Count - 1
            Try
                dtPersonal.Rows(row)("nvo_integrado") = RoundUp((dtPersonal.Rows(row)("SACTUAL") * dtPersonal.Rows(row)("nvo_fct_int")) + dtPersonal.Rows(row)("nvo_pro_var"), 2)
            Catch ex As Exception
                dtPersonal.Rows(row)("nvo_integrado") = 0
            End Try
        Next
    End Sub

    Private Sub CalculateIntegradoIMSS(dtPersonal As DataTable)
        dtPersonal.Columns.Add("integrado_imss")

        For row As Integer = 0 To dtPersonal.Rows.Count - 1
            Dim UMA = dtPersonal(row)("UMA")
            Dim TOPE = UMA * 25
            If (dtPersonal.Rows(row)("nvo_integrado") < TOPE) Then
                dtPersonal.Rows(row)("integrado_imss") = dtPersonal.Rows(row)("nvo_integrado")
            Else
                dtPersonal.Rows(row)("integrado_imss") = TOPE
            End If
        Next
    End Sub

    Private Sub ReporteAIMSS(dtPersonal As DataTable, mesNatural As DataTable)
        dtPersonal.Columns.Add("COMENTARIO")
        dtPersonal.Columns.Add("REPORTAR_IMSS")
        Dim fechaFinPeriodo As DateTime = mesNatural.Rows(0)("FECHA_FIN")
        Dim dtIncapacidad15Dias = sqlExecute("select reloj,fecha,tipo_aus from ausentismo where fecha between '" & fechaFinPeriodo.AddDays(-15) & "' and '" & fechaFinPeriodo & "' and tipo_aus in ('INA','ING','INR','INV','IMA','MAT','RT','EG','FI','INA') order by reloj", "TA")
        Dim dtIncapacidad1ro = sqlExecute("select reloj,fecha,tipo_aus from ausentismo where fecha ='" & fechaFinPeriodo.AddDays(1) & "' and tipo_aus in ('INA','ING','INR','INV','IMA','MAT','RT','EG','FI','INA') order by reloj", "TA")
        For row As Integer = 0 To dtPersonal.Rows.Count - 1
            Dim integradoAnterior = dtPersonal.Rows(row)("INTEGRADO")
            Dim nuevoIntegrado = dtPersonal.Rows(row)("Integrado_IMSS")
            Dim UMA = dtPersonal.Rows(row)("UMA")
            Dim TOPE = UMA * 25
            If (integradoAnterior = nuevoIntegrado) Then
                dtPersonal.Rows(row)("COMENTARIO") = "NO ENVIAR - mismo integrado del bimestre anterior."
                dtPersonal.Rows(row)("REPORTAR_IMSS") = "FALSE"
                Continue For
            End If
            If (integradoAnterior >= TOPE And nuevoIntegrado >= TOPE) Then
                dtPersonal.Rows(row)("COMENTARIO") = "NO ENVIAR - Topado desde bimestre anterior."
                dtPersonal.Rows(row)("REPORTAR_IMSS") = "FALSE"
                Continue For
            End If
            If (dtIncapacidad1ro.Select("reloj = '" & dtPersonal(row)("RELOJ") & "'").Any()) Then
                dtPersonal.Rows(row)("COMENTARIO") = "NO ENVIAR - Incapacidad 1o del bimestre."
                dtPersonal.Rows(row)("REPORTAR_IMSS") = "FALSE"
                Continue For
            End If
            If (dtIncapacidad15Dias.Select("reloj = '" & dtPersonal(row)("RELOJ") & "'").Count() >= 8) Then
                dtPersonal.Rows(row)("COMENTARIO") = "REVISAR, posible incapacidad."
                dtPersonal.Rows(row)("REPORTAR_IMSS") = "FALSE"
                Continue For
            End If
            If (Math.Abs(integradoAnterior - nuevoIntegrado) <= 0.5) Then
                dtPersonal.Rows(row)("COMENTARIO") = "REVISAR - Integrado muy similar al bimestre anterior."
                dtPersonal.Rows(row)("REPORTAR_IMSS") = "FALSE"
                Continue For
            End If
            dtPersonal.Rows(row)("REPORTAR_IMSS") = "TRUE"
        Next
    End Sub

    Private Sub GenerarLibroPromediosVariables(dtPersonal As DataTable)
        Try
            ' Las columnas que quieres omitir
            Dim columnasOmitir As New List(Of String) From {
                "curp", "apaterno", "umf", "amaterno", "nombre",
                "FHA_ULT_MO"
            }

            'Datos encabezados
            Dim selectedYear As String = cmbAnos.SelectedValue.ToString.Trim
            Dim selectedBimestre As String = cmbBimestre.SelectedValue.ToString.Trim

            Dim periodoSeleccionado = GetPeriodoSeleccionado(selectedYear, selectedBimestre)
            Dim periodoQuincenaSeleccionado = GetPeriodoQuincenaSeleccionado(selectedYear, selectedBimestre)

            'Obtener fecha primer semana y ultima semana
            Dim primeraSemana = periodoSeleccionado.AsEnumerable() _
              .Where(Function(row) row.Field(Of Object)("PERIODO_ESPECIAL") <> 1) _
              .OrderBy(Function(row) Convert.ToDateTime(row.Field(Of Date)("FECHA_INI"))) _
                          .FirstOrDefault()
            Dim ultimaSemana = periodoSeleccionado.AsEnumerable() _
                          .Where(Function(row) row.Field(Of Object)("PERIODO_ESPECIAL") <> 1) _
                          .OrderByDescending(Function(row) Convert.ToDateTime(row.Field(Of Date)("FECHA_INI"))) _
                          .FirstOrDefault()
            Dim semanasEspeciales = periodoSeleccionado.AsEnumerable() _
                          .Where(Function(row) row.Field(Of Object)("PERIODO_ESPECIAL") = 1) _
                          .OrderBy(Function(row) Convert.ToDateTime(row.Field(Of Date)("FECHA_INI")))

            Dim periodosConcatenados As String = String.Join(", ", semanasEspeciales.Select(Function(row) row.Field(Of String)("periodo")))

            Dim fechaInicioPeriodo As String = primeraSemana("periodo")
            Dim fechaFinPeriodo As String = ultimaSemana("periodo")

            Dim dtNombresConceptos = sqlExecute("select Concepto,nombre from conceptos", "NOMINA")
            Dim dtRegistrosPatronales = sqlExecute("select * from cias", "personal")

            ' Crear un diccionario para acceder rápido a los reg_pat por cod_comp
            Dim dicRegPat As Dictionary(Of String, String) = dtRegistrosPatronales.AsEnumerable() _
                .ToDictionary(Function(row) row("cod_comp").ToString(), Function(row) row("reg_pat").ToString())

            ' Creamos una nueva lista de columnas para agregar la columna combinada "NSS"
            Dim dtFiltrado As New DataTable

            For Each col As DataColumn In dtPersonal.Columns
                If Not columnasOmitir.Contains(col.ColumnName) AndAlso col.ColumnName <> "IMSS" AndAlso col.ColumnName <> "dig_ver" Then
                    dtFiltrado.Columns.Add(col.ColumnName, col.DataType)
                End If
            Next

            ' Agregar la nueva columna "NSS"
            dtFiltrado.Columns.Add("NSS", GetType(String))
            dtFiltrado.Columns("NSS").SetOrdinal(7) ' Colocar NSS en la posición deseada

            ' Agregar la nueva columna "reg_pat"
            dtFiltrado.Columns.Add("reg_pat", GetType(String))
            dtFiltrado.Columns("reg_pat").SetOrdinal(8) ' Colocar reg_pat justo después de NSS

            ' Copiar los datos de las filas
            For Each row As DataRow In dtPersonal.Rows
                Dim newRow As DataRow = dtFiltrado.NewRow()

                For Each col As DataColumn In dtFiltrado.Columns
                    If col.ColumnName = "NSS" Then
                        ' Combinar las columnas "IMSS" y "dig_ver"
                        Dim imssValue As String = If(row("IMSS") IsNot DBNull.Value, row("IMSS").ToString(), String.Empty)
                        Dim digVerValue As String = If(row("dig_ver") IsNot DBNull.Value, row("dig_ver").ToString(), String.Empty)
                        newRow("NSS") = imssValue & digVerValue
                    ElseIf col.ColumnName = "reg_pat" Then
                        ' Obtener el reg_pat utilizando el cod_comp de la fila actual
                        Dim codCompValue As String = If(row("cod_comp") IsNot DBNull.Value, row("cod_comp").ToString().Trim(), String.Empty)
                        If dicRegPat.ContainsKey(codCompValue) Then
                            newRow("reg_pat") = dicRegPat(codCompValue)
                        Else
                            newRow("reg_pat") = "No encontrado"
                        End If
                    Else
                        newRow(col.ColumnName) = row(col.ColumnName)
                    End If
                Next

                dtFiltrado.Rows.Add(newRow)
            Next

            ' Procedimiento para generar el archivo Excel
            Dim fbd As New System.Windows.Forms.FolderBrowserDialog
            If fbd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim PathSel = fbd.SelectedPath
                Dim FileName As String = "CTE - PromedioVariable(" & selectedYear & "-" & selectedBimestre & ").xlsx"
                Dim FullPathSaveFile = PathSel & "\" & FileName

                Using package As New ExcelPackage()
                    ' Crear hoja de Excel
                    Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets.Add("Promedios Variables")


                    ' Agregar la fila de descripciones en la fila 4
                    For colIndex As Integer = 0 To dtFiltrado.Columns.Count - 1
                        Dim columnName As String = dtFiltrado.Columns(colIndex).ColumnName
                        Dim descripcion As String = ""

                        ' Buscar si el nombre de la columna coincide con algún concepto
                        Dim filasCoincidentes = dtNombresConceptos.Select("Concepto = '" & columnName & "'")
                        If filasCoincidentes.Length > 0 Then
                            descripcion = filasCoincidentes(0)("nombre").ToString()
                        End If

                        ' Colocar la descripción en la fila 4
                        worksheet.Cells(5, colIndex + 1).Value = descripcion
                    Next

                    ' Cargar el DataTable en la fila 5 (dejando 4 filas vacías)
                    worksheet.Cells("A6").LoadFromDataTable(dtFiltrado, True)

                    ' Formatear la fila de descripciones
                    Using range As ExcelRange = worksheet.Cells(5, 1, 5, dtFiltrado.Columns.Count)
                        range.Style.Font.Bold = True
                        range.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center
                        range.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                        range.Style.Fill.BackgroundColor.SetColor(Color.LightGray)
                        range.Style.WrapText = True
                    End Using

                    ' Formatear el encabezado
                    Using headerRange As ExcelRange = worksheet.Cells(6, 1, 6, dtFiltrado.Columns.Count)
                        headerRange.Style.Font.Bold = True
                        headerRange.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center
                        headerRange.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center
                        headerRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid
                        headerRange.Style.Fill.BackgroundColor.SetColor(Color.LightBlue)
                        headerRange.Style.WrapText = True
                    End Using

                    ' Ajuste manual del ancho de columnas
                    For colIndex As Integer = 1 To dtFiltrado.Columns.Count
                        worksheet.Column(colIndex).AutoFit()
                        worksheet.Column(colIndex).Width += 5
                    Next

                    ' Formatear las columnas de fecha
                    Dim rowCount As Integer = dtFiltrado.Rows.Count
                    Dim colCount As Integer = dtFiltrado.Columns.Count

                    For colIndex As Integer = 0 To colCount - 1
                        If dtFiltrado.Columns(colIndex).DataType Is GetType(Date) Then
                            Dim cellAddress As String = Chr(65 + colIndex) & "5:" & Chr(65 + colIndex) & (rowCount + 4)
                            worksheet.Cells(cellAddress).Style.Numberformat.Format = "yyyy-MM-dd"
                        End If
                    Next

                    ' TÍTULO PRINCIPAL
                    worksheet.Cells("A1").Value = "CTE Transporte"
                    worksheet.Cells("A1").Style.Font.Bold = True
                    worksheet.Cells("A1").Style.Font.Size = 16
                    worksheet.Cells("A1").Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left

                    ' SUBTÍTULO
                    worksheet.Cells("A2").Value = "Promedios Variables bimestre " & selectedBimestre & " año " & selectedYear & ", efectivos al " & FechaProyeccionINI & " (S" & primeraSemana("periodo") & " - S" & ultimaSemana("periodo") & ", " & periodosConcatenados & " )"
                    worksheet.Cells("A2").Style.Font.Bold = True
                    worksheet.Cells("A2").Style.Font.Size = 14
                    worksheet.Cells("A2").Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left

                    ' DATO: Fecha de Proyección
                    worksheet.Cells("A3").Value = "Fecha proyección = " & FechaProyeccion & ""
                    worksheet.Cells("A3").Style.Font.Bold = False
                    worksheet.Cells("A3").Style.Font.Size = 11
                    worksheet.Cells("A3").Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left

                    ' DATO: Fecha de Proyección
                    worksheet.Cells("D3").Value = "Tope= 25 UMA's"
                    worksheet.Cells("D3").Style.Font.Bold = False
                    worksheet.Cells("D3").Style.Font.Size = 11
                    worksheet.Cells("D3").Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left

                    ' Guardar el archivo
                    package.SaveAs(New System.IO.FileInfo(FullPathSaveFile))
                    MessageBox.Show("Archivo generado correctamente en " & PathSel, "Archivo generado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Process.Start("explorer.exe", PathSel)
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function SIFECHA(ByVal fechaInicial As Date, ByVal fechaFinal As Date) As Integer
        Dim anos As Integer = fechaFinal.Year - fechaInicial.Year
        If fechaFinal.Month < fechaInicial.Month OrElse (fechaFinal.Month = fechaInicial.Month AndAlso fechaFinal.Day < fechaInicial.Day) Then
            anos -= 1
        End If
        Return anos
    End Function

    Private Sub btnGenerarExcel_Click(sender As Object, e As EventArgs) Handles btnGenerarExcel.Click
        GenerarLibroPromediosVariables(dtPersonal)
    End Sub

#End Region


    Private Sub btnAplicarCambios_Click(sender As Object, e As EventArgs) Handles btnAplicarCambios.Click
        If MessageBox.Show("¿Desea aplicar los nuevos saldos y promedios? Esta acción aplicara los datos tal como se muestran en este documento, este cambio es IRREVERSIBLE y no podra DESHACERSE!!.", "Aplicar Cambios", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.OK Then
            Try
                Dim dtProcesar As DataTable = dtPersonal.Clone()

                ' Filtrar las filas donde la columna REPORTAR_IMSS sea 'TRUE'
                Dim rows() As DataRow = dtPersonal.Select("REPORTAR_IMSS = 'TRUE'")

                ' Agregar las filas filtradas al nuevo DataTable
                For Each row As DataRow In rows
                    dtProcesar.ImportRow(row)
                Next

                For Each row As DataRow In dtProcesar.Rows
                    Dim reloj As String = row("reloj").ToString()

                    ' Obtén los datos actuales
                    Dim queryDatosActuales As String = "SELECT TOP 1 pro_var, reloj, factor_int, integrado FROM personal WHERE reloj = '" & reloj & "'"
                    Dim datosActuales As DataTable = sqlExecute(queryDatosActuales, "PERSONAL")

                    If datosActuales.Rows.Count > 0 Then
                        Dim datosActual As DataRow = datosActuales.Rows(0)

                        ' Actualiza los datos en la tabla "personal"
                        Dim queryUpdate As String = "UPDATE personal SET pro_var = " & row("nvo_pro_var") &
                                    ", factor_int = " & row("nvo_fct_int") &
                                    ", integrado = " & row("integrado_imss") &
                                    " WHERE reloj = '" & reloj & "'"
                        sqlExecute(queryUpdate, "PERSONAL")

                        ' Inserta en la bitácora los cambios realizados
                        Dim cadena1 As String = "INSERT INTO bitacora_personal (reloj, campo, valorAnterior, valorNuevo, usuario, fecha, tipo_movimiento) VALUES ('" & reloj & "', 'PRO_VAR', '" & datosActual("pro_var") & "', '" & row("nvo_pro_var") & "', '" & Usuario & "', GETDATE(), 'C')"
                        sqlExecute(cadena1)

                        Dim cadena2 As String = "INSERT INTO bitacora_personal (reloj, campo, valorAnterior, valorNuevo, usuario, fecha, tipo_movimiento) VALUES ('" & reloj & "', 'FACTOR_INT', '" & datosActual("factor_int") & "', '" & row("nvo_fct_int") & "', '" & Usuario & "', GETDATE(), 'C')"
                        sqlExecute(cadena2)

                        Dim cadena3 As String = "INSERT INTO bitacora_personal (reloj, campo, valorAnterior, valorNuevo, usuario, fecha, tipo_movimiento) VALUES ('" & reloj & "', 'INTEGRADO', '" & datosActual("integrado") & "', '" & row("integrado_imss") & "', '" & Usuario & "', GETDATE(), 'C')"
                        sqlExecute(cadena3)
                    End If
                Next
                MessageBox.Show("Los cambios han sido aplicados correctamente.")
            Catch ex As Exception
                MessageBox.Show("Ocurrio un error al aplicar los cambios.")
            End Try
        End If
    End Sub

    Private Sub btnGenerarReportes_Click(sender As Object, e As EventArgs) Handles btnGenerarReportes.Click
        Try
            ' Solicitar el directorio al usuario una sola vez
            Dim dialogoCarpeta As New FolderBrowserDialog()
            If dialogoCarpeta.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim directorioBase As String = dialogoCarpeta.SelectedPath

                ' Filtrar los datos y generar los reportes
                Dim filasSeleccionadas As DataRow() = dtPersonal.Select("REPORTAR_IMSS = 'TRUE'")
                Dim dtEmpleadosAEnviar As DataTable = dtPersonal.Clone()
                For Each fila As DataRow In filasSeleccionadas
                    dtEmpleadosAEnviar.ImportRow(fila)
                Next

                ModificacionesIMSSPromediosVariables(dtEmpleadosAEnviar, directorioBase)
                btnAplicarCambios.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show("No fue posible generar los reportes, no sera posible aplicar los cambios.", "Error")
        End Try
    End Sub
End Class