<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCapturaSubAusentismo
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
        Me.tabDatos = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.pnlAusentismo = New DevComponents.DotNetBar.PanelEx()
        Me.lblY = New DevComponents.DotNetBar.LabelX()
        Me.lblX = New DevComponents.DotNetBar.LabelX()
        Me.cmbLider = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.lblFecha = New DevComponents.DotNetBar.LabelX()
        Me.lblReloj = New DevComponents.DotNetBar.LabelX()
        Me.btnGuardar = New DevComponents.DotNetBar.ButtonX()
        Me.cmbSubAusentismo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txtComentarios = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblDato = New DevComponents.DotNetBar.LabelX()
        Me.btnCerrarPanel = New DevComponents.DotNetBar.ButtonX()
        Me.lblTexto = New System.Windows.Forms.Label()
        Me.dgvExtraAut = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ColumnReloj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnTurno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnDepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnClase = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.advSupervisores = New DevComponents.AdvTree.AdvTree()
        Me.Node1 = New DevComponents.AdvTree.Node()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle2 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle3 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle4 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle5 = New DevComponents.DotNetBar.ElementStyle()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.btnRefresh = New DevComponents.DotNetBar.ButtonX()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.cmbPeriodo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader()
        Me.btnPeriodoAnterior = New DevComponents.DotNetBar.ButtonX()
        Me.btnPeriodoSiguiente = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTituloPantalla = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.tabDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDatos.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.pnlAusentismo.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvExtraAut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        CType(Me.advSupervisores, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabDatos
        '
        '
        '
        '
        '
        '
        '
        Me.tabDatos.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.tabDatos.ControlBox.MenuBox.Name = ""
        Me.tabDatos.ControlBox.Name = ""
        Me.tabDatos.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabDatos.ControlBox.MenuBox, Me.tabDatos.ControlBox.CloseBox})
        Me.tabDatos.Controls.Add(Me.SuperTabControlPanel1)
        Me.tabDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabDatos.Location = New System.Drawing.Point(250, 0)
        Me.tabDatos.Name = "tabDatos"
        Me.tabDatos.ReorderTabsEnabled = True
        Me.tabDatos.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabDatos.SelectedTabIndex = 0
        Me.tabDatos.Size = New System.Drawing.Size(1074, 477)
        Me.tabDatos.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.tabDatos.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabDatos.TabIndex = 115
        Me.tabDatos.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.MultiLineFit
        Me.tabDatos.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1})
        Me.tabDatos.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.tabDatos.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.pnlAusentismo)
        Me.SuperTabControlPanel1.Controls.Add(Me.dgvExtraAut)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(973, 477)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        '
        'pnlAusentismo
        '
        Me.pnlAusentismo.AutoSize = True
        Me.pnlAusentismo.CanvasColor = System.Drawing.SystemColors.Control
        Me.pnlAusentismo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pnlAusentismo.Controls.Add(Me.lblY)
        Me.pnlAusentismo.Controls.Add(Me.lblX)
        Me.pnlAusentismo.Controls.Add(Me.cmbLider)
        Me.pnlAusentismo.Controls.Add(Me.lblFecha)
        Me.pnlAusentismo.Controls.Add(Me.lblReloj)
        Me.pnlAusentismo.Controls.Add(Me.btnGuardar)
        Me.pnlAusentismo.Controls.Add(Me.cmbSubAusentismo)
        Me.pnlAusentismo.Controls.Add(Me.LabelX3)
        Me.pnlAusentismo.Controls.Add(Me.LabelX2)
        Me.pnlAusentismo.Controls.Add(Me.LabelX1)
        Me.pnlAusentismo.Controls.Add(Me.txtComentarios)
        Me.pnlAusentismo.Controls.Add(Me.Line1)
        Me.pnlAusentismo.Controls.Add(Me.Panel3)
        Me.pnlAusentismo.Controls.Add(Me.lblTexto)
        Me.pnlAusentismo.DisabledBackColor = System.Drawing.Color.Empty
        Me.pnlAusentismo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlAusentismo.Location = New System.Drawing.Point(369, 70)
        Me.pnlAusentismo.Name = "pnlAusentismo"
        Me.pnlAusentismo.Padding = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.pnlAusentismo.ShowFocusRectangle = True
        Me.pnlAusentismo.Size = New System.Drawing.Size(363, 341)
        Me.pnlAusentismo.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pnlAusentismo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.pnlAusentismo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pnlAusentismo.Style.BorderColor.Color = System.Drawing.SystemColors.AppWorkspace
        Me.pnlAusentismo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.pnlAusentismo.Style.GradientAngle = 90
        Me.pnlAusentismo.TabIndex = 158
        Me.pnlAusentismo.Visible = False
        '
        'lblY
        '
        '
        '
        '
        Me.lblY.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblY.Location = New System.Drawing.Point(249, 126)
        Me.lblY.Name = "lblY"
        Me.lblY.Size = New System.Drawing.Size(35, 23)
        Me.lblY.TabIndex = 172
        Me.lblY.Text = "LabelX4"
        Me.lblY.Visible = False
        '
        'lblX
        '
        '
        '
        '
        Me.lblX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblX.Location = New System.Drawing.Point(205, 126)
        Me.lblX.Name = "lblX"
        Me.lblX.Size = New System.Drawing.Size(37, 23)
        Me.lblX.TabIndex = 171
        Me.lblX.Text = "LabelX4"
        Me.lblX.Visible = False
        '
        'cmbLider
        '
        Me.cmbLider.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbLider.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbLider.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbLider.ButtonDropDown.Visible = True
        Me.cmbLider.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbLider.Location = New System.Drawing.Point(61, 48)
        Me.cmbLider.Name = "cmbLider"
        Me.cmbLider.Size = New System.Drawing.Size(288, 23)
        Me.cmbLider.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbLider.TabIndex = 170
        '
        'lblFecha
        '
        '
        '
        '
        Me.lblFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblFecha.Location = New System.Drawing.Point(160, 126)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(39, 23)
        Me.lblFecha.TabIndex = 169
        Me.lblFecha.Text = "LabelX4"
        Me.lblFecha.Visible = False
        '
        'lblReloj
        '
        '
        '
        '
        Me.lblReloj.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblReloj.Location = New System.Drawing.Point(111, 126)
        Me.lblReloj.Name = "lblReloj"
        Me.lblReloj.Size = New System.Drawing.Size(43, 23)
        Me.lblReloj.TabIndex = 168
        Me.lblReloj.Text = "LabelX4"
        Me.lblReloj.Visible = False
        '
        'btnGuardar
        '
        Me.btnGuardar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGuardar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGuardar.Location = New System.Drawing.Point(139, 246)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGuardar.TabIndex = 167
        Me.btnGuardar.Text = "Guardar"
        '
        'cmbSubAusentismo
        '
        Me.cmbSubAusentismo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbSubAusentismo.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbSubAusentismo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbSubAusentismo.ButtonDropDown.Visible = True
        Me.cmbSubAusentismo.DropDownHeight = 150
        Me.cmbSubAusentismo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbSubAusentismo.Location = New System.Drawing.Point(128, 92)
        Me.cmbSubAusentismo.Name = "cmbSubAusentismo"
        Me.cmbSubAusentismo.Size = New System.Drawing.Size(221, 24)
        Me.cmbSubAusentismo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbSubAusentismo.TabIndex = 165
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(11, 93)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(110, 23)
        Me.LabelX3.TabIndex = 164
        Me.LabelX3.Text = "SubAusentismo"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(10, 49)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(44, 23)
        Me.LabelX2.TabIndex = 162
        Me.LabelX2.Text = "Lider"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(11, 126)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(94, 23)
        Me.LabelX1.TabIndex = 161
        Me.LabelX1.Text = "Comentarios"
        '
        'txtComentarios
        '
        '
        '
        '
        Me.txtComentarios.Border.Class = "TextBoxBorder"
        Me.txtComentarios.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtComentarios.Location = New System.Drawing.Point(11, 155)
        Me.txtComentarios.Multiline = True
        Me.txtComentarios.Name = "txtComentarios"
        Me.txtComentarios.PreventEnterBeep = True
        Me.txtComentarios.Size = New System.Drawing.Size(342, 85)
        Me.txtComentarios.TabIndex = 160
        '
        'Line1
        '
        Me.Line1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Line1.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Line1.Location = New System.Drawing.Point(7, 34)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(349, 8)
        Me.Line1.TabIndex = 159
        Me.Line1.Text = "Line1"
        Me.Line1.Thickness = 2
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lblDato)
        Me.Panel3.Controls.Add(Me.btnCerrarPanel)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(7, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(349, 34)
        Me.Panel3.TabIndex = 158
        '
        'lblDato
        '
        '
        '
        '
        Me.lblDato.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDato.Location = New System.Drawing.Point(0, 0)
        Me.lblDato.Name = "lblDato"
        Me.lblDato.Size = New System.Drawing.Size(327, 34)
        Me.lblDato.TabIndex = 3
        Me.lblDato.Text = "Fecha"
        '
        'btnCerrarPanel
        '
        Me.btnCerrarPanel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrarPanel.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.btnCerrarPanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCerrarPanel.Image = Global.PIDA.My.Resources.Resources.x18
        Me.btnCerrarPanel.Location = New System.Drawing.Point(327, 0)
        Me.btnCerrarPanel.Name = "btnCerrarPanel"
        Me.btnCerrarPanel.Size = New System.Drawing.Size(22, 34)
        Me.btnCerrarPanel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrarPanel.TabIndex = 2
        '
        'lblTexto
        '
        Me.lblTexto.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblTexto.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblTexto.Location = New System.Drawing.Point(7, 275)
        Me.lblTexto.Name = "lblTexto"
        Me.lblTexto.Size = New System.Drawing.Size(349, 66)
        Me.lblTexto.TabIndex = 4
        Me.lblTexto.Text = "Text"
        Me.lblTexto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgvExtraAut
        '
        Me.dgvExtraAut.AllowUserToAddRows = False
        Me.dgvExtraAut.AllowUserToDeleteRows = False
        Me.dgvExtraAut.AllowUserToResizeColumns = False
        Me.dgvExtraAut.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExtraAut.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvExtraAut.ColumnHeadersHeight = 40
        Me.dgvExtraAut.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvExtraAut.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnReloj, Me.ColumnNombre, Me.ColumnTurno, Me.ColumnDepto, Me.ColumnClase})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(141, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvExtraAut.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvExtraAut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvExtraAut.EnableHeadersVisualStyles = False
        Me.dgvExtraAut.GridColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.dgvExtraAut.Location = New System.Drawing.Point(0, 0)
        Me.dgvExtraAut.MultiSelect = False
        Me.dgvExtraAut.Name = "dgvExtraAut"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExtraAut.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvExtraAut.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvExtraAut.Size = New System.Drawing.Size(973, 477)
        Me.dgvExtraAut.TabIndex = 114
        '
        'ColumnReloj
        '
        Me.ColumnReloj.Frozen = True
        Me.ColumnReloj.HeaderText = "Reloj"
        Me.ColumnReloj.Name = "ColumnReloj"
        Me.ColumnReloj.ReadOnly = True
        Me.ColumnReloj.Width = 50
        '
        'ColumnNombre
        '
        Me.ColumnNombre.Frozen = True
        Me.ColumnNombre.HeaderText = "Nombre"
        Me.ColumnNombre.Name = "ColumnNombre"
        Me.ColumnNombre.ReadOnly = True
        Me.ColumnNombre.Width = 200
        '
        'ColumnTurno
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.ColumnTurno.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColumnTurno.Frozen = True
        Me.ColumnTurno.HeaderText = "Hor."
        Me.ColumnTurno.Name = "ColumnTurno"
        Me.ColumnTurno.ReadOnly = True
        Me.ColumnTurno.Width = 50
        '
        'ColumnDepto
        '
        Me.ColumnDepto.Frozen = True
        Me.ColumnDepto.HeaderText = "Depto."
        Me.ColumnDepto.Name = "ColumnDepto"
        Me.ColumnDepto.ReadOnly = True
        Me.ColumnDepto.Width = 70
        '
        'ColumnClase
        '
        Me.ColumnClase.Frozen = True
        Me.ColumnClase.HeaderText = "Clase"
        Me.ColumnClase.Name = "ColumnClase"
        Me.ColumnClase.ReadOnly = True
        Me.ColumnClase.Width = 50
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Tiempo extra"
        Me.SuperTabItem1.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.SuperTabItem1.Visible = False
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.tabDatos)
        Me.Panel5.Controls.Add(Me.advSupervisores)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 101)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1324, 477)
        Me.Panel5.TabIndex = 119
        '
        'advSupervisores
        '
        Me.advSupervisores.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.advSupervisores.AllowDrop = True
        Me.advSupervisores.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.advSupervisores.BackgroundStyle.Class = "TreeBorderKey"
        Me.advSupervisores.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.advSupervisores.Dock = System.Windows.Forms.DockStyle.Left
        Me.advSupervisores.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.advSupervisores.Location = New System.Drawing.Point(0, 0)
        Me.advSupervisores.Name = "advSupervisores"
        Me.advSupervisores.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node1})
        Me.advSupervisores.NodesConnector = Me.NodeConnector1
        Me.advSupervisores.NodeStyle = Me.ElementStyle1
        Me.advSupervisores.PathSeparator = ";"
        Me.advSupervisores.Size = New System.Drawing.Size(250, 477)
        Me.advSupervisores.Styles.Add(Me.ElementStyle1)
        Me.advSupervisores.Styles.Add(Me.ElementStyle2)
        Me.advSupervisores.Styles.Add(Me.ElementStyle3)
        Me.advSupervisores.Styles.Add(Me.ElementStyle4)
        Me.advSupervisores.Styles.Add(Me.ElementStyle5)
        Me.advSupervisores.TabIndex = 116
        Me.advSupervisores.Text = "AdvTree1"
        '
        'Node1
        '
        Me.Node1.Expanded = True
        Me.Node1.Name = "Node1"
        Me.Node1.Style = Me.ElementStyle1
        Me.Node1.StyleSelected = Me.ElementStyle1
        Me.Node1.Text = "Node1"
        '
        'ElementStyle1
        '
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.TextColor = System.Drawing.SystemColors.ControlText
        '
        'NodeConnector1
        '
        Me.NodeConnector1.LineColor = System.Drawing.SystemColors.ControlText
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
        'ElementStyle3
        '
        Me.ElementStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ElementStyle3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ElementStyle3.BackColorGradientAngle = 90
        Me.ElementStyle3.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle3.BorderBottomWidth = 1
        Me.ElementStyle3.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle3.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle3.BorderLeftWidth = 1
        Me.ElementStyle3.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle3.BorderRightWidth = 1
        Me.ElementStyle3.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle3.BorderTopWidth = 1
        Me.ElementStyle3.CornerDiameter = 4
        Me.ElementStyle3.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle3.Description = "BlueLight"
        Me.ElementStyle3.Name = "ElementStyle3"
        Me.ElementStyle3.PaddingBottom = 1
        Me.ElementStyle3.PaddingLeft = 1
        Me.ElementStyle3.PaddingRight = 1
        Me.ElementStyle3.PaddingTop = 1
        Me.ElementStyle3.TextColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(115, Byte), Integer))
        '
        'ElementStyle4
        '
        Me.ElementStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ElementStyle4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.ElementStyle4.BackColorGradientAngle = 90
        Me.ElementStyle4.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle4.BorderBottomWidth = 1
        Me.ElementStyle4.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle4.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle4.BorderLeftWidth = 1
        Me.ElementStyle4.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle4.BorderRightWidth = 1
        Me.ElementStyle4.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle4.BorderTopWidth = 1
        Me.ElementStyle4.CornerDiameter = 4
        Me.ElementStyle4.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle4.Description = "Tan"
        Me.ElementStyle4.Name = "ElementStyle4"
        Me.ElementStyle4.PaddingBottom = 1
        Me.ElementStyle4.PaddingLeft = 1
        Me.ElementStyle4.PaddingRight = 1
        Me.ElementStyle4.PaddingTop = 1
        Me.ElementStyle4.TextColor = System.Drawing.Color.Black
        '
        'ElementStyle5
        '
        Me.ElementStyle5.BackColor = System.Drawing.Color.White
        Me.ElementStyle5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ElementStyle5.BackColorGradientAngle = 90
        Me.ElementStyle5.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle5.BorderBottomWidth = 1
        Me.ElementStyle5.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle5.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle5.BorderLeftWidth = 1
        Me.ElementStyle5.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle5.BorderRightWidth = 1
        Me.ElementStyle5.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle5.BorderTopWidth = 1
        Me.ElementStyle5.CornerDiameter = 4
        Me.ElementStyle5.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle5.Description = "Gray"
        Me.ElementStyle5.Name = "ElementStyle5"
        Me.ElementStyle5.PaddingBottom = 1
        Me.ElementStyle5.PaddingLeft = 1
        Me.ElementStyle5.PaddingRight = 1
        Me.ElementStyle5.PaddingTop = 1
        Me.ElementStyle5.TextColor = System.Drawing.Color.Black
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DataFieldName = "fecha_ini"
        Me.ColumnHeader4.Editable = False
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "Inicio"
        Me.ColumnHeader4.Width.Absolute = 100
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DataFieldName = "num_mes"
        Me.ColumnHeader3.Editable = False
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Periodo"
        Me.ColumnHeader3.Width.Absolute = 75
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "ano"
        Me.ColumnHeader2.Editable = False
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Año"
        Me.ColumnHeader2.Width.Absolute = 75
        '
        'btnRefresh
        '
        Me.btnRefresh.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnRefresh.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Image = Global.PIDA.My.Resources.Resources.refresh16
        Me.btnRefresh.Location = New System.Drawing.Point(445, 62)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(26, 26)
        Me.btnRefresh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnRefresh.TabIndex = 124
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "anoper"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Column"
        Me.ColumnHeader1.Visible = False
        Me.ColumnHeader1.Width.Absolute = 150
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.cmbPeriodo)
        Me.Panel4.Controls.Add(Me.btnPeriodoAnterior)
        Me.Panel4.Controls.Add(Me.btnPeriodoSiguiente)
        Me.Panel4.Location = New System.Drawing.Point(19, 62)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(420, 26)
        Me.Panel4.TabIndex = 121
        '
        'cmbPeriodo
        '
        Me.cmbPeriodo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPeriodo.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPeriodo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPeriodo.ButtonDropDown.Visible = True
        Me.cmbPeriodo.Columns.Add(Me.ColumnHeader1)
        Me.cmbPeriodo.Columns.Add(Me.ColumnHeader2)
        Me.cmbPeriodo.Columns.Add(Me.ColumnHeader3)
        Me.cmbPeriodo.Columns.Add(Me.ColumnHeader4)
        Me.cmbPeriodo.Columns.Add(Me.ColumnHeader5)
        Me.cmbPeriodo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPeriodo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPeriodo.Location = New System.Drawing.Point(25, 0)
        Me.cmbPeriodo.Name = "cmbPeriodo"
        Me.cmbPeriodo.Size = New System.Drawing.Size(370, 26)
        Me.cmbPeriodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPeriodo.TabIndex = 115
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DataFieldName = "fecha_fin"
        Me.ColumnHeader5.Editable = False
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.StretchToFill = True
        Me.ColumnHeader5.Text = "Fin"
        Me.ColumnHeader5.Width.Absolute = 100
        '
        'btnPeriodoAnterior
        '
        Me.btnPeriodoAnterior.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPeriodoAnterior.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPeriodoAnterior.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnPeriodoAnterior.Image = Global.PIDA.My.Resources.Resources.Prev16
        Me.btnPeriodoAnterior.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnPeriodoAnterior.Location = New System.Drawing.Point(0, 0)
        Me.btnPeriodoAnterior.Name = "btnPeriodoAnterior"
        Me.btnPeriodoAnterior.Size = New System.Drawing.Size(25, 26)
        Me.btnPeriodoAnterior.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPeriodoAnterior.TabIndex = 115
        Me.btnPeriodoAnterior.Tooltip = "Periodo anterior"
        '
        'btnPeriodoSiguiente
        '
        Me.btnPeriodoSiguiente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPeriodoSiguiente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPeriodoSiguiente.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnPeriodoSiguiente.Image = Global.PIDA.My.Resources.Resources.Next16
        Me.btnPeriodoSiguiente.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnPeriodoSiguiente.Location = New System.Drawing.Point(395, 0)
        Me.btnPeriodoSiguiente.Name = "btnPeriodoSiguiente"
        Me.btnPeriodoSiguiente.Size = New System.Drawing.Size(25, 26)
        Me.btnPeriodoSiguiente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPeriodoSiguiente.TabIndex = 114
        Me.btnPeriodoSiguiente.Tooltip = "Periodo siguiente"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnRefresh)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblTituloPantalla)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1324, 101)
        Me.Panel1.TabIndex = 117
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 117
        Me.Label2.Text = "Seleccionar mes"
        '
        'lblTituloPantalla
        '
        Me.lblTituloPantalla.AutoSize = True
        Me.lblTituloPantalla.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTituloPantalla.ForeColor = System.Drawing.Color.Black
        Me.lblTituloPantalla.Location = New System.Drawing.Point(12, 9)
        Me.lblTituloPantalla.Name = "lblTituloPantalla"
        Me.lblTituloPantalla.Size = New System.Drawing.Size(443, 37)
        Me.lblTituloPantalla.TabIndex = 114
        Me.lblTituloPantalla.Text = "Captura de Sub Ausentismo"
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 578)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1324, 29)
        Me.Panel2.TabIndex = 118
        '
        'frmCapturaSubAusentismo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1324, 607)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "frmCapturaSubAusentismo"
        Me.Text = "Captura Sub Ausentismo"
        CType(Me.tabDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDatos.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel1.PerformLayout()
        Me.pnlAusentismo.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.dgvExtraAut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        CType(Me.advSupervisores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabDatos As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents dgvExtraAut As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents advSupervisores As DevComponents.AdvTree.AdvTree
    Friend WithEvents Node1 As DevComponents.AdvTree.Node
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle2 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle3 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle4 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle5 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents btnRefresh As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents cmbPeriodo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents btnPeriodoAnterior As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPeriodoSiguiente As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblTituloPantalla As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ColumnReloj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnTurno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnDepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnClase As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlAusentismo As DevComponents.DotNetBar.PanelEx
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblDato As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnCerrarPanel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblTexto As System.Windows.Forms.Label
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtComentarios As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmbSubAusentismo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents btnGuardar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblReloj As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblFecha As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbLider As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents lblY As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblX As DevComponents.DotNetBar.LabelX
End Class
