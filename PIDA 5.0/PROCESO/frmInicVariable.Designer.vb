<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInicVariable
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInicVariable))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.cmbAno = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnIniciProcVar = New DevComponents.DotNetBar.ButtonX()
        Me.labelEstatus = New System.Windows.Forms.Label()
        Me.cmbPerVar = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(85, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(314, 40)
        Me.ReflectionLabel1.TabIndex = 250
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>Inicializar cálculo de variables</b></font>"
        '
        'cmbAno
        '
        Me.cmbAno.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbAno.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbAno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbAno.ButtonDropDown.Visible = True
        Me.cmbAno.DisplayMembers = "ano"
        Me.cmbAno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAno.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbAno.Location = New System.Drawing.Point(90, 58)
        Me.cmbAno.Name = "cmbAno"
        Me.cmbAno.Size = New System.Drawing.Size(113, 30)
        Me.cmbAno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbAno.TabIndex = 256
        Me.cmbAno.ValueMember = "ano"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(220, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 17)
        Me.Label1.TabIndex = 255
        Me.Label1.Text = "Bimestre"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(51, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 17)
        Me.Label5.TabIndex = 254
        Me.Label5.Text = "Año"
        '
        'btnIniciProcVar
        '
        Me.btnIniciProcVar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnIniciProcVar.CausesValidation = False
        Me.btnIniciProcVar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnIniciProcVar.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.btnIniciProcVar.Image = Global.PIDA.My.Resources.Resources._1471324111_table_edit
        Me.btnIniciProcVar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnIniciProcVar.Location = New System.Drawing.Point(54, 117)
        Me.btnIniciProcVar.Name = "btnIniciProcVar"
        Me.btnIniciProcVar.Size = New System.Drawing.Size(346, 69)
        Me.btnIniciProcVar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnIniciProcVar.TabIndex = 258
        Me.btnIniciProcVar.Text = "Inicializa proceso"
        '
        'labelEstatus
        '
        Me.labelEstatus.BackColor = System.Drawing.SystemColors.Control
        Me.labelEstatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labelEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.labelEstatus.Location = New System.Drawing.Point(54, 208)
        Me.labelEstatus.Name = "labelEstatus"
        Me.labelEstatus.Size = New System.Drawing.Size(346, 61)
        Me.labelEstatus.TabIndex = 259
        Me.labelEstatus.Text = "-"
        Me.labelEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbPerVar
        '
        Me.cmbPerVar.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPerVar.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPerVar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPerVar.ButtonDropDown.Visible = True
        Me.cmbPerVar.DisplayMembers = "bimestre"
        Me.cmbPerVar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPerVar.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPerVar.Location = New System.Drawing.Point(289, 58)
        Me.cmbPerVar.Name = "cmbPerVar"
        Me.cmbPerVar.Size = New System.Drawing.Size(111, 30)
        Me.cmbPerVar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPerVar.TabIndex = 260
        Me.cmbPerVar.ValueMember = "bimestre"
        '
        'frmInicVariable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 289)
        Me.Controls.Add(Me.cmbPerVar)
        Me.Controls.Add(Me.labelEstatus)
        Me.Controls.Add(Me.btnIniciProcVar)
        Me.Controls.Add(Me.cmbAno)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInicVariable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inicializar cálculo de variables"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents cmbAno As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnIniciProcVar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents labelEstatus As System.Windows.Forms.Label
    Friend WithEvents cmbPerVar As DevComponents.DotNetBar.Controls.ComboTree
End Class
