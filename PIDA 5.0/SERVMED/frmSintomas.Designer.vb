<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSintomas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSintomas))
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
        Me.tabBuscar = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.AdvTree1 = New DevComponents.AdvTree.AdvTree()
        Me.Node1 = New DevComponents.AdvTree.Node()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.tabTabla = New DevComponents.DotNetBar.SuperTabItem()
        Me.pnlDatos = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.txtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cmbCodigo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tabEmpleado = New DevComponents.DotNetBar.SuperTabItem()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AgregarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmpNav.SuspendLayout()
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBuscar.SuspendLayout()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.AdvTree1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatos.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
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
        Me.EmpNav.Location = New System.Drawing.Point(12, 247)
        Me.EmpNav.Name = "EmpNav"
        Me.EmpNav.Size = New System.Drawing.Size(825, 47)
        Me.EmpNav.TabIndex = 105
        Me.EmpNav.TabStop = False
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
        Me.btnCerrar.TabIndex = 58
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
        Me.btnPrimero.TabIndex = 23
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
        Me.btnReporte.TabIndex = 57
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
        Me.btnAnterior.TabIndex = 24
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
        Me.btnBorrar.TabIndex = 56
        Me.btnBorrar.Text = "Borrar"
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
        Me.btnSiguiente.TabIndex = 25
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
        Me.btnUltimo.TabIndex = 26
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
        Me.btnEditar.Image = Global.PIDA.My.Resources.Resources.Edit
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
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.NewRecord
        Me.btnNuevo.Location = New System.Drawing.Point(493, 13)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 25)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 52
        Me.btnNuevo.Text = "Agregar"
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
        Me.tabBuscar.Controls.Add(Me.SuperTabControlPanel2)
        Me.tabBuscar.Controls.Add(Me.pnlDatos)
        Me.tabBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.Location = New System.Drawing.Point(12, 62)
        Me.tabBuscar.Name = "tabBuscar"
        Me.tabBuscar.ReorderTabsEnabled = True
        Me.tabBuscar.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabBuscar.SelectedTabIndex = 0
        Me.tabBuscar.Size = New System.Drawing.Size(825, 182)
        Me.tabBuscar.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.tabBuscar.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.TabIndex = 104
        Me.tabBuscar.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit
        Me.tabBuscar.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabEmpleado, Me.tabTabla})
        Me.tabBuscar.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.AdvTree1)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(752, 182)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.tabTabla
        '
        'AdvTree1
        '
        Me.AdvTree1.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.AdvTree1.AllowDrop = True
        Me.AdvTree1.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.AdvTree1.BackgroundStyle.Class = "TreeBorderKey"
        Me.AdvTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.AdvTree1.CellEdit = True
        Me.AdvTree1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdvTree1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.AdvTree1.Location = New System.Drawing.Point(0, 0)
        Me.AdvTree1.Name = "AdvTree1"
        Me.AdvTree1.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node1})
        Me.AdvTree1.NodesConnector = Me.NodeConnector1
        Me.AdvTree1.NodeStyle = Me.ElementStyle1
        Me.AdvTree1.PathSeparator = ";"
        Me.AdvTree1.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect
        Me.AdvTree1.Size = New System.Drawing.Size(752, 182)
        Me.AdvTree1.Styles.Add(Me.ElementStyle1)
        Me.AdvTree1.TabIndex = 0
        Me.AdvTree1.Text = "AdvTree1"
        '
        'Node1
        '
        Me.Node1.Expanded = True
        Me.Node1.Name = "Node1"
        Me.Node1.Text = "Node1"
        '
        'NodeConnector1
        '
        Me.NodeConnector1.LineColor = System.Drawing.SystemColors.ControlText
        '
        'ElementStyle1
        '
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.TextColor = System.Drawing.SystemColors.ControlText
        '
        'tabTabla
        '
        Me.tabTabla.AttachedControl = Me.SuperTabControlPanel2
        Me.tabTabla.GlobalItem = False
        Me.tabTabla.Name = "tabTabla"
        Me.tabTabla.Text = "Lista"
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.txtCodigo)
        Me.pnlDatos.Controls.Add(Me.Label3)
        Me.pnlDatos.Controls.Add(Me.txtNombre)
        Me.pnlDatos.Controls.Add(Me.cmbCodigo)
        Me.pnlDatos.Controls.Add(Me.Label1)
        Me.pnlDatos.Controls.Add(Me.Label2)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(754, 182)
        Me.pnlDatos.TabIndex = 63
        Me.pnlDatos.TabItem = Me.tabEmpleado
        '
        'txtCodigo
        '
        '
        '
        '
        Me.txtCodigo.Border.Class = "TextBoxBorder"
        Me.txtCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodigo.Enabled = False
        Me.txtCodigo.Location = New System.Drawing.Point(126, 82)
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.PreventEnterBeep = True
        Me.txtCodigo.Size = New System.Drawing.Size(128, 20)
        Me.txtCodigo.TabIndex = 89
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 15)
        Me.Label3.TabIndex = 88
        Me.Label3.Text = "Código"
        '
        'txtNombre
        '
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.Location = New System.Drawing.Point(126, 108)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.PreventEnterBeep = True
        Me.txtNombre.Size = New System.Drawing.Size(283, 20)
        Me.txtNombre.TabIndex = 87
        '
        'cmbCodigo
        '
        Me.cmbCodigo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbCodigo.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbCodigo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbCodigo.ButtonDropDown.Visible = True
        Me.cmbCodigo.DisplayMembers = "cod_grupo,nombre"
        Me.cmbCodigo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbCodigo.Location = New System.Drawing.Point(126, 54)
        Me.cmbCodigo.Name = "cmbCodigo"
        Me.cmbCodigo.Size = New System.Drawing.Size(283, 20)
        Me.cmbCodigo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbCodigo.TabIndex = 84
        Me.cmbCodigo.ValueMember = "cod_grupo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Grupo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 108)
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
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(45, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(132, 40)
        Me.ReflectionLabel1.TabIndex = 106
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>SINTOMAS</b></font>"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Grupos32
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(24, 24)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 107
        Me.PictureBox1.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AgregarToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(117, 26)
        '
        'AgregarToolStripMenuItem
        '
        Me.AgregarToolStripMenuItem.Image = Global.PIDA.My.Resources.Resources.Add
        Me.AgregarToolStripMenuItem.Name = "AgregarToolStripMenuItem"
        Me.AgregarToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.AgregarToolStripMenuItem.Text = "Agregar"
        '
        'frmSintomas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(850, 304)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.EmpNav)
        Me.Controls.Add(Me.tabBuscar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSintomas"
        Me.Text = "Síntomas"
        Me.EmpNav.ResumeLayout(False)
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBuscar.ResumeLayout(False)
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.AdvTree1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
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
    Friend WithEvents tabBuscar As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents pnlDatos As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tabEmpleado As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabTabla As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbCodigo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents AdvTree1 As DevComponents.AdvTree.AdvTree
    Friend WithEvents Node1 As DevComponents.AdvTree.Node
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents txtCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AgregarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
