<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCapturaCursosMasivos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapturaCursosMasivos))
        Me.ElementStyle2 = New DevComponents.DotNetBar.ElementStyle()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dlgArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.ElementStyle1 = New DevComponents.DotNetBar.ElementStyle()
        Me.ElementStyle3 = New DevComponents.DotNetBar.ElementStyle()
        Me.gpSueldos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.btnBuscaLista = New DevComponents.DotNetBar.ButtonX()
        Me.txtLista = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnLista = New System.Windows.Forms.RadioButton()
        Me.btnArchivo = New System.Windows.Forms.RadioButton()
        Me.btnBuscaArchivo = New DevComponents.DotNetBar.ButtonX()
        Me.txtArchivo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.cpActualizacion = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.lblaprobado = New DevComponents.DotNetBar.LabelX()
        Me.lblcalifminima = New System.Windows.Forms.Label()
        Me.txtDuracion = New DevComponents.Editors.DoubleInput()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnAprobado = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtComentario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtCalificacion = New DevComponents.Editors.DoubleInput()
        Me.txtFechaFin = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.txtFechaInicio = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.cmbInstructor = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.colCodInstructor = New DevComponents.AdvTree.ColumnHeader()
        Me.colNombreInstructor = New DevComponents.AdvTree.ColumnHeader()
        Me.cmbInstituto = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.colCodInstituto = New DevComponents.AdvTree.ColumnHeader()
        Me.colNombreInstituto = New DevComponents.AdvTree.ColumnHeader()
        Me.cmbCurso = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.colCodCurso = New DevComponents.AdvTree.ColumnHeader()
        Me.colNombreCurso = New DevComponents.AdvTree.ColumnHeader()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.gpSueldos.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.txtDuracion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCalificacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFechaInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ElementStyle2
        '
        Me.ElementStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ElementStyle2.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ElementStyle2.BackColorGradientAngle = 90
        Me.ElementStyle2.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderBottomWidth = 1
        Me.ElementStyle2.BorderColor = System.Drawing.Color.DarkGray
        Me.ElementStyle2.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderLeftWidth = 1
        Me.ElementStyle2.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderRightWidth = 1
        Me.ElementStyle2.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle2.BorderTopWidth = 1
        Me.ElementStyle2.CornerDiameter = 4
        Me.ElementStyle2.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle2.Description = "BlueLight"
        Me.ElementStyle2.Name = "ElementStyle2"
        Me.ElementStyle2.PaddingBottom = 1
        Me.ElementStyle2.PaddingLeft = 1
        Me.ElementStyle2.PaddingRight = 1
        Me.ElementStyle2.PaddingTop = 1
        Me.ElementStyle2.TextColor = System.Drawing.Color.FromArgb(CType(CType(69, Byte), Integer), CType(CType(84, Byte), Integer), CType(CType(115, Byte), Integer))
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
        Me.btnCancelar.Location = New System.Drawing.Point(88, 14)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Text = "Cancelar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAceptar)
        Me.GroupBox1.Controls.Add(Me.btnCancelar)
        Me.GroupBox1.Location = New System.Drawing.Point(249, 475)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(174, 47)
        Me.GroupBox1.TabIndex = 122
        Me.GroupBox1.TabStop = False
        '
        'dlgArchivo
        '
        Me.dlgArchivo.FileName = "OpenFileDialog1"
        '
        'ElementStyle1
        '
        Me.ElementStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.ElementStyle1.BackColor2 = System.Drawing.Color.Navy
        Me.ElementStyle1.BackColorGradientAngle = 90
        Me.ElementStyle1.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderBottomWidth = 1
        Me.ElementStyle1.BorderColor = System.Drawing.Color.Navy
        Me.ElementStyle1.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderLeftWidth = 1
        Me.ElementStyle1.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderRightWidth = 1
        Me.ElementStyle1.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.ElementStyle1.BorderTopWidth = 1
        Me.ElementStyle1.CornerDiameter = 4
        Me.ElementStyle1.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ElementStyle1.Description = "BlueNight"
        Me.ElementStyle1.Name = "ElementStyle1"
        Me.ElementStyle1.PaddingBottom = 1
        Me.ElementStyle1.PaddingLeft = 1
        Me.ElementStyle1.PaddingRight = 1
        Me.ElementStyle1.PaddingTop = 1
        Me.ElementStyle1.TextColor = System.Drawing.SystemColors.Window
        '
        'ElementStyle3
        '
        Me.ElementStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(247, Byte), Integer))
        Me.ElementStyle3.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(138, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(228, Byte), Integer))
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
        Me.ElementStyle3.Name = "ElementStyle3"
        Me.ElementStyle3.PaddingBottom = 1
        Me.ElementStyle3.PaddingLeft = 1
        Me.ElementStyle3.PaddingRight = 1
        Me.ElementStyle3.PaddingTop = 1
        Me.ElementStyle3.TextColor = System.Drawing.Color.Black
        '
        'gpSueldos
        '
        Me.gpSueldos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpSueldos.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpSueldos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpSueldos.Controls.Add(Me.btnBuscaLista)
        Me.gpSueldos.Controls.Add(Me.txtLista)
        Me.gpSueldos.Controls.Add(Me.btnLista)
        Me.gpSueldos.Controls.Add(Me.btnArchivo)
        Me.gpSueldos.Controls.Add(Me.btnBuscaArchivo)
        Me.gpSueldos.Controls.Add(Me.txtArchivo)
        Me.gpSueldos.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpSueldos.Location = New System.Drawing.Point(14, 67)
        Me.gpSueldos.Name = "gpSueldos"
        Me.gpSueldos.Size = New System.Drawing.Size(409, 163)
        '
        '
        '
        Me.gpSueldos.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpSueldos.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpSueldos.Style.BackColorGradientAngle = 90
        Me.gpSueldos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpSueldos.Style.BorderBottomWidth = 1
        Me.gpSueldos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpSueldos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpSueldos.Style.BorderLeftWidth = 1
        Me.gpSueldos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpSueldos.Style.BorderRightWidth = 1
        Me.gpSueldos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpSueldos.Style.BorderTopWidth = 1
        Me.gpSueldos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpSueldos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpSueldos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpSueldos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpSueldos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpSueldos.TabIndex = 118
        Me.gpSueldos.Text = "Empleados a asignar"
        '
        'btnBuscaLista
        '
        Me.btnBuscaLista.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscaLista.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscaLista.Enabled = False
        Me.btnBuscaLista.Location = New System.Drawing.Point(365, 83)
        Me.btnBuscaLista.Name = "btnBuscaLista"
        Me.btnBuscaLista.Size = New System.Drawing.Size(26, 23)
        Me.btnBuscaLista.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscaLista.TabIndex = 5
        Me.btnBuscaLista.Text = "..."
        '
        'txtLista
        '
        Me.txtLista.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtLista.Border.Class = "TextBoxBorder"
        Me.txtLista.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtLista.Enabled = False
        Me.txtLista.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLista.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtLista.Location = New System.Drawing.Point(26, 83)
        Me.txtLista.Multiline = True
        Me.txtLista.Name = "txtLista"
        Me.txtLista.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLista.Size = New System.Drawing.Size(333, 52)
        Me.txtLista.TabIndex = 4
        '
        'btnLista
        '
        Me.btnLista.AutoSize = True
        Me.btnLista.BackColor = System.Drawing.SystemColors.Window
        Me.btnLista.Location = New System.Drawing.Point(7, 63)
        Me.btnLista.Name = "btnLista"
        Me.btnLista.Size = New System.Drawing.Size(232, 17)
        Me.btnLista.TabIndex = 3
        Me.btnLista.Text = "Listar números de reloj, separados por coma"
        Me.btnLista.UseVisualStyleBackColor = False
        '
        'btnArchivo
        '
        Me.btnArchivo.AutoSize = True
        Me.btnArchivo.BackColor = System.Drawing.SystemColors.Window
        Me.btnArchivo.Checked = True
        Me.btnArchivo.Location = New System.Drawing.Point(7, 13)
        Me.btnArchivo.Name = "btnArchivo"
        Me.btnArchivo.Size = New System.Drawing.Size(201, 17)
        Me.btnArchivo.TabIndex = 0
        Me.btnArchivo.TabStop = True
        Me.btnArchivo.Text = "Buscar en archivo (reloj - calificación)"
        Me.btnArchivo.UseVisualStyleBackColor = False
        '
        'btnBuscaArchivo
        '
        Me.btnBuscaArchivo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscaArchivo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscaArchivo.Location = New System.Drawing.Point(365, 33)
        Me.btnBuscaArchivo.Name = "btnBuscaArchivo"
        Me.btnBuscaArchivo.Size = New System.Drawing.Size(26, 23)
        Me.btnBuscaArchivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscaArchivo.TabIndex = 2
        Me.btnBuscaArchivo.Text = "..."
        '
        'txtArchivo
        '
        Me.txtArchivo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtArchivo.Border.Class = "TextBoxBorder"
        Me.txtArchivo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtArchivo.Location = New System.Drawing.Point(26, 33)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.Size = New System.Drawing.Size(333, 23)
        Me.txtArchivo.TabIndex = 1
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(52, 14)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(451, 46)
        Me.ReflectionLabel1.TabIndex = 120
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CAPTURA DE CURSO POR GRUPO</b></font>"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.AjustesMasivos32
        Me.picImagen.Location = New System.Drawing.Point(14, 14)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(31, 30)
        Me.picImagen.TabIndex = 121
        Me.picImagen.TabStop = False
        '
        'cpActualizacion
        '
        '
        '
        '
        Me.cpActualizacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cpActualizacion.Location = New System.Drawing.Point(14, 482)
        Me.cpActualizacion.Name = "cpActualizacion"
        Me.cpActualizacion.Size = New System.Drawing.Size(229, 40)
        Me.cpActualizacion.TabIndex = 123
        Me.cpActualizacion.Text = "Reloj"
        Me.cpActualizacion.TextVisible = True
        Me.cpActualizacion.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel1.Controls.Add(Me.lblaprobado)
        Me.GroupPanel1.Controls.Add(Me.lblcalifminima)
        Me.GroupPanel1.Controls.Add(Me.txtDuracion)
        Me.GroupPanel1.Controls.Add(Me.Label5)
        Me.GroupPanel1.Controls.Add(Me.btnAprobado)
        Me.GroupPanel1.Controls.Add(Me.Label8)
        Me.GroupPanel1.Controls.Add(Me.txtComentario)
        Me.GroupPanel1.Controls.Add(Me.txtCalificacion)
        Me.GroupPanel1.Controls.Add(Me.txtFechaFin)
        Me.GroupPanel1.Controls.Add(Me.txtFechaInicio)
        Me.GroupPanel1.Controls.Add(Me.cmbInstructor)
        Me.GroupPanel1.Controls.Add(Me.cmbInstituto)
        Me.GroupPanel1.Controls.Add(Me.cmbCurso)
        Me.GroupPanel1.Controls.Add(Me.Label9)
        Me.GroupPanel1.Controls.Add(Me.Label4)
        Me.GroupPanel1.Controls.Add(Me.Label7)
        Me.GroupPanel1.Controls.Add(Me.Label6)
        Me.GroupPanel1.Controls.Add(Me.Label3)
        Me.GroupPanel1.Controls.Add(Me.Label2)
        Me.GroupPanel1.Controls.Add(Me.Label1)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(14, 236)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(409, 233)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor = System.Drawing.SystemColors.Window
        Me.GroupPanel1.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 119
        Me.GroupPanel1.Text = "Información"
        '
        'lblaprobado
        '
        Me.lblaprobado.BackColor = System.Drawing.SystemColors.ButtonHighlight
        '
        '
        '
        Me.lblaprobado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblaprobado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblaprobado.Location = New System.Drawing.Point(308, 116)
        Me.lblaprobado.Name = "lblaprobado"
        Me.lblaprobado.Size = New System.Drawing.Size(83, 23)
        Me.lblaprobado.TabIndex = 171
        Me.lblaprobado.Text = "AP"
        '
        'lblcalifminima
        '
        Me.lblcalifminima.AutoSize = True
        Me.lblcalifminima.BackColor = System.Drawing.SystemColors.Window
        Me.lblcalifminima.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcalifminima.Location = New System.Drawing.Point(160, 124)
        Me.lblcalifminima.Name = "lblcalifminima"
        Me.lblcalifminima.Size = New System.Drawing.Size(50, 13)
        Me.lblcalifminima.TabIndex = 170
        Me.lblcalifminima.Text = "Fecha fin"
        '
        'txtDuracion
        '
        '
        '
        '
        Me.txtDuracion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtDuracion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDuracion.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtDuracion.Increment = 1.0R
        Me.txtDuracion.Location = New System.Drawing.Point(78, 143)
        Me.txtDuracion.MaxValue = 999.0R
        Me.txtDuracion.MinValue = 0.0R
        Me.txtDuracion.Name = "txtDuracion"
        Me.txtDuracion.ShowUpDown = True
        Me.txtDuracion.Size = New System.Drawing.Size(83, 20)
        Me.txtDuracion.TabIndex = 162
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Location = New System.Drawing.Point(3, 147)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 163
        Me.Label5.Text = "Duración"
        '
        'btnAprobado
        '
        '
        '
        '
        Me.btnAprobado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.btnAprobado.IsReadOnly = True
        Me.btnAprobado.Location = New System.Drawing.Point(308, 117)
        Me.btnAprobado.Name = "btnAprobado"
        Me.btnAprobado.OffText = "No"
        Me.btnAprobado.OnText = "Si"
        Me.btnAprobado.Size = New System.Drawing.Size(83, 20)
        Me.btnAprobado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAprobado.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Window
        Me.Label8.Location = New System.Drawing.Point(233, 122)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 161
        Me.Label8.Text = "Aprobado"
        '
        'txtComentario
        '
        '
        '
        '
        Me.txtComentario.Border.Class = "TextBoxBorder"
        Me.txtComentario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtComentario.Location = New System.Drawing.Point(78, 169)
        Me.txtComentario.Multiline = True
        Me.txtComentario.Name = "txtComentario"
        Me.txtComentario.Size = New System.Drawing.Size(313, 35)
        Me.txtComentario.TabIndex = 7
        '
        'txtCalificacion
        '
        '
        '
        '
        Me.txtCalificacion.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtCalificacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCalificacion.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtCalificacion.Increment = 5.0R
        Me.txtCalificacion.Location = New System.Drawing.Point(78, 117)
        Me.txtCalificacion.MaxValue = 100.0R
        Me.txtCalificacion.MinValue = 0.0R
        Me.txtCalificacion.Name = "txtCalificacion"
        Me.txtCalificacion.ShowUpDown = True
        Me.txtCalificacion.Size = New System.Drawing.Size(83, 20)
        Me.txtCalificacion.TabIndex = 5
        '
        'txtFechaFin
        '
        '
        '
        '
        Me.txtFechaFin.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaFin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtFechaFin.ButtonDropDown.Visible = True
        Me.txtFechaFin.IsPopupCalendarOpen = False
        Me.txtFechaFin.Location = New System.Drawing.Point(308, 91)
        '
        '
        '
        Me.txtFechaFin.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaFin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFin.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtFechaFin.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaFin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFin.MonthCalendar.DisplayMonth = New Date(2014, 5, 1, 0, 0, 0, 0)
        Me.txtFechaFin.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaFin.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaFin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaFin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFin.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaFin.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFechaFin.Name = "txtFechaFin"
        Me.txtFechaFin.Size = New System.Drawing.Size(83, 20)
        Me.txtFechaFin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFechaFin.TabIndex = 4
        '
        'txtFechaInicio
        '
        '
        '
        '
        Me.txtFechaInicio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtFechaInicio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaInicio.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtFechaInicio.ButtonDropDown.Visible = True
        Me.txtFechaInicio.IsPopupCalendarOpen = False
        Me.txtFechaInicio.Location = New System.Drawing.Point(78, 91)
        '
        '
        '
        Me.txtFechaInicio.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaInicio.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaInicio.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtFechaInicio.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtFechaInicio.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaInicio.MonthCalendar.DisplayMonth = New Date(2014, 5, 1, 0, 0, 0, 0)
        Me.txtFechaInicio.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtFechaInicio.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtFechaInicio.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtFechaInicio.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaInicio.MonthCalendar.TodayButtonVisible = True
        Me.txtFechaInicio.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtFechaInicio.Name = "txtFechaInicio"
        Me.txtFechaInicio.Size = New System.Drawing.Size(83, 20)
        Me.txtFechaInicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtFechaInicio.TabIndex = 3
        '
        'cmbInstructor
        '
        Me.cmbInstructor.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbInstructor.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbInstructor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbInstructor.ButtonCustom.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.cmbInstructor.ButtonCustom.Visible = True
        Me.cmbInstructor.ButtonDropDown.Visible = True
        Me.cmbInstructor.Columns.Add(Me.colCodInstructor)
        Me.cmbInstructor.Columns.Add(Me.colNombreInstructor)
        Me.cmbInstructor.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbInstructor.Location = New System.Drawing.Point(78, 62)
        Me.cmbInstructor.Name = "cmbInstructor"
        Me.cmbInstructor.Size = New System.Drawing.Size(313, 23)
        Me.cmbInstructor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbInstructor.TabIndex = 2
        Me.cmbInstructor.ValueMember = "cod_instructor"
        '
        'colCodInstructor
        '
        Me.colCodInstructor.ColumnName = "colCodInstructor"
        Me.colCodInstructor.DataFieldName = "cod_instructor"
        Me.colCodInstructor.Name = "colCodInstructor"
        Me.colCodInstructor.Text = "Código"
        Me.colCodInstructor.Width.Relative = 30
        '
        'colNombreInstructor
        '
        Me.colNombreInstructor.ColumnName = "colNombreInstructor"
        Me.colNombreInstructor.DataFieldName = "nombre"
        Me.colNombreInstructor.Name = "colNombreInstructor"
        Me.colNombreInstructor.Text = "Nombre"
        Me.colNombreInstructor.Width.Relative = 70
        '
        'cmbInstituto
        '
        Me.cmbInstituto.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbInstituto.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbInstituto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbInstituto.ButtonCustom.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.cmbInstituto.ButtonCustom.Visible = True
        Me.cmbInstituto.ButtonDropDown.Visible = True
        Me.cmbInstituto.Columns.Add(Me.colCodInstituto)
        Me.cmbInstituto.Columns.Add(Me.colNombreInstituto)
        Me.cmbInstituto.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbInstituto.Location = New System.Drawing.Point(78, 33)
        Me.cmbInstituto.Name = "cmbInstituto"
        Me.cmbInstituto.Size = New System.Drawing.Size(313, 23)
        Me.cmbInstituto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbInstituto.TabIndex = 1
        Me.cmbInstituto.ValueMember = "cod_instituto"
        '
        'colCodInstituto
        '
        Me.colCodInstituto.ColumnName = "colCodInstituto"
        Me.colCodInstituto.DataFieldName = "cod_instituto"
        Me.colCodInstituto.Name = "colCodInstituto"
        Me.colCodInstituto.Text = "Código"
        Me.colCodInstituto.Width.Relative = 30
        '
        'colNombreInstituto
        '
        Me.colNombreInstituto.ColumnName = "colNombreInstituto"
        Me.colNombreInstituto.DataFieldName = "nombre"
        Me.colNombreInstituto.Name = "colNombreInstituto"
        Me.colNombreInstituto.Text = "Nombre"
        Me.colNombreInstituto.Width.Relative = 70
        '
        'cmbCurso
        '
        Me.cmbCurso.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbCurso.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbCurso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbCurso.ButtonCustom.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.cmbCurso.ButtonCustom.Visible = True
        Me.cmbCurso.ButtonDropDown.Visible = True
        Me.cmbCurso.Columns.Add(Me.colCodCurso)
        Me.cmbCurso.Columns.Add(Me.colNombreCurso)
        Me.cmbCurso.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbCurso.Location = New System.Drawing.Point(78, 4)
        Me.cmbCurso.Name = "cmbCurso"
        Me.cmbCurso.Size = New System.Drawing.Size(313, 23)
        Me.cmbCurso.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbCurso.TabIndex = 0
        Me.cmbCurso.ValueMember = "cod_curso"
        '
        'colCodCurso
        '
        Me.colCodCurso.ColumnName = "colCodCurso"
        Me.colCodCurso.DataFieldName = "cod_curso"
        Me.colCodCurso.Name = "colCodCurso"
        Me.colCodCurso.Text = "Código"
        Me.colCodCurso.Width.Relative = 30
        '
        'colNombreCurso
        '
        Me.colNombreCurso.ColumnName = "colNombreCurso"
        Me.colNombreCurso.DataFieldName = "nombre"
        Me.colNombreCurso.Name = "colNombreCurso"
        Me.colNombreCurso.Text = "Nombre"
        Me.colNombreCurso.Width.Relative = 70
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Window
        Me.Label9.Location = New System.Drawing.Point(4, 169)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 13)
        Me.Label9.TabIndex = 153
        Me.Label9.Text = "Comentarios"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Location = New System.Drawing.Point(3, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 152
        Me.Label4.Text = "Calificación"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.SystemColors.Window
        Me.Label7.Location = New System.Drawing.Point(233, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 151
        Me.Label7.Text = "Fecha fin"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Location = New System.Drawing.Point(3, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 150
        Me.Label6.Text = "Fecha inicio"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Location = New System.Drawing.Point(3, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 149
        Me.Label3.Text = "Curso"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Location = New System.Drawing.Point(3, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 148
        Me.Label2.Text = "Instructor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Location = New System.Drawing.Point(3, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 147
        Me.Label1.Text = "Instituto"
        '
        'frmCapturaCursosMasivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 535)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpSueldos)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.picImagen)
        Me.Controls.Add(Me.cpActualizacion)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapturaCursosMasivos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Capturar grupo para curso"
        Me.GroupBox1.ResumeLayout(False)
        Me.gpSueldos.ResumeLayout(False)
        Me.gpSueldos.PerformLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.GroupPanel1.PerformLayout()
        CType(Me.txtDuracion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCalificacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFechaInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ElementStyle2 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dlgArchivo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ElementStyle1 As DevComponents.DotNetBar.ElementStyle
    Friend WithEvents ElementStyle3 As DevComponents.DotNetBar.ElementStyle
    Private WithEvents gpSueldos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btnBuscaLista As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtLista As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnLista As System.Windows.Forms.RadioButton
    Friend WithEvents btnArchivo As System.Windows.Forms.RadioButton
    Friend WithEvents btnBuscaArchivo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtArchivo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents cpActualizacion As DevComponents.DotNetBar.Controls.ProgressBarX
    Private WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents txtComentario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtCalificacion As DevComponents.Editors.DoubleInput
    Friend WithEvents txtFechaFin As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents txtFechaInicio As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents cmbInstructor As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cmbInstituto As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents cmbCurso As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAprobado As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents colCodInstructor As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colNombreInstructor As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colCodInstituto As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colNombreInstituto As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colCodCurso As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents colNombreCurso As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents txtDuracion As DevComponents.Editors.DoubleInput
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblaprobado As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblcalifminima As System.Windows.Forms.Label
End Class
