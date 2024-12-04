<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlaneacion
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPlaneacion))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.tabBuscar = New DevComponents.DotNetBar.SuperTabControl()
        Me.pnlDatos = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.sprTabPlaneacion = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.pnlDatosPlaneacion = New System.Windows.Forms.Panel()
        Me.pnlCriterio = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnVerificar = New DevComponents.DotNetBar.ButtonX()
        Me.txtCriterio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnCriterio = New DevComponents.DotNetBar.ButtonX()
        Me.pnlObligatorio = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtMeses = New DevComponents.Editors.IntegerInput()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTematica = New System.Windows.Forms.Label()
        Me.txtFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.chkAlta = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkFecha = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.btnObligatorio = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tabConfiguracion = New DevComponents.DotNetBar.SuperTabItem()
        Me.pnlConfiguracion = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.lblEmpleados = New System.Windows.Forms.Label()
        Me.dgVistaPrevia = New System.Windows.Forms.DataGridView()
        Me.colReloj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFechaMaxima = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUsuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabVistaPrevia = New DevComponents.DotNetBar.SuperTabItem()
        Me.cmbMes = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.cmbAno = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.cmbCurso = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tabEmpleado = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgTabla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.colCodCurso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombreCurso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colObligatorio = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.tabTabla = New DevComponents.DotNetBar.SuperTabItem()
        Me.EmpNav = New System.Windows.Forms.GroupBox()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.bgw = New System.ComponentModel.BackgroundWorker()
        Me.pnlRegistosVista = New System.Windows.Forms.Panel()
        Me.cmbPlMes = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.cmbPlAnio = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dgCursosPlaneados = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnEliminaTodos = New DevComponents.DotNetBar.ButtonX()
        Me.btnEliminaSel = New DevComponents.DotNetBar.ButtonX()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnEdita = New DevComponents.DotNetBar.ButtonX()
        Me.dtiMax = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dtiInicio = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblCursosPlaneados = New System.Windows.Forms.Label()
        Me.reloj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ano = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha_captura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fecha_maxima = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.obligatorio = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.chkFhaIni = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkFhaMax = New DevComponents.DotNetBar.Controls.CheckBoxX()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBuscar.SuspendLayout()
        Me.pnlDatos.SuspendLayout()
        CType(Me.sprTabPlaneacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sprTabPlaneacion.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.pnlDatosPlaneacion.SuspendLayout()
        Me.pnlCriterio.SuspendLayout()
        Me.pnlObligatorio.SuspendLayout()
        CType(Me.txtMeses, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConfiguracion.SuspendLayout()
        CType(Me.dgVistaPrevia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EmpNav.SuspendLayout()
        Me.pnlRegistosVista.SuspendLayout()
        CType(Me.dgCursosPlaneados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dtiMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtiInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Planeacion32
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 40)
        Me.PictureBox1.TabIndex = 81
        Me.PictureBox1.TabStop = False
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(56, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(406, 40)
        Me.ReflectionLabel1.TabIndex = 80
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>PLANEACIÓN DE CURSOS</b></font>"
        '
        'tabBuscar
        '
        Me.tabBuscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        '
        '
        '
        Me.tabBuscar.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.tabBuscar.ControlBox.MenuBox.Name = ""
        Me.tabBuscar.ControlBox.MenuBox.Visible = False
        Me.tabBuscar.ControlBox.Name = ""
        Me.tabBuscar.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabBuscar.ControlBox.MenuBox, Me.tabBuscar.ControlBox.CloseBox})
        Me.tabBuscar.Controls.Add(Me.pnlDatos)
        Me.tabBuscar.Controls.Add(Me.SuperTabControlPanel2)
        Me.tabBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.Location = New System.Drawing.Point(12, 62)
        Me.tabBuscar.Name = "tabBuscar"
        Me.tabBuscar.ReorderTabsEnabled = True
        Me.tabBuscar.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabBuscar.SelectedTabIndex = 0
        Me.tabBuscar.Size = New System.Drawing.Size(766, 583)
        Me.tabBuscar.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.tabBuscar.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.TabIndex = 82
        Me.tabBuscar.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit
        Me.tabBuscar.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabEmpleado, Me.tabTabla})
        Me.tabBuscar.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.sprTabPlaneacion)
        Me.pnlDatos.Controls.Add(Me.cmbMes)
        Me.pnlDatos.Controls.Add(Me.cmbAno)
        Me.pnlDatos.Controls.Add(Me.cmbCurso)
        Me.pnlDatos.Controls.Add(Me.Label4)
        Me.pnlDatos.Controls.Add(Me.Label1)
        Me.pnlDatos.Controls.Add(Me.Label2)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(632, 583)
        Me.pnlDatos.TabIndex = 0
        Me.pnlDatos.TabItem = Me.tabEmpleado
        '
        'sprTabPlaneacion
        '
        Me.sprTabPlaneacion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sprTabPlaneacion.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        '
        '
        '
        Me.sprTabPlaneacion.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.sprTabPlaneacion.ControlBox.MenuBox.Name = ""
        Me.sprTabPlaneacion.ControlBox.Name = ""
        Me.sprTabPlaneacion.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.sprTabPlaneacion.ControlBox.MenuBox, Me.sprTabPlaneacion.ControlBox.CloseBox})
        Me.sprTabPlaneacion.Controls.Add(Me.SuperTabControlPanel1)
        Me.sprTabPlaneacion.Controls.Add(Me.pnlConfiguracion)
        Me.sprTabPlaneacion.Location = New System.Drawing.Point(26, 91)
        Me.sprTabPlaneacion.Name = "sprTabPlaneacion"
        Me.sprTabPlaneacion.ReorderTabsEnabled = True
        Me.sprTabPlaneacion.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
        Me.sprTabPlaneacion.SelectedTabIndex = 0
        Me.sprTabPlaneacion.Size = New System.Drawing.Size(582, 470)
        Me.sprTabPlaneacion.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sprTabPlaneacion.TabIndex = 3
        Me.sprTabPlaneacion.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit
        Me.sprTabPlaneacion.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabConfiguracion, Me.tabVistaPrevia})
        Me.sprTabPlaneacion.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.sprTabPlaneacion.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.AutoScroll = True
        Me.SuperTabControlPanel1.Controls.Add(Me.pnlDatosPlaneacion)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 23)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(582, 447)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.tabConfiguracion
        '
        'pnlDatosPlaneacion
        '
        Me.pnlDatosPlaneacion.AutoScroll = True
        Me.pnlDatosPlaneacion.BackColor = System.Drawing.Color.Transparent
        Me.pnlDatosPlaneacion.Controls.Add(Me.pnlCriterio)
        Me.pnlDatosPlaneacion.Controls.Add(Me.pnlObligatorio)
        Me.pnlDatosPlaneacion.Controls.Add(Me.btnObligatorio)
        Me.pnlDatosPlaneacion.Controls.Add(Me.Label5)
        Me.pnlDatosPlaneacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatosPlaneacion.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatosPlaneacion.Name = "pnlDatosPlaneacion"
        Me.pnlDatosPlaneacion.Size = New System.Drawing.Size(582, 447)
        Me.pnlDatosPlaneacion.TabIndex = 89
        '
        'pnlCriterio
        '
        Me.pnlCriterio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlCriterio.Controls.Add(Me.Label8)
        Me.pnlCriterio.Controls.Add(Me.Label3)
        Me.pnlCriterio.Controls.Add(Me.btnVerificar)
        Me.pnlCriterio.Controls.Add(Me.txtCriterio)
        Me.pnlCriterio.Controls.Add(Me.btnCriterio)
        Me.pnlCriterio.Location = New System.Drawing.Point(35, 191)
        Me.pnlCriterio.Name = "pnlCriterio"
        Me.pnlCriterio.Size = New System.Drawing.Size(506, 100)
        Me.pnlCriterio.TabIndex = 141
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Control
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(0, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.Label8.Size = New System.Drawing.Size(504, 18)
        Me.Label8.TabIndex = 141
        Me.Label8.Text = "Personal a asignar"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 15)
        Me.Label3.TabIndex = 93
        Me.Label3.Text = "Criterio"
        '
        'btnVerificar
        '
        Me.btnVerificar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnVerificar.CausesValidation = False
        Me.btnVerificar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnVerificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVerificar.Image = Global.PIDA.My.Resources.Resources.Validar22
        Me.btnVerificar.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnVerificar.Location = New System.Drawing.Point(438, 63)
        Me.btnVerificar.Name = "btnVerificar"
        Me.btnVerificar.Size = New System.Drawing.Size(26, 23)
        Me.btnVerificar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnVerificar.TabIndex = 7
        Me.btnVerificar.Tooltip = "Verificar criterio"
        '
        'txtCriterio
        '
        '
        '
        '
        Me.txtCriterio.Border.Class = "TextBoxBorder"
        Me.txtCriterio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCriterio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCriterio.Location = New System.Drawing.Point(82, 35)
        Me.txtCriterio.MaxLength = 60
        Me.txtCriterio.Multiline = True
        Me.txtCriterio.Name = "txtCriterio"
        Me.txtCriterio.Size = New System.Drawing.Size(339, 51)
        Me.txtCriterio.TabIndex = 5
        '
        'btnCriterio
        '
        Me.btnCriterio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCriterio.CausesValidation = False
        Me.btnCriterio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCriterio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCriterio.Image = Global.PIDA.My.Resources.Resources.Lapiz16
        Me.btnCriterio.Location = New System.Drawing.Point(438, 35)
        Me.btnCriterio.Name = "btnCriterio"
        Me.btnCriterio.Size = New System.Drawing.Size(26, 23)
        Me.btnCriterio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCriterio.TabIndex = 6
        Me.btnCriterio.Tooltip = "Agregar nuevo criterio"
        '
        'pnlObligatorio
        '
        Me.pnlObligatorio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlObligatorio.Controls.Add(Me.Label9)
        Me.pnlObligatorio.Controls.Add(Me.txtMeses)
        Me.pnlObligatorio.Controls.Add(Me.Label6)
        Me.pnlObligatorio.Controls.Add(Me.lblTematica)
        Me.pnlObligatorio.Controls.Add(Me.txtFecha)
        Me.pnlObligatorio.Controls.Add(Me.chkAlta)
        Me.pnlObligatorio.Controls.Add(Me.chkFecha)
        Me.pnlObligatorio.Location = New System.Drawing.Point(35, 62)
        Me.pnlObligatorio.Name = "pnlObligatorio"
        Me.pnlObligatorio.Size = New System.Drawing.Size(506, 113)
        Me.pnlObligatorio.TabIndex = 140
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.SystemColors.Control
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(0, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.Label9.Size = New System.Drawing.Size(504, 18)
        Me.Label9.TabIndex = 140
        Me.Label9.Text = "Periodo máximo para tomar el curso"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMeses
        '
        '
        '
        '
        Me.txtMeses.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtMeses.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMeses.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtMeses.Location = New System.Drawing.Point(103, 29)
        Me.txtMeses.MaxValue = 12
        Me.txtMeses.MinValue = 0
        Me.txtMeses.Name = "txtMeses"
        Me.txtMeses.ShowUpDown = True
        Me.txtMeses.Size = New System.Drawing.Size(68, 20)
        Me.txtMeses.TabIndex = 1
        Me.txtMeses.Value = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(22, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 15)
        Me.Label6.TabIndex = 136
        Me.Label6.Text = "Después de"
        '
        'lblTematica
        '
        Me.lblTematica.AutoSize = True
        Me.lblTematica.BackColor = System.Drawing.SystemColors.Window
        Me.lblTematica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTematica.Location = New System.Drawing.Point(177, 32)
        Me.lblTematica.Name = "lblTematica"
        Me.lblTematica.Size = New System.Drawing.Size(108, 15)
        Me.lblTematica.TabIndex = 132
        Me.lblTematica.Text = "meses, a partir de:"
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtFecha.ButtonDropDown.Visible = True
        Me.txtFecha.IsPopupCalendarOpen = False
        Me.txtFecha.Location = New System.Drawing.Point(286, 81)
        '
        '
        '
        Me.txtFecha.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFecha.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtFecha.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha.MonthCalendar.DisplayMonth = New Date(2014, 6, 1, 0, 0, 0, 0)
        Me.txtFecha.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFecha.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFecha.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFecha.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFecha.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFecha.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha.MonthCalendar.TodayButtonVisible = True
        Me.txtFecha.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(97, 20)
        Me.txtFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFecha.TabIndex = 4
        '
        'chkAlta
        '
        Me.chkAlta.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkAlta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkAlta.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkAlta.Location = New System.Drawing.Point(180, 60)
        Me.chkAlta.Name = "chkAlta"
        Me.chkAlta.Size = New System.Drawing.Size(100, 15)
        Me.chkAlta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkAlta.TabIndex = 2
        Me.chkAlta.Text = "Fecha de alta"
        Me.chkAlta.TextColor = System.Drawing.Color.Black
        '
        'chkFecha
        '
        Me.chkFecha.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkFecha.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkFecha.Location = New System.Drawing.Point(180, 84)
        Me.chkFecha.Name = "chkFecha"
        Me.chkFecha.Size = New System.Drawing.Size(100, 15)
        Me.chkFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkFecha.TabIndex = 3
        Me.chkFecha.Text = "Fecha específica"
        Me.chkFecha.TextColor = System.Drawing.Color.Black
        '
        'btnObligatorio
        '
        '
        '
        '
        Me.btnObligatorio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnObligatorio.Location = New System.Drawing.Point(117, 21)
        Me.btnObligatorio.Name = "btnObligatorio"
        Me.btnObligatorio.OffText = "No"
        Me.btnObligatorio.OffTextColor = System.Drawing.Color.Black
        Me.btnObligatorio.OnText = "Si"
        Me.btnObligatorio.OnTextColor = System.Drawing.Color.Black
        Me.btnObligatorio.Size = New System.Drawing.Size(68, 22)
        Me.btnObligatorio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnObligatorio.SwitchWidth = 20
        Me.btnObligatorio.TabIndex = 0
        Me.btnObligatorio.Value = True
        Me.btnObligatorio.ValueObject = "Y"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(36, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 15)
        Me.Label5.TabIndex = 88
        Me.Label5.Text = "Obligatorio"
        '
        'tabConfiguracion
        '
        Me.tabConfiguracion.AttachedControl = Me.SuperTabControlPanel1
        Me.tabConfiguracion.GlobalItem = False
        Me.tabConfiguracion.Name = "tabConfiguracion"
        Me.tabConfiguracion.Text = "Configuración"
        '
        'pnlConfiguracion
        '
        Me.pnlConfiguracion.Controls.Add(Me.lblEmpleados)
        Me.pnlConfiguracion.Controls.Add(Me.dgVistaPrevia)
        Me.pnlConfiguracion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlConfiguracion.Location = New System.Drawing.Point(0, 23)
        Me.pnlConfiguracion.Name = "pnlConfiguracion"
        Me.pnlConfiguracion.Size = New System.Drawing.Size(582, 447)
        Me.pnlConfiguracion.TabIndex = 0
        Me.pnlConfiguracion.TabItem = Me.tabVistaPrevia
        '
        'lblEmpleados
        '
        Me.lblEmpleados.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblEmpleados.Location = New System.Drawing.Point(0, 424)
        Me.lblEmpleados.Name = "lblEmpleados"
        Me.lblEmpleados.Size = New System.Drawing.Size(582, 23)
        Me.lblEmpleados.TabIndex = 2
        Me.lblEmpleados.Text = "# Registros"
        Me.lblEmpleados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgVistaPrevia
        '
        Me.dgVistaPrevia.AllowUserToAddRows = False
        Me.dgVistaPrevia.AllowUserToDeleteRows = False
        Me.dgVistaPrevia.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgVistaPrevia.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgVistaPrevia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgVistaPrevia.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colReloj, Me.colNombre, Me.colFechaMaxima, Me.colUsuario})
        Me.dgVistaPrevia.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgVistaPrevia.Location = New System.Drawing.Point(0, 0)
        Me.dgVistaPrevia.Name = "dgVistaPrevia"
        Me.dgVistaPrevia.ReadOnly = True
        Me.dgVistaPrevia.RowHeadersVisible = False
        Me.dgVistaPrevia.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgVistaPrevia.Size = New System.Drawing.Size(582, 239)
        Me.dgVistaPrevia.TabIndex = 1
        '
        'colReloj
        '
        Me.colReloj.DataPropertyName = "reloj"
        Me.colReloj.HeaderText = "RELOJ"
        Me.colReloj.Name = "colReloj"
        Me.colReloj.ReadOnly = True
        Me.colReloj.Width = 65
        '
        'colNombre
        '
        Me.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colNombre.DataPropertyName = "nombres"
        Me.colNombre.HeaderText = "NOMBRE"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        '
        'colFechaMaxima
        '
        Me.colFechaMaxima.DataPropertyName = "fecha_maxima"
        DataGridViewCellStyle2.Format = "d"
        Me.colFechaMaxima.DefaultCellStyle = DataGridViewCellStyle2
        Me.colFechaMaxima.HeaderText = "FECHA MÁXIMA"
        Me.colFechaMaxima.Name = "colFechaMaxima"
        Me.colFechaMaxima.ReadOnly = True
        Me.colFechaMaxima.Width = 85
        '
        'colUsuario
        '
        Me.colUsuario.DataPropertyName = "usuario"
        Me.colUsuario.HeaderText = "USUARIO"
        Me.colUsuario.Name = "colUsuario"
        Me.colUsuario.ReadOnly = True
        Me.colUsuario.Width = 85
        '
        'tabVistaPrevia
        '
        Me.tabVistaPrevia.AttachedControl = Me.pnlConfiguracion
        Me.tabVistaPrevia.GlobalItem = False
        Me.tabVistaPrevia.Name = "tabVistaPrevia"
        Me.tabVistaPrevia.Text = "Vista previa de personal asignado"
        '
        'cmbMes
        '
        Me.cmbMes.DisplayMember = "mes_may"
        Me.cmbMes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.ItemHeight = 14
        Me.cmbMes.Location = New System.Drawing.Point(273, 49)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(157, 20)
        Me.cmbMes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbMes.TabIndex = 2
        Me.cmbMes.ValueMember = "mes_may"
        '
        'cmbAno
        '
        Me.cmbAno.DisplayMember = "ano"
        Me.cmbAno.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAno.FormattingEnabled = True
        Me.cmbAno.ItemHeight = 14
        Me.cmbAno.Location = New System.Drawing.Point(86, 49)
        Me.cmbAno.Name = "cmbAno"
        Me.cmbAno.Size = New System.Drawing.Size(86, 20)
        Me.cmbAno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbAno.TabIndex = 1
        Me.cmbAno.ValueMember = "ano"
        '
        'cmbCurso
        '
        Me.cmbCurso.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbCurso.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbCurso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbCurso.ButtonDropDown.Visible = True
        Me.cmbCurso.Columns.Add(Me.ColumnHeader1)
        Me.cmbCurso.Columns.Add(Me.ColumnHeader2)
        Me.cmbCurso.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbCurso.Location = New System.Drawing.Point(86, 20)
        Me.cmbCurso.Name = "cmbCurso"
        Me.cmbCurso.Size = New System.Drawing.Size(522, 23)
        Me.cmbCurso.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbCurso.TabIndex = 0
        Me.cmbCurso.ValueMember = "cod_curso"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.ColumnName = "nombre"
        Me.ColumnHeader1.DataFieldName = "nombre"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.StretchToFill = True
        Me.ColumnHeader1.Text = "Nombre"
        Me.ColumnHeader1.Width.Absolute = 150
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.ColumnName = "cod_curso"
        Me.ColumnHeader2.DataFieldName = "cod_curso"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Código"
        Me.ColumnHeader2.Width.Absolute = 50
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(215, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 15)
        Me.Label4.TabIndex = 86
        Me.Label4.Text = "Mes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 15)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Curso"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 15)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Año"
        '
        'tabEmpleado
        '
        Me.tabEmpleado.AttachedControl = Me.pnlDatos
        Me.tabEmpleado.GlobalItem = False
        Me.tabEmpleado.Name = "tabEmpleado"
        Me.tabEmpleado.Text = "Planear nuevo curso"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.dgTabla)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(634, 583)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.tabTabla
        '
        'dgTabla
        '
        Me.dgTabla.AllowUserToAddRows = False
        Me.dgTabla.AllowUserToDeleteRows = False
        Me.dgTabla.AllowUserToOrderColumns = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTabla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgTabla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCodCurso, Me.colNombreCurso, Me.colMes, Me.colAno, Me.colObligatorio})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTabla.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgTabla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTabla.EnableHeadersVisualStyles = False
        Me.dgTabla.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgTabla.Location = New System.Drawing.Point(0, 0)
        Me.dgTabla.MultiSelect = False
        Me.dgTabla.Name = "dgTabla"
        Me.dgTabla.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTabla.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgTabla.RowHeadersVisible = False
        Me.dgTabla.Size = New System.Drawing.Size(634, 583)
        Me.dgTabla.TabIndex = 0
        '
        'colCodCurso
        '
        Me.colCodCurso.DataPropertyName = "codigo"
        Me.colCodCurso.HeaderText = "Código"
        Me.colCodCurso.Name = "colCodCurso"
        Me.colCodCurso.ReadOnly = True
        Me.colCodCurso.Width = 70
        '
        'colNombreCurso
        '
        Me.colNombreCurso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colNombreCurso.DataPropertyName = "nombre"
        Me.colNombreCurso.HeaderText = "Nombre"
        Me.colNombreCurso.Name = "colNombreCurso"
        Me.colNombreCurso.ReadOnly = True
        '
        'colMes
        '
        Me.colMes.DataPropertyName = "mes_letra"
        Me.colMes.HeaderText = "Mes"
        Me.colMes.Name = "colMes"
        Me.colMes.ReadOnly = True
        Me.colMes.Width = 70
        '
        'colAno
        '
        Me.colAno.DataPropertyName = "ano"
        Me.colAno.HeaderText = "Año"
        Me.colAno.Name = "colAno"
        Me.colAno.ReadOnly = True
        Me.colAno.Width = 60
        '
        'colObligatorio
        '
        Me.colObligatorio.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.colObligatorio.CheckBoxImageIndeterminate = Global.PIDA.My.Resources.Resources.Unckecked16
        Me.colObligatorio.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.Unckecked16
        Me.colObligatorio.Checked = True
        Me.colObligatorio.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.colObligatorio.CheckValue = "N"
        Me.colObligatorio.DataPropertyName = "obligatorio"
        Me.colObligatorio.HeaderText = "Obligatorio"
        Me.colObligatorio.Name = "colObligatorio"
        Me.colObligatorio.ReadOnly = True
        Me.colObligatorio.Width = 60
        '
        'tabTabla
        '
        Me.tabTabla.AttachedControl = Me.SuperTabControlPanel2
        Me.tabTabla.GlobalItem = False
        Me.tabTabla.Name = "tabTabla"
        Me.tabTabla.Text = "Cursos programados"
        '
        'EmpNav
        '
        Me.EmpNav.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EmpNav.Controls.Add(Me.btnCancelar)
        Me.EmpNav.Controls.Add(Me.btnAceptar)
        Me.EmpNav.Location = New System.Drawing.Point(12, 651)
        Me.EmpNav.Name = "EmpNav"
        Me.EmpNav.Size = New System.Drawing.Size(1326, 66)
        Me.EmpNav.TabIndex = 83
        Me.EmpNav.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCancelar.Location = New System.Drawing.Point(95, 23)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(76, 25)
        Me.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.Location = New System.Drawing.Point(13, 23)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(76, 25)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "Aceptar"
        '
        'bgw
        '
        '
        'pnlRegistosVista
        '
        Me.pnlRegistosVista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlRegistosVista.BackColor = System.Drawing.Color.White
        Me.pnlRegistosVista.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlRegistosVista.Controls.Add(Me.cmbPlMes)
        Me.pnlRegistosVista.Controls.Add(Me.cmbPlAnio)
        Me.pnlRegistosVista.Controls.Add(Me.Label13)
        Me.pnlRegistosVista.Controls.Add(Me.Label14)
        Me.pnlRegistosVista.Controls.Add(Me.dgCursosPlaneados)
        Me.pnlRegistosVista.Controls.Add(Me.Panel1)
        Me.pnlRegistosVista.Controls.Add(Me.lblCursosPlaneados)
        Me.pnlRegistosVista.Location = New System.Drawing.Point(800, 62)
        Me.pnlRegistosVista.Name = "pnlRegistosVista"
        Me.pnlRegistosVista.Size = New System.Drawing.Size(538, 583)
        Me.pnlRegistosVista.TabIndex = 84
        '
        'cmbPlMes
        '
        Me.cmbPlMes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPlMes.DisplayMember = "mes"
        Me.cmbPlMes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPlMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlMes.FormattingEnabled = True
        Me.cmbPlMes.ItemHeight = 14
        Me.cmbPlMes.Location = New System.Drawing.Point(436, 9)
        Me.cmbPlMes.Name = "cmbPlMes"
        Me.cmbPlMes.Size = New System.Drawing.Size(88, 20)
        Me.cmbPlMes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPlMes.TabIndex = 147
        Me.cmbPlMes.ValueMember = "mes"
        '
        'cmbPlAnio
        '
        Me.cmbPlAnio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPlAnio.DisplayMember = "ano"
        Me.cmbPlAnio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPlAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlAnio.FormattingEnabled = True
        Me.cmbPlAnio.ItemHeight = 14
        Me.cmbPlAnio.Location = New System.Drawing.Point(298, 9)
        Me.cmbPlAnio.Name = "cmbPlAnio"
        Me.cmbPlAnio.Size = New System.Drawing.Size(86, 20)
        Me.cmbPlAnio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPlAnio.TabIndex = 146
        Me.cmbPlAnio.ValueMember = "ano"
        '
        'Label13
        '
        Me.Label13.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.Highlight
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(402, 11)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 15)
        Me.Label13.TabIndex = 149
        Me.Label13.Text = "Mes"
        '
        'Label14
        '
        Me.Label14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.SystemColors.Highlight
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(267, 11)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 15)
        Me.Label14.TabIndex = 148
        Me.Label14.Text = "Año"
        '
        'dgCursosPlaneados
        '
        Me.dgCursosPlaneados.AllowUserToAddRows = False
        Me.dgCursosPlaneados.AllowUserToDeleteRows = False
        Me.dgCursosPlaneados.AllowUserToResizeRows = False
        Me.dgCursosPlaneados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCursosPlaneados.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgCursosPlaneados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCursosPlaneados.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.reloj, Me.nombres, Me.mes, Me.ano, Me.fecha_captura, Me.fecha_maxima, Me.obligatorio})
        Me.dgCursosPlaneados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgCursosPlaneados.Location = New System.Drawing.Point(0, 38)
        Me.dgCursosPlaneados.Name = "dgCursosPlaneados"
        Me.dgCursosPlaneados.ReadOnly = True
        Me.dgCursosPlaneados.RowHeadersVisible = False
        Me.dgCursosPlaneados.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgCursosPlaneados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCursosPlaneados.Size = New System.Drawing.Size(536, 423)
        Me.dgCursosPlaneados.TabIndex = 145
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 461)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(536, 120)
        Me.Panel1.TabIndex = 144
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.btnEliminaTodos)
        Me.Panel3.Controls.Add(Me.btnEliminaSel)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Location = New System.Drawing.Point(329, 11)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(196, 100)
        Me.Panel3.TabIndex = 14
        '
        'btnEliminaTodos
        '
        Me.btnEliminaTodos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEliminaTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btnEliminaTodos.CausesValidation = False
        Me.btnEliminaTodos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEliminaTodos.Enabled = False
        Me.btnEliminaTodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminaTodos.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnEliminaTodos.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnEliminaTodos.Location = New System.Drawing.Point(14, 65)
        Me.btnEliminaTodos.Name = "btnEliminaTodos"
        Me.btnEliminaTodos.Size = New System.Drawing.Size(170, 25)
        Me.btnEliminaTodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEliminaTodos.TabIndex = 11
        Me.btnEliminaTodos.Text = "Todos"
        '
        'btnEliminaSel
        '
        Me.btnEliminaSel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEliminaSel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.btnEliminaSel.CausesValidation = False
        Me.btnEliminaSel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEliminaSel.Enabled = False
        Me.btnEliminaSel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminaSel.Image = Global.PIDA.My.Resources.Resources.l_cancelado
        Me.btnEliminaSel.ImageFixedSize = New System.Drawing.Size(15, 15)
        Me.btnEliminaSel.Location = New System.Drawing.Point(14, 29)
        Me.btnEliminaSel.Name = "btnEliminaSel"
        Me.btnEliminaSel.Size = New System.Drawing.Size(170, 25)
        Me.btnEliminaSel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEliminaSel.TabIndex = 10
        Me.btnEliminaSel.Text = "Seleccionado"
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.SystemColors.Control
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(0, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.Label10.Size = New System.Drawing.Size(194, 18)
        Me.Label10.TabIndex = 141
        Me.Label10.Text = "Eliminar registros"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.chkFhaMax)
        Me.Panel2.Controls.Add(Me.chkFhaIni)
        Me.Panel2.Controls.Add(Me.btnEdita)
        Me.Panel2.Controls.Add(Me.dtiMax)
        Me.Panel2.Controls.Add(Me.dtiInicio)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Location = New System.Drawing.Point(13, 11)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(295, 100)
        Me.Panel2.TabIndex = 13
        '
        'btnEdita
        '
        Me.btnEdita.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEdita.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdita.CausesValidation = False
        Me.btnEdita.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEdita.Enabled = False
        Me.btnEdita.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdita.Image = Global.PIDA.My.Resources.Resources.Edit
        Me.btnEdita.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnEdita.Location = New System.Drawing.Point(233, 34)
        Me.btnEdita.Name = "btnEdita"
        Me.btnEdita.Size = New System.Drawing.Size(45, 44)
        Me.btnEdita.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEdita.TabIndex = 146
        '
        'dtiMax
        '
        Me.dtiMax.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.dtiMax.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtiMax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiMax.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtiMax.ButtonDropDown.Visible = True
        Me.dtiMax.Enabled = False
        Me.dtiMax.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dtiMax.IsInputReadOnly = True
        Me.dtiMax.IsPopupCalendarOpen = False
        Me.dtiMax.Location = New System.Drawing.Point(121, 65)
        Me.dtiMax.MinDate = New Date(2022, 6, 15, 0, 0, 0, 0)
        '
        '
        '
        Me.dtiMax.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtiMax.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiMax.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtiMax.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtiMax.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtiMax.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiMax.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtiMax.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtiMax.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtiMax.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtiMax.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiMax.MonthCalendar.DisplayMonth = New Date(2022, 6, 1, 0, 0, 0, 0)
        Me.dtiMax.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtiMax.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtiMax.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtiMax.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiMax.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtiMax.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiMax.MonthCalendar.TodayButtonVisible = True
        Me.dtiMax.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtiMax.Name = "dtiMax"
        Me.dtiMax.Size = New System.Drawing.Size(91, 20)
        Me.dtiMax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtiMax.TabIndex = 145
        '
        'dtiInicio
        '
        Me.dtiInicio.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.dtiInicio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtiInicio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiInicio.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtiInicio.ButtonDropDown.Visible = True
        Me.dtiInicio.Enabled = False
        Me.dtiInicio.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dtiInicio.IsInputReadOnly = True
        Me.dtiInicio.IsPopupCalendarOpen = False
        Me.dtiInicio.Location = New System.Drawing.Point(121, 29)
        Me.dtiInicio.MinDate = New Date(2022, 6, 15, 0, 0, 0, 0)
        '
        '
        '
        Me.dtiInicio.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtiInicio.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiInicio.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtiInicio.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtiInicio.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtiInicio.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiInicio.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtiInicio.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtiInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtiInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtiInicio.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiInicio.MonthCalendar.DisplayMonth = New Date(2022, 6, 1, 0, 0, 0, 0)
        Me.dtiInicio.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtiInicio.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtiInicio.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtiInicio.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiInicio.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtiInicio.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiInicio.MonthCalendar.TodayButtonVisible = True
        Me.dtiInicio.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtiInicio.Name = "dtiInicio"
        Me.dtiInicio.Size = New System.Drawing.Size(91, 20)
        Me.dtiInicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtiInicio.TabIndex = 144
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Window
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(28, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 15)
        Me.Label12.TabIndex = 143
        Me.Label12.Text = "Fecha máxima"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Window
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(28, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 15)
        Me.Label11.TabIndex = 142
        Me.Label11.Text = "Fecha inicio"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Control
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.Label7.Size = New System.Drawing.Size(293, 18)
        Me.Label7.TabIndex = 141
        Me.Label7.Text = "Edición fechas de curso"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCursosPlaneados
        '
        Me.lblCursosPlaneados.BackColor = System.Drawing.SystemColors.Highlight
        Me.lblCursosPlaneados.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblCursosPlaneados.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCursosPlaneados.ForeColor = System.Drawing.SystemColors.Control
        Me.lblCursosPlaneados.Location = New System.Drawing.Point(0, 0)
        Me.lblCursosPlaneados.Name = "lblCursosPlaneados"
        Me.lblCursosPlaneados.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.lblCursosPlaneados.Size = New System.Drawing.Size(536, 38)
        Me.lblCursosPlaneados.TabIndex = 142
        Me.lblCursosPlaneados.Text = "Empleados cursos planeados"
        Me.lblCursosPlaneados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'reloj
        '
        Me.reloj.DataPropertyName = "reloj"
        Me.reloj.HeaderText = "reloj"
        Me.reloj.Name = "reloj"
        Me.reloj.ReadOnly = True
        Me.reloj.Width = 55
        '
        'nombres
        '
        Me.nombres.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.nombres.DataPropertyName = "nombres"
        Me.nombres.HeaderText = "nombre"
        Me.nombres.Name = "nombres"
        Me.nombres.ReadOnly = True
        '
        'mes
        '
        Me.mes.DataPropertyName = "mes"
        Me.mes.HeaderText = "mes"
        Me.mes.Name = "mes"
        Me.mes.ReadOnly = True
        Me.mes.Width = 45
        '
        'ano
        '
        Me.ano.DataPropertyName = "ano"
        Me.ano.HeaderText = "año"
        Me.ano.Name = "ano"
        Me.ano.ReadOnly = True
        Me.ano.Width = 45
        '
        'fecha_captura
        '
        Me.fecha_captura.DataPropertyName = "fecha_captura"
        DataGridViewCellStyle7.Format = "d"
        Me.fecha_captura.DefaultCellStyle = DataGridViewCellStyle7
        Me.fecha_captura.HeaderText = "fecha inicio"
        Me.fecha_captura.Name = "fecha_captura"
        Me.fecha_captura.ReadOnly = True
        Me.fecha_captura.Width = 75
        '
        'fecha_maxima
        '
        Me.fecha_maxima.DataPropertyName = "fecha_maxima"
        Me.fecha_maxima.HeaderText = "fecha maxima"
        Me.fecha_maxima.Name = "fecha_maxima"
        Me.fecha_maxima.ReadOnly = True
        Me.fecha_maxima.Width = 75
        '
        'obligatorio
        '
        Me.obligatorio.DataPropertyName = "obligatorio"
        Me.obligatorio.HeaderText = "obligatorio"
        Me.obligatorio.Name = "obligatorio"
        Me.obligatorio.ReadOnly = True
        Me.obligatorio.Width = 65
        '
        'chkFhaIni
        '
        '
        '
        '
        Me.chkFhaIni.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkFhaIni.Checked = True
        Me.chkFhaIni.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFhaIni.CheckValue = "Y"
        Me.chkFhaIni.Location = New System.Drawing.Point(10, 29)
        Me.chkFhaIni.Name = "chkFhaIni"
        Me.chkFhaIni.Size = New System.Drawing.Size(18, 23)
        Me.chkFhaIni.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkFhaIni.TabIndex = 147
        Me.chkFhaIni.TextVisible = False
        '
        'chkFhaMax
        '
        '
        '
        '
        Me.chkFhaMax.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkFhaMax.Checked = True
        Me.chkFhaMax.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFhaMax.CheckValue = "Y"
        Me.chkFhaMax.Location = New System.Drawing.Point(10, 65)
        Me.chkFhaMax.Name = "chkFhaMax"
        Me.chkFhaMax.Size = New System.Drawing.Size(18, 23)
        Me.chkFhaMax.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkFhaMax.TabIndex = 148
        Me.chkFhaMax.TextVisible = False
        '
        'frmPlaneacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1350, 729)
        Me.Controls.Add(Me.pnlRegistosVista)
        Me.Controls.Add(Me.EmpNav)
        Me.Controls.Add(Me.tabBuscar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPlaneacion"
        Me.Text = "Planeación"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBuscar.ResumeLayout(False)
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        CType(Me.sprTabPlaneacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sprTabPlaneacion.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.pnlDatosPlaneacion.ResumeLayout(False)
        Me.pnlDatosPlaneacion.PerformLayout()
        Me.pnlCriterio.ResumeLayout(False)
        Me.pnlCriterio.PerformLayout()
        Me.pnlObligatorio.ResumeLayout(False)
        Me.pnlObligatorio.PerformLayout()
        CType(Me.txtMeses, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConfiguracion.ResumeLayout(False)
        CType(Me.dgVistaPrevia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EmpNav.ResumeLayout(False)
        Me.pnlRegistosVista.ResumeLayout(False)
        Me.pnlRegistosVista.PerformLayout()
        CType(Me.dgCursosPlaneados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dtiMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtiInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents tabBuscar As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents pnlDatos As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnObligatorio As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tabEmpleado As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents dgTabla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents tabTabla As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents cmbMes As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbAno As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbCurso As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents txtMeses As DevComponents.Editors.IntegerInput
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents chkFecha As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkAlta As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents lblTematica As System.Windows.Forms.Label
    Friend WithEvents btnVerificar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCriterio As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtCriterio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents sprTabPlaneacion As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabConfiguracion As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents pnlConfiguracion As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents dgVistaPrevia As System.Windows.Forms.DataGridView
    Friend WithEvents tabVistaPrevia As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents EmpNav As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblEmpleados As System.Windows.Forms.Label
    Friend WithEvents bgw As System.ComponentModel.BackgroundWorker
    Friend WithEvents colReloj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFechaMaxima As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUsuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodCurso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombreCurso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colObligatorio As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents pnlDatosPlaneacion As System.Windows.Forms.Panel
    Friend WithEvents pnlObligatorio As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnlCriterio As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents pnlRegistosVista As System.Windows.Forms.Panel
    Friend WithEvents lblCursosPlaneados As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgCursosPlaneados As System.Windows.Forms.DataGridView
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnEliminaTodos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnEliminaSel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtiMax As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dtiInicio As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnEdita As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmbPlMes As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbPlAnio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents reloj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ano As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha_captura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha_maxima As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents obligatorio As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents chkFhaMax As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkFhaIni As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
