<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCrud
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
        Me.btnAcept = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.tabCompleta = New System.Windows.Forms.TabControl()
        Me.tabPagHoras = New System.Windows.Forms.TabPage()
        Me.pnlHoras2 = New System.Windows.Forms.Panel()
        Me.pnlBase = New System.Windows.Forms.Panel()
        Me.pnlHoras = New System.Windows.Forms.Panel()
        Me.pnlHorasCodHora = New System.Windows.Forms.Panel()
        Me.txtHorasCodHora = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnlHorasSueldo = New System.Windows.Forms.Panel()
        Me.dbHorasSueldo = New DevComponents.Editors.DoubleInput()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.pnlHorasFecha = New System.Windows.Forms.Panel()
        Me.dtiHorasFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pnlHorasMonto = New System.Windows.Forms.Panel()
        Me.dbHorasMonto = New DevComponents.Editors.DoubleInput()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlHorasDescripcion = New System.Windows.Forms.Panel()
        Me.txtHorasDescripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlHorasConcepto = New System.Windows.Forms.Panel()
        Me.cmbHorasConcepto = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlHorasPerDed = New System.Windows.Forms.Panel()
        Me.txtHorasPerDed = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlHorasReloj = New System.Windows.Forms.Panel()
        Me.txtHorasReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlHorasPeriodo = New System.Windows.Forms.Panel()
        Me.txtHorasPeriodo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pnlHorasAno = New System.Windows.Forms.Panel()
        Me.txtHorasAno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tabPagMisc = New System.Windows.Forms.TabPage()
        Me.pnlAjustes2 = New System.Windows.Forms.Panel()
        Me.pnlAjustes = New System.Windows.Forms.Panel()
        Me.pnlAjustesSaldo = New System.Windows.Forms.Panel()
        Me.dbAjustesSaldo = New DevComponents.Editors.DoubleInput()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.pnlAjustesSueldo = New System.Windows.Forms.Panel()
        Me.dbAjustesSueldo = New DevComponents.Editors.DoubleInput()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.pnlAjustesFecha = New System.Windows.Forms.Panel()
        Me.dtiAjustesFecha = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.pnlAjustesMonto = New System.Windows.Forms.Panel()
        Me.dbAjustesMonto = New DevComponents.Editors.DoubleInput()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.pnlAjustesDescripcion = New System.Windows.Forms.Panel()
        Me.txtAjustesDescripcion = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.pnlAjustesConcepto = New System.Windows.Forms.Panel()
        Me.cmbAjustesConcepto = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.pnlAjustesPerDed = New System.Windows.Forms.Panel()
        Me.txtAjustesPerDed = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.pnlAjustesReloj = New System.Windows.Forms.Panel()
        Me.txtAjustesReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.pnlAjustesPeriodo = New System.Windows.Forms.Panel()
        Me.txtAjustesPeriodo = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.pnlAjustesAno = New System.Windows.Forms.Panel()
        Me.txtAjustesAno = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.tabPagNominaPro = New System.Windows.Forms.TabPage()
        Me.pnlNomina2 = New System.Windows.Forms.Panel()
        Me.pnlNominaFiniquito = New System.Windows.Forms.Panel()
        Me.swbNominaFiniquito = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.pnlNominaFaltas = New System.Windows.Forms.Panel()
        Me.intNominaFaltas = New DevComponents.Editors.IntegerInput()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.pnlNominaIncapacidad = New System.Windows.Forms.Panel()
        Me.intNominaIncapacidad = New DevComponents.Editors.IntegerInput()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.pnlNominaPrivacDias = New System.Windows.Forms.Panel()
        Me.dbNominaPrivacDias = New DevComponents.Editors.DoubleInput()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.pnlNominaPrivacPorc = New System.Windows.Forms.Panel()
        Me.intNominaPrivacPorc = New DevComponents.Editors.IntegerInput()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.pnlNominaCobroSegViv = New System.Windows.Forms.Panel()
        Me.swbNominaCobroSegViv = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.pnlNominaSeparador = New System.Windows.Forms.Panel()
        Me.pnlNomina = New System.Windows.Forms.Panel()
        Me.pnlNominaInicioCredito = New System.Windows.Forms.Panel()
        Me.dtiNominaInicioCredito = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.pnlNominaCuotaCredito = New System.Windows.Forms.Panel()
        Me.dbNominaCuotaCredito = New DevComponents.Editors.DoubleInput()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.pnlNominaTipoCredito = New System.Windows.Forms.Panel()
        Me.cmbNominaTipoCredito = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.pnlNominaInfonavitCredito = New System.Windows.Forms.Panel()
        Me.txtNominaInfonavitCredito = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.pnlNominaBaja = New System.Windows.Forms.Panel()
        Me.dtiNominaBaja = New DevComponents.Editors.DateTimeAdv.DateTimeInput()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.pnlNominaSindicalizado = New System.Windows.Forms.Panel()
        Me.swbNominaSindicalizado = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.pnlNominaIntegrado = New System.Windows.Forms.Panel()
        Me.dbNominaIntegrado = New DevComponents.Editors.DoubleInput()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.pnlNominaSactual = New System.Windows.Forms.Panel()
        Me.dbNominaSactual = New DevComponents.Editors.DoubleInput()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.pnlNominaCodClase = New System.Windows.Forms.Panel()
        Me.cmbNominaCodClase = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.pnlNominaProcesar = New System.Windows.Forms.Panel()
        Me.swbNominaProcesar = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.pnlNominaReloj = New System.Windows.Forms.Panel()
        Me.txtNominaReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.tabAgregaEmpleado = New System.Windows.Forms.TabPage()
        Me.pnlAgregaEmpleado = New System.Windows.Forms.Panel()
        Me.pnlEmpleadoMiscelaneos = New System.Windows.Forms.Panel()
        Me.swbEmpleadoMiscelaneos = New DevComponents.DotNetBar.Controls.SwitchButton()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.pnlEmpleadoTipoNomina = New System.Windows.Forms.Panel()
        Me.cmbEmpleadoTipoNomina = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.pnlEmpleadoReloj = New System.Windows.Forms.Panel()
        Me.txtEmpleadoReloj = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.tabCompleta.SuspendLayout
        Me.tabPagHoras.SuspendLayout
        Me.pnlHoras2.SuspendLayout
        Me.pnlHoras.SuspendLayout
        Me.pnlHorasCodHora.SuspendLayout
        Me.pnlHorasSueldo.SuspendLayout
        CType(Me.dbHorasSueldo,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlHorasFecha.SuspendLayout
        CType(Me.dtiHorasFecha,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlHorasMonto.SuspendLayout
        CType(Me.dbHorasMonto,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlHorasDescripcion.SuspendLayout
        Me.pnlHorasConcepto.SuspendLayout
        Me.pnlHorasPerDed.SuspendLayout
        Me.pnlHorasReloj.SuspendLayout
        Me.pnlHorasPeriodo.SuspendLayout
        Me.pnlHorasAno.SuspendLayout
        Me.tabPagMisc.SuspendLayout
        Me.pnlAjustes.SuspendLayout
        Me.pnlAjustesSaldo.SuspendLayout
        CType(Me.dbAjustesSaldo,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlAjustesSueldo.SuspendLayout
        CType(Me.dbAjustesSueldo,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlAjustesFecha.SuspendLayout
        CType(Me.dtiAjustesFecha,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlAjustesMonto.SuspendLayout
        CType(Me.dbAjustesMonto,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlAjustesDescripcion.SuspendLayout
        Me.pnlAjustesConcepto.SuspendLayout
        Me.pnlAjustesPerDed.SuspendLayout
        Me.pnlAjustesReloj.SuspendLayout
        Me.pnlAjustesPeriodo.SuspendLayout
        Me.pnlAjustesAno.SuspendLayout
        Me.tabPagNominaPro.SuspendLayout
        Me.pnlNomina2.SuspendLayout
        Me.pnlNominaFiniquito.SuspendLayout
        Me.pnlNominaFaltas.SuspendLayout
        CType(Me.intNominaFaltas,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlNominaIncapacidad.SuspendLayout
        CType(Me.intNominaIncapacidad,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlNominaPrivacDias.SuspendLayout
        CType(Me.dbNominaPrivacDias,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlNominaPrivacPorc.SuspendLayout
        CType(Me.intNominaPrivacPorc,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlNominaCobroSegViv.SuspendLayout
        Me.pnlNomina.SuspendLayout
        Me.pnlNominaInicioCredito.SuspendLayout
        CType(Me.dtiNominaInicioCredito,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlNominaCuotaCredito.SuspendLayout
        CType(Me.dbNominaCuotaCredito,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlNominaTipoCredito.SuspendLayout
        Me.pnlNominaInfonavitCredito.SuspendLayout
        Me.pnlNominaBaja.SuspendLayout
        CType(Me.dtiNominaBaja,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlNominaSindicalizado.SuspendLayout
        Me.pnlNominaIntegrado.SuspendLayout
        CType(Me.dbNominaIntegrado,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlNominaSactual.SuspendLayout
        CType(Me.dbNominaSactual,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlNominaCodClase.SuspendLayout
        Me.pnlNominaProcesar.SuspendLayout
        Me.pnlNominaReloj.SuspendLayout
        Me.tabAgregaEmpleado.SuspendLayout
        Me.pnlAgregaEmpleado.SuspendLayout
        Me.pnlEmpleadoMiscelaneos.SuspendLayout
        Me.pnlEmpleadoTipoNomina.SuspendLayout
        Me.pnlEmpleadoReloj.SuspendLayout
        Me.SuspendLayout
        '
        'btnAcept
        '
        Me.btnAcept.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnAcept.Location = New System.Drawing.Point(529, 455)
        Me.btnAcept.Name = "btnAcept"
        Me.btnAcept.Size = New System.Drawing.Size(75, 23)
        Me.btnAcept.TabIndex = 101
        Me.btnAcept.TabStop = false
        Me.btnAcept.Text = "Aceptar"
        Me.btnAcept.UseVisualStyleBackColor = true
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Location = New System.Drawing.Point(610, 455)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 100
        Me.btnCancelar.TabStop = false
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = true
        '
        'tabCompleta
        '
        Me.tabCompleta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.tabCompleta.Controls.Add(Me.tabPagHoras)
        Me.tabCompleta.Controls.Add(Me.tabPagMisc)
        Me.tabCompleta.Controls.Add(Me.tabPagNominaPro)
        Me.tabCompleta.Controls.Add(Me.tabAgregaEmpleado)
        Me.tabCompleta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.tabCompleta.Location = New System.Drawing.Point(14, 22)
        Me.tabCompleta.Name = "tabCompleta"
        Me.tabCompleta.SelectedIndex = 0
        Me.tabCompleta.Size = New System.Drawing.Size(675, 421)
        Me.tabCompleta.TabIndex = 291
        '
        'tabPagHoras
        '
        Me.tabPagHoras.Controls.Add(Me.pnlHoras2)
        Me.tabPagHoras.Controls.Add(Me.pnlHoras)
        Me.tabPagHoras.Location = New System.Drawing.Point(4, 22)
        Me.tabPagHoras.Name = "tabPagHoras"
        Me.tabPagHoras.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPagHoras.Size = New System.Drawing.Size(667, 395)
        Me.tabPagHoras.TabIndex = 0
        Me.tabPagHoras.Text = "Horas"
        Me.tabPagHoras.UseVisualStyleBackColor = true
        '
        'pnlHoras2
        '
        Me.pnlHoras2.Controls.Add(Me.pnlBase)
        Me.pnlHoras2.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlHoras2.Location = New System.Drawing.Point(328, 3)
        Me.pnlHoras2.Name = "pnlHoras2"
        Me.pnlHoras2.Size = New System.Drawing.Size(280, 389)
        Me.pnlHoras2.TabIndex = 1
        '
        'pnlBase
        '
        Me.pnlBase.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlBase.Location = New System.Drawing.Point(0, 0)
        Me.pnlBase.Name = "pnlBase"
        Me.pnlBase.Size = New System.Drawing.Size(280, 35)
        Me.pnlBase.TabIndex = 3
        '
        'pnlHoras
        '
        Me.pnlHoras.Controls.Add(Me.pnlHorasCodHora)
        Me.pnlHoras.Controls.Add(Me.pnlHorasSueldo)
        Me.pnlHoras.Controls.Add(Me.pnlHorasFecha)
        Me.pnlHoras.Controls.Add(Me.pnlHorasMonto)
        Me.pnlHoras.Controls.Add(Me.pnlHorasDescripcion)
        Me.pnlHoras.Controls.Add(Me.pnlHorasConcepto)
        Me.pnlHoras.Controls.Add(Me.pnlHorasPerDed)
        Me.pnlHoras.Controls.Add(Me.pnlHorasReloj)
        Me.pnlHoras.Controls.Add(Me.pnlHorasPeriodo)
        Me.pnlHoras.Controls.Add(Me.pnlHorasAno)
        Me.pnlHoras.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlHoras.Location = New System.Drawing.Point(3, 3)
        Me.pnlHoras.Name = "pnlHoras"
        Me.pnlHoras.Size = New System.Drawing.Size(325, 389)
        Me.pnlHoras.TabIndex = 0
        '
        'pnlHorasCodHora
        '
        Me.pnlHorasCodHora.Controls.Add(Me.txtHorasCodHora)
        Me.pnlHorasCodHora.Controls.Add(Me.Label13)
        Me.pnlHorasCodHora.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHorasCodHora.Enabled = false
        Me.pnlHorasCodHora.Location = New System.Drawing.Point(0, 315)
        Me.pnlHorasCodHora.Name = "pnlHorasCodHora"
        Me.pnlHorasCodHora.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlHorasCodHora.Size = New System.Drawing.Size(325, 35)
        Me.pnlHorasCodHora.TabIndex = 12
        Me.pnlHorasCodHora.Visible = false
        '
        'txtHorasCodHora
        '
        '
        '
        '
        Me.txtHorasCodHora.Border.Class = "TextBoxBorder"
        Me.txtHorasCodHora.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtHorasCodHora.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtHorasCodHora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtHorasCodHora.Location = New System.Drawing.Point(89, 7)
        Me.txtHorasCodHora.MaxLength = 3
        Me.txtHorasCodHora.Name = "txtHorasCodHora"
        Me.txtHorasCodHora.PreventEnterBeep = true
        Me.txtHorasCodHora.Size = New System.Drawing.Size(220, 20)
        Me.txtHorasCodHora.TabIndex = 295
        Me.txtHorasCodHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label13.Location = New System.Drawing.Point(0, 7)
        Me.Label13.Name = "Label13"
        Me.Label13.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label13.Size = New System.Drawing.Size(89, 28)
        Me.Label13.TabIndex = 294
        Me.Label13.Text = "Cod hora"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlHorasSueldo
        '
        Me.pnlHorasSueldo.Controls.Add(Me.dbHorasSueldo)
        Me.pnlHorasSueldo.Controls.Add(Me.Label12)
        Me.pnlHorasSueldo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHorasSueldo.Enabled = false
        Me.pnlHorasSueldo.Location = New System.Drawing.Point(0, 280)
        Me.pnlHorasSueldo.Name = "pnlHorasSueldo"
        Me.pnlHorasSueldo.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlHorasSueldo.Size = New System.Drawing.Size(325, 35)
        Me.pnlHorasSueldo.TabIndex = 11
        Me.pnlHorasSueldo.Visible = false
        '
        'dbHorasSueldo
        '
        '
        '
        '
        Me.dbHorasSueldo.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dbHorasSueldo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dbHorasSueldo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dbHorasSueldo.Dock = System.Windows.Forms.DockStyle.Left
        Me.dbHorasSueldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.dbHorasSueldo.Increment = 1R
        Me.dbHorasSueldo.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dbHorasSueldo.Location = New System.Drawing.Point(89, 7)
        Me.dbHorasSueldo.MaxValue = 100000R
        Me.dbHorasSueldo.MinValue = 0R
        Me.dbHorasSueldo.Name = "dbHorasSueldo"
        Me.dbHorasSueldo.ShowUpDown = true
        Me.dbHorasSueldo.Size = New System.Drawing.Size(220, 20)
        Me.dbHorasSueldo.TabIndex = 304
        '
        'Label12
        '
        Me.Label12.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label12.Location = New System.Drawing.Point(0, 7)
        Me.Label12.Name = "Label12"
        Me.Label12.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label12.Size = New System.Drawing.Size(89, 28)
        Me.Label12.TabIndex = 303
        Me.Label12.Text = "Sueldo"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlHorasFecha
        '
        Me.pnlHorasFecha.Controls.Add(Me.dtiHorasFecha)
        Me.pnlHorasFecha.Controls.Add(Me.Label11)
        Me.pnlHorasFecha.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHorasFecha.Enabled = false
        Me.pnlHorasFecha.Location = New System.Drawing.Point(0, 245)
        Me.pnlHorasFecha.Name = "pnlHorasFecha"
        Me.pnlHorasFecha.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlHorasFecha.Size = New System.Drawing.Size(325, 35)
        Me.pnlHorasFecha.TabIndex = 10
        Me.pnlHorasFecha.Visible = false
        '
        'dtiHorasFecha
        '
        '
        '
        '
        Me.dtiHorasFecha.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtiHorasFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiHorasFecha.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtiHorasFecha.ButtonDropDown.Visible = true
        Me.dtiHorasFecha.CustomFormat = "yyyy-MM-dd"
        Me.dtiHorasFecha.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtiHorasFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.dtiHorasFecha.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtiHorasFecha.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dtiHorasFecha.IsPopupCalendarOpen = false
        Me.dtiHorasFecha.Location = New System.Drawing.Point(89, 7)
        '
        '
        '
        Me.dtiHorasFecha.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtiHorasFecha.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiHorasFecha.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtiHorasFecha.MonthCalendar.ClearButtonVisible = true
        '
        '
        '
        Me.dtiHorasFecha.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtiHorasFecha.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiHorasFecha.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtiHorasFecha.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtiHorasFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtiHorasFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtiHorasFecha.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiHorasFecha.MonthCalendar.DisplayMonth = New Date(2023, 10, 1, 0, 0, 0, 0)
        Me.dtiHorasFecha.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtiHorasFecha.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtiHorasFecha.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtiHorasFecha.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiHorasFecha.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtiHorasFecha.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiHorasFecha.MonthCalendar.TodayButtonVisible = true
        Me.dtiHorasFecha.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtiHorasFecha.Name = "dtiHorasFecha"
        Me.dtiHorasFecha.Size = New System.Drawing.Size(220, 20)
        Me.dtiHorasFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtiHorasFecha.TabIndex = 303
        '
        'Label11
        '
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label11.Location = New System.Drawing.Point(0, 7)
        Me.Label11.Name = "Label11"
        Me.Label11.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label11.Size = New System.Drawing.Size(89, 28)
        Me.Label11.TabIndex = 302
        Me.Label11.Text = "Fecha"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlHorasMonto
        '
        Me.pnlHorasMonto.Controls.Add(Me.dbHorasMonto)
        Me.pnlHorasMonto.Controls.Add(Me.Label7)
        Me.pnlHorasMonto.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHorasMonto.Enabled = false
        Me.pnlHorasMonto.Location = New System.Drawing.Point(0, 210)
        Me.pnlHorasMonto.Name = "pnlHorasMonto"
        Me.pnlHorasMonto.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlHorasMonto.Size = New System.Drawing.Size(325, 35)
        Me.pnlHorasMonto.TabIndex = 6
        Me.pnlHorasMonto.Visible = false
        '
        'dbHorasMonto
        '
        '
        '
        '
        Me.dbHorasMonto.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dbHorasMonto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dbHorasMonto.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dbHorasMonto.DisplayFormat = "0.##"
        Me.dbHorasMonto.Dock = System.Windows.Forms.DockStyle.Left
        Me.dbHorasMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.dbHorasMonto.Increment = 1R
        Me.dbHorasMonto.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dbHorasMonto.Location = New System.Drawing.Point(89, 7)
        Me.dbHorasMonto.MaxValue = 500000R
        Me.dbHorasMonto.MinValue = -500000R
        Me.dbHorasMonto.Name = "dbHorasMonto"
        Me.dbHorasMonto.ShowUpDown = true
        Me.dbHorasMonto.Size = New System.Drawing.Size(220, 20)
        Me.dbHorasMonto.TabIndex = 299
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label7.Location = New System.Drawing.Point(0, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label7.Size = New System.Drawing.Size(89, 28)
        Me.Label7.TabIndex = 298
        Me.Label7.Text = "Monto"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlHorasDescripcion
        '
        Me.pnlHorasDescripcion.Controls.Add(Me.txtHorasDescripcion)
        Me.pnlHorasDescripcion.Controls.Add(Me.Label6)
        Me.pnlHorasDescripcion.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHorasDescripcion.Enabled = false
        Me.pnlHorasDescripcion.Location = New System.Drawing.Point(0, 175)
        Me.pnlHorasDescripcion.Name = "pnlHorasDescripcion"
        Me.pnlHorasDescripcion.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlHorasDescripcion.Size = New System.Drawing.Size(325, 35)
        Me.pnlHorasDescripcion.TabIndex = 5
        Me.pnlHorasDescripcion.Visible = false
        '
        'txtHorasDescripcion
        '
        '
        '
        '
        Me.txtHorasDescripcion.Border.Class = "TextBoxBorder"
        Me.txtHorasDescripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtHorasDescripcion.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtHorasDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 7!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtHorasDescripcion.Location = New System.Drawing.Point(89, 7)
        Me.txtHorasDescripcion.MaxLength = 80
        Me.txtHorasDescripcion.Name = "txtHorasDescripcion"
        Me.txtHorasDescripcion.PreventEnterBeep = true
        Me.txtHorasDescripcion.Size = New System.Drawing.Size(220, 18)
        Me.txtHorasDescripcion.TabIndex = 298
        Me.txtHorasDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label6.Location = New System.Drawing.Point(0, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label6.Size = New System.Drawing.Size(89, 28)
        Me.Label6.TabIndex = 297
        Me.Label6.Text = "Descripción"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlHorasConcepto
        '
        Me.pnlHorasConcepto.Controls.Add(Me.cmbHorasConcepto)
        Me.pnlHorasConcepto.Controls.Add(Me.Label5)
        Me.pnlHorasConcepto.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHorasConcepto.Enabled = false
        Me.pnlHorasConcepto.Location = New System.Drawing.Point(0, 140)
        Me.pnlHorasConcepto.Name = "pnlHorasConcepto"
        Me.pnlHorasConcepto.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlHorasConcepto.Size = New System.Drawing.Size(325, 35)
        Me.pnlHorasConcepto.TabIndex = 4
        Me.pnlHorasConcepto.Visible = false
        '
        'cmbHorasConcepto
        '
        Me.cmbHorasConcepto.DisplayMember = "concepto"
        Me.cmbHorasConcepto.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmbHorasConcepto.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbHorasConcepto.DropDownWidth = 310
        Me.cmbHorasConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cmbHorasConcepto.FormattingEnabled = true
        Me.cmbHorasConcepto.ItemHeight = 14
        Me.cmbHorasConcepto.Location = New System.Drawing.Point(89, 7)
        Me.cmbHorasConcepto.MaxDropDownItems = 15
        Me.cmbHorasConcepto.MaxLength = 6
        Me.cmbHorasConcepto.Name = "cmbHorasConcepto"
        Me.cmbHorasConcepto.Size = New System.Drawing.Size(220, 20)
        Me.cmbHorasConcepto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbHorasConcepto.TabIndex = 298
        Me.cmbHorasConcepto.ValueMember = "id"
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label5.Location = New System.Drawing.Point(0, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label5.Size = New System.Drawing.Size(89, 28)
        Me.Label5.TabIndex = 296
        Me.Label5.Text = "Concepto"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlHorasPerDed
        '
        Me.pnlHorasPerDed.Controls.Add(Me.txtHorasPerDed)
        Me.pnlHorasPerDed.Controls.Add(Me.Label4)
        Me.pnlHorasPerDed.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHorasPerDed.Enabled = false
        Me.pnlHorasPerDed.Location = New System.Drawing.Point(0, 105)
        Me.pnlHorasPerDed.Name = "pnlHorasPerDed"
        Me.pnlHorasPerDed.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlHorasPerDed.Size = New System.Drawing.Size(325, 35)
        Me.pnlHorasPerDed.TabIndex = 3
        Me.pnlHorasPerDed.Visible = false
        '
        'txtHorasPerDed
        '
        '
        '
        '
        Me.txtHorasPerDed.Border.Class = "TextBoxBorder"
        Me.txtHorasPerDed.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtHorasPerDed.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtHorasPerDed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtHorasPerDed.Location = New System.Drawing.Point(89, 7)
        Me.txtHorasPerDed.MaxLength = 20
        Me.txtHorasPerDed.Name = "txtHorasPerDed"
        Me.txtHorasPerDed.PreventEnterBeep = true
        Me.txtHorasPerDed.Size = New System.Drawing.Size(220, 20)
        Me.txtHorasPerDed.TabIndex = 296
        Me.txtHorasPerDed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label4.Size = New System.Drawing.Size(89, 28)
        Me.Label4.TabIndex = 295
        Me.Label4.Text = "Naturaleza"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlHorasReloj
        '
        Me.pnlHorasReloj.Controls.Add(Me.txtHorasReloj)
        Me.pnlHorasReloj.Controls.Add(Me.Label3)
        Me.pnlHorasReloj.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHorasReloj.Enabled = false
        Me.pnlHorasReloj.Location = New System.Drawing.Point(0, 70)
        Me.pnlHorasReloj.Name = "pnlHorasReloj"
        Me.pnlHorasReloj.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlHorasReloj.Size = New System.Drawing.Size(325, 35)
        Me.pnlHorasReloj.TabIndex = 2
        Me.pnlHorasReloj.Visible = false
        '
        'txtHorasReloj
        '
        '
        '
        '
        Me.txtHorasReloj.Border.Class = "TextBoxBorder"
        Me.txtHorasReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtHorasReloj.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtHorasReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtHorasReloj.Location = New System.Drawing.Point(89, 7)
        Me.txtHorasReloj.MaxLength = 6
        Me.txtHorasReloj.Name = "txtHorasReloj"
        Me.txtHorasReloj.PreventEnterBeep = true
        Me.txtHorasReloj.Size = New System.Drawing.Size(220, 20)
        Me.txtHorasReloj.TabIndex = 295
        Me.txtHorasReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label3.Size = New System.Drawing.Size(89, 28)
        Me.Label3.TabIndex = 294
        Me.Label3.Text = "Reloj"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlHorasPeriodo
        '
        Me.pnlHorasPeriodo.Controls.Add(Me.txtHorasPeriodo)
        Me.pnlHorasPeriodo.Controls.Add(Me.Label2)
        Me.pnlHorasPeriodo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHorasPeriodo.Enabled = false
        Me.pnlHorasPeriodo.Location = New System.Drawing.Point(0, 35)
        Me.pnlHorasPeriodo.Name = "pnlHorasPeriodo"
        Me.pnlHorasPeriodo.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlHorasPeriodo.Size = New System.Drawing.Size(325, 35)
        Me.pnlHorasPeriodo.TabIndex = 1
        Me.pnlHorasPeriodo.Visible = false
        '
        'txtHorasPeriodo
        '
        '
        '
        '
        Me.txtHorasPeriodo.Border.Class = "TextBoxBorder"
        Me.txtHorasPeriodo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtHorasPeriodo.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtHorasPeriodo.Enabled = false
        Me.txtHorasPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtHorasPeriodo.Location = New System.Drawing.Point(89, 7)
        Me.txtHorasPeriodo.MaxLength = 2
        Me.txtHorasPeriodo.Name = "txtHorasPeriodo"
        Me.txtHorasPeriodo.PreventEnterBeep = true
        Me.txtHorasPeriodo.Size = New System.Drawing.Size(220, 20)
        Me.txtHorasPeriodo.TabIndex = 294
        Me.txtHorasPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label2.Size = New System.Drawing.Size(89, 28)
        Me.Label2.TabIndex = 293
        Me.Label2.Text = "Periodo"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlHorasAno
        '
        Me.pnlHorasAno.Controls.Add(Me.txtHorasAno)
        Me.pnlHorasAno.Controls.Add(Me.Label1)
        Me.pnlHorasAno.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHorasAno.Enabled = false
        Me.pnlHorasAno.Location = New System.Drawing.Point(0, 0)
        Me.pnlHorasAno.Name = "pnlHorasAno"
        Me.pnlHorasAno.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlHorasAno.Size = New System.Drawing.Size(325, 35)
        Me.pnlHorasAno.TabIndex = 0
        Me.pnlHorasAno.Visible = false
        '
        'txtHorasAno
        '
        '
        '
        '
        Me.txtHorasAno.Border.Class = "TextBoxBorder"
        Me.txtHorasAno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtHorasAno.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtHorasAno.Enabled = false
        Me.txtHorasAno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtHorasAno.Location = New System.Drawing.Point(89, 7)
        Me.txtHorasAno.MaxLength = 4
        Me.txtHorasAno.Name = "txtHorasAno"
        Me.txtHorasAno.PreventEnterBeep = true
        Me.txtHorasAno.Size = New System.Drawing.Size(220, 20)
        Me.txtHorasAno.TabIndex = 293
        Me.txtHorasAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label1.Size = New System.Drawing.Size(89, 28)
        Me.Label1.TabIndex = 292
        Me.Label1.Text = "Año"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tabPagMisc
        '
        Me.tabPagMisc.Controls.Add(Me.pnlAjustes2)
        Me.tabPagMisc.Controls.Add(Me.pnlAjustes)
        Me.tabPagMisc.Location = New System.Drawing.Point(4, 22)
        Me.tabPagMisc.Name = "tabPagMisc"
        Me.tabPagMisc.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPagMisc.Size = New System.Drawing.Size(667, 395)
        Me.tabPagMisc.TabIndex = 1
        Me.tabPagMisc.Text = "Misceláneos"
        Me.tabPagMisc.UseVisualStyleBackColor = true
        '
        'pnlAjustes2
        '
        Me.pnlAjustes2.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAjustes2.Location = New System.Drawing.Point(328, 3)
        Me.pnlAjustes2.Name = "pnlAjustes2"
        Me.pnlAjustes2.Size = New System.Drawing.Size(280, 389)
        Me.pnlAjustes2.TabIndex = 5
        '
        'pnlAjustes
        '
        Me.pnlAjustes.Controls.Add(Me.pnlAjustesSaldo)
        Me.pnlAjustes.Controls.Add(Me.pnlAjustesSueldo)
        Me.pnlAjustes.Controls.Add(Me.pnlAjustesFecha)
        Me.pnlAjustes.Controls.Add(Me.pnlAjustesMonto)
        Me.pnlAjustes.Controls.Add(Me.pnlAjustesDescripcion)
        Me.pnlAjustes.Controls.Add(Me.pnlAjustesConcepto)
        Me.pnlAjustes.Controls.Add(Me.pnlAjustesPerDed)
        Me.pnlAjustes.Controls.Add(Me.pnlAjustesReloj)
        Me.pnlAjustes.Controls.Add(Me.pnlAjustesPeriodo)
        Me.pnlAjustes.Controls.Add(Me.pnlAjustesAno)
        Me.pnlAjustes.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAjustes.Location = New System.Drawing.Point(3, 3)
        Me.pnlAjustes.Name = "pnlAjustes"
        Me.pnlAjustes.Size = New System.Drawing.Size(325, 389)
        Me.pnlAjustes.TabIndex = 4
        '
        'pnlAjustesSaldo
        '
        Me.pnlAjustesSaldo.Controls.Add(Me.dbAjustesSaldo)
        Me.pnlAjustesSaldo.Controls.Add(Me.Label45)
        Me.pnlAjustesSaldo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAjustesSaldo.Enabled = false
        Me.pnlAjustesSaldo.Location = New System.Drawing.Point(0, 315)
        Me.pnlAjustesSaldo.Name = "pnlAjustesSaldo"
        Me.pnlAjustesSaldo.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlAjustesSaldo.Size = New System.Drawing.Size(325, 35)
        Me.pnlAjustesSaldo.TabIndex = 12
        Me.pnlAjustesSaldo.Visible = false
        '
        'dbAjustesSaldo
        '
        '
        '
        '
        Me.dbAjustesSaldo.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dbAjustesSaldo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dbAjustesSaldo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dbAjustesSaldo.Dock = System.Windows.Forms.DockStyle.Left
        Me.dbAjustesSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.dbAjustesSaldo.Increment = 1R
        Me.dbAjustesSaldo.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dbAjustesSaldo.Location = New System.Drawing.Point(89, 7)
        Me.dbAjustesSaldo.MaxValue = 500000R
        Me.dbAjustesSaldo.MinValue = -500000R
        Me.dbAjustesSaldo.Name = "dbAjustesSaldo"
        Me.dbAjustesSaldo.ShowUpDown = true
        Me.dbAjustesSaldo.Size = New System.Drawing.Size(220, 20)
        Me.dbAjustesSaldo.TabIndex = 295
        '
        'Label45
        '
        Me.Label45.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label45.Location = New System.Drawing.Point(0, 7)
        Me.Label45.Name = "Label45"
        Me.Label45.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label45.Size = New System.Drawing.Size(89, 28)
        Me.Label45.TabIndex = 294
        Me.Label45.Text = "Saldo"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlAjustesSueldo
        '
        Me.pnlAjustesSueldo.Controls.Add(Me.dbAjustesSueldo)
        Me.pnlAjustesSueldo.Controls.Add(Me.Label46)
        Me.pnlAjustesSueldo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAjustesSueldo.Enabled = false
        Me.pnlAjustesSueldo.Location = New System.Drawing.Point(0, 280)
        Me.pnlAjustesSueldo.Name = "pnlAjustesSueldo"
        Me.pnlAjustesSueldo.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlAjustesSueldo.Size = New System.Drawing.Size(325, 35)
        Me.pnlAjustesSueldo.TabIndex = 11
        Me.pnlAjustesSueldo.Visible = false
        '
        'dbAjustesSueldo
        '
        '
        '
        '
        Me.dbAjustesSueldo.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dbAjustesSueldo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dbAjustesSueldo.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dbAjustesSueldo.DisplayFormat = "0.##"
        Me.dbAjustesSueldo.Dock = System.Windows.Forms.DockStyle.Left
        Me.dbAjustesSueldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.dbAjustesSueldo.Increment = 1R
        Me.dbAjustesSueldo.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dbAjustesSueldo.Location = New System.Drawing.Point(89, 7)
        Me.dbAjustesSueldo.MaxValue = 100000R
        Me.dbAjustesSueldo.MinValue = 0R
        Me.dbAjustesSueldo.Name = "dbAjustesSueldo"
        Me.dbAjustesSueldo.ShowUpDown = true
        Me.dbAjustesSueldo.Size = New System.Drawing.Size(220, 20)
        Me.dbAjustesSueldo.TabIndex = 304
        '
        'Label46
        '
        Me.Label46.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label46.Location = New System.Drawing.Point(0, 7)
        Me.Label46.Name = "Label46"
        Me.Label46.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label46.Size = New System.Drawing.Size(89, 28)
        Me.Label46.TabIndex = 303
        Me.Label46.Text = "Sueldo"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlAjustesFecha
        '
        Me.pnlAjustesFecha.Controls.Add(Me.dtiAjustesFecha)
        Me.pnlAjustesFecha.Controls.Add(Me.Label47)
        Me.pnlAjustesFecha.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAjustesFecha.Enabled = false
        Me.pnlAjustesFecha.Location = New System.Drawing.Point(0, 245)
        Me.pnlAjustesFecha.Name = "pnlAjustesFecha"
        Me.pnlAjustesFecha.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlAjustesFecha.Size = New System.Drawing.Size(325, 35)
        Me.pnlAjustesFecha.TabIndex = 10
        Me.pnlAjustesFecha.Visible = false
        '
        'dtiAjustesFecha
        '
        '
        '
        '
        Me.dtiAjustesFecha.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtiAjustesFecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiAjustesFecha.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtiAjustesFecha.ButtonDropDown.Visible = true
        Me.dtiAjustesFecha.CustomFormat = "yyyy-MM-dd"
        Me.dtiAjustesFecha.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtiAjustesFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.dtiAjustesFecha.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtiAjustesFecha.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dtiAjustesFecha.IsPopupCalendarOpen = false
        Me.dtiAjustesFecha.Location = New System.Drawing.Point(89, 7)
        '
        '
        '
        Me.dtiAjustesFecha.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtiAjustesFecha.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiAjustesFecha.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtiAjustesFecha.MonthCalendar.ClearButtonVisible = true
        '
        '
        '
        Me.dtiAjustesFecha.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtiAjustesFecha.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiAjustesFecha.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtiAjustesFecha.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtiAjustesFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtiAjustesFecha.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtiAjustesFecha.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiAjustesFecha.MonthCalendar.DisplayMonth = New Date(2023, 10, 1, 0, 0, 0, 0)
        Me.dtiAjustesFecha.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtiAjustesFecha.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtiAjustesFecha.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtiAjustesFecha.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiAjustesFecha.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtiAjustesFecha.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiAjustesFecha.MonthCalendar.TodayButtonVisible = true
        Me.dtiAjustesFecha.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtiAjustesFecha.Name = "dtiAjustesFecha"
        Me.dtiAjustesFecha.Size = New System.Drawing.Size(220, 20)
        Me.dtiAjustesFecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtiAjustesFecha.TabIndex = 303
        '
        'Label47
        '
        Me.Label47.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label47.Location = New System.Drawing.Point(0, 7)
        Me.Label47.Name = "Label47"
        Me.Label47.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label47.Size = New System.Drawing.Size(89, 28)
        Me.Label47.TabIndex = 302
        Me.Label47.Text = "Fecha"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlAjustesMonto
        '
        Me.pnlAjustesMonto.Controls.Add(Me.dbAjustesMonto)
        Me.pnlAjustesMonto.Controls.Add(Me.Label51)
        Me.pnlAjustesMonto.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAjustesMonto.Enabled = false
        Me.pnlAjustesMonto.Location = New System.Drawing.Point(0, 210)
        Me.pnlAjustesMonto.Name = "pnlAjustesMonto"
        Me.pnlAjustesMonto.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlAjustesMonto.Size = New System.Drawing.Size(325, 35)
        Me.pnlAjustesMonto.TabIndex = 6
        Me.pnlAjustesMonto.Visible = false
        '
        'dbAjustesMonto
        '
        '
        '
        '
        Me.dbAjustesMonto.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dbAjustesMonto.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dbAjustesMonto.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dbAjustesMonto.DisplayFormat = "0.##"
        Me.dbAjustesMonto.Dock = System.Windows.Forms.DockStyle.Left
        Me.dbAjustesMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.dbAjustesMonto.Increment = 1R
        Me.dbAjustesMonto.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dbAjustesMonto.Location = New System.Drawing.Point(89, 7)
        Me.dbAjustesMonto.MaxValue = 500000R
        Me.dbAjustesMonto.MinValue = -500000R
        Me.dbAjustesMonto.Name = "dbAjustesMonto"
        Me.dbAjustesMonto.ShowUpDown = true
        Me.dbAjustesMonto.Size = New System.Drawing.Size(220, 20)
        Me.dbAjustesMonto.TabIndex = 299
        '
        'Label51
        '
        Me.Label51.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label51.Location = New System.Drawing.Point(0, 7)
        Me.Label51.Name = "Label51"
        Me.Label51.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label51.Size = New System.Drawing.Size(89, 28)
        Me.Label51.TabIndex = 298
        Me.Label51.Text = "Monto"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlAjustesDescripcion
        '
        Me.pnlAjustesDescripcion.Controls.Add(Me.txtAjustesDescripcion)
        Me.pnlAjustesDescripcion.Controls.Add(Me.Label52)
        Me.pnlAjustesDescripcion.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAjustesDescripcion.Enabled = false
        Me.pnlAjustesDescripcion.Location = New System.Drawing.Point(0, 175)
        Me.pnlAjustesDescripcion.Name = "pnlAjustesDescripcion"
        Me.pnlAjustesDescripcion.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlAjustesDescripcion.Size = New System.Drawing.Size(325, 35)
        Me.pnlAjustesDescripcion.TabIndex = 5
        Me.pnlAjustesDescripcion.Visible = false
        '
        'txtAjustesDescripcion
        '
        '
        '
        '
        Me.txtAjustesDescripcion.Border.Class = "TextBoxBorder"
        Me.txtAjustesDescripcion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAjustesDescripcion.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtAjustesDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 7!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtAjustesDescripcion.Location = New System.Drawing.Point(89, 7)
        Me.txtAjustesDescripcion.MaxLength = 80
        Me.txtAjustesDescripcion.Name = "txtAjustesDescripcion"
        Me.txtAjustesDescripcion.PreventEnterBeep = true
        Me.txtAjustesDescripcion.Size = New System.Drawing.Size(220, 18)
        Me.txtAjustesDescripcion.TabIndex = 298
        Me.txtAjustesDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label52
        '
        Me.Label52.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label52.Location = New System.Drawing.Point(0, 7)
        Me.Label52.Name = "Label52"
        Me.Label52.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label52.Size = New System.Drawing.Size(89, 28)
        Me.Label52.TabIndex = 297
        Me.Label52.Text = "Descripción"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlAjustesConcepto
        '
        Me.pnlAjustesConcepto.Controls.Add(Me.cmbAjustesConcepto)
        Me.pnlAjustesConcepto.Controls.Add(Me.Label53)
        Me.pnlAjustesConcepto.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAjustesConcepto.Enabled = false
        Me.pnlAjustesConcepto.Location = New System.Drawing.Point(0, 140)
        Me.pnlAjustesConcepto.Name = "pnlAjustesConcepto"
        Me.pnlAjustesConcepto.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlAjustesConcepto.Size = New System.Drawing.Size(325, 35)
        Me.pnlAjustesConcepto.TabIndex = 4
        Me.pnlAjustesConcepto.Visible = false
        '
        'cmbAjustesConcepto
        '
        Me.cmbAjustesConcepto.DisplayMember = "concepto"
        Me.cmbAjustesConcepto.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmbAjustesConcepto.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbAjustesConcepto.DropDownWidth = 350
        Me.cmbAjustesConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cmbAjustesConcepto.FormattingEnabled = true
        Me.cmbAjustesConcepto.ItemHeight = 14
        Me.cmbAjustesConcepto.Location = New System.Drawing.Point(89, 7)
        Me.cmbAjustesConcepto.MaxDropDownItems = 15
        Me.cmbAjustesConcepto.MaxLength = 6
        Me.cmbAjustesConcepto.Name = "cmbAjustesConcepto"
        Me.cmbAjustesConcepto.Size = New System.Drawing.Size(220, 20)
        Me.cmbAjustesConcepto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbAjustesConcepto.TabIndex = 299
        Me.cmbAjustesConcepto.ValueMember = "id"
        '
        'Label53
        '
        Me.Label53.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label53.Location = New System.Drawing.Point(0, 7)
        Me.Label53.Name = "Label53"
        Me.Label53.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label53.Size = New System.Drawing.Size(89, 28)
        Me.Label53.TabIndex = 296
        Me.Label53.Text = "Concepto"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlAjustesPerDed
        '
        Me.pnlAjustesPerDed.Controls.Add(Me.txtAjustesPerDed)
        Me.pnlAjustesPerDed.Controls.Add(Me.Label63)
        Me.pnlAjustesPerDed.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAjustesPerDed.Enabled = false
        Me.pnlAjustesPerDed.Location = New System.Drawing.Point(0, 105)
        Me.pnlAjustesPerDed.Name = "pnlAjustesPerDed"
        Me.pnlAjustesPerDed.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlAjustesPerDed.Size = New System.Drawing.Size(325, 35)
        Me.pnlAjustesPerDed.TabIndex = 3
        Me.pnlAjustesPerDed.Visible = false
        '
        'txtAjustesPerDed
        '
        '
        '
        '
        Me.txtAjustesPerDed.Border.Class = "TextBoxBorder"
        Me.txtAjustesPerDed.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAjustesPerDed.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtAjustesPerDed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtAjustesPerDed.Location = New System.Drawing.Point(89, 7)
        Me.txtAjustesPerDed.MaxLength = 20
        Me.txtAjustesPerDed.Name = "txtAjustesPerDed"
        Me.txtAjustesPerDed.PreventEnterBeep = true
        Me.txtAjustesPerDed.Size = New System.Drawing.Size(220, 20)
        Me.txtAjustesPerDed.TabIndex = 296
        Me.txtAjustesPerDed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label63
        '
        Me.Label63.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label63.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label63.Location = New System.Drawing.Point(0, 7)
        Me.Label63.Name = "Label63"
        Me.Label63.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label63.Size = New System.Drawing.Size(89, 28)
        Me.Label63.TabIndex = 295
        Me.Label63.Text = "Naturaleza"
        Me.Label63.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlAjustesReloj
        '
        Me.pnlAjustesReloj.Controls.Add(Me.txtAjustesReloj)
        Me.pnlAjustesReloj.Controls.Add(Me.Label64)
        Me.pnlAjustesReloj.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAjustesReloj.Enabled = false
        Me.pnlAjustesReloj.Location = New System.Drawing.Point(0, 70)
        Me.pnlAjustesReloj.Name = "pnlAjustesReloj"
        Me.pnlAjustesReloj.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlAjustesReloj.Size = New System.Drawing.Size(325, 35)
        Me.pnlAjustesReloj.TabIndex = 2
        Me.pnlAjustesReloj.Visible = false
        '
        'txtAjustesReloj
        '
        '
        '
        '
        Me.txtAjustesReloj.Border.Class = "TextBoxBorder"
        Me.txtAjustesReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAjustesReloj.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtAjustesReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtAjustesReloj.Location = New System.Drawing.Point(89, 7)
        Me.txtAjustesReloj.MaxLength = 6
        Me.txtAjustesReloj.Name = "txtAjustesReloj"
        Me.txtAjustesReloj.PreventEnterBeep = true
        Me.txtAjustesReloj.Size = New System.Drawing.Size(220, 20)
        Me.txtAjustesReloj.TabIndex = 295
        Me.txtAjustesReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label64
        '
        Me.Label64.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label64.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label64.Location = New System.Drawing.Point(0, 7)
        Me.Label64.Name = "Label64"
        Me.Label64.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label64.Size = New System.Drawing.Size(89, 28)
        Me.Label64.TabIndex = 294
        Me.Label64.Text = "Reloj"
        Me.Label64.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlAjustesPeriodo
        '
        Me.pnlAjustesPeriodo.Controls.Add(Me.txtAjustesPeriodo)
        Me.pnlAjustesPeriodo.Controls.Add(Me.Label65)
        Me.pnlAjustesPeriodo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAjustesPeriodo.Enabled = false
        Me.pnlAjustesPeriodo.Location = New System.Drawing.Point(0, 35)
        Me.pnlAjustesPeriodo.Name = "pnlAjustesPeriodo"
        Me.pnlAjustesPeriodo.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlAjustesPeriodo.Size = New System.Drawing.Size(325, 35)
        Me.pnlAjustesPeriodo.TabIndex = 1
        Me.pnlAjustesPeriodo.Visible = false
        '
        'txtAjustesPeriodo
        '
        '
        '
        '
        Me.txtAjustesPeriodo.Border.Class = "TextBoxBorder"
        Me.txtAjustesPeriodo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAjustesPeriodo.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtAjustesPeriodo.Enabled = false
        Me.txtAjustesPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtAjustesPeriodo.Location = New System.Drawing.Point(89, 7)
        Me.txtAjustesPeriodo.MaxLength = 2
        Me.txtAjustesPeriodo.Name = "txtAjustesPeriodo"
        Me.txtAjustesPeriodo.PreventEnterBeep = true
        Me.txtAjustesPeriodo.Size = New System.Drawing.Size(220, 20)
        Me.txtAjustesPeriodo.TabIndex = 294
        Me.txtAjustesPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label65
        '
        Me.Label65.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label65.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label65.Location = New System.Drawing.Point(0, 7)
        Me.Label65.Name = "Label65"
        Me.Label65.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label65.Size = New System.Drawing.Size(89, 28)
        Me.Label65.TabIndex = 293
        Me.Label65.Text = "Periodo"
        Me.Label65.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlAjustesAno
        '
        Me.pnlAjustesAno.Controls.Add(Me.txtAjustesAno)
        Me.pnlAjustesAno.Controls.Add(Me.Label66)
        Me.pnlAjustesAno.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlAjustesAno.Enabled = false
        Me.pnlAjustesAno.Location = New System.Drawing.Point(0, 0)
        Me.pnlAjustesAno.Name = "pnlAjustesAno"
        Me.pnlAjustesAno.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlAjustesAno.Size = New System.Drawing.Size(325, 35)
        Me.pnlAjustesAno.TabIndex = 0
        Me.pnlAjustesAno.Visible = false
        '
        'txtAjustesAno
        '
        '
        '
        '
        Me.txtAjustesAno.Border.Class = "TextBoxBorder"
        Me.txtAjustesAno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtAjustesAno.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtAjustesAno.Enabled = false
        Me.txtAjustesAno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtAjustesAno.Location = New System.Drawing.Point(89, 7)
        Me.txtAjustesAno.MaxLength = 4
        Me.txtAjustesAno.Name = "txtAjustesAno"
        Me.txtAjustesAno.PreventEnterBeep = true
        Me.txtAjustesAno.Size = New System.Drawing.Size(220, 20)
        Me.txtAjustesAno.TabIndex = 293
        Me.txtAjustesAno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label66
        '
        Me.Label66.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label66.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label66.Location = New System.Drawing.Point(0, 7)
        Me.Label66.Name = "Label66"
        Me.Label66.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label66.Size = New System.Drawing.Size(89, 28)
        Me.Label66.TabIndex = 292
        Me.Label66.Text = "Año"
        Me.Label66.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tabPagNominaPro
        '
        Me.tabPagNominaPro.Controls.Add(Me.pnlNomina2)
        Me.tabPagNominaPro.Controls.Add(Me.pnlNominaSeparador)
        Me.tabPagNominaPro.Controls.Add(Me.pnlNomina)
        Me.tabPagNominaPro.Location = New System.Drawing.Point(4, 22)
        Me.tabPagNominaPro.Name = "tabPagNominaPro"
        Me.tabPagNominaPro.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPagNominaPro.Size = New System.Drawing.Size(667, 395)
        Me.tabPagNominaPro.TabIndex = 3
        Me.tabPagNominaPro.Text = "Empleado"
        Me.tabPagNominaPro.UseVisualStyleBackColor = true
        '
        'pnlNomina2
        '
        Me.pnlNomina2.Controls.Add(Me.pnlNominaFiniquito)
        Me.pnlNomina2.Controls.Add(Me.pnlNominaFaltas)
        Me.pnlNomina2.Controls.Add(Me.pnlNominaIncapacidad)
        Me.pnlNomina2.Controls.Add(Me.pnlNominaPrivacDias)
        Me.pnlNomina2.Controls.Add(Me.pnlNominaPrivacPorc)
        Me.pnlNomina2.Controls.Add(Me.pnlNominaCobroSegViv)
        Me.pnlNomina2.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlNomina2.Location = New System.Drawing.Point(340, 3)
        Me.pnlNomina2.Name = "pnlNomina2"
        Me.pnlNomina2.Size = New System.Drawing.Size(325, 389)
        Me.pnlNomina2.TabIndex = 7
        '
        'pnlNominaFiniquito
        '
        Me.pnlNominaFiniquito.Controls.Add(Me.swbNominaFiniquito)
        Me.pnlNominaFiniquito.Controls.Add(Me.Label9)
        Me.pnlNominaFiniquito.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNominaFiniquito.Enabled = false
        Me.pnlNominaFiniquito.Location = New System.Drawing.Point(0, 175)
        Me.pnlNominaFiniquito.Name = "pnlNominaFiniquito"
        Me.pnlNominaFiniquito.Padding = New System.Windows.Forms.Padding(0, 7, 17, 0)
        Me.pnlNominaFiniquito.Size = New System.Drawing.Size(325, 35)
        Me.pnlNominaFiniquito.TabIndex = 29
        Me.pnlNominaFiniquito.Visible = false
        '
        'swbNominaFiniquito
        '
        '
        '
        '
        Me.swbNominaFiniquito.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swbNominaFiniquito.Dock = System.Windows.Forms.DockStyle.Top
        Me.swbNominaFiniquito.Location = New System.Drawing.Point(89, 7)
        Me.swbNominaFiniquito.Name = "swbNominaFiniquito"
        Me.swbNominaFiniquito.Size = New System.Drawing.Size(219, 20)
        Me.swbNominaFiniquito.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swbNominaFiniquito.TabIndex = 300
        '
        'Label9
        '
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label9.Location = New System.Drawing.Point(0, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label9.Size = New System.Drawing.Size(89, 28)
        Me.Label9.TabIndex = 299
        Me.Label9.Text = "Finiquito normal"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlNominaFaltas
        '
        Me.pnlNominaFaltas.Controls.Add(Me.intNominaFaltas)
        Me.pnlNominaFaltas.Controls.Add(Me.Label87)
        Me.pnlNominaFaltas.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNominaFaltas.Enabled = false
        Me.pnlNominaFaltas.Location = New System.Drawing.Point(0, 140)
        Me.pnlNominaFaltas.Name = "pnlNominaFaltas"
        Me.pnlNominaFaltas.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlNominaFaltas.Size = New System.Drawing.Size(325, 35)
        Me.pnlNominaFaltas.TabIndex = 24
        Me.pnlNominaFaltas.Visible = false
        '
        'intNominaFaltas
        '
        '
        '
        '
        Me.intNominaFaltas.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.intNominaFaltas.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.intNominaFaltas.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.intNominaFaltas.DisplayFormat = "0"
        Me.intNominaFaltas.Dock = System.Windows.Forms.DockStyle.Left
        Me.intNominaFaltas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.intNominaFaltas.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.intNominaFaltas.Location = New System.Drawing.Point(89, 7)
        Me.intNominaFaltas.MaxValue = 100
        Me.intNominaFaltas.MinValue = 0
        Me.intNominaFaltas.Name = "intNominaFaltas"
        Me.intNominaFaltas.ShowUpDown = true
        Me.intNominaFaltas.Size = New System.Drawing.Size(220, 20)
        Me.intNominaFaltas.TabIndex = 300
        '
        'Label87
        '
        Me.Label87.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label87.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label87.Location = New System.Drawing.Point(0, 7)
        Me.Label87.Name = "Label87"
        Me.Label87.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label87.Size = New System.Drawing.Size(89, 28)
        Me.Label87.TabIndex = 298
        Me.Label87.Text = "Días faltas"
        Me.Label87.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlNominaIncapacidad
        '
        Me.pnlNominaIncapacidad.Controls.Add(Me.intNominaIncapacidad)
        Me.pnlNominaIncapacidad.Controls.Add(Me.Label88)
        Me.pnlNominaIncapacidad.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNominaIncapacidad.Enabled = false
        Me.pnlNominaIncapacidad.Location = New System.Drawing.Point(0, 105)
        Me.pnlNominaIncapacidad.Name = "pnlNominaIncapacidad"
        Me.pnlNominaIncapacidad.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlNominaIncapacidad.Size = New System.Drawing.Size(325, 35)
        Me.pnlNominaIncapacidad.TabIndex = 23
        Me.pnlNominaIncapacidad.Visible = false
        '
        'intNominaIncapacidad
        '
        '
        '
        '
        Me.intNominaIncapacidad.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.intNominaIncapacidad.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.intNominaIncapacidad.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.intNominaIncapacidad.DisplayFormat = "0"
        Me.intNominaIncapacidad.Dock = System.Windows.Forms.DockStyle.Left
        Me.intNominaIncapacidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.intNominaIncapacidad.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.intNominaIncapacidad.Location = New System.Drawing.Point(89, 7)
        Me.intNominaIncapacidad.MaxValue = 100
        Me.intNominaIncapacidad.MinValue = 0
        Me.intNominaIncapacidad.Name = "intNominaIncapacidad"
        Me.intNominaIncapacidad.ShowUpDown = true
        Me.intNominaIncapacidad.Size = New System.Drawing.Size(220, 20)
        Me.intNominaIncapacidad.TabIndex = 300
        '
        'Label88
        '
        Me.Label88.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label88.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label88.Location = New System.Drawing.Point(0, 7)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(89, 28)
        Me.Label88.TabIndex = 298
        Me.Label88.Text = "Días incapacidad"
        Me.Label88.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlNominaPrivacDias
        '
        Me.pnlNominaPrivacDias.Controls.Add(Me.dbNominaPrivacDias)
        Me.pnlNominaPrivacDias.Controls.Add(Me.Label90)
        Me.pnlNominaPrivacDias.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNominaPrivacDias.Enabled = false
        Me.pnlNominaPrivacDias.Location = New System.Drawing.Point(0, 70)
        Me.pnlNominaPrivacDias.Name = "pnlNominaPrivacDias"
        Me.pnlNominaPrivacDias.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlNominaPrivacDias.Size = New System.Drawing.Size(325, 35)
        Me.pnlNominaPrivacDias.TabIndex = 21
        Me.pnlNominaPrivacDias.Visible = false
        '
        'dbNominaPrivacDias
        '
        '
        '
        '
        Me.dbNominaPrivacDias.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dbNominaPrivacDias.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dbNominaPrivacDias.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dbNominaPrivacDias.DisplayFormat = "0.##"
        Me.dbNominaPrivacDias.Dock = System.Windows.Forms.DockStyle.Left
        Me.dbNominaPrivacDias.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.dbNominaPrivacDias.Increment = 1R
        Me.dbNominaPrivacDias.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dbNominaPrivacDias.Location = New System.Drawing.Point(89, 7)
        Me.dbNominaPrivacDias.MaxValue = 365R
        Me.dbNominaPrivacDias.MinValue = 0R
        Me.dbNominaPrivacDias.Name = "dbNominaPrivacDias"
        Me.dbNominaPrivacDias.ShowUpDown = true
        Me.dbNominaPrivacDias.Size = New System.Drawing.Size(220, 20)
        Me.dbNominaPrivacDias.TabIndex = 299
        '
        'Label90
        '
        Me.Label90.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label90.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label90.Location = New System.Drawing.Point(0, 7)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(89, 28)
        Me.Label90.TabIndex = 298
        Me.Label90.Text = "Días prima vacacional"
        Me.Label90.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlNominaPrivacPorc
        '
        Me.pnlNominaPrivacPorc.Controls.Add(Me.intNominaPrivacPorc)
        Me.pnlNominaPrivacPorc.Controls.Add(Me.Label91)
        Me.pnlNominaPrivacPorc.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNominaPrivacPorc.Enabled = false
        Me.pnlNominaPrivacPorc.Location = New System.Drawing.Point(0, 35)
        Me.pnlNominaPrivacPorc.Name = "pnlNominaPrivacPorc"
        Me.pnlNominaPrivacPorc.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlNominaPrivacPorc.Size = New System.Drawing.Size(325, 35)
        Me.pnlNominaPrivacPorc.TabIndex = 20
        Me.pnlNominaPrivacPorc.Visible = false
        '
        'intNominaPrivacPorc
        '
        '
        '
        '
        Me.intNominaPrivacPorc.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.intNominaPrivacPorc.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.intNominaPrivacPorc.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.intNominaPrivacPorc.DisplayFormat = "0"
        Me.intNominaPrivacPorc.Dock = System.Windows.Forms.DockStyle.Left
        Me.intNominaPrivacPorc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.intNominaPrivacPorc.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.intNominaPrivacPorc.Location = New System.Drawing.Point(89, 7)
        Me.intNominaPrivacPorc.MaxValue = 100
        Me.intNominaPrivacPorc.MinValue = 0
        Me.intNominaPrivacPorc.Name = "intNominaPrivacPorc"
        Me.intNominaPrivacPorc.ShowUpDown = true
        Me.intNominaPrivacPorc.Size = New System.Drawing.Size(220, 20)
        Me.intNominaPrivacPorc.TabIndex = 299
        '
        'Label91
        '
        Me.Label91.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label91.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label91.Location = New System.Drawing.Point(0, 7)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(89, 28)
        Me.Label91.TabIndex = 298
        Me.Label91.Text = "Porcentaje prima vacacional"
        Me.Label91.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlNominaCobroSegViv
        '
        Me.pnlNominaCobroSegViv.Controls.Add(Me.swbNominaCobroSegViv)
        Me.pnlNominaCobroSegViv.Controls.Add(Me.Label92)
        Me.pnlNominaCobroSegViv.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNominaCobroSegViv.Enabled = false
        Me.pnlNominaCobroSegViv.Location = New System.Drawing.Point(0, 0)
        Me.pnlNominaCobroSegViv.Name = "pnlNominaCobroSegViv"
        Me.pnlNominaCobroSegViv.Padding = New System.Windows.Forms.Padding(0, 7, 17, 0)
        Me.pnlNominaCobroSegViv.Size = New System.Drawing.Size(325, 35)
        Me.pnlNominaCobroSegViv.TabIndex = 3
        Me.pnlNominaCobroSegViv.Visible = false
        '
        'swbNominaCobroSegViv
        '
        '
        '
        '
        Me.swbNominaCobroSegViv.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swbNominaCobroSegViv.Dock = System.Windows.Forms.DockStyle.Top
        Me.swbNominaCobroSegViv.Location = New System.Drawing.Point(89, 7)
        Me.swbNominaCobroSegViv.Name = "swbNominaCobroSegViv"
        Me.swbNominaCobroSegViv.Size = New System.Drawing.Size(219, 20)
        Me.swbNominaCobroSegViv.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swbNominaCobroSegViv.TabIndex = 295
        '
        'Label92
        '
        Me.Label92.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label92.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label92.Location = New System.Drawing.Point(0, 7)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(89, 28)
        Me.Label92.TabIndex = 294
        Me.Label92.Text = "Cobro seguro vivienda"
        Me.Label92.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlNominaSeparador
        '
        Me.pnlNominaSeparador.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlNominaSeparador.Location = New System.Drawing.Point(328, 3)
        Me.pnlNominaSeparador.Name = "pnlNominaSeparador"
        Me.pnlNominaSeparador.Size = New System.Drawing.Size(12, 389)
        Me.pnlNominaSeparador.TabIndex = 6
        '
        'pnlNomina
        '
        Me.pnlNomina.Controls.Add(Me.pnlNominaInicioCredito)
        Me.pnlNomina.Controls.Add(Me.pnlNominaCuotaCredito)
        Me.pnlNomina.Controls.Add(Me.pnlNominaTipoCredito)
        Me.pnlNomina.Controls.Add(Me.pnlNominaInfonavitCredito)
        Me.pnlNomina.Controls.Add(Me.pnlNominaBaja)
        Me.pnlNomina.Controls.Add(Me.pnlNominaSindicalizado)
        Me.pnlNomina.Controls.Add(Me.pnlNominaIntegrado)
        Me.pnlNomina.Controls.Add(Me.pnlNominaSactual)
        Me.pnlNomina.Controls.Add(Me.pnlNominaCodClase)
        Me.pnlNomina.Controls.Add(Me.pnlNominaProcesar)
        Me.pnlNomina.Controls.Add(Me.pnlNominaReloj)
        Me.pnlNomina.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlNomina.Location = New System.Drawing.Point(3, 3)
        Me.pnlNomina.Name = "pnlNomina"
        Me.pnlNomina.Size = New System.Drawing.Size(325, 389)
        Me.pnlNomina.TabIndex = 4
        '
        'pnlNominaInicioCredito
        '
        Me.pnlNominaInicioCredito.Controls.Add(Me.dtiNominaInicioCredito)
        Me.pnlNominaInicioCredito.Controls.Add(Me.Label93)
        Me.pnlNominaInicioCredito.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNominaInicioCredito.Enabled = false
        Me.pnlNominaInicioCredito.Location = New System.Drawing.Point(0, 350)
        Me.pnlNominaInicioCredito.Name = "pnlNominaInicioCredito"
        Me.pnlNominaInicioCredito.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlNominaInicioCredito.Size = New System.Drawing.Size(325, 35)
        Me.pnlNominaInicioCredito.TabIndex = 20
        Me.pnlNominaInicioCredito.Visible = false
        '
        'dtiNominaInicioCredito
        '
        '
        '
        '
        Me.dtiNominaInicioCredito.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtiNominaInicioCredito.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiNominaInicioCredito.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtiNominaInicioCredito.ButtonDropDown.Visible = true
        Me.dtiNominaInicioCredito.CustomFormat = "yyyy-MM-dd"
        Me.dtiNominaInicioCredito.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtiNominaInicioCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.dtiNominaInicioCredito.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtiNominaInicioCredito.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dtiNominaInicioCredito.IsPopupCalendarOpen = false
        Me.dtiNominaInicioCredito.Location = New System.Drawing.Point(89, 7)
        '
        '
        '
        Me.dtiNominaInicioCredito.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtiNominaInicioCredito.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiNominaInicioCredito.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtiNominaInicioCredito.MonthCalendar.ClearButtonVisible = true
        '
        '
        '
        Me.dtiNominaInicioCredito.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtiNominaInicioCredito.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiNominaInicioCredito.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtiNominaInicioCredito.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtiNominaInicioCredito.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtiNominaInicioCredito.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtiNominaInicioCredito.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiNominaInicioCredito.MonthCalendar.DisplayMonth = New Date(2023, 10, 1, 0, 0, 0, 0)
        Me.dtiNominaInicioCredito.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtiNominaInicioCredito.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtiNominaInicioCredito.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtiNominaInicioCredito.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiNominaInicioCredito.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtiNominaInicioCredito.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiNominaInicioCredito.MonthCalendar.TodayButtonVisible = true
        Me.dtiNominaInicioCredito.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtiNominaInicioCredito.Name = "dtiNominaInicioCredito"
        Me.dtiNominaInicioCredito.Size = New System.Drawing.Size(220, 20)
        Me.dtiNominaInicioCredito.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtiNominaInicioCredito.TabIndex = 295
        '
        'Label93
        '
        Me.Label93.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label93.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label93.Location = New System.Drawing.Point(0, 7)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(89, 28)
        Me.Label93.TabIndex = 294
        Me.Label93.Text = "Fecha crédito infonavit"
        Me.Label93.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlNominaCuotaCredito
        '
        Me.pnlNominaCuotaCredito.Controls.Add(Me.dbNominaCuotaCredito)
        Me.pnlNominaCuotaCredito.Controls.Add(Me.Label75)
        Me.pnlNominaCuotaCredito.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNominaCuotaCredito.Enabled = false
        Me.pnlNominaCuotaCredito.Location = New System.Drawing.Point(0, 315)
        Me.pnlNominaCuotaCredito.Name = "pnlNominaCuotaCredito"
        Me.pnlNominaCuotaCredito.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlNominaCuotaCredito.Size = New System.Drawing.Size(325, 35)
        Me.pnlNominaCuotaCredito.TabIndex = 19
        Me.pnlNominaCuotaCredito.Visible = false
        '
        'dbNominaCuotaCredito
        '
        '
        '
        '
        Me.dbNominaCuotaCredito.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dbNominaCuotaCredito.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dbNominaCuotaCredito.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dbNominaCuotaCredito.DisplayFormat = "0.####"
        Me.dbNominaCuotaCredito.Dock = System.Windows.Forms.DockStyle.Left
        Me.dbNominaCuotaCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.dbNominaCuotaCredito.Increment = 1R
        Me.dbNominaCuotaCredito.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dbNominaCuotaCredito.Location = New System.Drawing.Point(89, 7)
        Me.dbNominaCuotaCredito.MaxValue = 100000R
        Me.dbNominaCuotaCredito.MinValue = 0R
        Me.dbNominaCuotaCredito.Name = "dbNominaCuotaCredito"
        Me.dbNominaCuotaCredito.ShowUpDown = true
        Me.dbNominaCuotaCredito.Size = New System.Drawing.Size(220, 20)
        Me.dbNominaCuotaCredito.TabIndex = 299
        '
        'Label75
        '
        Me.Label75.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label75.Location = New System.Drawing.Point(0, 7)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(89, 28)
        Me.Label75.TabIndex = 298
        Me.Label75.Text = "Cuota crédito infonavit"
        Me.Label75.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlNominaTipoCredito
        '
        Me.pnlNominaTipoCredito.Controls.Add(Me.cmbNominaTipoCredito)
        Me.pnlNominaTipoCredito.Controls.Add(Me.Label76)
        Me.pnlNominaTipoCredito.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNominaTipoCredito.Enabled = false
        Me.pnlNominaTipoCredito.Location = New System.Drawing.Point(0, 280)
        Me.pnlNominaTipoCredito.Name = "pnlNominaTipoCredito"
        Me.pnlNominaTipoCredito.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlNominaTipoCredito.Size = New System.Drawing.Size(325, 35)
        Me.pnlNominaTipoCredito.TabIndex = 18
        Me.pnlNominaTipoCredito.Visible = false
        '
        'cmbNominaTipoCredito
        '
        Me.cmbNominaTipoCredito.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmbNominaTipoCredito.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbNominaTipoCredito.DropDownHeight = 150
        Me.cmbNominaTipoCredito.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNominaTipoCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cmbNominaTipoCredito.FormattingEnabled = true
        Me.cmbNominaTipoCredito.IntegralHeight = false
        Me.cmbNominaTipoCredito.ItemHeight = 14
        Me.cmbNominaTipoCredito.Location = New System.Drawing.Point(89, 7)
        Me.cmbNominaTipoCredito.MaxDropDownItems = 15
        Me.cmbNominaTipoCredito.Name = "cmbNominaTipoCredito"
        Me.cmbNominaTipoCredito.Size = New System.Drawing.Size(220, 20)
        Me.cmbNominaTipoCredito.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbNominaTipoCredito.TabIndex = 297
        '
        'Label76
        '
        Me.Label76.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label76.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label76.Location = New System.Drawing.Point(0, 7)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(89, 28)
        Me.Label76.TabIndex = 296
        Me.Label76.Text = "Tipo crédito infonavit"
        Me.Label76.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlNominaInfonavitCredito
        '
        Me.pnlNominaInfonavitCredito.Controls.Add(Me.txtNominaInfonavitCredito)
        Me.pnlNominaInfonavitCredito.Controls.Add(Me.Label77)
        Me.pnlNominaInfonavitCredito.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNominaInfonavitCredito.Enabled = false
        Me.pnlNominaInfonavitCredito.Location = New System.Drawing.Point(0, 245)
        Me.pnlNominaInfonavitCredito.Name = "pnlNominaInfonavitCredito"
        Me.pnlNominaInfonavitCredito.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlNominaInfonavitCredito.Size = New System.Drawing.Size(325, 35)
        Me.pnlNominaInfonavitCredito.TabIndex = 17
        Me.pnlNominaInfonavitCredito.Visible = false
        '
        'txtNominaInfonavitCredito
        '
        '
        '
        '
        Me.txtNominaInfonavitCredito.Border.Class = "TextBoxBorder"
        Me.txtNominaInfonavitCredito.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNominaInfonavitCredito.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtNominaInfonavitCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtNominaInfonavitCredito.Location = New System.Drawing.Point(89, 7)
        Me.txtNominaInfonavitCredito.MaxLength = 11
        Me.txtNominaInfonavitCredito.Name = "txtNominaInfonavitCredito"
        Me.txtNominaInfonavitCredito.PreventEnterBeep = true
        Me.txtNominaInfonavitCredito.Size = New System.Drawing.Size(220, 20)
        Me.txtNominaInfonavitCredito.TabIndex = 295
        Me.txtNominaInfonavitCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label77
        '
        Me.Label77.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label77.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label77.Location = New System.Drawing.Point(0, 7)
        Me.Label77.Name = "Label77"
        Me.Label77.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label77.Size = New System.Drawing.Size(89, 28)
        Me.Label77.TabIndex = 294
        Me.Label77.Text = "Crédito infonavit"
        Me.Label77.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlNominaBaja
        '
        Me.pnlNominaBaja.Controls.Add(Me.dtiNominaBaja)
        Me.pnlNominaBaja.Controls.Add(Me.Label78)
        Me.pnlNominaBaja.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNominaBaja.Enabled = false
        Me.pnlNominaBaja.Location = New System.Drawing.Point(0, 210)
        Me.pnlNominaBaja.Name = "pnlNominaBaja"
        Me.pnlNominaBaja.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlNominaBaja.Size = New System.Drawing.Size(325, 35)
        Me.pnlNominaBaja.TabIndex = 16
        Me.pnlNominaBaja.Visible = false
        '
        'dtiNominaBaja
        '
        '
        '
        '
        Me.dtiNominaBaja.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dtiNominaBaja.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiNominaBaja.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
        Me.dtiNominaBaja.ButtonDropDown.Visible = true
        Me.dtiNominaBaja.CustomFormat = "yyyy-MM-dd"
        Me.dtiNominaBaja.Dock = System.Windows.Forms.DockStyle.Left
        Me.dtiNominaBaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.dtiNominaBaja.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
        Me.dtiNominaBaja.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dtiNominaBaja.IsPopupCalendarOpen = false
        Me.dtiNominaBaja.Location = New System.Drawing.Point(89, 7)
        '
        '
        '
        Me.dtiNominaBaja.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtiNominaBaja.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiNominaBaja.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        Me.dtiNominaBaja.MonthCalendar.ClearButtonVisible = true
        '
        '
        '
        Me.dtiNominaBaja.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
        Me.dtiNominaBaja.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiNominaBaja.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
        Me.dtiNominaBaja.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.dtiNominaBaja.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
        Me.dtiNominaBaja.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
        Me.dtiNominaBaja.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiNominaBaja.MonthCalendar.DisplayMonth = New Date(2023, 10, 1, 0, 0, 0, 0)
        Me.dtiNominaBaja.MonthCalendar.MarkedDates = New Date(-1) {}
        Me.dtiNominaBaja.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
        '
        '
        '
        Me.dtiNominaBaja.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
        Me.dtiNominaBaja.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
        Me.dtiNominaBaja.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
        Me.dtiNominaBaja.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dtiNominaBaja.MonthCalendar.TodayButtonVisible = true
        Me.dtiNominaBaja.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
        Me.dtiNominaBaja.Name = "dtiNominaBaja"
        Me.dtiNominaBaja.Size = New System.Drawing.Size(220, 20)
        Me.dtiNominaBaja.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.dtiNominaBaja.TabIndex = 306
        '
        'Label78
        '
        Me.Label78.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label78.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label78.Location = New System.Drawing.Point(0, 7)
        Me.Label78.Name = "Label78"
        Me.Label78.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label78.Size = New System.Drawing.Size(89, 28)
        Me.Label78.TabIndex = 305
        Me.Label78.Text = "Baja"
        Me.Label78.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlNominaSindicalizado
        '
        Me.pnlNominaSindicalizado.Controls.Add(Me.swbNominaSindicalizado)
        Me.pnlNominaSindicalizado.Controls.Add(Me.Label79)
        Me.pnlNominaSindicalizado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNominaSindicalizado.Enabled = false
        Me.pnlNominaSindicalizado.Location = New System.Drawing.Point(0, 175)
        Me.pnlNominaSindicalizado.Name = "pnlNominaSindicalizado"
        Me.pnlNominaSindicalizado.Padding = New System.Windows.Forms.Padding(0, 7, 17, 0)
        Me.pnlNominaSindicalizado.Size = New System.Drawing.Size(325, 35)
        Me.pnlNominaSindicalizado.TabIndex = 15
        Me.pnlNominaSindicalizado.Visible = false
        '
        'swbNominaSindicalizado
        '
        '
        '
        '
        Me.swbNominaSindicalizado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swbNominaSindicalizado.Dock = System.Windows.Forms.DockStyle.Top
        Me.swbNominaSindicalizado.Location = New System.Drawing.Point(89, 7)
        Me.swbNominaSindicalizado.Name = "swbNominaSindicalizado"
        Me.swbNominaSindicalizado.Size = New System.Drawing.Size(219, 20)
        Me.swbNominaSindicalizado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swbNominaSindicalizado.TabIndex = 300
        '
        'Label79
        '
        Me.Label79.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label79.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label79.Location = New System.Drawing.Point(0, 7)
        Me.Label79.Name = "Label79"
        Me.Label79.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label79.Size = New System.Drawing.Size(89, 28)
        Me.Label79.TabIndex = 299
        Me.Label79.Text = "Sindicalizado"
        Me.Label79.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlNominaIntegrado
        '
        Me.pnlNominaIntegrado.Controls.Add(Me.dbNominaIntegrado)
        Me.pnlNominaIntegrado.Controls.Add(Me.Label80)
        Me.pnlNominaIntegrado.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNominaIntegrado.Enabled = false
        Me.pnlNominaIntegrado.Location = New System.Drawing.Point(0, 140)
        Me.pnlNominaIntegrado.Name = "pnlNominaIntegrado"
        Me.pnlNominaIntegrado.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlNominaIntegrado.Size = New System.Drawing.Size(325, 35)
        Me.pnlNominaIntegrado.TabIndex = 14
        Me.pnlNominaIntegrado.Visible = false
        '
        'dbNominaIntegrado
        '
        '
        '
        '
        Me.dbNominaIntegrado.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dbNominaIntegrado.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dbNominaIntegrado.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dbNominaIntegrado.DisplayFormat = "0.##"
        Me.dbNominaIntegrado.Dock = System.Windows.Forms.DockStyle.Left
        Me.dbNominaIntegrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.dbNominaIntegrado.Increment = 1R
        Me.dbNominaIntegrado.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dbNominaIntegrado.Location = New System.Drawing.Point(89, 7)
        Me.dbNominaIntegrado.MaxValue = 100000R
        Me.dbNominaIntegrado.MinValue = 0R
        Me.dbNominaIntegrado.Name = "dbNominaIntegrado"
        Me.dbNominaIntegrado.ShowUpDown = true
        Me.dbNominaIntegrado.Size = New System.Drawing.Size(220, 20)
        Me.dbNominaIntegrado.TabIndex = 295
        '
        'Label80
        '
        Me.Label80.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label80.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label80.Location = New System.Drawing.Point(0, 7)
        Me.Label80.Name = "Label80"
        Me.Label80.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label80.Size = New System.Drawing.Size(89, 28)
        Me.Label80.TabIndex = 294
        Me.Label80.Text = "Integrado"
        Me.Label80.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlNominaSactual
        '
        Me.pnlNominaSactual.Controls.Add(Me.dbNominaSactual)
        Me.pnlNominaSactual.Controls.Add(Me.Label81)
        Me.pnlNominaSactual.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNominaSactual.Enabled = false
        Me.pnlNominaSactual.Location = New System.Drawing.Point(0, 105)
        Me.pnlNominaSactual.Name = "pnlNominaSactual"
        Me.pnlNominaSactual.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlNominaSactual.Size = New System.Drawing.Size(325, 35)
        Me.pnlNominaSactual.TabIndex = 13
        Me.pnlNominaSactual.Visible = false
        '
        'dbNominaSactual
        '
        '
        '
        '
        Me.dbNominaSactual.BackgroundStyle.Class = "DateTimeInputBackground"
        Me.dbNominaSactual.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.dbNominaSactual.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2
        Me.dbNominaSactual.DisplayFormat = "0.##"
        Me.dbNominaSactual.Dock = System.Windows.Forms.DockStyle.Left
        Me.dbNominaSactual.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.dbNominaSactual.Increment = 1R
        Me.dbNominaSactual.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center
        Me.dbNominaSactual.Location = New System.Drawing.Point(89, 7)
        Me.dbNominaSactual.MaxValue = 100000R
        Me.dbNominaSactual.MinValue = 0R
        Me.dbNominaSactual.Name = "dbNominaSactual"
        Me.dbNominaSactual.ShowUpDown = true
        Me.dbNominaSactual.Size = New System.Drawing.Size(220, 20)
        Me.dbNominaSactual.TabIndex = 295
        '
        'Label81
        '
        Me.Label81.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label81.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label81.Location = New System.Drawing.Point(0, 7)
        Me.Label81.Name = "Label81"
        Me.Label81.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label81.Size = New System.Drawing.Size(89, 28)
        Me.Label81.TabIndex = 294
        Me.Label81.Text = "Sueldo"
        Me.Label81.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlNominaCodClase
        '
        Me.pnlNominaCodClase.Controls.Add(Me.cmbNominaCodClase)
        Me.pnlNominaCodClase.Controls.Add(Me.Label82)
        Me.pnlNominaCodClase.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNominaCodClase.Enabled = false
        Me.pnlNominaCodClase.Location = New System.Drawing.Point(0, 70)
        Me.pnlNominaCodClase.Name = "pnlNominaCodClase"
        Me.pnlNominaCodClase.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlNominaCodClase.Size = New System.Drawing.Size(325, 35)
        Me.pnlNominaCodClase.TabIndex = 12
        Me.pnlNominaCodClase.Visible = false
        '
        'cmbNominaCodClase
        '
        Me.cmbNominaCodClase.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmbNominaCodClase.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbNominaCodClase.DropDownHeight = 150
        Me.cmbNominaCodClase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNominaCodClase.DropDownWidth = 220
        Me.cmbNominaCodClase.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cmbNominaCodClase.FormattingEnabled = true
        Me.cmbNominaCodClase.IntegralHeight = false
        Me.cmbNominaCodClase.ItemHeight = 14
        Me.cmbNominaCodClase.Location = New System.Drawing.Point(89, 7)
        Me.cmbNominaCodClase.MaxDropDownItems = 15
        Me.cmbNominaCodClase.MaxLength = 6
        Me.cmbNominaCodClase.Name = "cmbNominaCodClase"
        Me.cmbNominaCodClase.Size = New System.Drawing.Size(220, 20)
        Me.cmbNominaCodClase.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbNominaCodClase.TabIndex = 301
        '
        'Label82
        '
        Me.Label82.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label82.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label82.Location = New System.Drawing.Point(0, 7)
        Me.Label82.Name = "Label82"
        Me.Label82.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label82.Size = New System.Drawing.Size(89, 28)
        Me.Label82.TabIndex = 296
        Me.Label82.Text = "Cod clase"
        Me.Label82.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlNominaProcesar
        '
        Me.pnlNominaProcesar.Controls.Add(Me.swbNominaProcesar)
        Me.pnlNominaProcesar.Controls.Add(Me.Label83)
        Me.pnlNominaProcesar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNominaProcesar.Enabled = false
        Me.pnlNominaProcesar.Location = New System.Drawing.Point(0, 35)
        Me.pnlNominaProcesar.Name = "pnlNominaProcesar"
        Me.pnlNominaProcesar.Padding = New System.Windows.Forms.Padding(0, 7, 17, 0)
        Me.pnlNominaProcesar.Size = New System.Drawing.Size(325, 35)
        Me.pnlNominaProcesar.TabIndex = 11
        Me.pnlNominaProcesar.Visible = false
        '
        'swbNominaProcesar
        '
        '
        '
        '
        Me.swbNominaProcesar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swbNominaProcesar.Dock = System.Windows.Forms.DockStyle.Top
        Me.swbNominaProcesar.Location = New System.Drawing.Point(89, 7)
        Me.swbNominaProcesar.Name = "swbNominaProcesar"
        Me.swbNominaProcesar.Size = New System.Drawing.Size(219, 20)
        Me.swbNominaProcesar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swbNominaProcesar.TabIndex = 296
        '
        'Label83
        '
        Me.Label83.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label83.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label83.Location = New System.Drawing.Point(0, 7)
        Me.Label83.Name = "Label83"
        Me.Label83.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label83.Size = New System.Drawing.Size(89, 28)
        Me.Label83.TabIndex = 295
        Me.Label83.Text = "Procesar"
        Me.Label83.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlNominaReloj
        '
        Me.pnlNominaReloj.Controls.Add(Me.txtNominaReloj)
        Me.pnlNominaReloj.Controls.Add(Me.Label84)
        Me.pnlNominaReloj.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlNominaReloj.Enabled = false
        Me.pnlNominaReloj.Location = New System.Drawing.Point(0, 0)
        Me.pnlNominaReloj.Name = "pnlNominaReloj"
        Me.pnlNominaReloj.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlNominaReloj.Size = New System.Drawing.Size(325, 35)
        Me.pnlNominaReloj.TabIndex = 0
        Me.pnlNominaReloj.Visible = false
        '
        'txtNominaReloj
        '
        '
        '
        '
        Me.txtNominaReloj.Border.Class = "TextBoxBorder"
        Me.txtNominaReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtNominaReloj.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtNominaReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtNominaReloj.Location = New System.Drawing.Point(89, 7)
        Me.txtNominaReloj.MaxLength = 6
        Me.txtNominaReloj.Name = "txtNominaReloj"
        Me.txtNominaReloj.PreventEnterBeep = true
        Me.txtNominaReloj.Size = New System.Drawing.Size(220, 20)
        Me.txtNominaReloj.TabIndex = 293
        Me.txtNominaReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label84
        '
        Me.Label84.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label84.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label84.Location = New System.Drawing.Point(0, 7)
        Me.Label84.Name = "Label84"
        Me.Label84.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label84.Size = New System.Drawing.Size(89, 28)
        Me.Label84.TabIndex = 292
        Me.Label84.Text = "Reloj"
        Me.Label84.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'tabAgregaEmpleado
        '
        Me.tabAgregaEmpleado.Controls.Add(Me.pnlAgregaEmpleado)
        Me.tabAgregaEmpleado.Location = New System.Drawing.Point(4, 22)
        Me.tabAgregaEmpleado.Name = "tabAgregaEmpleado"
        Me.tabAgregaEmpleado.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAgregaEmpleado.Size = New System.Drawing.Size(667, 395)
        Me.tabAgregaEmpleado.TabIndex = 4
        Me.tabAgregaEmpleado.Text = "Empleado"
        Me.tabAgregaEmpleado.UseVisualStyleBackColor = true
        '
        'pnlAgregaEmpleado
        '
        Me.pnlAgregaEmpleado.Controls.Add(Me.pnlEmpleadoMiscelaneos)
        Me.pnlAgregaEmpleado.Controls.Add(Me.pnlEmpleadoTipoNomina)
        Me.pnlAgregaEmpleado.Controls.Add(Me.pnlEmpleadoReloj)
        Me.pnlAgregaEmpleado.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlAgregaEmpleado.Location = New System.Drawing.Point(3, 3)
        Me.pnlAgregaEmpleado.Name = "pnlAgregaEmpleado"
        Me.pnlAgregaEmpleado.Size = New System.Drawing.Size(325, 389)
        Me.pnlAgregaEmpleado.TabIndex = 8
        '
        'pnlEmpleadoMiscelaneos
        '
        Me.pnlEmpleadoMiscelaneos.Controls.Add(Me.swbEmpleadoMiscelaneos)
        Me.pnlEmpleadoMiscelaneos.Controls.Add(Me.Label16)
        Me.pnlEmpleadoMiscelaneos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEmpleadoMiscelaneos.Enabled = false
        Me.pnlEmpleadoMiscelaneos.Location = New System.Drawing.Point(0, 70)
        Me.pnlEmpleadoMiscelaneos.Name = "pnlEmpleadoMiscelaneos"
        Me.pnlEmpleadoMiscelaneos.Padding = New System.Windows.Forms.Padding(0, 7, 17, 0)
        Me.pnlEmpleadoMiscelaneos.Size = New System.Drawing.Size(325, 35)
        Me.pnlEmpleadoMiscelaneos.TabIndex = 20
        '
        'swbEmpleadoMiscelaneos
        '
        '
        '
        '
        Me.swbEmpleadoMiscelaneos.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.swbEmpleadoMiscelaneos.Dock = System.Windows.Forms.DockStyle.Top
        Me.swbEmpleadoMiscelaneos.Location = New System.Drawing.Point(89, 7)
        Me.swbEmpleadoMiscelaneos.Name = "swbEmpleadoMiscelaneos"
        Me.swbEmpleadoMiscelaneos.Size = New System.Drawing.Size(219, 20)
        Me.swbEmpleadoMiscelaneos.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.swbEmpleadoMiscelaneos.TabIndex = 296
        '
        'Label16
        '
        Me.Label16.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label16.Location = New System.Drawing.Point(0, 7)
        Me.Label16.Name = "Label16"
        Me.Label16.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label16.Size = New System.Drawing.Size(89, 28)
        Me.Label16.TabIndex = 295
        Me.Label16.Text = "Misceláneos"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlEmpleadoTipoNomina
        '
        Me.pnlEmpleadoTipoNomina.Controls.Add(Me.cmbEmpleadoTipoNomina)
        Me.pnlEmpleadoTipoNomina.Controls.Add(Me.Label15)
        Me.pnlEmpleadoTipoNomina.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEmpleadoTipoNomina.Location = New System.Drawing.Point(0, 35)
        Me.pnlEmpleadoTipoNomina.Name = "pnlEmpleadoTipoNomina"
        Me.pnlEmpleadoTipoNomina.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlEmpleadoTipoNomina.Size = New System.Drawing.Size(325, 35)
        Me.pnlEmpleadoTipoNomina.TabIndex = 19
        '
        'cmbEmpleadoTipoNomina
        '
        Me.cmbEmpleadoTipoNomina.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmbEmpleadoTipoNomina.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.cmbEmpleadoTipoNomina.DropDownHeight = 150
        Me.cmbEmpleadoTipoNomina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpleadoTipoNomina.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cmbEmpleadoTipoNomina.FormattingEnabled = true
        Me.cmbEmpleadoTipoNomina.IntegralHeight = false
        Me.cmbEmpleadoTipoNomina.ItemHeight = 14
        Me.cmbEmpleadoTipoNomina.Location = New System.Drawing.Point(89, 7)
        Me.cmbEmpleadoTipoNomina.MaxDropDownItems = 15
        Me.cmbEmpleadoTipoNomina.Name = "cmbEmpleadoTipoNomina"
        Me.cmbEmpleadoTipoNomina.Size = New System.Drawing.Size(220, 20)
        Me.cmbEmpleadoTipoNomina.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.cmbEmpleadoTipoNomina.TabIndex = 297
        '
        'Label15
        '
        Me.Label15.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label15.Location = New System.Drawing.Point(0, 7)
        Me.Label15.Name = "Label15"
        Me.Label15.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label15.Size = New System.Drawing.Size(89, 28)
        Me.Label15.TabIndex = 296
        Me.Label15.Text = "Tipo nómina"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pnlEmpleadoReloj
        '
        Me.pnlEmpleadoReloj.Controls.Add(Me.txtEmpleadoReloj)
        Me.pnlEmpleadoReloj.Controls.Add(Me.Label14)
        Me.pnlEmpleadoReloj.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlEmpleadoReloj.Location = New System.Drawing.Point(0, 0)
        Me.pnlEmpleadoReloj.Name = "pnlEmpleadoReloj"
        Me.pnlEmpleadoReloj.Padding = New System.Windows.Forms.Padding(0, 7, 0, 0)
        Me.pnlEmpleadoReloj.Size = New System.Drawing.Size(325, 35)
        Me.pnlEmpleadoReloj.TabIndex = 3
        '
        'txtEmpleadoReloj
        '
        '
        '
        '
        Me.txtEmpleadoReloj.Border.Class = "TextBoxBorder"
        Me.txtEmpleadoReloj.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.txtEmpleadoReloj.Dock = System.Windows.Forms.DockStyle.Left
        Me.txtEmpleadoReloj.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtEmpleadoReloj.Location = New System.Drawing.Point(89, 7)
        Me.txtEmpleadoReloj.MaxLength = 6
        Me.txtEmpleadoReloj.Name = "txtEmpleadoReloj"
        Me.txtEmpleadoReloj.PreventEnterBeep = true
        Me.txtEmpleadoReloj.Size = New System.Drawing.Size(220, 20)
        Me.txtEmpleadoReloj.TabIndex = 295
        Me.txtEmpleadoReloj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.Dock = System.Windows.Forms.DockStyle.Left
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label14.Location = New System.Drawing.Point(0, 7)
        Me.Label14.Name = "Label14"
        Me.Label14.Padding = New System.Windows.Forms.Padding(0, 5, 0, 0)
        Me.Label14.Size = New System.Drawing.Size(89, 28)
        Me.Label14.TabIndex = 294
        Me.Label14.Text = "Reloj"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmCrud
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 490)
        Me.ControlBox = false
        Me.Controls.Add(Me.tabCompleta)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAcept)
        Me.Name = "frmCrud"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registos"
        Me.tabCompleta.ResumeLayout(false)
        Me.tabPagHoras.ResumeLayout(false)
        Me.pnlHoras2.ResumeLayout(false)
        Me.pnlHoras.ResumeLayout(false)
        Me.pnlHorasCodHora.ResumeLayout(false)
        Me.pnlHorasSueldo.ResumeLayout(false)
        CType(Me.dbHorasSueldo,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlHorasFecha.ResumeLayout(false)
        CType(Me.dtiHorasFecha,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlHorasMonto.ResumeLayout(false)
        CType(Me.dbHorasMonto,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlHorasDescripcion.ResumeLayout(false)
        Me.pnlHorasConcepto.ResumeLayout(false)
        Me.pnlHorasPerDed.ResumeLayout(false)
        Me.pnlHorasReloj.ResumeLayout(false)
        Me.pnlHorasPeriodo.ResumeLayout(false)
        Me.pnlHorasAno.ResumeLayout(false)
        Me.tabPagMisc.ResumeLayout(false)
        Me.pnlAjustes.ResumeLayout(false)
        Me.pnlAjustesSaldo.ResumeLayout(false)
        CType(Me.dbAjustesSaldo,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlAjustesSueldo.ResumeLayout(false)
        CType(Me.dbAjustesSueldo,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlAjustesFecha.ResumeLayout(false)
        CType(Me.dtiAjustesFecha,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlAjustesMonto.ResumeLayout(false)
        CType(Me.dbAjustesMonto,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlAjustesDescripcion.ResumeLayout(false)
        Me.pnlAjustesConcepto.ResumeLayout(false)
        Me.pnlAjustesPerDed.ResumeLayout(false)
        Me.pnlAjustesReloj.ResumeLayout(false)
        Me.pnlAjustesPeriodo.ResumeLayout(false)
        Me.pnlAjustesAno.ResumeLayout(false)
        Me.tabPagNominaPro.ResumeLayout(false)
        Me.pnlNomina2.ResumeLayout(false)
        Me.pnlNominaFiniquito.ResumeLayout(false)
        Me.pnlNominaFaltas.ResumeLayout(false)
        CType(Me.intNominaFaltas,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlNominaIncapacidad.ResumeLayout(false)
        CType(Me.intNominaIncapacidad,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlNominaPrivacDias.ResumeLayout(false)
        CType(Me.dbNominaPrivacDias,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlNominaPrivacPorc.ResumeLayout(false)
        CType(Me.intNominaPrivacPorc,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlNominaCobroSegViv.ResumeLayout(false)
        Me.pnlNomina.ResumeLayout(false)
        Me.pnlNominaInicioCredito.ResumeLayout(false)
        CType(Me.dtiNominaInicioCredito,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlNominaCuotaCredito.ResumeLayout(false)
        CType(Me.dbNominaCuotaCredito,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlNominaTipoCredito.ResumeLayout(false)
        Me.pnlNominaInfonavitCredito.ResumeLayout(false)
        Me.pnlNominaBaja.ResumeLayout(false)
        CType(Me.dtiNominaBaja,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlNominaSindicalizado.ResumeLayout(false)
        Me.pnlNominaIntegrado.ResumeLayout(false)
        CType(Me.dbNominaIntegrado,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlNominaSactual.ResumeLayout(false)
        CType(Me.dbNominaSactual,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlNominaCodClase.ResumeLayout(false)
        Me.pnlNominaProcesar.ResumeLayout(false)
        Me.pnlNominaReloj.ResumeLayout(false)
        Me.tabAgregaEmpleado.ResumeLayout(false)
        Me.pnlAgregaEmpleado.ResumeLayout(false)
        Me.pnlEmpleadoMiscelaneos.ResumeLayout(false)
        Me.pnlEmpleadoTipoNomina.ResumeLayout(false)
        Me.pnlEmpleadoReloj.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents btnAcept As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents tabCompleta As System.Windows.Forms.TabControl
    Friend WithEvents tabPagHoras As System.Windows.Forms.TabPage
    Friend WithEvents tabPagMisc As System.Windows.Forms.TabPage
    Friend WithEvents pnlHoras2 As System.Windows.Forms.Panel
    Friend WithEvents pnlBase As System.Windows.Forms.Panel
    Friend WithEvents pnlHoras As System.Windows.Forms.Panel
    Friend WithEvents pnlHorasMonto As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pnlHorasDescripcion As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pnlHorasConcepto As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents pnlHorasPerDed As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlHorasReloj As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents pnlHorasPeriodo As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pnlHorasAno As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tabPagNominaPro As System.Windows.Forms.TabPage
    Friend WithEvents pnlAjustes2 As System.Windows.Forms.Panel
    Friend WithEvents pnlAjustes As System.Windows.Forms.Panel
    Friend WithEvents pnlAjustesMonto As System.Windows.Forms.Panel
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents pnlAjustesDescripcion As System.Windows.Forms.Panel
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents pnlAjustesConcepto As System.Windows.Forms.Panel
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents pnlAjustesPerDed As System.Windows.Forms.Panel
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents pnlAjustesReloj As System.Windows.Forms.Panel
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents pnlAjustesPeriodo As System.Windows.Forms.Panel
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents pnlAjustesAno As System.Windows.Forms.Panel
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents pnlNomina2 As System.Windows.Forms.Panel
    Friend WithEvents pnlNominaFaltas As System.Windows.Forms.Panel
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents pnlNominaIncapacidad As System.Windows.Forms.Panel
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents pnlNominaPrivacDias As System.Windows.Forms.Panel
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents pnlNominaPrivacPorc As System.Windows.Forms.Panel
    Friend WithEvents Label91 As System.Windows.Forms.Label
    Friend WithEvents pnlNominaCobroSegViv As System.Windows.Forms.Panel
    Friend WithEvents Label92 As System.Windows.Forms.Label
    Friend WithEvents pnlNominaSeparador As System.Windows.Forms.Panel
    Friend WithEvents pnlNomina As System.Windows.Forms.Panel
    Friend WithEvents pnlNominaCuotaCredito As System.Windows.Forms.Panel
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents pnlNominaTipoCredito As System.Windows.Forms.Panel
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents pnlNominaInfonavitCredito As System.Windows.Forms.Panel
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents pnlNominaBaja As System.Windows.Forms.Panel
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents pnlNominaSindicalizado As System.Windows.Forms.Panel
    Friend WithEvents Label79 As System.Windows.Forms.Label
    Friend WithEvents pnlNominaIntegrado As System.Windows.Forms.Panel
    Friend WithEvents Label80 As System.Windows.Forms.Label
    Friend WithEvents pnlNominaSactual As System.Windows.Forms.Panel
    Friend WithEvents Label81 As System.Windows.Forms.Label
    Friend WithEvents pnlNominaCodClase As System.Windows.Forms.Panel
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents pnlNominaProcesar As System.Windows.Forms.Panel
    Friend WithEvents Label83 As System.Windows.Forms.Label
    Friend WithEvents pnlNominaReloj As System.Windows.Forms.Panel
    Friend WithEvents Label84 As System.Windows.Forms.Label
    Friend WithEvents dbHorasMonto As DevComponents.Editors.DoubleInput
    Friend WithEvents txtHorasDescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtHorasPerDed As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtHorasReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtHorasPeriodo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtHorasAno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents dbAjustesMonto As DevComponents.Editors.DoubleInput
    Friend WithEvents txtAjustesDescripcion As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtAjustesPerDed As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtAjustesReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtAjustesPeriodo As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents txtAjustesAno As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents dbNominaPrivacDias As DevComponents.Editors.DoubleInput
    Friend WithEvents intNominaPrivacPorc As DevComponents.Editors.IntegerInput
    Friend WithEvents swbNominaCobroSegViv As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents dbNominaCuotaCredito As DevComponents.Editors.DoubleInput
    Friend WithEvents cmbNominaTipoCredito As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents txtNominaInfonavitCredito As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents dtiNominaBaja As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents swbNominaSindicalizado As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents dbNominaIntegrado As DevComponents.Editors.DoubleInput
    Friend WithEvents dbNominaSactual As DevComponents.Editors.DoubleInput
    Friend WithEvents swbNominaProcesar As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents txtNominaReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents pnlHorasSueldo As System.Windows.Forms.Panel
    Friend WithEvents dbHorasSueldo As DevComponents.Editors.DoubleInput
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents pnlHorasFecha As System.Windows.Forms.Panel
    Friend WithEvents dtiHorasFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents pnlHorasCodHora As System.Windows.Forms.Panel
    Friend WithEvents txtHorasCodHora As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents pnlAjustesSaldo As System.Windows.Forms.Panel
    Friend WithEvents dbAjustesSaldo As DevComponents.Editors.DoubleInput
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents pnlAjustesSueldo As System.Windows.Forms.Panel
    Friend WithEvents dbAjustesSueldo As DevComponents.Editors.DoubleInput
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents pnlAjustesFecha As System.Windows.Forms.Panel
    Friend WithEvents dtiAjustesFecha As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents pnlNominaInicioCredito As System.Windows.Forms.Panel
    Friend WithEvents dtiNominaInicioCredito As DevComponents.Editors.DateTimeAdv.DateTimeInput
    Friend WithEvents Label93 As System.Windows.Forms.Label
    Friend WithEvents cmbHorasConcepto As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbAjustesConcepto As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents cmbNominaCodClase As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents pnlNominaFiniquito As System.Windows.Forms.Panel
    Friend WithEvents swbNominaFiniquito As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents intNominaFaltas As DevComponents.Editors.IntegerInput
    Friend WithEvents intNominaIncapacidad As DevComponents.Editors.IntegerInput
    Friend WithEvents tabAgregaEmpleado As System.Windows.Forms.TabPage
    Friend WithEvents pnlAgregaEmpleado As System.Windows.Forms.Panel
    Friend WithEvents pnlEmpleadoMiscelaneos As System.Windows.Forms.Panel
    Friend WithEvents swbEmpleadoMiscelaneos As DevComponents.DotNetBar.Controls.SwitchButton
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents pnlEmpleadoTipoNomina As System.Windows.Forms.Panel
    Friend WithEvents cmbEmpleadoTipoNomina As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents pnlEmpleadoReloj As System.Windows.Forms.Panel
    Friend WithEvents txtEmpleadoReloj As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
