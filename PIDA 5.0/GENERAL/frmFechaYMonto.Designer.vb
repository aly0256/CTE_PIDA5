<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFechaYMonto
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFechaYMonto))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtMonto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(63, -27)
        Me.ReflectionLabel1.Margin = New System.Windows.Forms.Padding(4)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(303, 110)
        Me.ReflectionLabel1.TabIndex = 110
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>Fecha y Monto de Retiro de Dispersion</b></font>"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(239, 164)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(108, 28)
        Me.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancelar.TabIndex = 109
        Me.btnCancelar.Text = "&Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Location = New System.Drawing.Point(123, 164)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(108, 28)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 108
        Me.btnAceptar.Text = "&Aceptar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtMonto)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtFecha)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(57, 71)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(257, 91)
        Me.GroupBox1.TabIndex = 107
        Me.GroupBox1.TabStop = False
        '
        'txtMonto
        '
        '
        '
        '
        Me.txtMonto.Border.Class = "TextBoxBorder"
        Me.txtMonto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMonto.Location = New System.Drawing.Point(87, 50)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.PreventEnterBeep = True
        Me.txtMonto.Size = New System.Drawing.Size(136, 22)
        Me.txtMonto.TabIndex = 107
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 52)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 17)
        Me.Label2.TabIndex = 108
        Me.Label2.Text = "Monto"
        '
        'dtFecha
        '
        '
        '
        '
        Me.dtFecha.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFecha.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtFecha.ButtonDropDown.Visible = True
        Me.dtFecha.IsPopupCalendarOpen = False
        Me.dtFecha.Location = New System.Drawing.Point(87, 24)
        Me.dtFecha.Margin = New System.Windows.Forms.Padding(4)
        '
        '
        '
        Me.dtFecha.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtFecha.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFecha.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtFecha.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtFecha.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtFecha.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtFecha.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtFecha.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtFecha.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFecha.MonthCalendar.DisplayMonth = New Date(2015, 5, 1, 0, 0, 0, 0)
        Me.dtFecha.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtFecha.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtFecha.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtFecha.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtFecha.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtFecha.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFecha.MonthCalendar.TodayButtonVisible = True
        Me.dtFecha.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtFecha.Name = "dtFecha"
        Me.dtFecha.Size = New System.Drawing.Size(136, 22)
        Me.dtFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtFecha.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 26)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fecha"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.Calendario32
        Me.picImagen.Location = New System.Drawing.Point(7, 12)
        Me.picImagen.Margin = New System.Windows.Forms.Padding(4)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(45, 42)
        Me.picImagen.TabIndex = 111
        Me.picImagen.TabStop = False
        '
        'frmFechaYMonto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(363, 206)
        Me.ControlBox = False
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.picImagen)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFechaYMonto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fecha y Monto"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtMonto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
End Class
