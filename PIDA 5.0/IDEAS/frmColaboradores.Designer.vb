<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmColaboradores
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
        Me.ListBusqueda = New DevComponents.DotNetBar.ListBoxAdv()
        Me.ListAgregar = New DevComponents.DotNetBar.ListBoxAdv()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX3 = New DevComponents.DotNetBar.ButtonX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtBusqueda = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.ReflectionLabel2 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListBusqueda
        '
        Me.ListBusqueda.AutoScroll = True
        '
        '
        '
        Me.ListBusqueda.BackgroundStyle.Class = "ListBoxAdv"
        Me.ListBusqueda.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ListBusqueda.ContainerControlProcessDialogKey = True
        Me.ListBusqueda.DragDropSupport = True
        Me.ListBusqueda.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ListBusqueda.Location = New System.Drawing.Point(12, 89)
        Me.ListBusqueda.Name = "ListBusqueda"
        Me.ListBusqueda.Size = New System.Drawing.Size(262, 260)
        Me.ListBusqueda.TabIndex = 0
        Me.ListBusqueda.Text = "ListBoxAdv1"
        '
        'ListAgregar
        '
        Me.ListAgregar.AutoScroll = True
        '
        '
        '
        Me.ListAgregar.BackgroundStyle.Class = "ListBoxAdv"
        Me.ListAgregar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ListAgregar.ContainerControlProcessDialogKey = True
        Me.ListAgregar.DragDropSupport = True
        Me.ListAgregar.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ListAgregar.Location = New System.Drawing.Point(370, 89)
        Me.ListAgregar.Name = "ListAgregar"
        Me.ListAgregar.Size = New System.Drawing.Size(254, 260)
        Me.ListAgregar.TabIndex = 1
        Me.ListAgregar.Text = "ListBoxAdv2"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.CausesValidation = False
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX2.Image = Global.PIDA.My.Resources.Resources.right
        Me.ButtonX2.Location = New System.Drawing.Point(293, 118)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(58, 23)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 99
        Me.ButtonX2.Tooltip = "Buscar"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.CausesValidation = False
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX1.Image = Global.PIDA.My.Resources.Resources.left
        Me.ButtonX1.Location = New System.Drawing.Point(293, 147)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(58, 23)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 98
        Me.ButtonX1.Tooltip = "Buscar"
        '
        'ButtonX3
        '
        Me.ButtonX3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX3.CausesValidation = False
        Me.ButtonX3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX3.Image = Global.PIDA.My.Resources.Resources.TrashBlue24
        Me.ButtonX3.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.ButtonX3.Location = New System.Drawing.Point(293, 196)
        Me.ButtonX3.Name = "ButtonX3"
        Me.ButtonX3.Size = New System.Drawing.Size(58, 23)
        Me.ButtonX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX3.TabIndex = 100
        Me.ButtonX3.Tooltip = "Quitar"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(4, 3)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(246, 40)
        Me.ReflectionLabel1.TabIndex = 101
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>COLABORADORES</b></font>"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Users32
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 102
        Me.PictureBox1.TabStop = False
        '
        'txtBusqueda
        '
        Me.txtBusqueda.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtBusqueda.Border.Class = "TextBoxBorder"
        Me.txtBusqueda.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBusqueda.DisabledBackColor = System.Drawing.Color.White
        Me.txtBusqueda.ForeColor = System.Drawing.Color.Black
        Me.txtBusqueda.Location = New System.Drawing.Point(12, 66)
        Me.txtBusqueda.Margin = New System.Windows.Forms.Padding(0)
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.PreventEnterBeep = True
        Me.txtBusqueda.Size = New System.Drawing.Size(262, 20)
        Me.txtBusqueda.TabIndex = 103
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Controls.Add(Me.btnAceptar)
        Me.GroupBox1.Location = New System.Drawing.Point(231, 355)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(178, 47)
        Me.GroupBox1.TabIndex = 104
        Me.GroupBox1.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelar.Location = New System.Drawing.Point(88, 16)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 52
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.Location = New System.Drawing.Point(6, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.TabIndex = 41
        Me.btnAceptar.Text = "Aceptar"
        '
        'ReflectionLabel2
        '
        '
        '
        '
        Me.ReflectionLabel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel2.Location = New System.Drawing.Point(59, 12)
        Me.ReflectionLabel2.Name = "ReflectionLabel2"
        Me.ReflectionLabel2.Size = New System.Drawing.Size(455, 40)
        Me.ReflectionLabel2.TabIndex = 105
        Me.ReflectionLabel2.Text = "<font color=""#1F497D""><b>COLABORADORES</b></font>"
        '
        'frmColaboradores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 411)
        Me.Controls.Add(Me.ReflectionLabel2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtBusqueda)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ButtonX3)
        Me.Controls.Add(Me.ButtonX2)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.ListAgregar)
        Me.Controls.Add(Me.ListBusqueda)
        Me.Name = "frmColaboradores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Colaboradores"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBusqueda As DevComponents.DotNetBar.ListBoxAdv
    Friend WithEvents ListAgregar As DevComponents.DotNetBar.ListBoxAdv
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents txtBusqueda As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ReflectionLabel2 As DevComponents.DotNetBar.Controls.ReflectionLabel
End Class
