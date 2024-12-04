<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCondensadoNomina
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCondensadoNomina))
        Me.bgw = New System.ComponentModel.BackgroundWorker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.lblCia = New System.Windows.Forms.Label()
        Me.btnDirectorio = New DevComponents.DotNetBar.ButtonX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.bgwGenerar = New System.ComponentModel.BackgroundWorker()
        Me.cbTodo = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.gpAvance = New System.Windows.Forms.Panel()
        Me.pbAvance = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.lblAvance = New System.Windows.Forms.Label()
        Me.lstPeriodos = New System.Windows.Forms.ListBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.dgvCondensado = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.btnGenerar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ColumnFormato = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnGenerar = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.gpAvance.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel7.SuspendLayout()
        CType(Me.dgvCondensado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.Panel9.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bgw
        '
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ReflectionLabel1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.lblCia)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(10, 10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(651, 83)
        Me.Panel1.TabIndex = 283
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.BackgroundStyle.PaddingLeft = 10
        Me.ReflectionLabel1.BackgroundStyle.PaddingTop = 10
        Me.ReflectionLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(38, 0)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(613, 55)
        Me.ReflectionLabel1.TabIndex = 285
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CONDENSADO DE NÓMINA</b></font>"
        '
        'lblCia
        '
        Me.lblCia.BackColor = System.Drawing.Color.Silver
        Me.lblCia.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblCia.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCia.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lblCia.Location = New System.Drawing.Point(0, 55)
        Me.lblCia.Name = "lblCia"
        Me.lblCia.Size = New System.Drawing.Size(651, 28)
        Me.lblCia.TabIndex = 283
        Me.lblCia.Text = "COMPAÑIA"
        Me.lblCia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnDirectorio
        '
        Me.btnDirectorio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnDirectorio.CausesValidation = False
        Me.btnDirectorio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnDirectorio.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnDirectorio.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnDirectorio.Enabled = False
        Me.btnDirectorio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDirectorio.Location = New System.Drawing.Point(625, 0)
        Me.btnDirectorio.Name = "btnDirectorio"
        Me.btnDirectorio.Size = New System.Drawing.Size(26, 22)
        Me.btnDirectorio.TabIndex = 287
        Me.btnDirectorio.Text = "..."
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(651, 17)
        Me.Label1.TabIndex = 288
        Me.Label1.Text = "Directorio archivos"
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(460, 17)
        Me.Label2.TabIndex = 289
        Me.Label2.Text = "Periodo seleccionado"
        '
        'bgwGenerar
        '
        '
        'cbTodo
        '
        Me.cbTodo.AutoSize = True
        Me.cbTodo.Dock = System.Windows.Forms.DockStyle.Right
        Me.cbTodo.Enabled = False
        Me.cbTodo.Location = New System.Drawing.Point(545, 0)
        Me.cbTodo.Name = "cbTodo"
        Me.cbTodo.Size = New System.Drawing.Size(106, 30)
        Me.cbTodo.TabIndex = 291
        Me.cbTodo.Text = "Seleccionar todo"
        Me.cbTodo.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnGenerar)
        Me.GroupBox2.Controls.Add(Me.btnCerrar)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(10, 572)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(10, 0, 10, 8)
        Me.GroupBox2.Size = New System.Drawing.Size(651, 46)
        Me.GroupBox2.TabIndex = 292
        Me.GroupBox2.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.gpAvance)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(10, 93)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Panel2.Size = New System.Drawing.Size(651, 44)
        Me.Panel2.TabIndex = 293
        '
        'gpAvance
        '
        Me.gpAvance.Controls.Add(Me.lblAvance)
        Me.gpAvance.Controls.Add(Me.pbAvance)
        Me.gpAvance.Dock = System.Windows.Forms.DockStyle.Right
        Me.gpAvance.Location = New System.Drawing.Point(460, 5)
        Me.gpAvance.Name = "gpAvance"
        Me.gpAvance.Size = New System.Drawing.Size(191, 39)
        Me.gpAvance.TabIndex = 294
        '
        'pbAvance
        '
        Me.pbAvance.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.pbAvance.BackgroundStyle.BackColor = System.Drawing.Color.Transparent
        Me.pbAvance.BackgroundStyle.BackColor2 = System.Drawing.Color.Transparent
        Me.pbAvance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pbAvance.Dock = System.Windows.Forms.DockStyle.Right
        Me.pbAvance.Location = New System.Drawing.Point(126, 0)
        Me.pbAvance.Name = "pbAvance"
        Me.pbAvance.Padding = New System.Windows.Forms.Padding(5)
        Me.pbAvance.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.pbAvance.ProgressColor = System.Drawing.Color.ForestGreen
        Me.pbAvance.ProgressTextFormat = ""
        Me.pbAvance.Size = New System.Drawing.Size(65, 39)
        Me.pbAvance.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.pbAvance.TabIndex = 273
        '
        'lblAvance
        '
        Me.lblAvance.BackColor = System.Drawing.Color.Transparent
        Me.lblAvance.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblAvance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvance.Location = New System.Drawing.Point(0, 0)
        Me.lblAvance.Name = "lblAvance"
        Me.lblAvance.Size = New System.Drawing.Size(126, 39)
        Me.lblAvance.TabIndex = 274
        Me.lblAvance.Text = "Preparando datos..."
        Me.lblAvance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lstPeriodos
        '
        Me.lstPeriodos.BackColor = System.Drawing.SystemColors.Highlight
        Me.lstPeriodos.ColumnWidth = 70
        Me.lstPeriodos.Dock = System.Windows.Forms.DockStyle.Left
        Me.lstPeriodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPeriodos.ForeColor = System.Drawing.SystemColors.HighlightText
        Me.lstPeriodos.FormattingEnabled = True
        Me.lstPeriodos.ItemHeight = 16
        Me.lstPeriodos.Location = New System.Drawing.Point(0, 0)
        Me.lstPeriodos.MultiColumn = True
        Me.lstPeriodos.Name = "lstPeriodos"
        Me.lstPeriodos.Size = New System.Drawing.Size(180, 22)
        Me.lstPeriodos.TabIndex = 295
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.lstPeriodos)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 22)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(460, 22)
        Me.Panel3.TabIndex = 296
        '
        'Panel4
        '
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(10, 137)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(651, 7)
        Me.Panel4.TabIndex = 294
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.Panel7)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(10, 144)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(651, 54)
        Me.Panel5.TabIndex = 295
        '
        'TextBox1
        '
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.TextBox1.Enabled = False
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.TextBox1.Location = New System.Drawing.Point(0, 0)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(586, 22)
        Me.TextBox1.TabIndex = 289
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.TextBox1)
        Me.Panel7.Controls.Add(Me.btnDirectorio)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 17)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(651, 22)
        Me.Panel7.TabIndex = 290
        '
        'dgvCondensado
        '
        Me.dgvCondensado.AllowUserToAddRows = False
        Me.dgvCondensado.AllowUserToDeleteRows = False
        Me.dgvCondensado.AllowUserToOrderColumns = True
        Me.dgvCondensado.AllowUserToResizeColumns = False
        Me.dgvCondensado.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCondensado.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCondensado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCondensado.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnFormato, Me.ColumnNombre, Me.ColumnGenerar})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(141, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCondensado.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCondensado.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgvCondensado.Enabled = False
        Me.dgvCondensado.EnableHeadersVisualStyles = False
        Me.dgvCondensado.GridColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.dgvCondensado.Location = New System.Drawing.Point(10, 198)
        Me.dgvCondensado.Name = "dgvCondensado"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCondensado.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvCondensado.Size = New System.Drawing.Size(651, 343)
        Me.dgvCondensado.TabIndex = 296
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.Panel9)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(10, 541)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(651, 31)
        Me.Panel8.TabIndex = 297
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.cbTodo)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(651, 30)
        Me.Panel9.TabIndex = 298
        '
        'btnGenerar
        '
        Me.btnGenerar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGenerar.CausesValidation = False
        Me.btnGenerar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGenerar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnGenerar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnGenerar.Enabled = False
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.Image = Global.PIDA.My.Resources.Resources.imprime_
        Me.btnGenerar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnGenerar.ImageTextSpacing = 3
        Me.btnGenerar.Location = New System.Drawing.Point(10, 13)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(237, 25)
        Me.btnGenerar.TabIndex = 114
        Me.btnGenerar.Text = "Generar reportes seleccionados"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.salir_
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.ImageTextSpacing = 3
        Me.btnCerrar.Location = New System.Drawing.Point(551, 13)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(90, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 42
        Me.btnCerrar.Text = "Salir"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.condensado_
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 55)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 284
        Me.PictureBox1.TabStop = False
        '
        'ColumnFormato
        '
        Me.ColumnFormato.DataPropertyName = "id_formato"
        Me.ColumnFormato.HeaderText = "formato"
        Me.ColumnFormato.Name = "ColumnFormato"
        Me.ColumnFormato.ReadOnly = True
        Me.ColumnFormato.Visible = False
        '
        'ColumnNombre
        '
        Me.ColumnNombre.DataPropertyName = "nombre_reporte"
        Me.ColumnNombre.HeaderText = "Reporte"
        Me.ColumnNombre.Name = "ColumnNombre"
        Me.ColumnNombre.ReadOnly = True
        Me.ColumnNombre.Width = 500
        '
        'ColumnGenerar
        '
        Me.ColumnGenerar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColumnGenerar.Checked = True
        Me.ColumnGenerar.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.ColumnGenerar.CheckValue = Nothing
        Me.ColumnGenerar.DataPropertyName = "generar"
        Me.ColumnGenerar.HeaderText = "Incluir"
        Me.ColumnGenerar.Name = "ColumnGenerar"
        Me.ColumnGenerar.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColumnGenerar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'frmCondensadoNomina
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(671, 628)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.dgvCondensado)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCondensadoNomina"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Condensado de nómina"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.gpAvance.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        CType(Me.dgvCondensado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnGenerar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents bgw As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCia As System.Windows.Forms.Label
    Friend WithEvents btnDirectorio As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents bgwGenerar As System.ComponentModel.BackgroundWorker
    Friend WithEvents cbTodo As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents gpAvance As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Public WithEvents lstPeriodos As System.Windows.Forms.ListBox
    Friend WithEvents lblAvance As System.Windows.Forms.Label
    Friend WithEvents pbAvance As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents dgvCondensado As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents ColumnFormato As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnGenerar As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
End Class
