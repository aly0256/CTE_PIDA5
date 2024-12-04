<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHerramientasPersonal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHerramientasPersonal))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlControles = New System.Windows.Forms.Panel()
        Me.btnFirst = New DevComponents.DotNetBar.ButtonX()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrev = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnNext = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.btnLast = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtBaja = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtAlta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.picFoto = New System.Windows.Forms.PictureBox()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.txtHorario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.txtTurno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.txtClase = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.txtSupervisor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.txtTipoEmp = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.txtDepto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblBaja = New System.Windows.Forms.Label()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblEstado = New DevComponents.DotNetBar.LabelX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgTabla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.COD_ART = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clasificacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_SAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_ENT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Entregado = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.CONTROL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CANTIDAD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OBSERVACION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HORA_DEV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RECIBIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPuesto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblPlanta = New DevComponents.DotNetBar.LabelX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtArea = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Panel1.SuspendLayout()
        Me.pnlControles.SuspendLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlControles)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 507)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1008, 41)
        Me.Panel1.TabIndex = 268
        '
        'pnlControles
        '
        Me.pnlControles.Controls.Add(Me.btnFirst)
        Me.pnlControles.Controls.Add(Me.btnBuscar)
        Me.pnlControles.Controls.Add(Me.btnPrev)
        Me.pnlControles.Controls.Add(Me.btnReporte)
        Me.pnlControles.Controls.Add(Me.btnNext)
        Me.pnlControles.Controls.Add(Me.btnNuevo)
        Me.pnlControles.Controls.Add(Me.btnEditar)
        Me.pnlControles.Controls.Add(Me.btnLast)
        Me.pnlControles.Controls.Add(Me.btnCerrar)
        Me.pnlControles.Controls.Add(Me.btnBorrar)
        Me.pnlControles.Location = New System.Drawing.Point(102, 6)
        Me.pnlControles.Name = "pnlControles"
        Me.pnlControles.Size = New System.Drawing.Size(815, 30)
        Me.pnlControles.TabIndex = 43
        '
        'btnFirst
        '
        Me.btnFirst.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnFirst.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnFirst.Image = CType(resources.GetObject("btnFirst.Image"), System.Drawing.Image)
        Me.btnFirst.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnFirst.Location = New System.Drawing.Point(3, 3)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(78, 25)
        Me.btnFirst.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnFirst.TabIndex = 33
        Me.btnFirst.Text = "Inicio"
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBuscar.Location = New System.Drawing.Point(327, 3)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(78, 25)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 37
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Tooltip = "Buscar"
        '
        'btnPrev
        '
        Me.btnPrev.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrev.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrev.Image = CType(resources.GetObject("btnPrev.Image"), System.Drawing.Image)
        Me.btnPrev.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnPrev.Location = New System.Drawing.Point(84, 3)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(78, 25)
        Me.btnPrev.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrev.TabIndex = 34
        Me.btnPrev.Text = "Anterior"
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = CType(resources.GetObject("btnReporte.Image"), System.Drawing.Image)
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnReporte.Location = New System.Drawing.Point(408, 3)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 38
        Me.btnReporte.Text = "Reporte"
        '
        'btnNext
        '
        Me.btnNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNext.Image = CType(resources.GetObject("btnNext.Image"), System.Drawing.Image)
        Me.btnNext.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnNext.Location = New System.Drawing.Point(165, 3)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(78, 25)
        Me.btnNext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNext.TabIndex = 35
        Me.btnNext.Text = "Siguiente"
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnNuevo.Location = New System.Drawing.Point(489, 3)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 25)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 39
        Me.btnNuevo.Text = "Agregar"
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = CType(resources.GetObject("btnEditar.Image"), System.Drawing.Image)
        Me.btnEditar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnEditar.Location = New System.Drawing.Point(570, 3)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(78, 25)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 40
        Me.btnEditar.Text = "Editar"
        '
        'btnLast
        '
        Me.btnLast.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLast.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLast.Image = CType(resources.GetObject("btnLast.Image"), System.Drawing.Image)
        Me.btnLast.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnLast.Location = New System.Drawing.Point(246, 3)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(78, 25)
        Me.btnLast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLast.TabIndex = 36
        Me.btnLast.Text = "Final"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(732, 3)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 42
        Me.btnCerrar.Text = "Salir"
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = CType(resources.GetObject("btnBorrar.Image"), System.Drawing.Image)
        Me.btnBorrar.Location = New System.Drawing.Point(651, 3)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(78, 25)
        Me.btnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBorrar.TabIndex = 41
        Me.btnBorrar.Text = "Borrar"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'txtBaja
        '
        '
        '
        '
        Me.txtBaja.Border.Class = "TextBoxBorder"
        Me.txtBaja.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBaja.ButtonCustom.Tooltip = ""
        Me.txtBaja.ButtonCustom2.Tooltip = ""
        Me.txtBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBaja.ForeColor = System.Drawing.Color.Black
        Me.txtBaja.Location = New System.Drawing.Point(806, 93)
        Me.txtBaja.Name = "txtBaja"
        Me.txtBaja.ReadOnly = True
        Me.txtBaja.Size = New System.Drawing.Size(78, 21)
        Me.txtBaja.TabIndex = 270
        '
        'txtAlta
        '
        '
        '
        '
        Me.txtAlta.Border.Class = "TextBoxBorder"
        Me.txtAlta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAlta.ButtonCustom.Tooltip = ""
        Me.txtAlta.ButtonCustom2.Tooltip = ""
        Me.txtAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlta.ForeColor = System.Drawing.Color.Black
        Me.txtAlta.Location = New System.Drawing.Point(806, 63)
        Me.txtAlta.Name = "txtAlta"
        Me.txtAlta.ReadOnly = True
        Me.txtAlta.Size = New System.Drawing.Size(78, 21)
        Me.txtAlta.TabIndex = 269
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "concepto"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Código"
        Me.ColumnHeader1.Width.Absolute = 70
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "nombre"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.StretchToFill = True
        Me.ColumnHeader2.Text = "Nombre"
        Me.ColumnHeader2.Width.Absolute = 150
        Me.ColumnHeader2.Width.AutoSize = True
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DataFieldName = "numcredito"
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Núm. crédito"
        Me.ColumnHeader3.Width.Absolute = 150
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.BackColor = System.Drawing.SystemColors.Control
        Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.Location = New System.Drawing.Point(453, 38)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(48, 15)
        Me.Label72.TabIndex = 267
        Me.Label72.Text = "Horario"
        '
        'picFoto
        '
        Me.picFoto.ErrorImage = CType(resources.GetObject("picFoto.ErrorImage"), System.Drawing.Image)
        Me.picFoto.Location = New System.Drawing.Point(919, 11)
        Me.picFoto.MaximumSize = New System.Drawing.Size(164, 210)
        Me.picFoto.MinimumSize = New System.Drawing.Size(78, 100)
        Me.picFoto.Name = "picFoto"
        Me.picFoto.Size = New System.Drawing.Size(78, 100)
        Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picFoto.TabIndex = 250
        Me.picFoto.TabStop = False
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(34, 8)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(398, 40)
        Me.ReflectionLabel1.TabIndex = 272
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>HERRAMIENTAS  POR EMPLEADO</b></font>"
        '
        'txtHorario
        '
        '
        '
        '
        Me.txtHorario.Border.Class = "TextBoxBorder"
        Me.txtHorario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtHorario.ButtonCustom.Tooltip = ""
        Me.txtHorario.ButtonCustom2.Tooltip = ""
        Me.txtHorario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorario.ForeColor = System.Drawing.Color.Black
        Me.txtHorario.Location = New System.Drawing.Point(538, 35)
        Me.txtHorario.Name = "txtHorario"
        Me.txtHorario.ReadOnly = True
        Me.txtHorario.Size = New System.Drawing.Size(168, 21)
        Me.txtHorario.TabIndex = 266
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.BackColor = System.Drawing.SystemColors.Control
        Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.Location = New System.Drawing.Point(453, 11)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(39, 15)
        Me.Label69.TabIndex = 265
        Me.Label69.Text = "Turno"
        '
        'txtTurno
        '
        '
        '
        '
        Me.txtTurno.Border.Class = "TextBoxBorder"
        Me.txtTurno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTurno.ButtonCustom.Tooltip = ""
        Me.txtTurno.ButtonCustom2.Tooltip = ""
        Me.txtTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTurno.ForeColor = System.Drawing.Color.Black
        Me.txtTurno.Location = New System.Drawing.Point(538, 8)
        Me.txtTurno.Name = "txtTurno"
        Me.txtTurno.ReadOnly = True
        Me.txtTurno.Size = New System.Drawing.Size(168, 21)
        Me.txtTurno.TabIndex = 264
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.BackColor = System.Drawing.SystemColors.Control
        Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.Location = New System.Drawing.Point(453, 92)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(38, 15)
        Me.Label70.TabIndex = 263
        Me.Label70.Text = "Clase"
        '
        'txtClase
        '
        '
        '
        '
        Me.txtClase.Border.Class = "TextBoxBorder"
        Me.txtClase.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtClase.ButtonCustom.Tooltip = ""
        Me.txtClase.ButtonCustom2.Tooltip = ""
        Me.txtClase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClase.ForeColor = System.Drawing.Color.Black
        Me.txtClase.Location = New System.Drawing.Point(538, 89)
        Me.txtClase.Name = "txtClase"
        Me.txtClase.ReadOnly = True
        Me.txtClase.Size = New System.Drawing.Size(168, 21)
        Me.txtClase.TabIndex = 262
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.BackColor = System.Drawing.SystemColors.Control
        Me.Label71.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.Location = New System.Drawing.Point(36, 128)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(65, 15)
        Me.Label71.TabIndex = 261
        Me.Label71.Text = "Supervisor"
        '
        'txtSupervisor
        '
        '
        '
        '
        Me.txtSupervisor.Border.Class = "TextBoxBorder"
        Me.txtSupervisor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSupervisor.ButtonCustom.Tooltip = ""
        Me.txtSupervisor.ButtonCustom2.Tooltip = ""
        Me.txtSupervisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupervisor.ForeColor = System.Drawing.Color.Black
        Me.txtSupervisor.Location = New System.Drawing.Point(135, 125)
        Me.txtSupervisor.Name = "txtSupervisor"
        Me.txtSupervisor.ReadOnly = True
        Me.txtSupervisor.Size = New System.Drawing.Size(297, 21)
        Me.txtSupervisor.TabIndex = 260
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.BackColor = System.Drawing.SystemColors.Control
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.Location = New System.Drawing.Point(453, 65)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(79, 15)
        Me.Label68.TabIndex = 259
        Me.Label68.Text = "Tipo de emp."
        '
        'txtTipoEmp
        '
        '
        '
        '
        Me.txtTipoEmp.Border.Class = "TextBoxBorder"
        Me.txtTipoEmp.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTipoEmp.ButtonCustom.Tooltip = ""
        Me.txtTipoEmp.ButtonCustom2.Tooltip = ""
        Me.txtTipoEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoEmp.ForeColor = System.Drawing.Color.Black
        Me.txtTipoEmp.Location = New System.Drawing.Point(538, 62)
        Me.txtTipoEmp.Name = "txtTipoEmp"
        Me.txtTipoEmp.ReadOnly = True
        Me.txtTipoEmp.Size = New System.Drawing.Size(168, 21)
        Me.txtTipoEmp.TabIndex = 258
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.BackColor = System.Drawing.SystemColors.Control
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.Location = New System.Drawing.Point(36, 101)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(86, 15)
        Me.Label67.TabIndex = 257
        Me.Label67.Text = "Departamento"
        '
        'txtDepto
        '
        '
        '
        '
        Me.txtDepto.Border.Class = "TextBoxBorder"
        Me.txtDepto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDepto.ButtonCustom.Tooltip = ""
        Me.txtDepto.ButtonCustom2.Tooltip = ""
        Me.txtDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepto.ForeColor = System.Drawing.Color.Black
        Me.txtDepto.Location = New System.Drawing.Point(135, 98)
        Me.txtDepto.Name = "txtDepto"
        Me.txtDepto.ReadOnly = True
        Me.txtDepto.Size = New System.Drawing.Size(297, 21)
        Me.txtDepto.TabIndex = 256
        '
        'lblBaja
        '
        Me.lblBaja.AutoSize = True
        Me.lblBaja.BackColor = System.Drawing.SystemColors.Control
        Me.lblBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBaja.Location = New System.Drawing.Point(715, 96)
        Me.lblBaja.Name = "lblBaja"
        Me.lblBaja.Size = New System.Drawing.Size(85, 15)
        Me.lblBaja.TabIndex = 255
        Me.lblBaja.Text = "Fecha de baja"
        '
        'txtNombre
        '
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.ButtonCustom.Tooltip = ""
        Me.txtNombre.ButtonCustom2.Tooltip = ""
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.Color.Black
        Me.txtNombre.Location = New System.Drawing.Point(36, 71)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(396, 21)
        Me.txtNombre.TabIndex = 249
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(715, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 254
        Me.Label2.Text = "Fecha de alta"
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
        Me.lblEstado.Size = New System.Drawing.Size(29, 164)
        Me.lblEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblEstado.TabIndex = 253
        Me.lblEstado.Text = "ACTIVO"
        Me.lblEstado.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblEstado.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.lblEstado.VerticalTextTopUp = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(36, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 15)
        Me.Label5.TabIndex = 251
        Me.Label5.Text = "Nombre"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgTabla)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 164)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(10)
        Me.Panel2.Size = New System.Drawing.Size(1008, 343)
        Me.Panel2.TabIndex = 273
        '
        'dgTabla
        '
        Me.dgTabla.AllowUserToAddRows = False
        Me.dgTabla.AllowUserToDeleteRows = False
        Me.dgTabla.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTabla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgTabla.ColumnHeadersHeight = 40
        Me.dgTabla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.COD_ART, Me.Nombre, Me.Clasificacion, Me.FECHA_SAL, Me.FECHA_ENT, Me.Entregado, Me.CONTROL, Me.CANTIDAD, Me.OBSERVACION, Me.HORA_DEV, Me.RECIBIO})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTabla.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgTabla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTabla.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgTabla.Location = New System.Drawing.Point(10, 10)
        Me.dgTabla.MultiSelect = False
        Me.dgTabla.Name = "dgTabla"
        Me.dgTabla.ReadOnly = True
        Me.dgTabla.RowHeadersVisible = False
        Me.dgTabla.RowHeadersWidth = 20
        Me.dgTabla.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window
        Me.dgTabla.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dgTabla.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgTabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgTabla.Size = New System.Drawing.Size(988, 323)
        Me.dgTabla.TabIndex = 3
        '
        'COD_ART
        '
        Me.COD_ART.DataPropertyName = "COD_ART"
        Me.COD_ART.HeaderText = "Código"
        Me.COD_ART.Name = "COD_ART"
        Me.COD_ART.ReadOnly = True
        Me.COD_ART.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.COD_ART.Width = 70
        '
        'Nombre
        '
        Me.Nombre.DataPropertyName = "NOMBRE"
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        Me.Nombre.Width = 200
        '
        'Clasificacion
        '
        Me.Clasificacion.DataPropertyName = "CLASIFICACION"
        Me.Clasificacion.HeaderText = "Clasificación"
        Me.Clasificacion.Name = "Clasificacion"
        Me.Clasificacion.ReadOnly = True
        Me.Clasificacion.Width = 200
        '
        'FECHA_SAL
        '
        Me.FECHA_SAL.DataPropertyName = "FECHA_SAL"
        Me.FECHA_SAL.HeaderText = "Fecha préstamo"
        Me.FECHA_SAL.Name = "FECHA_SAL"
        Me.FECHA_SAL.ReadOnly = True
        Me.FECHA_SAL.Width = 80
        '
        'FECHA_ENT
        '
        Me.FECHA_ENT.DataPropertyName = "FECHA_ENT"
        Me.FECHA_ENT.HeaderText = "Fecha reemplazo"
        Me.FECHA_ENT.Name = "FECHA_ENT"
        Me.FECHA_ENT.ReadOnly = True
        Me.FECHA_ENT.Width = 80
        '
        'Entregado
        '
        Me.Entregado.Checked = True
        Me.Entregado.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Entregado.CheckValue = "N"
        Me.Entregado.CheckValueChecked = "1"
        Me.Entregado.CheckValueUnchecked = "0"
        Me.Entregado.DataPropertyName = "ENTREGADO"
        Me.Entregado.HeaderText = "Devuelto"
        Me.Entregado.Name = "Entregado"
        Me.Entregado.ReadOnly = True
        Me.Entregado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Entregado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Entregado.Width = 65
        '
        'CONTROL
        '
        Me.CONTROL.DataPropertyName = "CONTROL"
        Me.CONTROL.HeaderText = "Control"
        Me.CONTROL.Name = "CONTROL"
        Me.CONTROL.ReadOnly = True
        Me.CONTROL.Width = 55
        '
        'CANTIDAD
        '
        Me.CANTIDAD.DataPropertyName = "CANTIDAD"
        Me.CANTIDAD.HeaderText = "Cantidad"
        Me.CANTIDAD.Name = "CANTIDAD"
        Me.CANTIDAD.ReadOnly = True
        Me.CANTIDAD.Width = 65
        '
        'OBSERVACION
        '
        Me.OBSERVACION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.OBSERVACION.DataPropertyName = "OBSERVACION"
        Me.OBSERVACION.HeaderText = "Observación"
        Me.OBSERVACION.Name = "OBSERVACION"
        Me.OBSERVACION.ReadOnly = True
        '
        'HORA_DEV
        '
        Me.HORA_DEV.DataPropertyName = "FECHA_DEV"
        Me.HORA_DEV.HeaderText = "Devolución"
        Me.HORA_DEV.Name = "HORA_DEV"
        Me.HORA_DEV.ReadOnly = True
        '
        'RECIBIO
        '
        Me.RECIBIO.DataPropertyName = "USUARIO"
        Me.RECIBIO.HeaderText = "Recibido por"
        Me.RECIBIO.Name = "RECIBIO"
        Me.RECIBIO.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(453, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 15)
        Me.Label1.TabIndex = 276
        Me.Label1.Text = "Puesto"
        '
        'txtPuesto
        '
        '
        '
        '
        Me.txtPuesto.Border.Class = "TextBoxBorder"
        Me.txtPuesto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPuesto.ButtonCustom.Tooltip = ""
        Me.txtPuesto.ButtonCustom2.Tooltip = ""
        Me.txtPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPuesto.ForeColor = System.Drawing.Color.Black
        Me.txtPuesto.Location = New System.Drawing.Point(538, 116)
        Me.txtPuesto.Name = "txtPuesto"
        Me.txtPuesto.ReadOnly = True
        Me.txtPuesto.Size = New System.Drawing.Size(168, 21)
        Me.txtPuesto.TabIndex = 275
        '
        'txtReloj
        '
        Me.txtReloj.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.ButtonCustom.Tooltip = ""
        Me.txtReloj.ButtonCustom2.Tooltip = ""
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.ForeColor = System.Drawing.Color.Black
        Me.txtReloj.Location = New System.Drawing.Point(79, 15)
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.ReadOnly = True
        Me.txtReloj.Size = New System.Drawing.Size(84, 26)
        Me.txtReloj.TabIndex = 0
        Me.txtReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LabelX4)
        Me.GroupBox1.Controls.Add(Me.txtReloj)
        Me.GroupBox1.Location = New System.Drawing.Point(718, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(171, 49)
        Me.GroupBox1.TabIndex = 252
        Me.GroupBox1.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.txtArea)
        Me.Panel3.Controls.Add(Me.lblPlanta)
        Me.Panel3.Controls.Add(Me.lblEstado)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.txtNombre)
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Controls.Add(Me.lblBaja)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.txtDepto)
        Me.Panel3.Controls.Add(Me.txtPuesto)
        Me.Panel3.Controls.Add(Me.Label67)
        Me.Panel3.Controls.Add(Me.txtTipoEmp)
        Me.Panel3.Controls.Add(Me.Label68)
        Me.Panel3.Controls.Add(Me.txtBaja)
        Me.Panel3.Controls.Add(Me.txtSupervisor)
        Me.Panel3.Controls.Add(Me.txtAlta)
        Me.Panel3.Controls.Add(Me.Label71)
        Me.Panel3.Controls.Add(Me.Label72)
        Me.Panel3.Controls.Add(Me.txtClase)
        Me.Panel3.Controls.Add(Me.picFoto)
        Me.Panel3.Controls.Add(Me.Label70)
        Me.Panel3.Controls.Add(Me.ReflectionLabel1)
        Me.Panel3.Controls.Add(Me.txtTurno)
        Me.Panel3.Controls.Add(Me.txtHorario)
        Me.Panel3.Controls.Add(Me.Label69)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1008, 164)
        Me.Panel3.TabIndex = 305
        '
        'lblPlanta
        '
        Me.lblPlanta.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        '
        '
        '
        Me.lblPlanta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblPlanta.Font = New System.Drawing.Font("Arial", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlanta.ForeColor = System.Drawing.Color.Black
        Me.lblPlanta.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.lblPlanta.Location = New System.Drawing.Point(718, 127)
        Me.lblPlanta.Name = "lblPlanta"
        Me.lblPlanta.Size = New System.Drawing.Size(279, 27)
        Me.lblPlanta.TabIndex = 305
        Me.lblPlanta.Text = "Compañia"
        Me.lblPlanta.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblPlanta.VerticalTextTopUp = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(453, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 15)
        Me.Label3.TabIndex = 307
        Me.Label3.Text = "Area"
        '
        'txtArea
        '
        '
        '
        '
        Me.txtArea.Border.Class = "TextBoxBorder"
        Me.txtArea.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtArea.ButtonCustom.Tooltip = ""
        Me.txtArea.ButtonCustom2.Tooltip = ""
        Me.txtArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArea.ForeColor = System.Drawing.Color.Black
        Me.txtArea.Location = New System.Drawing.Point(538, 140)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.ReadOnly = True
        Me.txtArea.Size = New System.Drawing.Size(168, 21)
        Me.txtArea.TabIndex = 306
        '
        'frmHerramientasPersonal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 548)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmHerramientasPersonal"
        Me.Text = "Herramientas por empleado"
        Me.Panel1.ResumeLayout(False)
        Me.pnlControles.ResumeLayout(False)
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnFirst As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrev As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNext As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnLast As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents txtBaja As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtAlta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents picFoto As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents txtHorario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents txtTurno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents txtClase As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents txtSupervisor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents txtTipoEmp As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents txtDepto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblBaja As System.Windows.Forms.Label
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblEstado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPuesto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents dgTabla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pnlControles As System.Windows.Forms.Panel
    Friend WithEvents COD_ART As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Clasificacion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_SAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_ENT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Entregado As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents CONTROL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CANTIDAD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OBSERVACION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HORA_DEV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RECIBIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblPlanta As DevComponents.DotNetBar.LabelX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtArea As DevComponents.DotNetBar.Controls.TextBoxX
End Class
