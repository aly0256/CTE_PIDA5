<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConceptoNVO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConceptoNVO))
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.btnComparativo = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.IntPrioridad = New DevComponents.Editors.IntegerInput()
        Me.btnPositivo = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.btnAfecta = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbNaturaleza = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.EmpNav = New System.Windows.Forms.GroupBox()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.IntPrioridad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EmpNav.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnEditar.Location = New System.Drawing.Point(90, 14)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(78, 25)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 7
        Me.btnEditar.Text = "Cancelar"
        '
        'btnComparativo
        '
        '
        '
        '
        Me.btnComparativo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnComparativo.Location = New System.Drawing.Point(124, 203)
        Me.btnComparativo.Name = "btnComparativo"
        Me.btnComparativo.OffText = "NO"
        Me.btnComparativo.OnText = "SI"
        Me.btnComparativo.Size = New System.Drawing.Size(66, 22)
        Me.btnComparativo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnComparativo.TabIndex = 86
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(30, 199)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 30)
        Me.Label4.TabIndex = 85
        Me.Label4.Text = "Comparativo " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de nómina"
        '
        'IntPrioridad
        '
        '
        '
        '
        Me.IntPrioridad.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.IntPrioridad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.IntPrioridad.ButtonCalculator.Tooltip = ""
        Me.IntPrioridad.ButtonClear.Tooltip = ""
        Me.IntPrioridad.ButtonCustom.Tooltip = ""
        Me.IntPrioridad.ButtonCustom2.Tooltip = ""
        Me.IntPrioridad.ButtonDropDown.Tooltip = ""
        Me.IntPrioridad.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.IntPrioridad.ButtonFreeText.Tooltip = ""
        Me.IntPrioridad.Increment = 10
        Me.IntPrioridad.Location = New System.Drawing.Point(124, 111)
        Me.IntPrioridad.Name = "IntPrioridad"
        Me.IntPrioridad.ShowUpDown = True
        Me.IntPrioridad.Size = New System.Drawing.Size(66, 20)
        Me.IntPrioridad.TabIndex = 3
        Me.IntPrioridad.Value = 900
        '
        'btnPositivo
        '
        '
        '
        '
        Me.btnPositivo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnPositivo.Location = New System.Drawing.Point(124, 171)
        Me.btnPositivo.Name = "btnPositivo"
        Me.btnPositivo.OffText = "NO"
        Me.btnPositivo.OnText = "SI"
        Me.btnPositivo.Size = New System.Drawing.Size(66, 22)
        Me.btnPositivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPositivo.TabIndex = 5
        '
        'btnAfecta
        '
        '
        '
        '
        Me.btnAfecta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnAfecta.Location = New System.Drawing.Point(124, 140)
        Me.btnAfecta.Name = "btnAfecta"
        Me.btnAfecta.OffText = "NO"
        Me.btnAfecta.OnText = "SI"
        Me.btnAfecta.Size = New System.Drawing.Size(66, 22)
        Me.btnAfecta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAfecta.TabIndex = 4
        Me.btnAfecta.Value = True
        Me.btnAfecta.ValueObject = "Y"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 175)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 15)
        Me.Label3.TabIndex = 84
        Me.Label3.Text = "Positivo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(30, 144)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 15)
        Me.Label5.TabIndex = 82
        Me.Label5.Text = "Afecta al neto"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(30, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 15)
        Me.Label6.TabIndex = 78
        Me.Label6.Text = "Prioridad"
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.BackColor = System.Drawing.SystemColors.Window
        Me.lbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.Location = New System.Drawing.Point(30, 85)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(67, 15)
        Me.lbl1.TabIndex = 75
        Me.lbl1.Text = "Naturaleza"
        '
        'txtCodigo
        '
        '
        '
        '
        Me.txtCodigo.Border.Class = "TextBoxBorder"
        Me.txtCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodigo.ButtonCustom.Tooltip = ""
        Me.txtCodigo.ButtonCustom2.Tooltip = ""
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(124, 22)
        Me.txtCodigo.MaxLength = 10
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(66, 21)
        Me.txtCodigo.TabIndex = 0
        '
        'txtNombre
        '
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.ButtonCustom.Tooltip = ""
        Me.txtNombre.ButtonCustom2.Tooltip = ""
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(124, 52)
        Me.txtNombre.MaxLength = 80
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(362, 21)
        Me.txtNombre.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 15)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Descripción"
        '
        'cmbNaturaleza
        '
        Me.cmbNaturaleza.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbNaturaleza.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbNaturaleza.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbNaturaleza.ButtonClear.Tooltip = ""
        Me.cmbNaturaleza.ButtonCustom.Tooltip = ""
        Me.cmbNaturaleza.ButtonCustom2.Tooltip = ""
        Me.cmbNaturaleza.ButtonDropDown.Tooltip = ""
        Me.cmbNaturaleza.ButtonDropDown.Visible = True
        Me.cmbNaturaleza.Columns.Add(Me.ColumnHeader1)
        Me.cmbNaturaleza.Columns.Add(Me.ColumnHeader2)
        Me.cmbNaturaleza.DisplayMembers = "cod_comp"
        Me.cmbNaturaleza.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbNaturaleza.Location = New System.Drawing.Point(124, 82)
        Me.cmbNaturaleza.Name = "cmbNaturaleza"
        Me.cmbNaturaleza.Size = New System.Drawing.Size(361, 20)
        Me.cmbNaturaleza.TabIndex = 2
        Me.cmbNaturaleza.ValueMember = "cod_naturaleza"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "cod_naturaleza"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Código"
        Me.ColumnHeader1.Width.Absolute = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "nombre"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.StretchToFill = True
        Me.ColumnHeader2.Text = "Naturaleza"
        Me.ColumnHeader2.Width.Absolute = 150
        Me.ColumnHeader2.Width.AutoSize = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 15)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Concepto"
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnNuevo.Location = New System.Drawing.Point(9, 14)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 25)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 6
        Me.btnNuevo.Text = "Aceptar"
        '
        'EmpNav
        '
        Me.EmpNav.Controls.Add(Me.btnEditar)
        Me.EmpNav.Controls.Add(Me.btnNuevo)
        Me.EmpNav.Location = New System.Drawing.Point(178, 356)
        Me.EmpNav.Name = "EmpNav"
        Me.EmpNav.Size = New System.Drawing.Size(177, 47)
        Me.EmpNav.TabIndex = 80
        Me.EmpNav.TabStop = False
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(45, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(473, 40)
        Me.ReflectionLabel1.TabIndex = 82
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CONCEPTO NUEVO</b></font>"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.catalog32
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.TabIndex = 83
        Me.PictureBox1.TabStop = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel1.Controls.Add(Me.btnComparativo)
        Me.GroupPanel1.Controls.Add(Me.Label1)
        Me.GroupPanel1.Controls.Add(Me.Label4)
        Me.GroupPanel1.Controls.Add(Me.cmbNaturaleza)
        Me.GroupPanel1.Controls.Add(Me.IntPrioridad)
        Me.GroupPanel1.Controls.Add(Me.Label2)
        Me.GroupPanel1.Controls.Add(Me.txtNombre)
        Me.GroupPanel1.Controls.Add(Me.btnPositivo)
        Me.GroupPanel1.Controls.Add(Me.txtCodigo)
        Me.GroupPanel1.Controls.Add(Me.btnAfecta)
        Me.GroupPanel1.Controls.Add(Me.lbl1)
        Me.GroupPanel1.Controls.Add(Me.Label3)
        Me.GroupPanel1.Controls.Add(Me.Label6)
        Me.GroupPanel1.Controls.Add(Me.Label5)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(12, 91)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(506, 259)
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
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
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
        Me.GroupPanel1.TabIndex = 84
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Highlight
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.Label8.Location = New System.Drawing.Point(12, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(506, 35)
        Me.Label8.TabIndex = 85
        Me.Label8.Text = "El concepto no fue localizado. Favor de capturar los datos faltantes."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmConceptoNVO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 417)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.EmpNav)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConceptoNVO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura concepto nuevo"
        CType(Me.IntPrioridad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EmpNav.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnComparativo As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents IntPrioridad As DevComponents.Editors.IntegerInput
    Friend WithEvents btnPositivo As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents btnAfecta As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents cmbNaturaleza As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EmpNav As System.Windows.Forms.GroupBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
