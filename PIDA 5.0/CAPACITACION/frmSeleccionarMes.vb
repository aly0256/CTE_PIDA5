Public Class frmSeleccionarMes
    Private Sub frmSeleccionarMes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbMes.DataSource = sqlExecute("select distinct mes as 'Mes', num_mes as 'Número mes', ano as 'Año' from periodos order by ano desc, num_mes asc", "TA")
        cmbMes.SelectedIndex = 0
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            AnoSelec = cmbMes.SelectedValue("Año")
            MesSelec = cmbMes.SelectedValue("Número mes")
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
            Me.Dispose()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        AnoSelec = Nothing
        MesSelec = Nothing
        Me.Close()
        Me.Dispose()
    End Sub
End Class