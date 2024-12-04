<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelAnoPeriodo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelAnoPeriodo))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.cmbPeriodos = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader12 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader13 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader14 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader15 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader16 = New DevComponents.AdvTree.ColumnHeader()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Periodo32
        Me.PictureBox1.Location = New System.Drawing.Point(12, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.TabIndex = 260
        Me.PictureBox1.TabStop = False
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(51, 6)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(427, 61)
        Me.ReflectionLabel1.TabIndex = 259
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>SELECCIONAR SEMANA DE PAGO PARA NÓMINA</b></font>"
        '
        'cmbPeriodos
        '
        Me.cmbPeriodos.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPeriodos.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPeriodos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPeriodos.ButtonDropDown.Visible = True
        Me.cmbPeriodos.Columns.Add(Me.ColumnHeader3)
        Me.cmbPeriodos.Columns.Add(Me.ColumnHeader12)
        Me.cmbPeriodos.Columns.Add(Me.ColumnHeader13)
        Me.cmbPeriodos.Columns.Add(Me.ColumnHeader14)
        Me.cmbPeriodos.Columns.Add(Me.ColumnHeader15)
        Me.cmbPeriodos.Columns.Add(Me.ColumnHeader16)
        Me.cmbPeriodos.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPeriodos.FormatString = "d"
        Me.cmbPeriodos.FormattingEnabled = True
        Me.cmbPeriodos.KeyboardSearchNoSelectionAllowed = False
        Me.cmbPeriodos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPeriodos.Location = New System.Drawing.Point(12, 80)
        Me.cmbPeriodos.Margin = New System.Windows.Forms.Padding(3, 10, 3, 3)
        Me.cmbPeriodos.Name = "cmbPeriodos"
        Me.cmbPeriodos.SelectionBoxStyle = DevComponents.AdvTree.eSelectionStyle.FullRowSelect
        Me.cmbPeriodos.Size = New System.Drawing.Size(466, 23)
        Me.cmbPeriodos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPeriodos.TabIndex = 261
        Me.cmbPeriodos.ValueMember = "seleccionado"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnAceptar.Location = New System.Drawing.Point(400, 121)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 262
        Me.btnAceptar.Text = "Aceptar"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.DataFieldName = "seleccionado"
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Column"
        Me.ColumnHeader3.Visible = False
        Me.ColumnHeader3.Width.Absolute = 70
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.DataFieldName = "ANO"
        Me.ColumnHeader12.Name = "ColumnHeader12"
        Me.ColumnHeader12.Text = "Año"
        Me.ColumnHeader12.Width.Absolute = 40
        '
        'ColumnHeader13
        '
        Me.ColumnHeader13.DataFieldName = "PERIODO"
        Me.ColumnHeader13.Name = "ColumnHeader13"
        Me.ColumnHeader13.Text = "Periodo"
        Me.ColumnHeader13.Width.Absolute = 50
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.DataFieldName = "FECHA_INI"
        Me.ColumnHeader14.Name = "ColumnHeader14"
        Me.ColumnHeader14.Text = "Fecha Inicial"
        Me.ColumnHeader14.Width.Absolute = 100
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.DataFieldName = "FECHA_FIN"
        Me.ColumnHeader15.Name = "ColumnHeader15"
        Me.ColumnHeader15.Text = "Fecha fin"
        Me.ColumnHeader15.Width.Absolute = 100
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.DataFieldName = "FECHA_PAGO"
        Me.ColumnHeader16.Name = "ColumnHeader16"
        Me.ColumnHeader16.Text = "Fecha pago"
        Me.ColumnHeader16.Width.Absolute = 100
        '
        'frmSelAnoPeriodo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(486, 149)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.cmbPeriodos)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSelAnoPeriodo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Selección de periodo"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents cmbPeriodos As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader12 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader13 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader14 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader15 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader16 As DevComponents.AdvTree.ColumnHeader
End Class
