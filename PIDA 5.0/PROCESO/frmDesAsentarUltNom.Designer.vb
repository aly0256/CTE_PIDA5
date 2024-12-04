<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDesAsentarUltNom
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDesAsentarUltNom))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.lblUltNomProc = New DevComponents.DotNetBar.LabelX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnDesAsentarNom = New DevComponents.DotNetBar.ButtonX()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(11, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(486, 49)
        Me.ReflectionLabel1.TabIndex = 256
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>DESASENTAR ULTIMA NÓMINA PROCESADA</b></font>"
        '
        'lblUltNomProc
        '
        '
        '
        '
        Me.lblUltNomProc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblUltNomProc.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUltNomProc.Location = New System.Drawing.Point(17, 61)
        Me.lblUltNomProc.Name = "lblUltNomProc"
        Me.lblUltNomProc.SingleLineColor = System.Drawing.SystemColors.Control
        Me.lblUltNomProc.Size = New System.Drawing.Size(466, 20)
        Me.lblUltNomProc.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.lblUltNomProc.TabIndex = 263
        Me.lblUltNomProc.Text = "Ultima(s) nómina(s) procesada(s):"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(367, 184)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(116, 28)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 262
        Me.btnCerrar.Text = "Salir"
        '
        'btnDesAsentarNom
        '
        Me.btnDesAsentarNom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDesAsentarNom.CausesValidation = False
        Me.btnDesAsentarNom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnDesAsentarNom.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnDesAsentarNom.Image = Global.PIDA.My.Resources.Resources.CandadoAbierto48
        Me.btnDesAsentarNom.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnDesAsentarNom.Location = New System.Drawing.Point(142, 97)
        Me.btnDesAsentarNom.Name = "btnDesAsentarNom"
        Me.btnDesAsentarNom.Size = New System.Drawing.Size(206, 78)
        Me.btnDesAsentarNom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnDesAsentarNom.TabIndex = 261
        Me.btnDesAsentarNom.Text = "Desasentar"
        '
        'frmDesAsentarUltNom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(495, 222)
        Me.Controls.Add(Me.lblUltNomProc)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnDesAsentarNom)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDesAsentarUltNom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Desasentar Nom"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents lblUltNomProc As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnDesAsentarNom As DevComponents.DotNetBar.ButtonX
End Class
