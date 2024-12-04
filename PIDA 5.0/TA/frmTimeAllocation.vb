
Imports DevComponents.DotNetBar.SuperGrid
Imports DevComponents.DotNetBar.SuperGrid.Style

Public Class frmTimeAllocation
    Dim Cargando As Boolean = True

    Dim NodoCentroCostos As DevComponents.AdvTree.Node
    Dim NodoTurno As DevComponents.AdvTree.Node
    Dim NodoDepto As DevComponents.AdvTree.Node    
    Dim TipoNodo As String


    Dim Filtro2Talloc As String = ""

    Dim OV As Double
    Dim NV As Double
    Dim AntNode As DevComponents.AdvTree.Node

    Dim FechaCorte As Date
    Dim dtTimeAllocation As New DataTable
    Dim dtOrdenes As New DataTable
    Dim dtTA As New DataTable
    Dim dtOrdenEmp As New DataTable
    Dim ColumnaInicial As Integer = 9    'En qué número de columna inican las órdenes de trabajo, exceptuando las columnas invisibles
    Dim Fecha As Date

    Dim dtGruposTAlloc As New DataTable

    Private _MyFont As New Font(SystemFonts.StatusFont, FontStyle.Bold)
    Private _BackColor As Background() = {New Background(Color.SteelBlue), _
            New Background(Color.CornflowerBlue), New Background(Color.RoyalBlue)}

    Private Sub txtFecha_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtFecha.Validating
        AntNode = Nothing
        btnMostrarInformacion.PerformClick()
    End Sub

    Private Sub frmTimeAllocation_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmTimeAllocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try

            Filtro2Talloc = FiltroXUsuario
            Dim dtFiltro2 As DataTable = sqlExecute("select isnull(filtro2, '') as filtro2 from seguridad.dbo.appuser where username = '" & Usuario & "'")
            If dtFiltro2.Rows.Count Then
                If dtFiltro2.Rows(0)("filtro2").ToString.Trim <> "" Then
                    Filtro2Talloc = dtFiltro2.Rows(0)("filtro2").ToString.Trim
                End If
            End If

            treGrupos.Nodes.Clear()
            dgPersonal.PrimaryGrid.DataSource = Nothing

            dtGruposTAlloc.Columns.Add("centro_costos")
            dtGruposTAlloc.Columns.Add("cod_depto")
            dtGruposTAlloc.Columns.Add("cod_super")
            dtGruposTAlloc.Columns.Add("cod_turno")
            dtGruposTAlloc.Columns.Add("orden")
            dtGruposTAlloc.Columns.Add("horas", GetType(System.Double))
            dtGruposTAlloc.Columns.Add("empleados", GetType(System.Double))

            'bgCargaFecha.WorkerSupportsCancellation = True
            'MCR 20/Ene/2016
            'Cambio de orden a grupo, en lugar de CC-Depto-Turno, será CC-Turno-Depto
            dtGruposTAlloc.PrimaryKey = New DataColumn() {dtGruposTAlloc.Columns("centro_costos"), dtGruposTAlloc.Columns("cod_turno"), _
                                                          dtGruposTAlloc.Columns("cod_depto"), dtGruposTAlloc.Columns("cod_super"), dtGruposTAlloc.Columns("orden")}
            dgPersonal.PrimaryGrid.Columns("colCodDepto").DeactivateFilterPopup()

            'MCR 20/Ene/2016
            'Iniciar con la fecha más reciente que tenga en time_allocation
            dtTemporal = sqlExecute("SELECT MAX(fecha) FROM time_allocation", "TA")
            If dtTemporal.Rows.Count > 0 Then
                Fecha = dtTemporal.Rows(0)(0)
            Else
                Fecha = Now
            End If
            txtFecha.ValueObject = Fecha
            'btnMostrarInformacion.PerformClick()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgPersonal_ColumnHeaderMouseLeave(sender As Object, e As GridColumnHeaderEventArgs) Handles dgPersonal.ColumnHeaderMouseLeave
        lblTip.Visible = False
        lblTip.Text = ""
    End Sub

    Private Sub dgPersonal_ColumnHeaderMouseMove(sender As Object, e As GridColumnHeaderMouseEventArgs) Handles dgPersonal.ColumnHeaderMouseMove
        Dim L As Integer
        Dim T As Integer
        Dim Orden As String
        Try

            If e.GridColumnHeader.GetHitColumn(e.Location.X, e.Location.Y) Is Nothing Then
                lblTip.Visible = False
            ElseIf e.GridColumnHeader.GetHitColumn(e.Location.X, e.Location.Y).Tag Is Nothing Then
                lblTip.Visible = False
            Else
                Orden = e.GridColumnHeader.GetHitColumn(e.Location.X, e.Location.Y).HeaderText
                AsignarHorasOrdenToolStripMenuItem.Tag = Orden
                AsignarHorasOrdenToolStripMenuItem.Text = "Asignar " & txtHoras.Text & IIf(txtHoras.Text = "01:00", " hora ", " horas ") & _
                    ", para orden " & Orden
                AsignarHorasOrdenToolStripMenuItem.Visible = True

                AsignarHorasEmpleadoToolStripMenuItem.Visible = False

                BorrarOrdenDeTrabajoToolStripMenuItem.Text = "Borrar orden " & Orden
                BorrarOrdenDeTrabajoToolStripMenuItem.Tag = Orden


                lblTip.Text = e.GridColumnHeader.GetHitColumn(e.Location.X, e.Location.Y).Tag.ToString.Trim
                L = e.Location.X + 15 + dgPersonal.Left
                T = e.Location.Y + dgPersonal.Top + 15

                If L + lblTip.Width > dgPersonal.Width + dgPersonal.Left Then
                    L = dgPersonal.Width - lblTip.Width + dgPersonal.Left
                End If
                lblTip.Location = New Point(L, T)

                lblTip.Visible = True
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgPersonal_EndEdit(sender As Object, e As GridEditEventArgs) Handles dgPersonal.EndEdit
        '            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), me.name, ex.HResult, ex.Message)
        Dim c As Integer
        Dim Total As Double
        Dim Diferencia As Double
        Dim gRow As GridRow
        Dim Reloj As String
        Dim Orden As String
        Dim Horas As Double

        Dim dtAsist As New DataTable
        Dim dtBitacora As New DataTable
        Dim dRAsist As DataRow

        Try
            If e.GridCell.Value Is Nothing Then Exit Sub
            If dgPersonal.ActiveCell.AllowEdit And Not IsDBNull(e.GridCell.Value) Then
                e.GridCell.Value = MerMilitar(CtoM(e.GridCell.Value))

                gRow = e.GridCell.GridRow
                Total = 0
                'AQUI ES PORQUE HAY 10 COLUMNAS FIJAS
                For c = 10 To gRow.Cells.Count - 1                    
                    If Not gRow.Cells(c) Is Nothing Then
                        If Not IsDBNull(gRow.Cells(c).Value) Then                            
                            Total = Total + IIf(gRow.Cells(c).Value = "**:**", 0, HtoDecimalCompleto(gRow.Cells(c).Value))
                        End If
                    End If                    
                Next

                Diferencia = (HtoDecimalCompleto(gRow.Cells("colHrsNormales").Value) + HtoDecimalCompleto(gRow.Cells("colHrsExtras").Value)) - Total
                If Math.Round(Diferencia, 2) < 0 Then
                    Diferencia = 0
                    Total = (HtoDecimalCompleto(gRow.Cells("colHrsNormales").Value) + HtoDecimalCompleto(gRow.Cells("colHrsExtras").Value)) - (Total - HtoDecimalCompleto(e.GridCell.Value))
                    Total = IIf(Total < 0, 0, Total)
                    e.GridCell.Value = DtoH(Total)
                    Total = (HtoDecimalCompleto(gRow.Cells("colHrsNormales").Value) + HtoDecimalCompleto(gRow.Cells("colHrsExtras").Value))

                End If

                gRow.Cells("colTotalHrs").Value = DtoH(Total)
                gRow.Cells("colDiferencia").Value = DtoH(Diferencia)
                gRow.Cells("colDiferencia").CellStyles.Default.Background.Color1 = IIf(Diferencia = 0, Color.Green, IIf(Diferencia > 0, SystemColors.GradientInactiveCaption, Color.Red))
                gRow.Cells("colDiferencia").CellStyles.ReadOnly.TextColor = IIf(Diferencia > 0, SystemColors.ControlText, Color.White)

                'Guardar en time_allocation
                Reloj = gRow.Cells("colReloj").Value.ToString.Trim
                Orden = e.GridCell.GridColumn.HeaderText.Trim
                Horas = HtoDecimalCompleto(e.GridCell.Value)

                If Math.Round(Horas, 4) = 0 Then
                    'Si las horas están en 0, borrar el registro para optimizar espacio
                    sqlExecute("DELETE FROM time_allocation WHERE reloj = '" & Reloj & "' AND " & _
                               "fecha = '" & FechaSQL(txtFecha.Value) & "' AND cod_orden = '" & Orden & "'", "TA")

                    Try
                        sqlExecute("insert into ta.dbo.registro_borradas (reloj, orden, fecha) values ('" & Reloj & "', '" & Orden & "', '" & FechaSQL(txtFecha.Value) & "')")
                    Catch ex As Exception

                    End Try

                Else
                    dtOrdenEmp = sqlExecute("SELECT horas FROM time_allocation WHERE reloj = '" & Reloj & "' AND " & _
                                            "fecha = '" & FechaSQL(txtFecha.Value) & "' AND cod_orden = '" & Orden & "'", "TA")
                    If dtOrdenEmp.Rows.Count > 0 Then
                        sqlExecute("UPDATE time_allocation SET " & _
                                   "horas = " & Horas & _
                                   ",usuario = '" & Usuario & _
                                   "',fecha_hora = GETDATE() WHERE reloj = '" & Reloj & "' AND " & _
                                   "fecha = '" & FechaSQL(txtFecha.Value) & "' AND cod_orden = '" & Orden & "'", "TA")
                    Else

                        dtAsist = sqlExecute("SELECT cod_comp,cod_depto,cod_super,cod_turno,cod_clase FROM asist WHERE reloj = '" & Reloj & _
                                             "' AND fha_ent_hor = '" & FechaSQL(txtFecha.Value) & "'", "TA")
                        If dtAsist.Rows.Count > 0 Then
                            dRAsist = dtAsist.Rows(0)
                        Else
                            dtAsist = sqlExecute("SELECT cod_comp,cod_depto,cod_super,cod_turno,cod_clase FROM personal WHERE reloj = '" & Reloj & "'")
                            dRAsist = dtAsist.Rows(0)
                        End If

                        dtBitacora = sqlExecute("SELECT ISNULL((SELECT TOP 1  CASE VALORNUEVO when '' then NULL else VALORNUEVO end FROM " & _
                                                "BITACORA_PERSONAL WHERE RELOJ = '" & Reloj & "' AND CAMPO = 'COD_PLANTA' AND " & _
                                                "FECHA <= '" & FechaSQL(txtFecha.Value) & "' ORDER BY FECHA DESC),PERSONAL.COD_PLANTA) " & _
                                                "FROM PERSONAL WHERE RELOJ = '" & Reloj & "'")

                        sqlExecute("INSERT INTO time_allocation (reloj,cod_orden,fecha,horas,cod_comp,cod_planta,cod_depto,cod_super,cod_turno,cod_clase,usuario,fecha_hora) " & _
                                      "VALUES ('" & Reloj & "','" & _
                                      Orden & "','" & _
                                      FechaSQL(txtFecha.Value) & "'," & _
                                      Horas & _
                                      ",'" & dRAsist("cod_comp") & "'," & _
                                      "'" & dtBitacora.Rows(0).Item(0) & "'," & _
                                      "'" & dRAsist("cod_depto") & "'," & _
                                      "'" & dRAsist("cod_super") & "'," & _
                                      "'" & dRAsist("cod_turno") & "'," & _
                                      "'" & dRAsist("cod_clase") & "'," & _
                                      "'" & Usuario & "'," & _
                                      "getdate()" & _
                                      ")", "TA")
                    End If
                End If
                ActualizaTotalesOrden(Orden)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ActualizaTotalesOrden(ByVal Orden As String)
        Dim CentroCostos As String
        Dim Depto As String
        Dim Turno As String
        Dim Filtro As String = ""

        Dim Trabajadas As Double = 0
        Dim Asignadas As Double = 0
        Dim HrsOrden As Double = 0

        Dim NodoCentroCostos As DevComponents.AdvTree.Node
        Dim NodoDepto As DevComponents.AdvTree.Node
        Dim NodoTurno As DevComponents.AdvTree.Node
        Dim NodoOrden As DevComponents.AdvTree.Node

        Try


            CentroCostos = dgPersonal.PrimaryGrid.Columns("colCodCC").FilterExpr
            If CentroCostos.Contains("'") Then
                CentroCostos = CentroCostos.Substring(CentroCostos.IndexOf("'"))
                CentroCostos = "centro_costos = " & CentroCostos
            End If

            If dgPersonal.PrimaryGrid.Columns("colCodDepto").FilterExpr Is Nothing Then
                Depto = ""
            Else

                Depto = dgPersonal.PrimaryGrid.Columns("colCodDepto").FilterExpr
                If Depto.Contains("'") Then
                    Depto = Depto.Substring(Depto.IndexOf("'"))
                    Depto = "cod_depto = " & Depto
                End If
            End If


            If dgPersonal.PrimaryGrid.Columns("colCodTurno").FilterExpr Is Nothing Then
                Turno = ""
            Else
                Turno = dgPersonal.PrimaryGrid.Columns("colCodTurno").FilterExpr
                If Turno.Contains("'") Then
                    Turno = Turno.Substring(Turno.IndexOf("'"))
                    Turno = "cod_Turno = " & Turno
                End If
            End If

            Filtro = CentroCostos
            Filtro = Filtro & IIf(Filtro.Length > 0 And Depto.Length > 0, " AND ", "") & Depto
            Filtro = Filtro & IIf(Filtro.Length > 0 And Turno.Length > 0, " AND ", "") & Turno



            For Each NodoCentroCostos In treGrupos.Nodes
                If CentroCostos.Contains("'" & NodoCentroCostos.Tag & "'") Then
                    For Each NodoDepto In NodoCentroCostos.Nodes
                        If Depto.Contains("'" & NodoDepto.Tag & "'") Or Depto = "" Then
                            For Each NodoTurno In NodoDepto.Nodes
                                If Turno.Contains("'" & NodoTurno.Tag & "'") Or Turno = "" Then
                                    For Each NodoOrden In NodoTurno.Nodes
                                        If NodoOrden.Text.ToUpper = "HORAS NORMALES" Or NodoOrden.Text.ToUpper = "HORAS EXTRAS" Then
                                            Trabajadas += HtoDecimalCompleto(NodoOrden.Cells(1).Text)
                                        ElseIf NodoOrden.Tag = "ORDEN" Then
                                            For Each nodo In NodoOrden.Nodes
                                                If nodo.text = Orden Then
                                                    HrsOrden = 0
                                                    For Each dRow In dtTimeAllocation.Select("centro_costos = '" & _
                                                                                             NodoCentroCostos.Tag & _
                                                                                             "' AND cod_depto = '" & _
                                                                                             NodoDepto.Tag & _
                                                                                             "' AND cod_turno = '" & _
                                                                                             NodoTurno.Tag & "'")
                                                        HrsOrden += HtoDecimalCompleto(IIf(IsDBNull(dRow(Orden)), "00:00", dRow(Orden)))
                                                    Next

                                                    nodo.Cells(1).Text = DtoH(HrsOrden)
                                                End If
                                                Asignadas += HtoDecimalCompleto(nodo.Cells(1).Text)
                                            Next
                                            NodoOrden.Cells(1).Text = DtoH(Asignadas)
                                        ElseIf NodoOrden.Text = "DIFERENCIA" Then
                                            NodoOrden.Cells(1).Text = DtoH(Trabajadas - Asignadas)
                                            Exit For
                                        End If
                                    Next
                                End If
                            Next
                            Exit For
                        End If
                    Next
                    Exit For
                End If
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

        End Try
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            Dim Localizado As Boolean = False
            Dim CC As String
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                dtTemporal = ConsultaPersonalVW("SELECT reloj FROM personalvw WHERE reloj ='" & Reloj & "'" & _
                                                IIf(Filtro2Talloc.Length > 0, " AND " & Filtro2Talloc, "") & " ORDER BY reloj ASC", False)

                If dtTemporal.Rows.Count > 0 Then
                    dgPersonal.PrimaryGrid.ClearSelectedCells()
                    My.Application.DoEvents()

                    For Each dCell In dgPersonal.PrimaryGrid.FlatRows
                        If Not TypeOf dCell Is GridGroup Then
                            If dCell.Cells("colReloj").Value = Reloj Then
                                dgPersonal.PrimaryGrid.ClearSelectedCells()
                                CC = dCell.cells("colCodCC").value


                                For Each Nd As DevComponents.AdvTree.Node In treGrupos.Nodes
                                    If Not Nd.Text.Trim = CC.Trim Then
                                        Nd.Collapse()
                                    Else
                                        treGrupos.SelectedNode = Nd

                                        'Nd.ExpandAll()
                                        Nd.RaiseClick()
                                    End If
                                Next

                                dCell.IsSelected = True
                                My.Application.DoEvents()
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

    Private Sub dgPersonal_DataBindingComplete(sender As Object, e As GridDataBindingCompleteEventArgs) Handles dgPersonal.DataBindingComplete
        Try
            Dim gRow As GridRow
            Dim Diferencia As Double
            For Each gRow In dgPersonal.PrimaryGrid.FlatRows
                If IsDBNull(gRow.Cells("colDiferencia").Value) Then
                    Diferencia = 0
                Else
                    Diferencia = HtoDecimalCompleto(gRow.Cells("colDiferencia").Value)
                End If

                gRow.Cells("colDiferencia").CellStyles.Default.Background.Color1 = IIf(Diferencia = 0, Color.Green, IIf(Diferencia > 0, SystemColors.GradientInactiveCaption, Color.Red))
                gRow.Cells("colDiferencia").CellStyles.ReadOnly.TextColor = IIf(Diferencia > 0, SystemColors.ControlText, Color.White)
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnAgregarOrden_Click(sender As Object, e As EventArgs) Handles btnAgregarOrden.Click
        Dim Orden As String
        'Dim Reloj As String
        'Dim Horas As Double
        Dim dRow As DataRow
        Dim NewCol As New DevComponents.DotNetBar.SuperGrid.GridColumn
        Dim CCostos As String
        Dim Max As Integer = 0
        Try
            Orden = Buscar("ta.dbo.ordenes_trabajo", "cod_orden", "ORDENES DE TRABAJO", False)
            If Not Orden = "CANCELAR" Then
                CCostos = NodoCentroCostos.Tag

                If Not IsNothing(dgPersonal.PrimaryGrid.Columns("colOrden" & Orden)) Then
                    If dgPersonal.PrimaryGrid.Columns("colOrden" & Orden).Visible = True Then
                        MessageBox.Show("Esta orden de trabajo ya se encuentra agregada. Favor de verificar", "Agregar orden", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Else
                        sqlExecute("INSERT INTO ordenes_cc (cod_orden,centro_costos,prioridad) VALUES ('" & Orden & "','" & CCostos & "'," & Max + 1 & ")", "TA")
                    End If
                    dgPersonal.PrimaryGrid.ClearSelectedColumns()
                    dgPersonal.PrimaryGrid.Columns("colOrden" & Orden).Visible = True
                    dgPersonal.PrimaryGrid.Columns("colOrden" & Orden).EnsureVisible(True)
                    dgPersonal.PrimaryGrid.Columns("colOrden" & Orden).IsSelected = True
                    Exit Sub
                End If


                dtTemporal = sqlExecute("SELECT cod_orden,nombre FROM ordenes_trabajo WHERE cod_orden = '" & Orden & "'", "TA")
                dRow = dtTemporal.Rows(0)

                'Agregar la columna al grid 
                NewCol = New GridColumn
                NewCol.Name = "colOrden" & dRow("cod_orden").ToString.Trim
                NewCol.HeaderText = dRow("cod_orden").ToString.Trim
                NewCol.DataPropertyName = dRow("cod_orden").ToString.Trim
                NewCol.CellStyles.Default.Alignment = Alignment.MiddleRight
                NewCol.CellStyles.Default.Padding.Right = 10
                NewCol.CellStyles.Default.Padding.Left = 5
                NewCol.CellStyles.Selected.Font = New Font("Microsoft SansSerif", 8, FontStyle.Bold)
                NewCol.CellStyles.Selected.Background.Color1 = SystemColors.Highlight
                NewCol.CellStyles.Selected.TextColor = SystemColors.HighlightText
                'NewCol.CellStyles.MouseOver.Background.Color1 = SystemColors.GradientInactiveCaption
                'NewCol.CellStyles.MouseOver.TextColor = SystemColors.ControlText
                NewCol.CellStyles.SelectedMouseOver.Background.Color1 = SystemColors.HotTrack
                NewCol.CellStyles.SelectedMouseOver.TextColor = SystemColors.HighlightText
                NewCol.Width = 75
                NewCol.Tag = dRow("nombre").ToString.Trim

                If dtTimeAllocation.Columns.IndexOf(Orden) < 0 Then
                    dtTimeAllocation.Columns.Add(dRow("cod_orden").ToString.Trim)
                End If


                dgPersonal.PrimaryGrid.Columns.Add(NewCol)

                dtTemporal = sqlExecute("SELECT cod_orden FROM ordenes_cc WHERE centro_costos = '" & CCostos & "' AND cod_orden = '" & Orden & "'", "TA")
                If dtTemporal.Rows.Count = 0 Then
                    dtTemporal = sqlExecute("SELECT MAX(prioridad) FROM ordenes_cc WHERE centro_costos = '" & CCostos & "'", "TA")
                    If dtTemporal.Rows.Count > 0 Then
                        Max = IIf(IsDBNull(dtTemporal.Rows(0).Item(0)), 0, dtTemporal.Rows(0).Item(0))
                    End If

                    sqlExecute("INSERT INTO ordenes_cc (cod_orden,centro_costos,prioridad) VALUES ('" & Orden & "','" & CCostos & "'," & Max + 1 & ")", "TA")
                End If

                AsignarHoras("/" & Orden)



                '    For Each dRow In dtTimeAllocation.Select("centro_costos = '" & CCostos & "'")
                '        dRow(Orden) = txtHoras.Text

                '        'Guardar en time_allocation
                '        Reloj = dRow("reloj").ToString.Trim
                '        Horas = HtoDecimalCompleto(txtHoras.Text)

                '        dtOrdenEmp = sqlExecute("SELECT horas FROM time_allocation WHERE reloj = '" & Reloj & "' AND " & _
                '                                "fecha = '" & FechaSQL(txtFecha.Value) & "' AND cod_orden = '" & Orden & "'", "TA")
                '        If dtOrdenEmp.Rows.Count > 0 Then
                '            sqlExecute("UPDATE time_allocation SET horas = " & Horas & " WHERE reloj = '" & Reloj & "' AND " & _
                '                       "fecha = '" & FechaSQL(txtFecha.Value) & "' AND cod_orden = '" & Orden & "'", "TA")
                '        Else
                '            sqlExecute("INSERT INTO time_allocation (reloj,cod_orden,fecha,horas) " & _
                '                          "VALUES ('" & Reloj & "','" & Orden & "','" & _
                '                          FechaSQL(txtFecha.Value) & "'," & Horas & ")", "TA")
                '        End If

                '    Next

                'End If


                dgPersonal.PrimaryGrid.DataSource = dtTimeAllocation
                'DataGridViewX1.DataSource = dtTimeAllocation

                dgPersonal.Update()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub AgregarOrdenDeTrabajoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarOrdenDeTrabajoToolStripMenuItem.Click
        btnAgregarOrden.PerformClick()
    End Sub

    Private Sub AsignarHorasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignarHorasOrdenToolStripMenuItem.Click
        Try
            AsignarHoras("/" & sender.tag.ToString.Trim)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgPersonal_CellMouseEnter(sender As Object, e As GridCellEventArgs) Handles dgPersonal.CellMouseEnter
        Try


            If e.GridCell.GridColumn.ColumnIndex >= ColumnaInicial Then
                AsignarHorasEmpleadoToolStripMenuItem.Text = "Asignar " & txtHoras.Text & _
                    IIf(txtHoras.Text = "01:00", " hora ", " horas ") & "al empleado " & _
                   e.GridCell.GridRow.Cells(0).Value & ", orden " & e.GridCell.GridColumn.HeaderText
                AsignarHorasEmpleadoToolStripMenuItem.Tag = "reloj = '" & e.GridCell.GridRow.Cells(0).Value & "'/" & e.GridCell.GridColumn.HeaderText
                AsignarHorasEmpleadoToolStripMenuItem.Visible = True

                AsignarHorasOrdenToolStripMenuItem.Text = "Asignar " & txtHoras.Text & _
                    IIf(txtHoras.Text = "01:00", " hora ", " horas ") & ", para orden " & e.GridCell.GridColumn.HeaderText
                AsignarHorasOrdenToolStripMenuItem.Tag = "/" & e.GridCell.GridColumn.HeaderText
                BorrarOrdenDeTrabajoToolStripMenuItem.Text = "Borrar orden " & e.GridCell.GridColumn.HeaderText
                BorrarOrdenDeTrabajoToolStripMenuItem.Tag = "/" & e.GridCell.GridColumn.HeaderText
            Else
                AsignarHorasEmpleadoToolStripMenuItem.Visible = False
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

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

    Private Sub txtFecha_Click(sender As Object, e As EventArgs) Handles txtFecha.Click

    End Sub

    Private Sub bgCargaFecha_DoWork()
        Dim Fecha As Date
        Try
            Dim dtPersonalFaltante As New DataTable
            Dim dtParametros As New DataTable
            Dim FiltroTAlloc As String
            Dim dtTAllocInicio As New DataTable
            Dim Texto As String = ""

            Dim x = 0
            treGrupos.Nodes.Clear()
            If txtFecha.ValueObject Is Nothing Then Exit Sub

            Fecha = txtFecha.Value

            'Mostar/ocultar picturebox para indicar festivo
            If Festivo(Fecha) Then
                picFestivo.Visible = True
                dtTemporal = sqlExecute("SELECT nombre,filtro FROM FESTIVOS WHERE festivo = '" & FechaSQL(Fecha) & "'", "TA")
                For Each dRow As DataRow In dtTemporal.Rows
                    Texto = IIf(Texto.Length > 0, vbCrLf & Texto, "") & dRow("nombre").ToString.Trim.ToUpper & _
                        IIf(IsDBNull(dRow("filtro")), "", IIf(dRow("filtro") = "", "", vbCrLf & "   [" & dRow("filtro").ToString.Trim & "]"))
                Next
                'Configurar Tooltip de acuerdo a detalle de festivo
                SuperTooltip1.SetSuperTooltip(picFestivo, New DevComponents.DotNetBar.SuperTooltipInfo _
                                              ("DÍA FESTIVO", "", Texto, My.Resources.Festivo24, Nothing, DevComponents.DotNetBar.eTooltipColor.Green))
            Else
                picFestivo.Visible = False
            End If

            dtParametros = sqlExecute("SELECT fecha_corte_tAlloc,filtro_tAlloc FROM parametros")
            If dtParametros.Rows.Count = 0 Then
                FechaCorte = DateSerial(2000, 1, 1)
                FiltroTAlloc = ""
            Else
                FechaCorte = IIf(IsDBNull(dtParametros.Rows(0).Item("fecha_corte_talloc")), DateSerial(200, 1, 1), dtParametros.Rows(0).Item("fecha_corte_talloc"))
                FiltroTAlloc = IIf(IsDBNull(dtParametros.Rows(0).Item("filtro_tAlloc")), "", dtParametros.Rows(0).Item("filtro_tAlloc"))
            End If


            Dim NewCol As DevComponents.DotNetBar.SuperGrid.GridColumn


            Dim dtTAllocCompleto As New DataTable
            Dim FiltroPersonal As String

            'Empleados ya registrados en time_allocation para la fecha

            Dim AnoPer As String
            AnoPer = ObtenerAnoPeriodo(Fecha)
            Dim dtPer As New DataTable
            Dim Eliminar As String = ""
            dtPer = sqlExecute("SELECT fecha_ini,fecha_fin FROM periodos WHERE ano = '" & AnoPer.Substring(0, 4) & "' AND periodo = '" & AnoPer.Substring(4, 2) & "'", "TA")

            dtTAllocCompleto = sqlExecute("SELECT * FROM time_allocation WHERE RELOJ+ CAST(FECHA AS CHAR(10))+COD_ORDEN IN " & _
                                          "(SELECT RELOJ+ CAST(FECHA AS CHAR(10))+COD_ORDEN from timeallocationvw  where not " & _
                                          "(" & FiltroTAlloc.Replace("]", "TA]") & ") and fecha between '" & _
                                          FechaSQL(dtPer.Rows(0).Item("fecha_ini")) & "' and '" & FechaSQL(dtPer.Rows(0).Item("fecha_fin")) & "')", "TA")

            For Each dRow As DataRow In dtTAllocCompleto.Rows
                Eliminar &= vbCrLf & "RELOJ: " & dRow("reloj") & " FECHA: " & dRow("fecha") & " ORDEN: " & dRow("cod_orden")
            Next


            If dtTAllocCompleto.Rows.Count > 0 Then
                If MessageBox.Show("Se detectaron " & dtTAllocCompleto.Rows.Count & " registros del periodo " & AnoPer & _
                                " que ya no cumplen con el criterio aceptado para Time Allocation. ¿Desea eliminarlos?" & vbCrLf & Eliminar, _
                                "Ordenes inválidas", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
                    sqlExecute("DELETE FROM time_allocation WHERE RELOJ+ CAST(FECHA AS CHAR(10))+COD_ORDEN IN " & _
                               "(SELECT RELOJ+ CAST(FECHA AS CHAR(10))+COD_ORDEN from timeallocationvw  where not " & _
                               "(" & FiltroTAlloc.Replace("]", "TA]") & ") and fecha between '" & _
                               FechaSQL(dtPer.Rows(0).Item("fecha_ini")) & "' and '" & FechaSQL(dtPer.Rows(0).Item("fecha_fin")) & "')", "TA")
                Else
                    MessageBox.Show("Se recomienda revisar esta información, para asegurar la confiabilidad de este proceso.", "Ordenes inválidas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If

            FiltroPersonal = IIf(Filtro2Talloc.Length > 0, " AND " & Filtro2Talloc, "")
            FiltroPersonal = FiltroPersonal & IIf(FiltroTAlloc.Length > 0, " AND " & FiltroTAlloc, "")

            'Los filtros son en base a asist, excepto centro de costos
            FiltroPersonal = FiltroPersonal.Replace("[centro_costos]", "deptos.centro_costos")
            FiltroPersonal = FiltroPersonal.Replace("[", "time_allocation.[")

            'Ordenes registradas en tabla ordenes_cc
            'además las que estén asignadas en esa fecha, pero no en la tabla (considerando que se hayan borrado)
            dtOrdenes = sqlExecute("SELECT ordenes_cc.cod_orden,nombre,1 AS prioridad FROM ordenes_cc LEFT JOIN ordenes_trabajo ON " & _
                                   "ordenes_cc.cod_orden = ordenes_trabajo.cod_orden GROUP BY ordenes_cc.cod_orden,nombre " & _
                                   "UNION " & _
                                   "SELECT DISTINCT TIME_ALLOCATION.cod_orden,ORDENES_TRABAJO.nombre,1 FROM time_allocation " & _
                                   "LEFT JOIN ordenes_trabajo ON time_allocation.cod_orden = ordenes_trabajo.cod_orden " & _
                                   "LEFT JOIN asist ON TIME_ALLOCATION.reloj = asist.reloj " & _
                                   "LEFT JOIN personal.dbo.personal ON time_allocation.reloj = Personal.reloj  " & _
                                   "LEFT JOIN personal.dbo.Turnos ON time_allocation.cod_comp = Turnos.cod_comp AND time_allocation.cod_Turno = Turnos.cod_Turno " & _
                                   "LEFT JOIN personal.dbo.super ON time_allocation.cod_comp = super.cod_comp AND time_allocation.cod_super = super.cod_super " & _
                                   "LEFT JOIN personal.dbo.Deptos ON time_allocation.cod_comp = Deptos.cod_comp AND time_allocation.cod_Depto = Deptos.cod_Depto " & _
                                   "WHERE time_allocation.fecha = '" & FechaSQL(Fecha) & "' " & _
                                   "AND fha_ent_hor = '" & FechaSQL(Fecha) & "' " & _
                                   "AND ISNULL(closing_date,'2099-01-01') >= '" & FechaSQL(Fecha) & "' " & _
                                   FiltroPersonal & _
                                   "AND (horas_normales <> '00:00'  or horas_extras <> '00:00')", "TA")


            dtTAllocInicio = sqlExecute("EXEC EstructuraTimeAllocation " & NivelConsulta & ",'" & FechaSQL(Fecha) & "'," & _
                          "'alta <= ''" & FechaSQL(Fecha) & "'' AND (baja IS NULL OR baja>''" & FechaSQL(Fecha) & "'')" & _
                          FiltroPersonal.Replace("'", "''") & "'", "TA")

            My.Application.DoEvents()
            'MCR 20/Ene/2016
            'Condición para determinar proporción de 2do turno solamente si la fecha a analizar es después del 4 de enero/2016
            'fecha en que se empezó a aplicar 9hrs p/2do. turno 
            If txtFecha.Value < Date.Parse("2016-01-04") Then
                dtPersonalFaltante = sqlExecute("SELECT DISTINCT asist.reloj,RTRIM(APATERNO) + ',' + RTRIM(AMATERNO) + ',' + RTRIM(PERSONAL.NOMBRE) AS NOMBRES," & _
                "asist.COD_COMP,asist.COD_DEPTO,asist.COD_TURNO,asist.COD_SUPER,asist.COD_CLASE," & _
                "dbo.DTOH((case when tipo_aus = 'FES' then 0 else SELECT SUM(CASE cod_turno WHEN '2' THEN " & _
                "ROUND(dbo.htod(HORAS_NORMALES),4) ELSE dbo.HToD(HORAS_NORMALES) end END) " & _
                "FROM asist AS as1 WHERE AS1.RELOJ = ASIST.RELOJ AND AS1.FHA_ENT_HOR = ASIST.FHA_ENT_HOR)) AS horas_normales," & _
                "(SELECT (TA.dbo.DTOH(SUM(ta.DBO.htod(horas_extras)))) FROM TA.dbo.ASIST AS AS1 WHERE AS1.RELOJ = ASIST.RELOJ AND AS1.FHA_ENT_HOR = ASIST.FHA_ENT_HOR) AS  horas_extras," & _
                "Personal.COD_PLANTA,deptos.CENTRO_COSTOS,deptos.NOMBRE AS NOMBRE_DEPTO,super.NOMBRE AS NOMBRE_SUPER,turnos.NOMBRE AS NOMBRE_TURNO " & _
                "FROM ta.dbo.asist " & _
                "LEFT JOIN personal.dbo.personal ON asist.reloj = Personal.reloj  " & _
                "LEFT JOIN personal.dbo.deptos ON asist.cod_comp = deptos.cod_comp AND asist.cod_depto = deptos.cod_depto " & _
                "LEFT JOIN personal.dbo.super ON asist.cod_comp = super.cod_comp AND asist.cod_super = super.cod_super " & _
                "LEFT JOIN personal.dbo.turnos ON asist.cod_comp = turnos.cod_comp AND asist.cod_turno = turnos.cod_turno " & _
                "LEFT JOIN ta.dbo.tipo_ausentismo ON asist.tipo_aus = tipo_ausentismo.tipo_aus" & _
                " WHERE asist.fha_ent_hor = '" & FechaSQL(Fecha) & "' " & _
                " AND (asist.TIPO_AUS IS NULL OR (TIPO_NATURALEZA not in ('V','F') AND porcentaje >0))" & _
                FiltroPersonal.Replace("time_allocation.", "asist.") & _
                "AND asist.reloj NOT IN (SELECT DISTINCT reloj FROM ta.dbo.time_allocation WHERE fecha = '" & FechaSQL(Fecha) & "') " & _
                "AND (horas_normales <> '00:00'  or horas_extras <> '00:00')", "TA")
            Else
             
                dtPersonalFaltante = sqlExecute(" SELECT DISTINCT " & _
                    " asist.reloj, " & _
                    " RTRIM(APATERNO) + ',' + RTRIM(AMATERNO) + ',' + RTRIM(PERSONAL.NOMBRE) AS NOMBRES, " & _
                    " asist.COD_COMP, " & _
                    " asist.COD_DEPTO, " & _
                    " asist.COD_TURNO, " & _
                    " asist.COD_SUPER, " & _
                    " asist.COD_CLASE,  " & _
                    " isnull (ta.dbo.DTOH((SELECT SUM(CASE WHEN TIPO_AUS='FES' THEN 0 ELSE CASE cod_turno WHEN '2' THEN ROUND(dbo.htod(HORAS_NORMALES) * 1.071428,4) ELSE dbo.HToD(HORAS_NORMALES)END END)  " & _
                    "             FROM asist AS as1 WHERE AS1.RELOJ = ASIST.RELOJ AND AS1.FHA_ENT_HOR = ASIST.FHA_ENT_HOR )),'00:00') AS horas_normales, " & _
                    " (SELECT (TA.dbo.DTOH(SUM(ta.DBO.htod(horas_extras)))) FROM TA.dbo.ASIST AS AS1 WHERE AS1.RELOJ = ASIST.RELOJ AND AS1.FHA_ENT_HOR = ASIST.FHA_ENT_HOR) AS  horas_extras, " & _
                    " Personal.COD_PLANTA, " & _
                    " deptos.CENTRO_COSTOS, " & _
                    " deptos.NOMBRE AS NOMBRE_DEPTO, " & _
                    " super.NOMBRE AS NOMBRE_SUPER, " & _
                    " turnos.NOMBRE AS NOMBRE_TURNO " & _
                    " FROM ta.dbo.asist " & _
                    " LEFT JOIN personal.dbo.personal ON asist.reloj = Personal.reloj  " & _
                    " LEFT JOIN personal.dbo.deptos ON asist.cod_comp = deptos.cod_comp AND asist.cod_depto = deptos.cod_depto " & _
                    " LEFT JOIN personal.dbo.super ON asist.cod_comp = super.cod_comp AND asist.cod_super = super.cod_super " & _
                    " LEFT JOIN personal.dbo.turnos ON asist.cod_comp = turnos.cod_comp AND asist.cod_turno = turnos.cod_turno " & _
                    " LEFT JOIN ta.dbo.tipo_ausentismo ON asist.tipo_aus = tipo_ausentismo.tipo_aus " & _
                    " WHERE asist.fha_ent_hor = '" & FechaSQL(Fecha) & "' AND asist.COD_TIPO='O' " & _
                    " AND (asist.TIPO_AUS IS NULL OR (TIPO_NATURALEZA not in ('V','F') AND porcentaje >0)) " & _
                    FiltroPersonal.Replace("time_allocation.", "asist.")& _
                    " AND asist.reloj NOT IN (SELECT DISTINCT reloj FROM ta.dbo.time_allocation WHERE fecha = '" & FechaSQL(Fecha) & "') " & _
                    " AND ( CASE WHEN ASIST.TIPO_AUS='FES' THEN '00:00' ELSE horas_normales END <> '00:00'  or horas_extras <> '00:00') ", "TA")

            End If

            '' Este procedimiento ya no se usa, ahora se basa en el ausentismo de asist
            'If Festivo(Fecha) Then
            '    'Si es festivo para algunos (o todos) empleados, revisar si tienen horas
            '    dtTimeAllocation = dtTAllocInicio.Clone
            '    For Each dRow As DataRow In dtTAllocInicio.Rows

            '        If Festivo(Fecha, dRow("RELOJ")) Then
            '            'Si es festivo para el empleado, insertar solamente si tiene horas extras
            '            'Las horas normales en este punto, se refieren a las festivas
            '            If dRow("horas_extras") <> "00:00" Then
            '                dRow("horas_normales") = "00:00"
            '                dtTimeAllocation.ImportRow(dRow)
            '            End If
            '        ElseIf dRow("horas_extras") <> "00:00" Or dRow("horas_normales") <> "00:00" Then
            '            dtTimeAllocation.ImportRow(dRow)
            '        End If

            '    Next
            'Else
            '    dtTimeAllocation = dtTAllocInicio.Copy
            'End If

            '2016-05-20 ACA
            dtTimeAllocation = dtTAllocInicio.Copy


            frmTrabajando.Avance.IsRunning = False
            frmTrabajando.Avance.Maximum = dtPersonalFaltante.Rows.Count
            For Each dEmpleado As DataRow In dtPersonalFaltante.Rows
                Try
                    bgCargaFecha_ProgressChanged("Analizando " & dEmpleado("reloj"))
                Catch ex As Exception
                    bgCargaFecha_ProgressChanged("Analizando")
                End Try

                'If Festivo(Fecha, dEmpleado("RELOJ")) Then
                '    'Si es festivo para el empleado, insertar solamente si tiene horas extras
                '    'Las horas normales en este punto, se refieren a las festivas
                '    If dEmpleado("horas_extras") > "00:00" Then
                '        dEmpleado("horas_normales") = "00:00"
                '        dtTimeAllocation.ImportRow(dEmpleado)
                '    End If
                'ElseIf dEmpleado("horas_extras") <> "00:00" Or dEmpleado("horas_normales") <> "00:00" Then
                '    dtTimeAllocation.ImportRow(dEmpleado)
                'End If
                '' Se basa en el festivo de asist
                If dEmpleado("horas_extras") <> "00:00" Or dEmpleado("horas_normales") <> "00:00" Then
                    dtTimeAllocation.ImportRow(dEmpleado)
                End If

            Next

            'miriam
            For Each dRow As DataRow In dtOrdenes.Select("", "prioridad,cod_orden")
                If dtTimeAllocation.Columns.IndexOf(dRow("cod_orden").ToString.Trim) < 0 Then
                    dtTimeAllocation.Columns.Add(dRow("cod_orden").ToString.Trim)
                End If

                If IsNothing(dgPersonal.PrimaryGrid.Columns("colOrden" & dRow("cod_orden").ToString.Trim)) Then
                    'Agregar la columna al grid
                    NewCol = New GridColumn
                    'NewCol.EditorType = GetType(GridDoubleInputEditControl)
                    NewCol.Name = "colOrden" & dRow("cod_orden").ToString.Trim
                    NewCol.HeaderText = dRow("cod_orden").ToString.Trim
                    NewCol.DataPropertyName = dRow("cod_orden").ToString.Trim
                    NewCol.CellStyles.Default.Alignment = Alignment.MiddleRight
                    NewCol.CellStyles.Default.Padding.Right = 10
                    NewCol.CellStyles.Default.Padding.Left = 5
                    NewCol.CellStyles.Selected.Font = New Font("Microsoft SansSerif", 8, FontStyle.Bold)
                    NewCol.CellStyles.Selected.Background.Color1 = SystemColors.Highlight
                    NewCol.CellStyles.Selected.TextColor = SystemColors.HighlightText
                    'NewCol.CellStyles.MouseOver.Background.Color1 = SystemColors.HotTrack
                    'NewCol.CellStyles.MouseOver.TextColor = SystemColors.HighlightText
                    NewCol.CellStyles.SelectedMouseOver.Background.Color1 = SystemColors.HotTrack
                    NewCol.CellStyles.SelectedMouseOver.TextColor = SystemColors.HighlightText
                    NewCol.Width = 75
                    NewCol.Tag = dRow("nombre").ToString.Trim
                    dgPersonal.PrimaryGrid.Columns.Add(NewCol)
                End If
            Next
            My.Application.DoEvents()


            'Filtrar datos, y pasar a dtTimeAllocation solamente los que cumplen la condición

            '***** SECCION INHABILITADA, MIENTRAS SE ESTEN UTILIZANDO SOLO CAMPOS DE ASIST PARA FILTROS *****
            'dtTimeAllocation = dtTAllocCompleto.Clone
            'FiltraTAlloc(dtTAllocCompleto, dtTimeAllocation, FiltroTAlloc & FiltroXUsuario)
            'FiltraTAlloc(dtPersonalFaltante, dtTimeAllocation, FiltroTAlloc & FiltroXUsuario)

            Dim Total As Double
            Dim TotalCC As Double
            Dim NormalesCC As Double
            Dim ExtrasCC As Double
            Dim EmpleadosCC As Integer
            Dim CentroCostos As String
            Dim Turno As String
            Dim Depto As String
            Dim Super As String
            Dim dReg As DataRow

            dtTimeAllocation.Columns.Add("diferencia")

            pbAvance.IsRunning = False
            pbAvance.Value = 0
            pbAvance.Maximum = dtTimeAllocation.Rows.Count
            dtGruposTAlloc.Rows.Clear()
            For Each dRow As DataRow In dtTimeAllocation.Rows

                bgCargaFecha_ProgressChanged(dRow("reloj"))


                Total = HtoDecimalCompleto(IIf(IsDBNull(dRow("total")), "00:00", dRow("total")))
                dRow("diferencia") = DtoH((HtoDecimalCompleto(IIf(IsDBNull(dRow("horas_normales")), "00:00", dRow("horas_normales"))) + _
                                           HtoDecimalCompleto(IIf(IsDBNull(dRow("horas_extras")), "00:00", dRow("horas_extras")))) - Total)

                '***************** OBTENER TOTALES POR GRUPO ************************
                'MCR 20/Ene/2016
                'Cambio de orden a grupo, en lugar de CC-Turno-Depto, será CC-Depto-Turno

                CentroCostos = IIf(IsDBNull(dRow("centro_costos")), "", dRow("centro_costos")).ToString.Trim
                Depto = IIf(IsDBNull(dRow("cod_Depto")), "", dRow("cod_Depto")).ToString.Trim
                Turno = IIf(IsDBNull(dRow("cod_Turno")), "", dRow("cod_Turno")).ToString.Trim
                Super = IIf(IsDBNull(dRow("cod_super")), "", dRow("cod_super")).ToString.Trim
                AgrupaOrden(CentroCostos, Turno, Depto, Super, "HORAS NORMALES", IIf(IsDBNull(dRow("horas_normales")), "00:00", dRow("horas_normales")))
                AgrupaOrden(CentroCostos, Turno, Depto, Super, "HORAS EXTRAS", IIf(IsDBNull(dRow("horas_extras")), "00:00", dRow("horas_extras")))
                AgrupaOrden(CentroCostos, Turno, Depto, Super, "EMPLEADOS", 1)

                For Each dOrden As DataRow In dtOrdenes.Select("", "prioridad")
                    AgrupaOrden(CentroCostos, Turno, Depto, Super,
                                dOrden("cod_orden").ToString.Trim, _
                                IIf(IsDBNull(dRow(dOrden("cod_orden").ToString.Trim)), "00:00", dRow(dOrden("cod_orden").ToString.Trim)))
                Next

                '**********************************************************************
            Next
            pbAvance.IsRunning = True
            bgCargaFecha_ProgressChanged(" - GRUPOS -")

            dgPersonal.PrimaryGrid.ReadOnly = Fecha.Date <= FechaCorte
            If Fecha.Date <= FechaCorte Or dtTimeAllocation.Rows.Count = 0 Then
                dgPersonal.ContextMenuStrip = Nothing
            Else
                dgPersonal.ContextMenuStrip = ContextMenuStrip1
            End If

            dgPersonal.PrimaryGrid.DataSource = dtTimeAllocation

            My.Application.DoEvents()

            Dim dNodoCentroCostos As DevComponents.AdvTree.Node
            Dim dnodoTurno As DevComponents.AdvTree.Node
            Dim dNodoDepto As DevComponents.AdvTree.Node
            Dim dNodoHoras As DevComponents.AdvTree.Node
            Dim dNodoOrden As DevComponents.AdvTree.Node
            'Dim dNodoTotalesCC() As DevComponents.AdvTree.Node
            Dim dNodoTotal As DevComponents.AdvTree.Node

            Dim N As Integer = 0
            Dim dtTurnos As New DataTable
            Dim dtCentroCostos As New DataTable
            Dim dtDeptos As New DataTable
            Dim Trabajadas As Double
            Dim Empleados As Integer

            dtCentroCostos = sqlExecute("SELECT centro_costos FROM c_costos WHERE distribuible = 1 ORDER BY centro_costos")
            'MCR 20/Ene/2016
            'Cambio a query, para tomar nombres directo de tabla de supervisores/turnos
            dtDeptos = sqlExecute("SELECT trn.cod_depto,trn.cod_super,ISNULL(NOMBRE,'NO SUP.') AS NOMBRE_SUPER FROM " & _
                                 "(SELECT distinct COD_COMP,cod_depto,cod_super FROM ta.dbo.tavw WHERE  fha_ent_hor = '" & FechaSQL(Fecha) & "'" & _
                                 IIf(FiltroTAlloc.Length > 0, " AND " & FiltroTAlloc, "") & ") AS TRN LEFT JOIN " & _
                                 "PERSONAL.DBO.super ON trn.cod_comp = super.cod_comp and trn.cod_super = super.cod_super")
            dtTurnos = sqlExecute("SELECT trn.COD_TURNO,ISNULL(NOMBRE,'NO TURNO') AS NOMBRE_TURNO FROM (SELECT distinct COD_COMP,cod_turno FROM ta.dbo.tavw " & _
                                 "WHERE fha_ent_hor = '" & FechaSQL(Fecha) & "'" & _
                                 IIf(FiltroTAlloc.Length > 0, " AND " & FiltroTAlloc, "") & ") AS TRN " & _
                                 "LEFT JOIN TURNOS ON trn.cod_comp = turnos.cod_comp and trn.cod_turno = turnos.cod_turno")

            For Each dCentroCostos As DataRow In dtCentroCostos.Select("", "centro_costos")
                CentroCostos = dCentroCostos("centro_costos").ToString.Trim
                N = 0
                NormalesCC = 0
                TotalCC = 0
                ExtrasCC = 0
                EmpleadosCC = 0
                'ReDim dNodoTotalesCC(10)

                Dim dNodoTotalesCC(10) As DevComponents.AdvTree.Node

                If dtGruposTAlloc.Select("centro_costos = '" & CentroCostos & "'").Count > 0 Then
                    dNodoCentroCostos = New DevComponents.AdvTree.Node
                    dNodoCentroCostos.Text = CentroCostos.Trim
                    dNodoCentroCostos.Name = "CentroCostos" & CentroCostos
                    dNodoCentroCostos.Style = EstiloSupervisor
                    'dNodoCentroCostos.ExpandVisibility = DevComponents.AdvTree.eNodeExpandVisibility.Hidden
                    dNodoCentroCostos.StyleSelected = EstiloSeleccionado
                    dNodoCentroCostos.StyleMouseOver = EstiloMouseOver
                    dNodoCentroCostos.FullRowBackground = True
                    dNodoCentroCostos.Tag = CentroCostos

                    For Each dTurno As DataRow In dtTurnos.Rows
                        Turno = dTurno("cod_Turno").ToString.Trim
                        If dtGruposTAlloc.Select("centro_costos = '" & CentroCostos & "' AND cod_Turno = '" & Turno & "'").Count > 0 Then
                            dnodoTurno = New DevComponents.AdvTree.Node
                            dnodoTurno.Text = dTurno("nombre_turno").ToString.Trim
                            dnodoTurno.Name = "Turno" & Turno.Trim
                            dnodoTurno.Style = EstiloDepartamento
                            dnodoTurno.StyleSelected = EstiloSeleccionado
                            dnodoTurno.StyleMouseOver = EstiloMouseOver
                            dnodoTurno.Tag = Turno
                            dnodoTurno.FullRowBackground = True
                            dnodoTurno.NodesColumnsHeaderVisible = False

                            dnodoTurno.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("Depto"))
                            dnodoTurno.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("Empleados"))

                            dnodoTurno.NodesColumns(0).Width.Relative = 55
                            dnodoTurno.NodesColumns(1).Width.Relative = 30

                            For Each dDepto As DataRow In dtDeptos.Rows
                                Empleados = 0
                                Depto = dDepto("cod_Depto").ToString
                                Super = dDepto("cod_Super").ToString
                                If dtGruposTAlloc.Select("centro_costos = '" & CentroCostos & "' AND cod_Turno = '" & Turno & "' AND cod_Depto = '" & Depto & "' AND cod_super = '" & Super & "'").Count > 0 Then
                                    dNodoDepto = New DevComponents.AdvTree.Node
                                    dNodoDepto.Text = Depto & "-" & dDepto("nombre_super").ToString.Trim
                                    dNodoDepto.Name = "Depto" & Depto.Trim
                                    dNodoDepto.Style = EstiloTurno
                                    dNodoDepto.StyleSelected = EstiloSeleccionado
                                    dNodoDepto.StyleMouseOver = EstiloMouseOver
                                    dNodoDepto.Tag = Depto
                                    dNodoDepto.AccessibleDescription = Super
                                    dNodoDepto.FullRowBackground = True
                                    dNodoDepto.NodesColumnsHeaderVisible = False

                                    'Columnas de totales en el nodo del grupo
                                    dNodoDepto.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("Detalle"))
                                    dNodoDepto.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("Horas"))

                                    dNodoDepto.NodesColumns(0).Width.Relative = 55
                                    dNodoDepto.NodesColumns(1).Width.Relative = 30

                                    Trabajadas = 0
                                    dReg = dtGruposTAlloc.Rows.Find({CentroCostos, Turno, Depto, Super, "HORAS NORMALES"})
                                    If Not dReg Is Nothing Then
                                        Trabajadas = dReg("horas")

                                        dNodoHoras = New DevComponents.AdvTree.Node
                                        dNodoHoras.Text = "Horas normales"
                                        dNodoHoras.Cells.Add(New DevComponents.AdvTree.Cell(DtoH(dReg("horas"))))
                                        dNodoHoras.Name = "hrsNormales" & Depto

                                        dNodoHoras.Selectable = False
                                        dNodoHoras.Style = EstiloRegular
                                        dNodoHoras.Cells(1).StyleNormal = EstiloRegularDerecha
                                        dNodoHoras.Tag = "HORAS"
                                        dNodoHoras.FullRowBackground = True
                                        dNodoDepto.Nodes.Add(dNodoHoras)

                                        NormalesCC += dReg("horas")
                                    End If

                                    dReg = dtGruposTAlloc.Rows.Find({CentroCostos, Turno, Depto, Super, "HORAS EXTRAS"})
                                    If Not dReg Is Nothing Then
                                        Trabajadas += dReg("horas")

                                        dNodoHoras = New DevComponents.AdvTree.Node
                                        dNodoHoras.Style = EstiloRegular
                                        dNodoHoras.Text = "Horas extras"
                                        dNodoHoras.Tag = "HORAS"
                                        dNodoHoras.Selectable = False
                                        dNodoHoras.Cells.Add(New DevComponents.AdvTree.Cell(DtoH(dReg("horas"))))
                                        dNodoHoras.Cells(1).StyleNormal = EstiloRegularDerecha
                                        dNodoDepto.Nodes.Add(dNodoHoras)

                                        ExtrasCC += dReg("horas")
                                    End If

                                    dNodoHoras = New DevComponents.AdvTree.Node
                                    dNodoHoras.Style = EstiloRegular
                                    dNodoHoras.Text = "Órdenes"
                                    dNodoHoras.Tag = "HORAS"
                                    dNodoHoras.Selectable = False
                                    'Columnas de horas por orden
                                    dNodoHoras.NodesColumnsHeaderVisible = True
                                    dNodoHoras.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("Detalle"))
                                    dNodoHoras.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("Horas"))

                                    dNodoHoras.NodesColumns(0).Width.Relative = 55
                                    dNodoHoras.NodesColumns(1).Width.Relative = 30


                                    Total = 0
                                    For Each dOrden As DataRow In dtGruposTAlloc.Select("orden NOT IN ('horas normales','horas extras','empleados') AND centro_costos = '" & CentroCostos & "' AND cod_Turno = '" & Turno & "' AND cod_Depto = '" & Depto & "' and cod_super = '" & Super & "'")
                                        If Empleados < dOrden("empleados") Then
                                            Empleados = dOrden("empleados")
                                        End If
                                        If dOrden("horas") > 0 Then

                                            dNodoOrden = New DevComponents.AdvTree.Node
                                            dNodoOrden.Text = dOrden("orden").ToString.Trim

                                            dNodoOrden.Tag = "ORDEN"
                                            dNodoOrden.Cells.Add(New DevComponents.AdvTree.Cell(DtoH(dOrden("horas"))))
                                            dNodoOrden.Style = EstiloRegular
                                            dNodoOrden.Cells(1).StyleNormal = EstiloRegularDerecha
                                            dNodoOrden.Selectable = False
                                            dNodoOrden.Name = "orden" & dOrden("orden").ToString.Trim


                                            dNodoHoras.Nodes.Add(dNodoOrden)

                                            Total += dOrden("horas")
                                            TotalCC += dOrden("horas")

                                        End If

                                    Next
                                    dNodoHoras.Cells.Add(New DevComponents.AdvTree.Cell(DtoH(Total)))
                                    dNodoHoras.Cells(1).StyleNormal = EstiloRegularDerecha

                                    dNodoDepto.Nodes.Add(dNodoHoras)


                                    '****** Nodo de diferencia ******
                                    dNodoHoras = New DevComponents.AdvTree.Node
                                    dNodoHoras.Text = "DIFERENCIA"
                                    dNodoHoras.Tag = "HORAS"
                                    dNodoHoras.Selectable = False
                                    If Math.Round(Trabajadas - Total, 2) = 0 Then
                                        dNodoHoras.Style = EstiloDiferencia0
                                    ElseIf Trabajadas - Total > 0 Then
                                        dNodoHoras.Style = EstiloDiferenciaPositiva
                                    Else
                                        dNodoHoras.Style = EstiloDiferenciaNegativa
                                    End If
                                    'dNodoHoras.FullRowBackground = True
                                    dNodoHoras.Cells.Add(New DevComponents.AdvTree.Cell(DtoH(Math.Round(Trabajadas - Total, 2))))
                                    dNodoHoras.Cells(1).StyleNormal = EstiloRegularDerecha
                                    dNodoDepto.Nodes.Add(dNodoHoras)
                                    '***********************************

                                    dNodoDepto.Cells.Add(New DevComponents.AdvTree.Cell(Empleados & " emp."))
                                    dNodoDepto.Cells(1).StyleNormal = EstiloRegularDerecha
                                    dnodoTurno.Nodes.Add(dNodoDepto)
                                    EmpleadosCC += Empleados
                                End If
                            Next

                            dNodoCentroCostos.Nodes.Add(dnodoTurno)
                        End If
                    Next

                    'Agregar el nodo de totales por centro de costos
                    dNodoTotal = New DevComponents.AdvTree.Node
                    dNodoTotal.FullRowBackground = True
                    dNodoTotal.Style = EstiloTotal
                    dNodoTotal.Text = "TOTALES C.C. " & dNodoCentroCostos.Text & "      (" & EmpleadosCC & " emp.)"
                    dNodoTotal.Tag = "TOTAL"
                    dNodoTotal.Selectable = False

                    dNodoTotal.NodesColumnsHeaderVisible = False
                    dNodoTotal.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("Detalle"))
                    dNodoTotal.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("Horas"))

                    dNodoTotal.NodesColumns(0).Width.Relative = 55
                    dNodoTotal.NodesColumns(1).Width.Relative = 30

                    'TOTAL HORAS NORMALES
                    dNodoHoras = New DevComponents.AdvTree.Node
                    dNodoHoras.Text = "Horas normales"
                    dNodoHoras.Cells.Add(New DevComponents.AdvTree.Cell(DtoH(NormalesCC)))
                    dNodoHoras.Name = "hrsNormales" & dNodoCentroCostos.Text

                    dNodoHoras.Selectable = False
                    dNodoHoras.Style = EstiloRegular
                    dNodoHoras.Cells(1).StyleNormal = EstiloRegularDerecha
                    dNodoHoras.Tag = "HORAS"
                    dNodoHoras.FullRowBackground = True
                    dNodoTotal.Nodes.Add(dNodoHoras)

                    'TOTAL HORAS EXTRAS
                    dNodoHoras = New DevComponents.AdvTree.Node
                    dNodoHoras.Style = EstiloRegular
                    dNodoHoras.Text = "Horas extras"
                    dNodoHoras.Tag = "HORAS"
                    dNodoHoras.Selectable = False
                    dNodoHoras.Cells.Add(New DevComponents.AdvTree.Cell(DtoH(ExtrasCC)))
                    dNodoHoras.Cells(1).StyleNormal = EstiloRegularDerecha
                    dNodoTotal.Nodes.Add(dNodoHoras)


                    dNodoHoras = New DevComponents.AdvTree.Node
                    dNodoHoras.Style = EstiloRegular
                    dNodoHoras.Text = "Órdenes"
                    dNodoHoras.Tag = "HORAS"
                    dNodoHoras.Selectable = False
                    dNodoHoras.Cells.Add(New DevComponents.AdvTree.Cell(DtoH(Math.Round(TotalCC, 2))))
                    dNodoHoras.Cells(1).StyleNormal = EstiloRegularDerecha


                    'Columnas de horas por orden
                    dNodoHoras.NodesColumnsHeaderVisible = True

                    'Columnas de horas por orden
                    dNodoHoras.NodesColumnsHeaderVisible = True
                    dNodoHoras.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("Orden"))
                    dNodoHoras.NodesColumns.Add(New DevComponents.AdvTree.ColumnHeader("Horas"))

                    dNodoHoras.NodesColumns(0).Width.Relative = 55
                    dNodoHoras.NodesColumns(1).Width.Relative = 30

                    If CentroCostos.Trim = "22522" Then
                        Dim i As Integer = 1
                    End If

                    Dim q_totales As String =
                    " SELECT " & _
                    " '" & CentroCostos.Trim & "' as centro_costos," & _
                    " time_allocation.cod_orden as orden, " & _
                    " sum(time_allocation.horas) as horas" & _
                    " from time_allocation " & _
                    " where time_allocation.cod_depto like '%" & CentroCostos.Trim & "%' and time_allocation.fecha = '" & FechaSQL(txtFecha.Value) & "' " & _
                    " group by time_allocation.cod_orden"

                    'Dim dtTotalesOrden As DataTable = sqlExecute("select personalvw.centro_costos, time_allocation.cod_orden as orden, (sum(time_allocation.horas)) as horas from time_allocation left join PERSONAL.dbo.personalvw on personalvw.reloj = time_allocation.reloj where fecha = '" & FechaSQL(txtFecha.Value) & "' and PersonalVW.centro_costos = '" & CentroCostos & "' group by personalvw.centro_costos, time_allocation.COD_ORDEN", "TA")

                    Dim dtTotalesOrden As DataTable = sqlExecute(q_totales, "TA")

                    For Each row As DataRow In dtTotalesOrden.Rows
                        Dim nd As New DevComponents.AdvTree.Node
                        'dNodoTotalesCC(N) = New DevComponents.AdvTree.Node
                        nd.Style = EstiloRegular
                        nd.Text = row("orden").ToString.Trim
                        nd.Tag = "ORDEN"
                        nd.Cells.Add(New DevComponents.AdvTree.Cell(row("horas")))
                        nd.Cells(1).Text = DtoH(nd.Cells(1).Text)
                        nd.Cells(1).StyleNormal = EstiloRegularDerecha

                        nd.Selectable = False
                        nd.Name = "Totalorden" & row("orden").ToString.Trim

                        dNodoHoras.Nodes.Add(nd)
                    Next
                    dNodoTotal.Nodes.Add(dNodoHoras)

                    'For Each nd As DevComponents.AdvTree.Node In dNodoTotalesCC
                    '    If Not nd Is Nothing Then
                    '        nd.Cells(1).Text = DtoH(nd.Cells(1).Text)
                    '        dNodoHoras.Nodes.Add(nd)
                    '    End If
                    'Next
                    'dNodoTotal.Nodes.Add(dNodoHoras)


                    TotalCC = Math.Round(NormalesCC + ExtrasCC - TotalCC, 2)
                    '****** Nodo de diferencia ******
                    dNodoHoras = New DevComponents.AdvTree.Node
                    dNodoHoras.Text = "DIFERENCIA"
                    dNodoHoras.Tag = "HORAS"
                    dNodoHoras.Selectable = False
                    If TotalCC = 0 Then
                        dNodoHoras.Style = EstiloDiferencia0
                    ElseIf TotalCC > 0 Then
                        dNodoHoras.Style = EstiloDiferenciaPositiva
                    Else
                        dNodoHoras.Style = EstiloDiferenciaNegativa
                    End If
                    'dNodoHoras.FullRowBackground = True
                    dNodoHoras.Cells.Add(New DevComponents.AdvTree.Cell(DtoH(TotalCC)))
                    dNodoHoras.Cells(1).StyleNormal = EstiloRegularDerecha
                    dNodoTotal.Nodes.Add(dNodoHoras)
                    '***********************************

                    dNodoCentroCostos.Nodes.Insert(0, dNodoTotal)
                    treGrupos.Nodes.Add(dNodoCentroCostos)
                End If
            Next

            If dtTimeAllocation.Rows.Count = 0 Then
                MessageBox.Show("No hay registros de órdenes de trabajo y/o asistencias en el día " & FechaLetra(txtFecha.Value) & _
                                ", para el usuario " & Usuario.Trim & ".", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub FiltraTAlloc(ByVal dtOrigen As DataTable, ByRef dtDestino As DataTable, ByVal Filtro As String)
        Dim Cumple As Boolean
        Dim ValorBusca As String
        Dim Campos(,) As String
        Dim CamposFiltro() As String
        Dim i As Integer
        Dim x As Integer
        Try
            CamposFiltro = Filtro.Split("[")
            ReDim Campos(2, CamposFiltro.GetUpperBound(0))

            i = 0
            For Each Campo In CamposFiltro
                x = Campo.IndexOf("]")
                If x > 0 Then
                    Campos(1, i) = Campo.Substring(0, x)
                    Campos(2, i) = Campo.Substring(x + 1)
                    Campos(2, i) = Campos(2, i).Replace("AND", "")
                    Campos(2, i) = Campos(2, i).Replace("]", "")
                    i += 1

                End If
            Next

            For Each dRow As DataRow In dtOrigen.Rows
                bgCargaFecha_ProgressChanged("Analizando " & dRow("reloj"))

                Cumple = True
                For x = 0 To Campos.GetUpperBound(1)
                    If Not Campos(1, x) Is Nothing Then

                        ValorBusca = "'" & ValorBitacora(dRow("RELOJ"), Campos(1, x), Fecha).Trim & "'"
                        If Not Campos(2, x).Contains(ValorBusca) Then
                            Cumple = False
                            Exit For
                        End If
                    End If
                Next

                If Cumple Then
                    dtDestino.ImportRow(dRow)
                End If
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub AgrupaOrden(ByVal CentroCostos As String, ByVal Turno As String, ByVal Departamento As String, ByVal Super As String, ByVal Orden As String, ByVal Horas As String)
        Dim dReg As DataRow
        Try
            'MCR 20/Ene/2016
            'Cambiar grupos, en lugar de CC-Depto-Turno, será CC-Turno-Depto
            dReg = dtGruposTAlloc.Rows.Find({CentroCostos, Turno, Departamento, Super, Orden})
            If dReg Is Nothing Then
                dReg = dtGruposTAlloc.NewRow
                dReg("centro_costos") = CentroCostos
                dReg("cod_depto") = Departamento
                dReg("cod_super") = Super
                dReg("cod_turno") = Turno
                dReg("orden") = Orden
                dReg("horas") = 0
                dReg("empleados") = 0
                dtGruposTAlloc.Rows.Add(dReg)

            End If
            dReg("horas") += HtoDecimalCompleto(Horas)
            dReg("empleados") += 1
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub bgCargaFecha_ProgressChanged(e As String)
        If e.Contains("GRUPO") Then
            lblAvance.Text = " TOTALIZANDO " & vbCrLf & e
        Else
            lblAvance.Text = "... PREPARANDO ..." & vbCrLf & e
            pbAvance.Value += 1
        End If
        Application.DoEvents()
    End Sub

    Private Sub bgCargaFecha_RunWorkerCompleted()
        Try
            'MCR 4/NOV/2015
            'Mostrar fecha/hora de la última vez que se actualizó la información en pantalla
            lblUltActualizacion.Text = "Información actualizada al: " & Now.ToString

            pbAvance.IsRunning = False
            gpAvance.Visible = False
            pnlEncabezado.Enabled = True
            My.Application.DoEvents()
            If treGrupos.Nodes.Count > 0 Then
                If AntNode Is Nothing Then
                    treGrupos.SelectedNode = treGrupos.Nodes(0)
                    treGrupos.Nodes(0).RaiseClick()
                Else
                    treGrupos.SelectedNode = treGrupos.FindNodeByName(AntNode.Name)

                    If Not treGrupos.SelectedNode.Parent Is Nothing Then
                        If Not treGrupos.SelectedNode.Parent.Parent Is Nothing Then
                            treGrupos.SelectedNode.Parent.Parent.ExpandAll()
                        End If
                        treGrupos.SelectedNode.Parent.ExpandAll()

                    End If
                    'treGrupos.SelectedNode = AntNode
                    treGrupos.SelectedNode.ExpandAll()
                    treGrupos.SelectedNode.RaiseClick()
                    AntNode = Nothing
                    'treGrupos.SelectedNode = treGrupos.Nodes(1)
                End If
                'treGrupos.Refresh()
            End If

            My.Application.DoEvents()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub frmTimeAllocation_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        gpAvance.Left = (Me.Width - gpAvance.Width) / 2
        pnlCentrarControles.Left = (Me.Width - pnlCentrarControles.Width) / 2
    End Sub

    Private Sub frmTimeAllocation_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'txtFecha.Value = Now.AddDays(-1)
        If Cargando Then
            btnMostrarInformacion.PerformClick()
            Cargando = False
        End If
    End Sub

    Private Sub btnMostrarInformacion_Click(sender As Object, e As EventArgs) Handles btnMostrarInformacion.Click
        Try
            AntNode = treGrupos.SelectedNode

            gpAvance.Visible = True
            pbAvance.IsRunning = True
            pnlEncabezado.Enabled = False
            lblAvance.Text = "Preparando información"
            'bgCargaFecha.WorkerReportsProgress = True
            bgCargaFecha_DoWork()
            bgCargaFecha_RunWorkerCompleted()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtHoras_LostFocus(sender As Object, e As EventArgs) Handles txtHoras.LostFocus
        Try
            txtHoras.Text = CtoM(txtHoras.Text)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgPersonal_ColumnHeaderMouseEnter(sender As Object, e As GridColumnHeaderEventArgs) Handles dgPersonal.ColumnHeaderMouseEnter
        AsignarHorasOrdenToolStripMenuItem.Visible = True
    End Sub

    Private Sub AsignarHorasEmpleadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsignarHorasEmpleadoToolStripMenuItem.Click
        AsignarHoras(sender.tag.ToString)
    End Sub

    Private Sub TurnoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        AsignarHoras(sender.tag.ToString)
    End Sub
    Private Sub DepartamentoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        AsignarHoras(sender.tag.ToString)
    End Sub

    Private Sub TodosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        AsignarHoras(sender.tag.ToString)
    End Sub

    Private Sub AsignarHoras(ByVal Filtro As String)
        Try
            Dim Total As Double
            Dim Diferencia As Double
            Dim Horas As Double
            Dim Orden As String
            Dim Limite As Double

            Dim CentroCostos As String
            Dim Depto As String = ""
            Dim Super As String = ""
            Dim Turno As String = ""
            Dim FiltroCC As Boolean = False

            Dim dtAsist As New DataTable
            Dim dtBitacora As New DataTable
            Dim dRAsist As DataRow

            If Not Filtro.Contains("/") Then Exit Sub
            If Filtro.Contains("/CC") Then
                FiltroCC = True
                Filtro = Filtro.Replace("/CC", "/")
            End If
            Orden = Filtro.Substring(Filtro.IndexOf("/"))
            Filtro = Filtro.Replace(Orden, "")
            Orden = Orden.Replace("/", "")

            frmTrabajando.Text = "Asignar horas"
            frmTrabajando.lblAvance.Text = "Procesando información"
            frmTrabajando.Avance.IsRunning = True
            frmTrabajando.Show(Me)

            CentroCostos = dgPersonal.PrimaryGrid.Columns("colCodCC").FilterExpr
            If CentroCostos.Contains("'") Then
                CentroCostos = CentroCostos.Substring(CentroCostos.IndexOf("'"))
                CentroCostos = "centro_costos = " & CentroCostos
            End If

            If Not FiltroCC Then

                If dgPersonal.PrimaryGrid.Columns("colCodDepto").FilterExpr Is Nothing Then
                    Depto = ""
                Else

                    Depto = dgPersonal.PrimaryGrid.Columns("colCodDepto").FilterExpr
                    If Depto.Contains("'") Then
                        Depto = Depto.Substring(Depto.IndexOf("'"))
                        Depto = "cod_depto = " & Depto
                    End If

                    Super = dgPersonal.PrimaryGrid.Columns("colCodSuper").FilterExpr
                    If Super.Contains("'") Then
                        Super = Super.Substring(Super.IndexOf("'"))
                        Super = "cod_super = " & Super
                    End If
                End If


                If dgPersonal.PrimaryGrid.Columns("colCodTurno").FilterExpr Is Nothing Then
                    Turno = ""
                Else
                    Turno = dgPersonal.PrimaryGrid.Columns("colCodTurno").FilterExpr
                    If Turno.Contains("'") Then
                        Turno = Turno.Substring(Turno.IndexOf("'"))
                        Turno = "cod_Turno = " & Turno
                    End If
                End If
            End If

            Filtro = Filtro & IIf(Filtro.Length > 0 And CentroCostos.Length > 0, " AND ", "") & CentroCostos
            Filtro = Filtro & IIf(Filtro.Length > 0 And Depto.Length > 0, " AND ", "") & Depto
            Filtro = Filtro & IIf(Filtro.Length > 0 And Turno.Length > 0, " AND ", "") & Turno
            Filtro = Filtro & IIf(Filtro.Length > 0 And Super.Length > 0, " AND ", "") & Super

            frmTrabajando.Text = Filtro
            frmTrabajando.Avance.IsRunning = False
            frmTrabajando.Avance.Maximum = dtTimeAllocation.Select(Filtro).Count
            My.Application.DoEvents()

            For Each dRow As DataRow In dtTimeAllocation.Select(Filtro)
                frmTrabajando.Avance.Value += 1
                If IIf(IsDBNull(dRow(Orden)), "00:00", dRow(Orden)) <> txtHoras.Text Then
                    'Guardar en time_allocation
                    Reloj = dRow("reloj").ToString.Trim

                    frmTrabajando.lblAvance.Text = Reloj
                    My.Application.DoEvents()

                    dtTemporal = sqlExecute("SELECT SUM(horas) as total FROM time_allocation WHERE reloj = '" & Reloj & "' AND " & _
                                      "fecha = '" & FechaSQL(txtFecha.Value) & "' AND cod_orden <> '" & Orden & "'", "TA")

                    If dtTemporal.Rows.Count > 0 Then
                        Total = IIf(IsDBNull(dtTemporal.Rows(0).Item("total")), 0, dtTemporal.Rows(0).Item("total"))
                    Else
                        Total = 0
                    End If

                    Limite = (HtoDecimalCompleto(dRow("horas_normales")) + HtoDecimalCompleto(dRow("horas_extras"))) - Total
                    'If Limite < 0 Then Stop
                    Limite = IIf(Limite < 0, 0, Limite)

                    Horas = HtoDecimalCompleto(txtHoras.Text)

                    If Horas > Limite Then
                        Horas = Limite
                        If Not (Horas = 0 And IIf(IsDBNull(dRow(Orden)), "00:00", dRow(Orden)) = "00:00") Then
                            dRow(Orden) = DtoH(Horas)
                        End If

                    Else
                        dRow(Orden) = txtHoras.Text
                    End If


                    If Math.Round(Horas, 4) = 0 Then
                        'Si las horas están en 0, borrar el registro para optimizar espacio
                        sqlExecute("DELETE FROM time_allocation WHERE reloj = '" & Reloj & "' AND " & _
                                   "fecha = '" & FechaSQL(txtFecha.Value) & "' AND cod_orden = '" & Orden & "'", "TA")

                        Try
                            sqlExecute("insert into ta.dbo.registro_borradas (reloj, orden, fecha) values ('" & Reloj & "', '" & Orden & "', '" & FechaSQL(txtFecha.Value) & "')")
                        Catch ex As Exception

                        End Try

                    Else
                        dtOrdenEmp = sqlExecute("SELECT horas FROM time_allocation WHERE reloj = '" & Reloj & "' AND " & _
                                                "fecha = '" & FechaSQL(txtFecha.Value) & "' AND cod_orden = '" & Orden & "'", "TA")
                        If dtOrdenEmp.Rows.Count > 0 Then
                            sqlExecute("UPDATE time_allocation SET " & _
                                       "horas = " & Horas & _
                                       ",usuario = '" & Usuario & _
                                       "',fecha_hora = GETDATE() WHERE reloj = '" & Reloj & "' AND " & _
                                       "fecha = '" & FechaSQL(txtFecha.Value) & "' AND cod_orden = '" & Orden & "'", "TA")
                        Else

                            dtAsist = sqlExecute("SELECT cod_comp,cod_depto,cod_super,cod_turno,cod_clase FROM asist WHERE reloj = '" & Reloj & _
                                                 "' AND fha_ent_hor = '" & FechaSQL(txtFecha.Value) & "'", "TA")
                            If dtAsist.Rows.Count > 0 Then
                                dRAsist = dtAsist.Rows(0)
                            Else
                                dtAsist = sqlExecute("SELECT cod_comp,cod_depto,cod_super,cod_turno,cod_clase FROM personal WHERE reloj = '" & Reloj & "'")
                                dRAsist = dtAsist.Rows(0)
                            End If

                            dtBitacora = sqlExecute("SELECT ISNULL((SELECT TOP 1 case  ISNULL(VALORNUEVO,'') WHEN '' THEN NULL ELSE VALORNUEVO END FROM " & _
                                                   "BITACORA_PERSONAL WHERE RELOJ = '" & Reloj & "' AND CAMPO = 'COD_PLANTA' AND " & _
                                                   "CONVERT(CHAR (10),FECHA) <= '" & FechaSQL(txtFecha.Value) & "' ORDER BY FECHA DESC),PERSONAL.COD_PLANTA) " & _
                                                   "FROM PERSONAL WHERE RELOJ = '" & Reloj & "'")

                            If dtBitacora.Rows.Count = 0 Then
                                sqlExecute("INSERT INTO time_allocation (reloj,cod_orden,fecha,horas,cod_comp,cod_planta,cod_depto,cod_super,cod_turno,cod_clase,usuario,fecha_hora) " & _
                                           "VALUES ('" & Reloj & "','" & _
                                           Orden & "','" & _
                                           FechaSQL(txtFecha.Value) & "'," & _
                                           Horas & _
                                           ",'" & dRAsist("cod_comp") & "'," & _
                                           "''," & _
                                           "'" & dRAsist("cod_depto") & "'," & _
                                           "'" & dRAsist("cod_super") & "'," & _
                                           "'" & dRAsist("cod_turno") & "'," & _
                                           "'" & dRAsist("cod_clase") & "'," & _
                                           "'" & Usuario & "'," & _
                                           "getdate()" & _
                                           ")", "TA")
                            Else

                                sqlExecute("INSERT INTO time_allocation (reloj,cod_orden,fecha,horas,cod_comp,cod_planta,cod_depto,cod_super,cod_turno,cod_clase,usuario,fecha_hora) " & _
                                              "VALUES ('" & Reloj & "','" & _
                                              Orden & "','" & _
                                              FechaSQL(txtFecha.Value) & "'," & _
                                              Horas & _
                                              ",'" & dRAsist("cod_comp") & "'," & _
                                              "'" & dtBitacora.Rows(0).Item(0) & "'," & _
                                              "'" & dRAsist("cod_depto") & "'," & _
                                              "'" & dRAsist("cod_super") & "'," & _
                                              "'" & dRAsist("cod_turno") & "'," & _
                                              "'" & dRAsist("cod_clase") & "'," & _
                                              "'" & Usuario & "'," & _
                                              "getdate()" & _
                                              ")", "TA")
                            End If
                        End If
                    End If
                    Total += Horas
                    dRow("total") = DtoH(Total)
                    dRow("diferencia") = DtoH((HtoDecimalCompleto(dRow("horas_normales")) + HtoDecimalCompleto(dRow("horas_extras"))) - Total)
                End If
            Next

            frmTrabajando.lblAvance.Text = "Configurando..."
            frmTrabajando.Avance.Value = 0
            My.Application.DoEvents()


            For Each gRow In dgPersonal.PrimaryGrid.FlatRows
                If Not TypeOf gRow Is GridGroup Then
                    Diferencia = HtoDecimalCompleto(gRow.Cells("colDiferencia").value)
                    gRow.Cells("colDiferencia").CellStyles.Default.Background.Color1 = IIf(Diferencia = 0, Color.Green, IIf(Diferencia > 0, SystemColors.GradientInactiveCaption, Color.Red))
                    gRow.Cells("colDiferencia").CellStyles.ReadOnly.TextColor = IIf(Diferencia > 0, SystemColors.ControlText, Color.White)
                End If
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            ActivoTrabajando = False
            frmTrabajando.Avance.IsRunning = False
            frmTrabajando.Close()
        End Try
    End Sub


    Public Function HtoDecimalCompleto(Hora As String) As Double
        Try

            Hora = Trim(Hora)

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

    Private Sub treGrupos_AfterExpand(sender As Object, e As DevComponents.AdvTree.AdvTreeNodeEventArgs) Handles treGrupos.AfterExpand
        If e.Node.Parent Is Nothing Then
            For Each Nd As DevComponents.AdvTree.Node In treGrupos.Nodes
                If Not Nd Is e.Node Then
                    Nd.Collapse()
                Else
                    Nd.ExpandAll()
                End If
            Next
        End If

    End Sub

    Private Sub treGrupos_Click(sender As Object, e As EventArgs) Handles treGrupos.Click

    End Sub

    Private Sub treGrupos_NodeClick(sender As Object, e As DevComponents.AdvTree.TreeNodeMouseEventArgs) Handles treGrupos.NodeClick

        Dim Visible As Boolean

        Try
            TipoNodo = e.Node.Name.ToUpper.Substring(0, 5)
            dgPersonal.PrimaryGrid.FilterMatchType = FilterMatchType.Wildcards

            Select Case TipoNodo
                Case "CENTR"
                    'Centro de costos
                    NodoCentroCostos = e.Node
                    NodoDepto = NodoCentroCostos.Nodes(0)                    
                    NodoTurno = NodoDepto.Nodes(0)
                    dgPersonal.PrimaryGrid.Columns("colCodCC").FilterExpr = "[colCodCC] IS '" & NodoCentroCostos.Tag & "'"
                    dgPersonal.PrimaryGrid.Columns("colCodDepto").FilterExpr = ""
                    dgPersonal.PrimaryGrid.Columns("colCodTurno").FilterExpr = ""
                    dgPersonal.PrimaryGrid.Columns("colCodSuper").FilterExpr = ""
                Case "TURNO"
                    NodoCentroCostos = e.Node.Parent
                    NodoTurno = e.Node
                    NodoDepto = NodoTurno.Nodes(0)                    
                    dgPersonal.PrimaryGrid.Columns("colCodCC").FilterExpr = "[colCodCC] IS '" & NodoCentroCostos.Tag & "'"
                    dgPersonal.PrimaryGrid.Columns("colCodTurno").FilterExpr = "[colCodTurno] IS '" & NodoTurno.Tag & "'"
                    dgPersonal.PrimaryGrid.Columns("colCodDepto").FilterExpr = ""
                    dgPersonal.PrimaryGrid.Columns("colCodSuper").FilterExpr = ""
                Case "DEPTO"
                    NodoDepto = e.Node                    
                    NodoTurno = NodoDepto.Parent
                    NodoCentroCostos = NodoTurno.Parent
                    dgPersonal.PrimaryGrid.Columns("colCodCC").FilterExpr = "[colCodCC] IS '" & NodoCentroCostos.Tag & "'"
                    dgPersonal.PrimaryGrid.Columns("colCodTurno").FilterExpr = "[colCodTurno] IS '" & NodoTurno.Tag & "'"
                    dgPersonal.PrimaryGrid.Columns("colCodDepto").FilterExpr = "[colCodDepto] IS '" & NodoDepto.Tag & "'"
                    dgPersonal.PrimaryGrid.Columns("colCodSuper").FilterExpr = "[colCodSuper] IS '" & NodoDepto.AccessibleDescription & "'"
                Case Else
                    Exit Sub
            End Select
            'Ocultar las columnas que no tienen horas para ese centro de costos
            'solo dejar las que aplican
            For Each dCol As DevComponents.DotNetBar.SuperGrid.GridColumn In dgPersonal.PrimaryGrid.Columns
                If dCol.Name.StartsWith("colOrden") Then
                    dtTemporal = sqlExecute("SELECT cod_orden FROM ordenes_cc WHERE centro_costos = '" & NodoCentroCostos.Tag & "' AND cod_orden = '" & dCol.HeaderText & "'", "TA")
                    Visible = dtTemporal.Rows.Count > 0
                    'If dCol.HeaderText = "000710725" Then Stop
                    If Not Visible Then
                        For Each dRow As DevComponents.DotNetBar.SuperGrid.GridRow In dgPersonal.PrimaryGrid.Rows
                            If IIf(IsDBNull(dRow(dCol).Value), "00:00", dRow(dCol).Value) <> "00:00" And dRow("colCodCC").Value = NodoCentroCostos.Tag Then
                                Visible = True
                                Exit For
                            End If
                        Next
                    End If
                    'If Visible = False Then Stop
                    dCol.Visible = Visible
                End If
            Next

            If e.Node.Parent Is Nothing Then
                For Each Nd As DevComponents.AdvTree.Node In treGrupos.Nodes
                    If Not Nd Is e.Node Then
                        Nd.Collapse()
                    Else
                        Nd.ExpandAll()
                    End If
                Next
            Else

                For Each Nd As DevComponents.AdvTree.Node In e.Node.Parent.Nodes
                    If Not Nd Is e.Node Then
                        Nd.Collapse()
                    Else
                        Nd.ExpandAll()
                    End If
                Next
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgPersonal_FilterPopupOpening(sender As Object, e As GridFilterPopupOpeningEventArgs) Handles dgPersonal.FilterPopupOpening
        'Cancelar para no permitir el popup, ya que el filtro se aplica por código
        e.Cancel = True
    End Sub

    Private Sub dgPersonal_Click(sender As Object, e As EventArgs) Handles dgPersonal.Click

    End Sub

    Private Sub treGrupos_Resize(sender As Object, e As EventArgs) Handles treGrupos.Resize
        Try

            For Each itCentroCostos In treGrupos.Nodes
                For Each itDepto In itCentroCostos.Nodes
                    If itDepto.nodescolumns.count > 0 Then
                        itDepto.nodescolumns(0).width.autosize = True
                        itDepto.nodescolumns(0).width.autosize = False
                    End If

                    For Each itTurno In itDepto.Nodes
                        If itTurno.nodescolumns.count > 0 Then
                            itTurno.nodescolumns(0).width.autosize = True
                            itTurno.nodescolumns(0).width.autosize = False
                        End If
                        For Each itHoras In itTurno.Nodes
                            If itHoras.nodescolumns.count > 0 Then
                                itHoras.nodescolumns(0).width.autosize = True
                                itHoras.nodescolumns(0).width.autosize = False
                            End If

                            For Each itOrden In itHoras.nodes
                                If itOrden.nodescolumns.count > 0 Then
                                    itOrden.nodescolumns(0).width.autosize = True
                                    itOrden.nodescolumns(0).width.autosize = False
                                End If
                            Next
                        Next
                    Next
                Next

            Next
            treGrupos.RefreshItems()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub BorrarOrdenDeTrabajoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BorrarOrdenDeTrabajoToolStripMenuItem.Click
        Try
            Dim CC As String
            Dim NumOrden As String
            Dim Borrar As Boolean = True
            Dim Hrs As String

            NumOrden = sender.tag.ToString.Replace("/", "")
            CC = NodoCentroCostos.Tag.trim

            dtTemporal = sqlExecute("SELECT asignadas FROM timeAllocationVW WHERE cod_orden = '" & NumOrden & "' AND centro_costosTA = '" & CC & _
                                    "' AND fecha >= '" & FechaSQL(DateAdd(DateInterval.Day, -7, txtFecha.Value)) & "'", "TA")

            If dtTemporal.Rows.Count > 0 Then
                If MessageBox.Show("Se " & IIf(dtTemporal.Rows.Count = 1, "localizó 1 registro", "localizaron " & dtTemporal.Rows.Count & " registros") & " a esta orden en la última semana. ¿Está seguro de querer borrar la orden " & NumOrden & "?", _
                                "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Borrar = False
                End If
            End If
            If Borrar Then
                'Tomar el dato que tenía txtHoras, para devolverlo al final
                Hrs = txtHoras.Text
                'Poner en 0 txtHoras, para que el procedimiento AsignarHoras lo tome
                txtHoras.Text = "00:00"
                sqlExecute("DELETE FROM ordenes_cc WHERE  cod_orden = '" & NumOrden & "' AND centro_costos = '" & CC & "'", "TA")
                'Al asignar 0 horas, se borra el registro
                AsignarHoras("/CC" & NumOrden)
                dgPersonal.PrimaryGrid.Columns.Remove(dgPersonal.PrimaryGrid.Columns("colOrden" & NumOrden))
                txtHoras.Text = Hrs
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click

    End Sub

    Private Sub picFestivo_Click(sender As Object, e As EventArgs) Handles picFestivo.Click

    End Sub

   
End Class
