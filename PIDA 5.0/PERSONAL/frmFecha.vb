Public Class frmFecha
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            FechaInicial = dtFechaInicial.Value
            Me.Close()
            Me.Dispose()
        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        FechaInicial = Nothing
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmFecha_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class