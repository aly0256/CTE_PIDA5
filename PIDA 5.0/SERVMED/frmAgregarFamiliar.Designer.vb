<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregarFamiliar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAgregarFamiliar))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.cmbFamiliares = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.dtFechaNac = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        CType(Me.dtFechaNac, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(45, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(141, 40)
        Me.ReflectionLabel1.TabIndex = 100
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>FAMILIARES</b></font>"
        '
        'cmbFamiliares
        '
        Me.cmbFamiliares.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbFamiliares.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbFamiliares.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbFamiliares.ButtonDropDown.Visible = True
        Me.cmbFamiliares.DisplayMembers = "cod_familia,nombre"
        Me.cmbFamiliares.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbFamiliares.Location = New System.Drawing.Point(140, 118)
        Me.cmbFamiliares.Name = "cmbFamiliares"
        Me.cmbFamiliares.Size = New System.Drawing.Size(253, 23)
        Me.cmbFamiliares.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbFamiliares.TabIndex = 97
        '
        'dtFechaNac
        '
        '
        '
        '
        Me.dtFechaNac.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtFechaNac.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaNac.ButtonClear.Visible = True
        Me.dtFechaNac.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtFechaNac.ButtonDropDown.Visible = True
        Me.dtFechaNac.IsPopupCalendarOpen = False
        Me.dtFechaNac.Location = New System.Drawing.Point(140, 160)
        '
        '
        '
        Me.dtFechaNac.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtFechaNac.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaNac.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtFechaNac.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtFechaNac.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtFechaNac.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtFechaNac.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtFechaNac.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtFechaNac.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtFechaNac.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtFechaNac.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaNac.MonthCalendar.DisplayMonth = New Date(2015, 5, 1, 0, 0, 0, 0)
        Me.dtFechaNac.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtFechaNac.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtFechaNac.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtFechaNac.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtFechaNac.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtFechaNac.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtFechaNac.MonthCalendar.TodayButtonVisible = True
        Me.dtFechaNac.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtFechaNac.Name = "dtFechaNac"
        Me.dtFechaNac.Size = New System.Drawing.Size(113, 20)
        Me.dtFechaNac.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtFechaNac.TabIndex = 96
        '
        'txtNombre
        '
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Location = New System.Drawing.Point(140, 78)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(253, 20)
        Me.txtNombre.TabIndex = 95
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 160)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 15)
        Me.Label3.TabIndex = 94
        Me.Label3.Text = "Fecha de nacimiento"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 15)
        Me.Label2.TabIndex = 93
        Me.Label2.Text = "Parentesco"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 15)
        Me.Label1.TabIndex = 92
        Me.Label1.Text = "Nombre de familiar"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Family24
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(27, 26)
        Me.PictureBox1.TabIndex = 101
        Me.PictureBox1.TabStop = False
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.Location = New System.Drawing.Point(236, 246)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 23)
        Me.btnAceptar.TabIndex = 98
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
        Me.btnCancelar.Location = New System.Drawing.Point(318, 246)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 99
        Me.btnCancelar.Text = "Cancelar"
        '
        'frmAgregarFamiliar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 281)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.cmbFamiliares)
        Me.Controls.Add(Me.dtFechaNac)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAgregarFamiliar"
        Me.Text = "Agregar Familiares"
        CType(Me.dtFechaNac, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmbFamiliares As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents dtFechaNac As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
