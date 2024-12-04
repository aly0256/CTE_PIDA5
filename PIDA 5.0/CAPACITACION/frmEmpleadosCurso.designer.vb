<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmpleadosCurso
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmpleadosCurso))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.btnFirst = New DevComponents.DotNetBar.ButtonX()
        Me.btnPrev = New DevComponents.DotNetBar.ButtonX()
        Me.btnNext = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnLast = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnBuscar = New DevComponents.DotNetBar.ButtonX()
        Me.dgCapacitacion = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.pnlCursoInfo = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCodCurso = New DevComponents.DotNetBar.LabelX()
        Me.txtcomentario = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtnombre_curso = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtclasificacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtcategoria = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtduracion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.pnlNoEmpleado = New DevComponents.DotNetBar.PanelEx()
        Me.pnlPlaneados = New DevComponents.DotNetBar.PanelEx()
        Me.lblPlaneados = New System.Windows.Forms.Label()
        Me.lblPlnds = New System.Windows.Forms.Label()
        Me.pnlCompletados = New DevComponents.DotNetBar.PanelEx()
        Me.lblCompletados = New System.Windows.Forms.Label()
        Me.lblComp = New System.Windows.Forms.Label()
        Me.pnlTotalEmp = New DevComponents.DotNetBar.PanelEx()
        Me.lblTotalEmp = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtarea_tematica = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtobjetivo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtmodalidad = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.gpDatosEmp = New System.Windows.Forms.GroupBox()
        Me.lblEdoEmpleado = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.picFoto = New System.Windows.Forms.PictureBox()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.btnCursosEmpleado = New DevComponents.DotNetBar.ButtonX()
        Me.txtCursosPlaneados = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCursosCompletados = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNombreEmpleado = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnVerPDF3 = New DevComponents.DotNetBar.ButtonX()
        Me.btnSubirPdf3 = New DevComponents.DotNetBar.ButtonX()
        Me.txtPathPdf3 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnVerPDF2 = New DevComponents.DotNetBar.ButtonX()
        Me.btnSubirPdf2 = New DevComponents.DotNetBar.ButtonX()
        Me.txtPathPdf2 = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnGuardaDocs = New DevComponents.DotNetBar.ButtonX()
        Me.btnVerPDF = New DevComponents.DotNetBar.ButtonX()
        Me.btnSubirPDF = New DevComponents.DotNetBar.ButtonX()
        Me.txtPathPdf = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Panel1.SuspendLayout()
        CType(Me.dgCapacitacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCursoInfo.SuspendLayout()
        Me.pnlNoEmpleado.SuspendLayout()
        Me.pnlPlaneados.SuspendLayout()
        Me.pnlCompletados.SuspendLayout()
        Me.pnlTotalEmp.SuspendLayout()
        Me.gpDatosEmp.SuspendLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnBorrar)
        Me.Panel1.Controls.Add(Me.btnEditar)
        Me.Panel1.Controls.Add(Me.btnNuevo)
        Me.Panel1.Controls.Add(Me.btnFirst)
        Me.Panel1.Controls.Add(Me.btnPrev)
        Me.Panel1.Controls.Add(Me.btnNext)
        Me.Panel1.Controls.Add(Me.btnCerrar)
        Me.Panel1.Controls.Add(Me.btnLast)
        Me.Panel1.Controls.Add(Me.btnReporte)
        Me.Panel1.Controls.Add(Me.btnBuscar)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 549)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1262, 35)
        Me.Panel1.TabIndex = 150
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = Global.PIDA.My.Resources.Resources.DeleteRec
        Me.btnBorrar.Location = New System.Drawing.Point(889, 3)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(78, 25)
        Me.btnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBorrar.TabIndex = 45
        Me.btnBorrar.Text = "Borrar"
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = Global.PIDA.My.Resources.Resources.Edit
        Me.btnEditar.Location = New System.Drawing.Point(808, 3)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(78, 25)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 44
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.Visible = False
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.NewRecord
        Me.btnNuevo.Location = New System.Drawing.Point(727, 3)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 25)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 43
        Me.btnNuevo.Text = "Agregar"
        Me.btnNuevo.Visible = False
        '
        'btnFirst
        '
        Me.btnFirst.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnFirst.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnFirst.Image = Global.PIDA.My.Resources.Resources.First16
        Me.btnFirst.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnFirst.Location = New System.Drawing.Point(241, 3)
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
        Me.btnPrev.Location = New System.Drawing.Point(322, 3)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(78, 25)
        Me.btnPrev.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnPrev.TabIndex = 34
        Me.btnPrev.Text = "Anterior"
        '
        'btnNext
        '
        Me.btnNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNext.Image = Global.PIDA.My.Resources.Resources.Next16
        Me.btnNext.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnNext.Location = New System.Drawing.Point(403, 3)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(78, 25)
        Me.btnNext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNext.TabIndex = 35
        Me.btnNext.Text = "Siguiente"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(970, 3)
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
        Me.btnLast.Location = New System.Drawing.Point(484, 3)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(78, 25)
        Me.btnLast.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnLast.TabIndex = 36
        Me.btnLast.Text = "Final"
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnReporte.Location = New System.Drawing.Point(646, 3)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 38
        Me.btnReporte.Text = "Reporte"
        '
        'btnBuscar
        '
        Me.btnBuscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscar.CausesValidation = False
        Me.btnBuscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.btnBuscar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnBuscar.Location = New System.Drawing.Point(565, 3)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(78, 25)
        Me.btnBuscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscar.TabIndex = 37
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.Tooltip = "Buscar"
        '
        'dgCapacitacion
        '
        Me.dgCapacitacion.AllowUserToAddRows = False
        Me.dgCapacitacion.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.dgCapacitacion.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgCapacitacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCapacitacion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgCapacitacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCapacitacion.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgCapacitacion.EnableHeadersVisualStyles = False
        Me.dgCapacitacion.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgCapacitacion.Location = New System.Drawing.Point(16, 137)
        Me.dgCapacitacion.Name = "dgCapacitacion"
        Me.dgCapacitacion.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCapacitacion.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgCapacitacion.RowHeadersVisible = False
        Me.dgCapacitacion.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.dgCapacitacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCapacitacion.Size = New System.Drawing.Size(924, 290)
        Me.dgCapacitacion.TabIndex = 172
        '
        'pnlCursoInfo
        '
        Me.pnlCursoInfo.Controls.Add(Me.Label3)
        Me.pnlCursoInfo.Controls.Add(Me.Label2)
        Me.pnlCursoInfo.Controls.Add(Me.lblCodCurso)
        Me.pnlCursoInfo.Controls.Add(Me.txtcomentario)
        Me.pnlCursoInfo.Controls.Add(Me.txtnombre_curso)
        Me.pnlCursoInfo.Controls.Add(Me.Label1)
        Me.pnlCursoInfo.Controls.Add(Me.Label11)
        Me.pnlCursoInfo.Controls.Add(Me.txtclasificacion)
        Me.pnlCursoInfo.Controls.Add(Me.txtcategoria)
        Me.pnlCursoInfo.Controls.Add(Me.txtduracion)
        Me.pnlCursoInfo.Controls.Add(Me.pnlNoEmpleado)
        Me.pnlCursoInfo.Controls.Add(Me.Label4)
        Me.pnlCursoInfo.Controls.Add(Me.Label8)
        Me.pnlCursoInfo.Controls.Add(Me.txtarea_tematica)
        Me.pnlCursoInfo.Controls.Add(Me.txtobjetivo)
        Me.pnlCursoInfo.Controls.Add(Me.Label5)
        Me.pnlCursoInfo.Controls.Add(Me.Label7)
        Me.pnlCursoInfo.Controls.Add(Me.txtmodalidad)
        Me.pnlCursoInfo.Location = New System.Drawing.Point(16, 12)
        Me.pnlCursoInfo.Name = "pnlCursoInfo"
        Me.pnlCursoInfo.Size = New System.Drawing.Size(1233, 119)
        Me.pnlCursoInfo.TabIndex = 194
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(38, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 15)
        Me.Label3.TabIndex = 198
        Me.Label3.Text = "Clasificación"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(583, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 15)
        Me.Label2.TabIndex = 211
        Me.Label2.Text = "Comentario"
        '
        'lblCodCurso
        '
        Me.lblCodCurso.BackColor = System.Drawing.Color.MidnightBlue
        '
        '
        '
        Me.lblCodCurso.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblCodCurso.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCodCurso.ForeColor = System.Drawing.SystemColors.Window
        Me.lblCodCurso.Location = New System.Drawing.Point(0, 10)
        Me.lblCodCurso.Name = "lblCodCurso"
        Me.lblCodCurso.Size = New System.Drawing.Size(29, 98)
        Me.lblCodCurso.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblCodCurso.TabIndex = 194
        Me.lblCodCurso.Text = "Curso"
        Me.lblCodCurso.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblCodCurso.TextOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.lblCodCurso.VerticalTextTopUp = False
        '
        'txtcomentario
        '
        Me.txtcomentario.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtcomentario.Border.Class = "TextBoxBorder"
        Me.txtcomentario.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtcomentario.Enabled = False
        Me.txtcomentario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcomentario.ForeColor = System.Drawing.Color.Black
        Me.txtcomentario.Location = New System.Drawing.Point(586, 87)
        Me.txtcomentario.Name = "txtcomentario"
        Me.txtcomentario.ReadOnly = True
        Me.txtcomentario.Size = New System.Drawing.Size(338, 21)
        Me.txtcomentario.TabIndex = 210
        '
        'txtnombre_curso
        '
        Me.txtnombre_curso.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtnombre_curso.Border.Class = "TextBoxBorder"
        Me.txtnombre_curso.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtnombre_curso.Enabled = False
        Me.txtnombre_curso.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnombre_curso.ForeColor = System.Drawing.Color.Black
        Me.txtnombre_curso.Location = New System.Drawing.Point(41, 37)
        Me.txtnombre_curso.Name = "txtnombre_curso"
        Me.txtnombre_curso.ReadOnly = True
        Me.txtnombre_curso.Size = New System.Drawing.Size(520, 21)
        Me.txtnombre_curso.TabIndex = 195
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 15)
        Me.Label1.TabIndex = 196
        Me.Label1.Text = "Curso"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(422, 62)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(60, 15)
        Me.Label11.TabIndex = 209
        Me.Label11.Text = "Categoria"
        '
        'txtclasificacion
        '
        Me.txtclasificacion.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtclasificacion.Border.Class = "TextBoxBorder"
        Me.txtclasificacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtclasificacion.Enabled = False
        Me.txtclasificacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtclasificacion.ForeColor = System.Drawing.Color.Black
        Me.txtclasificacion.Location = New System.Drawing.Point(41, 87)
        Me.txtclasificacion.Name = "txtclasificacion"
        Me.txtclasificacion.ReadOnly = True
        Me.txtclasificacion.Size = New System.Drawing.Size(188, 21)
        Me.txtclasificacion.TabIndex = 197
        '
        'txtcategoria
        '
        Me.txtcategoria.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtcategoria.Border.Class = "TextBoxBorder"
        Me.txtcategoria.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtcategoria.Enabled = False
        Me.txtcategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcategoria.ForeColor = System.Drawing.Color.Black
        Me.txtcategoria.Location = New System.Drawing.Point(425, 87)
        Me.txtcategoria.Name = "txtcategoria"
        Me.txtcategoria.ReadOnly = True
        Me.txtcategoria.Size = New System.Drawing.Size(155, 21)
        Me.txtcategoria.TabIndex = 208
        '
        'txtduracion
        '
        Me.txtduracion.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtduracion.Border.Class = "TextBoxBorder"
        Me.txtduracion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtduracion.Enabled = False
        Me.txtduracion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtduracion.ForeColor = System.Drawing.Color.Black
        Me.txtduracion.Location = New System.Drawing.Point(235, 87)
        Me.txtduracion.Name = "txtduracion"
        Me.txtduracion.ReadOnly = True
        Me.txtduracion.Size = New System.Drawing.Size(57, 21)
        Me.txtduracion.TabIndex = 199
        '
        'pnlNoEmpleado
        '
        Me.pnlNoEmpleado.CanvasColor = System.Drawing.SystemColors.Control
        Me.pnlNoEmpleado.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pnlNoEmpleado.Controls.Add(Me.pnlPlaneados)
        Me.pnlNoEmpleado.Controls.Add(Me.pnlCompletados)
        Me.pnlNoEmpleado.Controls.Add(Me.pnlTotalEmp)
        Me.pnlNoEmpleado.DisabledBackColor = System.Drawing.Color.Empty
        Me.pnlNoEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlNoEmpleado.Location = New System.Drawing.Point(933, 64)
        Me.pnlNoEmpleado.Name = "pnlNoEmpleado"
        Me.pnlNoEmpleado.Size = New System.Drawing.Size(300, 44)
        Me.pnlNoEmpleado.Style.BackColor1.Color = System.Drawing.Color.Silver
        Me.pnlNoEmpleado.Style.BackColor2.Color = System.Drawing.Color.Silver
        Me.pnlNoEmpleado.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pnlNoEmpleado.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.pnlNoEmpleado.Style.GradientAngle = 90
        Me.pnlNoEmpleado.Style.MarginLeft = 10
        Me.pnlNoEmpleado.TabIndex = 207
        '
        'pnlPlaneados
        '
        Me.pnlPlaneados.CanvasColor = System.Drawing.SystemColors.Control
        Me.pnlPlaneados.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pnlPlaneados.Controls.Add(Me.lblPlaneados)
        Me.pnlPlaneados.Controls.Add(Me.lblPlnds)
        Me.pnlPlaneados.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlPlaneados.DisabledBackColor = System.Drawing.Color.Empty
        Me.pnlPlaneados.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlPlaneados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlPlaneados.Location = New System.Drawing.Point(200, 0)
        Me.pnlPlaneados.Name = "pnlPlaneados"
        Me.pnlPlaneados.Size = New System.Drawing.Size(100, 44)
        Me.pnlPlaneados.Style.BackColor1.Color = System.Drawing.Color.Silver
        Me.pnlPlaneados.Style.BackColor2.Color = System.Drawing.Color.Silver
        Me.pnlPlaneados.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pnlPlaneados.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.pnlPlaneados.Style.GradientAngle = 90
        Me.pnlPlaneados.Style.MarginLeft = 10
        Me.pnlPlaneados.TabIndex = 178
        '
        'lblPlaneados
        '
        Me.lblPlaneados.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblPlaneados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlaneados.Location = New System.Drawing.Point(0, 20)
        Me.lblPlaneados.Name = "lblPlaneados"
        Me.lblPlaneados.Size = New System.Drawing.Size(100, 24)
        Me.lblPlaneados.TabIndex = 213
        Me.lblPlaneados.Text = "0"
        Me.lblPlaneados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPlnds
        '
        Me.lblPlnds.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPlnds.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlnds.Location = New System.Drawing.Point(0, 0)
        Me.lblPlnds.Name = "lblPlnds"
        Me.lblPlnds.Size = New System.Drawing.Size(100, 20)
        Me.lblPlnds.TabIndex = 172
        Me.lblPlnds.Text = "Planeados"
        Me.lblPlnds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlCompletados
        '
        Me.pnlCompletados.CanvasColor = System.Drawing.SystemColors.Control
        Me.pnlCompletados.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pnlCompletados.Controls.Add(Me.lblCompletados)
        Me.pnlCompletados.Controls.Add(Me.lblComp)
        Me.pnlCompletados.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pnlCompletados.DisabledBackColor = System.Drawing.Color.Empty
        Me.pnlCompletados.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlCompletados.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlCompletados.Location = New System.Drawing.Point(100, 0)
        Me.pnlCompletados.Name = "pnlCompletados"
        Me.pnlCompletados.Size = New System.Drawing.Size(100, 44)
        Me.pnlCompletados.Style.BackColor1.Color = System.Drawing.Color.Gainsboro
        Me.pnlCompletados.Style.BackColor2.Color = System.Drawing.Color.Gainsboro
        Me.pnlCompletados.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pnlCompletados.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.pnlCompletados.Style.GradientAngle = 90
        Me.pnlCompletados.Style.MarginLeft = 10
        Me.pnlCompletados.TabIndex = 177
        '
        'lblCompletados
        '
        Me.lblCompletados.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblCompletados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompletados.Location = New System.Drawing.Point(0, 20)
        Me.lblCompletados.Name = "lblCompletados"
        Me.lblCompletados.Size = New System.Drawing.Size(100, 24)
        Me.lblCompletados.TabIndex = 213
        Me.lblCompletados.Text = "0"
        Me.lblCompletados.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblComp
        '
        Me.lblComp.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblComp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComp.Location = New System.Drawing.Point(0, 0)
        Me.lblComp.Name = "lblComp"
        Me.lblComp.Size = New System.Drawing.Size(100, 20)
        Me.lblComp.TabIndex = 172
        Me.lblComp.Text = "Completados"
        Me.lblComp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlTotalEmp
        '
        Me.pnlTotalEmp.CanvasColor = System.Drawing.SystemColors.Control
        Me.pnlTotalEmp.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.pnlTotalEmp.Controls.Add(Me.lblTotalEmp)
        Me.pnlTotalEmp.Controls.Add(Me.Label18)
        Me.pnlTotalEmp.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.pnlTotalEmp.DisabledBackColor = System.Drawing.Color.Empty
        Me.pnlTotalEmp.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTotalEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlTotalEmp.Location = New System.Drawing.Point(0, 0)
        Me.pnlTotalEmp.Name = "pnlTotalEmp"
        Me.pnlTotalEmp.Size = New System.Drawing.Size(100, 44)
        Me.pnlTotalEmp.Style.BackColor1.Color = System.Drawing.Color.DimGray
        Me.pnlTotalEmp.Style.BackColor2.Color = System.Drawing.Color.DimGray
        Me.pnlTotalEmp.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.pnlTotalEmp.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.pnlTotalEmp.Style.GradientAngle = 90
        Me.pnlTotalEmp.Style.MarginLeft = 10
        Me.pnlTotalEmp.TabIndex = 176
        '
        'lblTotalEmp
        '
        Me.lblTotalEmp.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblTotalEmp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalEmp.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblTotalEmp.Location = New System.Drawing.Point(0, 20)
        Me.lblTotalEmp.Name = "lblTotalEmp"
        Me.lblTotalEmp.Size = New System.Drawing.Size(100, 24)
        Me.lblTotalEmp.TabIndex = 212
        Me.lblTotalEmp.Text = "0"
        Me.lblTotalEmp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label18.Location = New System.Drawing.Point(0, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(100, 20)
        Me.Label18.TabIndex = 172
        Me.Label18.Text = "Total empleados"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(233, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 15)
        Me.Label4.TabIndex = 200
        Me.Label4.Text = "Duración"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(873, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 15)
        Me.Label8.TabIndex = 206
        Me.Label8.Text = "Objetivo"
        '
        'txtarea_tematica
        '
        Me.txtarea_tematica.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtarea_tematica.Border.Class = "TextBoxBorder"
        Me.txtarea_tematica.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtarea_tematica.Enabled = False
        Me.txtarea_tematica.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtarea_tematica.ForeColor = System.Drawing.Color.Black
        Me.txtarea_tematica.Location = New System.Drawing.Point(565, 37)
        Me.txtarea_tematica.Name = "txtarea_tematica"
        Me.txtarea_tematica.ReadOnly = True
        Me.txtarea_tematica.Size = New System.Drawing.Size(305, 21)
        Me.txtarea_tematica.TabIndex = 201
        '
        'txtobjetivo
        '
        Me.txtobjetivo.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtobjetivo.Border.Class = "TextBoxBorder"
        Me.txtobjetivo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtobjetivo.Enabled = False
        Me.txtobjetivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtobjetivo.ForeColor = System.Drawing.Color.Black
        Me.txtobjetivo.Location = New System.Drawing.Point(876, 37)
        Me.txtobjetivo.Name = "txtobjetivo"
        Me.txtobjetivo.ReadOnly = True
        Me.txtobjetivo.Size = New System.Drawing.Size(357, 21)
        Me.txtobjetivo.TabIndex = 205
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(563, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 15)
        Me.Label5.TabIndex = 202
        Me.Label5.Text = "Área temática"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(296, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 15)
        Me.Label7.TabIndex = 204
        Me.Label7.Text = "Modalidad"
        '
        'txtmodalidad
        '
        Me.txtmodalidad.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtmodalidad.Border.Class = "TextBoxBorder"
        Me.txtmodalidad.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtmodalidad.Enabled = False
        Me.txtmodalidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmodalidad.ForeColor = System.Drawing.Color.Black
        Me.txtmodalidad.Location = New System.Drawing.Point(298, 87)
        Me.txtmodalidad.Name = "txtmodalidad"
        Me.txtmodalidad.ReadOnly = True
        Me.txtmodalidad.Size = New System.Drawing.Size(120, 21)
        Me.txtmodalidad.TabIndex = 203
        '
        'gpDatosEmp
        '
        Me.gpDatosEmp.Controls.Add(Me.lblEdoEmpleado)
        Me.gpDatosEmp.Controls.Add(Me.LabelX4)
        Me.gpDatosEmp.Controls.Add(Me.txtReloj)
        Me.gpDatosEmp.Controls.Add(Me.picFoto)
        Me.gpDatosEmp.Controls.Add(Me.LabelX1)
        Me.gpDatosEmp.Controls.Add(Me.btnCursosEmpleado)
        Me.gpDatosEmp.Controls.Add(Me.txtCursosPlaneados)
        Me.gpDatosEmp.Controls.Add(Me.Label10)
        Me.gpDatosEmp.Controls.Add(Me.txtCursosCompletados)
        Me.gpDatosEmp.Controls.Add(Me.Label9)
        Me.gpDatosEmp.Controls.Add(Me.txtNombreEmpleado)
        Me.gpDatosEmp.Controls.Add(Me.Label6)
        Me.gpDatosEmp.Location = New System.Drawing.Point(952, 134)
        Me.gpDatosEmp.Name = "gpDatosEmp"
        Me.gpDatosEmp.Size = New System.Drawing.Size(297, 403)
        Me.gpDatosEmp.TabIndex = 195
        Me.gpDatosEmp.TabStop = False
        '
        'lblEdoEmpleado
        '
        Me.lblEdoEmpleado.BackColor = System.Drawing.Color.DimGray
        '
        '
        '
        Me.lblEdoEmpleado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblEdoEmpleado.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdoEmpleado.ForeColor = System.Drawing.SystemColors.Window
        Me.lblEdoEmpleado.Location = New System.Drawing.Point(151, 119)
        Me.lblEdoEmpleado.Name = "lblEdoEmpleado"
        Me.lblEdoEmpleado.Size = New System.Drawing.Size(129, 23)
        Me.lblEdoEmpleado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.lblEdoEmpleado.TabIndex = 229
        Me.lblEdoEmpleado.Text = "---"
        Me.lblEdoEmpleado.TextAlignment = System.Drawing.StringAlignment.Center
        Me.lblEdoEmpleado.VerticalTextTopUp = False
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LabelX4.Location = New System.Drawing.Point(186, 59)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(56, 23)
        Me.LabelX4.TabIndex = 228
        Me.LabelX4.Text = "Reloj"
        Me.LabelX4.TextAlignment = System.Drawing.StringAlignment.Center
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
        Me.txtReloj.Location = New System.Drawing.Point(151, 87)
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.ReadOnly = True
        Me.txtReloj.Size = New System.Drawing.Size(129, 26)
        Me.txtReloj.TabIndex = 227
        Me.txtReloj.Text = "---"
        Me.txtReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'picFoto
        '
        Me.picFoto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picFoto.ErrorImage = Global.PIDA.My.Resources.Resources.NoFoto
        Me.picFoto.Image = Global.PIDA.My.Resources.Resources.NoFoto
        Me.picFoto.Location = New System.Drawing.Point(33, 42)
        Me.picFoto.MaximumSize = New System.Drawing.Size(164, 210)
        Me.picFoto.MinimumSize = New System.Drawing.Size(78, 100)
        Me.picFoto.Name = "picFoto"
        Me.picFoto.Size = New System.Drawing.Size(78, 100)
        Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picFoto.TabIndex = 226
        Me.picFoto.TabStop = False
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.ForeColor = System.Drawing.Color.Black
        Me.LabelX1.Location = New System.Drawing.Point(79, 13)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(151, 23)
        Me.LabelX1.TabIndex = 225
        Me.LabelX1.Text = "Datos de empleado"
        '
        'btnCursosEmpleado
        '
        Me.btnCursosEmpleado.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCursosEmpleado.CausesValidation = False
        Me.btnCursosEmpleado.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCursosEmpleado.Enabled = False
        Me.btnCursosEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCursosEmpleado.Image = Global.PIDA.My.Resources.Resources.Busca48
        Me.btnCursosEmpleado.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCursosEmpleado.Location = New System.Drawing.Point(19, 362)
        Me.btnCursosEmpleado.Name = "btnCursosEmpleado"
        Me.btnCursosEmpleado.Size = New System.Drawing.Size(261, 31)
        Me.btnCursosEmpleado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCursosEmpleado.TabIndex = 224
        Me.btnCursosEmpleado.Text = "Ir a cursos de empleado"
        '
        'txtCursosPlaneados
        '
        Me.txtCursosPlaneados.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtCursosPlaneados.Border.Class = "TextBoxBorder"
        Me.txtCursosPlaneados.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCursosPlaneados.Enabled = False
        Me.txtCursosPlaneados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCursosPlaneados.ForeColor = System.Drawing.Color.Black
        Me.txtCursosPlaneados.Location = New System.Drawing.Point(177, 309)
        Me.txtCursosPlaneados.Name = "txtCursosPlaneados"
        Me.txtCursosPlaneados.ReadOnly = True
        Me.txtCursosPlaneados.Size = New System.Drawing.Size(103, 21)
        Me.txtCursosPlaneados.TabIndex = 223
        Me.txtCursosPlaneados.Text = "---"
        Me.txtCursosPlaneados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(174, 233)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 15)
        Me.Label10.TabIndex = 222
        Me.Label10.Text = "Cursos planeados"
        '
        'txtCursosCompletados
        '
        Me.txtCursosCompletados.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtCursosCompletados.Border.Class = "TextBoxBorder"
        Me.txtCursosCompletados.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCursosCompletados.Enabled = False
        Me.txtCursosCompletados.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCursosCompletados.ForeColor = System.Drawing.Color.Black
        Me.txtCursosCompletados.Location = New System.Drawing.Point(19, 309)
        Me.txtCursosCompletados.Name = "txtCursosCompletados"
        Me.txtCursosCompletados.ReadOnly = True
        Me.txtCursosCompletados.Size = New System.Drawing.Size(116, 21)
        Me.txtCursosCompletados.TabIndex = 221
        Me.txtCursosCompletados.Text = "---"
        Me.txtCursosCompletados.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 233)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(119, 15)
        Me.Label9.TabIndex = 220
        Me.Label9.Text = "Cursos completados"
        '
        'txtNombreEmpleado
        '
        Me.txtNombreEmpleado.BackColor = System.Drawing.SystemColors.Control
        '
        '
        '
        Me.txtNombreEmpleado.Border.Class = "TextBoxBorder"
        Me.txtNombreEmpleado.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNombreEmpleado.Enabled = False
        Me.txtNombreEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNombreEmpleado.ForeColor = System.Drawing.Color.Black
        Me.txtNombreEmpleado.Location = New System.Drawing.Point(19, 200)
        Me.txtNombreEmpleado.Name = "txtNombreEmpleado"
        Me.txtNombreEmpleado.ReadOnly = True
        Me.txtNombreEmpleado.Size = New System.Drawing.Size(261, 21)
        Me.txtNombreEmpleado.TabIndex = 219
        Me.txtNombreEmpleado.Text = "---"
        Me.txtNombreEmpleado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 172)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 15)
        Me.Label6.TabIndex = 218
        Me.Label6.Text = "Nombre Completo"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnVerPDF3)
        Me.GroupBox1.Controls.Add(Me.btnSubirPdf3)
        Me.GroupBox1.Controls.Add(Me.txtPathPdf3)
        Me.GroupBox1.Controls.Add(Me.btnVerPDF2)
        Me.GroupBox1.Controls.Add(Me.btnSubirPdf2)
        Me.GroupBox1.Controls.Add(Me.txtPathPdf2)
        Me.GroupBox1.Controls.Add(Me.btnGuardaDocs)
        Me.GroupBox1.Controls.Add(Me.btnVerPDF)
        Me.GroupBox1.Controls.Add(Me.btnSubirPDF)
        Me.GroupBox1.Controls.Add(Me.txtPathPdf)
        Me.GroupBox1.Location = New System.Drawing.Point(219, 433)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(721, 104)
        Me.GroupBox1.TabIndex = 196
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "****DOCS*****"
        '
        'btnVerPDF3
        '
        Me.btnVerPDF3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnVerPDF3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnVerPDF3.Location = New System.Drawing.Point(515, 69)
        Me.btnVerPDF3.Name = "btnVerPDF3"
        Me.btnVerPDF3.Size = New System.Drawing.Size(75, 20)
        Me.btnVerPDF3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnVerPDF3.TabIndex = 114
        Me.btnVerPDF3.Text = "Ver PDF"
        '
        'btnSubirPdf3
        '
        Me.btnSubirPdf3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSubirPdf3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSubirPdf3.Location = New System.Drawing.Point(486, 69)
        Me.btnSubirPdf3.Name = "btnSubirPdf3"
        Me.btnSubirPdf3.Size = New System.Drawing.Size(26, 21)
        Me.btnSubirPdf3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSubirPdf3.TabIndex = 113
        Me.btnSubirPdf3.Text = "..."
        '
        'txtPathPdf3
        '
        '
        '
        '
        Me.txtPathPdf3.Border.Class = "TextBoxBorder"
        Me.txtPathPdf3.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPathPdf3.Location = New System.Drawing.Point(37, 71)
        Me.txtPathPdf3.Name = "txtPathPdf3"
        Me.txtPathPdf3.PreventEnterBeep = True
        Me.txtPathPdf3.Size = New System.Drawing.Size(443, 20)
        Me.txtPathPdf3.TabIndex = 112
        '
        'btnVerPDF2
        '
        Me.btnVerPDF2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnVerPDF2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnVerPDF2.Location = New System.Drawing.Point(515, 44)
        Me.btnVerPDF2.Name = "btnVerPDF2"
        Me.btnVerPDF2.Size = New System.Drawing.Size(75, 20)
        Me.btnVerPDF2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnVerPDF2.TabIndex = 111
        Me.btnVerPDF2.Text = "Ver PDF"
        '
        'btnSubirPdf2
        '
        Me.btnSubirPdf2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSubirPdf2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSubirPdf2.Location = New System.Drawing.Point(486, 44)
        Me.btnSubirPdf2.Name = "btnSubirPdf2"
        Me.btnSubirPdf2.Size = New System.Drawing.Size(26, 21)
        Me.btnSubirPdf2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSubirPdf2.TabIndex = 110
        Me.btnSubirPdf2.Text = "..."
        '
        'txtPathPdf2
        '
        '
        '
        '
        Me.txtPathPdf2.Border.Class = "TextBoxBorder"
        Me.txtPathPdf2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPathPdf2.Location = New System.Drawing.Point(37, 46)
        Me.txtPathPdf2.Name = "txtPathPdf2"
        Me.txtPathPdf2.PreventEnterBeep = True
        Me.txtPathPdf2.Size = New System.Drawing.Size(443, 20)
        Me.txtPathPdf2.TabIndex = 109
        '
        'btnGuardaDocs
        '
        Me.btnGuardaDocs.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnGuardaDocs.CausesValidation = False
        Me.btnGuardaDocs.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnGuardaDocs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardaDocs.Image = Global.PIDA.My.Resources.Resources.Save24
        Me.btnGuardaDocs.Location = New System.Drawing.Point(593, 39)
        Me.btnGuardaDocs.Name = "btnGuardaDocs"
        Me.btnGuardaDocs.Size = New System.Drawing.Size(111, 26)
        Me.btnGuardaDocs.TabIndex = 108
        Me.btnGuardaDocs.Text = "Guardar Docs"
        '
        'btnVerPDF
        '
        Me.btnVerPDF.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnVerPDF.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnVerPDF.Location = New System.Drawing.Point(515, 17)
        Me.btnVerPDF.Name = "btnVerPDF"
        Me.btnVerPDF.Size = New System.Drawing.Size(75, 20)
        Me.btnVerPDF.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnVerPDF.TabIndex = 107
        Me.btnVerPDF.Text = "Ver PDF"
        '
        'btnSubirPDF
        '
        Me.btnSubirPDF.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnSubirPDF.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnSubirPDF.Location = New System.Drawing.Point(486, 17)
        Me.btnSubirPDF.Name = "btnSubirPDF"
        Me.btnSubirPDF.Size = New System.Drawing.Size(26, 21)
        Me.btnSubirPDF.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnSubirPDF.TabIndex = 106
        Me.btnSubirPDF.Text = "..."
        '
        'txtPathPdf
        '
        '
        '
        '
        Me.txtPathPdf.Border.Class = "TextBoxBorder"
        Me.txtPathPdf.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPathPdf.Location = New System.Drawing.Point(37, 19)
        Me.txtPathPdf.Name = "txtPathPdf"
        Me.txtPathPdf.PreventEnterBeep = True
        Me.txtPathPdf.Size = New System.Drawing.Size(443, 20)
        Me.txtPathPdf.TabIndex = 0
        '
        'frmEmpleadosCurso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1262, 584)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gpDatosEmp)
        Me.Controls.Add(Me.pnlCursoInfo)
        Me.Controls.Add(Me.dgCapacitacion)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEmpleadosCurso"
        Me.Text = "Empleados por curso"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgCapacitacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCursoInfo.ResumeLayout(False)
        Me.pnlCursoInfo.PerformLayout()
        Me.pnlNoEmpleado.ResumeLayout(False)
        Me.pnlPlaneados.ResumeLayout(False)
        Me.pnlCompletados.ResumeLayout(False)
        Me.pnlTotalEmp.ResumeLayout(False)
        Me.gpDatosEmp.ResumeLayout(False)
        Me.gpDatosEmp.PerformLayout()
        CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnFirst As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnPrev As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNext As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnLast As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBuscar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents dgCapacitacion As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents pnlCursoInfo As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblCodCurso As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtcomentario As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtnombre_curso As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtclasificacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtcategoria As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtduracion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents pnlNoEmpleado As DevComponents.DotNetBar.PanelEx
    Friend WithEvents pnlPlaneados As DevComponents.DotNetBar.PanelEx
    Friend WithEvents lblPlnds As System.Windows.Forms.Label
    Friend WithEvents pnlCompletados As DevComponents.DotNetBar.PanelEx
    Friend WithEvents lblComp As System.Windows.Forms.Label
    Friend WithEvents pnlTotalEmp As DevComponents.DotNetBar.PanelEx
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtarea_tematica As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtobjetivo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtmodalidad As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents lblPlaneados As System.Windows.Forms.Label
    Friend WithEvents lblCompletados As System.Windows.Forms.Label
    Friend WithEvents lblTotalEmp As System.Windows.Forms.Label
    Friend WithEvents gpDatosEmp As System.Windows.Forms.GroupBox
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents btnCursosEmpleado As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtCursosPlaneados As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtCursosCompletados As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNombreEmpleado As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents picFoto As System.Windows.Forms.PictureBox
    Friend WithEvents lblEdoEmpleado As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPathPdf As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnVerPDF As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSubirPDF As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnGuardaDocs As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnVerPDF3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSubirPdf3 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtPathPdf3 As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnVerPDF2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnSubirPdf2 As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtPathPdf2 As DevComponents.DotNetBar.Controls.TextBoxX

End Class
