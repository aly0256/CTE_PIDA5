<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscarConsultas
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscarConsultas))
        Me.txtBusca = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.groupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.dgDatos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.colFolio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFecha = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.colHora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colServicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFamiliar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colConcluida = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtSuperNombre = New System.Windows.Forms.Label()
        Me.txtSuper = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBaja = New System.Windows.Forms.Label()
        Me.txtAlta = New System.Windows.Forms.Label()
        Me.txtDepto = New System.Windows.Forms.Label()
        Me.txtCodComp = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblBaja = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.picFoto = New System.Windows.Forms.PictureBox()
        Me.lblEstado = New DevComponents.DotNetBar.LabelX()
        Me.navPersonal = New DevComponents.DotNetBar.Controls.BindingNavigatorEx(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.BindingNavigatorCountItem = New DevComponents.DotNetBar.LabelItem()
        Me.BindingNavigatorMoveFirstItem = New DevComponents.DotNetBar.ButtonItem()
        Me.BindingNavigatorMovePreviousItem = New DevComponents.DotNetBar.ButtonItem()
        Me.BindingNavigatorPositionItem = New DevComponents.DotNetBar.TextBoxItem()
        Me.BindingNavigatorMoveNextItem = New DevComponents.DotNetBar.ButtonItem()
        Me.BindingNavigatorMoveLastItem = New DevComponents.DotNetBar.ButtonItem()
        Me.txtPlanta = New System.Windows.Forms.Label()
        Me.txtCodPlanta = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTurno = New System.Windows.Forms.Label()
        Me.txtCodTurno = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTipoEmp = New System.Windows.Forms.Label()
        Me.txtCodTipo = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtPuesto = New System.Windows.Forms.Label()
        Me.txtCodPuesto = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtEmergencia = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.Label()
        Me.txtImss = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtCia = New System.Windows.Forms.Label()
        Me.txtCodDepto = New System.Windows.Forms.Label()
        Me.groupPanel1.SuspendLayout()
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.navPersonal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.navPersonal.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBusca
        '
        Me.txtBusca.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtBusca.Border.Class = "TextBoxBorder"
        Me.txtBusca.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBusca.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBusca.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtBusca.Location = New System.Drawing.Point(81, 19)
        Me.txtBusca.Name = "txtBusca"
        Me.txtBusca.Size = New System.Drawing.Size(667, 26)
        Me.txtBusca.TabIndex = 86
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 20)
        Me.Label5.TabIndex = 87
        Me.Label5.Text = "Buscar"
        '
        'groupPanel1
        '
        Me.groupPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.groupPanel1.BackColor = System.Drawing.SystemColors.Window
        Me.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.groupPanel1.Controls.Add(Me.dgDatos)
        Me.groupPanel1.Controls.Add(Me.Panel1)
        Me.groupPanel1.Controls.Add(Me.lblEstado)
        Me.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.groupPanel1.Location = New System.Drawing.Point(10, 52)
        Me.groupPanel1.Name = "groupPanel1"
        Me.groupPanel1.Size = New System.Drawing.Size(743, 337)
        '
        '
        '
        Me.groupPanel1.Style.BackColor = System.Drawing.SystemColors.Window
        Me.groupPanel1.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.groupPanel1.Style.BackColorGradientAngle = 90
        Me.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.groupPanel1.Style.BorderBottomWidth = 1
        Me.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.groupPanel1.Style.BorderLeftWidth = 1
        Me.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.groupPanel1.Style.BorderRightWidth = 1
        Me.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.groupPanel1.Style.BorderTopWidth = 1
        Me.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.groupPanel1.TabIndex = 90
        '
        'dgDatos
        '
        Me.dgDatos.AllowUserToAddRows = False
        Me.dgDatos.AllowUserToDeleteRows = False
        Me.dgDatos.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgDatos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colFolio, Me.colFecha, Me.colHora, Me.colServicio, Me.colFamiliar, Me.colConcluida})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgDatos.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgDatos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgDatos.EnableHeadersVisualStyles = False
        Me.dgDatos.GridColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.dgDatos.Location = New System.Drawing.Point(23, 189)
        Me.dgDatos.MultiSelect = False
        Me.dgDatos.Name = "dgDatos"
        Me.dgDatos.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDatos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgDatos.RowHeadersVisible = False
        Me.dgDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDatos.Size = New System.Drawing.Size(710, 138)
        Me.dgDatos.TabIndex = 69
        '
        'colFolio
        '
        Me.colFolio.DataPropertyName = "folio"
        Me.colFolio.HeaderText = "Folio"
        Me.colFolio.Name = "colFolio"
        Me.colFolio.ReadOnly = True
        Me.colFolio.Width = 75
        '
        'colFecha
        '
        '
        '
        '
        Me.colFecha.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.colFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.colFecha.DataPropertyName = "fecha"
        Me.colFecha.HeaderText = "Fecha"
        Me.colFecha.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.colFecha.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.colFecha.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.colFecha.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.colFecha.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.colFecha.MonthCalendar.DisplayMonth = New Date(2015, 7, 1, 0, 0, 0, 0)
        Me.colFecha.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.colFecha.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.colFecha.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.colFecha.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.colFecha.Name = "colFecha"
        Me.colFecha.ReadOnly = True
        Me.colFecha.Width = 75
        '
        'colHora
        '
        Me.colHora.DataPropertyName = "hora"
        Me.colHora.HeaderText = "Hora"
        Me.colHora.Name = "colHora"
        Me.colHora.ReadOnly = True
        Me.colHora.Width = 75
        '
        'colServicio
        '
        Me.colServicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colServicio.DataPropertyName = "nombre_servicio"
        Me.colServicio.FillWeight = 200.0!
        Me.colServicio.HeaderText = "Servicio"
        Me.colServicio.Name = "colServicio"
        Me.colServicio.ReadOnly = True
        '
        'colFamiliar
        '
        Me.colFamiliar.DataPropertyName = "familiar"
        Me.colFamiliar.HeaderText = "Familiar"
        Me.colFamiliar.Name = "colFamiliar"
        Me.colFamiliar.ReadOnly = True
        Me.colFamiliar.Width = 75
        '
        'colConcluida
        '
        Me.colConcluida.DataPropertyName = "concluida"
        Me.colConcluida.HeaderText = "Concluida"
        Me.colConcluida.Name = "colConcluida"
        Me.colConcluida.ReadOnly = True
        Me.colConcluida.Width = 75
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtReloj)
        Me.Panel1.Controls.Add(Me.LabelX4)
        Me.Panel1.Controls.Add(Me.txtNombre)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.LabelX1)
        Me.Panel1.Controls.Add(Me.picFoto)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(23, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(710, 193)
        Me.Panel1.TabIndex = 71
        '
        'txtReloj
        '
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtReloj.Location = New System.Drawing.Point(130, 3)
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.ReadOnly = True
        Me.txtReloj.Size = New System.Drawing.Size(84, 26)
        Me.txtReloj.TabIndex = 92
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(36, 3)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(84, 23)
        Me.LabelX4.TabIndex = 91
        Me.LabelX4.Text = "Reloj"
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNombre.Location = New System.Drawing.Point(130, 32)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(455, 23)
        Me.txtNombre.TabIndex = 89
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(33, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 17)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "Nombre"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Window
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.txtCodDepto)
        Me.Panel3.Controls.Add(Me.txtCia)
        Me.Panel3.Controls.Add(Me.txtEmergencia)
        Me.Panel3.Controls.Add(Me.Label21)
        Me.Panel3.Controls.Add(Me.txtDireccion)
        Me.Panel3.Controls.Add(Me.txtImss)
        Me.Panel3.Controls.Add(Me.Label26)
        Me.Panel3.Controls.Add(Me.Label27)
        Me.Panel3.Controls.Add(Me.txtPuesto)
        Me.Panel3.Controls.Add(Me.txtCodPuesto)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.txtTurno)
        Me.Panel3.Controls.Add(Me.txtCodTurno)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.txtTipoEmp)
        Me.Panel3.Controls.Add(Me.txtCodTipo)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.txtPlanta)
        Me.Panel3.Controls.Add(Me.txtCodPlanta)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.txtSuperNombre)
        Me.Panel3.Controls.Add(Me.txtSuper)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.txtBaja)
        Me.Panel3.Controls.Add(Me.txtAlta)
        Me.Panel3.Controls.Add(Me.txtDepto)
        Me.Panel3.Controls.Add(Me.txtCodComp)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.lblBaja)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Location = New System.Drawing.Point(35, 61)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(550, 122)
        Me.Panel3.TabIndex = 88
        '
        'txtSuperNombre
        '
        Me.txtSuperNombre.AutoSize = True
        Me.txtSuperNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSuperNombre.Location = New System.Drawing.Point(120, 51)
        Me.txtSuperNombre.Name = "txtSuperNombre"
        Me.txtSuperNombre.Size = New System.Drawing.Size(16, 13)
        Me.txtSuperNombre.TabIndex = 94
        Me.txtSuperNombre.Text = "---"
        '
        'txtSuper
        '
        Me.txtSuper.AutoSize = True
        Me.txtSuper.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSuper.Location = New System.Drawing.Point(98, 51)
        Me.txtSuper.Name = "txtSuper"
        Me.txtSuper.Size = New System.Drawing.Size(16, 13)
        Me.txtSuper.TabIndex = 93
        Me.txtSuper.Text = "---"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Window
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 92
        Me.Label7.Text = "Puesto"
        '
        'txtBaja
        '
        Me.txtBaja.AutoSize = True
        Me.txtBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBaja.Location = New System.Drawing.Point(417, 36)
        Me.txtBaja.Name = "txtBaja"
        Me.txtBaja.Size = New System.Drawing.Size(16, 13)
        Me.txtBaja.TabIndex = 91
        Me.txtBaja.Text = "---"
        '
        'txtAlta
        '
        Me.txtAlta.AutoSize = True
        Me.txtAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlta.Location = New System.Drawing.Point(414, 8)
        Me.txtAlta.Name = "txtAlta"
        Me.txtAlta.Size = New System.Drawing.Size(16, 13)
        Me.txtAlta.TabIndex = 90
        Me.txtAlta.Text = "---"
        '
        'txtDepto
        '
        Me.txtDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepto.Location = New System.Drawing.Point(148, 34)
        Me.txtDepto.Name = "txtDepto"
        Me.txtDepto.Size = New System.Drawing.Size(152, 15)
        Me.txtDepto.TabIndex = 89
        Me.txtDepto.Text = "---"
        '
        'txtCodComp
        '
        Me.txtCodComp.AutoSize = True
        Me.txtCodComp.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodComp.Location = New System.Drawing.Point(98, 7)
        Me.txtCodComp.Name = "txtCodComp"
        Me.txtCodComp.Size = New System.Drawing.Size(16, 13)
        Me.txtCodComp.TabIndex = 88
        Me.txtCodComp.Text = "---"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Compañía"
        '
        'lblBaja
        '
        Me.lblBaja.AutoSize = True
        Me.lblBaja.BackColor = System.Drawing.SystemColors.Window
        Me.lblBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBaja.Location = New System.Drawing.Point(310, 36)
        Me.lblBaja.Name = "lblBaja"
        Me.lblBaja.Size = New System.Drawing.Size(88, 13)
        Me.lblBaja.TabIndex = 63
        Me.lblBaja.Text = "Fecha de baja"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(310, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Fecha de alta"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "Departamento"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Green
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Dock = System.Windows.Forms.DockStyle.Left
        Me.LabelX1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.SystemColors.Window
        Me.LabelX1.Location = New System.Drawing.Point(0, 0)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(29, 193)
        Me.LabelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LabelX1.TabIndex = 66
        Me.LabelX1.Text = "INACTIVO"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Center
        Me.LabelX1.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.LabelX1.VerticalTextTopUp = False
        '
        'picFoto
        '
        Me.picFoto.BackColor = System.Drawing.SystemColors.Window
        Me.picFoto.Dock = System.Windows.Forms.DockStyle.Right
        Me.picFoto.ErrorImage = Global.PIDA.My.Resources.Resources.NoFoto
        Me.picFoto.Image = Global.PIDA.My.Resources.Resources.NoFoto
        Me.picFoto.Location = New System.Drawing.Point(591, 0)
        Me.picFoto.Name = "picFoto"
        Me.picFoto.Size = New System.Drawing.Size(119, 193)
        Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picFoto.TabIndex = 70
        Me.picFoto.TabStop = False
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.SystemColors.ActiveCaption
        '
        '
        '
        Me.lblEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblEstado.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblEstado.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.Black
        Me.lblEstado.Location = New System.Drawing.Point(0, 0)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(23, 327)
        Me.lblEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblEstado.TabIndex = 59
        Me.lblEstado.Text = "CONSULTAS"
        Me.lblEstado.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblEstado.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.lblEstado.VerticalTextTopUp = False
        '
        'navPersonal
        '
        Me.navPersonal.AntiAlias = True
        Me.navPersonal.BackColor = System.Drawing.SystemColors.ControlLight
        Me.navPersonal.Controls.Add(Me.Panel2)
        Me.navPersonal.CountLabel = Me.BindingNavigatorCountItem
        Me.navPersonal.CountLabelFormat = "of {0}"
        Me.navPersonal.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.navPersonal.DoubleClickBehavior = DevComponents.DotNetBar.eDoubleClickBarBehavior.None
        Me.navPersonal.FadeEffect = True
        Me.navPersonal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.navPersonal.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem})
        Me.navPersonal.Location = New System.Drawing.Point(0, 395)
        Me.navPersonal.MoveFirstButton = Me.BindingNavigatorMoveFirstItem
        Me.navPersonal.MoveLastButton = Me.BindingNavigatorMoveLastItem
        Me.navPersonal.MoveNextButton = Me.BindingNavigatorMoveNextItem
        Me.navPersonal.MovePreviousButton = Me.BindingNavigatorMovePreviousItem
        Me.navPersonal.Name = "navPersonal"
        Me.navPersonal.PositionTextBox = Me.BindingNavigatorPositionItem
        Me.navPersonal.Size = New System.Drawing.Size(765, 28)
        Me.navPersonal.Stretch = True
        Me.navPersonal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.navPersonal.TabIndex = 91
        Me.navPersonal.TabStop = False
        Me.navPersonal.ThemeAware = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.ButtonX2)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.ButtonX3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(560, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(205, 28)
        Me.Panel2.TabIndex = 53
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(41, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(4, 28)
        Me.Panel4.TabIndex = 55
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.CausesValidation = False
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX2.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.ButtonX2.Location = New System.Drawing.Point(45, 0)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(78, 28)
        Me.ButtonX2.TabIndex = 41
        Me.ButtonX2.Text = "Aceptar"
        '
        'Panel5
        '
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel5.Location = New System.Drawing.Point(123, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(4, 28)
        Me.Panel5.TabIndex = 56
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.CausesValidation = False
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX3.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonX3.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX3.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.ButtonX3.Location = New System.Drawing.Point(127, 0)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(78, 28)
        Me.ButtonX3.TabIndex = 52
        Me.ButtonX3.Text = "Cancelar"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ThemeAware = True
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BindingNavigatorMoveFirstItem.Image = Global.PIDA.My.Resources.Resources.First16
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.Text = "Inicio"
        Me.BindingNavigatorMoveFirstItem.ThemeAware = True
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BindingNavigatorMovePreviousItem.Image = Global.PIDA.My.Resources.Resources.Prev16
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.Text = "Anterior"
        Me.BindingNavigatorMovePreviousItem.ThemeAware = True
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.BeginGroup = True
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.TextBoxWidth = 54
        Me.BindingNavigatorPositionItem.ThemeAware = True
        Me.BindingNavigatorPositionItem.WatermarkColor = System.Drawing.SystemColors.GrayText
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.BeginGroup = True
        Me.BindingNavigatorMoveNextItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BindingNavigatorMoveNextItem.Image = Global.PIDA.My.Resources.Resources.Next16
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.Text = "Siguiente"
        Me.BindingNavigatorMoveNextItem.ThemeAware = True
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BindingNavigatorMoveLastItem.Image = Global.PIDA.My.Resources.Resources.Last16
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.Text = "Final"
        Me.BindingNavigatorMoveLastItem.ThemeAware = True
        '
        'txtPlanta
        '
        Me.txtPlanta.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlanta.Location = New System.Drawing.Point(120, 21)
        Me.txtPlanta.Name = "txtPlanta"
        Me.txtPlanta.Size = New System.Drawing.Size(143, 13)
        Me.txtPlanta.TabIndex = 97
        Me.txtPlanta.Text = "---"
        '
        'txtCodPlanta
        '
        Me.txtCodPlanta.AutoSize = True
        Me.txtCodPlanta.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodPlanta.Location = New System.Drawing.Point(98, 21)
        Me.txtCodPlanta.Name = "txtCodPlanta"
        Me.txtCodPlanta.Size = New System.Drawing.Size(16, 13)
        Me.txtCodPlanta.TabIndex = 96
        Me.txtCodPlanta.Text = "---"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Window
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(4, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 13)
        Me.Label9.TabIndex = 95
        Me.Label9.Text = "Planta"
        '
        'txtTurno
        '
        Me.txtTurno.AutoSize = True
        Me.txtTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTurno.Location = New System.Drawing.Point(120, 83)
        Me.txtTurno.Name = "txtTurno"
        Me.txtTurno.Size = New System.Drawing.Size(16, 13)
        Me.txtTurno.TabIndex = 103
        Me.txtTurno.Text = "---"
        '
        'txtCodTurno
        '
        Me.txtCodTurno.AutoSize = True
        Me.txtCodTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodTurno.Location = New System.Drawing.Point(98, 83)
        Me.txtCodTurno.Name = "txtCodTurno"
        Me.txtCodTurno.Size = New System.Drawing.Size(16, 13)
        Me.txtCodTurno.TabIndex = 102
        Me.txtCodTurno.Text = "---"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Window
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 13)
        Me.Label12.TabIndex = 101
        Me.Label12.Text = "Supervisor"
        '
        'txtTipoEmp
        '
        Me.txtTipoEmp.AutoSize = True
        Me.txtTipoEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoEmp.Location = New System.Drawing.Point(120, 67)
        Me.txtTipoEmp.Name = "txtTipoEmp"
        Me.txtTipoEmp.Size = New System.Drawing.Size(16, 13)
        Me.txtTipoEmp.TabIndex = 100
        Me.txtTipoEmp.Text = "---"
        '
        'txtCodTipo
        '
        Me.txtCodTipo.AutoSize = True
        Me.txtCodTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodTipo.Location = New System.Drawing.Point(98, 67)
        Me.txtCodTipo.Name = "txtCodTipo"
        Me.txtCodTipo.Size = New System.Drawing.Size(16, 13)
        Me.txtCodTipo.TabIndex = 99
        Me.txtCodTipo.Text = "---"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.SystemColors.Window
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(4, 65)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(90, 13)
        Me.Label15.TabIndex = 98
        Me.Label15.Text = "Tipo empleado"
        '
        'txtPuesto
        '
        Me.txtPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPuesto.Location = New System.Drawing.Point(120, 98)
        Me.txtPuesto.Name = "txtPuesto"
        Me.txtPuesto.Size = New System.Drawing.Size(143, 15)
        Me.txtPuesto.TabIndex = 106
        Me.txtPuesto.Text = "---"
        '
        'txtCodPuesto
        '
        Me.txtCodPuesto.AutoSize = True
        Me.txtCodPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodPuesto.Location = New System.Drawing.Point(98, 98)
        Me.txtCodPuesto.Name = "txtCodPuesto"
        Me.txtCodPuesto.Size = New System.Drawing.Size(16, 13)
        Me.txtCodPuesto.TabIndex = 105
        Me.txtCodPuesto.Text = "---"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.SystemColors.Window
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(4, 82)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(40, 13)
        Me.Label18.TabIndex = 104
        Me.Label18.Text = "Turno"
        '
        'txtEmergencia
        '
        Me.txtEmergencia.AutoSize = True
        Me.txtEmergencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmergencia.Location = New System.Drawing.Point(417, 98)
        Me.txtEmergencia.Name = "txtEmergencia"
        Me.txtEmergencia.Size = New System.Drawing.Size(16, 13)
        Me.txtEmergencia.TabIndex = 114
        Me.txtEmergencia.Text = "---"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.SystemColors.Window
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(310, 82)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(61, 13)
        Me.Label21.TabIndex = 113
        Me.Label21.Text = "Dirección"
        '
        'txtDireccion
        '
        Me.txtDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccion.Location = New System.Drawing.Point(375, 83)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(170, 13)
        Me.txtDireccion.TabIndex = 111
        Me.txtDireccion.Text = "---"
        '
        'txtImss
        '
        Me.txtImss.AutoSize = True
        Me.txtImss.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImss.Location = New System.Drawing.Point(376, 65)
        Me.txtImss.Name = "txtImss"
        Me.txtImss.Size = New System.Drawing.Size(16, 13)
        Me.txtImss.TabIndex = 109
        Me.txtImss.Text = "---"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.SystemColors.Window
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(312, 63)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(32, 13)
        Me.Label26.TabIndex = 108
        Me.Label26.Text = "Imss"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.SystemColors.Window
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(310, 100)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(99, 13)
        Me.Label27.TabIndex = 107
        Me.Label27.Text = "Tel. Emergencia"
        '
        'txtCia
        '
        Me.txtCia.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCia.Location = New System.Drawing.Point(120, 7)
        Me.txtCia.Name = "txtCia"
        Me.txtCia.Size = New System.Drawing.Size(143, 14)
        Me.txtCia.TabIndex = 115
        Me.txtCia.Text = "---"
        '
        'txtCodDepto
        '
        Me.txtCodDepto.AutoSize = True
        Me.txtCodDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodDepto.Location = New System.Drawing.Point(98, 34)
        Me.txtCodDepto.Name = "txtCodDepto"
        Me.txtCodDepto.Size = New System.Drawing.Size(16, 13)
        Me.txtCodDepto.TabIndex = 116
        Me.txtCodDepto.Text = "---"
        '
        'frmBuscarConsultas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(765, 423)
        Me.Controls.Add(Me.navPersonal)
        Me.Controls.Add(Me.txtBusca)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.groupPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBuscarConsultas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Buscar consultas"
        Me.groupPanel1.ResumeLayout(False)
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.navPersonal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.navPersonal.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtBusca As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents groupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lblEstado As DevComponents.DotNetBar.LabelX
    Friend WithEvents dgDatos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents picFoto As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtBaja As System.Windows.Forms.Label
    Friend WithEvents txtAlta As System.Windows.Forms.Label
    Friend WithEvents txtDepto As System.Windows.Forms.Label
    Friend WithEvents txtCodComp As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblBaja As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents navPersonal As DevComponents.DotNetBar.Controls.BindingNavigatorEx
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents BindingNavigatorCountItem As DevComponents.DotNetBar.LabelItem
    Friend WithEvents BindingNavigatorMoveFirstItem As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BindingNavigatorMovePreviousItem As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BindingNavigatorPositionItem As DevComponents.DotNetBar.TextBoxItem
    Friend WithEvents BindingNavigatorMoveNextItem As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BindingNavigatorMoveLastItem As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents colFolio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFecha As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents colHora As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colServicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFamiliar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colConcluida As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents txtSuper As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSuperNombre As System.Windows.Forms.Label
    Friend WithEvents txtEmergencia As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtDireccion As System.Windows.Forms.Label
    Friend WithEvents txtImss As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtPuesto As System.Windows.Forms.Label
    Friend WithEvents txtCodPuesto As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtTurno As System.Windows.Forms.Label
    Friend WithEvents txtCodTurno As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTipoEmp As System.Windows.Forms.Label
    Friend WithEvents txtCodTipo As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtPlanta As System.Windows.Forms.Label
    Friend WithEvents txtCodPlanta As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCia As System.Windows.Forms.Label
    Friend WithEvents txtCodDepto As System.Windows.Forms.Label
End Class
