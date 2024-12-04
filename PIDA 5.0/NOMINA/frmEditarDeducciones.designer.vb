<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditarDeducciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditarDeducciones))
        Me.gpDatos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.txtSaldoActual = New DevComponents.Editors.DoubleInput()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.txtAbono = New DevComponents.Editors.DoubleInput()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.txtSaldoInicial = New DevComponents.Editors.DoubleInput()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.txtSemanas = New DevComponents.Editors.IntegerInput()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.cmbPeriodo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.txtNumCredito = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.cmbDeduccion = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnProrratear = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtAbonoActual = New DevComponents.Editors.DoubleInput()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtSaldoMes = New DevComponents.Editors.DoubleInput()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtAbonoMes = New DevComponents.Editors.DoubleInput()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnProrratearMes = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtSemRestan = New DevComponents.Editors.IntegerInput()
        Me.txtTasa = New DevComponents.Editors.DoubleInput()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ReflectionLabel2 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblEstado = New DevComponents.DotNetBar.LabelX()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.gpDatos.SuspendLayout()
        Me.Panel17.SuspendLayout()
        CType(Me.txtSaldoActual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel19.SuspendLayout()
        CType(Me.txtAbono, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel12.SuspendLayout()
        CType(Me.txtSaldoInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel15.SuspendLayout()
        CType(Me.txtSemanas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel10.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.txtAbonoActual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldoMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAbonoMes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSemRestan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTasa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpDatos
        '
        Me.gpDatos.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpDatos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpDatos.Controls.Add(Me.Panel17)
        Me.gpDatos.Controls.Add(Me.Panel18)
        Me.gpDatos.Controls.Add(Me.Panel19)
        Me.gpDatos.Controls.Add(Me.Panel20)
        Me.gpDatos.Controls.Add(Me.Panel12)
        Me.gpDatos.Controls.Add(Me.Panel14)
        Me.gpDatos.Controls.Add(Me.Panel15)
        Me.gpDatos.Controls.Add(Me.Panel16)
        Me.gpDatos.Controls.Add(Me.Panel10)
        Me.gpDatos.Controls.Add(Me.Panel11)
        Me.gpDatos.Controls.Add(Me.Panel9)
        Me.gpDatos.Controls.Add(Me.Panel8)
        Me.gpDatos.Controls.Add(Me.Panel7)
        Me.gpDatos.Controls.Add(Me.Panel1)
        Me.gpDatos.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gpDatos.Location = New System.Drawing.Point(0, 0)
        Me.gpDatos.Name = "gpDatos"
        Me.gpDatos.Padding = New System.Windows.Forms.Padding(10)
        Me.gpDatos.Size = New System.Drawing.Size(429, 224)
        '
        '
        '
        Me.gpDatos.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpDatos.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpDatos.Style.BackColorGradientAngle = 90
        Me.gpDatos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDatos.Style.BorderBottomWidth = 1
        Me.gpDatos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpDatos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDatos.Style.BorderLeftWidth = 1
        Me.gpDatos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDatos.Style.BorderRightWidth = 1
        Me.gpDatos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDatos.Style.BorderTopWidth = 1
        Me.gpDatos.Style.CornerDiameter = 4
        Me.gpDatos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpDatos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.gpDatos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpDatos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpDatos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpDatos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpDatos.TabIndex = 0
        '
        'Panel17
        '
        Me.Panel17.Controls.Add(Me.txtSaldoActual)
        Me.Panel17.Controls.Add(Me.Label10)
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel17.Location = New System.Drawing.Point(10, 190)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(407, 20)
        Me.Panel17.TabIndex = 275
        '
        'txtSaldoActual
        '
        '
        '
        '
        Me.txtSaldoActual.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtSaldoActual.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSaldoActual.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtSaldoActual.DisplayFormat = "C"
        Me.txtSaldoActual.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtSaldoActual.Enabled = False
        Me.txtSaldoActual.Increment = 1.0R
        Me.txtSaldoActual.Location = New System.Drawing.Point(75, 0)
        Me.txtSaldoActual.MinValue = 0.0R
        Me.txtSaldoActual.Name = "txtSaldoActual"
        Me.txtSaldoActual.Size = New System.Drawing.Size(91, 20)
        Me.txtSaldoActual.TabIndex = 9
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Window
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label10.Location = New System.Drawing.Point(0, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 20)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Saldo actual"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel18
        '
        Me.Panel18.BackColor = System.Drawing.Color.Transparent
        Me.Panel18.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel18.Location = New System.Drawing.Point(10, 180)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(407, 10)
        Me.Panel18.TabIndex = 274
        '
        'Panel19
        '
        Me.Panel19.Controls.Add(Me.txtAbono)
        Me.Panel19.Controls.Add(Me.Label4)
        Me.Panel19.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel19.Location = New System.Drawing.Point(10, 160)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(407, 20)
        Me.Panel19.TabIndex = 273
        '
        'txtAbono
        '
        '
        '
        '
        Me.txtAbono.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtAbono.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAbono.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtAbono.DisplayFormat = "C"
        Me.txtAbono.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtAbono.Enabled = False
        Me.txtAbono.Increment = 1.0R
        Me.txtAbono.Location = New System.Drawing.Point(75, 0)
        Me.txtAbono.MinValue = 0.0R
        Me.txtAbono.Name = "txtAbono"
        Me.txtAbono.Size = New System.Drawing.Size(91, 20)
        Me.txtAbono.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Abono"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel20
        '
        Me.Panel20.BackColor = System.Drawing.Color.Transparent
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel20.Location = New System.Drawing.Point(10, 150)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(407, 10)
        Me.Panel20.TabIndex = 272
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.txtSaldoInicial)
        Me.Panel12.Controls.Add(Me.Label6)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel12.Location = New System.Drawing.Point(10, 130)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(407, 20)
        Me.Panel12.TabIndex = 271
        '
        'txtSaldoInicial
        '
        '
        '
        '
        Me.txtSaldoInicial.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtSaldoInicial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSaldoInicial.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtSaldoInicial.DisplayFormat = "C"
        Me.txtSaldoInicial.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtSaldoInicial.Increment = 1.0R
        Me.txtSaldoInicial.Location = New System.Drawing.Point(75, 0)
        Me.txtSaldoInicial.MaxValue = 100000.0R
        Me.txtSaldoInicial.MinValue = 0.0R
        Me.txtSaldoInicial.Name = "txtSaldoInicial"
        Me.txtSaldoInicial.ShowUpDown = True
        Me.txtSaldoInicial.Size = New System.Drawing.Size(91, 20)
        Me.txtSaldoInicial.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 20)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Saldo inicial"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel14
        '
        Me.Panel14.BackColor = System.Drawing.Color.Transparent
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel14.Location = New System.Drawing.Point(10, 120)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(407, 10)
        Me.Panel14.TabIndex = 270
        '
        'Panel15
        '
        Me.Panel15.Controls.Add(Me.txtSemanas)
        Me.Panel15.Controls.Add(Me.Label7)
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel15.Location = New System.Drawing.Point(10, 100)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(407, 20)
        Me.Panel15.TabIndex = 269
        '
        'txtSemanas
        '
        '
        '
        '
        Me.txtSemanas.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtSemanas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSemanas.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtSemanas.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtSemanas.Location = New System.Drawing.Point(75, 0)
        Me.txtSemanas.MaxValue = 100000
        Me.txtSemanas.MinValue = 0
        Me.txtSemanas.Name = "txtSemanas"
        Me.txtSemanas.ShowUpDown = True
        Me.txtSemanas.Size = New System.Drawing.Size(91, 20)
        Me.txtSemanas.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Window
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 20)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "# Abonos"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel16
        '
        Me.Panel16.BackColor = System.Drawing.Color.Transparent
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel16.Location = New System.Drawing.Point(10, 90)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(407, 10)
        Me.Panel16.TabIndex = 268
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.cmbPeriodo)
        Me.Panel10.Controls.Add(Me.Label3)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(10, 70)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(407, 20)
        Me.Panel10.TabIndex = 267
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
        Me.cmbPeriodo.Columns.Add(Me.ColumnHeader4)
        Me.cmbPeriodo.Columns.Add(Me.ColumnHeader5)
        Me.cmbPeriodo.Columns.Add(Me.ColumnHeader1)
        Me.cmbPeriodo.Columns.Add(Me.ColumnHeader2)
        Me.cmbPeriodo.Columns.Add(Me.ColumnHeader3)
        Me.cmbPeriodo.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmbPeriodo.FormatString = "d"
        Me.cmbPeriodo.FormattingEnabled = True
        Me.cmbPeriodo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPeriodo.Location = New System.Drawing.Point(75, 0)
        Me.cmbPeriodo.Name = "cmbPeriodo"
        Me.cmbPeriodo.Size = New System.Drawing.Size(303, 20)
        Me.cmbPeriodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPeriodo.TabIndex = 5
        Me.cmbPeriodo.ValueMember = "unico"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DataFieldName = "unico"
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "Column"
        Me.ColumnHeader4.Visible = False
        Me.ColumnHeader4.Width.Absolute = 150
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DataFieldName = "ano"
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.Text = "Año"
        Me.ColumnHeader5.Width.Relative = 30
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "periodo"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Periodo"
        Me.ColumnHeader1.Width.Relative = 20
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "fecha_ini"
        Me.ColumnHeader2.EditorType = DevComponents.AdvTree.eCellEditorType.[Date]
        Me.ColumnHeader2.MaxInputLength = 10
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Fecha inicial"
        Me.ColumnHeader2.Width.Relative = 30
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DataFieldName = "fecha_fin"
        Me.ColumnHeader3.EditorType = DevComponents.AdvTree.eCellEditorType.[Date]
        Me.ColumnHeader3.MaxInputLength = 10
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Fecha final"
        Me.ColumnHeader3.Width.Relative = 30
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Año / Periodo"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.Transparent
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(10, 60)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(407, 10)
        Me.Panel11.TabIndex = 266
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.txtNumCredito)
        Me.Panel9.Controls.Add(Me.Label2)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(10, 40)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(407, 20)
        Me.Panel9.TabIndex = 265
        '
        'txtNumCredito
        '
        '
        '
        '
        Me.txtNumCredito.Border.Class = "TextBoxBorder"
        Me.txtNumCredito.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNumCredito.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtNumCredito.Enabled = False
        Me.txtNumCredito.Location = New System.Drawing.Point(75, 0)
        Me.txtNumCredito.MaxLength = 10
        Me.txtNumCredito.Name = "txtNumCredito"
        Me.txtNumCredito.Size = New System.Drawing.Size(91, 20)
        Me.txtNumCredito.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "# Crédito"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Transparent
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(10, 30)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(407, 10)
        Me.Panel8.TabIndex = 264
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.cmbDeduccion)
        Me.Panel7.Controls.Add(Me.Label1)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(10, 10)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(407, 20)
        Me.Panel7.TabIndex = 22
        '
        'cmbDeduccion
        '
        Me.cmbDeduccion.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbDeduccion.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbDeduccion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbDeduccion.ButtonDropDown.Visible = True
        Me.cmbDeduccion.DisplayMembers = "concepto"
        Me.cmbDeduccion.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmbDeduccion.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbDeduccion.Location = New System.Drawing.Point(75, 0)
        Me.cmbDeduccion.Name = "cmbDeduccion"
        Me.cmbDeduccion.Size = New System.Drawing.Size(303, 20)
        Me.cmbDeduccion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbDeduccion.TabIndex = 2
        Me.cmbDeduccion.ValueMember = "concepto"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Concepto"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.btnProrratear)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.txtAbonoActual)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.txtSaldoMes)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.txtAbonoMes)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.btnProrratearMes)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.txtSemRestan)
        Me.Panel1.Controls.Add(Me.txtTasa)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(10, 195)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(407, 17)
        Me.Panel1.TabIndex = 21
        Me.Panel1.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Window
        Me.Label9.Location = New System.Drawing.Point(13, 11)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Tasa de int. sem."
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.SystemColors.Window
        Me.Label18.Location = New System.Drawing.Point(13, 64)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(101, 13)
        Me.Label18.TabIndex = 20
        Me.Label18.Text = "Prorrateo saldo total"
        '
        'btnProrratear
        '
        '
        '
        '
        Me.btnProrratear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnProrratear.Location = New System.Drawing.Point(117, 59)
        Me.btnProrratear.Name = "btnProrratear"
        Me.btnProrratear.OffText = "NO"
        Me.btnProrratear.OffTextColor = System.Drawing.SystemColors.WindowText
        Me.btnProrratear.OnText = "SI"
        Me.btnProrratear.OnTextColor = System.Drawing.SystemColors.WindowText
        Me.btnProrratear.Size = New System.Drawing.Size(91, 22)
        Me.btnProrratear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnProrratear.TabIndex = 9
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.Window
        Me.Label13.Location = New System.Drawing.Point(13, 37)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(83, 13)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "Semanas restan"
        '
        'txtAbonoActual
        '
        '
        '
        '
        Me.txtAbonoActual.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtAbonoActual.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAbonoActual.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtAbonoActual.DisplayFormat = "C"
        Me.txtAbonoActual.Increment = 1.0R
        Me.txtAbonoActual.Location = New System.Drawing.Point(117, 167)
        Me.txtAbonoActual.MaxValue = 99999.0R
        Me.txtAbonoActual.MinValue = 0.0R
        Me.txtAbonoActual.Name = "txtAbonoActual"
        Me.txtAbonoActual.ShowUpDown = True
        Me.txtAbonoActual.Size = New System.Drawing.Size(89, 20)
        Me.txtAbonoActual.TabIndex = 13
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.SystemColors.Window
        Me.Label14.Location = New System.Drawing.Point(13, 92)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(92, 13)
        Me.Label14.TabIndex = 16
        Me.Label14.Text = "Prorrateo mensual"
        '
        'txtSaldoMes
        '
        '
        '
        '
        Me.txtSaldoMes.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtSaldoMes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSaldoMes.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtSaldoMes.DisplayFormat = "C"
        Me.txtSaldoMes.Increment = 1.0R
        Me.txtSaldoMes.Location = New System.Drawing.Point(117, 141)
        Me.txtSaldoMes.MaxValue = 99999.0R
        Me.txtSaldoMes.MinValue = 0.0R
        Me.txtSaldoMes.Name = "txtSaldoMes"
        Me.txtSaldoMes.ShowUpDown = True
        Me.txtSaldoMes.Size = New System.Drawing.Size(89, 20)
        Me.txtSaldoMes.TabIndex = 12
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.SystemColors.Window
        Me.Label15.Location = New System.Drawing.Point(13, 119)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(80, 13)
        Me.Label15.TabIndex = 17
        Me.Label15.Text = "Abono mensual"
        '
        'txtAbonoMes
        '
        '
        '
        '
        Me.txtAbonoMes.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtAbonoMes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAbonoMes.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtAbonoMes.DisplayFormat = "C"
        Me.txtAbonoMes.Increment = 1.0R
        Me.txtAbonoMes.Location = New System.Drawing.Point(117, 115)
        Me.txtAbonoMes.MaxValue = 99999.0R
        Me.txtAbonoMes.MinValue = 0.0R
        Me.txtAbonoMes.Name = "txtAbonoMes"
        Me.txtAbonoMes.ShowUpDown = True
        Me.txtAbonoMes.Size = New System.Drawing.Size(89, 20)
        Me.txtAbonoMes.TabIndex = 11
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.SystemColors.Window
        Me.Label16.Location = New System.Drawing.Point(13, 145)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(76, 13)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "Saldo mensual"
        '
        'btnProrratearMes
        '
        '
        '
        '
        Me.btnProrratearMes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnProrratearMes.Location = New System.Drawing.Point(117, 87)
        Me.btnProrratearMes.Name = "btnProrratearMes"
        Me.btnProrratearMes.OffText = "NO"
        Me.btnProrratearMes.OffTextColor = System.Drawing.SystemColors.WindowText
        Me.btnProrratearMes.OnText = "SI"
        Me.btnProrratearMes.OnTextColor = System.Drawing.SystemColors.WindowText
        Me.btnProrratearMes.Size = New System.Drawing.Size(91, 22)
        Me.btnProrratearMes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnProrratearMes.TabIndex = 10
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.SystemColors.Window
        Me.Label17.Location = New System.Drawing.Point(13, 171)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(95, 13)
        Me.Label17.TabIndex = 19
        Me.Label17.Text = "Abono sem. actual"
        '
        'txtSemRestan
        '
        '
        '
        '
        Me.txtSemRestan.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtSemRestan.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSemRestan.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtSemRestan.Location = New System.Drawing.Point(117, 33)
        Me.txtSemRestan.MaxValue = 104
        Me.txtSemRestan.MinValue = 0
        Me.txtSemRestan.Name = "txtSemRestan"
        Me.txtSemRestan.ShowUpDown = True
        Me.txtSemRestan.Size = New System.Drawing.Size(91, 20)
        Me.txtSemRestan.TabIndex = 8
        '
        'txtTasa
        '
        '
        '
        '
        Me.txtTasa.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtTasa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTasa.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtTasa.Increment = 1.0R
        Me.txtTasa.Location = New System.Drawing.Point(117, 7)
        Me.txtTasa.MaxValue = 100.0R
        Me.txtTasa.MinValue = 0.0R
        Me.txtTasa.Name = "txtTasa"
        Me.txtTasa.ShowUpDown = True
        Me.txtTasa.Size = New System.Drawing.Size(91, 20)
        Me.txtTasa.TabIndex = 7
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnAceptar)
        Me.GroupBox2.Controls.Add(Me.Panel13)
        Me.GroupBox2.Controls.Add(Me.btnCerrar)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(10, 354)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(10, 0, 10, 8)
        Me.GroupBox2.Size = New System.Drawing.Size(429, 46)
        Me.GroupBox2.TabIndex = 261
        Me.GroupBox2.TabStop = False
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.acept_
        Me.btnAceptar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnAceptar.ImageTextSpacing = 3
        Me.btnAceptar.Location = New System.Drawing.Point(232, 13)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(90, 25)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 261
        Me.btnAceptar.Text = "Aceptar"
        '
        'Panel13
        '
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel13.Location = New System.Drawing.Point(322, 13)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(7, 25)
        Me.Panel13.TabIndex = 260
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.salir_
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.ImageTextSpacing = 3
        Me.btnCerrar.Location = New System.Drawing.Point(329, 13)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(90, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 259
        Me.btnCerrar.Text = "Salir"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.lblEstado)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(10, 10)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(429, 110)
        Me.Panel2.TabIndex = 262
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtNombre)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(29, 56)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(10, 0, 0, 10)
        Me.Panel3.Size = New System.Drawing.Size(400, 54)
        Me.Panel3.TabIndex = 253
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.Color.Black
        Me.txtNombre.Location = New System.Drawing.Point(10, 20)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(382, 21)
        Me.txtNombre.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(390, 20)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Nombre"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.ReflectionLabel2)
        Me.Panel4.Controls.Add(Me.GroupBox3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(29, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(400, 56)
        Me.Panel4.TabIndex = 2
        '
        'ReflectionLabel2
        '
        '
        '
        '
        Me.ReflectionLabel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel2.BackgroundStyle.PaddingLeft = 10
        Me.ReflectionLabel2.BackgroundStyle.PaddingTop = 10
        Me.ReflectionLabel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.ReflectionLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel2.Location = New System.Drawing.Point(0, 0)
        Me.ReflectionLabel2.Name = "ReflectionLabel2"
        Me.ReflectionLabel2.Size = New System.Drawing.Size(199, 56)
        Me.ReflectionLabel2.TabIndex = 1
        Me.ReflectionLabel2.Text = "<font color=""#1F497D""><b>DEDUCCIONES</b></font>"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.LabelX1)
        Me.GroupBox3.Controls.Add(Me.txtReloj)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox3.Location = New System.Drawing.Point(229, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(171, 56)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(11, 17)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(56, 23)
        Me.LabelX1.TabIndex = 0
        Me.LabelX1.Text = "Reloj"
        '
        'txtReloj
        '
        Me.txtReloj.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.Enabled = False
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.ForeColor = System.Drawing.Color.Black
        Me.txtReloj.Location = New System.Drawing.Point(79, 15)
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.ReadOnly = True
        Me.txtReloj.Size = New System.Drawing.Size(84, 26)
        Me.txtReloj.TabIndex = 1
        Me.txtReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.Color.Green
        '
        '
        '
        Me.lblEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblEstado.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblEstado.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Window
        Me.lblEstado.Location = New System.Drawing.Point(0, 0)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(29, 110)
        Me.lblEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblEstado.TabIndex = 1
        Me.lblEstado.Text = "ACTIVO"
        Me.lblEstado.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblEstado.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.lblEstado.VerticalTextTopUp = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(10, 120)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(429, 10)
        Me.Panel5.TabIndex = 263
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.Controls.Add(Me.gpDatos)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(10, 130)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(429, 224)
        Me.Panel6.TabIndex = 264
        '
        'frmEditarDeducciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(449, 410)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditarDeducciones"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar/Agregar"
        Me.gpDatos.ResumeLayout(False)
        Me.Panel17.ResumeLayout(False)
        CType(Me.txtSaldoActual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel19.ResumeLayout(False)
        CType(Me.txtAbono, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel12.ResumeLayout(False)
        CType(Me.txtSaldoInicial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel15.ResumeLayout(False)
        CType(Me.txtSemanas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel10.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtAbonoActual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldoMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAbonoMes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSemRestan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTasa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpDatos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnProrratear As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents txtAbonoActual As DevComponents.Editors.DoubleInput
    Friend WithEvents txtSaldoMes As DevComponents.Editors.DoubleInput
    Friend WithEvents txtAbonoMes As DevComponents.Editors.DoubleInput
    Friend WithEvents btnProrratearMes As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents txtSemRestan As DevComponents.Editors.IntegerInput
    Friend WithEvents txtTasa As DevComponents.Editors.DoubleInput
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents ReflectionLabel2 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblEstado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel17 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel18 As System.Windows.Forms.Panel
    Friend WithEvents Panel19 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel20 As System.Windows.Forms.Panel
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents txtSemanas As DevComponents.Editors.IntegerInput
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents cmbPeriodo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents txtNumCredito As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents cmbDeduccion As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents txtSaldoActual As DevComponents.Editors.DoubleInput
    Friend WithEvents txtAbono As DevComponents.Editors.DoubleInput
    Friend WithEvents txtSaldoInicial As DevComponents.Editors.DoubleInput
End Class
