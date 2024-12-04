<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRecertificaCurso
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRecertificaCurso))
        Me.EmpNav = New System.Windows.Forms.GroupBox()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.dgCursosEmp = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.btnReCertificar = New DevComponents.DotNetBar.ButtonX()
        Me.pnlDatosCertificacion = New System.Windows.Forms.Panel()
        Me.lblCerti = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblAlta = New System.Windows.Forms.Label()
        Me.ReflectionImage1 = New DevComponents.DotNetBar.Controls.ReflectionImage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblNombre = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.txtReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.cl_reloj = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_puesto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cl_certi = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.cl_alta = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.EmpNav.SuspendLayout()
        CType(Me.dgCursosEmp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatosCertificacion.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'EmpNav
        '
        Me.EmpNav.Controls.Add(Me.btnCancelar)
        Me.EmpNav.Location = New System.Drawing.Point(515, 444)
        Me.EmpNav.Name = "EmpNav"
        Me.EmpNav.Size = New System.Drawing.Size(95, 47)
        Me.EmpNav.TabIndex = 84
        Me.EmpNav.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCancelar.Location = New System.Drawing.Point(9, 13)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(76, 25)
        Me.btnCancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCancelar.TabIndex = 9
        Me.btnCancelar.Text = "Cancelar"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX2.Location = New System.Drawing.Point(13, 205)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(237, 23)
        Me.LabelX2.TabIndex = 184
        Me.LabelX2.Text = "Vista previa de empleados re-certificados"
        '
        'dgCursosEmp
        '
        Me.dgCursosEmp.AllowUserToAddRows = False
        Me.dgCursosEmp.AllowUserToDeleteRows = False
        Me.dgCursosEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCursosEmp.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cl_reloj, Me.cl_nombre, Me.cl_puesto, Me.cl_certi, Me.cl_alta})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCursosEmp.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgCursosEmp.GridColor = System.Drawing.Color.FromArgb(CType(CType(158, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.dgCursosEmp.Location = New System.Drawing.Point(13, 234)
        Me.dgCursosEmp.Name = "dgCursosEmp"
        Me.dgCursosEmp.ReadOnly = True
        Me.dgCursosEmp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCursosEmp.Size = New System.Drawing.Size(597, 202)
        Me.dgCursosEmp.TabIndex = 183
        '
        'Line1
        '
        Me.Line1.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Line1.Location = New System.Drawing.Point(13, 182)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(597, 23)
        Me.Line1.TabIndex = 185
        Me.Line1.Text = "Line1"
        '
        'btnReCertificar
        '
        Me.btnReCertificar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReCertificar.CausesValidation = False
        Me.btnReCertificar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReCertificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReCertificar.Image = Global.PIDA.My.Resources.Resources.Award32
        Me.btnReCertificar.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnReCertificar.Location = New System.Drawing.Point(27, 82)
        Me.btnReCertificar.Name = "btnReCertificar"
        Me.btnReCertificar.Size = New System.Drawing.Size(125, 93)
        Me.btnReCertificar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReCertificar.TabIndex = 187
        Me.btnReCertificar.Text = "Re-Certificar"
        '
        'pnlDatosCertificacion
        '
        Me.pnlDatosCertificacion.BackColor = System.Drawing.Color.Silver
        Me.pnlDatosCertificacion.Controls.Add(Me.lblCerti)
        Me.pnlDatosCertificacion.Controls.Add(Me.Label5)
        Me.pnlDatosCertificacion.Controls.Add(Me.lblAlta)
        Me.pnlDatosCertificacion.Controls.Add(Me.ReflectionImage1)
        Me.pnlDatosCertificacion.Controls.Add(Me.Label9)
        Me.pnlDatosCertificacion.Controls.Add(Me.Label6)
        Me.pnlDatosCertificacion.Location = New System.Drawing.Point(171, 82)
        Me.pnlDatosCertificacion.Name = "pnlDatosCertificacion"
        Me.pnlDatosCertificacion.Size = New System.Drawing.Size(435, 93)
        Me.pnlDatosCertificacion.TabIndex = 186
        '
        'lblCerti
        '
        Me.lblCerti.AutoSize = True
        Me.lblCerti.BackColor = System.Drawing.Color.Transparent
        Me.lblCerti.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCerti.ForeColor = System.Drawing.Color.White
        Me.lblCerti.Location = New System.Drawing.Point(216, 62)
        Me.lblCerti.Name = "lblCerti"
        Me.lblCerti.Size = New System.Drawing.Size(67, 15)
        Me.lblCerti.TabIndex = 183
        Me.lblCerti.Text = "Fecha certi"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(65, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(155, 15)
        Me.Label5.TabIndex = 182
        Me.Label5.Text = "Fecha Re-certificación:"
        '
        'lblAlta
        '
        Me.lblAlta.AutoSize = True
        Me.lblAlta.BackColor = System.Drawing.Color.Transparent
        Me.lblAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlta.ForeColor = System.Drawing.Color.White
        Me.lblAlta.Location = New System.Drawing.Point(216, 35)
        Me.lblAlta.Name = "lblAlta"
        Me.lblAlta.Size = New System.Drawing.Size(64, 15)
        Me.lblAlta.TabIndex = 181
        Me.lblAlta.Text = "Fecha alta"
        '
        'ReflectionImage1
        '
        '
        '
        '
        Me.ReflectionImage1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionImage1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.ReflectionImage1.Dock = System.Windows.Forms.DockStyle.Right
        Me.ReflectionImage1.Image = Global.PIDA.My.Resources.Resources.Award32
        Me.ReflectionImage1.Location = New System.Drawing.Point(377, 22)
        Me.ReflectionImage1.Name = "ReflectionImage1"
        Me.ReflectionImage1.Size = New System.Drawing.Size(58, 71)
        Me.ReflectionImage1.TabIndex = 179
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Gray
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(0, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(435, 22)
        Me.Label9.TabIndex = 178
        Me.Label9.Text = "ESTATUS: NO RE-CERTIFICADO"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(119, 35)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 15)
        Me.Label6.TabIndex = 163
        Me.Label6.Text = "Fecha alta:"
        '
        'lblNombre
        '
        '
        '
        '
        Me.lblNombre.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.Location = New System.Drawing.Point(158, 53)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(449, 23)
        Me.lblNombre.TabIndex = 189
        Me.lblNombre.Text = "Curso"
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX1.Location = New System.Drawing.Point(9, 53)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(143, 23)
        Me.LabelX1.TabIndex = 188
        Me.LabelX1.Text = "Empleado seleccionado:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LabelX4)
        Me.GroupBox1.Controls.Add(Me.txtReloj)
        Me.GroupBox1.Location = New System.Drawing.Point(435, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(171, 41)
        Me.GroupBox1.TabIndex = 190
        Me.GroupBox1.TabStop = False
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelX4.Location = New System.Drawing.Point(11, 11)
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
        Me.txtReloj.DisabledBackColor = System.Drawing.Color.White
        Me.txtReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReloj.Location = New System.Drawing.Point(82, 10)
        Me.txtReloj.Name = "txtReloj"
        Me.txtReloj.ReadOnly = True
        Me.txtReloj.Size = New System.Drawing.Size(84, 26)
        Me.txtReloj.TabIndex = 0
        Me.txtReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.Planeacion32
        Me.PictureBox1.Location = New System.Drawing.Point(8, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 40)
        Me.PictureBox1.TabIndex = 192
        Me.PictureBox1.TabStop = False
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(52, 5)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(377, 40)
        Me.ReflectionLabel1.TabIndex = 191
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>RE-CERTIFICACION DE EMPLEADO</b></font>"
        '
        'cl_reloj
        '
        Me.cl_reloj.DataPropertyName = "reloj"
        Me.cl_reloj.HeaderText = "Reloj"
        Me.cl_reloj.Name = "cl_reloj"
        Me.cl_reloj.ReadOnly = True
        Me.cl_reloj.Width = 80
        '
        'cl_nombre
        '
        Me.cl_nombre.DataPropertyName = "NOMBRES"
        Me.cl_nombre.HeaderText = "Nombre"
        Me.cl_nombre.Name = "cl_nombre"
        Me.cl_nombre.ReadOnly = True
        Me.cl_nombre.Width = 240
        '
        'cl_puesto
        '
        Me.cl_puesto.DataPropertyName = "cod_puesto"
        Me.cl_puesto.HeaderText = "Puesto"
        Me.cl_puesto.Name = "cl_puesto"
        Me.cl_puesto.ReadOnly = True
        Me.cl_puesto.Width = 60
        '
        'cl_certi
        '
        '
        '
        '
        Me.cl_certi.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.cl_certi.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cl_certi.DataPropertyName = "inicio"
        Me.cl_certi.HeaderText = "Re-Certificacion"
        Me.cl_certi.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.cl_certi.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.cl_certi.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cl_certi.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.cl_certi.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cl_certi.MonthCalendar.DisplayMonth = New Date(2021, 7, 1, 0, 0, 0, 0)
        Me.cl_certi.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.cl_certi.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.cl_certi.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cl_certi.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.cl_certi.Name = "cl_certi"
        Me.cl_certi.ReadOnly = True
        '
        'cl_alta
        '
        '
        '
        '
        Me.cl_alta.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.cl_alta.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cl_alta.DataPropertyName = "alta"
        Me.cl_alta.HeaderText = "Alta"
        Me.cl_alta.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        Me.cl_alta.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.cl_alta.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cl_alta.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.cl_alta.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cl_alta.MonthCalendar.DisplayMonth = New Date(2021, 7, 1, 0, 0, 0, 0)
        Me.cl_alta.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.cl_alta.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.cl_alta.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cl_alta.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.cl_alta.Name = "cl_alta"
        Me.cl_alta.ReadOnly = True
        Me.cl_alta.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.cl_alta.Width = 80
        '
        'frmRecertificaCurso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 501)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnReCertificar)
        Me.Controls.Add(Me.pnlDatosCertificacion)
        Me.Controls.Add(Me.lblNombre)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.Line1)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.dgCursosEmp)
        Me.Controls.Add(Me.EmpNav)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmRecertificaCurso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Re-Certificación de empleado"
        Me.EmpNav.ResumeLayout(False)
        CType(Me.dgCursosEmp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatosCertificacion.ResumeLayout(False)
        Me.pnlDatosCertificacion.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents EmpNav As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents dgCursosEmp As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents cl_reloj As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cl_nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cl_puesto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cl_certi As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents cl_alta As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents btnReCertificar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents pnlDatosCertificacion As System.Windows.Forms.Panel
    Friend WithEvents lblCerti As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblAlta As System.Windows.Forms.Label
    Friend WithEvents ReflectionImage1 As DevComponents.DotNetBar.Controls.ReflectionImage
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblNombre As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents txtReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
End Class
