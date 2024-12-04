<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class loginemp
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtUsuario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtClave = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cmbSucursal = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.btnOk = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancel = New DevComponents.DotNetBar.ButtonX()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusMay = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusNum = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.PIDALogin
        Me.PictureBox1.Location = New System.Drawing.Point(1, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(158, 166)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 59
        Me.PictureBox1.TabStop = False
        '
        'txtUsuario
        '
        '
        '
        '
        Me.txtUsuario.Border.Class = "TextBoxBorder"
        Me.txtUsuario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtUsuario.Location = New System.Drawing.Point(194, 33)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.PreventEnterBeep = True
        Me.txtUsuario.Size = New System.Drawing.Size(222, 20)
        Me.txtUsuario.TabIndex = 62
        '
        'txtClave
        '
        '
        '
        '
        Me.txtClave.Border.Class = "TextBoxBorder"
        Me.txtClave.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtClave.Location = New System.Drawing.Point(194, 76)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.PreventEnterBeep = True
        Me.txtClave.Size = New System.Drawing.Size(222, 20)
        Me.txtClave.TabIndex = 63
        '
        'cmbSucursal
        '
        Me.cmbSucursal.DisplayMember = "Text"
        Me.cmbSucursal.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbSucursal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSucursal.FormattingEnabled = True
        Me.cmbSucursal.ItemHeight = 14
        Me.cmbSucursal.Location = New System.Drawing.Point(194, 122)
        Me.cmbSucursal.Name = "cmbSucursal"
        Me.cmbSucursal.Size = New System.Drawing.Size(222, 20)
        Me.cmbSucursal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbSucursal.TabIndex = 64
        '
        'btnOk
        '
        Me.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnOk.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnOk.Location = New System.Drawing.Point(194, 175)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(91, 29)
        Me.btnOk.TabIndex = 65
        Me.btnOk.Text = "Aceptar"
        '
        'btnCancel
        '
        Me.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancel.Location = New System.Drawing.Point(325, 175)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 29)
        Me.btnCancel.TabIndex = 66
        Me.btnCancel.Text = "Cancelar"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.statusMay, Me.statusNum})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 267)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(511, 24)
        Me.StatusStrip1.TabIndex = 67
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(421, 19)
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
        'loginemp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 291)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.cmbSucursal)
        Me.Controls.Add(Me.txtClave)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "loginemp"
        Me.Text = "loginemp"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtUsuario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtClave As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmbSucursal As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents btnOk As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusMay As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusNum As System.Windows.Forms.ToolStripStatusLabel
End Class
