Public Class frmPeriodoPruebas

    Private Sub btnSi_Click(sender As Object, e As EventArgs) Handles btnSi.Click
        strRespuesta = FechaSQL(txtFecha.Value)
        Me.DialogResult = Windows.Forms.DialogResult.Yes
    End Sub

    Private Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        Me.DialogResult = Windows.Forms.DialogResult.No
    End Sub
End Class