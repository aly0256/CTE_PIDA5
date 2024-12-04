Public Class frmCapturaVersionReportesPrenom
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If Not cmbVersion.SelectedItem Is Nothing Then
                Me.DialogResult = cmbVersion.SelectedItem.ToString
            Else
                MessageBox.Show("Seleccione una versión para los reportes.", "Seleccionar versión", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class