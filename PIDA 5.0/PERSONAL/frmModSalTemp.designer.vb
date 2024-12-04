<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModSalTemp
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModSalTemp))
        Me.ReflectionLabel1 = New DevComponents.DotNetBar.Controls.ReflectionLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EmpNav = New System.Windows.Forms.GroupBox()
        Me.btnMultiforma = New DevComponents.DotNetBar.ButtonX()
        Me.btnCerrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnReporte = New DevComponents.DotNetBar.ButtonX()
        Me.btnBorrar = New DevComponents.DotNetBar.ButtonX()
        Me.btnParametros = New DevComponents.DotNetBar.ButtonX()
        Me.btnAplicar = New DevComponents.DotNetBar.ButtonX()
        Me.btnEditar = New DevComponents.DotNetBar.ButtonX()
        Me.btnNuevo = New DevComponents.DotNetBar.ButtonX()
        Me.btnMostrarInformacion = New DevComponents.DotNetBar.ButtonX()
        Me.pbAplicar = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.picImagen = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkMultiforma = New DevComponents.DotNetBar.Controls.CheckBoxX()
        Me.dgModSal = New System.Windows.Forms.DataGridView()
        Me.Ok = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.Comp = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RELOJ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIPO_MOD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cambio_de = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NIVEL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CAMBIO_A = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pro_var = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FACT_INT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.INTEGRADO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FECHA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOTAS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnCargarExcel = New DevComponents.DotNetBar.ButtonX()
        Me.EmpNav.SuspendLayout()
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgModSal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReflectionLabel1
        '
        '
        '
        '
        Me.ReflectionLabel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ReflectionLabel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReflectionLabel1.Location = New System.Drawing.Point(45, 12)
        Me.ReflectionLabel1.Name = "ReflectionLabel1"
        Me.ReflectionLabel1.Size = New System.Drawing.Size(364, 40)
        Me.ReflectionLabel1.TabIndex = 109
        Me.ReflectionLabel1.Text = "<font color=""#1F497D""><b>MODIFICACIONES DE SUELDO</b></font>"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkRed
        Me.Label1.Location = New System.Drawing.Point(9, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(732, 13)
        Me.Label1.TabIndex = 112
        Me.Label1.Text = "Pantalla de captura de modificaciones de sueldo. Solo se reflejará en el archivo " & _
    "de empleados cuando se apliquen los cambios."
        '
        'EmpNav
        '
        Me.EmpNav.Controls.Add(Me.btnCargarExcel)
        Me.EmpNav.Controls.Add(Me.btnMultiforma)
        Me.EmpNav.Controls.Add(Me.btnCerrar)
        Me.EmpNav.Controls.Add(Me.btnReporte)
        Me.EmpNav.Controls.Add(Me.btnBorrar)
        Me.EmpNav.Controls.Add(Me.btnParametros)
        Me.EmpNav.Controls.Add(Me.btnAplicar)
        Me.EmpNav.Controls.Add(Me.btnEditar)
        Me.EmpNav.Controls.Add(Me.btnNuevo)
        Me.EmpNav.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.EmpNav.Location = New System.Drawing.Point(0, 564)
        Me.EmpNav.Name = "EmpNav"
        Me.EmpNav.Padding = New System.Windows.Forms.Padding(0)
        Me.EmpNav.Size = New System.Drawing.Size(1156, 67)
        Me.EmpNav.TabIndex = 1
        Me.EmpNav.TabStop = False
        '
        'btnMultiforma
        '
        Me.btnMultiforma.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnMultiforma.CausesValidation = False
        Me.btnMultiforma.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnMultiforma.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMultiforma.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnMultiforma.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnMultiforma.Location = New System.Drawing.Point(128, 15)
        Me.btnMultiforma.Name = "btnMultiforma"
        Me.btnMultiforma.Size = New System.Drawing.Size(110, 43)
        Me.btnMultiforma.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnMultiforma.TabIndex = 59
        Me.btnMultiforma.Text = "Multiforma seleccionados"
        '
        'btnCerrar
        '
        Me.btnCerrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCerrar.CausesValidation = False
        Me.btnCerrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = Global.PIDA.My.Resources.Resources.Cerrar16
        Me.btnCerrar.ImageFixedSize = New System.Drawing.Size(16, 16)
        Me.btnCerrar.Location = New System.Drawing.Point(749, 16)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(81, 43)
        Me.btnCerrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCerrar.TabIndex = 58
        Me.btnCerrar.Text = "Salir"
        '
        'btnReporte
        '
        Me.btnReporte.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnReporte.CausesValidation = False
        Me.btnReporte.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReporte.Image = Global.PIDA.My.Resources.Resources.Reporte16
        Me.btnReporte.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnReporte.Location = New System.Drawing.Point(244, 15)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(78, 43)
        Me.btnReporte.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnReporte.TabIndex = 57
        Me.btnReporte.Text = "Reporte"
        '
        'btnBorrar
        '
        Me.btnBorrar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnBorrar.CausesValidation = False
        Me.btnBorrar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnBorrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = Global.PIDA.My.Resources.Resources.DeleteRec
        Me.btnBorrar.Location = New System.Drawing.Point(665, 16)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(78, 43)
        Me.btnBorrar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnBorrar.TabIndex = 56
        Me.btnBorrar.Text = "Borrar"
        '
        'btnParametros
        '
        Me.btnParametros.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnParametros.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnParametros.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnParametros.Image = Global.PIDA.My.Resources.Resources.CambiosMasivos16
        Me.btnParametros.Location = New System.Drawing.Point(328, 16)
        Me.btnParametros.Name = "btnParametros"
        Me.btnParametros.Size = New System.Drawing.Size(78, 43)
        Me.btnParametros.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnParametros.TabIndex = 26
        Me.btnParametros.Text = "Agregar grupo"
        '
        'btnAplicar
        '
        Me.btnAplicar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnAplicar.CausesValidation = False
        Me.btnAplicar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnAplicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAplicar.Image = Global.PIDA.My.Resources.Resources.Ok16
        Me.btnAplicar.Location = New System.Drawing.Point(12, 15)
        Me.btnAplicar.Name = "btnAplicar"
        Me.btnAplicar.Size = New System.Drawing.Size(110, 43)
        Me.btnAplicar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnAplicar.TabIndex = 51
        Me.btnAplicar.Text = "Aplicar seleccionados"
        Me.btnAplicar.Tooltip = "Buscar"
        '
        'btnEditar
        '
        Me.btnEditar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnEditar.CausesValidation = False
        Me.btnEditar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnEditar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditar.Image = Global.PIDA.My.Resources.Resources.Edit
        Me.btnEditar.Location = New System.Drawing.Point(581, 16)
        Me.btnEditar.Name = "btnEditar"
        Me.btnEditar.Size = New System.Drawing.Size(78, 43)
        Me.btnEditar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnEditar.TabIndex = 53
        Me.btnEditar.Text = "Editar"
        Me.btnEditar.Visible = False
        '
        'btnNuevo
        '
        Me.btnNuevo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnNuevo.CausesValidation = False
        Me.btnNuevo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnNuevo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNuevo.Image = Global.PIDA.My.Resources.Resources.NewRecord
        Me.btnNuevo.Location = New System.Drawing.Point(497, 16)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(78, 43)
        Me.btnNuevo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnNuevo.TabIndex = 52
        Me.btnNuevo.Text = "Agregar"
        '
        'btnMostrarInformacion
        '
        Me.btnMostrarInformacion.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnMostrarInformacion.CausesValidation = False
        Me.btnMostrarInformacion.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnMostrarInformacion.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnMostrarInformacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMostrarInformacion.Image = Global.PIDA.My.Resources.Resources.refresh16
        Me.btnMostrarInformacion.ImageFixedSize = New System.Drawing.Size(18, 18)
        Me.btnMostrarInformacion.Location = New System.Drawing.Point(1119, 0)
        Me.btnMostrarInformacion.Name = "btnMostrarInformacion"
        Me.btnMostrarInformacion.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(20)
        Me.btnMostrarInformacion.Shortcuts.Add(DevComponents.DotNetBar.eShortcut.F5)
        Me.btnMostrarInformacion.Size = New System.Drawing.Size(37, 70)
        Me.btnMostrarInformacion.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnMostrarInformacion.TabIndex = 2
        '
        'pbAplicar
        '
        '
        '
        '
        Me.pbAplicar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.pbAplicar.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center
        Me.pbAplicar.BackgroundStyle.TextColor = System.Drawing.SystemColors.WindowText
        Me.pbAplicar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbAplicar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pbAplicar.Location = New System.Drawing.Point(0, 0)
        Me.pbAplicar.Name = "pbAplicar"
        Me.pbAplicar.Size = New System.Drawing.Size(1156, 26)
        Me.pbAplicar.TabIndex = 114
        Me.pbAplicar.Text = "Aplicar"
        Me.pbAplicar.TextVisible = True
        Me.pbAplicar.Value = 20
        Me.pbAplicar.Visible = False
        '
        'picImagen
        '
        Me.picImagen.Image = Global.PIDA.My.Resources.Resources.ModificacionesSueldo24
        Me.picImagen.Location = New System.Drawing.Point(12, 12)
        Me.picImagen.Name = "picImagen"
        Me.picImagen.Size = New System.Drawing.Size(27, 26)
        Me.picImagen.TabIndex = 110
        Me.picImagen.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.picImagen)
        Me.Panel1.Controls.Add(Me.btnMostrarInformacion)
        Me.Panel1.Controls.Add(Me.ReflectionLabel1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1156, 96)
        Me.Panel1.TabIndex = 115
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.pbAplicar)
        Me.Panel2.Controls.Add(Me.chkMultiforma)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 70)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1156, 26)
        Me.Panel2.TabIndex = 115
        '
        'chkMultiforma
        '
        '
        '
        '
        Me.chkMultiforma.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.chkMultiforma.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.chkMultiforma.CheckBoxImageIndeterminate = Global.PIDA.My.Resources.Resources.CancelX
        Me.chkMultiforma.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.CancelX
        Me.chkMultiforma.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Right
        Me.chkMultiforma.Location = New System.Drawing.Point(12, 1)
        Me.chkMultiforma.Name = "chkMultiforma"
        Me.chkMultiforma.Size = New System.Drawing.Size(50, 23)
        Me.chkMultiforma.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.chkMultiforma.TabIndex = 1
        Me.chkMultiforma.Text = "Todo"
        '
        'dgModSal
        '
        Me.dgModSal.AllowUserToAddRows = False
        Me.dgModSal.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgModSal.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgModSal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgModSal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ok, Me.Comp, Me.RELOJ, Me.nombre, Me.TIPO_MOD, Me.Cambio_de, Me.NIVEL, Me.CAMBIO_A, Me.pro_var, Me.FACT_INT, Me.INTEGRADO, Me.FECHA, Me.NOTAS})
        Me.dgModSal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgModSal.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgModSal.Location = New System.Drawing.Point(0, 96)
        Me.dgModSal.MultiSelect = False
        Me.dgModSal.Name = "dgModSal"
        Me.dgModSal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgModSal.Size = New System.Drawing.Size(1156, 468)
        Me.dgModSal.TabIndex = 116
        '
        'Ok
        '
        Me.Ok.CheckBoxImageChecked = Global.PIDA.My.Resources.Resources.Ok16
        Me.Ok.CheckBoxImageIndeterminate = Global.PIDA.My.Resources.Resources.CancelX
        Me.Ok.CheckBoxImageUnChecked = Global.PIDA.My.Resources.Resources.CancelX
        Me.Ok.Checked = True
        Me.Ok.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.Ok.CheckValue = "N"
        Me.Ok.CheckValueChecked = "1"
        Me.Ok.CheckValueIndeterminate = ""
        Me.Ok.CheckValueUnchecked = "0"
        Me.Ok.DataPropertyName = "INCLUIR"
        Me.Ok.HeaderText = "OK"
        Me.Ok.Name = "Ok"
        Me.Ok.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Ok.ThreeState = True
        Me.Ok.Width = 25
        '
        'Comp
        '
        Me.Comp.DataPropertyName = "comp."
        Me.Comp.HeaderText = "COMP."
        Me.Comp.Name = "Comp"
        Me.Comp.Width = 45
        '
        'RELOJ
        '
        Me.RELOJ.DataPropertyName = "RELOJ"
        Me.RELOJ.HeaderText = "RELOJ"
        Me.RELOJ.Name = "RELOJ"
        Me.RELOJ.Width = 50
        '
        'nombre
        '
        Me.nombre.DataPropertyName = "nombre"
        Me.nombre.HeaderText = "NOMBRE"
        Me.nombre.Name = "nombre"
        Me.nombre.Width = 120
        '
        'TIPO_MOD
        '
        Me.TIPO_MOD.DataPropertyName = "tipo mod."
        Me.TIPO_MOD.HeaderText = "TIPO MOD."
        Me.TIPO_MOD.Name = "TIPO_MOD"
        Me.TIPO_MOD.Width = 40
        '
        'Cambio_de
        '
        Me.Cambio_de.DataPropertyName = "cambio de"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.Cambio_de.DefaultCellStyle = DataGridViewCellStyle2
        Me.Cambio_de.HeaderText = "CAMBIO DE"
        Me.Cambio_de.Name = "Cambio_de"
        Me.Cambio_de.Width = 65
        '
        'NIVEL
        '
        Me.NIVEL.DataPropertyName = "nivel"
        Me.NIVEL.HeaderText = "NIVEL"
        Me.NIVEL.Name = "NIVEL"
        Me.NIVEL.Width = 40
        '
        'CAMBIO_A
        '
        Me.CAMBIO_A.DataPropertyName = "cambio a"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.CAMBIO_A.DefaultCellStyle = DataGridViewCellStyle3
        Me.CAMBIO_A.HeaderText = "CAMBIO A"
        Me.CAMBIO_A.Name = "CAMBIO_A"
        Me.CAMBIO_A.Width = 65
        '
        'pro_var
        '
        Me.pro_var.DataPropertyName = "PROM.VAR."
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.pro_var.DefaultCellStyle = DataGridViewCellStyle4
        Me.pro_var.HeaderText = "PROM. VAR."
        Me.pro_var.Name = "pro_var"
        Me.pro_var.Width = 50
        '
        'FACT_INT
        '
        Me.FACT_INT.DataPropertyName = "FACT.INT."
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N4"
        DataGridViewCellStyle5.NullValue = "0"
        Me.FACT_INT.DefaultCellStyle = DataGridViewCellStyle5
        Me.FACT_INT.HeaderText = "FACT. INT."
        Me.FACT_INT.Name = "FACT_INT"
        Me.FACT_INT.Width = 50
        '
        'INTEGRADO
        '
        Me.INTEGRADO.DataPropertyName = "INTEGRADO"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "C2"
        DataGridViewCellStyle6.NullValue = "0"
        Me.INTEGRADO.DefaultCellStyle = DataGridViewCellStyle6
        Me.INTEGRADO.HeaderText = "SAL. INT."
        Me.INTEGRADO.Name = "INTEGRADO"
        Me.INTEGRADO.Width = 65
        '
        'FECHA
        '
        Me.FECHA.DataPropertyName = "FECHA"
        Me.FECHA.HeaderText = "FECHA"
        Me.FECHA.Name = "FECHA"
        Me.FECHA.Width = 75
        '
        'NOTAS
        '
        Me.NOTAS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NOTAS.DataPropertyName = "NOTAS"
        Me.NOTAS.HeaderText = "NOTAS"
        Me.NOTAS.Name = "NOTAS"
        '
        'btnCargarExcel
        '
        Me.btnCargarExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.btnCargarExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.btnCargarExcel.Image = Global.PIDA.My.Resources.Resources.AddList32
        Me.btnCargarExcel.Location = New System.Drawing.Point(412, 16)
        Me.btnCargarExcel.Name = "btnCargarExcel"
        Me.btnCargarExcel.Size = New System.Drawing.Size(79, 43)
        Me.btnCargarExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.btnCargarExcel.TabIndex = 61
        Me.btnCargarExcel.Text = "Cargar Excel"
        '
        'frmModSalTemp
        '
        Me.AcceptButton = Me.btnNuevo
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(1156, 631)
        Me.Controls.Add(Me.dgModSal)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.EmpNav)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmModSalTemp"
        Me.Text = "Cambios de sueldo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.EmpNav.ResumeLayout(False)
        CType(Me.picImagen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgModSal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReflectionLabel1 As DevComponents.DotNetBar.Controls.ReflectionLabel
    Friend WithEvents picImagen As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EmpNav As System.Windows.Forms.GroupBox
    Friend WithEvents btnCerrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnReporte As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnBorrar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnParametros As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnAplicar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnEditar As DevComponents.DotNetBar.ButtonX
    Friend WithEvents btnNuevo As DevComponents.DotNetBar.ButtonX
    Friend WithEvents pbAplicar As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents btnMostrarInformacion As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgModSal As System.Windows.Forms.DataGridView
    Friend WithEvents btnMultiforma As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Ok As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents Comp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RELOJ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIPO_MOD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cambio_de As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NIVEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CAMBIO_A As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pro_var As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FACT_INT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents INTEGRADO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FECHA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOTAS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents chkMultiforma As DevComponents.DotNetBar.Controls.CheckBoxX
    Friend WithEvents btnCargarExcel As DevComponents.DotNetBar.ButtonX
End Class
