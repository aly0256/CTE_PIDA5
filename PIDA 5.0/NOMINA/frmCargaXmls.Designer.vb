<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargaXmls
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCargaXmls))
        Me.btnInicCarga = New DevComponents.DotNetBar.ButtonX()
        Me.txtSource = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtAno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPeriodo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTipoPeriodo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCodComp = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtVersion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.CircularProgress4 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.SuspendLayout()
        '
        'btnInicCarga
        '
        Me.btnInicCarga.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnInicCarga.CausesValidation = False
        Me.btnInicCarga.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnInicCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInicCarga.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnInicCarga.Location = New System.Drawing.Point(163, 240)
        Me.btnInicCarga.Name = "btnInicCarga"
        Me.btnInicCarga.Size = New System.Drawing.Size(167, 34)
        Me.btnInicCarga.TabIndex = 117
        Me.btnInicCarga.Text = "Actualizar"
        '
        'txtSource
        '
        Me.txtSource.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtSource.Border.Class = "TextBoxBorder"
        Me.txtSource.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSource.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtSource.Location = New System.Drawing.Point(100, 141)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(369, 20)
        Me.txtSource.TabIndex = 118
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 147)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 119
        Me.Label1.Text = "Ruta origen"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 121
        Me.Label2.Text = "Año"
        '
        'txtAno
        '
        Me.txtAno.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtAno.Border.Class = "TextBoxBorder"
        Me.txtAno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAno.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtAno.Location = New System.Drawing.Point(100, 33)
        Me.txtAno.Name = "txtAno"
        Me.txtAno.Size = New System.Drawing.Size(80, 20)
        Me.txtAno.TabIndex = 120
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 123
        Me.Label3.Text = "Periodo"
        '
        'txtPeriodo
        '
        Me.txtPeriodo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtPeriodo.Border.Class = "TextBoxBorder"
        Me.txtPeriodo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtPeriodo.Location = New System.Drawing.Point(100, 59)
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(80, 20)
        Me.txtPeriodo.TabIndex = 122
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 125
        Me.Label4.Text = "Tipo periodo"
        '
        'txtTipoPeriodo
        '
        Me.txtTipoPeriodo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtTipoPeriodo.Border.Class = "TextBoxBorder"
        Me.txtTipoPeriodo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTipoPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoPeriodo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtTipoPeriodo.Location = New System.Drawing.Point(100, 85)
        Me.txtTipoPeriodo.Name = "txtTipoPeriodo"
        Me.txtTipoPeriodo.Size = New System.Drawing.Size(80, 20)
        Me.txtTipoPeriodo.TabIndex = 124
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(22, 13)
        Me.Label5.TabIndex = 127
        Me.Label5.Text = "Cia"
        '
        'txtCodComp
        '
        Me.txtCodComp.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtCodComp.Border.Class = "TextBoxBorder"
        Me.txtCodComp.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodComp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodComp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCodComp.Location = New System.Drawing.Point(100, 5)
        Me.txtCodComp.Name = "txtCodComp"
        Me.txtCodComp.Size = New System.Drawing.Size(80, 20)
        Me.txtCodComp.TabIndex = 126
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 129
        Me.Label6.Text = "Versión"
        '
        'txtVersion
        '
        Me.txtVersion.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtVersion.Border.Class = "TextBoxBorder"
        Me.txtVersion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVersion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtVersion.Location = New System.Drawing.Point(100, 109)
        Me.txtVersion.Name = "txtVersion"
        Me.txtVersion.Size = New System.Drawing.Size(80, 20)
        Me.txtVersion.TabIndex = 128
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.CausesValidation = False
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX1.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.ButtonX1.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.ButtonX1.Location = New System.Drawing.Point(391, 240)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(78, 34)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 130
        Me.ButtonX1.Text = "&Salir"
        '
        'CircularProgress4
        '
        '
        '
        '
        Me.CircularProgress4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CircularProgress4.Location = New System.Drawing.Point(3, 172)
        Me.CircularProgress4.Name = "CircularProgress4"
        Me.CircularProgress4.ProgressColor = System.Drawing.Color.SteelBlue
        Me.CircularProgress4.ProgressTextVisible = True
        Me.CircularProgress4.Size = New System.Drawing.Size(487, 56)
        Me.CircularProgress4.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress4.TabIndex = 162
        '
        'frmCargaXmls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 280)
        Me.Controls.Add(Me.CircularProgress4)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtVersion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCodComp)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTipoPeriodo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPeriodo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtAno)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtSource)
        Me.Controls.Add(Me.btnInicCarga)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCargaXmls"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carga xmls"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnInicCarga As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtSource As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTipoPeriodo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCodComp As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtVersion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CircularProgress4 As DevComponents.DotNetBar.Controls.CircularProgress
End Class
