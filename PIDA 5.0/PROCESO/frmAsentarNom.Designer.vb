<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsentarNom
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
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Periodo = New DevComponents.AdvTree.ColumnHeader()
        Me.ColFechaIni = New DevComponents.AdvTree.ColumnHeader()
        Me.ColFechaFin = New DevComponents.AdvTree.ColumnHeader()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAsentarNom = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.lblAnioPer = New DevComponents.DotNetBar.LabelX()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(82, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(214, 40)
        Me.ReflectionLabel1.TabIndex = 255
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>ASENTAR NÓMINA</b></font>"
        '
        'Periodo
        '
        Me.Periodo.DataFieldName = "periodo"
        Me.Periodo.Name = "Periodo"
        Me.Periodo.StretchToFill = True
        Me.Periodo.Text = "Periodo"
        Me.Periodo.Width.Relative = 25
        '
        'ColFechaIni
        '
        Me.ColFechaIni.DataFieldName = "fecha_ini"
        Me.ColFechaIni.Name = "ColFechaIni"
        Me.ColFechaIni.Text = "Fecha Inicial"
        Me.ColFechaIni.Width.Relative = 25
        '
        'ColFechaFin
        '
        Me.ColFechaFin.DataFieldName = "fecha_fin"
        Me.ColFechaFin.Name = "ColFechaFin"
        Me.ColFechaFin.Text = "Fecha final"
        Me.ColFechaFin.Width.Relative = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.Label1.Location = New System.Drawing.Point(4, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 256
        Me.Label1.Text = "Periodo"
        '
        'btnAsentarNom
        '
        Me.btnAsentarNom.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAsentarNom.CausesValidation = False
        Me.btnAsentarNom.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAsentarNom.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.btnAsentarNom.Image = Global.PIDA.My.Resources.Resources.Candado48
        Me.btnAsentarNom.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnAsentarNom.Location = New System.Drawing.Point(116, 101)
        Me.btnAsentarNom.Name = "btnAsentarNom"
        Me.btnAsentarNom.Size = New System.Drawing.Size(206, 78)
        Me.btnAsentarNom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAsentarNom.TabIndex = 258
        Me.btnAsentarNom.Text = "Asienta nómina"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(297, 204)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(116, 28)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 259
        Me.btnCerrar.Text = "Salir"
        '
        'lblAnioPer
        '
        '
        '
        '
        Me.lblAnioPer.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.lblAnioPer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnioPer.Location = New System.Drawing.Point(61, 58)
        Me.lblAnioPer.Name = "lblAnioPer"
        Me.lblAnioPer.SingleLineColor = System.Drawing.SystemColors.Control
        Me.lblAnioPer.Size = New System.Drawing.Size(362, 20)
        Me.lblAnioPer.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014
        Me.lblAnioPer.TabIndex = 260
        Me.lblAnioPer.Text = "2020 - 29 del 13/07 al 19/07"
        '
        'frmAsentarNom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 243)
        Me.Controls.Add(Me.lblAnioPer)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAsentarNom)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Name = "frmAsentarNom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asentar / Cerrar Nómina"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAsentarNom As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Periodo As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColFechaIni As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents ColFechaFin As DevComponents.AdvTree.ColumnHeader
    Friend WithEvents lblAnioPer As DevComponents.DotNetBar.LabelX
End Class
