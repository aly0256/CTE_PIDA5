Public Class frmComentarioVersionProceso

    Public strComentario As String = ""

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            strComentario = txtComentario.Text.ToString.Trim
            Me.Close()
            Me.Dispose()
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception : End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class