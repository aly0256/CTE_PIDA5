<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteadorNomina
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteadorNomina))
        Me.gpReportes = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.gpAvance = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.lblAvance = New System.Windows.Forms.Label()
        Me.pbAvance = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.dgReportes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FRECUENCIA = New DevComponents.DotNetBar.Controls.DataGridViewProgressBarXColumn()
        Me.FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FILTRAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USERNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.txtBusca = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.chkRecientes = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.cmbTipoReportes = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gpFiltros = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.gpFiltrosVigentes = New System.Windows.Forms.GroupBox()
        Me.lstFiltros = New System.Windows.Forms.ListBox()
        Me.Panel26 = New System.Windows.Forms.Panel()
        Me.chkTodos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel25 = New System.Windows.Forms.Panel()
        Me.Panel23 = New System.Windows.Forms.Panel()
        Me.btnSeleccionarFiltros = New DevComponents.DotNetBar.ButtonX()
        Me.chkOtrosFiltros = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel24 = New System.Windows.Forms.Panel()
        Me.Panel22 = New System.Windows.Forms.Panel()
        Me.txtBajas = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.chkBajas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.Panel21 = New System.Windows.Forms.Panel()
        Me.txtActivos = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.chkActivos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.gpOrden = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lstOrden = New System.Windows.Forms.ListBox()
        Me.Panel27 = New System.Windows.Forms.Panel()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.btnBajar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.btnSubir = New DevComponents.DotNetBar.ButtonX()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.btnOrden = New DevComponents.DotNetBar.ButtonX()
        Me.chkOtroOrden = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.sbNombre = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.chkNombre = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.sbReloj = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.chkReloj = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.gpControles = New System.Windows.Forms.GroupBox()
        Me.pnlCentrarControles = New System.Windows.Forms.Panel()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnGenerar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.bgw = New System.ComponentModel.BackgroundWorker()
        Me.bgwReporte = New System.ComponentModel.BackgroundWorker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ReflectionLabel2 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.lblCia = New System.Windows.Forms.Label()
        Me.gpPeriodos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.lstPeriodos = New System.Windows.Forms.ListBox()
        Me.splReportes = New System.Windows.Forms.SplitContainer()
        Me.pnlseparador = New System.Windows.Forms.Panel()
        Me.gpReportes.SuspendLayout()
        Me.gpAvance.SuspendLayout()
        CType(Me.dgReportes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.gpFiltros.SuspendLayout()
        Me.gpFiltrosVigentes.SuspendLayout()
        Me.Panel23.SuspendLayout()
        Me.Panel22.SuspendLayout()
        CType(Me.txtBajas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel21.SuspendLayout()
        CType(Me.txtActivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpOrden.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel17.SuspendLayout()
        Me.Panel15.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.gpControles.SuspendLayout()
        Me.pnlCentrarControles.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpPeriodos.SuspendLayout()
        CType(Me.splReportes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splReportes.Panel1.SuspendLayout()
        Me.splReportes.Panel2.SuspendLayout()
        Me.splReportes.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpReportes
        '
        Me.gpReportes.BackColor = System.Drawing.SystemColors.Control
        Me.gpReportes.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpReportes.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpReportes.Controls.Add(Me.gpAvance)
        Me.gpReportes.Controls.Add(Me.dgReportes)
        Me.gpReportes.Controls.Add(Me.Panel2)
        Me.gpReportes.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpReportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gpReportes.Location = New System.Drawing.Point(0, 0)
        Me.gpReportes.Name = "gpReportes"
        Me.gpReportes.Padding = New System.Windows.Forms.Padding(10)
        Me.gpReportes.Size = New System.Drawing.Size(914, 512)
        '
        '
        '
        Me.gpReportes.Style.BackColor = System.Drawing.SystemColors.Window
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
        Me.gpReportes.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.gpReportes.TabIndex = 114
        Me.gpReportes.Text = "Reportes disponibles"
        '
        'gpAvance
        '
        Me.gpAvance.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpAvance.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpAvance.Controls.Add(Me.lblAvance)
        Me.gpAvance.Controls.Add(Me.pbAvance)
        Me.gpAvance.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpAvance.Location = New System.Drawing.Point(214, 87)
        Me.gpAvance.Name = "gpAvance"
        Me.gpAvance.Size = New System.Drawing.Size(220, 218)
        '
        '
        '
        Me.gpAvance.Style.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.gpAvance.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Me.gpAvance.Style.BackColorGradientAngle = 90
        Me.gpAvance.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpAvance.Style.BorderBottomWidth = 2
        Me.gpAvance.Style.BorderColor = System.Drawing.SystemColors.Highlight
        Me.gpAvance.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpAvance.Style.BorderLeftWidth = 1
        Me.gpAvance.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpAvance.Style.BorderRightWidth = 1
        Me.gpAvance.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpAvance.Style.BorderTopWidth = 1
        Me.gpAvance.Style.CornerDiameter = 4
        Me.gpAvance.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpAvance.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.gpAvance.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpAvance.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpAvance.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpAvance.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpAvance.TabIndex = 274
        Me.gpAvance.Visible = False
        '
        'lblAvance
        '
        Me.lblAvance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblAvance.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblAvance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvance.Location = New System.Drawing.Point(0, 155)
        Me.lblAvance.Name = "lblAvance"
        Me.lblAvance.Size = New System.Drawing.Size(218, 60)
        Me.lblAvance.TabIndex = 271
        Me.lblAvance.Text = "Preparando datos..."
        Me.lblAvance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbAvance
        '
        Me.pbAvance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        '
        '
        '
        Me.pbAvance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pbAvance.Dock = System.Windows.Forms.DockStyle.Top
        Me.pbAvance.Location = New System.Drawing.Point(0, 0)
        Me.pbAvance.Name = "pbAvance"
        Me.pbAvance.Padding = New System.Windows.Forms.Padding(5)
        Me.pbAvance.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.pbAvance.ProgressColor = System.Drawing.Color.MediumBlue
        Me.pbAvance.ProgressTextFormat = ""
        Me.pbAvance.Size = New System.Drawing.Size(218, 152)
        Me.pbAvance.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.pbAvance.TabIndex = 270
        '
        'dgReportes
        '
        Me.dgReportes.AllowUserToAddRows = False
        Me.dgReportes.AllowUserToDeleteRows = False
        Me.dgReportes.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgReportes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgReportes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgReportes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NOMBRE, Me.Tipo, Me.FRECUENCIA, Me.FECHA, Me.FILTRAR, Me.USERNAME})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgReportes.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgReportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgReportes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgReportes.EnableHeadersVisualStyles = False
        Me.dgReportes.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgReportes.Location = New System.Drawing.Point(10, 91)
        Me.dgReportes.MultiSelect = False
        Me.dgReportes.Name = "dgReportes"
        Me.dgReportes.PaintEnhancedSelection = False
        Me.dgReportes.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgReportes.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgReportes.RowHeadersVisible = False
        Me.dgReportes.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.dgReportes.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgReportes.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgReportes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgReportes.Size = New System.Drawing.Size(884, 382)
        Me.dgReportes.StandardTab = True
        Me.dgReportes.TabIndex = 47
        '
        'NOMBRE
        '
        Me.NOMBRE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NOMBRE.DataPropertyName = "NOMBRE"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.NOMBRE.DefaultCellStyle = DataGridViewCellStyle3
        Me.NOMBRE.HeaderText = "REPORTE"
        Me.NOMBRE.Name = "NOMBRE"
        Me.NOMBRE.ReadOnly = True
        '
        'Tipo
        '
        Me.Tipo.DataPropertyName = "Tipo"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.NullValue = " "
        Me.Tipo.DefaultCellStyle = DataGridViewCellStyle4
        Me.Tipo.HeaderText = "TIPO"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        '
        'FRECUENCIA
        '
        Me.FRECUENCIA.DataPropertyName = "Frecuencia"
        Me.FRECUENCIA.HeaderText = "FRECUENCIA"
        Me.FRECUENCIA.Name = "FRECUENCIA"
        Me.FRECUENCIA.ReadOnly = True
        Me.FRECUENCIA.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FRECUENCIA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.FRECUENCIA.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.FRECUENCIA.Text = Nothing
        Me.FRECUENCIA.TextVisible = True
        '
        'FECHA
        '
        Me.FECHA.DataPropertyName = "FECHA"
        Me.FECHA.HeaderText = "ÚLTIMO ACCESO"
        Me.FECHA.Name = "FECHA"
        Me.FECHA.ReadOnly = True
        Me.FECHA.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'FILTRAR
        '
        Me.FILTRAR.DataPropertyName = "FILTRAR"
        Me.FILTRAR.HeaderText = "FILTRAR"
        Me.FILTRAR.Name = "FILTRAR"
        Me.FILTRAR.ReadOnly = True
        Me.FILTRAR.Visible = False
        '
        'USERNAME
        '
        Me.USERNAME.DataPropertyName = "USERNAME"
        Me.USERNAME.HeaderText = "USERNAME"
        Me.USERNAME.Name = "USERNAME"
        Me.USERNAME.ReadOnly = True
        Me.USERNAME.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Window
        Me.Panel2.Controls.Add(Me.Panel9)
        Me.Panel2.Controls.Add(Me.Panel8)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(10, 10)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel2.Size = New System.Drawing.Size(884, 81)
        Me.Panel2.TabIndex = 276
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.txtBusca)
        Me.Panel9.Controls.Add(Me.Label2)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(10, 44)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(864, 24)
        Me.Panel9.TabIndex = 283
        '
        'txtBusca
        '
        '
        '
        '
        Me.txtBusca.Border.Class = "TextBoxBorder"
        Me.txtBusca.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBusca.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtBusca.Location = New System.Drawing.Point(57, 0)
        Me.txtBusca.Name = "txtBusca"
        Me.txtBusca.PreventEnterBeep = True
        Me.txtBusca.Size = New System.Drawing.Size(557, 20)
        Me.txtBusca.TabIndex = 279
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 24)
        Me.Label2.TabIndex = 280
        Me.Label2.Text = "Reporte:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel8
        '
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(10, 34)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(864, 10)
        Me.Panel8.TabIndex = 282
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.chkRecientes)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Controls.Add(Me.cmbTipoReportes)
        Me.Panel6.Controls.Add(Me.Label1)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(10, 10)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(864, 24)
        Me.Panel6.TabIndex = 281
        '
        'chkRecientes
        '
        Me.chkRecientes.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkRecientes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkRecientes.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkRecientes.Checked = True
        Me.chkRecientes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRecientes.CheckValue = "Y"
        Me.chkRecientes.Dock = System.Windows.Forms.DockStyle.Left
        Me.chkRecientes.Location = New System.Drawing.Point(329, 0)
        Me.chkRecientes.Name = "chkRecientes"
        Me.chkRecientes.Size = New System.Drawing.Size(115, 24)
        Me.chkRecientes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkRecientes.TabIndex = 45
        Me.chkRecientes.Text = "Reportes recientes"
        Me.chkRecientes.TextColor = System.Drawing.SystemColors.ControlText
        Me.chkRecientes.Visible = False
        '
        'Panel7
        '
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(314, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(15, 24)
        Me.Panel7.TabIndex = 52
        '
        'cmbTipoReportes
        '
        Me.cmbTipoReportes.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbTipoReportes.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbTipoReportes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbTipoReportes.ButtonDropDown.Visible = True
        Me.cmbTipoReportes.Columns.Add(Me.ColumnHeader1)
        Me.cmbTipoReportes.Columns.Add(Me.ColumnHeader2)
        Me.cmbTipoReportes.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmbTipoReportes.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbTipoReportes.Location = New System.Drawing.Point(115, 0)
        Me.cmbTipoReportes.Name = "cmbTipoReportes"
        Me.cmbTipoReportes.Size = New System.Drawing.Size(199, 24)
        Me.cmbTipoReportes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipoReportes.TabIndex = 50
        Me.cmbTipoReportes.ValueMember = "tipo"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "tipo"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Tipo"
        Me.ColumnHeader1.Width.Absolute = 30
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "nombre"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Descripción"
        Me.ColumnHeader2.Width.Absolute = 150
        Me.ColumnHeader2.Width.AutoSize = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 24)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Mostrar reportes tipo:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpFiltros
        '
        Me.gpFiltros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpFiltros.BackColor = System.Drawing.SystemColors.Control
        Me.gpFiltros.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpFiltros.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpFiltros.Controls.Add(Me.gpFiltrosVigentes)
        Me.gpFiltros.Controls.Add(Me.Panel26)
        Me.gpFiltros.Controls.Add(Me.chkTodos)
        Me.gpFiltros.Controls.Add(Me.Panel25)
        Me.gpFiltros.Controls.Add(Me.Panel23)
        Me.gpFiltros.Controls.Add(Me.Panel24)
        Me.gpFiltros.Controls.Add(Me.Panel22)
        Me.gpFiltros.Controls.Add(Me.Panel20)
        Me.gpFiltros.Controls.Add(Me.Panel21)
        Me.gpFiltros.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpFiltros.Location = New System.Drawing.Point(0, 0)
        Me.gpFiltros.Name = "gpFiltros"
        Me.gpFiltros.Padding = New System.Windows.Forms.Padding(10)
        Me.gpFiltros.Size = New System.Drawing.Size(345, 252)
        '
        '
        '
        Me.gpFiltros.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpFiltros.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpFiltros.Style.BackColorGradientAngle = 90
        Me.gpFiltros.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpFiltros.Style.BorderBottomWidth = 1
        Me.gpFiltros.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpFiltros.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpFiltros.Style.BorderLeftWidth = 1
        Me.gpFiltros.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpFiltros.Style.BorderRightWidth = 1
        Me.gpFiltros.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpFiltros.Style.BorderTopWidth = 1
        Me.gpFiltros.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpFiltros.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.gpFiltros.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpFiltros.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.gpFiltros.Style.TextShadowColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gpFiltros.Style.TextShadowOffset = New System.Drawing.Point(1, 1)
        '
        '
        '
        Me.gpFiltros.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpFiltros.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpFiltros.TabIndex = 115
        Me.gpFiltros.Text = "Filtros"
        '
        'gpFiltrosVigentes
        '
        Me.gpFiltrosVigentes.BackColor = System.Drawing.SystemColors.Window
        Me.gpFiltrosVigentes.Controls.Add(Me.lstFiltros)
        Me.gpFiltrosVigentes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gpFiltrosVigentes.Location = New System.Drawing.Point(10, 116)
        Me.gpFiltrosVigentes.Name = "gpFiltrosVigentes"
        Me.gpFiltrosVigentes.Padding = New System.Windows.Forms.Padding(10)
        Me.gpFiltrosVigentes.Size = New System.Drawing.Size(315, 97)
        Me.gpFiltrosVigentes.TabIndex = 46
        Me.gpFiltrosVigentes.TabStop = False
        Me.gpFiltrosVigentes.Text = "Filtros vigentes"
        '
        'lstFiltros
        '
        Me.lstFiltros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstFiltros.FormattingEnabled = True
        Me.lstFiltros.HorizontalScrollbar = True
        Me.lstFiltros.Location = New System.Drawing.Point(10, 23)
        Me.lstFiltros.Name = "lstFiltros"
        Me.lstFiltros.Size = New System.Drawing.Size(295, 64)
        Me.lstFiltros.TabIndex = 42
        '
        'Panel26
        '
        Me.Panel26.BackColor = System.Drawing.Color.Transparent
        Me.Panel26.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel26.Location = New System.Drawing.Point(10, 106)
        Me.Panel26.Name = "Panel26"
        Me.Panel26.Size = New System.Drawing.Size(315, 10)
        Me.Panel26.TabIndex = 291
        '
        'chkTodos
        '
        Me.chkTodos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkTodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkTodos.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkTodos.Checked = True
        Me.chkTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodos.CheckValue = "Y"
        Me.chkTodos.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkTodos.Location = New System.Drawing.Point(10, 91)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(315, 15)
        Me.chkTodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkTodos.TabIndex = 44
        Me.chkTodos.Text = "Todos los empleados (limpiar filtros)"
        Me.chkTodos.TextColor = System.Drawing.SystemColors.ControlText
        '
        'Panel25
        '
        Me.Panel25.BackColor = System.Drawing.Color.Transparent
        Me.Panel25.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel25.Location = New System.Drawing.Point(10, 84)
        Me.Panel25.Name = "Panel25"
        Me.Panel25.Size = New System.Drawing.Size(315, 7)
        Me.Panel25.TabIndex = 290
        '
        'Panel23
        '
        Me.Panel23.BackColor = System.Drawing.Color.Transparent
        Me.Panel23.Controls.Add(Me.btnSeleccionarFiltros)
        Me.Panel23.Controls.Add(Me.chkOtrosFiltros)
        Me.Panel23.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel23.Location = New System.Drawing.Point(10, 64)
        Me.Panel23.Name = "Panel23"
        Me.Panel23.Size = New System.Drawing.Size(315, 20)
        Me.Panel23.TabIndex = 289
        '
        'btnSeleccionarFiltros
        '
        Me.btnSeleccionarFiltros.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSeleccionarFiltros.CausesValidation = False
        Me.btnSeleccionarFiltros.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSeleccionarFiltros.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSeleccionarFiltros.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSeleccionarFiltros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSeleccionarFiltros.Image = Global.PIDA.My.Resources.Resources.filtro_
        Me.btnSeleccionarFiltros.ImageFixedSize = New System.Drawing.Size(15, 15)
        Me.btnSeleccionarFiltros.ImageTextSpacing = 3
        Me.btnSeleccionarFiltros.Location = New System.Drawing.Point(99, 0)
        Me.btnSeleccionarFiltros.Name = "btnSeleccionarFiltros"
        Me.btnSeleccionarFiltros.Size = New System.Drawing.Size(97, 20)
        Me.btnSeleccionarFiltros.TabIndex = 47
        Me.btnSeleccionarFiltros.Text = "Seleccionar"
        Me.btnSeleccionarFiltros.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'chkOtrosFiltros
        '
        Me.chkOtrosFiltros.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkOtrosFiltros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkOtrosFiltros.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkOtrosFiltros.Dock = System.Windows.Forms.DockStyle.Left
        Me.chkOtrosFiltros.Location = New System.Drawing.Point(0, 0)
        Me.chkOtrosFiltros.Name = "chkOtrosFiltros"
        Me.chkOtrosFiltros.Size = New System.Drawing.Size(99, 20)
        Me.chkOtrosFiltros.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkOtrosFiltros.TabIndex = 43
        Me.chkOtrosFiltros.Text = "Otros filtros"
        Me.chkOtrosFiltros.TextColor = System.Drawing.SystemColors.ControlText
        '
        'Panel24
        '
        Me.Panel24.BackColor = System.Drawing.Color.Transparent
        Me.Panel24.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel24.Location = New System.Drawing.Point(10, 57)
        Me.Panel24.Name = "Panel24"
        Me.Panel24.Size = New System.Drawing.Size(315, 7)
        Me.Panel24.TabIndex = 288
        '
        'Panel22
        '
        Me.Panel22.BackColor = System.Drawing.Color.Transparent
        Me.Panel22.Controls.Add(Me.txtBajas)
        Me.Panel22.Controls.Add(Me.chkBajas)
        Me.Panel22.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel22.Location = New System.Drawing.Point(10, 37)
        Me.Panel22.Name = "Panel22"
        Me.Panel22.Size = New System.Drawing.Size(315, 20)
        Me.Panel22.TabIndex = 287
        '
        'txtBajas
        '
        '
        '
        '
        Me.txtBajas.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtBajas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBajas.ButtonDropDown.Visible = True
        Me.txtBajas.DisabledForeColor = System.Drawing.Color.Black
        Me.txtBajas.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtBajas.FocusHighlightEnabled = True
        Me.txtBajas.IsPopupCalendarOpen = False
        Me.txtBajas.Location = New System.Drawing.Point(99, 0)
        '
        '
        '
        Me.txtBajas.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtBajas.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtBajas.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBajas.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtBajas.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtBajas.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBajas.MonthCalendar.DisplayMonth = New Date(2007, 10, 1, 0, 0, 0, 0)
        Me.txtBajas.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtBajas.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtBajas.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtBajas.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtBajas.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtBajas.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBajas.MonthCalendar.TodayButtonVisible = True
        Me.txtBajas.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtBajas.Name = "txtBajas"
        Me.txtBajas.Size = New System.Drawing.Size(97, 20)
        Me.txtBajas.TabIndex = 3
        '
        'chkBajas
        '
        Me.chkBajas.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkBajas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkBajas.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkBajas.Dock = System.Windows.Forms.DockStyle.Left
        Me.chkBajas.Location = New System.Drawing.Point(0, 0)
        Me.chkBajas.Name = "chkBajas"
        Me.chkBajas.Size = New System.Drawing.Size(99, 20)
        Me.chkBajas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkBajas.TabIndex = 1
        Me.chkBajas.Text = "Bajas al día"
        Me.chkBajas.TextColor = System.Drawing.SystemColors.ControlText
        '
        'Panel20
        '
        Me.Panel20.BackColor = System.Drawing.Color.Transparent
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel20.Location = New System.Drawing.Point(10, 30)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(315, 7)
        Me.Panel20.TabIndex = 286
        '
        'Panel21
        '
        Me.Panel21.BackColor = System.Drawing.Color.Transparent
        Me.Panel21.Controls.Add(Me.txtActivos)
        Me.Panel21.Controls.Add(Me.chkActivos)
        Me.Panel21.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel21.Location = New System.Drawing.Point(10, 10)
        Me.Panel21.Name = "Panel21"
        Me.Panel21.Size = New System.Drawing.Size(315, 20)
        Me.Panel21.TabIndex = 285
        '
        'txtActivos
        '
        '
        '
        '
        Me.txtActivos.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtActivos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtActivos.ButtonDropDown.Visible = True
        Me.txtActivos.DisabledForeColor = System.Drawing.Color.Black
        Me.txtActivos.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtActivos.FocusHighlightEnabled = True
        Me.txtActivos.IsPopupCalendarOpen = False
        Me.txtActivos.Location = New System.Drawing.Point(99, 0)
        '
        '
        '
        Me.txtActivos.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtActivos.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtActivos.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtActivos.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtActivos.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtActivos.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtActivos.MonthCalendar.DisplayMonth = New Date(2007, 10, 1, 0, 0, 0, 0)
        Me.txtActivos.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtActivos.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtActivos.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtActivos.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtActivos.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtActivos.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtActivos.MonthCalendar.TodayButtonVisible = True
        Me.txtActivos.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtActivos.Name = "txtActivos"
        Me.txtActivos.Size = New System.Drawing.Size(97, 20)
        Me.txtActivos.TabIndex = 2
        '
        'chkActivos
        '
        Me.chkActivos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkActivos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkActivos.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkActivos.Dock = System.Windows.Forms.DockStyle.Left
        Me.chkActivos.Location = New System.Drawing.Point(0, 0)
        Me.chkActivos.Name = "chkActivos"
        Me.chkActivos.Size = New System.Drawing.Size(99, 20)
        Me.chkActivos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkActivos.TabIndex = 0
        Me.chkActivos.Text = "Activos al día"
        Me.chkActivos.TextColor = System.Drawing.SystemColors.ControlText
        '
        'gpOrden
        '
        Me.gpOrden.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpOrden.BackColor = System.Drawing.SystemColors.Control
        Me.gpOrden.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpOrden.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpOrden.Controls.Add(Me.GroupBox1)
        Me.gpOrden.Controls.Add(Me.Panel16)
        Me.gpOrden.Controls.Add(Me.Panel15)
        Me.gpOrden.Controls.Add(Me.Panel14)
        Me.gpOrden.Controls.Add(Me.Panel12)
        Me.gpOrden.Controls.Add(Me.Panel11)
        Me.gpOrden.Controls.Add(Me.Panel10)
        Me.gpOrden.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpOrden.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpOrden.Location = New System.Drawing.Point(0, 264)
        Me.gpOrden.Name = "gpOrden"
        Me.gpOrden.Padding = New System.Windows.Forms.Padding(10)
        Me.gpOrden.Size = New System.Drawing.Size(345, 247)
        '
        '
        '
        Me.gpOrden.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpOrden.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpOrden.Style.BackColorGradientAngle = 90
        Me.gpOrden.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpOrden.Style.BorderBottomWidth = 1
        Me.gpOrden.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpOrden.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpOrden.Style.BorderLeftWidth = 1
        Me.gpOrden.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpOrden.Style.BorderRightWidth = 1
        Me.gpOrden.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpOrden.Style.BorderTopWidth = 1
        Me.gpOrden.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpOrden.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.gpOrden.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpOrden.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.gpOrden.Style.TextShadowColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gpOrden.Style.TextShadowOffset = New System.Drawing.Point(1, 1)
        '
        '
        '
        Me.gpOrden.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpOrden.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpOrden.TabIndex = 116
        Me.gpOrden.Text = "Orden"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Window
        Me.GroupBox1.Controls.Add(Me.lstOrden)
        Me.GroupBox1.Controls.Add(Me.Panel27)
        Me.GroupBox1.Controls.Add(Me.Panel17)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(10, 94)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(10)
        Me.GroupBox1.Size = New System.Drawing.Size(315, 114)
        Me.GroupBox1.TabIndex = 46
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Orden seleccionado"
        '
        'lstOrden
        '
        Me.lstOrden.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstOrden.FormattingEnabled = True
        Me.lstOrden.HorizontalScrollbar = True
        Me.lstOrden.Location = New System.Drawing.Point(10, 23)
        Me.lstOrden.Name = "lstOrden"
        Me.lstOrden.Size = New System.Drawing.Size(258, 81)
        Me.lstOrden.TabIndex = 42
        '
        'Panel27
        '
        Me.Panel27.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel27.Location = New System.Drawing.Point(268, 23)
        Me.Panel27.Name = "Panel27"
        Me.Panel27.Size = New System.Drawing.Size(10, 81)
        Me.Panel27.TabIndex = 52
        '
        'Panel17
        '
        Me.Panel17.Controls.Add(Me.btnBajar)
        Me.Panel17.Controls.Add(Me.Panel18)
        Me.Panel17.Controls.Add(Me.btnSubir)
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel17.Location = New System.Drawing.Point(278, 23)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Padding = New System.Windows.Forms.Padding(0, 15, 0, 0)
        Me.Panel17.Size = New System.Drawing.Size(27, 81)
        Me.Panel17.TabIndex = 51
        '
        'btnBajar
        '
        Me.btnBajar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBajar.CausesValidation = False
        Me.btnBajar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBajar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnBajar.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnBajar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBajar.Image = Global.PIDA.My.Resources.Resources.abajo_
        Me.btnBajar.ImageFixedSize = New System.Drawing.Size(12, 12)
        Me.btnBajar.Location = New System.Drawing.Point(0, 45)
        Me.btnBajar.Name = "btnBajar"
        Me.btnBajar.Size = New System.Drawing.Size(27, 20)
        Me.btnBajar.TabIndex = 50
        Me.btnBajar.Tooltip = "Bajar"
        '
        'Panel18
        '
        Me.Panel18.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel18.Location = New System.Drawing.Point(0, 35)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(27, 10)
        Me.Panel18.TabIndex = 50
        '
        'btnSubir
        '
        Me.btnSubir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSubir.CausesValidation = False
        Me.btnSubir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSubir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSubir.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSubir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubir.Image = Global.PIDA.My.Resources.Resources.arriba_
        Me.btnSubir.ImageFixedSize = New System.Drawing.Size(12, 12)
        Me.btnSubir.Location = New System.Drawing.Point(0, 15)
        Me.btnSubir.Name = "btnSubir"
        Me.btnSubir.Size = New System.Drawing.Size(27, 20)
        Me.btnSubir.TabIndex = 49
        Me.btnSubir.Tooltip = "Subir"
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.Transparent
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel16.Location = New System.Drawing.Point(10, 84)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(315, 10)
        Me.Panel16.TabIndex = 288
        '
        'Panel15
        '
        Me.Panel15.BackColor = System.Drawing.Color.Transparent
        Me.Panel15.Controls.Add(Me.btnOrden)
        Me.Panel15.Controls.Add(Me.chkOtroOrden)
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel15.Location = New System.Drawing.Point(10, 64)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(315, 20)
        Me.Panel15.TabIndex = 287
        '
        'btnOrden
        '
        Me.btnOrden.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnOrden.CausesValidation = False
        Me.btnOrden.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnOrden.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOrden.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOrden.Image = Global.PIDA.My.Resources.Resources.orden_
        Me.btnOrden.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnOrden.Location = New System.Drawing.Point(113, 0)
        Me.btnOrden.Name = "btnOrden"
        Me.btnOrden.Size = New System.Drawing.Size(97, 20)
        Me.btnOrden.TabIndex = 48
        Me.btnOrden.Text = "Seleccionar"
        Me.btnOrden.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'chkOtroOrden
        '
        Me.chkOtroOrden.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkOtroOrden.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkOtroOrden.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkOtroOrden.Dock = System.Windows.Forms.DockStyle.Left
        Me.chkOtroOrden.Location = New System.Drawing.Point(0, 0)
        Me.chkOtroOrden.Name = "chkOtroOrden"
        Me.chkOtroOrden.Size = New System.Drawing.Size(113, 20)
        Me.chkOtroOrden.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkOtroOrden.TabIndex = 43
        Me.chkOtroOrden.Text = "Otro orden"
        Me.chkOtroOrden.TextColor = System.Drawing.SystemColors.ControlText
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.Transparent
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel14.Location = New System.Drawing.Point(10, 57)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(315, 7)
        Me.Panel14.TabIndex = 286
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.Transparent
        Me.Panel12.Controls.Add(Me.sbNombre)
        Me.Panel12.Controls.Add(Me.chkNombre)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel12.Location = New System.Drawing.Point(10, 37)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(315, 20)
        Me.Panel12.TabIndex = 285
        '
        'sbNombre
        '
        '
        '
        '
        Me.sbNombre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sbNombre.Dock = System.Windows.Forms.DockStyle.Left
        Me.sbNombre.Location = New System.Drawing.Point(113, 0)
        Me.sbNombre.Name = "sbNombre"
        Me.sbNombre.OffBackColor = System.Drawing.Color.PowderBlue
        Me.sbNombre.OffText = "Descendente"
        Me.sbNombre.OffTextColor = System.Drawing.Color.Black
        Me.sbNombre.OnBackColor = System.Drawing.Color.Honeydew
        Me.sbNombre.OnText = "Ascendente"
        Me.sbNombre.OnTextColor = System.Drawing.Color.Black
        Me.sbNombre.Size = New System.Drawing.Size(97, 20)
        Me.sbNombre.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sbNombre.SwitchBackColor = System.Drawing.Color.RoyalBlue
        Me.sbNombre.SwitchFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sbNombre.SwitchWidth = 25
        Me.sbNombre.TabIndex = 47
        Me.sbNombre.Value = True
        Me.sbNombre.ValueObject = "Y"
        '
        'chkNombre
        '
        Me.chkNombre.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkNombre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkNombre.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkNombre.Dock = System.Windows.Forms.DockStyle.Left
        Me.chkNombre.Location = New System.Drawing.Point(0, 0)
        Me.chkNombre.Name = "chkNombre"
        Me.chkNombre.Size = New System.Drawing.Size(113, 20)
        Me.chkNombre.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkNombre.TabIndex = 1
        Me.chkNombre.Text = "Nombre completo"
        Me.chkNombre.TextColor = System.Drawing.SystemColors.ControlText
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.Transparent
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(10, 30)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(315, 7)
        Me.Panel11.TabIndex = 284
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Transparent
        Me.Panel10.Controls.Add(Me.sbReloj)
        Me.Panel10.Controls.Add(Me.chkReloj)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(10, 10)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(315, 20)
        Me.Panel10.TabIndex = 283
        '
        'sbReloj
        '
        '
        '
        '
        Me.sbReloj.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sbReloj.Dock = System.Windows.Forms.DockStyle.Left
        Me.sbReloj.Location = New System.Drawing.Point(113, 0)
        Me.sbReloj.Name = "sbReloj"
        Me.sbReloj.OffBackColor = System.Drawing.Color.PowderBlue
        Me.sbReloj.OffText = "Descendente"
        Me.sbReloj.OffTextColor = System.Drawing.Color.Black
        Me.sbReloj.OnBackColor = System.Drawing.Color.Honeydew
        Me.sbReloj.OnText = "Ascendente"
        Me.sbReloj.OnTextColor = System.Drawing.Color.Black
        Me.sbReloj.Size = New System.Drawing.Size(97, 20)
        Me.sbReloj.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sbReloj.SwitchBackColor = System.Drawing.Color.RoyalBlue
        Me.sbReloj.SwitchFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sbReloj.SwitchWidth = 25
        Me.sbReloj.TabIndex = 43
        Me.sbReloj.Value = True
        Me.sbReloj.ValueObject = "Y"
        '
        'chkReloj
        '
        Me.chkReloj.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkReloj.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkReloj.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkReloj.Dock = System.Windows.Forms.DockStyle.Left
        Me.chkReloj.Location = New System.Drawing.Point(0, 0)
        Me.chkReloj.Name = "chkReloj"
        Me.chkReloj.Size = New System.Drawing.Size(113, 20)
        Me.chkReloj.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkReloj.TabIndex = 0
        Me.chkReloj.Text = "Reloj"
        Me.chkReloj.TextColor = System.Drawing.SystemColors.ControlText
        '
        'gpControles
        '
        Me.gpControles.BackColor = System.Drawing.SystemColors.Control
        Me.gpControles.Controls.Add(Me.pnlCentrarControles)
        Me.gpControles.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gpControles.Location = New System.Drawing.Point(10, 611)
        Me.gpControles.Name = "gpControles"
        Me.gpControles.Size = New System.Drawing.Size(1263, 47)
        Me.gpControles.TabIndex = 119
        Me.gpControles.TabStop = False
        '
        'pnlCentrarControles
        '
        Me.pnlCentrarControles.Controls.Add(Me.btnBorrar)
        Me.pnlCentrarControles.Controls.Add(Me.Panel4)
        Me.pnlCentrarControles.Controls.Add(Me.btnNuevo)
        Me.pnlCentrarControles.Controls.Add(Me.Panel3)
        Me.pnlCentrarControles.Controls.Add(Me.btnGenerar)
        Me.pnlCentrarControles.Controls.Add(Me.Panel13)
        Me.pnlCentrarControles.Controls.Add(Me.btnCancelar)
        Me.pnlCentrarControles.Location = New System.Drawing.Point(442, 6)
        Me.pnlCentrarControles.Name = "pnlCentrarControles"
        Me.pnlCentrarControles.Padding = New System.Windows.Forms.Padding(10, 8, 10, 8)
        Me.pnlCentrarControles.Size = New System.Drawing.Size(468, 41)
        Me.pnlCentrarControles.TabIndex = 5
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = Global.PIDA.My.Resources.Resources.cancel_
        Me.btnBorrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBorrar.ImageTextSpacing = 3
        Me.btnBorrar.Location = New System.Drawing.Point(13, 8)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(106, 25)
        Me.btnBorrar.TabIndex = 4
        Me.btnBorrar.Text = "Borrar"
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(119, 8)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(7, 25)
        Me.Panel4.TabIndex = 264
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.Wizard16
        Me.btnNuevo.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnNuevo.Location = New System.Drawing.Point(126, 8)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(106, 25)
        Me.btnNuevo.TabIndex = 3
        Me.btnNuevo.Text = "Crear nuevo"
        Me.btnNuevo.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(232, 8)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(7, 25)
        Me.Panel3.TabIndex = 263
        '
        'btnGenerar
        '
        Me.btnGenerar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGenerar.CausesValidation = False
        Me.btnGenerar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGenerar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnGenerar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Image = Global.PIDA.My.Resources.Resources.imprime_
        Me.btnGenerar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnGenerar.ImageTextSpacing = 3
        Me.btnGenerar.Location = New System.Drawing.Point(239, 8)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(106, 25)
        Me.btnGenerar.TabIndex = 0
        Me.btnGenerar.Text = "Generar"
        '
        'Panel13
        '
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel13.Location = New System.Drawing.Point(345, 8)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(7, 25)
        Me.Panel13.TabIndex = 262
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.salir_
        Me.btnCancelar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCancelar.ImageTextSpacing = 3
        Me.btnCancelar.Location = New System.Drawing.Point(352, 8)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(106, 25)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cerrar"
        '
        'bgw
        '
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ReflectionLabel2)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.Line1)
        Me.Panel1.Controls.Add(Me.lblCia)
        Me.Panel1.Controls.Add(Me.gpPeriodos)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(10, 10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.Panel1.Size = New System.Drawing.Size(1263, 89)
        Me.Panel1.TabIndex = 124
        '
        'ReflectionLabel2
        '
        '
        '
        '
        Me.ReflectionLabel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel2.BackgroundStyle.PaddingLeft = 10
        Me.ReflectionLabel2.BackgroundStyle.PaddingTop = 10
        Me.ReflectionLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReflectionLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel2.Location = New System.Drawing.Point(48, 0)
        Me.ReflectionLabel2.Name = "ReflectionLabel2"
        Me.ReflectionLabel2.Size = New System.Drawing.Size(870, 51)
        Me.ReflectionLabel2.TabIndex = 285
        Me.ReflectionLabel2.Text = "<font color=""#1F497D""><b>REPORTEADOR DE NÓMINA</b></font>"
        '
        'Panel5
        '
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(38, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(10, 51)
        Me.Panel5.TabIndex = 284
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox2.Image = Global.PIDA.My.Resources.Resources.imprime_
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(38, 51)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 283
        Me.PictureBox2.TabStop = False
        '
        'Line1
        '
        Me.Line1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Line1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Line1.Location = New System.Drawing.Point(0, 51)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(918, 10)
        Me.Line1.TabIndex = 282
        Me.Line1.Text = "Line1"
        '
        'lblCia
        '
        Me.lblCia.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblCia.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCia.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblCia.Location = New System.Drawing.Point(0, 61)
        Me.lblCia.Name = "lblCia"
        Me.lblCia.Size = New System.Drawing.Size(918, 23)
        Me.lblCia.TabIndex = 281
        Me.lblCia.Text = "COMPAÑIA"
        Me.lblCia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'gpPeriodos
        '
        Me.gpPeriodos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpPeriodos.BackColor = System.Drawing.SystemColors.Control
        Me.gpPeriodos.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpPeriodos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpPeriodos.Controls.Add(Me.lstPeriodos)
        Me.gpPeriodos.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpPeriodos.Dock = System.Windows.Forms.DockStyle.Right
        Me.gpPeriodos.Location = New System.Drawing.Point(918, 0)
        Me.gpPeriodos.Name = "gpPeriodos"
        Me.gpPeriodos.Padding = New System.Windows.Forms.Padding(5)
        Me.gpPeriodos.Size = New System.Drawing.Size(345, 84)
        '
        '
        '
        Me.gpPeriodos.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpPeriodos.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpPeriodos.Style.BackColorGradientAngle = 90
        Me.gpPeriodos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpPeriodos.Style.BorderBottomWidth = 1
        Me.gpPeriodos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpPeriodos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpPeriodos.Style.BorderLeftWidth = 1
        Me.gpPeriodos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpPeriodos.Style.BorderRightWidth = 1
        Me.gpPeriodos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpPeriodos.Style.BorderTopWidth = 1
        Me.gpPeriodos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpPeriodos.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold)
        Me.gpPeriodos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpPeriodos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.gpPeriodos.Style.TextShadowColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gpPeriodos.Style.TextShadowOffset = New System.Drawing.Point(1, 1)
        '
        '
        '
        Me.gpPeriodos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpPeriodos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpPeriodos.TabIndex = 280
        Me.gpPeriodos.Text = "Periodos"
        '
        'lstPeriodos
        '
        Me.lstPeriodos.BackColor = System.Drawing.SystemColors.Highlight
        Me.lstPeriodos.ColumnWidth = 70
        Me.lstPeriodos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstPeriodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPeriodos.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lstPeriodos.FormattingEnabled = True
        Me.lstPeriodos.Location = New System.Drawing.Point(5, 5)
        Me.lstPeriodos.MultiColumn = True
        Me.lstPeriodos.Name = "lstPeriodos"
        Me.lstPeriodos.Size = New System.Drawing.Size(325, 45)
        Me.lstPeriodos.TabIndex = 123
        '
        'splReportes
        '
        Me.splReportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splReportes.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.splReportes.Location = New System.Drawing.Point(10, 99)
        Me.splReportes.Name = "splReportes"
        '
        'splReportes.Panel1
        '
        Me.splReportes.Panel1.Controls.Add(Me.gpReportes)
        '
        'splReportes.Panel2
        '
        Me.splReportes.Panel2.Controls.Add(Me.gpOrden)
        Me.splReportes.Panel2.Controls.Add(Me.pnlseparador)
        Me.splReportes.Panel2.Controls.Add(Me.gpFiltros)
        Me.splReportes.Size = New System.Drawing.Size(1263, 512)
        Me.splReportes.SplitterDistance = 914
        Me.splReportes.TabIndex = 276
        '
        'pnlseparador
        '
        Me.pnlseparador.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlseparador.Location = New System.Drawing.Point(0, 252)
        Me.pnlseparador.Name = "pnlseparador"
        Me.pnlseparador.Size = New System.Drawing.Size(345, 12)
        Me.pnlseparador.TabIndex = 118
        '
        'frmReporteadorNomina
        '
        Me.AcceptButton = Me.btnGenerar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(1283, 668)
        Me.Controls.Add(Me.splReportes)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gpControles)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReporteadorNomina"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.Text = "Reporteador"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.gpReportes.ResumeLayout(False)
        Me.gpAvance.ResumeLayout(False)
        CType(Me.dgReportes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.gpFiltros.ResumeLayout(False)
        Me.gpFiltrosVigentes.ResumeLayout(False)
        Me.Panel23.ResumeLayout(False)
        Me.Panel22.ResumeLayout(False)
        CType(Me.txtBajas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel21.ResumeLayout(False)
        CType(Me.txtActivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpOrden.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel17.ResumeLayout(False)
        Me.Panel15.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.gpControles.ResumeLayout(False)
        Me.pnlCentrarControles.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpPeriodos.ResumeLayout(False)
        Me.splReportes.Panel1.ResumeLayout(False)
        Me.splReportes.Panel2.ResumeLayout(False)
        CType(Me.splReportes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splReportes.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents gpReportes As DevComponents.DotNetBar.Controls.GroupPanel
    Private WithEvents gpFiltros As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents chkBajas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkActivos As DevComponents.DotNetBar.Controls.CheckBoxX
    Private WithEvents txtBajas As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Private WithEvents txtActivos As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents lstFiltros As System.Windows.Forms.ListBox
    Friend WithEvents chkTodos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkOtrosFiltros As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents gpFiltrosVigentes As System.Windows.Forms.GroupBox
    Private WithEvents gpOrden As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents sbReloj As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lstOrden As System.Windows.Forms.ListBox
    Friend WithEvents chkOtroOrden As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkNombre As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkReloj As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents sbNombre As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents gpControles As System.Windows.Forms.GroupBox
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnGenerar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSeleccionarFiltros As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnOrden As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSubir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBajar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dgReportes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents bgw As System.ComponentModel.BackgroundWorker
    Friend WithEvents gpAvance As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lblAvance As System.Windows.Forms.Label
    Friend WithEvents pbAvance As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents bgwReporte As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoReportes As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NOMBRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FRECUENCIA As DevComponents.DotNetBar.Controls.DataGridViewProgressBarXColumn
    Friend WithEvents FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FILTRAR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USERNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents splReportes As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBusca As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents pnlCentrarControles As System.Windows.Forms.Panel
    Friend WithEvents pnlseparador As System.Windows.Forms.Panel
    Private WithEvents gpPeriodos As DevComponents.DotNetBar.Controls.GroupPanel
    Public WithEvents lstPeriodos As System.Windows.Forms.ListBox
    Friend WithEvents lblCia As System.Windows.Forms.Label
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents chkRecientes As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents ReflectionLabel2 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Panel17 As System.Windows.Forms.Panel
    Friend WithEvents Panel18 As System.Windows.Forms.Panel
    Friend WithEvents Panel26 As System.Windows.Forms.Panel
    Friend WithEvents Panel25 As System.Windows.Forms.Panel
    Friend WithEvents Panel23 As System.Windows.Forms.Panel
    Friend WithEvents Panel24 As System.Windows.Forms.Panel
    Friend WithEvents Panel22 As System.Windows.Forms.Panel
    Friend WithEvents Panel20 As System.Windows.Forms.Panel
    Friend WithEvents Panel21 As System.Windows.Forms.Panel
    Friend WithEvents Panel27 As System.Windows.Forms.Panel
End Class
