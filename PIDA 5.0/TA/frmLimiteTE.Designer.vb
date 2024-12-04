<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLimiteTE
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
        Me.TimeSelector1 = New DevComponents.Editors.DateTimeAdv.TimeSelector()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TimeSelector1
        '
        Me.TimeSelector1.AutoSize = True
        '
        '
        '
        Me.TimeSelector1.BackgroundStyle.Class = "MonthCalendarAdv"
        Me.TimeSelector1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TimeSelector1.ClearText = "00:00"
        Me.TimeSelector1.ContainerControlProcessDialogKey = True
        Me.TimeSelector1.HourText = "Horas"
        Me.TimeSelector1.Location = New System.Drawing.Point(1, 12)
        Me.TimeSelector1.MinuteText = "Minutos"
        Me.TimeSelector1.Name = "TimeSelector1"
        Me.TimeSelector1.OkButtonVisible = False
        Me.TimeSelector1.Size = New System.Drawing.Size(250, 179)
        Me.TimeSelector1.TimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H
        Me.TimeSelector1.TimeFormat12H = "hh:mm"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnAceptar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 190)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(251, 43)
        Me.Panel1.TabIndex = 1
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.Location = New System.Drawing.Point(44, 9)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCancelar.Location = New System.Drawing.Point(128, 9)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "Cancelar"
        '
        'frmLimiteTE
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(251, 233)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TimeSelector1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmLimiteTE"
        Me.Text = "TiempExtra"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TimeSelector1 As DevComponents.Editors.DateTimeAdv.TimeSelector
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
End Class
