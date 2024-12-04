<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalcNom
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCalcNom))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.txtAnio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtPeriodo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCalcGenNom = New DevComponents.DotNetBar.ButtonX()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(224, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 253
        Me.Label1.Text = "Periodo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(44, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 17)
        Me.Label5.TabIndex = 252
        Me.Label5.Text = "Año"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(134, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(238, 40)
        Me.ReflectionLabel1.TabIndex = 254
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CÁLCULO GENERAL</b></font>"
        '
        'txtAnio
        '
        Me.txtAnio.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtAnio.Border.Class = "TextBoxBorder"
        Me.txtAnio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAnio.Enabled = False
        Me.txtAnio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnio.ForeColor = System.Drawing.Color.Black
        Me.txtAnio.Location = New System.Drawing.Point(83, 61)
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.ReadOnly = True
        Me.txtAnio.Size = New System.Drawing.Size(103, 21)
        Me.txtAnio.TabIndex = 255
        '
        'txtPeriodo
        '
        Me.txtPeriodo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtPeriodo.Border.Class = "TextBoxBorder"
        Me.txtPeriodo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPeriodo.Enabled = False
        Me.txtPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.ForeColor = System.Drawing.Color.Black
        Me.txtPeriodo.Location = New System.Drawing.Point(287, 63)
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.ReadOnly = True
        Me.txtPeriodo.Size = New System.Drawing.Size(212, 21)
        Me.txtPeriodo.TabIndex = 256
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(383, 212)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(116, 28)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 258
        Me.btnCerrar.Text = "Salir"
        '
        'btnCalcGenNom
        '
        Me.btnCalcGenNom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCalcGenNom.CausesValidation = False
        Me.btnCalcGenNom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCalcGenNom.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnCalcGenNom.Image = Global.PIDA.My.Resources.Resources._1471324111_table_edit
        Me.btnCalcGenNom.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCalcGenNom.Location = New System.Drawing.Point(150, 124)
        Me.btnCalcGenNom.Name = "btnCalcGenNom"
        Me.btnCalcGenNom.Size = New System.Drawing.Size(206, 78)
        Me.btnCalcGenNom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCalcGenNom.TabIndex = 257
        Me.btnCalcGenNom.Text = "Cálculo general"
        '
        'frmCalcNom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(502, 246)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnCalcGenNom)
        Me.Controls.Add(Me.txtPeriodo)
        Me.Controls.Add(Me.txtAnio)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCalcNom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cálculo de nómina"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents txtAnio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtPeriodo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnCalcGenNom As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
End Class
