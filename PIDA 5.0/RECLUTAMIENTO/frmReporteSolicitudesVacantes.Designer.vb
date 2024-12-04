<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteSolicitudesVacantes
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
        Me.btnCerrarr = New DevComponents.DotNetBar.ButtonX()
        Me.btnGenerarReportee = New DevComponents.DotNetBar.ButtonX()
        Me.dgvReportesVacantess = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.nombree = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.marcarr = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ReflectionLabel11 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PictureBox22 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip11 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar11 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabel11 = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.dgvReportesVacantess, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox22, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip11.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCerrarr
        '
        Me.btnCerrarr.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrarr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrarr.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrarr.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCerrarr.Location = New System.Drawing.Point(425, 258)
        Me.btnCerrarr.Name = "btnCerrarr"
        Me.btnCerrarr.Size = New System.Drawing.Size(80, 25)
        Me.btnCerrarr.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrarr.TabIndex = 132
        Me.btnCerrarr.Text = "&Cancelar"
        '
        'btnGenerarReportee
        '
        Me.btnGenerarReportee.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGenerarReportee.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerarReportee.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGenerarReportee.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnGenerarReportee.Location = New System.Drawing.Point(339, 258)
        Me.btnGenerarReportee.Name = "btnGenerarReportee"
        Me.btnGenerarReportee.Size = New System.Drawing.Size(80, 25)
        Me.btnGenerarReportee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGenerarReportee.TabIndex = 133
        Me.btnGenerarReportee.Text = "&Aceptar"
        '
        'dgvReportesVacantess
        '
        Me.dgvReportesVacantess.AllowUserToAddRows = False
        Me.dgvReportesVacantess.AllowUserToDeleteRows = False
        Me.dgvReportesVacantess.AllowUserToOrderColumns = True
        Me.dgvReportesVacantess.AllowUserToResizeColumns = False
        Me.dgvReportesVacantess.AllowUserToResizeRows = False
        Me.dgvReportesVacantess.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReportesVacantess.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvReportesVacantess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReportesVacantess.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nombree, Me.marcarr})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReportesVacantess.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReportesVacantess.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvReportesVacantess.Location = New System.Drawing.Point(36, 118)
        Me.dgvReportesVacantess.MultiSelect = False
        Me.dgvReportesVacantess.Name = "dgvReportesVacantess"
        Me.dgvReportesVacantess.Size = New System.Drawing.Size(469, 134)
        Me.dgvReportesVacantess.TabIndex = 134
        '
        'nombree
        '
        Me.nombree.DataPropertyName = "nombre"
        Me.nombree.HeaderText = "Reporte"
        Me.nombree.Name = "nombree"
        Me.nombree.ReadOnly = True
        Me.nombree.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.nombree.Width = 400
        '
        'marcarr
        '
        Me.marcarr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.marcarr.Checked = True
        Me.marcarr.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.marcarr.CheckValue = Nothing
        Me.marcarr.DataPropertyName = "marcar"
        Me.marcarr.HeaderText = ""
        Me.marcarr.Name = "marcarr"
        Me.marcarr.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(33, 102)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(101, 13)
        Me.Label22.TabIndex = 135
        Me.Label22.Text = "Reportes a generar:"
        '
        'ReflectionLabel11
        '
        '
        '
        '
        Me.ReflectionLabel11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel11.Location = New System.Drawing.Point(74, 12)
        Me.ReflectionLabel11.Name = "ReflectionLabel11"
        Me.ReflectionLabel11.Size = New System.Drawing.Size(451, 46)
        Me.ReflectionLabel11.TabIndex = 136
        Me.ReflectionLabel11.Text = "<font color=""#1F497D""><b>REPORTES DE ADMINISTRACION DE SOLICITUDES</b></font>"
        '
        'PictureBox22
        '
        Me.PictureBox22.Image = Global.PIDA.My.Resources.Resources.Reporte48
        Me.PictureBox22.Location = New System.Drawing.Point(36, 12)
        Me.PictureBox22.Name = "PictureBox22"
        Me.PictureBox22.Size = New System.Drawing.Size(32, 46)
        Me.PictureBox22.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox22.TabIndex = 137
        Me.PictureBox22.TabStop = False
        '
        'StatusStrip11
        '
        Me.StatusStrip11.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar11, Me.ToolStripStatusLabel11})
        Me.StatusStrip11.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.StatusStrip11.Location = New System.Drawing.Point(0, 302)
        Me.StatusStrip11.Name = "StatusStrip11"
        Me.StatusStrip11.Size = New System.Drawing.Size(528, 21)
        Me.StatusStrip11.TabIndex = 139
        Me.StatusStrip11.Text = "StatusStrip1"
        '
        'ToolStripProgressBar11
        '
        Me.ToolStripProgressBar11.Name = "ToolStripProgressBar11"
        Me.ToolStripProgressBar11.Size = New System.Drawing.Size(100, 15)
        '
        'ToolStripStatusLabel11
        '
        Me.ToolStripStatusLabel11.Name = "ToolStripStatusLabel11"
        Me.ToolStripStatusLabel11.Size = New System.Drawing.Size(18, 15)
        Me.ToolStripStatusLabel11.Text = " - "
        '
        'frmReporteSolicitudesVacantes
        '
        Me.ClientSize = New System.Drawing.Size(528, 323)
        Me.Controls.Add(Me.StatusStrip11)
        Me.Controls.Add(Me.PictureBox22)
        Me.Controls.Add(Me.ReflectionLabel11)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.dgvReportesVacantess)
        Me.Controls.Add(Me.btnGenerarReportee)
        Me.Controls.Add(Me.btnCerrarr)
        Me.Name = "frmReporteSolicitudesVacantes"
        Me.Text = "Reportes de Administracion de Solicitudes"
        CType(Me.dgvReportesVacantess, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox22, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip11.ResumeLayout(False)
        Me.StatusStrip11.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvReportesVacantes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnGenerarReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents marcar As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnCerrarr As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnGenerarReportee As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dgvReportesVacantess As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents nombree As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents marcarr As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ReflectionLabel11 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents PictureBox22 As System.Windows.Forms.PictureBox
    Friend WithEvents StatusStrip11 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar11 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripStatusLabel11 As System.Windows.Forms.ToolStripStatusLabel
End Class
