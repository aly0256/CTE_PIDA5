Public Class frmElegirAntidoping
    Public x As Integer = 0
    Private Sub frmElegirAntidoping_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Not IsNothing(x) Then
                txtCantidad.Value = x
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        x = txtCantidad.Value
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        x = 0
        Me.Close()
        Me.Dispose()
    End Sub
End Class