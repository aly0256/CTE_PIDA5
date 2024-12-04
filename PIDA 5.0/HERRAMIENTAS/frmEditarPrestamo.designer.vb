<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditarPrestamo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditarPrestamo))
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.gpDatos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.txtPrestados = New DevComponents.Editors.IntegerInput()
        Me.txtAPrestar = New DevComponents.Editors.IntegerInput()
        Me.txtCosto = New DevComponents.Editors.DoubleInput()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtControl = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDisponibles = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtFechaEntrada = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.txtFechaSalida = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtObservacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtReposicion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cmbArticulo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.colCodigo = New DevComponents.AdvTree.ColumnHeader()
        Me.colNombre = New DevComponents.AdvTree.ColumnHeader()
        Me.colClasificacion = New DevComponents.AdvTree.ColumnHeader()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblEstado = New DevComponents.DotNetBar.LabelX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Recibir = New DevComponents.DotNetBar.ButtonX()
        Me.gpDatos.SuspendLayout()
        CType(Me.txtPrestados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAPrestar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCosto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaEntrada, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaSalida, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cancel16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(580, 354)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.Text = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnAceptar.Location = New System.Drawing.Point(496, 353)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Aceptar"
        '
        'gpDatos
        '
        Me.gpDatos.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpDatos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpDatos.Controls.Add(Me.txtPrestados)
        Me.gpDatos.Controls.Add(Me.txtAPrestar)
        Me.gpDatos.Controls.Add(Me.txtCosto)
        Me.gpDatos.Controls.Add(Me.Label11)
        Me.gpDatos.Controls.Add(Me.txtControl)
        Me.gpDatos.Controls.Add(Me.Label10)
        Me.gpDatos.Controls.Add(Me.Label9)
        Me.gpDatos.Controls.Add(Me.txtDisponibles)
        Me.gpDatos.Controls.Add(Me.Label8)
        Me.gpDatos.Controls.Add(Me.txtFechaEntrada)
        Me.gpDatos.Controls.Add(Me.txtFechaSalida)
        Me.gpDatos.Controls.Add(Me.Label7)
        Me.gpDatos.Controls.Add(Me.Label6)
        Me.gpDatos.Controls.Add(Me.txtObservacion)
        Me.gpDatos.Controls.Add(Me.Label4)
        Me.gpDatos.Controls.Add(Me.txtReposicion)
        Me.gpDatos.Controls.Add(Me.cmbArticulo)
        Me.gpDatos.Controls.Add(Me.Label3)
        Me.gpDatos.Controls.Add(Me.Label2)
        Me.gpDatos.Controls.Add(Me.Label1)
        Me.gpDatos.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpDatos.Location = New System.Drawing.Point(12, 110)
        Me.gpDatos.Name = "gpDatos"
        Me.gpDatos.Size = New System.Drawing.Size(645, 238)
        '
        '
        '
        Me.gpDatos.Style.BackColor = System.Drawing.Color.White
        Me.gpDatos.Style.BackColor2 = System.Drawing.Color.White
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
        'txtPrestados
        '
        '
        '
        '
        Me.txtPrestados.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtPrestados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPrestados.ButtonCalculator.Tooltip = ""
        Me.txtPrestados.ButtonClear.Tooltip = ""
        Me.txtPrestados.ButtonCustom.Tooltip = ""
        Me.txtPrestados.ButtonCustom2.Tooltip = ""
        Me.txtPrestados.ButtonDropDown.Tooltip = ""
        Me.txtPrestados.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtPrestados.ButtonFreeText.Tooltip = ""
        Me.txtPrestados.Enabled = False
        Me.txtPrestados.Location = New System.Drawing.Point(522, 73)
        Me.txtPrestados.MinValue = 0
        Me.txtPrestados.Name = "txtPrestados"
        Me.txtPrestados.Size = New System.Drawing.Size(103, 20)
        Me.txtPrestados.TabIndex = 38
        '
        'txtAPrestar
        '
        Me.txtAPrestar.AutoOverwrite = True
        '
        '
        '
        Me.txtAPrestar.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtAPrestar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAPrestar.ButtonCalculator.Tooltip = ""
        Me.txtAPrestar.ButtonClear.Tooltip = ""
        Me.txtAPrestar.ButtonCustom.Tooltip = ""
        Me.txtAPrestar.ButtonCustom2.Tooltip = ""
        Me.txtAPrestar.ButtonDropDown.Tooltip = ""
        Me.txtAPrestar.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtAPrestar.ButtonFreeText.Tooltip = ""
        Me.txtAPrestar.Location = New System.Drawing.Point(522, 99)
        Me.txtAPrestar.MinValue = 0
        Me.txtAPrestar.Name = "txtAPrestar"
        Me.txtAPrestar.ShowUpDown = True
        Me.txtAPrestar.Size = New System.Drawing.Size(103, 20)
        Me.txtAPrestar.TabIndex = 1
        '
        'txtCosto
        '
        '
        '
        '
        Me.txtCosto.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtCosto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCosto.ButtonCalculator.Tooltip = ""
        Me.txtCosto.ButtonClear.Tooltip = ""
        Me.txtCosto.ButtonCustom.Tooltip = ""
        Me.txtCosto.ButtonCustom2.Tooltip = ""
        Me.txtCosto.ButtonDropDown.Tooltip = ""
        Me.txtCosto.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtCosto.ButtonFreeText.Tooltip = ""
        Me.txtCosto.Enabled = False
        Me.txtCosto.Increment = 1.0R
        Me.txtCosto.Location = New System.Drawing.Point(103, 99)
        Me.txtCosto.MaxValue = 99999.0R
        Me.txtCosto.MinValue = 0.0R
        Me.txtCosto.Name = "txtCosto"
        Me.txtCosto.Size = New System.Drawing.Size(84, 20)
        Me.txtCosto.TabIndex = 37
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.White
        Me.Label11.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label11.Location = New System.Drawing.Point(443, 75)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(54, 13)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "Prestados"
        '
        'txtControl
        '
        Me.txtControl.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtControl.Border.Class = "TextBoxBorder"
        Me.txtControl.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtControl.ButtonCustom.Tooltip = ""
        Me.txtControl.ButtonCustom2.Tooltip = ""
        Me.txtControl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtControl.Location = New System.Drawing.Point(522, 125)
        Me.txtControl.MaxLength = 10
        Me.txtControl.Name = "txtControl"
        Me.txtControl.ReadOnly = True
        Me.txtControl.Size = New System.Drawing.Size(103, 20)
        Me.txtControl.TabIndex = 2
        Me.txtControl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label10.Location = New System.Drawing.Point(443, 127)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "Cód. control"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label9.Location = New System.Drawing.Point(443, 101)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 32
        Me.Label9.Text = "A prestar"
        '
        'txtDisponibles
        '
        Me.txtDisponibles.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtDisponibles.Border.Class = "TextBoxBorder"
        Me.txtDisponibles.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDisponibles.ButtonCustom.Tooltip = ""
        Me.txtDisponibles.ButtonCustom2.Tooltip = ""
        Me.txtDisponibles.Enabled = False
        Me.txtDisponibles.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtDisponibles.Location = New System.Drawing.Point(522, 47)
        Me.txtDisponibles.MaxLength = 10
        Me.txtDisponibles.Name = "txtDisponibles"
        Me.txtDisponibles.ReadOnly = True
        Me.txtDisponibles.Size = New System.Drawing.Size(103, 20)
        Me.txtDisponibles.TabIndex = 10
        Me.txtDisponibles.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Label8.Location = New System.Drawing.Point(443, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Disponibles"
        '
        'txtFechaEntrada
        '
        '
        '
        '
        Me.txtFechaEntrada.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaEntrada.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaEntrada.ButtonClear.Tooltip = ""
        Me.txtFechaEntrada.ButtonCustom.Tooltip = ""
        Me.txtFechaEntrada.ButtonCustom2.Tooltip = ""
        Me.txtFechaEntrada.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtFechaEntrada.ButtonDropDown.Tooltip = ""
        Me.txtFechaEntrada.ButtonDropDown.Visible = True
        Me.txtFechaEntrada.ButtonFreeText.Tooltip = ""
        Me.txtFechaEntrada.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFechaEntrada.IsPopupCalendarOpen = False
        Me.txtFechaEntrada.Location = New System.Drawing.Point(103, 125)
        '
        '
        '
        Me.txtFechaEntrada.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaEntrada.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtFechaEntrada.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaEntrada.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaEntrada.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaEntrada.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaEntrada.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaEntrada.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaEntrada.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaEntrada.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaEntrada.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaEntrada.MonthCalendar.DisplayMonth = New Date(2012, 12, 1, 0, 0, 0, 0)
        Me.txtFechaEntrada.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaEntrada.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaEntrada.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaEntrada.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaEntrada.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaEntrada.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaEntrada.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaEntrada.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFechaEntrada.Name = "txtFechaEntrada"
        Me.txtFechaEntrada.Size = New System.Drawing.Size(84, 20)
        Me.txtFechaEntrada.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFechaEntrada.TabIndex = 0
        '
        'txtFechaSalida
        '
        '
        '
        '
        Me.txtFechaSalida.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaSalida.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaSalida.ButtonClear.Tooltip = ""
        Me.txtFechaSalida.ButtonCustom.Tooltip = ""
        Me.txtFechaSalida.ButtonCustom2.Tooltip = ""
        Me.txtFechaSalida.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtFechaSalida.ButtonDropDown.Tooltip = ""
        Me.txtFechaSalida.ButtonDropDown.Visible = True
        Me.txtFechaSalida.ButtonFreeText.Tooltip = ""
        Me.txtFechaSalida.Enabled = False
        Me.txtFechaSalida.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtFechaSalida.IsPopupCalendarOpen = False
        Me.txtFechaSalida.Location = New System.Drawing.Point(103, 47)
        '
        '
        '
        Me.txtFechaSalida.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaSalida.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtFechaSalida.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaSalida.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaSalida.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaSalida.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaSalida.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaSalida.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaSalida.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaSalida.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaSalida.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaSalida.MonthCalendar.DisplayMonth = New Date(2012, 12, 1, 0, 0, 0, 0)
        Me.txtFechaSalida.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaSalida.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaSalida.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaSalida.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaSalida.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaSalida.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaSalida.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaSalida.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFechaSalida.Name = "txtFechaSalida"
        Me.txtFechaSalida.Size = New System.Drawing.Size(84, 20)
        Me.txtFechaSalida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFechaSalida.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(10, 156)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 13)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Observación"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(10, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Costo"
        '
        'txtObservacion
        '
        '
        '
        '
        Me.txtObservacion.Border.Class = "TextBoxBorder"
        Me.txtObservacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtObservacion.ButtonCustom.Tooltip = ""
        Me.txtObservacion.ButtonCustom2.Tooltip = ""
        Me.txtObservacion.Location = New System.Drawing.Point(103, 151)
        Me.txtObservacion.Multiline = True
        Me.txtObservacion.Name = "txtObservacion"
        Me.txtObservacion.Size = New System.Drawing.Size(522, 70)
        Me.txtObservacion.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(10, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Entrega"
        '
        'txtReposicion
        '
        Me.txtReposicion.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtReposicion.Border.Class = "TextBoxBorder"
        Me.txtReposicion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReposicion.ButtonCustom.Tooltip = ""
        Me.txtReposicion.ButtonCustom2.Tooltip = ""
        Me.txtReposicion.Enabled = False
        Me.txtReposicion.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtReposicion.Location = New System.Drawing.Point(103, 73)
        Me.txtReposicion.MaxLength = 10
        Me.txtReposicion.Name = "txtReposicion"
        Me.txtReposicion.ReadOnly = True
        Me.txtReposicion.Size = New System.Drawing.Size(84, 20)
        Me.txtReposicion.TabIndex = 7
        Me.txtReposicion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbArticulo
        '
        Me.cmbArticulo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbArticulo.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbArticulo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbArticulo.ButtonClear.Tooltip = ""
        Me.cmbArticulo.ButtonCustom.Tooltip = ""
        Me.cmbArticulo.ButtonCustom2.Tooltip = ""
        Me.cmbArticulo.ButtonDropDown.Tooltip = ""
        Me.cmbArticulo.ButtonDropDown.Visible = True
        Me.cmbArticulo.Columns.Add(Me.colCodigo)
        Me.cmbArticulo.Columns.Add(Me.colNombre)
        Me.cmbArticulo.Columns.Add(Me.colClasificacion)
        Me.cmbArticulo.DisplayMembers = "unico"
        Me.cmbArticulo.Enabled = False
        Me.cmbArticulo.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbArticulo.FormatString = "d"
        Me.cmbArticulo.FormattingEnabled = True
        Me.cmbArticulo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbArticulo.Location = New System.Drawing.Point(103, 18)
        Me.cmbArticulo.Name = "cmbArticulo"
        Me.cmbArticulo.Size = New System.Drawing.Size(522, 23)
        Me.cmbArticulo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbArticulo.TabIndex = 5
        Me.cmbArticulo.ValueMember = "Código"
        '
        'colCodigo
        '
        Me.colCodigo.DataFieldName = "código"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.Text = "Código"
        Me.colCodigo.Width.Relative = 20
        '
        'colNombre
        '
        Me.colNombre.DataFieldName = "nombre"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.Text = "Nombre"
        Me.colNombre.Width.Relative = 40
        '
        'colClasificacion
        '
        Me.colClasificacion.DataFieldName = "Clasificación"
        Me.colClasificacion.Name = "colClasificacion"
        Me.colClasificacion.Text = "Clasificación"
        Me.colClasificacion.Width.Relative = 40
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(10, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Artículo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(10, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Reposición (días)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(43, 21)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(144, 40)
        Me.ReflectionLabel1.TabIndex = 270
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>PRÉSTAMO</b></font>"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LabelX4)
        Me.GroupBox1.Controls.Add(Me.txtReloj)
        Me.GroupBox1.Location = New System.Drawing.Point(487, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(171, 49)
        Me.GroupBox1.TabIndex = 268
        Me.GroupBox1.TabStop = False
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(11, 17)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(56, 23)
        Me.LabelX4.TabIndex = 36
        Me.LabelX4.Text = "Reloj"
        '
        'txtReloj
        '
        Me.txtReloj.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.ButtonCustom.Tooltip = ""
        Me.txtReloj.ButtonCustom2.Tooltip = ""
        Me.txtReloj.Enabled = False
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.ForeColor = System.Drawing.Color.Black
        Me.txtReloj.Location = New System.Drawing.Point(81, 14)
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.ReadOnly = True
        Me.txtReloj.Size = New System.Drawing.Size(84, 26)
        Me.txtReloj.TabIndex = 56
        Me.txtReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.Color.Green
        '
        '
        '
        Me.lblEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblEstado.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.White
        Me.lblEstado.Location = New System.Drawing.Point(12, 9)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(29, 95)
        Me.lblEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblEstado.TabIndex = 269
        Me.lblEstado.Text = "ACTIVO"
        Me.lblEstado.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblEstado.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.lblEstado.VerticalTextTopUp = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(45, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 15)
        Me.Label5.TabIndex = 267
        Me.Label5.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.ButtonCustom.Tooltip = ""
        Me.txtNombre.ButtonCustom2.Tooltip = ""
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.Color.Black
        Me.txtNombre.Location = New System.Drawing.Point(45, 83)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(613, 21)
        Me.txtNombre.TabIndex = 57
        '
        'Recibir
        '
        Me.Recibir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Recibir.CausesValidation = False
        Me.Recibir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Recibir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Recibir.Image = Global.PIDA.My.Resources.Resources.navigate_down16
        Me.Recibir.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.Recibir.Location = New System.Drawing.Point(322, 354)
        Me.Recibir.Name = "Recibir"
        Me.Recibir.Size = New System.Drawing.Size(104, 25)
        Me.Recibir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Recibir.TabIndex = 3
        Me.Recibir.Text = "Devolución"
        '
        'frmEditarPrestamo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 389)
        Me.Controls.Add(Me.Recibir)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.gpDatos)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtNombre)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditarPrestamo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar"
        Me.gpDatos.ResumeLayout(False)
        Me.gpDatos.PerformLayout()
        CType(Me.txtPrestados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAPrestar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCosto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaEntrada, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaSalida, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents gpDatos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtControl As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDisponibles As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtFechaEntrada As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtFechaSalida As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtReposicion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmbArticulo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblEstado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Recibir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents colCodigo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colNombre As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colClasificacion As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents txtCosto As DevComponents.Editors.DoubleInput
    Friend WithEvents txtAPrestar As DevComponents.Editors.IntegerInput
    Friend WithEvents txtPrestados As DevComponents.Editors.IntegerInput
End Class
