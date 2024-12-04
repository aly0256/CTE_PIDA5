<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFiniquitos
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFiniquitos))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.gpReportes = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.chkAll = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkTodas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.dgRetiros = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.clConfirma = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clReloj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clBaja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clMonto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clPeriodo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clTipoP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clFechaEx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clUsuarioEx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2.SuspendLayout()
        Me.gpReportes.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgRetiros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btnReporte)
        Me.GroupBox2.Controls.Add(Me.btnCerrar)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 476)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1103, 47)
        Me.GroupBox2.TabIndex = 134
        Me.GroupBox2.TabStop = False
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnReporte.Location = New System.Drawing.Point(904, 16)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(106, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 44
        Me.btnReporte.Text = "Formato"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(1016, 16)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 46
        Me.btnCerrar.Text = "Salir"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(64, 2)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(432, 40)
        Me.ReflectionLabel1.TabIndex = 132
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>GENERAR ARCHIVO DE FINIQUITOS</b></font>"
        '
        'gpReportes
        '
        Me.gpReportes.BackColor = System.Drawing.Color.Transparent
        Me.gpReportes.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpReportes.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpReportes.Controls.Add(Me.dgRetiros)
        Me.gpReportes.Controls.Add(Me.chkAll)
        Me.gpReportes.Controls.Add(Me.chkTodas)
        Me.gpReportes.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpReportes.Location = New System.Drawing.Point(7, 54)
        Me.gpReportes.Name = "gpReportes"
        Me.gpReportes.Size = New System.Drawing.Size(1103, 407)
        '
        '
        '
        Me.gpReportes.Style.BackColor = System.Drawing.Color.White
        Me.gpReportes.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpReportes.Style.BackColorGradientAngle = 90
        Me.gpReportes.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpReportes.Style.BorderBottomWidth = 1
        Me.gpReportes.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpReportes.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpReportes.Style.BorderLeftWidth = 1
        Me.gpReportes.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpReportes.Style.BorderRightWidth = 1
        Me.gpReportes.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpReportes.Style.BorderTopWidth = 1
        Me.gpReportes.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpReportes.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpReportes.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpReportes.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.gpReportes.Style.TextShadowColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.gpReportes.Style.TextShadowOffset = New System.Drawing.Point(1, 1)
        '
        '
        '
        Me.gpReportes.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpReportes.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpReportes.TabIndex = 131
        Me.gpReportes.Text = "Finiquitos"
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        '
        '
        '
        Me.chkAll.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkAll.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkAll.Location = New System.Drawing.Point(8, 16)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(104, 15)
        Me.chkAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkAll.TabIndex = 2
        Me.chkAll.Text = "Confirmar Todos"
        Me.chkAll.TextColor = System.Drawing.SystemColors.ControlText
        '
        'chkTodas
        '
        Me.chkTodas.AutoSize = True
        '
        '
        '
        Me.chkTodas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkTodas.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkTodas.Location = New System.Drawing.Point(118, 16)
        Me.chkTodas.Name = "chkTodas"
        Me.chkTodas.Size = New System.Drawing.Size(117, 15)
        Me.chkTodas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkTodas.TabIndex = 0
        Me.chkTodas.Text = "Mostrar exportados"
        Me.chkTodas.TextColor = System.Drawing.SystemColors.ControlText
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.fini_64
        Me.PictureBox1.Location = New System.Drawing.Point(7, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 133
        Me.PictureBox1.TabStop = False
        '
        'dgRetiros
        '
        Me.dgRetiros.AllowUserToAddRows = False
        Me.dgRetiros.AllowUserToDeleteRows = False
        Me.dgRetiros.AllowUserToResizeColumns = False
        Me.dgRetiros.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgRetiros.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgRetiros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgRetiros.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgRetiros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRetiros.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clConfirma, Me.clReloj, Me.clNombre, Me.clBaja, Me.clMonto, Me.clPeriodo, Me.clTipoP, Me.clFechaEx, Me.clUsuarioEx})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgRetiros.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgRetiros.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgRetiros.EnableHeadersVisualStyles = False
        Me.dgRetiros.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgRetiros.Location = New System.Drawing.Point(0, 37)
        Me.dgRetiros.MultiSelect = False
        Me.dgRetiros.Name = "dgRetiros"
        Me.dgRetiros.PaintEnhancedSelection = False
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgRetiros.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgRetiros.RowHeadersVisible = False
        Me.dgRetiros.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.dgRetiros.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgRetiros.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgRetiros.Size = New System.Drawing.Size(1093, 336)
        Me.dgRetiros.StandardTab = True
        Me.dgRetiros.TabIndex = 3
        '
        'clConfirma
        '
        Me.clConfirma.FalseValue = "0"
        Me.clConfirma.FillWeight = 47.74715!
        Me.clConfirma.HeaderText = "Confirmar"
        Me.clConfirma.Name = "clConfirma"
        Me.clConfirma.TrueValue = "1"
        '
        'clReloj
        '
        Me.clReloj.DataPropertyName = "reloj"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.clReloj.DefaultCellStyle = DataGridViewCellStyle3
        Me.clReloj.FillWeight = 58.17396!
        Me.clReloj.HeaderText = "Reloj"
        Me.clReloj.Name = "clReloj"
        Me.clReloj.ReadOnly = True
        '
        'clNombre
        '
        Me.clNombre.DataPropertyName = "nombres"
        Me.clNombre.FillWeight = 224.5167!
        Me.clNombre.HeaderText = "Nombre"
        Me.clNombre.Name = "clNombre"
        Me.clNombre.ReadOnly = True
        '
        'clBaja
        '
        Me.clBaja.DataPropertyName = "baja"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.clBaja.DefaultCellStyle = DataGridViewCellStyle4
        Me.clBaja.FillWeight = 103.9388!
        Me.clBaja.HeaderText = "Baja"
        Me.clBaja.Name = "clBaja"
        Me.clBaja.ReadOnly = True
        '
        'clMonto
        '
        Me.clMonto.DataPropertyName = "monto"
        DataGridViewCellStyle5.Format = "C2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.clMonto.DefaultCellStyle = DataGridViewCellStyle5
        Me.clMonto.FillWeight = 106.216!
        Me.clMonto.HeaderText = "Monto"
        Me.clMonto.Name = "clMonto"
        '
        'clPeriodo
        '
        Me.clPeriodo.DataPropertyName = "periodo"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.clPeriodo.DefaultCellStyle = DataGridViewCellStyle6
        Me.clPeriodo.FillWeight = 88.20986!
        Me.clPeriodo.HeaderText = "Periodo"
        Me.clPeriodo.Name = "clPeriodo"
        Me.clPeriodo.ReadOnly = True
        '
        'clTipoP
        '
        Me.clTipoP.DataPropertyName = "tipo_periodo"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.clTipoP.DefaultCellStyle = DataGridViewCellStyle7
        Me.clTipoP.FillWeight = 103.9388!
        Me.clTipoP.HeaderText = "Tipo Periodo"
        Me.clTipoP.Name = "clTipoP"
        Me.clTipoP.ReadOnly = True
        '
        'clFechaEx
        '
        Me.clFechaEx.DataPropertyName = "fecha_exportacion"
        Me.clFechaEx.FillWeight = 103.9388!
        Me.clFechaEx.HeaderText = "Fecha Exportación"
        Me.clFechaEx.Name = "clFechaEx"
        Me.clFechaEx.ReadOnly = True
        '
        'clUsuarioEx
        '
        Me.clUsuarioEx.DataPropertyName = "usuario_exportacion"
        Me.clUsuarioEx.FillWeight = 103.9388!
        Me.clUsuarioEx.HeaderText = "Usuario"
        Me.clUsuarioEx.Name = "clUsuarioEx"
        Me.clUsuarioEx.ReadOnly = True
        '
        'frmFiniquitos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1122, 529)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.gpReportes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFiniquitos"
        Me.Text = "Finiquitos"
        Me.GroupBox2.ResumeLayout(False)
        Me.gpReportes.ResumeLayout(False)
        Me.gpReportes.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgRetiros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Private WithEvents gpReportes As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents chkTodas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents chkAll As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents dgRetiros As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents clConfirma As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents clReloj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clBaja As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clMonto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clPeriodo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clTipoP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clFechaEx As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clUsuarioEx As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
