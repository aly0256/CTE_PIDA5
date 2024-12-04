<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRespuestas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRespuestas))
        Me.tabEmpleado = New DevComponents.DotNetBar.SuperTabItem()
        Me.pnlDatos = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.pnlRango = New System.Windows.Forms.Panel()
        Me.dgRango = New System.Windows.Forms.DataGridView()
        Me.colIdentificador = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colValorMinimo = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.colValorMaximo = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.pnlNumerico = New System.Windows.Forms.Panel()
        Me.intMaximo = New DevComponents.Editors.IntegerInput()
        Me.intMinimo = New DevComponents.Editors.IntegerInput()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbEstilo = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.pnlClasificacion = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.stpClasificacion = New DevComponents.DotNetBar.ProgressSteps()
        Me.mnuClasificacion = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AgregarNuevaClasificaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarTextoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarClasificaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StepItem1 = New DevComponents.DotNetBar.StepItem()
        Me.pnlLogico = New System.Windows.Forms.Panel()
        Me.txtNoRequerido = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtFalso = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtVerdadero = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlOpcionMultiple = New System.Windows.Forms.Panel()
        Me.chkSeleccionMultiple = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkUnaRespuesta = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.lblVarias = New System.Windows.Forms.Label()
        Me.dgValidas = New System.Windows.Forms.DataGridView()
        Me.colRespuestas = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colValor = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader6 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.codClasif = New DevComponents.AdvTree.ColumnHeader()
        Me.Nombre = New DevComponents.AdvTree.ColumnHeader()
        Me.dgTabla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.tabTabla = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.EmpNav = New System.Windows.Forms.GroupBox()
        Me.tabBuscar = New DevComponents.DotNetBar.SuperTabControl()
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.pnlDatos.SuspendLayout()
        Me.pnlRango.SuspendLayout()
        CType(Me.dgRango, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNumerico.SuspendLayout()
        CType(Me.intMaximo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.intMinimo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlClasificacion.SuspendLayout()
        Me.mnuClasificacion.SuspendLayout()
        Me.pnlLogico.SuspendLayout()
        Me.pnlOpcionMultiple.SuspendLayout()
        CType(Me.dgValidas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel2.SuspendLayout()
        Me.EmpNav.SuspendLayout()
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBuscar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.pnlDatos.Controls.Add(Me.pnlRango)
        Me.pnlDatos.Controls.Add(Me.pnlNumerico)
        Me.pnlDatos.Controls.Add(Me.cmbEstilo)
        Me.pnlDatos.Controls.Add(Me.pnlClasificacion)
        Me.pnlDatos.Controls.Add(Me.pnlLogico)
        Me.pnlDatos.Controls.Add(Me.Label4)
        Me.pnlDatos.Controls.Add(Me.Label1)
        Me.pnlDatos.Controls.Add(Me.txtCodigo)
        Me.pnlDatos.Controls.Add(Me.txtNombre)
        Me.pnlDatos.Controls.Add(Me.Label2)
        Me.pnlDatos.Controls.Add(Me.pnlOpcionMultiple)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(754, 405)
        Me.pnlDatos.TabIndex = 0
        Me.pnlDatos.TabItem = Me.tabEmpleado
        '
        'pnlRango
        '
        Me.pnlRango.BackColor = System.Drawing.SystemColors.Window
        Me.pnlRango.Controls.Add(Me.dgRango)
        Me.pnlRango.Location = New System.Drawing.Point(261, 255)
        Me.pnlRango.Name = "pnlRango"
        Me.pnlRango.Size = New System.Drawing.Size(470, 163)
        Me.pnlRango.TabIndex = 87
        Me.pnlRango.Visible = False
        '
        'dgRango
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgRango.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgRango.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgRango.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colIdentificador, Me.colValorMinimo, Me.colValorMaximo})
        Me.dgRango.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgRango.Location = New System.Drawing.Point(0, 0)
        Me.dgRango.Name = "dgRango"
        Me.dgRango.RowHeadersWidth = 25
        Me.dgRango.RowTemplate.Height = 20
        Me.dgRango.Size = New System.Drawing.Size(470, 163)
        Me.dgRango.TabIndex = 0
        '
        'colIdentificador
        '
        Me.colIdentificador.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colIdentificador.HeaderText = "IDENTIFICADOR"
        Me.colIdentificador.Name = "colIdentificador"
        '
        'colValorMinimo
        '
        '
        '
        '
        Me.colValorMinimo.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.colValorMinimo.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.colValorMinimo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.colValorMinimo.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.colValorMinimo.HeaderText = "MÍNIMO"
        Me.colValorMinimo.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.colValorMinimo.Name = "colValorMinimo"
        Me.colValorMinimo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colValorMinimo.Width = 50
        '
        'colValorMaximo
        '
        '
        '
        '
        Me.colValorMaximo.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.colValorMaximo.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.colValorMaximo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.colValorMaximo.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.colValorMaximo.HeaderText = "MÁXIMO"
        Me.colValorMaximo.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.colValorMaximo.Name = "colValorMaximo"
        Me.colValorMaximo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colValorMaximo.Width = 50
        '
        'pnlNumerico
        '
        Me.pnlNumerico.BackColor = System.Drawing.SystemColors.Window
        Me.pnlNumerico.Controls.Add(Me.intMaximo)
        Me.pnlNumerico.Controls.Add(Me.intMinimo)
        Me.pnlNumerico.Controls.Add(Me.Label7)
        Me.pnlNumerico.Controls.Add(Me.Label8)
        Me.pnlNumerico.Location = New System.Drawing.Point(506, 108)
        Me.pnlNumerico.Name = "pnlNumerico"
        Me.pnlNumerico.Size = New System.Drawing.Size(200, 59)
        Me.pnlNumerico.TabIndex = 4
        Me.pnlNumerico.Visible = False
        '
        'intMaximo
        '
        '
        '
        '
        Me.intMaximo.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.intMaximo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.intMaximo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.intMaximo.Location = New System.Drawing.Point(122, 29)
        Me.intMaximo.Name = "intMaximo"
        Me.intMaximo.ShowUpDown = True
        Me.intMaximo.Size = New System.Drawing.Size(78, 20)
        Me.intMaximo.TabIndex = 126
        '
        'intMinimo
        '
        '
        '
        '
        Me.intMinimo.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.intMinimo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.intMinimo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.intMinimo.Location = New System.Drawing.Point(122, 3)
        Me.intMinimo.Name = "intMinimo"
        Me.intMinimo.ShowUpDown = True
        Me.intMinimo.Size = New System.Drawing.Size(78, 20)
        Me.intMinimo.TabIndex = 125
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Window
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(0, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 15)
        Me.Label7.TabIndex = 124
        Me.Label7.Text = "Valor mínimo"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.SystemColors.Window
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(0, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 15)
        Me.Label8.TabIndex = 122
        Me.Label8.Text = "Valor máximo"
        '
        'cmbEstilo
        '
        Me.cmbEstilo.DisplayMember = "estilo"
        Me.cmbEstilo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbEstilo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstilo.FormattingEnabled = True
        Me.cmbEstilo.ItemHeight = 14
        Me.cmbEstilo.Location = New System.Drawing.Point(152, 82)
        Me.cmbEstilo.Name = "cmbEstilo"
        Me.cmbEstilo.Size = New System.Drawing.Size(154, 20)
        Me.cmbEstilo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbEstilo.TabIndex = 2
        '
        'pnlClasificacion
        '
        Me.pnlClasificacion.BackColor = System.Drawing.SystemColors.Window
        Me.pnlClasificacion.Controls.Add(Me.Label3)
        Me.pnlClasificacion.Controls.Add(Me.stpClasificacion)
        Me.pnlClasificacion.Location = New System.Drawing.Point(33, 323)
        Me.pnlClasificacion.Name = "pnlClasificacion"
        Me.pnlClasificacion.Size = New System.Drawing.Size(673, 56)
        Me.pnlClasificacion.TabIndex = 6
        Me.pnlClasificacion.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 30)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = "Niveles (clic derecho" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "para más opciones)"
        '
        'stpClasificacion
        '
        '
        '
        '
        Me.stpClasificacion.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.stpClasificacion.BackgroundStyle.Class = "ProgressSteps"
        Me.stpClasificacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.stpClasificacion.ContainerControlProcessDialogKey = True
        Me.stpClasificacion.ContextMenuStrip = Me.mnuClasificacion
        Me.stpClasificacion.Dock = System.Windows.Forms.DockStyle.Right
        Me.stpClasificacion.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.StepItem1})
        Me.stpClasificacion.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.stpClasificacion.Location = New System.Drawing.Point(122, 0)
        Me.stpClasificacion.Name = "stpClasificacion"
        Me.stpClasificacion.Size = New System.Drawing.Size(551, 56)
        Me.stpClasificacion.TabIndex = 1
        '
        'mnuClasificacion
        '
        Me.mnuClasificacion.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarNuevaClasificaciónToolStripMenuItem, Me.ModificarTextoToolStripMenuItem, Me.EliminarClasificaciónToolStripMenuItem})
        Me.mnuClasificacion.Name = "mnuClasificacion"
        Me.mnuClasificacion.Size = New System.Drawing.Size(155, 70)
        '
        'AgregarNuevaClasificaciónToolStripMenuItem
        '
        Me.AgregarNuevaClasificaciónToolStripMenuItem.Name = "AgregarNuevaClasificaciónToolStripMenuItem"
        Me.AgregarNuevaClasificaciónToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.AgregarNuevaClasificaciónToolStripMenuItem.Text = "Insertar nivel"
        '
        'ModificarTextoToolStripMenuItem
        '
        Me.ModificarTextoToolStripMenuItem.Name = "ModificarTextoToolStripMenuItem"
        Me.ModificarTextoToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.ModificarTextoToolStripMenuItem.Text = "Modificar texto"
        '
        'EliminarClasificaciónToolStripMenuItem
        '
        Me.EliminarClasificaciónToolStripMenuItem.Name = "EliminarClasificaciónToolStripMenuItem"
        Me.EliminarClasificaciónToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.EliminarClasificaciónToolStripMenuItem.Text = "Eliminar nivel"
        '
        'StepItem1
        '
        Me.StepItem1.Name = "StepItem1"
        Me.StepItem1.Padding.Bottom = 8
        Me.StepItem1.Padding.Left = 4
        Me.StepItem1.Padding.Right = 4
        Me.StepItem1.Padding.Top = 8
        Me.StepItem1.SymbolSize = 13.0!
        Me.StepItem1.Text = "Conoce"
        '
        'pnlLogico
        '
        Me.pnlLogico.BackColor = System.Drawing.SystemColors.Window
        Me.pnlLogico.Controls.Add(Me.txtNoRequerido)
        Me.pnlLogico.Controls.Add(Me.txtFalso)
        Me.pnlLogico.Controls.Add(Me.txtVerdadero)
        Me.pnlLogico.Controls.Add(Me.Label10)
        Me.pnlLogico.Controls.Add(Me.Label5)
        Me.pnlLogico.Controls.Add(Me.Label9)
        Me.pnlLogico.Location = New System.Drawing.Point(506, 171)
        Me.pnlLogico.Name = "pnlLogico"
        Me.pnlLogico.Size = New System.Drawing.Size(200, 89)
        Me.pnlLogico.TabIndex = 5
        Me.pnlLogico.Visible = False
        '
        'txtNoRequerido
        '
        '
        '
        '
        Me.txtNoRequerido.Border.Class = "TextBoxBorder"
        Me.txtNoRequerido.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNoRequerido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoRequerido.Location = New System.Drawing.Point(122, 57)
        Me.txtNoRequerido.MaxLength = 5
        Me.txtNoRequerido.Name = "txtNoRequerido"
        Me.txtNoRequerido.Size = New System.Drawing.Size(75, 21)
        Me.txtNoRequerido.TabIndex = 2
        Me.txtNoRequerido.Text = "N/A"
        '
        'txtFalso
        '
        '
        '
        '
        Me.txtFalso.Border.Class = "TextBoxBorder"
        Me.txtFalso.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFalso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFalso.Location = New System.Drawing.Point(122, 30)
        Me.txtFalso.MaxLength = 5
        Me.txtFalso.Name = "txtFalso"
        Me.txtFalso.Size = New System.Drawing.Size(75, 21)
        Me.txtFalso.TabIndex = 1
        Me.txtFalso.Text = "NO"
        '
        'txtVerdadero
        '
        '
        '
        '
        Me.txtVerdadero.Border.Class = "TextBoxBorder"
        Me.txtVerdadero.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtVerdadero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVerdadero.Location = New System.Drawing.Point(122, 3)
        Me.txtVerdadero.MaxLength = 5
        Me.txtVerdadero.Name = "txtVerdadero"
        Me.txtVerdadero.Size = New System.Drawing.Size(75, 21)
        Me.txtVerdadero.TabIndex = 0
        Me.txtVerdadero.Text = "SI"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Window
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(0, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(108, 15)
        Me.Label10.TabIndex = 109
        Me.Label10.Text = "Valor no requerido"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(0, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 15)
        Me.Label5.TabIndex = 107
        Me.Label5.Text = "Valor falso"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Window
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(0, 3)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 15)
        Me.Label9.TabIndex = 106
        Me.Label9.Text = "Valor verdadero"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(30, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 15)
        Me.Label4.TabIndex = 86
        Me.Label4.Text = "Estilo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 28)
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
        Me.txtCodigo.Location = New System.Drawing.Point(152, 25)
        Me.txtCodigo.MaxLength = 3
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(78, 21)
        Me.txtCodigo.TabIndex = 0
        '
        'txtNombre
        '
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(152, 52)
        Me.txtNombre.MaxLength = 60
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(348, 21)
        Me.txtNombre.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 54
        Me.Label2.Text = "Nombre"
        '
        'pnlOpcionMultiple
        '
        Me.pnlOpcionMultiple.BackColor = System.Drawing.SystemColors.Window
        Me.pnlOpcionMultiple.Controls.Add(Me.chkSeleccionMultiple)
        Me.pnlOpcionMultiple.Controls.Add(Me.chkUnaRespuesta)
        Me.pnlOpcionMultiple.Controls.Add(Me.lblVarias)
        Me.pnlOpcionMultiple.Controls.Add(Me.dgValidas)
        Me.pnlOpcionMultiple.Location = New System.Drawing.Point(30, 108)
        Me.pnlOpcionMultiple.Name = "pnlOpcionMultiple"
        Me.pnlOpcionMultiple.Size = New System.Drawing.Size(470, 163)
        Me.pnlOpcionMultiple.TabIndex = 3
        Me.pnlOpcionMultiple.Visible = False
        '
        'chkSeleccionMultiple
        '
        '
        '
        '
        Me.chkSeleccionMultiple.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkSeleccionMultiple.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkSeleccionMultiple.Location = New System.Drawing.Point(334, 3)
        Me.chkSeleccionMultiple.Name = "chkSeleccionMultiple"
        Me.chkSeleccionMultiple.Size = New System.Drawing.Size(133, 20)
        Me.chkSeleccionMultiple.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkSeleccionMultiple.TabIndex = 91
        Me.chkSeleccionMultiple.Text = "Múltiples respuestas"
        Me.chkSeleccionMultiple.TextColor = System.Drawing.SystemColors.ControlText
        '
        'chkUnaRespuesta
        '
        '
        '
        '
        Me.chkUnaRespuesta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkUnaRespuesta.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkUnaRespuesta.Checked = True
        Me.chkUnaRespuesta.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUnaRespuesta.CheckValue = "Y"
        Me.chkUnaRespuesta.Location = New System.Drawing.Point(122, 3)
        Me.chkUnaRespuesta.Name = "chkUnaRespuesta"
        Me.chkUnaRespuesta.Size = New System.Drawing.Size(180, 20)
        Me.chkUnaRespuesta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkUnaRespuesta.TabIndex = 90
        Me.chkUnaRespuesta.Text = "Solo una respuesta"
        Me.chkUnaRespuesta.TextColor = System.Drawing.SystemColors.ControlText
        '
        'lblVarias
        '
        Me.lblVarias.AutoSize = True
        Me.lblVarias.BackColor = System.Drawing.SystemColors.Window
        Me.lblVarias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVarias.Location = New System.Drawing.Point(0, 0)
        Me.lblVarias.Name = "lblVarias"
        Me.lblVarias.Size = New System.Drawing.Size(50, 15)
        Me.lblVarias.TabIndex = 89
        Me.lblVarias.Text = "Permitir"
        '
        'dgValidas
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgValidas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgValidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgValidas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colRespuestas, Me.colValor})
        Me.dgValidas.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgValidas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgValidas.Location = New System.Drawing.Point(0, 30)
        Me.dgValidas.Name = "dgValidas"
        Me.dgValidas.RowHeadersWidth = 25
        Me.dgValidas.Size = New System.Drawing.Size(470, 133)
        Me.dgValidas.TabIndex = 0
        '
        'colRespuestas
        '
        Me.colRespuestas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colRespuestas.HeaderText = "RESPUESTAS VÁLIDAS"
        Me.colRespuestas.Name = "colRespuestas"
        '
        'colValor
        '
        '
        '
        '
        Me.colValor.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
        Me.colValor.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.colValor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.colValor.BackgroundStyle.TextColor = System.Drawing.SystemColors.ControlText
        Me.colValor.HeaderText = "VALOR"
        Me.colValor.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        Me.colValor.MaxValue = 100
        Me.colValor.MinValue = -1
        Me.colValor.Name = "colValor"
        Me.colValor.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colValor.Width = 70
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DataFieldName = "modalidad"
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
        'ColumnHeader5
        '
        Me.ColumnHeader5.DataFieldName = "objetivo"
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.Text = "Código"
        Me.ColumnHeader5.Width.Absolute = 50
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.DataFieldName = "nombre"
        Me.ColumnHeader6.Name = "ColumnHeader6"
        Me.ColumnHeader6.StretchToFill = True
        Me.ColumnHeader6.Text = "Nombre"
        Me.ColumnHeader6.Width.Absolute = 150
        Me.ColumnHeader6.Width.AutoSize = True
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "cod_area"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Código"
        Me.ColumnHeader1.Width.Absolute = 50
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
        'codClasif
        '
        Me.codClasif.DataFieldName = "cod_clasif"
        Me.codClasif.Name = "codClasif"
        Me.codClasif.Text = "Código"
        Me.codClasif.Width.Absolute = 50
        '
        'Nombre
        '
        Me.Nombre.DataFieldName = "nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.StretchToFill = True
        Me.Nombre.Text = "Descripción"
        Me.Nombre.Width.Absolute = 150
        '
        'dgTabla
        '
        Me.dgTabla.AllowUserToAddRows = False
        Me.dgTabla.AllowUserToDeleteRows = False
        Me.dgTabla.AllowUserToOrderColumns = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTabla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(141, Byte), Integer))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTabla.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgTabla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTabla.EnableHeadersVisualStyles = False
        Me.dgTabla.GridColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.dgTabla.Location = New System.Drawing.Point(0, 0)
        Me.dgTabla.MultiSelect = False
        Me.dgTabla.Name = "dgTabla"
        Me.dgTabla.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTabla.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgTabla.Size = New System.Drawing.Size(752, 405)
        Me.dgTabla.TabIndex = 0
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
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(752, 405)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.tabTabla
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(56, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(313, 40)
        Me.ReflectionLabel1.TabIndex = 82
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>TIPO DE RESPUESTAS</b></font>"
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
        Me.EmpNav.Location = New System.Drawing.Point(13, 473)
        Me.EmpNav.Name = "EmpNav"
        Me.EmpNav.Size = New System.Drawing.Size(825, 47)
        Me.EmpNav.TabIndex = 80
        Me.EmpNav.TabStop = False
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
        Me.tabBuscar.Size = New System.Drawing.Size(825, 405)
        Me.tabBuscar.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.tabBuscar.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.TabIndex = 81
        Me.tabBuscar.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit
        Me.tabBuscar.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabEmpleado, Me.tabTabla})
        Me.tabBuscar.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(722, 13)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(73, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 9
        Me.btnCerrar.Text = "Salir"
        '
        'btnPrimero
        '
        Me.btnPrimero.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrimero.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrimero.Image = Global.PIDA.My.Resources.Resources.First16
        Me.btnPrimero.Location = New System.Drawing.Point(29, 13)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(73, 25)
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
        Me.btnReporte.Location = New System.Drawing.Point(414, 13)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(73, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 5
        Me.btnReporte.Text = "Reporte"
        '
        'btnAnterior
        '
        Me.btnAnterior.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAnterior.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAnterior.Image = Global.PIDA.My.Resources.Resources.Prev16
        Me.btnAnterior.Location = New System.Drawing.Point(106, 13)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(73, 25)
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
        Me.btnBorrar.Location = New System.Drawing.Point(645, 13)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(73, 25)
        Me.btnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBorrar.TabIndex = 8
        Me.btnBorrar.Text = "Borrar"
        '
        'btnSiguiente
        '
        Me.btnSiguiente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSiguiente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSiguiente.Image = Global.PIDA.My.Resources.Resources.Next16
        Me.btnSiguiente.Location = New System.Drawing.Point(183, 13)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(73, 25)
        Me.btnSiguiente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSiguiente.TabIndex = 2
        Me.btnSiguiente.Text = "Siguiente"
        '
        'btnUltimo
        '
        Me.btnUltimo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnUltimo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnUltimo.Image = Global.PIDA.My.Resources.Resources.Last16
        Me.btnUltimo.Location = New System.Drawing.Point(260, 13)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(73, 25)
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
        Me.btnBuscar.Location = New System.Drawing.Point(337, 13)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(73, 25)
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
        Me.btnEditar.Location = New System.Drawing.Point(568, 13)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(73, 25)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 7
        Me.btnEditar.Text = "Editar"
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.NewRecord
        Me.btnNuevo.Location = New System.Drawing.Point(491, 13)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(73, 25)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 6
        Me.btnNuevo.Text = "Agregar"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Preguntas64
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 40)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 83
        Me.PictureBox1.TabStop = False
        '
        'frmRespuestas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 524)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.EmpNav)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.tabBuscar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRespuestas"
        Me.Text = "Respuestas"
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        Me.pnlRango.ResumeLayout(False)
        CType(Me.dgRango, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNumerico.ResumeLayout(False)
        Me.pnlNumerico.PerformLayout()
        CType(Me.intMaximo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.intMinimo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlClasificacion.ResumeLayout(False)
        Me.pnlClasificacion.PerformLayout()
        Me.mnuClasificacion.ResumeLayout(False)
        Me.pnlLogico.ResumeLayout(False)
        Me.pnlLogico.PerformLayout()
        Me.pnlOpcionMultiple.ResumeLayout(False)
        Me.pnlOpcionMultiple.PerformLayout()
        CType(Me.dgValidas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        Me.EmpNav.ResumeLayout(False)
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBuscar.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabEmpleado As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents pnlDatos As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents pnlOpcionMultiple As System.Windows.Forms.Panel
    Friend WithEvents pnlLogico As System.Windows.Forms.Panel
    Friend WithEvents txtNoRequerido As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtFalso As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtVerdadero As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents pnlNumerico As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader6 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents codClasif As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Nombre As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgTabla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents tabTabla As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
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
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents tabBuscar As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents dgValidas As System.Windows.Forms.DataGridView
    Friend WithEvents pnlClasificacion As System.Windows.Forms.Panel
    Friend WithEvents stpClasificacion As DevComponents.DotNetBar.ProgressSteps
    Friend WithEvents StepItem1 As DevComponents.DotNetBar.StepItem
    Friend WithEvents mnuClasificacion As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AgregarNuevaClasificaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarTextoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarClasificaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbEstilo As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents colRespuestas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colValor As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents pnlRango As System.Windows.Forms.Panel
    Friend WithEvents dgRango As System.Windows.Forms.DataGridView
    Friend WithEvents colIdentificador As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colValorMinimo As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents colValorMaximo As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents lblVarias As System.Windows.Forms.Label
    Friend WithEvents chkSeleccionMultiple As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkUnaRespuesta As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents intMaximo As DevComponents.Editors.IntegerInput
    Friend WithEvents intMinimo As DevComponents.Editors.IntegerInput

End Class
