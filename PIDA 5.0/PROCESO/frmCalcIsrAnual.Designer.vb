<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalcIsrAnual
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCalcIsrAnual))
        Me.txtAnio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCalcVariable = New DevComponents.DotNetBar.ButtonX()
        Me.SuspendLayout()
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
        Me.txtAnio.Location = New System.Drawing.Point(165, 62)
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.ReadOnly = True
        Me.txtAnio.Size = New System.Drawing.Size(159, 21)
        Me.txtAnio.TabIndex = 269
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(47, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 17)
        Me.Label5.TabIndex = 267
        Me.Label5.Text = "Año del ejercicio"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(50, 20)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(295, 40)
        Me.ReflectionLabel1.TabIndex = 266
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CÁLCULO DEL ISR ANUAL</b></font>"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(221, 98)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(103, 37)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 272
        Me.btnCerrar.Text = "Salir"
        '
        'btnCalcVariable
        '
        Me.btnCalcVariable.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCalcVariable.CausesValidation = False
        Me.btnCalcVariable.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCalcVariable.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCalcVariable.Image = Global.PIDA.My.Resources.Resources.CalcFiniquito32
        Me.btnCalcVariable.ImageFixedSize = New System.Drawing.Size(25, 25)
        Me.btnCalcVariable.Location = New System.Drawing.Point(70, 98)
        Me.btnCalcVariable.Name = "btnCalcVariable"
        Me.btnCalcVariable.Size = New System.Drawing.Size(102, 37)
        Me.btnCalcVariable.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCalcVariable.TabIndex = 271
        Me.btnCalcVariable.Text = "Calcular"
        '
        'frmCalcIsrAnual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(373, 171)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnCalcVariable)
        Me.Controls.Add(Me.txtAnio)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCalcIsrAnual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cálculo del ISR Anual"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCalcVariable As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtAnio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
End Class
