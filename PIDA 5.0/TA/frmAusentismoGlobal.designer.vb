<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAusentismoGlobal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAusentismoGlobal))
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.txtFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.cpActualizacion = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.btnArchivo = New System.Windows.Forms.RadioButton()
        Me.btnBuscaArchivo = New DevComponents.DotNetBar.ButtonX()
        Me.txtArchivo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnBuscaLista = New DevComponents.DotNetBar.ButtonX()
        Me.txtLista = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnLista = New System.Windows.Forms.RadioButton()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.gpValores = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtDias = New DevComponents.Editors.IntegerInput()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbAusentismo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ColCiaValor = New DevComponents.AdvTree.ColumnHeader()
        Me.ColCodValor = New DevComponents.AdvTree.ColumnHeader()
        Me.ColNombreValor = New DevComponents.AdvTree.ColumnHeader()
        Me.dlgArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.gpAceptarCancelar = New System.Windows.Forms.GroupBox()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpValores.SuspendLayout()
        CType(Me.txtDias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpAceptarCancelar.SuspendLayout()
        Me.SuspendLayout()
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
        'txtFecha
        '
        '
        '
        '
        Me.txtFecha.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha.ButtonDropDown.Visible = True
        Me.txtFecha.DisabledForeColor = System.Drawing.Color.Black
        Me.txtFecha.FocusHighlightEnabled = True
        Me.txtFecha.IsPopupCalendarOpen = False
        Me.txtFecha.Location = New System.Drawing.Point(72, 157)
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
        Me.txtFecha.Size = New System.Drawing.Size(118, 20)
        Me.txtFecha.TabIndex = 126
        Me.txtFecha.Value = New Date(2007, 7, 7, 0, 0, 0, 0)
        '
        'cpActualizacion
        '
        '
        '
        '
        Me.cpActualizacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cpActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cpActualizacion.Location = New System.Drawing.Point(14, 301)
        Me.cpActualizacion.Name = "cpActualizacion"
        Me.cpActualizacion.Size = New System.Drawing.Size(298, 34)
        Me.cpActualizacion.TabIndex = 125
        Me.cpActualizacion.Text = "Reloj"
        Me.cpActualizacion.TextVisible = True
        Me.cpActualizacion.Visible = False
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.AusentismoParcial32
        Me.picImagen.Location = New System.Drawing.Point(14, 14)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(31, 30)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImagen.TabIndex = 119
        Me.picImagen.TabStop = False
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
        'btnArchivo
        '
        Me.btnArchivo.AutoSize = True
        Me.btnArchivo.BackColor = System.Drawing.SystemColors.Window
        Me.btnArchivo.Checked = True
        Me.btnArchivo.Location = New System.Drawing.Point(7, 6)
        Me.btnArchivo.Name = "btnArchivo"
        Me.btnArchivo.Size = New System.Drawing.Size(243, 17)
        Me.btnArchivo.TabIndex = 0
        Me.btnArchivo.TabStop = True
        Me.btnArchivo.Text = "Buscar en archivo excel (reloj, fecha, tipo aus)"
        Me.btnArchivo.UseVisualStyleBackColor = False
        '
        'btnBuscaArchivo
        '
        Me.btnBuscaArchivo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscaArchivo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscaArchivo.Location = New System.Drawing.Point(434, 29)
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
        Me.txtArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtArchivo.Location = New System.Drawing.Point(26, 29)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.Size = New System.Drawing.Size(406, 23)
        Me.txtArchivo.TabIndex = 1
        '
        'btnBuscaLista
        '
        Me.btnBuscaLista.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscaLista.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscaLista.Enabled = False
        Me.btnBuscaLista.Location = New System.Drawing.Point(434, 96)
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
        Me.txtLista.Location = New System.Drawing.Point(26, 96)
        Me.txtLista.Name = "txtLista"
        Me.txtLista.Size = New System.Drawing.Size(406, 23)
        Me.txtLista.TabIndex = 4
        '
        'btnLista
        '
        Me.btnLista.AutoSize = True
        Me.btnLista.BackColor = System.Drawing.SystemColors.Window
        Me.btnLista.Location = New System.Drawing.Point(7, 76)
        Me.btnLista.Name = "btnLista"
        Me.btnLista.Size = New System.Drawing.Size(232, 17)
        Me.btnLista.TabIndex = 3
        Me.btnLista.Text = "Listar números de reloj, separados por coma"
        Me.btnLista.UseVisualStyleBackColor = False
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
        Me.ReflectionLabel1.TabIndex = 118
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>AUSENTISMO MASIVO</b></font>"
        '
        'gpValores
        '
        Me.gpValores.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpValores.BackColor = System.Drawing.SystemColors.Control
        Me.gpValores.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpValores.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpValores.Controls.Add(Me.Panel1)
        Me.gpValores.Controls.Add(Me.btnArchivo)
        Me.gpValores.Controls.Add(Me.btnBuscaLista)
        Me.gpValores.Controls.Add(Me.txtDias)
        Me.gpValores.Controls.Add(Me.btnBuscaArchivo)
        Me.gpValores.Controls.Add(Me.Label1)
        Me.gpValores.Controls.Add(Me.txtLista)
        Me.gpValores.Controls.Add(Me.txtArchivo)
        Me.gpValores.Controls.Add(Me.cmbAusentismo)
        Me.gpValores.Controls.Add(Me.btnLista)
        Me.gpValores.Controls.Add(Me.Label6)
        Me.gpValores.Controls.Add(Me.Label12)
        Me.gpValores.Controls.Add(Me.txtFecha)
        Me.gpValores.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpValores.Location = New System.Drawing.Point(14, 66)
        Me.gpValores.Name = "gpValores"
        Me.gpValores.Size = New System.Drawing.Size(478, 220)
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
        Me.gpValores.TabIndex = 121
        Me.gpValores.Text = "Empleados a modificar"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightGray
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Location = New System.Drawing.Point(7, 61)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(456, 1)
        Me.Panel1.TabIndex = 129
        '
        'txtDias
        '
        '
        '
        '
        Me.txtDias.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtDias.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDias.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtDias.Location = New System.Drawing.Point(382, 157)
        Me.txtDias.MaxValue = 30
        Me.txtDias.MinValue = 1
        Me.txtDias.Name = "txtDias"
        Me.txtDias.ShowUpDown = True
        Me.txtDias.Size = New System.Drawing.Size(80, 20)
        Me.txtDias.TabIndex = 128
        Me.txtDias.Value = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(344, 160)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 15)
        Me.Label1.TabIndex = 127
        Me.Label1.Text = "Días"
        '
        'cmbAusentismo
        '
        Me.cmbAusentismo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbAusentismo.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbAusentismo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbAusentismo.ButtonDropDown.Visible = True
        Me.cmbAusentismo.Columns.Add(Me.ColumnHeader1)
        Me.cmbAusentismo.Columns.Add(Me.ColumnHeader2)
        Me.cmbAusentismo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbAusentismo.Location = New System.Drawing.Point(72, 127)
        Me.cmbAusentismo.Name = "cmbAusentismo"
        Me.cmbAusentismo.Size = New System.Drawing.Size(390, 23)
        Me.cmbAusentismo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbAusentismo.TabIndex = 6
        Me.cmbAusentismo.ValueMember = "tipo_aus"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.ColumnName = "tipo_aus"
        Me.ColumnHeader1.DataFieldName = "tipo_aus"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Tipo"
        Me.ColumnHeader1.Width.Absolute = 150
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 15)
        Me.Label6.TabIndex = 84
        Me.Label6.Text = "Tipo"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Window
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 160)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 15)
        Me.Label12.TabIndex = 80
        Me.Label12.Text = "Fecha"
        '
        'ColCiaValor
        '
        Me.ColCiaValor.DataFieldName = "comp"
        Me.ColCiaValor.Name = "ColCiaValor"
        Me.ColCiaValor.Text = "Cía."
        Me.ColCiaValor.Width.Absolute = 80
        '
        'ColCodValor
        '
        Me.ColCodValor.DataFieldName = "codigo"
        Me.ColCodValor.Name = "ColCodValor"
        Me.ColCodValor.Text = "Código"
        Me.ColCodValor.Width.Absolute = 80
        '
        'ColNombreValor
        '
        Me.ColNombreValor.DataFieldName = "nombre"
        Me.ColNombreValor.Name = "ColNombreValor"
        Me.ColNombreValor.Text = "Nombre"
        Me.ColNombreValor.Width.Absolute = 150
        Me.ColNombreValor.Width.AutoSize = True
        '
        'dlgArchivo
        '
        Me.dlgArchivo.FileName = "OpenFileDialog1"
        '
        'gpAceptarCancelar
        '
        Me.gpAceptarCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.gpAceptarCancelar.Controls.Add(Me.btnAceptar)
        Me.gpAceptarCancelar.Controls.Add(Me.btnCancelar)
        Me.gpAceptarCancelar.Location = New System.Drawing.Point(318, 292)
        Me.gpAceptarCancelar.Name = "gpAceptarCancelar"
        Me.gpAceptarCancelar.Size = New System.Drawing.Size(174, 47)
        Me.gpAceptarCancelar.TabIndex = 123
        Me.gpAceptarCancelar.TabStop = False
        '
        'frmAusentismoGlobal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(507, 346)
        Me.Controls.Add(Me.cpActualizacion)
        Me.Controls.Add(Me.picImagen)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.gpValores)
        Me.Controls.Add(Me.gpAceptarCancelar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAusentismoGlobal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ausentismo masivo"
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpValores.ResumeLayout(False)
        Me.gpValores.PerformLayout()
        CType(Me.txtDias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpAceptarCancelar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Private WithEvents txtFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents cpActualizacion As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBuscaLista As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtLista As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnLista As System.Windows.Forms.RadioButton
    Friend WithEvents btnArchivo As System.Windows.Forms.RadioButton
    Friend WithEvents btnBuscaArchivo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtArchivo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Private WithEvents gpValores As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents ColCiaValor As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColCodValor As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColNombreValor As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents cmbAusentismo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dlgArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents gpAceptarCancelar As System.Windows.Forms.GroupBox
    Friend WithEvents txtDias As DevComponents.Editors.IntegerInput
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
