Public Class frmTipoEmpleado
    Public tipo_emp As String = ""

    Private Sub btnSemanal_Click(sender As Object, e As EventArgs) Handles btnSemanal.Click
        tipo_emp = "S"
        Dispose()
    End Sub

    Private Sub btnCatorcenal_Click(sender As Object, e As EventArgs) Handles btnCatorcenal.Click
        tipo_emp = "C"
        Dispose()
    End Sub
End Class