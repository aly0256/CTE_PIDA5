<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIdeasAPago
    Inherits System.Windows.Forms.Form

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Padding1 As DevComponents.DotNetBar.SuperGrid.Style.Padding = New DevComponents.DotNetBar.SuperGrid.Style.Padding()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIdeasAPago))
        Me.GridColumn3 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn4 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn5 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn6 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn7 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn8 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.tabTabla = New DevComponents.DotNetBar.SuperTabItem()
        Me.tabConsulta = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgConsulta = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.Compañia = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn1 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn9 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.Pagada = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.tabAprobaciones = New DevComponents.DotNetBar.SuperTabItem()
        Me.tabAprobacion = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgAprobacion = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.pnlPendientes = New System.Windows.Forms.Panel()
        Me.lblPendientes = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbPeriodos = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.colUnico = New DevComponents.AdvTree.ColumnHeader()
        Me.colAno = New DevComponents.AdvTree.ColumnHeader()
        Me.colPeriodo = New DevComponents.AdvTree.ColumnHeader()
        Me.colFechaIni = New DevComponents.AdvTree.ColumnHeader()
        Me.colFechaFin = New DevComponents.AdvTree.ColumnHeader()
        Me.cmbCompa = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnTodos = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabPrestamos = New DevComponents.DotNetBar.SuperTabControl()
        Me.pnlControles = New System.Windows.Forms.Panel()
        Me.pnlCentrar = New System.Windows.Forms.Panel()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.btnLimpiar = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnMostrarInformacion = New DevComponents.DotNetBar.ButtonX()
        Me.DataGridViewCheckBoxXColumn1 = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.clcomp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Reloj_alt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColReloj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFolio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConCantSolicitada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCantPagar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEnviarNomina = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.tabConsulta.SuspendLayout()
        Me.tabAprobacion.SuspendLayout()
        CType(Me.dgAprobacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPendientes.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.tabPrestamos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPrestamos.SuspendLayout()
        Me.pnlControles.SuspendLayout()
        Me.pnlCentrar.SuspendLayout()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridColumn3
        '
        Me.GridColumn3.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.BottomLeft
        Me.GridColumn3.DataPropertyName = "reloj"
        Me.GridColumn3.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn3.Name = "Reloj"
        Me.GridColumn3.Width = 120
        '
        'GridColumn4
        '
        Me.GridColumn4.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColumn4.DataPropertyName = "fecha_captura_idea"
        Me.GridColumn4.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDateTimePickerEditControl)
        Me.GridColumn4.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn4.FilterAutoScan = True
        Me.GridColumn4.HeaderText = "Fecha de captura"
        Me.GridColumn4.Name = "FechaCaptura"
        Me.GridColumn4.Width = 120
        '
        'GridColumn5
        '
        Me.GridColumn5.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.BottomLeft
        Padding1.Right = 5
        Me.GridColumn5.CellStyles.Default.Padding = Padding1
        Me.GridColumn5.DataPropertyName = "folio"
        Me.GridColumn5.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn5.HeaderText = "Folio"
        Me.GridColumn5.Name = "Folio"
        Me.GridColumn5.Width = 70
        '
        'GridColumn6
        '
        Me.GridColumn6.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill
        Me.GridColumn6.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.BottomLeft
        Me.GridColumn6.DataPropertyName = "idea"
        Me.GridColumn6.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn6.MinimumWidth = 120
        Me.GridColumn6.Name = "Idea"
        Me.GridColumn6.Width = 0
        '
        'GridColumn7
        '
        Me.GridColumn7.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColumn7.DataPropertyName = "monto"
        Me.GridColumn7.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl)
        Me.GridColumn7.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn7.FilterAutoScan = True
        Me.GridColumn7.Name = "Monto"
        Me.GridColumn7.Width = 70
        '
        'GridColumn8
        '
        Me.GridColumn8.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColumn8.DataPropertyName = "anoperiodo"
        Me.GridColumn8.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn8.FilterAutoScan = True
        Me.GridColumn8.HeaderText = "Periodo de pago"
        Me.GridColumn8.Name = "PeriodoPago"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(55, 18)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(511, 40)
        Me.ReflectionLabel1.TabIndex = 272
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>PAGO DE IDEAS</b></font>"
        '
        'tabTabla
        '
        Me.tabTabla.AttachedControl = Me.tabConsulta
        Me.tabTabla.GlobalItem = False
        Me.tabTabla.Name = "tabTabla"
        Me.tabTabla.Text = "Consulta"
        Me.tabTabla.Visible = False
        '
        'tabConsulta
        '
        Me.tabConsulta.Controls.Add(Me.dgConsulta)
        Me.tabConsulta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabConsulta.Location = New System.Drawing.Point(0, 0)
        Me.tabConsulta.Name = "tabConsulta"
        Me.tabConsulta.Size = New System.Drawing.Size(1383, 667)
        Me.tabConsulta.TabIndex = 0
        Me.tabConsulta.TabItem = Me.tabTabla
        '
        'dgConsulta
        '
        Me.dgConsulta.BackColor = System.Drawing.Color.White
        Me.dgConsulta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgConsulta.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.dgConsulta.ForeColor = System.Drawing.Color.Black
        Me.dgConsulta.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.dgConsulta.Location = New System.Drawing.Point(0, 0)
        Me.dgConsulta.Name = "dgConsulta"
        '
        '
        '
        Me.dgConsulta.PrimaryGrid.AllowEdit = False
        Me.dgConsulta.PrimaryGrid.AllowRowHeaderResize = True
        Me.dgConsulta.PrimaryGrid.AllowRowResize = True
        Me.dgConsulta.PrimaryGrid.AutoExpandSetGroup = True
        Me.dgConsulta.PrimaryGrid.AutoGenerateColumns = False
        Me.dgConsulta.PrimaryGrid.Columns.Add(Me.Compañia)
        Me.dgConsulta.PrimaryGrid.Columns.Add(Me.GridColumn3)
        Me.dgConsulta.PrimaryGrid.Columns.Add(Me.GridColumn5)
        Me.dgConsulta.PrimaryGrid.Columns.Add(Me.GridColumn6)
        Me.dgConsulta.PrimaryGrid.Columns.Add(Me.GridColumn1)
        Me.dgConsulta.PrimaryGrid.Columns.Add(Me.GridColumn4)
        Me.dgConsulta.PrimaryGrid.Columns.Add(Me.GridColumn9)
        Me.dgConsulta.PrimaryGrid.Columns.Add(Me.GridColumn8)
        Me.dgConsulta.PrimaryGrid.Columns.Add(Me.GridColumn7)
        Me.dgConsulta.PrimaryGrid.Columns.Add(Me.Pagada)
        Me.dgConsulta.PrimaryGrid.DefaultRowHeight = 24
        Me.dgConsulta.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.dgConsulta.PrimaryGrid.EnableColumnFiltering = True
        Me.dgConsulta.PrimaryGrid.EnableFiltering = True
        Me.dgConsulta.PrimaryGrid.EnableRowFiltering = True
        '
        '
        '
        Me.dgConsulta.PrimaryGrid.Filter.Visible = True
        Me.dgConsulta.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        '
        '
        '
        Me.dgConsulta.PrimaryGrid.GroupByRow.GroupBoxEffects = DevComponents.DotNetBar.SuperGrid.GroupBoxEffects.Copy
        Me.dgConsulta.PrimaryGrid.GroupByRow.GroupBoxLayout = DevComponents.DotNetBar.SuperGrid.GroupBoxLayout.Flat
        Me.dgConsulta.PrimaryGrid.GroupByRow.Visible = True
        Me.dgConsulta.PrimaryGrid.GroupByRow.WatermarkText = "Arrastre la columna por la que desea agrupar"
        Me.dgConsulta.PrimaryGrid.GroupHeaderClickBehavior = DevComponents.DotNetBar.SuperGrid.GroupHeaderClickBehavior.ExpandCollapse
        Me.dgConsulta.PrimaryGrid.GroupHeaderKeyBehavior = DevComponents.DotNetBar.SuperGrid.GroupHeaderKeyBehavior.[Select]
        Me.dgConsulta.PrimaryGrid.GroupRowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.Always
        '
        '
        '
        Me.dgConsulta.PrimaryGrid.Header.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.Always
        Me.dgConsulta.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.Row
        Me.dgConsulta.PrimaryGrid.KeyboardEditMode = DevComponents.DotNetBar.SuperGrid.KeyboardEditMode.None
        Me.dgConsulta.PrimaryGrid.RowHeaderWidth = 20
        '
        '
        '
        Me.dgConsulta.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled
        Me.dgConsulta.PrimaryGrid.UseAlternateColumnStyle = True
        Me.dgConsulta.PrimaryGrid.UseAlternateRowStyle = True
        Me.dgConsulta.Size = New System.Drawing.Size(1383, 667)
        Me.dgConsulta.TabIndex = 3
        Me.dgConsulta.Text = "Consulta de préstamos"
        '
        'Compañia
        '
        Me.Compañia.DataPropertyName = "compania"
        Me.Compañia.Name = "Compañia"
        '
        'GridColumn1
        '
        Me.GridColumn1.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColumn1.DataPropertyName = "calificacion"
        Me.GridColumn1.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn1.FilterAutoScan = True
        Me.GridColumn1.HeaderText = "Calificación"
        Me.GridColumn1.Name = "Calificacion"
        Me.GridColumn1.Width = 80
        '
        'GridColumn9
        '
        Me.GridColumn9.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColumn9.DataPropertyName = "envio_nomina"
        Me.GridColumn9.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDateTimeInputEditControl)
        Me.GridColumn9.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn9.FilterAutoScan = True
        Me.GridColumn9.HeaderText = "Fecha envío nómina"
        Me.GridColumn9.Name = "FechaEnvioNomina"
        Me.GridColumn9.Width = 120
        '
        'Pagada
        '
        Me.Pagada.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.Pagada.DataPropertyName = "pagada"
        Me.Pagada.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.Pagada.FilterAutoScan = True
        Me.Pagada.HeaderText = "Pagada"
        Me.Pagada.Name = "Pagada"
        Me.Pagada.Width = 75
        '
        'tabAprobaciones
        '
        Me.tabAprobaciones.AttachedControl = Me.tabAprobacion
        Me.tabAprobaciones.GlobalItem = False
        Me.tabAprobaciones.Name = "tabAprobaciones"
        Me.tabAprobaciones.Text = "Consulta periodo"
        '
        'tabAprobacion
        '
        Me.tabAprobacion.Controls.Add(Me.dgAprobacion)
        Me.tabAprobacion.Controls.Add(Me.pnlPendientes)
        Me.tabAprobacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabAprobacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabAprobacion.Location = New System.Drawing.Point(0, 0)
        Me.tabAprobacion.Name = "tabAprobacion"
        Me.tabAprobacion.Size = New System.Drawing.Size(1387, 667)
        Me.tabAprobacion.TabIndex = 63
        Me.tabAprobacion.TabItem = Me.tabAprobaciones
        '
        'dgAprobacion
        '
        Me.dgAprobacion.AllowUserToAddRows = False
        Me.dgAprobacion.AllowUserToDeleteRows = False
        Me.dgAprobacion.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAprobacion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgAprobacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAprobacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clcomp, Me.Reloj_alt, Me.ColReloj, Me.colNombre, Me.ColFecha, Me.colFolio, Me.ConCantSolicitada, Me.ColCantPagar, Me.colEnviarNomina})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgAprobacion.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgAprobacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgAprobacion.EnableHeadersVisualStyles = False
        Me.dgAprobacion.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgAprobacion.Location = New System.Drawing.Point(0, 35)
        Me.dgAprobacion.MultiSelect = False
        Me.dgAprobacion.Name = "dgAprobacion"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAprobacion.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgAprobacion.RowHeadersVisible = False
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgAprobacion.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgAprobacion.Size = New System.Drawing.Size(1387, 632)
        Me.dgAprobacion.TabIndex = 2
        '
        'pnlPendientes
        '
        Me.pnlPendientes.BackColor = System.Drawing.Color.White
        Me.pnlPendientes.Controls.Add(Me.lblPendientes)
        Me.pnlPendientes.Controls.Add(Me.Panel1)
        Me.pnlPendientes.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPendientes.Location = New System.Drawing.Point(0, 0)
        Me.pnlPendientes.Name = "pnlPendientes"
        Me.pnlPendientes.Size = New System.Drawing.Size(1387, 35)
        Me.pnlPendientes.TabIndex = 5
        '
        'lblPendientes
        '
        Me.lblPendientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendientes.Location = New System.Drawing.Point(0, 0)
        Me.lblPendientes.Name = "lblPendientes"
        Me.lblPendientes.Size = New System.Drawing.Size(506, 35)
        Me.lblPendientes.TabIndex = 9
        Me.lblPendientes.Text = "IDEAS ENVIADAS A NÓMINA"
        Me.lblPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Panel1.Controls.Add(Me.cmbPeriodos)
        Me.Panel1.Controls.Add(Me.cmbCompa)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btnTodos)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(506, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(5)
        Me.Panel1.Size = New System.Drawing.Size(881, 35)
        Me.Panel1.TabIndex = 8
        '
        'cmbPeriodos
        '
        Me.cmbPeriodos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPeriodos.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPeriodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPeriodos.ButtonDropDown.Visible = True
        Me.cmbPeriodos.Columns.Add(Me.colUnico)
        Me.cmbPeriodos.Columns.Add(Me.colAno)
        Me.cmbPeriodos.Columns.Add(Me.colPeriodo)
        Me.cmbPeriodos.Columns.Add(Me.colFechaIni)
        Me.cmbPeriodos.Columns.Add(Me.colFechaFin)
        Me.cmbPeriodos.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmbPeriodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPeriodos.FormatString = "d"
        Me.cmbPeriodos.FormattingEnabled = True
        Me.cmbPeriodos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPeriodos.Location = New System.Drawing.Point(458, 5)
        Me.cmbPeriodos.Name = "cmbPeriodos"
        Me.cmbPeriodos.Size = New System.Drawing.Size(276, 25)
        Me.cmbPeriodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPeriodos.TabIndex = 15
        Me.cmbPeriodos.ValueMember = "unico"
        '
        'colUnico
        '
        Me.colUnico.DataFieldName = "unico"
        Me.colUnico.Name = "colUnico"
        Me.colUnico.Text = "unico"
        Me.colUnico.Visible = False
        Me.colUnico.Width.Absolute = 150
        '
        'colAno
        '
        Me.colAno.DataFieldName = "ano"
        Me.colAno.Name = "colAno"
        Me.colAno.Text = "AÑO"
        Me.colAno.Width.Relative = 15
        '
        'colPeriodo
        '
        Me.colPeriodo.DataFieldName = "periodo"
        Me.colPeriodo.Name = "colPeriodo"
        Me.colPeriodo.Text = "PER."
        Me.colPeriodo.Width.Relative = 25
        '
        'colFechaIni
        '
        Me.colFechaIni.DataFieldName = "fecha_ini"
        Me.colFechaIni.Name = "colFechaIni"
        Me.colFechaIni.Text = "FECHA INI."
        Me.colFechaIni.Width.Relative = 30
        '
        'colFechaFin
        '
        Me.colFechaFin.DataFieldName = "fecha_fin"
        Me.colFechaFin.Name = "colFechaFin"
        Me.colFechaFin.Text = "FECHA FIN"
        Me.colFechaFin.Width.Relative = 30
        '
        'cmbCompa
        '
        Me.cmbCompa.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbCompa.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbCompa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbCompa.ButtonDropDown.Visible = True
        Me.cmbCompa.Columns.Add(Me.ColumnHeader1)
        Me.cmbCompa.Columns.Add(Me.ColumnHeader2)
        Me.cmbCompa.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCompa.FormatString = "d"
        Me.cmbCompa.FormattingEnabled = True
        Me.cmbCompa.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbCompa.Location = New System.Drawing.Point(182, 5)
        Me.cmbCompa.Name = "cmbCompa"
        Me.cmbCompa.Size = New System.Drawing.Size(181, 25)
        Me.cmbCompa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbCompa.TabIndex = 14
        Me.cmbCompa.ValueMember = "cod_comp"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "cod_comp"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Código"
        Me.ColumnHeader1.Width.Absolute = 30
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "Nombre"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Nombre"
        Me.ColumnHeader2.Width.Absolute = 150
        Me.ColumnHeader2.Width.AutoSize = True
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(90, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 25)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "COMPAÑIA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnTodos
        '
        '
        '
        '
        Me.btnTodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnTodos.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnTodos.FocusCuesEnabled = False
        Me.btnTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTodos.Location = New System.Drawing.Point(734, 5)
        Me.btnTodos.Name = "btnTodos"
        Me.btnTodos.OffBackColor = System.Drawing.Color.DarkOrange
        Me.btnTodos.OffText = "Quincenal"
        Me.btnTodos.OffTextColor = System.Drawing.SystemColors.Window
        Me.btnTodos.OnText = "Semanal"
        Me.btnTodos.OnTextColor = System.Drawing.Color.Black
        Me.btnTodos.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnTodos.Size = New System.Drawing.Size(142, 25)
        Me.btnTodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnTodos.SwitchBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnTodos.SwitchBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnTodos.TabIndex = 11
        Me.btnTodos.Value = True
        Me.btnTodos.ValueObject = "Y"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(369, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 25)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "PERIODO"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabPrestamos
        '
        Me.tabPrestamos.BackColor = System.Drawing.Color.White
        '
        '
        '
        '
        '
        '
        Me.tabPrestamos.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.tabPrestamos.ControlBox.MenuBox.Name = ""
        Me.tabPrestamos.ControlBox.MenuBox.Visible = False
        Me.tabPrestamos.ControlBox.Name = ""
        Me.tabPrestamos.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabPrestamos.ControlBox.MenuBox, Me.tabPrestamos.ControlBox.CloseBox})
        Me.tabPrestamos.Controls.Add(Me.tabAprobacion)
        Me.tabPrestamos.Controls.Add(Me.tabConsulta)
        Me.tabPrestamos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabPrestamos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabPrestamos.ForeColor = System.Drawing.Color.Black
        Me.tabPrestamos.Location = New System.Drawing.Point(0, 61)
        Me.tabPrestamos.Name = "tabPrestamos"
        Me.tabPrestamos.ReorderTabsEnabled = True
        Me.tabPrestamos.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabPrestamos.SelectedTabIndex = 0
        Me.tabPrestamos.Size = New System.Drawing.Size(1496, 667)
        Me.tabPrestamos.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.tabPrestamos.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabPrestamos.TabIndex = 273
        Me.tabPrestamos.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit
        Me.tabPrestamos.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabAprobaciones, Me.tabTabla})
        Me.tabPrestamos.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        '
        'pnlControles
        '
        Me.pnlControles.Controls.Add(Me.pnlCentrar)
        Me.pnlControles.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlControles.Location = New System.Drawing.Point(0, 728)
        Me.pnlControles.Name = "pnlControles"
        Me.pnlControles.Size = New System.Drawing.Size(1496, 35)
        Me.pnlControles.TabIndex = 275
        '
        'pnlCentrar
        '
        Me.pnlCentrar.Controls.Add(Me.btnBuscar)
        Me.pnlCentrar.Controls.Add(Me.btnLimpiar)
        Me.pnlCentrar.Controls.Add(Me.btnReporte)
        Me.pnlCentrar.Controls.Add(Me.btnCerrar)
        Me.pnlCentrar.Location = New System.Drawing.Point(217, 2)
        Me.pnlCentrar.Name = "pnlCentrar"
        Me.pnlCentrar.Size = New System.Drawing.Size(537, 30)
        Me.pnlCentrar.TabIndex = 45
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBuscar.Location = New System.Drawing.Point(225, 3)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(97, 25)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 37
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Tooltip = "Buscar"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLimpiar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLimpiar.Image = Global.PIDA.My.Resources.Resources.LimpiaFiltroHC
        Me.btnLimpiar.Location = New System.Drawing.Point(115, 3)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(104, 25)
        Me.btnLimpiar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLimpiar.TabIndex = 43
        Me.btnLimpiar.Text = "Limpiar filtros"
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnReporte.Location = New System.Drawing.Point(328, 3)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(97, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 38
        Me.btnReporte.Text = "Reporte"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(431, 3)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(97, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 42
        Me.btnCerrar.Text = "Salir"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.Controls.Add(Me.PictureBox1)
        Me.pnlEncabezado.Controls.Add(Me.ReflectionLabel1)
        Me.pnlEncabezado.Controls.Add(Me.btnMostrarInformacion)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1496, 61)
        Me.pnlEncabezado.TabIndex = 277
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.PayIdea
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox1.TabIndex = 274
        Me.PictureBox1.TabStop = False
        '
        'btnMostrarInformacion
        '
        Me.btnMostrarInformacion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnMostrarInformacion.CausesValidation = False
        Me.btnMostrarInformacion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnMostrarInformacion.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnMostrarInformacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMostrarInformacion.Image = Global.PIDA.My.Resources.Resources.refresh32
        Me.btnMostrarInformacion.Location = New System.Drawing.Point(1459, 0)
        Me.btnMostrarInformacion.Name = "btnMostrarInformacion"
        Me.btnMostrarInformacion.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(20)
        Me.btnMostrarInformacion.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5)
        Me.btnMostrarInformacion.Size = New System.Drawing.Size(37, 61)
        Me.btnMostrarInformacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnMostrarInformacion.TabIndex = 276
        Me.btnMostrarInformacion.Tooltip = "Actualizar información"
        '
        'DataGridViewCheckBoxXColumn1
        '
        Me.DataGridViewCheckBoxXColumn1.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.DataGridViewCheckBoxXColumn1.CheckBoxImageIndeterminate = Global.PIDA.My.Resources.Resources.Star24Blank
        Me.DataGridViewCheckBoxXColumn1.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.CancelX
        Me.DataGridViewCheckBoxXColumn1.Checked = True
        Me.DataGridViewCheckBoxXColumn1.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.DataGridViewCheckBoxXColumn1.CheckValue = "N"
        Me.DataGridViewCheckBoxXColumn1.CheckValueChecked = "1"
        Me.DataGridViewCheckBoxXColumn1.CheckValueIndeterminate = "0"
        Me.DataGridViewCheckBoxXColumn1.CheckValueUnchecked = "2"
        Me.DataGridViewCheckBoxXColumn1.ConsiderEmptyStringAsNull = False
        Me.DataGridViewCheckBoxXColumn1.DataPropertyName = "aprobada"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewCheckBoxXColumn1.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewCheckBoxXColumn1.EnableMarkup = False
        Me.DataGridViewCheckBoxXColumn1.HeaderText = "Aprobada"
        Me.DataGridViewCheckBoxXColumn1.Name = "DataGridViewCheckBoxXColumn1"
        Me.DataGridViewCheckBoxXColumn1.ThreeState = True
        Me.DataGridViewCheckBoxXColumn1.Width = 60
        '
        'clcomp
        '
        Me.clcomp.DataPropertyName = "compania"
        Me.clcomp.HeaderText = "Compañia"
        Me.clcomp.Name = "clcomp"
        '
        'Reloj_alt
        '
        Me.Reloj_alt.DataPropertyName = "reloj_alt"
        Me.Reloj_alt.HeaderText = "Reloj Alt."
        Me.Reloj_alt.Name = "Reloj_alt"
        '
        'ColReloj
        '
        Me.ColReloj.DataPropertyName = "reloj"
        Me.ColReloj.HeaderText = "Reloj"
        Me.ColReloj.Name = "ColReloj"
        Me.ColReloj.ReadOnly = True
        Me.ColReloj.Width = 55
        '
        'colNombre
        '
        Me.colNombre.DataPropertyName = "nombres"
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        Me.colNombre.Width = 250
        '
        'ColFecha
        '
        Me.ColFecha.DataPropertyName = "fecha"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColFecha.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColFecha.HeaderText = "Fecha"
        Me.ColFecha.Name = "ColFecha"
        Me.ColFecha.ReadOnly = True
        Me.ColFecha.Width = 75
        '
        'colFolio
        '
        Me.colFolio.DataPropertyName = "folio"
        Me.colFolio.HeaderText = "Folio"
        Me.colFolio.Name = "colFolio"
        '
        'ConCantSolicitada
        '
        Me.ConCantSolicitada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ConCantSolicitada.DataPropertyName = "titulo"
        Me.ConCantSolicitada.HeaderText = "Idea"
        Me.ConCantSolicitada.Name = "ConCantSolicitada"
        Me.ConCantSolicitada.ReadOnly = True
        '
        'ColCantPagar
        '
        Me.ColCantPagar.DataPropertyName = "cantidad"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "c2"
        Me.ColCantPagar.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColCantPagar.HeaderText = "Cantidad a pagar"
        Me.ColCantPagar.Name = "ColCantPagar"
        Me.ColCantPagar.ReadOnly = True
        Me.ColCantPagar.Width = 75
        '
        'colEnviarNomina
        '
        Me.colEnviarNomina.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.colEnviarNomina.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.Unckecked16
        Me.colEnviarNomina.Checked = True
        Me.colEnviarNomina.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.colEnviarNomina.CheckValue = "N"
        Me.colEnviarNomina.ConsiderEmptyStringAsNull = False
        Me.colEnviarNomina.DataPropertyName = "enviar"
        Me.colEnviarNomina.HeaderText = "Enviar"
        Me.colEnviarNomina.Name = "colEnviarNomina"
        Me.colEnviarNomina.Visible = False
        Me.colEnviarNomina.Width = 60
        '
        'frmIdeasAPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(1496, 763)
        Me.Controls.Add(Me.tabPrestamos)
        Me.Controls.Add(Me.pnlControles)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmIdeasAPago"
        Me.Text = "Ideas"
        Me.tabConsulta.ResumeLayout(False)
        Me.tabAprobacion.ResumeLayout(False)
        CType(Me.dgAprobacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPendientes.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.tabPrestamos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPrestamos.ResumeLayout(False)
        Me.pnlControles.ResumeLayout(False)
        Me.pnlCentrar.ResumeLayout(False)
        Me.pnlEncabezado.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents tabTabla As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents tabConsulta As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabAprobaciones As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents tabAprobacion As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabPrestamos As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlControles As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    'Friend WithEvents DataGridViewCheckBoxXColumn1 As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents dgAprobacion As DevComponents.DotNetBar.Controls.DataGridViewX
    'Friend WithEvents DataGridViewCheckBoxXColumn2 As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Private WithEvents dgConsulta As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents DataGridViewCheckBoxXColumn1 As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents btnLimpiar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnMostrarInformacion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GridColumn3 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn4 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn5 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn6 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn7 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn8 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlCentrar As System.Windows.Forms.Panel
    Friend WithEvents pnlPendientes As System.Windows.Forms.Panel
    Friend WithEvents lblPendientes As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnTodos As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GridColumn9 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents Pagada As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn1 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents Compañia As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents cmbCompa As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents cmbPeriodos As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents colUnico As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colAno As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colPeriodo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colFechaIni As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colFechaFin As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents clcomp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Reloj_alt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColReloj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFolio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConCantSolicitada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCantPagar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEnviarNomina As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
End Class
