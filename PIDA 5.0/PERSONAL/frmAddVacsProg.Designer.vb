<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddVacsProg
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddVacsProg))
        Me.btnAgregarEmpleado = New DevComponents.DotNetBar.ButtonX()
        Me.txtBuscaEmpleado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.txtDias = New DevComponents.Editors.DoubleInput()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFechaDe = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.txtNotas = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaDe, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAgregarEmpleado
        '
        Me.btnAgregarEmpleado.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAgregarEmpleado.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAgregarEmpleado.Location = New System.Drawing.Point(413, 76)
        Me.btnAgregarEmpleado.Name = "btnAgregarEmpleado"
        Me.btnAgregarEmpleado.Size = New System.Drawing.Size(46, 20)
        Me.btnAgregarEmpleado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAgregarEmpleado.TabIndex = 259
        Me.btnAgregarEmpleado.Text = "..."
        Me.btnAgregarEmpleado.Tooltip = "Buscar empleado"
        '
        'txtBuscaEmpleado
        '
        '
        '
        '
        Me.txtBuscaEmpleado.Border.Class = "TextBoxBorder"
        Me.txtBuscaEmpleado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBuscaEmpleado.Enabled = False
        Me.txtBuscaEmpleado.Location = New System.Drawing.Point(106, 76)
        Me.txtBuscaEmpleado.Name = "txtBuscaEmpleado"
        Me.txtBuscaEmpleado.PreventEnterBeep = True
        Me.txtBuscaEmpleado.Size = New System.Drawing.Size(292, 20)
        Me.txtBuscaEmpleado.TabIndex = 258
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 15)
        Me.Label3.TabIndex = 257
        Me.Label3.Text = "Empleado"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightGray
        Me.Panel1.Controls.Add(Me.picImagen)
        Me.Panel1.Controls.Add(Me.ReflectionLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(467, 62)
        Me.Panel1.TabIndex = 260
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.AddList32
        Me.picImagen.Location = New System.Drawing.Point(4, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(41, 40)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picImagen.TabIndex = 115
        Me.picImagen.TabStop = False
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(54, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(248, 40)
        Me.ReflectionLabel1.TabIndex = 114
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>AGREGAR VACACIÓN" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "</b></font>"
        '
        'txtDias
        '
        '
        '
        '
        Me.txtDias.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtDias.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDias.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtDias.Increment = 1.0R
        Me.txtDias.Location = New System.Drawing.Point(106, 114)
        Me.txtDias.Name = "txtDias"
        Me.txtDias.ShowUpDown = True
        Me.txtDias.Size = New System.Drawing.Size(129, 20)
        Me.txtDias.TabIndex = 263
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 15)
        Me.Label1.TabIndex = 264
        Me.Label1.Text = "Días a tomar:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 154)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 15)
        Me.Label2.TabIndex = 265
        Me.Label2.Text = "A partir del día:"
        '
        'txtFechaDe
        '
        '
        '
        '
        Me.txtFechaDe.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaDe.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaDe.ButtonDropDown.Visible = True
        Me.txtFechaDe.DisabledForeColor = System.Drawing.Color.Black
        Me.txtFechaDe.FocusHighlightEnabled = True
        Me.txtFechaDe.IsPopupCalendarOpen = False
        Me.txtFechaDe.Location = New System.Drawing.Point(106, 149)
        '
        '
        '
        Me.txtFechaDe.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaDe.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.txtFechaDe.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaDe.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtFechaDe.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaDe.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaDe.MonthCalendar.DisplayMonth = New Date(2007, 10, 1, 0, 0, 0, 0)
        Me.txtFechaDe.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaDe.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaDe.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaDe.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaDe.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaDe.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaDe.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaDe.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFechaDe.Name = "txtFechaDe"
        Me.txtFechaDe.Size = New System.Drawing.Size(209, 20)
        Me.txtFechaDe.TabIndex = 266
        Me.txtFechaDe.Value = New Date(2007, 7, 7, 0, 0, 0, 0)
        '
        'txtNotas
        '
        Me.txtNotas.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtNotas.Border.Class = "TextBoxBorder"
        Me.txtNotas.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNotas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotas.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNotas.Location = New System.Drawing.Point(106, 187)
        Me.txtNotas.MaxLength = 1000
        Me.txtNotas.Multiline = True
        Me.txtNotas.Name = "txtNotas"
        Me.txtNotas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotas.Size = New System.Drawing.Size(292, 51)
        Me.txtNotas.TabIndex = 267
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 189)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 15)
        Me.Label4.TabIndex = 268
        Me.Label4.Text = "Notas:"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.Cancel16
        Me.btnCancelar.Location = New System.Drawing.Point(379, 256)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 270
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.Location = New System.Drawing.Point(295, 256)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.TabIndex = 269
        Me.btnAceptar.Text = "Aceptar"
        '
        'frmAddVacsProg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(467, 289)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtNotas)
        Me.Controls.Add(Me.txtFechaDe)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDias)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnAgregarEmpleado)
        Me.Controls.Add(Me.txtBuscaEmpleado)
        Me.Controls.Add(Me.Label3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAddVacsProg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar vacación programada"
        Me.Panel1.ResumeLayout(False)
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaDe, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAgregarEmpleado As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtBuscaEmpleado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents txtDias As DevComponents.Editors.DoubleInput
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents txtFechaDe As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtNotas As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
End Class
