Public Class frmConsultas

    Dim dtPersonal As DataTable
    Public servicio As String
    Dim dtConsultas As DataTable

    Dim filtros As String

    Private Sub frmConsultas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim dtServicios As DataTable = sqlExecute("select  cod_servicio, nombre,encargado from servicios", "sermed")
            dtServicios.Rows.Add({"TODO", "TODOS LOS SERVICIOS", "N/A"})
            cmbServicio.DataSource = dtServicios
            cmbServicio.ValueMember = "cod_servicio"

            dtFecha.Value = Today
            Panel5.Enabled = False
            ComboTree1.DataSource = sqlExecute("select cod_servicio, nombre from servicios", "sermed")
            ComboTree1.ValueMember = "cod_servicio"

            cmbsintoma.DataSource = sqlExecute("select * from grupos_sintomas", "sermed")
            cmbdescripcion.DataSource = sqlExecute("select * from sintomas", "sermed")

            MostrarInformacion()
            For Each d As DevComponents.Schedule.Model.WorkDay In CalendarView1.CalendarModel.WorkDays
                d.WorkStartTime = New DevComponents.Schedule.Model.WorkTime(6, 0)
                d.WorkEndTime = New DevComponents.Schedule.Model.WorkTime(22, 0)

            Next
            CalendarView1.ShowOnlyWorkDayHours = True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub MostrarInformacion()
        Try

            dgConsultas.AutoGenerateColumns = False

            Dim fuente As Font = New Font("Microsoft Sans Serif", 9, FontStyle.Bold)

            Dim consulta As String =
                "select " & _
                "sermed.dbo.consultas.folio, " & _
                "personal.dbo.personalvw.cod_comp, " & _
                "sermed.dbo.consultas.reloj, " & _
                "personal.dbo.personalvw.cod_planta, " & _
                "personal.dbo.personalvw.nombre_planta, " & _
                "personal.dbo.personalvw.cod_puesto, " & _
                "personal.dbo.personalvw.nombre_puesto, " & _
                "personal.dbo.personalvw.cod_super, " & _
                "personal.dbo.personalvw.cod_depto, " & _
                "personal.dbo.personalvw.nombre_super, " & _
                "personal.dbo.personalvw.cod_turno, " & _
                "sermed.dbo.consultas.cod_servicio, " & _
                "sermed.dbo.consultas.inicio, " & _
                "convert(date, sermed.dbo.consultas.inicio) as fecha, " & _
                "convert(time, sermed.dbo.consultas.inicio) as hora, " & _
                "sermed.dbo.consultas.familiar, " & _
                "sermed.dbo.consultas.duracion, " & _
                "sermed.dbo.consultas.concluida, " & _
                "sermed.dbo.consultas.sintoma, " & _
                "sermed.dbo.consultas.subsintoma " & _
                "from consultas " & _
                "left join personal.dbo.personalvw on personal.dbo.personalvw.reloj = sermed.dbo.consultas.reloj " & _
                "where  convert(date, sermed.dbo.consultas.inicio) = '" & FechaSQL(dtFecha.Value) & "'" & IIf(cmbServicio.SelectedValue.ToString.Trim <> "TODO", " and sermed.dbo.consultas.cod_servicio = '" & cmbServicio.SelectedValue & "'", "")



            dtConsultas = sqlExecute(consulta, "sermed")


            dgConsultas.DataSource = dtConsultas

            dgConsultas.Columns("columnaFolio").DefaultCellStyle.BackColor = SystemColors.InactiveCaption

            dgConsultas.Columns("columnaServicio").DefaultCellStyle.BackColor = SystemColors.InactiveCaption


            dgConsultas.Columns("columnaCod_comp").DefaultCellStyle.BackColor = SystemColors.InactiveCaption


            dgConsultas.Columns("columnaReloj").DefaultCellStyle.BackColor = SystemColors.InactiveCaption
            dgConsultas.Columns("columnaReloj").DefaultCellStyle.Font = fuente

            dgConsultas.Columns("columnaNombres").DefaultCellStyle.BackColor = SystemColors.InactiveCaption
            dgConsultas.Columns("columnaDepartamento").DefaultCellStyle.BackColor = SystemColors.InactiveCaption
            dgConsultas.Columns("columnaTurno").DefaultCellStyle.BackColor = SystemColors.InactiveCaption


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub CargarAppointments(Optional Seleccionado As String = "")

        CalendarView1.CalendarModel.Appointments.Clear()
        
        Dim consulta As String =
                "select " & _
                "sermed.dbo.consultas.folio, " & _
                "personal.dbo.personalvw.cod_comp, " & _
                "sermed.dbo.consultas.reloj, " & _
                "personal.dbo.personalvw.nombres, " & _
                "personal.dbo.personalvw.cod_depto, " & _
                "personal.dbo.personalvw.nombre_super, " & _
                "personal.dbo.personalvw.cod_turno, " & _
                "sermed.dbo.consultas.cod_servicio, " & _
                "sermed.dbo.servicios.color, " & _
                "sermed.dbo.consultas.inicio, " & _
                "convert(date, sermed.dbo.consultas.inicio) as fecha, " & _
                "convert(time, sermed.dbo.consultas.inicio) as hora, " & _
                "sermed.dbo.consultas.familiar, " & _
                "sermed.dbo.consultas.duracion, " & _
                "sermed.dbo.consultas.concluida, " & _
                "sermed.dbo.consultas.sintoma, " & _
                "sermed.dbo.consultas.subsintoma " & _
                "from consultas " & _
                "left join sermed.dbo.servicios on sermed.dbo.servicios.cod_servicio = sermed.dbo.consultas.cod_servicio " & _
                "left join personal.dbo.personalvw on personal.dbo.personalvw.reloj = sermed.dbo.consultas.reloj "

            If CalendarView1.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Day Then
            consulta &= "where  convert(date, sermed.dbo.consultas.inicio) = '" & FechaSQL(dtFecha.Value) & "'"
            ElseIf CalendarView1.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Week Then
                Dim dtPeriodo As DataTable = sqlExecute("select * from periodos where fecha_ini <= '" & FechaSQL(dtFecha.Value) & "' and fecha_fin >= '" & FechaSQL(dtFecha.Value) & "' and periodo_especial = '0'", "TA")
                If dtPeriodo.Rows.Count > 0 Then
                consulta &= "where convert(date, sermed.dbo.consultas.inicio) between '" & FechaSQL(dtPeriodo.Rows(0)("fecha_ini")) & "' and '" & FechaSQL(dtPeriodo.Rows(0)("fecha_fin")) & "'"
                Else
                    CalendarView1.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Day
                consulta &= "where  convert(date, sermed.dbo.consultas.inicio) = '" & FechaSQL(dtFecha.Value) & "'"
                End If
            ElseIf CalendarView1.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Month Then
            consulta &= "where datepart(month, inicio) = '" & dtFecha.Value.Month & "' and datepart(year, inicio) = '" & dtFecha.Value.Year & "'"
        End If

        consulta &= IIf(cmbServicio.SelectedValue.ToString.Trim <> "TODO", " and  sermed.dbo.consultas.cod_servicio = '" & cmbServicio.SelectedValue & "'", "")



            Dim dtConsultasCalendario As DataTable = sqlExecute(consulta, "sermed")

            For Each row As DataRow In dtConsultasCalendario.Rows
                Dim app As New DevComponents.Schedule.Model.Appointment
            app.StartTime = row("inicio")
            app.CategoryColor = Trim(row("color"))
                app.EndTime = app.StartTime.AddMinutes(row("duracion"))
                'app.Description = row("reloj")
                app.Subject = row("reloj")
                app.Id = row("folio")
                CalendarView1.CalendarModel.Appointments.Add(app)
                CalendarView1.EnsureVisible(app)
                Try
                app.IsSelected = app.Id.ToString = Seleccionado
                Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
                End Try

                app.Locked = True
            Next
    End Sub

    Private Sub dgConsultas_Resize(sender As Object, e As EventArgs) Handles dgConsultas.Resize
        Try
            'Ocultar el nombre del empleado cuando no cabe en la tabla
            'If dgConsultas.Width <= 1054 Then
            '    dgConsultas.Columns("columnaNombres").Visible = False
            'Else
            '    dgConsultas.Columns("columnaNombres").Visible = True
            'End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dtFecha_ValueChanged(sender As Object, e As EventArgs) Handles dtFecha.ValueChanged
        Try
            lblDiaSemana.Text = DiaSem(dtFecha.Value) & " " & FechaMediaLetra(dtFecha.Value)
            lblFechaNav.Text = DiaSem(dtFecha.Value) & " " & FechaMediaLetra(dtFecha.Value)
            If CalendarView1.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Month Then
                CalendarView1.MonthView.StartDate = DateSerial(dtFecha.Value.Date.Year, dtFecha.Value.Date.Month, 1)
                CalendarView1.MonthView.EndDate = DateSerial(dtFecha.Value.Date.Year, dtFecha.Value.Date.Month, DiasMes(dtFecha.Value.Date))
            ElseIf CalendarView1.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Week Then
                CalendarView1.WeekView.DateSelectionStart = dtFecha.Value.Date
                CalendarView1.WeekView.DateSelectionEnd = dtFecha.Value.Date
            ElseIf CalendarView1.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Day Then
                CalendarView1.DayView.StartDate = dtFecha.Value.Date
                CalendarView1.DayView.EndDate = dtFecha.Value.Date
            End If
            MostrarInformacion()
            CargarAppointments()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Try
            dtFecha.Value = dtFecha.Value.AddDays(-1)
            If CalendarView1.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Month Then
                CalendarView1.MonthView.StartDate = DateSerial(dtFecha.Value.Date.Year, dtFecha.Value.Date.Month, 1)
                CalendarView1.MonthView.EndDate = DateSerial(dtFecha.Value.Date.Year, dtFecha.Value.Date.Month, DiasMes(dtFecha.Value.Date))
            ElseIf CalendarView1.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Week Then

                Dim dtPeriodo As DataTable = sqlExecute("select * from ta.dbo.periodos where fecha_ini <= '" & dtFecha.Value.Date & "' and fecha_fin >= '" & dtFecha.Value.Date & "' and periodo_especial = 0")
                If dtPeriodo.Rows.Count Then
                    CalendarView1.WeekView.StartDate = dtPeriodo.Rows(0)("fecha_ini")
                    CalendarView1.WeekView.EndDate = dtPeriodo.Rows(0)("fecha_fin")
                    MostrarInformacion()
                    CargarAppointments()

                End If

            ElseIf CalendarView1.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Day Then
                CalendarView1.DayView.StartDate = dtFecha.Value.Date
                CalendarView1.DayView.EndDate = dtFecha.Value.Date
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try
            dtFecha.Value = dtFecha.Value.AddDays(1)
            If CalendarView1.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Month Then
                CalendarView1.MonthView.StartDate = DateSerial(dtFecha.Value.Date.Year, dtFecha.Value.Date.Month, 1)
                CalendarView1.MonthView.EndDate = DateSerial(dtFecha.Value.Date.Year, dtFecha.Value.Date.Month, DiasMes(dtFecha.Value.Date))
            ElseIf CalendarView1.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Week Then

                Dim dtPeriodo As DataTable = sqlExecute("select * from ta.dbo.periodos where fecha_ini <= '" & dtFecha.Value.Date & "' and fecha_fin >= '" & dtFecha.Value.Date & "' and periodo_especial = 0")
                If dtPeriodo.Rows.Count Then
                    CalendarView1.WeekView.StartDate = dtPeriodo.Rows(0)("fecha_ini")
                    CalendarView1.WeekView.EndDate = dtPeriodo.Rows(0)("fecha_fin")
                    MostrarInformacion()
                    CargarAppointments()

                End If

            ElseIf CalendarView1.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Day Then
              
                CalendarView1.DayView.StartDate = dtFecha.Value.Date
                CalendarView1.DayView.EndDate = dtFecha.Value.Date
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Try
            CalendarView1.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Day

            CalendarView1.MonthView.StartDate = dtFecha.Value.Date
            CalendarView1.MonthView.EndDate = dtFecha.Value.Date

            MostrarInformacion()
            CargarAppointments()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Try
            CalendarView1.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Week

            Dim dtPeriodo As DataTable = sqlExecute("select * from ta.dbo.periodos where fecha_ini <= '" & dtFecha.Value.Date & "' and fecha_fin >= '" & dtFecha.Value.Date & "' and periodo_especial = 0")
            If dtPeriodo.Rows.Count Then
                CalendarView1.WeekView.StartDate = dtPeriodo.Rows(0)("fecha_ini")
                CalendarView1.WeekView.EndDate = dtPeriodo.Rows(0)("fecha_fin")
                MostrarInformacion()
                CargarAppointments()

            End If

          
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ButtonX3_Click(sender As Object, e As EventArgs) Handles ButtonX3.Click
        Try
            CalendarView1.SelectedView = DevComponents.DotNetBar.Schedule.eCalendarView.Month

            CalendarView1.MonthView.StartDate = DateSerial(dtFecha.Value.Date.Year, dtFecha.Value.Date.Month, 1)

            CalendarView1.MonthView.EndDate = DateSerial(dtFecha.Value.Date.Year, dtFecha.Value.Date.Month, DiasMes(dtFecha.Value.Date))

            MostrarInformacion()
            CargarAppointments()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim frm As New frmBuscarConsultas
        frm.ShowDialog()
    End Sub
    Private Sub CalendarView1_ItemClick(sender As Object, e As EventArgs) Handles CalendarView1.ItemClick
        Try
            If TryCast(sender, DevComponents.DotNetBar.Schedule.AppointmentMonthView) IsNot Nothing Then
                Dim app As DevComponents.DotNetBar.Schedule.AppointmentMonthView = sender
                Dim folio As String = app.Appointment.Id
                MostrarInformacionRapida(folio)
            ElseIf TryCast(sender, DevComponents.DotNetBar.Schedule.AppointmentWeekDayView) IsNot Nothing Then
                Dim app As DevComponents.DotNetBar.Schedule.AppointmentWeekDayView = sender
                Dim folio As String = app.Appointment.Id
                MostrarInformacionRapida(folio)
                'ElseIf TryCast(sender, DevComponents.DotNetBar.Schedule.WeekView) IsNot Nothing Then
                '    Dim dia As DevComponents.DotNetBar.Schedule.WeekView = sender
                '    dtFecha.Value = dia.DateSelectionStart.Value
            ElseIf TryCast(sender, DevComponents.DotNetBar.Schedule.MonthView) IsNot Nothing Then
                Dim dia As DevComponents.DotNetBar.Schedule.MonthView = sender
                dtFecha.Value = dia.DateSelectionStart.Value
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private EditarInformacionRapida As Boolean = False

    Private Sub MostrarInformacionRapida(folio As String)
        Try
            If folio.Trim <> "" Then
                EditarInformacionRapida = False
                Panel5.Enabled = EditarInformacionRapida
                Dim dtfolio As DataTable = sqlExecute("select * from consultas where consultas.folio = '" & folio & "'", "SERMED")
                If dtfolio.Rows.Count > 0 Then
                    txtFolio.Text = dtfolio.Rows(0)("folio")
                    txtReloj.Text = dtfolio.Rows(0)("reloj")


                    Dim dtEmpleado As DataTable = sqlExecute("select * from personalvw where reloj = '" & txtReloj.Text & "'")
                    If dtEmpleado.Rows.Count > 0 Then
                        txtNombre.Text = dtEmpleado.Rows(0)("nombres")
                        txtCia.Text = IIf(IsDBNull(dtEmpleado.Rows(0)("cod_comp")), "", RTrim(dtEmpleado.Rows(0)("cod_comp"))) & "(" & IIf(IsDBNull(dtEmpleado.Rows(0)("compania")), "", RTrim(dtEmpleado.Rows(0)("compania"))) & ")"
                        txtSuper.Text = IIf(IsDBNull(dtEmpleado.Rows(0)("cod_super")), "", RTrim(dtEmpleado.Rows(0)("cod_super"))) & "(" & IIf(IsDBNull(dtEmpleado.Rows(0)("nombre_super")), "", RTrim(dtEmpleado.Rows(0)("nombre_super"))) & ")"
                        txtTurno.Text = IIf(IsDBNull(dtEmpleado.Rows(0)("cod_hora")), "", RTrim(dtEmpleado.Rows(0)("cod_hora"))) & "(" & IIf(IsDBNull(dtEmpleado.Rows(0)("nombre_horario")), "", RTrim(dtEmpleado.Rows(0)("nombre_horario"))) & ")"
                        txtPuesto.Text = IIf(IsDBNull(dtEmpleado.Rows(0)("cod_puesto")), "", RTrim(dtEmpleado.Rows(0)("cod_puesto"))) & "(" & IIf(IsDBNull(dtEmpleado.Rows(0)("nombre_puesto")), "", RTrim(dtEmpleado.Rows(0)("nombre_puesto"))) & ")"
                        txtPlanta.Text = IIf(IsDBNull(dtEmpleado.Rows(0)("cod_planta")), "", RTrim(dtEmpleado.Rows(0)("cod_planta"))) & "(" & IIf(IsDBNull(dtEmpleado.Rows(0)("nombre_planta")), "", RTrim(dtEmpleado.Rows(0)("nombre_planta"))) & ")"

                        If IO.File.Exists(dtEmpleado.Rows(0)("foto")) Then
                            picFoto.ImageLocation = dtEmpleado.Rows(0)("foto")
                        Else
                            picFoto.Image = My.Resources.NoFoto
                        End If

                    End If

                    dtFechaConsulta.Value = dtfolio.Rows(0)("inicio")
                    dtHoraConsulta.Value = dtfolio.Rows(0)("inicio")
                    ComboTree1.SelectedValue = dtfolio.Rows(0)("cod_servicio")
                    txtDuracion.Value = dtfolio.Rows(0)("duracion")
                    sbFamiliar.Value = dtfolio.Rows(0)("familiar")
                    sbConcluida.Value = dtfolio.Rows(0)("concluida")
                    cmbsintoma.SelectedValue = dtfolio.Rows(0)("sintoma")
                    cmbdescripcion.SelectedValue = dtfolio.Rows(0)("subsintoma")
                End If
            Else
                EditarInformacionRapida = False
                Panel5.Enabled = EditarInformacionRapida
                txtFolio.Text = ""
                txtReloj.Text = ""
                txtNombre.Text = ""
                txtCia.Text = ""
                txtSuper.Text = ""
                txtTurno.Text = ""
                txtPuesto.Text = ""
                txtPlanta.Text = ""
                picFoto.Image = My.Resources.NoFoto
                dtFechaConsulta.Value = ""
                dtHoraConsulta.Value = ""
                ComboTree1.SelectedIndex = -1
                txtDuracion.Value = ""
                sbFamiliar.Value = False
                sbConcluida.Value = False
                cmbsintoma.SelectedIndex = -1
                cmbdescripcion.SelectedIndex = -1
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub CalendarView1_ItemDoubleClick(sender As Object, e As MouseEventArgs) Handles CalendarView1.ItemDoubleClick


        Try
            If TryCast(sender, DevComponents.DotNetBar.Schedule.AppointmentMonthView) IsNot Nothing Then
                Dim app As DevComponents.DotNetBar.Schedule.AppointmentMonthView = sender
                Dim folio As String = app.Appointment.Id
                'Dim frm As New frmDetalleConsulta
                'frm.folio = folio
                Dim dtConsultaSeleccionada As DataTable = sqlExecute("select tipo_paciente from consultas where folio='" & folio & "'", "sermed")
                If dtConsultaSeleccionada.Rows(0)("tipo_paciente") = 3 Then
                    Dim frm As New frmDetalleExternos
                    frm.folio = folio
                    frm.ShowDialog()
                    frm.Close()
                ElseIf dtConsultaSeleccionada.Rows(0)("tipo_paciente") = 2 Then
                    Dim frm As New frmDetalleConsulta
                    frm.folio = folio
                    frm.ShowDialog()
                    frm.Close()
                ElseIf dtConsultaSeleccionada.Rows(0)("tipo_paciente") = 1 Then
                    Dim frm As New frmDetalleEmp
                    frm.folio = folio
                    frm.ShowDialog()
                    frm.Close()
                End If
                'frm.ShowDialog()
            ElseIf TryCast(sender, DevComponents.DotNetBar.Schedule.AppointmentWeekDayView) IsNot Nothing Then
                Dim app As DevComponents.DotNetBar.Schedule.AppointmentWeekDayView = sender
                Dim folio As String = app.Appointment.Id

                Dim dtConsultaSeleccionada As DataTable = sqlExecute("select tipo_paciente from consultas where folio='" & folio & "'", "sermed")
                If dtConsultaSeleccionada.Rows(0)("tipo_paciente") = 3 Then
                    Dim frm As New frmDetalleExternos
                    frm.folio = folio
                    frm.ShowDialog()
                    frm.Close()
                ElseIf dtConsultaSeleccionada.Rows(0)("tipo_paciente") = 2 Then
                    Dim frm As New frmDetalleConsulta
                    frm.folio = folio
                    frm.ShowDialog()
                    frm.Close()
                ElseIf dtConsultaSeleccionada.Rows(0)("tipo_paciente") = 1 Then
                    Dim frm As New frmDetalleEmp
                    frm.folio = folio
                    frm.ShowDialog()
                    frm.Close()
                End If

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ButtonX4_Click(sender As Object, e As EventArgs) Handles ButtonX4.Click
        Try                        

            Dim folio As String = txtFolio.Text

            Dim dtConsultaSeleccionada As DataTable = sqlExecute("select tipo_paciente from consultas where folio='" & folio & "'", "sermed")
            If dtConsultaSeleccionada.Rows(0)("tipo_paciente") = 3 Then
                Dim frm As New frmDetalleExternos
                frm.folio = folio
                frm.ShowDialog()
                frm.Close()
            ElseIf dtConsultaSeleccionada.Rows(0)("tipo_paciente") = 2 Then
                Dim frm As New frmDetalleConsulta
                frm.folio = folio
                frm.ShowDialog()
                frm.Close()
            ElseIf dtConsultaSeleccionada.Rows(0)("tipo_paciente") = 1 Then
                Dim frm As New frmDetalleEmp
                frm.folio = folio
                frm.ShowDialog()
                frm.Close()
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try
            Dim frm As New frmExternos
            Dim frmAgenda1 As New frmAgregarConsultaEmp
            Dim frmAgenda2 As New frmAgregarConsultaFam
            Dim frmAgenda3 As New frmAgregarConsultaExt

            If CalendarView1.DateSelectionStart Is Nothing Then
                MessageBox.Show("Es necesario seleccionar una fecha para agregar una consulta", "Seleccionar fecha", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

         
            If frm.ShowDialog() = Windows.Forms.DialogResult.OK Then
                MostrarInformacion()
                CargarAppointments()
            End If
            frm.Close()
            'inicio_consulta = CalendarView1.DateSelectionStart
            frmAgenda1.servicio = cmbServicio.SelectedValue
            'frmAgenda2.inicio = dtFecha.Value
            frmAgenda2.servicio = cmbServicio.SelectedValue
            'frmAgenda3.inicio = dtFecha.Value
            frmAgenda3.servicio = cmbServicio.SelectedValue
            'End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
       
    End Sub

    Private Sub dgConsultas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgConsultas.CellDoubleClick
        Dim folio As String = dgConsultas.Rows(e.RowIndex).Cells("columnaFolio").Value
        Dim frm As New frmDetalleConsulta
        frm.folio = folio
        frm.ShowDialog()
    End Sub

    Private Sub dtFechaConsulta_ValueChanged(sender As Object, e As EventArgs) Handles dtFechaConsulta.ValueChanged
        Try
            If txtFolio.Text.Trim <> "" Then
                Dim inicio As Date = dtFechaConsulta.Value.Date.AddTicks(dtHoraConsulta.Value.TimeOfDay.Ticks)
                If Panel5.Enabled Then
                    sqlExecute("update consultas set inicio = '" & FechaHoraSQL(inicio, True) & "' where folio = '" & txtFolio.Text.Trim & "'", "sermed")
                End If

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dtHoraConsulta_ValueChanged(sender As Object, e As EventArgs) Handles dtHoraConsulta.ValueChanged
        Try
            If txtFolio.Text.Trim <> "" Then
                Dim inicio As Date = dtFechaConsulta.Value.Date.AddTicks(dtHoraConsulta.Value.TimeOfDay.Ticks)
                If Panel5.Enabled Then
                    sqlExecute("update consultas set inicio = '" & FechaHoraSQL(inicio, True) & "' where folio = '" & txtFolio.Text.Trim & "'", "sermed")
                End If

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtDuracion_ValueChanged(sender As Object, e As EventArgs) Handles txtDuracion.ValueChanged
        Try
            If txtFolio.Text.Trim <> "" Then
                sqlExecute("update consultas set duracion = '" & txtDuracion.Value & "' where folio = '" & txtFolio.Text.Trim & "'", "sermed")
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub sbFamiliar_ValueChanged(sender As Object, e As EventArgs) Handles sbFamiliar.ValueChanged
        Try
            If txtFolio.Text.Trim <> "" Then
                sqlExecute("update consultas set familiar = '" & IIf(sbFamiliar.Value = True, 1, 0) & "' where folio = '" & txtFolio.Text.Trim & "'", "sermed")
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub sbConcluida_ValueChanged(sender As Object, e As EventArgs) Handles sbConcluida.ValueChanged
        Try
            If txtFolio.Text.Trim <> "" Then
                sqlExecute("update consultas set concluida = '" & IIf(sbConcluida.Value = True, 1, 0) & "' where folio = '" & txtFolio.Text.Trim & "'", "sermed")
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    'Private Sub TimerActualizar_Tick(sender As Object, e As EventArgs) Handles TimerActualizar.Tick
    'Try
    '    Dim folio As String = ""
    '    If txtFolio.Text.Trim <> "" Then
    '        folio = CalendarView1.SelectedAppointments(0).Appointment.Id
    '    End If
    '    MostrarInformacion()
    '    CargarAppointments(folio)
    '    LabelUpdate.Text = "Actualizado: " & FechaHoraSQL(Now, True, False)

    'Catch ex As Exception

    'End Try
    'End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            Dim folio As String = ""
            If txtFolio.Text.Trim <> "" Then
                folio = CalendarView1.SelectedAppointments(0).Appointment.Id
            End If

            MostrarInformacion()
            CargarAppointments()
            LabelUpdate.Text = "Actualizado: " & FechaHoraSQL(Now, True, False)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cmbServicio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbServicio.SelectedValueChanged
        'btnEditar.PerformClick()
        Try
            If CalendarView1.SelectedAppointments.Count <> 0 Then
                Dim folio As String = ""
                If txtFolio.Text.Trim <> "" Then
                    folio = CalendarView1.SelectedAppointments(0).Appointment.Id
                End If
                MostrarInformacion()
                CargarAppointments(folio)
                LabelUpdate.Text = "Actualizado: " & FechaHoraSQL(Now, True, False)
            Else
                CargarAppointments()
                LabelUpdate.Text = "Actualizado: " & FechaHoraSQL(Now, True, False)
            End If

            servicio_consulta = cmbServicio.SelectedValue
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cmbsintoma_Click(sender As Object, e As EventArgs) Handles cmbsintoma.Click
        Try
            If txtFolio.Text.Trim <> "" Then
                sqlExecute("update consultas set sintoma = '" & cmbsintoma.SelectedValue & "' where folio = '" & txtFolio.Text.Trim & "'", "sermed")
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cmbdescripcion_Click(sender As Object, e As EventArgs) Handles cmbdescripcion.SelectedValueChanged
        Try
            If txtFolio.Text.Trim <> "" Then
                EditaConsulta(txtFolio.Text.Trim, "subsintoma", cmbdescripcion.SelectedValue)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub cmbsintoma_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbsintoma.SelectedValueChanged
        Try
            Dim dtdesc As DataTable
            dtdesc = sqlExecute("select * from sintomas where cod_grupo='" & cmbsintoma.SelectedValue & "'", "sermed")
            If dtdesc.Rows.Count Then
                cmbdescripcion.DataSource = dtdesc
            End If
            EditaConsulta(txtFolio.Text.Trim, "sintoma", cmbsintoma.SelectedValue)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If EditarInformacionRapida = False Then
                EditarInformacionRapida = True
            Else
                EditarInformacionRapida = False
            End If
            Panel5.Enabled = EditarInformacionRapida
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If MessageBox.Show("¿Está seguro de borrar la consulta?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim dtBorrar As DataTable
            dtBorrar = sqlExecute("DELETE FROM consultas WHERE folio ='" & txtFolio.Text.Trim & "'", "sermed")
            btnEditar.PerformClick()
        End If
    End Sub

    Private Sub CalendarView1_DateSelectionStartChanged(sender As Object, e As DevComponents.DotNetBar.Schedule.DateSelectionEventArgs) Handles CalendarView1.DateSelectionStartChanged
        Try
            inicio_consulta = CalendarView1.DateSelectionStart
        Catch ex As Exception

        End Try
    End Sub
End Class