Public Class frmTrabajando

    Private Sub frmTrabajando_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        My.Application.DoEvents()
    End Sub

    Private Sub frmTrabajando_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ActivoTrabajando = False
        Me.Dispose()
    End Sub

    Private Sub frmTrabajando_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Avance.IsRunning = False
        If ActivoTrabajando Then
            If MessageBox.Show("¿Está seguro de cancelar el proceso que se está ejecutando en este momento?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub frmTrabajando_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Avance.IsRunning = True
        ActivoTrabajando = True
    End Sub

    Private Sub Avance_ValueChanged(sender As Object, e As EventArgs) Handles Avance.ValueChanged

    End Sub
End Class