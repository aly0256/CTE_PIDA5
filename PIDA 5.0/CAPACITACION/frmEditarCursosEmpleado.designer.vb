<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditarCursosEmpleado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditarCursosEmpleado))
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gpDatos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.lblcalifminima = New System.Windows.Forms.Label()
        Me.lblaprobado = New DevComponents.DotNetBar.LabelX()
        Me.txtDuracion = New DevComponents.Editors.DoubleInput()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtComentario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnAprobado = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.txtCalificacion = New DevComponents.Editors.DoubleInput()
        Me.txtFechaFin = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.txtFechaInicio = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.cmbInstructor = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader6 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader()
        Me.cmbInstituto = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.cmbCurso = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblEstado = New DevComponents.DotNetBar.LabelX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.gpDatos.SuspendLayout()
        CType(Me.txtDuracion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCalificacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.btnCerrar.Location = New System.Drawing.Point(357, 405)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 256
        Me.btnCerrar.Text = "Cancelar"
        '
        'ElementStyle1
        '
        Me.ElementStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ElementStyle1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
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
        Me.ElementStyle1.Description = "Blue"
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.PaddingBottom = 1
        Me.ElementStyle1.PaddingLeft = 1
        Me.ElementStyle1.PaddingRight = 1
        Me.ElementStyle1.PaddingTop = 1
        Me.ElementStyle1.TextColor = System.Drawing.Color.Black
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Location = New System.Drawing.Point(10, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Curso"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Location = New System.Drawing.Point(10, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Instructor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Location = New System.Drawing.Point(10, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Instituto"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnAceptar.Location = New System.Drawing.Point(273, 405)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 255
        Me.btnAceptar.Text = "Aceptar"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Window
        Me.Label7.Location = New System.Drawing.Point(10, 131)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 26
        Me.Label7.Text = "Fecha fin"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Location = New System.Drawing.Point(10, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Fecha inicio"
        '
        'gpDatos
        '
        Me.gpDatos.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpDatos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpDatos.Controls.Add(Me.lblcalifminima)
        Me.gpDatos.Controls.Add(Me.lblaprobado)
        Me.gpDatos.Controls.Add(Me.txtDuracion)
        Me.gpDatos.Controls.Add(Me.Label10)
        Me.gpDatos.Controls.Add(Me.txtComentario)
        Me.gpDatos.Controls.Add(Me.btnAprobado)
        Me.gpDatos.Controls.Add(Me.txtCalificacion)
        Me.gpDatos.Controls.Add(Me.txtFechaFin)
        Me.gpDatos.Controls.Add(Me.txtFechaInicio)
        Me.gpDatos.Controls.Add(Me.cmbInstructor)
        Me.gpDatos.Controls.Add(Me.cmbInstituto)
        Me.gpDatos.Controls.Add(Me.cmbCurso)
        Me.gpDatos.Controls.Add(Me.Label9)
        Me.gpDatos.Controls.Add(Me.Label8)
        Me.gpDatos.Controls.Add(Me.Label4)
        Me.gpDatos.Controls.Add(Me.Label7)
        Me.gpDatos.Controls.Add(Me.Label6)
        Me.gpDatos.Controls.Add(Me.Label3)
        Me.gpDatos.Controls.Add(Me.Label2)
        Me.gpDatos.Controls.Add(Me.Label1)
        Me.gpDatos.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpDatos.Location = New System.Drawing.Point(9, 105)
        Me.gpDatos.Name = "gpDatos"
        Me.gpDatos.Size = New System.Drawing.Size(426, 294)
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
        Me.gpDatos.TabIndex = 254
        '
        'lblcalifminima
        '
        Me.lblcalifminima.AutoSize = True
        Me.lblcalifminima.BackColor = System.Drawing.SystemColors.Window
        Me.lblcalifminima.Location = New System.Drawing.Point(175, 157)
        Me.lblcalifminima.Name = "lblcalifminima"
        Me.lblcalifminima.Size = New System.Drawing.Size(51, 13)
        Me.lblcalifminima.TabIndex = 168
        Me.lblcalifminima.Text = "Fecha fin"
        '
        'lblaprobado
        '
        Me.lblaprobado.BackColor = System.Drawing.SystemColors.ButtonHighlight
        '
        '
        '
        Me.lblaprobado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblaprobado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblaprobado.Location = New System.Drawing.Point(109, 179)
        Me.lblaprobado.Name = "lblaprobado"
        Me.lblaprobado.Size = New System.Drawing.Size(190, 23)
        Me.lblaprobado.TabIndex = 166
        Me.lblaprobado.Text = "AP"
        Me.lblaprobado.Visible = False
        '
        'txtDuracion
        '
        '
        '
        '
        Me.txtDuracion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtDuracion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDuracion.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtDuracion.Increment = 1.0R
        Me.txtDuracion.Location = New System.Drawing.Point(85, 207)
        Me.txtDuracion.MaxValue = 999.0R
        Me.txtDuracion.MinValue = 0.0R
        Me.txtDuracion.Name = "txtDuracion"
        Me.txtDuracion.ShowUpDown = True
        Me.txtDuracion.Size = New System.Drawing.Size(83, 20)
        Me.txtDuracion.TabIndex = 164
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Window
        Me.Label10.Location = New System.Drawing.Point(10, 211)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(50, 13)
        Me.Label10.TabIndex = 165
        Me.Label10.Text = "Duración"
        '
        'txtComentario
        '
        '
        '
        '
        Me.txtComentario.Border.Class = "TextBoxBorder"
        Me.txtComentario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtComentario.Location = New System.Drawing.Point(85, 237)
        Me.txtComentario.Multiline = True
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(313, 31)
        Me.txtComentario.TabIndex = 146
        '
        'btnAprobado
        '
        '
        '
        '
        Me.btnAprobado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnAprobado.IsReadOnly = True
        Me.btnAprobado.Location = New System.Drawing.Point(85, 179)
        Me.btnAprobado.Name = "btnAprobado"
        Me.btnAprobado.OffText = "No"
        Me.btnAprobado.OnText = "Si"
        Me.btnAprobado.Size = New System.Drawing.Size(83, 22)
        Me.btnAprobado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAprobado.TabIndex = 145
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
        Me.txtCalificacion.Location = New System.Drawing.Point(85, 153)
        Me.txtCalificacion.MaxValue = 100.0R
        Me.txtCalificacion.MinValue = 0.0R
        Me.txtCalificacion.Name = "txtCalificacion"
        Me.txtCalificacion.ShowUpDown = True
        Me.txtCalificacion.Size = New System.Drawing.Size(83, 20)
        Me.txtCalificacion.TabIndex = 35
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
        Me.txtFechaFin.Location = New System.Drawing.Point(85, 127)
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
        Me.txtFechaFin.MonthCalendar.DisplayMonth = New Date(2014, 5, 1, 0, 0, 0, 0)
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
        Me.txtFechaFin.Size = New System.Drawing.Size(83, 20)
        Me.txtFechaFin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFechaFin.TabIndex = 34
        '
        'txtFechaInicio
        '
        '
        '
        '
        Me.txtFechaInicio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaInicio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaInicio.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtFechaInicio.ButtonDropDown.Visible = True
        Me.txtFechaInicio.IsPopupCalendarOpen = False
        Me.txtFechaInicio.Location = New System.Drawing.Point(85, 101)
        '
        '
        '
        Me.txtFechaInicio.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaInicio.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaInicio.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtFechaInicio.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaInicio.MonthCalendar.DisplayMonth = New Date(2014, 5, 1, 0, 0, 0, 0)
        Me.txtFechaInicio.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaInicio.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaInicio.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaInicio.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaInicio.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.Size = New System.Drawing.Size(83, 20)
        Me.txtFechaInicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFechaInicio.TabIndex = 33
        '
        'cmbInstructor
        '
        Me.cmbInstructor.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbInstructor.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbInstructor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbInstructor.ButtonCustom.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.cmbInstructor.ButtonCustom.Visible = True
        Me.cmbInstructor.ButtonDropDown.Visible = True
        Me.cmbInstructor.Columns.Add(Me.ColumnHeader6)
        Me.cmbInstructor.Columns.Add(Me.ColumnHeader5)
        Me.cmbInstructor.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbInstructor.Location = New System.Drawing.Point(85, 72)
        Me.cmbInstructor.Name = "cmbInstructor"
        Me.cmbInstructor.Size = New System.Drawing.Size(313, 23)
        Me.cmbInstructor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbInstructor.TabIndex = 32
        Me.cmbInstructor.ValueMember = "cod_instructor"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.DataFieldName = "nombre"
        Me.ColumnHeader6.Name = "ColumnHeader6"
        Me.ColumnHeader6.Text = "Nombre"
        Me.ColumnHeader6.Width.Absolute = 150
        Me.ColumnHeader6.Width.Relative = 80
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DataFieldName = "cod_instructor"
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.Text = "Código"
        Me.ColumnHeader5.Width.Relative = 20
        '
        'cmbInstituto
        '
        Me.cmbInstituto.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbInstituto.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbInstituto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbInstituto.ButtonCustom.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.cmbInstituto.ButtonCustom.Visible = True
        Me.cmbInstituto.ButtonDropDown.Visible = True
        Me.cmbInstituto.Columns.Add(Me.ColumnHeader4)
        Me.cmbInstituto.Columns.Add(Me.ColumnHeader3)
        Me.cmbInstituto.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbInstituto.Location = New System.Drawing.Point(85, 43)
        Me.cmbInstituto.Name = "cmbInstituto"
        Me.cmbInstituto.Size = New System.Drawing.Size(313, 23)
        Me.cmbInstituto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbInstituto.TabIndex = 31
        Me.cmbInstituto.ValueMember = "cod_instituto"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DataFieldName = "nombre"
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "Nombre"
        Me.ColumnHeader4.Width.Relative = 80
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DataFieldName = "cod_instituto"
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Código"
        Me.ColumnHeader3.Width.Relative = 20
        '
        'cmbCurso
        '
        Me.cmbCurso.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbCurso.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbCurso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbCurso.ButtonCustom.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.cmbCurso.ButtonCustom.Visible = True
        Me.cmbCurso.ButtonDropDown.Visible = True
        Me.cmbCurso.Columns.Add(Me.ColumnHeader2)
        Me.cmbCurso.Columns.Add(Me.ColumnHeader1)
        Me.cmbCurso.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbCurso.Location = New System.Drawing.Point(85, 14)
        Me.cmbCurso.Name = "cmbCurso"
        Me.cmbCurso.Size = New System.Drawing.Size(313, 23)
        Me.cmbCurso.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbCurso.TabIndex = 30
        Me.cmbCurso.ValueMember = "cod_curso"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "nombre"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Nombre"
        Me.ColumnHeader2.Width.Relative = 80
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "cod_curso"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Código"
        Me.ColumnHeader1.Width.Relative = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Window
        Me.Label9.Location = New System.Drawing.Point(10, 237)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 13)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Comentarios"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Window
        Me.Label8.Location = New System.Drawing.Point(10, 184)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Aprobado"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Location = New System.Drawing.Point(10, 157)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Calificación"
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.Color.Green
        '
        '
        '
        Me.lblEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblEstado.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Window
        Me.lblEstado.Location = New System.Drawing.Point(6, 8)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(29, 91)
        Me.lblEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblEstado.TabIndex = 260
        Me.lblEstado.Text = "ACTIVO"
        Me.lblEstado.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblEstado.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.lblEstado.VerticalTextTopUp = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(39, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 15)
        Me.Label5.TabIndex = 258
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
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.Color.Black
        Me.txtNombre.Location = New System.Drawing.Point(39, 78)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(396, 21)
        Me.txtNombre.TabIndex = 257
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
        Me.txtReloj.Enabled = False
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.ForeColor = System.Drawing.Color.Black
        Me.txtReloj.Location = New System.Drawing.Point(73, 17)
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.Size = New System.Drawing.Size(111, 26)
        Me.txtReloj.TabIndex = 0
        Me.txtReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.LabelX4)
        Me.GroupBox1.Controls.Add(Me.txtReloj)
        Me.GroupBox1.Location = New System.Drawing.Point(242, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(193, 49)
        Me.GroupBox1.TabIndex = 259
        Me.GroupBox1.TabStop = False
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBuscar.Location = New System.Drawing.Point(161, 17)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(26, 25)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 262
        Me.btnBuscar.Tooltip = "Buscar"
        Me.btnBuscar.Visible = False
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(37, 16)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(199, 40)
        Me.ReflectionLabel1.TabIndex = 261
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CURSOS</b></font>"
        '
        'frmEditarCursosEmpleado
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(444, 442)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.gpDatos)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditarCursosEmpleado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar / agregar"
        Me.gpDatos.ResumeLayout(False)
        Me.gpDatos.PerformLayout()
        CType(Me.txtDuracion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCalificacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents gpDatos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lblEstado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCalificacion As DevComponents.Editors.DoubleInput
    Friend WithEvents txtFechaFin As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtFechaInicio As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents cmbInstructor As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cmbInstituto As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cmbCurso As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents txtComentario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnAprobado As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader6 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtDuracion As DevComponents.Editors.DoubleInput
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblaprobado As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblcalifminima As System.Windows.Forms.Label
End Class
