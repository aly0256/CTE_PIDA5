<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAjustesMasivos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAjustesMasivos))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.gpSueldos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.cbInactivos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.btnBuscaLista = New DevComponents.DotNetBar.ButtonX()
        Me.txtLista = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnLista = New System.Windows.Forms.RadioButton()
        Me.btnArchivo = New System.Windows.Forms.RadioButton()
        Me.btnBuscaArchivo = New DevComponents.DotNetBar.ButtonX()
        Me.txtArchivo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtComentario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlFecha = New System.Windows.Forms.Panel()
        Me.txtFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbTipoPeriodo = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.itmSemanal = New DevComponents.Editors.ComboItem()
        Me.itmQuincenal = New DevComponents.Editors.ComboItem()
        Me.itmMensual = New DevComponents.Editors.ComboItem()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbConcepto = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ConConcepto = New DevComponents.AdvTree.ColumnHeader()
        Me.NombreMod = New DevComponents.AdvTree.ColumnHeader()
        Me.ColNaturaleza = New DevComponents.AdvTree.ColumnHeader()
        Me.ElementStyle3 = New DevComponents.DotNetBar.ElementStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbAnoPeriodo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader()
        Me.txtMonto = New DevComponents.Editors.DoubleInput()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.dlgArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.cpActualizacion = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.ElementStyle2 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle4 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle5 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle6 = New DevComponents.DotNetBar.ElementStyle()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.sprToolTip = New DevComponents.DotNetBar.SuperTooltip()
        Me.gpSueldos.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlFecha.SuspendLayout()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.txtMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        Me.ReflectionLabel1.TabIndex = 111
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>AJUSTES A NÓMINA POR GRUPOS</b></font>"
        '
        'gpSueldos
        '
        Me.gpSueldos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpSueldos.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpSueldos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpSueldos.Controls.Add(Me.cbInactivos)
        Me.gpSueldos.Controls.Add(Me.btnBuscaLista)
        Me.gpSueldos.Controls.Add(Me.txtLista)
        Me.gpSueldos.Controls.Add(Me.btnLista)
        Me.gpSueldos.Controls.Add(Me.btnArchivo)
        Me.gpSueldos.Controls.Add(Me.btnBuscaArchivo)
        Me.gpSueldos.Controls.Add(Me.txtArchivo)
        Me.gpSueldos.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpSueldos.Location = New System.Drawing.Point(14, 67)
        Me.gpSueldos.Name = "gpSueldos"
        Me.gpSueldos.Size = New System.Drawing.Size(478, 164)
        '
        '
        '
        Me.gpSueldos.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpSueldos.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpSueldos.Style.BackColorGradientAngle = 90
        Me.gpSueldos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpSueldos.Style.BorderBottomWidth = 1
        Me.gpSueldos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpSueldos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpSueldos.Style.BorderLeftWidth = 1
        Me.gpSueldos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpSueldos.Style.BorderRightWidth = 1
        Me.gpSueldos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpSueldos.Style.BorderTopWidth = 1
        Me.gpSueldos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpSueldos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpSueldos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpSueldos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpSueldos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpSueldos.TabIndex = 0
        Me.gpSueldos.Text = "Empleados a asignar"
        '
        'cbInactivos
        '
        Me.cbInactivos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbInactivos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbInactivos.Location = New System.Drawing.Point(7, 111)
        Me.cbInactivos.Name = "cbInactivos"
        Me.cbInactivos.Size = New System.Drawing.Size(161, 24)
        Me.cbInactivos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbInactivos.TabIndex = 6
        Me.cbInactivos.Text = " Incluir personal inactivo"
        Me.cbInactivos.TextColor = System.Drawing.SystemColors.ActiveCaptionText
        '
        'btnBuscaLista
        '
        Me.btnBuscaLista.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscaLista.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscaLista.Enabled = False
        Me.btnBuscaLista.Location = New System.Drawing.Point(434, 83)
        Me.btnBuscaLista.Name = "btnBuscaLista"
        Me.btnBuscaLista.Size = New System.Drawing.Size(26, 23)
        Me.btnBuscaLista.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscaLista.TabIndex = 5
        Me.btnBuscaLista.Text = "..."
        '
        'txtLista
        '
        Me.txtLista.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtLista.Border.Class = "TextBoxBorder"
        Me.txtLista.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtLista.Enabled = False
        Me.txtLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLista.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLista.Location = New System.Drawing.Point(26, 83)
        Me.txtLista.Name = "txtLista"
        Me.txtLista.Size = New System.Drawing.Size(402, 23)
        Me.txtLista.TabIndex = 4
        '
        'btnLista
        '
        Me.btnLista.AutoSize = True
        Me.btnLista.BackColor = System.Drawing.SystemColors.Window
        Me.btnLista.Location = New System.Drawing.Point(7, 63)
        Me.btnLista.Name = "btnLista"
        Me.btnLista.Size = New System.Drawing.Size(270, 19)
        Me.btnLista.TabIndex = 3
        Me.btnLista.Text = "Listar números de reloj, separados por coma"
        Me.btnLista.UseVisualStyleBackColor = False
        '
        'btnArchivo
        '
        Me.btnArchivo.AutoSize = True
        Me.btnArchivo.BackColor = System.Drawing.SystemColors.Window
        Me.btnArchivo.Checked = True
        Me.btnArchivo.Location = New System.Drawing.Point(7, 13)
        Me.btnArchivo.Name = "btnArchivo"
        Me.btnArchivo.Size = New System.Drawing.Size(274, 19)
        Me.btnArchivo.TabIndex = 0
        Me.btnArchivo.TabStop = True
        Me.btnArchivo.Text = "Buscar en archivo texto o Excel (reloj - monto)"
        Me.btnArchivo.UseVisualStyleBackColor = False
        '
        'btnBuscaArchivo
        '
        Me.btnBuscaArchivo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscaArchivo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscaArchivo.Location = New System.Drawing.Point(434, 33)
        Me.btnBuscaArchivo.Name = "btnBuscaArchivo"
        Me.btnBuscaArchivo.Size = New System.Drawing.Size(26, 23)
        Me.btnBuscaArchivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sprToolTip.SetSuperTooltip(Me.btnBuscaArchivo, New DevComponents.DotNetBar.SuperTooltipInfo("Ajustes desde archivo", "                    RELOJ       MONTO", "Acepta archivo tipo texto (separando los datos con un ""TAB"") , o tipo Excel, en e" & _
            "l siguiente formato:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10), Global.PIDA.My.Resources.Resources.Export32, Nothing, DevComponents.DotNetBar.eTooltipColor.BlueMist))
        Me.btnBuscaArchivo.TabIndex = 2
        Me.btnBuscaArchivo.Text = "..."
        '
        'txtArchivo
        '
        Me.txtArchivo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtArchivo.Border.Class = "TextBoxBorder"
        Me.txtArchivo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtArchivo.Location = New System.Drawing.Point(26, 33)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.Size = New System.Drawing.Size(402, 23)
        Me.txtArchivo.TabIndex = 1
        '
        'GroupPanel1
        '
        Me.GroupPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel1.Controls.Add(Me.Panel3)
        Me.GroupPanel1.Controls.Add(Me.pnlFecha)
        Me.GroupPanel1.Controls.Add(Me.Panel1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(14, 237)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(478, 227)
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
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
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
        Me.GroupPanel1.TabIndex = 1
        Me.GroupPanel1.Text = "Información"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.txtComentario)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 150)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Padding = New System.Windows.Forms.Padding(4)
        Me.Panel3.Size = New System.Drawing.Size(468, 49)
        Me.Panel3.TabIndex = 1
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
        Me.txtComentario.Size = New System.Drawing.Size(341, 41)
        Me.txtComentario.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.SystemColors.Window
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label7.Location = New System.Drawing.Point(4, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.Label7.Size = New System.Drawing.Size(115, 41)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Comentario"
        '
        'pnlFecha
        '
        Me.pnlFecha.BackColor = System.Drawing.Color.White
        Me.pnlFecha.Controls.Add(Me.txtFecha)
        Me.pnlFecha.Controls.Add(Me.Label2)
        Me.pnlFecha.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFecha.Location = New System.Drawing.Point(0, 120)
        Me.pnlFecha.Name = "pnlFecha"
        Me.pnlFecha.Padding = New System.Windows.Forms.Padding(4)
        Me.pnlFecha.Size = New System.Drawing.Size(468, 30)
        Me.pnlFecha.TabIndex = 0
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
        Me.txtFecha.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtFecha.IsPopupCalendarOpen = False
        Me.txtFecha.Location = New System.Drawing.Point(119, 4)
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
        Me.txtFecha.MonthCalendar.DisplayMonth = New Date(2017, 10, 1, 0, 0, 0, 0)
        Me.txtFecha.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday
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
        Me.txtFecha.Size = New System.Drawing.Size(108, 21)
        Me.txtFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFecha.TabIndex = 1
        Me.txtFecha.Value = New Date(2017, 10, 17, 10, 30, 36, 0)
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.Location = New System.Drawing.Point(4, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 22)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Fecha incidencia"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.cmbTipoPeriodo)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cmbConcepto)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmbAnoPeriodo)
        Me.Panel1.Controls.Add(Me.txtMonto)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(468, 120)
        Me.Panel1.TabIndex = 1
        '
        'cmbTipoPeriodo
        '
        Me.cmbTipoPeriodo.DisplayMember = "Text"
        Me.cmbTipoPeriodo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTipoPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPeriodo.FormattingEnabled = True
        Me.cmbTipoPeriodo.ItemHeight = 15
        Me.cmbTipoPeriodo.Items.AddRange(New Object() {Me.itmSemanal, Me.itmQuincenal, Me.itmMensual})
        Me.cmbTipoPeriodo.Location = New System.Drawing.Point(119, 12)
        Me.cmbTipoPeriodo.Name = "cmbTipoPeriodo"
        Me.cmbTipoPeriodo.Size = New System.Drawing.Size(341, 21)
        Me.cmbTipoPeriodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipoPeriodo.TabIndex = 1
        '
        'itmSemanal
        '
        Me.itmSemanal.Text = "SEMANAL"
        Me.itmSemanal.Value = "S"
        '
        'itmQuincenal
        '
        Me.itmQuincenal.Text = "Catorcenal"
        Me.itmQuincenal.Value = "C"
        '
        'itmMensual
        '
        Me.itmMensual.Text = "MENSUAL"
        Me.itmMensual.Value = "M"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Window
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(4, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 15)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Tipo de periodo"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Window
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(5, 44)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 15)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Año/periodo"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 15)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Concepto"
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
        Me.cmbConcepto.Columns.Add(Me.ConConcepto)
        Me.cmbConcepto.Columns.Add(Me.NombreMod)
        Me.cmbConcepto.Columns.Add(Me.ColNaturaleza)
        Me.cmbConcepto.GroupingMembers = "naturaleza"
        Me.cmbConcepto.GroupNodeStyle = Me.ElementStyle3
        Me.cmbConcepto.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbConcepto.Location = New System.Drawing.Point(119, 69)
        Me.cmbConcepto.Name = "cmbConcepto"
        Me.cmbConcepto.Size = New System.Drawing.Size(341, 23)
        Me.cmbConcepto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbConcepto.TabIndex = 5
        Me.cmbConcepto.ValueMember = "concepto"
        '
        'ConConcepto
        '
        Me.ConConcepto.DataFieldName = "concepto"
        Me.ConConcepto.Name = "ConConcepto"
        Me.ConConcepto.Text = "Código"
        Me.ConConcepto.Width.Absolute = 100
        '
        'NombreMod
        '
        Me.NombreMod.DataFieldName = "Nombre"
        Me.NombreMod.Name = "NombreMod"
        Me.NombreMod.StretchToFill = True
        Me.NombreMod.Text = "Nombre"
        Me.NombreMod.Width.Absolute = 150
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
        'ElementStyle3
        '
        Me.ElementStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ElementStyle3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
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
        Me.ElementStyle3.Description = "Blue"
        Me.ElementStyle3.Name = "ElementStyle3"
        Me.ElementStyle3.PaddingBottom = 1
        Me.ElementStyle3.PaddingLeft = 1
        Me.ElementStyle3.PaddingRight = 1
        Me.ElementStyle3.PaddingTop = 1
        Me.ElementStyle3.TextColor = System.Drawing.Color.Black
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Monto"
        '
        'cmbAnoPeriodo
        '
        Me.cmbAnoPeriodo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbAnoPeriodo.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbAnoPeriodo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbAnoPeriodo.ButtonDropDown.Visible = True
        Me.cmbAnoPeriodo.Columns.Add(Me.ColumnHeader3)
        Me.cmbAnoPeriodo.Columns.Add(Me.ColumnHeader2)
        Me.cmbAnoPeriodo.Columns.Add(Me.ColumnHeader1)
        Me.cmbAnoPeriodo.Columns.Add(Me.ColumnHeader4)
        Me.cmbAnoPeriodo.Columns.Add(Me.ColumnHeader5)
        Me.cmbAnoPeriodo.DropDownHeight = 180
        Me.cmbAnoPeriodo.FormatString = "d"
        Me.cmbAnoPeriodo.FormattingEnabled = True
        Me.cmbAnoPeriodo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbAnoPeriodo.Location = New System.Drawing.Point(119, 40)
        Me.cmbAnoPeriodo.Name = "cmbAnoPeriodo"
        Me.cmbAnoPeriodo.Size = New System.Drawing.Size(341, 23)
        Me.cmbAnoPeriodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbAnoPeriodo.TabIndex = 3
        Me.cmbAnoPeriodo.ValueMember = "unico"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DataFieldName = "unico"
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "unico"
        Me.ColumnHeader3.Visible = False
        Me.ColumnHeader3.Width.Absolute = 150
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "ano"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Año"
        Me.ColumnHeader2.Width.Relative = 20
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "periodo"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Periodo"
        Me.ColumnHeader1.Width.Relative = 20
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DataFieldName = "fecha_ini"
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "Fecha inicial"
        Me.ColumnHeader4.Width.Relative = 30
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DataFieldName = "fecha_fin"
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.StretchToFill = True
        Me.ColumnHeader5.Text = "Fecha final"
        Me.ColumnHeader5.Width.Relative = 30
        '
        'txtMonto
        '
        '
        '
        '
        Me.txtMonto.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtMonto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMonto.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtMonto.Increment = 1.0R
        Me.txtMonto.Location = New System.Drawing.Point(119, 98)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.ShowUpDown = True
        Me.txtMonto.Size = New System.Drawing.Size(108, 21)
        Me.txtMonto.TabIndex = 7
        '
        'ElementStyle1
        '
        Me.ElementStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.ElementStyle1.BackColor2 = System.Drawing.Color.Navy
        Me.ElementStyle1.BackColorGradientAngle = 90
        Me.ElementStyle1.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderBottomWidth = 1
        Me.ElementStyle1.BorderColor = System.Drawing.Color.Navy
        Me.ElementStyle1.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderLeftWidth = 1
        Me.ElementStyle1.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderRightWidth = 1
        Me.ElementStyle1.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderTopWidth = 1
        Me.ElementStyle1.CornerDiameter = 4
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Description = "BlueNight"
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.PaddingBottom = 1
        Me.ElementStyle1.PaddingLeft = 1
        Me.ElementStyle1.PaddingRight = 1
        Me.ElementStyle1.PaddingTop = 1
        Me.ElementStyle1.TextColor = System.Drawing.SystemColors.Window
        '
        'dlgArchivo
        '
        Me.dlgArchivo.FileName = "OpenFileDialog1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAceptar)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Location = New System.Drawing.Point(318, 466)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(174, 47)
        Me.GroupBox1.TabIndex = 3
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
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelar.Location = New System.Drawing.Point(88, 14)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        '
        'cpActualizacion
        '
        '
        '
        '
        Me.cpActualizacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cpActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cpActualizacion.Location = New System.Drawing.Point(14, 480)
        Me.cpActualizacion.Name = "cpActualizacion"
        Me.cpActualizacion.Size = New System.Drawing.Size(298, 25)
        Me.cpActualizacion.TabIndex = 2
        Me.cpActualizacion.Text = "Reloj"
        Me.cpActualizacion.TextVisible = True
        Me.cpActualizacion.Visible = False
        '
        'ElementStyle2
        '
        Me.ElementStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ElementStyle2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(252, Byte), Integer))
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
        Me.ElementStyle2.Description = "BlueLight"
        Me.ElementStyle2.Name = "ElementStyle2"
        Me.ElementStyle2.PaddingBottom = 1
        Me.ElementStyle2.PaddingLeft = 1
        Me.ElementStyle2.PaddingRight = 1
        Me.ElementStyle2.PaddingTop = 1
        Me.ElementStyle2.TextColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(115, Byte), Integer))
        '
        'ElementStyle4
        '
        Me.ElementStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ElementStyle4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(252, Byte), Integer))
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
        Me.ElementStyle4.Description = "BlueLight"
        Me.ElementStyle4.Name = "ElementStyle4"
        Me.ElementStyle4.PaddingBottom = 1
        Me.ElementStyle4.PaddingLeft = 1
        Me.ElementStyle4.PaddingRight = 1
        Me.ElementStyle4.PaddingTop = 1
        Me.ElementStyle4.TextColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(115, Byte), Integer))
        '
        'ElementStyle5
        '
        Me.ElementStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.ElementStyle5.BackColor2 = System.Drawing.Color.Navy
        Me.ElementStyle5.BackColorGradientAngle = 90
        Me.ElementStyle5.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle5.BorderBottomWidth = 1
        Me.ElementStyle5.BorderColor = System.Drawing.Color.Navy
        Me.ElementStyle5.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle5.BorderLeftWidth = 1
        Me.ElementStyle5.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle5.BorderRightWidth = 1
        Me.ElementStyle5.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle5.BorderTopWidth = 1
        Me.ElementStyle5.CornerDiameter = 4
        Me.ElementStyle5.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle5.Description = "BlueNight"
        Me.ElementStyle5.Name = "ElementStyle5"
        Me.ElementStyle5.PaddingBottom = 1
        Me.ElementStyle5.PaddingLeft = 1
        Me.ElementStyle5.PaddingRight = 1
        Me.ElementStyle5.PaddingTop = 1
        Me.ElementStyle5.TextColor = System.Drawing.SystemColors.Window
        '
        'ElementStyle6
        '
        Me.ElementStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ElementStyle6.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ElementStyle6.BackColorGradientAngle = 90
        Me.ElementStyle6.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle6.BorderBottomWidth = 1
        Me.ElementStyle6.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle6.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle6.BorderLeftWidth = 1
        Me.ElementStyle6.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle6.BorderRightWidth = 1
        Me.ElementStyle6.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle6.BorderTopWidth = 1
        Me.ElementStyle6.CornerDiameter = 4
        Me.ElementStyle6.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle6.Description = "Blue"
        Me.ElementStyle6.Name = "ElementStyle6"
        Me.ElementStyle6.PaddingBottom = 1
        Me.ElementStyle6.PaddingLeft = 1
        Me.ElementStyle6.PaddingRight = 1
        Me.ElementStyle6.PaddingTop = 1
        Me.ElementStyle6.TextColor = System.Drawing.Color.Black
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.massive_
        Me.picImagen.Location = New System.Drawing.Point(12, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(31, 30)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picImagen.TabIndex = 112
        Me.picImagen.TabStop = False
        '
        'sprToolTip
        '
        Me.sprToolTip.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("Ajustes desde archivo", "                    RELOJ       MONTO", "Acepta archivo tipo texto (separando los datos con un ""TAB"") , o tipo Excel, en e" & _
        "l siguiente formato:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10), Global.PIDA.My.Resources.Resources.Export32, Nothing, DevComponents.DotNetBar.eTooltipColor.BlueMist)
        Me.sprToolTip.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.sprToolTip.ShowTooltipImmediately = True
        '
        'frmAjustesMasivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 519)
        Me.Controls.Add(Me.cpActualizacion)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.gpSueldos)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.picImagen)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAjustesMasivos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ajustes a misceláneos"
        Me.gpSueldos.ResumeLayout(False)
        Me.gpSueldos.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.pnlFecha.ResumeLayout(False)
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.txtMonto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Private WithEvents gpSueldos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents txtLista As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnLista As System.Windows.Forms.RadioButton
    Friend WithEvents btnArchivo As System.Windows.Forms.RadioButton
    Friend WithEvents btnBuscaArchivo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtArchivo As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmbConcepto As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ConConcepto As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NombreMod As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents dlgArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnBuscaLista As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmbAnoPeriodo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents cpActualizacion As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMonto As DevComponents.Editors.DoubleInput
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColNaturaleza As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle2 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle3 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle4 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle5 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle6 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents cbInactivos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoPeriodo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents itmSemanal As DevComponents.Editors.ComboItem
    Friend WithEvents itmQuincenal As DevComponents.Editors.ComboItem
    Friend WithEvents itmMensual As DevComponents.Editors.ComboItem
    Friend WithEvents sprToolTip As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtComentario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pnlFecha As System.Windows.Forms.Panel
    Friend WithEvents txtFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
