<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHorariosCafeteria
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHorariosCafeteria))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCodigo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tabEmpleado = New DevComponents.DotNetBar.SuperTabItem()
        Me.pnlDatos = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.cmbServicio = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.cmbTurno = New DevComponents.DotNetBar.Controls.ComboTree()
        Me.CodTurnocol = New DevComponents.AdvTree.ColumnHeader()
        Me.NomTurnoCol = New DevComponents.AdvTree.ColumnHeader()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gpAplica = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.swDomingo = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.swSabado = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.swViernes = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.swJueves = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.swMiercoles = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.swLunes = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.swMartes = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtHoraFin = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtHoraInicio = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.CodCia = New DevComponents.AdvTree.ColumnHeader()
        Me.NombreCia = New DevComponents.AdvTree.ColumnHeader()
        Me.CodTurno = New DevComponents.AdvTree.ColumnHeader()
        Me.NombreTurno = New DevComponents.AdvTree.ColumnHeader()
        Me.HorasTurno = New DevComponents.AdvTree.ColumnHeader()
        Me.SuperTabControlPanel2 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.dgTabla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.tabTabla = New DevComponents.DotNetBar.SuperTabItem()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.tabBuscar = New DevComponents.DotNetBar.SuperTabControl()
        Me.EmpNav = New System.Windows.Forms.GroupBox()
        Me.pnlControles = New System.Windows.Forms.Panel()
        Me.btnPrimero = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAnterior = New DevComponents.DotNetBar.ButtonX()
        Me.btnUltimo = New DevComponents.DotNetBar.ButtonX()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnSiguiente = New DevComponents.DotNetBar.ButtonX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbPlanta = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.J1 = New DevComponents.Editors.ComboItem()
        Me.J2 = New DevComponents.Editors.ComboItem()
        Me.NADA = New DevComponents.Editors.ComboItem()
        Me.pnlDatos.SuspendLayout()
        Me.gpAplica.SuspendLayout()
        CType(Me.txtHoraFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHoraInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControlPanel2.SuspendLayout()
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabBuscar.SuspendLayout()
        Me.EmpNav.SuspendLayout()
        Me.pnlControles.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Código de horario"
        '
        'txtCodigo
        '
        '
        '
        '
        Me.txtCodigo.Border.Class = "TextBoxBorder"
        Me.txtCodigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCodigo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtCodigo.Location = New System.Drawing.Point(179, 40)
        Me.txtCodigo.MaxLength = 10
        Me.txtCodigo.Name = "txtCodigo"
        Me.txtCodigo.Size = New System.Drawing.Size(144, 21)
        Me.txtCodigo.TabIndex = 1
        '
        'txtNombre
        '
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtNombre.Location = New System.Drawing.Point(179, 73)
        Me.txtNombre.MaxLength = 90
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(280, 21)
        Me.txtNombre.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nombre"
        '
        'tabEmpleado
        '
        Me.tabEmpleado.AttachedControl = Me.pnlDatos
        Me.tabEmpleado.GlobalItem = False
        Me.tabEmpleado.Name = "tabEmpleado"
        Me.tabEmpleado.Text = "Individual"
        '
        'pnlDatos
        '
        Me.pnlDatos.AutoSize = True
        Me.pnlDatos.Controls.Add(Me.cmbPlanta)
        Me.pnlDatos.Controls.Add(Me.Label6)
        Me.pnlDatos.Controls.Add(Me.cmbServicio)
        Me.pnlDatos.Controls.Add(Me.cmbTurno)
        Me.pnlDatos.Controls.Add(Me.Label15)
        Me.pnlDatos.Controls.Add(Me.Label4)
        Me.pnlDatos.Controls.Add(Me.gpAplica)
        Me.pnlDatos.Controls.Add(Me.Label5)
        Me.pnlDatos.Controls.Add(Me.txtHoraFin)
        Me.pnlDatos.Controls.Add(Me.Label3)
        Me.pnlDatos.Controls.Add(Me.txtHoraInicio)
        Me.pnlDatos.Controls.Add(Me.Label1)
        Me.pnlDatos.Controls.Add(Me.txtCodigo)
        Me.pnlDatos.Controls.Add(Me.txtNombre)
        Me.pnlDatos.Controls.Add(Me.Label2)
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(1041, 283)
        Me.pnlDatos.TabIndex = 0
        Me.pnlDatos.TabItem = Me.tabEmpleado
        '
        'cmbServicio
        '
        Me.cmbServicio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbServicio.FormattingEnabled = True
        Me.cmbServicio.ItemHeight = 14
        Me.cmbServicio.Location = New System.Drawing.Point(179, 173)
        Me.cmbServicio.Name = "cmbServicio"
        Me.cmbServicio.Size = New System.Drawing.Size(188, 20)
        Me.cmbServicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbServicio.TabIndex = 4
        '
        'cmbTurno
        '
        Me.cmbTurno.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.cmbTurno.BackgroundStyle.Class = "TextBoxBorder"
        Me.cmbTurno.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cmbTurno.ButtonDropDown.Visible = True
        Me.cmbTurno.Columns.Add(Me.CodTurnocol)
        Me.cmbTurno.Columns.Add(Me.NomTurnoCol)
        Me.cmbTurno.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.cmbTurno.Location = New System.Drawing.Point(179, 209)
        Me.cmbTurno.Name = "cmbTurno"
        Me.cmbTurno.Size = New System.Drawing.Size(188, 20)
        Me.cmbTurno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbTurno.TabIndex = 5
        Me.cmbTurno.ValueMember = "cod_turno"
        '
        'CodTurnocol
        '
        Me.CodTurnocol.ColumnName = "cod_turno"
        Me.CodTurnocol.DataFieldName = "cod_turno"
        Me.CodTurnocol.Name = "CodTurnocol"
        Me.CodTurnocol.Text = "Código"
        Me.CodTurnocol.Width.Absolute = 50
        '
        'NomTurnoCol
        '
        Me.NomTurnoCol.ColumnName = "nombre"
        Me.NomTurnoCol.DataFieldName = "nombre"
        Me.NomTurnoCol.Name = "NomTurnoCol"
        Me.NomTurnoCol.Text = "Turno"
        Me.NomTurnoCol.Width.Absolute = 150
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.SystemColors.Window
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(30, 178)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(50, 15)
        Me.Label15.TabIndex = 19
        Me.Label15.Text = "Servicio"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(30, 214)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 15)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Turno"
        '
        'gpAplica
        '
        Me.gpAplica.BackColor = System.Drawing.SystemColors.Window
        Me.gpAplica.CanvasColor = System.Drawing.SystemColors.Window
        Me.gpAplica.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007
        Me.gpAplica.Controls.Add(Me.Label8)
        Me.gpAplica.Controls.Add(Me.Label9)
        Me.gpAplica.Controls.Add(Me.Label10)
        Me.gpAplica.Controls.Add(Me.swDomingo)
        Me.gpAplica.Controls.Add(Me.Label11)
        Me.gpAplica.Controls.Add(Me.swSabado)
        Me.gpAplica.Controls.Add(Me.Label12)
        Me.gpAplica.Controls.Add(Me.swViernes)
        Me.gpAplica.Controls.Add(Me.Label13)
        Me.gpAplica.Controls.Add(Me.swJueves)
        Me.gpAplica.Controls.Add(Me.Label14)
        Me.gpAplica.Controls.Add(Me.swMiercoles)
        Me.gpAplica.Controls.Add(Me.swLunes)
        Me.gpAplica.Controls.Add(Me.swMartes)
        Me.gpAplica.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpAplica.Location = New System.Drawing.Point(495, 17)
        Me.gpAplica.Name = "gpAplica"
        Me.gpAplica.Size = New System.Drawing.Size(165, 252)
        '
        '
        '
        Me.gpAplica.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpAplica.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpAplica.Style.BackColorGradientAngle = 90
        Me.gpAplica.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpAplica.Style.BorderBottomWidth = 1
        Me.gpAplica.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpAplica.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpAplica.Style.BorderLeftWidth = 1
        Me.gpAplica.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpAplica.Style.BorderRightWidth = 1
        Me.gpAplica.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpAplica.Style.BorderTopWidth = 1
        Me.gpAplica.Style.CornerDiameter = 4
        Me.gpAplica.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpAplica.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.gpAplica.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpAplica.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpAplica.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpAplica.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpAplica.TabIndex = 15
        Me.gpAplica.Text = "Aplica"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.SystemColors.Window
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 15)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Lunes"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.SystemColors.Window
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 40)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(45, 15)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Martes"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.Window
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 73)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(61, 15)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Miércoles"
        '
        'swDomingo
        '
        '
        '
        '
        Me.swDomingo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swDomingo.Location = New System.Drawing.Point(71, 199)
        Me.swDomingo.Name = "swDomingo"
        Me.swDomingo.OffText = "NO"
        Me.swDomingo.OffTextColor = System.Drawing.Color.Black
        Me.swDomingo.OnText = "SI"
        Me.swDomingo.OnTextColor = System.Drawing.Color.Black
        Me.swDomingo.Size = New System.Drawing.Size(78, 22)
        Me.swDomingo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swDomingo.TabIndex = 12
        Me.swDomingo.Value = True
        Me.swDomingo.ValueObject = "Y"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Window
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(6, 107)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(45, 15)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Jueves"
        '
        'swSabado
        '
        '
        '
        '
        Me.swSabado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swSabado.Location = New System.Drawing.Point(71, 168)
        Me.swSabado.Name = "swSabado"
        Me.swSabado.OffText = "NO"
        Me.swSabado.OffTextColor = System.Drawing.Color.Black
        Me.swSabado.OnText = "SI"
        Me.swSabado.OnTextColor = System.Drawing.Color.Black
        Me.swSabado.Size = New System.Drawing.Size(78, 22)
        Me.swSabado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swSabado.TabIndex = 11
        Me.swSabado.Value = True
        Me.swSabado.ValueObject = "Y"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.SystemColors.Window
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(6, 140)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 15)
        Me.Label12.TabIndex = 8
        Me.Label12.Text = "Viernes"
        '
        'swViernes
        '
        '
        '
        '
        Me.swViernes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swViernes.Location = New System.Drawing.Point(71, 136)
        Me.swViernes.Name = "swViernes"
        Me.swViernes.OffText = "NO"
        Me.swViernes.OffTextColor = System.Drawing.Color.Black
        Me.swViernes.OnText = "SI"
        Me.swViernes.OnTextColor = System.Drawing.Color.Black
        Me.swViernes.Size = New System.Drawing.Size(78, 22)
        Me.swViernes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swViernes.TabIndex = 10
        Me.swViernes.Value = True
        Me.swViernes.ValueObject = "Y"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.Window
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 172)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 15)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "Sábado"
        '
        'swJueves
        '
        '
        '
        '
        Me.swJueves.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swJueves.Location = New System.Drawing.Point(71, 103)
        Me.swJueves.Name = "swJueves"
        Me.swJueves.OffText = "NO"
        Me.swJueves.OffTextColor = System.Drawing.Color.Black
        Me.swJueves.OnText = "SI"
        Me.swJueves.OnTextColor = System.Drawing.Color.Black
        Me.swJueves.Size = New System.Drawing.Size(78, 22)
        Me.swJueves.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swJueves.TabIndex = 9
        Me.swJueves.Value = True
        Me.swJueves.ValueObject = "Y"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.SystemColors.Window
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(6, 203)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 15)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Domingo"
        '
        'swMiercoles
        '
        '
        '
        '
        Me.swMiercoles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swMiercoles.Location = New System.Drawing.Point(71, 69)
        Me.swMiercoles.Name = "swMiercoles"
        Me.swMiercoles.OffText = "NO"
        Me.swMiercoles.OffTextColor = System.Drawing.Color.Black
        Me.swMiercoles.OnText = "SI"
        Me.swMiercoles.OnTextColor = System.Drawing.Color.Black
        Me.swMiercoles.Size = New System.Drawing.Size(78, 22)
        Me.swMiercoles.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swMiercoles.TabIndex = 8
        Me.swMiercoles.Value = True
        Me.swMiercoles.ValueObject = "Y"
        '
        'swLunes
        '
        '
        '
        '
        Me.swLunes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swLunes.Location = New System.Drawing.Point(71, 5)
        Me.swLunes.Name = "swLunes"
        Me.swLunes.OffText = "NO"
        Me.swLunes.OffTextColor = System.Drawing.Color.Black
        Me.swLunes.OnText = "SI"
        Me.swLunes.OnTextColor = System.Drawing.Color.Black
        Me.swLunes.Size = New System.Drawing.Size(78, 22)
        Me.swLunes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swLunes.TabIndex = 6
        Me.swLunes.Value = True
        Me.swLunes.ValueObject = "Y"
        '
        'swMartes
        '
        '
        '
        '
        Me.swMartes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swMartes.Location = New System.Drawing.Point(71, 36)
        Me.swMartes.Name = "swMartes"
        Me.swMartes.OffText = "NO"
        Me.swMartes.OffTextColor = System.Drawing.Color.Black
        Me.swMartes.OnText = "SI"
        Me.swMartes.OnTextColor = System.Drawing.Color.Black
        Me.swMartes.Size = New System.Drawing.Size(78, 22)
        Me.swMartes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swMartes.TabIndex = 7
        Me.swMartes.Value = True
        Me.swMartes.ValueObject = "Y"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Window
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(30, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Hora fin"
        '
        'txtHoraFin
        '
        '
        '
        '
        Me.txtHoraFin.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtHoraFin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtHoraFin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtHoraFin.ButtonDropDown.Visible = True
        Me.txtHoraFin.ButtonFreeText.Checked = True
        Me.txtHoraFin.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.TimeSelector
        Me.txtHoraFin.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.txtHoraFin.FreeTextEntryMode = True
        Me.txtHoraFin.IsPopupCalendarOpen = False
        Me.txtHoraFin.Location = New System.Drawing.Point(179, 138)
        '
        '
        '
        Me.txtHoraFin.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtHoraFin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtHoraFin.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtHoraFin.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtHoraFin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtHoraFin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtHoraFin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtHoraFin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtHoraFin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtHoraFin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtHoraFin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtHoraFin.MonthCalendar.DisplayMonth = New Date(2014, 12, 1, 0, 0, 0, 0)
        Me.txtHoraFin.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtHoraFin.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtHoraFin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtHoraFin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtHoraFin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtHoraFin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtHoraFin.MonthCalendar.TodayButtonVisible = True
        Me.txtHoraFin.MonthCalendar.Visible = False
        Me.txtHoraFin.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtHoraFin.Name = "txtHoraFin"
        Me.txtHoraFin.Size = New System.Drawing.Size(188, 20)
        Me.txtHoraFin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtHoraFin.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Hora inicio"
        '
        'txtHoraInicio
        '
        '
        '
        '
        Me.txtHoraInicio.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtHoraInicio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtHoraInicio.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.txtHoraInicio.ButtonDropDown.Visible = True
        Me.txtHoraInicio.ButtonFreeText.Checked = True
        Me.txtHoraInicio.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.TimeSelector
        Me.txtHoraInicio.Format = DevComponents.Editors.eDateTimePickerFormat.ShortTime
        Me.txtHoraInicio.FreeTextEntryMode = True
        Me.txtHoraInicio.IsPopupCalendarOpen = False
        Me.txtHoraInicio.Location = New System.Drawing.Point(179, 106)
        '
        '
        '
        Me.txtHoraInicio.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtHoraInicio.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtHoraInicio.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.txtHoraInicio.MonthCalendar.ClearButtonVisible = True
        '
        '
        '
        Me.txtHoraInicio.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.txtHoraInicio.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.txtHoraInicio.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.txtHoraInicio.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.txtHoraInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.txtHoraInicio.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.txtHoraInicio.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtHoraInicio.MonthCalendar.DisplayMonth = New Date(2014, 12, 1, 0, 0, 0, 0)
        Me.txtHoraInicio.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.txtHoraInicio.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.txtHoraInicio.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.txtHoraInicio.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.txtHoraInicio.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.txtHoraInicio.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtHoraInicio.MonthCalendar.TodayButtonVisible = True
        Me.txtHoraInicio.MonthCalendar.Visible = False
        Me.txtHoraInicio.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.txtHoraInicio.Name = "txtHoraInicio"
        Me.txtHoraInicio.Size = New System.Drawing.Size(188, 20)
        Me.txtHoraInicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.txtHoraInicio.TabIndex = 2
        '
        'CodCia
        '
        Me.CodCia.DataFieldName = "cod_comp"
        Me.CodCia.Name = "CodCia"
        Me.CodCia.Text = "Código"
        Me.CodCia.Width.Absolute = 60
        '
        'NombreCia
        '
        Me.NombreCia.DataFieldName = "nombre"
        Me.NombreCia.Name = "NombreCia"
        Me.NombreCia.StretchToFill = True
        Me.NombreCia.Text = "Nombre"
        Me.NombreCia.Width.Absolute = 150
        Me.NombreCia.Width.AutoSize = True
        '
        'CodTurno
        '
        Me.CodTurno.DataFieldName = "cod_turno"
        Me.CodTurno.Name = "CodTurno"
        Me.CodTurno.Text = "Código"
        Me.CodTurno.Width.Absolute = 60
        '
        'NombreTurno
        '
        Me.NombreTurno.DataFieldName = "Nombre"
        Me.NombreTurno.Name = "NombreTurno"
        Me.NombreTurno.Text = "Nombre"
        Me.NombreTurno.Width.Absolute = 150
        '
        'HorasTurno
        '
        Me.HorasTurno.DataFieldName = "horas"
        Me.HorasTurno.Name = "HorasTurno"
        Me.HorasTurno.StretchToFill = True
        Me.HorasTurno.Text = "Horas"
        Me.HorasTurno.Width.Absolute = 150
        Me.HorasTurno.Width.AutoSize = True
        '
        'SuperTabControlPanel2
        '
        Me.SuperTabControlPanel2.Controls.Add(Me.dgTabla)
        Me.SuperTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel2.Location = New System.Drawing.Point(0, 0)
        Me.SuperTabControlPanel2.Name = "SuperTabControlPanel2"
        Me.SuperTabControlPanel2.Size = New System.Drawing.Size(1039, 281)
        Me.SuperTabControlPanel2.TabIndex = 0
        Me.SuperTabControlPanel2.TabItem = Me.tabTabla
        '
        'dgTabla
        '
        Me.dgTabla.AllowUserToAddRows = False
        Me.dgTabla.AllowUserToDeleteRows = False
        Me.dgTabla.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTabla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTabla.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgTabla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTabla.EnableHeadersVisualStyles = False
        Me.dgTabla.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgTabla.Location = New System.Drawing.Point(0, 0)
        Me.dgTabla.MultiSelect = False
        Me.dgTabla.Name = "dgTabla"
        Me.dgTabla.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTabla.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgTabla.Size = New System.Drawing.Size(1039, 281)
        Me.dgTabla.TabIndex = 1
        '
        'tabTabla
        '
        Me.tabTabla.AttachedControl = Me.SuperTabControlPanel2
        Me.tabTabla.GlobalItem = False
        Me.tabTabla.Name = "tabTabla"
        Me.tabTabla.Text = "Lista"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.tabBuscar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 55)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(12)
        Me.Panel2.Size = New System.Drawing.Size(1136, 307)
        Me.Panel2.TabIndex = 1
        '
        'tabBuscar
        '
        '
        '
        '
        '
        '
        '
        Me.tabBuscar.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.tabBuscar.ControlBox.MenuBox.Name = ""
        Me.tabBuscar.ControlBox.MenuBox.Visible = False
        Me.tabBuscar.ControlBox.Name = ""
        Me.tabBuscar.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabBuscar.ControlBox.MenuBox, Me.tabBuscar.ControlBox.CloseBox})
        Me.tabBuscar.Controls.Add(Me.pnlDatos)
        Me.tabBuscar.Controls.Add(Me.SuperTabControlPanel2)
        Me.tabBuscar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.Location = New System.Drawing.Point(12, 12)
        Me.tabBuscar.Name = "tabBuscar"
        Me.tabBuscar.ReorderTabsEnabled = True
        Me.tabBuscar.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.tabBuscar.SelectedTabIndex = 0
        Me.tabBuscar.Size = New System.Drawing.Size(1112, 283)
        Me.tabBuscar.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Right
        Me.tabBuscar.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabBuscar.TabIndex = 0
        Me.tabBuscar.TabLayoutType = DevComponents.DotNetBar.eSuperTabLayoutType.SingleLineFit
        Me.tabBuscar.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.tabEmpleado, Me.tabTabla})
        Me.tabBuscar.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        '
        'EmpNav
        '
        Me.EmpNav.Controls.Add(Me.pnlControles)
        Me.EmpNav.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.EmpNav.Location = New System.Drawing.Point(0, 555)
        Me.EmpNav.Name = "EmpNav"
        Me.EmpNav.Size = New System.Drawing.Size(1136, 47)
        Me.EmpNav.TabIndex = 2
        Me.EmpNav.TabStop = False
        '
        'pnlControles
        '
        Me.pnlControles.Controls.Add(Me.btnPrimero)
        Me.pnlControles.Controls.Add(Me.btnCerrar)
        Me.pnlControles.Controls.Add(Me.btnNuevo)
        Me.pnlControles.Controls.Add(Me.btnEditar)
        Me.pnlControles.Controls.Add(Me.btnReporte)
        Me.pnlControles.Controls.Add(Me.btnBuscar)
        Me.pnlControles.Controls.Add(Me.btnAnterior)
        Me.pnlControles.Controls.Add(Me.btnUltimo)
        Me.pnlControles.Controls.Add(Me.btnBorrar)
        Me.pnlControles.Controls.Add(Me.btnSiguiente)
        Me.pnlControles.Location = New System.Drawing.Point(65, 11)
        Me.pnlControles.Name = "pnlControles"
        Me.pnlControles.Size = New System.Drawing.Size(821, 33)
        Me.pnlControles.TabIndex = 0
        '
        'btnPrimero
        '
        Me.btnPrimero.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrimero.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrimero.Image = Global.PIDA.My.Resources.Resources.First16
        Me.btnPrimero.Location = New System.Drawing.Point(10, 5)
        Me.btnPrimero.Name = "btnPrimero"
        Me.btnPrimero.Size = New System.Drawing.Size(78, 25)
        Me.btnPrimero.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrimero.TabIndex = 19
        Me.btnPrimero.Text = "Inicio"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(739, 5)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 18
        Me.btnCerrar.Text = "Salir"
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.NewRecord
        Me.btnNuevo.Location = New System.Drawing.Point(496, 5)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 25)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 15
        Me.btnNuevo.Text = "Agregar"
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = Global.PIDA.My.Resources.Resources.Edit
        Me.btnEditar.Location = New System.Drawing.Point(577, 5)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(78, 25)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 16
        Me.btnEditar.Text = "Editar"
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnReporte.Location = New System.Drawing.Point(415, 5)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 14
        Me.btnReporte.Text = "Reporte"
        Me.btnReporte.Visible = False
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscar.Location = New System.Drawing.Point(334, 5)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(78, 25)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 13
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Tooltip = "Buscar"
        '
        'btnAnterior
        '
        Me.btnAnterior.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAnterior.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAnterior.Image = Global.PIDA.My.Resources.Resources.Prev16
        Me.btnAnterior.Location = New System.Drawing.Point(91, 5)
        Me.btnAnterior.Name = "btnAnterior"
        Me.btnAnterior.Size = New System.Drawing.Size(78, 25)
        Me.btnAnterior.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAnterior.TabIndex = 20
        Me.btnAnterior.Text = "Anterior"
        '
        'btnUltimo
        '
        Me.btnUltimo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnUltimo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnUltimo.Image = Global.PIDA.My.Resources.Resources.Last16
        Me.btnUltimo.Location = New System.Drawing.Point(253, 5)
        Me.btnUltimo.Name = "btnUltimo"
        Me.btnUltimo.Size = New System.Drawing.Size(78, 25)
        Me.btnUltimo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnUltimo.TabIndex = 22
        Me.btnUltimo.Text = "Final"
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = Global.PIDA.My.Resources.Resources.DeleteRec
        Me.btnBorrar.Location = New System.Drawing.Point(658, 5)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(78, 25)
        Me.btnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBorrar.TabIndex = 17
        Me.btnBorrar.Text = "Borrar"
        '
        'btnSiguiente
        '
        Me.btnSiguiente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSiguiente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSiguiente.Image = Global.PIDA.My.Resources.Resources.Next16
        Me.btnSiguiente.Location = New System.Drawing.Point(172, 5)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(78, 25)
        Me.btnSiguiente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSiguiente.TabIndex = 21
        Me.btnSiguiente.Text = "Siguiente"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(58, 9)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(581, 40)
        Me.ReflectionLabel1.TabIndex = 0
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>HORARIOS DE CAFETERÍA</b></font>"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.ReflectionLabel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1136, 55)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.PIDA.My.Resources.Resources._1469761116_cmyk_04
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(55, 55)
        Me.PictureBox1.TabIndex = 82
        Me.PictureBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(30, 254)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 15)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Planta"
        '
        'cmbPlanta
        '
        Me.cmbPlanta.DisplayMember = "Text"
        Me.cmbPlanta.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbPlanta.FormattingEnabled = True
        Me.cmbPlanta.ItemHeight = 14
        Me.cmbPlanta.Items.AddRange(New Object() {Me.J1, Me.J2, Me.NADA})
        Me.cmbPlanta.Location = New System.Drawing.Point(179, 247)
        Me.cmbPlanta.Name = "cmbPlanta"
        Me.cmbPlanta.Size = New System.Drawing.Size(188, 20)
        Me.cmbPlanta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbPlanta.TabIndex = 21
        '
        'J1
        '
        Me.J1.Text = "JUAREZ 1"
        Me.J1.Value = "JUAREZ 1"
        '
        'J2
        '
        Me.J2.Text = "JUAREZ 2"
        Me.J2.Value = "JUAREZ 2"
        '
        'frmHorariosCafeteria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1136, 602)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.EmpNav)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmHorariosCafeteria"
        Me.Text = "Cafetería"
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        Me.gpAplica.ResumeLayout(False)
        Me.gpAplica.PerformLayout()
        CType(Me.txtHoraFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHoraInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControlPanel2.ResumeLayout(False)
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.tabBuscar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabBuscar.ResumeLayout(False)
        Me.tabBuscar.PerformLayout()
        Me.EmpNav.ResumeLayout(False)
        Me.pnlControles.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCodigo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tabEmpleado As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents pnlDatos As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents CodTurno As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NombreTurno As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents HorasTurno As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents CodCia As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NombreCia As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents SuperTabControlPanel2 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents dgTabla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents tabTabla As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents tabBuscar As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents EmpNav As System.Windows.Forms.GroupBox
    Friend WithEvents pnlControles As System.Windows.Forms.Panel
    Friend WithEvents btnPrimero As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAnterior As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnUltimo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSiguiente As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents swDomingo As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents swSabado As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents swViernes As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents swJueves As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents swMiercoles As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents swMartes As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents swLunes As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtHoraFin As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtHoraInicio As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents gpAplica As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents CodTurnocol As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents NomTurnoCol As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbTurno As DevComponents.DotNetBar.Controls.ComboTree
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbServicio As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbPlanta As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents J1 As DevComponents.Editors.ComboItem
    Friend WithEvents J2 As DevComponents.Editors.ComboItem
    Friend WithEvents NADA As DevComponents.Editors.ComboItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
