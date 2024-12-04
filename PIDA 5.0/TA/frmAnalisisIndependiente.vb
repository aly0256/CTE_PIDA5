Public Class frmAnalisisIndependiente

    Private Sub btnAnalizar_Click(sender As Object, e As EventArgs) Handles btnAnalizar.Click
        If txtReloj.Text <> "" Then
            analisis_independiente(txtReloj.Text, dtpFecha.Value)
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim frm As New frmBuscar
        frm.ShowDialog()
        If Reloj <> "ERROR" Then
            txtReloj.Text = Reloj
        Else
            txtReloj.Text = ""
        End If

    End Sub
End Class