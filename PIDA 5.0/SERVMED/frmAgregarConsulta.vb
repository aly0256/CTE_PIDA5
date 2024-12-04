Public Class frmAgregarConsulta
    Dim dtPersonal As DataTable
    Public reloj As String = ""
    Public cia As String = ""
    Public fam As String = ""
    Public servicio As String = ""
    Public editar As Boolean = False

    Public inicio As String = Now
    Dim dtdescripcion As DataTable
    Dim dtsintoma As DataTable

    Private Sub Agendar()
        Try
            Dim inicio As Date = dtFecha.Value.Date.AddTicks(dtHora.Value.TimeOfDay.Ticks)
            Dim cod_servicio As String = comboServicios.SelectedValue
            Dim familiar As Integer = IIf(sbConsultaFamiliar.Value = True, 1, 0)

            Dim folio As Integer
            folio = 10000000

            Dim dtfolio As DataTable = sqlExecute("select top 1 folio from consultas order by folio desc", "sermed")
            If dtfolio.Rows.Count > 0 Then
                folio = dtfolio.Rows(0)("folio") + 1
            End If
            If reloj <> "" Then
                sqlExecute("insert into consultas (folio, reloj, inicio, duracion, cod_servicio, usuario_captura, captura, concluida,sintoma,subsintoma,comentario) values ('" & folio & "', '" & Me.reloj & "', '" & FechaHoraSQL(inicio, True) & "', '" & txtDuracion.Value & "','" & comboServicios.SelectedValue & "', '" & Usuario & "', '" & FechaHoraSQL(Now, True) & "', '0','" & cmbsintoma.SelectedValue & "','" & cmbdescripcion.SelectedValue & "','" & txtComentario.Text.Replace("'", "''") & "')", "sermed")
                EditaConsulta(folio, "familiar", IIf(sbConsultaFamiliar.Value = True, 1, 0))
                EditaConsulta(folio, "familiar_registrado", IIf(sbConsultaFamiliar.Value = True, IIf(sbFamiliarRegistrado.Value = True, 1, 0), 0))
                EditaConsulta(folio, "id_familiar", IIf(sbConsultaFamiliar.Value = True, comboFamiliaresRegistrados.SelectedValue, 0))
                If sbConsultaFamiliar.Value = True Then
                    Dim dtNombre As DataTable = sqlExecute("select nombre from familiares where idfld = '" & comboFamiliaresRegistrados.SelectedValue & "'")
                    If dtNombre.Rows.Count > 0 Then
                        EditaConsulta(folio, "nombre_paciente", dtNombre.Rows(0)("nombre").ToString.Trim)
                    End If
                Else
                    EditaConsulta(folio, "nombre_paciente", txtNombre.Text)
                End If
                'EditaConsulta(folio, "nombre_paciente", IIf(sbConsultaFamiliar.Value = True, IIf(sbFamiliarRegistrado.Value = True, comboFamiliaresRegistrados.Text, txtNombreFamiliarNoRegistrado.Text), txtNombre.Text))
            End If
            Me.DialogResult = Windows.Forms.DialogResult.OK
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            Dim opcion As DialogResult
            Dim dtMayores As DataTable = sqlExecute("SELECT * FROM familiares where idfld = '" & comboFamiliaresRegistrados.SelectedValue & "' and (cod_familia=08 or cod_familia=07) and substring(cast(fecha_nac as VARCHAR),1,4)<='1999' order by fecha_nac asc")
            If sbConsultaFamiliar.Value = False Or dtMayores.Rows.Count = 0 Then Agendar()
            If sbConsultaFamiliar.Value = True And dtMayores.Rows.Count > 0 Then
                opcion = MessageBox.Show("Consultas a familiares hijos mayores de 16 años no están permitidas," & vbCrLf & " ¿Desea continuar?", "Familiares", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If opcion = System.Windows.Forms.DialogResult.No Then
                    btnCancelar.PerformClick()
                Else
                    Agendar()
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub frmAgregarConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            comboServicios.DataSource = sqlExecute("select  cod_servicio, nombre,encargado from servicios", "sermed")
            comboServicios.ValueMember = "cod_servicio"
            comboServicios.SelectedValue = servicio

            dtFecha.Value = inicio
            dtHora.Value = inicio

            If reloj <> "" Then
                dtPersonal = ConsultaPersonalVW("select  * from personalvw where reloj = '" & reloj & "'", False)
                btnBuscar.Visible = False
                MostrarInformacion()
            End If

            dtdescripcion = sqlExecute("select * from sintomas", "sermed")
            dtdescripcion.DefaultView.Sort = "cod_sintoma"
            cmbdescripcion.DataSource = dtdescripcion
            cmbdescripcion.SelectedIndex = -1

            dtsintoma = sqlExecute("select * from grupos_sintomas", "sermed")
            dtsintoma.DefaultView.Sort = "cod_grupo"
            cmbsintoma.DataSource = dtsintoma
            cmbsintoma.SelectedIndex = -1
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub MostrarInformacion()
        Try
            If dtPersonal.Rows.Count > 0 Then
                Dim drPersonal As DataRow = dtPersonal.Rows(0)

                reloj = IIf(IsDBNull(drPersonal("reloj")), "", drPersonal("reloj"))

                Try
                    txtReloj.Text = IIf(IsDBNull(drPersonal("reloj")), "", drPersonal("reloj"))
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
                    cia = IIf(IsDBNull(drPersonal("cod_comp")), "", drPersonal("cod_comp"))
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
                    
                    Dim dtFam As DataTable
                    dtFam = sqlExecute("select * from familiares where reloj='" & reloj & "'")
                    If dtFam.Rows.Count = 0 Then
                        Label20.Visible = False
                        sbConsultaFamiliar.Visible = False
                    Else
                        Label20.Visible = True
                        sbConsultaFamiliar.Visible = True
                    End If


                    If System.IO.File.Exists(IIf(IsDBNull(drPersonal("foto")), "", drPersonal("foto"))) Then
                        picFoto.ImageLocation = drPersonal("foto")
                    Else
                        picFoto.Image = My.Resources.NoFoto
                    End If

                    'comboFamiliaresRegistrados.DataSource = sqlExecute("select familiares.cod_familia, familia.nombre as 'parentesco', familiares.nombre from familiares left join familia on familia.cod_familia = familiares.cod_familia where reloj = '" & txtReloj.Text & "'")

                    comboFamiliaresRegistrados.DataSource = sqlExecute("select familiares.idfld as 'ID', familia.cod_familia as 'Código',familia.nombre as 'Parentesco',RTrim(familiares.nombre) as 'Nombre' from familiares left join familia on familiares.cod_familia=familia.cod_familia where reloj = '" & txtReloj.Text & "'")
                    comboFamiliaresRegistrados.ValueMember = "ID"

                Catch ex As Exception

                End Try


            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            frmBuscar.ShowDialog()
            dtpersonal = ConsultaPersonalVW("select  * from personalvw where reloj = '" & Declaraciones.Reloj & "'", False)
            If dtPersonal.Rows.Count > 0 Then
                MostrarInformacion()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub sbConsultaFamiliar_ValueChanged(sender As Object, e As EventArgs) Handles sbConsultaFamiliar.ValueChanged
        Try
            panelFamiliar.Visible = sbConsultaFamiliar.Value
            comboFamiliaresRegistrados.SelectedIndex = 0
            sbFamiliarRegistrado.Value = sbConsultaFamiliar.Value
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub sbFamiliarRegistrado_ValueChanged(sender As Object, e As EventArgs) Handles sbFamiliarRegistrado.ValueChanged
        Try
            'btnAgregarFam.Visible = Not sbFamiliarRegistrado.Value
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
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub btnAgregarFam_Click(sender As Object, e As EventArgs)
        Try
            frmAgregarFamiliar.reloj = reloj
            frmAgregarFamiliar.cia = cia
            frmAgregarFamiliar.editar = False
            frmAgregarFamiliar.ShowDialog()
            Dim dtFam As DataTable = sqlExecute("select familiares.idfld as 'ID', familia.cod_familia as 'Código',familia.nombre as 'Parentesco',RTrim(familiares.nombre) as 'Nombre' from familiares left join familia on familiares.cod_familia=familia.cod_familia where reloj = '" & txtReloj.Text & "'")
            comboFamiliaresRegistrados.DataSource = dtFam
            comboFamiliaresRegistrados.ValueMember = "ID"
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try


    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click

    End Sub

    Private Sub comboFamiliaresRegistrados_SelectedValueChanged(sender As Object, e As EventArgs) Handles comboFamiliaresRegistrados.SelectedValueChanged
        sbFamiliarRegistrado.Value = True
    End Sub

    Private Sub lblBaja_Click(sender As Object, e As EventArgs) Handles lblBaja.Click

    End Sub
End Class