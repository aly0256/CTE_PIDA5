<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpcionesHrsExtras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOpcionesHrsExtras))
        Me.cmbPlanta = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnAceptAsignar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelarAsignar = New DevComponents.DotNetBar.ButtonX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbPlanta
        '
        Me.cmbPlanta.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPlanta.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPlanta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPlanta.ButtonDropDown.Visible = True
        Me.cmbPlanta.ColumnsVisible = False
        Me.cmbPlanta.DisplayMembers = "Código"
        Me.cmbPlanta.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPlanta.Location = New System.Drawing.Point(60, 15)
        Me.cmbPlanta.Name = "cmbPlanta"
        Me.cmbPlanta.Size = New System.Drawing.Size(168, 23)
        Me.cmbPlanta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPlanta.TabIndex = 162
        Me.cmbPlanta.ValueMember = "Código"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btnAceptAsignar)
        Me.GroupBox2.Controls.Add(Me.btnCancelarAsignar)
        Me.GroupBox2.Location = New System.Drawing.Point(28, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(174, 47)
        Me.GroupBox2.TabIndex = 160
        Me.GroupBox2.TabStop = False
        '
        'btnAceptAsignar
        '
        Me.btnAceptAsignar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptAsignar.CausesValidation = False
        Me.btnAceptAsignar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptAsignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptAsignar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptAsignar.Location = New System.Drawing.Point(6, 14)
        Me.btnAceptAsignar.Name = "btnAceptAsignar"
        Me.btnAceptAsignar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptAsignar.TabIndex = 11
        Me.btnAceptAsignar.Text = "Aceptar"
        '
        'btnCancelarAsignar
        '
        Me.btnCancelarAsignar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelarAsignar.CausesValidation = False
        Me.btnCancelarAsignar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelarAsignar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelarAsignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarAsignar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelarAsignar.Location = New System.Drawing.Point(88, 14)
        Me.btnCancelarAsignar.Name = "btnCancelarAsignar"
        Me.btnCancelarAsignar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelarAsignar.TabIndex = 12
        Me.btnCancelarAsignar.Text = "Cancelar"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(53, 17)
        Me.Label4.TabIndex = 161
        Me.Label4.Text = "Planta"
        '
        'frmOpcionesHrsExtras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(244, 107)
        Me.Controls.Add(Me.cmbPlanta)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOpcionesHrsExtras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Opciones"
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbPlanta As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptAsignar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelarAsignar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
