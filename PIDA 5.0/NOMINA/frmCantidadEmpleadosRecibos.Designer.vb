<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCantidadEmpleadosRecibos
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.swEmpleados = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.pbCargarRecibos = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.lblBarra = New DevComponents.DotNetBar.LabelX()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(59, 7)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(283, 45)
        Me.ReflectionLabel1.TabIndex = 85
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>OPCIONES RECIBOS EMPLEADOS</b></font>"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Empleados32
        Me.PictureBox1.Location = New System.Drawing.Point(15, 11)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(37, 33)
        Me.PictureBox1.TabIndex = 86
        Me.PictureBox1.TabStop = False
        '
        'swEmpleados
        '
        '
        '
        '
        Me.swEmpleados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swEmpleados.Location = New System.Drawing.Point(21, 127)
        Me.swEmpleados.Name = "swEmpleados"
        Me.swEmpleados.OffText = "Todos"
        Me.swEmpleados.OnText = "Uno"
        Me.swEmpleados.Size = New System.Drawing.Size(102, 30)
        Me.swEmpleados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swEmpleados.TabIndex = 87
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Location = New System.Drawing.Point(223, 127)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(102, 30)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 88
        Me.btnAceptar.Text = "Aceptar"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(12, 51)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(323, 56)
        Me.LabelX1.TabIndex = 89
        Me.LabelX1.Text = "Seleccione si desea consultar los recibos de todos los " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "empleados o uno en espec" & _
    "ífico." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Si elige la opción ""Todos"", la carga podría durar unos momentos."
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'pbCargarRecibos
        '
        '
        '
        '
        Me.pbCargarRecibos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pbCargarRecibos.Location = New System.Drawing.Point(21, 188)
        Me.pbCargarRecibos.Name = "pbCargarRecibos"
        Me.pbCargarRecibos.Size = New System.Drawing.Size(304, 23)
        Me.pbCargarRecibos.TabIndex = 90
        Me.pbCargarRecibos.Text = "ProgressBarX1"
        '
        'lblBarra
        '
        '
        '
        '
        Me.lblBarra.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblBarra.Location = New System.Drawing.Point(73, 164)
        Me.lblBarra.Name = "lblBarra"
        Me.lblBarra.Size = New System.Drawing.Size(203, 23)
        Me.lblBarra.TabIndex = 91
        Me.lblBarra.Text = "Carga"
        Me.lblBarra.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'frmCantidadEmpleadosRecibos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(347, 227)
        Me.Controls.Add(Me.lblBarra)
        Me.Controls.Add(Me.pbCargarRecibos)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.swEmpleados)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCantidadEmpleadosRecibos"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccione opción"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents swEmpleados As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents pbCargarRecibos As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents lblBarra As DevComponents.DotNetBar.LabelX
End Class
