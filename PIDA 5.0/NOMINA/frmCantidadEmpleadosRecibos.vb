Public Class frmCantidadEmpleadosRecibos

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If swEmpleados.Value Then               'PARA UN EMPLEADO
            frmRecibos.varTodos = False
            pbCargarRecibos.Value = 100
            Me.Dispose()
            frmRecibos.tabBuscar.SelectedTab = frmRecibos.tabEmpleado
            frmRecibos.Show()
            frmRecibos.Focus()
        Else                                    'PARA TODOS LOS EMPLEADOS
            frmRecibos.varTodos = True
            frmRecibos.varActivoSeleccion = True
            lblBarra.Text = "0 %"
            Me.Focus()
            frmRecibos.Visible = False
            frmRecibos.Show()
            frmRecibos.Visible = True
            Me.Dispose()
            frmRecibos.Focus()
        End If
        frmRecibos.varActivoSeleccion = False
    End Sub

    Private Sub lblBarra_Click(sender As Object, e As EventArgs) Handles lblBarra.Click

    End Sub
End Class