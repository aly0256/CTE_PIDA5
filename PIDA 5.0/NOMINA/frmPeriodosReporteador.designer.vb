<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPeriodosReporteador
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPeriodosReporteador))
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader6 = New DevComponents.AdvTree.ColumnHeader()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.trPeriodos = New DevComponents.AdvTree.AdvTree()
        Me.ColPeriodo = New DevComponents.AdvTree.ColumnHeader()
        Me.ColNumPeriodo = New DevComponents.AdvTree.ColumnHeader()
        Me.ColFechaIni = New DevComponents.AdvTree.ColumnHeader()
        Me.ColFechaFin = New DevComponents.AdvTree.ColumnHeader()
        Me.ColMes = New DevComponents.AdvTree.ColumnHeader()
        Me.ColNombre = New DevComponents.AdvTree.ColumnHeader()
        Me.ColAnoP = New DevComponents.AdvTree.ColumnHeader()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.Node1 = New DevComponents.AdvTree.Node()
        Me.Node6 = New DevComponents.AdvTree.Node()
        Me.Cell2 = New DevComponents.AdvTree.Cell()
        Me.Cell3 = New DevComponents.AdvTree.Cell()
        Me.Cell4 = New DevComponents.AdvTree.Cell()
        Me.Cell5 = New DevComponents.AdvTree.Cell()
        Me.Cell1 = New DevComponents.AdvTree.Cell()
        Me.Node8 = New DevComponents.AdvTree.Node()
        Me.Cell6 = New DevComponents.AdvTree.Cell()
        Me.Cell7 = New DevComponents.AdvTree.Cell()
        Me.Cell8 = New DevComponents.AdvTree.Cell()
        Me.Cell9 = New DevComponents.AdvTree.Cell()
        Me.Node10 = New DevComponents.AdvTree.Node()
        Me.Node11 = New DevComponents.AdvTree.Node()
        Me.Node12 = New DevComponents.AdvTree.Node()
        Me.ElementStyle3 = New DevComponents.DotNetBar.ElementStyle()
        Me.NodeConnector2 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle2 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle4 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle5 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle6 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle7 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle8 = New DevComponents.DotNetBar.ElementStyle()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ColumnHeader7 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader8 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader9 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader10 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader11 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader12 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader13 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader14 = New DevComponents.AdvTree.ColumnHeader()
        Me.dlgArchivo = New System.Windows.Forms.SaveFileDialog()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ReflectionLabel2 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnProcesar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.btnSalir = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmbCompania = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPeriodos = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.trPeriodos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "tipo_pol"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Tipo"
        Me.ColumnHeader1.Width.Absolute = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "nombre"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.StretchToFill = True
        Me.ColumnHeader2.Text = "Nombre"
        Me.ColumnHeader2.Width.Absolute = 150
        Me.ColumnHeader2.Width.AutoSize = True
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DataFieldName = "cod_tipo"
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.Text = "Código"
        Me.ColumnHeader5.Width.Absolute = 50
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.DataFieldName = "nombre"
        Me.ColumnHeader6.Name = "ColumnHeader6"
        Me.ColumnHeader6.StretchToFill = True
        Me.ColumnHeader6.Text = "Nombre"
        Me.ColumnHeader6.Width.Absolute = 150
        Me.ColumnHeader6.Width.AutoSize = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(421, 485)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(203, 47)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel1.Controls.Add(Me.Panel7)
        Me.GroupPanel1.Controls.Add(Me.Panel6)
        Me.GroupPanel1.Controls.Add(Me.Panel5)
        Me.GroupPanel1.Controls.Add(Me.Panel4)
        Me.GroupPanel1.Controls.Add(Me.Panel3)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Padding = New System.Windows.Forms.Padding(10)
        Me.GroupPanel1.Size = New System.Drawing.Size(666, 459)
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
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
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
        Me.GroupPanel1.TabIndex = 0
        '
        'trPeriodos
        '
        Me.trPeriodos.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.trPeriodos.AllowDrop = True
        Me.trPeriodos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.trPeriodos.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Etched
        Me.trPeriodos.BackgroundStyle.Class = "TreeBorderKey"
        Me.trPeriodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.trPeriodos.Columns.Add(Me.ColPeriodo)
        Me.trPeriodos.Columns.Add(Me.ColNumPeriodo)
        Me.trPeriodos.Columns.Add(Me.ColFechaIni)
        Me.trPeriodos.Columns.Add(Me.ColFechaFin)
        Me.trPeriodos.Columns.Add(Me.ColMes)
        Me.trPeriodos.Columns.Add(Me.ColNombre)
        Me.trPeriodos.Columns.Add(Me.ColAnoP)
        Me.trPeriodos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trPeriodos.DragDropEnabled = False
        Me.trPeriodos.ExpandButtonType = DevComponents.AdvTree.eExpandButtonType.Triangle
        Me.trPeriodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.trPeriodos.GroupNodeStyle = Me.ElementStyle1
        Me.trPeriodos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.trPeriodos.Location = New System.Drawing.Point(0, 0)
        Me.trPeriodos.MultiNodeDragDropAllowed = False
        Me.trPeriodos.MultiSelect = True
        Me.trPeriodos.Name = "trPeriodos"
        Me.trPeriodos.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node1})
        Me.trPeriodos.NodesColumnsBackgroundStyle = Me.ElementStyle3
        Me.trPeriodos.NodesConnector = Me.NodeConnector2
        Me.trPeriodos.NodeSpacing = 5
        Me.trPeriodos.NodeStyle = Me.ElementStyle1
        Me.trPeriodos.PathSeparator = ";"
        Me.trPeriodos.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect
        Me.trPeriodos.Size = New System.Drawing.Size(640, 311)
        Me.trPeriodos.Styles.Add(Me.ElementStyle1)
        Me.trPeriodos.Styles.Add(Me.ElementStyle2)
        Me.trPeriodos.Styles.Add(Me.ElementStyle3)
        Me.trPeriodos.Styles.Add(Me.ElementStyle4)
        Me.trPeriodos.Styles.Add(Me.ElementStyle5)
        Me.trPeriodos.Styles.Add(Me.ElementStyle6)
        Me.trPeriodos.Styles.Add(Me.ElementStyle7)
        Me.trPeriodos.Styles.Add(Me.ElementStyle8)
        Me.trPeriodos.TabIndex = 1
        '
        'ColPeriodo
        '
        Me.ColPeriodo.Name = "ColPeriodo"
        Me.ColPeriodo.Text = "Periodo"
        Me.ColPeriodo.Width.Absolute = 80
        '
        'ColNumPeriodo
        '
        Me.ColNumPeriodo.Name = "ColNumPeriodo"
        Me.ColNumPeriodo.Text = "Periodo"
        Me.ColNumPeriodo.Width.Absolute = 70
        '
        'ColFechaIni
        '
        Me.ColFechaIni.Name = "ColFechaIni"
        Me.ColFechaIni.Text = "Fecha inicial"
        Me.ColFechaIni.Width.Absolute = 70
        '
        'ColFechaFin
        '
        Me.ColFechaFin.Name = "ColFechaFin"
        Me.ColFechaFin.Text = "Fecha final"
        Me.ColFechaFin.Width.Absolute = 70
        '
        'ColMes
        '
        Me.ColMes.Name = "ColMes"
        Me.ColMes.Text = "Mes"
        Me.ColMes.Width.Absolute = 85
        '
        'ColNombre
        '
        Me.ColNombre.Name = "ColNombre"
        Me.ColNombre.Text = "Nombre"
        Me.ColNombre.Width.Absolute = 230
        '
        'ColAnoP
        '
        Me.ColAnoP.Name = "ColAnoP"
        Me.ColAnoP.Text = "Ano"
        Me.ColAnoP.Visible = False
        Me.ColAnoP.Width.Absolute = 150
        '
        'ElementStyle1
        '
        Me.ElementStyle1.BackColor2 = System.Drawing.SystemColors.Highlight
        Me.ElementStyle1.BackColorGradientAngle = 90
        Me.ElementStyle1.BorderBottomWidth = 1
        Me.ElementStyle1.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle1.BorderLeftWidth = 1
        Me.ElementStyle1.BorderRightWidth = 1
        Me.ElementStyle1.BorderTopWidth = 1
        Me.ElementStyle1.CornerDiameter = 4
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Description = "Regular"
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.PaddingBottom = 1
        Me.ElementStyle1.PaddingLeft = 1
        Me.ElementStyle1.PaddingRight = 1
        Me.ElementStyle1.PaddingTop = 1
        Me.ElementStyle1.TextColor = System.Drawing.Color.Black
        '
        'Node1
        '
        Me.Node1.CheckBoxVisible = True
        Me.Node1.Checked = True
        Me.Node1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Node1.Expanded = True
        Me.Node1.Name = "Node1"
        Me.Node1.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node6, Me.Node8, Me.Node10, Me.Node11, Me.Node12})
        Me.Node1.Text = "AÑO"
        '
        'Node6
        '
        Me.Node6.Cells.Add(Me.Cell2)
        Me.Node6.Cells.Add(Me.Cell3)
        Me.Node6.Cells.Add(Me.Cell4)
        Me.Node6.Cells.Add(Me.Cell5)
        Me.Node6.Cells.Add(Me.Cell1)
        Me.Node6.CheckBoxVisible = True
        Me.Node6.Expanded = True
        Me.Node6.Name = "Node6"
        Me.Node6.Text = "01"
        '
        'Cell2
        '
        Me.Cell2.Name = "Cell2"
        Me.Cell2.StyleMouseOver = Nothing
        Me.Cell2.Text = "01/10/2013"
        '
        'Cell3
        '
        Me.Cell3.Name = "Cell3"
        Me.Cell3.StyleMouseOver = Nothing
        Me.Cell3.Text = "02/10/2013"
        '
        'Cell4
        '
        Me.Cell4.Name = "Cell4"
        Me.Cell4.StyleMouseOver = Nothing
        Me.Cell4.Text = "SEPTIEMBRE"
        '
        'Cell5
        '
        Me.Cell5.Name = "Cell5"
        Me.Cell5.StyleMouseOver = Nothing
        Me.Cell5.Text = "Aguinaldo 2014"
        '
        'Cell1
        '
        Me.Cell1.Name = "Cell1"
        Me.Cell1.StyleMouseOver = Nothing
        Me.Cell1.Text = "2222"
        '
        'Node8
        '
        Me.Node8.Cells.Add(Me.Cell6)
        Me.Node8.Cells.Add(Me.Cell7)
        Me.Node8.Cells.Add(Me.Cell8)
        Me.Node8.Cells.Add(Me.Cell9)
        Me.Node8.CheckBoxVisible = True
        Me.Node8.Expanded = True
        Me.Node8.Name = "Node8"
        Me.Node8.Text = "02"
        '
        'Cell6
        '
        Me.Cell6.Name = "Cell6"
        Me.Cell6.StyleMouseOver = Nothing
        '
        'Cell7
        '
        Me.Cell7.Name = "Cell7"
        Me.Cell7.StyleMouseOver = Nothing
        '
        'Cell8
        '
        Me.Cell8.Name = "Cell8"
        Me.Cell8.StyleMouseOver = Nothing
        '
        'Cell9
        '
        Me.Cell9.Name = "Cell9"
        Me.Cell9.StyleMouseOver = Nothing
        '
        'Node10
        '
        Me.Node10.CheckBoxVisible = True
        Me.Node10.Expanded = True
        Me.Node10.Name = "Node10"
        Me.Node10.Text = "03"
        '
        'Node11
        '
        Me.Node11.CheckBoxVisible = True
        Me.Node11.Expanded = True
        Me.Node11.Name = "Node11"
        Me.Node11.Text = "04"
        '
        'Node12
        '
        Me.Node12.CheckBoxVisible = True
        Me.Node12.Expanded = True
        Me.Node12.Name = "Node12"
        Me.Node12.Text = "05"
        '
        'ElementStyle3
        '
        Me.ElementStyle3.BackColor = System.Drawing.SystemColors.Window
        Me.ElementStyle3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(240, Byte), Integer))
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
        Me.ElementStyle3.Description = "Gray"
        Me.ElementStyle3.Name = "ElementStyle3"
        Me.ElementStyle3.PaddingBottom = 1
        Me.ElementStyle3.PaddingLeft = 1
        Me.ElementStyle3.PaddingRight = 1
        Me.ElementStyle3.PaddingTop = 1
        Me.ElementStyle3.TextColor = System.Drawing.Color.Black
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
        'ElementStyle4
        '
        Me.ElementStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ElementStyle4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
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
        Me.ElementStyle4.Description = "Blue"
        Me.ElementStyle4.Name = "ElementStyle4"
        Me.ElementStyle4.PaddingBottom = 1
        Me.ElementStyle4.PaddingLeft = 1
        Me.ElementStyle4.PaddingRight = 1
        Me.ElementStyle4.PaddingTop = 1
        Me.ElementStyle4.TextColor = System.Drawing.Color.Black
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
        'ElementStyle6
        '
        Me.ElementStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ElementStyle6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ElementStyle6.BackColorGradientAngle = 90
        Me.ElementStyle6.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle6.BorderBottomWidth = 1
        Me.ElementStyle6.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle6.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle6.BorderLeftWidth = 1
        Me.ElementStyle6.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle6.BorderRightWidth = 1
        Me.ElementStyle6.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle6.BorderTopWidth = 1
        Me.ElementStyle6.CornerDiameter = 4
        Me.ElementStyle6.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle6.Description = "BlueLight"
        Me.ElementStyle6.Name = "ElementStyle6"
        Me.ElementStyle6.PaddingBottom = 1
        Me.ElementStyle6.PaddingLeft = 1
        Me.ElementStyle6.PaddingRight = 1
        Me.ElementStyle6.PaddingTop = 1
        Me.ElementStyle6.TextColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(115, Byte), Integer))
        '
        'ElementStyle7
        '
        Me.ElementStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(217, Byte), Integer))
        Me.ElementStyle7.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(176, Byte), Integer), CType(CType(120, Byte), Integer))
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
        Me.ElementStyle7.Description = "Orange"
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
        'ColumnHeader3
        '
        Me.ColumnHeader3.DataFieldName = "cod_comp"
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Código"
        Me.ColumnHeader3.Width.Absolute = 50
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DataFieldName = "nombre"
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.StretchToFill = True
        Me.ColumnHeader4.Text = "Nombre"
        Me.ColumnHeader4.Width.Absolute = 150
        Me.ColumnHeader4.Width.AutoSize = True
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 25)
        Me.Label5.TabIndex = 95
        Me.Label5.Text = "Compañía"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Name = "ColumnHeader7"
        Me.ColumnHeader7.Text = "Per."
        Me.ColumnHeader7.Width.Absolute = 25
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Name = "ColumnHeader8"
        Me.ColumnHeader8.Text = "Ded."
        Me.ColumnHeader8.Width.Absolute = 25
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Name = "ColumnHeader9"
        Me.ColumnHeader9.Text = "Neto"
        Me.ColumnHeader9.Width.Absolute = 25
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Name = "ColumnHeader10"
        Me.ColumnHeader10.Text = "# Rec."
        Me.ColumnHeader10.Width.Absolute = 20
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Name = "ColumnHeader11"
        Me.ColumnHeader11.Text = "Per."
        Me.ColumnHeader11.Width.Absolute = 25
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Name = "ColumnHeader12"
        Me.ColumnHeader12.Text = "Ded."
        Me.ColumnHeader12.Width.Absolute = 25
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Name = "ColumnHeader13"
        Me.ColumnHeader13.Text = "Neto"
        Me.ColumnHeader13.Width.Absolute = 25
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Name = "ColumnHeader14"
        Me.ColumnHeader14.Text = "# Rec."
        Me.ColumnHeader14.Width.Absolute = 20
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ReflectionLabel2)
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(10, 10)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(666, 53)
        Me.Panel2.TabIndex = 82
        '
        'ReflectionLabel2
        '
        '
        '
        '
        Me.ReflectionLabel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel2.BackgroundStyle.PaddingLeft = 10
        Me.ReflectionLabel2.BackgroundStyle.PaddingTop = 10
        Me.ReflectionLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReflectionLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel2.Location = New System.Drawing.Point(38, 0)
        Me.ReflectionLabel2.Name = "ReflectionLabel2"
        Me.ReflectionLabel2.Size = New System.Drawing.Size(628, 53)
        Me.ReflectionLabel2.TabIndex = 249
        Me.ReflectionLabel2.Text = "<font color=""#1F497D""><b>SELECCIONE COMPAÑÍA Y PERIODO(S)</b></font>"
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox2.Image = Global.PIDA.My.Resources.Resources.periodos_reportes_
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(38, 53)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 210
        Me.PictureBox2.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnProcesar)
        Me.GroupBox2.Controls.Add(Me.Panel13)
        Me.GroupBox2.Controls.Add(Me.btnSalir)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(10, 522)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(10, 0, 10, 8)
        Me.GroupBox2.Size = New System.Drawing.Size(666, 46)
        Me.GroupBox2.TabIndex = 261
        Me.GroupBox2.TabStop = False
        '
        'btnProcesar
        '
        Me.btnProcesar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnProcesar.CausesValidation = False
        Me.btnProcesar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnProcesar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnProcesar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProcesar.Image = Global.PIDA.My.Resources.Resources.acept_
        Me.btnProcesar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnProcesar.ImageTextSpacing = 3
        Me.btnProcesar.Location = New System.Drawing.Point(469, 14)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(90, 24)
        Me.btnProcesar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnProcesar.TabIndex = 261
        Me.btnProcesar.Text = "Aceptar"
        '
        'Panel13
        '
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel13.Location = New System.Drawing.Point(559, 14)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(7, 24)
        Me.Panel13.TabIndex = 260
        '
        'btnSalir
        '
        Me.btnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSalir.CausesValidation = False
        Me.btnSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.PIDA.My.Resources.Resources.salir_
        Me.btnSalir.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnSalir.ImageTextSpacing = 3
        Me.btnSalir.Location = New System.Drawing.Point(566, 14)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(90, 24)
        Me.btnSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSalir.TabIndex = 259
        Me.btnSalir.Text = "Salir"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(10, 63)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(666, 459)
        Me.Panel1.TabIndex = 262
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.cmbCompania)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(10, 10)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(640, 25)
        Me.Panel3.TabIndex = 145
        '
        'cmbCompania
        '
        Me.cmbCompania.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbCompania.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbCompania.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbCompania.ButtonDropDown.Visible = True
        Me.cmbCompania.Columns.Add(Me.ColumnHeader3)
        Me.cmbCompania.Columns.Add(Me.ColumnHeader4)
        Me.cmbCompania.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbCompania.KeyboardSearchNoSelectionAllowed = False
        Me.cmbCompania.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbCompania.Location = New System.Drawing.Point(70, 0)
        Me.cmbCompania.Name = "cmbCompania"
        Me.cmbCompania.Size = New System.Drawing.Size(570, 25)
        Me.cmbCompania.TabIndex = 96
        Me.cmbCompania.ValueMember = "cod_comp"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(10, 35)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(640, 10)
        Me.Panel4.TabIndex = 146
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Controls.Add(Me.txtPeriodos)
        Me.Panel5.Controls.Add(Me.Label2)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(10, 45)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(640, 77)
        Me.Panel5.TabIndex = 147
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 77)
        Me.Label2.TabIndex = 145
        Me.Label2.Text = "Periodo(s)"
        '
        'txtPeriodos
        '
        '
        '
        '
        Me.txtPeriodos.Border.Class = "TextBoxBorder"
        Me.txtPeriodos.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPeriodos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPeriodos.Enabled = False
        Me.txtPeriodos.Location = New System.Drawing.Point(70, 0)
        Me.txtPeriodos.Multiline = True
        Me.txtPeriodos.Name = "txtPeriodos"
        Me.txtPeriodos.ReadOnly = True
        Me.txtPeriodos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPeriodos.Size = New System.Drawing.Size(570, 77)
        Me.txtPeriodos.TabIndex = 146
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(10, 122)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(640, 10)
        Me.Panel6.TabIndex = 148
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Transparent
        Me.Panel7.Controls.Add(Me.trPeriodos)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(10, 132)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(640, 311)
        Me.Panel7.TabIndex = 149
        '
        'frmPeriodosReporteador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 578)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPeriodosReporteador"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Periodos reporteador"
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.trPeriodos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader6 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents trPeriodos As DevComponents.AdvTree.AdvTree
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ColumnHeader11 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader12 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader13 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader14 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NodeConnector2 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle2 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle3 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle4 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ColumnHeader7 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader8 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader9 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader10 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColPeriodo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColFechaIni As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColFechaFin As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColMes As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColNombre As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Node1 As DevComponents.AdvTree.Node
    Friend WithEvents Node6 As DevComponents.AdvTree.Node
    Friend WithEvents Cell2 As DevComponents.AdvTree.Cell
    Friend WithEvents Cell3 As DevComponents.AdvTree.Cell
    Friend WithEvents Cell4 As DevComponents.AdvTree.Cell
    Friend WithEvents Cell5 As DevComponents.AdvTree.Cell
    Friend WithEvents Node8 As DevComponents.AdvTree.Node
    Friend WithEvents Cell6 As DevComponents.AdvTree.Cell
    Friend WithEvents Cell7 As DevComponents.AdvTree.Cell
    Friend WithEvents Cell8 As DevComponents.AdvTree.Cell
    Friend WithEvents Cell9 As DevComponents.AdvTree.Cell
    Friend WithEvents Node10 As DevComponents.AdvTree.Node
    Friend WithEvents Node11 As DevComponents.AdvTree.Node
    Friend WithEvents Node12 As DevComponents.AdvTree.Node
    Friend WithEvents ElementStyle5 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle6 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle7 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle8 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ColAnoP As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Cell1 As DevComponents.AdvTree.Cell
    Friend WithEvents dlgArchivo As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ColNumPeriodo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ReflectionLabel2 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnProcesar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents btnSalir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents txtPeriodos As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cmbCompania As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
