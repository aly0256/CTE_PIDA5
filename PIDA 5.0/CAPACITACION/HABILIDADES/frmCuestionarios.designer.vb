<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCuestionarios
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCuestionarios))
        Me.EmpNav = New System.Windows.Forms.GroupBox()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrimero = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnAnterior = New DevComponents.DotNetBar.ButtonX()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnSiguiente = New DevComponents.DotNetBar.ButtonX()
        Me.btnUltimo = New DevComponents.DotNetBar.ButtonX()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.tabBuscar = New DevComponents.DotNetBar.SuperTabControl()
        Me.pnlDatos = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.btnPromediar = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgCuestionario = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.colCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCodRespuesta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPregunta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTitulo = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colCalificacion = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.colPromedio = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colUbicacion = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.unico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.intDias = New DevComponents.Editors.IntegerInput()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnRecertificacion = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tabEmpleado = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgTabla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.tabTabla = New DevComponents.DotNetBar.SuperTabItem()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.mnuCuestionario = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AgregarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SepararToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator()
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DataGridViewCheckBoxXColumn1 = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.EmpNav.SuspendLayout()
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBuscar.SuspendLayout()
        Me.pnlDatos.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgCuestionario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.intDias, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuCuestionario.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EmpNav
        '
        Me.EmpNav.Controls.Add(Me.btnCerrar)
        Me.EmpNav.Controls.Add(Me.btnPrimero)
        Me.EmpNav.Controls.Add(Me.btnReporte)
        Me.EmpNav.Controls.Add(Me.btnAnterior)
        Me.EmpNav.Controls.Add(Me.btnBorrar)
        Me.EmpNav.Controls.Add(Me.btnSiguiente)
        Me.EmpNav.Controls.Add(Me.btnUltimo)
        Me.EmpNav.Controls.Add(Me.btnBuscar)
        Me.EmpNav.Controls.Add(Me.btnEditar)
        Me.EmpNav.Controls.Add(Me.btnNuevo)
        Me.EmpNav.Location = New System.Drawing.Point(180, 492)
        Me.EmpNav.Name = "EmpNav"
        Me.EmpNav.Size = New System.Drawing.Size(825, 47)
        Me.EmpNav.TabIndex = 90
        Me.EmpNav.TabStop = False
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = My.Resources.Resources.Cerrar16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(736, 13)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 58
        Me.btnCerrar.Text = "Salir"
        '
        'btnPrimero
        '
        Me.btnPrimero.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrimero.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrimero.Image = My.Resources.Resources.First16
        Me.btnPrimero.Location = New System.Drawing.Point(7, 13)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(78, 25)
        Me.btnPrimero.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrimero.TabIndex = 23
        Me.btnPrimero.Text = "Inicio"
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnReporte.Location = New System.Drawing.Point(412, 13)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 57
        Me.btnReporte.Text = "Reporte"
        '
        'btnAnterior
        '
        Me.btnAnterior.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAnterior.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAnterior.Image = My.Resources.Resources.Prev16
        Me.btnAnterior.Location = New System.Drawing.Point(88, 13)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(78, 25)
        Me.btnAnterior.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAnterior.TabIndex = 24
        Me.btnAnterior.Text = "Anterior"
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = My.Resources.Resources.DeleteRec
        Me.btnBorrar.Location = New System.Drawing.Point(655, 13)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(78, 25)
        Me.btnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBorrar.TabIndex = 56
        Me.btnBorrar.Text = "Borrar"
        '
        'btnSiguiente
        '
        Me.btnSiguiente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSiguiente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSiguiente.Image = My.Resources.Resources.Next16
        Me.btnSiguiente.Location = New System.Drawing.Point(169, 13)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(78, 25)
        Me.btnSiguiente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSiguiente.TabIndex = 25
        Me.btnSiguiente.Text = "Siguiente"
        '
        'btnUltimo
        '
        Me.btnUltimo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnUltimo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnUltimo.Image = My.Resources.Resources.Last16
        Me.btnUltimo.Location = New System.Drawing.Point(250, 13)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(78, 25)
        Me.btnUltimo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnUltimo.TabIndex = 26
        Me.btnUltimo.Text = "Final"
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = My.Resources.Resources.Search16
        Me.btnBuscar.Location = New System.Drawing.Point(331, 13)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(78, 25)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 51
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Tooltip = "Buscar"
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = My.Resources.Resources.Edit
        Me.btnEditar.Location = New System.Drawing.Point(574, 13)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(78, 25)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 53
        Me.btnEditar.Text = "Editar"
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = My.Resources.Resources.NewRecord
        Me.btnNuevo.Location = New System.Drawing.Point(493, 13)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 25)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 52
        Me.btnNuevo.Text = "Agregar"
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
        Me.ReflectionLabel1.TabIndex = 89
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CUESTIONARIOS</b></font>"
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
        Me.tabBuscar.Size = New System.Drawing.Size(1160, 424)
        Me.tabBuscar.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.tabBuscar.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.TabIndex = 88
        Me.tabBuscar.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit
        Me.tabBuscar.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabEmpleado, Me.tabTabla})
        Me.tabBuscar.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.btnPromediar)
        Me.pnlDatos.Controls.Add(Me.Label3)
        Me.pnlDatos.Controls.Add(Me.Panel1)
        Me.pnlDatos.Controls.Add(Me.Label5)
        Me.pnlDatos.Controls.Add(Me.intDias)
        Me.pnlDatos.Controls.Add(Me.Label4)
        Me.pnlDatos.Controls.Add(Me.btnRecertificacion)
        Me.pnlDatos.Controls.Add(Me.Label1)
        Me.pnlDatos.Controls.Add(Me.txtCodigo)
        Me.pnlDatos.Controls.Add(Me.txtNombre)
        Me.pnlDatos.Controls.Add(Me.Label2)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(1089, 424)
        Me.pnlDatos.TabIndex = 63
        Me.pnlDatos.TabItem = Me.tabEmpleado
        '
        'btnPromediar
        '
        '
        '
        '
        Me.btnPromediar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnPromediar.Location = New System.Drawing.Point(169, 112)
        Me.btnPromediar.Name = "btnPromediar"
        Me.btnPromediar.OffText = "NO"
        Me.btnPromediar.OnText = "SI"
        Me.btnPromediar.Size = New System.Drawing.Size(80, 22)
        Me.btnPromediar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPromediar.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 15)
        Me.Label3.TabIndex = 89
        Me.Label3.Text = "Promediar"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Window
        Me.Panel1.Controls.Add(Me.dgCuestionario)
        Me.Panel1.Location = New System.Drawing.Point(33, 142)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1032, 257)
        Me.Panel1.TabIndex = 6
        '
        'dgCuestionario
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCuestionario.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgCuestionario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCuestionario.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCodigo, Me.colCodRespuesta, Me.colPregunta, Me.colTitulo, Me.colCalificacion, Me.colPromedio, Me.colUbicacion, Me.unico})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCuestionario.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgCuestionario.Dock = System.Windows.Forms.DockStyle.Left
        Me.dgCuestionario.EnableHeadersVisualStyles = False
        Me.dgCuestionario.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.dgCuestionario.Location = New System.Drawing.Point(0, 0)
        Me.dgCuestionario.Name = "dgCuestionario"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCuestionario.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgCuestionario.RowHeadersWidth = 30
        Me.dgCuestionario.Size = New System.Drawing.Size(1029, 257)
        Me.dgCuestionario.TabIndex = 0
        '
        'colCodigo
        '
        Me.colCodigo.DataPropertyName = "cod_pregunta"
        Me.colCodigo.HeaderText = "Código"
        Me.colCodigo.MaxInputLength = 5
        Me.colCodigo.Name = "colCodigo"
        Me.colCodigo.Width = 75
        '
        'colCodRespuesta
        '
        Me.colCodRespuesta.DataPropertyName = "cod_respuesta"
        Me.colCodRespuesta.HeaderText = "CódigoRespuesta"
        Me.colCodRespuesta.Name = "colCodRespuesta"
        Me.colCodRespuesta.Visible = False
        '
        'colPregunta
        '
        Me.colPregunta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colPregunta.DataPropertyName = "pregunta"
        Me.colPregunta.HeaderText = "Descripción de la pregunta"
        Me.colPregunta.MaxInputLength = 200
        Me.colPregunta.Name = "colPregunta"
        '
        'colTitulo
        '
        Me.colTitulo.DataPropertyName = "titulo"
        Me.colTitulo.FalseValue = "0"
        Me.colTitulo.HeaderText = "¿Es título?"
        Me.colTitulo.Name = "colTitulo"
        Me.colTitulo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colTitulo.TrueValue = "1"
        Me.colTitulo.Width = 75
        '
        'colCalificacion
        '
        '
        '
        '
        Me.colCalificacion.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.colCalificacion.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.colCalificacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.colCalificacion.BackgroundStyle.TextColor = System.Drawing.SystemColors.WindowText
        Me.colCalificacion.DataPropertyName = "calificacion_minima"
        Me.colCalificacion.HeaderText = "Calificación mínima"
        Me.colCalificacion.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.colCalificacion.MaxInputLength = 1000
        Me.colCalificacion.Name = "colCalificacion"
        Me.colCalificacion.Width = 75
        '
        'colPromedio
        '
        Me.colPromedio.DataPropertyName = "participa_promedio"
        Me.colPromedio.FalseValue = "0"
        Me.colPromedio.HeaderText = "Participa en promedio"
        Me.colPromedio.Name = "colPromedio"
        Me.colPromedio.TrueValue = "1"
        Me.colPromedio.Width = 75
        '
        'colUbicacion
        '
        '
        '
        '
        Me.colUbicacion.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.colUbicacion.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.colUbicacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.colUbicacion.BackgroundStyle.TextColor = System.Drawing.SystemColors.WindowText
        Me.colUbicacion.DataPropertyName = "ubicacion"
        Me.colUbicacion.HeaderText = "Ubicación"
        Me.colUbicacion.Increment = 10
        Me.colUbicacion.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.colUbicacion.MaxValue = 99999
        Me.colUbicacion.MinValue = 0
        Me.colUbicacion.Name = "colUbicacion"
        Me.colUbicacion.Width = 75
        '
        'unico
        '
        Me.unico.DataPropertyName = "cod_pregunta"
        Me.unico.HeaderText = "unico"
        Me.unico.Name = "unico"
        Me.unico.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(312, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 15)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "Tiempo p/recertificar"
        '
        'intDias
        '
        '
        '
        '
        Me.intDias.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.intDias.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.intDias.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.intDias.Location = New System.Drawing.Point(451, 83)
        Me.intDias.MaxValue = 3650
        Me.intDias.MinValue = 0
        Me.intDias.Name = "intDias"
        Me.intDias.ShowUpDown = True
        Me.intDias.Size = New System.Drawing.Size(80, 20)
        Me.intDias.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(30, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 15)
        Me.Label4.TabIndex = 84
        Me.Label4.Text = "Recertificación"
        '
        'btnRecertificacion
        '
        '
        '
        '
        Me.btnRecertificacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnRecertificacion.Location = New System.Drawing.Point(169, 82)
        Me.btnRecertificacion.Name = "btnRecertificacion"
        Me.btnRecertificacion.OffText = "NO"
        Me.btnRecertificacion.OnText = "SI"
        Me.btnRecertificacion.Size = New System.Drawing.Size(80, 22)
        Me.btnRecertificacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnRecertificacion.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Código"
        '
        'txtCodigo
        '
        '
        '
        '
        Me.txtCodigo.Border.Class = "TextBoxBorder"
        Me.txtCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(169, 24)
        Me.txtCodigo.MaxLength = 3
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(78, 21)
        Me.txtCodigo.TabIndex = 1
        '
        'txtNombre
        '
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(169, 53)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(362, 21)
        Me.txtNombre.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Nombre"
        '
        'tabEmpleado
        '
        Me.tabEmpleado.AttachedControl = Me.pnlDatos
        Me.tabEmpleado.GlobalItem = False
        Me.tabEmpleado.Name = "tabEmpleado"
        Me.tabEmpleado.Text = "Individual"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.dgTabla)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(1089, 424)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.tabTabla
        '
        'dgTabla
        '
        Me.dgTabla.AllowUserToAddRows = False
        Me.dgTabla.AllowUserToDeleteRows = False
        Me.dgTabla.AllowUserToOrderColumns = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTabla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(62, Byte), Integer))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTabla.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgTabla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTabla.EnableHeadersVisualStyles = False
        Me.dgTabla.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.dgTabla.Location = New System.Drawing.Point(0, 0)
        Me.dgTabla.MultiSelect = False
        Me.dgTabla.Name = "dgTabla"
        Me.dgTabla.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTabla.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgTabla.Size = New System.Drawing.Size(1089, 424)
        Me.dgTabla.TabIndex = 1
        '
        'tabTabla
        '
        Me.tabTabla.AttachedControl = Me.SuperTabControlPanel2
        Me.tabTabla.GlobalItem = False
        Me.tabTabla.Name = "tabTabla"
        Me.tabTabla.Text = "Lista"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "cod_evaluacion"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Código"
        Me.ColumnHeader1.Width.Relative = 30
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "nombre"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.Text = "Nombre"
        Me.ColumnHeader2.Width.Relative = 70
        '
        'mnuCuestionario
        '
        Me.mnuCuestionario.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarToolStripMenuItem, Me.EditarToolStripMenuItem, Me.ToolStripMenuItem1, Me.SepararToolStripMenuItem, Me.CerrarToolStripMenuItem})
        Me.mnuCuestionario.Name = "mnuCuestionario"
        Me.mnuCuestionario.Size = New System.Drawing.Size(117, 98)
        '
        'AgregarToolStripMenuItem
        '
        Me.AgregarToolStripMenuItem.Image = My.Resources.Resources.NewRecord
        Me.AgregarToolStripMenuItem.Name = "AgregarToolStripMenuItem"
        Me.AgregarToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.AgregarToolStripMenuItem.Text = "Agregar"
        '
        'EditarToolStripMenuItem
        '
        Me.EditarToolStripMenuItem.Image = My.Resources.Resources.Edit
        Me.EditarToolStripMenuItem.Name = "EditarToolStripMenuItem"
        Me.EditarToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.EditarToolStripMenuItem.Text = "Editar"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = My.Resources.Resources.DeleteRec
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(116, 22)
        Me.ToolStripMenuItem1.Text = "Borrar"
        '
        'SepararToolStripMenuItem
        '
        Me.SepararToolStripMenuItem.Name = "SepararToolStripMenuItem"
        Me.SepararToolStripMenuItem.Size = New System.Drawing.Size(113, 6)
        '
        'CerrarToolStripMenuItem
        '
        Me.CerrarToolStripMenuItem.Name = "CerrarToolStripMenuItem"
        Me.CerrarToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.CerrarToolStripMenuItem.Text = "Cerrar"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = My.Resources.Resources.questionaire48
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(27, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 91
        Me.PictureBox1.TabStop = False
        '
        'DataGridViewCheckBoxXColumn1
        '
        Me.DataGridViewCheckBoxXColumn1.CheckBoxImageChecked = My.Resources.Resources.Checked16
        Me.DataGridViewCheckBoxXColumn1.CheckBoxImageUnChecked = My.Resources.Resources.Unckecked16
        Me.DataGridViewCheckBoxXColumn1.Checked = True
        Me.DataGridViewCheckBoxXColumn1.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.DataGridViewCheckBoxXColumn1.CheckValue = Nothing
        Me.DataGridViewCheckBoxXColumn1.DataPropertyName = "encabezado"
        Me.DataGridViewCheckBoxXColumn1.HeaderText = "¿Es encabezado?"
        Me.DataGridViewCheckBoxXColumn1.Name = "DataGridViewCheckBoxXColumn1"
        '
        'frmCuestionarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1184, 539)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.EmpNav)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.tabBuscar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCuestionarios"
        Me.Text = "Cuestionarios"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.EmpNav.ResumeLayout(False)
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBuscar.ResumeLayout(False)
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgCuestionario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.intDias, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuCuestionario.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents EmpNav As System.Windows.Forms.GroupBox
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrimero As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAnterior As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSiguiente As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnUltimo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents tabBuscar As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents pnlDatos As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tabEmpleado As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents dgTabla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents tabTabla As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents intDias As DevComponents.Editors.IntegerInput
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnRecertificacion As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents mnuCuestionario As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AgregarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SepararToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CerrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgCuestionario As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents DataGridViewCheckBoxXColumn1 As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents btnPromediar As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents colCodigo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodRespuesta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPregunta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTitulo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colCalificacion As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents colPromedio As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colUbicacion As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents unico As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
