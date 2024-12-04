Public Class frmSeleccionarCia

    Private Sub frmSeleccionarCia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cmbCia.DataSource = sqlExecute("SELECT cod_comp,nombre FROM cias")
            cmbCia.ValueMember = "cod_comp"
            cmbCia.DisplayMembers = "cod_comp,nombre"
            Dim dtCiaDefault As DataTable = sqlExecute("select top 1 * from cias where cia_default = '1'")
            If dtCiaDefault.Rows.Count Then
                cmbCia.SelectedValue = dtCiaDefault.Rows(0)("cod_comp")
            End If

            cmbCia.Columns(0).Width.AutoSize = True
            cmbCia.Columns(1).StretchToFill = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub cmbCia_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCia.SelectedValueChanged
        Compania = cmbCia.SelectedValue
    End Sub
End Class