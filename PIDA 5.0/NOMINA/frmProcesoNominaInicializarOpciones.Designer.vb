<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcesoNominaInicializarOpciones
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.sbtnPSG = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.sbtnSindi = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.sbtnDespensaF = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.btnAcept = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.sbtnAgui = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDescDefuncion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 13)
        Me.Label4.TabIndex = 271
        Me.Label4.Text = "Bono despensa a finiquitos"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 13)
        Me.Label1.TabIndex = 273
        Me.Label1.Text = "PSG mayores a 5 horas y altas"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.sbtnPSG)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(284, 58)
        Me.GroupBox1.TabIndex = 281
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Incluir"
        '
        'sbtnPSG
        '
        '
        '
        '
        Me.sbtnPSG.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sbtnPSG.Location = New System.Drawing.Point(198, 23)
        Me.sbtnPSG.Name = "sbtnPSG"
        Me.sbtnPSG.OffBackColor = System.Drawing.Color.LightCoral
        Me.sbtnPSG.OffText = "NO"
        Me.sbtnPSG.OnBackColor = System.Drawing.Color.LightGreen
        Me.sbtnPSG.OnText = "SI"
        Me.sbtnPSG.Size = New System.Drawing.Size(66, 19)
        Me.sbtnPSG.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sbtnPSG.TabIndex = 280
        '
        'sbtnSindi
        '
        '
        '
        '
        Me.sbtnSindi.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sbtnSindi.Location = New System.Drawing.Point(210, 75)
        Me.sbtnSindi.Name = "sbtnSindi"
        Me.sbtnSindi.OffBackColor = System.Drawing.Color.LightCoral
        Me.sbtnSindi.OffText = "NO"
        Me.sbtnSindi.OnBackColor = System.Drawing.Color.LightGreen
        Me.sbtnSindi.OnText = "SI"
        Me.sbtnSindi.Size = New System.Drawing.Size(66, 19)
        Me.sbtnSindi.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sbtnSindi.TabIndex = 281
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.sbtnDespensaF)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 194)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(284, 60)
        Me.GroupBox2.TabIndex = 282
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Incluir en finiquitos"
        '
        'sbtnDespensaF
        '
        '
        '
        '
        Me.sbtnDespensaF.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sbtnDespensaF.Location = New System.Drawing.Point(199, 28)
        Me.sbtnDespensaF.Name = "sbtnDespensaF"
        Me.sbtnDespensaF.OffBackColor = System.Drawing.Color.LightCoral
        Me.sbtnDespensaF.OffText = "NO"
        Me.sbtnDespensaF.OnBackColor = System.Drawing.Color.LightGreen
        Me.sbtnDespensaF.OnText = "SI"
        Me.sbtnDespensaF.Size = New System.Drawing.Size(66, 19)
        Me.sbtnDespensaF.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sbtnDespensaF.TabIndex = 273
        '
        'btnAcept
        '
        Me.btnAcept.Location = New System.Drawing.Point(137, 357)
        Me.btnAcept.Name = "btnAcept"
        Me.btnAcept.Size = New System.Drawing.Size(75, 23)
        Me.btnAcept.TabIndex = 284
        Me.btnAcept.Text = "Aceptar"
        Me.btnAcept.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Location = New System.Drawing.Point(223, 357)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 289
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.sbtnAgui)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(12, 260)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(284, 72)
        Me.GroupBox3.TabIndex = 290
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Incluir aguinaldo proporcional"
        '
        'sbtnAgui
        '
        '
        '
        '
        Me.sbtnAgui.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sbtnAgui.Location = New System.Drawing.Point(198, 32)
        Me.sbtnAgui.Name = "sbtnAgui"
        Me.sbtnAgui.OffBackColor = System.Drawing.Color.LightCoral
        Me.sbtnAgui.OffText = "NO"
        Me.sbtnAgui.OnBackColor = System.Drawing.Color.LightGreen
        Me.sbtnAgui.OnText = "SI"
        Me.sbtnAgui.Size = New System.Drawing.Size(66, 19)
        Me.sbtnAgui.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sbtnAgui.TabIndex = 274
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 13)
        Me.Label2.TabIndex = 272
        Me.Label2.Text = "Ya se calculó aguinaldo anual"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.txtDescDefuncion)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 76)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(284, 111)
        Me.GroupBox4.TabIndex = 291
        Me.GroupBox4.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Enabled = False
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(18, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(196, 13)
        Me.Label7.TabIndex = 285
        Me.Label7.Text = "Formato válido ejemplo: 000001,000002"
        '
        'txtDescDefuncion
        '
        Me.txtDescDefuncion.Enabled = False
        Me.txtDescDefuncion.Location = New System.Drawing.Point(18, 54)
        Me.txtDescDefuncion.Name = "txtDescDefuncion"
        Me.txtDescDefuncion.Size = New System.Drawing.Size(250, 20)
        Me.txtDescDefuncion.TabIndex = 284
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Enabled = False
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 28)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 13)
        Me.Label6.TabIndex = 283
        Me.Label6.Text = "Asignar empleado(s)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 76)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 13)
        Me.Label3.TabIndex = 277
        Me.Label3.Text = "Descuento de defunción"
        '
        'frmProcesoNominaInicializarOpciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(310, 392)
        Me.ControlBox = False
        Me.Controls.Add(Me.sbtnSindi)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAcept)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmProcesoNominaInicializarOpciones"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Opciones de carga previa"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents sbtnSindi As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents sbtnPSG As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents sbtnDespensaF As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents btnAcept As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents sbtnAgui As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDescDefuncion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
