Public Class frmCapturaNeto

    Public texto As String = "Neto"

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click

        Try
            Double.Parse(TextBox1.Text)
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            MessageBox.Show("El monto capturado no es un valor numérico válido")
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub frmCapturaNeto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Capture el valor de " & texto.ToUpper
        Me.Text = "Capturar " & texto.ToUpper
    End Sub
End Class