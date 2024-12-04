<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditarPensAlim
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEditarPensAlim))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.txtNoCuenta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblCta_Clabe_pensAlim = New System.Windows.Forms.Label()
        Me.chkInter = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPorc = New DevComponents.Editors.DoubleInput()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAPatPensAlim = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtApMatPensAlim = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNombresPensAlim = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkPAPorc = New System.Windows.Forms.CheckBox()
        Me.chkPACFija = New System.Windows.Forms.CheckBox()
        CType(Me.txtPorc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(159, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(129, 50)
        Me.ReflectionLabel1.TabIndex = 3
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>AJUSTES</b></font>"
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
        Me.btnCerrar.Location = New System.Drawing.Point(317, 337)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 83
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
        Me.btnAceptar.Location = New System.Drawing.Point(232, 337)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 82
        Me.btnAceptar.Text = "Aceptar"
        '
        'txtNoCuenta
        '
        '
        '
        '
        Me.txtNoCuenta.Border.Class = "TextBoxBorder"
        Me.txtNoCuenta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNoCuenta.Location = New System.Drawing.Point(107, 281)
        Me.txtNoCuenta.MaxLength = 18
        Me.txtNoCuenta.Name = "txtNoCuenta"
        Me.txtNoCuenta.PreventEnterBeep = True
        Me.txtNoCuenta.Size = New System.Drawing.Size(290, 20)
        Me.txtNoCuenta.TabIndex = 87
        '
        'lblCta_Clabe_pensAlim
        '
        Me.lblCta_Clabe_pensAlim.AutoSize = True
        Me.lblCta_Clabe_pensAlim.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCta_Clabe_pensAlim.Location = New System.Drawing.Point(52, 286)
        Me.lblCta_Clabe_pensAlim.Name = "lblCta_Clabe_pensAlim"
        Me.lblCta_Clabe_pensAlim.Size = New System.Drawing.Size(49, 15)
        Me.lblCta_Clabe_pensAlim.TabIndex = 86
        Me.lblCta_Clabe_pensAlim.Text = "Cuenta:"
        '
        'chkInter
        '
        '
        '
        '
        Me.chkInter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkInter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkInter.Location = New System.Drawing.Point(107, 249)
        Me.chkInter.Name = "chkInter"
        Me.chkInter.Size = New System.Drawing.Size(29, 26)
        Me.chkInter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkInter.TabIndex = 89
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(32, 218)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 15)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "Porcentaje:"
        '
        'txtPorc
        '
        '
        '
        '
        Me.txtPorc.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtPorc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPorc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtPorc.Increment = 1.0R
        Me.txtPorc.Location = New System.Drawing.Point(107, 213)
        Me.txtPorc.Name = "txtPorc"
        Me.txtPorc.ShowUpDown = True
        Me.txtPorc.Size = New System.Drawing.Size(80, 20)
        Me.txtPorc.TabIndex = 90
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(193, 215)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 20)
        Me.Label4.TabIndex = 92
        Me.Label4.Text = "%"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(19, 252)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 15)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Interbancaria:"
        '
        'txtAPatPensAlim
        '
        '
        '
        '
        Me.txtAPatPensAlim.Border.Class = "TextBoxBorder"
        Me.txtAPatPensAlim.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAPatPensAlim.Location = New System.Drawing.Point(107, 76)
        Me.txtAPatPensAlim.Name = "txtAPatPensAlim"
        Me.txtAPatPensAlim.PreventEnterBeep = True
        Me.txtAPatPensAlim.Size = New System.Drawing.Size(290, 20)
        Me.txtAPatPensAlim.TabIndex = 95
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(28, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 15)
        Me.Label6.TabIndex = 94
        Me.Label6.Text = "Ap. Paterno:"
        '
        'txtApMatPensAlim
        '
        '
        '
        '
        Me.txtApMatPensAlim.Border.Class = "TextBoxBorder"
        Me.txtApMatPensAlim.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtApMatPensAlim.Location = New System.Drawing.Point(107, 111)
        Me.txtApMatPensAlim.Name = "txtApMatPensAlim"
        Me.txtApMatPensAlim.PreventEnterBeep = True
        Me.txtApMatPensAlim.Size = New System.Drawing.Size(290, 20)
        Me.txtApMatPensAlim.TabIndex = 97
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(25, 116)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 15)
        Me.Label7.TabIndex = 96
        Me.Label7.Text = "Ap. Materno:"
        '
        'txtNombresPensAlim
        '
        '
        '
        '
        Me.txtNombresPensAlim.Border.Class = "TextBoxBorder"
        Me.txtNombresPensAlim.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombresPensAlim.Location = New System.Drawing.Point(107, 148)
        Me.txtNombresPensAlim.Name = "txtNombresPensAlim"
        Me.txtNombresPensAlim.PreventEnterBeep = True
        Me.txtNombresPensAlim.Size = New System.Drawing.Size(290, 20)
        Me.txtNombresPensAlim.TabIndex = 99
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(32, 153)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 15)
        Me.Label8.TabIndex = 98
        Me.Label8.Text = "Nombre(s):"
        '
        'chkPAPorc
        '
        Me.chkPAPorc.AutoSize = True
        Me.chkPAPorc.Location = New System.Drawing.Point(107, 183)
        Me.chkPAPorc.Name = "chkPAPorc"
        Me.chkPAPorc.Size = New System.Drawing.Size(77, 17)
        Me.chkPAPorc.TabIndex = 100
        Me.chkPAPorc.Text = "Porcentaje"
        Me.chkPAPorc.UseVisualStyleBackColor = True
        '
        'chkPACFija
        '
        Me.chkPACFija.AutoSize = True
        Me.chkPACFija.Location = New System.Drawing.Point(197, 183)
        Me.chkPACFija.Name = "chkPACFija"
        Me.chkPACFija.Size = New System.Drawing.Size(52, 17)
        Me.chkPACFija.TabIndex = 101
        Me.chkPACFija.Text = "C.Fija"
        Me.chkPACFija.UseVisualStyleBackColor = True
        '
        'frmEditarPensAlim
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(418, 423)
        Me.Controls.Add(Me.chkPACFija)
        Me.Controls.Add(Me.chkPAPorc)
        Me.Controls.Add(Me.txtNombresPensAlim)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtApMatPensAlim)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtAPatPensAlim)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPorc)
        Me.Controls.Add(Me.chkInter)
        Me.Controls.Add(Me.txtNoCuenta)
        Me.Controls.Add(Me.lblCta_Clabe_pensAlim)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEditarPensAlim"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editar / Agregar Pensiones alimenticias"
        CType(Me.txtPorc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtNoCuenta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblCta_Clabe_pensAlim As System.Windows.Forms.Label
    Friend WithEvents chkInter As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPorc As DevComponents.Editors.DoubleInput
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAPatPensAlim As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtApMatPensAlim As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtNombresPensAlim As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkPAPorc As System.Windows.Forms.CheckBox
    Friend WithEvents chkPACFija As System.Windows.Forms.CheckBox
End Class
