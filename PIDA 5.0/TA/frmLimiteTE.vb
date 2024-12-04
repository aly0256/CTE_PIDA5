Public Class frmLimiteTE

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        strRespuesta = TimeSelector1.SelectedTime.Hours.ToString.PadLeft(2, "0") & ":" & TimeSelector1.SelectedTime.Minutes.ToString.PadLeft(2, "0")
        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub
End Class