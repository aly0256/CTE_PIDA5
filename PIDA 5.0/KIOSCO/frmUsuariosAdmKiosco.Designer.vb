<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsuariosAdmKiosco
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUsuariosAdmKiosco))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.EmpNav = New System.Windows.Forms.GroupBox()
        Me.pnlCentrado = New System.Windows.Forms.Panel()
        Me.btnCambiarClave = New DevComponents.DotNetBar.ButtonX()
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
        Me.pnlInformacion = New System.Windows.Forms.Panel()
        Me.tabBuscar = New DevComponents.DotNetBar.SuperTabControl()
        Me.pnlDatos = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.PnlClave = New System.Windows.Forms.Panel()
        Me.txtConfirmarclave = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtClave = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNombreCompleto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbPerfiles = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.txtUsuario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPuesto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tabEmpleado = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgTabla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.tabTabla = New DevComponents.DotNetBar.SuperTabItem()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EmpNav.SuspendLayout()
        Me.pnlCentrado.SuspendLayout()
        Me.pnlInformacion.SuspendLayout()
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBuscar.SuspendLayout()
        Me.pnlDatos.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.PnlClave.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ReflectionLabel1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(990, 59)
        Me.Panel1.TabIndex = 99
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(45, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(410, 40)
        Me.ReflectionLabel1.TabIndex = 84
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>USUARIOS ADMINISTRADOR KIOSCO</b></font>"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Users32
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(27, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 85
        Me.PictureBox1.TabStop = False
        '
        'EmpNav
        '
        Me.EmpNav.Controls.Add(Me.pnlCentrado)
        Me.EmpNav.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.EmpNav.Location = New System.Drawing.Point(0, 385)
        Me.EmpNav.Name = "EmpNav"
        Me.EmpNav.Size = New System.Drawing.Size(990, 47)
        Me.EmpNav.TabIndex = 100
        Me.EmpNav.TabStop = False
        '
        'pnlCentrado
        '
        Me.pnlCentrado.Controls.Add(Me.btnCambiarClave)
        Me.pnlCentrado.Controls.Add(Me.btnPrimero)
        Me.pnlCentrado.Controls.Add(Me.btnCerrar)
        Me.pnlCentrado.Controls.Add(Me.btnNuevo)
        Me.pnlCentrado.Controls.Add(Me.btnEditar)
        Me.pnlCentrado.Controls.Add(Me.btnReporte)
        Me.pnlCentrado.Controls.Add(Me.btnBuscar)
        Me.pnlCentrado.Controls.Add(Me.btnAnterior)
        Me.pnlCentrado.Controls.Add(Me.btnUltimo)
        Me.pnlCentrado.Controls.Add(Me.btnBorrar)
        Me.pnlCentrado.Controls.Add(Me.btnSiguiente)
        Me.pnlCentrado.Location = New System.Drawing.Point(33, 9)
        Me.pnlCentrado.Name = "pnlCentrado"
        Me.pnlCentrado.Size = New System.Drawing.Size(942, 32)
        Me.pnlCentrado.TabIndex = 58
        '
        'btnCambiarClave
        '
        Me.btnCambiarClave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCambiarClave.CausesValidation = False
        Me.btnCambiarClave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCambiarClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCambiarClave.Image = Global.PIDA.My.Resources.Resources.key16
        Me.btnCambiarClave.Location = New System.Drawing.Point(741, 4)
        Me.btnCambiarClave.Name = "btnCambiarClave"
        Me.btnCambiarClave.Size = New System.Drawing.Size(112, 25)
        Me.btnCambiarClave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCambiarClave.TabIndex = 58
        Me.btnCambiarClave.Text = "Cambiar clave"
        '
        'btnPrimero
        '
        Me.btnPrimero.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrimero.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrimero.Image = Global.PIDA.My.Resources.Resources.First16
        Me.btnPrimero.Location = New System.Drawing.Point(3, 4)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(78, 25)
        Me.btnPrimero.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrimero.TabIndex = 23
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
        Me.btnCerrar.Location = New System.Drawing.Point(857, 4)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.Text = "Salir"
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.NewRecord
        Me.btnNuevo.Location = New System.Drawing.Point(495, 4)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 25)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 52
        Me.btnNuevo.Text = "Agregar"
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = Global.PIDA.My.Resources.Resources.Edit
        Me.btnEditar.Location = New System.Drawing.Point(577, 4)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(78, 25)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 53
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
        Me.btnReporte.Location = New System.Drawing.Point(413, 4)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 57
        Me.btnReporte.Text = "Reporte"
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscar.Location = New System.Drawing.Point(331, 4)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(78, 25)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 51
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Tooltip = "Buscar"
        '
        'btnAnterior
        '
        Me.btnAnterior.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAnterior.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAnterior.Image = Global.PIDA.My.Resources.Resources.Prev16
        Me.btnAnterior.Location = New System.Drawing.Point(85, 4)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(78, 25)
        Me.btnAnterior.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAnterior.TabIndex = 24
        Me.btnAnterior.Text = "Anterior"
        '
        'btnUltimo
        '
        Me.btnUltimo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnUltimo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnUltimo.Image = Global.PIDA.My.Resources.Resources.Last16
        Me.btnUltimo.Location = New System.Drawing.Point(249, 4)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(78, 25)
        Me.btnUltimo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnUltimo.TabIndex = 26
        Me.btnUltimo.Text = "Final"
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = Global.PIDA.My.Resources.Resources.DeleteRec
        Me.btnBorrar.Location = New System.Drawing.Point(659, 4)
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
        Me.btnSiguiente.Location = New System.Drawing.Point(167, 4)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(78, 25)
        Me.btnSiguiente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSiguiente.TabIndex = 25
        Me.btnSiguiente.Text = "Siguiente"
        '
        'pnlInformacion
        '
        Me.pnlInformacion.Controls.Add(Me.tabBuscar)
        Me.pnlInformacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlInformacion.Location = New System.Drawing.Point(0, 59)
        Me.pnlInformacion.Name = "pnlInformacion"
        Me.pnlInformacion.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlInformacion.Size = New System.Drawing.Size(990, 326)
        Me.pnlInformacion.TabIndex = 101
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
        Me.tabBuscar.Controls.Add(Me.pnlDatos)
        Me.tabBuscar.Controls.Add(Me.SuperTabControlPanel2)
        Me.tabBuscar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.Location = New System.Drawing.Point(10, 10)
        Me.tabBuscar.Name = "tabBuscar"
        Me.tabBuscar.ReorderTabsEnabled = True
        Me.tabBuscar.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabBuscar.SelectedTabIndex = 0
        Me.tabBuscar.Size = New System.Drawing.Size(970, 306)
        Me.tabBuscar.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.tabBuscar.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.TabIndex = 0
        Me.tabBuscar.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit
        Me.tabBuscar.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabEmpleado, Me.tabTabla})
        Me.tabBuscar.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.GroupPanel1)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Padding = New System.Windows.Forms.Padding(2)
        Me.pnlDatos.Size = New System.Drawing.Size(899, 306)
        Me.pnlDatos.TabIndex = 0
        Me.pnlDatos.TabItem = Me.tabEmpleado
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.PnlClave)
        Me.GroupPanel1.Controls.Add(Me.txtNombreCompleto)
        Me.GroupPanel1.Controls.Add(Me.Label1)
        Me.GroupPanel1.Controls.Add(Me.cmbPerfiles)
        Me.GroupPanel1.Controls.Add(Me.txtUsuario)
        Me.GroupPanel1.Controls.Add(Me.Label2)
        Me.GroupPanel1.Controls.Add(Me.txtPuesto)
        Me.GroupPanel1.Controls.Add(Me.Label3)
        Me.GroupPanel1.Controls.Add(Me.Label4)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(11, 12)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(877, 281)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor = System.Drawing.SystemColors.Window
        Me.GroupPanel1.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 180
        Me.GroupPanel1.Text = "Datos de Usuario"
        '
        'PnlClave
        '
        Me.PnlClave.Controls.Add(Me.txtConfirmarclave)
        Me.PnlClave.Controls.Add(Me.Label9)
        Me.PnlClave.Controls.Add(Me.Label8)
        Me.PnlClave.Controls.Add(Me.txtClave)
        Me.PnlClave.Location = New System.Drawing.Point(21, 139)
        Me.PnlClave.Name = "PnlClave"
        Me.PnlClave.Size = New System.Drawing.Size(523, 58)
        Me.PnlClave.TabIndex = 24
        '
        'txtConfirmarclave
        '
        '
        '
        '
        Me.txtConfirmarclave.Border.Class = "TextBoxBorder"
        Me.txtConfirmarclave.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtConfirmarclave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirmarclave.Location = New System.Drawing.Point(138, 34)
        Me.txtConfirmarclave.Name = "txtConfirmarclave"
        Me.txtConfirmarclave.Size = New System.Drawing.Size(362, 21)
        Me.txtConfirmarclave.TabIndex = 6
        Me.txtConfirmarclave.Text = "123456"
        Me.txtConfirmarclave.UseSystemPasswordChar = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Window
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 15)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Confirmar contraseña"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Window
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 15)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Contraseña"
        '
        'txtClave
        '
        '
        '
        '
        Me.txtClave.Border.Class = "TextBoxBorder"
        Me.txtClave.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClave.Location = New System.Drawing.Point(139, 5)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(362, 21)
        Me.txtClave.TabIndex = 5
        Me.txtClave.Text = "123456"
        Me.txtClave.UseSystemPasswordChar = True
        '
        'txtNombreCompleto
        '
        '
        '
        '
        Me.txtNombreCompleto.Border.Class = "TextBoxBorder"
        Me.txtNombreCompleto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombreCompleto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreCompleto.Location = New System.Drawing.Point(160, 30)
        Me.txtNombreCompleto.MaxLength = 60
        Me.txtNombreCompleto.Name = "txtNombreCompleto"
        Me.txtNombreCompleto.Size = New System.Drawing.Size(362, 21)
        Me.txtNombreCompleto.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 116)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 15)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Perfil"
        '
        'cmbPerfiles
        '
        Me.cmbPerfiles.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPerfiles.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPerfiles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPerfiles.ButtonDropDown.Visible = True
        Me.cmbPerfiles.DisplayMembers = "COLOR"
        Me.cmbPerfiles.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPerfiles.Location = New System.Drawing.Point(160, 111)
        Me.cmbPerfiles.Name = "cmbPerfiles"
        Me.cmbPerfiles.Size = New System.Drawing.Size(358, 22)
        Me.cmbPerfiles.TabIndex = 4
        Me.cmbPerfiles.ValueMember = "COD_PERFIL"
        '
        'txtUsuario
        '
        '
        '
        '
        Me.txtUsuario.Border.Class = "TextBoxBorder"
        Me.txtUsuario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.Location = New System.Drawing.Point(160, 84)
        Me.txtUsuario.MaxLength = 60
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(362, 21)
        Me.txtUsuario.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(29, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 15)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Nombre Completo"
        '
        'txtPuesto
        '
        '
        '
        '
        Me.txtPuesto.Border.Class = "TextBoxBorder"
        Me.txtPuesto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPuesto.Location = New System.Drawing.Point(160, 57)
        Me.txtPuesto.MaxLength = 60
        Me.txtPuesto.Name = "txtPuesto"
        Me.txtPuesto.Size = New System.Drawing.Size(362, 21)
        Me.txtPuesto.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 15)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Usuario(nickname)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(30, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 15)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Puesto"
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
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(897, 306)
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
        Me.dgTabla.Size = New System.Drawing.Size(897, 306)
        Me.dgTabla.TabIndex = 1
        '
        'tabTabla
        '
        Me.tabTabla.AttachedControl = Me.SuperTabControlPanel2
        Me.tabTabla.GlobalItem = False
        Me.tabTabla.Name = "tabTabla"
        Me.tabTabla.Text = "Lista"
        '
        'frmUsuariosAdmKiosco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(990, 432)
        Me.Controls.Add(Me.pnlInformacion)
        Me.Controls.Add(Me.EmpNav)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmUsuariosAdmKiosco"
        Me.Text = "Usuarios administrador kiosco"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EmpNav.ResumeLayout(False)
        Me.pnlCentrado.ResumeLayout(False)
        Me.pnlInformacion.ResumeLayout(False)
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBuscar.ResumeLayout(False)
        Me.pnlDatos.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.PnlClave.ResumeLayout(False)
        Me.PnlClave.PerformLayout()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents EmpNav As System.Windows.Forms.GroupBox
    Friend WithEvents pnlCentrado As System.Windows.Forms.Panel
    Friend WithEvents btnCambiarClave As DevComponents.DotNetBar.ButtonX
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
    Friend WithEvents pnlInformacion As System.Windows.Forms.Panel
    Friend WithEvents tabBuscar As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents pnlDatos As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabEmpleado As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents dgTabla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents tabTabla As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbPerfiles As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents txtUsuario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtConfirmarclave As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtClave As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtPuesto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNombreCompleto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents PnlClave As System.Windows.Forms.Panel
End Class
