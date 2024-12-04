<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPresentacionQuejas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPresentacionQuejas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.EmpNav = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrimero = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnAnterior = New DevComponents.DotNetBar.ButtonX()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnSiguiente = New DevComponents.DotNetBar.ButtonX()
        Me.btnUltimo = New DevComponents.DotNetBar.ButtonX()
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAlta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtSupervisor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTurno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtBaja = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblBaja = New System.Windows.Forms.Label()
        Me.txtDepartamento = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.picFoto = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblEstado = New DevComponents.DotNetBar.LabelX()
        Me.dgTabla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.cl_folio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_acusante = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_motivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.EmpNav.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'EmpNav
        '
        Me.EmpNav.Controls.Add(Me.btnBuscar)
        Me.EmpNav.Controls.Add(Me.btnCerrar)
        Me.EmpNav.Controls.Add(Me.btnPrimero)
        Me.EmpNav.Controls.Add(Me.btnReporte)
        Me.EmpNav.Controls.Add(Me.btnAnterior)
        Me.EmpNav.Controls.Add(Me.btnBorrar)
        Me.EmpNav.Controls.Add(Me.btnSiguiente)
        Me.EmpNav.Controls.Add(Me.btnUltimo)
        Me.EmpNav.Controls.Add(Me.btnEditar)
        Me.EmpNav.Controls.Add(Me.btnNuevo)
        Me.EmpNav.Location = New System.Drawing.Point(12, 12)
        Me.EmpNav.Name = "EmpNav"
        Me.EmpNav.Size = New System.Drawing.Size(1245, 47)
        Me.EmpNav.TabIndex = 96
        Me.EmpNav.TabStop = False
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscar.Location = New System.Drawing.Point(709, 14)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(78, 25)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 59
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Tooltip = "Buscar"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(1153, 14)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 58
        Me.btnCerrar.Text = "Salir"
        '
        'btnPrimero
        '
        Me.btnPrimero.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrimero.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrimero.Image = Global.PIDA.My.Resources.Resources.First16
        Me.btnPrimero.Location = New System.Drawing.Point(9, 14)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(78, 25)
        Me.btnPrimero.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrimero.TabIndex = 23
        Me.btnPrimero.Text = "Inicio"
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Enabled = False
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnReporte.Location = New System.Drawing.Point(791, 14)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 57
        Me.btnReporte.Text = "Reporte"
        Me.btnReporte.Visible = False
        '
        'btnAnterior
        '
        Me.btnAnterior.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAnterior.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAnterior.Image = Global.PIDA.My.Resources.Resources.Prev16
        Me.btnAnterior.Location = New System.Drawing.Point(90, 14)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(78, 25)
        Me.btnAnterior.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAnterior.TabIndex = 24
        Me.btnAnterior.Text = "Anterior"
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = Global.PIDA.My.Resources.Resources.DeleteRec
        Me.btnBorrar.Location = New System.Drawing.Point(1053, 14)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(78, 25)
        Me.btnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBorrar.TabIndex = 56
        Me.btnBorrar.Text = "Borrar"
        '
        'btnSiguiente
        '
        Me.btnSiguiente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSiguiente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSiguiente.Image = Global.PIDA.My.Resources.Resources.Next16
        Me.btnSiguiente.Location = New System.Drawing.Point(171, 14)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(78, 25)
        Me.btnSiguiente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSiguiente.TabIndex = 25
        Me.btnSiguiente.Text = "Siguiente"
        '
        'btnUltimo
        '
        Me.btnUltimo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnUltimo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnUltimo.Image = Global.PIDA.My.Resources.Resources.Last16
        Me.btnUltimo.Location = New System.Drawing.Point(252, 14)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(78, 25)
        Me.btnUltimo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnUltimo.TabIndex = 26
        Me.btnUltimo.Text = "Final"
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = Global.PIDA.My.Resources.Resources.Edit
        Me.btnEditar.Location = New System.Drawing.Point(972, 14)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(78, 25)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 53
        Me.btnEditar.Text = "Editar"
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.NewRecord
        Me.btnNuevo.Location = New System.Drawing.Point(891, 14)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 25)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 52
        Me.btnNuevo.Text = "Agregar"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 15)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Departamento"
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
        Me.txtAlta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtAlta.Location = New System.Drawing.Point(116, 64)
        Me.txtAlta.Name = "txtAlta"
        Me.txtAlta.ReadOnly = True
        Me.txtAlta.Size = New System.Drawing.Size(84, 21)
        Me.txtAlta.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 15)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Fecha de alta"
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
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNombre.Location = New System.Drawing.Point(107, 21)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(684, 23)
        Me.txtNombre.TabIndex = 2
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
        Me.txtSupervisor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtSupervisor.Location = New System.Drawing.Point(107, 58)
        Me.txtSupervisor.Name = "txtSupervisor"
        Me.txtSupervisor.ReadOnly = True
        Me.txtSupervisor.Size = New System.Drawing.Size(282, 21)
        Me.txtSupervisor.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 15)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Supervisor"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(407, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 15)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Turno"
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
        Me.txtTurno.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTurno.Location = New System.Drawing.Point(483, 58)
        Me.txtTurno.Name = "txtTurno"
        Me.txtTurno.ReadOnly = True
        Me.txtTurno.Size = New System.Drawing.Size(308, 21)
        Me.txtTurno.TabIndex = 115
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtReloj)
        Me.GroupBox2.Controls.Add(Me.LabelX4)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(200, 51)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'txtReloj
        '
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.Enabled = False
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.Location = New System.Drawing.Point(106, 16)
        Me.txtReloj.MaxLength = 6
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.Size = New System.Drawing.Size(84, 26)
        Me.txtReloj.TabIndex = 1
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(12, 16)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(84, 23)
        Me.LabelX4.TabIndex = 0
        Me.LabelX4.Text = "Reloj"
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
        Me.txtBaja.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBaja.Location = New System.Drawing.Point(116, 88)
        Me.txtBaja.Name = "txtBaja"
        Me.txtBaja.ReadOnly = True
        Me.txtBaja.Size = New System.Drawing.Size(84, 21)
        Me.txtBaja.TabIndex = 117
        '
        'lblBaja
        '
        Me.lblBaja.AutoSize = True
        Me.lblBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBaja.Location = New System.Drawing.Point(18, 91)
        Me.lblBaja.Name = "lblBaja"
        Me.lblBaja.Size = New System.Drawing.Size(85, 15)
        Me.lblBaja.TabIndex = 116
        Me.lblBaja.Text = "Fecha de baja"
        '
        'txtDepartamento
        '
        Me.txtDepartamento.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtDepartamento.Border.Class = "TextBoxBorder"
        Me.txtDepartamento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDepartamento.Enabled = False
        Me.txtDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepartamento.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDepartamento.Location = New System.Drawing.Point(107, 86)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.ReadOnly = True
        Me.txtDepartamento.Size = New System.Drawing.Size(282, 21)
        Me.txtDepartamento.TabIndex = 118
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.lblEstado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1269, 121)
        Me.Panel1.TabIndex = 3
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.picFoto)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(1179, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(78, 121)
        Me.Panel6.TabIndex = 255
        '
        'picFoto
        '
        Me.picFoto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picFoto.ErrorImage = CType(resources.GetObject("picFoto.ErrorImage"), System.Drawing.Image)
        Me.picFoto.Location = New System.Drawing.Point(0, 0)
        Me.picFoto.MaximumSize = New System.Drawing.Size(164, 210)
        Me.picFoto.MinimumSize = New System.Drawing.Size(78, 100)
        Me.picFoto.Name = "picFoto"
        Me.picFoto.Size = New System.Drawing.Size(78, 121)
        Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picFoto.TabIndex = 255
        Me.picFoto.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtBaja)
        Me.Panel2.Controls.Add(Me.txtAlta)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.lblBaja)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(956, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(223, 121)
        Me.Panel2.TabIndex = 101
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtNombre)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.txtDepartamento)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.txtSupervisor)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.txtTurno)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(29, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(927, 121)
        Me.Panel3.TabIndex = 102
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nombre"
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
        Me.lblEstado.ForeColor = System.Drawing.Color.White
        Me.lblEstado.Location = New System.Drawing.Point(0, 0)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(29, 121)
        Me.lblEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblEstado.TabIndex = 254
        Me.lblEstado.Text = "ACTIVO"
        Me.lblEstado.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblEstado.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.lblEstado.VerticalTextTopUp = False
        '
        'dgTabla
        '
        Me.dgTabla.AllowUserToAddRows = False
        Me.dgTabla.AllowUserToDeleteRows = False
        Me.dgTabla.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTabla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgTabla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cl_folio, Me.col_acusante, Me.Column1, Me.Column3, Me.col_motivo, Me.Column8, Me.Column6, Me.Column7})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTabla.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgTabla.EnableHeadersVisualStyles = False
        Me.dgTabla.GridColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.dgTabla.Location = New System.Drawing.Point(9, 19)
        Me.dgTabla.Name = "dgTabla"
        Me.dgTabla.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTabla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgTabla.RowHeadersVisible = False
        Me.dgTabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgTabla.Size = New System.Drawing.Size(1222, 234)
        Me.dgTabla.TabIndex = 97
        '
        'cl_folio
        '
        Me.cl_folio.DataPropertyName = "folio"
        Me.cl_folio.FillWeight = 40.60914!
        Me.cl_folio.HeaderText = "FOLIO"
        Me.cl_folio.Name = "cl_folio"
        Me.cl_folio.ReadOnly = True
        Me.cl_folio.Visible = False
        Me.cl_folio.Width = 5
        '
        'col_acusante
        '
        Me.col_acusante.DataPropertyName = "acusante"
        Me.col_acusante.HeaderText = "Reloj"
        Me.col_acusante.Name = "col_acusante"
        Me.col_acusante.ReadOnly = True
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "fecha_captura"
        Me.Column1.HeaderText = "Fecha"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 80
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "cod_motivo"
        Me.Column3.HeaderText = "Código"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        Me.Column3.Width = 60
        '
        'col_motivo
        '
        Me.col_motivo.DataPropertyName = "motivo"
        Me.col_motivo.HeaderText = "Motivo"
        Me.col_motivo.Name = "col_motivo"
        Me.col_motivo.ReadOnly = True
        Me.col_motivo.Width = 350
        '
        'Column8
        '
        Me.Column8.DataPropertyName = "fecha_incidencia"
        Me.Column8.HeaderText = "Fecha incidencia"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.Width = 80
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column6.DataPropertyName = "coment_super"
        Me.Column6.HeaderText = "Comentarios supervisor"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "coment_empleado"
        Me.Column7.HeaderText = "Comentarios empleado"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Width = 200
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dgTabla)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 25)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1245, 263)
        Me.GroupBox3.TabIndex = 100
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Quejas sobre empleado"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GroupBox3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 121)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1269, 342)
        Me.Panel4.TabIndex = 101
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.EmpNav)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 522)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(1269, 71)
        Me.Panel5.TabIndex = 102
        '
        'frmPresentacionQuejas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1269, 593)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPresentacionQuejas"
        Me.Text = "Presentación de quejas"
        Me.EmpNav.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EmpNav As System.Windows.Forms.GroupBox
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrimero As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAnterior As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSiguiente As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnUltimo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAlta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtSupervisor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTurno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtBaja As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblBaja As System.Windows.Forms.Label
    Friend WithEvents txtDepartamento As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblEstado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgTabla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents picFoto As System.Windows.Forms.PictureBox
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents cl_folio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_acusante As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_motivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
