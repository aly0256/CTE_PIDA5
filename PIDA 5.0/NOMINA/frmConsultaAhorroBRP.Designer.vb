<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaAhorroBRP
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAmaterno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtApaterno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.picFoto = New System.Windows.Forms.PictureBox()
        Me.gbReloj = New System.Windows.Forms.GroupBox()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnSalir = New DevComponents.DotNetBar.ButtonX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.txtResumen = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnPrestamo = New DevComponents.DotNetBar.ButtonX()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbReloj.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(335, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 15)
        Me.Label4.TabIndex = 151
        Me.Label4.Text = "Apellido materno"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(173, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 15)
        Me.Label3.TabIndex = 150
        Me.Label3.Text = "Apellido paterno"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 149
        Me.Label2.Text = "Nombre"
        '
        'txtAmaterno
        '
        '
        '
        '
        Me.txtAmaterno.Border.Class = "TextBoxBorder"
        Me.txtAmaterno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAmaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAmaterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmaterno.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtAmaterno.Location = New System.Drawing.Point(338, 96)
        Me.txtAmaterno.Name = "txtAmaterno"
        Me.txtAmaterno.ReadOnly = True
        Me.txtAmaterno.Size = New System.Drawing.Size(151, 21)
        Me.txtAmaterno.TabIndex = 148
        '
        'txtApaterno
        '
        '
        '
        '
        Me.txtApaterno.Border.Class = "TextBoxBorder"
        Me.txtApaterno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtApaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApaterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApaterno.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtApaterno.Location = New System.Drawing.Point(176, 96)
        Me.txtApaterno.Name = "txtApaterno"
        Me.txtApaterno.ReadOnly = True
        Me.txtApaterno.Size = New System.Drawing.Size(157, 21)
        Me.txtApaterno.TabIndex = 147
        '
        'txtNombre
        '
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNombre.Location = New System.Drawing.Point(12, 96)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(157, 21)
        Me.txtNombre.TabIndex = 146
        '
        'picFoto
        '
        Me.picFoto.ErrorImage = Global.PIDA.My.Resources.Resources.NoFoto1
        Me.picFoto.Image = Global.PIDA.My.Resources.Resources.NoFoto1
        Me.picFoto.Location = New System.Drawing.Point(572, 12)
        Me.picFoto.MaximumSize = New System.Drawing.Size(164, 210)
        Me.picFoto.MinimumSize = New System.Drawing.Size(82, 105)
        Me.picFoto.Name = "picFoto"
        Me.picFoto.Size = New System.Drawing.Size(82, 105)
        Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picFoto.TabIndex = 145
        Me.picFoto.TabStop = False
        '
        'gbReloj
        '
        Me.gbReloj.Controls.Add(Me.LabelX4)
        Me.gbReloj.Controls.Add(Me.txtReloj)
        Me.gbReloj.Location = New System.Drawing.Point(339, 12)
        Me.gbReloj.Name = "gbReloj"
        Me.gbReloj.Size = New System.Drawing.Size(227, 41)
        Me.gbReloj.TabIndex = 144
        Me.gbReloj.TabStop = False
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(11, 11)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(56, 23)
        Me.LabelX4.TabIndex = 36
        Me.LabelX4.Text = "Reloj"
        '
        'txtReloj
        '
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.ButtonCustom.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.txtReloj.ButtonCustom.Visible = True
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtReloj.Location = New System.Drawing.Point(69, 10)
        Me.txtReloj.MaxLength = 6
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.ReadOnly = True
        Me.txtReloj.Size = New System.Drawing.Size(152, 26)
        Me.txtReloj.TabIndex = 0
        Me.txtReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSalir
        '
        Me.btnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSalir.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnSalir.Location = New System.Drawing.Point(574, 329)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(80, 25)
        Me.btnSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSalir.TabIndex = 143
        Me.btnSalir.Text = "&Salir"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.ModSalTemp32
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(27, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 140
        Me.PictureBox1.TabStop = False
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(45, 23)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(288, 40)
        Me.ReflectionLabel1.TabIndex = 139
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>AHORRO DEL EMPLEADO</b></font>"
        '
        'txtResumen
        '
        '
        '
        '
        Me.txtResumen.Border.Class = "TextBoxBorder"
        Me.txtResumen.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtResumen.Location = New System.Drawing.Point(12, 123)
        Me.txtResumen.Multiline = True
        Me.txtResumen.Name = "txtResumen"
        Me.txtResumen.PreventEnterBeep = True
        Me.txtResumen.Size = New System.Drawing.Size(642, 200)
        Me.txtResumen.TabIndex = 138
        '
        'btnPrestamo
        '
        Me.btnPrestamo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrestamo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrestamo.Image = Global.PIDA.My.Resources.Resources.Prestamos32
        Me.btnPrestamo.ImageFixedSize = New System.Drawing.Size(22, 22)
        Me.btnPrestamo.Location = New System.Drawing.Point(488, 329)
        Me.btnPrestamo.Name = "btnPrestamo"
        Me.btnPrestamo.Size = New System.Drawing.Size(80, 25)
        Me.btnPrestamo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrestamo.TabIndex = 152
        Me.btnPrestamo.Text = "&Préstamo"
        '
        'frmConsultaAhorroBRP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 361)
        Me.Controls.Add(Me.btnPrestamo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAmaterno)
        Me.Controls.Add(Me.txtApaterno)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.picFoto)
        Me.Controls.Add(Me.gbReloj)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.txtResumen)
        Me.Name = "frmConsultaAhorroBRP"
        Me.Text = "frmConsultaAhorroBRP"
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbReloj.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAmaterno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtApaterno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents picFoto As System.Windows.Forms.PictureBox
    Friend WithEvents gbReloj As System.Windows.Forms.GroupBox
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnSalir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents txtResumen As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnPrestamo As DevComponents.DotNetBar.ButtonX
End Class
