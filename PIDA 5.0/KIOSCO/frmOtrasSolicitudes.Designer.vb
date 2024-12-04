<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOtrasSolicitudes
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOtrasSolicitudes))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.gpReportes = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbPlanta = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.dgSolicitudes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RELOJ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SOLICITUD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_SOL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_REV = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONFIRMADO = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.COSTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EXPORTADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkTodas = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ImprimirGafeteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox2.SuspendLayout()
        Me.gpReportes.SuspendLayout()
        CType(Me.dgSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btnReporte)
        Me.GroupBox2.Controls.Add(Me.btnBuscar)
        Me.GroupBox2.Controls.Add(Me.btnBorrar)
        Me.GroupBox2.Controls.Add(Me.btnNuevo)
        Me.GroupBox2.Controls.Add(Me.btnCancelar)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 473)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(718, 47)
        Me.GroupBox2.TabIndex = 130
        Me.GroupBox2.TabStop = False
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnReporte.Location = New System.Drawing.Point(439, 16)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(87, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 40
        Me.btnReporte.Text = "Reporte"
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBuscar.Location = New System.Drawing.Point(177, 16)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(87, 25)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Visible = False
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = Global.PIDA.My.Resources.Resources.Delete
        Me.btnBorrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBorrar.Location = New System.Drawing.Point(532, 16)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(87, 25)
        Me.btnBorrar.TabIndex = 4
        Me.btnBorrar.Text = "&Borrar"
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnNuevo.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnNuevo.Location = New System.Drawing.Point(345, 16)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(87, 25)
        Me.btnNuevo.TabIndex = 3
        Me.btnNuevo.Text = "&Confirmar "
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCancelar.Location = New System.Drawing.Point(625, 16)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(87, 25)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "&Salir"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(45, 7)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(602, 40)
        Me.ReflectionLabel1.TabIndex = 128
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>SOLICITUDES MISCELANEAS</b></font>"
        '
        'gpReportes
        '
        Me.gpReportes.BackColor = System.Drawing.Color.Transparent
        Me.gpReportes.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpReportes.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpReportes.Controls.Add(Me.Label1)
        Me.gpReportes.Controls.Add(Me.cmbPlanta)
        Me.gpReportes.Controls.Add(Me.dgSolicitudes)
        Me.gpReportes.Controls.Add(Me.chkTodas)
        Me.gpReportes.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpReportes.Location = New System.Drawing.Point(12, 59)
        Me.gpReportes.Name = "gpReportes"
        Me.gpReportes.Size = New System.Drawing.Size(728, 407)
        '
        '
        '
        Me.gpReportes.Style.BackColor = System.Drawing.Color.White
        Me.gpReportes.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpReportes.Style.BackColorGradientAngle = 90
        Me.gpReportes.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpReportes.Style.BorderBottomWidth = 1
        Me.gpReportes.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpReportes.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpReportes.Style.BorderLeftWidth = 1
        Me.gpReportes.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpReportes.Style.BorderRightWidth = 1
        Me.gpReportes.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpReportes.Style.BorderTopWidth = 1
        Me.gpReportes.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpReportes.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpReportes.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpReportes.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.gpReportes.Style.TextShadowColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.gpReportes.Style.TextShadowOffset = New System.Drawing.Point(1, 1)
        '
        '
        '
        Me.gpReportes.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpReportes.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpReportes.TabIndex = 127
        Me.gpReportes.Text = "Solicitudes"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(469, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Planta"
        '
        'cmbPlanta
        '
        Me.cmbPlanta.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbPlanta.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbPlanta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbPlanta.ButtonDropDown.Visible = True
        Me.cmbPlanta.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbPlanta.Location = New System.Drawing.Point(514, 6)
        Me.cmbPlanta.Name = "cmbPlanta"
        Me.cmbPlanta.Size = New System.Drawing.Size(204, 23)
        Me.cmbPlanta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPlanta.TabIndex = 2
        '
        'dgSolicitudes
        '
        Me.dgSolicitudes.AllowUserToAddRows = False
        Me.dgSolicitudes.AllowUserToDeleteRows = False
        Me.dgSolicitudes.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgSolicitudes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSolicitudes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSolicitudes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.RELOJ, Me.SOLICITUD, Me.FECHA_SOL, Me.FECHA_REV, Me.CONFIRMADO, Me.COSTO, Me.EXPORTADO})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSolicitudes.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgSolicitudes.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.dgSolicitudes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgSolicitudes.EnableHeadersVisualStyles = False
        Me.dgSolicitudes.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgSolicitudes.Location = New System.Drawing.Point(0, 35)
        Me.dgSolicitudes.MultiSelect = False
        Me.dgSolicitudes.Name = "dgSolicitudes"
        Me.dgSolicitudes.PaintEnhancedSelection = False
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSolicitudes.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgSolicitudes.RowHeadersVisible = False
        Me.dgSolicitudes.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.dgSolicitudes.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgSolicitudes.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSolicitudes.Size = New System.Drawing.Size(718, 338)
        Me.dgSolicitudes.StandardTab = True
        Me.dgSolicitudes.TabIndex = 1
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ID.DefaultCellStyle = DataGridViewCellStyle3
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Visible = False
        '
        'RELOJ
        '
        Me.RELOJ.DataPropertyName = "RELOJ"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.NullValue = " "
        Me.RELOJ.DefaultCellStyle = DataGridViewCellStyle4
        Me.RELOJ.HeaderText = "RELOJ"
        Me.RELOJ.Name = "RELOJ"
        Me.RELOJ.ReadOnly = True
        Me.RELOJ.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'SOLICITUD
        '
        Me.SOLICITUD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.SOLICITUD.DataPropertyName = "SOLICITUD"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.SOLICITUD.DefaultCellStyle = DataGridViewCellStyle5
        Me.SOLICITUD.HeaderText = "SOLICITUD"
        Me.SOLICITUD.Name = "SOLICITUD"
        Me.SOLICITUD.ReadOnly = True
        Me.SOLICITUD.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'FECHA_SOL
        '
        Me.FECHA_SOL.DataPropertyName = "FECHA_SOL"
        Me.FECHA_SOL.HeaderText = "FECHA DE SOLICITUD"
        Me.FECHA_SOL.Name = "FECHA_SOL"
        Me.FECHA_SOL.ReadOnly = True
        Me.FECHA_SOL.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'FECHA_REV
        '
        Me.FECHA_REV.DataPropertyName = "FECHA_REV"
        Me.FECHA_REV.HeaderText = "FECHA DE REVISION"
        Me.FECHA_REV.Name = "FECHA_REV"
        Me.FECHA_REV.ReadOnly = True
        Me.FECHA_REV.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'CONFIRMADO
        '
        Me.CONFIRMADO.Checked = True
        Me.CONFIRMADO.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.CONFIRMADO.CheckValue = "N"
        Me.CONFIRMADO.CheckValueChecked = "1"
        Me.CONFIRMADO.CheckValueUnchecked = "0"
        Me.CONFIRMADO.DataPropertyName = "CONFIRMADO"
        Me.CONFIRMADO.HeaderText = "CONFIRMADO"
        Me.CONFIRMADO.Name = "CONFIRMADO"
        Me.CONFIRMADO.ReadOnly = True
        Me.CONFIRMADO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CONFIRMADO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'COSTO
        '
        Me.COSTO.DataPropertyName = "CANTIDAD"
        Me.COSTO.HeaderText = "COSTO"
        Me.COSTO.Name = "COSTO"
        '
        'EXPORTADO
        '
        Me.EXPORTADO.DataPropertyName = "EXPORTADO"
        Me.EXPORTADO.HeaderText = "EXPORTADO"
        Me.EXPORTADO.Name = "EXPORTADO"
        Me.EXPORTADO.Visible = False
        '
        'chkTodas
        '
        Me.chkTodas.AutoSize = True
        '
        '
        '
        Me.chkTodas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkTodas.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkTodas.Location = New System.Drawing.Point(3, 10)
        Me.chkTodas.Name = "chkTodas"
        Me.chkTodas.Size = New System.Drawing.Size(123, 15)
        Me.chkTodas.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkTodas.TabIndex = 0
        Me.chkTodas.Text = "Mostrar confirmados"
        Me.chkTodas.TextColor = System.Drawing.SystemColors.ControlText
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirGafeteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(157, 26)
        '
        'ImprimirGafeteToolStripMenuItem
        '
        Me.ImprimirGafeteToolStripMenuItem.Name = "ImprimirGafeteToolStripMenuItem"
        Me.ImprimirGafeteToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.ImprimirGafeteToolStripMenuItem.Text = "Imprimir gafete"
        '
        'frmOtrasSolicitudes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 526)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.gpReportes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOtrasSolicitudes"
        Me.Text = "Solicitudes misceláneas"
        Me.GroupBox2.ResumeLayout(False)
        Me.gpReportes.ResumeLayout(False)
        Me.gpReportes.PerformLayout()
        CType(Me.dgSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Private WithEvents gpReportes As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents dgSolicitudes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents chkTodas As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RELOJ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SOLICITUD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_SOL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_REV As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CONFIRMADO As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents COSTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EXPORTADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ImprimirGafeteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbPlanta As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
