<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClabe
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
        Dim VirtualKeyboardColorTable1 As DevComponents.DotNetBar.Keyboard.VirtualKeyboardColorTable = New DevComponents.DotNetBar.Keyboard.VirtualKeyboardColorTable()
        Dim FlatStyleRenderer1 As DevComponents.DotNetBar.Keyboard.FlatStyleRenderer = New DevComponents.DotNetBar.Keyboard.FlatStyleRenderer()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClabe))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ApuntarClabe = New DevComponents.DotNetBar.LabelX()
        Me.kbTeclado = New DevComponents.DotNetBar.Keyboard.KeyboardControl()
        Me.lblTitulo = New DevComponents.DotNetBar.LabelX()
        Me.txtConfirma = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ApuntaCOnfirma = New DevComponents.DotNetBar.LabelX()
        Me.txtCLABE = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCambiar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.lblFecha = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Black
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.ApuntarClabe)
        Me.Panel2.Controls.Add(Me.kbTeclado)
        Me.Panel2.Controls.Add(Me.lblTitulo)
        Me.Panel2.Controls.Add(Me.txtConfirma)
        Me.Panel2.Controls.Add(Me.ApuntaCOnfirma)
        Me.Panel2.Controls.Add(Me.txtCLABE)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.lblFecha)
        Me.Panel2.Controls.Add(Me.LabelX1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1010, 394)
        Me.Panel2.TabIndex = 58
        '
        'ApuntarClabe
        '
        Me.ApuntarClabe.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.ApuntarClabe.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ApuntarClabe.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApuntarClabe.ForeColor = System.Drawing.Color.White
        Me.ApuntarClabe.Location = New System.Drawing.Point(10, 65)
        Me.ApuntarClabe.Name = "ApuntarClabe"
        Me.ApuntarClabe.Size = New System.Drawing.Size(27, 43)
        Me.ApuntarClabe.TabIndex = 53
        Me.ApuntarClabe.Text = "►"
        Me.ApuntarClabe.TextAlignment = System.Drawing.StringAlignment.Center
        Me.ApuntarClabe.VerticalTextTopUp = False
        '
        'kbTeclado
        '
        VirtualKeyboardColorTable1.BackgroundColor = System.Drawing.Color.Black
        VirtualKeyboardColorTable1.DarkKeysColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(33, Byte), Integer))
        VirtualKeyboardColorTable1.DownKeysColor = System.Drawing.Color.White
        VirtualKeyboardColorTable1.DownTextColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        VirtualKeyboardColorTable1.KeysColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(47, Byte), Integer), CType(CType(55, Byte), Integer))
        VirtualKeyboardColorTable1.LightKeysColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(76, Byte), Integer))
        VirtualKeyboardColorTable1.PressedKeysColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(81, Byte), Integer))
        VirtualKeyboardColorTable1.TextColor = System.Drawing.Color.White
        VirtualKeyboardColorTable1.ToggleTextColor = System.Drawing.Color.Green
        VirtualKeyboardColorTable1.TopBarTextColor = System.Drawing.Color.White
        Me.kbTeclado.ColorTable = VirtualKeyboardColorTable1
        Me.kbTeclado.IsTopBarVisible = False
        Me.kbTeclado.Location = New System.Drawing.Point(663, 92)
        Me.kbTeclado.Name = "kbTeclado"
        FlatStyleRenderer1.ColorTable = VirtualKeyboardColorTable1
        FlatStyleRenderer1.ForceAntiAlias = False
        Me.kbTeclado.Renderer = FlatStyleRenderer1
        Me.kbTeclado.Size = New System.Drawing.Size(325, 282)
        Me.kbTeclado.TabIndex = 27
        Me.kbTeclado.Text = "KeyboardControl1"
        '
        'lblTitulo
        '
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblTitulo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblTitulo.Font = New System.Drawing.Font("Segoe UI", 26.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.Color.Gold
        Me.lblTitulo.Location = New System.Drawing.Point(663, 3)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(325, 83)
        Me.lblTitulo.TabIndex = 26
        Me.lblTitulo.Text = "Validar CLABE"
        Me.lblTitulo.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblTitulo.VerticalTextTopUp = False
        '
        'txtConfirma
        '
        '
        '
        '
        Me.txtConfirma.Border.Class = "TextBoxBorder"
        Me.txtConfirma.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtConfirma.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirma.Location = New System.Drawing.Point(51, 182)
        Me.txtConfirma.MaxLength = 18
        Me.txtConfirma.Multiline = True
        Me.txtConfirma.Name = "txtConfirma"
        Me.txtConfirma.PreventEnterBeep = True
        Me.txtConfirma.Size = New System.Drawing.Size(583, 48)
        Me.txtConfirma.TabIndex = 56
        Me.txtConfirma.Text = "123456789123456789"
        Me.txtConfirma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ApuntaCOnfirma
        '
        Me.ApuntaCOnfirma.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.ApuntaCOnfirma.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ApuntaCOnfirma.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApuntaCOnfirma.ForeColor = System.Drawing.Color.White
        Me.ApuntaCOnfirma.Location = New System.Drawing.Point(10, 185)
        Me.ApuntaCOnfirma.Name = "ApuntaCOnfirma"
        Me.ApuntaCOnfirma.Size = New System.Drawing.Size(27, 43)
        Me.ApuntaCOnfirma.TabIndex = 54
        Me.ApuntaCOnfirma.Text = "►"
        Me.ApuntaCOnfirma.TextAlignment = System.Drawing.StringAlignment.Center
        Me.ApuntaCOnfirma.VerticalTextTopUp = False
        Me.ApuntaCOnfirma.Visible = False
        '
        'txtCLABE
        '
        '
        '
        '
        Me.txtCLABE.Border.Class = "TextBoxBorder"
        Me.txtCLABE.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCLABE.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCLABE.Location = New System.Drawing.Point(51, 65)
        Me.txtCLABE.MaxLength = 18
        Me.txtCLABE.Multiline = True
        Me.txtCLABE.Name = "txtCLABE"
        Me.txtCLABE.PreventEnterBeep = True
        Me.txtCLABE.Size = New System.Drawing.Size(583, 48)
        Me.txtCLABE.TabIndex = 55
        Me.txtCLABE.Text = "123456789123456789"
        Me.txtCLABE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.btnAceptar)
        Me.Panel1.Controls.Add(Me.btnCambiar)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Location = New System.Drawing.Point(150, 231)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(393, 131)
        Me.Panel1.TabIndex = 52
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.BackColor = System.Drawing.Color.DarkCyan
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.btnAceptar.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.ImageTextSpacing = 7
        Me.btnAceptar.Location = New System.Drawing.Point(5, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(385, 54)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextColor = System.Drawing.Color.White
        '
        'btnCambiar
        '
        Me.btnCambiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCambiar.BackColor = System.Drawing.Color.CornflowerBlue
        Me.btnCambiar.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.btnCambiar.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCambiar.ImageTextSpacing = 7
        Me.btnCambiar.Location = New System.Drawing.Point(5, 68)
        Me.btnCambiar.Name = "btnCambiar"
        Me.btnCambiar.Size = New System.Drawing.Size(187, 54)
        Me.btnCambiar.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013
        Me.btnCambiar.TabIndex = 9
        Me.btnCambiar.Text = "Limpiar"
        Me.btnCambiar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        Me.btnCambiar.TextColor = System.Drawing.Color.White
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.BackColor = System.Drawing.Color.DarkRed
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.btnCancelar.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ImageTextSpacing = 7
        Me.btnCancelar.Location = New System.Drawing.Point(198, 68)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(192, 54)
        Me.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        Me.btnCancelar.TextColor = System.Drawing.Color.White
        '
        'lblFecha
        '
        Me.lblFecha.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblFecha.Font = New System.Drawing.Font("Segoe UI Light", 20.75!)
        Me.lblFecha.ForeColor = System.Drawing.Color.White
        Me.lblFecha.Location = New System.Drawing.Point(36, 14)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(621, 43)
        Me.lblFecha.TabIndex = 50
        Me.lblFecha.Text = "Ingresa tu número de CLABE"
        Me.lblFecha.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblFecha.VerticalTextTopUp = False
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Segoe UI Light", 20.75!)
        Me.LabelX1.ForeColor = System.Drawing.Color.White
        Me.LabelX1.Location = New System.Drawing.Point(36, 131)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(621, 43)
        Me.LabelX1.TabIndex = 51
        Me.LabelX1.Text = "Confirma tu número de CLABE"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Center
        Me.LabelX1.VerticalTextTopUp = False
        '
        'frmClabe
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ClientSize = New System.Drawing.Size(1010, 394)
        Me.Controls.Add(Me.Panel2)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmClabe"
        Me.Text = "Validar CLABE"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ApuntarClabe As DevComponents.DotNetBar.LabelX
    Friend WithEvents kbTeclado As DevComponents.DotNetBar.Keyboard.KeyboardControl
    Friend WithEvents lblTitulo As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtConfirma As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ApuntaCOnfirma As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtCLABE As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCambiar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblFecha As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
End Class
