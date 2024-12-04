<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSolVacKioscoMotivo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSolVacKioscoMotivo))
        Me.txtMotivo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnCancela = New DevComponents.DotNetBar.ButtonX()
        Me.btnConfirmar = New DevComponents.DotNetBar.ButtonX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtMotivo
        '
        Me.txtMotivo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        '
        '
        '
        Me.txtMotivo.Border.Class = "TextBoxBorder"
        Me.txtMotivo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMotivo.Location = New System.Drawing.Point(11, 52)
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.PreventEnterBeep = True
        Me.txtMotivo.Size = New System.Drawing.Size(303, 78)
        Me.txtMotivo.TabIndex = 0
        '
        'btnCancela
        '
        Me.btnCancela.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancela.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancela.CausesValidation = False
        Me.btnCancela.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancela.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancela.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancela.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCancela.Location = New System.Drawing.Point(128, 144)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(88, 26)
        Me.btnCancela.TabIndex = 6
        Me.btnCancela.Text = "Cancelar"
        '
        'btnConfirmar
        '
        Me.btnConfirmar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnConfirmar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnConfirmar.CausesValidation = False
        Me.btnConfirmar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnConfirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnConfirmar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnConfirmar.Location = New System.Drawing.Point(227, 144)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(88, 26)
        Me.btnConfirmar.TabIndex = 5
        Me.btnConfirmar.Text = "Aceptar"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(330, 37)
        Me.Label5.TabIndex = 231
        Me.Label5.Text = "Por favor, ingrese el motivo de la cancelación de la " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "solicitud de vacaciones"
        '
        'frmSolVacKioscoMotivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(326, 182)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.btnConfirmar)
        Me.Controls.Add(Me.txtMotivo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSolVacKioscoMotivo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Motivo de no aprobación"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtMotivo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnCancela As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnConfirmar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
