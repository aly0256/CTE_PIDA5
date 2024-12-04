<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFiltroReporteadorIDEAS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFiltroReporteadorIDEAS))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.txtFecha1 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.txtFecha2 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.optRango = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.optPeriodo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cmbPeriodos = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.colUnico = New DevComponents.AdvTree.ColumnHeader()
        Me.colActivo = New DevComponents.AdvTree.ColumnHeader()
        Me.colAno = New DevComponents.AdvTree.ColumnHeader()
        Me.colPeriodo = New DevComponents.AdvTree.ColumnHeader()
        Me.colFechaIni = New DevComponents.AdvTree.ColumnHeader()
        Me.colFechaFin = New DevComponents.AdvTree.ColumnHeader()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAgregar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.cmbAno = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.chkAnoFiscal = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.ReflectionLabel1.Size = New System.Drawing.Size(403, 40)
        Me.ReflectionLabel1.TabIndex = 95
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>RANGO DE DATOS PARA REPORTES</b></font>"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.Calendario32
        Me.picImagen.Location = New System.Drawing.Point(12, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(34, 34)
        Me.picImagen.TabIndex = 96
        Me.picImagen.TabStop = False
        '
        'txtFecha1
        '
        '
        '
        '
        Me.txtFecha1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFecha1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtFecha1.ButtonDropDown.Visible = True
        Me.txtFecha1.Enabled = False
        Me.txtFecha1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha1.IsPopupCalendarOpen = False
        Me.txtFecha1.Location = New System.Drawing.Point(173, 78)
        '
        '
        '
        Me.txtFecha1.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFecha1.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtFecha1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha1.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFecha1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFecha1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFecha1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFecha1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFecha1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFecha1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFecha1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha1.MonthCalendar.DisplayMonth = New Date(2012, 12, 1, 0, 0, 0, 0)
        Me.txtFecha1.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFecha1.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFecha1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFecha1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFecha1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFecha1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha1.MonthCalendar.TodayButtonVisible = True
        Me.txtFecha1.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFecha1.Name = "txtFecha1"
        Me.txtFecha1.Size = New System.Drawing.Size(89, 21)
        Me.txtFecha1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFecha1.TabIndex = 4
        '
        'txtFecha2
        '
        '
        '
        '
        Me.txtFecha2.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFecha2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtFecha2.ButtonDropDown.Visible = True
        Me.txtFecha2.Enabled = False
        Me.txtFecha2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha2.IsPopupCalendarOpen = False
        Me.txtFecha2.Location = New System.Drawing.Point(340, 78)
        '
        '
        '
        Me.txtFecha2.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFecha2.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtFecha2.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha2.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFecha2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFecha2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFecha2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFecha2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFecha2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFecha2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFecha2.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha2.MonthCalendar.DisplayMonth = New Date(2012, 12, 1, 0, 0, 0, 0)
        Me.txtFecha2.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFecha2.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFecha2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFecha2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFecha2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFecha2.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha2.MonthCalendar.TodayButtonVisible = True
        Me.txtFecha2.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFecha2.Name = "txtFecha2"
        Me.txtFecha2.Size = New System.Drawing.Size(89, 21)
        Me.txtFecha2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFecha2.TabIndex = 6
        Me.txtFecha2.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(289, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 15)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "y el día"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(98, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 15)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Entre el día"
        '
        'optRango
        '
        Me.optRango.AutoSize = True
        Me.optRango.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.optRango.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.optRango.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.optRango.FocusCuesEnabled = False
        Me.optRango.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optRango.Location = New System.Drawing.Point(10, 62)
        Me.optRango.Name = "optRango"
        Me.optRango.Size = New System.Drawing.Size(139, 16)
        Me.optRango.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.optRango.TabIndex = 3
        Me.optRango.Text = "En el rango de fechas"
        Me.optRango.TextColor = System.Drawing.SystemColors.ControlText
        '
        'optPeriodo
        '
        Me.optPeriodo.AutoSize = True
        Me.optPeriodo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.optPeriodo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.optPeriodo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.optPeriodo.FocusCuesEnabled = False
        Me.optPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optPeriodo.Location = New System.Drawing.Point(10, 113)
        Me.optPeriodo.Name = "optPeriodo"
        Me.optPeriodo.Size = New System.Drawing.Size(84, 16)
        Me.optPeriodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.optPeriodo.TabIndex = 1
        Me.optPeriodo.Text = "Del periodo"
        Me.optPeriodo.TextColor = System.Drawing.SystemColors.ControlText
        '
        'cmbPeriodos
        '
        Me.cmbPeriodos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPeriodos.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPeriodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPeriodos.ButtonDropDown.Visible = True
        Me.cmbPeriodos.Columns.Add(Me.colUnico)
        Me.cmbPeriodos.Columns.Add(Me.colActivo)
        Me.cmbPeriodos.Columns.Add(Me.colAno)
        Me.cmbPeriodos.Columns.Add(Me.colPeriodo)
        Me.cmbPeriodos.Columns.Add(Me.colFechaIni)
        Me.cmbPeriodos.Columns.Add(Me.colFechaFin)
        Me.cmbPeriodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPeriodos.FormatString = "d"
        Me.cmbPeriodos.FormattingEnabled = True
        Me.cmbPeriodos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPeriodos.Location = New System.Drawing.Point(101, 113)
        Me.cmbPeriodos.Name = "cmbPeriodos"
        Me.cmbPeriodos.Size = New System.Drawing.Size(328, 21)
        Me.cmbPeriodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPeriodos.TabIndex = 2
        Me.cmbPeriodos.TabStop = False
        Me.cmbPeriodos.ThemeAware = True
        Me.cmbPeriodos.ValueMember = "unico"
        '
        'colUnico
        '
        Me.colUnico.DataFieldName = "unico"
        Me.colUnico.Name = "colUnico"
        Me.colUnico.Text = "Unico"
        Me.colUnico.Visible = False
        Me.colUnico.Width.Absolute = 150
        '
        'colActivo
        '
        Me.colActivo.DataFieldName = "activo"
        Me.colActivo.Name = "colActivo"
        Me.colActivo.Text = "Activo"
        Me.colActivo.Width.Relative = 14
        '
        'colAno
        '
        Me.colAno.DataFieldName = "ano"
        Me.colAno.Name = "colAno"
        Me.colAno.Text = "Año"
        Me.colAno.Width.Relative = 18
        '
        'colPeriodo
        '
        Me.colPeriodo.DataFieldName = "periodo"
        Me.colPeriodo.Name = "colPeriodo"
        Me.colPeriodo.Text = "Periodo"
        Me.colPeriodo.Width.Relative = 18
        '
        'colFechaIni
        '
        Me.colFechaIni.DataFieldName = "fecha_ini"
        Me.colFechaIni.Name = "colFechaIni"
        Me.colFechaIni.Text = "Fecha inicial"
        Me.colFechaIni.Width.Relative = 25
        '
        'colFechaFin
        '
        Me.colFechaFin.DataFieldName = "fecha_fin"
        Me.colFechaFin.Name = "colFechaFin"
        Me.colFechaFin.Text = "Fecha final"
        Me.colFechaFin.Width.Relative = 25
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.btnAgregar)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Location = New System.Drawing.Point(279, 187)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(176, 47)
        Me.GroupBox1.TabIndex = 98
        Me.GroupBox1.TabStop = False
        '
        'btnAgregar
        '
        Me.btnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAgregar.CausesValidation = False
        Me.btnAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = Global.PIDA.My.Resources.Resources.FiltroHC
        Me.btnAgregar.Location = New System.Drawing.Point(6, 14)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(78, 25)
        Me.btnAgregar.TabIndex = 10
        Me.btnAgregar.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCancelar.Location = New System.Drawing.Point(90, 14)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "Cancelar"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.cmbAno)
        Me.GroupPanel1.Controls.Add(Me.chkAnoFiscal)
        Me.GroupPanel1.Controls.Add(Me.optPeriodo)
        Me.GroupPanel1.Controls.Add(Me.cmbPeriodos)
        Me.GroupPanel1.Controls.Add(Me.txtFecha2)
        Me.GroupPanel1.Controls.Add(Me.optRango)
        Me.GroupPanel1.Controls.Add(Me.txtFecha1)
        Me.GroupPanel1.Controls.Add(Me.Label6)
        Me.GroupPanel1.Controls.Add(Me.Label5)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 52)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(443, 143)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor = System.Drawing.SystemColors.Window
        Me.GroupPanel1.Style.BackColor2 = System.Drawing.SystemColors.Window
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
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
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
        Me.GroupPanel1.TabIndex = 9
        '
        'cmbAno
        '
        Me.cmbAno.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbAno.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbAno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbAno.ButtonDropDown.Visible = True
        Me.cmbAno.DisplayMembers = "ano"
        Me.cmbAno.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbAno.Location = New System.Drawing.Point(101, 10)
        Me.cmbAno.Name = "cmbAno"
        Me.cmbAno.Size = New System.Drawing.Size(96, 23)
        Me.cmbAno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbAno.TabIndex = 8
        Me.cmbAno.ValueMember = "ano"
        '
        'chkAnoFiscal
        '
        Me.chkAnoFiscal.AutoSize = True
        Me.chkAnoFiscal.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkAnoFiscal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkAnoFiscal.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkAnoFiscal.Checked = True
        Me.chkAnoFiscal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAnoFiscal.CheckValue = "Y"
        Me.chkAnoFiscal.FocusCuesEnabled = False
        Me.chkAnoFiscal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAnoFiscal.Location = New System.Drawing.Point(10, 10)
        Me.chkAnoFiscal.Name = "chkAnoFiscal"
        Me.chkAnoFiscal.Size = New System.Drawing.Size(75, 16)
        Me.chkAnoFiscal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkAnoFiscal.TabIndex = 7
        Me.chkAnoFiscal.Text = "Año fiscal"
        Me.chkAnoFiscal.TextColor = System.Drawing.SystemColors.ControlText
        '
        'frmFiltroReporteadorIDEAS
        '
        Me.AcceptButton = Me.btnAgregar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(468, 242)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.picImagen)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFiltroReporteadorIDEAS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filtro al reporteador"
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents txtFecha1 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtFecha2 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents optRango As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents optPeriodo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents cmbPeriodos As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAgregar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents colUnico As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colActivo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colAno As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colPeriodo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colFechaIni As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colFechaFin As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmbAno As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents chkAnoFiscal As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
