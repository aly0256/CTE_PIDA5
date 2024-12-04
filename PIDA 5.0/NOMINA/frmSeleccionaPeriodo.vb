Public Class frmSeleccionaPeriodo
    Dim dtPeriodo As New DataTable
    Dim dtAno As New DataTable
    Private Sub cmbAno_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbAno.SelectedValueChanged
        'dtPeriodo = sqlExecute("SELECT periodo,(personal.dbo.FechaCorta(fecha_ini)) as 'fecha_ini',(personal.dbo.FechaCorta(fecha_fin)) as'fecha_fin' FROM periodos WHERE ano = '" & cmbAno.SelectedValue & "'  ORDER BY periodo ASC", "TA")
        dtPeriodo = sqlExecute("SELECT periodo,fecha_ini,fecha_fin FROM periodos WHERE ano = '" & cmbAno.SelectedValue & "'  ORDER BY periodo ASC", "TA")

        cmbPeriodo.DataSource = dtPeriodo

    End Sub

    Private Sub cmbAno_TextChanged(sender As Object, e As EventArgs) Handles cmbAno.TextChanged

    End Sub

    Private Sub frmSeleccionaPeriodo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtAno = sqlExecute("SELECT DISTINCT ano FROM periodos ORDER BY ano DESC", "TA")
        cmbAno.DataSource = dtAno
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        PeriodoSelec = cmbPeriodo.SelectedValue
        AnoSelec = cmbAno.SelectedValue
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub
End Class