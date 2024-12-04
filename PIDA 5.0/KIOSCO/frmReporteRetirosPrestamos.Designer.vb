<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteRetirosPrestamos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteRetirosPrestamos))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.txtFechaFinal = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFechaInicio = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkMisc = New System.Windows.Forms.CheckBox()
        Me.chkRetiros = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkPrestamos = New System.Windows.Forms.CheckBox()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.btnSalir = New DevComponents.DotNetBar.ButtonX()
        Me.BtnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.lblError = New System.Windows.Forms.Label()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.txtFechaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.txtFechaFinal)
        Me.GroupPanel1.Controls.Add(Me.Label3)
        Me.GroupPanel1.Controls.Add(Me.txtFechaInicio)
        Me.GroupPanel1.Controls.Add(Me.Label2)
        Me.GroupPanel1.Controls.Add(Me.chkMisc)
        Me.GroupPanel1.Controls.Add(Me.chkRetiros)
        Me.GroupPanel1.Controls.Add(Me.Label1)
        Me.GroupPanel1.Controls.Add(Me.chkPrestamos)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(5, 58)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(380, 137)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor = System.Drawing.Color.White
        Me.GroupPanel1.Style.BackColor2 = System.Drawing.Color.White
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 132
        Me.GroupPanel1.Text = "Ubicación de archivos"
        '
        'txtFechaFinal
        '
        '
        '
        '
        Me.txtFechaFinal.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaFinal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFinal.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtFechaFinal.ButtonDropDown.Visible = True
        Me.txtFechaFinal.IsPopupCalendarOpen = False
        Me.txtFechaFinal.Location = New System.Drawing.Point(9, 95)
        '
        '
        '
        Me.txtFechaFinal.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaFinal.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFinal.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtFechaFinal.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaFinal.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFinal.MonthCalendar.DisplayMonth = New Date(2015, 3, 1, 0, 0, 0, 0)
        Me.txtFechaFinal.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaFinal.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaFinal.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFinal.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaFinal.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFechaFinal.Name = "txtFechaFinal"
        Me.txtFechaFinal.Size = New System.Drawing.Size(200, 20)
        Me.txtFechaFinal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFechaFinal.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(6, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Fecha de fin"
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
        Me.txtFechaInicio.Location = New System.Drawing.Point(9, 56)
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
        Me.txtFechaInicio.MonthCalendar.DisplayMonth = New Date(2015, 3, 1, 0, 0, 0, 0)
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
        Me.txtFechaInicio.Size = New System.Drawing.Size(200, 20)
        Me.txtFechaInicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFechaInicio.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(6, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Fecha de inicio"
        '
        'chkMisc
        '
        Me.chkMisc.AutoSize = True
        Me.chkMisc.BackColor = System.Drawing.Color.White
        Me.chkMisc.Checked = True
        Me.chkMisc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMisc.Location = New System.Drawing.Point(161, 20)
        Me.chkMisc.Name = "chkMisc"
        Me.chkMisc.Size = New System.Drawing.Size(85, 17)
        Me.chkMisc.TabIndex = 3
        Me.chkMisc.Text = "Miscelanéos"
        Me.chkMisc.UseVisualStyleBackColor = False
        '
        'chkRetiros
        '
        Me.chkRetiros.AutoSize = True
        Me.chkRetiros.BackColor = System.Drawing.Color.White
        Me.chkRetiros.Checked = True
        Me.chkRetiros.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRetiros.Location = New System.Drawing.Point(96, 20)
        Me.chkRetiros.Name = "chkRetiros"
        Me.chkRetiros.Size = New System.Drawing.Size(59, 17)
        Me.chkRetiros.TabIndex = 2
        Me.chkRetiros.Text = "Retiros"
        Me.chkRetiros.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(6, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Elige que solicitudes incluir"
        '
        'chkPrestamos
        '
        Me.chkPrestamos.AutoSize = True
        Me.chkPrestamos.BackColor = System.Drawing.Color.White
        Me.chkPrestamos.Checked = True
        Me.chkPrestamos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrestamos.Location = New System.Drawing.Point(9, 20)
        Me.chkPrestamos.Name = "chkPrestamos"
        Me.chkPrestamos.Size = New System.Drawing.Size(75, 17)
        Me.chkPrestamos.TabIndex = 0
        Me.chkPrestamos.Text = "Préstamos"
        Me.chkPrestamos.UseVisualStyleBackColor = False
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(38, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(371, 40)
        Me.ReflectionLabel1.TabIndex = 133
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>FILTRAR REPORTE</b></font>"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.Filtro32
        Me.picImagen.Location = New System.Drawing.Point(5, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(27, 35)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picImagen.TabIndex = 134
        Me.picImagen.TabStop = False
        '
        'btnSalir
        '
        Me.btnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSalir.CausesValidation = False
        Me.btnSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.PIDA.My.Resources.Resources.Cerrar32
        Me.btnSalir.ImageTextSpacing = 5
        Me.btnSalir.Location = New System.Drawing.Point(279, 216)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(106, 28)
        Me.btnSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSalir.TabIndex = 131
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'BtnBorrar
        '
        Me.BtnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnBorrar.CausesValidation = False
        Me.BtnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBorrar.Image = Global.PIDA.My.Resources.Resources.Printer32
        Me.BtnBorrar.ImageTextSpacing = 5
        Me.BtnBorrar.Location = New System.Drawing.Point(167, 217)
        Me.BtnBorrar.Name = "BtnBorrar"
        Me.BtnBorrar.Size = New System.Drawing.Size(106, 27)
        Me.BtnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnBorrar.TabIndex = 130
        Me.BtnBorrar.Text = "&Imprimir"
        Me.BtnBorrar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'lblError
        '
        Me.lblError.AutoSize = True
        Me.lblError.ForeColor = System.Drawing.Color.Red
        Me.lblError.Location = New System.Drawing.Point(12, 198)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(242, 13)
        Me.lblError.TabIndex = 135
        Me.lblError.Text = "*El archivo especificado no existe o es incorrecto."
        Me.lblError.Visible = False
        '
        'frmReporteRetirosPrestamos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 256)
        Me.Controls.Add(Me.BtnBorrar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.picImagen)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReporteRetirosPrestamos"
        Me.Text = "Filtrar Reporte"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.txtFechaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents txtFechaFinal As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFechaInicio As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkMisc As System.Windows.Forms.CheckBox
    Friend WithEvents chkRetiros As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkPrestamos As System.Windows.Forms.CheckBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents btnSalir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BtnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblError As System.Windows.Forms.Label
End Class
