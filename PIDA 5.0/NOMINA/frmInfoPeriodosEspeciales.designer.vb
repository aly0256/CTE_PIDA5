<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfoPeriodosEspeciales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInfoPeriodosEspeciales))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSalir = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnEspecial = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.btnActivo = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFechaPago = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.txtFechaFin = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.txtFechaIni = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.cmbMes = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gpInfo = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaIni, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSalir)
        Me.GroupBox1.Controls.Add(Me.btnAceptar)
        Me.GroupBox1.Location = New System.Drawing.Point(166, 336)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(201, 47)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'btnSalir
        '
        Me.btnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSalir.CausesValidation = False
        Me.btnSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnSalir.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnSalir.Location = New System.Drawing.Point(103, 14)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(88, 25)
        Me.btnSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSalir.TabIndex = 9
        Me.btnSalir.Text = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnAceptar.Location = New System.Drawing.Point(10, 14)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(88, 25)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "Aceptar"
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
        Me.ReflectionLabel1.Size = New System.Drawing.Size(419, 40)
        Me.ReflectionLabel1.TabIndex = 114
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>INFORMACIÓN DE PERIODO ESPECIAL</b></font>"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.Periodo32
        Me.picImagen.Location = New System.Drawing.Point(12, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(27, 35)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picImagen.TabIndex = 115
        Me.picImagen.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = systemcolors.window
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(11, 213)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(99, 15)
        Me.Label10.TabIndex = 135
        Me.Label10.Text = "Periodo especial"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = systemcolors.window
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(11, 180)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 15)
        Me.Label9.TabIndex = 134
        Me.Label9.Text = "Periodo activo"
        '
        'btnEspecial
        '
        '
        '
        '
        Me.btnEspecial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnEspecial.IsReadOnly = True
        Me.btnEspecial.Location = New System.Drawing.Point(111, 209)
        Me.btnEspecial.Name = "btnEspecial"
        Me.btnEspecial.OffText = "NO"
        Me.btnEspecial.OffTextColor = System.Drawing.Color.DarkBlue
        Me.btnEspecial.OnText = "SI"
        Me.btnEspecial.OnTextColor = System.Drawing.Color.DarkBlue
        Me.btnEspecial.Size = New System.Drawing.Size(66, 22)
        Me.btnEspecial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEspecial.TabIndex = 7
        '
        'btnActivo
        '
        '
        '
        '
        Me.btnActivo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnActivo.IsReadOnly = True
        Me.btnActivo.Location = New System.Drawing.Point(111, 176)
        Me.btnActivo.Name = "btnActivo"
        Me.btnActivo.OffText = "NO"
        Me.btnActivo.OffTextColor = System.Drawing.Color.DarkBlue
        Me.btnActivo.OnText = "SI"
        Me.btnActivo.OnTextColor = System.Drawing.Color.DarkBlue
        Me.btnActivo.Size = New System.Drawing.Size(66, 22)
        Me.btnActivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnActivo.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = systemcolors.window
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(11, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 15)
        Me.Label8.TabIndex = 131
        Me.Label8.Text = "Observaciones"
        '
        'txtObservaciones
        '
        '
        '
        '
        Me.txtObservaciones.Border.Class = "TextBoxBorder"
        Me.txtObservaciones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservaciones.Location = New System.Drawing.Point(111, 80)
        Me.txtObservaciones.MaxLength = 100
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(289, 21)
        Me.txtObservaciones.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = systemcolors.window
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 15)
        Me.Label7.TabIndex = 129
        Me.Label7.Text = "Descripción"
        '
        'txtDescripcion
        '
        '
        '
        '
        Me.txtDescripcion.Border.Class = "TextBoxBorder"
        Me.txtDescripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(111, 48)
        Me.txtDescripcion.MaxLength = 30
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(289, 21)
        Me.txtDescripcion.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = systemcolors.window
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 147)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 15)
        Me.Label6.TabIndex = 127
        Me.Label6.Text = "Mes"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = systemcolors.window
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 15)
        Me.Label5.TabIndex = 126
        Me.Label5.Text = "Fecha de pago"
        '
        'txtFechaPago
        '
        '
        '
        '
        Me.txtFechaPago.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaPago.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaPago.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtFechaPago.ButtonDropDown.Visible = True
        Me.txtFechaPago.IsPopupCalendarOpen = False
        Me.txtFechaPago.Location = New System.Drawing.Point(111, 112)
        '
        '
        '
        Me.txtFechaPago.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaPago.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaPago.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtFechaPago.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaPago.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaPago.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaPago.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaPago.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaPago.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaPago.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaPago.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaPago.MonthCalendar.DisplayMonth = New Date(2013, 7, 1, 0, 0, 0, 0)
        Me.txtFechaPago.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaPago.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaPago.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaPago.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaPago.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaPago.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaPago.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaPago.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFechaPago.Name = "txtFechaPago"
        Me.txtFechaPago.Size = New System.Drawing.Size(84, 20)
        Me.txtFechaPago.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFechaPago.TabIndex = 4
        '
        'txtFechaFin
        '
        '
        '
        '
        Me.txtFechaFin.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaFin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtFechaFin.ButtonDropDown.Visible = True
        Me.txtFechaFin.IsPopupCalendarOpen = False
        Me.txtFechaFin.Location = New System.Drawing.Point(317, 17)
        '
        '
        '
        Me.txtFechaFin.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaFin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFin.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtFechaFin.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFin.MonthCalendar.DisplayMonth = New Date(2013, 7, 1, 0, 0, 0, 0)
        Me.txtFechaFin.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaFin.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaFin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFin.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaFin.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFechaFin.Name = "txtFechaFin"
        Me.txtFechaFin.Size = New System.Drawing.Size(84, 20)
        Me.txtFechaFin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFechaFin.TabIndex = 1
        '
        'txtFechaIni
        '
        '
        '
        '
        Me.txtFechaIni.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaIni.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaIni.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtFechaIni.ButtonDropDown.Visible = True
        Me.txtFechaIni.IsPopupCalendarOpen = False
        Me.txtFechaIni.Location = New System.Drawing.Point(111, 17)
        '
        '
        '
        Me.txtFechaIni.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaIni.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaIni.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtFechaIni.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaIni.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaIni.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaIni.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaIni.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaIni.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaIni.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaIni.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaIni.MonthCalendar.DisplayMonth = New Date(2013, 7, 1, 0, 0, 0, 0)
        Me.txtFechaIni.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaIni.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaIni.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaIni.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaIni.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaIni.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaIni.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaIni.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFechaIni.Name = "txtFechaIni"
        Me.txtFechaIni.Size = New System.Drawing.Size(84, 20)
        Me.txtFechaIni.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFechaIni.TabIndex = 0
        '
        'cmbMes
        '
        Me.cmbMes.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbMes.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbMes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbMes.ButtonDropDown.Visible = True
        Me.cmbMes.DisplayMembers = "cod_super"
        Me.cmbMes.Location = New System.Drawing.Point(111, 143)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(289, 22)
        Me.cmbMes.TabIndex = 5
        Me.cmbMes.ValueMember = "num_mes"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = systemcolors.window
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(221, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 121
        Me.Label2.Text = "Fecha final"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = systemcolors.window
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 15)
        Me.Label3.TabIndex = 119
        Me.Label3.Text = "Fecha inicial"
        '
        'gpInfo
        '
        Me.gpInfo.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpInfo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled 
        Me.gpInfo.Controls.Add(Me.Label10)
        Me.gpInfo.Controls.Add(Me.Label9)
        Me.gpInfo.Controls.Add(Me.btnEspecial)
        Me.gpInfo.Controls.Add(Me.btnActivo)
        Me.gpInfo.Controls.Add(Me.Label8)
        Me.gpInfo.Controls.Add(Me.txtObservaciones)
        Me.gpInfo.Controls.Add(Me.Label7)
        Me.gpInfo.Controls.Add(Me.txtDescripcion)
        Me.gpInfo.Controls.Add(Me.Label6)
        Me.gpInfo.Controls.Add(Me.Label5)
        Me.gpInfo.Controls.Add(Me.txtFechaPago)
        Me.gpInfo.Controls.Add(Me.txtFechaFin)
        Me.gpInfo.Controls.Add(Me.txtFechaIni)
        Me.gpInfo.Controls.Add(Me.cmbMes)
        Me.gpInfo.Controls.Add(Me.Label2)
        Me.gpInfo.Controls.Add(Me.Label3)
        Me.gpInfo.Location = New System.Drawing.Point(32, 58)
        Me.gpInfo.Name = "gpInfo"
        Me.gpInfo.Size = New System.Drawing.Size(419, 272)
        '
        '
        '
        Me.gpInfo.Style.BackColor = systemcolors.window
        Me.gpInfo.Style.BackColor2 = systemcolors.window
        Me.gpInfo.Style.BackColorGradientAngle = 90
        Me.gpInfo.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpInfo.Style.BorderBottomWidth = 1
        Me.gpInfo.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpInfo.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpInfo.Style.BorderLeftWidth = 1
        Me.gpInfo.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpInfo.Style.BorderRightWidth = 1
        Me.gpInfo.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpInfo.Style.BorderTopWidth = 1
        Me.gpInfo.Style.CornerDiameter = 4
        Me.gpInfo.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpInfo.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpInfo.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.gpInfo.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        '
        '
        '
        Me.gpInfo.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpInfo.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpInfo.TabIndex = 0
        Me.gpInfo.Text = "AÑO 9999 - PERIODO 99"
        '
        'frmInfoPeriodosEspeciales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 395)
        Me.Controls.Add(Me.gpInfo)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.picImagen)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInfoPeriodosEspeciales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Periodos especiales"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaIni, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpInfo.ResumeLayout(False)
        Me.gpInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSalir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnEspecial As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents btnActivo As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFechaPago As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtFechaFin As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtFechaIni As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents cmbMes As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents gpInfo As DevComponents.DotNetBar.Controls.GroupPanel
End Class
