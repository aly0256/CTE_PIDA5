<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DetallesVisita
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PanelEditable = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.campoFolio = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.campoResponsable = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.comboPato3 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.comboPato2 = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.comboPato = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.comboDuracion = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cbAccTray = New System.Windows.Forms.CheckBox()
        Me.cbAccTrab = New System.Windows.Forms.CheckBox()
        Me.cbPlanFam = New System.Windows.Forms.CheckBox()
        Me.campoCuracion_det = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.campoIyec_det = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.cbCuracion = New System.Windows.Forms.CheckBox()
        Me.cbInyeccion = New System.Windows.Forms.CheckBox()
        Me.cbConsulta = New System.Windows.Forms.CheckBox()
        Me.campoHora_entro = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.campoMedicamento = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.campoHora_salio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.campoComentario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnReceta = New DevComponents.DotNetBar.ButtonX()
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.GroupBox1.SuspendLayout()
        Me.PanelEditable.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnReceta)
        Me.GroupBox1.Controls.Add(Me.btnEditar)
        Me.GroupBox1.Controls.Add(Me.PanelEditable)
        Me.GroupBox1.Controls.Add(Me.btnCerrar)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(765, 360)
        Me.GroupBox1.TabIndex = 2016
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalles de la Visita"
        '
        'PanelEditable
        '
        Me.PanelEditable.Controls.Add(Me.Label2)
        Me.PanelEditable.Controls.Add(Me.campoFolio)
        Me.PanelEditable.Controls.Add(Me.Label1)
        Me.PanelEditable.Controls.Add(Me.Label3)
        Me.PanelEditable.Controls.Add(Me.dtpFecha)
        Me.PanelEditable.Controls.Add(Me.campoResponsable)
        Me.PanelEditable.Controls.Add(Me.GroupBox2)
        Me.PanelEditable.Controls.Add(Me.comboDuracion)
        Me.PanelEditable.Controls.Add(Me.GroupBox3)
        Me.PanelEditable.Controls.Add(Me.cbConsulta)
        Me.PanelEditable.Controls.Add(Me.campoHora_entro)
        Me.PanelEditable.Controls.Add(Me.Label24)
        Me.PanelEditable.Controls.Add(Me.Label8)
        Me.PanelEditable.Controls.Add(Me.campoMedicamento)
        Me.PanelEditable.Controls.Add(Me.campoHora_salio)
        Me.PanelEditable.Controls.Add(Me.Label23)
        Me.PanelEditable.Controls.Add(Me.Label10)
        Me.PanelEditable.Controls.Add(Me.campoComentario)
        Me.PanelEditable.Controls.Add(Me.Label11)
        Me.PanelEditable.Location = New System.Drawing.Point(3, 19)
        Me.PanelEditable.Name = "PanelEditable"
        Me.PanelEditable.Size = New System.Drawing.Size(756, 298)
        Me.PanelEditable.TabIndex = 2043
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(3, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 2009
        Me.Label2.Text = "Responsable"
        '
        'campoFolio
        '
        Me.campoFolio.Enabled = False
        Me.campoFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.campoFolio.Location = New System.Drawing.Point(653, 27)
        Me.campoFolio.Name = "campoFolio"
        Me.campoFolio.Size = New System.Drawing.Size(100, 20)
        Me.campoFolio.TabIndex = 2042
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(610, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 2008
        Me.Label1.Text = "Fecha"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(724, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 2041
        Me.Label3.Text = "Folio"
        '
        'dtpFecha
        '
        Me.dtpFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFecha.Enabled = False
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(547, 27)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(100, 20)
        Me.dtpFecha.TabIndex = 2007
        '
        'campoResponsable
        '
        Me.campoResponsable.Enabled = False
        Me.campoResponsable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.campoResponsable.Location = New System.Drawing.Point(3, 27)
        Me.campoResponsable.Name = "campoResponsable"
        Me.campoResponsable.Size = New System.Drawing.Size(100, 20)
        Me.campoResponsable.TabIndex = 2010
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.comboPato3)
        Me.GroupBox2.Controls.Add(Me.comboPato2)
        Me.GroupBox2.Controls.Add(Me.comboPato)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Location = New System.Drawing.Point(159, 56)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(134, 235)
        Me.GroupBox2.TabIndex = 2013
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Causas/Patologías"
        '
        'comboPato3
        '
        Me.comboPato3.DisplayMember = "Text"
        Me.comboPato3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.comboPato3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboPato3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.comboPato3.FormattingEnabled = True
        Me.comboPato3.ItemHeight = 14
        Me.comboPato3.Location = New System.Drawing.Point(9, 131)
        Me.comboPato3.Name = "comboPato3"
        Me.comboPato3.Size = New System.Drawing.Size(117, 20)
        Me.comboPato3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.comboPato3.TabIndex = 335
        '
        'comboPato2
        '
        Me.comboPato2.DisplayMember = "Text"
        Me.comboPato2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.comboPato2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboPato2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.comboPato2.FormattingEnabled = True
        Me.comboPato2.ItemHeight = 14
        Me.comboPato2.Location = New System.Drawing.Point(9, 85)
        Me.comboPato2.Name = "comboPato2"
        Me.comboPato2.Size = New System.Drawing.Size(117, 20)
        Me.comboPato2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.comboPato2.TabIndex = 334
        '
        'comboPato
        '
        Me.comboPato.DisplayMember = "Text"
        Me.comboPato.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.comboPato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboPato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.comboPato.FormattingEnabled = True
        Me.comboPato.ItemHeight = 14
        Me.comboPato.Location = New System.Drawing.Point(9, 39)
        Me.comboPato.Name = "comboPato"
        Me.comboPato.Size = New System.Drawing.Size(117, 20)
        Me.comboPato.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.comboPato.TabIndex = 333
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(6, 115)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(62, 13)
        Me.Label20.TabIndex = 332
        Me.Label20.Text = "Patología 3"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(6, 69)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(62, 13)
        Me.Label19.TabIndex = 331
        Me.Label19.Text = "Patología 2"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(6, 23)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(62, 13)
        Me.Label18.TabIndex = 330
        Me.Label18.Text = "Patología 1"
        '
        'comboDuracion
        '
        Me.comboDuracion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.comboDuracion.DisplayMember = "Text"
        Me.comboDuracion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.comboDuracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.comboDuracion.FormattingEnabled = True
        Me.comboDuracion.ItemHeight = 14
        Me.comboDuracion.Location = New System.Drawing.Point(653, 271)
        Me.comboDuracion.Name = "comboDuracion"
        Me.comboDuracion.Size = New System.Drawing.Size(100, 20)
        Me.comboDuracion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.comboDuracion.TabIndex = 2038
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbAccTray)
        Me.GroupBox3.Controls.Add(Me.cbAccTrab)
        Me.GroupBox3.Controls.Add(Me.cbPlanFam)
        Me.GroupBox3.Controls.Add(Me.campoCuracion_det)
        Me.GroupBox3.Controls.Add(Me.campoIyec_det)
        Me.GroupBox3.Controls.Add(Me.cbCuracion)
        Me.GroupBox3.Controls.Add(Me.cbInyeccion)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 56)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(153, 235)
        Me.GroupBox3.TabIndex = 2014
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Asistencia"
        '
        'cbAccTray
        '
        Me.cbAccTray.AutoSize = True
        Me.cbAccTray.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cbAccTray.Location = New System.Drawing.Point(6, 197)
        Me.cbAccTray.Name = "cbAccTray"
        Me.cbAccTray.Size = New System.Drawing.Size(134, 17)
        Me.cbAccTray.TabIndex = 332
        Me.cbAccTray.Text = "Accidente de Trayecto"
        Me.cbAccTray.UseVisualStyleBackColor = True
        '
        'cbAccTrab
        '
        Me.cbAccTrab.AutoSize = True
        Me.cbAccTrab.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cbAccTrab.Location = New System.Drawing.Point(6, 164)
        Me.cbAccTrab.Name = "cbAccTrab"
        Me.cbAccTrab.Size = New System.Drawing.Size(128, 17)
        Me.cbAccTrab.TabIndex = 330
        Me.cbAccTrab.Text = "Accidente de Trabajo"
        Me.cbAccTrab.UseVisualStyleBackColor = True
        '
        'cbPlanFam
        '
        Me.cbPlanFam.AutoSize = True
        Me.cbPlanFam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cbPlanFam.Location = New System.Drawing.Point(6, 131)
        Me.cbPlanFam.Name = "cbPlanFam"
        Me.cbPlanFam.Size = New System.Drawing.Size(124, 17)
        Me.cbPlanFam.TabIndex = 328
        Me.cbPlanFam.Text = "Planificación Familiar"
        Me.cbPlanFam.UseVisualStyleBackColor = True
        '
        'campoCuracion_det
        '
        Me.campoCuracion_det.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.campoCuracion_det.Border.Class = "TextBoxBorder"
        Me.campoCuracion_det.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.campoCuracion_det.Enabled = False
        Me.campoCuracion_det.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.campoCuracion_det.ForeColor = System.Drawing.Color.Black
        Me.campoCuracion_det.Location = New System.Drawing.Point(6, 85)
        Me.campoCuracion_det.Name = "campoCuracion_det"
        Me.campoCuracion_det.Size = New System.Drawing.Size(141, 20)
        Me.campoCuracion_det.TabIndex = 327
        '
        'campoIyec_det
        '
        Me.campoIyec_det.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.campoIyec_det.Border.Class = "TextBoxBorder"
        Me.campoIyec_det.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.campoIyec_det.Enabled = False
        Me.campoIyec_det.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.campoIyec_det.ForeColor = System.Drawing.Color.Black
        Me.campoIyec_det.Location = New System.Drawing.Point(6, 39)
        Me.campoIyec_det.Name = "campoIyec_det"
        Me.campoIyec_det.Size = New System.Drawing.Size(141, 20)
        Me.campoIyec_det.TabIndex = 324
        '
        'cbCuracion
        '
        Me.cbCuracion.AutoSize = True
        Me.cbCuracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cbCuracion.Location = New System.Drawing.Point(6, 65)
        Me.cbCuracion.Name = "cbCuracion"
        Me.cbCuracion.Size = New System.Drawing.Size(68, 17)
        Me.cbCuracion.TabIndex = 323
        Me.cbCuracion.Text = "Curación"
        Me.cbCuracion.UseVisualStyleBackColor = True
        '
        'cbInyeccion
        '
        Me.cbInyeccion.AutoSize = True
        Me.cbInyeccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cbInyeccion.Location = New System.Drawing.Point(6, 19)
        Me.cbInyeccion.Name = "cbInyeccion"
        Me.cbInyeccion.Size = New System.Drawing.Size(72, 17)
        Me.cbInyeccion.TabIndex = 322
        Me.cbInyeccion.Text = "Inyección"
        Me.cbInyeccion.UseVisualStyleBackColor = True
        '
        'cbConsulta
        '
        Me.cbConsulta.AutoSize = True
        Me.cbConsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.cbConsulta.Location = New System.Drawing.Point(302, 152)
        Me.cbConsulta.Name = "cbConsulta"
        Me.cbConsulta.Size = New System.Drawing.Size(171, 17)
        Me.cbConsulta.TabIndex = 2036
        Me.cbConsulta.Text = "Pasó a consulta con el médico"
        Me.cbConsulta.UseVisualStyleBackColor = True
        '
        'campoHora_entro
        '
        Me.campoHora_entro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.campoHora_entro.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.campoHora_entro.Border.Class = "TextBoxBorder"
        Me.campoHora_entro.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.campoHora_entro.Enabled = False
        Me.campoHora_entro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.campoHora_entro.ForeColor = System.Drawing.Color.Black
        Me.campoHora_entro.Location = New System.Drawing.Point(653, 187)
        Me.campoHora_entro.Name = "campoHora_entro"
        Me.campoHora_entro.ReadOnly = True
        Me.campoHora_entro.Size = New System.Drawing.Size(100, 20)
        Me.campoHora_entro.TabIndex = 2027
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(299, 171)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(71, 13)
        Me.Label24.TabIndex = 2035
        Me.Label24.Text = "Medicamento"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(707, 171)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 13)
        Me.Label8.TabIndex = 2028
        Me.Label8.Text = "Entrada"
        '
        'campoMedicamento
        '
        Me.campoMedicamento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.campoMedicamento.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.campoMedicamento.Border.Class = "TextBoxBorder"
        Me.campoMedicamento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.campoMedicamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.campoMedicamento.ForeColor = System.Drawing.Color.Black
        Me.campoMedicamento.Location = New System.Drawing.Point(299, 187)
        Me.campoMedicamento.Multiline = True
        Me.campoMedicamento.Name = "campoMedicamento"
        Me.campoMedicamento.Size = New System.Drawing.Size(348, 104)
        Me.campoMedicamento.TabIndex = 2034
        '
        'campoHora_salio
        '
        Me.campoHora_salio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.campoHora_salio.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.campoHora_salio.Border.Class = "TextBoxBorder"
        Me.campoHora_salio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.campoHora_salio.Enabled = False
        Me.campoHora_salio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.campoHora_salio.ForeColor = System.Drawing.Color.Black
        Me.campoHora_salio.Location = New System.Drawing.Point(653, 226)
        Me.campoHora_salio.Name = "campoHora_salio"
        Me.campoHora_salio.ReadOnly = True
        Me.campoHora_salio.Size = New System.Drawing.Size(100, 20)
        Me.campoHora_salio.TabIndex = 2029
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(299, 56)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(60, 13)
        Me.Label23.TabIndex = 2033
        Me.Label23.Text = "Comentario"
        '
        'Label10
        '
        Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(712, 210)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 13)
        Me.Label10.TabIndex = 2030
        Me.Label10.Text = " Salida"
        '
        'campoComentario
        '
        Me.campoComentario.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.campoComentario.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.campoComentario.Border.Class = "TextBoxBorder"
        Me.campoComentario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.campoComentario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.campoComentario.ForeColor = System.Drawing.Color.Black
        Me.campoComentario.Location = New System.Drawing.Point(299, 72)
        Me.campoComentario.Multiline = True
        Me.campoComentario.Name = "campoComentario"
        Me.campoComentario.Size = New System.Drawing.Size(454, 74)
        Me.campoComentario.TabIndex = 2032
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(703, 257)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(50, 13)
        Me.Label11.TabIndex = 2031
        Me.Label11.Text = "Duración"
        '
        'btnReceta
        '
        Me.btnReceta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReceta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReceta.CausesValidation = False
        Me.btnReceta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReceta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReceta.Image = Global.PIDA.NET.My.Resources.Resources.sermed_reloj
        Me.btnReceta.Location = New System.Drawing.Point(544, 329)
        Me.btnReceta.Name = "btnReceta"
        Me.btnReceta.Size = New System.Drawing.Size(90, 25)
        Me.btnReceta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReceta.TabIndex = 2048
        Me.btnReceta.Text = "Terminar"
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = Global.PIDA.NET.My.Resources.Resources.Edit
        Me.btnEditar.Location = New System.Drawing.Point(6, 329)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(90, 25)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 2047
        Me.btnEditar.Text = "Editar"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.NET.My.Resources.Resources.sermed_guardar
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(640, 329)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(119, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 2040
        Me.btnCerrar.Text = "Guardar y Salir"
        '
        'DetallesVisita
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "DetallesVisita"
        Me.Size = New System.Drawing.Size(765, 360)
        Me.GroupBox1.ResumeLayout(False)
        Me.PanelEditable.ResumeLayout(False)
        Me.PanelEditable.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents campoResponsable As System.Windows.Forms.TextBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents comboPato3 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents comboPato2 As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents comboPato As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cbAccTray As System.Windows.Forms.CheckBox
    Friend WithEvents cbAccTrab As System.Windows.Forms.CheckBox
    Friend WithEvents cbPlanFam As System.Windows.Forms.CheckBox
    Friend WithEvents campoCuracion_det As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents campoIyec_det As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents cbCuracion As System.Windows.Forms.CheckBox
    Friend WithEvents cbInyeccion As System.Windows.Forms.CheckBox
    Friend WithEvents comboDuracion As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cbConsulta As System.Windows.Forms.CheckBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents campoMedicamento As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents campoComentario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents campoHora_salio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents campoHora_entro As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents campoFolio As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PanelEditable As System.Windows.Forms.Panel
    Friend WithEvents btnReceta As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonX

End Class
