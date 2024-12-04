<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambiosMasivos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCambiosMasivos))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.gpEmpleados = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.btnBuscaLista = New DevComponents.DotNetBar.ButtonX()
        Me.txtLista = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnLista = New System.Windows.Forms.RadioButton()
        Me.btnArchivo = New System.Windows.Forms.RadioButton()
        Me.btnBuscaArchivo = New DevComponents.DotNetBar.ButtonX()
        Me.txtArchivo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.gpValores = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.txtFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.btnLogico = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.cmbCampo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.txtValorNuevo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cmbValorNuevo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColCodValor = New DevComponents.AdvTree.ColumnHeader()
        Me.ColCiaValor = New DevComponents.AdvTree.ColumnHeader()
        Me.ColNombreValor = New DevComponents.AdvTree.ColumnHeader()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dlgArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.cpActualizacion = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.gpBajas = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbSubBaja = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.colSubBaja = New DevComponents.AdvTree.ColumnHeader()
        Me.colNombreSubBaja = New DevComponents.AdvTree.ColumnHeader()
        Me.cmbBajaImss = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColCodBa = New DevComponents.AdvTree.ColumnHeader()
        Me.ColMotBa = New DevComponents.AdvTree.ColumnHeader()
        Me.txtComentarios = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbBajaInterno = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.txtEBaja = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.gpTransferencias = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.cmbNivel = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.colNivel = New DevComponents.AdvTree.ColumnHeader()
        Me.colNombreNivel = New DevComponents.AdvTree.ColumnHeader()
        Me.colTipoNivel = New DevComponents.AdvTree.ColumnHeader()
        Me.lblSueldo = New System.Windows.Forms.Label()
        Me.txtSActual = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblNivel = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnSueldo = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbSubTransferencia = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.codSubBaj = New DevComponents.AdvTree.ColumnHeader()
        Me.nomSubBaj = New DevComponents.AdvTree.ColumnHeader()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnAntiguedad = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.cmbBajaImssTrans = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.cmbBajaInternoTrans = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRelojInicial = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtAltaTrans = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.lblAltaTrans = New System.Windows.Forms.Label()
        Me.cmbComentariosTrans = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBajaTrans = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblBajaTrans = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gpEmpleados.SuspendLayout()
        Me.gpValores.SuspendLayout()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpBajas.SuspendLayout()
        CType(Me.txtEBaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpTransferencias.SuspendLayout()
        CType(Me.txtAltaTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBajaTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(52, 14)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(451, 46)
        Me.ReflectionLabel1.TabIndex = 0
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CAMBIOS MASIVOS A ARCHIVO DE PERSONAL</b></font>"
        '
        'gpEmpleados
        '
        Me.gpEmpleados.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpEmpleados.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpEmpleados.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpEmpleados.Controls.Add(Me.btnBuscaLista)
        Me.gpEmpleados.Controls.Add(Me.txtLista)
        Me.gpEmpleados.Controls.Add(Me.btnLista)
        Me.gpEmpleados.Controls.Add(Me.btnArchivo)
        Me.gpEmpleados.Controls.Add(Me.btnBuscaArchivo)
        Me.gpEmpleados.Controls.Add(Me.txtArchivo)
        Me.gpEmpleados.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpEmpleados.Location = New System.Drawing.Point(14, 67)
        Me.gpEmpleados.Name = "gpEmpleados"
        Me.gpEmpleados.Size = New System.Drawing.Size(598, 124)
        '
        '
        '
        Me.gpEmpleados.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpEmpleados.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpEmpleados.Style.BackColorGradientAngle = 90
        Me.gpEmpleados.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpEmpleados.Style.BorderBottomWidth = 1
        Me.gpEmpleados.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpEmpleados.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpEmpleados.Style.BorderLeftWidth = 1
        Me.gpEmpleados.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpEmpleados.Style.BorderRightWidth = 1
        Me.gpEmpleados.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpEmpleados.Style.BorderTopWidth = 1
        Me.gpEmpleados.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpEmpleados.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpEmpleados.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpEmpleados.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpEmpleados.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpEmpleados.TabIndex = 1
        Me.gpEmpleados.Text = "Empleados a modificar"
        '
        'btnBuscaLista
        '
        Me.btnBuscaLista.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscaLista.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscaLista.Enabled = False
        Me.btnBuscaLista.Location = New System.Drawing.Point(555, 70)
        Me.btnBuscaLista.Name = "btnBuscaLista"
        Me.btnBuscaLista.Size = New System.Drawing.Size(26, 23)
        Me.btnBuscaLista.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscaLista.TabIndex = 5
        Me.btnBuscaLista.Text = "..."
        '
        'txtLista
        '
        '
        '
        '
        Me.txtLista.Border.Class = "TextBoxBorder"
        Me.txtLista.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtLista.Enabled = False
        Me.txtLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLista.Location = New System.Drawing.Point(26, 70)
        Me.txtLista.Name = "txtLista"
        Me.txtLista.Size = New System.Drawing.Size(523, 23)
        Me.txtLista.TabIndex = 4
        '
        'btnLista
        '
        Me.btnLista.AutoSize = True
        Me.btnLista.BackColor = System.Drawing.SystemColors.Window
        Me.btnLista.Location = New System.Drawing.Point(7, 50)
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
        Me.btnArchivo.Location = New System.Drawing.Point(7, 4)
        Me.btnArchivo.Name = "btnArchivo"
        Me.btnArchivo.Size = New System.Drawing.Size(151, 19)
        Me.btnArchivo.TabIndex = 0
        Me.btnArchivo.TabStop = True
        Me.btnArchivo.Text = "Buscar en archivo texto"
        Me.btnArchivo.UseVisualStyleBackColor = False
        '
        'btnBuscaArchivo
        '
        Me.btnBuscaArchivo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscaArchivo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscaArchivo.Location = New System.Drawing.Point(555, 24)
        Me.btnBuscaArchivo.Name = "btnBuscaArchivo"
        Me.btnBuscaArchivo.Size = New System.Drawing.Size(26, 23)
        Me.btnBuscaArchivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscaArchivo.TabIndex = 2
        Me.btnBuscaArchivo.Text = "..."
        '
        'txtArchivo
        '
        '
        '
        '
        Me.txtArchivo.Border.Class = "TextBoxBorder"
        Me.txtArchivo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivo.Location = New System.Drawing.Point(26, 24)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.Size = New System.Drawing.Size(523, 23)
        Me.txtArchivo.TabIndex = 1
        '
        'gpValores
        '
        Me.gpValores.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpValores.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpValores.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpValores.Controls.Add(Me.txtFecha)
        Me.gpValores.Controls.Add(Me.btnLogico)
        Me.gpValores.Controls.Add(Me.cmbCampo)
        Me.gpValores.Controls.Add(Me.txtValorNuevo)
        Me.gpValores.Controls.Add(Me.cmbValorNuevo)
        Me.gpValores.Controls.Add(Me.Label6)
        Me.gpValores.Controls.Add(Me.Label12)
        Me.gpValores.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpValores.Location = New System.Drawing.Point(14, 197)
        Me.gpValores.Name = "gpValores"
        Me.gpValores.Size = New System.Drawing.Size(598, 84)
        '
        '
        '
        Me.gpValores.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpValores.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpValores.Style.BackColorGradientAngle = 90
        Me.gpValores.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpValores.Style.BorderBottomWidth = 1
        Me.gpValores.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpValores.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpValores.Style.BorderLeftWidth = 1
        Me.gpValores.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpValores.Style.BorderRightWidth = 1
        Me.gpValores.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpValores.Style.BorderTopWidth = 1
        Me.gpValores.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpValores.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpValores.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpValores.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpValores.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpValores.TabIndex = 2
        Me.gpValores.Text = "Modificar valor"
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
        Me.txtFecha.IsPopupCalendarOpen = False
        Me.txtFecha.Location = New System.Drawing.Point(485, 38)
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
        Me.txtFecha.MonthCalendar.DisplayMonth = New Date(2014, 2, 1, 0, 0, 0, 0)
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
        Me.txtFecha.Size = New System.Drawing.Size(96, 21)
        Me.txtFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFecha.TabIndex = 1
        '
        'btnLogico
        '
        '
        '
        '
        Me.btnLogico.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnLogico.Location = New System.Drawing.Point(114, 38)
        Me.btnLogico.Name = "btnLogico"
        Me.btnLogico.OffText = "NO"
        Me.btnLogico.OnText = "SI"
        Me.btnLogico.Size = New System.Drawing.Size(96, 22)
        Me.btnLogico.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLogico.TabIndex = 1
        Me.btnLogico.Value = True
        Me.btnLogico.ValueObject = "Y"
        '
        'cmbCampo
        '
        Me.cmbCampo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbCampo.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbCampo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbCampo.ButtonDropDown.Visible = True
        Me.cmbCampo.Columns.Add(Me.ColumnHeader1)
        Me.cmbCampo.Columns.Add(Me.ColumnHeader2)
        Me.cmbCampo.Columns.Add(Me.ColumnHeader3)
        Me.cmbCampo.Columns.Add(Me.ColumnHeader4)
        Me.cmbCampo.KeyboardSearchNoSelectionAllowed = False
        Me.cmbCampo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbCampo.Location = New System.Drawing.Point(114, 2)
        Me.cmbCampo.Name = "cmbCampo"
        Me.cmbCampo.Size = New System.Drawing.Size(467, 23)
        Me.cmbCampo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbCampo.TabIndex = 0
        Me.cmbCampo.ValueMember = "cod_campo"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "nombre"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.SortingEnabled = False
        Me.ColumnHeader1.StretchToFill = True
        Me.ColumnHeader1.Text = "Nombre"
        Me.ColumnHeader1.Width.Absolute = 150
        Me.ColumnHeader1.Width.AutoSize = True
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "cod_campo"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Código"
        Me.ColumnHeader2.Visible = False
        Me.ColumnHeader2.Width.Absolute = 150
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DataFieldName = "tipo"
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Tipo"
        Me.ColumnHeader3.Visible = False
        Me.ColumnHeader3.Width.Absolute = 150
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DataFieldName = "tabla"
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "Tabla"
        Me.ColumnHeader4.Visible = False
        Me.ColumnHeader4.Width.Absolute = 150
        '
        'txtValorNuevo
        '
        '
        '
        '
        Me.txtValorNuevo.Border.Class = "TextBoxBorder"
        Me.txtValorNuevo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtValorNuevo.Location = New System.Drawing.Point(221, 39)
        Me.txtValorNuevo.Name = "txtValorNuevo"
        Me.txtValorNuevo.Size = New System.Drawing.Size(258, 21)
        Me.txtValorNuevo.TabIndex = 1
        '
        'cmbValorNuevo
        '
        Me.cmbValorNuevo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbValorNuevo.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbValorNuevo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbValorNuevo.ButtonDropDown.Visible = True
        Me.cmbValorNuevo.Columns.Add(Me.ColCodValor)
        Me.cmbValorNuevo.Columns.Add(Me.ColCiaValor)
        Me.cmbValorNuevo.Columns.Add(Me.ColNombreValor)
        Me.cmbValorNuevo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbValorNuevo.Location = New System.Drawing.Point(114, 31)
        Me.cmbValorNuevo.Name = "cmbValorNuevo"
        Me.cmbValorNuevo.Size = New System.Drawing.Size(467, 23)
        Me.cmbValorNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbValorNuevo.TabIndex = 1
        Me.cmbValorNuevo.ValueMember = "codigo"
        '
        'ColCodValor
        '
        Me.ColCodValor.DataFieldName = "codigo"
        Me.ColCodValor.Name = "ColCodValor"
        Me.ColCodValor.Text = "Código"
        Me.ColCodValor.Width.Absolute = 80
        '
        'ColCiaValor
        '
        Me.ColCiaValor.DataFieldName = "comp"
        Me.ColCiaValor.Name = "ColCiaValor"
        Me.ColCiaValor.Text = "Cía."
        Me.ColCiaValor.Width.Absolute = 80
        '
        'ColNombreValor
        '
        Me.ColNombreValor.DataFieldName = "nombre"
        Me.ColNombreValor.Name = "ColNombreValor"
        Me.ColNombreValor.StretchToFill = True
        Me.ColNombreValor.Text = "Nombre"
        Me.ColNombreValor.Width.Absolute = 150
        Me.ColNombreValor.Width.AutoSize = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 15)
        Me.Label6.TabIndex = 84
        Me.Label6.Text = "Campo"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Window
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 31)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 15)
        Me.Label12.TabIndex = 80
        Me.Label12.Text = "Valor nuevo"
        '
        'dlgArchivo
        '
        Me.dlgArchivo.FileName = "OpenFileDialog1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAceptar)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox1.Location = New System.Drawing.Point(847, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(174, 47)
        Me.GroupBox1.TabIndex = 0
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
        Me.cpActualizacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cpActualizacion.Location = New System.Drawing.Point(0, 0)
        Me.cpActualizacion.Name = "cpActualizacion"
        Me.cpActualizacion.Size = New System.Drawing.Size(847, 47)
        Me.cpActualizacion.TabIndex = 1
        Me.cpActualizacion.Text = "Reloj"
        Me.cpActualizacion.TextVisible = True
        Me.cpActualizacion.Visible = False
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.EditList32
        Me.picImagen.Location = New System.Drawing.Point(14, 14)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(31, 30)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImagen.TabIndex = 112
        Me.picImagen.TabStop = False
        '
        'gpBajas
        '
        Me.gpBajas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpBajas.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpBajas.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpBajas.Controls.Add(Me.Label5)
        Me.gpBajas.Controls.Add(Me.cmbSubBaja)
        Me.gpBajas.Controls.Add(Me.cmbBajaImss)
        Me.gpBajas.Controls.Add(Me.txtComentarios)
        Me.gpBajas.Controls.Add(Me.Label1)
        Me.gpBajas.Controls.Add(Me.cmbBajaInterno)
        Me.gpBajas.Controls.Add(Me.txtEBaja)
        Me.gpBajas.Controls.Add(Me.Label50)
        Me.gpBajas.Controls.Add(Me.Label49)
        Me.gpBajas.Controls.Add(Me.Label41)
        Me.gpBajas.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpBajas.Location = New System.Drawing.Point(14, 287)
        Me.gpBajas.Name = "gpBajas"
        Me.gpBajas.Size = New System.Drawing.Size(598, 216)
        '
        '
        '
        Me.gpBajas.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpBajas.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpBajas.Style.BackColorGradientAngle = 90
        Me.gpBajas.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpBajas.Style.BorderBottomWidth = 1
        Me.gpBajas.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpBajas.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpBajas.Style.BorderLeftWidth = 1
        Me.gpBajas.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpBajas.Style.BorderRightWidth = 1
        Me.gpBajas.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpBajas.Style.BorderTopWidth = 1
        Me.gpBajas.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpBajas.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpBajas.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpBajas.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpBajas.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpBajas.TabIndex = 3
        Me.gpBajas.Text = "Bajas"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 59)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(109, 15)
        Me.Label5.TabIndex = 144
        Me.Label5.Text = "Submotivo de baja"
        '
        'cmbSubBaja
        '
        Me.cmbSubBaja.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbSubBaja.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbSubBaja.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbSubBaja.ButtonDropDown.Visible = True
        Me.cmbSubBaja.Columns.Add(Me.colSubBaja)
        Me.cmbSubBaja.Columns.Add(Me.colNombreSubBaja)
        Me.cmbSubBaja.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbSubBaja.Location = New System.Drawing.Point(137, 59)
        Me.cmbSubBaja.Name = "cmbSubBaja"
        Me.cmbSubBaja.Size = New System.Drawing.Size(444, 23)
        Me.cmbSubBaja.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbSubBaja.TabIndex = 2
        Me.cmbSubBaja.ValueMember = "CÓDIGO"
        '
        'colSubBaja
        '
        Me.colSubBaja.ColumnName = "CÓDIGO"
        Me.colSubBaja.DataFieldName = "CÓDIGO"
        Me.colSubBaja.Name = "colSubBaja"
        Me.colSubBaja.Text = "CÓD"
        Me.colSubBaja.Width.Absolute = 40
        '
        'colNombreSubBaja
        '
        Me.colNombreSubBaja.ColumnName = "MOTIVO"
        Me.colNombreSubBaja.DataFieldName = "MOTIVO"
        Me.colNombreSubBaja.Name = "colNombreSubBaja"
        Me.colNombreSubBaja.StretchToFill = True
        Me.colNombreSubBaja.Text = "NOMBRE"
        Me.colNombreSubBaja.Width.Absolute = 150
        Me.colNombreSubBaja.Width.AutoSize = True
        '
        'cmbBajaImss
        '
        Me.cmbBajaImss.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbBajaImss.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbBajaImss.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbBajaImss.ButtonDropDown.Visible = True
        Me.cmbBajaImss.Columns.Add(Me.ColCodBa)
        Me.cmbBajaImss.Columns.Add(Me.ColMotBa)
        Me.cmbBajaImss.DropDownHeight = 250
        Me.cmbBajaImss.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbBajaImss.Location = New System.Drawing.Point(137, 86)
        Me.cmbBajaImss.Name = "cmbBajaImss"
        Me.cmbBajaImss.Size = New System.Drawing.Size(444, 20)
        Me.cmbBajaImss.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbBajaImss.TabIndex = 3
        Me.cmbBajaImss.ValueMember = "CÓDIGO"
        '
        'ColCodBa
        '
        Me.ColCodBa.ColumnName = "CÓDIGO"
        Me.ColCodBa.DataFieldName = "CÓDIGO"
        Me.ColCodBa.Name = "ColCodBa"
        Me.ColCodBa.Text = "CÓD"
        Me.ColCodBa.Width.Absolute = 40
        '
        'ColMotBa
        '
        Me.ColMotBa.ColumnName = "MOTIVO"
        Me.ColMotBa.DataFieldName = "MOTIVO"
        Me.ColMotBa.Name = "ColMotBa"
        Me.ColMotBa.StretchToFill = True
        Me.ColMotBa.Text = "MOTIVO"
        Me.ColMotBa.Width.Absolute = 150
        Me.ColMotBa.Width.AutoSize = True
        '
        'txtComentarios
        '
        '
        '
        '
        Me.txtComentarios.Border.Class = "TextBoxBorder"
        Me.txtComentarios.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtComentarios.Location = New System.Drawing.Point(137, 112)
        Me.txtComentarios.Multiline = True
        Me.txtComentarios.Name = "txtComentarios"
        Me.txtComentarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtComentarios.Size = New System.Drawing.Size(444, 70)
        Me.txtComentarios.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 15)
        Me.Label1.TabIndex = 132
        Me.Label1.Text = "Comentarios"
        '
        'cmbBajaInterno
        '
        Me.cmbBajaInterno.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbBajaInterno.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbBajaInterno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbBajaInterno.ButtonDropDown.Visible = True
        Me.cmbBajaInterno.Columns.Add(Me.ColCodBa)
        Me.cmbBajaInterno.Columns.Add(Me.ColMotBa)
        Me.cmbBajaInterno.DropDownHeight = 250
        Me.cmbBajaInterno.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbBajaInterno.Location = New System.Drawing.Point(137, 35)
        Me.cmbBajaInterno.Name = "cmbBajaInterno"
        Me.cmbBajaInterno.Size = New System.Drawing.Size(444, 20)
        Me.cmbBajaInterno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbBajaInterno.TabIndex = 1
        Me.cmbBajaInterno.ValueMember = "CÓDIGO"
        '
        'txtEBaja
        '
        '
        '
        '
        Me.txtEBaja.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtEBaja.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtEBaja.ButtonDropDown.Visible = True
        Me.txtEBaja.DisabledForeColor = System.Drawing.Color.Black
        Me.txtEBaja.FocusHighlightEnabled = True
        Me.txtEBaja.IsPopupCalendarOpen = False
        Me.txtEBaja.Location = New System.Drawing.Point(137, 8)
        '
        '
        '
        Me.txtEBaja.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtEBaja.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtEBaja.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtEBaja.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtEBaja.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtEBaja.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtEBaja.MonthCalendar.DisplayMonth = New Date(2007, 10, 1, 0, 0, 0, 0)
        Me.txtEBaja.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtEBaja.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtEBaja.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtEBaja.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtEBaja.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtEBaja.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtEBaja.MonthCalendar.TodayButtonVisible = True
        Me.txtEBaja.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtEBaja.Name = "txtEBaja"
        Me.txtEBaja.Size = New System.Drawing.Size(96, 21)
        Me.txtEBaja.TabIndex = 0
        Me.txtEBaja.Value = New Date(2007, 7, 7, 0, 0, 0, 0)
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.BackColor = System.Drawing.SystemColors.Window
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(4, 86)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(120, 15)
        Me.Label50.TabIndex = 131
        Me.Label50.Text = "Motivo de baja IMSS"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.BackColor = System.Drawing.SystemColors.Window
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(3, 38)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(128, 15)
        Me.Label49.TabIndex = 130
        Me.Label49.Text = "Motivo de baja interno"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.BackColor = System.Drawing.SystemColors.Window
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(3, 11)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(85, 15)
        Me.Label41.TabIndex = 129
        Me.Label41.Text = "Fecha de baja"
        '
        'gpTransferencias
        '
        Me.gpTransferencias.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpTransferencias.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpTransferencias.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpTransferencias.Controls.Add(Me.cmbNivel)
        Me.gpTransferencias.Controls.Add(Me.lblSueldo)
        Me.gpTransferencias.Controls.Add(Me.txtSActual)
        Me.gpTransferencias.Controls.Add(Me.lblNivel)
        Me.gpTransferencias.Controls.Add(Me.Label10)
        Me.gpTransferencias.Controls.Add(Me.btnSueldo)
        Me.gpTransferencias.Controls.Add(Me.Label7)
        Me.gpTransferencias.Controls.Add(Me.cmbSubTransferencia)
        Me.gpTransferencias.Controls.Add(Me.Label9)
        Me.gpTransferencias.Controls.Add(Me.btnAntiguedad)
        Me.gpTransferencias.Controls.Add(Me.cmbBajaImssTrans)
        Me.gpTransferencias.Controls.Add(Me.cmbBajaInternoTrans)
        Me.gpTransferencias.Controls.Add(Me.Label8)
        Me.gpTransferencias.Controls.Add(Me.txtRelojInicial)
        Me.gpTransferencias.Controls.Add(Me.txtAltaTrans)
        Me.gpTransferencias.Controls.Add(Me.lblAltaTrans)
        Me.gpTransferencias.Controls.Add(Me.cmbComentariosTrans)
        Me.gpTransferencias.Controls.Add(Me.Label2)
        Me.gpTransferencias.Controls.Add(Me.txtBajaTrans)
        Me.gpTransferencias.Controls.Add(Me.Label3)
        Me.gpTransferencias.Controls.Add(Me.Label4)
        Me.gpTransferencias.Controls.Add(Me.lblBajaTrans)
        Me.gpTransferencias.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpTransferencias.Location = New System.Drawing.Point(424, 283)
        Me.gpTransferencias.Name = "gpTransferencias"
        Me.gpTransferencias.Size = New System.Drawing.Size(598, 288)
        '
        '
        '
        Me.gpTransferencias.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpTransferencias.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpTransferencias.Style.BackColorGradientAngle = 90
        Me.gpTransferencias.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpTransferencias.Style.BorderBottomWidth = 1
        Me.gpTransferencias.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpTransferencias.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpTransferencias.Style.BorderLeftWidth = 1
        Me.gpTransferencias.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpTransferencias.Style.BorderRightWidth = 1
        Me.gpTransferencias.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpTransferencias.Style.BorderTopWidth = 1
        Me.gpTransferencias.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpTransferencias.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpTransferencias.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpTransferencias.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpTransferencias.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpTransferencias.TabIndex = 4
        Me.gpTransferencias.Text = "Transferencias"
        '
        'cmbNivel
        '
        Me.cmbNivel.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbNivel.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbNivel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbNivel.ButtonDropDown.Visible = True
        Me.cmbNivel.Columns.Add(Me.colNivel)
        Me.cmbNivel.Columns.Add(Me.colNombreNivel)
        Me.cmbNivel.Columns.Add(Me.colTipoNivel)
        Me.cmbNivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNivel.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbNivel.Location = New System.Drawing.Point(133, 175)
        Me.cmbNivel.Name = "cmbNivel"
        Me.cmbNivel.Size = New System.Drawing.Size(262, 23)
        Me.cmbNivel.TabIndex = 17
        Me.cmbNivel.ValueMember = "nivel"
        '
        'colNivel
        '
        Me.colNivel.ColumnName = "nivel"
        Me.colNivel.DataFieldName = "nivel"
        Me.colNivel.Name = "colNivel"
        Me.colNivel.Text = "Código"
        Me.colNivel.Width.Relative = 20
        '
        'colNombreNivel
        '
        Me.colNombreNivel.ColumnName = "nombre"
        Me.colNombreNivel.DataFieldName = "nombre"
        Me.colNombreNivel.Name = "colNombreNivel"
        Me.colNombreNivel.Text = "Nombre"
        Me.colNombreNivel.Width.Relative = 60
        '
        'colTipoNivel
        '
        Me.colTipoNivel.ColumnName = "cod_tipo"
        Me.colTipoNivel.DataFieldName = "cod_tipo"
        Me.colTipoNivel.Name = "colTipoNivel"
        Me.colTipoNivel.Text = "Tipo Emp."
        Me.colTipoNivel.Width.Relative = 20
        '
        'lblSueldo
        '
        Me.lblSueldo.AutoSize = True
        Me.lblSueldo.BackColor = System.Drawing.SystemColors.Window
        Me.lblSueldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSueldo.Location = New System.Drawing.Point(403, 179)
        Me.lblSueldo.Name = "lblSueldo"
        Me.lblSueldo.Size = New System.Drawing.Size(80, 15)
        Me.lblSueldo.TabIndex = 18
        Me.lblSueldo.Text = "Sueldo diario"
        '
        'txtSActual
        '
        Me.txtSActual.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtSActual.Border.Class = "TextBoxBorder"
        Me.txtSActual.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSActual.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSActual.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtSActual.Location = New System.Drawing.Point(489, 177)
        Me.txtSActual.Name = "txtSActual"
        Me.txtSActual.Size = New System.Drawing.Size(96, 19)
        Me.txtSActual.TabIndex = 19
        Me.txtSActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNivel
        '
        Me.lblNivel.AutoSize = True
        Me.lblNivel.BackColor = System.Drawing.SystemColors.Window
        Me.lblNivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNivel.Location = New System.Drawing.Point(3, 179)
        Me.lblNivel.Name = "lblNivel"
        Me.lblNivel.Size = New System.Drawing.Size(34, 15)
        Me.lblNivel.TabIndex = 16
        Me.lblNivel.Text = "Nivel"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Window
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(3, 151)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 15)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Mantener sueldo"
        '
        'btnSueldo
        '
        '
        '
        '
        Me.btnSueldo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnSueldo.Location = New System.Drawing.Point(133, 147)
        Me.btnSueldo.Name = "btnSueldo"
        Me.btnSueldo.OffText = "NO"
        Me.btnSueldo.OnText = "SI"
        Me.btnSueldo.Size = New System.Drawing.Size(96, 23)
        Me.btnSueldo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSueldo.TabIndex = 15
        Me.btnSueldo.Value = True
        Me.btnSueldo.ValueObject = "Y"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Window
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(109, 15)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Submotivo de baja"
        '
        'cmbSubTransferencia
        '
        Me.cmbSubTransferencia.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbSubTransferencia.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbSubTransferencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbSubTransferencia.ButtonDropDown.Visible = True
        Me.cmbSubTransferencia.Columns.Add(Me.codSubBaj)
        Me.cmbSubTransferencia.Columns.Add(Me.nomSubBaj)
        Me.cmbSubTransferencia.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbSubTransferencia.Location = New System.Drawing.Point(133, 91)
        Me.cmbSubTransferencia.Name = "cmbSubTransferencia"
        Me.cmbSubTransferencia.Size = New System.Drawing.Size(452, 23)
        Me.cmbSubTransferencia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbSubTransferencia.TabIndex = 11
        Me.cmbSubTransferencia.ValueMember = "CÓDIGO"
        '
        'codSubBaj
        '
        Me.codSubBaj.ColumnName = "CÓDIGO"
        Me.codSubBaj.DataFieldName = "CÓDIGO"
        Me.codSubBaj.Name = "codSubBaj"
        Me.codSubBaj.Text = "CÓD"
        Me.codSubBaj.Width.Absolute = 40
        '
        'nomSubBaj
        '
        Me.nomSubBaj.ColumnName = "MOTIVO"
        Me.nomSubBaj.DataFieldName = "MOTIVO"
        Me.nomSubBaj.Name = "nomSubBaj"
        Me.nomSubBaj.StretchToFill = True
        Me.nomSubBaj.Text = "NOMBRE"
        Me.nomSubBaj.Width.Absolute = 150
        Me.nomSubBaj.Width.AutoSize = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Window
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(361, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(122, 15)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Respetar antigüedad"
        '
        'btnAntiguedad
        '
        '
        '
        '
        Me.btnAntiguedad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnAntiguedad.Location = New System.Drawing.Point(489, 9)
        Me.btnAntiguedad.Name = "btnAntiguedad"
        Me.btnAntiguedad.OffText = "NO"
        Me.btnAntiguedad.OnText = "SI"
        Me.btnAntiguedad.Size = New System.Drawing.Size(96, 23)
        Me.btnAntiguedad.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAntiguedad.TabIndex = 3
        '
        'cmbBajaImssTrans
        '
        Me.cmbBajaImssTrans.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbBajaImssTrans.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbBajaImssTrans.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbBajaImssTrans.ButtonDropDown.Visible = True
        Me.cmbBajaImssTrans.Columns.Add(Me.ColCodBa)
        Me.cmbBajaImssTrans.Columns.Add(Me.ColMotBa)
        Me.cmbBajaImssTrans.DropDownHeight = 250
        Me.cmbBajaImssTrans.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbBajaImssTrans.Location = New System.Drawing.Point(133, 119)
        Me.cmbBajaImssTrans.Name = "cmbBajaImssTrans"
        Me.cmbBajaImssTrans.Size = New System.Drawing.Size(452, 23)
        Me.cmbBajaImssTrans.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbBajaImssTrans.TabIndex = 13
        Me.cmbBajaImssTrans.ValueMember = "CÓDIGO"
        '
        'cmbBajaInternoTrans
        '
        Me.cmbBajaInternoTrans.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbBajaInternoTrans.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbBajaInternoTrans.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbBajaInternoTrans.ButtonDropDown.Visible = True
        Me.cmbBajaInternoTrans.Columns.Add(Me.ColCodBa)
        Me.cmbBajaInternoTrans.Columns.Add(Me.ColMotBa)
        Me.cmbBajaInternoTrans.DropDownHeight = 250
        Me.cmbBajaInternoTrans.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbBajaInternoTrans.Location = New System.Drawing.Point(133, 63)
        Me.cmbBajaInternoTrans.Name = "cmbBajaInternoTrans"
        Me.cmbBajaInternoTrans.Size = New System.Drawing.Size(452, 23)
        Me.cmbBajaInternoTrans.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbBajaInternoTrans.TabIndex = 9
        Me.cmbBajaInternoTrans.ValueMember = "CÓDIGO"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Window
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 13)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(112, 15)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Nuevo reloj (inicial)"
        '
        'txtRelojInicial
        '
        Me.txtRelojInicial.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtRelojInicial.Border.Class = "TextBoxBorder"
        Me.txtRelojInicial.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRelojInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRelojInicial.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtRelojInicial.Location = New System.Drawing.Point(133, 9)
        Me.txtRelojInicial.Name = "txtRelojInicial"
        Me.txtRelojInicial.Size = New System.Drawing.Size(96, 23)
        Me.txtRelojInicial.TabIndex = 1
        '
        'txtAltaTrans
        '
        '
        '
        '
        Me.txtAltaTrans.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtAltaTrans.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAltaTrans.ButtonDropDown.Visible = True
        Me.txtAltaTrans.DisabledForeColor = System.Drawing.Color.Black
        Me.txtAltaTrans.FocusHighlightEnabled = True
        Me.txtAltaTrans.IsPopupCalendarOpen = False
        Me.txtAltaTrans.Location = New System.Drawing.Point(133, 37)
        '
        '
        '
        Me.txtAltaTrans.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtAltaTrans.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtAltaTrans.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAltaTrans.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtAltaTrans.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtAltaTrans.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAltaTrans.MonthCalendar.DisplayMonth = New Date(2007, 10, 1, 0, 0, 0, 0)
        Me.txtAltaTrans.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtAltaTrans.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtAltaTrans.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtAltaTrans.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtAltaTrans.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtAltaTrans.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAltaTrans.MonthCalendar.TodayButtonVisible = True
        Me.txtAltaTrans.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtAltaTrans.Name = "txtAltaTrans"
        Me.txtAltaTrans.Size = New System.Drawing.Size(96, 21)
        Me.txtAltaTrans.TabIndex = 5
        Me.txtAltaTrans.Value = New Date(2014, 12, 29, 0, 0, 0, 0)
        '
        'lblAltaTrans
        '
        Me.lblAltaTrans.AutoSize = True
        Me.lblAltaTrans.BackColor = System.Drawing.SystemColors.Window
        Me.lblAltaTrans.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAltaTrans.Location = New System.Drawing.Point(3, 40)
        Me.lblAltaTrans.Name = "lblAltaTrans"
        Me.lblAltaTrans.Size = New System.Drawing.Size(81, 15)
        Me.lblAltaTrans.TabIndex = 4
        Me.lblAltaTrans.Text = "Fecha de alta"
        '
        'cmbComentariosTrans
        '
        '
        '
        '
        Me.cmbComentariosTrans.Border.Class = "TextBoxBorder"
        Me.cmbComentariosTrans.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbComentariosTrans.Location = New System.Drawing.Point(133, 203)
        Me.cmbComentariosTrans.Multiline = True
        Me.cmbComentariosTrans.Name = "cmbComentariosTrans"
        Me.cmbComentariosTrans.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.cmbComentariosTrans.Size = New System.Drawing.Size(452, 54)
        Me.cmbComentariosTrans.TabIndex = 21
        Me.cmbComentariosTrans.Text = "Transferencia "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 203)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Comentarios"
        '
        'txtBajaTrans
        '
        '
        '
        '
        Me.txtBajaTrans.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtBajaTrans.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBajaTrans.ButtonDropDown.Visible = True
        Me.txtBajaTrans.DisabledForeColor = System.Drawing.Color.Black
        Me.txtBajaTrans.FocusHighlightEnabled = True
        Me.txtBajaTrans.IsPopupCalendarOpen = False
        Me.txtBajaTrans.Location = New System.Drawing.Point(489, 37)
        '
        '
        '
        Me.txtBajaTrans.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtBajaTrans.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtBajaTrans.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBajaTrans.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtBajaTrans.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtBajaTrans.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBajaTrans.MonthCalendar.DisplayMonth = New Date(2007, 10, 1, 0, 0, 0, 0)
        Me.txtBajaTrans.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtBajaTrans.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtBajaTrans.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtBajaTrans.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtBajaTrans.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtBajaTrans.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBajaTrans.MonthCalendar.TodayButtonVisible = True
        Me.txtBajaTrans.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtBajaTrans.Name = "txtBajaTrans"
        Me.txtBajaTrans.Size = New System.Drawing.Size(96, 21)
        Me.txtBajaTrans.TabIndex = 7
        Me.txtBajaTrans.Value = New Date(2007, 7, 7, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 15)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Motivo de baja IMSS"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Motivo de baja interno"
        '
        'lblBajaTrans
        '
        Me.lblBajaTrans.AutoSize = True
        Me.lblBajaTrans.BackColor = System.Drawing.SystemColors.Window
        Me.lblBajaTrans.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBajaTrans.Location = New System.Drawing.Point(361, 40)
        Me.lblBajaTrans.Name = "lblBajaTrans"
        Me.lblBajaTrans.Size = New System.Drawing.Size(85, 15)
        Me.lblBajaTrans.TabIndex = 6
        Me.lblBajaTrans.Text = "Fecha de baja"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cpActualizacion)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(5, 580)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1021, 47)
        Me.Panel1.TabIndex = 5
        '
        'frmCambiosMasivos
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(1031, 632)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gpTransferencias)
        Me.Controls.Add(Me.gpBajas)
        Me.Controls.Add(Me.gpValores)
        Me.Controls.Add(Me.gpEmpleados)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.picImagen)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCambiosMasivos"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambios masivos a archivo de personal"
        Me.gpEmpleados.ResumeLayout(False)
        Me.gpEmpleados.PerformLayout()
        Me.gpValores.ResumeLayout(False)
        Me.gpValores.PerformLayout()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpBajas.ResumeLayout(False)
        Me.gpBajas.PerformLayout()
        CType(Me.txtEBaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpTransferencias.ResumeLayout(False)
        Me.gpTransferencias.PerformLayout()
        CType(Me.txtAltaTrans, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBajaTrans, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Private WithEvents gpEmpleados As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents txtLista As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnLista As System.Windows.Forms.RadioButton
    Friend WithEvents btnArchivo As System.Windows.Forms.RadioButton
    Friend WithEvents btnBuscaArchivo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtArchivo As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents gpValores As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dlgArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnBuscaLista As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmbValorNuevo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cpActualizacion As DevComponents.DotNetBar.Controls.ProgressBarX
    Private WithEvents gpBajas As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cmbBajaInterno As DevComponents.DotNetBar.Controls.ComboTree
    Private WithEvents txtEBaja As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents txtValorNuevo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ColCiaValor As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColCodValor As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColNombreValor As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents txtComentarios As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents gpTransferencias As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRelojInicial As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents txtAltaTrans As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents lblAltaTrans As System.Windows.Forms.Label
    Friend WithEvents cmbComentariosTrans As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents txtBajaTrans As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblBajaTrans As System.Windows.Forms.Label
    Friend WithEvents cmbCampo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents btnLogico As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents txtFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents ColCodBa As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColMotBa As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents cmbBajaImss As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cmbBajaImssTrans As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cmbBajaInternoTrans As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents btnAntiguedad As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbSubBaja As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbSubTransferencia As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents colSubBaja As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colNombreSubBaja As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents codSubBaj As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents nomSubBaj As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblNivel As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnSueldo As DevComponents.DotNetBar.Controls.SwitchButton
    Private WithEvents cmbNivel As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents lblSueldo As System.Windows.Forms.Label
    Friend WithEvents txtSActual As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents colNivel As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colNombreNivel As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colTipoNivel As DevComponents.AdvTree.ColumnHeader
End Class
