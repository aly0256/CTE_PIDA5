<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInicNom
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbAno = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.cmbPeriodo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColPeriodo = New DevComponents.AdvTree.ColumnHeader()
        Me.ColFechaIni = New DevComponents.AdvTree.ColumnHeader()
        Me.ColFechaFin = New DevComponents.AdvTree.ColumnHeader()
        Me.btnIniciProcNom = New DevComponents.DotNetBar.ButtonX()
        Me.btnTransferencia = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.MetroTileItem1 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.MetroTileItem2 = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.labelEstatus = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(12, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(398, 40)
        Me.ReflectionLabel1.TabIndex = 249
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>Inicializar proceso de  nómina</b></font>"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(9, 89)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 17)
        Me.Label5.TabIndex = 250
        Me.Label5.Text = "Año"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(178, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 251
        Me.Label1.Text = "Periodo"
        '
        'cmbAno
        '
        Me.cmbAno.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbAno.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbAno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbAno.ButtonDropDown.Visible = True
        Me.cmbAno.DisplayMembers = "ano"
        Me.cmbAno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAno.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbAno.Location = New System.Drawing.Point(48, 88)
        Me.cmbAno.Name = "cmbAno"
        Me.cmbAno.Size = New System.Drawing.Size(113, 30)
        Me.cmbAno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbAno.TabIndex = 252
        Me.cmbAno.ValueMember = "ano"
        '
        'cmbPeriodo
        '
        Me.cmbPeriodo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPeriodo.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPeriodo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPeriodo.ButtonDropDown.Visible = True
        Me.cmbPeriodo.Columns.Add(Me.ColPeriodo)
        Me.cmbPeriodo.Columns.Add(Me.ColFechaIni)
        Me.cmbPeriodo.Columns.Add(Me.ColFechaFin)
        Me.cmbPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPeriodo.FormatString = "d"
        Me.cmbPeriodo.FormattingEnabled = True
        Me.cmbPeriodo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPeriodo.Location = New System.Drawing.Point(241, 88)
        Me.cmbPeriodo.Name = "cmbPeriodo"
        Me.cmbPeriodo.Size = New System.Drawing.Size(331, 30)
        Me.cmbPeriodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPeriodo.TabIndex = 253
        Me.cmbPeriodo.TabStop = False
        Me.cmbPeriodo.ThemeAware = True
        Me.cmbPeriodo.ValueMember = "periodo"
        '
        'ColPeriodo
        '
        Me.ColPeriodo.DataFieldName = "periodo"
        Me.ColPeriodo.Name = "ColPeriodo"
        Me.ColPeriodo.StretchToFill = True
        Me.ColPeriodo.Text = "Periodo"
        Me.ColPeriodo.Width.Relative = 20
        '
        'ColFechaIni
        '
        Me.ColFechaIni.DataFieldName = "fecha_ini"
        Me.ColFechaIni.Name = "ColFechaIni"
        Me.ColFechaIni.Text = "Fecha inicio"
        Me.ColFechaIni.Width.Relative = 40
        '
        'ColFechaFin
        '
        Me.ColFechaFin.DataFieldName = "fecha_fin"
        Me.ColFechaFin.Name = "ColFechaFin"
        Me.ColFechaFin.Text = "Fecha fin"
        Me.ColFechaFin.Width.Relative = 40
        '
        'btnIniciProcNom
        '
        Me.btnIniciProcNom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnIniciProcNom.CausesValidation = False
        Me.btnIniciProcNom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnIniciProcNom.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.btnIniciProcNom.Image = Global.PIDA.My.Resources.Resources._1471324111_table_edit
        Me.btnIniciProcNom.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnIniciProcNom.Location = New System.Drawing.Point(12, 149)
        Me.btnIniciProcNom.Name = "btnIniciProcNom"
        Me.btnIniciProcNom.Size = New System.Drawing.Size(560, 78)
        Me.btnIniciProcNom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnIniciProcNom.TabIndex = 254
        Me.btnIniciProcNom.Text = "Inicializa proceso"
        '
        'btnTransferencia
        '
        Me.btnTransferencia.Image = Global.PIDA.My.Resources.Resources.Remote
        Me.btnTransferencia.ImageIndent = New System.Drawing.Point(6, 6)
        Me.btnTransferencia.Name = "btnTransferencia"
        Me.btnTransferencia.SymbolColor = System.Drawing.Color.Empty
        Me.btnTransferencia.Text = "Exportar horas a out helping"
        Me.btnTransferencia.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange
        Me.btnTransferencia.TileSize = New System.Drawing.Size(280, 90)
        '
        '
        '
        Me.btnTransferencia.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnTransferencia.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.btnTransferencia.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MetroTileItem1
        '
        Me.MetroTileItem1.Image = Global.PIDA.My.Resources.Resources.Remote
        Me.MetroTileItem1.ImageIndent = New System.Drawing.Point(6, 6)
        Me.MetroTileItem1.Name = "MetroTileItem1"
        Me.MetroTileItem1.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem1.Text = "Exportar horas a out helping"
        Me.MetroTileItem1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange
        Me.MetroTileItem1.TileSize = New System.Drawing.Size(280, 90)
        '
        '
        '
        Me.MetroTileItem1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTileItem1.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.MetroTileItem1.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MetroTileItem2
        '
        Me.MetroTileItem2.Image = Global.PIDA.My.Resources.Resources.Remote
        Me.MetroTileItem2.ImageIndent = New System.Drawing.Point(6, 6)
        Me.MetroTileItem2.Name = "MetroTileItem2"
        Me.MetroTileItem2.SymbolColor = System.Drawing.Color.Empty
        Me.MetroTileItem2.Text = "Exportar horas a out helping"
        Me.MetroTileItem2.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange
        Me.MetroTileItem2.TileSize = New System.Drawing.Size(280, 90)
        '
        '
        '
        Me.MetroTileItem2.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTileItem2.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.MetroTileItem2.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'labelEstatus
        '
        Me.labelEstatus.BackColor = System.Drawing.SystemColors.Control
        Me.labelEstatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.labelEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.labelEstatus.Location = New System.Drawing.Point(12, 245)
        Me.labelEstatus.Name = "labelEstatus"
        Me.labelEstatus.Size = New System.Drawing.Size(560, 90)
        Me.labelEstatus.TabIndex = 255
        Me.labelEstatus.Text = "-"
        Me.labelEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmInicNom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 344)
        Me.Controls.Add(Me.labelEstatus)
        Me.Controls.Add(Me.btnIniciProcNom)
        Me.Controls.Add(Me.cmbPeriodo)
        Me.Controls.Add(Me.cmbAno)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInicNom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inicializar"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnTransferencia As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents MetroTileItem1 As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents MetroTileItem2 As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents cmbAno As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cmbPeriodo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents btnIniciProcNom As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ColPeriodo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColFechaIni As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColFechaFin As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents labelEstatus As System.Windows.Forms.Label
End Class
