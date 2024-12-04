Public Class frmSelTipoMovSUA

    Private Sub frmSelTipoMovSUA_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub



    Private Sub btnAceptar_Click_1(sender As Object, e As EventArgs) Handles btnAceptar.Click
        '===This is correct
        Me.Close()
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        '===Salir o cancelar
        Me.Close()
    End Sub
End Class