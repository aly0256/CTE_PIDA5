<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditAgreConcepto
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
        Me.cmbConceptos = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMonto = New DevComponents.Editors.DoubleInput()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        CType(Me.txtMonto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(161, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(149, 50)
        Me.ReflectionLabel1.TabIndex = 83
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CONCEPTOS</b></font>"
        '
        'cmbConceptos
        '
        Me.cmbConceptos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbConceptos.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbConceptos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbConceptos.ButtonDropDown.Visible = True
        Me.cmbConceptos.DisplayMembers = "concepto,nombre"
        Me.cmbConceptos.GroupingMembers = "naturaleza"
        Me.cmbConceptos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbConceptos.Location = New System.Drawing.Point(97, 83)
        Me.cmbConceptos.Name = "cmbConceptos"
        Me.cmbConceptos.Size = New System.Drawing.Size(314, 23)
        Me.cmbConceptos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbConceptos.TabIndex = 84
        Me.cmbConceptos.ValueMember = "concepto"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 15)
        Me.Label6.TabIndex = 150
        Me.Label6.Text = "Concepto"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtDescripcion.Border.Class = "TextBoxBorder"
        Me.txtDescripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDescripcion.Enabled = False
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.ForeColor = System.Drawing.Color.Black
        Me.txtDescripcion.Location = New System.Drawing.Point(97, 112)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(318, 22)
        Me.txtDescripcion.TabIndex = 152
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 15)
        Me.Label2.TabIndex = 151
        Me.Label2.Text = "Descripción:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 15)
        Me.Label3.TabIndex = 154
        Me.Label3.Text = "Monto:"
        '
        'txtMonto
        '
        '
        '
        '
        Me.txtMonto.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtMonto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMonto.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.Increment = 1.0R
        Me.txtMonto.Location = New System.Drawing.Point(97, 140)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.ShowUpDown = True
        Me.txtMonto.Size = New System.Drawing.Size(80, 22)
        Me.txtMonto.TabIndex = 153
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
        Me.btnCerrar.Location = New System.Drawing.Point(376, 288)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 156
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
        Me.btnAceptar.Location = New System.Drawing.Point(291, 288)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 155
        Me.btnAceptar.Text = "Aceptar"
        '
        'frmEditAgreConcepto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 325)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMonto)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbConceptos)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "frmEditAgreConcepto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar/Agregar"
        CType(Me.txtMonto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents cmbConceptos As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMonto As DevComponents.Editors.DoubleInput
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
End Class
