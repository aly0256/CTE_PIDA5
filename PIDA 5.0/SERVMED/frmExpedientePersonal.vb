Public Class frmExpedientePersonal
    Dim dtPersonal As DataTable
    Dim dtConsultas As DataTable
    Dim reloj As String


    Private Sub frmExpedientePersonal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            dgConsultas.AutoGenerateColumns = False
            btnFirst.PerformClick()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MostrarInformacion()
        Try
            If dtPersonal.Rows.Count > 0 Then
                Dim drPersonal As DataRow = dtPersonal.Rows(0)

                reloj = IIf(IsDBNull(drPersonal("reloj")), "", drPersonal("reloj"))

                Try
                    txtReloj.Text = IIf(IsDBNull(drPersonal("reloj")), "", drPersonal("reloj"))
                    txtNombre.Text = IIf(IsDBNull(drPersonal("nombres")), "", drPersonal("nombres"))
                    txtCia.Text = IIf(IsDBNull(drPersonal("cod_comp")), "", drPersonal("cod_comp")) & " (" & IIf(IsDBNull(drPersonal("compania")), "", RTrim(drPersonal("compania"))) & ")"
                    txtTipoEmp.Text = IIf(IsDBNull(drPersonal("cod_tipo")), "", drPersonal("cod_tipo")) & " (" & IIf(IsDBNull(drPersonal("nombre_tipoemp")), "", RTrim(drPersonal("nombre_tipoemp"))) & ")"

                    txtDepto.Text = IIf(IsDBNull(drPersonal("cod_depto")), "", drPersonal("cod_depto")) & " (" & IIf(IsDBNull(drPersonal("nombre_depto")), "", drPersonal("nombre_depto")) & ")"
                    'txtSupervisor.Text = IIf(IsDBNull(drPersonal("cod_super")), "", drPersonal("cod_super")) & " (" & IIf(IsDBNull(drPersonal("nombre_super")), "", drPersonal("nombre_super")) & ")"
                    txtTurno.Text = IIf(IsDBNull(drPersonal("cod_hora")), "", drPersonal("cod_hora")) & " (" & IIf(IsDBNull(drPersonal("nombre_horario")), "", drPersonal("nombre_horario")) & ")"
                    'txtHorario.Text = IIf(IsDBNull(drPersonal("cod_hora")), "", drPersonal("cod_hora")) & " (" & IIf(IsDBNull(drPersonal("nombre_horario")), "", drPersonal("nombre_horario")) & ")"

                    txtNombre.Text = drPersonal("nombres")
                    txtCia.Text = IIf(IsDBNull(drPersonal("cod_comp")), "N/A", drPersonal("cod_comp")) & "(" & RTrim(IIf(IsDBNull(drPersonal("compania")), "N/A", drPersonal("compania"))) & ")"
                    txtSuper.Text = IIf(IsDBNull(drPersonal("cod_super")), "N/A", drPersonal("cod_super")) & "(" & RTrim(IIf(IsDBNull(drPersonal("nombre_super")), "N/A", drPersonal("nombre_super"))) & ")"
                    txtTurno.Text = IIf(IsDBNull(drPersonal("cod_hora")), "N/A", drPersonal("cod_hora")) & "(" & RTrim(IIf(IsDBNull(drPersonal("nombre_horario")), "N/A", drPersonal("nombre_horario"))) & ")"
                    txtPuesto.Text = IIf(IsDBNull(drPersonal("cod_puesto")), "N/A", drPersonal("cod_puesto")) & "(" & RTrim(IIf(IsDBNull(drPersonal("nombre_puesto")), "N/A", drPersonal("nombre_puesto"))) & ")"
                    txtDepto.Text = IIf(IsDBNull(drPersonal("cod_depto")), "N/A", drPersonal("cod_depto")) & "(" & RTrim(IIf(IsDBNull(drPersonal("nombre_depto")), "N/A", drPersonal("nombre_depto"))) & ")"
                    txtTipoEmp.Text = IIf(IsDBNull(drPersonal("cod_tipo")), "N/A", drPersonal("cod_tipo")) & "(" & RTrim(IIf(IsDBNull(drPersonal("nombre_tipoEmp")), "N/A", drPersonal("nombre_tipoEmp"))) & ")"
                    txtAlta.Value = drPersonal("alta")
                    txtImss.Text = IIf(IsDBNull(drPersonal("imss")), "N/A", drPersonal("imss")) & " - " & RTrim(IIf(IsDBNull(drPersonal("dig_ver")), "N/A", drPersonal("dig_ver")))
                    txtPlanta.Text = IIf(IsDBNull(drPersonal("cod_planta")), "N/A", drPersonal("cod_planta")) & "(" & RTrim(IIf(IsDBNull(drPersonal("nombre_planta")), "N/A", drPersonal("nombre_planta"))) & ")"
                    txtDireccion.Text = IIf(IsDBNull(drPersonal("d_completa")), "N/A", drPersonal("d_completa"))
                    txtEmergencia.Text = IIf(IsDBNull(drPersonal("aviso_acc")), "N/A", drPersonal("aviso_acc"))
                    If (IsDBNull(drPersonal("baja"))) Then

                        lblEstado.Text = "ACTIVO"
                        lblEstado.BackColor = Color.LimeGreen
                        txtBaja.Visible = False
                        lblBaja.Visible = False

                    Else

                        txtBaja.Value = drPersonal("baja")
                        lblEstado.BackColor = Color.IndianRed
                        txtBaja.Visible = True
                        lblBaja.Visible = True
                        lblEstado.Text = "INACTIVO"

                    End If

                    If System.IO.File.Exists(IIf(IsDBNull(drPersonal("foto")), "", drPersonal("foto"))) Then
                        picFoto.ImageLocation = drPersonal("foto")
                    Else
                        picFoto.Image = My.Resources.NoFoto
                    End If
                Catch ex As Exception

                End Try

                MostrarInformacionConsultas()
                MostrarInformacionIncapacidades()

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MostrarInformacionIncapacidades()
        Dim dtIncapacidades As DataTable = sqlExecute("select  min(ta.dbo.ausentismo.fecha) as fecha_inicio, ta.dbo.ausentismo.tipo_aus, ta.dbo.tipo_ausentismo.nombre, ta.dbo.ausentismo.referencia, count(ta.dbo.ausentismo.fecha) as dias from ta.dbo.ausentismo left join ta.dbo.tipo_ausentismo on ta.dbo.tipo_ausentismo.tipo_aus = ta.dbo.ausentismo.tipo_aus where ta.dbo.ausentismo.tipo_aus in (select tipo_aus from ta.dbo.tipo_ausentismo where ta.dbo.tipo_ausentismo.tipo_naturaleza = 'I') and ta.dbo.ausentismo.reloj = '" & reloj & "' group by ta.dbo.ausentismo.reloj, ta.dbo.ausentismo.tipo_aus, ta.dbo.ausentismo.referencia, ta.dbo.tipo_ausentismo.nombre  ", "ta")
        dgIncapacidades.DataSource = dtIncapacidades
    End Sub

    Private Sub CargarAnosKardex()
        Try
            Dim dtAnos As DataTable = sqlExecute("select datepart(year, alta) as ano from personal where reloj = '" & Ano & "'")
            If dtAnos.Rows.Count > 0 Then
                Dim ano_inicio As Integer = dtAnos.Rows(0)("ano")
                While ano_inicio <= DatePart(DateInterval.Year, Now)
                    cmbAno.Items.Add(ano_inicio)
                    ano_inicio += 1
                End While

                cmbAno.SelectedItem = DatePart(DateInterval.Year, Now)

            Else

            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub MostrarInformacionKardex()
        Try
            Dim dtKardex As New DataTable
            dtKardex.Columns.Add("MES", Type.GetType("System.String"))
            For i As Integer = 1 To 31
                Dim colDia As New DataColumn("DIA" & i, Type.GetType("System.String"))               
                dtKardex.Columns.Add(colDia)
            Next

            Dim dtCalendario As DataTable = sqlExecute("select datepart(month, fecha), datepart(day, fecha), tipo_aus from TA.dbo.ausentismo where datepart(year, fecha) = '" & cmbAno.SelectedItem & "' and ta.dbo.ausentismo.reloj = '" & reloj & "'", "TA")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub MostrarInformacionConsultas()
        Try
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
               "convert(date, sermed.dbo.consultas.inicio) as fecha, " & _
               "convert(time, sermed.dbo.consultas.inicio) as hora, " & _
               "sermed.dbo.consultas.duracion, " & _
               "sermed.dbo.consultas.familiar, " & _
               "sermed.dbo.consultas.comentario, " & _
               "sermed.dbo.consultas.tratamiento, " & _
               "sermed.dbo.consultas.indicaciones, " & _
               "sermed.dbo.consultas.nota_medica, " & _
               "sermed.dbo.consultas.nombre_paciente, " & _
               "sermed.dbo.consultas.concluida " & _
               "from consultas " & _
               "left join personal.dbo.personalvw on personal.dbo.personalvw.reloj = sermed.dbo.consultas.reloj " & _
               "where sermed.dbo.consultas.reloj = '" & reloj & "' order by fecha desc, hora desc"



            dtConsultas = sqlExecute(consulta, "sermed")




            dgConsultas.DataSource = dtConsultas
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        Try
            dtPersonal = ConsultaPersonalVW("select top 1 * from personalvw order by reloj asc", False)
            If dtPersonal.Rows.Count > 0 Then
                MostrarInformacion()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Try
            dtPersonal = ConsultaPersonalVW("select top 1 * from personalvw where reloj < '" & reloj & "' order by reloj desc", False)
            If dtPersonal.Rows.Count > 0 Then
                MostrarInformacion()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try
            dtPersonal = ConsultaPersonalVW("select top 1 * from personalvw where reloj > '" & reloj & "' order by reloj asc", False)
            If dtPersonal.Rows.Count > 0 Then
                MostrarInformacion()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        Try
            dtPersonal = ConsultaPersonalVW("select top 1 * from personalvw order by reloj desc", False)
            If dtPersonal.Rows.Count > 0 Then
                MostrarInformacion()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            frmBuscar.ShowDialog()
            dtPersonal = ConsultaPersonalVW("select  * from personalvw where reloj = '" & Declaraciones.Reloj & "'", False)
            If dtPersonal.Rows.Count > 0 Then
                MostrarInformacion()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try
            Dim frm As New frmRangoFechas
            frm.ShowDialog()

            Dim consulta As String =
                   "select * from consultasvw where reloj = '" & txtReloj.Text & "' and fecha between '" & FechaSQL(FechaInicial) & "' and '" & FechaSQL(FechaFinal) & "' order by fecha desc, hora desc"

            dtConsultas = sqlExecute(consulta, "sermed")

            frmVistaPrevia.LlamarReporte("Expediente personal", dtConsultas)
            frmVistaPrevia.ShowDialog()
        Catch ex As Exception

        End Try


    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        If SuperTabControl1.SelectedTab.Equals(tabConsultas) Then
            Dim frm As New frmAgregarConsultaFam
            frm.reloj = reloj
            frm.ShowDialog()
            MostrarInformacionConsultas()
        ElseIf SuperTabControl1.SelectedTab.Equals(tabIncapacidades) Then
            Dim frm As New frmCapturaDeIncapacidades
            frm.ShowDialog()
            MostrarInformacionIncapacidades()
        End If

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click

    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgDatos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgConsultas.CellDoubleClick
        Try
            Dim folio As String = dgConsultas.Rows(e.RowIndex).Cells("columnaFolio").Value
            Dim frm As New frmDetalleConsulta
            frm.folio = folio
            frm.ShowDialog()
            MostrarInformacionConsultas()
        Catch ex As Exception

        End Try
    End Sub
End Class