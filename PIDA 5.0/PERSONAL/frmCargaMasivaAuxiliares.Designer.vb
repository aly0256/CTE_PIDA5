<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargaMasivaAuxiliares
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCargaMasivaAuxiliares))
        Me.gpSueldos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.cbactualizar = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.cbInactivos = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.btnBuscaLista = New DevComponents.DotNetBar.ButtonX()
        Me.txtLista = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnLista = New System.Windows.Forms.RadioButton()
        Me.btnArchivo = New System.Windows.Forms.RadioButton()
        Me.btnBuscaArchivo = New DevComponents.DotNetBar.ButtonX()
        Me.txtArchivo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.txtValor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCia = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.cmbCampoaux = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbValorexis = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.cpActualizacion = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.dlgArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.gpSueldos.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpSueldos
        '
        Me.gpSueldos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpSueldos.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpSueldos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpSueldos.Controls.Add(Me.cbactualizar)
        Me.gpSueldos.Controls.Add(Me.cbInactivos)
        Me.gpSueldos.Controls.Add(Me.btnBuscaLista)
        Me.gpSueldos.Controls.Add(Me.txtLista)
        Me.gpSueldos.Controls.Add(Me.btnLista)
        Me.gpSueldos.Controls.Add(Me.btnArchivo)
        Me.gpSueldos.Controls.Add(Me.btnBuscaArchivo)
        Me.gpSueldos.Controls.Add(Me.txtArchivo)
        Me.gpSueldos.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpSueldos.Location = New System.Drawing.Point(14, 67)
        Me.gpSueldos.Name = "gpSueldos"
        Me.gpSueldos.Size = New System.Drawing.Size(478, 164)
        '
        '
        '
        Me.gpSueldos.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpSueldos.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpSueldos.Style.BackColorGradientAngle = 90
        Me.gpSueldos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpSueldos.Style.BorderBottomWidth = 1
        Me.gpSueldos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpSueldos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpSueldos.Style.BorderLeftWidth = 1
        Me.gpSueldos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpSueldos.Style.BorderRightWidth = 1
        Me.gpSueldos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpSueldos.Style.BorderTopWidth = 1
        Me.gpSueldos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpSueldos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpSueldos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpSueldos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpSueldos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpSueldos.TabIndex = 1
        Me.gpSueldos.Text = "Empleados a asignar"
        '
        'cbactualizar
        '
        Me.cbactualizar.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbactualizar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbactualizar.Checked = True
        Me.cbactualizar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbactualizar.CheckValue = "Y"
        Me.cbactualizar.Location = New System.Drawing.Point(161, 112)
        Me.cbactualizar.Name = "cbactualizar"
        Me.cbactualizar.Size = New System.Drawing.Size(171, 24)
        Me.cbactualizar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbactualizar.TabIndex = 7
        Me.cbactualizar.Text = "Actualizar auxiliares existentes"
        '
        'cbInactivos
        '
        Me.cbInactivos.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.cbInactivos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cbInactivos.Checked = True
        Me.cbInactivos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbInactivos.CheckValue = "Y"
        Me.cbInactivos.Location = New System.Drawing.Point(7, 111)
        Me.cbInactivos.Name = "cbInactivos"
        Me.cbInactivos.Size = New System.Drawing.Size(148, 24)
        Me.cbInactivos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cbInactivos.TabIndex = 6
        Me.cbInactivos.Text = "Incluir personal inactivo"
        '
        'btnBuscaLista
        '
        Me.btnBuscaLista.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscaLista.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscaLista.Enabled = False
        Me.btnBuscaLista.Location = New System.Drawing.Point(434, 83)
        Me.btnBuscaLista.Name = "btnBuscaLista"
        Me.btnBuscaLista.Size = New System.Drawing.Size(26, 23)
        Me.btnBuscaLista.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscaLista.TabIndex = 5
        Me.btnBuscaLista.Text = "..."
        '
        'txtLista
        '
        Me.txtLista.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtLista.Border.Class = "TextBoxBorder"
        Me.txtLista.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtLista.Enabled = False
        Me.txtLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLista.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLista.Location = New System.Drawing.Point(26, 83)
        Me.txtLista.Name = "txtLista"
        Me.txtLista.Size = New System.Drawing.Size(402, 23)
        Me.txtLista.TabIndex = 4
        '
        'btnLista
        '
        Me.btnLista.AutoSize = True
        Me.btnLista.BackColor = System.Drawing.SystemColors.Window
        Me.btnLista.Location = New System.Drawing.Point(7, 63)
        Me.btnLista.Name = "btnLista"
        Me.btnLista.Size = New System.Drawing.Size(232, 17)
        Me.btnLista.TabIndex = 3
        Me.btnLista.Text = "Listar números de reloj, separados por coma"
        Me.btnLista.UseVisualStyleBackColor = False
        '
        'btnArchivo
        '
        Me.btnArchivo.AutoSize = True
        Me.btnArchivo.BackColor = System.Drawing.SystemColors.Window
        Me.btnArchivo.Checked = True
        Me.btnArchivo.Location = New System.Drawing.Point(7, 13)
        Me.btnArchivo.Name = "btnArchivo"
        Me.btnArchivo.Size = New System.Drawing.Size(216, 17)
        Me.btnArchivo.TabIndex = 0
        Me.btnArchivo.TabStop = True
        Me.btnArchivo.Text = "Buscar en archivo (reloj [tabulador] dato)"
        Me.btnArchivo.UseVisualStyleBackColor = False
        '
        'btnBuscaArchivo
        '
        Me.btnBuscaArchivo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscaArchivo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscaArchivo.Location = New System.Drawing.Point(434, 33)
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
        Me.txtArchivo.Location = New System.Drawing.Point(26, 33)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.Size = New System.Drawing.Size(402, 23)
        Me.txtArchivo.TabIndex = 1
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(49, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(320, 46)
        Me.ReflectionLabel1.TabIndex = 113
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CARGA MASIVA AUXILIARES</b></font>"
        '
        'GroupPanel1
        '
        Me.GroupPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel1.Controls.Add(Me.txtValor)
        Me.GroupPanel1.Controls.Add(Me.Label1)
        Me.GroupPanel1.Controls.Add(Me.cmbCia)
        Me.GroupPanel1.Controls.Add(Me.cmbCampoaux)
        Me.GroupPanel1.Controls.Add(Me.Label6)
        Me.GroupPanel1.Controls.Add(Me.Label12)
        Me.GroupPanel1.Controls.Add(Me.cmbValorexis)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(14, 237)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(478, 169)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor = System.Drawing.SystemColors.Window
        Me.GroupPanel1.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 115
        Me.GroupPanel1.Text = "Información"
        '
        'txtValor
        '
        '
        '
        '
        Me.txtValor.Border.Class = "TextBoxBorder"
        Me.txtValor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValor.Location = New System.Drawing.Point(114, 65)
        Me.txtValor.Multiline = True
        Me.txtValor.Name = "txtValor"
        Me.txtValor.PreventEnterBeep = True
        Me.txtValor.Size = New System.Drawing.Size(346, 23)
        Me.txtValor.TabIndex = 87
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 15)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "Valor"
        '
        'cmbCia
        '
        Me.cmbCia.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbCia.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbCia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbCia.ButtonDropDown.Visible = True
        Me.cmbCia.DisplayMembers = "unico"
        Me.cmbCia.FormatString = "d"
        Me.cmbCia.FormattingEnabled = True
        Me.cmbCia.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbCia.Location = New System.Drawing.Point(114, 7)
        Me.cmbCia.Name = "cmbCia"
        Me.cmbCia.Size = New System.Drawing.Size(346, 23)
        Me.cmbCia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbCia.TabIndex = 0
        Me.cmbCia.ValueMember = "unico"
        '
        'cmbCampoaux
        '
        Me.cmbCampoaux.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbCampoaux.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbCampoaux.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbCampoaux.ButtonDropDown.Visible = True
        Me.cmbCampoaux.DisplayMembers = "concepto"
        Me.cmbCampoaux.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbCampoaux.Location = New System.Drawing.Point(114, 36)
        Me.cmbCampoaux.Name = "cmbCampoaux"
        Me.cmbCampoaux.Size = New System.Drawing.Size(346, 23)
        Me.cmbCampoaux.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbCampoaux.TabIndex = 1
        Me.cmbCampoaux.ValueMember = "concepto"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 15)
        Me.Label6.TabIndex = 84
        Me.Label6.Text = "Campo Aux."
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Window
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 7)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 15)
        Me.Label12.TabIndex = 80
        Me.Label12.Text = "Compañía"
        '
        'cmbValorexis
        '
        Me.cmbValorexis.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbValorexis.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbValorexis.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbValorexis.ButtonDropDown.Visible = True
        Me.cmbValorexis.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbValorexis.Location = New System.Drawing.Point(114, 65)
        Me.cmbValorexis.Name = "cmbValorexis"
        Me.cmbValorexis.Size = New System.Drawing.Size(346, 23)
        Me.cmbValorexis.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbValorexis.TabIndex = 88
        '
        'cpActualizacion
        '
        '
        '
        '
        Me.cpActualizacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cpActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cpActualizacion.Location = New System.Drawing.Point(14, 421)
        Me.cpActualizacion.Name = "cpActualizacion"
        Me.cpActualizacion.Size = New System.Drawing.Size(298, 25)
        Me.cpActualizacion.TabIndex = 120
        Me.cpActualizacion.Text = "Reloj"
        Me.cpActualizacion.TextVisible = True
        Me.cpActualizacion.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAceptar)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Location = New System.Drawing.Point(318, 407)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(174, 47)
        Me.GroupBox1.TabIndex = 121
        Me.GroupBox1.TabStop = False
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
        'dlgArchivo
        '
        Me.dlgArchivo.FileName = "OpenFileDialog1"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.CargaMasivaAux
        Me.picImagen.Location = New System.Drawing.Point(12, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(31, 30)
        Me.picImagen.TabIndex = 114
        Me.picImagen.TabStop = False
        '
        'frmCargaMasivaAuxiliares
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(513, 460)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cpActualizacion)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.picImagen)
        Me.Controls.Add(Me.gpSueldos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCargaMasivaAuxiliares"
        Me.Text = "Carga Masiva Auxiliares"
        Me.gpSueldos.ResumeLayout(False)
        Me.gpSueldos.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents gpSueldos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents cbInactivos As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents btnBuscaLista As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtLista As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnLista As System.Windows.Forms.RadioButton
    Friend WithEvents btnArchivo As System.Windows.Forms.RadioButton
    Friend WithEvents btnBuscaArchivo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtArchivo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Private WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCia As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cmbCampoaux As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cpActualizacion As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dlgArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtValor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cmbValorexis As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cbactualizar As DevComponents.DotNetBar.Controls.CheckBoxX
End Class
