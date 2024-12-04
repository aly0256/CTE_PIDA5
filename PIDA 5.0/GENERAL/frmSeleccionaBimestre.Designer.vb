<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeleccionaBimestre
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeleccionaBimestre))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAnio = New DevComponents.Editors.IntegerInput()
        Me.cmbBimestre = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtAnio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Controls.Add(Me.btnAceptar)
        Me.Panel1.Location = New System.Drawing.Point(106, 128)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(178, 31)
        Me.Panel1.TabIndex = 111
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Location = New System.Drawing.Point(92, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(81, 23)
        Me.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancelar.TabIndex = 106
        Me.btnCancelar.Text = "&Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Location = New System.Drawing.Point(5, 3)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(81, 23)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 105
        Me.btnAceptar.Text = "&Aceptar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtAnio)
        Me.GroupBox1.Controls.Add(Me.cmbBimestre)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 54)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(399, 68)
        Me.GroupBox1.TabIndex = 110
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(36, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Año"
        '
        'txtAnio
        '
        '
        '
        '
        Me.txtAnio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtAnio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAnio.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtAnio.Location = New System.Drawing.Point(74, 11)
        Me.txtAnio.MaxValue = 9999
        Me.txtAnio.MinValue = 1900
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.ShowUpDown = True
        Me.txtAnio.Size = New System.Drawing.Size(80, 20)
        Me.txtAnio.TabIndex = 4
        Me.txtAnio.Value = 1900
        '
        'cmbBimestre
        '
        Me.cmbBimestre.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbBimestre.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbBimestre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbBimestre.ButtonDropDown.Visible = True
        Me.cmbBimestre.DisplayMembers = "bimestre,meses,inicio,fin"
        Me.cmbBimestre.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbBimestre.Location = New System.Drawing.Point(74, 37)
        Me.cmbBimestre.Name = "cmbBimestre"
        Me.cmbBimestre.Size = New System.Drawing.Size(297, 23)
        Me.cmbBimestre.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbBimestre.TabIndex = 3
        Me.cmbBimestre.ValueMember = "bimestre"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Bimestre"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(39, 8)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(267, 40)
        Me.ReflectionLabel1.TabIndex = 108
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>SELECCIONE BIMESTRE</b></font>"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.Calendario32
        Me.picImagen.Location = New System.Drawing.Point(5, 8)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(34, 34)
        Me.picImagen.TabIndex = 109
        Me.picImagen.TabStop = False
        '
        'frmSeleccionaBimestre
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(413, 171)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.picImagen)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSeleccionaBimestre"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bimestre"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtAnio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents cmbBimestre As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAnio As DevComponents.Editors.IntegerInput
End Class
