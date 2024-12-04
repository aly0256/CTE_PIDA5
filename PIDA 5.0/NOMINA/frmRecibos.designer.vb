<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecibos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecibos))
        Me.tabBuscar = New DevComponents.DotNetBar.SuperTabControl()
        Me.pnlDatos = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.trSeleccion = New DevComponents.AdvTree.AdvTree()
        Me.ElementStyle6 = New DevComponents.DotNetBar.ElementStyle()
        Me.Node2 = New DevComponents.AdvTree.Node()
        Me.Node4 = New DevComponents.AdvTree.Node()
        Me.Node3 = New DevComponents.AdvTree.Node()
        Me.Cell1 = New DevComponents.AdvTree.Cell()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader6 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader7 = New DevComponents.AdvTree.ColumnHeader()
        Me.Node5 = New DevComponents.AdvTree.Node()
        Me.Node7 = New DevComponents.AdvTree.Node()
        Me.Node9 = New DevComponents.AdvTree.Node()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle7 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle8 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle9 = New DevComponents.DotNetBar.ElementStyle()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.chkMandarCorreos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkExpandir = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkSeleccionar = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.tabSeleccion = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.txtReloj = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabEmpleado = New DevComponents.DotNetBar.SuperTabItem()
        Me.chkSeleccion = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.pnlDatosRecibos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.txtCorreoPrueba = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkTipoPerCat = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkTipoPerSem = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbCia = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.colCodComp = New DevComponents.AdvTree.ColumnHeader()
        Me.colNombre = New DevComponents.AdvTree.ColumnHeader()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtComentario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.intFolio = New DevComponents.Editors.IntegerInput()
        Me.cmbPeriodos = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.colSeleccionado = New DevComponents.AdvTree.ColumnHeader()
        Me.colAno = New DevComponents.AdvTree.ColumnHeader()
        Me.colPeriodo = New DevComponents.AdvTree.ColumnHeader()
        Me.colFechaIni = New DevComponents.AdvTree.ColumnHeader()
        Me.colFechaFin = New DevComponents.AdvTree.ColumnHeader()
        Me.Node1 = New DevComponents.AdvTree.Node()
        Me.cmbImpresoras = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ElementStyle2 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle4 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle3 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle5 = New DevComponents.DotNetBar.ElementStyle()
        Me.EmpNav = New System.Windows.Forms.GroupBox()
        Me.pbCarga = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnBuscarEmp = New DevComponents.DotNetBar.ButtonX()
        Me.btnVistaPrevia = New DevComponents.DotNetBar.ButtonX()
        Me.btnSalir = New DevComponents.DotNetBar.ButtonX()
        Me.btnImprimir = New DevComponents.DotNetBar.ButtonX()
        Me.dlgArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CheckBoxX1 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.CheckBoxX2 = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Node6 = New DevComponents.AdvTree.Node()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBuscar.SuspendLayout()
        Me.pnlDatos.SuspendLayout()
        CType(Me.trSeleccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        Me.pnlDatosRecibos.SuspendLayout()
        CType(Me.intFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EmpNav.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEncabezado.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
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
        Me.tabBuscar.Controls.Add(Me.pnlDatos)
        Me.tabBuscar.Controls.Add(Me.SuperTabControlPanel2)
        Me.tabBuscar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.Location = New System.Drawing.Point(554, 52)
        Me.tabBuscar.Name = "tabBuscar"
        Me.tabBuscar.ReorderTabsEnabled = True
        Me.tabBuscar.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabBuscar.SelectedTabIndex = 0
        Me.tabBuscar.Size = New System.Drawing.Size(618, 240)
        Me.tabBuscar.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Left
        Me.tabBuscar.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.TabIndex = 86
        Me.tabBuscar.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.MultiLineFit
        Me.tabBuscar.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabSeleccion, Me.tabEmpleado})
        Me.tabBuscar.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.trSeleccion)
        Me.pnlDatos.Controls.Add(Me.Panel4)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(97, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(521, 240)
        Me.pnlDatos.TabIndex = 0
        Me.pnlDatos.TabItem = Me.tabSeleccion
        '
        'trSeleccion
        '
        Me.trSeleccion.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.trSeleccion.AllowDrop = True
        Me.trSeleccion.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.trSeleccion.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Etched
        Me.trSeleccion.BackgroundStyle.Class = "TreeBorderKey"
        Me.trSeleccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.trSeleccion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trSeleccion.DragDropEnabled = False
        Me.trSeleccion.ExpandButtonType = DevComponents.AdvTree.eExpandButtonType.Triangle
        Me.trSeleccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.trSeleccion.GroupNodeStyle = Me.ElementStyle6
        Me.trSeleccion.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.trSeleccion.Location = New System.Drawing.Point(0, 32)
        Me.trSeleccion.MultiNodeDragDropAllowed = False
        Me.trSeleccion.Name = "trSeleccion"
        Me.trSeleccion.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node2, Me.Node5, Me.Node9})
        Me.trSeleccion.NodesConnector = Me.NodeConnector1
        Me.trSeleccion.NodeSpacing = 5
        Me.trSeleccion.NodeStyle = Me.ElementStyle6
        Me.trSeleccion.PathSeparator = ";"
        Me.trSeleccion.Size = New System.Drawing.Size(521, 208)
        Me.trSeleccion.Styles.Add(Me.ElementStyle6)
        Me.trSeleccion.Styles.Add(Me.ElementStyle7)
        Me.trSeleccion.Styles.Add(Me.ElementStyle8)
        Me.trSeleccion.Styles.Add(Me.ElementStyle9)
        Me.trSeleccion.TabIndex = 8
        '
        'ElementStyle6
        '
        Me.ElementStyle6.BackColor2 = System.Drawing.SystemColors.Highlight
        Me.ElementStyle6.BackColorGradientAngle = 90
        Me.ElementStyle6.BorderBottomWidth = 1
        Me.ElementStyle6.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle6.BorderLeftWidth = 1
        Me.ElementStyle6.BorderRightWidth = 1
        Me.ElementStyle6.BorderTopWidth = 1
        Me.ElementStyle6.CornerDiameter = 4
        Me.ElementStyle6.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle6.Description = "Regular"
        Me.ElementStyle6.Name = "ElementStyle6"
        Me.ElementStyle6.PaddingBottom = 1
        Me.ElementStyle6.PaddingLeft = 1
        Me.ElementStyle6.PaddingRight = 1
        Me.ElementStyle6.PaddingTop = 1
        Me.ElementStyle6.TextColor = System.Drawing.Color.Black
        '
        'Node2
        '
        Me.Node2.CheckBoxVisible = True
        Me.Node2.Checked = True
        Me.Node2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Node2.Editable = False
        Me.Node2.Name = "Node2"
        Me.Node2.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node4})
        Me.Node2.Text = "Node2"
        '
        'Node4
        '
        Me.Node4.Expanded = True
        Me.Node4.Name = "Node4"
        Me.Node4.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node3})
        Me.Node4.NodesColumns.Add(Me.ColumnHeader1)
        Me.Node4.NodesColumns.Add(Me.ColumnHeader5)
        Me.Node4.NodesColumns.Add(Me.ColumnHeader6)
        Me.Node4.NodesColumns.Add(Me.ColumnHeader7)
        Me.Node4.Text = "Node4"
        '
        'Node3
        '
        Me.Node3.Cells.Add(Me.Cell1)
        Me.Node3.Expanded = True
        Me.Node3.ExpandVisibility = DevComponents.AdvTree.eNodeExpandVisibility.Hidden
        Me.Node3.Name = "Node3"
        Me.Node3.Text = "Node3"
        '
        'Cell1
        '
        Me.Cell1.Name = "Cell1"
        Me.Cell1.StyleMouseOver = Nothing
        Me.Cell1.Text = "FFF"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Per."
        Me.ColumnHeader1.Width.Absolute = 25
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.Text = "Ded."
        Me.ColumnHeader5.Width.Absolute = 25
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Name = "ColumnHeader6"
        Me.ColumnHeader6.Text = "Neto"
        Me.ColumnHeader6.Width.Absolute = 25
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Name = "ColumnHeader7"
        Me.ColumnHeader7.Text = "# Rec."
        Me.ColumnHeader7.Width.Absolute = 20
        '
        'Node5
        '
        Me.Node5.Name = "Node5"
        Me.Node5.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node7})
        Me.Node5.Text = "Node5"
        '
        'Node7
        '
        Me.Node7.Expanded = True
        Me.Node7.Name = "Node7"
        Me.Node7.Text = "Node7"
        '
        'Node9
        '
        Me.Node9.Expanded = True
        Me.Node9.Name = "Node9"
        Me.Node9.Text = "Node9"
        '
        'ElementStyle7
        '
        Me.ElementStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ElementStyle7.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ElementStyle7.BackColorGradientAngle = 90
        Me.ElementStyle7.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle7.BorderBottomWidth = 1
        Me.ElementStyle7.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle7.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle7.BorderLeftWidth = 1
        Me.ElementStyle7.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle7.BorderRightWidth = 1
        Me.ElementStyle7.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle7.BorderTopWidth = 1
        Me.ElementStyle7.CornerDiameter = 4
        Me.ElementStyle7.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle7.Description = "Blue"
        Me.ElementStyle7.Name = "ElementStyle7"
        Me.ElementStyle7.PaddingBottom = 1
        Me.ElementStyle7.PaddingLeft = 1
        Me.ElementStyle7.PaddingRight = 1
        Me.ElementStyle7.PaddingTop = 1
        Me.ElementStyle7.TextColor = System.Drawing.Color.Black
        '
        'ElementStyle8
        '
        Me.ElementStyle8.BackColor = System.Drawing.SystemColors.Window
        Me.ElementStyle8.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ElementStyle8.BackColorGradientAngle = 90
        Me.ElementStyle8.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle8.BorderBottomWidth = 1
        Me.ElementStyle8.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle8.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle8.BorderLeftWidth = 1
        Me.ElementStyle8.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle8.BorderRightWidth = 1
        Me.ElementStyle8.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle8.BorderTopWidth = 1
        Me.ElementStyle8.CornerDiameter = 4
        Me.ElementStyle8.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle8.Description = "Gray"
        Me.ElementStyle8.Name = "ElementStyle8"
        Me.ElementStyle8.PaddingBottom = 1
        Me.ElementStyle8.PaddingLeft = 1
        Me.ElementStyle8.PaddingRight = 1
        Me.ElementStyle8.PaddingTop = 1
        Me.ElementStyle8.TextColor = System.Drawing.Color.Black
        '
        'ElementStyle9
        '
        Me.ElementStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ElementStyle9.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ElementStyle9.BackColorGradientAngle = 90
        Me.ElementStyle9.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle9.BorderBottomWidth = 1
        Me.ElementStyle9.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle9.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle9.BorderLeftWidth = 1
        Me.ElementStyle9.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle9.BorderRightWidth = 1
        Me.ElementStyle9.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle9.BorderTopWidth = 1
        Me.ElementStyle9.CornerDiameter = 4
        Me.ElementStyle9.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle9.Description = "Blue"
        Me.ElementStyle9.Name = "ElementStyle9"
        Me.ElementStyle9.PaddingBottom = 1
        Me.ElementStyle9.PaddingLeft = 1
        Me.ElementStyle9.PaddingRight = 1
        Me.ElementStyle9.PaddingTop = 1
        Me.ElementStyle9.TextColor = System.Drawing.Color.Black
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.Window
        Me.Panel4.Controls.Add(Me.chkMandarCorreos)
        Me.Panel4.Controls.Add(Me.chkExpandir)
        Me.Panel4.Controls.Add(Me.chkSeleccionar)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(521, 32)
        Me.Panel4.TabIndex = 11
        '
        'chkMandarCorreos
        '
        Me.chkMandarCorreos.AutoSize = True
        Me.chkMandarCorreos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkMandarCorreos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkMandarCorreos.CheckSignSize = New System.Drawing.Size(15, 15)
        Me.chkMandarCorreos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMandarCorreos.Location = New System.Drawing.Point(388, 9)
        Me.chkMandarCorreos.Name = "chkMandarCorreos"
        Me.chkMandarCorreos.Size = New System.Drawing.Size(108, 17)
        Me.chkMandarCorreos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkMandarCorreos.TabIndex = 11
        Me.chkMandarCorreos.Text = "Mandar correos"
        '
        'chkExpandir
        '
        Me.chkExpandir.AutoSize = True
        Me.chkExpandir.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkExpandir.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkExpandir.CheckSignSize = New System.Drawing.Size(15, 15)
        Me.chkExpandir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkExpandir.Location = New System.Drawing.Point(3, 8)
        Me.chkExpandir.Name = "chkExpandir"
        Me.chkExpandir.Size = New System.Drawing.Size(104, 17)
        Me.chkExpandir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkExpandir.TabIndex = 9
        Me.chkExpandir.Text = "Expandir todos"
        '
        'chkSeleccionar
        '
        Me.chkSeleccionar.AutoSize = True
        Me.chkSeleccionar.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkSeleccionar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkSeleccionar.Checked = True
        Me.chkSeleccionar.CheckSignSize = New System.Drawing.Size(15, 15)
        Me.chkSeleccionar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSeleccionar.CheckValue = "Y"
        Me.chkSeleccionar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSeleccionar.Location = New System.Drawing.Point(151, 8)
        Me.chkSeleccionar.Name = "chkSeleccionar"
        Me.chkSeleccionar.Size = New System.Drawing.Size(120, 17)
        Me.chkSeleccionar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkSeleccionar.TabIndex = 10
        Me.chkSeleccionar.Text = "Seleccionar todos"
        '
        'tabSeleccion
        '
        Me.tabSeleccion.AttachedControl = Me.pnlDatos
        Me.tabSeleccion.GlobalItem = False
        Me.tabSeleccion.Name = "tabSeleccion"
        Me.tabSeleccion.Text = "Por selección"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.txtReloj)
        Me.SuperTabControlPanel2.Controls.Add(Me.Label1)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(95, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(523, 240)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.tabEmpleado
        '
        'txtReloj
        '
        Me.txtReloj.Enabled = False
        Me.txtReloj.Location = New System.Drawing.Point(64, 11)
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.Size = New System.Drawing.Size(100, 21)
        Me.txtReloj.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Location = New System.Drawing.Point(22, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Reloj"
        '
        'tabEmpleado
        '
        Me.tabEmpleado.AttachedControl = Me.SuperTabControlPanel2
        Me.tabEmpleado.GlobalItem = False
        Me.tabEmpleado.Name = "tabEmpleado"
        Me.tabEmpleado.Text = "Por empleado"
        '
        'chkSeleccion
        '
        Me.chkSeleccion.AutoSize = True
        Me.chkSeleccion.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkSeleccion.BackgroundStyle.BorderBottomWidth = 1
        Me.chkSeleccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkSeleccion.Checked = True
        Me.chkSeleccion.CheckSignSize = New System.Drawing.Size(15, 15)
        Me.chkSeleccion.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSeleccion.CheckValue = "Y"
        Me.chkSeleccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSeleccion.Location = New System.Drawing.Point(0, 7)
        Me.chkSeleccion.Name = "chkSeleccion"
        Me.chkSeleccion.Size = New System.Drawing.Size(120, 17)
        Me.chkSeleccion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkSeleccion.TabIndex = 11
        Me.chkSeleccion.Text = "Seleccionar todos"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(40, 0)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(407, 40)
        Me.ReflectionLabel1.TabIndex = 84
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>IMPRESIÓN DE RECIBOS</b></font>"
        '
        'pnlDatosRecibos
        '
        Me.pnlDatosRecibos.CanvasColor = System.Drawing.SystemColors.Control
        Me.pnlDatosRecibos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pnlDatosRecibos.Controls.Add(Me.txtCorreoPrueba)
        Me.pnlDatosRecibos.Controls.Add(Me.Label8)
        Me.pnlDatosRecibos.Controls.Add(Me.chkTipoPerCat)
        Me.pnlDatosRecibos.Controls.Add(Me.chkTipoPerSem)
        Me.pnlDatosRecibos.Controls.Add(Me.Label7)
        Me.pnlDatosRecibos.Controls.Add(Me.cmbCia)
        Me.pnlDatosRecibos.Controls.Add(Me.Label6)
        Me.pnlDatosRecibos.Controls.Add(Me.txtComentario)
        Me.pnlDatosRecibos.Controls.Add(Me.Label5)
        Me.pnlDatosRecibos.Controls.Add(Me.Label4)
        Me.pnlDatosRecibos.Controls.Add(Me.Label3)
        Me.pnlDatosRecibos.Controls.Add(Me.Label2)
        Me.pnlDatosRecibos.Controls.Add(Me.intFolio)
        Me.pnlDatosRecibos.Controls.Add(Me.cmbPeriodos)
        Me.pnlDatosRecibos.Controls.Add(Me.cmbImpresoras)
        Me.pnlDatosRecibos.DisabledBackColor = System.Drawing.Color.Empty
        Me.pnlDatosRecibos.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlDatosRecibos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlDatosRecibos.Location = New System.Drawing.Point(12, 52)
        Me.pnlDatosRecibos.Name = "pnlDatosRecibos"
        Me.pnlDatosRecibos.Size = New System.Drawing.Size(532, 240)
        '
        '
        '
        Me.pnlDatosRecibos.Style.BackColor = System.Drawing.SystemColors.Window
        Me.pnlDatosRecibos.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.pnlDatosRecibos.Style.BackColorGradientAngle = 90
        Me.pnlDatosRecibos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.pnlDatosRecibos.Style.BorderBottomWidth = 1
        Me.pnlDatosRecibos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pnlDatosRecibos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.pnlDatosRecibos.Style.BorderLeftWidth = 1
        Me.pnlDatosRecibos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.pnlDatosRecibos.Style.BorderRightWidth = 1
        Me.pnlDatosRecibos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.pnlDatosRecibos.Style.BorderTopWidth = 1
        Me.pnlDatosRecibos.Style.CornerDiameter = 4
        Me.pnlDatosRecibos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.pnlDatosRecibos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.pnlDatosRecibos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.pnlDatosRecibos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.pnlDatosRecibos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.pnlDatosRecibos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pnlDatosRecibos.TabIndex = 87
        '
        'txtCorreoPrueba
        '
        '
        '
        '
        Me.txtCorreoPrueba.Border.Class = "TextBoxBorder"
        Me.txtCorreoPrueba.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCorreoPrueba.Location = New System.Drawing.Point(120, 210)
        Me.txtCorreoPrueba.Name = "txtCorreoPrueba"
        Me.txtCorreoPrueba.PreventEnterBeep = True
        Me.txtCorreoPrueba.Size = New System.Drawing.Size(398, 21)
        Me.txtCorreoPrueba.TabIndex = 100
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Window
        Me.Label8.Location = New System.Drawing.Point(11, 209)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 15)
        Me.Label8.TabIndex = 99
        Me.Label8.Text = "Correo de prueba"
        '
        'chkTipoPerCat
        '
        Me.chkTipoPerCat.AutoSize = True
        Me.chkTipoPerCat.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkTipoPerCat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkTipoPerCat.CheckSignSize = New System.Drawing.Size(15, 15)
        Me.chkTipoPerCat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTipoPerCat.Location = New System.Drawing.Point(155, 44)
        Me.chkTipoPerCat.Name = "chkTipoPerCat"
        Me.chkTipoPerCat.Size = New System.Drawing.Size(83, 17)
        Me.chkTipoPerCat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkTipoPerCat.TabIndex = 98
        Me.chkTipoPerCat.Text = "Catorcenal"
        '
        'chkTipoPerSem
        '
        Me.chkTipoPerSem.AutoSize = True
        Me.chkTipoPerSem.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkTipoPerSem.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkTipoPerSem.Checked = True
        Me.chkTipoPerSem.CheckSignSize = New System.Drawing.Size(15, 15)
        Me.chkTipoPerSem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTipoPerSem.CheckValue = "Y"
        Me.chkTipoPerSem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTipoPerSem.Location = New System.Drawing.Point(77, 44)
        Me.chkTipoPerSem.Name = "chkTipoPerSem"
        Me.chkTipoPerSem.Size = New System.Drawing.Size(72, 17)
        Me.chkTipoPerSem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkTipoPerSem.TabIndex = 97
        Me.chkTipoPerSem.Text = "Semanal"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Window
        Me.Label7.Location = New System.Drawing.Point(5, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 15)
        Me.Label7.TabIndex = 96
        Me.Label7.Text = "Tipo:"
        '
        'cmbCia
        '
        Me.cmbCia.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbCia.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbCia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbCia.ButtonDropDown.Visible = True
        Me.cmbCia.Columns.Add(Me.colCodComp)
        Me.cmbCia.Columns.Add(Me.colNombre)
        Me.cmbCia.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbCia.Location = New System.Drawing.Point(77, 10)
        Me.cmbCia.Name = "cmbCia"
        Me.cmbCia.Size = New System.Drawing.Size(441, 23)
        Me.cmbCia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbCia.TabIndex = 0
        Me.cmbCia.ValueMember = "cod_comp"
        '
        'colCodComp
        '
        Me.colCodComp.ColumnName = "cod_comp"
        Me.colCodComp.DataFieldName = "cod_comp"
        Me.colCodComp.Name = "colCodComp"
        Me.colCodComp.Text = "Código"
        Me.colCodComp.Width.Relative = 20
        '
        'colNombre
        '
        Me.colNombre.ColumnName = "nombre"
        Me.colNombre.DataFieldName = "nombre"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.Text = "Nombre"
        Me.colNombre.Width.Relative = 80
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Location = New System.Drawing.Point(5, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 15)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Compañía"
        '
        'txtComentario
        '
        '
        '
        '
        Me.txtComentario.Border.Class = "TextBoxBorder"
        Me.txtComentario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtComentario.Location = New System.Drawing.Point(77, 156)
        Me.txtComentario.Multiline = True
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(441, 48)
        Me.txtComentario.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Location = New System.Drawing.Point(5, 161)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 15)
        Me.Label5.TabIndex = 94
        Me.Label5.Text = "Comentario"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Location = New System.Drawing.Point(5, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 15)
        Me.Label4.TabIndex = 93
        Me.Label4.Text = "Impresora"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Location = New System.Drawing.Point(5, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 15)
        Me.Label3.TabIndex = 92
        Me.Label3.Text = "Folio inicial"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Location = New System.Drawing.Point(5, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 15)
        Me.Label2.TabIndex = 91
        Me.Label2.Text = "Periodo"
        '
        'intFolio
        '
        Me.intFolio.AutoOverwrite = True
        '
        '
        '
        Me.intFolio.BackgroundStyle.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.TopLeft
        Me.intFolio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.intFolio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.intFolio.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.intFolio.Location = New System.Drawing.Point(77, 98)
        Me.intFolio.Margin = New System.Windows.Forms.Padding(3, 3, 10, 3)
        Me.intFolio.MinValue = 1
        Me.intFolio.Name = "intFolio"
        Me.intFolio.ShowUpDown = True
        Me.intFolio.Size = New System.Drawing.Size(68, 21)
        Me.intFolio.TabIndex = 2
        Me.intFolio.Value = 1
        '
        'cmbPeriodos
        '
        Me.cmbPeriodos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPeriodos.BackgroundStyle.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.TopLeft
        Me.cmbPeriodos.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPeriodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPeriodos.ButtonDropDown.Visible = True
        Me.cmbPeriodos.Columns.Add(Me.colSeleccionado)
        Me.cmbPeriodos.Columns.Add(Me.colAno)
        Me.cmbPeriodos.Columns.Add(Me.colPeriodo)
        Me.cmbPeriodos.Columns.Add(Me.colFechaIni)
        Me.cmbPeriodos.Columns.Add(Me.colFechaFin)
        Me.cmbPeriodos.FormatString = "d"
        Me.cmbPeriodos.FormattingEnabled = True
        Me.cmbPeriodos.GroupingMembers = "ano"
        Me.cmbPeriodos.ImageIndex = 0
        Me.cmbPeriodos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPeriodos.Location = New System.Drawing.Point(77, 69)
        Me.cmbPeriodos.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.cmbPeriodos.Name = "cmbPeriodos"
        Me.cmbPeriodos.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node1})
        Me.cmbPeriodos.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect
        Me.cmbPeriodos.Size = New System.Drawing.Size(441, 21)
        Me.cmbPeriodos.TabIndex = 1
        Me.cmbPeriodos.ThemeAware = True
        Me.cmbPeriodos.ValueMember = "seleccionado"
        Me.cmbPeriodos.WatermarkText = "PIDA"
        '
        'colSeleccionado
        '
        Me.colSeleccionado.ColumnName = "colSeleccionado"
        Me.colSeleccionado.DataFieldName = "seleccionado"
        Me.colSeleccionado.Name = "colSeleccionado"
        Me.colSeleccionado.Text = "Column"
        Me.colSeleccionado.Visible = False
        Me.colSeleccionado.Width.Absolute = 150
        '
        'colAno
        '
        Me.colAno.ColumnName = "colAno"
        Me.colAno.DataFieldName = "ano"
        Me.colAno.Name = "colAno"
        Me.colAno.Text = "Column"
        Me.colAno.Width.Relative = 20
        '
        'colPeriodo
        '
        Me.colPeriodo.DataFieldName = "periodo"
        Me.colPeriodo.Name = "colPeriodo"
        Me.colPeriodo.Text = "Periodo"
        Me.colPeriodo.Width.Relative = 20
        '
        'colFechaIni
        '
        Me.colFechaIni.DataFieldName = "fecha_ini"
        Me.colFechaIni.Name = "colFechaIni"
        Me.colFechaIni.Text = "Fecha inicial"
        Me.colFechaIni.Width.Relative = 30
        '
        'colFechaFin
        '
        Me.colFechaFin.DataFieldName = "fecha_fin"
        Me.colFechaFin.Name = "colFechaFin"
        Me.colFechaFin.Text = "Fecha final"
        Me.colFechaFin.Width.Relative = 30
        '
        'Node1
        '
        Me.Node1.Image = Global.PIDA.My.Resources.Resources.calendar_selection_week16
        Me.Node1.Name = "Node1"
        '
        'cmbImpresoras
        '
        Me.cmbImpresoras.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbImpresoras.BackgroundStyle.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.TopLeft
        Me.cmbImpresoras.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbImpresoras.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbImpresoras.ButtonDropDown.Visible = True
        Me.cmbImpresoras.ImageIndex = 0
        Me.cmbImpresoras.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbImpresoras.Location = New System.Drawing.Point(77, 127)
        Me.cmbImpresoras.Name = "cmbImpresoras"
        Me.cmbImpresoras.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect
        Me.cmbImpresoras.Size = New System.Drawing.Size(441, 21)
        Me.cmbImpresoras.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbImpresoras.TabIndex = 3
        '
        'ElementStyle1
        '
        Me.ElementStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(213, Byte), Integer))
        Me.ElementStyle1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(216, Byte), Integer), CType(CType(105, Byte), Integer))
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
        Me.ElementStyle1.Description = "Yellow"
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.PaddingBottom = 1
        Me.ElementStyle1.PaddingLeft = 1
        Me.ElementStyle1.PaddingRight = 1
        Me.ElementStyle1.PaddingTop = 1
        Me.ElementStyle1.TextColor = System.Drawing.Color.Black
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "1 (2).png")
        Me.ImageList1.Images.SetKeyName(1, "1 (3).png")
        Me.ImageList1.Images.SetKeyName(2, "1 (4).png")
        '
        'ElementStyle2
        '
        Me.ElementStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.ElementStyle2.BackColor2 = System.Drawing.Color.Navy
        Me.ElementStyle2.BackColorGradientAngle = 90
        Me.ElementStyle2.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderBottomWidth = 1
        Me.ElementStyle2.BorderColor = System.Drawing.Color.Navy
        Me.ElementStyle2.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderLeftWidth = 1
        Me.ElementStyle2.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderRightWidth = 1
        Me.ElementStyle2.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderTopWidth = 1
        Me.ElementStyle2.CornerDiameter = 4
        Me.ElementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle2.Description = "BlueNight"
        Me.ElementStyle2.Name = "ElementStyle2"
        Me.ElementStyle2.PaddingBottom = 1
        Me.ElementStyle2.PaddingLeft = 1
        Me.ElementStyle2.PaddingRight = 1
        Me.ElementStyle2.PaddingTop = 1
        Me.ElementStyle2.TextColor = System.Drawing.SystemColors.Window
        '
        'ElementStyle4
        '
        Me.ElementStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ElementStyle4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(146, Byte), Integer))
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
        Me.ElementStyle4.Description = "Apple"
        Me.ElementStyle4.Name = "ElementStyle4"
        Me.ElementStyle4.PaddingBottom = 1
        Me.ElementStyle4.PaddingLeft = 1
        Me.ElementStyle4.PaddingRight = 1
        Me.ElementStyle4.PaddingTop = 1
        Me.ElementStyle4.TextColor = System.Drawing.Color.Black
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
        'ElementStyle5
        '
        Me.ElementStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ElementStyle5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
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
        Me.ElementStyle5.Description = "Blue"
        Me.ElementStyle5.Name = "ElementStyle5"
        Me.ElementStyle5.PaddingBottom = 1
        Me.ElementStyle5.PaddingLeft = 1
        Me.ElementStyle5.PaddingRight = 1
        Me.ElementStyle5.PaddingTop = 1
        Me.ElementStyle5.TextColor = System.Drawing.Color.Black
        '
        'EmpNav
        '
        Me.EmpNav.Controls.Add(Me.LabelX1)
        Me.EmpNav.Controls.Add(Me.pbCarga)
        Me.EmpNav.Controls.Add(Me.Panel1)
        Me.EmpNav.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.EmpNav.Location = New System.Drawing.Point(12, 292)
        Me.EmpNav.Name = "EmpNav"
        Me.EmpNav.Padding = New System.Windows.Forms.Padding(0)
        Me.EmpNav.Size = New System.Drawing.Size(1160, 47)
        Me.EmpNav.TabIndex = 88
        Me.EmpNav.TabStop = False
        '
        'pbCarga
        '
        '
        '
        '
        Me.pbCarga.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pbCarga.Location = New System.Drawing.Point(11, 16)
        Me.pbCarga.Name = "pbCarga"
        Me.pbCarga.Size = New System.Drawing.Size(167, 23)
        Me.pbCarga.TabIndex = 4
        Me.pbCarga.Text = "ProgressBarX1"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnBuscarEmp)
        Me.Panel1.Controls.Add(Me.btnVistaPrevia)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Controls.Add(Me.btnImprimir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(761, 13)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(399, 34)
        Me.Panel1.TabIndex = 3
        '
        'btnBuscarEmp
        '
        Me.btnBuscarEmp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscarEmp.CausesValidation = False
        Me.btnBuscarEmp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscarEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscarEmp.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscarEmp.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBuscarEmp.Location = New System.Drawing.Point(13, 3)
        Me.btnBuscarEmp.Name = "btnBuscarEmp"
        Me.btnBuscarEmp.Size = New System.Drawing.Size(87, 25)
        Me.btnBuscarEmp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscarEmp.TabIndex = 5
        Me.btnBuscarEmp.Text = "Buscar"
        Me.btnBuscarEmp.Tooltip = "Buscar"
        '
        'btnVistaPrevia
        '
        Me.btnVistaPrevia.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnVistaPrevia.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnVistaPrevia.Image = Global.PIDA.My.Resources.Resources.Preview16
        Me.btnVistaPrevia.Location = New System.Drawing.Point(106, 3)
        Me.btnVistaPrevia.Name = "btnVistaPrevia"
        Me.btnVistaPrevia.Size = New System.Drawing.Size(92, 25)
        Me.btnVistaPrevia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnVistaPrevia.TabIndex = 2
        Me.btnVistaPrevia.Text = "Vista previa"
        '
        'btnSalir
        '
        Me.btnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSalir.Image = Global.PIDA.My.Resources.Resources.Cancel16
        Me.btnSalir.Location = New System.Drawing.Point(302, 3)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(92, 25)
        Me.btnSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSalir.TabIndex = 1
        Me.btnSalir.Text = "Salir"
        '
        'btnImprimir
        '
        Me.btnImprimir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnImprimir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnImprimir.Image = Global.PIDA.My.Resources.Resources.Printer16
        Me.btnImprimir.Location = New System.Drawing.Point(204, 3)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(92, 25)
        Me.btnImprimir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnImprimir.TabIndex = 0
        Me.btnImprimir.Text = "Imprimir"
        '
        'dlgArchivo
        '
        Me.dlgArchivo.FileName = "OpenFileDialog1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Printer32
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(34, 35)
        Me.PictureBox1.TabIndex = 85
        Me.PictureBox1.TabStop = False
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.Controls.Add(Me.LabelX2)
        Me.pnlEncabezado.Controls.Add(Me.ReflectionLabel1)
        Me.pnlEncabezado.Controls.Add(Me.PictureBox1)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(12, 12)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1160, 40)
        Me.pnlEncabezado.TabIndex = 89
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(544, 52)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(10, 240)
        Me.Panel2.TabIndex = 97
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.CheckBoxX1)
        Me.Panel3.Controls.Add(Me.CheckBoxX2)
        Me.Panel3.Location = New System.Drawing.Point(379, 14)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 100)
        Me.Panel3.TabIndex = 11
        '
        'CheckBoxX1
        '
        Me.CheckBoxX1.AutoSize = True
        Me.CheckBoxX1.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.CheckBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX1.CheckSignSize = New System.Drawing.Size(15, 15)
        Me.CheckBoxX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxX1.Location = New System.Drawing.Point(10, 7)
        Me.CheckBoxX1.Name = "CheckBoxX1"
        Me.CheckBoxX1.Size = New System.Drawing.Size(104, 17)
        Me.CheckBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX1.TabIndex = 9
        Me.CheckBoxX1.Text = "Expandir todos"
        '
        'CheckBoxX2
        '
        Me.CheckBoxX2.AutoSize = True
        Me.CheckBoxX2.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.CheckBoxX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CheckBoxX2.Checked = True
        Me.CheckBoxX2.CheckSignSize = New System.Drawing.Size(15, 15)
        Me.CheckBoxX2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxX2.CheckValue = "Y"
        Me.CheckBoxX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxX2.Location = New System.Drawing.Point(158, 7)
        Me.CheckBoxX2.Name = "CheckBoxX2"
        Me.CheckBoxX2.Size = New System.Drawing.Size(120, 17)
        Me.CheckBoxX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CheckBoxX2.TabIndex = 10
        Me.CheckBoxX2.Text = "Seleccionar todos"
        '
        'Node6
        '
        Me.Node6.Expanded = True
        Me.Node6.HostedControl = Me.Panel3
        Me.Node6.Name = "Node6"
        Me.Node6.Text = "Node6"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(187, 16)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(345, 23)
        Me.LabelX1.TabIndex = 5
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(542, 8)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(204, 23)
        Me.LabelX2.TabIndex = 86
        Me.LabelX2.Text = "LabelX2"
        '
        'frmRecibos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 351)
        Me.Controls.Add(Me.tabBuscar)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlDatosRecibos)
        Me.Controls.Add(Me.EmpNav)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRecibos"
        Me.Padding = New System.Windows.Forms.Padding(12)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recibos"
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBuscar.ResumeLayout(False)
        Me.pnlDatos.ResumeLayout(False)
        CType(Me.trSeleccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        Me.SuperTabControlPanel2.PerformLayout()
        Me.pnlDatosRecibos.ResumeLayout(False)
        Me.pnlDatosRecibos.PerformLayout()
        CType(Me.intFolio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EmpNav.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEncabezado.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabBuscar As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents pnlDatos As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabSeleccion As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabEmpleado As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents pnlDatosRecibos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmbImpresoras As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle2 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle4 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle3 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents txtReloj As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ElementStyle5 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents cmbPeriodos As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents colPeriodo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colFechaIni As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colFechaFin As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents intFolio As DevComponents.Editors.IntegerInput
    Friend WithEvents Node1 As DevComponents.AdvTree.Node
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtComentario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents EmpNav As System.Windows.Forms.GroupBox
    Friend WithEvents btnImprimir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSalir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents trSeleccion As DevComponents.AdvTree.AdvTree
    Friend WithEvents Node2 As DevComponents.AdvTree.Node
    Friend WithEvents Node4 As DevComponents.AdvTree.Node
    Friend WithEvents Node5 As DevComponents.AdvTree.Node
    Friend WithEvents Node7 As DevComponents.AdvTree.Node
    Friend WithEvents ElementStyle6 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle7 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle8 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents chkSeleccion As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkExpandir As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkSeleccionar As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Node9 As DevComponents.AdvTree.Node
    Friend WithEvents ElementStyle9 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents Node3 As DevComponents.AdvTree.Node
    Friend WithEvents Cell1 As DevComponents.AdvTree.Cell
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader6 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader7 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents dlgArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnVistaPrevia As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmbCia As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents colCodComp As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colNombre As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents CheckBoxX1 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents CheckBoxX2 As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Node6 As DevComponents.AdvTree.Node
    Friend WithEvents colSeleccionado As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colAno As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents chkMandarCorreos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkTipoPerCat As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkTipoPerSem As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCorreoPrueba As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Private WithEvents btnBuscarEmp As DevComponents.DotNetBar.ButtonX
    Friend WithEvents pbCarga As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
End Class
