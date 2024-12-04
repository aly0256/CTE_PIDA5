<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeleccionarFecha
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeleccionarFecha))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtFechaInicial = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtFechaInicial, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ReflectionLabel1.Location = New System.Drawing.Point(48, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(298, 94)
        Me.ReflectionLabel1.TabIndex = 105
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>SELECCIONAR FECHA</b></font>"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(191, 176)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(81, 23)
        Me.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancelar.TabIndex = 104
        Me.btnCancelar.Text = "&Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.Location = New System.Drawing.Point(104, 176)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(81, 23)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 103
        Me.btnAceptar.Text = "&Aceptar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtFechaInicial)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 112)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(354, 61)
        Me.GroupBox1.TabIndex = 102
        Me.GroupBox1.TabStop = False
        '
        'dtFechaInicial
        '
        '
        '
        '
        Me.dtFechaInicial.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtFechaInicial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaInicial.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtFechaInicial.ButtonDropDown.Visible = True
        Me.dtFechaInicial.IsPopupCalendarOpen = False
        Me.dtFechaInicial.Location = New System.Drawing.Point(156, 19)
        '
        '
        '
        Me.dtFechaInicial.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtFechaInicial.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaInicial.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtFechaInicial.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtFechaInicial.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtFechaInicial.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtFechaInicial.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtFechaInicial.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtFechaInicial.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtFechaInicial.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtFechaInicial.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaInicial.MonthCalendar.DisplayMonth = New Date(2015, 5, 1, 0, 0, 0, 0)
        Me.dtFechaInicial.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtFechaInicial.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtFechaInicial.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtFechaInicial.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtFechaInicial.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtFechaInicial.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaInicial.MonthCalendar.TodayButtonVisible = True
        Me.dtFechaInicial.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtFechaInicial.Name = "dtFechaInicial"
        Me.dtFechaInicial.Size = New System.Drawing.Size(150, 20)
        Me.dtFechaInicial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtFechaInicial.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Selecciona la fecha"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.Calendario32
        Me.picImagen.Location = New System.Drawing.Point(11, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(34, 34)
        Me.picImagen.TabIndex = 106
        Me.picImagen.TabStop = False
        '
        'frmSeleccionarFecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 211)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.picImagen)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSeleccionarFecha"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Selecciona una fecha"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtFechaInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtFechaInicial As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
