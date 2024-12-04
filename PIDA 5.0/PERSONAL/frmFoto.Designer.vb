<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFoto
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
        Me.picFoto = New System.Windows.Forms.PictureBox()
        Me.mnuImagen = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CopiarImagenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarImagenComoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dlgGuardarFoto = New System.Windows.Forms.SaveFileDialog()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuImagen.SuspendLayout()
        Me.SuspendLayout()
        '
        'picFoto
        '
        Me.picFoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picFoto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picFoto.Image = Global.PIDA.My.Resources.Resources.NoFoto
        Me.picFoto.Location = New System.Drawing.Point(0, 0)
        Me.picFoto.Name = "picFoto"
        Me.picFoto.Size = New System.Drawing.Size(230, 281)
        Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picFoto.TabIndex = 0
        Me.picFoto.TabStop = False
        '
        'mnuImagen
        '
        Me.mnuImagen.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopiarImagenToolStripMenuItem, Me.GuardarImagenComoToolStripMenuItem})
        Me.mnuImagen.Name = "mnuImagen"
        Me.mnuImagen.Size = New System.Drawing.Size(203, 48)
        '
        'CopiarImagenToolStripMenuItem
        '
        Me.CopiarImagenToolStripMenuItem.Image = Global.PIDA.My.Resources.Resources.copy_16
        Me.CopiarImagenToolStripMenuItem.Name = "CopiarImagenToolStripMenuItem"
        Me.CopiarImagenToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.CopiarImagenToolStripMenuItem.Text = "Copiar imagen"
        '
        'GuardarImagenComoToolStripMenuItem
        '
        Me.GuardarImagenComoToolStripMenuItem.Image = Global.PIDA.My.Resources.Resources.Save16
        Me.GuardarImagenComoToolStripMenuItem.Name = "GuardarImagenComoToolStripMenuItem"
        Me.GuardarImagenComoToolStripMenuItem.Size = New System.Drawing.Size(202, 22)
        Me.GuardarImagenComoToolStripMenuItem.Text = "Guardar imagen como..."
        '
        'frmFoto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(230, 281)
        Me.Controls.Add(Me.picFoto)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Location = New System.Drawing.Point(914, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFoto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Foto"
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuImagen.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picFoto As System.Windows.Forms.PictureBox
    Friend WithEvents mnuImagen As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CopiarImagenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarImagenComoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dlgGuardarFoto As System.Windows.Forms.SaveFileDialog
End Class
