<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaestroDeducciones
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMaestroDeducciones))
        Me.dgvMaestro = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ColConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCredito = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPeriodo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSaldoInicial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSemanas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAbono = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColSaldoActual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColActivo = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColComentario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabBuscar = New DevComponents.DotNetBar.SuperTabControl()
        Me.pnlDatos = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.tabMaestro = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgvSaldoCuenta = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblSaldoAct = New System.Windows.Forms.Label()
        Me.lblAbonos = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblSaldoInicial = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.imgEdoConcepto = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblEdoConcepto = New System.Windows.Forms.Label()
        Me.cmbConceptoCuenta = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.tabEdoCuenta = New DevComponents.DotNetBar.SuperTabItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.dlgArchivo = New System.Windows.Forms.SaveFileDialog()
        Me.ofdCargaArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel20 = New System.Windows.Forms.Panel()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel19 = New System.Windows.Forms.Panel()
        Me.btnAgregar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.btnFinal = New DevComponents.DotNetBar.ButtonX()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.btnSiguiente = New DevComponents.DotNetBar.ButtonX()
        Me.Panel15 = New System.Windows.Forms.Panel()
        Me.btnAnterior = New DevComponents.DotNetBar.ButtonX()
        Me.Panel14 = New System.Windows.Forms.Panel()
        Me.btnPrimero = New DevComponents.DotNetBar.ButtonX()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.btnFonacot = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.txtCodHora = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTurno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.txtClase = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.txtDepto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtTipoEmp = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.txtNombres = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblEstado = New DevComponents.DotNetBar.LabelX()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblFechaBaja = New System.Windows.Forms.Label()
        Me.txtAlta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtBaja = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.picFoto = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        CType(Me.dgvMaestro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBuscar.SuspendLayout()
        Me.pnlDatos.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.dgvSaldoCuenta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.imgEdoConcepto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel12.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel10.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvMaestro
        '
        Me.dgvMaestro.AllowUserToAddRows = False
        Me.dgvMaestro.AllowUserToDeleteRows = False
        Me.dgvMaestro.AllowUserToOrderColumns = True
        Me.dgvMaestro.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.dgvMaestro.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMaestro.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMaestro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaestro.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColConcepto, Me.colDescripcion, Me.ColCredito, Me.ColPeriodo, Me.ColAno, Me.ColSaldoInicial, Me.ColSemanas, Me.ColAbono, Me.ColSaldoActual, Me.ColActivo, Me.ColComentario, Me.colID})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMaestro.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgvMaestro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMaestro.EnableHeadersVisualStyles = False
        Me.dgvMaestro.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvMaestro.Location = New System.Drawing.Point(0, 0)
        Me.dgvMaestro.MultiSelect = False
        Me.dgvMaestro.Name = "dgvMaestro"
        Me.dgvMaestro.ReadOnly = True
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMaestro.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvMaestro.RowHeadersVisible = False
        Me.dgvMaestro.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMaestro.Size = New System.Drawing.Size(1189, 376)
        Me.dgvMaestro.TabIndex = 244
        '
        'ColConcepto
        '
        Me.ColConcepto.DataPropertyName = "concepto"
        Me.ColConcepto.Frozen = True
        Me.ColConcepto.HeaderText = "Concepto"
        Me.ColConcepto.MinimumWidth = 70
        Me.ColConcepto.Name = "ColConcepto"
        Me.ColConcepto.ReadOnly = True
        Me.ColConcepto.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColConcepto.Width = 70
        '
        'colDescripcion
        '
        Me.colDescripcion.DataPropertyName = "nombre"
        Me.colDescripcion.FillWeight = 250.0!
        Me.colDescripcion.Frozen = True
        Me.colDescripcion.HeaderText = "Descripción"
        Me.colDescripcion.MinimumWidth = 250
        Me.colDescripcion.Name = "colDescripcion"
        Me.colDescripcion.ReadOnly = True
        Me.colDescripcion.Width = 250
        '
        'ColCredito
        '
        Me.ColCredito.DataPropertyName = "credito"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColCredito.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColCredito.HeaderText = "# Crédito"
        Me.ColCredito.Name = "ColCredito"
        Me.ColCredito.ReadOnly = True
        '
        'ColPeriodo
        '
        Me.ColPeriodo.DataPropertyName = "ini_per"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColPeriodo.DefaultCellStyle = DataGridViewCellStyle4
        Me.ColPeriodo.HeaderText = "Periodo inicial"
        Me.ColPeriodo.Name = "ColPeriodo"
        Me.ColPeriodo.ReadOnly = True
        Me.ColPeriodo.Width = 60
        '
        'ColAno
        '
        Me.ColAno.DataPropertyName = "ini_ano"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColAno.DefaultCellStyle = DataGridViewCellStyle5
        Me.ColAno.HeaderText = "Año inicial"
        Me.ColAno.Name = "ColAno"
        Me.ColAno.ReadOnly = True
        Me.ColAno.Width = 40
        '
        'ColSaldoInicial
        '
        Me.ColSaldoInicial.DataPropertyName = "ini_saldo"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "C2"
        Me.ColSaldoInicial.DefaultCellStyle = DataGridViewCellStyle6
        Me.ColSaldoInicial.FillWeight = 80.0!
        Me.ColSaldoInicial.HeaderText = "Saldo inicial"
        Me.ColSaldoInicial.MinimumWidth = 80
        Me.ColSaldoInicial.Name = "ColSaldoInicial"
        Me.ColSaldoInicial.ReadOnly = True
        Me.ColSaldoInicial.Width = 80
        '
        'ColSemanas
        '
        Me.ColSemanas.DataPropertyName = "periodos"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ColSemanas.DefaultCellStyle = DataGridViewCellStyle7
        Me.ColSemanas.FillWeight = 80.0!
        Me.ColSemanas.HeaderText = "# Abonos"
        Me.ColSemanas.MinimumWidth = 50
        Me.ColSemanas.Name = "ColSemanas"
        Me.ColSemanas.ReadOnly = True
        Me.ColSemanas.Width = 50
        '
        'ColAbono
        '
        Me.ColAbono.DataPropertyName = "abono"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "C2"
        DataGridViewCellStyle8.NullValue = "0"
        Me.ColAbono.DefaultCellStyle = DataGridViewCellStyle8
        Me.ColAbono.HeaderText = "Abono"
        Me.ColAbono.MinimumWidth = 80
        Me.ColAbono.Name = "ColAbono"
        Me.ColAbono.ReadOnly = True
        Me.ColAbono.Width = 80
        '
        'ColSaldoActual
        '
        Me.ColSaldoActual.DataPropertyName = "sald_act"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.Format = "C2"
        Me.ColSaldoActual.DefaultCellStyle = DataGridViewCellStyle9
        Me.ColSaldoActual.FillWeight = 150.0!
        Me.ColSaldoActual.HeaderText = "Saldo sem. actual"
        Me.ColSaldoActual.MinimumWidth = 80
        Me.ColSaldoActual.Name = "ColSaldoActual"
        Me.ColSaldoActual.ReadOnly = True
        Me.ColSaldoActual.Width = 80
        '
        'ColActivo
        '
        Me.ColActivo.DataPropertyName = "activo"
        Me.ColActivo.FillWeight = 50.0!
        Me.ColActivo.HeaderText = "Activo"
        Me.ColActivo.MinimumWidth = 50
        Me.ColActivo.Name = "ColActivo"
        Me.ColActivo.ReadOnly = True
        Me.ColActivo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColActivo.Width = 50
        '
        'ColComentario
        '
        Me.ColComentario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColComentario.DataPropertyName = "comentario"
        Me.ColComentario.HeaderText = "Comentario"
        Me.ColComentario.Name = "ColComentario"
        Me.ColComentario.ReadOnly = True
        Me.ColComentario.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColComentario.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colID
        '
        Me.colID.DataPropertyName = "id"
        Me.colID.HeaderText = "ID"
        Me.colID.Name = "colID"
        Me.colID.ReadOnly = True
        Me.colID.Visible = False
        '
        'tabBuscar
        '
        '
        '
        '
        '
        '
        '
        Me.tabBuscar.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.tabBuscar.ControlBox.MenuBox.Name = ""
        Me.tabBuscar.ControlBox.MenuBox.Visible = False
        Me.tabBuscar.ControlBox.Name = ""
        Me.tabBuscar.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabBuscar.ControlBox.MenuBox, Me.tabBuscar.ControlBox.CloseBox})
        Me.tabBuscar.Controls.Add(Me.pnlDatos)
        Me.tabBuscar.Controls.Add(Me.SuperTabControlPanel2)
        Me.tabBuscar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.Location = New System.Drawing.Point(0, 0)
        Me.tabBuscar.Name = "tabBuscar"
        Me.tabBuscar.ReorderTabsEnabled = True
        Me.tabBuscar.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabBuscar.SelectedTabIndex = 0
        Me.tabBuscar.Size = New System.Drawing.Size(1274, 376)
        Me.tabBuscar.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.tabBuscar.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.TabIndex = 247
        Me.tabBuscar.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit
        Me.tabBuscar.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabMaestro, Me.tabEdoCuenta})
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.dgvMaestro)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(1189, 376)
        Me.pnlDatos.TabIndex = 0
        Me.pnlDatos.TabItem = Me.tabMaestro
        '
        'tabMaestro
        '
        Me.tabMaestro.AttachedControl = Me.pnlDatos
        Me.tabMaestro.GlobalItem = False
        Me.tabMaestro.Name = "tabMaestro"
        Me.tabMaestro.Text = "Maestro" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "deducciones"
        Me.tabMaestro.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.dgvSaldoCuenta)
        Me.SuperTabControlPanel2.Controls.Add(Me.TableLayoutPanel2)
        Me.SuperTabControlPanel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(1186, 376)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.tabEdoCuenta
        '
        'dgvSaldoCuenta
        '
        Me.dgvSaldoCuenta.AllowUserToAddRows = False
        Me.dgvSaldoCuenta.AllowUserToDeleteRows = False
        Me.dgvSaldoCuenta.AllowUserToOrderColumns = True
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.dgvSaldoCuenta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle12
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSaldoCuenta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvSaldoCuenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSaldoCuenta.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column4, Me.Column5, Me.Column6, Me.Column8, Me.Column3})
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSaldoCuenta.DefaultCellStyle = DataGridViewCellStyle17
        Me.dgvSaldoCuenta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSaldoCuenta.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvSaldoCuenta.EnableHeadersVisualStyles = False
        Me.dgvSaldoCuenta.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvSaldoCuenta.Location = New System.Drawing.Point(0, 37)
        Me.dgvSaldoCuenta.MultiSelect = False
        Me.dgvSaldoCuenta.Name = "dgvSaldoCuenta"
        Me.dgvSaldoCuenta.ReadOnly = True
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSaldoCuenta.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgvSaldoCuenta.RowHeadersVisible = False
        Me.dgvSaldoCuenta.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Lime
        Me.dgvSaldoCuenta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvSaldoCuenta.Size = New System.Drawing.Size(1186, 296)
        Me.dgvSaldoCuenta.TabIndex = 301
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "ano"
        Me.Column1.HeaderText = "Año"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 60
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "periodo"
        Me.Column2.HeaderText = "Periodo"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 50
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "saldo_ant"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "c2"
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle14
        Me.Column4.HeaderText = "Saldo anterior"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 75
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "abono"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "c2"
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle15
        Me.Column5.HeaderText = "Abono"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 75
        '
        'Column6
        '
        Me.Column6.DataPropertyName = "saldo"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "c2"
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle16
        Me.Column6.HeaderText = "Saldo actual"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 75
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column8.DataPropertyName = "comentario"
        Me.Column8.HeaderText = "Comentario"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "concepto"
        Me.Column3.HeaderText = "Column3"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Visible = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblSaldoAct, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.lblAbonos, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblSaldoInicial, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 333)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1186, 43)
        Me.TableLayoutPanel2.TabIndex = 247
        '
        'lblSaldoAct
        '
        Me.lblSaldoAct.AutoSize = True
        Me.lblSaldoAct.BackColor = System.Drawing.SystemColors.Highlight
        Me.lblSaldoAct.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSaldoAct.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoAct.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lblSaldoAct.Location = New System.Drawing.Point(595, 23)
        Me.lblSaldoAct.Name = "lblSaldoAct"
        Me.lblSaldoAct.Padding = New System.Windows.Forms.Padding(0, 0, 15, 0)
        Me.lblSaldoAct.Size = New System.Drawing.Size(588, 20)
        Me.lblSaldoAct.TabIndex = 6
        Me.lblSaldoAct.Text = "$0.00"
        Me.lblSaldoAct.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAbonos
        '
        Me.lblAbonos.AutoSize = True
        Me.lblAbonos.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lblAbonos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAbonos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbonos.Location = New System.Drawing.Point(299, 23)
        Me.lblAbonos.Name = "lblAbonos"
        Me.lblAbonos.Padding = New System.Windows.Forms.Padding(0, 0, 15, 0)
        Me.lblAbonos.Size = New System.Drawing.Size(290, 20)
        Me.lblAbonos.TabIndex = 5
        Me.lblAbonos.Text = "$0.00"
        Me.lblAbonos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(595, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(588, 23)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Saldo actual"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(299, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(290, 23)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Abonos"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(290, 23)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Saldo inicial"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSaldoInicial
        '
        Me.lblSaldoInicial.AutoSize = True
        Me.lblSaldoInicial.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lblSaldoInicial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSaldoInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaldoInicial.Location = New System.Drawing.Point(3, 23)
        Me.lblSaldoInicial.Name = "lblSaldoInicial"
        Me.lblSaldoInicial.Padding = New System.Windows.Forms.Padding(0, 0, 15, 0)
        Me.lblSaldoInicial.Size = New System.Drawing.Size(290, 20)
        Me.lblSaldoInicial.TabIndex = 4
        Me.lblSaldoInicial.Text = "$0.00"
        Me.lblSaldoInicial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 124.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.imgEdoConcepto, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEdoConcepto, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbConceptoCuenta, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TableLayoutPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1186, 37)
        Me.TableLayoutPanel1.TabIndex = 246
        '
        'imgEdoConcepto
        '
        Me.imgEdoConcepto.Dock = System.Windows.Forms.DockStyle.Left
        Me.imgEdoConcepto.Image = Global.PIDA.My.Resources.Resources.medal_
        Me.imgEdoConcepto.Location = New System.Drawing.Point(1134, 3)
        Me.imgEdoConcepto.Name = "imgEdoConcepto"
        Me.imgEdoConcepto.Size = New System.Drawing.Size(49, 31)
        Me.imgEdoConcepto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgEdoConcepto.TabIndex = 5
        Me.imgEdoConcepto.TabStop = False
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 37)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Concepto"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEdoConcepto
        '
        Me.lblEdoConcepto.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblEdoConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdoConcepto.Location = New System.Drawing.Point(1027, 0)
        Me.lblEdoConcepto.Name = "lblEdoConcepto"
        Me.lblEdoConcepto.Size = New System.Drawing.Size(77, 37)
        Me.lblEdoConcepto.TabIndex = 6
        Me.lblEdoConcepto.Text = "Liquidado"
        Me.lblEdoConcepto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbConceptoCuenta
        '
        Me.cmbConceptoCuenta.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbConceptoCuenta.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbConceptoCuenta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbConceptoCuenta.ButtonDropDown.Visible = True
        Me.cmbConceptoCuenta.Columns.Add(Me.ColumnHeader1)
        Me.cmbConceptoCuenta.Columns.Add(Me.ColumnHeader2)
        Me.cmbConceptoCuenta.Columns.Add(Me.ColumnHeader3)
        Me.cmbConceptoCuenta.Columns.Add(Me.ColumnHeader4)
        Me.cmbConceptoCuenta.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmbConceptoCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbConceptoCuenta.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbConceptoCuenta.Location = New System.Drawing.Point(113, 3)
        Me.cmbConceptoCuenta.Name = "cmbConceptoCuenta"
        Me.cmbConceptoCuenta.Size = New System.Drawing.Size(908, 31)
        Me.cmbConceptoCuenta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbConceptoCuenta.TabIndex = 7
        Me.cmbConceptoCuenta.ValueMember = "conceptonum"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "concepto"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Código"
        Me.ColumnHeader1.Width.Absolute = 70
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "nombre"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.StretchToFill = True
        Me.ColumnHeader2.Text = "Nombre"
        Me.ColumnHeader2.Width.Absolute = 150
        Me.ColumnHeader2.Width.AutoSize = True
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DataFieldName = "numcredito"
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Numcredito"
        Me.ColumnHeader3.Width.Absolute = 150
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.DataFieldName = "conceptonum"
        Me.ColumnHeader4.Editable = False
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "ConceptoNum"
        Me.ColumnHeader4.Visible = False
        Me.ColumnHeader4.Width.Absolute = 150
        '
        'tabEdoCuenta
        '
        Me.tabEdoCuenta.AttachedControl = Me.SuperTabControlPanel2
        Me.tabEdoCuenta.GlobalItem = False
        Me.tabEdoCuenta.Name = "tabEdoCuenta"
        Me.tabEdoCuenta.Text = "Estado " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "de cuenta"
        Me.tabEdoCuenta.TextAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'ofdCargaArchivo
        '
        Me.ofdCargaArchivo.FileName = "OpenFileDialog1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel12)
        Me.GroupBox2.Controls.Add(Me.Panel11)
        Me.GroupBox2.Controls.Add(Me.btnFonacot)
        Me.GroupBox2.Controls.Add(Me.btnCerrar)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(10, 571)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(10, 0, 10, 8)
        Me.GroupBox2.Size = New System.Drawing.Size(1274, 46)
        Me.GroupBox2.TabIndex = 249
        Me.GroupBox2.TabStop = False
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.btnEditar)
        Me.Panel12.Controls.Add(Me.Panel20)
        Me.Panel12.Controls.Add(Me.btnCancelar)
        Me.Panel12.Controls.Add(Me.Panel19)
        Me.Panel12.Controls.Add(Me.btnAgregar)
        Me.Panel12.Controls.Add(Me.Panel18)
        Me.Panel12.Controls.Add(Me.btnBuscar)
        Me.Panel12.Controls.Add(Me.Panel17)
        Me.Panel12.Controls.Add(Me.btnFinal)
        Me.Panel12.Controls.Add(Me.Panel16)
        Me.Panel12.Controls.Add(Me.btnSiguiente)
        Me.Panel12.Controls.Add(Me.Panel15)
        Me.Panel12.Controls.Add(Me.btnAnterior)
        Me.Panel12.Controls.Add(Me.Panel14)
        Me.Panel12.Controls.Add(Me.btnPrimero)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(204, 13)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(970, 25)
        Me.Panel12.TabIndex = 47
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = Global.PIDA.My.Resources.Resources.edit_
        Me.btnEditar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnEditar.ImageTextSpacing = 3
        Me.btnEditar.Location = New System.Drawing.Point(679, 0)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(90, 25)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 47
        Me.btnEditar.Text = "Editar"
        '
        'Panel20
        '
        Me.Panel20.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel20.Location = New System.Drawing.Point(672, 0)
        Me.Panel20.Name = "Panel20"
        Me.Panel20.Size = New System.Drawing.Size(7, 25)
        Me.Panel20.TabIndex = 46
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.cancel_
        Me.btnCancelar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCancelar.ImageTextSpacing = 3
        Me.btnCancelar.Location = New System.Drawing.Point(582, 0)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(90, 25)
        Me.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancelar.TabIndex = 45
        Me.btnCancelar.Text = "Cancelar"
        '
        'Panel19
        '
        Me.Panel19.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel19.Location = New System.Drawing.Point(575, 0)
        Me.Panel19.Name = "Panel19"
        Me.Panel19.Size = New System.Drawing.Size(7, 25)
        Me.Panel19.TabIndex = 44
        '
        'btnAgregar
        '
        Me.btnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAgregar.CausesValidation = False
        Me.btnAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAgregar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = Global.PIDA.My.Resources.Resources.add_
        Me.btnAgregar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnAgregar.ImageTextSpacing = 3
        Me.btnAgregar.Location = New System.Drawing.Point(485, 0)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(90, 25)
        Me.btnAgregar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAgregar.TabIndex = 43
        Me.btnAgregar.Text = "Agregar"
        '
        'Panel18
        '
        Me.Panel18.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel18.Location = New System.Drawing.Point(478, 0)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(7, 25)
        Me.Panel18.TabIndex = 42
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.buscar_
        Me.btnBuscar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBuscar.ImageTextSpacing = 3
        Me.btnBuscar.Location = New System.Drawing.Point(388, 0)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(90, 25)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 41
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Tooltip = "Buscar"
        '
        'Panel17
        '
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel17.Location = New System.Drawing.Point(381, 0)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(7, 25)
        Me.Panel17.TabIndex = 40
        '
        'btnFinal
        '
        Me.btnFinal.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnFinal.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnFinal.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnFinal.Image = Global.PIDA.My.Resources.Resources.last_
        Me.btnFinal.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnFinal.ImageTextSpacing = 3
        Me.btnFinal.Location = New System.Drawing.Point(291, 0)
        Me.btnFinal.Name = "btnFinal"
        Me.btnFinal.Size = New System.Drawing.Size(90, 25)
        Me.btnFinal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnFinal.TabIndex = 39
        Me.btnFinal.Text = "Final"
        '
        'Panel16
        '
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel16.Location = New System.Drawing.Point(284, 0)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(7, 25)
        Me.Panel16.TabIndex = 38
        '
        'btnSiguiente
        '
        Me.btnSiguiente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSiguiente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSiguiente.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSiguiente.Image = Global.PIDA.My.Resources.Resources.next_
        Me.btnSiguiente.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnSiguiente.ImageTextSpacing = 3
        Me.btnSiguiente.Location = New System.Drawing.Point(194, 0)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(90, 25)
        Me.btnSiguiente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSiguiente.TabIndex = 37
        Me.btnSiguiente.Text = "Siguiente"
        '
        'Panel15
        '
        Me.Panel15.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel15.Location = New System.Drawing.Point(187, 0)
        Me.Panel15.Name = "Panel15"
        Me.Panel15.Size = New System.Drawing.Size(7, 25)
        Me.Panel15.TabIndex = 36
        '
        'btnAnterior
        '
        Me.btnAnterior.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAnterior.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAnterior.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnAnterior.Image = Global.PIDA.My.Resources.Resources.prev_
        Me.btnAnterior.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnAnterior.ImageTextSpacing = 3
        Me.btnAnterior.Location = New System.Drawing.Point(97, 0)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(90, 25)
        Me.btnAnterior.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAnterior.TabIndex = 35
        Me.btnAnterior.Text = "Anterior"
        '
        'Panel14
        '
        Me.Panel14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel14.Location = New System.Drawing.Point(90, 0)
        Me.Panel14.Name = "Panel14"
        Me.Panel14.Size = New System.Drawing.Size(7, 25)
        Me.Panel14.TabIndex = 34
        '
        'btnPrimero
        '
        Me.btnPrimero.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrimero.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrimero.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnPrimero.Image = Global.PIDA.My.Resources.Resources.first_
        Me.btnPrimero.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnPrimero.ImageTextSpacing = 3
        Me.btnPrimero.Location = New System.Drawing.Point(0, 0)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(90, 25)
        Me.btnPrimero.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrimero.TabIndex = 33
        Me.btnPrimero.Text = "Inicio"
        '
        'Panel11
        '
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel11.Location = New System.Drawing.Point(197, 13)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(7, 25)
        Me.Panel11.TabIndex = 44
        '
        'btnFonacot
        '
        Me.btnFonacot.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnFonacot.CausesValidation = False
        Me.btnFonacot.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnFonacot.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnFonacot.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFonacot.Image = Global.PIDA.My.Resources.Resources.fonacot1_
        Me.btnFonacot.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnFonacot.ImageTextSpacing = 5
        Me.btnFonacot.Location = New System.Drawing.Point(10, 13)
        Me.btnFonacot.Name = "btnFonacot"
        Me.btnFonacot.Size = New System.Drawing.Size(187, 25)
        Me.btnFonacot.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnFonacot.TabIndex = 43
        Me.btnFonacot.Text = "Cargar cédula fonacot"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.salir_
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.ImageTextSpacing = 3
        Me.btnCerrar.Location = New System.Drawing.Point(1174, 13)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(90, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 42
        Me.btnCerrar.Text = "Salir"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Panel1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(10, 10)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1274, 175)
        Me.Panel4.TabIndex = 252
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1274, 175)
        Me.Panel1.TabIndex = 252
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.GroupBox4)
        Me.Panel8.Controls.Add(Me.Panel3)
        Me.Panel8.Controls.Add(Me.GroupBox3)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(0, 53)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(1274, 122)
        Me.Panel8.TabIndex = 2
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Panel7)
        Me.GroupBox4.Controls.Add(Me.Panel6)
        Me.GroupBox4.Controls.Add(Me.Panel5)
        Me.GroupBox4.Controls.Add(Me.lblEstado)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(0)
        Me.GroupBox4.Size = New System.Drawing.Size(961, 122)
        Me.GroupBox4.TabIndex = 254
        Me.GroupBox4.TabStop = False
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Transparent
        Me.Panel7.Controls.Add(Me.txtCodHora)
        Me.Panel7.Controls.Add(Me.Label7)
        Me.Panel7.Controls.Add(Me.txtTurno)
        Me.Panel7.Controls.Add(Me.Label69)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(29, 83)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Padding = New System.Windows.Forms.Padding(0, 10, 0, 10)
        Me.Panel7.Size = New System.Drawing.Size(932, 35)
        Me.Panel7.TabIndex = 139
        '
        'txtCodHora
        '
        Me.txtCodHora.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtCodHora.Border.Class = "TextBoxBorder"
        Me.txtCodHora.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodHora.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtCodHora.Enabled = False
        Me.txtCodHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodHora.ForeColor = System.Drawing.Color.Black
        Me.txtCodHora.Location = New System.Drawing.Point(514, 10)
        Me.txtCodHora.Name = "txtCodHora"
        Me.txtCodHora.ReadOnly = True
        Me.txtCodHora.Size = New System.Drawing.Size(405, 21)
        Me.txtCodHora.TabIndex = 150
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(414, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.Label7.Size = New System.Drawing.Size(100, 15)
        Me.Label7.TabIndex = 149
        Me.Label7.Text = "Horario"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTurno
        '
        Me.txtTurno.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtTurno.Border.Class = "TextBoxBorder"
        Me.txtTurno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTurno.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtTurno.Enabled = False
        Me.txtTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTurno.ForeColor = System.Drawing.Color.Black
        Me.txtTurno.Location = New System.Drawing.Point(100, 10)
        Me.txtTurno.Name = "txtTurno"
        Me.txtTurno.ReadOnly = True
        Me.txtTurno.Size = New System.Drawing.Size(314, 21)
        Me.txtTurno.TabIndex = 148
        '
        'Label69
        '
        Me.Label69.BackColor = System.Drawing.Color.Transparent
        Me.Label69.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.Location = New System.Drawing.Point(0, 10)
        Me.Label69.Name = "Label69"
        Me.Label69.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.Label69.Size = New System.Drawing.Size(100, 15)
        Me.Label69.TabIndex = 147
        Me.Label69.Text = "Turno"
        Me.Label69.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.Controls.Add(Me.txtClase)
        Me.Panel6.Controls.Add(Me.Label70)
        Me.Panel6.Controls.Add(Me.txtDepto)
        Me.Panel6.Controls.Add(Me.Label67)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(29, 48)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(0, 10, 0, 10)
        Me.Panel6.Size = New System.Drawing.Size(932, 35)
        Me.Panel6.TabIndex = 138
        '
        'txtClase
        '
        Me.txtClase.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtClase.Border.Class = "TextBoxBorder"
        Me.txtClase.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtClase.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtClase.Enabled = False
        Me.txtClase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClase.ForeColor = System.Drawing.Color.Black
        Me.txtClase.Location = New System.Drawing.Point(514, 10)
        Me.txtClase.Name = "txtClase"
        Me.txtClase.ReadOnly = True
        Me.txtClase.Size = New System.Drawing.Size(405, 21)
        Me.txtClase.TabIndex = 147
        '
        'Label70
        '
        Me.Label70.BackColor = System.Drawing.Color.Transparent
        Me.Label70.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.Location = New System.Drawing.Point(414, 10)
        Me.Label70.Name = "Label70"
        Me.Label70.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.Label70.Size = New System.Drawing.Size(100, 15)
        Me.Label70.TabIndex = 146
        Me.Label70.Text = "Clase"
        Me.Label70.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDepto
        '
        Me.txtDepto.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtDepto.Border.Class = "TextBoxBorder"
        Me.txtDepto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDepto.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtDepto.Enabled = False
        Me.txtDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepto.ForeColor = System.Drawing.Color.Black
        Me.txtDepto.Location = New System.Drawing.Point(100, 10)
        Me.txtDepto.Name = "txtDepto"
        Me.txtDepto.ReadOnly = True
        Me.txtDepto.Size = New System.Drawing.Size(314, 21)
        Me.txtDepto.TabIndex = 140
        '
        'Label67
        '
        Me.Label67.BackColor = System.Drawing.Color.Transparent
        Me.Label67.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.Location = New System.Drawing.Point(0, 10)
        Me.Label67.Name = "Label67"
        Me.Label67.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.Label67.Size = New System.Drawing.Size(100, 15)
        Me.Label67.TabIndex = 139
        Me.Label67.Text = "Departamento"
        Me.Label67.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Controls.Add(Me.txtTipoEmp)
        Me.Panel5.Controls.Add(Me.Label68)
        Me.Panel5.Controls.Add(Me.txtNombres)
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(29, 13)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(0, 10, 0, 10)
        Me.Panel5.Size = New System.Drawing.Size(932, 35)
        Me.Panel5.TabIndex = 137
        '
        'txtTipoEmp
        '
        Me.txtTipoEmp.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtTipoEmp.Border.Class = "TextBoxBorder"
        Me.txtTipoEmp.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTipoEmp.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtTipoEmp.Enabled = False
        Me.txtTipoEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoEmp.ForeColor = System.Drawing.Color.Black
        Me.txtTipoEmp.Location = New System.Drawing.Point(514, 10)
        Me.txtTipoEmp.Name = "txtTipoEmp"
        Me.txtTipoEmp.ReadOnly = True
        Me.txtTipoEmp.Size = New System.Drawing.Size(405, 21)
        Me.txtTipoEmp.TabIndex = 143
        '
        'Label68
        '
        Me.Label68.BackColor = System.Drawing.Color.Transparent
        Me.Label68.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.Location = New System.Drawing.Point(414, 10)
        Me.Label68.Name = "Label68"
        Me.Label68.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.Label68.Size = New System.Drawing.Size(100, 15)
        Me.Label68.TabIndex = 142
        Me.Label68.Text = "Tipo de emp."
        Me.Label68.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtNombres
        '
        Me.txtNombres.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtNombres.Border.Class = "TextBoxBorder"
        Me.txtNombres.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombres.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtNombres.Enabled = False
        Me.txtNombres.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombres.ForeColor = System.Drawing.Color.Black
        Me.txtNombres.Location = New System.Drawing.Point(100, 10)
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.ReadOnly = True
        Me.txtNombres.Size = New System.Drawing.Size(314, 21)
        Me.txtNombres.TabIndex = 131
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(0, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(0, 0, 5, 0)
        Me.Label5.Size = New System.Drawing.Size(100, 15)
        Me.Label5.TabIndex = 130
        Me.Label5.Text = "Nombre"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.Color.Green
        '
        '
        '
        Me.lblEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblEstado.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblEstado.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.SystemColors.Window
        Me.lblEstado.Location = New System.Drawing.Point(0, 13)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(29, 109)
        Me.lblEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblEstado.TabIndex = 135
        Me.lblEstado.Text = "ACTIVO"
        Me.lblEstado.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblEstado.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.lblEstado.VerticalTextTopUp = False
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(961, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(10, 122)
        Me.Panel3.TabIndex = 253
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GroupBox1)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.lblFechaBaja)
        Me.GroupBox3.Controls.Add(Me.txtAlta)
        Me.GroupBox3.Controls.Add(Me.txtBaja)
        Me.GroupBox3.Controls.Add(Me.picFoto)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox3.Location = New System.Drawing.Point(971, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(303, 122)
        Me.GroupBox3.TabIndex = 252
        Me.GroupBox3.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.txtReloj)
        Me.GroupBox1.Controls.Add(Me.LabelX4)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(171, 49)
        Me.GroupBox1.TabIndex = 133
        Me.GroupBox1.TabStop = False
        '
        'txtReloj
        '
        Me.txtReloj.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.ForeColor = System.Drawing.Color.Black
        Me.txtReloj.Location = New System.Drawing.Point(61, 15)
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.ReadOnly = True
        Me.txtReloj.Size = New System.Drawing.Size(102, 26)
        Me.txtReloj.TabIndex = 0
        Me.txtReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.BackColor = System.Drawing.Color.Transparent
        Me.LabelX4.BackgroundStyle.BackColor2 = System.Drawing.Color.Transparent
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(11, 15)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(56, 23)
        Me.LabelX4.TabIndex = 36
        Me.LabelX4.Text = "Reloj"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 135
        Me.Label2.Text = "Fecha de alta"
        '
        'lblFechaBaja
        '
        Me.lblFechaBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFechaBaja.AutoSize = True
        Me.lblFechaBaja.BackColor = System.Drawing.Color.Transparent
        Me.lblFechaBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaBaja.Location = New System.Drawing.Point(14, 92)
        Me.lblFechaBaja.Name = "lblFechaBaja"
        Me.lblFechaBaja.Size = New System.Drawing.Size(75, 13)
        Me.lblFechaBaja.TabIndex = 136
        Me.lblFechaBaja.Text = "Fecha de baja"
        '
        'txtAlta
        '
        Me.txtAlta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAlta.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtAlta.Border.Class = "TextBoxBorder"
        Me.txtAlta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlta.ForeColor = System.Drawing.Color.Black
        Me.txtAlta.Location = New System.Drawing.Point(105, 65)
        Me.txtAlta.Name = "txtAlta"
        Me.txtAlta.ReadOnly = True
        Me.txtAlta.Size = New System.Drawing.Size(78, 21)
        Me.txtAlta.TabIndex = 169
        '
        'txtBaja
        '
        Me.txtBaja.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBaja.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtBaja.Border.Class = "TextBoxBorder"
        Me.txtBaja.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBaja.ForeColor = System.Drawing.Color.Black
        Me.txtBaja.Location = New System.Drawing.Point(105, 89)
        Me.txtBaja.Name = "txtBaja"
        Me.txtBaja.ReadOnly = True
        Me.txtBaja.Size = New System.Drawing.Size(78, 21)
        Me.txtBaja.TabIndex = 170
        '
        'picFoto
        '
        Me.picFoto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picFoto.ErrorImage = Global.PIDA.My.Resources.Resources.NoFoto
        Me.picFoto.Location = New System.Drawing.Point(207, 15)
        Me.picFoto.MaximumSize = New System.Drawing.Size(164, 210)
        Me.picFoto.MinimumSize = New System.Drawing.Size(78, 100)
        Me.picFoto.Name = "picFoto"
        Me.picFoto.Size = New System.Drawing.Size(90, 100)
        Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picFoto.TabIndex = 129
        Me.picFoto.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ReflectionLabel1)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1274, 53)
        Me.Panel2.TabIndex = 0
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.BackgroundStyle.PaddingLeft = 10
        Me.ReflectionLabel1.BackgroundStyle.PaddingTop = 10
        Me.ReflectionLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(38, 0)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(1236, 53)
        Me.ReflectionLabel1.TabIndex = 249
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>MAESTRO DE DEDUCCIONES</b></font>"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.mtroded_
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 53)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 210
        Me.PictureBox1.TabStop = False
        '
        'Panel9
        '
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(10, 185)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(1274, 10)
        Me.Panel9.TabIndex = 253
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.tabBuscar)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(10, 195)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(1274, 376)
        Me.Panel10.TabIndex = 254
        '
        'frmMaestroDeducciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1294, 627)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMaestroDeducciones"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.Text = "Maestro de deducciones"
        CType(Me.dgvMaestro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBuscar.ResumeLayout(False)
        Me.pnlDatos.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.dgvSaldoCuenta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.imgEdoConcepto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel12.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel10.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPrimero As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dgvMaestro As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents tabBuscar As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents pnlDatos As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabMtro As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabEdoCta As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents dgvSaldoCuenta As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblSaldoAct As System.Windows.Forms.Label
    Friend WithEvents lblAbonos As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblSaldoInicial As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents dlgArchivo As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnFonacot As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ofdCargaArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents imgEdoConcepto As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblEdoConcepto As System.Windows.Forms.Label
    Friend WithEvents cmbConceptoCuenta As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents btnRepEmp As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents btnRegAct As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents tabMaestro As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents tabEdoCuenta As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents txtCodHora As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTurno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents txtClase As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents txtDepto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents txtTipoEmp As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents txtNombres As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblEstado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblFechaBaja As System.Windows.Forms.Label
    Friend WithEvents txtAlta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtBaja As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents picFoto As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel20 As System.Windows.Forms.Panel
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel19 As System.Windows.Forms.Panel
    Friend WithEvents btnAgregar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel18 As System.Windows.Forms.Panel
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel17 As System.Windows.Forms.Panel
    Friend WithEvents btnFinal As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel16 As System.Windows.Forms.Panel
    Friend WithEvents btnSiguiente As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel15 As System.Windows.Forms.Panel
    Friend WithEvents btnAnterior As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel14 As System.Windows.Forms.Panel
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColConcepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCredito As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPeriodo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSaldoInicial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSemanas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAbono As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColSaldoActual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColActivo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColComentario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
