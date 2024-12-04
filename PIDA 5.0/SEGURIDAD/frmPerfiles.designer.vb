<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPerfiles
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPerfiles))
        Me.tabBaja = New DevComponents.DotNetBar.SuperTabItem()
        Me.pnlReportesXX = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
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
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.tabBuscar = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.pnlExcepciones = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgExcepciones = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.GridColumn13 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn14 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn15 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn16 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.chkTodosVisible = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkTodosHabilitado = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.tabReportes = New DevComponents.DotNetBar.SuperTabItem()
        Me.pnlReportes = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgReportes = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.GridColumn10 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn11 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn12 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colTipoReporte = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkTodosReportes = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tabExcepciones = New DevComponents.DotNetBar.SuperTabItem()
        Me.pnlFormas = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgFormas = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.GridColumn7 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn8 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn9 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.chkTodosFormas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.tabFormas = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgCias = New System.Windows.Forms.DataGridView()
        Me.CiasPantalla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CiasControl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CiasAcceso = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.chkTodosCias = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tabCias = New DevComponents.DotNetBar.SuperTabItem()
        Me.pnlSeguridad = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.gpFiltro = New System.Windows.Forms.GroupBox()
        Me.lstFiltro = New DevComponents.DotNetBar.ListBoxAdv()
        Me.btnCancelarCriterio = New DevComponents.DotNetBar.ButtonX()
        Me.btnAgregarCriterio = New DevComponents.DotNetBar.ButtonX()
        Me.cbComparacion = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.ComboItem1 = New DevComponents.Editors.ComboItem()
        Me.ComboItem2 = New DevComponents.Editors.ComboItem()
        Me.cbCampos = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtFiltro = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.chkTodos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkFiltros = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.pnlCriterio = New System.Windows.Forms.Panel()
        Me.txtCriterio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnVerificar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCriterio = New DevComponents.DotNetBar.ButtonX()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnPeriodosInactivos = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.txtDias = New DevComponents.Editors.IntegerInput()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.gpValores = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dgClases = New System.Windows.Forms.DataGridView()
        Me.colCia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsulta = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colEdicion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colSueldos = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.sldSueldos = New DevComponents.Editors.IntegerInput()
        Me.sldEdicion = New DevComponents.Editors.IntegerInput()
        Me.sldConsulta = New DevComponents.Editors.IntegerInput()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.tabSeguridad = New DevComponents.DotNetBar.SuperTabItem()
        Me.pnlMaestro = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgMaestro = New System.Windows.Forms.DataGridView()
        Me.MaestroPantalla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.controlMaestro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaestroAcceso = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.chkTodosMaestro = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tabMaestro = New DevComponents.DotNetBar.SuperTabItem()
        Me.GridColumn3 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn5 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn6 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn1 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn2 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn4 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colModulo = New DevComponents.AdvTree.ColumnHeader()
        Me.gpAvance = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.lblAvance = New System.Windows.Forms.Label()
        Me.pbAvance = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.tabTabla = New DevComponents.DotNetBar.SuperTabItem()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bgwRefresca = New System.ComponentModel.BackgroundWorker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.swcAsisPerfecta = New DevComponents.DotNetBar.Controls.SwitchButton()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EmpNav.SuspendLayout()
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBuscar.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        Me.pnlExcepciones.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pnlReportes.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlFormas.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.dgCias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.pnlSeguridad.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.gpFiltro.SuspendLayout()
        Me.pnlCriterio.SuspendLayout()
        CType(Me.txtDias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpValores.SuspendLayout()
        CType(Me.dgClases, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sldSueldos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sldEdicion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sldConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMaestro.SuspendLayout()
        CType(Me.dgMaestro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.gpAvance.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabBaja
        '
        Me.tabBaja.GlobalItem = False
        Me.tabBaja.Name = "tabBaja"
        Me.tabBaja.Text = "Información de baja y reingreso"
        '
        'pnlReportesXX
        '
        Me.pnlReportesXX.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlReportesXX.Location = New System.Drawing.Point(0, 0)
        Me.pnlReportesXX.Name = "pnlReportesXX"
        Me.pnlReportesXX.Size = New System.Drawing.Size(834, 355)
        Me.pnlReportesXX.TabIndex = 0
        Me.pnlReportesXX.Text = "fasdfasdfasfasdf"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Profile32
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(27, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 83
        Me.PictureBox1.TabStop = False
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
        Me.EmpNav.TabIndex = 80
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
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(45, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(387, 40)
        Me.ReflectionLabel1.TabIndex = 82
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>PERFILES DE USUARIO</b></font>"
        '
        'tabBuscar
        '
        Me.tabBuscar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.tabBuscar.Controls.Add(Me.pnlSeguridad)
        Me.tabBuscar.Controls.Add(Me.SuperTabControlPanel2)
        Me.tabBuscar.Controls.Add(Me.pnlReportes)
        Me.tabBuscar.Controls.Add(Me.pnlFormas)
        Me.tabBuscar.Controls.Add(Me.SuperTabControlPanel1)
        Me.tabBuscar.Controls.Add(Me.pnlMaestro)
        Me.tabBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.Location = New System.Drawing.Point(12, 83)
        Me.tabBuscar.Name = "tabBuscar"
        Me.tabBuscar.ReorderTabsEnabled = True
        Me.tabBuscar.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabBuscar.SelectedTabIndex = 0
        Me.tabBuscar.Size = New System.Drawing.Size(825, 450)
        Me.tabBuscar.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.tabBuscar.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.TabIndex = 81
        Me.tabBuscar.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabSeguridad, Me.tabMaestro, Me.tabCias, Me.tabFormas, Me.tabReportes, Me.tabExcepciones})
        Me.tabBuscar.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.pnlExcepciones)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(716, 450)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.tabExcepciones
        '
        'pnlExcepciones
        '
        Me.pnlExcepciones.Controls.Add(Me.dgExcepciones)
        Me.pnlExcepciones.Controls.Add(Me.Panel5)
        Me.pnlExcepciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlExcepciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlExcepciones.Name = "pnlExcepciones"
        Me.pnlExcepciones.Size = New System.Drawing.Size(716, 450)
        Me.pnlExcepciones.TabIndex = 3
        Me.pnlExcepciones.TabItem = Me.tabReportes
        '
        'dgExcepciones
        '
        Me.dgExcepciones.DefaultVisualStyles.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.dgExcepciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgExcepciones.ExpandButtonType = DevComponents.DotNetBar.SuperGrid.ExpandButtonType.Square
        Me.dgExcepciones.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.dgExcepciones.ForeColor = System.Drawing.Color.Black
        Me.dgExcepciones.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.dgExcepciones.Location = New System.Drawing.Point(0, 25)
        Me.dgExcepciones.Name = "dgExcepciones"
        '
        '
        '
        Me.dgExcepciones.PrimaryGrid.AllowRowDelete = True
        Me.dgExcepciones.PrimaryGrid.AllowRowInsert = True
        '
        '
        '
        Me.dgExcepciones.PrimaryGrid.Caption.Visible = False
        Me.dgExcepciones.PrimaryGrid.Columns.Add(Me.GridColumn13)
        Me.dgExcepciones.PrimaryGrid.Columns.Add(Me.GridColumn14)
        Me.dgExcepciones.PrimaryGrid.Columns.Add(Me.GridColumn15)
        Me.dgExcepciones.PrimaryGrid.Columns.Add(Me.GridColumn16)
        Me.dgExcepciones.PrimaryGrid.DefaultRowHeight = 30
        Me.dgExcepciones.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft
        Me.dgExcepciones.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[False]
        Me.dgExcepciones.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.dgExcepciones.PrimaryGrid.DefaultVisualStyles.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.dgExcepciones.PrimaryGrid.EnableColumnFiltering = True
        Me.dgExcepciones.PrimaryGrid.EnableFiltering = True
        Me.dgExcepciones.PrimaryGrid.EnableRowFiltering = True
        Me.dgExcepciones.PrimaryGrid.EnsureVisibleAfterGrouping = True
        Me.dgExcepciones.PrimaryGrid.EnsureVisibleAfterSort = True
        '
        '
        '
        Me.dgExcepciones.PrimaryGrid.Filter.ShowPanelFilterExpr = True
        Me.dgExcepciones.PrimaryGrid.Filter.Visible = True
        Me.dgExcepciones.PrimaryGrid.FilterLevel = CType((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root Or DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded), DevComponents.DotNetBar.SuperGrid.FilterLevel)
        Me.dgExcepciones.PrimaryGrid.FrozenColumnCount = 1
        '
        '
        '
        Me.dgExcepciones.PrimaryGrid.GroupByRow.Text = ""
        Me.dgExcepciones.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.Row
        Me.dgExcepciones.PrimaryGrid.InsertRowImage = Global.PIDA.My.Resources.Resources.Add
        Me.dgExcepciones.PrimaryGrid.KeyboardEditMode = DevComponents.DotNetBar.SuperGrid.KeyboardEditMode.EditOnEntry
        Me.dgExcepciones.PrimaryGrid.RowEditMode = DevComponents.DotNetBar.SuperGrid.RowEditMode.PrimaryCell
        Me.dgExcepciones.PrimaryGrid.RowHeaderWidth = 24
        Me.dgExcepciones.PrimaryGrid.ShowInsertRow = True
        Me.dgExcepciones.PrimaryGrid.ShowRowGridIndex = True
        Me.dgExcepciones.PrimaryGrid.UseAlternateRowStyle = True
        Me.dgExcepciones.Size = New System.Drawing.Size(716, 425)
        Me.dgExcepciones.TabIndex = 288
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
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel5.Controls.Add(Me.chkTodosVisible)
        Me.Panel5.Controls.Add(Me.chkTodosHabilitado)
        Me.Panel5.Controls.Add(Me.Label11)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(716, 25)
        Me.Panel5.TabIndex = 287
        '
        'chkTodosVisible
        '
        '
        '
        '
        Me.chkTodosVisible.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkTodosVisible.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.chkTodosVisible.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.Unckecked16
        Me.chkTodosVisible.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Right
        Me.chkTodosVisible.Dock = System.Windows.Forms.DockStyle.Right
        Me.chkTodosVisible.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTodosVisible.Location = New System.Drawing.Point(515, 0)
        Me.chkTodosVisible.Name = "chkTodosVisible"
        Me.chkTodosVisible.Size = New System.Drawing.Size(98, 25)
        Me.chkTodosVisible.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkTodosVisible.TabIndex = 286
        Me.chkTodosVisible.Text = "Todos"
        '
        'chkTodosHabilitado
        '
        '
        '
        '
        Me.chkTodosHabilitado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkTodosHabilitado.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.chkTodosHabilitado.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.Unckecked16
        Me.chkTodosHabilitado.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Right
        Me.chkTodosHabilitado.Dock = System.Windows.Forms.DockStyle.Right
        Me.chkTodosHabilitado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTodosHabilitado.Location = New System.Drawing.Point(613, 0)
        Me.chkTodosHabilitado.Name = "chkTodosHabilitado"
        Me.chkTodosHabilitado.Size = New System.Drawing.Size(103, 25)
        Me.chkTodosHabilitado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkTodosHabilitado.TabIndex = 285
        Me.chkTodosHabilitado.Text = "Todos "
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
        'tabReportes
        '
        Me.tabReportes.AttachedControl = Me.pnlReportes
        Me.tabReportes.GlobalItem = False
        Me.tabReportes.Name = "tabReportes"
        Me.tabReportes.Text = "Reportes"
        '
        'pnlReportes
        '
        Me.pnlReportes.Controls.Add(Me.dgReportes)
        Me.pnlReportes.Controls.Add(Me.Panel2)
        Me.pnlReportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlReportes.Location = New System.Drawing.Point(0, 0)
        Me.pnlReportes.Name = "pnlReportes"
        Me.pnlReportes.Size = New System.Drawing.Size(716, 450)
        Me.pnlReportes.TabIndex = 2
        Me.pnlReportes.TabItem = Me.tabReportes
        '
        'dgReportes
        '
        Me.dgReportes.DefaultVisualStyles.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.dgReportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgReportes.ExpandButtonType = DevComponents.DotNetBar.SuperGrid.ExpandButtonType.Square
        Me.dgReportes.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.dgReportes.ForeColor = System.Drawing.Color.Black
        Me.dgReportes.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.dgReportes.Location = New System.Drawing.Point(0, 25)
        Me.dgReportes.Name = "dgReportes"
        '
        '
        '
        '
        '
        '
        Me.dgReportes.PrimaryGrid.Caption.Visible = False
        Me.dgReportes.PrimaryGrid.Columns.Add(Me.GridColumn10)
        Me.dgReportes.PrimaryGrid.Columns.Add(Me.GridColumn11)
        Me.dgReportes.PrimaryGrid.Columns.Add(Me.GridColumn12)
        Me.dgReportes.PrimaryGrid.Columns.Add(Me.colTipoReporte)
        Me.dgReportes.PrimaryGrid.DefaultRowHeight = 30
        Me.dgReportes.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft
        Me.dgReportes.PrimaryGrid.DefaultVisualStyles.CellStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[False]
        Me.dgReportes.PrimaryGrid.DefaultVisualStyles.FilterColumnHeaderStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.dgReportes.PrimaryGrid.DefaultVisualStyles.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.dgReportes.PrimaryGrid.EnableColumnFiltering = True
        Me.dgReportes.PrimaryGrid.EnableFiltering = True
        Me.dgReportes.PrimaryGrid.EnableRowFiltering = True
        Me.dgReportes.PrimaryGrid.EnsureVisibleAfterGrouping = True
        Me.dgReportes.PrimaryGrid.EnsureVisibleAfterSort = True
        '
        '
        '
        Me.dgReportes.PrimaryGrid.Filter.ShowPanelFilterExpr = True
        Me.dgReportes.PrimaryGrid.Filter.Visible = True
        Me.dgReportes.PrimaryGrid.FilterLevel = CType((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root Or DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded), DevComponents.DotNetBar.SuperGrid.FilterLevel)
        Me.dgReportes.PrimaryGrid.FrozenColumnCount = 1
        '
        '
        '
        Me.dgReportes.PrimaryGrid.GroupByRow.Text = ""
        Me.dgReportes.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.Row
        Me.dgReportes.PrimaryGrid.KeyboardEditMode = DevComponents.DotNetBar.SuperGrid.KeyboardEditMode.None
        Me.dgReportes.PrimaryGrid.RowHeaderWidth = 16
        Me.dgReportes.PrimaryGrid.ShowRowGridIndex = True
        Me.dgReportes.PrimaryGrid.ShowRowHeaders = False
        Me.dgReportes.PrimaryGrid.UseAlternateRowStyle = True
        Me.dgReportes.Size = New System.Drawing.Size(716, 425)
        Me.dgReportes.TabIndex = 288
        '
        'GridColumn10
        '
        Me.GridColumn10.DataPropertyName = "tag"
        Me.GridColumn10.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn10.FilterAutoScan = True
        Me.GridColumn10.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.Wildcards
        Me.GridColumn10.Name = "Módulo"
        Me.GridColumn10.Width = 150
        '
        'GridColumn11
        '
        Me.GridColumn11.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill
        Me.GridColumn11.DataPropertyName = "reporte"
        Me.GridColumn11.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn11.FilterAutoScan = True
        Me.GridColumn11.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.Wildcards
        Me.GridColumn11.MinimumWidth = 100
        Me.GridColumn11.Name = "Reporte"
        '
        'GridColumn12
        '
        Me.GridColumn12.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColumn12.DataPropertyName = "acceso"
        Me.GridColumn12.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl)
        Me.GridColumn12.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn12.FilterAutoScan = True
        Me.GridColumn12.Name = "Acceso"
        Me.GridColumn12.Width = 50
        '
        'colTipoReporte
        '
        Me.colTipoReporte.DataPropertyName = "tipo"
        Me.colTipoReporte.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colTipoReporte.FilterAutoScan = True
        Me.colTipoReporte.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.None
        Me.colTipoReporte.Name = "Tipo"
        Me.colTipoReporte.Width = 150
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel2.Controls.Add(Me.chkTodosReportes)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(716, 25)
        Me.Panel2.TabIndex = 287
        '
        'chkTodosReportes
        '
        '
        '
        '
        Me.chkTodosReportes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkTodosReportes.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.chkTodosReportes.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.Unckecked16
        Me.chkTodosReportes.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Right
        Me.chkTodosReportes.Dock = System.Windows.Forms.DockStyle.Right
        Me.chkTodosReportes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTodosReportes.Location = New System.Drawing.Point(574, 0)
        Me.chkTodosReportes.Name = "chkTodosReportes"
        Me.chkTodosReportes.Size = New System.Drawing.Size(142, 25)
        Me.chkTodosReportes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkTodosReportes.TabIndex = 285
        Me.chkTodosReportes.Text = "Marcar todos"
        Me.chkTodosReportes.TextColor = System.Drawing.SystemColors.ActiveCaptionText
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(716, 25)
        Me.Label5.TabIndex = 284
        Me.Label5.Text = "Seleccione los reportes a los que tendrá acceso este perfil"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabExcepciones
        '
        Me.tabExcepciones.AttachedControl = Me.SuperTabControlPanel2
        Me.tabExcepciones.GlobalItem = False
        Me.tabExcepciones.Name = "tabExcepciones"
        Me.tabExcepciones.Text = "Excepciones"
        '
        'pnlFormas
        '
        Me.pnlFormas.Controls.Add(Me.dgFormas)
        Me.pnlFormas.Controls.Add(Me.Panel1)
        Me.pnlFormas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFormas.Location = New System.Drawing.Point(0, 0)
        Me.pnlFormas.Name = "pnlFormas"
        Me.pnlFormas.Size = New System.Drawing.Size(716, 450)
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
        Me.dgFormas.Size = New System.Drawing.Size(716, 425)
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
        Me.Panel1.Size = New System.Drawing.Size(716, 25)
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
        Me.chkTodosFormas.Location = New System.Drawing.Point(574, 0)
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
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.dgCias)
        Me.SuperTabControlPanel1.Controls.Add(Me.Panel4)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(716, 450)
        Me.SuperTabControlPanel1.TabIndex = 0
        Me.SuperTabControlPanel1.TabItem = Me.tabCias
        '
        'dgCias
        '
        Me.dgCias.AllowUserToAddRows = False
        Me.dgCias.AllowUserToDeleteRows = False
        Me.dgCias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCias.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CiasPantalla, Me.CiasControl, Me.CiasAcceso})
        Me.dgCias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgCias.Location = New System.Drawing.Point(0, 25)
        Me.dgCias.Name = "dgCias"
        Me.dgCias.RowHeadersVisible = False
        Me.dgCias.Size = New System.Drawing.Size(716, 425)
        Me.dgCias.TabIndex = 289
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
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel4.Controls.Add(Me.chkTodosCias)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(716, 25)
        Me.Panel4.TabIndex = 288
        '
        'chkTodosCias
        '
        '
        '
        '
        Me.chkTodosCias.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkTodosCias.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.chkTodosCias.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.Unckecked16
        Me.chkTodosCias.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Right
        Me.chkTodosCias.Dock = System.Windows.Forms.DockStyle.Right
        Me.chkTodosCias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTodosCias.Location = New System.Drawing.Point(574, 0)
        Me.chkTodosCias.Name = "chkTodosCias"
        Me.chkTodosCias.Size = New System.Drawing.Size(142, 25)
        Me.chkTodosCias.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkTodosCias.TabIndex = 285
        Me.chkTodosCias.Text = "Marcar todos"
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
        'tabCias
        '
        Me.tabCias.AttachedControl = Me.SuperTabControlPanel1
        Me.tabCias.GlobalItem = False
        Me.tabCias.Name = "tabCias"
        Me.tabCias.Text = "Parámetros"
        '
        'pnlSeguridad
        '
        Me.pnlSeguridad.Controls.Add(Me.GroupPanel1)
        Me.pnlSeguridad.Controls.Add(Me.gpValores)
        Me.pnlSeguridad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSeguridad.Location = New System.Drawing.Point(0, 0)
        Me.pnlSeguridad.Name = "pnlSeguridad"
        Me.pnlSeguridad.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlSeguridad.Size = New System.Drawing.Size(716, 450)
        Me.pnlSeguridad.TabIndex = 0
        Me.pnlSeguridad.TabItem = Me.tabSeguridad
        '
        'GroupPanel1
        '
        Me.GroupPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupPanel1.BackColor = System.Drawing.SystemColors.Window
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel1.Controls.Add(Me.Label13)
        Me.GroupPanel1.Controls.Add(Me.swcAsisPerfecta)
        Me.GroupPanel1.Controls.Add(Me.gpFiltro)
        Me.GroupPanel1.Controls.Add(Me.chkTodos)
        Me.GroupPanel1.Controls.Add(Me.chkFiltros)
        Me.GroupPanel1.Controls.Add(Me.pnlCriterio)
        Me.GroupPanel1.Controls.Add(Me.Label35)
        Me.GroupPanel1.Controls.Add(Me.Label10)
        Me.GroupPanel1.Controls.Add(Me.btnPeriodosInactivos)
        Me.GroupPanel1.Controls.Add(Me.txtDias)
        Me.GroupPanel1.Controls.Add(Me.Label9)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel1.Location = New System.Drawing.Point(10, 263)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(696, 177)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor = System.Drawing.SystemColors.Window
        Me.GroupPanel1.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 1
        Me.GroupPanel1.Text = "Tiempo y asistencia"
        '
        'gpFiltro
        '
        Me.gpFiltro.BackColor = System.Drawing.SystemColors.Window
        Me.gpFiltro.Controls.Add(Me.lstFiltro)
        Me.gpFiltro.Controls.Add(Me.btnCancelarCriterio)
        Me.gpFiltro.Controls.Add(Me.btnAgregarCriterio)
        Me.gpFiltro.Controls.Add(Me.cbComparacion)
        Me.gpFiltro.Controls.Add(Me.cbCampos)
        Me.gpFiltro.Controls.Add(Me.Label29)
        Me.gpFiltro.Controls.Add(Me.txtFiltro)
        Me.gpFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFiltro.Location = New System.Drawing.Point(18, 95)
        Me.gpFiltro.Name = "gpFiltro"
        Me.gpFiltro.Size = New System.Drawing.Size(406, 117)
        Me.gpFiltro.TabIndex = 144
        Me.gpFiltro.TabStop = False
        Me.gpFiltro.Text = "Filtro"
        Me.gpFiltro.Visible = False
        '
        'lstFiltro
        '
        Me.lstFiltro.AutoScroll = True
        '
        '
        '
        Me.lstFiltro.BackgroundStyle.Class = "ListBoxAdv"
        Me.lstFiltro.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lstFiltro.CheckBoxesVisible = True
        Me.lstFiltro.CheckStateMember = Nothing
        Me.lstFiltro.ContainerControlProcessDialogKey = True
        Me.lstFiltro.DragDropSupport = True
        Me.lstFiltro.ItemHeight = 15
        Me.lstFiltro.Items.Add("a")
        Me.lstFiltro.Items.Add("b")
        Me.lstFiltro.Items.Add("c")
        Me.lstFiltro.Items.Add("d")
        Me.lstFiltro.Items.Add("e")
        Me.lstFiltro.ItemSpacing = 0
        Me.lstFiltro.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.lstFiltro.Location = New System.Drawing.Point(17, 64)
        Me.lstFiltro.Name = "lstFiltro"
        Me.lstFiltro.Size = New System.Drawing.Size(314, 45)
        Me.lstFiltro.TabIndex = 5
        Me.lstFiltro.ValueMember = "campo"
        '
        'btnCancelarCriterio
        '
        Me.btnCancelarCriterio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelarCriterio.CausesValidation = False
        Me.btnCancelarCriterio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelarCriterio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarCriterio.Image = Global.PIDA.My.Resources.Resources.Cancel2_16
        Me.btnCancelarCriterio.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCancelarCriterio.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnCancelarCriterio.Location = New System.Drawing.Point(368, 66)
        Me.btnCancelarCriterio.Name = "btnCancelarCriterio"
        Me.btnCancelarCriterio.Size = New System.Drawing.Size(30, 36)
        Me.btnCancelarCriterio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancelarCriterio.TabIndex = 0
        Me.btnCancelarCriterio.Tooltip = "Cancelar"
        '
        'btnAgregarCriterio
        '
        Me.btnAgregarCriterio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAgregarCriterio.CausesValidation = False
        Me.btnAgregarCriterio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAgregarCriterio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarCriterio.Image = Global.PIDA.My.Resources.Resources.LapizNvo16
        Me.btnAgregarCriterio.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnAgregarCriterio.Location = New System.Drawing.Point(334, 66)
        Me.btnAgregarCriterio.Name = "btnAgregarCriterio"
        Me.btnAgregarCriterio.Size = New System.Drawing.Size(30, 36)
        Me.btnAgregarCriterio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAgregarCriterio.TabIndex = 6
        Me.btnAgregarCriterio.Tooltip = "Agregar criterio"
        '
        'cbComparacion
        '
        Me.cbComparacion.DisplayMember = "Text"
        Me.cbComparacion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbComparacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbComparacion.FormattingEnabled = True
        Me.cbComparacion.ItemHeight = 15
        Me.cbComparacion.Items.AddRange(New Object() {Me.ComboItem1, Me.ComboItem2})
        Me.cbComparacion.Location = New System.Drawing.Point(334, 19)
        Me.cbComparacion.Name = "cbComparacion"
        Me.cbComparacion.Size = New System.Drawing.Size(64, 21)
        Me.cbComparacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbComparacion.TabIndex = 2
        '
        'ComboItem1
        '
        Me.ComboItem1.Text = "="
        '
        'ComboItem2
        '
        Me.ComboItem2.Text = "<>"
        '
        'cbCampos
        '
        Me.cbCampos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cbCampos.BackgroundStyle.Class = "TextBoxBorder"
        Me.cbCampos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbCampos.ButtonDropDown.Visible = True
        Me.cbCampos.DisplayMembers = "cod_campo"
        Me.cbCampos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cbCampos.Location = New System.Drawing.Point(67, 19)
        Me.cbCampos.Name = "cbCampos"
        Me.cbCampos.Size = New System.Drawing.Size(264, 21)
        Me.cbCampos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbCampos.TabIndex = 1
        Me.cbCampos.ValueMember = "NOMBRE"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(14, 19)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(47, 15)
        Me.Label29.TabIndex = 0
        Me.Label29.Text = "Campo"
        '
        'txtFiltro
        '
        Me.txtFiltro.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtFiltro.Border.Class = "TextBoxBorder"
        Me.txtFiltro.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFiltro.ForeColor = System.Drawing.Color.Black
        Me.txtFiltro.Location = New System.Drawing.Point(17, 41)
        Me.txtFiltro.MaxLength = 100
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(381, 21)
        Me.txtFiltro.TabIndex = 4
        '
        'chkTodos
        '
        Me.chkTodos.AutoSize = True
        Me.chkTodos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkTodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkTodos.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkTodos.Checked = True
        Me.chkTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodos.CheckValue = "Y"
        Me.chkTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTodos.Location = New System.Drawing.Point(273, 43)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(178, 16)
        Me.chkTodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkTodos.TabIndex = 141
        Me.chkTodos.Text = "Cualquier tipo de ausentismo"
        Me.chkTodos.TextColor = System.Drawing.SystemColors.ActiveCaptionText
        '
        'chkFiltros
        '
        Me.chkFiltros.AutoSize = True
        Me.chkFiltros.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkFiltros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkFiltros.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkFiltros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFiltros.Location = New System.Drawing.Point(273, 65)
        Me.chkFiltros.Name = "chkFiltros"
        Me.chkFiltros.Size = New System.Drawing.Size(189, 16)
        Me.chkFiltros.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkFiltros.TabIndex = 142
        Me.chkFiltros.Text = "Solo los que cumplan el criterio"
        Me.chkFiltros.TextColor = System.Drawing.SystemColors.ActiveCaptionText
        '
        'pnlCriterio
        '
        Me.pnlCriterio.BackColor = System.Drawing.SystemColors.Window
        Me.pnlCriterio.Controls.Add(Me.txtCriterio)
        Me.pnlCriterio.Controls.Add(Me.btnVerificar)
        Me.pnlCriterio.Controls.Add(Me.btnCriterio)
        Me.pnlCriterio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlCriterio.Location = New System.Drawing.Point(288, 92)
        Me.pnlCriterio.Name = "pnlCriterio"
        Me.pnlCriterio.Size = New System.Drawing.Size(383, 54)
        Me.pnlCriterio.TabIndex = 143
        Me.pnlCriterio.Visible = False
        '
        'txtCriterio
        '
        Me.txtCriterio.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtCriterio.Border.Class = "TextBoxBorder"
        Me.txtCriterio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCriterio.ForeColor = System.Drawing.Color.Black
        Me.txtCriterio.Location = New System.Drawing.Point(1, 3)
        Me.txtCriterio.MaxLength = 250
        Me.txtCriterio.Multiline = True
        Me.txtCriterio.Name = "txtCriterio"
        Me.txtCriterio.Size = New System.Drawing.Size(343, 47)
        Me.txtCriterio.TabIndex = 0
        '
        'btnVerificar
        '
        Me.btnVerificar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnVerificar.CausesValidation = False
        Me.btnVerificar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnVerificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerificar.Image = Global.PIDA.My.Resources.Resources.Validar22
        Me.btnVerificar.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnVerificar.Location = New System.Drawing.Point(350, 27)
        Me.btnVerificar.Name = "btnVerificar"
        Me.btnVerificar.Size = New System.Drawing.Size(26, 23)
        Me.btnVerificar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnVerificar.TabIndex = 2
        Me.btnVerificar.Tooltip = "Verificar criterio"
        '
        'btnCriterio
        '
        Me.btnCriterio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCriterio.CausesValidation = False
        Me.btnCriterio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCriterio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCriterio.Image = Global.PIDA.My.Resources.Resources.Lapiz16
        Me.btnCriterio.Location = New System.Drawing.Point(350, 3)
        Me.btnCriterio.Name = "btnCriterio"
        Me.btnCriterio.Size = New System.Drawing.Size(26, 23)
        Me.btnCriterio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCriterio.TabIndex = 1
        Me.btnCriterio.Tooltip = "Agregar nuevo criterio"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.SystemColors.Window
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(15, 43)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(166, 15)
        Me.Label35.TabIndex = 140
        Me.Label35.Text = "Permitir agregar ausentismo:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Window
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(368, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(178, 15)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Puede editar periodos inactivos"
        '
        'btnPeriodosInactivos
        '
        '
        '
        '
        Me.btnPeriodosInactivos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnPeriodosInactivos.Location = New System.Drawing.Point(612, 7)
        Me.btnPeriodosInactivos.Name = "btnPeriodosInactivos"
        Me.btnPeriodosInactivos.OffText = "NO"
        Me.btnPeriodosInactivos.OffTextColor = System.Drawing.SystemColors.ControlText
        Me.btnPeriodosInactivos.OnText = "SI"
        Me.btnPeriodosInactivos.OnTextColor = System.Drawing.SystemColors.ControlText
        Me.btnPeriodosInactivos.Size = New System.Drawing.Size(59, 22)
        Me.btnPeriodosInactivos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPeriodosInactivos.TabIndex = 2
        Me.btnPeriodosInactivos.Value = True
        Me.btnPeriodosInactivos.ValueObject = "Y"
        '
        'txtDias
        '
        '
        '
        '
        Me.txtDias.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtDias.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDias.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtDias.Location = New System.Drawing.Point(273, 8)
        Me.txtDias.MaxValue = 30
        Me.txtDias.MinValue = -1
        Me.txtDias.Name = "txtDias"
        Me.txtDias.ShowUpDown = True
        Me.txtDias.Size = New System.Drawing.Size(56, 21)
        Me.txtDias.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Window
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(248, 15)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Días disponibles para autorizar tiempo extra"
        '
        'gpValores
        '
        Me.gpValores.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpValores.BackColor = System.Drawing.SystemColors.Window
        Me.gpValores.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpValores.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpValores.Controls.Add(Me.Label8)
        Me.gpValores.Controls.Add(Me.dgClases)
        Me.gpValores.Controls.Add(Me.sldSueldos)
        Me.gpValores.Controls.Add(Me.sldEdicion)
        Me.gpValores.Controls.Add(Me.sldConsulta)
        Me.gpValores.Controls.Add(Me.Label3)
        Me.gpValores.Controls.Add(Me.Label4)
        Me.gpValores.Controls.Add(Me.Label12)
        Me.gpValores.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpValores.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpValores.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpValores.Location = New System.Drawing.Point(10, 10)
        Me.gpValores.Name = "gpValores"
        Me.gpValores.Size = New System.Drawing.Size(696, 219)
        '
        '
        '
        Me.gpValores.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpValores.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpValores.Style.BackColorGradientAngle = 90
        Me.gpValores.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpValores.Style.BorderBottomWidth = 1
        Me.gpValores.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpValores.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpValores.Style.BorderLeftWidth = 1
        Me.gpValores.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpValores.Style.BorderRightWidth = 1
        Me.gpValores.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpValores.Style.BorderTopWidth = 1
        Me.gpValores.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpValores.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpValores.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpValores.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpValores.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpValores.TabIndex = 0
        Me.gpValores.Text = "Niveles de seguridad en archivo maestro"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Window
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(0, 47)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(686, 25)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Accesos que tendrá por clase:"
        '
        'dgClases
        '
        Me.dgClases.AllowUserToAddRows = False
        Me.dgClases.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgClases.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgClases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgClases.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCia, Me.colClase, Me.colNombre, Me.colNivel, Me.colConsulta, Me.colEdicion, Me.colSueldos})
        Me.dgClases.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgClases.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgClases.Location = New System.Drawing.Point(0, 72)
        Me.dgClases.Name = "dgClases"
        Me.dgClases.ReadOnly = True
        Me.dgClases.RowHeadersVisible = False
        Me.dgClases.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgClases.Size = New System.Drawing.Size(686, 121)
        Me.dgClases.TabIndex = 6
        '
        'colCia
        '
        Me.colCia.DataPropertyName = "cod_comp"
        Me.colCia.HeaderText = "Comp."
        Me.colCia.Name = "colCia"
        Me.colCia.ReadOnly = True
        Me.colCia.Width = 60
        '
        'colClase
        '
        Me.colClase.DataPropertyName = "cod_clase"
        Me.colClase.HeaderText = "Código"
        Me.colClase.Name = "colClase"
        Me.colClase.ReadOnly = True
        Me.colClase.Width = 60
        '
        'colNombre
        '
        Me.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colNombre.DataPropertyName = "nombre"
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        '
        'colNivel
        '
        Me.colNivel.DataPropertyName = "nivel"
        Me.colNivel.HeaderText = "Nivel"
        Me.colNivel.Name = "colNivel"
        Me.colNivel.ReadOnly = True
        Me.colNivel.Width = 50
        '
        'colConsulta
        '
        Me.colConsulta.DataPropertyName = "consulta"
        Me.colConsulta.HeaderText = "Consulta"
        Me.colConsulta.Name = "colConsulta"
        Me.colConsulta.ReadOnly = True
        Me.colConsulta.Width = 70
        '
        'colEdicion
        '
        Me.colEdicion.DataPropertyName = "edición"
        Me.colEdicion.HeaderText = "Edición"
        Me.colEdicion.Name = "colEdicion"
        Me.colEdicion.ReadOnly = True
        Me.colEdicion.Width = 70
        '
        'colSueldos
        '
        Me.colSueldos.DataPropertyName = "sueldos"
        Me.colSueldos.HeaderText = "Sueldos"
        Me.colSueldos.Name = "colSueldos"
        Me.colSueldos.ReadOnly = True
        Me.colSueldos.Width = 70
        '
        'sldSueldos
        '
        '
        '
        '
        Me.sldSueldos.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.sldSueldos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sldSueldos.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.sldSueldos.Location = New System.Drawing.Point(623, 9)
        Me.sldSueldos.MaxValue = 10
        Me.sldSueldos.MinValue = 0
        Me.sldSueldos.Name = "sldSueldos"
        Me.sldSueldos.ShowUpDown = True
        Me.sldSueldos.Size = New System.Drawing.Size(56, 21)
        Me.sldSueldos.TabIndex = 5
        '
        'sldEdicion
        '
        '
        '
        '
        Me.sldEdicion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.sldEdicion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sldEdicion.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.sldEdicion.Location = New System.Drawing.Point(361, 9)
        Me.sldEdicion.MaxValue = 10
        Me.sldEdicion.MinValue = 0
        Me.sldEdicion.Name = "sldEdicion"
        Me.sldEdicion.ShowUpDown = True
        Me.sldEdicion.Size = New System.Drawing.Size(56, 21)
        Me.sldEdicion.TabIndex = 3
        '
        'sldConsulta
        '
        '
        '
        '
        Me.sldConsulta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.sldConsulta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sldConsulta.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.sldConsulta.Location = New System.Drawing.Point(101, 9)
        Me.sldConsulta.MaxValue = 10
        Me.sldConsulta.MinValue = 0
        Me.sldConsulta.Name = "sldConsulta"
        Me.sldConsulta.ShowUpDown = True
        Me.sldConsulta.Size = New System.Drawing.Size(56, 21)
        Me.sldConsulta.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(533, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Ver sueldos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Consulta"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Window
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(270, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 15)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Edición"
        '
        'tabSeguridad
        '
        Me.tabSeguridad.AttachedControl = Me.pnlSeguridad
        Me.tabSeguridad.GlobalItem = False
        Me.tabSeguridad.Name = "tabSeguridad"
        Me.tabSeguridad.Text = "Seguridad"
        '
        'pnlMaestro
        '
        Me.pnlMaestro.Controls.Add(Me.dgMaestro)
        Me.pnlMaestro.Controls.Add(Me.Panel3)
        Me.pnlMaestro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMaestro.Location = New System.Drawing.Point(0, 0)
        Me.pnlMaestro.Name = "pnlMaestro"
        Me.pnlMaestro.Size = New System.Drawing.Size(720, 338)
        Me.pnlMaestro.TabIndex = 3
        Me.pnlMaestro.TabItem = Me.tabMaestro
        '
        'dgMaestro
        '
        Me.dgMaestro.AllowUserToAddRows = False
        Me.dgMaestro.AllowUserToDeleteRows = False
        Me.dgMaestro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMaestro.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MaestroPantalla, Me.controlMaestro, Me.MaestroAcceso})
        Me.dgMaestro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgMaestro.Location = New System.Drawing.Point(0, 25)
        Me.dgMaestro.Name = "dgMaestro"
        Me.dgMaestro.RowHeadersVisible = False
        Me.dgMaestro.Size = New System.Drawing.Size(720, 313)
        Me.dgMaestro.TabIndex = 288
        '
        'MaestroPantalla
        '
        Me.MaestroPantalla.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.MaestroPantalla.DataPropertyName = "pantalla"
        Me.MaestroPantalla.HeaderText = "Pantalla"
        Me.MaestroPantalla.Name = "MaestroPantalla"
        '
        'controlMaestro
        '
        Me.controlMaestro.DataPropertyName = "control"
        Me.controlMaestro.HeaderText = "control"
        Me.controlMaestro.Name = "controlMaestro"
        Me.controlMaestro.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.controlMaestro.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.controlMaestro.Visible = False
        '
        'MaestroAcceso
        '
        Me.MaestroAcceso.DataPropertyName = "acceso"
        Me.MaestroAcceso.HeaderText = "Acceso"
        Me.MaestroAcceso.Name = "MaestroAcceso"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel3.Controls.Add(Me.chkTodosMaestro)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(720, 25)
        Me.Panel3.TabIndex = 287
        '
        'chkTodosMaestro
        '
        '
        '
        '
        Me.chkTodosMaestro.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkTodosMaestro.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.chkTodosMaestro.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.Unckecked16
        Me.chkTodosMaestro.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Right
        Me.chkTodosMaestro.Dock = System.Windows.Forms.DockStyle.Right
        Me.chkTodosMaestro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTodosMaestro.Location = New System.Drawing.Point(578, 0)
        Me.chkTodosMaestro.Name = "chkTodosMaestro"
        Me.chkTodosMaestro.Size = New System.Drawing.Size(142, 25)
        Me.chkTodosMaestro.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkTodosMaestro.TabIndex = 285
        Me.chkTodosMaestro.Text = "Marcar todos"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(716, 25)
        Me.Label6.TabIndex = 284
        Me.Label6.Text = "Seleccione las formas a las que tendrá acceso este perfil"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabMaestro
        '
        Me.tabMaestro.AttachedControl = Me.pnlMaestro
        Me.tabMaestro.GlobalItem = False
        Me.tabMaestro.Name = "tabMaestro"
        Me.tabMaestro.Text = "Archivo maestro"
        '
        'GridColumn3
        '
        Me.GridColumn3.AllowEdit = False
        Me.GridColumn3.DataPropertyName = "modulo"
        Me.GridColumn3.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn3.FilterAutoScan = True
        Me.GridColumn3.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.Wildcards
        Me.GridColumn3.Name = "Módulo"
        Me.GridColumn3.Width = 150
        '
        'GridColumn5
        '
        Me.GridColumn5.AllowEdit = False
        Me.GridColumn5.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill
        Me.GridColumn5.DataPropertyName = "forma"
        Me.GridColumn5.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn5.FilterAutoScan = True
        Me.GridColumn5.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.Wildcards
        Me.GridColumn5.Name = "Forma"
        '
        'GridColumn6
        '
        Me.GridColumn6.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.None
        Me.GridColumn6.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColumn6.CellStyles.Default.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn6.DataPropertyName = "acceso"
        Me.GridColumn6.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl)
        Me.GridColumn6.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn6.FilterAutoScan = True
        Me.GridColumn6.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.Wildcards
        Me.GridColumn6.Name = "Acceso"
        '
        'GridColumn1
        '
        Me.GridColumn1.DataPropertyName = "modulo"
        Me.GridColumn1.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn1.FilterAutoScan = True
        Me.GridColumn1.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.TextBox
        Me.GridColumn1.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.Wildcards
        Me.GridColumn1.Name = "Column1"
        '
        'GridColumn2
        '
        Me.GridColumn2.DataPropertyName = "forma"
        Me.GridColumn2.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn2.FilterAutoScan = True
        Me.GridColumn2.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.TextBox
        Me.GridColumn2.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.Wildcards
        Me.GridColumn2.Name = "Column2"
        Me.GridColumn2.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        '
        'GridColumn4
        '
        Me.GridColumn4.DataPropertyName = "acceso"
        Me.GridColumn4.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl)
        Me.GridColumn4.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn4.FilterAutoScan = True
        Me.GridColumn4.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.CheckBox
        Me.GridColumn4.Name = "Column4"
        Me.GridColumn4.ShowPanelFilterExpr = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        '
        'colModulo
        '
        Me.colModulo.ColumnName = "colModulo"
        Me.colModulo.DataFieldName = "modulo"
        Me.colModulo.Name = "colModulo"
        Me.colModulo.Text = "Módulo"
        Me.colModulo.Width.Absolute = 150
        '
        'gpAvance
        '
        Me.gpAvance.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpAvance.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpAvance.Controls.Add(Me.lblAvance)
        Me.gpAvance.Controls.Add(Me.pbAvance)
        Me.gpAvance.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpAvance.Location = New System.Drawing.Point(318, 158)
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
        Me.gpAvance.TabIndex = 276
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
        Me.lblAvance.TabIndex = 1
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
        Me.pbAvance.TabIndex = 0
        '
        'tabTabla
        '
        Me.tabTabla.BeginGroup = True
        Me.tabTabla.GlobalItem = False
        Me.tabTabla.Name = "tabTabla"
        Me.tabTabla.Text = "Lista"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 80
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
        Me.txtCodigo.Location = New System.Drawing.Point(64, 56)
        Me.txtCodigo.MaxLength = 15
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(153, 21)
        Me.txtCodigo.TabIndex = 1
        '
        'txtNombre
        '
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(281, 56)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(447, 21)
        Me.txtNombre.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(223, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Nombre"
        '
        'bgwRefresca
        '
        Me.bgwRefresca.WorkerReportsProgress = True
        Me.bgwRefresca.WorkerSupportsCancellation = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.Window
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(368, 39)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(188, 15)
        Me.Label13.TabIndex = 145
        Me.Label13.Text = "Puede ajustar asistencia perfecta"
        '
        'swcAsisPerfecta
        '
        '
        '
        '
        Me.swcAsisPerfecta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swcAsisPerfecta.Location = New System.Drawing.Point(612, 35)
        Me.swcAsisPerfecta.Name = "swcAsisPerfecta"
        Me.swcAsisPerfecta.OffText = "NO"
        Me.swcAsisPerfecta.OffTextColor = System.Drawing.SystemColors.ControlText
        Me.swcAsisPerfecta.OnText = "SI"
        Me.swcAsisPerfecta.OnTextColor = System.Drawing.SystemColors.ControlText
        Me.swcAsisPerfecta.Size = New System.Drawing.Size(59, 22)
        Me.swcAsisPerfecta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swcAsisPerfecta.TabIndex = 146
        Me.swcAsisPerfecta.Value = True
        Me.swcAsisPerfecta.ValueObject = "Y"
        '
        'frmPerfiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(857, 586)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gpAvance)
        Me.Controls.Add(Me.EmpNav)
        Me.Controls.Add(Me.txtCodigo)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tabBuscar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPerfiles"
        Me.Text = "Perfiles"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EmpNav.ResumeLayout(False)
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBuscar.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        Me.pnlExcepciones.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.pnlReportes.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.pnlFormas.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        CType(Me.dgCias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.pnlSeguridad.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.gpFiltro.ResumeLayout(False)
        Me.gpFiltro.PerformLayout()
        Me.pnlCriterio.ResumeLayout(False)
        CType(Me.txtDias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpValores.ResumeLayout(False)
        Me.gpValores.PerformLayout()
        CType(Me.dgClases, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sldSueldos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sldEdicion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sldConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMaestro.ResumeLayout(False)
        CType(Me.dgMaestro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.gpAvance.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tabBaja As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents pnlReportesXX As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
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
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents tabBuscar As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents pnlSeguridad As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tabSeguridad As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents tabTabla As DevComponents.DotNetBar.SuperTabItem
    Private WithEvents gpValores As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents pnlFormas As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabFormas As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents pnlReportes As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabReportes As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents pnlMaestro As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabMaestro As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabCias As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents bgwRefresca As System.ComponentModel.BackgroundWorker
    Friend WithEvents gpAvance As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lblAvance As System.Windows.Forms.Label
    Friend WithEvents pbAvance As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents colModulo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents GridColumn1 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn2 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn4 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn3 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn5 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn6 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents dgFormas As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents chkTodosFormas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents GridColumn7 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn8 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn9 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Private WithEvents dgReportes As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents GridColumn10 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn11 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn12 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents chkTodosReportes As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgMaestro As System.Windows.Forms.DataGridView
    Friend WithEvents MaestroPantalla As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents controlMaestro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaestroAcceso As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents chkTodosMaestro As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgCias As System.Windows.Forms.DataGridView
    Friend WithEvents CiasPantalla As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CiasControl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CiasAcceso As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents chkTodosCias As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents sldSueldos As DevComponents.Editors.IntegerInput
    Friend WithEvents sldEdicion As DevComponents.Editors.IntegerInput
    Friend WithEvents sldConsulta As DevComponents.Editors.IntegerInput
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dgClases As System.Windows.Forms.DataGridView
    Friend WithEvents colCia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colClase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNivel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsulta As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colEdicion As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colSueldos As System.Windows.Forms.DataGridViewCheckBoxColumn
    Private WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents txtDias As DevComponents.Editors.IntegerInput
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnPeriodosInactivos As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabExcepciones As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents pnlExcepciones As DevComponents.DotNetBar.SuperTabControlPanel
    Private WithEvents dgExcepciones As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents GridColumn13 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn14 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn15 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn16 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents chkTodosVisible As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkTodosHabilitado As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents colTipoReporte As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents chkTodos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkFiltros As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents pnlCriterio As System.Windows.Forms.Panel
    Friend WithEvents txtCriterio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnVerificar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCriterio As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents gpFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents lstFiltro As DevComponents.DotNetBar.ListBoxAdv
    Friend WithEvents btnCancelarCriterio As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAgregarCriterio As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cbComparacion As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents ComboItem1 As DevComponents.Editors.ComboItem
    Friend WithEvents ComboItem2 As DevComponents.Editors.ComboItem
    Friend WithEvents cbCampos As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtFiltro As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents swcAsisPerfecta As DevComponents.DotNetBar.Controls.SwitchButton
End Class
