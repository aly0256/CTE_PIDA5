<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarVacantes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarVacantes))
        Me.txtBusca = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.groupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDepto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPlanta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtVacante = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtCodVacante = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblEstado = New DevComponents.DotNetBar.LabelX()
        Me.dgDatos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtSupervisor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.btnLast = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.btnNext = New DevComponents.DotNetBar.ButtonX()
        Me.btnFirst = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrev = New DevComponents.DotNetBar.ButtonX()
        Me.ColCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColVacante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSupervisor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPlanta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupPanel1.SuspendLayout()
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBusca
        '
        Me.txtBusca.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtBusca.Border.Class = "TextBoxBorder"
        Me.txtBusca.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBusca.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusca.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBusca.Location = New System.Drawing.Point(137, 19)
        Me.txtBusca.Name = "txtBusca"
        Me.txtBusca.Size = New System.Drawing.Size(543, 26)
        Me.txtBusca.TabIndex = 85
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(79, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 20)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "Buscar"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Busca48
        Me.PictureBox1.Location = New System.Drawing.Point(12, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(63, 46)
        Me.PictureBox1.TabIndex = 87
        Me.PictureBox1.TabStop = False
        '
        'groupPanel1
        '
        Me.groupPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.groupPanel1.BackColor = System.Drawing.SystemColors.Window
        Me.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.groupPanel1.Controls.Add(Me.Label4)
        Me.groupPanel1.Controls.Add(Me.txtDepto)
        Me.groupPanel1.Controls.Add(Me.Label3)
        Me.groupPanel1.Controls.Add(Me.txtPlanta)
        Me.groupPanel1.Controls.Add(Me.txtReloj)
        Me.groupPanel1.Controls.Add(Me.LabelX1)
        Me.groupPanel1.Controls.Add(Me.Label1)
        Me.groupPanel1.Controls.Add(Me.txtVacante)
        Me.groupPanel1.Controls.Add(Me.txtCodVacante)
        Me.groupPanel1.Controls.Add(Me.lblEstado)
        Me.groupPanel1.Controls.Add(Me.dgDatos)
        Me.groupPanel1.Controls.Add(Me.Label2)
        Me.groupPanel1.Controls.Add(Me.LabelX4)
        Me.groupPanel1.Controls.Add(Me.txtSupervisor)
        Me.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.groupPanel1.Location = New System.Drawing.Point(10, 52)
        Me.groupPanel1.Name = "groupPanel1"
        Me.groupPanel1.Size = New System.Drawing.Size(670, 284)
        '
        '
        '
        Me.groupPanel1.Style.BackColor = System.Drawing.SystemColors.Window
        Me.groupPanel1.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.groupPanel1.Style.BackColorGradientAngle = 90
        Me.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.groupPanel1.Style.BorderBottomWidth = 1
        Me.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.groupPanel1.Style.BorderLeftWidth = 1
        Me.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.groupPanel1.Style.BorderRightWidth = 1
        Me.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.groupPanel1.Style.BorderTopWidth = 1
        Me.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.groupPanel1.TabIndex = 88
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(319, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 17)
        Me.Label4.TabIndex = 82
        Me.Label4.Text = "Depto"
        '
        'txtDepto
        '
        Me.txtDepto.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtDepto.Border.Class = "TextBoxBorder"
        Me.txtDepto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDepto.Location = New System.Drawing.Point(379, 66)
        Me.txtDepto.Name = "txtDepto"
        Me.txtDepto.ReadOnly = True
        Me.txtDepto.Size = New System.Drawing.Size(277, 23)
        Me.txtDepto.TabIndex = 81
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 17)
        Me.Label3.TabIndex = 78
        Me.Label3.Text = "Planta"
        '
        'txtPlanta
        '
        Me.txtPlanta.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtPlanta.Border.Class = "TextBoxBorder"
        Me.txtPlanta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPlanta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlanta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPlanta.Location = New System.Drawing.Point(86, 66)
        Me.txtPlanta.Name = "txtPlanta"
        Me.txtPlanta.ReadOnly = True
        Me.txtPlanta.Size = New System.Drawing.Size(215, 23)
        Me.txtPlanta.TabIndex = 77
        '
        'txtReloj
        '
        Me.txtReloj.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtReloj.Location = New System.Drawing.Point(80, 36)
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.ReadOnly = True
        Me.txtReloj.Size = New System.Drawing.Size(108, 23)
        Me.txtReloj.TabIndex = 74
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(29, 37)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(45, 23)
        Me.LabelX1.TabIndex = 73
        Me.LabelX1.Text = "Reloj"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(211, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 17)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "Vacante"
        '
        'txtVacante
        '
        Me.txtVacante.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtVacante.Border.Class = "TextBoxBorder"
        Me.txtVacante.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtVacante.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVacante.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtVacante.Location = New System.Drawing.Point(284, 8)
        Me.txtVacante.Name = "txtVacante"
        Me.txtVacante.ReadOnly = True
        Me.txtVacante.Size = New System.Drawing.Size(372, 23)
        Me.txtVacante.TabIndex = 71
        '
        'txtCodVacante
        '
        Me.txtCodVacante.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtCodVacante.Border.Class = "TextBoxBorder"
        Me.txtCodVacante.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodVacante.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodVacante.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCodVacante.Location = New System.Drawing.Point(80, 8)
        Me.txtCodVacante.Name = "txtCodVacante"
        Me.txtCodVacante.ReadOnly = True
        Me.txtCodVacante.Size = New System.Drawing.Size(108, 23)
        Me.txtCodVacante.TabIndex = 70
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.Color.LimeGreen
        '
        '
        '
        Me.lblEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblEstado.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblEstado.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Window
        Me.lblEstado.Location = New System.Drawing.Point(0, 0)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(23, 274)
        Me.lblEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblEstado.TabIndex = 59
        Me.lblEstado.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblEstado.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.lblEstado.VerticalTextTopUp = False
        '
        'dgDatos
        '
        Me.dgDatos.AllowUserToAddRows = False
        Me.dgDatos.AllowUserToDeleteRows = False
        Me.dgDatos.AllowUserToOrderColumns = True
        Me.dgDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColCodigo, Me.ColVacante, Me.ColSupervisor, Me.ColPlanta, Me.ColDepto})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgDatos.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgDatos.EnableHeadersVisualStyles = False
        Me.dgDatos.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgDatos.Location = New System.Drawing.Point(27, 98)
        Me.dgDatos.MultiSelect = False
        Me.dgDatos.Name = "dgDatos"
        Me.dgDatos.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDatos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgDatos.RowHeadersVisible = False
        Me.dgDatos.Size = New System.Drawing.Size(629, 169)
        Me.dgDatos.TabIndex = 69
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(196, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 17)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Supervisor"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(28, 8)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(45, 23)
        Me.LabelX4.TabIndex = 67
        Me.LabelX4.Text = "Codigo"
        '
        'txtSupervisor
        '
        Me.txtSupervisor.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtSupervisor.Border.Class = "TextBoxBorder"
        Me.txtSupervisor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSupervisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupervisor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtSupervisor.Location = New System.Drawing.Point(284, 36)
        Me.txtSupervisor.Name = "txtSupervisor"
        Me.txtSupervisor.ReadOnly = True
        Me.txtSupervisor.Size = New System.Drawing.Size(372, 23)
        Me.txtSupervisor.TabIndex = 50
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Controls.Add(Me.btnLast)
        Me.GroupBox1.Controls.Add(Me.btnAceptar)
        Me.GroupBox1.Controls.Add(Me.btnNext)
        Me.GroupBox1.Controls.Add(Me.btnFirst)
        Me.GroupBox1.Controls.Add(Me.btnPrev)
        Me.GroupBox1.Location = New System.Drawing.Point(53, 337)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(584, 47)
        Me.GroupBox1.TabIndex = 89
        Me.GroupBox1.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelar.Location = New System.Drawing.Point(499, 13)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 52
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnLast
        '
        Me.btnLast.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLast.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLast.Image = Global.PIDA.My.Resources.Resources.Last16
        Me.btnLast.Location = New System.Drawing.Point(253, 13)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(78, 25)
        Me.btnLast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLast.TabIndex = 26
        Me.btnLast.Text = "Final"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.Location = New System.Drawing.Point(417, 13)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.TabIndex = 41
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnNext
        '
        Me.btnNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNext.Image = Global.PIDA.My.Resources.Resources.Next16
        Me.btnNext.Location = New System.Drawing.Point(171, 13)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(78, 25)
        Me.btnNext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNext.TabIndex = 25
        Me.btnNext.Text = "Siguiente"
        '
        'btnFirst
        '
        Me.btnFirst.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnFirst.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnFirst.Image = Global.PIDA.My.Resources.Resources.First16
        Me.btnFirst.Location = New System.Drawing.Point(7, 13)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(78, 25)
        Me.btnFirst.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnFirst.TabIndex = 23
        Me.btnFirst.Text = "Inicio"
        '
        'btnPrev
        '
        Me.btnPrev.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrev.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrev.Image = Global.PIDA.My.Resources.Resources.Prev16
        Me.btnPrev.Location = New System.Drawing.Point(89, 13)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(78, 25)
        Me.btnPrev.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrev.TabIndex = 24
        Me.btnPrev.Text = "Anterior"
        '
        'ColCodigo
        '
        Me.ColCodigo.DataPropertyName = "Cod_Vac"
        Me.ColCodigo.HeaderText = "Codigo"
        Me.ColCodigo.Name = "ColCodigo"
        Me.ColCodigo.ReadOnly = True
        Me.ColCodigo.Width = 65
        '
        'ColVacante
        '
        Me.ColVacante.DataPropertyName = "Vacante"
        Me.ColVacante.HeaderText = "Vacante"
        Me.ColVacante.Name = "ColVacante"
        Me.ColVacante.ReadOnly = True
        Me.ColVacante.Width = 72
        '
        'ColSupervisor
        '
        Me.ColSupervisor.DataPropertyName = "Supervisor"
        Me.ColSupervisor.HeaderText = "Supervisor"
        Me.ColSupervisor.Name = "ColSupervisor"
        Me.ColSupervisor.ReadOnly = True
        Me.ColSupervisor.Width = 82
        '
        'ColPlanta
        '
        Me.ColPlanta.DataPropertyName = "Planta"
        Me.ColPlanta.HeaderText = "Planta"
        Me.ColPlanta.Name = "ColPlanta"
        Me.ColPlanta.ReadOnly = True
        Me.ColPlanta.Width = 62
        '
        'ColDepto
        '
        Me.ColDepto.DataPropertyName = "Depto"
        Me.ColDepto.HeaderText = "Depto"
        Me.ColDepto.Name = "ColDepto"
        Me.ColDepto.ReadOnly = True
        Me.ColDepto.Width = 61
        '
        'frmBuscarVacantes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 389)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.groupPanel1)
        Me.Controls.Add(Me.txtBusca)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarVacantes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Buscar"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupPanel1.ResumeLayout(False)
        Me.groupPanel1.PerformLayout()
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtBusca As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents groupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtVacante As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtCodVacante As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblEstado As DevComponents.DotNetBar.LabelX
    Friend WithEvents dgDatos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtSupervisor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnLast As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNext As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnFirst As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrev As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDepto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPlanta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ColCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColVacante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSupervisor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPlanta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDepto As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
