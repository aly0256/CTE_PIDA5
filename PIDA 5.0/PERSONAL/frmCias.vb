
'Imports Microsoft.Office.Interop
Public Class frmCias

#Region "Declaraciones"
    Dim dtRegistro As New DataTable
    Dim dtTemp As New DataTable
    Dim CambioLogo As Boolean = False

    ' Variables para Cias
    Dim EditarCias As Boolean                   'Modificar registro?
    Dim AgregarCias As Boolean                  'Agregar nuevo?
    Dim CiasIdx As Integer                      'Indice actual
    Dim dtCias As New DataTable                 'Tabla de compañías


    ' Variables para modificaciones de sueldo
    Dim dtSueldo As New DataTable
    Dim CambiosSueldo(3, 0) As String           'Arreglo para guardar los cambios en el grid, y administrarlos en el botón de guardar
    Dim EditarSueldo As Boolean                 'Modificar registro?
    Dim AgregarSueldo As Boolean                'Agregar nuevo?
    Dim SueldoAnt As String                     'Código anterior

    ' Variables para Vacaciones
    Dim dtVacaciones As New DataTable
    Dim CambiosVacaciones(6, 0) As String         'Arreglo para guardar los cambios en el grid, y administrarlos en el botón de guardar
    Dim EditarVacaciones As Boolean               'Modificar registro?
    Dim AgregarVacaciones As Boolean              'Agregar nuevo?
    Dim VacacionesAnt As String                   'Código anterior

    'Variables para Documentos Word
    Dim dtDocumentos As New DataTable
    Dim EditarDocs As Boolean

    'Variables para TA
    Dim dtAusentismo As New DataTable
    Dim dtCiasTA As New DataTable

    Dim dtValores As New DataTable
    Dim dtCampos As New DataTable

    'Variables para nómina
    Dim dtMetodoPago As New DataTable
    Dim dtPeriodosI As New DataTable
    Dim dtPeriodosF As New DataTable
    Dim dtPeriodosP As New DataTable

#End Region

#Region "Companias"

    Private Sub btnCiasEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCiasEditar.Click
        Try

            If AgregarCias Then
                EditarCias = True
            End If
            AgregarCias = False
            EditarCias = Not EditarCias
            MostrarCias()

            If EditarCias Then
                txtNombre.Focus()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCiasNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Try
            If AgregarCias Then
                ' Si AgregarCias, entonces guardar registro nuevo
                If txtCia.TextLength = 0 Then
                    MessageBox.Show("El código de la compañía no puede quedar en blanco. Favor de verificar.", "Compañía en blanco", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtCia.Focus()
                    Exit Sub
                End If

                If txtNombre.TextLength = 0 Then
                    MessageBox.Show("El nombre de la compañía no puede quedar en blanco. Favor de verificar.", "Compañía en blanco", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtNombre.Focus()
                    Exit Sub
                End If

                Compania = txtCia.Text
                dtTemp = sqlExecute("INSERT INTO cias (cod_comp,nombre) VALUES ('" & txtCia.Text & "','" & txtNombre.Text & "')")
                dtTemp = sqlExecute("INSERT INTO cias_ta (cod_comp) VALUES ('" & txtCia.Text & "')", "TA")
                AgregarCias = False
            ElseIf EditarCias Then
                ' Si EditarCias, entonces guardar cambios a registro
                dtTemp = sqlExecute("UPDATE cias SET nombre = '" & txtNombre.Text & "' WHERE cod_comp = '" & txtCia.Text & "'")
            Else
                AgregarCias = True
            End If
            EditarCias = False

            If Not AgregarCias And Not EditarCias Then
                sqlExecute("UPDATE cias SET giro = '" & txtGiro.Text & "' WHERE cod_comp = '" & txtCia.Text & "'")
                sqlExecute("UPDATE cias SET direccion = '" & txtDireccion.Text & "' WHERE cod_comp = '" & txtCia.Text & "'")
                sqlExecute("UPDATE cias SET colonia = '" & txtColonia.Text & "' WHERE cod_comp = '" & txtCia.Text & "'")
                sqlExecute("UPDATE cias SET ciudad = '" & txtCiudad.Text & "' WHERE cod_comp = '" & txtCia.Text & "'")
                sqlExecute("UPDATE cias SET estado = '" & txtEstado.Text & "' WHERE cod_comp = '" & txtCia.Text & "'")
                sqlExecute("UPDATE cias SET cod_postal = '" & txtCP.Text & "' WHERE cod_comp = '" & txtCia.Text & "'")
                'mcr 18/NOV/2015
                sqlExecute("UPDATE cias SET editable = " & IIf(btnEditable.Value, 1, 0) & " WHERE cod_comp = '" & txtCia.Text & "'")
                '****************
                sqlExecute("UPDATE cias SET rep_legal = '" & txtRepresentante.Text & "' WHERE cod_comp = '" & txtCia.Text & "'")
                sqlExecute("UPDATE cias SET puesto = '" & txtPuestoRep.Text & "' WHERE cod_comp = '" & txtCia.Text & "'")
                sqlExecute("UPDATE cias SET telefono1 = '" & txtTel1.Text & "' WHERE cod_comp = '" & txtCia.Text & "'")
                sqlExecute("UPDATE cias SET telefono2 = '" & txtTel2.Text & "' WHERE cod_comp = '" & txtCia.Text & "'")
                sqlExecute("UPDATE cias SET telefono3 = '" & txtTel3.Text & "' WHERE cod_comp = '" & txtCia.Text & "'")
                sqlExecute("UPDATE cias SET fax = '" & txtFax.Text & "' WHERE cod_comp = '" & txtCia.Text & "'")
                sqlExecute("UPDATE cias SET reg_pat = '" & txtRegistroPatronal.Text & "' WHERE cod_comp = '" & txtCia.Text & "'")
                sqlExecute("UPDATE cias SET rfc = '" & txtRFC.Text & "' WHERE cod_comp = '" & txtCia.Text & "'")
                sqlExecute("UPDATE cias SET infonavit = '" & txtInfonavit.Text & "' WHERE cod_comp = '" & txtCia.Text & "'")
                sqlExecute("UPDATE cias SET fonacot = '" & txtFonacot.Text & "' WHERE cod_comp = '" & txtCia.Text & "'")
                sqlExecute("UPDATE cias SET minimo_df = '" & txtMinimoDF.Text & "' WHERE cod_comp = '" & txtCia.Text & "'")
                sqlExecute("UPDATE cias SET minimo = '" & txtMinimoLocal.Text & "' WHERE cod_comp = '" & txtCia.Text & "'")
                sqlExecute("UPDATE cias SET guia = '" & txtGuia.Text & "' WHERE cod_comp = '" & txtCia.Text & "'")
                sqlExecute("UPDATE cias_ta SET retardo = '" & txtRetardo.Text & "' WHERE cod_comp = '" & txtCia.Text & "'", "TA")
                sqlExecute("UPDATE cias_ta SET festivo_sep = " & IIf(chkSeparar.Checked, 1, 0) & " WHERE cod_comp = '" & txtCia.Text & "'", "TA")
                sqlExecute("UPDATE cias_ta SET FESTIVO_A_DESCANSO = " & IIf(chkDescanso.Checked, 1, 0) & " WHERE cod_comp = '" & txtCia.Text & "'", "TA")
                sqlExecute("UPDATE cias_ta SET Autorizar_Extra = " & IIf(btnAutorizarExtra.Value, 1, 0) & " WHERE cod_comp = '" & txtCia.Text & "'", "TA")
                sqlExecute("UPDATE cias_ta SET Filtro_Extra = '" & IIf(chkTodos.Checked, "", txtCriterio.Text.Trim.Replace("'", "''")) & "' WHERE cod_comp = '" & txtCia.Text & "'", "TA")
                sqlExecute("UPDATE cias_ta SET Filtro_tiempo_completo = '" & _
                           IIf(chkTodosCompleto.Checked, "TODOS", _
                                    IIf(chkNingunoCompleto.Checked, "NINGUNO", _
                                        txtCriterioCompleto.Text.Trim.Replace("'", "''"))) & "' WHERE cod_comp = '" & txtCia.Text & "'", "TA")


                If CambioLogo Then
                    Dim imgConnection As New SqlClient.SqlConnection(SQLConn & ";Initial Catalog='Personal';Persist Security Info=True; User ID=sa; Password=" & sPassword & ";")
                    Dim imgCommand As New SqlClient.SqlCommand("UPDATE cias SET LOGO = @Picture WHERE cod_comp = '" & txtCia.Text & "'", imgConnection)
                    'Create an Image object.
                    Using picture As Image = imgLogo.Image
                        'Create an empty stream in memory.
                        Using stream As New IO.MemoryStream
                            'Fill the stream with the binary data from the Image.
                            picture.Save(stream, Imaging.ImageFormat.Png)

                            'Get an array of Bytes from the stream and assign to the parameter.
                            imgCommand.Parameters.Add("@Picture", SqlDbType.VarBinary).Value = stream.GetBuffer()
                        End Using
                    End Using
                    imgConnection.Open()
                    imgCommand.ExecuteNonQuery()
                    imgConnection.Close()
                End If

                dtCias = sqlExecute("SELECT * FROM cias WHERE cod_comp = '" & txtCia.Text & "'")
                MostrarCias()
            End If
            HabilitarCias()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.hResult, ex.Message)
        End Try

    End Sub
    Public Sub btnCiasBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCiasBuscar.Click
        Try
            Dim Cod As String
            'Dim x As Integer
            Cod = Buscar("cias", "cod_comp", "COMPAÑIAS", False)
            If Cod <> "CANCELAR" Then
                'x = dtCias.DefaultView.Find(Cod)

                ' If x >= 0 Then
                dtCias = sqlExecute("SELECT * FROM cias WHERE cod_comp = '" & Compania & "'")
                MostrarCias()
                'End If

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub HabilitarCias()
        Try
            Dim NoRec As Boolean
            NoRec = dtCias.Rows.Count = 0

            btnCiasPrev.Enabled = Not (AgregarCias Or EditarCias Or NoRec)
            btnCiasFirst.Enabled = Not (AgregarCias Or EditarCias Or NoRec)
            btnCiasNext.Enabled = Not (AgregarCias Or EditarCias Or NoRec)
            btnCiasLast.Enabled = Not (AgregarCias Or EditarCias Or NoRec)
            btnCiasBuscar.Enabled = Not (AgregarCias Or EditarCias Or NoRec)

            btnCiasBorrar.Enabled = Not (AgregarCias Or EditarCias Or NoRec)
            btnCiasCerrar.Enabled = Not (AgregarCias Or EditarCias Or NoRec)
            btnReporteCias.Enabled = Not (AgregarCias Or EditarCias Or NoRec)

            If AgregarCias Or EditarCias Then
                ' Si está activa la edición o nuevo registro
                btnNuevo.Image = PIDA.My.Resources.Ok16
                btnNuevo.Text = "Aceptar"
                btnCiasEditar.Image = PIDA.My.Resources.CancelX
                btnCiasEditar.Text = "Cancelar"
            Else

                btnNuevo.Image = PIDA.My.Resources.NewRecord
                btnNuevo.Text = "Agregar"
                btnCiasEditar.Image = PIDA.My.Resources.Edit
                btnCiasEditar.Text = "Editar"
            End If

            'pnlGeneral.Enabled = AgregarCias Or EditarCias
            'pnlRegistros.Enabled = AgregarCias Or EditarCias
            'pnlDirecciones.Enabled = AgregarCias Or EditarCias
            'pnlTA.Enabled = AgregarCias Or EditarCias

            'Información general
            For Each Ctr In tbInfo.Controls
                If TypeOf Ctr Is DevComponents.DotNetBar.SuperTabControlPanel Then
                    For Each Control In Ctr.controls
                        If TypeOf Control Is DevComponents.DotNetBar.Controls.SwitchButton Then
                            Control.isreadonly = Not (AgregarCias Or EditarCias)
                        ElseIf TypeOf Control Is DevComponents.DotNetBar.Controls.ComboBoxEx Or _
                            TypeOf Control Is DevComponents.DotNetBar.ButtonX Or _
                            TypeOf Control Is DevComponents.DotNetBar.Controls.CheckBoxX Or _
                            TypeOf Control Is DevComponents.DotNetBar.Controls.ComboTree Or _
                            TypeOf Control Is DevComponents.Editors.IntegerInput Then
                            Control.Enabled = AgregarCias Or EditarCias
                        ElseIf TypeOf Control Is DevComponents.DotNetBar.Controls.DataGridViewX Then
                            Control.ReadOnly = Not (AgregarCias Or EditarCias)
                        ElseIf TypeOf Control Is DevComponents.DotNetBar.Controls.TextBoxX Then
                            Control.ReadOnly = Not (AgregarCias Or EditarCias)
                            Control.BackColor = IIf(Control.ReadOnly, SystemColors.Control, SystemColors.Window)
                        ElseIf TypeOf Control Is System.Windows.Forms.RadioButton Or _
                            TypeOf Control Is System.Windows.Forms.GroupBox Or TypeOf Control Is System.Windows.Forms.Panel Then
                            Control.Enabled = (AgregarCias Or EditarCias)
                        End If
                    Next
                End If
            Next
            txtCia.ReadOnly = Not AgregarCias
            txtNombre.ReadOnly = Not (AgregarCias Or EditarCias)

            If AgregarCias Then
                txtCia.Text = ""
                txtNombre.Text = ""
                txtCia.Focus()
            End If

            If EditarCias Then
                txtNombre.Focus()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub frmCias_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
    Private Sub frmCias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            RevisarAccesos()

            'dtCias = sqlExecute("SELECT TOP 1 * FROM cias WHERE cia_default = 1")
            dtCias = sqlExecute("SELECT * FROM cias", "personal")
            dtCias.DefaultView.Sort = "cod_comp"

            dtPeriodosI = sqlExecute("SELECT ano+periodo as 'unico',ano,periodo,fecha_ini,fecha_fin FROM periodos ORDER BY ano DESC,periodo ASC", "TA")
            dtPeriodosF = dtPeriodosI.Copy
            dtPeriodosP = dtPeriodosI.Copy

            MostrarCias()
            ReDim CambiosSueldo(3, 5)

            HabilitarCias()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub RevisarAccesos()
        Dim Acceso As Boolean
        Dim i As Integer
        Try
            'Revisar cada control dentro del panel
            i = 0
            For Each c In tbInfo.Tabs
                'Si se tiene acceso a alguno de los subitems, o no tiene subitems, revisar acceso del botón
                dtTemp = sqlExecute("SELECT acceso FROM permisos WHERE tipo = 'T' AND control = '" & c.name & "' AND cod_perfil " & perfil , "Seguridad")
                Acceso = False
                If dtTemp.Rows.Count > 0 Then
                    Acceso = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("acceso")), False, dtTemp.Rows.Item(0).Item("acceso") = 1)
                End If
                c.visible = Acceso
                If Acceso Then i = i + 1
            Next
            tbInfo.Visible = i > 0
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub UbicacionArchivo(ByRef Desc As String, ByVal txtBox As Object)
        Try
            Dim FBD As New FolderBrowserDialog
            FBD.Description = Desc
            FBD.ShowNewFolderButton = True      'OR FALSE
            FBD.SelectedPath = txtBox.Text
            If FBD.ShowDialog() = DialogResult.OK Then
                txtBox.Text = FBD.SelectedPath
            End If
            FBD = Nothing
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogo.Click
        'dbArchivos.Title = "Ubicación de logotipo"
        'dbArchivos.FileName = txtLogo.Text
        'If dbArchivos.ShowDialog <> DialogResult.Cancel Then
        '    txtLogo.Text = dbArchivos.FileName
        'End If
        Try
            dbArchivos.FileName = ""
            dbArchivos.Filter = "PNG files (*.png)|*.png|Bitmap files (*.bmp)|*.bmp|JPEG files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif|All files (*.*)|*.*"
            If dbArchivos.ShowDialog <> DialogResult.Cancel Then
                Dim Archivo As String
                Archivo = dbArchivos.FileName
                imgLogo.Image = Image.FromFile(Archivo)
                imgLogo.Refresh()
                CambioLogo = True
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
            CambioLogo = False
        End Try
    End Sub

    Public Sub MostrarCias()
        Try
            Dim FiltroCompleto As String

            Compania = IIf(IsDBNull(dtCias.Rows.Item(0).Item("cod_comp")), "", dtCias.Rows.Item(0).Item("cod_comp")).ToString.Trim
            txtCia.Text = IIf(IsDBNull(dtCias.Rows.Item(0).Item("cod_comp")), "", dtCias.Rows.Item(0).Item("cod_comp")).ToString.Trim
            txtNombre.Text = IIf(IsDBNull(dtCias.Rows.Item(0).Item("nombre")), "", dtCias.Rows.Item(0).Item("nombre")).ToString.Trim
            txtGiro.Text = IIf(IsDBNull(dtCias.Rows.Item(0).Item("giro")), "", dtCias.Rows.Item(0).Item("giro")).ToString.Trim
            txtDireccion.Text = IIf(IsDBNull(dtCias.Rows.Item(0).Item("direccion")), "", dtCias.Rows.Item(0).Item("direccion")).ToString.Trim
            txtColonia.Text = IIf(IsDBNull(dtCias.Rows.Item(0).Item("colonia")), "", dtCias.Rows.Item(0).Item("colonia")).ToString.Trim
            txtEstado.Text = IIf(IsDBNull(dtCias.Rows.Item(0).Item("estado")), "", dtCias.Rows.Item(0).Item("estado")).ToString.Trim
            txtCiudad.Text = IIf(IsDBNull(dtCias.Rows.Item(0).Item("ciudad")), "", dtCias.Rows.Item(0).Item("ciudad")).ToString.Trim
            txtCP.Text = IIf(IsDBNull(dtCias.Rows.Item(0).Item("cod_postal")), "", dtCias.Rows.Item(0).Item("cod_postal")).ToString.Trim
            'MCR 18/NOV/2015
            btnEditable.Value = IIf(IsDBNull(dtCias.Rows.Item(0).Item("editable")), 1, dtCias.Rows.Item(0).Item("editable")) = 1

            txtTel1.Text = IIf(IsDBNull(dtCias.Rows.Item(0).Item("telefono1")), "", dtCias.Rows.Item(0).Item("telefono1")).ToString.Trim
            txtTel2.Text = IIf(IsDBNull(dtCias.Rows.Item(0).Item("telefono2")), "", dtCias.Rows.Item(0).Item("telefono2")).ToString.Trim
            txtTel3.Text = IIf(IsDBNull(dtCias.Rows.Item(0).Item("telefono3")), "", dtCias.Rows.Item(0).Item("telefono3")).ToString.Trim
            txtFax.Text = IIf(IsDBNull(dtCias.Rows.Item(0).Item("fax")), "", dtCias.Rows.Item(0).Item("fax")).ToString.Trim
            txtRepresentante.Text = IIf(IsDBNull(dtCias.Rows.Item(0).Item("rep_legal")), "", dtCias.Rows.Item(0).Item("rep_legal")).ToString.Trim
            txtPuestoRep.Text = IIf(IsDBNull(dtCias.Rows.Item(0).Item("puesto")), "", dtCias.Rows.Item(0).Item("puesto")).ToString.Trim
            txtRegistroPatronal.Text = IIf(IsDBNull(dtCias.Rows.Item(0).Item("reg_pat")), "", dtCias.Rows.Item(0).Item("reg_pat")).ToString.Trim
            txtInfonavit.Text = IIf(IsDBNull(dtCias.Rows.Item(0).Item("infonavit")), "", dtCias.Rows.Item(0).Item("infonavit")).ToString.Trim
            txtRFC.Text = IIf(IsDBNull(dtCias.Rows.Item(0).Item("rfc")), "", dtCias.Rows.Item(0).Item("rfc")).ToString.Trim
            txtFonacot.Text = IIf(IsDBNull(dtCias.Rows.Item(0).Item("fonacot")), "", dtCias.Rows.Item(0).Item("fonacot")).ToString.Trim
            txtMinimoDF.Text = IIf(IsDBNull(dtCias.Rows.Item(0).Item("minimo_df")), 0, dtCias.Rows.Item(0).Item("minimo_df"))
            txtMinimoLocal.Text = IIf(IsDBNull(dtCias.Rows.Item(0).Item("minimo_df")), 0, dtCias.Rows.Item(0).Item("minimo"))
            txtGuia.Text = IIf(IsDBNull(dtCias.Rows.Item(0).Item("guia")), "", dtCias.Rows.Item(0).Item("guia"))

            If Not IsDBNull(dtCias.Rows(0).Item("logo")) Then
                Dim imageInBytes As Byte() = dtCias.Rows(0).Item("logo")
                Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream(imageInBytes, False)
                Dim image As System.Drawing.Image = System.Drawing.Image.FromStream(memoryStream)
                imgLogo.Image = image
            Else
                imgLogo.Image = imgLogo.ErrorImage
            End If

            dtCiasTA = sqlExecute("SELECT * FROM cias_ta WHERE cias_ta.cod_comp = '" & Compania & "'", "TA")


            If dtCiasTA.Rows.Count = 0 Then
                sqlExecute("INSERT INTO cias_ta (cod_comp) VALUES ('" & Compania & "')", "TA")
                dtCiasTA = sqlExecute("SELECT * FROM cias_ta WHERE cias_ta.cod_comp = '" & Compania & "'", "TA")

            End If
            txtRetardo.Text = IIf(IsDBNull(dtCiasTA.Rows.Item(CiasIdx).Item("retardo")), "00:00", dtCiasTA.Rows.Item(0).Item("retardo"))
            chkSeparar.Checked = IIf(IsDBNull(dtCiasTA.Rows.Item(CiasIdx).Item("festivo_sep")), 0, dtCiasTA.Rows.Item(0).Item("festivo_sep")) = 1
            chkDescanso.Checked = IIf(IsDBNull(dtCiasTA.Rows.Item(CiasIdx).Item("FESTIVO_A_DESCANSO")), 0, dtCiasTA.Rows.Item(0).Item("FESTIVO_A_DESCANSO")) = 1

            btnAutorizarExtra.Value = IIf(IsDBNull(dtCiasTA.Rows.Item(CiasIdx).Item("Autorizar_Extra")), 0, dtCiasTA.Rows.Item(0).Item("Autorizar_Extra")) = 1
            txtCriterio.Text = IIf(IsDBNull(dtCiasTA.Rows.Item(CiasIdx).Item("Filtro_Extra")), "", dtCiasTA.Rows.Item(0).Item("Filtro_Extra"))
            chkTodos.Checked = IIf(IsDBNull(dtCiasTA.Rows.Item(CiasIdx).Item("Filtro_Extra")), "", dtCiasTA.Rows.Item(0).Item("Filtro_Extra")) = ""
            chkFiltros.Checked = Not chkTodos.Checked

            FiltroCompleto = IIf(IsDBNull(dtCiasTA.Rows.Item(CiasIdx).Item("Filtro_tiempo_completo")), "NINGUNO", dtCiasTA.Rows.Item(0).Item("Filtro_tiempo_completo"))

            txtCriterioCompleto.Text = IIf(FiltroCompleto = "TODOS" Or FiltroCompleto = "NINGUNO", "", FiltroCompleto)
            chkNingunoCompleto.Checked = FiltroCompleto = "NINGUNO"
            chkTodosCompleto.Checked = FiltroCompleto = "TODOS"
            chkFiltrosCompleto.Checked = Not chkTodosCompleto.Checked And Not chkNingunoCompleto.Checked

            gpFiltro.Location = chkTodos.Location
            gpFiltro.Visible = False

            gpFiltroCompleto.Location = chkTodosCompleto.Location
            gpFiltroCompleto.Visible = False

            dtCampos = sqlExecute("SELECT UPPER(nombre) AS 'NOMBRE' FROM campos WHERE tipo='char' ORDER BY nombre")
            cbCampos.DataSource = dtCampos
            cbCamposCompleto.DataSource = dtCampos.Copy

            cbComparacion.SelectedValue = "="
            cbComparacionCompleto.SelectedValue = "="

            HabilitarCias()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnCiasFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCiasFirst.Click
        Primero("cias", "cod_comp", dtCias)
        MostrarCias()
    End Sub

    Private Sub btnCiasPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCiasPrev.Click
        Anterior("cias", "cod_comp", Compania, dtCias)
        MostrarCias()
    End Sub

    Private Sub btnCiasNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCiasNext.Click
        Siguiente("cias", "cod_comp", Compania, dtCias)
        MostrarCias()
    End Sub

    Private Sub btnCiasLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCiasLast.Click
        Ultimo("cias", "cod_comp", dtCias)
        MostrarCias()
    End Sub

    Private Sub btnCiasCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnCiasCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCiasCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub
#End Region

    Private Sub btnCiasBorrar_Click(sender As Object, e As EventArgs) Handles btnCiasBorrar.Click
        Dim x As Integer
        Dim y As Integer
        Dim i As Integer = 0
        Dim C As String = ""
        Dim dtRec As New DataTable
        Dim Recs As Boolean = False
        ' Dim BD() As String = {"Personal", "Seguridad", "TA", "Nomina"}
        Dim BD() As String
        Dim Tablas(,) As String
        Dim Respuesta As Windows.Forms.DialogResult

        Try
            dtTemp = sqlExecute("SELECT name FROM master.dbo.sysdatabases WHERE name not in ('master','tempdb','model','msdb')")
            If dtTemp.Rows.Count > 0 Then
                ReDim BD(dtTemp.Rows.Count - 1)
            Else
                MessageBox.Show("Error al conectar a base de datos. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            For x = 0 To dtTemp.Rows.Count - 1
                BD(x) = dtTemp.Rows(x).Item("name")
            Next

            ReDim Tablas(2, 10)
            dtTemp = sqlExecute("SELECT cod_comp FROM PERSONALVW WHERE cod_comp = '" & Compania & "'")
            If dtTemp.Rows.Count > 0 Then
                MessageBox.Show("El registro no puede ser eliminado, porque ya se encuentra asignado a personalvw.", "Borrar compañía", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                'REVISAR LAS BASES DE DATOS
                For y = 0 To UBound(BD)
                    dtTemp = sqlExecute("SELECT table_name,table_catalog FROM information_schema.columns WHERE column_name='COD_COMP' AND table_name NOT IN ('CIAS','CIAS_TA','PERSONAL') ORDER  BY ordinal_position", BD(y))
                    'REVISAR TODAS LAS TABLAS DONDE SE UTILIZA LA COMPAÑIA, A VER SI NO ESTA ASIGNADO
                    For x = 0 To dtTemp.Rows.Count - 1
                        C = dtTemp.Rows.Item(x).Item("table_name").ToString.ToUpper

                        dtRec = sqlExecute("SELECT cod_comp FROM " & C & " WHERE cod_comp = '" & Compania & "'", BD(y))
                        If dtRec.Rows.Count > 0 Then

                            If UBound(Tablas, 2) < i Then
                                ReDim Preserve Tablas(2, i + 1)
                            End If
                            Tablas(0, i) = BD(y)
                            Tablas(1, i) = C
                            Tablas(2, i) = dtRec.Rows.Count
                            i = i + 1
                        End If
                    Next
                Next

                Respuesta = Windows.Forms.DialogResult.Cancel
                If i > 0 Then
                    C = "Se localizó la compañía en " & i & " tablas del catálogo. ¿Desea eliminar también estos registros?" & vbCrLf & vbCrLf
                    For x = 0 To i - 1
                        C = C & " * " & Tablas(0, x) & "." & Tablas(1, x) & " (" & Tablas(2, x) & " registros)" & vbCrLf
                    Next

                    Respuesta = MessageBox.Show(C, "Borrar compañía", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                    If Respuesta = Windows.Forms.DialogResult.Yes Then
                        For x = 0 To i - 1
                            dtTemp = sqlExecute("DELETE FROM " & Tablas(1, x) & " WHERE cod_comp ='" & Compania & "'", Tablas(0, x))
                        Next
                    End If
                Else
                    Respuesta = MessageBox.Show("¿Está seguro de borrar la compañía " & Compania.ToUpper & "?", "Borrar compañía", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                End If

                If Respuesta = Windows.Forms.DialogResult.Yes Then
                    dtTemp = sqlExecute("DELETE FROM cias WHERE cod_comp = '" & Compania & "'")
                    btnciasNext.PerformClick()
                End If
            End If



        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.hResult, ex.Message)
        End Try
    End Sub

    Private Sub txtCia_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCia.Validating
        Try
            If AgregarCias And txtCia.Text <> "" Then
                dtTemp = sqlExecute("SELECT cod_comp FROM cias WHERE cod_comp = '" & txtCia.Text & "'")
                If dtTemp.Rows.Count > 0 Then
                    MessageBox.Show("El código de compañía " & txtCia.Text & " ya se encuentra registrado. Favor de verificar.", "Compañía duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnReporteCias_Click(sender As Object, e As EventArgs) Handles btnReporteCias.Click
        Try
            Dim dtDatos As New DataTable
            dtDatos = sqlExecute("SELECT * FROM cias WHERE cod_comp = '" & txtCia.Text & "'")
            frmVistaPrevia.LlamarReporte("Compañías", dtDatos, txtCia.Text)
            frmVistaPrevia.ShowDialog()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodos.CheckedChanged
        Try
            pnlCriterio.Enabled = chkFiltros.Checked
            pnlCriterio.Visible = True
            gpFiltro.Visible = False
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkFiltros_CheckedChanged(sender As Object, e As EventArgs) Handles chkFiltros.CheckedChanged
        Try
            pnlCriterio.Enabled = chkFiltros.Checked
            gpFiltro.Visible = False

            If chkFiltros.Checked Then
                pnlCriterio.Visible = True
                txtCriterio.Focus()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCriterio_Click(sender As Object, e As EventArgs) Handles btnCriterio.Click
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

    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles btnCancelarCriterio.Click
        Try
            pnlCriterio.Visible = True
            gpFiltro.Visible = False
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkTodosCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkTodosCompleto.CheckedChanged
        'Try
        '    pnlCriterioCompleto.Enabled = chkFiltrosCompleto.Checked
        '    pnlCriterioCompleto.Visible = True
        '    gpFiltroCompleto.Visible = False
        'Catch ex As Exception
        '    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        'End Try
    End Sub

    Private Sub chkFiltrosCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkFiltrosCompleto.CheckedChanged
        Try
            pnlCriterioCompleto.Enabled = chkFiltrosCompleto.Checked
            gpFiltroCompleto.Visible = False
            pnlCriterioCompleto.Visible = chkFiltrosCompleto.Checked

            If chkFiltrosCompleto.Checked Then
                txtCriterioCompleto.Focus()
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCriterioCompleto_Click(sender As Object, e As EventArgs) Handles btnCriterioCompleto.Click
        gpFiltroCompleto.Visible = True
        pnlCriterioCompleto.Visible = False
    End Sub

    Private Sub btnVerificarCompleto_Click(sender As Object, e As EventArgs) Handles btnVerificarCompleto.Click
        Try
            Dim dtResultado As New DataTable
            Dim Valido As Boolean

            dtResultado = sqlExecute("SELECT reloj FROM PERSONALVW" & IIf(txtCriterioCompleto.Text.Length > 0, " WHERE ", "") & txtCriterioCompleto.Text)
            Valido = Not (dtResultado Is Nothing Or dtResultado.Columns(0).ColumnName = "ERROR")
            If Valido Then
                MessageBox.Show("El criterio es válido. Se " & IIf(dtResultado.Rows.Count = 1, "obtuvo 1 registro que cumple", "obtuvieron " & dtResultado.Rows.Count & " registros que cumplen") & " con esta condición.", "Criterio", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("El criterio no es válido. Favor de verificar.", "Criterio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cbCamposCompleto_SelectionChanged(sender As Object, e As DevComponents.AdvTree.AdvTreeNodeEventArgs) Handles cbCamposCompleto.SelectionChanged
        Try
            Dim Campo As String

            If cbCamposCompleto.SelectedIndex >= 0 Then
                dtTemp = sqlExecute("SELECT cod_campo FROM campos WHERE RTRIM(nombre) = '" & cbCamposCompleto.SelectedValue.ToString.Trim & "'")
                If dtTemp.Rows.Count > 0 Then
                    Campo = dtTemp.Rows(0).Item("cod_campo").ToString.Trim
                Else
                    lstFiltroCompleto.DataSource = Nothing
                    Exit Sub
                End If
            Else
                lstFiltroCompleto.DataSource = Nothing
                Exit Sub
            End If

            'Si el campo es de tipo caracter
            dtValores = sqlExecute("SELECT DISTINCT " & Campo & " AS CAMPO FROM PERSONALVW WHERE " & Campo & " <> ''  AND NOT " & Campo & " IS NULL")
            lstFiltroCompleto.DataSource = dtValores
            lstFiltroCompleto.DisplayMember = "campo"
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnAgregarCriterioCompleto_Click(sender As Object, e As EventArgs) Handles btnAgregarCriterioCompleto.Click
        Try
            Dim Campo As String = ""
            Dim FiltraValor As String

            If cbCamposCompleto.SelectedIndex >= 0 Then
                dtTemp = sqlExecute("SELECT cod_campo FROM campos WHERE RTRIM(nombre) = '" & cbCamposCompleto.SelectedValue.ToString.Trim & "'")
                If dtTemp.Rows.Count > 0 Then
                    Campo = dtTemp.Rows(0).Item("cod_campo").ToString.Trim
                Else
                    Campo = ""
                End If
            Else
                Campo = ""
            End If

            FiltraValor = ""


            For Each itm As DevComponents.DotNetBar.ListBoxItem In lstFiltroCompleto.CheckedItems
                FiltraValor = FiltraValor & IIf(FiltraValor.Length > 0, ",", "") & "'" & itm.Text & "'"
            Next
            FiltraValor = Campo & IIf(cbComparacionCompleto.Text = "<>", " NOT ", "") & " IN (" & FiltraValor & ")"

            txtCriterioCompleto.Text = txtCriterioCompleto.Text.Trim & IIf(txtCriterioCompleto.TextLength > 0, " AND ", "") & FiltraValor

            pnlCriterioCompleto.Visible = True
            gpFiltroCompleto.Visible = False
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCancelarCriterioCompleto_Click(sender As Object, e As EventArgs) Handles btnCancelarCriterioCompleto.Click
        pnlCriterioCompleto.Visible = True
        gpFiltroCompleto.Visible = False
    End Sub

    Private Sub txtFiltroCompleto_TextChanged(sender As Object, e As EventArgs) Handles txtFiltroCompleto.TextChanged
        Try
            Dim Resultado As New DataTable
            Dim c As Integer = 0
            Resultado = FiltrarDatos(txtFiltroCompleto.Text.Trim, False, cbCamposCompleto.SelectedValue)
            If Resultado Is Nothing Then Exit Sub
            lstFiltroCompleto.DataSource = Resultado
            'For c = 0 To lstFiltroCompleto.Items.Count - 1
            '    lstFiltroCompleto.SetItemCheckState(c, CheckState.Checked)
            'Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Declaraciones", ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cbCamposCompleto_TextChanged(sender As Object, e As EventArgs) Handles cbCamposCompleto.TextChanged

    End Sub

    Private Sub cbCampos_TextChanged(sender As Object, e As EventArgs) Handles cbCampos.TextChanged

    End Sub

    Private Sub cbComparacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbComparacion.SelectedIndexChanged

    End Sub

    Private Sub txtCia_TextChanged(sender As Object, e As EventArgs) Handles txtCia.TextChanged

    End Sub

    Private Sub frmCias_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        EmpNav.Left = (Me.Width - EmpNav.Width) / 2
    End Sub

    Private Sub txtNombre_TextChanged(sender As Object, e As EventArgs) Handles txtNombre.TextChanged

    End Sub
End Class