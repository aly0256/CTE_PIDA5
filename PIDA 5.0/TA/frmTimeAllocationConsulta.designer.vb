<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTimeAllocationConsulta
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
        Dim Background10 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background11 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background1 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background2 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background3 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Padding1 As DevComponents.DotNetBar.SuperGrid.Style.Padding = New DevComponents.DotNetBar.SuperGrid.Style.Padding()
        Dim Background4 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Padding2 As DevComponents.DotNetBar.SuperGrid.Style.Padding = New DevComponents.DotNetBar.SuperGrid.Style.Padding()
        Dim Background5 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background6 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Padding3 As DevComponents.DotNetBar.SuperGrid.Style.Padding = New DevComponents.DotNetBar.SuperGrid.Style.Padding()
        Dim Background7 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Background8 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim Padding4 As DevComponents.DotNetBar.SuperGrid.Style.Padding = New DevComponents.DotNetBar.SuperGrid.Style.Padding()
        Dim Background9 As DevComponents.DotNetBar.SuperGrid.Style.Background = New DevComponents.DotNetBar.SuperGrid.Style.Background()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTimeAllocationConsulta))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.pnlParametros = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnMostrarInformacion = New DevComponents.DotNetBar.ButtonX()
        Me.lblUltActualizacion = New DevComponents.DotNetBar.LabelX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlCentrarControles = New System.Windows.Forms.Panel()
        Me.btnArchivoSAP = New DevComponents.DotNetBar.ButtonX()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.dgPersonal = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopiarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.colReloj = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colNombres = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colComp = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colCodSuper = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colCodDepto = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colCodTurno = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colHrsNor = New DevComponents.DotNetBar.SuperGrid.GridColumn()
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
        Me.gpAvance = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.lblAvance = New System.Windows.Forms.Label()
        Me.pbAvance = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlParametros.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlCentrarControles.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.gpAvance.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Controls.Add(Me.pnlParametros)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Padding = New System.Windows.Forms.Padding(3, 3, 3, 10)
        Me.pnlEncabezado.Size = New System.Drawing.Size(974, 77)
        Me.pnlEncabezado.TabIndex = 1
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.ReflectionLabel1)
        Me.pnlTitulo.Controls.Add(Me.picImagen)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTitulo.Location = New System.Drawing.Point(3, 3)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(679, 64)
        Me.pnlTitulo.TabIndex = 0
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
        Me.ReflectionLabel1.Size = New System.Drawing.Size(615, 40)
        Me.ReflectionLabel1.TabIndex = 0
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CONSULTA DE DISTRIBUCIÓN DE TIEMPO</b></font>"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.ConsultaTAlloc32
        Me.picImagen.Location = New System.Drawing.Point(12, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(32, 32)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picImagen.TabIndex = 110
        Me.picImagen.TabStop = False
        '
        'pnlParametros
        '
        Me.pnlParametros.Controls.Add(Me.Panel5)
        Me.pnlParametros.Controls.Add(Me.btnMostrarInformacion)
        Me.pnlParametros.Controls.Add(Me.lblUltActualizacion)
        Me.pnlParametros.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlParametros.Location = New System.Drawing.Point(688, 3)
        Me.pnlParametros.Name = "pnlParametros"
        Me.pnlParametros.Size = New System.Drawing.Size(283, 64)
        Me.pnlParametros.TabIndex = 0
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.Panel5.Controls.Add(Me.txtFecha)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 18)
        Me.Panel5.MinimumSize = New System.Drawing.Size(175, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(3)
        Me.Panel5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Panel5.Size = New System.Drawing.Size(252, 46)
        Me.Panel5.TabIndex = 2
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
        Me.txtFecha.Location = New System.Drawing.Point(124, 11)
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
        Me.Label5.Location = New System.Drawing.Point(33, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(47, 17)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Fecha"
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
        Me.btnMostrarInformacion.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnMostrarInformacion.Location = New System.Drawing.Point(252, 18)
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
        Me.lblUltActualizacion.Size = New System.Drawing.Size(283, 18)
        Me.lblUltActualizacion.TabIndex = 2
        Me.lblUltActualizacion.Text = "Información actualizada al: 4/11/2015 09:34:10.00 AM"
        Me.lblUltActualizacion.TextAlignment = System.Drawing.StringAlignment.Far
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlCentrarControles)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 389)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(974, 48)
        Me.Panel1.TabIndex = 3
        '
        'pnlCentrarControles
        '
        Me.pnlCentrarControles.Controls.Add(Me.btnArchivoSAP)
        Me.pnlCentrarControles.Controls.Add(Me.btnBuscar)
        Me.pnlCentrarControles.Controls.Add(Me.btnReporte)
        Me.pnlCentrarControles.Controls.Add(Me.btnCerrar)
        Me.pnlCentrarControles.Location = New System.Drawing.Point(53, 6)
        Me.pnlCentrarControles.Name = "pnlCentrarControles"
        Me.pnlCentrarControles.Size = New System.Drawing.Size(387, 32)
        Me.pnlCentrarControles.TabIndex = 0
        '
        'btnArchivoSAP
        '
        Me.btnArchivoSAP.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnArchivoSAP.CausesValidation = False
        Me.btnArchivoSAP.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnArchivoSAP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnArchivoSAP.Image = Global.PIDA.My.Resources.Resources.Save_as16
        Me.btnArchivoSAP.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnArchivoSAP.Location = New System.Drawing.Point(7, 4)
        Me.btnArchivoSAP.Name = "btnArchivoSAP"
        Me.btnArchivoSAP.Size = New System.Drawing.Size(115, 25)
        Me.btnArchivoSAP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnArchivoSAP.TabIndex = 0
        Me.btnArchivoSAP.Text = "Generar archivo"
        Me.btnArchivoSAP.Tooltip = "Buscar"
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBuscar.Location = New System.Drawing.Point(130, 4)
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
        Me.btnReporte.Location = New System.Drawing.Point(216, 4)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 2
        Me.btnReporte.Text = "Reporte"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(302, 4)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 3
        Me.btnCerrar.Text = "Salir"
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
        Me.dgPersonal.Location = New System.Drawing.Point(0, 77)
        Me.dgPersonal.Name = "dgPersonal"
        '
        '
        '
        Me.dgPersonal.PrimaryGrid.AllowEdit = False
        Me.dgPersonal.PrimaryGrid.AutoGenerateColumns = False
        Me.dgPersonal.PrimaryGrid.ColumnDragBehavior = DevComponents.DotNetBar.SuperGrid.ColumnDragBehavior.None
        '
        '
        '
        Me.dgPersonal.PrimaryGrid.ColumnHeader.AutoApplyGroupColors = False
        Me.dgPersonal.PrimaryGrid.Columns.Add(Me.colReloj)
        Me.dgPersonal.PrimaryGrid.Columns.Add(Me.colNombres)
        Me.dgPersonal.PrimaryGrid.Columns.Add(Me.colComp)
        Me.dgPersonal.PrimaryGrid.Columns.Add(Me.colCodSuper)
        Me.dgPersonal.PrimaryGrid.Columns.Add(Me.colCodDepto)
        Me.dgPersonal.PrimaryGrid.Columns.Add(Me.colCodTurno)
        Me.dgPersonal.PrimaryGrid.Columns.Add(Me.colHrsNor)
        Me.dgPersonal.PrimaryGrid.Columns.Add(Me.colHrsExtras)
        Me.dgPersonal.PrimaryGrid.Columns.Add(Me.GridColumn6)
        Me.dgPersonal.PrimaryGrid.Columns.Add(Me.GridColumn7)
        Background10.Color1 = System.Drawing.Color.LightSteelBlue
        Me.dgPersonal.PrimaryGrid.DefaultVisualStyles.GroupHeaderStyles.Default.Background = Background10
        Me.dgPersonal.PrimaryGrid.DefaultVisualStyles.GroupHeaderStyles.Default.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Background11.Color1 = System.Drawing.SystemColors.Highlight
        Me.dgPersonal.PrimaryGrid.DefaultVisualStyles.RowStyles.Selected.Background = Background11
        Me.dgPersonal.PrimaryGrid.EnableFiltering = True
        Me.dgPersonal.PrimaryGrid.EnableRowFiltering = True
        Me.dgPersonal.PrimaryGrid.ExpandButtonType = DevComponents.DotNetBar.SuperGrid.ExpandButtonType.Triangle
        '
        '
        '
        Me.dgPersonal.PrimaryGrid.Filter.ShowPanelFilterExpr = True
        Me.dgPersonal.PrimaryGrid.Filter.Visible = True
        Me.dgPersonal.PrimaryGrid.FilterLevel = CType((DevComponents.DotNetBar.SuperGrid.FilterLevel.Root Or DevComponents.DotNetBar.SuperGrid.FilterLevel.Expanded), DevComponents.DotNetBar.SuperGrid.FilterLevel)
        Me.dgPersonal.PrimaryGrid.FilterMatchType = DevComponents.DotNetBar.SuperGrid.FilterMatchType.RegularExpressions
        Me.dgPersonal.PrimaryGrid.FrozenColumnCount = 2
        '
        '
        '
        Me.dgPersonal.PrimaryGrid.GroupByRow.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.Never
        Me.dgPersonal.PrimaryGrid.GroupByRow.Visible = True
        Me.dgPersonal.PrimaryGrid.GroupByRow.WatermarkText = "Arrastre el encabezado de la columna que deseee agrupar"
        '
        '
        '
        Me.dgPersonal.PrimaryGrid.Header.RowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.Never
        Me.dgPersonal.PrimaryGrid.ShowGroupUnderline = False
        Me.dgPersonal.PrimaryGrid.ShowTreeButtons = True
        Me.dgPersonal.Size = New System.Drawing.Size(974, 312)
        Me.dgPersonal.TabIndex = 2
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopiarToolStripMenuItem, Me.ToolStripMenuItem2, Me.CerrarToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(152, 54)
        '
        'CopiarToolStripMenuItem
        '
        Me.CopiarToolStripMenuItem.Image = Global.PIDA.My.Resources.Resources.copy_16
        Me.CopiarToolStripMenuItem.Name = "CopiarToolStripMenuItem"
        Me.CopiarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopiarToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.CopiarToolStripMenuItem.Text = "Copiar"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(148, 6)
        '
        'CerrarToolStripMenuItem
        '
        Me.CerrarToolStripMenuItem.Name = "CerrarToolStripMenuItem"
        Me.CerrarToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.CerrarToolStripMenuItem.Text = "Cerrar"
        '
        'colReloj
        '
        Me.colReloj.AllowEdit = False
        Me.colReloj.DataPropertyName = "reloj"
        Me.colReloj.GroupBoxEffects = DevComponents.DotNetBar.SuperGrid.GroupBoxEffects.None
        Me.colReloj.HeaderText = "RELOJ"
        Me.colReloj.Name = "colReloj"
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
        Me.colNombres.GroupBoxEffects = DevComponents.DotNetBar.SuperGrid.GroupBoxEffects.None
        Me.colNombres.HeaderText = "NOMBRE"
        Me.colNombres.Name = "colNombres"
        Me.colNombres.ReadOnly = True
        Me.colNombres.Width = 200
        '
        'colComp
        '
        Me.colComp.DataPropertyName = "cod_comp"
        Me.colComp.HeaderText = "COMPAÑÍA"
        Me.colComp.Name = "colComp"
        Me.colComp.Width = 75
        '
        'colCodSuper
        '
        Me.colCodSuper.DataPropertyName = "nombre_super"
        Me.colCodSuper.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colCodSuper.FilterAutoScan = True
        Me.colCodSuper.HeaderText = "SUPERVISOR"
        Me.colCodSuper.Name = "colCodSuper"
        '
        'colCodDepto
        '
        Me.colCodDepto.AllowEdit = False
        Me.colCodDepto.CellStyles.Default.TextColor = System.Drawing.SystemColors.GrayText
        Background2.Color1 = System.Drawing.SystemColors.Highlight
        Me.colCodDepto.CellStyles.Selected.Background = Background2
        Me.colCodDepto.CellStyles.Selected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colCodDepto.CellStyles.Selected.TextColor = System.Drawing.SystemColors.HighlightText
        Me.colCodDepto.DataPropertyName = "nombre_depto"
        Me.colCodDepto.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colCodDepto.FilterAutoScan = True
        Me.colCodDepto.HeaderText = "DEPARTAMENTO"
        Me.colCodDepto.Name = "colCodDepto"
        Me.colCodDepto.ReadOnly = True
        '
        'colCodTurno
        '
        Me.colCodTurno.AllowEdit = False
        Me.colCodTurno.CellStyles.Default.TextColor = System.Drawing.SystemColors.GrayText
        Background3.Color1 = System.Drawing.SystemColors.Highlight
        Me.colCodTurno.CellStyles.Selected.Background = Background3
        Me.colCodTurno.CellStyles.Selected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colCodTurno.CellStyles.Selected.TextColor = System.Drawing.SystemColors.HighlightText
        Me.colCodTurno.DataPropertyName = "nombre_turno"
        Me.colCodTurno.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colCodTurno.FilterAutoScan = True
        Me.colCodTurno.HeaderText = "TURNO"
        Me.colCodTurno.Name = "colCodTurno"
        Me.colCodTurno.ReadOnly = True
        '
        'colHrsNor
        '
        Me.colHrsNor.AllowEdit = False
        Me.colHrsNor.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
        Padding1.Right = 10
        Me.colHrsNor.CellStyles.Default.Padding = Padding1
        Me.colHrsNor.CellStyles.Default.TextColor = System.Drawing.SystemColors.GrayText
        Background4.Color1 = System.Drawing.SystemColors.Highlight
        Me.colHrsNor.CellStyles.Selected.Background = Background4
        Me.colHrsNor.CellStyles.Selected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colHrsNor.CellStyles.Selected.TextColor = System.Drawing.SystemColors.HighlightText
        Me.colHrsNor.DataPropertyName = "horas_normales"
        Me.colHrsNor.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colHrsNor.FilterAutoScan = True
        Me.colHrsNor.GroupBoxEffects = DevComponents.DotNetBar.SuperGrid.GroupBoxEffects.None
        Me.colHrsNor.HeaderText = "HRS. NOR."
        Me.colHrsNor.Name = "colHrsNormales"
        Me.colHrsNor.ReadOnly = True
        Me.colHrsNor.Width = 75
        '
        'colHrsExtras
        '
        Me.colHrsExtras.AllowEdit = False
        Me.colHrsExtras.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
        Padding2.Right = 10
        Me.colHrsExtras.CellStyles.Default.Padding = Padding2
        Me.colHrsExtras.CellStyles.Default.TextColor = System.Drawing.SystemColors.GrayText
        Background5.Color1 = System.Drawing.SystemColors.Highlight
        Me.colHrsExtras.CellStyles.Selected.Background = Background5
        Me.colHrsExtras.CellStyles.Selected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.colHrsExtras.CellStyles.Selected.TextColor = System.Drawing.SystemColors.HighlightText
        Me.colHrsExtras.DataPropertyName = "horas_extras"
        Me.colHrsExtras.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colHrsExtras.FilterAutoScan = True
        Me.colHrsExtras.GroupBoxEffects = DevComponents.DotNetBar.SuperGrid.GroupBoxEffects.None
        Me.colHrsExtras.HeaderText = "HRS. EXTR."
        Me.colHrsExtras.Name = "colHrsExtras"
        Me.colHrsExtras.ReadOnly = True
        Me.colHrsExtras.Width = 75
        '
        'GridColumn6
        '
        Me.GridColumn6.AllowEdit = False
        Me.GridColumn6.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
        Background6.Color1 = System.Drawing.SystemColors.ActiveCaption
        Me.GridColumn6.CellStyles.Default.Background = Background6
        Padding3.Right = 10
        Me.GridColumn6.CellStyles.Default.Padding = Padding3
        Me.GridColumn6.CellStyles.Default.TextColor = System.Drawing.SystemColors.GrayText
        Background7.Color1 = System.Drawing.SystemColors.Highlight
        Me.GridColumn6.CellStyles.Selected.Background = Background7
        Me.GridColumn6.CellStyles.Selected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn6.CellStyles.Selected.TextColor = System.Drawing.SystemColors.HighlightText
        Me.GridColumn6.DataPropertyName = "diferencia"
        Me.GridColumn6.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn6.FilterAutoScan = True
        Me.GridColumn6.GroupBoxEffects = DevComponents.DotNetBar.SuperGrid.GroupBoxEffects.None
        Me.GridColumn6.HeaderText = "DIFERENCIA"
        Me.GridColumn6.Name = "colDiferencia"
        Me.GridColumn6.ReadOnly = True
        Me.GridColumn6.Width = 75
        '
        'GridColumn7
        '
        Me.GridColumn7.AllowEdit = False
        Me.GridColumn7.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
        Background8.Color1 = System.Drawing.Color.LightSteelBlue
        Me.GridColumn7.CellStyles.Default.Background = Background8
        Padding4.Right = 10
        Me.GridColumn7.CellStyles.Default.Padding = Padding4
        Me.GridColumn7.CellStyles.Default.TextColor = System.Drawing.SystemColors.InactiveCaptionText
        Background9.Color1 = System.Drawing.SystemColors.Highlight
        Me.GridColumn7.CellStyles.Selected.Background = Background9
        Me.GridColumn7.CellStyles.Selected.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridColumn7.CellStyles.Selected.TextColor = System.Drawing.SystemColors.HighlightText
        Me.GridColumn7.DataPropertyName = "total"
        Me.GridColumn7.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn7.FilterAutoScan = True
        Me.GridColumn7.GroupBoxEffects = DevComponents.DotNetBar.SuperGrid.GroupBoxEffects.None
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
        Me.gpAvance.TabIndex = 2
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
        'frmTimeAllocationConsulta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(974, 437)
        Me.Controls.Add(Me.gpAvance)
        Me.Controls.Add(Me.lblTip)
        Me.Controls.Add(Me.dgPersonal)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTimeAllocationConsulta"
        Me.Text = "ConsultaTime Allocation"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlParametros.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.pnlCentrarControles.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.gpAvance.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents btnMostrarInformacion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgPersonal As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents colNombres As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents colHrsNor As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn2 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader6 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader7 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader8 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents GridColumn3 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents colCodDepto As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents colCodTurno As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents colHrsExtras As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn6 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents lblTip As System.Windows.Forms.Label
    Friend WithEvents GridColumn7 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents pnlCentrarControles As System.Windows.Forms.Panel
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CerrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopiarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gpAvance As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lblAvance As System.Windows.Forms.Label
    Friend WithEvents pbAvance As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents btnArchivoSAP As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents colCodSuper As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents colReloj As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents colComp As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents pnlParametros As System.Windows.Forms.Panel
    Friend WithEvents lblUltActualizacion As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
End Class
