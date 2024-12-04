<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisitas
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVisitas))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.btnConcluirDia = New DevComponents.DotNetBar.ButtonX()
        Me.btnFirst = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrev = New DevComponents.DotNetBar.ButtonX()
        Me.btnNext = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnLast = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.labelConteo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.comboFiltroExternos = New System.Windows.Forms.ComboBox()
        Me.comboFiltroEstado = New System.Windows.Forms.ComboBox()
        Me.dtpFechaBusqueda = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvVisitasDiarias = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.SuperTabControl1 = New DevComponents.DotNetBar.SuperTabControl()
        Me.SuperTabControlPanel1 = New DevComponents.DotNetBar.SuperTabControlPanel()
        Me.SuperTabItem1 = New DevComponents.DotNetBar.SuperTabItem()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvVisitasDiarias, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuperTabControl1.SuspendLayout()
        Me.SuperTabControlPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnBorrar)
        Me.Panel1.Controls.Add(Me.btnNuevo)
        Me.Panel1.Controls.Add(Me.btnConcluirDia)
        Me.Panel1.Controls.Add(Me.btnFirst)
        Me.Panel1.Controls.Add(Me.btnPrev)
        Me.Panel1.Controls.Add(Me.btnNext)
        Me.Panel1.Controls.Add(Me.btnCerrar)
        Me.Panel1.Controls.Add(Me.btnLast)
        Me.Panel1.Controls.Add(Me.btnReporte)
        Me.Panel1.Location = New System.Drawing.Point(6, 591)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(780, 33)
        Me.Panel1.TabIndex = 21
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = Global.PIDA.NET.My.Resources.Resources.DeleteRec
        Me.btnBorrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBorrar.Location = New System.Drawing.Point(373, 3)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(72, 25)
        Me.btnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBorrar.TabIndex = 5011
        Me.btnBorrar.Text = "Borrar"
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.NET.My.Resources.Resources.NewRecord
        Me.btnNuevo.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnNuevo.Location = New System.Drawing.Point(451, 3)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(72, 25)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 5010
        Me.btnNuevo.Text = "Agregar"
        '
        'btnConcluirDia
        '
        Me.btnConcluirDia.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnConcluirDia.CausesValidation = False
        Me.btnConcluirDia.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnConcluirDia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConcluirDia.Image = Global.PIDA.NET.My.Resources.Resources.Ok16
        Me.btnConcluirDia.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnConcluirDia.Location = New System.Drawing.Point(579, 3)
        Me.btnConcluirDia.Name = "btnConcluirDia"
        Me.btnConcluirDia.Size = New System.Drawing.Size(121, 25)
        Me.btnConcluirDia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnConcluirDia.TabIndex = 5005
        Me.btnConcluirDia.Text = "Concluir Este Día"
        Me.btnConcluirDia.Tooltip = "Buscar"
        '
        'btnFirst
        '
        Me.btnFirst.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnFirst.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFirst.Image = Global.PIDA.NET.My.Resources.Resources.First16
        Me.btnFirst.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnFirst.Location = New System.Drawing.Point(3, 3)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(68, 25)
        Me.btnFirst.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnFirst.TabIndex = 5000
        Me.btnFirst.Text = "Inicio"
        '
        'btnPrev
        '
        Me.btnPrev.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrev.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrev.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrev.Image = Global.PIDA.NET.My.Resources.Resources.Prev16
        Me.btnPrev.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnPrev.Location = New System.Drawing.Point(77, 3)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(68, 25)
        Me.btnPrev.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrev.TabIndex = 5001
        Me.btnPrev.Text = "Anterior"
        '
        'btnNext
        '
        Me.btnNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Image = Global.PIDA.NET.My.Resources.Resources.Next16
        Me.btnNext.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnNext.Location = New System.Drawing.Point(151, 3)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(68, 25)
        Me.btnNext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNext.TabIndex = 5002
        Me.btnNext.Text = "Siguiente"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.NET.My.Resources.Resources.CancelX
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(706, 3)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(68, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 5009
        Me.btnCerrar.Text = "Salir"
        '
        'btnLast
        '
        Me.btnLast.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLast.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLast.Image = Global.PIDA.NET.My.Resources.Resources.Last16
        Me.btnLast.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnLast.Location = New System.Drawing.Point(225, 3)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(68, 25)
        Me.btnLast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLast.TabIndex = 5003
        Me.btnLast.Text = "Final"
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.NET.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnReporte.Location = New System.Drawing.Point(299, 3)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(68, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 5005
        Me.btnReporte.Text = "Reporte"
        '
        'labelConteo
        '
        Me.labelConteo.AutoSize = True
        Me.labelConteo.BackColor = System.Drawing.Color.Transparent
        Me.labelConteo.Location = New System.Drawing.Point(261, 77)
        Me.labelConteo.Name = "labelConteo"
        Me.labelConteo.Size = New System.Drawing.Size(45, 13)
        Me.labelConteo.TabIndex = 5006
        Me.labelConteo.Text = "n visitas"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(131, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 283
        Me.Label3.Text = "Estado de la Visita"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 282
        Me.Label2.Text = "Estado de la Persona"
        '
        'comboFiltroExternos
        '
        Me.comboFiltroExternos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboFiltroExternos.FormattingEnabled = True
        Me.comboFiltroExternos.Items.AddRange(New Object() {"Todos", "Empleados", "Externos"})
        Me.comboFiltroExternos.Location = New System.Drawing.Point(6, 72)
        Me.comboFiltroExternos.Name = "comboFiltroExternos"
        Me.comboFiltroExternos.Size = New System.Drawing.Size(121, 21)
        Me.comboFiltroExternos.TabIndex = 281
        '
        'comboFiltroEstado
        '
        Me.comboFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboFiltroEstado.FormattingEnabled = True
        Me.comboFiltroEstado.Items.AddRange(New Object() {"Todas", "Concluidas", "Sin Concluir"})
        Me.comboFiltroEstado.Location = New System.Drawing.Point(134, 72)
        Me.comboFiltroEstado.Name = "comboFiltroEstado"
        Me.comboFiltroEstado.Size = New System.Drawing.Size(121, 21)
        Me.comboFiltroEstado.TabIndex = 280
        '
        'dtpFechaBusqueda
        '
        Me.dtpFechaBusqueda.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaBusqueda.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaBusqueda.Location = New System.Drawing.Point(679, 67)
        Me.dtpFechaBusqueda.MaxDate = New Date(2021, 12, 31, 0, 0, 0, 0)
        Me.dtpFechaBusqueda.MinDate = New Date(2013, 1, 1, 0, 0, 0, 0)
        Me.dtpFechaBusqueda.Name = "dtpFechaBusqueda"
        Me.dtpFechaBusqueda.Size = New System.Drawing.Size(107, 26)
        Me.dtpFechaBusqueda.TabIndex = 279
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(749, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 278
        Me.Label1.Text = "Fecha"
        '
        'dgvVisitasDiarias
        '
        Me.dgvVisitasDiarias.AllowUserToAddRows = False
        Me.dgvVisitasDiarias.AllowUserToDeleteRows = False
        Me.dgvVisitasDiarias.AllowUserToOrderColumns = True
        Me.dgvVisitasDiarias.AllowUserToResizeColumns = False
        Me.dgvVisitasDiarias.AllowUserToResizeRows = False
        Me.dgvVisitasDiarias.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVisitasDiarias.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvVisitasDiarias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVisitasDiarias.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvVisitasDiarias.GridColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.dgvVisitasDiarias.Location = New System.Drawing.Point(6, 99)
        Me.dgvVisitasDiarias.Name = "dgvVisitasDiarias"
        Me.dgvVisitasDiarias.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVisitasDiarias.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvVisitasDiarias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvVisitasDiarias.Size = New System.Drawing.Size(780, 460)
        Me.dgvVisitasDiarias.TabIndex = 277
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.PIDA.NET.My.Resources.Resources.enfermera64
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 50)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 276
        Me.PictureBox1.TabStop = False
        '
        'ReflectionLabel1
        '
        Me.ReflectionLabel1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(50, 13)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(530, 40)
        Me.ReflectionLabel1.TabIndex = 275
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>VISITAS DIARIAS A ENFERMERIA</b></font>"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "group2-16.png")
        Me.ImageList1.Images.SetKeyName(1, "user-16.png")
        '
        'SuperTabControl1
        '
        Me.SuperTabControl1.CloseButtonOnTabsVisible = True
        '
        '
        '
        '
        '
        '
        Me.SuperTabControl1.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControl1.ControlBox.MenuBox.Name = ""
        Me.SuperTabControl1.ControlBox.Name = ""
        Me.SuperTabControl1.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControl1.ControlBox.MenuBox, Me.SuperTabControl1.ControlBox.CloseBox})
        Me.SuperTabControl1.Controls.Add(Me.SuperTabControlPanel1)
        Me.SuperTabControl1.ImageList = Me.ImageList1
        Me.SuperTabControl1.Location = New System.Drawing.Point(12, 12)
        Me.SuperTabControl1.Name = "SuperTabControl1"
        Me.SuperTabControl1.ReorderTabsEnabled = True
        Me.SuperTabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.SuperTabControl1.SelectedTabIndex = 0
        Me.SuperTabControl1.Size = New System.Drawing.Size(800, 657)
        Me.SuperTabControl1.TabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControl1.TabIndex = 23
        Me.SuperTabControl1.Tabs.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabItem1})
        Me.SuperTabControl1.Text = "SuperTabControl1"
        '
        'SuperTabControlPanel1
        '
        Me.SuperTabControlPanel1.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.Zoom
        Me.SuperTabControlPanel1.Controls.Add(Me.labelConteo)
        Me.SuperTabControlPanel1.Controls.Add(Me.Panel1)
        Me.SuperTabControlPanel1.Controls.Add(Me.dgvVisitasDiarias)
        Me.SuperTabControlPanel1.Controls.Add(Me.PictureBox1)
        Me.SuperTabControlPanel1.Controls.Add(Me.Label3)
        Me.SuperTabControlPanel1.Controls.Add(Me.ReflectionLabel1)
        Me.SuperTabControlPanel1.Controls.Add(Me.Label2)
        Me.SuperTabControlPanel1.Controls.Add(Me.Label1)
        Me.SuperTabControlPanel1.Controls.Add(Me.comboFiltroExternos)
        Me.SuperTabControlPanel1.Controls.Add(Me.dtpFechaBusqueda)
        Me.SuperTabControlPanel1.Controls.Add(Me.comboFiltroEstado)
        Me.SuperTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SuperTabControlPanel1.Location = New System.Drawing.Point(0, 30)
        Me.SuperTabControlPanel1.Name = "SuperTabControlPanel1"
        Me.SuperTabControlPanel1.Size = New System.Drawing.Size(800, 627)
        Me.SuperTabControlPanel1.TabIndex = 1
        Me.SuperTabControlPanel1.TabItem = Me.SuperTabItem1
        Me.SuperTabControlPanel1.Text = "Visitas"
        '
        'SuperTabItem1
        '
        Me.SuperTabItem1.AttachedControl = Me.SuperTabControlPanel1
        Me.SuperTabItem1.GlobalItem = False
        Me.SuperTabItem1.ImageIndex = 0
        Me.SuperTabItem1.Name = "SuperTabItem1"
        Me.SuperTabItem1.Text = "Visitas Diarias"
        '
        'frmVisitas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(824, 681)
        Me.Controls.Add(Me.SuperTabControl1)
        Me.Name = "frmVisitas"
        Me.Text = "Visitas Diarias"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvVisitasDiarias, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SuperTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SuperTabControl1.ResumeLayout(False)
        Me.SuperTabControlPanel1.ResumeLayout(False)
        Me.SuperTabControlPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnFirst As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrev As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNext As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnLast As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents dgvVisitasDiarias As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaBusqueda As System.Windows.Forms.DateTimePicker
    Friend WithEvents comboFiltroExternos As System.Windows.Forms.ComboBox
    Friend WithEvents comboFiltroEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnConcluirDia As DevComponents.DotNetBar.ButtonX
    Friend WithEvents labelConteo As System.Windows.Forms.Label
    Friend WithEvents SuperTabControl1 As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents SuperTabControlPanel1 As DevComponents.DotNetBar.SuperTabControlPanel
    Friend WithEvents SuperTabItem1 As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
End Class
