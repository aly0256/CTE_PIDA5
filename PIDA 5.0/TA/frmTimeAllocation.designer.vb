<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTimeAllocation
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
        Dim Background8 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background9 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background1 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background2 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background3 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Padding1 As DevComponents.DotNetBar.SuperGrid.Style.Padding = New DevComponents.DotNetBar.SuperGrid.Style.Padding()
        Dim Background4 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background5 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background6 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Padding2 As DevComponents.DotNetBar.SuperGrid.Style.Padding = New DevComponents.DotNetBar.SuperGrid.Style.Padding()
        Dim Background7 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTimeAllocation))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.pnlFecha = New System.Windows.Forms.Panel()
        Me.picFestivo = New System.Windows.Forms.PictureBox()
        Me.txtFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlTiempo = New System.Windows.Forms.Panel()
        Me.txtHoras = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnMostrarInformacion = New DevComponents.DotNetBar.ButtonX()
        Me.lblUltActualizacion = New DevComponents.DotNetBar.LabelX()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlCentrarControles = New System.Windows.Forms.Panel()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAgregarOrden = New DevComponents.DotNetBar.ButtonX()
        Me.dgPersonal = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopiarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.AgregarOrdenDeTrabajoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BorrarOrdenDeTrabajoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.AsignarHorasEmpleadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AsignarHorasOrdenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.colReloj = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colNombres = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colCodCC = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colCodTurno = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colCodDepto = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colCodSuper = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colHrsNormales = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colHrsExtras = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn6 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn7 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn2 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader6 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader7 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader8 = New DevComponents.AdvTree.ColumnHeader()
        Me.GridColumn3 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.lblTip = New System.Windows.Forms.Label()
        Me.bgCargaFecha = New System.ComponentModel.BackgroundWorker()
        Me.gpAvance = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.lblAvance = New System.Windows.Forms.Label()
        Me.pbAvance = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.spltGrupos = New DevComponents.DotNetBar.ExpandableSplitter()
        Me.treGrupos = New DevComponents.AdvTree.AdvTree()
        Me.Node1 = New DevComponents.AdvTree.Node()
        Me.Node16 = New DevComponents.AdvTree.Node()
        Me.Cell8 = New DevComponents.AdvTree.Cell()
        Me.EstiloRegularDerecha = New DevComponents.DotNetBar.ElementStyle()
        Me.Node17 = New DevComponents.AdvTree.Node()
        Me.Cell6 = New DevComponents.AdvTree.Cell()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.Node18 = New DevComponents.AdvTree.Node()
        Me.Cell7 = New DevComponents.AdvTree.Cell()
        Me.ColumnHeader15 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader16 = New DevComponents.AdvTree.ColumnHeader()
        Me.EstiloTotal = New DevComponents.DotNetBar.ElementStyle()
        Me.Node9 = New DevComponents.AdvTree.Node()
        Me.Node4 = New DevComponents.AdvTree.Node()
        Me.Node6 = New DevComponents.AdvTree.Node()
        Me.Cell1 = New DevComponents.AdvTree.Cell()
        Me.EstiloRegular = New DevComponents.DotNetBar.ElementStyle()
        Me.Node8 = New DevComponents.AdvTree.Node()
        Me.Cell2 = New DevComponents.AdvTree.Cell()
        Me.Node12 = New DevComponents.AdvTree.Node()
        Me.Cell4 = New DevComponents.AdvTree.Cell()
        Me.Node13 = New DevComponents.AdvTree.Node()
        Me.Cell3 = New DevComponents.AdvTree.Cell()
        Me.ColumnHeader11 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader12 = New DevComponents.AdvTree.ColumnHeader()
        Me.Node11 = New DevComponents.AdvTree.Node()
        Me.Cell5 = New DevComponents.AdvTree.Cell()
        Me.EstiloDiferenciaPositiva = New DevComponents.DotNetBar.ElementStyle()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.EstiloTurno = New DevComponents.DotNetBar.ElementStyle()
        Me.EstiloSeleccionado = New DevComponents.DotNetBar.ElementStyle()
        Me.Node10 = New DevComponents.AdvTree.Node()
        Me.ColumnHeader9 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader10 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader13 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader14 = New DevComponents.AdvTree.ColumnHeader()
        Me.EstiloDepartamento = New DevComponents.DotNetBar.ElementStyle()
        Me.Node19 = New DevComponents.AdvTree.Node()
        Me.EstiloSupervisor = New DevComponents.DotNetBar.ElementStyle()
        Me.EstiloMouseOver = New DevComponents.DotNetBar.ElementStyle()
        Me.Node2 = New DevComponents.AdvTree.Node()
        Me.Node5 = New DevComponents.AdvTree.Node()
        Me.Node7 = New DevComponents.AdvTree.Node()
        Me.Node3 = New DevComponents.AdvTree.Node()
        Me.Node14 = New DevComponents.AdvTree.Node()
        Me.Node15 = New DevComponents.AdvTree.Node()
        Me.EstiloDiferencia0 = New DevComponents.DotNetBar.ElementStyle()
        Me.EstiloDiferenciaNegativa = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle2 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle3 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle4 = New DevComponents.DotNetBar.ElementStyle()
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlParametros.SuspendLayout()
        Me.pnlFecha.SuspendLayout()
        CType(Me.picFestivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTiempo.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlCentrarControles.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.gpAvance.SuspendLayout()
        CType(Me.treGrupos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.Controls.Add(Me.pnlParametros)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Padding = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.pnlEncabezado.Size = New System.Drawing.Size(1136, 77)
        Me.pnlEncabezado.TabIndex = 1
        '
        'pnlParametros
        '
        Me.pnlParametros.Controls.Add(Me.pnlFecha)
        Me.pnlParametros.Controls.Add(Me.pnlTiempo)
        Me.pnlParametros.Controls.Add(Me.btnMostrarInformacion)
        Me.pnlParametros.Controls.Add(Me.lblUltActualizacion)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlParametros.Location = New System.Drawing.Point(645, 3)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(488, 64)
        Me.pnlParametros.TabIndex = 6
        '
        'pnlFecha
        '
        Me.pnlFecha.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.pnlFecha.Controls.Add(Me.picFestivo)
        Me.pnlFecha.Controls.Add(Me.txtFecha)
        Me.pnlFecha.Controls.Add(Me.Label5)
        Me.pnlFecha.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFecha.Location = New System.Drawing.Point(0, 18)
        Me.pnlFecha.MinimumSize = New System.Drawing.Size(175, 0)
        Me.pnlFecha.Name = "pnlFecha"
        Me.pnlFecha.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlFecha.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.pnlFecha.Size = New System.Drawing.Size(233, 46)
        Me.pnlFecha.TabIndex = 0
        '
        'picFestivo
        '
        Me.picFestivo.Image = Global.PIDA.My.Resources.Resources.Festivo24
        Me.picFestivo.Location = New System.Drawing.Point(190, 11)
        Me.picFestivo.Name = "picFestivo"
        Me.picFestivo.Size = New System.Drawing.Size(24, 24)
        Me.picFestivo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.SuperTooltip1.SetSuperTooltip(Me.picFestivo, New DevComponents.DotNetBar.SuperTooltipInfo("", "", "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DIA FESTIVO", Global.PIDA.My.Resources.Resources.Festivo24, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray, False, False, New System.Drawing.Size(0, 0)))
        Me.picFestivo.TabIndex = 2
        Me.picFestivo.TabStop = False
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
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.IsPopupCalendarOpen = False
        Me.txtFecha.Location = New System.Drawing.Point(82, 12)
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
        Me.txtFecha.MonthCalendar.DisplayMonth = New Date(2015, 5, 1, 0, 0, 0, 0)
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
        Me.txtFecha.Size = New System.Drawing.Size(104, 23)
        Me.txtFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFecha.TabIndex = 1
        Me.txtFecha.Value = New Date(2015, 9, 22, 9, 7, 8, 0)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(47, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Fecha"
        '
        'pnlTiempo
        '
        Me.pnlTiempo.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.pnlTiempo.Controls.Add(Me.txtHoras)
        Me.pnlTiempo.Controls.Add(Me.Label1)
        Me.pnlTiempo.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlTiempo.Location = New System.Drawing.Point(233, 18)
        Me.pnlTiempo.MinimumSize = New System.Drawing.Size(175, 0)
        Me.pnlTiempo.Name = "pnlTiempo"
        Me.pnlTiempo.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlTiempo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.pnlTiempo.Size = New System.Drawing.Size(224, 46)
        Me.pnlTiempo.TabIndex = 1
        '
        'txtHoras
        '
        Me.txtHoras.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.txtHoras.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList
        Me.txtHoras.AutoSelectAll = True
        Me.txtHoras.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtHoras.Border.Class = "TextBoxBorder"
        Me.txtHoras.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtHoras.DisabledBackColor = System.Drawing.Color.White
        Me.txtHoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoras.ForeColor = System.Drawing.Color.Black
        Me.txtHoras.Location = New System.Drawing.Point(143, 12)
        Me.txtHoras.MaxLength = 5
        Me.txtHoras.Name = "txtHoras"
        Me.txtHoras.PreventEnterBeep = True
        Me.txtHoras.Size = New System.Drawing.Size(56, 23)
        Me.txtHoras.TabIndex = 1
        Me.txtHoras.Text = "00:00"
        Me.txtHoras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(102, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Asignar tiempo"
        '
        'btnMostrarInformacion
        '
        Me.btnMostrarInformacion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnMostrarInformacion.CausesValidation = False
        Me.btnMostrarInformacion.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.btnMostrarInformacion.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnMostrarInformacion.FocusCuesEnabled = False
        Me.btnMostrarInformacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMostrarInformacion.Image = Global.PIDA.My.Resources.Resources.refresh16
        Me.btnMostrarInformacion.Location = New System.Drawing.Point(457, 18)
        Me.btnMostrarInformacion.Name = "btnMostrarInformacion"
        Me.btnMostrarInformacion.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5)
        Me.btnMostrarInformacion.Size = New System.Drawing.Size(31, 46)
        Me.btnMostrarInformacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnMostrarInformacion.TabIndex = 2
        '
        'lblUltActualizacion
        '
        '
        '
        '
        Me.lblUltActualizacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblUltActualizacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblUltActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltActualizacion.Location = New System.Drawing.Point(0, 0)
        Me.lblUltActualizacion.Name = "lblUltActualizacion"
        Me.lblUltActualizacion.PaddingRight = 10
        Me.lblUltActualizacion.Size = New System.Drawing.Size(488, 18)
        Me.lblUltActualizacion.TabIndex = 6
        Me.lblUltActualizacion.Text = "Información actualizada al: 4/11/2015 09:34:10.00 AM"
        Me.lblUltActualizacion.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.ReflectionLabel1)
        Me.pnlTitulo.Controls.Add(Me.picImagen)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTitulo.Location = New System.Drawing.Point(3, 3)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(480, 64)
        Me.pnlTitulo.TabIndex = 3
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
        Me.ReflectionLabel1.Size = New System.Drawing.Size(424, 40)
        Me.ReflectionLabel1.TabIndex = 0
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>DISTRIBUCIÓN DE TIEMPO</b></font>"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.Timer32
        Me.picImagen.Location = New System.Drawing.Point(12, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(32, 32)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picImagen.TabIndex = 110
        Me.picImagen.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlCentrarControles)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 515)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1136, 48)
        Me.Panel1.TabIndex = 2
        '
        'pnlCentrarControles
        '
        Me.pnlCentrarControles.Controls.Add(Me.btnBuscar)
        Me.pnlCentrarControles.Controls.Add(Me.btnReporte)
        Me.pnlCentrarControles.Controls.Add(Me.btnCerrar)
        Me.pnlCentrarControles.Controls.Add(Me.btnAgregarOrden)
        Me.pnlCentrarControles.Location = New System.Drawing.Point(53, 6)
        Me.pnlCentrarControles.Name = "pnlCentrarControles"
        Me.pnlCentrarControles.Size = New System.Drawing.Size(384, 32)
        Me.pnlCentrarControles.TabIndex = 0
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBuscar.Location = New System.Drawing.Point(126, 3)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(78, 25)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Tooltip = "Buscar"
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnReporte.Location = New System.Drawing.Point(212, 3)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 2
        Me.btnReporte.Text = "Reporte"
        Me.btnReporte.Visible = False
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(298, 3)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.Text = "Salir"
        '
        'btnAgregarOrden
        '
        Me.btnAgregarOrden.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAgregarOrden.CausesValidation = False
        Me.btnAgregarOrden.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAgregarOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarOrden.Image = Global.PIDA.My.Resources.Resources.Add
        Me.btnAgregarOrden.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnAgregarOrden.Location = New System.Drawing.Point(5, 3)
        Me.btnAgregarOrden.Name = "btnAgregarOrden"
        Me.btnAgregarOrden.Size = New System.Drawing.Size(115, 25)
        Me.btnAgregarOrden.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAgregarOrden.TabIndex = 0
        Me.btnAgregarOrden.Text = "Agregar orden"
        Me.btnAgregarOrden.Tooltip = "Buscar"
        '
        'dgPersonal
        '
        Me.dgPersonal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgPersonal.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgPersonal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgPersonal.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.dgPersonal.FilterUseExtendedCustomDialog = True
        Me.dgPersonal.ForeColor = System.Drawing.Color.Black
        Me.dgPersonal.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.dgPersonal.Location = New System.Drawing.Point(300, 77)
        Me.dgPersonal.Name = "dgPersonal"
        '
        '
        '
        Me.dgPersonal.PrimaryGrid.AutoGenerateColumns = False
        Me.dgPersonal.PrimaryGrid.ColumnDragBehavior = DevComponents.DotNetBar.SuperGrid.ColumnDragBehavior.None
        Me.dgPersonal.PrimaryGrid.ColumnGroupHeaderClickBehavior = DevComponents.DotNetBar.SuperGrid.ColumnHeaderClickBehavior.None
        '
        '
        '
        Me.dgPersonal.PrimaryGrid.ColumnHeader.AutoApplyGroupColors = False
        Me.dgPersonal.PrimaryGrid.ColumnHeader.ShowGroupColumnHeaders = False
        Me.dgPersonal.PrimaryGrid.ColumnHeader.ShowHeaderImages = False
        Me.dgPersonal.PrimaryGrid.Columns.Add(Me.colReloj)
        Me.dgPersonal.PrimaryGrid.Columns.Add(Me.colNombres)
        Me.dgPersonal.PrimaryGrid.Columns.Add(Me.colCodCC)
        Me.dgPersonal.PrimaryGrid.Columns.Add(Me.colCodTurno)
        Me.dgPersonal.PrimaryGrid.Columns.Add(Me.colCodDepto)
        Me.dgPersonal.PrimaryGrid.Columns.Add(Me.colCodSuper)
        Me.dgPersonal.PrimaryGrid.Columns.Add(Me.colHrsNormales)
        Me.dgPersonal.PrimaryGrid.Columns.Add(Me.colHrsExtras)
        Me.dgPersonal.PrimaryGrid.Columns.Add(Me.GridColumn6)
        Me.dgPersonal.PrimaryGrid.Columns.Add(Me.GridColumn7)
        Background8.Color1 = System.Drawing.Color.LightSteelBlue
        Me.dgPersonal.PrimaryGrid.DefaultVisualStyles.GroupHeaderStyles.Default.Background = Background8
        Me.dgPersonal.PrimaryGrid.DefaultVisualStyles.GroupHeaderStyles.Default.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Background9.Color1 = System.Drawing.SystemColors.Highlight
        Me.dgPersonal.PrimaryGrid.DefaultVisualStyles.RowStyles.Selected.Background = Background9
        Me.dgPersonal.PrimaryGrid.EnableFiltering = True
        Me.dgPersonal.PrimaryGrid.ExpandButtonType = DevComponents.DotNetBar.SuperGrid.ExpandButtonType.Triangle
        '
        '
        '
        Me.dgPersonal.PrimaryGrid.Filter.AllowSelection = False
        Me.dgPersonal.PrimaryGrid.FrozenColumnCount = 2
        '
        '
        '
        Me.dgPersonal.PrimaryGrid.GroupByRow.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.Never
        Me.dgPersonal.PrimaryGrid.GroupHeaderClickBehavior = DevComponents.DotNetBar.SuperGrid.GroupHeaderClickBehavior.[Select]
        Me.dgPersonal.PrimaryGrid.ShowRowHeaders = False
        Me.dgPersonal.PrimaryGrid.ShowTreeButtons = True
        Me.dgPersonal.ShowCustomFilterHelp = False
        Me.dgPersonal.Size = New System.Drawing.Size(836, 438)
        Me.dgPersonal.TabIndex = 3
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopiarToolStripMenuItem, Me.ToolStripMenuItem2, Me.AgregarOrdenDeTrabajoToolStripMenuItem, Me.BorrarOrdenDeTrabajoToolStripMenuItem, Me.ToolStripMenuItem3, Me.AsignarHorasEmpleadoToolStripMenuItem, Me.AsignarHorasOrdenToolStripMenuItem, Me.ToolStripMenuItem1, Me.CerrarToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(207, 154)
        '
        'CopiarToolStripMenuItem
        '
        Me.CopiarToolStripMenuItem.Image = Global.PIDA.My.Resources.Resources.copy_16
        Me.CopiarToolStripMenuItem.Name = "CopiarToolStripMenuItem"
        Me.CopiarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopiarToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.CopiarToolStripMenuItem.Text = "Copiar"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(203, 6)
        '
        'AgregarOrdenDeTrabajoToolStripMenuItem
        '
        Me.AgregarOrdenDeTrabajoToolStripMenuItem.Image = Global.PIDA.My.Resources.Resources.Add
        Me.AgregarOrdenDeTrabajoToolStripMenuItem.Name = "AgregarOrdenDeTrabajoToolStripMenuItem"
        Me.AgregarOrdenDeTrabajoToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.AgregarOrdenDeTrabajoToolStripMenuItem.Text = "Agregar orden de trabajo"
        '
        'BorrarOrdenDeTrabajoToolStripMenuItem
        '
        Me.BorrarOrdenDeTrabajoToolStripMenuItem.Image = Global.PIDA.My.Resources.Resources.Delete
        Me.BorrarOrdenDeTrabajoToolStripMenuItem.Name = "BorrarOrdenDeTrabajoToolStripMenuItem"
        Me.BorrarOrdenDeTrabajoToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.BorrarOrdenDeTrabajoToolStripMenuItem.Text = "Borrar orden de trabajo"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(203, 6)
        '
        'AsignarHorasEmpleadoToolStripMenuItem
        '
        Me.AsignarHorasEmpleadoToolStripMenuItem.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.AsignarHorasEmpleadoToolStripMenuItem.Image = Global.PIDA.My.Resources.Resources.Plus16
        Me.AsignarHorasEmpleadoToolStripMenuItem.Name = "AsignarHorasEmpleadoToolStripMenuItem"
        Me.AsignarHorasEmpleadoToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.AsignarHorasEmpleadoToolStripMenuItem.Text = "Asignar horas empleado"
        '
        'AsignarHorasOrdenToolStripMenuItem
        '
        Me.AsignarHorasOrdenToolStripMenuItem.Name = "AsignarHorasOrdenToolStripMenuItem"
        Me.AsignarHorasOrdenToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.AsignarHorasOrdenToolStripMenuItem.Text = "Asignar horas orden"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(203, 6)
        '
        'CerrarToolStripMenuItem
        '
        Me.CerrarToolStripMenuItem.Name = "CerrarToolStripMenuItem"
        Me.CerrarToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.CerrarToolStripMenuItem.Text = "Cerrar"
        '
        'colReloj
        '
        Me.colReloj.AllowEdit = False
        Me.colReloj.DataPropertyName = "reloj"
        Me.colReloj.HeaderText = "RELOJ"
        Me.colReloj.Name = "colReloj"
        Me.colReloj.ReadOnly = True
        '
        'colNombres
        '
        Me.colNombres.AllowEdit = False
        Me.colNombres.CellStyles.Default.TextColor = System.Drawing.SystemColors.GrayText
        Background1.Color1 = System.Drawing.SystemColors.Highlight
        Me.colNombres.CellStyles.Selected.Background = Background1
        Me.colNombres.CellStyles.Selected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colNombres.CellStyles.Selected.TextColor = System.Drawing.SystemColors.HighlightText
        Me.colNombres.DataPropertyName = "nombres"
        Me.colNombres.HeaderText = "NOMBRE"
        Me.colNombres.Name = "colNombres"
        Me.colNombres.ReadOnly = True
        Me.colNombres.Width = 200
        '
        'colCodCC
        '
        Me.colCodCC.AllowEdit = False
        Me.colCodCC.DataPropertyName = "centro_costos"
        Me.colCodCC.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colCodCC.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None
        Me.colCodCC.HeaderText = "C.C."
        Me.colCodCC.Name = "colCodCC"
        Me.colCodCC.ReadOnly = True
        Me.colCodCC.Width = 50
        '
        'colCodTurno
        '
        Me.colCodTurno.AllowEdit = False
        Me.colCodTurno.CellStyles.Default.TextColor = System.Drawing.SystemColors.GrayText
        Background2.Color1 = System.Drawing.SystemColors.Highlight
        Me.colCodTurno.CellStyles.Selected.Background = Background2
        Me.colCodTurno.CellStyles.Selected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colCodTurno.CellStyles.Selected.TextColor = System.Drawing.SystemColors.HighlightText
        Me.colCodTurno.DataPropertyName = "cod_turno"
        Me.colCodTurno.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colCodTurno.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None
        Me.colCodTurno.HeaderText = "TURNO"
        Me.colCodTurno.Name = "colCodTurno"
        Me.colCodTurno.ReadOnly = True
        Me.colCodTurno.Width = 50
        '
        'colCodDepto
        '
        Me.colCodDepto.AllowEdit = False
        Me.colCodDepto.CellStyles.Default.TextColor = System.Drawing.SystemColors.GrayText
        Background3.Color1 = System.Drawing.SystemColors.Highlight
        Me.colCodDepto.CellStyles.Selected.Background = Background3
        Me.colCodDepto.CellStyles.Selected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colCodDepto.CellStyles.Selected.TextColor = System.Drawing.SystemColors.HighlightText
        Me.colCodDepto.DataPropertyName = "cod_depto"
        Me.colCodDepto.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colCodDepto.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None
        Me.colCodDepto.HeaderText = "DEPTO."
        Me.colCodDepto.Name = "colCodDepto"
        Me.colCodDepto.ReadOnly = True
        Me.colCodDepto.Width = 50
        '
        'colCodSuper
        '
        Me.colCodSuper.AllowEdit = False
        Me.colCodSuper.DataPropertyName = "cod_super"
        Me.colCodSuper.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colCodSuper.FilterEditType = DevComponents.DotNetBar.SuperGrid.FilterEditType.None
        Me.colCodSuper.HeaderText = "SUPER."
        Me.colCodSuper.Name = "colCodSuper"
        Me.colCodSuper.ReadOnly = True
        Me.colCodSuper.Width = 50
        '
        'colHrsNormales
        '
        Me.colHrsNormales.AllowEdit = False
        Me.colHrsNormales.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
        Padding1.Right = 10
        Me.colHrsNormales.CellStyles.Default.Padding = Padding1
        Me.colHrsNormales.CellStyles.Default.TextColor = System.Drawing.SystemColors.GrayText
        Me.colHrsNormales.CellStyles.Selected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colHrsNormales.DataPropertyName = "HORAS_NORMALES"
        Me.colHrsNormales.HeaderText = "HRS.NOR."
        Me.colHrsNormales.Name = "colHrsNormales"
        Me.colHrsNormales.ReadOnly = True
        Me.colHrsNormales.Width = 75
        '
        'colHrsExtras
        '
        Me.colHrsExtras.AllowEdit = False
        Me.colHrsExtras.CellStyles.Default.TextColor = System.Drawing.SystemColors.GrayText
        Me.colHrsExtras.CellStyles.Selected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colHrsExtras.DataPropertyName = "HORAS_EXTRAS"
        Me.colHrsExtras.HeaderText = "HRS.EXT."
        Me.colHrsExtras.Name = "colHrsExtras"
        Me.colHrsExtras.ReadOnly = True
        Me.colHrsExtras.Width = 75
        '
        'GridColumn6
        '
        Me.GridColumn6.AllowEdit = False
        Me.GridColumn6.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
        Background4.Color1 = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GridColumn6.CellStyles.Default.Background = Background4
        Me.GridColumn6.CellStyles.Default.Padding = Padding1
        Me.GridColumn6.CellStyles.Default.TextColor = System.Drawing.SystemColors.ControlText
        Me.GridColumn6.CellStyles.ReadOnly.TextColor = System.Drawing.Color.Purple
        Background5.Color1 = System.Drawing.SystemColors.Highlight
        Me.GridColumn6.CellStyles.Selected.Background = Background5
        Me.GridColumn6.CellStyles.Selected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn6.CellStyles.Selected.TextColor = System.Drawing.SystemColors.HighlightText
        Me.GridColumn6.DataPropertyName = "diferencia"
        Me.GridColumn6.HeaderText = "DIFERENCIA"
        Me.GridColumn6.Name = "colDiferencia"
        Me.GridColumn6.ReadOnly = True
        Me.GridColumn6.Width = 75
        '
        'GridColumn7
        '
        Me.GridColumn7.AllowEdit = False
        Me.GridColumn7.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
        Background6.Color1 = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GridColumn7.CellStyles.Default.Background = Background6
        Padding2.Right = 10
        Me.GridColumn7.CellStyles.Default.Padding = Padding2
        Me.GridColumn7.CellStyles.Default.TextColor = System.Drawing.SystemColors.ControlText
        Me.GridColumn7.CellStyles.ReadOnly.TextColor = System.Drawing.SystemColors.ControlDarkDark
        Background7.Color1 = System.Drawing.SystemColors.Highlight
        Me.GridColumn7.CellStyles.Selected.Background = Background7
        Me.GridColumn7.CellStyles.Selected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn7.CellStyles.Selected.TextColor = System.Drawing.SystemColors.HighlightText
        Me.GridColumn7.DataPropertyName = "total"
        Me.GridColumn7.HeaderText = "TOTAL HRS."
        Me.GridColumn7.Name = "colTotalHrs"
        Me.GridColumn7.ReadOnly = True
        Me.GridColumn7.Width = 75
        '
        'GridColumn2
        '
        Me.GridColumn2.DataPropertyName = "cod_depto"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.Text = "Column"
        Me.ColumnHeader5.Width.Absolute = 150
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Name = "ColumnHeader6"
        Me.ColumnHeader6.Text = "Column"
        Me.ColumnHeader6.Width.Absolute = 150
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Name = "ColumnHeader7"
        Me.ColumnHeader7.Text = "Column"
        Me.ColumnHeader7.Width.Absolute = 150
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Name = "ColumnHeader8"
        Me.ColumnHeader8.Text = "Column"
        Me.ColumnHeader8.Width.Absolute = 150
        '
        'GridColumn3
        '
        Me.GridColumn3.DataPropertyName = "cod_depto"
        Me.GridColumn3.DefaultNewRowCellValue = ""
        '
        'lblTip
        '
        Me.lblTip.AutoSize = True
        Me.lblTip.BackColor = System.Drawing.SystemColors.HotTrack
        Me.lblTip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTip.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTip.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblTip.Location = New System.Drawing.Point(920, 80)
        Me.lblTip.Name = "lblTip"
        Me.lblTip.Padding = New System.Windows.Forms.Padding(10)
        Me.lblTip.Size = New System.Drawing.Size(51, 39)
        Me.lblTip.TabIndex = 0
        Me.lblTip.Text = "TIP"
        Me.lblTip.Visible = False
        '
        'gpAvance
        '
        Me.gpAvance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.gpAvance.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpAvance.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpAvance.Controls.Add(Me.lblAvance)
        Me.gpAvance.Controls.Add(Me.pbAvance)
        Me.gpAvance.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpAvance.Location = New System.Drawing.Point(463, 136)
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
        Me.gpAvance.TabIndex = 5
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
        Me.lblAvance.TabIndex = 1
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
        Me.pbAvance.TabIndex = 0
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Column"
        Me.ColumnHeader1.Width.Absolute = 150
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Column"
        Me.ColumnHeader2.Width.Absolute = 150
        '
        'NodeConnector1
        '
        Me.NodeConnector1.LineColor = System.Drawing.SystemColors.ControlText
        '
        'spltGrupos
        '
        Me.spltGrupos.BackColor = System.Drawing.SystemColors.ControlLight
        Me.spltGrupos.BackColor2 = System.Drawing.Color.Empty
        Me.spltGrupos.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.spltGrupos.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.spltGrupos.Expandable = False
        Me.spltGrupos.ExpandableControl = Me.dgPersonal
        Me.spltGrupos.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.spltGrupos.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
        Me.spltGrupos.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.spltGrupos.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder
        Me.spltGrupos.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.spltGrupos.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder
        Me.spltGrupos.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.spltGrupos.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground
        Me.spltGrupos.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(140, Byte), Integer))
        Me.spltGrupos.HotBackColor2 = System.Drawing.Color.Empty
        Me.spltGrupos.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.None
        Me.spltGrupos.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemCheckedBackground
        Me.spltGrupos.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.spltGrupos.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
        Me.spltGrupos.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.spltGrupos.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder
        Me.spltGrupos.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.spltGrupos.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBorder
        Me.spltGrupos.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.spltGrupos.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.MenuBackground
        Me.spltGrupos.Location = New System.Drawing.Point(300, 77)
        Me.spltGrupos.Name = "spltGrupos"
        Me.spltGrupos.Size = New System.Drawing.Size(17, 438)
        Me.spltGrupos.Style = DevComponents.DotNetBar.eSplitterStyle.Mozilla
        Me.spltGrupos.TabIndex = 0
        Me.spltGrupos.TabStop = False
        '
        'treGrupos
        '
        Me.treGrupos.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.treGrupos.AllowDrop = True
        Me.treGrupos.AllowUserToResizeColumns = False
        Me.treGrupos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.treGrupos.BackgroundStyle.Class = "TreeBorderKey"
        Me.treGrupos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.treGrupos.Dock = System.Windows.Forms.DockStyle.Left
        Me.treGrupos.ExpandBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.treGrupos.ExpandButtonType = DevComponents.AdvTree.eExpandButtonType.Triangle
        Me.treGrupos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.treGrupos.Location = New System.Drawing.Point(0, 77)
        Me.treGrupos.Name = "treGrupos"
        Me.treGrupos.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node1, Me.Node2, Me.Node3, Me.Node14, Me.Node15})
        Me.treGrupos.NodeSpacing = 5
        Me.treGrupos.NodeStyleSelected = Me.EstiloSeleccionado
        Me.treGrupos.PathSeparator = ";"
        Me.treGrupos.SelectionBox = False
        Me.treGrupos.Size = New System.Drawing.Size(300, 438)
        Me.treGrupos.Styles.Add(Me.EstiloSupervisor)
        Me.treGrupos.Styles.Add(Me.EstiloDepartamento)
        Me.treGrupos.Styles.Add(Me.EstiloTurno)
        Me.treGrupos.Styles.Add(Me.EstiloDiferenciaPositiva)
        Me.treGrupos.Styles.Add(Me.EstiloDiferencia0)
        Me.treGrupos.Styles.Add(Me.EstiloDiferenciaNegativa)
        Me.treGrupos.Styles.Add(Me.EstiloRegular)
        Me.treGrupos.Styles.Add(Me.EstiloSeleccionado)
        Me.treGrupos.Styles.Add(Me.EstiloMouseOver)
        Me.treGrupos.Styles.Add(Me.ElementStyle2)
        Me.treGrupos.Styles.Add(Me.ElementStyle3)
        Me.treGrupos.Styles.Add(Me.ElementStyle1)
        Me.treGrupos.Styles.Add(Me.EstiloTotal)
        Me.treGrupos.Styles.Add(Me.ElementStyle4)
        Me.treGrupos.Styles.Add(Me.EstiloRegularDerecha)
        Me.treGrupos.TabIndex = 2
        '
        'Node1
        '
        Me.Node1.Expanded = True
        Me.Node1.FullRowBackground = True
        Me.Node1.Name = "Node1"
        Me.Node1.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node16, Me.Node9, Me.Node19})
        Me.Node1.Style = Me.EstiloSupervisor
        Me.Node1.StyleMouseOver = Me.EstiloMouseOver
        Me.Node1.StyleSelected = Me.EstiloSeleccionado
        Me.Node1.Text = "SUPERVISOR"
        '
        'Node16
        '
        Me.Node16.Cells.Add(Me.Cell8)
        Me.Node16.Expanded = True
        Me.Node16.FullRowBackground = True
        Me.Node16.Name = "Node16"
        Me.Node16.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node17, Me.Node18})
        Me.Node16.NodesColumns.Add(Me.ColumnHeader15)
        Me.Node16.NodesColumns.Add(Me.ColumnHeader16)
        Me.Node16.Selectable = False
        Me.Node16.Style = Me.EstiloTotal
        Me.Node16.Text = "TOTALES"
        '
        'Cell8
        '
        Me.Cell8.Name = "Cell8"
        Me.Cell8.StyleMouseOver = Nothing
        Me.Cell8.StyleNormal = Me.EstiloRegularDerecha
        Me.Cell8.Text = "99:00"
        '
        'EstiloRegularDerecha
        '
        Me.EstiloRegularDerecha.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.EstiloRegularDerecha.Name = "EstiloRegularDerecha"
        Me.EstiloRegularDerecha.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Far
        '
        'Node17
        '
        Me.Node17.Cells.Add(Me.Cell6)
        Me.Node17.Expanded = True
        Me.Node17.Name = "Node17"
        Me.Node17.Style = Me.ElementStyle1
        Me.Node17.Text = "Node17"
        '
        'Cell6
        '
        Me.Cell6.Name = "Cell6"
        Me.Cell6.StyleMouseOver = Nothing
        '
        'ElementStyle1
        '
        Me.ElementStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ElementStyle1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(155, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(183, Byte), Integer))
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
        Me.ElementStyle1.Description = "SilverMist"
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.PaddingBottom = 1
        Me.ElementStyle1.PaddingLeft = 1
        Me.ElementStyle1.PaddingRight = 1
        Me.ElementStyle1.PaddingTop = 1
        Me.ElementStyle1.TextColor = System.Drawing.Color.FromArgb(CType(CType(87, Byte), Integer), CType(CType(86, Byte), Integer), CType(CType(113, Byte), Integer))
        '
        'Node18
        '
        Me.Node18.Cells.Add(Me.Cell7)
        Me.Node18.Expanded = True
        Me.Node18.Name = "Node18"
        Me.Node18.Style = Me.ElementStyle1
        Me.Node18.Text = "Node18"
        '
        'Cell7
        '
        Me.Cell7.Name = "Cell7"
        Me.Cell7.StyleMouseOver = Nothing
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Name = "ColumnHeader15"
        Me.ColumnHeader15.Text = "Column"
        Me.ColumnHeader15.Width.Absolute = 150
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Name = "ColumnHeader16"
        Me.ColumnHeader16.Text = "Column"
        Me.ColumnHeader16.Width.Absolute = 150
        '
        'EstiloTotal
        '
        Me.EstiloTotal.BackColor = System.Drawing.Color.Teal
        Me.EstiloTotal.BackColorGradientAngle = 90
        Me.EstiloTotal.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.EstiloTotal.BorderBottomWidth = 1
        Me.EstiloTotal.BorderColor = System.Drawing.Color.DarkGray
        Me.EstiloTotal.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.EstiloTotal.BorderLeftWidth = 1
        Me.EstiloTotal.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.EstiloTotal.BorderRightWidth = 1
        Me.EstiloTotal.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.EstiloTotal.BorderTopWidth = 1
        Me.EstiloTotal.CornerDiameter = 4
        Me.EstiloTotal.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.EstiloTotal.Description = "Total"
        Me.EstiloTotal.Name = "EstiloTotal"
        Me.EstiloTotal.PaddingBottom = 1
        Me.EstiloTotal.PaddingLeft = 1
        Me.EstiloTotal.PaddingRight = 1
        Me.EstiloTotal.PaddingTop = 1
        Me.EstiloTotal.TextColor = System.Drawing.Color.White
        '
        'Node9
        '
        Me.Node9.Expanded = True
        Me.Node9.FullRowBackground = True
        Me.Node9.Name = "Node9"
        Me.Node9.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node4, Me.Node10})
        Me.Node9.NodesColumns.Add(Me.ColumnHeader13)
        Me.Node9.NodesColumns.Add(Me.ColumnHeader14)
        Me.Node9.Style = Me.EstiloDepartamento
        Me.Node9.StyleSelected = Me.EstiloSeleccionado
        Me.Node9.Text = "DEPARTAMENTO" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DEPTO"
        '
        'Node4
        '
        Me.Node4.Expanded = True
        Me.Node4.FullRowBackground = True
        Me.Node4.Name = "Node4"
        Me.Node4.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node6, Me.Node8, Me.Node12, Me.Node11})
        Me.Node4.NodesColumns.Add(Me.ColumnHeader3)
        Me.Node4.NodesColumns.Add(Me.ColumnHeader4)
        Me.Node4.Style = Me.EstiloTurno
        Me.Node4.StyleSelected = Me.EstiloSeleccionado
        Me.Node4.Text = "TURNO 1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "NOMBRE SUPERVISOR"
        '
        'Node6
        '
        Me.Node6.CellPartLayout = DevComponents.AdvTree.eCellPartLayout.Horizontal
        Me.Node6.Cells.Add(Me.Cell1)
        Me.Node6.Expanded = True
        Me.Node6.Name = "Node6"
        Me.Node6.Style = Me.EstiloRegular
        Me.Node6.Text = "HORAS NORMALES"
        '
        'Cell1
        '
        Me.Cell1.Name = "Cell1"
        Me.Cell1.StyleMouseOver = Nothing
        Me.Cell1.Text = "10"
        '
        'EstiloRegular
        '
        Me.EstiloRegular.BackColor = System.Drawing.SystemColors.Window
        Me.EstiloRegular.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.EstiloRegular.Name = "EstiloRegular"
        Me.EstiloRegular.TextColor = System.Drawing.SystemColors.ControlText
        '
        'Node8
        '
        Me.Node8.Cells.Add(Me.Cell2)
        Me.Node8.Expanded = True
        Me.Node8.Name = "Node8"
        Me.Node8.Style = Me.EstiloRegularDerecha
        Me.Node8.Text = "HORAS EXTRAS"
        '
        'Cell2
        '
        Me.Cell2.Name = "Cell2"
        Me.Cell2.StyleMouseOver = Nothing
        Me.Cell2.StyleNormal = Me.EstiloRegularDerecha
        Me.Cell2.Text = "5:00"
        '
        'Node12
        '
        Me.Node12.Cells.Add(Me.Cell4)
        Me.Node12.Name = "Node12"
        Me.Node12.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node13})
        Me.Node12.NodesColumns.Add(Me.ColumnHeader11)
        Me.Node12.NodesColumns.Add(Me.ColumnHeader12)
        Me.Node12.NodesColumnsHeaderVisible = False
        Me.Node12.Style = Me.EstiloRegular
        Me.Node12.Text = "ORDENES"
        '
        'Cell4
        '
        Me.Cell4.Name = "Cell4"
        Me.Cell4.StyleMouseOver = Nothing
        Me.Cell4.Text = "25"
        '
        'Node13
        '
        Me.Node13.Cells.Add(Me.Cell3)
        Me.Node13.Expanded = True
        Me.Node13.Name = "Node13"
        Me.Node13.Text = "000888888"
        '
        'Cell3
        '
        Me.Cell3.Name = "Cell3"
        Me.Cell3.StyleMouseOver = Nothing
        Me.Cell3.Text = "10"
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Name = "ColumnHeader11"
        Me.ColumnHeader11.StretchToFill = True
        Me.ColumnHeader11.Text = "Column"
        Me.ColumnHeader11.Width.Absolute = 100
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.Name = "ColumnHeader12"
        Me.ColumnHeader12.Text = "Column"
        Me.ColumnHeader12.Width.Absolute = 50
        '
        'Node11
        '
        Me.Node11.Cells.Add(Me.Cell5)
        Me.Node11.Expanded = True
        Me.Node11.Name = "Node11"
        Me.Node11.Style = Me.EstiloDiferenciaPositiva
        Me.Node11.Text = "DIFERENCIA"
        '
        'Cell5
        '
        Me.Cell5.Name = "Cell5"
        Me.Cell5.StyleMouseOver = Nothing
        Me.Cell5.Text = "-10"
        '
        'EstiloDiferenciaPositiva
        '
        Me.EstiloDiferenciaPositiva.BackColor = System.Drawing.Color.White
        Me.EstiloDiferenciaPositiva.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.EstiloDiferenciaPositiva.BorderBottomWidth = 1
        Me.EstiloDiferenciaPositiva.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.EstiloDiferenciaPositiva.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.EstiloDiferenciaPositiva.BorderTopWidth = 1
        Me.EstiloDiferenciaPositiva.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.EstiloDiferenciaPositiva.Name = "EstiloDiferenciaPositiva"
        Me.EstiloDiferenciaPositiva.PaddingBottom = 2
        Me.EstiloDiferenciaPositiva.PaddingTop = 1
        Me.EstiloDiferenciaPositiva.TextColor = System.Drawing.Color.Black
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.StretchToFill = True
        Me.ColumnHeader3.Text = "DISTRIBUCION"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "HORAS"
        Me.ColumnHeader4.Width.Absolute = 50
        '
        'EstiloTurno
        '
        Me.EstiloTurno.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.EstiloTurno.BorderBottomColor = System.Drawing.SystemColors.MenuHighlight
        Me.EstiloTurno.BorderBottomWidth = 2
        Me.EstiloTurno.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.EstiloTurno.Name = "EstiloTurno"
        Me.EstiloTurno.TextColor = System.Drawing.Color.SteelBlue
        '
        'EstiloSeleccionado
        '
        Me.EstiloSeleccionado.BackColor = System.Drawing.Color.RoyalBlue
        Me.EstiloSeleccionado.BackgroundImage = Global.PIDA.My.Resources.Resources.GreenMarker16
        Me.EstiloSeleccionado.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.BottomLeft
        Me.EstiloSeleccionado.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.EstiloSeleccionado.BorderBottomWidth = 2
        Me.EstiloSeleccionado.BorderColor = System.Drawing.Color.DarkBlue
        Me.EstiloSeleccionado.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.EstiloSeleccionado.BorderLeftWidth = 2
        Me.EstiloSeleccionado.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.EstiloSeleccionado.BorderRightWidth = 2
        Me.EstiloSeleccionado.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.EstiloSeleccionado.BorderTopWidth = 2
        Me.EstiloSeleccionado.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.EstiloSeleccionado.MarginBottom = -1
        Me.EstiloSeleccionado.MarginTop = -1
        Me.EstiloSeleccionado.Name = "EstiloSeleccionado"
        Me.EstiloSeleccionado.PaddingBottom = 2
        Me.EstiloSeleccionado.PaddingLeft = 2
        Me.EstiloSeleccionado.PaddingRight = 2
        Me.EstiloSeleccionado.PaddingTop = 2
        Me.EstiloSeleccionado.TextColor = System.Drawing.Color.White
        '
        'Node10
        '
        Me.Node10.Expanded = True
        Me.Node10.Name = "Node10"
        Me.Node10.NodesColumns.Add(Me.ColumnHeader9)
        Me.Node10.NodesColumns.Add(Me.ColumnHeader10)
        Me.Node10.NodesColumnsHeaderVisible = False
        Me.Node10.Style = Me.EstiloTurno
        Me.Node10.Text = "TURNO 2"
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Name = "ColumnHeader9"
        Me.ColumnHeader9.StretchToFill = True
        Me.ColumnHeader9.Text = "DISTRIBUCION"
        Me.ColumnHeader9.Width.Absolute = 100
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Name = "ColumnHeader10"
        Me.ColumnHeader10.Text = "HORAS"
        Me.ColumnHeader10.Width.Absolute = 50
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.Name = "ColumnHeader13"
        Me.ColumnHeader13.Text = "Column"
        Me.ColumnHeader13.Width.Absolute = 150
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Name = "ColumnHeader14"
        Me.ColumnHeader14.Text = "Column"
        Me.ColumnHeader14.Width.Absolute = 150
        '
        'EstiloDepartamento
        '
        Me.EstiloDepartamento.BackColor = System.Drawing.Color.LightSteelBlue
        Me.EstiloDepartamento.BackColorGradientAngle = 90
        Me.EstiloDepartamento.BorderBottomWidth = 1
        Me.EstiloDepartamento.BorderLeftWidth = 1
        Me.EstiloDepartamento.BorderRightWidth = 1
        Me.EstiloDepartamento.BorderTopWidth = 1
        Me.EstiloDepartamento.CornerDiameter = 4
        Me.EstiloDepartamento.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.EstiloDepartamento.Description = "Depto"
        Me.EstiloDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstiloDepartamento.Name = "EstiloDepartamento"
        Me.EstiloDepartamento.PaddingBottom = 1
        Me.EstiloDepartamento.PaddingLeft = 1
        Me.EstiloDepartamento.PaddingRight = 1
        Me.EstiloDepartamento.PaddingTop = 1
        Me.EstiloDepartamento.TextColor = System.Drawing.Color.MidnightBlue
        '
        'Node19
        '
        Me.Node19.Expanded = True
        Me.Node19.FullRowBackground = True
        Me.Node19.Name = "Node19"
        Me.Node19.Style = Me.EstiloDepartamento
        Me.Node19.Text = "Node19"
        '
        'EstiloSupervisor
        '
        Me.EstiloSupervisor.BackColor = System.Drawing.Color.White
        Me.EstiloSupervisor.BackColorGradientAngle = 90
        Me.EstiloSupervisor.BorderLeftWidth = 1
        Me.EstiloSupervisor.BorderRightWidth = 1
        Me.EstiloSupervisor.BorderTopWidth = 1
        Me.EstiloSupervisor.CornerDiameter = 4
        Me.EstiloSupervisor.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.EstiloSupervisor.Description = "Supervisor"
        Me.EstiloSupervisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EstiloSupervisor.Name = "EstiloSupervisor"
        Me.EstiloSupervisor.PaddingBottom = 1
        Me.EstiloSupervisor.PaddingLeft = 1
        Me.EstiloSupervisor.PaddingRight = 1
        Me.EstiloSupervisor.PaddingTop = 1
        Me.EstiloSupervisor.TextColor = System.Drawing.Color.Black
        '
        'EstiloMouseOver
        '
        Me.EstiloMouseOver.BackColor = System.Drawing.Color.DarkSlateGray
        Me.EstiloMouseOver.BackColor2 = System.Drawing.Color.DarkSlateGray
        Me.EstiloMouseOver.BackColorGradientAngle = 90
        Me.EstiloMouseOver.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.EstiloMouseOver.BorderBottomWidth = 1
        Me.EstiloMouseOver.BorderColor = System.Drawing.Color.DarkGray
        Me.EstiloMouseOver.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.EstiloMouseOver.BorderLeftWidth = 1
        Me.EstiloMouseOver.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.EstiloMouseOver.BorderRightWidth = 1
        Me.EstiloMouseOver.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.EstiloMouseOver.BorderTopWidth = 1
        Me.EstiloMouseOver.CornerDiameter = 4
        Me.EstiloMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.EstiloMouseOver.Description = "Apple"
        Me.EstiloMouseOver.Name = "EstiloMouseOver"
        Me.EstiloMouseOver.PaddingBottom = 1
        Me.EstiloMouseOver.PaddingLeft = 1
        Me.EstiloMouseOver.PaddingRight = 1
        Me.EstiloMouseOver.PaddingTop = 1
        Me.EstiloMouseOver.TextColor = System.Drawing.Color.White
        '
        'Node2
        '
        Me.Node2.FullRowBackground = True
        Me.Node2.Name = "Node2"
        Me.Node2.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node5, Me.Node7})
        Me.Node2.Style = Me.EstiloSupervisor
        Me.Node2.Text = "SUPERVISOR"
        '
        'Node5
        '
        Me.Node5.Expanded = True
        Me.Node5.Name = "Node5"
        Me.Node5.Style = Me.EstiloDepartamento
        Me.Node5.Text = "DEPARTAMENTO"
        '
        'Node7
        '
        Me.Node7.Expanded = True
        Me.Node7.Name = "Node7"
        Me.Node7.Style = Me.EstiloTurno
        Me.Node7.Text = "TURNO"
        '
        'Node3
        '
        Me.Node3.Expanded = True
        Me.Node3.Name = "Node3"
        Me.Node3.Style = Me.EstiloSupervisor
        Me.Node3.Text = "Node3"
        '
        'Node14
        '
        Me.Node14.Expanded = True
        Me.Node14.Name = "Node14"
        Me.Node14.Style = Me.EstiloSupervisor
        Me.Node14.Text = "Node14"
        '
        'Node15
        '
        Me.Node15.Expanded = True
        Me.Node15.Name = "Node15"
        Me.Node15.Style = Me.EstiloSupervisor
        Me.Node15.Text = "Node15"
        '
        'EstiloDiferencia0
        '
        Me.EstiloDiferencia0.BackColor = System.Drawing.Color.Green
        Me.EstiloDiferencia0.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.EstiloDiferencia0.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.EstiloDiferencia0.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.EstiloDiferencia0.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarCaptionInactiveText
        Me.EstiloDiferencia0.BorderTopWidth = 1
        Me.EstiloDiferencia0.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.EstiloDiferencia0.Name = "EstiloDiferencia0"
        Me.EstiloDiferencia0.PaddingBottom = 2
        Me.EstiloDiferencia0.PaddingTop = 1
        Me.EstiloDiferencia0.TextColor = System.Drawing.Color.White
        '
        'EstiloDiferenciaNegativa
        '
        Me.EstiloDiferenciaNegativa.BackColor = System.Drawing.Color.Red
        Me.EstiloDiferenciaNegativa.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.EstiloDiferenciaNegativa.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.EstiloDiferenciaNegativa.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.EstiloDiferenciaNegativa.BorderTopWidth = 1
        Me.EstiloDiferenciaNegativa.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.EstiloDiferenciaNegativa.Name = "EstiloDiferenciaNegativa"
        Me.EstiloDiferenciaNegativa.PaddingBottom = 2
        Me.EstiloDiferenciaNegativa.PaddingTop = 1
        Me.EstiloDiferenciaNegativa.TextColor = System.Drawing.Color.White
        '
        'ElementStyle2
        '
        Me.ElementStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(243, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.ElementStyle2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.ElementStyle2.BackColorGradientAngle = 90
        Me.ElementStyle2.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderBottomWidth = 1
        Me.ElementStyle2.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle2.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderLeftWidth = 1
        Me.ElementStyle2.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderRightWidth = 1
        Me.ElementStyle2.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderTopWidth = 1
        Me.ElementStyle2.CornerDiameter = 4
        Me.ElementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle2.Description = "Magenta"
        Me.ElementStyle2.Name = "ElementStyle2"
        Me.ElementStyle2.PaddingBottom = 1
        Me.ElementStyle2.PaddingLeft = 1
        Me.ElementStyle2.PaddingRight = 1
        Me.ElementStyle2.PaddingTop = 1
        Me.ElementStyle2.TextColor = System.Drawing.Color.Black
        '
        'ElementStyle3
        '
        Me.ElementStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.ElementStyle3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.ElementStyle3.BackColorGradientAngle = 90
        Me.ElementStyle3.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle3.BorderBottomWidth = 1
        Me.ElementStyle3.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle3.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle3.BorderLeftWidth = 1
        Me.ElementStyle3.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle3.BorderRightWidth = 1
        Me.ElementStyle3.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle3.BorderTopWidth = 1
        Me.ElementStyle3.CornerDiameter = 4
        Me.ElementStyle3.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle3.Description = "Lemon"
        Me.ElementStyle3.Name = "ElementStyle3"
        Me.ElementStyle3.PaddingBottom = 1
        Me.ElementStyle3.PaddingLeft = 1
        Me.ElementStyle3.PaddingRight = 1
        Me.ElementStyle3.PaddingTop = 1
        Me.ElementStyle3.TextColor = System.Drawing.Color.Black
        '
        'ElementStyle4
        '
        Me.ElementStyle4.BackColor = System.Drawing.Color.White
        Me.ElementStyle4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(228, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.ElementStyle4.BackColorGradientAngle = 90
        Me.ElementStyle4.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle4.BorderBottomWidth = 1
        Me.ElementStyle4.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle4.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle4.BorderLeftWidth = 1
        Me.ElementStyle4.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle4.BorderRightWidth = 1
        Me.ElementStyle4.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle4.BorderTopWidth = 1
        Me.ElementStyle4.CornerDiameter = 4
        Me.ElementStyle4.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle4.Description = "Gray"
        Me.ElementStyle4.Name = "ElementStyle4"
        Me.ElementStyle4.PaddingBottom = 1
        Me.ElementStyle4.PaddingLeft = 1
        Me.ElementStyle4.PaddingRight = 1
        Me.ElementStyle4.PaddingTop = 1
        Me.ElementStyle4.TextColor = System.Drawing.Color.Black
        '
        'SuperTooltip1
        '
        Me.SuperTooltip1.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray)
        Me.SuperTooltip1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'frmTimeAllocation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1136, 563)
        Me.Controls.Add(Me.gpAvance)
        Me.Controls.Add(Me.lblTip)
        Me.Controls.Add(Me.spltGrupos)
        Me.Controls.Add(Me.dgPersonal)
        Me.Controls.Add(Me.treGrupos)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTimeAllocation"
        Me.Text = "Time Allocation"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlParametros.ResumeLayout(False)
        Me.pnlFecha.ResumeLayout(False)
        Me.pnlFecha.PerformLayout()
        CType(Me.picFestivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTiempo.ResumeLayout(False)
        Me.pnlTiempo.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.pnlCentrarControles.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.gpAvance.ResumeLayout(False)
        CType(Me.treGrupos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlFecha As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents btnMostrarInformacion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgPersonal As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents txtFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents colNombres As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn2 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader6 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader7 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader8 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents GridColumn3 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents colCodDepto As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents colCodTurno As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn6 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents lblTip As System.Windows.Forms.Label
    Friend WithEvents GridColumn7 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents pnlCentrarControles As System.Windows.Forms.Panel
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAgregarOrden As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AgregarOrdenDeTrabajoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CerrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlTiempo As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CopiarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bgCargaFecha As System.ComponentModel.BackgroundWorker
    Friend WithEvents gpAvance As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lblAvance As System.Windows.Forms.Label
    Friend WithEvents pbAvance As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents txtHoras As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents AsignarHorasEmpleadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AsignarHorasOrdenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colReloj As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents colHrsNormales As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents colHrsExtras As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents treGrupos As DevComponents.AdvTree.AdvTree
    Friend WithEvents Node1 As DevComponents.AdvTree.Node
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents Node4 As DevComponents.AdvTree.Node
    Friend WithEvents Node2 As DevComponents.AdvTree.Node
    Friend WithEvents Node5 As DevComponents.AdvTree.Node
    Friend WithEvents Node7 As DevComponents.AdvTree.Node
    Friend WithEvents Node3 As DevComponents.AdvTree.Node
    Friend WithEvents Node6 As DevComponents.AdvTree.Node
    Friend WithEvents Cell1 As DevComponents.AdvTree.Cell
    Friend WithEvents Node8 As DevComponents.AdvTree.Node
    Friend WithEvents Cell2 As DevComponents.AdvTree.Cell
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents EstiloSupervisor As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents Node9 As DevComponents.AdvTree.Node
    Friend WithEvents Node12 As DevComponents.AdvTree.Node
    Friend WithEvents Cell4 As DevComponents.AdvTree.Cell
    Friend WithEvents Node13 As DevComponents.AdvTree.Node
    Friend WithEvents Cell3 As DevComponents.AdvTree.Cell
    Friend WithEvents ColumnHeader11 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader12 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Node11 As DevComponents.AdvTree.Node
    Friend WithEvents Cell5 As DevComponents.AdvTree.Cell
    Friend WithEvents Node10 As DevComponents.AdvTree.Node
    Friend WithEvents ColumnHeader9 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader10 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents EstiloTurno As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents EstiloDepartamento As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents spltGrupos As DevComponents.DotNetBar.ExpandableSplitter
    Friend WithEvents Node14 As DevComponents.AdvTree.Node
    Friend WithEvents Node15 As DevComponents.AdvTree.Node
    Friend WithEvents EstiloDiferenciaPositiva As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents EstiloDiferencia0 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents EstiloDiferenciaNegativa As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents EstiloRegular As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ColumnHeader13 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader14 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colCodCC As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents EstiloMouseOver As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle3 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle2 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents EstiloSeleccionado As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents BorrarOrdenDeTrabajoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Node16 As DevComponents.AdvTree.Node
    Friend WithEvents Node17 As DevComponents.AdvTree.Node
    Friend WithEvents Cell6 As DevComponents.AdvTree.Cell
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents Node18 As DevComponents.AdvTree.Node
    Friend WithEvents Cell7 As DevComponents.AdvTree.Cell
    Friend WithEvents ColumnHeader15 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader16 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents EstiloTotal As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents Node19 As DevComponents.AdvTree.Node
    Friend WithEvents Cell8 As DevComponents.AdvTree.Cell
    Friend WithEvents EstiloRegularDerecha As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle4 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents picFestivo As System.Windows.Forms.PictureBox
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents pnlParametros As System.Windows.Forms.Panel
    Friend WithEvents lblUltActualizacion As DevComponents.DotNetBar.LabelX
    Friend WithEvents colCodSuper As DevComponents.DotNetBar.SuperGrid.GridColumn
End Class
