<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModSalEdicion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModSalEdicion))
        Me.txtAlta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtDepto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPuesto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.lblEstado = New DevComponents.DotNetBar.LabelX()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.picFoto = New System.Windows.Forms.PictureBox()
        Me.gpSueldos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.txtFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbTipoModSal = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Codigo = New DevComponents.AdvTree.ColumnHeader()
        Me.Nombre = New DevComponents.AdvTree.ColumnHeader()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbNivel = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.NivelCodigo = New DevComponents.AdvTree.ColumnHeader()
        Me.NivelNombre = New DevComponents.AdvTree.ColumnHeader()
        Me.Sueldo = New DevComponents.AdvTree.ColumnHeader()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtFactorInt = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtCambioA = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtIntegrado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtProVar = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNotas = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSueldoActual = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.txtComp = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtTipo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnBusca = New DevComponents.DotNetBar.ButtonX()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpSueldos.SuspendLayout()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtAlta
        '
        Me.txtAlta.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtAlta.Border.Class = "TextBoxBorder"
        Me.txtAlta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtAlta.Location = New System.Drawing.Point(375, 123)
        Me.txtAlta.Name = "txtAlta"
        Me.txtAlta.ReadOnly = True
        Me.txtAlta.Size = New System.Drawing.Size(110, 21)
        Me.txtAlta.TabIndex = 88
        '
        'txtDepto
        '
        Me.txtDepto.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtDepto.Border.Class = "TextBoxBorder"
        Me.txtDepto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDepto.Location = New System.Drawing.Point(123, 96)
        Me.txtDepto.Name = "txtDepto"
        Me.txtDepto.ReadOnly = True
        Me.txtDepto.Size = New System.Drawing.Size(362, 21)
        Me.txtDepto.TabIndex = 86
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(29, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 15)
        Me.Label4.TabIndex = 87
        Me.Label4.Text = "Departamento"
        '
        'txtPuesto
        '
        Me.txtPuesto.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtPuesto.Border.Class = "TextBoxBorder"
        Me.txtPuesto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPuesto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPuesto.Location = New System.Drawing.Point(123, 69)
        Me.txtPuesto.Name = "txtPuesto"
        Me.txtPuesto.ReadOnly = True
        Me.txtPuesto.Size = New System.Drawing.Size(362, 21)
        Me.txtPuesto.TabIndex = 84
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(29, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 15)
        Me.Label3.TabIndex = 85
        Me.Label3.Text = "Puesto"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(281, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 15)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Fecha de alta"
        '
        'txtReloj
        '
        Me.txtReloj.AcceptsReturn = True
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.Location = New System.Drawing.Point(123, 12)
        Me.txtReloj.MaxLength = 6
        Me.txtReloj.Multiline = True
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.Size = New System.Drawing.Size(84, 26)
        Me.txtReloj.TabIndex = 0
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(29, 12)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(84, 23)
        Me.LabelX4.TabIndex = 82
        Me.LabelX4.Text = "Reloj"
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
        Me.lblEstado.Size = New System.Drawing.Size(23, 425)
        Me.lblEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblEstado.TabIndex = 78
        Me.lblEstado.Text = "ACTIVO"
        Me.lblEstado.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblEstado.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.lblEstado.VerticalTextTopUp = False
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNombre.Location = New System.Drawing.Point(123, 41)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(362, 23)
        Me.txtNombre.TabIndex = 75
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(26, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 17)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "Nombre"
        '
        'picFoto
        '
        Me.picFoto.BackColor = System.Drawing.SystemColors.Control
        Me.picFoto.ErrorImage = Global.PIDA.My.Resources.Resources.NoFoto
        Me.picFoto.Image = Global.PIDA.My.Resources.Resources.NoFoto
        Me.picFoto.Location = New System.Drawing.Point(491, 19)
        Me.picFoto.Name = "picFoto"
        Me.picFoto.Size = New System.Drawing.Size(95, 120)
        Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picFoto.TabIndex = 76
        Me.picFoto.TabStop = False
        '
        'gpSueldos
        '
        Me.gpSueldos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpSueldos.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpSueldos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpSueldos.Controls.Add(Me.txtFecha)
        Me.gpSueldos.Controls.Add(Me.Label7)
        Me.gpSueldos.Controls.Add(Me.cmbTipoModSal)
        Me.gpSueldos.Controls.Add(Me.Label6)
        Me.gpSueldos.Controls.Add(Me.cmbNivel)
        Me.gpSueldos.Controls.Add(Me.Label21)
        Me.gpSueldos.Controls.Add(Me.txtFactorInt)
        Me.gpSueldos.Controls.Add(Me.Label22)
        Me.gpSueldos.Controls.Add(Me.txtCambioA)
        Me.gpSueldos.Controls.Add(Me.Label19)
        Me.gpSueldos.Controls.Add(Me.txtIntegrado)
        Me.gpSueldos.Controls.Add(Me.Label20)
        Me.gpSueldos.Controls.Add(Me.txtProVar)
        Me.gpSueldos.Controls.Add(Me.Label5)
        Me.gpSueldos.Controls.Add(Me.txtNotas)
        Me.gpSueldos.Controls.Add(Me.Label18)
        Me.gpSueldos.Controls.Add(Me.Label12)
        Me.gpSueldos.Controls.Add(Me.txtSueldoActual)
        Me.gpSueldos.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpSueldos.Location = New System.Drawing.Point(29, 157)
        Me.gpSueldos.Name = "gpSueldos"
        Me.gpSueldos.Size = New System.Drawing.Size(557, 208)
        '
        '
        '
        Me.gpSueldos.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpSueldos.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpSueldos.Style.BackColorGradientAngle = 90
        Me.gpSueldos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpSueldos.Style.BorderBottomWidth = 1
        Me.gpSueldos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpSueldos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpSueldos.Style.BorderLeftWidth = 1
        Me.gpSueldos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpSueldos.Style.BorderRightWidth = 1
        Me.gpSueldos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpSueldos.Style.BorderTopWidth = 1
        Me.gpSueldos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpSueldos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpSueldos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpSueldos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpSueldos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpSueldos.TabIndex = 1
        Me.gpSueldos.Text = "Sueldos"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha.ButtonDropDown.Visible = True
        Me.txtFecha.DisabledForeColor = System.Drawing.Color.Black
        Me.txtFecha.FocusHighlightEnabled = True
        Me.txtFecha.IsPopupCalendarOpen = False
        Me.txtFecha.Location = New System.Drawing.Point(113, 108)
        '
        '
        '
        Me.txtFecha.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFecha.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtFecha.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtFecha.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha.MonthCalendar.DisplayMonth = New Date(2007, 10, 1, 0, 0, 0, 0)
        Me.txtFecha.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFecha.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFecha.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFecha.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFecha.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFecha.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha.MonthCalendar.TodayButtonVisible = True
        Me.txtFecha.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(141, 20)
        Me.txtFecha.TabIndex = 4
        Me.txtFecha.Value = New Date(2007, 7, 7, 0, 0, 0, 0)
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Window
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 15)
        Me.Label7.TabIndex = 77
        Me.Label7.Text = "Sueldo actual"
        '
        'cmbTipoModSal
        '
        Me.cmbTipoModSal.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbTipoModSal.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbTipoModSal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbTipoModSal.ButtonDropDown.Visible = True
        Me.cmbTipoModSal.Columns.Add(Me.Codigo)
        Me.cmbTipoModSal.Columns.Add(Me.Nombre)
        Me.cmbTipoModSal.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbTipoModSal.Location = New System.Drawing.Point(113, 27)
        Me.cmbTipoModSal.Name = "cmbTipoModSal"
        Me.cmbTipoModSal.Size = New System.Drawing.Size(424, 23)
        Me.cmbTipoModSal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipoModSal.TabIndex = 1
        Me.cmbTipoModSal.ValueMember = "cod_tipo_mod"
        '
        'Codigo
        '
        Me.Codigo.DataFieldName = "cod_tipo_mod"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.Text = "Código"
        Me.Codigo.Width.Absolute = 50
        '
        'Nombre
        '
        Me.Nombre.DataFieldName = "nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.StretchToFill = True
        Me.Nombre.Text = "Nombre"
        Me.Nombre.Width.Absolute = 150
        Me.Nombre.Width.AutoSize = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 15)
        Me.Label6.TabIndex = 74
        Me.Label6.Text = "Tipo mod. sueldo"
        '
        'cmbNivel
        '
        Me.cmbNivel.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbNivel.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbNivel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbNivel.ButtonDropDown.Visible = True
        Me.cmbNivel.Columns.Add(Me.NivelCodigo)
        Me.cmbNivel.Columns.Add(Me.NivelNombre)
        Me.cmbNivel.Columns.Add(Me.Sueldo)
        Me.cmbNivel.DisplayMembers = "nivel"
        Me.cmbNivel.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbNivel.Location = New System.Drawing.Point(113, 54)
        Me.cmbNivel.Name = "cmbNivel"
        Me.cmbNivel.Size = New System.Drawing.Size(141, 23)
        Me.cmbNivel.TabIndex = 2
        Me.cmbNivel.ValueMember = "nivel"
        '
        'NivelCodigo
        '
        Me.NivelCodigo.DataFieldName = "nivel"
        Me.NivelCodigo.Name = "NivelCodigo"
        Me.NivelCodigo.Text = "Código"
        Me.NivelCodigo.Width.Absolute = 50
        '
        'NivelNombre
        '
        Me.NivelNombre.DataFieldName = "nombre"
        Me.NivelNombre.Name = "NivelNombre"
        Me.NivelNombre.Text = "Nombre"
        Me.NivelNombre.Width.Absolute = 50
        Me.NivelNombre.Width.AutoSize = True
        '
        'Sueldo
        '
        Me.Sueldo.DataFieldName = "sueldo"
        Me.Sueldo.Name = "Sueldo"
        Me.Sueldo.Text = "Sueldo"
        Me.Sueldo.Width.Absolute = 50
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.SystemColors.Window
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(268, 111)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(122, 15)
        Me.Label21.TabIndex = 73
        Me.Label21.Text = "Factor de integración"
        '
        'txtFactorInt
        '
        Me.txtFactorInt.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtFactorInt.Border.Class = "TextBoxBorder"
        Me.txtFactorInt.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFactorInt.Enabled = False
        Me.txtFactorInt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFactorInt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFactorInt.Location = New System.Drawing.Point(396, 108)
        Me.txtFactorInt.Name = "txtFactorInt"
        Me.txtFactorInt.Size = New System.Drawing.Size(141, 21)
        Me.txtFactorInt.TabIndex = 8
        Me.txtFactorInt.Text = "0.0000"
        Me.txtFactorInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.SystemColors.Window
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(3, 85)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(63, 15)
        Me.Label22.TabIndex = 71
        Me.Label22.Text = "Cambio a:"
        '
        'txtCambioA
        '
        Me.txtCambioA.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtCambioA.Border.Class = "TextBoxBorder"
        Me.txtCambioA.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCambioA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCambioA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCambioA.Location = New System.Drawing.Point(113, 81)
        Me.txtCambioA.Name = "txtCambioA"
        Me.txtCambioA.Size = New System.Drawing.Size(141, 23)
        Me.txtCambioA.TabIndex = 3
        Me.txtCambioA.Text = "0.00"
        Me.txtCambioA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.SystemColors.Window
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(268, 84)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(101, 15)
        Me.Label19.TabIndex = 69
        Me.Label19.Text = "Salario integrado"
        '
        'txtIntegrado
        '
        Me.txtIntegrado.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtIntegrado.Border.Class = "TextBoxBorder"
        Me.txtIntegrado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtIntegrado.Enabled = False
        Me.txtIntegrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIntegrado.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtIntegrado.Location = New System.Drawing.Point(396, 81)
        Me.txtIntegrado.Name = "txtIntegrado"
        Me.txtIntegrado.Size = New System.Drawing.Size(141, 21)
        Me.txtIntegrado.TabIndex = 7
        Me.txtIntegrado.Text = "0.00"
        Me.txtIntegrado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.SystemColors.Window
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(268, 57)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(107, 15)
        Me.Label20.TabIndex = 67
        Me.Label20.Text = "Promedio variable"
        '
        'txtProVar
        '
        Me.txtProVar.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtProVar.Border.Class = "TextBoxBorder"
        Me.txtProVar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtProVar.Enabled = False
        Me.txtProVar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProVar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtProVar.Location = New System.Drawing.Point(396, 54)
        Me.txtProVar.Name = "txtProVar"
        Me.txtProVar.Size = New System.Drawing.Size(141, 21)
        Me.txtProVar.TabIndex = 6
        Me.txtProVar.Text = "0.00"
        Me.txtProVar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 15)
        Me.Label5.TabIndex = 65
        Me.Label5.Text = "Notas"
        '
        'txtNotas
        '
        Me.txtNotas.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtNotas.Border.Class = "TextBoxBorder"
        Me.txtNotas.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotas.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNotas.Location = New System.Drawing.Point(113, 132)
        Me.txtNotas.MaxLength = 200
        Me.txtNotas.Multiline = True
        Me.txtNotas.Name = "txtNotas"
        Me.txtNotas.Size = New System.Drawing.Size(424, 48)
        Me.txtNotas.TabIndex = 5
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.SystemColors.Window
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(3, 111)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(41, 15)
        Me.Label18.TabIndex = 63
        Me.Label18.Text = "Fecha"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Window
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 58)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 15)
        Me.Label12.TabIndex = 60
        Me.Label12.Text = "Nivel"
        '
        'txtSueldoActual
        '
        Me.txtSueldoActual.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtSueldoActual.Border.Class = "TextBoxBorder"
        Me.txtSueldoActual.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSueldoActual.Enabled = False
        Me.txtSueldoActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSueldoActual.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtSueldoActual.Location = New System.Drawing.Point(113, 0)
        Me.txtSueldoActual.Name = "txtSueldoActual"
        Me.txtSueldoActual.ReadOnly = True
        Me.txtSueldoActual.Size = New System.Drawing.Size(141, 23)
        Me.txtSueldoActual.TabIndex = 0
        Me.txtSueldoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelar.Location = New System.Drawing.Point(170, 14)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.Location = New System.Drawing.Point(88, 14)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscar.Location = New System.Drawing.Point(6, 14)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(78, 25)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 0
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Tooltip = "Buscar"
        Me.btnBuscar.Visible = False
        '
        'txtComp
        '
        Me.txtComp.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtComp.Border.Class = "TextBoxBorder"
        Me.txtComp.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtComp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtComp.Location = New System.Drawing.Point(375, 15)
        Me.txtComp.Name = "txtComp"
        Me.txtComp.ReadOnly = True
        Me.txtComp.Size = New System.Drawing.Size(110, 21)
        Me.txtComp.TabIndex = 90
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(300, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 15)
        Me.Label8.TabIndex = 89
        Me.Label8.Text = "Compañía"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.btnAceptar)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Location = New System.Drawing.Point(329, 371)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(257, 47)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'txtTipo
        '
        Me.txtTipo.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtTipo.Border.Class = "TextBoxBorder"
        Me.txtTipo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTipo.Location = New System.Drawing.Point(123, 123)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.ReadOnly = True
        Me.txtTipo.Size = New System.Drawing.Size(110, 21)
        Me.txtTipo.TabIndex = 93
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(29, 126)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 15)
        Me.Label9.TabIndex = 92
        Me.Label9.Text = "Tipo"
        '
        'btnBusca
        '
        Me.btnBusca.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBusca.CausesValidation = False
        Me.btnBusca.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBusca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBusca.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBusca.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBusca.Location = New System.Drawing.Point(213, 13)
        Me.btnBusca.Name = "btnBusca"
        Me.btnBusca.Size = New System.Drawing.Size(26, 25)
        Me.btnBusca.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBusca.TabIndex = 94
        Me.btnBusca.Tooltip = "Buscar"
        '
        'frmModSalEdicion
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(593, 425)
        Me.Controls.Add(Me.btnBusca)
        Me.Controls.Add(Me.txtTipo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtComp)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.gpSueldos)
        Me.Controls.Add(Me.txtAlta)
        Me.Controls.Add(Me.txtDepto)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPuesto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtReloj)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.picFoto)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmModSalEdicion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Modificaciones de sueldo"
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpSueldos.ResumeLayout(False)
        Me.gpSueldos.PerformLayout()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtAlta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtDepto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPuesto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblEstado As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents picFoto As System.Windows.Forms.PictureBox
    Private WithEvents gpSueldos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmbTipoModSal As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Codigo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Nombre As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents cmbNivel As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtFactorInt As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtCambioA As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtIntegrado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtProVar As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNotas As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSueldoActual As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtComp As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents NivelCodigo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NivelNombre As DevComponents.AdvTree.ColumnHeader
    Private WithEvents txtFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtTipo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Sueldo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents btnBusca As DevComponents.DotNetBar.ButtonX
End Class
