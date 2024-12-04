<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConfigPerLiqFah
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConfigPerLiqFah))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dvbPerLiqFah = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.cLAnioIni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cLPerIni = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.anio_fin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.per_fin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.anio_liq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.coment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.btnAddPer = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1.SuspendLayout()
        CType(Me.dvbPerLiqFah, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dvbPerLiqFah)
        Me.Panel1.Location = New System.Drawing.Point(29, 58)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(676, 512)
        Me.Panel1.TabIndex = 0
        '
        'dvbPerLiqFah
        '
        Me.dvbPerLiqFah.AllowUserToAddRows = False
        Me.dvbPerLiqFah.AllowUserToDeleteRows = False
        Me.dvbPerLiqFah.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.dvbPerLiqFah.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dvbPerLiqFah.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dvbPerLiqFah.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dvbPerLiqFah.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cLAnioIni, Me.cLPerIni, Me.anio_fin, Me.per_fin, Me.anio_liq, Me.coment})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(23, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(141, Byte), Integer))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dvbPerLiqFah.DefaultCellStyle = DataGridViewCellStyle3
        Me.dvbPerLiqFah.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dvbPerLiqFah.EnableHeadersVisualStyles = False
        Me.dvbPerLiqFah.GridColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.dvbPerLiqFah.Location = New System.Drawing.Point(0, 0)
        Me.dvbPerLiqFah.Name = "dvbPerLiqFah"
        Me.dvbPerLiqFah.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dvbPerLiqFah.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dvbPerLiqFah.RowHeadersVisible = False
        Me.dvbPerLiqFah.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dvbPerLiqFah.Size = New System.Drawing.Size(676, 512)
        Me.dvbPerLiqFah.TabIndex = 247
        '
        'cLAnioIni
        '
        Me.cLAnioIni.DataPropertyName = "anio_ini"
        Me.cLAnioIni.HeaderText = "Año inicia"
        Me.cLAnioIni.Name = "cLAnioIni"
        Me.cLAnioIni.ReadOnly = True
        '
        'cLPerIni
        '
        Me.cLPerIni.DataPropertyName = "per_ini"
        Me.cLPerIni.HeaderText = "Periodo ini"
        Me.cLPerIni.Name = "cLPerIni"
        Me.cLPerIni.ReadOnly = True
        '
        'anio_fin
        '
        Me.anio_fin.DataPropertyName = "anio_fin"
        Me.anio_fin.HeaderText = "Año fin"
        Me.anio_fin.Name = "anio_fin"
        Me.anio_fin.ReadOnly = True
        '
        'per_fin
        '
        Me.per_fin.DataPropertyName = "per_fin"
        Me.per_fin.HeaderText = "Periodo fin"
        Me.per_fin.Name = "per_fin"
        Me.per_fin.ReadOnly = True
        '
        'anio_liq
        '
        Me.anio_liq.DataPropertyName = "anio_liq"
        Me.anio_liq.HeaderText = "Año aplicar"
        Me.anio_liq.Name = "anio_liq"
        Me.anio_liq.ReadOnly = True
        '
        'coment
        '
        Me.coment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.coment.DataPropertyName = "coment"
        Me.coment.HeaderText = "Comentarios"
        Me.coment.Name = "coment"
        Me.coment.ReadOnly = True
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(157, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(393, 40)
        Me.ReflectionLabel1.TabIndex = 255
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>Periodos de ciclo para fondo de ahorro</b></font>"
        '
        'btnAddPer
        '
        Me.btnAddPer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAddPer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAddPer.Image = Global.PIDA.My.Resources.Resources.NewRecord
        Me.btnAddPer.Location = New System.Drawing.Point(499, 586)
        Me.btnAddPer.Name = "btnAddPer"
        Me.btnAddPer.Size = New System.Drawing.Size(75, 25)
        Me.btnAddPer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAddPer.TabIndex = 256
        Me.btnAddPer.Text = "Agregar"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(580, 586)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 257
        Me.btnCerrar.Text = "Salir"
        '
        'frmConfigPerLiqFah
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 620)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAddPer)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConfigPerLiqFah"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración de periodos de liquidación para fondo de ahorro"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dvbPerLiqFah, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dvbPerLiqFah As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents btnAddPer As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cLAnioIni As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cLPerIni As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents anio_fin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents per_fin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents anio_liq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents coment As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
