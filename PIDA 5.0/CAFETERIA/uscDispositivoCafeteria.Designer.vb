<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uscDispositivoCafeteria
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.lblDispositivo = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.lblVersion = New DevComponents.DotNetBar.LabelX()
        Me.pnlEstatus = New System.Windows.Forms.Panel()
        Me.lblDescripcion = New DevComponents.DotNetBar.LabelX()
        Me.btnSincronizar = New DevComponents.DotNetBar.ButtonX()
        Me.btnActualizar = New DevComponents.DotNetBar.ButtonX()
        Me.btnReiniciar = New DevComponents.DotNetBar.ButtonX()
        Me.btnBloquear = New DevComponents.DotNetBar.ButtonX()
        Me.tmrDispositivo = New System.Windows.Forms.Timer(Me.components)
        Me.btnScreenshot = New DevComponents.DotNetBar.ButtonX()
        Me.pnlEstatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblDispositivo
        '
        '
        '
        '
        Me.lblDispositivo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDispositivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDispositivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDispositivo.ForeColor = System.Drawing.Color.White
        Me.lblDispositivo.Location = New System.Drawing.Point(0, 0)
        Me.lblDispositivo.Name = "lblDispositivo"
        Me.lblDispositivo.Size = New System.Drawing.Size(38, 194)
        Me.lblDispositivo.TabIndex = 3
        Me.lblDispositivo.Text = "MXJZVDB01"
        Me.lblDispositivo.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblDispositivo.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(3, 34)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(79, 16)
        Me.LabelX4.TabIndex = 5
        Me.LabelX4.Text = "<b><font size=""+1"">Versión:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "</font></b>"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'lblVersion
        '
        '
        '
        '
        Me.lblVersion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblVersion.Location = New System.Drawing.Point(4, 56)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(79, 14)
        Me.lblVersion.TabIndex = 6
        Me.lblVersion.Text = "1.1.10.100"
        Me.lblVersion.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'pnlEstatus
        '
        Me.pnlEstatus.BackColor = System.Drawing.Color.LimeGreen
        Me.pnlEstatus.Controls.Add(Me.lblDispositivo)
        Me.pnlEstatus.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlEstatus.Location = New System.Drawing.Point(247, 0)
        Me.pnlEstatus.Name = "pnlEstatus"
        Me.pnlEstatus.Size = New System.Drawing.Size(38, 194)
        Me.pnlEstatus.TabIndex = 7
        '
        'lblDescripcion
        '
        '
        '
        '
        Me.lblDescripcion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.Location = New System.Drawing.Point(3, 3)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(238, 25)
        Me.lblDescripcion.TabIndex = 8
        Me.lblDescripcion.Text = "<font size=""+5"">Cafetería Sur J1</font>"
        Me.lblDescripcion.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'btnSincronizar
        '
        Me.btnSincronizar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSincronizar.BackgroundImage = Global.PIDA.My.Resources.Resources._1469827778_Sync
        Me.btnSincronizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSincronizar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSincronizar.Image = Global.PIDA.My.Resources.Resources._1469827778_Sync
        Me.btnSincronizar.ImageFixedSize = New System.Drawing.Size(20, 20)
        Me.btnSincronizar.Location = New System.Drawing.Point(4, 129)
        Me.btnSincronizar.Name = "btnSincronizar"
        Me.btnSincronizar.Size = New System.Drawing.Size(96, 28)
        Me.btnSincronizar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSincronizar.TabIndex = 9
        Me.btnSincronizar.Text = "Sincronizar"
        Me.btnSincronizar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'btnActualizar
        '
        Me.btnActualizar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnActualizar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnActualizar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizar.Image = Global.PIDA.My.Resources.Resources.refresh32
        Me.btnActualizar.ImageFixedSize = New System.Drawing.Size(20, 20)
        Me.btnActualizar.Location = New System.Drawing.Point(4, 76)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(96, 47)
        Me.btnActualizar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnActualizar.TabIndex = 10
        Me.btnActualizar.Text = "Sincronizar TODO"
        Me.btnActualizar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'btnReiniciar
        '
        Me.btnReiniciar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReiniciar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnReiniciar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReiniciar.Image = Global.PIDA.My.Resources.Resources._1472007528_button_blue_repeat
        Me.btnReiniciar.ImageFixedSize = New System.Drawing.Size(20, 20)
        Me.btnReiniciar.Location = New System.Drawing.Point(38, 163)
        Me.btnReiniciar.Name = "btnReiniciar"
        Me.btnReiniciar.Size = New System.Drawing.Size(28, 28)
        Me.btnReiniciar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReiniciar.TabIndex = 11
        Me.btnReiniciar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        Me.btnReiniciar.Tooltip = "Reiniciar  "
        '
        'btnBloquear
        '
        Me.btnBloquear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBloquear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBloquear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBloquear.Image = Global.PIDA.My.Resources.Resources._1472011640_Abort
        Me.btnBloquear.ImageFixedSize = New System.Drawing.Size(20, 20)
        Me.btnBloquear.Location = New System.Drawing.Point(4, 163)
        Me.btnBloquear.Name = "btnBloquear"
        Me.btnBloquear.Size = New System.Drawing.Size(28, 28)
        Me.btnBloquear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBloquear.TabIndex = 12
        Me.btnBloquear.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        Me.btnBloquear.Tooltip = "Bloquear"
        '
        'tmrDispositivo
        '
        Me.tmrDispositivo.Interval = 1000
        '
        'btnScreenshot
        '
        Me.btnScreenshot.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnScreenshot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnScreenshot.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnScreenshot.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnScreenshot.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnScreenshot.Location = New System.Drawing.Point(72, 163)
        Me.btnScreenshot.Name = "btnScreenshot"
        Me.btnScreenshot.Size = New System.Drawing.Size(28, 28)
        Me.btnScreenshot.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnScreenshot.TabIndex = 13
        Me.btnScreenshot.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        Me.btnScreenshot.Tooltip = "Screenshot"
        '
        'uscDispositivoCafeteria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.btnScreenshot)
        Me.Controls.Add(Me.btnBloquear)
        Me.Controls.Add(Me.btnReiniciar)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.btnSincronizar)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.pnlEstatus)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.LabelX4)
        Me.DoubleBuffered = True
        Me.Name = "uscDispositivoCafeteria"
        Me.Size = New System.Drawing.Size(285, 194)
        Me.pnlEstatus.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblDispositivo As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblVersion As DevComponents.DotNetBar.LabelX
    Friend WithEvents pnlEstatus As System.Windows.Forms.Panel
    Friend WithEvents lblDescripcion As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnSincronizar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnActualizar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReiniciar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBloquear As DevComponents.DotNetBar.ButtonX
    Friend WithEvents tmrDispositivo As System.Windows.Forms.Timer
    Friend WithEvents btnScreenshot As DevComponents.DotNetBar.ButtonX

End Class
