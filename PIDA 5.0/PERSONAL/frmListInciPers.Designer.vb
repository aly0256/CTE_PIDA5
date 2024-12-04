<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListInciPers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListInciPers))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblAplic = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dgvPendInci = New System.Windows.Forms.DataGridView()
        Me.col_usuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_reloj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_depto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_tipo_mov = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_dias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_fini = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_ffin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_motivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabInciPend = New DevComponents.DotNetBar.SuperTabItem()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.dgvIncTodas = New System.Windows.Forms.DataGridView()
        Me.col_usuario_t = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_reloj_t = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_nombre_t = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_depto_t = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_tipo_mov_t = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_dias_t = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_fini_t = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_ffin_t = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.col_motivo_t = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabTodasInci = New DevComponents.DotNetBar.SuperTabItem()
        Me.Panel1.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvPendInci, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.dgvIncTodas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.lblAplic)
        Me.Panel1.Controls.Add(Me.picImagen)
        Me.Panel1.Controls.Add(Me.ReflectionLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1277, 77)
        Me.Panel1.TabIndex = 0
        '
        'lblAplic
        '
        '
        '
        '
        Me.lblAplic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblAplic.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAplic.Location = New System.Drawing.Point(66, 19)
        Me.lblAplic.Name = "lblAplic"
        Me.lblAplic.Size = New System.Drawing.Size(336, 40)
        Me.lblAplic.TabIndex = 115
        Me.lblAplic.Text = "<font color=""#1F497D""><b>INCIDENCIAS APLICADAS</b></font>"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.checklist
        Me.picImagen.Location = New System.Drawing.Point(13, 9)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(46, 50)
        Me.picImagen.TabIndex = 114
        Me.picImagen.TabStop = False
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(66, 18)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(336, 40)
        Me.ReflectionLabel1.TabIndex = 113
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>INCIDENCIAS PENDIENTES</b></font>"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel2.Controls.Add(Me.btnCerrar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 519)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1277, 62)
        Me.Panel2.TabIndex = 1
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
        Me.btnCerrar.Location = New System.Drawing.Point(444, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(110, 43)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 60
        Me.btnCerrar.Text = "Salir"
        '
        'SuperTabControl1
        '
        Me.SuperTabControl1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl1.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl1.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl1.ControlBox.Name = ""
        Me.SuperTabControl1.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl1.ControlBox.MenuBox, Me.SuperTabControl1.ControlBox.CloseBox})
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel2)
        Me.SuperTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControl1.Location = New System.Drawing.Point(0, 77)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(1277, 442)
        Me.SuperTabControl1.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 2
        Me.SuperTabControl1.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabInciPend, Me.tabTodasInci})
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.Controls.Add(Me.Panel3)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(1199, 442)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.tabInciPend
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.dgvPendInci)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1199, 442)
        Me.Panel3.TabIndex = 0
        '
        'dgvPendInci
        '
        Me.dgvPendInci.AllowUserToAddRows = False
        Me.dgvPendInci.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPendInci.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPendInci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPendInci.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_usuario, Me.col_reloj, Me.col_nombre, Me.col_depto, Me.col_tipo_mov, Me.col_dias, Me.col_fini, Me.col_ffin, Me.col_motivo})
        Me.dgvPendInci.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPendInci.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvPendInci.Location = New System.Drawing.Point(0, 0)
        Me.dgvPendInci.MultiSelect = False
        Me.dgvPendInci.Name = "dgvPendInci"
        Me.dgvPendInci.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPendInci.Size = New System.Drawing.Size(1199, 442)
        Me.dgvPendInci.TabIndex = 118
        '
        'col_usuario
        '
        Me.col_usuario.DataPropertyName = "usuario"
        Me.col_usuario.HeaderText = "USUARIO"
        Me.col_usuario.Name = "col_usuario"
        '
        'col_reloj
        '
        Me.col_reloj.DataPropertyName = "RELOJ"
        Me.col_reloj.HeaderText = "RELOJ"
        Me.col_reloj.Name = "col_reloj"
        Me.col_reloj.Width = 50
        '
        'col_nombre
        '
        Me.col_nombre.DataPropertyName = "nombre"
        Me.col_nombre.HeaderText = "NOMBRE"
        Me.col_nombre.Name = "col_nombre"
        Me.col_nombre.Width = 200
        '
        'col_depto
        '
        Me.col_depto.DataPropertyName = "depto"
        Me.col_depto.HeaderText = "DEPARTAMENTO"
        Me.col_depto.Name = "col_depto"
        Me.col_depto.Width = 200
        '
        'col_tipo_mov
        '
        Me.col_tipo_mov.DataPropertyName = "tipo_movimiento"
        Me.col_tipo_mov.HeaderText = "MOVIMIENTO"
        Me.col_tipo_mov.Name = "col_tipo_mov"
        Me.col_tipo_mov.Width = 150
        '
        'col_dias
        '
        Me.col_dias.DataPropertyName = "dias"
        Me.col_dias.HeaderText = "DIAS"
        Me.col_dias.Name = "col_dias"
        Me.col_dias.Width = 50
        '
        'col_fini
        '
        Me.col_fini.DataPropertyName = "f_ini"
        Me.col_fini.HeaderText = "FECHA SALIDA"
        Me.col_fini.Name = "col_fini"
        '
        'col_ffin
        '
        Me.col_ffin.DataPropertyName = "f_fin"
        Me.col_ffin.HeaderText = "FECHA REGRESO"
        Me.col_ffin.Name = "col_ffin"
        '
        'col_motivo
        '
        Me.col_motivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col_motivo.DataPropertyName = "motivo"
        Me.col_motivo.HeaderText = "MOTIVO"
        Me.col_motivo.Name = "col_motivo"
        '
        'tabInciPend
        '
        Me.tabInciPend.AttachedControl = Me.SuperTabControlPanel1
        Me.tabInciPend.GlobalItem = False
        Me.tabInciPend.Name = "tabInciPend"
        Me.tabInciPend.Text = "Pendientes"
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.Panel4)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(1201, 442)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.tabTodasInci
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.dgvIncTodas)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1201, 442)
        Me.Panel4.TabIndex = 0
        '
        'dgvIncTodas
        '
        Me.dgvIncTodas.AllowUserToAddRows = False
        Me.dgvIncTodas.AllowUserToOrderColumns = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIncTodas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvIncTodas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIncTodas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.col_usuario_t, Me.col_reloj_t, Me.col_nombre_t, Me.col_depto_t, Me.col_tipo_mov_t, Me.col_dias_t, Me.col_fini_t, Me.col_ffin_t, Me.col_motivo_t})
        Me.dgvIncTodas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIncTodas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvIncTodas.Location = New System.Drawing.Point(0, 0)
        Me.dgvIncTodas.MultiSelect = False
        Me.dgvIncTodas.Name = "dgvIncTodas"
        Me.dgvIncTodas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvIncTodas.Size = New System.Drawing.Size(1201, 442)
        Me.dgvIncTodas.TabIndex = 119
        '
        'col_usuario_t
        '
        Me.col_usuario_t.DataPropertyName = "usuario"
        Me.col_usuario_t.HeaderText = "USUARIO"
        Me.col_usuario_t.Name = "col_usuario_t"
        '
        'col_reloj_t
        '
        Me.col_reloj_t.DataPropertyName = "RELOJ"
        Me.col_reloj_t.HeaderText = "RELOJ"
        Me.col_reloj_t.Name = "col_reloj_t"
        Me.col_reloj_t.Width = 50
        '
        'col_nombre_t
        '
        Me.col_nombre_t.DataPropertyName = "nombre"
        Me.col_nombre_t.HeaderText = "NOMBRE"
        Me.col_nombre_t.Name = "col_nombre_t"
        Me.col_nombre_t.Width = 200
        '
        'col_depto_t
        '
        Me.col_depto_t.DataPropertyName = "depto"
        Me.col_depto_t.HeaderText = "DEPARTAMENTO"
        Me.col_depto_t.Name = "col_depto_t"
        Me.col_depto_t.Width = 200
        '
        'col_tipo_mov_t
        '
        Me.col_tipo_mov_t.DataPropertyName = "tipo_movimiento"
        Me.col_tipo_mov_t.HeaderText = "MOVIMIENTO"
        Me.col_tipo_mov_t.Name = "col_tipo_mov_t"
        Me.col_tipo_mov_t.Width = 150
        '
        'col_dias_t
        '
        Me.col_dias_t.DataPropertyName = "dias"
        Me.col_dias_t.HeaderText = "DIAS"
        Me.col_dias_t.Name = "col_dias_t"
        Me.col_dias_t.Width = 50
        '
        'col_fini_t
        '
        Me.col_fini_t.DataPropertyName = "f_ini"
        Me.col_fini_t.HeaderText = "FECHA SALIDA"
        Me.col_fini_t.Name = "col_fini_t"
        '
        'col_ffin_t
        '
        Me.col_ffin_t.DataPropertyName = "f_fin"
        Me.col_ffin_t.HeaderText = "FECHA REGRESO"
        Me.col_ffin_t.Name = "col_ffin_t"
        '
        'col_motivo_t
        '
        Me.col_motivo_t.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.col_motivo_t.DataPropertyName = "motivo"
        Me.col_motivo_t.HeaderText = "MOTIVO"
        Me.col_motivo_t.Name = "col_motivo_t"
        '
        'tabTodasInci
        '
        Me.tabTodasInci.AttachedControl = Me.SuperTabControlPanel2
        Me.tabTodasInci.GlobalItem = False
        Me.tabTodasInci.Name = "tabTodasInci"
        Me.tabTodasInci.Text = "Aplicadas"
        '
        'frmListInciPers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1277, 581)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmListInciPers"
        Me.Text = "Incidencias capturadas del personal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.dgvPendInci, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.dgvIncTodas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents tabInciPend As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents tabTodasInci As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents dgvPendInci As System.Windows.Forms.DataGridView
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents col_usuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_reloj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_depto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_tipo_mov As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_dias As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_fini As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_ffin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_motivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvIncTodas As System.Windows.Forms.DataGridView
    Friend WithEvents col_usuario_t As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_reloj_t As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_nombre_t As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_depto_t As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_tipo_mov_t As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_dias_t As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_fini_t As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_ffin_t As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents col_motivo_t As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblAplic As DevComponents.DotNetBar.Controls.ReflectionLabel
End Class
