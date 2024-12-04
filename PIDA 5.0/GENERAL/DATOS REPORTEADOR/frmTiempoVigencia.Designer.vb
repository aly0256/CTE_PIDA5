<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTiempoVigencia
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
        Me.PanelVencimiento = New System.Windows.Forms.Panel()
        Me.intDiasHoy = New DevComponents.Editors.IntegerInput()
        Me.intDiasAlta = New DevComponents.Editors.IntegerInput()
        Me.rbVigenciaHoy = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFechaVencimiento = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.rbFechaVenc = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.rbVigenciaAlta = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lblDias = New System.Windows.Forms.Label()
        Me.lblTitulo = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PanelVencimiento.SuspendLayout()
        CType(Me.intDiasHoy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.intDiasAlta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaVencimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelVencimiento
        '
        Me.PanelVencimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelVencimiento.Controls.Add(Me.intDiasHoy)
        Me.PanelVencimiento.Controls.Add(Me.intDiasAlta)
        Me.PanelVencimiento.Controls.Add(Me.rbVigenciaHoy)
        Me.PanelVencimiento.Controls.Add(Me.Label1)
        Me.PanelVencimiento.Controls.Add(Me.Label4)
        Me.PanelVencimiento.Controls.Add(Me.txtFechaVencimiento)
        Me.PanelVencimiento.Controls.Add(Me.rbFechaVenc)
        Me.PanelVencimiento.Controls.Add(Me.rbVigenciaAlta)
        Me.PanelVencimiento.Controls.Add(Me.lblDias)
        Me.PanelVencimiento.Location = New System.Drawing.Point(12, 58)
        Me.PanelVencimiento.Name = "PanelVencimiento"
        Me.PanelVencimiento.Size = New System.Drawing.Size(311, 136)
        Me.PanelVencimiento.TabIndex = 0
        '
        'intDiasHoy
        '
        '
        '
        '
        Me.intDiasHoy.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.intDiasHoy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.intDiasHoy.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.intDiasHoy.Location = New System.Drawing.Point(186, 69)
        Me.intDiasHoy.MaxValue = 750
        Me.intDiasHoy.MinValue = 1
        Me.intDiasHoy.Name = "intDiasHoy"
        Me.intDiasHoy.ShowUpDown = True
        Me.intDiasHoy.Size = New System.Drawing.Size(58, 20)
        Me.intDiasHoy.TabIndex = 5
        Me.intDiasHoy.Value = 90
        '
        'intDiasAlta
        '
        '
        '
        '
        Me.intDiasAlta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.intDiasAlta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.intDiasAlta.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.intDiasAlta.Location = New System.Drawing.Point(186, 38)
        Me.intDiasAlta.MaxValue = 750
        Me.intDiasAlta.MinValue = 1
        Me.intDiasAlta.Name = "intDiasAlta"
        Me.intDiasAlta.ShowUpDown = True
        Me.intDiasAlta.Size = New System.Drawing.Size(58, 20)
        Me.intDiasAlta.TabIndex = 2
        Me.intDiasAlta.Value = 90
        '
        'rbVigenciaHoy
        '
        '
        '
        '
        Me.rbVigenciaHoy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.rbVigenciaHoy.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.rbVigenciaHoy.Location = New System.Drawing.Point(39, 66)
        Me.rbVigenciaHoy.Name = "rbVigenciaHoy"
        Me.rbVigenciaHoy.Size = New System.Drawing.Size(141, 23)
        Me.rbVigenciaHoy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.rbVigenciaHoy.TabIndex = 4
        Me.rbVigenciaHoy.Text = "Vigencia a partir de hoy"
        Me.rbVigenciaHoy.TextColor = System.Drawing.Color.Black
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(250, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "días"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Fecha de vencimiento:"
        '
        'txtFechaVencimiento
        '
        '
        '
        '
        Me.txtFechaVencimiento.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaVencimiento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaVencimiento.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtFechaVencimiento.ButtonDropDown.Visible = True
        Me.txtFechaVencimiento.IsPopupCalendarOpen = False
        Me.txtFechaVencimiento.Location = New System.Drawing.Point(186, 95)
        '
        '
        '
        Me.txtFechaVencimiento.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaVencimiento.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaVencimiento.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtFechaVencimiento.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaVencimiento.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaVencimiento.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaVencimiento.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaVencimiento.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaVencimiento.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaVencimiento.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaVencimiento.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaVencimiento.MonthCalendar.DisplayMonth = New Date(2013, 3, 1, 0, 0, 0, 0)
        Me.txtFechaVencimiento.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaVencimiento.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaVencimiento.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaVencimiento.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaVencimiento.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaVencimiento.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaVencimiento.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaVencimiento.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFechaVencimiento.Name = "txtFechaVencimiento"
        Me.txtFechaVencimiento.Size = New System.Drawing.Size(95, 20)
        Me.txtFechaVencimiento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFechaVencimiento.TabIndex = 8
        '
        'rbFechaVenc
        '
        '
        '
        '
        Me.rbFechaVenc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.rbFechaVenc.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.rbFechaVenc.Location = New System.Drawing.Point(39, 95)
        Me.rbFechaVenc.Name = "rbFechaVenc"
        Me.rbFechaVenc.Size = New System.Drawing.Size(100, 23)
        Me.rbFechaVenc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.rbFechaVenc.TabIndex = 7
        Me.rbFechaVenc.Text = "Fecha específica"
        Me.rbFechaVenc.TextColor = System.Drawing.Color.Black
        '
        'rbVigenciaAlta
        '
        '
        '
        '
        Me.rbVigenciaAlta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.rbVigenciaAlta.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.rbVigenciaAlta.Checked = True
        Me.rbVigenciaAlta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rbVigenciaAlta.CheckValue = "Y"
        Me.rbVigenciaAlta.Location = New System.Drawing.Point(39, 35)
        Me.rbVigenciaAlta.Name = "rbVigenciaAlta"
        Me.rbVigenciaAlta.Size = New System.Drawing.Size(141, 23)
        Me.rbVigenciaAlta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.rbVigenciaAlta.TabIndex = 1
        Me.rbVigenciaAlta.Text = "Vigencia a partir de alta"
        Me.rbVigenciaAlta.TextColor = System.Drawing.Color.Black
        '
        'lblDias
        '
        Me.lblDias.AutoSize = True
        Me.lblDias.Location = New System.Drawing.Point(250, 45)
        Me.lblDias.Name = "lblDias"
        Me.lblDias.Size = New System.Drawing.Size(28, 13)
        Me.lblDias.TabIndex = 3
        Me.lblDias.Text = "días"
        '
        'lblTitulo
        '
        '
        '
        '
        Me.lblTitulo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(52, 12)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(194, 40)
        Me.lblTitulo.TabIndex = 3
        Me.lblTitulo.Text = "<font color=""#1F497D""><b>VENCIMIENTO</b></font>"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCerrar.Location = New System.Drawing.Point(168, 206)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.Text = "&Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.Location = New System.Drawing.Point(88, 206)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "&Aceptar"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources._1469761116_cmyk_04
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(34, 29)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 123
        Me.PictureBox1.TabStop = False
        '
        'frmTiempoVigencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 245)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblTitulo)
        Me.Controls.Add(Me.PanelVencimiento)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTiempoVigencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vigencia"
        Me.PanelVencimiento.ResumeLayout(False)
        Me.PanelVencimiento.PerformLayout()
        CType(Me.intDiasHoy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.intDiasAlta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaVencimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelVencimiento As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents rbVigenciaAlta As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents rbFechaVenc As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents lblDias As System.Windows.Forms.Label
    Friend WithEvents txtFechaVencimiento As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents rbVigenciaHoy As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents intDiasHoy As DevComponents.Editors.IntegerInput
    Friend WithEvents intDiasAlta As DevComponents.Editors.IntegerInput
End Class
