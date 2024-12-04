
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.SuperGrid.Style

Public Class frmTimeAllocationConsulta
    Dim dtTimeAllocation As New DataTable
    Dim dtOrdenes As New DataTable
    Dim dtTA As New DataTable
    Dim dtOrdenEmp As New DataTable
    Dim ColumnaInicial As Integer = 10    'En qué número de columna inican las órdenes de trabajo, exceptuando las columnas invisibles
    Dim Fecha As Date

    Private _MyFont As New Font(SystemFonts.StatusFont, FontStyle.Bold)
    Private _BackColor As Background() = {New Background(Color.RoyalBlue), _
                                         New Background(Color.RoyalBlue), _
                                         New Background(Color.RoyalBlue), _
                                         New Background(Color.SteelBlue), _
                                         New Background(Color.Teal), _
                                         New Background(Color.DarkSlateBlue), _
                                         New Background(Color.DarkCyan)}

    Private Sub frmTimeAllocation_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'bgCargaFecha.CancelAsync()
        Me.Dispose()
    End Sub

    Private Sub dgPersonal_ColumnHeaderMouseLeave(sender As Object, e As GridColumnHeaderEventArgs) Handles dgPersonal.ColumnHeaderMouseLeave
        lblTip.Visible = False
        lblTip.Text = ""
    End Sub

    Private Sub UpdateParentDetails(ByVal group As GridGroup, ByVal ColIdx As Integer, ByVal n As Double)
        Try
            If group IsNot Nothing Then
                Dim row As GridRow = TryCast(group.Rows(group.Rows.Count - 1), GridRow)

                If row IsNot Nothing Then
                    Dim cell As GridCell = row.Cells(ColIdx)

                    cell.Value = DtoH(HtoD(cell.Value) + n)

                    ' Recursively update our outer detail rows

                    UpdateParentDetails(TryCast(group.Parent, GridGroup), ColIdx, n)
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim Localizado As Boolean = False
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                dtTemporal = ConsultaPersonalVW("SELECT reloj FROM personalvw WHERE reloj ='" & Reloj & "'" & _
                                                IIf(FiltroXUsuario.Length > 0, " AND " & FiltroXUsuario, "") & " ORDER BY reloj ASC", False)

                If dtTemporal.Rows.Count > 0 Then
                    dgPersonal.PrimaryGrid.ClearSelectedCells()

                    For Each dCell In dgPersonal.PrimaryGrid.FlatRows
                        If Not TypeOf dCell Is GridGroup Then
                            If dCell.Cells("colReloj").Value = Reloj Then
                                dCell.IsSelected = True
                                dCell.ensurevisible(True)
                                Localizado = True
                                Exit For
                            End If
                        End If

                        Debug.Print(dCell.ToString)
                    Next
                End If
                If Not Localizado Then
                    MessageBox.Show("El empleado " & Reloj & " no fue localizado, no cumple con el filtro aplicado, o tiene un nivel al que su usuario no tiene acceso.", "Empleado no localizado", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgPersonal_ColumnHeaderMouseMove(sender As Object, e As GridColumnHeaderMouseEventArgs) Handles dgPersonal.ColumnHeaderMouseMove
        Dim L As Integer
        Dim T As Integer
        Try

            If e.GridColumnHeader.GetHitColumn(e.Location.X, e.Location.Y) Is Nothing Then
                lblTip.Visible = False
                'AsignarHorasOrdenToolStripMenuItem.Visible = False
            ElseIf e.GridColumnHeader.GetHitColumn(e.Location.X, e.Location.Y).Tag Is Nothing Then
                lblTip.Visible = False
                'AsignarHorasOrdenToolStripMenuItem.Visible = False
            Else
                lblTip.Text = e.GridColumnHeader.GetHitColumn(e.Location.X, e.Location.Y).Tag.ToString.Trim
                L = e.Location.X + 15
                T = e.Location.Y + dgPersonal.Top + 15

                If L + lblTip.Width > dgPersonal.Width Then
                    L = dgPersonal.Width - lblTip.Width
                End If
                lblTip.Location = New Point(L, T)

                lblTip.Visible = True
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgPersonal_DataBindingComplete(sender As Object, e As GridDataBindingCompleteEventArgs) Handles dgPersonal.DataBindingComplete
        Try
            Dim gRow As GridRow
            Dim Diferencia As Double
            For Each gRow In dgPersonal.PrimaryGrid.FlatRows
                If IsDBNull(gRow.Cells("colDiferencia").Value) Then
                    Diferencia = 0
                Else
                    Diferencia = HtoD(gRow.Cells("colDiferencia").Value)
                End If

                gRow.Cells("colDiferencia").CellStyles.Default.Background.Color1 = IIf(Diferencia >= 0, SystemColors.ActiveCaption, Color.Red)
                gRow.Cells("colDiferencia").CellStyles.Default.TextColor = IIf(Diferencia >= 0, SystemColors.GrayText, Color.White)
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Function TotalHours(ByVal group As GridGroup, ByVal ColumnIdx As Integer, ByVal detailRow As Boolean) As Double
        Dim n As Double = 0
        Try
            For Each item As GridElement In group.Rows
                If TypeOf item Is GridGroup AndAlso detailRow = False Then
                    n += TotalHours(DirectCast(item, GridGroup), ColumnIdx, True)
                Else

                    Dim row As GridRow = TryCast(item, GridRow)

                    If row IsNot Nothing AndAlso row.Visible = True Then
                        If row.IsDetailRow = detailRow Then
                            If Not IsDBNull(row.Cells(ColumnIdx).Value) Then
                                n += HtoDecimalCompleto(row.Cells(ColumnIdx).Value)
                            End If
                        End If
                    End If
                End If
            Next
            Return n
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.name, ex.HResult, ex.Message)

            Return -1
        End Try
    End Function


    Private Sub dgPersonalGetGroupDetailRows(ByVal sender As Object, ByVal e As GridGetGroupDetailRowsEventArgs) Handles dgPersonal.GetGroupDetailRows
        Dim panel As GridPanel = dgPersonal.PrimaryGrid
        Dim C As Integer = panel.GroupColumns.Count
        Dim B As Integer = _BackColor.Length
        If C > B Then C = B
        Static CColor As Integer = 0
        Try
            If panel.GroupColumns IsNot Nothing Then
                If e.GridGroup.Rows.Count > 0 Then

                    Dim index As Integer = e.GridGroup.Column.ColumnIndex
                    Dim Total As Integer = 0

                    Dim detailRows As New List(Of GridRow)()

                    'Agregar un registro en blanco
                    If TypeOf e.GridGroup.Rows(0) Is GridGroup Then
                        'detailRows.Add(GetNewDetailRow(panel.Columns.Count - 1))
                        CColor += 1
                    Else
                        CColor = C + 1
                    End If

                    If CColor > _BackColor.GetUpperBound(0) Then
                        CColor = 0
                    End If

                    Dim row As GridRow = GetNewDetailRow(panel.Columns.Count - 1)
                    row.RowHeight = 0

                    Total = TotalRegistros(e.GridGroup, False)
                    If Total > 0 Then
                        row.Cells(0).Value = Total
                        row.Cells(0).CellStyles.Default.Alignment = Alignment.MiddleRight

                        row.Cells(1).Value = "Empleados"
                        row.Cells(1).CellStyles.Default.Alignment = Alignment.MiddleLeft

                        For C = ColumnaInicial - 2 To dgPersonal.PrimaryGrid.Columns.Count - 1
                            row.Cells(C).Value = DtoH(TotalHours(e.GridGroup, C, False))
                            row.Cells(C).CellStyles.Default.Alignment = Alignment.MiddleRight
                        Next

                        row.Cells(3).Value = DBNull.Value

                        row.CellStyles.[Default].Font = New Font(SystemFonts.StatusFont, FontStyle.Bold)
                        'Color de fondo, de acuerdo al nivel del grupo
                        row.CellStyles.[Default].Background = _BackColor(index)
                        row.CellStyles.[Default].TextColor = Color.White
                        detailRows.Add(row)
                        'Agregar el registro como "Predetalle", para que aparezca el total antes de iniciar el grupo
                        'este registro se eliminará cuando se remueva el grupo
                        e.PreDetailRows = detailRows
                    End If

                    e.GridGroup.GroupHeaderVisualStyles.[Default].Background = _BackColor(index)
                    e.GridGroup.GroupHeaderVisualStyles.[Default].TextColor = Color.White


                End If
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            'My.Application.DoEvents()
        End Try
    End Sub

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


    Private Sub CopiarClipboard()
        Dim R As Integer
        Dim C As Integer
        Try
            'Tomar el total de renglones y columnas
            R = dgPersonal.PrimaryGrid.Rows.Count
            C = dgPersonal.PrimaryGrid.Columns.Count
            If dgPersonal.PrimaryGrid.SelectedCellCount = R * C Then
                'Si el número de celdas seleccionadas es igual al total de celdas, incluir encabezados
                dgPersonal.PrimaryGrid.CopySelectedCellsToClipboard(True, False)
            Else
                dgPersonal.PrimaryGrid.CopySelectedCellsToClipboard()
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub CopiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiarToolStripMenuItem.Click
        CopiarClipboard()
    End Sub

    Private Sub bgCargaFecha_DoWork()
        Dim Fecha As Date
        Try
            Dim dtPersonalFaltante As New DataTable
            Dim x = 0
            Fecha = txtFecha.Value

            'MCR 28/ENERO/2016
            'Corregir error de ambigüedad de campos en filtro, agregando FiltroXUsuario.Replace("[", "personalVW.[")
            dtOrdenes = sqlExecute("SELECT ordenes_usuario.cod_orden,nombre,prioridad FROM ordenes_usuario LEFT JOIN ordenes_trabajo ON " & _
                                   "ordenes_usuario.cod_orden = ordenes_trabajo.cod_orden WHERE usuario = '" & Usuario & "'" & _
                                   "UNION " & _
                                   "SELECT DISTINCT TIME_ALLOCATION.cod_orden,ORDENES_TRABAJO.nombre,0 FROM time_allocation " & _
                                   "LEFT JOIN ordenes_trabajo ON time_allocation.cod_orden = ordenes_trabajo.cod_orden " & _
                                   "LEFT JOIN personal.dbo.personalVW ON TIME_ALLOCATION.reloj = personalVW.reloj " & _
                                   "WHERE fecha >= '" & FechaSQL(DateAdd(DateInterval.Day, -7, Fecha)) & "' " & _
                                   "AND fecha BETWEEN opening_date AND ISNULL(closing_date,'2099-01-01') " & _
                                   IIf(FiltroXUsuario.Length > 0, " AND " & FiltroXUsuario.Replace("[", "personalVW.["), ""), "TA")
            '*** TEMPORAL PARA PRUEBAS ***
            'dtOrdenes = sqlExecute("SELECT cod_orden,nombre,0 as prioridad FROM ordenes_trabajo")
            '******************************            
            AddHandler dgPersonal.GetGroupDetailRows, AddressOf dgPersonalGetGroupDetailRows


            Dim NewCol As DevComponents.DotNetBar.SuperGrid.GridColumn
            For Each dRow As DataRow In dtOrdenes.Select("", "prioridad")
                '*** TEMPORAL PARA PRUEBAS ***
                'x += 1
                'If x > 10 Then Exit For
                '******************************

                If IsNothing(dgPersonal.PrimaryGrid.Columns("col" & dRow("cod_orden").ToString.Trim)) Then
                    'Agregar la columna al grid
                    NewCol = New GridColumn
                    'NewCol.EditorType = GetType(GridDoubleInputEditControl)
                    NewCol.Name = "col" & dRow("cod_orden").ToString.Trim
                    NewCol.HeaderText = dRow("cod_orden").ToString.Trim
                    NewCol.DataPropertyName = dRow("cod_orden").ToString.Trim
                    NewCol.CellStyles.Default.Alignment = Alignment.MiddleRight
                    NewCol.CellStyles.Default.Padding.Right = 10
                    NewCol.CellStyles.Default.Padding.Left = 5
                    NewCol.CellStyles.Selected.Font = New Font("Microsoft SansSerif", 8, FontStyle.Bold)
                    NewCol.CellStyles.Selected.Background.Color1 = SystemColors.Highlight
                    NewCol.CellStyles.Selected.TextColor = SystemColors.HighlightText
                    NewCol.CellStyles.MouseOver.Background.Color1 = SystemColors.Highlight
                    NewCol.CellStyles.MouseOver.TextColor = SystemColors.HighlightText
                    NewCol.CellStyles.SelectedMouseOver.Background.Color1 = SystemColors.Highlight
                    NewCol.CellStyles.SelectedMouseOver.TextColor = SystemColors.HighlightText
                    NewCol.EnableFiltering = Tbool.False
                    NewCol.GroupBoxEffects = GroupBoxEffects.None
                    NewCol.Width = 75
                    NewCol.Tag = dRow("nombre").ToString.Trim
                    dgPersonal.PrimaryGrid.Columns.Add(NewCol)
                End If
            Next
            My.Application.DoEvents()

            dtTimeAllocation = sqlExecute("EXEC EstructuraTimeAllocation " & NivelConsulta & ",'" & FechaSQL(Fecha) & "'," & _
                                          "'alta <= ''" & FechaSQL(Fecha) & "'' AND (baja IS NULL OR baja>''" & FechaSQL(Fecha) & "'')" & _
                                          IIf(FiltroXUsuario.Length = 0, "", " AND " & FiltroXUsuario.Replace("'", "''").Replace("[", "PERSONALVW.[")) & "'", "TA")

            dtPersonalFaltante = sqlExecute("SELECT PERSONALVW.*,HORAS_NORMALES,HORAS_EXTRAS FROM PERSONALVW RIGHT JOIN " & _
                                            "(SELECT reloj as rl, TA.dbo.DTOH(SUM(ta.DBO.HTOD(HORAS_NORMALES))) AS  horas_normales, " & _
                                            "TA.dbo.DTOH(SUM(ta.DBO.HTOD(horas_extras))) AS HORAS_EXTRAS " & _
                                            "FROM TA.DBO.ASIST WHERE FHA_ENT_HOR = '" & FechaSQL(Fecha) & "' GROUP BY reloj) as Xl " & _
                                            "ON PersonalVW.RELOJ = Xl.rl " & _
                                            " WHERE nivel_seguridad<=" & NivelConsulta & " AND " & _
                                            "alta <= '" & FechaSQL(Fecha) & "' AND (baja IS NULL OR baja>'" & FechaSQL(Fecha) & "')" & _
                                            " AND (horas_normales<> '00:00' OR horas_extras <> '00:00') " & _
                                            IIf(FiltroXUsuario.Length = 0, "", " AND " & FiltroXUsuario.Replace("[", "personalvw.[")) & " AND " & _
                                            "personalvw.reloj NOT IN (SELECT DISTINCT reloj FROM ta.dbo.time_allocation WHERE fecha = '" & FechaSQL(Fecha) & "')")

            For Each dRow As DataRow In dtPersonalFaltante.Rows
                dtTimeAllocation.ImportRow(dRow)
            Next

            Dim Total As Double

            dtTimeAllocation.Columns.Add("diferencia")

            pbAvance.IsRunning = False
            pbAvance.Value = 0
            pbAvance.Maximum = dtTimeAllocation.Rows.Count
            For Each dRow As DataRow In dtTimeAllocation.Rows
                lblAvance.Text = "... PREPARANDO ..." & vbCrLf & dRow("reloj")
                pbAvance.Value += 1
                My.Application.DoEvents()

                Total = HtoDecimalCompleto(IIf(IsDBNull(dRow("total")), "00:00", dRow("total")))
                dRow("diferencia") = DtoH((HtoD(IIf(IsDBNull(dRow("horas_normales")), "00:00", dRow("horas_normales"))) + _
                                           HtoD(IIf(IsDBNull(dRow("horas_extras")), "00:00", dRow("horas_extras")))) - Total)
            Next
            pbAvance.IsRunning = True
            lblAvance.Text = " TOTALIZANDO " & vbCrLf & " - GRUPOS -"
            My.Application.DoEvents()

            dgPersonal.PrimaryGrid.DataSource = dtTimeAllocation

            If dtTimeAllocation.Rows.Count < 150 Then
                dgPersonal.PrimaryGrid.SetGroup({dgPersonal.PrimaryGrid.Columns("colCodDepto"), dgPersonal.PrimaryGrid.Columns("colCodTurno")})
                'Else
                'dgPersonal.PrimaryGrid.SetGroup({dgPersonal.PrimaryGrid.Columns("colCodSuper")})
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub bgCargaFecha_RunWorkerCompleted()
        gpAvance.Visible = False
        pbAvance.IsRunning = False
        'MCR 4/NOV/2015
        'Mostrar fecha/hora de la última vez que se actualizó la información en pantalla
        lblUltActualizacion.Text = "Información actualizada al: " & Now.ToString
        My.Application.DoEvents()
    End Sub

    Private Sub frmTimeAllocation_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        gpAvance.Left = (Me.Width - gpAvance.Width) / 2
        pnlCentrarControles.Left = (Me.Width - pnlCentrarControles.Width) / 2

    End Sub

    Private Sub frmTimeAllocation_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        btnMostrarInformacion.PerformClick()
    End Sub

    Private Sub btnMostrarInformacion_Click(sender As Object, e As EventArgs) Handles btnMostrarInformacion.Click
        gpAvance.Visible = True
        pbAvance.IsRunning = True
        lblAvance.Text = "Preparando información"

        bgCargaFecha_DoWork()
        bgCargaFecha_RunWorkerCompleted()

    End Sub


    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try
            Dim dtCompanias As New DataTable
            Dim x As Integer
            Dim Relojes As String = ""
            For Each dRow As DataRow In dtTimeAllocation.Rows
                Relojes = Relojes & IIf(Relojes.Length = 0, "", ",") & "'" & dRow("reloj").ToString.Trim & "'"
            Next

            Dim dtDatos As New DataTable
            'dtDatos = sqlExecute("SELECT time_allocation.*,ordenes_trabajo.nombre AS nombre_orden," & _
            '                     "RTRIM(personal.nombre) + ' ' + RTRIM(apaterno) + ' ' + RTRIM(amaterno) as nombres," & _
            '                     "deptos.nombre AS nombre_depto,centro_costos,super.nombre AS nombre_super," & _
            '                     "ROUND(CAST(SUBSTRING(case ISNULL(horas_normales,'00:00') when '**.**' then '00:00' when '**:**' then '00:00' else horas_normales end,1,2)  AS FLOAT) + " & _
            '                     "CAST(SUBSTRING(case ISNULL(horas_normales,'00:00') when '**.**' then '00:00' when '**:**' then '00:00' else horas_normales end,4,2)  AS FLOAT)/60,2) + " & _
            '                     "ROUND(CAST(SUBSTRING(case ISNULL(horas_extras,'00:00') when '**.**' then '00:00' when '**:**' then '00:00' else horas_extras end,1,2)  AS FLOAT) + " & _
            '                     "CAST(SUBSTRING(case ISNULL(horas_extras,'00:00') when '**.**' then '00:00' when '**:**' then '00:00' else horas_extras end,4,2)  AS FLOAT)/60,2) as trabajadas , " & _
            '                     "asist.cod_comp,asist.cod_depto,asist.cod_super,(time_allocation.horas) as asignadas " & _
            '                     "FROM ta.dbo.time_allocation " & _
            '                     "LEFT JOIN ta.dbo.asist ON time_allocation.reloj = asist.reloj AND time_allocation.fecha= asist.fha_ent_hor " & _
            '                     "LEFT JOIN ta.dbo.ordenes_trabajo ON ordenes_trabajo.cod_orden = time_allocation.cod_orden " & _
            '                     "LEFT JOIN personal.dbo.personal ON time_allocation.reloj = personal.reloj " & _
            '                     "LEFT JOIN personal.dbo.deptos ON asist.cod_comp = deptos.cod_comp and asist.cod_depto = deptos.COD_DEPTO  " & _
            '                     "LEFT JOIN personal.dbo.super ON asist.cod_comp = super.cod_comp and asist.cod_super = super.cod_super " & _
            '                     "WHERE time_allocation.reloj IN (" & Relojes & ") AND time_allocation.fecha = '" & FechaSQL(txtFecha.Value) & "'", "TA")

            EncabezadoReporte = FechaMediaLetra(txtFecha.Value)
            dtDatos = sqlExecute("SELECT * FROM timeAllocationVW WHERE reloj IN (" & Relojes & ") AND fecha = '" & FechaSQL(txtFecha.Value) & "'", "TA")

            If dtDatos.Rows.Count > 0 Then
                frmVistaPrevia.LlamarReporte("Reporte de time allocation", dtDatos, dtDatos.Rows(0).Item("cod_comp"))
            Else
                dtCompanias = sqlExecute("SELECT cod_comp FROM cias WHERE cia_default = 1")
                frmVistaPrevia.LlamarReporte("Reporte de time allocation", dtDatos, dtCompanias.Rows(x).Item(0))

            End If
            frmVistaPrevia.ShowDialog()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnArchivoSAP_Click(sender As Object, e As EventArgs) Handles btnArchivoSAP.Click
        GeneraArchivoSAP(Me)
    End Sub

    Public Function HtoDecimalCompleto(Hora As String) As Double
        Try
            Dim H As Integer
            Dim M As Integer
            Dim _negativo As Boolean = False
            'En caso de que no ocupe 5 espacios, forzarlo
            If Microsoft.VisualBasic.Strings.Left(Hora, 1) = "-" Then
                _negativo = True
                Hora = Hora.Replace("-", "")
            End If
            Hora = Hora.PadLeft(5, "0")
            H = Val(Hora.Substring(0, 3))
            M = Val(Hora.Substring(3, Hora.Length - 3))
            Return (H + (M / 60)) * IIf(_negativo, -1, 1)
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Private Sub frmTimeAllocationConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'MCR 20/Ene/2016
        'Iniciar con la fecha más reciente que tenga en time_allocation
        dtTemporal = sqlExecute("SELECT MAX(fecha) FROM time_allocation", "TA")
        If dtTemporal.Rows.Count > 0 Then
            Fecha = dtTemporal.Rows(0)(0)
        Else
            Fecha = Now
        End If
        txtFecha.ValueObject = Fecha
    End Sub

    Private Sub txtFecha_Leave(sender As Object, e As EventArgs) Handles txtFecha.Leave
        btnMostrarInformacion.PerformClick()
    End Sub

End Class
