<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFiltroUniformes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFiltroUniformes))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.lstFiltros = New System.Windows.Forms.ListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dgLista = New System.Windows.Forms.DataGridView()
        Me.Reloj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Codigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FechaSAL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlBooleano = New System.Windows.Forms.Panel()
        Me.chkNo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkSi = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lblRegistros = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbCampos = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.NOMBRE = New DevComponents.AdvTree.ColumnHeader()
        Me.COD_CAMPO = New DevComponents.AdvTree.ColumnHeader()
        Me.TIPO = New DevComponents.AdvTree.ColumnHeader()
        Me.TABLA = New DevComponents.AdvTree.ColumnHeader()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlCaracter = New System.Windows.Forms.Panel()
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
        Me.chkTodosExcepto = New DevComponents.DotNetBar.Controls.CheckBoxX()
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
        Me.chkTodosIncluyendo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkNoBlanco = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkIncluyendo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtExcepto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.chkBlanco = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lstIncluyendo = New System.Windows.Forms.CheckedListBox()
        Me.txtIncluyendo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.chkExcepto = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lstExcepto = New System.Windows.Forms.CheckedListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnLimpiar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAgregar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgLista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBooleano.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.pnlCaracter.SuspendLayout()
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
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(46, 13)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(545, 40)
        Me.ReflectionLabel1.TabIndex = 97
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>FILTROS A ARCHIVO DE UNIFORMES</b></font>"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.Filtro32
        Me.picImagen.Location = New System.Drawing.Point(12, 13)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(34, 34)
        Me.picImagen.TabIndex = 98
        Me.picImagen.TabStop = False
        '
        'GroupPanel2
        '
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.GroupPanel2.Controls.Add(Me.lstFiltros)
        Me.GroupPanel2.Controls.Add(Me.GroupBox3)
        Me.GroupPanel2.Controls.Add(Me.Label2)
        Me.GroupPanel2.Controls.Add(Me.GroupBox2)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(9, 59)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(839, 492)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor = System.Drawing.Color.White
        Me.GroupPanel2.Style.BackColor2 = System.Drawing.Color.White
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
        Me.GroupBox3.BackColor = System.Drawing.Color.White
        Me.GroupBox3.Controls.Add(Me.dgLista)
        Me.GroupBox3.Controls.Add(Me.pnlBooleano)
        Me.GroupBox3.Controls.Add(Me.lblRegistros)
        Me.GroupBox3.Location = New System.Drawing.Point(437, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(393, 405)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Resultado"
        '
        'dgLista
        '
        Me.dgLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLista.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Reloj, Me.NOMBRES, Me.Codigo, Me.FechaSAL})
        Me.dgLista.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.dgLista.Location = New System.Drawing.Point(9, 19)
        Me.dgLista.Name = "dgLista"
        Me.dgLista.ReadOnly = True
        Me.dgLista.RowHeadersVisible = False
        Me.dgLista.Size = New System.Drawing.Size(378, 352)
        Me.dgLista.TabIndex = 100
        '
        'Reloj
        '
        Me.Reloj.DataPropertyName = "RELOJ"
        Me.Reloj.HeaderText = "Reloj"
        Me.Reloj.Name = "Reloj"
        Me.Reloj.ReadOnly = True
        Me.Reloj.Width = 50
        '
        'NOMBRES
        '
        Me.NOMBRES.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NOMBRES.DataPropertyName = "NOMBRES"
        Me.NOMBRES.HeaderText = "Nombre"
        Me.NOMBRES.Name = "NOMBRES"
        Me.NOMBRES.ReadOnly = True
        '
        'Codigo
        '
        Me.Codigo.DataPropertyName = "Código"
        Me.Codigo.HeaderText = "Código"
        Me.Codigo.Name = "Codigo"
        Me.Codigo.ReadOnly = True
        Me.Codigo.Width = 60
        '
        'FechaSAL
        '
        Me.FechaSAL.DataPropertyName = "FECHA_SAL"
        Me.FechaSAL.HeaderText = "Fecha de préstamo"
        Me.FechaSAL.Name = "FechaSAL"
        Me.FechaSAL.ReadOnly = True
        Me.FechaSAL.Width = 75
        '
        'pnlBooleano
        '
        Me.pnlBooleano.Controls.Add(Me.chkNo)
        Me.pnlBooleano.Controls.Add(Me.chkSi)
        Me.pnlBooleano.Location = New System.Drawing.Point(18, 253)
        Me.pnlBooleano.Name = "pnlBooleano"
        Me.pnlBooleano.Size = New System.Drawing.Size(306, 161)
        Me.pnlBooleano.TabIndex = 99
        Me.pnlBooleano.Visible = False
        '
        'chkNo
        '
        Me.chkNo.AutoSize = True
        '
        '
        '
        Me.chkNo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkNo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkNo.Location = New System.Drawing.Point(3, 30)
        Me.chkNo.Name = "chkNo"
        Me.chkNo.Size = New System.Drawing.Size(37, 15)
        Me.chkNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkNo.TabIndex = 5
        Me.chkNo.Text = "No"
        '
        'chkSi
        '
        Me.chkSi.AutoSize = True
        '
        '
        '
        Me.chkSi.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkSi.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkSi.Location = New System.Drawing.Point(3, 3)
        Me.chkSi.Name = "chkSi"
        Me.chkSi.Size = New System.Drawing.Size(32, 15)
        Me.chkSi.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkSi.TabIndex = 0
        Me.chkSi.Text = "Sí"
        '
        'lblRegistros
        '
        Me.lblRegistros.Location = New System.Drawing.Point(6, 372)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(381, 26)
        Me.lblRegistros.TabIndex = 0
        Me.lblRegistros.Text = "X registros"
        Me.lblRegistros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(3, 410)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Filtros vigentes"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.cbCampos)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.pnlCaracter)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(426, 405)
        Me.GroupBox2.TabIndex = 0
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
        Me.cbCampos.Columns.Add(Me.NOMBRE)
        Me.cbCampos.Columns.Add(Me.COD_CAMPO)
        Me.cbCampos.Columns.Add(Me.TIPO)
        Me.cbCampos.Columns.Add(Me.TABLA)
        Me.cbCampos.KeyboardSearchNoSelectionAllowed = False
        Me.cbCampos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cbCampos.Location = New System.Drawing.Point(62, 20)
        Me.cbCampos.Name = "cbCampos"
        Me.cbCampos.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.cbCampos.Size = New System.Drawing.Size(355, 21)
        Me.cbCampos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbCampos.TabIndex = 0
        Me.cbCampos.ThemeAware = True
        Me.cbCampos.ValueMember = "cod_campo"
        '
        'NOMBRE
        '
        Me.NOMBRE.DataFieldName = "NOMBRE"
        Me.NOMBRE.Name = "NOMBRE"
        Me.NOMBRE.Text = "NOMBRE"
        Me.NOMBRE.Width.Absolute = 600
        '
        'COD_CAMPO
        '
        Me.COD_CAMPO.DataFieldName = "COD_CAMPO"
        Me.COD_CAMPO.Name = "COD_CAMPO"
        Me.COD_CAMPO.Text = "Código"
        Me.COD_CAMPO.Visible = False
        Me.COD_CAMPO.Width.Absolute = 150
        '
        'TIPO
        '
        Me.TIPO.DataFieldName = "TIPO"
        Me.TIPO.Name = "TIPO"
        Me.TIPO.Text = "Tipo"
        Me.TIPO.Visible = False
        Me.TIPO.Width.Absolute = 150
        '
        'TABLA
        '
        Me.TABLA.DataFieldName = "TABLA"
        Me.TABLA.Name = "TABLA"
        Me.TABLA.Text = "Tabla"
        Me.TABLA.Visible = False
        Me.TABLA.Width.Absolute = 150
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
        Me.pnlCaracter.Controls.Add(Me.pnlNumerico)
        Me.pnlCaracter.Controls.Add(Me.chkTodosExcepto)
        Me.pnlCaracter.Controls.Add(Me.pnlFechas)
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
        Me.pnlCaracter.TabIndex = 2
        Me.pnlCaracter.Visible = False
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
        Me.pnlNumerico.Location = New System.Drawing.Point(125, 199)
        Me.pnlNumerico.Name = "pnlNumerico"
        Me.pnlNumerico.Size = New System.Drawing.Size(306, 161)
        Me.pnlNumerico.TabIndex = 99
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
        Me.txtExceptoNum2.Size = New System.Drawing.Size(118, 21)
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
        Me.txtExceptoNum1.Size = New System.Drawing.Size(118, 21)
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
        Me.txtNum2.Size = New System.Drawing.Size(118, 21)
        Me.txtNum2.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(24, 137)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 15)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "y el valor"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(24, 112)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 15)
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
        Me.chkExceptoNum.Size = New System.Drawing.Size(134, 16)
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
        Me.Label7.Size = New System.Drawing.Size(54, 15)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "y el valor"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(24, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 15)
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
        Me.chkIncluyendoNum.Size = New System.Drawing.Size(160, 16)
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
        Me.txtNum1.Size = New System.Drawing.Size(118, 21)
        Me.txtNum1.TabIndex = 2
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
        Me.pnlFechas.Location = New System.Drawing.Point(123, 28)
        Me.pnlFechas.Name = "pnlFechas"
        Me.pnlFechas.Size = New System.Drawing.Size(306, 161)
        Me.pnlFechas.TabIndex = 100
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
        Me.txtExceptoFecha1.Size = New System.Drawing.Size(118, 21)
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
        Me.txtExceptoFecha2.Size = New System.Drawing.Size(118, 21)
        Me.txtExceptoFecha2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtExceptoFecha2.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(24, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "y el día"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(24, 112)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 15)
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
        Me.txtFecha2.Size = New System.Drawing.Size(118, 21)
        Me.txtFecha2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFecha2.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(24, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "y el día"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(66, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(24, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 15)
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
        Me.chkExceptoFecha.Size = New System.Drawing.Size(134, 16)
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
        Me.chkIncluyeFecha.Size = New System.Drawing.Size(160, 16)
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
        Me.txtFecha1.Size = New System.Drawing.Size(118, 21)
        Me.txtFecha1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFecha1.TabIndex = 2
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
        Me.chkNoBlanco.TabIndex = 2
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
        Me.chkBlanco.TabIndex = 1
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
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnLimpiar)
        Me.GroupBox1.Controls.Add(Me.btnAgregar)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Location = New System.Drawing.Point(279, 548)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(302, 47)
        Me.GroupBox1.TabIndex = 96
        Me.GroupBox1.TabStop = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLimpiar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLimpiar.Image = Global.PIDA.My.Resources.Resources.LimpiaFiltroHC
        Me.btnLimpiar.Location = New System.Drawing.Point(112, 14)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(102, 25)
        Me.btnLimpiar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLimpiar.TabIndex = 4
        Me.btnLimpiar.Text = "Limpiar filtros"
        '
        'btnAgregar
        '
        Me.btnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAgregar.CausesValidation = False
        Me.btnAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = Global.PIDA.My.Resources.Resources.FiltroHC
        Me.btnAgregar.Location = New System.Drawing.Point(6, 14)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(102, 25)
        Me.btnAgregar.TabIndex = 3
        Me.btnAgregar.Text = "Agregar filtro"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCancelar.Location = New System.Drawing.Point(218, 14)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cerrar"
        '
        'frmFiltroUniformes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 598)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.picImagen)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmFiltroUniformes"
        Me.Text = "Filtro para reportes de herramientas"
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        Me.GroupPanel2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgLista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBooleano.ResumeLayout(False)
        Me.pnlBooleano.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.pnlCaracter.ResumeLayout(False)
        Me.pnlCaracter.PerformLayout()
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
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lstFiltros As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRegistros As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cbCampos As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlCaracter As System.Windows.Forms.Panel
    Friend WithEvents chkTodosExcepto As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkTodosIncluyendo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkNoBlanco As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkIncluyendo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents txtExcepto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents chkBlanco As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents lstIncluyendo As System.Windows.Forms.CheckedListBox
    Friend WithEvents txtIncluyendo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents chkExcepto As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents lstExcepto As System.Windows.Forms.CheckedListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAgregar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents NOMBRE As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents COD_CAMPO As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents TIPO As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents TABLA As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents pnlBooleano As System.Windows.Forms.Panel
    Friend WithEvents chkNo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkSi As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents dgLista As System.Windows.Forms.DataGridView
    Friend WithEvents pnlNumerico As System.Windows.Forms.Panel
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
    Friend WithEvents pnlFechas As System.Windows.Forms.Panel
    Friend WithEvents txtExceptoFecha1 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtExceptoFecha2 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFecha2 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkExceptoFecha As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkIncluyeFecha As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents txtFecha1 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Reloj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Codigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FechaSAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnLimpiar As DevComponents.DotNetBar.ButtonX
End Class
