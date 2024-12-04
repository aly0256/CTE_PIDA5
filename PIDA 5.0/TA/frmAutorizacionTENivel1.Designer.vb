<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAutorizacionTEENivel1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAutorizacionTEENivel1))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.cmbPeriodo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.colUnico = New DevComponents.AdvTree.ColumnHeader()
        Me.colAno = New DevComponents.AdvTree.ColumnHeader()
        Me.colPeriodo = New DevComponents.AdvTree.ColumnHeader()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.btnMostrarInformacion = New DevComponents.DotNetBar.ButtonX()
        Me.EmpNav = New System.Windows.Forms.GroupBox()
        Me.pnlCentrado = New System.Windows.Forms.Panel()
        Me.btnGlobal = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnParametros = New DevComponents.DotNetBar.ButtonX()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgAutorizacion = New System.Windows.Forms.DataGridView()
        Me.colAutorizado = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.RELOJ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEntrada = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSalida = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtrasReales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAutorizadas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMotivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDeptoOriginal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAusentismo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.barSupervisores = New DevComponents.DotNetBar.SideBar()
        Me.barPanelSupervisores = New DevComponents.DotNetBar.SideBarPanelItem()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.pnlEditar = New System.Windows.Forms.Panel()
        Me.prgEditar = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LayoutGroup1 = New DevComponents.DotNetBar.Layout.LayoutGroup()
        Me.LayoutControlItem4 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.pnlEncabezado.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EmpNav.SuspendLayout()
        Me.pnlCentrado.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgAutorizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlEditar.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.Controls.Add(Me.Panel11)
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Controls.Add(Me.btnMostrarInformacion)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlEncabezado.Size = New System.Drawing.Size(1029, 60)
        Me.pnlEncabezado.TabIndex = 118
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel11.Controls.Add(Me.Panel5)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel11.Location = New System.Drawing.Point(483, 3)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(512, 54)
        Me.Panel11.TabIndex = 1
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Panel9)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.MinimumSize = New System.Drawing.Size(175, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Padding = New System.Windows.Forms.Padding(3)
        Me.Panel5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Panel5.Size = New System.Drawing.Size(512, 54)
        Me.Panel5.TabIndex = 0
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.SystemColors.Control
        Me.Panel9.Controls.Add(Me.cmbPeriodo)
        Me.Panel9.Controls.Add(Me.Label4)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(3, 3)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Padding = New System.Windows.Forms.Padding(12)
        Me.Panel9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Panel9.Size = New System.Drawing.Size(506, 48)
        Me.Panel9.TabIndex = 122
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
        Me.cmbPeriodo.Columns.Add(Me.colPeriodo)
        Me.cmbPeriodo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cmbPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPeriodo.FormatString = "d"
        Me.cmbPeriodo.FormattingEnabled = True
        Me.cmbPeriodo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPeriodo.Location = New System.Drawing.Point(79, 12)
        Me.cmbPeriodo.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbPeriodo.Name = "cmbPeriodo"
        Me.cmbPeriodo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbPeriodo.Size = New System.Drawing.Size(415, 24)
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
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label4.Location = New System.Drawing.Point(12, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(67, 24)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Periodo"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.ReflectionLabel1)
        Me.pnlTitulo.Controls.Add(Me.picImagen)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTitulo.Location = New System.Drawing.Point(3, 3)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(480, 54)
        Me.pnlTitulo.TabIndex = 122
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
        Me.ReflectionLabel1.Size = New System.Drawing.Size(389, 40)
        Me.ReflectionLabel1.TabIndex = 109
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>AUTORIZACIÓN DE TIEMPO EXTRA</b></font>"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.Signature32
        Me.picImagen.Location = New System.Drawing.Point(12, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(27, 26)
        Me.picImagen.TabIndex = 110
        Me.picImagen.TabStop = False
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
        Me.btnMostrarInformacion.Size = New System.Drawing.Size(31, 54)
        Me.btnMostrarInformacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnMostrarInformacion.TabIndex = 125
        '
        'EmpNav
        '
        Me.EmpNav.Controls.Add(Me.pnlCentrado)
        Me.EmpNav.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.EmpNav.Location = New System.Drawing.Point(0, 446)
        Me.EmpNav.Name = "EmpNav"
        Me.EmpNav.Padding = New System.Windows.Forms.Padding(0)
        Me.EmpNav.Size = New System.Drawing.Size(1029, 42)
        Me.EmpNav.TabIndex = 117
        Me.EmpNav.TabStop = False
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
        Me.pnlCentrado.Location = New System.Drawing.Point(61, 9)
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
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgAutorizacion)
        Me.Panel2.Controls.Add(Me.barSupervisores)
        Me.Panel2.Controls.Add(Me.pnlEditar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 60)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1029, 386)
        Me.Panel2.TabIndex = 120
        '
        'dgAutorizacion
        '
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
        Me.dgAutorizacion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAutorizado, Me.RELOJ, Me.nombre, Me.colFecha, Me.colEntrada, Me.colSalida, Me.colExtrasReales, Me.colAutorizadas, Me.colMotivo, Me.colDepto, Me.colDeptoOriginal, Me.colAusentismo})
        Me.dgAutorizacion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgAutorizacion.Location = New System.Drawing.Point(235, 0)
        Me.dgAutorizacion.MultiSelect = False
        Me.dgAutorizacion.Name = "dgAutorizacion"
        Me.dgAutorizacion.RowHeadersWidth = 25
        Me.dgAutorizacion.Size = New System.Drawing.Size(794, 386)
        Me.dgAutorizacion.TabIndex = 121
        '
        'colAutorizado
        '
        Me.colAutorizado.Checked = True
        Me.colAutorizado.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.colAutorizado.CheckValue = Nothing
        Me.colAutorizado.HeaderText = "AUTORIZADO"
        Me.colAutorizado.Name = "colAutorizado"
        Me.colAutorizado.Width = 80
        '
        'RELOJ
        '
        Me.RELOJ.DataPropertyName = "RELOJ"
        Me.RELOJ.HeaderText = "RELOJ"
        Me.RELOJ.MaxInputLength = 6
        Me.RELOJ.Name = "RELOJ"
        Me.RELOJ.Width = 50
        '
        'nombre
        '
        Me.nombre.DataPropertyName = "nombres"
        Me.nombre.HeaderText = "NOMBRE"
        Me.nombre.Name = "nombre"
        Me.nombre.ReadOnly = True
        Me.nombre.Width = 250
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
        Me.colAutorizadas.DataPropertyName = "extras_autorizadas"
        Me.colAutorizadas.HeaderText = "EXTRAS AUTORIZADAS"
        Me.colAutorizadas.MaxInputLength = 5
        Me.colAutorizadas.Name = "colAutorizadas"
        Me.colAutorizadas.Width = 80
        '
        'colMotivo
        '
        Me.colMotivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colMotivo.DataPropertyName = "comentario"
        Me.colMotivo.HeaderText = "MOTIVO"
        Me.colMotivo.MaxInputLength = 200
        Me.colMotivo.MinimumWidth = 150
        Me.colMotivo.Name = "colMotivo"
        '
        'colDepto
        '
        Me.colDepto.DataPropertyName = "depto_transferencia"
        Me.colDepto.HeaderText = "DEPARTAMENTO TIEMPO EXTRA"
        Me.colDepto.MaxInputLength = 5
        Me.colDepto.Name = "colDepto"
        '
        'colDeptoOriginal
        '
        Me.colDeptoOriginal.DataPropertyName = "cod_depto"
        Me.colDeptoOriginal.HeaderText = "DEPARTAMENTO EMPLEADO"
        Me.colDeptoOriginal.MaxInputLength = 5
        Me.colDeptoOriginal.Name = "colDeptoOriginal"
        Me.colDeptoOriginal.ReadOnly = True
        '
        'colAusentismo
        '
        Me.colAusentismo.DataPropertyName = "ausentismo"
        Me.colAusentismo.HeaderText = "AUSENTISMO"
        Me.colAusentismo.MaxInputLength = 30
        Me.colAusentismo.Name = "colAusentismo"
        Me.colAusentismo.ReadOnly = True
        '
        'barSupervisores
        '
        Me.barSupervisores.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar
        Me.barSupervisores.Appearance = DevComponents.DotNetBar.eSideBarAppearance.Flat
        Me.barSupervisores.BorderStyle = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.barSupervisores.ColorScheme.ItemCheckedBackground = System.Drawing.Color.Empty
        Me.barSupervisores.ColorScheme.ItemCheckedBorder = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.barSupervisores.ColorScheme.ItemExpandedBackground = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.barSupervisores.ColorScheme.ItemExpandedBackground2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.barSupervisores.ColorScheme.ItemExpandedShadow = System.Drawing.Color.Empty
        Me.barSupervisores.ColorScheme.ItemHotBackground = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.barSupervisores.ColorScheme.ItemHotBackground2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(208, Byte), Integer), CType(CType(145, Byte), Integer))
        Me.barSupervisores.ColorScheme.ItemHotBorder = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.barSupervisores.ColorScheme.ItemPressedBackground = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.barSupervisores.ColorScheme.ItemPressedBackground2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.barSupervisores.ColorScheme.ItemPressedBorder = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.barSupervisores.ColorScheme.ItemPressedText = System.Drawing.SystemColors.ControlText
        Me.barSupervisores.ColorScheme.MenuBackground = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.barSupervisores.ColorScheme.MenuBorder = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.barSupervisores.ColorScheme.MenuSide = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.barSupervisores.ColorScheme.MenuSide2 = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.barSupervisores.Dock = System.Windows.Forms.DockStyle.Left
        Me.barSupervisores.ExpandedPanel = Me.barPanelSupervisores
        Me.barSupervisores.Location = New System.Drawing.Point(0, 0)
        Me.barSupervisores.Name = "barSupervisores"
        Me.barSupervisores.Panels.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.barPanelSupervisores})
        Me.barSupervisores.Size = New System.Drawing.Size(235, 386)
        Me.barSupervisores.TabIndex = 124
        Me.barSupervisores.Text = "SideBar1"
        Me.barSupervisores.UsingSystemColors = True
        '
        'barPanelSupervisores
        '
        Me.barPanelSupervisores.BackgroundStyle.BackColor1.Color = System.Drawing.SystemColors.InactiveBorder
        Me.barPanelSupervisores.BackgroundStyle.BackColor2.Color = System.Drawing.SystemColors.InactiveBorder
        Me.barPanelSupervisores.BackgroundStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.barPanelSupervisores.BackgroundStyle.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.barPanelSupervisores.BackgroundStyle.ForeColor.Color = System.Drawing.SystemColors.HotTrack
        Me.barPanelSupervisores.HeaderHotStyle.Alignment = System.Drawing.StringAlignment.Center
        Me.barPanelSupervisores.HeaderHotStyle.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.barPanelSupervisores.HeaderHotStyle.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.barPanelSupervisores.HeaderHotStyle.ForeColor.Color = System.Drawing.SystemColors.ControlText
        Me.barPanelSupervisores.HeaderHotStyle.GradientAngle = 90
        Me.barPanelSupervisores.HeaderSideHotStyle.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.barPanelSupervisores.HeaderSideHotStyle.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.barPanelSupervisores.HeaderSideHotStyle.GradientAngle = 90
        Me.barPanelSupervisores.HeaderSideStyle.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.barPanelSupervisores.HeaderSideStyle.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.barPanelSupervisores.HeaderSideStyle.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.barPanelSupervisores.HeaderSideStyle.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.barPanelSupervisores.HeaderSideStyle.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Top) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.barPanelSupervisores.HeaderSideStyle.GradientAngle = 90
        Me.barPanelSupervisores.HeaderStyle.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.barPanelSupervisores.HeaderStyle.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(135, Byte), Integer), CType(CType(173, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.barPanelSupervisores.HeaderStyle.Border = DevComponents.DotNetBar.eBorderType.DoubleLine
        Me.barPanelSupervisores.HeaderStyle.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.barPanelSupervisores.HeaderStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.barPanelSupervisores.HeaderStyle.ForeColor.Color = System.Drawing.SystemColors.ControlText
        Me.barPanelSupervisores.HeaderStyle.GradientAngle = 90
        Me.barPanelSupervisores.HotFontBold = True
        Me.barPanelSupervisores.HotFontUnderline = True
        Me.barPanelSupervisores.Image = Global.PIDA.My.Resources.Resources.Star24
        Me.barPanelSupervisores.Name = "barPanelSupervisores"
        Me.barPanelSupervisores.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem1})
        Me.barPanelSupervisores.Text = "SUPERVISORES"
        '
        'ButtonItem1
        '
        Me.ButtonItem1.BeginGroup = True
        Me.ButtonItem1.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.ButtonItem1.Checked = True
        Me.ButtonItem1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb
        Me.ButtonItem1.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.PopupType = DevComponents.DotNetBar.ePopupType.ToolBar
        Me.ButtonItem1.Text = "New Button"
        '
        'pnlEditar
        '
        Me.pnlEditar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEditar.Controls.Add(Me.prgEditar)
        Me.pnlEditar.Controls.Add(Me.Label1)
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
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 177)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 31)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "Cargando información"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'frmAutorizacionTEENivel1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1029, 488)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.EmpNav)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAutorizacionTEENivel1"
        Me.Text = "Autorización de tiempo extra NIVEL 1"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EmpNav.ResumeLayout(False)
        Me.pnlCentrado.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgAutorizacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlEditar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnParametros As DevComponents.DotNetBar.ButtonX
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
    Friend WithEvents cmbPeriodo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents LayoutGroup1 As DevComponents.DotNetBar.Layout.LayoutGroup
    Friend WithEvents LayoutControlItem4 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents btnMostrarInformacion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents pnlEditar As System.Windows.Forms.Panel
    Friend WithEvents prgEditar As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents barSupervisores As DevComponents.DotNetBar.SideBar
    Friend WithEvents barPanelSupervisores As DevComponents.DotNetBar.SideBarPanelItem
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents colAutorizado As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents RELOJ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEntrada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSalida As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtrasReales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAutorizadas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMotivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDepto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDeptoOriginal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAusentismo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
