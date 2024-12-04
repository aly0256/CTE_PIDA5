<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargaCafeteria
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
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.gpValores = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.btnArchivo = New System.Windows.Forms.RadioButton()
        Me.btnBuscaArchivo = New DevComponents.DotNetBar.ButtonX()
        Me.txtArchivo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.gpAceptarCancelar = New System.Windows.Forms.GroupBox()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.cpActualizacion = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.dlgArchivo = New System.Windows.Forms.OpenFileDialog()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpValores.SuspendLayout()
        Me.gpAceptarCancelar.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(50, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(451, 46)
        Me.ReflectionLabel1.TabIndex = 120
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CARGA MASIVA CAFETERIA</b></font>"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources._1469761116_cmyk_04
        Me.picImagen.Location = New System.Drawing.Point(12, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(31, 30)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImagen.TabIndex = 121
        Me.picImagen.TabStop = False
        '
        'gpValores
        '
        Me.gpValores.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpValores.BackColor = System.Drawing.SystemColors.Control
        Me.gpValores.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpValores.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpValores.Controls.Add(Me.btnArchivo)
        Me.gpValores.Controls.Add(Me.btnBuscaArchivo)
        Me.gpValores.Controls.Add(Me.txtArchivo)
        Me.gpValores.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpValores.Location = New System.Drawing.Point(12, 64)
        Me.gpValores.Name = "gpValores"
        Me.gpValores.Size = New System.Drawing.Size(478, 94)
        '
        '
        '
        Me.gpValores.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpValores.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpValores.Style.BackColorGradientAngle = 90
        Me.gpValores.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpValores.Style.BorderBottomWidth = 1
        Me.gpValores.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpValores.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpValores.Style.BorderLeftWidth = 1
        Me.gpValores.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpValores.Style.BorderRightWidth = 1
        Me.gpValores.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpValores.Style.BorderTopWidth = 1
        Me.gpValores.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpValores.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpValores.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpValores.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpValores.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpValores.TabIndex = 122
        Me.gpValores.Text = "Archivo"
        '
        'btnArchivo
        '
        Me.btnArchivo.AutoSize = True
        Me.btnArchivo.BackColor = System.Drawing.SystemColors.Window
        Me.btnArchivo.Checked = True
        Me.btnArchivo.Location = New System.Drawing.Point(7, 6)
        Me.btnArchivo.Name = "btnArchivo"
        Me.btnArchivo.Size = New System.Drawing.Size(227, 17)
        Me.btnArchivo.TabIndex = 0
        Me.btnArchivo.TabStop = True
        Me.btnArchivo.Text = "Buscar en archivo excel (reloj, fecha, hora)"
        Me.btnArchivo.UseVisualStyleBackColor = False
        '
        'btnBuscaArchivo
        '
        Me.btnBuscaArchivo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscaArchivo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscaArchivo.Location = New System.Drawing.Point(434, 29)
        Me.btnBuscaArchivo.Name = "btnBuscaArchivo"
        Me.btnBuscaArchivo.Size = New System.Drawing.Size(26, 23)
        Me.btnBuscaArchivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscaArchivo.TabIndex = 2
        Me.btnBuscaArchivo.Text = "..."
        '
        'txtArchivo
        '
        Me.txtArchivo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtArchivo.Border.Class = "TextBoxBorder"
        Me.txtArchivo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtArchivo.Location = New System.Drawing.Point(26, 29)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.Size = New System.Drawing.Size(406, 23)
        Me.txtArchivo.TabIndex = 1
        '
        'gpAceptarCancelar
        '
        Me.gpAceptarCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.gpAceptarCancelar.Controls.Add(Me.btnAceptar)
        Me.gpAceptarCancelar.Controls.Add(Me.btnCancelar)
        Me.gpAceptarCancelar.Location = New System.Drawing.Point(319, 164)
        Me.gpAceptarCancelar.Name = "gpAceptarCancelar"
        Me.gpAceptarCancelar.Size = New System.Drawing.Size(174, 47)
        Me.gpAceptarCancelar.TabIndex = 126
        Me.gpAceptarCancelar.TabStop = False
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.Location = New System.Drawing.Point(6, 14)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.TabIndex = 11
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelar.Location = New System.Drawing.Point(88, 14)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Text = "Cancelar"
        '
        'cpActualizacion
        '
        '
        '
        '
        Me.cpActualizacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cpActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cpActualizacion.Location = New System.Drawing.Point(15, 173)
        Me.cpActualizacion.Name = "cpActualizacion"
        Me.cpActualizacion.Size = New System.Drawing.Size(298, 34)
        Me.cpActualizacion.TabIndex = 127
        Me.cpActualizacion.Text = "Reloj"
        Me.cpActualizacion.TextVisible = True
        Me.cpActualizacion.Visible = False
        '
        'dlgArchivo
        '
        Me.dlgArchivo.FileName = "OpenFileDialog1"
        '
        'frmCargaCafeteria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 225)
        Me.Controls.Add(Me.gpAceptarCancelar)
        Me.Controls.Add(Me.cpActualizacion)
        Me.Controls.Add(Me.gpValores)
        Me.Controls.Add(Me.picImagen)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "frmCargaCafeteria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Carga Masiva"
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpValores.ResumeLayout(False)
        Me.gpValores.PerformLayout()
        Me.gpAceptarCancelar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Private WithEvents gpValores As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btnArchivo As System.Windows.Forms.RadioButton
    Friend WithEvents btnBuscaArchivo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtArchivo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents gpAceptarCancelar As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cpActualizacion As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents dlgArchivo As System.Windows.Forms.OpenFileDialog
End Class
