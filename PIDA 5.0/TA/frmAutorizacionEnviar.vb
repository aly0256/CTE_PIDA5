Public Class frmAutorizacionEnviar

    Private Sub frmAutorizacionEnviar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'If SQLConn.Contains("Juarez 2") Then
        '    chkJ1.CheckState = CheckState.Unchecked
        '    chkJ2.CheckState = CheckState.Checked
        'ElseIf SQLConn.Contains("BRP") Then
        '    chkJ2.CheckState = CheckState.Unchecked
        '    chkJ1.CheckState = CheckState.Checked
        'Else
        '    chkJ1.CheckState = CheckState.Unchecked
        '    chkJ2.CheckState = CheckState.Checked
        'End If


    End Sub

    Private Sub btnGenerarReporte_Click(sender As Object, e As EventArgs) Handles btnGenerarReporte.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class