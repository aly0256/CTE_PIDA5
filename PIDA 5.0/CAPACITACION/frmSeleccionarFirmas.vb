Public Class frmSeleccionarFirmas

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        repEmpleados = cmbEmpleados.SelectedValue
        repEmpresa = cmbEmpresa.SelectedValue
        Me.Close()

    End Sub

    Private Sub frmSeleccionarFirmas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim dtempleados As DataTable = sqlExecute("select cod_representantes as Código, Nombre from representantes where COD_REPRESENTANTES LIKE 'E%' order by COD_REPRESENTANTES asc", "capacitacion")
        cmbEmpleados.DataSource = dtempleados

        Dim dtempresa As DataTable = sqlExecute("select cod_representantes as Código, Nombre from representantes where COD_REPRESENTANTES LIKE 'C%' order by COD_REPRESENTANTES asc", "capacitacion")
        cmbEmpresa.DataSource = dtempresa
    End Sub

End Class