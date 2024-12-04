Imports OfficeOpenXml
Public Class frmUsuarios
    Dim dtUsuarios As New DataTable
    Dim dtRegistro As New DataTable
    Dim dtPerfiles As New DataTable
    Dim dtCia As New DataTable
    Dim dtValores As New DataTable
    Dim dtTemp As New DataTable

    Dim DesdeGrid As Boolean
    Dim Editar As Boolean
    Dim Agregar As Boolean

    Private Sub frmUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim dtJefes As New DataTable
            gpFiltro.Location = chkTodos.Location

            dtCia = sqlExecute("SELECT DIAS_EXPIRA_CLAVE FROM parametros")

            dtUsuarios = sqlExecute("SELECT RTRIM(username) AS USUARIO,RTRIM(NOMBRE) AS NOMBRE,cod_perfil AS PERFIL FROM appuser", "seguridad")
            dtUsuarios.DefaultView.Sort = "USUARIO"

            dtPerfiles = sqlExecute("SELECT cod_perfil,nombre FROM perfiles", "seguridad")
            cmbPerfil.DataSource = dtPerfiles

            dgTabla.DataSource = dtUsuarios
            dgTabla.Columns(0).Width = 150
            dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgTabla.Columns(2).Width = 150

            dtRegistro = sqlExecute("SELECT TOP 1 * FROM appuser ORDER BY username ASC", "seguridad")

            cbCampos.DataSource = sqlExecute("SELECT UPPER(nombre) AS 'NOMBRE' FROM campos WHERE tipo='char' ORDER BY nombre")
            cbComparacion.SelectedValue = "="

            dtJefes = dtUsuarios.Copy
            dtJefes.Rows.Add({"", "INDEFINIDO"})
            cmbNivel1.DataSource = dtJefes
            cmbNivel2.DataSource = dtJefes.Copy

            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

        End Try
    End Sub

    Private Sub MostrarInformacion()
        Dim i As Integer
        Dim dUsr As DataRow
        Dim inactivo As Boolean = False
        Try
            dUsr = dtRegistro.Rows(0)
            txtUsuario.Text = IIf(IsDBNull(dUsr("username")), "", dUsr("username")).ToString.Trim
            cmbPerfil.SelectedValue = IIf(IsDBNull(dUsr("cod_perfil")), "", dUsr("cod_perfil"))
            txtNotas.Text = IIf(IsDBNull(dUsr("NOMBRE")), "", dUsr("NOMBRE")).ToString.Trim
            txtEmail.Text = IIf(IsDBNull(dUsr("email")), "", dUsr("email")).ToString.Trim
            cmbNivel1.SelectedValue = IIf(IsDBNull(dUsr("usuario_n1")), "", dUsr("usuario_n1")).ToString.Trim
            cmbNivel2.SelectedValue = IIf(IsDBNull(dUsr("usuario_n2")), "", dUsr("usuario_n2")).ToString.Trim
            chkTodos.Checked = IIf(IsDBNull(dUsr("filtro")), "", dUsr("filtro")).ToString.Trim.Length = 0
            chkFiltros.Checked = Not chkTodos.Checked
            txtCriterio.Text = IIf(IsDBNull(dUsr("filtro")), "", dUsr("filtro")).ToString.Trim
            txtReloj.Text = IIf(IsDBNull(dUsr("reloj")), "", dUsr("reloj")).ToString.Trim
            inactivo = IIf(dUsr("Activo") = 1, False, True)
            chkInactivo.Checked = inactivo
            lblInactivo.Visible = inactivo
            lblActivo.Visible = Not inactivo



            If Not DesdeGrid Then
                i = dtUsuarios.DefaultView.Find(txtUsuario.Text)
                If i >= 0 Then
                    dgTabla.FirstDisplayedScrollingRowIndex = i
                    dgTabla.Rows(i).Selected = True
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
        btnPrimero.Enabled = Not (Agregar Or Editar Or NoRec)
        btnAnterior.Enabled = Not (Agregar Or Editar Or NoRec)
        btnSiguiente.Enabled = Not (Agregar Or Editar Or NoRec)
        btnUltimo.Enabled = Not (Agregar Or Editar Or NoRec)

        btnReporte.Enabled = Not (Agregar Or Editar Or NoRec)
        btnBuscar.Enabled = Not (Agregar Or Editar Or NoRec)
        btnBorrar.Enabled = Not (Agregar Or Editar Or NoRec)
        btnCerrar.Enabled = Not (Agregar Or Editar Or NoRec)
        pnlDatos.Enabled = Agregar Or Editar
        btnReporte.Enabled = Not (Agregar Or Editar Or NoRec)
        pnlClave.Visible = Agregar
        btnCambiarClave.Enabled = Not (Agregar Or Editar Or NoRec)
        btnEditar.Enabled = Not (Not (Editar Or Agregar) And NoRec)


        If Agregar Or Editar Then
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

        txtUsuario.Enabled = Agregar

        If Agregar Then
            txtUsuario.Text = ""
            txtNotas.Text = ""
            cmbPerfil.SelectedIndex = -1
            txtClave.Text = ""
            txtConfirmarClave.Text = ""
            chkInactivo.Checked = False
            txtReloj.Text = ""
            'txtCriterio.Text = ""
            lblActivo.Visible = False
            lblInactivo.Visible = False
            'chkInactivo.Visible = False
            txtUsuario.Focus()
        ElseIf Editar Then
            txtUsuario.Focus()
        End If
    End Sub

    Private Sub ReflectionLabel1_Click(sender As Object, e As EventArgs) Handles ReflectionLabel1.Click

    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Primero("appuser", "username", dtRegistro, "seguridad")
        MostrarInformacion()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("appuser", "username", txtUsuario.Text, dtRegistro, "seguridad")
        MostrarInformacion()
    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Siguiente("appuser", "username", txtUsuario.Text, dtRegistro, "seguridad")
        MostrarInformacion()
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Ultimo("appuser", "username", dtRegistro, "seguridad")
        MostrarInformacion()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("seguridad.dbo.appuser", "username", "USUARIOS", False)
        If Cod <> "CANCELAR" Then
            dtRegistro = sqlExecute("SELECT * FROM appuser WHERE username = '" & Cod & "' ", "seguridad")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click

        Dim NvaClave As String
        Try

            If Agregar Then
                ' Si Agregar, revisar si existe banco
                dtTemporal = sqlExecute("SELECT username FROM appuser where username = '" & txtUsuario.Text & "'", "seguridad")
                If dtTemporal.Rows.Count > 0 Then
                    MessageBox.Show("El registro no se puede agregar, ya existe el usuario '" & txtUsuario.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtUsuario.Focus()
                    Exit Sub
                Else

                    If txtClave.Text.Trim <> txtConfirmarClave.Text.Trim Then
                        MessageBox.Show("La clave no coincide. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtClave.Focus()
                        Exit Sub
                    End If

                    If ValidarClaveAcceso(txtClave.Text) Then
                        NvaClave = getMD5Hash(txtClave.Text.Trim)
                        dtTemporal = sqlExecute("SELECT userpass FROM appuser WHERE username = '" & Usuario & "'", "Seguridad")
                        If dtTemporal.Rows(0).Item(0) = NvaClave Then
                            MessageBox.Show("La clave no puede ser igual que la anterior. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            txtClave.Focus()
                            Exit Sub
                        End If
                    Else
                        MessageBox.Show("El cambio no pudo ser realizado porque la clave de acceso no cumple la validación (mínimo 15 caracteres, y que incluya al menos un número, una mayúscula, una minúscula y un caracter especial).", "Cambio de clave de acceso", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtClave.Focus()
                        Exit Sub
                    End If

                    sqlExecute("INSERT INTO appuser (username,userpass,NOMBRE,fecha_expira,activo) VALUES ('" & txtUsuario.Text & "','" & _
                               getMD5Hash(txtClave.Text.Trim) & "','" & txtNotas.Text.Trim & _
                               "',DATEADD(DAY," & dtCia.Rows(0).Item("DIAS_EXPIRA_CLAVE") & ",GETDATE()),1)", "seguridad")
                    dtUsuarios.Rows.Add({txtUsuario.Text, cmbPerfil.SelectedValue})
                    Agregar = False
                    Editar = True
                End If
            End If

            If Editar Then
                ' Si Editar, entonces guardar cambios a registro
                Try
                    Dim ml As New System.Net.Mail.MailAddress(txtEmail.Text.Trim)
                Catch ex As Exception
                    If txtEmail.Text.Trim.Length > 0 Then
                        MessageBox.Show("La dirección de email no es válida. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtEmail.Focus()
                        Exit Sub
                    End If
                End Try

                If cmbNivel1.SelectedValue = txtUsuario.Text Or cmbNivel2.SelectedValue = txtUsuario.Text Then
                    MessageBox.Show("No se puede definir como superior al mismo usuario. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If cmbNivel1.SelectedValue = txtUsuario.Text Then
                        cmbNivel1.Focus()
                    Else
                        cmbNivel2.Focus()
                    End If
                    Exit Sub
                End If
                If (chkInactivo.Checked) Then
                    sqlExecute("UPDATE appuser SET USERPASS = '" & "passwordPIDA" & _
                           "' WHERE username = '" & txtUsuario.Text & "'", "seguridad")
                End If
                sqlExecute("UPDATE appuser SET NOMBRE = '" & txtNotas.Text & _
                           "',cod_perfil = '" & cmbPerfil.SelectedValue & _
                           "',email = '" & txtEmail.Text & _
                           "',usuario_n1 = '" & cmbNivel1.SelectedValue & _
                           "',usuario_n2 = '" & cmbNivel2.SelectedValue & _
                           "',filtro = '" & txtCriterio.Text.Replace("'", "''") & _
                               "',reloj = '" & txtReloj.Text & _
                            "',Activo = " & IIf(chkInactivo.Checked = True, 0, 1) & _
                           " WHERE username = '" & txtUsuario.Text & "'", "seguridad")
            Else
                Agregar = True
            End If
            Editar = False

            HabilitarBotones()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Se detectó un error, por lo que no se pudo continuar. Si el error persiste, contacte al administrador del sistema.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If Not Editar And Not Agregar Then
            Editar = True
            HabilitarBotones()
            txtUsuario.Focus()
        Else
            Editar = False
        End If
        Agregar = False
        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Try

            Codigo = txtUsuario.Text

            If MessageBox.Show("¿Está seguro de borrar el registro " & Codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM appuser WHERE username = '" & Codigo & "'", "seguridad")

                dtUsuarios = sqlExecute("SELECT username AS USUARIO,cod_perfil AS PERFIL FROM appuser", "seguridad")
                dtUsuarios.DefaultView.Sort = "USUARIO"
                dgTabla.DataSource = dtUsuarios

                btnSiguiente.PerformClick()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub dgTabla_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.CellContentClick

    End Sub

    Private Sub dgTabla_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        Try
            Dim cod As String

            DesdeGrid = True

            cod = dgTabla.Item("USUARIO", e.RowIndex).Value
            dtRegistro = sqlExecute("SELECT * FROM appuser WHERE username = '" & cod & "'", "seguridad")
            MostrarInformacion()

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Try
            Dim nombre_archivo As String = ""

            Dim sfd As New SaveFileDialog
            sfd.FileName = "Reporte de usuarios"
            sfd.Filter = "Excel File|*.xlsx"
            sfd.Title = "Archivo de excel"

            If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                nombre_archivo = sfd.FileName


                '*********************************************************************

                Dim dtUsuarios As DataTable = sqlExecute("select username as usuario, appuser.nombre as nombre_usuario, appuser.cod_perfil,  " & _
                                                         " filtro as filtro, appuser.reloj as reloj, PersonalVW.nombres as nombre_empleado, personalvw.nombre_puesto,   " & _
                                                         "perfiles.nivel_consulta, appuser.activo, perfiles.nivel_sueldos, perfiles.nivel_edicion, perfiles.taperiodos_inactivos   " & _
                                                         " from seguridad.dbo.appuser left join seguridad.dbo.perfiles on perfiles.cod_perfil = appuser.cod_perfil   " & _
                                                         " left join personal.dbo.personalvw on personalvw.reloj = appuser.reloj")

                Dim dtUsuariosArchivo As New DataTable
                dtUsuariosArchivo.Columns.Add("usuario")
                dtUsuariosArchivo.Columns.Add("nombre_usuario")
                dtUsuariosArchivo.Columns.Add("activo")
                dtUsuariosArchivo.Columns.Add("cod_perfil")
                dtUsuariosArchivo.Columns.Add("filtro")
                dtUsuariosArchivo.Columns.Add("reloj")
                dtUsuariosArchivo.Columns.Add("nombre_empleado")
                dtUsuariosArchivo.Columns.Add("nombre_puesto")

                Dim dtClase As DataTable = sqlExecute("select distinct cod_clase, nombre, NIVEL_SEGURIDAD from clase order by nivel_seguridad asc")

                For Each row As DataRow In dtClase.Rows
                    Try
                        dtUsuariosArchivo.Columns.Add(RTrim(row("nombre")) & "_consulta")
                        dtUsuariosArchivo.Columns.Add(RTrim(row("nombre")) & "_edicion")
                        dtUsuariosArchivo.Columns.Add(RTrim(row("nombre")) & "_sueldos")
                    Catch ex As Exception

                    End Try
                Next

                For Each row As DataRow In dtUsuarios.Rows
                    Dim dr As DataRow = dtUsuariosArchivo.NewRow
                    dr("usuario") = IIf(IsDBNull(row("usuario")), "", row("usuario"))
                    dr("nombre_usuario") = IIf(IsDBNull(row("nombre_usuario")), "", row("nombre_usuario"))
                    dr("activo") = IIf(IsDBNull(row("activo")), "0", row("activo"))
                    dr("cod_perfil") = IIf(IsDBNull(row("cod_perfil")), "", row("cod_perfil"))
                    dr("filtro") = IIf(IsDBNull(row("filtro")), "", row("filtro"))
                    dr("reloj") = IIf(IsDBNull(row("reloj")), "", row("reloj"))
                    dr("nombre_empleado") = IIf(IsDBNull(row("nombre_empleado")), "", row("nombre_empleado"))
                    dr("nombre_puesto") = IIf(IsDBNull(row("nombre_puesto")), "", row("nombre_puesto"))

                    For Each row_clase As DataRow In dtClase.Rows
                        Dim nivel_seguridad As Integer = row_clase("nivel_seguridad")
                        If row("nivel_consulta") >= nivel_seguridad Then
                            dr(RTrim(row_clase("nombre")) & "_consulta") = "SI"
                        Else
                            dr(RTrim(row_clase("nombre")) & "_consulta") = "NO"
                        End If

                        If row("nivel_edicion") >= nivel_seguridad Then
                            dr(RTrim(row_clase("nombre")) & "_edicion") = "SI"
                        Else
                            dr(RTrim(row_clase("nombre")) & "_edicion") = "NO"
                        End If

                        If row("nivel_sueldos") >= nivel_seguridad Then
                            dr(RTrim(row_clase("nombre")) & "_sueldos") = "SI"
                        Else
                            dr(RTrim(row_clase("nombre")) & "_sueldos") = "NO"
                        End If

                    Next

                    dtUsuariosArchivo.Rows.Add(dr)

                Next

                Dim archivo As ExcelPackage = New ExcelPackage()
                Dim wb As ExcelWorkbook = archivo.Workbook

                '*********************************************************************

                Dim hoja_usuarios As ExcelWorksheet = wb.Worksheets.Add("Usuarios")

                Dim x As Integer = 2
                Dim y As Integer = 1

                For Each column As DataColumn In dtUsuariosArchivo.Columns
                    Dim nombre_columna As String = column.ColumnName.Replace("_", vbCrLf)
                    hoja_usuarios.Cells(x, y).Style.Font.Bold = True
                    hoja_usuarios.Cells(x, y).Value = StrConv(nombre_columna, VbStrConv.ProperCase)
                    hoja_usuarios.Cells(x, y).Style.WrapText = True

                    If y >= 9 Then
                        hoja_usuarios.Cells(x, y).Style.TextRotation = 90
                    End If

                    y += 1
                Next

                x += 1
                y = 1

                For Each row As DataRow In dtUsuariosArchivo.Rows
                    For Each column As DataColumn In dtUsuariosArchivo.Columns
                        hoja_usuarios.Cells(x, y).Value = RTrim(row(column.ColumnName))
                        y += 1
                    Next
                    y = 1
                    x += 1
                Next

                hoja_usuarios.Cells(hoja_usuarios.Dimension.Address).AutoFitColumns()
                hoja_usuarios.Cells(1, 1).Style.Font.Bold = True
                hoja_usuarios.Cells(1, 1).Style.Font.Size = 24
                hoja_usuarios.Cells(1, 1).Value = "Listado de usuarios"

                '*********************************************************************

                Dim dtAccesos As New DataTable
                dtAccesos.Columns.Add("perfil")
                dtAccesos.Columns.Add("modulo")
                dtAccesos.Columns.Add("control")
                dtAccesos.Columns.Add("nombre")
                dtAccesos.Columns.Add("tipo")
                dtAccesos.Columns.Add("acceso")


                Dim i As Integer
                Dim si As Integer
                Dim t As Integer = 0
                Dim Tg As String

                For Each rp In frmMain.rbGeneral.Controls



                    'Poner como tag en cada RibbonPanel, a qué módulo pertenece
                    Tg = rp.tag
                    'Revisar cada control dentro del panel
                    For Each c In rp.controls
                        i = 0
                        If TypeOf c Is DevComponents.DotNetBar.RibbonBar Then
                            ' Si es un ribbonbar, revisar cada elemento (botón)
                            For Each r In c.items
                                si = r.subitems.count
                                If si > 0 Then
                                    'Si tiene subitems, revisar los accesos a cada uno
                                    si = 0
                                    For Each s In r.subitems
                                        Dim dr As DataRow = dtAccesos.NewRow
                                        dr("perfil") = ""
                                        dr("modulo") = Tg
                                        dr("control") = s.name
                                        dr("nombre") = s.text
                                        dr("tipo") = "F"
                                        dr("acceso") = "NO"
                                        dtAccesos.Rows.Add(dr)
                                    Next
                                Else
                                    'Si no tiene subitems, igualar la variable a 1 para que revise acceso al botón
                                    si = 1
                                End If

                                If si > 0 Then
                                    'Si se tiene acceso a alguno de los subitems, o no tiene subitems, revisar acceso del botón
                                    Dim dr As DataRow = dtAccesos.NewRow
                                    dr("perfil") = ""
                                    dr("modulo") = Tg
                                    dr("control") = r.name
                                    dr("nombre") = r.text
                                    dr("tipo") = "F"
                                    dr("acceso") = "NO"
                                    dtAccesos.Rows.Add(dr)
                                End If
                            Next
                        End If
                    Next
                Next

                Dim bases As New ArrayList
                bases.Add("personal")
                bases.Add("ta")
                bases.Add("nomina")
                bases.Add("herramientas")
                bases.Add("sermed")
                bases.Add("capacitacion")
                bases.Add("ideas")

                For Each base As String In bases
                    Dim dtReportes As DataTable = sqlExecute("select nombre from reportes where tipo <> 'U'", base)
                    For Each row As DataRow In dtReportes.Rows
                        Dim dr As DataRow = dtAccesos.NewRow
                        dr("perfil") = ""
                        dr("modulo") = base
                        dr("control") = RTrim(row("nombre"))
                        dr("nombre") = RTrim(row("nombre"))
                        dr("tipo") = "R"
                        dr("acceso") = "NO"
                        dtAccesos.Rows.Add(dr)
                    Next
                Next

                Dim dtAccesosPerfil As New DataTable
                dtAccesosPerfil.Columns.Add("perfil")
                dtAccesosPerfil.Columns.Add("modulo")
                dtAccesosPerfil.Columns.Add("nombre")
                dtAccesosPerfil.Columns.Add("tipo")
                dtAccesosPerfil.Columns.Add("acceso")

                Dim dtPermisos As DataTable = sqlExecute("select * from permisos", "seguridad")

                Dim dtPerfilesReporte As DataTable = sqlExecute("select cod_perfil, nombre from perfiles", "seguridad")
                For Each row_perfiles As DataRow In dtPerfilesReporte.Rows
                    For Each row_acceso As DataRow In dtAccesos.Rows

                        Dim dr As DataRow = dtAccesosPerfil.NewRow
                        dr("perfil") = row_perfiles("cod_perfil")
                        dr("modulo") = row_acceso("modulo")
                        'dr("control") = row_acceso("control")
                        dr("nombre") = row_acceso("nombre")
                        dr("tipo") = row_acceso("tipo")
                        dr("acceso") = row_acceso("acceso")

                        For Each row_permiso As DataRow In dtPermisos.Select("cod_perfil = '" & row_perfiles("cod_perfil") & "' and control = '" & row_acceso("control") & "' and acceso = 1")
                            dr("acceso") = "SI"
                        Next

                        dtAccesosPerfil.Rows.Add(dr)
                    Next
                Next




                ' *********************************************************************

                Dim hoja_accesos As ExcelWorksheet = wb.Worksheets.Add("Accesos")

                Dim x_accesos As Integer = 2
                Dim y_accesos As Integer = 1

                For Each column As DataColumn In dtAccesosPerfil.Columns
                    Dim nombre_columna As String = column.ColumnName.Replace("_", vbCrLf)
                    hoja_accesos.Cells(x_accesos, y_accesos).Style.Font.Bold = True
                    hoja_accesos.Cells(x_accesos, y_accesos).Value = StrConv(nombre_columna, VbStrConv.ProperCase)
                    hoja_accesos.Cells(x_accesos, y_accesos).Style.WrapText = True

                    y_accesos += 1
                Next

                x_accesos += 1
                y_accesos = 1

                For Each row As DataRow In dtAccesosPerfil.Select("acceso = 'SI'", "perfil, modulo, tipo, nombre")
                    For Each column As DataColumn In dtAccesosPerfil.Columns
                        hoja_accesos.Cells(x_accesos, y_accesos).Value = RTrim(IIf(IsDBNull(row(column.ColumnName)), "", row(column.ColumnName)))
                        y_accesos += 1
                    Next
                    y_accesos = 1
                    x_accesos += 1
                Next

                hoja_accesos.Cells(hoja_usuarios.Dimension.Address).AutoFitColumns()
                hoja_accesos.Cells(1, 1).Style.Font.Bold = True
                hoja_accesos.Cells(1, 1).Style.Font.Size = 24
                hoja_accesos.Cells(1, 1).Value = "Listado de accesos"

                '*********************************************************************


                archivo.SaveAs(New System.IO.FileInfo(nombre_archivo))

                MessageBox.Show("Archivo creado con éxito en:" & vbCrLf & nombre_archivo, "Archivo creado", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkFiltros_CheckedChanged(sender As Object, e As EventArgs) Handles chkFiltros.CheckedChanged
        pnlCriterio.Visible = chkFiltros.Checked
    End Sub

    Private Sub btnCriterio_CheckedChanged(sender As Object, e As EventArgs) Handles btnCriterio.CheckedChanged
        Try
            gpFiltro.Visible = True
            pnlCriterio.Visible = False
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub btnVerificar_Click(sender As Object, e As EventArgs) Handles btnVerificar.Click
        Try
            Dim dtResultado As New DataTable
            Dim Valido As Boolean

            dtResultado = sqlExecute("SELECT reloj FROM PERSONALVW" & IIf(txtCriterio.Text.Length > 0, " WHERE ", "") & txtCriterio.Text)
            Valido = Not (dtResultado Is Nothing)
            If Valido Then
                MessageBox.Show("El criterio es válido. Se " & IIf(dtResultado.Rows.Count = 1, "obtuvo 1 registro que cumple", "obtuvieron " & dtResultado.Rows.Count & " registros que cumplen") & " con esta condición.", "Criterio", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("El criterio no es válido. Favor de verificar.", "Criterio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cbCampos_SelectionChanged(sender As Object, e As DevComponents.AdvTree.AdvTreeNodeEventArgs) Handles cbCampos.SelectionChanged
        Dim x As Integer
        Dim Campo As String
        Try

            If cbCampos.SelectedIndex >= 0 Then
                dtTemp = sqlExecute("SELECT cod_campo FROM campos WHERE RTRIM(nombre) = '" & cbCampos.SelectedValue.ToString.Trim & "'")
                If dtTemp.Rows.Count > 0 Then
                    Campo = dtTemp.Rows(0).Item("cod_campo").ToString.Trim
                Else
                    lstFiltro.Items.Clear()
                    Exit Sub
                End If
            Else : lstFiltro.Items.Clear()
                Exit Sub
            End If

            'pnlCaracter.Visible = cbCampos.SelectedNode.NodesColumns.Item("tipo")

            'Si el campo es de tipo caracter
            dtValores = sqlExecute("SELECT DISTINCT " & Campo & " AS campo FROM PERSONALVW WHERE " & Campo & " <> ''  AND NOT " & Campo & " IS NULL")
            lstFiltro.Items.Clear()
            lstFiltro.Items.Add(" ")
            For x = 0 To dtValores.Rows.Count - 1
                lstFiltro.Items.Add(dtValores.Rows.Item(x).Item(0))
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cbCampos_TextChanged(sender As Object, e As EventArgs) Handles cbCampos.TextChanged

    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        Try
            Dim Resultado As New DataTable
            Dim R As String
            Dim c As Integer = 0
            Resultado = FiltrarDatos(txtFiltro.Text.Trim, False, cbCampos.SelectedValue)
            If Resultado Is Nothing Then Exit Sub
            lstFiltro.Items.Clear()
            For x = 0 To Resultado.Rows.Count - 1
                R = Resultado.Rows.Item(x).Item(0)
                If lstFiltro.FindString(R) < 0 Then
                    lstFiltro.Items.Add(Resultado.Rows.Item(x).Item(0))
                    lstFiltro.SetItemCheckState(c, True)
                    c = c + 1
                End If
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnAgregarCriterio_Click(sender As Object, e As EventArgs) Handles btnAgregarCriterio.Click
        Try
            Dim Campo As String = ""
            Dim FiltraValor As String

            If cbCampos.SelectedIndex >= 0 Then
                dtTemp = sqlExecute("SELECT cod_campo FROM campos WHERE RTRIM(nombre) = '" & cbCampos.SelectedValue.ToString.Trim & "'")
                If dtTemp.Rows.Count > 0 Then
                    Campo = dtTemp.Rows(0).Item("cod_campo").ToString.Trim
                Else
                    Campo = ""
                End If
            Else
                Campo = ""
            End If

            FiltraValor = ""


            For Each itm As DevComponents.DotNetBar.ListBoxItem In lstFiltro.CheckedItems
                FiltraValor = FiltraValor & IIf(FiltraValor.Length > 0, ",", "") & "'" & itm.Text & "'"
            Next
            FiltraValor = Campo & IIf(cbComparacion.Text = "<>", " NOT ", "") & " IN (" & FiltraValor & ")"

            txtCriterio.Text = txtCriterio.Text.Trim & IIf(txtCriterio.TextLength > 0, " AND ", "") & FiltraValor

            pnlCriterio.Visible = True
            gpFiltro.Visible = False
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCancelarCriterio_Click(sender As Object, e As EventArgs) Handles btnCancelarCriterio.Click
        Try
            pnlCriterio.Visible = True
            gpFiltro.Visible = False
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Function FiltrarDatos(Texto As String, Excepcion As Boolean, CampoBusqueda As String) As DataTable
        Dim x As Integer
        Dim Campo As String = ""
        Dim Valores() As String
        Valores = Split(Texto, ",")
        Dim FiltraValor As String = ""
        dtValores = New DataTable
        Try

            If CampoBusqueda.Length >= 0 Then
                dtTemp = sqlExecute("SELECT cod_campo FROM campos WHERE RTRIM(nombre) = '" & CampoBusqueda.Trim & "'")
                If dtTemp.Rows.Count > 0 Then
                    Campo = dtTemp.Rows(0).Item("cod_campo").ToString.Trim
                Else
                    lstFiltro.Items.Clear()
                End If
            Else
                lstFiltro.Items.Clear()
            End If

            If UBound(Valores) = 0 And Valores(0) = "" Then
                FiltraValor = Campo & " <> '' AND NOT " & Campo & " IS NULL"
            Else
                For x = 0 To UBound(Valores)
                    If Valores(x).Length = 0 Then
                        'Si el valor está en blanco, utilizar una cadena siempre verdadera para no obstruir la consulta
                        Valores(x) = "1=1"
                    ElseIf Not Valores(x).Contains("*") Then
                        'Si no se incluye el asterisco, agregarlo al final
                        Valores(x) = Valores(x) & "*"
                    End If
                    'Formar la cadena con los valores a filtrar
                    FiltraValor = FiltraValor & Campo & " LIKE ('" & Valores(x).Replace("*", "%") & "')"

                    If x < UBound(Valores) Then
                        'Si no es el último elemento del arreglo, agregar el OR
                        FiltraValor = FiltraValor & " OR "
                    End If
                Next
            End If

            If Excepcion Then
                FiltraValor = "NOT (" & FiltraValor & ")"
            End If

            dtValores = sqlExecute("SELECT DISTINCT " & Campo & " AS campo FROM PERSONALVW WHERE " & FiltraValor)

            Return dtValores
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
            Return New DataTable
        End Try

    End Function

    Private Sub btnCriterio_Click(sender As Object, e As EventArgs) Handles btnCriterio.Click
        Try
            gpFiltro.Visible = True
            pnlCriterio.Visible = False
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub frmUsuarios_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        pnlCentrado.Left = (Me.Width - pnlCentrado.Width) / 2
    End Sub

    Private Sub pnlDatos_Click(sender As Object, e As EventArgs) Handles pnlDatos.Click

    End Sub


    Private Sub btnCambiarClave_Click(sender As Object, e As EventArgs) Handles btnCambiarClave.Click
        'MCR 26/OCT/2015
        'Habilidad para cambiar clave de acceso a los usuarios

        Try
            Dim UsrTemp As String

            'La forma frmCambiarClave utiliza la variable USUARIO
            'Es necesario guardar el nombre de usuario actual en variable temporal, 
            'y regresarlo una vez que se cambia la clave
            UsrTemp = Usuario
            Usuario = txtUsuario.Text

            frmCambiarClave.ShowDialog(Me)
            Usuario = UsrTemp
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnRelacionar_Click(sender As Object, e As EventArgs) Handles btnRelacionar.Click
        Try
            Dim nombre As String = ""
            Dim dtUsuario As New DataTable
            Dim relojTmp As String = ""

            frmBuscar.ShowDialog(Me)
            relojTmp = Reloj
            dtUsuario = sqlExecute("SELECT NOMBRES FROM personalvw WHERE reloj ='" & relojTmp & "'", "PERSONAL")
            nombre = dtUsuario.AsEnumerable.First.Item(0)

            txtNotas.Text = nombre
            txtReloj.Text = relojTmp

        Catch ex As Exception

            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub
End Class