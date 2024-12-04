<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAjustesProcesoNom
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAjustesProcesoNom))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.gpConsultaReg = New System.Windows.Forms.GroupBox()
        Me.chkSQL = New System.Windows.Forms.CheckBox()
        Me.chkArchivoLocal = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnLocRutaResp = New DevComponents.DotNetBar.ButtonX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRutaResp = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnLocRuta = New DevComponents.DotNetBar.ButtonX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtArchivoProc = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgvResp = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Año = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Periodo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Version = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Seleccionar = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.chkRespaldos = New System.Windows.Forms.CheckBox()
        Me.btnElimina = New System.Windows.Forms.Button()
        Me.gpDatosPeriodo = New System.Windows.Forms.GroupBox()
        Me.cmbPer = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbAno = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.rbQ = New System.Windows.Forms.RadioButton()
        Me.rbS = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkMarcar = New System.Windows.Forms.CheckBox()
        Me.dgvReportes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Reporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estatus = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.gpConsultaReg.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvResp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpDatosPeriodo.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvReportes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(526, 383)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.gpConsultaReg)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(518, 357)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Opciones generales"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'gpConsultaReg
        '
        Me.gpConsultaReg.Controls.Add(Me.chkSQL)
        Me.gpConsultaReg.Controls.Add(Me.chkArchivoLocal)
        Me.gpConsultaReg.Controls.Add(Me.Label3)
        Me.gpConsultaReg.Controls.Add(Me.btnLocRutaResp)
        Me.gpConsultaReg.Controls.Add(Me.Label2)
        Me.gpConsultaReg.Controls.Add(Me.txtRutaResp)
        Me.gpConsultaReg.Controls.Add(Me.btnLocRuta)
        Me.gpConsultaReg.Controls.Add(Me.Label1)
        Me.gpConsultaReg.Controls.Add(Me.txtArchivoProc)
        Me.gpConsultaReg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpConsultaReg.Location = New System.Drawing.Point(17, 19)
        Me.gpConsultaReg.Name = "gpConsultaReg"
        Me.gpConsultaReg.Size = New System.Drawing.Size(478, 222)
        Me.gpConsultaReg.TabIndex = 263
        Me.gpConsultaReg.TabStop = False
        Me.gpConsultaReg.Text = "Rutas"
        '
        'chkSQL
        '
        Me.chkSQL.AutoSize = True
        Me.chkSQL.Enabled = False
        Me.chkSQL.Location = New System.Drawing.Point(243, 182)
        Me.chkSQL.Name = "chkSQL"
        Me.chkSQL.Size = New System.Drawing.Size(47, 17)
        Me.chkSQL.TabIndex = 268
        Me.chkSQL.Text = "SQL"
        Me.chkSQL.UseVisualStyleBackColor = True
        Me.chkSQL.Visible = False
        '
        'chkArchivoLocal
        '
        Me.chkArchivoLocal.AutoSize = True
        Me.chkArchivoLocal.Checked = True
        Me.chkArchivoLocal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkArchivoLocal.Enabled = False
        Me.chkArchivoLocal.Location = New System.Drawing.Point(130, 182)
        Me.chkArchivoLocal.Name = "chkArchivoLocal"
        Me.chkArchivoLocal.Size = New System.Drawing.Size(87, 17)
        Me.chkArchivoLocal.TabIndex = 267
        Me.chkArchivoLocal.Text = "Archivo local"
        Me.chkArchivoLocal.UseVisualStyleBackColor = True
        Me.chkArchivoLocal.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(16, 183)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 266
        Me.Label3.Text = "Modo de respaldo"
        Me.Label3.Visible = False
        '
        'btnLocRutaResp
        '
        Me.btnLocRutaResp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLocRutaResp.CausesValidation = False
        Me.btnLocRutaResp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLocRutaResp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLocRutaResp.Image = Global.PIDA.My.Resources.Resources.search24
        Me.btnLocRutaResp.ImageFixedSize = New System.Drawing.Size(15, 15)
        Me.btnLocRutaResp.Location = New System.Drawing.Point(435, 108)
        Me.btnLocRutaResp.Name = "btnLocRutaResp"
        Me.btnLocRutaResp.Size = New System.Drawing.Size(25, 20)
        Me.btnLocRutaResp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLocRutaResp.SubItemsExpandWidth = 15
        Me.btnLocRutaResp.TabIndex = 264
        Me.btnLocRutaResp.Tooltip = "Inicializar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 263
        Me.Label2.Text = "Ruta respaldos"
        '
        'txtRutaResp
        '
        '
        '
        '
        Me.txtRutaResp.Border.Class = "TextBoxBorder"
        Me.txtRutaResp.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRutaResp.Location = New System.Drawing.Point(131, 108)
        Me.txtRutaResp.MaxLength = 6
        Me.txtRutaResp.Multiline = True
        Me.txtRutaResp.Name = "txtRutaResp"
        Me.txtRutaResp.PreventEnterBeep = True
        Me.txtRutaResp.ReadOnly = True
        Me.txtRutaResp.Size = New System.Drawing.Size(287, 60)
        Me.txtRutaResp.TabIndex = 262
        '
        'btnLocRuta
        '
        Me.btnLocRuta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLocRuta.CausesValidation = False
        Me.btnLocRuta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLocRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLocRuta.Image = Global.PIDA.My.Resources.Resources.search24
        Me.btnLocRuta.ImageFixedSize = New System.Drawing.Size(15, 15)
        Me.btnLocRuta.Location = New System.Drawing.Point(435, 32)
        Me.btnLocRuta.Name = "btnLocRuta"
        Me.btnLocRuta.Size = New System.Drawing.Size(25, 20)
        Me.btnLocRuta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLocRuta.SubItemsExpandWidth = 15
        Me.btnLocRuta.TabIndex = 261
        Me.btnLocRuta.Tooltip = "Inicializar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 260
        Me.Label1.Text = "Ruta proceso activo"
        '
        'txtArchivoProc
        '
        '
        '
        '
        Me.txtArchivoProc.Border.Class = "TextBoxBorder"
        Me.txtArchivoProc.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtArchivoProc.Location = New System.Drawing.Point(131, 32)
        Me.txtArchivoProc.MaxLength = 6
        Me.txtArchivoProc.Multiline = True
        Me.txtArchivoProc.Name = "txtArchivoProc"
        Me.txtArchivoProc.PreventEnterBeep = True
        Me.txtArchivoProc.ReadOnly = True
        Me.txtArchivoProc.Size = New System.Drawing.Size(287, 60)
        Me.txtArchivoProc.TabIndex = 259
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox3)
        Me.TabPage4.Controls.Add(Me.gpDatosPeriodo)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(518, 357)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Respaldos"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgvResp)
        Me.GroupBox3.Controls.Add(Me.chkRespaldos)
        Me.GroupBox3.Controls.Add(Me.btnElimina)
        Me.GroupBox3.Location = New System.Drawing.Point(17, 102)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(479, 242)
        Me.GroupBox3.TabIndex = 266
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Lista respaldos"
        '
        'dgvResp
        '
        Me.dgvResp.AllowUserToAddRows = False
        Me.dgvResp.AllowUserToDeleteRows = False
        Me.dgvResp.AllowUserToResizeColumns = False
        Me.dgvResp.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvResp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvResp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Año, Me.Periodo, Me.Tipo, Me.Version, Me.Fecha, Me.Seleccionar})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvResp.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvResp.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvResp.EnableHeadersVisualStyles = False
        Me.dgvResp.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvResp.Location = New System.Drawing.Point(3, 71)
        Me.dgvResp.Name = "dgvResp"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvResp.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvResp.RowHeadersVisible = False
        Me.dgvResp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvResp.Size = New System.Drawing.Size(473, 168)
        Me.dgvResp.TabIndex = 257
        '
        'ID
        '
        Me.ID.DataPropertyName = "id"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        Me.ID.Width = 20
        '
        'Año
        '
        Me.Año.DataPropertyName = "ano"
        Me.Año.HeaderText = "Año"
        Me.Año.Name = "Año"
        Me.Año.ReadOnly = True
        Me.Año.Width = 50
        '
        'Periodo
        '
        Me.Periodo.DataPropertyName = "periodo"
        Me.Periodo.HeaderText = "Periodo"
        Me.Periodo.Name = "Periodo"
        Me.Periodo.ReadOnly = True
        Me.Periodo.Width = 50
        '
        'Tipo
        '
        Me.Tipo.DataPropertyName = "tipo_periodo"
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Width = 35
        '
        'Version
        '
        Me.Version.DataPropertyName = "version"
        Me.Version.HeaderText = "Version"
        Me.Version.Name = "Version"
        Me.Version.ReadOnly = True
        Me.Version.Width = 45
        '
        'Fecha
        '
        Me.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Fecha.DataPropertyName = "datetime"
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        '
        'Seleccionar
        '
        Me.Seleccionar.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.l_ocupado
        Me.Seleccionar.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.l_disponible
        Me.Seleccionar.Checked = True
        Me.Seleccionar.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Seleccionar.CheckValue = "N"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Seleccionar.DefaultCellStyle = DataGridViewCellStyle2
        Me.Seleccionar.HeaderText = "Seleccionar"
        Me.Seleccionar.Name = "Seleccionar"
        '
        'chkRespaldos
        '
        Me.chkRespaldos.AutoSize = True
        Me.chkRespaldos.Location = New System.Drawing.Point(16, 35)
        Me.chkRespaldos.Name = "chkRespaldos"
        Me.chkRespaldos.Size = New System.Drawing.Size(88, 17)
        Me.chkRespaldos.TabIndex = 256
        Me.chkRespaldos.Text = "Marcar todos"
        Me.chkRespaldos.UseVisualStyleBackColor = True
        '
        'btnElimina
        '
        Me.btnElimina.Location = New System.Drawing.Point(364, 29)
        Me.btnElimina.Name = "btnElimina"
        Me.btnElimina.Size = New System.Drawing.Size(99, 23)
        Me.btnElimina.TabIndex = 253
        Me.btnElimina.Text = "Eliminar selección"
        Me.btnElimina.UseVisualStyleBackColor = True
        '
        'gpDatosPeriodo
        '
        Me.gpDatosPeriodo.Controls.Add(Me.cmbPer)
        Me.gpDatosPeriodo.Controls.Add(Me.Label5)
        Me.gpDatosPeriodo.Controls.Add(Me.cmbAno)
        Me.gpDatosPeriodo.Controls.Add(Me.rbQ)
        Me.gpDatosPeriodo.Controls.Add(Me.rbS)
        Me.gpDatosPeriodo.Controls.Add(Me.Label4)
        Me.gpDatosPeriodo.Location = New System.Drawing.Point(17, 19)
        Me.gpDatosPeriodo.Name = "gpDatosPeriodo"
        Me.gpDatosPeriodo.Size = New System.Drawing.Size(479, 77)
        Me.gpDatosPeriodo.TabIndex = 265
        Me.gpDatosPeriodo.TabStop = False
        Me.gpDatosPeriodo.Text = "Datos de periodo"
        '
        'cmbPer
        '
        Me.cmbPer.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPer.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPer.ButtonDropDown.Visible = True
        Me.cmbPer.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPer.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPer.Location = New System.Drawing.Point(207, 34)
        Me.cmbPer.Name = "cmbPer"
        Me.cmbPer.Size = New System.Drawing.Size(83, 20)
        Me.cmbPer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPer.TabIndex = 250
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(151, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 251
        Me.Label5.Text = "Periodo"
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
        Me.cmbAno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAno.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbAno.Location = New System.Drawing.Point(52, 34)
        Me.cmbAno.Name = "cmbAno"
        Me.cmbAno.Size = New System.Drawing.Size(83, 20)
        Me.cmbAno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbAno.TabIndex = 245
        '
        'rbQ
        '
        Me.rbQ.AutoSize = True
        Me.rbQ.Enabled = False
        Me.rbQ.Location = New System.Drawing.Point(390, 35)
        Me.rbQ.Name = "rbQ"
        Me.rbQ.Size = New System.Drawing.Size(73, 17)
        Me.rbQ.TabIndex = 235
        Me.rbQ.Text = "Quincenal"
        Me.rbQ.UseVisualStyleBackColor = True
        Me.rbQ.Visible = False
        '
        'rbS
        '
        Me.rbS.AutoSize = True
        Me.rbS.Checked = True
        Me.rbS.Enabled = False
        Me.rbS.Location = New System.Drawing.Point(318, 35)
        Me.rbS.Name = "rbS"
        Me.rbS.Size = New System.Drawing.Size(66, 17)
        Me.rbS.TabIndex = 236
        Me.rbS.TabStop = True
        Me.rbS.Text = "Semanal"
        Me.rbS.UseVisualStyleBackColor = True
        Me.rbS.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(26, 13)
        Me.Label4.TabIndex = 249
        Me.Label4.Text = "Año"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(518, 357)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Reportes prenómina"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkMarcar)
        Me.GroupBox1.Controls.Add(Me.dgvReportes)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(479, 325)
        Me.GroupBox1.TabIndex = 266
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Lista reportes"
        '
        'chkMarcar
        '
        Me.chkMarcar.AutoSize = True
        Me.chkMarcar.Checked = True
        Me.chkMarcar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMarcar.Location = New System.Drawing.Point(376, 19)
        Me.chkMarcar.Name = "chkMarcar"
        Me.chkMarcar.Size = New System.Drawing.Size(88, 17)
        Me.chkMarcar.TabIndex = 255
        Me.chkMarcar.Text = "Marcar todos"
        Me.chkMarcar.UseVisualStyleBackColor = True
        '
        'dgvReportes
        '
        Me.dgvReportes.AllowUserToAddRows = False
        Me.dgvReportes.AllowUserToDeleteRows = False
        Me.dgvReportes.AllowUserToOrderColumns = True
        Me.dgvReportes.AllowUserToResizeColumns = False
        Me.dgvReportes.AllowUserToResizeRows = False
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReportes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReportes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Reporte, Me.Estatus})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReportes.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvReportes.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgvReportes.EnableHeadersVisualStyles = False
        Me.dgvReportes.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvReportes.Location = New System.Drawing.Point(3, 53)
        Me.dgvReportes.Name = "dgvReportes"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReportes.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvReportes.RowHeadersVisible = False
        Me.dgvReportes.Size = New System.Drawing.Size(473, 269)
        Me.dgvReportes.TabIndex = 254
        '
        'Reporte
        '
        Me.Reporte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Reporte.DataPropertyName = "variable"
        Me.Reporte.HeaderText = "Reporte"
        Me.Reporte.Name = "Reporte"
        Me.Reporte.ReadOnly = True
        '
        'Estatus
        '
        Me.Estatus.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.l_ocupado
        Me.Estatus.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.l_cancelado
        Me.Estatus.Checked = True
        Me.Estatus.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Estatus.CheckValue = "N"
        Me.Estatus.CheckValueChecked = "1"
        Me.Estatus.CheckValueUnchecked = "0"
        Me.Estatus.DataPropertyName = "valor"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Estatus.DefaultCellStyle = DataGridViewCellStyle6
        Me.Estatus.HeaderText = "Estatus"
        Me.Estatus.Name = "Estatus"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.ImageFixedSize = New System.Drawing.Size(15, 15)
        Me.btnAceptar.ImageTextSpacing = 5
        Me.btnAceptar.Location = New System.Drawing.Point(434, 414)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(100, 25)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 258
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.Tooltip = "Se generan un vez realizado el cálculo"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.ImageFixedSize = New System.Drawing.Size(15, 15)
        Me.btnCancelar.ImageTextSpacing = 5
        Me.btnCancelar.Location = New System.Drawing.Point(328, 414)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 25)
        Me.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancelar.TabIndex = 259
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.Tooltip = "Se generan un vez realizado el cálculo"
        '
        'frmAjustesProcesoNom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 451)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAjustesProcesoNom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ajustes generales"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.gpConsultaReg.ResumeLayout(False)
        Me.gpConsultaReg.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvResp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpDatosPeriodo.ResumeLayout(False)
        Me.gpDatosPeriodo.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvReportes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents gpConsultaReg As System.Windows.Forms.GroupBox
    Friend WithEvents txtArchivoProc As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnLocRutaResp As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRutaResp As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnLocRuta As DevComponents.DotNetBar.ButtonX
    Friend WithEvents chkSQL As System.Windows.Forms.CheckBox
    Friend WithEvents chkArchivoLocal As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents gpDatosPeriodo As System.Windows.Forms.GroupBox
    Friend WithEvents cmbPer As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbAno As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents rbQ As System.Windows.Forms.RadioButton
    Friend WithEvents rbS As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnElimina As System.Windows.Forms.Button
    Friend WithEvents dgvReportes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents chkMarcar As System.Windows.Forms.CheckBox
    Friend WithEvents Reporte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estatus As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents chkRespaldos As System.Windows.Forms.CheckBox
    Friend WithEvents dgvResp As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Año As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Periodo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Version As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Seleccionar As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
End Class
