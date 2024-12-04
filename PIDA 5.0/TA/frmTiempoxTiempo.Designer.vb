<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTiempoxTiempo
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
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.gpEmpleados = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.txtNuevafecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txtFechaOriginal = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.gpEmpleados.SuspendLayout()
        CType(Me.txtNuevafecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaOriginal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(12, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(266, 46)
        Me.ReflectionLabel1.TabIndex = 127
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>TIEMPO x TIEMPO</b></font>"
        '
        'gpEmpleados
        '
        Me.gpEmpleados.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpEmpleados.BackColor = System.Drawing.SystemColors.Control
        Me.gpEmpleados.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpEmpleados.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpEmpleados.Controls.Add(Me.LabelX2)
        Me.gpEmpleados.Controls.Add(Me.txtNuevafecha)
        Me.gpEmpleados.Controls.Add(Me.LabelX1)
        Me.gpEmpleados.Controls.Add(Me.txtFechaOriginal)
        Me.gpEmpleados.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpEmpleados.Location = New System.Drawing.Point(12, 64)
        Me.gpEmpleados.Name = "gpEmpleados"
        Me.gpEmpleados.Size = New System.Drawing.Size(266, 138)
        '
        '
        '
        Me.gpEmpleados.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpEmpleados.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpEmpleados.Style.BackColorGradientAngle = 90
        Me.gpEmpleados.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpEmpleados.Style.BorderBottomWidth = 1
        Me.gpEmpleados.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpEmpleados.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpEmpleados.Style.BorderLeftWidth = 1
        Me.gpEmpleados.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpEmpleados.Style.BorderRightWidth = 1
        Me.gpEmpleados.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpEmpleados.Style.BorderTopWidth = 1
        Me.gpEmpleados.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpEmpleados.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpEmpleados.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpEmpleados.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpEmpleados.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpEmpleados.TabIndex = 129
        Me.gpEmpleados.Text = "Modificar fecha"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(3, 3)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(250, 23)
        Me.LabelX2.TabIndex = 133
        Me.LabelX2.Text = "Fecha que trabajará el empleado"
        '
        'txtNuevafecha
        '
        '
        '
        '
        Me.txtNuevafecha.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtNuevafecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNuevafecha.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtNuevafecha.ButtonDropDown.Visible = True
        Me.txtNuevafecha.IsPopupCalendarOpen = False
        Me.txtNuevafecha.Location = New System.Drawing.Point(3, 32)
        '
        '
        '
        Me.txtNuevafecha.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtNuevafecha.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNuevafecha.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtNuevafecha.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtNuevafecha.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtNuevafecha.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtNuevafecha.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtNuevafecha.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtNuevafecha.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtNuevafecha.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtNuevafecha.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNuevafecha.MonthCalendar.DisplayMonth = New Date(2016, 1, 1, 0, 0, 0, 0)
        Me.txtNuevafecha.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtNuevafecha.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtNuevafecha.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtNuevafecha.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtNuevafecha.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtNuevafecha.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNuevafecha.MonthCalendar.TodayButtonVisible = True
        Me.txtNuevafecha.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtNuevafecha.Name = "txtNuevafecha"
        Me.txtNuevafecha.Size = New System.Drawing.Size(163, 20)
        Me.txtNuevafecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtNuevafecha.TabIndex = 132
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(3, 58)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(250, 23)
        Me.LabelX1.TabIndex = 4
        Me.LabelX1.Text = "Fecha que descansará el empleado"
        '
        'txtFechaOriginal
        '
        '
        '
        '
        Me.txtFechaOriginal.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaOriginal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaOriginal.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtFechaOriginal.ButtonDropDown.Visible = True
        Me.txtFechaOriginal.IsPopupCalendarOpen = False
        Me.txtFechaOriginal.Location = New System.Drawing.Point(3, 87)
        '
        '
        '
        Me.txtFechaOriginal.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaOriginal.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaOriginal.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtFechaOriginal.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaOriginal.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaOriginal.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaOriginal.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaOriginal.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaOriginal.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaOriginal.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaOriginal.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaOriginal.MonthCalendar.DisplayMonth = New Date(2016, 1, 1, 0, 0, 0, 0)
        Me.txtFechaOriginal.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaOriginal.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaOriginal.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaOriginal.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaOriginal.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaOriginal.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaOriginal.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaOriginal.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFechaOriginal.Name = "txtFechaOriginal"
        Me.txtFechaOriginal.Size = New System.Drawing.Size(163, 20)
        Me.txtFechaOriginal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFechaOriginal.TabIndex = 3
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelar.Location = New System.Drawing.Point(200, 208)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 131
        Me.btnCancelar.Text = "Salir"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.Location = New System.Drawing.Point(116, 208)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.TabIndex = 12
        Me.btnAceptar.Text = "Aplicar"
        '
        'frmTiempoxTiempo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(287, 245)
        Me.Controls.Add(Me.gpEmpleados)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Name = "frmTiempoxTiempo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificación TiempoxTiempo"
        Me.gpEmpleados.ResumeLayout(False)
        CType(Me.txtNuevafecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaOriginal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Private WithEvents gpEmpleados As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtFechaOriginal As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtNuevafecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
End Class
