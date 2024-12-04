<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCapturaCursosTemp
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapturaCursosTemp))
        Me.btnMostrarInformacion = New DevComponents.DotNetBar.ButtonX()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnParametros = New DevComponents.DotNetBar.ButtonX()
        Me.btnAplicar = New DevComponents.DotNetBar.ButtonX()
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.EmpNav = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbAplicar = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.dgCursosEmp = New System.Windows.Forms.DataGridView()
        Me.colReloj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCurso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInstituto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInstructor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCalificacion = New DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn()
        Me.colAprobado = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.colCodCurso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCodInst = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCodInstr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColumnDuracion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colComentarios = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.EmpNav.SuspendLayout()
        CType(Me.dgCursosEmp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnMostrarInformacion
        '
        Me.btnMostrarInformacion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnMostrarInformacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMostrarInformacion.CausesValidation = False
        Me.btnMostrarInformacion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnMostrarInformacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMostrarInformacion.Image = Global.PIDA.My.Resources.Resources.refresh16
        Me.btnMostrarInformacion.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnMostrarInformacion.Location = New System.Drawing.Point(959, 12)
        Me.btnMostrarInformacion.Name = "btnMostrarInformacion"
        Me.btnMostrarInformacion.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(20)
        Me.btnMostrarInformacion.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5)
        Me.btnMostrarInformacion.Size = New System.Drawing.Size(37, 25)
        Me.btnMostrarInformacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnMostrarInformacion.TabIndex = 117
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(45, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(364, 40)
        Me.ReflectionLabel1.TabIndex = 118
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CAPTURA DE CURSOS</b></font>"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(553, 11)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(78, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 58
        Me.btnCerrar.Text = "Salir"
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnReporte.Location = New System.Drawing.Point(5, 11)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 25)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 57
        Me.btnReporte.Text = "Reporte"
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = Global.PIDA.My.Resources.Resources.DeleteRec
        Me.btnBorrar.Location = New System.Drawing.Point(467, 11)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(78, 25)
        Me.btnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBorrar.TabIndex = 56
        Me.btnBorrar.Text = "Borrar"
        '
        'btnParametros
        '
        Me.btnParametros.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnParametros.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnParametros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnParametros.Image = Global.PIDA.My.Resources.Resources.CambiosMasivos16
        Me.btnParametros.Location = New System.Drawing.Point(177, 11)
        Me.btnParametros.Name = "btnParametros"
        Me.btnParametros.Size = New System.Drawing.Size(110, 25)
        Me.btnParametros.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnParametros.TabIndex = 26
        Me.btnParametros.Text = "Agregar grupo"
        '
        'btnAplicar
        '
        Me.btnAplicar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAplicar.CausesValidation = False
        Me.btnAplicar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAplicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAplicar.Location = New System.Drawing.Point(91, 11)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(78, 25)
        Me.btnAplicar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAplicar.TabIndex = 51
        Me.btnAplicar.Text = "Aplicar"
        Me.btnAplicar.Tooltip = "Buscar"
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = Global.PIDA.My.Resources.Resources.Edit
        Me.btnEditar.Location = New System.Drawing.Point(379, 11)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(78, 25)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 53
        Me.btnEditar.Text = "Editar"
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.NewRecord
        Me.btnNuevo.Location = New System.Drawing.Point(295, 11)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 25)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 52
        Me.btnNuevo.Text = "Agregar"
        '
        'EmpNav
        '
        Me.EmpNav.Controls.Add(Me.btnCerrar)
        Me.EmpNav.Controls.Add(Me.btnReporte)
        Me.EmpNav.Controls.Add(Me.btnBorrar)
        Me.EmpNav.Controls.Add(Me.btnParametros)
        Me.EmpNav.Controls.Add(Me.btnAplicar)
        Me.EmpNav.Controls.Add(Me.btnEditar)
        Me.EmpNav.Controls.Add(Me.btnNuevo)
        Me.EmpNav.Location = New System.Drawing.Point(186, 485)
        Me.EmpNav.Name = "EmpNav"
        Me.EmpNav.Padding = New System.Windows.Forms.Padding(0)
        Me.EmpNav.Size = New System.Drawing.Size(637, 42)
        Me.EmpNav.TabIndex = 116
        Me.EmpNav.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkRed
        Me.Label1.Location = New System.Drawing.Point(9, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(626, 13)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "Pantalla de captura de cursos. Solo se reflejará en el archivo de empleados cuand" & _
    "o se apliquen los cambios."
        '
        'pbAplicar
        '
        Me.pbAplicar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.pbAplicar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pbAplicar.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.pbAplicar.BackgroundStyle.TextColor = System.Drawing.SystemColors.WindowText
        Me.pbAplicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbAplicar.Location = New System.Drawing.Point(12, 71)
        Me.pbAplicar.Name = "pbAplicar"
        Me.pbAplicar.Size = New System.Drawing.Size(984, 23)
        Me.pbAplicar.TabIndex = 121
        Me.pbAplicar.Text = "Aplicar"
        Me.pbAplicar.TextVisible = True
        Me.pbAplicar.Value = 20
        Me.pbAplicar.Visible = False
        '
        'dgCursosEmp
        '
        Me.dgCursosEmp.AllowUserToAddRows = False
        Me.dgCursosEmp.AllowUserToOrderColumns = True
        Me.dgCursosEmp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCursosEmp.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgCursosEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCursosEmp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colReloj, Me.colNombre, Me.colCurso, Me.colInstituto, Me.colInstructor, Me.colInicio, Me.colFin, Me.colCalificacion, Me.colAprobado, Me.colCodCurso, Me.colCodInst, Me.colCodInstr, Me.ColumnDuracion, Me.colComentarios})
        Me.dgCursosEmp.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgCursosEmp.Location = New System.Drawing.Point(12, 99)
        Me.dgCursosEmp.Name = "dgCursosEmp"
        Me.dgCursosEmp.ReadOnly = True
        Me.dgCursosEmp.RowHeadersWidth = 20
        Me.dgCursosEmp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCursosEmp.Size = New System.Drawing.Size(984, 380)
        Me.dgCursosEmp.TabIndex = 115
        '
        'colReloj
        '
        Me.colReloj.DataPropertyName = "reloj"
        Me.colReloj.Frozen = True
        Me.colReloj.HeaderText = "RELOJ"
        Me.colReloj.Name = "colReloj"
        Me.colReloj.ReadOnly = True
        Me.colReloj.Width = 45
        '
        'colNombre
        '
        Me.colNombre.DataPropertyName = "nombres"
        Me.colNombre.HeaderText = "NOMBRE"
        Me.colNombre.Name = "colNombre"
        Me.colNombre.ReadOnly = True
        Me.colNombre.Width = 150
        '
        'colCurso
        '
        Me.colCurso.DataPropertyName = "curso"
        Me.colCurso.HeaderText = "CURSO"
        Me.colCurso.Name = "colCurso"
        Me.colCurso.ReadOnly = True
        Me.colCurso.Width = 150
        '
        'colInstituto
        '
        Me.colInstituto.DataPropertyName = "instituto"
        Me.colInstituto.HeaderText = "INSTITUTO"
        Me.colInstituto.Name = "colInstituto"
        Me.colInstituto.ReadOnly = True
        Me.colInstituto.Width = 150
        '
        'colInstructor
        '
        Me.colInstructor.DataPropertyName = "instructor"
        Me.colInstructor.HeaderText = "INSTRUCTOR"
        Me.colInstructor.Name = "colInstructor"
        Me.colInstructor.ReadOnly = True
        Me.colInstructor.Width = 150
        '
        'colInicio
        '
        Me.colInicio.DataPropertyName = "inicio"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "d"
        Me.colInicio.DefaultCellStyle = DataGridViewCellStyle2
        Me.colInicio.HeaderText = "FECHA INICIO"
        Me.colInicio.Name = "colInicio"
        Me.colInicio.ReadOnly = True
        Me.colInicio.Width = 75
        '
        'colFin
        '
        Me.colFin.DataPropertyName = "fin"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "d"
        Me.colFin.DefaultCellStyle = DataGridViewCellStyle3
        Me.colFin.HeaderText = "FECHA FIN"
        Me.colFin.Name = "colFin"
        Me.colFin.ReadOnly = True
        Me.colFin.Width = 75
        '
        'colCalificacion
        '
        '
        '
        '
        Me.colCalificacion.BackgroundStyle.Class = "DataGridViewNumericBorder"
        Me.colCalificacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.colCalificacion.DataPropertyName = "calificacion"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colCalificacion.DefaultCellStyle = DataGridViewCellStyle4
        Me.colCalificacion.HeaderText = "CALIF."
        Me.colCalificacion.MaxValue = 100
        Me.colCalificacion.MinValue = 0
        Me.colCalificacion.Name = "colCalificacion"
        Me.colCalificacion.ReadOnly = True
        Me.colCalificacion.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCalificacion.Width = 40
        '
        'colAprobado
        '
        Me.colAprobado.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.colAprobado.CheckBoxImageIndeterminate = Global.PIDA.My.Resources.Resources.Question16
        Me.colAprobado.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.CancelX
        Me.colAprobado.Checked = True
        Me.colAprobado.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.colAprobado.CheckValue = "N"
        Me.colAprobado.DataPropertyName = "aprobado"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.colAprobado.DefaultCellStyle = DataGridViewCellStyle5
        Me.colAprobado.HeaderText = "APROB."
        Me.colAprobado.Name = "colAprobado"
        Me.colAprobado.ReadOnly = True
        Me.colAprobado.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colAprobado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colAprobado.ThreeState = True
        Me.colAprobado.Width = 50
        '
        'colCodCurso
        '
        Me.colCodCurso.DataPropertyName = "cod_curso"
        Me.colCodCurso.HeaderText = "cod.curso"
        Me.colCodCurso.Name = "colCodCurso"
        Me.colCodCurso.ReadOnly = True
        Me.colCodCurso.Visible = False
        '
        'colCodInst
        '
        Me.colCodInst.DataPropertyName = "cod_instituto"
        Me.colCodInst.HeaderText = "cod.instituto"
        Me.colCodInst.Name = "colCodInst"
        Me.colCodInst.ReadOnly = True
        Me.colCodInst.Visible = False
        '
        'colCodInstr
        '
        Me.colCodInstr.DataPropertyName = "cod_instructor"
        Me.colCodInstr.HeaderText = "instructor"
        Me.colCodInstr.Name = "colCodInstr"
        Me.colCodInstr.ReadOnly = True
        Me.colCodInstr.Visible = False
        '
        'ColumnDuracion
        '
        Me.ColumnDuracion.DataPropertyName = "duracion"
        Me.ColumnDuracion.HeaderText = "DURACION (Hrs.)"
        Me.ColumnDuracion.Name = "ColumnDuracion"
        Me.ColumnDuracion.ReadOnly = True
        Me.ColumnDuracion.Width = 75
        '
        'colComentarios
        '
        Me.colComentarios.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colComentarios.DataPropertyName = "comentario"
        Me.colComentarios.HeaderText = "COMENTARIOS"
        Me.colComentarios.Name = "colComentarios"
        Me.colComentarios.ReadOnly = True
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.ModificacionesSueldo24
        Me.picImagen.Location = New System.Drawing.Point(12, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(27, 26)
        Me.picImagen.TabIndex = 119
        Me.picImagen.TabStop = False
        '
        'frmCapturaCursosTemp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 539)
        Me.Controls.Add(Me.btnMostrarInformacion)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.EmpNav)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pbAplicar)
        Me.Controls.Add(Me.dgCursosEmp)
        Me.Controls.Add(Me.picImagen)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCapturaCursosTemp"
        Me.Text = "Captura de cursos"
        Me.EmpNav.ResumeLayout(False)
        CType(Me.dgCursosEmp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnMostrarInformacion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnParametros As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAplicar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents EmpNav As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pbAplicar As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents dgCursosEmp As System.Windows.Forms.DataGridView
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents colReloj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCurso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInstituto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInstructor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInicio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCalificacion As DevComponents.DotNetBar.Controls.DataGridViewIntegerInputColumn
    Friend WithEvents colAprobado As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents colCodCurso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodInst As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodInstr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnDuracion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colComentarios As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
