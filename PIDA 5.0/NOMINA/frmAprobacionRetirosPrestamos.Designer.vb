<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAprobacionRetirosPrestamos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAprobacionRetirosPrestamos))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.gpReportes = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.advSolicitudes = New DevComponents.AdvTree.AdvTree()
        Me.RELOJ = New DevComponents.AdvTree.ColumnHeader()
        Me.NOMBRE = New DevComponents.AdvTree.ColumnHeader()
        Me.Cantidad = New DevComponents.AdvTree.ColumnHeader()
        Me.FECHA_SOL = New DevComponents.AdvTree.ColumnHeader()
        Me.ID = New DevComponents.AdvTree.ColumnHeader()
        Me.CONFIRMADO = New DevComponents.AdvTree.ColumnHeader()
        Me.NodeConnector1 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.btnExportar = New DevComponents.DotNetBar.ButtonX()
        Me.btnSalir = New DevComponents.DotNetBar.ButtonX()
        Me.btnQuitar = New DevComponents.DotNetBar.ButtonX()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlCancelacion = New System.Windows.Forms.Panel()
        Me.gpCanceladas = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.advCancelaciones = New DevComponents.AdvTree.AdvTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader6 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader4 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader()
        Me.NodeConnector2 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle2 = New DevComponents.DotNetBar.ElementStyle()
        Me.ExpandableSplitter1 = New DevComponents.DotNetBar.ExpandableSplitter()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.ButtonX1 = New DevComponents.DotNetBar.ButtonX()
        Me.gpReportes.SuspendLayout()
        CType(Me.advSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.pnlCancelacion.SuspendLayout()
        Me.gpCanceladas.SuspendLayout()
        CType(Me.advCancelaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(36, 3)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(602, 40)
        Me.ReflectionLabel1.TabIndex = 123
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>EXPORTACIÓN DE DESCUENTOS</b></font>"
        '
        'gpReportes
        '
        Me.gpReportes.BackColor = System.Drawing.Color.Transparent
        Me.gpReportes.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpReportes.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpReportes.Controls.Add(Me.advSolicitudes)
        Me.gpReportes.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpReportes.Location = New System.Drawing.Point(8, 64)
        Me.gpReportes.Name = "gpReportes"
        Me.gpReportes.Size = New System.Drawing.Size(778, 489)
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
        Me.gpReportes.TabIndex = 122
        Me.gpReportes.Text = "Descuentos"
        '
        'advSolicitudes
        '
        Me.advSolicitudes.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.advSolicitudes.AllowDrop = True
        Me.advSolicitudes.AllowUserToResizeColumns = False
        Me.advSolicitudes.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.advSolicitudes.BackgroundStyle.Class = "TreeBorderKey"
        Me.advSolicitudes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.advSolicitudes.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.advSolicitudes.CheckBoxImageIndeterminate = Global.PIDA.My.Resources.Resources.CancelX
        Me.advSolicitudes.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.CancelX
        Me.advSolicitudes.Columns.Add(Me.RELOJ)
        Me.advSolicitudes.Columns.Add(Me.NOMBRE)
        Me.advSolicitudes.Columns.Add(Me.Cantidad)
        Me.advSolicitudes.Columns.Add(Me.FECHA_SOL)
        Me.advSolicitudes.Columns.Add(Me.ID)
        Me.advSolicitudes.Columns.Add(Me.CONFIRMADO)
        Me.advSolicitudes.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.advSolicitudes.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.advSolicitudes.Location = New System.Drawing.Point(3, 12)
        Me.advSolicitudes.Name = "advSolicitudes"
        Me.advSolicitudes.NodesConnector = Me.NodeConnector1
        Me.advSolicitudes.NodeStyle = Me.ElementStyle1
        Me.advSolicitudes.PathSeparator = ";"
        Me.advSolicitudes.Size = New System.Drawing.Size(762, 440)
        Me.advSolicitudes.Styles.Add(Me.ElementStyle1)
        Me.advSolicitudes.TabIndex = 125
        Me.advSolicitudes.Text = "AdvTree1"
        '
        'RELOJ
        '
        Me.RELOJ.ColumnName = "RELOJ"
        Me.RELOJ.DataFieldName = "RELOJ"
        Me.RELOJ.Name = "RELOJ"
        Me.RELOJ.Text = "Reloj"
        Me.RELOJ.Width.Absolute = 150
        '
        'NOMBRE
        '
        Me.NOMBRE.ColumnName = "NOMBRE"
        Me.NOMBRE.DataFieldName = "NOMBRE"
        Me.NOMBRE.Name = "NOMBRE"
        Me.NOMBRE.StretchToFill = True
        Me.NOMBRE.Text = "Nombre"
        Me.NOMBRE.Width.Absolute = 150
        '
        'Cantidad
        '
        Me.Cantidad.ColumnName = "CANTIDAD"
        Me.Cantidad.DataFieldName = "CANTIDAD"
        Me.Cantidad.EditorType = DevComponents.AdvTree.eCellEditorType.NumericCurrency
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Text = "Cantidad"
        Me.Cantidad.Width.Absolute = 150
        '
        'FECHA_SOL
        '
        Me.FECHA_SOL.CellsBackColor = System.Drawing.Color.White
        Me.FECHA_SOL.ColumnName = "Fecha de Solicitud"
        Me.FECHA_SOL.DataFieldName = "Fecha de Solicitud"
        Me.FECHA_SOL.EditorType = DevComponents.AdvTree.eCellEditorType.DateTime
        Me.FECHA_SOL.Name = "FECHA_SOL"
        Me.FECHA_SOL.Text = "Fecha de solicitud"
        Me.FECHA_SOL.Width.Absolute = 150
        '
        'ID
        '
        Me.ID.ColumnName = "ID"
        Me.ID.DataFieldName = "ID"
        Me.ID.DoubleClickAutoSize = False
        Me.ID.Editable = False
        Me.ID.Name = "ID"
        Me.ID.Text = "Identificador"
        Me.ID.Width.Absolute = 1
        '
        'CONFIRMADO
        '
        Me.CONFIRMADO.ColumnName = "CONFIRMADO"
        Me.CONFIRMADO.DataFieldName = "CONFIRMADO"
        Me.CONFIRMADO.Name = "CONFIRMADO"
        Me.CONFIRMADO.Text = "Confirmado"
        Me.CONFIRMADO.Width.Absolute = 1
        '
        'NodeConnector1
        '
        Me.NodeConnector1.LineColor = System.Drawing.SystemColors.ControlText
        '
        'ElementStyle1
        '
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.TextColor = System.Drawing.SystemColors.ControlText
        '
        'btnExportar
        '
        Me.btnExportar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnExportar.CausesValidation = False
        Me.btnExportar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnExportar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportar.Image = Global.PIDA.My.Resources.Resources.Download32
        Me.btnExportar.ImageTextSpacing = 5
        Me.btnExportar.Location = New System.Drawing.Point(792, 457)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(145, 45)
        Me.btnExportar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnExportar.TabIndex = 125
        Me.btnExportar.Text = "Exportar" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "&Vector"
        Me.btnExportar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'btnSalir
        '
        Me.btnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSalir.CausesValidation = False
        Me.btnSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.PIDA.My.Resources.Resources.x18
        Me.btnSalir.ImageTextSpacing = 5
        Me.btnSalir.Location = New System.Drawing.Point(792, 508)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(145, 45)
        Me.btnSalir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSalir.TabIndex = 127
        Me.btnSalir.Text = "&Salir"
        Me.btnSalir.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'btnQuitar
        '
        Me.btnQuitar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnQuitar.CausesValidation = False
        Me.btnQuitar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnQuitar.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitar.Image = Global.PIDA.My.Resources.Resources.Cancel16
        Me.btnQuitar.ImageTextSpacing = 5
        Me.btnQuitar.Location = New System.Drawing.Point(792, 405)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(145, 46)
        Me.btnQuitar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnQuitar.TabIndex = 129
        Me.btnQuitar.Text = "&Cancelar seleccionado"
        Me.btnQuitar.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.SystemColors.Control
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(792, 167)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(145, 71)
        Me.Label13.TabIndex = 140
        Me.Label13.Text = "Recuerda que solo se exportarán los registros marcados"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ReflectionLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1176, 58)
        Me.Panel1.TabIndex = 142
        '
        'pnlCancelacion
        '
        Me.pnlCancelacion.Controls.Add(Me.gpCanceladas)
        Me.pnlCancelacion.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlCancelacion.Location = New System.Drawing.Point(501, 58)
        Me.pnlCancelacion.Name = "pnlCancelacion"
        Me.pnlCancelacion.Size = New System.Drawing.Size(733, 507)
        Me.pnlCancelacion.TabIndex = 143
        Me.pnlCancelacion.Visible = False
        '
        'gpCanceladas
        '
        Me.gpCanceladas.BackColor = System.Drawing.Color.Transparent
        Me.gpCanceladas.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpCanceladas.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpCanceladas.Controls.Add(Me.advCancelaciones)
        Me.gpCanceladas.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpCanceladas.Location = New System.Drawing.Point(15, 6)
        Me.gpCanceladas.Name = "gpCanceladas"
        Me.gpCanceladas.Size = New System.Drawing.Size(699, 489)
        '
        '
        '
        Me.gpCanceladas.Style.BackColor = System.Drawing.Color.White
        Me.gpCanceladas.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpCanceladas.Style.BackColorGradientAngle = 90
        Me.gpCanceladas.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpCanceladas.Style.BorderBottomWidth = 1
        Me.gpCanceladas.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpCanceladas.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpCanceladas.Style.BorderLeftWidth = 1
        Me.gpCanceladas.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpCanceladas.Style.BorderRightWidth = 1
        Me.gpCanceladas.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpCanceladas.Style.BorderTopWidth = 1
        Me.gpCanceladas.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpCanceladas.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpCanceladas.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpCanceladas.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        Me.gpCanceladas.Style.TextShadowColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.gpCanceladas.Style.TextShadowOffset = New System.Drawing.Point(1, 1)
        '
        '
        '
        Me.gpCanceladas.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpCanceladas.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpCanceladas.TabIndex = 123
        Me.gpCanceladas.Text = "Solicitudes Canceladas"
        '
        'advCancelaciones
        '
        Me.advCancelaciones.AccessibleRole = System.Windows.Forms.AccessibleRole.Outline
        Me.advCancelaciones.AllowDrop = True
        Me.advCancelaciones.AllowUserToResizeColumns = False
        Me.advCancelaciones.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.advCancelaciones.BackgroundStyle.Class = "TreeBorderKey"
        Me.advCancelaciones.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.advCancelaciones.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.advCancelaciones.CheckBoxImageIndeterminate = Global.PIDA.My.Resources.Resources.CancelX
        Me.advCancelaciones.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.CancelX
        Me.advCancelaciones.Columns.Add(Me.ColumnHeader1)
        Me.advCancelaciones.Columns.Add(Me.ColumnHeader2)
        Me.advCancelaciones.Columns.Add(Me.ColumnHeader3)
        Me.advCancelaciones.Columns.Add(Me.ColumnHeader6)
        Me.advCancelaciones.Columns.Add(Me.ColumnHeader4)
        Me.advCancelaciones.Columns.Add(Me.ColumnHeader5)
        Me.advCancelaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.advCancelaciones.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.advCancelaciones.Location = New System.Drawing.Point(3, 12)
        Me.advCancelaciones.Name = "advCancelaciones"
        Me.advCancelaciones.NodesConnector = Me.NodeConnector2
        Me.advCancelaciones.NodeStyle = Me.ElementStyle2
        Me.advCancelaciones.PathSeparator = ";"
        Me.advCancelaciones.Size = New System.Drawing.Size(688, 437)
        Me.advCancelaciones.Styles.Add(Me.ElementStyle2)
        Me.advCancelaciones.TabIndex = 125
        Me.advCancelaciones.Text = "AdvTree2"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.ColumnName = "RELOJ"
        Me.ColumnHeader1.DataFieldName = "RELOJ"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Reloj"
        Me.ColumnHeader1.Width.Absolute = 150
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.ColumnName = "NOMBRE"
        Me.ColumnHeader2.DataFieldName = "NOMBRE"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.StretchToFill = True
        Me.ColumnHeader2.Text = "Nombre"
        Me.ColumnHeader2.Width.Absolute = 150
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.CellsBackColor = System.Drawing.Color.White
        Me.ColumnHeader3.ColumnName = "Fecha de cancelación"
        Me.ColumnHeader3.DataFieldName = "Fecha de cancelación"
        Me.ColumnHeader3.EditorType = DevComponents.AdvTree.eCellEditorType.DateTime
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "Fecha de cancelación"
        Me.ColumnHeader3.Width.Absolute = 150
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.ColumnName = "USUARIO_CAN"
        Me.ColumnHeader6.DataFieldName = "USUARIO_CAN"
        Me.ColumnHeader6.Name = "ColumnHeader6"
        Me.ColumnHeader6.Text = "Usuario Canceló"
        Me.ColumnHeader6.Width.Absolute = 150
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.ColumnName = "ID"
        Me.ColumnHeader4.DataFieldName = "ID"
        Me.ColumnHeader4.DoubleClickAutoSize = False
        Me.ColumnHeader4.Editable = False
        Me.ColumnHeader4.Name = "ColumnHeader4"
        Me.ColumnHeader4.Text = "Identificador"
        Me.ColumnHeader4.Width.Absolute = 1
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.ColumnName = "CONFIRMADO"
        Me.ColumnHeader5.DataFieldName = "CONFIRMADO"
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.Text = "Confirmado"
        Me.ColumnHeader5.Width.Absolute = 1
        '
        'NodeConnector2
        '
        Me.NodeConnector2.LineColor = System.Drawing.SystemColors.ControlText
        '
        'ElementStyle2
        '
        Me.ElementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle2.Name = "ElementStyle2"
        Me.ElementStyle2.TextColor = System.Drawing.SystemColors.ControlText
        '
        'ExpandableSplitter1
        '
        Me.ExpandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.ExpandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.ExpandableSplitter1.Dock = System.Windows.Forms.DockStyle.Right
        Me.ExpandableSplitter1.ExpandableControl = Me.pnlCancelacion
        Me.ExpandableSplitter1.Expanded = False
        Me.ExpandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.ExpandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.ExpandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.ExpandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ExpandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(207, Byte), Integer), CType(CType(155, Byte), Integer))
        Me.ExpandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(254, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(189, Byte), Integer))
        Me.ExpandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
        Me.ExpandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
        Me.ExpandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.ExpandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.ExpandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
        Me.ExpandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(118, Byte), Integer), CType(CType(176, Byte), Integer))
        Me.ExpandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.ExpandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(213, Byte), Integer), CType(CType(235, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ExpandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.ExpandableSplitter1.Location = New System.Drawing.Point(1142, 58)
        Me.ExpandableSplitter1.Name = "ExpandableSplitter1"
        Me.ExpandableSplitter1.Size = New System.Drawing.Size(34, 507)
        Me.ExpandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
        Me.ExpandableSplitter1.TabIndex = 144
        Me.ExpandableSplitter1.TabStop = False
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Dock = System.Windows.Forms.DockStyle.Right
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(1118, 58)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(24, 507)
        Me.LabelX1.TabIndex = 126
        Me.LabelX1.Text = "Solicitudes canceladas"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Center
        Me.LabelX1.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        '
        'ButtonX1
        '
        Me.ButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonX1.CausesValidation = False
        Me.ButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonX1.Image = Global.PIDA.My.Resources.Resources.Add
        Me.ButtonX1.ImageTextSpacing = 5
        Me.ButtonX1.Location = New System.Drawing.Point(792, 353)
        Me.ButtonX1.Name = "ButtonX1"
        Me.ButtonX1.Size = New System.Drawing.Size(145, 46)
        Me.ButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonX1.TabIndex = 145
        Me.ButtonX1.Text = "&Agregar Préstamo/Retiro"
        Me.ButtonX1.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        '
        'frmAprobacionRetirosPrestamos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1176, 565)
        Me.Controls.Add(Me.ButtonX1)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.ExpandableSplitter1)
        Me.Controls.Add(Me.pnlCancelacion)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnQuitar)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.gpReportes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAprobacionRetirosPrestamos"
        Me.Text = "Descuentos"
        Me.gpReportes.ResumeLayout(False)
        CType(Me.advSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.pnlCancelacion.ResumeLayout(False)
        Me.gpCanceladas.ResumeLayout(False)
        CType(Me.advCancelaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Private WithEvents gpReportes As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents advSolicitudes As DevComponents.AdvTree.AdvTree
    Friend WithEvents NodeConnector1 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents btnExportar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSalir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnQuitar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents FECHA_SOL As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents RELOJ As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NOMBRE As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ID As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents CONFIRMADO As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnlCancelacion As System.Windows.Forms.Panel
    Private WithEvents gpCanceladas As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents advCancelaciones As DevComponents.AdvTree.AdvTree
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader4 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NodeConnector2 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle2 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ColumnHeader6 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ExpandableSplitter1 As DevComponents.DotNetBar.ExpandableSplitter
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Cantidad As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ButtonX1 As DevComponents.DotNetBar.ButtonX
End Class
