<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgVacs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProgVacs))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAplicar = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.dgvProgVacs = New System.Windows.Forms.DataGridView()
        Me.Ok = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.RELOJ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOTAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgvProgVacs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightGray
        Me.Panel1.Controls.Add(Me.picImagen)
        Me.Panel1.Controls.Add(Me.ReflectionLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(727, 62)
        Me.Panel1.TabIndex = 0
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.Planeacion32
        Me.picImagen.Location = New System.Drawing.Point(5, 13)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(46, 40)
        Me.picImagen.TabIndex = 112
        Me.picImagen.TabStop = False
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(58, 13)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(364, 40)
        Me.ReflectionLabel1.TabIndex = 111
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>PLANEACIÓN DE VACACIONES</b></font>"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.LightGray
        Me.Panel2.Controls.Add(Me.btnCerrar)
        Me.Panel2.Controls.Add(Me.btnBorrar)
        Me.Panel2.Controls.Add(Me.btnAplicar)
        Me.Panel2.Controls.Add(Me.btnNuevo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 550)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(727, 61)
        Me.Panel2.TabIndex = 1
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
        Me.btnCerrar.Location = New System.Drawing.Point(394, 7)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(110, 43)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 59
        Me.btnCerrar.Text = "Salir"
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = Global.PIDA.My.Resources.Resources.DeleteRec
        Me.btnBorrar.Location = New System.Drawing.Point(268, 6)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(110, 43)
        Me.btnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBorrar.TabIndex = 57
        Me.btnBorrar.Text = "Borrar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Seleccionado" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'btnAplicar
        '
        Me.btnAplicar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAplicar.CausesValidation = False
        Me.btnAplicar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAplicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAplicar.Location = New System.Drawing.Point(27, 7)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(110, 40)
        Me.btnAplicar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAplicar.TabIndex = 54
        Me.btnAplicar.Text = "Aplicar seleccionados"
        Me.btnAplicar.Tooltip = "Buscar"
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.NewRecord
        Me.btnNuevo.Location = New System.Drawing.Point(143, 7)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(110, 40)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 53
        Me.btnNuevo.Text = "Agregar"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.dgvProgVacs)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 62)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(727, 488)
        Me.Panel3.TabIndex = 2
        '
        'dgvProgVacs
        '
        Me.dgvProgVacs.AllowUserToAddRows = False
        Me.dgvProgVacs.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProgVacs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProgVacs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProgVacs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ok, Me.RELOJ, Me.nombre, Me.FECHA, Me.NOTAS})
        Me.dgvProgVacs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProgVacs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvProgVacs.Location = New System.Drawing.Point(0, 0)
        Me.dgvProgVacs.MultiSelect = False
        Me.dgvProgVacs.Name = "dgvProgVacs"
        Me.dgvProgVacs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvProgVacs.Size = New System.Drawing.Size(727, 488)
        Me.dgvProgVacs.TabIndex = 117
        '
        'Ok
        '
        Me.Ok.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.Ok.CheckBoxImageIndeterminate = Global.PIDA.My.Resources.Resources.CancelX
        Me.Ok.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.CancelX
        Me.Ok.Checked = True
        Me.Ok.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ok.CheckValue = "N"
        Me.Ok.CheckValueChecked = "1"
        Me.Ok.CheckValueIndeterminate = ""
        Me.Ok.CheckValueUnchecked = "0"
        Me.Ok.DataPropertyName = "INCLUIR"
        Me.Ok.HeaderText = "APLICAR"
        Me.Ok.Name = "Ok"
        Me.Ok.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Ok.ThreeState = True
        Me.Ok.Width = 55
        '
        'RELOJ
        '
        Me.RELOJ.DataPropertyName = "RELOJ"
        Me.RELOJ.HeaderText = "RELOJ"
        Me.RELOJ.Name = "RELOJ"
        Me.RELOJ.Width = 50
        '
        'nombre
        '
        Me.nombre.DataPropertyName = "nombre"
        Me.nombre.HeaderText = "NOMBRE"
        Me.nombre.Name = "nombre"
        Me.nombre.Width = 200
        '
        'FECHA
        '
        Me.FECHA.DataPropertyName = "FECHA"
        Me.FECHA.HeaderText = "FECHA"
        Me.FECHA.Name = "FECHA"
        Me.FECHA.Width = 75
        '
        'NOTAS
        '
        Me.NOTAS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NOTAS.DataPropertyName = "NOTAS"
        Me.NOTAS.HeaderText = "NOTAS"
        Me.NOTAS.Name = "NOTAS"
        '
        'frmProgVacs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(727, 611)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProgVacs"
        Me.Text = "Planeación de vacaciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.dgvProgVacs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents dgvProgVacs As System.Windows.Forms.DataGridView
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAplicar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Ok As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents RELOJ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOTAS As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
