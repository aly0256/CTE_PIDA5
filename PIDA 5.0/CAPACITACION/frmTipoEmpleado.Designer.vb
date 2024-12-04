<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTipoEmpleado
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
        Me.btnSemanal = New DevComponents.DotNetBar.ButtonX()
        Me.btnCatorcenal = New DevComponents.DotNetBar.ButtonX()
        Me.SuspendLayout()
        '
        'btnSemanal
        '
        Me.btnSemanal.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSemanal.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSemanal.Location = New System.Drawing.Point(30, 12)
        Me.btnSemanal.Name = "btnSemanal"
        Me.btnSemanal.Size = New System.Drawing.Size(133, 43)
        Me.btnSemanal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSemanal.TabIndex = 0
        Me.btnSemanal.Text = "Semanal"
        '
        'btnCatorcenal
        '
        Me.btnCatorcenal.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCatorcenal.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCatorcenal.Location = New System.Drawing.Point(196, 12)
        Me.btnCatorcenal.Name = "btnCatorcenal"
        Me.btnCatorcenal.Size = New System.Drawing.Size(133, 43)
        Me.btnCatorcenal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCatorcenal.TabIndex = 1
        Me.btnCatorcenal.Text = "Catorcenal"
        '
        'frmTipoEmpleado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 69)
        Me.Controls.Add(Me.btnCatorcenal)
        Me.Controls.Add(Me.btnSemanal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTipoEmpleado"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Periodo"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSemanal As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCatorcenal As DevComponents.DotNetBar.ButtonX
End Class
