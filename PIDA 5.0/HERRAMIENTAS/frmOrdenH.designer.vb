<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenH
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrdenH))
        Me.btnBajar = New DevComponents.DotNetBar.ButtonX()
        Me.btnSubir = New DevComponents.DotNetBar.ButtonX()
        Me.lstOrden = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAgregar = New DevComponents.DotNetBar.ButtonX()
        Me.btnLimpiar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.sbOrden = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.cbCampos = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBajar
        '
        Me.btnBajar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBajar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBajar.Image = Global.PIDA.My.Resources.Resources.navigate_down16
        Me.btnBajar.Location = New System.Drawing.Point(497, 154)
        Me.btnBajar.Name = "btnBajar"
        Me.btnBajar.Size = New System.Drawing.Size(21, 21)
        Me.btnBajar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBajar.TabIndex = 113
        '
        'btnSubir
        '
        Me.btnSubir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSubir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSubir.Image = Global.PIDA.My.Resources.Resources.navigate_up16
        Me.btnSubir.Location = New System.Drawing.Point(497, 80)
        Me.btnSubir.Name = "btnSubir"
        Me.btnSubir.Size = New System.Drawing.Size(21, 21)
        Me.btnSubir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSubir.TabIndex = 112
        '
        'lstOrden
        '
        Me.lstOrden.FormattingEnabled = True
        Me.lstOrden.Location = New System.Drawing.Point(18, 80)
        Me.lstOrden.Name = "lstOrden"
        Me.lstOrden.Size = New System.Drawing.Size(475, 95)
        Me.lstOrden.TabIndex = 111
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnAgregar)
        Me.GroupBox1.Controls.Add(Me.btnLimpiar)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Location = New System.Drawing.Point(116, 180)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(302, 47)
        Me.GroupBox1.TabIndex = 110
        Me.GroupBox1.TabStop = False
        '
        'btnAgregar
        '
        Me.btnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAgregar.CausesValidation = False
        Me.btnAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = Global.PIDA.My.Resources.Resources.AddOrder16
        Me.btnAgregar.Location = New System.Drawing.Point(6, 14)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(102, 25)
        Me.btnAgregar.TabIndex = 3
        Me.btnAgregar.Text = "Agregar orden"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLimpiar.CausesValidation = False
        Me.btnLimpiar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.Image = Global.PIDA.My.Resources.Resources.DeleteOrder16
        Me.btnLimpiar.Location = New System.Drawing.Point(112, 14)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(102, 25)
        Me.btnLimpiar.TabIndex = 0
        Me.btnLimpiar.Text = "Limpiar orden"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCancelar.Location = New System.Drawing.Point(218, 14)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "Cerrar"
        '
        'sbOrden
        '
        '
        '
        '
        Me.sbOrden.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sbOrden.Location = New System.Drawing.Point(422, 53)
        Me.sbOrden.Name = "sbOrden"
        Me.sbOrden.OffBackColor = System.Drawing.Color.PowderBlue
        Me.sbOrden.OffText = "Descendente"
        Me.sbOrden.OffTextColor = System.Drawing.Color.Black
        Me.sbOrden.OnBackColor = System.Drawing.Color.Honeydew
        Me.sbOrden.OnText = "Ascendente"
        Me.sbOrden.OnTextColor = System.Drawing.Color.Black
        Me.sbOrden.Size = New System.Drawing.Size(97, 21)
        Me.sbOrden.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sbOrden.SwitchBackColor = System.Drawing.Color.RoyalBlue
        Me.sbOrden.SwitchFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sbOrden.SwitchWidth = 25
        Me.sbOrden.TabIndex = 109
        Me.sbOrden.Value = True
        Me.sbOrden.ValueObject = "Y"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(55, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(403, 40)
        Me.ReflectionLabel1.TabIndex = 107
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>ORDENAR</b></font>"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.Sort32
        Me.picImagen.Location = New System.Drawing.Point(13, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(32, 32)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picImagen.TabIndex = 108
        Me.picImagen.TabStop = False
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
        Me.cbCampos.DisplayMembers = "nombre,cod_campo"
        Me.cbCampos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cbCampos.Location = New System.Drawing.Point(61, 53)
        Me.cbCampos.Name = "cbCampos"
        Me.cbCampos.Size = New System.Drawing.Size(355, 21)
        Me.cbCampos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbCampos.TabIndex = 105
        Me.cbCampos.ValueMember = "cod_campo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "Campo"
        '
        'frmOrdenH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 239)
        Me.Controls.Add(Me.btnBajar)
        Me.Controls.Add(Me.btnSubir)
        Me.Controls.Add(Me.lstOrden)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.sbOrden)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.picImagen)
        Me.Controls.Add(Me.cbCampos)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOrdenH"
        Me.Text = "Orden de archivo herramientas"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBajar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSubir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lstOrden As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAgregar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnLimpiar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents sbOrden As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents cbCampos As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
