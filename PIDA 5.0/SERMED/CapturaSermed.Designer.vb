<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CapturaSermed
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.panelEmpleados = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.campoTipo = New System.Windows.Forms.TextBox()
        Me.campoPuesto = New System.Windows.Forms.TextBox()
        Me.campoTurno = New System.Windows.Forms.TextBox()
        Me.campoDepto = New System.Windows.Forms.TextBox()
        Me.lblEstado = New DevComponents.DotNetBar.LabelX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.picFoto = New System.Windows.Forms.PictureBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.campoNombreEmpleado = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.campoAlta = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.campoBaja = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.campoHorario = New System.Windows.Forms.TextBox()
        Me.campoSexoEmpleado = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.campoSuper = New System.Windows.Forms.TextBox()
        Me.campoEdadEmpleado = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.campoReloj = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.panelExternos = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.campoEmpresa = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.campoReloj_fam = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.campoApaternoExterno = New System.Windows.Forms.TextBox()
        Me.campoNombresExterno = New System.Windows.Forms.TextBox()
        Me.campoAmaternoExterno = New System.Windows.Forms.TextBox()
        Me.campoSexoExterno = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.campoEdadExterno = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.flowPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbExterno = New System.Windows.Forms.RadioButton()
        Me.rbEmpleado = New System.Windows.Forms.RadioButton()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.grupoSeleccion = New System.Windows.Forms.GroupBox()
        Me.panelEmpleados.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelExternos.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.flowPanel.SuspendLayout()
        Me.grupoSeleccion.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelEmpleados
        '
        Me.panelEmpleados.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelEmpleados.Controls.Add(Me.GroupBox1)
        Me.panelEmpleados.Location = New System.Drawing.Point(3, 3)
        Me.panelEmpleados.Name = "panelEmpleados"
        Me.panelEmpleados.Size = New System.Drawing.Size(765, 151)
        Me.panelEmpleados.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.campoTipo)
        Me.GroupBox1.Controls.Add(Me.campoPuesto)
        Me.GroupBox1.Controls.Add(Me.campoTurno)
        Me.GroupBox1.Controls.Add(Me.campoDepto)
        Me.GroupBox1.Controls.Add(Me.lblEstado)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.picFoto)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.campoNombreEmpleado)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.campoAlta)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.campoBaja)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.campoHorario)
        Me.GroupBox1.Controls.Add(Me.campoSexoEmpleado)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.campoSuper)
        Me.GroupBox1.Controls.Add(Me.campoEdadEmpleado)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(765, 151)
        Me.GroupBox1.TabIndex = 358
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información de Personal"
        '
        'campoTipo
        '
        Me.campoTipo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.campoTipo.Enabled = False
        Me.campoTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.campoTipo.Location = New System.Drawing.Point(232, 121)
        Me.campoTipo.Name = "campoTipo"
        Me.campoTipo.Size = New System.Drawing.Size(108, 20)
        Me.campoTipo.TabIndex = 359
        '
        'campoPuesto
        '
        Me.campoPuesto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.campoPuesto.Enabled = False
        Me.campoPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.campoPuesto.Location = New System.Drawing.Point(232, 82)
        Me.campoPuesto.Name = "campoPuesto"
        Me.campoPuesto.Size = New System.Drawing.Size(108, 20)
        Me.campoPuesto.TabIndex = 358
        '
        'campoTurno
        '
        Me.campoTurno.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.campoTurno.Enabled = False
        Me.campoTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.campoTurno.Location = New System.Drawing.Point(346, 121)
        Me.campoTurno.Name = "campoTurno"
        Me.campoTurno.Size = New System.Drawing.Size(108, 20)
        Me.campoTurno.TabIndex = 357
        '
        'campoDepto
        '
        Me.campoDepto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.campoDepto.Enabled = False
        Me.campoDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.campoDepto.Location = New System.Drawing.Point(346, 82)
        Me.campoDepto.Name = "campoDepto"
        Me.campoDepto.Size = New System.Drawing.Size(108, 20)
        Me.campoDepto.TabIndex = 356
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.Color.LimeGreen
        '
        '
        '
        Me.lblEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.White
        Me.lblEstado.Location = New System.Drawing.Point(6, 19)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(29, 122)
        Me.lblEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblEstado.TabIndex = 329
        Me.lblEstado.Text = "ACTIVO"
        Me.lblEstado.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblEstado.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.lblEstado.VerticalTextTopUp = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(41, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 331
        Me.Label5.Text = "Nombre"
        '
        'picFoto
        '
        Me.picFoto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picFoto.ErrorImage = Global.PIDA.NET.My.Resources.Resources.NoFoto
        Me.picFoto.Image = Global.PIDA.NET.My.Resources.Resources.NoFoto
        Me.picFoto.Location = New System.Drawing.Point(661, 19)
        Me.picFoto.MaximumSize = New System.Drawing.Size(164, 210)
        Me.picFoto.MinimumSize = New System.Drawing.Size(78, 100)
        Me.picFoto.Name = "picFoto"
        Me.picFoto.Size = New System.Drawing.Size(98, 122)
        Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picFoto.TabIndex = 332
        Me.picFoto.TabStop = False
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(312, 105)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(28, 13)
        Me.Label15.TabIndex = 355
        Me.Label15.Text = "Tipo"
        '
        'campoNombreEmpleado
        '
        Me.campoNombreEmpleado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.campoNombreEmpleado.Enabled = False
        Me.campoNombreEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.campoNombreEmpleado.Location = New System.Drawing.Point(44, 35)
        Me.campoNombreEmpleado.Name = "campoNombreEmpleado"
        Me.campoNombreEmpleado.Size = New System.Drawing.Size(611, 26)
        Me.campoNombreEmpleado.TabIndex = 333
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(300, 66)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(40, 13)
        Me.Label17.TabIndex = 354
        Me.Label17.Text = "Puesto"
        '
        'campoAlta
        '
        Me.campoAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.campoAlta.Enabled = False
        Me.campoAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.campoAlta.Location = New System.Drawing.Point(574, 82)
        Me.campoAlta.Name = "campoAlta"
        Me.campoAlta.Size = New System.Drawing.Size(81, 20)
        Me.campoAlta.TabIndex = 336
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(419, 105)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 13)
        Me.Label13.TabIndex = 351
        Me.Label13.Text = "Turno"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(630, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 337
        Me.Label2.Text = "Alta"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(380, 66)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 13)
        Me.Label14.TabIndex = 349
        Me.Label14.Text = "Departamento"
        '
        'campoBaja
        '
        Me.campoBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.campoBaja.Enabled = False
        Me.campoBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.campoBaja.Location = New System.Drawing.Point(574, 121)
        Me.campoBaja.Name = "campoBaja"
        Me.campoBaja.Size = New System.Drawing.Size(81, 20)
        Me.campoBaja.TabIndex = 338
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(527, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 347
        Me.Label8.Text = "Horario"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(627, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 339
        Me.Label3.Text = "Baja"
        '
        'campoHorario
        '
        Me.campoHorario.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.campoHorario.Enabled = False
        Me.campoHorario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.campoHorario.Location = New System.Drawing.Point(460, 121)
        Me.campoHorario.Name = "campoHorario"
        Me.campoHorario.Size = New System.Drawing.Size(108, 20)
        Me.campoHorario.TabIndex = 346
        '
        'campoSexoEmpleado
        '
        Me.campoSexoEmpleado.Enabled = False
        Me.campoSexoEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.campoSexoEmpleado.Location = New System.Drawing.Point(44, 82)
        Me.campoSexoEmpleado.Name = "campoSexoEmpleado"
        Me.campoSexoEmpleado.Size = New System.Drawing.Size(81, 20)
        Me.campoSexoEmpleado.TabIndex = 340
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(511, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 345
        Me.Label7.Text = "Supervisor"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(44, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 341
        Me.Label4.Text = "Sexo"
        '
        'campoSuper
        '
        Me.campoSuper.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.campoSuper.Enabled = False
        Me.campoSuper.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.campoSuper.Location = New System.Drawing.Point(460, 82)
        Me.campoSuper.Name = "campoSuper"
        Me.campoSuper.Size = New System.Drawing.Size(108, 20)
        Me.campoSuper.TabIndex = 344
        '
        'campoEdadEmpleado
        '
        Me.campoEdadEmpleado.Enabled = False
        Me.campoEdadEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.campoEdadEmpleado.Location = New System.Drawing.Point(44, 121)
        Me.campoEdadEmpleado.Name = "campoEdadEmpleado"
        Me.campoEdadEmpleado.Size = New System.Drawing.Size(81, 20)
        Me.campoEdadEmpleado.TabIndex = 342
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(44, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 343
        Me.Label6.Text = "Edad"
        '
        'campoReloj
        '
        Me.campoReloj.Enabled = False
        Me.campoReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.campoReloj.Location = New System.Drawing.Point(670, 27)
        Me.campoReloj.Name = "campoReloj"
        Me.campoReloj.Size = New System.Drawing.Size(98, 26)
        Me.campoReloj.TabIndex = 334
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(734, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 335
        Me.Label1.Text = "Reloj"
        '
        'panelExternos
        '
        Me.panelExternos.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelExternos.Controls.Add(Me.GroupBox2)
        Me.panelExternos.Location = New System.Drawing.Point(3, 160)
        Me.panelExternos.Name = "panelExternos"
        Me.panelExternos.Size = New System.Drawing.Size(765, 151)
        Me.panelExternos.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnBuscar)
        Me.GroupBox2.Controls.Add(Me.campoEmpresa)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.campoReloj_fam)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.campoApaternoExterno)
        Me.GroupBox2.Controls.Add(Me.campoNombresExterno)
        Me.GroupBox2.Controls.Add(Me.campoAmaternoExterno)
        Me.GroupBox2.Controls.Add(Me.campoSexoExterno)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.campoEdadExterno)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(765, 151)
        Me.GroupBox2.TabIndex = 349
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Información Externos"
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.NET.My.Resources.Resources.Search16
        Me.btnBuscar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBuscar.Location = New System.Drawing.Point(571, 116)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(70, 20)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 353
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Tooltip = "Buscar"
        '
        'campoEmpresa
        '
        Me.campoEmpresa.Location = New System.Drawing.Point(647, 77)
        Me.campoEmpresa.Name = "campoEmpresa"
        Me.campoEmpresa.Size = New System.Drawing.Size(112, 20)
        Me.campoEmpresa.TabIndex = 349
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(711, 61)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(48, 13)
        Me.Label18.TabIndex = 350
        Me.Label18.Text = "Empresa"
        '
        'campoReloj_fam
        '
        Me.campoReloj_fam.Enabled = False
        Me.campoReloj_fam.Location = New System.Drawing.Point(647, 116)
        Me.campoReloj_fam.Name = "campoReloj_fam"
        Me.campoReloj_fam.Size = New System.Drawing.Size(112, 20)
        Me.campoReloj_fam.TabIndex = 351
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(675, 100)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(84, 13)
        Me.Label19.TabIndex = 352
        Me.Label19.Text = "Reloj de Familiar"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(6, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 13)
        Me.Label16.TabIndex = 331
        Me.Label16.Text = "Nombres"
        '
        'campoApaternoExterno
        '
        Me.campoApaternoExterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.campoApaternoExterno.Location = New System.Drawing.Point(371, 32)
        Me.campoApaternoExterno.Name = "campoApaternoExterno"
        Me.campoApaternoExterno.Size = New System.Drawing.Size(191, 26)
        Me.campoApaternoExterno.TabIndex = 348
        '
        'campoNombresExterno
        '
        Me.campoNombresExterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.campoNombresExterno.Location = New System.Drawing.Point(9, 32)
        Me.campoNombresExterno.Name = "campoNombresExterno"
        Me.campoNombresExterno.Size = New System.Drawing.Size(356, 26)
        Me.campoNombresExterno.TabIndex = 333
        '
        'campoAmaternoExterno
        '
        Me.campoAmaternoExterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.campoAmaternoExterno.Location = New System.Drawing.Point(568, 32)
        Me.campoAmaternoExterno.Name = "campoAmaternoExterno"
        Me.campoAmaternoExterno.Size = New System.Drawing.Size(191, 26)
        Me.campoAmaternoExterno.TabIndex = 347
        '
        'campoSexoExterno
        '
        Me.campoSexoExterno.Location = New System.Drawing.Point(10, 77)
        Me.campoSexoExterno.Name = "campoSexoExterno"
        Me.campoSexoExterno.Size = New System.Drawing.Size(112, 20)
        Me.campoSexoExterno.TabIndex = 340
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(673, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 13)
        Me.Label10.TabIndex = 346
        Me.Label10.Text = "Apellido Materno"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(7, 61)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 13)
        Me.Label12.TabIndex = 341
        Me.Label12.Text = "Sexo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(478, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 13)
        Me.Label9.TabIndex = 344
        Me.Label9.Text = "Apellido Paterno"
        '
        'campoEdadExterno
        '
        Me.campoEdadExterno.Location = New System.Drawing.Point(10, 116)
        Me.campoEdadExterno.Name = "campoEdadExterno"
        Me.campoEdadExterno.Size = New System.Drawing.Size(112, 20)
        Me.campoEdadExterno.TabIndex = 342
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(7, 100)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 13)
        Me.Label11.TabIndex = 343
        Me.Label11.Text = "Edad"
        '
        'flowPanel
        '
        Me.flowPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flowPanel.Controls.Add(Me.panelEmpleados)
        Me.flowPanel.Controls.Add(Me.panelExternos)
        Me.flowPanel.Location = New System.Drawing.Point(3, 59)
        Me.flowPanel.Name = "flowPanel"
        Me.flowPanel.Size = New System.Drawing.Size(777, 584)
        Me.flowPanel.TabIndex = 3
        '
        'rbExterno
        '
        Me.rbExterno.AutoSize = True
        Me.rbExterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbExterno.Location = New System.Drawing.Point(217, 22)
        Me.rbExterno.Name = "rbExterno"
        Me.rbExterno.Size = New System.Drawing.Size(61, 17)
        Me.rbExterno.TabIndex = 4
        Me.rbExterno.TabStop = True
        Me.rbExterno.Text = "Externo"
        Me.rbExterno.UseVisualStyleBackColor = True
        '
        'rbEmpleado
        '
        Me.rbEmpleado.AutoSize = True
        Me.rbEmpleado.Enabled = False
        Me.rbEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbEmpleado.Location = New System.Drawing.Point(12, 22)
        Me.rbEmpleado.Name = "rbEmpleado"
        Me.rbEmpleado.Size = New System.Drawing.Size(72, 17)
        Me.rbEmpleado.TabIndex = 5
        Me.rbEmpleado.TabStop = True
        Me.rbEmpleado.Text = "Empleado"
        Me.rbEmpleado.UseVisualStyleBackColor = True
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.CausesValidation = False
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX1.Image = Global.PIDA.NET.My.Resources.Resources.Search16
        Me.ButtonX1.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.ButtonX1.Location = New System.Drawing.Point(90, 22)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(70, 20)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 354
        Me.ButtonX1.Text = "Buscar"
        Me.ButtonX1.Tooltip = "Buscar"
        '
        'grupoSeleccion
        '
        Me.grupoSeleccion.Controls.Add(Me.rbEmpleado)
        Me.grupoSeleccion.Controls.Add(Me.ButtonX1)
        Me.grupoSeleccion.Controls.Add(Me.rbExterno)
        Me.grupoSeleccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grupoSeleccion.Location = New System.Drawing.Point(3, 5)
        Me.grupoSeleccion.Name = "grupoSeleccion"
        Me.grupoSeleccion.Size = New System.Drawing.Size(661, 51)
        Me.grupoSeleccion.TabIndex = 355
        Me.grupoSeleccion.TabStop = False
        Me.grupoSeleccion.Text = "Seleccione Una Opción"
        '
        'CapturaSermed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.grupoSeleccion)
        Me.Controls.Add(Me.flowPanel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.campoReloj)
        Me.Name = "CapturaSermed"
        Me.Size = New System.Drawing.Size(777, 633)
        Me.panelEmpleados.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelExternos.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.flowPanel.ResumeLayout(False)
        Me.grupoSeleccion.ResumeLayout(False)
        Me.grupoSeleccion.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents panelEmpleados As System.Windows.Forms.Panel
    Friend WithEvents lblEstado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents picFoto As System.Windows.Forms.PictureBox
    Friend WithEvents campoNombreEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents campoReloj As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents campoBaja As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents campoAlta As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents campoSexoEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents campoEdadEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents campoHorario As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents campoSuper As System.Windows.Forms.TextBox
    Friend WithEvents panelExternos As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents campoEdadExterno As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents campoSexoExterno As System.Windows.Forms.TextBox
    Friend WithEvents campoNombresExterno As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents campoApaternoExterno As System.Windows.Forms.TextBox
    Friend WithEvents campoAmaternoExterno As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents flowPanel As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents campoTipo As System.Windows.Forms.TextBox
    Friend WithEvents campoPuesto As System.Windows.Forms.TextBox
    Friend WithEvents campoTurno As System.Windows.Forms.TextBox
    Friend WithEvents campoDepto As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbExterno As System.Windows.Forms.RadioButton
    Friend WithEvents rbEmpleado As System.Windows.Forms.RadioButton
    Friend WithEvents campoEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents campoReloj_fam As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents grupoSeleccion As System.Windows.Forms.GroupBox

End Class
