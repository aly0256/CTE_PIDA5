<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAjusteFiniquito
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtFolio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.AntigEmp = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.AltaEmp = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbPeriodos = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ElementStyle2 = New DevComponents.DotNetBar.ElementStyle()
        Me.lblTipoNomProcesada = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.swdespensa = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbsueldodias = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.swdiasano = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbsueldoprima = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.swgratificacion = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbsueldograf = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.txtNumGratificacion = New DevComponents.Editors.IntegerInput()
        Me.swantiguedad = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPerFija = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNetoFijo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.swpercefija = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.swnetofijo = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.EliminaConce = New DevComponents.DotNetBar.ButtonX()
        Me.btnAgregaConcepto = New DevComponents.DotNetBar.ButtonX()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbConceptos = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.dgvConceptos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ColConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMonto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColFactor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnCargaDef = New DevComponents.DotNetBar.ButtonX()
        Me.swComplemento = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.BajaFiniquito = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCalcular = New DevComponents.DotNetBar.ButtonX()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnSalir = New DevComponents.DotNetBar.ButtonX()
        Me.pnlEmp = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        CType(Me.AntigEmp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AltaEmp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.txtNumGratificacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.dgvConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.BajaFiniquito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEmp.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LabelX4)
        Me.GroupBox1.Controls.Add(Me.txtFolio)
        Me.GroupBox1.Location = New System.Drawing.Point(692, 5)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(356, 60)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(15, 21)
        Me.LabelX4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 28)
        Me.LabelX4.TabIndex = 0
        Me.LabelX4.Text = "Folio"
        '
        'txtFolio
        '
        Me.txtFolio.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtFolio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFolio.Enabled = False
        Me.txtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFolio.ForeColor = System.Drawing.Color.Black
        Me.txtFolio.Location = New System.Drawing.Point(105, 18)
        Me.txtFolio.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.ReadOnly = True
        Me.txtFolio.Size = New System.Drawing.Size(239, 24)
        Me.txtFolio.TabIndex = 1
        Me.txtFolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(20, 5)
        Me.ReflectionLabel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(300, 49)
        Me.ReflectionLabel1.TabIndex = 4
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CÁLCULO FINIQUITO</b></font>"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(156, 4)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 18)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.Color.Black
        Me.txtNombre.Location = New System.Drawing.Point(156, 26)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(528, 24)
        Me.txtNombre.TabIndex = 6
        '
        'AntigEmp
        '
        '
        '
        '
        Me.AntigEmp.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.AntigEmp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.AntigEmp.ButtonDropDown.Visible = True
        Me.AntigEmp.DisabledForeColor = System.Drawing.Color.Black
        Me.AntigEmp.FocusHighlightEnabled = True
        Me.AntigEmp.IsPopupCalendarOpen = False
        Me.AntigEmp.Location = New System.Drawing.Point(905, 27)
        Me.AntigEmp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        '
        '
        '
        Me.AntigEmp.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.AntigEmp.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.AntigEmp.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.AntigEmp.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.AntigEmp.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.AntigEmp.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.AntigEmp.MonthCalendar.DisplayMonth = New Date(2007, 10, 1, 0, 0, 0, 0)
        Me.AntigEmp.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.AntigEmp.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.AntigEmp.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.AntigEmp.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.AntigEmp.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.AntigEmp.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.AntigEmp.MonthCalendar.TodayButtonVisible = True
        Me.AntigEmp.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.AntigEmp.Name = "AntigEmp"
        Me.AntigEmp.Size = New System.Drawing.Size(109, 22)
        Me.AntigEmp.TabIndex = 160
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(888, 5)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(125, 18)
        Me.Label13.TabIndex = 161
        Me.Label13.Text = "Fecha Antiguedad"
        '
        'AltaEmp
        '
        '
        '
        '
        Me.AltaEmp.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.AltaEmp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.AltaEmp.ButtonDropDown.Visible = True
        Me.AltaEmp.DisabledForeColor = System.Drawing.Color.Black
        Me.AltaEmp.FocusHighlightEnabled = True
        Me.AltaEmp.IsPopupCalendarOpen = False
        Me.AltaEmp.Location = New System.Drawing.Point(752, 27)
        Me.AltaEmp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        '
        '
        '
        Me.AltaEmp.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.AltaEmp.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.AltaEmp.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.AltaEmp.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.AltaEmp.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.AltaEmp.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.AltaEmp.MonthCalendar.DisplayMonth = New Date(2007, 10, 1, 0, 0, 0, 0)
        Me.AltaEmp.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.AltaEmp.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.AltaEmp.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.AltaEmp.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.AltaEmp.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.AltaEmp.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.AltaEmp.MonthCalendar.TodayButtonVisible = True
        Me.AltaEmp.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.AltaEmp.Name = "AltaEmp"
        Me.AltaEmp.Size = New System.Drawing.Size(109, 22)
        Me.AltaEmp.TabIndex = 158
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(763, 5)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 18)
        Me.Label10.TabIndex = 159
        Me.Label10.Text = "Fecha Alta"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmbPeriodos)
        Me.Panel1.Controls.Add(Me.lblTipoNomProcesada)
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1019, 33)
        Me.Panel1.TabIndex = 162
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
        Me.cmbPeriodos.DisplayMembers = "unico"
        Me.cmbPeriodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPeriodos.FormatString = "d"
        Me.cmbPeriodos.FormattingEnabled = True
        Me.cmbPeriodos.GroupingMembers = "año"
        Me.cmbPeriodos.GroupNodeStyle = Me.ElementStyle2
        Me.cmbPeriodos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPeriodos.Location = New System.Drawing.Point(355, 4)
        Me.cmbPeriodos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbPeriodos.Name = "cmbPeriodos"
        Me.cmbPeriodos.Size = New System.Drawing.Size(648, 26)
        Me.cmbPeriodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPeriodos.TabIndex = 163
        Me.cmbPeriodos.TabStop = False
        Me.cmbPeriodos.ThemeAware = True
        Me.cmbPeriodos.ValueMember = "unico"
        '
        'ElementStyle2
        '
        Me.ElementStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ElementStyle2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ElementStyle2.BackColorGradientAngle = 90
        Me.ElementStyle2.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderBottomWidth = 1
        Me.ElementStyle2.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle2.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderLeftWidth = 1
        Me.ElementStyle2.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderRightWidth = 1
        Me.ElementStyle2.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderTopWidth = 1
        Me.ElementStyle2.CornerDiameter = 4
        Me.ElementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle2.Description = "Blue"
        Me.ElementStyle2.Name = "ElementStyle2"
        Me.ElementStyle2.PaddingBottom = 1
        Me.ElementStyle2.PaddingLeft = 1
        Me.ElementStyle2.PaddingRight = 1
        Me.ElementStyle2.PaddingTop = 1
        Me.ElementStyle2.TextColor = System.Drawing.Color.Black
        '
        'lblTipoNomProcesada
        '
        Me.lblTipoNomProcesada.AutoSize = True
        Me.lblTipoNomProcesada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoNomProcesada.Location = New System.Drawing.Point(17, 7)
        Me.lblTipoNomProcesada.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTipoNomProcesada.Name = "lblTipoNomProcesada"
        Me.lblTipoNomProcesada.Size = New System.Drawing.Size(230, 18)
        Me.lblTipoNomProcesada.TabIndex = 164
        Me.lblTipoNomProcesada.Text = "Periodo última nómina procesada"
        Me.lblTipoNomProcesada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Location = New System.Drawing.Point(16, 128)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1032, 476)
        Me.Panel2.TabIndex = 163
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label17)
        Me.Panel6.Controls.Add(Me.swdespensa)
        Me.Panel6.Controls.Add(Me.Label4)
        Me.Panel6.Controls.Add(Me.cmbsueldodias)
        Me.Panel6.Controls.Add(Me.swdiasano)
        Me.Panel6.Controls.Add(Me.Label16)
        Me.Panel6.Controls.Add(Me.Label15)
        Me.Panel6.Controls.Add(Me.cmbsueldoprima)
        Me.Panel6.Controls.Add(Me.Label9)
        Me.Panel6.Controls.Add(Me.Label3)
        Me.Panel6.Controls.Add(Me.swgratificacion)
        Me.Panel6.Controls.Add(Me.Label8)
        Me.Panel6.Controls.Add(Me.cmbsueldograf)
        Me.Panel6.Controls.Add(Me.txtNumGratificacion)
        Me.Panel6.Controls.Add(Me.swantiguedad)
        Me.Panel6.Controls.Add(Me.Label7)
        Me.Panel6.Controls.Add(Me.txtPerFija)
        Me.Panel6.Controls.Add(Me.txtNetoFijo)
        Me.Panel6.Controls.Add(Me.swpercefija)
        Me.Panel6.Controls.Add(Me.Label12)
        Me.Panel6.Controls.Add(Me.swnetofijo)
        Me.Panel6.Controls.Add(Me.Label11)
        Me.Panel6.Location = New System.Drawing.Point(4, 362)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(1019, 108)
        Me.Panel6.TabIndex = 166
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(660, 78)
        Me.Label17.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(54, 18)
        Me.Label17.TabIndex = 283
        Me.Label17.Text = "Sueldo"
        '
        'swdespensa
        '
        '
        '
        '
        Me.swdespensa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swdespensa.Location = New System.Drawing.Point(145, 6)
        Me.swdespensa.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.swdespensa.Name = "swdespensa"
        Me.swdespensa.OffBackColor = System.Drawing.Color.LightCoral
        Me.swdespensa.OffText = "NO"
        Me.swdespensa.OnBackColor = System.Drawing.Color.LightGreen
        Me.swdespensa.OnText = "SI"
        Me.swdespensa.Size = New System.Drawing.Size(88, 27)
        Me.swdespensa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swdespensa.TabIndex = 270
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 11)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 18)
        Me.Label4.TabIndex = 269
        Me.Label4.Text = "Incluir despensa"
        '
        'cmbsueldodias
        '
        Me.cmbsueldodias.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbsueldodias.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbsueldodias.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbsueldodias.ButtonDropDown.Visible = True
        Me.cmbsueldodias.Enabled = False
        Me.cmbsueldodias.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbsueldodias.Location = New System.Drawing.Point(729, 74)
        Me.cmbsueldodias.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbsueldodias.Name = "cmbsueldodias"
        Me.cmbsueldodias.Size = New System.Drawing.Size(105, 28)
        Me.cmbsueldodias.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbsueldodias.TabIndex = 282
        '
        'swdiasano
        '
        '
        '
        '
        Me.swdiasano.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swdiasano.Location = New System.Drawing.Point(569, 74)
        Me.swdiasano.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.swdiasano.Name = "swdiasano"
        Me.swdiasano.OffBackColor = System.Drawing.Color.LightCoral
        Me.swdiasano.OffText = "NO"
        Me.swdiasano.OnBackColor = System.Drawing.Color.LightGreen
        Me.swdiasano.OnText = "SI"
        Me.swdiasano.Size = New System.Drawing.Size(88, 27)
        Me.swdiasano.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swdiasano.TabIndex = 281
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(439, 78)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(110, 18)
        Me.Label16.TabIndex = 280
        Me.Label16.Text = "20 días por año"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(665, 11)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 18)
        Me.Label15.TabIndex = 279
        Me.Label15.Text = "Sueldo"
        '
        'cmbsueldoprima
        '
        Me.cmbsueldoprima.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbsueldoprima.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbsueldoprima.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbsueldoprima.ButtonDropDown.Visible = True
        Me.cmbsueldoprima.Enabled = False
        Me.cmbsueldoprima.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbsueldoprima.Location = New System.Drawing.Point(729, 7)
        Me.cmbsueldoprima.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbsueldoprima.Name = "cmbsueldoprima"
        Me.cmbsueldoprima.Size = New System.Drawing.Size(105, 28)
        Me.cmbsueldoprima.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbsueldoprima.TabIndex = 278
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(839, 46)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 18)
        Me.Label9.TabIndex = 277
        Me.Label9.Text = "Sueldo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(665, 46)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 18)
        Me.Label3.TabIndex = 276
        Me.Label3.Text = "Días"
        '
        'swgratificacion
        '
        '
        '
        '
        Me.swgratificacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swgratificacion.Location = New System.Drawing.Point(569, 41)
        Me.swgratificacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.swgratificacion.Name = "swgratificacion"
        Me.swgratificacion.OffBackColor = System.Drawing.Color.LightCoral
        Me.swgratificacion.OffText = "NO"
        Me.swgratificacion.OnBackColor = System.Drawing.Color.LightGreen
        Me.swgratificacion.OnText = "SI"
        Me.swgratificacion.Size = New System.Drawing.Size(88, 27)
        Me.swgratificacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swgratificacion.TabIndex = 275
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(461, 46)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(103, 18)
        Me.Label8.TabIndex = 274
        Me.Label8.Text = "Indemnización"
        '
        'cmbsueldograf
        '
        Me.cmbsueldograf.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbsueldograf.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbsueldograf.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbsueldograf.ButtonDropDown.Visible = True
        Me.cmbsueldograf.Enabled = False
        Me.cmbsueldograf.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbsueldograf.Location = New System.Drawing.Point(903, 39)
        Me.cmbsueldograf.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbsueldograf.Name = "cmbsueldograf"
        Me.cmbsueldograf.Size = New System.Drawing.Size(105, 28)
        Me.cmbsueldograf.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbsueldograf.TabIndex = 273
        '
        'txtNumGratificacion
        '
        '
        '
        '
        Me.txtNumGratificacion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtNumGratificacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNumGratificacion.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtNumGratificacion.Enabled = False
        Me.txtNumGratificacion.Location = New System.Drawing.Point(729, 42)
        Me.txtNumGratificacion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNumGratificacion.MinValue = 0
        Me.txtNumGratificacion.Name = "txtNumGratificacion"
        Me.txtNumGratificacion.ShowUpDown = True
        Me.txtNumGratificacion.Size = New System.Drawing.Size(105, 22)
        Me.txtNumGratificacion.TabIndex = 272
        '
        'swantiguedad
        '
        '
        '
        '
        Me.swantiguedad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swantiguedad.Location = New System.Drawing.Point(569, 7)
        Me.swantiguedad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.swantiguedad.Name = "swantiguedad"
        Me.swantiguedad.OffBackColor = System.Drawing.Color.LightCoral
        Me.swantiguedad.OffText = "NO"
        Me.swantiguedad.OnBackColor = System.Drawing.Color.LightGreen
        Me.swantiguedad.OnText = "SI"
        Me.swantiguedad.Size = New System.Drawing.Size(88, 27)
        Me.swantiguedad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swantiguedad.TabIndex = 271
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(399, 11)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(142, 18)
        Me.Label7.TabIndex = 270
        Me.Label7.Text = "Prima de antiguedad"
        '
        'txtPerFija
        '
        '
        '
        '
        Me.txtPerFija.Border.Class = "TextBoxBorder"
        Me.txtPerFija.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPerFija.Enabled = False
        Me.txtPerFija.Location = New System.Drawing.Point(245, 76)
        Me.txtPerFija.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtPerFija.Name = "txtPerFija"
        Me.txtPerFija.PreventEnterBeep = True
        Me.txtPerFija.Size = New System.Drawing.Size(133, 22)
        Me.txtPerFija.TabIndex = 269
        Me.txtPerFija.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNetoFijo
        '
        '
        '
        '
        Me.txtNetoFijo.Border.Class = "TextBoxBorder"
        Me.txtNetoFijo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNetoFijo.Enabled = False
        Me.txtNetoFijo.Location = New System.Drawing.Point(245, 42)
        Me.txtNetoFijo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNetoFijo.Name = "txtNetoFijo"
        Me.txtNetoFijo.PreventEnterBeep = True
        Me.txtNetoFijo.Size = New System.Drawing.Size(133, 22)
        Me.txtNetoFijo.TabIndex = 268
        Me.txtNetoFijo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'swpercefija
        '
        '
        '
        '
        Me.swpercefija.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swpercefija.Location = New System.Drawing.Point(143, 75)
        Me.swpercefija.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.swpercefija.Name = "swpercefija"
        Me.swpercefija.OffBackColor = System.Drawing.Color.LightCoral
        Me.swpercefija.OffText = "NO"
        Me.swpercefija.OnBackColor = System.Drawing.Color.LightGreen
        Me.swpercefija.OnText = "SI"
        Me.swpercefija.Size = New System.Drawing.Size(88, 27)
        Me.swpercefija.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swpercefija.TabIndex = 267
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(12, 79)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 18)
        Me.Label12.TabIndex = 266
        Me.Label12.Text = "Percepción Fija"
        '
        'swnetofijo
        '
        '
        '
        '
        Me.swnetofijo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swnetofijo.Location = New System.Drawing.Point(143, 41)
        Me.swnetofijo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.swnetofijo.Name = "swnetofijo"
        Me.swnetofijo.OffBackColor = System.Drawing.Color.LightCoral
        Me.swnetofijo.OffText = "NO"
        Me.swnetofijo.OnBackColor = System.Drawing.Color.LightGreen
        Me.swnetofijo.OnText = "SI"
        Me.swnetofijo.Size = New System.Drawing.Size(88, 27)
        Me.swnetofijo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swnetofijo.TabIndex = 265
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(60, 46)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 18)
        Me.Label11.TabIndex = 264
        Me.Label11.Text = "Neto Fijo"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GroupPanel2)
        Me.Panel4.Location = New System.Drawing.Point(4, 89)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1019, 268)
        Me.Panel4.TabIndex = 165
        '
        'GroupPanel2
        '
        Me.GroupPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupPanel2.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel2.Controls.Add(Me.EliminaConce)
        Me.GroupPanel2.Controls.Add(Me.btnAgregaConcepto)
        Me.GroupPanel2.Controls.Add(Me.Label6)
        Me.GroupPanel2.Controls.Add(Me.cmbConceptos)
        Me.GroupPanel2.Controls.Add(Me.Panel5)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(4, 4)
        Me.GroupPanel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(1007, 252)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.GroupPanel2.Style.TextShadowColor = System.Drawing.Color.FromArgb(CType(CType(167, Byte), Integer), CType(CType(203, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.GroupPanel2.Style.TextShadowOffset = New System.Drawing.Point(1, 1)
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 2
        Me.GroupPanel2.Text = "Conceptos"
        '
        'EliminaConce
        '
        Me.EliminaConce.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.EliminaConce.CausesValidation = False
        Me.EliminaConce.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.EliminaConce.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EliminaConce.Location = New System.Drawing.Point(877, 2)
        Me.EliminaConce.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.EliminaConce.Name = "EliminaConce"
        Me.EliminaConce.Size = New System.Drawing.Size(104, 31)
        Me.EliminaConce.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.EliminaConce.TabIndex = 151
        Me.EliminaConce.Text = "Eliminar"
        '
        'btnAgregaConcepto
        '
        Me.btnAgregaConcepto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAgregaConcepto.CausesValidation = False
        Me.btnAgregaConcepto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAgregaConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregaConcepto.Location = New System.Drawing.Point(767, 2)
        Me.btnAgregaConcepto.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAgregaConcepto.Name = "btnAgregaConcepto"
        Me.btnAgregaConcepto.Size = New System.Drawing.Size(104, 31)
        Me.btnAgregaConcepto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAgregaConcepto.TabIndex = 150
        Me.btnAgregaConcepto.Text = "Agregar"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 10)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 18)
        Me.Label6.TabIndex = 149
        Me.Label6.Text = "Concepto"
        '
        'cmbConceptos
        '
        Me.cmbConceptos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbConceptos.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbConceptos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbConceptos.ButtonDropDown.Visible = True
        Me.cmbConceptos.GroupingMembers = "naturaleza"
        Me.cmbConceptos.GroupNodeStyle = Me.ElementStyle1
        Me.cmbConceptos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbConceptos.Location = New System.Drawing.Point(93, 5)
        Me.cmbConceptos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbConceptos.Name = "cmbConceptos"
        Me.cmbConceptos.Size = New System.Drawing.Size(665, 28)
        Me.cmbConceptos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbConceptos.TabIndex = 2
        '
        'ElementStyle1
        '
        Me.ElementStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ElementStyle1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ElementStyle1.BackColorGradientAngle = 90
        Me.ElementStyle1.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderBottomWidth = 1
        Me.ElementStyle1.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle1.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderLeftWidth = 1
        Me.ElementStyle1.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderRightWidth = 1
        Me.ElementStyle1.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderTopWidth = 1
        Me.ElementStyle1.CornerDiameter = 4
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Description = "Blue"
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.PaddingBottom = 1
        Me.ElementStyle1.PaddingLeft = 1
        Me.ElementStyle1.PaddingRight = 1
        Me.ElementStyle1.PaddingTop = 1
        Me.ElementStyle1.TextColor = System.Drawing.Color.Black
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.dgvConceptos)
        Me.Panel5.Location = New System.Drawing.Point(1, 41)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(980, 162)
        Me.Panel5.TabIndex = 1
        '
        'dgvConceptos
        '
        Me.dgvConceptos.AllowUserToAddRows = False
        Me.dgvConceptos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConceptos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConceptos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColConcepto, Me.ColDescripcion, Me.ColMonto, Me.ColFactor})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvConceptos.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvConceptos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConceptos.EnableHeadersVisualStyles = False
        Me.dgvConceptos.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvConceptos.Location = New System.Drawing.Point(0, 0)
        Me.dgvConceptos.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvConceptos.Name = "dgvConceptos"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConceptos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvConceptos.RowHeadersVisible = False
        Me.dgvConceptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvConceptos.Size = New System.Drawing.Size(980, 162)
        Me.dgvConceptos.TabIndex = 0
        '
        'ColConcepto
        '
        Me.ColConcepto.DataPropertyName = "Concepto"
        Me.ColConcepto.HeaderText = "Concepto"
        Me.ColConcepto.Name = "ColConcepto"
        Me.ColConcepto.ReadOnly = True
        Me.ColConcepto.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColConcepto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColDescripcion
        '
        Me.ColDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColDescripcion.DataPropertyName = "Descripcion"
        Me.ColDescripcion.HeaderText = "Descripcion"
        Me.ColDescripcion.Name = "ColDescripcion"
        Me.ColDescripcion.ReadOnly = True
        Me.ColDescripcion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColDescripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'ColMonto
        '
        Me.ColMonto.DataPropertyName = "Monto"
        Me.ColMonto.HeaderText = "Monto"
        Me.ColMonto.Name = "ColMonto"
        '
        'ColFactor
        '
        Me.ColFactor.DataPropertyName = "factor"
        Me.ColFactor.HeaderText = "Factor"
        Me.ColFactor.Name = "ColFactor"
        Me.ColFactor.Visible = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnCargaDef)
        Me.Panel3.Controls.Add(Me.swComplemento)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.BajaFiniquito)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Location = New System.Drawing.Point(4, 41)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1019, 44)
        Me.Panel3.TabIndex = 163
        '
        'btnCargaDef
        '
        Me.btnCargaDef.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCargaDef.CausesValidation = False
        Me.btnCargaDef.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCargaDef.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCargaDef.Location = New System.Drawing.Point(752, 7)
        Me.btnCargaDef.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCargaDef.Name = "btnCargaDef"
        Me.btnCargaDef.Size = New System.Drawing.Size(257, 31)
        Me.btnCargaDef.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCargaDef.TabIndex = 152
        Me.btnCargaDef.Text = "Cargar Conceptos Principales"
        '
        'swComplemento
        '
        '
        '
        '
        Me.swComplemento.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swComplemento.Location = New System.Drawing.Point(576, 7)
        Me.swComplemento.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.swComplemento.Name = "swComplemento"
        Me.swComplemento.OffBackColor = System.Drawing.Color.LightCoral
        Me.swComplemento.OffText = "NO"
        Me.swComplemento.OnBackColor = System.Drawing.Color.LightGreen
        Me.swComplemento.OnText = "SI"
        Me.swComplemento.Size = New System.Drawing.Size(88, 27)
        Me.swComplemento.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swComplemento.TabIndex = 268
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(393, 12)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(160, 18)
        Me.Label14.TabIndex = 267
        Me.Label14.Text = "Generar Complemento"
        '
        'BajaFiniquito
        '
        '
        '
        '
        Me.BajaFiniquito.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.BajaFiniquito.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BajaFiniquito.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.BajaFiniquito.ButtonDropDown.Visible = True
        Me.BajaFiniquito.IsPopupCalendarOpen = False
        Me.BajaFiniquito.Location = New System.Drawing.Point(147, 10)
        Me.BajaFiniquito.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        '
        '
        '
        Me.BajaFiniquito.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.BajaFiniquito.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BajaFiniquito.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.BajaFiniquito.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.BajaFiniquito.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.BajaFiniquito.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.BajaFiniquito.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.BajaFiniquito.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.BajaFiniquito.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.BajaFiniquito.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.BajaFiniquito.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BajaFiniquito.MonthCalendar.DisplayMonth = New Date(2019, 4, 1, 0, 0, 0, 0)
        Me.BajaFiniquito.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.BajaFiniquito.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.BajaFiniquito.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.BajaFiniquito.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.BajaFiniquito.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.BajaFiniquito.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.BajaFiniquito.MonthCalendar.TodayButtonVisible = True
        Me.BajaFiniquito.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.BajaFiniquito.Name = "BajaFiniquito"
        Me.BajaFiniquito.Size = New System.Drawing.Size(145, 22)
        Me.BajaFiniquito.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BajaFiniquito.TabIndex = 165
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 18)
        Me.Label2.TabIndex = 164
        Me.Label2.Text = "Fecha Finiquito"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.Cancel16
        Me.btnCancelar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCancelar.Location = New System.Drawing.Point(831, 612)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(105, 31)
        Me.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancelar.TabIndex = 165
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnCalcular
        '
        Me.btnCalcular.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCalcular.CausesValidation = False
        Me.btnCalcular.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCalcular.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCalcular.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnCalcular.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCalcular.Location = New System.Drawing.Point(717, 612)
        Me.btnCalcular.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(104, 31)
        Me.btnCalcular.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCalcular.TabIndex = 164
        Me.btnCalcular.Text = "Calcular"
        '
        'txtReloj
        '
        Me.txtReloj.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.Enabled = False
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.ForeColor = System.Drawing.Color.Black
        Me.txtReloj.Location = New System.Drawing.Point(11, 26)
        Me.txtReloj.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.ReadOnly = True
        Me.txtReloj.Size = New System.Drawing.Size(121, 24)
        Me.txtReloj.TabIndex = 166
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(7, 4)
        Me.Label18.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(42, 18)
        Me.Label18.TabIndex = 167
        Me.Label18.Text = "Reloj"
        '
        'btnSalir
        '
        Me.btnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSalir.CausesValidation = False
        Me.btnSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnSalir.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnSalir.Location = New System.Drawing.Point(944, 612)
        Me.btnSalir.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(104, 31)
        Me.btnSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSalir.TabIndex = 168
        Me.btnSalir.Text = "Salir"
        '
        'pnlEmp
        '
        Me.pnlEmp.Controls.Add(Me.AntigEmp)
        Me.pnlEmp.Controls.Add(Me.Label10)
        Me.pnlEmp.Controls.Add(Me.Label18)
        Me.pnlEmp.Controls.Add(Me.AltaEmp)
        Me.pnlEmp.Controls.Add(Me.txtReloj)
        Me.pnlEmp.Controls.Add(Me.Label13)
        Me.pnlEmp.Controls.Add(Me.txtNombre)
        Me.pnlEmp.Controls.Add(Me.Label5)
        Me.pnlEmp.Location = New System.Drawing.Point(16, 69)
        Me.pnlEmp.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlEmp.Name = "pnlEmp"
        Me.pnlEmp.Size = New System.Drawing.Size(1032, 55)
        Me.pnlEmp.TabIndex = 169
        '
        'frmAjusteFiniquito
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1063, 654)
        Me.Controls.Add(Me.pnlEmp)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnCalcular)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAjusteFiniquito"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CAPTURA FINIQUITO"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.AntigEmp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AltaEmp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        CType(Me.txtNumGratificacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel2.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.dgvConceptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.BajaFiniquito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEmp.ResumeLayout(False)
        Me.pnlEmp.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtFolio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents AntigEmp As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Private WithEvents AltaEmp As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmbPeriodos As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents lblTipoNomProcesada As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BajaFiniquito As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btnAgregaConcepto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbConceptos As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents dgvConceptos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents EliminaConce As DevComponents.DotNetBar.ButtonX
    Friend WithEvents swComplemento As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents txtPerFija As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNetoFijo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents swpercefija As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents swnetofijo As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents swantiguedad As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents swgratificacion As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbsueldograf As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents txtNumGratificacion As DevComponents.Editors.IntegerInput
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbsueldoprima As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents swdiasano As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cmbsueldodias As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents btnCargaDef As DevComponents.DotNetBar.ButtonX
    Friend WithEvents swdespensa As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCalcular As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btnSalir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle2 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents pnlEmp As System.Windows.Forms.Panel
    Friend WithEvents ColConcepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMonto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColFactor As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
