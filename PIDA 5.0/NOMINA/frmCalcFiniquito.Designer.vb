<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalcFiniquito
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabFiniquitos = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.sdgFiniquitos = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.GridColSel = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColStatus = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColAno = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColPeriodo = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColFolio = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColReloj = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColNombre = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColTipoEmp = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridTipoPeriodo = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColCodPuesto = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColAlta = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColAntig = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColFiniquito = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColNeto = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColPrima = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColGratif = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColDiasGrati = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColNoRest = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColDeposito = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColAnioAsentado = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColPeriodoAsentado = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColDespensa = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColPoliza = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColUsuario = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColCaptura = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColComple = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.pnlControlAsentado = New System.Windows.Forms.Panel()
        Me.cmbPeriodosAsentado = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.btnLimpiar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.swTipoperiodo = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.swdeposito = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.swPoliza = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.ReflectionLabel2 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.dgvFiniquitos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ColStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPeriodo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFolio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAlta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAntig = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFiniquito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPrimAntig = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColGratif = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColDiasGrati = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRest = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColBonDes = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColDeposito = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColAnioAsentado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPeriodoAsentado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPoliza = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCapIni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtHorario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtAntig = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblEstado = New DevComponents.DotNetBar.LabelX()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBaja = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtAlta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblBaja = New System.Windows.Forms.Label()
        Me.txtPuesto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.txtTipoEmp = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.ColConce = New DevComponents.AdvTree.ColumnHeader()
        Me.ColNombreConcepto = New DevComponents.AdvTree.ColumnHeader()
        Me.ColNaturaleza = New DevComponents.AdvTree.ColumnHeader()
        Me.ElementStyle2 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancelarFiniquito = New DevComponents.DotNetBar.ButtonX()
        Me.btnFirst = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrev = New DevComponents.DotNetBar.ButtonX()
        Me.btnNext = New DevComponents.DotNetBar.ButtonX()
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnLast = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        CType(Me.TabFiniquitos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabFiniquitos.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.pnlControlAsentado.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dgvFiniquitos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabFiniquitos
        '
        Me.TabFiniquitos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        '
        '
        '
        Me.TabFiniquitos.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.TabFiniquitos.ControlBox.MenuBox.Name = ""
        Me.TabFiniquitos.ControlBox.Name = ""
        Me.TabFiniquitos.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.TabFiniquitos.ControlBox.MenuBox, Me.TabFiniquitos.ControlBox.CloseBox})
        Me.TabFiniquitos.ControlBox.Visible = False
        Me.TabFiniquitos.Controls.Add(Me.SuperTabControlPanel2)
        Me.TabFiniquitos.Controls.Add(Me.SuperTabControlPanel1)
        Me.TabFiniquitos.Location = New System.Drawing.Point(1, 1)
        Me.TabFiniquitos.Name = "TabFiniquitos"
        Me.TabFiniquitos.ReorderTabsEnabled = True
        Me.TabFiniquitos.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabFiniquitos.SelectedTabIndex = 0
        Me.TabFiniquitos.Size = New System.Drawing.Size(1006, 483)
        Me.TabFiniquitos.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.TabFiniquitos.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabFiniquitos.TabIndex = 0
        Me.TabFiniquitos.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit
        Me.TabFiniquitos.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1, Me.SuperTabItem2})
        Me.TabFiniquitos.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.TabFiniquitos.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.Panel6)
        Me.SuperTabControlPanel2.Controls.Add(Me.Panel5)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(942, 483)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'Panel6
        '
        Me.Panel6.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel6.Controls.Add(Me.sdgFiniquitos)
        Me.Panel6.Controls.Add(Me.pnlControlAsentado)
        Me.Panel6.Location = New System.Drawing.Point(3, 57)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(936, 417)
        Me.Panel6.TabIndex = 1
        '
        'sdgFiniquitos
        '
        Me.sdgFiniquitos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sdgFiniquitos.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.sdgFiniquitos.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sdgFiniquitos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.sdgFiniquitos.Location = New System.Drawing.Point(0, 68)
        Me.sdgFiniquitos.Name = "sdgFiniquitos"
        '
        '
        '
        Me.sdgFiniquitos.PrimaryGrid.AllowRowDelete = True
        Me.sdgFiniquitos.PrimaryGrid.AllowRowInsert = True
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColSel)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColStatus)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColAno)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColPeriodo)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColFolio)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColReloj)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColNombre)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColTipoEmp)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridTipoPeriodo)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColCodPuesto)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColAlta)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColAntig)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColFiniquito)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColNeto)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColPrima)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColGratif)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColDiasGrati)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColNoRest)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColDeposito)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColAnioAsentado)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColPeriodoAsentado)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColDespensa)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColPoliza)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColUsuario)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColCaptura)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColComple)
        '
        '
        '
        Me.sdgFiniquitos.PrimaryGrid.Filter.ShowPanelFilterExpr = True
        Me.sdgFiniquitos.PrimaryGrid.Filter.Visible = True
        Me.sdgFiniquitos.PrimaryGrid.MultiSelect = False
        Me.sdgFiniquitos.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row
        Me.sdgFiniquitos.Size = New System.Drawing.Size(936, 349)
        Me.sdgFiniquitos.TabIndex = 7
        Me.sdgFiniquitos.Text = "Días"
        '
        'GridColSel
        '
        Me.GridColSel.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColSel.DataPropertyName = "seleccionado"
        Me.GridColSel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl)
        Me.GridColSel.HeaderText = ""
        Me.GridColSel.MarkRowDirtyOnCellValueChange = False
        Me.GridColSel.Name = "ColSel"
        Me.GridColSel.ReadOnly = True
        Me.GridColSel.Visible = False
        '
        'GridColStatus
        '
        Me.GridColStatus.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColStatus.DataPropertyName = "estado"
        Me.GridColStatus.DefaultNewRowCellValue = ""
        Me.GridColStatus.HeaderText = "Status"
        Me.GridColStatus.Name = "ColStatus"
        Me.GridColStatus.ReadOnly = True
        '
        'GridColAno
        '
        Me.GridColAno.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColAno.DataPropertyName = "ano"
        Me.GridColAno.HeaderText = "Año"
        Me.GridColAno.Name = "ColAno"
        Me.GridColAno.ReadOnly = True
        '
        'GridColPeriodo
        '
        Me.GridColPeriodo.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColPeriodo.DataPropertyName = "Periodo"
        Me.GridColPeriodo.HeaderText = "Periodo"
        Me.GridColPeriodo.Name = "ColPerido"
        Me.GridColPeriodo.ReadOnly = True
        '
        'GridColFolio
        '
        Me.GridColFolio.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColFolio.DataPropertyName = "Folio"
        Me.GridColFolio.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        Me.GridColFolio.HeaderText = "Folio"
        Me.GridColFolio.Name = "ColFolio"
        Me.GridColFolio.ReadOnly = True
        '
        'GridColReloj
        '
        Me.GridColReloj.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColReloj.DataPropertyName = "Reloj"
        Me.GridColReloj.HeaderText = "Reloj"
        Me.GridColReloj.Name = "ColReloj"
        Me.GridColReloj.ReadOnly = True
        '
        'GridColNombre
        '
        Me.GridColNombre.DataPropertyName = "Nombres"
        Me.GridColNombre.HeaderText = "Nombre"
        Me.GridColNombre.Name = "ColNombre"
        Me.GridColNombre.ReadOnly = True
        '
        'GridColTipoEmp
        '
        Me.GridColTipoEmp.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColTipoEmp.DataPropertyName = "cod_tipo"
        Me.GridColTipoEmp.HeaderText = "Tipo empleado"
        Me.GridColTipoEmp.Name = "ColEmp"
        Me.GridColTipoEmp.ReadOnly = True
        '
        'GridTipoPeriodo
        '
        Me.GridTipoPeriodo.DataPropertyName = "tipo_periodo"
        Me.GridTipoPeriodo.HeaderText = "Tipo periodo"
        Me.GridTipoPeriodo.Name = "ColTipoPeriodo"
        '
        'GridColCodPuesto
        '
        Me.GridColCodPuesto.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColCodPuesto.DataPropertyName = "cod_puesto"
        Me.GridColCodPuesto.HeaderText = "Puesto"
        Me.GridColCodPuesto.Name = "ColCodPuesto"
        Me.GridColCodPuesto.ReadOnly = True
        '
        'GridColAlta
        '
        Me.GridColAlta.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColAlta.DataPropertyName = "alta"
        Me.GridColAlta.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDateTimeInputEditControl)
        Me.GridColAlta.HeaderText = "Fecha de Alta"
        Me.GridColAlta.Name = "ColAlta"
        Me.GridColAlta.ReadOnly = True
        '
        'GridColAntig
        '
        Me.GridColAntig.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColAntig.DataPropertyName = "alta_antig"
        Me.GridColAntig.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDateTimeInputEditControl)
        Me.GridColAntig.HeaderText = "Fecha Alta de Antiguedad"
        Me.GridColAntig.Name = "ColAntig"
        Me.GridColAntig.ReadOnly = True
        '
        'GridColFiniquito
        '
        Me.GridColFiniquito.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColFiniquito.DataPropertyName = "baja_fin"
        Me.GridColFiniquito.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDateTimeInputEditControl)
        Me.GridColFiniquito.HeaderText = "Fecha Baja Finiquito"
        Me.GridColFiniquito.Name = "ColFiniquito"
        Me.GridColFiniquito.ReadOnly = True
        '
        'GridColNeto
        '
        Me.GridColNeto.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
        Me.GridColNeto.DataPropertyName = "Neto"
        Me.GridColNeto.DefaultNewRowCellValue = ""
        Me.GridColNeto.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl)
        Me.GridColNeto.HeaderText = "Neto"
        Me.GridColNeto.Name = "ColNeto"
        Me.GridColNeto.ReadOnly = True
        '
        'GridColPrima
        '
        Me.GridColPrima.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColPrima.DataPropertyName = "Prima_Antig"
        Me.GridColPrima.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl)
        Me.GridColPrima.HeaderText = "Prima de Antiguedad"
        Me.GridColPrima.Name = "ColPrima"
        Me.GridColPrima.ReadOnly = True
        '
        'GridColGratif
        '
        Me.GridColGratif.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColGratif.DataPropertyName = "Gratificacion"
        Me.GridColGratif.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl)
        Me.GridColGratif.HeaderText = "Indemnización"
        Me.GridColGratif.Name = "ColGratificacion"
        Me.GridColGratif.ReadOnly = True
        Me.GridColGratif.Visible = False
        '
        'GridColDiasGrati
        '
        Me.GridColDiasGrati.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColDiasGrati.DataPropertyName = "dias_grati"
        Me.GridColDiasGrati.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        Me.GridColDiasGrati.HeaderText = "Indemnización"
        Me.GridColDiasGrati.Name = "ColDiasGrati"
        '
        'GridColNoRest
        '
        Me.GridColNoRest.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColNoRest.DataPropertyName = "[20diasano] "
        Me.GridColNoRest.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl)
        Me.GridColNoRest.HeaderText = "20 Días por Año"
        Me.GridColNoRest.Name = "ColNoRest"
        Me.GridColNoRest.ReadOnly = True
        '
        'GridColDeposito
        '
        Me.GridColDeposito.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColDeposito.DataPropertyName = "Deposito"
        Me.GridColDeposito.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl)
        Me.GridColDeposito.HeaderText = "Asentado Depósito"
        Me.GridColDeposito.Name = "ColDeposito"
        Me.GridColDeposito.ReadOnly = True
        '
        'GridColAnioAsentado
        '
        Me.GridColAnioAsentado.DataPropertyName = "ano_asent_dep"
        Me.GridColAnioAsentado.HeaderText = "Año asentado"
        Me.GridColAnioAsentado.Name = "ColAnioAsentado"
        Me.GridColAnioAsentado.ReadOnly = True
        '
        'GridColPeriodoAsentado
        '
        Me.GridColPeriodoAsentado.DataPropertyName = "per_asent_dep"
        Me.GridColPeriodoAsentado.HeaderText = "Periodo asentado"
        Me.GridColPeriodoAsentado.Name = "ColPeriodoAsentado"
        Me.GridColPeriodoAsentado.ReadOnly = True
        '
        'GridColDespensa
        '
        Me.GridColDespensa.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColDespensa.DataPropertyName = "vales_despensa"
        Me.GridColDespensa.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl)
        Me.GridColDespensa.HeaderText = "Bono Despensa"
        Me.GridColDespensa.Name = "ColDespensa"
        Me.GridColDespensa.ReadOnly = True
        Me.GridColDespensa.Visible = False
        '
        'GridColPoliza
        '
        Me.GridColPoliza.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColPoliza.DataPropertyName = "Poliza"
        Me.GridColPoliza.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl)
        Me.GridColPoliza.HeaderText = "Asentado Póliza"
        Me.GridColPoliza.Name = "ColPoliza"
        Me.GridColPoliza.ReadOnly = True
        Me.GridColPoliza.Visible = False
        '
        'GridColUsuario
        '
        Me.GridColUsuario.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColUsuario.DataPropertyName = "Usuario"
        Me.GridColUsuario.HeaderText = "Usuario Captura"
        Me.GridColUsuario.Name = "ColUsuario"
        Me.GridColUsuario.ReadOnly = True
        '
        'GridColCaptura
        '
        Me.GridColCaptura.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColCaptura.DataPropertyName = "Captura"
        Me.GridColCaptura.HeaderText = "Fecha Captura"
        Me.GridColCaptura.Name = "ColCaptura"
        Me.GridColCaptura.ReadOnly = True
        '
        'GridColComple
        '
        Me.GridColComple.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColComple.DataPropertyName = "complemento"
        Me.GridColComple.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl)
        Me.GridColComple.HeaderText = "Complemento"
        Me.GridColComple.Name = "ColComplemento"
        Me.GridColComple.ReadOnly = True
        Me.GridColComple.Visible = False
        '
        'pnlControlAsentado
        '
        Me.pnlControlAsentado.Controls.Add(Me.cmbPeriodosAsentado)
        Me.pnlControlAsentado.Controls.Add(Me.btnLimpiar)
        Me.pnlControlAsentado.Controls.Add(Me.btnAceptar)
        Me.pnlControlAsentado.Controls.Add(Me.swTipoperiodo)
        Me.pnlControlAsentado.Controls.Add(Me.swdeposito)
        Me.pnlControlAsentado.Controls.Add(Me.LabelX2)
        Me.pnlControlAsentado.Controls.Add(Me.LabelX3)
        Me.pnlControlAsentado.Controls.Add(Me.swPoliza)
        Me.pnlControlAsentado.Controls.Add(Me.LabelX1)
        Me.pnlControlAsentado.Location = New System.Drawing.Point(3, 5)
        Me.pnlControlAsentado.Name = "pnlControlAsentado"
        Me.pnlControlAsentado.Size = New System.Drawing.Size(930, 64)
        Me.pnlControlAsentado.TabIndex = 277
        '
        'cmbPeriodosAsentado
        '
        Me.cmbPeriodosAsentado.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPeriodosAsentado.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPeriodosAsentado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPeriodosAsentado.ButtonDropDown.Visible = True
        Me.cmbPeriodosAsentado.DisplayMembers = "Único,Año,Periodo,Inicio,Fin"
        Me.cmbPeriodosAsentado.GroupingMembers = "tipoperiodo"
        Me.cmbPeriodosAsentado.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPeriodosAsentado.Location = New System.Drawing.Point(269, 35)
        Me.cmbPeriodosAsentado.Name = "cmbPeriodosAsentado"
        Me.cmbPeriodosAsentado.Size = New System.Drawing.Size(372, 23)
        Me.cmbPeriodosAsentado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPeriodosAsentado.TabIndex = 283
        Me.cmbPeriodosAsentado.ValueMember = "Único"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLimpiar.CausesValidation = False
        Me.btnLimpiar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLimpiar.Enabled = False
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.Image = Global.PIDA.My.Resources.Resources.DeleteRec
        Me.btnLimpiar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnLimpiar.Location = New System.Drawing.Point(648, 33)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(104, 25)
        Me.btnLimpiar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLimpiar.TabIndex = 280
        Me.btnLimpiar.Text = "Limpiar"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnAceptar.Location = New System.Drawing.Point(648, 6)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(104, 25)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 279
        Me.btnAceptar.Text = "Aceptar"
        '
        'swTipoperiodo
        '
        '
        '
        '
        Me.swTipoperiodo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swTipoperiodo.Location = New System.Drawing.Point(173, 35)
        Me.swTipoperiodo.Name = "swTipoperiodo"
        Me.swTipoperiodo.OffBackColor = System.Drawing.Color.LightCyan
        Me.swTipoperiodo.OffText = "Catorcenal"
        Me.swTipoperiodo.OnBackColor = System.Drawing.Color.LightCyan
        Me.swTipoperiodo.OnText = "Semanal"
        Me.swTipoperiodo.Size = New System.Drawing.Size(90, 22)
        Me.swTipoperiodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swTipoperiodo.TabIndex = 285
        '
        'swdeposito
        '
        '
        '
        '
        Me.swdeposito.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swdeposito.Location = New System.Drawing.Point(176, 5)
        Me.swdeposito.Name = "swdeposito"
        Me.swdeposito.OffBackColor = System.Drawing.Color.LightCoral
        Me.swdeposito.OffText = "NO"
        Me.swdeposito.OnBackColor = System.Drawing.Color.LightGreen
        Me.swdeposito.OnText = "SI"
        Me.swdeposito.Size = New System.Drawing.Size(66, 22)
        Me.swdeposito.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swdeposito.TabIndex = 282
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(248, 5)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(158, 23)
        Me.LabelX2.TabIndex = 281
        Me.LabelX2.Text = "Selección Múltiple para Póliza"
        Me.LabelX2.Visible = False
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(50, 35)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(116, 23)
        Me.LabelX3.TabIndex = 284
        Me.LabelX3.Text = "Tipo periodo a asentar"
        '
        'swPoliza
        '
        '
        '
        '
        Me.swPoliza.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swPoliza.Location = New System.Drawing.Point(410, 6)
        Me.swPoliza.Name = "swPoliza"
        Me.swPoliza.OffBackColor = System.Drawing.Color.LightCoral
        Me.swPoliza.OffText = "NO"
        Me.swPoliza.OnBackColor = System.Drawing.Color.LightGreen
        Me.swPoliza.OnText = "SI"
        Me.swPoliza.Size = New System.Drawing.Size(66, 22)
        Me.swPoliza.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swPoliza.TabIndex = 278
        Me.swPoliza.Visible = False
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(5, 4)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(174, 23)
        Me.LabelX1.TabIndex = 277
        Me.LabelX1.Text = "Selección Múltiple para Depósito"
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(936, 55)
        Me.Panel5.TabIndex = 0
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.ReflectionLabel2)
        Me.Panel7.Location = New System.Drawing.Point(4, 4)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(497, 44)
        Me.Panel7.TabIndex = 278
        '
        'ReflectionLabel2
        '
        '
        '
        '
        Me.ReflectionLabel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel2.Location = New System.Drawing.Point(4, 3)
        Me.ReflectionLabel2.Name = "ReflectionLabel2"
        Me.ReflectionLabel2.Size = New System.Drawing.Size(447, 37)
        Me.ReflectionLabel2.TabIndex = 249
        Me.ReflectionLabel2.Text = "<font color=""#1F497D""><b>HISTORIAL DE FINIQUITOS CAPTURADOS</b></font>"
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Historial"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.Panel4)
        Me.SuperTabControlPanel1.Controls.Add(Me.Panel2)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(944, 483)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.Controls.Add(Me.dgvFiniquitos)
        Me.Panel4.Location = New System.Drawing.Point(3, 137)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(938, 343)
        Me.Panel4.TabIndex = 252
        '
        'dgvFiniquitos
        '
        Me.dgvFiniquitos.AllowUserToAddRows = False
        Me.dgvFiniquitos.AllowUserToDeleteRows = False
        Me.dgvFiniquitos.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFiniquitos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvFiniquitos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFiniquitos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColStatus, Me.ColAno, Me.ColPeriodo, Me.ColFolio, Me.ColAlta, Me.ColAntig, Me.ColFiniquito, Me.ColNeto, Me.ColPrimAntig, Me.ColGratif, Me.ColDiasGrati, Me.ColRest, Me.ColBonDes, Me.ColDeposito, Me.ColAnioAsentado, Me.ColPeriodoAsentado, Me.ColPoliza, Me.ColUsuario, Me.ColCapIni})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFiniquitos.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvFiniquitos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFiniquitos.EnableHeadersVisualStyles = False
        Me.dgvFiniquitos.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvFiniquitos.Location = New System.Drawing.Point(0, 0)
        Me.dgvFiniquitos.MultiSelect = False
        Me.dgvFiniquitos.Name = "dgvFiniquitos"
        Me.dgvFiniquitos.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFiniquitos.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvFiniquitos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFiniquitos.Size = New System.Drawing.Size(938, 343)
        Me.dgvFiniquitos.TabIndex = 253
        '
        'ColStatus
        '
        Me.ColStatus.DataPropertyName = "Status"
        Me.ColStatus.HeaderText = "Status"
        Me.ColStatus.Name = "ColStatus"
        Me.ColStatus.ReadOnly = True
        '
        'ColAno
        '
        Me.ColAno.DataPropertyName = "ano"
        Me.ColAno.HeaderText = "Año"
        Me.ColAno.Name = "ColAno"
        Me.ColAno.ReadOnly = True
        '
        'ColPeriodo
        '
        Me.ColPeriodo.DataPropertyName = "Periodo"
        Me.ColPeriodo.HeaderText = "Periodo"
        Me.ColPeriodo.Name = "ColPeriodo"
        Me.ColPeriodo.ReadOnly = True
        '
        'ColFolio
        '
        Me.ColFolio.DataPropertyName = "Folio"
        Me.ColFolio.HeaderText = "Folio"
        Me.ColFolio.Name = "ColFolio"
        Me.ColFolio.ReadOnly = True
        '
        'ColAlta
        '
        Me.ColAlta.DataPropertyName = "alta"
        Me.ColAlta.HeaderText = "Fecha de Alta"
        Me.ColAlta.Name = "ColAlta"
        Me.ColAlta.ReadOnly = True
        '
        'ColAntig
        '
        Me.ColAntig.DataPropertyName = "alta_antig"
        Me.ColAntig.HeaderText = "Fecha Alta de Antiguedad"
        Me.ColAntig.Name = "ColAntig"
        Me.ColAntig.ReadOnly = True
        '
        'ColFiniquito
        '
        Me.ColFiniquito.DataPropertyName = "baja_fin"
        Me.ColFiniquito.HeaderText = "Fecha Baja Finiquito"
        Me.ColFiniquito.Name = "ColFiniquito"
        Me.ColFiniquito.ReadOnly = True
        '
        'ColNeto
        '
        Me.ColNeto.DataPropertyName = "Neto"
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.ColNeto.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColNeto.HeaderText = "Neto"
        Me.ColNeto.Name = "ColNeto"
        Me.ColNeto.ReadOnly = True
        '
        'ColPrimAntig
        '
        Me.ColPrimAntig.DataPropertyName = "Prima_Antig"
        Me.ColPrimAntig.HeaderText = "Prima de Antiguedad"
        Me.ColPrimAntig.Name = "ColPrimAntig"
        Me.ColPrimAntig.ReadOnly = True
        Me.ColPrimAntig.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColPrimAntig.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ColGratif
        '
        Me.ColGratif.DataPropertyName = "Gratificacion"
        Me.ColGratif.HeaderText = "Indemnización"
        Me.ColGratif.Name = "ColGratif"
        Me.ColGratif.ReadOnly = True
        Me.ColGratif.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColGratif.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ColDiasGrati
        '
        Me.ColDiasGrati.DataPropertyName = "dias_grati"
        Me.ColDiasGrati.HeaderText = "Indemnización"
        Me.ColDiasGrati.Name = "ColDiasGrati"
        Me.ColDiasGrati.ReadOnly = True
        Me.ColDiasGrati.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'ColRest
        '
        Me.ColRest.DataPropertyName = "20diasano"
        Me.ColRest.HeaderText = "20 Días por Año"
        Me.ColRest.Name = "ColRest"
        Me.ColRest.ReadOnly = True
        Me.ColRest.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColRest.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ColBonDes
        '
        Me.ColBonDes.DataPropertyName = "vales_despensa"
        Me.ColBonDes.HeaderText = "Bono Despensa"
        Me.ColBonDes.Name = "ColBonDes"
        Me.ColBonDes.ReadOnly = True
        Me.ColBonDes.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColBonDes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ColBonDes.Visible = False
        '
        'ColDeposito
        '
        Me.ColDeposito.DataPropertyName = "Ase_Dep"
        Me.ColDeposito.HeaderText = "Asentado Depósito"
        Me.ColDeposito.Name = "ColDeposito"
        Me.ColDeposito.ReadOnly = True
        '
        'ColAnioAsentado
        '
        Me.ColAnioAsentado.DataPropertyName = "ano_asent_dep"
        Me.ColAnioAsentado.HeaderText = "Año asentado"
        Me.ColAnioAsentado.Name = "ColAnioAsentado"
        Me.ColAnioAsentado.ReadOnly = True
        '
        'ColPeriodoAsentado
        '
        Me.ColPeriodoAsentado.DataPropertyName = "per_asent_dep"
        Me.ColPeriodoAsentado.HeaderText = "Periodo asentado"
        Me.ColPeriodoAsentado.Name = "ColPeriodoAsentado"
        Me.ColPeriodoAsentado.ReadOnly = True
        '
        'ColPoliza
        '
        Me.ColPoliza.DataPropertyName = "Ase_Pol"
        Me.ColPoliza.HeaderText = "Asentado Póliza"
        Me.ColPoliza.Name = "ColPoliza"
        Me.ColPoliza.ReadOnly = True
        Me.ColPoliza.Visible = False
        '
        'ColUsuario
        '
        Me.ColUsuario.DataPropertyName = "Usuario"
        Me.ColUsuario.HeaderText = "Usuario Captura"
        Me.ColUsuario.Name = "ColUsuario"
        Me.ColUsuario.ReadOnly = True
        '
        'ColCapIni
        '
        Me.ColCapIni.DataPropertyName = "Captura"
        Me.ColCapIni.HeaderText = "Fecha Captura"
        Me.ColCapIni.Name = "ColCapIni"
        Me.ColCapIni.ReadOnly = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.txtHorario)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.txtAntig)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.lblEstado)
        Me.Panel2.Controls.Add(Me.txtNombre)
        Me.Panel2.Controls.Add(Me.ReflectionLabel1)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtBaja)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.txtAlta)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.lblBaja)
        Me.Panel2.Controls.Add(Me.txtPuesto)
        Me.Panel2.Controls.Add(Me.Label67)
        Me.Panel2.Controls.Add(Me.txtTipoEmp)
        Me.Panel2.Controls.Add(Me.Label68)
        Me.Panel2.Location = New System.Drawing.Point(3, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(938, 137)
        Me.Panel2.TabIndex = 251
        '
        'txtHorario
        '
        Me.txtHorario.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtHorario.Border.Class = "TextBoxBorder"
        Me.txtHorario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtHorario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorario.ForeColor = System.Drawing.Color.Black
        Me.txtHorario.Location = New System.Drawing.Point(473, 102)
        Me.txtHorario.Name = "txtHorario"
        Me.txtHorario.ReadOnly = True
        Me.txtHorario.Size = New System.Drawing.Size(168, 21)
        Me.txtHorario.TabIndex = 255
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(388, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 15)
        Me.Label3.TabIndex = 256
        Me.Label3.Text = "Horario"
        '
        'Panel3
        '
        Me.Panel3.Location = New System.Drawing.Point(0, 143)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 100)
        Me.Panel3.TabIndex = 252
        '
        'txtAntig
        '
        Me.txtAntig.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtAntig.Border.Class = "TextBoxBorder"
        Me.txtAntig.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAntig.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAntig.ForeColor = System.Drawing.Color.Black
        Me.txtAntig.Location = New System.Drawing.Point(751, 101)
        Me.txtAntig.Name = "txtAntig"
        Me.txtAntig.ReadOnly = True
        Me.txtAntig.Size = New System.Drawing.Size(78, 21)
        Me.txtAntig.TabIndex = 250
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(660, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 15)
        Me.Label1.TabIndex = 249
        Me.Label1.Text = "Fecha de Antig"
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.Color.Green
        '
        '
        '
        Me.lblEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblEstado.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Window
        Me.lblEstado.Location = New System.Drawing.Point(3, 3)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(29, 115)
        Me.lblEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblEstado.TabIndex = 134
        Me.lblEstado.Text = "ACTIVO"
        Me.lblEstado.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblEstado.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.lblEstado.VerticalTextTopUp = False
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.Color.Black
        Me.txtNombre.Location = New System.Drawing.Point(36, 73)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(345, 21)
        Me.txtNombre.TabIndex = 126
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(236, 11)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(398, 40)
        Me.ReflectionLabel1.TabIndex = 248
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CÁLCULO DE FINIQUITO</b></font>"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(36, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 15)
        Me.Label5.TabIndex = 130
        Me.Label5.Text = "Nombre"
        '
        'txtBaja
        '
        Me.txtBaja.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtBaja.Border.Class = "TextBoxBorder"
        Me.txtBaja.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBaja.ForeColor = System.Drawing.Color.Black
        Me.txtBaja.Location = New System.Drawing.Point(751, 79)
        Me.txtBaja.Name = "txtBaja"
        Me.txtBaja.ReadOnly = True
        Me.txtBaja.Size = New System.Drawing.Size(78, 21)
        Me.txtBaja.TabIndex = 170
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LabelX4)
        Me.GroupBox1.Controls.Add(Me.txtReloj)
        Me.GroupBox1.Location = New System.Drawing.Point(663, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(171, 49)
        Me.GroupBox1.TabIndex = 133
        Me.GroupBox1.TabStop = False
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(11, 17)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(56, 23)
        Me.LabelX4.TabIndex = 36
        Me.LabelX4.Text = "Reloj"
        '
        'txtReloj
        '
        Me.txtReloj.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.ForeColor = System.Drawing.Color.Black
        Me.txtReloj.Location = New System.Drawing.Point(79, 15)
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.ReadOnly = True
        Me.txtReloj.Size = New System.Drawing.Size(84, 26)
        Me.txtReloj.TabIndex = 0
        Me.txtReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAlta
        '
        Me.txtAlta.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtAlta.Border.Class = "TextBoxBorder"
        Me.txtAlta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlta.ForeColor = System.Drawing.Color.Black
        Me.txtAlta.Location = New System.Drawing.Point(751, 57)
        Me.txtAlta.Name = "txtAlta"
        Me.txtAlta.ReadOnly = True
        Me.txtAlta.Size = New System.Drawing.Size(78, 21)
        Me.txtAlta.TabIndex = 169
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(660, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 135
        Me.Label2.Text = "Fecha de alta"
        '
        'lblBaja
        '
        Me.lblBaja.AutoSize = True
        Me.lblBaja.BackColor = System.Drawing.SystemColors.Control
        Me.lblBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBaja.Location = New System.Drawing.Point(660, 82)
        Me.lblBaja.Name = "lblBaja"
        Me.lblBaja.Size = New System.Drawing.Size(85, 15)
        Me.lblBaja.TabIndex = 136
        Me.lblBaja.Text = "Fecha de baja"
        '
        'txtPuesto
        '
        Me.txtPuesto.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtPuesto.Border.Class = "TextBoxBorder"
        Me.txtPuesto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPuesto.ForeColor = System.Drawing.Color.Black
        Me.txtPuesto.Location = New System.Drawing.Point(84, 97)
        Me.txtPuesto.Name = "txtPuesto"
        Me.txtPuesto.ReadOnly = True
        Me.txtPuesto.Size = New System.Drawing.Size(297, 21)
        Me.txtPuesto.TabIndex = 138
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.BackColor = System.Drawing.SystemColors.Control
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.Location = New System.Drawing.Point(36, 100)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(45, 15)
        Me.Label67.TabIndex = 139
        Me.Label67.Text = "Puesto"
        '
        'txtTipoEmp
        '
        Me.txtTipoEmp.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtTipoEmp.Border.Class = "TextBoxBorder"
        Me.txtTipoEmp.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTipoEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoEmp.ForeColor = System.Drawing.Color.Black
        Me.txtTipoEmp.Location = New System.Drawing.Point(473, 73)
        Me.txtTipoEmp.Name = "txtTipoEmp"
        Me.txtTipoEmp.ReadOnly = True
        Me.txtTipoEmp.Size = New System.Drawing.Size(168, 21)
        Me.txtTipoEmp.TabIndex = 140
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.BackColor = System.Drawing.SystemColors.Control
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.Location = New System.Drawing.Point(388, 76)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(79, 15)
        Me.Label68.TabIndex = 141
        Me.Label68.Text = "Tipo de emp."
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Calculo"
        '
        'ColConce
        '
        Me.ColConce.ColumnName = "ColConce"
        Me.ColConce.DataFieldName = "concepto"
        Me.ColConce.Name = "ColConce"
        Me.ColConce.Text = "Column"
        Me.ColConce.Width.Absolute = 150
        '
        'ColNombreConcepto
        '
        Me.ColNombreConcepto.ColumnName = "ColNombre"
        Me.ColNombreConcepto.DataFieldName = "nombre"
        Me.ColNombreConcepto.Name = "ColNombreConcepto"
        Me.ColNombreConcepto.Text = "Column"
        Me.ColNombreConcepto.Width.Absolute = 150
        '
        'ColNaturaleza
        '
        Me.ColNaturaleza.ColumnName = "ColNaturaleza"
        Me.ColNaturaleza.DataFieldName = "naturaleza"
        Me.ColNaturaleza.Name = "ColNaturaleza"
        Me.ColNaturaleza.Text = "Column"
        Me.ColNaturaleza.Width.Absolute = 150
        '
        'ElementStyle2
        '
        Me.ElementStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ElementStyle2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ElementStyle2.BackColorGradientAngle = 90
        Me.ElementStyle2.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderBottomWidth = 1
        Me.ElementStyle2.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle2.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderLeftWidth = 1
        Me.ElementStyle2.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderRightWidth = 1
        Me.ElementStyle2.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderTopWidth = 1
        Me.ElementStyle2.CornerDiameter = 4
        Me.ElementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle2.Description = "Blue"
        Me.ElementStyle2.Name = "ElementStyle2"
        Me.ElementStyle2.PaddingBottom = 1
        Me.ElementStyle2.PaddingLeft = 1
        Me.ElementStyle2.PaddingRight = 1
        Me.ElementStyle2.PaddingTop = 1
        Me.ElementStyle2.TextColor = System.Drawing.Color.Black
        '
        'ElementStyle1
        '
        Me.ElementStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ElementStyle1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ElementStyle1.BackColorGradientAngle = 90
        Me.ElementStyle1.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderBottomWidth = 1
        Me.ElementStyle1.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle1.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderLeftWidth = 1
        Me.ElementStyle1.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderRightWidth = 1
        Me.ElementStyle1.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderTopWidth = 1
        Me.ElementStyle1.CornerDiameter = 4
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Description = "Blue"
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.PaddingBottom = 1
        Me.ElementStyle1.PaddingLeft = 1
        Me.ElementStyle1.PaddingRight = 1
        Me.ElementStyle1.PaddingTop = 1
        Me.ElementStyle1.TextColor = System.Drawing.Color.Black
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCancelarFiniquito)
        Me.Panel1.Controls.Add(Me.btnFirst)
        Me.Panel1.Controls.Add(Me.btnPrev)
        Me.Panel1.Controls.Add(Me.btnNext)
        Me.Panel1.Controls.Add(Me.btnEditar)
        Me.Panel1.Controls.Add(Me.btnCerrar)
        Me.Panel1.Controls.Add(Me.btnBorrar)
        Me.Panel1.Controls.Add(Me.btnLast)
        Me.Panel1.Controls.Add(Me.btnNuevo)
        Me.Panel1.Controls.Add(Me.btnReporte)
        Me.Panel1.Controls.Add(Me.btnBuscar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 487)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1008, 35)
        Me.Panel1.TabIndex = 252
        '
        'btnCancelarFiniquito
        '
        Me.btnCancelarFiniquito.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelarFiniquito.CausesValidation = False
        Me.btnCancelarFiniquito.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelarFiniquito.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarFiniquito.Image = Global.PIDA.My.Resources.Resources.Cancel16
        Me.btnCancelarFiniquito.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCancelarFiniquito.Location = New System.Drawing.Point(765, 3)
        Me.btnCancelarFiniquito.Name = "btnCancelarFiniquito"
        Me.btnCancelarFiniquito.Size = New System.Drawing.Size(124, 25)
        Me.btnCancelarFiniquito.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancelarFiniquito.TabIndex = 174
        Me.btnCancelarFiniquito.Text = "Cancelar finiquito"
        '
        'btnFirst
        '
        Me.btnFirst.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnFirst.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnFirst.Image = Global.PIDA.My.Resources.Resources.First16
        Me.btnFirst.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnFirst.Location = New System.Drawing.Point(33, 3)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(78, 25)
        Me.btnFirst.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnFirst.TabIndex = 33
        Me.btnFirst.Text = "Inicio"
        Me.btnFirst.Visible = False
        '
        'btnPrev
        '
        Me.btnPrev.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrev.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrev.Image = Global.PIDA.My.Resources.Resources.Prev16
        Me.btnPrev.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnPrev.Location = New System.Drawing.Point(114, 3)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(78, 25)
        Me.btnPrev.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrev.TabIndex = 34
        Me.btnPrev.Text = "Anterior"
        Me.btnPrev.Visible = False
        '
        'btnNext
        '
        Me.btnNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNext.Image = Global.PIDA.My.Resources.Resources.Next16
        Me.btnNext.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnNext.Location = New System.Drawing.Point(195, 3)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(78, 25)
        Me.btnNext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNext.TabIndex = 35
        Me.btnNext.Text = "Siguiente"
        Me.btnNext.Visible = False
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = Global.PIDA.My.Resources.Resources.Edit
        Me.btnEditar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnEditar.Location = New System.Drawing.Point(600, 3)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(78, 25)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 40
        Me.btnEditar.Text = "Editar"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(895, 3)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 42
        Me.btnCerrar.Text = "Salir"
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = Global.PIDA.My.Resources.Resources.DeleteRec
        Me.btnBorrar.Location = New System.Drawing.Point(681, 3)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(78, 25)
        Me.btnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBorrar.TabIndex = 41
        Me.btnBorrar.Text = "Borrar"
        Me.btnBorrar.Visible = False
        '
        'btnLast
        '
        Me.btnLast.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLast.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLast.Image = Global.PIDA.My.Resources.Resources.Last16
        Me.btnLast.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnLast.Location = New System.Drawing.Point(276, 3)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(78, 25)
        Me.btnLast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLast.TabIndex = 36
        Me.btnLast.Text = "Final"
        Me.btnLast.Visible = False
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.NewRecord
        Me.btnNuevo.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnNuevo.Location = New System.Drawing.Point(519, 3)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 25)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 39
        Me.btnNuevo.Text = "Agregar"
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnReporte.Location = New System.Drawing.Point(438, 3)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 38
        Me.btnReporte.Text = "Reporte"
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBuscar.Location = New System.Drawing.Point(357, 3)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(78, 25)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 37
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Tooltip = "Buscar"
        '
        'frmCalcFiniquito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 522)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TabFiniquitos)
        Me.Name = "frmCalcFiniquito"
        Me.Text = "Calculo Finiquito"
        CType(Me.TabFiniquitos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabFiniquitos.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.pnlControlAsentado.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.dgvFiniquitos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabFiniquitos As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ColConce As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColNombreConcepto As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColNaturaleza As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ElementStyle2 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtAntig As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblEstado As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBaja As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtAlta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblBaja As System.Windows.Forms.Label
    Friend WithEvents txtPuesto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents txtTipoEmp As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents dgvFiniquitos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnFirst As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrev As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNext As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnLast As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents sdgFiniquitos As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents GridColSel As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColStatus As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColAno As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColPeriodo As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColFolio As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColReloj As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColNombre As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColTipoEmp As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColCodPuesto As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColAlta As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColAntig As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColFiniquito As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColNeto As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColPrima As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColGratif As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColNoRest As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColDespensa As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColDeposito As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColPoliza As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColUsuario As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColCaptura As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColComple As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents txtHorario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GridColDiasGrati As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents pnlControlAsentado As System.Windows.Forms.Panel
    Friend WithEvents swdeposito As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnLimpiar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents swPoliza As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents ReflectionLabel2 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents btnCancelarFiniquito As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmbPeriodosAsentado As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents GridTipoPeriodo As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents swTipoperiodo As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents ColStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPeriodo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFolio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAlta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAntig As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFiniquito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNeto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPrimAntig As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColGratif As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColDiasGrati As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRest As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColBonDes As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColDeposito As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColAnioAsentado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPeriodoAsentado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPoliza As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColUsuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCapIni As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GridColAnioAsentado As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColPeriodoAsentado As DevComponents.DotNetBar.SuperGrid.GridColumn
End Class
