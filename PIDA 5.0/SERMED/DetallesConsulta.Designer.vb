<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DetallesConsulta
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
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.campoResponsable = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpProxima = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnReceta = New DevComponents.DotNetBar.ButtonX()
        Me.PanelEditable = New System.Windows.Forms.Panel()
        Me.campoFolio = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.campoMedicamento = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.campoComentarios = New System.Windows.Forms.TextBox()
        Me.campoDatos_clinicos = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.GroupBox1.SuspendLayout()
        Me.PanelEditable.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtpFecha
        '
        Me.dtpFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFecha.Enabled = False
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(544, 22)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(100, 20)
        Me.dtpFecha.TabIndex = 2007
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(607, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 2008
        Me.Label1.Text = "Fecha"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(3, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 2009
        Me.Label2.Text = "Responsable"
        '
        'campoResponsable
        '
        Me.campoResponsable.Enabled = False
        Me.campoResponsable.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.campoResponsable.Location = New System.Drawing.Point(6, 25)
        Me.campoResponsable.Name = "campoResponsable"
        Me.campoResponsable.Size = New System.Drawing.Size(100, 20)
        Me.campoResponsable.TabIndex = 2010
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(109, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 2012
        Me.Label3.Text = "Próxima Cita"
        '
        'dtpProxima
        '
        Me.dtpProxima.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.dtpProxima.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpProxima.Location = New System.Drawing.Point(112, 25)
        Me.dtpProxima.Name = "dtpProxima"
        Me.dtpProxima.Size = New System.Drawing.Size(100, 20)
        Me.dtpProxima.TabIndex = 2011
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnReceta)
        Me.GroupBox1.Controls.Add(Me.PanelEditable)
        Me.GroupBox1.Controls.Add(Me.btnEditar)
        Me.GroupBox1.Controls.Add(Me.btnCerrar)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(765, 360)
        Me.GroupBox1.TabIndex = 2015
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detalles de la Consulta"
        '
        'btnReceta
        '
        Me.btnReceta.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReceta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnReceta.CausesValidation = False
        Me.btnReceta.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReceta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReceta.Image = Global.PIDA.NET.My.Resources.Resources.sermed_receta
        Me.btnReceta.Location = New System.Drawing.Point(544, 329)
        Me.btnReceta.Name = "btnReceta"
        Me.btnReceta.Size = New System.Drawing.Size(90, 25)
        Me.btnReceta.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReceta.TabIndex = 2046
        Me.btnReceta.Text = "Receta"
        '
        'PanelEditable
        '
        Me.PanelEditable.Controls.Add(Me.Label2)
        Me.PanelEditable.Controls.Add(Me.campoFolio)
        Me.PanelEditable.Controls.Add(Me.dtpProxima)
        Me.PanelEditable.Controls.Add(Me.Label7)
        Me.PanelEditable.Controls.Add(Me.Label3)
        Me.PanelEditable.Controls.Add(Me.Label1)
        Me.PanelEditable.Controls.Add(Me.dtpFecha)
        Me.PanelEditable.Controls.Add(Me.campoMedicamento)
        Me.PanelEditable.Controls.Add(Me.Label4)
        Me.PanelEditable.Controls.Add(Me.campoComentarios)
        Me.PanelEditable.Controls.Add(Me.campoDatos_clinicos)
        Me.PanelEditable.Controls.Add(Me.Label6)
        Me.PanelEditable.Controls.Add(Me.campoResponsable)
        Me.PanelEditable.Controls.Add(Me.Label5)
        Me.PanelEditable.Enabled = False
        Me.PanelEditable.Location = New System.Drawing.Point(6, 19)
        Me.PanelEditable.Name = "PanelEditable"
        Me.PanelEditable.Size = New System.Drawing.Size(753, 297)
        Me.PanelEditable.TabIndex = 2045
        '
        'campoFolio
        '
        Me.campoFolio.Enabled = False
        Me.campoFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.campoFolio.Location = New System.Drawing.Point(650, 22)
        Me.campoFolio.Name = "campoFolio"
        Me.campoFolio.Size = New System.Drawing.Size(100, 20)
        Me.campoFolio.TabIndex = 2044
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label7.Location = New System.Drawing.Point(721, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 2043
        Me.Label7.Text = "Folio"
        '
        'campoMedicamento
        '
        Me.campoMedicamento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.campoMedicamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.campoMedicamento.Location = New System.Drawing.Point(6, 223)
        Me.campoMedicamento.Multiline = True
        Me.campoMedicamento.Name = "campoMedicamento"
        Me.campoMedicamento.Size = New System.Drawing.Size(441, 59)
        Me.campoMedicamento.TabIndex = 2020
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(3, 48)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 2014
        Me.Label4.Text = "Datos Clínicos"
        '
        'campoComentarios
        '
        Me.campoComentarios.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.campoComentarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.campoComentarios.Location = New System.Drawing.Point(6, 145)
        Me.campoComentarios.Multiline = True
        Me.campoComentarios.Name = "campoComentarios"
        Me.campoComentarios.Size = New System.Drawing.Size(744, 59)
        Me.campoComentarios.TabIndex = 2019
        '
        'campoDatos_clinicos
        '
        Me.campoDatos_clinicos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.campoDatos_clinicos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.campoDatos_clinicos.Location = New System.Drawing.Point(6, 64)
        Me.campoDatos_clinicos.Multiline = True
        Me.campoDatos_clinicos.Name = "campoDatos_clinicos"
        Me.campoDatos_clinicos.Size = New System.Drawing.Size(744, 59)
        Me.campoDatos_clinicos.TabIndex = 2013
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label6.Location = New System.Drawing.Point(3, 207)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 2018
        Me.Label6.Text = "Tratamiento"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(3, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 2016
        Me.Label5.Text = "Diagnóstico"
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
        Me.btnEditar.TabIndex = 2041
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
        Me.btnCerrar.TabIndex = 2042
        Me.btnCerrar.Text = "Guardar y Salir"
        '
        'DetallesConsulta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "DetallesConsulta"
        Me.Size = New System.Drawing.Size(765, 360)
        Me.GroupBox1.ResumeLayout(False)
        Me.PanelEditable.ResumeLayout(False)
        Me.PanelEditable.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents campoResponsable As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpProxima As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents campoMedicamento As System.Windows.Forms.TextBox
    Friend WithEvents campoComentarios As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents campoDatos_clinicos As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents campoFolio As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PanelEditable As System.Windows.Forms.Panel
    Friend WithEvents btnReceta As DevComponents.DotNetBar.ButtonX

End Class
