<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditPerLiqFah
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditPerLiqFah))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.txtAnioInic = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPerInic = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPerFin = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAnioFin = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAnioAplica = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtComentario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(7, 7)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(320, 50)
        Me.ReflectionLabel1.TabIndex = 83
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>Alta de nuevo ciclo para pago y liquidación de FAH</b></" & _
    "font>"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cancel16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(213, 257)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 94
        Me.btnCerrar.Text = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnAceptar.Location = New System.Drawing.Point(128, 257)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 93
        Me.btnAceptar.Text = "Aceptar"
        '
        'txtAnioInic
        '
        Me.txtAnioInic.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtAnioInic.Border.Class = "TextBoxBorder"
        Me.txtAnioInic.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAnioInic.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnioInic.ForeColor = System.Drawing.Color.Black
        Me.txtAnioInic.Location = New System.Drawing.Point(101, 60)
        Me.txtAnioInic.MaxLength = 4
        Me.txtAnioInic.Name = "txtAnioInic"
        Me.txtAnioInic.Size = New System.Drawing.Size(101, 22)
        Me.txtAnioInic.TabIndex = 96
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 15)
        Me.Label2.TabIndex = 95
        Me.Label2.Text = "Año inicio:"
        '
        'txtPerInic
        '
        Me.txtPerInic.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtPerInic.Border.Class = "TextBoxBorder"
        Me.txtPerInic.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPerInic.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPerInic.ForeColor = System.Drawing.Color.Black
        Me.txtPerInic.Location = New System.Drawing.Point(102, 88)
        Me.txtPerInic.MaxLength = 2
        Me.txtPerInic.Name = "txtPerInic"
        Me.txtPerInic.Size = New System.Drawing.Size(101, 22)
        Me.txtPerInic.TabIndex = 98
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 15)
        Me.Label1.TabIndex = 97
        Me.Label1.Text = "Periodo inicio:"
        '
        'txtPerFin
        '
        Me.txtPerFin.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtPerFin.Border.Class = "TextBoxBorder"
        Me.txtPerFin.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPerFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPerFin.ForeColor = System.Drawing.Color.Black
        Me.txtPerFin.Location = New System.Drawing.Point(101, 146)
        Me.txtPerFin.MaxLength = 2
        Me.txtPerFin.Name = "txtPerFin"
        Me.txtPerFin.Size = New System.Drawing.Size(101, 22)
        Me.txtPerFin.TabIndex = 102
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 15)
        Me.Label3.TabIndex = 101
        Me.Label3.Text = "Periodo fin:"
        '
        'txtAnioFin
        '
        Me.txtAnioFin.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtAnioFin.Border.Class = "TextBoxBorder"
        Me.txtAnioFin.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAnioFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnioFin.ForeColor = System.Drawing.Color.Black
        Me.txtAnioFin.Location = New System.Drawing.Point(102, 118)
        Me.txtAnioFin.MaxLength = 4
        Me.txtAnioFin.Name = "txtAnioFin"
        Me.txtAnioFin.Size = New System.Drawing.Size(101, 22)
        Me.txtAnioFin.TabIndex = 100
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 15)
        Me.Label4.TabIndex = 99
        Me.Label4.Text = "Año fin:"
        '
        'txtAnioAplica
        '
        Me.txtAnioAplica.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtAnioAplica.Border.Class = "TextBoxBorder"
        Me.txtAnioAplica.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAnioAplica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnioAplica.ForeColor = System.Drawing.Color.Black
        Me.txtAnioAplica.Location = New System.Drawing.Point(101, 175)
        Me.txtAnioAplica.MaxLength = 4
        Me.txtAnioAplica.Name = "txtAnioAplica"
        Me.txtAnioAplica.Size = New System.Drawing.Size(101, 22)
        Me.txtAnioAplica.TabIndex = 104
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 180)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 15)
        Me.Label5.TabIndex = 103
        Me.Label5.Text = "Año aplicar:"
        '
        'txtComentario
        '
        Me.txtComentario.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtComentario.Border.Class = "TextBoxBorder"
        Me.txtComentario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtComentario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentario.ForeColor = System.Drawing.Color.Black
        Me.txtComentario.Location = New System.Drawing.Point(101, 203)
        Me.txtComentario.MaxLength = 50
        Me.txtComentario.Multiline = True
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(196, 37)
        Me.txtComentario.TabIndex = 106
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 203)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 15)
        Me.Label6.TabIndex = 105
        Me.Label6.Text = "Comentario:"
        '
        'frmEditPerLiqFah
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 303)
        Me.Controls.Add(Me.txtComentario)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtAnioAplica)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtPerFin)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAnioFin)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPerInic)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAnioInic)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEditPerLiqFah"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Periodos de liquidación para FAH"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtAnioInic As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPerInic As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPerFin As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAnioFin As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAnioAplica As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtComentario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
