<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPruebaDinamico
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.EmpNav = New System.Windows.Forms.GroupBox()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrimero = New DevComponents.DotNetBar.ButtonX()
        Me.btnAnterior = New DevComponents.DotNetBar.ButtonX()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnSiguiente = New DevComponents.DotNetBar.ButtonX()
        Me.btnUltimo = New DevComponents.DotNetBar.ButtonX()
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.tabControl = New DevComponents.DotNetBar.SuperTabControl()
        Me.pnlDatos = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.panelIndividual = New System.Windows.Forms.FlowLayoutPanel()
        Me.tabPrograma = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgvTabla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.tabTabla = New DevComponents.DotNetBar.SuperTabItem()
        Me.campoTitulo = New System.Windows.Forms.Label()
        Me.campoBase = New System.Windows.Forms.TextBox()
        Me.comboTablasPorBase = New System.Windows.Forms.ComboBox()
        Me.botonActualizarTablas = New System.Windows.Forms.Button()
        Me.campoPassword = New System.Windows.Forms.TextBox()
        Me.campoUsuario = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgvInfoTabla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.campoHost = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.EmpNav.SuspendLayout()
        CType(Me.tabControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabControl.SuspendLayout()
        Me.pnlDatos.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.dgvTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInfoTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.EmpNav)
        Me.GroupBox1.Controls.Add(Me.tabControl)
        Me.GroupBox1.Controls.Add(Me.campoTitulo)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 208)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(694, 389)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Prueba"
        '
        'EmpNav
        '
        Me.EmpNav.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.EmpNav.Controls.Add(Me.btnCerrar)
        Me.EmpNav.Controls.Add(Me.btnPrimero)
        Me.EmpNav.Controls.Add(Me.btnAnterior)
        Me.EmpNav.Controls.Add(Me.btnBorrar)
        Me.EmpNav.Controls.Add(Me.btnSiguiente)
        Me.EmpNav.Controls.Add(Me.btnUltimo)
        Me.EmpNav.Controls.Add(Me.btnEditar)
        Me.EmpNav.Controls.Add(Me.btnNuevo)
        Me.EmpNav.Location = New System.Drawing.Point(11, 330)
        Me.EmpNav.Name = "EmpNav"
        Me.EmpNav.Size = New System.Drawing.Size(673, 47)
        Me.EmpNav.TabIndex = 92
        Me.EmpNav.TabStop = False
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.NET.My.Resources.Resources.Cerrar16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(586, 13)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 10
        Me.btnCerrar.Text = "Salir"
        '
        'btnPrimero
        '
        Me.btnPrimero.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrimero.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrimero.Image = Global.PIDA.NET.My.Resources.Resources.First16
        Me.btnPrimero.Location = New System.Drawing.Point(7, 13)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(78, 25)
        Me.btnPrimero.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrimero.TabIndex = 11
        Me.btnPrimero.Text = "Inicio"
        '
        'btnAnterior
        '
        Me.btnAnterior.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAnterior.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAnterior.Image = Global.PIDA.NET.My.Resources.Resources.Prev16
        Me.btnAnterior.Location = New System.Drawing.Point(88, 13)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(78, 25)
        Me.btnAnterior.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAnterior.TabIndex = 12
        Me.btnAnterior.Text = "Anterior"
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = Global.PIDA.NET.My.Resources.Resources.DeleteRec
        Me.btnBorrar.Location = New System.Drawing.Point(502, 13)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(78, 25)
        Me.btnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBorrar.TabIndex = 9
        Me.btnBorrar.Text = "Borrar"
        '
        'btnSiguiente
        '
        Me.btnSiguiente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSiguiente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSiguiente.Image = Global.PIDA.NET.My.Resources.Resources.Next16
        Me.btnSiguiente.Location = New System.Drawing.Point(169, 13)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(78, 25)
        Me.btnSiguiente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSiguiente.TabIndex = 13
        Me.btnSiguiente.Text = "Siguiente"
        '
        'btnUltimo
        '
        Me.btnUltimo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnUltimo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnUltimo.Image = Global.PIDA.NET.My.Resources.Resources.Last16
        Me.btnUltimo.Location = New System.Drawing.Point(250, 13)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(78, 25)
        Me.btnUltimo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnUltimo.TabIndex = 14
        Me.btnUltimo.Text = "Final"
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = Global.PIDA.NET.My.Resources.Resources.Edit
        Me.btnEditar.Location = New System.Drawing.Point(418, 13)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(78, 25)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 8
        Me.btnEditar.Text = "Editar"
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.NET.My.Resources.Resources.NewRecord
        Me.btnNuevo.Location = New System.Drawing.Point(334, 13)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 25)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 7
        Me.btnNuevo.Text = "Agregar"
        '
        'tabControl
        '
        Me.tabControl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        '
        '
        '
        Me.tabControl.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.tabControl.ControlBox.MenuBox.Name = ""
        Me.tabControl.ControlBox.MenuBox.Visible = False
        Me.tabControl.ControlBox.Name = ""
        Me.tabControl.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabControl.ControlBox.MenuBox, Me.tabControl.ControlBox.CloseBox})
        Me.tabControl.Controls.Add(Me.pnlDatos)
        Me.tabControl.Controls.Add(Me.SuperTabControlPanel2)
        Me.tabControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabControl.Location = New System.Drawing.Point(11, 45)
        Me.tabControl.Name = "tabControl"
        Me.tabControl.ReorderTabsEnabled = True
        Me.tabControl.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabControl.SelectedTabIndex = 0
        Me.tabControl.Size = New System.Drawing.Size(673, 279)
        Me.tabControl.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.tabControl.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabControl.TabIndex = 91
        Me.tabControl.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit
        Me.tabControl.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabPrograma, Me.tabTabla})
        Me.tabControl.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.Panel1)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(602, 279)
        Me.pnlDatos.TabIndex = 0
        Me.pnlDatos.TabItem = Me.tabPrograma
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.panelIndividual)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(602, 279)
        Me.Panel1.TabIndex = 0
        '
        'panelIndividual
        '
        Me.panelIndividual.AutoScroll = True
        Me.panelIndividual.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelIndividual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelIndividual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelIndividual.Location = New System.Drawing.Point(0, 0)
        Me.panelIndividual.Name = "panelIndividual"
        Me.panelIndividual.Size = New System.Drawing.Size(602, 279)
        Me.panelIndividual.TabIndex = 0
        '
        'tabPrograma
        '
        Me.tabPrograma.AttachedControl = Me.pnlDatos
        Me.tabPrograma.GlobalItem = False
        Me.tabPrograma.Name = "tabPrograma"
        Me.tabPrograma.Text = "Individual"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.dgvTabla)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(602, 279)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.tabTabla
        '
        'dgvTabla
        '
        Me.dgvTabla.AllowUserToAddRows = False
        Me.dgvTabla.AllowUserToDeleteRows = False
        Me.dgvTabla.AllowUserToOrderColumns = True
        Me.dgvTabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvTabla.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgvTabla.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTabla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTabla.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTabla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTabla.EnableHeadersVisualStyles = False
        Me.dgvTabla.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvTabla.Location = New System.Drawing.Point(0, 0)
        Me.dgvTabla.MultiSelect = False
        Me.dgvTabla.Name = "dgvTabla"
        Me.dgvTabla.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTabla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvTabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTabla.Size = New System.Drawing.Size(602, 279)
        Me.dgvTabla.TabIndex = 1
        '
        'tabTabla
        '
        Me.tabTabla.AttachedControl = Me.SuperTabControlPanel2
        Me.tabTabla.GlobalItem = False
        Me.tabTabla.Name = "tabTabla"
        Me.tabTabla.Text = "Tabla"
        '
        'campoTitulo
        '
        Me.campoTitulo.AutoSize = True
        Me.campoTitulo.Font = New System.Drawing.Font("Segoe UI Light", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.campoTitulo.Location = New System.Drawing.Point(6, 16)
        Me.campoTitulo.Name = "campoTitulo"
        Me.campoTitulo.Size = New System.Drawing.Size(57, 25)
        Me.campoTitulo.TabIndex = 0
        Me.campoTitulo.Tag = ""
        Me.campoTitulo.Text = "Titulo"
        '
        'campoBase
        '
        Me.campoBase.Location = New System.Drawing.Point(10, 142)
        Me.campoBase.Name = "campoBase"
        Me.campoBase.Size = New System.Drawing.Size(160, 20)
        Me.campoBase.TabIndex = 1
        '
        'comboTablasPorBase
        '
        Me.comboTablasPorBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboTablasPorBase.FormattingEnabled = True
        Me.comboTablasPorBase.Location = New System.Drawing.Point(10, 181)
        Me.comboTablasPorBase.Name = "comboTablasPorBase"
        Me.comboTablasPorBase.Size = New System.Drawing.Size(190, 21)
        Me.comboTablasPorBase.TabIndex = 2
        '
        'botonActualizarTablas
        '
        Me.botonActualizarTablas.Location = New System.Drawing.Point(176, 142)
        Me.botonActualizarTablas.Name = "botonActualizarTablas"
        Me.botonActualizarTablas.Size = New System.Drawing.Size(24, 20)
        Me.botonActualizarTablas.TabIndex = 3
        Me.botonActualizarTablas.Text = " "
        Me.botonActualizarTablas.UseVisualStyleBackColor = True
        '
        'campoPassword
        '
        Me.campoPassword.Location = New System.Drawing.Point(10, 64)
        Me.campoPassword.Name = "campoPassword"
        Me.campoPassword.Size = New System.Drawing.Size(190, 20)
        Me.campoPassword.TabIndex = 4
        '
        'campoUsuario
        '
        Me.campoUsuario.Location = New System.Drawing.Point(10, 25)
        Me.campoUsuario.Name = "campoUsuario"
        Me.campoUsuario.Size = New System.Drawing.Size(190, 20)
        Me.campoUsuario.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Usuario"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Base"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 165)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Tabla"
        '
        'dgvInfoTabla
        '
        Me.dgvInfoTabla.AllowUserToAddRows = False
        Me.dgvInfoTabla.AllowUserToDeleteRows = False
        Me.dgvInfoTabla.AllowUserToOrderColumns = True
        Me.dgvInfoTabla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgvInfoTabla.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dgvInfoTabla.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInfoTabla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvInfoTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInfoTabla.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvInfoTabla.EnableHeadersVisualStyles = False
        Me.dgvInfoTabla.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvInfoTabla.Location = New System.Drawing.Point(206, 24)
        Me.dgvInfoTabla.MultiSelect = False
        Me.dgvInfoTabla.Name = "dgvInfoTabla"
        Me.dgvInfoTabla.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInfoTabla.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvInfoTabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvInfoTabla.Size = New System.Drawing.Size(497, 178)
        Me.dgvInfoTabla.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Host"
        '
        'campoHost
        '
        Me.campoHost.Location = New System.Drawing.Point(10, 103)
        Me.campoHost.Name = "campoHost"
        Me.campoHost.Size = New System.Drawing.Size(190, 20)
        Me.campoHost.TabIndex = 11
        '
        'frmPruebaDinamico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 776)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.campoHost)
        Me.Controls.Add(Me.dgvInfoTabla)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.campoUsuario)
        Me.Controls.Add(Me.campoPassword)
        Me.Controls.Add(Me.botonActualizarTablas)
        Me.Controls.Add(Me.comboTablasPorBase)
        Me.Controls.Add(Me.campoBase)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmPruebaDinamico"
        Me.Text = "frmPruebaDinamico"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.EmpNav.ResumeLayout(False)
        CType(Me.tabControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabControl.ResumeLayout(False)
        Me.pnlDatos.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.dgvTabla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInfoTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents campoBase As System.Windows.Forms.TextBox
    Friend WithEvents comboTablasPorBase As System.Windows.Forms.ComboBox
    Friend WithEvents botonActualizarTablas As System.Windows.Forms.Button
    Friend WithEvents campoPassword As System.Windows.Forms.TextBox
    Friend WithEvents campoUsuario As System.Windows.Forms.TextBox
    Friend WithEvents campoTitulo As System.Windows.Forms.Label
    Friend WithEvents tabControl As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents pnlDatos As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tabPrograma As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents dgvTabla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents tabTabla As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents panelIndividual As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgvInfoTabla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents campoHost As System.Windows.Forms.TextBox
    Friend WithEvents EmpNav As System.Windows.Forms.GroupBox
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrimero As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAnterior As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSiguiente As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnUltimo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
End Class
