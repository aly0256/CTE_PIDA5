<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargaXML
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCargaXML))
        Me.Label61 = New System.Windows.Forms.Label()
        Me.txtarchivo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.CircularProgress4 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtanotim = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtperiodotim = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtpath = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPathXml = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnBuscarRutaXML = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnVerBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.chkPerS = New System.Windows.Forms.CheckBox()
        Me.chkPerC = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.BackColor = System.Drawing.SystemColors.Control
        Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.Location = New System.Drawing.Point(9, 14)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(113, 15)
        Me.Label61.TabIndex = 107
        Me.Label61.Text = "Selecciona Archivo:"
        '
        'txtarchivo
        '
        '
        '
        '
        Me.txtarchivo.Border.Class = "TextBoxBorder"
        Me.txtarchivo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtarchivo.Location = New System.Drawing.Point(131, 14)
        Me.txtarchivo.Name = "txtarchivo"
        Me.txtarchivo.PreventEnterBeep = True
        Me.txtarchivo.Size = New System.Drawing.Size(388, 20)
        Me.txtarchivo.TabIndex = 106
        '
        'CircularProgress4
        '
        '
        '
        '
        Me.CircularProgress4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CircularProgress4.Location = New System.Drawing.Point(12, 128)
        Me.CircularProgress4.Name = "CircularProgress4"
        Me.CircularProgress4.ProgressColor = System.Drawing.Color.SteelBlue
        Me.CircularProgress4.ProgressTextVisible = True
        Me.CircularProgress4.Size = New System.Drawing.Size(539, 56)
        Me.CircularProgress4.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress4.TabIndex = 161
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(94, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 15)
        Me.Label4.TabIndex = 180
        Me.Label4.Text = "Ano:"
        '
        'txtanotim
        '
        '
        '
        '
        Me.txtanotim.Border.Class = "TextBoxBorder"
        Me.txtanotim.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtanotim.Location = New System.Drawing.Point(131, 99)
        Me.txtanotim.Name = "txtanotim"
        Me.txtanotim.PreventEnterBeep = True
        Me.txtanotim.Size = New System.Drawing.Size(56, 20)
        Me.txtanotim.TabIndex = 179
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(193, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 15)
        Me.Label5.TabIndex = 178
        Me.Label5.Text = "Periodo :"
        '
        'txtperiodotim
        '
        '
        '
        '
        Me.txtperiodotim.Border.Class = "TextBoxBorder"
        Me.txtperiodotim.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtperiodotim.Location = New System.Drawing.Point(255, 99)
        Me.txtperiodotim.Name = "txtperiodotim"
        Me.txtperiodotim.PreventEnterBeep = True
        Me.txtperiodotim.Size = New System.Drawing.Size(56, 20)
        Me.txtperiodotim.TabIndex = 177
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 184
        Me.Label6.Text = "Extraer En:"
        '
        'txtpath
        '
        '
        '
        '
        Me.txtpath.Border.Class = "TextBoxBorder"
        Me.txtpath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtpath.Location = New System.Drawing.Point(131, 40)
        Me.txtpath.Name = "txtpath"
        Me.txtpath.PreventEnterBeep = True
        Me.txtpath.Size = New System.Drawing.Size(388, 20)
        Me.txtpath.TabIndex = 183
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 15)
        Me.Label1.TabIndex = 187
        Me.Label1.Text = "Guardar xml's en:"
        '
        'txtPathXml
        '
        '
        '
        '
        Me.txtPathXml.Border.Class = "TextBoxBorder"
        Me.txtPathXml.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPathXml.Location = New System.Drawing.Point(131, 67)
        Me.txtPathXml.Name = "txtPathXml"
        Me.txtPathXml.PreventEnterBeep = True
        Me.txtPathXml.Size = New System.Drawing.Size(388, 20)
        Me.txtPathXml.TabIndex = 186
        '
        'btnBuscarRutaXML
        '
        Me.btnBuscarRutaXML.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscarRutaXML.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarRutaXML.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscarRutaXML.Image = Global.PIDA.My.Resources.Resources.search24
        Me.btnBuscarRutaXML.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnBuscarRutaXML.Location = New System.Drawing.Point(528, 67)
        Me.btnBuscarRutaXML.Name = "btnBuscarRutaXML"
        Me.btnBuscarRutaXML.Size = New System.Drawing.Size(28, 20)
        Me.btnBuscarRutaXML.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscarRutaXML.TabIndex = 188
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Image = Global.PIDA.My.Resources.Resources.search24
        Me.ButtonX2.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.ButtonX2.Location = New System.Drawing.Point(528, 40)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(28, 20)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 185
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = Global.PIDA.My.Resources.Resources.Inbox32
        Me.btnBorrar.Location = New System.Drawing.Point(12, 206)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(455, 34)
        Me.btnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBorrar.SubItemsExpandWidth = 15
        Me.btnBorrar.TabIndex = 158
        Me.btnBorrar.Text = "Cargar"
        '
        'btnVerBuscar
        '
        Me.btnVerBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnVerBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVerBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnVerBuscar.Image = Global.PIDA.My.Resources.Resources.search24
        Me.btnVerBuscar.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnVerBuscar.Location = New System.Drawing.Point(528, 14)
        Me.btnVerBuscar.Name = "btnVerBuscar"
        Me.btnVerBuscar.Size = New System.Drawing.Size(28, 20)
        Me.btnVerBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnVerBuscar.TabIndex = 157
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.CausesValidation = False
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX1.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.ButtonX1.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.ButtonX1.Location = New System.Drawing.Point(473, 206)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(78, 34)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 21
        Me.ButtonX1.Text = "&Salir"
        '
        'chkPerS
        '
        Me.chkPerS.AutoSize = True
        Me.chkPerS.Checked = True
        Me.chkPerS.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPerS.Location = New System.Drawing.Point(338, 101)
        Me.chkPerS.Name = "chkPerS"
        Me.chkPerS.Size = New System.Drawing.Size(67, 17)
        Me.chkPerS.TabIndex = 189
        Me.chkPerS.Text = "Semanal"
        Me.chkPerS.UseVisualStyleBackColor = True
        '
        'chkPerC
        '
        Me.chkPerC.AutoSize = True
        Me.chkPerC.Location = New System.Drawing.Point(411, 100)
        Me.chkPerC.Name = "chkPerC"
        Me.chkPerC.Size = New System.Drawing.Size(77, 17)
        Me.chkPerC.TabIndex = 190
        Me.chkPerC.Text = "Catorcenal"
        Me.chkPerC.UseVisualStyleBackColor = True
        '
        'frmCargaXML
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 256)
        Me.Controls.Add(Me.chkPerC)
        Me.Controls.Add(Me.chkPerS)
        Me.Controls.Add(Me.btnBuscarRutaXML)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPathXml)
        Me.Controls.Add(Me.ButtonX2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtpath)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtanotim)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtperiodotim)
        Me.Controls.Add(Me.CircularProgress4)
        Me.Controls.Add(Me.btnBorrar)
        Me.Controls.Add(Me.btnVerBuscar)
        Me.Controls.Add(Me.Label61)
        Me.Controls.Add(Me.txtarchivo)
        Me.Controls.Add(Me.ButtonX1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCargaXML"
        Me.Text = "Cargar xml's"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents txtarchivo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnVerBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CircularProgress4 As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtanotim As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtperiodotim As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtpath As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnBuscarRutaXML As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPathXml As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents chkPerS As System.Windows.Forms.CheckBox
    Friend WithEvents chkPerC As System.Windows.Forms.CheckBox
End Class
