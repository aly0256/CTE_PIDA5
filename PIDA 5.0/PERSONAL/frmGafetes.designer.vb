<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGafetes
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
        Me.colImprimir = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.pnlNavegacion = New System.Windows.Forms.Panel()
        Me.pnlCentrarControles = New System.Windows.Forms.Panel()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.ButtonItem2 = New DevComponents.DotNetBar.ButtonItem()
        Me.ButtonItem3 = New DevComponents.DotNetBar.ButtonItem()
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.pnlGrd = New System.Windows.Forms.Panel()
        Me.dgGafetes = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.colReloj = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colGafete = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colNombre = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colCompania = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colPlanta = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colNombrePlanta = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colTurno = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colNombreTurno = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colDepto = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colNombreDepto = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colSupervisor = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colNombreSupervisor = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.colTipoEmp = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.RadialMenuItem2 = New DevComponents.DotNetBar.RadialMenuItem()
        Me.RadialMenuItem3 = New DevComponents.DotNetBar.RadialMenuItem()
        Me.RadialMenuItem4 = New DevComponents.DotNetBar.RadialMenuItem()
        Me.pnlEncabezado.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNavegacion.SuspendLayout()
        Me.pnlCentrarControles.SuspendLayout()
        Me.pnlGrd.SuspendLayout()
        Me.SuspendLayout()
        '
        'colImprimir
        '
        Me.colImprimir.AllowNullCellMerge = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colImprimir.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.colImprimir.DataPropertyName = "imprimir"
        Me.colImprimir.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridSwitchButtonEditControl)
        Me.colImprimir.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colImprimir.FilterAutoScan = True
        Me.colImprimir.HeaderStyles.Default.Image = Global.PIDA.My.Resources.Resources.Printer16
        Me.colImprimir.HeaderStyles.Default.ImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleLeft
        Me.colImprimir.HeaderText = "Imprime"
        Me.colImprimir.InfoImageAlignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.NotSet
        Me.colImprimir.MarkRowDirtyOnCellValueChange = False
        Me.colImprimir.Name = "Imprimir"
        Me.colImprimir.NullString = "No"
        Me.colImprimir.RenderType = GetType(DevComponents.DotNetBar.SuperGrid.GridSwitchButtonEditControl)
        Me.colImprimir.Width = 80
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.Controls.Add(Me.ReflectionLabel1)
        Me.pnlEncabezado.Controls.Add(Me.picImagen)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Size = New System.Drawing.Size(1204, 63)
        Me.pnlEncabezado.TabIndex = 0
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
        Me.ReflectionLabel1.Size = New System.Drawing.Size(366, 40)
        Me.ReflectionLabel1.TabIndex = 97
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CONTROL DE GAFETES</b></font>"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.ID32
        Me.picImagen.Location = New System.Drawing.Point(12, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(27, 26)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picImagen.TabIndex = 98
        Me.picImagen.TabStop = False
        '
        'pnlNavegacion
        '
        Me.pnlNavegacion.Controls.Add(Me.pnlCentrarControles)
        Me.pnlNavegacion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlNavegacion.Location = New System.Drawing.Point(0, 417)
        Me.pnlNavegacion.Name = "pnlNavegacion"
        Me.pnlNavegacion.Size = New System.Drawing.Size(1204, 42)
        Me.pnlNavegacion.TabIndex = 1
        '
        'pnlCentrarControles
        '
        Me.pnlCentrarControles.Controls.Add(Me.btnBuscar)
        Me.pnlCentrarControles.Controls.Add(Me.btnReporte)
        Me.pnlCentrarControles.Controls.Add(Me.btnEditar)
        Me.pnlCentrarControles.Controls.Add(Me.btnNuevo)
        Me.pnlCentrarControles.Controls.Add(Me.btnCerrar)
        Me.pnlCentrarControles.Location = New System.Drawing.Point(397, 3)
        Me.pnlCentrarControles.Name = "pnlCentrarControles"
        Me.pnlCentrarControles.Size = New System.Drawing.Size(430, 32)
        Me.pnlCentrarControles.TabIndex = 3
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBuscar.Location = New System.Drawing.Point(3, 3)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(82, 27)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Tooltip = "Buscar"
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnReporte.Location = New System.Drawing.Point(88, 3)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(82, 27)
        Me.btnReporte.SplitButton = True
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItem2, Me.ButtonItem3})
        Me.btnReporte.TabIndex = 5
        Me.btnReporte.Text = "Imprimir"
        '
        'ButtonItem2
        '
        Me.ButtonItem2.GlobalItem = False
        Me.ButtonItem2.Image = Global.PIDA.My.Resources.Resources.Id16
        Me.ButtonItem2.Name = "ButtonItem2"
        Me.ButtonItem2.Text = "Gafete1"
        '
        'ButtonItem3
        '
        Me.ButtonItem3.GlobalItem = False
        Me.ButtonItem3.Name = "ButtonItem3"
        Me.ButtonItem3.Text = "Gafete2"
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = Global.PIDA.My.Resources.Resources.Edit
        Me.btnEditar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnEditar.Location = New System.Drawing.Point(258, 3)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(82, 27)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 6
        Me.btnEditar.Text = "Editar"
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.NewRecord
        Me.btnNuevo.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnNuevo.Location = New System.Drawing.Point(173, 3)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(82, 27)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 6
        Me.btnNuevo.Text = "Guardar"
        Me.btnNuevo.Visible = False
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(343, 3)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(82, 27)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 8
        Me.btnCerrar.Text = "Salir"
        '
        'pnlGrd
        '
        Me.pnlGrd.Controls.Add(Me.dgGafetes)
        Me.pnlGrd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGrd.Location = New System.Drawing.Point(0, 63)
        Me.pnlGrd.Name = "pnlGrd"
        Me.pnlGrd.Padding = New System.Windows.Forms.Padding(12)
        Me.pnlGrd.Size = New System.Drawing.Size(1204, 354)
        Me.pnlGrd.TabIndex = 2
        '
        'dgGafetes
        '
        Me.dgGafetes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgGafetes.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.dgGafetes.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.dgGafetes.Location = New System.Drawing.Point(12, 12)
        Me.dgGafetes.Name = "dgGafetes"
        '
        '
        '
        Me.dgGafetes.PrimaryGrid.AllowRowResize = True
        Me.dgGafetes.PrimaryGrid.Columns.Add(Me.colReloj)
        Me.dgGafetes.PrimaryGrid.Columns.Add(Me.colGafete)
        Me.dgGafetes.PrimaryGrid.Columns.Add(Me.colImprimir)
        Me.dgGafetes.PrimaryGrid.Columns.Add(Me.colNombre)
        Me.dgGafetes.PrimaryGrid.Columns.Add(Me.colCompania)
        Me.dgGafetes.PrimaryGrid.Columns.Add(Me.colPlanta)
        Me.dgGafetes.PrimaryGrid.Columns.Add(Me.colNombrePlanta)
        Me.dgGafetes.PrimaryGrid.Columns.Add(Me.colTurno)
        Me.dgGafetes.PrimaryGrid.Columns.Add(Me.colNombreTurno)
        Me.dgGafetes.PrimaryGrid.Columns.Add(Me.colDepto)
        Me.dgGafetes.PrimaryGrid.Columns.Add(Me.colNombreDepto)
        Me.dgGafetes.PrimaryGrid.Columns.Add(Me.colSupervisor)
        Me.dgGafetes.PrimaryGrid.Columns.Add(Me.colNombreSupervisor)
        Me.dgGafetes.PrimaryGrid.Columns.Add(Me.colTipoEmp)
        Me.dgGafetes.PrimaryGrid.EnableFiltering = True
        '
        '
        '
        Me.dgGafetes.PrimaryGrid.Filter.ShowPanelFilterExpr = True
        Me.dgGafetes.PrimaryGrid.Filter.Visible = True
        Me.dgGafetes.PrimaryGrid.FrozenColumnCount = 3
        Me.dgGafetes.Size = New System.Drawing.Size(1180, 330)
        Me.dgGafetes.TabIndex = 0
        '
        'colReloj
        '
        Me.colReloj.AllowEdit = False
        Me.colReloj.DataPropertyName = "reloj"
        Me.colReloj.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colReloj.MarkRowDirtyOnCellValueChange = False
        Me.colReloj.Name = "Reloj"
        Me.colReloj.ReadOnly = True
        Me.colReloj.Width = 60
        '
        'colGafete
        '
        Me.colGafete.DataPropertyName = "gafete"
        Me.colGafete.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colGafete.Name = "Gafete"
        Me.colGafete.Width = 70
        '
        'colNombre
        '
        Me.colNombre.AllowEdit = False
        Me.colNombre.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill
        Me.colNombre.DataPropertyName = "nombres"
        Me.colNombre.MarkRowDirtyOnCellValueChange = False
        Me.colNombre.MinimumWidth = 200
        Me.colNombre.Name = "Nombre"
        Me.colNombre.ReadOnly = True
        '
        'colCompania
        '
        Me.colCompania.AllowEdit = False
        Me.colCompania.DataPropertyName = "cod_comp"
        Me.colCompania.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colCompania.FilterAutoScan = True
        Me.colCompania.MarkRowDirtyOnCellValueChange = False
        Me.colCompania.Name = "Compañía"
        Me.colCompania.ReadOnly = True
        Me.colCompania.Width = 80
        '
        'colPlanta
        '
        Me.colPlanta.AllowEdit = False
        Me.colPlanta.DataPropertyName = "cod_planta"
        Me.colPlanta.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colPlanta.FilterAutoScan = True
        Me.colPlanta.MarkRowDirtyOnCellValueChange = False
        Me.colPlanta.Name = "Planta"
        Me.colPlanta.ReadOnly = True
        Me.colPlanta.Width = 50
        '
        'colNombrePlanta
        '
        Me.colNombrePlanta.AllowEdit = False
        Me.colNombrePlanta.DataPropertyName = "nombre_planta"
        Me.colNombrePlanta.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colNombrePlanta.MarkRowDirtyOnCellValueChange = False
        Me.colNombrePlanta.Name = "Nombre planta"
        Me.colNombrePlanta.ReadOnly = True
        Me.colNombrePlanta.Width = 120
        '
        'colTurno
        '
        Me.colTurno.AllowEdit = False
        Me.colTurno.DataPropertyName = "cod_turno"
        Me.colTurno.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colTurno.FilterAutoScan = True
        Me.colTurno.MarkRowDirtyOnCellValueChange = False
        Me.colTurno.Name = "Turno"
        Me.colTurno.ReadOnly = True
        Me.colTurno.Width = 50
        '
        'colNombreTurno
        '
        Me.colNombreTurno.AllowEdit = False
        Me.colNombreTurno.DataPropertyName = "nombre_turno"
        Me.colNombreTurno.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colNombreTurno.MarkRowDirtyOnCellValueChange = False
        Me.colNombreTurno.Name = "Nombre turno"
        Me.colNombreTurno.ReadOnly = True
        Me.colNombreTurno.Width = 120
        '
        'colDepto
        '
        Me.colDepto.AllowEdit = False
        Me.colDepto.DataPropertyName = "cod_depto"
        Me.colDepto.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colDepto.FilterAutoScan = True
        Me.colDepto.MarkRowDirtyOnCellValueChange = False
        Me.colDepto.Name = "Depto."
        Me.colDepto.ReadOnly = True
        Me.colDepto.Width = 50
        '
        'colNombreDepto
        '
        Me.colNombreDepto.AllowEdit = False
        Me.colNombreDepto.DataPropertyName = "nombre_depto"
        Me.colNombreDepto.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colNombreDepto.MarkRowDirtyOnCellValueChange = False
        Me.colNombreDepto.Name = "Nombre depto."
        Me.colNombreDepto.ReadOnly = True
        Me.colNombreDepto.Width = 120
        '
        'colSupervisor
        '
        Me.colSupervisor.AllowEdit = False
        Me.colSupervisor.DataPropertyName = "cod_super"
        Me.colSupervisor.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colSupervisor.FilterAutoScan = True
        Me.colSupervisor.MarkRowDirtyOnCellValueChange = False
        Me.colSupervisor.Name = "Sup."
        Me.colSupervisor.ReadOnly = True
        Me.colSupervisor.Width = 50
        '
        'colNombreSupervisor
        '
        Me.colNombreSupervisor.AllowEdit = False
        Me.colNombreSupervisor.DataPropertyName = "nombre_super"
        Me.colNombreSupervisor.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colNombreSupervisor.MarkRowDirtyOnCellValueChange = False
        Me.colNombreSupervisor.Name = "Nombre supervisor"
        Me.colNombreSupervisor.ReadOnly = True
        Me.colNombreSupervisor.Width = 120
        '
        'colTipoEmp
        '
        Me.colTipoEmp.AllowEdit = False
        Me.colTipoEmp.DataPropertyName = "cod_tipo"
        Me.colTipoEmp.EnableFiltering = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.colTipoEmp.FilterAutoScan = True
        Me.colTipoEmp.MarkRowDirtyOnCellValueChange = False
        Me.colTipoEmp.Name = "Tipo emp."
        Me.colTipoEmp.ReadOnly = True
        Me.colTipoEmp.Width = 65
        '
        'ButtonItem1
        '
        Me.ButtonItem1.GlobalItem = False
        Me.ButtonItem1.Name = "ButtonItem1"
        Me.ButtonItem1.Text = "ButtonItem1"
        '
        'RadialMenuItem2
        '
        Me.RadialMenuItem2.Name = "RadialMenuItem2"
        Me.RadialMenuItem2.Text = "Item 2"
        '
        'RadialMenuItem3
        '
        Me.RadialMenuItem3.Name = "RadialMenuItem3"
        Me.RadialMenuItem3.Text = "Item 2"
        '
        'RadialMenuItem4
        '
        Me.RadialMenuItem4.Name = "RadialMenuItem4"
        Me.RadialMenuItem4.Text = "Item 2"
        '
        'frmGafetes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1204, 459)
        Me.Controls.Add(Me.pnlGrd)
        Me.Controls.Add(Me.pnlNavegacion)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Name = "frmGafetes"
        Me.Text = "frmGafetes"
        Me.pnlEncabezado.ResumeLayout(False)
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNavegacion.ResumeLayout(False)
        Me.pnlCentrarControles.ResumeLayout(False)
        Me.pnlGrd.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents pnlNavegacion As System.Windows.Forms.Panel
    Friend WithEvents pnlGrd As System.Windows.Forms.Panel
    Friend WithEvents dgGafetes As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents colReloj As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents colGafete As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents colNombre As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents colDepto As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents colNombreSupervisor As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents colCompania As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents colPlanta As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents colNombrePlanta As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents colTurno As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents colNombreTurno As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents colNombreDepto As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents colSupervisor As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents colTipoEmp As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents pnlCentrarControles As System.Windows.Forms.Panel
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem2 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents ButtonItem3 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents RadialMenuItem2 As DevComponents.DotNetBar.RadialMenuItem
    Friend WithEvents RadialMenuItem3 As DevComponents.DotNetBar.RadialMenuItem
    Friend WithEvents RadialMenuItem4 As DevComponents.DotNetBar.RadialMenuItem
    Friend WithEvents colImprimir As DevComponents.DotNetBar.SuperGrid.GridColumn
End Class
