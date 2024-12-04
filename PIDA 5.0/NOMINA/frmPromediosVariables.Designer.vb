<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPromediosVariables
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnGenerarReportes = New DevComponents.DotNetBar.ButtonX()
        Me.btnAplicarCambios = New DevComponents.DotNetBar.ButtonX()
        Me.gpReportes = New System.Windows.Forms.GroupBox()
        Me.btnGuardarEstado = New DevComponents.DotNetBar.ButtonX()
        Me.btnGenerarExcel = New DevComponents.DotNetBar.ButtonX()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.employ = New System.Windows.Forms.TabPage()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.activos = New System.Windows.Forms.TabPage()
        Me.dgPromediosEnviar = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.finiquitosN = New System.Windows.Forms.TabPage()
        Me.dgPromediosNoEnviar = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.tabPeriodos = New System.Windows.Forms.TabControl()
        Me.Historical = New System.Windows.Forms.TabPage()
        Me.dgSemanasIncluidas = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgQuincenasIncluidas = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgHistorial = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.gpDatosPeriodo = New System.Windows.Forms.GroupBox()
        Me.cmbAnos = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.cmbBimestre = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.btnGenerarPromedio = New DevComponents.DotNetBar.ButtonX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tooltipBitacora = New DevComponents.DotNetBar.SuperTooltip()
        Me.ContextMenuStripGridNoEnviar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MandarAEnviarMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStripGridEnviar = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MandarANoEnviarMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox2.SuspendLayout()
        Me.gpReportes.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.employ.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.activos.SuspendLayout()
        CType(Me.dgPromediosEnviar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.finiquitosN.SuspendLayout()
        CType(Me.dgPromediosNoEnviar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPeriodos.SuspendLayout()
        Me.Historical.SuspendLayout()
        CType(Me.dgSemanasIncluidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgQuincenasIncluidas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgHistorial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpDatosPeriodo.SuspendLayout()
        Me.ContextMenuStripGridNoEnviar.SuspendLayout()
        Me.ContextMenuStripGridEnviar.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnGenerarReportes)
        Me.GroupBox2.Controls.Add(Me.btnAplicarCambios)
        Me.GroupBox2.Location = New System.Drawing.Point(43, 499)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(392, 170)
        Me.GroupBox2.TabIndex = 289
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Procesos"
        '
        'btnGenerarReportes
        '
        Me.btnGenerarReportes.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGenerarReportes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerarReportes.BackColor = System.Drawing.SystemColors.Control
        Me.btnGenerarReportes.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGenerarReportes.Enabled = False
        Me.btnGenerarReportes.Image = Global.PIDA.My.Resources.Resources.MtroDed32
        Me.btnGenerarReportes.ImageFixedSize = New System.Drawing.Size(15, 15)
        Me.btnGenerarReportes.ImageTextSpacing = 5
        Me.btnGenerarReportes.Location = New System.Drawing.Point(40, 40)
        Me.btnGenerarReportes.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGenerarReportes.Name = "btnGenerarReportes"
        Me.btnGenerarReportes.Size = New System.Drawing.Size(321, 34)
        Me.btnGenerarReportes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGenerarReportes.TabIndex = 275
        Me.btnGenerarReportes.Text = "Generar Reportes"
        Me.btnGenerarReportes.Tooltip = "Genera los reportes de cambio de sueldo"
        '
        'btnAplicarCambios
        '
        Me.btnAplicarCambios.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAplicarCambios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAplicarCambios.BackColor = System.Drawing.SystemColors.Control
        Me.btnAplicarCambios.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAplicarCambios.Enabled = False
        Me.btnAplicarCambios.Image = Global.PIDA.My.Resources.Resources.incidencias
        Me.btnAplicarCambios.ImageFixedSize = New System.Drawing.Size(15, 15)
        Me.btnAplicarCambios.ImageTextSpacing = 5
        Me.btnAplicarCambios.Location = New System.Drawing.Point(40, 104)
        Me.btnAplicarCambios.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAplicarCambios.Name = "btnAplicarCambios"
        Me.btnAplicarCambios.Size = New System.Drawing.Size(321, 34)
        Me.btnAplicarCambios.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAplicarCambios.TabIndex = 259
        Me.btnAplicarCambios.Text = "APLICAR CAMBIOS"
        Me.btnAplicarCambios.Tooltip = "Aplica los cambios de sueldo. Esta acción es irreversible!!."
        '
        'gpReportes
        '
        Me.gpReportes.Controls.Add(Me.btnGuardarEstado)
        Me.gpReportes.Controls.Add(Me.btnGenerarExcel)
        Me.gpReportes.Location = New System.Drawing.Point(778, 35)
        Me.gpReportes.Margin = New System.Windows.Forms.Padding(4)
        Me.gpReportes.Name = "gpReportes"
        Me.gpReportes.Padding = New System.Windows.Forms.Padding(4)
        Me.gpReportes.Size = New System.Drawing.Size(554, 92)
        Me.gpReportes.TabIndex = 288
        Me.gpReportes.TabStop = False
        Me.gpReportes.Text = "Herramientas"
        '
        'btnGuardarEstado
        '
        Me.btnGuardarEstado.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGuardarEstado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardarEstado.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGuardarEstado.Enabled = False
        Me.btnGuardarEstado.Image = Global.PIDA.My.Resources.Resources.Actualizar48
        Me.btnGuardarEstado.ImageFixedSize = New System.Drawing.Size(15, 15)
        Me.btnGuardarEstado.ImageTextSpacing = 5
        Me.btnGuardarEstado.Location = New System.Drawing.Point(28, 29)
        Me.btnGuardarEstado.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGuardarEstado.Name = "btnGuardarEstado"
        Me.btnGuardarEstado.Size = New System.Drawing.Size(214, 31)
        Me.btnGuardarEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGuardarEstado.TabIndex = 258
        Me.btnGuardarEstado.Text = "Guardar Calculos"
        Me.btnGuardarEstado.Tooltip = "Guarda el estado actual de los datos"
        '
        'btnGenerarExcel
        '
        Me.btnGenerarExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGenerarExcel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerarExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGenerarExcel.Enabled = False
        Me.btnGenerarExcel.Image = Global.PIDA.My.Resources.Resources._1469760469_kmenuedit
        Me.btnGenerarExcel.ImageFixedSize = New System.Drawing.Size(15, 15)
        Me.btnGenerarExcel.ImageTextSpacing = 5
        Me.btnGenerarExcel.Location = New System.Drawing.Point(307, 29)
        Me.btnGenerarExcel.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGenerarExcel.Name = "btnGenerarExcel"
        Me.btnGenerarExcel.Size = New System.Drawing.Size(214, 31)
        Me.btnGenerarExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGenerarExcel.TabIndex = 257
        Me.btnGenerarExcel.Text = "Exportar a Excel"
        Me.btnGenerarExcel.Tooltip = "Se generan un vez realizado el cálculo"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.employ)
        Me.TabControl1.Location = New System.Drawing.Point(475, 148)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1318, 705)
        Me.TabControl1.TabIndex = 287
        '
        'employ
        '
        Me.employ.Controls.Add(Me.TabControl2)
        Me.employ.Location = New System.Drawing.Point(4, 25)
        Me.employ.Margin = New System.Windows.Forms.Padding(4)
        Me.employ.Name = "employ"
        Me.employ.Padding = New System.Windows.Forms.Padding(4)
        Me.employ.Size = New System.Drawing.Size(1310, 676)
        Me.employ.TabIndex = 0
        Me.employ.Text = "Promedios"
        Me.employ.UseVisualStyleBackColor = True
        '
        'TabControl2
        '
        Me.TabControl2.Alignment = System.Windows.Forms.TabAlignment.Right
        Me.TabControl2.Controls.Add(Me.activos)
        Me.TabControl2.Controls.Add(Me.finiquitosN)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.Location = New System.Drawing.Point(4, 4)
        Me.TabControl2.Margin = New System.Windows.Forms.Padding(4)
        Me.TabControl2.Multiline = True
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(1302, 668)
        Me.TabControl2.TabIndex = 0
        '
        'activos
        '
        Me.activos.Controls.Add(Me.dgPromediosEnviar)
        Me.activos.Location = New System.Drawing.Point(4, 4)
        Me.activos.Margin = New System.Windows.Forms.Padding(4)
        Me.activos.Name = "activos"
        Me.activos.Padding = New System.Windows.Forms.Padding(4)
        Me.activos.Size = New System.Drawing.Size(1273, 660)
        Me.activos.TabIndex = 0
        Me.activos.Text = "Enviar Integrado"
        Me.activos.UseVisualStyleBackColor = True
        '
        'dgPromediosEnviar
        '
        Me.dgPromediosEnviar.AllowUserToAddRows = False
        Me.dgPromediosEnviar.AllowUserToDeleteRows = False
        Me.dgPromediosEnviar.AllowUserToResizeRows = False
        Me.dgPromediosEnviar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPromediosEnviar.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgPromediosEnviar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPromediosEnviar.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgPromediosEnviar.EnableHeadersVisualStyles = False
        Me.dgPromediosEnviar.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgPromediosEnviar.Location = New System.Drawing.Point(4, 4)
        Me.dgPromediosEnviar.Margin = New System.Windows.Forms.Padding(4)
        Me.dgPromediosEnviar.MultiSelect = False
        Me.dgPromediosEnviar.Name = "dgPromediosEnviar"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgPromediosEnviar.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgPromediosEnviar.RowHeadersVisible = False
        Me.dgPromediosEnviar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgPromediosEnviar.Size = New System.Drawing.Size(1265, 652)
        Me.dgPromediosEnviar.TabIndex = 2
        '
        'finiquitosN
        '
        Me.finiquitosN.Controls.Add(Me.dgPromediosNoEnviar)
        Me.finiquitosN.Location = New System.Drawing.Point(4, 4)
        Me.finiquitosN.Margin = New System.Windows.Forms.Padding(4)
        Me.finiquitosN.Name = "finiquitosN"
        Me.finiquitosN.Padding = New System.Windows.Forms.Padding(4)
        Me.finiquitosN.Size = New System.Drawing.Size(1273, 660)
        Me.finiquitosN.TabIndex = 1
        Me.finiquitosN.Text = "No Enviar Integrados"
        Me.finiquitosN.UseVisualStyleBackColor = True
        '
        'dgPromediosNoEnviar
        '
        Me.dgPromediosNoEnviar.AllowUserToAddRows = False
        Me.dgPromediosNoEnviar.AllowUserToDeleteRows = False
        Me.dgPromediosNoEnviar.AllowUserToOrderColumns = True
        Me.dgPromediosNoEnviar.AllowUserToResizeRows = False
        Me.dgPromediosNoEnviar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgPromediosNoEnviar.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgPromediosNoEnviar.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgPromediosNoEnviar.Location = New System.Drawing.Point(4, 4)
        Me.dgPromediosNoEnviar.Name = "dgPromediosNoEnviar"
        Me.dgPromediosNoEnviar.Size = New System.Drawing.Size(1265, 652)
        Me.dgPromediosNoEnviar.TabIndex = 0
        '
        'tabPeriodos
        '
        Me.tabPeriodos.Controls.Add(Me.Historical)
        Me.tabPeriodos.Controls.Add(Me.TabPage1)
        Me.tabPeriodos.Controls.Add(Me.TabPage2)
        Me.tabPeriodos.Location = New System.Drawing.Point(16, 148)
        Me.tabPeriodos.Margin = New System.Windows.Forms.Padding(4)
        Me.tabPeriodos.Name = "tabPeriodos"
        Me.tabPeriodos.SelectedIndex = 0
        Me.tabPeriodos.Size = New System.Drawing.Size(451, 299)
        Me.tabPeriodos.TabIndex = 286
        '
        'Historical
        '
        Me.Historical.Controls.Add(Me.dgSemanasIncluidas)
        Me.Historical.Location = New System.Drawing.Point(4, 25)
        Me.Historical.Margin = New System.Windows.Forms.Padding(4)
        Me.Historical.Name = "Historical"
        Me.Historical.Padding = New System.Windows.Forms.Padding(4)
        Me.Historical.Size = New System.Drawing.Size(443, 270)
        Me.Historical.TabIndex = 1
        Me.Historical.Text = "Semanas"
        Me.Historical.UseVisualStyleBackColor = True
        '
        'dgSemanasIncluidas
        '
        Me.dgSemanasIncluidas.AllowUserToAddRows = False
        Me.dgSemanasIncluidas.AllowUserToDeleteRows = False
        Me.dgSemanasIncluidas.AllowUserToResizeRows = False
        Me.dgSemanasIncluidas.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSemanasIncluidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSemanasIncluidas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgSemanasIncluidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSemanasIncluidas.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgSemanasIncluidas.EnableHeadersVisualStyles = False
        Me.dgSemanasIncluidas.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgSemanasIncluidas.Location = New System.Drawing.Point(4, 4)
        Me.dgSemanasIncluidas.Margin = New System.Windows.Forms.Padding(4)
        Me.dgSemanasIncluidas.MultiSelect = False
        Me.dgSemanasIncluidas.Name = "dgSemanasIncluidas"
        Me.dgSemanasIncluidas.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSemanasIncluidas.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgSemanasIncluidas.RowHeadersVisible = False
        Me.dgSemanasIncluidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSemanasIncluidas.ShowCellToolTips = False
        Me.dgSemanasIncluidas.Size = New System.Drawing.Size(439, 262)
        Me.dgSemanasIncluidas.TabIndex = 9
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgQuincenasIncluidas)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(443, 270)
        Me.TabPage1.TabIndex = 2
        Me.TabPage1.Text = "Quincenas"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgQuincenasIncluidas
        '
        Me.dgQuincenasIncluidas.AllowUserToAddRows = False
        Me.dgQuincenasIncluidas.AllowUserToDeleteRows = False
        Me.dgQuincenasIncluidas.AllowUserToResizeRows = False
        Me.dgQuincenasIncluidas.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgQuincenasIncluidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgQuincenasIncluidas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgQuincenasIncluidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgQuincenasIncluidas.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgQuincenasIncluidas.EnableHeadersVisualStyles = False
        Me.dgQuincenasIncluidas.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgQuincenasIncluidas.Location = New System.Drawing.Point(3, 3)
        Me.dgQuincenasIncluidas.Margin = New System.Windows.Forms.Padding(4)
        Me.dgQuincenasIncluidas.MultiSelect = False
        Me.dgQuincenasIncluidas.Name = "dgQuincenasIncluidas"
        Me.dgQuincenasIncluidas.ReadOnly = True
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgQuincenasIncluidas.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgQuincenasIncluidas.RowHeadersVisible = False
        Me.dgQuincenasIncluidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgQuincenasIncluidas.ShowCellToolTips = False
        Me.dgQuincenasIncluidas.Size = New System.Drawing.Size(436, 267)
        Me.dgQuincenasIncluidas.TabIndex = 10
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgHistorial)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(443, 270)
        Me.TabPage2.TabIndex = 3
        Me.TabPage2.Text = "Calculos Guardados"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgHistorial
        '
        Me.dgHistorial.AllowUserToAddRows = False
        Me.dgHistorial.AllowUserToDeleteRows = False
        Me.dgHistorial.AllowUserToResizeRows = False
        Me.dgHistorial.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgHistorial.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgHistorial.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgHistorial.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgHistorial.EnableHeadersVisualStyles = False
        Me.dgHistorial.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgHistorial.Location = New System.Drawing.Point(2, 4)
        Me.dgHistorial.Margin = New System.Windows.Forms.Padding(4)
        Me.dgHistorial.MultiSelect = False
        Me.dgHistorial.Name = "dgHistorial"
        Me.dgHistorial.ReadOnly = True
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgHistorial.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgHistorial.RowHeadersVisible = False
        Me.dgHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgHistorial.ShowCellToolTips = False
        Me.dgHistorial.Size = New System.Drawing.Size(439, 262)
        Me.dgHistorial.TabIndex = 10
        '
        'gpDatosPeriodo
        '
        Me.gpDatosPeriodo.Controls.Add(Me.cmbAnos)
        Me.gpDatosPeriodo.Controls.Add(Me.cmbBimestre)
        Me.gpDatosPeriodo.Controls.Add(Me.btnGenerarPromedio)
        Me.gpDatosPeriodo.Controls.Add(Me.Label2)
        Me.gpDatosPeriodo.Controls.Add(Me.Label3)
        Me.gpDatosPeriodo.Location = New System.Drawing.Point(24, 13)
        Me.gpDatosPeriodo.Margin = New System.Windows.Forms.Padding(4)
        Me.gpDatosPeriodo.Name = "gpDatosPeriodo"
        Me.gpDatosPeriodo.Padding = New System.Windows.Forms.Padding(4)
        Me.gpDatosPeriodo.Size = New System.Drawing.Size(732, 116)
        Me.gpDatosPeriodo.TabIndex = 285
        Me.gpDatosPeriodo.TabStop = False
        Me.gpDatosPeriodo.Text = "Datos de periodo"
        '
        'cmbAnos
        '
        Me.cmbAnos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbAnos.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbAnos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbAnos.ButtonDropDown.Visible = True
        Me.cmbAnos.KeyboardSearchNoSelectionAllowed = False
        Me.cmbAnos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbAnos.Location = New System.Drawing.Point(19, 43)
        Me.cmbAnos.Name = "cmbAnos"
        Me.cmbAnos.Size = New System.Drawing.Size(224, 27)
        Me.cmbAnos.TabIndex = 102
        '
        'cmbBimestre
        '
        Me.cmbBimestre.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbBimestre.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbBimestre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbBimestre.ButtonDropDown.Visible = True
        Me.cmbBimestre.KeyboardSearchNoSelectionAllowed = False
        Me.cmbBimestre.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbBimestre.Location = New System.Drawing.Point(264, 43)
        Me.cmbBimestre.Name = "cmbBimestre"
        Me.cmbBimestre.Size = New System.Drawing.Size(224, 27)
        Me.cmbBimestre.TabIndex = 103
        '
        'btnGenerarPromedio
        '
        Me.btnGenerarPromedio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGenerarPromedio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGenerarPromedio.Location = New System.Drawing.Point(532, 34)
        Me.btnGenerarPromedio.Name = "btnGenerarPromedio"
        Me.btnGenerarPromedio.Size = New System.Drawing.Size(169, 45)
        Me.btnGenerarPromedio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGenerarPromedio.TabIndex = 0
        Me.btnGenerarPromedio.Text = "Cargar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 22)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 18)
        Me.Label2.TabIndex = 249
        Me.Label2.Text = "Año:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(261, 22)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 18)
        Me.Label3.TabIndex = 250
        Me.Label3.Text = "Bimestre:"
        '
        'tooltipBitacora
        '
        Me.tooltipBitacora.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray)
        Me.tooltipBitacora.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.tooltipBitacora.TooltipDuration = 2
        '
        'ContextMenuStripGridNoEnviar
        '
        Me.ContextMenuStripGridNoEnviar.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStripGridNoEnviar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MandarAEnviarMenuItem})
        Me.ContextMenuStripGridNoEnviar.Name = "ContextMenuStripGridNoEnviar"
        Me.ContextMenuStripGridNoEnviar.Size = New System.Drawing.Size(188, 28)
        '
        'MandarAEnviarMenuItem
        '
        Me.MandarAEnviarMenuItem.Name = "MandarAEnviarMenuItem"
        Me.MandarAEnviarMenuItem.Size = New System.Drawing.Size(187, 24)
        Me.MandarAEnviarMenuItem.Text = "Mandar A Enviar"
        '
        'ContextMenuStripGridEnviar
        '
        Me.ContextMenuStripGridEnviar.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStripGridEnviar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MandarANoEnviarMenuItem})
        Me.ContextMenuStripGridEnviar.Name = "ContextMenuStripGridEnviar"
        Me.ContextMenuStripGridEnviar.Size = New System.Drawing.Size(210, 56)
        '
        'MandarANoEnviarMenuItem
        '
        Me.MandarANoEnviarMenuItem.Name = "MandarANoEnviarMenuItem"
        Me.MandarANoEnviarMenuItem.Size = New System.Drawing.Size(209, 24)
        Me.MandarANoEnviarMenuItem.Text = "Mandar a No Enviar"
        '
        'frmPromediosVariables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1809, 866)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gpReportes)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.tabPeriodos)
        Me.Controls.Add(Me.gpDatosPeriodo)
        Me.Name = "frmPromediosVariables"
        Me.Text = "frmPromediosVariables"
        Me.GroupBox2.ResumeLayout(False)
        Me.gpReportes.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.employ.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.activos.ResumeLayout(False)
        CType(Me.dgPromediosEnviar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.finiquitosN.ResumeLayout(False)
        CType(Me.dgPromediosNoEnviar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPeriodos.ResumeLayout(False)
        Me.Historical.ResumeLayout(False)
        CType(Me.dgSemanasIncluidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgQuincenasIncluidas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgHistorial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpDatosPeriodo.ResumeLayout(False)
        Me.gpDatosPeriodo.PerformLayout()
        Me.ContextMenuStripGridNoEnviar.ResumeLayout(False)
        Me.ContextMenuStripGridEnviar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnGenerarReportes As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAplicarCambios As DevComponents.DotNetBar.ButtonX
    Friend WithEvents gpReportes As System.Windows.Forms.GroupBox
    Friend WithEvents btnGuardarEstado As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnGenerarExcel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents employ As System.Windows.Forms.TabPage
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents activos As System.Windows.Forms.TabPage
    Friend WithEvents dgPromediosEnviar As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents finiquitosN As System.Windows.Forms.TabPage
    Friend WithEvents dgPromediosNoEnviar As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents tabPeriodos As System.Windows.Forms.TabControl
    Friend WithEvents Historical As System.Windows.Forms.TabPage
    Friend WithEvents dgSemanasIncluidas As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgQuincenasIncluidas As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgHistorial As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents gpDatosPeriodo As System.Windows.Forms.GroupBox
    Friend WithEvents cmbAnos As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cmbBimestre As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents btnGenerarPromedio As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tooltipBitacora As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents ContextMenuStripGridNoEnviar As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MandarAEnviarMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStripGridEnviar As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MandarANoEnviarMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
