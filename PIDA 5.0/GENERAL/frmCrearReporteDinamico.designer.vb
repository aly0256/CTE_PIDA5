<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCrearReporteDinamico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCrearReporteDinamico))
        Me.wizAsistente = New DevComponents.DotNetBar.Wizard()
        Me.wizBienvenida = New DevComponents.DotNetBar.WizardPage()
        Me.lblFuente = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.wizCampos = New DevComponents.DotNetBar.WizardPage()
        Me.chkMarcar = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkSeleccionados = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtBusca = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.lstDisponibles = New System.Windows.Forms.CheckedListBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.wizCamposSeleccionados = New DevComponents.DotNetBar.WizardPage()
        Me.lstSeleccionados = New System.Windows.Forms.ListBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.wizGrupos = New DevComponents.DotNetBar.WizardPage()
        Me.chkDetalle = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.chkTotales = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbGrupo3 = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbGrupo2 = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbGrupo1 = New System.Windows.Forms.ComboBox()
        Me.wizTerminar = New DevComponents.DotNetBar.WizardPage()
        Me.chkGuardar = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.txtReporte = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.wizAsistente.SuspendLayout()
        Me.wizBienvenida.SuspendLayout()
        Me.wizCampos.SuspendLayout()
        Me.wizCamposSeleccionados.SuspendLayout()
        Me.wizGrupos.SuspendLayout()
        Me.wizTerminar.SuspendLayout()
        Me.SuspendLayout()
        '
        'wizAsistente
        '
        Me.wizAsistente.BackButtonText = "< Atrás"
        Me.wizAsistente.CancelButtonText = "Cancelar"
        Me.wizAsistente.Cursor = System.Windows.Forms.Cursors.Default
        Me.wizAsistente.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wizAsistente.FinishButtonTabIndex = 3
        Me.wizAsistente.FinishButtonText = "Terminar"
        '
        '
        '
        Me.wizAsistente.FooterStyle.BackColor = System.Drawing.SystemColors.Control
        Me.wizAsistente.FooterStyle.BackColorGradientAngle = 90
        Me.wizAsistente.FooterStyle.BorderBottomWidth = 1
        Me.wizAsistente.FooterStyle.BorderColor = System.Drawing.SystemColors.Control
        Me.wizAsistente.FooterStyle.BorderLeftWidth = 1
        Me.wizAsistente.FooterStyle.BorderRightWidth = 1
        Me.wizAsistente.FooterStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Etched
        Me.wizAsistente.FooterStyle.BorderTopColor = System.Drawing.SystemColors.Control
        Me.wizAsistente.FooterStyle.BorderTopWidth = 1
        Me.wizAsistente.FooterStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.wizAsistente.FooterStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.wizAsistente.FooterStyle.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.wizAsistente.HeaderCaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.wizAsistente.HeaderDescriptionFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.wizAsistente.HeaderDescriptionIndent = 16
        Me.wizAsistente.HeaderImage = Global.PIDA.My.Resources.Resources.Wizard48
        '
        '
        '
        Me.wizAsistente.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.wizAsistente.HeaderStyle.BackColorGradientAngle = 90
        Me.wizAsistente.HeaderStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Etched
        Me.wizAsistente.HeaderStyle.BorderBottomWidth = 1
        Me.wizAsistente.HeaderStyle.BorderColor = System.Drawing.SystemColors.Control
        Me.wizAsistente.HeaderStyle.BorderLeftWidth = 1
        Me.wizAsistente.HeaderStyle.BorderRightWidth = 1
        Me.wizAsistente.HeaderStyle.BorderTopWidth = 1
        Me.wizAsistente.HeaderStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.wizAsistente.HeaderStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.wizAsistente.HeaderStyle.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText
        Me.wizAsistente.HelpButtonVisible = False
        Me.wizAsistente.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.wizAsistente.Location = New System.Drawing.Point(0, 0)
        Me.wizAsistente.Name = "wizAsistente"
        Me.wizAsistente.NextButtonText = "Siguiente >"
        Me.wizAsistente.Size = New System.Drawing.Size(487, 279)
        Me.wizAsistente.TabIndex = 0
        Me.wizAsistente.WizardPages.AddRange(New DevComponents.DotNetBar.WizardPage() {Me.wizBienvenida, Me.wizCampos, Me.wizCamposSeleccionados, Me.wizGrupos, Me.wizTerminar})
        '
        'wizBienvenida
        '
        Me.wizBienvenida.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wizBienvenida.BackColor = System.Drawing.SystemColors.Window
        Me.wizBienvenida.Controls.Add(Me.lblFuente)
        Me.wizBienvenida.Controls.Add(Me.Label1)
        Me.wizBienvenida.Controls.Add(Me.Label2)
        Me.wizBienvenida.Controls.Add(Me.Label3)
        Me.wizBienvenida.InteriorPage = False
        Me.wizBienvenida.Location = New System.Drawing.Point(0, 0)
        Me.wizBienvenida.Name = "wizBienvenida"
        Me.wizBienvenida.Size = New System.Drawing.Size(487, 233)
        '
        '
        '
        Me.wizBienvenida.Style.BackColor = System.Drawing.SystemColors.Window
        Me.wizBienvenida.Style.BackgroundImage = Global.PIDA.My.Resources.Resources.Wizard
        Me.wizBienvenida.Style.BackgroundImagePosition = DevComponents.DotNetBar.eStyleBackgroundImage.TopLeft
        Me.wizBienvenida.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.wizBienvenida.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.wizBienvenida.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.wizBienvenida.TabIndex = 9
        '
        'lblFuente
        '
        Me.lblFuente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFuente.BackColor = System.Drawing.SystemColors.Window
        Me.lblFuente.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.lblFuente.Location = New System.Drawing.Point(204, 75)
        Me.lblFuente.Name = "lblFuente"
        Me.lblFuente.Size = New System.Drawing.Size(277, 35)
        Me.lblFuente.TabIndex = 3
        Me.lblFuente.Text = "Fuente"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 16.0!)
        Me.Label1.Location = New System.Drawing.Point(204, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(277, 66)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bienvenido al asistente para crear reportes"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.Location = New System.Drawing.Point(204, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(276, 45)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Este asistente le ayudará a crear un reporte, seleccionando los campos que quiere" & _
    " incluir, con opción a separar por grupos."
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.SystemColors.Window
        Me.Label3.Location = New System.Drawing.Point(204, 210)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(249, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Para continuar, presione ""Siguiente"""
        '
        'wizCampos
        '
        Me.wizCampos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wizCampos.AntiAlias = False
        Me.wizCampos.Controls.Add(Me.chkMarcar)
        Me.wizCampos.Controls.Add(Me.chkSeleccionados)
        Me.wizCampos.Controls.Add(Me.txtBusca)
        Me.wizCampos.Controls.Add(Me.lstDisponibles)
        Me.wizCampos.Controls.Add(Me.Label4)
        Me.wizCampos.Location = New System.Drawing.Point(7, 72)
        Me.wizCampos.Name = "wizCampos"
        Me.wizCampos.PageDescription = "Elija los campos desados desde la lista de campos disponibles."
        Me.wizCampos.PageHeaderImage = Global.PIDA.My.Resources.Resources.Wizard48
        Me.wizCampos.PageTitle = "Selección de campos"
        Me.wizCampos.Size = New System.Drawing.Size(473, 149)
        '
        '
        '
        Me.wizCampos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.wizCampos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.wizCampos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.wizCampos.TabIndex = 10
        '
        'chkMarcar
        '
        '
        '
        '
        Me.chkMarcar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkMarcar.FocusCuesEnabled = False
        Me.chkMarcar.Location = New System.Drawing.Point(16, 67)
        Me.chkMarcar.Name = "chkMarcar"
        Me.chkMarcar.Size = New System.Drawing.Size(147, 18)
        Me.chkMarcar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkMarcar.TabIndex = 3
        Me.chkMarcar.Text = "Marcar/desmarcar todos"
        Me.chkMarcar.TextColor = System.Drawing.Color.Black
        '
        'chkSeleccionados
        '
        '
        '
        '
        Me.chkSeleccionados.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkSeleccionados.FocusCuesEnabled = False
        Me.chkSeleccionados.Location = New System.Drawing.Point(16, 43)
        Me.chkSeleccionados.Name = "chkSeleccionados"
        Me.chkSeleccionados.Size = New System.Drawing.Size(208, 15)
        Me.chkSeleccionados.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkSeleccionados.TabIndex = 2
        Me.chkSeleccionados.Text = "Mostrar solo campos seleccionados"
        Me.chkSeleccionados.TextColor = System.Drawing.Color.Black
        '
        'txtBusca
        '
        Me.txtBusca.BackColor = System.Drawing.Color.White
        '
        '
        '
        Me.txtBusca.Border.Class = "TextBoxBorder"
        Me.txtBusca.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtBusca.ButtonCustom.Image = Global.PIDA.My.Resources.Resources.Search16
        Me.txtBusca.ButtonCustom.Visible = True
        Me.txtBusca.DisabledBackColor = System.Drawing.Color.White
        Me.txtBusca.ForeColor = System.Drawing.Color.Black
        Me.txtBusca.Location = New System.Drawing.Point(16, 16)
        Me.txtBusca.Name = "txtBusca"
        Me.txtBusca.PreventEnterBeep = True
        Me.txtBusca.Size = New System.Drawing.Size(208, 22)
        Me.txtBusca.TabIndex = 0
        '
        'lstDisponibles
        '
        Me.lstDisponibles.ColumnWidth = 225
        Me.lstDisponibles.Location = New System.Drawing.Point(230, 16)
        Me.lstDisponibles.Name = "lstDisponibles"
        Me.lstDisponibles.Size = New System.Drawing.Size(229, 124)
        Me.lstDisponibles.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Campos disponibles"
        '
        'wizCamposSeleccionados
        '
        Me.wizCamposSeleccionados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wizCamposSeleccionados.Controls.Add(Me.lstSeleccionados)
        Me.wizCamposSeleccionados.Controls.Add(Me.Label5)
        Me.wizCamposSeleccionados.Location = New System.Drawing.Point(7, 72)
        Me.wizCamposSeleccionados.Name = "wizCamposSeleccionados"
        Me.wizCamposSeleccionados.PageDescription = "Arrastre los elementos de la lista, acomodándolos en el orden que desea aprezcan " & _
    "en el reporte."
        Me.wizCamposSeleccionados.PageTitle = "Organizar campos"
        Me.wizCamposSeleccionados.Size = New System.Drawing.Size(473, 149)
        '
        '
        '
        Me.wizCamposSeleccionados.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.wizCamposSeleccionados.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.wizCamposSeleccionados.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.wizCamposSeleccionados.TabIndex = 13
        '
        'lstSeleccionados
        '
        Me.lstSeleccionados.FormattingEnabled = True
        Me.lstSeleccionados.Location = New System.Drawing.Point(16, 22)
        Me.lstSeleccionados.Name = "lstSeleccionados"
        Me.lstSeleccionados.Size = New System.Drawing.Size(441, 121)
        Me.lstSeleccionados.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Campos seleccionados"
        '
        'wizGrupos
        '
        Me.wizGrupos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wizGrupos.AntiAlias = False
        Me.wizGrupos.Controls.Add(Me.chkDetalle)
        Me.wizGrupos.Controls.Add(Me.chkTotales)
        Me.wizGrupos.Controls.Add(Me.Label8)
        Me.wizGrupos.Controls.Add(Me.cmbGrupo3)
        Me.wizGrupos.Controls.Add(Me.Label7)
        Me.wizGrupos.Controls.Add(Me.cmbGrupo2)
        Me.wizGrupos.Controls.Add(Me.Label6)
        Me.wizGrupos.Controls.Add(Me.cmbGrupo1)
        Me.wizGrupos.Location = New System.Drawing.Point(7, 72)
        Me.wizGrupos.Name = "wizGrupos"
        Me.wizGrupos.PageDescription = "¿Cómo quiere agrupar los registros? Puede elegir hasta 3 niveles."
        Me.wizGrupos.PageTitle = "Agrupar los datos"
        Me.wizGrupos.Size = New System.Drawing.Size(473, 149)
        '
        '
        '
        Me.wizGrupos.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.wizGrupos.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.wizGrupos.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.wizGrupos.TabIndex = 11
        '
        'chkDetalle
        '
        Me.chkDetalle.AutoSize = True
        '
        '
        '
        Me.chkDetalle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkDetalle.BackgroundStyle.TextColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.chkDetalle.Checked = True
        Me.chkDetalle.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDetalle.CheckValue = "Y"
        Me.chkDetalle.Location = New System.Drawing.Point(110, 130)
        Me.chkDetalle.Name = "chkDetalle"
        Me.chkDetalle.Size = New System.Drawing.Size(107, 15)
        Me.chkDetalle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkDetalle.TabIndex = 9
        Me.chkDetalle.Text = "Mostrar el detalle"
        Me.chkDetalle.TextColor = System.Drawing.SystemColors.ActiveCaptionText
        '
        'chkTotales
        '
        Me.chkTotales.AutoSize = True
        '
        '
        '
        Me.chkTotales.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkTotales.BackgroundStyle.TextColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.chkTotales.Checked = True
        Me.chkTotales.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTotales.CheckValue = "Y"
        Me.chkTotales.Location = New System.Drawing.Point(110, 109)
        Me.chkTotales.Name = "chkTotales"
        Me.chkTotales.Size = New System.Drawing.Size(150, 15)
        Me.chkTotales.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkTotales.TabIndex = 8
        Me.chkTotales.Text = "Mostrar renglón de totales"
        Me.chkTotales.TextColor = System.Drawing.SystemColors.ActiveCaptionText
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(88, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(16, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "3."
        '
        'cmbGrupo3
        '
        Me.cmbGrupo3.Enabled = False
        Me.cmbGrupo3.FormattingEnabled = True
        Me.cmbGrupo3.Location = New System.Drawing.Point(110, 65)
        Me.cmbGrupo3.Name = "cmbGrupo3"
        Me.cmbGrupo3.Size = New System.Drawing.Size(275, 21)
        Me.cmbGrupo3.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(88, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(16, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "2."
        '
        'cmbGrupo2
        '
        Me.cmbGrupo2.Enabled = False
        Me.cmbGrupo2.FormattingEnabled = True
        Me.cmbGrupo2.Location = New System.Drawing.Point(110, 38)
        Me.cmbGrupo2.Name = "cmbGrupo2"
        Me.cmbGrupo2.Size = New System.Drawing.Size(275, 21)
        Me.cmbGrupo2.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(88, 11)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "1."
        '
        'cmbGrupo1
        '
        Me.cmbGrupo1.FormattingEnabled = True
        Me.cmbGrupo1.Location = New System.Drawing.Point(110, 11)
        Me.cmbGrupo1.Name = "cmbGrupo1"
        Me.cmbGrupo1.Size = New System.Drawing.Size(275, 21)
        Me.cmbGrupo1.TabIndex = 0
        '
        'wizTerminar
        '
        Me.wizTerminar.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.wizTerminar.AntiAlias = False
        Me.wizTerminar.Controls.Add(Me.chkGuardar)
        Me.wizTerminar.Controls.Add(Me.txtReporte)
        Me.wizTerminar.Controls.Add(Me.Label9)
        Me.wizTerminar.Location = New System.Drawing.Point(7, 72)
        Me.wizTerminar.Name = "wizTerminar"
        Me.wizTerminar.PageDescription = "Asigne un nombre al reporte. Con este nombre se identificará dentro del reportead" & _
    "or, y también será el encabezado."
        Me.wizTerminar.PageTitle = "Nombre del reporte"
        Me.wizTerminar.Size = New System.Drawing.Size(473, 149)
        '
        '
        '
        Me.wizTerminar.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.wizTerminar.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.wizTerminar.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.wizTerminar.TabIndex = 12
        '
        'chkGuardar
        '
        '
        '
        '
        Me.chkGuardar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkGuardar.Location = New System.Drawing.Point(63, 74)
        Me.chkGuardar.Name = "chkGuardar"
        Me.chkGuardar.Size = New System.Drawing.Size(196, 23)
        Me.chkGuardar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkGuardar.TabIndex = 2
        Me.chkGuardar.Text = "Guardar reporte para uso posterior"
        Me.chkGuardar.TextColor = System.Drawing.SystemColors.ActiveCaptionText
        '
        'txtReporte
        '
        Me.txtReporte.Location = New System.Drawing.Point(163, 48)
        Me.txtReporte.MaxLength = 254
        Me.txtReporte.Name = "txtReporte"
        Me.txtReporte.Size = New System.Drawing.Size(252, 20)
        Me.txtReporte.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(60, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Nombre del reporte"
        '
        'frmCrearReporteDinamico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 279)
        Me.Controls.Add(Me.wizAsistente)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCrearReporteDinamico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Creación de reportes"
        Me.wizAsistente.ResumeLayout(False)
        Me.wizBienvenida.ResumeLayout(False)
        Me.wizCampos.ResumeLayout(False)
        Me.wizCampos.PerformLayout()
        Me.wizCamposSeleccionados.ResumeLayout(False)
        Me.wizCamposSeleccionados.PerformLayout()
        Me.wizGrupos.ResumeLayout(False)
        Me.wizGrupos.PerformLayout()
        Me.wizTerminar.ResumeLayout(False)
        Me.wizTerminar.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents wizAsistente As DevComponents.DotNetBar.Wizard
    Friend WithEvents wizBienvenida As DevComponents.DotNetBar.WizardPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents wizCampos As DevComponents.DotNetBar.WizardPage
    Friend WithEvents wizGrupos As DevComponents.DotNetBar.WizardPage
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbGrupo3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbGrupo2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbGrupo1 As System.Windows.Forms.ComboBox
    Friend WithEvents chkDetalle As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkTotales As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents wizTerminar As DevComponents.DotNetBar.WizardPage
    Friend WithEvents txtReporte As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkGuardar As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents lblFuente As System.Windows.Forms.Label
    Friend WithEvents lstDisponibles As System.Windows.Forms.CheckedListBox
    Friend WithEvents wizCamposSeleccionados As DevComponents.DotNetBar.WizardPage
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lstSeleccionados As System.Windows.Forms.ListBox
    Friend WithEvents txtBusca As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents chkMarcar As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents chkSeleccionados As DevComponents.DotNetBar.Controls.CheckBoxX

End Class
