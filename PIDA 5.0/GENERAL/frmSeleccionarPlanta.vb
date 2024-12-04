Public Class frmSeleccionarPlanta

    Private Sub frmSeleccionarPlanta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtPlantas As DataTable = New DataTable
        dtPlantas.Columns.Add("cod_planta")
        dtPlantas.Columns.Add("nombre")

        dtPlantas.Rows.Add({"***", "Todas"})
        dtPlantas.Rows.Add({"610", "Querétaro"})


        ComboTree1.DataSource = dtPlantas
        ComboTree1.ValueMember = "cod_planta"
        ComboTree1.DisplayMembers = "nombre"

        PlantaReporteDiario = "***"
        ComboTree1.SelectedValue = PlantaReporteDiario

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        PlantaReporteDiario = "***"
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        PlantaReporteDiario = ComboTree1.SelectedValue
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class