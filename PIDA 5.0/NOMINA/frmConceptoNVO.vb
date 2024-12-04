Public Class frmConceptoNVO
    Dim dtNaturaleza As New DataTable
    Dim dtRegistro As New DataTable
    Private Sub frmConceptoNVO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dtNaturaleza = sqlExecute("SELECT * FROM naturalezas", "nomina")
            cmbNaturaleza.DataSource = dtNaturaleza

            txtCodigo.Text = NvoConcepto
            txtNombre.Text = ""
            cmbNaturaleza.SelectedValue = "I"
            IntPrioridad.Value = 900
            btnAfecta.Value = False
            btnPositivo.Value = True
            btnComparativo.Value = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        sqlExecute("INSERT INTO conceptos (concepto) VALUES ('" & txtCodigo.Text & "')", "nomina")
        sqlExecute("UPDATE conceptos SET nombre = '" & txtNombre.Text & "', " & _
            "cod_naturaleza = '" & cmbNaturaleza.SelectedValue & "', " & _
            "prioridad = " & IntPrioridad.Value & ", " & _
            "suma_neto = " & IIf(btnAfecta.Value, 1, 0) & ", " & _
            "positivo = " & IIf(btnPositivo.Value, 1, 0) & ", " & _
            "comparativo_nominas = " & IIf(btnComparativo.Value, 1, 0) & " " & _
            " WHERE concepto = '" & txtCodigo.Text & "'", "nomina")
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class