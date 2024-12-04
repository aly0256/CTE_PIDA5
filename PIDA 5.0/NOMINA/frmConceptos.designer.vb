<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConceptos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConceptos))
        Me.tabBuscar = New DevComponents.DotNetBar.SuperTabControl()
        Me.pnlDatos = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbTipos = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtEquivalenteSat = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbExento = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCodigoSat = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtMonto = New DevComponents.Editors.DoubleInput()
        Me.txtClaveMisc = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnMaestro = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnComparativo = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.IntPrioridad = New DevComponents.Editors.IntegerInput()
        Me.btnPositivo = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.btnAfecta = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbNaturaleza = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.txtNombreIngles = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBuscar.SuspendLayout()
        Me.pnlDatos.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.txtMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IntPrioridad, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.tabBuscar.Location = New System.Drawing.Point(12, 62)
        Me.tabBuscar.Name = "tabBuscar"
        Me.tabBuscar.ReorderTabsEnabled = True
        Me.tabBuscar.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabBuscar.SelectedTabIndex = 0
        Me.tabBuscar.Size = New System.Drawing.Size(825, 375)
        Me.tabBuscar.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.tabBuscar.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.TabIndex = 69
        Me.tabBuscar.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit
        Me.tabBuscar.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabEmpleado, Me.tabTabla})
        Me.tabBuscar.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.txtNombreIngles)
        Me.pnlDatos.Controls.Add(Me.Label7)
        Me.pnlDatos.Controls.Add(Me.Label14)
        Me.pnlDatos.Controls.Add(Me.cmbTipos)
        Me.pnlDatos.Controls.Add(Me.GroupPanel1)
        Me.pnlDatos.Controls.Add(Me.txtMonto)
        Me.pnlDatos.Controls.Add(Me.txtClaveMisc)
        Me.pnlDatos.Controls.Add(Me.Label10)
        Me.pnlDatos.Controls.Add(Me.Label9)
        Me.pnlDatos.Controls.Add(Me.btnMaestro)
        Me.pnlDatos.Controls.Add(Me.Label8)
        Me.pnlDatos.Controls.Add(Me.btnComparativo)
        Me.pnlDatos.Controls.Add(Me.Label4)
        Me.pnlDatos.Controls.Add(Me.IntPrioridad)
        Me.pnlDatos.Controls.Add(Me.btnPositivo)
        Me.pnlDatos.Controls.Add(Me.btnAfecta)
        Me.pnlDatos.Controls.Add(Me.Label3)
        Me.pnlDatos.Controls.Add(Me.Label5)
        Me.pnlDatos.Controls.Add(Me.Label6)
        Me.pnlDatos.Controls.Add(Me.lbl1)
        Me.pnlDatos.Controls.Add(Me.txtCodigo)
        Me.pnlDatos.Controls.Add(Me.txtNombre)
        Me.pnlDatos.Controls.Add(Me.Label2)
        Me.pnlDatos.Controls.Add(Me.cmbNaturaleza)
        Me.pnlDatos.Controls.Add(Me.Label1)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(754, 375)
        Me.pnlDatos.TabIndex = 0
        Me.pnlDatos.TabItem = Me.tabEmpleado
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.SystemColors.Window
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(30, 216)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 15)
        Me.Label14.TabIndex = 102
        Me.Label14.Text = "Tipo de dato"
        '
        'cmbTipos
        '
        Me.cmbTipos.DisplayMember = "Text"
        Me.cmbTipos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTipos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipos.FormattingEnabled = True
        Me.cmbTipos.ItemHeight = 14
        Me.cmbTipos.Location = New System.Drawing.Point(144, 213)
        Me.cmbTipos.Name = "cmbTipos"
        Me.cmbTipos.Size = New System.Drawing.Size(116, 20)
        Me.cmbTipos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipos.TabIndex = 7
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.SystemColors.Window
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel1.Controls.Add(Me.Label13)
        Me.GroupPanel1.Controls.Add(Me.txtEquivalenteSat)
        Me.GroupPanel1.Controls.Add(Me.Label12)
        Me.GroupPanel1.Controls.Add(Me.cmbExento)
        Me.GroupPanel1.Controls.Add(Me.Label11)
        Me.GroupPanel1.Controls.Add(Me.txtCodigoSat)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(19, 248)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(489, 114)
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
        Me.GroupPanel1.TabIndex = 12
        Me.GroupPanel1.Text = "CFDI"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.Window
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 62)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(96, 15)
        Me.Label13.TabIndex = 98
        Me.Label13.Text = "Equivalente SAT"
        '
        'txtEquivalenteSat
        '
        '
        '
        '
        Me.txtEquivalenteSat.Border.Class = "TextBoxBorder"
        Me.txtEquivalenteSat.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtEquivalenteSat.ButtonCustom.Tooltip = ""
        Me.txtEquivalenteSat.ButtonCustom2.Tooltip = ""
        Me.txtEquivalenteSat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEquivalenteSat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEquivalenteSat.Location = New System.Drawing.Point(115, 59)
        Me.txtEquivalenteSat.MaxLength = 10
        Me.txtEquivalenteSat.Name = "txtEquivalenteSat"
        Me.txtEquivalenteSat.Size = New System.Drawing.Size(123, 21)
        Me.txtEquivalenteSat.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Window
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 34)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 15)
        Me.Label12.TabIndex = 96
        Me.Label12.Text = "Parte exenta"
        '
        'cmbExento
        '
        Me.cmbExento.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbExento.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbExento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbExento.ButtonClear.Tooltip = ""
        Me.cmbExento.ButtonCustom.Tooltip = ""
        Me.cmbExento.ButtonCustom2.Tooltip = ""
        Me.cmbExento.ButtonDropDown.Tooltip = ""
        Me.cmbExento.ButtonDropDown.Visible = True
        Me.cmbExento.Columns.Add(Me.ColumnHeader3)
        Me.cmbExento.Columns.Add(Me.ColumnHeader4)
        Me.cmbExento.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbExento.Location = New System.Drawing.Point(115, 30)
        Me.cmbExento.Name = "cmbExento"
        Me.cmbExento.Size = New System.Drawing.Size(362, 23)
        Me.cmbExento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbExento.TabIndex = 1
        Me.cmbExento.ValueMember = "concepto"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DataFieldName = "concepto"
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Código"
        Me.ColumnHeader3.Width.Absolute = 50
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DataFieldName = "nombre"
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "Nombre"
        Me.ColumnHeader4.Width.Absolute = 150
        Me.ColumnHeader4.Width.AutoSize = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Window
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 15)
        Me.Label11.TabIndex = 94
        Me.Label11.Text = "Código SAT"
        '
        'txtCodigoSat
        '
        '
        '
        '
        Me.txtCodigoSat.Border.Class = "TextBoxBorder"
        Me.txtCodigoSat.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodigoSat.ButtonCustom.Tooltip = ""
        Me.txtCodigoSat.ButtonCustom2.Tooltip = ""
        Me.txtCodigoSat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigoSat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigoSat.Location = New System.Drawing.Point(115, 1)
        Me.txtCodigoSat.MaxLength = 3
        Me.txtCodigoSat.Name = "txtCodigoSat"
        Me.txtCodigoSat.Size = New System.Drawing.Size(123, 21)
        Me.txtCodigoSat.TabIndex = 0
        '
        'txtMonto
        '
        '
        '
        '
        Me.txtMonto.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtMonto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMonto.ButtonCalculator.Tooltip = ""
        Me.txtMonto.ButtonClear.Tooltip = ""
        Me.txtMonto.ButtonCustom.Tooltip = ""
        Me.txtMonto.ButtonCustom2.Tooltip = ""
        Me.txtMonto.ButtonDropDown.Tooltip = ""
        Me.txtMonto.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtMonto.ButtonFreeText.Tooltip = ""
        Me.txtMonto.Increment = 1.0R
        Me.txtMonto.Location = New System.Drawing.Point(194, 186)
        Me.txtMonto.MaxValue = 9999.0R
        Me.txtMonto.MinValue = 0.0R
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.ShowUpDown = True
        Me.txtMonto.Size = New System.Drawing.Size(66, 20)
        Me.txtMonto.TabIndex = 6
        '
        'txtClaveMisc
        '
        '
        '
        '
        Me.txtClaveMisc.Border.Class = "TextBoxBorder"
        Me.txtClaveMisc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtClaveMisc.ButtonCustom.Tooltip = ""
        Me.txtClaveMisc.ButtonCustom2.Tooltip = ""
        Me.txtClaveMisc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaveMisc.Location = New System.Drawing.Point(194, 158)
        Me.txtClaveMisc.MaxLength = 3
        Me.txtClaveMisc.Name = "txtClaveMisc"
        Me.txtClaveMisc.Size = New System.Drawing.Size(66, 21)
        Me.txtClaveMisc.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Window
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(30, 160)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(127, 15)
        Me.Label10.TabIndex = 92
        Me.Label10.Text = "Clave en misceláneos"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Window
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(30, 188)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(133, 15)
        Me.Label9.TabIndex = 90
        Me.Label9.Text = "Monto predeterminado"
        '
        'btnMaestro
        '
        '
        '
        '
        Me.btnMaestro.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnMaestro.Location = New System.Drawing.Point(433, 212)
        Me.btnMaestro.Name = "btnMaestro"
        Me.btnMaestro.OffText = "NO"
        Me.btnMaestro.OnText = "SI"
        Me.btnMaestro.Size = New System.Drawing.Size(66, 22)
        Me.btnMaestro.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnMaestro.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Window
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(277, 216)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(147, 15)
        Me.Label8.TabIndex = 87
        Me.Label8.Text = "Participa en mtro. de ded."
        '
        'btnComparativo
        '
        '
        '
        '
        Me.btnComparativo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnComparativo.Location = New System.Drawing.Point(433, 130)
        Me.btnComparativo.Name = "btnComparativo"
        Me.btnComparativo.OffText = "NO"
        Me.btnComparativo.OnText = "SI"
        Me.btnComparativo.Size = New System.Drawing.Size(66, 22)
        Me.btnComparativo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnComparativo.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(277, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(138, 15)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "Comparativo de nómina"
        '
        'IntPrioridad
        '
        '
        '
        '
        Me.IntPrioridad.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntPrioridad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntPrioridad.ButtonCalculator.Tooltip = ""
        Me.IntPrioridad.ButtonClear.Tooltip = ""
        Me.IntPrioridad.ButtonCustom.Tooltip = ""
        Me.IntPrioridad.ButtonCustom2.Tooltip = ""
        Me.IntPrioridad.ButtonDropDown.Tooltip = ""
        Me.IntPrioridad.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.IntPrioridad.ButtonFreeText.Tooltip = ""
        Me.IntPrioridad.Increment = 10
        Me.IntPrioridad.Location = New System.Drawing.Point(144, 131)
        Me.IntPrioridad.MaxValue = 99999
        Me.IntPrioridad.MinValue = 0
        Me.IntPrioridad.Name = "IntPrioridad"
        Me.IntPrioridad.ShowUpDown = True
        Me.IntPrioridad.Size = New System.Drawing.Size(116, 20)
        Me.IntPrioridad.TabIndex = 4
        '
        'btnPositivo
        '
        '
        '
        '
        Me.btnPositivo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnPositivo.Location = New System.Drawing.Point(433, 184)
        Me.btnPositivo.Name = "btnPositivo"
        Me.btnPositivo.OffText = "NO"
        Me.btnPositivo.OnText = "SI"
        Me.btnPositivo.Size = New System.Drawing.Size(66, 22)
        Me.btnPositivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPositivo.TabIndex = 10
        '
        'btnAfecta
        '
        '
        '
        '
        Me.btnAfecta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnAfecta.Location = New System.Drawing.Point(433, 156)
        Me.btnAfecta.Name = "btnAfecta"
        Me.btnAfecta.OffText = "NO"
        Me.btnAfecta.OnText = "SI"
        Me.btnAfecta.Size = New System.Drawing.Size(66, 22)
        Me.btnAfecta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAfecta.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(277, 188)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 15)
        Me.Label3.TabIndex = 84
        Me.Label3.Text = "Positivo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(277, 160)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 15)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "Afecta al neto"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(30, 134)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 15)
        Me.Label6.TabIndex = 78
        Me.Label6.Text = "Prioridad"
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.BackColor = System.Drawing.SystemColors.Window
        Me.lbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.Location = New System.Drawing.Point(30, 107)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(67, 15)
        Me.lbl1.TabIndex = 75
        Me.lbl1.Text = "Naturaleza"
        '
        'txtCodigo
        '
        '
        '
        '
        Me.txtCodigo.Border.Class = "TextBoxBorder"
        Me.txtCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodigo.ButtonCustom.Tooltip = ""
        Me.txtCodigo.ButtonCustom2.Tooltip = ""
        Me.txtCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(144, 22)
        Me.txtCodigo.MaxLength = 10
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(116, 21)
        Me.txtCodigo.TabIndex = 0
        '
        'txtNombre
        '
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.ButtonCustom.Tooltip = ""
        Me.txtNombre.ButtonCustom2.Tooltip = ""
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(144, 50)
        Me.txtNombre.MaxLength = 80
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(355, 21)
        Me.txtNombre.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 15)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Descripción"
        '
        'cmbNaturaleza
        '
        Me.cmbNaturaleza.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbNaturaleza.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbNaturaleza.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbNaturaleza.ButtonClear.Tooltip = ""
        Me.cmbNaturaleza.ButtonCustom.Tooltip = ""
        Me.cmbNaturaleza.ButtonCustom2.Tooltip = ""
        Me.cmbNaturaleza.ButtonDropDown.Tooltip = ""
        Me.cmbNaturaleza.ButtonDropDown.Visible = True
        Me.cmbNaturaleza.Columns.Add(Me.ColumnHeader1)
        Me.cmbNaturaleza.Columns.Add(Me.ColumnHeader2)
        Me.cmbNaturaleza.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbNaturaleza.Location = New System.Drawing.Point(144, 104)
        Me.cmbNaturaleza.Name = "cmbNaturaleza"
        Me.cmbNaturaleza.Size = New System.Drawing.Size(355, 20)
        Me.cmbNaturaleza.TabIndex = 3
        Me.cmbNaturaleza.ValueMember = "cod_naturaleza"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "cod_naturaleza"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Código"
        Me.ColumnHeader1.Width.Absolute = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "nombre"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.StretchToFill = True
        Me.ColumnHeader2.Text = "Naturaleza"
        Me.ColumnHeader2.Width.Absolute = 150
        Me.ColumnHeader2.Width.AutoSize = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 15)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Concepto"
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
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(754, 355)
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
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTabla.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgTabla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTabla.EnableHeadersVisualStyles = False
        Me.dgTabla.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
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
        Me.dgTabla.Size = New System.Drawing.Size(754, 355)
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
        Me.ReflectionLabel1.Location = New System.Drawing.Point(45, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(157, 40)
        Me.ReflectionLabel1.TabIndex = 70
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CONCEPTOS</b></font>"
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
        Me.EmpNav.Location = New System.Drawing.Point(12, 443)
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
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cancel16
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
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.catalog32
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.TabIndex = 79
        Me.PictureBox1.TabStop = False
        '
        'txtNombreIngles
        '
        '
        '
        '
        Me.txtNombreIngles.Border.Class = "TextBoxBorder"
        Me.txtNombreIngles.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombreIngles.ButtonCustom.Tooltip = ""
        Me.txtNombreIngles.ButtonCustom2.Tooltip = ""
        Me.txtNombreIngles.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreIngles.Location = New System.Drawing.Point(144, 77)
        Me.txtNombreIngles.MaxLength = 80
        Me.txtNombreIngles.Name = "txtNombreIngles"
        Me.txtNombreIngles.Size = New System.Drawing.Size(355, 21)
        Me.txtNombreIngles.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Window
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(30, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(108, 15)
        Me.Label7.TabIndex = 104
        Me.Label7.Text = "Descripción inglés"
        '
        'frmConceptos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 498)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.EmpNav)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.tabBuscar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConceptos"
        Me.Text = "Conceptos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBuscar.ResumeLayout(False)
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.txtMonto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IntPrioridad, System.ComponentModel.ISupportInitialize).EndInit()
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
    Private WithEvents cmbNaturaleza As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents IntPrioridad As DevComponents.Editors.IntegerInput
    Friend WithEvents btnPositivo As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents btnAfecta As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents btnComparativo As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMonto As DevComponents.Editors.DoubleInput
    Friend WithEvents txtClaveMisc As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnMaestro As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbTipos As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtEquivalenteSat As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbExento As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCodigoSat As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNombreIngles As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
