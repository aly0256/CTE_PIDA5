<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class froModificarFactorCreditoInfonavit
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
        Me.cmbTipoInfonavitNombre = New DevComponents.AdvTree.ColumnHeader()
        Me.cmbTipoInfonavit = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.cmbTipoInfonavitCodigo = New DevComponents.AdvTree.ColumnHeader()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpAlta = New System.Windows.Forms.DateTimePicker()
        Me.lblNombres = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.btnGuardar = New DevComponents.DotNetBar.ButtonX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtFactorDeDescuentoInfonavit = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNumeroCredito = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbTipoInfonavitNombre
        '
        Me.cmbTipoInfonavitNombre.DataFieldName = "nombre"
        Me.cmbTipoInfonavitNombre.Name = "cmbTipoInfonavitNombre"
        Me.cmbTipoInfonavitNombre.Text = "Nombre"
        Me.cmbTipoInfonavitNombre.Width.Relative = 80
        '
        'cmbTipoInfonavit
        '
        Me.cmbTipoInfonavit.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbTipoInfonavit.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbTipoInfonavit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbTipoInfonavit.ButtonDropDown.Visible = True
        Me.cmbTipoInfonavit.Columns.Add(Me.cmbTipoInfonavitCodigo)
        Me.cmbTipoInfonavit.Columns.Add(Me.cmbTipoInfonavitNombre)
        Me.cmbTipoInfonavit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoInfonavit.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbTipoInfonavit.Location = New System.Drawing.Point(301, 162)
        Me.cmbTipoInfonavit.Name = "cmbTipoInfonavit"
        Me.cmbTipoInfonavit.Size = New System.Drawing.Size(233, 23)
        Me.cmbTipoInfonavit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipoInfonavit.TabIndex = 132
        '
        'cmbTipoInfonavitCodigo
        '
        Me.cmbTipoInfonavitCodigo.DataFieldName = "tipo"
        Me.cmbTipoInfonavitCodigo.Name = "cmbTipoInfonavitCodigo"
        Me.cmbTipoInfonavitCodigo.Text = "Tipo"
        Me.cmbTipoInfonavitCodigo.Width.Relative = 20
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gainsboro
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtpAlta)
        Me.Panel1.Controls.Add(Me.lblNombres)
        Me.Panel1.Controls.Add(Me.LabelX3)
        Me.Panel1.Controls.Add(Me.LabelX4)
        Me.Panel1.Controls.Add(Me.txtReloj)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(546, 77)
        Me.Panel1.TabIndex = 131
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "Nombre:"
        '
        'dtpAlta
        '
        Me.dtpAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.dtpAlta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpAlta.Location = New System.Drawing.Point(411, 44)
        Me.dtpAlta.Name = "dtpAlta"
        Me.dtpAlta.Size = New System.Drawing.Size(123, 23)
        Me.dtpAlta.TabIndex = 118
        '
        'lblNombres
        '
        '
        '
        '
        Me.lblNombres.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblNombres.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombres.Location = New System.Drawing.Point(17, 32)
        Me.lblNombres.Name = "lblNombres"
        Me.lblNombres.SingleLineColor = System.Drawing.SystemColors.Control
        Me.lblNombres.Size = New System.Drawing.Size(320, 23)
        Me.lblNombres.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.lblNombres.TabIndex = 113
        Me.lblNombres.Text = "-,-,-"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX3.Location = New System.Drawing.Point(367, 44)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(38, 23)
        Me.LabelX3.TabIndex = 119
        Me.LabelX3.Text = "Alta"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(357, 15)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(48, 23)
        Me.LabelX4.TabIndex = 114
        Me.LabelX4.Text = "Reloj"
        '
        'txtReloj
        '
        Me.txtReloj.BackColor = System.Drawing.Color.LimeGreen
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtReloj.Location = New System.Drawing.Point(411, 12)
        Me.txtReloj.MaxLength = 6
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.ReadOnly = True
        Me.txtReloj.Size = New System.Drawing.Size(123, 29)
        Me.txtReloj.TabIndex = 115
        Me.txtReloj.Text = "999999"
        Me.txtReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.CausesValidation = False
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX1.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.ButtonX1.Location = New System.Drawing.Point(16, 272)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(123, 25)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 130
        Me.ButtonX1.Text = "Cancelar"
        '
        'btnGuardar
        '
        Me.btnGuardar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGuardar.CausesValidation = False
        Me.btnGuardar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnGuardar.Location = New System.Drawing.Point(414, 272)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(123, 25)
        Me.btnGuardar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGuardar.TabIndex = 129
        Me.btnGuardar.Text = "Guardar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 162)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 17)
        Me.Label3.TabIndex = 122
        Me.Label3.Text = "Tipo de crédito:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(13, 194)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(162, 17)
        Me.Label17.TabIndex = 128
        Me.Label17.Text = "Factor de descuento:"
        '
        'txtFactorDeDescuentoInfonavit
        '
        Me.txtFactorDeDescuentoInfonavit.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtFactorDeDescuentoInfonavit.Border.Class = "TextBoxBorder"
        Me.txtFactorDeDescuentoInfonavit.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFactorDeDescuentoInfonavit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFactorDeDescuentoInfonavit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtFactorDeDescuentoInfonavit.Location = New System.Drawing.Point(301, 194)
        Me.txtFactorDeDescuentoInfonavit.Name = "txtFactorDeDescuentoInfonavit"
        Me.txtFactorDeDescuentoInfonavit.Size = New System.Drawing.Size(233, 26)
        Me.txtFactorDeDescuentoInfonavit.TabIndex = 125
        '
        'txtNumeroCredito
        '
        Me.txtNumeroCredito.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtNumeroCredito.Border.Class = "TextBoxBorder"
        Me.txtNumeroCredito.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNumeroCredito.Enabled = False
        Me.txtNumeroCredito.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumeroCredito.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNumeroCredito.Location = New System.Drawing.Point(301, 102)
        Me.txtNumeroCredito.Name = "txtNumeroCredito"
        Me.txtNumeroCredito.Size = New System.Drawing.Size(233, 26)
        Me.txtNumeroCredito.TabIndex = 124
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(13, 102)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(147, 17)
        Me.Label15.TabIndex = 123
        Me.Label15.Text = "Número de crédito:"
        '
        'froModificarFactorCreditoInfonavit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(546, 305)
        Me.Controls.Add(Me.cmbTipoInfonavit)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtFactorDeDescuentoInfonavit)
        Me.Controls.Add(Me.txtNumeroCredito)
        Me.Controls.Add(Me.Label15)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "froModificarFactorCreditoInfonavit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Modificar factor de descuento"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbTipoInfonavitNombre As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents cmbTipoInfonavit As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cmbTipoInfonavitCodigo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpAlta As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblNombres As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnGuardar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtFactorDeDescuentoInfonavit As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNumeroCredito As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
