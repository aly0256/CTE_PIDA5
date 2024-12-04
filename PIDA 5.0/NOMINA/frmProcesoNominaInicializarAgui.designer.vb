<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcesoNominaInicializarAgui
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtiFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.btnAcept = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dtiFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dtiFecha)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(255, 67)
        Me.GroupBox3.TabIndex = 287
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Fecha de límite aguinaldo"
        '
        'dtiFecha
        '
        '
        '
        '
        Me.dtiFecha.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtiFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFecha.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtiFecha.ButtonDropDown.Visible = True
        Me.dtiFecha.CustomFormat = "yyyy-MM-dd"
        Me.dtiFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtiFecha.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtiFecha.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dtiFecha.IsPopupCalendarOpen = False
        Me.dtiFecha.Location = New System.Drawing.Point(61, 26)
        '
        '
        '
        Me.dtiFecha.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtiFecha.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFecha.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtiFecha.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtiFecha.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtiFecha.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiFecha.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtiFecha.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtiFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtiFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtiFecha.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFecha.MonthCalendar.DisplayMonth = New Date(2023, 10, 1, 0, 0, 0, 0)
        Me.dtiFecha.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtiFecha.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtiFecha.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtiFecha.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiFecha.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtiFecha.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFecha.MonthCalendar.TodayButtonVisible = True
        Me.dtiFecha.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtiFecha.Name = "dtiFecha"
        Me.dtiFecha.Size = New System.Drawing.Size(158, 20)
        Me.dtiFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtiFecha.TabIndex = 304
        '
        'btnAcept
        '
        Me.btnAcept.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAcept.Location = New System.Drawing.Point(116, 91)
        Me.btnAcept.Name = "btnAcept"
        Me.btnAcept.Size = New System.Drawing.Size(75, 23)
        Me.btnAcept.TabIndex = 286
        Me.btnAcept.Text = "Aceptar"
        Me.btnAcept.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Location = New System.Drawing.Point(197, 91)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 288
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmProcesoNominaInicializarAgui
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 128)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnAcept)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProcesoNominaInicializarAgui"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aguinaldo anual"
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dtiFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAcept As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents dtiFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
End Class
