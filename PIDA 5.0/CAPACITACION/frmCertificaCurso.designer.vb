<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCertificaCurso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCertificaCurso))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.sprTabPlaneacion = New DevComponents.DotNetBar.SuperTabControl()
        Me.tabVistaPrevia = New DevComponents.DotNetBar.SuperTabItem()
        Me.cmbMes = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.cmbAno = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.cmbCurso = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tabTabla = New DevComponents.DotNetBar.SuperTabItem()
        Me.EmpNav = New System.Windows.Forms.GroupBox()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.bgw = New System.ComponentModel.BackgroundWorker()
        Me.pnlDatosCertificacion = New System.Windows.Forms.Panel()
        Me.lblAlta = New System.Windows.Forms.Label()
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgCursosEmp = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.btnCertificar = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblNombre = New DevComponents.DotNetBar.LabelX()
        Me.lblCerti = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cl_reloj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_puesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_certi = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.cl_alta = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sprTabPlaneacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EmpNav.SuspendLayout()
        Me.pnlDatosCertificacion.SuspendLayout()
        CType(Me.dgCursosEmp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        Me.ReflectionLabel1.Size = New System.Drawing.Size(343, 40)
        Me.ReflectionLabel1.TabIndex = 80
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CERTIFICACION DE EMPLEADO</b></font>"
        '
        'sprTabPlaneacion
        '
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
        Me.sprTabPlaneacion.Location = New System.Drawing.Point(14, 75)
        Me.sprTabPlaneacion.Name = "sprTabPlaneacion"
        Me.sprTabPlaneacion.ReorderTabsEnabled = True
        Me.sprTabPlaneacion.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
        Me.sprTabPlaneacion.SelectedTabIndex = 0
        Me.sprTabPlaneacion.Size = New System.Drawing.Size(457, 287)
        Me.sprTabPlaneacion.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sprTabPlaneacion.TabIndex = 3
        Me.sprTabPlaneacion.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit
        Me.sprTabPlaneacion.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        '
        'tabVistaPrevia
        '
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
        Me.cmbMes.Location = New System.Drawing.Point(307, 49)
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
        Me.cmbAno.Location = New System.Drawing.Point(93, 49)
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
        Me.cmbCurso.Location = New System.Drawing.Point(93, 20)
        Me.cmbCurso.Name = "cmbCurso"
        Me.cmbCurso.Size = New System.Drawing.Size(371, 23)
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
        Me.Label4.Location = New System.Drawing.Point(251, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 15)
        Me.Label4.TabIndex = 86
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 15)
        Me.Label1.TabIndex = 80
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 15)
        Me.Label2.TabIndex = 54
        '
        'tabTabla
        '
        Me.tabTabla.GlobalItem = False
        Me.tabTabla.Name = "tabTabla"
        Me.tabTabla.Text = "Cursos programados"
        '
        'EmpNav
        '
        Me.EmpNav.Controls.Add(Me.btnCancelar)
        Me.EmpNav.Location = New System.Drawing.Point(515, 446)
        Me.EmpNav.Name = "EmpNav"
        Me.EmpNav.Size = New System.Drawing.Size(95, 47)
        Me.EmpNav.TabIndex = 83
        Me.EmpNav.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCancelar.Location = New System.Drawing.Point(9, 13)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(76, 25)
        Me.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "Cancelar"
        '
        'pnlDatosCertificacion
        '
        Me.pnlDatosCertificacion.BackColor = System.Drawing.Color.Silver
        Me.pnlDatosCertificacion.Controls.Add(Me.lblCerti)
        Me.pnlDatosCertificacion.Controls.Add(Me.Label5)
        Me.pnlDatosCertificacion.Controls.Add(Me.lblAlta)
        Me.pnlDatosCertificacion.Controls.Add(Me.ReflectionImage1)
        Me.pnlDatosCertificacion.Controls.Add(Me.Label9)
        Me.pnlDatosCertificacion.Controls.Add(Me.Label6)
        Me.pnlDatosCertificacion.Location = New System.Drawing.Point(174, 87)
        Me.pnlDatosCertificacion.Name = "pnlDatosCertificacion"
        Me.pnlDatosCertificacion.Size = New System.Drawing.Size(435, 93)
        Me.pnlDatosCertificacion.TabIndex = 179
        '
        'lblAlta
        '
        Me.lblAlta.AutoSize = True
        Me.lblAlta.BackColor = System.Drawing.Color.Transparent
        Me.lblAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlta.ForeColor = System.Drawing.Color.White
        Me.lblAlta.Location = New System.Drawing.Point(216, 35)
        Me.lblAlta.Name = "lblAlta"
        Me.lblAlta.Size = New System.Drawing.Size(64, 15)
        Me.lblAlta.TabIndex = 181
        Me.lblAlta.Text = "Fecha alta"
        '
        'ReflectionImage1
        '
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage1.Dock = System.Windows.Forms.DockStyle.Right
        Me.ReflectionImage1.Image = Global.PIDA.My.Resources.Resources.Award32
        Me.ReflectionImage1.Location = New System.Drawing.Point(377, 22)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(58, 71)
        Me.ReflectionImage1.TabIndex = 179
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Gray
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(0, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(435, 22)
        Me.Label9.TabIndex = 178
        Me.Label9.Text = "ESTATUS: NO CERTIFICADO"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(119, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 15)
        Me.Label6.TabIndex = 163
        Me.Label6.Text = "Fecha alta:"
        '
        'dgCursosEmp
        '
        Me.dgCursosEmp.AllowUserToAddRows = False
        Me.dgCursosEmp.AllowUserToDeleteRows = False
        Me.dgCursosEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCursosEmp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cl_reloj, Me.cl_nombre, Me.cl_puesto, Me.cl_certi, Me.cl_alta})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCursosEmp.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgCursosEmp.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgCursosEmp.Location = New System.Drawing.Point(12, 238)
        Me.dgCursosEmp.Name = "dgCursosEmp"
        Me.dgCursosEmp.ReadOnly = True
        Me.dgCursosEmp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCursosEmp.Size = New System.Drawing.Size(597, 202)
        Me.dgCursosEmp.TabIndex = 180
        '
        'btnCertificar
        '
        Me.btnCertificar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCertificar.CausesValidation = False
        Me.btnCertificar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCertificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCertificar.Image = Global.PIDA.My.Resources.Resources.Award32
        Me.btnCertificar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnCertificar.Location = New System.Drawing.Point(30, 87)
        Me.btnCertificar.Name = "btnCertificar"
        Me.btnCertificar.Size = New System.Drawing.Size(125, 93)
        Me.btnCertificar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCertificar.TabIndex = 180
        Me.btnCertificar.Text = "Certificar"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(12, 58)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(143, 23)
        Me.LabelX1.TabIndex = 181
        Me.LabelX1.Text = "Empleado seleccionado:"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(12, 209)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(222, 23)
        Me.LabelX2.TabIndex = 182
        Me.LabelX2.Text = "Vista previa de empleados certificados"
        '
        'Line1
        '
        Me.Line1.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Line1.Location = New System.Drawing.Point(12, 186)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(597, 23)
        Me.Line1.TabIndex = 183
        Me.Line1.Text = "Line1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LabelX4)
        Me.GroupBox1.Controls.Add(Me.txtReloj)
        Me.GroupBox1.Location = New System.Drawing.Point(438, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(171, 41)
        Me.GroupBox1.TabIndex = 184
        Me.GroupBox1.TabStop = False
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
        Me.txtReloj.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.DisabledBackColor = System.Drawing.Color.White
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.Location = New System.Drawing.Point(82, 10)
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.ReadOnly = True
        Me.txtReloj.Size = New System.Drawing.Size(84, 26)
        Me.txtReloj.TabIndex = 0
        Me.txtReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNombre
        '
        '
        '
        '
        Me.lblNombre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(161, 58)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(449, 23)
        Me.lblNombre.TabIndex = 185
        Me.lblNombre.Text = "Curso"
        '
        'lblCerti
        '
        Me.lblCerti.AutoSize = True
        Me.lblCerti.BackColor = System.Drawing.Color.Transparent
        Me.lblCerti.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCerti.ForeColor = System.Drawing.Color.White
        Me.lblCerti.Location = New System.Drawing.Point(216, 62)
        Me.lblCerti.Name = "lblCerti"
        Me.lblCerti.Size = New System.Drawing.Size(67, 15)
        Me.lblCerti.TabIndex = 183
        Me.lblCerti.Text = "Fecha certi"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(65, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 15)
        Me.Label5.TabIndex = 182
        Me.Label5.Text = "Fecha certificación:"
        '
        'cl_reloj
        '
        Me.cl_reloj.DataPropertyName = "reloj"
        Me.cl_reloj.HeaderText = "Reloj"
        Me.cl_reloj.Name = "cl_reloj"
        Me.cl_reloj.ReadOnly = True
        Me.cl_reloj.Width = 80
        '
        'cl_nombre
        '
        Me.cl_nombre.DataPropertyName = "NOMBRES"
        Me.cl_nombre.HeaderText = "Nombre"
        Me.cl_nombre.Name = "cl_nombre"
        Me.cl_nombre.ReadOnly = True
        Me.cl_nombre.Width = 240
        '
        'cl_puesto
        '
        Me.cl_puesto.DataPropertyName = "cod_puesto"
        Me.cl_puesto.HeaderText = "Puesto"
        Me.cl_puesto.Name = "cl_puesto"
        Me.cl_puesto.ReadOnly = True
        Me.cl_puesto.Width = 60
        '
        'cl_certi
        '
        '
        '
        '
        Me.cl_certi.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.cl_certi.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cl_certi.DataPropertyName = "inicio"
        Me.cl_certi.HeaderText = "Certificacion"
        Me.cl_certi.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.cl_certi.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.cl_certi.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cl_certi.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.cl_certi.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cl_certi.MonthCalendar.DisplayMonth = New Date(2021, 7, 1, 0, 0, 0, 0)
        Me.cl_certi.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.cl_certi.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.cl_certi.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cl_certi.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.cl_certi.Name = "cl_certi"
        Me.cl_certi.ReadOnly = True
        '
        'cl_alta
        '
        '
        '
        '
        Me.cl_alta.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.cl_alta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cl_alta.DataPropertyName = "alta"
        Me.cl_alta.HeaderText = "Alta"
        Me.cl_alta.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.cl_alta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.cl_alta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cl_alta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.cl_alta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cl_alta.MonthCalendar.DisplayMonth = New Date(2021, 7, 1, 0, 0, 0, 0)
        Me.cl_alta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.cl_alta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.cl_alta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cl_alta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.cl_alta.Name = "cl_alta"
        Me.cl_alta.ReadOnly = True
        Me.cl_alta.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cl_alta.Width = 80
        '
        'frmCertificaCurso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 501)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCertificar)
        Me.Controls.Add(Me.Line1)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.dgCursosEmp)
        Me.Controls.Add(Me.pnlDatosCertificacion)
        Me.Controls.Add(Me.EmpNav)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCertificaCurso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Certificación de empleado"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sprTabPlaneacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EmpNav.ResumeLayout(False)
        Me.pnlDatosCertificacion.ResumeLayout(False)
        Me.pnlDatosCertificacion.PerformLayout()
        CType(Me.dgCursosEmp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tabTabla As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents cmbMes As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbAno As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbCurso As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents sprTabPlaneacion As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents tabVistaPrevia As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents EmpNav As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents bgw As System.ComponentModel.BackgroundWorker
    Friend WithEvents pnlDatosCertificacion As System.Windows.Forms.Panel
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgCursosEmp As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnCertificar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblAlta As System.Windows.Forms.Label
    Friend WithEvents lblNombre As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCerti As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cl_reloj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cl_nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cl_puesto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cl_certi As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents cl_alta As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
End Class
