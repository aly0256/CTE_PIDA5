<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExcepcionHorarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExcepcionHorarios))
        Me.pnlEncabezado = New System.Windows.Forms.Panel()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.btnMostrarInformacion = New DevComponents.DotNetBar.ButtonX()
        Me.colUnico = New DevComponents.AdvTree.ColumnHeader()
        Me.colAno = New DevComponents.AdvTree.ColumnHeader()
        Me.colPeriodo = New DevComponents.AdvTree.ColumnHeader()
        Me.EmpNav = New System.Windows.Forms.GroupBox()
        Me.labelTotalVista = New DevComponents.DotNetBar.LabelX()
        Me.pnlCentrado = New System.Windows.Forms.Panel()
        Me.btnGlobal = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnParametros = New DevComponents.DotNetBar.ButtonX()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgExcepcionHorarios = New DevComponents.DotNetBar.SuperGrid.SuperGridControl()
        Me.GridColumn7 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn8 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn9 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn10 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn11 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn12 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.pnlEditar = New System.Windows.Forms.Panel()
        Me.prgEditar = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.lblAvance = New System.Windows.Forms.Label()
        Me.LayoutGroup1 = New DevComponents.DotNetBar.Layout.LayoutGroup()
        Me.LayoutControlItem4 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevComponents.DotNetBar.Layout.LayoutControlItem()
        Me.SuperTooltip1 = New DevComponents.DotNetBar.SuperTooltip()
        Me.GridColumn6 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn5 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn4 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn3 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn2 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.GridColumn1 = New DevComponents.DotNetBar.SuperGrid.GridColumn()
        Me.pnlEncabezado.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EmpNav.SuspendLayout()
        Me.pnlCentrado.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnlEditar.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlEncabezado
        '
        Me.pnlEncabezado.Controls.Add(Me.pnlTitulo)
        Me.pnlEncabezado.Controls.Add(Me.btnMostrarInformacion)
        Me.pnlEncabezado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnlEncabezado.Name = "pnlEncabezado"
        Me.pnlEncabezado.Padding = New System.Windows.Forms.Padding(3)
        Me.pnlEncabezado.Size = New System.Drawing.Size(1029, 78)
        Me.pnlEncabezado.TabIndex = 118
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.ReflectionLabel1)
        Me.pnlTitulo.Controls.Add(Me.picImagen)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTitulo.Location = New System.Drawing.Point(3, 3)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(559, 72)
        Me.pnlTitulo.TabIndex = 122
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(50, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(494, 40)
        Me.ReflectionLabel1.TabIndex = 109
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>EXCEPCIÓN HORARIOS POR EMPLEADO</b></font>"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.Horario24
        Me.picImagen.Location = New System.Drawing.Point(12, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(24, 24)
        Me.picImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picImagen.TabIndex = 110
        Me.picImagen.TabStop = False
        '
        'btnMostrarInformacion
        '
        Me.btnMostrarInformacion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnMostrarInformacion.CausesValidation = False
        Me.btnMostrarInformacion.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
        Me.btnMostrarInformacion.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnMostrarInformacion.FocusCuesEnabled = False
        Me.btnMostrarInformacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMostrarInformacion.Image = Global.PIDA.My.Resources.Resources.refresh16
        Me.btnMostrarInformacion.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnMostrarInformacion.Location = New System.Drawing.Point(995, 3)
        Me.btnMostrarInformacion.Name = "btnMostrarInformacion"
        Me.btnMostrarInformacion.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5)
        Me.btnMostrarInformacion.Size = New System.Drawing.Size(31, 72)
        Me.btnMostrarInformacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnMostrarInformacion.TabIndex = 125
        '
        'colUnico
        '
        Me.colUnico.DataFieldName = "unico"
        Me.colUnico.Name = "colUnico"
        Me.colUnico.Text = "Column"
        Me.colUnico.Visible = False
        Me.colUnico.Width.Absolute = 150
        '
        'colAno
        '
        Me.colAno.ColumnName = "colAno"
        Me.colAno.DataFieldName = "ano"
        Me.colAno.Name = "colAno"
        Me.colAno.Text = "AÑO"
        Me.colAno.Width.AutoSize = True
        Me.colAno.Width.Relative = 50
        '
        'colPeriodo
        '
        Me.colPeriodo.ColumnName = "colPeriodo"
        Me.colPeriodo.DataFieldName = "periodo"
        Me.colPeriodo.Name = "colPeriodo"
        Me.colPeriodo.StretchToFill = True
        Me.colPeriodo.Text = "PERIODO"
        Me.colPeriodo.Width.Relative = 50
        '
        'EmpNav
        '
        Me.EmpNav.Controls.Add(Me.labelTotalVista)
        Me.EmpNav.Controls.Add(Me.pnlCentrado)
        Me.EmpNav.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.EmpNav.Location = New System.Drawing.Point(0, 446)
        Me.EmpNav.Name = "EmpNav"
        Me.EmpNav.Padding = New System.Windows.Forms.Padding(0)
        Me.EmpNav.Size = New System.Drawing.Size(1029, 42)
        Me.EmpNav.TabIndex = 117
        Me.EmpNav.TabStop = False
        '
        'labelTotalVista
        '
        Me.labelTotalVista.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.labelTotalVista.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.labelTotalVista.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelTotalVista.Location = New System.Drawing.Point(873, 10)
        Me.labelTotalVista.Name = "labelTotalVista"
        Me.labelTotalVista.Size = New System.Drawing.Size(153, 23)
        Me.labelTotalVista.TabIndex = 125
        Me.labelTotalVista.Text = "TOTAL: N EMPLEADOS"
        '
        'pnlCentrado
        '
        Me.pnlCentrado.Controls.Add(Me.btnGlobal)
        Me.pnlCentrado.Controls.Add(Me.btnReporte)
        Me.pnlCentrado.Controls.Add(Me.btnCerrar)
        Me.pnlCentrado.Controls.Add(Me.btnNuevo)
        Me.pnlCentrado.Controls.Add(Me.btnEditar)
        Me.pnlCentrado.Controls.Add(Me.btnBorrar)
        Me.pnlCentrado.Controls.Add(Me.btnParametros)
        Me.pnlCentrado.Location = New System.Drawing.Point(153, 6)
        Me.pnlCentrado.Name = "pnlCentrado"
        Me.pnlCentrado.Size = New System.Drawing.Size(705, 30)
        Me.pnlCentrado.TabIndex = 59
        '
        'btnGlobal
        '
        Me.btnGlobal.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGlobal.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGlobal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGlobal.Image = Global.PIDA.My.Resources.Resources.All16
        Me.btnGlobal.Location = New System.Drawing.Point(121, 2)
        Me.btnGlobal.Name = "btnGlobal"
        Me.btnGlobal.Size = New System.Drawing.Size(131, 25)
        Me.btnGlobal.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnGlobal.TabIndex = 59
        Me.btnGlobal.Text = "Autorización global"
        Me.btnGlobal.Visible = False
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnReporte.Location = New System.Drawing.Point(279, 2)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 57
        Me.btnReporte.Text = "Reporte"
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
        Me.btnCerrar.Location = New System.Drawing.Point(623, 2)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 58
        Me.btnCerrar.Text = "Salir"
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.NewRecord
        Me.btnNuevo.Location = New System.Drawing.Point(365, 2)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 25)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 52
        Me.btnNuevo.Text = "Agregar"
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = Global.PIDA.My.Resources.Resources.Edit
        Me.btnEditar.Location = New System.Drawing.Point(451, 2)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(78, 25)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 53
        Me.btnEditar.Text = "Editar"
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = Global.PIDA.My.Resources.Resources.DeleteRec
        Me.btnBorrar.Location = New System.Drawing.Point(535, 2)
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
        Me.btnParametros.Location = New System.Drawing.Point(3, 2)
        Me.btnParametros.Name = "btnParametros"
        Me.btnParametros.Size = New System.Drawing.Size(110, 25)
        Me.btnParametros.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnParametros.TabIndex = 26
        Me.btnParametros.Text = "Agregar grupo"
        Me.btnParametros.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgExcepcionHorarios)
        Me.Panel2.Controls.Add(Me.pnlEditar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 78)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1029, 368)
        Me.Panel2.TabIndex = 120
        '
        'dgExcepcionHorarios
        '
        Me.dgExcepcionHorarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgExcepcionHorarios.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed
        Me.dgExcepcionHorarios.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.dgExcepcionHorarios.Location = New System.Drawing.Point(0, 0)
        Me.dgExcepcionHorarios.Name = "dgExcepcionHorarios"
        '
        '
        '
        Me.dgExcepcionHorarios.PrimaryGrid.AutoGenerateColumns = False
        Me.dgExcepcionHorarios.PrimaryGrid.Columns.Add(Me.GridColumn7)
        Me.dgExcepcionHorarios.PrimaryGrid.Columns.Add(Me.GridColumn8)
        Me.dgExcepcionHorarios.PrimaryGrid.Columns.Add(Me.GridColumn9)
        Me.dgExcepcionHorarios.PrimaryGrid.Columns.Add(Me.GridColumn10)
        Me.dgExcepcionHorarios.PrimaryGrid.Columns.Add(Me.GridColumn11)
        Me.dgExcepcionHorarios.PrimaryGrid.Columns.Add(Me.GridColumn12)
        Me.dgExcepcionHorarios.PrimaryGrid.EnableFiltering = True
        '
        '
        '
        Me.dgExcepcionHorarios.PrimaryGrid.Filter.Visible = True
        Me.dgExcepcionHorarios.PrimaryGrid.InitialSelection = DevComponents.DotNetBar.SuperGrid.RelativeSelection.None
        Me.dgExcepcionHorarios.PrimaryGrid.MultiSelect = False
        Me.dgExcepcionHorarios.PrimaryGrid.ReadOnly = True
        Me.dgExcepcionHorarios.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.Row
        Me.dgExcepcionHorarios.Size = New System.Drawing.Size(1029, 368)
        Me.dgExcepcionHorarios.TabIndex = 126
        Me.dgExcepcionHorarios.Text = "Excepciones"
        '
        'GridColumn7
        '
        Me.GridColumn7.DataPropertyName = "reloj"
        Me.GridColumn7.HeaderText = "RELOJ"
        Me.GridColumn7.Name = "colReloj"
        Me.GridColumn7.Width = 70
        '
        'GridColumn8
        '
        Me.GridColumn8.DataPropertyName = "nombres"
        Me.GridColumn8.HeaderText = "NOMBRES"
        Me.GridColumn8.Name = "colNombre"
        Me.GridColumn8.Width = 200
        '
        'GridColumn9
        '
        Me.GridColumn9.DataPropertyName = "fecha"
        Me.GridColumn9.EditorType = GetType(DevComponents.DotNetBar.SuperGrid.GridDateTimePickerEditControl)
        Me.GridColumn9.HeaderText = "FECHA"
        Me.GridColumn9.Name = "colFecha"
        '
        'GridColumn10
        '
        Me.GridColumn10.DataPropertyName = "cod_hora"
        Me.GridColumn10.FilterAutoScan = True
        Me.GridColumn10.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn10.HeaderText = "HORARIO EXCEPCION"
        Me.GridColumn10.Name = "colHoraExcepcion"
        '
        'GridColumn11
        '
        Me.GridColumn11.DataPropertyName = "cod_hora_personal"
        Me.GridColumn11.FilterAutoScan = True
        Me.GridColumn11.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn11.HeaderText = "HORARIO PERSONAL"
        Me.GridColumn11.Name = "colHoraPersonal"
        '
        'GridColumn12
        '
        Me.GridColumn12.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill
        Me.GridColumn12.DataPropertyName = "comentario"
        Me.GridColumn12.HeaderText = "COMENTARIO"
        Me.GridColumn12.MinimumWidth = 50
        Me.GridColumn12.Name = "colComentario"
        '
        'pnlEditar
        '
        Me.pnlEditar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlEditar.Controls.Add(Me.prgEditar)
        Me.pnlEditar.Controls.Add(Me.lblAvance)
        Me.pnlEditar.Location = New System.Drawing.Point(452, 93)
        Me.pnlEditar.Name = "pnlEditar"
        Me.pnlEditar.Size = New System.Drawing.Size(242, 210)
        Me.pnlEditar.TabIndex = 123
        Me.pnlEditar.Visible = False
        '
        'prgEditar
        '
        Me.prgEditar.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        '
        '
        '
        Me.prgEditar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.prgEditar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.prgEditar.FocusCuesEnabled = False
        Me.prgEditar.Location = New System.Drawing.Point(0, 0)
        Me.prgEditar.Name = "prgEditar"
        Me.prgEditar.Padding = New System.Windows.Forms.Padding(5)
        Me.prgEditar.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Dot
        Me.prgEditar.ProgressTextFormat = ""
        Me.prgEditar.ProgressTextVisible = True
        Me.prgEditar.Size = New System.Drawing.Size(240, 177)
        Me.prgEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.prgEditar.TabIndex = 125
        '
        'lblAvance
        '
        Me.lblAvance.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.lblAvance.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblAvance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAvance.Location = New System.Drawing.Point(0, 177)
        Me.lblAvance.Name = "lblAvance"
        Me.lblAvance.Size = New System.Drawing.Size(240, 31)
        Me.lblAvance.TabIndex = 124
        Me.lblAvance.Text = "Cargando información"
        Me.lblAvance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LayoutGroup1
        '
        Me.LayoutGroup1.Height = 100
        Me.LayoutGroup1.MinSize = New System.Drawing.Size(120, 32)
        Me.LayoutGroup1.Name = "LayoutGroup1"
        Me.LayoutGroup1.TextPosition = DevComponents.DotNetBar.Layout.eLayoutPosition.Top
        Me.LayoutGroup1.Width = 200
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Height = 28
        Me.LayoutControlItem4.MinSize = New System.Drawing.Size(64, 18)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Text = "Label:"
        Me.LayoutControlItem4.Width = 95
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Height = 31
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(64, 18)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Text = "Label:"
        Me.LayoutControlItem1.Width = 93
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Height = 31
        Me.LayoutControlItem7.MinSize = New System.Drawing.Size(120, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Text = "Label:"
        Me.LayoutControlItem7.Width = 100
        Me.LayoutControlItem7.WidthType = DevComponents.DotNetBar.Layout.eLayoutSizeType.Percent
        '
        'SuperTooltip1
        '
        Me.SuperTooltip1.DefaultTooltipSettings = New DevComponents.DotNetBar.SuperTooltipInfo("TODO EL TIEMPO EXTRA", "", "Para autorizar todo el tiempo extra trabajado," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "indicar ""*"" o ""TODO""", Global.PIDA.My.Resources.Resources.Information48, Nothing, DevComponents.DotNetBar.eTooltipColor.Gray)
        Me.SuperTooltip1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        '
        'GridColumn6
        '
        Me.GridColumn6.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill
        Me.GridColumn6.DataPropertyName = "comentario"
        Me.GridColumn6.HeaderText = "COMENTARIO"
        Me.GridColumn6.MinimumWidth = 50
        Me.GridColumn6.Name = "colComentario"
        '
        'GridColumn5
        '
        Me.GridColumn5.DataPropertyName = "cod_hora_personal"
        Me.GridColumn5.FilterAutoScan = True
        Me.GridColumn5.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn5.HeaderText = "HORARIO PERSONAL"
        Me.GridColumn5.Name = "colHoraPersonal"
        '
        'GridColumn4
        '
        Me.GridColumn4.DataPropertyName = "cod_hora"
        Me.GridColumn4.FilterAutoScan = True
        Me.GridColumn4.HeaderStyles.Default.AllowWrap = DevComponents.DotNetBar.SuperGrid.Style.Tbool.[True]
        Me.GridColumn4.HeaderText = "HORARIO EXCEPCION"
        Me.GridColumn4.Name = "colHoraExcepcion"
        '
        'GridColumn3
        '
        Me.GridColumn3.DataPropertyName = "fecha"
        Me.GridColumn3.HeaderText = "FECHA"
        Me.GridColumn3.Name = "colFecha"
        '
        'GridColumn2
        '
        Me.GridColumn2.DataPropertyName = "nombres"
        Me.GridColumn2.HeaderText = "NOMBRES"
        Me.GridColumn2.Name = "colNombre"
        Me.GridColumn2.Width = 200
        '
        'GridColumn1
        '
        Me.GridColumn1.DataPropertyName = "reloj"
        Me.GridColumn1.HeaderText = "RELOJ"
        Me.GridColumn1.Name = "colReloj"
        Me.GridColumn1.Width = 70
        '
        'frmExcepcionHorarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1029, 488)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlEncabezado)
        Me.Controls.Add(Me.EmpNav)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmExcepcionHorarios"
        Me.Text = "Excepción de horarios por empleado"
        Me.pnlEncabezado.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.pnlTitulo.PerformLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EmpNav.ResumeLayout(False)
        Me.pnlCentrado.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.pnlEditar.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlEncabezado As System.Windows.Forms.Panel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EmpNav As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents colUnico As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colAno As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colPeriodo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents pnlCentrado As System.Windows.Forms.Panel
    Friend WithEvents btnGlobal As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LayoutGroup1 As DevComponents.DotNetBar.Layout.LayoutGroup
    Friend WithEvents LayoutControlItem4 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevComponents.DotNetBar.Layout.LayoutControlItem
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents btnMostrarInformacion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents pnlEditar As System.Windows.Forms.Panel
    Friend WithEvents prgEditar As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents lblAvance As System.Windows.Forms.Label
    Friend WithEvents btnParametros As DevComponents.DotNetBar.ButtonX
    Friend WithEvents labelTotalVista As DevComponents.DotNetBar.LabelX
    Friend WithEvents SuperTooltip1 As DevComponents.DotNetBar.SuperTooltip
    Friend WithEvents GridColumn6 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn5 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn4 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn3 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn2 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn1 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents dgExcepcionHorarios As DevComponents.DotNetBar.SuperGrid.SuperGridControl
    Friend WithEvents GridColumn7 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn8 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn9 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn10 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn11 As DevComponents.DotNetBar.SuperGrid.GridColumn
    Friend WithEvents GridColumn12 As DevComponents.DotNetBar.SuperGrid.GridColumn
End Class
