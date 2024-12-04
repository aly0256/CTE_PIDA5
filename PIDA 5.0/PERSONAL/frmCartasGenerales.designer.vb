<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCartasGenerales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCartasGenerales))
        Me.txtFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.cmbRemitente = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader()
        Me.nombre = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader7 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtMensaje = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbPredefinidas = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.cmbDestinatario = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.cmbMensaje = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader6 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader8 = New DevComponents.AdvTree.ColumnHeader()
        Me.btnFotografia = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnMensaje = New DevComponents.DotNetBar.ButtonX()
        Me.btnVerRemitente = New DevComponents.DotNetBar.ButtonX()
        Me.btnVerDestinatario = New DevComponents.DotNetBar.ButtonX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnGenerarReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnGuardarCambios = New DevComponents.DotNetBar.ButtonX()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtFecha.ButtonDropDown.Visible = True
        Me.txtFecha.IsPopupCalendarOpen = False
        Me.txtFecha.Location = New System.Drawing.Point(116, 14)
        '
        '
        '
        Me.txtFecha.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFecha.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtFecha.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha.MonthCalendar.DisplayMonth = New Date(2013, 3, 1, 0, 0, 0, 0)
        Me.txtFecha.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFecha.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFecha.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFecha.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFecha.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFecha.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha.MonthCalendar.TodayButtonVisible = True
        Me.txtFecha.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(112, 20)
        Me.txtFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFecha.TabIndex = 1
        '
        'cmbRemitente
        '
        Me.cmbRemitente.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbRemitente.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbRemitente.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbRemitente.ButtonDropDown.Visible = True
        Me.cmbRemitente.Columns.Add(Me.ColumnHeader5)
        Me.cmbRemitente.Columns.Add(Me.nombre)
        Me.cmbRemitente.Columns.Add(Me.ColumnHeader7)
        Me.cmbRemitente.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbRemitente.Location = New System.Drawing.Point(116, 69)
        Me.cmbRemitente.Name = "cmbRemitente"
        Me.cmbRemitente.Size = New System.Drawing.Size(354, 23)
        Me.cmbRemitente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbRemitente.TabIndex = 2
        Me.cmbRemitente.ValueMember = "cod_remitente"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DataFieldName = "cod_remitente"
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.Text = "Código"
        Me.ColumnHeader5.Width.Absolute = 50
        '
        'nombre
        '
        Me.nombre.DataFieldName = "nombre"
        Me.nombre.Name = "nombre"
        Me.nombre.StretchToFill = True
        Me.nombre.Text = "Nombre"
        Me.nombre.Width.Absolute = 150
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.DataFieldName = "cod_puesto"
        Me.ColumnHeader7.Name = "ColumnHeader7"
        Me.ColumnHeader7.Text = "Puesto"
        Me.ColumnHeader7.Width.Absolute = 50
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Firma"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Destinatario"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 130)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Mensaje"
        '
        'txtMensaje
        '
        Me.txtMensaje.AcceptsReturn = True
        '
        '
        '
        Me.txtMensaje.Border.Class = "TextBoxBorder"
        Me.txtMensaje.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMensaje.Location = New System.Drawing.Point(10, 156)
        Me.txtMensaje.Multiline = True
        Me.txtMensaje.Name = "txtMensaje"
        Me.txtMensaje.Size = New System.Drawing.Size(487, 148)
        Me.txtMensaje.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Incluir fotografía"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(19, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Tipo de formato"
        '
        'cmbPredefinidas
        '
        Me.cmbPredefinidas.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPredefinidas.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPredefinidas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPredefinidas.ButtonDropDown.Visible = True
        Me.cmbPredefinidas.Columns.Add(Me.ColumnHeader1)
        Me.cmbPredefinidas.Columns.Add(Me.ColumnHeader2)
        Me.cmbPredefinidas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPredefinidas.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPredefinidas.Location = New System.Drawing.Point(128, 56)
        Me.cmbPredefinidas.Name = "cmbPredefinidas"
        Me.cmbPredefinidas.Size = New System.Drawing.Size(381, 23)
        Me.cmbPredefinidas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPredefinidas.TabIndex = 11
        Me.cmbPredefinidas.ValueMember = "cod_carta"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.ColumnName = "cod_carta"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Código"
        Me.ColumnHeader1.Width.Absolute = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.ColumnName = "nombre"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.StretchToFill = True
        Me.ColumnHeader2.Text = "Nombre"
        Me.ColumnHeader2.Width.Absolute = 150
        '
        'cmbDestinatario
        '
        Me.cmbDestinatario.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbDestinatario.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbDestinatario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbDestinatario.ButtonDropDown.Visible = True
        Me.cmbDestinatario.Columns.Add(Me.ColumnHeader3)
        Me.cmbDestinatario.Columns.Add(Me.ColumnHeader4)
        Me.cmbDestinatario.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbDestinatario.Location = New System.Drawing.Point(116, 40)
        Me.cmbDestinatario.Name = "cmbDestinatario"
        Me.cmbDestinatario.Size = New System.Drawing.Size(354, 23)
        Me.cmbDestinatario.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbDestinatario.TabIndex = 12
        Me.cmbDestinatario.ValueMember = "cod_destinatario"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DataFieldName = "cod_destinatario"
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Código"
        Me.ColumnHeader3.Width.Absolute = 50
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DataFieldName = "nombre"
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.StretchToFill = True
        Me.ColumnHeader4.Text = "Nombre"
        Me.ColumnHeader4.Width.Absolute = 150
        '
        'cmbMensaje
        '
        Me.cmbMensaje.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbMensaje.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbMensaje.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbMensaje.ButtonDropDown.Visible = True
        Me.cmbMensaje.Columns.Add(Me.ColumnHeader6)
        Me.cmbMensaje.Columns.Add(Me.ColumnHeader8)
        Me.cmbMensaje.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbMensaje.Location = New System.Drawing.Point(116, 127)
        Me.cmbMensaje.Name = "cmbMensaje"
        Me.cmbMensaje.Size = New System.Drawing.Size(354, 23)
        Me.cmbMensaje.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbMensaje.TabIndex = 13
        Me.cmbMensaje.ValueMember = "cod_mensaje"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.DataFieldName = "cod_mensaje"
        Me.ColumnHeader6.Name = "ColumnHeader6"
        Me.ColumnHeader6.Text = "Código"
        Me.ColumnHeader6.Width.Absolute = 50
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.DataFieldName = "nombre"
        Me.ColumnHeader8.Name = "ColumnHeader8"
        Me.ColumnHeader8.StretchToFill = True
        Me.ColumnHeader8.Text = "Nombre"
        Me.ColumnHeader8.Width.Absolute = 150
        '
        'btnFotografia
        '
        '
        '
        '
        Me.btnFotografia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnFotografia.Location = New System.Drawing.Point(116, 98)
        Me.btnFotografia.Name = "btnFotografia"
        Me.btnFotografia.OffBackColor = System.Drawing.SystemColors.Window
        Me.btnFotografia.OffText = "NO"
        Me.btnFotografia.OnText = "SI"
        Me.btnFotografia.Size = New System.Drawing.Size(112, 23)
        Me.btnFotografia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnFotografia.SwitchBackColor = System.Drawing.SystemColors.HotTrack
        Me.btnFotografia.SwitchBorderColor = System.Drawing.SystemColors.HotTrack
        Me.btnFotografia.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnMensaje)
        Me.GroupBox1.Controls.Add(Me.btnVerRemitente)
        Me.GroupBox1.Controls.Add(Me.btnVerDestinatario)
        Me.GroupBox1.Controls.Add(Me.cmbMensaje)
        Me.GroupBox1.Controls.Add(Me.cmbDestinatario)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnFotografia)
        Me.GroupBox1.Controls.Add(Me.txtMensaje)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbRemitente)
        Me.GroupBox1.Controls.Add(Me.txtFecha)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 80)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(504, 312)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        '
        'btnMensaje
        '
        Me.btnMensaje.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnMensaje.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnMensaje.Location = New System.Drawing.Point(475, 127)
        Me.btnMensaje.Name = "btnMensaje"
        Me.btnMensaje.Size = New System.Drawing.Size(22, 23)
        Me.btnMensaje.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnMensaje.TabIndex = 24
        Me.btnMensaje.Text = "..."
        '
        'btnVerRemitente
        '
        Me.btnVerRemitente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnVerRemitente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnVerRemitente.Location = New System.Drawing.Point(476, 69)
        Me.btnVerRemitente.Name = "btnVerRemitente"
        Me.btnVerRemitente.Size = New System.Drawing.Size(22, 23)
        Me.btnVerRemitente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnVerRemitente.TabIndex = 23
        Me.btnVerRemitente.Text = "..."
        '
        'btnVerDestinatario
        '
        Me.btnVerDestinatario.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnVerDestinatario.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnVerDestinatario.Location = New System.Drawing.Point(476, 40)
        Me.btnVerDestinatario.Name = "btnVerDestinatario"
        Me.btnVerDestinatario.Size = New System.Drawing.Size(22, 23)
        Me.btnVerDestinatario.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnVerDestinatario.TabIndex = 22
        Me.btnVerDestinatario.Text = "..."
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(52, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(275, 40)
        Me.ReflectionLabel1.TabIndex = 121
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CARTAS GENERALES</b></font>"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Carta32
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(34, 30)
        Me.PictureBox1.TabIndex = 122
        Me.PictureBox1.TabStop = False
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCerrar.Location = New System.Drawing.Point(257, 398)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(80, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 16
        Me.btnCerrar.Text = "&Cancelar"
        '
        'btnGenerarReporte
        '
        Me.btnGenerarReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGenerarReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGenerarReporte.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnGenerarReporte.Location = New System.Drawing.Point(169, 398)
        Me.btnGenerarReporte.Name = "btnGenerarReporte"
        Me.btnGenerarReporte.Size = New System.Drawing.Size(80, 25)
        Me.btnGenerarReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGenerarReporte.TabIndex = 15
        Me.btnGenerarReporte.Text = "&Aceptar"
        '
        'btnGuardarCambios
        '
        Me.btnGuardarCambios.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGuardarCambios.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGuardarCambios.Image = Global.PIDA.My.Resources.Resources.Save16
        Me.btnGuardarCambios.Location = New System.Drawing.Point(35, 398)
        Me.btnGuardarCambios.Name = "btnGuardarCambios"
        Me.btnGuardarCambios.Size = New System.Drawing.Size(80, 25)
        Me.btnGuardarCambios.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGuardarCambios.TabIndex = 14
        Me.btnGuardarCambios.Text = "&Guardar"
        Me.btnGuardarCambios.Visible = False
        '
        'frmCartasGenerales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 430)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnGenerarReporte)
        Me.Controls.Add(Me.btnGuardarCambios)
        Me.Controls.Add(Me.cmbPredefinidas)
        Me.Controls.Add(Me.Label6)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCartasGenerales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cartas generales"
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents cmbRemitente As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMensaje As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbPredefinidas As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cmbDestinatario As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cmbMensaje As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents nombre As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader7 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader6 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader8 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents btnGuardarCambios As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnGenerarReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnFotografia As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents btnVerRemitente As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnVerDestinatario As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnMensaje As DevComponents.DotNetBar.ButtonX
End Class
