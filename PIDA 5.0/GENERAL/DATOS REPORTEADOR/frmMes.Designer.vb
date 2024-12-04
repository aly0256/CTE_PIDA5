<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMes
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
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.MesesBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbAño = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtFechaDoc = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.dtFechaDepo = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.MesesBox1.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaDoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtFechaDepo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(37, 2)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(227, 40)
        Me.ReflectionLabel1.TabIndex = 110
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>AÑO FISCAL...</b></font>"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(212, 159)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(81, 23)
        Me.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancelar.TabIndex = 109
        Me.btnCancelar.Text = "&Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Location = New System.Drawing.Point(125, 159)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(81, 23)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 108
        Me.btnAceptar.Text = "&Aceptar"
        '
        'MesesBox1
        '
        Me.MesesBox1.Controls.Add(Me.dtFechaDoc)
        Me.MesesBox1.Controls.Add(Me.dtFechaDepo)
        Me.MesesBox1.Controls.Add(Me.Label3)
        Me.MesesBox1.Controls.Add(Me.cmbAño)
        Me.MesesBox1.Controls.Add(Me.Label1)
        Me.MesesBox1.Controls.Add(Me.Label2)
        Me.MesesBox1.Location = New System.Drawing.Point(17, 37)
        Me.MesesBox1.Name = "MesesBox1"
        Me.MesesBox1.Size = New System.Drawing.Size(234, 116)
        Me.MesesBox1.TabIndex = 107
        Me.MesesBox1.TabStop = False
        '
        'cmbAño
        '
        Me.cmbAño.DisplayMember = "NUM_AÑO"
        Me.cmbAño.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAño.ItemHeight = 14
        Me.cmbAño.Location = New System.Drawing.Point(109, 19)
        Me.cmbAño.Name = "cmbAño"
        Me.cmbAño.Size = New System.Drawing.Size(82, 20)
        Me.cmbAño.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbAño.TabIndex = 6
        Me.cmbAño.ValueMember = "NUM_AÑO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Año Fiscal"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha Documento"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.Set22
        Me.picImagen.Location = New System.Drawing.Point(3, 2)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(34, 34)
        Me.picImagen.TabIndex = 111
        Me.picImagen.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Fecha Depósito"
        '
        'dtFechaDoc
        '
        '
        '
        '
        Me.dtFechaDoc.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtFechaDoc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaDoc.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtFechaDoc.ButtonDropDown.Visible = True
        Me.dtFechaDoc.IsPopupCalendarOpen = False
        Me.dtFechaDoc.Location = New System.Drawing.Point(109, 50)
        '
        '
        '
        Me.dtFechaDoc.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtFechaDoc.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaDoc.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtFechaDoc.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtFechaDoc.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtFechaDoc.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtFechaDoc.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtFechaDoc.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtFechaDoc.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtFechaDoc.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtFechaDoc.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaDoc.MonthCalendar.DisplayMonth = New Date(2015, 5, 1, 0, 0, 0, 0)
        Me.dtFechaDoc.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtFechaDoc.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtFechaDoc.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtFechaDoc.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtFechaDoc.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtFechaDoc.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaDoc.MonthCalendar.TodayButtonVisible = True
        Me.dtFechaDoc.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtFechaDoc.Name = "dtFechaDoc"
        Me.dtFechaDoc.Size = New System.Drawing.Size(102, 20)
        Me.dtFechaDoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtFechaDoc.TabIndex = 8
        '
        'dtFechaDepo
        '
        '
        '
        '
        Me.dtFechaDepo.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtFechaDepo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaDepo.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtFechaDepo.ButtonDropDown.Visible = True
        Me.dtFechaDepo.IsPopupCalendarOpen = False
        Me.dtFechaDepo.Location = New System.Drawing.Point(109, 79)
        '
        '
        '
        Me.dtFechaDepo.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtFechaDepo.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaDepo.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtFechaDepo.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtFechaDepo.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtFechaDepo.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtFechaDepo.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtFechaDepo.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtFechaDepo.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtFechaDepo.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtFechaDepo.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaDepo.MonthCalendar.DisplayMonth = New Date(2015, 5, 1, 0, 0, 0, 0)
        Me.dtFechaDepo.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtFechaDepo.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtFechaDepo.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtFechaDepo.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtFechaDepo.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtFechaDepo.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaDepo.MonthCalendar.TodayButtonVisible = True
        Me.dtFechaDepo.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtFechaDepo.Name = "dtFechaDepo"
        Me.dtFechaDepo.Size = New System.Drawing.Size(102, 20)
        Me.dtFechaDepo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtFechaDepo.TabIndex = 9
        '
        'frmMes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 193)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.picImagen)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.MesesBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Selecciona un Año Fiscal"
        Me.MesesBox1.ResumeLayout(False)
        Me.MesesBox1.PerformLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaDoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtFechaDepo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents MesesBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbAño As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtFechaDoc As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents dtFechaDepo As DevComponents.Editors.DateTimeAdv.DateTimeInput
End Class
