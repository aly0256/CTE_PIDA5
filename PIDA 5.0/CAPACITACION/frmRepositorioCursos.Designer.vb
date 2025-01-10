<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRepositorioCursos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRepositorioCursos))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.dlgSave = New System.Windows.Forms.SaveFileDialog()
        Me.opnArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.mnuDocs = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DocToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgregarDocumentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EliminarDocumentoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.GuardarArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImprimirArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.CerrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CollapsibleSplitContainer1 = New DevComponents.DotNetBar.Controls.CollapsibleSplitContainer()
        Me.treeDocs = New DevComponents.AdvTree.AdvTree()
        Me.ElementStyle5 = New DevComponents.DotNetBar.ElementStyle()
        Me.Node1 = New DevComponents.AdvTree.Node()
        Me.Node5 = New DevComponents.AdvTree.Node()
        Me.Node4 = New DevComponents.AdvTree.Node()
        Me.Node3 = New DevComponents.AdvTree.Node()
        Me.Node2 = New DevComponents.AdvTree.Node()
        Me.Node6 = New DevComponents.AdvTree.Node()
        Me.ElementStyle6 = New DevComponents.DotNetBar.ElementStyle()
        Me.Node7 = New DevComponents.AdvTree.Node()
        Me.Node9 = New DevComponents.AdvTree.Node()
        Me.Node10 = New DevComponents.AdvTree.Node()
        Me.Node12 = New DevComponents.AdvTree.Node()
        Me.Node11 = New DevComponents.AdvTree.Node()
        Me.Node13 = New DevComponents.AdvTree.Node()
        Me.Node14 = New DevComponents.AdvTree.Node()
        Me.NodeConnector2 = New DevComponents.AdvTree.NodeConnector()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle3 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle4 = New DevComponents.DotNetBar.ElementStyle()
        Me.webPreview = New System.Windows.Forms.WebBrowser()
        Me.imgDocs = New System.Windows.Forms.ImageList(Me.components)
        Me.txtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrimero = New DevComponents.DotNetBar.ButtonX()
        Me.btnAnterior = New DevComponents.DotNetBar.ButtonX()
        Me.btnSiguiente = New DevComponents.DotNetBar.ButtonX()
        Me.btnUltimo = New DevComponents.DotNetBar.ButtonX()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.mnuDocs.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.CollapsibleSplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CollapsibleSplitContainer1.Panel1.SuspendLayout()
        Me.CollapsibleSplitContainer1.Panel2.SuspendLayout()
        Me.CollapsibleSplitContainer1.SuspendLayout()
        CType(Me.treeDocs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.txtNombre)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtCodigo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1070, 76)
        Me.Panel1.TabIndex = 0
        '
        'opnArchivo
        '
        Me.opnArchivo.FileName = "OpenFileDialog1"
        '
        'mnuDocs
        '
        Me.mnuDocs.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.mnuDocs.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DocToolStripMenuItem, Me.AgregarDocumentoToolStripMenuItem, Me.EliminarDocumentoToolStripMenuItem, Me.ToolStripMenuItem2, Me.GuardarArchivoToolStripMenuItem, Me.ImprimirArchivoToolStripMenuItem, Me.ToolStripMenuItem3, Me.CerrarToolStripMenuItem})
        Me.mnuDocs.Name = "mnuDocs"
        Me.mnuDocs.Size = New System.Drawing.Size(229, 148)
        '
        'DocToolStripMenuItem
        '
        Me.DocToolStripMenuItem.BackColor = System.Drawing.SystemColors.Highlight
        Me.DocToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Window
        Me.DocToolStripMenuItem.Name = "DocToolStripMenuItem"
        Me.DocToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        '
        'AgregarDocumentoToolStripMenuItem
        '
        Me.AgregarDocumentoToolStripMenuItem.Name = "AgregarDocumentoToolStripMenuItem"
        Me.AgregarDocumentoToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.AgregarDocumentoToolStripMenuItem.Text = "Agregar/Guardar documento"
        '
        'EliminarDocumentoToolStripMenuItem
        '
        Me.EliminarDocumentoToolStripMenuItem.Name = "EliminarDocumentoToolStripMenuItem"
        Me.EliminarDocumentoToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.EliminarDocumentoToolStripMenuItem.Text = "Eliminar documento"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(225, 6)
        '
        'GuardarArchivoToolStripMenuItem
        '
        Me.GuardarArchivoToolStripMenuItem.Name = "GuardarArchivoToolStripMenuItem"
        Me.GuardarArchivoToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.GuardarArchivoToolStripMenuItem.Text = "Guardar archivo"
        Me.GuardarArchivoToolStripMenuItem.Visible = False
        '
        'ImprimirArchivoToolStripMenuItem
        '
        Me.ImprimirArchivoToolStripMenuItem.Name = "ImprimirArchivoToolStripMenuItem"
        Me.ImprimirArchivoToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.ImprimirArchivoToolStripMenuItem.Text = "Imprimir archivo"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(225, 6)
        '
        'CerrarToolStripMenuItem
        '
        Me.CerrarToolStripMenuItem.Name = "CerrarToolStripMenuItem"
        Me.CerrarToolStripMenuItem.Size = New System.Drawing.Size(228, 22)
        Me.CerrarToolStripMenuItem.Text = "Cerrar"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnCerrar)
        Me.Panel2.Controls.Add(Me.btnPrimero)
        Me.Panel2.Controls.Add(Me.btnAnterior)
        Me.Panel2.Controls.Add(Me.btnSiguiente)
        Me.Panel2.Controls.Add(Me.btnUltimo)
        Me.Panel2.Controls.Add(Me.btnBuscar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 546)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1070, 54)
        Me.Panel2.TabIndex = 3
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.Controls.Add(Me.CollapsibleSplitContainer1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 76)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1070, 470)
        Me.Panel3.TabIndex = 4
        '
        'CollapsibleSplitContainer1
        '
        Me.CollapsibleSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CollapsibleSplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.CollapsibleSplitContainer1.Name = "CollapsibleSplitContainer1"
        '
        'CollapsibleSplitContainer1.Panel1
        '
        Me.CollapsibleSplitContainer1.Panel1.Controls.Add(Me.treeDocs)
        '
        'CollapsibleSplitContainer1.Panel2
        '
        Me.CollapsibleSplitContainer1.Panel2.Controls.Add(Me.webPreview)
        Me.CollapsibleSplitContainer1.Size = New System.Drawing.Size(1070, 470)
        Me.CollapsibleSplitContainer1.SplitterDistance = 312
        Me.CollapsibleSplitContainer1.SplitterWidth = 20
        Me.CollapsibleSplitContainer1.TabIndex = 0
        '
        'treeDocs
        '
        Me.treeDocs.AllowDrop = True
        Me.treeDocs.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.treeDocs.BackgroundStyle.Class = "TreeBorderKey"
        Me.treeDocs.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.treeDocs.ContextMenuStrip = Me.mnuDocs
        Me.treeDocs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeDocs.ExpandButtonSize = New System.Drawing.Size(16, 16)
        Me.treeDocs.ExpandButtonType = DevComponents.AdvTree.eExpandButtonType.Image
        Me.treeDocs.GroupNodeStyle = Me.ElementStyle5
        Me.treeDocs.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.treeDocs.Location = New System.Drawing.Point(0, 0)
        Me.treeDocs.Name = "treeDocs"
        Me.treeDocs.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node1, Me.Node2, Me.Node9, Me.Node10, Me.Node13, Me.Node14})
        Me.treeDocs.NodesConnector = Me.NodeConnector2
        Me.treeDocs.NodeStyle = Me.ElementStyle1
        Me.treeDocs.PathSeparator = ";"
        Me.treeDocs.Size = New System.Drawing.Size(312, 470)
        Me.treeDocs.Styles.Add(Me.ElementStyle1)
        Me.treeDocs.Styles.Add(Me.ElementStyle3)
        Me.treeDocs.Styles.Add(Me.ElementStyle4)
        Me.treeDocs.Styles.Add(Me.ElementStyle5)
        Me.treeDocs.Styles.Add(Me.ElementStyle6)
        Me.treeDocs.TabIndex = 2
        '
        'ElementStyle5
        '
        Me.ElementStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ElementStyle5.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ElementStyle5.BackColorGradientAngle = 90
        Me.ElementStyle5.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle5.BorderBottomWidth = 1
        Me.ElementStyle5.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle5.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle5.BorderLeftWidth = 1
        Me.ElementStyle5.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle5.BorderRightWidth = 1
        Me.ElementStyle5.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle5.BorderTopWidth = 1
        Me.ElementStyle5.CornerDiameter = 4
        Me.ElementStyle5.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle5.Description = "Blue"
        Me.ElementStyle5.Name = "ElementStyle5"
        Me.ElementStyle5.PaddingBottom = 1
        Me.ElementStyle5.PaddingLeft = 1
        Me.ElementStyle5.PaddingRight = 1
        Me.ElementStyle5.PaddingTop = 1
        Me.ElementStyle5.TextColor = System.Drawing.Color.Black
        '
        'Node1
        '
        Me.Node1.Name = "Node1"
        Me.Node1.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node5, Me.Node4, Me.Node3})
        Me.Node1.Text = "1.1 ALTA IMSS                                                                   "
        '
        'Node5
        '
        Me.Node5.Name = "Node5"
        Me.Node5.Text = "Descripción: Alta IMSS.jpg"
        '
        'Node4
        '
        Me.Node4.Expanded = True
        Me.Node4.Name = "Node4"
        Me.Node4.Text = "Fecha doc.:12/10/2010"
        '
        'Node3
        '
        Me.Node3.Expanded = True
        Me.Node3.Name = "Node3"
        Me.Node3.Text = "Tipo de archivo: JPG"
        '
        'Node2
        '
        Me.Node2.Name = "Node2"
        Me.Node2.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node6, Me.Node7})
        Me.Node2.NodesIndent = 24
        Me.Node2.Text = "1.2 INTEGRACION SALARIAL                                                        "
        '
        'Node6
        '
        Me.Node6.Expanded = True
        Me.Node6.FullRowBackground = True
        Me.Node6.Name = "Node6"
        Me.Node6.Style = Me.ElementStyle6
        Me.Node6.Text = "Node6"
        '
        'ElementStyle6
        '
        Me.ElementStyle6.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElementStyle6.Name = "ElementStyle6"
        '
        'Node7
        '
        Me.Node7.Name = "Node7"
        Me.Node7.Text = "Node7"
        '
        'Node9
        '
        Me.Node9.Expanded = True
        Me.Node9.Name = "Node9"
        Me.Node9.Selectable = False
        Me.Node9.Text = "       3.3 CURRICULUM  VITAE O SOLICITUD DE EMPLEO.PDF   "
        '
        'Node10
        '
        Me.Node10.Name = "Node10"
        Me.Node10.Nodes.AddRange(New DevComponents.AdvTree.Node() {Me.Node12, Me.Node11})
        Me.Node10.Text = "2.6 IFE  POR AMBOS LADOS Y/O IDENTIFICACIÓN O.PDF "
        '
        'Node12
        '
        Me.Node12.Expanded = True
        Me.Node12.Name = "Node12"
        Me.Node12.Text = "Node12"
        '
        'Node11
        '
        Me.Node11.Expanded = True
        Me.Node11.Name = "Node11"
        Me.Node11.Text = "Node11"
        '
        'Node13
        '
        Me.Node13.Expanded = True
        Me.Node13.Name = "Node13"
        Me.Node13.Text = "2.10 AVISO DE RETENCION CREDITO INFONAVIT.PDF     "
        '
        'Node14
        '
        Me.Node14.Expanded = True
        Me.Node14.Name = "Node14"
        Me.Node14.Text = "3.3 ESTUDIO SOCIOECONOMICO E INVESTIGACION LA.PDF "
        '
        'NodeConnector2
        '
        Me.NodeConnector2.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.NodeConnector2.LineColor = System.Drawing.SystemColors.Window
        '
        'ElementStyle1
        '
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.TextColor = System.Drawing.SystemColors.ControlText
        '
        'ElementStyle3
        '
        Me.ElementStyle3.BackColor = System.Drawing.SystemColors.Menu
        Me.ElementStyle3.BackColor2 = System.Drawing.SystemColors.Menu
        Me.ElementStyle3.BackColorGradientAngle = 90
        Me.ElementStyle3.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle3.BorderBottomWidth = 1
        Me.ElementStyle3.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle3.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle3.BorderLeftWidth = 1
        Me.ElementStyle3.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle3.BorderRightWidth = 1
        Me.ElementStyle3.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle3.BorderTopWidth = 1
        Me.ElementStyle3.CornerDiameter = 4
        Me.ElementStyle3.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle3.Description = "Blue"
        Me.ElementStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ElementStyle3.Name = "ElementStyle3"
        Me.ElementStyle3.PaddingBottom = 1
        Me.ElementStyle3.PaddingLeft = 1
        Me.ElementStyle3.PaddingRight = 1
        Me.ElementStyle3.PaddingTop = 1
        Me.ElementStyle3.TextColor = System.Drawing.SystemColors.ControlDark
        '
        'ElementStyle4
        '
        Me.ElementStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ElementStyle4.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ElementStyle4.BackColorGradientAngle = 90
        Me.ElementStyle4.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle4.BorderBottomWidth = 1
        Me.ElementStyle4.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle4.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle4.BorderLeftWidth = 1
        Me.ElementStyle4.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle4.BorderRightWidth = 1
        Me.ElementStyle4.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle4.BorderTopWidth = 1
        Me.ElementStyle4.CornerDiameter = 4
        Me.ElementStyle4.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle4.Description = "BlueLight"
        Me.ElementStyle4.Name = "ElementStyle4"
        Me.ElementStyle4.PaddingBottom = 1
        Me.ElementStyle4.PaddingLeft = 1
        Me.ElementStyle4.PaddingRight = 1
        Me.ElementStyle4.PaddingTop = 1
        Me.ElementStyle4.TextColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(115, Byte), Integer))
        '
        'webPreview
        '
        Me.webPreview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.webPreview.Location = New System.Drawing.Point(0, 0)
        Me.webPreview.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webPreview.Name = "webPreview"
        Me.webPreview.Size = New System.Drawing.Size(738, 470)
        Me.webPreview.TabIndex = 8
        '
        'imgDocs
        '
        Me.imgDocs.ImageStream = CType(resources.GetObject("imgDocs.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgDocs.TransparentColor = System.Drawing.Color.Transparent
        Me.imgDocs.Images.SetKeyName(0, "archivo2")
        Me.imgDocs.Images.SetKeyName(1, "archivo")
        Me.imgDocs.Images.SetKeyName(2, "attachment16.png")
        Me.imgDocs.Images.SetKeyName(3, "DOC")
        Me.imgDocs.Images.SetKeyName(4, "MSG")
        Me.imgDocs.Images.SetKeyName(5, "PDF")
        Me.imgDocs.Images.SetKeyName(6, "TIF")
        Me.imgDocs.Images.SetKeyName(7, "DOCX")
        Me.imgDocs.Images.SetKeyName(8, "JPG")
        Me.imgDocs.Images.SetKeyName(9, "JPEG")
        Me.imgDocs.Images.SetKeyName(10, "PNG")
        Me.imgDocs.Images.SetKeyName(11, "BMP")
        Me.imgDocs.Images.SetKeyName(12, "BLANCO")
        Me.imgDocs.Images.SetKeyName(13, "UND")
        Me.imgDocs.Images.SetKeyName(14, "DOCX")
        '
        'txtCodigo
        '
        '
        '
        '
        Me.txtCodigo.Border.Class = "TextBoxBorder"
        Me.txtCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.Location = New System.Drawing.Point(310, 12)
        Me.txtCodigo.MaxLength = 5
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(136, 21)
        Me.txtCodigo.TabIndex = 2
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(697, 17)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(73, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 15
        Me.btnCerrar.Text = "Salir"
        '
        'btnPrimero
        '
        Me.btnPrimero.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrimero.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrimero.Image = Global.PIDA.My.Resources.Resources.First16
        Me.btnPrimero.Location = New System.Drawing.Point(310, 17)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(73, 25)
        Me.btnPrimero.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrimero.TabIndex = 10
        Me.btnPrimero.Text = "Inicio"
        '
        'btnAnterior
        '
        Me.btnAnterior.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAnterior.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAnterior.Image = Global.PIDA.My.Resources.Resources.Prev16
        Me.btnAnterior.Location = New System.Drawing.Point(387, 17)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(73, 25)
        Me.btnAnterior.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAnterior.TabIndex = 11
        Me.btnAnterior.Text = "Anterior"
        '
        'btnSiguiente
        '
        Me.btnSiguiente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSiguiente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSiguiente.Image = Global.PIDA.My.Resources.Resources.Next16
        Me.btnSiguiente.Location = New System.Drawing.Point(464, 17)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(73, 25)
        Me.btnSiguiente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSiguiente.TabIndex = 12
        Me.btnSiguiente.Text = "Siguiente"
        '
        'btnUltimo
        '
        Me.btnUltimo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnUltimo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnUltimo.Image = Global.PIDA.My.Resources.Resources.Last16
        Me.btnUltimo.Location = New System.Drawing.Point(541, 17)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(73, 25)
        Me.btnUltimo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnUltimo.TabIndex = 13
        Me.btnUltimo.Text = "Final"
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscar.Location = New System.Drawing.Point(618, 17)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(73, 25)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 14
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Tooltip = "Buscar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(256, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 15)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "Código"
        '
        'txtNombre
        '
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.Location = New System.Drawing.Point(513, 12)
        Me.txtNombre.MaxLength = 150
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(438, 21)
        Me.txtNombre.TabIndex = 82
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(455, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "Nombre"
        '
        'frmRepositorioCursos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1070, 600)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRepositorioCursos"
        Me.Text = "Repositorio de cursos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.mnuDocs.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.CollapsibleSplitContainer1.Panel1.ResumeLayout(False)
        Me.CollapsibleSplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.CollapsibleSplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CollapsibleSplitContainer1.ResumeLayout(False)
        CType(Me.treeDocs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents dlgSave As System.Windows.Forms.SaveFileDialog
    Friend WithEvents opnArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents mnuDocs As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DocToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AgregarDocumentoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EliminarDocumentoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GuardarArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImprimirArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CerrarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents CollapsibleSplitContainer1 As DevComponents.DotNetBar.Controls.CollapsibleSplitContainer
    Friend WithEvents treeDocs As DevComponents.AdvTree.AdvTree
    Friend WithEvents ElementStyle5 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents Node1 As DevComponents.AdvTree.Node
    Friend WithEvents Node5 As DevComponents.AdvTree.Node
    Friend WithEvents Node4 As DevComponents.AdvTree.Node
    Friend WithEvents Node3 As DevComponents.AdvTree.Node
    Friend WithEvents Node2 As DevComponents.AdvTree.Node
    Friend WithEvents Node6 As DevComponents.AdvTree.Node
    Friend WithEvents ElementStyle6 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents Node7 As DevComponents.AdvTree.Node
    Friend WithEvents Node9 As DevComponents.AdvTree.Node
    Friend WithEvents Node10 As DevComponents.AdvTree.Node
    Friend WithEvents Node12 As DevComponents.AdvTree.Node
    Friend WithEvents Node11 As DevComponents.AdvTree.Node
    Friend WithEvents Node13 As DevComponents.AdvTree.Node
    Friend WithEvents Node14 As DevComponents.AdvTree.Node
    Friend WithEvents NodeConnector2 As DevComponents.AdvTree.NodeConnector
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle3 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle4 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents webPreview As System.Windows.Forms.WebBrowser
    Friend WithEvents imgDocs As System.Windows.Forms.ImageList
    Friend WithEvents txtCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrimero As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAnterior As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSiguiente As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnUltimo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
