<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenNomina
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrdenNomina))
        Me.cbCampos = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.NombreCampo = New DevComponents.AdvTree.ColumnHeader()
        Me.CodCampo = New DevComponents.AdvTree.ColumnHeader()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.sbOrden = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnLimpiar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAgregar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.lstOrden = New System.Windows.Forms.ListBox()
        Me.btnBajar = New DevComponents.DotNetBar.ButtonX()
        Me.btnSubir = New DevComponents.DotNetBar.ButtonX()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ReflectionLabel2 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbCampos
        '
        Me.cbCampos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cbCampos.BackgroundStyle.Class = "TextBoxBorder"
        Me.cbCampos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbCampos.ButtonDropDown.Visible = True
        Me.cbCampos.Columns.Add(Me.NombreCampo)
        Me.cbCampos.Columns.Add(Me.CodCampo)
        Me.cbCampos.DisplayMembers = "nombre,cod_campo"
        Me.cbCampos.Dock = System.Windows.Forms.DockStyle.Left
        Me.cbCampos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cbCampos.Location = New System.Drawing.Point(47, 0)
        Me.cbCampos.Name = "cbCampos"
        Me.cbCampos.Size = New System.Drawing.Size(355, 20)
        Me.cbCampos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbCampos.TabIndex = 5
        Me.cbCampos.ValueMember = "cod_campo"
        '
        'NombreCampo
        '
        Me.NombreCampo.DataFieldName = "nombre"
        Me.NombreCampo.Name = "NombreCampo"
        Me.NombreCampo.StretchToFill = True
        Me.NombreCampo.Text = "Campo"
        Me.NombreCampo.Width.Absolute = 150
        '
        'CodCampo
        '
        Me.CodCampo.DataFieldName = "cod_campo"
        Me.CodCampo.Name = "CodCampo"
        Me.CodCampo.Text = "Código"
        Me.CodCampo.Width.Absolute = 100
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Campo"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'sbOrden
        '
        '
        '
        '
        Me.sbOrden.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sbOrden.Dock = System.Windows.Forms.DockStyle.Left
        Me.sbOrden.Location = New System.Drawing.Point(412, 0)
        Me.sbOrden.Name = "sbOrden"
        Me.sbOrden.OffBackColor = System.Drawing.Color.PowderBlue
        Me.sbOrden.OffText = "Descendente"
        Me.sbOrden.OffTextColor = System.Drawing.Color.Black
        Me.sbOrden.OnBackColor = System.Drawing.Color.Honeydew
        Me.sbOrden.OnText = "Ascendente"
        Me.sbOrden.OnTextColor = System.Drawing.Color.Black
        Me.sbOrden.Size = New System.Drawing.Size(97, 20)
        Me.sbOrden.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sbOrden.SwitchBackColor = System.Drawing.Color.RoyalBlue
        Me.sbOrden.SwitchFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sbOrden.SwitchWidth = 25
        Me.sbOrden.TabIndex = 98
        Me.sbOrden.Value = True
        Me.sbOrden.ValueObject = "Y"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnLimpiar)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.btnAgregar)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(10, 208)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(10, 0, 10, 8)
        Me.GroupBox1.Size = New System.Drawing.Size(510, 47)
        Me.GroupBox1.TabIndex = 99
        Me.GroupBox1.TabStop = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLimpiar.CausesValidation = False
        Me.btnLimpiar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLimpiar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.Image = Global.PIDA.My.Resources.Resources.cancel_
        Me.btnLimpiar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnLimpiar.ImageTextSpacing = 3
        Me.btnLimpiar.Location = New System.Drawing.Point(137, 13)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(111, 26)
        Me.btnLimpiar.TabIndex = 0
        Me.btnLimpiar.Text = "Limpiar orden"
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(127, 13)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(10, 26)
        Me.Panel1.TabIndex = 5
        '
        'btnAgregar
        '
        Me.btnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAgregar.CausesValidation = False
        Me.btnAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAgregar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = Global.PIDA.My.Resources.Resources.add_
        Me.btnAgregar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnAgregar.ImageTextSpacing = 3
        Me.btnAgregar.Location = New System.Drawing.Point(10, 13)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(117, 26)
        Me.btnAgregar.TabIndex = 3
        Me.btnAgregar.Text = "Agregar orden"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.salir_
        Me.btnCancelar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCancelar.ImageTextSpacing = 3
        Me.btnCancelar.Location = New System.Drawing.Point(410, 13)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(90, 26)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cerrar"
        '
        'lstOrden
        '
        Me.lstOrden.Dock = System.Windows.Forms.DockStyle.Left
        Me.lstOrden.FormattingEnabled = True
        Me.lstOrden.Location = New System.Drawing.Point(0, 0)
        Me.lstOrden.Name = "lstOrden"
        Me.lstOrden.Size = New System.Drawing.Size(465, 115)
        Me.lstOrden.TabIndex = 102
        '
        'btnBajar
        '
        Me.btnBajar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBajar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBajar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnBajar.Image = Global.PIDA.My.Resources.Resources.abajo_
        Me.btnBajar.ImageFixedSize = New System.Drawing.Size(13, 13)
        Me.btnBajar.Location = New System.Drawing.Point(0, 69)
        Me.btnBajar.Name = "btnBajar"
        Me.btnBajar.Size = New System.Drawing.Size(35, 21)
        Me.btnBajar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBajar.TabIndex = 104
        '
        'btnSubir
        '
        Me.btnSubir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSubir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSubir.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSubir.Image = Global.PIDA.My.Resources.Resources.arriba_
        Me.btnSubir.ImageFixedSize = New System.Drawing.Size(13, 13)
        Me.btnSubir.Location = New System.Drawing.Point(0, 25)
        Me.btnSubir.Name = "btnSubir"
        Me.btnSubir.Size = New System.Drawing.Size(35, 21)
        Me.btnSubir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSubir.TabIndex = 103
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ReflectionLabel2)
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(10, 10)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(510, 53)
        Me.Panel2.TabIndex = 105
        '
        'ReflectionLabel2
        '
        '
        '
        '
        Me.ReflectionLabel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel2.BackgroundStyle.PaddingLeft = 10
        Me.ReflectionLabel2.BackgroundStyle.PaddingTop = 10
        Me.ReflectionLabel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReflectionLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel2.Location = New System.Drawing.Point(38, 0)
        Me.ReflectionLabel2.Name = "ReflectionLabel2"
        Me.ReflectionLabel2.Size = New System.Drawing.Size(472, 53)
        Me.ReflectionLabel2.TabIndex = 249
        Me.ReflectionLabel2.Text = "<font color=""#1F497D""><b>ORDENAR</b></font>"
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox2.Image = Global.PIDA.My.Resources.Resources.orden_
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(38, 53)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 210
        Me.PictureBox2.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.sbOrden)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.cbCampos)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(10, 63)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(510, 20)
        Me.Panel3.TabIndex = 106
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel4.Location = New System.Drawing.Point(402, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(10, 20)
        Me.Panel4.TabIndex = 8
        '
        'Panel5
        '
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(10, 83)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(510, 10)
        Me.Panel5.TabIndex = 107
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Panel8)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Controls.Add(Me.lstOrden)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(10, 93)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(510, 115)
        Me.Panel6.TabIndex = 108
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.btnSubir)
        Me.Panel8.Controls.Add(Me.btnBajar)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(475, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Padding = New System.Windows.Forms.Padding(0, 25, 0, 25)
        Me.Panel8.Size = New System.Drawing.Size(35, 115)
        Me.Panel8.TabIndex = 104
        '
        'Panel7
        '
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(465, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(10, 115)
        Me.Panel7.TabIndex = 103
        '
        'frmOrdenNomina
        '
        Me.AcceptButton = Me.btnAgregar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(530, 265)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOrdenNomina"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Orden de información nómina"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cbCampos As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents sbOrden As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAgregar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnLimpiar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents NombreCampo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents CodCampo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents lstOrden As System.Windows.Forms.ListBox
    Friend WithEvents btnSubir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBajar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ReflectionLabel2 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
End Class
