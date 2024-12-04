<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportaciondatos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportaciondatos))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.dlgArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.btnSalir = New DevComponents.DotNetBar.ButtonX()
        Me.btnActualizar = New DevComponents.DotNetBar.ButtonX()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRecib = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnNomina = New DevComponents.DotNetBar.ButtonX()
        Me.btnGenerales = New DevComponents.DotNetBar.ButtonX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtGenerales = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.btnPensiones = New DevComponents.DotNetBar.ButtonX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPensiones = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbCia = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.cmbPeriodos = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.gpAvance = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.cpActualizacion = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.lblReloj = New System.Windows.Forms.Label()
        Me.cmbTipoPeriodo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColTipoPeriodo = New DevComponents.AdvTree.ColumnHeader()
        Me.ColTipoPeriodoNombre = New DevComponents.AdvTree.ColumnHeader()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader6 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader7 = New DevComponents.AdvTree.ColumnHeader()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.gpAvance.SuspendLayout()
        Me.SuspendLayout()
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
        Me.ReflectionLabel1.Size = New System.Drawing.Size(419, 28)
        Me.ReflectionLabel1.TabIndex = 93
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>IMPORTACIÓN DE DATOS DE NÓMINA</b></font>"
        '
        'dlgArchivo
        '
        Me.dlgArchivo.FileName = "OpenFileDialog1"
        '
        'btnSalir
        '
        Me.btnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSalir.CausesValidation = False
        Me.btnSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.PIDA.My.Resources.Resources.Cerrar32
        Me.btnSalir.ImageTextSpacing = 5
        Me.btnSalir.Location = New System.Drawing.Point(313, 252)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(120, 45)
        Me.btnSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSalir.TabIndex = 6
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'btnActualizar
        '
        Me.btnActualizar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnActualizar.CausesValidation = False
        Me.btnActualizar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizar.Image = Global.PIDA.My.Resources.Resources.Inbox32
        Me.btnActualizar.ImageTextSpacing = 5
        Me.btnActualizar.Location = New System.Drawing.Point(61, 252)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(120, 45)
        Me.btnActualizar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnActualizar.TabIndex = 4
        Me.btnActualizar.Text = "Importar datos"
        Me.btnActualizar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.ActualizaNomina32
        Me.picImagen.Location = New System.Drawing.Point(12, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(27, 35)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picImagen.TabIndex = 94
        Me.picImagen.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "Periodo"
        '
        'BtnBorrar
        '
        Me.BtnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BtnBorrar.CausesValidation = False
        Me.BtnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.BtnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBorrar.Image = Global.PIDA.My.Resources.Resources.BorrarNomina32
        Me.BtnBorrar.ImageTextSpacing = 5
        Me.BtnBorrar.Location = New System.Drawing.Point(187, 252)
        Me.BtnBorrar.Name = "BtnBorrar"
        Me.BtnBorrar.Size = New System.Drawing.Size(120, 45)
        Me.BtnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BtnBorrar.TabIndex = 5
        Me.BtnBorrar.Text = "Borrar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "nómina"
        Me.BtnBorrar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 15)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "Carga de nómina"
        '
        'txtRecib
        '
        '
        '
        '
        Me.txtRecib.Border.Class = "TextBoxBorder"
        Me.txtRecib.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRecib.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecib.Location = New System.Drawing.Point(126, 7)
        Me.txtRecib.MaxLength = 80
        Me.txtRecib.Name = "txtRecib"
        Me.txtRecib.Size = New System.Drawing.Size(283, 21)
        Me.txtRecib.TabIndex = 0
        '
        'btnNomina
        '
        Me.btnNomina.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNomina.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNomina.Location = New System.Drawing.Point(411, 7)
        Me.btnNomina.Name = "btnNomina"
        Me.btnNomina.Size = New System.Drawing.Size(21, 21)
        Me.btnNomina.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNomina.TabIndex = 3
        Me.btnNomina.Text = "..."
        '
        'btnGenerales
        '
        Me.btnGenerales.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGenerales.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGenerales.Location = New System.Drawing.Point(411, 37)
        Me.btnGenerales.Name = "btnGenerales"
        Me.btnGenerales.Size = New System.Drawing.Size(21, 21)
        Me.btnGenerales.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGenerales.TabIndex = 4
        Me.btnGenerales.Text = "..."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 15)
        Me.Label3.TabIndex = 108
        Me.Label3.Text = "Datos generales"
        '
        'txtGenerales
        '
        '
        '
        '
        Me.txtGenerales.Border.Class = "TextBoxBorder"
        Me.txtGenerales.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtGenerales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGenerales.Location = New System.Drawing.Point(126, 37)
        Me.txtGenerales.MaxLength = 80
        Me.txtGenerales.Name = "txtGenerales"
        Me.txtGenerales.Size = New System.Drawing.Size(283, 21)
        Me.txtGenerales.TabIndex = 1
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel1.Controls.Add(Me.Line1)
        Me.GroupPanel1.Controls.Add(Me.btnPensiones)
        Me.GroupPanel1.Controls.Add(Me.Label4)
        Me.GroupPanel1.Controls.Add(Me.txtPensiones)
        Me.GroupPanel1.Controls.Add(Me.btnGenerales)
        Me.GroupPanel1.Controls.Add(Me.Label3)
        Me.GroupPanel1.Controls.Add(Me.txtGenerales)
        Me.GroupPanel1.Controls.Add(Me.btnNomina)
        Me.GroupPanel1.Controls.Add(Me.Label2)
        Me.GroupPanel1.Controls.Add(Me.txtRecib)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(20, 125)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(439, 118)
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
        Me.GroupPanel1.TabIndex = 3
        Me.GroupPanel1.Text = "Ubicación de archivos"
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.Transparent
        Me.Line1.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Line1.Location = New System.Drawing.Point(13, 58)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(419, 19)
        Me.Line1.TabIndex = 112
        Me.Line1.Text = "Line1"
        '
        'btnPensiones
        '
        Me.btnPensiones.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPensiones.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPensiones.Location = New System.Drawing.Point(411, 77)
        Me.btnPensiones.Name = "btnPensiones"
        Me.btnPensiones.Size = New System.Drawing.Size(21, 21)
        Me.btnPensiones.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPensiones.TabIndex = 110
        Me.btnPensiones.Text = "..."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 15)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "Detalle pensiones"
        '
        'txtPensiones
        '
        '
        '
        '
        Me.txtPensiones.Border.Class = "TextBoxBorder"
        Me.txtPensiones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPensiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPensiones.Location = New System.Drawing.Point(126, 77)
        Me.txtPensiones.MaxLength = 80
        Me.txtPensiones.Name = "txtPensiones"
        Me.txtPensiones.Size = New System.Drawing.Size(283, 21)
        Me.txtPensiones.TabIndex = 109
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 104
        Me.Label5.Text = "Compañía"
        '
        'cmbCia
        '
        Me.cmbCia.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbCia.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbCia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbCia.ButtonDropDown.Visible = True
        Me.cmbCia.Columns.Add(Me.ColumnHeader1)
        Me.cmbCia.Columns.Add(Me.ColumnHeader2)
        Me.cmbCia.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbCia.Location = New System.Drawing.Point(120, 96)
        Me.cmbCia.Name = "cmbCia"
        Me.cmbCia.Size = New System.Drawing.Size(339, 23)
        Me.cmbCia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbCia.TabIndex = 2
        Me.cmbCia.ValueMember = "cod_comp"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "cod_comp"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Código"
        Me.ColumnHeader1.Width.Relative = 20
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "nombre"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Nombre"
        Me.ColumnHeader2.Width.Relative = 80
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
        Me.cmbPeriodos.Columns.Add(Me.ColumnHeader3)
        Me.cmbPeriodos.Columns.Add(Me.ColumnHeader4)
        Me.cmbPeriodos.Columns.Add(Me.ColumnHeader5)
        Me.cmbPeriodos.Columns.Add(Me.ColumnHeader6)
        Me.cmbPeriodos.Columns.Add(Me.ColumnHeader7)
        Me.cmbPeriodos.DisplayMembers = "seleccionado,ano,periodo,fecha_ini,fecha_fin"
        Me.cmbPeriodos.FormatString = "d"
        Me.cmbPeriodos.FormattingEnabled = True
        Me.cmbPeriodos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPeriodos.Location = New System.Drawing.Point(120, 71)
        Me.cmbPeriodos.Name = "cmbPeriodos"
        Me.cmbPeriodos.Size = New System.Drawing.Size(339, 23)
        Me.cmbPeriodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPeriodos.TabIndex = 105
        Me.cmbPeriodos.ValueMember = "seleccionado"
        '
        'gpAvance
        '
        Me.gpAvance.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpAvance.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpAvance.Controls.Add(Me.cpActualizacion)
        Me.gpAvance.Controls.Add(Me.lblReloj)
        Me.gpAvance.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpAvance.Location = New System.Drawing.Point(131, 40)
        Me.gpAvance.Name = "gpAvance"
        Me.gpAvance.Size = New System.Drawing.Size(220, 218)
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
        'cpActualizacion
        '
        Me.cpActualizacion.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        '
        '
        '
        Me.cpActualizacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cpActualizacion.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.cpActualizacion.BackgroundStyle.TextColor = System.Drawing.SystemColors.WindowText
        Me.cpActualizacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cpActualizacion.Location = New System.Drawing.Point(0, 0)
        Me.cpActualizacion.Maximum = 20
        Me.cpActualizacion.Name = "cpActualizacion"
        Me.cpActualizacion.ProgressColor = System.Drawing.SystemColors.HotTrack
        Me.cpActualizacion.ProgressTextVisible = True
        Me.cpActualizacion.Size = New System.Drawing.Size(218, 170)
        Me.cpActualizacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cpActualizacion.TabIndex = 274
        '
        'lblReloj
        '
        Me.lblReloj.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblReloj.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReloj.Location = New System.Drawing.Point(0, 170)
        Me.lblReloj.Name = "lblReloj"
        Me.lblReloj.Size = New System.Drawing.Size(218, 45)
        Me.lblReloj.TabIndex = 273
        Me.lblReloj.Text = "Reloj"
        Me.lblReloj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbTipoPeriodo
        '
        Me.cmbTipoPeriodo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbTipoPeriodo.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbTipoPeriodo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbTipoPeriodo.ButtonDropDown.Visible = True
        Me.cmbTipoPeriodo.Columns.Add(Me.ColTipoPeriodo)
        Me.cmbTipoPeriodo.Columns.Add(Me.ColTipoPeriodoNombre)
        Me.cmbTipoPeriodo.DisplayMembers = "tipo_periodo,nombre"
        Me.cmbTipoPeriodo.FormatString = "d"
        Me.cmbTipoPeriodo.FormattingEnabled = True
        Me.cmbTipoPeriodo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbTipoPeriodo.Location = New System.Drawing.Point(120, 46)
        Me.cmbTipoPeriodo.Name = "cmbTipoPeriodo"
        Me.cmbTipoPeriodo.Size = New System.Drawing.Size(339, 23)
        Me.cmbTipoPeriodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipoPeriodo.TabIndex = 276
        Me.cmbTipoPeriodo.ValueMember = "tipo_periodo"
        '
        'ColTipoPeriodo
        '
        Me.ColTipoPeriodo.DataFieldName = "tipo_periodo"
        Me.ColTipoPeriodo.Name = "ColTipoPeriodo"
        Me.ColTipoPeriodo.Text = "Column"
        Me.ColTipoPeriodo.Width.Absolute = 150
        '
        'ColTipoPeriodoNombre
        '
        Me.ColTipoPeriodoNombre.DataFieldName = "nombre"
        Me.ColTipoPeriodoNombre.Name = "ColTipoPeriodoNombre"
        Me.ColTipoPeriodoNombre.Text = "Column"
        Me.ColTipoPeriodoNombre.Width.Absolute = 150
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(18, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 13)
        Me.Label6.TabIndex = 277
        Me.Label6.Text = "Tipo de periodo"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DataFieldName = "seleccionado"
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Column"
        Me.ColumnHeader3.Width.Absolute = 150
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DataFieldName = "ano"
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "Año"
        Me.ColumnHeader4.Width.Absolute = 150
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DataFieldName = "periodo"
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.Text = "Periodo"
        Me.ColumnHeader5.Width.Absolute = 150
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.DataFieldName = "fecha_ini"
        Me.ColumnHeader6.Name = "ColumnHeader6"
        Me.ColumnHeader6.Text = "Inicio"
        Me.ColumnHeader6.Width.Absolute = 150
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.DataFieldName = "fecha_fin"
        Me.ColumnHeader7.Name = "ColumnHeader7"
        Me.ColumnHeader7.Text = "Fin"
        Me.ColumnHeader7.Width.Absolute = 150
        '
        'frmImportaciondatos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 308)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.gpAvance)
        Me.Controls.Add(Me.cmbPeriodos)
        Me.Controls.Add(Me.cmbCia)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.BtnBorrar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.picImagen)
        Me.Controls.Add(Me.cmbTipoPeriodo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportaciondatos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Importación de datos de nómina"
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.gpAvance.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents btnActualizar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSalir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dlgArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRecib As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnNomina As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnGenerales As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtGenerales As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbCia As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents cmbPeriodos As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents gpAvance As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lblReloj As System.Windows.Forms.Label
    Friend WithEvents cpActualizacion As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents btnPensiones As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPensiones As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmbTipoPeriodo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ColTipoPeriodo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColTipoPeriodoNombre As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader6 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader7 As DevComponents.AdvTree.ColumnHeader
End Class
