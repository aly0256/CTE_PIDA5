<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCursos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCursos))
        Me.tabBuscar = New DevComponents.DotNetBar.SuperTabControl()
        Me.pnlDatos = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.cmbClasificacion = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.codClasif = New DevComponents.AdvTree.ColumnHeader()
        Me.Nombre = New DevComponents.AdvTree.ColumnHeader()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.lblOrdenActual = New System.Windows.Forms.Label()
        Me.lblOrden = New System.Windows.Forms.Label()
        Me.cmbOrdenNivel = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.c_Categoria = New DevComponents.AdvTree.ColumnHeader()
        Me.c_Orden = New DevComponents.AdvTree.ColumnHeader()
        Me.c_Nivel = New DevComponents.AdvTree.ColumnHeader()
        Me.cmbDepto = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.codDepto = New DevComponents.AdvTree.ColumnHeader()
        Me.nomDepto = New DevComponents.AdvTree.ColumnHeader()
        Me.lblDep = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnObligatorio = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.sbRequiereCalificacion = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.cmbTipo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader6 = New DevComponents.AdvTree.ColumnHeader()
        Me.cmbClase = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader9 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader10 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblActivar = New System.Windows.Forms.Label()
        Me.btnActivar = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCalificacion = New DevComponents.Editors.DoubleInput()
        Me.txtOrdenMatriz = New DevComponents.Editors.IntegerInput()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbModalidad = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader7 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader8 = New DevComponents.AdvTree.ColumnHeader()
        Me.cmbObjetivo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.cmbAreaTematica = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.txtCosto = New DevComponents.Editors.DoubleInput()
        Me.txtDuracion = New DevComponents.Editors.DoubleInput()
        Me.txtComentarios = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblComments = New System.Windows.Forms.Label()
        Me.lblTematica = New System.Windows.Forms.Label()
        Me.lblClase = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnStps = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tabEmpleado = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgTabla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.tabTabla = New DevComponents.DotNetBar.SuperTabItem()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBuscar.SuspendLayout()
        Me.pnlDatos.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.txtCalificacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtOrdenMatriz, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDuracion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EmpNav.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.tabBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.Location = New System.Drawing.Point(12, 48)
        Me.tabBuscar.Name = "tabBuscar"
        Me.tabBuscar.ReorderTabsEnabled = True
        Me.tabBuscar.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabBuscar.SelectedTabIndex = 0
        Me.tabBuscar.Size = New System.Drawing.Size(825, 436)
        Me.tabBuscar.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.tabBuscar.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.TabIndex = 69
        Me.tabBuscar.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit
        Me.tabBuscar.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabEmpleado, Me.tabTabla})
        Me.tabBuscar.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.cmbClasificacion)
        Me.pnlDatos.Controls.Add(Me.GroupPanel1)
        Me.pnlDatos.Controls.Add(Me.cmbDepto)
        Me.pnlDatos.Controls.Add(Me.lblDep)
        Me.pnlDatos.Controls.Add(Me.Label12)
        Me.pnlDatos.Controls.Add(Me.btnObligatorio)
        Me.pnlDatos.Controls.Add(Me.Label9)
        Me.pnlDatos.Controls.Add(Me.sbRequiereCalificacion)
        Me.pnlDatos.Controls.Add(Me.cmbTipo)
        Me.pnlDatos.Controls.Add(Me.cmbClase)
        Me.pnlDatos.Controls.Add(Me.Label10)
        Me.pnlDatos.Controls.Add(Me.Label11)
        Me.pnlDatos.Controls.Add(Me.lblActivar)
        Me.pnlDatos.Controls.Add(Me.btnActivar)
        Me.pnlDatos.Controls.Add(Me.Label8)
        Me.pnlDatos.Controls.Add(Me.txtCalificacion)
        Me.pnlDatos.Controls.Add(Me.txtOrdenMatriz)
        Me.pnlDatos.Controls.Add(Me.Label7)
        Me.pnlDatos.Controls.Add(Me.cmbModalidad)
        Me.pnlDatos.Controls.Add(Me.cmbObjetivo)
        Me.pnlDatos.Controls.Add(Me.cmbAreaTematica)
        Me.pnlDatos.Controls.Add(Me.txtCosto)
        Me.pnlDatos.Controls.Add(Me.txtDuracion)
        Me.pnlDatos.Controls.Add(Me.txtComentarios)
        Me.pnlDatos.Controls.Add(Me.lblComments)
        Me.pnlDatos.Controls.Add(Me.lblTematica)
        Me.pnlDatos.Controls.Add(Me.lblClase)
        Me.pnlDatos.Controls.Add(Me.lblTipo)
        Me.pnlDatos.Controls.Add(Me.Label6)
        Me.pnlDatos.Controls.Add(Me.Label5)
        Me.pnlDatos.Controls.Add(Me.Label4)
        Me.pnlDatos.Controls.Add(Me.Label3)
        Me.pnlDatos.Controls.Add(Me.btnStps)
        Me.pnlDatos.Controls.Add(Me.Label1)
        Me.pnlDatos.Controls.Add(Me.txtCodigo)
        Me.pnlDatos.Controls.Add(Me.txtNombre)
        Me.pnlDatos.Controls.Add(Me.Label2)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(754, 436)
        Me.pnlDatos.TabIndex = 0
        Me.pnlDatos.TabItem = Me.tabEmpleado
        '
        'cmbClasificacion
        '
        Me.cmbClasificacion.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbClasificacion.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbClasificacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbClasificacion.ButtonDropDown.Visible = True
        Me.cmbClasificacion.Columns.Add(Me.codClasif)
        Me.cmbClasificacion.Columns.Add(Me.Nombre)
        Me.cmbClasificacion.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbClasificacion.Location = New System.Drawing.Point(138, 166)
        Me.cmbClasificacion.Name = "cmbClasificacion"
        Me.cmbClasificacion.Size = New System.Drawing.Size(206, 21)
        Me.cmbClasificacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbClasificacion.TabIndex = 138
        Me.cmbClasificacion.ValueMember = "cod_clasif"
        '
        'codClasif
        '
        Me.codClasif.DataFieldName = "cod_clasif"
        Me.codClasif.Name = "codClasif"
        Me.codClasif.Text = "Código"
        Me.codClasif.Width.Absolute = 75
        '
        'Nombre
        '
        Me.Nombre.DataFieldName = "nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Text = "Descripción"
        Me.Nombre.Width.Absolute = 150
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.lblOrdenActual)
        Me.GroupPanel1.Controls.Add(Me.lblOrden)
        Me.GroupPanel1.Controls.Add(Me.cmbOrdenNivel)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel1.Location = New System.Drawing.Point(46, 307)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(391, 74)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.Style.BackColor2 = System.Drawing.Color.White
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
        Me.GroupPanel1.TabIndex = 137
        Me.GroupPanel1.Text = "Orden y nivel"
        Me.GroupPanel1.Visible = False
        '
        'lblOrdenActual
        '
        Me.lblOrdenActual.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOrdenActual.AutoSize = True
        Me.lblOrdenActual.BackColor = System.Drawing.SystemColors.Window
        Me.lblOrdenActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrdenActual.ForeColor = System.Drawing.Color.Maroon
        Me.lblOrdenActual.Location = New System.Drawing.Point(11, -14)
        Me.lblOrdenActual.Name = "lblOrdenActual"
        Me.lblOrdenActual.Size = New System.Drawing.Size(303, 15)
        Me.lblOrdenActual.TabIndex = 93
        Me.lblOrdenActual.Text = "Categoria actual:   -Sin registro-   Orden:   -Sin registro-"
        Me.lblOrdenActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblOrden
        '
        Me.lblOrden.AutoSize = True
        Me.lblOrden.BackColor = System.Drawing.SystemColors.Window
        Me.lblOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrden.Location = New System.Drawing.Point(256, 22)
        Me.lblOrden.Name = "lblOrden"
        Me.lblOrden.Size = New System.Drawing.Size(136, 15)
        Me.lblOrden.TabIndex = 92
        Me.lblOrden.Text = "<- Seleccione opción ->"
        Me.lblOrden.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbOrdenNivel
        '
        Me.cmbOrdenNivel.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbOrdenNivel.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbOrdenNivel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbOrdenNivel.ButtonDropDown.Visible = True
        Me.cmbOrdenNivel.Columns.Add(Me.c_Categoria)
        Me.cmbOrdenNivel.Columns.Add(Me.c_Orden)
        Me.cmbOrdenNivel.Columns.Add(Me.c_Nivel)
        Me.cmbOrdenNivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOrdenNivel.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbOrdenNivel.Location = New System.Drawing.Point(14, 20)
        Me.cmbOrdenNivel.Name = "cmbOrdenNivel"
        Me.cmbOrdenNivel.Size = New System.Drawing.Size(210, 21)
        Me.cmbOrdenNivel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbOrdenNivel.TabIndex = 91
        Me.cmbOrdenNivel.ValueMember = "orden"
        '
        'c_Categoria
        '
        Me.c_Categoria.DataFieldName = "categoria"
        Me.c_Categoria.Name = "c_Categoria"
        Me.c_Categoria.Text = "Categoria"
        Me.c_Categoria.Width.Absolute = 100
        '
        'c_Orden
        '
        Me.c_Orden.DataFieldName = "orden"
        Me.c_Orden.Name = "c_Orden"
        Me.c_Orden.Text = "Orden"
        Me.c_Orden.Width.Absolute = 50
        '
        'c_Nivel
        '
        Me.c_Nivel.DataFieldName = "nivel"
        Me.c_Nivel.Name = "c_Nivel"
        Me.c_Nivel.Text = "Nivel"
        Me.c_Nivel.Width.Absolute = 150
        '
        'cmbDepto
        '
        Me.cmbDepto.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbDepto.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbDepto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbDepto.ButtonDropDown.Visible = True
        Me.cmbDepto.Columns.Add(Me.codDepto)
        Me.cmbDepto.Columns.Add(Me.nomDepto)
        Me.cmbDepto.Enabled = False
        Me.cmbDepto.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbDepto.Location = New System.Drawing.Point(494, 11)
        Me.cmbDepto.Name = "cmbDepto"
        Me.cmbDepto.Size = New System.Drawing.Size(206, 21)
        Me.cmbDepto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbDepto.TabIndex = 136
        Me.cmbDepto.ValueMember = "cod_depto"
        Me.cmbDepto.Visible = False
        '
        'codDepto
        '
        Me.codDepto.DataFieldName = "COD_DEPTO"
        Me.codDepto.Name = "codDepto"
        Me.codDepto.Text = "Código"
        Me.codDepto.Width.Absolute = 45
        '
        'nomDepto
        '
        Me.nomDepto.DataFieldName = "NOMBRE"
        Me.nomDepto.Name = "nomDepto"
        Me.nomDepto.Text = "Departamento"
        Me.nomDepto.Width.Absolute = 250
        '
        'lblDep
        '
        Me.lblDep.AutoSize = True
        Me.lblDep.BackColor = System.Drawing.SystemColors.Window
        Me.lblDep.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDep.Location = New System.Drawing.Point(386, 14)
        Me.lblDep.Name = "lblDep"
        Me.lblDep.Size = New System.Drawing.Size(86, 15)
        Me.lblDep.TabIndex = 135
        Me.lblDep.Text = "Departamento"
        Me.lblDep.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Window
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(519, 74)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 15)
        Me.Label12.TabIndex = 134
        Me.Label12.Text = "Obligatorio"
        '
        'btnObligatorio
        '
        '
        '
        '
        Me.btnObligatorio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnObligatorio.Location = New System.Drawing.Point(612, 71)
        Me.btnObligatorio.Name = "btnObligatorio"
        Me.btnObligatorio.OffText = "No"
        Me.btnObligatorio.OnText = "Si"
        Me.btnObligatorio.Size = New System.Drawing.Size(84, 22)
        Me.btnObligatorio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnObligatorio.TabIndex = 133
        Me.btnObligatorio.Value = True
        Me.btnObligatorio.ValueObject = "Y"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Window
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(249, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(124, 15)
        Me.Label9.TabIndex = 130
        Me.Label9.Text = "Requiere Calificación"
        '
        'sbRequiereCalificacion
        '
        '
        '
        '
        Me.sbRequiereCalificacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sbRequiereCalificacion.Location = New System.Drawing.Point(385, 71)
        Me.sbRequiereCalificacion.Name = "sbRequiereCalificacion"
        Me.sbRequiereCalificacion.OffText = "No"
        Me.sbRequiereCalificacion.OnText = "Si"
        Me.sbRequiereCalificacion.Size = New System.Drawing.Size(84, 20)
        Me.sbRequiereCalificacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sbRequiereCalificacion.TabIndex = 129
        Me.sbRequiereCalificacion.Value = True
        Me.sbRequiereCalificacion.ValueObject = "Y"
        '
        'cmbTipo
        '
        Me.cmbTipo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbTipo.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbTipo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbTipo.ButtonDropDown.Visible = True
        Me.cmbTipo.Columns.Add(Me.ColumnHeader5)
        Me.cmbTipo.Columns.Add(Me.ColumnHeader6)
        Me.cmbTipo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbTipo.Location = New System.Drawing.Point(138, 334)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(438, 23)
        Me.cmbTipo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipo.TabIndex = 125
        Me.cmbTipo.ValueMember = "cod_tipo_curso"
        Me.cmbTipo.Visible = False
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DataFieldName = "cod_tipo_curso"
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.Text = "Column"
        Me.ColumnHeader5.Width.Absolute = 150
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.DataFieldName = "nombre"
        Me.ColumnHeader6.Name = "ColumnHeader6"
        Me.ColumnHeader6.Text = "Column"
        Me.ColumnHeader6.Width.Absolute = 150
        '
        'cmbClase
        '
        Me.cmbClase.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbClase.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbClase.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbClase.ButtonDropDown.Visible = True
        Me.cmbClase.Columns.Add(Me.ColumnHeader9)
        Me.cmbClase.Columns.Add(Me.ColumnHeader10)
        Me.cmbClase.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbClase.Location = New System.Drawing.Point(138, 363)
        Me.cmbClase.Name = "cmbClase"
        Me.cmbClase.Size = New System.Drawing.Size(438, 23)
        Me.cmbClase.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbClase.TabIndex = 126
        Me.cmbClase.ValueMember = "cod_clase_curso"
        Me.cmbClase.Visible = False
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.DataFieldName = "cod_clase_curso"
        Me.ColumnHeader9.Name = "ColumnHeader9"
        Me.ColumnHeader9.Text = "Column"
        Me.ColumnHeader9.Width.Absolute = 150
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.DataFieldName = "nombre"
        Me.ColumnHeader10.Name = "ColumnHeader10"
        Me.ColumnHeader10.Text = "Column"
        Me.ColumnHeader10.Width.Absolute = 150
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Window
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(386, 200)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 15)
        Me.Label10.TabIndex = 128
        Me.Label10.Text = "Objetivo"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Window
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(30, 200)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 15)
        Me.Label11.TabIndex = 127
        Me.Label11.Text = "Modalidad"
        '
        'lblActivar
        '
        Me.lblActivar.AutoSize = True
        Me.lblActivar.BackColor = System.Drawing.SystemColors.Window
        Me.lblActivar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblActivar.Location = New System.Drawing.Point(519, 103)
        Me.lblActivar.Name = "lblActivar"
        Me.lblActivar.Size = New System.Drawing.Size(82, 15)
        Me.lblActivar.TabIndex = 124
        Me.lblActivar.Text = "Activo/Inactivo"
        '
        'btnActivar
        '
        '
        '
        '
        Me.btnActivar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnActivar.Location = New System.Drawing.Point(612, 100)
        Me.btnActivar.Name = "btnActivar"
        Me.btnActivar.OffText = "Inactivo"
        Me.btnActivar.OnText = "Activo"
        Me.btnActivar.Size = New System.Drawing.Size(84, 22)
        Me.btnActivar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnActivar.TabIndex = 123
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Window
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(249, 103)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 15)
        Me.Label8.TabIndex = 122
        Me.Label8.Text = "Calif. mín. aprob."
        '
        'txtCalificacion
        '
        '
        '
        '
        Me.txtCalificacion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtCalificacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCalificacion.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtCalificacion.Increment = 5.0R
        Me.txtCalificacion.Location = New System.Drawing.Point(385, 100)
        Me.txtCalificacion.MaxValue = 100.0R
        Me.txtCalificacion.MinValue = 0.0R
        Me.txtCalificacion.Name = "txtCalificacion"
        Me.txtCalificacion.ShowUpDown = True
        Me.txtCalificacion.Size = New System.Drawing.Size(83, 20)
        Me.txtCalificacion.TabIndex = 6
        Me.txtCalificacion.Value = 50.0R
        '
        'txtOrdenMatriz
        '
        '
        '
        '
        Me.txtOrdenMatriz.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtOrdenMatriz.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtOrdenMatriz.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtOrdenMatriz.Increment = 10
        Me.txtOrdenMatriz.Location = New System.Drawing.Point(138, 128)
        Me.txtOrdenMatriz.MaxValue = 99999
        Me.txtOrdenMatriz.MinValue = 0
        Me.txtOrdenMatriz.Name = "txtOrdenMatriz"
        Me.txtOrdenMatriz.Size = New System.Drawing.Size(84, 20)
        Me.txtOrdenMatriz.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Window
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(30, 131)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 15)
        Me.Label7.TabIndex = 120
        Me.Label7.Text = "Orden en matriz"
        '
        'cmbModalidad
        '
        Me.cmbModalidad.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbModalidad.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbModalidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbModalidad.ButtonDropDown.Visible = True
        Me.cmbModalidad.Columns.Add(Me.ColumnHeader7)
        Me.cmbModalidad.Columns.Add(Me.ColumnHeader8)
        Me.cmbModalidad.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbModalidad.Location = New System.Drawing.Point(138, 196)
        Me.cmbModalidad.Name = "cmbModalidad"
        Me.cmbModalidad.Size = New System.Drawing.Size(206, 23)
        Me.cmbModalidad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbModalidad.TabIndex = 10
        Me.cmbModalidad.ValueMember = "modalidad"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.DataFieldName = "modalidad"
        Me.ColumnHeader7.Name = "ColumnHeader7"
        Me.ColumnHeader7.Text = "Código"
        Me.ColumnHeader7.Width.Absolute = 75
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.DataFieldName = "nombre"
        Me.ColumnHeader8.Name = "ColumnHeader8"
        Me.ColumnHeader8.Text = "Modalidad"
        Me.ColumnHeader8.Width.Absolute = 150
        '
        'cmbObjetivo
        '
        Me.cmbObjetivo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbObjetivo.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbObjetivo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbObjetivo.ButtonDropDown.Visible = True
        Me.cmbObjetivo.Columns.Add(Me.ColumnHeader3)
        Me.cmbObjetivo.Columns.Add(Me.ColumnHeader4)
        Me.cmbObjetivo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbObjetivo.Location = New System.Drawing.Point(492, 196)
        Me.cmbObjetivo.Name = "cmbObjetivo"
        Me.cmbObjetivo.Size = New System.Drawing.Size(206, 23)
        Me.cmbObjetivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbObjetivo.TabIndex = 11
        Me.cmbObjetivo.ValueMember = "objetivo"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DataFieldName = "objetivo"
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Código"
        Me.ColumnHeader3.Width.Absolute = 50
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DataFieldName = "nombre"
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "Objetivo"
        Me.ColumnHeader4.Width.Absolute = 150
        '
        'cmbAreaTematica
        '
        Me.cmbAreaTematica.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbAreaTematica.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbAreaTematica.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbAreaTematica.ButtonDropDown.Visible = True
        Me.cmbAreaTematica.Columns.Add(Me.ColumnHeader1)
        Me.cmbAreaTematica.Columns.Add(Me.ColumnHeader2)
        Me.cmbAreaTematica.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbAreaTematica.Location = New System.Drawing.Point(492, 165)
        Me.cmbAreaTematica.Name = "cmbAreaTematica"
        Me.cmbAreaTematica.Size = New System.Drawing.Size(206, 23)
        Me.cmbAreaTematica.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbAreaTematica.TabIndex = 9
        Me.cmbAreaTematica.ValueMember = "cod_area"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "cod_area"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Código"
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
        'txtCosto
        '
        '
        '
        '
        Me.txtCosto.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtCosto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCosto.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtCosto.Increment = 100.0R
        Me.txtCosto.Location = New System.Drawing.Point(138, 100)
        Me.txtCosto.MaxValue = 999999.0R
        Me.txtCosto.MinValue = 0.0R
        Me.txtCosto.Name = "txtCosto"
        Me.txtCosto.Size = New System.Drawing.Size(84, 20)
        Me.txtCosto.TabIndex = 4
        '
        'txtDuracion
        '
        '
        '
        '
        Me.txtDuracion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtDuracion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDuracion.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtDuracion.Increment = 0.5R
        Me.txtDuracion.Location = New System.Drawing.Point(138, 71)
        Me.txtDuracion.MaxValue = 9999.0R
        Me.txtDuracion.MinValue = 0.0R
        Me.txtDuracion.Name = "txtDuracion"
        Me.txtDuracion.Size = New System.Drawing.Size(84, 20)
        Me.txtDuracion.TabIndex = 3
        '
        'txtComentarios
        '
        '
        '
        '
        Me.txtComentarios.Border.Class = "TextBoxBorder"
        Me.txtComentarios.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtComentarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentarios.Location = New System.Drawing.Point(138, 239)
        Me.txtComentarios.MaxLength = 60
        Me.txtComentarios.Multiline = True
        Me.txtComentarios.Name = "txtComentarios"
        Me.txtComentarios.Size = New System.Drawing.Size(558, 27)
        Me.txtComentarios.TabIndex = 12
        '
        'lblComments
        '
        Me.lblComments.AutoSize = True
        Me.lblComments.BackColor = System.Drawing.SystemColors.Window
        Me.lblComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComments.Location = New System.Drawing.Point(30, 241)
        Me.lblComments.Name = "lblComments"
        Me.lblComments.Size = New System.Drawing.Size(77, 15)
        Me.lblComments.TabIndex = 111
        Me.lblComments.Text = "Comentarios"
        '
        'lblTematica
        '
        Me.lblTematica.AutoSize = True
        Me.lblTematica.BackColor = System.Drawing.SystemColors.Window
        Me.lblTematica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTematica.Location = New System.Drawing.Point(386, 165)
        Me.lblTematica.Name = "lblTematica"
        Me.lblTematica.Size = New System.Drawing.Size(82, 15)
        Me.lblTematica.TabIndex = 105
        Me.lblTematica.Text = "Área temática"
        '
        'lblClase
        '
        Me.lblClase.AllowDrop = True
        Me.lblClase.AutoSize = True
        Me.lblClase.BackColor = System.Drawing.SystemColors.Window
        Me.lblClase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClase.Location = New System.Drawing.Point(30, 366)
        Me.lblClase.Name = "lblClase"
        Me.lblClase.Size = New System.Drawing.Size(38, 15)
        Me.lblClase.TabIndex = 103
        Me.lblClase.Text = "Clase"
        Me.lblClase.Visible = False
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.BackColor = System.Drawing.SystemColors.Window
        Me.lblTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.Location = New System.Drawing.Point(30, 337)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(31, 15)
        Me.lblTipo.TabIndex = 101
        Me.lblTipo.Text = "Tipo"
        Me.lblTipo.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(30, 169)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 15)
        Me.Label6.TabIndex = 90
        Me.Label6.Text = "Clasificación"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(30, 103)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 15)
        Me.Label5.TabIndex = 88
        Me.Label5.Text = "Costo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(30, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 15)
        Me.Label4.TabIndex = 86
        Me.Label4.Text = "Duración (hrs.)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(249, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 15)
        Me.Label3.TabIndex = 84
        Me.Label3.Text = "Enviar a STPS"
        '
        'btnStps
        '
        '
        '
        '
        Me.btnStps.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnStps.Location = New System.Drawing.Point(385, 128)
        Me.btnStps.Name = "btnStps"
        Me.btnStps.OffText = "No"
        Me.btnStps.OnText = "Si"
        Me.btnStps.Size = New System.Drawing.Size(84, 22)
        Me.btnStps.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnStps.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 14)
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
        Me.txtCodigo.Location = New System.Drawing.Point(138, 11)
        Me.txtCodigo.MaxLength = 5
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(160, 21)
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
        Me.txtNombre.Location = New System.Drawing.Point(138, 40)
        Me.txtNombre.MaxLength = 150
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(438, 21)
        Me.txtNombre.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Nombre"
        '
        'tabEmpleado
        '
        Me.tabEmpleado.AttachedControl = Me.pnlDatos
        Me.tabEmpleado.GlobalItem = False
        Me.tabEmpleado.Name = "tabEmpleado"
        Me.tabEmpleado.Text = "Individual"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.dgTabla)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(752, 436)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.tabTabla
        '
        'dgTabla
        '
        Me.dgTabla.AllowUserToAddRows = False
        Me.dgTabla.AllowUserToDeleteRows = False
        Me.dgTabla.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTabla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(141, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTabla.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgTabla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTabla.EnableHeadersVisualStyles = False
        Me.dgTabla.GridColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.dgTabla.Location = New System.Drawing.Point(0, 0)
        Me.dgTabla.MultiSelect = False
        Me.dgTabla.Name = "dgTabla"
        Me.dgTabla.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTabla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgTabla.Size = New System.Drawing.Size(752, 436)
        Me.dgTabla.TabIndex = 0
        '
        'tabTabla
        '
        Me.tabTabla.AttachedControl = Me.SuperTabControlPanel2
        Me.tabTabla.GlobalItem = False
        Me.tabTabla.Name = "tabTabla"
        Me.tabTabla.Text = "Lista"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(56, 2)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(211, 40)
        Me.ReflectionLabel1.TabIndex = 70
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CURSOS</b></font>"
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
        Me.EmpNav.Location = New System.Drawing.Point(13, 490)
        Me.EmpNav.Name = "EmpNav"
        Me.EmpNav.Size = New System.Drawing.Size(825, 47)
        Me.EmpNav.TabIndex = 0
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
        Me.btnCerrar.Location = New System.Drawing.Point(722, 14)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(73, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 9
        Me.btnCerrar.Text = "Salir"
        '
        'btnPrimero
        '
        Me.btnPrimero.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrimero.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrimero.Image = Global.PIDA.My.Resources.Resources.First16
        Me.btnPrimero.Location = New System.Drawing.Point(29, 14)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(73, 25)
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
        Me.btnReporte.Location = New System.Drawing.Point(414, 14)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(73, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 5
        Me.btnReporte.Text = "Reporte"
        '
        'btnAnterior
        '
        Me.btnAnterior.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAnterior.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAnterior.Image = Global.PIDA.My.Resources.Resources.Prev16
        Me.btnAnterior.Location = New System.Drawing.Point(106, 14)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(73, 25)
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
        Me.btnBorrar.Location = New System.Drawing.Point(645, 14)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(73, 25)
        Me.btnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBorrar.TabIndex = 8
        Me.btnBorrar.Text = "Borrar"
        '
        'btnSiguiente
        '
        Me.btnSiguiente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSiguiente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSiguiente.Image = Global.PIDA.My.Resources.Resources.Next16
        Me.btnSiguiente.Location = New System.Drawing.Point(183, 14)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(73, 25)
        Me.btnSiguiente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSiguiente.TabIndex = 2
        Me.btnSiguiente.Text = "Siguiente"
        '
        'btnUltimo
        '
        Me.btnUltimo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnUltimo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnUltimo.Image = Global.PIDA.My.Resources.Resources.Last16
        Me.btnUltimo.Location = New System.Drawing.Point(260, 14)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(73, 25)
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
        Me.btnBuscar.Location = New System.Drawing.Point(337, 14)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(73, 25)
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
        Me.btnEditar.Location = New System.Drawing.Point(568, 14)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(73, 25)
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
        Me.btnNuevo.Location = New System.Drawing.Point(491, 14)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(73, 25)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 6
        Me.btnNuevo.Text = "Agregar"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Courses32
        Me.PictureBox1.Location = New System.Drawing.Point(12, 2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 40)
        Me.PictureBox1.TabIndex = 79
        Me.PictureBox1.TabStop = False
        '
        'frmCursos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 539)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.EmpNav)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.tabBuscar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCursos"
        Me.Text = "Cursos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBuscar.ResumeLayout(False)
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.txtCalificacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtOrdenMatriz, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDuracion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EmpNav.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabBuscar As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents pnlDatos As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents txtCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tabEmpleado As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents dgTabla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents tabTabla As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnStps As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents c_Orden As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents c_Nivel As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents txtComentarios As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblComments As System.Windows.Forms.Label
    Friend WithEvents lblTematica As System.Windows.Forms.Label
    Friend WithEvents lblClase As System.Windows.Forms.Label
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents txtCosto As DevComponents.Editors.DoubleInput
    Friend WithEvents txtDuracion As DevComponents.Editors.DoubleInput
    Friend WithEvents txtOrdenMatriz As DevComponents.Editors.IntegerInput
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbModalidad As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cmbObjetivo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cmbTipo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cmbClase As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cmbAreaTematica As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCalificacion As DevComponents.Editors.DoubleInput
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblActivar As System.Windows.Forms.Label
    Friend WithEvents btnActivar As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader6 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader9 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader10 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader7 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader8 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents sbRequiereCalificacion As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnObligatorio As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents cmbDepto As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents codDepto As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents nomDepto As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents lblDep As System.Windows.Forms.Label
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lblOrden As System.Windows.Forms.Label
    Friend WithEvents cmbOrdenNivel As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents c_Categoria As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents lblOrdenActual As System.Windows.Forms.Label
    Friend WithEvents cmbClasificacion As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents codClasif As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Nombre As DevComponents.AdvTree.ColumnHeader
End Class
