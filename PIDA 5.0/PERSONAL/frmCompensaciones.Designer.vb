<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompensaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCompensaciones))
        Me.txtTipo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtComp = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAlta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtDepto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPuesto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.lblEstado = New DevComponents.DotNetBar.LabelX()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.tabBuscar = New DevComponents.DotNetBar.SuperTabControl()
        Me.pnlDatos = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.txtID = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.gpCompen = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.cmbTipoCompen = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Cve_Compen = New DevComponents.AdvTree.ColumnHeader()
        Me.Desc_Compen = New DevComponents.AdvTree.ColumnHeader()
        Me.DateTimeInput3 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.DateTimeInput2 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.DateTimeInput1 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCompensacionActual = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.SwitchButton = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtComent = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnBusca = New DevComponents.DotNetBar.ButtonX()
        Me.picFoto = New System.Windows.Forms.PictureBox()
        Me.tabEmpleado = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgTabla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.tabTabla = New DevComponents.DotNetBar.SuperTabItem()
        Me.GroupBox1.SuspendLayout()
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBuscar.SuspendLayout()
        Me.pnlDatos.SuspendLayout()
        Me.gpCompen.SuspendLayout()
        CType(Me.DateTimeInput3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTimeInput2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTimeInput1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtTipo
        '
        Me.txtTipo.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtTipo.Border.Class = "TextBoxBorder"
        Me.txtTipo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTipo.Location = New System.Drawing.Point(115, 134)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.ReadOnly = True
        Me.txtTipo.Size = New System.Drawing.Size(110, 21)
        Me.txtTipo.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(21, 137)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 15)
        Me.Label9.TabIndex = 109
        Me.Label9.Text = "Tipo"
        '
        'txtComp
        '
        Me.txtComp.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtComp.Border.Class = "TextBoxBorder"
        Me.txtComp.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtComp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtComp.Location = New System.Drawing.Point(367, 26)
        Me.txtComp.Name = "txtComp"
        Me.txtComp.ReadOnly = True
        Me.txtComp.Size = New System.Drawing.Size(110, 21)
        Me.txtComp.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(292, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 15)
        Me.Label8.TabIndex = 107
        Me.Label8.Text = "Compañía"
        '
        'txtAlta
        '
        Me.txtAlta.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtAlta.Border.Class = "TextBoxBorder"
        Me.txtAlta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtAlta.Location = New System.Drawing.Point(318, 135)
        Me.txtAlta.Name = "txtAlta"
        Me.txtAlta.ReadOnly = True
        Me.txtAlta.Size = New System.Drawing.Size(110, 21)
        Me.txtAlta.TabIndex = 7
        Me.txtAlta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDepto
        '
        Me.txtDepto.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtDepto.Border.Class = "TextBoxBorder"
        Me.txtDepto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDepto.Location = New System.Drawing.Point(115, 107)
        Me.txtDepto.Name = "txtDepto"
        Me.txtDepto.ReadOnly = True
        Me.txtDepto.Size = New System.Drawing.Size(362, 21)
        Me.txtDepto.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 15)
        Me.Label4.TabIndex = 105
        Me.Label4.Text = "Departamento"
        '
        'txtPuesto
        '
        Me.txtPuesto.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtPuesto.Border.Class = "TextBoxBorder"
        Me.txtPuesto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPuesto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPuesto.Location = New System.Drawing.Point(115, 80)
        Me.txtPuesto.Name = "txtPuesto"
        Me.txtPuesto.ReadOnly = True
        Me.txtPuesto.Size = New System.Drawing.Size(362, 21)
        Me.txtPuesto.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(21, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 15)
        Me.Label3.TabIndex = 103
        Me.Label3.Text = "Puesto"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(231, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 15)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "Fecha de alta"
        '
        'txtReloj
        '
        Me.txtReloj.AcceptsReturn = True
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.Location = New System.Drawing.Point(115, 17)
        Me.txtReloj.MaxLength = 6
        Me.txtReloj.Multiline = True
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.Size = New System.Drawing.Size(84, 26)
        Me.txtReloj.TabIndex = 0
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(21, 17)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(84, 23)
        Me.LabelX4.TabIndex = 101
        Me.LabelX4.Text = "Reloj"
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblEstado.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblEstado.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.Black
        Me.lblEstado.Location = New System.Drawing.Point(0, 0)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(23, 461)
        Me.lblEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblEstado.TabIndex = 99
        Me.lblEstado.Text = "ESTATUS"
        Me.lblEstado.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblEstado.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.lblEstado.VerticalTextTopUp = False
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNombre.Location = New System.Drawing.Point(115, 52)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(362, 23)
        Me.txtNombre.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 17)
        Me.Label2.TabIndex = 98
        Me.Label2.Text = "Nombre"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.btnAceptar)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Location = New System.Drawing.Point(427, 407)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(257, 47)
        Me.GroupBox1.TabIndex = 112
        Me.GroupBox1.TabStop = False
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscar.Location = New System.Drawing.Point(6, 14)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(78, 25)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 0
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Tooltip = "Buscar"
        Me.btnBuscar.Visible = False
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.Location = New System.Drawing.Point(88, 14)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelar.Location = New System.Drawing.Point(170, 14)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        '
        'tabBuscar
        '
        Me.tabBuscar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabBuscar.BackColor = System.Drawing.SystemColors.Window
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
        Me.tabBuscar.ForeColor = System.Drawing.Color.Black
        Me.tabBuscar.Location = New System.Drawing.Point(29, 7)
        Me.tabBuscar.Name = "tabBuscar"
        Me.tabBuscar.ReorderTabsEnabled = True
        Me.tabBuscar.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabBuscar.SelectedTabIndex = 0
        Me.tabBuscar.Size = New System.Drawing.Size(659, 408)
        Me.tabBuscar.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.tabBuscar.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.TabIndex = 114
        Me.tabBuscar.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit
        Me.tabBuscar.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabEmpleado, Me.tabTabla})
        Me.tabBuscar.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        '
        'pnlDatos
        '
        Me.pnlDatos.CanvasColor = System.Drawing.SystemColors.Window
        Me.pnlDatos.Controls.Add(Me.txtID)
        Me.pnlDatos.Controls.Add(Me.Label14)
        Me.pnlDatos.Controls.Add(Me.LabelX4)
        Me.pnlDatos.Controls.Add(Me.gpCompen)
        Me.pnlDatos.Controls.Add(Me.txtReloj)
        Me.pnlDatos.Controls.Add(Me.btnBusca)
        Me.pnlDatos.Controls.Add(Me.txtTipo)
        Me.pnlDatos.Controls.Add(Me.Label9)
        Me.pnlDatos.Controls.Add(Me.Label2)
        Me.pnlDatos.Controls.Add(Me.txtAlta)
        Me.pnlDatos.Controls.Add(Me.picFoto)
        Me.pnlDatos.Controls.Add(Me.Label1)
        Me.pnlDatos.Controls.Add(Me.txtComp)
        Me.pnlDatos.Controls.Add(Me.txtNombre)
        Me.pnlDatos.Controls.Add(Me.Label8)
        Me.pnlDatos.Controls.Add(Me.Label3)
        Me.pnlDatos.Controls.Add(Me.txtPuesto)
        Me.pnlDatos.Controls.Add(Me.txtDepto)
        Me.pnlDatos.Controls.Add(Me.Label4)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(588, 408)
        Me.pnlDatos.TabIndex = 0
        Me.pnlDatos.TabItem = Me.tabEmpleado
        '
        'txtID
        '
        Me.txtID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtID.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtID.Border.Class = "TextBoxBorder"
        Me.txtID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.ForeColor = System.Drawing.Color.Brown
        Me.txtID.Location = New System.Drawing.Point(496, 135)
        Me.txtID.MaxLength = 6
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(84, 20)
        Me.txtID.TabIndex = 7
        Me.txtID.Text = "0"
        Me.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(456, 140)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(34, 15)
        Me.Label14.TabIndex = 111
        Me.Label14.Text = "Folio"
        '
        'gpCompen
        '
        Me.gpCompen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpCompen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpCompen.BackColor = System.Drawing.SystemColors.Window
        Me.gpCompen.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpCompen.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpCompen.Controls.Add(Me.cmbTipoCompen)
        Me.gpCompen.Controls.Add(Me.DateTimeInput3)
        Me.gpCompen.Controls.Add(Me.DateTimeInput2)
        Me.gpCompen.Controls.Add(Me.DateTimeInput1)
        Me.gpCompen.Controls.Add(Me.Label13)
        Me.gpCompen.Controls.Add(Me.Label11)
        Me.gpCompen.Controls.Add(Me.txtCompensacionActual)
        Me.gpCompen.Controls.Add(Me.SwitchButton)
        Me.gpCompen.Controls.Add(Me.Label10)
        Me.gpCompen.Controls.Add(Me.Label7)
        Me.gpCompen.Controls.Add(Me.Label6)
        Me.gpCompen.Controls.Add(Me.Label5)
        Me.gpCompen.Controls.Add(Me.txtComent)
        Me.gpCompen.Controls.Add(Me.Label12)
        Me.gpCompen.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpCompen.Enabled = False
        Me.gpCompen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpCompen.Location = New System.Drawing.Point(12, 161)
        Me.gpCompen.Name = "gpCompen"
        Me.gpCompen.Size = New System.Drawing.Size(568, 233)
        '
        '
        '
        Me.gpCompen.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpCompen.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpCompen.Style.BackColorGradientAngle = 90
        Me.gpCompen.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpCompen.Style.BorderBottomWidth = 1
        Me.gpCompen.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpCompen.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpCompen.Style.BorderLeftWidth = 1
        Me.gpCompen.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpCompen.Style.BorderRightWidth = 1
        Me.gpCompen.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpCompen.Style.BorderTopWidth = 1
        Me.gpCompen.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpCompen.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpCompen.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpCompen.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpCompen.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpCompen.TabIndex = 8
        Me.gpCompen.TabStop = True
        Me.gpCompen.Text = "Compensaciones"
        '
        'cmbTipoCompen
        '
        Me.cmbTipoCompen.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbTipoCompen.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbTipoCompen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbTipoCompen.ButtonDropDown.Visible = True
        Me.cmbTipoCompen.Columns.Add(Me.Cve_Compen)
        Me.cmbTipoCompen.Columns.Add(Me.Desc_Compen)
        Me.cmbTipoCompen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoCompen.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbTipoCompen.Location = New System.Drawing.Point(122, 84)
        Me.cmbTipoCompen.Name = "cmbTipoCompen"
        Me.cmbTipoCompen.Size = New System.Drawing.Size(241, 23)
        Me.cmbTipoCompen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipoCompen.TabIndex = 3
        Me.cmbTipoCompen.ValueMember = "Cve_Compen"
        '
        'Cve_Compen
        '
        Me.Cve_Compen.DataFieldName = "Cve_Compen"
        Me.Cve_Compen.Name = "Cve_Compen"
        Me.Cve_Compen.Text = "Clave"
        Me.Cve_Compen.Width.Absolute = 50
        Me.Cve_Compen.Width.AutoSize = True
        Me.Cve_Compen.Width.AutoSizeMinHeader = True
        '
        'Desc_Compen
        '
        Me.Desc_Compen.DataFieldName = "Desc_Compen"
        Me.Desc_Compen.Name = "Desc_Compen"
        Me.Desc_Compen.Text = "Descripción"
        Me.Desc_Compen.Width.Absolute = 130
        Me.Desc_Compen.Width.AutoSize = True
        Me.Desc_Compen.Width.AutoSizeMinHeader = True
        '
        'DateTimeInput3
        '
        '
        '
        '
        Me.DateTimeInput3.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DateTimeInput3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInput3.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DateTimeInput3.ButtonDropDown.Visible = True
        Me.DateTimeInput3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimeInput3.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.DateTimeInput3.IsPopupCalendarOpen = False
        Me.DateTimeInput3.Location = New System.Drawing.Point(345, 114)
        '
        '
        '
        Me.DateTimeInput3.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInput3.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInput3.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.DateTimeInput3.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DateTimeInput3.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DateTimeInput3.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInput3.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DateTimeInput3.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DateTimeInput3.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DateTimeInput3.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DateTimeInput3.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInput3.MonthCalendar.DisplayMonth = New Date(2018, 2, 1, 0, 0, 0, 0)
        Me.DateTimeInput3.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.DateTimeInput3.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInput3.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DateTimeInput3.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInput3.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DateTimeInput3.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInput3.MonthCalendar.TodayButtonVisible = True
        Me.DateTimeInput3.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.DateTimeInput3.Name = "DateTimeInput3"
        Me.DateTimeInput3.Size = New System.Drawing.Size(113, 22)
        Me.DateTimeInput3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DateTimeInput3.TabIndex = 5
        Me.DateTimeInput3.Visible = False
        '
        'DateTimeInput2
        '
        '
        '
        '
        Me.DateTimeInput2.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DateTimeInput2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInput2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DateTimeInput2.ButtonDropDown.Visible = True
        Me.DateTimeInput2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimeInput2.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.DateTimeInput2.IsPopupCalendarOpen = False
        Me.DateTimeInput2.Location = New System.Drawing.Point(122, 56)
        '
        '
        '
        Me.DateTimeInput2.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInput2.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInput2.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.DateTimeInput2.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DateTimeInput2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DateTimeInput2.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInput2.MonthCalendar.DisplayMonth = New Date(2018, 2, 1, 0, 0, 0, 0)
        Me.DateTimeInput2.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.DateTimeInput2.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInput2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DateTimeInput2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInput2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DateTimeInput2.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInput2.MonthCalendar.TodayButtonVisible = True
        Me.DateTimeInput2.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.DateTimeInput2.Name = "DateTimeInput2"
        Me.DateTimeInput2.Size = New System.Drawing.Size(113, 22)
        Me.DateTimeInput2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DateTimeInput2.TabIndex = 2
        '
        'DateTimeInput1
        '
        '
        '
        '
        Me.DateTimeInput1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DateTimeInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInput1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DateTimeInput1.ButtonDropDown.Visible = True
        Me.DateTimeInput1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimeInput1.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.DateTimeInput1.IsPopupCalendarOpen = False
        Me.DateTimeInput1.Location = New System.Drawing.Point(122, 30)
        '
        '
        '
        Me.DateTimeInput1.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInput1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInput1.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.DateTimeInput1.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DateTimeInput1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInput1.MonthCalendar.DisplayMonth = New Date(2018, 2, 1, 0, 0, 0, 0)
        Me.DateTimeInput1.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.DateTimeInput1.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DateTimeInput1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInput1.MonthCalendar.TodayButtonVisible = True
        Me.DateTimeInput1.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.DateTimeInput1.Name = "DateTimeInput1"
        Me.DateTimeInput1.Size = New System.Drawing.Size(113, 22)
        Me.DateTimeInput1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DateTimeInput1.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.Window
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(3, 56)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(90, 15)
        Me.Label13.TabIndex = 83
        Me.Label13.Text = "Fecha Termino"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Window
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(3, 31)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 15)
        Me.Label11.TabIndex = 81
        Me.Label11.Text = "Fecha Inicio"
        '
        'txtCompensacionActual
        '
        '
        '
        '
        Me.txtCompensacionActual.Border.Class = "TextBoxBorder"
        Me.txtCompensacionActual.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCompensacionActual.Font = New System.Drawing.Font("Arial Rounded MT Bold", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCompensacionActual.ForeColor = System.Drawing.Color.Black
        Me.txtCompensacionActual.Location = New System.Drawing.Point(122, 3)
        Me.txtCompensacionActual.Name = "txtCompensacionActual"
        Me.txtCompensacionActual.PreventEnterBeep = True
        Me.txtCompensacionActual.Size = New System.Drawing.Size(113, 23)
        Me.txtCompensacionActual.TabIndex = 0
        Me.txtCompensacionActual.Text = "$0.00"
        Me.txtCompensacionActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'SwitchButton
        '
        Me.SwitchButton.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.SwitchButton.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SwitchButton.Location = New System.Drawing.Point(122, 114)
        Me.SwitchButton.Name = "SwitchButton"
        Me.SwitchButton.OffBackColor = System.Drawing.Color.Red
        Me.SwitchButton.OffText = "Suspendido"
        Me.SwitchButton.OffTextColor = System.Drawing.Color.White
        Me.SwitchButton.OnBackColor = System.Drawing.Color.LimeGreen
        Me.SwitchButton.OnText = "Activo"
        Me.SwitchButton.OnTextColor = System.Drawing.Color.White
        Me.SwitchButton.Size = New System.Drawing.Size(105, 22)
        Me.SwitchButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SwitchButton.TabIndex = 4
        Me.SwitchButton.Value = True
        Me.SwitchButton.ValueObject = "Y"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Window
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(230, 116)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(109, 15)
        Me.Label10.TabIndex = 79
        Me.Label10.Text = "Fecha Suspensión"
        Me.Label10.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Window
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 5)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 15)
        Me.Label7.TabIndex = 77
        Me.Label7.Text = "Sueldo Cobertura"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 15)
        Me.Label6.TabIndex = 74
        Me.Label6.Text = "Tipo Compensación"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 142)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 15)
        Me.Label5.TabIndex = 65
        Me.Label5.Text = "Comentarios"
        '
        'txtComent
        '
        Me.txtComent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtComent.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtComent.Border.Class = "TextBoxBorder"
        Me.txtComent.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtComent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComent.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtComent.Location = New System.Drawing.Point(122, 142)
        Me.txtComent.MaxLength = 200
        Me.txtComent.Multiline = True
        Me.txtComent.Name = "txtComent"
        Me.txtComent.Size = New System.Drawing.Size(433, 61)
        Me.txtComent.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Window
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 114)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 15)
        Me.Label12.TabIndex = 60
        Me.Label12.Text = "Estatus"
        '
        'btnBusca
        '
        Me.btnBusca.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBusca.CausesValidation = False
        Me.btnBusca.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBusca.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBusca.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBusca.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBusca.Location = New System.Drawing.Point(205, 18)
        Me.btnBusca.Name = "btnBusca"
        Me.btnBusca.Size = New System.Drawing.Size(26, 25)
        Me.btnBusca.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBusca.TabIndex = 1
        Me.btnBusca.Tooltip = "Buscar"
        '
        'picFoto
        '
        Me.picFoto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picFoto.BackColor = System.Drawing.SystemColors.Control
        Me.picFoto.ErrorImage = Global.PIDA.My.Resources.Resources.NoFoto
        Me.picFoto.Image = Global.PIDA.My.Resources.Resources.NoFoto
        Me.picFoto.Location = New System.Drawing.Point(485, 10)
        Me.picFoto.Name = "picFoto"
        Me.picFoto.Size = New System.Drawing.Size(95, 120)
        Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picFoto.TabIndex = 97
        Me.picFoto.TabStop = False
        '
        'tabEmpleado
        '
        Me.tabEmpleado.AttachedControl = Me.pnlDatos
        Me.tabEmpleado.GlobalItem = False
        Me.tabEmpleado.Name = "tabEmpleado"
        Me.tabEmpleado.Text = "Individual"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.dgTabla)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(586, 408)
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
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
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
        Me.dgTabla.Size = New System.Drawing.Size(586, 408)
        Me.dgTabla.TabIndex = 0
        '
        'tabTabla
        '
        Me.tabTabla.AttachedControl = Me.SuperTabControlPanel2
        Me.tabTabla.GlobalItem = False
        Me.tabTabla.Name = "tabTabla"
        Me.tabTabla.Text = "Lista"
        '
        'frmCompensaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 461)
        Me.Controls.Add(Me.tabBuscar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblEstado)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCompensaciones"
        Me.Text = "Compensaciones"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBuscar.ResumeLayout(False)
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        Me.gpCompen.ResumeLayout(False)
        Me.gpCompen.PerformLayout()
        CType(Me.DateTimeInput3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTimeInput2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTimeInput1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnBusca As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtTipo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtComp As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAlta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtDepto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPuesto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblEstado As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents picFoto As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents tabBuscar As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents pnlDatos As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabEmpleado As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents dgTabla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents tabTabla As DevComponents.DotNetBar.SuperTabItem
    Private WithEvents gpCompen As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents SwitchButton As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtComent As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCompensacionActual As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents DateTimeInput3 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents DateTimeInput2 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents DateTimeInput1 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents cmbTipoCompen As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Cve_Compen As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Desc_Compen As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents txtID As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
