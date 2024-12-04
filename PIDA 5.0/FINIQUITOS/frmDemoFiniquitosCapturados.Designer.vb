<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDemoFiniquitosCapturados
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDemoFiniquitosCapturados))
        Me.pnlContenedorPrincipal = New System.Windows.Forms.Panel()
        Me.pnlContenedorSecundario = New System.Windows.Forms.Panel()
        Me.pnlGrid = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.sdgFiniquitos = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.GridColSel = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColStatus = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColFolio = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColReloj = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColNombre = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColFiniquito = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColNeto = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColAno = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColPeriodo = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridTipoPeriodo = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.pnlFiltros = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.swExportacion = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.pnlCheckFiltro = New System.Windows.Forms.Panel()
        Me.chkExportados = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.ReflectionLabel2 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.pnlControles = New System.Windows.Forms.Panel()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnExportaNomina = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnLimpiar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.sfd = New System.Windows.Forms.SaveFileDialog()
        Me.pnlContenedorPrincipal.SuspendLayout()
        Me.pnlContenedorSecundario.SuspendLayout()
        Me.pnlGrid.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlFiltros.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.pnlCheckFiltro.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlControles.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContenedorPrincipal
        '
        Me.pnlContenedorPrincipal.Controls.Add(Me.pnlContenedorSecundario)
        Me.pnlContenedorPrincipal.Controls.Add(Me.pnlControles)
        Me.pnlContenedorPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedorPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedorPrincipal.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlContenedorPrincipal.Name = "pnlContenedorPrincipal"
        Me.pnlContenedorPrincipal.Size = New System.Drawing.Size(1525, 642)
        Me.pnlContenedorPrincipal.TabIndex = 2
        '
        'pnlContenedorSecundario
        '
        Me.pnlContenedorSecundario.Controls.Add(Me.pnlGrid)
        Me.pnlContenedorSecundario.Controls.Add(Me.pnlTitulo)
        Me.pnlContenedorSecundario.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContenedorSecundario.Location = New System.Drawing.Point(0, 0)
        Me.pnlContenedorSecundario.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlContenedorSecundario.Name = "pnlContenedorSecundario"
        Me.pnlContenedorSecundario.Size = New System.Drawing.Size(1525, 585)
        Me.pnlContenedorSecundario.TabIndex = 2
        '
        'pnlGrid
        '
        Me.pnlGrid.Controls.Add(Me.Panel1)
        Me.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGrid.Location = New System.Drawing.Point(0, 68)
        Me.pnlGrid.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(1525, 517)
        Me.pnlGrid.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.pnlFiltros)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1525, 517)
        Me.Panel1.TabIndex = 9
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.sdgFiniquitos)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 46)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1525, 471)
        Me.Panel2.TabIndex = 10
        '
        'sdgFiniquitos
        '
        Me.sdgFiniquitos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.sdgFiniquitos.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.sdgFiniquitos.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sdgFiniquitos.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.sdgFiniquitos.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.sdgFiniquitos.Location = New System.Drawing.Point(0, 0)
        Me.sdgFiniquitos.Margin = New System.Windows.Forms.Padding(4)
        Me.sdgFiniquitos.Name = "sdgFiniquitos"
        '
        '
        '
        Me.sdgFiniquitos.PrimaryGrid.AutoExpandSetGroup = True
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColSel)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColStatus)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColFolio)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColReloj)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColNombre)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColFiniquito)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColNeto)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColAno)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridColPeriodo)
        Me.sdgFiniquitos.PrimaryGrid.Columns.Add(Me.GridTipoPeriodo)
        Me.sdgFiniquitos.PrimaryGrid.ExpandButtonType = DevComponents.DotNetBar.SuperGrid.ExpandButtonType.Circle
        '
        '
        '
        Me.sdgFiniquitos.PrimaryGrid.Filter.ShowPanelFilterExpr = True
        Me.sdgFiniquitos.PrimaryGrid.Filter.Visible = True
        Me.sdgFiniquitos.PrimaryGrid.GridLines = DevComponents.DotNetBar.SuperGrid.GridLines.None
        Me.sdgFiniquitos.PrimaryGrid.GroupRowHeaderVisibility = DevComponents.DotNetBar.SuperGrid.RowHeaderVisibility.Always
        Me.sdgFiniquitos.PrimaryGrid.ShowCheckBox = False
        Me.sdgFiniquitos.PrimaryGrid.ShowRowHeaders = False
        Me.sdgFiniquitos.PrimaryGrid.ShowWhitespaceRowLines = False
        Me.sdgFiniquitos.PrimaryGrid.SortLevel = DevComponents.DotNetBar.SuperGrid.SortLevel.Expanded
        Me.sdgFiniquitos.Size = New System.Drawing.Size(1525, 471)
        Me.sdgFiniquitos.TabIndex = 8
        Me.sdgFiniquitos.Text = "Finiquitos"
        '
        'GridColSel
        '
        Me.GridColSel.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColSel.DataPropertyName = "seleccionado"
        Me.GridColSel.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl)
        Me.GridColSel.EnableHeaderMarkup = True
        Me.GridColSel.HeaderText = "Confirmar"
        Me.GridColSel.InfoImage = Global.PIDA.My.Resources.Resources._1472009258_FAQ1
        Me.GridColSel.MarkRowDirtyOnCellValueChange = False
        Me.GridColSel.Name = "ColSel"
        Me.GridColSel.ResizeMode = DevComponents.DotNetBar.SuperGrid.ColumnResizeMode.None
        Me.GridColSel.Width = 70
        '
        'GridColStatus
        '
        Me.GridColStatus.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColStatus.DataPropertyName = "estado"
        Me.GridColStatus.DefaultNewRowCellValue = ""
        Me.GridColStatus.FilterAutoScan = True
        Me.GridColStatus.HeaderText = "Estatus"
        Me.GridColStatus.Name = "ColStatus"
        Me.GridColStatus.ReadOnly = True
        '
        'GridColFolio
        '
        Me.GridColFolio.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColFolio.DataPropertyName = "Folio"
        Me.GridColFolio.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl)
        Me.GridColFolio.HeaderText = "Folio"
        Me.GridColFolio.Name = "ColFolio"
        Me.GridColFolio.ReadOnly = True
        '
        'GridColReloj
        '
        Me.GridColReloj.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColReloj.DataPropertyName = "Reloj"
        Me.GridColReloj.EnableGroupHeaderMarkup = True
        Me.GridColReloj.HeaderText = "Reloj"
        Me.GridColReloj.Name = "ColReloj"
        Me.GridColReloj.ReadOnly = True
        '
        'GridColNombre
        '
        Me.GridColNombre.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill
        Me.GridColNombre.DataPropertyName = "Nombres"
        Me.GridColNombre.HeaderText = "Nombre"
        Me.GridColNombre.Name = "ColNombre"
        Me.GridColNombre.ReadOnly = True
        Me.GridColNombre.Width = 500
        '
        'GridColFiniquito
        '
        Me.GridColFiniquito.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColFiniquito.DataPropertyName = "baja_fin"
        Me.GridColFiniquito.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDateTimeInputEditControl)
        Me.GridColFiniquito.HeaderText = "Fecha baja finiquito"
        Me.GridColFiniquito.Name = "ColFiniquito"
        Me.GridColFiniquito.ReadOnly = True
        Me.GridColFiniquito.Width = 120
        '
        'GridColNeto
        '
        Me.GridColNeto.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight
        Me.GridColNeto.DataPropertyName = "Neto"
        Me.GridColNeto.DefaultNewRowCellValue = ""
        Me.GridColNeto.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl)
        Me.GridColNeto.HeaderText = "Monto"
        Me.GridColNeto.Name = "ColNeto"
        Me.GridColNeto.ReadOnly = True
        '
        'GridColAno
        '
        Me.GridColAno.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColAno.DataPropertyName = "ano"
        Me.GridColAno.HeaderText = "Año de captura"
        Me.GridColAno.Name = "ColAno"
        Me.GridColAno.ReadOnly = True
        '
        'GridColPeriodo
        '
        Me.GridColPeriodo.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter
        Me.GridColPeriodo.DataPropertyName = "Periodo"
        Me.GridColPeriodo.HeaderText = "Periodo de captura"
        Me.GridColPeriodo.Name = "ColPerido"
        Me.GridColPeriodo.ReadOnly = True
        Me.GridColPeriodo.Width = 120
        '
        'GridTipoPeriodo
        '
        Me.GridTipoPeriodo.DataPropertyName = "tipo_periodo"
        Me.GridTipoPeriodo.HeaderText = "Tipo periodo"
        Me.GridTipoPeriodo.Name = "ColTipoPeriodo"
        Me.GridTipoPeriodo.ReadOnly = True
        '
        'pnlFiltros
        '
        Me.pnlFiltros.Controls.Add(Me.Panel4)
        Me.pnlFiltros.Controls.Add(Me.pnlCheckFiltro)
        Me.pnlFiltros.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFiltros.Location = New System.Drawing.Point(0, 0)
        Me.pnlFiltros.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlFiltros.Name = "pnlFiltros"
        Me.pnlFiltros.Size = New System.Drawing.Size(1525, 46)
        Me.pnlFiltros.TabIndex = 9
        Me.pnlFiltros.Visible = False
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.swExportacion)
        Me.Panel4.Controls.Add(Me.LabelX5)
        Me.Panel4.Location = New System.Drawing.Point(8, 5)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(331, 36)
        Me.Panel4.TabIndex = 291
        Me.Panel4.Visible = False
        '
        'swExportacion
        '
        '
        '
        '
        Me.swExportacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swExportacion.Location = New System.Drawing.Point(236, 5)
        Me.swExportacion.Margin = New System.Windows.Forms.Padding(4)
        Me.swExportacion.Name = "swExportacion"
        Me.swExportacion.OffBackColor = System.Drawing.Color.LightCoral
        Me.swExportacion.OffText = "NO"
        Me.swExportacion.OnBackColor = System.Drawing.Color.LightGreen
        Me.swExportacion.OnText = "SI"
        Me.swExportacion.Size = New System.Drawing.Size(88, 27)
        Me.swExportacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swExportacion.TabIndex = 288
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(8, 4)
        Me.LabelX5.Margin = New System.Windows.Forms.Padding(4)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(220, 28)
        Me.LabelX5.TabIndex = 287
        Me.LabelX5.Text = "Selección múltiple para exportar"
        '
        'pnlCheckFiltro
        '
        Me.pnlCheckFiltro.Controls.Add(Me.chkExportados)
        Me.pnlCheckFiltro.Location = New System.Drawing.Point(347, 5)
        Me.pnlCheckFiltro.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlCheckFiltro.Name = "pnlCheckFiltro"
        Me.pnlCheckFiltro.Size = New System.Drawing.Size(335, 36)
        Me.pnlCheckFiltro.TabIndex = 289
        Me.pnlCheckFiltro.Visible = False
        '
        'chkExportados
        '
        Me.chkExportados.AutoSize = True
        '
        '
        '
        Me.chkExportados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.chkExportados.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.chkExportados.Location = New System.Drawing.Point(9, 10)
        Me.chkExportados.Margin = New System.Windows.Forms.Padding(4)
        Me.chkExportados.Name = "chkExportados"
        Me.chkExportados.Size = New System.Drawing.Size(134, 17)
        Me.chkExportados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkExportados.TabIndex = 3
        Me.chkExportados.Text = "Mostrar exportados"
        Me.chkExportados.TextColor = System.Drawing.SystemColors.ControlText
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.picImagen)
        Me.pnlTitulo.Controls.Add(Me.ReflectionLabel2)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 0)
        Me.pnlTitulo.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(1525, 68)
        Me.pnlTitulo.TabIndex = 1
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.checklist_32
        Me.picImagen.Location = New System.Drawing.Point(16, 15)
        Me.picImagen.Margin = New System.Windows.Forms.Padding(4)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(36, 32)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picImagen.TabIndex = 250
        Me.picImagen.TabStop = False
        '
        'ReflectionLabel2
        '
        '
        '
        '
        Me.ReflectionLabel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel2.Location = New System.Drawing.Point(60, 16)
        Me.ReflectionLabel2.Margin = New System.Windows.Forms.Padding(4)
        Me.ReflectionLabel2.Name = "ReflectionLabel2"
        Me.ReflectionLabel2.Size = New System.Drawing.Size(500, 46)
        Me.ReflectionLabel2.TabIndex = 249
        Me.ReflectionLabel2.Text = "<font color=""#1F497D""><b>FINIQUITOS CAPTURADOS</b></font>"
        '
        'pnlControles
        '
        Me.pnlControles.Controls.Add(Me.pnlBotones)
        Me.pnlControles.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlControles.Location = New System.Drawing.Point(0, 585)
        Me.pnlControles.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlControles.Name = "pnlControles"
        Me.pnlControles.Size = New System.Drawing.Size(1525, 57)
        Me.pnlControles.TabIndex = 1
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.ButtonX1)
        Me.pnlBotones.Controls.Add(Me.btnReporte)
        Me.pnlBotones.Controls.Add(Me.btnExportaNomina)
        Me.pnlBotones.Controls.Add(Me.btnCerrar)
        Me.pnlBotones.Controls.Add(Me.btnLimpiar)
        Me.pnlBotones.Controls.Add(Me.btnAceptar)
        Me.pnlBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlBotones.Location = New System.Drawing.Point(767, 0)
        Me.pnlBotones.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(758, 57)
        Me.pnlBotones.TabIndex = 0
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.CausesValidation = False
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX1.Image = Global.PIDA.My.Resources.Resources.incidencias
        Me.ButtonX1.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.ButtonX1.Location = New System.Drawing.Point(611, 5)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(135, 37)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 285
        Me.ButtonX1.Text = "Finiquito especial"
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Printer16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnReporte.Location = New System.Drawing.Point(151, 5)
        Me.btnReporte.Margin = New System.Windows.Forms.Padding(4)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(104, 37)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 283
        Me.btnReporte.Text = "Reporte"
        '
        'btnExportaNomina
        '
        Me.btnExportaNomina.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnExportaNomina.CausesValidation = False
        Me.btnExportaNomina.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnExportaNomina.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportaNomina.Image = Global.PIDA.My.Resources.Resources.Export24
        Me.btnExportaNomina.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnExportaNomina.Location = New System.Drawing.Point(4, 5)
        Me.btnExportaNomina.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExportaNomina.Name = "btnExportaNomina"
        Me.btnExportaNomina.Size = New System.Drawing.Size(139, 37)
        Me.btnExportaNomina.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnExportaNomina.TabIndex = 282
        Me.btnExportaNomina.Text = "Exportar " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "para nómina"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(260, 5)
        Me.btnCerrar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(104, 37)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 43
        Me.btnCerrar.Text = "Salir"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLimpiar.CausesValidation = False
        Me.btnLimpiar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLimpiar.Enabled = False
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.Image = Global.PIDA.My.Resources.Resources.DeleteRec
        Me.btnLimpiar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnLimpiar.Location = New System.Drawing.Point(488, 5)
        Me.btnLimpiar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(116, 37)
        Me.btnLimpiar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLimpiar.TabIndex = 281
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.Visible = False
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.excel_16
        Me.btnAceptar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnAceptar.Location = New System.Drawing.Point(369, 5)
        Me.btnAceptar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(116, 37)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 280
        Me.btnAceptar.Text = "Exportar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Excel"
        Me.btnAceptar.Visible = False
        '
        'frmDemoFiniquitosCapturados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1525, 642)
        Me.Controls.Add(Me.pnlContenedorPrincipal)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDemoFiniquitosCapturados"
        Me.Text = "Finiquitos Capturados"
        Me.pnlContenedorPrincipal.ResumeLayout(False)
        Me.pnlContenedorSecundario.ResumeLayout(False)
        Me.pnlGrid.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.pnlFiltros.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.pnlCheckFiltro.ResumeLayout(False)
        Me.pnlCheckFiltro.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlControles.ResumeLayout(False)
        Me.pnlBotones.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlContenedorPrincipal As System.Windows.Forms.Panel
    Friend WithEvents pnlContenedorSecundario As System.Windows.Forms.Panel
    Friend WithEvents pnlGrid As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents sdgFiniquitos As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents GridColSel As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColStatus As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColFolio As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColReloj As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColNombre As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColFiniquito As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColNeto As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColAno As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColPeriodo As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridTipoPeriodo As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents pnlFiltros As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents swExportacion As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents pnlCheckFiltro As System.Windows.Forms.Panel
    Friend WithEvents chkExportados As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel2 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents pnlControles As System.Windows.Forms.Panel
    Friend WithEvents pnlBotones As System.Windows.Forms.Panel
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnExportaNomina As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnLimpiar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents sfd As System.Windows.Forms.SaveFileDialog
End Class
