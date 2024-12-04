
Imports System.Drawing.Drawing2D
Public Class uscPeriodoCafeteria
    Public HayDesayuno As Boolean
    Public HayComida As Boolean
    Public HayCena As Boolean
    Dim AnoMenu As String
    Dim PeriodoMenu As String
    Dim FechaMenu As Date
    Dim PathFotoMenu As String
    Dim PathCafeteria As String
    Dim FechaInicialMenu As Date
    Dim FechaFinalMenu As Date
    Dim ToolTipDesayuno As DevComponents.DotNetBar.SuperTooltip
    Dim ToolTipComida As DevComponents.DotNetBar.SuperTooltip
    Dim ToolTipCena As DevComponents.DotNetBar.SuperTooltip
    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        'SuperTooltip1.SetSuperTooltip(btnDesayuno, New DevComponents.DotNetBar.SuperTooltipInfo("Nombre - header", "descripcion - footer", "Body text", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Silver))
    End Sub
    Public Sub New(period As String, year As String, Fecha As Date)
        ' This call is required by the designer.
        InitializeComponent()
        Me.lblDia.Text = "<b><font size=""+5""><b>" + DiaSem(Fecha) + "</b></font></b>"
        Me.lblFecha.Text = "<b><font size=""+2""><b>" + FechaSQL(Fecha) + "</b></font></b>"
        AnoMenu = year
        PeriodoMenu = period
        FechaMenu = Fecha
        PathCafeteria = ""
        Dim dtPAthCafeteria As DataTable = sqlExecute("select path_fotos from parametros", "CAFETERIA")
        If dtPAthCafeteria.Rows.Count > 0 Then
            PathCafeteria = dtPAthCafeteria.Rows(0).Item("path_fotos").ToString.Trim
        Else
            PathCafeteria = ""
        End If
        'lblnicio.Text = FechaMediaLetra(startDate)
        'lblFin.Text = FechaMediaLetra(finalDate)
        ActualizarControl()
        'SuperTooltip1.SetSuperTooltip(btnDesayuno, New DevComponents.DotNetBar.SuperTooltipInfo("Nombre - header", "descripcion - footer", "Body text", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Silver))
    End Sub
    Public Sub New(period As String, year As String, startDate As Date, finalDate As Date)
        ' This call is required by the designer.
        InitializeComponent()
        Me.lblFecha.Text = "<b><font size=""+1""><b>" + period + "</b></font></b>"
        AnoMenu = year
        PeriodoMenu = period
        FechaInicialMenu = startDate
        FechaFinalMenu = finalDate
        'lblnicio.Text = FechaMediaLetra(startDate)
        'lblFin.Text = FechaMediaLetra(finalDate)
        ActualizarControl()
        'SuperTooltip1.SetSuperTooltip(btnDesayuno, New DevComponents.DotNetBar.SuperTooltipInfo("Nombre - header", "descripcion - footer", "Body text", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Silver))
    End Sub
    Private Sub ActualizarControl()
        Try

        Catch ex As Exception

        End Try
        If FechaMenu < Now.Date Then
            Me.Enabled = False
        End If


        Dim dtDesayuno As DataTable = sqlExecute("select * from programacion where ano = '" + AnoMenu + "' and periodo = '" + PeriodoMenu + "' and servicio = 'DESAYUNO' AND FECHA='" + FechaSQL(FechaMenu) + "' AND DIA ='" + DiaSem(FechaMenu) + "'", "cafeteria")
        pctDesayuno.SizeMode = PictureBoxSizeMode.StretchImage
        If dtDesayuno.Rows.Count > 0 Then
            btnDesayuno.Text = "Desayuno - " + dtDesayuno.Rows(0).Item("cod_menu").ToString.Trim
            PathFotoMenu = PathCafeteria + "m" + dtDesayuno.Rows(0).Item("cod_menu").ToString.Trim + ".jpg"
            btnDesayuno.BackColor = Color.LightGreen
            Dim dtMenu As DataTable = sqlExecute("select menus.* FROM menus WHERE cod_menu = '" + dtDesayuno.Rows(0).Item("cod_menu") + "'", "cafeteria")
            Dim Header As String = ""
            Dim Body As String = ""
            If dtMenu.Rows.Count > 0 Then
                '  pctDesayuno.BackgroundImageLayout = ImageLayout.Stretch
                If System.IO.File.Exists(PathFotoMenu) Then
                    Dim s As System.IO.FileStream = New System.IO.FileStream(PathFotoMenu, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                    'MakeRoundedImage(Image.FromStream(s), pctDesayuno)
                    pctDesayuno.Image = Image.FromStream(s)
                    s.Close()
                Else
                    pctDesayuno.Image = Nothing
                End If

                Header = "<b>" + dtMenu.Rows(0).Item("nombre") + "</b>"
                Body = Body + " - " + dtMenu.Rows(0).Item("Descripcion") + vbCrLf
                ToolTipDesayuno = New DevComponents.DotNetBar.SuperTooltip()
                ToolTipDesayuno.SetSuperTooltip(btnDesayuno, New DevComponents.DotNetBar.SuperTooltipInfo(Header, "", Body, Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Green))
            End If

        Else
            Dim s As System.IO.FileStream = New System.IO.FileStream(PathCafeteria & "defaD.jpg", System.IO.FileMode.Open, System.IO.FileAccess.Read)
            pctDesayuno.Image = Image.FromStream(s)
            btnDesayuno.Text = "Desayuno - Default"
            btnDesayuno.BackColor = Color.White
            ToolTipDesayuno = New DevComponents.DotNetBar.SuperTooltip()
        End If

        Dim dtComida As DataTable = sqlExecute("select * from programacion where ano = '" + AnoMenu + "' and periodo = '" + PeriodoMenu + "' and servicio = 'COMIDA' AND FECHA='" + FechaSQL(FechaMenu) + "' AND DIA ='" + DiaSem(FechaMenu) + "'", "cafeteria")
        pctComida.SizeMode = PictureBoxSizeMode.StretchImage
        If dtComida.Rows.Count > 0 Then
            btnComida.Text = "Comida - " + dtComida.Rows(0).Item("cod_menu").ToString.Trim
            PathFotoMenu = PathCafeteria + "m" + dtComida.Rows(0).Item("cod_menu").ToString.Trim + ".jpg"
            btnComida.BackColor = Color.LightBlue
            Dim dtMenu As DataTable = sqlExecute("select menus.* FROM menus WHERE cod_menu = '" + dtComida.Rows(0).Item("cod_menu") + "'", "cafeteria")
            Dim Header As String = ""
            Dim Body As String = ""
            If dtMenu.Rows.Count > 0 Then

                'pctComida.BackgroundImageLayout = ImageLayout.Stretch
                If System.IO.File.Exists(PathFotoMenu) Then
                    Dim s As System.IO.FileStream = New System.IO.FileStream(PathFotoMenu, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                    ' MakeRoundedImage(Image.FromStream(s), pctComida)
                    pctComida.Image = Image.FromStream(s)
                    s.Close()
                Else
                    pctComida.Image = Nothing
                End If

                Header = "<b>" + dtMenu.Rows(0).Item("nombre") + "</b>"
                Body = Body + " - " + dtMenu.Rows(0).Item("Descripcion") + vbCrLf
                ToolTipComida = New DevComponents.DotNetBar.SuperTooltip()
                ToolTipComida.SetSuperTooltip(btnComida, New DevComponents.DotNetBar.SuperTooltipInfo(Header, "", Body, Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Blue))

            End If


        Else
            Dim s As System.IO.FileStream = New System.IO.FileStream(PathCafeteria & "defCo.jpg", System.IO.FileMode.Open, System.IO.FileAccess.Read)
            pctComida.Image = Image.FromStream(s)
            btnComida.Text = "Comida - Default"
            btnComida.BackColor = Color.White
            ToolTipComida = New DevComponents.DotNetBar.SuperTooltip()
        End If
        Dim dtCena As DataTable = sqlExecute("select * from programacion where ano = '" + AnoMenu + "' and periodo = '" + PeriodoMenu + "' and servicio = 'Cena' AND FECHA='" + FechaSQL(FechaMenu) + "' AND DIA ='" + DiaSem(FechaMenu) + "'", "cafeteria")
        pctCena.SizeMode = PictureBoxSizeMode.StretchImage
        If dtCena.Rows.Count > 0 Then
            btnCena.Text = "Cena - " + dtCena.Rows(0).Item("cod_menu").ToString.Trim
            PathFotoMenu = PathCafeteria + "m" + dtCena.Rows(0).Item("cod_menu").ToString.Trim + ".jpg"
            btnCena.BackColor = Color.Orchid
            Dim dtMenu As DataTable = sqlExecute("select menus.* FROM menus WHERE cod_menu = '" + dtCena.Rows(0).Item("cod_menu") + "'", "cafeteria")
            Dim Header As String = ""
            Dim Body As String = ""
            If dtMenu.Rows.Count > 0 Then

                'pctCena.BackgroundImageLayout = ImageLayout.Stretch
                If System.IO.File.Exists(PathFotoMenu) Then
                    Dim s As System.IO.FileStream = New System.IO.FileStream(PathFotoMenu, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                    pctCena.Image = Image.FromStream(s)
                    s.Close()
                Else
                    pctCena.Image = Nothing
                End If

                Header = "<b>" + dtMenu.Rows(0).Item("nombre") + "</b>"
                Body = Body + " - " + dtMenu.Rows(0).Item("Descripcion") + vbCrLf
                ToolTipCena = New DevComponents.DotNetBar.SuperTooltip()
                ToolTipCena.SetSuperTooltip(btnCena, New DevComponents.DotNetBar.SuperTooltipInfo(Header, "", Body, Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Purple))
            End If
        Else
            Dim s As System.IO.FileStream = New System.IO.FileStream(PathCafeteria & "defCe.jpg", System.IO.FileMode.Open, System.IO.FileAccess.Read)
            pctCena.Image = Image.FromStream(s)
            btnCena.Text = "Cena - Default"
            btnCena.BackColor = Color.White
            ToolTipCena = New DevComponents.DotNetBar.SuperTooltip()
        End If
        sqlExecute("update dispositivos set Sincronizar = '1' where planta = 'JUAREZ 1'", "cafeteria")
        Me.Refresh()

    End Sub
    Private Sub btnDesayuno_Click(sender As Object, e As EventArgs) Handles btnDesayuno.Click
        If frmElegirMenu.ShowDialog() = DialogResult.OK Then
            Dim dtDesayuno As DataTable = sqlExecute("select * from programacion where ano = '" + AnoMenu + "' and periodo = '" + PeriodoMenu + "' and servicio = 'DESAYUNO' AND FECHA='" + FechaSQL(FechaMenu) + "' AND DIA ='" + DiaSem(FechaMenu) + "'", "cafeteria")
            If dtDesayuno.Rows.Count > 0 Then
                sqlExecute("update programacion set cod_menu = '" + frmElegirMenu.CodigoMenuSeleccionado + "' where  ano = '" + AnoMenu + "' and periodo = '" + PeriodoMenu + "' and servicio = 'DESAYUNO' AND FECHA='" + FechaSQL(FechaMenu) + "' AND DIA ='" + DiaSem(FechaMenu) + "'", "cafeteria")
            Else
                sqlExecute("insert into programacion(ano,periodo,servicio,cod_menu,fecha,dia) values('" + AnoMenu + "','" + PeriodoMenu + "','DESAYUNO','" + frmElegirMenu.CodigoMenuSeleccionado + "','" + FechaSQL(FechaMenu) + "','" + DiaSem(FechaMenu) + "')", "cafeteria")
            End If
            ActualizarControl()
        End If

    End Sub

    Private Sub btnComida_Click(sender As Object, e As EventArgs) Handles btnComida.Click
        If frmElegirMenu.ShowDialog() = DialogResult.OK Then
            Dim dtComida As DataTable = sqlExecute("select * from programacion where ano = '" + AnoMenu + "' and periodo = '" + PeriodoMenu + "' and servicio = 'COMIDA' AND FECHA='" + FechaSQL(FechaMenu) + "' AND DIA ='" + DiaSem(FechaMenu) + "'", "cafeteria")
            If dtComida.Rows.Count > 0 Then
                sqlExecute("update programacion set cod_menu = '" + frmElegirMenu.CodigoMenuSeleccionado + "' where  ano = '" + AnoMenu + "' and periodo = '" + PeriodoMenu + "' and servicio = 'COMIDA' AND FECHA='" + FechaSQL(FechaMenu) + "' AND DIA ='" + DiaSem(FechaMenu) + "'", "cafeteria")
            Else
                sqlExecute("insert into programacion(ano,periodo,servicio,cod_menu,fecha,dia) values('" + AnoMenu + "','" + PeriodoMenu + "','COMIDA','" + frmElegirMenu.CodigoMenuSeleccionado + "','" + FechaSQL(FechaMenu) + "','" + DiaSem(FechaMenu) + "')", "cafeteria")
            End If
            ActualizarControl()
        End If

    End Sub

    Private Sub btnCena_Click(sender As Object, e As EventArgs) Handles btnCena.Click
        If frmElegirMenu.ShowDialog() = DialogResult.OK Then
            Dim dtCena As DataTable = sqlExecute("select * from programacion where ano = '" + AnoMenu + "' and periodo = '" + PeriodoMenu + "' and servicio = 'CENA' AND FECHA='" + FechaSQL(FechaMenu) + "' AND DIA ='" + DiaSem(FechaMenu) + "'", "cafeteria")
            If dtCena.Rows.Count > 0 Then
                sqlExecute("update programacion set cod_menu = '" + frmElegirMenu.CodigoMenuSeleccionado + "' where  ano = '" + AnoMenu + "' and periodo = '" + PeriodoMenu + "' and servicio = 'CENA'  AND FECHA='" + FechaSQL(FechaMenu) + "' AND DIA ='" + DiaSem(FechaMenu) + "'", "cafeteria")
            Else
                sqlExecute("insert into programacion(ano,periodo,servicio,cod_menu,fecha,dia) values('" + AnoMenu + "','" + PeriodoMenu + "','CENA','" + frmElegirMenu.CodigoMenuSeleccionado + "','" + FechaSQL(FechaMenu) + "','" + DiaSem(FechaMenu) + "')", "cafeteria")
            End If
            ActualizarControl()
        End If

    End Sub

    Private Sub uscPeriodoCafeteria_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PathCafeteria = ""
        Dim dtPAthCafeteria As DataTable = sqlExecute("select path_fotos from parametros", "CAFETERIA")
        If dtPAthCafeteria.Rows.Count > 0 Then
            PathCafeteria = dtPAthCafeteria.Rows(0).Item("path_fotos").ToString.Trim
        Else
            PathCafeteria = ""
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
End Class
