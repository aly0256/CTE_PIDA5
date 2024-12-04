Public Class frmSeleccionarFecha

    Private Sub frmSeleccionarFecha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtFechaInicial.Value = Date.Now
        If msginactivo <> "" Then
            ReflectionLabel1.Text = msginactivo
        End If
        FechaInicial = dtFechaInicial.Value
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        FechaInicial = dtFechaInicial.Value
        fechaultimo = dtFechaInicial.Value
        fecha_bitacora_wme = dtFechaInicial.Value
        msginactivo = ""
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        fechaultimo = Nothing
    End Sub
End Class