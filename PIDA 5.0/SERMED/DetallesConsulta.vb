Public Class DetallesConsulta
    Public consulta As ConsultaSermed
    Public t As New DevComponents.DotNetBar.SuperTabItem
    Public tc As New DevComponents.DotNetBar.SuperTabControl

    Public editable As Boolean = False

    Public Sub MostrarInformacion(Optional ByVal folio As String = "")
        On Error Resume Next
        If editable Then
            PanelEditable.Enabled = True
            btnEditar.Visible = False
        Else
            PanelEditable.Enabled = False
            btnEditar.Visible = True
        End If
        campoFolio.Text = consulta.folio

        dtpFecha.Value = consulta.DatosCaptura.fecha

        campoResponsable.Text = consulta.DatosCaptura.responsable

        If consulta.tieneProx_cita Then
            dtpProxima.Value = consulta.prox_cita
            dtpProxima.MinDate = consulta.prox_cita
        Else
            dtpProxima.MinDate = Date.Now
        End If

        campoComentarios.Text = consulta.comentarios

        campoMedicamento.Text = consulta.medicamentos

        campoDatos_clinicos.Text = consulta.datos_clinicos
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.consulta.guardar()
        tc.Tabs.Remove(t)
    End Sub

    Private Sub campoDatos_clinicos_TextChanged(sender As Object, e As EventArgs) Handles campoDatos_clinicos.TextChanged
        Me.consulta.datos_clinicos = campoDatos_clinicos.Text.ToUpper
    End Sub

    Private Sub campoComentarios_TextChanged(sender As Object, e As EventArgs) Handles campoComentarios.TextChanged
        Me.consulta.comentarios = campoComentarios.Text.ToUpper
    End Sub

    Private Sub campoMedicamento_TextChanged(sender As Object, e As EventArgs) Handles campoMedicamento.TextChanged
        Me.consulta.medicamentos = campoMedicamento.Text.ToUpper
    End Sub

    Private Sub dtpProxima_ValueChanged(sender As Object, e As EventArgs) Handles dtpProxima.ValueChanged
        Me.consulta.tieneProx_cita = True
        Me.consulta.prox_cita = dtpProxima.Value
    End Sub

    Private Sub dtpFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtpFecha.ValueChanged
        Me.consulta.DatosCaptura.fecha = dtpFecha.Value
    End Sub

    Private Sub campoResponsable_TextChanged(sender As Object, e As EventArgs) Handles campoResponsable.TextChanged
        Me.consulta.DatosCaptura.responsable = campoResponsable.Text.ToUpper
    End Sub

    Private Sub btnReceta_Click(sender As Object, e As EventArgs) Handles btnReceta.Click       
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        editable = True
        MostrarInformacion()
    End Sub
End Class


