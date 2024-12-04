<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargaMasivaTarjetas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCargaMasivaTarjetas))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSeleccionarArchivo = New DevComponents.DotNetBar.ButtonX()
        Me.txtArchivoCarga = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnIniciarCarga = New DevComponents.DotNetBar.ButtonX()
        Me.cpActualizacion = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(208, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Carga masiva de tarjetas"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Seleccionar archivo de csv para la carga"
        '
        'btnSeleccionarArchivo
        '
        Me.btnSeleccionarArchivo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSeleccionarArchivo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSeleccionarArchivo.Location = New System.Drawing.Point(292, 61)
        Me.btnSeleccionarArchivo.Name = "btnSeleccionarArchivo"
        Me.btnSeleccionarArchivo.Size = New System.Drawing.Size(75, 23)
        Me.btnSeleccionarArchivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSeleccionarArchivo.TabIndex = 8
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
        Me.txtArchivoCarga.Location = New System.Drawing.Point(7, 61)
        Me.txtArchivoCarga.Name = "txtArchivoCarga"
        Me.txtArchivoCarga.PreventEnterBeep = True
        Me.txtArchivoCarga.ReadOnly = True
        Me.txtArchivoCarga.Size = New System.Drawing.Size(279, 23)
        Me.txtArchivoCarga.TabIndex = 7
        '
        'btnIniciarCarga
        '
        Me.btnIniciarCarga.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnIniciarCarga.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnIniciarCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIniciarCarga.Location = New System.Drawing.Point(12, 135)
        Me.btnIniciarCarga.Name = "btnIniciarCarga"
        Me.btnIniciarCarga.Size = New System.Drawing.Size(360, 46)
        Me.btnIniciarCarga.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnIniciarCarga.TabIndex = 10
        Me.btnIniciarCarga.Text = "Iniciar carga"
        '
        'cpActualizacion
        '
        '
        '
        '
        Me.cpActualizacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cpActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cpActualizacion.Location = New System.Drawing.Point(12, 104)
        Me.cpActualizacion.Name = "cpActualizacion"
        Me.cpActualizacion.Size = New System.Drawing.Size(360, 25)
        Me.cpActualizacion.TabIndex = 118
        Me.cpActualizacion.Text = "Procesando..."
        Me.cpActualizacion.TextVisible = True
        '
        'frmCargaMasivaTargetas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(392, 197)
        Me.Controls.Add(Me.cpActualizacion)
        Me.Controls.Add(Me.btnIniciarCarga)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSeleccionarArchivo)
        Me.Controls.Add(Me.txtArchivoCarga)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCargaMasivaTargetas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carga masiva tarjetas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSeleccionarArchivo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtArchivoCarga As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnIniciarCarga As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cpActualizacion As DevComponents.DotNetBar.Controls.ProgressBarX
End Class
