<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecibosCFDI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecibosCFDI))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.gpParametros = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.gpAvance = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.lblAvance = New System.Windows.Forms.Label()
        Me.lblTiempo = New System.Windows.Forms.Label()
        Me.pbAvance = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.txtRiesgo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtBanco = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbCia = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnDirectorioArchivos = New DevComponents.DotNetBar.ButtonX()
        Me.txtDirectorioArchivos = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnDirectorioCD = New DevComponents.DotNetBar.ButtonX()
        Me.txtDirectorioCD = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtClaveWeb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtUsuarioWeb = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtClaveKEY = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnArchivoCER = New DevComponents.DotNetBar.ButtonX()
        Me.txtArchivoCER = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnArchivoKEY = New DevComponents.DotNetBar.ButtonX()
        Me.txtArchivoKEY = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnPrueba = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbAnoPeriodo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader6 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader7 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.gpControles = New System.Windows.Forms.GroupBox()
        Me.btnExportar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.dlgArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.bgTimbrado = New System.ComponentModel.BackgroundWorker()
        Me.PreguntaArchivo = New System.Windows.Forms.SaveFileDialog()
        Me.tmrTranscurre = New System.Windows.Forms.Timer(Me.components)
        Me.gpParametros.SuspendLayout()
        Me.gpAvance.SuspendLayout()
        Me.gpControles.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(50, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(451, 46)
        Me.ReflectionLabel1.TabIndex = 113
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>RECIBOS CFDI</b></font>"
        '
        'gpParametros
        '
        Me.gpParametros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpParametros.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpParametros.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpParametros.Controls.Add(Me.gpAvance)
        Me.gpParametros.Controls.Add(Me.txtRiesgo)
        Me.gpParametros.Controls.Add(Me.txtBanco)
        Me.gpParametros.Controls.Add(Me.Label11)
        Me.gpParametros.Controls.Add(Me.Label9)
        Me.gpParametros.Controls.Add(Me.cmbCia)
        Me.gpParametros.Controls.Add(Me.Label10)
        Me.gpParametros.Controls.Add(Me.Label8)
        Me.gpParametros.Controls.Add(Me.btnDirectorioArchivos)
        Me.gpParametros.Controls.Add(Me.txtDirectorioArchivos)
        Me.gpParametros.Controls.Add(Me.Label7)
        Me.gpParametros.Controls.Add(Me.btnDirectorioCD)
        Me.gpParametros.Controls.Add(Me.txtDirectorioCD)
        Me.gpParametros.Controls.Add(Me.Label6)
        Me.gpParametros.Controls.Add(Me.txtClaveWeb)
        Me.gpParametros.Controls.Add(Me.Label5)
        Me.gpParametros.Controls.Add(Me.txtUsuarioWeb)
        Me.gpParametros.Controls.Add(Me.Label4)
        Me.gpParametros.Controls.Add(Me.txtClaveKEY)
        Me.gpParametros.Controls.Add(Me.Label3)
        Me.gpParametros.Controls.Add(Me.btnArchivoCER)
        Me.gpParametros.Controls.Add(Me.txtArchivoCER)
        Me.gpParametros.Controls.Add(Me.Label1)
        Me.gpParametros.Controls.Add(Me.btnArchivoKEY)
        Me.gpParametros.Controls.Add(Me.txtArchivoKEY)
        Me.gpParametros.Controls.Add(Me.btnPrueba)
        Me.gpParametros.Controls.Add(Me.Label2)
        Me.gpParametros.Controls.Add(Me.cmbAnoPeriodo)
        Me.gpParametros.Controls.Add(Me.Label12)
        Me.gpParametros.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpParametros.Location = New System.Drawing.Point(12, 64)
        Me.gpParametros.Name = "gpParametros"
        Me.gpParametros.Size = New System.Drawing.Size(942, 375)
        '
        '
        '
        Me.gpParametros.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpParametros.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpParametros.Style.BackColorGradientAngle = 90
        Me.gpParametros.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpParametros.Style.BorderBottomWidth = 1
        Me.gpParametros.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpParametros.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpParametros.Style.BorderLeftWidth = 1
        Me.gpParametros.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpParametros.Style.BorderRightWidth = 1
        Me.gpParametros.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpParametros.Style.BorderTopWidth = 1
        Me.gpParametros.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpParametros.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpParametros.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpParametros.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpParametros.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpParametros.TabIndex = 0
        '
        'gpAvance
        '
        Me.gpAvance.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpAvance.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.gpAvance.Controls.Add(Me.lblAvance)
        Me.gpAvance.Controls.Add(Me.lblTiempo)
        Me.gpAvance.Controls.Add(Me.pbAvance)
        Me.gpAvance.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpAvance.Location = New System.Drawing.Point(362, 72)
        Me.gpAvance.Name = "gpAvance"
        Me.gpAvance.Size = New System.Drawing.Size(216, 229)
        '
        '
        '
        Me.gpAvance.Style.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.gpAvance.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Me.gpAvance.Style.BackColorGradientAngle = 90
        Me.gpAvance.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpAvance.Style.BorderBottomWidth = 2
        Me.gpAvance.Style.BorderColor = System.Drawing.SystemColors.Highlight
        Me.gpAvance.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpAvance.Style.BorderLeftWidth = 1
        Me.gpAvance.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpAvance.Style.BorderRightWidth = 1
        Me.gpAvance.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpAvance.Style.BorderTopWidth = 1
        Me.gpAvance.Style.CornerDiameter = 4
        Me.gpAvance.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpAvance.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.gpAvance.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpAvance.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpAvance.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpAvance.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpAvance.TabIndex = 275
        Me.gpAvance.Visible = False
        '
        'lblAvance
        '
        Me.lblAvance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblAvance.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblAvance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvance.Location = New System.Drawing.Point(0, 162)
        Me.lblAvance.Name = "lblAvance"
        Me.lblAvance.Size = New System.Drawing.Size(214, 44)
        Me.lblAvance.TabIndex = 273
        Me.lblAvance.Text = "Preparando datos..."
        Me.lblAvance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTiempo
        '
        Me.lblTiempo.BackColor = System.Drawing.SystemColors.Highlight
        Me.lblTiempo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblTiempo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTiempo.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblTiempo.Location = New System.Drawing.Point(0, 206)
        Me.lblTiempo.Name = "lblTiempo"
        Me.lblTiempo.Size = New System.Drawing.Size(214, 20)
        Me.lblTiempo.TabIndex = 272
        Me.lblTiempo.Text = "Tiempo..."
        '
        'pbAvance
        '
        Me.pbAvance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        '
        '
        '
        Me.pbAvance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pbAvance.Dock = System.Windows.Forms.DockStyle.Top
        Me.pbAvance.Location = New System.Drawing.Point(0, 0)
        Me.pbAvance.Name = "pbAvance"
        Me.pbAvance.Padding = New System.Windows.Forms.Padding(5)
        Me.pbAvance.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.pbAvance.ProgressColor = System.Drawing.Color.MediumBlue
        Me.pbAvance.ProgressTextFormat = ""
        Me.pbAvance.Size = New System.Drawing.Size(214, 152)
        Me.pbAvance.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.pbAvance.TabIndex = 270
        '
        'txtRiesgo
        '
        Me.txtRiesgo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtRiesgo.Border.Class = "TextBoxBorder"
        Me.txtRiesgo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRiesgo.ButtonCustom.Tooltip = ""
        Me.txtRiesgo.ButtonCustom2.Tooltip = ""
        Me.txtRiesgo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRiesgo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtRiesgo.Location = New System.Drawing.Point(122, 329)
        Me.txtRiesgo.Name = "txtRiesgo"
        Me.txtRiesgo.Size = New System.Drawing.Size(133, 21)
        Me.txtRiesgo.TabIndex = 118
        '
        'txtBanco
        '
        Me.txtBanco.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtBanco.Border.Class = "TextBoxBorder"
        Me.txtBanco.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBanco.ButtonCustom.Tooltip = ""
        Me.txtBanco.ButtonCustom2.Tooltip = ""
        Me.txtBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBanco.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBanco.Location = New System.Drawing.Point(122, 300)
        Me.txtBanco.Name = "txtBanco"
        Me.txtBanco.Size = New System.Drawing.Size(133, 21)
        Me.txtBanco.TabIndex = 117
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Window
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 329)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 15)
        Me.Label11.TabIndex = 116
        Me.Label11.Text = "Riesgo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Window
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 302)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 15)
        Me.Label9.TabIndex = 114
        Me.Label9.Text = "Banco"
        '
        'cmbCia
        '
        Me.cmbCia.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbCia.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbCia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbCia.ButtonClear.Tooltip = ""
        Me.cmbCia.ButtonCustom.Tooltip = ""
        Me.cmbCia.ButtonCustom2.Tooltip = ""
        Me.cmbCia.ButtonDropDown.Tooltip = ""
        Me.cmbCia.ButtonDropDown.Visible = True
        Me.cmbCia.Columns.Add(Me.ColumnHeader1)
        Me.cmbCia.Columns.Add(Me.ColumnHeader2)
        Me.cmbCia.DropDownHeight = 180
        Me.cmbCia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCia.FormatString = "d"
        Me.cmbCia.FormattingEnabled = True
        Me.cmbCia.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbCia.Location = New System.Drawing.Point(122, 41)
        Me.cmbCia.Name = "cmbCia"
        Me.cmbCia.Size = New System.Drawing.Size(808, 23)
        Me.cmbCia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbCia.TabIndex = 1
        Me.cmbCia.ValueMember = "cod_comp"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "cod_comp"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Código"
        Me.ColumnHeader1.Width.Absolute = 70
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "nombre"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Compañía"
        Me.ColumnHeader2.Width.Absolute = 150
        Me.ColumnHeader2.Width.AutoSize = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Window
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(12, 41)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 15)
        Me.Label10.TabIndex = 112
        Me.Label10.Text = "Compañía"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Window
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 275)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(215, 15)
        Me.Label8.TabIndex = 108
        Me.Label8.Text = "Directorio destino archivos XML y PDF"
        '
        'btnDirectorioArchivos
        '
        Me.btnDirectorioArchivos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDirectorioArchivos.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnDirectorioArchivos.Location = New System.Drawing.Point(907, 273)
        Me.btnDirectorioArchivos.Name = "btnDirectorioArchivos"
        Me.btnDirectorioArchivos.Size = New System.Drawing.Size(23, 21)
        Me.btnDirectorioArchivos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnDirectorioArchivos.TabIndex = 13
        Me.btnDirectorioArchivos.Text = "..."
        '
        'txtDirectorioArchivos
        '
        Me.txtDirectorioArchivos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtDirectorioArchivos.Border.Class = "TextBoxBorder"
        Me.txtDirectorioArchivos.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDirectorioArchivos.ButtonCustom.Tooltip = ""
        Me.txtDirectorioArchivos.ButtonCustom2.Tooltip = ""
        Me.txtDirectorioArchivos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDirectorioArchivos.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDirectorioArchivos.Location = New System.Drawing.Point(253, 273)
        Me.txtDirectorioArchivos.Name = "txtDirectorioArchivos"
        Me.txtDirectorioArchivos.Size = New System.Drawing.Size(652, 21)
        Me.txtDirectorioArchivos.TabIndex = 12
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Window
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 246)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(226, 15)
        Me.Label7.TabIndex = 105
        Me.Label7.Text = "Ubicación programa de comercio digital"
        '
        'btnDirectorioCD
        '
        Me.btnDirectorioCD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDirectorioCD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnDirectorioCD.Location = New System.Drawing.Point(907, 244)
        Me.btnDirectorioCD.Name = "btnDirectorioCD"
        Me.btnDirectorioCD.Size = New System.Drawing.Size(23, 21)
        Me.btnDirectorioCD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnDirectorioCD.TabIndex = 11
        Me.btnDirectorioCD.Text = "..."
        '
        'txtDirectorioCD
        '
        Me.txtDirectorioCD.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtDirectorioCD.Border.Class = "TextBoxBorder"
        Me.txtDirectorioCD.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDirectorioCD.ButtonCustom.Tooltip = ""
        Me.txtDirectorioCD.ButtonCustom2.Tooltip = ""
        Me.txtDirectorioCD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDirectorioCD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtDirectorioCD.Location = New System.Drawing.Point(253, 244)
        Me.txtDirectorioCD.Name = "txtDirectorioCD"
        Me.txtDirectorioCD.Size = New System.Drawing.Size(652, 21)
        Me.txtDirectorioCD.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 217)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 15)
        Me.Label6.TabIndex = 102
        Me.Label6.Text = "Contraseña WEB"
        '
        'txtClaveWeb
        '
        Me.txtClaveWeb.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtClaveWeb.Border.Class = "TextBoxBorder"
        Me.txtClaveWeb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtClaveWeb.ButtonCustom.Tooltip = ""
        Me.txtClaveWeb.ButtonCustom2.Tooltip = ""
        Me.txtClaveWeb.Enabled = False
        Me.txtClaveWeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaveWeb.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtClaveWeb.Location = New System.Drawing.Point(122, 215)
        Me.txtClaveWeb.Name = "txtClaveWeb"
        Me.txtClaveWeb.Size = New System.Drawing.Size(133, 21)
        Me.txtClaveWeb.TabIndex = 9
        Me.txtClaveWeb.UseSystemPasswordChar = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 188)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 15)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "Usuario WEB"
        '
        'txtUsuarioWeb
        '
        Me.txtUsuarioWeb.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtUsuarioWeb.Border.Class = "TextBoxBorder"
        Me.txtUsuarioWeb.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtUsuarioWeb.ButtonCustom.Tooltip = ""
        Me.txtUsuarioWeb.ButtonCustom2.Tooltip = ""
        Me.txtUsuarioWeb.Enabled = False
        Me.txtUsuarioWeb.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuarioWeb.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtUsuarioWeb.Location = New System.Drawing.Point(122, 186)
        Me.txtUsuarioWeb.Name = "txtUsuarioWeb"
        Me.txtUsuarioWeb.Size = New System.Drawing.Size(133, 21)
        Me.txtUsuarioWeb.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 159)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 15)
        Me.Label4.TabIndex = 98
        Me.Label4.Text = "Contraseña .KEY"
        '
        'txtClaveKEY
        '
        Me.txtClaveKEY.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtClaveKEY.Border.Class = "TextBoxBorder"
        Me.txtClaveKEY.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtClaveKEY.ButtonCustom.Tooltip = ""
        Me.txtClaveKEY.ButtonCustom2.Tooltip = ""
        Me.txtClaveKEY.Enabled = False
        Me.txtClaveKEY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClaveKEY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtClaveKEY.Location = New System.Drawing.Point(122, 157)
        Me.txtClaveKEY.Name = "txtClaveKEY"
        Me.txtClaveKEY.Size = New System.Drawing.Size(133, 21)
        Me.txtClaveKEY.TabIndex = 7
        Me.txtClaveKEY.UseSystemPasswordChar = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 15)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "Archivo .CER"
        '
        'btnArchivoCER
        '
        Me.btnArchivoCER.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnArchivoCER.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnArchivoCER.Location = New System.Drawing.Point(907, 128)
        Me.btnArchivoCER.Name = "btnArchivoCER"
        Me.btnArchivoCER.Size = New System.Drawing.Size(23, 21)
        Me.btnArchivoCER.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnArchivoCER.TabIndex = 6
        Me.btnArchivoCER.Text = "..."
        '
        'txtArchivoCER
        '
        Me.txtArchivoCER.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtArchivoCER.Border.Class = "TextBoxBorder"
        Me.txtArchivoCER.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtArchivoCER.ButtonCustom.Tooltip = ""
        Me.txtArchivoCER.ButtonCustom2.Tooltip = ""
        Me.txtArchivoCER.Enabled = False
        Me.txtArchivoCER.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivoCER.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtArchivoCER.Location = New System.Drawing.Point(122, 128)
        Me.txtArchivoCER.Name = "txtArchivoCER"
        Me.txtArchivoCER.Size = New System.Drawing.Size(783, 21)
        Me.txtArchivoCER.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 15)
        Me.Label1.TabIndex = 93
        Me.Label1.Text = "Archivo .KEY"
        '
        'btnArchivoKEY
        '
        Me.btnArchivoKEY.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnArchivoKEY.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnArchivoKEY.Location = New System.Drawing.Point(907, 99)
        Me.btnArchivoKEY.Name = "btnArchivoKEY"
        Me.btnArchivoKEY.Size = New System.Drawing.Size(23, 21)
        Me.btnArchivoKEY.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnArchivoKEY.TabIndex = 4
        Me.btnArchivoKEY.Text = "..."
        '
        'txtArchivoKEY
        '
        Me.txtArchivoKEY.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtArchivoKEY.Border.Class = "TextBoxBorder"
        Me.txtArchivoKEY.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtArchivoKEY.ButtonCustom.Tooltip = ""
        Me.txtArchivoKEY.ButtonCustom2.Tooltip = ""
        Me.txtArchivoKEY.Enabled = False
        Me.txtArchivoKEY.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivoKEY.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtArchivoKEY.Location = New System.Drawing.Point(122, 99)
        Me.txtArchivoKEY.Name = "txtArchivoKEY"
        Me.txtArchivoKEY.Size = New System.Drawing.Size(783, 21)
        Me.txtArchivoKEY.TabIndex = 3
        '
        'btnPrueba
        '
        '
        '
        '
        Me.btnPrueba.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnPrueba.Location = New System.Drawing.Point(122, 70)
        Me.btnPrueba.Name = "btnPrueba"
        Me.btnPrueba.OffText = "NO"
        Me.btnPrueba.OnText = "SI"
        Me.btnPrueba.Size = New System.Drawing.Size(133, 23)
        Me.btnPrueba.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrueba.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 15)
        Me.Label2.TabIndex = 89
        Me.Label2.Text = "Info. de prueba"
        '
        'cmbAnoPeriodo
        '
        Me.cmbAnoPeriodo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbAnoPeriodo.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbAnoPeriodo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbAnoPeriodo.ButtonClear.Tooltip = ""
        Me.cmbAnoPeriodo.ButtonCustom.Tooltip = ""
        Me.cmbAnoPeriodo.ButtonCustom2.Tooltip = ""
        Me.cmbAnoPeriodo.ButtonDropDown.Tooltip = ""
        Me.cmbAnoPeriodo.ButtonDropDown.Visible = True
        Me.cmbAnoPeriodo.Columns.Add(Me.ColumnHeader3)
        Me.cmbAnoPeriodo.Columns.Add(Me.ColumnHeader4)
        Me.cmbAnoPeriodo.Columns.Add(Me.ColumnHeader5)
        Me.cmbAnoPeriodo.Columns.Add(Me.ColumnHeader6)
        Me.cmbAnoPeriodo.Columns.Add(Me.ColumnHeader7)
        Me.cmbAnoPeriodo.DropDownHeight = 180
        Me.cmbAnoPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAnoPeriodo.FormatString = "d"
        Me.cmbAnoPeriodo.FormattingEnabled = True
        Me.cmbAnoPeriodo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbAnoPeriodo.Location = New System.Drawing.Point(122, 12)
        Me.cmbAnoPeriodo.Name = "cmbAnoPeriodo"
        Me.cmbAnoPeriodo.Size = New System.Drawing.Size(808, 23)
        Me.cmbAnoPeriodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbAnoPeriodo.TabIndex = 0
        Me.cmbAnoPeriodo.ValueMember = "unico"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DataFieldName = "unico"
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "UNICO"
        Me.ColumnHeader3.Visible = False
        Me.ColumnHeader3.Width.Absolute = 150
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DataFieldName = "ano"
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "AÑO"
        Me.ColumnHeader4.Width.Relative = 20
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DataFieldName = "periodo"
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.Text = "PERIODO"
        Me.ColumnHeader5.Width.Relative = 30
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.DataFieldName = "fecha_ini"
        Me.ColumnHeader6.Name = "ColumnHeader6"
        Me.ColumnHeader6.Text = "FECHA INICIO"
        Me.ColumnHeader6.Width.Relative = 30
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.DataFieldName = "fecha_fin"
        Me.ColumnHeader7.Name = "ColumnHeader7"
        Me.ColumnHeader7.Text = "FECHA FIN"
        Me.ColumnHeader7.Width.Relative = 30
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Window
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(12, 12)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 15)
        Me.Label12.TabIndex = 80
        Me.Label12.Text = "Año/periodo"
        '
        'gpControles
        '
        Me.gpControles.Controls.Add(Me.btnExportar)
        Me.gpControles.Controls.Add(Me.btnCancelar)
        Me.gpControles.Location = New System.Drawing.Point(742, 445)
        Me.gpControles.Name = "gpControles"
        Me.gpControles.Size = New System.Drawing.Size(212, 50)
        Me.gpControles.TabIndex = 1
        Me.gpControles.TabStop = False
        '
        'btnExportar
        '
        Me.btnExportar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnExportar.CausesValidation = False
        Me.btnExportar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Image = Global.PIDA.My.Resources.Resources.Export24
        Me.btnExportar.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnExportar.ImageTextSpacing = 5
        Me.btnExportar.Location = New System.Drawing.Point(9, 14)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(94, 28)
        Me.btnExportar.TabIndex = 0
        Me.btnExportar.Text = "&Exportar"
        Me.btnExportar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelar.ImageTextSpacing = 5
        Me.btnCancelar.Location = New System.Drawing.Point(110, 14)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(94, 28)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "&Cerrar"
        Me.btnCancelar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.qr_code32
        Me.picImagen.Location = New System.Drawing.Point(12, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(31, 30)
        Me.picImagen.TabIndex = 114
        Me.picImagen.TabStop = False
        '
        'dlgArchivo
        '
        Me.dlgArchivo.FileName = "OpenFileDialog1"
        '
        'bgTimbrado
        '
        Me.bgTimbrado.WorkerReportsProgress = True
        Me.bgTimbrado.WorkerSupportsCancellation = True
        '
        'tmrTranscurre
        '
        '
        'frmRecibosCFDI
        '
        Me.AcceptButton = Me.btnExportar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(964, 503)
        Me.Controls.Add(Me.gpControles)
        Me.Controls.Add(Me.gpParametros)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.picImagen)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRecibosCFDI"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Recibos CFDI"
        Me.gpParametros.ResumeLayout(False)
        Me.gpParametros.PerformLayout()
        Me.gpAvance.ResumeLayout(False)
        Me.gpControles.ResumeLayout(False)
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Private WithEvents gpParametros As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmbAnoPeriodo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnPrueba As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnArchivoKEY As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtArchivoKEY As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnDirectorioArchivos As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtDirectorioArchivos As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnDirectorioCD As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtDirectorioCD As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtClaveWeb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtUsuarioWeb As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtClaveKEY As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnArchivoCER As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtArchivoCER As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents gpControles As System.Windows.Forms.GroupBox
    Friend WithEvents btnExportar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dlgArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmbCia As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents txtRiesgo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtBanco As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader6 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader7 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents gpAvance As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents pbAvance As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents bgTimbrado As System.ComponentModel.BackgroundWorker
    Friend WithEvents PreguntaArchivo As System.Windows.Forms.SaveFileDialog
    Friend WithEvents tmrTranscurre As System.Windows.Forms.Timer
    Friend WithEvents lblAvance As System.Windows.Forms.Label
    Friend WithEvents lblTiempo As System.Windows.Forms.Label
End Class
