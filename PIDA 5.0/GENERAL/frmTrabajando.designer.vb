<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTrabajando
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTrabajando))
        Me.Avance = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.lblAvance = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Avance
        '
        '
        '
        '
        Me.Avance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Avance.FocusCuesEnabled = False
        Me.Avance.Location = New System.Drawing.Point(3, 2)
        Me.Avance.Name = "Avance"
        Me.Avance.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Spoke
        Me.Avance.ProgressText = "12345"
        Me.Avance.Size = New System.Drawing.Size(229, 230)
        Me.Avance.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.Avance.TabIndex = 0
        Me.Avance.UseWaitCursor = True
        '
        'lblAvance
        '
        Me.lblAvance.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblAvance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAvance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvance.ForeColor = System.Drawing.SystemColors.Window
        Me.lblAvance.Location = New System.Drawing.Point(36, 101)
        Me.lblAvance.Name = "lblAvance"
        Me.lblAvance.Size = New System.Drawing.Size(163, 33)
        Me.lblAvance.TabIndex = 1
        Me.lblAvance.Text = "Preparando datos..."
        Me.lblAvance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmTrabajando
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(234, 234)
        Me.Controls.Add(Me.lblAvance)
        Me.Controls.Add(Me.Avance)
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTrabajando"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Avance As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents lblAvance As System.Windows.Forms.Label
End Class
