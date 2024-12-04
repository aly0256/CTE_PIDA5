<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaPersonal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaPersonal))
        Me.cmbCCostos = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.cmbArea = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.cmbCia = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.cmbPlanta = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.cmbSuper = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.cmbLinea = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.cmbHorario = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.cmbClase = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.cmbPuesto = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.cmbTipo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.cmbTurno = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.cmbDepto = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblDepto = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.lblEstado = New DevComponents.DotNetBar.LabelX()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtApaterno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtAmaterno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.gbReloj = New System.Windows.Forms.GroupBox()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picFoto = New System.Windows.Forms.PictureBox()
        Me.lblBaja = New System.Windows.Forms.Label()
        Me.txtAlta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.txtBaja = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSexo = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.chkChecaTarjeta = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.txtCurp = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtGafete = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtRFC = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtIMSSdv = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtIMSS = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlCentrarControles = New System.Windows.Forms.Panel()
        Me.btnFirst = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrev = New DevComponents.DotNetBar.ButtonX()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.btnNext = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnLast = New DevComponents.DotNetBar.ButtonX()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.Panel3.SuspendLayout()
        Me.gbReloj.SuspendLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAlta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlCentrarControles.SuspendLayout()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbCCostos
        '
        Me.cmbCCostos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbCCostos.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbCCostos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbCCostos.ButtonDropDown.Visible = True
        Me.cmbCCostos.DisplayMembers = "centro_costos,nombre"
        Me.cmbCCostos.Enabled = False
        Me.cmbCCostos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCCostos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbCCostos.Location = New System.Drawing.Point(124, 111)
        Me.cmbCCostos.Name = "cmbCCostos"
        Me.cmbCCostos.Size = New System.Drawing.Size(285, 20)
        Me.cmbCCostos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbCCostos.TabIndex = 125
        Me.cmbCCostos.ValueMember = "centro_costos"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.BackColor = System.Drawing.SystemColors.Window
        Me.Label58.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label58.Location = New System.Drawing.Point(12, 116)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(100, 15)
        Me.Label58.TabIndex = 126
        Me.Label58.Text = "Centro de Costos"
        '
        'cmbArea
        '
        Me.cmbArea.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbArea.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbArea.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbArea.ButtonDropDown.Visible = True
        Me.cmbArea.DisplayMembers = "cod_area,nombre"
        Me.cmbArea.Enabled = False
        Me.cmbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArea.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbArea.Location = New System.Drawing.Point(124, 59)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(285, 20)
        Me.cmbArea.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbArea.TabIndex = 122
        Me.cmbArea.ValueMember = "cod_area"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.BackColor = System.Drawing.SystemColors.Window
        Me.Label54.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(12, 64)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(32, 15)
        Me.Label54.TabIndex = 124
        Me.Label54.Text = "Area"
        '
        'cmbCia
        '
        Me.cmbCia.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbCia.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbCia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbCia.ButtonDropDown.Visible = True
        Me.cmbCia.DisplayMembers = "cod_comp,nombre"
        Me.cmbCia.Enabled = False
        Me.cmbCia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCia.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbCia.Location = New System.Drawing.Point(124, 7)
        Me.cmbCia.Name = "cmbCia"
        Me.cmbCia.Size = New System.Drawing.Size(285, 20)
        Me.cmbCia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbCia.TabIndex = 93
        Me.cmbCia.ValueMember = "cod_comp"
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
        Me.cmbPlanta.Enabled = False
        Me.cmbPlanta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPlanta.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPlanta.Location = New System.Drawing.Point(124, 33)
        Me.cmbPlanta.Name = "cmbPlanta"
        Me.cmbPlanta.Size = New System.Drawing.Size(285, 20)
        Me.cmbPlanta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPlanta.TabIndex = 94
        Me.cmbPlanta.ValueMember = "cod_planta"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.BackColor = System.Drawing.SystemColors.Window
        Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.Location = New System.Drawing.Point(12, 38)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(42, 15)
        Me.Label61.TabIndex = 121
        Me.Label61.Text = "Planta"
        '
        'cmbSuper
        '
        Me.cmbSuper.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbSuper.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbSuper.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbSuper.ButtonDropDown.Visible = True
        Me.cmbSuper.DisplayMembers = "cod_super,nombre"
        Me.cmbSuper.Enabled = False
        Me.cmbSuper.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSuper.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbSuper.Location = New System.Drawing.Point(124, 163)
        Me.cmbSuper.Name = "cmbSuper"
        Me.cmbSuper.Size = New System.Drawing.Size(285, 22)
        Me.cmbSuper.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbSuper.TabIndex = 97
        Me.cmbSuper.ValueMember = "cod_super"
        '
        'cmbLinea
        '
        Me.cmbLinea.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbLinea.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbLinea.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbLinea.ButtonDropDown.Visible = True
        Me.cmbLinea.DisplayMembers = "cod_linea,nombre"
        Me.cmbLinea.Enabled = False
        Me.cmbLinea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbLinea.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbLinea.Location = New System.Drawing.Point(124, 137)
        Me.cmbLinea.Name = "cmbLinea"
        Me.cmbLinea.Size = New System.Drawing.Size(285, 20)
        Me.cmbLinea.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbLinea.TabIndex = 96
        Me.cmbLinea.ValueMember = "cod_linea"
        '
        'cmbHorario
        '
        Me.cmbHorario.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbHorario.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbHorario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbHorario.ButtonDropDown.Visible = True
        Me.cmbHorario.DisplayMembers = "cod_hora,nombre"
        Me.cmbHorario.Enabled = False
        Me.cmbHorario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbHorario.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbHorario.Location = New System.Drawing.Point(124, 295)
        Me.cmbHorario.Name = "cmbHorario"
        Me.cmbHorario.Size = New System.Drawing.Size(285, 20)
        Me.cmbHorario.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbHorario.TabIndex = 102
        Me.cmbHorario.ValueMember = "cod_hora"
        '
        'cmbClase
        '
        Me.cmbClase.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbClase.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbClase.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbClase.ButtonDropDown.Visible = True
        Me.cmbClase.DisplayMembers = "Cod_depto,nombre"
        Me.cmbClase.Enabled = False
        Me.cmbClase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbClase.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbClase.Location = New System.Drawing.Point(124, 243)
        Me.cmbClase.Name = "cmbClase"
        Me.cmbClase.Size = New System.Drawing.Size(285, 20)
        Me.cmbClase.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbClase.TabIndex = 100
        Me.cmbClase.ValueMember = "cod_clase"
        '
        'cmbPuesto
        '
        Me.cmbPuesto.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPuesto.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPuesto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPuesto.ButtonDropDown.Visible = True
        Me.cmbPuesto.DisplayMembers = "cod_puesto,nombre"
        Me.cmbPuesto.Enabled = False
        Me.cmbPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPuesto.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPuesto.Location = New System.Drawing.Point(124, 191)
        Me.cmbPuesto.Name = "cmbPuesto"
        Me.cmbPuesto.Size = New System.Drawing.Size(285, 20)
        Me.cmbPuesto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPuesto.TabIndex = 98
        Me.cmbPuesto.ValueMember = "cod_puesto"
        '
        'cmbTipo
        '
        Me.cmbTipo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbTipo.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbTipo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbTipo.ButtonDropDown.Visible = True
        Me.cmbTipo.DisplayMembers = "cod_tipo,nombre"
        Me.cmbTipo.Enabled = False
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbTipo.Location = New System.Drawing.Point(124, 217)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(285, 20)
        Me.cmbTipo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipo.TabIndex = 99
        Me.cmbTipo.ValueMember = "cod_tipo"
        '
        'cmbTurno
        '
        Me.cmbTurno.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbTurno.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbTurno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbTurno.ButtonDropDown.Visible = True
        Me.cmbTurno.DisplayMembers = "cod_turno,nombre"
        Me.cmbTurno.Enabled = False
        Me.cmbTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTurno.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbTurno.Location = New System.Drawing.Point(124, 269)
        Me.cmbTurno.Name = "cmbTurno"
        Me.cmbTurno.Size = New System.Drawing.Size(285, 20)
        Me.cmbTurno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTurno.TabIndex = 101
        Me.cmbTurno.ValueMember = "cod_turno"
        '
        'cmbDepto
        '
        Me.cmbDepto.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbDepto.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbDepto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbDepto.ButtonDropDown.Visible = True
        Me.cmbDepto.DisplayMembers = "Cod_depto,nombre"
        Me.cmbDepto.Enabled = False
        Me.cmbDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDepto.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbDepto.Location = New System.Drawing.Point(124, 85)
        Me.cmbDepto.Name = "cmbDepto"
        Me.cmbDepto.Size = New System.Drawing.Size(285, 20)
        Me.cmbDepto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbDepto.TabIndex = 95
        Me.cmbDepto.ValueMember = "Cod_depto"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.SystemColors.Window
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(12, 142)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(38, 15)
        Me.Label25.TabIndex = 120
        Me.Label25.Text = "Línea"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Window
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 300)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 15)
        Me.Label8.TabIndex = 109
        Me.Label8.Text = "Horario"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Window
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(11, 248)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 15)
        Me.Label9.TabIndex = 108
        Me.Label9.Text = "Clase"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Window
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 196)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 15)
        Me.Label10.TabIndex = 107
        Me.Label10.Text = "Puesto"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Window
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 222)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 15)
        Me.Label11.TabIndex = 106
        Me.Label11.Text = "Tipo de empleado"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Window
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 274)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 15)
        Me.Label7.TabIndex = 105
        Me.Label7.Text = "Turno"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 170)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 15)
        Me.Label6.TabIndex = 104
        Me.Label6.Text = "Supervisor"
        '
        'lblDepto
        '
        Me.lblDepto.AutoSize = True
        Me.lblDepto.BackColor = System.Drawing.SystemColors.Window
        Me.lblDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDepto.Location = New System.Drawing.Point(12, 90)
        Me.lblDepto.Name = "lblDepto"
        Me.lblDepto.Size = New System.Drawing.Size(86, 15)
        Me.lblDepto.TabIndex = 103
        Me.lblDepto.Text = "Departamento"
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.BackColor = System.Drawing.SystemColors.Window
        Me.lbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.Location = New System.Drawing.Point(12, 12)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(64, 15)
        Me.lbl1.TabIndex = 92
        Me.lbl1.Text = "Compañía"
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.Color.DarkOrange
        '
        '
        '
        Me.lblEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblEstado.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblEstado.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Window
        Me.lblEstado.Location = New System.Drawing.Point(0, 0)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(29, 125)
        Me.lblEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblEstado.TabIndex = 135
        Me.lblEstado.Text = "* INACTIVO"
        Me.lblEstado.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblEstado.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.lblEstado.VerticalTextTopUp = False
        '
        'txtNombre
        '
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNombre.Location = New System.Drawing.Point(35, 82)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(157, 21)
        Me.txtNombre.TabIndex = 128
        '
        'txtApaterno
        '
        '
        '
        '
        Me.txtApaterno.Border.Class = "TextBoxBorder"
        Me.txtApaterno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtApaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApaterno.Enabled = False
        Me.txtApaterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtApaterno.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtApaterno.Location = New System.Drawing.Point(199, 82)
        Me.txtApaterno.Name = "txtApaterno"
        Me.txtApaterno.ReadOnly = True
        Me.txtApaterno.Size = New System.Drawing.Size(157, 21)
        Me.txtApaterno.TabIndex = 129
        '
        'txtAmaterno
        '
        '
        '
        '
        Me.txtAmaterno.Border.Class = "TextBoxBorder"
        Me.txtAmaterno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAmaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAmaterno.Enabled = False
        Me.txtAmaterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAmaterno.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtAmaterno.Location = New System.Drawing.Point(361, 82)
        Me.txtAmaterno.Name = "txtAmaterno"
        Me.txtAmaterno.ReadOnly = True
        Me.txtAmaterno.Size = New System.Drawing.Size(151, 21)
        Me.txtAmaterno.TabIndex = 130
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(32, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 131
        Me.Label2.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(196, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 15)
        Me.Label3.TabIndex = 132
        Me.Label3.Text = "Apellido paterno"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(358, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 15)
        Me.Label4.TabIndex = 133
        Me.Label4.Text = "Apellido materno"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(34, 11)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(439, 40)
        Me.ReflectionLabel1.TabIndex = 134
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CONSULTA GENERAL DE PERSONAL</b></font>"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.gbReloj)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.picFoto)
        Me.Panel3.Controls.Add(Me.lblBaja)
        Me.Panel3.Controls.Add(Me.txtAlta)
        Me.Panel3.Controls.Add(Me.txtBaja)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(637, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(294, 125)
        Me.Panel3.TabIndex = 136
        '
        'gbReloj
        '
        Me.gbReloj.Controls.Add(Me.LabelX4)
        Me.gbReloj.Controls.Add(Me.txtReloj)
        Me.gbReloj.Location = New System.Drawing.Point(4, 3)
        Me.gbReloj.Name = "gbReloj"
        Me.gbReloj.Size = New System.Drawing.Size(171, 41)
        Me.gbReloj.TabIndex = 0
        Me.gbReloj.TabStop = False
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(11, 11)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(56, 23)
        Me.LabelX4.TabIndex = 36
        Me.LabelX4.Text = "Reloj"
        '
        'txtReloj
        '
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtReloj.Location = New System.Drawing.Point(69, 10)
        Me.txtReloj.MaxLength = 6
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.ReadOnly = True
        Me.txtReloj.Size = New System.Drawing.Size(84, 26)
        Me.txtReloj.TabIndex = 0
        Me.txtReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 15)
        Me.Label1.TabIndex = 48
        Me.Label1.Text = "Fecha de alta"
        '
        'picFoto
        '
        Me.picFoto.Dock = System.Windows.Forms.DockStyle.Right
        Me.picFoto.ErrorImage = Global.PIDA.My.Resources.Resources.NoFoto
        Me.picFoto.Image = Global.PIDA.My.Resources.Resources.NoFoto
        Me.picFoto.InitialImage = Global.PIDA.My.Resources.Resources.NoFoto
        Me.picFoto.Location = New System.Drawing.Point(180, 0)
        Me.picFoto.MaximumSize = New System.Drawing.Size(164, 210)
        Me.picFoto.MinimumSize = New System.Drawing.Size(82, 105)
        Me.picFoto.Name = "picFoto"
        Me.picFoto.Size = New System.Drawing.Size(114, 125)
        Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picFoto.TabIndex = 12
        Me.picFoto.TabStop = False
        '
        'lblBaja
        '
        Me.lblBaja.AutoSize = True
        Me.lblBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBaja.Location = New System.Drawing.Point(1, 73)
        Me.lblBaja.Name = "lblBaja"
        Me.lblBaja.Size = New System.Drawing.Size(85, 15)
        Me.lblBaja.TabIndex = 49
        Me.lblBaja.Text = "Fecha de baja"
        '
        'txtAlta
        '
        '
        '
        '
        Me.txtAlta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtAlta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAlta.ButtonDropDown.Visible = True
        Me.txtAlta.DisabledForeColor = System.Drawing.Color.Black
        Me.txtAlta.Enabled = False
        Me.txtAlta.FocusHighlightEnabled = True
        Me.txtAlta.IsPopupCalendarOpen = False
        Me.txtAlta.Location = New System.Drawing.Point(92, 47)
        '
        '
        '
        Me.txtAlta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtAlta.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtAlta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAlta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtAlta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtAlta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAlta.MonthCalendar.DisplayMonth = New Date(2007, 10, 1, 0, 0, 0, 0)
        Me.txtAlta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtAlta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtAlta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtAlta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtAlta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtAlta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAlta.MonthCalendar.TodayButtonVisible = True
        Me.txtAlta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtAlta.Name = "txtAlta"
        Me.txtAlta.Size = New System.Drawing.Size(82, 20)
        Me.txtAlta.TabIndex = 1
        Me.txtAlta.Value = New Date(2007, 7, 7, 0, 0, 0, 0)
        '
        'txtBaja
        '
        '
        '
        '
        Me.txtBaja.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtBaja.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBaja.ButtonDropDown.Visible = True
        Me.txtBaja.DisabledForeColor = System.Drawing.Color.Black
        Me.txtBaja.Enabled = False
        Me.txtBaja.FocusHighlightEnabled = True
        Me.txtBaja.IsPopupCalendarOpen = False
        Me.txtBaja.Location = New System.Drawing.Point(92, 73)
        '
        '
        '
        Me.txtBaja.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtBaja.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtBaja.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBaja.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtBaja.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtBaja.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBaja.MonthCalendar.DisplayMonth = New Date(2007, 10, 1, 0, 0, 0, 0)
        Me.txtBaja.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtBaja.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtBaja.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtBaja.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtBaja.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtBaja.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBaja.MonthCalendar.TodayButtonVisible = True
        Me.txtBaja.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtBaja.Name = "txtBaja"
        Me.txtBaja.Size = New System.Drawing.Size(82, 20)
        Me.txtBaja.TabIndex = 2
        Me.txtBaja.Value = New Date(2007, 7, 7, 0, 0, 0, 0)
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblEstado)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.ReflectionLabel1)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtNombre)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtApaterno)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtAmaterno)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(931, 125)
        Me.Panel1.TabIndex = 137
        '
        'btnSexo
        '
        Me.btnSexo.AnimationEnabled = False
        '
        '
        '
        Me.btnSexo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnSexo.CausesValidation = False
        Me.btnSexo.Enabled = False
        Me.btnSexo.Location = New System.Drawing.Point(557, 90)
        Me.btnSexo.Name = "btnSexo"
        Me.btnSexo.OffBackColor = System.Drawing.Color.SkyBlue
        Me.btnSexo.OffText = "Masculino"
        Me.btnSexo.OffTextColor = System.Drawing.Color.Black
        Me.btnSexo.OnBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSexo.OnText = "Femenino"
        Me.btnSexo.OnTextColor = System.Drawing.Color.Black
        Me.btnSexo.Size = New System.Drawing.Size(219, 20)
        Me.btnSexo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSexo.SwitchBackColor = System.Drawing.SystemColors.Control
        Me.btnSexo.SwitchBorderColor = System.Drawing.SystemColors.ControlDark
        Me.btnSexo.SwitchFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSexo.SwitchWidth = 40
        Me.btnSexo.TabIndex = 142
        Me.btnSexo.Value = True
        Me.btnSexo.ValueObject = "Y"
        '
        'chkChecaTarjeta
        '
        Me.chkChecaTarjeta.AutoSize = True
        Me.chkChecaTarjeta.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkChecaTarjeta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkChecaTarjeta.Enabled = False
        Me.chkChecaTarjeta.Location = New System.Drawing.Point(682, 119)
        Me.chkChecaTarjeta.Name = "chkChecaTarjeta"
        Me.chkChecaTarjeta.Size = New System.Drawing.Size(88, 15)
        Me.chkChecaTarjeta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkChecaTarjeta.TabIndex = 144
        Me.chkChecaTarjeta.Text = "Checa tarjeta"
        Me.chkChecaTarjeta.TextColor = System.Drawing.SystemColors.ControlText
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.BackColor = System.Drawing.SystemColors.Window
        Me.Label59.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label59.Location = New System.Drawing.Point(436, 63)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(41, 15)
        Me.Label59.TabIndex = 149
        Me.Label59.Text = "CURP"
        '
        'txtCurp
        '
        Me.txtCurp.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtCurp.Border.Class = "TextBoxBorder"
        Me.txtCurp.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCurp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCurp.Enabled = False
        Me.txtCurp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCurp.Location = New System.Drawing.Point(557, 63)
        Me.txtCurp.MaxLength = 18
        Me.txtCurp.Name = "txtCurp"
        Me.txtCurp.Size = New System.Drawing.Size(219, 21)
        Me.txtCurp.TabIndex = 141
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.SystemColors.Window
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(436, 114)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 15)
        Me.Label16.TabIndex = 148
        Me.Label16.Text = "Gafete"
        '
        'txtGafete
        '
        Me.txtGafete.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtGafete.Border.Class = "TextBoxBorder"
        Me.txtGafete.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtGafete.Enabled = False
        Me.txtGafete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGafete.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtGafete.Location = New System.Drawing.Point(557, 116)
        Me.txtGafete.MaxLength = 10
        Me.txtGafete.Name = "txtGafete"
        Me.txtGafete.Size = New System.Drawing.Size(119, 21)
        Me.txtGafete.TabIndex = 143
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.SystemColors.Window
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(436, 88)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 15)
        Me.Label15.TabIndex = 147
        Me.Label15.Text = "Sexo"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.SystemColors.Window
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(436, 38)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 15)
        Me.Label14.TabIndex = 146
        Me.Label14.Text = "RFC"
        '
        'txtRFC
        '
        Me.txtRFC.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtRFC.Border.Class = "TextBoxBorder"
        Me.txtRFC.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRFC.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRFC.Enabled = False
        Me.txtRFC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRFC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtRFC.Location = New System.Drawing.Point(557, 36)
        Me.txtRFC.MaxLength = 14
        Me.txtRFC.Name = "txtRFC"
        Me.txtRFC.Size = New System.Drawing.Size(219, 21)
        Me.txtRFC.TabIndex = 140
        '
        'txtIMSSdv
        '
        Me.txtIMSSdv.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtIMSSdv.Border.Class = "TextBoxBorder"
        Me.txtIMSSdv.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtIMSSdv.Enabled = False
        Me.txtIMSSdv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIMSSdv.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtIMSSdv.Location = New System.Drawing.Point(745, 7)
        Me.txtIMSSdv.MaxLength = 1
        Me.txtIMSSdv.Name = "txtIMSSdv"
        Me.txtIMSSdv.ShortcutsEnabled = False
        Me.txtIMSSdv.Size = New System.Drawing.Size(31, 21)
        Me.txtIMSSdv.TabIndex = 139
        '
        'txtIMSS
        '
        Me.txtIMSS.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtIMSS.Border.Class = "TextBoxBorder"
        Me.txtIMSS.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtIMSS.Enabled = False
        Me.txtIMSS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIMSS.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtIMSS.Location = New System.Drawing.Point(557, 7)
        Me.txtIMSS.MaxLength = 10
        Me.txtIMSS.Name = "txtIMSS"
        Me.txtIMSS.Size = New System.Drawing.Size(182, 21)
        Me.txtIMSS.TabIndex = 138
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.Window
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(436, 12)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 15)
        Me.Label13.TabIndex = 145
        Me.Label13.Text = "IMSS"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pnlCentrarControles)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 572)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(931, 42)
        Me.Panel2.TabIndex = 150
        '
        'pnlCentrarControles
        '
        Me.pnlCentrarControles.Controls.Add(Me.btnFirst)
        Me.pnlCentrarControles.Controls.Add(Me.btnPrev)
        Me.pnlCentrarControles.Controls.Add(Me.btnBuscar)
        Me.pnlCentrarControles.Controls.Add(Me.btnNext)
        Me.pnlCentrarControles.Controls.Add(Me.btnCerrar)
        Me.pnlCentrarControles.Controls.Add(Me.btnLast)
        Me.pnlCentrarControles.Location = New System.Drawing.Point(6, 5)
        Me.pnlCentrarControles.Name = "pnlCentrarControles"
        Me.pnlCentrarControles.Size = New System.Drawing.Size(815, 32)
        Me.pnlCentrarControles.TabIndex = 0
        '
        'btnFirst
        '
        Me.btnFirst.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnFirst.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnFirst.Image = Global.PIDA.My.Resources.Resources.First16
        Me.btnFirst.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnFirst.Location = New System.Drawing.Point(3, 3)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(78, 25)
        Me.btnFirst.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnFirst.TabIndex = 0
        Me.btnFirst.Text = "Inicio"
        '
        'btnPrev
        '
        Me.btnPrev.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrev.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrev.Image = Global.PIDA.My.Resources.Resources.Prev16
        Me.btnPrev.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnPrev.Location = New System.Drawing.Point(84, 3)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(78, 25)
        Me.btnPrev.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrev.TabIndex = 1
        Me.btnPrev.Text = "Anterior"
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
        'btnNext
        '
        Me.btnNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNext.Image = Global.PIDA.My.Resources.Resources.Next16
        Me.btnNext.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnNext.Location = New System.Drawing.Point(165, 3)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(78, 25)
        Me.btnNext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "Siguiente"
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
        'btnLast
        '
        Me.btnLast.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLast.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLast.Image = Global.PIDA.My.Resources.Resources.Last16
        Me.btnLast.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnLast.Location = New System.Drawing.Point(246, 3)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(78, 25)
        Me.btnLast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLast.TabIndex = 3
        Me.btnLast.Text = "Final"
        '
        'SuperTabControl1
        '
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl1.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl1.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl1.ControlBox.Name = ""
        Me.SuperTabControl1.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl1.ControlBox.MenuBox, Me.SuperTabControl1.ControlBox.CloseBox})
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControl1.Location = New System.Drawing.Point(0, 125)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(931, 447)
        Me.SuperTabControl1.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 151
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1})
        Me.SuperTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.SuperTabControl1.Text = "Información General"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.lbl1)
        Me.SuperTabControlPanel1.Controls.Add(Me.lblDepto)
        Me.SuperTabControlPanel1.Controls.Add(Me.btnSexo)
        Me.SuperTabControlPanel1.Controls.Add(Me.Label6)
        Me.SuperTabControlPanel1.Controls.Add(Me.chkChecaTarjeta)
        Me.SuperTabControlPanel1.Controls.Add(Me.Label7)
        Me.SuperTabControlPanel1.Controls.Add(Me.Label59)
        Me.SuperTabControlPanel1.Controls.Add(Me.Label11)
        Me.SuperTabControlPanel1.Controls.Add(Me.txtCurp)
        Me.SuperTabControlPanel1.Controls.Add(Me.Label10)
        Me.SuperTabControlPanel1.Controls.Add(Me.Label16)
        Me.SuperTabControlPanel1.Controls.Add(Me.Label9)
        Me.SuperTabControlPanel1.Controls.Add(Me.txtGafete)
        Me.SuperTabControlPanel1.Controls.Add(Me.Label8)
        Me.SuperTabControlPanel1.Controls.Add(Me.Label15)
        Me.SuperTabControlPanel1.Controls.Add(Me.Label25)
        Me.SuperTabControlPanel1.Controls.Add(Me.Label14)
        Me.SuperTabControlPanel1.Controls.Add(Me.cmbDepto)
        Me.SuperTabControlPanel1.Controls.Add(Me.txtRFC)
        Me.SuperTabControlPanel1.Controls.Add(Me.cmbTurno)
        Me.SuperTabControlPanel1.Controls.Add(Me.txtIMSSdv)
        Me.SuperTabControlPanel1.Controls.Add(Me.cmbTipo)
        Me.SuperTabControlPanel1.Controls.Add(Me.txtIMSS)
        Me.SuperTabControlPanel1.Controls.Add(Me.cmbPuesto)
        Me.SuperTabControlPanel1.Controls.Add(Me.Label13)
        Me.SuperTabControlPanel1.Controls.Add(Me.cmbClase)
        Me.SuperTabControlPanel1.Controls.Add(Me.cmbHorario)
        Me.SuperTabControlPanel1.Controls.Add(Me.cmbCCostos)
        Me.SuperTabControlPanel1.Controls.Add(Me.cmbLinea)
        Me.SuperTabControlPanel1.Controls.Add(Me.Label58)
        Me.SuperTabControlPanel1.Controls.Add(Me.cmbSuper)
        Me.SuperTabControlPanel1.Controls.Add(Me.cmbArea)
        Me.SuperTabControlPanel1.Controls.Add(Me.Label61)
        Me.SuperTabControlPanel1.Controls.Add(Me.Label54)
        Me.SuperTabControlPanel1.Controls.Add(Me.cmbPlanta)
        Me.SuperTabControlPanel1.Controls.Add(Me.cmbCia)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(807, 447)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Información general"
        '
        'frmConsultaPersonal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(931, 614)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaPersonal"
        Me.Text = "Consulta de personal"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.gbReloj.ResumeLayout(False)
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAlta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.pnlCentrarControles.ResumeLayout(False)
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents cmbCCostos As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents cmbArea As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents cmbCia As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cmbPlanta As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents cmbSuper As DevComponents.DotNetBar.Controls.ComboTree
    Private WithEvents cmbLinea As DevComponents.DotNetBar.Controls.ComboTree
    Private WithEvents cmbHorario As DevComponents.DotNetBar.Controls.ComboTree
    Private WithEvents cmbClase As DevComponents.DotNetBar.Controls.ComboTree
    Private WithEvents cmbPuesto As DevComponents.DotNetBar.Controls.ComboTree
    Private WithEvents cmbTipo As DevComponents.DotNetBar.Controls.ComboTree
    Private WithEvents cmbTurno As DevComponents.DotNetBar.Controls.ComboTree
    Private WithEvents cmbDepto As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblDepto As System.Windows.Forms.Label
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents lblEstado As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtApaterno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtAmaterno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents gbReloj As System.Windows.Forms.GroupBox
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picFoto As System.Windows.Forms.PictureBox
    Friend WithEvents lblBaja As System.Windows.Forms.Label
    Private WithEvents txtAlta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Private WithEvents txtBaja As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnSexo As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents chkChecaTarjeta As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents txtCurp As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtGafete As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtRFC As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtIMSSdv As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtIMSS As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnlCentrarControles As System.Windows.Forms.Panel
    Friend WithEvents btnFirst As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrev As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNext As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnLast As DevComponents.DotNetBar.ButtonX
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
End Class
