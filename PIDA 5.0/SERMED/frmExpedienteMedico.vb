Public Class frmExpedienteMedico

    Dim empleado As EmpleadoSermed
    Dim dtRegistro As New DataTable
    Dim ConsultasAbiertas As New ArrayList
    Dim VisitasAbiertas As New ArrayList

    Public Sub frmExpedienteMedico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarInformacion()
    End Sub

    Public Sub MostrarInformacion(Optional ByVal reloj As String = "")
        Dim dtReloj As New DataTable
        If reloj.Equals("") Then
            dtReloj = sqlExecute("select top 1 reloj from personal order by reloj asc")
            empleado = New EmpleadoSermed(dtReloj(0)("reloj"))
        Else
            empleado = New EmpleadoSermed(reloj)
        End If

        txtAlta.Text = empleado.alta
        txtBaja.Text = empleado.baja
        txtReloj.Text = empleado.reloj
        'txtClase.Text = empleado.clase
        txtNombreEmpleado.Text = empleado.nombre
        txtApaterno.Text = empleado.apaterno
        txtAmaterno.Text = empleado.amaterno
        campoEdadEmpleado.Text = empleado.edad
        txtPuesto.Text = empleado.puesto
        campoSexo.Text = empleado.sexo
        txtSupervisor.Text = empleado.super
        txtTipoEmp.Text = empleado.tipo
        txtDepto.Text = empleado.depto
        txtTurno.Text = empleado.turno
        txtHorario.Text = empleado.horario

        If empleado.baja.Equals("") Then
            lblEstado.Text = "ACTIVO"
            lblEstado.BackColor = Color.LimeGreen
        Else
            lblEstado.Text = "INACTIVO"
            lblEstado.BackColor = Color.IndianRed
        End If
        tabControlVisitas.Tabs.Clear()
        tabControlVisitas.Tabs.Add(tabVisitas)
        tabControlVisitas.SelectedTab = tabVisitas

        cargarVisitasDiarias()

        tabControlConsultas.Tabs.Clear()
        tabControlConsultas.Tabs.Add(TabConsultas)
        tabControlConsultas.SelectedTab = TabConsultas
        cargarConsultas()
    End Sub

    Private Sub cargarVisitasDiarias()

       
        dgvVisitas.DataSource = sqlExecute("select folio as 'Folio', fecha as 'Fecha', hora_entro as 'Entró',  hora_salio as 'Salió', tiempo as 'Duración' from visitas where reloj = '" & empleado.reloj & "'", "sermed")
        dgvVisitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvVisitas.AutoResizeColumns()
    End Sub

    Private Sub cargarConsultas()      
        dgvConsultas.DataSource = sqlExecute("select folio as 'Folio', fecha as 'Fecha', responsable as 'Responsable', prox_cita as 'Próxima Cita' from consultas where reloj = '" & empleado.reloj & "'", "sermed")
        dgvConsultas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvConsultas.AutoResizeColumns()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Siguiente("personal", "reloj", empleado.reloj, dtRegistro)
        If dtRegistro.Rows.Count > 0 Then
            MostrarInformacion(dtRegistro.Rows(0)("reloj"))
        End If
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Anterior("personal", "reloj", empleado.reloj, dtRegistro)
        If dtRegistro.Rows.Count > 0 Then
            MostrarInformacion(dtRegistro.Rows(0)("reloj"))
        End If
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Ultimo("personal", "reloj", dtRegistro)
        If dtRegistro.Rows.Count > 0 Then
            MostrarInformacion(dtRegistro.Rows(0)("reloj"))
        End If
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        Primero("personal", "reloj", dtRegistro)
        If dtRegistro.Rows.Count > 0 Then
            MostrarInformacion(dtRegistro.Rows(0)("reloj"))
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            frmBusca.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                MostrarInformacion(Reloj)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, Err.Number, ex.Message)
        End Try
    End Sub

    Private Sub dgvConsultas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvConsultas.CellDoubleClick
        Try
            Dim dtConsulta As DataTable = sqlExecute("select * from consultas where folio = '" + dgvConsultas.DataSource.Rows(e.RowIndex)("folio") + "'", "sermed")
            If dtConsulta.Rows.Count > 0 Then
                Dim t As New DevComponents.DotNetBar.SuperTabItem
                Dim p As New DevComponents.DotNetBar.SuperTabControlPanel
                'Dim c As New CapturaSermed(dtVisita.Rows(0))
                Dim d As New DetallesConsulta

                d.t = t
                d.tc = tabControlConsultas

                t.CloseButtonVisible = True
                t.Text = "Consulta " & dtConsulta.Rows(0)("fecha")
                t.ImageIndex = 1

                t.AttachedControl = p
                p.TabItem = t

                p.Controls.Add(d)
                p.Dock = DockStyle.Fill

                d.consulta = New ConsultaSermed(dtConsulta.Rows(0)("folio"))
                d.MostrarInformacion()
                'c.detalle = d

                ' c.Dock = DockStyle.Fill
                'c.BorderStyle = BorderStyle.FixedSingle
                'c.mostrarInformacion()

                Me.tabControlConsultas.Tabs.Add(t)
                Me.tabControlConsultas.Controls.Add(p)

                Me.tabControlConsultas.SelectedTab = t

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgvVisitas_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVisitas.CellDoubleClick
         Try
            Dim dtVisita As DataTable = sqlExecute("select * from visitas where folio = '" + dgvVisitas.DataSource.Rows(e.RowIndex)("folio") + "'", "sermed")
            If dtVisita.Rows.Count > 0 Then
                Dim t As New DevComponents.DotNetBar.SuperTabItem
                Dim p As New DevComponents.DotNetBar.SuperTabControlPanel
                'Dim c As New CapturaSermed(dtVisita.Rows(0))
                Dim d As New DetallesVisita

                d.t = t
                d.tc = tabControlVisitas

                t.CloseButtonVisible = True
                t.Text = "Visita " & dtVisita.Rows(0)("fecha")
                t.ImageIndex = 1

                t.AttachedControl = p
                p.TabItem = t

                p.Controls.Add(d)
                p.Dock = DockStyle.Fill

                d.visita = New VisitaSermed(dtVisita.Rows(0)("folio"))
                d.MostrarInformacion()               

                Me.tabControlVisitas.Tabs.Add(t)
                Me.tabControlVisitas.Controls.Add(p)

                Me.tabControlVisitas.SelectedTab = t

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If TabControlGeneral.SelectedTab.Equals(TabItemVisitasDiarias) Then
            Try

                Dim t As New DevComponents.DotNetBar.SuperTabItem
                Dim p As New DevComponents.DotNetBar.SuperTabControlPanel                
                Dim d As New DetallesVisita

                d.t = t
                d.tc = tabControlVisitas

                t.CloseButtonVisible = True
                t.Text = "Nueva Visita"
                t.ImageIndex = 1

                t.AttachedControl = p
                p.TabItem = t

                p.Controls.Add(d)
                p.Dock = DockStyle.Fill

                d.visita = New VisitaSermed()
                d.visita.DatosCaptura = New DatosCapturaSermed(empleado)
                d.editable = True
                d.MostrarInformacion()
               
                Me.tabControlVisitas.Tabs.Add(t)
                Me.tabControlVisitas.Controls.Add(p)

                Me.tabControlVisitas.SelectedTab = t



            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf TabControlGeneral.SelectedTab.Equals(TabItemConsultas) Then
            Try

                Dim t As New DevComponents.DotNetBar.SuperTabItem
                Dim p As New DevComponents.DotNetBar.SuperTabControlPanel                
                Dim d As New DetallesConsulta

                d.t = t
                d.tc = tabControlConsultas

                t.CloseButtonVisible = True
                t.Text = "Nueva Consulta"
                t.ImageIndex = 1

                t.AttachedControl = p
                p.TabItem = t

                p.Controls.Add(d)
                p.Dock = DockStyle.Fill

                d.consulta = New ConsultaSermed()
                d.consulta.DatosCaptura = New DatosCapturaSermed(empleado)
                d.editable = True
                d.MostrarInformacion()                

                Me.tabControlConsultas.Tabs.Add(t)
                Me.tabControlConsultas.Controls.Add(p)

                Me.tabControlConsultas.SelectedTab = t

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub tabControlVisitas_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles tabControlVisitas.SelectedTabChanged
        If tabControlVisitas.SelectedTab.Equals(tabVisitas) Then
            cargarVisitasDiarias()
        End If
    End Sub

    Private Sub tabControlConsultas_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles tabControlConsultas.SelectedTabChanged
        If tabControlConsultas.SelectedTab.Equals(TabConsultas) Then
            cargarConsultas()
        End If
    End Sub

End Class