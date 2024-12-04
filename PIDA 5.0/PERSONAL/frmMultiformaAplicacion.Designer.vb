<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMultiformaAplicacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMultiformaAplicacion))
        Me.pbAplicar = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.btnMostrarInformacion = New DevComponents.DotNetBar.ButtonX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EmpNav = New System.Windows.Forms.GroupBox()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnParametros = New DevComponents.DotNetBar.ButtonX()
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.Node1 = New DevComponents.AdvTree.Node()
        Me.Node2 = New DevComponents.AdvTree.Node()
        Me.Node3 = New DevComponents.AdvTree.Node()
        Me.dgMovimientos = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.INC = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.REL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MOV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.USU = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DET = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IMP = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Panel1.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EmpNav.SuspendLayout()
        CType(Me.dgMovimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbAplicar
        '
        '
        '
        '
        Me.pbAplicar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pbAplicar.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.pbAplicar.BackgroundStyle.TextColor = System.Drawing.SystemColors.WindowText
        Me.pbAplicar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbAplicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbAplicar.Location = New System.Drawing.Point(0, 79)
        Me.pbAplicar.Name = "pbAplicar"
        Me.pbAplicar.Size = New System.Drawing.Size(1148, 23)
        Me.pbAplicar.TabIndex = 114
        Me.pbAplicar.Text = "Aplicar"
        Me.pbAplicar.TextVisible = True
        Me.pbAplicar.Value = 20
        Me.pbAplicar.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.picImagen)
        Me.Panel1.Controls.Add(Me.btnMostrarInformacion)
        Me.Panel1.Controls.Add(Me.ReflectionLabel1)
        Me.Panel1.Controls.Add(Me.pbAplicar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1148, 102)
        Me.Panel1.TabIndex = 118
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.ModificacionesSueldo24
        Me.picImagen.Location = New System.Drawing.Point(12, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(27, 26)
        Me.picImagen.TabIndex = 110
        Me.picImagen.TabStop = False
        '
        'btnMostrarInformacion
        '
        Me.btnMostrarInformacion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnMostrarInformacion.CausesValidation = False
        Me.btnMostrarInformacion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnMostrarInformacion.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnMostrarInformacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMostrarInformacion.Image = Global.PIDA.My.Resources.Resources.refresh16
        Me.btnMostrarInformacion.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnMostrarInformacion.Location = New System.Drawing.Point(1111, 0)
        Me.btnMostrarInformacion.Name = "btnMostrarInformacion"
        Me.btnMostrarInformacion.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(20)
        Me.btnMostrarInformacion.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5)
        Me.btnMostrarInformacion.Size = New System.Drawing.Size(37, 79)
        Me.btnMostrarInformacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnMostrarInformacion.TabIndex = 2
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(45, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(680, 40)
        Me.ReflectionLabel1.TabIndex = 109
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>APLICACION DE MULTIFORMA</b></font>"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkRed
        Me.Label1.Location = New System.Drawing.Point(9, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(612, 13)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "Los cambios seleccionados solo se reflejarán en el archivo de empleados una vez q" & _
    "ue se hayan aplicado. "
        '
        'EmpNav
        '
        Me.EmpNav.Controls.Add(Me.ButtonX1)
        Me.EmpNav.Controls.Add(Me.btnCerrar)
        Me.EmpNav.Controls.Add(Me.btnReporte)
        Me.EmpNav.Controls.Add(Me.btnBorrar)
        Me.EmpNav.Controls.Add(Me.btnParametros)
        Me.EmpNav.Controls.Add(Me.btnEditar)
        Me.EmpNav.Controls.Add(Me.btnNuevo)
        Me.EmpNav.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.EmpNav.Location = New System.Drawing.Point(0, 394)
        Me.EmpNav.Name = "EmpNav"
        Me.EmpNav.Padding = New System.Windows.Forms.Padding(0)
        Me.EmpNav.Size = New System.Drawing.Size(1148, 42)
        Me.EmpNav.TabIndex = 117
        Me.EmpNav.TabStop = False
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.CausesValidation = False
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX1.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.ButtonX1.Location = New System.Drawing.Point(276, 11)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(162, 25)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 59
        Me.ButtonX1.Text = "Aplicar selección"
        Me.ButtonX1.Tooltip = "Buscar"
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
        Me.btnCerrar.Location = New System.Drawing.Point(780, 11)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 58
        Me.btnCerrar.Text = "Salir"
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnReporte.Location = New System.Drawing.Point(444, 11)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 57
        Me.btnReporte.Text = "Reporte"
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = Global.PIDA.My.Resources.Resources.DeleteRec
        Me.btnBorrar.Location = New System.Drawing.Point(696, 11)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(78, 25)
        Me.btnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBorrar.TabIndex = 56
        Me.btnBorrar.Text = "Borrar"
        '
        'btnParametros
        '
        Me.btnParametros.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnParametros.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnParametros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnParametros.Image = Global.PIDA.My.Resources.Resources.CambiosMasivos16
        Me.btnParametros.Location = New System.Drawing.Point(3, 11)
        Me.btnParametros.Name = "btnParametros"
        Me.btnParametros.Size = New System.Drawing.Size(110, 25)
        Me.btnParametros.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnParametros.TabIndex = 26
        Me.btnParametros.Text = "Agregar grupo"
        Me.btnParametros.Visible = False
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = Global.PIDA.My.Resources.Resources.Edit
        Me.btnEditar.Location = New System.Drawing.Point(612, 11)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(78, 25)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 53
        Me.btnEditar.Text = "Editar"
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.NewRecord
        Me.btnNuevo.Location = New System.Drawing.Point(528, 11)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 25)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 52
        Me.btnNuevo.Text = "Agregar"
        '
        'Node1
        '
        Me.Node1.CheckBoxVisible = True
        Me.Node1.Checked = True
        Me.Node1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Node1.Expanded = True
        Me.Node1.Name = "Node1"
        Me.Node1.Text = "Node1"
        '
        'Node2
        '
        Me.Node2.CheckBoxVisible = True
        Me.Node2.Checked = True
        Me.Node2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Node2.Expanded = True
        Me.Node2.Name = "Node2"
        Me.Node2.Text = "Node1"
        '
        'Node3
        '
        Me.Node3.CheckBoxVisible = True
        Me.Node3.Checked = True
        Me.Node3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.Node3.Expanded = True
        Me.Node3.Name = "Node3"
        Me.Node3.Text = "Node1"
        '
        'dgMovimientos
        '
        Me.dgMovimientos.AllowUserToAddRows = False
        Me.dgMovimientos.AllowUserToDeleteRows = False
        Me.dgMovimientos.AllowUserToResizeRows = False
        Me.dgMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMovimientos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.INC, Me.REL, Me.NOM, Me.MOV, Me.USU, Me.DET, Me.COM, Me.IMP})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgMovimientos.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgMovimientos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgMovimientos.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgMovimientos.Location = New System.Drawing.Point(0, 102)
        Me.dgMovimientos.Name = "dgMovimientos"
        Me.dgMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgMovimientos.Size = New System.Drawing.Size(1148, 292)
        Me.dgMovimientos.TabIndex = 120
        '
        'INC
        '
        Me.INC.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top
        Me.INC.Checked = True
        Me.INC.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.INC.CheckValue = Nothing
        Me.INC.CheckValueChecked = "1"
        Me.INC.CheckValueIndeterminate = ""
        Me.INC.CheckValueUnchecked = "0"
        Me.INC.HeaderText = "OK"
        Me.INC.Name = "INC"
        Me.INC.Width = 25
        '
        'REL
        '
        Me.REL.DataPropertyName = "RELOJ"
        Me.REL.HeaderText = "RELOJ"
        Me.REL.Name = "REL"
        Me.REL.ReadOnly = True
        Me.REL.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.REL.Width = 80
        '
        'NOM
        '
        Me.NOM.DataPropertyName = "NOMBRE"
        Me.NOM.HeaderText = "NOMBRE"
        Me.NOM.Name = "NOM"
        Me.NOM.ReadOnly = True
        Me.NOM.Width = 150
        '
        'MOV
        '
        Me.MOV.DataPropertyName = "TIPO_MOVIMIENTO"
        Me.MOV.HeaderText = "TIPO MOV."
        Me.MOV.Name = "MOV"
        Me.MOV.ReadOnly = True
        '
        'USU
        '
        Me.USU.DataPropertyName = "USUARIO"
        Me.USU.HeaderText = "USUARIO"
        Me.USU.Name = "USU"
        Me.USU.ReadOnly = True
        Me.USU.Width = 80
        '
        'DET
        '
        Me.DET.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DET.DataPropertyName = "DETALLE"
        Me.DET.HeaderText = "DETALLES"
        Me.DET.Name = "DET"
        Me.DET.ReadOnly = True
        '
        'COM
        '
        Me.COM.DataPropertyName = "COMENTARIO"
        Me.COM.HeaderText = "COMENTARIO"
        Me.COM.Name = "COM"
        Me.COM.ReadOnly = True
        Me.COM.Width = 180
        '
        'IMP
        '
        Me.IMP.DataPropertyName = "IMPRESO"
        Me.IMP.FalseValue = "0"
        Me.IMP.HeaderText = "IMPRESO"
        Me.IMP.IndeterminateValue = "null"
        Me.IMP.Name = "IMP"
        Me.IMP.ReadOnly = True
        Me.IMP.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IMP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.IMP.TrueValue = "1"
        Me.IMP.Width = 60
        '
        'frmMultiformaAplicacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1148, 436)
        Me.Controls.Add(Me.dgMovimientos)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.EmpNav)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMultiformaAplicacion"
        Me.Text = "Aplicación de multiforma"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EmpNav.ResumeLayout(False)
        CType(Me.dgMovimientos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbAplicar As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents btnMostrarInformacion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EmpNav As System.Windows.Forms.GroupBox
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnParametros As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Node1 As DevComponents.AdvTree.Node
    Friend WithEvents Node2 As DevComponents.AdvTree.Node
    Friend WithEvents Node3 As DevComponents.AdvTree.Node
    Friend WithEvents dgMovimientos As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents INC As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents REL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents USU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DET As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IMP As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
