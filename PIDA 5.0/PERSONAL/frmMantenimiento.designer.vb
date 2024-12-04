<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMantenimiento
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMantenimiento))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.cmbCia = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Codigo = New DevComponents.AdvTree.ColumnHeader()
        Me.Nombre = New DevComponents.AdvTree.ColumnHeader()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CodigoTE = New DevComponents.AdvTree.ColumnHeader()
        Me.NombreTE = New DevComponents.AdvTree.ColumnHeader()
        Me.dlgArchivo = New System.Windows.Forms.SaveFileDialog()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbTipoEmp = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.optPeriodo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cmbPeriodos = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.colUnico = New DevComponents.AdvTree.ColumnHeader()
        Me.colActivo = New DevComponents.AdvTree.ColumnHeader()
        Me.colAno = New DevComponents.AdvTree.ColumnHeader()
        Me.colPeriodo = New DevComponents.AdvTree.ColumnHeader()
        Me.colFechaIni = New DevComponents.AdvTree.ColumnHeader()
        Me.colFechaFin = New DevComponents.AdvTree.ColumnHeader()
        Me.dtFin = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.optRango = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.dtinicio = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pbAvance = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.labelProgreso = New System.Windows.Forms.Label()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnMantenimiento = New DevComponents.DotNetBar.ButtonX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAltas = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnBajas = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnCambios = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnModSal = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.dtFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtinicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(50, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(425, 40)
        Me.ReflectionLabel1.TabIndex = 0
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>MANTENIMIENTO</b></font>"
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
        Me.cmbCia.Columns.Add(Me.Codigo)
        Me.cmbCia.Columns.Add(Me.Nombre)
        Me.cmbCia.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbCia.Location = New System.Drawing.Point(111, 12)
        Me.cmbCia.Name = "cmbCia"
        Me.cmbCia.Size = New System.Drawing.Size(341, 20)
        Me.cmbCia.TabIndex = 1
        Me.cmbCia.ValueMember = "cod_comp"
        '
        'Codigo
        '
        Me.Codigo.DataFieldName = "cod_comp"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.Text = "Código"
        Me.Codigo.Width.Absolute = 30
        '
        'Nombre
        '
        Me.Nombre.DataFieldName = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.StretchToFill = True
        Me.Nombre.Text = "Nombre"
        Me.Nombre.Width.Absolute = 150
        Me.Nombre.Width.AutoSize = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Location = New System.Drawing.Point(6, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Compañía"
        '
        'CodigoTE
        '
        Me.CodigoTE.DataFieldName = "cod_tipo"
        Me.CodigoTE.Name = "CodigoTE"
        Me.CodigoTE.Text = "Código"
        Me.CodigoTE.Width.Absolute = 30
        '
        'NombreTE
        '
        Me.NombreTE.DataFieldName = "Nombre"
        Me.NombreTE.Name = "NombreTE"
        Me.NombreTE.StretchToFill = True
        Me.NombreTE.Text = "NombreTE"
        Me.NombreTE.Width.Absolute = 150
        Me.NombreTE.Width.AutoSize = True
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.ColumnName = "colFecha"
        Me.ColumnHeader2.DataFieldName = "fecha"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Fecha"
        Me.ColumnHeader2.Width.Relative = 75
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.ColumnName = "colUsuario"
        Me.ColumnHeader1.DataFieldName = "usuario"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Usuario"
        Me.ColumnHeader1.Width.Relative = 25
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.GroupPanel3)
        Me.GroupPanel1.Controls.Add(Me.Label2)
        Me.GroupPanel1.Controls.Add(Me.cmbTipoEmp)
        Me.GroupPanel1.Controls.Add(Me.GroupPanel2)
        Me.GroupPanel1.Controls.Add(Me.Label1)
        Me.GroupPanel1.Controls.Add(Me.cmbCia)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 58)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(463, 263)
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
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
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
        Me.GroupPanel1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Location = New System.Drawing.Point(6, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Tipo de empleado"
        '
        'cmbTipoEmp
        '
        Me.cmbTipoEmp.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbTipoEmp.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbTipoEmp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbTipoEmp.ButtonDropDown.Visible = True
        Me.cmbTipoEmp.Columns.Add(Me.CodigoTE)
        Me.cmbTipoEmp.Columns.Add(Me.NombreTE)
        Me.cmbTipoEmp.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbTipoEmp.Location = New System.Drawing.Point(111, 38)
        Me.cmbTipoEmp.Name = "cmbTipoEmp"
        Me.cmbTipoEmp.Size = New System.Drawing.Size(341, 20)
        Me.cmbTipoEmp.TabIndex = 3
        Me.cmbTipoEmp.ValueMember = "cod_tipo"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.optPeriodo)
        Me.GroupPanel2.Controls.Add(Me.cmbPeriodos)
        Me.GroupPanel2.Controls.Add(Me.dtFin)
        Me.GroupPanel2.Controls.Add(Me.optRango)
        Me.GroupPanel2.Controls.Add(Me.dtinicio)
        Me.GroupPanel2.Controls.Add(Me.Label6)
        Me.GroupPanel2.Controls.Add(Me.Label5)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(9, 156)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(443, 98)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor = System.Drawing.SystemColors.Window
        Me.GroupPanel2.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 5
        '
        'optPeriodo
        '
        Me.optPeriodo.AutoSize = True
        Me.optPeriodo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.optPeriodo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.optPeriodo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.optPeriodo.Checked = True
        Me.optPeriodo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.optPeriodo.CheckValue = "Y"
        Me.optPeriodo.FocusCuesEnabled = False
        Me.optPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optPeriodo.Location = New System.Drawing.Point(10, 13)
        Me.optPeriodo.Name = "optPeriodo"
        Me.optPeriodo.Size = New System.Drawing.Size(84, 16)
        Me.optPeriodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.optPeriodo.TabIndex = 0
        Me.optPeriodo.Text = "Del periodo"
        Me.optPeriodo.TextColor = System.Drawing.SystemColors.ControlText
        '
        'cmbPeriodos
        '
        Me.cmbPeriodos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPeriodos.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPeriodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPeriodos.ButtonDropDown.Visible = True
        Me.cmbPeriodos.Columns.Add(Me.colUnico)
        Me.cmbPeriodos.Columns.Add(Me.colActivo)
        Me.cmbPeriodos.Columns.Add(Me.colAno)
        Me.cmbPeriodos.Columns.Add(Me.colPeriodo)
        Me.cmbPeriodos.Columns.Add(Me.colFechaIni)
        Me.cmbPeriodos.Columns.Add(Me.colFechaFin)
        Me.cmbPeriodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPeriodos.FormatString = "d"
        Me.cmbPeriodos.FormattingEnabled = True
        Me.cmbPeriodos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPeriodos.Location = New System.Drawing.Point(101, 13)
        Me.cmbPeriodos.Name = "cmbPeriodos"
        Me.cmbPeriodos.Size = New System.Drawing.Size(328, 21)
        Me.cmbPeriodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPeriodos.TabIndex = 0
        Me.cmbPeriodos.TabStop = False
        Me.cmbPeriodos.ThemeAware = True
        Me.cmbPeriodos.ValueMember = "unico"
        '
        'colUnico
        '
        Me.colUnico.DataFieldName = "unico"
        Me.colUnico.Name = "colUnico"
        Me.colUnico.Text = "Unico"
        Me.colUnico.Visible = False
        Me.colUnico.Width.Absolute = 150
        Me.colUnico.Width.AutoSize = True
        '
        'colActivo
        '
        Me.colActivo.DataFieldName = "activo"
        Me.colActivo.Name = "colActivo"
        Me.colActivo.Text = "Activo"
        Me.colActivo.Width.Relative = 14
        '
        'colAno
        '
        Me.colAno.DataFieldName = "ano"
        Me.colAno.Name = "colAno"
        Me.colAno.Text = "Año"
        Me.colAno.Width.Relative = 18
        '
        'colPeriodo
        '
        Me.colPeriodo.DataFieldName = "periodo"
        Me.colPeriodo.Name = "colPeriodo"
        Me.colPeriodo.Text = "Periodo"
        Me.colPeriodo.Width.Relative = 18
        '
        'colFechaIni
        '
        Me.colFechaIni.DataFieldName = "fecha_ini"
        Me.colFechaIni.Name = "colFechaIni"
        Me.colFechaIni.Text = "Fecha Inicio"
        Me.colFechaIni.Width.Relative = 25
        '
        'colFechaFin
        '
        Me.colFechaFin.DataFieldName = "fecha_fin"
        Me.colFechaFin.Name = "colFechaFin"
        Me.colFechaFin.Text = "Fecha Fin"
        Me.colFechaFin.Width.Relative = 25
        '
        'dtFin
        '
        '
        '
        '
        Me.dtFin.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtFin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtFin.ButtonDropDown.Visible = True
        Me.dtFin.Enabled = False
        Me.dtFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFin.IsPopupCalendarOpen = False
        Me.dtFin.Location = New System.Drawing.Point(324, 56)
        '
        '
        '
        Me.dtFin.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtFin.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.dtFin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFin.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtFin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtFin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtFin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtFin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtFin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtFin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtFin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFin.MonthCalendar.DisplayMonth = New Date(2012, 12, 1, 0, 0, 0, 0)
        Me.dtFin.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtFin.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtFin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtFin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtFin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtFin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFin.MonthCalendar.TodayButtonVisible = True
        Me.dtFin.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtFin.Name = "dtFin"
        Me.dtFin.Size = New System.Drawing.Size(105, 21)
        Me.dtFin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtFin.TabIndex = 5
        '
        'optRango
        '
        Me.optRango.AutoSize = True
        Me.optRango.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.optRango.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.optRango.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.optRango.FocusCuesEnabled = False
        Me.optRango.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optRango.Location = New System.Drawing.Point(10, 40)
        Me.optRango.Name = "optRango"
        Me.optRango.Size = New System.Drawing.Size(139, 16)
        Me.optRango.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.optRango.TabIndex = 1
        Me.optRango.Text = "En el rango de fechas"
        Me.optRango.TextColor = System.Drawing.SystemColors.ControlText
        '
        'dtinicio
        '
        '
        '
        '
        Me.dtinicio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtinicio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtinicio.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtinicio.ButtonDropDown.Visible = True
        Me.dtinicio.Enabled = False
        Me.dtinicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtinicio.IsPopupCalendarOpen = False
        Me.dtinicio.Location = New System.Drawing.Point(173, 56)
        '
        '
        '
        Me.dtinicio.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtinicio.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.dtinicio.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtinicio.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtinicio.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtinicio.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtinicio.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtinicio.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtinicio.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtinicio.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtinicio.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtinicio.MonthCalendar.DisplayMonth = New Date(2012, 12, 1, 0, 0, 0, 0)
        Me.dtinicio.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtinicio.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtinicio.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtinicio.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtinicio.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtinicio.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtinicio.MonthCalendar.TodayButtonVisible = True
        Me.dtinicio.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtinicio.Name = "dtinicio"
        Me.dtinicio.Size = New System.Drawing.Size(94, 21)
        Me.dtinicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtinicio.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(98, 59)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 15)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Entre el día"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(273, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "y el día"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.ReflectionLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(485, 55)
        Me.Panel1.TabIndex = 5
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.ToolBox32
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 89
        Me.PictureBox1.TabStop = False
        '
        'pbAvance
        '
        Me.pbAvance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.pbAvance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pbAvance.Location = New System.Drawing.Point(12, 345)
        Me.pbAvance.Name = "pbAvance"
        Me.pbAvance.Size = New System.Drawing.Size(463, 26)
        Me.pbAvance.TabIndex = 2
        Me.pbAvance.Text = "pbAvance"
        Me.pbAvance.Visible = False
        '
        'labelProgreso
        '
        Me.labelProgreso.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.labelProgreso.AutoSize = True
        Me.labelProgreso.BackColor = System.Drawing.Color.Transparent
        Me.labelProgreso.Location = New System.Drawing.Point(12, 329)
        Me.labelProgreso.Name = "labelProgreso"
        Me.labelProgreso.Size = New System.Drawing.Size(52, 13)
        Me.labelProgreso.TabIndex = 1
        Me.labelProgreso.Text = "Progreso:"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(387, 346)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 4
        Me.btnCerrar.Text = "Salir"
        '
        'btnMantenimiento
        '
        Me.btnMantenimiento.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnMantenimiento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnMantenimiento.CausesValidation = False
        Me.btnMantenimiento.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnMantenimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMantenimiento.Image = Global.PIDA.My.Resources.Resources.GuardarMnto22
        Me.btnMantenimiento.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnMantenimiento.Location = New System.Drawing.Point(276, 346)
        Me.btnMantenimiento.Name = "btnMantenimiento"
        Me.btnMantenimiento.Size = New System.Drawing.Size(105, 25)
        Me.btnMantenimiento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnMantenimiento.TabIndex = 3
        Me.btnMantenimiento.Text = "Crear archivo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Location = New System.Drawing.Point(7, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Movimientos a incluir"
        '
        'btnAltas
        '
        '
        '
        '
        Me.btnAltas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnAltas.Location = New System.Drawing.Point(135, 25)
        Me.btnAltas.Name = "btnAltas"
        Me.btnAltas.OffText = "NO"
        Me.btnAltas.OnText = "SÍ"
        Me.btnAltas.Size = New System.Drawing.Size(66, 22)
        Me.btnAltas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAltas.TabIndex = 1
        Me.btnAltas.Value = True
        Me.btnAltas.ValueObject = "Y"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Location = New System.Drawing.Point(99, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Altas"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Window
        Me.Label7.Location = New System.Drawing.Point(99, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Bajas"
        '
        'btnBajas
        '
        '
        '
        '
        Me.btnBajas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnBajas.Location = New System.Drawing.Point(135, 53)
        Me.btnBajas.Name = "btnBajas"
        Me.btnBajas.OffText = "NO"
        Me.btnBajas.OnText = "SÍ"
        Me.btnBajas.Size = New System.Drawing.Size(66, 22)
        Me.btnBajas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBajas.TabIndex = 4
        Me.btnBajas.Value = True
        Me.btnBajas.ValueObject = "Y"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Window
        Me.Label8.Location = New System.Drawing.Point(233, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Cambios generales"
        '
        'btnCambios
        '
        '
        '
        '
        Me.btnCambios.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnCambios.Location = New System.Drawing.Point(366, 25)
        Me.btnCambios.Name = "btnCambios"
        Me.btnCambios.OffText = "NO"
        Me.btnCambios.OnText = "SÍ"
        Me.btnCambios.Size = New System.Drawing.Size(66, 22)
        Me.btnCambios.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCambios.TabIndex = 6
        Me.btnCambios.Value = True
        Me.btnCambios.ValueObject = "Y"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Window
        Me.Label9.Location = New System.Drawing.Point(233, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(127, 13)
        Me.Label9.TabIndex = 7
        Me.Label9.Text = "Modificaciones de sueldo"
        '
        'btnModSal
        '
        '
        '
        '
        Me.btnModSal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnModSal.Location = New System.Drawing.Point(366, 53)
        Me.btnModSal.Name = "btnModSal"
        Me.btnModSal.OffText = "NO"
        Me.btnModSal.OnText = "SÍ"
        Me.btnModSal.Size = New System.Drawing.Size(66, 22)
        Me.btnModSal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnModSal.TabIndex = 8
        Me.btnModSal.Value = True
        Me.btnModSal.ValueObject = "Y"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.White
        Me.GroupPanel3.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.btnAltas)
        Me.GroupPanel3.Controls.Add(Me.Label3)
        Me.GroupPanel3.Controls.Add(Me.Label9)
        Me.GroupPanel3.Controls.Add(Me.Label4)
        Me.GroupPanel3.Controls.Add(Me.btnModSal)
        Me.GroupPanel3.Controls.Add(Me.btnBajas)
        Me.GroupPanel3.Controls.Add(Me.Label8)
        Me.GroupPanel3.Controls.Add(Me.Label7)
        Me.GroupPanel3.Controls.Add(Me.btnCambios)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(9, 64)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(443, 86)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor = System.Drawing.SystemColors.Window
        Me.GroupPanel3.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderLeftWidth = 1
        Me.GroupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderRightWidth = 1
        Me.GroupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderTopWidth = 1
        Me.GroupPanel3.Style.CornerDiameter = 4
        Me.GroupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel3.TabIndex = 3
        '
        'frmMantenimiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(485, 386)
        Me.Controls.Add(Me.labelProgreso)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnMantenimiento)
        Me.Controls.Add(Me.pbAvance)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMantenimiento"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel2.PerformLayout()
        CType(Me.dtFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtinicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        Me.GroupPanel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Private WithEvents cmbCia As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnMantenimiento As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Codigo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Nombre As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents CodigoTE As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NombreTE As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents dlgArchivo As System.Windows.Forms.SaveFileDialog
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents pbAvance As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents labelProgreso As System.Windows.Forms.Label
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents optPeriodo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cmbPeriodos As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents dtFin As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents optRango As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents dtinicio As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents colUnico As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colActivo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colAno As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colPeriodo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colFechaIni As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colFechaFin As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents cmbTipoEmp As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btnAltas As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnModSal As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents btnBajas As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnCambios As DevComponents.DotNetBar.Controls.SwitchButton
End Class
