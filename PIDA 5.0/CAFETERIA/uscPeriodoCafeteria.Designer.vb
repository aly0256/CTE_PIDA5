<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class uscPeriodoCafeteria
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
        Me.lblFecha = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.lblDia = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.btnDesayuno = New System.Windows.Forms.Button()
        Me.btnComida = New System.Windows.Forms.Button()
        Me.btnCena = New System.Windows.Forms.Button()
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        Me.pctDesayuno = New System.Windows.Forms.PictureBox()
        Me.pctComida = New System.Windows.Forms.PictureBox()
        Me.pctCena = New System.Windows.Forms.PictureBox()
        CType(Me.pctDesayuno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctComida, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pctCena, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblFecha
        '
        '
        '
        '
        Me.lblFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblFecha.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.lblFecha.Location = New System.Drawing.Point(251, 8)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(140, 18)
        Me.lblFecha.TabIndex = 0
        Me.lblFecha.Text = "<b><font size=""+1""><b>01/02/2016" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "</b></font></b>"
        '
        'lblDia
        '
        '
        '
        '
        Me.lblDia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDia.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.lblDia.Location = New System.Drawing.Point(20, 8)
        Me.lblDia.Name = "lblDia"
        Me.lblDia.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDia.Size = New System.Drawing.Size(140, 26)
        Me.lblDia.TabIndex = 1
        Me.lblDia.Text = "<b><font size=""+6" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & """><b>LUNES</b></font></b>"
        '
        'btnDesayuno
        '
        Me.btnDesayuno.BackColor = System.Drawing.Color.LightGreen
        Me.btnDesayuno.Location = New System.Drawing.Point(20, 143)
        Me.btnDesayuno.Name = "btnDesayuno"
        Me.btnDesayuno.Size = New System.Drawing.Size(120, 23)
        Me.btnDesayuno.TabIndex = 2
        Me.btnDesayuno.Text = "Desayuno"
        Me.btnDesayuno.UseVisualStyleBackColor = False
        '
        'btnComida
        '
        Me.btnComida.BackColor = System.Drawing.Color.LightBlue
        Me.btnComida.Location = New System.Drawing.Point(146, 143)
        Me.btnComida.Name = "btnComida"
        Me.btnComida.Size = New System.Drawing.Size(120, 23)
        Me.btnComida.TabIndex = 3
        Me.btnComida.Text = "Comida"
        Me.btnComida.UseVisualStyleBackColor = False
        '
        'btnCena
        '
        Me.btnCena.BackColor = System.Drawing.Color.Orchid
        Me.btnCena.Location = New System.Drawing.Point(271, 143)
        Me.btnCena.Name = "btnCena"
        Me.btnCena.Size = New System.Drawing.Size(120, 23)
        Me.btnCena.TabIndex = 4
        Me.btnCena.Text = "Cena"
        Me.btnCena.UseVisualStyleBackColor = False
        '
        'SuperTooltip1
        '
        Me.SuperTooltip1.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("", "", "", Nothing, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray)
        Me.SuperTooltip1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'pctDesayuno
        '
        Me.pctDesayuno.Location = New System.Drawing.Point(20, 37)
        Me.pctDesayuno.Name = "pctDesayuno"
        Me.pctDesayuno.Size = New System.Drawing.Size(120, 120)
        Me.pctDesayuno.TabIndex = 9
        Me.pctDesayuno.TabStop = False
        '
        'pctComida
        '
        Me.pctComida.Location = New System.Drawing.Point(146, 37)
        Me.pctComida.Name = "pctComida"
        Me.pctComida.Size = New System.Drawing.Size(120, 120)
        Me.pctComida.TabIndex = 10
        Me.pctComida.TabStop = False
        '
        'pctCena
        '
        Me.pctCena.Location = New System.Drawing.Point(272, 40)
        Me.pctCena.Name = "pctCena"
        Me.pctCena.Size = New System.Drawing.Size(120, 120)
        Me.pctCena.TabIndex = 11
        Me.pctCena.TabStop = False
        '
        'uscPeriodoCafeteria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImage = Global.PIDA.My.Resources.Resources.fondo_cafe_cinco
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Controls.Add(Me.btnCena)
        Me.Controls.Add(Me.btnComida)
        Me.Controls.Add(Me.btnDesayuno)
        Me.Controls.Add(Me.pctCena)
        Me.Controls.Add(Me.pctComida)
        Me.Controls.Add(Me.pctDesayuno)
        Me.Controls.Add(Me.lblDia)
        Me.Controls.Add(Me.lblFecha)
        Me.DoubleBuffered = True
        Me.Name = "uscPeriodoCafeteria"
        Me.Size = New System.Drawing.Size(411, 176)
        CType(Me.pctDesayuno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctComida, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pctCena, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblFecha As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents lblDia As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents btnDesayuno As System.Windows.Forms.Button
    Friend WithEvents btnComida As System.Windows.Forms.Button
    Friend WithEvents btnCena As System.Windows.Forms.Button
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents pctDesayuno As System.Windows.Forms.PictureBox
    Friend WithEvents pctComida As System.Windows.Forms.PictureBox
    Friend WithEvents pctCena As System.Windows.Forms.PictureBox

End Class
