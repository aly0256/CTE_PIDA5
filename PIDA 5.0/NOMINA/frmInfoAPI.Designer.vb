<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInfoAPI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInfoAPI))
        Me.btnConexion = New System.Windows.Forms.Button()
        Me.btnExporta = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.intRango = New DevComponents.Editors.IntegerInput()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbPeriodo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbAno = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CircularProgress4 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnNomina = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgv1 = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.hiloTrabajo = New System.ComponentModel.BackgroundWorker()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lstDet = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lstLog = New System.Windows.Forms.ListBox()
        Me.GroupBox5.SuspendLayout()
        CType(Me.intRango, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnConexion
        '
        Me.btnConexion.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnConexion.Location = New System.Drawing.Point(15, 18)
        Me.btnConexion.Name = "btnConexion"
        Me.btnConexion.Size = New System.Drawing.Size(100, 26)
        Me.btnConexion.TabIndex = 0
        Me.btnConexion.Text = "Conectar"
        Me.btnConexion.UseVisualStyleBackColor = True
        '
        'btnExporta
        '
        Me.btnExporta.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnExporta.Location = New System.Drawing.Point(115, 18)
        Me.btnExporta.Name = "btnExporta"
        Me.btnExporta.Size = New System.Drawing.Size(100, 26)
        Me.btnExporta.TabIndex = 6
        Me.btnExporta.Text = "Genera excel"
        Me.btnExporta.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.intRango)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.cmbPeriodo)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.cmbAno)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.CircularProgress4)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(15, 15)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(15, 20, 15, 20)
        Me.GroupBox5.Size = New System.Drawing.Size(927, 73)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Datos periodo"
        '
        'intRango
        '
        '
        '
        '
        Me.intRango.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.intRango.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.intRango.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.intRango.Dock = System.Windows.Forms.DockStyle.Left
        Me.intRango.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.intRango.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.intRango.Location = New System.Drawing.Point(716, 33)
        Me.intRango.MaxValue = 30
        Me.intRango.MinValue = 0
        Me.intRango.Name = "intRango"
        Me.intRango.ShowUpDown = True
        Me.intRango.Size = New System.Drawing.Size(80, 20)
        Me.intRango.TabIndex = 250
        Me.intRango.Value = 7
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(536, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(180, 20)
        Me.Label5.TabIndex = 249
        Me.Label5.Text = "Rango de días anticipado"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbPeriodo
        '
        Me.cmbPeriodo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPeriodo.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPeriodo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPeriodo.ButtonDropDown.Visible = True
        Me.cmbPeriodo.DisplayMembers = "periodo,Inicio,Fin"
        Me.cmbPeriodo.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmbPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPeriodo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPeriodo.Location = New System.Drawing.Point(237, 33)
        Me.cmbPeriodo.Name = "cmbPeriodo"
        Me.cmbPeriodo.Size = New System.Drawing.Size(299, 20)
        Me.cmbPeriodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPeriodo.TabIndex = 248
        Me.cmbPeriodo.ValueMember = "periodo"
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(151, 33)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 20)
        Me.Label4.TabIndex = 247
        Me.Label4.Text = "Periodo"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbAno
        '
        Me.cmbAno.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbAno.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbAno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbAno.ButtonDropDown.Visible = True
        Me.cmbAno.DisplayMembers = "ano"
        Me.cmbAno.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmbAno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAno.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbAno.Location = New System.Drawing.Point(57, 33)
        Me.cmbAno.Name = "cmbAno"
        Me.cmbAno.Size = New System.Drawing.Size(94, 20)
        Me.cmbAno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbAno.TabIndex = 246
        Me.cmbAno.ValueMember = "ano"
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Año"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CircularProgress4
        '
        Me.CircularProgress4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CircularProgress4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.CircularProgress4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress4.FocusCuesEnabled = False
        Me.CircularProgress4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CircularProgress4.Location = New System.Drawing.Point(858, 11)
        Me.CircularProgress4.Name = "CircularProgress4"
        Me.CircularProgress4.ProgressColor = System.Drawing.Color.SteelBlue
        Me.CircularProgress4.ProgressTextVisible = True
        Me.CircularProgress4.Size = New System.Drawing.Size(59, 55)
        Me.CircularProgress4.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress4.TabIndex = 251
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnNomina)
        Me.GroupBox2.Controls.Add(Me.btnExporta)
        Me.GroupBox2.Controls.Add(Me.btnConexion)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(15, 659)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(15, 5, 15, 10)
        Me.GroupBox2.Size = New System.Drawing.Size(927, 54)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        '
        'btnNomina
        '
        Me.btnNomina.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnNomina.Location = New System.Drawing.Point(812, 18)
        Me.btnNomina.Name = "btnNomina"
        Me.btnNomina.Size = New System.Drawing.Size(100, 26)
        Me.btnNomina.TabIndex = 8
        Me.btnNomina.Text = "Exportar a nómina"
        Me.btnNomina.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dgv1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(15, 88)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(15)
        Me.GroupBox1.Size = New System.Drawing.Size(927, 341)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Información"
        '
        'dgv1
        '
        Me.dgv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgv1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.dgv1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgv1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.dgv1.Location = New System.Drawing.Point(15, 28)
        Me.dgv1.Name = "dgv1"
        '
        '
        '
        Me.dgv1.PrimaryGrid.AllowEdit = False
        Me.dgv1.PrimaryGrid.ColumnAutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.DisplayedCells
        Me.dgv1.PrimaryGrid.EnableColumnFiltering = True
        Me.dgv1.PrimaryGrid.EnableFiltering = True
        Me.dgv1.PrimaryGrid.EnableRowFiltering = True
        '
        '
        '
        Me.dgv1.PrimaryGrid.Filter.ShowPanelFilterExpr = True
        Me.dgv1.PrimaryGrid.Filter.Visible = True
        Me.dgv1.Size = New System.Drawing.Size(897, 298)
        Me.dgv1.TabIndex = 2
        Me.dgv1.Text = "SuperGridControl1"
        '
        'hiloTrabajo
        '
        Me.hiloTrabajo.WorkerReportsProgress = True
        Me.hiloTrabajo.WorkerSupportsCancellation = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GroupBox4)
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(15, 429)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(927, 230)
        Me.Panel2.TabIndex = 16
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lstDet)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(245, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(15)
        Me.GroupBox4.Size = New System.Drawing.Size(682, 230)
        Me.GroupBox4.TabIndex = 17
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Detalles"
        '
        'lstDet
        '
        Me.lstDet.BackColor = System.Drawing.Color.Black
        Me.lstDet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstDet.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.lstDet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstDet.ForeColor = System.Drawing.Color.White
        Me.lstDet.FormattingEnabled = True
        Me.lstDet.ItemHeight = 15
        Me.lstDet.Location = New System.Drawing.Point(15, 28)
        Me.lstDet.Name = "lstDet"
        Me.lstDet.Size = New System.Drawing.Size(652, 187)
        Me.lstDet.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(237, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(8, 230)
        Me.Panel1.TabIndex = 16
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lstLog)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(15)
        Me.GroupBox3.Size = New System.Drawing.Size(237, 230)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Log"
        '
        'lstLog
        '
        Me.lstLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstLog.FormattingEnabled = True
        Me.lstLog.Location = New System.Drawing.Point(15, 28)
        Me.lstLog.Name = "lstLog"
        Me.lstLog.Size = New System.Drawing.Size(207, 187)
        Me.lstLog.TabIndex = 0
        '
        'frmInfoAPI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(957, 728)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfoAPI"
        Me.Padding = New System.Windows.Forms.Padding(15)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "API Bono productividad"
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.intRango, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnConexion As System.Windows.Forms.Button
    Friend WithEvents btnExporta As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbAno As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cmbPeriodo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents intRango As DevComponents.Editors.IntegerInput
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dgv1 As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents hiloTrabajo As System.ComponentModel.BackgroundWorker
    Friend WithEvents CircularProgress4 As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents btnNomina As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents lstLog As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents lstDet As System.Windows.Forms.ListBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
