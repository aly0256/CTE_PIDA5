<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class frmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLogin))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusMay = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusNum = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtUsuario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtClave = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cmbSucursal = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.btnOk = New DevComponents.DotNetBar.ButtonX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.tiempoVal = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.statusMay, Me.statusNum})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 435)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(250, 24)
        Me.StatusStrip1.TabIndex = 60
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(160, 19)
        Me.ToolStripStatusLabel1.Spring = True
        '
        'statusMay
        '
        Me.statusMay.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.statusMay.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.statusMay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.statusMay.Name = "statusMay"
        Me.statusMay.Size = New System.Drawing.Size(36, 19)
        Me.statusMay.Text = "MAY"
        '
        'statusNum
        '
        Me.statusNum.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.statusNum.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.statusNum.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.statusNum.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.statusNum.Name = "statusNum"
        Me.statusNum.Size = New System.Drawing.Size(39, 19)
        Me.statusNum.Text = "NÚM"
        '
        'txtUsuario
        '
        '
        '
        '
        Me.txtUsuario.Border.Class = "TextBoxBorder"
        Me.txtUsuario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtUsuario.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.Location = New System.Drawing.Point(38, 14)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.PreventEnterBeep = True
        Me.txtUsuario.Size = New System.Drawing.Size(173, 29)
        Me.txtUsuario.TabIndex = 61
        Me.txtUsuario.Text = "Usuario"
        '
        'txtClave
        '
        '
        '
        '
        Me.txtClave.Border.Class = "TextBoxBorder"
        Me.txtClave.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtClave.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClave.Location = New System.Drawing.Point(38, 49)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PreventEnterBeep = True
        Me.txtClave.Size = New System.Drawing.Size(173, 29)
        Me.txtClave.TabIndex = 62
        '
        'cmbSucursal
        '
        Me.cmbSucursal.DisplayMember = "Text"
        Me.cmbSucursal.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSucursal.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbSucursal.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.ItemHeight = 17
        Me.cmbSucursal.Location = New System.Drawing.Point(38, 88)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(173, 23)
        Me.cmbSucursal.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.cmbSucursal.TabIndex = 63
        '
        'btnOk
        '
        Me.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnOk.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb
        Me.btnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Location = New System.Drawing.Point(15, 195)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(223, 37)
        Me.btnOk.TabIndex = 69
        Me.btnOk.Text = "Iniciar"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!)
        Me.ReflectionLabel1.Location = New System.Drawing.Point(64, 14)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(151, 38)
        Me.ReflectionLabel1.TabIndex = 251
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>Iniciar sesión</b></font>"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.PictureBox4)
        Me.Panel1.Controls.Add(Me.txtUsuario)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.txtClave)
        Me.Panel1.Controls.Add(Me.cmbSucursal)
        Me.Panel1.Location = New System.Drawing.Point(15, 59)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(223, 125)
        Me.Panel1.TabIndex = 252
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.PIDA.My.Resources.Resources.Sucursal
        Me.PictureBox2.Location = New System.Drawing.Point(4, 84)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(27, 29)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 255
        Me.PictureBox2.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.PIDA.My.Resources.Resources.Password
        Me.PictureBox4.Location = New System.Drawing.Point(3, 49)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(28, 29)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 254
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.PIDA.My.Resources.Resources.UserName
        Me.PictureBox3.Location = New System.Drawing.Point(3, 14)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(28, 29)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 253
        Me.PictureBox3.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.PIDA.My.Resources.Resources.Teclado1
        Me.PictureBox5.Location = New System.Drawing.Point(15, 241)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(223, 181)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 254
        Me.PictureBox5.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Key_Login
        Me.PictureBox1.Location = New System.Drawing.Point(8, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 49)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 253
        Me.PictureBox1.TabStop = False
        '
        'tiempoVal
        '
        Me.tiempoVal.Interval = 500
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(250, 459)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(15, 15)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sistema PIDA 5"
        Me.TopMost = True
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents statusMay As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusNum As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtUsuario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtClave As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmbSucursal As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents btnOk As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents tiempoVal As System.Windows.Forms.Timer

End Class
