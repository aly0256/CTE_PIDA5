<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSuplentes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSuplentes))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.sup3 = New System.Windows.Forms.Panel()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnActivo3 = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.cmbSuplente3 = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnActivo2 = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.cmbSuplente2 = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnActivo1 = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.cmbSuplente1 = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.sup2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtFechaFinal = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.chkDefinido = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkIndefinido = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.dtFechaInicial = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.sup1 = New System.Windows.Forms.Panel()
        Me.cmbUsuarioPrincipal = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.sup3.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.sup2.SuspendLayout()
        CType(Me.dtFechaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.sup1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ReflectionLabel1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(12)
        Me.Panel1.Size = New System.Drawing.Size(540, 59)
        Me.Panel1.TabIndex = 99
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(50, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(478, 44)
        Me.ReflectionLabel1.TabIndex = 84
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>SUPLENTES TEMPORALES</b></font>"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Suplente32
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Padding = New System.Windows.Forms.Padding(0, 0, 6, 6)
        Me.PictureBox1.Size = New System.Drawing.Size(38, 35)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 85
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.btnAceptar)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Location = New System.Drawing.Point(352, 362)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(176, 47)
        Me.GroupBox1.TabIndex = 110
        Me.GroupBox1.TabStop = False
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.Location = New System.Drawing.Point(6, 14)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCancelar.Location = New System.Drawing.Point(90, 14)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cancelar"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.sup3)
        Me.Panel4.Controls.Add(Me.sup2)
        Me.Panel4.Controls.Add(Me.sup1)
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Location = New System.Drawing.Point(0, 65)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Padding = New System.Windows.Forms.Padding(12)
        Me.Panel4.Size = New System.Drawing.Size(540, 418)
        Me.Panel4.TabIndex = 111
        '
        'sup3
        '
        Me.sup3.BackColor = System.Drawing.SystemColors.Window
        Me.sup3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sup3.Controls.Add(Me.GroupPanel3)
        Me.sup3.Controls.Add(Me.GroupPanel2)
        Me.sup3.Controls.Add(Me.GroupPanel1)
        Me.sup3.Controls.Add(Me.Label4)
        Me.sup3.Dock = System.Windows.Forms.DockStyle.Top
        Me.sup3.Location = New System.Drawing.Point(12, 179)
        Me.sup3.Name = "sup3"
        Me.sup3.Size = New System.Drawing.Size(516, 177)
        Me.sup3.TabIndex = 141
        '
        'GroupPanel3
        '
        Me.GroupPanel3.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel3.Controls.Add(Me.Label3)
        Me.GroupPanel3.Controls.Add(Me.btnActivo3)
        Me.GroupPanel3.Controls.Add(Me.cmbSuplente3)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(11, 117)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(492, 39)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor = System.Drawing.SystemColors.Window
        Me.GroupPanel3.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderLeftWidth = 1
        Me.GroupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderRightWidth = 1
        Me.GroupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderTopWidth = 1
        Me.GroupPanel3.Style.CornerDiameter = 4
        Me.GroupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel3.TabIndex = 113
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Font = New System.Drawing.Font("Wingdings 2", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(0, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 29)
        Me.Label3.TabIndex = 103
        Me.Label3.Text = "w"
        '
        'btnActivo3
        '
        '
        '
        '
        Me.btnActivo3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnActivo3.Location = New System.Drawing.Point(44, 7)
        Me.btnActivo3.Name = "btnActivo3"
        Me.btnActivo3.OffText = "INACTIVO"
        Me.btnActivo3.OffTextColor = System.Drawing.SystemColors.ControlText
        Me.btnActivo3.OnText = "ACTIVO"
        Me.btnActivo3.OnTextColor = System.Drawing.SystemColors.ControlText
        Me.btnActivo3.Size = New System.Drawing.Size(103, 23)
        Me.btnActivo3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnActivo3.TabIndex = 100
        Me.btnActivo3.Value = True
        Me.btnActivo3.ValueObject = "Y"
        '
        'cmbSuplente3
        '
        Me.cmbSuplente3.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbSuplente3.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbSuplente3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbSuplente3.ButtonDropDown.Visible = True
        Me.cmbSuplente3.DisplayMembers = "usuario,nombre"
        Me.cmbSuplente3.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbSuplente3.Location = New System.Drawing.Point(153, 7)
        Me.cmbSuplente3.Name = "cmbSuplente3"
        Me.cmbSuplente3.Size = New System.Drawing.Size(329, 23)
        Me.cmbSuplente3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbSuplente3.TabIndex = 101
        Me.cmbSuplente3.ValueMember = "usuario"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.Label2)
        Me.GroupPanel2.Controls.Add(Me.btnActivo2)
        Me.GroupPanel2.Controls.Add(Me.cmbSuplente2)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(11, 72)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(492, 39)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor = System.Drawing.SystemColors.Window
        Me.GroupPanel2.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 112
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(0, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 29)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "v"
        '
        'btnActivo2
        '
        '
        '
        '
        Me.btnActivo2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnActivo2.Location = New System.Drawing.Point(44, 7)
        Me.btnActivo2.Name = "btnActivo2"
        Me.btnActivo2.OffText = "INACTIVO"
        Me.btnActivo2.OffTextColor = System.Drawing.SystemColors.ControlText
        Me.btnActivo2.OnText = "ACTIVO"
        Me.btnActivo2.OnTextColor = System.Drawing.SystemColors.ControlText
        Me.btnActivo2.Size = New System.Drawing.Size(103, 23)
        Me.btnActivo2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnActivo2.TabIndex = 100
        Me.btnActivo2.Value = True
        Me.btnActivo2.ValueObject = "Y"
        '
        'cmbSuplente2
        '
        Me.cmbSuplente2.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbSuplente2.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbSuplente2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbSuplente2.ButtonDropDown.Visible = True
        Me.cmbSuplente2.DisplayMembers = "usuario,nombre"
        Me.cmbSuplente2.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbSuplente2.Location = New System.Drawing.Point(153, 7)
        Me.cmbSuplente2.Name = "cmbSuplente2"
        Me.cmbSuplente2.Size = New System.Drawing.Size(329, 23)
        Me.cmbSuplente2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbSuplente2.TabIndex = 101
        Me.cmbSuplente2.ValueMember = "usuario"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel1.Controls.Add(Me.Label1)
        Me.GroupPanel1.Controls.Add(Me.btnActivo1)
        Me.GroupPanel1.Controls.Add(Me.cmbSuplente1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(11, 27)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(492, 39)
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
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 111
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(0, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 29)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "u"
        '
        'btnActivo1
        '
        '
        '
        '
        Me.btnActivo1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnActivo1.Location = New System.Drawing.Point(44, 7)
        Me.btnActivo1.Name = "btnActivo1"
        Me.btnActivo1.OffText = "INACTIVO"
        Me.btnActivo1.OffTextColor = System.Drawing.SystemColors.ControlText
        Me.btnActivo1.OnText = "ACTIVO"
        Me.btnActivo1.OnTextColor = System.Drawing.SystemColors.ControlText
        Me.btnActivo1.Size = New System.Drawing.Size(103, 23)
        Me.btnActivo1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnActivo1.TabIndex = 100
        Me.btnActivo1.Value = True
        Me.btnActivo1.ValueObject = "Y"
        '
        'cmbSuplente1
        '
        Me.cmbSuplente1.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbSuplente1.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbSuplente1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbSuplente1.ButtonDropDown.Visible = True
        Me.cmbSuplente1.DisplayMembers = "usuario,nombre"
        Me.cmbSuplente1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbSuplente1.Location = New System.Drawing.Point(153, 7)
        Me.cmbSuplente1.Name = "cmbSuplente1"
        Me.cmbSuplente1.Size = New System.Drawing.Size(329, 23)
        Me.cmbSuplente1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbSuplente1.TabIndex = 101
        Me.cmbSuplente1.ValueMember = "usuario"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(514, 18)
        Me.Label4.TabIndex = 77
        Me.Label4.Text = "Suplentes"
        '
        'sup2
        '
        Me.sup2.BackColor = System.Drawing.SystemColors.Window
        Me.sup2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sup2.Controls.Add(Me.Label5)
        Me.sup2.Controls.Add(Me.dtFechaFinal)
        Me.sup2.Controls.Add(Me.chkDefinido)
        Me.sup2.Controls.Add(Me.chkIndefinido)
        Me.sup2.Controls.Add(Me.dtFechaInicial)
        Me.sup2.Controls.Add(Me.Label17)
        Me.sup2.Dock = System.Windows.Forms.DockStyle.Top
        Me.sup2.Location = New System.Drawing.Point(12, 86)
        Me.sup2.Name = "sup2"
        Me.sup2.Size = New System.Drawing.Size(516, 93)
        Me.sup2.TabIndex = 141
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(187, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 13)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "al"
        '
        'dtFechaFinal
        '
        '
        '
        '
        Me.dtFechaFinal.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtFechaFinal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaFinal.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtFechaFinal.ButtonDropDown.Visible = True
        Me.dtFechaFinal.IsPopupCalendarOpen = False
        Me.dtFechaFinal.Location = New System.Drawing.Point(202, 55)
        '
        '
        '
        Me.dtFechaFinal.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtFechaFinal.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaFinal.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtFechaFinal.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtFechaFinal.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaFinal.MonthCalendar.DisplayMonth = New Date(2015, 2, 1, 0, 0, 0, 0)
        Me.dtFechaFinal.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtFechaFinal.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtFechaFinal.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaFinal.MonthCalendar.TodayButtonVisible = True
        Me.dtFechaFinal.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtFechaFinal.Name = "dtFechaFinal"
        Me.dtFechaFinal.Size = New System.Drawing.Size(84, 20)
        Me.dtFechaFinal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtFechaFinal.TabIndex = 81
        '
        'chkDefinido
        '
        Me.chkDefinido.AutoSize = True
        Me.chkDefinido.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkDefinido.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkDefinido.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkDefinido.FocusCuesEnabled = False
        Me.chkDefinido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDefinido.Location = New System.Drawing.Point(17, 57)
        Me.chkDefinido.Name = "chkDefinido"
        Me.chkDefinido.Size = New System.Drawing.Size(86, 16)
        Me.chkDefinido.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkDefinido.TabIndex = 80
        Me.chkDefinido.Text = "Definido del"
        Me.chkDefinido.TextColor = System.Drawing.SystemColors.ControlText
        '
        'chkIndefinido
        '
        Me.chkIndefinido.AutoSize = True
        Me.chkIndefinido.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkIndefinido.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkIndefinido.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkIndefinido.FocusCuesEnabled = False
        Me.chkIndefinido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIndefinido.Location = New System.Drawing.Point(17, 28)
        Me.chkIndefinido.Name = "chkIndefinido"
        Me.chkIndefinido.Size = New System.Drawing.Size(75, 16)
        Me.chkIndefinido.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkIndefinido.TabIndex = 79
        Me.chkIndefinido.Text = "Indefinido"
        Me.chkIndefinido.TextColor = System.Drawing.SystemColors.ControlText
        '
        'dtFechaInicial
        '
        '
        '
        '
        Me.dtFechaInicial.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtFechaInicial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaInicial.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtFechaInicial.ButtonDropDown.Visible = True
        Me.dtFechaInicial.IsPopupCalendarOpen = False
        Me.dtFechaInicial.Location = New System.Drawing.Point(103, 55)
        '
        '
        '
        Me.dtFechaInicial.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtFechaInicial.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaInicial.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtFechaInicial.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtFechaInicial.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtFechaInicial.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtFechaInicial.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtFechaInicial.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtFechaInicial.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtFechaInicial.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtFechaInicial.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaInicial.MonthCalendar.DisplayMonth = New Date(2015, 2, 1, 0, 0, 0, 0)
        Me.dtFechaInicial.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtFechaInicial.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtFechaInicial.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtFechaInicial.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtFechaInicial.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtFechaInicial.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaInicial.MonthCalendar.TodayButtonVisible = True
        Me.dtFechaInicial.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtFechaInicial.Name = "dtFechaInicial"
        Me.dtFechaInicial.Size = New System.Drawing.Size(84, 20)
        Me.dtFechaInicial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtFechaInicial.TabIndex = 78
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label17.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(0, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(514, 18)
        Me.Label17.TabIndex = 77
        Me.Label17.Text = "Periodo"
        '
        'sup1
        '
        Me.sup1.BackColor = System.Drawing.SystemColors.Window
        Me.sup1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sup1.Controls.Add(Me.cmbUsuarioPrincipal)
        Me.sup1.Controls.Add(Me.Label6)
        Me.sup1.Controls.Add(Me.Label7)
        Me.sup1.Dock = System.Windows.Forms.DockStyle.Top
        Me.sup1.Location = New System.Drawing.Point(12, 12)
        Me.sup1.Name = "sup1"
        Me.sup1.Size = New System.Drawing.Size(516, 74)
        Me.sup1.TabIndex = 139
        '
        'cmbUsuarioPrincipal
        '
        Me.cmbUsuarioPrincipal.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbUsuarioPrincipal.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbUsuarioPrincipal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbUsuarioPrincipal.ButtonDropDown.Visible = True
        Me.cmbUsuarioPrincipal.DisplayMembers = "usuario,nombre"
        Me.cmbUsuarioPrincipal.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbUsuarioPrincipal.Location = New System.Drawing.Point(63, 32)
        Me.cmbUsuarioPrincipal.Name = "cmbUsuarioPrincipal"
        Me.cmbUsuarioPrincipal.Size = New System.Drawing.Size(417, 23)
        Me.cmbUsuarioPrincipal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbUsuarioPrincipal.TabIndex = 102
        Me.cmbUsuarioPrincipal.ValueMember = "usuario"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 78
        Me.Label6.Text = "Usuario"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(514, 18)
        Me.Label7.TabIndex = 77
        Me.Label7.Text = "Usuario"
        '
        'frmSuplentes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 494)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSuplentes"
        Me.Text = "Suplentes"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.sup3.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        Me.GroupPanel3.PerformLayout()
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel2.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.sup2.ResumeLayout(False)
        Me.sup2.PerformLayout()
        CType(Me.dtFechaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaInicial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.sup1.ResumeLayout(False)
        Me.sup1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents sup3 As System.Windows.Forms.Panel
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnActivo3 As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents cmbSuplente3 As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnActivo2 As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents cmbSuplente2 As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnActivo1 As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents cmbSuplente1 As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents sup2 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtFechaFinal As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents chkDefinido As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkIndefinido As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents dtFechaInicial As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents sup1 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbUsuarioPrincipal As DevComponents.DotNetBar.Controls.ComboTree
End Class
