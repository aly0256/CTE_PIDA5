Public Class frmFechaYMonto

    Private Sub frmFechaYMonto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtFecha.Text = Now.Date
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If dtFecha.Value.Date.ToShortDateString < Now.Date Then
            MessageBox.Show("La fecha no puede ser menor a la actual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf txtMonto.Text <= 0 Then
            MessageBox.Show("El monto no puede ser igual a 0", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            FechaRetiro = dtFecha.Value.Date.ToShortDateString
            MontoRetiro = txtMonto.Text
            Me.Close()
            Me.Dispose()
        End If
    End Sub

    Private Sub txtMonto_TextChanged(sender As Object, e As EventArgs) Handles txtMonto.TextChanged

    End Sub
End Class