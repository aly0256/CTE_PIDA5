<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscar
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscar))
        Me.lblBaja = New System.Windows.Forms.Label()
        Me.lblEstado = New DevComponents.DotNetBar.LabelX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.tabBuscar = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgTabla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ColReloj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAlta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBaja = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPuesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabTabla = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.pnlExtras = New System.Windows.Forms.Panel()
        Me.lblExtras = New System.Windows.Forms.Label()
        Me.lblDatoExtra = New System.Windows.Forms.RichTextBox()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtBaja = New System.Windows.Forms.Label()
        Me.txtAlta = New System.Windows.Forms.Label()
        Me.txtDepto = New System.Windows.Forms.Label()
        Me.txtPuesto = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.picFoto = New System.Windows.Forms.PictureBox()
        Me.tabEmpleado = New DevComponents.DotNetBar.SuperTabItem()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBusca = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.navPersonal = New DevComponents.DotNetBar.Controls.BindingNavigatorEx(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.BindingNavigatorCountItem = New DevComponents.DotNetBar.LabelItem()
        Me.BindingNavigatorMoveFirstItem = New DevComponents.DotNetBar.ButtonItem()
        Me.BindingNavigatorMovePreviousItem = New DevComponents.DotNetBar.ButtonItem()
        Me.BindingNavigatorPositionItem = New DevComponents.DotNetBar.TextBoxItem()
        Me.BindingNavigatorMoveNextItem = New DevComponents.DotNetBar.ButtonItem()
        Me.BindingNavigatorMoveLastItem = New DevComponents.DotNetBar.ButtonItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBuscar.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.pnlExtras.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.navPersonal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.navPersonal.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblBaja
        '
        Me.lblBaja.AutoSize = True
        Me.lblBaja.BackColor = System.Drawing.SystemColors.Window
        Me.lblBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBaja.Location = New System.Drawing.Point(264, 36)
        Me.lblBaja.Name = "lblBaja"
        Me.lblBaja.Size = New System.Drawing.Size(88, 13)
        Me.lblBaja.TabIndex = 63
        Me.lblBaja.Text = "Fecha de baja"
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.Color.Green
        '
        '
        '
        Me.lblEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblEstado.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblEstado.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Window
        Me.lblEstado.Location = New System.Drawing.Point(0, 0)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(23, 227)
        Me.lblEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblEstado.TabIndex = 59
        Me.lblEstado.Text = "ACTIVO"
        Me.lblEstado.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblEstado.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.lblEstado.VerticalTextTopUp = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 17)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Nombre"
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
        Me.txtNombre.Location = New System.Drawing.Point(127, 37)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(361, 23)
        Me.txtNombre.TabIndex = 50
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
        Me.tabBuscar.Controls.Add(Me.SuperTabControlPanel2)
        Me.tabBuscar.Controls.Add(Me.SuperTabControlPanel1)
        Me.tabBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.Location = New System.Drawing.Point(10, 55)
        Me.tabBuscar.Name = "tabBuscar"
        Me.tabBuscar.ReorderTabsEnabled = True
        Me.tabBuscar.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabBuscar.SelectedTabIndex = 0
        Me.tabBuscar.Size = New System.Drawing.Size(670, 227)
        Me.tabBuscar.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.tabBuscar.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.TabIndex = 68
        Me.tabBuscar.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit
        Me.tabBuscar.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabEmpleado, Me.tabTabla})
        Me.tabBuscar.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.dgTabla)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(597, 227)
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
        Me.dgTabla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColReloj, Me.ColNombre, Me.ColAlta, Me.colBaja, Me.ColDepto, Me.ColPuesto})
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
        Me.dgTabla.GridColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(218, Byte), Integer))
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
        Me.dgTabla.RowHeadersVisible = False
        Me.dgTabla.Size = New System.Drawing.Size(597, 227)
        Me.dgTabla.TabIndex = 1
        '
        'ColReloj
        '
        Me.ColReloj.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ColReloj.DataPropertyName = "reloj"
        Me.ColReloj.HeaderText = "RELOJ"
        Me.ColReloj.Name = "ColReloj"
        Me.ColReloj.ReadOnly = True
        Me.ColReloj.Width = 66
        '
        'ColNombre
        '
        Me.ColNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ColNombre.DataPropertyName = "nombre"
        Me.ColNombre.HeaderText = "NOMBRE"
        Me.ColNombre.Name = "ColNombre"
        Me.ColNombre.ReadOnly = True
        Me.ColNombre.Width = 79
        '
        'ColAlta
        '
        Me.ColAlta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ColAlta.DataPropertyName = "alta"
        Me.ColAlta.HeaderText = "F.ALTA"
        Me.ColAlta.Name = "ColAlta"
        Me.ColAlta.ReadOnly = True
        Me.ColAlta.Width = 68
        '
        'colBaja
        '
        Me.colBaja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.colBaja.DataPropertyName = "baja"
        Me.colBaja.HeaderText = "F.BAJA"
        Me.colBaja.Name = "colBaja"
        Me.colBaja.ReadOnly = True
        Me.colBaja.Width = 67
        '
        'ColDepto
        '
        Me.ColDepto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ColDepto.DataPropertyName = "departamento"
        Me.ColDepto.HeaderText = "DEPTO."
        Me.ColDepto.Name = "ColDepto"
        Me.ColDepto.ReadOnly = True
        Me.ColDepto.Width = 72
        '
        'ColPuesto
        '
        Me.ColPuesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
        Me.ColPuesto.DataPropertyName = "puesto"
        Me.ColPuesto.HeaderText = "PUESTO"
        Me.ColPuesto.Name = "ColPuesto"
        Me.ColPuesto.ReadOnly = True
        Me.ColPuesto.Width = 76
        '
        'tabTabla
        '
        Me.tabTabla.AttachedControl = Me.SuperTabControlPanel2
        Me.tabTabla.GlobalItem = False
        Me.tabTabla.Name = "tabTabla"
        Me.tabTabla.Text = "Lista"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.AutoSize = True
        Me.SuperTabControlPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.SuperTabControlPanel1.Controls.Add(Me.pnlExtras)
        Me.SuperTabControlPanel1.Controls.Add(Me.Panel3)
        Me.SuperTabControlPanel1.Controls.Add(Me.txtReloj)
        Me.SuperTabControlPanel1.Controls.Add(Me.LabelX4)
        Me.SuperTabControlPanel1.Controls.Add(Me.lblEstado)
        Me.SuperTabControlPanel1.Controls.Add(Me.txtNombre)
        Me.SuperTabControlPanel1.Controls.Add(Me.Label2)
        Me.SuperTabControlPanel1.Controls.Add(Me.picFoto)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(599, 227)
        Me.SuperTabControlPanel1.TabIndex = 63
        Me.SuperTabControlPanel1.TabItem = Me.tabEmpleado
        '
        'pnlExtras
        '
        Me.pnlExtras.AutoScroll = True
        Me.pnlExtras.BackColor = System.Drawing.SystemColors.Window
        Me.pnlExtras.Controls.Add(Me.lblExtras)
        Me.pnlExtras.Controls.Add(Me.lblDatoExtra)
        Me.pnlExtras.Controls.Add(Me.Line1)
        Me.pnlExtras.Location = New System.Drawing.Point(29, 62)
        Me.pnlExtras.Name = "pnlExtras"
        Me.pnlExtras.Padding = New System.Windows.Forms.Padding(5)
        Me.pnlExtras.Size = New System.Drawing.Size(459, 92)
        Me.pnlExtras.TabIndex = 88
        '
        'lblExtras
        '
        Me.lblExtras.AutoSize = True
        Me.lblExtras.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExtras.Location = New System.Drawing.Point(1, 13)
        Me.lblExtras.Name = "lblExtras"
        Me.lblExtras.Size = New System.Drawing.Size(58, 15)
        Me.lblExtras.TabIndex = 84
        Me.lblExtras.Text = "Nombre"
        '
        'lblDatoExtra
        '
        Me.lblDatoExtra.BackColor = System.Drawing.SystemColors.Window
        Me.lblDatoExtra.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblDatoExtra.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblDatoExtra.Location = New System.Drawing.Point(101, 10)
        Me.lblDatoExtra.Name = "lblDatoExtra"
        Me.lblDatoExtra.ReadOnly = True
        Me.lblDatoExtra.Size = New System.Drawing.Size(353, 77)
        Me.lblDatoExtra.TabIndex = 90
        Me.lblDatoExtra.Text = ""
        '
        'Line1
        '
        Me.Line1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Line1.ForeColor = System.Drawing.SystemColors.InactiveCaption
        Me.Line1.Location = New System.Drawing.Point(5, 5)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(449, 5)
        Me.Line1.TabIndex = 89
        Me.Line1.Text = "Line1"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Window
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.txtBaja)
        Me.Panel3.Controls.Add(Me.txtAlta)
        Me.Panel3.Controls.Add(Me.txtDepto)
        Me.Panel3.Controls.Add(Me.txtPuesto)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.lblBaja)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Location = New System.Drawing.Point(33, 160)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(456, 58)
        Me.Panel3.TabIndex = 87
        '
        'txtBaja
        '
        Me.txtBaja.AutoSize = True
        Me.txtBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBaja.Location = New System.Drawing.Point(371, 36)
        Me.txtBaja.Name = "txtBaja"
        Me.txtBaja.Size = New System.Drawing.Size(39, 13)
        Me.txtBaja.TabIndex = 91
        Me.txtBaja.Text = "Label6"
        '
        'txtAlta
        '
        Me.txtAlta.AutoSize = True
        Me.txtAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlta.Location = New System.Drawing.Point(90, 36)
        Me.txtAlta.Name = "txtAlta"
        Me.txtAlta.Size = New System.Drawing.Size(39, 13)
        Me.txtAlta.TabIndex = 90
        Me.txtAlta.Text = "Label6"
        '
        'txtDepto
        '
        Me.txtDepto.AutoSize = True
        Me.txtDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepto.Location = New System.Drawing.Point(90, 21)
        Me.txtDepto.Name = "txtDepto"
        Me.txtDepto.Size = New System.Drawing.Size(39, 13)
        Me.txtDepto.TabIndex = 89
        Me.txtDepto.Text = "Label6"
        '
        'txtPuesto
        '
        Me.txtPuesto.AutoSize = True
        Me.txtPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPuesto.Location = New System.Drawing.Point(90, 6)
        Me.txtPuesto.Name = "txtPuesto"
        Me.txtPuesto.Size = New System.Drawing.Size(39, 13)
        Me.txtPuesto.TabIndex = 88
        Me.txtPuesto.Text = "Label6"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(2, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Puesto"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Fecha de alta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(2, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "Departamento"
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
        Me.txtReloj.Location = New System.Drawing.Point(127, 8)
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.ReadOnly = True
        Me.txtReloj.Size = New System.Drawing.Size(84, 26)
        Me.txtReloj.TabIndex = 68
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(33, 8)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(84, 23)
        Me.LabelX4.TabIndex = 67
        Me.LabelX4.Text = "Reloj"
        '
        'picFoto
        '
        Me.picFoto.BackColor = System.Drawing.SystemColors.Window
        Me.picFoto.ErrorImage = Global.PIDA.My.Resources.Resources.NoFoto
        Me.picFoto.Image = Global.PIDA.My.Resources.Resources.NoFoto
        Me.picFoto.Location = New System.Drawing.Point(495, 9)
        Me.picFoto.Name = "picFoto"
        Me.picFoto.Size = New System.Drawing.Size(95, 120)
        Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picFoto.TabIndex = 53
        Me.picFoto.TabStop = False
        '
        'tabEmpleado
        '
        Me.tabEmpleado.AttachedControl = Me.SuperTabControlPanel1
        Me.tabEmpleado.GlobalItem = False
        Me.tabEmpleado.Name = "tabEmpleado"
        Me.tabEmpleado.Text = "Individual"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(79, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 20)
        Me.Label5.TabIndex = 69
        Me.Label5.Text = "Buscar"
        '
        'txtBusca
        '
        Me.txtBusca.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtBusca.Border.Class = "TextBoxBorder"
        Me.txtBusca.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBusca.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBusca.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusca.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBusca.Location = New System.Drawing.Point(137, 14)
        Me.txtBusca.Name = "txtBusca"
        Me.txtBusca.Size = New System.Drawing.Size(543, 26)
        Me.txtBusca.TabIndex = 0
        '
        'navPersonal
        '
        Me.navPersonal.AntiAlias = True
        Me.navPersonal.BackColor = System.Drawing.SystemColors.ControlLight
        Me.navPersonal.Controls.Add(Me.Panel1)
        Me.navPersonal.CountLabel = Me.BindingNavigatorCountItem
        Me.navPersonal.CountLabelFormat = "of {0}"
        Me.navPersonal.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.navPersonal.DoubleClickBehavior = DevComponents.DotNetBar.eDoubleClickBarBehavior.None
        Me.navPersonal.FadeEffect = True
        Me.navPersonal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.navPersonal.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem})
        Me.navPersonal.Location = New System.Drawing.Point(0, 293)
        Me.navPersonal.MoveFirstButton = Me.BindingNavigatorMoveFirstItem
        Me.navPersonal.MoveLastButton = Me.BindingNavigatorMoveLastItem
        Me.navPersonal.MoveNextButton = Me.BindingNavigatorMoveNextItem
        Me.navPersonal.MovePreviousButton = Me.BindingNavigatorMovePreviousItem
        Me.navPersonal.Name = "navPersonal"
        Me.navPersonal.PositionTextBox = Me.BindingNavigatorPositionItem
        Me.navPersonal.Size = New System.Drawing.Size(691, 28)
        Me.navPersonal.Stretch = True
        Me.navPersonal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.navPersonal.TabIndex = 53
        Me.navPersonal.TabStop = False
        Me.navPersonal.ThemeAware = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnAceptar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(518, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(173, 28)
        Me.Panel1.TabIndex = 53
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.Location = New System.Drawing.Point(3, 2)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.TabIndex = 41
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelar.Location = New System.Drawing.Point(85, 2)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 52
        Me.btnCancelar.Text = "Cancelar"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ThemeAware = True
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BindingNavigatorMoveFirstItem.Image = Global.PIDA.My.Resources.Resources.First16
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.Text = "Inicio"
        Me.BindingNavigatorMoveFirstItem.ThemeAware = True
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BindingNavigatorMovePreviousItem.Image = Global.PIDA.My.Resources.Resources.Prev16
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.Text = "Anterior"
        Me.BindingNavigatorMovePreviousItem.ThemeAware = True
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.BeginGroup = True
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.TextBoxWidth = 54
        Me.BindingNavigatorPositionItem.ThemeAware = True
        Me.BindingNavigatorPositionItem.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.BeginGroup = True
        Me.BindingNavigatorMoveNextItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BindingNavigatorMoveNextItem.Image = Global.PIDA.My.Resources.Resources.Next16
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.Text = "Siguiente"
        Me.BindingNavigatorMoveNextItem.ThemeAware = True
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BindingNavigatorMoveLastItem.Image = Global.PIDA.My.Resources.Resources.Last16
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.Text = "Final"
        Me.BindingNavigatorMoveLastItem.ThemeAware = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Busca48
        Me.PictureBox1.Location = New System.Drawing.Point(10, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(63, 46)
        Me.PictureBox1.TabIndex = 80
        Me.PictureBox1.TabStop = False
        '
        'frmBuscar
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(691, 321)
        Me.Controls.Add(Me.navPersonal)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.txtBusca)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tabBuscar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Búsqueda de personal"
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBuscar.ResumeLayout(False)
        Me.tabBuscar.PerformLayout()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel1.PerformLayout()
        Me.pnlExtras.ResumeLayout(False)
        Me.pnlExtras.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.navPersonal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.navPersonal.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblBaja As System.Windows.Forms.Label
    Friend WithEvents lblEstado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents tabBuscar As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabEmpleado As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabTabla As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents picFoto As System.Windows.Forms.PictureBox
    Friend WithEvents txtBusca As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents dgTabla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents navPersonal As DevComponents.DotNetBar.Controls.BindingNavigatorEx
    Friend WithEvents BindingNavigatorCountItem As DevComponents.DotNetBar.LabelItem
    Friend WithEvents BindingNavigatorMoveFirstItem As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BindingNavigatorMovePreviousItem As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BindingNavigatorPositionItem As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents BindingNavigatorMoveNextItem As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BindingNavigatorMoveLastItem As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtBaja As System.Windows.Forms.Label
    Friend WithEvents txtAlta As System.Windows.Forms.Label
    Friend WithEvents txtDepto As System.Windows.Forms.Label
    Friend WithEvents txtPuesto As System.Windows.Forms.Label
    Friend WithEvents pnlExtras As System.Windows.Forms.Panel
    Friend WithEvents lblExtras As System.Windows.Forms.Label
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents lblDatoExtra As System.Windows.Forms.RichTextBox
    Friend WithEvents ColReloj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAlta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBaja As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPuesto As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
