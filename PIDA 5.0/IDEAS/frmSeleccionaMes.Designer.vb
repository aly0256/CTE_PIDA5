<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeleccionaMes
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
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.MesesBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbMes = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MesesBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(46, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(227, 40)
        Me.ReflectionLabel1.TabIndex = 120
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>Selecciona Mes</b></font>"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.Set22
        Me.picImagen.Location = New System.Drawing.Point(12, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(34, 34)
        Me.picImagen.TabIndex = 121
        Me.picImagen.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(135, 122)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(81, 23)
        Me.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancelar.TabIndex = 119
        Me.btnCancelar.Text = "&Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Location = New System.Drawing.Point(48, 122)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(81, 23)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 118
        Me.btnAceptar.Text = "&Aceptar"
        '
        'MesesBox1
        '
        Me.MesesBox1.Controls.Add(Me.cmbMes)
        Me.MesesBox1.Controls.Add(Me.Label1)
        Me.MesesBox1.Location = New System.Drawing.Point(7, 47)
        Me.MesesBox1.Name = "MesesBox1"
        Me.MesesBox1.Size = New System.Drawing.Size(253, 50)
        Me.MesesBox1.TabIndex = 117
        Me.MesesBox1.TabStop = False
        '
        'cmbMes
        '
        Me.cmbMes.DisplayMember = "NUM_AÑO"
        Me.cmbMes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.ItemHeight = 14
        Me.cmbMes.Location = New System.Drawing.Point(83, 19)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(145, 20)
        Me.cmbMes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbMes.TabIndex = 6
        Me.cmbMes.ValueMember = "NUM_AÑO"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Meses:"
        '
        'frmSeleccionaMes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 155)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.picImagen)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.MesesBox1)
        Me.Name = "frmSeleccionaMes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SeleccionaMes"
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MesesBox1.ResumeLayout(False)
        Me.MesesBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents MesesBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbMes As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
