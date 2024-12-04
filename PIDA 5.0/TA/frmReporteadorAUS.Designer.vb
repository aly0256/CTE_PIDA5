<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteadorAUS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteadorAUS))
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.txtBusca = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.FILTRAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FRECUENCIA = New DevComponents.DotNetBar.Controls.DataGridViewProgressBarXColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgReportes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.USERNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gpOrden = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.btnOrden = New DevComponents.DotNetBar.ButtonX()
        Me.sbNombre = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.sbReloj = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBajar = New DevComponents.DotNetBar.ButtonX()
        Me.btnSubir = New DevComponents.DotNetBar.ButtonX()
        Me.lstOrden = New System.Windows.Forms.ListBox()
        Me.chkOtroOrden = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkNombre = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkReloj = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.gpReportes = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.pnlFiltroReporte = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkRecientes = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipoReportes = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.gpAvance = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.lblAvance = New System.Windows.Forms.Label()
        Me.pbAvance = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.lblRango = New System.Windows.Forms.Label()
        Me.lblFechas = New System.Windows.Forms.Label()
        Me.pnlRango = New System.Windows.Forms.Panel()
        Me.bgwReporte = New System.ComponentModel.BackgroundWorker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.pnlseparador = New System.Windows.Forms.Panel()
        Me.gpFiltros = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.btnSeleccionarFiltros = New DevComponents.DotNetBar.ButtonX()
        Me.gpFiltrosVigentes = New System.Windows.Forms.GroupBox()
        Me.lstFiltros = New System.Windows.Forms.ListBox()
        Me.chkTodos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkOtrosFiltros = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtBajas = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.txtActivos = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.chkBajas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkActivos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.gpControles = New System.Windows.Forms.GroupBox()
        Me.pnlCentrarControles = New System.Windows.Forms.Panel()
        Me.btnGenerar = New DevComponents.DotNetBar.ButtonX()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.splReportes = New System.Windows.Forms.SplitContainer()
        CType(Me.dgReportes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpOrden.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gpReportes.SuspendLayout()
        Me.pnlFiltroReporte.SuspendLayout()
        Me.gpAvance.SuspendLayout()
        Me.pnlRango.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpFiltros.SuspendLayout()
        Me.gpFiltrosVigentes.SuspendLayout()
        CType(Me.txtBajas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtActivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpControles.SuspendLayout()
        Me.pnlCentrarControles.SuspendLayout()
        CType(Me.splReportes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splReportes.Panel1.SuspendLayout()
        Me.splReportes.Panel2.SuspendLayout()
        Me.splReportes.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBusca
        '
        '
        '
        '
        Me.txtBusca.Border.Class = "TextBoxBorder"
        Me.txtBusca.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.txtBusca, "txtBusca")
        Me.txtBusca.Name = "txtBusca"
        Me.txtBusca.PreventEnterBeep = True
        '
        'FILTRAR
        '
        Me.FILTRAR.DataPropertyName = "FILTRAR"
        resources.ApplyResources(Me.FILTRAR, "FILTRAR")
        Me.FILTRAR.Name = "FILTRAR"
        Me.FILTRAR.ReadOnly = True
        '
        'FECHA
        '
        Me.FECHA.DataPropertyName = "FECHA"
        resources.ApplyResources(Me.FECHA, "FECHA")
        Me.FECHA.Name = "FECHA"
        Me.FECHA.ReadOnly = True
        Me.FECHA.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'FRECUENCIA
        '
        Me.FRECUENCIA.DataPropertyName = "Frecuencia"
        resources.ApplyResources(Me.FRECUENCIA, "FRECUENCIA")
        Me.FRECUENCIA.Name = "FRECUENCIA"
        Me.FRECUENCIA.ReadOnly = True
        Me.FRECUENCIA.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FRECUENCIA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.FRECUENCIA.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.FRECUENCIA.Text = Nothing
        Me.FRECUENCIA.TextVisible = True
        '
        'Tipo
        '
        Me.Tipo.DataPropertyName = "Tipo"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.NullValue = " "
        Me.Tipo.DefaultCellStyle = DataGridViewCellStyle8
        resources.ApplyResources(Me.Tipo, "Tipo")
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        '
        'NOMBRE
        '
        Me.NOMBRE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NOMBRE.DataPropertyName = "Nombre"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.NOMBRE.DefaultCellStyle = DataGridViewCellStyle9
        resources.ApplyResources(Me.NOMBRE, "NOMBRE")
        Me.NOMBRE.Name = "NOMBRE"
        Me.NOMBRE.ReadOnly = True
        '
        'ID
        '
        Me.ID.DataPropertyName = "idReporte"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ID.DefaultCellStyle = DataGridViewCellStyle10
        resources.ApplyResources(Me.ID, "ID")
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        '
        'dgReportes
        '
        Me.dgReportes.AllowUserToAddRows = False
        Me.dgReportes.AllowUserToDeleteRows = False
        Me.dgReportes.AllowUserToOrderColumns = True
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgReportes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgReportes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgReportes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.NOMBRE, Me.Tipo, Me.FRECUENCIA, Me.FECHA, Me.FILTRAR, Me.USERNAME})
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgReportes.DefaultCellStyle = DataGridViewCellStyle13
        resources.ApplyResources(Me.dgReportes, "dgReportes")
        Me.dgReportes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgReportes.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgReportes.MultiSelect = False
        Me.dgReportes.Name = "dgReportes"
        Me.dgReportes.PaintEnhancedSelection = False
        Me.dgReportes.ReadOnly = True
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgReportes.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgReportes.RowHeadersVisible = False
        Me.dgReportes.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.dgReportes.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgReportes.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgReportes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgReportes.StandardTab = True
        '
        'USERNAME
        '
        Me.USERNAME.DataPropertyName = "USERNAME"
        resources.ApplyResources(Me.USERNAME, "USERNAME")
        Me.USERNAME.Name = "USERNAME"
        Me.USERNAME.ReadOnly = True
        '
        'gpOrden
        '
        resources.ApplyResources(Me.gpOrden, "gpOrden")
        Me.gpOrden.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpOrden.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpOrden.Controls.Add(Me.btnOrden)
        Me.gpOrden.Controls.Add(Me.sbNombre)
        Me.gpOrden.Controls.Add(Me.sbReloj)
        Me.gpOrden.Controls.Add(Me.GroupBox1)
        Me.gpOrden.Controls.Add(Me.chkOtroOrden)
        Me.gpOrden.Controls.Add(Me.chkNombre)
        Me.gpOrden.Controls.Add(Me.chkReloj)
        Me.gpOrden.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpOrden.Name = "gpOrden"
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
        Me.gpOrden.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
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
        '
        'btnOrden
        '
        Me.btnOrden.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnOrden.CausesValidation = False
        Me.btnOrden.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnOrden.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.btnOrden, "btnOrden")
        Me.btnOrden.Image = Global.PIDA.My.Resources.Resources.Sort16
        Me.btnOrden.Name = "btnOrden"
        Me.btnOrden.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'sbNombre
        '
        '
        '
        '
        Me.sbNombre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.sbNombre, "sbNombre")
        Me.sbNombre.Name = "sbNombre"
        Me.sbNombre.OffBackColor = System.Drawing.Color.PowderBlue
        Me.sbNombre.OffTextColor = System.Drawing.Color.Black
        Me.sbNombre.OnBackColor = System.Drawing.Color.Honeydew
        Me.sbNombre.OnTextColor = System.Drawing.Color.Black
        Me.sbNombre.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sbNombre.SwitchBackColor = System.Drawing.Color.RoyalBlue
        Me.sbNombre.SwitchFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sbNombre.SwitchWidth = 25
        Me.sbNombre.Value = True
        Me.sbNombre.ValueObject = "Y"
        '
        'sbReloj
        '
        '
        '
        '
        Me.sbReloj.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.sbReloj, "sbReloj")
        Me.sbReloj.Name = "sbReloj"
        Me.sbReloj.OffBackColor = System.Drawing.Color.PowderBlue
        Me.sbReloj.OffTextColor = System.Drawing.Color.Black
        Me.sbReloj.OnBackColor = System.Drawing.Color.Honeydew
        Me.sbReloj.OnTextColor = System.Drawing.Color.Black
        Me.sbReloj.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sbReloj.SwitchBackColor = System.Drawing.Color.RoyalBlue
        Me.sbReloj.SwitchFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sbReloj.SwitchWidth = 25
        Me.sbReloj.Value = True
        Me.sbReloj.ValueObject = "Y"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Window
        Me.GroupBox1.Controls.Add(Me.btnBajar)
        Me.GroupBox1.Controls.Add(Me.btnSubir)
        Me.GroupBox1.Controls.Add(Me.lstOrden)
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'btnBajar
        '
        Me.btnBajar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBajar.CausesValidation = False
        Me.btnBajar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBajar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.btnBajar, "btnBajar")
        Me.btnBajar.Image = Global.PIDA.My.Resources.Resources.navigate_down16
        Me.btnBajar.Name = "btnBajar"
        '
        'btnSubir
        '
        Me.btnSubir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSubir.CausesValidation = False
        Me.btnSubir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSubir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.btnSubir, "btnSubir")
        Me.btnSubir.Image = CType(resources.GetObject("btnSubir.Image"), System.Drawing.Image)
        Me.btnSubir.Name = "btnSubir"
        '
        'lstOrden
        '
        Me.lstOrden.FormattingEnabled = True
        resources.ApplyResources(Me.lstOrden, "lstOrden")
        Me.lstOrden.Name = "lstOrden"
        '
        'chkOtroOrden
        '
        resources.ApplyResources(Me.chkOtroOrden, "chkOtroOrden")
        Me.chkOtroOrden.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkOtroOrden.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkOtroOrden.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkOtroOrden.Name = "chkOtroOrden"
        Me.chkOtroOrden.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkOtroOrden.TextColor = System.Drawing.SystemColors.ControlText
        '
        'chkNombre
        '
        resources.ApplyResources(Me.chkNombre, "chkNombre")
        Me.chkNombre.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkNombre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkNombre.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkNombre.Name = "chkNombre"
        Me.chkNombre.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkNombre.TextColor = System.Drawing.SystemColors.ControlText
        '
        'chkReloj
        '
        resources.ApplyResources(Me.chkReloj, "chkReloj")
        Me.chkReloj.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkReloj.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkReloj.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkReloj.Checked = True
        Me.chkReloj.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReloj.CheckValue = "Y"
        Me.chkReloj.Name = "chkReloj"
        Me.chkReloj.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkReloj.TextColor = System.Drawing.SystemColors.ControlText
        '
        'gpReportes
        '
        Me.gpReportes.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpReportes.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpReportes.Controls.Add(Me.gpAvance)
        Me.gpReportes.Controls.Add(Me.dgReportes)
        Me.gpReportes.Controls.Add(Me.pnlFiltroReporte)
        Me.gpReportes.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.gpReportes, "gpReportes")
        Me.gpReportes.Name = "gpReportes"
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
        '
        'pnlFiltroReporte
        '
        Me.pnlFiltroReporte.BackColor = System.Drawing.SystemColors.Window
        Me.pnlFiltroReporte.Controls.Add(Me.Label2)
        Me.pnlFiltroReporte.Controls.Add(Me.txtBusca)
        Me.pnlFiltroReporte.Controls.Add(Me.chkRecientes)
        Me.pnlFiltroReporte.Controls.Add(Me.Label1)
        Me.pnlFiltroReporte.Controls.Add(Me.cmbTipoReportes)
        resources.ApplyResources(Me.pnlFiltroReporte, "pnlFiltroReporte")
        Me.pnlFiltroReporte.Name = "pnlFiltroReporte"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Name = "Label2"
        '
        'chkRecientes
        '
        resources.ApplyResources(Me.chkRecientes, "chkRecientes")
        Me.chkRecientes.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkRecientes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkRecientes.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkRecientes.Checked = True
        Me.chkRecientes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRecientes.CheckValue = "Y"
        Me.chkRecientes.Name = "chkRecientes"
        Me.chkRecientes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkRecientes.TextColor = System.Drawing.SystemColors.ControlText
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Name = "Label1"
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
        Me.cmbTipoReportes.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        resources.ApplyResources(Me.cmbTipoReportes, "cmbTipoReportes")
        Me.cmbTipoReportes.Name = "cmbTipoReportes"
        Me.cmbTipoReportes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipoReportes.ValueMember = "tipo"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "tipo"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        resources.ApplyResources(Me.ColumnHeader1, "ColumnHeader1")
        Me.ColumnHeader1.Width.Absolute = 30
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "nombre"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        resources.ApplyResources(Me.ColumnHeader2, "ColumnHeader2")
        Me.ColumnHeader2.Width.Absolute = 150
        Me.ColumnHeader2.Width.AutoSize = True
        '
        'gpAvance
        '
        Me.gpAvance.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpAvance.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpAvance.Controls.Add(Me.lblAvance)
        Me.gpAvance.Controls.Add(Me.pbAvance)
        Me.gpAvance.DisabledBackColor = System.Drawing.Color.Empty
        resources.ApplyResources(Me.gpAvance, "gpAvance")
        Me.gpAvance.Name = "gpAvance"
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
        '
        'lblAvance
        '
        Me.lblAvance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        resources.ApplyResources(Me.lblAvance, "lblAvance")
        Me.lblAvance.Name = "lblAvance"
        '
        'pbAvance
        '
        Me.pbAvance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        '
        '
        '
        Me.pbAvance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.pbAvance, "pbAvance")
        Me.pbAvance.Name = "pbAvance"
        Me.pbAvance.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.pbAvance.ProgressColor = System.Drawing.Color.MediumBlue
        Me.pbAvance.ProgressTextFormat = ""
        Me.pbAvance.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        '
        'lblRango
        '
        resources.ApplyResources(Me.lblRango, "lblRango")
        Me.lblRango.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblRango.Name = "lblRango"
        '
        'lblFechas
        '
        resources.ApplyResources(Me.lblFechas, "lblFechas")
        Me.lblFechas.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblFechas.Name = "lblFechas"
        '
        'pnlRango
        '
        Me.pnlRango.BackColor = System.Drawing.SystemColors.HotTrack
        Me.pnlRango.Controls.Add(Me.lblRango)
        Me.pnlRango.Controls.Add(Me.lblFechas)
        resources.ApplyResources(Me.pnlRango, "pnlRango")
        Me.pnlRango.Name = "pnlRango"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.ReflectionLabel1)
        Me.Panel1.Controls.Add(Me.pnlRango)
        resources.ApplyResources(Me.Panel1, "Panel1")
        Me.Panel1.Name = "Panel1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Reporte48
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        resources.ApplyResources(Me.ReflectionLabel1, "ReflectionLabel1")
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        '
        'pnlseparador
        '
        resources.ApplyResources(Me.pnlseparador, "pnlseparador")
        Me.pnlseparador.Name = "pnlseparador"
        '
        'gpFiltros
        '
        resources.ApplyResources(Me.gpFiltros, "gpFiltros")
        Me.gpFiltros.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpFiltros.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpFiltros.Controls.Add(Me.btnSeleccionarFiltros)
        Me.gpFiltros.Controls.Add(Me.gpFiltrosVigentes)
        Me.gpFiltros.Controls.Add(Me.chkTodos)
        Me.gpFiltros.Controls.Add(Me.chkOtrosFiltros)
        Me.gpFiltros.Controls.Add(Me.txtBajas)
        Me.gpFiltros.Controls.Add(Me.txtActivos)
        Me.gpFiltros.Controls.Add(Me.chkBajas)
        Me.gpFiltros.Controls.Add(Me.chkActivos)
        Me.gpFiltros.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpFiltros.Name = "gpFiltros"
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
        Me.gpFiltros.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
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
        '
        'btnSeleccionarFiltros
        '
        Me.btnSeleccionarFiltros.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSeleccionarFiltros.CausesValidation = False
        Me.btnSeleccionarFiltros.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSeleccionarFiltros.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.btnSeleccionarFiltros, "btnSeleccionarFiltros")
        Me.btnSeleccionarFiltros.Image = Global.PIDA.My.Resources.Resources.FiltroHC
        Me.btnSeleccionarFiltros.Name = "btnSeleccionarFiltros"
        Me.btnSeleccionarFiltros.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'gpFiltrosVigentes
        '
        Me.gpFiltrosVigentes.BackColor = System.Drawing.SystemColors.Window
        Me.gpFiltrosVigentes.Controls.Add(Me.lstFiltros)
        resources.ApplyResources(Me.gpFiltrosVigentes, "gpFiltrosVigentes")
        Me.gpFiltrosVigentes.Name = "gpFiltrosVigentes"
        Me.gpFiltrosVigentes.TabStop = False
        '
        'lstFiltros
        '
        Me.lstFiltros.FormattingEnabled = True
        resources.ApplyResources(Me.lstFiltros, "lstFiltros")
        Me.lstFiltros.Name = "lstFiltros"
        '
        'chkTodos
        '
        resources.ApplyResources(Me.chkTodos, "chkTodos")
        Me.chkTodos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkTodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkTodos.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkTodos.Checked = True
        Me.chkTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodos.CheckValue = "Y"
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkTodos.TextColor = System.Drawing.SystemColors.ControlText
        '
        'chkOtrosFiltros
        '
        resources.ApplyResources(Me.chkOtrosFiltros, "chkOtrosFiltros")
        Me.chkOtrosFiltros.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkOtrosFiltros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkOtrosFiltros.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkOtrosFiltros.Name = "chkOtrosFiltros"
        Me.chkOtrosFiltros.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkOtrosFiltros.TextColor = System.Drawing.SystemColors.ControlText
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
        Me.txtBajas.FocusHighlightEnabled = True
        Me.txtBajas.IsPopupCalendarOpen = False
        resources.ApplyResources(Me.txtBajas, "txtBajas")
        '
        '
        '
        Me.txtBajas.MonthCalendar.AnnuallyMarkedDates = CType(resources.GetObject("txtBajas.MonthCalendar.AnnuallyMarkedDates"), Date())
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
        Me.txtBajas.MonthCalendar.MarkedDates = CType(resources.GetObject("txtBajas.MonthCalendar.MarkedDates"), Date())
        Me.txtBajas.MonthCalendar.MonthlyMarkedDates = CType(resources.GetObject("txtBajas.MonthCalendar.MonthlyMarkedDates"), Date())
        '
        '
        '
        Me.txtBajas.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtBajas.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtBajas.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtBajas.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBajas.MonthCalendar.TodayButtonVisible = True
        Me.txtBajas.MonthCalendar.WeeklyMarkedDays = CType(resources.GetObject("txtBajas.MonthCalendar.WeeklyMarkedDays"), System.DayOfWeek())
        Me.txtBajas.Name = "txtBajas"
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
        Me.txtActivos.FocusHighlightEnabled = True
        Me.txtActivos.IsPopupCalendarOpen = False
        resources.ApplyResources(Me.txtActivos, "txtActivos")
        '
        '
        '
        Me.txtActivos.MonthCalendar.AnnuallyMarkedDates = CType(resources.GetObject("txtActivos.MonthCalendar.AnnuallyMarkedDates"), Date())
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
        Me.txtActivos.MonthCalendar.MarkedDates = CType(resources.GetObject("txtActivos.MonthCalendar.MarkedDates"), Date())
        Me.txtActivos.MonthCalendar.MonthlyMarkedDates = CType(resources.GetObject("txtActivos.MonthCalendar.MonthlyMarkedDates"), Date())
        '
        '
        '
        Me.txtActivos.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtActivos.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtActivos.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtActivos.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtActivos.MonthCalendar.TodayButtonVisible = True
        Me.txtActivos.MonthCalendar.WeeklyMarkedDays = CType(resources.GetObject("txtActivos.MonthCalendar.WeeklyMarkedDays"), System.DayOfWeek())
        Me.txtActivos.Name = "txtActivos"
        '
        'chkBajas
        '
        resources.ApplyResources(Me.chkBajas, "chkBajas")
        Me.chkBajas.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkBajas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkBajas.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkBajas.Name = "chkBajas"
        Me.chkBajas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkBajas.TextColor = System.Drawing.SystemColors.ControlText
        '
        'chkActivos
        '
        resources.ApplyResources(Me.chkActivos, "chkActivos")
        Me.chkActivos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkActivos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkActivos.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkActivos.Name = "chkActivos"
        Me.chkActivos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkActivos.TextColor = System.Drawing.SystemColors.ControlText
        '
        'gpControles
        '
        Me.gpControles.Controls.Add(Me.pnlCentrarControles)
        resources.ApplyResources(Me.gpControles, "gpControles")
        Me.gpControles.Name = "gpControles"
        Me.gpControles.TabStop = False
        '
        'pnlCentrarControles
        '
        Me.pnlCentrarControles.Controls.Add(Me.btnGenerar)
        Me.pnlCentrarControles.Controls.Add(Me.btnBorrar)
        Me.pnlCentrarControles.Controls.Add(Me.btnCancelar)
        Me.pnlCentrarControles.Controls.Add(Me.btnNuevo)
        resources.ApplyResources(Me.pnlCentrarControles, "pnlCentrarControles")
        Me.pnlCentrarControles.Name = "pnlCentrarControles"
        '
        'btnGenerar
        '
        Me.btnGenerar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGenerar.CausesValidation = False
        Me.btnGenerar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGenerar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.btnGenerar, "btnGenerar")
        Me.btnGenerar.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnGenerar.Name = "btnGenerar"
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.btnBorrar, "btnBorrar")
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Image = Global.PIDA.My.Resources.Resources.Delete
        Me.btnBorrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBorrar.Name = "btnBorrar"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        resources.ApplyResources(Me.btnCancelar, "btnCancelar")
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCancelar.Name = "btnCancelar"
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        resources.ApplyResources(Me.btnNuevo, "btnNuevo")
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.Wizard16
        Me.btnNuevo.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnNuevo.Name = "btnNuevo"
        '
        'splReportes
        '
        resources.ApplyResources(Me.splReportes, "splReportes")
        Me.splReportes.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
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
        '
        'frmReporteadorAUS
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.splReportes)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gpControles)
        Me.Name = "frmReporteadorAUS"
        CType(Me.dgReportes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpOrden.ResumeLayout(False)
        Me.gpOrden.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.gpReportes.ResumeLayout(False)
        Me.pnlFiltroReporte.ResumeLayout(False)
        Me.pnlFiltroReporte.PerformLayout()
        Me.gpAvance.ResumeLayout(False)
        Me.pnlRango.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpFiltros.ResumeLayout(False)
        Me.gpFiltros.PerformLayout()
        Me.gpFiltrosVigentes.ResumeLayout(False)
        CType(Me.txtBajas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtActivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpControles.ResumeLayout(False)
        Me.pnlCentrarControles.ResumeLayout(False)
        Me.splReportes.Panel1.ResumeLayout(False)
        Me.splReportes.Panel2.ResumeLayout(False)
        CType(Me.splReportes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splReportes.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtBusca As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents FILTRAR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FRECUENCIA As DevComponents.DotNetBar.Controls.DataGridViewProgressBarXColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgReportes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents USERNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents gpOrden As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btnOrden As DevComponents.DotNetBar.ButtonX
    Friend WithEvents sbNombre As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents sbReloj As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBajar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSubir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lstOrden As System.Windows.Forms.ListBox
    Friend WithEvents chkOtroOrden As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkNombre As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkReloj As DevComponents.DotNetBar.Controls.CheckBoxX
    Private WithEvents gpReportes As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents gpAvance As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lblAvance As System.Windows.Forms.Label
    Friend WithEvents pbAvance As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents pnlFiltroReporte As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkRecientes As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoReportes As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents lblRango As System.Windows.Forms.Label
    Friend WithEvents lblFechas As System.Windows.Forms.Label
    Friend WithEvents pnlRango As System.Windows.Forms.Panel
    Friend WithEvents bgwReporte As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents pnlseparador As System.Windows.Forms.Panel
    Private WithEvents gpFiltros As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btnSeleccionarFiltros As DevComponents.DotNetBar.ButtonX
    Friend WithEvents gpFiltrosVigentes As System.Windows.Forms.GroupBox
    Friend WithEvents lstFiltros As System.Windows.Forms.ListBox
    Friend WithEvents chkTodos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkOtrosFiltros As DevComponents.DotNetBar.Controls.CheckBoxX
    Private WithEvents txtBajas As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Private WithEvents txtActivos As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents chkBajas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkActivos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents gpControles As System.Windows.Forms.GroupBox
    Friend WithEvents pnlCentrarControles As System.Windows.Forms.Panel
    Friend WithEvents btnGenerar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents splReportes As System.Windows.Forms.SplitContainer
End Class
