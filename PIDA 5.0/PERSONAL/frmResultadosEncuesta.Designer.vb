<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResultadosEncuesta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResultadosEncuesta))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbEncuestas = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dpFechaFinal = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dpFechaInicial = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnGenerarReporte = New DevComponents.DotNetBar.ButtonX()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dpFechaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dpFechaInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Download32
        Me.PictureBox1.Location = New System.Drawing.Point(3, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 46)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 125
        Me.PictureBox1.TabStop = False
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(41, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(473, 46)
        Me.ReflectionLabel1.TabIndex = 124
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>DESCARGAR RESULTADOS ENCUESTA</b></font>"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmbEncuestas)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.dpFechaFinal)
        Me.Panel1.Controls.Add(Me.dpFechaInicial)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(56, 83)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(417, 112)
        Me.Panel1.TabIndex = 130
        '
        'cmbEncuestas
        '
        Me.cmbEncuestas.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbEncuestas.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbEncuestas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbEncuestas.ButtonDropDown.Visible = True
        Me.cmbEncuestas.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbEncuestas.Location = New System.Drawing.Point(25, 72)
        Me.cmbEncuestas.Name = "cmbEncuestas"
        Me.cmbEncuestas.Size = New System.Drawing.Size(365, 23)
        Me.cmbEncuestas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbEncuestas.TabIndex = 132
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "Encuesta"
        '
        'dpFechaFinal
        '
        '
        '
        '
        Me.dpFechaFinal.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dpFechaFinal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dpFechaFinal.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dpFechaFinal.ButtonDropDown.Visible = True
        Me.dpFechaFinal.IsPopupCalendarOpen = False
        Me.dpFechaFinal.Location = New System.Drawing.Point(288, 8)
        '
        '
        '
        Me.dpFechaFinal.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dpFechaFinal.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dpFechaFinal.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dpFechaFinal.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dpFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dpFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dpFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dpFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dpFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dpFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dpFechaFinal.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dpFechaFinal.MonthCalendar.DisplayMonth = New Date(2015, 5, 1, 0, 0, 0, 0)
        Me.dpFechaFinal.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dpFechaFinal.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dpFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dpFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dpFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dpFechaFinal.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dpFechaFinal.MonthCalendar.TodayButtonVisible = True
        Me.dpFechaFinal.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dpFechaFinal.Name = "dpFechaFinal"
        Me.dpFechaFinal.Size = New System.Drawing.Size(102, 20)
        Me.dpFechaFinal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dpFechaFinal.TabIndex = 133
        '
        'dpFechaInicial
        '
        '
        '
        '
        Me.dpFechaInicial.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dpFechaInicial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dpFechaInicial.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dpFechaInicial.ButtonDropDown.Visible = True
        Me.dpFechaInicial.IsPopupCalendarOpen = False
        Me.dpFechaInicial.Location = New System.Drawing.Point(94, 8)
        '
        '
        '
        Me.dpFechaInicial.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dpFechaInicial.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dpFechaInicial.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dpFechaInicial.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dpFechaInicial.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dpFechaInicial.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dpFechaInicial.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dpFechaInicial.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dpFechaInicial.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dpFechaInicial.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dpFechaInicial.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dpFechaInicial.MonthCalendar.DisplayMonth = New Date(2015, 5, 1, 0, 0, 0, 0)
        Me.dpFechaInicial.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dpFechaInicial.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dpFechaInicial.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dpFechaInicial.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dpFechaInicial.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dpFechaInicial.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dpFechaInicial.MonthCalendar.TodayButtonVisible = True
        Me.dpFechaInicial.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dpFechaInicial.Name = "dpFechaInicial"
        Me.dpFechaInicial.Size = New System.Drawing.Size(102, 20)
        Me.dpFechaInicial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dpFechaInicial.TabIndex = 132
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(216, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 131
        Me.Label2.Text = "Fecha final"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 130
        Me.Label1.Text = "Fecha inicial"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCerrar.Location = New System.Drawing.Point(275, 206)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(80, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 132
        Me.btnCerrar.Text = "&Salir"
        '
        'btnGenerarReporte
        '
        Me.btnGenerarReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGenerarReporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerarReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGenerarReporte.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnGenerarReporte.Location = New System.Drawing.Point(189, 206)
        Me.btnGenerarReporte.Name = "btnGenerarReporte"
        Me.btnGenerarReporte.Size = New System.Drawing.Size(80, 25)
        Me.btnGenerarReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGenerarReporte.TabIndex = 131
        Me.btnGenerarReporte.Text = "&Aceptar"
        '
        'frmResultadosEncuesta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 243)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnGenerarReporte)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmResultadosEncuesta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Resultados Encuestas"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dpFechaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dpFechaInicial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dpFechaFinal As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dpFechaInicial As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbEncuestas As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnGenerarReporte As DevComponents.DotNetBar.ButtonX
End Class
