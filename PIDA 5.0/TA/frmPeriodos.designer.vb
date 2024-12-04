<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPeriodos
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPeriodos))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ColAnoActivo = New DevComponents.AdvTree.ColumnHeader()
        Me.ColPeriodoActivo = New DevComponents.AdvTree.ColumnHeader()
        Me.ColUnicoActivo = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrimero = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnAnterior = New DevComponents.DotNetBar.ButtonX()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnSiguiente = New DevComponents.DotNetBar.ButtonX()
        Me.btnUltimo = New DevComponents.DotNetBar.ButtonX()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.tabTabla = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgTabla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.colAno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPeriodo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFechaIni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFechaFin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colActivo = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.tabEmpleado = New DevComponents.DotNetBar.SuperTabItem()
        Me.pnlDatos = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.gpNuevo = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.btnCrearEspeciales = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.txtPeriodoInicial = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblDiaFinal = New System.Windows.Forms.Label()
        Me.lblDiaInicial = New System.Windows.Forms.Label()
        Me.btnGenerar = New DevComponents.DotNetBar.ButtonX()
        Me.dgNuevosPeriodos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.txtFechaFinal = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.txtFechaInicial = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtNuevoAno = New DevComponents.Editors.IntegerInput()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnEspecial = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.btnActivo = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFechaPago = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.txtFechaFin = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.txtFechaIni = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbMes = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.txtPeriodo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbAno = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.tabBuscar = New DevComponents.DotNetBar.SuperTabControl()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lstActivo = New System.Windows.Forms.ListBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatos.SuspendLayout()
        Me.gpNuevo.SuspendLayout()
        CType(Me.dgNuevosPeriodos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNuevoAno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaIni, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBuscar.SuspendLayout()
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
        Me.ReflectionLabel1.Size = New System.Drawing.Size(211, 40)
        Me.ReflectionLabel1.TabIndex = 88
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>PERIODOS</b></font>"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Periodo24
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(27, 26)
        Me.PictureBox1.TabIndex = 89
        Me.PictureBox1.TabStop = False
        '
        'ColAnoActivo
        '
        Me.ColAnoActivo.DataFieldName = "ano"
        Me.ColAnoActivo.Name = "ColAnoActivo"
        Me.ColAnoActivo.Text = "Año"
        Me.ColAnoActivo.Width.Absolute = 75
        Me.ColAnoActivo.Width.AutoSize = True
        '
        'ColPeriodoActivo
        '
        Me.ColPeriodoActivo.DataFieldName = "periodo"
        Me.ColPeriodoActivo.Name = "ColPeriodoActivo"
        Me.ColPeriodoActivo.Text = "Periodo"
        Me.ColPeriodoActivo.Width.Absolute = 75
        Me.ColPeriodoActivo.Width.AutoSize = True
        '
        'ColUnicoActivo
        '
        Me.ColUnicoActivo.DataFieldName = "unico"
        Me.ColUnicoActivo.Name = "ColUnicoActivo"
        Me.ColUnicoActivo.Text = "Column"
        Me.ColUnicoActivo.Visible = False
        Me.ColUnicoActivo.Width.Absolute = 150
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.ColumnName = "periodo"
        Me.ColumnHeader2.DataFieldName = "periodo"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Periodo"
        Me.ColumnHeader2.Width.Absolute = 150
        '
        'ElementStyle1
        '
        Me.ElementStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.ElementStyle1.BackColor2 = System.Drawing.Color.Navy
        Me.ElementStyle1.BackColorGradientAngle = 90
        Me.ElementStyle1.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderBottomWidth = 1
        Me.ElementStyle1.BorderColor = System.Drawing.Color.Navy
        Me.ElementStyle1.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderLeftWidth = 1
        Me.ElementStyle1.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderRightWidth = 1
        Me.ElementStyle1.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderTopWidth = 1
        Me.ElementStyle1.CornerDiameter = 4
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Description = "BlueNight"
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.PaddingBottom = 1
        Me.ElementStyle1.PaddingLeft = 1
        Me.ElementStyle1.PaddingRight = 1
        Me.ElementStyle1.PaddingTop = 1
        Me.ElementStyle1.TextColor = System.Drawing.SystemColors.Window
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(736, 13)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 9
        Me.btnCerrar.Text = "Salir"
        '
        'btnPrimero
        '
        Me.btnPrimero.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrimero.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrimero.Image = Global.PIDA.My.Resources.Resources.First16
        Me.btnPrimero.Location = New System.Drawing.Point(7, 13)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(78, 25)
        Me.btnPrimero.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrimero.TabIndex = 0
        Me.btnPrimero.Text = "Inicio"
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnReporte.Location = New System.Drawing.Point(412, 13)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 5
        Me.btnReporte.Text = "Reporte"
        '
        'btnAnterior
        '
        Me.btnAnterior.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAnterior.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAnterior.Image = Global.PIDA.My.Resources.Resources.Prev16
        Me.btnAnterior.Location = New System.Drawing.Point(88, 13)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(78, 25)
        Me.btnAnterior.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAnterior.TabIndex = 1
        Me.btnAnterior.Text = "Anterior"
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = Global.PIDA.My.Resources.Resources.DeleteRec
        Me.btnBorrar.Location = New System.Drawing.Point(655, 13)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(78, 25)
        Me.btnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBorrar.TabIndex = 8
        Me.btnBorrar.Text = "Borrar"
        Me.btnBorrar.Visible = False
        '
        'btnSiguiente
        '
        Me.btnSiguiente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSiguiente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSiguiente.Image = Global.PIDA.My.Resources.Resources.Next16
        Me.btnSiguiente.Location = New System.Drawing.Point(169, 13)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(78, 25)
        Me.btnSiguiente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSiguiente.TabIndex = 2
        Me.btnSiguiente.Text = "Siguiente"
        '
        'btnUltimo
        '
        Me.btnUltimo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnUltimo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnUltimo.Image = Global.PIDA.My.Resources.Resources.Last16
        Me.btnUltimo.Location = New System.Drawing.Point(250, 13)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(78, 25)
        Me.btnUltimo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnUltimo.TabIndex = 3
        Me.btnUltimo.Text = "Final"
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscar.Location = New System.Drawing.Point(331, 13)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(78, 25)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Tooltip = "Buscar"
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = Global.PIDA.My.Resources.Resources.Edit
        Me.btnEditar.Location = New System.Drawing.Point(574, 13)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(78, 25)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 7
        Me.btnEditar.Text = "Editar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnCerrar)
        Me.GroupBox1.Controls.Add(Me.btnPrimero)
        Me.GroupBox1.Controls.Add(Me.btnReporte)
        Me.GroupBox1.Controls.Add(Me.btnAnterior)
        Me.GroupBox1.Controls.Add(Me.btnBorrar)
        Me.GroupBox1.Controls.Add(Me.btnSiguiente)
        Me.GroupBox1.Controls.Add(Me.btnUltimo)
        Me.GroupBox1.Controls.Add(Me.btnBuscar)
        Me.GroupBox1.Controls.Add(Me.btnEditar)
        Me.GroupBox1.Controls.Add(Me.btnNuevo)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 410)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(825, 47)
        Me.GroupBox1.TabIndex = 111
        Me.GroupBox1.TabStop = False
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.NewRecord
        Me.btnNuevo.Location = New System.Drawing.Point(493, 13)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 25)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 6
        Me.btnNuevo.Text = "Agregar"
        '
        'tabTabla
        '
        Me.tabTabla.AttachedControl = Me.SuperTabControlPanel2
        Me.tabTabla.GlobalItem = False
        Me.tabTabla.Name = "tabTabla"
        Me.tabTabla.Text = "Lista"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.dgTabla)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(752, 342)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.tabTabla
        '
        'dgTabla
        '
        Me.dgTabla.AllowUserToAddRows = False
        Me.dgTabla.AllowUserToDeleteRows = False
        Me.dgTabla.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTabla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgTabla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAno, Me.colPeriodo, Me.colFechaIni, Me.colFechaFin, Me.colMes, Me.colActivo})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTabla.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgTabla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTabla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgTabla.EnableHeadersVisualStyles = False
        Me.dgTabla.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgTabla.Location = New System.Drawing.Point(0, 0)
        Me.dgTabla.MultiSelect = False
        Me.dgTabla.Name = "dgTabla"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTabla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgTabla.RowHeadersVisible = False
        Me.dgTabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgTabla.Size = New System.Drawing.Size(752, 342)
        Me.dgTabla.TabIndex = 0
        '
        'colAno
        '
        Me.colAno.DataPropertyName = "ano"
        Me.colAno.HeaderText = "AÑO"
        Me.colAno.Name = "colAno"
        Me.colAno.ReadOnly = True
        Me.colAno.Width = 50
        '
        'colPeriodo
        '
        Me.colPeriodo.DataPropertyName = "periodo"
        Me.colPeriodo.HeaderText = "PERIODO"
        Me.colPeriodo.Name = "colPeriodo"
        Me.colPeriodo.ReadOnly = True
        Me.colPeriodo.Width = 60
        '
        'colFechaIni
        '
        Me.colFechaIni.DataPropertyName = "fecha_ini"
        Me.colFechaIni.HeaderText = "FECHA INICIAL"
        Me.colFechaIni.Name = "colFechaIni"
        Me.colFechaIni.ReadOnly = True
        Me.colFechaIni.Width = 70
        '
        'colFechaFin
        '
        Me.colFechaFin.DataPropertyName = "fecha_fin"
        Me.colFechaFin.HeaderText = "FECHA FINAL"
        Me.colFechaFin.Name = "colFechaFin"
        Me.colFechaFin.ReadOnly = True
        Me.colFechaFin.Width = 70
        '
        'colMes
        '
        Me.colMes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colMes.DataPropertyName = "mes"
        Me.colMes.HeaderText = "MES"
        Me.colMes.Name = "colMes"
        Me.colMes.ReadOnly = True
        '
        'colActivo
        '
        Me.colActivo.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Checked16
        Me.colActivo.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.Unckecked16
        Me.colActivo.Checked = True
        Me.colActivo.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.colActivo.CheckValue = "N"
        Me.colActivo.DataPropertyName = "activo"
        Me.colActivo.HeaderText = "ACTIVO"
        Me.colActivo.Name = "colActivo"
        Me.colActivo.ReadOnly = True
        Me.colActivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colActivo.Width = 50
        '
        'tabEmpleado
        '
        Me.tabEmpleado.AttachedControl = Me.pnlDatos
        Me.tabEmpleado.GlobalItem = False
        Me.tabEmpleado.Name = "tabEmpleado"
        Me.tabEmpleado.Text = "Individual"
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.gpNuevo)
        Me.pnlDatos.Controls.Add(Me.Label10)
        Me.pnlDatos.Controls.Add(Me.Label9)
        Me.pnlDatos.Controls.Add(Me.btnEspecial)
        Me.pnlDatos.Controls.Add(Me.btnActivo)
        Me.pnlDatos.Controls.Add(Me.Label8)
        Me.pnlDatos.Controls.Add(Me.txtObservaciones)
        Me.pnlDatos.Controls.Add(Me.Label7)
        Me.pnlDatos.Controls.Add(Me.txtDescripcion)
        Me.pnlDatos.Controls.Add(Me.Label6)
        Me.pnlDatos.Controls.Add(Me.Label5)
        Me.pnlDatos.Controls.Add(Me.txtFechaPago)
        Me.pnlDatos.Controls.Add(Me.txtFechaFin)
        Me.pnlDatos.Controls.Add(Me.txtFechaIni)
        Me.pnlDatos.Controls.Add(Me.Label1)
        Me.pnlDatos.Controls.Add(Me.cmbMes)
        Me.pnlDatos.Controls.Add(Me.Label2)
        Me.pnlDatos.Controls.Add(Me.lbl1)
        Me.pnlDatos.Controls.Add(Me.txtPeriodo)
        Me.pnlDatos.Controls.Add(Me.Label3)
        Me.pnlDatos.Controls.Add(Me.cmbAno)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(754, 342)
        Me.pnlDatos.TabIndex = 0
        Me.pnlDatos.TabItem = Me.tabEmpleado
        '
        'gpNuevo
        '
        Me.gpNuevo.BackColor = System.Drawing.SystemColors.Window
        Me.gpNuevo.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpNuevo.Controls.Add(Me.Label15)
        Me.gpNuevo.Controls.Add(Me.btnCrearEspeciales)
        Me.gpNuevo.Controls.Add(Me.txtPeriodoInicial)
        Me.gpNuevo.Controls.Add(Me.Label14)
        Me.gpNuevo.Controls.Add(Me.lblDiaFinal)
        Me.gpNuevo.Controls.Add(Me.lblDiaInicial)
        Me.gpNuevo.Controls.Add(Me.btnGenerar)
        Me.gpNuevo.Controls.Add(Me.dgNuevosPeriodos)
        Me.gpNuevo.Controls.Add(Me.txtFechaFinal)
        Me.gpNuevo.Controls.Add(Me.txtFechaInicial)
        Me.gpNuevo.Controls.Add(Me.Label12)
        Me.gpNuevo.Controls.Add(Me.Label13)
        Me.gpNuevo.Controls.Add(Me.txtNuevoAno)
        Me.gpNuevo.Controls.Add(Me.Label11)
        Me.gpNuevo.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpNuevo.Location = New System.Drawing.Point(443, 13)
        Me.gpNuevo.Name = "gpNuevo"
        Me.gpNuevo.Size = New System.Drawing.Size(291, 326)
        '
        '
        '
        Me.gpNuevo.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpNuevo.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpNuevo.Style.BackColorGradientAngle = 90
        Me.gpNuevo.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpNuevo.Style.BorderBottomWidth = 1
        Me.gpNuevo.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpNuevo.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpNuevo.Style.BorderLeftWidth = 1
        Me.gpNuevo.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpNuevo.Style.BorderRightWidth = 1
        Me.gpNuevo.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpNuevo.Style.BorderTopWidth = 1
        Me.gpNuevo.Style.CornerDiameter = 4
        Me.gpNuevo.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpNuevo.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.gpNuevo.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpNuevo.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpNuevo.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpNuevo.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpNuevo.TabIndex = 94
        Me.gpNuevo.Text = "Nuevos periodos"
        Me.gpNuevo.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.SystemColors.Window
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 108)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(99, 15)
        Me.Label15.TabIndex = 95
        Me.Label15.Text = "Crear especiales"
        '
        'btnCrearEspeciales
        '
        '
        '
        '
        Me.btnCrearEspeciales.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnCrearEspeciales.Location = New System.Drawing.Point(108, 104)
        Me.btnCrearEspeciales.Name = "btnCrearEspeciales"
        Me.btnCrearEspeciales.OffText = "NO"
        Me.btnCrearEspeciales.OffTextColor = System.Drawing.Color.DarkBlue
        Me.btnCrearEspeciales.OnText = "SI"
        Me.btnCrearEspeciales.OnTextColor = System.Drawing.Color.DarkBlue
        Me.btnCrearEspeciales.Size = New System.Drawing.Size(84, 22)
        Me.btnCrearEspeciales.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCrearEspeciales.TabIndex = 94
        Me.btnCrearEspeciales.Value = True
        Me.btnCrearEspeciales.ValueObject = "Y"
        '
        'txtPeriodoInicial
        '
        '
        '
        '
        Me.txtPeriodoInicial.Border.Class = "TextBoxBorder"
        Me.txtPeriodoInicial.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPeriodoInicial.ButtonCustom.Tooltip = ""
        Me.txtPeriodoInicial.ButtonCustom2.Tooltip = ""
        Me.txtPeriodoInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodoInicial.Location = New System.Drawing.Point(108, 78)
        Me.txtPeriodoInicial.MaxLength = 5
        Me.txtPeriodoInicial.Name = "txtPeriodoInicial"
        Me.txtPeriodoInicial.Size = New System.Drawing.Size(84, 21)
        Me.txtPeriodoInicial.TabIndex = 4
        Me.txtPeriodoInicial.Text = "01"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.SystemColors.Window
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(8, 81)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 15)
        Me.Label14.TabIndex = 93
        Me.Label14.Text = "Periodo inicial"
        '
        'lblDiaFinal
        '
        Me.lblDiaFinal.AutoSize = True
        Me.lblDiaFinal.BackColor = System.Drawing.SystemColors.Window
        Me.lblDiaFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiaFinal.Location = New System.Drawing.Point(198, 56)
        Me.lblDiaFinal.Name = "lblDiaFinal"
        Me.lblDiaFinal.Size = New System.Drawing.Size(76, 15)
        Me.lblDiaFinal.TabIndex = 91
        Me.lblDiaFinal.Text = "Fecha inicial"
        '
        'lblDiaInicial
        '
        Me.lblDiaInicial.AutoSize = True
        Me.lblDiaInicial.BackColor = System.Drawing.SystemColors.Window
        Me.lblDiaInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiaInicial.Location = New System.Drawing.Point(198, 31)
        Me.lblDiaInicial.Name = "lblDiaInicial"
        Me.lblDiaInicial.Size = New System.Drawing.Size(76, 15)
        Me.lblDiaInicial.TabIndex = 90
        Me.lblDiaInicial.Text = "Fecha inicial"
        '
        'btnGenerar
        '
        Me.btnGenerar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGenerar.CausesValidation = False
        Me.btnGenerar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Image = Global.PIDA.My.Resources.Resources.NewReport22
        Me.btnGenerar.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnGenerar.Location = New System.Drawing.Point(8, 131)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(186, 25)
        Me.btnGenerar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGenerar.TabIndex = 5
        Me.btnGenerar.Text = "Generar lista de periodos"
        '
        'dgNuevosPeriodos
        '
        Me.dgNuevosPeriodos.AllowUserToAddRows = False
        Me.dgNuevosPeriodos.AllowUserToDeleteRows = False
        Me.dgNuevosPeriodos.AllowUserToOrderColumns = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgNuevosPeriodos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgNuevosPeriodos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgNuevosPeriodos.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgNuevosPeriodos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgNuevosPeriodos.EnableHeadersVisualStyles = False
        Me.dgNuevosPeriodos.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgNuevosPeriodos.Location = New System.Drawing.Point(0, 165)
        Me.dgNuevosPeriodos.MultiSelect = False
        Me.dgNuevosPeriodos.Name = "dgNuevosPeriodos"
        Me.dgNuevosPeriodos.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgNuevosPeriodos.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgNuevosPeriodos.Size = New System.Drawing.Size(285, 140)
        Me.dgNuevosPeriodos.TabIndex = 88
        '
        'txtFechaFinal
        '
        '
        '
        '
        Me.txtFechaFinal.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaFinal.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFinal.ButtonClear.Tooltip = ""
        Me.txtFechaFinal.ButtonCustom.Tooltip = ""
        Me.txtFechaFinal.ButtonCustom2.Tooltip = ""
        Me.txtFechaFinal.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtFechaFinal.ButtonDropDown.Tooltip = ""
        Me.txtFechaFinal.ButtonDropDown.Visible = True
        Me.txtFechaFinal.ButtonFreeText.Tooltip = ""
        Me.txtFechaFinal.IsPopupCalendarOpen = False
        Me.txtFechaFinal.Location = New System.Drawing.Point(108, 53)
        '
        '
        '
        Me.txtFechaFinal.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaFinal.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFinal.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtFechaFinal.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaFinal.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaFinal.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFinal.MonthCalendar.DisplayMonth = New Date(2013, 7, 1, 0, 0, 0, 0)
        Me.txtFechaFinal.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaFinal.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaFinal.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaFinal.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFinal.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaFinal.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFechaFinal.Name = "txtFechaFinal"
        Me.txtFechaFinal.Size = New System.Drawing.Size(84, 20)
        Me.txtFechaFinal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFechaFinal.TabIndex = 3
        '
        'txtFechaInicial
        '
        '
        '
        '
        Me.txtFechaInicial.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaInicial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaInicial.ButtonClear.Tooltip = ""
        Me.txtFechaInicial.ButtonCustom.Tooltip = ""
        Me.txtFechaInicial.ButtonCustom2.Tooltip = ""
        Me.txtFechaInicial.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtFechaInicial.ButtonDropDown.Tooltip = ""
        Me.txtFechaInicial.ButtonDropDown.Visible = True
        Me.txtFechaInicial.ButtonFreeText.Tooltip = ""
        Me.txtFechaInicial.IsPopupCalendarOpen = False
        Me.txtFechaInicial.Location = New System.Drawing.Point(108, 28)
        '
        '
        '
        Me.txtFechaInicial.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaInicial.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaInicial.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtFechaInicial.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaInicial.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaInicial.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaInicial.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaInicial.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaInicial.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaInicial.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaInicial.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaInicial.MonthCalendar.DisplayMonth = New Date(2013, 7, 1, 0, 0, 0, 0)
        Me.txtFechaInicial.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaInicial.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaInicial.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaInicial.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaInicial.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaInicial.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaInicial.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaInicial.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFechaInicial.Name = "txtFechaInicial"
        Me.txtFechaInicial.Size = New System.Drawing.Size(84, 20)
        Me.txtFechaInicial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFechaInicial.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Window
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 56)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 15)
        Me.Label12.TabIndex = 84
        Me.Label12.Text = "Fecha final"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.Window
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(8, 31)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 15)
        Me.Label13.TabIndex = 83
        Me.Label13.Text = "Fecha inicial"
        '
        'txtNuevoAno
        '
        '
        '
        '
        Me.txtNuevoAno.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtNuevoAno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNuevoAno.ButtonCalculator.Tooltip = ""
        Me.txtNuevoAno.ButtonClear.Tooltip = ""
        Me.txtNuevoAno.ButtonCustom.Tooltip = ""
        Me.txtNuevoAno.ButtonCustom2.Tooltip = ""
        Me.txtNuevoAno.ButtonDropDown.Tooltip = ""
        Me.txtNuevoAno.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtNuevoAno.ButtonFreeText.Tooltip = ""
        Me.txtNuevoAno.Location = New System.Drawing.Point(108, 3)
        Me.txtNuevoAno.MaxValue = 2050
        Me.txtNuevoAno.MinValue = 2010
        Me.txtNuevoAno.Name = "txtNuevoAno"
        Me.txtNuevoAno.ShowUpDown = True
        Me.txtNuevoAno.Size = New System.Drawing.Size(84, 20)
        Me.txtNuevoAno.TabIndex = 1
        Me.txtNuevoAno.Value = 2010
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Window
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(28, 15)
        Me.Label11.TabIndex = 77
        Me.Label11.Text = "Año"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Window
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(27, 252)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(99, 15)
        Me.Label10.TabIndex = 93
        Me.Label10.Text = "Periodo especial"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Window
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(27, 219)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 15)
        Me.Label9.TabIndex = 92
        Me.Label9.Text = "Periodo activo"
        '
        'btnEspecial
        '
        '
        '
        '
        Me.btnEspecial.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnEspecial.Location = New System.Drawing.Point(127, 248)
        Me.btnEspecial.Name = "btnEspecial"
        Me.btnEspecial.OffText = "NO"
        Me.btnEspecial.OffTextColor = System.Drawing.Color.DarkBlue
        Me.btnEspecial.OnText = "SI"
        Me.btnEspecial.OnTextColor = System.Drawing.Color.DarkBlue
        Me.btnEspecial.Size = New System.Drawing.Size(66, 22)
        Me.btnEspecial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEspecial.TabIndex = 91
        '
        'btnActivo
        '
        '
        '
        '
        Me.btnActivo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnActivo.Location = New System.Drawing.Point(127, 215)
        Me.btnActivo.Name = "btnActivo"
        Me.btnActivo.OffText = "NO"
        Me.btnActivo.OffTextColor = System.Drawing.Color.DarkBlue
        Me.btnActivo.OnText = "SI"
        Me.btnActivo.OnTextColor = System.Drawing.Color.DarkBlue
        Me.btnActivo.Size = New System.Drawing.Size(66, 22)
        Me.btnActivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnActivo.TabIndex = 90
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Window
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(27, 122)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 15)
        Me.Label8.TabIndex = 89
        Me.Label8.Text = "Observaciones"
        '
        'txtObservaciones
        '
        '
        '
        '
        Me.txtObservaciones.Border.Class = "TextBoxBorder"
        Me.txtObservaciones.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtObservaciones.ButtonCustom.Tooltip = ""
        Me.txtObservaciones.ButtonCustom2.Tooltip = ""
        Me.txtObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservaciones.Location = New System.Drawing.Point(127, 119)
        Me.txtObservaciones.MaxLength = 150
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(289, 21)
        Me.txtObservaciones.TabIndex = 88
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Window
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(27, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 15)
        Me.Label7.TabIndex = 87
        Me.Label7.Text = "Descripción"
        '
        'txtDescripcion
        '
        '
        '
        '
        Me.txtDescripcion.Border.Class = "TextBoxBorder"
        Me.txtDescripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDescripcion.ButtonCustom.Tooltip = ""
        Me.txtDescripcion.ButtonCustom2.Tooltip = ""
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(127, 87)
        Me.txtDescripcion.MaxLength = 30
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(289, 21)
        Me.txtDescripcion.TabIndex = 86
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(27, 186)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 15)
        Me.Label6.TabIndex = 85
        Me.Label6.Text = "Mes"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(27, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 15)
        Me.Label5.TabIndex = 84
        Me.Label5.Text = "Fecha de pago"
        '
        'txtFechaPago
        '
        '
        '
        '
        Me.txtFechaPago.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaPago.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaPago.ButtonClear.Tooltip = ""
        Me.txtFechaPago.ButtonCustom.Tooltip = ""
        Me.txtFechaPago.ButtonCustom2.Tooltip = ""
        Me.txtFechaPago.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtFechaPago.ButtonDropDown.Tooltip = ""
        Me.txtFechaPago.ButtonDropDown.Visible = True
        Me.txtFechaPago.ButtonFreeText.Tooltip = ""
        Me.txtFechaPago.IsPopupCalendarOpen = False
        Me.txtFechaPago.Location = New System.Drawing.Point(127, 151)
        '
        '
        '
        Me.txtFechaPago.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaPago.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaPago.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtFechaPago.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaPago.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaPago.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaPago.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaPago.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaPago.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaPago.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaPago.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaPago.MonthCalendar.DisplayMonth = New Date(2013, 7, 1, 0, 0, 0, 0)
        Me.txtFechaPago.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaPago.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaPago.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaPago.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaPago.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaPago.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaPago.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaPago.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFechaPago.Name = "txtFechaPago"
        Me.txtFechaPago.Size = New System.Drawing.Size(84, 20)
        Me.txtFechaPago.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFechaPago.TabIndex = 83
        '
        'txtFechaFin
        '
        '
        '
        '
        Me.txtFechaFin.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaFin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFin.ButtonClear.Tooltip = ""
        Me.txtFechaFin.ButtonCustom.Tooltip = ""
        Me.txtFechaFin.ButtonCustom2.Tooltip = ""
        Me.txtFechaFin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtFechaFin.ButtonDropDown.Tooltip = ""
        Me.txtFechaFin.ButtonDropDown.Visible = True
        Me.txtFechaFin.ButtonFreeText.Tooltip = ""
        Me.txtFechaFin.Enabled = False
        Me.txtFechaFin.IsPopupCalendarOpen = False
        Me.txtFechaFin.Location = New System.Drawing.Point(333, 56)
        '
        '
        '
        Me.txtFechaFin.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaFin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFin.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtFechaFin.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFin.MonthCalendar.DisplayMonth = New Date(2013, 7, 1, 0, 0, 0, 0)
        Me.txtFechaFin.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaFin.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaFin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFin.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaFin.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFechaFin.Name = "txtFechaFin"
        Me.txtFechaFin.Size = New System.Drawing.Size(84, 20)
        Me.txtFechaFin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFechaFin.TabIndex = 82
        '
        'txtFechaIni
        '
        '
        '
        '
        Me.txtFechaIni.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaIni.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaIni.ButtonClear.Tooltip = ""
        Me.txtFechaIni.ButtonCustom.Tooltip = ""
        Me.txtFechaIni.ButtonCustom2.Tooltip = ""
        Me.txtFechaIni.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtFechaIni.ButtonDropDown.Tooltip = ""
        Me.txtFechaIni.ButtonDropDown.Visible = True
        Me.txtFechaIni.ButtonFreeText.Tooltip = ""
        Me.txtFechaIni.Enabled = False
        Me.txtFechaIni.IsPopupCalendarOpen = False
        Me.txtFechaIni.Location = New System.Drawing.Point(127, 56)
        '
        '
        '
        Me.txtFechaIni.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaIni.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaIni.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtFechaIni.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaIni.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaIni.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaIni.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaIni.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaIni.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaIni.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaIni.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaIni.MonthCalendar.DisplayMonth = New Date(2013, 7, 1, 0, 0, 0, 0)
        Me.txtFechaIni.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaIni.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaIni.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaIni.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaIni.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaIni.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaIni.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaIni.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFechaIni.Name = "txtFechaIni"
        Me.txtFechaIni.Size = New System.Drawing.Size(84, 20)
        Me.txtFechaIni.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFechaIni.TabIndex = 81
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(237, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 15)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Periodo"
        '
        'cmbMes
        '
        Me.cmbMes.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbMes.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbMes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbMes.ButtonClear.Tooltip = ""
        Me.cmbMes.ButtonCustom.Tooltip = ""
        Me.cmbMes.ButtonCustom2.Tooltip = ""
        Me.cmbMes.ButtonDropDown.Tooltip = ""
        Me.cmbMes.ButtonDropDown.Visible = True
        Me.cmbMes.DisplayMembers = "cod_super"
        Me.cmbMes.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbMes.Location = New System.Drawing.Point(127, 182)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(289, 22)
        Me.cmbMes.TabIndex = 3
        Me.cmbMes.ValueMember = "num_mes"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(237, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 78
        Me.Label2.Text = "Fecha final"
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.BackColor = System.Drawing.SystemColors.Window
        Me.lbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.Location = New System.Drawing.Point(27, 28)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(28, 15)
        Me.lbl1.TabIndex = 75
        Me.lbl1.Text = "Año"
        '
        'txtPeriodo
        '
        '
        '
        '
        Me.txtPeriodo.Border.Class = "TextBoxBorder"
        Me.txtPeriodo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPeriodo.ButtonCustom.Tooltip = ""
        Me.txtPeriodo.ButtonCustom2.Tooltip = ""
        Me.txtPeriodo.Enabled = False
        Me.txtPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.Location = New System.Drawing.Point(333, 25)
        Me.txtPeriodo.MaxLength = 2
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.Size = New System.Drawing.Size(84, 21)
        Me.txtPeriodo.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(27, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 15)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "Fecha inicial"
        '
        'cmbAno
        '
        Me.cmbAno.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbAno.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbAno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbAno.ButtonClear.Tooltip = ""
        Me.cmbAno.ButtonCustom.Tooltip = ""
        Me.cmbAno.ButtonCustom2.Tooltip = ""
        Me.cmbAno.ButtonDropDown.Tooltip = ""
        Me.cmbAno.ButtonDropDown.Visible = True
        Me.cmbAno.DisplayMembers = "cod_comp"
        Me.cmbAno.Enabled = False
        Me.cmbAno.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbAno.Location = New System.Drawing.Point(127, 25)
        Me.cmbAno.Name = "cmbAno"
        Me.cmbAno.Size = New System.Drawing.Size(84, 20)
        Me.cmbAno.TabIndex = 0
        Me.cmbAno.ValueMember = "ano"
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
        Me.tabBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.Location = New System.Drawing.Point(12, 62)
        Me.tabBuscar.Name = "tabBuscar"
        Me.tabBuscar.ReorderTabsEnabled = True
        Me.tabBuscar.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabBuscar.SelectedTabIndex = 0
        Me.tabBuscar.Size = New System.Drawing.Size(825, 342)
        Me.tabBuscar.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.tabBuscar.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.TabIndex = 112
        Me.tabBuscar.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit
        Me.tabBuscar.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabEmpleado, Me.tabTabla})
        Me.tabBuscar.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(645, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 17)
        Me.Label4.TabIndex = 114
        Me.Label4.Text = "ACTIVO(S):"
        '
        'lstActivo
        '
        Me.lstActivo.BackColor = System.Drawing.SystemColors.Control
        Me.lstActivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstActivo.FormattingEnabled = True
        Me.lstActivo.ItemHeight = 15
        Me.lstActivo.Items.AddRange(New Object() {"ACTIVO1", "ACTIVO2", "ACTIVO3", "ACTIVO4"})
        Me.lstActivo.Location = New System.Drawing.Point(742, 8)
        Me.lstActivo.Name = "lstActivo"
        Me.lstActivo.Size = New System.Drawing.Size(96, 47)
        Me.lstActivo.TabIndex = 116
        '
        'frmPeriodos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 462)
        Me.Controls.Add(Me.lstActivo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tabBuscar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPeriodos"
        Me.Text = "Periodos en tiempo y asistencia"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        Me.gpNuevo.ResumeLayout(False)
        Me.gpNuevo.PerformLayout()
        CType(Me.dgNuevosPeriodos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNuevoAno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaIni, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBuscar.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents ColAnoActivo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColPeriodoActivo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColUnicoActivo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrimero As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAnterior As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSiguiente As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnUltimo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents tabTabla As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents dgTabla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents tabEmpleado As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents pnlDatos As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbMes As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents txtPeriodo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Private WithEvents cmbAno As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents tabBuscar As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtFechaPago As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtFechaFin As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtFechaIni As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnEspecial As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents btnActivo As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents gpNuevo As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents txtFechaFinal As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtFechaInicial As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtNuevoAno As DevComponents.Editors.IntegerInput
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnGenerar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dgNuevosPeriodos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents lblDiaFinal As System.Windows.Forms.Label
    Friend WithEvents lblDiaInicial As System.Windows.Forms.Label
    Friend WithEvents txtPeriodoInicial As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnCrearEspeciales As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents colAno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPeriodo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFechaIni As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFechaFin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colActivo As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents lstActivo As System.Windows.Forms.ListBox
End Class
