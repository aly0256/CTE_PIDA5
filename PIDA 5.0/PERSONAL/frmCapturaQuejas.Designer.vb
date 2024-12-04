<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCapturaQuejas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapturaQuejas))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtComentSupervisor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtComentEmpleado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ColumnHeader3 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader5 = New DevComponents.AdvTree.ColumnHeader()
        Me.cmbMotivo = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.ColumnHeader1 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader2 = New DevComponents.AdvTree.ColumnHeader()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblEstado = New DevComponents.DotNetBar.LabelX()
        Me.gpDatos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDepartamento = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPuesto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNombres = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNoReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnVerPDF = New DevComponents.DotNetBar.ButtonX()
        Me.btnSubirPDF = New DevComponents.DotNetBar.ButtonX()
        Me.txtPDF = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label95 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtimeFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.ColumnHeader6 = New DevComponents.AdvTree.ColumnHeader()
        Me.ColumnHeader7 = New DevComponents.AdvTree.ColumnHeader()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gpDatos.SuspendLayout()
        CType(Me.dtimeFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 161)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(290, 17)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Datos de persona que levanta la queja"
        '
        'txtComentSupervisor
        '
        '
        '
        '
        Me.txtComentSupervisor.Border.Class = "TextBoxBorder"
        Me.txtComentSupervisor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtComentSupervisor.Location = New System.Drawing.Point(17, 313)
        Me.txtComentSupervisor.Multiline = True
        Me.txtComentSupervisor.Name = "txtComentSupervisor"
        Me.txtComentSupervisor.PreventEnterBeep = True
        Me.txtComentSupervisor.Size = New System.Drawing.Size(663, 38)
        Me.txtComentSupervisor.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 296)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(138, 15)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Comentarios/Supervisor"
        '
        'txtComentEmpleado
        '
        '
        '
        '
        Me.txtComentEmpleado.Border.Class = "TextBoxBorder"
        Me.txtComentEmpleado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtComentEmpleado.Location = New System.Drawing.Point(17, 381)
        Me.txtComentEmpleado.Multiline = True
        Me.txtComentEmpleado.Name = "txtComentEmpleado"
        Me.txtComentEmpleado.PreventEnterBeep = True
        Me.txtComentEmpleado.Size = New System.Drawing.Size(663, 40)
        Me.txtComentEmpleado.TabIndex = 34
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 363)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(137, 15)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Comentarios/Empleado"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.ColumnName = "TIPO"
        Me.ColumnHeader3.DataFieldName = "TIPO"
        Me.ColumnHeader3.Name = "ColumnHeader3"
        Me.ColumnHeader3.Text = "TIPO"
        Me.ColumnHeader3.Width.Absolute = 150
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.ColumnName = "cod_tipo_accion"
        Me.ColumnHeader5.DataFieldName = "cod_tipo_accion"
        Me.ColumnHeader5.Name = "ColumnHeader5"
        Me.ColumnHeader5.Text = "CODIGO"
        Me.ColumnHeader5.Visible = False
        Me.ColumnHeader5.Width.Absolute = 50
        '
        'cmbMotivo
        '
        Me.cmbMotivo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbMotivo.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbMotivo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbMotivo.ButtonDropDown.Visible = True
        Me.cmbMotivo.Columns.Add(Me.ColumnHeader1)
        Me.cmbMotivo.Columns.Add(Me.ColumnHeader2)
        Me.cmbMotivo.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbMotivo.Location = New System.Drawing.Point(17, 119)
        Me.cmbMotivo.Name = "cmbMotivo"
        Me.cmbMotivo.Size = New System.Drawing.Size(663, 20)
        Me.cmbMotivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbMotivo.TabIndex = 38
        Me.cmbMotivo.ValueMember = "cod_motivo"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.ColumnName = "Código"
        Me.ColumnHeader1.DataFieldName = "cod_motivo"
        Me.ColumnHeader1.Name = "ColumnHeader1"
        Me.ColumnHeader1.Text = "Código"
        Me.ColumnHeader1.Width.Absolute = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.ColumnName = "Nombre"
        Me.ColumnHeader2.DataFieldName = "NOMBRE"
        Me.ColumnHeader2.Name = "ColumnHeader2"
        Me.ColumnHeader2.StretchToFill = True
        Me.ColumnHeader2.Text = "Motivo"
        Me.ColumnHeader2.Width.Absolute = 500
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnAceptar)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Location = New System.Drawing.Point(537, 568)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(174, 47)
        Me.GroupBox1.TabIndex = 131
        Me.GroupBox1.TabStop = False
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.Location = New System.Drawing.Point(6, 14)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.TabIndex = 11
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelar.Location = New System.Drawing.Point(90, 14)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Text = "Cancelar"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LabelX4)
        Me.GroupBox2.Controls.Add(Me.txtReloj)
        Me.GroupBox2.Location = New System.Drawing.Point(502, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(191, 49)
        Me.GroupBox2.TabIndex = 282
        Me.GroupBox2.TabStop = False
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(11, 17)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(56, 23)
        Me.LabelX4.TabIndex = 36
        Me.LabelX4.Text = "Reloj"
        '
        'txtReloj
        '
        Me.txtReloj.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.Enabled = False
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.ForeColor = System.Drawing.Color.Black
        Me.txtReloj.Location = New System.Drawing.Point(81, 14)
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.ReadOnly = True
        Me.txtReloj.Size = New System.Drawing.Size(84, 26)
        Me.txtReloj.TabIndex = 56
        Me.txtReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(49, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 15)
        Me.Label6.TabIndex = 281
        Me.Label6.Text = "Nombre"
        '
        'txtNombre
        '
        Me.txtNombre.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.Enabled = False
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.Color.Black
        Me.txtNombre.Location = New System.Drawing.Point(47, 85)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(664, 21)
        Me.txtNombre.TabIndex = 280
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.Color.Green
        '
        '
        '
        Me.lblEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblEstado.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.White
        Me.lblEstado.Location = New System.Drawing.Point(12, 11)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(29, 95)
        Me.lblEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblEstado.TabIndex = 283
        Me.lblEstado.Text = "ACTIVO"
        Me.lblEstado.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblEstado.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.lblEstado.VerticalTextTopUp = False
        '
        'gpDatos
        '
        Me.gpDatos.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpDatos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpDatos.Controls.Add(Me.Label10)
        Me.gpDatos.Controls.Add(Me.btnBuscar)
        Me.gpDatos.Controls.Add(Me.Label9)
        Me.gpDatos.Controls.Add(Me.txtDepartamento)
        Me.gpDatos.Controls.Add(Me.Label8)
        Me.gpDatos.Controls.Add(Me.txtPuesto)
        Me.gpDatos.Controls.Add(Me.Label5)
        Me.gpDatos.Controls.Add(Me.txtNombres)
        Me.gpDatos.Controls.Add(Me.Label4)
        Me.gpDatos.Controls.Add(Me.txtNoReloj)
        Me.gpDatos.Controls.Add(Me.btnVerPDF)
        Me.gpDatos.Controls.Add(Me.btnSubirPDF)
        Me.gpDatos.Controls.Add(Me.txtPDF)
        Me.gpDatos.Controls.Add(Me.Label95)
        Me.gpDatos.Controls.Add(Me.Label7)
        Me.gpDatos.Controls.Add(Me.dtimeFecha)
        Me.gpDatos.Controls.Add(Me.txtComentEmpleado)
        Me.gpDatos.Controls.Add(Me.Label2)
        Me.gpDatos.Controls.Add(Me.txtComentSupervisor)
        Me.gpDatos.Controls.Add(Me.Label1)
        Me.gpDatos.Controls.Add(Me.cmbMotivo)
        Me.gpDatos.Controls.Add(Me.Label3)
        Me.gpDatos.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpDatos.Location = New System.Drawing.Point(12, 112)
        Me.gpDatos.Name = "gpDatos"
        Me.gpDatos.Size = New System.Drawing.Size(699, 450)
        '
        '
        '
        Me.gpDatos.Style.BackColor = System.Drawing.Color.White
        Me.gpDatos.Style.BackColor2 = System.Drawing.Color.White
        Me.gpDatos.Style.BackColorGradientAngle = 90
        Me.gpDatos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDatos.Style.BorderBottomWidth = 1
        Me.gpDatos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpDatos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDatos.Style.BorderLeftWidth = 1
        Me.gpDatos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDatos.Style.BorderRightWidth = 1
        Me.gpDatos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDatos.Style.BorderTopWidth = 1
        Me.gpDatos.Style.CornerDiameter = 4
        Me.gpDatos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpDatos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.gpDatos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpDatos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpDatos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpDatos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpDatos.TabIndex = 284
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Window
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(17, 101)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 15)
        Me.Label10.TabIndex = 115
        Me.Label10.Text = "Motivo"
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscar.Location = New System.Drawing.Point(138, 208)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(43, 20)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 114
        Me.btnBuscar.Tooltip = "Buscar"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(382, 238)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 15)
        Me.Label9.TabIndex = 113
        Me.Label9.Text = "Departamento"
        '
        'txtDepartamento
        '
        '
        '
        '
        Me.txtDepartamento.Border.Class = "TextBoxBorder"
        Me.txtDepartamento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDepartamento.Enabled = False
        Me.txtDepartamento.Location = New System.Drawing.Point(382, 256)
        Me.txtDepartamento.Name = "txtDepartamento"
        Me.txtDepartamento.PreventEnterBeep = True
        Me.txtDepartamento.Size = New System.Drawing.Size(298, 20)
        Me.txtDepartamento.TabIndex = 112
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(382, 190)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 15)
        Me.Label8.TabIndex = 111
        Me.Label8.Text = "Puesto"
        '
        'txtPuesto
        '
        '
        '
        '
        Me.txtPuesto.Border.Class = "TextBoxBorder"
        Me.txtPuesto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPuesto.Enabled = False
        Me.txtPuesto.Location = New System.Drawing.Point(382, 208)
        Me.txtPuesto.Name = "txtPuesto"
        Me.txtPuesto.PreventEnterBeep = True
        Me.txtPuesto.Size = New System.Drawing.Size(298, 20)
        Me.txtPuesto.TabIndex = 110
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 238)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 15)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "Nombre"
        '
        'txtNombres
        '
        '
        '
        '
        Me.txtNombres.Border.Class = "TextBoxBorder"
        Me.txtNombres.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombres.Enabled = False
        Me.txtNombres.Location = New System.Drawing.Point(18, 256)
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.PreventEnterBeep = True
        Me.txtNombres.Size = New System.Drawing.Size(298, 20)
        Me.txtNombres.TabIndex = 108
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 190)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 15)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "No. de Nómina"
        '
        'txtNoReloj
        '
        '
        '
        '
        Me.txtNoReloj.Border.Class = "TextBoxBorder"
        Me.txtNoReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNoReloj.Enabled = False
        Me.txtNoReloj.Location = New System.Drawing.Point(18, 208)
        Me.txtNoReloj.Name = "txtNoReloj"
        Me.txtNoReloj.PreventEnterBeep = True
        Me.txtNoReloj.Size = New System.Drawing.Size(114, 20)
        Me.txtNoReloj.TabIndex = 106
        '
        'btnVerPDF
        '
        Me.btnVerPDF.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnVerPDF.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnVerPDF.Location = New System.Drawing.Point(354, 73)
        Me.btnVerPDF.Name = "btnVerPDF"
        Me.btnVerPDF.Size = New System.Drawing.Size(75, 20)
        Me.btnVerPDF.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnVerPDF.TabIndex = 105
        Me.btnVerPDF.Text = "Ver PDF"
        '
        'btnSubirPDF
        '
        Me.btnSubirPDF.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSubirPDF.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSubirPDF.Location = New System.Drawing.Point(322, 73)
        Me.btnSubirPDF.Name = "btnSubirPDF"
        Me.btnSubirPDF.Size = New System.Drawing.Size(26, 21)
        Me.btnSubirPDF.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSubirPDF.TabIndex = 104
        Me.btnSubirPDF.Text = "..."
        '
        'txtPDF
        '
        '
        '
        '
        Me.txtPDF.Border.Class = "TextBoxBorder"
        Me.txtPDF.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPDF.Location = New System.Drawing.Point(18, 73)
        Me.txtPDF.Name = "txtPDF"
        Me.txtPDF.PreventEnterBeep = True
        Me.txtPDF.Size = New System.Drawing.Size(298, 20)
        Me.txtPDF.TabIndex = 103
        '
        'Label95
        '
        Me.Label95.AutoSize = True
        Me.Label95.BackColor = System.Drawing.SystemColors.Window
        Me.Label95.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label95.Location = New System.Drawing.Point(15, 55)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(73, 15)
        Me.Label95.TabIndex = 102
        Me.Label95.Text = "Archivo PDF"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(183, 15)
        Me.Label7.TabIndex = 42
        Me.Label7.Text = "Fecha de presentación de queja"
        '
        'dtimeFecha
        '
        '
        '
        '
        Me.dtimeFecha.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtimeFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtimeFecha.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtimeFecha.ButtonDropDown.Visible = True
        Me.dtimeFecha.IsPopupCalendarOpen = False
        Me.dtimeFecha.Location = New System.Drawing.Point(18, 32)
        '
        '
        '
        Me.dtimeFecha.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtimeFecha.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtimeFecha.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtimeFecha.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.dtimeFecha.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtimeFecha.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtimeFecha.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtimeFecha.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtimeFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtimeFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtimeFecha.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtimeFecha.MonthCalendar.DisplayMonth = New Date(2016, 7, 1, 0, 0, 0, 0)
        Me.dtimeFecha.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtimeFecha.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtimeFecha.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtimeFecha.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtimeFecha.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtimeFecha.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtimeFecha.MonthCalendar.TodayButtonVisible = True
        Me.dtimeFecha.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtimeFecha.Name = "dtimeFecha"
        Me.dtimeFecha.Size = New System.Drawing.Size(215, 20)
        Me.dtimeFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtimeFecha.TabIndex = 41
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.ColumnName = "nombre"
        Me.ColumnHeader6.DataFieldName = "nombre"
        Me.ColumnHeader6.Name = "ColumnHeader6"
        Me.ColumnHeader6.Text = "Categoría"
        Me.ColumnHeader6.Width.Absolute = 150
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.ColumnName = "cod_categoria"
        Me.ColumnHeader7.DataFieldName = "cod_categoria"
        Me.ColumnHeader7.Name = "ColumnHeader7"
        Me.ColumnHeader7.Text = "cod_categoria"
        Me.ColumnHeader7.Visible = False
        Me.ColumnHeader7.Width.Absolute = 150
        '
        'frmCapturaQuejas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(718, 627)
        Me.Controls.Add(Me.gpDatos)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.lblEstado)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCapturaQuejas"
        Me.Text = "Captura de quejas"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.gpDatos.ResumeLayout(False)
        Me.gpDatos.PerformLayout()
        CType(Me.dtimeFecha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtComentSupervisor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtComentEmpleado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbMotivo As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents ColumnHeader1 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader2 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader3 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader5 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblEstado As DevComponents.DotNetBar.LabelX
    Friend WithEvents gpDatos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtimeFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents ColumnHeader6 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColumnHeader7 As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents btnSubirPDF As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtPDF As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label95 As System.Windows.Forms.Label
    Friend WithEvents btnVerPDF As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDepartamento As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPuesto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNombres As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtNoReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
End Class
