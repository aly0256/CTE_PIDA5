<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmZoom
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmZoom))
        Me.mnuImagen = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopiarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarComoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.CancelarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.sveDialog = New System.Windows.Forms.SaveFileDialog()
        Me.mnuImagen.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuImagen
        '
        Me.mnuImagen.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopiarToolStripMenuItem, Me.GuardarComoToolStripMenuItem, Me.ToolStripMenuItem1, Me.CancelarToolStripMenuItem})
        Me.mnuImagen.Name = "mnuImagen"
        Me.mnuImagen.Size = New System.Drawing.Size(160, 76)
        '
        'CopiarToolStripMenuItem
        '
        Me.CopiarToolStripMenuItem.Image = Global.PIDA.My.Resources.Resources.copy_16
        Me.CopiarToolStripMenuItem.Name = "CopiarToolStripMenuItem"
        Me.CopiarToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.CopiarToolStripMenuItem.Text = "Copiar"
        '
        'GuardarComoToolStripMenuItem
        '
        Me.GuardarComoToolStripMenuItem.Image = Global.PIDA.My.Resources.Resources.Save_as16
        Me.GuardarComoToolStripMenuItem.Name = "GuardarComoToolStripMenuItem"
        Me.GuardarComoToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.GuardarComoToolStripMenuItem.Text = "Guardar como..."
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(156, 6)
        '
        'CancelarToolStripMenuItem
        '
        Me.CancelarToolStripMenuItem.Name = "CancelarToolStripMenuItem"
        Me.CancelarToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.CancelarToolStripMenuItem.Text = "Cancelar"
        '
        'picImagen
        '
        Me.picImagen.BackColor = System.Drawing.Color.Black
        Me.picImagen.ContextMenuStrip = Me.mnuImagen
        Me.picImagen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picImagen.Location = New System.Drawing.Point(0, 0)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(467, 518)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picImagen.TabIndex = 0
        Me.picImagen.TabStop = False
        '
        'frmZoom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(467, 518)
        Me.Controls.Add(Me.picImagen)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmZoom"
        Me.Text = "frmZoom"
        Me.mnuImagen.ResumeLayout(False)
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents mnuImagen As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopiarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarComoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CancelarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents sveDialog As System.Windows.Forms.SaveFileDialog
End Class
