<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCancelarDeducciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCancelarDeducciones))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.gpDatos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.pnlTransferencia = New System.Windows.Forms.Panel()
        Me.txtNvaClave = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkTransferencia = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.pnlDefinitiva = New System.Windows.Forms.Panel()
        Me.txtMotivo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumCancelacion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkDefinitivo = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.txtID = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtClave = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.gpDatos.SuspendLayout()
        Me.pnlTransferencia.SuspendLayout()
        Me.pnlDefinitiva.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnAceptar)
        Me.GroupBox2.Controls.Add(Me.Panel13)
        Me.GroupBox2.Controls.Add(Me.btnCerrar)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(10, 381)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(10, 0, 10, 8)
        Me.GroupBox2.Size = New System.Drawing.Size(356, 46)
        Me.GroupBox2.TabIndex = 260
        Me.GroupBox2.TabStop = False
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.acept_
        Me.btnAceptar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnAceptar.ImageTextSpacing = 3
        Me.btnAceptar.Location = New System.Drawing.Point(159, 13)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(90, 25)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 261
        Me.btnAceptar.Text = "Aceptar"
        '
        'Panel13
        '
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel13.Location = New System.Drawing.Point(249, 13)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(7, 25)
        Me.Panel13.TabIndex = 260
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.salir_
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.ImageTextSpacing = 3
        Me.btnCerrar.Location = New System.Drawing.Point(256, 13)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(90, 25)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 259
        Me.btnCerrar.Text = "Salir"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ReflectionLabel1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(10, 10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(356, 43)
        Me.Panel1.TabIndex = 261
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.BackgroundStyle.PaddingLeft = 10
        Me.ReflectionLabel1.BackgroundStyle.PaddingTop = 10
        Me.ReflectionLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(32, 0)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(324, 43)
        Me.ReflectionLabel1.TabIndex = 258
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CANCELA DEDUCCION / MODIFICA CREDITO</b></font>"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = Global.PIDA.My.Resources.Resources.cancel_
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 43)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 257
        Me.PictureBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.gpDatos)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(10, 53)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(356, 328)
        Me.Panel2.TabIndex = 262
        '
        'gpDatos
        '
        Me.gpDatos.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpDatos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpDatos.Controls.Add(Me.pnlTransferencia)
        Me.gpDatos.Controls.Add(Me.chkTransferencia)
        Me.gpDatos.Controls.Add(Me.pnlDefinitiva)
        Me.gpDatos.Controls.Add(Me.chkDefinitivo)
        Me.gpDatos.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gpDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpDatos.Location = New System.Drawing.Point(0, 58)
        Me.gpDatos.Name = "gpDatos"
        Me.gpDatos.Padding = New System.Windows.Forms.Padding(15)
        Me.gpDatos.Size = New System.Drawing.Size(356, 270)
        '
        '
        '
        Me.gpDatos.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpDatos.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpDatos.Style.BackColorGradientAngle = 90
        Me.gpDatos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDatos.Style.BorderBottomWidth = 1
        Me.gpDatos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpDatos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDatos.Style.BorderLeftWidth = 1
        Me.gpDatos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDatos.Style.BorderRightWidth = 1
        Me.gpDatos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpDatos.Style.BorderTopWidth = 1
        Me.gpDatos.Style.CornerDiameter = 4
        Me.gpDatos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpDatos.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.gpDatos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpDatos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpDatos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpDatos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpDatos.TabIndex = 40
        '
        'pnlTransferencia
        '
        Me.pnlTransferencia.BackColor = System.Drawing.SystemColors.Window
        Me.pnlTransferencia.Controls.Add(Me.txtNvaClave)
        Me.pnlTransferencia.Controls.Add(Me.Label3)
        Me.pnlTransferencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlTransferencia.Enabled = False
        Me.pnlTransferencia.Location = New System.Drawing.Point(15, 196)
        Me.pnlTransferencia.Name = "pnlTransferencia"
        Me.pnlTransferencia.Padding = New System.Windows.Forms.Padding(5)
        Me.pnlTransferencia.Size = New System.Drawing.Size(324, 57)
        Me.pnlTransferencia.TabIndex = 5
        '
        'txtNvaClave
        '
        '
        '
        '
        Me.txtNvaClave.Border.Class = "TextBoxBorder"
        Me.txtNvaClave.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNvaClave.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtNvaClave.Location = New System.Drawing.Point(5, 26)
        Me.txtNvaClave.MaxLength = 13
        Me.txtNvaClave.Name = "txtNvaClave"
        Me.txtNvaClave.Size = New System.Drawing.Size(314, 21)
        Me.txtNvaClave.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Location = New System.Drawing.Point(5, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(314, 21)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nueva clave crédito"
        '
        'chkTransferencia
        '
        Me.chkTransferencia.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkTransferencia.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkTransferencia.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkTransferencia.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkTransferencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTransferencia.Location = New System.Drawing.Point(15, 174)
        Me.chkTransferencia.Name = "chkTransferencia"
        Me.chkTransferencia.Size = New System.Drawing.Size(324, 22)
        Me.chkTransferencia.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkTransferencia.TabIndex = 3
        Me.chkTransferencia.Text = "Modificar clave de crédito"
        Me.chkTransferencia.TextColor = System.Drawing.Color.Black
        '
        'pnlDefinitiva
        '
        Me.pnlDefinitiva.BackColor = System.Drawing.SystemColors.Window
        Me.pnlDefinitiva.Controls.Add(Me.txtMotivo)
        Me.pnlDefinitiva.Controls.Add(Me.Label2)
        Me.pnlDefinitiva.Controls.Add(Me.txtNumCancelacion)
        Me.pnlDefinitiva.Controls.Add(Me.Label1)
        Me.pnlDefinitiva.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDefinitiva.Location = New System.Drawing.Point(15, 31)
        Me.pnlDefinitiva.Name = "pnlDefinitiva"
        Me.pnlDefinitiva.Padding = New System.Windows.Forms.Padding(5)
        Me.pnlDefinitiva.Size = New System.Drawing.Size(324, 143)
        Me.pnlDefinitiva.TabIndex = 2
        '
        'txtMotivo
        '
        '
        '
        '
        Me.txtMotivo.Border.Class = "TextBoxBorder"
        Me.txtMotivo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtMotivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtMotivo.Location = New System.Drawing.Point(5, 81)
        Me.txtMotivo.MaxLength = 100
        Me.txtMotivo.Multiline = True
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(314, 57)
        Me.txtMotivo.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Location = New System.Drawing.Point(5, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(314, 35)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Motivo"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumCancelacion
        '
        '
        '
        '
        Me.txtNumCancelacion.Border.Class = "TextBoxBorder"
        Me.txtNumCancelacion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNumCancelacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtNumCancelacion.Location = New System.Drawing.Point(5, 25)
        Me.txtNumCancelacion.Name = "txtNumCancelacion"
        Me.txtNumCancelacion.Size = New System.Drawing.Size(314, 21)
        Me.txtNumCancelacion.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(5, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(314, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Número de cancelación"
        '
        'chkDefinitivo
        '
        Me.chkDefinitivo.AutoSize = True
        Me.chkDefinitivo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.chkDefinitivo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkDefinitivo.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
        Me.chkDefinitivo.Checked = True
        Me.chkDefinitivo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDefinitivo.CheckValue = "Y"
        Me.chkDefinitivo.Dock = System.Windows.Forms.DockStyle.Top
        Me.chkDefinitivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDefinitivo.Location = New System.Drawing.Point(15, 15)
        Me.chkDefinitivo.Name = "chkDefinitivo"
        Me.chkDefinitivo.Size = New System.Drawing.Size(144, 16)
        Me.chkDefinitivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkDefinitivo.TabIndex = 1
        Me.chkDefinitivo.Text = "Cancelación definitiva"
        Me.chkDefinitivo.TextColor = System.Drawing.Color.Black
        '
        'Panel5
        '
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 48)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(356, 10)
        Me.Panel5.TabIndex = 39
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.GroupPanel1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 10)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(356, 38)
        Me.Panel4.TabIndex = 1
        '
        'GroupPanel1
        '
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel1.Controls.Add(Me.txtID)
        Me.GroupPanel1.Controls.Add(Me.txtClave)
        Me.GroupPanel1.Controls.Add(Me.Label4)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupPanel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupPanel1.Location = New System.Drawing.Point(0, 0)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Padding = New System.Windows.Forms.Padding(15, 5, 0, 0)
        Me.GroupPanel1.Size = New System.Drawing.Size(356, 38)
        '
        '
        '
        Me.GroupPanel1.Style.BackColor = System.Drawing.SystemColors.Window
        Me.GroupPanel1.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.GroupPanel1.Style.BackColorGradientAngle = 90
        Me.GroupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderBottomWidth = 1
        Me.GroupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.GroupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderLeftWidth = 1
        Me.GroupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderRightWidth = 1
        Me.GroupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.GroupPanel1.Style.BorderTopWidth = 1
        Me.GroupPanel1.Style.CornerDiameter = 4
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.GroupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.GroupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.GroupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.GroupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.GroupPanel1.TabIndex = 38
        '
        'txtID
        '
        Me.txtID.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtID.Border.Class = "TextBoxBorder"
        Me.txtID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtID.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtID.Enabled = False
        Me.txtID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtID.ForeColor = System.Drawing.Color.Black
        Me.txtID.Location = New System.Drawing.Point(240, 5)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(69, 26)
        Me.txtID.TabIndex = 42
        Me.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtID.Visible = False
        '
        'txtClave
        '
        Me.txtClave.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtClave.Border.Class = "TextBoxBorder"
        Me.txtClave.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtClave.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtClave.Enabled = False
        Me.txtClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClave.ForeColor = System.Drawing.Color.Black
        Me.txtClave.Location = New System.Drawing.Point(71, 5)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.ReadOnly = True
        Me.txtClave.Size = New System.Drawing.Size(169, 23)
        Me.txtClave.TabIndex = 41
        Me.txtClave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label4.Size = New System.Drawing.Size(56, 31)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Crédito"
        '
        'Panel3
        '
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(356, 10)
        Me.Panel3.TabIndex = 0
        '
        'frmCancelarDeducciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(376, 437)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCancelarDeducciones"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancelar deducciones"
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.gpDatos.ResumeLayout(False)
        Me.gpDatos.PerformLayout()
        Me.pnlTransferencia.ResumeLayout(False)
        Me.pnlDefinitiva.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.GroupPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents txtClave As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents gpDatos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents pnlTransferencia As System.Windows.Forms.Panel
    Friend WithEvents txtNvaClave As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkTransferencia As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents pnlDefinitiva As System.Windows.Forms.Panel
    Friend WithEvents txtMotivo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumCancelacion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkDefinitivo As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents txtID As DevComponents.DotNetBar.Controls.TextBoxX
End Class
