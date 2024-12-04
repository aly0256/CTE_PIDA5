<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargaExcepMasivo
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCargaExcepMasivo))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.GroupPanel2 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.lblRegistros = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.txtRuta = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnCarga = New DevComponents.DotNetBar.ButtonX()
        Me.dgExcepciones = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.colReloj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExcepcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFechaAplicar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCargar = New DevComponents.DotNetBar.ButtonX()
        Me.GroupPanel3 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.lblMostrarEjemplo = New DevComponents.DotNetBar.LabelX()
        Me.picEjemplo = New System.Windows.Forms.PictureBox()
        Me.lblInfo = New DevComponents.DotNetBar.LabelX()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.btnResultados = New DevComponents.DotNetBar.ButtonX()
        Me.lblEstatus = New DevComponents.DotNetBar.LabelX()
        Me.pbProgreso = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.ofDialogo = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel2.SuspendLayout()
        CType(Me.dgExcepciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel3.SuspendLayout()
        CType(Me.picEjemplo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.reloj_ta
        Me.PictureBox1.Location = New System.Drawing.Point(99, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 31)
        Me.PictureBox1.TabIndex = 130
        Me.PictureBox1.TabStop = False
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(139, 19)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(415, 31)
        Me.ReflectionLabel1.TabIndex = 129
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CARGA MASIVA DE EXCEPCIONES DE HORARIO</b></font>"
        '
        'GroupPanel2
        '
        Me.GroupPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupPanel2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel2.Controls.Add(Me.lblRegistros)
        Me.GroupPanel2.Controls.Add(Me.LabelX1)
        Me.GroupPanel2.Controls.Add(Me.LabelX2)
        Me.GroupPanel2.Controls.Add(Me.txtRuta)
        Me.GroupPanel2.Controls.Add(Me.btnCarga)
        Me.GroupPanel2.Controls.Add(Me.dgExcepciones)
        Me.GroupPanel2.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel2.Location = New System.Drawing.Point(15, 63)
        Me.GroupPanel2.Name = "GroupPanel2"
        Me.GroupPanel2.Size = New System.Drawing.Size(358, 378)
        '
        '
        '
        Me.GroupPanel2.Style.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.GroupPanel2.Style.BackColor2 = System.Drawing.SystemColors.InactiveBorder
        Me.GroupPanel2.Style.BackColorGradientAngle = 90
        Me.GroupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderBottomWidth = 1
        Me.GroupPanel2.Style.BorderColor = System.Drawing.SystemColors.WindowText
        Me.GroupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderLeftWidth = 1
        Me.GroupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderRightWidth = 1
        Me.GroupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel2.Style.BorderTopWidth = 1
        Me.GroupPanel2.Style.CornerDiameter = 6
        Me.GroupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel2.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel2.Style.TextColor = System.Drawing.SystemColors.HotTrack
        Me.GroupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel2.TabIndex = 137
        Me.GroupPanel2.Text = "Excepciones"
        '
        'lblRegistros
        '
        Me.lblRegistros.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblRegistros.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRegistros.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblRegistros.Location = New System.Drawing.Point(238, 70)
        Me.lblRegistros.Name = "lblRegistros"
        Me.lblRegistros.Size = New System.Drawing.Size(99, 23)
        Me.lblRegistros.TabIndex = 10
        Me.lblRegistros.Text = "No. registros:"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LabelX1.Location = New System.Drawing.Point(12, 7)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(168, 23)
        Me.LabelX1.TabIndex = 5
        Me.LabelX1.Text = "Ruta de archivo de excel"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.LabelX2.Location = New System.Drawing.Point(12, 70)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(77, 23)
        Me.LabelX2.TabIndex = 9
        Me.LabelX2.Text = "Vista previa"
        '
        'txtRuta
        '
        '
        '
        '
        Me.txtRuta.Border.Class = "TextBoxBorder"
        Me.txtRuta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtRuta.Enabled = False
        Me.txtRuta.Location = New System.Drawing.Point(12, 36)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.PreventEnterBeep = True
        Me.txtRuta.Size = New System.Drawing.Size(294, 20)
        Me.txtRuta.TabIndex = 6
        '
        'btnCarga
        '
        Me.btnCarga.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCarga.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCarga.Location = New System.Drawing.Point(313, 36)
        Me.btnCarga.Name = "btnCarga"
        Me.btnCarga.Size = New System.Drawing.Size(28, 20)
        Me.btnCarga.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCarga.TabIndex = 7
        Me.btnCarga.Text = "..."
        '
        'dgExcepciones
        '
        Me.dgExcepciones.AllowUserToDeleteRows = False
        Me.dgExcepciones.AllowUserToResizeColumns = False
        Me.dgExcepciones.AllowUserToResizeRows = False
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgExcepciones.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgExcepciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgExcepciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colReloj, Me.colExcepcion, Me.colFechaAplicar})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgExcepciones.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgExcepciones.EnableHeadersVisualStyles = False
        Me.dgExcepciones.GridColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.dgExcepciones.Location = New System.Drawing.Point(12, 99)
        Me.dgExcepciones.Name = "dgExcepciones"
        Me.dgExcepciones.ReadOnly = True
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgExcepciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgExcepciones.RowHeadersVisible = False
        Me.dgExcepciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.dgExcepciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgExcepciones.Size = New System.Drawing.Size(329, 246)
        Me.dgExcepciones.TabIndex = 8
        '
        'colReloj
        '
        Me.colReloj.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colReloj.HeaderText = "Reloj"
        Me.colReloj.Name = "colReloj"
        Me.colReloj.ReadOnly = True
        '
        'colExcepcion
        '
        Me.colExcepcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colExcepcion.HeaderText = "Codigo Excepcion"
        Me.colExcepcion.Name = "colExcepcion"
        Me.colExcepcion.ReadOnly = True
        '
        'colFechaAplicar
        '
        Me.colFechaAplicar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colFechaAplicar.HeaderText = "Fecha a aplicar"
        Me.colFechaAplicar.Name = "colFechaAplicar"
        Me.colFechaAplicar.ReadOnly = True
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelar.Location = New System.Drawing.Point(276, 455)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(91, 28)
        Me.btnCancelar.TabIndex = 139
        Me.btnCancelar.Text = "Salir"
        '
        'btnCargar
        '
        Me.btnCargar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCargar.CausesValidation = False
        Me.btnCargar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCargar.Enabled = False
        Me.btnCargar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCargar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnCargar.Location = New System.Drawing.Point(179, 455)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(91, 28)
        Me.btnCargar.TabIndex = 138
        Me.btnCargar.Text = "Cargar"
        '
        'GroupPanel3
        '
        Me.GroupPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupPanel3.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanel3.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel3.Controls.Add(Me.lblMostrarEjemplo)
        Me.GroupPanel3.Controls.Add(Me.picEjemplo)
        Me.GroupPanel3.Controls.Add(Me.lblInfo)
        Me.GroupPanel3.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel3.Location = New System.Drawing.Point(380, 72)
        Me.GroupPanel3.Name = "GroupPanel3"
        Me.GroupPanel3.Size = New System.Drawing.Size(300, 232)
        '
        '
        '
        Me.GroupPanel3.Style.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.GroupPanel3.Style.BackColor2 = System.Drawing.SystemColors.InactiveBorder
        Me.GroupPanel3.Style.BackColorGradientAngle = 90
        Me.GroupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderBottomWidth = 1
        Me.GroupPanel3.Style.BorderColor = System.Drawing.SystemColors.WindowText
        Me.GroupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderLeftWidth = 1
        Me.GroupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderRightWidth = 1
        Me.GroupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel3.Style.BorderTopWidth = 1
        Me.GroupPanel3.Style.CornerDiameter = 6
        Me.GroupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel3.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel3.Style.TextColor = System.Drawing.SystemColors.HotTrack
        Me.GroupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel3.TabIndex = 140
        Me.GroupPanel3.Text = "Información"
        '
        'lblMostrarEjemplo
        '
        Me.lblMostrarEjemplo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblMostrarEjemplo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblMostrarEjemplo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblMostrarEjemplo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMostrarEjemplo.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblMostrarEjemplo.Location = New System.Drawing.Point(60, 95)
        Me.lblMostrarEjemplo.Name = "lblMostrarEjemplo"
        Me.lblMostrarEjemplo.Size = New System.Drawing.Size(183, 23)
        Me.lblMostrarEjemplo.TabIndex = 9
        Me.lblMostrarEjemplo.Text = "** Dar click para mostrar ejemplo" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "    de layout de excel **"
        Me.lblMostrarEjemplo.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'picEjemplo
        '
        Me.picEjemplo.Image = CType(resources.GetObject("picEjemplo.Image"), System.Drawing.Image)
        Me.picEjemplo.Location = New System.Drawing.Point(11, 50)
        Me.picEjemplo.Name = "picEjemplo"
        Me.picEjemplo.Size = New System.Drawing.Size(271, 109)
        Me.picEjemplo.TabIndex = 10
        Me.picEjemplo.TabStop = False
        Me.picEjemplo.Visible = False
        '
        'lblInfo
        '
        Me.lblInfo.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblInfo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblInfo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.ForeColor = System.Drawing.Color.ForestGreen
        Me.lblInfo.Location = New System.Drawing.Point(15, 161)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(261, 55)
        Me.lblInfo.TabIndex = 11
        Me.lblInfo.Text = "Formato correcto que debe contener" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "el archivo de excel para realizar la" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "carga d" & _
    "e los horarios"
        Me.lblInfo.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblInfo.Visible = False
        '
        'GroupPanel1
        '
        Me.GroupPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupPanel1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel1.Controls.Add(Me.btnResultados)
        Me.GroupPanel1.Controls.Add(Me.lblEstatus)
        Me.GroupPanel1.Controls.Add(Me.pbProgreso)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(380, 308)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(300, 133)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.GroupPanel1.Style.BackColor2 = System.Drawing.SystemColors.InactiveBorder
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColor = System.Drawing.SystemColors.WindowText
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 6
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.GroupPanel1.Style.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel1.Style.TextColor = System.Drawing.SystemColors.HotTrack
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 141
        Me.GroupPanel1.Text = "Estatus"
        '
        'btnResultados
        '
        Me.btnResultados.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnResultados.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnResultados.Enabled = False
        Me.btnResultados.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResultados.Location = New System.Drawing.Point(228, 75)
        Me.btnResultados.Name = "btnResultados"
        Me.btnResultados.Size = New System.Drawing.Size(53, 23)
        Me.btnResultados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnResultados.TabIndex = 134
        Me.btnResultados.Text = "Resultados"
        '
        'lblEstatus
        '
        Me.lblEstatus.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.lblEstatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatus.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblEstatus.Location = New System.Drawing.Point(10, 3)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(271, 66)
        Me.lblEstatus.TabIndex = 133
        Me.lblEstatus.Text = "Estado"
        Me.lblEstatus.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'pbProgreso
        '
        '
        '
        '
        Me.pbProgreso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pbProgreso.Location = New System.Drawing.Point(13, 75)
        Me.pbProgreso.Name = "pbProgreso"
        Me.pbProgreso.Size = New System.Drawing.Size(206, 23)
        Me.pbProgreso.TabIndex = 132
        Me.pbProgreso.Text = "ProgressBarX1"
        '
        'ofDialogo
        '
        Me.ofDialogo.FileName = "OpenFileDialog1"
        '
        'frmCargaExcepMasivo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 495)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.GroupPanel3)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.GroupPanel2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCargaExcepMasivo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Carga masiva de excepciones de horario"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel2.ResumeLayout(False)
        CType(Me.dgExcepciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel3.ResumeLayout(False)
        CType(Me.picEjemplo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents GroupPanel2 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lblRegistros As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtRuta As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnCarga As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dgExcepciones As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents colReloj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExcepcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFechaAplicar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCargar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupPanel3 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents lblMostrarEjemplo As DevComponents.DotNetBar.LabelX
    Friend WithEvents picEjemplo As System.Windows.Forms.PictureBox
    Friend WithEvents lblInfo As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btnResultados As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblEstatus As DevComponents.DotNetBar.LabelX
    Friend WithEvents pbProgreso As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents ofDialogo As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
