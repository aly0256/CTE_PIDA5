<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditaEscolaridad
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.sbFinalizo = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAnos = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNombreEscolaridad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cmbEscolaridad = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnElimina = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel2.Controls.Add(Me.sbFinalizo)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.txtAnos)
        Me.Panel2.Controls.Add(Me.txtNombreEscolaridad)
        Me.Panel2.Controls.Add(Me.cmbEscolaridad)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 30)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(545, 169)
        Me.Panel2.TabIndex = 5
        '
        'sbFinalizo
        '
        '
        '
        '
        Me.sbFinalizo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sbFinalizo.Location = New System.Drawing.Point(160, 119)
        Me.sbFinalizo.Name = "sbFinalizo"
        Me.sbFinalizo.OffText = "NO"
        Me.sbFinalizo.OnText = "SI"
        Me.sbFinalizo.Size = New System.Drawing.Size(66, 22)
        Me.sbFinalizo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sbFinalizo.TabIndex = 282
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 16)
        Me.Label5.TabIndex = 281
        Me.Label5.Text = "Finalizó"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(3, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 16)
        Me.Label4.TabIndex = 280
        Me.Label4.Text = "Años"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 16)
        Me.Label3.TabIndex = 279
        Me.Label3.Text = "Nombre/Descripción"
        '
        'txtAnos
        '
        Me.txtAnos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtAnos.Border.Class = "TextBoxBorder"
        Me.txtAnos.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAnos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnos.ForeColor = System.Drawing.Color.Black
        Me.txtAnos.Location = New System.Drawing.Point(160, 81)
        Me.txtAnos.Name = "txtAnos"
        Me.txtAnos.Size = New System.Drawing.Size(66, 26)
        Me.txtAnos.TabIndex = 278
        '
        'txtNombreEscolaridad
        '
        Me.txtNombreEscolaridad.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtNombreEscolaridad.Border.Class = "TextBoxBorder"
        Me.txtNombreEscolaridad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombreEscolaridad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreEscolaridad.ForeColor = System.Drawing.Color.Black
        Me.txtNombreEscolaridad.Location = New System.Drawing.Point(160, 44)
        Me.txtNombreEscolaridad.Name = "txtNombreEscolaridad"
        Me.txtNombreEscolaridad.Size = New System.Drawing.Size(365, 26)
        Me.txtNombreEscolaridad.TabIndex = 277
        '
        'cmbEscolaridad
        '
        Me.cmbEscolaridad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEscolaridad.FormattingEnabled = True
        Me.cmbEscolaridad.Location = New System.Drawing.Point(161, 6)
        Me.cmbEscolaridad.Name = "cmbEscolaridad"
        Me.cmbEscolaridad.Size = New System.Drawing.Size(365, 28)
        Me.cmbEscolaridad.TabIndex = 275
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(152, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nivel de escolaridad"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(545, 30)
        Me.Panel1.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(168, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Edición de escolaridad"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnElimina)
        Me.Panel3.Controls.Add(Me.btnAceptar)
        Me.Panel3.Controls.Add(Me.btnCancelar)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 199)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(545, 49)
        Me.Panel3.TabIndex = 6
        '
        'btnElimina
        '
        Me.btnElimina.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnElimina.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnElimina.Location = New System.Drawing.Point(41, 4)
        Me.btnElimina.Name = "btnElimina"
        Me.btnElimina.Size = New System.Drawing.Size(148, 33)
        Me.btnElimina.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnElimina.TabIndex = 10
        Me.btnElimina.Text = "Eliminar"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Location = New System.Drawing.Point(212, 4)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(148, 33)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 13
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCancelar.Location = New System.Drawing.Point(376, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(148, 34)
        Me.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Text = "Cancelar"
        '
        'frmEditaEscolaridad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(545, 248)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmEditaEscolaridad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmEditaEscolaridad"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAnos As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNombreEscolaridad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmbEscolaridad As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnElimina As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents sbFinalizo As DevComponents.DotNetBar.Controls.SwitchButton
End Class
