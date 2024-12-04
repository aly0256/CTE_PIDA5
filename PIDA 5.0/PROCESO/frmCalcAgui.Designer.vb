<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalcAgui
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCalcAgui))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAnio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtPeriodo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnCalcAgui = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gpFiltro = New System.Windows.Forms.GroupBox()
        Me.lstFiltro = New DevComponents.DotNetBar.ListBoxAdv()
        Me.btnAgregarCriterio = New DevComponents.DotNetBar.ButtonX()
        Me.txtCriterio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnCriterio = New DevComponents.DotNetBar.ButtonX()
        Me.gpCriterios = New System.Windows.Forms.GroupBox()
        Me.gpFiltro.SuspendLayout()
        Me.gpCriterios.SuspendLayout()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(125, 21)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(250, 40)
        Me.ReflectionLabel1.TabIndex = 255
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CÁLCULO AGUINALDO</b></font>"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(210, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 257
        Me.Label1.Text = "Periodo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(30, 68)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 17)
        Me.Label5.TabIndex = 256
        Me.Label5.Text = "Año"
        '
        'txtAnio
        '
        Me.txtAnio.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtAnio.Border.Class = "TextBoxBorder"
        Me.txtAnio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAnio.Enabled = False
        Me.txtAnio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAnio.ForeColor = System.Drawing.Color.Black
        Me.txtAnio.Location = New System.Drawing.Point(69, 66)
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.ReadOnly = True
        Me.txtAnio.Size = New System.Drawing.Size(100, 21)
        Me.txtAnio.TabIndex = 258
        '
        'txtPeriodo
        '
        Me.txtPeriodo.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtPeriodo.Border.Class = "TextBoxBorder"
        Me.txtPeriodo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtPeriodo.Enabled = False
        Me.txtPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriodo.ForeColor = System.Drawing.Color.Black
        Me.txtPeriodo.Location = New System.Drawing.Point(273, 67)
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.PreventEnterBeep = True
        Me.txtPeriodo.ReadOnly = True
        Me.txtPeriodo.Size = New System.Drawing.Size(235, 21)
        Me.txtPeriodo.TabIndex = 259
        '
        'btnCalcAgui
        '
        Me.btnCalcAgui.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCalcAgui.CausesValidation = False
        Me.btnCalcAgui.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCalcAgui.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCalcAgui.Image = Global.PIDA.My.Resources.Resources.CalcFiniquito32
        Me.btnCalcAgui.ImageFixedSize = New System.Drawing.Size(25, 25)
        Me.btnCalcAgui.Location = New System.Drawing.Point(417, 231)
        Me.btnCalcAgui.Name = "btnCalcAgui"
        Me.btnCalcAgui.Size = New System.Drawing.Size(91, 37)
        Me.btnCalcAgui.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCalcAgui.TabIndex = 260
        Me.btnCalcAgui.Text = "Calcular"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(417, 280)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(91, 37)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 261
        Me.btnCerrar.Text = "Salir"
        '
        'lblEstatus
        '
        Me.lblEstatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatus.Location = New System.Drawing.Point(33, 102)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(475, 53)
        Me.lblEstatus.TabIndex = 262
        Me.lblEstatus.Text = "--"
        Me.lblEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label2.Location = New System.Drawing.Point(30, 168)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 17)
        Me.Label2.TabIndex = 264
        Me.Label2.Text = "Tipos ausentismos"
        '
        'gpFiltro
        '
        Me.gpFiltro.BackColor = System.Drawing.SystemColors.Control
        Me.gpFiltro.Controls.Add(Me.lstFiltro)
        Me.gpFiltro.Controls.Add(Me.btnAgregarCriterio)
        Me.gpFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFiltro.Location = New System.Drawing.Point(33, 188)
        Me.gpFiltro.Name = "gpFiltro"
        Me.gpFiltro.Size = New System.Drawing.Size(366, 195)
        Me.gpFiltro.TabIndex = 265
        Me.gpFiltro.TabStop = False
        Me.gpFiltro.Text = "Filtro"
        '
        'lstFiltro
        '
        Me.lstFiltro.AutoScroll = True
        '
        '
        '
        Me.lstFiltro.BackgroundStyle.Class = "ListBoxAdv"
        Me.lstFiltro.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lstFiltro.CheckBoxesVisible = True
        Me.lstFiltro.CheckStateMember = Nothing
        Me.lstFiltro.ContainerControlProcessDialogKey = True
        Me.lstFiltro.DragDropSupport = True
        Me.lstFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstFiltro.ItemHeight = 15
        Me.lstFiltro.ItemSpacing = 0
        Me.lstFiltro.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.lstFiltro.Location = New System.Drawing.Point(15, 22)
        Me.lstFiltro.Name = "lstFiltro"
        Me.lstFiltro.Size = New System.Drawing.Size(262, 159)
        Me.lstFiltro.TabIndex = 5
        Me.lstFiltro.ValueMember = "campo"
        '
        'btnAgregarCriterio
        '
        Me.btnAgregarCriterio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAgregarCriterio.CausesValidation = False
        Me.btnAgregarCriterio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAgregarCriterio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarCriterio.Image = Global.PIDA.My.Resources.Resources.LapizNvo16
        Me.btnAgregarCriterio.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.btnAgregarCriterio.Location = New System.Drawing.Point(293, 83)
        Me.btnAgregarCriterio.Name = "btnAgregarCriterio"
        Me.btnAgregarCriterio.Size = New System.Drawing.Size(57, 32)
        Me.btnAgregarCriterio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAgregarCriterio.TabIndex = 6
        Me.btnAgregarCriterio.Tooltip = "Agregar criterio"
        '
        'txtCriterio
        '
        Me.txtCriterio.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtCriterio.Border.Class = "TextBoxBorder"
        Me.txtCriterio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCriterio.Enabled = False
        Me.txtCriterio.ForeColor = System.Drawing.Color.Black
        Me.txtCriterio.Location = New System.Drawing.Point(15, 22)
        Me.txtCriterio.MaxLength = 250
        Me.txtCriterio.Multiline = True
        Me.txtCriterio.Name = "txtCriterio"
        Me.txtCriterio.Size = New System.Drawing.Size(262, 82)
        Me.txtCriterio.TabIndex = 0
        '
        'btnCriterio
        '
        Me.btnCriterio.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCriterio.CausesValidation = False
        Me.btnCriterio.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCriterio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCriterio.Image = Global.PIDA.My.Resources.Resources.Lapiz16
        Me.btnCriterio.Location = New System.Drawing.Point(293, 43)
        Me.btnCriterio.Name = "btnCriterio"
        Me.btnCriterio.Size = New System.Drawing.Size(57, 32)
        Me.btnCriterio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCriterio.TabIndex = 1
        Me.btnCriterio.Tooltip = "Agregar nuevo criterio"
        '
        'gpCriterios
        '
        Me.gpCriterios.Controls.Add(Me.txtCriterio)
        Me.gpCriterios.Controls.Add(Me.btnCriterio)
        Me.gpCriterios.Enabled = False
        Me.gpCriterios.Location = New System.Drawing.Point(33, 188)
        Me.gpCriterios.Name = "gpCriterios"
        Me.gpCriterios.Size = New System.Drawing.Size(366, 115)
        Me.gpCriterios.TabIndex = 267
        Me.gpCriterios.TabStop = False
        Me.gpCriterios.Text = "Criterios"
        Me.gpCriterios.Visible = False
        '
        'frmCalcAgui
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(531, 390)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblEstatus)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnCalcAgui)
        Me.Controls.Add(Me.txtPeriodo)
        Me.Controls.Add(Me.txtAnio)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Controls.Add(Me.gpFiltro)
        Me.Controls.Add(Me.gpCriterios)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCalcAgui"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cálculo de aguinaldo"
        Me.gpFiltro.ResumeLayout(False)
        Me.gpCriterios.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAnio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtPeriodo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnCalcAgui As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Public WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gpFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents lstFiltro As DevComponents.DotNetBar.ListBoxAdv
    Friend WithEvents btnAgregarCriterio As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtCriterio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnCriterio As DevComponents.DotNetBar.ButtonX
    Friend WithEvents gpCriterios As System.Windows.Forms.GroupBox
End Class
