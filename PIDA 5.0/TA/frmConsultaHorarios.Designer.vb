<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaHorarios
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
        Me.cmbPeriodos = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.cmbHorarios = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridViewX1 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbPeriodos
        '
        Me.cmbPeriodos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPeriodos.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPeriodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPeriodos.ButtonCustom.Checked = True
        Me.cmbPeriodos.ButtonDropDown.Visible = True
        Me.cmbPeriodos.DisplayMembers = "unico,ano,periodo,fecha_ini,fecha_fin"
        Me.cmbPeriodos.FocusHighlightEnabled = True
        Me.cmbPeriodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPeriodos.FormatString = "d"
        Me.cmbPeriodos.FormattingEnabled = True
        Me.cmbPeriodos.GridRowLines = True
        Me.cmbPeriodos.GroupingMembers = "ano"
        Me.cmbPeriodos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPeriodos.Location = New System.Drawing.Point(345, 27)
        Me.cmbPeriodos.Name = "cmbPeriodos"
        Me.cmbPeriodos.Size = New System.Drawing.Size(326, 23)
        Me.cmbPeriodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPeriodos.TabIndex = 112
        Me.cmbPeriodos.ValueMember = "unico"
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.Location = New System.Drawing.Point(344, 9)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(50, 15)
        Me.Label67.TabIndex = 113
        Me.Label67.Text = "Periodo"
        '
        'cmbHorarios
        '
        Me.cmbHorarios.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbHorarios.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbHorarios.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbHorarios.ButtonDropDown.Visible = True
        Me.cmbHorarios.DisplayMembers = "cod_hora,nombre"
        Me.cmbHorarios.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbHorarios.Location = New System.Drawing.Point(12, 27)
        Me.cmbHorarios.Name = "cmbHorarios"
        Me.cmbHorarios.Size = New System.Drawing.Size(326, 23)
        Me.cmbHorarios.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbHorarios.TabIndex = 114
        Me.cmbHorarios.ValueMember = "cod_hora"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 15)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "Horario"
        '
        'DataGridViewX1
        '
        Me.DataGridViewX1.AllowUserToAddRows = False
        Me.DataGridViewX1.AllowUserToDeleteRows = False
        Me.DataGridViewX1.AllowUserToResizeColumns = False
        Me.DataGridViewX1.AllowUserToResizeRows = False
        Me.DataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewX1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewX1.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DataGridViewX1.Location = New System.Drawing.Point(12, 56)
        Me.DataGridViewX1.Name = "DataGridViewX1"
        Me.DataGridViewX1.Size = New System.Drawing.Size(659, 113)
        Me.DataGridViewX1.TabIndex = 116
        '
        'frmConsultaHorarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 189)
        Me.Controls.Add(Me.DataGridViewX1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbHorarios)
        Me.Controls.Add(Me.Label67)
        Me.Controls.Add(Me.cmbPeriodos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsultaHorarios"
        Me.Text = "Detalle horarios"
        CType(Me.DataGridViewX1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbPeriodos As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents cmbHorarios As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewX1 As DevComponents.DotNetBar.Controls.DataGridViewX
End Class
