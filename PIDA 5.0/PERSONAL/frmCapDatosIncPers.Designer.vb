<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCapDatosIncPers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapDatosIncPers))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.gpbFalta = New System.Windows.Forms.GroupBox()
        Me.gpbVac = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDiasVac = New DevComponents.Editors.DoubleInput()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFechaRegVac = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFIniVac = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.txtFechaFalta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.txtMotivo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbTipoMov = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnAgregarEmpleado = New DevComponents.DotNetBar.ButtonX()
        Me.txtBuscaEmpleado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.gpbFalta.SuspendLayout()
        Me.gpbVac.SuspendLayout()
        CType(Me.txtDiasVac, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaRegVac, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFIniVac, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaFalta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(701, 47)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(297, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Captura de incidencia"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 47)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(701, 23)
        Me.Panel2.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.ButtonX2)
        Me.Panel3.Controls.Add(Me.btnCancelar)
        Me.Panel3.Controls.Add(Me.btnAceptar)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 412)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(701, 61)
        Me.Panel3.TabIndex = 2
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.CausesValidation = False
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonX2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX2.Location = New System.Drawing.Point(545, 12)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(106, 37)
        Me.ButtonX2.TabIndex = 6
        Me.ButtonX2.Text = "Salir"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Location = New System.Drawing.Point(421, 12)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(106, 37)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAceptar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(296, 12)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(106, 37)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "Aceptar"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.gpbVac)
        Me.Panel4.Controls.Add(Me.gpbFalta)
        Me.Panel4.Controls.Add(Me.cmbTipoMov)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.btnAgregarEmpleado)
        Me.Panel4.Controls.Add(Me.txtBuscaEmpleado)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 70)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(701, 342)
        Me.Panel4.TabIndex = 3
        '
        'gpbFalta
        '
        Me.gpbFalta.Controls.Add(Me.txtFechaFalta)
        Me.gpbFalta.Controls.Add(Me.txtMotivo)
        Me.gpbFalta.Controls.Add(Me.Label7)
        Me.gpbFalta.Controls.Add(Me.Label8)
        Me.gpbFalta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gpbFalta.Location = New System.Drawing.Point(13, 175)
        Me.gpbFalta.Name = "gpbFalta"
        Me.gpbFalta.Size = New System.Drawing.Size(674, 158)
        Me.gpbFalta.TabIndex = 276
        Me.gpbFalta.TabStop = False
        '
        'gpbVac
        '
        Me.gpbVac.Controls.Add(Me.Label4)
        Me.gpbVac.Controls.Add(Me.txtDiasVac)
        Me.gpbVac.Controls.Add(Me.Label6)
        Me.gpbVac.Controls.Add(Me.txtFechaRegVac)
        Me.gpbVac.Controls.Add(Me.Label5)
        Me.gpbVac.Controls.Add(Me.txtFIniVac)
        Me.gpbVac.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gpbVac.Location = New System.Drawing.Point(16, 105)
        Me.gpbVac.Name = "gpbVac"
        Me.gpbVac.Size = New System.Drawing.Size(674, 64)
        Me.gpbVac.TabIndex = 277
        Me.gpbVac.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label4.Location = New System.Drawing.Point(6, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 20)
        Me.Label4.TabIndex = 265
        Me.Label4.Text = "Días"
        '
        'txtDiasVac
        '
        '
        '
        '
        Me.txtDiasVac.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtDiasVac.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDiasVac.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtDiasVac.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiasVac.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtDiasVac.Increment = 1.0R
        Me.txtDiasVac.Location = New System.Drawing.Point(111, 14)
        Me.txtDiasVac.MaxValue = 30.0R
        Me.txtDiasVac.MinValue = 1.0R
        Me.txtDiasVac.Name = "txtDiasVac"
        Me.txtDiasVac.ShowUpDown = True
        Me.txtDiasVac.Size = New System.Drawing.Size(74, 26)
        Me.txtDiasVac.TabIndex = 264
        Me.txtDiasVac.Value = 1.0R
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label6.Location = New System.Drawing.Point(442, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 20)
        Me.Label6.TabIndex = 270
        Me.Label6.Text = "Entrada"
        '
        'txtFechaRegVac
        '
        '
        '
        '
        Me.txtFechaRegVac.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaRegVac.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaRegVac.ButtonDropDown.Visible = True
        Me.txtFechaRegVac.DisabledForeColor = System.Drawing.Color.Black
        Me.txtFechaRegVac.Enabled = False
        Me.txtFechaRegVac.FocusHighlightEnabled = True
        Me.txtFechaRegVac.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaRegVac.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtFechaRegVac.IsPopupCalendarOpen = False
        Me.txtFechaRegVac.Location = New System.Drawing.Point(522, 14)
        '
        '
        '
        Me.txtFechaRegVac.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaRegVac.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtFechaRegVac.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaRegVac.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtFechaRegVac.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaRegVac.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaRegVac.MonthCalendar.DisplayMonth = New Date(2007, 10, 1, 0, 0, 0, 0)
        Me.txtFechaRegVac.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaRegVac.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaRegVac.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaRegVac.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaRegVac.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaRegVac.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaRegVac.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaRegVac.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFechaRegVac.Name = "txtFechaRegVac"
        Me.txtFechaRegVac.Size = New System.Drawing.Size(147, 26)
        Me.txtFechaRegVac.TabIndex = 269
        Me.txtFechaRegVac.Value = New Date(2007, 7, 7, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.Location = New System.Drawing.Point(202, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 20)
        Me.Label5.TabIndex = 268
        Me.Label5.Text = "Salida"
        '
        'txtFIniVac
        '
        '
        '
        '
        Me.txtFIniVac.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFIniVac.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFIniVac.ButtonDropDown.Visible = True
        Me.txtFIniVac.DisabledForeColor = System.Drawing.Color.Black
        Me.txtFIniVac.FocusHighlightEnabled = True
        Me.txtFIniVac.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFIniVac.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtFIniVac.IsPopupCalendarOpen = False
        Me.txtFIniVac.Location = New System.Drawing.Point(280, 14)
        '
        '
        '
        Me.txtFIniVac.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFIniVac.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtFIniVac.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFIniVac.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtFIniVac.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFIniVac.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFIniVac.MonthCalendar.DisplayMonth = New Date(2007, 10, 1, 0, 0, 0, 0)
        Me.txtFIniVac.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFIniVac.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFIniVac.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFIniVac.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFIniVac.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFIniVac.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFIniVac.MonthCalendar.TodayButtonVisible = True
        Me.txtFIniVac.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFIniVac.Name = "txtFIniVac"
        Me.txtFIniVac.Size = New System.Drawing.Size(149, 26)
        Me.txtFIniVac.TabIndex = 267
        Me.txtFIniVac.Value = New Date(2007, 7, 7, 0, 0, 0, 0)
        '
        'txtFechaFalta
        '
        '
        '
        '
        Me.txtFechaFalta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaFalta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFalta.ButtonDropDown.Visible = True
        Me.txtFechaFalta.DisabledForeColor = System.Drawing.Color.Black
        Me.txtFechaFalta.FocusHighlightEnabled = True
        Me.txtFechaFalta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFalta.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtFechaFalta.IsPopupCalendarOpen = False
        Me.txtFechaFalta.Location = New System.Drawing.Point(111, 19)
        '
        '
        '
        Me.txtFechaFalta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaFalta.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtFechaFalta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFalta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtFechaFalta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaFalta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFalta.MonthCalendar.DisplayMonth = New Date(2007, 10, 1, 0, 0, 0, 0)
        Me.txtFechaFalta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaFalta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaFalta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaFalta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaFalta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaFalta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFalta.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaFalta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFechaFalta.Name = "txtFechaFalta"
        Me.txtFechaFalta.Size = New System.Drawing.Size(149, 26)
        Me.txtFechaFalta.TabIndex = 272
        Me.txtFechaFalta.Value = New Date(2007, 7, 7, 0, 0, 0, 0)
        '
        'txtMotivo
        '
        '
        '
        '
        Me.txtMotivo.Border.Class = "TextBoxBorder"
        Me.txtMotivo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMotivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMotivo.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtMotivo.Location = New System.Drawing.Point(111, 78)
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.PreventEnterBeep = True
        Me.txtMotivo.Size = New System.Drawing.Size(318, 74)
        Me.txtMotivo.TabIndex = 274
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label7.Location = New System.Drawing.Point(6, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 20)
        Me.Label7.TabIndex = 271
        Me.Label7.Text = "Fecha"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label8.Location = New System.Drawing.Point(6, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 20)
        Me.Label8.TabIndex = 273
        Me.Label8.Text = "Motivo"
        '
        'cmbTipoMov
        '
        Me.cmbTipoMov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoMov.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoMov.ForeColor = System.Drawing.Color.MidnightBlue
        Me.cmbTipoMov.FormattingEnabled = True
        Me.cmbTipoMov.Items.AddRange(New Object() {"Vacaciones", "Permiso con goce de sueldo", "Permiso sin goce de sueldo", "Tolerancia", "Falta injustificada", "Falta Justificada"})
        Me.cmbTipoMov.Location = New System.Drawing.Point(117, 67)
        Me.cmbTipoMov.Name = "cmbTipoMov"
        Me.cmbTipoMov.Size = New System.Drawing.Size(328, 28)
        Me.cmbTipoMov.TabIndex = 262
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label3.Location = New System.Drawing.Point(12, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 40)
        Me.Label3.TabIndex = 261
        Me.Label3.Text = "Tipo de " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "movimiento"
        '
        'btnAgregarEmpleado
        '
        Me.btnAgregarEmpleado.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAgregarEmpleado.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAgregarEmpleado.Location = New System.Drawing.Point(623, 17)
        Me.btnAgregarEmpleado.Name = "btnAgregarEmpleado"
        Me.btnAgregarEmpleado.Size = New System.Drawing.Size(54, 26)
        Me.btnAgregarEmpleado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAgregarEmpleado.TabIndex = 260
        Me.btnAgregarEmpleado.Text = "..."
        Me.btnAgregarEmpleado.Tooltip = "Buscar empleado"
        '
        'txtBuscaEmpleado
        '
        '
        '
        '
        Me.txtBuscaEmpleado.Border.Class = "TextBoxBorder"
        Me.txtBuscaEmpleado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBuscaEmpleado.Enabled = False
        Me.txtBuscaEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscaEmpleado.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtBuscaEmpleado.Location = New System.Drawing.Point(117, 17)
        Me.txtBuscaEmpleado.Name = "txtBuscaEmpleado"
        Me.txtBuscaEmpleado.PreventEnterBeep = True
        Me.txtBuscaEmpleado.Size = New System.Drawing.Size(500, 26)
        Me.txtBuscaEmpleado.TabIndex = 259
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(12, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Empleado"
        '
        'frmCapDatosIncPers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(701, 473)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCapDatosIncPers"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de Incidencias"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.gpbFalta.ResumeLayout(False)
        Me.gpbFalta.PerformLayout()
        Me.gpbVac.ResumeLayout(False)
        Me.gpbVac.PerformLayout()
        CType(Me.txtDiasVac, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaRegVac, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFIniVac, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaFalta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBuscaEmpleado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnAgregarEmpleado As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmbTipoMov As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDiasVac As DevComponents.Editors.DoubleInput
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Private WithEvents txtFechaRegVac As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents txtFIniVac As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Private WithEvents txtFechaFalta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMotivo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents gpbFalta As System.Windows.Forms.GroupBox
    Friend WithEvents gpbVac As System.Windows.Forms.GroupBox
End Class
