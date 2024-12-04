<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargaExcelSalMasivos
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCargaExcelSalMasivos))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gpCargaExcelSueldos = New DevComponents.DotNetBar.Controls.GroupPanel()
        Me.btnBuscArcExcel = New DevComponents.DotNetBar.ButtonX()
        Me.txtArchivoCarga = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.btnInicCarga = New DevComponents.DotNetBar.ButtonX()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.lblMostrarEjemplo = New System.Windows.Forms.LinkLabel()
        Me.ttEjemplo = New System.Windows.Forms.ToolTip(Me.components)
        Me.gpCargaExcelSueldos.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(209, 20)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Carga masiva de sueldos"
        '
        'gpCargaExcelSueldos
        '
        Me.gpCargaExcelSueldos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.gpCargaExcelSueldos.CanvasColor = System.Drawing.SystemColors.Control
        Me.gpCargaExcelSueldos.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.gpCargaExcelSueldos.Controls.Add(Me.btnBuscArcExcel)
        Me.gpCargaExcelSueldos.Controls.Add(Me.txtArchivoCarga)
        Me.gpCargaExcelSueldos.DisabledBackColor = System.Drawing.Color.Empty
        Me.gpCargaExcelSueldos.Location = New System.Drawing.Point(16, 32)
        Me.gpCargaExcelSueldos.Name = "gpCargaExcelSueldos"
        Me.gpCargaExcelSueldos.Size = New System.Drawing.Size(395, 58)
        '
        '
        '
        Me.gpCargaExcelSueldos.Style.BackColor = System.Drawing.SystemColors.Window
        Me.gpCargaExcelSueldos.Style.BackColor2 = System.Drawing.SystemColors.Window
        Me.gpCargaExcelSueldos.Style.BackColorGradientAngle = 90
        Me.gpCargaExcelSueldos.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpCargaExcelSueldos.Style.BorderBottomWidth = 1
        Me.gpCargaExcelSueldos.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
        Me.gpCargaExcelSueldos.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpCargaExcelSueldos.Style.BorderLeftWidth = 1
        Me.gpCargaExcelSueldos.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpCargaExcelSueldos.Style.BorderRightWidth = 1
        Me.gpCargaExcelSueldos.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.gpCargaExcelSueldos.Style.BorderTopWidth = 1
        Me.gpCargaExcelSueldos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded
        Me.gpCargaExcelSueldos.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.gpCargaExcelSueldos.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near
        '
        '
        '
        Me.gpCargaExcelSueldos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.gpCargaExcelSueldos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.gpCargaExcelSueldos.TabIndex = 114
        Me.gpCargaExcelSueldos.Text = "Seleccionar archivo de excel"
        '
        'btnBuscArcExcel
        '
        Me.btnBuscArcExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBuscArcExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBuscArcExcel.Location = New System.Drawing.Point(284, 3)
        Me.btnBuscArcExcel.Name = "btnBuscArcExcel"
        Me.btnBuscArcExcel.Size = New System.Drawing.Size(85, 23)
        Me.btnBuscArcExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBuscArcExcel.TabIndex = 2
        Me.btnBuscArcExcel.Text = "Seleccionar"
        '
        'txtArchivoCarga
        '
        Me.txtArchivoCarga.BackColor = System.Drawing.SystemColors.Window
        '
        '
        '
        Me.txtArchivoCarga.Border.Class = "TextBoxBorder"
        Me.txtArchivoCarga.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtArchivoCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivoCarga.ForeColor = System.Drawing.SystemColors.ControlText
        Me.txtArchivoCarga.Location = New System.Drawing.Point(3, 3)
        Me.txtArchivoCarga.Name = "txtArchivoCarga"
        Me.txtArchivoCarga.Size = New System.Drawing.Size(275, 20)
        Me.txtArchivoCarga.TabIndex = 1
        '
        'btnInicCarga
        '
        Me.btnInicCarga.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnInicCarga.CausesValidation = False
        Me.btnInicCarga.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnInicCarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInicCarga.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnInicCarga.Location = New System.Drawing.Point(24, 117)
        Me.btnInicCarga.Name = "btnInicCarga"
        Me.btnInicCarga.Size = New System.Drawing.Size(387, 25)
        Me.btnInicCarga.TabIndex = 115
        Me.btnInicCarga.Text = "Iniciar carga"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(23, 93)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(136, 15)
        Me.LinkLabel1.TabIndex = 116
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Generar layout en excel"
        '
        'lblMostrarEjemplo
        '
        Me.lblMostrarEjemplo.AutoSize = True
        Me.lblMostrarEjemplo.Location = New System.Drawing.Point(314, 92)
        Me.lblMostrarEjemplo.Name = "lblMostrarEjemplo"
        Me.lblMostrarEjemplo.Size = New System.Drawing.Size(73, 15)
        Me.lblMostrarEjemplo.TabIndex = 117
        Me.lblMostrarEjemplo.TabStop = True
        Me.lblMostrarEjemplo.Text = "Ver ejemplo"
        '
        'frmCargaExcelSalMasivos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(419, 164)
        Me.Controls.Add(Me.lblMostrarEjemplo)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.btnInicCarga)
        Me.Controls.Add(Me.gpCargaExcelSueldos)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCargaExcelSalMasivos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Carga masiva de sueldos por excel"
        Me.gpCargaExcelSueldos.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Private WithEvents gpCargaExcelSueldos As DevComponents.DotNetBar.Controls.GroupPanel
    Friend WithEvents btnBuscArcExcel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents txtArchivoCarga As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents btnInicCarga As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents lblMostrarEjemplo As System.Windows.Forms.LinkLabel
    Friend WithEvents ttEjemplo As System.Windows.Forms.ToolTip
End Class
