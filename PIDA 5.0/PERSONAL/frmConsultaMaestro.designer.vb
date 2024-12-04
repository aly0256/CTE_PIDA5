<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaMaestro
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaMaestro))
        Me.GridColumn1 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn2 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn3 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn4 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn5 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn6 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn7 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.pnlControles = New System.Windows.Forms.Panel()
        Me.pnlCentrado = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnExportar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.lblCuantos = New System.Windows.Forms.Label()
        Me.mnuEditar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuCopiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuOcultar = New System.Windows.Forms.ToolStripMenuItem()
        Me.MostrarTodasLasColumnasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DataGridViewCheckBoxXColumn1 = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.dgMaestro = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.COMP = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn11 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn9 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn12 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn13 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.dlgArchivo = New System.Windows.Forms.SaveFileDialog()
        Me.bckCarga = New System.ComponentModel.BackgroundWorker()
        Me.gpAvance = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.lblAvance = New System.Windows.Forms.Label()
        Me.pbAvance = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.pnlControles.SuspendLayout()
        Me.pnlCentrado.SuspendLayout()
        Me.mnuEditar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTitulo.SuspendLayout()
        Me.gpAvance.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridColumn1
        '
        Me.GridColumn1.DataPropertyName = "reloj"
        Me.GridColumn1.Name = "RELOJ"
        '
        'GridColumn2
        '
        Me.GridColumn2.DataPropertyName = "nombres"
        Me.GridColumn2.Name = "NOMBRES"
        Me.GridColumn2.Width = 180
        '
        'GridColumn3
        '
        Me.GridColumn3.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColumn3.DataPropertyName = "alta"
        Me.GridColumn3.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDateTimeInputEditControl)
        Me.GridColumn3.Name = "ALTA"
        Me.GridColumn3.Width = 70
        '
        'GridColumn4
        '
        Me.GridColumn4.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColumn4.DataPropertyName = "baja"
        Me.GridColumn4.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDateTimePickerEditControl)
        Me.GridColumn4.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.DateTime
        Me.GridColumn4.Name = "BAJA"
        Me.GridColumn4.Width = 70
        '
        'GridColumn5
        '
        Me.GridColumn5.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColumn5.DataPropertyName = "sexo"
        Me.GridColumn5.FilterAutoScan = True
        Me.GridColumn5.Name = "SEXO"
        Me.GridColumn5.Width = 50
        '
        'GridColumn6
        '
        Me.GridColumn6.DataPropertyName = "imss"
        Me.GridColumn6.Name = "IMSS"
        '
        'GridColumn7
        '
        Me.GridColumn7.DataPropertyName = "rfc"
        Me.GridColumn7.Name = "RFC"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(53, 16)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(465, 40)
        Me.ReflectionLabel1.TabIndex = 272
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>HEADCOUNT DINÁMICO</b></font>"
        '
        'pnlControles
        '
        Me.pnlControles.Controls.Add(Me.pnlCentrado)
        Me.pnlControles.Controls.Add(Me.lblCuantos)
        Me.pnlControles.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlControles.Location = New System.Drawing.Point(0, 452)
        Me.pnlControles.Name = "pnlControles"
        Me.pnlControles.Size = New System.Drawing.Size(1036, 68)
        Me.pnlControles.TabIndex = 275
        '
        'pnlCentrado
        '
        Me.pnlCentrado.Controls.Add(Me.btnLimpiar)
        Me.pnlCentrado.Controls.Add(Me.btnReporte)
        Me.pnlCentrado.Controls.Add(Me.btnExportar)
        Me.pnlCentrado.Controls.Add(Me.btnCerrar)
        Me.pnlCentrado.Location = New System.Drawing.Point(238, 26)
        Me.pnlCentrado.Name = "pnlCentrado"
        Me.pnlCentrado.Size = New System.Drawing.Size(356, 35)
        Me.pnlCentrado.TabIndex = 46
        '
        'btnLimpiar
        '
        Me.btnLimpiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLimpiar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLimpiar.Image = Global.PIDA.My.Resources.Resources.LimpiaFiltroHC
        Me.btnLimpiar.Location = New System.Drawing.Point(3, 3)
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
        Me.btnReporte.Location = New System.Drawing.Point(191, 3)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 38
        Me.btnReporte.Text = "Reporte"
        '
        'btnExportar
        '
        Me.btnExportar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnExportar.CausesValidation = False
        Me.btnExportar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Image = Global.PIDA.My.Resources.Resources.Save16
        Me.btnExportar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnExportar.Location = New System.Drawing.Point(107, 3)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(78, 25)
        Me.btnExportar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnExportar.TabIndex = 44
        Me.btnExportar.Text = "Exportar"
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
        Me.btnCerrar.Location = New System.Drawing.Point(275, 3)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 42
        Me.btnCerrar.Text = "Salir"
        '
        'lblCuantos
        '
        Me.lblCuantos.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCuantos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuantos.Location = New System.Drawing.Point(0, 0)
        Me.lblCuantos.Name = "lblCuantos"
        Me.lblCuantos.Size = New System.Drawing.Size(1036, 23)
        Me.lblCuantos.TabIndex = 45
        Me.lblCuantos.Text = "N Registros"
        Me.lblCuantos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'mnuEditar
        '
        Me.mnuEditar.AllowMerge = False
        Me.mnuEditar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCopiar, Me.ToolStripSeparator1, Me.mnuOcultar, Me.MostrarTodasLasColumnasToolStripMenuItem})
        Me.mnuEditar.Name = "ContextMenuStrip1"
        Me.mnuEditar.Size = New System.Drawing.Size(220, 76)
        '
        'mnuCopiar
        '
        Me.mnuCopiar.Image = Global.PIDA.My.Resources.Resources.copy_16
        Me.mnuCopiar.Name = "mnuCopiar"
        Me.mnuCopiar.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.mnuCopiar.Size = New System.Drawing.Size(219, 22)
        Me.mnuCopiar.Text = "&Copiar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(216, 6)
        '
        'mnuOcultar
        '
        Me.mnuOcultar.Name = "mnuOcultar"
        Me.mnuOcultar.Size = New System.Drawing.Size(219, 22)
        Me.mnuOcultar.Text = "&Ocultar columna"
        '
        'MostrarTodasLasColumnasToolStripMenuItem
        '
        Me.MostrarTodasLasColumnasToolStripMenuItem.Name = "MostrarTodasLasColumnasToolStripMenuItem"
        Me.MostrarTodasLasColumnasToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.MostrarTodasLasColumnasToolStripMenuItem.Text = "&Mostrar todas las columnas"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.ConsultaEmpleados32
        Me.PictureBox1.Location = New System.Drawing.Point(10, 10)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 34)
        Me.PictureBox1.TabIndex = 274
        Me.PictureBox1.TabStop = False
        '
        'DataGridViewCheckBoxXColumn1
        '
        Me.DataGridViewCheckBoxXColumn1.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.DataGridViewCheckBoxXColumn1.CheckBoxImageIndeterminate = Global.PIDA.My.Resources.Resources.Question16
        Me.DataGridViewCheckBoxXColumn1.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.CancelX
        Me.DataGridViewCheckBoxXColumn1.Checked = True
        Me.DataGridViewCheckBoxXColumn1.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.DataGridViewCheckBoxXColumn1.CheckValue = "N"
        Me.DataGridViewCheckBoxXColumn1.CheckValueChecked = "1"
        Me.DataGridViewCheckBoxXColumn1.CheckValueIndeterminate = "0"
        Me.DataGridViewCheckBoxXColumn1.CheckValueUnchecked = "2"
        Me.DataGridViewCheckBoxXColumn1.ConsiderEmptyStringAsNull = False
        Me.DataGridViewCheckBoxXColumn1.DataPropertyName = "aprobada"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewCheckBoxXColumn1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewCheckBoxXColumn1.HeaderText = "Aprobada"
        Me.DataGridViewCheckBoxXColumn1.Name = "DataGridViewCheckBoxXColumn1"
        Me.DataGridViewCheckBoxXColumn1.ThreeState = True
        Me.DataGridViewCheckBoxXColumn1.Width = 60
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.PictureBox1)
        Me.pnlTitulo.Controls.Add(Me.ReflectionLabel1)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(1036, 65)
        Me.pnlTitulo.TabIndex = 0
        '
        'dgMaestro
        '
        Me.dgMaestro.ContextMenuStrip = Me.mnuEditar
        Me.dgMaestro.DefaultVisualStyles.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.dgMaestro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgMaestro.ExpandButtonType = DevComponents.DotNetBar.SuperGrid.ExpandButtonType.Square
        Me.dgMaestro.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.dgMaestro.ForeColor = System.Drawing.Color.Black
        Me.dgMaestro.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.dgMaestro.Location = New System.Drawing.Point(0, 65)
        Me.dgMaestro.Name = "dgMaestro"
        '
        '
        '
        Me.dgMaestro.PrimaryGrid.ActiveRowIndicatorStyle = DevComponents.DotNetBar.SuperGrid.ActiveRowIndicatorStyle.Highlight
        Me.dgMaestro.PrimaryGrid.AllowEdit = False
        Me.dgMaestro.PrimaryGrid.AllowRowHeaderResize = True
        '
        '
        '
        Me.dgMaestro.PrimaryGrid.Caption.Visible = False
        Me.dgMaestro.PrimaryGrid.CellDragBehavior = DevComponents.DotNetBar.SuperGrid.CellDragBehavior.None
        '
        '
        '
        Me.dgMaestro.PrimaryGrid.ColumnHeader.RowHeaderText = "texto"
        Me.dgMaestro.PrimaryGrid.ColumnHeader.SortImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.TopRight
        Me.dgMaestro.PrimaryGrid.Columns.Add(Me.GridColumn1)
        Me.dgMaestro.PrimaryGrid.Columns.Add(Me.COMP)
        Me.dgMaestro.PrimaryGrid.Columns.Add(Me.GridColumn11)
        Me.dgMaestro.PrimaryGrid.Columns.Add(Me.GridColumn2)
        Me.dgMaestro.PrimaryGrid.Columns.Add(Me.GridColumn3)
        Me.dgMaestro.PrimaryGrid.Columns.Add(Me.GridColumn4)
        Me.dgMaestro.PrimaryGrid.Columns.Add(Me.GridColumn5)
        Me.dgMaestro.PrimaryGrid.Columns.Add(Me.GridColumn6)
        Me.dgMaestro.PrimaryGrid.Columns.Add(Me.GridColumn7)
        Me.dgMaestro.PrimaryGrid.Columns.Add(Me.GridColumn9)
        Me.dgMaestro.PrimaryGrid.Columns.Add(Me.GridColumn12)
        Me.dgMaestro.PrimaryGrid.Columns.Add(Me.GridColumn13)
        Me.dgMaestro.PrimaryGrid.DefaultRowHeight = 24
        Me.dgMaestro.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft
        Me.dgMaestro.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[False]
        Me.dgMaestro.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.dgMaestro.PrimaryGrid.DefaultVisualStyles.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.dgMaestro.PrimaryGrid.EnableColumnFiltering = True
        Me.dgMaestro.PrimaryGrid.EnableFiltering = True
        Me.dgMaestro.PrimaryGrid.EnsureVisibleAfterGrouping = True
        Me.dgMaestro.PrimaryGrid.EnsureVisibleAfterSort = True
        '
        '
        '
        Me.dgMaestro.PrimaryGrid.Filter.ShowPanelFilterExpr = True
        Me.dgMaestro.PrimaryGrid.Filter.Visible = True
        Me.dgMaestro.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.Wildcards
        Me.dgMaestro.PrimaryGrid.FrozenColumnCount = 1
        '
        '
        '
        Me.dgMaestro.PrimaryGrid.GroupByRow.GroupBoxLayout = DevComponents.DotNetBar.SuperGrid.GroupBoxLayout.Flat
        Me.dgMaestro.PrimaryGrid.GroupByRow.GroupBoxStyle = DevComponents.DotNetBar.SuperGrid.GroupBoxStyle.RoundedRectangular
        Me.dgMaestro.PrimaryGrid.GroupByRow.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.Always
        Me.dgMaestro.PrimaryGrid.GroupByRow.Text = ""
        Me.dgMaestro.PrimaryGrid.GroupByRow.Visible = True
        Me.dgMaestro.PrimaryGrid.GroupByRow.WatermarkText = "Arrastre la columna por la que desea agrupar"
        Me.dgMaestro.PrimaryGrid.GroupHeaderClickBehavior = DevComponents.DotNetBar.SuperGrid.GroupHeaderClickBehavior.ExpandCollapse
        Me.dgMaestro.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.Row
        Me.dgMaestro.PrimaryGrid.KeyboardEditMode = DevComponents.DotNetBar.SuperGrid.KeyboardEditMode.None
        Me.dgMaestro.PrimaryGrid.ReadOnly = True
        Me.dgMaestro.PrimaryGrid.RowHeaderWidth = 20
        Me.dgMaestro.PrimaryGrid.ShowTreeButton = False
        Me.dgMaestro.PrimaryGrid.ShowTreeLines = True
        Me.dgMaestro.PrimaryGrid.ShowWhitespaceRowLines = False
        Me.dgMaestro.PrimaryGrid.UseAlternateRowStyle = True
        Me.dgMaestro.Size = New System.Drawing.Size(1036, 387)
        Me.dgMaestro.TabIndex = 277
        '
        'COMP
        '
        Me.COMP.DataPropertyName = "cod_comp"
        Me.COMP.Name = "COMP"
        '
        'GridColumn11
        '
        Me.GridColumn11.DataPropertyName = "planta"
        Me.GridColumn11.Name = "PLANTA"
        '
        'GridColumn9
        '
        Me.GridColumn9.DataPropertyName = "curp"
        Me.GridColumn9.Name = "CURP"
        Me.GridColumn9.Width = 80
        '
        'GridColumn12
        '
        Me.GridColumn12.DataPropertyName = "cp_sat"
        Me.GridColumn12.Name = "CP_SAT"
        Me.GridColumn12.Width = 80
        '
        'GridColumn13
        '
        Me.GridColumn13.DataPropertyName = "cod_reg_sat"
        Me.GridColumn13.Name = "REG FISCAL"
        Me.GridColumn13.Width = 80
        '
        'bckCarga
        '
        Me.bckCarga.WorkerSupportsCancellation = True
        '
        'gpAvance
        '
        Me.gpAvance.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpAvance.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpAvance.Controls.Add(Me.lblAvance)
        Me.gpAvance.Controls.Add(Me.pbAvance)
        Me.gpAvance.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpAvance.Location = New System.Drawing.Point(394, 160)
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
        Me.gpAvance.TabIndex = 278
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
        'frmConsultaMaestro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(1036, 520)
        Me.Controls.Add(Me.gpAvance)
        Me.Controls.Add(Me.dgMaestro)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Controls.Add(Me.pnlControles)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmConsultaMaestro"
        Me.Text = "Personal"
        Me.pnlControles.ResumeLayout(False)
        Me.pnlCentrado.ResumeLayout(False)
        Me.mnuEditar.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTitulo.ResumeLayout(False)
        Me.gpAvance.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents pnlControles As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    'Friend WithEvents DataGridViewCheckBoxXColumn1 As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    'Friend WithEvents DataGridViewCheckBoxXColumn2 As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents DataGridViewCheckBoxXColumn1 As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents btnLimpiar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnExportar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents mnuEditar As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuCopiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Private WithEvents dgMaestro As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents mnuOcultar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dlgArchivo As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MostrarTodasLasColumnasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblCuantos As System.Windows.Forms.Label
    Friend WithEvents GridColumn1 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn2 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn3 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn4 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn5 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn6 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn7 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents pnlCentrado As System.Windows.Forms.Panel
    Friend WithEvents bckCarga As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblAvance As System.Windows.Forms.Label
    Friend WithEvents pbAvance As DevComponents.DotNetBar.Controls.CircularProgress
    Public WithEvents gpAvance As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GridColumn9 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents COMP As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn11 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn12 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn13 As DevComponents.DotNetBar.SuperGrid.GridColumn
End Class
