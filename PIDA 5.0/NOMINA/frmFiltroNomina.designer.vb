<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFiltroNomina
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFiltroNomina))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAgregar = New DevComponents.DotNetBar.ButtonX()
        Me.btnLimpiar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.lstFiltros = New System.Windows.Forms.ListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.pnlNumerico = New System.Windows.Forms.Panel()
        Me.txtExceptoNum2 = New DevComponents.Editors.DoubleInput()
        Me.txtExceptoNum1 = New DevComponents.Editors.DoubleInput()
        Me.txtNum2 = New DevComponents.Editors.DoubleInput()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.chkExceptoNum = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkIncluyendoNum = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtNum1 = New DevComponents.Editors.DoubleInput()
        Me.pnlFechas = New System.Windows.Forms.Panel()
        Me.txtExceptoFecha1 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.txtExceptoFecha2 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFecha2 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkExceptoFecha = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkIncluyeFecha = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtFecha1 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.dgLista = New System.Windows.Forms.DataGridView()
        Me.colReloj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbCampos = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.NombreCampo = New DevComponents.AdvTree.ColumnHeader()
        Me.CodCampo = New DevComponents.AdvTree.ColumnHeader()
        Me.tipo = New DevComponents.AdvTree.ColumnHeader()
        Me.Tabla = New DevComponents.AdvTree.ColumnHeader()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlCaracter = New System.Windows.Forms.Panel()
        Me.chkTodosExcepto = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkTodosIncluyendo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkNoBlanco = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkIncluyendo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtExcepto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.chkBlanco = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lstIncluyendo = New System.Windows.Forms.CheckedListBox()
        Me.txtIncluyendo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.chkExcepto = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lstExcepto = New System.Windows.Forms.CheckedListBox()
        Me.Codigo = New DevComponents.AdvTree.ColumnHeader()
        Me.Nombre = New DevComponents.AdvTree.ColumnHeader()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ReflectionLabel2 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.pnlNumerico.SuspendLayout()
        CType(Me.txtExceptoNum2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtExceptoNum1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNum2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNum1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFechas.SuspendLayout()
        CType(Me.txtExceptoFecha1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtExceptoFecha2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.pnlCaracter.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Location = New System.Drawing.Point(3, 410)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Filtros vigentes"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnLimpiar)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.btnAgregar)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(10, 559)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(10, 0, 10, 8)
        Me.GroupBox1.Size = New System.Drawing.Size(849, 47)
        Me.GroupBox1.TabIndex = 74
        Me.GroupBox1.TabStop = False
        '
        'btnAgregar
        '
        Me.btnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAgregar.CausesValidation = False
        Me.btnAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAgregar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = Global.PIDA.My.Resources.Resources.add_
        Me.btnAgregar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnAgregar.Location = New System.Drawing.Point(10, 13)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(102, 26)
        Me.btnAgregar.TabIndex = 3
        Me.btnAgregar.Text = "Agregar filtro"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLimpiar.CausesValidation = False
        Me.btnLimpiar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnLimpiar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.Image = Global.PIDA.My.Resources.Resources.cancel_
        Me.btnLimpiar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnLimpiar.Location = New System.Drawing.Point(122, 13)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(102, 26)
        Me.btnLimpiar.TabIndex = 0
        Me.btnLimpiar.Text = "Limpiar filtros"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.salir_
        Me.btnCancelar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCancelar.ImageTextSpacing = 3
        Me.btnCancelar.Location = New System.Drawing.Point(739, 13)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(100, 26)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cerrar"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel2.Controls.Add(Me.lstFiltros)
        Me.GroupPanel2.Controls.Add(Me.GroupBox3)
        Me.GroupPanel2.Controls.Add(Me.Label2)
        Me.GroupPanel2.Controls.Add(Me.GroupBox2)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel2.Location = New System.Drawing.Point(10, 63)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(849, 496)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor = System.Drawing.SystemColors.Window
        Me.GroupPanel2.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 4
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 95
        '
        'lstFiltros
        '
        Me.lstFiltros.FormattingEnabled = True
        Me.lstFiltros.Location = New System.Drawing.Point(4, 426)
        Me.lstFiltros.Name = "lstFiltros"
        Me.lstFiltros.Size = New System.Drawing.Size(826, 56)
        Me.lstFiltros.TabIndex = 3
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.Window
        Me.GroupBox3.Controls.Add(Me.pnlNumerico)
        Me.GroupBox3.Controls.Add(Me.pnlFechas)
        Me.GroupBox3.Controls.Add(Me.lblRegistros)
        Me.GroupBox3.Controls.Add(Me.dgLista)
        Me.GroupBox3.Location = New System.Drawing.Point(437, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(393, 405)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Resultado"
        '
        'pnlNumerico
        '
        Me.pnlNumerico.Controls.Add(Me.txtExceptoNum2)
        Me.pnlNumerico.Controls.Add(Me.txtExceptoNum1)
        Me.pnlNumerico.Controls.Add(Me.txtNum2)
        Me.pnlNumerico.Controls.Add(Me.Label9)
        Me.pnlNumerico.Controls.Add(Me.Label10)
        Me.pnlNumerico.Controls.Add(Me.chkExceptoNum)
        Me.pnlNumerico.Controls.Add(Me.Label7)
        Me.pnlNumerico.Controls.Add(Me.Label8)
        Me.pnlNumerico.Controls.Add(Me.chkIncluyendoNum)
        Me.pnlNumerico.Controls.Add(Me.txtNum1)
        Me.pnlNumerico.Location = New System.Drawing.Point(69, 194)
        Me.pnlNumerico.Name = "pnlNumerico"
        Me.pnlNumerico.Size = New System.Drawing.Size(306, 161)
        Me.pnlNumerico.TabIndex = 1
        Me.pnlNumerico.Visible = False
        '
        'txtExceptoNum2
        '
        '
        '
        '
        Me.txtExceptoNum2.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtExceptoNum2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtExceptoNum2.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtExceptoNum2.Enabled = False
        Me.txtExceptoNum2.Increment = 1.0R
        Me.txtExceptoNum2.Location = New System.Drawing.Point(108, 133)
        Me.txtExceptoNum2.MaxValue = 999999.0R
        Me.txtExceptoNum2.MinValue = 0.0R
        Me.txtExceptoNum2.Name = "txtExceptoNum2"
        Me.txtExceptoNum2.ShowUpDown = True
        Me.txtExceptoNum2.Size = New System.Drawing.Size(118, 20)
        Me.txtExceptoNum2.TabIndex = 9
        '
        'txtExceptoNum1
        '
        '
        '
        '
        Me.txtExceptoNum1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtExceptoNum1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtExceptoNum1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtExceptoNum1.Enabled = False
        Me.txtExceptoNum1.Increment = 1.0R
        Me.txtExceptoNum1.Location = New System.Drawing.Point(108, 108)
        Me.txtExceptoNum1.MaxValue = 999999.0R
        Me.txtExceptoNum1.MinValue = 0.0R
        Me.txtExceptoNum1.Name = "txtExceptoNum1"
        Me.txtExceptoNum1.ShowUpDown = True
        Me.txtExceptoNum1.Size = New System.Drawing.Size(118, 20)
        Me.txtExceptoNum1.TabIndex = 7
        '
        'txtNum2
        '
        '
        '
        '
        Me.txtNum2.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtNum2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNum2.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtNum2.Enabled = False
        Me.txtNum2.Increment = 1.0R
        Me.txtNum2.Location = New System.Drawing.Point(108, 50)
        Me.txtNum2.MaxValue = 999999.0R
        Me.txtNum2.MinValue = 0.0R
        Me.txtNum2.Name = "txtNum2"
        Me.txtNum2.ShowUpDown = True
        Me.txtNum2.Size = New System.Drawing.Size(118, 20)
        Me.txtNum2.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(24, 137)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "y el valor"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(24, 112)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 13)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "Entre el valor"
        '
        'chkExceptoNum
        '
        Me.chkExceptoNum.AutoSize = True
        '
        '
        '
        Me.chkExceptoNum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkExceptoNum.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkExceptoNum.Location = New System.Drawing.Point(3, 87)
        Me.chkExceptoNum.Name = "chkExceptoNum"
        Me.chkExceptoNum.Size = New System.Drawing.Size(124, 15)
        Me.chkExceptoNum.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkExceptoNum.TabIndex = 5
        Me.chkExceptoNum.Text = "Esté fuera del rango:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(24, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "y el valor"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(24, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Entre el valor"
        '
        'chkIncluyendoNum
        '
        Me.chkIncluyendoNum.AutoSize = True
        '
        '
        '
        Me.chkIncluyendoNum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkIncluyendoNum.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkIncluyendoNum.Location = New System.Drawing.Point(3, 3)
        Me.chkIncluyendoNum.Name = "chkIncluyendoNum"
        Me.chkIncluyendoNum.Size = New System.Drawing.Size(149, 15)
        Me.chkIncluyendoNum.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkIncluyendoNum.TabIndex = 0
        Me.chkIncluyendoNum.Text = "Se encuentre en el rango:"
        '
        'txtNum1
        '
        '
        '
        '
        Me.txtNum1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtNum1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNum1.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtNum1.Enabled = False
        Me.txtNum1.Increment = 1.0R
        Me.txtNum1.Location = New System.Drawing.Point(108, 25)
        Me.txtNum1.MaxValue = 999999.0R
        Me.txtNum1.MinValue = 0.0R
        Me.txtNum1.Name = "txtNum1"
        Me.txtNum1.ShowUpDown = True
        Me.txtNum1.Size = New System.Drawing.Size(118, 20)
        Me.txtNum1.TabIndex = 2
        '
        'pnlFechas
        '
        Me.pnlFechas.Controls.Add(Me.txtExceptoFecha1)
        Me.pnlFechas.Controls.Add(Me.txtExceptoFecha2)
        Me.pnlFechas.Controls.Add(Me.Label5)
        Me.pnlFechas.Controls.Add(Me.Label6)
        Me.pnlFechas.Controls.Add(Me.txtFecha2)
        Me.pnlFechas.Controls.Add(Me.Label4)
        Me.pnlFechas.Controls.Add(Me.Label3)
        Me.pnlFechas.Controls.Add(Me.chkExceptoFecha)
        Me.pnlFechas.Controls.Add(Me.chkIncluyeFecha)
        Me.pnlFechas.Controls.Add(Me.txtFecha1)
        Me.pnlFechas.Location = New System.Drawing.Point(69, 22)
        Me.pnlFechas.Name = "pnlFechas"
        Me.pnlFechas.Size = New System.Drawing.Size(306, 161)
        Me.pnlFechas.TabIndex = 3
        Me.pnlFechas.Visible = False
        '
        'txtExceptoFecha1
        '
        '
        '
        '
        Me.txtExceptoFecha1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtExceptoFecha1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtExceptoFecha1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtExceptoFecha1.ButtonDropDown.Visible = True
        Me.txtExceptoFecha1.Enabled = False
        Me.txtExceptoFecha1.IsPopupCalendarOpen = False
        Me.txtExceptoFecha1.Location = New System.Drawing.Point(108, 108)
        '
        '
        '
        Me.txtExceptoFecha1.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtExceptoFecha1.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtExceptoFecha1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtExceptoFecha1.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtExceptoFecha1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtExceptoFecha1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtExceptoFecha1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtExceptoFecha1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtExceptoFecha1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtExceptoFecha1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtExceptoFecha1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtExceptoFecha1.MonthCalendar.DisplayMonth = New Date(2012, 12, 1, 0, 0, 0, 0)
        Me.txtExceptoFecha1.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtExceptoFecha1.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtExceptoFecha1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtExceptoFecha1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtExceptoFecha1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtExceptoFecha1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtExceptoFecha1.MonthCalendar.TodayButtonVisible = True
        Me.txtExceptoFecha1.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtExceptoFecha1.Name = "txtExceptoFecha1"
        Me.txtExceptoFecha1.Size = New System.Drawing.Size(118, 20)
        Me.txtExceptoFecha1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtExceptoFecha1.TabIndex = 7
        '
        'txtExceptoFecha2
        '
        '
        '
        '
        Me.txtExceptoFecha2.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtExceptoFecha2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtExceptoFecha2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtExceptoFecha2.ButtonDropDown.Visible = True
        Me.txtExceptoFecha2.Enabled = False
        Me.txtExceptoFecha2.IsPopupCalendarOpen = False
        Me.txtExceptoFecha2.Location = New System.Drawing.Point(108, 133)
        '
        '
        '
        Me.txtExceptoFecha2.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtExceptoFecha2.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtExceptoFecha2.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtExceptoFecha2.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtExceptoFecha2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtExceptoFecha2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtExceptoFecha2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtExceptoFecha2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtExceptoFecha2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtExceptoFecha2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtExceptoFecha2.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtExceptoFecha2.MonthCalendar.DisplayMonth = New Date(2012, 12, 1, 0, 0, 0, 0)
        Me.txtExceptoFecha2.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtExceptoFecha2.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtExceptoFecha2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtExceptoFecha2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtExceptoFecha2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtExceptoFecha2.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtExceptoFecha2.MonthCalendar.TodayButtonVisible = True
        Me.txtExceptoFecha2.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtExceptoFecha2.Name = "txtExceptoFecha2"
        Me.txtExceptoFecha2.Size = New System.Drawing.Size(118, 20)
        Me.txtExceptoFecha2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtExceptoFecha2.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(24, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "y el día"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(24, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Entre el día"
        '
        'txtFecha2
        '
        '
        '
        '
        Me.txtFecha2.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFecha2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha2.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtFecha2.ButtonDropDown.Visible = True
        Me.txtFecha2.Enabled = False
        Me.txtFecha2.IsPopupCalendarOpen = False
        Me.txtFecha2.Location = New System.Drawing.Point(108, 50)
        '
        '
        '
        Me.txtFecha2.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFecha2.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtFecha2.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha2.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFecha2.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFecha2.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFecha2.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFecha2.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFecha2.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFecha2.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFecha2.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha2.MonthCalendar.DisplayMonth = New Date(2012, 12, 1, 0, 0, 0, 0)
        Me.txtFecha2.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFecha2.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFecha2.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFecha2.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFecha2.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFecha2.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha2.MonthCalendar.TodayButtonVisible = True
        Me.txtFecha2.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFecha2.Name = "txtFecha2"
        Me.txtFecha2.Size = New System.Drawing.Size(118, 20)
        Me.txtFecha2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFecha2.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(24, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "y el día"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(24, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Entre el día"
        '
        'chkExceptoFecha
        '
        Me.chkExceptoFecha.AutoSize = True
        '
        '
        '
        Me.chkExceptoFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkExceptoFecha.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkExceptoFecha.Location = New System.Drawing.Point(3, 87)
        Me.chkExceptoFecha.Name = "chkExceptoFecha"
        Me.chkExceptoFecha.Size = New System.Drawing.Size(124, 15)
        Me.chkExceptoFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkExceptoFecha.TabIndex = 5
        Me.chkExceptoFecha.Text = "Esté fuera del rango:"
        '
        'chkIncluyeFecha
        '
        Me.chkIncluyeFecha.AutoSize = True
        '
        '
        '
        Me.chkIncluyeFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkIncluyeFecha.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkIncluyeFecha.Location = New System.Drawing.Point(3, 3)
        Me.chkIncluyeFecha.Name = "chkIncluyeFecha"
        Me.chkIncluyeFecha.Size = New System.Drawing.Size(149, 15)
        Me.chkIncluyeFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkIncluyeFecha.TabIndex = 0
        Me.chkIncluyeFecha.Text = "Se encuentre en el rango:"
        '
        'txtFecha1
        '
        '
        '
        '
        Me.txtFecha1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFecha1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtFecha1.ButtonDropDown.Visible = True
        Me.txtFecha1.Enabled = False
        Me.txtFecha1.IsPopupCalendarOpen = False
        Me.txtFecha1.Location = New System.Drawing.Point(108, 25)
        '
        '
        '
        Me.txtFecha1.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFecha1.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtFecha1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha1.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFecha1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFecha1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFecha1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFecha1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFecha1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFecha1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFecha1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha1.MonthCalendar.DisplayMonth = New Date(2012, 12, 1, 0, 0, 0, 0)
        Me.txtFecha1.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFecha1.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFecha1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFecha1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFecha1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFecha1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha1.MonthCalendar.TodayButtonVisible = True
        Me.txtFecha1.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFecha1.Name = "txtFecha1"
        Me.txtFecha1.Size = New System.Drawing.Size(118, 20)
        Me.txtFecha1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFecha1.TabIndex = 2
        '
        'lblRegistros
        '
        Me.lblRegistros.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblRegistros.Location = New System.Drawing.Point(3, 376)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(387, 26)
        Me.lblRegistros.TabIndex = 0
        Me.lblRegistros.Text = "X registros"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgLista
        '
        Me.dgLista.AllowUserToAddRows = False
        Me.dgLista.AllowUserToDeleteRows = False
        Me.dgLista.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLista.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLista.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colReloj, Me.colNombres})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgLista.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgLista.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgLista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgLista.Location = New System.Drawing.Point(3, 16)
        Me.dgLista.Name = "dgLista"
        Me.dgLista.RowHeadersVisible = False
        Me.dgLista.RowTemplate.Height = 18
        Me.dgLista.Size = New System.Drawing.Size(387, 355)
        Me.dgLista.TabIndex = 98
        '
        'colReloj
        '
        Me.colReloj.DataPropertyName = "reloj"
        Me.colReloj.HeaderText = "RELOJ"
        Me.colReloj.Name = "colReloj"
        Me.colReloj.Width = 45
        '
        'colNombres
        '
        Me.colNombres.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colNombres.DataPropertyName = "nombres"
        Me.colNombres.HeaderText = "NOMBRES"
        Me.colNombres.Name = "colNombres"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Window
        Me.GroupBox2.Controls.Add(Me.cbCampos)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.pnlCaracter)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(426, 405)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Mostar registros que cumplan"
        '
        'cbCampos
        '
        Me.cbCampos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cbCampos.BackgroundStyle.Class = "TextBoxBorder"
        Me.cbCampos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbCampos.ButtonDropDown.Visible = True
        Me.cbCampos.Columns.Add(Me.NombreCampo)
        Me.cbCampos.Columns.Add(Me.CodCampo)
        Me.cbCampos.Columns.Add(Me.tipo)
        Me.cbCampos.Columns.Add(Me.Tabla)
        Me.cbCampos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cbCampos.Location = New System.Drawing.Point(62, 20)
        Me.cbCampos.Name = "cbCampos"
        Me.cbCampos.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.cbCampos.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect
        Me.cbCampos.Size = New System.Drawing.Size(355, 21)
        Me.cbCampos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbCampos.TabIndex = 0
        Me.cbCampos.ThemeAware = True
        Me.cbCampos.ValueMember = "cod_campo"
        '
        'NombreCampo
        '
        Me.NombreCampo.DataFieldName = "nombre"
        Me.NombreCampo.DisplayIndex = 0
        Me.NombreCampo.Name = "NombreCampo"
        Me.NombreCampo.StretchToFill = True
        Me.NombreCampo.Text = "Campo"
        Me.NombreCampo.Width.Absolute = 150
        Me.NombreCampo.Width.AutoSize = True
        '
        'CodCampo
        '
        Me.CodCampo.DataFieldName = "cod_campo"
        Me.CodCampo.Name = "CodCampo"
        Me.CodCampo.Text = "Código"
        Me.CodCampo.Visible = False
        Me.CodCampo.Width.Absolute = 75
        '
        'tipo
        '
        Me.tipo.DataFieldName = "tipo"
        Me.tipo.Name = "tipo"
        Me.tipo.Text = "Tipo"
        Me.tipo.Visible = False
        Me.tipo.Width.Absolute = 50
        '
        'Tabla
        '
        Me.Tabla.DataFieldName = "Tabla"
        Me.Tabla.Name = "Tabla"
        Me.Tabla.Text = "Tabla"
        Me.Tabla.Visible = False
        Me.Tabla.Width.Absolute = 150
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Campo"
        '
        'pnlCaracter
        '
        Me.pnlCaracter.Controls.Add(Me.chkTodosExcepto)
        Me.pnlCaracter.Controls.Add(Me.chkTodosIncluyendo)
        Me.pnlCaracter.Controls.Add(Me.chkNoBlanco)
        Me.pnlCaracter.Controls.Add(Me.chkIncluyendo)
        Me.pnlCaracter.Controls.Add(Me.txtExcepto)
        Me.pnlCaracter.Controls.Add(Me.chkBlanco)
        Me.pnlCaracter.Controls.Add(Me.lstIncluyendo)
        Me.pnlCaracter.Controls.Add(Me.txtIncluyendo)
        Me.pnlCaracter.Controls.Add(Me.chkExcepto)
        Me.pnlCaracter.Controls.Add(Me.lstExcepto)
        Me.pnlCaracter.Location = New System.Drawing.Point(4, 45)
        Me.pnlCaracter.Name = "pnlCaracter"
        Me.pnlCaracter.Size = New System.Drawing.Size(416, 354)
        Me.pnlCaracter.TabIndex = 1
        Me.pnlCaracter.Visible = False
        '
        'chkTodosExcepto
        '
        Me.chkTodosExcepto.AutoSize = True
        '
        '
        '
        Me.chkTodosExcepto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkTodosExcepto.Checked = True
        Me.chkTodosExcepto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodosExcepto.CheckValue = "Y"
        Me.chkTodosExcepto.Location = New System.Drawing.Point(294, 158)
        Me.chkTodosExcepto.Name = "chkTodosExcepto"
        Me.chkTodosExcepto.Size = New System.Drawing.Size(118, 16)
        Me.chkTodosExcepto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkTodosExcepto.TabIndex = 7
        Me.chkTodosExcepto.Text = "Seleccionar todos"
        '
        'chkTodosIncluyendo
        '
        Me.chkTodosIncluyendo.AutoSize = True
        '
        '
        '
        Me.chkTodosIncluyendo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkTodosIncluyendo.Checked = True
        Me.chkTodosIncluyendo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTodosIncluyendo.CheckValue = "Y"
        Me.chkTodosIncluyendo.Location = New System.Drawing.Point(294, 3)
        Me.chkTodosIncluyendo.Name = "chkTodosIncluyendo"
        Me.chkTodosIncluyendo.Size = New System.Drawing.Size(118, 16)
        Me.chkTodosIncluyendo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkTodosIncluyendo.TabIndex = 6
        Me.chkTodosIncluyendo.Text = "Seleccionar todos"
        '
        'chkNoBlanco
        '
        Me.chkNoBlanco.AutoSize = True
        '
        '
        '
        Me.chkNoBlanco.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkNoBlanco.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkNoBlanco.Location = New System.Drawing.Point(3, 333)
        Me.chkNoBlanco.Name = "chkNoBlanco"
        Me.chkNoBlanco.Size = New System.Drawing.Size(122, 16)
        Me.chkNoBlanco.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkNoBlanco.TabIndex = 8
        Me.chkNoBlanco.Text = "NO esté en blanco"
        '
        'chkIncluyendo
        '
        Me.chkIncluyendo.AutoSize = True
        '
        '
        '
        Me.chkIncluyendo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkIncluyendo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkIncluyendo.Location = New System.Drawing.Point(3, 3)
        Me.chkIncluyendo.Name = "chkIncluyendo"
        Me.chkIncluyendo.Size = New System.Drawing.Size(86, 16)
        Me.chkIncluyendo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkIncluyendo.TabIndex = 0
        Me.chkIncluyendo.Text = "Sea igual a:"
        '
        'txtExcepto
        '
        '
        '
        '
        Me.txtExcepto.Border.Class = "TextBoxBorder"
        Me.txtExcepto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtExcepto.Enabled = False
        Me.txtExcepto.Location = New System.Drawing.Point(25, 181)
        Me.txtExcepto.Name = "txtExcepto"
        Me.txtExcepto.Size = New System.Drawing.Size(389, 21)
        Me.txtExcepto.TabIndex = 4
        '
        'chkBlanco
        '
        Me.chkBlanco.AutoSize = True
        '
        '
        '
        Me.chkBlanco.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkBlanco.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkBlanco.Location = New System.Drawing.Point(3, 310)
        Me.chkBlanco.Name = "chkBlanco"
        Me.chkBlanco.Size = New System.Drawing.Size(102, 16)
        Me.chkBlanco.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkBlanco.TabIndex = 7
        Me.chkBlanco.Text = "Esté en blanco"
        '
        'lstIncluyendo
        '
        Me.lstIncluyendo.CheckOnClick = True
        Me.lstIncluyendo.FormattingEnabled = True
        Me.lstIncluyendo.Location = New System.Drawing.Point(25, 52)
        Me.lstIncluyendo.Name = "lstIncluyendo"
        Me.lstIncluyendo.Size = New System.Drawing.Size(389, 100)
        Me.lstIncluyendo.Sorted = True
        Me.lstIncluyendo.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.lstIncluyendo, "Solo se muestran los primeros 100 registros")
        '
        'txtIncluyendo
        '
        '
        '
        '
        Me.txtIncluyendo.Border.Class = "TextBoxBorder"
        Me.txtIncluyendo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtIncluyendo.Location = New System.Drawing.Point(24, 25)
        Me.txtIncluyendo.Name = "txtIncluyendo"
        Me.txtIncluyendo.Size = New System.Drawing.Size(389, 21)
        Me.txtIncluyendo.TabIndex = 1
        '
        'chkExcepto
        '
        Me.chkExcepto.AutoSize = True
        '
        '
        '
        Me.chkExcepto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkExcepto.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkExcepto.Location = New System.Drawing.Point(3, 158)
        Me.chkExcepto.Name = "chkExcepto"
        Me.chkExcepto.Size = New System.Drawing.Size(114, 16)
        Me.chkExcepto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkExcepto.TabIndex = 3
        Me.chkExcepto.Text = "Sea diferente de:"
        '
        'lstExcepto
        '
        Me.lstExcepto.CheckOnClick = True
        Me.lstExcepto.Enabled = False
        Me.lstExcepto.FormattingEnabled = True
        Me.lstExcepto.Location = New System.Drawing.Point(25, 208)
        Me.lstExcepto.Name = "lstExcepto"
        Me.lstExcepto.Size = New System.Drawing.Size(389, 100)
        Me.lstExcepto.Sorted = True
        Me.lstExcepto.TabIndex = 5
        '
        'Codigo
        '
        Me.Codigo.DataFieldName = "cod_campo"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.Text = "Código"
        Me.Codigo.Width.Absolute = 150
        '
        'Nombre
        '
        Me.Nombre.DataFieldName = "nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Text = "Nombre"
        Me.Nombre.Width.Absolute = 150
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ReflectionLabel2)
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(10, 10)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(849, 53)
        Me.Panel2.TabIndex = 96
        '
        'ReflectionLabel2
        '
        '
        '
        '
        Me.ReflectionLabel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel2.BackgroundStyle.PaddingLeft = 10
        Me.ReflectionLabel2.BackgroundStyle.PaddingTop = 10
        Me.ReflectionLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReflectionLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel2.Location = New System.Drawing.Point(38, 0)
        Me.ReflectionLabel2.Name = "ReflectionLabel2"
        Me.ReflectionLabel2.Size = New System.Drawing.Size(811, 53)
        Me.ReflectionLabel2.TabIndex = 249
        Me.ReflectionLabel2.Text = "<font color=""#1F497D""><b>FILTROS A ARCHIVOS DE NÓMINA</b></font>"
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox2.Image = Global.PIDA.My.Resources.Resources.filtro_
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(38, 53)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 210
        Me.PictureBox2.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(112, 13)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(10, 26)
        Me.Panel1.TabIndex = 4
        '
        'frmFiltroNomina
        '
        Me.AcceptButton = Me.btnAgregar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(869, 616)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFiltroNomina"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Filtros"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.pnlNumerico.ResumeLayout(False)
        Me.pnlNumerico.PerformLayout()
        CType(Me.txtExceptoNum2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtExceptoNum1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNum2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNum1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFechas.ResumeLayout(False)
        Me.pnlFechas.PerformLayout()
        CType(Me.txtExceptoFecha1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtExceptoFecha2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.pnlCaracter.ResumeLayout(False)
        Me.pnlCaracter.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLimpiar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtExcepto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtIncluyendo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstIncluyendo As System.Windows.Forms.CheckedListBox
    Friend WithEvents lstExcepto As System.Windows.Forms.CheckedListBox
    Friend WithEvents chkBlanco As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkExcepto As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkIncluyendo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkNoBlanco As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRegistros As System.Windows.Forms.Label
    Friend WithEvents lstFiltros As System.Windows.Forms.ListBox
    Friend WithEvents btnAgregar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Codigo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Nombre As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents cbCampos As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents pnlNumerico As System.Windows.Forms.Panel
    Friend WithEvents pnlFechas As System.Windows.Forms.Panel
    Friend WithEvents txtFecha1 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents pnlCaracter As System.Windows.Forms.Panel
    Friend WithEvents txtExceptoFecha2 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFecha2 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkExceptoFecha As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkIncluyeFecha As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents NombreCampo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents CodCampo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents tipo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents txtExceptoFecha1 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtExceptoNum2 As DevComponents.Editors.DoubleInput
    Friend WithEvents txtExceptoNum1 As DevComponents.Editors.DoubleInput
    Friend WithEvents txtNum2 As DevComponents.Editors.DoubleInput
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents chkExceptoNum As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkIncluyendoNum As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents txtNum1 As DevComponents.Editors.DoubleInput
    Friend WithEvents chkTodosIncluyendo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkTodosExcepto As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Tabla As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents dgLista As System.Windows.Forms.DataGridView
    Friend WithEvents colReloj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ReflectionLabel2 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
