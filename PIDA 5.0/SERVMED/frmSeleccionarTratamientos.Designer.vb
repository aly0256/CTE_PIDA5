<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeleccionarTratamientos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeleccionarTratamientos))
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAgregar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtReloj = New System.Windows.Forms.TextBox()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.dgvTratamientos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ColumnCodTratamiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnTratamiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnPosologiaT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnDiasTratamientoT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LabelVista = New System.Windows.Forms.Label()
        Me.dgvBusquedaTratamientos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ColumnCodBusqueda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnNombreBusqueda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnServicioTratamiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnPosologia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnRecurso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnTipoTratamiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnDiasTratamiento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtTipo = New System.Windows.Forms.TextBox()
        Me.txtServicio = New System.Windows.Forms.TextBox()
        Me.txtPosologia = New System.Windows.Forms.TextBox()
        Me.txtRecurso = New System.Windows.Forms.TextBox()
        Me.txtDiasTratamiento = New System.Windows.Forms.NumericUpDown()
        Me.LabelDiasTra = New System.Windows.Forms.Label()
        CType(Me.dgvTratamientos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBusquedaTratamientos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiasTratamiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Image = Global.PIDA.My.Resources.Resources.Delete
        Me.btnBorrar.Location = New System.Drawing.Point(93, 244)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(75, 23)
        Me.btnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBorrar.TabIndex = 14
        Me.btnBorrar.Text = "Borrar"
        '
        'btnAgregar
        '
        Me.btnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAgregar.Image = Global.PIDA.My.Resources.Resources.Add
        Me.btnAgregar.Location = New System.Drawing.Point(12, 244)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAgregar.TabIndex = 13
        Me.btnAgregar.Text = "Agregar"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.Location = New System.Drawing.Point(497, 244)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 12
        Me.btnAceptar.Text = "Aceptar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Nombre"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(460, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Reloj"
        '
        'txtReloj
        '
        Me.txtReloj.Enabled = False
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.Location = New System.Drawing.Point(497, 6)
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.Size = New System.Drawing.Size(75, 20)
        Me.txtReloj.TabIndex = 16
        '
        'txtNombres
        '
        Me.txtNombres.Enabled = False
        Me.txtNombres.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombres.Location = New System.Drawing.Point(62, 6)
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(348, 20)
        Me.txtNombres.TabIndex = 15
        '
        'dgvTratamientos
        '
        Me.dgvTratamientos.AllowUserToAddRows = False
        Me.dgvTratamientos.AllowUserToDeleteRows = False
        Me.dgvTratamientos.AllowUserToResizeColumns = False
        Me.dgvTratamientos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTratamientos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTratamientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTratamientos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnCodTratamiento, Me.ColumnTratamiento, Me.ColumnPosologiaT, Me.ColumnDiasTratamientoT})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTratamientos.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvTratamientos.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvTratamientos.Location = New System.Drawing.Point(12, 50)
        Me.dgvTratamientos.MultiSelect = False
        Me.dgvTratamientos.Name = "dgvTratamientos"
        Me.dgvTratamientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTratamientos.Size = New System.Drawing.Size(560, 188)
        Me.dgvTratamientos.TabIndex = 19
        '
        'ColumnCodTratamiento
        '
        Me.ColumnCodTratamiento.DataPropertyName = "id_recurso"
        Me.ColumnCodTratamiento.HeaderText = "ColumnCodSintoma"
        Me.ColumnCodTratamiento.Name = "ColumnCodTratamiento"
        Me.ColumnCodTratamiento.Visible = False
        '
        'ColumnTratamiento
        '
        Me.ColumnTratamiento.DataPropertyName = "descripcion"
        Me.ColumnTratamiento.HeaderText = "Tratamiento"
        Me.ColumnTratamiento.Name = "ColumnTratamiento"
        Me.ColumnTratamiento.ReadOnly = True
        Me.ColumnTratamiento.Width = 300
        '
        'ColumnPosologiaT
        '
        Me.ColumnPosologiaT.DataPropertyName = "posologia"
        Me.ColumnPosologiaT.FillWeight = 150.0!
        Me.ColumnPosologiaT.HeaderText = "Posología"
        Me.ColumnPosologiaT.Name = "ColumnPosologiaT"
        Me.ColumnPosologiaT.ReadOnly = True
        Me.ColumnPosologiaT.Width = 150
        '
        'ColumnDiasTratamientoT
        '
        Me.ColumnDiasTratamientoT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColumnDiasTratamientoT.DataPropertyName = "dias_tratamiento"
        Me.ColumnDiasTratamientoT.FillWeight = 50.0!
        Me.ColumnDiasTratamientoT.HeaderText = "Días"
        Me.ColumnDiasTratamientoT.Name = "ColumnDiasTratamientoT"
        Me.ColumnDiasTratamientoT.ReadOnly = True
        '
        'LabelVista
        '
        Me.LabelVista.AutoSize = True
        Me.LabelVista.Location = New System.Drawing.Point(12, 34)
        Me.LabelVista.Name = "LabelVista"
        Me.LabelVista.Size = New System.Drawing.Size(68, 13)
        Me.LabelVista.TabIndex = 20
        Me.LabelVista.Text = "Tratamientos"
        '
        'dgvBusquedaTratamientos
        '
        Me.dgvBusquedaTratamientos.AllowUserToAddRows = False
        Me.dgvBusquedaTratamientos.AllowUserToDeleteRows = False
        Me.dgvBusquedaTratamientos.AllowUserToResizeColumns = False
        Me.dgvBusquedaTratamientos.AllowUserToResizeRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBusquedaTratamientos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvBusquedaTratamientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBusquedaTratamientos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnCodBusqueda, Me.ColumnNombreBusqueda, Me.ColumnServicioTratamiento, Me.ColumnPosologia, Me.ColumnRecurso, Me.ColumnTipoTratamiento, Me.ColumnDiasTratamiento})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBusquedaTratamientos.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvBusquedaTratamientos.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvBusquedaTratamientos.Location = New System.Drawing.Point(12, 82)
        Me.dgvBusquedaTratamientos.MultiSelect = False
        Me.dgvBusquedaTratamientos.Name = "dgvBusquedaTratamientos"
        Me.dgvBusquedaTratamientos.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvBusquedaTratamientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBusquedaTratamientos.Size = New System.Drawing.Size(398, 156)
        Me.dgvBusquedaTratamientos.TabIndex = 23
        '
        'ColumnCodBusqueda
        '
        Me.ColumnCodBusqueda.DataPropertyName = "id_recurso"
        Me.ColumnCodBusqueda.HeaderText = "id_tratamiento"
        Me.ColumnCodBusqueda.Name = "ColumnCodBusqueda"
        Me.ColumnCodBusqueda.ReadOnly = True
        Me.ColumnCodBusqueda.Visible = False
        '
        'ColumnNombreBusqueda
        '
        Me.ColumnNombreBusqueda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColumnNombreBusqueda.DataPropertyName = "descripcion"
        Me.ColumnNombreBusqueda.HeaderText = "Tratamiento"
        Me.ColumnNombreBusqueda.Name = "ColumnNombreBusqueda"
        Me.ColumnNombreBusqueda.ReadOnly = True
        '
        'ColumnServicioTratamiento
        '
        Me.ColumnServicioTratamiento.DataPropertyName = "servicio"
        Me.ColumnServicioTratamiento.HeaderText = "servicio"
        Me.ColumnServicioTratamiento.Name = "ColumnServicioTratamiento"
        Me.ColumnServicioTratamiento.ReadOnly = True
        Me.ColumnServicioTratamiento.Visible = False
        '
        'ColumnPosologia
        '
        Me.ColumnPosologia.DataPropertyName = "posologia"
        Me.ColumnPosologia.HeaderText = "posologia"
        Me.ColumnPosologia.Name = "ColumnPosologia"
        Me.ColumnPosologia.Visible = False
        '
        'ColumnRecurso
        '
        Me.ColumnRecurso.DataPropertyName = "recurso"
        Me.ColumnRecurso.HeaderText = "recurso"
        Me.ColumnRecurso.Name = "ColumnRecurso"
        Me.ColumnRecurso.ReadOnly = True
        Me.ColumnRecurso.Visible = False
        '
        'ColumnTipoTratamiento
        '
        Me.ColumnTipoTratamiento.DataPropertyName = "tipo"
        Me.ColumnTipoTratamiento.HeaderText = "tipo"
        Me.ColumnTipoTratamiento.Name = "ColumnTipoTratamiento"
        Me.ColumnTipoTratamiento.ReadOnly = True
        Me.ColumnTipoTratamiento.Visible = False
        '
        'ColumnDiasTratamiento
        '
        Me.ColumnDiasTratamiento.DataPropertyName = "dias"
        Me.ColumnDiasTratamiento.HeaderText = "dias"
        Me.ColumnDiasTratamiento.Name = "ColumnDiasTratamiento"
        Me.ColumnDiasTratamiento.ReadOnly = True
        Me.ColumnDiasTratamiento.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(12, 50)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(560, 26)
        Me.TextBox1.TabIndex = 22
        '
        'txtTipo
        '
        Me.txtTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipo.Location = New System.Drawing.Point(416, 108)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.ReadOnly = True
        Me.txtTipo.Size = New System.Drawing.Size(156, 20)
        Me.txtTipo.TabIndex = 24
        Me.txtTipo.TabStop = False
        Me.txtTipo.Text = "ANTIINFLAMATORIO"
        Me.txtTipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtServicio
        '
        Me.txtServicio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServicio.Location = New System.Drawing.Point(416, 134)
        Me.txtServicio.Name = "txtServicio"
        Me.txtServicio.ReadOnly = True
        Me.txtServicio.Size = New System.Drawing.Size(156, 20)
        Me.txtServicio.TabIndex = 25
        Me.txtServicio.TabStop = False
        Me.txtServicio.Text = "1ER NIVEL"
        Me.txtServicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtPosologia
        '
        Me.txtPosologia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPosologia.Location = New System.Drawing.Point(416, 160)
        Me.txtPosologia.Name = "txtPosologia"
        Me.txtPosologia.ReadOnly = True
        Me.txtPosologia.Size = New System.Drawing.Size(156, 20)
        Me.txtPosologia.TabIndex = 26
        Me.txtPosologia.TabStop = False
        Me.txtPosologia.Text = "1 dosis cada 8 hrs"
        Me.txtPosologia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtRecurso
        '
        Me.txtRecurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecurso.Location = New System.Drawing.Point(416, 82)
        Me.txtRecurso.Name = "txtRecurso"
        Me.txtRecurso.ReadOnly = True
        Me.txtRecurso.Size = New System.Drawing.Size(156, 20)
        Me.txtRecurso.TabIndex = 27
        Me.txtRecurso.TabStop = False
        Me.txtRecurso.Text = "Medicamentos"
        Me.txtRecurso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtDiasTratamiento
        '
        Me.txtDiasTratamiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiasTratamiento.Location = New System.Drawing.Point(416, 209)
        Me.txtDiasTratamiento.Name = "txtDiasTratamiento"
        Me.txtDiasTratamiento.Size = New System.Drawing.Size(156, 29)
        Me.txtDiasTratamiento.TabIndex = 28
        Me.txtDiasTratamiento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelDiasTra
        '
        Me.LabelDiasTra.AutoSize = True
        Me.LabelDiasTra.Location = New System.Drawing.Point(416, 193)
        Me.LabelDiasTra.Name = "LabelDiasTra"
        Me.LabelDiasTra.Size = New System.Drawing.Size(100, 13)
        Me.LabelDiasTra.TabIndex = 29
        Me.LabelDiasTra.Text = "Días de tratamiento"
        '
        'frmSeleccionarTratamientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 279)
        Me.Controls.Add(Me.dgvTratamientos)
        Me.Controls.Add(Me.LabelDiasTra)
        Me.Controls.Add(Me.txtDiasTratamiento)
        Me.Controls.Add(Me.txtRecurso)
        Me.Controls.Add(Me.txtPosologia)
        Me.Controls.Add(Me.txtServicio)
        Me.Controls.Add(Me.txtTipo)
        Me.Controls.Add(Me.dgvBusquedaTratamientos)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.LabelVista)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtReloj)
        Me.Controls.Add(Me.txtNombres)
        Me.Controls.Add(Me.btnBorrar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSeleccionarTratamientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Seleccionar tratamientos"
        CType(Me.dgvTratamientos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBusquedaTratamientos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiasTratamiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAgregar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtReloj As System.Windows.Forms.TextBox
    Friend WithEvents txtNombres As System.Windows.Forms.TextBox
    Friend WithEvents dgvTratamientos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents LabelVista As System.Windows.Forms.Label
    Friend WithEvents dgvBusquedaTratamientos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtTipo As System.Windows.Forms.TextBox
    Friend WithEvents txtServicio As System.Windows.Forms.TextBox
    Friend WithEvents txtPosologia As System.Windows.Forms.TextBox
    Friend WithEvents txtRecurso As System.Windows.Forms.TextBox
    Friend WithEvents txtDiasTratamiento As System.Windows.Forms.NumericUpDown
    Friend WithEvents LabelDiasTra As System.Windows.Forms.Label
    Friend WithEvents ColumnCodBusqueda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnNombreBusqueda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnServicioTratamiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnPosologia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnRecurso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnTipoTratamiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnDiasTratamiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnCodTratamiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnTratamiento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnPosologiaT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnDiasTratamientoT As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
