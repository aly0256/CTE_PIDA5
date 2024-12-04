<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmElegirPlatillos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmElegirPlatillos))
        Me.flwPeriodosDisponibles = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtBuscar = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'flwPeriodosDisponibles
        '
        Me.flwPeriodosDisponibles.AutoScroll = True
        Me.flwPeriodosDisponibles.BackColor = System.Drawing.Color.Transparent
        Me.flwPeriodosDisponibles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flwPeriodosDisponibles.Location = New System.Drawing.Point(0, 60)
        Me.flwPeriodosDisponibles.Name = "flwPeriodosDisponibles"
        Me.flwPeriodosDisponibles.Size = New System.Drawing.Size(784, 501)
        Me.flwPeriodosDisponibles.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = Global.PIDA.My.Resources.Resources.test_fon_tres
        Me.Panel1.Controls.Add(Me.txtBuscar)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.ReflectionLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(784, 60)
        Me.Panel1.TabIndex = 4
        '
        'txtBuscar
        '
        '
        '
        '
        Me.txtBuscar.Border.Class = "TextBoxBorder"
        Me.txtBuscar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(524, 28)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.PreventEnterBeep = True
        Me.txtBuscar.Size = New System.Drawing.Size(257, 26)
        Me.txtBuscar.TabIndex = 1
        Me.txtBuscar.WatermarkBehavior = DevComponents.DotNetBar.eWatermarkBehavior.HideNonEmpty
        Me.txtBuscar.WatermarkText = "Buscar..."
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.PIDA.My.Resources.Resources.Food_Dome_128
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(17, 8)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(46, 40)
        Me.PictureBox1.TabIndex = 82
        Me.PictureBox1.TabStop = False
        '
        'ReflectionLabel1
        '
        Me.ReflectionLabel1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(69, 8)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(429, 40)
        Me.ReflectionLabel1.TabIndex = 0
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>ELEGIR PLATILLO</b></font>"
        '
        'frmElegirPlatillos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.ControlBox = False
        Me.Controls.Add(Me.flwPeriodosDisponibles)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmElegirPlatillos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Elegir platillos"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents flwPeriodosDisponibles As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txtBuscar As DevComponents.DotNetBar.Controls.TextBoxX
End Class
