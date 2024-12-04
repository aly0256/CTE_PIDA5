<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeleccionarSintomas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeleccionarSintomas))
        Me.dgvSintomas = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ColumnCodSintoma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnSintoma = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.txtReloj = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAgregar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.LabelVista = New System.Windows.Forms.Label()
        Me.dgvBusquedaSintomas = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ColumnCodSinBusqueda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnNombreBusqueda = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnaimagen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvSintomas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvBusquedaSintomas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvSintomas
        '
        Me.dgvSintomas.AllowUserToAddRows = False
        Me.dgvSintomas.AllowUserToDeleteRows = False
        Me.dgvSintomas.AllowUserToResizeColumns = False
        Me.dgvSintomas.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSintomas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSintomas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSintomas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnCodSintoma, Me.ColumnSintoma})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSintomas.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSintomas.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvSintomas.Location = New System.Drawing.Point(12, 50)
        Me.dgvSintomas.MultiSelect = False
        Me.dgvSintomas.Name = "dgvSintomas"
        Me.dgvSintomas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSintomas.Size = New System.Drawing.Size(560, 188)
        Me.dgvSintomas.TabIndex = 4
        '
        'ColumnCodSintoma
        '
        Me.ColumnCodSintoma.DataPropertyName = "cod_sin"
        Me.ColumnCodSintoma.HeaderText = "ColumnCodSintoma"
        Me.ColumnCodSintoma.Name = "ColumnCodSintoma"
        Me.ColumnCodSintoma.Visible = False
        '
        'ColumnSintoma
        '
        Me.ColumnSintoma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColumnSintoma.DataPropertyName = "descripcion"
        Me.ColumnSintoma.HeaderText = "Síntoma"
        Me.ColumnSintoma.Name = "ColumnSintoma"
        Me.ColumnSintoma.ReadOnly = True
        '
        'txtNombres
        '
        Me.txtNombres.Enabled = False
        Me.txtNombres.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombres.Location = New System.Drawing.Point(62, 6)
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(348, 20)
        Me.txtNombres.TabIndex = 5
        '
        'txtReloj
        '
        Me.txtReloj.Enabled = False
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.Location = New System.Drawing.Point(497, 6)
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.Size = New System.Drawing.Size(75, 20)
        Me.txtReloj.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(460, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Reloj"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Nombre"
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
        Me.btnBorrar.TabIndex = 11
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
        Me.btnAgregar.TabIndex = 10
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
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "Aceptar"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(416, 82)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(156, 156)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(12, 50)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(560, 26)
        Me.TextBox1.TabIndex = 12
        '
        'LabelVista
        '
        Me.LabelVista.AutoSize = True
        Me.LabelVista.Location = New System.Drawing.Point(12, 34)
        Me.LabelVista.Name = "LabelVista"
        Me.LabelVista.Size = New System.Drawing.Size(52, 13)
        Me.LabelVista.TabIndex = 13
        Me.LabelVista.Text = "Síntomas"
        '
        'dgvBusquedaSintomas
        '
        Me.dgvBusquedaSintomas.AllowUserToAddRows = False
        Me.dgvBusquedaSintomas.AllowUserToDeleteRows = False
        Me.dgvBusquedaSintomas.AllowUserToResizeColumns = False
        Me.dgvBusquedaSintomas.AllowUserToResizeRows = False
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBusquedaSintomas.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvBusquedaSintomas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBusquedaSintomas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnCodSinBusqueda, Me.ColumnNombreBusqueda, Me.columnaimagen})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvBusquedaSintomas.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvBusquedaSintomas.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvBusquedaSintomas.Location = New System.Drawing.Point(12, 82)
        Me.dgvBusquedaSintomas.MultiSelect = False
        Me.dgvBusquedaSintomas.Name = "dgvBusquedaSintomas"
        Me.dgvBusquedaSintomas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBusquedaSintomas.Size = New System.Drawing.Size(398, 156)
        Me.dgvBusquedaSintomas.TabIndex = 14
        '
        'ColumnCodSinBusqueda
        '
        Me.ColumnCodSinBusqueda.DataPropertyName = "cod_sin"
        Me.ColumnCodSinBusqueda.HeaderText = "cod_sin"
        Me.ColumnCodSinBusqueda.Name = "ColumnCodSinBusqueda"
        Me.ColumnCodSinBusqueda.ReadOnly = True
        Me.ColumnCodSinBusqueda.Visible = False
        '
        'ColumnNombreBusqueda
        '
        Me.ColumnNombreBusqueda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColumnNombreBusqueda.DataPropertyName = "nombre"
        Me.ColumnNombreBusqueda.HeaderText = "Síntoma"
        Me.ColumnNombreBusqueda.Name = "ColumnNombreBusqueda"
        Me.ColumnNombreBusqueda.ReadOnly = True
        '
        'columnaimagen
        '
        Me.columnaimagen.DataPropertyName = "imagen"
        Me.columnaimagen.HeaderText = "imagen"
        Me.columnaimagen.Name = "columnaimagen"
        Me.columnaimagen.Visible = False
        '
        'frmSeleccionarSintomas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(786, 407)
        Me.Controls.Add(Me.dgvSintomas)
        Me.Controls.Add(Me.dgvBusquedaSintomas)
        Me.Controls.Add(Me.LabelVista)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnBorrar)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtReloj)
        Me.Controls.Add(Me.txtNombres)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSeleccionarSintomas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Seleccionar síntomas"
        CType(Me.dgvSintomas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvBusquedaSintomas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents dgvSintomas As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents txtNombres As System.Windows.Forms.TextBox
    Friend WithEvents txtReloj As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnAgregar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ColumnCodSintoma As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnSintoma As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents LabelVista As System.Windows.Forms.Label
    Friend WithEvents dgvBusquedaSintomas As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ColumnCodSinBusqueda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnNombreBusqueda As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnaimagen As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
