<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeleccionaPlanta
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
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkWME = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkWSM = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Location = New System.Drawing.Point(74, 77)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(122, 23)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 2
        Me.ButtonX1.Text = "Aceptar"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.chkWSM)
        Me.GroupBox1.Controls.Add(Me.chkWME)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(242, 59)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'chkWME
        '
        '
        '
        '
        Me.chkWME.BackgroundStyle.BackColor = System.Drawing.Color.Transparent
        Me.chkWME.BackgroundStyle.BackColor2 = System.Drawing.Color.Transparent
        Me.chkWME.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkWME.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.chkWME.CheckValue = "0"
        Me.chkWME.CheckValueChecked = "1"
        Me.chkWME.CheckValueUnchecked = "0"
        Me.chkWME.Location = New System.Drawing.Point(16, 21)
        Me.chkWME.Name = "chkWME"
        Me.chkWME.Size = New System.Drawing.Size(106, 23)
        Me.chkWME.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkWME.TabIndex = 0
        Me.chkWME.TextColor = System.Drawing.Color.Black
        '
        'chkWSM
        '
        '
        '
        '
        Me.chkWSM.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkWSM.CheckSignSize = New System.Drawing.Size(17, 17)
        Me.chkWSM.CheckValue = "0"
        Me.chkWSM.CheckValueChecked = "2"
        Me.chkWSM.CheckValueUnchecked = "0"
        Me.chkWSM.Location = New System.Drawing.Point(137, 21)
        Me.chkWSM.Name = "chkWSM"
        Me.chkWSM.Size = New System.Drawing.Size(99, 23)
        Me.chkWSM.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkWSM.TabIndex = 1
        Me.chkWSM.TextColor = System.Drawing.Color.Black
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Wollsdorf México"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(156, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Wollsdorf Sales"
        '
        'frmSeleccionaPlanta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(266, 112)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ButtonX1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSeleccionaPlanta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccionar planta"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkWSM As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkWME As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
