<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAguinaldo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAguinaldo))
        Me.dgAguinaldo = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Años = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cadena = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cambio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.lblCia = New DevComponents.DotNetBar.LabelX()
        Me.txtCia = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.AuxFam = New System.Windows.Forms.GroupBox()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnAgregar = New DevComponents.DotNetBar.ButtonX()
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCiasFirst = New DevComponents.DotNetBar.ButtonX()
        Me.btnCiasLast = New DevComponents.DotNetBar.ButtonX()
        Me.btnCiasNext = New DevComponents.DotNetBar.ButtonX()
        Me.btnCiasPrev = New DevComponents.DotNetBar.ButtonX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.dgAguinaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.AuxFam.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgAguinaldo
        '
        Me.dgAguinaldo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAguinaldo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgAguinaldo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAguinaldo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tipo, Me.NOMBRE, Me.Años, Me.Dias, Me.cadena, Me.cambio})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgAguinaldo.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgAguinaldo.EnableHeadersVisualStyles = False
        Me.dgAguinaldo.GridColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.dgAguinaldo.Location = New System.Drawing.Point(12, 110)
        Me.dgAguinaldo.MultiSelect = False
        Me.dgAguinaldo.Name = "dgAguinaldo"
        Me.dgAguinaldo.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAguinaldo.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgAguinaldo.RowHeadersWidth = 15
        Me.dgAguinaldo.Size = New System.Drawing.Size(715, 208)
        Me.dgAguinaldo.TabIndex = 121
        '
        'Tipo
        '
        Me.Tipo.DataPropertyName = "TIPO"
        Me.Tipo.FillWeight = 83.68774!
        Me.Tipo.HeaderText = "TIPO"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        '
        'NOMBRE
        '
        Me.NOMBRE.DataPropertyName = "NOMBRE"
        Me.NOMBRE.FillWeight = 152.2843!
        Me.NOMBRE.HeaderText = "NOMBRE"
        Me.NOMBRE.Name = "NOMBRE"
        Me.NOMBRE.ReadOnly = True
        '
        'Años
        '
        Me.Años.DataPropertyName = "AÑOS"
        Me.Años.FillWeight = 82.01399!
        Me.Años.HeaderText = "AÑOS"
        Me.Años.Name = "Años"
        Me.Años.ReadOnly = True
        '
        'Dias
        '
        Me.Dias.DataPropertyName = "DÍAS"
        Me.Dias.FillWeight = 82.01399!
        Me.Dias.HeaderText = "DÍAS"
        Me.Dias.Name = "Dias"
        Me.Dias.ReadOnly = True
        '
        'cadena
        '
        Me.cadena.DataPropertyName = "cadena"
        Me.cadena.HeaderText = "cadena"
        Me.cadena.Name = "cadena"
        Me.cadena.ReadOnly = True
        Me.cadena.Visible = False
        '
        'cambio
        '
        Me.cambio.DataPropertyName = "cambio"
        Me.cambio.HeaderText = "cambio"
        Me.cambio.Name = "cambio"
        Me.cambio.ReadOnly = True
        Me.cambio.Visible = False
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
        Me.ReflectionLabel1.Size = New System.Drawing.Size(319, 40)
        Me.ReflectionLabel1.TabIndex = 119
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>AGUINALDO</b></font>"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LabelX1)
        Me.GroupBox1.Controls.Add(Me.lblCia)
        Me.GroupBox1.Controls.Add(Me.txtCia)
        Me.GroupBox1.Controls.Add(Me.txtNombre)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(715, 46)
        Me.GroupBox1.TabIndex = 118
        Me.GroupBox1.TabStop = False
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(264, 14)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(64, 23)
        Me.LabelX1.TabIndex = 37
        Me.LabelX1.Text = "Nombre"
        '
        'lblCia
        '
        '
        '
        '
        Me.lblCia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCia.Location = New System.Drawing.Point(9, 14)
        Me.lblCia.Name = "lblCia"
        Me.lblCia.Size = New System.Drawing.Size(124, 23)
        Me.lblCia.TabIndex = 36
        Me.lblCia.Text = "Cód. compañía"
        '
        'txtCia
        '
        '
        '
        '
        Me.txtCia.Border.Class = "TextBoxBorder"
        Me.txtCia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCia.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCia.Location = New System.Drawing.Point(134, 14)
        Me.txtCia.MaxLength = 3
        Me.txtCia.Name = "txtCia"
        Me.txtCia.ReadOnly = True
        Me.txtCia.Size = New System.Drawing.Size(84, 26)
        Me.txtCia.TabIndex = 0
        '
        'txtNombre
        '
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNombre.Location = New System.Drawing.Point(339, 14)
        Me.txtNombre.MaxLength = 30
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(364, 26)
        Me.txtNombre.TabIndex = 34
        '
        'AuxFam
        '
        Me.AuxFam.BackColor = System.Drawing.SystemColors.Control
        Me.AuxFam.Controls.Add(Me.btnReporte)
        Me.AuxFam.Controls.Add(Me.btnAgregar)
        Me.AuxFam.Controls.Add(Me.btnEditar)
        Me.AuxFam.Controls.Add(Me.btnCerrar)
        Me.AuxFam.Controls.Add(Me.btnCiasFirst)
        Me.AuxFam.Controls.Add(Me.btnCiasLast)
        Me.AuxFam.Controls.Add(Me.btnCiasNext)
        Me.AuxFam.Controls.Add(Me.btnCiasPrev)
        Me.AuxFam.Location = New System.Drawing.Point(12, 324)
        Me.AuxFam.Name = "AuxFam"
        Me.AuxFam.Size = New System.Drawing.Size(715, 45)
        Me.AuxFam.TabIndex = 117
        Me.AuxFam.TabStop = False
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnReporte.Location = New System.Drawing.Point(387, 14)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 76
        Me.btnReporte.Text = "Reporte"
        '
        'btnAgregar
        '
        Me.btnAgregar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAgregar.CausesValidation = False
        Me.btnAgregar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = Global.PIDA.My.Resources.Resources.NewRecord
        Me.btnAgregar.Location = New System.Drawing.Point(468, 14)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(78, 25)
        Me.btnAgregar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAgregar.TabIndex = 74
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.Visible = False
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = Global.PIDA.My.Resources.Resources.Edit
        Me.btnEditar.Location = New System.Drawing.Point(549, 14)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(78, 25)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 75
        Me.btnEditar.Text = "Editar"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(630, 14)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 77
        Me.btnCerrar.Text = "Salir"
        '
        'btnCiasFirst
        '
        Me.btnCiasFirst.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCiasFirst.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCiasFirst.Image = Global.PIDA.My.Resources.Resources.First16
        Me.btnCiasFirst.Location = New System.Drawing.Point(8, 14)
        Me.btnCiasFirst.Name = "btnCiasFirst"
        Me.btnCiasFirst.Size = New System.Drawing.Size(78, 25)
        Me.btnCiasFirst.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCiasFirst.TabIndex = 69
        Me.btnCiasFirst.Text = "Inicio"
        '
        'btnCiasLast
        '
        Me.btnCiasLast.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCiasLast.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCiasLast.Image = Global.PIDA.My.Resources.Resources.Last16
        Me.btnCiasLast.Location = New System.Drawing.Point(251, 14)
        Me.btnCiasLast.Name = "btnCiasLast"
        Me.btnCiasLast.Size = New System.Drawing.Size(78, 25)
        Me.btnCiasLast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCiasLast.TabIndex = 72
        Me.btnCiasLast.Text = "Final"
        '
        'btnCiasNext
        '
        Me.btnCiasNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCiasNext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCiasNext.Image = Global.PIDA.My.Resources.Resources.Next16
        Me.btnCiasNext.Location = New System.Drawing.Point(170, 14)
        Me.btnCiasNext.Name = "btnCiasNext"
        Me.btnCiasNext.Size = New System.Drawing.Size(78, 25)
        Me.btnCiasNext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCiasNext.TabIndex = 71
        Me.btnCiasNext.Text = "Siguiente"
        '
        'btnCiasPrev
        '
        Me.btnCiasPrev.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCiasPrev.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCiasPrev.Image = Global.PIDA.My.Resources.Resources.Prev16
        Me.btnCiasPrev.Location = New System.Drawing.Point(89, 14)
        Me.btnCiasPrev.Name = "btnCiasPrev"
        Me.btnCiasPrev.Size = New System.Drawing.Size(78, 25)
        Me.btnCiasPrev.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCiasPrev.TabIndex = 70
        Me.btnCiasPrev.Text = "Anterior"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Aguinaldo24
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(27, 26)
        Me.PictureBox1.TabIndex = 120
        Me.PictureBox1.TabStop = False
        '
        'frmAguinaldo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(739, 384)
        Me.Controls.Add(Me.dgAguinaldo)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.AuxFam)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAguinaldo"
        Me.Text = "Aguinaldo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgAguinaldo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.AuxFam.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgAguinaldo As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblCia As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtCia As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents AuxFam As System.Windows.Forms.GroupBox
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAgregar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCiasFirst As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCiasLast As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCiasNext As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCiasPrev As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Años As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dias As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cadena As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cambio As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
