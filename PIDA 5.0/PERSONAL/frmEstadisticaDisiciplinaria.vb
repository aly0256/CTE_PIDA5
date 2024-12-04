Public Class frmEstadisticaDisiciplinaria
    Dim dtfiltroDisciplina As DataTable
    Dim reporte As String

    Private Sub frmEstadisticaDisiciplinaria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtcat As DataTable = sqlExecute("select cod_categoria as Código, Nombre from cod_cat_disciplinaria UNION SELECT DISTINCT '000', 'Todos' AS RegistroVacio FROM cod_cat_disciplinaria AS Tabla order by COD_CATEGORIA ASC")
        Dim dttipo As DataTable = sqlExecute("select cod_tipo_accion as Código, tipo_accion_disciplinaria as Tipo from tipo_disciplinaria union select distinct '000' , 'Todos' as RegistroVacio from tipo_disciplinaria as tabla order by cod_tipo_accion asc")

        cmbCat.DataSource = dtcat
        cmbTipo.DataSource = dttipo
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim dtt As New DataTable()
        Dim qwery As String = ""
        If cmbFecha1.Text <> "" And cmbFecha2.Text <> "" Then
            If cmbCat.SelectedValue <> "000" Then
                qwery = qwery & " and cod_categoria = '" & cmbCat.SelectedValue & "' "
            End If
            If cmbTipo.SelectedValue <> "000" Then
                qwery = qwery & " and cod_tipo_accion = '" & cmbTipo.SelectedValue & "'"
            End If

            dtfiltroDisciplina = sqlExecute("select * from accion_disciplinariavw where fecha BETWEEN '" & FechaSQL(cmbFecha1.Text) & "' and '" & FechaSQL(cmbFecha2.Text) & "' " & qwery & " ")
            Dim resultado = (From tabla1 In dtfiltroDisciplina
            Join tabla2 In dtFiltroPersonal On tabla1.Field(Of String)("Reloj") Equals tabla2.Field(Of String)("Reloj")
            Select tabla1)

            If resultado.Count() > 0 Then
                dtt = resultado.CopyToDataTable()
            End If

            Dim fechas As String = cmbFecha1.Text & " a " & cmbFecha2.Text
            Dim clfechas As New Data.DataColumn("fechas_consulta", GetType(System.String))
            clfechas.DefaultValue = fechas
            dtt.Columns.Add(clfechas)

            If TipoReporteEstadistico = "Estadisticas_Disciplinarias" Then
                reporte = "Reporte disciplinario estadistico"
            Else
                reporte = "Reporte disciplinario total"
            End If

            frmVistaPrevia.LlamarReporte(reporte, dtt)
            frmVistaPrevia.ShowDialog()
            frmVistaPrevia.Focus()
            Me.Close()

        Else
            MessageBox.Show("Seleccione un rango de fechas para continuar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class