Imports System.Drawing.Drawing2D
Public Class frmElegirMenu
    Dim dtmenus As DataTable
    Dim PathPlatillos As String = ""
    Dim PathFotoMenu As String = ""
    Public CodigoMenuSeleccionado As String = ""
    Private Sub frmElegirMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pctFotoMenu.SizeMode = PictureBoxSizeMode.StretchImage
        Dim dtPathP As DataTable = sqlExecute("select top 1 path_fotos from parametros ", "cafeteria")
        If dtPathP.Rows.Count > 0 Then
            PathPlatillos = dtPathP.Rows(0).Item("path_fotos")
        Else
            PathPlatillos = ""
        End If
        dtmenus = sqlExecute("select top 1 * from menus where cod_menu not in ('DEFAD', 'DEFCO', 'DEFCE') order by cod_menu", "cafeteria")
        CodigoMenuSeleccionado = ""
        MostrarInformacion()
    End Sub
    Private Sub MostrarInformacion()
        If dtmenus.Rows.Count > 0 Then
            txtCodigo.Text = IIf(IsDBNull(dtmenus.Rows.Item(0).Item("cod_menu")), "", dtmenus.Rows.Item(0).Item("cod_menu")).ToString.Trim
            txtNombre.Text = IIf(IsDBNull(dtmenus.Rows.Item(0).Item("nombre")), "", dtmenus.Rows.Item(0).Item("nombre")).ToString.Trim
            txtDescripcion.Text = IIf(IsDBNull(dtmenus.Rows.Item(0).Item("descripcion")), "", dtmenus.Rows.Item(0).Item("descripcion")).ToString.Trim
            txtServicio.Text = IIf(IsDBNull(dtmenus.Rows.Item(0).Item("servicio")), "", dtmenus.Rows.Item(0).Item("servicio")).ToString.Trim
            PathFotoMenu = PathPlatillos + "m" + txtCodigo.Text.Trim + ".jpg"

        Else
            txtCodigo.Text = ""
            txtNombre.Text = ""
            txtDescripcion.Text = ""
            txtServicio.Text = ""
        End If
        ' flwPlatillos.Controls.Clear()
        PathFotoMenu = PathPlatillos + "m" + txtCodigo.Text + ".jpg"
        If System.IO.File.Exists(PathFotoMenu) Then
            Dim s As System.IO.FileStream = New System.IO.FileStream(PathFotoMenu, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            MakeRoundedImage(Image.FromStream(s), pctFotoMenu)
            s.Close()
        Else
            pctFotoMenu.Image = Nothing
        End If

        'Dim dtPlatillos As DataTable = sqlExecute("select platillos.* from menu_platillo left join platillos on menu_platillo.cod_platillo = platillos.cod_platillo where menu_platillo.cod_menu  = '" + txtCodigo.Text + "'", "cafeteria")
        'For Each r As DataRow In dtPlatillos.Rows
        '    flwPlatillos.Controls.Add(New uscPlatillo(r.Item("cod_platillo"), PathPlatillos + r.Item("cod_platillo").ToString.Trim + ".jpg", r.Item("nombre"), 0))
        'Next
    End Sub
    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        SiguienteN("menus", "cod_menu", txtCodigo.Text, dtmenus, "cafeteria")
        MostrarInformacion()
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        UltimoN("menus", "cod_menu", dtmenus, "cafeteria")
        MostrarInformacion()
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        PrimeroN("menus", "cod_menu", dtmenus, "cafeteria")
        MostrarInformacion()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        AnteriorN("menus", "cod_menu", txtCodigo.Text, dtmenus, "cafeteria")
        MostrarInformacion()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("cafeteria.dbo.menus", "cod_menu", "menus", False)
        If Cod <> "CANCELAR" Then
            dtmenus = sqlExecute("SELECT * from menus WHERE cod_menu = '" & Cod & "' ", "cafeteria")
            MostrarInformacion()
        End If

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
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        CodigoMenuSeleccionado = txtCodigo.Text
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        CodigoMenuSeleccionado = ""
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
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
End Class