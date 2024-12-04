<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeleccionarFirmas
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
        Me.cmbEmpresa = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.cmbEmpleados = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.SuspendLayout()
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbEmpresa.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbEmpresa.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbEmpresa.ButtonDropDown.Visible = True
        Me.cmbEmpresa.Columns.Add(Me.ColumnHeader1)
        Me.cmbEmpresa.Columns.Add(Me.ColumnHeader3)
        Me.cmbEmpresa.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbEmpresa.Location = New System.Drawing.Point(12, 78)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(270, 23)
        Me.cmbEmpresa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbEmpresa.TabIndex = 0
        Me.cmbEmpresa.ValueMember = "Código"
        '
        'cmbEmpleados
        '
        Me.cmbEmpleados.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbEmpleados.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbEmpleados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbEmpleados.ButtonDropDown.Visible = True
        Me.cmbEmpleados.Columns.Add(Me.ColumnHeader2)
        Me.cmbEmpleados.Columns.Add(Me.ColumnHeader4)
        Me.cmbEmpleados.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbEmpleados.Location = New System.Drawing.Point(288, 78)
        Me.cmbEmpleados.Name = "cmbEmpleados"
        Me.cmbEmpleados.Size = New System.Drawing.Size(270, 23)
        Me.cmbEmpleados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbEmpleados.TabIndex = 1
        Me.cmbEmpleados.ValueMember = "Código"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(62, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 15)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Representante de la empresa"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(329, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(189, 15)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Representante de los empleados"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(22, -5)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(546, 69)
        Me.ReflectionLabel1.TabIndex = 34
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>Seleccion de representantes de la Comisión Mixta" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " de Ca" & _
    "pacitación y Adiestramiento</b></font>"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(288, 117)
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
        Me.btnAceptar.Location = New System.Drawing.Point(201, 117)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(81, 23)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 118
        Me.btnAceptar.Text = "&Aceptar"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.ColumnName = "Código"
        Me.ColumnHeader1.DataFieldName = "Código"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Código"
        Me.ColumnHeader1.Width.Absolute = 40
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.ColumnName = "Código"
        Me.ColumnHeader2.DataFieldName = "Código"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Código"
        Me.ColumnHeader2.Width.Absolute = 40
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.ColumnName = "Nombre"
        Me.ColumnHeader3.DataFieldName = "Nombre"
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Nombre"
        Me.ColumnHeader3.Width.Absolute = 180
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.ColumnName = "Nombre"
        Me.ColumnHeader4.DataFieldName = "Nombre"
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "Nombre"
        Me.ColumnHeader4.Width.Absolute = 180
        '
        'frmSeleccionarFirmas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(571, 151)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbEmpleados)
        Me.Controls.Add(Me.cmbEmpresa)
        Me.Name = "frmSeleccionarFirmas"
        Me.Text = "Selección de representantes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbEmpresa As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cmbEmpleados As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
End Class
