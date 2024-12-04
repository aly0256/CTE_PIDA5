<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFacturacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFacturacion))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.dlgArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBase = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnBase = New DevComponents.DotNetBar.ButtonX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbCia = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.colCodigo = New DevComponents.AdvTree.ColumnHeader()
        Me.colNombre = New DevComponents.AdvTree.ColumnHeader()
        Me.cmbPeriodos = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.colSeleccionado = New DevComponents.AdvTree.ColumnHeader()
        Me.colAno = New DevComponents.AdvTree.ColumnHeader()
        Me.colPeriodo = New DevComponents.AdvTree.ColumnHeader()
        Me.colFechaIni = New DevComponents.AdvTree.ColumnHeader()
        Me.olcFechaFin = New DevComponents.AdvTree.ColumnHeader()
        Me.gpAvance = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.cpActualizacion = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.lblReloj = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnFactura = New DevComponents.DotNetBar.ButtonX()
        Me.txtFactura = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnSalir = New DevComponents.DotNetBar.ButtonX()
        Me.btnActualizar = New DevComponents.DotNetBar.ButtonX()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.dlgGuardar = New System.Windows.Forms.SaveFileDialog()
        Me.gpAvance.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.ReflectionLabel1.Size = New System.Drawing.Size(419, 40)
        Me.ReflectionLabel1.TabIndex = 93
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>FACTURACIÓN</b></font>"
        '
        'dlgArchivo
        '
        Me.dlgArchivo.FileName = "OpenFileDialog1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 17)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "Periodo"
        '
        'txtBase
        '
        '
        '
        '
        Me.txtBase.Border.Class = "TextBoxBorder"
        Me.txtBase.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBase.ButtonCustom.Tooltip = ""
        Me.txtBase.ButtonCustom2.Tooltip = ""
        Me.txtBase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBase.Location = New System.Drawing.Point(130, 122)
        Me.txtBase.MaxLength = 80
        Me.txtBase.Name = "txtBase"
        Me.txtBase.Size = New System.Drawing.Size(330, 21)
        Me.txtBase.TabIndex = 2
        '
        'btnBase
        '
        Me.btnBase.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBase.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBase.Location = New System.Drawing.Point(465, 122)
        Me.btnBase.Name = "btnBase"
        Me.btnBase.Size = New System.Drawing.Size(21, 21)
        Me.btnBase.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBase.TabIndex = 3
        Me.btnBase.Text = "..."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 17)
        Me.Label5.TabIndex = 104
        Me.Label5.Text = "Compañía"
        '
        'cmbCia
        '
        Me.cmbCia.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbCia.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbCia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbCia.ButtonClear.Tooltip = ""
        Me.cmbCia.ButtonCustom.Tooltip = ""
        Me.cmbCia.ButtonCustom2.Tooltip = ""
        Me.cmbCia.ButtonDropDown.Tooltip = ""
        Me.cmbCia.ButtonDropDown.Visible = True
        Me.cmbCia.Columns.Add(Me.colCodigo)
        Me.cmbCia.Columns.Add(Me.colNombre)
        Me.cmbCia.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbCia.Location = New System.Drawing.Point(130, 93)
        Me.cmbCia.Name = "cmbCia"
        Me.cmbCia.Size = New System.Drawing.Size(356, 23)
        Me.cmbCia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbCia.TabIndex = 1
        Me.cmbCia.ValueMember = "cod_comp"
        '
        'colCodigo
        '
        Me.colCodigo.DataFieldName = "cod_comp"
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.Text = "Código"
        Me.colCodigo.Width.Relative = 20
        '
        'colNombre
        '
        Me.colNombre.DataFieldName = "nombre"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.Text = "Nombre"
        Me.colNombre.Width.Relative = 80
        '
        'cmbPeriodos
        '
        Me.cmbPeriodos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPeriodos.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPeriodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPeriodos.ButtonClear.Tooltip = ""
        Me.cmbPeriodos.ButtonCustom.Tooltip = ""
        Me.cmbPeriodos.ButtonCustom2.Tooltip = ""
        Me.cmbPeriodos.ButtonDropDown.Tooltip = ""
        Me.cmbPeriodos.ButtonDropDown.Visible = True
        Me.cmbPeriodos.Columns.Add(Me.colSeleccionado)
        Me.cmbPeriodos.Columns.Add(Me.colAno)
        Me.cmbPeriodos.Columns.Add(Me.colPeriodo)
        Me.cmbPeriodos.Columns.Add(Me.colFechaIni)
        Me.cmbPeriodos.Columns.Add(Me.olcFechaFin)
        Me.cmbPeriodos.FormatString = "d"
        Me.cmbPeriodos.FormattingEnabled = True
        Me.cmbPeriodos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPeriodos.Location = New System.Drawing.Point(130, 64)
        Me.cmbPeriodos.Name = "cmbPeriodos"
        Me.cmbPeriodos.Size = New System.Drawing.Size(356, 23)
        Me.cmbPeriodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPeriodos.TabIndex = 0
        Me.cmbPeriodos.ValueMember = "seleccionado"
        '
        'colSeleccionado
        '
        Me.colSeleccionado.ColumnName = "seleccionado"
        Me.colSeleccionado.DataFieldName = "seleccionado"
        Me.colSeleccionado.Name = "colSeleccionado"
        Me.colSeleccionado.Text = "Column"
        Me.colSeleccionado.Visible = False
        '
        'colAno
        '
        Me.colAno.ColumnName = "ano"
        Me.colAno.DataFieldName = "ano"
        Me.colAno.Name = "colAno"
        Me.colAno.Text = "Año"
        Me.colAno.Width.Relative = 20
        '
        'colPeriodo
        '
        Me.colPeriodo.ColumnName = "periodo"
        Me.colPeriodo.DataFieldName = "periodo"
        Me.colPeriodo.Name = "colPeriodo"
        Me.colPeriodo.Text = "Periodo"
        Me.colPeriodo.Width.Relative = 20
        '
        'colFechaIni
        '
        Me.colFechaIni.ColumnName = "fecha_ini"
        Me.colFechaIni.DataFieldName = "fecha_ini"
        Me.colFechaIni.Name = "colFechaIni"
        Me.colFechaIni.Text = "Fecha inicial"
        Me.colFechaIni.Width.Relative = 30
        '
        'olcFechaFin
        '
        Me.olcFechaFin.ColumnName = "fecha_fin"
        Me.olcFechaFin.DataFieldName = "fecha_fin"
        Me.olcFechaFin.Name = "olcFechaFin"
        Me.olcFechaFin.Text = "Fecha final"
        Me.olcFechaFin.Width.Relative = 30
        '
        'gpAvance
        '
        Me.gpAvance.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpAvance.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpAvance.Controls.Add(Me.cpActualizacion)
        Me.gpAvance.Controls.Add(Me.lblReloj)
        Me.gpAvance.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpAvance.Location = New System.Drawing.Point(160, 18)
        Me.gpAvance.Name = "gpAvance"
        Me.gpAvance.Size = New System.Drawing.Size(173, 179)
        '
        '
        '
        Me.gpAvance.Style.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.gpAvance.Style.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption
        Me.gpAvance.Style.BackColorGradientAngle = 90
        Me.gpAvance.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpAvance.Style.BorderBottomWidth = 2
        Me.gpAvance.Style.BorderColor = System.Drawing.SystemColors.Highlight
        Me.gpAvance.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpAvance.Style.BorderLeftWidth = 1
        Me.gpAvance.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpAvance.Style.BorderRightWidth = 1
        Me.gpAvance.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpAvance.Style.BorderTopWidth = 1
        Me.gpAvance.Style.CornerDiameter = 4
        Me.gpAvance.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpAvance.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.gpAvance.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpAvance.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpAvance.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpAvance.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpAvance.TabIndex = 275
        Me.gpAvance.Visible = False
        '
        'cpActualizacion
        '
        Me.cpActualizacion.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        '
        '
        '
        Me.cpActualizacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cpActualizacion.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.cpActualizacion.BackgroundStyle.TextColor = System.Drawing.SystemColors.WindowText
        Me.cpActualizacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cpActualizacion.Location = New System.Drawing.Point(0, 0)
        Me.cpActualizacion.Maximum = 20
        Me.cpActualizacion.Name = "cpActualizacion"
        Me.cpActualizacion.ProgressColor = System.Drawing.SystemColors.HotTrack
        Me.cpActualizacion.ProgressTextVisible = True
        Me.cpActualizacion.Size = New System.Drawing.Size(171, 131)
        Me.cpActualizacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cpActualizacion.TabIndex = 274
        '
        'lblReloj
        '
        Me.lblReloj.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblReloj.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReloj.Location = New System.Drawing.Point(0, 131)
        Me.lblReloj.Name = "lblReloj"
        Me.lblReloj.Size = New System.Drawing.Size(171, 45)
        Me.lblReloj.TabIndex = 273
        Me.lblReloj.Text = "Reloj"
        Me.lblReloj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(17, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 17)
        Me.Label6.TabIndex = 276
        Me.Label6.Text = "Excel base"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 17)
        Me.Label2.TabIndex = 279
        Me.Label2.Text = "Factura (.xlsx)"
        '
        'btnFactura
        '
        Me.btnFactura.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnFactura.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnFactura.Location = New System.Drawing.Point(465, 149)
        Me.btnFactura.Name = "btnFactura"
        Me.btnFactura.Size = New System.Drawing.Size(21, 21)
        Me.btnFactura.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnFactura.TabIndex = 5
        Me.btnFactura.Text = "..."
        '
        'txtFactura
        '
        '
        '
        '
        Me.txtFactura.Border.Class = "TextBoxBorder"
        Me.txtFactura.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFactura.ButtonCustom.Tooltip = ""
        Me.txtFactura.ButtonCustom2.Tooltip = ""
        Me.txtFactura.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFactura.Location = New System.Drawing.Point(130, 149)
        Me.txtFactura.MaxLength = 80
        Me.txtFactura.Name = "txtFactura"
        Me.txtFactura.Size = New System.Drawing.Size(330, 21)
        Me.txtFactura.TabIndex = 4
        '
        'btnSalir
        '
        Me.btnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSalir.CausesValidation = False
        Me.btnSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnSalir.Location = New System.Drawing.Point(410, 176)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(78, 25)
        Me.btnSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSalir.TabIndex = 7
        Me.btnSalir.Text = "Salir"
        '
        'btnActualizar
        '
        Me.btnActualizar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnActualizar.CausesValidation = False
        Me.btnActualizar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizar.Image = Global.PIDA.My.Resources.Resources.Invoice16
        Me.btnActualizar.Location = New System.Drawing.Point(326, 176)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(78, 25)
        Me.btnActualizar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnActualizar.TabIndex = 6
        Me.btnActualizar.Text = "Generar"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.Invoice32
        Me.picImagen.Location = New System.Drawing.Point(12, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(27, 35)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picImagen.TabIndex = 94
        Me.picImagen.TabStop = False
        '
        'frmFacturacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(493, 214)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnFactura)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.gpAvance)
        Me.Controls.Add(Me.cmbPeriodos)
        Me.Controls.Add(Me.cmbCia)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnBase)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtBase)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.picImagen)
        Me.Controls.Add(Me.txtFactura)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFacturacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PIDA"
        Me.gpAvance.ResumeLayout(False)
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents btnActualizar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSalir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dlgArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBase As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnBase As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbCia As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents colCodigo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colNombre As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents cmbPeriodos As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents colSeleccionado As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colAno As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colPeriodo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colFechaIni As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents olcFechaFin As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents gpAvance As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lblReloj As System.Windows.Forms.Label
    Friend WithEvents cpActualizacion As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnFactura As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtFactura As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents dlgGuardar As System.Windows.Forms.SaveFileDialog
End Class
