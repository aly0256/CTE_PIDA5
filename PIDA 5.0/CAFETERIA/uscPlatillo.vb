Imports System.Drawing.Drawing2D

'   
Public Class uscPlatillo
    Public HayPlatillo As Boolean = False
    Public CodigoPlatillo As String = ""
    Public PathCompleto As String = ""

    Private Sub uscPlatillo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        CodigoPlatillo = ""
        PathCompleto = ""
        btnAgregarQuitar.Image = My.Resources.Add24
        lblNombrePLatillo.Text = " "
        'btnAgregarQuitar.Image = My.Resources.Ok16
        'btnAgregarQuitar.Image = My.Resources.Delete24
        '  AddHandler pcbImagenPlatillo.Click, AddressOf AgregarPlatillo
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(Cod As String, P As String, D As String)

        ' This call is required by the designer.
        InitializeComponent()
        CodigoPlatillo = Cod
        PathCompleto = P
        pcbImagenPlatillo.SizeMode = PictureBoxSizeMode.StretchImage
        lblNombrePLatillo.Text = "<b><font size=""+1""><b>" + D + "</b></font></b>"
        btnAgregarQuitar.Image = My.Resources.Ok16
        If System.IO.File.Exists(PathCompleto) Then
            Dim s As System.IO.FileStream = New System.IO.FileStream(PathCompleto, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            MakeRoundedImage(Image.FromStream(s), pcbImagenPlatillo)
            s.Close()
        Else
            pcbImagenPlatillo.Image = Nothing
        End If
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(codigo As String, path As String, nombre As String, t As Boolean) ', descripcion As String
        ' This call is required by the designer.
        InitializeComponent()
        CodigoPlatillo = codigo
        PathCompleto = path
        pcbImagenPlatillo.SizeMode = PictureBoxSizeMode.StretchImage
        lblNombrePLatillo.Text = "<b><font size=""+1""><b>" + nombre + "</b></font></b>"
        btnAgregarQuitar.Image = My.Resources.Delete24
        If System.IO.File.Exists(PathCompleto) Then
            Dim s As System.IO.FileStream = New System.IO.FileStream(PathCompleto, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            MakeRoundedImage(Image.FromStream(s), pcbImagenPlatillo)
            s.Close()
        Else
            pcbImagenPlatillo.Image = Nothing
        End If

    End Sub

    Public Sub New(codigo As String, path As String, nombre As String, t As Integer) ', descripcion As String
        ' This call is required by the designer.
        InitializeComponent()
        CodigoPlatillo = codigo
        PathCompleto = path
        pcbImagenPlatillo.SizeMode = PictureBoxSizeMode.StretchImage
        lblNombrePLatillo.Text = "<b><font size=""+1""><b>" + nombre + "</b></font></b>"
        btnAgregarQuitar.Visible = False
        If System.IO.File.Exists(PathCompleto) Then
            Dim s As System.IO.FileStream = New System.IO.FileStream(PathCompleto, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            MakeRoundedImage(Image.FromStream(s), pcbImagenPlatillo)
            s.Close()
        Else
            pcbImagenPlatillo.Image = Nothing
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
    Private Sub MostrarInformacion()
        Dim dtPlatilloInfo As DataTable = sqlExecute("select * from platillos where cod_platillo  = '" + CodigoPlatillo + "'")
        If dtPlatilloInfo.Rows.Count > 0 Then
            lblNombrePLatillo.Text = "<b><font size=""+6"">" + dtPlatilloInfo.Rows(0).Item("nombre").ToString.Trim + "</b></font></b>"
        Else
            lblNombrePLatillo.Text = "<b><font size=""+6""><b>Agregar platillo...</b></font></b>"
        End If

        If System.IO.File.Exists(PathCompleto) Then
            Dim s As System.IO.FileStream = New System.IO.FileStream(PathCompleto, System.IO.FileMode.Open, System.IO.FileAccess.Read)
            MakeRoundedImage(Image.FromStream(s), pcbImagenPlatillo)
            s.Close()
        Else
            pcbImagenPlatillo.Image = Nothing
        End If
    End Sub
    Private Sub AgregarPlatillo()
        '  Dim c As String = cmbDepto.SelectedValue
        Dim dtPlatillos As DataTable
        Try
            frmPlatillos.ShowDialog(Me)
            dtPlatillos = sqlExecute("SELECT cod_platillo,NOMBRE FROM platillos")
            ' cmbDepto.DataSource = dtDeptos
            '    If Not c = Nothing Then cmbDepto.SelectedValue = c

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            frmDeptos.Focus()
        End Try
    End Sub

    Private Sub btnAgregarQuitar_Click(sender As Object, e As EventArgs) Handles btnAgregarQuitar.Click

    End Sub
End Class
