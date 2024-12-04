<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uscPlatillo
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
        Me.lblNombrePLatillo = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.pcbImagenPlatillo = New System.Windows.Forms.PictureBox()
        Me.btnAgregarQuitar = New DevComponents.DotNetBar.ButtonX()
        CType(Me.pcbImagenPlatillo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblNombrePLatillo
        '
        Me.lblNombrePLatillo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblNombrePLatillo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblNombrePLatillo.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.lblNombrePLatillo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.lblNombrePLatillo.Location = New System.Drawing.Point(8, 170)
        Me.lblNombrePLatillo.Name = "lblNombrePLatillo"
        Me.lblNombrePLatillo.Size = New System.Drawing.Size(156, 28)
        Me.lblNombrePLatillo.TabIndex = 1
        Me.lblNombrePLatillo.Text = "<b><font size=""+6""><b>Nombre Platillo</b></font></b>"
        '
        'pcbImagenPlatillo
        '
        Me.pcbImagenPlatillo.BackColor = System.Drawing.Color.Transparent
        Me.pcbImagenPlatillo.BackgroundImage = Global.PIDA.My.Resources.Resources._1472009258_FAQ1
        Me.pcbImagenPlatillo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pcbImagenPlatillo.Location = New System.Drawing.Point(8, 11)
        Me.pcbImagenPlatillo.Name = "pcbImagenPlatillo"
        Me.pcbImagenPlatillo.Size = New System.Drawing.Size(156, 153)
        Me.pcbImagenPlatillo.TabIndex = 2
        Me.pcbImagenPlatillo.TabStop = False
        '
        'btnAgregarQuitar
        '
        Me.btnAgregarQuitar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAgregarQuitar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAgregarQuitar.Image = Global.PIDA.My.Resources.Resources.Delete24
        Me.btnAgregarQuitar.Location = New System.Drawing.Point(137, 134)
        Me.btnAgregarQuitar.Name = "btnAgregarQuitar"
        Me.btnAgregarQuitar.Size = New System.Drawing.Size(30, 30)
        Me.btnAgregarQuitar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAgregarQuitar.TabIndex = 3
        '
        'uscPlatillo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImage = Global.PIDA.My.Resources.Resources.fondo_tres
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.btnAgregarQuitar)
        Me.Controls.Add(Me.pcbImagenPlatillo)
        Me.Controls.Add(Me.lblNombrePLatillo)
        Me.DoubleBuffered = True
        Me.Name = "uscPlatillo"
        Me.Size = New System.Drawing.Size(170, 210)
        CType(Me.pcbImagenPlatillo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblNombrePLatillo As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents pcbImagenPlatillo As System.Windows.Forms.PictureBox
    Public WithEvents btnAgregarQuitar As DevComponents.DotNetBar.ButtonX

End Class
