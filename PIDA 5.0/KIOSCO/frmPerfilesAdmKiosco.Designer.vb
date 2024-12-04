<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPerfilesAdmKiosco
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
        Dim Padding1 As DevComponents.DotNetBar.SuperGrid.Style.Padding = New DevComponents.DotNetBar.SuperGrid.Style.Padding()
        Dim Padding2 As DevComponents.DotNetBar.SuperGrid.Style.Padding = New DevComponents.DotNetBar.SuperGrid.Style.Padding()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPerfilesAdmKiosco))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tabBuscar = New DevComponents.DotNetBar.SuperTabControl()
        Me.pnlFormas = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgFormas = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.GridColumn7 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn8 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn9 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkTodosFormas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tabFormas = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.pnlExcepciones = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GridColumn13 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn14 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn15 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn16 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CiasPantalla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CiasControl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CiasAcceso = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.EmpNav = New System.Windows.Forms.GroupBox()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrimero = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnAnterior = New DevComponents.DotNetBar.ButtonX()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnSiguiente = New DevComponents.DotNetBar.ButtonX()
        Me.btnUltimo = New DevComponents.DotNetBar.ButtonX()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.gpAvance = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.pbAvance = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.lblAvance = New System.Windows.Forms.Label()
        Me.bgwRefresca = New System.ComponentModel.BackgroundWorker()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBuscar.SuspendLayout()
        Me.pnlFormas.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        Me.pnlExcepciones.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.EmpNav.SuspendLayout()
        Me.gpAvance.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Profile32
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(27, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 85
        Me.PictureBox1.TabStop = False
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
        Me.ReflectionLabel1.Size = New System.Drawing.Size(544, 40)
        Me.ReflectionLabel1.TabIndex = 84
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>PERFILES DE USUARIO ADMINISTRADOR KIOSCO</b></font>"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 89
        Me.Label1.Text = "Código"
        '
        'txtCodigo
        '
        '
        '
        '
        Me.txtCodigo.Border.Class = "TextBoxBorder"
        Me.txtCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(68, 58)
        Me.txtCodigo.MaxLength = 15
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(153, 21)
        Me.txtCodigo.TabIndex = 86
        '
        'txtNombre
        '
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(285, 58)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(447, 21)
        Me.txtNombre.TabIndex = 87
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(227, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 88
        Me.Label2.Text = "Nombre"
        '
        'tabBuscar
        '
        '
        '
        '
        '
        '
        '
        Me.tabBuscar.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.tabBuscar.ControlBox.MenuBox.Name = ""
        Me.tabBuscar.ControlBox.MenuBox.Visible = False
        Me.tabBuscar.ControlBox.Name = ""
        Me.tabBuscar.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabBuscar.ControlBox.MenuBox, Me.tabBuscar.ControlBox.CloseBox})
        Me.tabBuscar.Controls.Add(Me.pnlFormas)
        Me.tabBuscar.Controls.Add(Me.SuperTabControlPanel2)
        Me.tabBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.Location = New System.Drawing.Point(16, 85)
        Me.tabBuscar.Name = "tabBuscar"
        Me.tabBuscar.ReorderTabsEnabled = True
        Me.tabBuscar.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabBuscar.SelectedTabIndex = 0
        Me.tabBuscar.Size = New System.Drawing.Size(782, 450)
        Me.tabBuscar.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.tabBuscar.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.TabIndex = 90
        Me.tabBuscar.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabFormas})
        Me.tabBuscar.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        '
        'pnlFormas
        '
        Me.pnlFormas.Controls.Add(Me.dgFormas)
        Me.pnlFormas.Controls.Add(Me.Panel1)
        Me.pnlFormas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFormas.Location = New System.Drawing.Point(0, 0)
        Me.pnlFormas.Name = "pnlFormas"
        Me.pnlFormas.Size = New System.Drawing.Size(721, 450)
        Me.pnlFormas.TabIndex = 1
        Me.pnlFormas.TabItem = Me.tabFormas
        '
        'dgFormas
        '
        Me.dgFormas.DefaultVisualStyles.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.dgFormas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgFormas.ExpandButtonType = DevComponents.DotNetBar.SuperGrid.ExpandButtonType.Square
        Me.dgFormas.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.dgFormas.ForeColor = System.Drawing.Color.Black
        Me.dgFormas.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.dgFormas.Location = New System.Drawing.Point(0, 25)
        Me.dgFormas.Name = "dgFormas"
        '
        '
        '
        '
        '
        '
        Me.dgFormas.PrimaryGrid.Caption.Visible = False
        Me.dgFormas.PrimaryGrid.Columns.Add(Me.GridColumn7)
        Me.dgFormas.PrimaryGrid.Columns.Add(Me.GridColumn8)
        Me.dgFormas.PrimaryGrid.Columns.Add(Me.GridColumn9)
        Me.dgFormas.PrimaryGrid.DefaultRowHeight = 30
        Me.dgFormas.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft
        Me.dgFormas.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[False]
        Me.dgFormas.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.dgFormas.PrimaryGrid.DefaultVisualStyles.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.dgFormas.PrimaryGrid.EnableColumnFiltering = True
        Me.dgFormas.PrimaryGrid.EnableFiltering = True
        Me.dgFormas.PrimaryGrid.EnableRowFiltering = True
        Me.dgFormas.PrimaryGrid.EnsureVisibleAfterGrouping = True
        Me.dgFormas.PrimaryGrid.EnsureVisibleAfterSort = True
        '
        '
        '
        Me.dgFormas.PrimaryGrid.Filter.ShowPanelFilterExpr = True
        Me.dgFormas.PrimaryGrid.Filter.Visible = True
        Me.dgFormas.PrimaryGrid.FilterLevel = CType((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root Or DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded), DevComponents.DotNetBar.SuperGrid.FilterLevel)
        Me.dgFormas.PrimaryGrid.FrozenColumnCount = 1
        '
        '
        '
        Me.dgFormas.PrimaryGrid.GroupByRow.Text = ""
        Me.dgFormas.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.Row
        Me.dgFormas.PrimaryGrid.KeyboardEditMode = DevComponents.DotNetBar.SuperGrid.KeyboardEditMode.None
        Me.dgFormas.PrimaryGrid.RowHeaderWidth = 20
        Me.dgFormas.PrimaryGrid.ShowRowGridIndex = True
        Me.dgFormas.PrimaryGrid.ShowRowHeaders = False
        Me.dgFormas.PrimaryGrid.UseAlternateRowStyle = True
        Me.dgFormas.Size = New System.Drawing.Size(721, 425)
        Me.dgFormas.TabIndex = 287
        '
        'GridColumn7
        '
        Me.GridColumn7.AllowEdit = False
        Me.GridColumn7.DataPropertyName = "modulo"
        Me.GridColumn7.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn7.FilterAutoScan = True
        Me.GridColumn7.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.Wildcards
        Me.GridColumn7.Name = "Módulo"
        Me.GridColumn7.Width = 150
        '
        'GridColumn8
        '
        Me.GridColumn8.AllowEdit = False
        Me.GridColumn8.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill
        Me.GridColumn8.DataPropertyName = "forma"
        Me.GridColumn8.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn8.FilterAutoScan = True
        Me.GridColumn8.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.Wildcards
        Me.GridColumn8.Name = "Forma"
        '
        'GridColumn9
        '
        Me.GridColumn9.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColumn9.CellStyles.Default.ImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColumn9.CellStyles.Default.TextColor = System.Drawing.Color.Red
        Me.GridColumn9.CellStyles.ReadOnly.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColumn9.DataPropertyName = "acceso"
        Me.GridColumn9.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl)
        Me.GridColumn9.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn9.Name = "Acceso"
        Me.GridColumn9.Width = 80
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Controls.Add(Me.chkTodosFormas)
        Me.Panel1.Controls.Add(Me.Label27)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(721, 25)
        Me.Panel1.TabIndex = 286
        '
        'chkTodosFormas
        '
        '
        '
        '
        Me.chkTodosFormas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkTodosFormas.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.chkTodosFormas.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.Unckecked16
        Me.chkTodosFormas.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Right
        Me.chkTodosFormas.Dock = System.Windows.Forms.DockStyle.Right
        Me.chkTodosFormas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTodosFormas.Location = New System.Drawing.Point(579, 0)
        Me.chkTodosFormas.Name = "chkTodosFormas"
        Me.chkTodosFormas.Size = New System.Drawing.Size(142, 25)
        Me.chkTodosFormas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkTodosFormas.TabIndex = 285
        Me.chkTodosFormas.Text = "Marcar todos"
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label27.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(0, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(716, 25)
        Me.Label27.TabIndex = 284
        Me.Label27.Text = "Seleccione las formas a las que tendrá acceso este perfil"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabFormas
        '
        Me.tabFormas.AttachedControl = Me.pnlFormas
        Me.tabFormas.GlobalItem = False
        Me.tabFormas.Name = "tabFormas"
        Me.tabFormas.Text = "Formas"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.pnlExcepciones)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(721, 450)
        Me.SuperTabControlPanel2.TabIndex = 0
        '
        'pnlExcepciones
        '
        Me.pnlExcepciones.Controls.Add(Me.Panel5)
        Me.pnlExcepciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlExcepciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlExcepciones.Name = "pnlExcepciones"
        Me.pnlExcepciones.Size = New System.Drawing.Size(721, 450)
        Me.pnlExcepciones.TabIndex = 3
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel5.Controls.Add(Me.Label11)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(721, 25)
        Me.Panel5.TabIndex = 287
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(0, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(716, 25)
        Me.Label11.TabIndex = 284
        Me.Label11.Text = "Agrege/modifique las excepciones a los controles por forma"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GridColumn13
        '
        Me.GridColumn13.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft
        Padding1.Left = 5
        Me.GridColumn13.CellStyles.Default.Padding = Padding1
        Me.GridColumn13.DataPropertyName = "nombre_forma"
        Me.GridColumn13.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn13.FilterAutoScan = True
        Me.GridColumn13.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.Wildcards
        Me.GridColumn13.Name = "Forma"
        Me.GridColumn13.Width = 150
        '
        'GridColumn14
        '
        Me.GridColumn14.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill
        Me.GridColumn14.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft
        Padding2.Left = 5
        Me.GridColumn14.CellStyles.Default.Padding = Padding2
        Me.GridColumn14.DataPropertyName = "nombre_control"
        Me.GridColumn14.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn14.FilterAutoScan = True
        Me.GridColumn14.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.Wildcards
        Me.GridColumn14.Name = "Control"
        '
        'GridColumn15
        '
        Me.GridColumn15.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColumn15.DataPropertyName = "visible"
        Me.GridColumn15.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl)
        Me.GridColumn15.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn15.FilterAutoScan = True
        Me.GridColumn15.Name = "Visible"
        '
        'GridColumn16
        '
        Me.GridColumn16.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColumn16.DataPropertyName = "habilitado"
        Me.GridColumn16.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl)
        Me.GridColumn16.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn16.FilterAutoScan = True
        Me.GridColumn16.Name = "Habilitado"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.Panel4)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(740, 450)
        Me.SuperTabControlPanel1.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(740, 25)
        Me.Panel4.TabIndex = 288
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(716, 25)
        Me.Label7.TabIndex = 284
        Me.Label7.Text = "Seleccione las formas a las que tendrá acceso este perfil"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CiasPantalla
        '
        Me.CiasPantalla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.CiasPantalla.DataPropertyName = "pantalla"
        Me.CiasPantalla.HeaderText = "Pantalla"
        Me.CiasPantalla.Name = "CiasPantalla"
        '
        'CiasControl
        '
        Me.CiasControl.DataPropertyName = "control"
        Me.CiasControl.HeaderText = "control"
        Me.CiasControl.Name = "CiasControl"
        Me.CiasControl.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CiasControl.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CiasControl.Visible = False
        '
        'CiasAcceso
        '
        Me.CiasAcceso.DataPropertyName = "acceso"
        Me.CiasAcceso.HeaderText = "Acceso"
        Me.CiasAcceso.Name = "CiasAcceso"
        '
        'EmpNav
        '
        Me.EmpNav.Controls.Add(Me.btnCerrar)
        Me.EmpNav.Controls.Add(Me.btnPrimero)
        Me.EmpNav.Controls.Add(Me.btnReporte)
        Me.EmpNav.Controls.Add(Me.btnAnterior)
        Me.EmpNav.Controls.Add(Me.btnBorrar)
        Me.EmpNav.Controls.Add(Me.btnSiguiente)
        Me.EmpNav.Controls.Add(Me.btnUltimo)
        Me.EmpNav.Controls.Add(Me.btnBuscar)
        Me.EmpNav.Controls.Add(Me.btnEditar)
        Me.EmpNav.Controls.Add(Me.btnNuevo)
        Me.EmpNav.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.EmpNav.Location = New System.Drawing.Point(0, 539)
        Me.EmpNav.Name = "EmpNav"
        Me.EmpNav.Size = New System.Drawing.Size(857, 47)
        Me.EmpNav.TabIndex = 91
        Me.EmpNav.TabStop = False
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(736, 13)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 9
        Me.btnCerrar.Text = "Salir"
        '
        'btnPrimero
        '
        Me.btnPrimero.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrimero.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrimero.Image = Global.PIDA.My.Resources.Resources.First16
        Me.btnPrimero.Location = New System.Drawing.Point(7, 13)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(78, 25)
        Me.btnPrimero.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrimero.TabIndex = 0
        Me.btnPrimero.Text = "Inicio"
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnReporte.Location = New System.Drawing.Point(412, 13)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 5
        Me.btnReporte.Text = "Reporte"
        '
        'btnAnterior
        '
        Me.btnAnterior.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAnterior.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAnterior.Image = Global.PIDA.My.Resources.Resources.Prev16
        Me.btnAnterior.Location = New System.Drawing.Point(88, 13)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(78, 25)
        Me.btnAnterior.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAnterior.TabIndex = 1
        Me.btnAnterior.Text = "Anterior"
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = Global.PIDA.My.Resources.Resources.DeleteRec
        Me.btnBorrar.Location = New System.Drawing.Point(655, 13)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(78, 25)
        Me.btnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBorrar.TabIndex = 8
        Me.btnBorrar.Text = "Borrar"
        '
        'btnSiguiente
        '
        Me.btnSiguiente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSiguiente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSiguiente.Image = Global.PIDA.My.Resources.Resources.Next16
        Me.btnSiguiente.Location = New System.Drawing.Point(169, 13)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(78, 25)
        Me.btnSiguiente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSiguiente.TabIndex = 2
        Me.btnSiguiente.Text = "Siguiente"
        '
        'btnUltimo
        '
        Me.btnUltimo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnUltimo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnUltimo.Image = Global.PIDA.My.Resources.Resources.Last16
        Me.btnUltimo.Location = New System.Drawing.Point(250, 13)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(78, 25)
        Me.btnUltimo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnUltimo.TabIndex = 3
        Me.btnUltimo.Text = "Final"
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscar.Location = New System.Drawing.Point(331, 13)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(78, 25)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Tooltip = "Buscar"
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = Global.PIDA.My.Resources.Resources.Edit
        Me.btnEditar.Location = New System.Drawing.Point(574, 13)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(78, 25)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 7
        Me.btnEditar.Text = "Editar"
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.NewRecord
        Me.btnNuevo.Location = New System.Drawing.Point(493, 13)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 25)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 6
        Me.btnNuevo.Text = "Agregar"
        '
        'gpAvance
        '
        Me.gpAvance.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpAvance.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpAvance.Controls.Add(Me.pbAvance)
        Me.gpAvance.Controls.Add(Me.lblAvance)
        Me.gpAvance.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpAvance.Location = New System.Drawing.Point(321, 184)
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
        Me.gpAvance.TabIndex = 277
        Me.gpAvance.Visible = False
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
        Me.pbAvance.TabIndex = 0
        '
        'lblAvance
        '
        Me.lblAvance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblAvance.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblAvance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvance.Location = New System.Drawing.Point(0, 155)
        Me.lblAvance.Name = "lblAvance"
        Me.lblAvance.Size = New System.Drawing.Size(218, 60)
        Me.lblAvance.TabIndex = 1
        Me.lblAvance.Text = "Preparando datos..."
        Me.lblAvance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'bgwRefresca
        '
        Me.bgwRefresca.WorkerReportsProgress = True
        Me.bgwRefresca.WorkerSupportsCancellation = True
        '
        'frmPerfilesAdmKiosco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(857, 586)
        Me.Controls.Add(Me.gpAvance)
        Me.Controls.Add(Me.EmpNav)
        Me.Controls.Add(Me.tabBuscar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPerfilesAdmKiosco"
        Me.Text = "Perfiles Admistrador Kiosco"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBuscar.ResumeLayout(False)
        Me.pnlFormas.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        Me.pnlExcepciones.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.EmpNav.ResumeLayout(False)
        Me.gpAvance.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tabBuscar As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents pnlFormas As DevComponents.DotNetBar.SuperTabControlPanel
    Private WithEvents dgFormas As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents GridColumn7 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn8 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn9 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chkTodosFormas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents tabFormas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents pnlExcepciones As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents GridColumn13 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn14 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn15 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn16 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents EmpNav As System.Windows.Forms.GroupBox
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrimero As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAnterior As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSiguiente As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnUltimo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents gpAvance As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents pbAvance As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents lblAvance As System.Windows.Forms.Label
    Friend WithEvents bgwRefresca As System.ComponentModel.BackgroundWorker
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents CiasPantalla As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CiasControl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CiasAcceso As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
