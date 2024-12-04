Public Class frmReporteSolicitudesVacantes

    Dim dtReportesVacantes As New DataTable
    Public strCodVac As String

    Private Sub frmReporteSolicitudesVacantes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmReporteSolicitudesVacantes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dgvReportesVacantess.AutoGenerateColumns = False
            dtReportesVacantes.Columns.Add("nombre", GetType(System.String))
            dtReportesVacantes.Columns.Add("marcar", GetType(System.Boolean))
            dtReportesVacantes.Rows.Add({"Vacante seleccionada", 0})
            dtReportesVacantes.Rows.Add({"Todas las vacantes", 0})
            dgvReportesVacantess.DataSource = dtReportesVacantes
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, Err.Number, ex.Message)
        End Try
    End Sub


    Private Sub VacanteSeleccionada()
        Try
            Dim dtvacanteseleccionada As New DataTable
            Dim query As String = ""
            Dim codvacante As String = ""
            query = "where v.activo = 1 "
            codvacante = " and v.Cod_Vac = '" & strCodVac & "' "
            dtvacanteseleccionada = sqlExecute("select c.folio, c.Cod_Vac, v.vacante, rtrim(c.Nombre) + ' ' + rtrim(c.SegundoNombre) + ' '  + rtrim(c.Paterno) + ' ' + rtrim(c.Materno) as nombre, " & _
                " c.FhaApli, c.Agencia, case when c.AprobadoRH is NULL then 'Pendiente' when c.AprobadoRH = 0 then 'Rechazada' when c.AprobadoRH = 1 then 'Aceptada' end as aprobacion_RH, " & _
                " case when c.AprobadoSupervisor is NULL then 'Pendiente' when c.AprobadoSupervisor = 0 then 'Rechazada' when c.AprobadoSupervisor = 1 then 'Aceptada' end as aprobacion_supervisor, " & _
                " case when c.AprobadoMedico is NULL then 'Pendiente' when c.AprobadoMedico = 0 then 'Rechazada' when c.AprobadoMedico = 1 then 'Aceptada' end as aprobacion_medico, " & _
                " case when c.AprobadoEntrevistaRH is NULL then 'Pendiente' when c.AprobadoEntrevistaRH = 0 then 'Rechazada' when c.AprobadoEntrevistaRH = 1 then 'Aceptada' end as aprobacion_altaRH, " & _
                " case when c.Layout is NULL then 'Pendiente' when c.Layout = 1 then 'Exportado' end as exportado, " & _
                " c.DuracionRH, c.DuracionSupervisor, c.DuracionMedico, c.DuracionEntrevistaRH " & _
                " from reclutamiento.dbo.candidatos c " & _
                "LEFT JOIN reclutamiento.dbo.vacantes v on c.Cod_Vac = v.Cod_Vac " & query & codvacante)
            If Not dtvacanteseleccionada.Rows.Count > 0 Then
                MessageBox.Show("No hay información para generar el reporte o la vacante esta inactiva", "Información no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If
            ToolStripProgressBar11.Value = 1
            frmVistaPrevia.LlamarReporte("ReporteVacantes", dtvacanteseleccionada)
            frmVistaPrevia.ShowDialog()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, Err.Number, ex.Message)
        End Try
    End Sub

    Private Sub TodasLasVacantes()
        Dim dttodasvacantes As New DataTable
        Dim query As String = ""
        Try
            query = "where v.activo = 1 "
            dttodasvacantes = sqlExecute("select c.folio, c.Cod_Vac, v.vacante, rtrim(c.Nombre) + ' ' + rtrim(c.SegundoNombre) + ' '  + rtrim(c.Paterno) + ' ' + rtrim(c.Materno) as nombre, " & _
                " c.FhaApli, c.Agencia, case when c.AprobadoRH is NULL then 'Pendiente' when c.AprobadoRH = 0 then 'Rechazada' when c.AprobadoRH = 1 then 'Aceptada' end as aprobacion_RH, " & _
                " case when c.AprobadoSupervisor is NULL then 'Pendiente' when c.AprobadoSupervisor = 0 then 'Rechazada' when c.AprobadoSupervisor = 1 then 'Aceptada' end as aprobacion_supervisor, " & _
                " case when c.AprobadoMedico is NULL then 'Pendiente' when c.AprobadoMedico = 0 then 'Rechazada' when c.AprobadoMedico = 1 then 'Aceptada' end as aprobacion_medico, " & _
                " case when c.AprobadoEntrevistaRH is NULL then 'Pendiente' when c.AprobadoEntrevistaRH = 0 then 'Rechazada' when c.AprobadoEntrevistaRH = 1 then 'Aceptada' end as aprobacion_altaRH, " & _
                " case when c.Layout is NULL then 'Pendiente' when c.Layout = 1 then 'Exportado' end as exportado, " & _
                " c.DuracionRH, c.DuracionSupervisor, c.DuracionMedico, c.DuracionEntrevistaRH " & _
                " from reclutamiento.dbo.candidatos c " & _
                "LEFT JOIN reclutamiento.dbo.vacantes v on c.Cod_Vac = v.Cod_Vac " & query)
            If Not dttodasvacantes.Rows.Count > 0 Then
                MessageBox.Show("No hay información para generar el reporte de todas las vacantes", "Información no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If
            ToolStripProgressBar11.Value = 1
            frmVistaPrevia.LlamarReporte("ReporteVacantes", dttodasvacantes)
            frmVistaPrevia.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Se presentó un error al intentar procesar la información.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, Err.Number, ex.Message)
        End Try
    End Sub

    Private Sub btnCerrarr_Click(sender As Object, e As EventArgs) Handles btnCerrarr.Click
        Me.Close()
    End Sub

    Private Sub btnGenerarReportee_Click(sender As Object, e As EventArgs) Handles btnGenerarReportee.Click
        Dim seleccionado As Long = 0
        Try
            'obtener nombres de los reportes a generar
            ToolStripProgressBar11.Maximum = 1
            ToolStripProgressBar11.Value = 0
            For Each row As DataGridViewRow In dgvReportesVacantess.Rows
                Try
                    If row.Cells("marcarr").Value Then
                        seleccionado = seleccionado + 1
                        Select Case row.Cells("nombree").Value
                            Case "Vacante seleccionada"
                                VacanteSeleccionada()
                            Case "Todas las vacantes"
                                TodasLasVacantes()
                        End Select
                    End If
                Catch ex As Exception
                End Try
                ToolStripProgressBar11.Value = 0
            Next
            If Not seleccionado > 0 Then
                MessageBox.Show("No se ha seleccionado ningún reporte.", "Reporte(s) no seleccionado(s)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, Err.Number, ex.Message)
        End Try
    End Sub
End Class