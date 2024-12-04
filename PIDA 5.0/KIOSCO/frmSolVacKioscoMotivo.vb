Public Class frmSolVacKioscoMotivo

    Public strMotivo As String = ""

    Private Sub btnConfirmar_Click(sender As Object, e As EventArgs) Handles btnConfirmar.Click
        If txtMotivo.Text.Trim = "" Then
            MessageBox.Show("Por favor, capture un motivo de negación de solicitud", "Motivo inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            strMotivo = txtMotivo.Text.Trim
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub btnCancela_Click(sender As Object, e As EventArgs) Handles btnCancela.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class