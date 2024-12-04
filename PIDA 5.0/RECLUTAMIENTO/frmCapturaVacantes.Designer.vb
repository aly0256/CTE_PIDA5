<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCapturaVacantes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapturaVacantes))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.tabcatalogo = New DevComponents.DotNetBar.SuperTabControl()
        Me.pnlCatalogo = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.cmbCCostos = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.cmbSupervisor = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNumRequisicion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cmbPuesto = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbDepto = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.cmbPlanta = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.txtVacantes = New DevComponents.Editors.IntegerInput()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.swActivo = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtVacante = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TabInformación = New DevComponents.DotNetBar.SuperTabItem()
        Me.PnlDatos = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgCalogVacantes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ColCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColVacante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSupervisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPlanta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTurno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CCostos = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColVencimiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColActiva = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColImagen = New System.Windows.Forms.DataGridViewImageColumn()
        Me.TabLista = New DevComponents.DotNetBar.SuperTabItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlCentrarControles = New System.Windows.Forms.Panel()
        Me.btnPrimero = New DevComponents.DotNetBar.ButtonX()
        Me.btnAnterior = New DevComponents.DotNetBar.ButtonX()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.btnSiguiente = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnUltimo = New DevComponents.DotNetBar.ButtonX()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.dlgArchivo = New System.Windows.Forms.OpenFileDialog()
        CType(Me.tabcatalogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabcatalogo.SuspendLayout()
        Me.pnlCatalogo.SuspendLayout()
        CType(Me.txtVacantes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDatos.SuspendLayout()
        CType(Me.dgCalogVacantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.pnlCentrarControles.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(53, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(295, 40)
        Me.ReflectionLabel1.TabIndex = 129
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>ALTAS VACANTES</b></font>"
        '
        'tabcatalogo
        '
        Me.tabcatalogo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        '
        '
        '
        Me.tabcatalogo.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.tabcatalogo.ControlBox.MenuBox.Name = ""
        Me.tabcatalogo.ControlBox.MenuBox.Visible = False
        Me.tabcatalogo.ControlBox.Name = ""
        Me.tabcatalogo.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabcatalogo.ControlBox.MenuBox, Me.tabcatalogo.ControlBox.CloseBox})
        Me.tabcatalogo.Controls.Add(Me.pnlCatalogo)
        Me.tabcatalogo.Controls.Add(Me.PnlDatos)
        Me.tabcatalogo.Location = New System.Drawing.Point(0, 58)
        Me.tabcatalogo.Name = "tabcatalogo"
        Me.tabcatalogo.ReorderTabsEnabled = True
        Me.tabcatalogo.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabcatalogo.SelectedTabIndex = 0
        Me.tabcatalogo.Size = New System.Drawing.Size(850, 262)
        Me.tabcatalogo.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.tabcatalogo.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabcatalogo.TabIndex = 132
        Me.tabcatalogo.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit
        Me.tabcatalogo.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.TabInformación, Me.TabLista})
        Me.tabcatalogo.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.tabcatalogo.Text = "SuperTabControl2"
        '
        'pnlCatalogo
        '
        Me.pnlCatalogo.Controls.Add(Me.cmbCCostos)
        Me.pnlCatalogo.Controls.Add(Me.cmbSupervisor)
        Me.pnlCatalogo.Controls.Add(Me.Label11)
        Me.pnlCatalogo.Controls.Add(Me.txtNumRequisicion)
        Me.pnlCatalogo.Controls.Add(Me.cmbPuesto)
        Me.pnlCatalogo.Controls.Add(Me.Label10)
        Me.pnlCatalogo.Controls.Add(Me.Label8)
        Me.pnlCatalogo.Controls.Add(Me.cmbDepto)
        Me.pnlCatalogo.Controls.Add(Me.cmbPlanta)
        Me.pnlCatalogo.Controls.Add(Me.txtVacantes)
        Me.pnlCatalogo.Controls.Add(Me.Label9)
        Me.pnlCatalogo.Controls.Add(Me.Label7)
        Me.pnlCatalogo.Controls.Add(Me.cmbFecha)
        Me.pnlCatalogo.Controls.Add(Me.swActivo)
        Me.pnlCatalogo.Controls.Add(Me.Label18)
        Me.pnlCatalogo.Controls.Add(Me.Label5)
        Me.pnlCatalogo.Controls.Add(Me.Label4)
        Me.pnlCatalogo.Controls.Add(Me.Label3)
        Me.pnlCatalogo.Controls.Add(Me.Label2)
        Me.pnlCatalogo.Controls.Add(Me.txtVacante)
        Me.pnlCatalogo.Controls.Add(Me.Label1)
        Me.pnlCatalogo.Controls.Add(Me.txtCodigo)
        Me.pnlCatalogo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCatalogo.Location = New System.Drawing.Point(0, 0)
        Me.pnlCatalogo.Name = "pnlCatalogo"
        Me.pnlCatalogo.Size = New System.Drawing.Size(779, 262)
        Me.pnlCatalogo.TabIndex = 1
        Me.pnlCatalogo.TabItem = Me.TabInformación
        '
        'cmbCCostos
        '
        Me.cmbCCostos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbCCostos.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbCCostos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbCCostos.ButtonCustom.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.cmbCCostos.ButtonCustom.Visible = True
        Me.cmbCCostos.ButtonDropDown.Visible = True
        Me.cmbCCostos.DisplayMembers = "centro_costos,nombre"
        Me.cmbCCostos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbCCostos.Location = New System.Drawing.Point(109, 153)
        Me.cmbCCostos.Name = "cmbCCostos"
        Me.cmbCCostos.Size = New System.Drawing.Size(360, 22)
        Me.cmbCCostos.TabIndex = 190
        Me.cmbCCostos.ValueMember = "centro_costos"
        '
        'cmbSupervisor
        '
        Me.cmbSupervisor.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbSupervisor.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbSupervisor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbSupervisor.ButtonCustom.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.cmbSupervisor.ButtonCustom.Visible = True
        Me.cmbSupervisor.ButtonDropDown.Visible = True
        Me.cmbSupervisor.DisplayMembers = "cod_comp"
        Me.cmbSupervisor.GridRowLines = True
        Me.cmbSupervisor.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbSupervisor.Location = New System.Drawing.Point(109, 71)
        Me.cmbSupervisor.Name = "cmbSupervisor"
        Me.cmbSupervisor.Size = New System.Drawing.Size(360, 20)
        Me.cmbSupervisor.TabIndex = 184
        Me.cmbSupervisor.ValueMember = "cod_comp"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(16, 214)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 13)
        Me.Label11.TabIndex = 159
        Me.Label11.Text = "Num Requisición"
        '
        'txtNumRequisicion
        '
        '
        '
        '
        Me.txtNumRequisicion.Border.Class = "TextBoxBorder"
        Me.txtNumRequisicion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNumRequisicion.Location = New System.Drawing.Point(109, 211)
        Me.txtNumRequisicion.MaxLength = 10
        Me.txtNumRequisicion.Name = "txtNumRequisicion"
        Me.txtNumRequisicion.PreventEnterBeep = True
        Me.txtNumRequisicion.Size = New System.Drawing.Size(360, 20)
        Me.txtNumRequisicion.TabIndex = 158
        '
        'cmbPuesto
        '
        Me.cmbPuesto.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPuesto.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPuesto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPuesto.ButtonCustom.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.cmbPuesto.ButtonCustom.Visible = True
        Me.cmbPuesto.ButtonDropDown.Visible = True
        Me.cmbPuesto.DisplayMembers = "cod_puesto,nombre"
        Me.cmbPuesto.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPuesto.Location = New System.Drawing.Point(109, 181)
        Me.cmbPuesto.Name = "cmbPuesto"
        Me.cmbPuesto.Size = New System.Drawing.Size(360, 22)
        Me.cmbPuesto.TabIndex = 157
        Me.cmbPuesto.ValueMember = "cod_puesto"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(63, 190)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 156
        Me.Label10.Text = "Puesto"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(51, 156)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 154
        Me.Label8.Text = "C. Costos"
        '
        'cmbDepto
        '
        Me.cmbDepto.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbDepto.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbDepto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbDepto.ButtonCustom.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.cmbDepto.ButtonCustom.Visible = True
        Me.cmbDepto.ButtonDropDown.Visible = True
        Me.cmbDepto.DisplayMembers = "cod_depto,nombre"
        Me.cmbDepto.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbDepto.Location = New System.Drawing.Point(109, 126)
        Me.cmbDepto.Name = "cmbDepto"
        Me.cmbDepto.Size = New System.Drawing.Size(360, 22)
        Me.cmbDepto.TabIndex = 151
        Me.cmbDepto.ValueMember = "cod_depto"
        '
        'cmbPlanta
        '
        Me.cmbPlanta.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPlanta.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPlanta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPlanta.ButtonDropDown.Visible = True
        Me.cmbPlanta.DisplayMembers = "cod_planta,nombre"
        Me.cmbPlanta.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPlanta.Location = New System.Drawing.Point(109, 97)
        Me.cmbPlanta.Name = "cmbPlanta"
        Me.cmbPlanta.Size = New System.Drawing.Size(360, 22)
        Me.cmbPlanta.TabIndex = 149
        Me.cmbPlanta.ValueMember = "COD_PLANTA"
        '
        'txtVacantes
        '
        '
        '
        '
        Me.txtVacantes.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtVacantes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtVacantes.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtVacantes.Location = New System.Drawing.Point(623, 104)
        Me.txtVacantes.MinValue = 0
        Me.txtVacantes.Name = "txtVacantes"
        Me.txtVacantes.ShowUpDown = True
        Me.txtVacantes.Size = New System.Drawing.Size(96, 20)
        Me.txtVacantes.TabIndex = 143
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(527, 104)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 15)
        Me.Label9.TabIndex = 142
        Me.Label9.Text = "Num. Vacantes"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(490, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(127, 15)
        Me.Label7.TabIndex = 141
        Me.Label7.Text = "Fecha de vencimiento"
        '
        'cmbFecha
        '
        '
        '
        '
        Me.cmbFecha.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.cmbFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbFecha.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.cmbFecha.ButtonDropDown.Visible = True
        Me.cmbFecha.IsPopupCalendarOpen = False
        Me.cmbFecha.Location = New System.Drawing.Point(623, 128)
        '
        '
        '
        Me.cmbFecha.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.cmbFecha.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbFecha.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.cmbFecha.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.cmbFecha.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.cmbFecha.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.cmbFecha.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.cmbFecha.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.cmbFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.cmbFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.cmbFecha.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbFecha.MonthCalendar.DisplayMonth = New Date(2017, 3, 1, 0, 0, 0, 0)
        Me.cmbFecha.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.cmbFecha.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.cmbFecha.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.cmbFecha.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.cmbFecha.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.cmbFecha.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbFecha.MonthCalendar.TodayButtonVisible = True
        Me.cmbFecha.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.cmbFecha.Name = "cmbFecha"
        Me.cmbFecha.Size = New System.Drawing.Size(136, 20)
        Me.cmbFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbFecha.TabIndex = 140
        '
        'swActivo
        '
        '
        '
        '
        Me.swActivo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swActivo.Location = New System.Drawing.Point(623, 154)
        Me.swActivo.Name = "swActivo"
        Me.swActivo.OffBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.swActivo.OffText = "INACTIVO"
        Me.swActivo.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.swActivo.OnText = "ACTIVO"
        Me.swActivo.Size = New System.Drawing.Size(96, 25)
        Me.swActivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swActivo.TabIndex = 139
        Me.swActivo.ValueFalse = "0"
        Me.swActivo.ValueObject = "0"
        Me.swActivo.ValueTrue = "1"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.SystemColors.Window
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(579, 154)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(38, 15)
        Me.Label18.TabIndex = 138
        Me.Label18.Text = "Activo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(66, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Planta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(29, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Departamento"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(46, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Supervisor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(56, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Vacante"
        '
        'txtVacante
        '
        '
        '
        '
        Me.txtVacante.Border.Class = "TextBoxBorder"
        Me.txtVacante.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtVacante.Location = New System.Drawing.Point(109, 45)
        Me.txtVacante.Name = "txtVacante"
        Me.txtVacante.PreventEnterBeep = True
        Me.txtVacante.Size = New System.Drawing.Size(360, 20)
        Me.txtVacante.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(63, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Código"
        '
        'txtCodigo
        '
        '
        '
        '
        Me.txtCodigo.Border.Class = "TextBoxBorder"
        Me.txtCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodigo.Location = New System.Drawing.Point(109, 17)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.PreventEnterBeep = True
        Me.txtCodigo.Size = New System.Drawing.Size(71, 20)
        Me.txtCodigo.TabIndex = 8
        '
        'TabInformación
        '
        Me.TabInformación.AttachedControl = Me.pnlCatalogo
        Me.TabInformación.GlobalItem = False
        Me.TabInformación.Name = "TabInformación"
        Me.TabInformación.Text = "Individual"
        '
        'PnlDatos
        '
        Me.PnlDatos.Controls.Add(Me.dgCalogVacantes)
        Me.PnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.PnlDatos.Name = "PnlDatos"
        Me.PnlDatos.Size = New System.Drawing.Size(781, 325)
        Me.PnlDatos.TabIndex = 0
        Me.PnlDatos.TabItem = Me.TabLista
        '
        'dgCalogVacantes
        '
        Me.dgCalogVacantes.AllowUserToAddRows = False
        Me.dgCalogVacantes.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCalogVacantes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgCalogVacantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCalogVacantes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColCodigo, Me.ColVacante, Me.ColSupervisor, Me.ColPlanta, Me.ColDepto, Me.ColTurno, Me.CCostos, Me.ColVencimiento, Me.ColActiva, Me.ColImagen})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCalogVacantes.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgCalogVacantes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgCalogVacantes.EnableHeadersVisualStyles = False
        Me.dgCalogVacantes.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgCalogVacantes.Location = New System.Drawing.Point(0, 0)
        Me.dgCalogVacantes.Name = "dgCalogVacantes"
        Me.dgCalogVacantes.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCalogVacantes.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgCalogVacantes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgCalogVacantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCalogVacantes.Size = New System.Drawing.Size(781, 325)
        Me.dgCalogVacantes.TabIndex = 0
        '
        'ColCodigo
        '
        Me.ColCodigo.DataPropertyName = "Codigo"
        Me.ColCodigo.HeaderText = "Codigo"
        Me.ColCodigo.Name = "ColCodigo"
        Me.ColCodigo.ReadOnly = True
        '
        'ColVacante
        '
        Me.ColVacante.DataPropertyName = "Vacante"
        Me.ColVacante.HeaderText = "Vacante"
        Me.ColVacante.Name = "ColVacante"
        Me.ColVacante.ReadOnly = True
        '
        'ColSupervisor
        '
        Me.ColSupervisor.DataPropertyName = "Supervisor"
        Me.ColSupervisor.HeaderText = "Supervisor"
        Me.ColSupervisor.Name = "ColSupervisor"
        Me.ColSupervisor.ReadOnly = True
        '
        'ColPlanta
        '
        Me.ColPlanta.DataPropertyName = "Planta"
        Me.ColPlanta.HeaderText = "Planta"
        Me.ColPlanta.Name = "ColPlanta"
        Me.ColPlanta.ReadOnly = True
        '
        'ColDepto
        '
        Me.ColDepto.DataPropertyName = "Depto"
        Me.ColDepto.HeaderText = "Depto"
        Me.ColDepto.Name = "ColDepto"
        Me.ColDepto.ReadOnly = True
        '
        'ColTurno
        '
        Me.ColTurno.DataPropertyName = "Turno"
        Me.ColTurno.HeaderText = "Turno"
        Me.ColTurno.Name = "ColTurno"
        Me.ColTurno.ReadOnly = True
        '
        'CCostos
        '
        Me.CCostos.DataPropertyName = "ccostos"
        Me.CCostos.HeaderText = "CCostos"
        Me.CCostos.Name = "CCostos"
        Me.CCostos.ReadOnly = True
        '
        'ColVencimiento
        '
        Me.ColVencimiento.DataPropertyName = "Vencimiento"
        Me.ColVencimiento.HeaderText = "Vencimiento"
        Me.ColVencimiento.Name = "ColVencimiento"
        Me.ColVencimiento.ReadOnly = True
        '
        'ColActiva
        '
        Me.ColActiva.DataPropertyName = "Activa"
        Me.ColActiva.HeaderText = "Activa"
        Me.ColActiva.Name = "ColActiva"
        Me.ColActiva.ReadOnly = True
        Me.ColActiva.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColActiva.Visible = False
        '
        'ColImagen
        '
        Me.ColImagen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.ColImagen.DataPropertyName = "imagen"
        Me.ColImagen.HeaderText = "Disponible"
        Me.ColImagen.Name = "ColImagen"
        Me.ColImagen.ReadOnly = True
        Me.ColImagen.Width = 62
        '
        'TabLista
        '
        Me.TabLista.AttachedControl = Me.PnlDatos
        Me.TabLista.GlobalItem = False
        Me.TabLista.Name = "TabLista"
        Me.TabLista.Text = "Lista"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pnlCentrarControles)
        Me.Panel2.Location = New System.Drawing.Point(0, 322)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(850, 42)
        Me.Panel2.TabIndex = 154
        '
        'pnlCentrarControles
        '
        Me.pnlCentrarControles.Controls.Add(Me.btnPrimero)
        Me.pnlCentrarControles.Controls.Add(Me.btnAnterior)
        Me.pnlCentrarControles.Controls.Add(Me.btnBuscar)
        Me.pnlCentrarControles.Controls.Add(Me.btnSiguiente)
        Me.pnlCentrarControles.Controls.Add(Me.btnReporte)
        Me.pnlCentrarControles.Controls.Add(Me.btnEditar)
        Me.pnlCentrarControles.Controls.Add(Me.btnNuevo)
        Me.pnlCentrarControles.Controls.Add(Me.btnCerrar)
        Me.pnlCentrarControles.Controls.Add(Me.btnUltimo)
        Me.pnlCentrarControles.Controls.Add(Me.btnBorrar)
        Me.pnlCentrarControles.Location = New System.Drawing.Point(6, 5)
        Me.pnlCentrarControles.Name = "pnlCentrarControles"
        Me.pnlCentrarControles.Size = New System.Drawing.Size(815, 32)
        Me.pnlCentrarControles.TabIndex = 0
        '
        'btnPrimero
        '
        Me.btnPrimero.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrimero.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrimero.Image = Global.PIDA.My.Resources.Resources.First16
        Me.btnPrimero.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnPrimero.Location = New System.Drawing.Point(3, 3)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(78, 25)
        Me.btnPrimero.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrimero.TabIndex = 0
        Me.btnPrimero.Text = "Inicio"
        '
        'btnAnterior
        '
        Me.btnAnterior.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAnterior.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAnterior.Image = Global.PIDA.My.Resources.Resources.Prev16
        Me.btnAnterior.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnAnterior.Location = New System.Drawing.Point(84, 3)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(78, 25)
        Me.btnAnterior.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAnterior.TabIndex = 1
        Me.btnAnterior.Text = "Anterior"
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBuscar.Location = New System.Drawing.Point(327, 3)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(78, 25)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Tooltip = "Buscar"
        '
        'btnSiguiente
        '
        Me.btnSiguiente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSiguiente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSiguiente.Image = Global.PIDA.My.Resources.Resources.Next16
        Me.btnSiguiente.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnSiguiente.Location = New System.Drawing.Point(165, 3)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(78, 25)
        Me.btnSiguiente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSiguiente.TabIndex = 2
        Me.btnSiguiente.Text = "Siguiente"
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnReporte.Location = New System.Drawing.Point(408, 3)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 5
        Me.btnReporte.Text = "Reporte"
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = Global.PIDA.My.Resources.Resources.Edit
        Me.btnEditar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnEditar.Location = New System.Drawing.Point(567, 3)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(78, 25)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 6
        Me.btnEditar.Text = "Editar"
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.NewRecord
        Me.btnNuevo.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnNuevo.Location = New System.Drawing.Point(489, 3)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 25)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 6
        Me.btnNuevo.Text = "Agregar"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(732, 3)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 8
        Me.btnCerrar.Text = "Salir"
        '
        'btnUltimo
        '
        Me.btnUltimo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnUltimo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnUltimo.Image = Global.PIDA.My.Resources.Resources.Last16
        Me.btnUltimo.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnUltimo.Location = New System.Drawing.Point(246, 3)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(78, 25)
        Me.btnUltimo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnUltimo.TabIndex = 3
        Me.btnUltimo.Text = "Final"
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Enabled = False
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = Global.PIDA.My.Resources.Resources.DeleteRec
        Me.btnBorrar.Location = New System.Drawing.Point(651, 3)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(78, 25)
        Me.btnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBorrar.TabIndex = 7
        Me.btnBorrar.Text = "Borrar"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.portfolio32
        Me.PictureBox1.Location = New System.Drawing.Point(14, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(27, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 130
        Me.PictureBox1.TabStop = False
        '
        'dlgArchivo
        '
        Me.dlgArchivo.FileName = "OpenFileDialog1"
        '
        'frmCapturaVacantes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 377)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.tabcatalogo)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCapturaVacantes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Altas Vacantes"
        CType(Me.tabcatalogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabcatalogo.ResumeLayout(False)
        Me.pnlCatalogo.ResumeLayout(False)
        Me.pnlCatalogo.PerformLayout()
        CType(Me.txtVacantes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDatos.ResumeLayout(False)
        CType(Me.dgCalogVacantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.pnlCentrarControles.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents tabcatalogo As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents pnlCatalogo As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents TabInformación As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents PnlDatos As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents TabLista As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtVacante As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmbDepto As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cmbPlanta As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents txtVacantes As DevComponents.Editors.IntegerInput
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents swActivo As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents dgCalogVacantes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlCentrarControles As System.Windows.Forms.Panel
    Friend WithEvents btnPrimero As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAnterior As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSiguiente As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnUltimo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ColCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColVacante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSupervisor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPlanta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTurno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CCostos As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColVencimiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColActiva As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColImagen As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents cmbPuesto As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNumRequisicion As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents cmbSupervisor As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents dlgArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmbCCostos As DevComponents.DotNetBar.Controls.ComboTree
End Class
