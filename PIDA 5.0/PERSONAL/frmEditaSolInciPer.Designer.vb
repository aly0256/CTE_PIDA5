<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditaSolInciPer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditaSolInciPer))
        Me.chkSuperv = New System.Windows.Forms.CheckBox()
        Me.chkRH = New System.Windows.Forms.CheckBox()
        Me.chkGteOP = New System.Windows.Forms.CheckBox()
        Me.chkGteGral = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkSuperv
        '
        Me.chkSuperv.AutoSize = True
        Me.chkSuperv.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSuperv.Location = New System.Drawing.Point(7, 10)
        Me.chkSuperv.Name = "chkSuperv"
        Me.chkSuperv.Size = New System.Drawing.Size(113, 24)
        Me.chkSuperv.TabIndex = 1
        Me.chkSuperv.Text = "Supervisor"
        Me.chkSuperv.UseVisualStyleBackColor = True
        '
        'chkRH
        '
        Me.chkRH.AutoSize = True
        Me.chkRH.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRH.Location = New System.Drawing.Point(131, 10)
        Me.chkRH.Name = "chkRH"
        Me.chkRH.Size = New System.Drawing.Size(185, 24)
        Me.chkRH.TabIndex = 2
        Me.chkRH.Text = "Recursos Humanos"
        Me.chkRH.UseVisualStyleBackColor = True
        '
        'chkGteOP
        '
        Me.chkGteOP.AutoSize = True
        Me.chkGteOP.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkGteOP.Location = New System.Drawing.Point(331, 10)
        Me.chkGteOP.Name = "chkGteOP"
        Me.chkGteOP.Size = New System.Drawing.Size(169, 24)
        Me.chkGteOP.TabIndex = 3
        Me.chkGteOP.Text = "Gte. Operaciones"
        Me.chkGteOP.UseVisualStyleBackColor = True
        '
        'chkGteGral
        '
        Me.chkGteGral.AutoSize = True
        Me.chkGteGral.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkGteGral.Location = New System.Drawing.Point(520, 10)
        Me.chkGteGral.Name = "chkGteGral"
        Me.chkGteGral.Size = New System.Drawing.Size(107, 24)
        Me.chkGteGral.TabIndex = 4
        Me.chkGteGral.Text = "Gte. Gral."
        Me.chkGteGral.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.chkSuperv)
        Me.Panel1.Controls.Add(Me.chkGteGral)
        Me.Panel1.Controls.Add(Me.chkRH)
        Me.Panel1.Controls.Add(Me.chkGteOP)
        Me.Panel1.Location = New System.Drawing.Point(5, 56)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(642, 42)
        Me.Panel1.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel2.Controls.Add(Me.ButtonX2)
        Me.Panel2.Controls.Add(Me.btnAceptar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 104)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(651, 52)
        Me.Panel2.TabIndex = 6
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.CausesValidation = False
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonX2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX2.Location = New System.Drawing.Point(541, 8)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(106, 37)
        Me.ButtonX2.TabIndex = 9
        Me.ButtonX2.Text = "Salir"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAceptar.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Location = New System.Drawing.Point(419, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(106, 37)
        Me.btnAceptar.TabIndex = 7
        Me.btnAceptar.Text = "Aceptar"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(651, 50)
        Me.Panel3.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(4, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(340, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Aprobación de incidencia"
        '
        'frmEditaSolInciPer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 156)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEditaSolInciPer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkSuperv As System.Windows.Forms.CheckBox
    Friend WithEvents chkRH As System.Windows.Forms.CheckBox
    Friend WithEvents chkGteOP As System.Windows.Forms.CheckBox
    Friend WithEvents chkGteGral As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
