<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditaFaEsDA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditaFaEsDA))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtFecha = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNombreFamiliar = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cmbTipoPago = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnElimina = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtIdfld = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(31, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(730, 30)
        Me.Panel1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Edición de familiares"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Panel2.Controls.Add(Me.txtIdfld)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.txtFecha)
        Me.Panel2.Controls.Add(Me.txtNombreFamiliar)
        Me.Panel2.Controls.Add(Me.cmbTipoPago)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 30)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(730, 194)
        Me.Panel2.TabIndex = 2
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtFecha.Border.Class = "TextBoxBorder"
        Me.txtFecha.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFecha.ForeColor = System.Drawing.Color.Black
        Me.txtFecha.Location = New System.Drawing.Point(353, 88)
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.Size = New System.Drawing.Size(365, 26)
        Me.txtFecha.TabIndex = 278
        '
        'txtNombreFamiliar
        '
        Me.txtNombreFamiliar.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtNombreFamiliar.Border.Class = "TextBoxBorder"
        Me.txtNombreFamiliar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombreFamiliar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreFamiliar.ForeColor = System.Drawing.Color.Black
        Me.txtNombreFamiliar.Location = New System.Drawing.Point(353, 49)
        Me.txtNombreFamiliar.Name = "txtNombreFamiliar"
        Me.txtNombreFamiliar.Size = New System.Drawing.Size(365, 26)
        Me.txtNombreFamiliar.TabIndex = 277
        '
        'cmbTipoPago
        '
        Me.cmbTipoPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoPago.FormattingEnabled = True
        Me.cmbTipoPago.Location = New System.Drawing.Point(353, 10)
        Me.cmbTipoPago.Name = "cmbTipoPago"
        Me.cmbTipoPago.Size = New System.Drawing.Size(365, 28)
        Me.cmbTipoPago.TabIndex = 275
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Familiar"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btnElimina)
        Me.Panel3.Controls.Add(Me.btnAceptar)
        Me.Panel3.Controls.Add(Me.btnCancelar)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 180)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(730, 44)
        Me.Panel3.TabIndex = 3
        '
        'btnElimina
        '
        Me.btnElimina.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnElimina.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnElimina.Location = New System.Drawing.Point(233, 4)
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
        Me.btnAceptar.Location = New System.Drawing.Point(404, 4)
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
        Me.btnCancelar.Location = New System.Drawing.Point(568, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(148, 34)
        Me.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Text = "Cancelar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(343, 16)
        Me.Label3.TabIndex = 279
        Me.Label3.Text = "Nombre(Ejem. Ap Paterno/Ap Materno/Nombres)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(3, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(154, 16)
        Me.Label4.TabIndex = 280
        Me.Label4.Text = "Fecha de nacimiento"
        '
        'txtIdfld
        '
        Me.txtIdfld.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtIdfld.Border.Class = "TextBoxBorder"
        Me.txtIdfld.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtIdfld.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIdfld.ForeColor = System.Drawing.Color.Black
        Me.txtIdfld.Location = New System.Drawing.Point(77, 112)
        Me.txtIdfld.Name = "txtIdfld"
        Me.txtIdfld.Size = New System.Drawing.Size(89, 26)
        Me.txtIdfld.TabIndex = 281
        Me.txtIdfld.Visible = False
        '
        'frmEditaFaEsDA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(730, 224)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEditaFaEsDA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edición"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnElimina As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoPago As System.Windows.Forms.ComboBox
    Friend WithEvents txtNombreFamiliar As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtFecha As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtIdfld As DevComponents.DotNetBar.Controls.TextBoxX
End Class
