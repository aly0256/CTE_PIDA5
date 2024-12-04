<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditarHoras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditarHoras))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbConcepto = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtMonto = New DevComponents.Editors.DoubleInput()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtComentario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.cConcepto = New DevComponents.AdvTree.ColumnHeader()
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
        Me.ReflectionLabel1.Location = New System.Drawing.Point(138, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(149, 50)
        Me.ReflectionLabel1.TabIndex = 2
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>AJUSTES</b></font>"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Concepto"
        '
        'cmbConcepto
        '
        Me.cmbConcepto.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbConcepto.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbConcepto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbConcepto.ButtonDropDown.Visible = True
        Me.cmbConcepto.Columns.Add(Me.cConcepto)
        Me.cmbConcepto.Enabled = False
        Me.cmbConcepto.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbConcepto.Location = New System.Drawing.Point(102, 75)
        Me.cmbConcepto.Name = "cmbConcepto"
        Me.cmbConcepto.Size = New System.Drawing.Size(185, 23)
        Me.cmbConcepto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbConcepto.TabIndex = 73
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(26, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 15)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Descripción"
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
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.ForeColor = System.Drawing.Color.Black
        Me.txtDescripcion.Location = New System.Drawing.Point(102, 109)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(318, 21)
        Me.txtDescripcion.TabIndex = 75
        '
        'txtMonto
        '
        '
        '
        '
        Me.txtMonto.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtMonto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMonto.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtMonto.Increment = 1.0R
        Me.txtMonto.Location = New System.Drawing.Point(102, 141)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.ShowUpDown = True
        Me.txtMonto.Size = New System.Drawing.Size(80, 20)
        Me.txtMonto.TabIndex = 76
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(26, 146)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 15)
        Me.Label3.TabIndex = 77
        Me.Label3.Text = "Monto"
        '
        'txtComentario
        '
        Me.txtComentario.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtComentario.Border.Class = "TextBoxBorder"
        Me.txtComentario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtComentario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComentario.ForeColor = System.Drawing.Color.Black
        Me.txtComentario.Location = New System.Drawing.Point(102, 174)
        Me.txtComentario.Multiline = True
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(318, 59)
        Me.txtComentario.TabIndex = 79
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(26, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 15)
        Me.Label4.TabIndex = 78
        Me.Label4.Text = "Comentario"
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
        Me.btnCerrar.Location = New System.Drawing.Point(346, 250)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 81
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
        Me.btnAceptar.Location = New System.Drawing.Point(261, 250)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 80
        Me.btnAceptar.Text = "Aceptar"
        '
        'cConcepto
        '
        Me.cConcepto.DataFieldName = "concepto"
        Me.cConcepto.Name = "cConcepto"
        Me.cConcepto.StretchToFill = True
        Me.cConcepto.Text = "Concepto"
        Me.cConcepto.Width.Absolute = 150
        '
        'frmEditarHoras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(432, 288)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtComentario)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMonto)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbConcepto)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEditarHoras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar / Agregar"
        CType(Me.txtMonto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbConcepto As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtMonto As DevComponents.Editors.DoubleInput
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtComentario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cConcepto As DevComponents.AdvTree.ColumnHeader
End Class
