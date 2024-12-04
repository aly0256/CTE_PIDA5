<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCondensados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCondensados))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.comboCondensados = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvReportesCondensado = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.nombreReporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.marcarImpresion = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbImpresoras = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnGenerarReporte = New DevComponents.DotNetBar.ButtonX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.dgvReportesCondensado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(50, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(473, 46)
        Me.ReflectionLabel1.TabIndex = 122
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>IMPRIMIR CONDENSADO</b></font>"
        '
        'comboCondensados
        '
        Me.comboCondensados.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.comboCondensados.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.comboCondensados.BackgroundStyle.Class = "TextBoxBorder"
        Me.comboCondensados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.comboCondensados.ButtonDropDown.Visible = True
        Me.comboCondensados.Columns.Add(Me.ColumnHeader1)
        Me.comboCondensados.Columns.Add(Me.ColumnHeader3)
        Me.comboCondensados.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.comboCondensados.Location = New System.Drawing.Point(12, 77)
        Me.comboCondensados.Name = "comboCondensados"
        Me.comboCondensados.Size = New System.Drawing.Size(511, 23)
        Me.comboCondensados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.comboCondensados.TabIndex = 124
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "tipo"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Tipo"
        Me.ColumnHeader1.Width.Absolute = 35
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DataFieldName = "nombre"
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.StretchToFill = True
        Me.ColumnHeader3.Text = "Nombre"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Condensado"
        '
        'dgvReportesCondensado
        '
        Me.dgvReportesCondensado.AllowUserToAddRows = False
        Me.dgvReportesCondensado.AllowUserToDeleteRows = False
        Me.dgvReportesCondensado.AllowUserToOrderColumns = True
        Me.dgvReportesCondensado.AllowUserToResizeColumns = False
        Me.dgvReportesCondensado.AllowUserToResizeRows = False
        Me.dgvReportesCondensado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReportesCondensado.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvReportesCondensado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReportesCondensado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nombreReporte, Me.marcarImpresion})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReportesCondensado.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReportesCondensado.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvReportesCondensado.Location = New System.Drawing.Point(12, 175)
        Me.dgvReportesCondensado.MultiSelect = False
        Me.dgvReportesCondensado.Name = "dgvReportesCondensado"
        Me.dgvReportesCondensado.Size = New System.Drawing.Size(511, 195)
        Me.dgvReportesCondensado.TabIndex = 126
        '
        'nombreReporte
        '
        Me.nombreReporte.DataPropertyName = "nombreReporte"
        Me.nombreReporte.HeaderText = "Reporte"
        Me.nombreReporte.Name = "nombreReporte"
        Me.nombreReporte.ReadOnly = True
        Me.nombreReporte.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.nombreReporte.Width = 400
        '
        'marcarImpresion
        '
        Me.marcarImpresion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.marcarImpresion.Checked = True
        Me.marcarImpresion.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.marcarImpresion.CheckValue = Nothing
        Me.marcarImpresion.DataPropertyName = "marcarImpresion"
        Me.marcarImpresion.HeaderText = ""
        Me.marcarImpresion.Name = "marcarImpresion"
        Me.marcarImpresion.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 159)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 127
        Me.Label2.Text = "Reportes a Imprimir"
        '
        'cmbImpresoras
        '
        Me.cmbImpresoras.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbImpresoras.BackgroundStyle.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.TopLeft
        Me.cmbImpresoras.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbImpresoras.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbImpresoras.ButtonDropDown.Visible = True
        Me.cmbImpresoras.ImageIndex = 0
        Me.cmbImpresoras.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbImpresoras.Location = New System.Drawing.Point(3, 26)
        Me.cmbImpresoras.Name = "cmbImpresoras"
        Me.cmbImpresoras.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect
        Me.cmbImpresoras.Size = New System.Drawing.Size(478, 21)
        Me.cmbImpresoras.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbImpresoras.TabIndex = 130
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Location = New System.Drawing.Point(3, 3)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(78, 17)
        Me.RadioButton2.TabIndex = 135
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Imprimir en:"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ButtonX1)
        Me.Panel1.Controls.Add(Me.cmbImpresoras)
        Me.Panel1.Controls.Add(Me.RadioButton2)
        Me.Panel1.Location = New System.Drawing.Point(12, 106)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(511, 50)
        Me.Panel1.TabIndex = 136
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(487, 26)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(21, 21)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 136
        Me.ButtonX1.Text = "..."
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCerrar.Location = New System.Drawing.Point(443, 376)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(80, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 129
        Me.btnCerrar.Text = "&Cancelar"
        '
        'btnGenerarReporte
        '
        Me.btnGenerarReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGenerarReporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerarReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGenerarReporte.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnGenerarReporte.Location = New System.Drawing.Point(357, 376)
        Me.btnGenerarReporte.Name = "btnGenerarReporte"
        Me.btnGenerarReporte.Size = New System.Drawing.Size(80, 25)
        Me.btnGenerarReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGenerarReporte.TabIndex = 128
        Me.btnGenerarReporte.Text = "&Aceptar"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.condensados
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 46)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 123
        Me.PictureBox1.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1, Me.ToolStripStatusLabel1})
        Me.StatusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 405)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(535, 21)
        Me.StatusStrip1.TabIndex = 137
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 15)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(18, 15)
        Me.ToolStripStatusLabel1.Text = " - "
        '
        'frmCondensados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(535, 426)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnGenerarReporte)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvReportesCondensado)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.comboCondensados)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCondensados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Condensados"
        CType(Me.dgvReportesCondensado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents comboCondensados As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvReportesCondensado As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnGenerarReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmbImpresoras As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents nombreReporte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents marcarImpresion As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
End Class
