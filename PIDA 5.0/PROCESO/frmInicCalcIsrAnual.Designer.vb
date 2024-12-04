<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInicCalcIsrAnual
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInicCalcIsrAnual))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.cmbAno = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnInicCalcIsrAn = New DevComponents.DotNetBar.ButtonX()
        Me.labelEstatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(54, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(342, 40)
        Me.ReflectionLabel1.TabIndex = 251
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>Inicializar cálculo del ISR anual</b></font>"
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
        Me.cmbAno.Location = New System.Drawing.Point(181, 52)
        Me.cmbAno.Name = "cmbAno"
        Me.cmbAno.Size = New System.Drawing.Size(183, 30)
        Me.cmbAno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbAno.TabIndex = 258
        Me.cmbAno.ValueMember = "ano"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(51, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 17)
        Me.Label5.TabIndex = 257
        Me.Label5.Text = "Año del ejercicio"
        '
        'btnInicCalcIsrAn
        '
        Me.btnInicCalcIsrAn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnInicCalcIsrAn.CausesValidation = False
        Me.btnInicCalcIsrAn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnInicCalcIsrAn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.btnInicCalcIsrAn.Image = Global.PIDA.My.Resources.Resources._1471324111_table_edit
        Me.btnInicCalcIsrAn.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnInicCalcIsrAn.Location = New System.Drawing.Point(54, 105)
        Me.btnInicCalcIsrAn.Name = "btnInicCalcIsrAn"
        Me.btnInicCalcIsrAn.Size = New System.Drawing.Size(310, 47)
        Me.btnInicCalcIsrAn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnInicCalcIsrAn.TabIndex = 259
        Me.btnInicCalcIsrAn.Text = "Inicializa proceso"
        '
        'labelEstatus
        '
        Me.labelEstatus.BackColor = System.Drawing.SystemColors.Control
        Me.labelEstatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labelEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.labelEstatus.Location = New System.Drawing.Point(50, 174)
        Me.labelEstatus.Name = "labelEstatus"
        Me.labelEstatus.Size = New System.Drawing.Size(314, 61)
        Me.labelEstatus.TabIndex = 260
        Me.labelEstatus.Text = "-"
        Me.labelEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmInicCalcIsrAnual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 269)
        Me.Controls.Add(Me.labelEstatus)
        Me.Controls.Add(Me.btnInicCalcIsrAn)
        Me.Controls.Add(Me.cmbAno)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInicCalcIsrAnual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inicializar cálculo de ISR Anual"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents cmbAno As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnInicCalcIsrAn As DevComponents.DotNetBar.ButtonX
    Friend WithEvents labelEstatus As System.Windows.Forms.Label
End Class
