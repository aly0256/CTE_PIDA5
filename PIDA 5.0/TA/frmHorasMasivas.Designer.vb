<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHorasMasivas
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
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.ColNombreValor = New DevComponents.AdvTree.ColumnHeader()
        Me.ColCodValor = New DevComponents.AdvTree.ColumnHeader()
        Me.gpEmpleados = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.LabelStatus = New DevComponents.DotNetBar.LabelX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.DataGridViewX1 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.DateTimeInput1 = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.btnBuscaArchivo = New DevComponents.DotNetBar.ButtonX()
        Me.txtArchivo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ColCiaValor = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.dlgArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.ColumnReloj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnNombres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnHorario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnDepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnHora = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnComentario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gpEmpleados.SuspendLayout()
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DateTimeInput1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(48, 11)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(451, 46)
        Me.ReflectionLabel1.TabIndex = 126
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CARGA MASIVA DE HORAS</b></font>"
        '
        'ColNombreValor
        '
        Me.ColNombreValor.DataFieldName = "nombre"
        Me.ColNombreValor.Name = "ColNombreValor"
        Me.ColNombreValor.Text = "Nombre"
        Me.ColNombreValor.Width.Absolute = 150
        Me.ColNombreValor.Width.AutoSize = True
        '
        'ColCodValor
        '
        Me.ColCodValor.DataFieldName = "codigo"
        Me.ColCodValor.Name = "ColCodValor"
        Me.ColCodValor.Text = "Código"
        Me.ColCodValor.Width.Absolute = 80
        '
        'gpEmpleados
        '
        Me.gpEmpleados.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpEmpleados.BackColor = System.Drawing.SystemColors.Control
        Me.gpEmpleados.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpEmpleados.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpEmpleados.Controls.Add(Me.LabelStatus)
        Me.gpEmpleados.Controls.Add(Me.btnCancelar)
        Me.gpEmpleados.Controls.Add(Me.LabelX3)
        Me.gpEmpleados.Controls.Add(Me.btnAceptar)
        Me.gpEmpleados.Controls.Add(Me.LabelX2)
        Me.gpEmpleados.Controls.Add(Me.DataGridViewX1)
        Me.gpEmpleados.Controls.Add(Me.LabelX1)
        Me.gpEmpleados.Controls.Add(Me.DateTimeInput1)
        Me.gpEmpleados.Controls.Add(Me.btnBuscaArchivo)
        Me.gpEmpleados.Controls.Add(Me.txtArchivo)
        Me.gpEmpleados.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpEmpleados.Location = New System.Drawing.Point(10, 64)
        Me.gpEmpleados.Name = "gpEmpleados"
        Me.gpEmpleados.Size = New System.Drawing.Size(725, 322)
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
        Me.gpEmpleados.TabIndex = 128
        Me.gpEmpleados.Text = "Empleados a modificar"
        '
        'LabelStatus
        '
        Me.LabelStatus.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelStatus.Location = New System.Drawing.Point(3, 269)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(388, 23)
        Me.LabelStatus.TabIndex = 132
        Me.LabelStatus.Text = "Estatus: -"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelar.Location = New System.Drawing.Point(634, 269)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 131
        Me.btnCancelar.Text = "Salir"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(3, 58)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(677, 23)
        Me.LabelX3.TabIndex = 13
        Me.LabelX3.Text = "Seleccionar archivo de horas (Archivo de Excel con formato [RELOJ][HORA] en las c" & _
    "olumnas A y B)"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.Location = New System.Drawing.Point(550, 269)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.TabIndex = 12
        Me.btnAceptar.Text = "Aplicar"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(3, 110)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(388, 23)
        Me.LabelX2.TabIndex = 6
        Me.LabelX2.Text = "Información por aplicar, los registros marcados en rojo no son válidos"
        '
        'DataGridViewX1
        '
        Me.DataGridViewX1.AllowUserToAddRows = False
        Me.DataGridViewX1.AllowUserToDeleteRows = False
        Me.DataGridViewX1.AllowUserToResizeColumns = False
        Me.DataGridViewX1.AllowUserToResizeRows = False
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewX1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.DataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewX1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnReloj, Me.ColumnNombres, Me.ColumnHorario, Me.ColumnDepto, Me.ColumnFecha, Me.ColumnHora, Me.ColumnComentario})
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewX1.DefaultCellStyle = DataGridViewCellStyle20
        Me.DataGridViewX1.EnableHeadersVisualStyles = False
        Me.DataGridViewX1.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DataGridViewX1.Location = New System.Drawing.Point(3, 139)
        Me.DataGridViewX1.Name = "DataGridViewX1"
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewX1.RowHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.DataGridViewX1.Size = New System.Drawing.Size(709, 124)
        Me.DataGridViewX1.TabIndex = 5
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(3, 3)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(163, 23)
        Me.LabelX1.TabIndex = 4
        Me.LabelX1.Text = "Seleccionar fecha"
        '
        'DateTimeInput1
        '
        '
        '
        '
        Me.DateTimeInput1.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.DateTimeInput1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInput1.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.DateTimeInput1.ButtonDropDown.Visible = True
        Me.DateTimeInput1.IsPopupCalendarOpen = False
        Me.DateTimeInput1.Location = New System.Drawing.Point(3, 32)
        '
        '
        '
        Me.DateTimeInput1.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInput1.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInput1.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.DateTimeInput1.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.DateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.DateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.DateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.DateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.DateTimeInput1.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.DateTimeInput1.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInput1.MonthCalendar.DisplayMonth = New Date(2016, 1, 1, 0, 0, 0, 0)
        Me.DateTimeInput1.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.DateTimeInput1.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.DateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.DateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.DateTimeInput1.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.DateTimeInput1.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.DateTimeInput1.MonthCalendar.TodayButtonVisible = True
        Me.DateTimeInput1.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.DateTimeInput1.Name = "DateTimeInput1"
        Me.DateTimeInput1.Size = New System.Drawing.Size(163, 20)
        Me.DateTimeInput1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DateTimeInput1.TabIndex = 3
        '
        'btnBuscaArchivo
        '
        Me.btnBuscaArchivo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscaArchivo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscaArchivo.Location = New System.Drawing.Point(686, 81)
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
        Me.txtArchivo.Enabled = False
        Me.txtArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtArchivo.Location = New System.Drawing.Point(3, 81)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.Size = New System.Drawing.Size(677, 23)
        Me.txtArchivo.TabIndex = 1
        '
        'ColCiaValor
        '
        Me.ColCiaValor.DataFieldName = "comp"
        Me.ColCiaValor.Name = "ColCiaValor"
        Me.ColCiaValor.Text = "Cía."
        Me.ColCiaValor.Width.Absolute = 80
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.ColumnName = "Nombre"
        Me.ColumnHeader2.DataFieldName = "Nombre"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.StretchToFill = True
        Me.ColumnHeader2.Text = "Nombre"
        Me.ColumnHeader2.Width.Absolute = 150
        Me.ColumnHeader2.Width.AutoSize = True
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.ColumnName = "tipo_aus"
        Me.ColumnHeader1.DataFieldName = "tipo_aus"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Tipo"
        Me.ColumnHeader1.Width.Absolute = 150
        '
        'dlgArchivo
        '
        Me.dlgArchivo.FileName = "OpenFileDialog1"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.AusentismoParcial32
        Me.picImagen.Location = New System.Drawing.Point(10, 11)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(31, 30)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImagen.TabIndex = 127
        Me.picImagen.TabStop = False
        '
        'ColumnReloj
        '
        Me.ColumnReloj.DataPropertyName = "reloj"
        Me.ColumnReloj.HeaderText = "Reloj"
        Me.ColumnReloj.Name = "ColumnReloj"
        Me.ColumnReloj.ReadOnly = True
        Me.ColumnReloj.Width = 75
        '
        'ColumnNombres
        '
        Me.ColumnNombres.DataPropertyName = "nombres"
        Me.ColumnNombres.HeaderText = "Nombres"
        Me.ColumnNombres.Name = "ColumnNombres"
        Me.ColumnNombres.ReadOnly = True
        Me.ColumnNombres.Width = 175
        '
        'ColumnHorario
        '
        Me.ColumnHorario.DataPropertyName = "cod_hora"
        Me.ColumnHorario.HeaderText = "Horario"
        Me.ColumnHorario.Name = "ColumnHorario"
        Me.ColumnHorario.ReadOnly = True
        Me.ColumnHorario.Width = 50
        '
        'ColumnDepto
        '
        Me.ColumnDepto.DataPropertyName = "cod_depto"
        Me.ColumnDepto.HeaderText = "Depto."
        Me.ColumnDepto.Name = "ColumnDepto"
        Me.ColumnDepto.ReadOnly = True
        Me.ColumnDepto.Width = 75
        '
        'ColumnFecha
        '
        Me.ColumnFecha.DataPropertyName = "fecha"
        Me.ColumnFecha.HeaderText = "Fecha"
        Me.ColumnFecha.Name = "ColumnFecha"
        Me.ColumnFecha.ReadOnly = True
        Me.ColumnFecha.Width = 75
        '
        'ColumnHora
        '
        Me.ColumnHora.DataPropertyName = "hora"
        Me.ColumnHora.HeaderText = "Hora"
        Me.ColumnHora.Name = "ColumnHora"
        Me.ColumnHora.ReadOnly = True
        Me.ColumnHora.Width = 75
        '
        'ColumnComentario
        '
        Me.ColumnComentario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColumnComentario.DataPropertyName = "comentario"
        Me.ColumnComentario.HeaderText = "Comentario"
        Me.ColumnComentario.Name = "ColumnComentario"
        Me.ColumnComentario.ReadOnly = True
        '
        'frmHorasMasivas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(747, 394)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.picImagen)
        Me.Controls.Add(Me.gpEmpleados)
        Me.MaximizeBox = False
        Me.Name = "frmHorasMasivas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Carga masiva de registros de asistencia"
        Me.gpEmpleados.ResumeLayout(False)
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DateTimeInput1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents ColNombreValor As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents ColCodValor As DevComponents.AdvTree.ColumnHeader
    Private WithEvents gpEmpleados As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btnBuscaArchivo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtArchivo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ColCiaValor As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents dlgArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents DateTimeInput1 As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents DataGridViewX1 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelStatus As DevComponents.DotNetBar.LabelX
    Friend WithEvents ColumnReloj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnNombres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnHorario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnDepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnHora As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnComentario As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
