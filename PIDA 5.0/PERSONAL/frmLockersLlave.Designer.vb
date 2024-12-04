<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLockersLlave
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
        Me.picboxLocker = New System.Windows.Forms.PictureBox()
        Me.lbClave = New System.Windows.Forms.Label()
        Me.txtClave = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lbInfo = New System.Windows.Forms.Label()
        Me.txtNoCandado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lbCandado = New System.Windows.Forms.Label()
        Me.lbLlave = New System.Windows.Forms.Label()
        Me.txtLlave = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.gbLockers2 = New System.Windows.Forms.GroupBox()
        Me.btnOk = New DevComponents.DotNetBar.ButtonX()
        Me.panelLockers1 = New System.Windows.Forms.Panel()
        Me.panelLockers2 = New System.Windows.Forms.Panel()
        Me.btnCancelarAsignar = New DevComponents.DotNetBar.ButtonX()
        CType(Me.picboxLocker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbLockers2.SuspendLayout()
        Me.panelLockers1.SuspendLayout()
        Me.panelLockers2.SuspendLayout()
        Me.SuspendLayout()
        '
        'picboxLocker
        '
        Me.picboxLocker.Image = Global.PIDA.My.Resources.Resources.candado
        Me.picboxLocker.Location = New System.Drawing.Point(3, 3)
        Me.picboxLocker.Name = "picboxLocker"
        Me.picboxLocker.Size = New System.Drawing.Size(84, 87)
        Me.picboxLocker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picboxLocker.TabIndex = 59
        Me.picboxLocker.TabStop = False
        '
        'lbClave
        '
        Me.lbClave.AutoSize = True
        Me.lbClave.Location = New System.Drawing.Point(93, 3)
        Me.lbClave.Name = "lbClave"
        Me.lbClave.Size = New System.Drawing.Size(34, 13)
        Me.lbClave.TabIndex = 69
        Me.lbClave.Text = "Clave"
        '
        'txtClave
        '
        '
        '
        '
        Me.txtClave.Border.Class = "TextBoxBorder"
        Me.txtClave.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtClave.Location = New System.Drawing.Point(93, 19)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.PreventEnterBeep = True
        Me.txtClave.Size = New System.Drawing.Size(196, 20)
        Me.txtClave.TabIndex = 68
        '
        'lbInfo
        '
        Me.lbInfo.AutoSize = True
        Me.lbInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbInfo.Location = New System.Drawing.Point(93, 50)
        Me.lbInfo.Name = "lbInfo"
        Me.lbInfo.Size = New System.Drawing.Size(211, 39)
        Me.lbInfo.TabIndex = 70
        Me.lbInfo.Text = "*Para tener acceso a las llaves/contraseñas" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " de los lockers es necesario volver " & _
    "a" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " autenticarse con su clave de usuario."
        '
        'txtNoCandado
        '
        '
        '
        '
        Me.txtNoCandado.Border.Class = "TextBoxBorder"
        Me.txtNoCandado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNoCandado.Enabled = False
        Me.txtNoCandado.Location = New System.Drawing.Point(90, 9)
        Me.txtNoCandado.Name = "txtNoCandado"
        Me.txtNoCandado.PreventEnterBeep = True
        Me.txtNoCandado.Size = New System.Drawing.Size(192, 20)
        Me.txtNoCandado.TabIndex = 71
        '
        'lbCandado
        '
        Me.lbCandado.AutoSize = True
        Me.lbCandado.Location = New System.Drawing.Point(14, 11)
        Me.lbCandado.Name = "lbCandado"
        Me.lbCandado.Size = New System.Drawing.Size(70, 13)
        Me.lbCandado.TabIndex = 72
        Me.lbCandado.Text = "No. Candado"
        '
        'lbLlave
        '
        Me.lbLlave.AutoSize = True
        Me.lbLlave.Location = New System.Drawing.Point(14, 43)
        Me.lbLlave.Name = "lbLlave"
        Me.lbLlave.Size = New System.Drawing.Size(61, 26)
        Me.lbLlave.TabIndex = 73
        Me.lbLlave.Text = "Llave/" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Contraseña"
        '
        'txtLlave
        '
        '
        '
        '
        Me.txtLlave.Border.Class = "TextBoxBorder"
        Me.txtLlave.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtLlave.Enabled = False
        Me.txtLlave.Location = New System.Drawing.Point(90, 49)
        Me.txtLlave.Name = "txtLlave"
        Me.txtLlave.PreventEnterBeep = True
        Me.txtLlave.Size = New System.Drawing.Size(192, 20)
        Me.txtLlave.TabIndex = 74
        '
        'gbLockers2
        '
        Me.gbLockers2.BackColor = System.Drawing.Color.Transparent
        Me.gbLockers2.Controls.Add(Me.btnCancelarAsignar)
        Me.gbLockers2.Controls.Add(Me.btnOk)
        Me.gbLockers2.Location = New System.Drawing.Point(162, 105)
        Me.gbLockers2.Name = "gbLockers2"
        Me.gbLockers2.Size = New System.Drawing.Size(172, 47)
        Me.gbLockers2.TabIndex = 152
        Me.gbLockers2.TabStop = False
        '
        'btnOk
        '
        Me.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnOk.CausesValidation = False
        Me.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Location = New System.Drawing.Point(7, 13)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(78, 25)
        Me.btnOk.TabIndex = 11
        Me.btnOk.Text = "Aceptar"
        '
        'panelLockers1
        '
        Me.panelLockers1.Controls.Add(Me.lbCandado)
        Me.panelLockers1.Controls.Add(Me.txtNoCandado)
        Me.panelLockers1.Controls.Add(Me.lbLlave)
        Me.panelLockers1.Controls.Add(Me.txtLlave)
        Me.panelLockers1.Location = New System.Drawing.Point(12, 12)
        Me.panelLockers1.Name = "panelLockers1"
        Me.panelLockers1.Size = New System.Drawing.Size(315, 85)
        Me.panelLockers1.TabIndex = 153
        '
        'panelLockers2
        '
        Me.panelLockers2.Controls.Add(Me.picboxLocker)
        Me.panelLockers2.Controls.Add(Me.txtClave)
        Me.panelLockers2.Controls.Add(Me.lbClave)
        Me.panelLockers2.Controls.Add(Me.lbInfo)
        Me.panelLockers2.Location = New System.Drawing.Point(7, 5)
        Me.panelLockers2.Name = "panelLockers2"
        Me.panelLockers2.Size = New System.Drawing.Size(333, 102)
        Me.panelLockers2.TabIndex = 154
        '
        'btnCancelarAsignar
        '
        Me.btnCancelarAsignar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelarAsignar.CausesValidation = False
        Me.btnCancelarAsignar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelarAsignar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelarAsignar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarAsignar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelarAsignar.Location = New System.Drawing.Point(88, 13)
        Me.btnCancelarAsignar.Name = "btnCancelarAsignar"
        Me.btnCancelarAsignar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelarAsignar.TabIndex = 13
        Me.btnCancelarAsignar.Text = "Cancelar"
        '
        'frmLockersLlave
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 158)
        Me.Controls.Add(Me.panelLockers2)
        Me.Controls.Add(Me.panelLockers1)
        Me.Controls.Add(Me.gbLockers2)
        Me.Name = "frmLockersLlave"
        Me.Text = "Contraseña de Lockers"
        CType(Me.picboxLocker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbLockers2.ResumeLayout(False)
        Me.panelLockers1.ResumeLayout(False)
        Me.panelLockers1.PerformLayout()
        Me.panelLockers2.ResumeLayout(False)
        Me.panelLockers2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picboxLocker As System.Windows.Forms.PictureBox
    Friend WithEvents lbClave As System.Windows.Forms.Label
    Friend WithEvents txtClave As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lbInfo As System.Windows.Forms.Label
    Friend WithEvents txtNoCandado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lbCandado As System.Windows.Forms.Label
    Friend WithEvents lbLlave As System.Windows.Forms.Label
    Friend WithEvents txtLlave As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents gbLockers2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnOk As DevComponents.DotNetBar.ButtonX
    Friend WithEvents panelLockers1 As System.Windows.Forms.Panel
    Friend WithEvents panelLockers2 As System.Windows.Forms.Panel
    Friend WithEvents btnCancelarAsignar As DevComponents.DotNetBar.ButtonX
End Class
