<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmElegirCampo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmElegirCampo))
        Me.ComboTree1 = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonX2 = New DevComponents.DotNetBar.ButtonX()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'ComboTree1
        '
        Me.ComboTree1.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.ComboTree1.BackgroundStyle.Class = "TextBoxBorder"
        Me.ComboTree1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ComboTree1.ButtonDropDown.Visible = True
        Me.ComboTree1.Columns.Add(Me.ColumnHeader1)
        Me.ComboTree1.Columns.Add(Me.ColumnHeader2)
        Me.ComboTree1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ComboTree1.Location = New System.Drawing.Point(15, 71)
        Me.ComboTree1.Name = "ComboTree1"
        Me.ComboTree1.Size = New System.Drawing.Size(333, 23)
        Me.ComboTree1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ComboTree1.TabIndex = 0
        Me.ComboTree1.ValueMember = "cod_campo"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.DataFieldName = "cod_campo"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Cód. Campo"
        Me.ColumnHeader1.Width.Absolute = 100
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.DataFieldName = "nombre_campo"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.StretchToFill = True
        Me.ColumnHeader2.Text = "Campo"
        Me.ColumnHeader2.Width.Absolute = 150
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Campo para reporte de último movimiento"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(12, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(294, 40)
        Me.ReflectionLabel1.TabIndex = 106
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>SELECCIONAR CAMPO</b></font>"
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.ButtonX1.Location = New System.Drawing.Point(273, 137)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 107
        Me.ButtonX1.Text = "Aceptar"
        '
        'ButtonX2
        '
        Me.ButtonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX2.Image = Global.PIDA.My.Resources.Resources.Cancel16
        Me.ButtonX2.Location = New System.Drawing.Point(192, 137)
        Me.ButtonX2.Name = "ButtonX2"
        Me.ButtonX2.Size = New System.Drawing.Size(75, 23)
        Me.ButtonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX2.TabIndex = 108
        Me.ButtonX2.Text = "Cancelar"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(15, 100)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(228, 17)
        Me.CheckBox1.TabIndex = 109
        Me.CheckBox1.Text = "Sólo personal con promociones registradas"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'frmElegirCampo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(360, 172)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.ButtonX2)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboTree1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmElegirCampo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Seleccionar campo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboTree1 As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
