<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContratos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmContratos))
        Me.cmbContratos = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnGenerarReporte = New DevComponents.DotNetBar.ButtonX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkApartir = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbinicio = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.lblAlta = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lblEspecifica = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtInicioHoy = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.PanelVencimiento = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rbVigencia = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.rbFechaVenc = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lblDias = New System.Windows.Forms.Label()
        Me.cmbTipo = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.txtFechaVencimiento = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.chkWord = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.pnlAvance = New System.Windows.Forms.Panel()
        Me.lblAvance = New System.Windows.Forms.Label()
        Me.pbAvance = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtInicioHoy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelVencimiento.SuspendLayout()
        CType(Me.txtFechaVencimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAvance.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbContratos
        '
        Me.cmbContratos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbContratos.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbContratos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbContratos.ButtonDropDown.Visible = True
        Me.cmbContratos.DisplayMembers = "cod_carta"
        Me.cmbContratos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbContratos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbContratos.Location = New System.Drawing.Point(119, 17)
        Me.cmbContratos.Name = "cmbContratos"
        Me.cmbContratos.Size = New System.Drawing.Size(265, 23)
        Me.cmbContratos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbContratos.TabIndex = 0
        Me.cmbContratos.ValueMember = "tipo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(24, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Tipo de contrato"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Fecha de inicio:"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCerrar.Location = New System.Drawing.Point(208, 309)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.Text = "&Cancelar"
        '
        'btnGenerarReporte
        '
        Me.btnGenerarReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGenerarReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGenerarReporte.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnGenerarReporte.Location = New System.Drawing.Point(128, 309)
        Me.btnGenerarReporte.Name = "btnGenerarReporte"
        Me.btnGenerarReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnGenerarReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGenerarReporte.TabIndex = 2
        Me.btnGenerarReporte.Text = "&Aceptar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkApartir)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbinicio)
        Me.GroupBox1.Controls.Add(Me.lblAlta)
        Me.GroupBox1.Controls.Add(Me.lblEspecifica)
        Me.GroupBox1.Controls.Add(Me.txtInicioHoy)
        Me.GroupBox1.Controls.Add(Me.cmbContratos)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.PanelVencimiento)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(399, 251)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'chkApartir
        '
        '
        '
        '
        Me.chkApartir.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkApartir.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkApartir.Location = New System.Drawing.Point(94, 124)
        Me.chkApartir.Name = "chkApartir"
        Me.chkApartir.Size = New System.Drawing.Size(100, 23)
        Me.chkApartir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkApartir.TabIndex = 38
        Me.chkApartir.Text = "A partir "
        Me.chkApartir.TextColor = System.Drawing.Color.Black
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(263, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "días"
        '
        'cmbinicio
        '
        Me.cmbinicio.DisplayMember = "Dias"
        Me.cmbinicio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbinicio.FormattingEnabled = True
        Me.cmbinicio.ItemHeight = 14
        Me.cmbinicio.Location = New System.Drawing.Point(200, 127)
        Me.cmbinicio.Name = "cmbinicio"
        Me.cmbinicio.Size = New System.Drawing.Size(57, 20)
        Me.cmbinicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbinicio.TabIndex = 36
        Me.cmbinicio.ValueMember = "Dias"
        '
        'lblAlta
        '
        '
        '
        '
        Me.lblAlta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblAlta.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.lblAlta.Checked = True
        Me.lblAlta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.lblAlta.CheckValue = "Y"
        Me.lblAlta.Location = New System.Drawing.Point(94, 66)
        Me.lblAlta.Name = "lblAlta"
        Me.lblAlta.Size = New System.Drawing.Size(100, 23)
        Me.lblAlta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblAlta.TabIndex = 32
        Me.lblAlta.Text = "Fecha de alta"
        Me.lblAlta.TextColor = System.Drawing.Color.Black
        '
        'lblEspecifica
        '
        '
        '
        '
        Me.lblEspecifica.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblEspecifica.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.lblEspecifica.Location = New System.Drawing.Point(94, 95)
        Me.lblEspecifica.Name = "lblEspecifica"
        Me.lblEspecifica.Size = New System.Drawing.Size(100, 23)
        Me.lblEspecifica.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblEspecifica.TabIndex = 31
        Me.lblEspecifica.Text = "Fecha específica"
        Me.lblEspecifica.TextColor = System.Drawing.Color.Black
        '
        'txtInicioHoy
        '
        '
        '
        '
        Me.txtInicioHoy.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtInicioHoy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtInicioHoy.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtInicioHoy.ButtonDropDown.Visible = True
        Me.txtInicioHoy.Enabled = False
        Me.txtInicioHoy.IsPopupCalendarOpen = False
        Me.txtInicioHoy.Location = New System.Drawing.Point(200, 95)
        '
        '
        '
        Me.txtInicioHoy.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtInicioHoy.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtInicioHoy.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtInicioHoy.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtInicioHoy.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtInicioHoy.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtInicioHoy.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtInicioHoy.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtInicioHoy.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtInicioHoy.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtInicioHoy.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtInicioHoy.MonthCalendar.DisplayMonth = New Date(2013, 3, 1, 0, 0, 0, 0)
        Me.txtInicioHoy.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtInicioHoy.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtInicioHoy.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtInicioHoy.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtInicioHoy.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtInicioHoy.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtInicioHoy.MonthCalendar.TodayButtonVisible = True
        Me.txtInicioHoy.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtInicioHoy.Name = "txtInicioHoy"
        Me.txtInicioHoy.Size = New System.Drawing.Size(112, 20)
        Me.txtInicioHoy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtInicioHoy.TabIndex = 28
        '
        'PanelVencimiento
        '
        Me.PanelVencimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelVencimiento.Controls.Add(Me.Label4)
        Me.PanelVencimiento.Controls.Add(Me.rbVigencia)
        Me.PanelVencimiento.Controls.Add(Me.rbFechaVenc)
        Me.PanelVencimiento.Controls.Add(Me.lblDias)
        Me.PanelVencimiento.Controls.Add(Me.cmbTipo)
        Me.PanelVencimiento.Controls.Add(Me.txtFechaVencimiento)
        Me.PanelVencimiento.Location = New System.Drawing.Point(6, 153)
        Me.PanelVencimiento.Name = "PanelVencimiento"
        Me.PanelVencimiento.Size = New System.Drawing.Size(387, 91)
        Me.PanelVencimiento.TabIndex = 25
        Me.PanelVencimiento.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Fecha de vencimiento:"
        '
        'rbVigencia
        '
        '
        '
        '
        Me.rbVigencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.rbVigencia.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.rbVigencia.Checked = True
        Me.rbVigencia.CheckState = System.Windows.Forms.CheckState.Checked
        Me.rbVigencia.CheckValue = "Y"
        Me.rbVigencia.Location = New System.Drawing.Point(87, 54)
        Me.rbVigencia.Name = "rbVigencia"
        Me.rbVigencia.Size = New System.Drawing.Size(100, 23)
        Me.rbVigencia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.rbVigencia.TabIndex = 26
        Me.rbVigencia.Text = "Vigencia"
        Me.rbVigencia.TextColor = System.Drawing.Color.Black
        '
        'rbFechaVenc
        '
        '
        '
        '
        Me.rbFechaVenc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.rbFechaVenc.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.rbFechaVenc.Location = New System.Drawing.Point(87, 25)
        Me.rbFechaVenc.Name = "rbFechaVenc"
        Me.rbFechaVenc.Size = New System.Drawing.Size(100, 23)
        Me.rbFechaVenc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.rbFechaVenc.TabIndex = 25
        Me.rbFechaVenc.Text = "Fecha específica"
        Me.rbFechaVenc.TextColor = System.Drawing.Color.Black
        '
        'lblDias
        '
        Me.lblDias.AutoSize = True
        Me.lblDias.Location = New System.Drawing.Point(256, 64)
        Me.lblDias.Name = "lblDias"
        Me.lblDias.Size = New System.Drawing.Size(28, 13)
        Me.lblDias.TabIndex = 24
        Me.lblDias.Text = "días"
        '
        'cmbTipo
        '
        Me.cmbTipo.DisplayMember = "Dias"
        Me.cmbTipo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.ItemHeight = 14
        Me.cmbTipo.Location = New System.Drawing.Point(193, 57)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(57, 20)
        Me.cmbTipo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipo.TabIndex = 23
        Me.cmbTipo.ValueMember = "Dias"
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
        Me.txtFechaVencimiento.Enabled = False
        Me.txtFechaVencimiento.IsPopupCalendarOpen = False
        Me.txtFechaVencimiento.Location = New System.Drawing.Point(193, 25)
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
        Me.txtFechaVencimiento.Size = New System.Drawing.Size(112, 20)
        Me.txtFechaVencimiento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFechaVencimiento.TabIndex = 20
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(52, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(334, 40)
        Me.ReflectionLabel1.TabIndex = 34
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CONTRATOS</b></font>"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Contrato24
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(34, 29)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 121
        Me.PictureBox1.TabStop = False
        '
        'chkWord
        '
        '
        '
        '
        Me.chkWord.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkWord.Checked = True
        Me.chkWord.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkWord.CheckValue = "Y"
        Me.chkWord.Location = New System.Drawing.Point(18, 309)
        Me.chkWord.Name = "chkWord"
        Me.chkWord.Size = New System.Drawing.Size(96, 23)
        Me.chkWord.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkWord.TabIndex = 122
        Me.chkWord.Text = "Directo a Word"
        Me.chkWord.TextColor = System.Drawing.Color.Black
        '
        'pnlAvance
        '
        Me.pnlAvance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAvance.Controls.Add(Me.lblAvance)
        Me.pnlAvance.Controls.Add(Me.pbAvance)
        Me.pnlAvance.Location = New System.Drawing.Point(103, 52)
        Me.pnlAvance.Name = "pnlAvance"
        Me.pnlAvance.Size = New System.Drawing.Size(200, 205)
        Me.pnlAvance.TabIndex = 123
        Me.pnlAvance.Visible = False
        '
        'lblAvance
        '
        Me.lblAvance.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblAvance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvance.Location = New System.Drawing.Point(0, 174)
        Me.lblAvance.Name = "lblAvance"
        Me.lblAvance.Size = New System.Drawing.Size(198, 29)
        Me.lblAvance.TabIndex = 41
        Me.lblAvance.Text = "Generando contratos"
        Me.lblAvance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbAvance
        '
        '
        '
        '
        Me.pbAvance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pbAvance.Dock = System.Windows.Forms.DockStyle.Top
        Me.pbAvance.Location = New System.Drawing.Point(0, 0)
        Me.pbAvance.Name = "pbAvance"
        Me.pbAvance.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.pbAvance.Size = New System.Drawing.Size(198, 173)
        Me.pbAvance.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.pbAvance.TabIndex = 40
        '
        'frmContratos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 343)
        Me.Controls.Add(Me.pnlAvance)
        Me.Controls.Add(Me.chkWord)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnGenerarReporte)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmContratos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contratos"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtInicioHoy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelVencimiento.ResumeLayout(False)
        Me.PanelVencimiento.PerformLayout()
        CType(Me.txtFechaVencimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAvance.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbContratos As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnGenerarReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtFechaVencimiento As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents cmbTipo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents lblDias As System.Windows.Forms.Label
    Friend WithEvents PanelVencimiento As System.Windows.Forms.Panel
    Friend WithEvents rbFechaVenc As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents rbVigencia As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents txtInicioHoy As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblAlta As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents lblEspecifica As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkApartir As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbinicio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents chkWord As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents pnlAvance As System.Windows.Forms.Panel
    Friend WithEvents lblAvance As System.Windows.Forms.Label
    Friend WithEvents pbAvance As DevComponents.DotNetBar.Controls.CircularProgress
End Class
