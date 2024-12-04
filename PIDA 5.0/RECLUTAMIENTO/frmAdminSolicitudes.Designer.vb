<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminSolicitudes
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdminSolicitudes))
        Me.vacante = New DevComponents.AdvTree.ColumnHeader()
        Me.cmbVacantes = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.cod_vac = New DevComponents.AdvTree.ColumnHeader()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.EmpNav = New System.Windows.Forms.GroupBox()
        Me.btnSolicitudes = New DevComponents.DotNetBar.ButtonX()
        Me.btnLayouts = New DevComponents.DotNetBar.ButtonX()
        Me.cmbStatus = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.dgSolicitudes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.gbBotones2 = New System.Windows.Forms.GroupBox()
        Me.btnLiberarPosiciones = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.folio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cod_vacc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVacante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colfhaApli = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Agencia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.solicitud = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.Layouts = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.Posicion = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.EntrevistaRHBuscar = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn()
        Me.EntrevistaRHAprobado = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.SupervisorBuscar = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn()
        Me.supervisorAprobado = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.medicoBuscar = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn()
        Me.medicoAprobado = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.RHBuscar = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn()
        Me.RHAprobado = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.Exportado = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.EmpNav.SuspendLayout()
        CType(Me.dgSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbBotones2.SuspendLayout()
        Me.SuspendLayout()
        '
        'vacante
        '
        Me.vacante.ColumnName = "vacante"
        Me.vacante.DataFieldName = "vacante"
        Me.vacante.Name = "vacante"
        Me.vacante.StretchToFill = True
        Me.vacante.Text = "Nombre vacante"
        Me.vacante.Width.Absolute = 150
        '
        'cmbVacantes
        '
        Me.cmbVacantes.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbVacantes.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbVacantes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbVacantes.ButtonDropDown.Visible = True
        Me.cmbVacantes.Columns.Add(Me.cod_vac)
        Me.cmbVacantes.Columns.Add(Me.vacante)
        Me.cmbVacantes.DisplayMembers = "cod_vac,vacante"
        Me.cmbVacantes.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbVacantes.Location = New System.Drawing.Point(92, 92)
        Me.cmbVacantes.Name = "cmbVacantes"
        Me.cmbVacantes.Size = New System.Drawing.Size(535, 20)
        Me.cmbVacantes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbVacantes.TabIndex = 172
        Me.cmbVacantes.ValueMember = "cod_vac"
        '
        'cod_vac
        '
        Me.cod_vac.ColumnName = "cod_vac"
        Me.cod_vac.DataFieldName = "cod_vac"
        Me.cod_vac.Name = "cod_vac"
        Me.cod_vac.Text = "Codigo"
        Me.cod_vac.Width.Absolute = 150
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 15)
        Me.Label3.TabIndex = 171
        Me.Label3.Text = "Vacantes"
        '
        'EmpNav
        '
        Me.EmpNav.Controls.Add(Me.btnSolicitudes)
        Me.EmpNav.Controls.Add(Me.btnLayouts)
        Me.EmpNav.Location = New System.Drawing.Point(394, 485)
        Me.EmpNav.Name = "EmpNav"
        Me.EmpNav.Size = New System.Drawing.Size(185, 47)
        Me.EmpNav.TabIndex = 170
        Me.EmpNav.TabStop = False
        '
        'btnSolicitudes
        '
        Me.btnSolicitudes.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSolicitudes.CausesValidation = False
        Me.btnSolicitudes.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSolicitudes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSolicitudes.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnSolicitudes.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnSolicitudes.Location = New System.Drawing.Point(6, 16)
        Me.btnSolicitudes.Name = "btnSolicitudes"
        Me.btnSolicitudes.Size = New System.Drawing.Size(87, 25)
        Me.btnSolicitudes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSolicitudes.SubItemsExpandWidth = 26
        Me.btnSolicitudes.TabIndex = 26
        Me.btnSolicitudes.Text = "Solicitudes"
        '
        'btnLayouts
        '
        Me.btnLayouts.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLayouts.CausesValidation = False
        Me.btnLayouts.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLayouts.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLayouts.Image = Global.PIDA.My.Resources.Resources.Export32
        Me.btnLayouts.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnLayouts.Location = New System.Drawing.Point(99, 16)
        Me.btnLayouts.Name = "btnLayouts"
        Me.btnLayouts.Size = New System.Drawing.Size(78, 25)
        Me.btnLayouts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLayouts.SubItemsExpandWidth = 26
        Me.btnLayouts.TabIndex = 22
        Me.btnLayouts.Text = "Layouts"
        '
        'cmbStatus
        '
        Me.cmbStatus.DisplayMember = "Text"
        Me.cmbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.ItemHeight = 14
        Me.cmbStatus.Location = New System.Drawing.Point(92, 118)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(104, 20)
        Me.cmbStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbStatus.TabIndex = 168
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(39, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 15)
        Me.Label2.TabIndex = 167
        Me.Label2.Text = "Status"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(64, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(387, 40)
        Me.ReflectionLabel1.TabIndex = 165
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>ADMINISTRACION DE SOLICITUDES" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "</b></font>"
        '
        'dgSolicitudes
        '
        Me.dgSolicitudes.AllowUserToAddRows = False
        Me.dgSolicitudes.AllowUserToDeleteRows = False
        Me.dgSolicitudes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSolicitudes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSolicitudes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSolicitudes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.folio, Me.cod_vacc, Me.colVacante, Me.colNombre, Me.colfhaApli, Me.Agencia, Me.solicitud, Me.Layouts, Me.Posicion, Me.EntrevistaRHBuscar, Me.EntrevistaRHAprobado, Me.SupervisorBuscar, Me.supervisorAprobado, Me.medicoBuscar, Me.medicoAprobado, Me.RHBuscar, Me.RHAprobado, Me.Exportado})
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSolicitudes.DefaultCellStyle = DataGridViewCellStyle23
        Me.dgSolicitudes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgSolicitudes.EnableHeadersVisualStyles = False
        Me.dgSolicitudes.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgSolicitudes.Location = New System.Drawing.Point(10, 144)
        Me.dgSolicitudes.Name = "dgSolicitudes"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSolicitudes.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
        Me.dgSolicitudes.RowHeadersWidth = 10
        Me.dgSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSolicitudes.Size = New System.Drawing.Size(1119, 335)
        Me.dgSolicitudes.TabIndex = 160
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.portfolio32
        Me.picImagen.InitialImage = Global.PIDA.My.Resources.Resources.portfolio32
        Me.picImagen.Location = New System.Drawing.Point(12, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(41, 40)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picImagen.TabIndex = 166
        Me.picImagen.TabStop = False
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Image = Global.PIDA.My.Resources.Resources.refresh16
        Me.ButtonX1.Location = New System.Drawing.Point(634, 92)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(31, 23)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 173
        '
        'gbBotones2
        '
        Me.gbBotones2.Controls.Add(Me.btnLiberarPosiciones)
        Me.gbBotones2.Controls.Add(Me.ButtonX2)
        Me.gbBotones2.Location = New System.Drawing.Point(637, 485)
        Me.gbBotones2.Name = "gbBotones2"
        Me.gbBotones2.Size = New System.Drawing.Size(336, 47)
        Me.gbBotones2.TabIndex = 175
        Me.gbBotones2.TabStop = False
        '
        'btnLiberarPosiciones
        '
        Me.btnLiberarPosiciones.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLiberarPosiciones.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLiberarPosiciones.Image = Global.PIDA.My.Resources.Resources.Edit
        Me.btnLiberarPosiciones.Location = New System.Drawing.Point(177, 17)
        Me.btnLiberarPosiciones.Name = "btnLiberarPosiciones"
        Me.btnLiberarPosiciones.Size = New System.Drawing.Size(144, 23)
        Me.btnLiberarPosiciones.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLiberarPosiciones.TabIndex = 1
        Me.btnLiberarPosiciones.Text = "Liberar Posiciones"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Image = Global.PIDA.My.Resources.Resources.Edit
        Me.ButtonX2.Location = New System.Drawing.Point(20, 17)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(144, 23)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 0
        Me.ButtonX2.Text = "Cargar datos auxiliares"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 60000
        '
        'folio
        '
        Me.folio.DataPropertyName = "folio"
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.folio.DefaultCellStyle = DataGridViewCellStyle14
        Me.folio.FillWeight = 13.94189!
        Me.folio.HeaderText = "Folio"
        Me.folio.MinimumWidth = 40
        Me.folio.Name = "folio"
        Me.folio.ReadOnly = True
        '
        'cod_vacc
        '
        Me.cod_vacc.DataPropertyName = "cod_vac"
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cod_vacc.DefaultCellStyle = DataGridViewCellStyle15
        Me.cod_vacc.FillWeight = 19.01736!
        Me.cod_vacc.HeaderText = "Codigo Vacante"
        Me.cod_vacc.MinimumWidth = 55
        Me.cod_vacc.Name = "cod_vacc"
        Me.cod_vacc.ReadOnly = True
        Me.cod_vacc.Visible = False
        '
        'colVacante
        '
        Me.colVacante.DataPropertyName = "vacante"
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colVacante.DefaultCellStyle = DataGridViewCellStyle16
        Me.colVacante.FillWeight = 19.01736!
        Me.colVacante.HeaderText = "Vacante"
        Me.colVacante.MinimumWidth = 60
        Me.colVacante.Name = "colVacante"
        Me.colVacante.ReadOnly = True
        Me.colVacante.Visible = False
        '
        'colNombre
        '
        Me.colNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colNombre.DataPropertyName = "nombre"
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colNombre.DefaultCellStyle = DataGridViewCellStyle17
        Me.colNombre.FillWeight = 58.56035!
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.MinimumWidth = 92
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        Me.colNombre.Width = 92
        '
        'colfhaApli
        '
        Me.colfhaApli.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colfhaApli.DataPropertyName = "fhaapli"
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colfhaApli.DefaultCellStyle = DataGridViewCellStyle18
        Me.colfhaApli.FillWeight = 17.75718!
        Me.colfhaApli.HeaderText = " Fecha solicitud"
        Me.colfhaApli.MinimumWidth = 60
        Me.colfhaApli.Name = "colfhaApli"
        Me.colfhaApli.ReadOnly = True
        Me.colfhaApli.Width = 107
        '
        'Agencia
        '
        Me.Agencia.DataPropertyName = "agencia"
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Agencia.DefaultCellStyle = DataGridViewCellStyle19
        Me.Agencia.HeaderText = "Agencia"
        Me.Agencia.MinimumWidth = 65
        Me.Agencia.Name = "Agencia"
        Me.Agencia.ReadOnly = True
        '
        'solicitud
        '
        Me.solicitud.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.solicitud.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Checked16
        Me.solicitud.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.Unckecked16
        Me.solicitud.Checked = True
        Me.solicitud.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.solicitud.CheckValue = "N"
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.solicitud.DefaultCellStyle = DataGridViewCellStyle20
        Me.solicitud.FillWeight = 19.01736!
        Me.solicitud.HeaderText = "Solicitud"
        Me.solicitud.MinimumWidth = 60
        Me.solicitud.Name = "solicitud"
        Me.solicitud.Width = 60
        '
        'Layouts
        '
        Me.Layouts.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Layouts.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Checked16
        Me.Layouts.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.Unckecked16
        Me.Layouts.Checked = True
        Me.Layouts.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Layouts.CheckValue = "N"
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Layouts.DefaultCellStyle = DataGridViewCellStyle21
        Me.Layouts.FillWeight = 19.01736!
        Me.Layouts.HeaderText = "Layouts"
        Me.Layouts.MinimumWidth = 45
        Me.Layouts.Name = "Layouts"
        Me.Layouts.Width = 55
        '
        'Posicion
        '
        Me.Posicion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Posicion.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Checked16
        Me.Posicion.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.Unckecked16
        Me.Posicion.Checked = True
        Me.Posicion.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Posicion.CheckValue = "N"
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Posicion.DefaultCellStyle = DataGridViewCellStyle22
        Me.Posicion.FillWeight = 20.0!
        Me.Posicion.HeaderText = "Posicion"
        Me.Posicion.MinimumWidth = 45
        Me.Posicion.Name = "Posicion"
        Me.Posicion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Posicion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Posicion.Width = 79
        '
        'EntrevistaRHBuscar
        '
        Me.EntrevistaRHBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.EntrevistaRHBuscar.HeaderText = "(Entrevista RH) Buscar"
        Me.EntrevistaRHBuscar.Image = CType(resources.GetObject("EntrevistaRHBuscar.Image"), System.Drawing.Image)
        Me.EntrevistaRHBuscar.MinimumWidth = 80
        Me.EntrevistaRHBuscar.Name = "EntrevistaRHBuscar"
        Me.EntrevistaRHBuscar.Text = Nothing
        '
        'EntrevistaRHAprobado
        '
        Me.EntrevistaRHAprobado.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.EntrevistaRHAprobado.CheckBoxImageIndeterminate = Global.PIDA.My.Resources.Resources.Knob_Pause
        Me.EntrevistaRHAprobado.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.CancelX
        Me.EntrevistaRHAprobado.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Bottom
        Me.EntrevistaRHAprobado.Checked = True
        Me.EntrevistaRHAprobado.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.EntrevistaRHAprobado.CheckValue = "N"
        Me.EntrevistaRHAprobado.DataPropertyName = "EntrevistaRHAprobado"
        Me.EntrevistaRHAprobado.HeaderText = "(Entrevista RH) Aprobado"
        Me.EntrevistaRHAprobado.MinimumWidth = 80
        Me.EntrevistaRHAprobado.Name = "EntrevistaRHAprobado"
        Me.EntrevistaRHAprobado.ReadOnly = True
        Me.EntrevistaRHAprobado.ThreeState = True
        '
        'SupervisorBuscar
        '
        Me.SupervisorBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.SupervisorBuscar.FillWeight = 19.01736!
        Me.SupervisorBuscar.HeaderText = "(Supervisor) Buscar"
        Me.SupervisorBuscar.Image = CType(resources.GetObject("SupervisorBuscar.Image"), System.Drawing.Image)
        Me.SupervisorBuscar.MinimumWidth = 80
        Me.SupervisorBuscar.Name = "SupervisorBuscar"
        Me.SupervisorBuscar.Text = Nothing
        '
        'supervisorAprobado
        '
        Me.supervisorAprobado.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.supervisorAprobado.CheckBoxImageIndeterminate = Global.PIDA.My.Resources.Resources.Knob_Pause
        Me.supervisorAprobado.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.CancelX
        Me.supervisorAprobado.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Bottom
        Me.supervisorAprobado.Checked = True
        Me.supervisorAprobado.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.supervisorAprobado.CheckValue = "N"
        Me.supervisorAprobado.DataPropertyName = "supervisorAprobado"
        Me.supervisorAprobado.FillWeight = 19.01736!
        Me.supervisorAprobado.HeaderText = "(Supervisor) Aprobado"
        Me.supervisorAprobado.MinimumWidth = 80
        Me.supervisorAprobado.Name = "supervisorAprobado"
        Me.supervisorAprobado.ReadOnly = True
        Me.supervisorAprobado.ThreeState = True
        '
        'medicoBuscar
        '
        Me.medicoBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.medicoBuscar.FillWeight = 19.01736!
        Me.medicoBuscar.HeaderText = "(Medico) Buscar"
        Me.medicoBuscar.Image = CType(resources.GetObject("medicoBuscar.Image"), System.Drawing.Image)
        Me.medicoBuscar.MinimumWidth = 80
        Me.medicoBuscar.Name = "medicoBuscar"
        Me.medicoBuscar.Text = Nothing
        '
        'medicoAprobado
        '
        Me.medicoAprobado.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.medicoAprobado.CheckBoxImageIndeterminate = Global.PIDA.My.Resources.Resources.Knob_Pause
        Me.medicoAprobado.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.CancelX
        Me.medicoAprobado.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Bottom
        Me.medicoAprobado.Checked = True
        Me.medicoAprobado.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.medicoAprobado.CheckValue = "N"
        Me.medicoAprobado.DataPropertyName = "medicoAprobado"
        Me.medicoAprobado.FillWeight = 19.01736!
        Me.medicoAprobado.HeaderText = "(Medico) Aprobado"
        Me.medicoAprobado.MinimumWidth = 80
        Me.medicoAprobado.Name = "medicoAprobado"
        Me.medicoAprobado.ReadOnly = True
        Me.medicoAprobado.ThreeState = True
        '
        'RHBuscar
        '
        Me.RHBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.RHBuscar.FillWeight = 18.5852!
        Me.RHBuscar.HeaderText = "(Alta RH) Buscar"
        Me.RHBuscar.Image = CType(resources.GetObject("RHBuscar.Image"), System.Drawing.Image)
        Me.RHBuscar.MinimumWidth = 80
        Me.RHBuscar.Name = "RHBuscar"
        Me.RHBuscar.Text = Nothing
        '
        'RHAprobado
        '
        Me.RHAprobado.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.RHAprobado.CheckBoxImageIndeterminate = Global.PIDA.My.Resources.Resources.Knob_Pause
        Me.RHAprobado.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.CancelX
        Me.RHAprobado.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Bottom
        Me.RHAprobado.Checked = True
        Me.RHAprobado.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.RHAprobado.CheckValue = "N"
        Me.RHAprobado.DataPropertyName = "RHAprobado"
        Me.RHAprobado.FillWeight = 28.53766!
        Me.RHAprobado.HeaderText = "(Alta RH) Aprobado"
        Me.RHAprobado.MinimumWidth = 80
        Me.RHAprobado.Name = "RHAprobado"
        Me.RHAprobado.ReadOnly = True
        Me.RHAprobado.ThreeState = True
        '
        'Exportado
        '
        Me.Exportado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Exportado.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.Exportado.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.empty_16
        Me.Exportado.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Bottom
        Me.Exportado.Checked = True
        Me.Exportado.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Exportado.CheckValue = "N"
        Me.Exportado.DataPropertyName = "layout"
        Me.Exportado.FillWeight = 46.46299!
        Me.Exportado.HeaderText = "Exportado"
        Me.Exportado.MinimumWidth = 65
        Me.Exportado.Name = "Exportado"
        Me.Exportado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Exportado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Exportado.Width = 88
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnReporte.Location = New System.Drawing.Point(1048, 500)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 176
        Me.btnReporte.Text = "Reporte"
        '
        'frmAdminSolicitudes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1138, 535)
        Me.Controls.Add(Me.btnReporte)
        Me.Controls.Add(Me.gbBotones2)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.cmbVacantes)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.EmpNav)
        Me.Controls.Add(Me.cmbStatus)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.picImagen)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.dgSolicitudes)
        Me.Name = "frmAdminSolicitudes"
        Me.Text = "Admin Solicitudes"
        Me.EmpNav.ResumeLayout(False)
        CType(Me.dgSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbBotones2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents vacante As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents cmbVacantes As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cod_vac As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnLayouts As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EmpNav As System.Windows.Forms.GroupBox
    Friend WithEvents cmbStatus As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents dgSolicitudes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnSolicitudes As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents gbBotones2 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnLiberarPosiciones As DevComponents.DotNetBar.ButtonX
    Friend WithEvents folio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cod_vacc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVacante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colfhaApli As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Agencia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents solicitud As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents Layouts As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents Posicion As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents EntrevistaRHBuscar As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents EntrevistaRHAprobado As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents SupervisorBuscar As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents supervisorAprobado As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents medicoBuscar As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents medicoAprobado As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents RHBuscar As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents RHAprobado As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents Exportado As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
End Class
