Public Class frmSeleccionaMes

    Private Sub frmSeleccionaMes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbMes.Items.Clear()
        cmbMes.Items.Add("Enero")
        cmbMes.Items.Add("Febrero")
        cmbMes.Items.Add("Marzo")
        cmbMes.Items.Add("Abril")
        cmbMes.Items.Add("Mayo")
        cmbMes.Items.Add("Junio")
        cmbMes.Items.Add("Julio")
        cmbMes.Items.Add("Agosto")
        cmbMes.Items.Add("Septiembre")
        cmbMes.Items.Add("Octubre")
        cmbMes.Items.Add("Noviembre")
        cmbMes.Items.Add("Diciembre")

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        mesideas = cmbMes.Text
        Me.Close()
    End Sub
End Class