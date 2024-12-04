<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFactInt
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFactInt))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.lblCia = New DevComponents.DotNetBar.LabelX()
        Me.txtCia = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.AuxFam = New System.Windows.Forms.GroupBox()
        Me.btnReporteFactores = New DevComponents.DotNetBar.ButtonX()
        Me.btnAgregarFactores = New DevComponents.DotNetBar.ButtonX()
        Me.btnEditarFactores = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrarFactores = New DevComponents.DotNetBar.ButtonX()
        Me.btnCiasFirst = New DevComponents.DotNetBar.ButtonX()
        Me.btnCiasLast = New DevComponents.DotNetBar.ButtonX()
        Me.btnCiasNext = New DevComponents.DotNetBar.ButtonX()
        Me.btnCiasPrev = New DevComponents.DotNetBar.ButtonX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.dgFactoresIntegracion = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.GroupBox1.SuspendLayout()
        Me.AuxFam.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgFactoresIntegracion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(45, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(319, 40)
        Me.ReflectionLabel1.TabIndex = 114
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>FACTORES DE INTEGRACIÓN</b></font>"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LabelX1)
        Me.GroupBox1.Controls.Add(Me.lblCia)
        Me.GroupBox1.Controls.Add(Me.txtCia)
        Me.GroupBox1.Controls.Add(Me.txtNombre)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(715, 46)
        Me.GroupBox1.TabIndex = 113
        Me.GroupBox1.TabStop = False
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(264, 14)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(64, 23)
        Me.LabelX1.TabIndex = 37
        Me.LabelX1.Text = "Nombre"
        '
        'lblCia
        '
        '
        '
        '
        Me.lblCia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCia.Location = New System.Drawing.Point(9, 14)
        Me.lblCia.Name = "lblCia"
        Me.lblCia.Size = New System.Drawing.Size(124, 23)
        Me.lblCia.TabIndex = 36
        Me.lblCia.Text = "Cód. compañía"
        '
        'txtCia
        '
        '
        '
        '
        Me.txtCia.Border.Class = "TextBoxBorder"
        Me.txtCia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCia.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCia.Location = New System.Drawing.Point(134, 14)
        Me.txtCia.MaxLength = 3
        Me.txtCia.Name = "txtCia"
        Me.txtCia.ReadOnly = True
        Me.txtCia.Size = New System.Drawing.Size(84, 26)
        Me.txtCia.TabIndex = 0
        '
        'txtNombre
        '
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNombre.Location = New System.Drawing.Point(339, 14)
        Me.txtNombre.MaxLength = 30
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(364, 26)
        Me.txtNombre.TabIndex = 34
        '
        'AuxFam
        '
        Me.AuxFam.Controls.Add(Me.btnReporteFactores)
        Me.AuxFam.Controls.Add(Me.btnAgregarFactores)
        Me.AuxFam.Controls.Add(Me.btnEditarFactores)
        Me.AuxFam.Controls.Add(Me.btnCerrarFactores)
        Me.AuxFam.Controls.Add(Me.btnCiasFirst)
        Me.AuxFam.Controls.Add(Me.btnCiasLast)
        Me.AuxFam.Controls.Add(Me.btnCiasNext)
        Me.AuxFam.Controls.Add(Me.btnCiasPrev)
        Me.AuxFam.Location = New System.Drawing.Point(0, 324)
        Me.AuxFam.Name = "AuxFam"
        Me.AuxFam.Size = New System.Drawing.Size(742, 45)
        Me.AuxFam.TabIndex = 111
        Me.AuxFam.TabStop = False
        '
        'btnReporteFactores
        '
        Me.btnReporteFactores.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporteFactores.CausesValidation = False
        Me.btnReporteFactores.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporteFactores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporteFactores.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporteFactores.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnReporteFactores.Location = New System.Drawing.Point(413, 14)
        Me.btnReporteFactores.Name = "btnReporteFactores"
        Me.btnReporteFactores.Size = New System.Drawing.Size(78, 25)
        Me.btnReporteFactores.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporteFactores.TabIndex = 76
        Me.btnReporteFactores.Text = "Reporte"
        '
        'btnAgregarFactores
        '
        Me.btnAgregarFactores.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAgregarFactores.CausesValidation = False
        Me.btnAgregarFactores.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAgregarFactores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarFactores.Image = Global.PIDA.My.Resources.Resources.NewRecord
        Me.btnAgregarFactores.Location = New System.Drawing.Point(494, 14)
        Me.btnAgregarFactores.Name = "btnAgregarFactores"
        Me.btnAgregarFactores.Size = New System.Drawing.Size(78, 25)
        Me.btnAgregarFactores.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAgregarFactores.TabIndex = 74
        Me.btnAgregarFactores.Text = "Agregar"
        Me.btnAgregarFactores.Visible = False
        '
        'btnEditarFactores
        '
        Me.btnEditarFactores.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditarFactores.CausesValidation = False
        Me.btnEditarFactores.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditarFactores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditarFactores.Image = Global.PIDA.My.Resources.Resources.Edit
        Me.btnEditarFactores.Location = New System.Drawing.Point(575, 14)
        Me.btnEditarFactores.Name = "btnEditarFactores"
        Me.btnEditarFactores.Size = New System.Drawing.Size(78, 25)
        Me.btnEditarFactores.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditarFactores.TabIndex = 75
        Me.btnEditarFactores.Text = "Editar"
        '
        'btnCerrarFactores
        '
        Me.btnCerrarFactores.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrarFactores.CausesValidation = False
        Me.btnCerrarFactores.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrarFactores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrarFactores.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCerrarFactores.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrarFactores.Location = New System.Drawing.Point(656, 14)
        Me.btnCerrarFactores.Name = "btnCerrarFactores"
        Me.btnCerrarFactores.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrarFactores.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrarFactores.TabIndex = 77
        Me.btnCerrarFactores.Text = "Salir"
        '
        'btnCiasFirst
        '
        Me.btnCiasFirst.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCiasFirst.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCiasFirst.Image = Global.PIDA.My.Resources.Resources.First16
        Me.btnCiasFirst.Location = New System.Drawing.Point(8, 14)
        Me.btnCiasFirst.Name = "btnCiasFirst"
        Me.btnCiasFirst.Size = New System.Drawing.Size(78, 25)
        Me.btnCiasFirst.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCiasFirst.TabIndex = 69
        Me.btnCiasFirst.Text = "Inicio"
        '
        'btnCiasLast
        '
        Me.btnCiasLast.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCiasLast.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCiasLast.Image = Global.PIDA.My.Resources.Resources.Last16
        Me.btnCiasLast.Location = New System.Drawing.Point(251, 14)
        Me.btnCiasLast.Name = "btnCiasLast"
        Me.btnCiasLast.Size = New System.Drawing.Size(78, 25)
        Me.btnCiasLast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCiasLast.TabIndex = 72
        Me.btnCiasLast.Text = "Final"
        '
        'btnCiasNext
        '
        Me.btnCiasNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCiasNext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCiasNext.Image = Global.PIDA.My.Resources.Resources.Next16
        Me.btnCiasNext.Location = New System.Drawing.Point(170, 14)
        Me.btnCiasNext.Name = "btnCiasNext"
        Me.btnCiasNext.Size = New System.Drawing.Size(78, 25)
        Me.btnCiasNext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCiasNext.TabIndex = 71
        Me.btnCiasNext.Text = "Siguiente"
        '
        'btnCiasPrev
        '
        Me.btnCiasPrev.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCiasPrev.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCiasPrev.Image = Global.PIDA.My.Resources.Resources.Prev16
        Me.btnCiasPrev.Location = New System.Drawing.Point(89, 14)
        Me.btnCiasPrev.Name = "btnCiasPrev"
        Me.btnCiasPrev.Size = New System.Drawing.Size(78, 25)
        Me.btnCiasPrev.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCiasPrev.TabIndex = 70
        Me.btnCiasPrev.Text = "Anterior"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Factores24
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(27, 26)
        Me.PictureBox1.TabIndex = 115
        Me.PictureBox1.TabStop = False
        '
        'dgFactoresIntegracion
        '
        Me.dgFactoresIntegracion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgFactoresIntegracion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgFactoresIntegracion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgFactoresIntegracion.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgFactoresIntegracion.EnableHeadersVisualStyles = False
        Me.dgFactoresIntegracion.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgFactoresIntegracion.Location = New System.Drawing.Point(12, 110)
        Me.dgFactoresIntegracion.MultiSelect = False
        Me.dgFactoresIntegracion.Name = "dgFactoresIntegracion"
        Me.dgFactoresIntegracion.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgFactoresIntegracion.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgFactoresIntegracion.Size = New System.Drawing.Size(715, 208)
        Me.dgFactoresIntegracion.TabIndex = 116
        '
        'frmFactInt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(742, 369)
        Me.Controls.Add(Me.dgFactoresIntegracion)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.AuxFam)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFactInt"
        Me.Text = "Factores de integración"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.AuxFam.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgFactoresIntegracion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCia As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtCia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents AuxFam As System.Windows.Forms.GroupBox
    Friend WithEvents btnCiasFirst As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCiasLast As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCiasNext As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCiasPrev As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporteFactores As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAgregarFactores As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnEditarFactores As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrarFactores As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dgFactoresIntegracion As DevComponents.DotNetBar.Controls.DataGridViewX
End Class
