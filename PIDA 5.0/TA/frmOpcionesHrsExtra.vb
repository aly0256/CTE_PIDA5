Public Class frmOpcionesHrsExtras
    Dim dtplantas As DataTable
    Private Sub frmopcioneshrsextras_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        dtplantas = sqlExecute("SELECT DISTINCT nombre, cod_planta as Código from plantas  where COD_PLANTA = '001' or COD_PLANTA = '002' union select DISTINCT 'Todos', 'Todos' from plantas as tabla order by nombre asc")
        cmbPlanta.DataSource = dtplantas
    End Sub

    Private Sub btnAceptAsignar_Click(sender As Object, e As EventArgs) Handles btnAceptAsignar.Click
        Dim planta As String = cmbPlanta.SelectedValue

        If planta = "Todos" Then
            Dim dtHoras As DataTable = sqlExecute("select * from tavw where reloj in (select reloj from extras_autorizadas where fecha = '" & FechaSQL(TiempoExFecha) & "' and autori_a1 = '1') and fecha_entro = '" & FechaSQL(TiempoExFechaEntro) & "'", "TA")
            frmVistaPrevia.LlamarReporte("Horas extras autorizadas", dtHoras)
            frmVistaPrevia.ShowDialog()
            Me.Close()
        Else
            Dim dtHoras As DataTable = sqlExecute("select * from tavw where reloj in (select reloj from extras_autorizadas where fecha = '" & FechaSQL(TiempoExFecha) & "' and autori_a1 = '1') and fecha_entro = '" & FechaSQL(TiempoExFechaEntro) & "' and cod_planta = '" & Trim(planta) & "'", "TA")
            frmVistaPrevia.LlamarReporte("Horas extras autorizadas", dtHoras)
            frmVistaPrevia.ShowDialog()
            Me.Close()
        End If

    End Sub
End Class