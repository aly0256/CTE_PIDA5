<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMarcarFiniquitoEspecial
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMarcarFiniquitoEspecial))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgEmploys = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.btnAcepta = New System.Windows.Forms.Button()
        Me.btnCancela = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbAno = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.cmbPeriodo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.rbS = New System.Windows.Forms.RadioButton()
        Me.rbQ = New System.Windows.Forms.RadioButton()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgEmploys, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgEmploys)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 14)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox2.Size = New System.Drawing.Size(661, 190)
        Me.GroupBox2.TabIndex = 295
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Empleados"
        '
        'dgEmploys
        '
        Me.dgEmploys.AllowUserToAddRows = False
        Me.dgEmploys.AllowUserToDeleteRows = False
        Me.dgEmploys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgEmploys.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgEmploys.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgEmploys.Location = New System.Drawing.Point(8, 23)
        Me.dgEmploys.Margin = New System.Windows.Forms.Padding(4)
        Me.dgEmploys.Name = "dgEmploys"
        Me.dgEmploys.ReadOnly = True
        Me.dgEmploys.Size = New System.Drawing.Size(645, 159)
        Me.dgEmploys.TabIndex = 0
        '
        'btnAcepta
        '
        Me.btnAcepta.Location = New System.Drawing.Point(579, 363)
        Me.btnAcepta.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAcepta.Name = "btnAcepta"
        Me.btnAcepta.Size = New System.Drawing.Size(100, 28)
        Me.btnAcepta.TabIndex = 294
        Me.btnAcepta.Text = "Aceptar"
        Me.btnAcepta.UseVisualStyleBackColor = True
        '
        'btnCancela
        '
        Me.btnCancela.Location = New System.Drawing.Point(467, 363)
        Me.btnCancela.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(100, 28)
        Me.btnCancela.TabIndex = 293
        Me.btnCancela.Text = "Cancelar"
        Me.btnCancela.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbAno)
        Me.GroupBox1.Controls.Add(Me.cmbPeriodo)
        Me.GroupBox1.Controls.Add(Me.rbS)
        Me.GroupBox1.Controls.Add(Me.rbQ)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 222)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(661, 134)
        Me.GroupBox1.TabIndex = 292
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(236, 53)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 18)
        Me.Label2.TabIndex = 252
        Me.Label2.Text = "Periodo:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 53)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 18)
        Me.Label1.TabIndex = 251
        Me.Label1.Text = "Año:"
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
        Me.cmbAno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAno.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbAno.Location = New System.Drawing.Point(32, 75)
        Me.cmbAno.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbAno.Name = "cmbAno"
        Me.cmbAno.Size = New System.Drawing.Size(185, 28)
        Me.cmbAno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbAno.TabIndex = 249
        Me.cmbAno.ValueMember = "ano"
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
        Me.cmbPeriodo.DisplayMembers = "cod"
        Me.cmbPeriodo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPeriodo.Location = New System.Drawing.Point(240, 75)
        Me.cmbPeriodo.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPeriodo.Name = "cmbPeriodo"
        Me.cmbPeriodo.Size = New System.Drawing.Size(309, 27)
        Me.cmbPeriodo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPeriodo.TabIndex = 248
        Me.cmbPeriodo.ValueMember = "cod"
        '
        'rbS
        '
        Me.rbS.AutoSize = True
        Me.rbS.Checked = True
        Me.rbS.Location = New System.Drawing.Point(28, 23)
        Me.rbS.Margin = New System.Windows.Forms.Padding(4)
        Me.rbS.Name = "rbS"
        Me.rbS.Size = New System.Drawing.Size(84, 21)
        Me.rbS.TabIndex = 247
        Me.rbS.TabStop = True
        Me.rbS.Text = "Semanal"
        Me.rbS.UseVisualStyleBackColor = True
        '
        'rbQ
        '
        Me.rbQ.AutoSize = True
        Me.rbQ.Location = New System.Drawing.Point(120, 23)
        Me.rbQ.Margin = New System.Windows.Forms.Padding(4)
        Me.rbQ.Name = "rbQ"
        Me.rbQ.Size = New System.Drawing.Size(93, 21)
        Me.rbQ.TabIndex = 246
        Me.rbQ.Text = "Quincenal"
        Me.rbQ.UseVisualStyleBackColor = True
        '
        'frmMarcarFiniquitoEspecial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 405)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnAcepta)
        Me.Controls.Add(Me.btnCancela)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMarcarFiniquitoEspecial"
        Me.Text = "Marcar finiquito especial"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgEmploys, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgEmploys As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnAcepta As System.Windows.Forms.Button
    Friend WithEvents btnCancela As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbAno As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cmbPeriodo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents rbS As System.Windows.Forms.RadioButton
    Friend WithEvents rbQ As System.Windows.Forms.RadioButton
End Class
