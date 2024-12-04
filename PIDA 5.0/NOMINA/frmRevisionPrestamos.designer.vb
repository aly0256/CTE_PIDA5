<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRevisionPrestamos
    Inherits System.Windows.Forms.Form

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim Padding4 As DevComponents.DotNetBar.SuperGrid.Style.Padding = New DevComponents.DotNetBar.SuperGrid.Style.Padding()
        Dim Padding5 As DevComponents.DotNetBar.SuperGrid.Style.Padding = New DevComponents.DotNetBar.SuperGrid.Style.Padding()
        Dim Padding6 As DevComponents.DotNetBar.SuperGrid.Style.Padding = New DevComponents.DotNetBar.SuperGrid.Style.Padding()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRevisionPrestamos))
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GridColumn1 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn2 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn3 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn4 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn5 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn6 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn7 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn8 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn9 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn10 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn11 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn12 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn13 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn14 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn15 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.tabTabla = New DevComponents.DotNetBar.SuperTabItem()
        Me.tabConsulta = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgSuperPrestamos = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.mnuReimpresion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ReimprimirSolicitudToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CancelarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabAprobaciones = New DevComponents.DotNetBar.SuperTabItem()
        Me.tabAprobacion = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgAprobacion = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ColReloj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConCantSolicitada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCantPagar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDescuento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSemanas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMotivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRevAprobada = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.ColRechazo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlPendientes = New System.Windows.Forms.Panel()
        Me.lblPendientes = New System.Windows.Forms.Label()
        Me.btnTodos = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.tabPrestamos = New DevComponents.DotNetBar.SuperTabControl()
        Me.pnlControles = New System.Windows.Forms.Panel()
        Me.pnlCentrar = New System.Windows.Forms.Panel()
        Me.btnExportar = New DevComponents.DotNetBar.ButtonX()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.btnLimpiar = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.imgEstados = New System.Windows.Forms.ImageList(Me.components)
        Me.DataGridViewCheckBoxXColumn1 = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnMostrarInformacion = New DevComponents.DotNetBar.ButtonX()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.tabConsulta.SuspendLayout()
        Me.mnuReimpresion.SuspendLayout()
        Me.tabAprobacion.SuspendLayout()
        CType(Me.dgAprobacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPendientes.SuspendLayout()
        CType(Me.tabPrestamos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPrestamos.SuspendLayout()
        Me.pnlControles.SuspendLayout()
        Me.pnlCentrar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEncabezado.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridColumn1
        '
        Me.GridColumn1.FilterAutoScan = True
        Me.GridColumn1.Name = "Año"
        Me.GridColumn1.Width = 40
        '
        'GridColumn2
        '
        Me.GridColumn2.FilterAutoScan = True
        Me.GridColumn2.Name = "Periodo"
        Me.GridColumn2.Width = 50
        '
        'GridColumn3
        '
        Me.GridColumn3.Name = "Reloj"
        Me.GridColumn3.Width = 60
        '
        'GridColumn4
        '
        Me.GridColumn4.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDateTimePickerEditControl)
        Me.GridColumn4.FilterAutoScan = True
        Me.GridColumn4.Name = "Fecha"
        Me.GridColumn4.Width = 70
        '
        'GridColumn5
        '
        Me.GridColumn5.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
        Padding4.Right = 5
        Me.GridColumn5.CellStyles.Default.Padding = Padding4
        Me.GridColumn5.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl)
        Me.GridColumn5.HeaderText = "Cant.Sol."
        Me.GridColumn5.Name = "Cant.Sol."
        Me.GridColumn5.Width = 70
        '
        'GridColumn6
        '
        Me.GridColumn6.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
        Padding5.Right = 5
        Me.GridColumn6.CellStyles.Default.Padding = Padding5
        Me.GridColumn6.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl)
        Me.GridColumn6.Name = "Cant.Pag."
        Me.GridColumn6.Width = 70
        '
        'GridColumn7
        '
        Me.GridColumn7.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl)
        Me.GridColumn7.Name = "Tasa int."
        Me.GridColumn7.Width = 50
        '
        'GridColumn8
        '
        Me.GridColumn8.Name = "Sem."
        Me.GridColumn8.Width = 45
        '
        'GridColumn9
        '
        Me.GridColumn9.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
        Padding6.Right = 5
        Me.GridColumn9.CellStyles.Default.Padding = Padding6
        Me.GridColumn9.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl)
        Me.GridColumn9.Name = "Desc. sem."
        Me.GridColumn9.Width = 65
        '
        'GridColumn10
        '
        Me.GridColumn10.EnableGroupHeaderMarkup = True
        Me.GridColumn10.GroupBoxEffects = DevComponents.DotNetBar.SuperGrid.GroupBoxEffects.Copy
        Me.GridColumn10.Name = "Estado"
        '
        'GridColumn11
        '
        Me.GridColumn11.Name = "Motivo"
        Me.GridColumn11.Width = 130
        '
        'GridColumn12
        '
        Me.GridColumn12.FilterAutoScan = True
        Me.GridColumn12.Name = "Capturado por"
        Me.GridColumn12.Width = 130
        '
        'GridColumn13
        '
        Me.GridColumn13.FilterAutoScan = True
        Me.GridColumn13.Name = "Revisado por"
        Me.GridColumn13.Width = 130
        '
        'GridColumn14
        '
        Me.GridColumn14.Name = "Fecha rev."
        Me.GridColumn14.Width = 140
        '
        'GridColumn15
        '
        Me.GridColumn15.FilterAutoScan = True
        Me.GridColumn15.Name = "Motivo rechazo"
        Me.GridColumn15.Width = 130
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
        Me.ReflectionLabel1.Size = New System.Drawing.Size(320, 40)
        Me.ReflectionLabel1.TabIndex = 272
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>REVISIÓN DE PRÉSTAMOS</b></font>"
        '
        'tabTabla
        '
        Me.tabTabla.AttachedControl = Me.tabConsulta
        Me.tabTabla.GlobalItem = False
        Me.tabTabla.Name = "tabTabla"
        Me.tabTabla.Text = "Consulta"
        '
        'tabConsulta
        '
        Me.tabConsulta.Controls.Add(Me.dgSuperPrestamos)
        Me.tabConsulta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabConsulta.Location = New System.Drawing.Point(0, 0)
        Me.tabConsulta.Name = "tabConsulta"
        Me.tabConsulta.Size = New System.Drawing.Size(812, 416)
        Me.tabConsulta.TabIndex = 0
        Me.tabConsulta.TabItem = Me.tabTabla
        '
        'dgSuperPrestamos
        '
        Me.dgSuperPrestamos.ContextMenuStrip = Me.mnuReimpresion
        Me.dgSuperPrestamos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgSuperPrestamos.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.dgSuperPrestamos.ForeColor = System.Drawing.Color.Black
        Me.dgSuperPrestamos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.dgSuperPrestamos.Location = New System.Drawing.Point(0, 0)
        Me.dgSuperPrestamos.Name = "dgSuperPrestamos"
        '
        '
        '
        Me.dgSuperPrestamos.PrimaryGrid.AllowEdit = False
        Me.dgSuperPrestamos.PrimaryGrid.AllowRowHeaderResize = True
        Me.dgSuperPrestamos.PrimaryGrid.AllowRowResize = True
        Me.dgSuperPrestamos.PrimaryGrid.AutoExpandSetGroup = True
        Me.dgSuperPrestamos.PrimaryGrid.Columns.Add(Me.GridColumn1)
        Me.dgSuperPrestamos.PrimaryGrid.Columns.Add(Me.GridColumn2)
        Me.dgSuperPrestamos.PrimaryGrid.Columns.Add(Me.GridColumn3)
        Me.dgSuperPrestamos.PrimaryGrid.Columns.Add(Me.GridColumn4)
        Me.dgSuperPrestamos.PrimaryGrid.Columns.Add(Me.GridColumn5)
        Me.dgSuperPrestamos.PrimaryGrid.Columns.Add(Me.GridColumn6)
        Me.dgSuperPrestamos.PrimaryGrid.Columns.Add(Me.GridColumn7)
        Me.dgSuperPrestamos.PrimaryGrid.Columns.Add(Me.GridColumn8)
        Me.dgSuperPrestamos.PrimaryGrid.Columns.Add(Me.GridColumn9)
        Me.dgSuperPrestamos.PrimaryGrid.Columns.Add(Me.GridColumn10)
        Me.dgSuperPrestamos.PrimaryGrid.Columns.Add(Me.GridColumn11)
        Me.dgSuperPrestamos.PrimaryGrid.Columns.Add(Me.GridColumn12)
        Me.dgSuperPrestamos.PrimaryGrid.Columns.Add(Me.GridColumn13)
        Me.dgSuperPrestamos.PrimaryGrid.Columns.Add(Me.GridColumn14)
        Me.dgSuperPrestamos.PrimaryGrid.Columns.Add(Me.GridColumn15)
        Me.dgSuperPrestamos.PrimaryGrid.DefaultRowHeight = 24
        Me.dgSuperPrestamos.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.dgSuperPrestamos.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.dgSuperPrestamos.PrimaryGrid.EnableColumnFiltering = True
        Me.dgSuperPrestamos.PrimaryGrid.EnableFiltering = True
        Me.dgSuperPrestamos.PrimaryGrid.EnableRowFiltering = True
        '
        '
        '
        Me.dgSuperPrestamos.PrimaryGrid.Filter.Visible = True
        '
        '
        '
        Me.dgSuperPrestamos.PrimaryGrid.GroupByRow.GroupBoxEffects = DevComponents.DotNetBar.SuperGrid.GroupBoxEffects.Copy
        Me.dgSuperPrestamos.PrimaryGrid.GroupByRow.GroupBoxLayout = DevComponents.DotNetBar.SuperGrid.GroupBoxLayout.Flat
        Me.dgSuperPrestamos.PrimaryGrid.GroupByRow.Visible = True
        Me.dgSuperPrestamos.PrimaryGrid.GroupByRow.WatermarkText = "Arrastre la columna por la que desea agrupar"
        Me.dgSuperPrestamos.PrimaryGrid.GroupHeaderClickBehavior = DevComponents.DotNetBar.SuperGrid.GroupHeaderClickBehavior.ExpandCollapse
        Me.dgSuperPrestamos.PrimaryGrid.GroupHeaderKeyBehavior = DevComponents.DotNetBar.SuperGrid.GroupHeaderKeyBehavior.[Select]
        Me.dgSuperPrestamos.PrimaryGrid.GroupRowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.Always
        '
        '
        '
        Me.dgSuperPrestamos.PrimaryGrid.Header.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.Always
        Me.dgSuperPrestamos.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.Row
        Me.dgSuperPrestamos.PrimaryGrid.KeyboardEditMode = DevComponents.DotNetBar.SuperGrid.KeyboardEditMode.None
        Me.dgSuperPrestamos.PrimaryGrid.NullString = "<<null>>"
        Me.dgSuperPrestamos.PrimaryGrid.RowHeaderWidth = 20
        '
        '
        '
        Me.dgSuperPrestamos.PrimaryGrid.Title.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.PanelControlled
        Me.dgSuperPrestamos.PrimaryGrid.UseAlternateColumnStyle = True
        Me.dgSuperPrestamos.PrimaryGrid.UseAlternateRowStyle = True
        Me.dgSuperPrestamos.Size = New System.Drawing.Size(812, 416)
        Me.dgSuperPrestamos.TabIndex = 3
        Me.dgSuperPrestamos.Text = "Consulta de préstamos"
        '
        'mnuReimpresion
        '
        Me.mnuReimpresion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReimprimirSolicitudToolStripMenuItem, Me.ToolStripSeparator1, Me.CancelarToolStripMenuItem})
        Me.mnuReimpresion.Name = "mnuReimpresion"
        Me.mnuReimpresion.Size = New System.Drawing.Size(182, 54)
        '
        'ReimprimirSolicitudToolStripMenuItem
        '
        Me.ReimprimirSolicitudToolStripMenuItem.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.ReimprimirSolicitudToolStripMenuItem.Name = "ReimprimirSolicitudToolStripMenuItem"
        Me.ReimprimirSolicitudToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ReimprimirSolicitudToolStripMenuItem.Text = "Reimprimir solicitud"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(178, 6)
        '
        'CancelarToolStripMenuItem
        '
        Me.CancelarToolStripMenuItem.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.CancelarToolStripMenuItem.Name = "CancelarToolStripMenuItem"
        Me.CancelarToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.CancelarToolStripMenuItem.Text = "Cerrar"
        '
        'tabAprobaciones
        '
        Me.tabAprobaciones.AttachedControl = Me.tabAprobacion
        Me.tabAprobaciones.GlobalItem = False
        Me.tabAprobaciones.Name = "tabAprobaciones"
        Me.tabAprobaciones.Text = "Aprobación"
        '
        'tabAprobacion
        '
        Me.tabAprobacion.Controls.Add(Me.dgAprobacion)
        Me.tabAprobacion.Controls.Add(Me.pnlPendientes)
        Me.tabAprobacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabAprobacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabAprobacion.Location = New System.Drawing.Point(0, 0)
        Me.tabAprobacion.Name = "tabAprobacion"
        Me.tabAprobacion.Size = New System.Drawing.Size(815, 416)
        Me.tabAprobacion.TabIndex = 63
        Me.tabAprobacion.TabItem = Me.tabAprobaciones
        '
        'dgAprobacion
        '
        Me.dgAprobacion.AllowUserToAddRows = False
        Me.dgAprobacion.AllowUserToDeleteRows = False
        Me.dgAprobacion.AllowUserToOrderColumns = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAprobacion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgAprobacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAprobacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColReloj, Me.ColFecha, Me.ConCantSolicitada, Me.ColCantPagar, Me.ColDescuento, Me.ColSemanas, Me.ColMotivo, Me.ColRevAprobada, Me.ColRechazo})
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgAprobacion.DefaultCellStyle = DataGridViewCellStyle19
        Me.dgAprobacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgAprobacion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgAprobacion.EnableHeadersVisualStyles = False
        Me.dgAprobacion.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgAprobacion.Location = New System.Drawing.Point(0, 35)
        Me.dgAprobacion.MultiSelect = False
        Me.dgAprobacion.Name = "dgAprobacion"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAprobacion.RowHeadersDefaultCellStyle = DataGridViewCellStyle20
        Me.dgAprobacion.RowHeadersVisible = False
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgAprobacion.RowsDefaultCellStyle = DataGridViewCellStyle21
        Me.dgAprobacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgAprobacion.Size = New System.Drawing.Size(815, 381)
        Me.dgAprobacion.TabIndex = 2
        Me.dgAprobacion.VirtualMode = True
        '
        'ColReloj
        '
        Me.ColReloj.DataPropertyName = "reloj"
        Me.ColReloj.HeaderText = "Reloj"
        Me.ColReloj.Name = "ColReloj"
        Me.ColReloj.ReadOnly = True
        Me.ColReloj.Width = 55
        '
        'ColFecha
        '
        Me.ColFecha.DataPropertyName = "fecha"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColFecha.DefaultCellStyle = DataGridViewCellStyle13
        Me.ColFecha.HeaderText = "Fecha"
        Me.ColFecha.Name = "ColFecha"
        Me.ColFecha.ReadOnly = True
        Me.ColFecha.Width = 75
        '
        'ConCantSolicitada
        '
        Me.ConCantSolicitada.DataPropertyName = "cantidad_sol"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "c2"
        Me.ConCantSolicitada.DefaultCellStyle = DataGridViewCellStyle14
        Me.ConCantSolicitada.HeaderText = "Cantidad solicitada"
        Me.ConCantSolicitada.Name = "ConCantSolicitada"
        Me.ConCantSolicitada.ReadOnly = True
        Me.ConCantSolicitada.Width = 75
        '
        'ColCantPagar
        '
        Me.ColCantPagar.DataPropertyName = "cantidad_pag"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "c2"
        Me.ColCantPagar.DefaultCellStyle = DataGridViewCellStyle15
        Me.ColCantPagar.HeaderText = "Cantidad a pagar"
        Me.ColCantPagar.Name = "ColCantPagar"
        Me.ColCantPagar.ReadOnly = True
        Me.ColCantPagar.Width = 75
        '
        'ColDescuento
        '
        Me.ColDescuento.DataPropertyName = "descuento_sem"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "c2"
        Me.ColDescuento.DefaultCellStyle = DataGridViewCellStyle16
        Me.ColDescuento.HeaderText = "Descuento semanal"
        Me.ColDescuento.Name = "ColDescuento"
        Me.ColDescuento.ReadOnly = True
        Me.ColDescuento.Width = 65
        '
        'ColSemanas
        '
        Me.ColSemanas.DataPropertyName = "semanas_pag"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.ColSemanas.DefaultCellStyle = DataGridViewCellStyle17
        Me.ColSemanas.HeaderText = "Sem."
        Me.ColSemanas.Name = "ColSemanas"
        Me.ColSemanas.ReadOnly = True
        Me.ColSemanas.Width = 45
        '
        'ColMotivo
        '
        Me.ColMotivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColMotivo.DataPropertyName = "motivo_pmo"
        Me.ColMotivo.HeaderText = "Motivo"
        Me.ColMotivo.Name = "ColMotivo"
        Me.ColMotivo.ReadOnly = True
        '
        'ColRevAprobada
        '
        Me.ColRevAprobada.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.ColRevAprobada.CheckBoxImageIndeterminate = Global.PIDA.My.Resources.Resources.Question16
        Me.ColRevAprobada.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.CancelX
        Me.ColRevAprobada.Checked = True
        Me.ColRevAprobada.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.ColRevAprobada.CheckValue = "N"
        Me.ColRevAprobada.CheckValueChecked = "1"
        Me.ColRevAprobada.CheckValueIndeterminate = "0"
        Me.ColRevAprobada.CheckValueUnchecked = "2"
        Me.ColRevAprobada.DataPropertyName = "aprobada"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.Format = "N0"
        DataGridViewCellStyle18.NullValue = "0"
        Me.ColRevAprobada.DefaultCellStyle = DataGridViewCellStyle18
        Me.ColRevAprobada.EnableMarkup = False
        Me.ColRevAprobada.HeaderText = "Aprobada"
        Me.ColRevAprobada.Name = "ColRevAprobada"
        Me.ColRevAprobada.ThreeState = True
        Me.ColRevAprobada.Width = 60
        '
        'ColRechazo
        '
        Me.ColRechazo.DataPropertyName = "motivo_rechazo"
        Me.ColRechazo.HeaderText = "MotivoRechazo"
        Me.ColRechazo.Name = "ColRechazo"
        Me.ColRechazo.Visible = False
        '
        'pnlPendientes
        '
        Me.pnlPendientes.BackColor = System.Drawing.Color.White
        Me.pnlPendientes.Controls.Add(Me.lblPendientes)
        Me.pnlPendientes.Controls.Add(Me.btnTodos)
        Me.pnlPendientes.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPendientes.Location = New System.Drawing.Point(0, 0)
        Me.pnlPendientes.Name = "pnlPendientes"
        Me.pnlPendientes.Size = New System.Drawing.Size(815, 35)
        Me.pnlPendientes.TabIndex = 5
        '
        'lblPendientes
        '
        Me.lblPendientes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendientes.Location = New System.Drawing.Point(0, 0)
        Me.lblPendientes.Name = "lblPendientes"
        Me.lblPendientes.Size = New System.Drawing.Size(691, 35)
        Me.lblPendientes.TabIndex = 0
        Me.lblPendientes.Text = "PRÉSTAMOS PENDIENTES DE APROBACIÓN"
        Me.lblPendientes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnTodos
        '
        '
        '
        '
        Me.btnTodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnTodos.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTodos.Location = New System.Drawing.Point(691, 0)
        Me.btnTodos.Name = "btnTodos"
        Me.btnTodos.OffBackColor = System.Drawing.Color.Maroon
        Me.btnTodos.OffText = "Rechazar todos"
        Me.btnTodos.OffTextColor = System.Drawing.SystemColors.Window
        Me.btnTodos.OnText = "Aprobar todos"
        Me.btnTodos.OnTextColor = System.Drawing.Color.Black
        Me.btnTodos.Size = New System.Drawing.Size(124, 35)
        Me.btnTodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnTodos.SwitchBackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnTodos.SwitchBorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnTodos.TabIndex = 4
        Me.btnTodos.Value = True
        Me.btnTodos.ValueObject = "Y"
        '
        'tabPrestamos
        '
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
        Me.tabPrestamos.Controls.Add(Me.tabConsulta)
        Me.tabPrestamos.Controls.Add(Me.tabAprobacion)
        Me.tabPrestamos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabPrestamos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabPrestamos.Location = New System.Drawing.Point(0, 61)
        Me.tabPrestamos.Name = "tabPrestamos"
        Me.tabPrestamos.ReorderTabsEnabled = True
        Me.tabPrestamos.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabPrestamos.SelectedTabIndex = 0
        Me.tabPrestamos.Size = New System.Drawing.Size(895, 416)
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
        Me.pnlControles.Location = New System.Drawing.Point(0, 477)
        Me.pnlControles.Name = "pnlControles"
        Me.pnlControles.Size = New System.Drawing.Size(895, 35)
        Me.pnlControles.TabIndex = 275
        '
        'pnlCentrar
        '
        Me.pnlCentrar.Controls.Add(Me.btnExportar)
        Me.pnlCentrar.Controls.Add(Me.btnBuscar)
        Me.pnlCentrar.Controls.Add(Me.btnLimpiar)
        Me.pnlCentrar.Controls.Add(Me.btnReporte)
        Me.pnlCentrar.Controls.Add(Me.btnCerrar)
        Me.pnlCentrar.Location = New System.Drawing.Point(231, 2)
        Me.pnlCentrar.Name = "pnlCentrar"
        Me.pnlCentrar.Size = New System.Drawing.Size(433, 30)
        Me.pnlCentrar.TabIndex = 45
        '
        'btnExportar
        '
        Me.btnExportar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnExportar.CausesValidation = False
        Me.btnExportar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Image = Global.PIDA.My.Resources.Resources.Save16
        Me.btnExportar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnExportar.Location = New System.Drawing.Point(3, 3)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(78, 25)
        Me.btnExportar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnExportar.TabIndex = 44
        Me.btnExportar.Text = "Exportar"
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBuscar.Location = New System.Drawing.Point(187, 3)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(78, 25)
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
        Me.btnLimpiar.Location = New System.Drawing.Point(85, 3)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(98, 25)
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
        Me.btnReporte.Location = New System.Drawing.Point(269, 3)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
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
        Me.btnCerrar.Location = New System.Drawing.Point(351, 3)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 42
        Me.btnCerrar.Text = "Salir"
        '
        'imgEstados
        '
        Me.imgEstados.ImageStream = CType(resources.GetObject("imgEstados.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgEstados.TransparentColor = System.Drawing.Color.Transparent
        Me.imgEstados.Images.SetKeyName(0, "APROBADO")
        Me.imgEstados.Images.SetKeyName(1, "RECHAZADO")
        Me.imgEstados.Images.SetKeyName(2, "PENDIENTE")
        '
        'DataGridViewCheckBoxXColumn1
        '
        Me.DataGridViewCheckBoxXColumn1.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.DataGridViewCheckBoxXColumn1.CheckBoxImageIndeterminate = Global.PIDA.My.Resources.Resources.ZA24
        Me.DataGridViewCheckBoxXColumn1.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.CancelX
        Me.DataGridViewCheckBoxXColumn1.Checked = True
        Me.DataGridViewCheckBoxXColumn1.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.DataGridViewCheckBoxXColumn1.CheckValue = "N"
        Me.DataGridViewCheckBoxXColumn1.CheckValueChecked = "1"
        Me.DataGridViewCheckBoxXColumn1.CheckValueIndeterminate = "0"
        Me.DataGridViewCheckBoxXColumn1.CheckValueUnchecked = "2"
        Me.DataGridViewCheckBoxXColumn1.ConsiderEmptyStringAsNull = False
        Me.DataGridViewCheckBoxXColumn1.DataPropertyName = "aprobada"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewCheckBoxXColumn1.DefaultCellStyle = DataGridViewCellStyle22
        Me.DataGridViewCheckBoxXColumn1.HeaderText = "Aprobada"
        Me.DataGridViewCheckBoxXColumn1.Name = "DataGridViewCheckBoxXColumn1"
        Me.DataGridViewCheckBoxXColumn1.ThreeState = True
        Me.DataGridViewCheckBoxXColumn1.Width = 60
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.RevisionPrestamos32
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
        Me.btnMostrarInformacion.Image = Global.PIDA.My.Resources.Resources.refresh16
        Me.btnMostrarInformacion.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnMostrarInformacion.Location = New System.Drawing.Point(858, 0)
        Me.btnMostrarInformacion.Name = "btnMostrarInformacion"
        Me.btnMostrarInformacion.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(20)
        Me.btnMostrarInformacion.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5)
        Me.btnMostrarInformacion.Size = New System.Drawing.Size(37, 61)
        Me.btnMostrarInformacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnMostrarInformacion.TabIndex = 276
        Me.btnMostrarInformacion.Tooltip = "Actualizar información"
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.Controls.Add(Me.PictureBox1)
        Me.pnlEncabezado.Controls.Add(Me.ReflectionLabel1)
        Me.pnlEncabezado.Controls.Add(Me.btnMostrarInformacion)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(895, 61)
        Me.pnlEncabezado.TabIndex = 277
        '
        'frmRevisionPrestamos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(895, 512)
        Me.Controls.Add(Me.tabPrestamos)
        Me.Controls.Add(Me.pnlControles)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRevisionPrestamos"
        Me.Text = "Préstamos"
        Me.tabConsulta.ResumeLayout(False)
        Me.mnuReimpresion.ResumeLayout(False)
        Me.tabAprobacion.ResumeLayout(False)
        CType(Me.dgAprobacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPendientes.ResumeLayout(False)
        CType(Me.tabPrestamos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPrestamos.ResumeLayout(False)
        Me.pnlControles.ResumeLayout(False)
        Me.pnlCentrar.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEncabezado.ResumeLayout(False)
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
    Private WithEvents dgSuperPrestamos As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Private WithEvents imgEstados As System.Windows.Forms.ImageList
    Friend WithEvents btnTodos As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents DataGridViewCheckBoxXColumn1 As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents btnLimpiar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnExportar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents mnuReimpresion As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ReimprimirSolicitudToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CancelarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColReloj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConCantSolicitada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCantPagar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDescuento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSemanas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMotivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRevAprobada As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents ColRechazo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnMostrarInformacion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GridColumn1 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn2 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn3 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn4 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn5 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn6 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn7 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn8 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn9 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn10 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn11 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn12 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn13 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn14 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn15 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlCentrar As System.Windows.Forms.Panel
    Friend WithEvents pnlPendientes As System.Windows.Forms.Panel
    Friend WithEvents lblPendientes As System.Windows.Forms.Label
End Class
