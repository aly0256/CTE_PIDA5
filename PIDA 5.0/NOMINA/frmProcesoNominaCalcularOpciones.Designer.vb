<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcesoNominaCalcularOpciones
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.sbtnAjusteSub = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.sbtnSuaPaid = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.sbtnCalcAgui = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnAcept = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.sbtnAjusteSub)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.sbtnSuaPaid)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.sbtnCalcAgui)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(342, 124)
        Me.GroupBox3.TabIndex = 287
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Opciones"
        '
        'sbtnAjusteSub
        '
        '
        '
        '
        Me.sbtnAjusteSub.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sbtnAjusteSub.Location = New System.Drawing.Point(261, 79)
        Me.sbtnAjusteSub.Name = "sbtnAjusteSub"
        Me.sbtnAjusteSub.OffBackColor = System.Drawing.Color.LightCoral
        Me.sbtnAjusteSub.OffText = "NO"
        Me.sbtnAjusteSub.OnBackColor = System.Drawing.Color.LightGreen
        Me.sbtnAjusteSub.OnText = "SI"
        Me.sbtnAjusteSub.Size = New System.Drawing.Size(66, 19)
        Me.sbtnAjusteSub.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sbtnAjusteSub.TabIndex = 277
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(231, 15)
        Me.Label2.TabIndex = 276
        Me.Label2.Text = "Incluir último ajuste al subsidio calculado"
        '
        'sbtnSuaPaid
        '
        '
        '
        '
        Me.sbtnSuaPaid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sbtnSuaPaid.Location = New System.Drawing.Point(261, 51)
        Me.sbtnSuaPaid.Name = "sbtnSuaPaid"
        Me.sbtnSuaPaid.OffBackColor = System.Drawing.Color.LightCoral
        Me.sbtnSuaPaid.OffText = "NO"
        Me.sbtnSuaPaid.OnBackColor = System.Drawing.Color.LightGreen
        Me.sbtnSuaPaid.OnText = "SI"
        Me.sbtnSuaPaid.Size = New System.Drawing.Size(66, 19)
        Me.sbtnSuaPaid.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sbtnSuaPaid.TabIndex = 275
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 15)
        Me.Label1.TabIndex = 274
        Me.Label1.Text = "SUA pagado del mes anterior"
        '
        'sbtnCalcAgui
        '
        '
        '
        '
        Me.sbtnCalcAgui.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sbtnCalcAgui.Location = New System.Drawing.Point(262, 24)
        Me.sbtnCalcAgui.Name = "sbtnCalcAgui"
        Me.sbtnCalcAgui.OffBackColor = System.Drawing.Color.LightCoral
        Me.sbtnCalcAgui.OffText = "NO"
        Me.sbtnCalcAgui.OnBackColor = System.Drawing.Color.LightGreen
        Me.sbtnCalcAgui.OnText = "SI"
        Me.sbtnCalcAgui.Size = New System.Drawing.Size(66, 19)
        Me.sbtnCalcAgui.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sbtnCalcAgui.TabIndex = 273
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 15)
        Me.Label6.TabIndex = 271
        Me.Label6.Text = "Calcular aguinaldo anual"
        '
        'btnAcept
        '
        Me.btnAcept.Location = New System.Drawing.Point(198, 151)
        Me.btnAcept.Name = "btnAcept"
        Me.btnAcept.Size = New System.Drawing.Size(75, 23)
        Me.btnAcept.TabIndex = 286
        Me.btnAcept.Text = "Aceptar"
        Me.btnAcept.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(279, 151)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 288
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'frmProcesoNominaCalcularOpciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(366, 186)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnAcept)
        Me.Name = "frmProcesoNominaCalcularOpciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Opciones de cálculo"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents sbtnCalcAgui As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnAcept As System.Windows.Forms.Button
    Friend WithEvents sbtnSuaPaid As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents sbtnAjusteSub As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
