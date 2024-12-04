Imports System.IO
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.SuperGrid.Style

Public Class frmConsultaMaestro

    Dim dtPersonal As New DataTable
    Dim ColumnaSeleccionada As Integer = -1
    Private _BackColor As Background() = {New Background(Color.FromArgb(23, 54, 93)), _
                                          New Background(Color.FromArgb(69, 98, 135)), _
                                          New Background(Color.FromArgb(0, 114, 188)), _
                                          New Background(Color.FromArgb(78, 93, 48)), _
                                          New Background(Color.FromArgb(37, 86, 99)), _
                                          New Background(Color.FromArgb(122, 78, 43)), _
                                          New Background(Color.FromArgb(96, 40, 38)), _
                                          New Background(Color.FromArgb(0, 129, 68)), _
                                          New Background(Color.FromArgb(0, 129, 129)), _
                                          New Background(Color.FromArgb(129, 0, 61))}

    Private Sub frmConsultaMaestro_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        pbAvance.IsRunning = False
        If bckCarga.IsBusy Then
            bckCarga.CancelAsync()
        End If
        Me.Dispose()
    End Sub

    Private Sub frmConsultaMaestro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'MCR 26/OCT/2015
            'Utilizar BackGroundWorker para que, al abrir, sea más claro que está trabajando, no atorado
            pnlCentrado.Enabled = False
            dgMaestro.Enabled = False
            gpAvance.Visible = True
            pbAvance.IsRunning = True

            bckCarga.RunWorkerAsync()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

#Region "GetNewDetailRow"

    Private Function GetNewDetailRow(ByVal i As Integer) As GridRow
        Try

            Dim row As New GridRow()
            'Agregar al registro de detalle tantas columnas como tenga el grid
            For x As Integer = 0 To i
                row.Cells.Add(New DevComponents.DotNetBar.SuperGrid.GridCell)
                row.Cells(x).EditorType = GetType(GridTextBoxXEditControl)
            Next
            row.[ReadOnly] = True
            Return row

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return New GridRow()
        End Try
    End Function

#End Region

#Region "TotalRegistros"

    Private Function TotalRegistros(ByVal group As GridGroup, ByVal detailRow As Boolean) As Integer
        Try
            Dim n As Integer = 0

            For Each item As GridElement In group.Rows
                If TypeOf item Is GridGroup AndAlso detailRow = False Then
                    'Suma recursiva dentro del subgrupo
                    'se resta 1, para no contar el registro de detalle dentro del subgrupo
                    n += TotalRegistros(DirectCast(item, GridGroup), True) - 1
                Else
                    Dim row As GridRow = TryCast(item, GridRow)
                    If row IsNot Nothing AndAlso row.Visible = True Then
                        'If row.IsDetailRow = detailRow Then
                        n += 1
                        'End If
                    End If
                End If
            Next
            Return (n)
        Catch ex As Exception
            Return -1
        End Try
    End Function

#End Region

    Private Sub CopiarClipboard()
        Dim R As Integer
        Dim C As Integer
        Try
            'Tomar el total de renglones y columnas
            R = dgMaestro.PrimaryGrid.Rows.Count
            C = dgMaestro.PrimaryGrid.Columns.Count
            If dgMaestro.PrimaryGrid.SelectedCellCount = R * C Then
                'Si el número de celdas seleccionadas es igual al total de celdas, incluir encabezados
                dgMaestro.PrimaryGrid.CopySelectedCellsToClipboard(True, False)
            Else
                dgMaestro.PrimaryGrid.CopySelectedCellsToClipboard()
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub CopiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuCopiar.Click
        CopiarClipboard()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        Try
            Dim d As Double
            Dim Archivo As String = ""

            dlgArchivo.FileName = ""
            ' dlgArchivo.Filter = "Archivos excel|*.xls;*.xlsx|Todos los archivos (*.*)|*.*"
            dlgArchivo.Filter = "Archivos excel|*.xlsx"

            Dim lDialogResult As DialogResult = dlgArchivo.ShowDialog()

            If lDialogResult = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            Else
                Archivo = dlgArchivo.FileName
            End If

            d = dtPersonal.Rows.Count
            d = dgMaestro.PrimaryGrid.Rows.Count
            'Variable F se inicializa a 1=1, para que siempre sea verdadero, y no interfiera con el filtro
            Dim F As String = "1=1"
            Dim O As String = ""
            Me.Cursor = Cursors.WaitCursor

            For Each c As DevComponents.DotNetBar.SuperGrid.GridColumn In dgMaestro.PrimaryGrid.Columns
                If Not IsNothing(c.FilterExpr) Then
                    If c.FilterExpr.ToUpper.Contains(c.DataPropertyName.ToUpper) Then
                        F = F & " AND " & c.FilterExpr
                    Else
                        'F = F & " AND " & c.DataPropertyName & c.FilterExpr
                        Try
                            F = F & " AND " & c.FilterExpr.Substring(0, c.FilterExpr.IndexOf("[")) & c.DataPropertyName.ToUpper & c.FilterExpr.Substring(c.FilterExpr.IndexOf("]"))
                        Catch ex As Exception

                        End Try

                    End If
                End If
                If c.IsSortColumn Then
                    O = O & IIf(O.Length = 0, "", ",") & c.DataPropertyName & " " & IIf(c.SortDirection = SortDirection.Ascending, "ASC", "DESC")
                End If
            Next
            F = F.Replace("[", "")
            F = F.Replace("]", "")
            F = F.Replace("*", "%")
            F = F.Replace(Chr(34), "'")
            F = F.ToUpper.Replace(" = NULL", " IS NULL")
            F = F.ToUpper.Replace(" != NULL", " IS NOT NULL")

            Dim dtResultadoFiltro As New DataSet
            dtResultadoFiltro.Merge(dtPersonal.Select(F, O))

            If dtResultadoFiltro.Tables.Count = 0 Then
                dtFiltroPersonal = New DataTable
            Else
                dtFiltroPersonal = dtResultadoFiltro.Tables(0)
                dtResultadoFiltro.Tables(0).TableName = "Filtro"
            End If

            For Each c As DevComponents.DotNetBar.SuperGrid.GridColumn In dgMaestro.PrimaryGrid.Columns
                If Not c.Visible Then
                    dtFiltroPersonal.Columns.Remove(c.DataPropertyName)
                End If
            Next

            ExportaExcel(DataTableTORecordset(dtFiltroPersonal), Archivo, True)

        Catch ex As Exception
            MessageBox.Show("El reporte no puede ser generado, debido a que se detectaron errores." & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dgMaestro_CellDoubleClick(sender As Object, e As GridCellDoubleClickEventArgs) Handles dgMaestro.CellDoubleClick
        Dim i As Integer = e.GridCell.RowIndex
        ConsultaReloj = dgMaestro.PrimaryGrid.GridPanel.GetCell(i, 0).Value
        Try

            'On Error Resume Next
            frmMaestro.MdiParent = frmMain
            frmMaestro.WindowState = FormWindowState.Maximized
            frmMaestro.Show()
            ConsultaReloj = dgMaestro.PrimaryGrid.GridPanel.GetCell(i, 0).Value
            frmMaestro.Focus()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub dgMaestro_Click(sender As Object, e As EventArgs) Handles dgMaestro.Click

    End Sub

    Private Sub dgMaestro_ColumnHeaderClick(sender As Object, e As GridColumnHeaderClickEventArgs) Handles dgMaestro.ColumnHeaderClick
        ColumnaSeleccionada = e.GridColumn.ColumnIndex

    End Sub

    Private Sub dgMaestro_GetGroupDetailRows(sender As Object, e As GridGetGroupDetailRowsEventArgs) Handles dgMaestro.GetGroupDetailRows
        Dim panel As GridPanel = dgMaestro.PrimaryGrid
        Dim C As Integer = panel.GroupColumns.Count
        Dim B As Integer = _BackColor.Length
        If C > B Then C = B
        Static CColor As Integer = C - 1
        Try
            If panel.GroupColumns IsNot Nothing Then
                If e.GridGroup.Rows.Count > 0 Then
                    Dim index As Integer = e.GridGroup.Column.ColumnIndex
                    Dim Total As Integer = 0

                    Dim detailRows As New List(Of GridRow)()

                    'Agregar un registro en blanco
                    If TypeOf e.GridGroup.Rows(0) Is GridGroup Then
                        detailRows.Add(GetNewDetailRow(panel.Columns.Count - 1))
                        CColor -= 1
                    Else
                        CColor = C - 1
                    End If

                    If CColor < 0 Then
                        CColor = C - 1
                    End If
                    Dim row As GridRow = GetNewDetailRow(panel.Columns.Count - 1)
                    row.RowHeight = 0

                    row.Cells(0).Value = ""
                    row.Cells(1).Value = "TOTAL " & e.GridGroup.Column.Name.ToString & vbCrLf & Convert.ToString(e.GridGroup.GroupValue).Trim
                    row.Cells(1).CellStyles.Default.Alignment = Alignment.TopLeft
                    row.Cells(1).CellStyles.Default.AllowWrap = Tbool.True
                    row.Cells(2).Value = TotalRegistros(e.GridGroup, False)
                    row.Cells(2).CellStyles.Default.Alignment = Alignment.MiddleRight
                    row.Cells(3).Value = DBNull.Value

                    row.CellStyles.[Default].Font = New Font(SystemFonts.StatusFont, FontStyle.Bold)
                    'Color de fondo, de acuerdo al nivel del grupo
                    row.CellStyles.[Default].Background = _BackColor(CColor)
                    row.CellStyles.[Default].TextColor = System.Drawing.SystemColors.HighlightText
                    detailRows.Add(row)
                    'Agregar el registro como "Predetalle", para que aparezca el total antes de iniciar el grupo
                    'este registro se eliminará cuando se remueva el grupo
                    e.PreDetailRows = detailRows
                End If
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub pnlTitulo_Paint(sender As Object, e As PaintEventArgs) Handles pnlTitulo.Paint

    End Sub

    Private Sub mnuOcultar_Click(sender As Object, e As EventArgs) Handles mnuOcultar.Click
        If ColumnaSeleccionada = -1 Then
            For Each c As DevComponents.DotNetBar.SuperGrid.GridCell In dgMaestro.PrimaryGrid.SelectedCells
                c.GridColumn.Visible = False
            Next
        Else
            dgMaestro.PrimaryGrid.Columns(ColumnaSeleccionada).Visible = False
        End If
        ColumnaSeleccionada = -1
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try
            Dim Par As OrdenFiltro
            Dim dtResultadoFiltro As New DataSet
            Par = CadenaFiltro(dtPersonal, dgMaestro)
            dtResultadoFiltro.Merge(dtPersonal.Select(Par.Filtro, Par.Orden))

            If dtResultadoFiltro.Tables.Count = 0 Then
                dtFiltroPersonal = New DataTable
            Else
                dtFiltroPersonal = dtResultadoFiltro.Tables(0)
                dtResultadoFiltro.Tables(0).TableName = "Filtro"
            End If
            frmVistaPrevia.LlamarReporte("Reporte numérico", dtFiltroPersonal)
            frmVistaPrevia.Show()

        Catch ex As Exception
            MessageBox.Show("El reporte no puede ser generado, debido a que se detectaron errores." & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        dgMaestro.PrimaryGrid.FilterExpr = Nothing
        For Each column As GridColumn In dgMaestro.PrimaryGrid.Columns
            column.FilterExpr = Nothing
        Next column
    End Sub

    Private Sub ReflectionLabel1_Click(sender As Object, e As EventArgs) Handles ReflectionLabel1.Click

    End Sub

    Private Sub MostrarTodasLasColumnasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MostrarTodasLasColumnasToolStripMenuItem.Click
        For Each c As DevComponents.DotNetBar.SuperGrid.GridColumn In dgMaestro.PrimaryGrid.Columns
            If Array.IndexOf(New String() {"IMSS", "RFC"}, c.Name) = -1 Then
                c.Visible = True
            End If
        Next

    End Sub

    Private Sub dgMaestro_Paint(sender As Object, e As PaintEventArgs) Handles dgMaestro.Paint
        Try
            Dim Par As OrdenFiltro
            Par = CadenaFiltro(dtPersonal, dgMaestro)
            lblCuantos.Text = dtPersonal.Select(Par.Filtro).Count & " empleados"
        Catch ex As Exception
            lblCuantos.Text = "Error"
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub pnlControles_Paint(sender As Object, e As PaintEventArgs) Handles pnlControles.Paint

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmConsultaMaestro_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        pnlCentrado.Left = (Me.Width - pnlCentrado.Width) / 2
        gpAvance.Left = (Me.Width - gpAvance.Width) / 2
    End Sub

    Private Sub bckCarga_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bckCarga.DoWork
        Dim M As Integer
        Dim P As Integer
        Dim x As Integer
        Dim N As String = ""
        Dim c As System.Data.DataColumn
        Dim dtDatosPersonal As New DataTable
        Try

            'Debe haber al menos un auxiliar a mostrar en pantalla (aunque no se use), para que el query no regrese en blanco
            'La estructura de ConsultaPersonalFILTROS indica los campos que aparecen en el grid
            Dim QC As String = "EXEC ConsultaPersonalFILTROS @nivel = '" & NivelConsulta & "',@nivelSueldo = '" & NivelSueldos & "',@reloj = ''"

            '==Modificado para que pueda consultar información de la 2da empresa wme            25/nov/2021             Ernesto
            ' dtDatosPersonal = sqlExecute(QC, "personal", 2)
            dtDatosPersonal = sqlExecute(QC, "personal")

            '== Para una empresa (Comentado)            26nov2021
            'dtDatosPersonal = sqlExecute(QC)

            'dtDatosPersonal = sqlExecute(query)

            '*******************************************************DIAS VACACIONES**************************************************************************************
            '===== Se agrega al HeadCount los dias de vacaciones ganados [último aniversario] y saldo actual a petición de Miriam WME - 06/ene/2023
            '===== Se desactiva temporalmente que no se muestre el saldo de vacaciones  2024-04-03
            'Dim dtSaldosVac = sqlExecute("select sv.reloj, " &
            '                             "case when SUM(CAST(sv.dias as int)) is null then 0 else SUM(CAST(sv.dias as int)) end as dias_ganados, " &
            '                             "case when SUM(CAST(tiempo as int)) is null then 0 else SUM(CAST(tiempo as int)) end as dias_tomados, " &
            '                             "(SELECT TOP 1 DIAS FROM saldos_vacaciones WHERE COMENTARIO LIKE 'ANIVERSARIO %' and RELOJ=sv.RELOJ ORDER BY COMENTARIO DESC) as VAC_DIAS_ANIVERSARIO, " &
            '                             "0.0 as VAC_SALDO_ACTUAL " &
            '                             "from personal.dbo.saldos_vacaciones sv " &
            '                             "left join personal.dbo.personalvw p on sv.RELOJ=p.reloj " &
            '                             "group by sv.RELOJ " &
            '                             "order by sv.RELOJ asc")

            'If dtSaldosVac.Rows.Count > 0 Then
            '    For Each drow In dtSaldosVac.Rows : drow("VAC_SALDO_ACTUAL") = Math.Round(drow("dias_ganados") - drow("dias_tomados") + VacacionesDevengadas(drow("reloj").ToString.Trim, Now.Date), 2)
            '    Next

            '    '== Agregar columnas a HD
            '    dtDatosPersonal.Columns.Add("VACACIONES_DIAS_ANIVERSARIO", System.Type.GetType("System.Int32"))
            '    dtDatosPersonal.Columns.Add("VACACIONES_SALDO_ACTUAL", System.Type.GetType("System.Double"))

            '    For Each saldos In dtSaldosVac.Rows
            '        For Each per In dtDatosPersonal.Select("reloj='" & saldos("reloj").ToString.Trim & "'")
            '            per("VACACIONES_DIAS_ANIVERSARIO") = saldos("VAC_DIAS_ANIVERSARIO")
            '            per("VACACIONES_SALDO_ACTUAL") = saldos("VAC_SALDO_ACTUAL")
            '        Next
            '    Next
            'End If
            '================================================================= END: Mostrar dias de vacaciones =================================================================

            dtPersonal = dtDatosPersonal.Clone
            For Each dRow As DataRow In dtDatosPersonal.Select(FiltroXUsuario)
                dtPersonal.ImportRow(dRow)
            Next

            P = dtPersonal.Columns.Count
            M = dgMaestro.PrimaryGrid.Columns.Count
            dgMaestro.PrimaryGrid.FilterMatchType = FilterMatchType.None

            For x = M To P - 1
                'Agregar las columnas que no estén ya en el DataGrid
                'dando el formato y características necesarias
                c = dtPersonal.Columns(x)
                Dim grdCol As DevComponents.DotNetBar.SuperGrid.GridColumn = New DevComponents.DotNetBar.SuperGrid.GridColumn()
                N = c.ColumnName.ToUpper
                N = N.Replace("COD", "CÓD.")
                N = N.Replace("_", " ")
                N = N.Replace("COMPANIA", "COMPAÑÍA")

                grdCol.Name = N
                grdCol.DataPropertyName = c.ColumnName
                grdCol.HeaderStyles.Default.AllowWrap = Tbool.True
                grdCol.Width = IIf(N.Contains("CÓD."), 50, 130)
                'grdCol.AutoSizeMode = ColumnAutoSizeMode.DisplayedCellsExceptHeader
                'grdCol.FilterMatchType = FilterMatchType.Wildcards
                grdCol.FilterAutoScan = True
                grdCol.FilterPopupMaxItems = dtPersonal.Rows.Count / 3

                '-- AOS : Para no mostrar los campos que no se deseen mostrar en el GRID
                If (N = "001") Then
                    grdCol.Visible = False
                End If
                '--- AOS: Ends
                dgMaestro.PrimaryGrid.Columns.Add(grdCol)
            Next
            dgMaestro.PrimaryGrid.ReadOnly = False
            My.Application.DoEvents()
        Catch ex As Exception
            MessageBox.Show("La información no fue cargada correctamente. Se recomienda cerrar y volver a abrir. Si el problema persiste, contacte al administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub bckCarga_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bckCarga.RunWorkerCompleted
        Try
            dgMaestro.PrimaryGrid.DataSource = dtPersonal
            My.Application.DoEvents()
            dgMaestro.Refresh()

            pbAvance.IsRunning = False
            gpAvance.Visible = False
            dgMaestro.Enabled = True
            pnlCentrado.Enabled = True
        Catch ex As Exception
            MessageBox.Show("La información no fue cargada correctamente. Se recomienda cerrar y volver a abrir. Si el problema persiste, contacte al administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
End Class