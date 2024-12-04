<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMasivoGafetes
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
        Me.cpActualizacion = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.btnIniciarCarga = New DevComponents.DotNetBar.ButtonX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSeleccionarArchivo = New DevComponents.DotNetBar.ButtonX()
        Me.txtArchivoCarga = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lnkformato = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'cpActualizacion
        '
        '
        '
        '
        Me.cpActualizacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cpActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cpActualizacion.Location = New System.Drawing.Point(16, 100)
        Me.cpActualizacion.Name = "cpActualizacion"
        Me.cpActualizacion.Size = New System.Drawing.Size(360, 25)
        Me.cpActualizacion.TabIndex = 124
        Me.cpActualizacion.Text = "Procesando..."
        Me.cpActualizacion.TextVisible = True
        '
        'btnIniciarCarga
        '
        Me.btnIniciarCarga.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnIniciarCarga.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnIniciarCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIniciarCarga.Location = New System.Drawing.Point(16, 139)
        Me.btnIniciarCarga.Name = "btnIniciarCarga"
        Me.btnIniciarCarga.Size = New System.Drawing.Size(360, 46)
        Me.btnIniciarCarga.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnIniciarCarga.TabIndex = 123
        Me.btnIniciarCarga.Text = "Iniciar carga"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(169, 13)
        Me.Label1.TabIndex = 122
        Me.Label1.Text = "Seleccionar archivo  para la carga"
        '
        'btnSeleccionarArchivo
        '
        Me.btnSeleccionarArchivo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSeleccionarArchivo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSeleccionarArchivo.Location = New System.Drawing.Point(301, 64)
        Me.btnSeleccionarArchivo.Name = "btnSeleccionarArchivo"
        Me.btnSeleccionarArchivo.Size = New System.Drawing.Size(75, 23)
        Me.btnSeleccionarArchivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSeleccionarArchivo.TabIndex = 121
        Me.btnSeleccionarArchivo.Text = "Seleccionar"
        '
        'txtArchivoCarga
        '
        '
        '
        '
        Me.txtArchivoCarga.Border.Class = "TextBoxBorder"
        Me.txtArchivoCarga.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtArchivoCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivoCarga.Location = New System.Drawing.Point(16, 64)
        Me.txtArchivoCarga.Name = "txtArchivoCarga"
        Me.txtArchivoCarga.PreventEnterBeep = True
        Me.txtArchivoCarga.ReadOnly = True
        Me.txtArchivoCarga.Size = New System.Drawing.Size(279, 23)
        Me.txtArchivoCarga.TabIndex = 120
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(208, 20)
        Me.Label2.TabIndex = 119
        Me.Label2.Text = "Carga masiva de gafetes"
        '
        'lnkformato
        '
        Me.lnkformato.AutoSize = True
        Me.lnkformato.Location = New System.Drawing.Point(101, 199)
        Me.lnkformato.Name = "lnkformato"
        Me.lnkformato.Size = New System.Drawing.Size(184, 13)
        Me.lnkformato.TabIndex = 125
        Me.lnkformato.TabStop = True
        Me.lnkformato.Text = "Descargar plantilla para carga masiva"
        '
        'frmMasivoGafetes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 221)
        Me.Controls.Add(Me.lnkformato)
        Me.Controls.Add(Me.cpActualizacion)
        Me.Controls.Add(Me.btnIniciarCarga)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSeleccionarArchivo)
        Me.Controls.Add(Me.txtArchivoCarga)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmMasivoGafetes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Masivo gafetes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cpActualizacion As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents btnIniciarCarga As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSeleccionarArchivo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtArchivoCarga As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lnkformato As System.Windows.Forms.LinkLabel
End Class
