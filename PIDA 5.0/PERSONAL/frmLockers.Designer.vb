<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLockers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLockers))
        Me.dgLockers = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.c_locker = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_estatus = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_boton = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn()
        Me.c_reloj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_detalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.EmpNav = New System.Windows.Forms.GroupBox()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.txtBusqueda = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbGrupos = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.c_codigo = New DevComponents.AdvTree.ColumnHeader()
        Me.c_nombre = New DevComponents.AdvTree.ColumnHeader()
        Me.cmbStatus = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.DataGridViewButtonXColumn1 = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.btnVerBuscar = New DevComponents.DotNetBar.ButtonX()
        CType(Me.dgLockers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EmpNav.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgLockers
        '
        Me.dgLockers.AllowUserToAddRows = False
        Me.dgLockers.AllowUserToDeleteRows = False
        Me.dgLockers.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLockers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgLockers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgLockers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.c_locker, Me.c_estatus, Me.Column2, Me.c_status, Me.c_boton, Me.c_reloj, Me.c_detalle})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgLockers.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgLockers.EnableHeadersVisualStyles = False
        Me.dgLockers.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgLockers.Location = New System.Drawing.Point(12, 129)
        Me.dgLockers.Name = "dgLockers"
        Me.dgLockers.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgLockers.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgLockers.RowHeadersWidth = 10
        Me.dgLockers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgLockers.Size = New System.Drawing.Size(769, 351)
        Me.dgLockers.TabIndex = 0
        '
        'c_locker
        '
        Me.c_locker.DataPropertyName = "locker"
        Me.c_locker.HeaderText = "No. Locker"
        Me.c_locker.Name = "c_locker"
        Me.c_locker.ReadOnly = True
        Me.c_locker.Width = 45
        '
        'c_estatus
        '
        Me.c_estatus.HeaderText = "Estatus"
        Me.c_estatus.Name = "c_estatus"
        Me.c_estatus.ReadOnly = True
        Me.c_estatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.c_estatus.Width = 50
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "candado"
        Me.Column2.HeaderText = "Candado"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'c_status
        '
        Me.c_status.DataPropertyName = "status"
        Me.c_status.HeaderText = "status"
        Me.c_status.Name = "c_status"
        Me.c_status.ReadOnly = True
        Me.c_status.Visible = False
        Me.c_status.Width = 50
        '
        'c_boton
        '
        Me.c_boton.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.c_boton.HeaderText = "Contraseña / Llave"
        Me.c_boton.Image = CType(resources.GetObject("c_boton.Image"), System.Drawing.Image)
        Me.c_boton.Name = "c_boton"
        Me.c_boton.ReadOnly = True
        Me.c_boton.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.c_boton.Text = Nothing
        Me.c_boton.Width = 70
        '
        'c_reloj
        '
        Me.c_reloj.DataPropertyName = "reloj"
        Me.c_reloj.HeaderText = "Reloj"
        Me.c_reloj.Name = "c_reloj"
        Me.c_reloj.ReadOnly = True
        Me.c_reloj.Width = 60
        '
        'c_detalle
        '
        Me.c_detalle.DataPropertyName = "detalle"
        Me.c_detalle.HeaderText = "Detalle"
        Me.c_detalle.Name = "c_detalle"
        Me.c_detalle.ReadOnly = True
        Me.c_detalle.Width = 450
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(70, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(291, 40)
        Me.ReflectionLabel1.TabIndex = 95
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CONTROL DE LOCKERS</b></font>"
        '
        'EmpNav
        '
        Me.EmpNav.Controls.Add(Me.btnCerrar)
        Me.EmpNav.Controls.Add(Me.btnReporte)
        Me.EmpNav.Location = New System.Drawing.Point(604, 486)
        Me.EmpNav.Name = "EmpNav"
        Me.EmpNav.Size = New System.Drawing.Size(180, 47)
        Me.EmpNav.TabIndex = 101
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
        Me.btnCerrar.Location = New System.Drawing.Point(90, 14)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 58
        Me.btnCerrar.Text = "Salir"
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnReporte.Location = New System.Drawing.Point(6, 14)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 57
        Me.btnReporte.Text = "Reporte"
        '
        'txtBusqueda
        '
        '
        '
        '
        Me.txtBusqueda.Border.Class = "TextBoxBorder"
        Me.txtBusqueda.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBusqueda.Location = New System.Drawing.Point(70, 103)
        Me.txtBusqueda.Name = "txtBusqueda"
        Me.txtBusqueda.PreventEnterBeep = True
        Me.txtBusqueda.Size = New System.Drawing.Size(680, 20)
        Me.txtBusqueda.TabIndex = 102
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.BackColor = System.Drawing.SystemColors.Control
        Me.Label61.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label61.Location = New System.Drawing.Point(19, 103)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(45, 15)
        Me.Label61.TabIndex = 103
        Me.Label61.Text = "Buscar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Grupo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(593, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 15)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "Status"
        '
        'cmbGrupos
        '
        Me.cmbGrupos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbGrupos.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbGrupos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbGrupos.ButtonDropDown.Visible = True
        Me.cmbGrupos.Columns.Add(Me.c_codigo)
        Me.cmbGrupos.Columns.Add(Me.c_nombre)
        Me.cmbGrupos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbGrupos.Location = New System.Drawing.Point(70, 77)
        Me.cmbGrupos.Name = "cmbGrupos"
        Me.cmbGrupos.Size = New System.Drawing.Size(166, 20)
        Me.cmbGrupos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbGrupos.TabIndex = 106
        Me.cmbGrupos.ValueMember = "cod_grupo"
        '
        'c_codigo
        '
        Me.c_codigo.ColumnName = "c_codigo"
        Me.c_codigo.DataFieldName = "cod_grupo"
        Me.c_codigo.Name = "c_codigo"
        Me.c_codigo.Text = "Código"
        Me.c_codigo.Width.Absolute = 40
        '
        'c_nombre
        '
        Me.c_nombre.ColumnName = "c_nombre"
        Me.c_nombre.DataFieldName = "nombre"
        Me.c_nombre.Name = "c_nombre"
        Me.c_nombre.Text = "Nombre"
        Me.c_nombre.Width.Absolute = 100
        '
        'cmbStatus
        '
        Me.cmbStatus.DisplayMember = "Text"
        Me.cmbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.ItemHeight = 14
        Me.cmbStatus.Location = New System.Drawing.Point(640, 77)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(141, 20)
        Me.cmbStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbStatus.TabIndex = 107
        '
        'DataGridViewButtonXColumn1
        '
        Me.DataGridViewButtonXColumn1.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground
        Me.DataGridViewButtonXColumn1.HeaderText = "..."
        Me.DataGridViewButtonXColumn1.Image = CType(resources.GetObject("DataGridViewButtonXColumn1.Image"), System.Drawing.Image)
        Me.DataGridViewButtonXColumn1.Name = "DataGridViewButtonXColumn1"
        Me.DataGridViewButtonXColumn1.ReadOnly = True
        Me.DataGridViewButtonXColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewButtonXColumn1.Text = Nothing
        Me.DataGridViewButtonXColumn1.Width = 30
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.locker2
        Me.picImagen.Location = New System.Drawing.Point(23, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(41, 40)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picImagen.TabIndex = 97
        Me.picImagen.TabStop = False
        '
        'btnVerBuscar
        '
        Me.btnVerBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnVerBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnVerBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnVerBuscar.Image = Global.PIDA.My.Resources.Resources.brush
        Me.btnVerBuscar.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnVerBuscar.Location = New System.Drawing.Point(753, 103)
        Me.btnVerBuscar.Name = "btnVerBuscar"
        Me.btnVerBuscar.Size = New System.Drawing.Size(28, 20)
        Me.btnVerBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnVerBuscar.TabIndex = 155
        '
        'frmLockers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(795, 535)
        Me.Controls.Add(Me.btnVerBuscar)
        Me.Controls.Add(Me.cmbStatus)
        Me.Controls.Add(Me.cmbGrupos)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label61)
        Me.Controls.Add(Me.txtBusqueda)
        Me.Controls.Add(Me.EmpNav)
        Me.Controls.Add(Me.picImagen)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.dgLockers)
        Me.Name = "frmLockers"
        Me.Text = "Status"
        CType(Me.dgLockers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EmpNav.ResumeLayout(False)
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgLockers As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents EmpNav As System.Windows.Forms.GroupBox
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtBusqueda As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbGrupos As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents c_codigo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents c_nombre As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents cmbStatus As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents DataGridViewButtonXColumn1 As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents c_locker As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_estatus As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_boton As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents c_reloj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_detalle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnVerBuscar As DevComponents.DotNetBar.ButtonX
End Class
