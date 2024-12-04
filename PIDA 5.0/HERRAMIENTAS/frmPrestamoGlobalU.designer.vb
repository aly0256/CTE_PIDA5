<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrestamoGlobalU
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrestamoGlobalU))
        Me.cpActualizacion = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.gpEmpleados = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.btnBuscaLista = New DevComponents.DotNetBar.ButtonX()
        Me.txtLista = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnLista = New System.Windows.Forms.RadioButton()
        Me.btnArchivo = New System.Windows.Forms.RadioButton()
        Me.btnBuscaArchivo = New DevComponents.DotNetBar.ButtonX()
        Me.txtArchivo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.gpValores = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbTalla = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.txtCantidad = New DevComponents.Editors.IntegerInput()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbUniformes = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpEmpleados.SuspendLayout()
        Me.gpValores.SuspendLayout()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cpActualizacion
        '
        '
        '
        '
        Me.cpActualizacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cpActualizacion.Location = New System.Drawing.Point(10, 298)
        Me.cpActualizacion.Name = "cpActualizacion"
        Me.cpActualizacion.Size = New System.Drawing.Size(298, 34)
        Me.cpActualizacion.TabIndex = 137
        Me.cpActualizacion.Text = "Reloj"
        Me.cpActualizacion.TextVisible = True
        Me.cpActualizacion.Visible = False
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.Clasificacion24
        Me.picImagen.Location = New System.Drawing.Point(10, 11)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(31, 30)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImagen.TabIndex = 133
        Me.picImagen.TabStop = False
        '
        'gpEmpleados
        '
        Me.gpEmpleados.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpEmpleados.BackColor = System.Drawing.Color.Transparent
        Me.gpEmpleados.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpEmpleados.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.gpEmpleados.Controls.Add(Me.btnBuscaLista)
        Me.gpEmpleados.Controls.Add(Me.txtLista)
        Me.gpEmpleados.Controls.Add(Me.btnLista)
        Me.gpEmpleados.Controls.Add(Me.btnArchivo)
        Me.gpEmpleados.Controls.Add(Me.btnBuscaArchivo)
        Me.gpEmpleados.Controls.Add(Me.txtArchivo)
        Me.gpEmpleados.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpEmpleados.Location = New System.Drawing.Point(10, 64)
        Me.gpEmpleados.Name = "gpEmpleados"
        Me.gpEmpleados.Size = New System.Drawing.Size(478, 124)
        '
        '
        '
        Me.gpEmpleados.Style.BackColor = System.Drawing.Color.White
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
        Me.gpEmpleados.TabIndex = 134
        Me.gpEmpleados.Text = "Empleados "
        '
        'btnBuscaLista
        '
        Me.btnBuscaLista.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscaLista.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscaLista.Enabled = False
        Me.btnBuscaLista.Location = New System.Drawing.Point(434, 70)
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
        Me.txtLista.Location = New System.Drawing.Point(26, 70)
        Me.txtLista.Name = "txtLista"
        Me.txtLista.Size = New System.Drawing.Size(406, 23)
        Me.txtLista.TabIndex = 4
        '
        'btnLista
        '
        Me.btnLista.AutoSize = True
        Me.btnLista.Location = New System.Drawing.Point(7, 50)
        Me.btnLista.Name = "btnLista"
        Me.btnLista.Size = New System.Drawing.Size(232, 17)
        Me.btnLista.TabIndex = 3
        Me.btnLista.Text = "Listar números de reloj, separados por coma"
        Me.btnLista.UseVisualStyleBackColor = True
        '
        'btnArchivo
        '
        Me.btnArchivo.AutoSize = True
        Me.btnArchivo.Checked = True
        Me.btnArchivo.Location = New System.Drawing.Point(7, 4)
        Me.btnArchivo.Name = "btnArchivo"
        Me.btnArchivo.Size = New System.Drawing.Size(137, 17)
        Me.btnArchivo.TabIndex = 0
        Me.btnArchivo.TabStop = True
        Me.btnArchivo.Text = "Buscar en archivo texto"
        Me.btnArchivo.UseVisualStyleBackColor = True
        '
        'btnBuscaArchivo
        '
        Me.btnBuscaArchivo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscaArchivo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscaArchivo.Location = New System.Drawing.Point(434, 24)
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
        Me.txtArchivo.Location = New System.Drawing.Point(26, 24)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.Size = New System.Drawing.Size(406, 23)
        Me.txtArchivo.TabIndex = 1
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
        Me.ReflectionLabel1.TabIndex = 132
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>PRÉSTAMO MASIVO  UNIFORMES</b></font>"
        '
        'gpValores
        '
        Me.gpValores.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpValores.BackColor = System.Drawing.Color.Transparent
        Me.gpValores.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpValores.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.gpValores.Controls.Add(Me.Label2)
        Me.gpValores.Controls.Add(Me.cmbTalla)
        Me.gpValores.Controls.Add(Me.txtCantidad)
        Me.gpValores.Controls.Add(Me.Label1)
        Me.gpValores.Controls.Add(Me.cmbUniformes)
        Me.gpValores.Controls.Add(Me.Label6)
        Me.gpValores.Controls.Add(Me.Label12)
        Me.gpValores.Controls.Add(Me.txtFecha)
        Me.gpValores.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpValores.Location = New System.Drawing.Point(10, 194)
        Me.gpValores.Name = "gpValores"
        Me.gpValores.Size = New System.Drawing.Size(478, 89)
        '
        '
        '
        Me.gpValores.Style.BackColor = System.Drawing.Color.White
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
        Me.gpValores.TabIndex = 135
        Me.gpValores.Text = "Uniformes"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(205, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 15)
        Me.Label2.TabIndex = 132
        Me.Label2.Text = "Talla"
        '
        'cmbTalla
        '
        Me.cmbTalla.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbTalla.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbTalla.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbTalla.ButtonDropDown.Visible = True
        Me.cmbTalla.DisplayMembers = "Código"
        Me.cmbTalla.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbTalla.Location = New System.Drawing.Point(245, 36)
        Me.cmbTalla.Name = "cmbTalla"
        Me.cmbTalla.Size = New System.Drawing.Size(48, 20)
        Me.cmbTalla.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTalla.TabIndex = 128
        Me.cmbTalla.Text = "cmbUniformes"
        Me.cmbTalla.ValueMember = "Código"
        '
        'txtCantidad
        '
        '
        '
        '
        Me.txtCantidad.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtCantidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCantidad.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtCantidad.Location = New System.Drawing.Point(380, 36)
        Me.txtCantidad.MaxValue = 10
        Me.txtCantidad.MinValue = 1
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.ShowUpDown = True
        Me.txtCantidad.Size = New System.Drawing.Size(80, 20)
        Me.txtCantidad.TabIndex = 129
        Me.txtCantidad.Value = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(318, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 15)
        Me.Label1.TabIndex = 127
        Me.Label1.Text = "Cantidad"
        '
        'cmbUniformes
        '
        Me.cmbUniformes.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbUniformes.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbUniformes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbUniformes.ButtonDropDown.Visible = True
        Me.cmbUniformes.Columns.Add(Me.ColumnHeader1)
        Me.cmbUniformes.Columns.Add(Me.ColumnHeader2)
        Me.cmbUniformes.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbUniformes.Location = New System.Drawing.Point(70, 4)
        Me.cmbUniformes.Name = "cmbUniformes"
        Me.cmbUniformes.Size = New System.Drawing.Size(390, 23)
        Me.cmbUniformes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbUniformes.TabIndex = 6
        Me.cmbUniformes.ValueMember = "Código"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.ColumnName = "Código"
        Me.ColumnHeader1.DataFieldName = "Código"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Código"
        Me.ColumnHeader1.Width.Absolute = 150
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.ColumnName = "Nombre"
        Me.ColumnHeader2.DataFieldName = "Nombre"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Uniforme"
        Me.ColumnHeader2.Width.Absolute = 150
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 15)
        Me.Label6.TabIndex = 84
        Me.Label6.Text = "Tipo"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 39)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(41, 15)
        Me.Label12.TabIndex = 80
        Me.Label12.Text = "Fecha"
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
        Me.txtFecha.Location = New System.Drawing.Point(70, 36)
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
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnAceptar)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Location = New System.Drawing.Point(314, 289)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(174, 47)
        Me.GroupBox1.TabIndex = 136
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
        'frmPrestamoGlobalU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 346)
        Me.Controls.Add(Me.cpActualizacion)
        Me.Controls.Add(Me.picImagen)
        Me.Controls.Add(Me.gpEmpleados)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.gpValores)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPrestamoGlobalU"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Préstamo masivo de uniformes"
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpEmpleados.ResumeLayout(False)
        Me.gpEmpleados.PerformLayout()
        Me.gpValores.ResumeLayout(False)
        Me.gpValores.PerformLayout()
        CType(Me.txtCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cpActualizacion As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Private WithEvents gpEmpleados As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btnBuscaLista As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtLista As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnLista As System.Windows.Forms.RadioButton
    Friend WithEvents btnArchivo As System.Windows.Forms.RadioButton
    Friend WithEvents btnBuscaArchivo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtArchivo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Private WithEvents gpValores As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents txtCantidad As DevComponents.Editors.IntegerInput
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbUniformes As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Private WithEvents txtFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbTalla As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
End Class
