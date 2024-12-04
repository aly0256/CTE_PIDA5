Public Class frmOtrasSolicitudes
    Dim dtSolicitudes As DataTable
    Dim family As Integer


    Private Sub frmOtrasSolicitudes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtPlantas As New DataTable
        dtPlantas.Columns.Add("cod_planta")
        dtPlantas.Columns.Add("nombre")

        dtPlantas.Rows.Add({"001", "Juárez 1"})
        dtPlantas.Rows.Add({"002", "Juárez 2"})
        dtPlantas.Rows.Add({"***", "Todo"})

        cmbPlanta.DataSource = dtPlantas
        cmbPlanta.ValueMember = "cod_planta"
        cmbPlanta.DisplayMembers = "nombre"

        cmbPlanta.SelectedValue = "***"

    End Sub

    Private Sub ActualizarTabla(Optional planta As String = "")
        Try
            dgSolicitudes.AutoGenerateColumns = False
            If planta = "" Then
                dgSolicitudes.DataSource = sqlExecute("SELECT * FROM solicitudes" & IIf(chkTodas.Checked, "", " WHERE CONFIRMADO = '0'") & " ORDER BY fecha_sol desc, reloj asc", "KIOSCO")
            Else
                dgSolicitudes.DataSource = sqlExecute("SELECT solicitudes.* FROM solicitudes left join personal.dbo.personal on personal.reloj = solicitudes.reloj " & IIf(chkTodas.Checked, "", " WHERE solicitudes.CONFIRMADO = '0'") & " and personal.cod_planta = '" & planta & "' ORDER BY solicitudes.fecha_sol desc, solicitudes.reloj asc", "KIOSCO")
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub chkTodas_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodas.CheckedChanged
        ActualizarTabla()
    End Sub
    Private Sub dgPrestamos_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgSolicitudes.CellDoubleClick
        btnNuevo.PerformClick()
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try
            Dim Rlj As String = dgSolicitudes.SelectedCells.Item(1).Value.ToString
            Dim Art As String = dgSolicitudes.SelectedCells.Item(2).Value.ToString
            Dim costo As Double = dgSolicitudes.SelectedCells.Item(6).Value.ToString
            Dim r As Integer = MessageBox.Show("¿Este artículo se aplicará con costo de " & Format(costo, "c") & "?", "Aplicar costo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            If r = Windows.Forms.DialogResult.Yes Or r = Windows.Forms.DialogResult.No Then

                dtSolicitudes = sqlExecute("Select solicitudes.*,Vpersonal.*,'' as COSTO,'' AS DESCRIPCION  from solicitudes left join Vpersonal on solicitudes.Reloj = Vpersonal.Reloj Where solicitudes.Reloj = '" & Rlj & "' and solicitudes.Solicitud = '" & Art & "'", "KIOSCO")
                dtSolicitudes.Rows(0).Item("DESCRIPCION") = Art
                dtSolicitudes.Rows(0).Item("COSTO") = IIf(r = Windows.Forms.DialogResult.Yes, Format(costo, "c"), "N/A")

                frmVistaPrevia.LlamarReporte("Recibo de Herramienta", dtSolicitudes)
                frmVistaPrevia.ShowDialog()
                If Art.Trim.Equals("Gafete") Then
                    

                End If
                ActivityLog(Usuario, "APROBACION DE MISCELANEO", dgSolicitudes.SelectedCells.Item(1).Value.ToString, dgSolicitudes.SelectedCells.Item(2).Value.ToString)

                sqlExecute("UPDATE solicitudes SET CONFIRMADO = '1',EXPORTADO = '" & IIf(r = Windows.Forms.DialogResult.Yes, "0", "1") & "',FECHA_REV = '" & FechaSQL(Date.Now) & "'WHERE ID = '" & dgSolicitudes.SelectedCells.Item(0).Value.ToString & "' and reloj = '" & Rlj.Trim & "'", "KIOSCO")
                ActualizarTabla()

            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, Err.Number, ex.Message)
        End Try
    End Sub

    Private Sub btnTodos_Click(sender As Object, e As EventArgs)
        Try
            sqlExecute("UPDATE solicitudes SET CONFIRMADO = '1',FECHA_REV = '" & FechaSQL(Date.Now) & "' WHERE CONFIRMADO = '0'", "KIOSCO")
            ActualizarTabla()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try
            sqlExecute("DELETE FROM solicitudes WHERE ID = '" & dgSolicitudes.SelectedCells.Item(0).Value.ToString & "'", "KIOSCO")
            ActualizarTabla()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub


    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        frmReporteRetirosPrestamos.ShowDialog(Me)

    End Sub

    
    Private Sub dgSolicitudes_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgSolicitudes.CellMouseDown
        Try
            If e.Button = Windows.Forms.MouseButtons.Right Then
                dgSolicitudes.Rows(e.RowIndex).Selected = True
                Dim solicitud As String = dgSolicitudes.Rows(e.RowIndex).Cells(2).Value
                Dim reloj As String = dgSolicitudes.Rows(e.RowIndex).Cells(1).Value
                If RTrim(solicitud.ToUpper) = "GAFETE" Then
                    ImprimirGafeteToolStripMenuItem.Text = "Imprimir gafete " & reloj
                    ContextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y)

                ElseIf RTrim(solicitud.ToUpper) = "Credencial VIP" Then   '---------------CHUY--------
                    ImprimirGafeteToolStripMenuItem.Text = "Imprimir CredencialVIP " & reloj
                    ContextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y)
                    family = 1




                End If
            End If
        Catch ex As Exception

        End Try
        
    End Sub

    Private Sub ImprimirGafeteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirGafeteToolStripMenuItem.Click
        Try
            Dim datos As DataTable = New DataTable

            datos = sqlExecute("select * from personalvw where reloj = '" & ImprimirGafeteToolStripMenuItem.Text.Split(" ")(2) & "'", "PERSONAL")
            'datos = sqlExecute("SELECT TOP (1) rtrim(Vpersonal.RELOJ) as reloj,rtrim(Vpersonal.NOMBRE) as nombre, rtrim(Vpersonal.APATERNO) as apaterno, rtrim(Vpersonal.AMATERNO) as amaterno, 'BRP' AS COD_COMP, rtrim(cias.PATH_FOTO) as path_foto FROM Vpersonal LEFT OUTER JOIN cias ON cias.COD_COMP = 'brp' WHERE (Vpersonal.RELOJ = '" & Rlj & "')", "PERSONAL")
            'If datos.Rows.Count > 0 Then
            '    'PATH = datos.Rows(0).Item("path_foto").ToString.Trim & "\p" & Rlj & ".jpg"
            '    'datos.Rows(0).Item("path_foto") = PATH
            '    Dim planta As String = RTrim(datos.Rows(0)("cod_planta"))

            '    If planta = "002" Then
            '        frmVistaPrevia.LlamarReporte("Gafete_BRPJuarez2", datos)
            '    Else
            '        frmVistaPrevia.LlamarReporte("Gafete_BRP", datos)
            '    End If

            '    frmVistaPrevia.ShowDialog()
            'End If
            Dim _reloj As String = ImprimirGafeteToolStripMenuItem.Text.Split(" ")(2)
            Dim familiares As DataTable = New DataTable

            familiares = sqlExecute("select * from familiares where reloj = '" & _reloj & "' and (COD_FAMILIA in ('05','06','11','12','13') or (COD_FAMILIA in ('07','08','14') and datediff(year, fecha_nac, getdate()) between 15 and 22 ))")



            If datos.Rows.Count > 0 Then
                'PATH = datos.Rows(0).Item("path_foto").ToString.Trim & "\p" & Rlj & ".jpg"
                'datos.Rows(0).Item("path_foto") = PATH

                If family = 1 Then '-------------------------CHUY----------------
                    If familiares.Rows.Count > 0 Then
                        frmVistaPrevia.LlamarReporte("Gafete Centro Familiar", datos)
                        frmVistaPrevia.ShowDialog()
                    Else

                        MessageBox.Show("No se cuenta con ningun Familiar Elegible.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

                    End If

                Else


                    Dim planta As String = RTrim(datos.Rows(0)("cod_planta"))
                    Dim cia As String = RTrim(datos.Rows(0)("cod_comp"))

                    If cia = "090" Then
                        If planta = "002" Then
                            frmVistaPrevia.LlamarReporte("Gafete_BRPJuarez2", datos)
                        Else
                            frmVistaPrevia.LlamarReporte("Gafete_BRP", datos)
                        End If
                    ElseIf cia = "093" Then
                        frmVistaPrevia.LlamarReporte("Gafete_Caseem", datos)
                    ElseIf cia = "091" Then
                        frmVistaPrevia.LlamarReporte("Gafete_Practicante", datos)
                    Else
                        frmVistaPrevia.LlamarReporte("Gafete_BRP", datos)
                    End If
                    frmVistaPrevia.ShowDialog()
                End If
                'frmVistaPrevia.ShowDialog()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbPlanta_TextChanged(sender As Object, e As EventArgs) Handles cmbPlanta.SelectedValueChanged
        Try
            If cmbPlanta.SelectedValue = "***" Then
                ActualizarTabla()
            Else
                ActualizarTabla(cmbPlanta.SelectedValue)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgSolicitudes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgSolicitudes.CellContentClick

    End Sub
End Class