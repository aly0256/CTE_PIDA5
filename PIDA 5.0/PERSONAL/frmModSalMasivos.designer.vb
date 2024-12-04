<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModSalMasivos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModSalMasivos))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.gpSueldos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.btnBuscaLista = New DevComponents.DotNetBar.ButtonX()
        Me.txtLista = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnLista = New System.Windows.Forms.RadioButton()
        Me.btnArchivo = New System.Windows.Forms.RadioButton()
        Me.btnBuscaArchivo = New DevComponents.DotNetBar.ButtonX()
        Me.txtArchivo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.cmbNiveles = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader()
        Me.txtFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.cmbTipoModSal = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.CodMod = New DevComponents.AdvTree.ColumnHeader()
        Me.NombreMod = New DevComponents.AdvTree.ColumnHeader()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtCambioA = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNotas = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dlgArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.cpActualizacion = New DevComponents.DotNetBar.Controls.ProgressBarX()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpSueldos.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ReflectionLabel1.Location = New System.Drawing.Point(52, 14)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(451, 46)
        Me.ReflectionLabel1.TabIndex = 111
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>MODIFICACIONES MASIVAS DE SUELDO</b></font>"
        '
        'picImagen
        '
        '        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.ModificacionesSueldo24
        Me.picImagen.Location = New System.Drawing.Point(14, 14)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(31, 30)
        Me.picImagen.TabIndex = 112
        Me.picImagen.TabStop = False
        '
        'gpSueldos
        '
        Me.gpSueldos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpSueldos.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpSueldos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpSueldos.Controls.Add(Me.btnBuscaLista)
        Me.gpSueldos.Controls.Add(Me.txtLista)
        Me.gpSueldos.Controls.Add(Me.btnLista)
        Me.gpSueldos.Controls.Add(Me.btnArchivo)
        Me.gpSueldos.Controls.Add(Me.btnBuscaArchivo)
        Me.gpSueldos.Controls.Add(Me.txtArchivo)
        Me.gpSueldos.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpSueldos.Location = New System.Drawing.Point(14, 67)
        Me.gpSueldos.Name = "gpSueldos"
        Me.gpSueldos.Size = New System.Drawing.Size(478, 140)
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
        Me.gpSueldos.TabIndex = 113
        Me.gpSueldos.Text = "Empleados a modificar"
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
        Me.txtLista.ButtonCustom.Tooltip = ""
        Me.txtLista.ButtonCustom2.Tooltip = ""
        Me.txtLista.Enabled = False
        Me.txtLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLista.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLista.Location = New System.Drawing.Point(26, 83)
        Me.txtLista.Name = "txtLista"
        Me.txtLista.Size = New System.Drawing.Size(406, 23)
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
        Me.btnBuscaArchivo.Location = New System.Drawing.Point(434, 33)
        Me.btnBuscaArchivo.Name = "btnBuscaArchivo"
        Me.btnBuscaArchivo.Size = New System.Drawing.Size(26, 23)
        Me.btnBuscaArchivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
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
        Me.txtArchivo.ButtonCustom.Tooltip = ""
        Me.txtArchivo.ButtonCustom2.Tooltip = ""
        Me.txtArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtArchivo.Location = New System.Drawing.Point(26, 33)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.Size = New System.Drawing.Size(406, 23)
        Me.txtArchivo.TabIndex = 1
        '
        'GroupPanel1
        '
        Me.GroupPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel1.Controls.Add(Me.cmbNiveles)
        Me.GroupPanel1.Controls.Add(Me.txtFecha)
        Me.GroupPanel1.Controls.Add(Me.cmbTipoModSal)
        Me.GroupPanel1.Controls.Add(Me.Label6)
        Me.GroupPanel1.Controls.Add(Me.Label22)
        Me.GroupPanel1.Controls.Add(Me.txtCambioA)
        Me.GroupPanel1.Controls.Add(Me.Label5)
        Me.GroupPanel1.Controls.Add(Me.txtNotas)
        Me.GroupPanel1.Controls.Add(Me.Label18)
        Me.GroupPanel1.Controls.Add(Me.Label12)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(14, 213)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(478, 193)
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
        Me.GroupPanel1.TabIndex = 114
        Me.GroupPanel1.Text = "Información"
        '
        'cmbNiveles
        '
        Me.cmbNiveles.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbNiveles.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbNiveles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbNiveles.ButtonClear.Tooltip = ""
        Me.cmbNiveles.ButtonCustom.Tooltip = ""
        Me.cmbNiveles.ButtonCustom2.Tooltip = ""
        Me.cmbNiveles.ButtonDropDown.Tooltip = ""
        Me.cmbNiveles.ButtonDropDown.Visible = True
        Me.cmbNiveles.Columns.Add(Me.ColumnHeader2)
        Me.cmbNiveles.Columns.Add(Me.ColumnHeader1)
        Me.cmbNiveles.Columns.Add(Me.ColumnHeader4)
        Me.cmbNiveles.Columns.Add(Me.ColumnHeader5)
        Me.cmbNiveles.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbNiveles.Location = New System.Drawing.Point(114, 34)
        Me.cmbNiveles.Name = "cmbNiveles"
        Me.cmbNiveles.Size = New System.Drawing.Size(346, 23)
        Me.cmbNiveles.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbNiveles.TabIndex = 7
        Me.cmbNiveles.ValueMember = "nivel"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "cod_comp"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Comp."
        Me.ColumnHeader2.Width.Absolute = 50
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "Nivel"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Código"
        Me.ColumnHeader1.Width.Absolute = 50
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DataFieldName = "Nombre"
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "Nombre"
        Me.ColumnHeader4.Width.Absolute = 100
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DataFieldName = "Sueldo"
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.StretchToFill = True
        Me.ColumnHeader5.Text = "Sueldo"
        Me.ColumnHeader5.Width.Absolute = 150
        '
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha.ButtonClear.Tooltip = ""
        Me.txtFecha.ButtonCustom.Tooltip = ""
        Me.txtFecha.ButtonCustom2.Tooltip = ""
        Me.txtFecha.ButtonDropDown.Tooltip = ""
        Me.txtFecha.ButtonDropDown.Visible = True
        Me.txtFecha.ButtonFreeText.Tooltip = ""
        Me.txtFecha.DisabledForeColor = System.Drawing.Color.Black
        Me.txtFecha.FocusHighlightEnabled = True
        Me.txtFecha.IsPopupCalendarOpen = False
        Me.txtFecha.Location = New System.Drawing.Point(114, 88)
        '
        '
        '
        Me.txtFecha.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFecha.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtFecha.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtFecha.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFecha.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha.MonthCalendar.DisplayMonth = New Date(2007, 10, 1, 0, 0, 0, 0)
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
        Me.txtFecha.Size = New System.Drawing.Size(346, 21)
        Me.txtFecha.TabIndex = 9
        Me.txtFecha.Value = New Date(2007, 7, 7, 0, 0, 0, 0)
        '
        'cmbTipoModSal
        '
        Me.cmbTipoModSal.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbTipoModSal.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbTipoModSal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbTipoModSal.ButtonClear.Tooltip = ""
        Me.cmbTipoModSal.ButtonCustom.Tooltip = ""
        Me.cmbTipoModSal.ButtonCustom2.Tooltip = ""
        Me.cmbTipoModSal.ButtonDropDown.Tooltip = ""
        Me.cmbTipoModSal.ButtonDropDown.Visible = True
        Me.cmbTipoModSal.Columns.Add(Me.CodMod)
        Me.cmbTipoModSal.Columns.Add(Me.NombreMod)
        Me.cmbTipoModSal.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbTipoModSal.Location = New System.Drawing.Point(114, 7)
        Me.cmbTipoModSal.Name = "cmbTipoModSal"
        Me.cmbTipoModSal.Size = New System.Drawing.Size(346, 23)
        Me.cmbTipoModSal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipoModSal.TabIndex = 6
        Me.cmbTipoModSal.ValueMember = "cod_tipo_mod"
        '
        'CodMod
        '
        Me.CodMod.DataFieldName = "cod_tipo_mod"
        Me.CodMod.Name = "CodMod"
        Me.CodMod.Text = "Código"
        Me.CodMod.Width.Absolute = 50
        '
        'NombreMod
        '
        Me.NombreMod.DataFieldName = "Nombre"
        Me.NombreMod.Name = "NombreMod"
        Me.NombreMod.StretchToFill = True
        Me.NombreMod.Text = "Nombre"
        Me.NombreMod.Width.Absolute = 150
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 15)
        Me.Label6.TabIndex = 84
        Me.Label6.Text = "Tipo mod. sueldo"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.SystemColors.Window
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(4, 61)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(63, 15)
        Me.Label22.TabIndex = 83
        Me.Label22.Text = "Cambio a:"
        '
        'txtCambioA
        '
        Me.txtCambioA.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtCambioA.Border.Class = "TextBoxBorder"
        Me.txtCambioA.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCambioA.ButtonCustom.Tooltip = ""
        Me.txtCambioA.ButtonCustom2.Tooltip = ""
        Me.txtCambioA.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCambioA.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCambioA.Location = New System.Drawing.Point(114, 61)
        Me.txtCambioA.Name = "txtCambioA"
        Me.txtCambioA.Size = New System.Drawing.Size(346, 23)
        Me.txtCambioA.TabIndex = 8
        Me.txtCambioA.Text = "0.00"
        Me.txtCambioA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 113)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 15)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "Notas"
        '
        'txtNotas
        '
        Me.txtNotas.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtNotas.Border.Class = "TextBoxBorder"
        Me.txtNotas.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNotas.ButtonCustom.Tooltip = ""
        Me.txtNotas.ButtonCustom2.Tooltip = ""
        Me.txtNotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotas.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNotas.Location = New System.Drawing.Point(114, 113)
        Me.txtNotas.MaxLength = 200
        Me.txtNotas.Multiline = True
        Me.txtNotas.Name = "txtNotas"
        Me.txtNotas.Size = New System.Drawing.Size(346, 48)
        Me.txtNotas.TabIndex = 10
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.SystemColors.Window
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(4, 88)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(41, 15)
        Me.Label18.TabIndex = 81
        Me.Label18.Text = "Fecha"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Window
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 34)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 15)
        Me.Label12.TabIndex = 80
        Me.Label12.Text = "Nivel"
        '
        'dlgArchivo
        '
        Me.dlgArchivo.FileName = "OpenFileDialog1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAceptar)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Location = New System.Drawing.Point(318, 407)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(174, 47)
        Me.GroupBox1.TabIndex = 115
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
        Me.btnAceptar.TabIndex = 11
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
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Text = "Cancelar"
        '
        'cpActualizacion
        '
        '
        '
        '
        Me.cpActualizacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cpActualizacion.Location = New System.Drawing.Point(14, 412)
        Me.cpActualizacion.Name = "cpActualizacion"
        Me.cpActualizacion.Size = New System.Drawing.Size(298, 42)
        Me.cpActualizacion.TabIndex = 117
        Me.cpActualizacion.Text = "Reloj"
        Me.cpActualizacion.TextVisible = True
        Me.cpActualizacion.Visible = False
        '
        'frmModSalMasivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 460)
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
        Me.Name = "frmModSalMasivos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cambios masivos de sueldo"
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpSueldos.ResumeLayout(False)
        Me.gpSueldos.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
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
    Private WithEvents txtFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents cmbTipoModSal As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtCambioA As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNotas As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CodMod As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NombreMod As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents dlgArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnBuscaLista As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmbNiveles As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents cpActualizacion As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
End Class
