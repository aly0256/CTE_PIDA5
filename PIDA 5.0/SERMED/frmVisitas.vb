Public Class frmVisitas

    Dim fecha_busqueda As Date = Date.Now
    Dim dtFechaBusqueda As New DataTable

    Dim visitasAbiertas As New ArrayList

    Private Sub frmVisitas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dtpFechaBusqueda.MaxDate = Date.Now

        Try
            dtFechaBusqueda = sqlExecute("select top 1 fecha from visitas order by fecha desc", "sermed")
            If dtFechaBusqueda.Rows.Count > 0 Then
                fecha_busqueda = dtFechaBusqueda.Rows(0)("fecha")
                dtpFechaBusqueda.Value = fecha_busqueda
            End If
            comboFiltroEstado.Text = "Todas"
            comboFiltroExternos.Text = "Todos"

            SuperTabItem1.CloseButtonVisible = False
        Catch ex As Exception

        End Try
    End Sub

    Public Sub cargarDatosGeneral()    
        dgvVisitasDiarias.DataSource = DatosPorFecha()
        dgvVisitasDiarias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvVisitasDiarias.AutoResizeColumns()
        labelConteo.Text = dgvVisitasDiarias.Rows.Count - 1 & " Visitas "
    End Sub

    Public Function DatosPorFecha() As DataTable
        Dim query As String = "select folio as 'ID', reloj as 'Reloj', nombres as 'Nombre', fecha as 'Fecha', hora_entro as 'Entró',  hora_salio as 'Salió', tiempo as 'Duración' from visitas"

        query += " where fecha = '" + fecha_busqueda + "' "

        If comboFiltroExternos.SelectedItem = "Externos" Then
            query += " and reloj = 'Exter' "
        ElseIf comboFiltroExternos.SelectedItem = "Empleados" Then
            query += " and reloj != 'Exter' "
        End If

        If comboFiltroEstado.SelectedItem = "Concluidas" Then
            query += " and tiempo != '' "
        ElseIf comboFiltroEstado.SelectedItem = "Sin Concluir" Then
            query += " and tiempo = '' "
        End If

        Return sqlExecute(query, "sermed")
    End Function

    

    Private Sub dtpFechaBusqueda_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaBusqueda.ValueChanged
        fecha_busqueda = dtpFechaBusqueda.Value
        cargarDatosGeneral()
    End Sub

    Private Sub comboFiltroExternos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboFiltroExternos.SelectedIndexChanged
        cargarDatosGeneral()
    End Sub

    Private Sub comboFiltroEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboFiltroEstado.SelectedIndexChanged
        cargarDatosGeneral()
    End Sub

    Private Sub btnConcluirDia_Click(sender As Object, e As EventArgs) Handles btnConcluirDia.Click
        Try
            Dim dtConcluirDia As DataTable = sqlExecute("select * from visitas where fecha = '" + FechaSQL(fecha_busqueda) + "' and tiempo = ''", "sermed")
            If dtConcluirDia.Rows.Count > 0 Then
                Dim VisitasDeHoySinConcluir As New ArrayList
                For Each row As DataRow In dtConcluirDia.Rows
                    VisitasDeHoySinConcluir.Add(New visita(row))
                Next
                For Each visita As visita In VisitasDeHoySinConcluir
                    visita.minutos = 1
                    visita.tiempo = "00:01"
                    visita.guardar()
                Next

                cargarDatosGeneral()

            End If
        Catch ex As Exception

        End Try        
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Anterior("visitas", "fecha", FechaSQL(fecha_busqueda), dtFechaBusqueda, "sermed")
        If dtFechaBusqueda.Rows.Count > 0 Then
            dtpFechaBusqueda.Value = dtFechaBusqueda.Rows(0)("fecha")
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Siguiente("visitas", "fecha", FechaSQL(fecha_busqueda), dtFechaBusqueda, "sermed")
        If dtFechaBusqueda.Rows.Count > 0 Then
            dtpFechaBusqueda.Value = dtFechaBusqueda.Rows(0)("fecha")
        End If
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        Primero("visitas", "fecha", dtFechaBusqueda, "sermed")
        If dtFechaBusqueda.Rows.Count > 0 Then
            dtpFechaBusqueda.Value = dtFechaBusqueda.Rows(0)("fecha")
        End If
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Ultimo("visitas", "fecha", dtFechaBusqueda, "sermed")
        If dtFechaBusqueda.Rows.Count > 0 Then
            dtpFechaBusqueda.Value = dtFechaBusqueda.Rows(0)("fecha")
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Dispose()
    End Sub

    Private Sub dgvVisitasDiarias_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVisitasDiarias.CellDoubleClick
        Try
            Dim dtVisita As DataTable = sqlExecute("select * from visitas where cod_visita = '" + dgvVisitasDiarias.DataSource.Rows(e.RowIndex)("ID") + "'", "sermed")
            If dtVisita.Rows.Count > 0 Then

                Dim existe As Boolean = False

                For Each TAB As DevComponents.DotNetBar.SuperTabItem In SuperTabControl1.Tabs
                    If TAB.AccessibleDescription.Equals(dtVisita.Rows(0)("cod_visita")) Then
                        existe = True
                        SuperTabControl1.SelectedTab = TAB
                    End If
                Next

                If Not existe Then
                    Dim t As New DevComponents.DotNetBar.SuperTabItem                    
                    Dim p As New DevComponents.DotNetBar.SuperTabControlPanel
                    Dim d As New frmDetallesVisita
                    d.t = t
                    AddHandler d.btnCerrar.Click, AddressOf HandlerSalir
                    AddHandler d.btnCambios.Click, AddressOf HandlerTerminar

                    t.CloseButtonVisible = True
                    t.Text = "Visita: " & dtVisita.Rows(0)("reloj")
                    t.ImageIndex = 1
                    t.AccessibleDescription = dtVisita.Rows(0)("cod_visita")

                    t.AttachedControl = p
                    p.TabItem = t

                    p.Controls.Add(d)
                    p.Dock = DockStyle.Fill
                    d.Dock = DockStyle.Fill
                    d.BorderStyle = BorderStyle.FixedSingle
                    d.visita = New visita(dtVisita.Rows(0))

                    Me.SuperTabControl1.Tabs.Add(t)
                    Me.SuperTabControl1.Controls.Add(p)


                    Me.SuperTabControl1.SelectedTab = t

                    d.MostrarInformacion()

                    visitasAbiertas.Add(d)

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        'Try

        Dim t As New DevComponents.DotNetBar.SuperTabItem
        Dim p As New DevComponents.DotNetBar.SuperTabControlPanel
        Dim d As New frmDetallesVisita
        d.t = t
        AddHandler d.btnCerrar.Click, AddressOf HandlerSalir
        AddHandler d.btnCambios.Click, AddressOf HandlerTerminar

        t.CloseButtonVisible = True
        t.Text = "Nueva Visita"
        t.ImageIndex = 1
        ' t.AccessibleDescription = dtVisita.Rows(0)("cod_visita")

        t.AttachedControl = p
        p.TabItem = t

        p.Controls.Add(d)
        p.Dock = DockStyle.Fill
        d.Dock = DockStyle.Fill
        d.BorderStyle = BorderStyle.FixedSingle
        d.visita = New visita()

        visitasAbiertas.Add(d)

        Me.SuperTabControl1.Tabs.Add(t)
        Me.SuperTabControl1.Controls.Add(p)

        Me.SuperTabControl1.SelectedTab = t

        d.MostrarInformacion()

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Public Sub HandlerSalir(sender As Object, e As EventArgs)
        For Each visita As frmDetallesVisita In visitasAbiertas
            If sender.Equals(visita.btnCerrar) Then
                visita.visita.guardar()
                SuperTabControl1.Tabs.Remove(visita.t)
                btnLast.PerformClick()
            End If
        Next
    End Sub

    Public Sub HandlerTerminar(sender As Object, e As EventArgs)
        For Each visita As frmDetallesVisita In visitasAbiertas
            If sender.Equals(visita.btnCambios) Then
                Dim ts As TimeSpan = Date.Now.TimeOfDay - visita.visita.hora_entro.TimeOfDay
                visita.visita.tiempo = "00:" & completar(Math.Round(ts.TotalMinutes), 2)
                visita.visita.minutos = ts.TotalMinutes
                visita.visita.guardar()
                SuperTabControl1.Tabs.Remove(visita.t)

                btnLast.PerformClick()

            End If
        Next
    End Sub

    Private Function completar(numero As Integer, caracteres As Integer) As String
        Dim s As String = numero.ToString
        While (s.Length < caracteres)
            s = "0" + s
        End While
        Return s
    End Function


    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If MsgBox("¿Seguro que desea eliminar las " & dgvVisitasDiarias.SelectedRows.Count & " visitas seleccionada?") = MsgBoxResult.Ok Then
            For Each row As DataGridViewRow In dgvVisitasDiarias.SelectedRows

                sqlExecute("delete from visitas where cod_visita = '" & dgvVisitasDiarias.DataSource.rows(dgvVisitasDiarias.Rows.IndexOf(row))("id") & "'", "sermed")
            Next
        End If
        If DatosPorFecha.Rows.Count > 0 Then
            dgvVisitasDiarias.DataSource = DatosPorFecha()
            dgvVisitasDiarias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvVisitasDiarias.AutoResizeColumns()
        Else
            btnPrev.PerformClick()
        End If

    End Sub

End Class


Public Class visita

    Public concluida As Boolean = False

    Public cod_visita As String
    Public reloj As String = ""
    Public nombres As String = ""
    Public fecha As Date = Date.Now
    Public hora_entro As DateTime = Date.Now
    Public salida As String
    Public hora_salio As DateTime
    Public minutos As Integer
    Public tiempo As String = ""
    Public inyeccion As Boolean = False
    Public inyec_det As String = ""
    Public curacion As Boolean = False
    Public cura_det As String = ""
    Public plan_fam As Boolean = False
    Public cod_pato1 As String = "000"
    Public cod_pato2 As String = "000"
    Public cod_pato3 As String = "000"
    Public comentario As String = ""
    Public medicamento As String = ""
    Public responsabl As String = ""
    Public consulta As String = False
    Public externo As Boolean = False
    Public reloj_famil As String = ""
    Public empresa As String = ""
    Public ext_edad As String = ""
    Public ext_sexo As String = "M"
    Public acc_traba As Boolean = False
    Public acc_tray As Boolean = False


    Sub New()
        Dim dtVisita As DataTable = sqlExecute("select top 1 cod_visita from visitas order by cod_visita desc", "sermed")
        If dtVisita.Rows.Count > 0 Then
            Me.cod_visita = completar(Integer.Parse(dtVisita.Rows(0)("cod_visita")) + 1, 6)
        End If
    End Sub

    Private Function completar(numero As Integer, caracteres As Integer) As String
        Dim s As String = numero.ToString
        While (s.Length < caracteres)
            s = "0" + s
        End While
        Return s
    End Function

    Sub New(row As DataRow)
        On Error Resume Next
        Me.cod_visita = row("cod_visita")
        Me.reloj = row("reloj")
        Me.nombres = row("nombres")
        Me.fecha = row("fecha")
        Me.tiempo = row("tiempo")
        Me.hora_entro = row("hora_entro")
        Me.salida = row("hora_salio")
        Me.responsabl = row("responsabl")

        If salida.equals("") Then
            concluida = False
        Else
            concluida = True
            hora_salio = row("hora_salio")
        End If

        Me.comentario = row("comentario")
        Me.medicamento = row("medicament")
        Me.externo = row("externo")
        Me.cod_pato1 = row("cod_pato1")
        Me.cod_pato2 = row("cod_pato2")
        Me.cod_pato3 = row("cod_pato3")
        Me.empresa = row("empresa")
        Me.reloj_famil = row("reloj_fam")
        Me.ext_sexo = row("ext_sexo")
        Me.ext_edad = row("ext_edad")
        Me.inyeccion = row("inyeccion")
        Me.curacion = row("curacion")
        Me.acc_traba = row("acc_traba")
        Me.acc_tray = row("acc_tray")
        Me.plan_fam = row("plan_fam")
    End Sub

    Public Sub guardar()
        Dim dtExisteVisita As DataTable = sqlExecute("select cod_visita from visitas where cod_visita = '" + cod_visita + "'", "sermed")
        If dtExisteVisita.Rows.Count <= 0 Then
            sqlExecute("insert into visitas (cod_visita) values ('" + Me.cod_visita + "')", "sermed")
        End If
        '

        If minutos > 0 Then
            hora_salio = hora_entro.AddMinutes(minutos)
        End If
        ' datos generales
        sqlExecute("update visitas set reloj = '" & reloj & "', nombres = '" & nombres & "', fecha = '" & FechaSQL(fecha) & "', hora_entro = '" & hora_entro.ToShortTimeString & "', tiempo = '" & tiempo & "', hora_salio = '" & IIf(tiempo.Equals(""), "", hora_salio.ToShortTimeString) & "' where cod_visita = '" & cod_visita & "'", "sermed")
        ' usuario
        sqlExecute("update visitas set responsabl = '" & IIf(Declaraciones.Usuario <> "", Declaraciones.Usuario, "PIDA") & "' where cod_visita = '" + Me.cod_visita + "'", "sermed")
        ' datos externos
        sqlExecute("update visitas set externo = '" & externo & "', reloj_fam = '" & reloj_famil & "', ext_edad = '" & ext_edad & "', ext_sexo = '" & ext_sexo & "', empresa = '" & empresa & "' where cod_visita = '" & cod_visita & "'", "sermed")
        ' asistencia
        sqlExecute("update visitas set inyeccion = '" & inyeccion & "', inyec_det = '" & inyec_det & "', curacion = '" & curacion & "', cura_det = '" & cura_det & "', plan_fam = '" & plan_fam & "', acc_tray = '" & acc_tray & "', acc_traba = '" & acc_traba & "' where cod_visita = '" + cod_visita + "'", "sermed")
        ' causas/patologia
        sqlExecute("update visitas set cod_pato1 = '" & cod_pato1 & "', cod_pato2 = '" & cod_pato2 & "', cod_pato3  = '" & cod_pato3 & "' where cod_visita = '" & cod_visita & "'", "sermed")
        ' conclusiones
        sqlExecute("update visitas set comentario = '" & comentario & "', medicament = '" & medicamento & "', consulta = '" & consulta & "' where cod_visita = '" & cod_visita & "'", "sermed")
    End Sub

End Class