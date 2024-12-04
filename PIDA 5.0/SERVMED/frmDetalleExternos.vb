Public Class frmDetalleExternos
    Public reloj As String = ""
    Public folio As String = ""
    Public cod_familiar As String = ""
    Public editar As Boolean = True
    Dim dtdescripcion As DataTable
    Dim dtsintoma As DataTable
    Dim dtEditarNota As DataTable
    Dim dtFamiliares As DataTable


    Private Sub ButtonX3_Click(sender As Object, e As EventArgs)
        'Try
        '    If panelInfoConsulta.Visible = True Then
        '        panelInfoConsulta.Visible = False
        '        btnInfoConsulta.Image = My.Resources.toggle_expand
        '    Else
        '        panelInfoConsulta.Visible = True
        '        btnInfoConsulta.Image = My.Resources.toggle
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub btnInfoPaciente_Click(sender As Object, e As EventArgs) Handles btnInfoPaciente.Click
        Try
            If panelInfoPaciente.Visible = True Then
                panelInfoPaciente.Visible = False
                btnInfoPaciente.Image = My.Resources.toggle_expand
            Else
                panelInfoPaciente.Visible = True
                btnInfoPaciente.Image = My.Resources.toggle
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub frmDetalleConsulta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            comboServicios.DataSource = sqlExecute("select  cod_servicio, nombre from servicios", "sermed")
            comboServicios.ValueMember = "cod_servicio"


            dgConsultas.AutoGenerateColumns = False

            Dim dtNotaMedica As DataTable = sqlExecute("SELECT acceso FROM permisos WHERE tipo = 'T' AND control = 'tabNotaMedica' AND cod_perfil " & Perfil, "Seguridad")
            If dtNotaMedica.Rows(0)("acceso") = 0 Then
                tabNotaMedica.Visible = False
            End If

            dtdescripcion = sqlExecute("select * from sintomas", "sermed")
            dtdescripcion.DefaultView.Sort = "cod_sintoma"
            cmbDescripcion.DisplayMembers = "cod_sintoma,nombre"
            cmbDescripcion.DataSource = dtdescripcion

            dtsintoma = sqlExecute("select * from grupos_sintomas", "sermed")
            dtsintoma.DefaultView.Sort = "cod_grupo"
            cmbSintoma.DisplayMembers = "cod_grupo,nombre"
            cmbSintoma.DataSource = dtsintoma

            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub MostrarInformacion()


        Dim dtConsultas As DataTable
        'Panel4.Enabled = False
        Dim Editando As Boolean
        Try
            Dim dtConsulta As DataTable = sqlExecute("select consultas.*,grupos_sintomas.cod_grupo as sintoma1 ,sintomas.cod_sintoma as subsintoma1 from consultas left join grupos_sintomas on consultas.sintoma=grupos_sintomas.cod_grupo left join sintomas on consultas.subsintoma=sintomas.cod_sintoma where folio =  '" & folio & "'", "sermed")
            If dtConsulta.Rows.Count > 0 Then



                If Not IsDBNull(dtConsulta.Rows(0)("usuario")) Then
                    If RTrim(dtConsulta.Rows(0)("usuario")) = Usuario Then
                        Label39.Visible = False
                        Editando = False
                    Else
                        Label39.Text = "Editando por " & dtConsulta.Rows(0)("usuario")
                        Editando = True
                    End If
                Else
                    sqlExecute("update sermed.dbo.consultas set usuario='" & Usuario & "' where folio='" & folio & "'")
                    Label39.Visible = False
                    Editando = False
                End If


                txtReloj.Text = dtConsulta.Rows(0)("reloj")


                Dim dtEmpleado As DataTable = sqlExecute("select externos.*,cias_externas.nombre as 'nombre_cia' from externos left join cias_externas on cias_externas.cia=externos.compania where externos.id = '" & txtReloj.Text & "'", "sermed")
                Dim fecha_emp, fecha_fam As Date

                RemoveHandler sbConcluida.ValueChanged, AddressOf sbConcluida_ValueChanged

                sbConcluida.Value = IIf(IsDBNull(dtConsulta.Rows(0)("concluida")), False, dtConsulta.Rows(0)("concluida"))
                sbConcluida.Visible = Not sbConcluida.Value And Not Editando

                panelInfoPaciente.Enabled = Not sbConcluida.Value And Not Editando
                Panel5.Enabled = Not sbConcluida.Value And Not Editando
                Panel12.Enabled = Not sbConcluida.Value And Not Editando
                Panel4.Enabled = Not sbConcluida.Value And Not Editando

                AddHandler sbConcluida.ValueChanged, AddressOf sbConcluida_ValueChanged

                'Sólo el doctor que atendió la consulta puede ver el switch de concluida
                Dim dtAccesoNota As DataTable = sqlExecute("select * from servicios where username='" & Usuario & "'", "sermed")
                If dtAccesoNota.Rows.Count > 0 Then
                    Dim servicio As String
                    servicio = IIf(IsDBNull(dtAccesoNota.Rows(0)("cod_servicio")), "", dtAccesoNota.Rows(0)("cod_servicio"))
                    If (comboServicios.SelectedValue = servicio) Or IsDBNull(dtAccesoNota.Rows(0)("username")) Then
                        sbConcluida.Visible = True
                        Label8.Visible = True
                    Else
                        sbConcluida.Visible = False
                        Label8.Visible = False
                    End If
                Else
                    sbConcluida.Visible = False
                    Label8.Visible = False
                End If
                '
                If dtEmpleado.Rows.Count > 0 Then
                    Try
                        Dim valor As Boolean
                        'valor = dtConsulta.Rows(0)("familiar")
                        txtReloj.Text = dtEmpleado.Rows(0)("ID")
                        txtNombre.Text = RTrim(dtEmpleado.Rows(0)("nombre")) & " " & RTrim(dtEmpleado.Rows(0)("apaterno")) & " " & IIf(IsDBNull(dtEmpleado.Rows(0)("amaterno")), " ", RTrim(dtEmpleado.Rows(0)("amaterno")))
                        txtCia.Text = IIf(IsDBNull(dtEmpleado.Rows(0)("compania")), "N/A", dtEmpleado.Rows(0)("compania")) & "(" & RTrim(IIf(IsDBNull(dtEmpleado.Rows(0)("nombre_cia")), "N/A", dtEmpleado.Rows(0)("nombre_cia"))) & ")"
                        txtAlta.Value = dtEmpleado.Rows(0)("alta")
                        txtImss.Text = IIf(IsDBNull(dtEmpleado.Rows(0)("imss")), "N/A", dtEmpleado.Rows(0)("imss"))
                        txtDireccion.Text = IIf(IsDBNull(dtEmpleado.Rows(0)("direccion")), "N/A", dtEmpleado.Rows(0)("direccion"))
                        txtTelCasa.Text = IIf(IsDBNull(dtEmpleado.Rows(0)("telefono1")), "N/A", dtEmpleado.Rows(0)("telefono1"))
                        txtTelCel.Text = IIf(IsDBNull(dtEmpleado.Rows(0)("telefono2")), "N/A", dtEmpleado.Rows(0)("telefono2"))
                        txtTelOfi.Text = IIf(IsDBNull(dtEmpleado.Rows(0)("telefono3")), "N/A", dtEmpleado.Rows(0)("telefono3"))

                        'If valor = True Then
                        '    Dim dtedad As DataTable = sqlExecute("select fecha_nac from familiares where reloj = '" & txtReloj.Text & "' and idfld=" & RTrim(dtConsulta.Rows(0)("id_familiar")) & "", "personal")
                        '    If IsDBNull(dtedad.Rows(0)("fecha_nac")) Then
                        '        txtEdad.Text = ""
                        '    Else
                        '        'BG 15/02/16 Cálculo de edad en base a la fecha de la consulta
                        '        fecha_fam = IIf(IsDBNull(dtedad.Rows(0)("fecha_nac")), Nothing, dtedad.Rows(0)("fecha_nac"))
                        '        txtEdad.Text = AntiguedadExacta(fecha_fam, FechaSQL(dtConsulta.Rows(0)("inicio")))
                        '        btnFhaFam.Visible = False
                        '        'ErrorProvider1.SetError(txtEdad, "")
                        '    End If
                        'ElseIf IsDBNull(dtEmpleado.Rows(0)("fha_nac")) Then
                        '    txtEdad.Text = ""
                        'Else
                        fecha_emp = IIf(IsDBNull(dtEmpleado.Rows(0)("fha_nac")), Nothing, dtEmpleado.Rows(0)("fha_nac"))
                        txtEdad.Text = AntiguedadExacta(fecha_emp, FechaSQL(dtConsulta.Rows(0)("inicio")))
                        'End If

                    Catch ex As Exception
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
                    End Try




                    'If IO.File.Exists(dtEmpleado.Rows(0)("foto")) Then
                    '    picFoto.ImageLocation = dtEmpleado.Rows(0)("foto")
                    'Else
                    picFoto.Image = My.Resources.NoFoto
                    'End If

                End If

                dtFecha.Value = dtConsulta.Rows(0)("inicio")
                dtHora.Value = dtConsulta.Rows(0)("inicio")

                txtDuracion.Value = dtConsulta.Rows(0)("duracion")

                LabelX2.Text = IIf(IsDBNull(dtConsulta.Rows(0)("usuario_captura")), "N/A", dtConsulta.Rows(0)("usuario_captura"))

                comboServicios.SelectedValue = dtConsulta.Rows(0)("cod_servicio")

                '''''BG 30/12/15 Acceso restringido nota médica 
                'Dim dtAccesoNota As DataTable = sqlExecute("select * from servicios where username='" & Usuario & "'", "sermed")
                'Dim servicio As String
                'servicio = dtAccesoNota.Rows(0)("cod_servicio")
                'If (comboServicios.SelectedValue = servicio) Then
                '    txtReceta.Enabled = True
                'End If
                ''''''

                'Dim CodFam As String = dtConsulta.Rows(0)("id_familiar")


                Try
                    txtPeso.Value = IIf(IsDBNull(dtConsulta.Rows(0)("peso")), 0.0, dtConsulta.Rows(0)("peso").ToString)
                    txtTalla.Value = IIf(IsDBNull(dtConsulta.Rows(0)("talla")), 0.0, dtConsulta.Rows(0)("talla").ToString)
                    txtTemperatura.Value = IIf(IsDBNull(dtConsulta.Rows(0)("temperatura")), 0.0, dtConsulta.Rows(0)("temperatura").ToString)
                    txtPresion.Text = IIf(IsDBNull(dtConsulta.Rows(0)("presion")), "", dtConsulta.Rows(0)("presion"))
                    cmbSintoma.SelectedValue = dtConsulta.Rows(0)("sintoma1")
                    cmbDescripcion.SelectedValue = dtConsulta.Rows(0)("subsintoma1")

                Catch ex As Exception
                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
                End Try

                Try

                    txtTratamiento.Text = IIf(IsDBNull(dtConsulta.Rows(0)("tratamiento")), "", RTrim(dtConsulta.Rows(0)("tratamiento").ToString))
                    txtReceta.Text = IIf(IsDBNull(dtConsulta.Rows(0)("nota_medica")), "", RTrim(dtConsulta.Rows(0)("nota_medica").ToString))
                    txtComentario.Text = IIf(IsDBNull(dtConsulta.Rows(0)("comentario")), "", RTrim(dtConsulta.Rows(0)("comentario").ToString))
                    txtIndicaciones.Text = IIf(IsDBNull(dtConsulta.Rows(0)("indicaciones")), "", RTrim(dtConsulta.Rows(0)("indicaciones").ToString))
                Catch ex As Exception
                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
                End Try
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

        Try
            'If sbConsultaFamiliar.Value = True Then
            Dim dtfam As DataTable = sqlExecute("select consultas.* from consultas where folio =  '" & folio & "'", "sermed")
            'Dim CodFam As String = dtfam.Rows(0)("id_familiar")
            Dim consulta As String =
               "select " & _
               "sermed.dbo.consultas.folio, " & _
               "sermed.dbo.consultas.reloj, " & _
               "convert(date, sermed.dbo.consultas.inicio) as fecha, " & _
               "convert(time, sermed.dbo.consultas.inicio) as hora, " & _
               "sermed.dbo.consultas.familiar, " & _
               "sermed.dbo.consultas.comentario, " & _
               "sermed.dbo.consultas.tratamiento, " & _
               "sermed.dbo.consultas.indicaciones, " & _
               "sermed.dbo.consultas.nota_medica, " & _
               "sermed.dbo.grupos_sintomas.nombre as 'sintoma' " & _
               "from consultas " & _
               "left join personal.dbo.personalvw on personal.dbo.personalvw.reloj = sermed.dbo.consultas.reloj " & _
               "left join sermed.dbo.grupos_sintomas on sermed.dbo.grupos_sintomas.cod_grupo = sermed.dbo.consultas.sintoma " &
               "where sermed.dbo.consultas.reloj = '" & RTrim(txtReloj.Text) & "' and sermed.dbo.consultas.tipo_paciente = '3' order by fecha desc,hora desc"

            dtConsultas = sqlExecute(consulta, "sermed")

            dgConsultas.DataSource = dtConsultas
            'End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    'Private Sub sbConsultaFamiliar_ValueChanged(sender As Object, e As EventArgs) Handles sbConsultaFamiliar.ValueChanged
    '    Try
    '        Dim dtfam As DataTable = sqlExecute("select id_familiar from consultas where folio='" & folio & "'", "sermed")
    '        panelFamiliar.Visible = sbConsultaFamiliar.Value
    '        EditaConsulta(folio, "familiar", IIf(sbConsultaFamiliar.Value = True, 1, 0))
    '        EditaConsulta(folio, "familiar_registrado", IIf(sbConsultaFamiliar.Value = True, 1, 0))
    '        'comboFamiliaresRegistrados.SelectedValue = dtfam.Rows(0)("id_familiar")
    '        'If sbConsultaFamiliar.Value = True Then
    '        dtFamiliares = sqlExecute("select familiares.idfld as 'ID', familia.cod_familia as 'Código',familia.nombre as 'Parentesco',RTrim(familiares.nombre) as 'Nombre' from familiares left join familia on familiares.cod_familia=familia.cod_familia where reloj = '" & txtReloj.Text & "'")

    '        comboFamiliaresRegistrados.DisplayMembers = "Código,Parentesco,Nombre"
    '        comboFamiliaresRegistrados.DataSource = dtFamiliares
    '        comboFamiliaresRegistrados.ValueMember = "ID"
    '        comboFamiliaresRegistrados.Columns(0).Width.Absolute = 50
    '        comboFamiliaresRegistrados.Columns(1).Width.Absolute = 80
    '        comboFamiliaresRegistrados.Columns(2).Width.Absolute = 340
    '        ' End If
    '    Catch ex As Exception
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
    '    End Try
    'End Sub

    'Private Sub sbFamiliarRegistrado_ValueChanged(sender As Object, e As EventArgs) Handles sbFamiliarRegistrado.ValueChanged
    '    Try
    '        EditaConsulta(folio, "familiar", IIf(sbConsultaFamiliar.Value = True, 1, 0))
    '        EditaConsulta(folio, "familiar_registrado", IIf(sbConsultaFamiliar.Value = True, IIf(sbFamiliarRegistrado.Value = True, 1, 0), 0))
    '        EditaConsulta(folio, "id_familiar", IIf(sbConsultaFamiliar.Value = True, comboFamiliaresRegistrados.SelectedValue, 0))
    '        'GuardarCambios()
    '        MostrarInformacion()
    '    Catch ex As Exception
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
    '    End Try
    'End Sub

    Private Sub btnAceptar_Click(sender As Object, e As System.EventArgs) Handles btnAceptar.Click
        Try
            If txtEdad.Text = "" Then

            End If
            GuardarCambios()

            Me.DialogResult = Windows.Forms.DialogResult.OK

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub GuardarCambios()
        Dim inicio As Date = dtFecha.Value.Date.AddTicks(dtHora.Value.TimeOfDay.Ticks)
        Try
            'EditaConsulta(folio, "nota_medica", txtNotaMedica.Text)
            EditaConsulta(folio, "inicio", FechaHoraSQL(inicio, True))
            EditaConsulta(folio, "duracion", txtDuracion.Value)

            EditaConsulta(folio, "comentario", txtComentario.Text.Replace("'", "''"))
            EditaConsulta(folio, "indicaciones", txtIndicaciones.Text.Replace("'", "''"))
            EditaConsulta(folio, "tratamiento", txtTratamiento.Text.Replace("'", "''"))
            EditaConsulta(folio, "nota_medica", txtReceta.Text.Replace("'", "''"))

            EditaConsulta(folio, "concluida", IIf(sbConcluida.Value, 1, 0))
            EditaConsulta(folio, "edad", txtEdad.Text)
            'EditaConsulta(folio, "meses", txtMeses.Text)
            EditaConsulta(folio, "peso", txtPeso.Value)
            EditaConsulta(folio, "talla", txtTalla.Value)
            EditaConsulta(folio, "temperatura", txtTemperatura.Value)
            EditaConsulta(folio, "presion", txtPresion.Text.Trim)
            EditaConsulta(folio, "sintoma", cmbSintoma.SelectedValue)
            EditaConsulta(folio, "subsintoma", cmbDescripcion.SelectedValue)

            EditaConsulta(folio, "familiar", 0)
            'EditaConsulta(folio, "familiar_registrado", IIf(sbConsultaFamiliar.Value, IIf(sbFamiliarRegistrado.Value, 1, 0), 0))
            'If sbConsultaFamiliar.Value = True Then
            '    Dim dtNombre As DataTable = sqlExecute("select nombre from familiares where idfld = '" & comboFamiliaresRegistrados.SelectedValue & "'")
            '    If dtNombre.Rows.Count > 0 Then
            '        EditaConsulta(folio, "nombre_paciente", dtNombre.Rows(0)("nombre").ToString.Trim)
            '    End If
            'Else
            '    EditaConsulta(folio, "nombre_paciente", txtNombre.Text)
            'End If
            EditaConsulta(folio, "cod_servicio", comboServicios.SelectedValue)

            '; sbConcluida.Value = True

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub sbConcluida_ValueChanged(sender As Object, e As EventArgs) 'Handles sbConcluida.ValueChanged
        Try
            RemoveHandler sbConcluida.ValueChanged, AddressOf sbConcluida_ValueChanged
            Dim dtAccesoNota As DataTable = sqlExecute("select * from servicios where username='" & Usuario & "'", "sermed")
            If dtAccesoNota.Rows.Count > 0 Then
                Dim servicio As String
                servicio = IIf(IsDBNull(dtAccesoNota.Rows(0)("cod_servicio")), "", dtAccesoNota.Rows(0)("cod_servicio"))
                If (comboServicios.SelectedValue = servicio) Or IsDBNull(dtAccesoNota.Rows(0)("username")) Then
                    sqlExecute("update consultas set usuario_concluye='" & Usuario & "' where folio='" & folio & "'", "sermed")
                    Panel4.Enabled = False
                    sbConcluida.Visible = Not sbConcluida.Value
                    panelInfoPaciente.Enabled = Not sbConcluida.Value
                    Panel5.Enabled = Not sbConcluida.Value
                    Panel12.Enabled = Not sbConcluida.Value
                Else
                    sbConcluida.Value = False
                End If
            Else
                sbConcluida.Value = False
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            AddHandler sbConcluida.ValueChanged, AddressOf sbConcluida_ValueChanged
        End Try
    End Sub

    Private Sub btnReceta_Click(sender As Object, e As EventArgs) Handles btnReceta.Click

        GuardarCambios()

        If txtReceta.Text <> "" Then

            Dim dtReceta As New DataTable
            dtReceta.Columns.Add("reloj", Type.GetType("System.String"))
            dtReceta.Columns.Add("nombres", Type.GetType("System.String"))
            dtReceta.Columns.Add("cia_direccion", Type.GetType("System.String"))
            dtReceta.Columns.Add("nombre_puesto", Type.GetType("System.String"))
            dtReceta.Columns.Add("edad", Type.GetType("System.String"))
            dtReceta.Columns.Add("meses", Type.GetType("System.String"))
            dtReceta.Columns.Add("nombre_paciente", Type.GetType("System.String"))
            dtReceta.Columns.Add("direccion", Type.GetType("System.String"))
            dtReceta.Columns.Add("nombre_colonia", Type.GetType("System.String"))
            dtReceta.Columns.Add("sexo", Type.GetType("System.String"))
            dtReceta.Columns.Add("fecha", Type.GetType("System.String"))
            dtReceta.Columns.Add("hora", Type.GetType("System.String"))
            dtReceta.Columns.Add("nota_medica", Type.GetType("System.String"))
            dtReceta.Columns.Add("comentario", Type.GetType("System.String"))
            dtReceta.Columns.Add("receta", Type.GetType("System.String"))
            dtReceta.Columns.Add("peso", Type.GetType("System.String"))
            dtReceta.Columns.Add("talla", Type.GetType("System.String"))
            dtReceta.Columns.Add("temperatura", Type.GetType("System.String"))
            dtReceta.Columns.Add("presion", Type.GetType("System.String"))
            dtReceta.Columns.Add("tratamiento", Type.GetType("System.String"))
            dtReceta.Columns.Add("indicaciones", Type.GetType("System.String"))
            dtReceta.Columns.Add("nombre_servicio", Type.GetType("System.String"))
            dtReceta.Columns.Add("encargado_servicio", Type.GetType("System.String"))
            dtReceta.Columns.Add("cedula_servicio", Type.GetType("System.String"))
            dtReceta.Columns.Add("universidad", Type.GetType("System.String"))
            dtReceta.Columns.Add("especialidad", Type.GetType("System.String"))
            dtReceta.Columns.Add("concluida", Type.GetType("System.String"))
            dtReceta.Columns.Add("familiar_registrado", Type.GetType("System.String"))

            Dim q As String =
                "select " & _
                    "consultas.reloj, " & _
                    "personalvw.nombres, " & _
                    "personalvw.cia_direccion, " & _
                    "personalvw.nombre_puesto, " & _
                    "consultas.edad, " & _
                    "consultas.meses, " & _
                    "consultas.nombre_paciente, " & _
                    "personalvw.direccion, " & _
                    "personalvw.nombre_colonia, " & _
                    "personalvw.sexo, " & _
                    "convert(date, consultas.inicio) as fecha, " & _
                    "convert(time, consultas.inicio) as hora, " & _
                    "consultas.nota_medica, " & _
                    "consultas.comentario, " & _
                    "consultas.receta, " & _
                    "consultas.peso, " & _
                    "consultas.talla, " & _
                    "consultas.temperatura, " & _
                    "consultas.presion, " & _
                    "consultas.tratamiento, " & _
                    "consultas.indicaciones, " & _
                    "servicios.nombre as nombre_servicio, " & _
                    "servicios.encargado as encargado_servicio, " & _
                    "servicios.cedula as cedula_servicio, " & _
                    "servicios.universidad as universidad, " & _
                    "servicios.especialidad as especialidad, " & _
                    "consultas.concluida, " & _
                    "consultas.familiar, " & _
                    "consultas.id_familiar, " & _
                    "consultas.familiar_registrado " & _
                "from consultas " & _
                    "left join personal.dbo.personalvw on personalvw.reloj = consultas.reloj " & _
                    "left join dbo.servicios on servicios.cod_servicio= consultas.cod_servicio where consultas.folio = '" & folio & "'"

            Dim dtConsulta As DataTable = sqlExecute(q, "sermed")
            Try
                If dtConsulta.Rows.Count > 0 Then
                    If dtConsulta.Rows(0)("familiar") = 1 And dtConsulta.Rows(0)("familiar_registrado") = 1 Then
                        Dim dtNombre As DataTable = sqlExecute("select nombre from familiares where idfld = '" & dtConsulta.Rows(0)("id_familiar") & "'")
                        If dtNombre.Rows.Count > 0 Then
                            dtConsulta.Rows(0)("nombre_paciente") = dtNombre.Rows(0)("nombre").ToString.Trim
                        End If
                    Else
                        Dim dtNombre As DataTable = sqlExecute("select nombres, fha_nac from personalvw where reloj = '" & dtConsulta.Rows(0)("reloj") & "'")
                        If dtNombre.Rows.Count > 0 Then
                            dtConsulta.Rows(0)("nombre_paciente") = dtNombre.Rows(0)("nombres").ToString.Trim
                        End If
                    End If
                End If
            Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            End Try
            frmVistaPrevia.LlamarReporte("Receta BRP", dtConsulta)
            frmVistaPrevia.ShowDialog()

        Else

            MessageBox.Show("Para generar Receta se debe capturar Nota Médica", "Nota médica", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            txtReceta.Focus()
            Exit Sub
        End If
    End Sub
    Private Sub txtPeso_ValueChanged(sender As Object, e As EventArgs) Handles txtPeso.ValueChanged
        Dim Peso As Double
        Dim Talla As Double
        Peso = Double.Parse(txtPeso.Value)
        Talla = Double.Parse(txtTalla.Value)
        txtIMC.Text = Math.Round((Peso / (Talla * Talla)), 2)

    End Sub

    Private Sub txtTalla_ValueChanged_1(sender As Object, e As EventArgs) Handles txtTalla.ValueChanged
        Try
            Dim Peso As Double
            Dim Talla As Double
            Peso = Double.Parse(txtPeso.Value)
            Talla = Double.Parse(txtTalla.Value)
            txtIMC.Text = Math.Round((Peso / (Talla * Talla)), 2)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub btnNota_Click(sender As Object, e As EventArgs) Handles btnNota.Click
        GuardarCambios()
        Dim dtReceta As New DataTable
        dtReceta.Columns.Add("reloj", Type.GetType("System.String"))
        dtReceta.Columns.Add("nombres", Type.GetType("System.String"))
        dtReceta.Columns.Add("cia_direccion", Type.GetType("System.String"))
        dtReceta.Columns.Add("nombre_puesto", Type.GetType("System.String"))
        dtReceta.Columns.Add("edad", Type.GetType("System.String"))
        dtReceta.Columns.Add("meses", Type.GetType("System.String"))
        dtReceta.Columns.Add("nombre_paciente", Type.GetType("System.String"))
        dtReceta.Columns.Add("direccion", Type.GetType("System.String"))
        dtReceta.Columns.Add("nombre_colonia", Type.GetType("System.String"))
        dtReceta.Columns.Add("sexo", Type.GetType("System.String"))
        dtReceta.Columns.Add("fecha", Type.GetType("System.String"))
        dtReceta.Columns.Add("hora", Type.GetType("System.String"))
        dtReceta.Columns.Add("nota_medica", Type.GetType("System.String"))
        dtReceta.Columns.Add("comentario", Type.GetType("System.String"))
        dtReceta.Columns.Add("receta", Type.GetType("System.String"))
        dtReceta.Columns.Add("peso", Type.GetType("System.String"))
        dtReceta.Columns.Add("talla", Type.GetType("System.String"))
        dtReceta.Columns.Add("temperatura", Type.GetType("System.String"))
        dtReceta.Columns.Add("presion", Type.GetType("System.String"))
        dtReceta.Columns.Add("tratamiento", Type.GetType("System.String"))
        dtReceta.Columns.Add("indicaciones", Type.GetType("System.String"))
        dtReceta.Columns.Add("nombre_servicio", Type.GetType("System.String"))
        dtReceta.Columns.Add("encargado_servicio", Type.GetType("System.String"))
        dtReceta.Columns.Add("cedula_servicio", Type.GetType("System.String"))
        dtReceta.Columns.Add("universidad", Type.GetType("System.String"))
        dtReceta.Columns.Add("especialidad", Type.GetType("System.String"))
        dtReceta.Columns.Add("concluida", Type.GetType("System.String"))
        dtReceta.Columns.Add("familiar_registrado", Type.GetType("System.String"))
        Dim q As String =
            "select " & _
                "consultas.reloj, " & _
                "personalvw.nombres, " & _
                "personalvw.cia_direccion, " & _
                "personalvw.nombre_puesto, " & _
                "consultas.edad, " & _
                "consultas.meses, " & _
                "consultas.nombre_paciente, " & _
                "personalvw.direccion, " & _
                "personalvw.nombre_colonia, " & _
                "personalvw.sexo, " & _
                "convert(date, consultas.inicio) as fecha, " & _
                "convert(time, consultas.inicio) as hora, " & _
                "consultas.nota_medica, " & _
                "consultas.comentario, " & _
                "consultas.receta, " & _
                "consultas.peso, " & _
                "consultas.talla, " & _
                "consultas.temperatura, " & _
                "consultas.presion, " & _
                "consultas.tratamiento, " & _
                "consultas.indicaciones, " & _
                "servicios.nombre as nombre_servicio, " & _
                "servicios.encargado as encargado_servicio, " & _
                "servicios.cedula as cedula_servicio, " & _
                "servicios.universidad as universidad, " & _
                "servicios.especialidad as especialidad, " & _
                "consultas.concluida, " & _
                "consultas.familiar, " & _
                "consultas.id_familiar, " & _
                "consultas.familiar_registrado " & _
            "from consultas " & _
                "left join personal.dbo.personalvw on personalvw.reloj = consultas.reloj " & _
                "left join dbo.servicios on servicios.cod_servicio= consultas.cod_servicio where consultas.folio = '" & folio & "'"

        Dim dtConsulta As DataTable = sqlExecute(q, "sermed")
        Try
            If dtConsulta.Rows.Count > 0 Then
                If dtConsulta.Rows(0)("familiar") = 1 And dtConsulta.Rows(0)("familiar_registrado") = 1 Then
                    Dim dtNombre As DataTable = sqlExecute("select nombre from familiares where idfld = '" & dtConsulta.Rows(0)("id_familiar") & "'")
                    If dtNombre.Rows.Count > 0 Then
                        dtConsulta.Rows(0)("nombre_paciente") = dtNombre.Rows(0)("nombre").ToString.Trim
                    End If
                Else
                    Dim dtNombre As DataTable = sqlExecute("select nombres, fha_nac from personalvw where reloj = '" & dtConsulta.Rows(0)("reloj") & "'")
                    If dtNombre.Rows.Count > 0 Then
                        dtConsulta.Rows(0)("nombre_paciente") = dtNombre.Rows(0)("nombres").ToString.Trim
                    End If
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
        frmVistaPrevia.LlamarReporte("Nota Médica BRP", dtConsulta)
        frmVistaPrevia.ShowDialog()
    End Sub

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click
        Try
            Clipboard.SetText(txtComentario.Text)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs)
        Try
            Clipboard.SetText(txtReceta.Text)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ButtonX3_Click_1(sender As Object, e As EventArgs) Handles ButtonX3.Click
        Try
            Clipboard.SetText(txtTratamiento.Text)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ButtonX4_Click(sender As Object, e As EventArgs) Handles ButtonX4.Click
        Try
            Clipboard.SetText(txtIndicaciones.Text)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnExpediente_Click(sender As Object, e As EventArgs)
        Try
            frmExpedientePersonal.Show()
            frmExpedientePersonal.Focus()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtPeso_ValueChanged_1(sender As Object, e As EventArgs) Handles txtPeso.ValueChanged

    End Sub

    Private Sub pnlCentrarControles_Paint(sender As Object, e As PaintEventArgs) Handles pnlCentrarControles.Paint

    End Sub

    Private Sub dgConsultas_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        Try
            Dim folio As String = dgConsultas.Rows(e.RowIndex).Cells("columnaFolio").Value
            Dim frm As New frmDetalleConsulta
            frm.folio = folio
            frm.ShowDialog()
            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub btnCancelar_Click_1(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim dt As DataTable = sqlExecute("select usuario from consultas where folio='" & folio & "'", "sermed")
        If IsDBNull(dt.Rows(0)("usuario")) Then
            sqlExecute("update sermed.dbo.consultas set usuario=NULL where folio='" & folio & "'")
        ElseIf Not IsDBNull(dt.Rows(0)("usuario")) And RTrim(dt.Rows(0)("usuario")) = Usuario Then
            sqlExecute("update sermed.dbo.consultas set usuario=NULL where folio='" & folio & "'")
        End If
        'GuardarCambios()
    End Sub

    Private Sub cmbSintoma_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSintoma.SelectedValueChanged
        Try
            Dim dtdesc As DataTable
            dtdesc = sqlExecute("select * from sintomas where cod_grupo='" & cmbSintoma.SelectedValue & "'", "sermed")
            If dtdesc.Rows.Count Then
                cmbDescripcion.DataSource = dtdesc
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    'Private Sub btnFhaFam_Click(sender As Object, e As EventArgs) Handles btnFhaFam.Click
    '    'Dim dtidfld As DataTable = sqlExecute("select idfld from familiares where idfld='" & dtc & "'")
    '    cod_familiar = comboFamiliaresRegistrados.SelectedValue
    '    frmAgregarFamiliar.editar = True
    '    frmAgregarFamiliar.idfamiliar = cod_familiar
    '    frmAgregarFamiliar.ShowDialog()

    '    MostrarInformacion()
    'End Sub

    Private Sub pnlEncabezado_Paint(sender As Object, e As PaintEventArgs) Handles pnlEncabezado.Paint

    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        Try
            If SuperTabControl1.SelectedTab Is tabExpediente Then
                btnReporte.Visible = True
            Else
                btnReporte.Visible = False
            End If

            '''''BG 30/12/15 Acceso restringido nota médica 
            Dim dtAccesoNota As DataTable = sqlExecute("select * from servicios where username='" & Usuario & "'", "sermed")
            If dtAccesoNota.Rows.Count > 0 Then
                Dim servicio As String
                servicio = dtAccesoNota.Rows(0)("cod_servicio")
                If (comboServicios.SelectedValue = servicio) Or IsDBNull(dtAccesoNota.Rows(0)("username")) Then
                    txtReceta.Enabled = True
                    btnNota.Enabled = True
                    dtEditarNota = sqlExecute("SELECT acceso FROM permisos WHERE tipo = 'T' AND control = 'tabNotaMedica' AND cod_perfil " & Perfil, "Seguridad")
                    If dtEditarNota.Rows(0)("acceso") = 1 And SuperTabControl1.SelectedTab Is tabReceta And (txtReceta.Text = "" Or txtReceta.Text.ToString.StartsWith(" ")) Then
                        If sbConcluida.Value = False Then
                            MessageBox.Show("Para generar Receta se debe capturar Nota Médica", "Nota médica", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            SuperTabControl1.SelectedTab = tabNotaMedica
                        End If

                    End If

                    GuardarCambios()
                Else
                    btnNota.Enabled = False
                    txtReceta.Enabled = False
                    GuardarCambios()
                End If
            Else
                btnNota.Enabled = False
                txtReceta.Enabled = False
                GuardarCambios()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub TimerActualizar_Tick(sender As Object, e As EventArgs)
        'Try
        '    Dim folio As String = ""
        '    If txtFolio.Text.Trim <> "" Then
        '        folio = CalendarView1.SelectedAppointments(0).Appointment.Id
        '    End If
        MostrarInformacion()
        '    CargarAppointments(folio)
        LabelUpdate.Text = "Actualizado: " & FechaHoraSQL(Now, True, False)

        'Catch ex As Exception

        'End Try
    End Sub

    'Private Sub comboFamiliaresRegistrados_SelectedValueChanged(sender As Object, e As EventArgs) Handles comboFamiliaresRegistrados.SelectedValueChanged
    '    If sbConsultaFamiliar.Value = True Then
    '        Dim dtNombre As DataTable = sqlExecute("select nombre from familiares where idfld = '" & comboFamiliaresRegistrados.SelectedValue & "'")
    '        If comboFamiliaresRegistrados.SelectedValue <> Nothing Then
    '            EditaConsulta(folio, "nombre_paciente", dtNombre.Rows(0)("nombre").ToString.Trim)
    '            EditaConsulta(folio, "id_familiar", comboFamiliaresRegistrados.SelectedValue)
    '        End If

    '    End If
    '    MostrarInformacion()
    'End Sub

    Private Sub dgConsultas_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgConsultas.CellDoubleClick
        Try
            Dim folio As String = dgConsultas.Rows(e.RowIndex).Cells("columnaFolio").Value
            Dim frm As New frmDetalleConsulta
            frm.folio = folio
            frm.ShowDialog()
            MostrarInformacion()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtConsultas As DataTable = sqlExecute("select * from consultasvw")
        Dim dtDatos As DataTable
        Try
            'If sbConsultaFamiliar.Value = True Then
            '    Dim dtfam As DataTable = sqlExecute("select consultas.* from consultas where folio =  '" & folio & "'", "sermed")
            '    Dim CodFam As String = dtfam.Rows(0)("id_familiar")
            '    Dim consulta As String = "select * from sermed.dbo.consultasvw where reloj = '" & RTrim(txtReloj.Text) & "' and id_familiar = '" & CodFam & "' and familiar = '1' order by fecha desc,hora desc"
            '    dtConsultas = sqlExecute(consulta, "sermed")

            '    frmVistaPrevia.LlamarReporte("Expediente personal", dtConsultas)
            '    frmVistaPrevia.ShowDialog()
            'Else
            Dim consulta As String = "select * from consultasvw where reloj = '" & RTrim(txtReloj.Text) & "' and tipo_paciente = '3' order by fecha desc,hora desc"

            dtConsultas = sqlExecute(consulta, "sermed")
            frmVistaPrevia.LlamarReporte("Expediente personal", dtConsultas)
            frmVistaPrevia.ShowDialog()
            'End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
End Class