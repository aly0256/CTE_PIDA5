Public Class Visitas

    ' -------------------------------------

    Public VisitasAbiertas As New ArrayList
    Public fechaDeBusqueda As New Date

    Public dtRegistro As New DataTable
    Public dtVisitasPorFecha As New DataTable

    ' -------------------------------------

    Public Sub mostrarInformacion()
        If dtRegistro.Rows.Count > 0 Then
            fechaDeBusqueda = dtRegistro.Rows(0)("fecha")
            'dtVisitasPorFecha = sqlExecute("select folio as 'Folio', reloj as 'Reloj', nombres as 'Nombres', fecha as 'Fecha', hora_entro as 'Entrada', hora_salio as 'Salida', tiempo as 'Duración' from visitas where fecha = '" & FechaSQL(Me.fechaDeBusqueda) & "'", "sermed")
            dtVisitasPorFecha = DatosPorFecha()
            dgvVisitasDiarias.DataSource = dtVisitasPorFecha
            dgvVisitasDiarias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvVisitasDiarias.AutoResizeColumns()
            dtpFechaBusqueda.Value = fechaDeBusqueda
        Else

        End If
    End Sub

    Public Function DatosPorFecha() As DataTable
        Dim query As String = "select folio as 'Folio', reloj as 'Reloj', nombres as 'Nombre', fecha as 'Fecha', hora_entro as 'Entró',  hora_salio as 'Salió', tiempo as 'Duración' from visitas"

        query += " where fecha = '" + fechaDeBusqueda + "' "

        If comboFiltroExternos.SelectedItem.Equals(ComboItemExternos) Then
            query += " and reloj = 'Exter' "
        ElseIf comboFiltroExternos.SelectedItem.Equals(ComboItemEmpleados) Then
            query += " and reloj != 'Exter' "
        End If

        If comboFiltroEstado.SelectedItem.Equals(ComboItemConcluidas) Then
            query += " and tiempo != '' "
        ElseIf comboFiltroEstado.SelectedItem.Equals(ComboItemSinConcluir) Then
            query += " and tiempo = '' "
        End If

      

        Return sqlExecute(query, "sermed")
    End Function

    Private Sub Visitas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
       
        comboFiltroEstado.SelectedItem = ComboItemTodas
        comboFiltroExternos.SelectedItem = ComboItemTodos

        Primero("visitas", "fecha", dtRegistro, "sermed")
        dtpFechaBusqueda.MinDate = dtRegistro.Rows(0)("fecha")

        dtpFechaBusqueda.MaxDate = Date.Now

        Ultimo("visitas", "fecha", dtRegistro, "sermed")
        mostrarInformacion()
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        Primero("visitas", "fecha", dtRegistro, "sermed")
        mostrarInformacion()
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Anterior("visitas", "fecha", FechaSQL(fechaDeBusqueda), dtRegistro, "sermed")
        mostrarInformacion()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Siguiente("visitas", "fecha", FechaSQL(fechaDeBusqueda), dtRegistro, "sermed")
        mostrarInformacion()
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Ultimo("visitas", "fecha", dtRegistro, "sermed")
        mostrarInformacion()
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click

    End Sub


    Private Sub dtpFechaBusqueda_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaBusqueda.ValueChanged
        dtRegistro = sqlExecute("select fecha from visitas where fecha = '" & FechaSQL(dtpFechaBusqueda.Value) & "'", "sermed")
        mostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try

            Dim t As New DevComponents.DotNetBar.SuperTabItem
            Dim p As New DevComponents.DotNetBar.SuperTabControlPanel
            Dim c As New CapturaSermed()
            Dim d As New DetallesVisita

            d.t = t
            d.tc = tabControlGeneral

            t.CloseButtonVisible = True
            t.Text = "Nueva Visita"
            t.ImageIndex = 1

            t.AttachedControl = p
            p.TabItem = t

            p.Controls.Add(c)
            p.Dock = DockStyle.Fill

            d.visita = New VisitaSermed()
            d.editable = True
            d.MostrarInformacion()

            c.captura = d.visita.DatosCaptura
            c.detalle = d
            d.editable = True

            c.Dock = DockStyle.Fill
            c.BorderStyle = BorderStyle.FixedSingle
            ' c.mostrarInformacion()

            Me.tabControlGeneral.Tabs.Add(t)
            Me.tabControlGeneral.Controls.Add(p)

            Me.tabControlGeneral.SelectedTab = t



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        
    End Sub

    Private Sub dgvVisitasDiarias_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVisitasDiarias.CellDoubleClick
        Try
            Dim dtVisita As DataTable = sqlExecute("select * from visitas where folio = '" + dgvVisitasDiarias.DataSource.Rows(e.RowIndex)("folio") + "'", "sermed")
            If dtVisita.Rows.Count > 0 Then
                Dim t As New DevComponents.DotNetBar.SuperTabItem
                Dim p As New DevComponents.DotNetBar.SuperTabControlPanel
                Dim c As New CapturaSermed()
                Dim d As New DetallesVisita

                d.t = t
                d.tc = tabControlGeneral

                t.CloseButtonVisible = True
                t.Text = "Visita " & dtVisita.Rows(0)("reloj")
                t.ImageIndex = 1

                t.AttachedControl = p
                p.TabItem = t

                p.Controls.Add(c)
                p.Dock = DockStyle.Fill

                d.visita = New VisitaSermed(dtVisita.Rows(0)("folio"))
                d.MostrarInformacion()

                c.captura = d.visita.DatosCaptura
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
        If tabControlGeneral.SelectedTab.Equals(tabVisitasDiarias) Then
            dtRegistro = sqlExecute("select fecha from visitas where fecha = '" & FechaSQL(dtpFechaBusqueda.Value) & "'", "sermed")
            mostrarInformacion()
        End If
    End Sub

    Private Sub comboFiltroExternos_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles comboFiltroExternos.SelectedIndexChanged
        If tabControlGeneral.SelectedTab.Equals(tabVisitasDiarias) Then
            dtRegistro = sqlExecute("select fecha from visitas where fecha = '" & FechaSQL(dtpFechaBusqueda.Value) & "'", "sermed")
            mostrarInformacion()
        End If
    End Sub

    Private Sub comboFiltroEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboFiltroEstado.SelectedIndexChanged
        If tabControlGeneral.SelectedTab.Equals(tabVisitasDiarias) Then
            dtRegistro = sqlExecute("select fecha from visitas where fecha = '" & FechaSQL(dtpFechaBusqueda.Value) & "'", "sermed")
            mostrarInformacion()
        End If
    End Sub
End Class