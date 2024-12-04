<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExportar
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExportar))
        Me.dlgArchivo = New System.Windows.Forms.SaveFileDialog()
        Me.btnExportar = New DevComponents.DotNetBar.ButtonX()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.cmbAnoPeriodo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gpDatos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.cmbTipoPeriodo = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.itmSemanal = New DevComponents.Editors.ComboItem()
        Me.itmQuincenal = New DevComponents.Editors.ComboItem()
        Me.itmMensual = New DevComponents.Editors.ComboItem()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbCia = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader6 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader7 = New DevComponents.AdvTree.ColumnHeader()
        Me.chkComplementaria = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkCompleta = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.sbMarcarExportados = New DevComponents.DotNetBar.Controls.SwitchButton()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExportar
        '
        Me.btnExportar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnExportar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnExportar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnExportar.Location = New System.Drawing.Point(336, 285)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(78, 25)
        Me.btnExportar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnExportar.TabIndex = 0
        Me.btnExportar.Text = "Aceptar"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Window
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(14, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 15)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Año/periodo"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(50, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(451, 46)
        Me.ReflectionLabel1.TabIndex = 3
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>EXPORTAR AJUSTES Y DEDUCCIONES</b></font>"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.Export32
        Me.picImagen.Location = New System.Drawing.Point(12, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(32, 46)
        Me.picImagen.TabIndex = 114
        Me.picImagen.TabStop = False
        '
        'cmbAnoPeriodo
        '
        Me.cmbAnoPeriodo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbAnoPeriodo.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbAnoPeriodo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbAnoPeriodo.ButtonDropDown.Visible = True
        Me.cmbAnoPeriodo.Columns.Add(Me.ColumnHeader1)
        Me.cmbAnoPeriodo.Columns.Add(Me.ColumnHeader2)
        Me.cmbAnoPeriodo.Columns.Add(Me.ColumnHeader3)
        Me.cmbAnoPeriodo.Columns.Add(Me.ColumnHeader4)
        Me.cmbAnoPeriodo.Columns.Add(Me.ColumnHeader5)
        Me.cmbAnoPeriodo.DropDownHeight = 180
        Me.cmbAnoPeriodo.FormatString = "d"
        Me.cmbAnoPeriodo.FormattingEnabled = True
        Me.cmbAnoPeriodo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbAnoPeriodo.Location = New System.Drawing.Point(135, 76)
        Me.cmbAnoPeriodo.Name = "cmbAnoPeriodo"
        Me.cmbAnoPeriodo.Size = New System.Drawing.Size(333, 23)
        Me.cmbAnoPeriodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbAnoPeriodo.TabIndex = 5
        Me.cmbAnoPeriodo.ValueMember = "unico"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "unico"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "unico"
        Me.ColumnHeader1.Visible = False
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "ano"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Año"
        Me.ColumnHeader2.Width.Relative = 20
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DataFieldName = "periodo"
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Periodo"
        Me.ColumnHeader3.Width.Relative = 20
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DataFieldName = "fecha_ini"
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "Fecha inicial"
        Me.ColumnHeader4.Width.Relative = 30
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DataFieldName = "fecha_fin"
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.Text = "Fecha final"
        Me.ColumnHeader5.Width.Relative = 30
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Tipo de exportación"
        '
        'gpDatos
        '
        Me.gpDatos.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpDatos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpDatos.Controls.Add(Me.sbMarcarExportados)
        Me.gpDatos.Controls.Add(Me.cmbTipoPeriodo)
        Me.gpDatos.Controls.Add(Me.Label3)
        Me.gpDatos.Controls.Add(Me.Label2)
        Me.gpDatos.Controls.Add(Me.cmbCia)
        Me.gpDatos.Controls.Add(Me.chkComplementaria)
        Me.gpDatos.Controls.Add(Me.chkCompleta)
        Me.gpDatos.Controls.Add(Me.Label12)
        Me.gpDatos.Controls.Add(Me.Label1)
        Me.gpDatos.Controls.Add(Me.cmbAnoPeriodo)
        Me.gpDatos.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpDatos.Location = New System.Drawing.Point(12, 64)
        Me.gpDatos.Name = "gpDatos"
        Me.gpDatos.Size = New System.Drawing.Size(486, 215)
        '
        '
        '
        Me.gpDatos.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpDatos.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpDatos.Style.BackColorGradientAngle = 90
        Me.gpDatos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDatos.Style.BorderBottomWidth = 1
        Me.gpDatos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpDatos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDatos.Style.BorderLeftWidth = 1
        Me.gpDatos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDatos.Style.BorderRightWidth = 1
        Me.gpDatos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDatos.Style.BorderTopWidth = 1
        Me.gpDatos.Style.CornerDiameter = 4
        Me.gpDatos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpDatos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.gpDatos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpDatos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpDatos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpDatos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpDatos.TabIndex = 2
        '
        'cmbTipoPeriodo
        '
        Me.cmbTipoPeriodo.DisplayMember = "Text"
        Me.cmbTipoPeriodo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTipoPeriodo.FormattingEnabled = True
        Me.cmbTipoPeriodo.ItemHeight = 15
        Me.cmbTipoPeriodo.Items.AddRange(New Object() {Me.itmSemanal, Me.itmQuincenal, Me.itmMensual})
        Me.cmbTipoPeriodo.Location = New System.Drawing.Point(135, 49)
        Me.cmbTipoPeriodo.Name = "cmbTipoPeriodo"
        Me.cmbTipoPeriodo.Size = New System.Drawing.Size(333, 21)
        Me.cmbTipoPeriodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipoPeriodo.TabIndex = 3
        '
        'itmSemanal
        '
        Me.itmSemanal.Text = "SEMANAL"
        Me.itmSemanal.Value = "S"
        '
        'itmQuincenal
        '
        Me.itmQuincenal.Text = "QUINCENAL"
        Me.itmQuincenal.Value = "Q"
        '
        'itmMensual
        '
        Me.itmMensual.Text = "MENSUAL"
        Me.itmMensual.Value = "M"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Tipo de periodo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Compañía"
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
        Me.cmbCia.Columns.Add(Me.ColumnHeader6)
        Me.cmbCia.Columns.Add(Me.ColumnHeader7)
        Me.cmbCia.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbCia.Location = New System.Drawing.Point(135, 20)
        Me.cmbCia.Name = "cmbCia"
        Me.cmbCia.Size = New System.Drawing.Size(333, 23)
        Me.cmbCia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbCia.TabIndex = 1
        Me.cmbCia.ValueMember = "cod_comp"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.DataFieldName = "cod_comp"
        Me.ColumnHeader6.Name = "ColumnHeader6"
        Me.ColumnHeader6.Text = "Código"
        Me.ColumnHeader6.Width.Relative = 30
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.DataFieldName = "nombre"
        Me.ColumnHeader7.Name = "ColumnHeader7"
        Me.ColumnHeader7.StretchToFill = True
        Me.ColumnHeader7.Text = "Nombre"
        Me.ColumnHeader7.Width.AutoSize = True
        Me.ColumnHeader7.Width.Relative = 70
        '
        'chkComplementaria
        '
        Me.chkComplementaria.AutoSize = True
        Me.chkComplementaria.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkComplementaria.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkComplementaria.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkComplementaria.Enabled = False
        Me.chkComplementaria.Location = New System.Drawing.Point(357, 194)
        Me.chkComplementaria.Name = "chkComplementaria"
        Me.chkComplementaria.Size = New System.Drawing.Size(111, 16)
        Me.chkComplementaria.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkComplementaria.TabIndex = 8
        Me.chkComplementaria.Text = "Complementaria"
        Me.ToolTip1.SetToolTip(Me.chkComplementaria, "Cambios desde última exportación")
        Me.chkComplementaria.Visible = False
        '
        'chkCompleta
        '
        Me.chkCompleta.AutoSize = True
        Me.chkCompleta.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkCompleta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkCompleta.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkCompleta.Checked = True
        Me.chkCompleta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCompleta.CheckValue = "Y"
        Me.chkCompleta.Location = New System.Drawing.Point(277, 194)
        Me.chkCompleta.Name = "chkCompleta"
        Me.chkCompleta.Size = New System.Drawing.Size(74, 16)
        Me.chkCompleta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkCompleta.TabIndex = 7
        Me.chkCompleta.Text = "Completa"
        Me.ToolTip1.SetToolTip(Me.chkCompleta, "Todos los ajustes y deducciones")
        Me.chkCompleta.Visible = False
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelar.Location = New System.Drawing.Point(420, 285)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "Cancelar"
        '
        'sbMarcarExportados
        '
        '
        '
        '
        Me.sbMarcarExportados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.sbMarcarExportados.Location = New System.Drawing.Point(135, 112)
        Me.sbMarcarExportados.Name = "sbMarcarExportados"
        Me.sbMarcarExportados.OffText = "Revisión"
        Me.sbMarcarExportados.OnText = "Definitiva"
        Me.sbMarcarExportados.Size = New System.Drawing.Size(126, 22)
        Me.sbMarcarExportados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.sbMarcarExportados.TabIndex = 115
        '
        'frmExportar
        '
        Me.AcceptButton = Me.btnExportar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(511, 322)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.gpDatos)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.picImagen)
        Me.Controls.Add(Me.btnExportar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExportar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Exportar ajustes"
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpDatos.ResumeLayout(False)
        Me.gpDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dlgArchivo As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnExportar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents cmbAnoPeriodo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents gpDatos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents chkComplementaria As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents chkCompleta As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbCia As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents ColumnHeader6 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader7 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents cmbTipoPeriodo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents itmSemanal As DevComponents.Editors.ComboItem
    Friend WithEvents itmQuincenal As DevComponents.Editors.ComboItem
    Friend WithEvents itmMensual As DevComponents.Editors.ComboItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents sbMarcarExportados As DevComponents.DotNetBar.Controls.SwitchButton
End Class
