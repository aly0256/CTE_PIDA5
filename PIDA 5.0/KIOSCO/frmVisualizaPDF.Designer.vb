<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisualizaPDF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVisualizaPDF))
        Me.AxAcroPDF1 = New AxAcroPDFLib.AxAcroPDF()
        Me.btnSi = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'AxAcroPDF1
        '
        Me.AxAcroPDF1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxAcroPDF1.Enabled = True
        Me.AxAcroPDF1.Location = New System.Drawing.Point(0, 0)
        Me.AxAcroPDF1.Name = "AxAcroPDF1"
        Me.AxAcroPDF1.OcxState = CType(resources.GetObject("AxAcroPDF1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF1.Size = New System.Drawing.Size(748, 727)
        Me.AxAcroPDF1.TabIndex = 0
        '
        'btnSi
        '
        Me.btnSi.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSi.BackColor = System.Drawing.Color.Orange
        Me.btnSi.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.btnSi.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.btnSi.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold)
        Me.btnSi.ImageFixedSize = New System.Drawing.Size(30, 30)
        Me.btnSi.ImageTextSpacing = 7
        Me.btnSi.Location = New System.Drawing.Point(0, 0)
        Me.btnSi.Name = "btnSi"
        Me.btnSi.Size = New System.Drawing.Size(745, 47)
        Me.btnSi.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013
        Me.btnSi.TabIndex = 33
        Me.btnSi.Text = "Cerrar"
        Me.btnSi.TextColor = System.Drawing.Color.White
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.AxAcroPDF1)
        Me.Panel1.Location = New System.Drawing.Point(0, 47)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(748, 727)
        Me.Panel1.TabIndex = 35
        '
        'frmVisualizaPDF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(750, 777)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSi)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmVisualizaPDF"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmVisualizaPDF"
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AxAcroPDF1 As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents btnSi As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
