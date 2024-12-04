Public Class frmDetallesVisita

    Public visita As visita
    Public Empleado As EmpleadoSermed

    Public t As DevComponents.DotNetBar.SuperTabItem

    Public relojTMP As String = ""

    Public Sub MostrarInformacion()
        Me.txtReloj.Text = visita.reloj

        Me.panelInfo.Controls.Clear()

        If Not visita.concluida Then
            Me.infoEmpleados.Enabled = True
            Me.infoExternos.Enabled = True
            Me.infoVisita.Enabled = True
            btnEditar.Visible = False

            rbExterno.Enabled = True
            rbEmpleado.Enabled = True
            btnSeleccionarEmpleado.Enabled = True
        Else
            Me.infoEmpleados.Enabled = False
            Me.infoExternos.Enabled = False
            Me.infoVisita.Enabled = False
            btnEditar.Visible = True

            rbExterno.Enabled = False
            rbEmpleado.Enabled = False
            btnSeleccionarEmpleado.Enabled = False
        End If

        Me.rbExterno.Checked = Me.visita.externo
        Me.rbEmpleado.Checked = Not Me.visita.externo

        If Me.visita.externo Then
            Me.panelInfo.Controls.Add(infoExternos)
            Me.panelInfo.Controls.Add(infoVisita)
            'Me.panelInfo.Controls.Add(panelAcciones)

            Me.comboSexoExterno.SelectedValue = Me.visita.ext_sexo
            AddHandler comboSexoExterno.SelectedValueChanged, AddressOf comboSexoExterno_SelectedValueChanged

            Me.campoEdadExterno.Text = Me.visita.ext_edad

            Me.campoReloj_famil.Text = Me.visita.reloj_famil

            If visita.nombres <> "" Then
                campoNombreExterno.Visible = False
                labelapaterno.Visible = False
                labelamaterno.Visible = False
                campoApaternoExterno.Visible = False
                campoAmaternoExterno.Visible = False
                campoNombresExterno.Text = visita.nombres
                campoNombresExterno.Visible = True
            Else
                campoNombreExterno.Visible = True
                labelapaterno.Visible = True
                labelamaterno.Visible = True
                campoApaternoExterno.Visible = True
                campoAmaternoExterno.Visible = True
                campoNombresExterno.Visible = False
            End If

        Else

            Me.panelInfo.Controls.Add(infoEmpleados)
            Me.panelInfo.Controls.Add(infoVisita)
            'Me.panelInfo.Controls.Add(panelAcciones)

            If Me.visita.reloj <> "" Then

                Empleado = New EmpleadoSermed(Me.visita.reloj)

                Me.comboSexoEmpleado.SelectedValue = Empleado.sexo

                'Me.campoEdadEmpleado.Text = Integer.Parse(Empleado.edad.TotalDays / 365) & " Años"
                Me.txtNombreEmpleado.Text = Empleado.nombres
                Me.txtSupervisor.Text = Empleado.super
                Me.txtTipoEmp.Text = Empleado.tipo
                Me.txtHorario.Text = Empleado.horario
                Me.txtPuesto.Text = Empleado.puesto
                Me.visita.nombres = Empleado.nombres
                Me.txtReloj.Text = Empleado.reloj
                Me.txtDepto.Text = Empleado.depto
                Me.txtClase.Text = Empleado.clase
                Me.txtTurno.Text = Empleado.turno
                Me.txtAlta.Text = Empleado.alta.ToShortDateString
                Me.txtBaja.Text = Empleado.baja
                If Empleado.baja.Equals("") Then
                    lblEstado.Text = "ACTIVO"
                    lblEstado.BackColor = Color.LimeGreen
                Else
                    lblEstado.Text = "INACTIVO"
                    lblEstado.BackColor = Color.IndianRed
                End If
            End If
        End If

        Me.campoID.Text = Me.visita.cod_visita
        Me.campoResponsable.text = Me.visita.responsabl

        Me.campoFecha.Text = visita.fecha.ToShortDateString
        Me.campoHora_entro.Text = Me.visita.hora_entro.ToShortTimeString

        Me.comboDuracion.SelectedValue = Me.visita.minutos
        AddHandler comboDuracion.SelectedValueChanged, AddressOf comboDuracion_SelectedValueChanged

        If visita.concluida Then
            Me.campoHora_salio.Text = Me.visita.hora_salio.ToShortTimeString
        End If

        Me.comboDuracion.Text = Me.visita.tiempo
        Me.campoComentario.Text = Me.visita.comentario
        Me.campoMedicamento.Text = Me.visita.medicamento

        Me.comboPato.SelectedValue = Me.visita.cod_pato1
        Me.comboPato2.SelectedValue = Me.visita.cod_pato2
        Me.comboPato3.SelectedValue = Me.visita.cod_pato3

        AddHandler comboPato.SelectedValueChanged, AddressOf comboPato1_SelectedValueChanged
        AddHandler comboPato2.SelectedValueChanged, AddressOf comboPato2_SelectedValueChanged
        AddHandler comboPato3.SelectedValueChanged, AddressOf comboPato3_SelectedValueChanged

        Me.cbAccTrab.Checked = Me.visita.acc_traba
        Me.cbAccTray.Checked = Me.visita.acc_tray
        Me.cbInyeccion.Checked = Me.visita.inyeccion
        Me.cbCuracion.Checked = Me.visita.curacion
        Me.cbPlanFam.Checked = Me.visita.plan_fam

        Me.campoEmpresa.Text = Me.visita.empresa
        Me.campoReloj_famil.Text = Me.visita.reloj_famil

    End Sub


    Private Sub detallesVisita_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' ---------------------------------------------------

        comboSexoEmpleado.DataSource = sqlExecute("select sexo as 'id', nombres as 'descripcion' from sexo")
        comboSexoEmpleado.DisplayMember = "descripcion"
        comboSexoEmpleado.ValueMember = "id"

        comboSexoExterno.DataSource = sqlExecute("select sexo as 'id', nombres as 'descripcion' from sexo")
        comboSexoExterno.DisplayMember = "descripcion"
        comboSexoExterno.ValueMember = "id"

        comboPato.DataSource = sqlExecute("select codigo as 'id', descripcion as 'descripcion' from patologia order by codigo asc", "SERMED")
        comboPato.DisplayMember = "descripcion"
        comboPato.ValueMember = "id"

        comboPato2.DataSource = sqlExecute("select codigo as 'id', descripcion as 'descripcion' from patologia order by codigo asc", "SERMED")
        comboPato2.DisplayMember = "descripcion"
        comboPato2.ValueMember = "id"

        comboPato3.DataSource = sqlExecute("select codigo as 'id', descripcion as 'descripcion' from patologia order by codigo asc", "SERMED")
        comboPato3.DisplayMember = "descripcion"
        comboPato3.ValueMember = "id"

        comboDuracion.DataSource = sqlExecute("select duracion as 'id', descripcion as 'descripcion' from duraciones order by duracion asc", "SERMED")
        comboDuracion.DisplayMember = "descripcion"
        comboDuracion.ValueMember = "id"

        '' ---------------------------------------------------        
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
        Me.panelInfo.Controls.Clear()
        If rbExterno.Checked Then
            Me.panelInfo.Controls.Add(infoExternos)
            Me.panelInfo.Controls.Add(infoVisita)
            ' Me.panelInfo.Controls.Add(panelAcciones)
        ElseIf rbEmpleado.Checked Then
            Me.panelInfo.Controls.Add(infoEmpleados)
            Me.panelInfo.Controls.Add(infoVisita)
            ' Me.panelInfo.Controls.Add(panelAcciones)
        End If
    End Sub

    Private Sub campoNombreExterno_TextChanged(sender As Object, e As EventArgs) Handles campoNombreExterno.TextChanged
        visita.nombres = campoApaternoExterno.Text.ToUpper + "," + campoAmaternoExterno.Text.ToUpper + "," + campoNombreExterno.Text.ToUpper
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles rbEmpleado.CheckedChanged, rbExterno.CheckedChanged
        Me.panelInfo.Controls.Clear()

        If rbExterno.Checked Then
            relojTMP = visita.reloj
            visita.externo = True
            visita.reloj = "Exter"
            btnSeleccionarEmpleado.Visible = False
            Me.panelInfo.Controls.Add(infoExternos)
            Me.panelInfo.Controls.Add(infoVisita)
            ' Me.panelInfo.Controls.Add(panelAcciones)
        ElseIf rbEmpleado.Checked Then
            btnSeleccionarEmpleado.Visible = True
            visita.externo = False
            If relojTMP <> "" Then
                visita.reloj = relojTMP
            End If

            Me.panelInfo.Controls.Add(infoEmpleados)
            Me.panelInfo.Controls.Add(infoVisita)
            'Me.panelInfo.Controls.Add(panelAcciones)
        End If
    End Sub

    Private Sub campoEdadExterno_TextChanged(sender As Object, e As EventArgs) Handles campoEdadExterno.TextChanged
        Try
            Me.visita.ext_edad = Integer.Parse(campoEdadExterno.Text).ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub campoEmpresa_TextChanged(sender As Object, e As EventArgs) Handles campoEmpresa.TextChanged
        Me.visita.empresa = campoEmpresa.Text
    End Sub

    Private Sub comboSexoExterno_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            Me.visita.ext_sexo = comboSexoExterno.SelectedValue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub campoAmaternoExterno_TextChanged(sender As Object, e As EventArgs) Handles campoAmaternoExterno.TextChanged
        visita.nombres = campoApaternoExterno.Text.ToUpper + "," + campoAmaternoExterno.Text.ToUpper + "," + campoNombreExterno.Text.ToUpper
    End Sub

    Private Sub campoApaternoExterno_TextChanged(sender As Object, e As EventArgs) Handles campoApaternoExterno.TextChanged
        visita.nombres = campoApaternoExterno.Text.ToUpper + "," + campoAmaternoExterno.Text.ToUpper + "," + campoNombreExterno.Text.ToUpper
    End Sub

    Private Sub campoComentario_TextChanged(sender As Object, e As EventArgs) Handles campoComentario.TextChanged
        Me.visita.comentario = campoComentario.Text.ToUpper
    End Sub

    Private Sub campoMedicamento_TextChanged(sender As Object, e As EventArgs) Handles campoMedicamento.TextChanged
        Me.visita.medicamento = campoMedicamento.Text.ToUpper
    End Sub

    Private Sub campoFecha_TextChanged(sender As Object, e As EventArgs) Handles campoFecha.TextChanged
        Me.visita.fecha = campoFecha.Text
    End Sub

    Private Sub campoHora_entro_TextChanged(sender As Object, e As EventArgs) Handles campoHora_entro.TextChanged
        Me.visita.hora_entro = campoHora_entro.Text
    End Sub

    Private Sub comboPato1_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            visita.cod_pato1 = comboPato.SelectedValue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub comboPato2_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            visita.cod_pato2 = comboPato2.SelectedValue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub comboPato3_SelectedValueChanged(sender As Object, e As EventArgs)
        Try
            visita.cod_pato3 = comboPato3.SelectedValue
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbAccTray_CheckedChanged(sender As Object, e As EventArgs) Handles cbAccTray.CheckedChanged
        Me.visita.acc_tray = cbAccTray.Checked
    End Sub

    Private Sub cbAccTrab_CheckedChanged(sender As Object, e As EventArgs) Handles cbAccTrab.CheckedChanged
        Me.visita.acc_traba = cbAccTrab.Checked
    End Sub

    Private Sub cbInyeccion_CheckedChanged(sender As Object, e As EventArgs) Handles cbInyeccion.CheckedChanged
        Me.visita.inyeccion = cbInyeccion.Checked
        campoIyec_det.Enabled = visita.inyeccion
        If Not visita.inyeccion Then
            campoIyec_det.Text = ""
        End If
    End Sub

    Private Sub cbCuracion_CheckedChanged(sender As Object, e As EventArgs) Handles cbCuracion.CheckedChanged
        Me.visita.curacion = cbCuracion.Checked
        campoCuracion_det.Enabled = visita.curacion
        If Not visita.curacion Then
            campoCuracion_det.Text = ""
        End If
    End Sub

    Private Sub campoIyec_det_TextChanged(sender As Object, e As EventArgs) Handles campoIyec_det.TextChanged
        Me.visita.inyec_det = campoIyec_det.Text.ToUpper
    End Sub

    Private Sub campoCuracion_det_TextChanged(sender As Object, e As EventArgs) Handles campoCuracion_det.TextChanged
        Me.visita.cura_det = campoCuracion_det.Text.ToUpper
    End Sub

    Private Sub comboDuracion_SelectedValueChanged(sender As Object, e As EventArgs) ' Handles comboDuracion.SelectedIndexChanged
        Me.visita.tiempo = comboDuracion.Text.Split(" ")(0)
        Me.visita.minutos = comboDuracion.SelectedValue
        Dim tmp As New DateTime
        tmp = visita.hora_entro.AddMinutes(visita.minutos)
        campoHora_salio.Text = tmp.ToShortTimeString
    End Sub

    Private Sub CheckBox1_CheckedChanged_1(sender As Object, e As EventArgs) Handles cbConsulta.CheckedChanged
        Me.visita.consulta = cbConsulta.Checked
    End Sub


    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles btnSeleccionarEmpleado.Click
        Try
            frmBusca.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                Me.visita.reloj = Reloj

                Empleado = New EmpleadoSermed(Me.visita.reloj)

                Me.comboSexoEmpleado.SelectedValue = Empleado.sexo
                ' Me.campoEdadEmpleado.Text = Integer.Parse(Empleado.edad.TotalDays / 365) & " Años"
                Me.txtNombreEmpleado.Text = Empleado.nombres
                Me.txtSupervisor.Text = Empleado.super
                Me.txtTipoEmp.Text = Empleado.tipo
                Me.txtHorario.Text = Empleado.horario
                Me.txtPuesto.Text = Empleado.puesto
                Me.visita.nombres = Empleado.nombres
                Me.txtReloj.Text = Empleado.reloj
                Me.txtDepto.Text = Empleado.depto
                Me.txtClase.Text = Empleado.clase
                Me.txtTurno.Text = Empleado.turno
                Me.txtAlta.Text = Empleado.alta.ToShortDateString
                Me.txtBaja.Text = Empleado.baja
                If Empleado.baja.Equals("") Then
                    lblEstado.Text = "ACTIVO"
                    lblEstado.BackColor = Color.LimeGreen
                Else
                    lblEstado.Text = "INACTIVO"
                    lblEstado.BackColor = Color.IndianRed
                End If

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, Err.Number, ex.Message)
        End Try

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            frmBusca.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                Me.campoReloj_famil.Text = Reloj
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, Err.Number, ex.Message)
        End Try
    End Sub

    Private Sub campoReloj_famil_TextChanged(sender As Object, e As EventArgs) Handles campoReloj_famil.TextChanged
        Me.visita.reloj_famil = campoReloj_famil.Text
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        visita.concluida = False
        Me.MostrarInformacion()
    End Sub

    Private Sub campoNombresExterno_TextChanged(sender As Object, e As EventArgs) Handles campoNombresExterno.TextChanged
        Me.visita.nombres = campoNombresExterno.Text.ToUpper
    End Sub

    Private Sub campoEdadExterno_Click(sender As Object, e As EventArgs) Handles campoEdadExterno.Click
        campoEdadExterno.SelectAll()
    End Sub

    Private Sub comboDuracion_KeyDown(sender As Object, e As KeyEventArgs) Handles comboDuracion.KeyDown
        e.SuppressKeyPress = True
    End Sub

    Private Sub btnCambios_Click(sender As Object, e As EventArgs) Handles btnCambios.Click

    End Sub
End Class





