Imports System.Drawing.Drawing2D
Public Class frmMenuCafeteria


    Dim PathPlatillos As String = ""
    Dim PathFotoMenu As String = ""
    Dim ImgPlatilloTmp As String = ""
    '   Dim dtCias As New DataTable
    Dim dtTurnos As New DataTable
    Dim dtServicios As New DataTable
    Dim dtDias As New DataTable
    Dim dtmenus As New DataTable
    Dim dtmenusD As New DataTable
    Dim dtTemp As New DataTable
    Dim dtLista As New DataTable
    Dim dtdefa As New DataTable
    '    Dim AgregaPlatillo As New uscPlatillo()
    Dim Editar As Boolean
    Dim Agregar As Boolean
    Dim DesdeGrid As Boolean
    Dim CodHora As String ', CodComp As String

    Private Sub frmmenus_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        pctFotoMenu.SizeMode = PictureBoxSizeMode.StretchImage
        picDefault.SizeMode = PictureBoxSizeMode.StretchImage
        Agregar = False
        Editar = False

        dtServicios = sqlExecute("select SERVICIO from servicios", "CAFETERIA")
        cmbServicio.DisplayMember = "SERVICIO"
        cmbServicio.ValueMember = "SERVICIO"
        cmbServicio.DataSource = dtServicios

        Dim dtPathP As DataTable = sqlExecute("select top 1 path_fotos from parametros ", "cafeteria")
        If dtPathP.Rows.Count > 0 Then
            PathPlatillos = dtPathP.Rows(0).Item("path_fotos")
        Else
            PathPlatillos = ""
        End If

        'Dim AgregaPlatillo As New uscPlatillo()
        '  AddHandler AgregaPlatillo.btnAgregarQuitar.Click, AddressOf ElegirPlatillo
        '    flwPlatillos.Controls.Add(AgregaPlatillo)
        '    dtTurnos = sqlExecute("select cod_turno,nombre from turnos where cod_comp ='090'")
        'cmbTurno.DataSource = dtTurnos
        'dtCias = sqlExecute("SELECT cod_comp,nombre FROM cias")
        ' cmbCia.DataSource = dtCias


        dtLista = sqlExecute("SELECT cod_menu as 'Código',Nombre FROM menus where cod_menu not in ('DEFAD', 'DEFCO', 'DEFCE')", "cafeteria") 'cod_comp as 'Compañía',
        dtLista.DefaultView.Sort = "Código"
        dgTabla.DataSource = dtLista
        dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DesdeGrid = False
        dtmenus = sqlExecute("SELECT TOP 1 * FROM menus  where cod_menu not in ('DEFAD', 'DEFCO', 'DEFCE') ORDER BY cod_menu ASC", "cafeteria")
        If dtmenus.Rows.Count > 0 Then MostrarInformacion()
        dtmenusD = sqlExecute("SELECT TOP 1 * FROM menus  where cod_menu in ('DEFAD', 'DEFCO', 'DEFCE') ORDER BY cod_menu ASC", "cafeteria")
        If dtmenusD.Rows.Count > 0 Then MostrarInformacion()
        HabilitarBotones()


    End Sub

    Sub MostrarInformacion()
        Dim i As Integer
        Try
     
            ' CodComp = dtmenus.Rows.Item(0).Item("cod_comp")
            Dim a As Integer = tabBuscar.SelectedTabIndex
            If a = 2 Then
                CodHora = dtmenusD.Rows.Item(0).Item("cod_menu")
                txtcoddef.Text = dtmenusD.Rows.Item(0).Item("cod_menu")
                txtNombredef.Text = IIf(IsDBNull(dtmenusD.Rows.Item(0).Item("nombre")), "", dtmenusD.Rows.Item(0).Item("nombre")).ToString.Trim
                txtServiciodef.Text = IIf(IsDBNull(dtmenusD.Rows.Item(0).Item("servicio")), "", dtmenusD.Rows.Item(0).Item("servicio")).ToString.Trim
                txtdescdefa.Text = IIf(IsDBNull(dtmenusD.Rows.Item(0).Item("descripcion")), "", dtmenusD.Rows.Item(0).Item("descripcion")).ToString.Trim

                PathFotoMenu = PathPlatillos + txtcoddef.Text + ".jpg"
                If System.IO.File.Exists(PathFotoMenu) Then
                    Dim s As System.IO.FileStream = New System.IO.FileStream(PathFotoMenu, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                    ' MakeRoundedImage(Image.FromStream(s), picDefault)
                    picDefault.Image = Image.FromStream(s)
                    s.Close()
                Else
                    pctFotoMenu.Image = Nothing
                End If


            Else
                CodHora = dtmenus.Rows.Item(0).Item("cod_menu")

                txtCodigo.Text = CodHora
                txtNombre.Text = IIf(IsDBNull(dtmenus.Rows.Item(0).Item("nombre")), "", dtmenus.Rows.Item(0).Item("nombre")).ToString.Trim
                txtDescripcion.Text = IIf(IsDBNull(dtmenus.Rows.Item(0).Item("descripcion")), "", dtmenus.Rows.Item(0).Item("descripcion")).ToString.Trim
                cmbServicio.Text = IIf(IsDBNull(dtmenus.Rows.Item(0).Item("servicio")), "", dtmenus.Rows.Item(0).Item("servicio")).ToString.Trim

                PathFotoMenu = PathPlatillos + "m" + txtCodigo.Text + ".jpg"
                If System.IO.File.Exists(PathFotoMenu) Then
                    Dim s As System.IO.FileStream = New System.IO.FileStream(PathFotoMenu, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                    ' MakeRoundedImage(Image.FromStream(s), pctFotoMenu)
                    pctFotoMenu.Image = Image.FromStream(s)
                    s.Close()
                Else
                    pctFotoMenu.Image = Nothing
                End If



                'AgregarPlatillos()
                If Not DesdeGrid Then
                    i = dtLista.DefaultView.Find(txtCodigo.Text)
                    If i >= 0 Then
                        dgTabla.FirstDisplayedScrollingRowIndex = i
                        dgTabla.Rows(i).Selected = True
                    End If
                End If
                DesdeGrid = False
            End If

            
            'HabilitarBotones()

        Catch ex As Exception

            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Dim a As Integer = tabBuscar.SelectedTabIndex
        If a = 2 Then
            SiguienteD("menus", "cod_menu", CodHora, dtmenusD, "cafeteria")
            MostrarInformacion()
        Else
            SiguienteN("menus", "cod_menu", CodHora, dtmenus, "cafeteria")
            MostrarInformacion()
        End If

    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Dim a As Integer = tabBuscar.SelectedTabIndex
        If a = 2 Then
            UltimoD("menus", "cod_menu", dtmenusD, "cafeteria")
            MostrarInformacion()
        Else
            UltimoN("menus", "cod_menu", dtmenus, "cafeteria")
            MostrarInformacion()
        End If
       
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Dim a As Integer = tabBuscar.SelectedTabIndex
        If a = 2 Then
            PrimeroD("menus", "cod_menu", dtmenusD, "cafeteria")
            MostrarInformacion()
        Else
            PrimeroN("menus", "cod_menu", dtmenus, "cafeteria")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Dim a As Integer = tabBuscar.SelectedTabIndex
        If a = 2 Then
            AnteriorD("menus", "cod_menu", CodHora, dtmenusD, "cafeteria")
            MostrarInformacion()
        Else
            AnteriorN("menus", "cod_menu", CodHora, dtmenus, "cafeteria")
            MostrarInformacion()
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("cafeteria.dbo.menus", "cod_menu", "menus", False)
        If Cod <> "CANCELAR" Then
            dtmenus = sqlExecute("SELECT * from menus WHERE cod_menu = '" & Cod & "'", "cafeteria")
            MostrarInformacion()
        End If

    End Sub
    Private Sub HabilitarBotonesD()
        Dim NoRec As Boolean
        NoRec = dgTabla.Rows.Count = 0
        btnCambiarD.Enabled = Editar
        btnQuitarD.Enabled = Editar

        If Agregar Or Editar Then
            ' Si está activa la edición o nuevo registro
            btnNuevo.Visible = True
            btnNuevo.Image = PIDA.My.Resources.Ok16
            btnEditar.Image = PIDA.My.Resources.CancelX
            btnNuevo.Text = "Aceptar"
            btnEditar.Text = "Cancelar"
            tabBuscar.SelectedTabIndex = 2
        Else
            btnNuevo.Visible = False
            btnNuevo.Image = PIDA.My.Resources.NewRecord
            btnEditar.Image = PIDA.My.Resources.Edit
            btnEditar.Text = "Editar"
        End If

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

            txtCodigo.Enabled = Agregar
            ' cmbCia.Enabled = Agregar

            If Agregar Then
                txtCodigo.Text = ""
                txtNombre.Text = ""
                txtDescripcion.Text = ""

                txtCodigo.Focus()
            ElseIf Editar Then
                ' txtNombre.Focus()
            End If



    End Sub

    Private Sub dgTabla_DoubleClick(sender As Object, e As EventArgs) Handles dgTabla.DoubleClick
        Try
            tabBuscar.SelectedTabIndex = 0
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub dgTabla_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgTabla.RowEnter
        Try
            Dim cod As String ', nom As String

            DesdeGrid = True

            cod = dgTabla.Item("Código", e.RowIndex).Value
            'nom = dgTabla.Item("Compañía", e.RowIndex).Value
            dtmenus = sqlExecute("SELECT * from menus WHERE cod_menu = '" & cod & "'", "cafeteria")
            MostrarInformacion()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        '   Dim Comp As String
        Dim Hora As String
        Dim Cadena As String = ""
        Try

            Hora = txtCodigo.Text
            '  Comp = cmbCia.SelectedValue

            If Agregar Then
                ' Si Agregar, revisar si existe cod_comp+cod_depto
                dtTemporal = sqlExecute("SELECT cod_menu FROM menus where cod_menu = '" & txtCodigo.Text & "'", "cafeteria")
                If dtTemporal.Rows.Count > 0 Then
                    MessageBox.Show("El registro no se puede agregar, ya existe '" & txtCodigo.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    txtCodigo.Focus()
                    Exit Sub
                Else

                    Cadena = "INSERT INTO menus (cod_menu,NOMBRE,DESCRIPCION,SERVICIO) VALUES ("
                    Cadena = Cadena & "'" & txtCodigo.Text & "','" & txtNombre.Text & "','" & txtDescripcion.Text & "','" & cmbServicio.Text & "')"
                    sqlExecute(Cadena, "cafeteria")
                    ' ActualizarPlatillos()
                    dtmenus = sqlExecute("SELECT * FROM menus WHERE cod_menu = '" & Hora & "'", "cafeteria")
                    If System.IO.File.Exists(ImgPlatilloTmp) Then
                        ' pcbPlatillo.Image = Nothing
                        My.Computer.FileSystem.CopyFile(ImgPlatilloTmp, PathPlatillos + "m" + Hora + ".jpg", True)
                    End If
                    MostrarInformacion()
                    Agregar = False
                End If

            ElseIf Editar Then
                Dim a As Integer = tabBuscar.SelectedTabIndex
                If a = 2 Then
                    If System.IO.File.Exists(ImgPlatilloTmp) Then
                        'pcbPlatillo.Image = Nothing
                        My.Computer.FileSystem.CopyFile(ImgPlatilloTmp, PathFotoMenu, True)
                    End If
                    MostrarInformacion()
                Else
                    ' Si Editar, entonces guardar cambios a registro
                    Cadena = "UPDATE menus set NOMBRE='" & txtNombre.Text & "',SERVICIO='" & cmbServicio.SelectedValue.ToString & "',DESCRIPCION='" & txtDescripcion.Text & "'"
                    Cadena = Cadena & " WHERE cod_menu = '" & txtCodigo.Text & "'"
                    sqlExecute(Cadena, "cafeteria")
                    '  ActualizarPlatillos()
                    dtmenus = sqlExecute("SELECT * FROM menus WHERE cod_menu = '" & Hora & "'", "cafeteria")
                    If System.IO.File.Exists(ImgPlatilloTmp) Then
                        'pcbPlatillo.Image = Nothing
                        My.Computer.FileSystem.CopyFile(ImgPlatilloTmp, PathFotoMenu, True)
                    End If
                    MostrarInformacion()
                End If
                
            Else
                Agregar = True
            End If
            Editar = False

            HabilitarBotones()
            HabilitarBotonesD()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub
 

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If Not Editar And Not Agregar Then
            Dim a As Integer = tabBuscar.SelectedTabIndex
            If a = 2 Then
                Editar = True
                HabilitarBotonesD()
            Else
                Editar = True
                HabilitarBotones()
                txtNombre.Focus()
            End If
  
        Else
            Agregar = False
            Editar = False
            HabilitarBotones()
            HabilitarBotonesD()
        End If

        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Dim codigo As String ', comp As String
        codigo = txtCodigo.Text
        'comp = cmbCia.SelectedValue
        dtTemporal = sqlExecute("SELECT * from programacion WHERE cod_menu = '" & codigo & "' ", "cafeteria")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse ningún menú que se encuentre programado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM menus WHERE cod_menu = '" & codigo & "'", "cafeteria")
                'sqlExecute("DELETE FROM dias WHERE cod_menu = '" & codigo & "' AND cod_comp = '" & comp & "'")
                btnSiguiente.PerformClick()
            End If
        End If
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtHrs As New DataTable

        dtHrs = sqlExecute("SELECT * FROM menus", "cafeteria")
        frmVistaPrevia.LlamarReporte("menus", dtmenus)
        frmVistaPrevia.ShowDialog()

    End Sub

    Private Sub frmmenus_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        pnlControles.Left = (Me.Width - pnlControles.Width) / 2
    End Sub

    Private Sub btnCambiarFoto_Click(sender As Object, e As EventArgs) Handles btnCambiarFoto.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Archivo de Imagen JPG (.jpg)|*.jpg"
        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            If System.IO.File.Exists(ofd.FileName) Then
                ImgPlatilloTmp = ofd.FileName
                'MakeRoundedImage(Image.FromFile(ofd.FileName), pctFotoMenu)
                pctFotoMenu.Image = Image.FromFile(ofd.FileName)
            Else
                ImgPlatilloTmp = ""
                'pcbPlatillo.Image = Nothing
            End If
        Else
            If System.IO.File.Exists(PathPlatillos.Trim & "m" + txtCodigo.Text & ".jpg") Then
                Dim s As System.IO.FileStream = New System.IO.FileStream(PathPlatillos.Trim & "m" + txtCodigo.Text & ".jpg", System.IO.FileMode.Open, System.IO.FileAccess.Read)
                ' MakeRoundedImage(Image.FromStream(s), pctFotoMenu)
                pctFotoMenu.Image = Image.FromStream(s)
                s.Close()
            Else
                pctFotoMenu.Image = Nothing
            End If

        End If
    End Sub

    Private Sub btnQuitarFoto_Click(sender As Object, e As EventArgs) Handles btnQuitarFoto.Click
        System.IO.File.Delete(PathFotoMenu)
        pctFotoMenu.Image = Nothing
    End Sub
    Private Sub MakeRoundedImage(ByVal Img As Image, ByVal PicBox As PictureBox)

        Using bm As New Bitmap(Img.Width, Img.Height)
            Using grx2 As Graphics = Graphics.FromImage(bm)
                grx2.SmoothingMode = SmoothingMode.AntiAlias
                Using tb As New TextureBrush(Img)
                    tb.TranslateTransform(0, 0)
                    Using gp As New GraphicsPath
                        gp.AddEllipse(0, 0, Img.Width, Img.Height)
                        grx2.FillPath(tb, gp)
                    End Using
                End Using
            End Using
            If PicBox.Image IsNot Nothing Then PicBox.Image.Dispose()
            PicBox.Image = New Bitmap(bm)
        End Using
    End Sub
    Private Sub ElegirPlatillo(sender As Object, e As EventArgs)
        'If frmElegirPlatillos.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '    If sqlExecute("select  * from menu_platillo where cod_menu = '" + txtCodigo.Text + "' and cod_platillo= '" + frmElegirPlatillos.CodigoPlatilloSeleccionado + "'", "cafeteria").Rows.Count > 0 Then
        '        Exit Sub
        '    End If
        '    sqlExecute("insert into menu_platillo(cod_menu,cod_platillo) values('" + txtCodigo.Text + "','" + frmElegirPlatillos.CodigoPlatilloSeleccionado + "')", "cafeteria")
        'End If
        'AgregarPlatillos()
    End Sub
    Private Sub AgregarPlatillos()
        'For Each c As uscPlatillo In flwPlatillos.Controls
        '    If Not c.Equals() Then
        '        c.Dispose()
        '        '
        '    End If
        'Next
        'flwPlatillos.Controls.Remove(AgregaPlatillo)
        'flwPlatillos.Controls.Clear()
        'flwPlatillos.Controls.Add(AgregaPlatillo)
        'flwPlatillos.Refresh()
        'Dim dtPlatillos As DataTable = sqlExecute("select platillos.* from menu_platillo left join platillos on menu_platillo.cod_platillo = platillos.cod_platillo where menu_platillo.cod_menu  = '" + txtCodigo.Text + "'", "cafeteria")
        'For Each r As DataRow In dtPlatillos.Rows
        '    flwPlatillos.Controls.Add(New uscPlatillo(r.Item("cod_platillo"), PathPlatillos + r.Item("cod_platillo").ToString.Trim + ".jpg", r.Item("nombre"), False))
        'Next
        'For Each c As uscPlatillo In flwPlatillos.Controls
        '    If Not c.Equals(AgregaPlatillo) Then
        '        AddHandler c.btnAgregarQuitar.Click, AddressOf QuitarPlatillo
        '    End If
        'Next
    End Sub
    Private Sub QuitarPlatillo(sender As Object, e As EventArgs)
        'Dim c As uscPlatillo = TryCast(sender.parent, uscPlatillo)
        'Dim cod As String = c.CodigoPlatillo

        'sqlExecute("delete from menu_platillo where cod_menu = '" + txtCodigo.Text + "' and cod_platillo= '" + cod + "'", "cafeteria")
        'AgregarPlatillos()
    End Sub

    Private Sub ActualizarPlatillos()
        'sqlExecute("delete menu_platillo where cod_menu  ='" + txtCodigo.Text + "'", "cafeteria")
        'Dim d As String = ""
        'For Each c As uscPlatillo In flwPlatillos.Controls
        '    If c.CodigoPlatillo <> "" Then
        '        d = d + "insert into menu_platillo(cod_menu,cod_platillo) values('" + txtCodigo.Text + "','" + c.CodigoPlatillo + "')"
        '    End If
        'Next
        'sqlExecute(d, "cafeteria")
    End Sub

    Private Sub tabBuscar_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles tabBuscar.SelectedTabChanged
        Dim a As Integer = tabBuscar.SelectedTabIndex
        If a = 2 Then
            btnBorrar.Visible = False
            btnNuevo.Visible = False
            btnBuscar.Visible = False

            btnCambiarD.Enabled = False
            btnQuitarD.Enabled = False
            MostrarInformacion()

        Else
            btnBorrar.Visible = True
            btnNuevo.Visible = True
            btnBuscar.Visible = True

        End If
    End Sub

    Public Sub SiguienteN(ByVal tabla As String, ByVal campo As String, ByVal valor As String, ByRef dtRegistro As DataTable, Optional BaseDatos As String = "Personal")

        dtRegistro = sqlExecute("SELECT TOP 1 * FROM " & tabla & " WHERE " & campo & " >'" & valor & "' and cod_menu not in ('DEFAD', 'DEFCO', 'DEFCE') ORDER BY " & campo & " ASC", BaseDatos)
        If dtRegistro.Rows.Count < 1 Then
            dtRegistro = sqlExecute("SELECT TOP 1 * FROM " & tabla & " where cod_menu not in ('DEFAD', 'DEFCO', 'DEFCE') ORDER BY " & campo & " DESC", BaseDatos)
        End If

    End Sub

    Public Sub AnteriorN(ByVal tabla As String, ByVal campo As String, ByVal valor As String, ByRef dtRegistro As DataTable, Optional BaseDatos As String = "Personal")
        dtRegistro = sqlExecute("SELECT TOP 1 * FROM " & tabla & " WHERE " & campo & "<'" & valor & "' and cod_menu not in ('DEFAD', 'DEFCO', 'DEFCE') ORDER BY " & campo & " DESC", BaseDatos)
        If dtRegistro.Rows.Count < 1 Then
            dtRegistro = sqlExecute("SELECT TOP 1 * FROM " & tabla & " where cod_menu not in ('DEFAD', 'DEFCO', 'DEFCE') ORDER BY " & campo & " ASC", BaseDatos)
        End If
    End Sub

    Public Sub PrimeroN(ByVal tabla As String, ByVal campo As String, ByRef dtRegistro As DataTable, Optional BaseDatos As String = "Personal")

        dtRegistro = sqlExecute("SELECT TOP 1 * FROM " & tabla & " where cod_menu not in ('DEFAD', 'DEFCO', 'DEFCE') ORDER BY " & campo & " ASC ", BaseDatos)
    End Sub

    Public Sub UltimoN(ByVal tabla As String, ByVal campo As String, ByRef dtRegistro As DataTable, Optional BaseDatos As String = "Personal")
        dtRegistro = sqlExecute("SELECT TOP 1 * FROM " & tabla & " where cod_menu not in ('DEFAD', 'DEFCO', 'DEFCE') ORDER BY " & campo & " DESC", BaseDatos)
    End Sub

    Public Sub SiguienteD(ByVal tabla As String, ByVal campo As String, ByVal valor As String, ByRef dtRegistro As DataTable, Optional BaseDatos As String = "Personal")

        dtRegistro = sqlExecute("SELECT TOP 1 * FROM " & tabla & " WHERE " & campo & " >'" & valor & "' and cod_menu  in ('DEFAD', 'DEFCO', 'DEFCE') ORDER BY " & campo & " ASC", BaseDatos)
        If dtRegistro.Rows.Count < 1 Then
            dtRegistro = sqlExecute("SELECT TOP 1 * FROM " & tabla & " where cod_menu in ('DEFAD', 'DEFCO', 'DEFCE')ORDER BY " & campo & " DESC", BaseDatos)
        End If

    End Sub

    Public Sub AnteriorD(ByVal tabla As String, ByVal campo As String, ByVal valor As String, ByRef dtRegistro As DataTable, Optional BaseDatos As String = "Personal")
        dtRegistro = sqlExecute("SELECT TOP 1 * FROM " & tabla & " WHERE " & campo & "<'" & valor & "' and cod_menu  in ('DEFAD', 'DEFCO', 'DEFCE') ORDER BY " & campo & " DESC", BaseDatos)
        If dtRegistro.Rows.Count < 1 Then
            dtRegistro = sqlExecute("SELECT TOP 1 * FROM " & tabla & " where cod_menu in ('DEFAD', 'DEFCO', 'DEFCE') ORDER BY " & campo & " ASC", BaseDatos)
        End If
    End Sub

    Public Sub PrimeroD(ByVal tabla As String, ByVal campo As String, ByRef dtRegistro As DataTable, Optional BaseDatos As String = "Personal")

        dtRegistro = sqlExecute("SELECT TOP 1 * FROM " & tabla & " where cod_menu  in ('DEFAD', 'DEFCO', 'DEFCE') ORDER BY " & campo & " ASC ", BaseDatos)
    End Sub

    Public Sub UltimoD(ByVal tabla As String, ByVal campo As String, ByRef dtRegistro As DataTable, Optional BaseDatos As String = "Personal")
        dtRegistro = sqlExecute("SELECT TOP 1 * FROM " & tabla & " where cod_menu in ('DEFAD', 'DEFCO', 'DEFCE') ORDER BY " & campo & " DESC", BaseDatos)
    End Sub

    Private Sub btnCambiarD_Click(sender As Object, e As EventArgs) Handles btnCambiarD.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Archivo de Imagen JPG (.jpg)|*.jpg"
        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            If System.IO.File.Exists(ofd.FileName) Then
                ImgPlatilloTmp = ofd.FileName
                'MakeRoundedImage(Image.FromFile(ofd.FileName), picDefault)
                picDefault.Image = Image.FromFile(ofd.FileName)
            Else
                ImgPlatilloTmp = ""
                'pcbPlatillo.Image = Nothing
            End If
        Else
            If System.IO.File.Exists(PathPlatillos.Trim & "m" + txtCodigo.Text & ".jpg") Then
                Dim s As System.IO.FileStream = New System.IO.FileStream(PathPlatillos.Trim & "m" + txtCodigo.Text & ".jpg", System.IO.FileMode.Open, System.IO.FileAccess.Read)
                'MakeRoundedImage(Image.FromStream(s), picDefault)
                picDefault.Image = Image.FromStream(s)
                s.Close()
            Else
                pctFotoMenu.Image = Nothing
            End If

        End If
    End Sub

    Private Sub btnQuitarD_Click(sender As Object, e As EventArgs) Handles btnQuitarD.Click
        System.IO.File.Delete(PathFotoMenu)
        picDefault.Image = Nothing
    End Sub
End Class