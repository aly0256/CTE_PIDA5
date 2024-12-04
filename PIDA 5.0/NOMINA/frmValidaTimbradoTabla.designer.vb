<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmValidaTimbradoTabla
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmValidaTimbradoTabla))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.gpDatos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.lblAvisoCrit = New DevComponents.DotNetBar.LabelX()
        Me.btnValida = New DevComponents.DotNetBar.ButtonX()
        Me.lblEstatus = New DevComponents.DotNetBar.LabelX()
        Me.Line4 = New DevComponents.DotNetBar.Controls.Line()
        Me.chkFiltro = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.Line2 = New DevComponents.DotNetBar.Controls.Line()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.btnLimpiaCriterio = New DevComponents.DotNetBar.ButtonX()
        Me.btnQuita = New DevComponents.DotNetBar.ButtonX()
        Me.btnAgrega = New DevComponents.DotNetBar.ButtonX()
        Me.pbEstatus = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.txtCriterio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cmbCriterios = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.cmbPeriodos = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.btnDir = New DevComponents.DotNetBar.ButtonX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.lblNoDet = New DevComponents.DotNetBar.LabelX()
        Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
        Me.lblNoTimb = New DevComponents.DotNetBar.LabelX()
        Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
        Me.Line5 = New DevComponents.DotNetBar.Controls.Line()
        Me.lblNoReg = New DevComponents.DotNetBar.LabelX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.lblNoXML = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.cmbCias = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.cmbTipoPer = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.cmbAño = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.txtRuta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
        Me.Line3 = New DevComponents.DotNetBar.Controls.Line()
        Me.lblNoCoincide = New DevComponents.DotNetBar.LabelX()
        Me.btnResumen = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.lblFiltroApp = New DevComponents.DotNetBar.LabelX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.lblCoincidencias = New DevComponents.DotNetBar.LabelX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.listXML = New DevComponents.DotNetBar.ListBoxAdv()
        Me.btnLimpiar = New DevComponents.DotNetBar.ButtonX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpDatos.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.CheckAuthorization32
        Me.PictureBox1.Location = New System.Drawing.Point(13, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.TabIndex = 256
        Me.PictureBox1.TabStop = False
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(51, 9)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(338, 47)
        Me.ReflectionLabel1.TabIndex = 255
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>VALIDACION REGISTROS DE TIMBRADO</b></font>"
        '
        'gpDatos
        '
        Me.gpDatos.BackColor = System.Drawing.Color.Transparent
        Me.gpDatos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpDatos.Controls.Add(Me.lblAvisoCrit)
        Me.gpDatos.Controls.Add(Me.btnValida)
        Me.gpDatos.Controls.Add(Me.lblEstatus)
        Me.gpDatos.Controls.Add(Me.Line4)
        Me.gpDatos.Controls.Add(Me.chkFiltro)
        Me.gpDatos.Controls.Add(Me.LabelX13)
        Me.gpDatos.Controls.Add(Me.Line2)
        Me.gpDatos.Controls.Add(Me.LabelX11)
        Me.gpDatos.Controls.Add(Me.btnLimpiaCriterio)
        Me.gpDatos.Controls.Add(Me.btnQuita)
        Me.gpDatos.Controls.Add(Me.btnAgrega)
        Me.gpDatos.Controls.Add(Me.pbEstatus)
        Me.gpDatos.Controls.Add(Me.txtCriterio)
        Me.gpDatos.Controls.Add(Me.cmbCriterios)
        Me.gpDatos.Controls.Add(Me.LabelX10)
        Me.gpDatos.Controls.Add(Me.cmbPeriodos)
        Me.gpDatos.Controls.Add(Me.btnDir)
        Me.gpDatos.Controls.Add(Me.GroupPanel1)
        Me.gpDatos.Controls.Add(Me.cmbCias)
        Me.gpDatos.Controls.Add(Me.LabelX5)
        Me.gpDatos.Controls.Add(Me.cmbTipoPer)
        Me.gpDatos.Controls.Add(Me.cmbAño)
        Me.gpDatos.Controls.Add(Me.LabelX4)
        Me.gpDatos.Controls.Add(Me.LabelX3)
        Me.gpDatos.Controls.Add(Me.LabelX2)
        Me.gpDatos.Controls.Add(Me.LabelX1)
        Me.gpDatos.Controls.Add(Me.txtRuta)
        Me.gpDatos.Controls.Add(Me.Line1)
        Me.gpDatos.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpDatos.Location = New System.Drawing.Point(13, 62)
        Me.gpDatos.Name = "gpDatos"
        Me.gpDatos.Size = New System.Drawing.Size(427, 524)
        '
        '
        '
        Me.gpDatos.Style.BackColor = System.Drawing.Color.Transparent
        Me.gpDatos.Style.BackColor2 = System.Drawing.Color.Transparent
        Me.gpDatos.Style.BackColorGradientAngle = 90
        Me.gpDatos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDatos.Style.BorderBottomWidth = 1
        Me.gpDatos.Style.BorderColor = System.Drawing.SystemColors.AppWorkspace
        Me.gpDatos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDatos.Style.BorderLeftWidth = 1
        Me.gpDatos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDatos.Style.BorderRightWidth = 1
        Me.gpDatos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDatos.Style.BorderTopWidth = 1
        Me.gpDatos.Style.CornerDiameter = 4
        Me.gpDatos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpDatos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.gpDatos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpDatos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpDatos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpDatos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpDatos.TabIndex = 0
        '
        'lblAvisoCrit
        '
        Me.lblAvisoCrit.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblAvisoCrit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblAvisoCrit.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvisoCrit.ForeColor = System.Drawing.Color.Black
        Me.lblAvisoCrit.Location = New System.Drawing.Point(163, 307)
        Me.lblAvisoCrit.Name = "lblAvisoCrit"
        Me.lblAvisoCrit.Size = New System.Drawing.Size(251, 23)
        Me.lblAvisoCrit.TabIndex = 278
        Me.lblAvisoCrit.Text = "Sin filtros aplicados."
        Me.lblAvisoCrit.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'btnValida
        '
        Me.btnValida.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnValida.CausesValidation = False
        Me.btnValida.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnValida.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnValida.Image = Global.PIDA.My.Resources.Resources.Analyze48
        Me.btnValida.ImageFixedSize = New System.Drawing.Size(25, 25)
        Me.btnValida.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnValida.ImageTextSpacing = 5
        Me.btnValida.Location = New System.Drawing.Point(308, 417)
        Me.btnValida.Name = "btnValida"
        Me.btnValida.Size = New System.Drawing.Size(104, 86)
        Me.btnValida.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnValida.TabIndex = 261
        Me.btnValida.Text = "Validar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "información"
        '
        'lblEstatus
        '
        Me.lblEstatus.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblEstatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatus.ForeColor = System.Drawing.Color.Black
        Me.lblEstatus.Location = New System.Drawing.Point(14, 357)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(400, 23)
        Me.lblEstatus.TabIndex = 263
        Me.lblEstatus.Text = "Estatus"
        Me.lblEstatus.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Line4
        '
        Me.Line4.BackColor = System.Drawing.Color.Transparent
        Me.Line4.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Line4.Location = New System.Drawing.Point(14, 334)
        Me.Line4.Name = "Line4"
        Me.Line4.Size = New System.Drawing.Size(400, 23)
        Me.Line4.TabIndex = 277
        Me.Line4.Text = "Line4"
        '
        'chkFiltro
        '
        '
        '
        '
        Me.chkFiltro.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkFiltro.Location = New System.Drawing.Point(14, 306)
        Me.chkFiltro.Name = "chkFiltro"
        Me.chkFiltro.Size = New System.Drawing.Size(107, 23)
        Me.chkFiltro.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkFiltro.TabIndex = 276
        Me.chkFiltro.Text = "Filtro disponible"
        Me.chkFiltro.TextColor = System.Drawing.Color.Black
        '
        'LabelX13
        '
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX13.BackgroundStyle.BackColor = System.Drawing.Color.Transparent
        Me.LabelX13.BackgroundStyle.BackColor2 = System.Drawing.Color.Transparent
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX13.ForeColor = System.Drawing.Color.Black
        Me.LabelX13.Location = New System.Drawing.Point(12, 8)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(189, 23)
        Me.LabelX13.TabIndex = 275
        Me.LabelX13.Text = "Parámetros"
        '
        'Line2
        '
        Me.Line2.BackColor = System.Drawing.Color.Transparent
        Me.Line2.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Line2.Location = New System.Drawing.Point(12, 23)
        Me.Line2.Name = "Line2"
        Me.Line2.Size = New System.Drawing.Size(400, 23)
        Me.Line2.TabIndex = 274
        Me.Line2.Text = "Line2"
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.BackColor = System.Drawing.Color.Transparent
        Me.LabelX11.BackgroundStyle.BackColor2 = System.Drawing.Color.Transparent
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX11.ForeColor = System.Drawing.Color.Black
        Me.LabelX11.Location = New System.Drawing.Point(13, 168)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(189, 23)
        Me.LabelX11.TabIndex = 273
        Me.LabelX11.Text = "Validaciones extras"
        '
        'btnLimpiaCriterio
        '
        Me.btnLimpiaCriterio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLimpiaCriterio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLimpiaCriterio.Enabled = False
        Me.btnLimpiaCriterio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiaCriterio.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnLimpiaCriterio.Location = New System.Drawing.Point(316, 214)
        Me.btnLimpiaCriterio.Name = "btnLimpiaCriterio"
        Me.btnLimpiaCriterio.Size = New System.Drawing.Size(96, 21)
        Me.btnLimpiaCriterio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLimpiaCriterio.TabIndex = 272
        Me.btnLimpiaCriterio.Text = "Limpiar filtro"
        '
        'btnQuita
        '
        Me.btnQuita.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnQuita.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnQuita.Enabled = False
        Me.btnQuita.Image = Global.PIDA.My.Resources.Resources.Minus16
        Me.btnQuita.Location = New System.Drawing.Point(259, 214)
        Me.btnQuita.Name = "btnQuita"
        Me.btnQuita.Size = New System.Drawing.Size(42, 21)
        Me.btnQuita.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnQuita.TabIndex = 271
        '
        'btnAgrega
        '
        Me.btnAgrega.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAgrega.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAgrega.Enabled = False
        Me.btnAgrega.Image = Global.PIDA.My.Resources.Resources.Add
        Me.btnAgrega.Location = New System.Drawing.Point(215, 214)
        Me.btnAgrega.Name = "btnAgrega"
        Me.btnAgrega.Size = New System.Drawing.Size(42, 21)
        Me.btnAgrega.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAgrega.TabIndex = 270
        '
        'pbEstatus
        '
        '
        '
        '
        Me.pbEstatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pbEstatus.Location = New System.Drawing.Point(13, 385)
        Me.pbEstatus.Name = "pbEstatus"
        Me.pbEstatus.Size = New System.Drawing.Size(400, 17)
        Me.pbEstatus.TabIndex = 260
        Me.pbEstatus.Text = "ProgressBarX1"
        '
        'txtCriterio
        '
        '
        '
        '
        Me.txtCriterio.Border.Class = "TextBoxBorder"
        Me.txtCriterio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCriterio.Enabled = False
        Me.txtCriterio.Location = New System.Drawing.Point(12, 251)
        Me.txtCriterio.Multiline = True
        Me.txtCriterio.Name = "txtCriterio"
        Me.txtCriterio.PreventEnterBeep = True
        Me.txtCriterio.Size = New System.Drawing.Size(400, 44)
        Me.txtCriterio.TabIndex = 269
        '
        'cmbCriterios
        '
        Me.cmbCriterios.DisplayMember = "Text"
        Me.cmbCriterios.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCriterios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCriterios.Enabled = False
        Me.cmbCriterios.FormattingEnabled = True
        Me.cmbCriterios.ItemHeight = 15
        Me.cmbCriterios.Location = New System.Drawing.Point(67, 214)
        Me.cmbCriterios.Name = "cmbCriterios"
        Me.cmbCriterios.Size = New System.Drawing.Size(136, 21)
        Me.cmbCriterios.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbCriterios.TabIndex = 267
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX10.ForeColor = System.Drawing.Color.Black
        Me.LabelX10.Location = New System.Drawing.Point(13, 210)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(88, 23)
        Me.LabelX10.TabIndex = 266
        Me.LabelX10.Text = "Campos"
        '
        'cmbPeriodos
        '
        Me.cmbPeriodos.DisplayMember = "Text"
        Me.cmbPeriodos.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPeriodos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPeriodos.Enabled = False
        Me.cmbPeriodos.FormattingEnabled = True
        Me.cmbPeriodos.ItemHeight = 15
        Me.cmbPeriodos.Location = New System.Drawing.Point(322, 128)
        Me.cmbPeriodos.Name = "cmbPeriodos"
        Me.cmbPeriodos.Size = New System.Drawing.Size(79, 21)
        Me.cmbPeriodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPeriodos.TabIndex = 265
        '
        'btnDir
        '
        Me.btnDir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnDir.Location = New System.Drawing.Point(356, 73)
        Me.btnDir.Name = "btnDir"
        Me.btnDir.Size = New System.Drawing.Size(56, 21)
        Me.btnDir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnDir.TabIndex = 264
        Me.btnDir.Text = "..."
        '
        'GroupPanel1
        '
        Me.GroupPanel1.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel1.CanvasColor = System.Drawing.Color.Transparent
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel1.Controls.Add(Me.lblNoDet)
        Me.GroupPanel1.Controls.Add(Me.LabelX16)
        Me.GroupPanel1.Controls.Add(Me.lblNoTimb)
        Me.GroupPanel1.Controls.Add(Me.LabelX18)
        Me.GroupPanel1.Controls.Add(Me.Line5)
        Me.GroupPanel1.Controls.Add(Me.lblNoReg)
        Me.GroupPanel1.Controls.Add(Me.LabelX7)
        Me.GroupPanel1.Controls.Add(Me.lblNoXML)
        Me.GroupPanel1.Controls.Add(Me.LabelX6)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel1.Location = New System.Drawing.Point(13, 417)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(278, 90)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel1.Style.BackColor2 = System.Drawing.Color.Transparent
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColor = System.Drawing.SystemColors.ActiveBorder
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
        Me.GroupPanel1.TabIndex = 263
        '
        'lblNoDet
        '
        Me.lblNoDet.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblNoDet.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblNoDet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoDet.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNoDet.Location = New System.Drawing.Point(152, 66)
        Me.lblNoDet.Name = "lblNoDet"
        Me.lblNoDet.Size = New System.Drawing.Size(125, 15)
        Me.lblNoDet.TabIndex = 282
        Me.lblNoDet.Text = "--"
        Me.lblNoDet.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX16
        '
        Me.LabelX16.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX16.ForeColor = System.Drawing.Color.Black
        Me.LabelX16.Location = New System.Drawing.Point(152, 45)
        Me.LabelX16.Name = "LabelX16"
        Me.LabelX16.Size = New System.Drawing.Size(125, 23)
        Me.LabelX16.TabIndex = 281
        Me.LabelX16.Text = "Tabla detalles timb."
        Me.LabelX16.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblNoTimb
        '
        Me.lblNoTimb.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblNoTimb.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblNoTimb.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoTimb.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNoTimb.Location = New System.Drawing.Point(153, 25)
        Me.lblNoTimb.Name = "lblNoTimb"
        Me.lblNoTimb.Size = New System.Drawing.Size(124, 15)
        Me.lblNoTimb.TabIndex = 280
        Me.lblNoTimb.Text = "--"
        Me.lblNoTimb.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX18
        '
        Me.LabelX18.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX18.ForeColor = System.Drawing.Color.Black
        Me.LabelX18.Location = New System.Drawing.Point(153, 4)
        Me.LabelX18.Name = "LabelX18"
        Me.LabelX18.Size = New System.Drawing.Size(124, 23)
        Me.LabelX18.TabIndex = 279
        Me.LabelX18.Text = "Tabla timbrado"
        Me.LabelX18.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Line5
        '
        Me.Line5.BackColor = System.Drawing.Color.Transparent
        Me.Line5.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Line5.Location = New System.Drawing.Point(142, 6)
        Me.Line5.Name = "Line5"
        Me.Line5.Size = New System.Drawing.Size(10, 74)
        Me.Line5.TabIndex = 278
        Me.Line5.Text = "Line5"
        Me.Line5.VerticalLine = True
        '
        'lblNoReg
        '
        Me.lblNoReg.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblNoReg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblNoReg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoReg.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNoReg.Location = New System.Drawing.Point(-1, 65)
        Me.lblNoReg.Name = "lblNoReg"
        Me.lblNoReg.Size = New System.Drawing.Size(153, 15)
        Me.lblNoReg.TabIndex = 266
        Me.lblNoReg.Text = "--"
        Me.lblNoReg.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX7.ForeColor = System.Drawing.Color.Black
        Me.LabelX7.Location = New System.Drawing.Point(-1, 44)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(147, 23)
        Me.LabelX7.TabIndex = 265
        Me.LabelX7.Text = "Registros tabla Timbrado"
        Me.LabelX7.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblNoXML
        '
        Me.lblNoXML.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblNoXML.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblNoXML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoXML.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNoXML.Location = New System.Drawing.Point(0, 24)
        Me.lblNoXML.Name = "lblNoXML"
        Me.lblNoXML.Size = New System.Drawing.Size(147, 15)
        Me.lblNoXML.TabIndex = 263
        Me.lblNoXML.Text = "--"
        Me.lblNoXML.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX6.ForeColor = System.Drawing.Color.Black
        Me.LabelX6.Location = New System.Drawing.Point(0, 3)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(146, 23)
        Me.LabelX6.TabIndex = 262
        Me.LabelX6.Text = "No. de archivos XML"
        Me.LabelX6.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'cmbCias
        '
        Me.cmbCias.DisplayMember = "Text"
        Me.cmbCias.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCias.FormattingEnabled = True
        Me.cmbCias.ItemHeight = 15
        Me.cmbCias.Location = New System.Drawing.Point(12, 128)
        Me.cmbCias.Name = "cmbCias"
        Me.cmbCias.Size = New System.Drawing.Size(89, 21)
        Me.cmbCias.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbCias.TabIndex = 19
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX5.ForeColor = System.Drawing.Color.Black
        Me.LabelX5.Location = New System.Drawing.Point(12, 99)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(63, 23)
        Me.LabelX5.TabIndex = 18
        Me.LabelX5.Text = "Compañia"
        '
        'cmbTipoPer
        '
        Me.cmbTipoPer.DisplayMember = "Text"
        Me.cmbTipoPer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTipoPer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPer.FormattingEnabled = True
        Me.cmbTipoPer.ItemHeight = 15
        Me.cmbTipoPer.Location = New System.Drawing.Point(122, 128)
        Me.cmbTipoPer.Name = "cmbTipoPer"
        Me.cmbTipoPer.Size = New System.Drawing.Size(79, 21)
        Me.cmbTipoPer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipoPer.TabIndex = 17
        '
        'cmbAño
        '
        Me.cmbAño.DisplayMember = "Text"
        Me.cmbAño.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAño.FormattingEnabled = True
        Me.cmbAño.ItemHeight = 15
        Me.cmbAño.Location = New System.Drawing.Point(222, 128)
        Me.cmbAño.Name = "cmbAño"
        Me.cmbAño.Size = New System.Drawing.Size(79, 21)
        Me.cmbAño.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbAño.TabIndex = 16
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.Color.Black
        Me.LabelX4.Location = New System.Drawing.Point(322, 99)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(79, 23)
        Me.LabelX4.TabIndex = 12
        Me.LabelX4.Text = "No. de periodo"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.ForeColor = System.Drawing.Color.Black
        Me.LabelX3.Location = New System.Drawing.Point(122, 99)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 23)
        Me.LabelX3.TabIndex = 10
        Me.LabelX3.Text = "Tipo periodo"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.Color.Black
        Me.LabelX2.Location = New System.Drawing.Point(222, 99)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(29, 23)
        Me.LabelX2.TabIndex = 8
        Me.LabelX2.Text = "Año"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(12, 41)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(89, 23)
        Me.LabelX1.TabIndex = 6
        Me.LabelX1.Text = "Ruta de XMLs"
        '
        'txtRuta
        '
        '
        '
        '
        Me.txtRuta.Border.Class = "TextBoxBorder"
        Me.txtRuta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRuta.Enabled = False
        Me.txtRuta.Location = New System.Drawing.Point(12, 73)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.PreventEnterBeep = True
        Me.txtRuta.Size = New System.Drawing.Size(338, 21)
        Me.txtRuta.TabIndex = 0
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.Transparent
        Me.Line1.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Line1.Location = New System.Drawing.Point(13, 185)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(400, 23)
        Me.Line1.TabIndex = 268
        Me.Line1.Text = "Line1"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cancel16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(251, 16)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(105, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 259
        Me.btnCerrar.Text = "Salir"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnAceptar.Location = New System.Drawing.Point(134, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(105, 25)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 258
        Me.btnAceptar.Text = "Actualizar"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel2.CanvasColor = System.Drawing.Color.Transparent
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel2.Controls.Add(Me.LabelX14)
        Me.GroupPanel2.Controls.Add(Me.Line3)
        Me.GroupPanel2.Controls.Add(Me.lblNoCoincide)
        Me.GroupPanel2.Controls.Add(Me.btnResumen)
        Me.GroupPanel2.Controls.Add(Me.LabelX12)
        Me.GroupPanel2.Controls.Add(Me.lblFiltroApp)
        Me.GroupPanel2.Controls.Add(Me.LabelX8)
        Me.GroupPanel2.Controls.Add(Me.lblCoincidencias)
        Me.GroupPanel2.Controls.Add(Me.LabelX9)
        Me.GroupPanel2.Controls.Add(Me.listXML)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel2.Location = New System.Drawing.Point(446, 62)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(373, 460)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel2.Style.BackColor2 = System.Drawing.Color.Transparent
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColor = System.Drawing.SystemColors.AppWorkspace
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
        Me.GroupPanel2.TabIndex = 264
        '
        'LabelX14
        '
        Me.LabelX14.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX14.BackgroundStyle.BackColor = System.Drawing.Color.Transparent
        Me.LabelX14.BackgroundStyle.BackColor2 = System.Drawing.Color.Transparent
        Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX14.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX14.ForeColor = System.Drawing.Color.Black
        Me.LabelX14.Location = New System.Drawing.Point(10, 8)
        Me.LabelX14.Name = "LabelX14"
        Me.LabelX14.Size = New System.Drawing.Size(189, 23)
        Me.LabelX14.TabIndex = 277
        Me.LabelX14.Text = "Coincidencias"
        '
        'Line3
        '
        Me.Line3.BackColor = System.Drawing.Color.Transparent
        Me.Line3.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Line3.Location = New System.Drawing.Point(10, 23)
        Me.Line3.Name = "Line3"
        Me.Line3.Size = New System.Drawing.Size(346, 23)
        Me.Line3.TabIndex = 276
        Me.Line3.Text = "Line3"
        '
        'lblNoCoincide
        '
        Me.lblNoCoincide.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblNoCoincide.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblNoCoincide.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoCoincide.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblNoCoincide.Location = New System.Drawing.Point(76, 366)
        Me.lblNoCoincide.Name = "lblNoCoincide"
        Me.lblNoCoincide.Size = New System.Drawing.Size(27, 23)
        Me.lblNoCoincide.TabIndex = 269
        Me.lblNoCoincide.Text = "--"
        '
        'btnResumen
        '
        Me.btnResumen.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnResumen.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnResumen.Enabled = False
        Me.btnResumen.Image = Global.PIDA.My.Resources.Resources.tests24
        Me.btnResumen.ImageFixedSize = New System.Drawing.Size(20, 20)
        Me.btnResumen.Location = New System.Drawing.Point(134, 414)
        Me.btnResumen.Name = "btnResumen"
        Me.btnResumen.Size = New System.Drawing.Size(105, 30)
        Me.btnResumen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnResumen.TabIndex = 266
        Me.btnResumen.Text = "Resumen"
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX12.ForeColor = System.Drawing.Color.Black
        Me.LabelX12.Location = New System.Drawing.Point(10, 366)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(66, 23)
        Me.LabelX12.TabIndex = 268
        Me.LabelX12.Text = "Sin coincidir:"
        '
        'lblFiltroApp
        '
        Me.lblFiltroApp.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblFiltroApp.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblFiltroApp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFiltroApp.ForeColor = System.Drawing.Color.Black
        Me.lblFiltroApp.Location = New System.Drawing.Point(-1, 69)
        Me.lblFiltroApp.Name = "lblFiltroApp"
        Me.lblFiltroApp.Size = New System.Drawing.Size(373, 23)
        Me.lblFiltroApp.TabIndex = 267
        Me.lblFiltroApp.Text = "- Filtro aplicado: <> -"
        Me.lblFiltroApp.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX8.ForeColor = System.Drawing.Color.Black
        Me.LabelX8.Location = New System.Drawing.Point(10, 40)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(287, 23)
        Me.LabelX8.TabIndex = 266
        Me.LabelX8.Text = "Relojes de XML que existen en tabla Timbrado"
        '
        'lblCoincidencias
        '
        Me.lblCoincidencias.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblCoincidencias.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCoincidencias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCoincidencias.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblCoincidencias.Location = New System.Drawing.Point(119, 341)
        Me.lblCoincidencias.Name = "lblCoincidencias"
        Me.lblCoincidencias.Size = New System.Drawing.Size(27, 23)
        Me.lblCoincidencias.TabIndex = 265
        Me.lblCoincidencias.Text = "--"
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX9.ForeColor = System.Drawing.Color.Black
        Me.LabelX9.Location = New System.Drawing.Point(10, 341)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(125, 23)
        Me.LabelX9.TabIndex = 263
        Me.LabelX9.Text = "No. de coincidencias:"
        '
        'listXML
        '
        Me.listXML.AutoScroll = True
        '
        '
        '
        Me.listXML.BackgroundStyle.Class = "ListBoxAdv"
        Me.listXML.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.listXML.ContainerControlProcessDialogKey = True
        Me.listXML.DragDropSupport = True
        Me.listXML.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listXML.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.listXML.Location = New System.Drawing.Point(10, 100)
        Me.listXML.Name = "listXML"
        Me.listXML.Size = New System.Drawing.Size(346, 235)
        Me.listXML.TabIndex = 9
        Me.listXML.Text = "ListBoxAdv1"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLimpiar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLimpiar.Image = Global.PIDA.My.Resources.Resources.brush
        Me.btnLimpiar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnLimpiar.Location = New System.Drawing.Point(15, 16)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(105, 25)
        Me.btnLimpiar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLimpiar.TabIndex = 267
        Me.btnLimpiar.Text = "Limpiar todo"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel3.CanvasColor = System.Drawing.Color.Transparent
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel3.Controls.Add(Me.btnAceptar)
        Me.GroupPanel3.Controls.Add(Me.btnLimpiar)
        Me.GroupPanel3.Controls.Add(Me.btnCerrar)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel3.Location = New System.Drawing.Point(446, 528)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(372, 58)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor = System.Drawing.Color.Transparent
        Me.GroupPanel3.Style.BackColor2 = System.Drawing.Color.Transparent
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColor = System.Drawing.SystemColors.AppWorkspace
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
        Me.GroupPanel3.TabIndex = 268
        '
        'frmValidaTimbradoTabla
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 602)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.gpDatos)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmValidaTimbradoTabla"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Validar registros timbrados"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpDatos.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents gpDatos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtRuta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents cmbTipoPer As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbAño As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbCias As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents pbEstatus As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents btnValida As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lblNoXML As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblEstatus As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents listXML As DevComponents.DotNetBar.ListBoxAdv
    Friend WithEvents lblCoincidencias As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnResumen As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnLimpiar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmbPeriodos As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents cmbCriterios As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents btnLimpiaCriterio As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnQuita As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAgrega As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtCriterio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblFiltroApp As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblNoCoincide As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblNoReg As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Line2 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Line3 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Line4 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents chkFiltro As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents lblAvisoCrit As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblNoDet As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblNoTimb As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Line5 As DevComponents.DotNetBar.Controls.Line
End Class
