<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActualizarVariables
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmActualizarVariables))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.cpActualizacion = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.dlgArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.lblReloj = New System.Windows.Forms.Label()
        Me.pnlControles = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
        Me.btnActualizar = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.btnSimular = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.btnSalir = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.cmbPeriodos = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.colUnico = New DevComponents.AdvTree.ColumnHeader()
        Me.colActivo = New DevComponents.AdvTree.ColumnHeader()
        Me.colAno = New DevComponents.AdvTree.ColumnHeader()
        Me.colPeriodo = New DevComponents.AdvTree.ColumnHeader()
        Me.colFechaIni = New DevComponents.AdvTree.ColumnHeader()
        Me.colFechaFin = New DevComponents.AdvTree.ColumnHeader()
        Me.picImagen = New System.Windows.Forms.PictureBox()
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
        Me.ReflectionLabel1.Size = New System.Drawing.Size(499, 54)
        Me.ReflectionLabel1.TabIndex = 93
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>ACTUALIZACIÓN DE PROMEDIOS VARIABLES</b></font>"
        '
        'cpActualizacion
        '
        '
        '
        '
        Me.cpActualizacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cpActualizacion.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.cpActualizacion.BackgroundStyle.TextColor = System.Drawing.SystemColors.WindowText
        Me.cpActualizacion.Location = New System.Drawing.Point(45, 195)
        Me.cpActualizacion.Maximum = 20
        Me.cpActualizacion.Name = "cpActualizacion"
        Me.cpActualizacion.ProgressColor = System.Drawing.SystemColors.HotTrack
        Me.cpActualizacion.ProgressTextVisible = True
        Me.cpActualizacion.Size = New System.Drawing.Size(454, 139)
        Me.cpActualizacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cpActualizacion.TabIndex = 96
        Me.cpActualizacion.Visible = False
        '
        'dlgArchivo
        '
        Me.dlgArchivo.FileName = "OpenFileDialog1"
        '
        'lblReloj
        '
        Me.lblReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReloj.Location = New System.Drawing.Point(45, 383)
        Me.lblReloj.Name = "lblReloj"
        Me.lblReloj.Size = New System.Drawing.Size(454, 23)
        Me.lblReloj.TabIndex = 100
        Me.lblReloj.Text = "Label1"
        Me.lblReloj.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlControles
        '
        '
        '
        '
        Me.pnlControles.BackgroundStyle.BackColor = System.Drawing.SystemColors.Control
        Me.pnlControles.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.pnlControles.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.pnlControles.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.pnlControles.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.pnlControles.BackgroundStyle.Class = "MetroTilePanel"
        Me.pnlControles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pnlControles.ContainerControlProcessDialogKey = True
        Me.pnlControles.DragDropSupport = True
        Me.pnlControles.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1})
        Me.pnlControles.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.pnlControles.Location = New System.Drawing.Point(30, 62)
        Me.pnlControles.Name = "pnlControles"
        Me.pnlControles.Size = New System.Drawing.Size(488, 96)
        Me.pnlControles.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pnlControles.TabIndex = 101
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.MultiLine = True
        Me.ItemContainer1.Name = "ItemContainer1"
        Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnActualizar, Me.btnSimular, Me.btnSalir})
        '
        '
        '
        Me.ItemContainer1.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'btnActualizar
        '
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Symbol = ""
        Me.btnActualizar.SymbolColor = System.Drawing.Color.Empty
        Me.btnActualizar.SymbolSize = 32.0!
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Green
        Me.btnActualizar.TileSize = New System.Drawing.Size(150, 60)
        '
        '
        '
        Me.btnActualizar.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnActualizar.TileStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnActualizar.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        '
        'btnSimular
        '
        Me.btnSimular.Name = "btnSimular"
        Me.btnSimular.Symbol = ""
        Me.btnSimular.SymbolColor = System.Drawing.Color.Empty
        Me.btnSimular.SymbolSize = 32.0!
        Me.btnSimular.Text = "Simular actualización"
        Me.btnSimular.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Maroon
        Me.btnSimular.TileSize = New System.Drawing.Size(150, 60)
        '
        '
        '
        Me.btnSimular.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnSimular.TileStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSimular.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        '
        'btnSalir
        '
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Symbol = ""
        Me.btnSalir.SymbolColor = System.Drawing.Color.Empty
        Me.btnSalir.SymbolSize = 32.0!
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.btnSalir.TileSize = New System.Drawing.Size(150, 60)
        '
        '
        '
        Me.btnSalir.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnSalir.TileStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        '
        'cmbPeriodos
        '
        Me.cmbPeriodos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPeriodos.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPeriodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPeriodos.ButtonCustom.Checked = True
        Me.cmbPeriodos.ButtonDropDown.Visible = True
        Me.cmbPeriodos.Columns.Add(Me.colUnico)
        Me.cmbPeriodos.Columns.Add(Me.colActivo)
        Me.cmbPeriodos.Columns.Add(Me.colAno)
        Me.cmbPeriodos.Columns.Add(Me.colPeriodo)
        Me.cmbPeriodos.Columns.Add(Me.colFechaIni)
        Me.cmbPeriodos.Columns.Add(Me.colFechaFin)
        Me.cmbPeriodos.FocusHighlightEnabled = True
        Me.cmbPeriodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPeriodos.FormatString = "d"
        Me.cmbPeriodos.FormattingEnabled = True
        Me.cmbPeriodos.GridRowLines = True
        Me.cmbPeriodos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPeriodos.Location = New System.Drawing.Point(45, 164)
        Me.cmbPeriodos.Name = "cmbPeriodos"
        Me.cmbPeriodos.Size = New System.Drawing.Size(454, 25)
        Me.cmbPeriodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPeriodos.TabIndex = 112
        Me.cmbPeriodos.ValueMember = "fecha_fin"
        '
        'colUnico
        '
        Me.colUnico.DataFieldName = "unico"
        Me.colUnico.Name = "colUnico"
        Me.colUnico.Text = "Unico"
        Me.colUnico.Visible = False
        Me.colUnico.Width.Relative = 25
        '
        'colActivo
        '
        Me.colActivo.DataFieldName = "activo"
        Me.colActivo.Name = "colActivo"
        Me.colActivo.Text = "Activo"
        Me.colActivo.Width.Relative = 14
        '
        'colAno
        '
        Me.colAno.DataFieldName = "ano"
        Me.colAno.Name = "colAno"
        Me.colAno.Text = "Año"
        Me.colAno.Width.Relative = 18
        '
        'colPeriodo
        '
        Me.colPeriodo.DataFieldName = "periodo"
        Me.colPeriodo.Name = "colPeriodo"
        Me.colPeriodo.Text = "Periodo"
        Me.colPeriodo.Width.Relative = 18
        '
        'colFechaIni
        '
        Me.colFechaIni.DataFieldName = "fecha_ini"
        Me.colFechaIni.Name = "colFechaIni"
        Me.colFechaIni.Text = "Fecha inicial"
        Me.colFechaIni.Width.Relative = 25
        '
        'colFechaFin
        '
        Me.colFechaFin.DataFieldName = "fecha_fin"
        Me.colFechaFin.Name = "colFechaFin"
        Me.colFechaFin.Text = "Fecha final"
        Me.colFechaFin.Width.Relative = 25
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.ActualizacionVariables24
        Me.picImagen.Location = New System.Drawing.Point(12, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(27, 26)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picImagen.TabIndex = 94
        Me.picImagen.TabStop = False
        '
        'frmActualizarVariables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(548, 433)
        Me.Controls.Add(Me.cmbPeriodos)
        Me.Controls.Add(Me.cpActualizacion)
        Me.Controls.Add(Me.pnlControles)
        Me.Controls.Add(Me.lblReloj)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.picImagen)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmActualizarVariables"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Actualizar promedios variables"
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents cpActualizacion As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents dlgArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblReloj As System.Windows.Forms.Label
    Friend WithEvents pnlControles As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents btnActualizar As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents btnSimular As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents btnSalir As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents cmbPeriodos As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents colUnico As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colActivo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colAno As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colPeriodo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colFechaIni As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colFechaFin As DevComponents.AdvTree.ColumnHeader
End Class
