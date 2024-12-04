<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstadisticaDisiciplinaria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEstadisticaDisiciplinaria))
        Me.cmbFecha2 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.cmbFecha1 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.cmbCat = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.cmbTipo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        CType(Me.cmbFecha2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbFecha1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbFecha2
        '
        '
        '
        '
        Me.cmbFecha2.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.cmbFecha2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbFecha2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.cmbFecha2.ButtonDropDown.Visible = True
        Me.cmbFecha2.IsPopupCalendarOpen = False
        Me.cmbFecha2.Location = New System.Drawing.Point(71, 77)
        '
        '
        '
        Me.cmbFecha2.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.cmbFecha2.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbFecha2.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.cmbFecha2.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.cmbFecha2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.cmbFecha2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.cmbFecha2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.cmbFecha2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.cmbFecha2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.cmbFecha2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.cmbFecha2.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbFecha2.MonthCalendar.DisplayMonth = New Date(2016, 8, 1, 0, 0, 0, 0)
        Me.cmbFecha2.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.cmbFecha2.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.cmbFecha2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.cmbFecha2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.cmbFecha2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.cmbFecha2.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbFecha2.MonthCalendar.TodayButtonVisible = True
        Me.cmbFecha2.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.cmbFecha2.Name = "cmbFecha2"
        Me.cmbFecha2.Size = New System.Drawing.Size(107, 20)
        Me.cmbFecha2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbFecha2.TabIndex = 0
        '
        'cmbFecha1
        '
        '
        '
        '
        Me.cmbFecha1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.cmbFecha1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbFecha1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.cmbFecha1.ButtonDropDown.Visible = True
        Me.cmbFecha1.IsPopupCalendarOpen = False
        Me.cmbFecha1.Location = New System.Drawing.Point(71, 51)
        '
        '
        '
        Me.cmbFecha1.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.cmbFecha1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbFecha1.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.cmbFecha1.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.cmbFecha1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.cmbFecha1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.cmbFecha1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.cmbFecha1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.cmbFecha1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.cmbFecha1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.cmbFecha1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbFecha1.MonthCalendar.DisplayMonth = New Date(2016, 8, 1, 0, 0, 0, 0)
        Me.cmbFecha1.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.cmbFecha1.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.cmbFecha1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.cmbFecha1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.cmbFecha1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.cmbFecha1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbFecha1.MonthCalendar.TodayButtonVisible = True
        Me.cmbFecha1.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.cmbFecha1.Name = "cmbFecha1"
        Me.cmbFecha1.Size = New System.Drawing.Size(107, 20)
        Me.cmbFecha1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbFecha1.TabIndex = 1
        '
        'cmbCat
        '
        Me.cmbCat.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbCat.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbCat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbCat.ButtonDropDown.Visible = True
        Me.cmbCat.Columns.Add(Me.ColumnHeader1)
        Me.cmbCat.Columns.Add(Me.ColumnHeader2)
        Me.cmbCat.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbCat.Location = New System.Drawing.Point(71, 123)
        Me.cmbCat.Name = "cmbCat"
        Me.cmbCat.Size = New System.Drawing.Size(179, 23)
        Me.cmbCat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbCat.TabIndex = 2
        Me.cmbCat.ValueMember = "Código"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.ColumnName = "Código"
        Me.ColumnHeader1.DataFieldName = "Código"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Código"
        Me.ColumnHeader1.Width.Absolute = 40
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.ColumnName = "Nombre"
        Me.ColumnHeader2.DataFieldName = "Nombre"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Nombre"
        Me.ColumnHeader2.Width.Absolute = 100
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
        Me.cmbTipo.Columns.Add(Me.ColumnHeader3)
        Me.cmbTipo.Columns.Add(Me.ColumnHeader4)
        Me.cmbTipo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbTipo.Location = New System.Drawing.Point(71, 155)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(179, 23)
        Me.cmbTipo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipo.TabIndex = 3
        Me.cmbTipo.ValueMember = "Código"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.ColumnName = "Código"
        Me.ColumnHeader3.DataFieldName = "Código"
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Código"
        Me.ColumnHeader3.Width.Absolute = 40
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.ColumnName = "Tipo"
        Me.ColumnHeader4.DataFieldName = "Tipo"
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "Tipo"
        Me.ColumnHeader4.Width.Absolute = 100
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(12, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Fecha"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(12, 5)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(125, 40)
        Me.ReflectionLabel1.TabIndex = 118
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>OPCIONES</b></font>"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(57, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 13)
        Me.Label2.TabIndex = 119
        Me.Label2.Text = "a"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(12, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 120
        Me.Label3.Text = "Categoria"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(12, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 121
        Me.Label4.Text = "Tipo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(52, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(19, 13)
        Me.Label5.TabIndex = 122
        Me.Label5.Text = "de"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnAceptar)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Location = New System.Drawing.Point(45, 184)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(174, 47)
        Me.GroupBox1.TabIndex = 133
        Me.GroupBox1.TabStop = False
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.Location = New System.Drawing.Point(6, 14)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.TabIndex = 11
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelar.Location = New System.Drawing.Point(88, 14)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Text = "Cancelar"
        '
        'frmEstadisticaDisiciplinaria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(262, 239)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbTipo)
        Me.Controls.Add(Me.cmbCat)
        Me.Controls.Add(Me.cmbFecha1)
        Me.Controls.Add(Me.cmbFecha2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEstadisticaDisiciplinaria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Estadísticas disciplinarias"
        CType(Me.cmbFecha2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbFecha1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbFecha2 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents cmbFecha1 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents cmbCat As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cmbTipo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
End Class
