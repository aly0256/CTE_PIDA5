<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditarExcepcionHorarios
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
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblEstado = New DevComponents.DotNetBar.LabelX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.gpDatos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.pnlComentario = New System.Windows.Forms.Panel()
        Me.txtComentario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblComentario = New System.Windows.Forms.Label()
        Me.pnlNumPeriodos = New System.Windows.Forms.Panel()
        Me.cmbHorario = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.colCodHora = New DevComponents.AdvTree.ColumnHeader()
        Me.colNombreHora = New DevComponents.AdvTree.ColumnHeader()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlMonto = New System.Windows.Forms.Panel()
        Me.pnlFechaIncidencia = New System.Windows.Forms.Panel()
        Me.txtFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtHorario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupBox1.SuspendLayout()
        Me.gpDatos.SuspendLayout()
        Me.pnlComentario.SuspendLayout()
        Me.pnlNumPeriodos.SuspendLayout()
        Me.pnlFechaIncidencia.SuspendLayout()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(37, 16)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(300, 40)
        Me.ReflectionLabel1.TabIndex = 1
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>EXCEPCIONES HORARIO</b></font>"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LabelX4)
        Me.GroupBox1.Controls.Add(Me.txtReloj)
        Me.GroupBox1.Location = New System.Drawing.Point(340, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(171, 49)
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
        Me.txtReloj.Size = New System.Drawing.Size(84, 26)
        Me.txtReloj.TabIndex = 1
        Me.txtReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.lblEstado.Size = New System.Drawing.Size(29, 91)
        Me.lblEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblEstado.TabIndex = 0
        Me.lblEstado.Text = "ACTIVO"
        Me.lblEstado.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblEstado.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.lblEstado.VerticalTextTopUp = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(39, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 15)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Nombre"
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
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.Color.Black
        Me.txtNombre.Location = New System.Drawing.Point(39, 78)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(368, 21)
        Me.txtNombre.TabIndex = 4
        '
        'gpDatos
        '
        Me.gpDatos.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpDatos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpDatos.Controls.Add(Me.pnlComentario)
        Me.gpDatos.Controls.Add(Me.pnlNumPeriodos)
        Me.gpDatos.Controls.Add(Me.pnlMonto)
        Me.gpDatos.Controls.Add(Me.pnlFechaIncidencia)
        Me.gpDatos.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpDatos.Location = New System.Drawing.Point(9, 105)
        Me.gpDatos.Name = "gpDatos"
        Me.gpDatos.Size = New System.Drawing.Size(502, 160)
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
        Me.pnlComentario.Location = New System.Drawing.Point(0, 70)
        Me.pnlComentario.Name = "pnlComentario"
        Me.pnlComentario.Padding = New System.Windows.Forms.Padding(4)
        Me.pnlComentario.Size = New System.Drawing.Size(500, 85)
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
        Me.txtComentario.Size = New System.Drawing.Size(374, 77)
        Me.txtComentario.TabIndex = 1
        '
        'lblComentario
        '
        Me.lblComentario.BackColor = System.Drawing.SystemColors.Window
        Me.lblComentario.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblComentario.Location = New System.Drawing.Point(4, 4)
        Me.lblComentario.Name = "lblComentario"
        Me.lblComentario.Padding = New System.Windows.Forms.Padding(0, 6, 0, 0)
        Me.lblComentario.Size = New System.Drawing.Size(115, 77)
        Me.lblComentario.TabIndex = 0
        Me.lblComentario.Text = "Comentario"
        '
        'pnlNumPeriodos
        '
        Me.pnlNumPeriodos.BackColor = System.Drawing.Color.White
        Me.pnlNumPeriodos.Controls.Add(Me.cmbHorario)
        Me.pnlNumPeriodos.Controls.Add(Me.Label3)
        Me.pnlNumPeriodos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNumPeriodos.Location = New System.Drawing.Point(0, 40)
        Me.pnlNumPeriodos.Name = "pnlNumPeriodos"
        Me.pnlNumPeriodos.Padding = New System.Windows.Forms.Padding(4)
        Me.pnlNumPeriodos.Size = New System.Drawing.Size(500, 30)
        Me.pnlNumPeriodos.TabIndex = 8
        '
        'cmbHorario
        '
        Me.cmbHorario.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbHorario.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbHorario.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbHorario.ButtonDropDown.Visible = True
        Me.cmbHorario.Columns.Add(Me.colCodHora)
        Me.cmbHorario.Columns.Add(Me.colNombreHora)
        Me.cmbHorario.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmbHorario.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbHorario.Location = New System.Drawing.Point(119, 4)
        Me.cmbHorario.Name = "cmbHorario"
        Me.cmbHorario.Size = New System.Drawing.Size(374, 22)
        Me.cmbHorario.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbHorario.TabIndex = 1
        Me.cmbHorario.ValueMember = "cod_hora"
        '
        'colCodHora
        '
        Me.colCodHora.DataFieldName = "cod_hora"
        Me.colCodHora.Name = "colCodHora"
        Me.colCodHora.Text = "Column"
        Me.colCodHora.Width.Absolute = 50
        '
        'colNombreHora
        '
        Me.colNombreHora.DataFieldName = "nombre"
        Me.colNombreHora.Name = "colNombreHora"
        Me.colNombreHora.StretchToFill = True
        Me.colNombreHora.Text = "Column"
        Me.colNombreHora.Width.Absolute = 150
        Me.colNombreHora.Width.AutoSize = True
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Location = New System.Drawing.Point(4, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 22)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Horario temporal"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlMonto
        '
        Me.pnlMonto.BackColor = System.Drawing.Color.White
        Me.pnlMonto.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlMonto.Location = New System.Drawing.Point(0, 30)
        Me.pnlMonto.Name = "pnlMonto"
        Me.pnlMonto.Padding = New System.Windows.Forms.Padding(4)
        Me.pnlMonto.Size = New System.Drawing.Size(500, 10)
        Me.pnlMonto.TabIndex = 7
        '
        'pnlFechaIncidencia
        '
        Me.pnlFechaIncidencia.BackColor = System.Drawing.Color.White
        Me.pnlFechaIncidencia.Controls.Add(Me.txtFecha)
        Me.pnlFechaIncidencia.Controls.Add(Me.Label13)
        Me.pnlFechaIncidencia.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFechaIncidencia.Location = New System.Drawing.Point(0, 0)
        Me.pnlFechaIncidencia.Name = "pnlFechaIncidencia"
        Me.pnlFechaIncidencia.Padding = New System.Windows.Forms.Padding(4)
        Me.pnlFechaIncidencia.Size = New System.Drawing.Size(500, 30)
        Me.pnlFechaIncidencia.TabIndex = 4
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
        Me.txtFecha.Size = New System.Drawing.Size(84, 20)
        Me.txtFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFecha.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Window
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label13.Location = New System.Drawing.Point(4, 4)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(115, 22)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Fecha"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnAceptar.Location = New System.Drawing.Point(351, 271)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "Aceptar"
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
        Me.btnCerrar.Location = New System.Drawing.Point(436, 271)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.Text = "Cancelar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(416, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Horario"
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
        Me.txtHorario.Location = New System.Drawing.Point(419, 78)
        Me.txtHorario.Name = "txtHorario"
        Me.txtHorario.ReadOnly = True
        Me.txtHorario.Size = New System.Drawing.Size(84, 21)
        Me.txtHorario.TabIndex = 6
        '
        'frmEditarExcepcionHorarios
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(522, 304)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtHorario)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.gpDatos)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtNombre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditarExcepcionHorarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar/Agregar"
        Me.GroupBox1.ResumeLayout(False)
        Me.gpDatos.ResumeLayout(False)
        Me.pnlComentario.ResumeLayout(False)
        Me.pnlNumPeriodos.ResumeLayout(False)
        Me.pnlFechaIncidencia.ResumeLayout(False)
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblEstado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents gpDatos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents pnlComentario As System.Windows.Forms.Panel
    Friend WithEvents txtComentario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblComentario As System.Windows.Forms.Label
    Friend WithEvents pnlMonto As System.Windows.Forms.Panel
    Friend WithEvents pnlFechaIncidencia As System.Windows.Forms.Panel
    Friend WithEvents txtFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents pnlNumPeriodos As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbHorario As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtHorario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents colCodHora As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colNombreHora As DevComponents.AdvTree.ColumnHeader
End Class
