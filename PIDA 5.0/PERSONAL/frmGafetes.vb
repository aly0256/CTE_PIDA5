'MCR 19/NOV/2015
Public Class frmGafetes

    Dim dtGafetes As New DataTable
    Dim dtCambios As New DataTable
    Dim Editar As Boolean

    Private Sub frmGafetes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtGafetes = ConsultaPersonalVW("SELECT reloj,gafete,foto,nombres,cod_comp,cod_planta,nombre_planta,cod_depto,nombre_depto,cod_turno,nombre_turno,cod_super,nombre_super,cod_tipo,nombre_tipoEmp " & _
                                   "FROM personalvw", False)
            dtGafetes.Columns.Add("imprimir", GetType(System.Boolean), False)
            dtGafetes.Columns.Add("ExisteFoto", GetType(System.Boolean))

            'My.Application.DoEvents()
            'For Each dRec As DataRow In dtGafetes.Rows
            '    dRec("ExisteFoto") = My.Computer.FileSystem.FileExists(dRec("foto"))
            'Next
            'My.Application.DoEvents()

            dgGafetes.PrimaryGrid.DataSource = dtGafetes
            dgGafetes.PrimaryGrid.AutoGenerateColumns = False
            SetSwitchText(dgGafetes.PrimaryGrid.Columns("Imprimir").EditControl)
            SetSwitchText(dgGafetes.PrimaryGrid.Columns("Imprimir").RenderControl)
            ' SetCheckOptions(dgGafetes.PrimaryGrid.Columns("Imprimir").FilterEditType)

            Dim dtReportes As New DataTable
            dtReportes = sqlExecute("SELECT nombre FROM permisos WHERE cod_perfil " & Perfil & " and control LIKE '%GAFETE%' AND tipo = 'R' and modulo = 'PER' AND acceso = 1", "SEGURIDAD")
            btnReporte.SubItems.Clear()
            Dim btnIt As DevComponents.DotNetBar.ButtonItem
            For Each dRep As DataRow In dtReportes.Rows
                btnIt = New DevComponents.DotNetBar.ButtonItem
                btnIt.Text = dRep("nombre")
                btnIt.Image = My.Resources.bullet_blue16
                AddHandler btnIt.Click, AddressOf GenerarReporte
                btnReporte.SubItems.Add(btnIt)
            Next
            Editar = False
            HabilitarControles()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub dgGafetes_CellValidating(sender As Object, e As DevComponents.DotNetBar.SuperGrid.GridCellValidatingEventArgs) Handles dgGafetes.CellValidating
        Try
            Dim Gafete As String
            Gafete = IIf(IsDBNull(e.Value), "", e.Value)
            If Gafete.Length > 10 Then
                MessageBox.Show("La longitud del gafete debe ser de máximo 10 dígitos. Favor de verificar.", "Gafete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                e.Cancel = True
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgGafetes_CellValueChanged(sender As Object, e As DevComponents.DotNetBar.SuperGrid.GridCellValueChangedEventArgs) Handles dgGafetes.CellValueChanged
        Try
            If e.GridCell.GridColumn.Name = "Gafete" Then
                Dim Nvo As String
                Dim Ant As String
                Ant = IIf(IsDBNull(e.OldValue), "", e.OldValue)
                Nvo = IIf(IsDBNull(e.NewValue), "", e.NewValue)
                If Ant = Nvo Then
                    e.GridCell.GridRow.RowDirty = False
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try
            Dim Gafete As String

            For Each drows As DevComponents.DotNetBar.SuperGrid.GridRow In dgGafetes.PrimaryGrid.Rows
                If drows.RowDirty And Not drows.GetCell("Gafete") Is Nothing Then
                    Gafete = drows.GetCell("Gafete").Value
                    sqlExecute("INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento) " & _
                            "SELECT reloj,'GAFETE',gafete,'" & Gafete & "','Pida',getdate(),'C' from personal where reloj = '" & drows.GetCell("Reloj").Value & "'")
                    sqlExecute("UPDATE personal SET gafete = '" & Gafete & "' WHERE reloj = '" & drows.GetCell("Reloj").Value & "'")
                    drows.RowDirty = False
                End If
            Next
            Editar = False
            HabilitarControles()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            Editar = Not Editar

            HabilitarControles()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub HabilitarControles()
        Try
            btnNuevo.Visible = Editar

            If Editar Then
                btnNuevo.Image = My.Resources.Ok16
                btnEditar.Image = My.Resources.Cancel16

                btnNuevo.Text = "Aceptar"
                btnEditar.Text = "Cancelar"
            Else
                btnNuevo.Image = My.Resources.NewRecord
                btnEditar.Image = My.Resources.Edit

                btnNuevo.Text = "Agregar"
                btnEditar.Text = "Editar"
            End If

            btnReporte.Visible = Not Editar
            btnCerrar.Visible = Not Editar

            dgGafetes.PrimaryGrid.Columns("Gafete").ReadOnly = Not Editar
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub frmGafetes_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        pnlCentrarControles.Left = (pnlNavegacion.Width - pnlCentrarControles.Width) / 2
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                For Each dIt As DevComponents.DotNetBar.SuperGrid.GridRow In dgGafetes.PrimaryGrid.Rows
                    If dIt("Reloj").Value = Reloj Then
                        dIt.IsSelected = True
                        dIt.ScrollToTop()
                        Exit For
                    End If
                Next
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub GenerarReporte(sender As Object, e As EventArgs)
        Try
            Dim dtInfo As New DataTable
            Dim dtDatosPersonal As New DataTable
            Dim i As Integer
            Dim Nombre As String

            Dim ArRelojes() As String
            Dim Relojes As String

            Nombre = sender.text.ToString.Trim
            sqlExecute("UPDATE reportes SET veces_acceso = veces_acceso + 1, fecha = GETDATE()   WHERE nombre = '" & Nombre & "'")

            dtTemporal = sqlExecute("SELECT COUNT(nombre) AS cuantos FROM reportes_recientes WHERE usuario = '" & Usuario & "'")
            If dtTemporal.Rows.Item(0).Item("cuantos") = 10 Then
                sqlExecute("DELETE FROM reportes_recientes WHERE fecha = (SELECT MIN(fecha) FROM reportes_recientes WHERE usuario = '" & Usuario & "') AND usuario = '" & Usuario & "'")
            End If

            dtTemporal = sqlExecute("SELECT nombre FROM reportes_recientes WHERE usuario = '" & Usuario & "' AND nombre = '" & Nombre & "'")
            If dtTemporal.Rows.Count > 0 Then
                sqlExecute("UPDATE reportes_recientes SET fecha = GETDATE() WHERE usuario = '" & Usuario & "' AND nombre = '" & Nombre & "'")
            Else
                sqlExecute("INSERT INTO reportes_recientes (usuario,fecha,nombre) VALUES ('" & Usuario & "',GETDATE(),'" & Nombre & "')")
            End If

            ReDim ArRelojes(dgGafetes.PrimaryGrid.Rows.Count - 1)
            i = 0
            For Each dIt As DevComponents.DotNetBar.SuperGrid.GridRow In dgGafetes.PrimaryGrid.Rows
                If IIf(IsDBNull(dIt(2).Value), False, dIt(2).Value) Then
                    ArRelojes(i) = "'" & dIt("Reloj").Value.ToString.Trim & "'"
                    i += 1
                End If
            Next
            i -= 1
            ReDim Preserve ArRelojes(i)
            Relojes = Join(ArRelojes, ",")

            If Relojes = "" Then Relojes = "''"

            '**** CARGAR PERSONALVW PARA ESTE EMPLEADO
            dtDatosPersonal = sqlExecute("SELECT * FROM personalVW WHERE reloj IN (" & Relojes & ")")
            dtInfo = dtDatosPersonal.Clone

            If dtDatosPersonal.Rows.Count = 0 Then
                MessageBox.Show("No hay información seleccionada para imprimir gafete. Favor de verificar.", "Imprimir", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                Exit Sub
            End If
            Dim dRow As DataRow
            'dtInfo.Columns(0).ColumnName = dtInfo.Columns(0).ColumnName.ToLower
            dRow = dtDatosPersonal.Rows(0)
            frmTrabajando.lblAvance.Text = "Reloj " & dRow.Item("reloj")
            Application.DoEvents()

            For Each dRow In dtDatosPersonal.Select(FiltroXUsuario)
                dRow.Item("sactual") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("sactual"), 0)
                dRow.Item("integrado") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("integrado"), 0)
                dRow.Item("pro_var") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("pro_var"), 0)
                dRow.Item("factor_int") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("factor_int"), 0)
                dRow.Item("sal_ant") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("sal_ant"), 0)

                dtInfo.ImportRow(dRow)
            Next


            '**************************************************************
            dtFiltroPersonal = dtInfo.Copy

            ReporteadorFuente = "Personal"

            frmVistaPrevia.vwrReportes.LocalReport.EnableExternalImages = True

            frmVistaPrevia.LlamarReporte(Nombre, dtInfo)
            frmVistaPrevia.ShowDialog()
            Me.Show()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub SetSwitchText(ctl As DevComponents.DotNetBar.SuperGrid.GridSwitchButtonEditControl)
        Try
            If Not ctl Is Nothing Then
                ctl.OnText = "Sí"
                ctl.OffText = "No"
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
End Class