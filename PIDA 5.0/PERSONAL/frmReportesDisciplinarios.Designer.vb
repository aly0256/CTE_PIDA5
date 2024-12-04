<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportesDisciplinarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportesDisciplinarios))
        Me.chckIndividual = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chckGeneral = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.chkPDF = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chckIndividual
        '
        '
        '
        '
        Me.chckIndividual.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chckIndividual.Location = New System.Drawing.Point(70, 58)
        Me.chckIndividual.Name = "chckIndividual"
        Me.chckIndividual.Size = New System.Drawing.Size(119, 23)
        Me.chckIndividual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chckIndividual.TabIndex = 0
        Me.chckIndividual.Text = "Reporte individual"
        '
        'chckGeneral
        '
        '
        '
        '
        Me.chckGeneral.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chckGeneral.Location = New System.Drawing.Point(70, 87)
        Me.chckGeneral.Name = "chckGeneral"
        Me.chckGeneral.Size = New System.Drawing.Size(100, 23)
        Me.chckGeneral.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chckGeneral.TabIndex = 1
        Me.chckGeneral.Text = "Reporte General"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(12, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(289, 40)
        Me.ReflectionLabel1.TabIndex = 93
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>Reportes Disciplinarios</b></font>"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnAceptar)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Location = New System.Drawing.Point(35, 161)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(174, 47)
        Me.GroupBox1.TabIndex = 132
        Me.GroupBox1.TabStop = False
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.Location = New System.Drawing.Point(6, 14)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.TabIndex = 11
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelar.Location = New System.Drawing.Point(88, 14)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Text = "Cancelar"
        '
        'chkPDF
        '
        '
        '
        '
        Me.chkPDF.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkPDF.Location = New System.Drawing.Point(70, 116)
        Me.chkPDF.Name = "chkPDF"
        Me.chkPDF.Size = New System.Drawing.Size(100, 23)
        Me.chkPDF.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkPDF.TabIndex = 133
        Me.chkPDF.Text = "Original PDF"
        Me.chkPDF.Visible = False
        '
        'frmReportesDisciplinarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(261, 235)
        Me.Controls.Add(Me.chkPDF)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.chckGeneral)
        Me.Controls.Add(Me.chckIndividual)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReportesDisciplinarios"
        Me.Text = "Reportes Disciplinarios"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chckIndividual As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chckGeneral As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents chkPDF As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
