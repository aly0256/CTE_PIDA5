<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambiarClave
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCambiarClave))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusMay = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusNum = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtConfirmar = New System.Windows.Forms.TextBox()
        Me.PasswordLabel = New System.Windows.Forms.Label()
        Me.UsernameLabel = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnOk = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.txtNuevaClave = New System.Windows.Forms.TextBox()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.statusMay, Me.statusNum})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 217)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(465, 24)
        Me.StatusStrip1.TabIndex = 68
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(372, 19)
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
        Me.statusMay.Size = New System.Drawing.Size(37, 19)
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
        'txtConfirmar
        '
        Me.txtConfirmar.Location = New System.Drawing.Point(103, 142)
        Me.txtConfirmar.Name = "txtConfirmar"
        Me.txtConfirmar.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmar.Size = New System.Drawing.Size(256, 21)
        Me.txtConfirmar.TabIndex = 1
        '
        'PasswordLabel
        '
        Me.PasswordLabel.BackColor = System.Drawing.SystemColors.Control
        Me.PasswordLabel.Location = New System.Drawing.Point(103, 119)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(257, 27)
        Me.PasswordLabel.TabIndex = 63
        Me.PasswordLabel.Text = "&Confirmar clave de acceso:&"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsernameLabel
        '
        Me.UsernameLabel.BackColor = System.Drawing.SystemColors.Control
        Me.UsernameLabel.Location = New System.Drawing.Point(103, 69)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(257, 27)
        Me.UsernameLabel.TabIndex = 61
        Me.UsernameLabel.Text = "&Nueva clave de acceso:"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.CambiarClave48
        Me.PictureBox1.Location = New System.Drawing.Point(14, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(52, 52)
        Me.PictureBox1.TabIndex = 67
        Me.PictureBox1.TabStop = False
        '
        'btnOk
        '
        Me.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnOk.CausesValidation = False
        Me.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnOk.Enabled = False
        Me.btnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnOk.Location = New System.Drawing.Point(142, 175)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(91, 29)
        Me.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelar.Location = New System.Drawing.Point(237, 175)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(91, 29)
        Me.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "Cancelar"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(69, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(369, 46)
        Me.ReflectionLabel1.TabIndex = 97
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CAMBIAR CLAVE DE ACCESO</b></font>"
        '
        'txtNuevaClave
        '
        Me.txtNuevaClave.Location = New System.Drawing.Point(103, 99)
        Me.txtNuevaClave.Name = "txtNuevaClave"
        Me.txtNuevaClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtNuevaClave.Size = New System.Drawing.Size(256, 21)
        Me.txtNuevaClave.TabIndex = 0
        '
        'frmCambiarClave
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(465, 241)
        Me.Controls.Add(Me.txtNuevaClave)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.txtConfirmar)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCambiarClave"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambiar clave de acceso"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusMay As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusNum As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnOk As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtConfirmar As System.Windows.Forms.TextBox
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents txtNuevaClave As System.Windows.Forms.TextBox
End Class
