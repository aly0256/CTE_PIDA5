Public Class frmTiempoVigencia

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click

        FechaInicial = Nothing
        NumControl = Nothing
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try

            If rbVigenciaAlta.Checked Then
                FechaIni = Nothing
                NumControl = intDiasAlta.Value
            ElseIf rbVigenciaHoy.Checked Then
                FechaIni = DateAdd("d", intDiasHoy.Value, Now.Date)
                NumControl = 0
            ElseIf rbFechaVenc.Checked Then
                FechaIni = txtFechaVencimiento.Value
                NumControl = 0
            End If

            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub frmVigencia_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub



    Private Sub rbFechaVenc_CheckedChanged(sender As Object, e As EventArgs) Handles rbFechaVenc.CheckedChanged
        txtFechaVencimiento.Enabled = True
        intDiasAlta.Enabled = False
        intDiasHoy.Enabled = False
        txtFechaVencimiento.Focus()
    End Sub

    Private Sub rbVigenciaAlta_CheckedChanged(sender As Object, e As EventArgs) Handles rbVigenciaAlta.CheckedChanged
        txtFechaVencimiento.Enabled = False
        intDiasAlta.Enabled = True
        intDiasHoy.Enabled = False
        intDiasAlta.Focus()
    End Sub

    Private Sub rbVigenciaHoy_CheckedChanged(sender As Object, e As EventArgs) Handles rbVigenciaHoy.CheckedChanged
        txtFechaVencimiento.Enabled = False
        intDiasAlta.Enabled = False
        intDiasHoy.Enabled = True
        intDiasHoy.Focus()
    End Sub

    Private Sub frmTiempoVigencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFechaVencimiento.Value = DateAdd("d", 90, Now.Date)
    End Sub
End Class