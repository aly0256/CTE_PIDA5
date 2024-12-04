Public Class frmElegirCampo

    Private Sub frmElegirCampo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtCampos As New DataTable
        dtCampos.Columns.Add("cod_campo")
        dtCampos.Columns.Add("nombre_campo")

        dtCampos.Rows.Add({"cod_puesto", "Puesto"})
        dtCampos.Rows.Add({"cod_clase", "Clasificación"})
        dtCampos.Rows.Add({"cod_planta", "Planta"})
        dtCampos.Rows.Add({"cod_depto", "Departamento"})
        dtCampos.Rows.Add({"cod_super", "Supervisor"})
        dtCampos.Rows.Add({"cod_turno", "Turno"})
        dtCampos.Rows.Add({"cod_hora", "Horario"})
        dtCampos.Rows.Add({"cod_super", "Supervisor"})
        dtCampos.Rows.Add({"nivel", "Nivel"})
        dtCampos.Rows.Add({"promocion", "Promoción"})

        ComboTree1.DataSource = dtCampos        

    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        campo_ultimo_movimiento = ComboTree1.SelectedValue
        solo_promociones_reporte = CheckBox1.Checked

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub ComboTree1_TextChanged(sender As Object, e As EventArgs) Handles ComboTree1.SelectedValueChanged
        If ComboTree1.SelectedValue = "promocion" Then
            CheckBox1.Visible = True
        Else
            CheckBox1.Visible = False
        End If
    End Sub


End Class