<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAplicaVar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAplicaVar))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgAplVar = New System.Windows.Forms.DataGridView()
        Me.btnAplicar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.cod_comp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ano = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bimestre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.reloj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombres = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sactual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nvo_fi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nvo_provar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nvo_integrado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comentario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aplica = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dgAplVar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(66, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(364, 40)
        Me.ReflectionLabel1.TabIndex = 111
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>APLICACION DE VARIABLES IMSS</b></font>"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.ModificacionesSueldo24
        Me.picImagen.Location = New System.Drawing.Point(22, 16)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(27, 26)
        Me.picImagen.TabIndex = 112
        Me.picImagen.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgAplVar)
        Me.Panel1.Location = New System.Drawing.Point(22, 58)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1055, 483)
        Me.Panel1.TabIndex = 113
        '
        'dgAplVar
        '
        Me.dgAplVar.AllowUserToDeleteRows = False
        Me.dgAplVar.AllowUserToResizeColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgAplVar.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgAplVar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAplVar.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cod_comp, Me.ano, Me.bimestre, Me.reloj, Me.nombres, Me.sactual, Me.nvo_fi, Me.nvo_provar, Me.nvo_integrado, Me.comentario, Me.aplica})
        Me.dgAplVar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgAplVar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgAplVar.Location = New System.Drawing.Point(0, 0)
        Me.dgAplVar.Name = "dgAplVar"
        Me.dgAplVar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgAplVar.Size = New System.Drawing.Size(1055, 483)
        Me.dgAplVar.TabIndex = 116
        '
        'btnAplicar
        '
        Me.btnAplicar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAplicar.CausesValidation = False
        Me.btnAplicar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAplicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAplicar.Location = New System.Drawing.Point(871, 556)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(110, 43)
        Me.btnAplicar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAplicar.TabIndex = 128
        Me.btnAplicar.Text = "Aplicar seleccionados"
        Me.btnAplicar.Tooltip = "Buscar"
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
        Me.btnCerrar.Location = New System.Drawing.Point(996, 556)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(81, 43)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 129
        Me.btnCerrar.Text = "Salir"
        '
        'cod_comp
        '
        Me.cod_comp.DataPropertyName = "cod_comp"
        Me.cod_comp.HeaderText = "COMP."
        Me.cod_comp.Name = "cod_comp"
        Me.cod_comp.Width = 45
        '
        'ano
        '
        Me.ano.DataPropertyName = "ano"
        Me.ano.HeaderText = "AÑO"
        Me.ano.Name = "ano"
        Me.ano.Width = 45
        '
        'bimestre
        '
        Me.bimestre.DataPropertyName = "bimestre"
        Me.bimestre.HeaderText = "BIM"
        Me.bimestre.Name = "bimestre"
        Me.bimestre.Width = 45
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
        Me.nombres.DataPropertyName = "nombres"
        Me.nombres.HeaderText = "NOMBRES"
        Me.nombres.Name = "nombres"
        Me.nombres.Width = 250
        '
        'sactual
        '
        Me.sactual.DataPropertyName = "sactual"
        Me.sactual.HeaderText = "SUELDO"
        Me.sactual.Name = "sactual"
        Me.sactual.Width = 50
        '
        'nvo_fi
        '
        Me.nvo_fi.DataPropertyName = "nvo_fi"
        Me.nvo_fi.HeaderText = "F.I."
        Me.nvo_fi.Name = "nvo_fi"
        Me.nvo_fi.Width = 50
        '
        'nvo_provar
        '
        Me.nvo_provar.DataPropertyName = "nvo_provar"
        Me.nvo_provar.HeaderText = "P.VAR"
        Me.nvo_provar.Name = "nvo_provar"
        Me.nvo_provar.Width = 50
        '
        'nvo_integrado
        '
        Me.nvo_integrado.DataPropertyName = "nvo_integrado"
        Me.nvo_integrado.HeaderText = "INT."
        Me.nvo_integrado.Name = "nvo_integrado"
        Me.nvo_integrado.Width = 50
        '
        'comentario
        '
        Me.comentario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.comentario.DataPropertyName = "comentario"
        Me.comentario.HeaderText = "COMENTARIO"
        Me.comentario.Name = "comentario"
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
        'frmAplicaVar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1104, 606)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAplicar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.picImagen)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAplicaVar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aplicación de varaibles"
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgAplVar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgAplVar As System.Windows.Forms.DataGridView
    Friend WithEvents btnAplicar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents cod_comp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ano As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bimestre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents reloj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombres As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sactual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nvo_fi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nvo_provar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nvo_integrado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comentario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents aplica As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
End Class
