Public Class frmSuspenderCreditoInfonavit

    Public _reloj_suspender_infonavit As String = ""
    Public _nombres_suspender_infonavit As String = ""
    Public _fecha_alta As Date

    Public _numero_credito_suspender As String = ""

    Private Sub frmSuspenderCreditoInfonavit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        txtReloj.Text = _reloj_suspender_infonavit
        lblNombres.Text = _nombres_suspender_infonavit
        '   dtpAlta.Value = _fecha_alta
        txtNumeroCredito.Text = _numero_credito_suspender
        dtpFechaSuspension.Value = Today

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        sqlExecute("update infonavit set activo = 0, suspension = '" & FechaSQL(dtpFechaSuspension.Value) & "' where reloj = '" & _reloj_suspender_infonavit & "' and infonavit = '" & _numero_credito_suspender & "'")


        Me.Dispose()
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub
End Class