<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSuspenderCreditoInfonavit
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
        Me.cmbTipoInfonavitNombre = New DevComponents.AdvTree.ColumnHeader()
        Me.cmbTipoInfonavitCodigo = New DevComponents.AdvTree.ColumnHeader()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNombres = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.btnGuardar = New DevComponents.DotNetBar.ButtonX()
        Me.txtNumeroCredito = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dtpFechaSuspension = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dtpFechaSuspension, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbTipoInfonavitNombre
        '
        Me.cmbTipoInfonavitNombre.DataFieldName = "nombre"
        Me.cmbTipoInfonavitNombre.Name = "cmbTipoInfonavitNombre"
        Me.cmbTipoInfonavitNombre.Text = "Nombre"
        Me.cmbTipoInfonavitNombre.Width.Relative = 80
        '
        'cmbTipoInfonavitCodigo
        '
        Me.cmbTipoInfonavitCodigo.DataFieldName = "tipo"
        Me.cmbTipoInfonavitCodigo.Name = "cmbTipoInfonavitCodigo"
        Me.cmbTipoInfonavitCodigo.Text = "Tipo"
        Me.cmbTipoInfonavitCodigo.Width.Relative = 20
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblNombres)
        Me.Panel1.Controls.Add(Me.LabelX4)
        Me.Panel1.Controls.Add(Me.txtReloj)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(546, 59)
        Me.Panel1.TabIndex = 131
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "Nombre:"
        '
        'lblNombres
        '
        '
        '
        '
        Me.lblNombres.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblNombres.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombres.Location = New System.Drawing.Point(17, 32)
        Me.lblNombres.Name = "lblNombres"
        Me.lblNombres.SingleLineColor = System.Drawing.SystemColors.Control
        Me.lblNombres.Size = New System.Drawing.Size(320, 23)
        Me.lblNombres.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.lblNombres.TabIndex = 113
        Me.lblNombres.Text = "-,-,-"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(357, 15)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(48, 23)
        Me.LabelX4.TabIndex = 114
        Me.LabelX4.Text = "Reloj"
        '
        'txtReloj
        '
        Me.txtReloj.BackColor = System.Drawing.Color.LimeGreen
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtReloj.Location = New System.Drawing.Point(411, 12)
        Me.txtReloj.MaxLength = 6
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.ReadOnly = True
        Me.txtReloj.Size = New System.Drawing.Size(123, 29)
        Me.txtReloj.TabIndex = 115
        Me.txtReloj.Text = "999999"
        Me.txtReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCancelar.Location = New System.Drawing.Point(17, 139)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(123, 25)
        Me.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancelar.TabIndex = 130
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnGuardar
        '
        Me.btnGuardar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGuardar.CausesValidation = False
        Me.btnGuardar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnGuardar.Location = New System.Drawing.Point(411, 139)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(123, 25)
        Me.btnGuardar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGuardar.TabIndex = 129
        Me.btnGuardar.Text = "Suspender"
        '
        'txtNumeroCredito
        '
        Me.txtNumeroCredito.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtNumeroCredito.Border.Class = "TextBoxBorder"
        Me.txtNumeroCredito.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNumeroCredito.Enabled = False
        Me.txtNumeroCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroCredito.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNumeroCredito.Location = New System.Drawing.Point(301, 71)
        Me.txtNumeroCredito.Name = "txtNumeroCredito"
        Me.txtNumeroCredito.Size = New System.Drawing.Size(233, 26)
        Me.txtNumeroCredito.TabIndex = 124
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(13, 71)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(147, 17)
        Me.Label15.TabIndex = 123
        Me.Label15.Text = "Número de crédito:"
        '
        'dtpFechaSuspension
        '
        '
        '
        '
        Me.dtpFechaSuspension.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtpFechaSuspension.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFechaSuspension.ButtonCustom.Visible = True
        Me.dtpFechaSuspension.ButtonDropDown.Visible = True
        Me.dtpFechaSuspension.FocusHighlightEnabled = True
        Me.dtpFechaSuspension.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaSuspension.IsPopupCalendarOpen = False
        Me.dtpFechaSuspension.Location = New System.Drawing.Point(301, 102)
        '
        '
        '
        Me.dtpFechaSuspension.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpFechaSuspension.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.dtpFechaSuspension.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFechaSuspension.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtpFechaSuspension.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtpFechaSuspension.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFechaSuspension.MonthCalendar.DisplayMonth = New Date(2007, 10, 1, 0, 0, 0, 0)
        Me.dtpFechaSuspension.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtpFechaSuspension.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtpFechaSuspension.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtpFechaSuspension.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtpFechaSuspension.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtpFechaSuspension.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtpFechaSuspension.MonthCalendar.TodayButtonVisible = True
        Me.dtpFechaSuspension.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtpFechaSuspension.Name = "dtpFechaSuspension"
        Me.dtpFechaSuspension.Size = New System.Drawing.Size(233, 26)
        Me.dtpFechaSuspension.TabIndex = 126
        Me.dtpFechaSuspension.Value = New Date(2013, 10, 24, 13, 27, 15, 502)
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 102)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(162, 17)
        Me.Label16.TabIndex = 127
        Me.Label16.Text = "Fecha de suspensión"
        '
        'frmSuspenderCreditoInfonavit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(546, 169)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.dtpFechaSuspension)
        Me.Controls.Add(Me.txtNumeroCredito)
        Me.Controls.Add(Me.Label15)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSuspenderCreditoInfonavit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Suspender Crédito Infonavit"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtpFechaSuspension, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbTipoInfonavitNombre As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents cmbTipoInfonavitCodigo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblNombres As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnGuardar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtNumeroCredito As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Private WithEvents dtpFechaSuspension As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
