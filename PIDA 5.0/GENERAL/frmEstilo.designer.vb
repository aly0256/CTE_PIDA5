<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstilo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEstilo))
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.clrEstilo = New DevComponents.DotNetBar.ColorPickerButton()
        Me.cmbEstilo = New System.Windows.Forms.ComboBox()
        Me.btnSalir = New DevComponents.DotNetBar.ButtonX()
        Me.btnAplicar = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrevia = New DevComponents.DotNetBar.ButtonX()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel1.Controls.Add(Me.Label2)
        Me.GroupPanel1.Controls.Add(Me.Label1)
        Me.GroupPanel1.Controls.Add(Me.clrEstilo)
        Me.GroupPanel1.Controls.Add(Me.cmbEstilo)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(9, 11)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(274, 97)
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
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 169
        Me.GroupPanel1.Text = "Apariencia"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Location = New System.Drawing.Point(6, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 165
        Me.Label2.Text = "Tinte de color"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Location = New System.Drawing.Point(6, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 164
        Me.Label1.Text = "Estilo"
        '
        'clrEstilo
        '
        Me.clrEstilo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.clrEstilo.AutoExpandOnClick = True
        Me.clrEstilo.AutoSize = True
        Me.clrEstilo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.clrEstilo.Image = CType(resources.GetObject("clrEstilo.Image"), System.Drawing.Image)
        Me.clrEstilo.Location = New System.Drawing.Point(84, 40)
        Me.clrEstilo.Name = "clrEstilo"
        Me.clrEstilo.SelectedColorImageRectangle = New System.Drawing.Rectangle(2, 2, 12, 12)
        Me.clrEstilo.Size = New System.Drawing.Size(42, 26)
        Me.clrEstilo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.clrEstilo.TabIndex = 157
        '
        'cmbEstilo
        '
        Me.cmbEstilo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstilo.FormattingEnabled = True
        Me.cmbEstilo.Location = New System.Drawing.Point(55, 9)
        Me.cmbEstilo.Name = "cmbEstilo"
        Me.cmbEstilo.Size = New System.Drawing.Size(206, 21)
        Me.cmbEstilo.TabIndex = 158
        '
        'btnSalir
        '
        Me.btnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSalir.CausesValidation = False
        Me.btnSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnSalir.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnSalir.Location = New System.Drawing.Point(197, 117)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(78, 25)
        Me.btnSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSalir.TabIndex = 168
        Me.btnSalir.Text = "&Cancelar"
        '
        'btnAplicar
        '
        Me.btnAplicar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAplicar.CausesValidation = False
        Me.btnAplicar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAplicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAplicar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnAplicar.Location = New System.Drawing.Point(110, 117)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(78, 25)
        Me.btnAplicar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAplicar.TabIndex = 167
        Me.btnAplicar.Text = "&Aceptar"
        '
        'btnPrevia
        '
        Me.btnPrevia.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrevia.CausesValidation = False
        Me.btnPrevia.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrevia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrevia.Image = Global.PIDA.My.Resources.Resources.Find16
        Me.btnPrevia.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnPrevia.Location = New System.Drawing.Point(11, 117)
        Me.btnPrevia.Name = "btnPrevia"
        Me.btnPrevia.Size = New System.Drawing.Size(92, 25)
        Me.btnPrevia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrevia.TabIndex = 170
        Me.btnPrevia.Text = "&Vista previa"
        '
        'frmConfiguracion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 153)
        Me.Controls.Add(Me.btnPrevia)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnAplicar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConfiguracion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración de estilo"
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPrevia As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents clrEstilo As DevComponents.DotNetBar.ColorPickerButton
    Friend WithEvents cmbEstilo As System.Windows.Forms.ComboBox
    Friend WithEvents btnSalir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAplicar As DevComponents.DotNetBar.ButtonX
End Class
