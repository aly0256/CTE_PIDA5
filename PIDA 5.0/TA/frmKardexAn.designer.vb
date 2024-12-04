<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmKardexAn
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmKardexAn))
        Me.pnlKardex = New System.Windows.Forms.Panel()
        Me.pnlAusentismo = New DevComponents.DotNetBar.PanelEx()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblDato = New DevComponents.DotNetBar.LabelX()
        Me.btnCerrarPanel = New DevComponents.DotNetBar.ButtonX()
        Me.lblTexto = New System.Windows.Forms.Label()
        Me.dgCalendario = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pbCarga = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.cmbAno = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.tmrDelay = New System.Windows.Forms.Timer(Me.components)
        Me.btnFirst = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrev = New DevComponents.DotNetBar.ButtonX()
        Me.btnNext = New DevComponents.DotNetBar.ButtonX()
        Me.lblEstado = New DevComponents.DotNetBar.LabelX()
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.txtBaja = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.lblReingreso = New System.Windows.Forms.Label()
        Me.txtAlta = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.lblBaja = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnLast = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.picFoto = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtArea = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.txtCia = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtHorario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.txtTurno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.txtClase = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.txtSupervisor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.txtTipoEmp = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.txtDepto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtplanta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.pnlKardex.SuspendLayout()
        Me.pnlAusentismo.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgCalendario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.txtBaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAlta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlKardex
        '
        Me.pnlKardex.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnlKardex.Controls.Add(Me.pnlAusentismo)
        Me.pnlKardex.Controls.Add(Me.dgCalendario)
        Me.pnlKardex.Controls.Add(Me.Panel3)
        Me.pnlKardex.Location = New System.Drawing.Point(2, 111)
        Me.pnlKardex.Name = "pnlKardex"
        Me.pnlKardex.Padding = New System.Windows.Forms.Padding(5)
        Me.pnlKardex.Size = New System.Drawing.Size(1002, 352)
        Me.pnlKardex.TabIndex = 173
        '
        'pnlAusentismo
        '
        Me.pnlAusentismo.AutoSize = True
        Me.pnlAusentismo.CanvasColor = System.Drawing.SystemColors.Control
        Me.pnlAusentismo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pnlAusentismo.Controls.Add(Me.Line1)
        Me.pnlAusentismo.Controls.Add(Me.Panel2)
        Me.pnlAusentismo.Controls.Add(Me.lblTexto)
        Me.pnlAusentismo.DisabledBackColor = System.Drawing.Color.Empty
        Me.pnlAusentismo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlAusentismo.Location = New System.Drawing.Point(456, 195)
        Me.pnlAusentismo.Name = "pnlAusentismo"
        Me.pnlAusentismo.Padding = New System.Windows.Forms.Padding(7, 0, 7, 0)
        Me.pnlAusentismo.ShowFocusRectangle = True
        Me.pnlAusentismo.Size = New System.Drawing.Size(246, 98)
        Me.pnlAusentismo.Style.Alignment = System.Drawing.StringAlignment.Center
        Me.pnlAusentismo.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.pnlAusentismo.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.pnlAusentismo.Style.BorderColor.Color = System.Drawing.SystemColors.AppWorkspace
        Me.pnlAusentismo.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.pnlAusentismo.Style.GradientAngle = 90
        Me.pnlAusentismo.TabIndex = 157
        Me.pnlAusentismo.Visible = False
        '
        'Line1
        '
        Me.Line1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Line1.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Line1.Location = New System.Drawing.Point(7, 34)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(232, 8)
        Me.Line1.TabIndex = 159
        Me.Line1.Text = "Line1"
        Me.Line1.Thickness = 2
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblDato)
        Me.Panel2.Controls.Add(Me.btnCerrarPanel)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(7, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(232, 34)
        Me.Panel2.TabIndex = 158
        '
        'lblDato
        '
        '
        '
        '
        Me.lblDato.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDato.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDato.Location = New System.Drawing.Point(0, 0)
        Me.lblDato.Name = "lblDato"
        Me.lblDato.Size = New System.Drawing.Size(210, 34)
        Me.lblDato.TabIndex = 3
        Me.lblDato.Text = "Fecha"
        '
        'btnCerrarPanel
        '
        Me.btnCerrarPanel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrarPanel.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.btnCerrarPanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCerrarPanel.Image = Global.PIDA.My.Resources.Resources.x18
        Me.btnCerrarPanel.Location = New System.Drawing.Point(210, 0)
        Me.btnCerrarPanel.Name = "btnCerrarPanel"
        Me.btnCerrarPanel.Size = New System.Drawing.Size(22, 34)
        Me.btnCerrarPanel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrarPanel.TabIndex = 2
        '
        'lblTexto
        '
        Me.lblTexto.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblTexto.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblTexto.Location = New System.Drawing.Point(7, 42)
        Me.lblTexto.Name = "lblTexto"
        Me.lblTexto.Size = New System.Drawing.Size(232, 56)
        Me.lblTexto.TabIndex = 4
        Me.lblTexto.Text = "Text"
        Me.lblTexto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgCalendario
        '
        Me.dgCalendario.AllowUserToAddRows = False
        Me.dgCalendario.AllowUserToDeleteRows = False
        Me.dgCalendario.AllowUserToResizeColumns = False
        Me.dgCalendario.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.dgCalendario.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgCalendario.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgCalendario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCalendario.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgCalendario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgCalendario.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgCalendario.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgCalendario.Location = New System.Drawing.Point(5, 41)
        Me.dgCalendario.Name = "dgCalendario"
        Me.dgCalendario.ReadOnly = True
        Me.dgCalendario.RowHeadersVisible = False
        Me.dgCalendario.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.dgCalendario.Size = New System.Drawing.Size(992, 306)
        Me.dgCalendario.TabIndex = 155
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Window
        Me.Panel3.Controls.Add(Me.pbCarga)
        Me.Panel3.Controls.Add(Me.cmbAno)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(5, 5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(992, 36)
        Me.Panel3.TabIndex = 156
        '
        'pbCarga
        '
        '
        '
        '
        Me.pbCarga.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pbCarga.Location = New System.Drawing.Point(211, 4)
        Me.pbCarga.Name = "pbCarga"
        Me.pbCarga.Size = New System.Drawing.Size(777, 27)
        Me.pbCarga.TabIndex = 143
        Me.pbCarga.Visible = False
        '
        'cmbAno
        '
        Me.cmbAno.DisplayMember = "ano"
        Me.cmbAno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAno.FormattingEnabled = True
        Me.cmbAno.Location = New System.Drawing.Point(123, 5)
        Me.cmbAno.Name = "cmbAno"
        Me.cmbAno.Size = New System.Drawing.Size(82, 24)
        Me.cmbAno.TabIndex = 142
        Me.cmbAno.ValueMember = "ano"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label5.Location = New System.Drawing.Point(6, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(115, 16)
        Me.Label5.TabIndex = 141
        Me.Label5.Text = "Año a consultar"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(11, 11)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(56, 23)
        Me.LabelX4.TabIndex = 36
        Me.LabelX4.Text = "Reloj"
        '
        'tmrDelay
        '
        Me.tmrDelay.Interval = 2000
        '
        'btnFirst
        '
        Me.btnFirst.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnFirst.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnFirst.Image = Global.PIDA.My.Resources.Resources.First16
        Me.btnFirst.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnFirst.Location = New System.Drawing.Point(101, 10)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(78, 25)
        Me.btnFirst.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnFirst.TabIndex = 33
        Me.btnFirst.Text = "Inicio"
        '
        'btnPrev
        '
        Me.btnPrev.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrev.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrev.Image = Global.PIDA.My.Resources.Resources.Prev16
        Me.btnPrev.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnPrev.Location = New System.Drawing.Point(182, 10)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(78, 25)
        Me.btnPrev.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrev.TabIndex = 34
        Me.btnPrev.Text = "Anterior"
        '
        'btnNext
        '
        Me.btnNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNext.Image = Global.PIDA.My.Resources.Resources.Next16
        Me.btnNext.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnNext.Location = New System.Drawing.Point(263, 10)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(78, 25)
        Me.btnNext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNext.TabIndex = 35
        Me.btnNext.Text = "Siguiente"
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.Color.Green
        '
        '
        '
        Me.lblEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblEstado.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Window
        Me.lblEstado.Location = New System.Drawing.Point(6, 8)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(29, 100)
        Me.lblEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblEstado.TabIndex = 165
        Me.lblEstado.Text = "ACTIVO"
        Me.lblEstado.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblEstado.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.lblEstado.VerticalTextTopUp = False
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = Global.PIDA.My.Resources.Resources.Edit
        Me.btnEditar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnEditar.Location = New System.Drawing.Point(668, 10)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(78, 25)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 40
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.Visible = False
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(833, 10)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 42
        Me.btnCerrar.Text = "Salir"
        '
        'txtBaja
        '
        '
        '
        '
        Me.txtBaja.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtBaja.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBaja.ButtonDropDown.Visible = True
        Me.txtBaja.DisabledForeColor = System.Drawing.Color.Black
        Me.txtBaja.Enabled = False
        Me.txtBaja.FocusHighlightEnabled = True
        Me.txtBaja.IsPopupCalendarOpen = False
        Me.txtBaja.Location = New System.Drawing.Point(808, 66)
        '
        '
        '
        Me.txtBaja.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtBaja.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtBaja.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBaja.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtBaja.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtBaja.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBaja.MonthCalendar.DisplayMonth = New Date(2007, 10, 1, 0, 0, 0, 0)
        Me.txtBaja.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtBaja.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtBaja.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtBaja.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtBaja.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtBaja.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBaja.MonthCalendar.TodayButtonVisible = True
        Me.txtBaja.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtBaja.Name = "txtBaja"
        Me.txtBaja.Size = New System.Drawing.Size(82, 20)
        Me.txtBaja.TabIndex = 156
        Me.txtBaja.Value = New Date(2007, 7, 7, 0, 0, 0, 0)
        '
        'lblReingreso
        '
        Me.lblReingreso.BackColor = System.Drawing.SystemColors.HotTrack
        Me.lblReingreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReingreso.ForeColor = System.Drawing.SystemColors.Info
        Me.lblReingreso.Location = New System.Drawing.Point(720, 87)
        Me.lblReingreso.Name = "lblReingreso"
        Me.lblReingreso.Size = New System.Drawing.Size(169, 18)
        Me.lblReingreso.TabIndex = 168
        Me.lblReingreso.Text = "REINGRESO"
        Me.lblReingreso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtAlta
        '
        '
        '
        '
        Me.txtAlta.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtAlta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAlta.ButtonDropDown.Visible = True
        Me.txtAlta.DisabledForeColor = System.Drawing.Color.Black
        Me.txtAlta.Enabled = False
        Me.txtAlta.FocusHighlightEnabled = True
        Me.txtAlta.IsPopupCalendarOpen = False
        Me.txtAlta.Location = New System.Drawing.Point(808, 45)
        '
        '
        '
        Me.txtAlta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtAlta.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtAlta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAlta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtAlta.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtAlta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAlta.MonthCalendar.DisplayMonth = New Date(2007, 10, 1, 0, 0, 0, 0)
        Me.txtAlta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtAlta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtAlta.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtAlta.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtAlta.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtAlta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAlta.MonthCalendar.TodayButtonVisible = True
        Me.txtAlta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtAlta.Name = "txtAlta"
        Me.txtAlta.Size = New System.Drawing.Size(82, 20)
        Me.txtAlta.TabIndex = 155
        Me.txtAlta.Value = New Date(2007, 7, 7, 0, 0, 0, 0)
        '
        'lblBaja
        '
        Me.lblBaja.AutoSize = True
        Me.lblBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBaja.Location = New System.Drawing.Point(717, 66)
        Me.lblBaja.Name = "lblBaja"
        Me.lblBaja.Size = New System.Drawing.Size(85, 15)
        Me.lblBaja.TabIndex = 167
        Me.lblBaja.Text = "Fecha de baja"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(717, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 15)
        Me.Label1.TabIndex = 166
        Me.Label1.Text = "Fecha de alta"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtReloj)
        Me.GroupBox1.Controls.Add(Me.LabelX4)
        Me.GroupBox1.Location = New System.Drawing.Point(720, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(171, 41)
        Me.GroupBox1.TabIndex = 164
        Me.GroupBox1.TabStop = False
        '
        'txtReloj
        '
        Me.txtReloj.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.ForeColor = System.Drawing.Color.Black
        Me.txtReloj.Location = New System.Drawing.Point(82, 10)
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.ReadOnly = True
        Me.txtReloj.Size = New System.Drawing.Size(84, 26)
        Me.txtReloj.TabIndex = 37
        Me.txtReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnLast
        '
        Me.btnLast.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLast.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLast.Image = Global.PIDA.My.Resources.Resources.Last16
        Me.btnLast.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnLast.Location = New System.Drawing.Point(344, 10)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(78, 25)
        Me.btnLast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLast.TabIndex = 36
        Me.btnLast.Text = "Final"
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.NewRecord
        Me.btnNuevo.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnNuevo.Location = New System.Drawing.Point(587, 10)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 25)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 39
        Me.btnNuevo.Text = "Agregar"
        Me.btnNuevo.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnFirst)
        Me.Panel1.Controls.Add(Me.btnPrev)
        Me.Panel1.Controls.Add(Me.btnNext)
        Me.Panel1.Controls.Add(Me.btnEditar)
        Me.Panel1.Controls.Add(Me.btnCerrar)
        Me.Panel1.Controls.Add(Me.btnBorrar)
        Me.Panel1.Controls.Add(Me.btnLast)
        Me.Panel1.Controls.Add(Me.btnNuevo)
        Me.Panel1.Controls.Add(Me.btnReporte)
        Me.Panel1.Controls.Add(Me.btnBuscar)
        Me.Panel1.Location = New System.Drawing.Point(-1, 470)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1008, 44)
        Me.Panel1.TabIndex = 154
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = Global.PIDA.My.Resources.Resources.DeleteRec
        Me.btnBorrar.Location = New System.Drawing.Point(749, 10)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(78, 25)
        Me.btnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBorrar.TabIndex = 41
        Me.btnBorrar.Text = "Borrar"
        Me.btnBorrar.Visible = False
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnReporte.Location = New System.Drawing.Point(506, 10)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 38
        Me.btnReporte.Text = "Reporte"
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBuscar.Location = New System.Drawing.Point(425, 10)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(78, 25)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 37
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Tooltip = "Buscar"
        '
        'picFoto
        '
        Me.picFoto.ErrorImage = Global.PIDA.My.Resources.Resources.NoFoto
        Me.picFoto.Location = New System.Drawing.Point(921, 5)
        Me.picFoto.MaximumSize = New System.Drawing.Size(164, 210)
        Me.picFoto.MinimumSize = New System.Drawing.Size(78, 100)
        Me.picFoto.Name = "picFoto"
        Me.picFoto.Size = New System.Drawing.Size(78, 100)
        Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picFoto.TabIndex = 160
        Me.picFoto.TabStop = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(315, 32)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(32, 15)
        Me.Label30.TabIndex = 191
        Me.Label30.Text = "Area"
        '
        'txtArea
        '
        Me.txtArea.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtArea.Border.Class = "TextBoxBorder"
        Me.txtArea.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtArea.Enabled = False
        Me.txtArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArea.ForeColor = System.Drawing.Color.Black
        Me.txtArea.Location = New System.Drawing.Point(403, 30)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.Size = New System.Drawing.Size(161, 21)
        Me.txtArea.TabIndex = 190
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(314, 9)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(64, 15)
        Me.Label29.TabIndex = 189
        Me.Label29.Text = "Compañía"
        '
        'txtCia
        '
        Me.txtCia.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtCia.Border.Class = "TextBoxBorder"
        Me.txtCia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCia.Enabled = False
        Me.txtCia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCia.ForeColor = System.Drawing.Color.Black
        Me.txtCia.Location = New System.Drawing.Point(403, 3)
        Me.txtCia.Name = "txtCia"
        Me.txtCia.Size = New System.Drawing.Size(161, 21)
        Me.txtCia.TabIndex = 188
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(570, 86)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(48, 15)
        Me.Label26.TabIndex = 187
        Me.Label26.Text = "Horario"
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.Color.Black
        Me.txtNombre.Location = New System.Drawing.Point(44, 28)
        Me.txtNombre.Margin = New System.Windows.Forms.Padding(0)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(266, 23)
        Me.txtNombre.TabIndex = 174
        '
        'txtHorario
        '
        Me.txtHorario.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtHorario.Border.Class = "TextBoxBorder"
        Me.txtHorario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtHorario.Enabled = False
        Me.txtHorario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorario.ForeColor = System.Drawing.Color.Black
        Me.txtHorario.Location = New System.Drawing.Point(624, 84)
        Me.txtHorario.Name = "txtHorario"
        Me.txtHorario.Size = New System.Drawing.Size(90, 21)
        Me.txtHorario.TabIndex = 186
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(41, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 175
        Me.Label2.Text = "Nombre"
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.Location = New System.Drawing.Point(570, 61)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(39, 15)
        Me.Label69.TabIndex = 185
        Me.Label69.Text = "Turno"
        '
        'txtTurno
        '
        Me.txtTurno.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtTurno.Border.Class = "TextBoxBorder"
        Me.txtTurno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTurno.Enabled = False
        Me.txtTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTurno.ForeColor = System.Drawing.Color.Black
        Me.txtTurno.Location = New System.Drawing.Point(624, 59)
        Me.txtTurno.Name = "txtTurno"
        Me.txtTurno.Size = New System.Drawing.Size(90, 21)
        Me.txtTurno.TabIndex = 184
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.Location = New System.Drawing.Point(41, 86)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(38, 15)
        Me.Label70.TabIndex = 183
        Me.Label70.Text = "Clase"
        '
        'txtClase
        '
        Me.txtClase.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtClase.Border.Class = "TextBoxBorder"
        Me.txtClase.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtClase.Enabled = False
        Me.txtClase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClase.ForeColor = System.Drawing.Color.Black
        Me.txtClase.Location = New System.Drawing.Point(123, 84)
        Me.txtClase.Name = "txtClase"
        Me.txtClase.Size = New System.Drawing.Size(186, 21)
        Me.txtClase.TabIndex = 182
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.Location = New System.Drawing.Point(315, 86)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(65, 15)
        Me.Label71.TabIndex = 181
        Me.Label71.Text = "Supervisor"
        '
        'txtSupervisor
        '
        Me.txtSupervisor.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtSupervisor.Border.Class = "TextBoxBorder"
        Me.txtSupervisor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSupervisor.Enabled = False
        Me.txtSupervisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupervisor.ForeColor = System.Drawing.Color.Black
        Me.txtSupervisor.Location = New System.Drawing.Point(403, 84)
        Me.txtSupervisor.Name = "txtSupervisor"
        Me.txtSupervisor.Size = New System.Drawing.Size(161, 21)
        Me.txtSupervisor.TabIndex = 180
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.Location = New System.Drawing.Point(41, 59)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(79, 15)
        Me.Label68.TabIndex = 179
        Me.Label68.Text = "Tipo de emp."
        '
        'txtTipoEmp
        '
        Me.txtTipoEmp.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtTipoEmp.Border.Class = "TextBoxBorder"
        Me.txtTipoEmp.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTipoEmp.Enabled = False
        Me.txtTipoEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoEmp.ForeColor = System.Drawing.Color.Black
        Me.txtTipoEmp.Location = New System.Drawing.Point(123, 57)
        Me.txtTipoEmp.Name = "txtTipoEmp"
        Me.txtTipoEmp.Size = New System.Drawing.Size(186, 21)
        Me.txtTipoEmp.TabIndex = 178
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.Location = New System.Drawing.Point(314, 59)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(86, 15)
        Me.Label67.TabIndex = 177
        Me.Label67.Text = "Departamento"
        '
        'txtDepto
        '
        Me.txtDepto.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtDepto.Border.Class = "TextBoxBorder"
        Me.txtDepto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDepto.Enabled = False
        Me.txtDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepto.ForeColor = System.Drawing.Color.Black
        Me.txtDepto.Location = New System.Drawing.Point(403, 57)
        Me.txtDepto.Name = "txtDepto"
        Me.txtDepto.Size = New System.Drawing.Size(161, 21)
        Me.txtDepto.TabIndex = 176
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(570, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 15)
        Me.Label3.TabIndex = 193
        Me.Label3.Text = "Planta"
        '
        'txtplanta
        '
        Me.txtplanta.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtplanta.Border.Class = "TextBoxBorder"
        Me.txtplanta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtplanta.Enabled = False
        Me.txtplanta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtplanta.ForeColor = System.Drawing.Color.Black
        Me.txtplanta.Location = New System.Drawing.Point(624, 3)
        Me.txtplanta.Name = "txtplanta"
        Me.txtplanta.Size = New System.Drawing.Size(90, 21)
        Me.txtplanta.TabIndex = 192
        '
        'frmKardexAn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 522)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtplanta)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.txtArea)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.txtCia)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.txtHorario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label69)
        Me.Controls.Add(Me.txtTurno)
        Me.Controls.Add(Me.Label70)
        Me.Controls.Add(Me.txtClase)
        Me.Controls.Add(Me.Label71)
        Me.Controls.Add(Me.txtSupervisor)
        Me.Controls.Add(Me.Label68)
        Me.Controls.Add(Me.txtTipoEmp)
        Me.Controls.Add(Me.Label67)
        Me.Controls.Add(Me.txtDepto)
        Me.Controls.Add(Me.pnlKardex)
        Me.Controls.Add(Me.picFoto)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.txtBaja)
        Me.Controls.Add(Me.lblReingreso)
        Me.Controls.Add(Me.txtAlta)
        Me.Controls.Add(Me.lblBaja)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmKardexAn"
        Me.Text = "Kárdex anual"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlKardex.ResumeLayout(False)
        Me.pnlKardex.PerformLayout()
        Me.pnlAusentismo.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgCalendario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.txtBaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAlta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlKardex As System.Windows.Forms.Panel
    Friend WithEvents pnlAusentismo As DevComponents.DotNetBar.PanelEx
    Friend WithEvents btnCerrarPanel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dgCalendario As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pbCarga As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents cmbAno As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents tmrDelay As System.Windows.Forms.Timer
    Friend WithEvents picFoto As System.Windows.Forms.PictureBox
    Friend WithEvents btnFirst As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrev As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNext As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblEstado As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Private WithEvents txtBaja As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents lblReingreso As System.Windows.Forms.Label
    Private WithEvents txtAlta As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents lblBaja As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLast As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblDato As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblTexto As System.Windows.Forms.Label
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtArea As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents txtCia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtHorario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents txtTurno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents txtClase As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents txtSupervisor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents txtTipoEmp As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents txtDepto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtplanta As DevComponents.DotNetBar.Controls.TextBoxX
End Class
