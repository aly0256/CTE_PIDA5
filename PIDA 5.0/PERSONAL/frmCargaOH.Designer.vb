<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargaOH
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCargaOH))
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.btnIniciarCarga = New DevComponents.DotNetBar.ButtonX()
        Me.txtArchivoCarga = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnSeleccionarArchivo = New DevComponents.DotNetBar.ButtonX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbCias = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFechaEfectiva = New System.Windows.Forms.DateTimePicker()
        Me.SuspendLayout()
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(13, 87)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(195, 13)
        Me.LinkLabel1.TabIndex = 0
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Generar layout y catálogos actualizados"
        '
        'btnIniciarCarga
        '
        Me.btnIniciarCarga.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnIniciarCarga.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnIniciarCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIniciarCarga.Location = New System.Drawing.Point(12, 253)
        Me.btnIniciarCarga.Name = "btnIniciarCarga"
        Me.btnIniciarCarga.Size = New System.Drawing.Size(360, 46)
        Me.btnIniciarCarga.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnIniciarCarga.TabIndex = 1
        Me.btnIniciarCarga.Text = "Iniciar carga"
        '
        'txtArchivoCarga
        '
        '
        '
        '
        Me.txtArchivoCarga.Border.Class = "TextBoxBorder"
        Me.txtArchivoCarga.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtArchivoCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivoCarga.Location = New System.Drawing.Point(12, 61)
        Me.txtArchivoCarga.Name = "txtArchivoCarga"
        Me.txtArchivoCarga.PreventEnterBeep = True
        Me.txtArchivoCarga.ReadOnly = True
        Me.txtArchivoCarga.Size = New System.Drawing.Size(279, 23)
        Me.txtArchivoCarga.TabIndex = 2
        '
        'btnSeleccionarArchivo
        '
        Me.btnSeleccionarArchivo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSeleccionarArchivo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSeleccionarArchivo.Location = New System.Drawing.Point(297, 61)
        Me.btnSeleccionarArchivo.Name = "btnSeleccionarArchivo"
        Me.btnSeleccionarArchivo.Size = New System.Drawing.Size(75, 23)
        Me.btnSeleccionarArchivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSeleccionarArchivo.TabIndex = 3
        Me.btnSeleccionarArchivo.Text = "Seleccionar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(209, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Seleccionar archivo de excel para la carga"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(216, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Carga masiva de personal"
        '
        'cmbCias
        '
        Me.cmbCias.DisplayMember = "cod_comp"
        Me.cmbCias.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbCias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCias.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCias.FormattingEnabled = True
        Me.cmbCias.ItemHeight = 20
        Me.cmbCias.Location = New System.Drawing.Point(12, 132)
        Me.cmbCias.Name = "cmbCias"
        Me.cmbCias.Size = New System.Drawing.Size(279, 26)
        Me.cmbCias.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbCias.TabIndex = 6
        Me.cmbCias.ValueMember = "cod_comp"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Compañía"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 178)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Fecha efectiva"
        '
        'DateTimePicker1
        '
        Me.dtpFechaEfectiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaEfectiva.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaEfectiva.Location = New System.Drawing.Point(12, 194)
        Me.dtpFechaEfectiva.Name = "DateTimePicker1"
        Me.dtpFechaEfectiva.Size = New System.Drawing.Size(128, 29)
        Me.dtpFechaEfectiva.TabIndex = 9
        '
        'frmCargaOH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(384, 323)
        Me.Controls.Add(Me.dtpFechaEfectiva)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbCias)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSeleccionarArchivo)
        Me.Controls.Add(Me.txtArchivoCarga)
        Me.Controls.Add(Me.btnIniciarCarga)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCargaOH"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carga masiva de personal"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents btnIniciarCarga As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtArchivoCarga As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnSeleccionarArchivo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbCias As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaEfectiva As System.Windows.Forms.DateTimePicker
End Class
