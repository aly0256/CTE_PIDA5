Public Class frmAgregarEvaluacionReclutamiento

    Dim formaFiltro As String = ""

    Private Sub frmAgregarEvaluacionReclutamiento_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmAgregarEvaluacionReclutamiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtFolio.Text = strRespuesta

        cmbFiltro.Items.Add("Solo evaluaciones que apliquen")
        cmbFiltro.Items.Add("Todas las evaluaciones disponibles")

        cmbFiltro.SelectedIndex = 0
    End Sub

    Private Sub cmbFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFiltro.SelectedIndexChanged
        Dim dtEvaluaciones As New DataTable

        If cmbFiltro.SelectedIndex = 0 Then
            dtEvaluaciones = sqlExecute("SELECT cod_evaluacion,nombre,filtro FROM evaluaciones where filtro = '" & formaFiltro & "' ORDER BY nombre", "RECLUTAMIENTO")
            cmbEvaluaciones.DataSource = dtEvaluaciones
        Else
            dtEvaluaciones = sqlExecute("SELECT cod_evaluacion,nombre,filtro FROM evaluaciones ORDER BY nombre", "RECLUTAMIENTO")
            cmbEvaluaciones.DataSource = dtEvaluaciones
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If sqlExecute("SELECT folio FROM evaluaciones_solicitantes WHERE folio = '" & txtFolio.Text & "' AND cod_evaluacion = '" & _
                      cmbEvaluaciones.SelectedValue & "'", "RECLUTAMIENTO").Rows.Count > 0 Then
            MessageBox.Show("El solicitante con folio " & txtFolio.Text & " ya ha sido o está siendo evaluado en esta habilidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbEvaluaciones.Focus()
        Else
            strRespuesta = cmbEvaluaciones.SelectedValue

            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Public Overloads Function ShowDialog(ByVal forma As String)
        formaFiltro = forma
        MyBase.ShowDialog()
        Return Me.DialogResult
    End Function
End Class