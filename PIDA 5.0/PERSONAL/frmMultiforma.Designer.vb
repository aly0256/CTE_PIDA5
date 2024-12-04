<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMultiforma
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMultiforma))
        Me.tabTabla = New DevComponents.DotNetBar.SuperTabItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgTabla = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.CRELOJ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_CAPTURA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HORA_CAPTURA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cusuario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MOVIMIENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Detalle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COMENTARIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CONFIRMADO = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.IMPRESO = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pnlCentrarControles = New System.Windows.Forms.Panel()
        Me.btnConfirmar = New DevComponents.DotNetBar.ButtonX()
        Me.btnFirst = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrev = New DevComponents.DotNetBar.ButtonX()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.btnNext = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnLast = New DevComponents.DotNetBar.ButtonX()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtArea = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblEstado = New DevComponents.DotNetBar.LabelX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNombre = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblBaja = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDepto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtPuesto = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.txtTipoEmp = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.txtBaja = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtSupervisor = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtAlta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.txtClase = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.picFoto = New System.Windows.Forms.PictureBox()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.txtTurno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtHorario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCentrarControles.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabTabla
        '
        Me.tabTabla.GlobalItem = False
        Me.tabTabla.Name = "tabTabla"
        Me.tabTabla.Text = "Lista"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgTabla)
        Me.Panel1.Controls.Add(Me.pnlCentrarControles)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1035, 358)
        Me.Panel1.TabIndex = 279
        '
        'dgTabla
        '
        Me.dgTabla.AllowUserToAddRows = False
        Me.dgTabla.AllowUserToDeleteRows = False
        Me.dgTabla.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgTabla.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgTabla.ColumnHeadersHeight = 40
        Me.dgTabla.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CRELOJ, Me.FECHA_CAPTURA, Me.HORA_CAPTURA, Me.cusuario, Me.MOVIMIENTO, Me.Detalle, Me.COMENTARIO, Me.CONFIRMADO, Me.IMPRESO})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgTabla.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgTabla.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgTabla.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgTabla.Location = New System.Drawing.Point(0, 173)
        Me.dgTabla.MultiSelect = False
        Me.dgTabla.Name = "dgTabla"
        Me.dgTabla.ReadOnly = True
        Me.dgTabla.RowHeadersVisible = False
        Me.dgTabla.RowHeadersWidth = 20
        Me.dgTabla.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window
        Me.dgTabla.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dgTabla.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgTabla.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgTabla.Size = New System.Drawing.Size(1035, 153)
        Me.dgTabla.TabIndex = 307
        '
        'CRELOJ
        '
        Me.CRELOJ.DataPropertyName = "reloj"
        Me.CRELOJ.HeaderText = "Reloj"
        Me.CRELOJ.Name = "CRELOJ"
        Me.CRELOJ.ReadOnly = True
        Me.CRELOJ.Width = 50
        '
        'FECHA_CAPTURA
        '
        Me.FECHA_CAPTURA.DataPropertyName = "FECHA_CAPTURA"
        Me.FECHA_CAPTURA.HeaderText = "Fecha captura"
        Me.FECHA_CAPTURA.Name = "FECHA_CAPTURA"
        Me.FECHA_CAPTURA.ReadOnly = True
        Me.FECHA_CAPTURA.Width = 70
        '
        'HORA_CAPTURA
        '
        Me.HORA_CAPTURA.DataPropertyName = "HORA_CAPTURA"
        Me.HORA_CAPTURA.HeaderText = "Hora captura"
        Me.HORA_CAPTURA.Name = "HORA_CAPTURA"
        Me.HORA_CAPTURA.ReadOnly = True
        Me.HORA_CAPTURA.Width = 65
        '
        'cusuario
        '
        Me.cusuario.DataPropertyName = "USUARIO"
        Me.cusuario.HeaderText = "Usuario"
        Me.cusuario.Name = "cusuario"
        Me.cusuario.ReadOnly = True
        Me.cusuario.Width = 60
        '
        'MOVIMIENTO
        '
        Me.MOVIMIENTO.DataPropertyName = "TIPO_MOVIMIENTO"
        Me.MOVIMIENTO.HeaderText = "Movimiento"
        Me.MOVIMIENTO.Name = "MOVIMIENTO"
        Me.MOVIMIENTO.ReadOnly = True
        Me.MOVIMIENTO.Width = 120
        '
        'Detalle
        '
        Me.Detalle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Detalle.DataPropertyName = "DETALLE"
        Me.Detalle.HeaderText = "Detalle"
        Me.Detalle.Name = "Detalle"
        Me.Detalle.ReadOnly = True
        '
        'COMENTARIO
        '
        Me.COMENTARIO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.COMENTARIO.DataPropertyName = "COMENTARIO"
        Me.COMENTARIO.HeaderText = "Comentario"
        Me.COMENTARIO.Name = "COMENTARIO"
        Me.COMENTARIO.ReadOnly = True
        '
        'CONFIRMADO
        '
        Me.CONFIRMADO.DataPropertyName = "CONFIRMADO"
        Me.CONFIRMADO.FalseValue = "0"
        Me.CONFIRMADO.HeaderText = "Aplicado"
        Me.CONFIRMADO.Name = "CONFIRMADO"
        Me.CONFIRMADO.ReadOnly = True
        Me.CONFIRMADO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CONFIRMADO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CONFIRMADO.TrueValue = "1"
        Me.CONFIRMADO.Width = 65
        '
        'IMPRESO
        '
        Me.IMPRESO.DataPropertyName = "IMPRESO"
        Me.IMPRESO.FalseValue = "0"
        Me.IMPRESO.HeaderText = "Impreso"
        Me.IMPRESO.Name = "IMPRESO"
        Me.IMPRESO.ReadOnly = True
        Me.IMPRESO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IMPRESO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.IMPRESO.TrueValue = "1"
        Me.IMPRESO.Width = 65
        '
        'pnlCentrarControles
        '
        Me.pnlCentrarControles.Controls.Add(Me.btnConfirmar)
        Me.pnlCentrarControles.Controls.Add(Me.btnFirst)
        Me.pnlCentrarControles.Controls.Add(Me.btnPrev)
        Me.pnlCentrarControles.Controls.Add(Me.btnBuscar)
        Me.pnlCentrarControles.Controls.Add(Me.btnNext)
        Me.pnlCentrarControles.Controls.Add(Me.btnReporte)
        Me.pnlCentrarControles.Controls.Add(Me.btnNuevo)
        Me.pnlCentrarControles.Controls.Add(Me.btnCerrar)
        Me.pnlCentrarControles.Controls.Add(Me.btnLast)
        Me.pnlCentrarControles.Controls.Add(Me.btnBorrar)
        Me.pnlCentrarControles.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlCentrarControles.Location = New System.Drawing.Point(0, 326)
        Me.pnlCentrarControles.Name = "pnlCentrarControles"
        Me.pnlCentrarControles.Size = New System.Drawing.Size(1035, 32)
        Me.pnlCentrarControles.TabIndex = 280
        '
        'btnConfirmar
        '
        Me.btnConfirmar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnConfirmar.CausesValidation = False
        Me.btnConfirmar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnConfirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmar.Image = Global.PIDA.My.Resources.Resources.NewRecord
        Me.btnConfirmar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnConfirmar.Location = New System.Drawing.Point(581, 3)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(78, 25)
        Me.btnConfirmar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnConfirmar.TabIndex = 43
        Me.btnConfirmar.Text = "Agregar"
        '
        'btnFirst
        '
        Me.btnFirst.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnFirst.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnFirst.Image = Global.PIDA.My.Resources.Resources.First16
        Me.btnFirst.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnFirst.Location = New System.Drawing.Point(95, 3)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(78, 25)
        Me.btnFirst.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnFirst.TabIndex = 33
        Me.btnFirst.Text = "Inicio"
        '
        'btnPrev
        '
        Me.btnPrev.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnPrev.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnPrev.Image = Global.PIDA.My.Resources.Resources.Prev16
        Me.btnPrev.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnPrev.Location = New System.Drawing.Point(176, 3)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(78, 25)
        Me.btnPrev.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrev.TabIndex = 34
        Me.btnPrev.Text = "Anterior"
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBuscar.Location = New System.Drawing.Point(419, 3)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(78, 25)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 37
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Tooltip = "Buscar"
        '
        'btnNext
        '
        Me.btnNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNext.Image = Global.PIDA.My.Resources.Resources.Next16
        Me.btnNext.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnNext.Location = New System.Drawing.Point(257, 3)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(78, 25)
        Me.btnNext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNext.TabIndex = 35
        Me.btnNext.Text = "Siguiente"
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnReporte.Location = New System.Drawing.Point(500, 3)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 38
        Me.btnReporte.Text = "Reporte"
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.Edit
        Me.btnNuevo.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnNuevo.Location = New System.Drawing.Point(662, 3)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 25)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 39
        Me.btnNuevo.Text = "Editar"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(824, 3)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 42
        Me.btnCerrar.Text = "Salir"
        '
        'btnLast
        '
        Me.btnLast.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnLast.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnLast.Image = Global.PIDA.My.Resources.Resources.Last16
        Me.btnLast.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnLast.Location = New System.Drawing.Point(338, 3)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(78, 25)
        Me.btnLast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLast.TabIndex = 36
        Me.btnLast.Text = "Final"
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = Global.PIDA.My.Resources.Resources.DeleteRec
        Me.btnBorrar.Location = New System.Drawing.Point(743, 3)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(78, 25)
        Me.btnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBorrar.TabIndex = 41
        Me.btnBorrar.Text = "Borrar"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtArea)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.lblEstado)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.txtNombre)
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Controls.Add(Me.lblBaja)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.txtDepto)
        Me.Panel3.Controls.Add(Me.txtPuesto)
        Me.Panel3.Controls.Add(Me.Label67)
        Me.Panel3.Controls.Add(Me.txtTipoEmp)
        Me.Panel3.Controls.Add(Me.Label68)
        Me.Panel3.Controls.Add(Me.txtBaja)
        Me.Panel3.Controls.Add(Me.txtSupervisor)
        Me.Panel3.Controls.Add(Me.txtAlta)
        Me.Panel3.Controls.Add(Me.Label71)
        Me.Panel3.Controls.Add(Me.Label72)
        Me.Panel3.Controls.Add(Me.txtClase)
        Me.Panel3.Controls.Add(Me.picFoto)
        Me.Panel3.Controls.Add(Me.Label70)
        Me.Panel3.Controls.Add(Me.ReflectionLabel1)
        Me.Panel3.Controls.Add(Me.txtTurno)
        Me.Panel3.Controls.Add(Me.txtHorario)
        Me.Panel3.Controls.Add(Me.Label69)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1035, 173)
        Me.Panel3.TabIndex = 306
        '
        'txtArea
        '
        '
        '
        '
        Me.txtArea.Border.Class = "TextBoxBorder"
        Me.txtArea.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArea.ForeColor = System.Drawing.Color.Black
        Me.txtArea.Location = New System.Drawing.Point(532, 62)
        Me.txtArea.Name = "txtArea"
        Me.txtArea.ReadOnly = True
        Me.txtArea.Size = New System.Drawing.Size(168, 21)
        Me.txtArea.TabIndex = 277
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(447, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 15)
        Me.Label1.TabIndex = 278
        Me.Label1.Text = "Area"
        '
        'lblEstado
        '
        Me.lblEstado.BackColor = System.Drawing.Color.Green
        '
        '
        '
        Me.lblEstado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblEstado.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblEstado.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstado.ForeColor = System.Drawing.Color.White
        Me.lblEstado.Location = New System.Drawing.Point(0, 0)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(29, 173)
        Me.lblEstado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblEstado.TabIndex = 253
        Me.lblEstado.Text = "ACTIVO"
        Me.lblEstado.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblEstado.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.lblEstado.VerticalTextTopUp = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(36, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 15)
        Me.Label5.TabIndex = 251
        Me.Label5.Text = "Nombre"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(718, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 15)
        Me.Label3.TabIndex = 254
        Me.Label3.Text = "Fecha de alta"
        '
        'txtNombre
        '
        '
        '
        '
        Me.txtNombre.Border.Class = "TextBoxBorder"
        Me.txtNombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombre.ForeColor = System.Drawing.Color.Black
        Me.txtNombre.Location = New System.Drawing.Point(36, 75)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.ReadOnly = True
        Me.txtNombre.Size = New System.Drawing.Size(396, 21)
        Me.txtNombre.TabIndex = 249
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LabelX4)
        Me.GroupBox1.Controls.Add(Me.txtReloj)
        Me.GroupBox1.Location = New System.Drawing.Point(721, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(171, 49)
        Me.GroupBox1.TabIndex = 252
        Me.GroupBox1.TabStop = False
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
        Me.txtReloj.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtReloj.Border.Class = "TextBoxBorder"
        Me.txtReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.ForeColor = System.Drawing.Color.Black
        Me.txtReloj.Location = New System.Drawing.Point(79, 15)
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.ReadOnly = True
        Me.txtReloj.Size = New System.Drawing.Size(84, 26)
        Me.txtReloj.TabIndex = 0
        Me.txtReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBaja
        '
        Me.lblBaja.AutoSize = True
        Me.lblBaja.BackColor = System.Drawing.SystemColors.Control
        Me.lblBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBaja.Location = New System.Drawing.Point(718, 94)
        Me.lblBaja.Name = "lblBaja"
        Me.lblBaja.Size = New System.Drawing.Size(85, 15)
        Me.lblBaja.TabIndex = 255
        Me.lblBaja.Text = "Fecha de baja"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Control
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(447, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 15)
        Me.Label4.TabIndex = 276
        Me.Label4.Text = "Puesto"
        '
        'txtDepto
        '
        '
        '
        '
        Me.txtDepto.Border.Class = "TextBoxBorder"
        Me.txtDepto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDepto.ForeColor = System.Drawing.Color.Black
        Me.txtDepto.Location = New System.Drawing.Point(135, 115)
        Me.txtDepto.Name = "txtDepto"
        Me.txtDepto.ReadOnly = True
        Me.txtDepto.Size = New System.Drawing.Size(297, 21)
        Me.txtDepto.TabIndex = 256
        '
        'txtPuesto
        '
        '
        '
        '
        Me.txtPuesto.Border.Class = "TextBoxBorder"
        Me.txtPuesto.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPuesto.ForeColor = System.Drawing.Color.Black
        Me.txtPuesto.Location = New System.Drawing.Point(532, 143)
        Me.txtPuesto.Name = "txtPuesto"
        Me.txtPuesto.ReadOnly = True
        Me.txtPuesto.Size = New System.Drawing.Size(168, 21)
        Me.txtPuesto.TabIndex = 275
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.BackColor = System.Drawing.SystemColors.Control
        Me.Label67.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.Location = New System.Drawing.Point(36, 118)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(86, 15)
        Me.Label67.TabIndex = 257
        Me.Label67.Text = "Departamento"
        '
        'txtTipoEmp
        '
        '
        '
        '
        Me.txtTipoEmp.Border.Class = "TextBoxBorder"
        Me.txtTipoEmp.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTipoEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipoEmp.ForeColor = System.Drawing.Color.Black
        Me.txtTipoEmp.Location = New System.Drawing.Point(532, 89)
        Me.txtTipoEmp.Name = "txtTipoEmp"
        Me.txtTipoEmp.ReadOnly = True
        Me.txtTipoEmp.Size = New System.Drawing.Size(168, 21)
        Me.txtTipoEmp.TabIndex = 258
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.BackColor = System.Drawing.SystemColors.Control
        Me.Label68.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.Location = New System.Drawing.Point(447, 92)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(79, 15)
        Me.Label68.TabIndex = 259
        Me.Label68.Text = "Tipo de emp."
        '
        'txtBaja
        '
        '
        '
        '
        Me.txtBaja.Border.Class = "TextBoxBorder"
        Me.txtBaja.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBaja.ForeColor = System.Drawing.Color.Black
        Me.txtBaja.Location = New System.Drawing.Point(809, 91)
        Me.txtBaja.Name = "txtBaja"
        Me.txtBaja.ReadOnly = True
        Me.txtBaja.Size = New System.Drawing.Size(83, 21)
        Me.txtBaja.TabIndex = 270
        '
        'txtSupervisor
        '
        '
        '
        '
        Me.txtSupervisor.Border.Class = "TextBoxBorder"
        Me.txtSupervisor.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSupervisor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupervisor.ForeColor = System.Drawing.Color.Black
        Me.txtSupervisor.Location = New System.Drawing.Point(135, 142)
        Me.txtSupervisor.Name = "txtSupervisor"
        Me.txtSupervisor.ReadOnly = True
        Me.txtSupervisor.Size = New System.Drawing.Size(297, 21)
        Me.txtSupervisor.TabIndex = 260
        '
        'txtAlta
        '
        '
        '
        '
        Me.txtAlta.Border.Class = "TextBoxBorder"
        Me.txtAlta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlta.ForeColor = System.Drawing.Color.Black
        Me.txtAlta.Location = New System.Drawing.Point(809, 61)
        Me.txtAlta.Name = "txtAlta"
        Me.txtAlta.ReadOnly = True
        Me.txtAlta.Size = New System.Drawing.Size(83, 21)
        Me.txtAlta.TabIndex = 269
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.BackColor = System.Drawing.SystemColors.Control
        Me.Label71.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.Location = New System.Drawing.Point(36, 145)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(65, 15)
        Me.Label71.TabIndex = 261
        Me.Label71.Text = "Supervisor"
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.BackColor = System.Drawing.SystemColors.Control
        Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.Location = New System.Drawing.Point(447, 39)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(48, 15)
        Me.Label72.TabIndex = 267
        Me.Label72.Text = "Horario"
        '
        'txtClase
        '
        '
        '
        '
        Me.txtClase.Border.Class = "TextBoxBorder"
        Me.txtClase.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtClase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClase.ForeColor = System.Drawing.Color.Black
        Me.txtClase.Location = New System.Drawing.Point(532, 116)
        Me.txtClase.Name = "txtClase"
        Me.txtClase.ReadOnly = True
        Me.txtClase.Size = New System.Drawing.Size(168, 21)
        Me.txtClase.TabIndex = 262
        '
        'picFoto
        '
        Me.picFoto.ErrorImage = CType(resources.GetObject("picFoto.ErrorImage"), System.Drawing.Image)
        Me.picFoto.Image = Global.PIDA.My.Resources.Resources.NoFoto
        Me.picFoto.Location = New System.Drawing.Point(916, 8)
        Me.picFoto.MaximumSize = New System.Drawing.Size(164, 210)
        Me.picFoto.MinimumSize = New System.Drawing.Size(78, 100)
        Me.picFoto.Name = "picFoto"
        Me.picFoto.Size = New System.Drawing.Size(105, 108)
        Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picFoto.TabIndex = 250
        Me.picFoto.TabStop = False
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.BackColor = System.Drawing.SystemColors.Control
        Me.Label70.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.Location = New System.Drawing.Point(447, 119)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(38, 15)
        Me.Label70.TabIndex = 263
        Me.Label70.Text = "Clase"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(34, 8)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(398, 40)
        Me.ReflectionLabel1.TabIndex = 272
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CAPTURA DE MULTIFORMA</b></font>"
        '
        'txtTurno
        '
        '
        '
        '
        Me.txtTurno.Border.Class = "TextBoxBorder"
        Me.txtTurno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtTurno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTurno.ForeColor = System.Drawing.Color.Black
        Me.txtTurno.Location = New System.Drawing.Point(532, 9)
        Me.txtTurno.Name = "txtTurno"
        Me.txtTurno.ReadOnly = True
        Me.txtTurno.Size = New System.Drawing.Size(168, 21)
        Me.txtTurno.TabIndex = 264
        '
        'txtHorario
        '
        '
        '
        '
        Me.txtHorario.Border.Class = "TextBoxBorder"
        Me.txtHorario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtHorario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHorario.ForeColor = System.Drawing.Color.Black
        Me.txtHorario.Location = New System.Drawing.Point(532, 36)
        Me.txtHorario.Name = "txtHorario"
        Me.txtHorario.ReadOnly = True
        Me.txtHorario.Size = New System.Drawing.Size(168, 21)
        Me.txtHorario.TabIndex = 266
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.BackColor = System.Drawing.SystemColors.Control
        Me.Label69.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.Location = New System.Drawing.Point(447, 12)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(39, 15)
        Me.Label69.TabIndex = 265
        Me.Label69.Text = "Turno"
        '
        'frmMultiforma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1318, 358)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMultiforma"
        Me.Text = "Captura de multiforma"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgTabla, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCentrarControles.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabTabla As DevComponents.DotNetBar.SuperTabItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents lblEstado As DevComponents.DotNetBar.LabelX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblBaja As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDepto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtPuesto As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents txtTipoEmp As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents txtBaja As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtSupervisor As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtAlta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents txtClase As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents picFoto As System.Windows.Forms.PictureBox
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents txtTurno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtHorario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnLast As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNext As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrev As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnFirst As DevComponents.DotNetBar.ButtonX
    Friend WithEvents pnlCentrarControles As System.Windows.Forms.Panel
    Friend WithEvents dgTabla As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents btnConfirmar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CRELOJ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_CAPTURA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HORA_CAPTURA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cusuario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOVIMIENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Detalle As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMENTARIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CONFIRMADO As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents IMPRESO As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents txtArea As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
