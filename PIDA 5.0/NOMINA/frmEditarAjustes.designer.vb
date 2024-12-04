<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditarAjustes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditarAjustes))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gpDatos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.pnlComentario = New System.Windows.Forms.Panel()
        Me.txtComentario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblComentario = New System.Windows.Forms.Label()
        Me.pnlNumPeriodos = New System.Windows.Forms.Panel()
        Me.txtPeriodos = New DevComponents.Editors.IntegerInput()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlMonto = New System.Windows.Forms.Panel()
        Me.txtMonto = New DevComponents.Editors.DoubleInput()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlSaldo = New System.Windows.Forms.Panel()
        Me.txtSaldoInicial = New DevComponents.Editors.DoubleInput()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlCreditoFolio = New System.Windows.Forms.Panel()
        Me.txtCredito = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblCredito = New System.Windows.Forms.Label()
        Me.pnlFechaIncidencia = New System.Windows.Forms.Panel()
        Me.txtFechaIncidencia = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnlConceptos = New System.Windows.Forms.Panel()
        Me.cmbConcepto = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColConcepto = New DevComponents.AdvTree.ColumnHeader()
        Me.ColNombreConcepto = New DevComponents.AdvTree.ColumnHeader()
        Me.ColNaturaleza = New DevComponents.AdvTree.ColumnHeader()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlPeriodo = New System.Windows.Forms.Panel()
        Me.cmbPeriodo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColAno = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.pnlTipoAjuste = New System.Windows.Forms.Panel()
        Me.cmbTipoConcepto = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.colTipo = New DevComponents.AdvTree.ColumnHeader()
        Me.colDescripcion = New DevComponents.AdvTree.ColumnHeader()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ColCodigo = New DevComponents.AdvTree.ColumnHeader()
        Me.ColNombre = New DevComponents.AdvTree.ColumnHeader()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblEstado = New DevComponents.DotNetBar.LabelX()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        Me.gpDatos.SuspendLayout()
        Me.pnlComentario.SuspendLayout()
        Me.pnlNumPeriodos.SuspendLayout()
        CType(Me.txtPeriodos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlMonto.SuspendLayout()
        CType(Me.txtMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSaldo.SuspendLayout()
        CType(Me.txtSaldoInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCreditoFolio.SuspendLayout()
        Me.pnlFechaIncidencia.SuspendLayout()
        CType(Me.txtFechaIncidencia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlConceptos.SuspendLayout()
        Me.pnlPeriodo.SuspendLayout()
        Me.pnlTipoAjuste.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.BackgroundStyle.PaddingLeft = 10
        Me.ReflectionLabel1.BackgroundStyle.PaddingTop = 10
        Me.ReflectionLabel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(0, 0)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(199, 56)
        Me.ReflectionLabel1.TabIndex = 1
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>AJUSTES</b></font>"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LabelX4)
        Me.GroupBox1.Controls.Add(Me.txtReloj)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox1.Location = New System.Drawing.Point(229, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(171, 56)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
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
        Me.LabelX4.TabIndex = 0
        Me.LabelX4.Text = "Reloj"
        '
        'txtReloj
        '
        Me.txtReloj.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.Enabled = False
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.ForeColor = System.Drawing.Color.Black
        Me.txtReloj.Location = New System.Drawing.Point(79, 15)
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.ReadOnly = True
        Me.txtReloj.Size = New System.Drawing.Size(84, 26)
        Me.txtReloj.TabIndex = 1
        Me.txtReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(390, 20)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Nombre"
        '
        'gpDatos
        '
        Me.gpDatos.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpDatos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpDatos.Controls.Add(Me.pnlComentario)
        Me.gpDatos.Controls.Add(Me.pnlNumPeriodos)
        Me.gpDatos.Controls.Add(Me.pnlMonto)
        Me.gpDatos.Controls.Add(Me.pnlSaldo)
        Me.gpDatos.Controls.Add(Me.pnlCreditoFolio)
        Me.gpDatos.Controls.Add(Me.pnlFechaIncidencia)
        Me.gpDatos.Controls.Add(Me.pnlConceptos)
        Me.gpDatos.Controls.Add(Me.pnlPeriodo)
        Me.gpDatos.Controls.Add(Me.pnlTipoAjuste)
        Me.gpDatos.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gpDatos.Location = New System.Drawing.Point(0, 0)
        Me.gpDatos.Name = "gpDatos"
        Me.gpDatos.Padding = New System.Windows.Forms.Padding(10)
        Me.gpDatos.Size = New System.Drawing.Size(429, 319)
        '
        '
        '
        Me.gpDatos.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpDatos.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpDatos.Style.BackColorGradientAngle = 90
        Me.gpDatos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDatos.Style.BorderBottomWidth = 1
        Me.gpDatos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
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
        'pnlComentario
        '
        Me.pnlComentario.BackColor = System.Drawing.Color.White
        Me.pnlComentario.Controls.Add(Me.txtComentario)
        Me.pnlComentario.Controls.Add(Me.lblComentario)
        Me.pnlComentario.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlComentario.Location = New System.Drawing.Point(10, 250)
        Me.pnlComentario.Name = "pnlComentario"
        Me.pnlComentario.Padding = New System.Windows.Forms.Padding(4)
        Me.pnlComentario.Size = New System.Drawing.Size(407, 65)
        Me.pnlComentario.TabIndex = 0
        '
        'txtComentario
        '
        '
        '
        '
        Me.txtComentario.Border.Class = "TextBoxBorder"
        Me.txtComentario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtComentario.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtComentario.Location = New System.Drawing.Point(119, 4)
        Me.txtComentario.Multiline = True
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(281, 57)
        Me.txtComentario.TabIndex = 1
        '
        'lblComentario
        '
        Me.lblComentario.BackColor = System.Drawing.SystemColors.Window
        Me.lblComentario.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblComentario.Location = New System.Drawing.Point(4, 4)
        Me.lblComentario.Name = "lblComentario"
        Me.lblComentario.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.lblComentario.Size = New System.Drawing.Size(115, 57)
        Me.lblComentario.TabIndex = 0
        Me.lblComentario.Text = "Comentario"
        '
        'pnlNumPeriodos
        '
        Me.pnlNumPeriodos.BackColor = System.Drawing.Color.White
        Me.pnlNumPeriodos.Controls.Add(Me.txtPeriodos)
        Me.pnlNumPeriodos.Controls.Add(Me.Label3)
        Me.pnlNumPeriodos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNumPeriodos.Location = New System.Drawing.Point(10, 220)
        Me.pnlNumPeriodos.Name = "pnlNumPeriodos"
        Me.pnlNumPeriodos.Padding = New System.Windows.Forms.Padding(4)
        Me.pnlNumPeriodos.Size = New System.Drawing.Size(407, 30)
        Me.pnlNumPeriodos.TabIndex = 8
        '
        'txtPeriodos
        '
        '
        '
        '
        Me.txtPeriodos.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtPeriodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPeriodos.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtPeriodos.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtPeriodos.Location = New System.Drawing.Point(119, 4)
        Me.txtPeriodos.MaxValue = 52
        Me.txtPeriodos.MinValue = 0
        Me.txtPeriodos.Name = "txtPeriodos"
        Me.txtPeriodos.ShowUpDown = True
        Me.txtPeriodos.Size = New System.Drawing.Size(84, 20)
        Me.txtPeriodos.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Location = New System.Drawing.Point(4, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 22)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "# periodos"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlMonto
        '
        Me.pnlMonto.BackColor = System.Drawing.Color.White
        Me.pnlMonto.Controls.Add(Me.txtMonto)
        Me.pnlMonto.Controls.Add(Me.Label6)
        Me.pnlMonto.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMonto.Location = New System.Drawing.Point(10, 190)
        Me.pnlMonto.Name = "pnlMonto"
        Me.pnlMonto.Padding = New System.Windows.Forms.Padding(4)
        Me.pnlMonto.Size = New System.Drawing.Size(407, 30)
        Me.pnlMonto.TabIndex = 7
        '
        'txtMonto
        '
        '
        '
        '
        Me.txtMonto.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtMonto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMonto.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtMonto.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtMonto.Increment = 1.0R
        Me.txtMonto.Location = New System.Drawing.Point(119, 4)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.ShowUpDown = True
        Me.txtMonto.Size = New System.Drawing.Size(84, 20)
        Me.txtMonto.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label6.Location = New System.Drawing.Point(4, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 22)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Monto"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlSaldo
        '
        Me.pnlSaldo.BackColor = System.Drawing.Color.White
        Me.pnlSaldo.Controls.Add(Me.txtSaldoInicial)
        Me.pnlSaldo.Controls.Add(Me.Label2)
        Me.pnlSaldo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlSaldo.Location = New System.Drawing.Point(10, 160)
        Me.pnlSaldo.Name = "pnlSaldo"
        Me.pnlSaldo.Padding = New System.Windows.Forms.Padding(4)
        Me.pnlSaldo.Size = New System.Drawing.Size(407, 30)
        Me.pnlSaldo.TabIndex = 6
        '
        'txtSaldoInicial
        '
        '
        '
        '
        Me.txtSaldoInicial.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtSaldoInicial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSaldoInicial.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtSaldoInicial.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtSaldoInicial.Increment = 1.0R
        Me.txtSaldoInicial.Location = New System.Drawing.Point(119, 4)
        Me.txtSaldoInicial.Name = "txtSaldoInicial"
        Me.txtSaldoInicial.ShowUpDown = True
        Me.txtSaldoInicial.Size = New System.Drawing.Size(84, 20)
        Me.txtSaldoInicial.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.Location = New System.Drawing.Point(4, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 22)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Saldo inicial"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlCreditoFolio
        '
        Me.pnlCreditoFolio.BackColor = System.Drawing.Color.White
        Me.pnlCreditoFolio.Controls.Add(Me.txtCredito)
        Me.pnlCreditoFolio.Controls.Add(Me.lblCredito)
        Me.pnlCreditoFolio.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlCreditoFolio.Location = New System.Drawing.Point(10, 130)
        Me.pnlCreditoFolio.Name = "pnlCreditoFolio"
        Me.pnlCreditoFolio.Padding = New System.Windows.Forms.Padding(4)
        Me.pnlCreditoFolio.Size = New System.Drawing.Size(407, 30)
        Me.pnlCreditoFolio.TabIndex = 5
        '
        'txtCredito
        '
        '
        '
        '
        Me.txtCredito.Border.Class = "TextBoxBorder"
        Me.txtCredito.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCredito.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtCredito.Location = New System.Drawing.Point(119, 4)
        Me.txtCredito.MaxLength = 10
        Me.txtCredito.Name = "txtCredito"
        Me.txtCredito.Size = New System.Drawing.Size(84, 20)
        Me.txtCredito.TabIndex = 1
        '
        'lblCredito
        '
        Me.lblCredito.BackColor = System.Drawing.SystemColors.Window
        Me.lblCredito.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblCredito.Location = New System.Drawing.Point(4, 4)
        Me.lblCredito.Name = "lblCredito"
        Me.lblCredito.Size = New System.Drawing.Size(115, 22)
        Me.lblCredito.TabIndex = 0
        Me.lblCredito.Text = "# Crédito/folio"
        Me.lblCredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlFechaIncidencia
        '
        Me.pnlFechaIncidencia.BackColor = System.Drawing.Color.White
        Me.pnlFechaIncidencia.Controls.Add(Me.txtFechaIncidencia)
        Me.pnlFechaIncidencia.Controls.Add(Me.Label13)
        Me.pnlFechaIncidencia.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFechaIncidencia.Location = New System.Drawing.Point(10, 100)
        Me.pnlFechaIncidencia.Name = "pnlFechaIncidencia"
        Me.pnlFechaIncidencia.Padding = New System.Windows.Forms.Padding(4)
        Me.pnlFechaIncidencia.Size = New System.Drawing.Size(407, 30)
        Me.pnlFechaIncidencia.TabIndex = 4
        '
        'txtFechaIncidencia
        '
        '
        '
        '
        Me.txtFechaIncidencia.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaIncidencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaIncidencia.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtFechaIncidencia.ButtonDropDown.Visible = True
        Me.txtFechaIncidencia.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtFechaIncidencia.IsPopupCalendarOpen = False
        Me.txtFechaIncidencia.Location = New System.Drawing.Point(119, 4)
        '
        '
        '
        Me.txtFechaIncidencia.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaIncidencia.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaIncidencia.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtFechaIncidencia.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaIncidencia.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaIncidencia.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaIncidencia.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaIncidencia.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaIncidencia.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaIncidencia.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaIncidencia.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaIncidencia.MonthCalendar.DisplayMonth = New Date(2017, 10, 1, 0, 0, 0, 0)
        Me.txtFechaIncidencia.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
        Me.txtFechaIncidencia.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaIncidencia.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaIncidencia.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaIncidencia.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaIncidencia.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaIncidencia.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaIncidencia.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaIncidencia.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFechaIncidencia.Name = "txtFechaIncidencia"
        Me.txtFechaIncidencia.Size = New System.Drawing.Size(84, 20)
        Me.txtFechaIncidencia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFechaIncidencia.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Window
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label13.Location = New System.Drawing.Point(4, 4)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(115, 22)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Fecha incidencia"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlConceptos
        '
        Me.pnlConceptos.BackColor = System.Drawing.Color.White
        Me.pnlConceptos.Controls.Add(Me.cmbConcepto)
        Me.pnlConceptos.Controls.Add(Me.Label1)
        Me.pnlConceptos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlConceptos.Location = New System.Drawing.Point(10, 70)
        Me.pnlConceptos.Name = "pnlConceptos"
        Me.pnlConceptos.Padding = New System.Windows.Forms.Padding(4)
        Me.pnlConceptos.Size = New System.Drawing.Size(407, 30)
        Me.pnlConceptos.TabIndex = 3
        '
        'cmbConcepto
        '
        Me.cmbConcepto.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbConcepto.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbConcepto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbConcepto.ButtonDropDown.Visible = True
        Me.cmbConcepto.Columns.Add(Me.ColConcepto)
        Me.cmbConcepto.Columns.Add(Me.ColNombreConcepto)
        Me.cmbConcepto.Columns.Add(Me.ColNaturaleza)
        Me.cmbConcepto.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmbConcepto.GroupingMembers = "naturaleza"
        Me.cmbConcepto.GroupNodeStyle = Me.ElementStyle1
        Me.cmbConcepto.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbConcepto.Location = New System.Drawing.Point(119, 4)
        Me.cmbConcepto.Name = "cmbConcepto"
        Me.cmbConcepto.Size = New System.Drawing.Size(281, 22)
        Me.cmbConcepto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbConcepto.TabIndex = 1
        Me.cmbConcepto.ValueMember = "concepto"
        '
        'ColConcepto
        '
        Me.ColConcepto.ColumnName = "ColConcepto"
        Me.ColConcepto.DataFieldName = "concepto"
        Me.ColConcepto.Name = "ColConcepto"
        Me.ColConcepto.Text = "Código"
        Me.ColConcepto.Width.Absolute = 100
        '
        'ColNombreConcepto
        '
        Me.ColNombreConcepto.ColumnName = "ColNombre"
        Me.ColNombreConcepto.DataFieldName = "nombre"
        Me.ColNombreConcepto.Name = "ColNombreConcepto"
        Me.ColNombreConcepto.StretchToFill = True
        Me.ColNombreConcepto.Text = "Concepto"
        Me.ColNombreConcepto.Width.Absolute = 150
        Me.ColNombreConcepto.Width.AutoSize = True
        '
        'ColNaturaleza
        '
        Me.ColNaturaleza.ColumnName = "ColNaturaleza"
        Me.ColNaturaleza.DataFieldName = "naturaleza"
        Me.ColNaturaleza.Name = "ColNaturaleza"
        Me.ColNaturaleza.Text = "Naturaleza"
        Me.ColNaturaleza.Visible = False
        Me.ColNaturaleza.Width.Absolute = 150
        '
        'ElementStyle1
        '
        Me.ElementStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ElementStyle1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ElementStyle1.BackColorGradientAngle = 90
        Me.ElementStyle1.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderBottomWidth = 1
        Me.ElementStyle1.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle1.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderLeftWidth = 1
        Me.ElementStyle1.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderRightWidth = 1
        Me.ElementStyle1.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderTopWidth = 1
        Me.ElementStyle1.CornerDiameter = 4
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Description = "Blue"
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.PaddingBottom = 1
        Me.ElementStyle1.PaddingLeft = 1
        Me.ElementStyle1.PaddingRight = 1
        Me.ElementStyle1.PaddingTop = 1
        Me.ElementStyle1.TextColor = System.Drawing.Color.Black
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Location = New System.Drawing.Point(4, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Concepto"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlPeriodo
        '
        Me.pnlPeriodo.BackColor = System.Drawing.Color.White
        Me.pnlPeriodo.Controls.Add(Me.cmbPeriodo)
        Me.pnlPeriodo.Controls.Add(Me.lblPeriodo)
        Me.pnlPeriodo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlPeriodo.Location = New System.Drawing.Point(10, 40)
        Me.pnlPeriodo.Name = "pnlPeriodo"
        Me.pnlPeriodo.Padding = New System.Windows.Forms.Padding(4)
        Me.pnlPeriodo.Size = New System.Drawing.Size(407, 30)
        Me.pnlPeriodo.TabIndex = 2
        '
        'cmbPeriodo
        '
        Me.cmbPeriodo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPeriodo.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPeriodo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPeriodo.ButtonDropDown.Visible = True
        Me.cmbPeriodo.Columns.Add(Me.ColumnHeader4)
        Me.cmbPeriodo.Columns.Add(Me.ColAno)
        Me.cmbPeriodo.Columns.Add(Me.ColumnHeader1)
        Me.cmbPeriodo.Columns.Add(Me.ColumnHeader2)
        Me.cmbPeriodo.Columns.Add(Me.ColumnHeader3)
        Me.cmbPeriodo.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmbPeriodo.FormatString = "d"
        Me.cmbPeriodo.FormattingEnabled = True
        Me.cmbPeriodo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPeriodo.Location = New System.Drawing.Point(119, 4)
        Me.cmbPeriodo.Name = "cmbPeriodo"
        Me.cmbPeriodo.Size = New System.Drawing.Size(281, 22)
        Me.cmbPeriodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPeriodo.TabIndex = 1
        Me.cmbPeriodo.ValueMember = "unico"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DataFieldName = "unico"
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "Column"
        Me.ColumnHeader4.Visible = False
        Me.ColumnHeader4.Width.Absolute = 150
        '
        'ColAno
        '
        Me.ColAno.ColumnName = "ano"
        Me.ColAno.DataFieldName = "ano"
        Me.ColAno.Name = "ColAno"
        Me.ColAno.Text = "Año"
        Me.ColAno.Width.Relative = 20
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "periodo"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Periodo"
        Me.ColumnHeader1.Width.Relative = 20
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "fecha_ini"
        Me.ColumnHeader2.EditorType = DevComponents.AdvTree.eCellEditorType.[Date]
        Me.ColumnHeader2.MaxInputLength = 10
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Fecha inicial"
        Me.ColumnHeader2.Width.Relative = 30
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DataFieldName = "fecha_fin"
        Me.ColumnHeader3.EditorType = DevComponents.AdvTree.eCellEditorType.[Date]
        Me.ColumnHeader3.MaxInputLength = 10
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Fecha final"
        Me.ColumnHeader3.Width.Relative = 30
        '
        'lblPeriodo
        '
        Me.lblPeriodo.BackColor = System.Drawing.SystemColors.Window
        Me.lblPeriodo.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblPeriodo.Location = New System.Drawing.Point(4, 4)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(115, 22)
        Me.lblPeriodo.TabIndex = 0
        Me.lblPeriodo.Text = "Periodo"
        Me.lblPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlTipoAjuste
        '
        Me.pnlTipoAjuste.BackColor = System.Drawing.Color.White
        Me.pnlTipoAjuste.Controls.Add(Me.cmbTipoConcepto)
        Me.pnlTipoAjuste.Controls.Add(Me.Label4)
        Me.pnlTipoAjuste.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTipoAjuste.Location = New System.Drawing.Point(10, 10)
        Me.pnlTipoAjuste.Name = "pnlTipoAjuste"
        Me.pnlTipoAjuste.Padding = New System.Windows.Forms.Padding(4)
        Me.pnlTipoAjuste.Size = New System.Drawing.Size(407, 30)
        Me.pnlTipoAjuste.TabIndex = 1
        '
        'cmbTipoConcepto
        '
        Me.cmbTipoConcepto.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbTipoConcepto.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbTipoConcepto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbTipoConcepto.ButtonDropDown.Visible = True
        Me.cmbTipoConcepto.Columns.Add(Me.colTipo)
        Me.cmbTipoConcepto.Columns.Add(Me.colDescripcion)
        Me.cmbTipoConcepto.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmbTipoConcepto.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbTipoConcepto.Location = New System.Drawing.Point(119, 4)
        Me.cmbTipoConcepto.Name = "cmbTipoConcepto"
        Me.cmbTipoConcepto.Size = New System.Drawing.Size(281, 22)
        Me.cmbTipoConcepto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipoConcepto.TabIndex = 1
        Me.cmbTipoConcepto.ValueMember = "tipo"
        '
        'colTipo
        '
        Me.colTipo.DataFieldName = "tipo"
        Me.colTipo.Name = "colTipo"
        Me.colTipo.Text = "Tipo"
        Me.colTipo.Width.Absolute = 70
        '
        'colDescripcion
        '
        Me.colDescripcion.DataFieldName = "descripcion"
        Me.colDescripcion.Name = "colDescripcion"
        Me.colDescripcion.StretchToFill = True
        Me.colDescripcion.Text = "Descripción"
        Me.colDescripcion.Width.Absolute = 150
        Me.colDescripcion.Width.AutoSize = True
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label4.Location = New System.Drawing.Point(4, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 22)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Tipo de ajuste"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ColCodigo
        '
        Me.ColCodigo.ColumnName = "ColCodigo"
        Me.ColCodigo.DataFieldName = "cod_naturaleza"
        Me.ColCodigo.Name = "ColCodigo"
        Me.ColCodigo.Text = "Código"
        Me.ColCodigo.Width.Absolute = 60
        '
        'ColNombre
        '
        Me.ColNombre.ColumnName = "ColNombre"
        Me.ColNombre.DataFieldName = "naturaleza"
        Me.ColNombre.Name = "ColNombre"
        Me.ColNombre.StretchToFill = True
        Me.ColNombre.Text = "Nombre"
        Me.ColNombre.Width.Absolute = 150
        Me.ColNombre.Width.AutoSize = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnAceptar)
        Me.GroupBox2.Controls.Add(Me.Panel6)
        Me.GroupBox2.Controls.Add(Me.btnCerrar)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(10, 449)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(10, 0, 10, 8)
        Me.GroupBox2.Size = New System.Drawing.Size(429, 47)
        Me.GroupBox2.TabIndex = 251
        Me.GroupBox2.TabStop = False
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.acept_
        Me.btnAceptar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnAceptar.ImageTextSpacing = 3
        Me.btnAceptar.Location = New System.Drawing.Point(232, 13)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(90, 26)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 278
        Me.btnAceptar.Text = "Aceptar"
        '
        'Panel6
        '
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(322, 13)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(7, 26)
        Me.Panel6.TabIndex = 277
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.salir_
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.ImageTextSpacing = 3
        Me.btnCerrar.Location = New System.Drawing.Point(329, 13)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(90, 26)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 276
        Me.btnCerrar.Text = "Cancelar"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.lblEstado)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(10, 10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(429, 110)
        Me.Panel1.TabIndex = 252
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtNombre)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(29, 56)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(10, 0, 0, 10)
        Me.Panel3.Size = New System.Drawing.Size(400, 54)
        Me.Panel3.TabIndex = 253
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.Color.Black
        Me.txtNombre.Location = New System.Drawing.Point(10, 20)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(382, 21)
        Me.txtNombre.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ReflectionLabel1)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(29, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(400, 56)
        Me.Panel2.TabIndex = 2
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
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Window
        Me.lblEstado.Location = New System.Drawing.Point(0, 0)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(29, 110)
        Me.lblEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblEstado.TabIndex = 1
        Me.lblEstado.Text = "ACTIVO"
        Me.lblEstado.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblEstado.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.lblEstado.VerticalTextTopUp = False
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(10, 120)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(429, 10)
        Me.Panel4.TabIndex = 253
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.gpDatos)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(10, 130)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(429, 319)
        Me.Panel5.TabIndex = 254
        '
        'frmEditarAjustes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(449, 506)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditarAjustes"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar/Agregar"
        Me.GroupBox1.ResumeLayout(False)
        Me.gpDatos.ResumeLayout(False)
        Me.pnlComentario.ResumeLayout(False)
        Me.pnlNumPeriodos.ResumeLayout(False)
        CType(Me.txtPeriodos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlMonto.ResumeLayout(False)
        CType(Me.txtMonto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSaldo.ResumeLayout(False)
        CType(Me.txtSaldoInicial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCreditoFolio.ResumeLayout(False)
        Me.pnlFechaIncidencia.ResumeLayout(False)
        CType(Me.txtFechaIncidencia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlConceptos.ResumeLayout(False)
        Me.pnlPeriodo.ResumeLayout(False)
        Me.pnlTipoAjuste.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gpDatos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColCodigo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColNombre As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColConcepto As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColNombreConcepto As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColAno As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColNaturaleza As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents pnlTipoAjuste As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlComentario As System.Windows.Forms.Panel
    Friend WithEvents txtComentario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblComentario As System.Windows.Forms.Label
    Friend WithEvents pnlMonto As System.Windows.Forms.Panel
    Friend WithEvents txtMonto As DevComponents.Editors.DoubleInput
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pnlSaldo As System.Windows.Forms.Panel
    Friend WithEvents txtSaldoInicial As DevComponents.Editors.DoubleInput
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlCreditoFolio As System.Windows.Forms.Panel
    Friend WithEvents txtCredito As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblCredito As System.Windows.Forms.Label
    Friend WithEvents pnlFechaIncidencia As System.Windows.Forms.Panel
    Friend WithEvents txtFechaIncidencia As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents pnlConceptos As System.Windows.Forms.Panel
    Friend WithEvents cmbConcepto As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlNumPeriodos As System.Windows.Forms.Panel
    Friend WithEvents txtPeriodos As DevComponents.Editors.IntegerInput
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlPeriodo As System.Windows.Forms.Panel
    Friend WithEvents cmbPeriodo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents cmbTipoConcepto As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents colTipo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colDescripcion As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblEstado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
End Class
