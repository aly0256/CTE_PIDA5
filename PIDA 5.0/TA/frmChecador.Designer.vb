<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChecador
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblTipo = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.lblFecha = New DevComponents.DotNetBar.LabelX()
        Me.lblHora = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PanelEx1 = New DevComponents.DotNetBar.PanelEx()
        Me.lblReloj = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.lblTurno = New DevComponents.DotNetBar.LabelX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.lblHorario = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.lblSuper = New DevComponents.DotNetBar.LabelX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.lblDepto = New DevComponents.DotNetBar.LabelX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.lblArea = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.lblClase = New DevComponents.DotNetBar.LabelX()
        Me.lblNombre = New DevComponents.DotNetBar.LabelX()
        Me.PanelEx2 = New DevComponents.DotNetBar.PanelEx()
        Me.lblAviso = New DevComponents.DotNetBar.LabelX()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEx1.SuspendLayout()
        Me.PanelEx2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTipo
        '
        '
        '
        '
        Me.lblTipo.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblTipo.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Gold
        Me.lblTipo.BackgroundStyle.BorderBottomWidth = 1
        Me.lblTipo.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblTipo.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblTipo.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblTipo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.ForeColor = System.Drawing.Color.Black
        Me.lblTipo.Location = New System.Drawing.Point(17, 114)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(122, 36)
        Me.lblTipo.TabIndex = 150
        Me.lblTipo.Text = "O"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.DimGray
        Me.LabelX2.Location = New System.Drawing.Point(17, 150)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(49, 23)
        Me.LabelX2.TabIndex = 133
        Me.LabelX2.Text = "TIPO"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.Controls.Add(Me.PictureBox3)
        Me.Panel2.Controls.Add(Me.lblFecha)
        Me.Panel2.Controls.Add(Me.lblHora)
        Me.Panel2.Controls.Add(Me.LabelX9)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1044, 44)
        Me.Panel2.TabIndex = 150
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.PIDA.My.Resources.Resources.Cerrar32
        Me.PictureBox3.Location = New System.Drawing.Point(1088, 8)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(38, 30)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 153
        Me.PictureBox3.TabStop = False
        '
        'lblFecha
        '
        '
        '
        '
        Me.lblFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.ForeColor = System.Drawing.Color.White
        Me.lblFecha.Location = New System.Drawing.Point(815, 5)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(194, 34)
        Me.lblFecha.TabIndex = 152
        Me.lblFecha.Text = "00:00"
        Me.lblFecha.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'lblHora
        '
        '
        '
        '
        Me.lblHora.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHora.ForeColor = System.Drawing.Color.White
        Me.lblHora.Location = New System.Drawing.Point(1003, 5)
        Me.lblHora.Name = "lblHora"
        Me.lblHora.Size = New System.Drawing.Size(79, 34)
        Me.lblHora.TabIndex = 151
        Me.lblHora.Text = "00:00"
        Me.lblHora.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'LabelX9
        '
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.ForeColor = System.Drawing.Color.White
        Me.LabelX9.Location = New System.Drawing.Point(61, 8)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(248, 27)
        Me.LabelX9.TabIndex = 131
        Me.LabelX9.Text = "Checador"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Accept32
        Me.PictureBox1.Location = New System.Drawing.Point(10, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(45, 34)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 130
        Me.PictureBox1.TabStop = False
        '
        'PanelEx1
        '
        Me.PanelEx1.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx1.Controls.Add(Me.lblReloj)
        Me.PanelEx1.Controls.Add(Me.LabelX7)
        Me.PanelEx1.Controls.Add(Me.lblTurno)
        Me.PanelEx1.Controls.Add(Me.LabelX5)
        Me.PanelEx1.Controls.Add(Me.lblHorario)
        Me.PanelEx1.Controls.Add(Me.LabelX3)
        Me.PanelEx1.Controls.Add(Me.lblSuper)
        Me.PanelEx1.Controls.Add(Me.LabelX13)
        Me.PanelEx1.Controls.Add(Me.lblDepto)
        Me.PanelEx1.Controls.Add(Me.LabelX11)
        Me.PanelEx1.Controls.Add(Me.lblArea)
        Me.PanelEx1.Controls.Add(Me.LabelX1)
        Me.PanelEx1.Controls.Add(Me.lblClase)
        Me.PanelEx1.Controls.Add(Me.lblNombre)
        Me.PanelEx1.Controls.Add(Me.LabelX2)
        Me.PanelEx1.Controls.Add(Me.lblTipo)
        Me.PanelEx1.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelEx1.Location = New System.Drawing.Point(0, 44)
        Me.PanelEx1.Name = "PanelEx1"
        Me.PanelEx1.Size = New System.Drawing.Size(703, 469)
        Me.PanelEx1.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx1.Style.BackColor1.Color = System.Drawing.Color.White
        Me.PanelEx1.Style.BackColor2.Color = System.Drawing.Color.DarkGray
        Me.PanelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx1.Style.GradientAngle = 90
        Me.PanelEx1.TabIndex = 151
        '
        'lblReloj
        '
        '
        '
        '
        Me.lblReloj.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReloj.ForeColor = System.Drawing.Color.Black
        Me.lblReloj.Location = New System.Drawing.Point(12, 49)
        Me.lblReloj.Name = "lblReloj"
        Me.lblReloj.Size = New System.Drawing.Size(151, 35)
        Me.lblReloj.TabIndex = 164
        Me.lblReloj.Text = "000000"
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.DimGray
        Me.LabelX7.Location = New System.Drawing.Point(507, 405)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(86, 23)
        Me.LabelX7.TabIndex = 163
        Me.LabelX7.Text = "TURNO"
        '
        'lblTurno
        '
        '
        '
        '
        Me.lblTurno.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblTurno.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Gold
        Me.lblTurno.BackgroundStyle.BorderBottomWidth = 1
        Me.lblTurno.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblTurno.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblTurno.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblTurno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurno.ForeColor = System.Drawing.Color.Black
        Me.lblTurno.Location = New System.Drawing.Point(507, 369)
        Me.lblTurno.Name = "lblTurno"
        Me.lblTurno.Size = New System.Drawing.Size(150, 36)
        Me.lblTurno.TabIndex = 162
        Me.lblTurno.Text = "1"
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.DimGray
        Me.LabelX5.Location = New System.Drawing.Point(17, 405)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(177, 23)
        Me.LabelX5.TabIndex = 160
        Me.LabelX5.Text = "HORARIO"
        '
        'lblHorario
        '
        '
        '
        '
        Me.lblHorario.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblHorario.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Gold
        Me.lblHorario.BackgroundStyle.BorderBottomWidth = 1
        Me.lblHorario.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblHorario.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblHorario.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblHorario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblHorario.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHorario.ForeColor = System.Drawing.Color.Black
        Me.lblHorario.Location = New System.Drawing.Point(17, 369)
        Me.lblHorario.Name = "lblHorario"
        Me.lblHorario.Size = New System.Drawing.Size(475, 36)
        Me.lblHorario.TabIndex = 161
        Me.lblHorario.Text = "LUN-JUE 16:00-00:30 VIE 16:00-00:00   "
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.DimGray
        Me.LabelX3.Location = New System.Drawing.Point(17, 348)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(177, 23)
        Me.LabelX3.TabIndex = 158
        Me.LabelX3.Text = "SUPERVISOR"
        '
        'lblSuper
        '
        '
        '
        '
        Me.lblSuper.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblSuper.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Gold
        Me.lblSuper.BackgroundStyle.BorderBottomWidth = 1
        Me.lblSuper.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblSuper.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblSuper.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblSuper.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblSuper.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuper.ForeColor = System.Drawing.Color.Black
        Me.lblSuper.Location = New System.Drawing.Point(17, 312)
        Me.lblSuper.Name = "lblSuper"
        Me.lblSuper.Size = New System.Drawing.Size(640, 36)
        Me.lblSuper.TabIndex = 159
        Me.lblSuper.Text = "Nombre, Nombre Nombre"
        '
        'LabelX13
        '
        '
        '
        '
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX13.ForeColor = System.Drawing.Color.DimGray
        Me.LabelX13.Location = New System.Drawing.Point(17, 271)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(177, 23)
        Me.LabelX13.TabIndex = 156
        Me.LabelX13.Text = "DEPARTAMENTO"
        '
        'lblDepto
        '
        '
        '
        '
        Me.lblDepto.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblDepto.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Gold
        Me.lblDepto.BackgroundStyle.BorderBottomWidth = 1
        Me.lblDepto.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblDepto.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblDepto.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblDepto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepto.ForeColor = System.Drawing.Color.Black
        Me.lblDepto.Location = New System.Drawing.Point(17, 235)
        Me.lblDepto.Name = "lblDepto"
        Me.lblDepto.Size = New System.Drawing.Size(409, 36)
        Me.lblDepto.TabIndex = 157
        Me.lblDepto.Text = "Mantenimiento Juarez"
        '
        'LabelX11
        '
        '
        '
        '
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.ForeColor = System.Drawing.Color.DimGray
        Me.LabelX11.Location = New System.Drawing.Point(17, 210)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(49, 23)
        Me.LabelX11.TabIndex = 154
        Me.LabelX11.Text = "AREA"
        '
        'lblArea
        '
        '
        '
        '
        Me.lblArea.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblArea.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Gold
        Me.lblArea.BackgroundStyle.BorderBottomWidth = 1
        Me.lblArea.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblArea.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblArea.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblArea.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArea.ForeColor = System.Drawing.Color.Black
        Me.lblArea.Location = New System.Drawing.Point(17, 174)
        Me.lblArea.Name = "lblArea"
        Me.lblArea.Size = New System.Drawing.Size(409, 36)
        Me.lblArea.TabIndex = 155
        Me.lblArea.Text = "Ensamble"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.DimGray
        Me.LabelX1.Location = New System.Drawing.Point(145, 150)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(86, 23)
        Me.LabelX1.TabIndex = 153
        Me.LabelX1.Text = "CLASE"
        '
        'lblClase
        '
        '
        '
        '
        Me.lblClase.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblClase.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Gold
        Me.lblClase.BackgroundStyle.BorderBottomWidth = 1
        Me.lblClase.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblClase.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblClase.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.lblClase.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblClase.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClase.ForeColor = System.Drawing.Color.Black
        Me.lblClase.Location = New System.Drawing.Point(145, 114)
        Me.lblClase.Name = "lblClase"
        Me.lblClase.Size = New System.Drawing.Size(231, 36)
        Me.lblClase.TabIndex = 152
        Me.lblClase.Text = "Directo"
        '
        'lblNombre
        '
        '
        '
        '
        Me.lblNombre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.Black
        Me.lblNombre.Location = New System.Drawing.Point(12, 11)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(685, 49)
        Me.lblNombre.TabIndex = 146
        Me.lblNombre.Text = "Nombre, Nombre Nombre"
        '
        'PanelEx2
        '
        Me.PanelEx2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PanelEx2.CanvasColor = System.Drawing.SystemColors.Control
        Me.PanelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PanelEx2.Controls.Add(Me.lblAviso)
        Me.PanelEx2.Controls.Add(Me.txtReloj)
        Me.PanelEx2.Controls.Add(Me.PictureBox2)
        Me.PanelEx2.DisabledBackColor = System.Drawing.Color.Empty
        Me.PanelEx2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEx2.Location = New System.Drawing.Point(703, 44)
        Me.PanelEx2.Name = "PanelEx2"
        Me.PanelEx2.Size = New System.Drawing.Size(341, 469)
        Me.PanelEx2.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.PanelEx2.Style.BackColor1.Color = System.Drawing.Color.Gold
        Me.PanelEx2.Style.BackColor2.Color = System.Drawing.Color.DarkGoldenrod
        Me.PanelEx2.Style.BackgroundImage = Global.PIDA.My.Resources.Resources.tire_160182_1280
        Me.PanelEx2.Style.BackgroundImagePosition = DevComponents.DotNetBar.eBackgroundImagePosition.CenterRight
        Me.PanelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.PanelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.PanelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.PanelEx2.Style.GradientAngle = 90
        Me.PanelEx2.TabIndex = 152
        '
        'lblAviso
        '
        '
        '
        '
        Me.lblAviso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblAviso.Font = New System.Drawing.Font("Impact", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAviso.ForeColor = System.Drawing.Color.Blue
        Me.lblAviso.Location = New System.Drawing.Point(9, 371)
        Me.lblAviso.Name = "lblAviso"
        Me.lblAviso.Size = New System.Drawing.Size(418, 65)
        Me.lblAviso.TabIndex = 148
        Me.lblAviso.Text = "<<Escanea tu gafete>>"
        Me.lblAviso.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'txtReloj
        '
        Me.txtReloj.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 50.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.ForeColor = System.Drawing.Color.Black
        Me.txtReloj.Location = New System.Drawing.Point(9, 271)
        Me.txtReloj.MaxLength = 10
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.Size = New System.Drawing.Size(406, 83)
        Me.txtReloj.TabIndex = 134
        Me.txtReloj.Text = "0000000000"
        Me.txtReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox2
        '
        Me.PictureBox2.ErrorImage = Global.PIDA.My.Resources.Resources.NoFoto
        Me.PictureBox2.Image = Global.PIDA.My.Resources.Resources.NoFoto
        Me.PictureBox2.InitialImage = Global.PIDA.My.Resources.Resources.NoFoto
        Me.PictureBox2.Location = New System.Drawing.Point(122, 43)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(201, 222)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 133
        Me.PictureBox2.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Timer2
        '
        '
        'Timer3
        '
        Me.Timer3.Interval = 1000
        '
        'Timer4
        '
        '
        'frmChecador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1044, 513)
        Me.Controls.Add(Me.PanelEx2)
        Me.Controls.Add(Me.PanelEx1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximumSize = New System.Drawing.Size(1130, 513)
        Me.Name = "frmChecador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmChecador"
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEx1.ResumeLayout(False)
        Me.PanelEx2.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTipo As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblFecha As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblHora As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PanelEx1 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents lblNombre As DevComponents.DotNetBar.LabelX
    Friend WithEvents PanelEx2 As DevComponents.DotNetBar.PanelEx
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents lblClase As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblArea As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDepto As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblSuper As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblHorario As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblTurno As DevComponents.DotNetBar.LabelX
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents lblAviso As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblReloj As DevComponents.DotNetBar.LabelX
    Friend WithEvents Timer4 As System.Windows.Forms.Timer
End Class
