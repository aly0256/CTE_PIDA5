<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAplicaIsrAnual
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAplicaIsrAnual))
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAplicar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgAplicaIsrAnual = New System.Windows.Forms.DataGridView()
        Me.reloj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tipo_periodo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.alta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dias = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.neto_anual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.isrcau = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.isrret = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.difisr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.subcau = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.afavor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aplica = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.dgAplicaIsrAnual, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(1067, 670)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(93, 43)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 131
        Me.btnCerrar.Text = "Salir"
        '
        'btnAplicar
        '
        Me.btnAplicar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAplicar.CausesValidation = False
        Me.btnAplicar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAplicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAplicar.Location = New System.Drawing.Point(923, 670)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(122, 43)
        Me.btnAplicar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAplicar.TabIndex = 130
        Me.btnAplicar.Text = "Aplicar seleccionados"
        Me.btnAplicar.Tooltip = "Buscar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgAplicaIsrAnual)
        Me.Panel1.Location = New System.Drawing.Point(34, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1128, 624)
        Me.Panel1.TabIndex = 132
        '
        'dgAplicaIsrAnual
        '
        Me.dgAplicaIsrAnual.AllowUserToDeleteRows = False
        Me.dgAplicaIsrAnual.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAplicaIsrAnual.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgAplicaIsrAnual.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAplicaIsrAnual.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.reloj, Me.nombres, Me.tipo_periodo, Me.alta, Me.dias, Me.neto_anual, Me.isrcau, Me.isrret, Me.difisr, Me.subcau, Me.afavor, Me.aplica})
        Me.dgAplicaIsrAnual.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgAplicaIsrAnual.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgAplicaIsrAnual.Location = New System.Drawing.Point(0, 0)
        Me.dgAplicaIsrAnual.Name = "dgAplicaIsrAnual"
        Me.dgAplicaIsrAnual.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgAplicaIsrAnual.Size = New System.Drawing.Size(1128, 624)
        Me.dgAplicaIsrAnual.TabIndex = 117
        '
        'reloj
        '
        Me.reloj.DataPropertyName = "reloj"
        Me.reloj.HeaderText = "RELOJ"
        Me.reloj.Name = "reloj"
        Me.reloj.Width = 60
        '
        'nombres
        '
        Me.nombres.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.nombres.DataPropertyName = "nombres"
        Me.nombres.HeaderText = "NOMBRES"
        Me.nombres.Name = "nombres"
        '
        'tipo_periodo
        '
        Me.tipo_periodo.DataPropertyName = "tipo_periodo"
        Me.tipo_periodo.HeaderText = "PERIODO"
        Me.tipo_periodo.Name = "tipo_periodo"
        '
        'alta
        '
        Me.alta.DataPropertyName = "alta"
        Me.alta.HeaderText = "ALTA"
        Me.alta.Name = "alta"
        '
        'dias
        '
        Me.dias.DataPropertyName = "dias"
        Me.dias.HeaderText = "DIAS"
        Me.dias.Name = "dias"
        Me.dias.Width = 50
        '
        'neto_anual
        '
        Me.neto_anual.DataPropertyName = "neto_anual"
        Me.neto_anual.HeaderText = "NETO ANUAL"
        Me.neto_anual.Name = "neto_anual"
        '
        'isrcau
        '
        Me.isrcau.DataPropertyName = "isrcau"
        Me.isrcau.HeaderText = "ISR CAU"
        Me.isrcau.Name = "isrcau"
        '
        'isrret
        '
        Me.isrret.DataPropertyName = "isrret"
        Me.isrret.HeaderText = "ISR RET"
        Me.isrret.Name = "isrret"
        '
        'difisr
        '
        Me.difisr.DataPropertyName = "difisr"
        Me.difisr.HeaderText = "DIF.ISR"
        Me.difisr.Name = "difisr"
        '
        'subcau
        '
        Me.subcau.DataPropertyName = "subcau"
        Me.subcau.HeaderText = "SUB.CAU"
        Me.subcau.Name = "subcau"
        Me.subcau.Width = 50
        '
        'afavor
        '
        Me.afavor.DataPropertyName = "afavor"
        Me.afavor.HeaderText = "FAVOR"
        Me.afavor.Name = "afavor"
        Me.afavor.Width = 50
        '
        'aplica
        '
        Me.aplica.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.aplica.CheckBoxImageIndeterminate = Global.PIDA.My.Resources.Resources.CancelX
        Me.aplica.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.CancelX
        Me.aplica.Checked = True
        Me.aplica.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.aplica.CheckValue = Nothing
        Me.aplica.CheckValueChecked = "1"
        Me.aplica.CheckValueUnchecked = "0"
        Me.aplica.DataPropertyName = "aplica"
        Me.aplica.HeaderText = "APLICAR"
        Me.aplica.Name = "aplica"
        Me.aplica.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.aplica.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.aplica.Width = 60
        '
        'frmAplicaIsrAnual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1171, 721)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAplicar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAplicaIsrAnual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aplicar / Asentar ISR Anual"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgAplicaIsrAnual, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAplicar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgAplicaIsrAnual As System.Windows.Forms.DataGridView
    Friend WithEvents reloj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tipo_periodo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents alta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dias As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents neto_anual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents isrcau As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents isrret As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents difisr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents subcau As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents afavor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents aplica As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
End Class
