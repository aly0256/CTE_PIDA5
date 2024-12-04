<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpcionesLockers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOpcionesLockers))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.txtDetalle = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnVerBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnAceptAsignar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelarAsignar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.panelLockers2 = New System.Windows.Forms.Panel()
        Me.picboxLocker = New System.Windows.Forms.PictureBox()
        Me.txtClave = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lbClave = New System.Windows.Forms.Label()
        Me.lbInfo = New System.Windows.Forms.Label()
        Me.panelLockers1 = New System.Windows.Forms.Panel()
        Me.picVer = New System.Windows.Forms.PictureBox()
        Me.lbCandado = New System.Windows.Forms.Label()
        Me.txtNoCandado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lbLlave = New System.Windows.Forms.Label()
        Me.txtLlave = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnAceptarBaja = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelarBaja = New DevComponents.DotNetBar.ButtonX()
        Me.tabLockers = New DevComponents.DotNetBar.SuperTabControl()
        Me.pnlDatos = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.tabAsignar = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnAceptarLiberar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelarLiberar = New DevComponents.DotNetBar.ButtonX()
        Me.tabLiberar = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.tabCancelar = New DevComponents.DotNetBar.SuperTabItem()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.panelLockers2.SuspendLayout()
        CType(Me.picboxLocker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelLockers1.SuspendLayout()
        CType(Me.picVer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.tabLockers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabLockers.SuspendLayout()
        Me.pnlDatos.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(12, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(131, 40)
        Me.ReflectionLabel1.TabIndex = 96
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>OPCIONES</b></font>"
        '
        'txtDetalle
        '
        '
        '
        '
        Me.txtDetalle.Border.Class = "TextBoxBorder"
        Me.txtDetalle.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDetalle.Location = New System.Drawing.Point(13, 19)
        Me.txtDetalle.Multiline = True
        Me.txtDetalle.Name = "txtDetalle"
        Me.txtDetalle.PreventEnterBeep = True
        Me.txtDetalle.Size = New System.Drawing.Size(328, 78)
        Me.txtDetalle.TabIndex = 97
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.Location = New System.Drawing.Point(10, 1)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(182, 15)
        Me.Label69.TabIndex = 147
        Me.Label69.Text = "Motivo de cancelación de locker"
        '
        'txtReloj
        '
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.Location = New System.Drawing.Point(59, 8)
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.PreventEnterBeep = True
        Me.txtReloj.Size = New System.Drawing.Size(73, 20)
        Me.txtReloj.TabIndex = 152
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 15)
        Me.Label2.TabIndex = 153
        Me.Label2.Text = "Reloj"
        '
        'btnVerBuscar
        '
        Me.btnVerBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnVerBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnVerBuscar.Location = New System.Drawing.Point(138, 8)
        Me.btnVerBuscar.Name = "btnVerBuscar"
        Me.btnVerBuscar.Size = New System.Drawing.Size(22, 20)
        Me.btnVerBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnVerBuscar.TabIndex = 154
        Me.btnVerBuscar.Text = "..."
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.txtReloj)
        Me.Panel1.Controls.Add(Me.btnVerBuscar)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Location = New System.Drawing.Point(3, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(381, 204)
        Me.Panel1.TabIndex = 155
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btnAceptAsignar)
        Me.GroupBox2.Controls.Add(Me.btnCancelarAsignar)
        Me.GroupBox2.Location = New System.Drawing.Point(160, 154)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(174, 47)
        Me.GroupBox2.TabIndex = 156
        Me.GroupBox2.TabStop = False
        '
        'btnAceptAsignar
        '
        Me.btnAceptAsignar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptAsignar.CausesValidation = False
        Me.btnAceptAsignar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptAsignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptAsignar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptAsignar.Location = New System.Drawing.Point(6, 14)
        Me.btnAceptAsignar.Name = "btnAceptAsignar"
        Me.btnAceptAsignar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptAsignar.TabIndex = 11
        Me.btnAceptAsignar.Text = "Aceptar"
        '
        'btnCancelarAsignar
        '
        Me.btnCancelarAsignar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelarAsignar.CausesValidation = False
        Me.btnCancelarAsignar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelarAsignar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelarAsignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarAsignar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelarAsignar.Location = New System.Drawing.Point(88, 14)
        Me.btnCancelarAsignar.Name = "btnCancelarAsignar"
        Me.btnCancelarAsignar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelarAsignar.TabIndex = 12
        Me.btnCancelarAsignar.Text = "Cancelar"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel3.Controls.Add(Me.panelLockers2)
        Me.Panel3.Controls.Add(Me.panelLockers1)
        Me.Panel3.Location = New System.Drawing.Point(20, 37)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(354, 116)
        Me.Panel3.TabIndex = 157
        '
        'panelLockers2
        '
        Me.panelLockers2.Controls.Add(Me.picboxLocker)
        Me.panelLockers2.Controls.Add(Me.txtClave)
        Me.panelLockers2.Controls.Add(Me.lbClave)
        Me.panelLockers2.Controls.Add(Me.lbInfo)
        Me.panelLockers2.Location = New System.Drawing.Point(3, 11)
        Me.panelLockers2.Name = "panelLockers2"
        Me.panelLockers2.Size = New System.Drawing.Size(336, 102)
        Me.panelLockers2.TabIndex = 155
        '
        'picboxLocker
        '
        Me.picboxLocker.Image = Global.PIDA.My.Resources.Resources.candado
        Me.picboxLocker.Location = New System.Drawing.Point(3, 3)
        Me.picboxLocker.Name = "picboxLocker"
        Me.picboxLocker.Size = New System.Drawing.Size(84, 87)
        Me.picboxLocker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picboxLocker.TabIndex = 59
        Me.picboxLocker.TabStop = False
        '
        'txtClave
        '
        '
        '
        '
        Me.txtClave.Border.Class = "TextBoxBorder"
        Me.txtClave.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtClave.Location = New System.Drawing.Point(93, 19)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.PreventEnterBeep = True
        Me.txtClave.Size = New System.Drawing.Size(196, 20)
        Me.txtClave.TabIndex = 68
        '
        'lbClave
        '
        Me.lbClave.AutoSize = True
        Me.lbClave.Location = New System.Drawing.Point(93, 3)
        Me.lbClave.Name = "lbClave"
        Me.lbClave.Size = New System.Drawing.Size(34, 13)
        Me.lbClave.TabIndex = 69
        Me.lbClave.Text = "Clave"
        '
        'lbInfo
        '
        Me.lbInfo.AutoSize = True
        Me.lbInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbInfo.Location = New System.Drawing.Point(93, 50)
        Me.lbInfo.Name = "lbInfo"
        Me.lbInfo.Size = New System.Drawing.Size(211, 39)
        Me.lbInfo.TabIndex = 70
        Me.lbInfo.Text = "*Para tener acceso a las llaves/contraseñas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " de los lockers es necesario volver " & _
    "a" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " autenticarse con su clave de usuario."
        '
        'panelLockers1
        '
        Me.panelLockers1.Controls.Add(Me.picVer)
        Me.panelLockers1.Controls.Add(Me.lbCandado)
        Me.panelLockers1.Controls.Add(Me.txtNoCandado)
        Me.panelLockers1.Controls.Add(Me.lbLlave)
        Me.panelLockers1.Controls.Add(Me.txtLlave)
        Me.panelLockers1.Location = New System.Drawing.Point(19, 19)
        Me.panelLockers1.Name = "panelLockers1"
        Me.panelLockers1.Size = New System.Drawing.Size(315, 83)
        Me.panelLockers1.TabIndex = 158
        '
        'picVer
        '
        Me.picVer.Image = Global.PIDA.My.Resources.Resources.ver
        Me.picVer.Location = New System.Drawing.Point(288, 49)
        Me.picVer.Name = "picVer"
        Me.picVer.Size = New System.Drawing.Size(24, 20)
        Me.picVer.TabIndex = 161
        Me.picVer.TabStop = False
        '
        'lbCandado
        '
        Me.lbCandado.AutoSize = True
        Me.lbCandado.Location = New System.Drawing.Point(14, 11)
        Me.lbCandado.Name = "lbCandado"
        Me.lbCandado.Size = New System.Drawing.Size(70, 13)
        Me.lbCandado.TabIndex = 72
        Me.lbCandado.Text = "No. Candado"
        '
        'txtNoCandado
        '
        '
        '
        '
        Me.txtNoCandado.Border.Class = "TextBoxBorder"
        Me.txtNoCandado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNoCandado.Location = New System.Drawing.Point(90, 9)
        Me.txtNoCandado.Name = "txtNoCandado"
        Me.txtNoCandado.PreventEnterBeep = True
        Me.txtNoCandado.Size = New System.Drawing.Size(192, 20)
        Me.txtNoCandado.TabIndex = 71
        '
        'lbLlave
        '
        Me.lbLlave.AutoSize = True
        Me.lbLlave.Location = New System.Drawing.Point(14, 43)
        Me.lbLlave.Name = "lbLlave"
        Me.lbLlave.Size = New System.Drawing.Size(61, 26)
        Me.lbLlave.TabIndex = 73
        Me.lbLlave.Text = "Llave/" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Contraseña"
        '
        'txtLlave
        '
        '
        '
        '
        Me.txtLlave.Border.Class = "TextBoxBorder"
        Me.txtLlave.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtLlave.Location = New System.Drawing.Point(90, 49)
        Me.txtLlave.Name = "txtLlave"
        Me.txtLlave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtLlave.PreventEnterBeep = True
        Me.txtLlave.Size = New System.Drawing.Size(192, 20)
        Me.txtLlave.TabIndex = 74
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel2.Controls.Add(Me.GroupBox4)
        Me.Panel2.Controls.Add(Me.Label69)
        Me.Panel2.Controls.Add(Me.txtDetalle)
        Me.Panel2.Location = New System.Drawing.Point(13, 21)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(344, 171)
        Me.Panel2.TabIndex = 159
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.Controls.Add(Me.btnAceptarBaja)
        Me.GroupBox4.Controls.Add(Me.btnCancelarBaja)
        Me.GroupBox4.Location = New System.Drawing.Point(167, 103)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(174, 47)
        Me.GroupBox4.TabIndex = 160
        Me.GroupBox4.TabStop = False
        '
        'btnAceptarBaja
        '
        Me.btnAceptarBaja.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptarBaja.CausesValidation = False
        Me.btnAceptarBaja.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptarBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptarBaja.Image = CType(resources.GetObject("btnAceptarBaja.Image"), System.Drawing.Image)
        Me.btnAceptarBaja.Location = New System.Drawing.Point(6, 14)
        Me.btnAceptarBaja.Name = "btnAceptarBaja"
        Me.btnAceptarBaja.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptarBaja.TabIndex = 11
        Me.btnAceptarBaja.Text = "Aceptar"
        '
        'btnCancelarBaja
        '
        Me.btnCancelarBaja.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelarBaja.CausesValidation = False
        Me.btnCancelarBaja.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelarBaja.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelarBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarBaja.Image = CType(resources.GetObject("btnCancelarBaja.Image"), System.Drawing.Image)
        Me.btnCancelarBaja.Location = New System.Drawing.Point(88, 14)
        Me.btnCancelarBaja.Name = "btnCancelarBaja"
        Me.btnCancelarBaja.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelarBaja.TabIndex = 12
        Me.btnCancelarBaja.Text = "Cancelar"
        '
        'tabLockers
        '
        '
        '
        '
        '
        '
        '
        Me.tabLockers.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.tabLockers.ControlBox.MenuBox.Name = ""
        Me.tabLockers.ControlBox.MenuBox.Visible = False
        Me.tabLockers.ControlBox.Name = ""
        Me.tabLockers.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabLockers.ControlBox.MenuBox, Me.tabLockers.ControlBox.CloseBox})
        Me.tabLockers.Controls.Add(Me.pnlDatos)
        Me.tabLockers.Controls.Add(Me.SuperTabControlPanel2)
        Me.tabLockers.Controls.Add(Me.SuperTabControlPanel1)
        Me.tabLockers.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabLockers.Location = New System.Drawing.Point(16, 61)
        Me.tabLockers.Name = "tabLockers"
        Me.tabLockers.ReorderTabsEnabled = True
        Me.tabLockers.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabLockers.SelectedTabIndex = 0
        Me.tabLockers.Size = New System.Drawing.Size(464, 215)
        Me.tabLockers.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Left
        Me.tabLockers.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabLockers.TabIndex = 160
        Me.tabLockers.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit
        Me.tabLockers.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabAsignar, Me.tabLiberar, Me.tabCancelar})
        Me.tabLockers.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.Panel1)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(75, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(389, 215)
        Me.pnlDatos.TabIndex = 63
        Me.pnlDatos.TabItem = Me.tabAsignar
        '
        'tabAsignar
        '
        Me.tabAsignar.AttachedControl = Me.pnlDatos
        Me.tabAsignar.GlobalItem = False
        Me.tabAsignar.Name = "tabAsignar"
        Me.tabAsignar.Text = "Asignar/" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Reasignar"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.GroupBox3)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(77, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(387, 215)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.tabLiberar
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.btnAceptarLiberar)
        Me.GroupBox3.Controls.Add(Me.btnCancelarLiberar)
        Me.GroupBox3.Location = New System.Drawing.Point(114, 76)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(174, 47)
        Me.GroupBox3.TabIndex = 151
        Me.GroupBox3.TabStop = False
        '
        'btnAceptarLiberar
        '
        Me.btnAceptarLiberar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptarLiberar.CausesValidation = False
        Me.btnAceptarLiberar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptarLiberar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptarLiberar.Image = CType(resources.GetObject("btnAceptarLiberar.Image"), System.Drawing.Image)
        Me.btnAceptarLiberar.Location = New System.Drawing.Point(6, 14)
        Me.btnAceptarLiberar.Name = "btnAceptarLiberar"
        Me.btnAceptarLiberar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptarLiberar.TabIndex = 11
        Me.btnAceptarLiberar.Text = "Aceptar"
        '
        'btnCancelarLiberar
        '
        Me.btnCancelarLiberar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelarLiberar.CausesValidation = False
        Me.btnCancelarLiberar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelarLiberar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelarLiberar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarLiberar.Image = CType(resources.GetObject("btnCancelarLiberar.Image"), System.Drawing.Image)
        Me.btnCancelarLiberar.Location = New System.Drawing.Point(88, 14)
        Me.btnCancelarLiberar.Name = "btnCancelarLiberar"
        Me.btnCancelarLiberar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelarLiberar.TabIndex = 12
        Me.btnCancelarLiberar.Text = "Cancelar"
        '
        'tabLiberar
        '
        Me.tabLiberar.AttachedControl = Me.SuperTabControlPanel2
        Me.tabLiberar.GlobalItem = False
        Me.tabLiberar.Name = "tabLiberar"
        Me.tabLiberar.Text = "Liberar"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.Panel2)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(77, 0)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(387, 215)
        Me.SuperTabControlPanel1.TabIndex = 0
        Me.SuperTabControlPanel1.TabItem = Me.tabCancelar
        '
        'tabCancelar
        '
        Me.tabCancelar.AttachedControl = Me.SuperTabControlPanel1
        Me.tabCancelar.GlobalItem = False
        Me.tabCancelar.Name = "tabCancelar"
        Me.tabCancelar.Text = "Cancelar"
        '
        'frmOpcionesLockers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 287)
        Me.Controls.Add(Me.tabLockers)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Name = "frmOpcionesLockers"
        Me.Text = "Opciones"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.panelLockers2.ResumeLayout(False)
        Me.panelLockers2.PerformLayout()
        CType(Me.picboxLocker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelLockers1.ResumeLayout(False)
        Me.panelLockers1.PerformLayout()
        CType(Me.picVer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.tabLockers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabLockers.ResumeLayout(False)
        Me.pnlDatos.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents txtDetalle As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnVerBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents panelLockers2 As System.Windows.Forms.Panel
    Friend WithEvents picboxLocker As System.Windows.Forms.PictureBox
    Friend WithEvents txtClave As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lbClave As System.Windows.Forms.Label
    Friend WithEvents lbInfo As System.Windows.Forms.Label
    Friend WithEvents panelLockers1 As System.Windows.Forms.Panel
    Friend WithEvents lbCandado As System.Windows.Forms.Label
    Friend WithEvents txtNoCandado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lbLlave As System.Windows.Forms.Label
    Friend WithEvents txtLlave As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tabLockers As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents pnlDatos As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabAsignar As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabLiberar As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabCancelar As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptAsignar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelarAsignar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptarLiberar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelarLiberar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptarBaja As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelarBaja As DevComponents.DotNetBar.ButtonX
    Friend WithEvents picVer As System.Windows.Forms.PictureBox
End Class
