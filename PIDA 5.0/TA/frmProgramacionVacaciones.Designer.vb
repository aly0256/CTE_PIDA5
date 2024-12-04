<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgramacionVacaciones
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProgramacionVacaciones))
        Me.dgvProgramacion = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ColumnReloj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnNombres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnCodDepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnHora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnDiasDisp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AdvTreeFiltros = New DevComponents.AdvTree.AdvTree()
        Me.Node1 = New DevComponents.AdvTree.Node()
        Me.ElementStyle8 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle11 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle10 = New DevComponents.DotNetBar.ElementStyle()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle9 = New DevComponents.DotNetBar.ElementStyle()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.labelAdmin = New System.Windows.Forms.Label()
        Me.LabelExtension = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LabelTermino = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LabelPeriodoVac = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LabelEstatus = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnGenerar = New DevComponents.DotNetBar.ButtonX()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TimerExtension = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dgvProgramacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdvTreeFiltros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvProgramacion
        '
        Me.dgvProgramacion.AllowUserToAddRows = False
        Me.dgvProgramacion.AllowUserToDeleteRows = False
        Me.dgvProgramacion.AllowUserToResizeColumns = False
        Me.dgvProgramacion.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProgramacion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProgramacion.ColumnHeadersHeight = 80
        Me.dgvProgramacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvProgramacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnReloj, Me.ColumnNombres, Me.ColumnCodDepto, Me.ColumnHora, Me.ColumnSaldo, Me.ColumnDiasDisp})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Lucida Sans", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(141, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvProgramacion.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvProgramacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProgramacion.EnableHeadersVisualStyles = False
        Me.dgvProgramacion.GridColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.dgvProgramacion.Location = New System.Drawing.Point(0, 0)
        Me.dgvProgramacion.Name = "dgvProgramacion"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProgramacion.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvProgramacion.Size = New System.Drawing.Size(814, 420)
        Me.dgvProgramacion.TabIndex = 0
        '
        'ColumnReloj
        '
        Me.ColumnReloj.DataPropertyName = "reloj"
        Me.ColumnReloj.Frozen = True
        Me.ColumnReloj.HeaderText = "Reloj"
        Me.ColumnReloj.Name = "ColumnReloj"
        Me.ColumnReloj.ReadOnly = True
        Me.ColumnReloj.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'ColumnNombres
        '
        Me.ColumnNombres.DataPropertyName = "nombres"
        Me.ColumnNombres.Frozen = True
        Me.ColumnNombres.HeaderText = "Nombres"
        Me.ColumnNombres.Name = "ColumnNombres"
        Me.ColumnNombres.ReadOnly = True
        Me.ColumnNombres.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColumnNombres.Width = 300
        '
        'ColumnCodDepto
        '
        Me.ColumnCodDepto.DataPropertyName = "cod_depto"
        Me.ColumnCodDepto.Frozen = True
        Me.ColumnCodDepto.HeaderText = "Depto."
        Me.ColumnCodDepto.Name = "ColumnCodDepto"
        Me.ColumnCodDepto.ReadOnly = True
        Me.ColumnCodDepto.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColumnCodDepto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColumnCodDepto.Visible = False
        '
        'ColumnHora
        '
        Me.ColumnHora.DataPropertyName = "cod_hora"
        Me.ColumnHora.Frozen = True
        Me.ColumnHora.HeaderText = "Horario"
        Me.ColumnHora.Name = "ColumnHora"
        Me.ColumnHora.ReadOnly = True
        Me.ColumnHora.Width = 50
        '
        'ColumnSaldo
        '
        Me.ColumnSaldo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColumnSaldo.DataPropertyName = "saldo"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColumnSaldo.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColumnSaldo.Frozen = True
        Me.ColumnSaldo.HeaderText = "Saldo"
        Me.ColumnSaldo.Name = "ColumnSaldo"
        Me.ColumnSaldo.ReadOnly = True
        Me.ColumnSaldo.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColumnSaldo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ColumnSaldo.Width = 50
        '
        'ColumnDiasDisp
        '
        Me.ColumnDiasDisp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ColumnDiasDisp.DataPropertyName = "dias_disp"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ColumnDiasDisp.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColumnDiasDisp.Frozen = True
        Me.ColumnDiasDisp.HeaderText = "Días disp."
        Me.ColumnDiasDisp.Name = "ColumnDiasDisp"
        Me.ColumnDiasDisp.ReadOnly = True
        Me.ColumnDiasDisp.Width = 50
        '
        'AdvTreeFiltros
        '
        Me.AdvTreeFiltros.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.AdvTreeFiltros.AllowDrop = True
        Me.AdvTreeFiltros.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.AdvTreeFiltros.BackgroundStyle.Class = "TreeBorderKey"
        Me.AdvTreeFiltros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.AdvTreeFiltros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdvTreeFiltros.ExpandButtonType = DevComponents.AdvTree.eExpandButtonType.Triangle
        Me.AdvTreeFiltros.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.AdvTreeFiltros.Location = New System.Drawing.Point(3, 3)
        Me.AdvTreeFiltros.Name = "AdvTreeFiltros"
        Me.AdvTreeFiltros.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node1})
        Me.AdvTreeFiltros.NodesConnector = Me.NodeConnector1
        Me.AdvTreeFiltros.PathSeparator = ";"
        Me.AdvTreeFiltros.Size = New System.Drawing.Size(294, 443)
        Me.AdvTreeFiltros.Styles.Add(Me.ElementStyle8)
        Me.AdvTreeFiltros.Styles.Add(Me.ElementStyle9)
        Me.AdvTreeFiltros.Styles.Add(Me.ElementStyle10)
        Me.AdvTreeFiltros.Styles.Add(Me.ElementStyle11)
        Me.AdvTreeFiltros.TabIndex = 1
        Me.AdvTreeFiltros.Text = "AdvTree1"
        '
        'Node1
        '
        Me.Node1.Expanded = True
        Me.Node1.FullRowBackground = True
        Me.Node1.Name = "Node1"
        Me.Node1.Selectable = False
        Me.Node1.Style = Me.ElementStyle8
        Me.Node1.StyleExpanded = Me.ElementStyle11
        Me.Node1.StyleSelected = Me.ElementStyle10
        Me.Node1.Text = "Node1"
        '
        'ElementStyle8
        '
        Me.ElementStyle8.BackColor = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.ElementStyle8.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(78, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(202, Byte), Integer))
        Me.ElementStyle8.BackColorGradientAngle = 90
        Me.ElementStyle8.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle8.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle8.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle8.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle8.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle8.CornerDiameter = 4
        Me.ElementStyle8.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle8.Description = "Teal"
        Me.ElementStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElementStyle8.Name = "ElementStyle8"
        Me.ElementStyle8.PaddingBottom = 1
        Me.ElementStyle8.PaddingLeft = 1
        Me.ElementStyle8.PaddingRight = 1
        Me.ElementStyle8.PaddingTop = 1
        Me.ElementStyle8.TextColor = System.Drawing.Color.Black
        Me.ElementStyle8.TextTrimming = DevComponents.DotNetBar.eStyleTextTrimming.None
        '
        'ElementStyle11
        '
        Me.ElementStyle11.BackColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ElementStyle11.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ElementStyle11.BackColorGradientAngle = 90
        Me.ElementStyle11.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle11.BorderBottomWidth = 1
        Me.ElementStyle11.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle11.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle11.BorderLeftWidth = 1
        Me.ElementStyle11.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle11.BorderRightWidth = 1
        Me.ElementStyle11.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle11.BorderTopWidth = 1
        Me.ElementStyle11.CornerDiameter = 4
        Me.ElementStyle11.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle11.Description = "Teal"
        Me.ElementStyle11.Name = "ElementStyle11"
        Me.ElementStyle11.PaddingBottom = 1
        Me.ElementStyle11.PaddingLeft = 1
        Me.ElementStyle11.PaddingRight = 1
        Me.ElementStyle11.PaddingTop = 1
        Me.ElementStyle11.TextColor = System.Drawing.Color.Black
        Me.ElementStyle11.TextTrimming = DevComponents.DotNetBar.eStyleTextTrimming.None
        '
        'ElementStyle10
        '
        Me.ElementStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.ElementStyle10.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.ElementStyle10.BackColorGradientAngle = 90
        Me.ElementStyle10.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle10.BorderBottomWidth = 1
        Me.ElementStyle10.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle10.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle10.BorderLeftWidth = 1
        Me.ElementStyle10.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle10.BorderRightWidth = 1
        Me.ElementStyle10.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle10.BorderTopWidth = 1
        Me.ElementStyle10.CornerDiameter = 4
        Me.ElementStyle10.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle10.Description = "Tan"
        Me.ElementStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElementStyle10.MarginBottom = -1
        Me.ElementStyle10.MarginTop = -1
        Me.ElementStyle10.Name = "ElementStyle10"
        Me.ElementStyle10.PaddingBottom = 1
        Me.ElementStyle10.PaddingLeft = 1
        Me.ElementStyle10.PaddingRight = 1
        Me.ElementStyle10.PaddingTop = 1
        Me.ElementStyle10.TextColor = System.Drawing.Color.Black
        Me.ElementStyle10.TextTrimming = DevComponents.DotNetBar.eStyleTextTrimming.None
        '
        'NodeConnector1
        '
        Me.NodeConnector1.LineColor = System.Drawing.SystemColors.ControlText
        '
        'ElementStyle9
        '
        Me.ElementStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ElementStyle9.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(205, Byte), Integer), CType(CType(236, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ElementStyle9.BackColorGradientAngle = 90
        Me.ElementStyle9.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle9.BorderBottomWidth = 1
        Me.ElementStyle9.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle9.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle9.BorderLeftWidth = 1
        Me.ElementStyle9.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle9.BorderRightWidth = 1
        Me.ElementStyle9.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle9.BorderTopWidth = 1
        Me.ElementStyle9.CornerDiameter = 4
        Me.ElementStyle9.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle9.Description = "Yellow"
        Me.ElementStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElementStyle9.Name = "ElementStyle9"
        Me.ElementStyle9.PaddingBottom = 1
        Me.ElementStyle9.PaddingLeft = 1
        Me.ElementStyle9.PaddingRight = 1
        Me.ElementStyle9.PaddingTop = 1
        Me.ElementStyle9.TextColor = System.Drawing.Color.Black
        Me.ElementStyle9.TextTrimming = DevComponents.DotNetBar.eStyleTextTrimming.None
        '
        'pnlTitulo
        '
        Me.pnlTitulo.BackColor = System.Drawing.Color.White
        Me.pnlTitulo.Controls.Add(Me.labelAdmin)
        Me.pnlTitulo.Controls.Add(Me.LabelExtension)
        Me.pnlTitulo.Controls.Add(Me.Label3)
        Me.pnlTitulo.Controls.Add(Me.LabelTermino)
        Me.pnlTitulo.Controls.Add(Me.Label2)
        Me.pnlTitulo.Controls.Add(Me.LabelPeriodoVac)
        Me.pnlTitulo.Controls.Add(Me.Label1)
        Me.pnlTitulo.Controls.Add(Me.picImagen)
        Me.pnlTitulo.Controls.Add(Me.Label4)
        Me.pnlTitulo.Controls.Add(Me.Label5)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(1120, 64)
        Me.pnlTitulo.TabIndex = 4
        '
        'labelAdmin
        '
        Me.labelAdmin.BackColor = System.Drawing.Color.PaleTurquoise
        Me.labelAdmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labelAdmin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelAdmin.ForeColor = System.Drawing.Color.DarkSlateGray
        Me.labelAdmin.Location = New System.Drawing.Point(460, 31)
        Me.labelAdmin.Name = "labelAdmin"
        Me.labelAdmin.Size = New System.Drawing.Size(60, 15)
        Me.labelAdmin.TabIndex = 115
        Me.labelAdmin.Text = "ADMIN"
        Me.labelAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.labelAdmin.Visible = False
        '
        'LabelExtension
        '
        Me.LabelExtension.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelExtension.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelExtension.ForeColor = System.Drawing.Color.Black
        Me.LabelExtension.Location = New System.Drawing.Point(54, 46)
        Me.LabelExtension.Name = "LabelExtension"
        Me.LabelExtension.Size = New System.Drawing.Size(400, 15)
        Me.LabelExtension.TabIndex = 3
        Me.LabelExtension.Text = "Extensión"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(713, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(404, 13)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "Marca con P los días que el empleado tomará como permiso sin goce."
        '
        'LabelTermino
        '
        Me.LabelTermino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelTermino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTermino.Location = New System.Drawing.Point(54, 31)
        Me.LabelTermino.Name = "LabelTermino"
        Me.LabelTermino.Size = New System.Drawing.Size(400, 15)
        Me.LabelTermino.TabIndex = 2
        Me.LabelTermino.Text = "Periodo de captura"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(690, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(427, 13)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "Marca con V los días que el empleado tomará de su saldo de vacaciones."
        '
        'LabelPeriodoVac
        '
        Me.LabelPeriodoVac.AutoSize = True
        Me.LabelPeriodoVac.Font = New System.Drawing.Font("Lucida Sans", 12.0!, System.Drawing.FontStyle.Bold)
        Me.LabelPeriodoVac.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LabelPeriodoVac.Location = New System.Drawing.Point(283, 12)
        Me.LabelPeriodoVac.Name = "LabelPeriodoVac"
        Me.LabelPeriodoVac.Size = New System.Drawing.Size(70, 18)
        Me.LabelPeriodoVac.TabIndex = 112
        Me.LabelPeriodoVac.Text = "Periodo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Lucida Sans", 12.0!)
        Me.Label1.Location = New System.Drawing.Point(50, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(227, 18)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "Programación de vacaciones"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.Calendario32
        Me.picImagen.Location = New System.Drawing.Point(12, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(32, 32)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picImagen.TabIndex = 110
        Me.picImagen.TabStop = False
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(713, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(403, 13)
        Me.Label4.TabIndex = 116
        Me.Label4.Text = "Deja en blanco los días que el empleado trabajará de manera regular."
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label5.Location = New System.Drawing.Point(780, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(336, 12)
        Me.Label5.TabIndex = 117
        Me.Label5.Text = "(Puedes escribir un ESPACIO para eliminar un registro capturado)"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.AdvTreeFiltros, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 64)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 449.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1120, 449)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvProgramacion)
        Me.Panel2.Controls.Add(Me.LabelEstatus)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(303, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(814, 443)
        Me.Panel2.TabIndex = 2
        '
        'LabelEstatus
        '
        Me.LabelEstatus.BackColor = System.Drawing.Color.White
        Me.LabelEstatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelEstatus.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LabelEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelEstatus.ForeColor = System.Drawing.Color.Black
        Me.LabelEstatus.Location = New System.Drawing.Point(0, 420)
        Me.LabelEstatus.Name = "LabelEstatus"
        Me.LabelEstatus.Size = New System.Drawing.Size(814, 23)
        Me.LabelEstatus.TabIndex = 1
        Me.LabelEstatus.Text = "Estatus"
        Me.LabelEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnGenerar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 513)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1120, 48)
        Me.Panel1.TabIndex = 7
        '
        'btnGenerar
        '
        Me.btnGenerar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerar.CausesValidation = False
        Me.btnGenerar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGenerar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnGenerar.Location = New System.Drawing.Point(1001, 5)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(106, 25)
        Me.btnGenerar.TabIndex = 1
        Me.btnGenerar.Text = "Reporte"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'TimerExtension
        '
        Me.TimerExtension.Interval = 20000
        '
        'frmProgramacionVacaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1120, 561)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProgramacionVacaciones"
        Me.Text = "Programación de vacaciones"
        CType(Me.dgvProgramacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdvTreeFiltros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvProgramacion As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents AdvTreeFiltros As DevComponents.AdvTree.AdvTree
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle9 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle8 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle10 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Node1 As DevComponents.AdvTree.Node
    Friend WithEvents ElementStyle11 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents LabelPeriodoVac As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents LabelEstatus As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnGenerar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelTermino As System.Windows.Forms.Label
    Friend WithEvents LabelExtension As System.Windows.Forms.Label
    Friend WithEvents TimerExtension As System.Windows.Forms.Timer
    Friend WithEvents labelAdmin As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ColumnReloj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnNombres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnCodDepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnHora As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnSaldo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnDiasDisp As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
