<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPtuParam
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPtuParam))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.ReflectionLabel2 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.ReflectionLabel3 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.txtCantRepartir = New DevComponents.Editors.DoubleInput()
        Me.txtDiasMinConsid = New DevComponents.Editors.DoubleInput()
        Me.txtSDMaxSindic = New DevComponents.Editors.DoubleInput()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnAceptar = New DevComponents.DotNetBar.ButtonX()
        CType(Me.txtCantRepartir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiasMinConsid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSDMaxSindic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(12, 21)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(201, 26)
        Me.ReflectionLabel1.TabIndex = 264
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>Cantidad a repartir:</b></font>"
        '
        'ReflectionLabel2
        '
        '
        '
        '
        Me.ReflectionLabel2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel2.Location = New System.Drawing.Point(12, 61)
        Me.ReflectionLabel2.Name = "ReflectionLabel2"
        Me.ReflectionLabel2.Size = New System.Drawing.Size(275, 26)
        Me.ReflectionLabel2.TabIndex = 265
        Me.ReflectionLabel2.Text = "<font color=""#1F497D""><b>Días mínimos a considerar:</b></font>"
        '
        'ReflectionLabel3
        '
        '
        '
        '
        Me.ReflectionLabel3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel3.Location = New System.Drawing.Point(12, 100)
        Me.ReflectionLabel3.Name = "ReflectionLabel3"
        Me.ReflectionLabel3.Size = New System.Drawing.Size(303, 26)
        Me.ReflectionLabel3.TabIndex = 266
        Me.ReflectionLabel3.Text = "<font color=""#1F497D""><b>Sueldo máximo sindicalizado:</b></font>"
        '
        'txtCantRepartir
        '
        '
        '
        '
        Me.txtCantRepartir.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtCantRepartir.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtCantRepartir.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtCantRepartir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantRepartir.Increment = 1.0R
        Me.txtCantRepartir.Location = New System.Drawing.Point(311, 21)
        Me.txtCantRepartir.Name = "txtCantRepartir"
        Me.txtCantRepartir.ShowUpDown = True
        Me.txtCantRepartir.Size = New System.Drawing.Size(148, 22)
        Me.txtCantRepartir.TabIndex = 267
        '
        'txtDiasMinConsid
        '
        '
        '
        '
        Me.txtDiasMinConsid.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtDiasMinConsid.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtDiasMinConsid.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtDiasMinConsid.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiasMinConsid.Increment = 1.0R
        Me.txtDiasMinConsid.Location = New System.Drawing.Point(311, 61)
        Me.txtDiasMinConsid.Name = "txtDiasMinConsid"
        Me.txtDiasMinConsid.ShowUpDown = True
        Me.txtDiasMinConsid.Size = New System.Drawing.Size(148, 22)
        Me.txtDiasMinConsid.TabIndex = 268
        '
        'txtSDMaxSindic
        '
        '
        '
        '
        Me.txtSDMaxSindic.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.txtSDMaxSindic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtSDMaxSindic.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.txtSDMaxSindic.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSDMaxSindic.Increment = 1.0R
        Me.txtSDMaxSindic.Location = New System.Drawing.Point(311, 104)
        Me.txtSDMaxSindic.Name = "txtSDMaxSindic"
        Me.txtSDMaxSindic.ShowUpDown = True
        Me.txtSDMaxSindic.Size = New System.Drawing.Size(148, 22)
        Me.txtSDMaxSindic.TabIndex = 269
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.CancelX
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(356, 143)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(103, 37)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 271
        Me.btnCerrar.Text = "Salir"
        '
        'btnAceptar
        '
        Me.btnAceptar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAceptar.CausesValidation = False
        Me.btnAceptar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = Global.PIDA.My.Resources.Resources.Accept32
        Me.btnAceptar.ImageFixedSize = New System.Drawing.Size(25, 25)
        Me.btnAceptar.Location = New System.Drawing.Point(228, 143)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(102, 37)
        Me.btnAceptar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAceptar.TabIndex = 270
        Me.btnAceptar.Text = "Aceptar"
        '
        'frmPtuParam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 190)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.txtSDMaxSindic)
        Me.Controls.Add(Me.txtDiasMinConsid)
        Me.Controls.Add(Me.txtCantRepartir)
        Me.Controls.Add(Me.ReflectionLabel3)
        Me.Controls.Add(Me.ReflectionLabel2)
        Me.Controls.Add(Me.ReflectionLabel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPtuParam"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Parámetros para cálculo"
        CType(Me.txtCantRepartir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiasMinConsid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSDMaxSindic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents ReflectionLabel2 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents ReflectionLabel3 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents txtCantRepartir As DevComponents.Editors.DoubleInput
    Friend WithEvents txtDiasMinConsid As DevComponents.Editors.DoubleInput
    Friend WithEvents txtSDMaxSindic As DevComponents.Editors.DoubleInput
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAceptar As DevComponents.DotNetBar.ButtonX
End Class
