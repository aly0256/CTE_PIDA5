<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportarChecadas
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportarChecadas))
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.txtIP = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.txtPort = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblState = New DevComponents.DotNetBar.LabelX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX4 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX5 = New DevComponents.DotNetBar.ButtonX()
        Me.TextBoxX1 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.DataGridViewX1 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX6 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX7 = New DevComponents.DotNetBar.ButtonX()
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(263, 12)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(149, 20)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 0
        Me.ButtonX1.Text = "Conectar"
        '
        'txtIP
        '
        '
        '
        '
        Me.txtIP.Border.Class = "TextBoxBorder"
        Me.txtIP.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtIP.Location = New System.Drawing.Point(36, 12)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.PreventEnterBeep = True
        Me.txtIP.Size = New System.Drawing.Size(112, 20)
        Me.txtIP.TabIndex = 1
        Me.txtIP.Text = "10.3.32.11"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(13, 9)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(17, 23)
        Me.LabelX1.TabIndex = 2
        Me.LabelX1.Text = "IP:"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(167, 9)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(41, 23)
        Me.LabelX2.TabIndex = 4
        Me.LabelX2.Text = "Puerto:"
        '
        'txtPort
        '
        '
        '
        '
        Me.txtPort.Border.Class = "TextBoxBorder"
        Me.txtPort.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPort.Location = New System.Drawing.Point(214, 12)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.PreventEnterBeep = True
        Me.txtPort.Size = New System.Drawing.Size(43, 20)
        Me.txtPort.TabIndex = 3
        Me.txtPort.Text = "4370"
        '
        'lblState
        '
        '
        '
        '
        Me.lblState.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblState.Location = New System.Drawing.Point(553, 9)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(215, 23)
        Me.lblState.TabIndex = 5
        Me.lblState.Text = "Estado: Desconectado"
        Me.lblState.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Location = New System.Drawing.Point(13, 345)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(167, 31)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 6
        Me.ButtonX2.Text = "Importar (GetGeneralLogData)"
        '
        'ButtonX4
        '
        Me.ButtonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX4.Location = New System.Drawing.Point(619, 38)
        Me.ButtonX4.Name = "ButtonX4"
        Me.ButtonX4.Size = New System.Drawing.Size(149, 20)
        Me.ButtonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX4.TabIndex = 10
        Me.ButtonX4.Text = "Numero de registros"
        '
        'ButtonX5
        '
        Me.ButtonX5.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX5.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX5.Location = New System.Drawing.Point(13, 38)
        Me.ButtonX5.Name = "ButtonX5"
        Me.ButtonX5.Size = New System.Drawing.Size(104, 20)
        Me.ButtonX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX5.TabIndex = 11
        Me.ButtonX5.Text = "Eliminar registros"
        '
        'TextBoxX1
        '
        '
        '
        '
        Me.TextBoxX1.Border.Class = "TextBoxBorder"
        Me.TextBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TextBoxX1.Location = New System.Drawing.Point(13, 65)
        Me.TextBoxX1.Multiline = True
        Me.TextBoxX1.Name = "TextBoxX1"
        Me.TextBoxX1.PreventEnterBeep = True
        Me.TextBoxX1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxX1.Size = New System.Drawing.Size(255, 274)
        Me.TextBoxX1.TabIndex = 12
        '
        'DataGridViewX1
        '
        Me.DataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewX1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewX1.GridColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.DataGridViewX1.Location = New System.Drawing.Point(274, 65)
        Me.DataGridViewX1.Name = "DataGridViewX1"
        Me.DataGridViewX1.Size = New System.Drawing.Size(494, 274)
        Me.DataGridViewX1.TabIndex = 13
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX3.Location = New System.Drawing.Point(186, 345)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(167, 31)
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX3.TabIndex = 14
        Me.ButtonX3.Text = "Importar (USE THIS) (SSRGetGeneralLogData)"
        '
        'ButtonX6
        '
        Me.ButtonX6.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX6.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX6.Location = New System.Drawing.Point(359, 345)
        Me.ButtonX6.Name = "ButtonX6"
        Me.ButtonX6.Size = New System.Drawing.Size(167, 31)
        Me.ButtonX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX6.TabIndex = 15
        Me.ButtonX6.Text = "Importar (GetAllGLogData)"
        '
        'ButtonX7
        '
        Me.ButtonX7.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX7.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX7.Location = New System.Drawing.Point(532, 345)
        Me.ButtonX7.Name = "ButtonX7"
        Me.ButtonX7.Size = New System.Drawing.Size(155, 31)
        Me.ButtonX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX7.TabIndex = 16
        Me.ButtonX7.Text = "Importar (GetGeneralExtLogData)"
        '
        'frmImportarChecadas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 385)
        Me.Controls.Add(Me.ButtonX7)
        Me.Controls.Add(Me.ButtonX6)
        Me.Controls.Add(Me.ButtonX3)
        Me.Controls.Add(Me.DataGridViewX1)
        Me.Controls.Add(Me.TextBoxX1)
        Me.Controls.Add(Me.ButtonX5)
        Me.Controls.Add(Me.ButtonX4)
        Me.Controls.Add(Me.ButtonX2)
        Me.Controls.Add(Me.lblState)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.txtIP)
        Me.Controls.Add(Me.ButtonX1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmImportarChecadas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración de relojes"
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtIP As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtPort As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblState As DevComponents.DotNetBar.LabelX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX4 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX5 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TextBoxX1 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents DataGridViewX1 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX6 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX7 As DevComponents.DotNetBar.ButtonX
End Class
