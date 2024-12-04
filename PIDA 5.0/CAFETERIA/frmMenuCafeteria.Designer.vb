<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenuCafeteria
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenuCafeteria))
        Me.CodCia = New DevComponents.AdvTree.ColumnHeader()
        Me.CodTurno = New DevComponents.AdvTree.ColumnHeader()
        Me.NombreTurno = New DevComponents.AdvTree.ColumnHeader()
        Me.HorasTurno = New DevComponents.AdvTree.ColumnHeader()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgTabla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.tabTabla = New DevComponents.DotNetBar.SuperTabItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tabBuscar = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.txtServiciodef = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnQuitarD = New DevComponents.DotNetBar.ButtonX()
        Me.btnCambiarD = New DevComponents.DotNetBar.ButtonX()
        Me.picDefault = New System.Windows.Forms.PictureBox()
        Me.txtdescdefa = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNombredef = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtcoddef = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.tabDefault = New DevComponents.DotNetBar.SuperTabItem()
        Me.pnlDatos = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.btnQuitarFoto = New DevComponents.DotNetBar.ButtonX()
        Me.btnCambiarFoto = New DevComponents.DotNetBar.ButtonX()
        Me.pctFotoMenu = New System.Windows.Forms.PictureBox()
        Me.txtDescripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cmbServicio = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.tabEmpleado = New DevComponents.DotNetBar.SuperTabItem()
        Me.CodTurnocol = New DevComponents.AdvTree.ColumnHeader()
        Me.NomTurnoCol = New DevComponents.AdvTree.ColumnHeader()
        Me.EmpNav = New System.Windows.Forms.GroupBox()
        Me.pnlControles = New System.Windows.Forms.Panel()
        Me.btnPrimero = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAnterior = New DevComponents.DotNetBar.ButtonX()
        Me.btnUltimo = New DevComponents.DotNetBar.ButtonX()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnSiguiente = New DevComponents.DotNetBar.ButtonX()
        Me.NombreCia = New DevComponents.AdvTree.ColumnHeader()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBuscar.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        CType(Me.picDefault, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatos.SuspendLayout()
        CType(Me.pctFotoMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EmpNav.SuspendLayout()
        Me.pnlControles.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CodCia
        '
        Me.CodCia.DataFieldName = "cod_comp"
        Me.CodCia.Name = "CodCia"
        Me.CodCia.Text = "Código"
        Me.CodCia.Width.Absolute = 60
        '
        'CodTurno
        '
        Me.CodTurno.DataFieldName = "cod_turno"
        Me.CodTurno.Name = "CodTurno"
        Me.CodTurno.Text = "Código"
        Me.CodTurno.Width.Absolute = 60
        '
        'NombreTurno
        '
        Me.NombreTurno.DataFieldName = "Nombre"
        Me.NombreTurno.Name = "NombreTurno"
        Me.NombreTurno.Text = "Nombre"
        Me.NombreTurno.Width.Absolute = 150
        '
        'HorasTurno
        '
        Me.HorasTurno.DataFieldName = "horas"
        Me.HorasTurno.Name = "HorasTurno"
        Me.HorasTurno.StretchToFill = True
        Me.HorasTurno.Text = "Horas"
        Me.HorasTurno.Width.Absolute = 150
        Me.HorasTurno.Width.AutoSize = True
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.dgTabla)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(869, 417)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.tabTabla
        '
        'dgTabla
        '
        Me.dgTabla.AllowUserToAddRows = False
        Me.dgTabla.AllowUserToDeleteRows = False
        Me.dgTabla.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTabla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTabla.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgTabla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTabla.EnableHeadersVisualStyles = False
        Me.dgTabla.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgTabla.Location = New System.Drawing.Point(0, 0)
        Me.dgTabla.MultiSelect = False
        Me.dgTabla.Name = "dgTabla"
        Me.dgTabla.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTabla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgTabla.Size = New System.Drawing.Size(869, 417)
        Me.dgTabla.TabIndex = 1
        '
        'tabTabla
        '
        Me.tabTabla.AttachedControl = Me.SuperTabControlPanel2
        Me.tabTabla.GlobalItem = False
        Me.tabTabla.Name = "tabTabla"
        Me.tabTabla.Text = "Lista"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.tabBuscar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 55)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(12)
        Me.Panel2.Size = New System.Drawing.Size(987, 441)
        Me.Panel2.TabIndex = 4
        '
        'tabBuscar
        '
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
        Me.tabBuscar.Controls.Add(Me.SuperTabControlPanel1)
        Me.tabBuscar.Controls.Add(Me.pnlDatos)
        Me.tabBuscar.Controls.Add(Me.SuperTabControlPanel2)
        Me.tabBuscar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.Location = New System.Drawing.Point(12, 12)
        Me.tabBuscar.Name = "tabBuscar"
        Me.tabBuscar.ReorderTabsEnabled = True
        Me.tabBuscar.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabBuscar.SelectedTabIndex = 0
        Me.tabBuscar.Size = New System.Drawing.Size(963, 417)
        Me.tabBuscar.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.tabBuscar.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.TabIndex = 0
        Me.tabBuscar.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit
        Me.tabBuscar.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabEmpleado, Me.tabTabla, Me.tabDefault})
        Me.tabBuscar.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.txtServiciodef)
        Me.SuperTabControlPanel1.Controls.Add(Me.btnQuitarD)
        Me.SuperTabControlPanel1.Controls.Add(Me.btnCambiarD)
        Me.SuperTabControlPanel1.Controls.Add(Me.picDefault)
        Me.SuperTabControlPanel1.Controls.Add(Me.txtdescdefa)
        Me.SuperTabControlPanel1.Controls.Add(Me.Label3)
        Me.SuperTabControlPanel1.Controls.Add(Me.Label4)
        Me.SuperTabControlPanel1.Controls.Add(Me.Label6)
        Me.SuperTabControlPanel1.Controls.Add(Me.Label7)
        Me.SuperTabControlPanel1.Controls.Add(Me.txtNombredef)
        Me.SuperTabControlPanel1.Controls.Add(Me.txtcoddef)
        Me.SuperTabControlPanel1.Controls.Add(Me.PictureBox4)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(873, 417)
        Me.SuperTabControlPanel1.TabIndex = 0
        Me.SuperTabControlPanel1.TabItem = Me.tabDefault
        '
        'txtServiciodef
        '
        '
        '
        '
        Me.txtServiciodef.Border.Class = "TextBoxBorder"
        Me.txtServiciodef.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtServiciodef.Enabled = False
        Me.txtServiciodef.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServiciodef.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtServiciodef.Location = New System.Drawing.Point(131, 99)
        Me.txtServiciodef.MaxLength = 10
        Me.txtServiciodef.Name = "txtServiciodef"
        Me.txtServiciodef.Size = New System.Drawing.Size(314, 21)
        Me.txtServiciodef.TabIndex = 39
        '
        'btnQuitarD
        '
        Me.btnQuitarD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnQuitarD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnQuitarD.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitarD.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnQuitarD.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnQuitarD.Location = New System.Drawing.Point(675, 361)
        Me.btnQuitarD.Name = "btnQuitarD"
        Me.btnQuitarD.Size = New System.Drawing.Size(40, 40)
        Me.btnQuitarD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnQuitarD.TabIndex = 38
        Me.btnQuitarD.Text = "Quitar"
        '
        'btnCambiarD
        '
        Me.btnCambiarD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCambiarD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCambiarD.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCambiarD.Image = Global.PIDA.My.Resources.Resources._1472009531_camera_photo
        Me.btnCambiarD.ImageFixedSize = New System.Drawing.Size(20, 20)
        Me.btnCambiarD.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnCambiarD.Location = New System.Drawing.Point(629, 361)
        Me.btnCambiarD.Name = "btnCambiarD"
        Me.btnCambiarD.Size = New System.Drawing.Size(40, 40)
        Me.btnCambiarD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCambiarD.TabIndex = 36
        Me.btnCambiarD.Text = "Cambiar"
        '
        'picDefault
        '
        Me.picDefault.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.picDefault.Location = New System.Drawing.Point(486, 27)
        Me.picDefault.Name = "picDefault"
        Me.picDefault.Size = New System.Drawing.Size(358, 358)
        Me.picDefault.TabIndex = 35
        Me.picDefault.TabStop = False
        '
        'txtdescdefa
        '
        '
        '
        '
        Me.txtdescdefa.Border.Class = "TextBoxBorder"
        Me.txtdescdefa.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtdescdefa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtdescdefa.Enabled = False
        Me.txtdescdefa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdescdefa.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtdescdefa.Location = New System.Drawing.Point(131, 139)
        Me.txtdescdefa.MaxLength = 90
        Me.txtdescdefa.Multiline = True
        Me.txtdescdefa.Name = "txtdescdefa"
        Me.txtdescdefa.Size = New System.Drawing.Size(314, 89)
        Me.txtdescdefa.TabIndex = 31
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 15)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Nombre"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 15)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Código "
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(17, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 15)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Servicio"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Window
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 141)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 15)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Descripción"
        '
        'txtNombredef
        '
        '
        '
        '
        Me.txtNombredef.Border.Class = "TextBoxBorder"
        Me.txtNombredef.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombredef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombredef.Enabled = False
        Me.txtNombredef.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombredef.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNombredef.Location = New System.Drawing.Point(131, 64)
        Me.txtNombredef.MaxLength = 90
        Me.txtNombredef.Name = "txtNombredef"
        Me.txtNombredef.Size = New System.Drawing.Size(314, 21)
        Me.txtNombredef.TabIndex = 29
        '
        'txtcoddef
        '
        '
        '
        '
        Me.txtcoddef.Border.Class = "TextBoxBorder"
        Me.txtcoddef.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtcoddef.Enabled = False
        Me.txtcoddef.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcoddef.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtcoddef.Location = New System.Drawing.Point(131, 31)
        Me.txtcoddef.MaxLength = 10
        Me.txtcoddef.Name = "txtcoddef"
        Me.txtcoddef.Size = New System.Drawing.Size(314, 21)
        Me.txtcoddef.TabIndex = 27
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.BackgroundImage = Global.PIDA.My.Resources.Resources.fondo_tres
        Me.PictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox4.Location = New System.Drawing.Point(475, 15)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(380, 380)
        Me.PictureBox4.TabIndex = 37
        Me.PictureBox4.TabStop = False
        '
        'tabDefault
        '
        Me.tabDefault.AttachedControl = Me.SuperTabControlPanel1
        Me.tabDefault.GlobalItem = False
        Me.tabDefault.Name = "tabDefault"
        Me.tabDefault.Text = "Menu Default"
        '
        'pnlDatos
        '
        Me.pnlDatos.AutoSize = True
        Me.pnlDatos.Controls.Add(Me.btnQuitarFoto)
        Me.pnlDatos.Controls.Add(Me.btnCambiarFoto)
        Me.pnlDatos.Controls.Add(Me.pctFotoMenu)
        Me.pnlDatos.Controls.Add(Me.txtDescripcion)
        Me.pnlDatos.Controls.Add(Me.cmbServicio)
        Me.pnlDatos.Controls.Add(Me.Label2)
        Me.pnlDatos.Controls.Add(Me.Label1)
        Me.pnlDatos.Controls.Add(Me.Label15)
        Me.pnlDatos.Controls.Add(Me.Label5)
        Me.pnlDatos.Controls.Add(Me.txtNombre)
        Me.pnlDatos.Controls.Add(Me.txtCodigo)
        Me.pnlDatos.Controls.Add(Me.PictureBox3)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(869, 417)
        Me.pnlDatos.TabIndex = 0
        Me.pnlDatos.TabItem = Me.tabEmpleado
        '
        'btnQuitarFoto
        '
        Me.btnQuitarFoto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnQuitarFoto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnQuitarFoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitarFoto.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnQuitarFoto.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnQuitarFoto.Location = New System.Drawing.Point(688, 353)
        Me.btnQuitarFoto.Name = "btnQuitarFoto"
        Me.btnQuitarFoto.Size = New System.Drawing.Size(40, 40)
        Me.btnQuitarFoto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnQuitarFoto.TabIndex = 26
        Me.btnQuitarFoto.Text = "Quitar"
        '
        'btnCambiarFoto
        '
        Me.btnCambiarFoto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCambiarFoto.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCambiarFoto.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCambiarFoto.Image = Global.PIDA.My.Resources.Resources._1472009531_camera_photo
        Me.btnCambiarFoto.ImageFixedSize = New System.Drawing.Size(20, 20)
        Me.btnCambiarFoto.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnCambiarFoto.Location = New System.Drawing.Point(642, 353)
        Me.btnCambiarFoto.Name = "btnCambiarFoto"
        Me.btnCambiarFoto.Size = New System.Drawing.Size(40, 40)
        Me.btnCambiarFoto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCambiarFoto.TabIndex = 24
        Me.btnCambiarFoto.Text = "Cambiar"
        '
        'pctFotoMenu
        '
        Me.pctFotoMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pctFotoMenu.Location = New System.Drawing.Point(499, 19)
        Me.pctFotoMenu.Name = "pctFotoMenu"
        Me.pctFotoMenu.Size = New System.Drawing.Size(358, 358)
        Me.pctFotoMenu.TabIndex = 23
        Me.pctFotoMenu.TabStop = False
        '
        'txtDescripcion
        '
        '
        '
        '
        Me.txtDescripcion.Border.Class = "TextBoxBorder"
        Me.txtDescripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDescripcion.Location = New System.Drawing.Point(144, 131)
        Me.txtDescripcion.MaxLength = 90
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(314, 89)
        Me.txtDescripcion.TabIndex = 4
        '
        'cmbServicio
        '
        Me.cmbServicio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbServicio.FormattingEnabled = True
        Me.cmbServicio.ItemHeight = 14
        Me.cmbServicio.Location = New System.Drawing.Point(144, 92)
        Me.cmbServicio.Name = "cmbServicio"
        Me.cmbServicio.Size = New System.Drawing.Size(314, 20)
        Me.cmbServicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbServicio.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nombre"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Código "
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.SystemColors.Window
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(30, 97)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(50, 15)
        Me.Label15.TabIndex = 21
        Me.Label15.Text = "Servicio"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(30, 133)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 15)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Descripción"
        '
        'txtNombre
        '
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNombre.Location = New System.Drawing.Point(144, 56)
        Me.txtNombre.MaxLength = 90
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(314, 21)
        Me.txtNombre.TabIndex = 2
        '
        'txtCodigo
        '
        '
        '
        '
        Me.txtCodigo.Border.Class = "TextBoxBorder"
        Me.txtCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCodigo.Location = New System.Drawing.Point(144, 23)
        Me.txtCodigo.MaxLength = 10
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(314, 21)
        Me.txtCodigo.TabIndex = 1
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.BackgroundImage = Global.PIDA.My.Resources.Resources.fondo_tres
        Me.PictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox3.Location = New System.Drawing.Point(488, 7)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(380, 380)
        Me.PictureBox3.TabIndex = 25
        Me.PictureBox3.TabStop = False
        '
        'tabEmpleado
        '
        Me.tabEmpleado.AttachedControl = Me.pnlDatos
        Me.tabEmpleado.GlobalItem = False
        Me.tabEmpleado.Name = "tabEmpleado"
        Me.tabEmpleado.Text = "Individual"
        '
        'CodTurnocol
        '
        Me.CodTurnocol.ColumnName = "cod_turno"
        Me.CodTurnocol.DataFieldName = "cod_turno"
        Me.CodTurnocol.Name = "CodTurnocol"
        Me.CodTurnocol.Text = "Código"
        Me.CodTurnocol.Width.Absolute = 50
        '
        'NomTurnoCol
        '
        Me.NomTurnoCol.ColumnName = "nombre"
        Me.NomTurnoCol.DataFieldName = "nombre"
        Me.NomTurnoCol.Name = "NomTurnoCol"
        Me.NomTurnoCol.Text = "Turno"
        Me.NomTurnoCol.Width.Absolute = 150
        '
        'EmpNav
        '
        Me.EmpNav.Controls.Add(Me.pnlControles)
        Me.EmpNav.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.EmpNav.Location = New System.Drawing.Point(0, 502)
        Me.EmpNav.Name = "EmpNav"
        Me.EmpNav.Size = New System.Drawing.Size(987, 47)
        Me.EmpNav.TabIndex = 5
        Me.EmpNav.TabStop = False
        '
        'pnlControles
        '
        Me.pnlControles.Controls.Add(Me.btnPrimero)
        Me.pnlControles.Controls.Add(Me.btnCerrar)
        Me.pnlControles.Controls.Add(Me.btnNuevo)
        Me.pnlControles.Controls.Add(Me.btnEditar)
        Me.pnlControles.Controls.Add(Me.btnReporte)
        Me.pnlControles.Controls.Add(Me.btnBuscar)
        Me.pnlControles.Controls.Add(Me.btnAnterior)
        Me.pnlControles.Controls.Add(Me.btnUltimo)
        Me.pnlControles.Controls.Add(Me.btnBorrar)
        Me.pnlControles.Controls.Add(Me.btnSiguiente)
        Me.pnlControles.Location = New System.Drawing.Point(65, 11)
        Me.pnlControles.Name = "pnlControles"
        Me.pnlControles.Size = New System.Drawing.Size(821, 33)
        Me.pnlControles.TabIndex = 0
        '
        'btnPrimero
        '
        Me.btnPrimero.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrimero.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrimero.Image = Global.PIDA.My.Resources.Resources.First16
        Me.btnPrimero.Location = New System.Drawing.Point(10, 5)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(78, 25)
        Me.btnPrimero.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrimero.TabIndex = 19
        Me.btnPrimero.Text = "Inicio"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(739, 5)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 18
        Me.btnCerrar.Text = "Salir"
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.NewRecord
        Me.btnNuevo.Location = New System.Drawing.Point(496, 5)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 25)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 15
        Me.btnNuevo.Text = "Agregar"
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = Global.PIDA.My.Resources.Resources.Edit
        Me.btnEditar.Location = New System.Drawing.Point(577, 5)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(78, 25)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 16
        Me.btnEditar.Text = "Editar"
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnReporte.Location = New System.Drawing.Point(415, 5)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 14
        Me.btnReporte.Text = "Reporte"
        Me.btnReporte.Visible = False
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscar.Location = New System.Drawing.Point(334, 5)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(78, 25)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 13
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Tooltip = "Buscar"
        '
        'btnAnterior
        '
        Me.btnAnterior.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAnterior.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAnterior.Image = Global.PIDA.My.Resources.Resources.Prev16
        Me.btnAnterior.Location = New System.Drawing.Point(91, 5)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(78, 25)
        Me.btnAnterior.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAnterior.TabIndex = 20
        Me.btnAnterior.Text = "Anterior"
        '
        'btnUltimo
        '
        Me.btnUltimo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnUltimo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnUltimo.Image = Global.PIDA.My.Resources.Resources.Last16
        Me.btnUltimo.Location = New System.Drawing.Point(253, 5)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(78, 25)
        Me.btnUltimo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnUltimo.TabIndex = 22
        Me.btnUltimo.Text = "Final"
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = Global.PIDA.My.Resources.Resources.DeleteRec
        Me.btnBorrar.Location = New System.Drawing.Point(658, 5)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(78, 25)
        Me.btnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBorrar.TabIndex = 17
        Me.btnBorrar.Text = "Borrar"
        '
        'btnSiguiente
        '
        Me.btnSiguiente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSiguiente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSiguiente.Image = Global.PIDA.My.Resources.Resources.Next16
        Me.btnSiguiente.Location = New System.Drawing.Point(172, 5)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(78, 25)
        Me.btnSiguiente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSiguiente.TabIndex = 21
        Me.btnSiguiente.Text = "Siguiente"
        '
        'NombreCia
        '
        Me.NombreCia.DataFieldName = "nombre"
        Me.NombreCia.Name = "NombreCia"
        Me.NombreCia.StretchToFill = True
        Me.NombreCia.Text = "Nombre"
        Me.NombreCia.Width.Absolute = 150
        Me.NombreCia.Width.AutoSize = True
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(58, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(581, 40)
        Me.ReflectionLabel1.TabIndex = 0
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>MENUS DE CAFETERIA</b></font>"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.ReflectionLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(987, 55)
        Me.Panel1.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.PIDA.My.Resources.Resources._1469760469_kmenuedit
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(53, 55)
        Me.PictureBox1.TabIndex = 82
        Me.PictureBox1.TabStop = False
        '
        'frmMenuCafeteria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(987, 549)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.EmpNav)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMenuCafeteria"
        Me.Text = "Menús de cafetería"
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBuscar.ResumeLayout(False)
        Me.tabBuscar.PerformLayout()
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel1.PerformLayout()
        CType(Me.picDefault, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        CType(Me.pctFotoMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EmpNav.ResumeLayout(False)
        Me.pnlControles.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CodCia As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents CodTurno As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NombreTurno As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents HorasTurno As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents dgTabla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents tabTabla As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tabBuscar As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents pnlDatos As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents CodTurnocol As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NomTurnoCol As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tabEmpleado As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents EmpNav As System.Windows.Forms.GroupBox
    Friend WithEvents pnlControles As System.Windows.Forms.Panel
    Friend WithEvents btnPrimero As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAnterior As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnUltimo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSiguiente As DevComponents.DotNetBar.ButtonX
    Friend WithEvents NombreCia As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtDescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbServicio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents pctFotoMenu As System.Windows.Forms.PictureBox
    Friend WithEvents btnCambiarFoto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnQuitarFoto As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents btnQuitarD As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCambiarD As DevComponents.DotNetBar.ButtonX
    Friend WithEvents picDefault As System.Windows.Forms.PictureBox
    Friend WithEvents txtdescdefa As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtNombredef As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents tabDefault As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents txtServiciodef As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtcoddef As DevComponents.DotNetBar.Controls.TextBoxX
End Class
