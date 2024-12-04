<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregarEvaluacionReclutamiento
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbFiltro = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.cmbEvaluaciones = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.txtFolio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(44, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(338, 40)
        Me.ReflectionLabel1.TabIndex = 112
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>EVALUACIONES DISPONIBLES</b></font>"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.Profile24
        Me.picImagen.Location = New System.Drawing.Point(11, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(27, 26)
        Me.picImagen.TabIndex = 113
        Me.picImagen.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Window
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmbFiltro)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Line1)
        Me.Panel1.Controls.Add(Me.cmbEvaluaciones)
        Me.Panel1.Controls.Add(Me.txtFolio)
        Me.Panel1.Location = New System.Drawing.Point(5, 53)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(600, 97)
        Me.Panel1.TabIndex = 114
        '
        'cmbFiltro
        '
        Me.cmbFiltro.DisplayMember = "Text"
        Me.cmbFiltro.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFiltro.FormattingEnabled = True
        Me.cmbFiltro.ItemHeight = 14
        Me.cmbFiltro.Location = New System.Drawing.Point(315, 19)
        Me.cmbFiltro.Name = "cmbFiltro"
        Me.cmbFiltro.Size = New System.Drawing.Size(270, 20)
        Me.cmbFiltro.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbFiltro.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(29, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 15)
        Me.Label3.TabIndex = 82
        Me.Label3.Text = "Folio"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(239, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 15)
        Me.Label4.TabIndex = 86
        Me.Label4.Text = "Mostrar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Evaluación"
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.SystemColors.Window
        Me.Line1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Line1.Location = New System.Drawing.Point(11, 49)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(577, 11)
        Me.Line1.TabIndex = 84
        Me.Line1.Text = "Line1"
        '
        'cmbEvaluaciones
        '
        Me.cmbEvaluaciones.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbEvaluaciones.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbEvaluaciones.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbEvaluaciones.ButtonDropDown.Visible = True
        Me.cmbEvaluaciones.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbEvaluaciones.Location = New System.Drawing.Point(114, 66)
        Me.cmbEvaluaciones.Name = "cmbEvaluaciones"
        Me.cmbEvaluaciones.Size = New System.Drawing.Size(474, 23)
        Me.cmbEvaluaciones.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbEvaluaciones.TabIndex = 0
        Me.cmbEvaluaciones.ValueMember = "cod_evaluacion"
        '
        'txtFolio
        '
        '
        '
        '
        Me.txtFolio.Border.Class = "TextBoxBorder"
        Me.txtFolio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFolio.Enabled = False
        Me.txtFolio.Location = New System.Drawing.Point(114, 19)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.PreventEnterBeep = True
        Me.txtFolio.Size = New System.Drawing.Size(100, 20)
        Me.txtFolio.TabIndex = 83
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelar.Location = New System.Drawing.Point(527, 156)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 116
        Me.btnCancelar.Text = "Cancelar"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.Location = New System.Drawing.Point(445, 156)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.TabIndex = 115
        Me.btnAceptar.Text = "Aceptar"
        '
        'frmAgregarEvaluacionReclutamiento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 186)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.picImagen)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAgregarEvaluacionReclutamiento"
        Me.Text = "Agregar Evaluacion Reclutamiento"
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmbFiltro As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents cmbEvaluaciones As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents txtFolio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
End Class
