Public Class frmUsuariosAdmKiosco

    Dim dtUsuarios As New DataTable
    Dim dtRegistro As New DataTable
    Dim dtPerfiles As New DataTable

    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean
    Dim CambiarClave As Boolean
    Dim SubConsulta As String = ""

    Private Sub frmUsuariosAdmKiosco_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try

            dtUsuarios = sqlExecute("SELECT RTRIM(username) AS USUARIO,RTRIM(NOMBRE) AS NOMBRE,cod_perfil AS PERFIL, RTRIM(PUESTO) as PUESTO FROM appuser", "kiosco")
            dtUsuarios.DefaultView.Sort = "USUARIO"

            dtPerfiles = sqlExecute("SELECT ltrim(rtrim(COD_PERFIL)) as COD_PERFIL,ltrim(rtrim(NOMBRE)) as NOMBRE FROM PERFILES", "kiosco")
            dtPerfiles.DefaultView.Sort = "COD_PERFIL"
            cmbPerfiles.DataSource = dtPerfiles
            cmbPerfiles.ValueMember = "COD_PERFIL"
            cmbPerfiles.DisplayMembers = "COD_PERFIL,NOMBRE"

            dgTabla.DataSource = dtUsuarios
            dgTabla.Columns(0).Width = 150
            dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgTabla.Columns(2).Width = 150
            dgTabla.Columns(3).Width = 500

            dtRegistro = sqlExecute("SELECT TOP 1 * FROM appuser ORDER BY username ASC", "kiosco")

            MostrarInformacion()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Se presentó un error al intentar cargar la información de usuarios del administardor del kiosco. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub MostrarInformacion()

        Dim i As Integer = 0
        Dim dUsuario As DataRow = Nothing

        Try

            If dtRegistro.Rows.Count > 0 Then

                dUsuario = dtRegistro.Rows(0)

                txtNombreCompleto.Text = IIf(IsDBNull(dUsuario("NOMBRE")), "", dUsuario("NOMBRE"))
                txtPuesto.Text = IIf(IsDBNull(dUsuario("PUESTO")), "", dUsuario("PUESTO"))
                txtUsuario.Text = IIf(IsDBNull(dUsuario("USERNAME")), "", dUsuario("USERNAME"))
                cmbPerfiles.SelectedValue = IIf(IsDBNull(dUsuario("COD_PERFIL")), "", dUsuario("COD_PERFIL"))

                If Not DesdeGrid Then
                    i = dtUsuarios.DefaultView.Find(txtUsuario.Text)
                    If i >= 0 Then
                        dgTabla.FirstDisplayedScrollingRowIndex = i
                        dgTabla.Rows(i).Selected = True
                    End If
                End If

            End If

            DesdeGrid = False
            HabilitarBotones()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub HabilitarBotones()
        Dim NoRec As Boolean
        NoRec = dgTabla.Rows.Count = 0

        btnPrimero.Enabled = Not (Agregar Or Editar Or CambiarClave Or NoRec)
        btnAnterior.Enabled = Not (Agregar Or Editar Or CambiarClave Or NoRec)
        btnSiguiente.Enabled = Not (Agregar Or Editar Or CambiarClave Or NoRec)
        btnUltimo.Enabled = Not (Agregar Or Editar Or CambiarClave Or NoRec)

        btnReporte.Enabled = Not (Agregar Or Editar Or CambiarClave Or NoRec)
        btnBuscar.Enabled = Not (Agregar Or Editar Or CambiarClave Or NoRec)
        btnBorrar.Enabled = Not (Agregar Or Editar Or CambiarClave Or NoRec)
        btnCerrar.Enabled = Not (Agregar Or Editar Or CambiarClave Or NoRec)
        pnlDatos.Enabled = Agregar Or Editar Or CambiarClave
        PnlClave.Visible = Agregar Or CambiarClave
        btnReporte.Enabled = Not (Agregar Or Editar Or CambiarClave Or NoRec)
        btnCambiarClave.Enabled = Not (Agregar Or Editar Or CambiarClave Or NoRec)
        btnEditar.Enabled = Not (Not (Editar Or Agregar) And NoRec)

        If Agregar Or Editar Or CambiarClave Then
            ' Si está activa la edición o nuevo registro
            btnNuevo.Image = PIDA.My.Resources.Ok16
            btnEditar.Image = PIDA.My.Resources.CancelX
            btnNuevo.Text = "Aceptar"
            btnEditar.Text = "Cancelar"
            tabBuscar.SelectedTabIndex = 0
        Else

            btnNuevo.Image = PIDA.My.Resources.NewRecord
            btnEditar.Image = PIDA.My.Resources.Edit

            btnNuevo.Text = "Agregar"
            btnEditar.Text = "Editar"
        End If


        txtNombreCompleto.Enabled = Not CambiarClave
        txtPuesto.Enabled = Not CambiarClave
        txtUsuario.Enabled = Agregar
        cmbPerfiles.Enabled = Not CambiarClave

        If Agregar Then
            txtNombreCompleto.Text = ""
            txtUsuario.Text = ""
            txtPuesto.Text = ""
            cmbPerfiles.SelectedIndex = -1
            txtClave.Text = ""
            txtConfirmarclave.Text = ""
            txtUsuario.Focus()

        ElseIf Editar Then
            txtUsuario.Focus()

        ElseIf CambiarClave Then

            txtClave.Text = ""
            txtConfirmarclave.Text = ""
            txtClave.Focus()

        End If

    End Sub

    Private Sub frmUsuariosAdmKiosco_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("appuser", "USERNAME", txtUsuario.Text, dtRegistro, "KIOSCO")
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Siguiente("appuser", "USERNAME", txtUsuario.Text, dtRegistro, "KIOSCO")
        MostrarInformacion()
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Primero("appuser", "USERNAME", dtRegistro, "KIOSCO")
        MostrarInformacion()
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Ultimo("appuser", "USERNAME", dtRegistro, "KIOSCO")
        MostrarInformacion()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click

        Dim NvaClave As String = ""

        Try

            If txtNombreCompleto.Text.Trim.Equals("") Then
                MessageBox.Show("El nombre del usuario no puede estar en blanco. Favor de verificar.", "Nombre de usuario en blanco", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtNombreCompleto.Focus()
                Exit Sub
            End If

            If txtUsuario.Text.Trim.Equals("") Then
                MessageBox.Show("El Usuario(nickname) no puede estar en blanco. Favor de verificar.", "Usuario en blanco", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtUsuario.Focus()
                Exit Sub
            End If

            If cmbPerfiles.SelectedIndex < 0 Then
                MessageBox.Show("Debe seleccionar un perfil para el usuario. Favor de verificar.", "Sin perfil seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cmbPerfiles.Focus()
                Exit Sub
            End If


            If Agregar Then

                ' Si Agregar, revisar si existe el usuario

                If txtClave.Text.Trim = "" Then
                    MessageBox.Show("Debe establecer una contraseña de acceso al admnistrador de kiosco. Favor de verificar.", "Sin contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtClave.Focus()
                    Exit Sub
                End If


                dtTemporal = sqlExecute("SELECT username FROM appuser where username = '" & txtUsuario.Text.Trim & "'", "KIOSCO")
                If dtTemporal.Rows.Count > 0 Then
                    MessageBox.Show("El Usuario que intentas crear ya existe, por favor intenta con otro.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtUsuario.Focus()
                    Exit Sub

                Else

                    If txtClave.Text.Trim <> txtConfirmarclave.Text.Trim Then
                        MessageBox.Show("La clave no coincide. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtClave.Focus()
                        Exit Sub
                    End If

                    'If ValidarClaveAcceso(txtClave.Text) Then
                    '    NvaClave = getMD5Hash(txtClave.Text.Trim)
                    '    dtTemporal = sqlExecute("SELECT userpass FROM appuser WHERE username = '" & Usuario & "'", "KIOSCO")
                    '    If dtTemporal.Rows(0).Item(0) = NvaClave Then
                    '        MessageBox.Show("La clave no puede ser igual que la anterior. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '        txtClave.Focus()
                    '        Exit Sub
                    '    End If
                    'Else
                    '    MessageBox.Show("El cambio no pudo ser realizado porque la clave de acceso no cumple la validación (mínimo 15 caracteres, y que incluya al menos un número, una mayúscula, una minúscula y un caracter especial).", "Cambio de clave de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    txtClave.Focus()
                    '    Exit Sub
                    'End If

                    NvaClave = getMD5Hash(txtClave.Text.Trim)

                    sqlExecute("INSERT INTO appuser (USERNAME,USERPASS,COD_PERFIL,NOMBRE,PUESTO) VALUES('" & txtUsuario.Text.Trim & "','" & NvaClave & "','" & cmbPerfiles.SelectedValue.ToString & "','" & txtNombreCompleto.Text.Trim & "','" & txtPuesto.Text.Trim & "')", "KIOSCO")

                    Agregar = False

                End If

            ElseIf Editar Then
                ' Si Editar, entonces guardar cambios a registro

                sqlExecute("update appuser set cod_perfil = '" & cmbPerfiles.SelectedValue.ToString & "'," & _
                           "NOMBRE = '" & txtNombreCompleto.Text.Trim & "'," & _
                           " PUESTO = '" & txtPuesto.Text.Trim & "' where USERNAME = '" & txtUsuario.Text.Trim & "'", "Kiosco")

            ElseIf CambiarClave Then

                If txtClave.Text.Trim = "" Then
                    MessageBox.Show("Debe establecer una contraseña de acceso al admnistrador de kiosco. Favor de verificar.", "Sin contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtClave.Focus()
                    Exit Sub
                End If

                If txtClave.Text.Trim <> txtConfirmarclave.Text.Trim Then
                    MessageBox.Show("Las contraseñas no coinciden. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtClave.Focus()
                    Exit Sub
                End If

                NvaClave = getMD5Hash(txtClave.Text.Trim)

                If Not sqlExecute("update appuser set USERPASS = '" & NvaClave & "' where USERNAME = '" & txtUsuario.Text & "'", "KIOSCO").Columns.Contains("ERROR") Then
                    MessageBox.Show("Cambio de contraseña exitoso.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Las contraseña no pudo ser cambiada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

            Else
                Agregar = True
            End If

            Editar = False
            CambiarClave = False

            HabilitarBotones()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Se detectó un error, por lo que no se pudo continuar. Si el error persiste, contacte al administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If Not Editar And Not Agregar And Not CambiarClave Then
            Editar = True
            HabilitarBotones()
            txtUsuario.Focus()
        Else
            CambiarClave = False
            Editar = False
        End If
        Agregar = False
        MostrarInformacion()
    End Sub

    Private Sub frmUsuariosAdmKiosco_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        pnlCentrado.Left = (Me.Width - pnlCentrado.Width) / 2
    End Sub

    Private Sub btnCambiarClave_Click(sender As Object, e As EventArgs) Handles btnCambiarClave.Click

        CambiarClave = True
        HabilitarBotones()

    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("kiosco.dbo.appuser", "username", "USUARIOS", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * FROM appuser WHERE username = '" & Cod & "' ", "kiosco")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try

            Dim codigo_usuario As String = txtUsuario.Text.Trim

            If MessageBox.Show("¿Está seguro de borrar el registro " & codigo_usuario & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM appuser WHERE username = '" & codigo_usuario & "'", "Kiosco")

                dtUsuarios = sqlExecute("SELECT RTRIM(username) AS USUARIO,RTRIM(NOMBRE) AS NOMBRE,cod_perfil AS PERFIL, RTRIM(PUESTO) as PUESTO FROM appuser", "kiosco")
                dtUsuarios.DefaultView.Sort = "USUARIO"
                dgTabla.DataSource = dtUsuarios

                btnSiguiente.PerformClick()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Se detectó un error al intentar borrar el registro. Si el error persiste, contacte al administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgTabla_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        Try
            Dim cod As String

            DesdeGrid = True

            cod = dgTabla.Item("USUARIO", e.RowIndex).Value
            dtRegistro = sqlExecute("SELECT * FROM appuser WHERE username = '" & cod & "'", "kiosco")
            MostrarInformacion()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtUsuarios As New DataTable

        Try

            dtUsuarios = sqlExecute("select username,cod_perfil,rtrim(ltrim(nombre)) as nombre,rtrim(ltrim(puesto)) as puesto from appuser order by cod_perfil", "Kiosco")

            If dtUsuarios.Rows.Count > 0 Then
                frmVistaPrevia.LlamarReporte("UsuariosAdmKiosco", dtUsuarios, "")
                frmVistaPrevia.ShowDialog()
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
End Class