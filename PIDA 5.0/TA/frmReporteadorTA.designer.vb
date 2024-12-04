<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteadorTA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteadorTA))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnOrden = New DevComponents.DotNetBar.ButtonX()
        Me.sbReloj = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.chkTodos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkOtrosFiltros = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtBajas = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.txtActivos = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBajar = New DevComponents.DotNetBar.ButtonX()
        Me.btnSubir = New DevComponents.DotNetBar.ButtonX()
        Me.lstOrden = New System.Windows.Forms.ListBox()
        Me.btnSeleccionarFiltros = New DevComponents.DotNetBar.ButtonX()
        Me.gpFiltrosVigentes = New System.Windows.Forms.GroupBox()
        Me.lstFiltros = New System.Windows.Forms.ListBox()
        Me.chkOtroOrden = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkNombre = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkReloj = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.gpControles = New System.Windows.Forms.GroupBox()
        Me.pnlCentrarControles = New System.Windows.Forms.Panel()
        Me.btnGenerar = New DevComponents.DotNetBar.ButtonX()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.sbNombre = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.chkBajas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkActivos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.gpFiltros = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.chkRecientes = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.USERNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FILTRAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FRECUENCIA = New DevComponents.DotNetBar.Controls.DataGridViewProgressBarXColumn()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgReportes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.gpOrden = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.gpReportes = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.pnlFiltroReporte = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBusca = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipoReportes = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.gpAvance = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.lblAvance = New System.Windows.Forms.Label()
        Me.pbAvance = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.lblRango = New System.Windows.Forms.Label()
        Me.lblFechas = New System.Windows.Forms.Label()
        Me.pnlRango = New System.Windows.Forms.Panel()
        Me.bgwReporte = New System.ComponentModel.BackgroundWorker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.splReportes = New System.Windows.Forms.SplitContainer()
        Me.pnlseparador = New System.Windows.Forms.Panel()
        CType(Me.txtBajas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtActivos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gpFiltrosVigentes.SuspendLayout()
        Me.gpControles.SuspendLayout()
        Me.pnlCentrarControles.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpFiltros.SuspendLayout()
        CType(Me.dgReportes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpOrden.SuspendLayout()
        Me.gpReportes.SuspendLayout()
        Me.pnlFiltroReporte.SuspendLayout()
        Me.gpAvance.SuspendLayout()
        Me.pnlRango.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.splReportes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splReportes.Panel1.SuspendLayout()
        Me.splReportes.Panel2.SuspendLayout()
        Me.splReportes.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnOrden
        '
        Me.btnOrden.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnOrden.CausesValidation = False
        Me.btnOrden.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnOrden.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOrden.Image = My.Resources.Resources.Sort16
        Me.btnOrden.Location = New System.Drawing.Point(118, 48)
        Me.btnOrden.Name = "btnOrden"
        Me.btnOrden.Size = New System.Drawing.Size(97, 23)
        Me.btnOrden.TabIndex = 48
        Me.btnOrden.Text = "Seleccionar"
        Me.btnOrden.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'sbReloj
        '
        '
        '
        '
        Me.sbReloj.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sbReloj.Location = New System.Drawing.Point(118, 0)
        Me.sbReloj.Name = "sbReloj"
        Me.sbReloj.OffBackColor = System.Drawing.Color.PowderBlue
        Me.sbReloj.OffText = "Descendente"
        Me.sbReloj.OffTextColor = System.Drawing.Color.Black
        Me.sbReloj.OnBackColor = System.Drawing.Color.Honeydew
        Me.sbReloj.OnText = "Ascendente"
        Me.sbReloj.OnTextColor = System.Drawing.Color.Black
        Me.sbReloj.Size = New System.Drawing.Size(97, 21)
        Me.sbReloj.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sbReloj.SwitchBackColor = System.Drawing.Color.RoyalBlue
        Me.sbReloj.SwitchFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sbReloj.SwitchWidth = 25
        Me.sbReloj.TabIndex = 43
        Me.sbReloj.Value = True
        Me.sbReloj.ValueObject = "Y"
        '
        'chkTodos
        '
        Me.chkTodos.AutoSize = True
        Me.chkTodos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkTodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkTodos.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkTodos.Checked = True
        Me.chkTodos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodos.CheckValue = "Y"
        Me.chkTodos.Location = New System.Drawing.Point(3, 71)
        Me.chkTodos.Name = "chkTodos"
        Me.chkTodos.Size = New System.Drawing.Size(199, 15)
        Me.chkTodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkTodos.TabIndex = 44
        Me.chkTodos.Text = "Todos los empleados (limpiar filtros)"
        Me.chkTodos.TextColor = System.Drawing.SystemColors.ControlText
        '
        'chkOtrosFiltros
        '
        Me.chkOtrosFiltros.AutoSize = True
        Me.chkOtrosFiltros.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkOtrosFiltros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkOtrosFiltros.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkOtrosFiltros.Location = New System.Drawing.Point(3, 48)
        Me.chkOtrosFiltros.Name = "chkOtrosFiltros"
        Me.chkOtrosFiltros.Size = New System.Drawing.Size(79, 15)
        Me.chkOtrosFiltros.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkOtrosFiltros.TabIndex = 43
        Me.chkOtrosFiltros.Text = "Otros filtros"
        Me.chkOtrosFiltros.TextColor = System.Drawing.SystemColors.ControlText
        '
        'txtBajas
        '
        '
        '
        '
        Me.txtBajas.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtBajas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBajas.ButtonDropDown.Visible = True
        Me.txtBajas.DisabledForeColor = System.Drawing.Color.Black
        Me.txtBajas.FocusHighlightEnabled = True
        Me.txtBajas.IsPopupCalendarOpen = False
        Me.txtBajas.Location = New System.Drawing.Point(100, 23)
        '
        '
        '
        Me.txtBajas.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtBajas.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtBajas.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBajas.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtBajas.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtBajas.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBajas.MonthCalendar.DisplayMonth = New Date(2007, 10, 1, 0, 0, 0, 0)
        Me.txtBajas.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtBajas.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtBajas.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtBajas.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtBajas.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtBajas.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBajas.MonthCalendar.TodayButtonVisible = True
        Me.txtBajas.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtBajas.Name = "txtBajas"
        Me.txtBajas.Size = New System.Drawing.Size(97, 20)
        Me.txtBajas.TabIndex = 3
        '
        'txtActivos
        '
        '
        '
        '
        Me.txtActivos.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtActivos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtActivos.ButtonDropDown.Visible = True
        Me.txtActivos.DisabledForeColor = System.Drawing.Color.Black
        Me.txtActivos.FocusHighlightEnabled = True
        Me.txtActivos.IsPopupCalendarOpen = False
        Me.txtActivos.Location = New System.Drawing.Point(100, 0)
        '
        '
        '
        Me.txtActivos.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtActivos.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtActivos.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtActivos.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtActivos.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtActivos.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtActivos.MonthCalendar.DisplayMonth = New Date(2007, 10, 1, 0, 0, 0, 0)
        Me.txtActivos.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtActivos.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtActivos.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtActivos.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtActivos.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtActivos.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtActivos.MonthCalendar.TodayButtonVisible = True
        Me.txtActivos.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtActivos.Name = "txtActivos"
        Me.txtActivos.Size = New System.Drawing.Size(97, 20)
        Me.txtActivos.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Window
        Me.GroupBox1.Controls.Add(Me.btnBajar)
        Me.GroupBox1.Controls.Add(Me.btnSubir)
        Me.GroupBox1.Controls.Add(Me.lstOrden)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 70)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(327, 81)
        Me.GroupBox1.TabIndex = 46
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Orden seleccionado"
        '
        'btnBajar
        '
        Me.btnBajar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBajar.CausesValidation = False
        Me.btnBajar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBajar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnBajar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBajar.Image = My.Resources.Resources.navigate_down16
        Me.btnBajar.Location = New System.Drawing.Point(301, 55)
        Me.btnBajar.Name = "btnBajar"
        Me.btnBajar.Size = New System.Drawing.Size(20, 20)
        Me.btnBajar.TabIndex = 50
        Me.btnBajar.Tooltip = "Bajar"
        '
        'btnSubir
        '
        Me.btnSubir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSubir.CausesValidation = False
        Me.btnSubir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSubir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSubir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubir.Image = CType(resources.GetObject("btnSubir.Image"), System.Drawing.Image)
        Me.btnSubir.Location = New System.Drawing.Point(301, 19)
        Me.btnSubir.Name = "btnSubir"
        Me.btnSubir.Size = New System.Drawing.Size(20, 20)
        Me.btnSubir.TabIndex = 49
        Me.btnSubir.Tooltip = "Subir"
        '
        'lstOrden
        '
        Me.lstOrden.FormattingEnabled = True
        Me.lstOrden.HorizontalScrollbar = True
        Me.lstOrden.Location = New System.Drawing.Point(7, 19)
        Me.lstOrden.Name = "lstOrden"
        Me.lstOrden.Size = New System.Drawing.Size(290, 56)
        Me.lstOrden.TabIndex = 42
        '
        'btnSeleccionarFiltros
        '
        Me.btnSeleccionarFiltros.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSeleccionarFiltros.CausesValidation = False
        Me.btnSeleccionarFiltros.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSeleccionarFiltros.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSeleccionarFiltros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSeleccionarFiltros.Image = My.Resources.Resources.FiltroHC
        Me.btnSeleccionarFiltros.Location = New System.Drawing.Point(100, 47)
        Me.btnSeleccionarFiltros.Name = "btnSeleccionarFiltros"
        Me.btnSeleccionarFiltros.Size = New System.Drawing.Size(97, 23)
        Me.btnSeleccionarFiltros.TabIndex = 47
        Me.btnSeleccionarFiltros.Text = "Seleccionar"
        Me.btnSeleccionarFiltros.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'gpFiltrosVigentes
        '
        Me.gpFiltrosVigentes.BackColor = System.Drawing.SystemColors.Window
        Me.gpFiltrosVigentes.Controls.Add(Me.lstFiltros)
        Me.gpFiltrosVigentes.Location = New System.Drawing.Point(5, 92)
        Me.gpFiltrosVigentes.Name = "gpFiltrosVigentes"
        Me.gpFiltrosVigentes.Size = New System.Drawing.Size(325, 83)
        Me.gpFiltrosVigentes.TabIndex = 46
        Me.gpFiltrosVigentes.TabStop = False
        Me.gpFiltrosVigentes.Text = "Filtros vigentes"
        '
        'lstFiltros
        '
        Me.lstFiltros.FormattingEnabled = True
        Me.lstFiltros.HorizontalScrollbar = True
        Me.lstFiltros.Location = New System.Drawing.Point(7, 19)
        Me.lstFiltros.Name = "lstFiltros"
        Me.lstFiltros.Size = New System.Drawing.Size(310, 56)
        Me.lstFiltros.TabIndex = 42
        '
        'chkOtroOrden
        '
        Me.chkOtroOrden.AutoSize = True
        Me.chkOtroOrden.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkOtroOrden.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkOtroOrden.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkOtroOrden.Location = New System.Drawing.Point(3, 49)
        Me.chkOtroOrden.Name = "chkOtroOrden"
        Me.chkOtroOrden.Size = New System.Drawing.Size(75, 15)
        Me.chkOtroOrden.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkOtroOrden.TabIndex = 43
        Me.chkOtroOrden.Text = "Otro orden"
        Me.chkOtroOrden.TextColor = System.Drawing.SystemColors.ControlText
        '
        'chkNombre
        '
        Me.chkNombre.AutoSize = True
        Me.chkNombre.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkNombre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkNombre.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkNombre.Location = New System.Drawing.Point(3, 26)
        Me.chkNombre.Name = "chkNombre"
        Me.chkNombre.Size = New System.Drawing.Size(109, 15)
        Me.chkNombre.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkNombre.TabIndex = 1
        Me.chkNombre.Text = "Nombre completo"
        Me.chkNombre.TextColor = System.Drawing.SystemColors.ControlText
        '
        'chkReloj
        '
        Me.chkReloj.AutoSize = True
        Me.chkReloj.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkReloj.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkReloj.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkReloj.Checked = True
        Me.chkReloj.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkReloj.CheckValue = "Y"
        Me.chkReloj.Location = New System.Drawing.Point(3, 3)
        Me.chkReloj.Name = "chkReloj"
        Me.chkReloj.Size = New System.Drawing.Size(48, 15)
        Me.chkReloj.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkReloj.TabIndex = 0
        Me.chkReloj.Text = "Reloj"
        Me.chkReloj.TextColor = System.Drawing.SystemColors.ControlText
        '
        'gpControles
        '
        Me.gpControles.Controls.Add(Me.pnlCentrarControles)
        Me.gpControles.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gpControles.Location = New System.Drawing.Point(0, 475)
        Me.gpControles.Name = "gpControles"
        Me.gpControles.Size = New System.Drawing.Size(1008, 47)
        Me.gpControles.TabIndex = 125
        Me.gpControles.TabStop = False
        '
        'pnlCentrarControles
        '
        Me.pnlCentrarControles.Controls.Add(Me.btnGenerar)
        Me.pnlCentrarControles.Controls.Add(Me.btnBorrar)
        Me.pnlCentrarControles.Controls.Add(Me.btnCancelar)
        Me.pnlCentrarControles.Controls.Add(Me.btnNuevo)
        Me.pnlCentrarControles.Location = New System.Drawing.Point(488, 6)
        Me.pnlCentrarControles.Name = "pnlCentrarControles"
        Me.pnlCentrarControles.Size = New System.Drawing.Size(458, 41)
        Me.pnlCentrarControles.TabIndex = 5
        '
        'btnGenerar
        '
        Me.btnGenerar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGenerar.CausesValidation = False
        Me.btnGenerar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGenerar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Image = My.Resources.Resources.Reporte16
        Me.btnGenerar.Location = New System.Drawing.Point(3, 10)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(106, 25)
        Me.btnGenerar.TabIndex = 0
        Me.btnGenerar.Text = "Generar"
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = My.Resources.Resources.Delete
        Me.btnBorrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBorrar.Location = New System.Drawing.Point(231, 10)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(106, 25)
        Me.btnBorrar.TabIndex = 4
        Me.btnBorrar.Text = "Borrar"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = My.Resources.Resources.Cerrar16
        Me.btnCancelar.Location = New System.Drawing.Point(345, 10)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(106, 25)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cerrar"
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = My.Resources.Resources.Wizard16
        Me.btnNuevo.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnNuevo.Location = New System.Drawing.Point(117, 10)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(106, 25)
        Me.btnNuevo.TabIndex = 3
        Me.btnNuevo.Text = "Crear nuevo"
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
        Me.ReflectionLabel1.Size = New System.Drawing.Size(472, 40)
        Me.ReflectionLabel1.TabIndex = 123
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>REPORTEADOR TIEMPO Y ASISTENCIA</b></font>"
        '
        'sbNombre
        '
        '
        '
        '
        Me.sbNombre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sbNombre.Location = New System.Drawing.Point(118, 24)
        Me.sbNombre.Name = "sbNombre"
        Me.sbNombre.OffBackColor = System.Drawing.Color.PowderBlue
        Me.sbNombre.OffText = "Descendente"
        Me.sbNombre.OffTextColor = System.Drawing.Color.Black
        Me.sbNombre.OnBackColor = System.Drawing.Color.Honeydew
        Me.sbNombre.OnText = "Ascendente"
        Me.sbNombre.OnTextColor = System.Drawing.Color.Black
        Me.sbNombre.Size = New System.Drawing.Size(97, 21)
        Me.sbNombre.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sbNombre.SwitchBackColor = System.Drawing.Color.RoyalBlue
        Me.sbNombre.SwitchFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sbNombre.SwitchWidth = 25
        Me.sbNombre.TabIndex = 47
        Me.sbNombre.Value = True
        Me.sbNombre.ValueObject = "Y"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = My.Resources.Resources.Reporte48
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(27, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 124
        Me.PictureBox1.TabStop = False
        '
        'chkBajas
        '
        Me.chkBajas.AutoSize = True
        Me.chkBajas.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkBajas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkBajas.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkBajas.Location = New System.Drawing.Point(3, 25)
        Me.chkBajas.Name = "chkBajas"
        Me.chkBajas.Size = New System.Drawing.Size(79, 15)
        Me.chkBajas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkBajas.TabIndex = 1
        Me.chkBajas.Text = "Bajas al día"
        Me.chkBajas.TextColor = System.Drawing.SystemColors.ControlText
        '
        'chkActivos
        '
        Me.chkActivos.AutoSize = True
        Me.chkActivos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkActivos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkActivos.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkActivos.Location = New System.Drawing.Point(3, 2)
        Me.chkActivos.Name = "chkActivos"
        Me.chkActivos.Size = New System.Drawing.Size(87, 15)
        Me.chkActivos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkActivos.TabIndex = 0
        Me.chkActivos.Text = "Activos al día"
        Me.chkActivos.TextColor = System.Drawing.SystemColors.ControlText
        '
        'gpFiltros
        '
        Me.gpFiltros.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpFiltros.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpFiltros.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpFiltros.Controls.Add(Me.btnSeleccionarFiltros)
        Me.gpFiltros.Controls.Add(Me.gpFiltrosVigentes)
        Me.gpFiltros.Controls.Add(Me.chkTodos)
        Me.gpFiltros.Controls.Add(Me.chkOtrosFiltros)
        Me.gpFiltros.Controls.Add(Me.txtBajas)
        Me.gpFiltros.Controls.Add(Me.txtActivos)
        Me.gpFiltros.Controls.Add(Me.chkBajas)
        Me.gpFiltros.Controls.Add(Me.chkActivos)
        Me.gpFiltros.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpFiltros.Location = New System.Drawing.Point(0, 0)
        Me.gpFiltros.Name = "gpFiltros"
        Me.gpFiltros.Size = New System.Drawing.Size(344, 209)
        '
        '
        '
        Me.gpFiltros.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpFiltros.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpFiltros.Style.BackColorGradientAngle = 90
        Me.gpFiltros.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpFiltros.Style.BorderBottomWidth = 1
        Me.gpFiltros.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpFiltros.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpFiltros.Style.BorderLeftWidth = 1
        Me.gpFiltros.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpFiltros.Style.BorderRightWidth = 1
        Me.gpFiltros.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpFiltros.Style.BorderTopWidth = 1
        Me.gpFiltros.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpFiltros.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.gpFiltros.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpFiltros.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.gpFiltros.Style.TextShadowColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gpFiltros.Style.TextShadowOffset = New System.Drawing.Point(1, 1)
        '
        '
        '
        Me.gpFiltros.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpFiltros.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpFiltros.TabIndex = 121
        Me.gpFiltros.Text = "Filtros"
        '
        'chkRecientes
        '
        Me.chkRecientes.AutoSize = True
        Me.chkRecientes.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkRecientes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkRecientes.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkRecientes.Checked = True
        Me.chkRecientes.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkRecientes.CheckValue = "Y"
        Me.chkRecientes.Location = New System.Drawing.Point(6, 12)
        Me.chkRecientes.Name = "chkRecientes"
        Me.chkRecientes.Size = New System.Drawing.Size(115, 15)
        Me.chkRecientes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkRecientes.TabIndex = 45
        Me.chkRecientes.Text = "Reportes recientes"
        Me.chkRecientes.TextColor = System.Drawing.SystemColors.ControlText
        '
        'USERNAME
        '
        Me.USERNAME.DataPropertyName = "USERNAME"
        Me.USERNAME.HeaderText = "USERNAME"
        Me.USERNAME.Name = "USERNAME"
        Me.USERNAME.ReadOnly = True
        Me.USERNAME.Visible = False
        '
        'FILTRAR
        '
        Me.FILTRAR.DataPropertyName = "FILTRAR"
        Me.FILTRAR.HeaderText = "FILTRAR"
        Me.FILTRAR.Name = "FILTRAR"
        Me.FILTRAR.ReadOnly = True
        Me.FILTRAR.Visible = False
        '
        'FECHA
        '
        Me.FECHA.DataPropertyName = "FECHA"
        Me.FECHA.HeaderText = "ÚLTIMO ACCESO"
        Me.FECHA.Name = "FECHA"
        Me.FECHA.ReadOnly = True
        Me.FECHA.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'FRECUENCIA
        '
        Me.FRECUENCIA.DataPropertyName = "Frecuencia"
        Me.FRECUENCIA.HeaderText = "FRECUENCIA"
        Me.FRECUENCIA.Name = "FRECUENCIA"
        Me.FRECUENCIA.ReadOnly = True
        Me.FRECUENCIA.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.FRECUENCIA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.FRECUENCIA.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.FRECUENCIA.Text = Nothing
        Me.FRECUENCIA.TextVisible = True
        '
        'Tipo
        '
        Me.Tipo.DataPropertyName = "Tipo"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.NullValue = " "
        Me.Tipo.DefaultCellStyle = DataGridViewCellStyle1
        Me.Tipo.HeaderText = "TIPO"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        '
        'NOMBRE
        '
        Me.NOMBRE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NOMBRE.DataPropertyName = "Nombre"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.NOMBRE.DefaultCellStyle = DataGridViewCellStyle2
        Me.NOMBRE.HeaderText = "REPORTE"
        Me.NOMBRE.Name = "NOMBRE"
        Me.NOMBRE.ReadOnly = True
        '
        'ID
        '
        Me.ID.DataPropertyName = "idReporte"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ID.DefaultCellStyle = DataGridViewCellStyle3
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'dgReportes
        '
        Me.dgReportes.AllowUserToAddRows = False
        Me.dgReportes.AllowUserToDeleteRows = False
        Me.dgReportes.AllowUserToOrderColumns = True
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgReportes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgReportes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgReportes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgReportes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.NOMBRE, Me.Tipo, Me.FRECUENCIA, Me.FECHA, Me.FILTRAR, Me.USERNAME})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgReportes.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgReportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgReportes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgReportes.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.dgReportes.Location = New System.Drawing.Point(0, 61)
        Me.dgReportes.MultiSelect = False
        Me.dgReportes.Name = "dgReportes"
        Me.dgReportes.PaintEnhancedSelection = False
        Me.dgReportes.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgReportes.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgReportes.RowHeadersVisible = False
        Me.dgReportes.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.dgReportes.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgReportes.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgReportes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgReportes.Size = New System.Drawing.Size(650, 321)
        Me.dgReportes.StandardTab = True
        Me.dgReportes.TabIndex = 47
        '
        'gpOrden
        '
        Me.gpOrden.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpOrden.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpOrden.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpOrden.Controls.Add(Me.btnOrden)
        Me.gpOrden.Controls.Add(Me.sbNombre)
        Me.gpOrden.Controls.Add(Me.sbReloj)
        Me.gpOrden.Controls.Add(Me.GroupBox1)
        Me.gpOrden.Controls.Add(Me.chkOtroOrden)
        Me.gpOrden.Controls.Add(Me.chkNombre)
        Me.gpOrden.Controls.Add(Me.chkReloj)
        Me.gpOrden.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpOrden.Dock = System.Windows.Forms.DockStyle.Top
        Me.gpOrden.Location = New System.Drawing.Point(0, 231)
        Me.gpOrden.Name = "gpOrden"
        Me.gpOrden.Size = New System.Drawing.Size(344, 185)
        '
        '
        '
        Me.gpOrden.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpOrden.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpOrden.Style.BackColorGradientAngle = 90
        Me.gpOrden.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpOrden.Style.BorderBottomWidth = 1
        Me.gpOrden.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpOrden.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpOrden.Style.BorderLeftWidth = 1
        Me.gpOrden.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpOrden.Style.BorderRightWidth = 1
        Me.gpOrden.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpOrden.Style.BorderTopWidth = 1
        Me.gpOrden.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpOrden.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold)
        Me.gpOrden.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpOrden.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.gpOrden.Style.TextShadowColor = System.Drawing.Color.FromArgb(CType(CType(169, Byte), Integer), CType(CType(206, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.gpOrden.Style.TextShadowOffset = New System.Drawing.Point(1, 1)
        '
        '
        '
        Me.gpOrden.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpOrden.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpOrden.TabIndex = 122
        Me.gpOrden.Text = "Orden"
        '
        'gpReportes
        '
        Me.gpReportes.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpReportes.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpReportes.Controls.Add(Me.dgReportes)
        Me.gpReportes.Controls.Add(Me.pnlFiltroReporte)
        Me.gpReportes.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpReportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gpReportes.Location = New System.Drawing.Point(0, 0)
        Me.gpReportes.Name = "gpReportes"
        Me.gpReportes.Size = New System.Drawing.Size(660, 416)
        '
        '
        '
        Me.gpReportes.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpReportes.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpReportes.Style.BackColorGradientAngle = 90
        Me.gpReportes.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpReportes.Style.BorderBottomWidth = 1
        Me.gpReportes.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpReportes.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpReportes.Style.BorderLeftWidth = 1
        Me.gpReportes.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpReportes.Style.BorderRightWidth = 1
        Me.gpReportes.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpReportes.Style.BorderTopWidth = 1
        Me.gpReportes.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpReportes.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpReportes.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpReportes.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.gpReportes.Style.TextShadowColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.gpReportes.Style.TextShadowOffset = New System.Drawing.Point(1, 1)
        '
        '
        '
        Me.gpReportes.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpReportes.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpReportes.TabIndex = 120
        Me.gpReportes.Text = "Reportes disponibles"
        '
        'pnlFiltroReporte
        '
        Me.pnlFiltroReporte.BackColor = System.Drawing.SystemColors.Window
        Me.pnlFiltroReporte.Controls.Add(Me.Label2)
        Me.pnlFiltroReporte.Controls.Add(Me.txtBusca)
        Me.pnlFiltroReporte.Controls.Add(Me.chkRecientes)
        Me.pnlFiltroReporte.Controls.Add(Me.Label1)
        Me.pnlFiltroReporte.Controls.Add(Me.cmbTipoReportes)
        Me.pnlFiltroReporte.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltroReporte.Location = New System.Drawing.Point(0, 0)
        Me.pnlFiltroReporte.Name = "pnlFiltroReporte"
        Me.pnlFiltroReporte.Size = New System.Drawing.Size(650, 61)
        Me.pnlFiltroReporte.TabIndex = 54
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Location = New System.Drawing.Point(3, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 280
        Me.Label2.Text = "Reporte:"
        '
        'txtBusca
        '
        '
        '
        '
        Me.txtBusca.Border.Class = "TextBoxBorder"
        Me.txtBusca.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBusca.Location = New System.Drawing.Point(68, 34)
        Me.txtBusca.Name = "txtBusca"
        Me.txtBusca.PreventEnterBeep = True
        Me.txtBusca.Size = New System.Drawing.Size(557, 20)
        Me.txtBusca.TabIndex = 279
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Location = New System.Drawing.Point(314, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 53
        Me.Label1.Text = "Mostrar reportes tipo:"
        '
        'cmbTipoReportes
        '
        Me.cmbTipoReportes.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbTipoReportes.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbTipoReportes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbTipoReportes.ButtonDropDown.Visible = True
        Me.cmbTipoReportes.Columns.Add(Me.ColumnHeader1)
        Me.cmbTipoReportes.Columns.Add(Me.ColumnHeader2)
        Me.cmbTipoReportes.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbTipoReportes.Location = New System.Drawing.Point(426, 8)
        Me.cmbTipoReportes.Name = "cmbTipoReportes"
        Me.cmbTipoReportes.Size = New System.Drawing.Size(199, 23)
        Me.cmbTipoReportes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipoReportes.TabIndex = 52
        Me.cmbTipoReportes.ValueMember = "tipo"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "tipo"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Tipo"
        Me.ColumnHeader1.Width.Absolute = 30
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "nombre"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Descripción"
        Me.ColumnHeader2.Width.Absolute = 150
        Me.ColumnHeader2.Width.AutoSize = True
        '
        'gpAvance
        '
        Me.gpAvance.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpAvance.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpAvance.Controls.Add(Me.lblAvance)
        Me.gpAvance.Controls.Add(Me.pbAvance)
        Me.gpAvance.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpAvance.Location = New System.Drawing.Point(394, 152)
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
        'lblAvance
        '
        Me.lblAvance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblAvance.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblAvance.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvance.Location = New System.Drawing.Point(0, 155)
        Me.lblAvance.Name = "lblAvance"
        Me.lblAvance.Size = New System.Drawing.Size(218, 60)
        Me.lblAvance.TabIndex = 271
        Me.lblAvance.Text = "Preparando datos..."
        Me.lblAvance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.pbAvance.Size = New System.Drawing.Size(218, 152)
        Me.pbAvance.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.pbAvance.TabIndex = 270
        '
        'lblRango
        '
        Me.lblRango.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblRango.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRango.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblRango.Location = New System.Drawing.Point(0, 0)
        Me.lblRango.Name = "lblRango"
        Me.lblRango.Size = New System.Drawing.Size(344, 23)
        Me.lblRango.TabIndex = 126
        Me.lblRango.Text = "EN EL RANGO DE"
        Me.lblRango.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFechas
        '
        Me.lblFechas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblFechas.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechas.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblFechas.Location = New System.Drawing.Point(0, 18)
        Me.lblFechas.Name = "lblFechas"
        Me.lblFechas.Size = New System.Drawing.Size(344, 36)
        Me.lblFechas.TabIndex = 127
        Me.lblFechas.Text = "fecha A fecha"
        Me.lblFechas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlRango
        '
        Me.pnlRango.BackColor = System.Drawing.SystemColors.HotTrack
        Me.pnlRango.Controls.Add(Me.lblRango)
        Me.pnlRango.Controls.Add(Me.lblFechas)
        Me.pnlRango.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlRango.Location = New System.Drawing.Point(664, 0)
        Me.pnlRango.Name = "pnlRango"
        Me.pnlRango.Size = New System.Drawing.Size(344, 54)
        Me.pnlRango.TabIndex = 129
        '
        'bgwReporte
        '
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.ReflectionLabel1)
        Me.Panel1.Controls.Add(Me.pnlRango)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        Me.Panel1.Size = New System.Drawing.Size(1008, 59)
        Me.Panel1.TabIndex = 276
        '
        'splReportes
        '
        Me.splReportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splReportes.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.splReportes.Location = New System.Drawing.Point(0, 59)
        Me.splReportes.Name = "splReportes"
        '
        'splReportes.Panel1
        '
        Me.splReportes.Panel1.Controls.Add(Me.gpReportes)
        '
        'splReportes.Panel2
        '
        Me.splReportes.Panel2.Controls.Add(Me.gpOrden)
        Me.splReportes.Panel2.Controls.Add(Me.pnlseparador)
        Me.splReportes.Panel2.Controls.Add(Me.gpFiltros)
        Me.splReportes.Size = New System.Drawing.Size(1008, 416)
        Me.splReportes.SplitterDistance = 660
        Me.splReportes.TabIndex = 54
        '
        'pnlseparador
        '
        Me.pnlseparador.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlseparador.Location = New System.Drawing.Point(0, 209)
        Me.pnlseparador.Name = "pnlseparador"
        Me.pnlseparador.Size = New System.Drawing.Size(344, 22)
        Me.pnlseparador.TabIndex = 49
        '
        'frmReporteadorTA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 522)
        Me.Controls.Add(Me.gpAvance)
        Me.Controls.Add(Me.splReportes)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gpControles)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReporteadorTA"
        Me.Text = "Reporteador TA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.txtBajas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtActivos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.gpFiltrosVigentes.ResumeLayout(False)
        Me.gpControles.ResumeLayout(False)
        Me.pnlCentrarControles.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpFiltros.ResumeLayout(False)
        Me.gpFiltros.PerformLayout()
        CType(Me.dgReportes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpOrden.ResumeLayout(False)
        Me.gpOrden.PerformLayout()
        Me.gpReportes.ResumeLayout(False)
        Me.pnlFiltroReporte.ResumeLayout(False)
        Me.pnlFiltroReporte.PerformLayout()
        Me.gpAvance.ResumeLayout(False)
        Me.pnlRango.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.splReportes.Panel1.ResumeLayout(False)
        Me.splReportes.Panel2.ResumeLayout(False)
        CType(Me.splReportes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splReportes.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnOrden As DevComponents.DotNetBar.ButtonX
    Friend WithEvents sbReloj As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents chkTodos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkOtrosFiltros As DevComponents.DotNetBar.Controls.CheckBoxX
    Private WithEvents txtBajas As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Private WithEvents txtActivos As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBajar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSubir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lstOrden As System.Windows.Forms.ListBox
    Friend WithEvents btnSeleccionarFiltros As DevComponents.DotNetBar.ButtonX
    Friend WithEvents gpFiltrosVigentes As System.Windows.Forms.GroupBox
    Friend WithEvents lstFiltros As System.Windows.Forms.ListBox
    Friend WithEvents chkOtroOrden As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkNombre As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkReloj As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents gpControles As System.Windows.Forms.GroupBox
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnGenerar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents sbNombre As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents chkBajas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkActivos As DevComponents.DotNetBar.Controls.CheckBoxX
    Private WithEvents gpFiltros As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents chkRecientes As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents USERNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FILTRAR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FRECUENCIA As DevComponents.DotNetBar.Controls.DataGridViewProgressBarXColumn
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgReportes As DevComponents.DotNetBar.Controls.DataGridViewX
    Private WithEvents gpOrden As DevComponents.DotNetBar.Controls.GroupPanel
    Private WithEvents gpReportes As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lblRango As System.Windows.Forms.Label
    Friend WithEvents lblFechas As System.Windows.Forms.Label
    Friend WithEvents pnlRango As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoReportes As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents bgwReporte As System.ComponentModel.BackgroundWorker
    Friend WithEvents gpAvance As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lblAvance As System.Windows.Forms.Label
    Friend WithEvents pbAvance As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents splReportes As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlFiltroReporte As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBusca As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents pnlCentrarControles As System.Windows.Forms.Panel
    Friend WithEvents pnlseparador As System.Windows.Forms.Panel
End Class
