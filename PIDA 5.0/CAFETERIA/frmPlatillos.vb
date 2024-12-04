Imports System.Drawing.Drawing2D
Public Class frmPlatillos

    'Private Sub frmPlatillos_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    '    MakeRoundedImage(Image.FromFile("C:\CASAS\me.jpg"), pcbPlatillo)

    'End Sub
    '   Dim dtCias As New DataTable
    Dim dtTurnos As New DataTable
    Dim dtDias As New DataTable
    Dim dtPlatillos As New DataTable
    Dim dtTemp As New DataTable
    Dim dtLista As New DataTable

    Dim PathPlatillos As String = ""
    Dim ImgPlatilloTmp As String = ""
    Dim Editar As Boolean
    Dim Agregar As Boolean
    Dim DesdeGrid As Boolean
    Dim CodHora As String ', CodComp As String

    Private Sub frmPlatillos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        pcbPlatillo.SizeMode = PictureBoxSizeMode.StretchImage
        Agregar = False
        Editar = False

        dtLista = sqlExecute("SELECT cod_platillo as 'Código',Nombre FROM Platillos", "cafeteria") 'cod_comp as 'Compañía',
        dtLista.DefaultView.Sort = "Código"

        dgTabla.DataSource = dtLista
        dgTabla.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill


        Dim dtPathP As DataTable = sqlExecute("select top 1 path_platillos from parametros ", "cafeteria")
        If dtPathP.Rows.Count > 0 Then
            PathPlatillos = dtPathP.Rows(0).Item("path_platillos")
        Else
            PathPlatillos = ""
        End If
        'dtCias = sqlExecute("SELECT cod_comp,nombre FROM cias")
        ' cmbCia.DataSource = dtCias

        DesdeGrid = False
        dtPlatillos = sqlExecute("SELECT TOP 1 * FROM Platillos ORDER BY cod_platillo ASC", "cafeteria")
        If dtPlatillos.Rows.Count > 0 Then MostrarInformacion()
        HabilitarBotones()
    End Sub

    Sub MostrarInformacion()
        Dim i As Integer
        Try
            ' CodComp = dtPlatillos.Rows.Item(0).Item("cod_comp")
            CodHora = dtPlatillos.Rows.Item(0).Item("cod_platillo")

            txtCodigo.Text = CodHora
            txtNombre.Text = IIf(IsDBNull(dtPlatillos.Rows.Item(0).Item("nombre")), "", dtPlatillos.Rows.Item(0).Item("nombre")).ToString.Trim
            txtDescripcion.Text = IIf(IsDBNull(dtPlatillos.Rows.Item(0).Item("descripcion")), "", dtPlatillos.Rows.Item(0).Item("descripcion")).ToString.Trim
            '  cmbCia.SelectedValue = CodComp

            If System.IO.File.Exists(PathPlatillos.Trim & txtCodigo.Text & ".jpg") Then
                Dim s As System.IO.FileStream = New System.IO.FileStream(PathPlatillos.Trim & txtCodigo.Text & ".jpg", System.IO.FileMode.Open, System.IO.FileAccess.Read)
                MakeRoundedImage(Image.FromStream(s), pcbPlatillo)
                s.Close()
            Else
                MakeRoundedImage(My.Resources._1472009258_FAQ1, pcbPlatillo)
                '  pcbPlatillo.Image = My.Resources._1472009258_FAQ1
            End If

  
            If Not DesdeGrid Then
                i = dtLista.DefaultView.Find(txtCodigo.Text)
                If i >= 0 Then
                    dgTabla.FirstDisplayedScrollingRowIndex = i
                    dgTabla.Rows(i).Selected = True
                End If
            End If
            DesdeGrid = False
            'HabilitarBotones()

        Catch ex As Exception

            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub btnSiguiente_Click(sender As Object, e As EventArgs) Handles btnSiguiente.Click
        Siguiente("Platillos", "cod_platillo", CodHora, dtPlatillos, "cafeteria")
        MostrarInformacion()
    End Sub

    Private Sub btnUltimo_Click(sender As Object, e As EventArgs) Handles btnUltimo.Click
        Ultimo("Platillos", "cod_platillo", dtPlatillos, "cafeteria")
        MostrarInformacion()
    End Sub

    Private Sub btnPrimero_Click(sender As Object, e As EventArgs) Handles btnPrimero.Click
        Primero("Platillos", "cod_platillo", dtPlatillos, "cafeteria")
        MostrarInformacion()
    End Sub

    Private Sub btnAnterior_Click(sender As Object, e As EventArgs) Handles btnAnterior.Click
        Anterior("Platillos", "cod_platillo", CodHora, dtPlatillos, "cafeteria")
        MostrarInformacion()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim Cod As String
        Cod = Buscar("cafeteria.dbo.Platillos", "cod_platillo", "Platillos", False)
        If Cod <> "CANCELAR" Then
            dtPlatillos = sqlExecute("SELECT * from Platillos WHERE cod_platillo = '" & Cod & "'", "cafeteria")
            MostrarInformacion()
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

        '  txtCodigo.Enabled = Agregar
        ' cmbCia.Enabled = Agregar

        If Agregar Then
            txtCodigo.Text = ""
            txtNombre.Text = ""
            txtDescripcion.Text = ""
            MakeRoundedImage(My.Resources._1472009258_FAQ1, pcbPlatillo)
            txtCodigo.Focus()
        ElseIf Editar Then
            txtNombre.Focus()
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
            dtPlatillos = sqlExecute("SELECT * from Platillos WHERE cod_platillo = '" & cod & "'", "cafeteria")
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
                'dtTemporal = sqlExecute("SELECT cod_platillo FROM Platillos where cod_platillo = '" & txtCodigo.Text & "'", "cafeteria")
                'If dtTemporal.Rows.Count > 0 Then
                '    MessageBox.Show("El registro no se puede agregar, ya existe '" & txtCodigo.Text & "'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    txtCodigo.Focus()
                '    Exit Sub
                'Else

                'End If
                Dim c As String = ObtenerCodigo()
                Cadena = "INSERT INTO Platillos (cod_platillo,NOMBRE,DESCRIPCION) VALUES ("
                Cadena = Cadena & "'" & c & "','" & txtNombre.Text & "','" & txtDescripcion.Text & "')"
                If System.IO.File.Exists(ImgPlatilloTmp) Then
                    ' pcbPlatillo.Image = Nothing
                    My.Computer.FileSystem.CopyFile(ImgPlatilloTmp, PathPlatillos + c + ".jpg", True)
                End If

                sqlExecute(Cadena, "cafeteria")


                dtPlatillos = sqlExecute("SELECT * FROM Platillos WHERE cod_platillo = '" & c & "'", "cafeteria")
                MostrarInformacion()
                Agregar = False

            ElseIf Editar Then
                ' Si Editar, entonces guardar cambios a registro
                Cadena = "UPDATE Platillos set NOMBRE='" & txtNombre.Text & "',descripcion='" & txtDescripcion.Text & "' "
                Cadena = Cadena & "WHERE cod_platillo = '" & txtCodigo.Text & "'"
                If System.IO.File.Exists(ImgPlatilloTmp) Then
                    'pcbPlatillo.Image = Nothing
                    My.Computer.FileSystem.CopyFile(ImgPlatilloTmp, PathPlatillos + txtCodigo.Text + ".jpg", True)
                End If
                sqlExecute(Cadena, "cafeteria")

                dtPlatillos = sqlExecute("SELECT * FROM Platillos WHERE cod_platillo = '" & Hora & "'", "cafeteria")
                MostrarInformacion()
            Else
                Agregar = True
            End If
            Editar = False

            HabilitarBotones()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub


    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If Not Editar And Not Agregar Then
            Editar = True
            HabilitarBotones()
            txtNombre.Focus()
        Else
            Agregar = False
            Editar = False
            HabilitarBotones()

        End If

        MostrarInformacion()
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Dim codigo As String ', comp As String
        codigo = txtCodigo.Text
        'comp = cmbCia.SelectedValue
        dtTemporal = sqlExecute("SELECT cod_platillo from menu_platillo WHERE cod_platillo = '" & codigo & "' ", "cafeteria")
        If dtTemporal.Rows.Count > 0 Then
            MessageBox.Show("No puede borrarse un registro que se encuentre asignado a algún menú.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            If MessageBox.Show("¿Está seguro de borrar el registro " & codigo & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                sqlExecute("DELETE FROM Platillos WHERE cod_platillo = '" & codigo & "'", "cafeteria")
                My.Computer.FileSystem.DeleteFile(PathPlatillos + codigo + ".jpg")
                btnSiguiente.PerformClick()
            End If
        End If
    End Sub

    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        Dim dtHrs As New DataTable

        dtHrs = sqlExecute("SELECT * FROM Platillos", "cafeteria")
        frmVistaPrevia.LlamarReporte("Platillos", dtPlatillos) ', cmbCia.SelectedValue)
        frmVistaPrevia.ShowDialog()

    End Sub

    Private Sub frmPlatillos_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        pnlControles.Left = (Me.Width - pnlControles.Width) / 2
    End Sub
    Private Function ObtenerCodigo() As String
        Dim dtCod As DataTable = sqlExecute("select  cast (ISNULL(max(cod_platillo),0) as integer) +1 as id from platillos", "cafeteria")

        Return IIf(IsDBNull(dtCod.Rows(0).Item("id")), 1, dtCod.Rows(0).Item("id")).ToString.PadLeft(7, "0")
    End Function
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

    Private Sub pcbPlatillo_Click(sender As Object, e As EventArgs) Handles pcbPlatillo.Click

    End Sub

    Private Sub btnCambiarFoto_Click(sender As Object, e As EventArgs) Handles btnCambiarFoto.Click
        Dim ofd As New OpenFileDialog
        ofd.Filter = "Archivo de Imagen JPG (.jpg)|*.jpg"
        If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
            If System.IO.File.Exists(ofd.FileName) Then
                ImgPlatilloTmp = ofd.FileName
                MakeRoundedImage(Image.FromFile(ofd.FileName), pcbPlatillo)
            Else
                ImgPlatilloTmp = ""
                'pcbPlatillo.Image = Nothing
            End If
        Else
            If System.IO.File.Exists(PathPlatillos.Trim & txtCodigo.Text & ".jpg") Then
                Dim s As System.IO.FileStream = New System.IO.FileStream(PathPlatillos.Trim & txtCodigo.Text & ".jpg", System.IO.FileMode.Open, System.IO.FileAccess.Read)
                MakeRoundedImage(Image.FromStream(s), pcbPlatillo)
                s.Close()
            Else
                pcbPlatillo.Image = My.Resources._1472009258_FAQ1
            End If

        End If
    End Sub
End Class