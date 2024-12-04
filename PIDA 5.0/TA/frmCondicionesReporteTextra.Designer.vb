<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCondicionesReporteTextra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCondicionesReporteTextra))
        Me.lblTituloPantalla = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtiFechaAutorizacion = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.btnAutorizarGlobal = New DevComponents.DotNetBar.ButtonX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtComentarios = New System.Windows.Forms.TextBox()
        Me.txtHoraDesde = New System.Windows.Forms.TextBox()
        Me.txtHoraHasta = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.dtiFechaAutorizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTituloPantalla
        '
        Me.lblTituloPantalla.AutoSize = True
        Me.lblTituloPantalla.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloPantalla.ForeColor = System.Drawing.Color.Black
        Me.lblTituloPantalla.Location = New System.Drawing.Point(7, 9)
        Me.lblTituloPantalla.Name = "lblTituloPantalla"
        Me.lblTituloPantalla.Size = New System.Drawing.Size(256, 26)
        Me.lblTituloPantalla.TabIndex = 115
        Me.lblTituloPantalla.Text = "Reporte de tiempo extra"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 35)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 117
        Me.Label5.Text = "Fecha"
        '
        'dtiFechaAutorizacion
        '
        '
        '
        '
        Me.dtiFechaAutorizacion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtiFechaAutorizacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFechaAutorizacion.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtiFechaAutorizacion.ButtonDropDown.Visible = True
        Me.dtiFechaAutorizacion.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
        Me.dtiFechaAutorizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtiFechaAutorizacion.IsPopupCalendarOpen = False
        Me.dtiFechaAutorizacion.Location = New System.Drawing.Point(12, 51)
        '
        '
        '
        Me.dtiFechaAutorizacion.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtiFechaAutorizacion.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFechaAutorizacion.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.dtiFechaAutorizacion.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtiFechaAutorizacion.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiFechaAutorizacion.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtiFechaAutorizacion.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtiFechaAutorizacion.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtiFechaAutorizacion.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtiFechaAutorizacion.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFechaAutorizacion.MonthCalendar.DisplayMonth = New Date(2017, 7, 1, 0, 0, 0, 0)
        Me.dtiFechaAutorizacion.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.dtiFechaAutorizacion.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtiFechaAutorizacion.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtiFechaAutorizacion.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtiFechaAutorizacion.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiFechaAutorizacion.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtiFechaAutorizacion.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiFechaAutorizacion.MonthCalendar.TodayButtonVisible = True
        Me.dtiFechaAutorizacion.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtiFechaAutorizacion.Name = "dtiFechaAutorizacion"
        Me.dtiFechaAutorizacion.Size = New System.Drawing.Size(129, 26)
        Me.dtiFechaAutorizacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtiFechaAutorizacion.TabIndex = 116
        '
        'btnAutorizarGlobal
        '
        Me.btnAutorizarGlobal.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAutorizarGlobal.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAutorizarGlobal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAutorizarGlobal.Image = Global.PIDA.My.Resources.Resources.Printer16
        Me.btnAutorizarGlobal.Location = New System.Drawing.Point(184, 223)
        Me.btnAutorizarGlobal.Name = "btnAutorizarGlobal"
        Me.btnAutorizarGlobal.Size = New System.Drawing.Size(88, 26)
        Me.btnAutorizarGlobal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAutorizarGlobal.TabIndex = 118
        Me.btnAutorizarGlobal.Text = "Generar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 119
        Me.Label1.Text = "Comentario" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtComentarios
        '
        Me.txtComentarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentarios.Location = New System.Drawing.Point(12, 142)
        Me.txtComentarios.Multiline = True
        Me.txtComentarios.Name = "txtComentarios"
        Me.txtComentarios.Size = New System.Drawing.Size(260, 75)
        Me.txtComentarios.TabIndex = 120
        '
        'txtHoraDesde
        '
        Me.txtHoraDesde.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraDesde.Location = New System.Drawing.Point(12, 97)
        Me.txtHoraDesde.Name = "txtHoraDesde"
        Me.txtHoraDesde.Size = New System.Drawing.Size(75, 26)
        Me.txtHoraDesde.TabIndex = 121
        '
        'txtHoraHasta
        '
        Me.txtHoraHasta.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraHasta.Location = New System.Drawing.Point(93, 97)
        Me.txtHoraHasta.Name = "txtHoraHasta"
        Me.txtHoraHasta.Size = New System.Drawing.Size(75, 26)
        Me.txtHoraHasta.TabIndex = 122
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 123
        Me.Label2.Text = "Desde:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(90, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 124
        Me.Label3.Text = "Hasta:"
        '
        'frmCondicionesReporteTextra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtHoraHasta)
        Me.Controls.Add(Me.txtHoraDesde)
        Me.Controls.Add(Me.txtComentarios)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAutorizarGlobal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtiFechaAutorizacion)
        Me.Controls.Add(Me.lblTituloPantalla)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCondicionesReporteTextra"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de tiempo extra"
        CType(Me.dtiFechaAutorizacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTituloPantalla As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtiFechaAutorizacion As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents btnAutorizarGlobal As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtComentarios As System.Windows.Forms.TextBox
    Friend WithEvents txtHoraDesde As System.Windows.Forms.TextBox
    Friend WithEvents txtHoraHasta As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
