Public Class Consultas

    ' -----------------------------------------

    Public ConsultasAbiertas As New ArrayList
    Public fechaDeBusqueda As New Date

    Public dtRegistro As New DataTable
    Public dtConsultasPorFecha As New DataTable

    ' -----------------------------------------

    Public Sub mostrarInformacion()
        If dtRegistro.Rows.Count > 0 Then
            fechaDeBusqueda = dtRegistro.Rows(0)("fecha")
            dtConsultasPorFecha = DatosPorFecha()
            dgvConsultasDiarias.DataSource = dtConsultasPorFecha
            dgvConsultasDiarias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvConsultasDiarias.AutoResizeColumns()
            dtpFechaBusqueda.Value = fechaDeBusqueda
        End If
    End Sub

    Public Function DatosPorFecha() As DataTable
        Dim query As String = "select folio as 'Folio', reloj as 'Reloj', nombres as 'Nombre',  responsable as 'Responsable', fecha as 'Fecha', prox_cita as 'Próxima Cita' from consultas"

        query += " where fecha = '" + fechaDeBusqueda + "' "

        If comboFiltroExternos.SelectedItem.Equals(ComboItemExternos) Then
            query += " and reloj = 'Exter' "
        ElseIf comboFiltroExternos.SelectedItem.Equals(ComboItemEmpleados) Then
            query += " and reloj != 'Exter' "
        End If

        If comboFiltroEstado.SelectedItem.Equals(ComboItemProxima) Then
            query += " and prox_cita != '' "
        ElseIf comboFiltroEstado.SelectedItem.Equals(ComboItemSinProxima) Then
            query += " and prox_cita = '' "
        End If

        Return sqlExecute(query, "sermed")
    End Function

    Private Sub frmConsultas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboFiltroEstado.SelectedItem = ComboItemTodas
        comboFiltroExternos.SelectedItem = ComboItemTodos

        Primero("consultas", "fecha", dtRegistro, "sermed")
        dtpFechaBusqueda.MinDate = dtRegistro.Rows(0)("fecha")

        dtpFechaBusqueda.MaxDate = Date.Now

        Ultimo("consultas", "fecha", dtRegistro, "sermed")
        mostrarInformacion()
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        Primero("consultas", "fecha", dtRegistro, "sermed")
        mostrarInformacion()
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Anterior("consultas", "fecha", FechaSQL(fechaDeBusqueda), dtRegistro, "sermed")
        mostrarInformacion()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Siguiente("consultas", "fecha", FechaSQL(fechaDeBusqueda), dtRegistro, "sermed")
        mostrarInformacion()
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Ultimo("consultas", "fecha", dtRegistro, "sermed")
        mostrarInformacion()
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click

    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try

            Dim t As New DevComponents.DotNetBar.SuperTabItem
            Dim p As New DevComponents.DotNetBar.SuperTabControlPanel
            Dim c As New CapturaSermed()
            Dim d As New DetallesConsulta

            d.t = t
            d.tc = tabControlGeneral

            t.CloseButtonVisible = True
            t.Text = "Nueva Consulta"
            t.ImageIndex = 1

            t.AttachedControl = p
            p.TabItem = t

            p.Controls.Add(c)
            p.Dock = DockStyle.Fill

            d.consulta = New ConsultaSermed()
            d.editable = True
            d.MostrarInformacion()

            c.captura = d.consulta.DatosCaptura
            c.detalle = d

            c.Dock = DockStyle.Fill
            c.BorderStyle = BorderStyle.FixedSingle
            'c.mostrarInformacion()

            Me.tabControlGeneral.Tabs.Add(t)
            Me.tabControlGeneral.Controls.Add(p)

            Me.tabControlGeneral.SelectedTab = t



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click

    End Sub

    Private Sub comboFiltroExternos_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub dtpFechaBusqueda_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaBusqueda.ValueChanged
        dtRegistro = sqlExecute("select fecha from consultas where fecha = '" & FechaSQL(dtpFechaBusqueda.Value) & "'", "sermed")
        mostrarInformacion()
    End Sub

    Private Sub dgvConsultasDiarias_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvConsultasDiarias.CellDoubleClick
        Try

            Dim dtConsulta As DataTable = sqlExecute("select * from consultas where folio = '" + dgvConsultasDiarias.DataSource.Rows(e.RowIndex)("folio") + "'", "sermed")
            If dtConsulta.Rows.Count > 0 Then
                Dim t As New DevComponents.DotNetBar.SuperTabItem
                Dim p As New DevComponents.DotNetBar.SuperTabControlPanel
                Dim c As New CapturaSermed()
                Dim d As New DetallesConsulta()

                d.t = t
                d.tc = tabControlGeneral

                t.CloseButtonVisible = True
                t.Text = "Consulta " & dtConsulta.Rows(0)("reloj")
                t.ImageIndex = 1
                t.AttachedControl = p

                p.TabItem = t
                p.Controls.Add(c)
                p.Dock = DockStyle.Fill

                d.consulta = New ConsultaSermed(dtConsulta.Rows(0)("folio"))
                d.MostrarInformacion()

                c.captura = d.consulta.DatosCaptura
                c.detalle = d

                c.Dock = DockStyle.Fill
                c.BorderStyle = BorderStyle.FixedSingle

                c.grupoSeleccion.Visible = False

                Me.tabControlGeneral.Tabs.Add(t)
                Me.tabControlGeneral.Controls.Add(p)

                Me.tabControlGeneral.SelectedTab = t
                c.mostrarInformacion()
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tabControlGeneral_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles tabControlGeneral.SelectedTabChanged
        If tabControlGeneral.SelectedTab.Equals(tabConsultasDiarias) Then
            dtRegistro = sqlExecute("select fecha from consultas where fecha = '" & FechaSQL(dtpFechaBusqueda.Value) & "'", "sermed")
            mostrarInformacion()
        End If
    End Sub

    Private Sub comboFiltroExternos_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles comboFiltroExternos.SelectedIndexChanged
        If tabControlGeneral.SelectedTab.Equals(tabConsultasDiarias) Then
            dtRegistro = sqlExecute("select fecha from consultas where fecha = '" & FechaSQL(dtpFechaBusqueda.Value) & "'", "sermed")
            mostrarInformacion()
        End If
    End Sub

    Private Sub comboFiltroEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboFiltroEstado.SelectedIndexChanged
        If tabControlGeneral.SelectedTab.Equals(tabConsultasDiarias) Then
            dtRegistro = sqlExecute("select fecha from consultas where fecha = '" & FechaSQL(dtpFechaBusqueda.Value) & "'", "sermed")
            mostrarInformacion()
        End If
    End Sub
End Class