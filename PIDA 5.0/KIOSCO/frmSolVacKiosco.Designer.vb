<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSolVacKiosco
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSolVacKiosco))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnEliminar = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancela = New DevComponents.DotNetBar.ButtonX()
        Me.btnConfirmar = New DevComponents.DotNetBar.ButtonX()
        Me.btnSalir = New DevComponents.DotNetBar.ButtonX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ImprimirGafeteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgSolicitudes = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COD_COMP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DETALLES = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RELOJ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOMBRE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_SOL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DIAS_SOLICITADOS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_INICIO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_FIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA_REGRESO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.APROBADO = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.DEPARTAMENTO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RELOJ_SUPER = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MOTIVO_RECHAZO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtDiasTotales = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFechaRegreso = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtFechaFin = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFechaIni = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblEdoSolicitud = New DevComponents.DotNetBar.LabelX()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.txtDetalles = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lblDetalle = New DevComponents.DotNetBar.LabelX()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.txtUltSol = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtNoSolAnio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblNomEmp = New System.Windows.Forms.Label()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.lblPendientes = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblConfirmados = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkMostrarPen = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.DataGridViewCheckBoxXColumn1 = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.dgSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.btnEliminar)
        Me.GroupBox2.Controls.Add(Me.btnReporte)
        Me.GroupBox2.Controls.Add(Me.btnCancela)
        Me.GroupBox2.Controls.Add(Me.btnConfirmar)
        Me.GroupBox2.Controls.Add(Me.btnSalir)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 402)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1335, 50)
        Me.GroupBox2.TabIndex = 130
        Me.GroupBox2.TabStop = False
        '
        'btnEliminar
        '
        Me.btnEliminar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEliminar.CausesValidation = False
        Me.btnEliminar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.Image = Global.PIDA.My.Resources.Resources.Delete
        Me.btnEliminar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnEliminar.Location = New System.Drawing.Point(311, 14)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(88, 25)
        Me.btnEliminar.TabIndex = 42
        Me.btnEliminar.Text = "Borrar"
        Me.btnEliminar.Visible = False
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Enabled = False
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnReporte.Location = New System.Drawing.Point(6, 14)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(87, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 41
        Me.btnReporte.Text = "Reporte"
        '
        'btnCancela
        '
        Me.btnCancela.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancela.CausesValidation = False
        Me.btnCancela.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancela.Enabled = False
        Me.btnCancela.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancela.Image = Global.PIDA.My.Resources.Resources.Cancel2_16
        Me.btnCancela.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCancela.Location = New System.Drawing.Point(99, 14)
        Me.btnCancela.Name = "btnCancela"
        Me.btnCancela.Size = New System.Drawing.Size(100, 25)
        Me.btnCancela.TabIndex = 4
        Me.btnCancela.Text = "No aprobado"
        '
        'btnConfirmar
        '
        Me.btnConfirmar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnConfirmar.CausesValidation = False
        Me.btnConfirmar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnConfirmar.Enabled = False
        Me.btnConfirmar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConfirmar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnConfirmar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnConfirmar.Location = New System.Drawing.Point(205, 14)
        Me.btnConfirmar.Name = "btnConfirmar"
        Me.btnConfirmar.Size = New System.Drawing.Size(100, 25)
        Me.btnConfirmar.TabIndex = 3
        Me.btnConfirmar.Text = "Aprobado"
        '
        'btnSalir
        '
        Me.btnSalir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSalir.CausesValidation = False
        Me.btnSalir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSalir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalir.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnSalir.Location = New System.Drawing.Point(1237, 14)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(87, 25)
        Me.btnSalir.TabIndex = 5
        Me.btnSalir.Text = "&Salir"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(53, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(438, 40)
        Me.ReflectionLabel1.TabIndex = 128
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>SOLICITUDES VACACIONES DE KIOSCO</b></font>"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImprimirGafeteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(157, 26)
        '
        'ImprimirGafeteToolStripMenuItem
        '
        Me.ImprimirGafeteToolStripMenuItem.Name = "ImprimirGafeteToolStripMenuItem"
        Me.ImprimirGafeteToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.ImprimirGafeteToolStripMenuItem.Text = "Imprimir gafete"
        '
        'dgSolicitudes
        '
        Me.dgSolicitudes.AllowUserToAddRows = False
        Me.dgSolicitudes.AllowUserToDeleteRows = False
        Me.dgSolicitudes.AllowUserToOrderColumns = True
        Me.dgSolicitudes.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Menu
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgSolicitudes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSolicitudes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgSolicitudes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSolicitudes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.COD_COMP, Me.DETALLES, Me.RELOJ, Me.NOMBRE, Me.FECHA_SOL, Me.DIAS_SOLICITADOS, Me.FECHA_INICIO, Me.FECHA_FIN, Me.FECHA_REGRESO, Me.APROBADO, Me.DEPARTAMENTO, Me.RELOJ_SUPER, Me.MOTIVO_RECHAZO})
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgSolicitudes.DefaultCellStyle = DataGridViewCellStyle10
        Me.dgSolicitudes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgSolicitudes.EnableHeadersVisualStyles = False
        Me.dgSolicitudes.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgSolicitudes.Location = New System.Drawing.Point(20, 114)
        Me.dgSolicitudes.MultiSelect = False
        Me.dgSolicitudes.Name = "dgSolicitudes"
        Me.dgSolicitudes.PaintEnhancedSelection = False
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSolicitudes.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgSolicitudes.RowHeadersVisible = False
        Me.dgSolicitudes.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText
        Me.dgSolicitudes.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight
        Me.dgSolicitudes.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgSolicitudes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgSolicitudes.Size = New System.Drawing.Size(990, 230)
        Me.dgSolicitudes.StandardTab = True
        Me.dgSolicitudes.TabIndex = 132
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ID.DefaultCellStyle = DataGridViewCellStyle3
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Visible = False
        '
        'COD_COMP
        '
        Me.COD_COMP.DataPropertyName = "COD_COMP"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.COD_COMP.DefaultCellStyle = DataGridViewCellStyle4
        Me.COD_COMP.HeaderText = "COMPAÑIA"
        Me.COD_COMP.Name = "COD_COMP"
        Me.COD_COMP.ReadOnly = True
        Me.COD_COMP.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.COD_COMP.Visible = False
        '
        'DETALLES
        '
        Me.DETALLES.DataPropertyName = "DETALLES"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DETALLES.DefaultCellStyle = DataGridViewCellStyle5
        Me.DETALLES.HeaderText = "DETALLES"
        Me.DETALLES.Name = "DETALLES"
        Me.DETALLES.ReadOnly = True
        Me.DETALLES.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DETALLES.Visible = False
        '
        'RELOJ
        '
        Me.RELOJ.DataPropertyName = "RELOJ"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.NullValue = " "
        Me.RELOJ.DefaultCellStyle = DataGridViewCellStyle6
        Me.RELOJ.HeaderText = "RELOJ"
        Me.RELOJ.Name = "RELOJ"
        Me.RELOJ.ReadOnly = True
        Me.RELOJ.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        '
        'NOMBRE
        '
        Me.NOMBRE.DataPropertyName = "NOMBRE"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.NOMBRE.DefaultCellStyle = DataGridViewCellStyle7
        Me.NOMBRE.HeaderText = "NOMBRE"
        Me.NOMBRE.Name = "NOMBRE"
        Me.NOMBRE.ReadOnly = True
        Me.NOMBRE.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.NOMBRE.Width = 300
        '
        'FECHA_SOL
        '
        Me.FECHA_SOL.DataPropertyName = "FECHA_SOLICITUD"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.FECHA_SOL.DefaultCellStyle = DataGridViewCellStyle8
        Me.FECHA_SOL.HeaderText = "FECHA DE SOLICITUD"
        Me.FECHA_SOL.Name = "FECHA_SOL"
        Me.FECHA_SOL.ReadOnly = True
        Me.FECHA_SOL.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FECHA_SOL.Width = 150
        '
        'DIAS_SOLICITADOS
        '
        Me.DIAS_SOLICITADOS.DataPropertyName = "DIAS_SOLICITADOS"
        Me.DIAS_SOLICITADOS.HeaderText = "DIAS SOLICITADOS"
        Me.DIAS_SOLICITADOS.Name = "DIAS_SOLICITADOS"
        Me.DIAS_SOLICITADOS.ReadOnly = True
        Me.DIAS_SOLICITADOS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DIAS_SOLICITADOS.Visible = False
        '
        'FECHA_INICIO
        '
        Me.FECHA_INICIO.DataPropertyName = "FECHA_INICIO"
        Me.FECHA_INICIO.HeaderText = "FECHA INICIO"
        Me.FECHA_INICIO.Name = "FECHA_INICIO"
        Me.FECHA_INICIO.ReadOnly = True
        Me.FECHA_INICIO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FECHA_INICIO.Visible = False
        '
        'FECHA_FIN
        '
        Me.FECHA_FIN.DataPropertyName = "FECHA_FIN"
        Me.FECHA_FIN.HeaderText = "FECHA FIN"
        Me.FECHA_FIN.Name = "FECHA_FIN"
        Me.FECHA_FIN.ReadOnly = True
        Me.FECHA_FIN.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FECHA_FIN.Visible = False
        '
        'FECHA_REGRESO
        '
        Me.FECHA_REGRESO.DataPropertyName = "FECHA_REGRESO"
        Me.FECHA_REGRESO.HeaderText = "FECHA REGRESO"
        Me.FECHA_REGRESO.Name = "FECHA_REGRESO"
        Me.FECHA_REGRESO.ReadOnly = True
        Me.FECHA_REGRESO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.FECHA_REGRESO.Visible = False
        '
        'APROBADO
        '
        Me.APROBADO.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.APROBADO.CheckBoxImageIndeterminate = Global.PIDA.My.Resources.Resources.asterisk_yellow
        Me.APROBADO.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.Cancel2_16
        Me.APROBADO.Checked = True
        Me.APROBADO.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.APROBADO.CheckValue = "N"
        Me.APROBADO.CheckValueChecked = "1"
        Me.APROBADO.CheckValueUnchecked = "0"
        Me.APROBADO.DataPropertyName = "APROBADO"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.APROBADO.DefaultCellStyle = DataGridViewCellStyle9
        Me.APROBADO.HeaderText = "ESTATUS"
        Me.APROBADO.Name = "APROBADO"
        Me.APROBADO.ReadOnly = True
        Me.APROBADO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.APROBADO.ThreeState = True
        '
        'DEPARTAMENTO
        '
        Me.DEPARTAMENTO.DataPropertyName = "DEPARTAMENTO"
        Me.DEPARTAMENTO.HeaderText = "DEPARTAMENTO"
        Me.DEPARTAMENTO.Name = "DEPARTAMENTO"
        Me.DEPARTAMENTO.ReadOnly = True
        Me.DEPARTAMENTO.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DEPARTAMENTO.Width = 390
        '
        'RELOJ_SUPER
        '
        Me.RELOJ_SUPER.DataPropertyName = "RELOJ_SUPER"
        Me.RELOJ_SUPER.HeaderText = "RELOJ_SUPER"
        Me.RELOJ_SUPER.Name = "RELOJ_SUPER"
        Me.RELOJ_SUPER.ReadOnly = True
        Me.RELOJ_SUPER.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.RELOJ_SUPER.Visible = False
        '
        'MOTIVO_RECHAZO
        '
        Me.MOTIVO_RECHAZO.DataPropertyName = "MOTIVO_RECHAZO"
        Me.MOTIVO_RECHAZO.HeaderText = "MOTIVO"
        Me.MOTIVO_RECHAZO.Name = "MOTIVO_RECHAZO"
        Me.MOTIVO_RECHAZO.ReadOnly = True
        Me.MOTIVO_RECHAZO.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtDiasTotales)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtFechaRegreso)
        Me.Panel1.Controls.Add(Me.txtFechaFin)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtFechaIni)
        Me.Panel1.Controls.Add(Me.lblEdoSolicitud)
        Me.Panel1.Location = New System.Drawing.Point(20, 58)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(990, 50)
        Me.Panel1.TabIndex = 133
        '
        'txtDiasTotales
        '
        Me.txtDiasTotales.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtDiasTotales.Border.Class = "TextBoxBorder"
        Me.txtDiasTotales.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDiasTotales.DisabledBackColor = System.Drawing.Color.White
        Me.txtDiasTotales.Enabled = False
        Me.txtDiasTotales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiasTotales.ForeColor = System.Drawing.Color.Black
        Me.txtDiasTotales.Location = New System.Drawing.Point(938, 14)
        Me.txtDiasTotales.Name = "txtDiasTotales"
        Me.txtDiasTotales.ReadOnly = True
        Me.txtDiasTotales.Size = New System.Drawing.Size(32, 21)
        Me.txtDiasTotales.TabIndex = 205
        Me.txtDiasTotales.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(866, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 15)
        Me.Label4.TabIndex = 204
        Me.Label4.Text = "Días totales"
        '
        'txtFechaRegreso
        '
        Me.txtFechaRegreso.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtFechaRegreso.Border.Class = "TextBoxBorder"
        Me.txtFechaRegreso.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaRegreso.DisabledBackColor = System.Drawing.Color.White
        Me.txtFechaRegreso.Enabled = False
        Me.txtFechaRegreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaRegreso.ForeColor = System.Drawing.Color.Black
        Me.txtFechaRegreso.Location = New System.Drawing.Point(674, 14)
        Me.txtFechaRegreso.Name = "txtFechaRegreso"
        Me.txtFechaRegreso.ReadOnly = True
        Me.txtFechaRegreso.Size = New System.Drawing.Size(85, 21)
        Me.txtFechaRegreso.TabIndex = 203
        Me.txtFechaRegreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtFechaFin
        '
        Me.txtFechaFin.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtFechaFin.Border.Class = "TextBoxBorder"
        Me.txtFechaFin.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaFin.DisabledBackColor = System.Drawing.Color.White
        Me.txtFechaFin.Enabled = False
        Me.txtFechaFin.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaFin.ForeColor = System.Drawing.Color.Black
        Me.txtFechaFin.Location = New System.Drawing.Point(386, 14)
        Me.txtFechaFin.Name = "txtFechaFin"
        Me.txtFechaFin.ReadOnly = True
        Me.txtFechaFin.Size = New System.Drawing.Size(85, 21)
        Me.txtFechaFin.TabIndex = 202
        Me.txtFechaFin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(617, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 15)
        Me.Label3.TabIndex = 201
        Me.Label3.Text = "Regreso"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(322, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 15)
        Me.Label1.TabIndex = 199
        Me.Label1.Text = "Fecha Fin"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 15)
        Me.Label2.TabIndex = 197
        Me.Label2.Text = "Fecha Inicio"
        '
        'txtFechaIni
        '
        Me.txtFechaIni.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtFechaIni.Border.Class = "TextBoxBorder"
        Me.txtFechaIni.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtFechaIni.DisabledBackColor = System.Drawing.Color.White
        Me.txtFechaIni.Enabled = False
        Me.txtFechaIni.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaIni.ForeColor = System.Drawing.Color.Black
        Me.txtFechaIni.Location = New System.Drawing.Point(105, 14)
        Me.txtFechaIni.Name = "txtFechaIni"
        Me.txtFechaIni.ReadOnly = True
        Me.txtFechaIni.Size = New System.Drawing.Size(85, 21)
        Me.txtFechaIni.TabIndex = 196
        Me.txtFechaIni.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblEdoSolicitud
        '
        Me.lblEdoSolicitud.BackColor = System.Drawing.Color.SlateGray
        '
        '
        '
        Me.lblEdoSolicitud.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblEdoSolicitud.Dock = System.Windows.Forms.DockStyle.Left
        Me.lblEdoSolicitud.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdoSolicitud.ForeColor = System.Drawing.SystemColors.Window
        Me.lblEdoSolicitud.Image = Global.PIDA.My.Resources.Resources.l_disponible
        Me.lblEdoSolicitud.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.lblEdoSolicitud.ImageTextSpacing = 0
        Me.lblEdoSolicitud.Location = New System.Drawing.Point(0, 0)
        Me.lblEdoSolicitud.Name = "lblEdoSolicitud"
        Me.lblEdoSolicitud.Size = New System.Drawing.Size(26, 48)
        Me.lblEdoSolicitud.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblEdoSolicitud.TabIndex = 195
        Me.lblEdoSolicitud.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblEdoSolicitud.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.lblEdoSolicitud.VerticalTextTopUp = False
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Panel8)
        Me.Panel3.Controls.Add(Me.lblDetalle)
        Me.Panel3.Controls.Add(Me.Panel6)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.lblNomEmp)
        Me.Panel3.Controls.Add(Me.LabelX1)
        Me.Panel3.Location = New System.Drawing.Point(1033, 58)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(320, 338)
        Me.Panel3.TabIndex = 135
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.txtDetalles)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 229)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.Panel8.Size = New System.Drawing.Size(318, 97)
        Me.Panel8.TabIndex = 237
        '
        'txtDetalles
        '
        Me.txtDetalles.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtDetalles.Border.Class = "TextBoxBorder"
        Me.txtDetalles.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDetalles.DisabledBackColor = System.Drawing.Color.White
        Me.txtDetalles.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtDetalles.Enabled = False
        Me.txtDetalles.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDetalles.ForeColor = System.Drawing.Color.Black
        Me.txtDetalles.Location = New System.Drawing.Point(10, 0)
        Me.txtDetalles.Multiline = True
        Me.txtDetalles.Name = "txtDetalles"
        Me.txtDetalles.ReadOnly = True
        Me.txtDetalles.Size = New System.Drawing.Size(298, 93)
        Me.txtDetalles.TabIndex = 232
        '
        'lblDetalle
        '
        '
        '
        '
        Me.lblDetalle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblDetalle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetalle.ForeColor = System.Drawing.Color.Black
        Me.lblDetalle.Location = New System.Drawing.Point(0, 199)
        Me.lblDetalle.Name = "lblDetalle"
        Me.lblDetalle.Size = New System.Drawing.Size(318, 30)
        Me.lblDetalle.TabIndex = 236
        Me.lblDetalle.Text = "Detalles de solicitud"
        Me.lblDetalle.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.txtUltSol)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 141)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.Panel6.Size = New System.Drawing.Size(318, 58)
        Me.Panel6.TabIndex = 235
        '
        'txtUltSol
        '
        Me.txtUltSol.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtUltSol.Border.Class = "TextBoxBorder"
        Me.txtUltSol.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtUltSol.DisabledBackColor = System.Drawing.Color.White
        Me.txtUltSol.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtUltSol.Enabled = False
        Me.txtUltSol.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUltSol.ForeColor = System.Drawing.Color.Black
        Me.txtUltSol.Location = New System.Drawing.Point(10, 14)
        Me.txtUltSol.Name = "txtUltSol"
        Me.txtUltSol.ReadOnly = True
        Me.txtUltSol.Size = New System.Drawing.Size(298, 21)
        Me.txtUltSol.TabIndex = 232
        Me.txtUltSol.Text = "---"
        Me.txtUltSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel7
        '
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(10, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(298, 14)
        Me.Panel7.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(0, 126)
        Me.Label7.Name = "Label7"
        Me.Label7.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.Label7.Size = New System.Drawing.Size(169, 15)
        Me.Label7.TabIndex = 235
        Me.Label7.Text = "Última solicitud (Año actual)"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.txtNoSolAnio)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 81)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Padding = New System.Windows.Forms.Padding(10, 0, 10, 0)
        Me.Panel2.Size = New System.Drawing.Size(318, 45)
        Me.Panel2.TabIndex = 234
        '
        'txtNoSolAnio
        '
        Me.txtNoSolAnio.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtNoSolAnio.Border.Class = "TextBoxBorder"
        Me.txtNoSolAnio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNoSolAnio.DisabledBackColor = System.Drawing.Color.White
        Me.txtNoSolAnio.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtNoSolAnio.Enabled = False
        Me.txtNoSolAnio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoSolAnio.ForeColor = System.Drawing.Color.Black
        Me.txtNoSolAnio.Location = New System.Drawing.Point(10, 14)
        Me.txtNoSolAnio.Name = "txtNoSolAnio"
        Me.txtNoSolAnio.ReadOnly = True
        Me.txtNoSolAnio.Size = New System.Drawing.Size(298, 21)
        Me.txtNoSolAnio.TabIndex = 230
        Me.txtNoSolAnio.Text = "---"
        Me.txtNoSolAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel5
        '
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(10, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(298, 14)
        Me.Panel5.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(0, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.Label5.Size = New System.Drawing.Size(167, 15)
        Me.Label5.TabIndex = 230
        Me.Label5.Text = "No. Solicitudes (Año actual)"
        '
        'lblNomEmp
        '
        Me.lblNomEmp.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblNomEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNomEmp.Location = New System.Drawing.Point(0, 30)
        Me.lblNomEmp.Name = "lblNomEmp"
        Me.lblNomEmp.Size = New System.Drawing.Size(318, 36)
        Me.lblNomEmp.TabIndex = 228
        Me.lblNomEmp.Text = "---"
        Me.lblNomEmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Dock = System.Windows.Forms.DockStyle.Top
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(0, 0)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(318, 30)
        Me.LabelX1.TabIndex = 227
        Me.LabelX1.Text = "Datos empleado"
        Me.LabelX1.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.lblPendientes)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.lblConfirmados)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.chkMostrarPen)
        Me.Panel4.Location = New System.Drawing.Point(18, 350)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(992, 46)
        Me.Panel4.TabIndex = 136
        '
        'lblPendientes
        '
        Me.lblPendientes.AutoSize = True
        Me.lblPendientes.BackColor = System.Drawing.Color.Transparent
        Me.lblPendientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendientes.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblPendientes.Location = New System.Drawing.Point(959, 15)
        Me.lblPendientes.Name = "lblPendientes"
        Me.lblPendientes.Size = New System.Drawing.Size(19, 15)
        Me.lblPendientes.TabIndex = 232
        Me.lblPendientes.Text = "---"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(891, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 15)
        Me.Label12.TabIndex = 231
        Me.Label12.Text = "Pendientes:"
        '
        'lblConfirmados
        '
        Me.lblConfirmados.AutoSize = True
        Me.lblConfirmados.BackColor = System.Drawing.Color.Transparent
        Me.lblConfirmados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfirmados.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblConfirmados.Location = New System.Drawing.Point(848, 15)
        Me.lblConfirmados.Name = "lblConfirmados"
        Me.lblConfirmados.Size = New System.Drawing.Size(19, 15)
        Me.lblConfirmados.TabIndex = 230
        Me.lblConfirmados.Text = "---"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(773, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 15)
        Me.Label9.TabIndex = 229
        Me.Label9.Text = "Confirmados:"
        '
        'chkMostrarPen
        '
        '
        '
        '
        Me.chkMostrarPen.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkMostrarPen.Checked = True
        Me.chkMostrarPen.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMostrarPen.CheckValue = "Y"
        Me.chkMostrarPen.Location = New System.Drawing.Point(10, 11)
        Me.chkMostrarPen.Name = "chkMostrarPen"
        Me.chkMostrarPen.Size = New System.Drawing.Size(119, 23)
        Me.chkMostrarPen.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkMostrarPen.TabIndex = 228
        Me.chkMostrarPen.Text = "Mostrar confirmados"
        Me.chkMostrarPen.TextColor = System.Drawing.Color.Black
        '
        'DataGridViewCheckBoxXColumn1
        '
        Me.DataGridViewCheckBoxXColumn1.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.DataGridViewCheckBoxXColumn1.CheckBoxImageIndeterminate = Global.PIDA.My.Resources.Resources.asterisk_yellow
        Me.DataGridViewCheckBoxXColumn1.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.Cancel16
        Me.DataGridViewCheckBoxXColumn1.Checked = True
        Me.DataGridViewCheckBoxXColumn1.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.DataGridViewCheckBoxXColumn1.CheckValue = "N"
        Me.DataGridViewCheckBoxXColumn1.CheckValueChecked = "1"
        Me.DataGridViewCheckBoxXColumn1.CheckValueUnchecked = "0"
        Me.DataGridViewCheckBoxXColumn1.DataPropertyName = "APROBADO"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewCheckBoxXColumn1.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewCheckBoxXColumn1.HeaderText = "APROBADO"
        Me.DataGridViewCheckBoxXColumn1.Name = "DataGridViewCheckBoxXColumn1"
        Me.DataGridViewCheckBoxXColumn1.ReadOnly = True
        Me.DataGridViewCheckBoxXColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewCheckBoxXColumn1.ThreeState = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.tests24
        Me.PictureBox1.Location = New System.Drawing.Point(20, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(27, 26)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 131
        Me.PictureBox1.TabStop = False
        '
        'frmSolVacKiosco
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1382, 464)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dgSolicitudes)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSolVacKiosco"
        Me.Text = "Solicitudes de vacaciones"
        Me.GroupBox2.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.dgSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancela As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnConfirmar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSalir As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ImprimirGafeteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents dgSolicitudes As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblEdoSolicitud As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtDiasTotales As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFechaRegreso As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtFechaFin As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFechaIni As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents lblNomEmp As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lblPendientes As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblConfirmados As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkMostrarPen As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents txtDetalles As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblDetalle As DevComponents.DotNetBar.LabelX
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents txtUltSol As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtNoSolAnio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents DataGridViewCheckBoxXColumn1 As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents btnEliminar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COD_COMP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DETALLES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RELOJ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOMBRE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_SOL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DIAS_SOLICITADOS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_INICIO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_FIN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA_REGRESO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents APROBADO As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents DEPARTAMENTO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RELOJ_SUPER As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MOTIVO_RECHAZO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
