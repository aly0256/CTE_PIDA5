<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCalcLiqFah
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCalcLiqFah))
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.txtPeriodo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.txtAnio = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnCalcAgui = New DevComponents.DotNetBar.ButtonX()
        Me.SuspendLayout()
        '
        'lblEstatus
        '
        Me.lblEstatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEstatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEstatus.Location = New System.Drawing.Point(17, 85)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(475, 53)
        Me.lblEstatus.TabIndex = 270
        Me.lblEstatus.Text = "--"
        Me.lblEstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.txtPeriodo.Location = New System.Drawing.Point(257, 50)
        Me.txtPeriodo.Name = "txtPeriodo"
        Me.txtPeriodo.PreventEnterBeep = True
        Me.txtPeriodo.ReadOnly = True
        Me.txtPeriodo.Size = New System.Drawing.Size(235, 21)
        Me.txtPeriodo.TabIndex = 267
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
        Me.txtAnio.Location = New System.Drawing.Point(53, 49)
        Me.txtAnio.Name = "txtAnio"
        Me.txtAnio.ReadOnly = True
        Me.txtAnio.Size = New System.Drawing.Size(100, 21)
        Me.txtAnio.TabIndex = 266
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(194, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 265
        Me.Label1.Text = "Periodo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label5.Location = New System.Drawing.Point(14, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 17)
        Me.Label5.TabIndex = 264
        Me.Label5.Text = "Año"
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(86, 4)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(389, 40)
        Me.ReflectionLabel1.TabIndex = 263
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>CÁLCULO LIQ. FONDO AHORRO</b></font>"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(389, 160)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(103, 37)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 269
        Me.btnCerrar.Text = "Salir"
        '
        'btnCalcAgui
        '
        Me.btnCalcAgui.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCalcAgui.CausesValidation = False
        Me.btnCalcAgui.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCalcAgui.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCalcAgui.Image = Global.PIDA.My.Resources.Resources.CalcFiniquito32
        Me.btnCalcAgui.ImageFixedSize = New System.Drawing.Size(25, 25)
        Me.btnCalcAgui.Location = New System.Drawing.Point(261, 160)
        Me.btnCalcAgui.Name = "btnCalcAgui"
        Me.btnCalcAgui.Size = New System.Drawing.Size(102, 37)
        Me.btnCalcAgui.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCalcAgui.TabIndex = 268
        Me.btnCalcAgui.Text = "Calcular"
        '
        'frmCalcLiqFah
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 201)
        Me.Controls.Add(Me.lblEstatus)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnCalcAgui)
        Me.Controls.Add(Me.txtPeriodo)
        Me.Controls.Add(Me.txtAnio)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCalcLiqFah"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cálculo Liq. FAH"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents lblEstatus As System.Windows.Forms.Label
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCalcAgui As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtPeriodo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtAnio As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
End Class
