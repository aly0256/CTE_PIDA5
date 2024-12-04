<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNomina
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNomina))
        Me.colaño = New DevComponents.AdvTree.ColumnHeader()
        Me.colperiodo = New DevComponents.AdvTree.ColumnHeader()
        Me.colinicio = New DevComponents.AdvTree.ColumnHeader()
        Me.colfin = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColNombre = New DevComponents.AdvTree.ColumnHeader()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnFirst = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrev = New DevComponents.DotNetBar.ButtonX()
        Me.btnNext = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnLast = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.cmbPeriodos = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader6 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader7 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader()
        Me.btnTotales = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblBaja = New System.Windows.Forms.Label()
        Me.txtAlta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtBaja = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.picFoto = New System.Windows.Forms.PictureBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.txtTipoEmp = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.txtClase = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.txtTurno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtHorario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblEstado = New DevComponents.DotNetBar.LabelX()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDepto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.txtSupervisor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.dgMovimientos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Concepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Descripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Monto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cod_Naturaleza = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipoPer = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader8 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader9 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.dgMovimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'colaño
        '
        Me.colaño.DataFieldName = "ano"
        Me.colaño.Name = "colaño"
        Me.colaño.Text = "Año"
        Me.colaño.Width.Absolute = 55
        '
        'colperiodo
        '
        Me.colperiodo.DataFieldName = "periodo"
        Me.colperiodo.Name = "colperiodo"
        Me.colperiodo.Text = "Periodo"
        Me.colperiodo.Width.Absolute = 50
        '
        'colinicio
        '
        Me.colinicio.DataFieldName = "fecha_ini"
        Me.colinicio.Name = "colinicio"
        Me.colinicio.StretchToFill = True
        Me.colinicio.Text = "Fecha Ini"
        Me.colinicio.Width.Absolute = 70
        '
        'colfin
        '
        Me.colfin.DataFieldName = "fecha_fin"
        Me.colfin.Name = "colfin"
        Me.colfin.StretchToFill = True
        Me.colfin.Text = "Fecha Fin"
        Me.colfin.Width.Absolute = 70
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "seleccionado"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Column"
        Me.ColumnHeader1.Visible = False
        Me.ColumnHeader1.Width.Absolute = 150
        '
        'ColNombre
        '
        Me.ColNombre.ColumnName = "nombre"
        Me.ColNombre.DataFieldName = "nombre"
        Me.ColNombre.Name = "ColNombre"
        Me.ColNombre.StretchToFill = True
        Me.ColNombre.Text = "Descripción"
        Me.ColNombre.Width.Absolute = 150
        Me.ColNombre.Width.AutoSize = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnFirst)
        Me.Panel1.Controls.Add(Me.btnPrev)
        Me.Panel1.Controls.Add(Me.btnNext)
        Me.Panel1.Controls.Add(Me.btnCerrar)
        Me.Panel1.Controls.Add(Me.btnLast)
        Me.Panel1.Controls.Add(Me.btnReporte)
        Me.Panel1.Controls.Add(Me.btnBuscar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 533)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1023, 35)
        Me.Panel1.TabIndex = 3
        '
        'btnFirst
        '
        Me.btnFirst.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnFirst.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnFirst.Image = Global.PIDA.My.Resources.Resources.First16
        Me.btnFirst.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnFirst.Location = New System.Drawing.Point(222, 3)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(78, 25)
        Me.btnFirst.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnFirst.TabIndex = 0
        Me.btnFirst.Text = "Inicio"
        '
        'btnPrev
        '
        Me.btnPrev.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrev.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrev.Image = Global.PIDA.My.Resources.Resources.Prev16
        Me.btnPrev.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnPrev.Location = New System.Drawing.Point(303, 3)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(78, 25)
        Me.btnPrev.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrev.TabIndex = 1
        Me.btnPrev.Text = "Anterior"
        '
        'btnNext
        '
        Me.btnNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNext.Image = Global.PIDA.My.Resources.Resources.Next16
        Me.btnNext.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnNext.Location = New System.Drawing.Point(384, 3)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(78, 25)
        Me.btnNext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "Siguiente"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(708, 3)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 6
        Me.btnCerrar.Text = "Salir"
        '
        'btnLast
        '
        Me.btnLast.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLast.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLast.Image = Global.PIDA.My.Resources.Resources.Last16
        Me.btnLast.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnLast.Location = New System.Drawing.Point(465, 3)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(78, 25)
        Me.btnLast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLast.TabIndex = 3
        Me.btnLast.Text = "Final"
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnReporte.Location = New System.Drawing.Point(627, 3)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 5
        Me.btnReporte.Text = "Reporte"
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBuscar.Location = New System.Drawing.Point(546, 3)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(78, 25)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Tooltip = "Buscar"
        '
        'cmbPeriodos
        '
        Me.cmbPeriodos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPeriodos.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPeriodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPeriodos.ButtonDropDown.Visible = True
        Me.cmbPeriodos.Columns.Add(Me.ColumnHeader6)
        Me.cmbPeriodos.Columns.Add(Me.ColumnHeader7)
        Me.cmbPeriodos.Columns.Add(Me.ColumnHeader2)
        Me.cmbPeriodos.Columns.Add(Me.ColumnHeader3)
        Me.cmbPeriodos.Columns.Add(Me.ColumnHeader4)
        Me.cmbPeriodos.Columns.Add(Me.ColumnHeader5)
        Me.cmbPeriodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPeriodos.FormatString = "d"
        Me.cmbPeriodos.FormattingEnabled = True
        Me.cmbPeriodos.KeyboardSearchNoSelectionAllowed = False
        Me.cmbPeriodos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPeriodos.Location = New System.Drawing.Point(80, 27)
        Me.cmbPeriodos.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.cmbPeriodos.Name = "cmbPeriodos"
        Me.cmbPeriodos.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect
        Me.cmbPeriodos.Size = New System.Drawing.Size(679, 23)
        Me.cmbPeriodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPeriodos.TabIndex = 0
        Me.cmbPeriodos.ValueMember = "seleccionado"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.DataFieldName = "seleccionado"
        Me.ColumnHeader6.Name = "ColumnHeader6"
        Me.ColumnHeader6.Text = "Column"
        Me.ColumnHeader6.Visible = False
        Me.ColumnHeader6.Width.Absolute = 150
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.DataFieldName = "ano"
        Me.ColumnHeader7.Name = "ColumnHeader7"
        Me.ColumnHeader7.Text = "Año"
        Me.ColumnHeader7.Width.Absolute = 70
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "periodo"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Periodo"
        Me.ColumnHeader2.Width.Absolute = 70
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DataFieldName = "fecha_ini"
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Fecha inicial"
        Me.ColumnHeader3.Width.Absolute = 100
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DataFieldName = "fecha_fin"
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "Fecha final"
        Me.ColumnHeader4.Width.Absolute = 100
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DataFieldName = "nombre"
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.StretchToFill = True
        Me.ColumnHeader5.Text = "Nombre"
        Me.ColumnHeader5.Width.Absolute = 150
        Me.ColumnHeader5.Width.AutoSize = True
        '
        'btnTotales
        '
        Me.btnTotales.Location = New System.Drawing.Point(772, 15)
        Me.btnTotales.Name = "btnTotales"
        Me.btnTotales.Size = New System.Drawing.Size(239, 23)
        Me.btnTotales.TabIndex = 248
        Me.btnTotales.Text = "Calcula TOTAL Per/Ded"
        Me.btnTotales.UseVisualStyleBackColor = True
        Me.btnTotales.Visible = False
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.Panel4)
        Me.Panel7.Controls.Add(Me.picFoto)
        Me.Panel7.Controls.Add(Me.Panel6)
        Me.Panel7.Controls.Add(Me.Panel2)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(1023, 113)
        Me.Panel7.TabIndex = 253
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.lblBaja)
        Me.Panel4.Controls.Add(Me.txtAlta)
        Me.Panel4.Controls.Add(Me.txtBaja)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(743, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(202, 113)
        Me.Panel4.TabIndex = 259
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LabelX4)
        Me.GroupBox1.Controls.Add(Me.txtReloj)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(171, 49)
        Me.GroupBox1.TabIndex = 133
        Me.GroupBox1.TabStop = False
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(11, 17)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(56, 23)
        Me.LabelX4.TabIndex = 36
        Me.LabelX4.Text = "Reloj"
        '
        'txtReloj
        '
        Me.txtReloj.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.ForeColor = System.Drawing.Color.Black
        Me.txtReloj.Location = New System.Drawing.Point(79, 15)
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.ReadOnly = True
        Me.txtReloj.Size = New System.Drawing.Size(84, 26)
        Me.txtReloj.TabIndex = 0
        Me.txtReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 135
        Me.Label2.Text = "Fecha de alta"
        '
        'lblBaja
        '
        Me.lblBaja.AutoSize = True
        Me.lblBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBaja.Location = New System.Drawing.Point(14, 89)
        Me.lblBaja.Name = "lblBaja"
        Me.lblBaja.Size = New System.Drawing.Size(85, 15)
        Me.lblBaja.TabIndex = 136
        Me.lblBaja.Text = "Fecha de baja"
        '
        'txtAlta
        '
        Me.txtAlta.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtAlta.Border.Class = "TextBoxBorder"
        Me.txtAlta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAlta.Enabled = False
        Me.txtAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlta.ForeColor = System.Drawing.Color.Black
        Me.txtAlta.Location = New System.Drawing.Point(105, 61)
        Me.txtAlta.Name = "txtAlta"
        Me.txtAlta.Size = New System.Drawing.Size(78, 21)
        Me.txtAlta.TabIndex = 169
        '
        'txtBaja
        '
        Me.txtBaja.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtBaja.Border.Class = "TextBoxBorder"
        Me.txtBaja.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBaja.Enabled = False
        Me.txtBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBaja.ForeColor = System.Drawing.Color.Black
        Me.txtBaja.Location = New System.Drawing.Point(105, 86)
        Me.txtBaja.Name = "txtBaja"
        Me.txtBaja.Size = New System.Drawing.Size(78, 21)
        Me.txtBaja.TabIndex = 170
        '
        'picFoto
        '
        Me.picFoto.Dock = System.Windows.Forms.DockStyle.Right
        Me.picFoto.ErrorImage = Global.PIDA.My.Resources.Resources.NoFoto
        Me.picFoto.Location = New System.Drawing.Point(945, 0)
        Me.picFoto.MaximumSize = New System.Drawing.Size(164, 210)
        Me.picFoto.MinimumSize = New System.Drawing.Size(78, 100)
        Me.picFoto.Name = "picFoto"
        Me.picFoto.Size = New System.Drawing.Size(78, 113)
        Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picFoto.TabIndex = 129
        Me.picFoto.TabStop = False
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label69)
        Me.Panel6.Controls.Add(Me.txtTipoEmp)
        Me.Panel6.Controls.Add(Me.Label68)
        Me.Panel6.Controls.Add(Me.txtClase)
        Me.Panel6.Controls.Add(Me.Label70)
        Me.Panel6.Controls.Add(Me.txtTurno)
        Me.Panel6.Controls.Add(Me.txtHorario)
        Me.Panel6.Controls.Add(Me.Label72)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(456, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(265, 113)
        Me.Panel6.TabIndex = 257
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.BackColor = System.Drawing.SystemColors.Control
        Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.Location = New System.Drawing.Point(3, 11)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(39, 15)
        Me.Label69.TabIndex = 147
        Me.Label69.Text = "Turno"
        '
        'txtTipoEmp
        '
        Me.txtTipoEmp.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtTipoEmp.Border.Class = "TextBoxBorder"
        Me.txtTipoEmp.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTipoEmp.Enabled = False
        Me.txtTipoEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoEmp.ForeColor = System.Drawing.Color.Black
        Me.txtTipoEmp.Location = New System.Drawing.Point(89, 58)
        Me.txtTipoEmp.Name = "txtTipoEmp"
        Me.txtTipoEmp.Size = New System.Drawing.Size(168, 21)
        Me.txtTipoEmp.TabIndex = 140
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.BackColor = System.Drawing.SystemColors.Control
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.Location = New System.Drawing.Point(4, 61)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(79, 15)
        Me.Label68.TabIndex = 141
        Me.Label68.Text = "Tipo de emp."
        '
        'txtClase
        '
        Me.txtClase.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtClase.Border.Class = "TextBoxBorder"
        Me.txtClase.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtClase.Enabled = False
        Me.txtClase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClase.ForeColor = System.Drawing.Color.Black
        Me.txtClase.Location = New System.Drawing.Point(88, 83)
        Me.txtClase.Name = "txtClase"
        Me.txtClase.Size = New System.Drawing.Size(168, 21)
        Me.txtClase.TabIndex = 144
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.BackColor = System.Drawing.SystemColors.Control
        Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.Location = New System.Drawing.Point(3, 86)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(38, 15)
        Me.Label70.TabIndex = 145
        Me.Label70.Text = "Clase"
        '
        'txtTurno
        '
        Me.txtTurno.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtTurno.Border.Class = "TextBoxBorder"
        Me.txtTurno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTurno.Enabled = False
        Me.txtTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTurno.ForeColor = System.Drawing.Color.Black
        Me.txtTurno.Location = New System.Drawing.Point(88, 8)
        Me.txtTurno.Name = "txtTurno"
        Me.txtTurno.Size = New System.Drawing.Size(168, 21)
        Me.txtTurno.TabIndex = 146
        '
        'txtHorario
        '
        Me.txtHorario.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtHorario.Border.Class = "TextBoxBorder"
        Me.txtHorario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtHorario.Enabled = False
        Me.txtHorario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorario.ForeColor = System.Drawing.Color.Black
        Me.txtHorario.Location = New System.Drawing.Point(88, 33)
        Me.txtHorario.Name = "txtHorario"
        Me.txtHorario.Size = New System.Drawing.Size(168, 21)
        Me.txtHorario.TabIndex = 148
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.BackColor = System.Drawing.SystemColors.Control
        Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.Location = New System.Drawing.Point(3, 36)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(48, 15)
        Me.Label72.TabIndex = 149
        Me.Label72.Text = "Horario"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblEstado)
        Me.Panel2.Controls.Add(Me.txtNombre)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.txtDepto)
        Me.Panel2.Controls.Add(Me.Label67)
        Me.Panel2.Controls.Add(Me.txtSupervisor)
        Me.Panel2.Controls.Add(Me.Label71)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(456, 113)
        Me.Panel2.TabIndex = 253
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
        Me.lblEstado.Size = New System.Drawing.Size(29, 113)
        Me.lblEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblEstado.TabIndex = 134
        Me.lblEstado.Text = "ACTIVO"
        Me.lblEstado.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblEstado.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.lblEstado.VerticalTextTopUp = False
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.Color.Black
        Me.txtNombre.Location = New System.Drawing.Point(39, 30)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(396, 21)
        Me.txtNombre.TabIndex = 126
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(39, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 15)
        Me.Label5.TabIndex = 130
        Me.Label5.Text = "Nombre"
        '
        'txtDepto
        '
        Me.txtDepto.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtDepto.Border.Class = "TextBoxBorder"
        Me.txtDepto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDepto.Enabled = False
        Me.txtDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepto.ForeColor = System.Drawing.Color.Black
        Me.txtDepto.Location = New System.Drawing.Point(138, 55)
        Me.txtDepto.Name = "txtDepto"
        Me.txtDepto.Size = New System.Drawing.Size(297, 21)
        Me.txtDepto.TabIndex = 138
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.BackColor = System.Drawing.SystemColors.Control
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.Location = New System.Drawing.Point(39, 58)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(86, 15)
        Me.Label67.TabIndex = 139
        Me.Label67.Text = "Departamento"
        '
        'txtSupervisor
        '
        Me.txtSupervisor.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtSupervisor.Border.Class = "TextBoxBorder"
        Me.txtSupervisor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSupervisor.Enabled = False
        Me.txtSupervisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupervisor.ForeColor = System.Drawing.Color.Black
        Me.txtSupervisor.Location = New System.Drawing.Point(138, 80)
        Me.txtSupervisor.Name = "txtSupervisor"
        Me.txtSupervisor.Size = New System.Drawing.Size(297, 21)
        Me.txtSupervisor.TabIndex = 142
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.BackColor = System.Drawing.SystemColors.Control
        Me.Label71.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.Location = New System.Drawing.Point(39, 83)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(65, 15)
        Me.Label71.TabIndex = 143
        Me.Label71.Text = "Supervisor"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel8)
        Me.Panel3.Controls.Add(Me.Panel5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 113)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1023, 420)
        Me.Panel3.TabIndex = 254
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.dgMovimientos)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(0, 61)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1023, 359)
        Me.Panel8.TabIndex = 252
        '
        'dgMovimientos
        '
        Me.dgMovimientos.AllowUserToAddRows = False
        Me.dgMovimientos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMovimientos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMovimientos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Concepto, Me.Descripcion, Me.Monto, Me.Cod_Naturaleza})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgMovimientos.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgMovimientos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgMovimientos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgMovimientos.EnableHeadersVisualStyles = False
        Me.dgMovimientos.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgMovimientos.Location = New System.Drawing.Point(0, 0)
        Me.dgMovimientos.Name = "dgMovimientos"
        Me.dgMovimientos.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgMovimientos.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgMovimientos.RowHeadersVisible = False
        Me.dgMovimientos.Size = New System.Drawing.Size(1023, 359)
        Me.dgMovimientos.TabIndex = 1
        '
        'Concepto
        '
        Me.Concepto.DataPropertyName = "concepto"
        Me.Concepto.HeaderText = "Concepto"
        Me.Concepto.Name = "Concepto"
        Me.Concepto.ReadOnly = True
        '
        'Descripcion
        '
        Me.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Descripcion.DataPropertyName = "descripcion"
        Me.Descripcion.HeaderText = "Descripción"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.ReadOnly = True
        '
        'Monto
        '
        Me.Monto.DataPropertyName = "monto"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.Monto.DefaultCellStyle = DataGridViewCellStyle2
        Me.Monto.HeaderText = "Monto"
        Me.Monto.Name = "Monto"
        Me.Monto.ReadOnly = True
        '
        'Cod_Naturaleza
        '
        Me.Cod_Naturaleza.DataPropertyName = "cod_naturaleza"
        Me.Cod_Naturaleza.HeaderText = "Naturaleza"
        Me.Cod_Naturaleza.Name = "Cod_Naturaleza"
        Me.Cod_Naturaleza.ReadOnly = True
        Me.Cod_Naturaleza.Visible = False
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Controls.Add(Me.cmbTipoPer)
        Me.Panel5.Controls.Add(Me.Label27)
        Me.Panel5.Controls.Add(Me.cmbPeriodos)
        Me.Panel5.Controls.Add(Me.btnTotales)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1023, 61)
        Me.Panel5.TabIndex = 249
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 17)
        Me.Label1.TabIndex = 250
        Me.Label1.Text = "Tipo"
        '
        'cmbTipoPer
        '
        Me.cmbTipoPer.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbTipoPer.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbTipoPer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbTipoPer.ButtonDropDown.Visible = True
        Me.cmbTipoPer.Columns.Add(Me.ColumnHeader8)
        Me.cmbTipoPer.Columns.Add(Me.ColumnHeader9)
        Me.cmbTipoPer.DisplayMembers = "Nombre,Tipo"
        Me.cmbTipoPer.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoPer.FormatString = "d"
        Me.cmbTipoPer.FormattingEnabled = True
        Me.cmbTipoPer.KeyboardSearchNoSelectionAllowed = False
        Me.cmbTipoPer.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbTipoPer.Location = New System.Drawing.Point(80, 3)
        Me.cmbTipoPer.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.cmbTipoPer.Name = "cmbTipoPer"
        Me.cmbTipoPer.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect
        Me.cmbTipoPer.Size = New System.Drawing.Size(679, 23)
        Me.cmbTipoPer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipoPer.TabIndex = 249
        Me.cmbTipoPer.ValueMember = "tipo_periodo"
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.DataFieldName = "tipo_periodo"
        Me.ColumnHeader8.Name = "ColumnHeader8"
        Me.ColumnHeader8.Text = "Tipo"
        Me.ColumnHeader8.Width.Absolute = 150
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.DataFieldName = "nombre"
        Me.ColumnHeader9.Name = "ColumnHeader9"
        Me.ColumnHeader9.Text = "Nombre"
        Me.ColumnHeader9.Width.Absolute = 150
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(12, 30)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(64, 17)
        Me.Label27.TabIndex = 247
        Me.Label27.Text = "Periodo"
        '
        'frmNomina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1023, 568)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmNomina"
        Me.Text = "Consulta de nómina"
        Me.Panel1.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        CType(Me.dgMovimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents colaño As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colperiodo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colinicio As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colfin As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColNombre As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnFirst As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrev As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNext As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnLast As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmbPeriodos As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader6 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader7 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents btnTotales As System.Windows.Forms.Button
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents picFoto As System.Windows.Forms.PictureBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents txtTipoEmp As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents txtClase As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents txtTurno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtHorario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblEstado As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDepto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents txtSupervisor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents dgMovimientos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Concepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Descripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Monto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cod_Naturaleza As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblBaja As System.Windows.Forms.Label
    Friend WithEvents txtAlta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtBaja As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoPer As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents ColumnHeader8 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader9 As DevComponents.AdvTree.ColumnHeader
End Class
