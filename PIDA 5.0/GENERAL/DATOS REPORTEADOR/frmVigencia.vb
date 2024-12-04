Public Class frmVigencia

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        FechaInicial = Nothing
        NumControl = Nothing
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            FechaInicial = dtFecha.Value
            NumControl = txtControl.Value
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub frmVigencia_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmVigencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtControl.Value = NumControl
            dtFecha.Value = DateAdd(DateInterval.Year, 1, Now.Date)
        Catch ex As Exception
            txtControl.Value = 1
        End Try
    End Sub
End Class