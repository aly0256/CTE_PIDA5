Public Class froModificarFactorCreditoInfonavit

    Public _reloj_agregar_infonavit As String = ""
    Public _nombres_agregar_infonavit As String = ""
    Public _fecha_alta As Date

    Public _credito_modificar As String = ""
    Public _tipo_credito_modificar As String = ""
    Public _factor_credito_modificar As String = ""

    Private Sub froModificarFactorCreditoInfonavit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtReloj.Text = _reloj_agregar_infonavit
        lblNombres.Text = _nombres_agregar_infonavit
        dtpAlta.Value = _fecha_alta

        Dim dtTipoInfonavit As New DataTable
        dtTipoInfonavit.Columns.Add("tipo")
        dtTipoInfonavit.Columns.Add("nombre")

        dtTipoInfonavit.Rows.Add({"1", "Porcentaje"})
        dtTipoInfonavit.Rows.Add({"2", "Cuota fija"})
        dtTipoInfonavit.Rows.Add({"3", "VSM"})

        cmbTipoInfonavit.DataSource = dtTipoInfonavit
        cmbTipoInfonavit.ValueMember = "tipo"

        txtNumeroCredito.Text = _credito_modificar

        cmbTipoInfonavit.SelectedValue = _tipo_credito_modificar
        txtFactorDeDescuentoInfonavit.Text = _factor_credito_modificar

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        sqlExecute("update infonavit set tipo_cred = '" & cmbTipoInfonavit.SelectedValue & "' where reloj = '" & _reloj_agregar_infonavit & "' and infonavit = '" & _credito_modificar & "'")
        sqlExecute("update infonavit set cuota_cred = '" & txtFactorDeDescuentoInfonavit.Text & "' where reloj = '" & _reloj_agregar_infonavit & "' and infonavit = '" & _credito_modificar & "'")

        Me.Dispose()
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Me.Dispose()
    End Sub
End Class