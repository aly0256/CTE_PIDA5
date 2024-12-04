<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAutorizacionTiempoExtraPeriodo
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAutorizacionTiempoExtraPeriodo))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlAyuda = New System.Windows.Forms.Panel()
        Me.picAyuda = New System.Windows.Forms.PictureBox()
        Me.lblAyuda = New DevComponents.DotNetBar.LabelX()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.chkConfirmarOH = New System.Windows.Forms.CheckBox()
        Me.chkConfirmarTodo = New System.Windows.Forms.CheckBox()
        Me.btnReporteAutorizacion = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporteExtra = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.btnExtraNO = New DevComponents.DotNetBar.ButtonX()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonX()
        Me.sbPlanta = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.btnReporteAvance = New DevComponents.DotNetBar.ButtonX()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.cmbPeriodo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader()
        Me.btnPeriodoAnterior = New DevComponents.DotNetBar.ButtonX()
        Me.btnPeriodoSiguiente = New DevComponents.DotNetBar.ButtonX()
        Me.panelAutorizacion = New System.Windows.Forms.Panel()
        Me.Line3 = New DevComponents.DotNetBar.Controls.Line()
        Me.Line2 = New DevComponents.DotNetBar.Controls.Line()
        Me.btnAutorizarGlobal = New DevComponents.DotNetBar.ButtonX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtiFechaAutorizacion = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbTodoElTiempoExtra = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtHorasAutorizacion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.lblTituloPantalla = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvExtraAut = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ColumnReloj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnTurno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnDepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnClase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnReporteExt = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tabDatos = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgvNomSem = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ColumnNomSemReloj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colComp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnNomSemNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnNomSemTurno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnNomSemDepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnNomSemClase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnEstatus = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ColumnHrsNormales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnHrsExtra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnPrimaDom = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ColumnPrimaSab = New System.Windows.Forms.DataGridViewImageColumn()
        Me.ColumnVacPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnDIAFIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnSinPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnConPago = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnConfirmacion = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColumnUsuarioFirma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnFechaFirma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SuperTabItem2 = New DevComponents.DotNetBar.SuperTabItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.advSupervisores = New DevComponents.AdvTree.AdvTree()
        Me.Node1 = New DevComponents.AdvTree.Node()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle2 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle3 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle4 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle5 = New DevComponents.DotNetBar.ElementStyle()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.pnlAyuda.SuspendLayout()
        CType(Me.picAyuda, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.panelAutorizacion.SuspendLayout()
        CType(Me.dtiFechaAutorizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvExtraAut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDatos.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.dgvNomSem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.advSupervisores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlAyuda)
        Me.Panel1.Controls.Add(Me.btnReporteAutorizacion)
        Me.Panel1.Controls.Add(Me.btnReporteExtra)
        Me.Panel1.Controls.Add(Me.ButtonX1)
        Me.Panel1.Controls.Add(Me.btnExtraNO)
        Me.Panel1.Controls.Add(Me.btnRefresh)
        Me.Panel1.Controls.Add(Me.sbPlanta)
        Me.Panel1.Controls.Add(Me.btnReporteAvance)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.panelAutorizacion)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Line1)
        Me.Panel1.Controls.Add(Me.lblTituloPantalla)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1273, 142)
        Me.Panel1.TabIndex = 112
        '
        'pnlAyuda
        '
        Me.pnlAyuda.Controls.Add(Me.picAyuda)
        Me.pnlAyuda.Controls.Add(Me.lblAyuda)
        Me.pnlAyuda.Controls.Add(Me.Panel8)
        Me.pnlAyuda.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAyuda.Location = New System.Drawing.Point(935, 0)
        Me.pnlAyuda.Name = "pnlAyuda"
        Me.pnlAyuda.Size = New System.Drawing.Size(338, 142)
        Me.pnlAyuda.TabIndex = 129
        '
        'picAyuda
        '
        Me.picAyuda.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picAyuda.Image = Global.PIDA.My.Resources.Resources.AyudaTextra
        Me.picAyuda.Location = New System.Drawing.Point(25, 0)
        Me.picAyuda.Margin = New System.Windows.Forms.Padding(0)
        Me.picAyuda.Name = "picAyuda"
        Me.picAyuda.Size = New System.Drawing.Size(313, 116)
        Me.picAyuda.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picAyuda.TabIndex = 124
        Me.picAyuda.TabStop = False
        '
        'lblAyuda
        '
        Me.lblAyuda.BackColor = System.Drawing.Color.Gainsboro
        '
        '
        '
        Me.lblAyuda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblAyuda.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblAyuda.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAyuda.ForeColor = System.Drawing.Color.Black
        Me.lblAyuda.Location = New System.Drawing.Point(0, 0)
        Me.lblAyuda.Name = "lblAyuda"
        Me.lblAyuda.Size = New System.Drawing.Size(25, 116)
        Me.lblAyuda.TabIndex = 123
        Me.lblAyuda.Text = "Ejemplos"
        Me.lblAyuda.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblAyuda.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.lblAyuda.VerticalTextTopUp = False
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.chkConfirmarOH)
        Me.Panel8.Controls.Add(Me.chkConfirmarTodo)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel8.Location = New System.Drawing.Point(0, 116)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(338, 26)
        Me.Panel8.TabIndex = 1
        '
        'chkConfirmarOH
        '
        Me.chkConfirmarOH.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkConfirmarOH.AutoSize = True
        Me.chkConfirmarOH.Enabled = False
        Me.chkConfirmarOH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkConfirmarOH.Location = New System.Drawing.Point(3, 4)
        Me.chkConfirmarOH.Name = "chkConfirmarOH"
        Me.chkConfirmarOH.Size = New System.Drawing.Size(113, 19)
        Me.chkConfirmarOH.TabIndex = 128
        Me.chkConfirmarOH.Text = "Confirmar OH"
        Me.chkConfirmarOH.UseVisualStyleBackColor = True
        Me.chkConfirmarOH.Visible = False
        '
        'chkConfirmarTodo
        '
        Me.chkConfirmarTodo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkConfirmarTodo.AutoSize = True
        Me.chkConfirmarTodo.Enabled = False
        Me.chkConfirmarTodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkConfirmarTodo.Location = New System.Drawing.Point(125, 4)
        Me.chkConfirmarTodo.Name = "chkConfirmarTodo"
        Me.chkConfirmarTodo.Size = New System.Drawing.Size(121, 19)
        Me.chkConfirmarTodo.TabIndex = 122
        Me.chkConfirmarTodo.Text = "Confirmar BRP"
        Me.chkConfirmarTodo.UseVisualStyleBackColor = True
        Me.chkConfirmarTodo.Visible = False
        '
        'btnReporteAutorizacion
        '
        Me.btnReporteAutorizacion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporteAutorizacion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporteAutorizacion.Enabled = False
        Me.btnReporteAutorizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporteAutorizacion.Image = Global.PIDA.My.Resources.Resources.Printer16
        Me.btnReporteAutorizacion.Location = New System.Drawing.Point(19, 116)
        Me.btnReporteAutorizacion.Name = "btnReporteAutorizacion"
        Me.btnReporteAutorizacion.Size = New System.Drawing.Size(224, 23)
        Me.btnReporteAutorizacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporteAutorizacion.TabIndex = 10
        Me.btnReporteAutorizacion.Text = "Reporte de autorización"
        Me.btnReporteAutorizacion.Visible = False
        '
        'btnReporteExtra
        '
        Me.btnReporteExtra.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporteExtra.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporteExtra.Enabled = False
        Me.btnReporteExtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporteExtra.Image = Global.PIDA.My.Resources.Resources.Printer16
        Me.btnReporteExtra.Location = New System.Drawing.Point(19, 116)
        Me.btnReporteExtra.Name = "btnReporteExtra"
        Me.btnReporteExtra.Size = New System.Drawing.Size(224, 23)
        Me.btnReporteExtra.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporteExtra.TabIndex = 127
        Me.btnReporteExtra.Text = "Reporte T.E (correo)"
        Me.btnReporteExtra.Visible = False
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Enabled = False
        Me.ButtonX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX1.Image = Global.PIDA.My.Resources.Resources.Printer16
        Me.ButtonX1.Location = New System.Drawing.Point(19, 91)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(224, 23)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 11
        Me.ButtonX1.Text = "Resumen de incidencias"
        Me.ButtonX1.Visible = False
        '
        'btnExtraNO
        '
        Me.btnExtraNO.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnExtraNO.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnExtraNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExtraNO.Image = Global.PIDA.My.Resources.Resources.Printer16
        Me.btnExtraNO.Location = New System.Drawing.Point(247, 116)
        Me.btnExtraNO.Name = "btnExtraNO"
        Me.btnExtraNO.Size = New System.Drawing.Size(224, 23)
        Me.btnExtraNO.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnExtraNO.TabIndex = 125
        Me.btnExtraNO.Text = "T.E. Trabajado / Autorizado"
        '
        'btnRefresh
        '
        Me.btnRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnRefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnRefresh.Enabled = False
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Image = Global.PIDA.My.Resources.Resources.refresh16
        Me.btnRefresh.Location = New System.Drawing.Point(445, 62)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(26, 26)
        Me.btnRefresh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnRefresh.TabIndex = 124
        '
        'sbPlanta
        '
        '
        '
        '
        Me.sbPlanta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sbPlanta.Enabled = False
        Me.sbPlanta.Location = New System.Drawing.Point(19, 92)
        Me.sbPlanta.Name = "sbPlanta"
        Me.sbPlanta.OffText = "Planta 1"
        Me.sbPlanta.OnText = "Planta 2"
        Me.sbPlanta.Size = New System.Drawing.Size(222, 22)
        Me.sbPlanta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sbPlanta.TabIndex = 123
        Me.sbPlanta.ValueFalse = "001"
        Me.sbPlanta.ValueTrue = "002"
        Me.sbPlanta.Visible = False
        '
        'btnReporteAvance
        '
        Me.btnReporteAvance.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporteAvance.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporteAvance.Enabled = False
        Me.btnReporteAvance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporteAvance.Image = Global.PIDA.My.Resources.Resources.Printer16
        Me.btnReporteAvance.Location = New System.Drawing.Point(247, 92)
        Me.btnReporteAvance.Name = "btnReporteAvance"
        Me.btnReporteAvance.Size = New System.Drawing.Size(224, 23)
        Me.btnReporteAvance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporteAvance.TabIndex = 8
        Me.btnReporteAvance.Text = "Reporte de avance "
        Me.btnReporteAvance.Visible = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.cmbPeriodo)
        Me.Panel4.Controls.Add(Me.btnPeriodoAnterior)
        Me.Panel4.Controls.Add(Me.btnPeriodoSiguiente)
        Me.Panel4.Location = New System.Drawing.Point(19, 62)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(420, 26)
        Me.Panel4.TabIndex = 121
        '
        'cmbPeriodo
        '
        Me.cmbPeriodo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPeriodo.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPeriodo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPeriodo.ButtonDropDown.Visible = True
        Me.cmbPeriodo.Columns.Add(Me.ColumnHeader1)
        Me.cmbPeriodo.Columns.Add(Me.ColumnHeader2)
        Me.cmbPeriodo.Columns.Add(Me.ColumnHeader3)
        Me.cmbPeriodo.Columns.Add(Me.ColumnHeader4)
        Me.cmbPeriodo.Columns.Add(Me.ColumnHeader5)
        Me.cmbPeriodo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPeriodo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPeriodo.Location = New System.Drawing.Point(25, 0)
        Me.cmbPeriodo.Name = "cmbPeriodo"
        Me.cmbPeriodo.Size = New System.Drawing.Size(370, 26)
        Me.cmbPeriodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPeriodo.TabIndex = 115
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "anoper"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Column"
        Me.ColumnHeader1.Visible = False
        Me.ColumnHeader1.Width.Absolute = 150
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "ano"
        Me.ColumnHeader2.Editable = False
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Año"
        Me.ColumnHeader2.Width.Absolute = 75
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DataFieldName = "per"
        Me.ColumnHeader3.Editable = False
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Periodo"
        Me.ColumnHeader3.Width.Absolute = 75
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DataFieldName = "fecha_ini"
        Me.ColumnHeader4.Editable = False
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "Inicio"
        Me.ColumnHeader4.Width.Absolute = 100
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DataFieldName = "fecha_fin"
        Me.ColumnHeader5.Editable = False
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.StretchToFill = True
        Me.ColumnHeader5.Text = "Fin"
        Me.ColumnHeader5.Width.Absolute = 100
        '
        'btnPeriodoAnterior
        '
        Me.btnPeriodoAnterior.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPeriodoAnterior.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPeriodoAnterior.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnPeriodoAnterior.Image = Global.PIDA.My.Resources.Resources.Prev16
        Me.btnPeriodoAnterior.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnPeriodoAnterior.Location = New System.Drawing.Point(0, 0)
        Me.btnPeriodoAnterior.Name = "btnPeriodoAnterior"
        Me.btnPeriodoAnterior.Size = New System.Drawing.Size(25, 26)
        Me.btnPeriodoAnterior.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPeriodoAnterior.TabIndex = 115
        Me.btnPeriodoAnterior.Tooltip = "Periodo anterior"
        '
        'btnPeriodoSiguiente
        '
        Me.btnPeriodoSiguiente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPeriodoSiguiente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPeriodoSiguiente.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnPeriodoSiguiente.Image = Global.PIDA.My.Resources.Resources.Next16
        Me.btnPeriodoSiguiente.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnPeriodoSiguiente.Location = New System.Drawing.Point(395, 0)
        Me.btnPeriodoSiguiente.Name = "btnPeriodoSiguiente"
        Me.btnPeriodoSiguiente.Size = New System.Drawing.Size(25, 26)
        Me.btnPeriodoSiguiente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPeriodoSiguiente.TabIndex = 114
        Me.btnPeriodoSiguiente.Tooltip = "Periodo siguiente"
        '
        'panelAutorizacion
        '
        Me.panelAutorizacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelAutorizacion.Controls.Add(Me.Line3)
        Me.panelAutorizacion.Controls.Add(Me.Line2)
        Me.panelAutorizacion.Controls.Add(Me.btnAutorizarGlobal)
        Me.panelAutorizacion.Controls.Add(Me.Label5)
        Me.panelAutorizacion.Controls.Add(Me.dtiFechaAutorizacion)
        Me.panelAutorizacion.Controls.Add(Me.Label4)
        Me.panelAutorizacion.Controls.Add(Me.cbTodoElTiempoExtra)
        Me.panelAutorizacion.Controls.Add(Me.Label3)
        Me.panelAutorizacion.Controls.Add(Me.txtHorasAutorizacion)
        Me.panelAutorizacion.Location = New System.Drawing.Point(504, 11)
        Me.panelAutorizacion.Name = "panelAutorizacion"
        Me.panelAutorizacion.Size = New System.Drawing.Size(398, 125)
        Me.panelAutorizacion.TabIndex = 118
        '
        'Line3
        '
        Me.Line3.DashOffset = 1.0!
        Me.Line3.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.Line3.ForeColor = System.Drawing.Color.LightGray
        Me.Line3.Location = New System.Drawing.Point(277, 16)
        Me.Line3.Name = "Line3"
        Me.Line3.Size = New System.Drawing.Size(13, 79)
        Me.Line3.TabIndex = 118
        Me.Line3.Text = "Line3"
        Me.Line3.VerticalLine = True
        '
        'Line2
        '
        Me.Line2.DashOffset = 1.0!
        Me.Line2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.Line2.ForeColor = System.Drawing.Color.LightGray
        Me.Line2.Location = New System.Drawing.Point(117, 34)
        Me.Line2.Name = "Line2"
        Me.Line2.Size = New System.Drawing.Size(17, 42)
        Me.Line2.TabIndex = 117
        Me.Line2.Text = "Line2"
        Me.Line2.VerticalLine = True
        '
        'btnAutorizarGlobal
        '
        Me.btnAutorizarGlobal.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAutorizarGlobal.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAutorizarGlobal.Enabled = False
        Me.btnAutorizarGlobal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutorizarGlobal.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAutorizarGlobal.Location = New System.Drawing.Point(296, 50)
        Me.btnAutorizarGlobal.Name = "btnAutorizarGlobal"
        Me.btnAutorizarGlobal.Size = New System.Drawing.Size(88, 26)
        Me.btnAutorizarGlobal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAutorizarGlobal.TabIndex = 6
        Me.btnAutorizarGlobal.Text = "Autorizar"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(140, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Fecha"
        '
        'dtiFechaAutorizacion
        '
        '
        '
        '
        Me.dtiFechaAutorizacion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtiFechaAutorizacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFechaAutorizacion.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtiFechaAutorizacion.ButtonDropDown.Visible = True
        Me.dtiFechaAutorizacion.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
        Me.dtiFechaAutorizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtiFechaAutorizacion.IsPopupCalendarOpen = False
        Me.dtiFechaAutorizacion.Location = New System.Drawing.Point(140, 50)
        '
        '
        '
        Me.dtiFechaAutorizacion.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtiFechaAutorizacion.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFechaAutorizacion.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.dtiFechaAutorizacion.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtiFechaAutorizacion.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiFechaAutorizacion.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtiFechaAutorizacion.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtiFechaAutorizacion.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtiFechaAutorizacion.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtiFechaAutorizacion.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFechaAutorizacion.MonthCalendar.DisplayMonth = New Date(2017, 7, 1, 0, 0, 0, 0)
        Me.dtiFechaAutorizacion.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.dtiFechaAutorizacion.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtiFechaAutorizacion.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtiFechaAutorizacion.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtiFechaAutorizacion.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiFechaAutorizacion.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtiFechaAutorizacion.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFechaAutorizacion.MonthCalendar.TodayButtonVisible = True
        Me.dtiFechaAutorizacion.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtiFechaAutorizacion.Name = "dtiFechaAutorizacion"
        Me.dtiFechaAutorizacion.Size = New System.Drawing.Size(129, 26)
        Me.dtiFechaAutorizacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtiFechaAutorizacion.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(188, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Autorización tiempo extra global"
        '
        'cbTodoElTiempoExtra
        '
        Me.cbTodoElTiempoExtra.AutoSize = True
        Me.cbTodoElTiempoExtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTodoElTiempoExtra.Location = New System.Drawing.Point(6, 82)
        Me.cbTodoElTiempoExtra.Name = "cbTodoElTiempoExtra"
        Me.cbTodoElTiempoExtra.Size = New System.Drawing.Size(229, 20)
        Me.cbTodoElTiempoExtra.TabIndex = 2
        Me.cbTodoElTiempoExtra.Text = "Autorizar con Regla de 30 minutos"
        Me.cbTodoElTiempoExtra.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Tiempo límite:"
        '
        'txtHorasAutorizacion
        '
        Me.txtHorasAutorizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorasAutorizacion.Location = New System.Drawing.Point(6, 50)
        Me.txtHorasAutorizacion.Name = "txtHorasAutorizacion"
        Me.txtHorasAutorizacion.Size = New System.Drawing.Size(100, 26)
        Me.txtHorasAutorizacion.TabIndex = 0
        Me.txtHorasAutorizacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 117
        Me.Label2.Text = "Seleccionar periodo"
        '
        'Line1
        '
        Me.Line1.DashOffset = 1.0!
        Me.Line1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash
        Me.Line1.Location = New System.Drawing.Point(477, 12)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(21, 103)
        Me.Line1.TabIndex = 116
        Me.Line1.Text = "Line1"
        Me.Line1.VerticalLine = True
        '
        'lblTituloPantalla
        '
        Me.lblTituloPantalla.AutoSize = True
        Me.lblTituloPantalla.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloPantalla.ForeColor = System.Drawing.Color.Black
        Me.lblTituloPantalla.Location = New System.Drawing.Point(12, 9)
        Me.lblTituloPantalla.Name = "lblTituloPantalla"
        Me.lblTituloPantalla.Size = New System.Drawing.Size(459, 37)
        Me.lblTituloPantalla.TabIndex = 114
        Me.lblTituloPantalla.Text = "Autorización de tiempo extra"
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 477)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1273, 29)
        Me.Panel2.TabIndex = 113
        '
        'dgvExtraAut
        '
        Me.dgvExtraAut.AllowUserToAddRows = False
        Me.dgvExtraAut.AllowUserToDeleteRows = False
        Me.dgvExtraAut.AllowUserToResizeColumns = False
        Me.dgvExtraAut.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExtraAut.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvExtraAut.ColumnHeadersHeight = 40
        Me.dgvExtraAut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvExtraAut.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnReloj, Me.ColumnNombre, Me.ColumnTurno, Me.ColumnDepto, Me.ColumnClase, Me.ColumnReporteExt})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(141, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvExtraAut.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvExtraAut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvExtraAut.EnableHeadersVisualStyles = False
        Me.dgvExtraAut.GridColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.dgvExtraAut.Location = New System.Drawing.Point(0, 0)
        Me.dgvExtraAut.MultiSelect = False
        Me.dgvExtraAut.Name = "dgvExtraAut"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExtraAut.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvExtraAut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvExtraAut.Size = New System.Drawing.Size(922, 335)
        Me.dgvExtraAut.TabIndex = 114
        '
        'ColumnReloj
        '
        Me.ColumnReloj.Frozen = True
        Me.ColumnReloj.HeaderText = "Reloj"
        Me.ColumnReloj.Name = "ColumnReloj"
        Me.ColumnReloj.ReadOnly = True
        Me.ColumnReloj.Width = 50
        '
        'ColumnNombre
        '
        Me.ColumnNombre.Frozen = True
        Me.ColumnNombre.HeaderText = "Nombre"
        Me.ColumnNombre.Name = "ColumnNombre"
        Me.ColumnNombre.ReadOnly = True
        Me.ColumnNombre.Width = 200
        '
        'ColumnTurno
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.ColumnTurno.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColumnTurno.Frozen = True
        Me.ColumnTurno.HeaderText = "Hor."
        Me.ColumnTurno.Name = "ColumnTurno"
        Me.ColumnTurno.ReadOnly = True
        Me.ColumnTurno.Width = 50
        '
        'ColumnDepto
        '
        Me.ColumnDepto.Frozen = True
        Me.ColumnDepto.HeaderText = "Depto."
        Me.ColumnDepto.Name = "ColumnDepto"
        Me.ColumnDepto.ReadOnly = True
        Me.ColumnDepto.Width = 70
        '
        'ColumnClase
        '
        Me.ColumnClase.Frozen = True
        Me.ColumnClase.HeaderText = "Clase"
        Me.ColumnClase.Name = "ColumnClase"
        Me.ColumnClase.ReadOnly = True
        Me.ColumnClase.Width = 50
        '
        'ColumnReporteExt
        '
        Me.ColumnReporteExt.Frozen = True
        Me.ColumnReporteExt.HeaderText = "Reporte"
        Me.ColumnReporteExt.Name = "ColumnReporteExt"
        '
        'tabDatos
        '
        '
        '
        '
        '
        '
        '
        Me.tabDatos.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.tabDatos.ControlBox.MenuBox.Name = ""
        Me.tabDatos.ControlBox.Name = ""
        Me.tabDatos.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabDatos.ControlBox.MenuBox, Me.tabDatos.ControlBox.CloseBox})
        Me.tabDatos.Controls.Add(Me.SuperTabControlPanel2)
        Me.tabDatos.Controls.Add(Me.SuperTabControlPanel1)
        Me.tabDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabDatos.Location = New System.Drawing.Point(250, 0)
        Me.tabDatos.Name = "tabDatos"
        Me.tabDatos.ReorderTabsEnabled = True
        Me.tabDatos.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabDatos.SelectedTabIndex = 0
        Me.tabDatos.Size = New System.Drawing.Size(1023, 335)
        Me.tabDatos.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.tabDatos.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabDatos.TabIndex = 115
        Me.tabDatos.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.MultiLineFit
        Me.tabDatos.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem2, Me.SuperTabItem1})
        Me.tabDatos.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.tabDatos.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.dgvExtraAut)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(922, 335)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Tiempo extra"
        Me.SuperTabItem1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.dgvNomSem)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(925, 335)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.SuperTabItem2
        '
        'dgvNomSem
        '
        Me.dgvNomSem.AllowUserToAddRows = False
        Me.dgvNomSem.AllowUserToDeleteRows = False
        Me.dgvNomSem.AllowUserToResizeColumns = False
        Me.dgvNomSem.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvNomSem.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvNomSem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvNomSem.ColumnHeadersHeight = 40
        Me.dgvNomSem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnNomSemReloj, Me.colComp, Me.ColumnNomSemNombre, Me.ColumnNomSemTurno, Me.ColumnNomSemDepto, Me.ColumnNomSemClase, Me.ColumnEstatus, Me.ColumnHrsNormales, Me.ColumnHrsExtra, Me.ColumnPrimaDom, Me.ColumnPrimaSab, Me.ColumnVacPago, Me.ColumnDIAFIN, Me.ColumnSinPago, Me.ColumnConPago, Me.ColumnConfirmacion, Me.ColumnUsuarioFirma, Me.ColumnFechaFirma})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(141, Byte), Integer))
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvNomSem.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgvNomSem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvNomSem.EnableHeadersVisualStyles = False
        Me.dgvNomSem.GridColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.dgvNomSem.Location = New System.Drawing.Point(0, 0)
        Me.dgvNomSem.MultiSelect = False
        Me.dgvNomSem.Name = "dgvNomSem"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvNomSem.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvNomSem.Size = New System.Drawing.Size(925, 335)
        Me.dgvNomSem.TabIndex = 0
        '
        'ColumnNomSemReloj
        '
        Me.ColumnNomSemReloj.Frozen = True
        Me.ColumnNomSemReloj.HeaderText = "Reloj"
        Me.ColumnNomSemReloj.Name = "ColumnNomSemReloj"
        Me.ColumnNomSemReloj.ReadOnly = True
        Me.ColumnNomSemReloj.Width = 50
        '
        'colComp
        '
        Me.colComp.DataPropertyName = "cod_comp"
        Me.colComp.Frozen = True
        Me.colComp.HeaderText = "cod_comp"
        Me.colComp.Name = "colComp"
        Me.colComp.Visible = False
        '
        'ColumnNomSemNombre
        '
        Me.ColumnNomSemNombre.Frozen = True
        Me.ColumnNomSemNombre.HeaderText = "Nombre"
        Me.ColumnNomSemNombre.Name = "ColumnNomSemNombre"
        Me.ColumnNomSemNombre.ReadOnly = True
        Me.ColumnNomSemNombre.Width = 200
        '
        'ColumnNomSemTurno
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColumnNomSemTurno.DefaultCellStyle = DataGridViewCellStyle7
        Me.ColumnNomSemTurno.Frozen = True
        Me.ColumnNomSemTurno.HeaderText = "Turno"
        Me.ColumnNomSemTurno.Name = "ColumnNomSemTurno"
        Me.ColumnNomSemTurno.ReadOnly = True
        Me.ColumnNomSemTurno.Width = 50
        '
        'ColumnNomSemDepto
        '
        Me.ColumnNomSemDepto.Frozen = True
        Me.ColumnNomSemDepto.HeaderText = "Depto."
        Me.ColumnNomSemDepto.Name = "ColumnNomSemDepto"
        Me.ColumnNomSemDepto.ReadOnly = True
        Me.ColumnNomSemDepto.Width = 70
        '
        'ColumnNomSemClase
        '
        Me.ColumnNomSemClase.Frozen = True
        Me.ColumnNomSemClase.HeaderText = "Clase"
        Me.ColumnNomSemClase.Name = "ColumnNomSemClase"
        Me.ColumnNomSemClase.ReadOnly = True
        Me.ColumnNomSemClase.Width = 50
        '
        'ColumnEstatus
        '
        Me.ColumnEstatus.Frozen = True
        Me.ColumnEstatus.HeaderText = "O"
        Me.ColumnEstatus.Name = "ColumnEstatus"
        Me.ColumnEstatus.ReadOnly = True
        Me.ColumnEstatus.Width = 32
        '
        'ColumnHrsNormales
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColumnHrsNormales.DefaultCellStyle = DataGridViewCellStyle8
        Me.ColumnHrsNormales.HeaderText = "Hrs. Normales"
        Me.ColumnHrsNormales.Name = "ColumnHrsNormales"
        Me.ColumnHrsNormales.ReadOnly = True
        '
        'ColumnHrsExtra
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColumnHrsExtra.DefaultCellStyle = DataGridViewCellStyle9
        Me.ColumnHrsExtra.HeaderText = "Hrs. Extra"
        Me.ColumnHrsExtra.Name = "ColumnHrsExtra"
        Me.ColumnHrsExtra.ReadOnly = True
        '
        'ColumnPrimaDom
        '
        Me.ColumnPrimaDom.HeaderText = "Prima Dom."
        Me.ColumnPrimaDom.Name = "ColumnPrimaDom"
        Me.ColumnPrimaDom.ReadOnly = True
        Me.ColumnPrimaDom.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColumnPrimaDom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ColumnPrimaSab
        '
        Me.ColumnPrimaSab.HeaderText = "Prima Sab."
        Me.ColumnPrimaSab.Name = "ColumnPrimaSab"
        Me.ColumnPrimaSab.ReadOnly = True
        '
        'ColumnVacPago
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColumnVacPago.DefaultCellStyle = DataGridViewCellStyle10
        Me.ColumnVacPago.HeaderText = "Vacaciones"
        Me.ColumnVacPago.Name = "ColumnVacPago"
        Me.ColumnVacPago.ReadOnly = True
        '
        'ColumnDIAFIN
        '
        Me.ColumnDIAFIN.HeaderText = "Faltas injustificadas"
        Me.ColumnDIAFIN.Name = "ColumnDIAFIN"
        Me.ColumnDIAFIN.ReadOnly = True
        '
        'ColumnSinPago
        '
        Me.ColumnSinPago.HeaderText = "Ausentismos sin pago"
        Me.ColumnSinPago.Name = "ColumnSinPago"
        Me.ColumnSinPago.ReadOnly = True
        '
        'ColumnConPago
        '
        Me.ColumnConPago.HeaderText = "AusentismosConPago"
        Me.ColumnConPago.Name = "ColumnConPago"
        Me.ColumnConPago.ReadOnly = True
        '
        'ColumnConfirmacion
        '
        Me.ColumnConfirmacion.HeaderText = "Confirmar"
        Me.ColumnConfirmacion.MinimumWidth = 75
        Me.ColumnConfirmacion.Name = "ColumnConfirmacion"
        Me.ColumnConfirmacion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColumnConfirmacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ColumnConfirmacion.Width = 75
        '
        'ColumnUsuarioFirma
        '
        Me.ColumnUsuarioFirma.HeaderText = "Usuario"
        Me.ColumnUsuarioFirma.MinimumWidth = 75
        Me.ColumnUsuarioFirma.Name = "ColumnUsuarioFirma"
        Me.ColumnUsuarioFirma.ReadOnly = True
        Me.ColumnUsuarioFirma.Width = 75
        '
        'ColumnFechaFirma
        '
        Me.ColumnFechaFirma.HeaderText = "Fecha"
        Me.ColumnFechaFirma.MinimumWidth = 125
        Me.ColumnFechaFirma.Name = "ColumnFechaFirma"
        Me.ColumnFechaFirma.ReadOnly = True
        Me.ColumnFechaFirma.Width = 125
        '
        'SuperTabItem2
        '
        Me.SuperTabItem2.AttachedControl = Me.SuperTabControlPanel2
        Me.SuperTabItem2.Enabled = False
        Me.SuperTabItem2.GlobalItem = False
        Me.SuperTabItem2.Name = "SuperTabItem2"
        Me.SuperTabItem2.Text = "Asistencia"
        Me.SuperTabItem2.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.SuperTabItem2.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'advSupervisores
        '
        Me.advSupervisores.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.advSupervisores.AllowDrop = True
        Me.advSupervisores.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.advSupervisores.BackgroundStyle.Class = "TreeBorderKey"
        Me.advSupervisores.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.advSupervisores.Dock = System.Windows.Forms.DockStyle.Left
        Me.advSupervisores.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.advSupervisores.Location = New System.Drawing.Point(0, 0)
        Me.advSupervisores.Name = "advSupervisores"
        Me.advSupervisores.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node1})
        Me.advSupervisores.NodesConnector = Me.NodeConnector1
        Me.advSupervisores.NodeStyle = Me.ElementStyle1
        Me.advSupervisores.PathSeparator = ";"
        Me.advSupervisores.Size = New System.Drawing.Size(250, 335)
        Me.advSupervisores.Styles.Add(Me.ElementStyle1)
        Me.advSupervisores.Styles.Add(Me.ElementStyle2)
        Me.advSupervisores.Styles.Add(Me.ElementStyle3)
        Me.advSupervisores.Styles.Add(Me.ElementStyle4)
        Me.advSupervisores.Styles.Add(Me.ElementStyle5)
        Me.advSupervisores.TabIndex = 116
        Me.advSupervisores.Text = "AdvTree1"
        '
        'Node1
        '
        Me.Node1.Expanded = True
        Me.Node1.Name = "Node1"
        Me.Node1.Style = Me.ElementStyle1
        Me.Node1.StyleSelected = Me.ElementStyle1
        Me.Node1.Text = "Node1"
        '
        'ElementStyle1
        '
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.TextColor = System.Drawing.SystemColors.ControlText
        '
        'NodeConnector1
        '
        Me.NodeConnector1.LineColor = System.Drawing.SystemColors.ControlText
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
        'ElementStyle3
        '
        Me.ElementStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ElementStyle3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ElementStyle3.BackColorGradientAngle = 90
        Me.ElementStyle3.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle3.BorderBottomWidth = 1
        Me.ElementStyle3.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle3.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle3.BorderLeftWidth = 1
        Me.ElementStyle3.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle3.BorderRightWidth = 1
        Me.ElementStyle3.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle3.BorderTopWidth = 1
        Me.ElementStyle3.CornerDiameter = 4
        Me.ElementStyle3.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle3.Description = "BlueLight"
        Me.ElementStyle3.Name = "ElementStyle3"
        Me.ElementStyle3.PaddingBottom = 1
        Me.ElementStyle3.PaddingLeft = 1
        Me.ElementStyle3.PaddingRight = 1
        Me.ElementStyle3.PaddingTop = 1
        Me.ElementStyle3.TextColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(115, Byte), Integer))
        '
        'ElementStyle4
        '
        Me.ElementStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ElementStyle4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.ElementStyle4.BackColorGradientAngle = 90
        Me.ElementStyle4.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle4.BorderBottomWidth = 1
        Me.ElementStyle4.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle4.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle4.BorderLeftWidth = 1
        Me.ElementStyle4.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle4.BorderRightWidth = 1
        Me.ElementStyle4.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle4.BorderTopWidth = 1
        Me.ElementStyle4.CornerDiameter = 4
        Me.ElementStyle4.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle4.Description = "Tan"
        Me.ElementStyle4.Name = "ElementStyle4"
        Me.ElementStyle4.PaddingBottom = 1
        Me.ElementStyle4.PaddingLeft = 1
        Me.ElementStyle4.PaddingRight = 1
        Me.ElementStyle4.PaddingTop = 1
        Me.ElementStyle4.TextColor = System.Drawing.Color.Black
        '
        'ElementStyle5
        '
        Me.ElementStyle5.BackColor = System.Drawing.Color.White
        Me.ElementStyle5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ElementStyle5.BackColorGradientAngle = 90
        Me.ElementStyle5.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle5.BorderBottomWidth = 1
        Me.ElementStyle5.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle5.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle5.BorderLeftWidth = 1
        Me.ElementStyle5.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle5.BorderRightWidth = 1
        Me.ElementStyle5.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle5.BorderTopWidth = 1
        Me.ElementStyle5.CornerDiameter = 4
        Me.ElementStyle5.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle5.Description = "Gray"
        Me.ElementStyle5.Name = "ElementStyle5"
        Me.ElementStyle5.PaddingBottom = 1
        Me.ElementStyle5.PaddingLeft = 1
        Me.ElementStyle5.PaddingRight = 1
        Me.ElementStyle5.PaddingTop = 1
        Me.ElementStyle5.TextColor = System.Drawing.Color.Black
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.tabDatos)
        Me.Panel5.Controls.Add(Me.advSupervisores)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 142)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1273, 335)
        Me.Panel5.TabIndex = 116
        '
        'frmAutorizacionTiempoExtraPeriodo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1273, 506)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAutorizacionTiempoExtraPeriodo"
        Me.Text = "Resumen semanal TA & TE"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlAyuda.ResumeLayout(False)
        CType(Me.picAyuda, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.panelAutorizacion.ResumeLayout(False)
        Me.panelAutorizacion.PerformLayout()
        CType(Me.dtiFechaAutorizacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvExtraAut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDatos.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.dgvNomSem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.advSupervisores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblTituloPantalla As System.Windows.Forms.Label
    Friend WithEvents dgvExtraAut As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents cmbPeriodo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents tabDatos As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem2 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents panelAutorizacion As System.Windows.Forms.Panel
    Friend WithEvents txtHorasAutorizacion As System.Windows.Forms.TextBox
    Friend WithEvents cbTodoElTiempoExtra As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtiFechaAutorizacion As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents btnAutorizarGlobal As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Line3 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Line2 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents dgvNomSem As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents advSupervisores As DevComponents.AdvTree.AdvTree
    Friend WithEvents Node1 As DevComponents.AdvTree.Node
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents ElementStyle2 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle3 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle4 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle5 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnPeriodoAnterior As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPeriodoSiguiente As DevComponents.DotNetBar.ButtonX
    Friend WithEvents chkConfirmarTodo As System.Windows.Forms.CheckBox
    Friend WithEvents btnReporteAvance As DevComponents.DotNetBar.ButtonX
    Friend WithEvents sbPlanta As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporteAutorizacion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnExtraNO As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporteExtra As DevComponents.DotNetBar.ButtonX
    Friend WithEvents chkConfirmarOH As System.Windows.Forms.CheckBox
    Friend WithEvents ColumnNomSemReloj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colComp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnNomSemNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnNomSemTurno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnNomSemDepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnNomSemClase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnEstatus As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ColumnHrsNormales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnHrsExtra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnPrimaDom As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ColumnPrimaSab As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents ColumnVacPago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnDIAFIN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnSinPago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnConPago As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnConfirmacion As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColumnUsuarioFirma As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnFechaFirma As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnReloj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnTurno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnDepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnClase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnReporteExt As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents pnlAyuda As System.Windows.Forms.Panel
    Friend WithEvents picAyuda As System.Windows.Forms.PictureBox
    Friend WithEvents lblAyuda As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
End Class
