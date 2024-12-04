<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExcepcionesHorariosMasivos
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
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.txtArchivo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnBuscaArchivo = New DevComponents.DotNetBar.ButtonX()
        Me.lblFormato = New System.Windows.Forms.Label()
        Me.cpActualizacion = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCancelar = New DevComponents.DotNetBar.ButtonX()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupPanel1 = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.dgvLog = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.ColCampo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColComentario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPosicion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupPanel1.SuspendLayout()
        CType(Me.dgvLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(68, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(416, 46)
        Me.ReflectionLabel1.TabIndex = 112
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>EXCEPCIONES HORARIOS MASIVOS</b></font>"
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.AjustesMasivos32
        Me.picImagen.Location = New System.Drawing.Point(12, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(31, 30)
        Me.picImagen.TabIndex = 113
        Me.picImagen.TabStop = False
        '
        'txtArchivo
        '
        Me.txtArchivo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtArchivo.Border.Class = "TextBoxBorder"
        Me.txtArchivo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtArchivo.Location = New System.Drawing.Point(7, 23)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.ReadOnly = True
        Me.txtArchivo.Size = New System.Drawing.Size(430, 23)
        Me.txtArchivo.TabIndex = 114
        '
        'btnBuscaArchivo
        '
        Me.btnBuscaArchivo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscaArchivo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscaArchivo.Location = New System.Drawing.Point(443, 23)
        Me.btnBuscaArchivo.Name = "btnBuscaArchivo"
        Me.btnBuscaArchivo.Size = New System.Drawing.Size(26, 23)
        Me.btnBuscaArchivo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscaArchivo.TabIndex = 115
        Me.btnBuscaArchivo.Text = "..."
        '
        'lblFormato
        '
        Me.lblFormato.AutoSize = True
        Me.lblFormato.BackColor = System.Drawing.SystemColors.Window
        Me.lblFormato.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormato.Location = New System.Drawing.Point(4, 5)
        Me.lblFormato.Name = "lblFormato"
        Me.lblFormato.Size = New System.Drawing.Size(104, 15)
        Me.lblFormato.TabIndex = 116
        Me.lblFormato.Text = "Buscar en archivo"
        '
        'cpActualizacion
        '
        '
        '
        '
        Me.cpActualizacion.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.cpActualizacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cpActualizacion.Location = New System.Drawing.Point(7, 5)
        Me.cpActualizacion.Name = "cpActualizacion"
        Me.cpActualizacion.Size = New System.Drawing.Size(298, 25)
        Me.cpActualizacion.TabIndex = 117
        Me.cpActualizacion.Text = "Procesando..."
        Me.cpActualizacion.TextVisible = True
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAceptar.Location = New System.Drawing.Point(309, 5)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(78, 25)
        Me.btnAceptar.TabIndex = 118
        Me.btnAceptar.Text = "Aceptar"
        '
        'btnCancelar
        '
        Me.btnCancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCancelar.CausesValidation = False
        Me.btnCancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCancelar.Location = New System.Drawing.Point(391, 5)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(78, 25)
        Me.btnCancelar.TabIndex = 119
        Me.btnCancelar.Text = "Cancelar"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnAceptar)
        Me.Panel1.Controls.Add(Me.cpActualizacion)
        Me.Panel1.Controls.Add(Me.btnCancelar)
        Me.Panel1.Location = New System.Drawing.Point(6, 361)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(476, 34)
        Me.Panel1.TabIndex = 120
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnBuscaArchivo)
        Me.Panel2.Controls.Add(Me.txtArchivo)
        Me.Panel2.Controls.Add(Me.lblFormato)
        Me.Panel2.Location = New System.Drawing.Point(8, 64)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(476, 53)
        Me.Panel2.TabIndex = 121
        '
        'GroupPanel1
        '
        Me.GroupPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.GroupPanel1.CanvasColor = System.Drawing.SystemColors.Control
        Me.GroupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.GroupPanel1.Controls.Add(Me.dgvLog)
        Me.GroupPanel1.DisabledBackColor = System.Drawing.Color.Empty
        Me.GroupPanel1.Location = New System.Drawing.Point(6, 123)
        Me.GroupPanel1.Name = "GroupPanel1"
        Me.GroupPanel1.Size = New System.Drawing.Size(478, 237)
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
        Me.GroupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
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
        Me.GroupPanel1.TabIndex = 122
        Me.GroupPanel1.Text = "Log Errores"
        '
        'dgvLog
        '
        Me.dgvLog.AllowUserToAddRows = False
        Me.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLog.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColCampo, Me.ColComentario, Me.ColPosicion})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvLog.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLog.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgvLog.Location = New System.Drawing.Point(0, 0)
        Me.dgvLog.Name = "dgvLog"
        Me.dgvLog.Size = New System.Drawing.Size(468, 212)
        Me.dgvLog.TabIndex = 0
        '
        'ColCampo
        '
        Me.ColCampo.HeaderText = "Error"
        Me.ColCampo.Name = "ColCampo"
        Me.ColCampo.ReadOnly = True
        '
        'ColComentario
        '
        Me.ColComentario.HeaderText = "Comentario"
        Me.ColComentario.Name = "ColComentario"
        Me.ColComentario.ReadOnly = True
        '
        'ColPosicion
        '
        Me.ColPosicion.HeaderText = "Fila"
        Me.ColPosicion.Name = "ColPosicion"
        Me.ColPosicion.ReadOnly = True
        '
        'frmExcepcionesHorariosMasivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(491, 397)
        Me.Controls.Add(Me.GroupPanel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.picImagen)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Name = "frmExcepcionesHorariosMasivos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Excepciones Horarios Masivos"
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupPanel1.ResumeLayout(False)
        CType(Me.dgvLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents txtArchivo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnBuscaArchivo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents lblFormato As System.Windows.Forms.Label
    Friend WithEvents cpActualizacion As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCancelar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents GroupPanel1 As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents dgvLog As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents ColCampo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColComentario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPosicion As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
