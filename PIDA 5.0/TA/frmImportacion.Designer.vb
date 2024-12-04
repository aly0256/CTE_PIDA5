<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportacion))
        Me.cmbPeriodo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.colUnico = New DevComponents.AdvTree.ColumnHeader()
        Me.colAno = New DevComponents.AdvTree.ColumnHeader()
        Me.Periodo = New DevComponents.AdvTree.ColumnHeader()
        Me.colIni = New DevComponents.AdvTree.ColumnHeader()
        Me.colFin = New DevComponents.AdvTree.ColumnHeader()
        Me.txtArchivo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnArchivo = New DevComponents.DotNetBar.ButtonX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.pnlDetalle = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.pnlPeriodo = New System.Windows.Forms.Panel()
        Me.pnlArchivo = New System.Windows.Forms.Panel()
        Me.dbArchivos = New System.Windows.Forms.OpenFileDialog()
        Me.btnOk = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlDetalle.SuspendLayout()
        Me.pnlPeriodo.SuspendLayout()
        Me.pnlArchivo.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbPeriodo
        '
        Me.cmbPeriodo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPeriodo.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPeriodo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPeriodo.ButtonClear.Tooltip = ""
        Me.cmbPeriodo.ButtonCustom.Tooltip = ""
        Me.cmbPeriodo.ButtonCustom2.Tooltip = ""
        Me.cmbPeriodo.ButtonDropDown.Tooltip = ""
        Me.cmbPeriodo.ButtonDropDown.Visible = True
        Me.cmbPeriodo.Columns.Add(Me.colUnico)
        Me.cmbPeriodo.Columns.Add(Me.colAno)
        Me.cmbPeriodo.Columns.Add(Me.Periodo)
        Me.cmbPeriodo.Columns.Add(Me.colIni)
        Me.cmbPeriodo.Columns.Add(Me.colFin)
        Me.cmbPeriodo.FormatString = "d"
        Me.cmbPeriodo.FormattingEnabled = True
        Me.cmbPeriodo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPeriodo.Location = New System.Drawing.Point(78, 9)
        Me.cmbPeriodo.Name = "cmbPeriodo"
        Me.cmbPeriodo.Size = New System.Drawing.Size(402, 23)
        Me.cmbPeriodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPeriodo.TabIndex = 0
        Me.cmbPeriodo.ValueMember = "unico"
        '
        'colUnico
        '
        Me.colUnico.DataFieldName = "unico"
        Me.colUnico.Name = "colUnico"
        Me.colUnico.Text = "UNICO"
        Me.colUnico.Visible = False
        Me.colUnico.Width.Absolute = 150
        '
        'colAno
        '
        Me.colAno.DataFieldName = "ano"
        Me.colAno.Name = "colAno"
        Me.colAno.Text = "AÑO"
        Me.colAno.Width.Relative = 15
        '
        'Periodo
        '
        Me.Periodo.DataFieldName = "periodo"
        Me.Periodo.Name = "Periodo"
        Me.Periodo.Text = "PERIODO"
        Me.Periodo.Width.Relative = 15
        '
        'colIni
        '
        Me.colIni.DataFieldName = "fecha_ini"
        Me.colIni.Name = "colIni"
        Me.colIni.Text = "FECHA INICIAL"
        Me.colIni.Width.Relative = 35
        '
        'colFin
        '
        Me.colFin.DataFieldName = "fecha_fin"
        Me.colFin.Name = "colFin"
        Me.colFin.Text = "FECHA FINAL"
        Me.colFin.Width.Relative = 35
        '
        'txtArchivo
        '
        '
        '
        '
        Me.txtArchivo.Border.Class = "TextBoxBorder"
        Me.txtArchivo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtArchivo.ButtonCustom.Tooltip = ""
        Me.txtArchivo.ButtonCustom2.Tooltip = ""
        Me.txtArchivo.Location = New System.Drawing.Point(78, 10)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.PreventEnterBeep = True
        Me.txtArchivo.Size = New System.Drawing.Size(375, 20)
        Me.txtArchivo.TabIndex = 1
        '
        'btnArchivo
        '
        Me.btnArchivo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnArchivo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnArchivo.Location = New System.Drawing.Point(459, 10)
        Me.btnArchivo.Name = "btnArchivo"
        Me.btnArchivo.Size = New System.Drawing.Size(21, 20)
        Me.btnArchivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnArchivo.TabIndex = 2
        Me.btnArchivo.Text = "..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Location = New System.Drawing.Point(19, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Archivo"
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.BackColor = System.Drawing.SystemColors.Window
        Me.lblPeriodo.Location = New System.Drawing.Point(19, 14)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(43, 13)
        Me.lblPeriodo.TabIndex = 4
        Me.lblPeriodo.Text = "Periodo"
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
        Me.ReflectionLabel1.Size = New System.Drawing.Size(455, 40)
        Me.ReflectionLabel1.TabIndex = 96
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>IMPORTACIÓN DE HORAS</b></font>"
        '
        'pnlDetalle
        '
        Me.pnlDetalle.CanvasColor = System.Drawing.SystemColors.Control
        Me.pnlDetalle.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.pnlDetalle.Controls.Add(Me.pnlPeriodo)
        Me.pnlDetalle.Controls.Add(Me.pnlArchivo)
        Me.pnlDetalle.DisabledBackColor = System.Drawing.Color.Empty
        Me.pnlDetalle.Location = New System.Drawing.Point(12, 58)
        Me.pnlDetalle.Name = "pnlDetalle"
        Me.pnlDetalle.Size = New System.Drawing.Size(503, 85)
        '
        '
        '
        Me.pnlDetalle.Style.BackColor = System.Drawing.SystemColors.Window
        Me.pnlDetalle.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.pnlDetalle.Style.BackColorGradientAngle = 90
        Me.pnlDetalle.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.pnlDetalle.Style.BorderBottomWidth = 1
        Me.pnlDetalle.Style.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.pnlDetalle.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.pnlDetalle.Style.BorderLeftWidth = 1
        Me.pnlDetalle.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.pnlDetalle.Style.BorderRightWidth = 1
        Me.pnlDetalle.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.pnlDetalle.Style.BorderTopWidth = 1
        Me.pnlDetalle.Style.CornerDiameter = 4
        Me.pnlDetalle.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pnlDetalle.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.pnlDetalle.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.pnlDetalle.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.pnlDetalle.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.pnlDetalle.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pnlDetalle.TabIndex = 98
        '
        'pnlPeriodo
        '
        Me.pnlPeriodo.BackColor = System.Drawing.SystemColors.Window
        Me.pnlPeriodo.Controls.Add(Me.lblPeriodo)
        Me.pnlPeriodo.Controls.Add(Me.cmbPeriodo)
        Me.pnlPeriodo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlPeriodo.Location = New System.Drawing.Point(0, 0)
        Me.pnlPeriodo.Name = "pnlPeriodo"
        Me.pnlPeriodo.Size = New System.Drawing.Size(501, 44)
        Me.pnlPeriodo.TabIndex = 101
        '
        'pnlArchivo
        '
        Me.pnlArchivo.BackColor = System.Drawing.SystemColors.Window
        Me.pnlArchivo.Controls.Add(Me.Label1)
        Me.pnlArchivo.Controls.Add(Me.txtArchivo)
        Me.pnlArchivo.Controls.Add(Me.btnArchivo)
        Me.pnlArchivo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlArchivo.Location = New System.Drawing.Point(0, 44)
        Me.pnlArchivo.Name = "pnlArchivo"
        Me.pnlArchivo.Size = New System.Drawing.Size(501, 39)
        Me.pnlArchivo.TabIndex = 101
        Me.pnlArchivo.Visible = False
        '
        'dbArchivos
        '
        Me.dbArchivos.FileName = "OpenFileDialog1"
        '
        'btnOk
        '
        Me.btnOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnOk.CausesValidation = False
        Me.btnOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnOk.Location = New System.Drawing.Point(329, 149)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(91, 29)
        Me.btnOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnOk.TabIndex = 99
        Me.btnOk.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelar.Location = New System.Drawing.Point(424, 149)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(91, 29)
        Me.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancelar.TabIndex = 100
        Me.btnCancelar.Text = "Cancelar"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Download32
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(27, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 97
        Me.PictureBox1.TabStop = False
        '
        'frmImportacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(528, 183)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.pnlDetalle)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportacion"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importación"
        Me.pnlDetalle.ResumeLayout(False)
        Me.pnlPeriodo.ResumeLayout(False)
        Me.pnlPeriodo.PerformLayout()
        Me.pnlArchivo.ResumeLayout(False)
        Me.pnlArchivo.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbPeriodo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents txtArchivo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnArchivo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents pnlDetalle As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents colUnico As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colAno As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Periodo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colIni As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colFin As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents btnOk As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dbArchivos As System.Windows.Forms.OpenFileDialog
    Friend WithEvents pnlArchivo As System.Windows.Forms.Panel
    Friend WithEvents pnlPeriodo As System.Windows.Forms.Panel
End Class
