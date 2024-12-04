<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcesarHoras
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
        Dim MetroTileFrame1 As DevComponents.DotNetBar.Metro.MetroTileFrame
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProcesarHoras))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem()
        Me.cmbCia = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbAno = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MetroTilePanel1 = New DevComponents.DotNetBar.Metro.MetroTilePanel()
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
        Me.btnPrenominaOperativa = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.btnPrenominaAdmva = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.btnRevisionHoras = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.btnTransferencia = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.btnCorreciones = New DevComponents.DotNetBar.Metro.MetroTileItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmbPeriodo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Periodo = New DevComponents.AdvTree.ColumnHeader()
        Me.colFechaIni = New DevComponents.AdvTree.ColumnHeader()
        Me.colFechaFin = New DevComponents.AdvTree.ColumnHeader()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbTipo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Tipo = New DevComponents.AdvTree.ColumnHeader()
        Me.Nombre = New DevComponents.AdvTree.ColumnHeader()
        Me.cmbPlanta = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader6 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.cmbTipoEmpleado = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.fecha_ini = New DevComponents.AdvTree.ColumnHeader()
        Me.fecha_fin = New DevComponents.AdvTree.ColumnHeader()
        MetroTileFrame1 = New DevComponents.DotNetBar.Metro.MetroTileFrame()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MetroTileFrame1
        '
        MetroTileFrame1.Image = Global.PIDA.My.Resources.Resources.TableReport
        MetroTileFrame1.Text = "Prenómina semanal operativa"
        MetroTileFrame1.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        '
        '
        '
        MetroTileFrame1.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        MetroTileFrame1.TitleText = "Prenómina"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(69, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(209, 40)
        Me.ReflectionLabel1.TabIndex = 0
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>PROCESAR HORAS</b></font>"
        '
        'ControlContainerItem1
        '
        Me.ControlContainerItem1.AllowItemResize = True
        Me.ControlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem1.Name = "ControlContainerItem1"
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
        Me.cmbCia.Columns.Add(Me.ColumnHeader3)
        Me.cmbCia.Columns.Add(Me.ColumnHeader4)
        Me.cmbCia.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbCia.Location = New System.Drawing.Point(112, 11)
        Me.cmbCia.Name = "cmbCia"
        Me.cmbCia.Size = New System.Drawing.Size(324, 23)
        Me.cmbCia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbCia.TabIndex = 1
        Me.cmbCia.ValueMember = "cod_comp"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DataFieldName = "cod_comp"
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Código"
        Me.ColumnHeader3.Width.Absolute = 50
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DataFieldName = "nombre"
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.StretchToFill = True
        Me.ColumnHeader4.Text = "Nombre"
        Me.ColumnHeader4.Width.Absolute = 150
        Me.ColumnHeader4.Width.AutoSize = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Location = New System.Drawing.Point(22, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 17)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Compañía"
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
        Me.cmbAno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAno.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbAno.Location = New System.Drawing.Point(525, 9)
        Me.cmbAno.Name = "cmbAno"
        Me.cmbAno.Size = New System.Drawing.Size(113, 23)
        Me.cmbAno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbAno.TabIndex = 6
        Me.cmbAno.ValueMember = "ano"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Location = New System.Drawing.Point(461, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 17)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Año"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Location = New System.Drawing.Point(460, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Periodo"
        '
        'MetroTilePanel1
        '
        '
        '
        '
        Me.MetroTilePanel1.BackgroundStyle.Class = "MetroTilePanel"
        Me.MetroTilePanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.MetroTilePanel1.ContainerControlProcessDialogKey = True
        Me.MetroTilePanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MetroTilePanel1.DragDropSupport = True
        Me.MetroTilePanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MetroTilePanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer1})
        Me.MetroTilePanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.MetroTilePanel1.Location = New System.Drawing.Point(0, 0)
        Me.MetroTilePanel1.Name = "MetroTilePanel1"
        Me.MetroTilePanel1.Size = New System.Drawing.Size(891, 216)
        Me.MetroTilePanel1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.MetroTilePanel1.TabIndex = 0
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.MultiLine = True
        Me.ItemContainer1.Name = "ItemContainer1"
        Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.btnPrenominaOperativa, Me.btnPrenominaAdmva, Me.btnRevisionHoras, Me.btnTransferencia, Me.btnCorreciones})
        '
        '
        '
        Me.ItemContainer1.TitleStyle.Class = "MetroTileGroupTitle"
        Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'btnPrenominaOperativa
        '
        Me.btnPrenominaOperativa.Image = Global.PIDA.My.Resources.Resources.TableReport
        Me.btnPrenominaOperativa.ImageIndent = New System.Drawing.Point(6, 6)
        Me.btnPrenominaOperativa.Name = "btnPrenominaOperativa"
        Me.btnPrenominaOperativa.SymbolColor = System.Drawing.Color.Empty
        Me.btnPrenominaOperativa.Text = "1.- Prenómina semanal (Completa)"
        Me.btnPrenominaOperativa.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.[Default]
        Me.btnPrenominaOperativa.TileSize = New System.Drawing.Size(420, 90)
        '
        '
        '
        Me.btnPrenominaOperativa.TileStyle.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Tile
        Me.btnPrenominaOperativa.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnPrenominaOperativa.TileStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrenominaOperativa.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.btnPrenominaOperativa.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnPrenominaOperativa.TitleTextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'btnPrenominaAdmva
        '
        Me.btnPrenominaAdmva.Image = Global.PIDA.My.Resources.Resources.contact
        Me.btnPrenominaAdmva.ImageIndent = New System.Drawing.Point(6, 6)
        Me.btnPrenominaAdmva.Name = "btnPrenominaAdmva"
        Me.btnPrenominaAdmva.SymbolColor = System.Drawing.Color.Empty
        Me.btnPrenominaAdmva.Text = "1.- Prenómina semanal " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(sólo excepciones)"
        Me.btnPrenominaAdmva.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Olive
        Me.btnPrenominaAdmva.TileSize = New System.Drawing.Size(420, 90)
        '
        '
        '
        Me.btnPrenominaAdmva.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnPrenominaAdmva.TileStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrenominaAdmva.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.btnPrenominaAdmva.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRevisionHoras
        '
        Me.btnRevisionHoras.Image = Global.PIDA.My.Resources.Resources.MetroReloj64
        Me.btnRevisionHoras.ImageIndent = New System.Drawing.Point(6, 6)
        Me.btnRevisionHoras.Name = "btnRevisionHoras"
        Me.btnRevisionHoras.SymbolColor = System.Drawing.Color.Empty
        Me.btnRevisionHoras.Text = "2.- Revisión de horas"
        Me.btnRevisionHoras.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Coffee
        Me.btnRevisionHoras.TileSize = New System.Drawing.Size(280, 90)
        '
        '
        '
        Me.btnRevisionHoras.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnRevisionHoras.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.btnRevisionHoras.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnTransferencia
        '
        Me.btnTransferencia.Image = Global.PIDA.My.Resources.Resources.Remote
        Me.btnTransferencia.ImageIndent = New System.Drawing.Point(6, 6)
        Me.btnTransferencia.Name = "btnTransferencia"
        Me.btnTransferencia.SymbolColor = System.Drawing.Color.Empty
        Me.btnTransferencia.Text = "3.- Transferencia de horas a nómina"
        Me.btnTransferencia.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.Orange
        Me.btnTransferencia.TileSize = New System.Drawing.Size(280, 90)
        '
        '
        '
        Me.btnTransferencia.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnTransferencia.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.btnTransferencia.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCorreciones
        '
        Me.btnCorreciones.Image = Global.PIDA.My.Resources.Resources.MetroCorrecciones
        Me.btnCorreciones.ImageIndent = New System.Drawing.Point(6, 6)
        Me.btnCorreciones.Name = "btnCorreciones"
        Me.btnCorreciones.SymbolColor = System.Drawing.Color.Empty
        Me.btnCorreciones.Text = "4.- Correcciones de horas para nómina"
        Me.btnCorreciones.TileColor = DevComponents.DotNetBar.Metro.eMetroTileColor.RedViolet
        Me.btnCorreciones.TileSize = New System.Drawing.Size(280, 90)
        '
        '
        '
        Me.btnCorreciones.TileStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnCorreciones.TileStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.btnCorreciones.TitleTextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.ProcesarHoras24
        Me.PictureBox1.Location = New System.Drawing.Point(17, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(46, 40)
        Me.PictureBox1.TabIndex = 81
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Window
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.cmbPeriodo)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cmbTipo)
        Me.Panel1.Controls.Add(Me.cmbPlanta)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Line1)
        Me.Panel1.Controls.Add(Me.cmbTipoEmpleado)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cmbCia)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmbAno)
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(16, 58)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(893, 108)
        Me.Panel1.TabIndex = 1
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
        Me.cmbPeriodo.Columns.Add(Me.Periodo)
        Me.cmbPeriodo.Columns.Add(Me.colFechaIni)
        Me.cmbPeriodo.Columns.Add(Me.colFechaFin)
        Me.cmbPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPeriodo.FormatString = "d"
        Me.cmbPeriodo.FormattingEnabled = True
        Me.cmbPeriodo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPeriodo.Location = New System.Drawing.Point(525, 66)
        Me.cmbPeriodo.Name = "cmbPeriodo"
        Me.cmbPeriodo.Size = New System.Drawing.Size(332, 21)
        Me.cmbPeriodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPeriodo.TabIndex = 13
        Me.cmbPeriodo.TabStop = False
        Me.cmbPeriodo.ThemeAware = True
        Me.cmbPeriodo.ValueMember = "periodo"
        '
        'Periodo
        '
        Me.Periodo.DataFieldName = "periodo"
        Me.Periodo.Name = "Periodo"
        Me.Periodo.Text = "Periodo"
        Me.Periodo.Width.Relative = 25
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Location = New System.Drawing.Point(460, 40)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 17)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Tipo"
        '
        'cmbTipo
        '
        Me.cmbTipo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbTipo.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbTipo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbTipo.ButtonDropDown.Visible = True
        Me.cmbTipo.Columns.Add(Me.Tipo)
        Me.cmbTipo.Columns.Add(Me.Nombre)
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbTipo.Location = New System.Drawing.Point(525, 37)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(332, 23)
        Me.cmbTipo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipo.TabIndex = 12
        Me.cmbTipo.ValueMember = "tipo"
        '
        'Tipo
        '
        Me.Tipo.DataFieldName = "tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.Text = "Tipo"
        Me.Tipo.Width.Absolute = 150
        '
        'Nombre
        '
        Me.Nombre.DataFieldName = "nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.Text = "Nombre"
        Me.Nombre.Width.Absolute = 150
        '
        'cmbPlanta
        '
        Me.cmbPlanta.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPlanta.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPlanta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPlanta.ButtonDropDown.Visible = True
        Me.cmbPlanta.Columns.Add(Me.ColumnHeader5)
        Me.cmbPlanta.Columns.Add(Me.ColumnHeader6)
        Me.cmbPlanta.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPlanta.Location = New System.Drawing.Point(165, 69)
        Me.cmbPlanta.Name = "cmbPlanta"
        Me.cmbPlanta.Size = New System.Drawing.Size(271, 23)
        Me.cmbPlanta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPlanta.TabIndex = 10
        Me.cmbPlanta.ValueMember = "cod_planta"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.DataFieldName = "cod_planta"
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.Text = "Cód."
        Me.ColumnHeader5.Width.Absolute = 150
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.DataFieldName = "nombre"
        Me.ColumnHeader6.Name = "ColumnHeader6"
        Me.ColumnHeader6.Text = "Planta"
        Me.ColumnHeader6.Width.Absolute = 150
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Location = New System.Drawing.Point(22, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 17)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Planta"
        '
        'Line1
        '
        Me.Line1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Line1.Location = New System.Drawing.Point(442, 10)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(12, 60)
        Me.Line1.TabIndex = 4
        Me.Line1.Text = "Line1"
        Me.Line1.VerticalLine = True
        '
        'cmbTipoEmpleado
        '
        Me.cmbTipoEmpleado.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbTipoEmpleado.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbTipoEmpleado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbTipoEmpleado.ButtonDropDown.Visible = True
        Me.cmbTipoEmpleado.Columns.Add(Me.ColumnHeader1)
        Me.cmbTipoEmpleado.Columns.Add(Me.ColumnHeader2)
        Me.cmbTipoEmpleado.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbTipoEmpleado.Location = New System.Drawing.Point(165, 40)
        Me.cmbTipoEmpleado.Name = "cmbTipoEmpleado"
        Me.cmbTipoEmpleado.Size = New System.Drawing.Size(271, 23)
        Me.cmbTipoEmpleado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTipoEmpleado.TabIndex = 3
        Me.cmbTipoEmpleado.ValueMember = "cod_tipo"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "cod_tipo"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Cód."
        Me.ColumnHeader1.Width.Absolute = 150
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "nombre"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Tipo"
        Me.ColumnHeader2.Width.Absolute = 150
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Location = New System.Drawing.Point(22, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 17)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Tipo de empleado"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Window
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.MetroTilePanel1)
        Me.Panel2.Location = New System.Drawing.Point(16, 171)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(893, 218)
        Me.Panel2.TabIndex = 2
        '
        'fecha_ini
        '
        Me.fecha_ini.DataFieldName = "fecha_ini"
        Me.fecha_ini.EditorType = DevComponents.AdvTree.eCellEditorType.Custom
        Me.fecha_ini.Name = "fecha_ini"
        Me.fecha_ini.Text = "Inicio"
        Me.fecha_ini.Width.Absolute = 150
        '
        'fecha_fin
        '
        Me.fecha_fin.DataFieldName = "fecha_fin"
        Me.fecha_fin.Name = "fecha_fin"
        Me.fecha_fin.Text = "Fin"
        Me.fecha_fin.Width.Absolute = 150
        '
        'frmProcesarHoras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(928, 411)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProcesarHoras"
        Me.Text = "Proceso de horas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents cmbCia As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbAno As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MetroTilePanel1 As DevComponents.DotNetBar.Metro.MetroTilePanel
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents btnPrenominaOperativa As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents btnPrenominaAdmva As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents btnRevisionHoras As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents btnTransferencia As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents btnCorreciones As DevComponents.DotNetBar.Metro.MetroTileItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents cmbTipoEmpleado As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents cmbPlanta As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader6 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents fecha_ini As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents fecha_fin As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colFechaIni As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colFechaFin As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents cmbPeriodo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Periodo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Tipo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Nombre As DevComponents.AdvTree.ColumnHeader
End Class
