<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVistaPrevia
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVistaPrevia))
        Me.dbImagen = New System.Windows.Forms.OpenFileDialog()
        Me.vwrReportes = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'dbImagen
        '
        Me.dbImagen.FileName = "OpenFileDialog1"
        Me.dbImagen.Filter = "JPEG files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif|All files (*.*)|*.*"
        '
        'vwrReportes
        '
        Me.vwrReportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vwrReportes.Location = New System.Drawing.Point(0, 0)
        Me.vwrReportes.Name = "vwrReportes"
        Me.vwrReportes.Size = New System.Drawing.Size(789, 438)
        Me.vwrReportes.TabIndex = 0
        '
        'frmVistaPrevia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 438)
        Me.Controls.Add(Me.vwrReportes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVistaPrevia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dbImagen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents vwrReportes As Microsoft.Reporting.WinForms.ReportViewer
End Class
