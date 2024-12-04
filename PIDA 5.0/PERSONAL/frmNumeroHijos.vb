Public Class frmNumeroHijos

    Private Sub frmNumeroHijos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtEdad.Text = "15"

    End Sub

    Private Sub txtEdad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtEdad.KeyPress
        If InStr(1, "123456789.-" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If txtEdad.Text = "" Then
            MessageBox.Show("Introduzca un numero en el capo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            EdadHijos = CInt(txtEdad.Text)
            CapturaEdad = True
            Me.Close()
        End If
    End Sub
End Class