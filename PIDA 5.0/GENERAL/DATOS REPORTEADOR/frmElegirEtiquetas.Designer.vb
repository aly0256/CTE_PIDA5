<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmElegirEtiquetas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmElegirEtiquetas))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbEtiquetas = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ETIQUETA = New DevComponents.AdvTree.ColumnHeader()
        Me.DESCRIPCION = New DevComponents.AdvTree.ColumnHeader()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(35, 2)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(304, 40)
        Me.ReflectionLabel1.TabIndex = 99
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>ELEGIR ETIQUETAS</b></font>"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.PrintFolderLabel32
        Me.picImagen.Location = New System.Drawing.Point(1, 2)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(34, 34)
        Me.picImagen.TabIndex = 100
        Me.picImagen.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbEtiquetas)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(377, 82)
        Me.GroupBox1.TabIndex = 101
        Me.GroupBox1.TabStop = False
        '
        'cmbEtiquetas
        '
        Me.cmbEtiquetas.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbEtiquetas.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbEtiquetas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbEtiquetas.ButtonClear.Tooltip = ""
        Me.cmbEtiquetas.ButtonCustom.Tooltip = ""
        Me.cmbEtiquetas.ButtonCustom2.Tooltip = ""
        Me.cmbEtiquetas.ButtonDropDown.Tooltip = ""
        Me.cmbEtiquetas.ButtonDropDown.Visible = True
        Me.cmbEtiquetas.Columns.Add(Me.ETIQUETA)
        Me.cmbEtiquetas.Columns.Add(Me.DESCRIPCION)
        Me.cmbEtiquetas.DisplayMembers = "etiqueta"
        Me.cmbEtiquetas.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbEtiquetas.Location = New System.Drawing.Point(95, 33)
        Me.cmbEtiquetas.Name = "cmbEtiquetas"
        Me.cmbEtiquetas.Size = New System.Drawing.Size(276, 23)
        Me.cmbEtiquetas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbEtiquetas.TabIndex = 49
        Me.cmbEtiquetas.ValueMember = "etiqueta"
        '
        'ETIQUETA
        '
        Me.ETIQUETA.ColumnName = "ETIQUETA"
        Me.ETIQUETA.DataFieldName = "ETIQUETA"
        Me.ETIQUETA.Name = "ETIQUETA"
        Me.ETIQUETA.Text = "Tipo"
        Me.ETIQUETA.Width.Absolute = 150
        '
        'DESCRIPCION
        '
        Me.DESCRIPCION.ColumnName = "DESCRIPCION"
        Me.DESCRIPCION.DataFieldName = "DESCRIPCION"
        Me.DESCRIPCION.Name = "DESCRIPCION"
        Me.DESCRIPCION.Text = "Descripcion"
        Me.DESCRIPCION.Width.Absolute = 150
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Tipo de etiqueta"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(205, 138)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(81, 23)
        Me.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancelar.TabIndex = 119
        Me.btnCancelar.Text = "&Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Location = New System.Drawing.Point(118, 138)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(81, 23)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 118
        Me.btnAceptar.Text = "&Aceptar"
        '
        'frmElegirEtiquetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 172)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.picImagen)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmElegirEtiquetas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Elección de etiqueta"
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmbEtiquetas As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents ETIQUETA As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents DESCRIPCION As DevComponents.AdvTree.ColumnHeader
End Class
