<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargaHist
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPathXml = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtpath = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.txtarchivo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnBuscarRutaXML = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.btnVerBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.CircularProgress4 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.btnCargaXmlHist = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 15)
        Me.Label1.TabIndex = 196
        Me.Label1.Text = "Guardar xml's en:"
        '
        'txtPathXml
        '
        '
        '
        '
        Me.txtPathXml.Border.Class = "TextBoxBorder"
        Me.txtPathXml.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPathXml.Location = New System.Drawing.Point(142, 64)
        Me.txtPathXml.Name = "txtPathXml"
        Me.txtPathXml.PreventEnterBeep = True
        Me.txtPathXml.Size = New System.Drawing.Size(388, 20)
        Me.txtPathXml.TabIndex = 195
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Control
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(20, 37)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 193
        Me.Label6.Text = "Extraer En:"
        '
        'txtpath
        '
        '
        '
        '
        Me.txtpath.Border.Class = "TextBoxBorder"
        Me.txtpath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtpath.Location = New System.Drawing.Point(142, 37)
        Me.txtpath.Name = "txtpath"
        Me.txtpath.PreventEnterBeep = True
        Me.txtpath.Size = New System.Drawing.Size(388, 20)
        Me.txtpath.TabIndex = 192
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.BackColor = System.Drawing.SystemColors.Control
        Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.Location = New System.Drawing.Point(20, 11)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(113, 15)
        Me.Label61.TabIndex = 190
        Me.Label61.Text = "Selecciona Archivo:"
        '
        'txtarchivo
        '
        '
        '
        '
        Me.txtarchivo.Border.Class = "TextBoxBorder"
        Me.txtarchivo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtarchivo.Location = New System.Drawing.Point(142, 11)
        Me.txtarchivo.Name = "txtarchivo"
        Me.txtarchivo.PreventEnterBeep = True
        Me.txtarchivo.Size = New System.Drawing.Size(388, 20)
        Me.txtarchivo.TabIndex = 189
        '
        'btnBuscarRutaXML
        '
        Me.btnBuscarRutaXML.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscarRutaXML.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBuscarRutaXML.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscarRutaXML.Image = Global.PIDA.My.Resources.Resources.search24
        Me.btnBuscarRutaXML.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnBuscarRutaXML.Location = New System.Drawing.Point(539, 64)
        Me.btnBuscarRutaXML.Name = "btnBuscarRutaXML"
        Me.btnBuscarRutaXML.Size = New System.Drawing.Size(28, 20)
        Me.btnBuscarRutaXML.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscarRutaXML.TabIndex = 197
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Image = Global.PIDA.My.Resources.Resources.search24
        Me.ButtonX2.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.ButtonX2.Location = New System.Drawing.Point(539, 37)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(28, 20)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 194
        '
        'btnVerBuscar
        '
        Me.btnVerBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnVerBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVerBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnVerBuscar.Image = Global.PIDA.My.Resources.Resources.search24
        Me.btnVerBuscar.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnVerBuscar.Location = New System.Drawing.Point(539, 11)
        Me.btnVerBuscar.Name = "btnVerBuscar"
        Me.btnVerBuscar.Size = New System.Drawing.Size(28, 20)
        Me.btnVerBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnVerBuscar.TabIndex = 191
        '
        'CircularProgress4
        '
        '
        '
        '
        Me.CircularProgress4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CircularProgress4.Location = New System.Drawing.Point(23, 101)
        Me.CircularProgress4.Name = "CircularProgress4"
        Me.CircularProgress4.ProgressColor = System.Drawing.Color.SteelBlue
        Me.CircularProgress4.ProgressTextVisible = True
        Me.CircularProgress4.Size = New System.Drawing.Size(539, 56)
        Me.CircularProgress4.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress4.TabIndex = 200
        '
        'btnCargaXmlHist
        '
        Me.btnCargaXmlHist.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCargaXmlHist.CausesValidation = False
        Me.btnCargaXmlHist.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCargaXmlHist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCargaXmlHist.Image = Global.PIDA.My.Resources.Resources.Inbox32
        Me.btnCargaXmlHist.Location = New System.Drawing.Point(23, 179)
        Me.btnCargaXmlHist.Name = "btnCargaXmlHist"
        Me.btnCargaXmlHist.Size = New System.Drawing.Size(455, 34)
        Me.btnCargaXmlHist.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCargaXmlHist.SubItemsExpandWidth = 15
        Me.btnCargaXmlHist.TabIndex = 199
        Me.btnCargaXmlHist.Text = "Cargar"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.CausesValidation = False
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX1.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.ButtonX1.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.ButtonX1.Location = New System.Drawing.Point(484, 179)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(78, 34)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 198
        Me.ButtonX1.Text = "&Salir"
        '
        'frmCargaHist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 230)
        Me.Controls.Add(Me.CircularProgress4)
        Me.Controls.Add(Me.btnCargaXmlHist)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.btnBuscarRutaXML)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPathXml)
        Me.Controls.Add(Me.ButtonX2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtpath)
        Me.Controls.Add(Me.btnVerBuscar)
        Me.Controls.Add(Me.Label61)
        Me.Controls.Add(Me.txtarchivo)
        Me.Name = "frmCargaHist"
        Me.Text = "Cargar Histórico"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBuscarRutaXML As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPathXml As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtpath As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnVerBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents txtarchivo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents CircularProgress4 As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents btnCargaXmlHist As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
End Class
