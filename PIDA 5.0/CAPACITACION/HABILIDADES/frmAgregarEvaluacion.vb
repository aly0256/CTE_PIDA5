Public Class frmAgregarEvaluacion

    Private Sub frmAgregarEvaluacion_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmAgregarEvaluacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtReloj.Text = strRespuesta

        cmbFiltro.Items.Add("Solo evaluaciones que apliquen")
        cmbFiltro.Items.Add("Todas las evaluaciones disponibles")

        cmbFiltro.SelectedIndex = 0
    End Sub

    Private Sub cmbFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFiltro.SelectedIndexChanged
        Dim dtEvaluaciones As New DataTable
        Dim dtEvalFiltro As New DataTable
        Dim dtTemp As New DataTable
        Dim R As String
        Dim Filtro As String

        dtEvaluaciones = sqlExecute("SELECT cod_evaluacion,nombre,filtro FROM evaluaciones ORDER BY nombre", "CAPACITACION")
        If cmbFiltro.SelectedIndex = 0 Then

            dtEvalFiltro = dtEvaluaciones.Clone

            R = txtReloj.Text
            For Each dEval As DataRow In dtEvaluaciones.Rows
                If IsDBNull(dEval("filtro")) Then
                    dtEvalFiltro.ImportRow(dEval)
                Else
                    Filtro = dEval("filtro").ToString.Trim
                    dtTemp = sqlExecute("SELECT reloj from personalvw WHERE reloj = '" & R & "' AND " & Filtro)
                    If dtTemp.Rows.Count > 0 Then
                        dtEvalFiltro.ImportRow(dEval)
                    End If
                End If
            Next

            cmbEvaluaciones.DataSource = dtEvalFiltro
        Else
            cmbEvaluaciones.DataSource = dtEvaluaciones
        End If

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click

        If sqlExecute("SELECT reloj FROM evaluaciones_empleados WHERE reloj= '" & txtReloj.Text & "' AND cod_evaluacion = '" & _
                      cmbEvaluaciones.SelectedValue & "'", "CAPACITACION").Rows.Count > 0 Then
            MessageBox.Show("El empleado " & txtReloj.Text & " ya ha sido o está siendo evaluado en esta habilidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbEvaluaciones.Focus()
        Else
            strRespuesta = cmbEvaluaciones.SelectedValue

            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If

    End Sub
End Class