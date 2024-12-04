<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChecadas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChecadas))
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.lblAviso = New DevComponents.DotNetBar.LabelX()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblReloj = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.lblHorario = New DevComponents.DotNetBar.LabelX()
        Me.lblTurno = New DevComponents.DotNetBar.LabelX()
        Me.lblSuper = New DevComponents.DotNetBar.LabelX()
        Me.lblDepto = New DevComponents.DotNetBar.LabelX()
        Me.lblNombre = New DevComponents.DotNetBar.LabelX()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblFecha = New DevComponents.DotNetBar.LabelX()
        Me.lblHora = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Timer4 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtReloj
        '
        Me.txtReloj.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.ForeColor = System.Drawing.Color.Black
        Me.txtReloj.Location = New System.Drawing.Point(757, 351)
        Me.txtReloj.MaxLength = 10
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.Size = New System.Drawing.Size(348, 53)
        Me.txtReloj.TabIndex = 127
        Me.txtReloj.Text = "0000000000"
        Me.txtReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.LightGray
        Me.LabelX5.Location = New System.Drawing.Point(15, 100)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(141, 23)
        Me.LabelX5.TabIndex = 139
        Me.LabelX5.Text = "Depto:"
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.LightGray
        Me.LabelX6.Location = New System.Drawing.Point(15, 141)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(111, 23)
        Me.LabelX6.TabIndex = 141
        Me.LabelX6.Text = "Supervisor:"
        '
        'LabelX7
        '
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.LightGray
        Me.LabelX7.Location = New System.Drawing.Point(15, 182)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(67, 23)
        Me.LabelX7.TabIndex = 143
        Me.LabelX7.Text = "Turno:"
        '
        'LabelX8
        '
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.ForeColor = System.Drawing.Color.LightGray
        Me.LabelX8.Location = New System.Drawing.Point(15, 221)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(77, 23)
        Me.LabelX8.TabIndex = 145
        Me.LabelX8.Text = "Horario:"
        '
        'lblAviso
        '
        '
        '
        '
        Me.lblAviso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblAviso.Font = New System.Drawing.Font("Impact", 35.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAviso.ForeColor = System.Drawing.Color.Blue
        Me.lblAviso.Location = New System.Drawing.Point(33, 410)
        Me.lblAviso.Name = "lblAviso"
        Me.lblAviso.Size = New System.Drawing.Size(718, 65)
        Me.lblAviso.TabIndex = 147
        Me.lblAviso.Text = "<<Desliza tu gafete por el lector>>"
        Me.lblAviso.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.lblReloj)
        Me.Panel1.Controls.Add(Me.LabelX1)
        Me.Panel1.Controls.Add(Me.lblHorario)
        Me.Panel1.Controls.Add(Me.lblTurno)
        Me.Panel1.Controls.Add(Me.lblSuper)
        Me.Panel1.Controls.Add(Me.lblDepto)
        Me.Panel1.Controls.Add(Me.lblNombre)
        Me.Panel1.Controls.Add(Me.LabelX8)
        Me.Panel1.Controls.Add(Me.LabelX7)
        Me.Panel1.Controls.Add(Me.LabelX6)
        Me.Panel1.Controls.Add(Me.LabelX5)
        Me.Panel1.Location = New System.Drawing.Point(33, 90)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(718, 314)
        Me.Panel1.TabIndex = 148
        '
        'lblReloj
        '
        '
        '
        '
        Me.lblReloj.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReloj.ForeColor = System.Drawing.Color.White
        Me.lblReloj.Location = New System.Drawing.Point(141, 46)
        Me.lblReloj.Name = "lblReloj"
        Me.lblReloj.Size = New System.Drawing.Size(490, 42)
        Me.lblReloj.TabIndex = 155
        Me.lblReloj.Text = "000000"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.LightGray
        Me.LabelX1.Location = New System.Drawing.Point(15, 58)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(141, 23)
        Me.LabelX1.TabIndex = 154
        Me.LabelX1.Text = "Reloj:"
        '
        'lblHorario
        '
        '
        '
        '
        Me.lblHorario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblHorario.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHorario.ForeColor = System.Drawing.Color.White
        Me.lblHorario.Location = New System.Drawing.Point(141, 207)
        Me.lblHorario.Name = "lblHorario"
        Me.lblHorario.Size = New System.Drawing.Size(577, 42)
        Me.lblHorario.TabIndex = 153
        Me.lblHorario.Text = "LUN-JUE 16:00-00:30 VIE 16:00-00:00   "
        '
        'lblTurno
        '
        '
        '
        '
        Me.lblTurno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurno.ForeColor = System.Drawing.Color.White
        Me.lblTurno.Location = New System.Drawing.Point(141, 168)
        Me.lblTurno.Name = "lblTurno"
        Me.lblTurno.Size = New System.Drawing.Size(88, 42)
        Me.lblTurno.TabIndex = 152
        Me.lblTurno.Text = "1"
        '
        'lblSuper
        '
        '
        '
        '
        Me.lblSuper.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblSuper.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuper.ForeColor = System.Drawing.Color.White
        Me.lblSuper.Location = New System.Drawing.Point(141, 127)
        Me.lblSuper.Name = "lblSuper"
        Me.lblSuper.Size = New System.Drawing.Size(490, 42)
        Me.lblSuper.TabIndex = 149
        Me.lblSuper.Text = "Nombre, Nombre Nombre"
        '
        'lblDepto
        '
        '
        '
        '
        Me.lblDepto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepto.ForeColor = System.Drawing.Color.White
        Me.lblDepto.Location = New System.Drawing.Point(141, 86)
        Me.lblDepto.Name = "lblDepto"
        Me.lblDepto.Size = New System.Drawing.Size(490, 42)
        Me.lblDepto.TabIndex = 148
        Me.lblDepto.Text = "Mantenimiento Juarez "
        '
        'lblNombre
        '
        '
        '
        '
        Me.lblNombre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.White
        Me.lblNombre.Location = New System.Drawing.Point(3, 3)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(708, 49)
        Me.lblNombre.TabIndex = 146
        Me.lblNombre.Text = "Nombre "
        '
        'Timer2
        '
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.lblFecha)
        Me.Panel2.Controls.Add(Me.lblHora)
        Me.Panel2.Controls.Add(Me.LabelX9)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1028, 74)
        Me.Panel2.TabIndex = 149
        '
        'lblFecha
        '
        '
        '
        '
        Me.lblFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFecha.ForeColor = System.Drawing.Color.White
        Me.lblFecha.Location = New System.Drawing.Point(909, 5)
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
        Me.lblHora.Location = New System.Drawing.Point(1024, 33)
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
        Me.LabelX9.Font = New System.Drawing.Font("Microsoft Sans Serif", 32.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.ForeColor = System.Drawing.Color.White
        Me.LabelX9.Location = New System.Drawing.Point(92, 12)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(248, 43)
        Me.LabelX9.TabIndex = 131
        Me.LabelX9.Text = "Cafetería"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Accept32
        Me.PictureBox1.Location = New System.Drawing.Point(21, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(65, 66)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 130
        Me.PictureBox1.TabStop = False
        '
        'Timer3
        '
        Me.Timer3.Interval = 1000
        '
        'PictureBox2
        '
        Me.PictureBox2.ErrorImage = Global.PIDA.My.Resources.Resources.NoFoto
        Me.PictureBox2.Image = Global.PIDA.My.Resources.Resources.NoFoto
        Me.PictureBox2.InitialImage = Global.PIDA.My.Resources.Resources.NoFoto
        Me.PictureBox2.Location = New System.Drawing.Point(826, 102)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(201, 222)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 132
        Me.PictureBox2.TabStop = False
        '
        'Timer4
        '
        '
        'frmChecadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gold
        Me.ClientSize = New System.Drawing.Size(1028, 487)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblAviso)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.txtReloj)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChecadas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Checador"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblAviso As DevComponents.DotNetBar.LabelX
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblHorario As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblTurno As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblSuper As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblDepto As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblNombre As DevComponents.DotNetBar.LabelX
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents lblHora As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblFecha As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblReloj As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Timer4 As System.Windows.Forms.Timer
End Class
