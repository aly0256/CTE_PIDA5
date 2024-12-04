<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAutorizacionTiempoExtra
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAutorizacionTiempoExtra))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.cmbPeriodo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.colUnico = New DevComponents.AdvTree.ColumnHeader()
        Me.colAno = New DevComponents.AdvTree.ColumnHeader()
        Me.colPeriodo = New DevComponents.AdvTree.ColumnHeader()
        Me.cmbFecha = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnMostrarInformacion = New DevComponents.DotNetBar.ButtonX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.EmpNav = New System.Windows.Forms.GroupBox()
        Me.labelTotalVista = New DevComponents.DotNetBar.LabelX()
        Me.pnlCentrado = New System.Windows.Forms.Panel()
        Me.btnGlobal = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnParametros = New DevComponents.DotNetBar.ButtonX()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnlEditar = New System.Windows.Forms.Panel()
        Me.prgEditar = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.lblAvance = New System.Windows.Forms.Label()
        Me.dgAutorizacion = New System.Windows.Forms.DataGridView()
        Me.colReloj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTurno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEntrada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSalida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtrasReales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAutorizadas = New DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn()
        Me.colAut = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colComentario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LayoutGroup1 = New DevComponents.DotNetBar.Layout.LayoutGroup()
        Me.LayoutControlItem4 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EmpNav.SuspendLayout()
        Me.pnlCentrado.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlEditar.SuspendLayout()
        CType(Me.dgAutorizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.Controls.Add(Me.cmbPeriodo)
        Me.pnlEncabezado.Controls.Add(Me.cmbFecha)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Controls.Add(Me.Label4)
        Me.pnlEncabezado.Controls.Add(Me.btnMostrarInformacion)
        Me.pnlEncabezado.Controls.Add(Me.Label5)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlEncabezado.Size = New System.Drawing.Size(1029, 78)
        Me.pnlEncabezado.TabIndex = 118
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
        Me.cmbPeriodo.Columns.Add(Me.colUnico)
        Me.cmbPeriodo.Columns.Add(Me.colAno)
        Me.cmbPeriodo.Columns.Add(Me.colPeriodo)
        Me.cmbPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPeriodo.FormatString = "d"
        Me.cmbPeriodo.FormattingEnabled = True
        Me.cmbPeriodo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPeriodo.Location = New System.Drawing.Point(559, 9)
        Me.cmbPeriodo.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbPeriodo.Name = "cmbPeriodo"
        Me.cmbPeriodo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbPeriodo.Size = New System.Drawing.Size(210, 26)
        Me.cmbPeriodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPeriodo.TabIndex = 0
        Me.cmbPeriodo.ValueMember = "unico"
        '
        'colUnico
        '
        Me.colUnico.DataFieldName = "unico"
        Me.colUnico.Name = "colUnico"
        Me.colUnico.Text = "Column"
        Me.colUnico.Visible = False
        Me.colUnico.Width.Absolute = 150
        '
        'colAno
        '
        Me.colAno.ColumnName = "colAno"
        Me.colAno.DataFieldName = "ano"
        Me.colAno.Name = "colAno"
        Me.colAno.Text = "AÑO"
        Me.colAno.Width.AutoSize = True
        Me.colAno.Width.Relative = 50
        '
        'colPeriodo
        '
        Me.colPeriodo.ColumnName = "colPeriodo"
        Me.colPeriodo.DataFieldName = "periodo"
        Me.colPeriodo.Name = "colPeriodo"
        Me.colPeriodo.StretchToFill = True
        Me.colPeriodo.Text = "PERIODO"
        Me.colPeriodo.Width.Relative = 50
        '
        'cmbFecha
        '
        Me.cmbFecha.DisplayMember = "fecha"
        Me.cmbFecha.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFecha.FormatString = "D"
        Me.cmbFecha.FormattingEnabled = True
        Me.cmbFecha.ItemHeight = 17
        Me.cmbFecha.Location = New System.Drawing.Point(559, 42)
        Me.cmbFecha.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbFecha.MinimumSize = New System.Drawing.Size(75, 0)
        Me.cmbFecha.Name = "cmbFecha"
        Me.cmbFecha.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbFecha.Size = New System.Drawing.Size(210, 23)
        Me.cmbFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbFecha.TabIndex = 1
        Me.cmbFecha.ValueMember = "fecha"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.ReflectionLabel1)
        Me.pnlTitulo.Controls.Add(Me.picImagen)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTitulo.Location = New System.Drawing.Point(3, 3)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(480, 72)
        Me.pnlTitulo.TabIndex = 122
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
        Me.ReflectionLabel1.Size = New System.Drawing.Size(389, 40)
        Me.ReflectionLabel1.TabIndex = 109
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>AUTORIZACIÓN DE TIEMPO EXTRA</b></font>"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.CheckAuthorization32
        Me.picImagen.Location = New System.Drawing.Point(12, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(32, 32)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picImagen.TabIndex = 110
        Me.picImagen.TabStop = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(489, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(67, 26)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Periodo"
        '
        'btnMostrarInformacion
        '
        Me.btnMostrarInformacion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnMostrarInformacion.CausesValidation = False
        Me.btnMostrarInformacion.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.btnMostrarInformacion.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnMostrarInformacion.FocusCuesEnabled = False
        Me.btnMostrarInformacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMostrarInformacion.Image = Global.PIDA.My.Resources.Resources.refresh16
        Me.btnMostrarInformacion.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnMostrarInformacion.Location = New System.Drawing.Point(995, 3)
        Me.btnMostrarInformacion.Name = "btnMostrarInformacion"
        Me.btnMostrarInformacion.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5)
        Me.btnMostrarInformacion.Size = New System.Drawing.Size(31, 72)
        Me.btnMostrarInformacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnMostrarInformacion.TabIndex = 125
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(489, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(67, 23)
        Me.Label5.TabIndex = 123
        Me.Label5.Text = "Fecha"
        '
        'EmpNav
        '
        Me.EmpNav.Controls.Add(Me.labelTotalVista)
        Me.EmpNav.Controls.Add(Me.pnlCentrado)
        Me.EmpNav.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.EmpNav.Location = New System.Drawing.Point(0, 446)
        Me.EmpNav.Name = "EmpNav"
        Me.EmpNav.Padding = New System.Windows.Forms.Padding(0)
        Me.EmpNav.Size = New System.Drawing.Size(1029, 42)
        Me.EmpNav.TabIndex = 117
        Me.EmpNav.TabStop = False
        '
        'labelTotalVista
        '
        Me.labelTotalVista.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.labelTotalVista.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.labelTotalVista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelTotalVista.Location = New System.Drawing.Point(873, 10)
        Me.labelTotalVista.Name = "labelTotalVista"
        Me.labelTotalVista.Size = New System.Drawing.Size(153, 23)
        Me.labelTotalVista.TabIndex = 125
        Me.labelTotalVista.Text = "TOTAL: N EMPLEADOS"
        '
        'pnlCentrado
        '
        Me.pnlCentrado.Controls.Add(Me.btnGlobal)
        Me.pnlCentrado.Controls.Add(Me.btnReporte)
        Me.pnlCentrado.Controls.Add(Me.btnCerrar)
        Me.pnlCentrado.Controls.Add(Me.btnNuevo)
        Me.pnlCentrado.Controls.Add(Me.btnEditar)
        Me.pnlCentrado.Controls.Add(Me.btnBorrar)
        Me.pnlCentrado.Controls.Add(Me.btnParametros)
        Me.pnlCentrado.Location = New System.Drawing.Point(153, 6)
        Me.pnlCentrado.Name = "pnlCentrado"
        Me.pnlCentrado.Size = New System.Drawing.Size(705, 30)
        Me.pnlCentrado.TabIndex = 59
        '
        'btnGlobal
        '
        Me.btnGlobal.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGlobal.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGlobal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGlobal.Image = Global.PIDA.My.Resources.Resources.All16
        Me.btnGlobal.Location = New System.Drawing.Point(121, 2)
        Me.btnGlobal.Name = "btnGlobal"
        Me.btnGlobal.Size = New System.Drawing.Size(131, 25)
        Me.btnGlobal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGlobal.TabIndex = 59
        Me.btnGlobal.Text = "Autorización global"
        Me.btnGlobal.Visible = False
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnReporte.Location = New System.Drawing.Point(279, 2)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 57
        Me.btnReporte.Text = "Reporte"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(623, 2)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 58
        Me.btnCerrar.Text = "Salir"
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.NewRecord
        Me.btnNuevo.Location = New System.Drawing.Point(365, 2)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 25)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 52
        Me.btnNuevo.Text = "Agregar"
        Me.btnNuevo.Visible = False
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = Global.PIDA.My.Resources.Resources.Edit
        Me.btnEditar.Location = New System.Drawing.Point(451, 2)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(78, 25)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 53
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.Visible = False
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = Global.PIDA.My.Resources.Resources.DeleteRec
        Me.btnBorrar.Location = New System.Drawing.Point(537, 2)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(78, 25)
        Me.btnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBorrar.TabIndex = 56
        Me.btnBorrar.Text = "Borrar"
        Me.btnBorrar.Visible = False
        '
        'btnParametros
        '
        Me.btnParametros.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnParametros.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnParametros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnParametros.Image = Global.PIDA.My.Resources.Resources.CambiosMasivos16
        Me.btnParametros.Location = New System.Drawing.Point(3, 2)
        Me.btnParametros.Name = "btnParametros"
        Me.btnParametros.Size = New System.Drawing.Size(110, 25)
        Me.btnParametros.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnParametros.TabIndex = 26
        Me.btnParametros.Text = "Agregar grupo"
        Me.btnParametros.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pnlEditar)
        Me.Panel2.Controls.Add(Me.dgAutorizacion)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 78)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1029, 368)
        Me.Panel2.TabIndex = 120
        '
        'pnlEditar
        '
        Me.pnlEditar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEditar.Controls.Add(Me.prgEditar)
        Me.pnlEditar.Controls.Add(Me.lblAvance)
        Me.pnlEditar.Location = New System.Drawing.Point(452, 93)
        Me.pnlEditar.Name = "pnlEditar"
        Me.pnlEditar.Size = New System.Drawing.Size(242, 210)
        Me.pnlEditar.TabIndex = 123
        Me.pnlEditar.Visible = False
        '
        'prgEditar
        '
        Me.prgEditar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        '
        '
        '
        Me.prgEditar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.prgEditar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.prgEditar.FocusCuesEnabled = False
        Me.prgEditar.Location = New System.Drawing.Point(0, 0)
        Me.prgEditar.Name = "prgEditar"
        Me.prgEditar.Padding = New System.Windows.Forms.Padding(5)
        Me.prgEditar.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.prgEditar.ProgressTextFormat = ""
        Me.prgEditar.ProgressTextVisible = True
        Me.prgEditar.Size = New System.Drawing.Size(240, 177)
        Me.prgEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.prgEditar.TabIndex = 125
        '
        'lblAvance
        '
        Me.lblAvance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblAvance.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblAvance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvance.Location = New System.Drawing.Point(0, 177)
        Me.lblAvance.Name = "lblAvance"
        Me.lblAvance.Size = New System.Drawing.Size(240, 31)
        Me.lblAvance.TabIndex = 124
        Me.lblAvance.Text = "Cargando información"
        Me.lblAvance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgAutorizacion
        '
        Me.dgAutorizacion.AllowUserToAddRows = False
        Me.dgAutorizacion.AllowUserToDeleteRows = False
        Me.dgAutorizacion.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAutorizacion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgAutorizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAutorizacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colReloj, Me.colNombre, Me.colFecha, Me.colTipo, Me.colDepto, Me.colTurno, Me.colEntrada, Me.colSalida, Me.colExtrasReales, Me.colAutorizadas, Me.colAut, Me.colComentario})
        Me.dgAutorizacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgAutorizacion.Location = New System.Drawing.Point(0, 0)
        Me.dgAutorizacion.MultiSelect = False
        Me.dgAutorizacion.Name = "dgAutorizacion"
        Me.dgAutorizacion.RowHeadersWidth = 25
        Me.dgAutorizacion.Size = New System.Drawing.Size(1029, 368)
        Me.dgAutorizacion.TabIndex = 121
        '
        'colReloj
        '
        Me.colReloj.DataPropertyName = "RELOJ"
        Me.colReloj.HeaderText = "RELOJ"
        Me.colReloj.MaxInputLength = 6
        Me.colReloj.Name = "colReloj"
        Me.colReloj.Width = 50
        '
        'colNombre
        '
        Me.colNombre.DataPropertyName = "nombres"
        Me.colNombre.HeaderText = "NOMBRE"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        Me.colNombre.Width = 250
        '
        'colFecha
        '
        Me.colFecha.DataPropertyName = "fecha"
        Me.colFecha.HeaderText = "FECHA"
        Me.colFecha.Name = "colFecha"
        Me.colFecha.ReadOnly = True
        Me.colFecha.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colFecha.Width = 75
        '
        'colTipo
        '
        Me.colTipo.DataPropertyName = "cod_tipo"
        Me.colTipo.HeaderText = "TIPO"
        Me.colTipo.Name = "colTipo"
        Me.colTipo.Width = 50
        '
        'colDepto
        '
        Me.colDepto.DataPropertyName = "cod_depto"
        Me.colDepto.HeaderText = "DEPTO"
        Me.colDepto.Name = "colDepto"
        Me.colDepto.Width = 50
        '
        'colTurno
        '
        Me.colTurno.DataPropertyName = "cod_turno"
        Me.colTurno.HeaderText = "TURNO"
        Me.colTurno.Name = "colTurno"
        Me.colTurno.Width = 50
        '
        'colEntrada
        '
        Me.colEntrada.DataPropertyName = "entrada"
        Me.colEntrada.HeaderText = "ENTRADA"
        Me.colEntrada.MaxInputLength = 5
        Me.colEntrada.Name = "colEntrada"
        Me.colEntrada.ReadOnly = True
        Me.colEntrada.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colEntrada.Width = 75
        '
        'colSalida
        '
        Me.colSalida.DataPropertyName = "salida"
        Me.colSalida.HeaderText = "SALIDA"
        Me.colSalida.MaxInputLength = 5
        Me.colSalida.Name = "colSalida"
        Me.colSalida.ReadOnly = True
        Me.colSalida.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colSalida.Width = 75
        '
        'colExtrasReales
        '
        Me.colExtrasReales.DataPropertyName = "extras_reales"
        Me.colExtrasReales.HeaderText = "EXTRAS REALES"
        Me.colExtrasReales.MaxInputLength = 5
        Me.colExtrasReales.Name = "colExtrasReales"
        Me.colExtrasReales.ReadOnly = True
        Me.colExtrasReales.Width = 75
        '
        'colAutorizadas
        '
        Me.colAutorizadas.AutoCompleteCustomSource.AddRange(New String() {"TODO", "1:00", "1:15", "1:30", "1:45", "2:00", "2:15", "2:30", "2:45", "3:00", "3:15", "3:30", "3:45", "4:00", "4:15", "4:30", "4:45", "5:00", "5:15", "5:30", "5:45", "6:00", "6:15", "6:30", "6:45", "7:00", "7:15", "7:30", "7:45", "8:00", "8:15", "8:30", "8:45", "9:00", "9:15", "9:30", "9:45", "10:00", "10:15", "10:30", "10:45", "11:00", "11:15", "11:30", "11:45", "12:00"})
        Me.colAutorizadas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.colAutorizadas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.colAutorizadas.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.colAutorizadas.BackgroundStyle.Class = "DataGridViewIpAddressBorder"
        Me.colAutorizadas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.colAutorizadas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.colAutorizadas.DataPropertyName = "extras_autorizadas"
        Me.colAutorizadas.ForeColor = System.Drawing.SystemColors.ControlText
        Me.colAutorizadas.HeaderText = "EXTRAS AUTORIZADAS"
        Me.colAutorizadas.HideSelection = False
        Me.colAutorizadas.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.colAutorizadas.Name = "colAutorizadas"
        Me.colAutorizadas.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.colAutorizadas.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colAutorizadas.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.colAutorizadas.Text = ""
        Me.colAutorizadas.Width = 80
        '
        'colAut
        '
        Me.colAut.DataPropertyName = "autori_a1"
        Me.colAut.HeaderText = "AUT."
        Me.colAut.MinimumWidth = 50
        Me.colAut.Name = "colAut"
        Me.colAut.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colAut.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colAut.Width = 50
        '
        'colComentario
        '
        Me.colComentario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colComentario.DataPropertyName = "cometario"
        Me.colComentario.HeaderText = "COMENTARIO"
        Me.colComentario.Name = "colComentario"
        '
        'LayoutGroup1
        '
        Me.LayoutGroup1.Height = 100
        Me.LayoutGroup1.MinSize = New System.Drawing.Size(120, 32)
        Me.LayoutGroup1.Name = "LayoutGroup1"
        Me.LayoutGroup1.TextPosition = DevComponents.DotNetBar.Layout.eLayoutPosition.Top
        Me.LayoutGroup1.Width = 200
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Height = 28
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(64, 18)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Text = "Label:"
        Me.LayoutControlItem4.Width = 95
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Height = 31
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(64, 18)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Text = "Label:"
        Me.LayoutControlItem1.Width = 93
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Height = 31
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(120, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Text = "Label:"
        Me.LayoutControlItem7.Width = 100
        Me.LayoutControlItem7.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'SuperTooltip1
        '
        Me.SuperTooltip1.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("TODO EL TIEMPO EXTRA", "", "Para autorizar todo el tiempo extra trabajado," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "indicar ""*"" o ""TODO""", Global.PIDA.My.Resources.Resources.Information48, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray)
        Me.SuperTooltip1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'frmAutorizacionTiempoExtra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1029, 488)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.EmpNav)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAutorizacionTiempoExtra"
        Me.Text = "Autorización de tiempo extra SUPERVISOR"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EmpNav.ResumeLayout(False)
        Me.pnlCentrado.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.pnlEditar.ResumeLayout(False)
        CType(Me.dgAutorizacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EmpNav As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dgAutorizacion As System.Windows.Forms.DataGridView
    Friend WithEvents colUnico As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colAno As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colPeriodo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents pnlCentrado As System.Windows.Forms.Panel
    Friend WithEvents btnGlobal As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cmbFecha As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbPeriodo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents LayoutGroup1 As DevComponents.DotNetBar.Layout.LayoutGroup
    Friend WithEvents LayoutControlItem4 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnMostrarInformacion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents pnlEditar As System.Windows.Forms.Panel
    Friend WithEvents prgEditar As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents lblAvance As System.Windows.Forms.Label
    Friend WithEvents btnParametros As DevComponents.DotNetBar.ButtonX
    Friend WithEvents labelTotalVista As DevComponents.DotNetBar.LabelX
    Friend WithEvents colReloj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTurno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEntrada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSalida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtrasReales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAutorizadas As DevComponents.DotNetBar.Controls.DataGridViewTextBoxDropDownColumn
    Friend WithEvents colAut As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colComentario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
End Class
