<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsentarNom_esp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsentarNom_esp))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.lblAnioPer = New DevComponents.DotNetBar.LabelX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAsentarNom = New DevComponents.DotNetBar.ButtonX()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(95, 16)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(287, 40)
        Me.ReflectionLabel1.TabIndex = 256
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>ASENTAR NÓMINA ESPECIAL</b></font>"
        '
        'lblAnioPer
        '
        '
        '
        '
        Me.lblAnioPer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblAnioPer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnioPer.Location = New System.Drawing.Point(86, 61)
        Me.lblAnioPer.Name = "lblAnioPer"
        Me.lblAnioPer.SingleLineColor = System.Drawing.SystemColors.Control
        Me.lblAnioPer.Size = New System.Drawing.Size(350, 20)
        Me.lblAnioPer.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.lblAnioPer.TabIndex = 262
        Me.lblAnioPer.Text = "2020 - 29 del 13/07 al 19/07"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(20, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 261
        Me.Label1.Text = "Periodo"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(355, 99)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(81, 40)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 264
        Me.btnCerrar.Text = "Salir"
        '
        'btnAsentarNom
        '
        Me.btnAsentarNom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAsentarNom.CausesValidation = False
        Me.btnAsentarNom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAsentarNom.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnAsentarNom.Image = Global.PIDA.My.Resources.Resources.Candado48
        Me.btnAsentarNom.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnAsentarNom.Location = New System.Drawing.Point(258, 99)
        Me.btnAsentarNom.Name = "btnAsentarNom"
        Me.btnAsentarNom.Size = New System.Drawing.Size(83, 40)
        Me.btnAsentarNom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAsentarNom.TabIndex = 263
        Me.btnAsentarNom.Text = "Asentar"
        '
        'frmAsentarNom_esp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(457, 144)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAsentarNom)
        Me.Controls.Add(Me.lblAnioPer)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAsentarNom_esp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asentar nómina especial"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents lblAnioPer As DevComponents.DotNetBar.LabelX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAsentarNom As DevComponents.DotNetBar.ButtonX
End Class
