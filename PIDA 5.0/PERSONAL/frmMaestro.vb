Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Imports OfficeOpenXml

Public Class frmMaestro

    '---- AO 2023-12-06: Prueba de GIT

    '==LIDER            10Dic2021       Ernesto
    Dim dtLider As New DataTable

    'Para los perfiles a detalle        17/dic/2020
    Dim perfilesDetallados As Boolean

    Dim encabezado_fechas As String = ""
    Dim encabezado_nombre As String = ""

    Dim nReingresos As Integer

    Dim CambiaFoto As Boolean = False
    Dim tbVac As Boolean
    Dim tbGral As Boolean
    Dim PermisoEdicion As Boolean
    ' Variables para MAESTRO
    Dim Nuevo As Boolean
    Dim Editar As Boolean

    Dim DarDeBaja As Boolean
    Dim DarReingreso As Boolean

    Public Cargando As Boolean = False

    ' Bandera de ver historial de sueldos, de acuerdo a perfil
    Dim AccesoHistorial As Boolean

    ' Variables para FAMILIARES
    Dim AgregarFam As Boolean     'Nuevo familiar?
    Dim EditarFam As Boolean    'Editar familiar?
    Dim FamSelec As Integer      'Familiar seleccionado
    Dim dtCambiosFamilia As New DataTable
    Dim IDFamiliares As String
    Dim FamAnt As String

    ' Variables para ESCOLARIDAD
    Dim AgregarEsc As Boolean     'Nueva escolaridad?
    Dim EditarEsc As Boolean    'Editar escolaridad?
    Dim EscSelec As Integer      'Escolaridad seleccionada

    Dim dtCambiosEscolaridad As New DataTable
    Dim IDEscolaridad As String
    Dim EscAnt As String


    ' Variables para AUXILIARES
    Dim AgregarAux As Boolean     'Nueva auxiliares?
    Dim EditarAux As Boolean    'Editar auxiliares?
    Dim AuxSelec As Integer      'Auxiliar seleccionado

    Dim dtCambiosAuxiliares As New DataTable
    Dim IDAuxiliares As String
    Dim AuxAnt As String
    Dim _finicio_cred_infonavit As String = ""

    'Variables para VACACIONES

    ' Tablas
    Dim dtTemp As New DataTable
    Dim dtPersonal As New DataTable
    Dim dtCias As New DataTable
    Dim dtDeptos As New DataTable
    Dim dtSuper As New DataTable
    Dim dtClerk As New DataTable
    Dim dtSindicalizado As New DataTable
    Dim dtTipoPeriodo As New DataTable
    Dim dtTurnos As New DataTable
    Dim dtTipos As New DataTable
    Dim dtPuestos As New DataTable
    Dim dtPlantas As New DataTable
    Dim dtAreas As New DataTable

    Dim dtClases As New DataTable
    Dim dtHorarios As New DataTable

    Dim dtBancos As New DataTable
    Dim dtCodPago As New DataTable
    Dim dtCategoria As New DataTable
    Dim dtCelula As New DataTable
    Dim dtHyperion As New DataTable
    Dim dtColonia As New DataTable
    Dim dtNivel As New DataTable
    Dim dtCiudad As New DataTable
    Dim dtEstado As New DataTable
    Dim dtCivil As New DataTable
    Dim dtFamilia As New DataTable
    Dim dtFamiliares As New DataTable
    Dim dtEscuelas As New DataTable
    Dim dtEscolaridad As New DataTable
    Dim dtAuxiliares As New DataTable
    Dim dtAuxiliaresValidos As New DataTable
    Dim dtDetalleAuxiliares As New DataTable
    Dim dtVacaciones As New DataTable
    Dim dtBajaInterno As New DataTable
    Dim dtBajaIMSS As New DataTable
    Dim dtSubBaja As New DataTable
    Dim dtModSal As New DataTable
    Dim dtCambios As New DataTable
    Dim dtCampos As New DataTable
    Dim dtUsuarios As New DataTable
    Dim dtTipoMovs As New DataTable
    Dim dtAuxiliaresSeleccionados As New DataTable
    Dim dtValidos As New DataTable
    Dim dtReportes As New DataTable
    Dim dtBeneficiarios As New DataTable
    Dim dtCCostos As New DataTable
    Dim dtRegFiscSAT As New DataTable

    ' VARIABLES PARA REINGRESO
    Dim dtReingreso As New DataTable
    Dim AltaAnt As Date, BajaAnt As Date

    Dim NombreReporte As String = ""

    'MCR 18/NOV/2015
    'Cambios para SuccessFactor, verificar si la compañía es editable
    Dim CiaEditable As Boolean
    Dim PuestoActivo As Boolean

    '== Tipo de periodo del empleado 11junio2021        Ernesto
    Dim tipo_per As String = ""

    '== Filtro de archivos para carga de documentos desde personal
    Dim FiltroArchivos As String = "Todos los archivos (*.*)|*.*"

    ' # -----VERSION NUEVA
    '#Region "Infonavit"
    '    Private Sub RefrescaInfonavit(ByVal rl As String)
    '        Try
    '            cmbTipoMovInfonavit.SelectedValue = ""  ' MCR20210517

    '            '== Modificado para incluir cobro_segviv            Ernesto         31-marzo-2023
    '            Dim dtInfonavit As DataTable = sqlExecute("select infonavit, tipo_cred, cuota_cred, inicio_cre,fecha_aplicacion,cobro_segv from infonavit where reloj = '" & _
    '                                                   rl & "' and isnull(activo,0)=1", "PERSONAL")

    '            BorraInfonavit = False  'MCR 20210629
    '            If dtInfonavit.Rows.Count > 0 Then

    '                '== Se almacena el valor del cobro_serviv del registro activo           Ernesto         31-marzo-2023
    '                cobro_segv = dtInfonavit.Rows(0)("cobro_segv")

    '                txtNumeroCredito.Text = IIf(IsDBNull(dtInfonavit.Rows(0)("infonavit")), "SIN CREDITO ACTIVO", dtInfonavit.Rows(0)("infonavit"))
    '                If txtNumeroCredito.Text = "SIN CREDITO ACTIVO" Then
    '                    '  panelInfonavit.Visible = False
    '                    cmbTipoInfonavit.SelectedValue = 0
    '                    txtFactorDeDescuentoInfonavit.Text = 0
    '                    dtpFechaInicioCreditoInfonavit.Value = Nothing
    '                    'MCR 20210407
    '                    dtpFechaAplicacion.Value = Now

    '                    btnAgregarSuspenderCreditoInfonavit.Text = "Agregar crédito"

    '                    '--No mostrar controles
    '                    'Label3.Visible = False
    '                    'Label17.Visible = False
    '                    'Label16.Visible = False
    '                    'cmbTipoInfonavit.Visible = False
    '                    'txtFactorDeDescuentoInfonavit.Visible = False
    '                    'dtpFechaInicioCreditoInfonavit.Visible = False
    '                    ''MCR 20210407
    '                    'dtpFechaAplicacion.Visible = False


    '                    'MCR 20210519
    '                    pnlInfoTipoCred.Enabled = False
    '                    pnlInfoFactor.Enabled = False
    '                    pnlInfoFInicio.Enabled = False
    '                    'MCR 20210407
    '                    pnlFechaAplicacion.Enabled = False
    '                    '***** MCR 20210519

    '                Else
    '                    '  panelInfonavit.Visible = True
    '                    cmbTipoInfonavit.SelectedValue = IIf(IsDBNull(dtInfonavit.Rows(0)("tipo_cred")), "0", dtInfonavit.Rows(0)("tipo_cred"))
    '                    txtFactorDeDescuentoInfonavit.Text = IIf(IsDBNull(dtInfonavit.Rows(0)("cuota_cred")), "", Double.Parse(dtInfonavit.Rows(0)("cuota_cred")).ToString("0.0000"))
    '                    dtpFechaInicioCreditoInfonavit.Value = IIf(IsDBNull(dtInfonavit.Rows(0)("inicio_cre")), Nothing, dtInfonavit.Rows(0)("inicio_cre"))
    '                    'MCR 20210407
    '                    dtpFechaAplicacion.Value = IIf(IsDBNull(dtInfonavit.Rows(0)("fecha_aplicacion")), Now, dtInfonavit.Rows(0)("fecha_aplicacion"))

    '                    btnAgregarSuspenderCreditoInfonavit.Text = "Suspender crédito"

    '                    'cmbTipoInfonavit.Visible = True
    '                    'txtFactorDeDescuentoInfonavit.Visible = True
    '                    'dtpFechaInicioCreditoInfonavit.Visible = True
    '                    ''MCR 20210407
    '                    'dtpFechaAplicacion.Visible = True

    '                    'MCR 20210519
    '                    pnlInfoTipoCred.Enabled = True
    '                    pnlInfoFactor.Enabled = True
    '                    pnlInfoFInicio.Enabled = True
    '                    'MCR 20210407
    '                    pnlFechaAplicacion.Enabled = True
    '                    '***** MCR 20210519

    '                End If
    '            Else
    '                txtNumeroCredito.Text = "SIN CREDITO ACTIVO"
    '                cmbTipoInfonavit.SelectedValue = 0
    '                txtFactorDeDescuentoInfonavit.Text = 0
    '                dtpFechaInicioCreditoInfonavit.Value = Nothing
    '                'MCR 20210407
    '                dtpFechaAplicacion.Value = Now

    '                btnAgregarSuspenderCreditoInfonavit.Text = "Agregar crédito"

    '                'cmbTipoInfonavit.Visible = False
    '                'txtFactorDeDescuentoInfonavit.Visible = False
    '                'dtpFechaInicioCreditoInfonavit.Visible = False
    '                ''MCR 20210407
    '                'dtpFechaAplicacion.Visible = False

    '                'MCR 20210519
    '                pnlInfoTipoCred.Enabled = False
    '                pnlInfoFactor.Enabled = False
    '                pnlInfoFInicio.Enabled = False
    '                'MCR 20210407
    '                pnlFechaAplicacion.Enabled = False
    '                '***** MCR 20210519

    '            End If

    '            'MCR 20210519
    '            pnlInfoTipoCred.Visible = False
    '            pnlInfoFactor.Visible = False
    '            pnlInfoFInicio.Visible = False
    '            pnlFechaAplicacion.Visible = False
    '            pnlInfoFSuspension.Visible = False
    '            '***** MCR 20210519

    '            'MCR 20210505
    '            'Regresar el datagrid para mostrar historial de Infonavit
    '            Dim dtInfo As DataTable = sqlExecute("select infonavit," & _
    '                                                 "CASE tipo_cred WHEN 1 THEN '%' ELSE CASE tipo_cred WHEN 2 THEN 'CUOTA' ELSE " & _
    '                                                 "CASE tipo_cred WHEN 3 THEN 'VSM' ELSE '--' END END END AS tipo_cre," & _
    '                                                 "cuota_cred,inicio_cre,suspension,comentario,activo,fecha_aplicacion,fecha_captura, " & _
    '                                                 "RTRIM(cod_mov_infonavit.nombre) AS movimiento from infonavit LEFT JOIN cod_mov_infonavit ON " & _
    '                                                 "infonavit.cod_movimiento = cod_mov_infonavit.cod_movimiento" & _
    '                                                 " where reloj='" & rl & "' ORDER BY activo DESC,fecha_aplicacion DESC,fecha_captura DESC", "PERSONAL")
    '            dgvInfonavit.DataSource = dtInfo  ' Actualiza el DataGridView
    '            '***** MCR 20210505


    '        Catch ex As Exception
    '            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
    '        End Try
    '    End Sub
    '#End Region

    '---- END VERSION NUEVA

#Region "Beneficiarios"

    Private Sub CargarPrestaciones(ByVal rl As String)
        Dim btnPrestaciones As DevComponents.DotNetBar.ButtonItem
        Dim dtPrestaciones As New DataTable
        Dim dtPresta As New DataTable
        Dim Primero As Boolean
        Dim btnPrimero As New DevComponents.DotNetBar.ButtonItem
        Try
            dtBeneficiarios = sqlExecute("SELECT idFld,cod_prestacion,nombre_beneficiario AS 'Nombre', familia.nombre AS 'Parentesco', fecha_nacimiento as 'nacimiento',Porcentaje," & _
                             "'X' as movimiento FROM beneficiarios LEFT JOIN familia ON familia.cod_familia = beneficiarios.cod_familia WHERE " & _
                             "reloj = '" & rl & "'")
            dtBeneficiarios.PrimaryKey = New DataColumn() {dtBeneficiarios.Columns("idFld")}

            dtPresta = dtBeneficiarios.Clone
            For Each Benef As DataRow In dtBeneficiarios.Select("cod_prestacion = 'BANCO' AND movimiento<>'B'")
                dtPresta.ImportRow(Benef)
            Next
            dgBeneficiarios.AutoGenerateColumns = False
            dgBeneficiariosBanco.DataSource = dtPresta

            barPanelConceptos.SubItems.Clear()
            dtPrestaciones = sqlExecute("SELECT * FROM prestaciones_con_beneficiarios WHERE cod_comp = '" & cmbCia.SelectedValue & "' ORDER BY nombre")
            Primero = True
            For Each row As DataRow In dtPrestaciones.Rows
                btnPrestaciones = New DevComponents.DotNetBar.ButtonItem
                btnPrestaciones.Name = "btn" & row("cod_prestacion")
                btnPrestaciones.Text = row("nombre").ToString.ToUpper.Trim
                btnPrestaciones.Tag = row("cod_prestacion")
                btnPrestaciones.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb
                btnPrestaciones.AutoCheckOnClick = True
                btnPrestaciones.OptionGroup = "Prestaciones"
                btnPrestaciones.HotFontBold = True

                AddHandler btnPrestaciones.Click, AddressOf FiltraPrestaciones
                AddHandler btnPrestaciones.CheckedChanged, AddressOf CambioEstilo
                barPanelConceptos.SubItems.Add(btnPrestaciones)

                If Primero Then
                    btnPrimero = btnPrestaciones

                    Primero = False
                End If
            Next

            btnPrimero.BeginGroup = True
            btnPrimero.Checked = True
            barPanelConceptos.Refresh()
            My.Application.DoEvents()
            FiltraPrestaciones(btnPrimero, Nothing)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub CambioEstilo(sender As Object, e As EventArgs)
        Try
            sender.FontBold = sender.Checked
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub FiltraPrestaciones(sender As Object, e As EventArgs)
        Try
            Dim dtPresta As New DataTable
            dtPresta = dtBeneficiarios.Clone
            For Each Benef As DataRow In dtBeneficiarios.Select("cod_prestacion = '" & sender.tag & "' AND movimiento<>'B'")
                dtPresta.ImportRow(Benef)
            Next
            dgBeneficiarios.DataSource = dtPresta
            dgBeneficiarios.Tag = sender.tag
            ActualizaPorcentajes()
            ActualizaPorcentajeBanco()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Function ActualizarBeneficiarios() As Boolean
        Dim D As Integer = 0
        Dim R As String
        Dim M As String
        Dim U As String
        Dim P As String
        Dim N As String
        Dim FN As String
        Dim C As String
        Dim F As String
        Try
            R = txtReloj.Text

            For Each dBenef As DataRow In dtBeneficiarios.Select("movimiento<>'X'")
                M = dBenef("movimiento")
                U = dBenef("idFld")
                N = dBenef("nombre").ToString.Trim
                P = dBenef("parentesco").ToString.Trim
                FN = dBenef("nacimiento").ToString.Trim

                C = dBenef("cod_prestacion").ToString.Trim
                If P.Length = 0 Then
                    MessageBox.Show("El parentesco del beneficiario no puede quedar en blanco, favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                Else
                    dtTemp = sqlExecute("SELECT cod_familia FROM familia WHERE nombre = '" & P & "'")
                    If dtTemp.Rows.Count = 0 Then
                        MessageBox.Show("El parentesco del beneficiario " & N & " no es válido, favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    Else
                        F = dtTemp.Rows(0).Item("cod_familia").ToString.Trim
                    End If
                End If

                If N.Length > 60 Then
                    N = N.Substring(0, 60)
                End If

                Select Case M
                    Case "A"
                        sqlExecute("INSERT INTO beneficiarios (cod_prestacion,reloj,nombre_beneficiario,cod_familia, fecha_nacimiento, porcentaje,usuario,fecha_registro) " & _
                                   "VALUES ('" & _
                                   dBenef("cod_prestacion").ToString.Trim & "','" & _
                                   R & "','" & _
                                   dBenef("nombre").ToString.Trim & "','" & _
                                   F & "'," & _
                                   IIf(Date.Parse(FN).Date = Now.Date, "NULL", "'" & FechaSQL(Date.Parse(FN)) & "'") & "," & _
                                   dBenef("porcentaje") & ",'" & _
                                   Usuario & "','" & _
                                   FechaSQL(Now.Date) & "')")
                    Case "B"
                        sqlExecute("DELETE FROM beneficiarios WHERE idFld = '" & U & "'")
                    Case "C"
                        Dim s As String =
                            "UPDATE beneficiarios SET " & _
                                   "nombre_beneficiario = '" & dBenef("nombre").ToString.Trim & _
                                   "', cod_familia = '" & F & _
                                   "', fecha_nacimiento = " & IIf(Date.Parse(FN).Date = Now.Date, "NULL", "'" & FechaSQL(Date.Parse(FN)) & "'") & _
                                   "', porcentaje = " & dBenef("porcentaje") & _
                                   ", usuario = '" & Usuario & _
                                   "', fecha_registro = '" & FechaSQL(Now.Date) & _
                                   "' WHERE idFld = " & U
                        sqlExecute(s)
                End Select
            Next
            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return False
        End Try
    End Function

#End Region

#Region "Familiares"

    Private Sub RefrescaFamiliares(ByVal rl As String)
        Try
            dtFamiliares = sqlExecute("SELECT familiares.idfld, familiares.COD_FAMILIA + ' - ' + familia.nombre as 'CÓD.FAMILIA', familiares.NOMBRE AS '" & encabezado_nombre & "', familiares.FECHA_NAC AS '" & encabezado_fechas & "' FROM familiares INNER JOIN familia ON familiares.COD_FAMILIA = familia.COD_FAMILIA WHERE reloj = '" & rl & "'")
            AgregarFam = False
            EditarFam = False
            dgFamiliares.DataSource = dtFamiliares
            dgFamiliares.Columns("idFld").Visible = False
            dgFamiliares.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            dgFamiliares.Columns.Remove("CÓD.FAMILIA")

            Dim dgvCombo As New DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn
            With dgvCombo
                .Width = 150
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                dtTemp = sqlExecute("SELECT COD_FAMILIA,NOMBRE FROM familia ORDER BY COD_FAMILIA")
                For x = 0 To dtTemp.Rows.Count - 1
                    .Items.Add(dtTemp.Rows.Item(x).Item("COD_FAMILIA") & " - " & dtTemp.Rows.Item(x).Item("nombre"))
                Next

                .DataPropertyName = "CÓD.FAMILIA"
                .HeaderText = "CÓD.FAMILIA"
                .Name = "CÓD.FAMILIA"
            End With
            dgFamiliares.Columns.Insert(1, dgvCombo)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Function CrearDTCambiosFamilia() As Boolean
        Try
            Dim Columnas(5) As DataColumn

            dtCambiosFamilia = New DataTable("CambiosFamilia")
            'dtCambiosFamilia.Columns.Add("UNICO")
            Columnas(0) = New DataColumn("UNICO")
            Columnas(0).DataType = System.Type.GetType("System.String")
            Columnas(1) = New DataColumn("MOVIMIENTO")
            Columnas(1).DataType = System.Type.GetType("System.String")
            Columnas(2) = New DataColumn("CodFamilia")
            Columnas(2).DataType = System.Type.GetType("System.String")
            Columnas(3) = New DataColumn("TipoFamiliar")
            Columnas(3).DataType = System.Type.GetType("System.String")
            Columnas(4) = New DataColumn("Nombre")
            Columnas(4).DataType = System.Type.GetType("System.String")
            Columnas(5) = New DataColumn("Fecha_nac")
            Columnas(5).DataType = System.Type.GetType("System.DateTime")

            For x = 0 To UBound(Columnas)
                dtCambiosFamilia.Columns.Add(Columnas(x))
            Next
            dtCambiosFamilia.PrimaryKey = New DataColumn() {dtCambiosFamilia.Columns("UNICO")}
            'dgCambiosFamilia.DataSource = dtCambiosFamilia
            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return False
        End Try
    End Function

    Private Sub dgFamiliares_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgFamiliares.CellBeginEdit
        Try

            If IsDBNull(dgFamiliares.Item("idFLD", e.RowIndex).Value) Then
                IDFamiliares = ""
            Else
                IDFamiliares = dgFamiliares.Item("idFLD", e.RowIndex).Value
            End If
            FamAnt = IIf(IsDBNull(dgFamiliares.Item(e.ColumnIndex, e.RowIndex).Value), "", dgFamiliares.Item(e.ColumnIndex, e.RowIndex).Value)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub dgFamiliares_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgFamiliares.CellEndEdit
        Dim NewVal As String
        Dim ID As String
        Dim dR As DataRow
        Static NvoID As Integer = 999000
        Try
            NvoID = NvoID + 1
            ID = IIf(IsDBNull(dgFamiliares.Item("idfld", e.RowIndex).Value), NvoID, dgFamiliares.Item("idfld", e.RowIndex).Value)
            NewVal = IIf(IsDBNull(dgFamiliares.Item(e.ColumnIndex, e.RowIndex).Value), "", dgFamiliares.Item(e.ColumnIndex, e.RowIndex).Value)
            If FamAnt <> NewVal Then
                dR = dtCambiosFamilia.Rows.Find(ID)
                If IsNothing(dR) Then
                    dtCambiosFamilia.Rows.Add(ID, IIf(AgregarFam, "A", "C"), dgFamiliares.Item("CÓD.FAMILIA", e.RowIndex).Value, "", dgFamiliares.Item(encabezado_nombre, e.RowIndex).Value, dgFamiliares.Item(encabezado_fechas, e.RowIndex).Value)
                    dgFamiliares.Item("idfld", e.RowIndex).Value = ID
                Else
                    dR.Item("CodFamilia") = dgFamiliares.Item("CÓD.FAMILIA", e.RowIndex).Value
                    'dR.Item("TipoFamiliar") = dgCambiosFamilia.Item("TIPO FAMILIAR", e.RowIndex).Value
                    dR.Item("NOMBRE") = dgFamiliares.Item(encabezado_nombre, e.RowIndex).Value
                    dR.Item("Fecha_nac") = dgFamiliares.Item(encabezado_fechas, e.RowIndex).Value
                End If
                AgregarFam = False
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgFamiliares_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgFamiliares.CellValidating
        Dim x As Date
        Try
            If Editar Or Nuevo Then
                Dim int As Integer
                Try
                    int = dgFamiliares.Columns("CÓD.FAMILIA").Index
                Catch ex As Exception
                    int = 1
                End Try

                If e.ColumnIndex = int Then
                    Dim C As String
                    Dim D As Integer

                    C = e.FormattedValue
                    If C.Length > 0 Then
                        D = C.IndexOf(" - ")
                        If D > 0 Then
                            C = " cod_familia = '" & C.Substring(0, D) & "'"
                        Else
                            C = " UPPER(nombre) LIKE '" & C.ToUpper & "%'"
                        End If
                    Else
                        C = "1=1"
                    End If
                    dtTemp = sqlExecute("SELECT cod_familia + ' - ' + nombre AS dato FROM familia WHERE " & C & "")
                    If dtTemp.Rows.Count = 0 Then
                        MessageBox.Show("El tipo de familiar no es válido. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dgFamiliares.CancelEdit()
                        e.Cancel = True
                    ElseIf D < 0 Then
                        dgFamiliares.Item(e.ColumnIndex, e.RowIndex).Value = dtTemp.Rows(0).Item(0)
                        dgFamiliares.RefreshEdit()
                    End If

                ElseIf e.ColumnIndex = 3 Then
                    If Not DateTime.TryParse(e.FormattedValue, x) And e.FormattedValue <> "" And (Editar Or Nuevo) Then
                        MessageBox.Show("La fecha no es válida. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dgFamiliares.CancelEdit()
                        e.Cancel = True
                    End If
                End If
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            e.Cancel = True
        End Try
    End Sub

    Private Sub dgFamiliares_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgFamiliares.UserAddedRow
        AgregarFam = True
    End Sub

    Private Sub dgFamiliares_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgFamiliares.UserDeletingRow
        Dim Indice As String
        Dim dR As DataRow
        Try
            Indice = """" & dgFamiliares.Item("NOMBRE", e.Row.Index).Value & """"
            If MessageBox.Show("¿Está seguro de borrar el registro " & Indice & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                dR = dtCambiosFamilia.Rows.Find(Indice)
                If IsNothing(dR) Then
                    dtCambiosFamilia.Rows.Add(dgFamiliares.Item("idFld", e.Row.Index).Value, "B")
                Else
                    dR.Item("MOVIMIENTO") = "B"
                End If
            Else
                e.Cancel = True
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            e.Cancel = True
        End Try
    End Sub
    Private Function ActualizarCambiosFamilia() As Boolean
        Dim I As Integer
        Dim D As Integer = 0
        Dim R As String
        Dim M As String
        Dim U As String
        Dim C As String
        Dim T As String
        Dim N As String
        Dim F As Date
        Try
            R = txtReloj.Text

            For I = 0 To dtCambiosFamilia.Rows.Count - 1
                M = dtCambiosFamilia.Rows(I).Item("movimiento")
                U = dtCambiosFamilia.Rows(I).Item("unico")
                If U.Contains("NUEVO") Then
                    U = Val(U.Replace("NUEVO", ""))
                End If
                C = IIf(IsDBNull(dtCambiosFamilia.Rows(I).Item("CodFamilia")), "", dtCambiosFamilia.Rows(I).Item("CodFamilia"))
                If C.Length > 0 Then
                    D = C.IndexOf(" - ")
                    If D > 0 Then
                        C = C.Substring(0, D)
                    Else
                        dtTemp = sqlExecute("SELECT cod_familia FROM familia WHERE cod_familia = '" & C.Trim & "' OR LOWER(nombre) = '" & C.Trim.ToLower & "'")
                        If dtTemp.Rows.Count > 0 Then
                            C = dtTemp.Rows(0).Item("cod_familia")
                        Else
                            MessageBox.Show("El tipo de familiar no es válido, favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return False
                        End If

                    End If
                ElseIf M <> "B" Then
                    MessageBox.Show("El tipo de familiar no puede quedar en blanco, favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If

                T = IIf(IsDBNull(dtCambiosFamilia.Rows(I).Item("TipoFamiliar")), "", dtCambiosFamilia.Rows(I).Item("TipoFamiliar"))
                N = IIf(IsDBNull(dtCambiosFamilia.Rows(I).Item("Nombre")), "", dtCambiosFamilia.Rows(I).Item("Nombre"))
                F = IIf(IsDBNull(dtCambiosFamilia.Rows(I).Item("Fecha_nac")), Now.Date, dtCambiosFamilia.Rows(I).Item("Fecha_nac"))
                Select Case M
                    Case "A"
                        sqlExecute("INSERT INTO familiares (reloj,cod_familia,nombre, fecha_nac) VALUES ('" & R & "','" & C & "','" & N & "'," & IIf(F.Date = Now.Date, "NULL", "'" & FechaSQL(F) & "'") & ")")
                    Case "B"
                        sqlExecute("DELETE FROM familiares WHERE idFld = '" & U & "'")
                    Case "C"
                        sqlExecute("UPDATE familiares SET cod_familia = '" & C & "', nombre = '" & N & "', fecha_nac = '" & FechaSQL(F) & "' WHERE idFld = '" & U & "'")
                End Select
            Next
            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return False
        End Try
    End Function
#End Region

#Region "Escolaridad"

    Private Sub RefrescaEscolaridad(ByVal rl As String)
        Try
            dtEscolaridad = sqlExecute("SELECT '' as idFld, escolaridad.cod_escuela + ' - ' + escuelas.nombre as 'NIVEL ESC.',escolaridad.nombre_escuela as 'NOMBRE/DESCRIPCIÓN', escolaridad.anos as 'AÑOS',finalizo AS 'FINALIZÓ' FROM escolaridad FULL OUTER JOIN escuelas ON escuelas.cod_escuela=escolaridad.cod_escuela WHERE reloj = '" & rl & "'")
            dgEscolaridad.DataSource = dtEscolaridad
            dgEscolaridad.Columns("idFld").Visible = False
            dgEscolaridad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            dgEscolaridad.Columns.Remove("NIVEL ESC.")
            dgEscolaridad.Columns.Remove("FINALIZÓ")

            Dim dgvCombo As New DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn
            With dgvCombo
                .Width = 150
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                dtTemp = sqlExecute("SELECT COD_ESCUELA,NOMBRE FROM escuelas ORDER BY COD_ESCUELA")
                For x = 0 To dtTemp.Rows.Count - 1
                    .Items.Add(dtTemp.Rows.Item(x).Item("COD_ESCUELA") & " - " & dtTemp.Rows.Item(x).Item("nombre"))
                Next

                .DataPropertyName = "NIVEL ESC."
                .HeaderText = "NIVEL ESC."
                .Name = "NIVEL ESC."
            End With
            dgEscolaridad.Columns.Insert(1, dgvCombo)

            Dim dgvCheck As New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
            With dgvCheck
                .DataPropertyName = "FINALIZÓ"
                .HeaderText = "FINALIZÓ"
                .Name = "FINALIZÓ"
            End With
            dgEscolaridad.Columns.Add(dgvCheck)
            dgEscolaridad.Columns("FINALIZÓ").ReadOnly = True
            AgregarEsc = False
            EditarEsc = True
            'dgEscolaridad.DataSource = dtEscolaridad
            'dgEscolaridad.Columns("idFld").Visible = False
            'dgEscolaridad.Columns("finalizo").Visible = False
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Function CrearDTCambiosEscolaridad() As Boolean
        Try
            Dim Columnas(5) As DataColumn

            dtCambiosEscolaridad = New DataTable("CambiosEscolaridad")
            Columnas(0) = New DataColumn("UNICO")
            Columnas(0).DataType = System.Type.GetType("System.String")
            Columnas(1) = New DataColumn("MOVIMIENTO")
            Columnas(1).DataType = System.Type.GetType("System.String")
            Columnas(2) = New DataColumn("Cod_escuela")
            Columnas(2).DataType = System.Type.GetType("System.String")
            Columnas(3) = New DataColumn("Anos")
            Columnas(3).DataType = System.Type.GetType("System.String")
            Columnas(4) = New DataColumn("Finalizo")
            Columnas(4).DataType = System.Type.GetType("System.Boolean")
            Columnas(5) = New DataColumn("nombre_escuela")
            Columnas(5).DataType = System.Type.GetType("System.String")

            For x = 0 To UBound(Columnas)
                dtCambiosEscolaridad.Columns.Add(Columnas(x))
            Next
            dtCambiosEscolaridad.PrimaryKey = New DataColumn() {dtCambiosEscolaridad.Columns("UNICO")}
            'dgCambiosEscolaridad.DataSource = dtCambiosEscolaridad
            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return False
        End Try
    End Function

    Private Sub dgEscolaridad_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgEscolaridad.CellBeginEdit
        Try
            If IsDBNull(dgEscolaridad.Item("idFLD", e.RowIndex).Value) Then
                IDEscolaridad = ""
            Else
                IDEscolaridad = dgEscolaridad.Item("idFLD", e.RowIndex).Value
            End If
            EscAnt = IIf(IsDBNull(dgEscolaridad.Item(e.ColumnIndex, e.RowIndex).Value), "", dgEscolaridad.Item(e.ColumnIndex, e.RowIndex).Value)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub dgEscolaridad_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgEscolaridad.CellEndEdit
        Dim NewVal As String
        Dim ID As String
        Dim dR As DataRow
        Static NvoID As Integer = 999000
        Try
            NvoID = NvoID + 1

            ID = IIf(IsDBNull(dgEscolaridad.Item("idfld", e.RowIndex).Value), NvoID, dgEscolaridad.Item("idfld", e.RowIndex).Value)

            NewVal = IIf(IsDBNull(dgEscolaridad.Item(e.ColumnIndex, e.RowIndex).Value), "", dgEscolaridad.Item(e.ColumnIndex, e.RowIndex).Value)

            If EscAnt <> NewVal Or e.ColumnIndex = 3 Then
                If e.ColumnIndex = 3 And EscAnt > NewVal Then
                    'Si es la columna de años, y el valor es diferente, indica que no finalizó
                    dgEscolaridad.Item("FINALIZÓ", e.RowIndex).Value = False
                End If

                dR = dtCambiosEscolaridad.Rows.Find(ID)
                If IsNothing(dR) Then
                    dtCambiosEscolaridad.Rows.Add(ID, IIf(AgregarEsc, "A", "C"), dgEscolaridad.Item("NIVEL ESC.", e.RowIndex).Value, dgEscolaridad.Item("AÑOS", e.RowIndex).Value, dgEscolaridad.Item("FINALIZÓ", e.RowIndex).Value, dgEscolaridad.Item("NOMBRE/DESCRIPCIÓN", e.RowIndex).Value)
                    dgEscolaridad.Item("idfld", e.RowIndex).Value = ID
                Else
                    dR.Item("Cod_escuela") = dgEscolaridad.Item("NIVEL ESC.", e.RowIndex).Value
                    dR.Item("anos") = dgEscolaridad.Item("AÑOS", e.RowIndex).Value
                    dR.Item("finalizo") = IIf(IsDBNull(dgEscolaridad.Item("FINALIZÓ", e.RowIndex).Value), 0, dgEscolaridad.Item("FINALIZÓ", e.RowIndex).Value) = 1
                    dR.Item("nombre_escuela") = dgEscolaridad.Item("NOMBRE/DESCRIPCIÓN", e.RowIndex).Value
                End If

                AgregarEsc = False
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgEscolaridad_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgEscolaridad.CellValidating
        Dim x As Integer
        Try
            If Editar Or Nuevo Then
                If e.ColumnIndex = 1 Then
                    Dim C As String
                    Dim D As Integer

                    C = e.FormattedValue
                    If C.Length > 0 Then
                        D = C.IndexOf(" - ")
                        If D > 0 Then
                            C = " cod_escuela = '" & C.Substring(0, D) & "'"
                        Else
                            C = " UPPER(nombre) LIKE '" & C.ToUpper & "%'"
                        End If
                    Else
                        C = "1=1"
                    End If
                    dtTemp = sqlExecute("SELECT cod_escuela + ' - ' + nombre AS dato,anos FROM escuelas WHERE " & C & "")
                    If dtTemp.Rows.Count = 0 Then
                        MessageBox.Show("El tipo de escuela no es válido. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        dgEscolaridad.CancelEdit()
                        e.Cancel = True
                        Exit Sub
                    ElseIf D < 0 Then
                        dgEscolaridad.Item(e.ColumnIndex, e.RowIndex).Value = dtTemp.Rows(0).Item(0)
                        dgEscolaridad.RefreshEdit()
                    End If
                    dgEscolaridad.Item("AÑOS", e.RowIndex).Value = dtTemp.Rows(0).Item("anos")
                    If dgEscolaridad.Columns.Count > 3 Then
                        dgEscolaridad.Item("FINALIZÓ", e.RowIndex).Value = True
                    End If
                ElseIf e.ColumnIndex = 3 Then
                    If e.FormattedValue <> "" Then
                        If Not Integer.TryParse(e.FormattedValue, x) Then
                            MessageBox.Show("Los años de escolaridad no son válidos. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            dgEscolaridad.CancelEdit()
                            e.Cancel = True
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            e.Cancel = True
        End Try
    End Sub

    Private Sub dgEscolaridad_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgEscolaridad.UserAddedRow
        AgregarEsc = True
    End Sub

    Private Sub dgEscolaridad_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgEscolaridad.UserDeletingRow
        Dim Indice As String
        Dim dR As DataRow
        Try
            Indice = """" & dgEscolaridad.Item("NIVEL ESC.", e.Row.Index).Value & """"
            If MessageBox.Show("¿Está seguro de borrar el registro " & Indice & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                dR = dtCambiosEscolaridad.Rows.Find(Indice)
                If IsNothing(dR) Then
                    dtCambiosEscolaridad.Rows.Add(dgEscolaridad.Item("idFld", e.Row.Index).Value, "B")
                Else
                    dR.Item("MOVIMIENTO") = "B"
                End If
            Else
                e.Cancel = True
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            e.Cancel = True
        End Try
    End Sub
    Private Function ActualizarCambiosEscolaridad() As Boolean
        Dim I As Integer
        Dim D As Integer = 0
        Dim R As String
        Dim M As String
        Dim U As String
        Dim C As String
        Dim T As Integer
        Dim N As String
        Dim F As Byte
        Try
            R = txtReloj.Text

            For I = 0 To dtCambiosEscolaridad.Rows.Count - 1
                M = dtCambiosEscolaridad.Rows(I).Item("movimiento")
                U = dtCambiosEscolaridad.Rows(I).Item("unico")
                T = IIf(IsDBNull(dtCambiosEscolaridad.Rows(I).Item("anos")), 0, dtCambiosEscolaridad.Rows(I).Item("anos"))
                C = IIf(IsDBNull(dtCambiosEscolaridad.Rows(I).Item("cod_escuela")), "", dtCambiosEscolaridad.Rows(I).Item("cod_escuela"))
                F = 0
                If M <> "B" Then
                    If C.Length > 0 Then
                        If C.Length > 0 Then
                            D = C.IndexOf(" - ")
                            If D > 0 Then
                                C = " cod_escuela = '" & C.Substring(0, D) & "'"
                            Else
                                C = " UPPER(nombre) = '" & C.ToUpper & "'"
                            End If
                        Else
                            C = "1=1"
                        End If

                        dtTemp = sqlExecute("SELECT cod_escuela AS dato,anos FROM escuelas WHERE " & C & "")
                        If dtTemp.Rows.Count = 0 Then
                            MessageBox.Show("El tipo de escuela no es válido. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return False
                        End If
                        If T = dtTemp.Rows(0).Item("anos") Then
                            F = 1
                        Else
                            If T = 0 And dtTemp.Rows(0).Item("anos") > 0 Then
                                F = 1
                            End If
                        End If
                        C = dtTemp.Rows(0).Item(0)
                    Else
                        MessageBox.Show("El tipo de escuela no puede quedar en blanco, favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return False
                    End If
                End If

                N = IIf(IsDBNull(dtCambiosEscolaridad.Rows(I).Item("nombre_escuela")), "", dtCambiosEscolaridad.Rows(I).Item("nombre_escuela"))
                Select Case M
                    Case "A"
                        sqlExecute("INSERT INTO escolaridad (reloj,cod_escuela,anos,finalizo,nombre_escuela) VALUES ('" & R & "','" & C & "'," & T & "," & F & ",'" & N & "')")
                    Case "B"
                        sqlExecute("DELETE FROM escolaridad WHERE idFld = '" & U & "'")
                    Case "C"
                        sqlExecute("UPDATE escolaridad SET cod_escuela = '" & C & "', nombre_escuela = '" & N & "', anos = " & T & ", finalizo = " & F & " WHERE idFld = '" & U & "'")
                End Select
            Next
            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return False
        End Try
    End Function

#End Region

#Region "Infonavit"
    Private Sub RefrescaInfonavit(ByVal rl As String)
        Try
            If Not addInfoFirstTime Then cmbTipoMovInfonavit.SelectedValue = ""



            Dim dtInfonavit As DataTable = sqlExecute("select infonavit, tipo_cred, cuota_cred, inicio_cre,cod_movimiento,fecha_aplicacion from infonavit where reloj = '" & rl & "' and isnull(activo,0)=1", "PERSONAL")
            If dtInfonavit.Rows.Count > 0 Then
                Try : txtNumeroCredito.Text = dtInfonavit.Rows(0)("infonavit") : Catch ex As Exception : txtNumeroCredito.Text = "SIN CREDITO ACTIVO" : End Try
                '  txtNumeroCredito.Text = IIf(IsDBNull(dtInfonavit.Rows(0)("infonavit")), "SIN CREDITO ACTIVO", dtInfonavit.Rows(0)("infonavit"))
                If txtNumeroCredito.Text = "SIN CREDITO ACTIVO" Then
                    cmbTipoInfonavit.SelectedValue = 0
                    txtFactorDeDescuentoInfonavit.Text = 0
                    dtpFechaInicioCreditoInfonavit.Value = dtpFechaInicioCreditoInfonavit.MinDate
                    cmbTipoMovInfonavit.SelectedValue = 0
                    btnAgregarSuspenderCreditoInfonavit.Text = "Agregar crédito"
                    btnAgregarSuspenderCreditoInfonavit.Visible = True

                    '--No mostrar controles
                    Label3.Visible = False
                    Label17.Visible = False
                    Label16.Visible = False
                    cmbTipoInfonavit.Visible = False
                    txtFactorDeDescuentoInfonavit.Visible = False
                    dtpFechaInicioCreditoInfonavit.Visible = False
                    cmbTipoMovInfonavit.Visible = False

                Else
                    Try : cmbTipoInfonavit.SelectedValue = dtInfonavit.Rows(0)("tipo_cred") : Catch ex As Exception : cmbTipoInfonavit.SelectedValue = "0" : End Try
                    Try : txtFactorDeDescuentoInfonavit.Text = Double.Parse(dtInfonavit.Rows(0)("cuota_cred")).ToString("0.0000") : Catch ex As Exception : txtFactorDeDescuentoInfonavit.Text = "" : End Try
                    ' Try : dtpFechaInicioCreditoInfonavit.Value = dtInfonavit.Rows(0)("inicio_cre") : Catch ex As Exception : dtpFechaInicioCreditoInfonavit.Value = dtpFechaInicioCreditoInfonavit.MinDate : End Try
                    Try : dtpFechaInicioCreditoInfonavit.Value = dtInfonavit.Rows(0)("fecha_aplicacion") : Catch ex As Exception : dtpFechaInicioCreditoInfonavit.Value = dtpFechaInicioCreditoInfonavit.MinDate : End Try
                    Try : cmbTipoMovInfonavit.SelectedValue = dtInfonavit.Rows(0)("cod_movimiento") : Catch ex As Exception : cmbTipoMovInfonavit.SelectedValue = "0" : End Try

                    '  cmbTipoInfonavit.SelectedValue = IIf(IsDBNull(dtInfonavit.Rows(0)("tipo_cred")), "0", dtInfonavit.Rows(0)("tipo_cred"))
                    '  txtFactorDeDescuentoInfonavit.Text = IIf(IsDBNull(dtInfonavit.Rows(0)("cuota_cred")), "", Double.Parse(dtInfonavit.Rows(0)("cuota_cred")).ToString("0.0000"))
                    '  dtpFechaInicioCreditoInfonavit.Value = IIf(IsDBNull(dtInfonavit.Rows(0)("inicio_cre")), dtpFechaInicioCreditoInfonavit.MinDate, dtInfonavit.Rows(0)("inicio_cre"))

                    btnAgregarSuspenderCreditoInfonavit.Text = "Suspender crédito"
                    btnAgregarSuspenderCreditoInfonavit.Visible = False

                    '--Mostrar demás controles
                    Label3.Visible = True
                    Label17.Visible = True
                    Label16.Visible = True
                    cmbTipoInfonavit.Visible = True
                    txtFactorDeDescuentoInfonavit.Visible = True
                    dtpFechaInicioCreditoInfonavit.Visible = True
                    cmbTipoMovInfonavit.Visible = True

                End If
            Else
                If Not addInfoFirstTime Then
                    txtNumeroCredito.Text = "SIN CREDITO ACTIVO"
                    cmbTipoInfonavit.SelectedValue = 0
                    txtFactorDeDescuentoInfonavit.Text = 0
                    cmbTipoMovInfonavit.SelectedValue = 0
                    dtpFechaInicioCreditoInfonavit.Value = dtpFechaInicioCreditoInfonavit.MinDate

                    btnAgregarSuspenderCreditoInfonavit.Text = "Agregar crédito"
                    btnAgregarSuspenderCreditoInfonavit.Visible = True

                    '--No mostrar controles
                    Label3.Visible = False
                    Label17.Visible = False
                    Label16.Visible = False
                    cmbTipoInfonavit.Visible = False
                    txtFactorDeDescuentoInfonavit.Visible = False
                    dtpFechaInicioCreditoInfonavit.Visible = False
                    cmbTipoMovInfonavit.Visible = False

                End If

            End If




            ' Dim dtInfo As DataTable = sqlExecute("select infonavit,tipo_cred,cuota_cred,inicio_cre,suspension,comentario,activo from infonavit where reloj='" & rl & "'", "PERSONAL")

            Dim QInfo As String = "select infonavit," & _
                                       "CASE tipo_cred WHEN 1 THEN '%' ELSE CASE tipo_cred WHEN 2 THEN 'CUOTA' ELSE " & _
                                       "CASE tipo_cred WHEN 3 THEN 'VSM' ELSE '--' END END END AS tipo_cre," & _
                                       "cuota_cred,inicio_cre,suspension,comentario,activo,fecha_aplicacion,fechahora, " & _
                                       "RTRIM(cod_mov_infonavit.nombre) AS movimiento,usuario from infonavit LEFT JOIN cod_mov_infonavit ON " & _
                                       "infonavit.cod_movimiento = cod_mov_infonavit.cod_movimiento" & _
                                       " where reloj='" & rl & "' ORDER BY activo DESC,fecha_aplicacion DESC,fechahora DESC"

            Dim dtInfo As DataTable = sqlExecute(QInfo, "PERSONAL")

            dgvInfonavit.DataSource = dtInfo  ' Actualiza el DataGridView

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
#End Region

#Region "Auxiliares"
    Private Sub RefrescaAuxiliares(ByVal rl As String)
        Dim colAux As New DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn
        Dim dtAuxSel As New DataTable
        Try
            rl = rl.Trim
            dtAuxSel = sqlExecute("SELECT campo FROM auxiliares LEFT JOIN personal ON auxiliares.cod_comp = personal.cod_comp WHERE reloj = '" & rl & _
                                  "' AND mostrar_personal = 1 AND campo NOT IN " & _
                                  "(select campo FROM detalle_auxiliares WHERE campo =auxiliares.campo AND reloj = '" & rl & "') ")

            For Each AuxSel As DataRow In dtAuxSel.Rows
                Dim idFld As Integer = 1000
                Dim dtSiguiente As DataTable = sqlExecute("select top 1 idFld from detalle_auxiliares where idFld is not null order by idFld desc")
                If dtSiguiente.Rows.Count Then
                    idFld = Integer.Parse(dtSiguiente.Rows(0)("idfld")) + 1
                End If
                If AuxSel("campo").ToString.Trim <> "RECOMEN" Then
                    sqlExecute("INSERT INTO detalle_auxiliares (idFld,cod_comp, reloj,campo) VALUES ('" & idFld & "','" & RTrim(cmbCia.SelectedValue) & "', '" & rl & "','" & AuxSel("campo") & "')")
                End If
            Next

            dtAuxiliares = New DataTable
            dtAuxiliares = sqlExecute("SELECT detalle_auxiliares.idFld,RTRIM(auxiliares.CAMPO) AS CAMPO,RTRIM(detalle_auxiliares.contenido) as 'CONTENIDO' FROM detalle_auxiliares FULL OUTER JOIN auxiliares ON auxiliares.campo=detalle_auxiliares.campo WHERE reloj = '" & rl & "' ORDER BY auxiliares.campo")
            AgregarAux = False
            EditarAux = True
            dgAuxiliares.DataSource = dtAuxiliares
            dgAuxiliares.Columns("idFld").Visible = False
            'dgAuxiliares.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            ''dtAuxiliares.Columns("detalle").ReadOnly = True

            dgAuxiliares.Columns.Remove("CAMPO")
            dgAuxiliares.Columns.Remove("CONTENIDO")

            'Agregar datos a columna combo de tipo de respuestas
            'Esta configuración no se puede agregar en modo de edición, solo en código
            colAux.DataSource = sqlExecute("SELECT UPPER(RTRIM(CAMPO)) AS CAMPO,upper(RTRIM(NOMBRE)) as NOMBRE FROM Auxiliares ORDER BY campo")
            colAux.ValueMember = "CAMPO"
            colAux.DisplayMember = "NOMBRE"
            colAux.DataPropertyName = "CAMPO"
            colAux.Name = "CAMPO"
            colAux.Width = 350
            colAux.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            'colRespuesta.AutoCompleteSource = AutoCompleteSource.ListItems
            colAux.DropDownStyle = ComboBoxStyle.DropDownList
            colAux.HeaderText = "CAMPO"
            dgAuxiliares.Columns.Insert(1, colAux)
            '***********************************************************************

            Dim dgvCombo As New DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn
            With dgvCombo
                '.Width = 150
                '.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend

                dtValidos = sqlExecute("SELECT idFLD, campo, campo_valido FROM Auxiliares_VALIDOS")
                .Items.Clear()
                For Each DR As DataRow In dtValidos.Rows
                    .Items.Add(DR("CAMPO_VALIDO"))
                Next

                'dtValidos.Select("campo = 'TALLA_PANT'")

                '.DataSource = dtValidos
                '.DisplayMember = "campo,campo_valido"
                .ValueMember = "campo_valido"
                .DataPropertyName = "CONTENIDO"
                .HeaderText = "CONTENIDO"
                .Name = "CONTENIDO"
            End With
            dgAuxiliares.Columns.Add(dgvCombo)
            dgAuxiliares.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Function CrearDTCambiosAuxiliares() As Boolean
        Try
            Dim Columnas(3) As DataColumn

            dtCambiosAuxiliares = New DataTable("CambiosAuxiliares")
            Columnas(0) = New DataColumn("UNICO")
            Columnas(0).DataType = System.Type.GetType("System.String")
            Columnas(1) = New DataColumn("MOVIMIENTO")
            Columnas(1).DataType = System.Type.GetType("System.String")
            Columnas(2) = New DataColumn("Campo")
            Columnas(2).DataType = System.Type.GetType("System.String")
            Columnas(3) = New DataColumn("Contenido")
            Columnas(3).DataType = System.Type.GetType("System.String")

            For x = 0 To UBound(Columnas)
                dtCambiosAuxiliares.Columns.Add(Columnas(x))
            Next
            dtCambiosAuxiliares.PrimaryKey = New DataColumn() {dtCambiosAuxiliares.Columns("UNICO")}
            'dgCambiosAuxiliares.DataSource = dtCambiosAuxiliares
            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return False
        End Try
    End Function

    Private Sub dgAuxiliares_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles dgAuxiliares.CellBeginEdit
        Try
            If IsDBNull(dgAuxiliares.Item("idFLD", e.RowIndex).Value) Then
                IDAuxiliares = ""
            Else
                IDAuxiliares = dgAuxiliares.Item("idFLD", e.RowIndex).Value
            End If
            AuxAnt = IIf(IsDBNull(dgAuxiliares.Item(e.ColumnIndex, e.RowIndex).Value), "", dgAuxiliares.Item(e.ColumnIndex, e.RowIndex).Value)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub dgAuxiliares_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAuxiliares.CellContentClick

    End Sub

    Private Sub dgAuxiliares_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgAuxiliares.CellEndEdit
        Dim NewVal As String
        Dim ID As String
        Dim dR As DataRow
        Static NvoID As Integer = 999000
        Try
            NvoID = NvoID + 1

            ID = IIf(IsDBNull(dgAuxiliares.Item("idfld", e.RowIndex).Value), NvoID, dgAuxiliares.Item("idfld", e.RowIndex).Value)

            NewVal = IIf(IsDBNull(dgAuxiliares.Item(e.ColumnIndex, e.RowIndex).Value), "", dgAuxiliares.Item(e.ColumnIndex, e.RowIndex).Value)

            If AuxAnt <> NewVal Then
                dR = dtCambiosAuxiliares.Rows.Find(ID)
                If IsNothing(dR) Then
                    dtCambiosAuxiliares.Rows.Add(ID, IIf(ID > 999000, "A", "C"), dgAuxiliares.Item("CAMPO", e.RowIndex).Value, dgAuxiliares.Item("CONTENIDO", e.RowIndex).Value)
                    dgAuxiliares.Item("idfld", e.RowIndex).Value = ID
                Else

                    dR.Item("CAMPO") = dgAuxiliares.Item("CAMPO", e.RowIndex).Value
                    dR.Item("CONTENIDO") = dgAuxiliares.Item("CONTENIDO", e.RowIndex).Value
                End If

                AgregarAux = False
            End If

            If NewVal = "RECOMEN" Then
                dgAuxiliares.Item("CONTENIDO", e.RowIndex).ReadOnly = True
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgAuxiliares_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgAuxiliares.CellEnter
        Try
            Dim Campo As String = dgAuxiliares.Item(1, e.RowIndex).Value.ToString.Trim
            Dim AuxValidos As Boolean = False
            If Editar Or Nuevo Then
                If e.ColumnIndex = 2 Then
                    'Buscar los valores válidos para el auxiliar seleccionado
                    dtValidos = sqlExecute("SELECT idFLD, campo, campo_valido FROM Auxiliares_VALIDOS WHERE campo = '" & Campo & "' AND cod_comp = '" & cmbCia.SelectedValue & "'")

                    'Si regresó registros, indica que hay auxiliares válidos
                    AuxValidos = dtValidos.Rows.Count > 0

                    'Crear una variable tipo combo, para pasar los datos de los auxiliares válidos
                    Dim dgvCombo As New DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn
                    dgvCombo = dgAuxiliares.Columns("CONTENIDO")
                    dgvCombo.Items.Clear()
                    For Each DR As DataRow In dtValidos.Rows
                        dgvCombo.Items.Add(DR("CAMPO_VALIDO"))
                    Next

                    'Si hay , buscar si el valor actual es válido
                    If AuxValidos Then
                        dtTemp = sqlExecute("SELECT idFLD FROM Auxiliares_VALIDOS WHERE campo_valido = '" & dgAuxiliares.Item("CONTENIDO", e.RowIndex).Value & "' AND  campo = '" & Campo & "' AND cod_comp = '" & cmbCia.SelectedValue & "'")
                        'Si el valor actual no es un dato válido para este auxiliar, poner en blanco
                        If dtTemp.Rows.Count = 0 Then
                            'Poner el blanco el contenido, 
                            dgAuxiliares.Item("CONTENIDO", e.RowIndex).Value = ""
                        End If
                    End If
                    'dgAuxiliares.Item("CONTENIDO", e.RowIndex) = dgvCombo.Items(0)

                    'If IsDBNull(dgAuxiliares.Item("CONTENIDO", e.RowIndex).Value) Then
                    'End If
                    dgAuxiliares.Refresh()
                End If
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgAuxiliares_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgAuxiliares.CellValidated

    End Sub

    Private Sub dgAuxiliares_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgAuxiliares.CellValidating

        'Dim x As Integer
        Try
            Dim Valido As Boolean
            If Editar Or Nuevo Then
                If e.ColumnIndex = 2 Then
                    Dim C As String
                    C = e.FormattedValue
                    Valido = True

                    dtTemp = sqlExecute("SELECT campo_valido FROM Auxiliares_validos WHERE campo = '" & dgAuxiliares.Item("CAMPO", e.RowIndex).Value.ToString.Trim.ToUpper & "'")
                    If dtTemp.Rows.Count = 0 Then
                        Valido = True
                    Else
                        dtTemp = sqlExecute("SELECT campo_valido FROM Auxiliares_validos WHERE campo = '" & dgAuxiliares.Item("CAMPO", e.RowIndex).Value.ToString.Trim.ToUpper & _
                                            "' AND campo_valido = '" & C.ToUpper & "'")
                        dgAuxiliares.CurrentCell.Value = C.ToUpper
                        Valido = dtTemp.Rows.Count > 0
                    End If

                    If Not Valido Then
                        MessageBox.Show("El tipo de auxiliar no es válido. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        'dgAuxiliares.CancelEdit()
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            e.Cancel = True
        End Try
    End Sub



    Private Sub dgAuxiliares_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgAuxiliares.UserAddedRow
        AgregarAux = True
    End Sub

    Private Sub dgAuxiliares_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgAuxiliares.UserDeletingRow
        Dim Indice As String
        Dim dR As DataRow
        Try
            Indice = """" & dgAuxiliares.Item("CAMPO", e.Row.Index).Value & """"
            If MessageBox.Show("¿Está seguro de borrar el registro " & Indice & "?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                dR = dtCambiosAuxiliares.Rows.Find(Indice)
                If IsNothing(dR) Then
                    dtCambiosAuxiliares.Rows.Add(dgAuxiliares.Item("idFld", e.Row.Index).Value, "B")
                Else
                    dR.Item("MOVIMIENTO") = "B"
                End If
            Else
                e.Cancel = True
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            e.Cancel = True
        End Try

    End Sub
    Private Function ActualizarCambiosAuxiliares() As Boolean
        Dim I As Integer
        Dim D As Integer = 0
        Dim R As String
        Dim M As String
        Dim U As String
        Dim C As String
        Dim T As String
        Dim N As String
        Try
            R = txtReloj.Text

            For I = 0 To dtCambiosAuxiliares.Rows.Count - 1
                M = dtCambiosAuxiliares.Rows(I).Item("movimiento")
                U = dtCambiosAuxiliares.Rows(I).Item("unico")
                C = IIf(IsDBNull(dtCambiosAuxiliares.Rows(I).Item("CAMPO")), "", dtCambiosAuxiliares.Rows(I).Item("CAMPO"))
                If C.Length > 0 Then
                    D = C.IndexOf(" - ")
                    If D > 0 Then C = C.Substring(0, D)
                ElseIf M <> "B" Then
                    MessageBox.Show("El campo auxiliar no puede quedar en blanco, favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
                dtTemp = sqlExecute("SELECT cod_comp from personalvw WHERE reloj = '" & R & "'")
                N = dtTemp.Rows.Item(0).Item(0)

                T = IIf(IsDBNull(dtCambiosAuxiliares.Rows(I).Item("contenido")), "", dtCambiosAuxiliares.Rows(I).Item("contenido"))



                Select Case M
                    Case "A"
                        Dim idFld As Integer = 1000
                        Dim dtSiguiente As DataTable = sqlExecute("select top 1 idFld from detalle_auxiliares where idFld is not null order by idFld desc")
                        If dtSiguiente.Rows.Count Then
                            idFld = Integer.Parse(dtSiguiente.Rows(0)("idfld")) + 1
                        End If
                        If C.Trim = "RECOMEN" Then
                            Dim dttemp As DataTable = sqlExecute("select * from personal where reloj = '" & T.Trim.PadLeft(6, "0") & "'")
                            If dttemp.Rows.Count > 0 Then
                                sqlExecute("INSERT INTO detalle_auxiliares (idfld, cod_comp,reloj,campo,contenido, detalles, usuario) VALUES ('" & idFld & "', '" & N & "','" & R & "','" & C.Trim & "','" & T.Trim.PadLeft(6, "0") & "', '1', '" & Usuario & "')")
                            Else
                                MessageBox.Show("El valor de auxiliar no es valido, favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            sqlExecute("INSERT INTO detalle_auxiliares (idfld, cod_comp,reloj,campo,contenido) VALUES ('" & idFld & "', '" & N & "','" & R & "','" & C.Trim & "','" & T.Trim & "')")
                        End If
                    Case "B"
                        sqlExecute("DELETE FROM detalle_auxiliares WHERE idFld = '" & U & "'")
                    Case "C"
                        sqlExecute("UPDATE detalle_auxiliares SET campo = '" & C & "', contenido = '" & T & "' WHERE idFld = '" & U & "'")
                End Select
            Next
            Return True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return False
        End Try
    End Function
#End Region

#Region "Documentos"
    Private Sub RefrescaDocumentos(ByVal rl As String)
        Try
            Dim btnArchivo As DevComponents.DotNetBar.ButtonItem
            Dim dtDocumentos As DataTable = sqlExecute("SELECT * from archivos where reloj='" & rl.Trim & "' order by consec asc", "PERSONAL")

            '------------Mostrar  Archivos
            For y = 0 To itmDocs.SubItems.Count - 1 ' Para cada uno de los items de los archivos
                itmDocs.SubItems.RemoveAt(0) ' Remueve los elementos del index a -1, es decir, los elementos despues, por ejemplo el index 1, se pasa al 0, el que era el 2, se pasa al 1 y asi sucesivamente..
            Next
            itmDocs.SubItems.Clear()

            Dim x As Integer = 0
            For Each Row In dtDocumentos.Rows
                Dim Archivo As String = IIf(IsDBNull(dtDocumentos.Rows(x).Item("nombre_arch")), "", dtDocumentos.Rows(x).Item("nombre_arch"))
                If Archivo.Trim.Length > 0 Then
                    btnArchivo = NuevoArchivo(PathArchivos & "PERSONAL\" & Archivo)
                    If Not btnArchivo Is Nothing Then
                        itmDocs.SubItems.Add(btnArchivo)
                    End If
                End If
                x += 1
            Next

            pnlDocs.Refresh() ' Refrescar los archivos en el panel

            '------------Cargar Descripción y tipo del documento y limpiar los demas controles

            If (Not dtDocumentos.Columns.Contains("Error") And dtDocumentos.Rows.Count > 0) Then
                Dim z As Integer = dtDocumentos.Rows.Count
                Select Case z
                    Case 1
                        txtDescArch1.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(0).Item("desc_arch")), "", dtDocumentos.Rows(0).Item("desc_arch")))
                        lblTpoDoc1.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(0).Item("tipo_arch")), "", dtDocumentos.Rows(0).Item("tipo_arch")))
                        txtDescArch2.Text = ""
                        lblTpoDoc2.Text = ""
                        txtDescArch3.Text = ""
                        lblTpoDoc3.Text = ""
                        txtDescArch4.Text = ""
                        lblTpoDoc4.Text = ""
                        txtDescArch5.Text = ""
                        lblTpoDoc5.Text = ""
                        txtDescArch6.Text = ""
                        lblTpoDoc6.Text = ""
                        txtDescArch7.Text = ""
                        lblTpoDoc7.Text = ""
                        txtDescArch8.Text = ""
                        lblTpoDoc8.Text = ""
                    Case 2
                        txtDescArch1.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(0).Item("desc_arch")), "", dtDocumentos.Rows(0).Item("desc_arch")))
                        lblTpoDoc1.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(0).Item("tipo_arch")), "", dtDocumentos.Rows(0).Item("tipo_arch")))
                        txtDescArch2.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(1).Item("desc_arch")), "", dtDocumentos.Rows(1).Item("desc_arch")))
                        lblTpoDoc2.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(1).Item("tipo_arch")), "", dtDocumentos.Rows(1).Item("tipo_arch")))
                        txtDescArch3.Text = ""
                        lblTpoDoc3.Text = ""
                        txtDescArch4.Text = ""
                        lblTpoDoc4.Text = ""
                        txtDescArch5.Text = ""
                        lblTpoDoc5.Text = ""
                        txtDescArch6.Text = ""
                        lblTpoDoc6.Text = ""
                        txtDescArch7.Text = ""
                        lblTpoDoc7.Text = ""
                        txtDescArch8.Text = ""
                        lblTpoDoc8.Text = ""
                    Case 3

                        txtDescArch1.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(0).Item("desc_arch")), "", dtDocumentos.Rows(0).Item("desc_arch")))
                        lblTpoDoc1.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(0).Item("tipo_arch")), "", dtDocumentos.Rows(0).Item("tipo_arch")))
                        txtDescArch2.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(1).Item("desc_arch")), "", dtDocumentos.Rows(1).Item("desc_arch")))
                        lblTpoDoc2.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(1).Item("tipo_arch")), "", dtDocumentos.Rows(1).Item("tipo_arch")))
                        txtDescArch3.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(2).Item("desc_arch")), "", dtDocumentos.Rows(2).Item("desc_arch")))
                        lblTpoDoc3.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(2).Item("tipo_arch")), "", dtDocumentos.Rows(2).Item("tipo_arch")))
                        txtDescArch4.Text = ""
                        lblTpoDoc4.Text = ""
                        txtDescArch5.Text = ""
                        lblTpoDoc5.Text = ""
                        txtDescArch6.Text = ""
                        lblTpoDoc6.Text = ""
                        txtDescArch7.Text = ""
                        lblTpoDoc7.Text = ""
                        txtDescArch8.Text = ""
                        lblTpoDoc8.Text = ""
                    Case 4
                        txtDescArch1.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(0).Item("desc_arch")), "", dtDocumentos.Rows(0).Item("desc_arch")))
                        lblTpoDoc1.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(0).Item("tipo_arch")), "", dtDocumentos.Rows(0).Item("tipo_arch")))
                        txtDescArch2.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(1).Item("desc_arch")), "", dtDocumentos.Rows(1).Item("desc_arch")))
                        lblTpoDoc2.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(1).Item("tipo_arch")), "", dtDocumentos.Rows(1).Item("tipo_arch")))
                        txtDescArch3.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(2).Item("desc_arch")), "", dtDocumentos.Rows(2).Item("desc_arch")))
                        lblTpoDoc3.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(2).Item("tipo_arch")), "", dtDocumentos.Rows(2).Item("tipo_arch")))
                        txtDescArch4.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(3).Item("desc_arch")), "", dtDocumentos.Rows(3).Item("desc_arch")))
                        lblTpoDoc4.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(3).Item("tipo_arch")), "", dtDocumentos.Rows(3).Item("tipo_arch")))
                        txtDescArch5.Text = ""
                        lblTpoDoc5.Text = ""
                        txtDescArch6.Text = ""
                        lblTpoDoc6.Text = ""
                        txtDescArch7.Text = ""
                        lblTpoDoc7.Text = ""
                        txtDescArch8.Text = ""
                        lblTpoDoc8.Text = ""

                    Case 5
                        txtDescArch1.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(0).Item("desc_arch")), "", dtDocumentos.Rows(0).Item("desc_arch")))
                        lblTpoDoc1.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(0).Item("tipo_arch")), "", dtDocumentos.Rows(0).Item("tipo_arch")))
                        txtDescArch2.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(1).Item("desc_arch")), "", dtDocumentos.Rows(1).Item("desc_arch")))
                        lblTpoDoc2.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(1).Item("tipo_arch")), "", dtDocumentos.Rows(1).Item("tipo_arch")))
                        txtDescArch3.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(2).Item("desc_arch")), "", dtDocumentos.Rows(2).Item("desc_arch")))
                        lblTpoDoc3.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(2).Item("tipo_arch")), "", dtDocumentos.Rows(2).Item("tipo_arch")))
                        txtDescArch4.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(3).Item("desc_arch")), "", dtDocumentos.Rows(3).Item("desc_arch")))
                        lblTpoDoc4.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(3).Item("tipo_arch")), "", dtDocumentos.Rows(3).Item("tipo_arch")))
                        txtDescArch5.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(4).Item("desc_arch")), "", dtDocumentos.Rows(4).Item("desc_arch")))
                        lblTpoDoc5.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(4).Item("tipo_arch")), "", dtDocumentos.Rows(4).Item("tipo_arch")))
                        txtDescArch6.Text = ""
                        lblTpoDoc6.Text = ""
                        txtDescArch7.Text = ""
                        lblTpoDoc7.Text = ""
                        txtDescArch8.Text = ""
                        lblTpoDoc8.Text = ""

                    Case 6
                        txtDescArch1.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(0).Item("desc_arch")), "", dtDocumentos.Rows(0).Item("desc_arch")))
                        lblTpoDoc1.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(0).Item("tipo_arch")), "", dtDocumentos.Rows(0).Item("tipo_arch")))
                        txtDescArch2.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(1).Item("desc_arch")), "", dtDocumentos.Rows(1).Item("desc_arch")))
                        lblTpoDoc2.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(1).Item("tipo_arch")), "", dtDocumentos.Rows(1).Item("tipo_arch")))
                        txtDescArch3.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(2).Item("desc_arch")), "", dtDocumentos.Rows(2).Item("desc_arch")))
                        lblTpoDoc3.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(2).Item("tipo_arch")), "", dtDocumentos.Rows(2).Item("tipo_arch")))
                        txtDescArch4.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(3).Item("desc_arch")), "", dtDocumentos.Rows(3).Item("desc_arch")))
                        lblTpoDoc4.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(3).Item("tipo_arch")), "", dtDocumentos.Rows(3).Item("tipo_arch")))
                        txtDescArch5.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(4).Item("desc_arch")), "", dtDocumentos.Rows(4).Item("desc_arch")))
                        lblTpoDoc5.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(4).Item("tipo_arch")), "", dtDocumentos.Rows(4).Item("tipo_arch")))
                        txtDescArch6.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(5).Item("desc_arch")), "", dtDocumentos.Rows(5).Item("desc_arch")))
                        lblTpoDoc6.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(5).Item("tipo_arch")), "", dtDocumentos.Rows(5).Item("tipo_arch")))
                        txtDescArch7.Text = ""
                        lblTpoDoc7.Text = ""
                        txtDescArch8.Text = ""
                        lblTpoDoc8.Text = ""

                    Case 7
                        txtDescArch1.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(0).Item("desc_arch")), "", dtDocumentos.Rows(0).Item("desc_arch")))
                        lblTpoDoc1.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(0).Item("tipo_arch")), "", dtDocumentos.Rows(0).Item("tipo_arch")))
                        txtDescArch2.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(1).Item("desc_arch")), "", dtDocumentos.Rows(1).Item("desc_arch")))
                        lblTpoDoc2.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(1).Item("tipo_arch")), "", dtDocumentos.Rows(1).Item("tipo_arch")))
                        txtDescArch3.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(2).Item("desc_arch")), "", dtDocumentos.Rows(2).Item("desc_arch")))
                        lblTpoDoc3.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(2).Item("tipo_arch")), "", dtDocumentos.Rows(2).Item("tipo_arch")))
                        txtDescArch4.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(3).Item("desc_arch")), "", dtDocumentos.Rows(3).Item("desc_arch")))
                        lblTpoDoc4.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(3).Item("tipo_arch")), "", dtDocumentos.Rows(3).Item("tipo_arch")))
                        txtDescArch5.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(4).Item("desc_arch")), "", dtDocumentos.Rows(4).Item("desc_arch")))
                        lblTpoDoc5.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(4).Item("tipo_arch")), "", dtDocumentos.Rows(4).Item("tipo_arch")))
                        txtDescArch6.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(5).Item("desc_arch")), "", dtDocumentos.Rows(5).Item("desc_arch")))
                        lblTpoDoc6.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(5).Item("tipo_arch")), "", dtDocumentos.Rows(5).Item("tipo_arch")))
                        txtDescArch7.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(6).Item("desc_arch")), "", dtDocumentos.Rows(6).Item("desc_arch")))
                        lblTpoDoc7.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(6).Item("tipo_arch")), "", dtDocumentos.Rows(6).Item("tipo_arch")))
                        txtDescArch8.Text = ""
                        lblTpoDoc8.Text = ""
                    Case 8
                        txtDescArch1.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(0).Item("desc_arch")), "", dtDocumentos.Rows(0).Item("desc_arch")))
                        lblTpoDoc1.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(0).Item("tipo_arch")), "", dtDocumentos.Rows(0).Item("tipo_arch")))
                        txtDescArch2.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(1).Item("desc_arch")), "", dtDocumentos.Rows(1).Item("desc_arch")))
                        lblTpoDoc2.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(1).Item("tipo_arch")), "", dtDocumentos.Rows(1).Item("tipo_arch")))
                        txtDescArch3.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(2).Item("desc_arch")), "", dtDocumentos.Rows(2).Item("desc_arch")))
                        lblTpoDoc3.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(2).Item("tipo_arch")), "", dtDocumentos.Rows(2).Item("tipo_arch")))
                        txtDescArch4.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(3).Item("desc_arch")), "", dtDocumentos.Rows(3).Item("desc_arch")))
                        lblTpoDoc4.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(3).Item("tipo_arch")), "", dtDocumentos.Rows(3).Item("tipo_arch")))
                        txtDescArch5.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(4).Item("desc_arch")), "", dtDocumentos.Rows(4).Item("desc_arch")))
                        lblTpoDoc5.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(4).Item("tipo_arch")), "", dtDocumentos.Rows(4).Item("tipo_arch")))
                        txtDescArch6.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(5).Item("desc_arch")), "", dtDocumentos.Rows(5).Item("desc_arch")))
                        lblTpoDoc6.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(5).Item("tipo_arch")), "", dtDocumentos.Rows(5).Item("tipo_arch")))
                        txtDescArch7.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(6).Item("desc_arch")), "", dtDocumentos.Rows(6).Item("desc_arch")))
                        lblTpoDoc7.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(6).Item("tipo_arch")), "", dtDocumentos.Rows(6).Item("tipo_arch")))
                        txtDescArch8.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(7).Item("desc_arch")), "", dtDocumentos.Rows(7).Item("desc_arch")))
                        lblTpoDoc8.Text = RTrim(IIf(IsDBNull(dtDocumentos.Rows(7).Item("tipo_arch")), "", dtDocumentos.Rows(7).Item("tipo_arch")))

                    Case Else
                        LimpiarCtrlDocs() ' Limpia todos los controles
                End Select

            Else
                LimpiarCtrlDocs()

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
#End Region

    Private Sub frmMaestro_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If ConsultaReloj <> "" Then
            MostrarInformacion(ConsultaReloj)
        End If
    End Sub


    Private Sub frmMaestro_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Dim Resulta As Windows.Forms.DialogResult
        If Nuevo Or Editar Then
            Resulta = MessageBox.Show("Hay datos pendientes de guardar. ¿Desea guardarlos antes de cambiar de pantalla?", "Abandonar maestro", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button3)
            If Resulta = Windows.Forms.DialogResult.Cancel Then
                Timer1.Start()
            ElseIf Resulta = Windows.Forms.DialogResult.Yes Then
                btnNuevo.PerformClick()
            ElseIf Resulta = Windows.Forms.DialogResult.No Then
                btnEditar.PerformClick()
            End If
        End If
    End Sub

    Private Sub frmTa_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.F12 Then
                btnBuscar.PerformClick()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmMaestro_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        dgBeneficiarios.DataSource = Nothing
        dgBeneficiariosBanco.DataSource = Nothing
        dgBeneficiarios.Columns.Clear()
        dgBeneficiarios.Columns.Clear()
        Me.Dispose()
    End Sub

    Private Sub frmMaestro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.KeyPreview = True

        encabezado_fechas = "FECHA NACIMIENTO (EJEM. " & New Date(Now.Year, 12, 31).ToShortDateString & ")"
        encabezado_nombre = "NOMBRE (EJEM. AP PATERNO/AP MATERNO/NOMBRES)"

        Try
            cmbCia.FormattingEnabled = False
            dgContratos.AutoGenerateColumns = False
            ' Revisar acceso a los Tab
            RevisarAccesos()

            ' Ubicar la etiqueta de reingreso en la posición de Fecha de Baja
            lblReingreso.Left = lblBaja.Left + 3
            lblReingreso.Top = lblBaja.Top

            ' Ubicar los botones de control de vacaciones sobre la barra de navegación, pero invisibles

            btnCapturar.Parent = btnReporte.Parent
            btnAplicarVac.Parent = btnNuevo.Parent '	1102	            btnAplicarVac.Parent = btnEditar.Parent 
            btnCancelarVac.Parent = btnEditar.Parent '	1103	            btnCancelarVac.Parent = btnBorrar.Parent 
            btnBorrarVac.Parent = btnBorrar.Parent  '1104	 

            btnCapturar.Location = btnReporte.Location  '1106	            btnAplicarVac.Location = btnEditar.Location 
            btnAplicarVac.Location = btnNuevo.Location  '1107	            btnCancelarVac.Location = btnBorrar.Location 
            btnCancelarVac.Location = btnEditar.Location
            btnBorrarVac.Location = btnBorrar.Location

            btnCapturar.Visible = False     '1109	            btnCapturar.Visible = False 
            btnAplicarVac.Visible = False   '1110	            btnAplicarVac.Visible = False 
            btnCancelarVac.Visible = False  '1111	            btnCancelarVac.Visible = False 
            btnBorrarVac.Visible = False

            'btnCapturar.Parent = btnNuevo.Parent
            'btnAplicarVac.Parent = btnEditar.Parent
            'btnCancelarVac.Parent = btnBorrar.Parent

            'btnCapturar.Location = btnNuevo.Location
            'btnAplicarVac.Location = btnEditar.Location
            'btnCancelarVac.Location = btnBorrar.Location

            'btnCapturar.Visible = False
            'btnAplicarVac.Visible = False
            'btnCancelarVac.Visible = False

            'Cargar datos generales

            Dim dtfiltro2 As New DataTable
            dtfiltro2 = sqlExecute("select isnull (filtro2,'') as filtro2 from appuser where username='" & Usuario & "'", "SEGURIDAD")
            If dtfiltro2.Rows.Count > 0 Then
                Dim filtro2 As String = dtfiltro2.Rows(0)("filtro2")
                If filtro2.Trim <> "" Then
                    'MCR 28/ENERO/2016
                    'Cambio para evitar error cuando el filtro trae campos que no existen en CIAS
                    dtCias = sqlExecute("SELECT * FROM cias where cod_comp IN (SELECT DISTINCT cod_comp FROM personalVW WHERE " & filtro2 & ") order by CIA_DEFAULT desc")
                    If dtCias.Rows.Count <= 0 Then
                        dtCias = sqlExecute("SELECT * FROM cias order by CIA_DEFAULT desc")
                    End If
                Else
                    dtCias = sqlExecute("SELECT * FROM cias order by CIA_DEFAULT desc")
                End If
            Else
                dtCias = sqlExecute("SELECT * FROM cias order by CIA_DEFAULT desc")

            End If
            cmbCia.DataSource = dtCias
            dtBancos = sqlExecute("SELECT * FROM bancos")
            cmbBanco.DataSource = dtBancos
            cmbBanco.ValueMember = "banco"

            cmbBancoExp.DataSource = dtBancos
            cmbBancoExp.ValueMember = "banco"

            dtCodPago = sqlExecute("SELECT * FROM tipo_pago")
            cmbCodPago.DataSource = dtCodPago

            dtColonia = sqlExecute("select * from colonias")
            cmbColonia.DataSource = dtColonia

            dtCiudad = sqlExecute("SELECT cod_cd,ciudad.nombre,estados.nombre as estado FROM ciudad FULL OUTER JOIN estados ON ciudad.cod_edo = estados.cod_edo")
            dtCiudad.DefaultView.Sort = "cod_cd"
            cmbCd.DataSource = dtCiudad

            dtEstado = sqlExecute("SELECT cod_edo,nombre FROM estados")
            cmbLugarNac.DataSource = dtEstado

            dtCivil = sqlExecute("SELECT cod_civil,nombre FROM civil")
            cmbEdoCivil.DataSource = dtCivil

            dtBajaInterno = sqlExecute("SELECT cod_mot_ba, nombre FROM cod_mot_baj")
            'dtBajaInterno.DefaultView.Sort = "cod_mot_ba"
            cmbBajaInterno.DataSource = dtBajaInterno

            Dim dtSubmotivo As DataTable = sqlExecute("select * from cod_sub_baj")
            If dtSubmotivo.Rows.Count Then
                cmbsubmotivo.DataSource = dtSubmotivo
            End If

            CargaTipoCredInfonavit()

            dtBajaIMSS = sqlExecute("SELECT * FROM cod_mot_baj_imss")
            dtBajaIMSS.DefaultView.Sort = "cod_mot"
            cmbBajaIMSS.DataSource = dtBajaIMSS

            dtCampos = sqlExecute("SELECT DISTINCT UPPER(Campo) as 'campo' FROM bitacora_personal ORDER BY Campo")
            cmbHCCampo.DataSource = dtCampos

            dtUsuarios = sqlExecute("SELECT DISTINCT UPPER(Usuario) as 'usuario' FROM bitacora_personal ORDER BY Usuario")
            cmbHCUsuario.DataSource = dtUsuarios

            dtTipoMovs = sqlExecute("SELECT DISTINCT tipo_movimiento FROM bitacora_personal ORDER BY tipo_movimiento")
            cmbHCTipoMovimiento.DataSource = dtTipoMovs

            dtTemp = sqlExecute("SELECT MIN(fecha) as minfecha, max(fecha) as maxfecha FROM bitacora_personal")
            If dtTemp.Rows.Count > 0 Then
                dtHCFechaIni.Value = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("Minfecha")), Nothing, dtTemp.Rows.Item(0).Item("Minfecha"))
                dtHCFechaFin.Value = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("Maxfecha")), Nothing, dtTemp.Rows.Item(0).Item("Maxfecha"))
            End If

            'Configurar DataGrid de beneficiarios
            dgBeneficiarios.AutoGenerateColumns = False
            dgBeneficiariosBanco.AutoGenerateColumns = False
            dgBeneficiarios.Columns.Remove("colParentesco")
            dgBeneficiariosBanco.Columns.Remove("colParentescoBanco")

            Dim dgvCombo As New DevComponents.DotNetBar.Controls.DataGridViewComboBoxExColumn

            With dgvCombo
                .Width = 100
                .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                .DropDownStyle = ComboBoxStyle.DropDownList
                .DisplayControlForCurrentCellOnly = False
                dtTemp = sqlExecute("SELECT NOMBRE  FROM familia ORDER BY COD_FAMILIA")
                For Each dFam As DataRow In dtTemp.Rows
                    .Items.Add(dFam("nombre"))
                Next

                .DataPropertyName = "PARENTESCO"
                .HeaderText = "PARENTESCO"
                .Name = "colParentesco"
            End With
            dgBeneficiarios.Columns.Insert(2, dgvCombo)

            dgBeneficiariosBanco.Columns.Insert(2, dgvCombo.Clone)


            '===================Cargar datos para INFONAVIT
            '====Tipo de credito
            Dim dtTipoInfonavit As New DataTable, dtTipoMovimiento As New DataTable
            dtTipoInfonavit.Columns.Add("tipo", Type.GetType("System.String"))
            dtTipoInfonavit.Columns.Add("nombre", Type.GetType("System.String"))

            dtTipoInfonavit.Rows.Add({"1", "1.- Porcentaje"})
            dtTipoInfonavit.Rows.Add({"2", "2.- Cuota"})
            dtTipoInfonavit.Rows.Add({"3", "3.- VSM"})

            '====Tipo de movimiento
            dtTipoMovimiento = sqlExecute("SELECT *,'' as grupo FROM cod_mov_infonavit WHERE cod_movimiento <> 30 UNION " & _
                              "SELECT '99' AS cod_movimiento,'Borrar último registro de Infonavit' as nombre,'[X]' as grupo")
            cmbTipoMovInfonavit.DataSource = dtTipoMovimiento

            '===================END Datos de infonavit


            'REVISAR PROCESO DE VACACIONES
            'ESTA LENTO Y NO FUNCIONA ADECUADAMENTE

            ActualizaVacaciones()

            addInfoFirstTime = False

                '******* CARGAR Y MOSTRAR DATOS DEL VIEW GENERAL *********
                'sqlExecute("SELECT TOP 1 reloj from personalvw ORDER BY reloj", dtPersonal)
                'dtPersonal.DefaultView.Sort = "reloj"
                'Reloj = dtPersonal.Rows.Item(0).Item("RELOJ")

            tbInfo.SelectedTabIndex = 0
            tbGral = True
            MostrarInformacion(ConsultaReloj)
            ConsultaReloj = ""
            HabilitarMaestro()
            chkShowSalary.Enabled = True ' Habilitar que pueda ver sueldos solo a los que tenga acceso a sueldos


            CargarReportes()
                '**********************************************************
            sqlClose()
                'Me.vwrReportes.RefreshReport()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("La carga de información generó errores. Si el problema persiste, contacte al administrador del sistema." & _
                             vbCrLf & vbCrLf & "Err.- " & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub CargarReportes()
        Dim Creados As Boolean
        Dim Cadena As String
        Dim D As Integer
        Dim O As Windows.Forms.SortOrder
        Try
            dtReportes = New DataTable
            If dgReportes.SortedColumn Is Nothing Then
                D = 0
                O = SortOrder.Ascending
            Else
                D = dgReportes.SortedColumn.Index
                O = dgReportes.SortOrder
            End If

            Cadena = "SELECT DISTINCT reportes.NOMBRE,reportes.TIPO,(100*VECES_ACCESO)/((SELECT MAX(veces_acceso) FROM reportes)+1) " & _
                "AS Frecuencia,reportes.FECHA,FILTRAR FROM REPORTES  " & _
                "LEFT JOIN SEGURIDAD.dbo.permisos ON reportes.nombre = permisos.control WHERE " & _
                IIf(Creados, " reportes.tipo<>'U' AND ", "") & " cod_perfil " & Perfil & _
                " AND permisos.modulo = 'PER' and permisos.acceso = 1 AND individual = 1 ORDER BY reportes.nombre"

            dtReportes = sqlExecute(Cadena)
            dgReportes.DataSource = dtReportes
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub RevisarAccesos()
        Dim Acceso As Boolean
        Dim i As Integer
        Try
            'Revisar cada control dentro del panel
            i = 0
            For Each c In tbInfo.Tabs
                'Si se tiene acceso a alguno de los subitems, o no tiene subitems, revisar acceso del botón
                dtTemp = sqlExecute("SELECT acceso FROM permisos WHERE tipo = 'T' AND control = '" & c.name & "' AND cod_perfil " & Perfil, "Seguridad")
                Acceso = False
                If dtTemp.Rows.Count > 0 Then
                    Acceso = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("acceso")), False, dtTemp.Rows.Item(0).Item("acceso") = 1)
                End If
                c.visible = Acceso
                If Acceso Then i = i + 1
                If c.name = "tabHistorial" Then
                    AccesoHistorial = Acceso
                End If
            Next
            tbInfo.Visible = i > 0

            'Si se tiene acceso al botón de borrar
            dtTemp = sqlExecute("SELECT acceso FROM permisos WHERE tipo = 'T' AND control = 'btnBorrar' AND cod_perfil " & Perfil, "Seguridad")
            Acceso = False
            If dtTemp.Rows.Count > 0 Then
                Acceso = IIf(IsDBNull(dtTemp.Rows.Item(0).Item("acceso")), False, dtTemp.Rows.Item(0).Item("acceso") = 1)
            End If
            btnBorrar.Visible = Acceso

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub MostrarInformacion(ByVal rl As String)

        'Carga nuevamente los catálogos cada vez que se selecciona un nuevo empleado para asegurar que estén completos
        refrescar_cia()

        Dim ArchivoFoto As String
        Dim a As Date, b As Date
        Dim Cadena As String
        Dim SI As Integer = 0
        Dim drEmpleado As DataRow
        Dim dtReingreso As New DataTable
        Dim dtTransferencias As New DataTable

        Dim InfoST As New DevComponents.DotNetBar.SuperTooltipInfo
        Dim AltaVacacionST As New DevComponents.DotNetBar.SuperTooltipInfo

        'Inicializar variables globales
        _finicio_cred_infonavit = ""

        Try
            SI = tbInfo.SelectedTabIndex
            If rl <> "" Then
                dtPersonal = ConsultaPersonalVW("SELECT * from personalvw WHERE reloj = '" & rl & "'")
            Else
                dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * from personalvw ORDER BY reloj")
                rl = IIf(IsDBNull(dtPersonal.Rows(0).Item("reloj")), "", dtPersonal.Rows(0).Item("reloj"))
            End If

            If dtPersonal.Rows.Count = 0 Then Exit Sub
            drEmpleado = dtPersonal.Rows(0)
            Compania = IIf(IsDBNull(drEmpleado("cod_comp")), "", drEmpleado("cod_comp"))
            If Compania.Trim = "610" Then
                Label85.Text = "ID Success Factors"
            ElseIf Compania.Trim = "002" Then
                Label85.Text = "Reloj Alterno"
            Else
                Label85.Text = "ID SAP"
            End If
            txtReloj.Text = IIf(IsDBNull(drEmpleado("reloj")), "", drEmpleado("reloj"))
            txtNombre.Text = Trim(IIf(IsDBNull(drEmpleado("nombre")), "", drEmpleado("nombre")))
            txtApaterno.Text = Trim(IIf(IsDBNull(drEmpleado("apaterno")), "", drEmpleado("apaterno")))
            txtAmaterno.Text = Trim(IIf(IsDBNull(drEmpleado("amaterno")), "", drEmpleado("amaterno")))

            txtAlta.Value = IIf(IsDBNull(drEmpleado("alta")), Nothing, drEmpleado("alta"))
            EsBaja = Not IsDBNull(drEmpleado("baja"))
            txtBaja.Value = IIf(EsBaja, drEmpleado("baja"), Nothing)

            cmbCia.SelectedValue = IIf(IsDBNull(drEmpleado("cod_comp")), "", drEmpleado("cod_comp"))
            cmbPlanta.SelectedValue = IIf(IsDBNull(drEmpleado("cod_planta")), "", drEmpleado("cod_planta"))
            cmbArea.SelectedValue = IIf(IsDBNull(drEmpleado("cod_area")), "", drEmpleado("cod_area")).ToString.Trim
            cmbRegFiscSAT.SelectedValue = IIf(IsDBNull(drEmpleado("COD_REG_SAT")), "", drEmpleado("COD_REG_SAT")).ToString.Trim

            cmbDepto.SelectedValue = IIf(IsDBNull(drEmpleado("cod_depto")), "", drEmpleado("cod_depto"))
            cmbSuper.SelectedValue = IIf(IsDBNull(drEmpleado("cod_super")), "", drEmpleado("cod_super"))

            '==MOSTRAR LIDER DEL EMPLEADO           10Dic2021           Ernesto
            'Dim liderStr As String = IIf(IsDBNull(drEmpleado("cod_linea")), "", drEmpleado("cod_linea").ToString.Trim)
            cmbLider.SelectedValue = IIf(IsDBNull(drEmpleado("cod_linea")), "", drEmpleado("cod_linea"))


            cmbPuesto.SelectedValue = IIf(IsDBNull(drEmpleado("cod_puesto")), "", drEmpleado("cod_puesto"))
            cmbTipo.SelectedValue = IIf(IsDBNull(drEmpleado("cod_tipo")), "", drEmpleado("cod_tipo"))
            cmbClase.SelectedValue = IIf(IsDBNull(drEmpleado("cod_clase")), "", drEmpleado("cod_clase"))
            cmbHorario.SelectedValue = IIf(IsDBNull(drEmpleado("cod_hora")), "", drEmpleado("cod_hora"))
            cmbTurno.SelectedValue = IIf(IsDBNull(drEmpleado("cod_turno")), "", drEmpleado("cod_turno"))
            cmbCCostos.SelectedValue = IIf(IsDBNull(drEmpleado("centro_costos")), "", drEmpleado("centro_costos"))

            ' cmbClerk.SelectedValue = IIf(IsDBNull(drEmpleado("cod_clerk")), "", drEmpleado("cod_clerk"))
            '  cmbSindicalizado.SelectedValue = IIf(IsDBNull(drEmpleado("sindicalizado")), "", drEmpleado("sindicalizado"))
            cmbTipoPeriodo.SelectedValue = IIf(IsDBNull(drEmpleado("tipo_periodo")), "", drEmpleado("tipo_periodo"))

            txtIMSS.Text = IIf(IsDBNull(drEmpleado("imss")), "", drEmpleado("imss"))
            txtIMSSdv.Text = IIf(IsDBNull(drEmpleado("dig_ver")), "", drEmpleado("dig_ver"))

            txtRFC.Text = IIf(IsDBNull(drEmpleado("RFC")), "", drEmpleado("RFC"))
            txtCurp.Text = IIf(IsDBNull(drEmpleado("Curp")), "", drEmpleado("Curp"))
            'bntSexo = False -> Masculino
            If IsDBNull(drEmpleado("sexo")) Then
                btnSexo.Value = False
            Else
                btnSexo.Value = drEmpleado("sexo") = "F"
            End If

            'Estatus inactivo, Abraham Casas
            Try
                If IsDBNull(drEmpleado("inactivo")) Then
                    sbInactivo.Value = False
                Else
                    sbInactivo.Value = drEmpleado("inactivo")
                End If
            Catch ex As Exception

            End Try

            txtCpSAT.Text = IIf(IsDBNull(drEmpleado("cp_sat")), "", drEmpleado("cp_sat"))

            txtGafete.Text = IIf(IsDBNull(drEmpleado("Gafete")), "", drEmpleado("Gafete"))
            chkChecaTarjeta.Checked = IIf(IsDBNull(drEmpleado("checa_tarjeta")), False, drEmpleado("checa_tarjeta"))

            cmbCodPago.SelectedValue = IIf(IsDBNull(drEmpleado("tipo_pago")), "", drEmpleado("tipo_pago"))
            cmbBanco.SelectedValue = IIf(IsDBNull(drEmpleado("banco")), "", drEmpleado("banco"))
            txtCuenta.Text = IIf(IsDBNull(drEmpleado("cuenta_banco")), 0, drEmpleado("cuenta_banco"))

            cmbNivel.SelectedValue = IIf(IsDBNull(drEmpleado("nivel")), "", drEmpleado("nivel"))
            txtSActual.Text = FormatCurrency(IIf(IsDBNull(drEmpleado("sactual")), 0, drEmpleado("sactual")))
            txtFactorInt.Text = IIf(IsDBNull(drEmpleado("factor_int")), 0, drEmpleado("factor_int"))
            txtProVar.Text = FormatCurrency(IIf(IsDBNull(drEmpleado("pro_var")), 0, drEmpleado("pro_var")))
            txtIntegrado.Text = FormatCurrency(IIf(IsDBNull(drEmpleado("integrado")), 0, drEmpleado("integrado")))
            txtUltimaMod.Text = IIf(IsDBNull(drEmpleado("fha_ult_mo")), 0, drEmpleado("fha_ult_mo"))
            txtSAnterior.Text = FormatCurrency(IIf(IsDBNull(drEmpleado("sal_ant")), 0, drEmpleado("sal_ant")))
            txtCompaRatio.Text = IIf(IsDBNull(drEmpleado("COMPA_RATIO")), 0, drEmpleado("COMPA_RATIO"))
            Dim tipocodtemp As String = IIf(IsDBNull(drEmpleado("cod_tipo")), "", drEmpleado("cod_tipo"))
            If tipocodtemp.Trim.Equals("") Or tipocodtemp.Trim.Equals("O") Then
                ' pnlSueldos1.Height = 48
                gpSueldos.Height = 200
            Else
                ' pnlSueldos1.Height = 70
                gpSueldos.Height = 222

            End If
            flwSueldos.Height = gpSueldos.Height - 28

            '--- Mostrar o no sueldos
            If (chkShowSalary.Checked = True) Then
                '  pnlSueldos1.Visible = True
                pnlSueldos2.Visible = True
            End If

            If (chkShowSalary.Checked = False) Then
                '  pnlSueldos1.Visible = False
                pnlSueldos2.Visible = False
            End If


            '-- AOS: Etiqueta usada para el ID_SAP, reloj alterno o algo similar
            Try
                '  Dim sf As String = IIf(IsDBNull(drEmpleado("reloj_alt")), "", RTrim(drEmpleado("reloj_alt")))
                Dim reloj_alt As String = ""
                Try : reloj_alt = drEmpleado("reloj_alt") : Catch ex As Exception : reloj_alt = "" : End Try

                If reloj_alt <> "" Then
                    LabelXSF.Visible = True
                    Label85.Visible = True
                    LabelXSF.Text = reloj_alt
                Else
                    LabelXSF.Visible = False
                    Label85.Visible = False
                    LabelXSF.Text = ""
                End If
            Catch ex As Exception
                LabelXSF.Visible = False
                Label85.Visible = False
                LabelXSF.Text = ""
            End Try


            '*** TRANSFERENCIAS
            Dim Alta As String
            Dim Baja As String
            dtTransferencias = sqlExecute("SELECT TOP 1 * FROM transferencias WHERE reloj_nuevo = '" & rl & "' ORDER BY ALTA DESC")
            If dtTransferencias.Rows.Count > 0 Then
                picTransferencia.Visible = True
                InfoST.HeaderText = "TRANSFERENCIA"
                If Not IsDBNull(dtTransferencias.Rows(0)("alta_anterior")) Then
                    Alta = FechaCortaLetra(dtTransferencias.Rows(0)("alta_anterior"))
                Else
                    Alta = ""
                End If

                If Not IsDBNull(dtTransferencias.Rows(0)("baja_anterior")) Then
                    Baja = FechaCortaLetra(dtTransferencias.Rows(0)("baja_anterior"))
                Else
                    Baja = ""
                End If

                InfoST.BodyText = "De la compañía: " & dtTransferencias.Rows(0)("cod_comp_anterior") & vbCrLf & vbCrLf & _
                    "Alta anterior: " & Alta & vbCrLf & _
                    "Baja anterior: " & Baja
                InfoST.FooterText = "RELOJ ANTERIOR " & dtTransferencias.Rows(0)("reloj_anterior")
                InfoST.BodyImage = My.Resources.go_into48
                InfoST.FooterImage = My.Resources.Favorite16
                InfoST.Color = DevComponents.DotNetBar.eTooltipColor.BlueMist

                SuperTooltip1.SetSuperTooltip(picTransferencia, InfoST)
            Else
                dtTransferencias = sqlExecute("SELECT TOP 1 * FROM transferencias WHERE reloj_anterior = '" & rl & "' ORDER BY ALTA DESC")
                If dtTransferencias.Rows.Count > 0 Then
                    picTransferencia.Visible = True
                    InfoST.HeaderText = "TRANSFERENCIA"
                    If Not IsDBNull(dtTransferencias.Rows(0)("alta")) Then
                        Alta = FechaCortaLetra(dtTransferencias.Rows(0)("alta"))
                    Else
                        Alta = ""
                    End If

                    If Not IsDBNull(dtTransferencias.Rows(0)("baja")) Then
                        Baja = FechaCortaLetra(dtTransferencias.Rows(0)("baja"))
                    Else
                        Baja = ""
                    End If
                    InfoST.BodyText = "A la compañía: " & dtTransferencias.Rows(0)("cod_comp_nuevo") & vbCrLf & vbCrLf & _
                        "Alta nueva: " & Alta & vbCrLf & _
                        "Baja nueva: " & Baja
                    InfoST.FooterText = "RELOJ NUEVO " & dtTransferencias.Rows(0)("reloj_nuevo")
                    InfoST.BodyImage = My.Resources.go_back48
                    InfoST.FooterImage = My.Resources.Favorite16
                    InfoST.Color = DevComponents.DotNetBar.eTooltipColor.Gray
                    SuperTooltip1.SetSuperTooltip(picTransferencia, InfoST)
                Else

                    picTransferencia.Visible = False
                End If
            End If


            ' **********************************************************************************

            Dim dtAltaVacacion As DataTable = sqlExecute("SELECT reloj, alta, alta_vacacion FROM personal WHERE reloj = '" & rl & "' and alta_vacacion is not null and alta <> alta_vacacion")
            If dtAltaVacacion.Rows.Count > 0 Then
                Dim _alta As String = ""
                Dim _alta_vacaciones As String = ""

                picAltaVacacion.Visible = True
                AltaVacacionST.HeaderText = "Alta vacaciones"
                If Not IsDBNull(dtAltaVacacion.Rows(0)("alta")) Then
                    _alta = FechaCortaLetra(dtAltaVacacion.Rows(0)("alta"))
                Else
                    _alta = ""
                End If

                If Not IsDBNull(dtAltaVacacion.Rows(0)("alta_vacacion")) Then
                    _alta_vacaciones = FechaCortaLetra(dtAltaVacacion.Rows(0)("alta_vacacion"))
                Else
                    _alta_vacaciones = ""
                End If

                AltaVacacionST.BodyText =
                    "Fecha de alta: " & vbCrLf & _alta & vbCrLf & _
                    "Fecha de antigüedad: " & vbCrLf & _alta_vacaciones

                AltaVacacionST.BodyImage = My.Resources.Information48
                AltaVacacionST.Color = DevComponents.DotNetBar.eTooltipColor.BlueMist

                SuperTooltip1.SetSuperTooltip(picAltaVacacion, AltaVacacionST)
            Else
                picAltaVacacion.Visible = False
            End If

            ' **********************************************************************************

            '* Pantalla de eExpediente\personal
            txtDireccion.Text = IIf(IsDBNull(drEmpleado("direccion")), "", drEmpleado("direccion"))
            txtTelefono.Text = IIf(IsDBNull(drEmpleado("telefono")), "", drEmpleado("telefono"))
            txtTelefono2.Text = IIf(IsDBNull(drEmpleado("telefono2")), "", drEmpleado("telefono2"))
            txtTelefono3.Text = IIf(IsDBNull(drEmpleado("telefono3")), "", drEmpleado("telefono3"))

            Try
                txtTelefono4.Text = IIf(IsDBNull(drEmpleado("telefono4")), "", drEmpleado("telefono4"))
                txtTelefono5.Text = IIf(IsDBNull(drEmpleado("telefono5")), "", drEmpleado("telefono5"))
            Catch ex As Exception

            End Try



            cmbColonia.SelectedValue = IIf(IsDBNull(drEmpleado("cod_col")), "", drEmpleado("cod_col"))
            txtUMF.Text = IIf(IsDBNull(drEmpleado("umf")), txtUMF.Text, drEmpleado("umf"))

            cmbCd.SelectedValue = IIf(IsDBNull(drEmpleado("cod_cd")), "", drEmpleado("cod_cd"))

            cmbLugarNac.SelectedValue = IIf(IsDBNull(drEmpleado("lugarn")), "", drEmpleado("lugarn"))

            If IsDBNull(drEmpleado("fha_nac")) Then
                txtFechaNac.Value = RFCaFechaNac(IIf(IsDBNull(drEmpleado("rfc")), "", drEmpleado("rfc")))
            ElseIf drEmpleado("fha_nac") = New Date(1900, 1, 1) Then
                txtFechaNac.Value = RFCaFechaNac(IIf(IsDBNull(drEmpleado("rfc")), "", drEmpleado("rfc")))
            Else
                txtFechaNac.Value = IIf(IsDBNull(drEmpleado("fha_nac")), "", drEmpleado("fha_nac"))
            End If

            cmbEdoCivil.SelectedValue = IIf(IsDBNull(drEmpleado("cod_civil")), "", drEmpleado("cod_civil"))

            txtEmail_empl.Text = RTrim(IIf(IsDBNull(drEmpleado("email")), "", drEmpleado("email")))

            txtEmailEmpresa.Text = RTrim(IIf(IsDBNull(drEmpleado("email_empresa")), "", drEmpleado("email_empresa")))

            Try
                txtLocker.Text = RTrim(IIf(IsDBNull(drEmpleado("locker")), "", drEmpleado("locker")))
                txtCandado.Text = RTrim(IIf(IsDBNull(drEmpleado("candado")), "", drEmpleado("candado")))
                txtCombinacion.Text = RTrim(IIf(IsDBNull(drEmpleado("combinacion")), "", drEmpleado("combinacion")))
            Catch ex As Exception

            End Try


            txtAccidente.Text = IIf(IsDBNull(drEmpleado("aviso_acc")), "", drEmpleado("aviso_acc"))

            '* Pantalla de expediente\infonavit
            'If IsDBNull(drEmpleado("credito_in")) Then
            '    btnCredito.Value = False
            'Else
            '    btnCredito.Value = drEmpleado("credito_in")
            'End If

            'cmbTipoCredito.SelectedValue = IIf(IsDBNull(drEmpleado("tipo_cre")), "", drEmpleado("tipo_cre"))
            'txtInfonavit.Text = IIf(IsDBNull(drEmpleado("infonavit")), "", drEmpleado("infonavit"))
            'txtInfonavitDV.Text = IIf(IsDBNull(drEmpleado("dig_ver_in")), "", drEmpleado("dig_ver_in"))
            'dtFechaInfonavit.Value = IIf(IsDBNull(drEmpleado("fecha_cre")), Nothing, drEmpleado("fecha_cre"))

            'txtPagoInfonavit.Text = IIf(IsDBNull(drEmpleado("pago_inf")), 0, drEmpleado("pago_inf"))

            '**** Información Expediente\Comentarios
            txtComentarios.Text = IIf(IsDBNull(drEmpleado("comentario")), "", drEmpleado("comentario"))

            ' *** Expediente\ información de baja - reingresos ***
            a = IIf(IsDBNull(drEmpleado("alta")), Nothing, drEmpleado("alta"))
            b = IIf(IsDBNull(drEmpleado("baja")), Nothing, drEmpleado("baja"))
            txtEAlta.Text = a.ToString
            txtEBaja.Text = IIf(IsNothing(b), "", b.ToString)
            txtNotasBaja.Text = IIf(IsDBNull(drEmpleado("notas_baja")), "", drEmpleado("notas_baja")) ' 2022-06-24 Sergio Núñez
            If EsBaja Then
                txtAntiguedad.Text = AntiguedadExacta(a, b)
            Else
                txtAntiguedad.Text = AntiguedadExacta(a, Today)
            End If

            If IsDBNull(drEmpleado("cod_mot_ba")) Then
                cmbBajaInterno.SelectedIndex = -1
            ElseIf drEmpleado("cod_mot_ba") = "" Then
                cmbBajaInterno.SelectedIndex = -1
            Else
                cmbBajaInterno.SelectedValue = drEmpleado("cod_mot_ba")
            End If

            If IsDBNull(drEmpleado("cod_sub_ba")) Then
                cmbsubmotivo.SelectedIndex = -1
            ElseIf drEmpleado("cod_sub_ba") = "" Then
                cmbsubmotivo.SelectedIndex = -1
            Else
                cmbsubmotivo.SelectedValue = drEmpleado("cod_sub_ba")
            End If

            If IsDBNull(drEmpleado("cod_mot_im")) Then
                cmbBajaIMSS.SelectedIndex = -1
            ElseIf drEmpleado("cod_mot_im") = "" Then
                cmbBajaIMSS.SelectedIndex = -1
            Else
                cmbBajaIMSS.SelectedValue = drEmpleado("cod_mot_im")
            End If

            sbrecontrata.Value = IIf(IsDBNull(drEmpleado("recontrata")), 1, drEmpleado("recontrata"))

            If IsDBNull(drEmpleado("cod_sub_ba")) Then
                cmbsubmotivo.SelectedIndex = -1
            ElseIf drEmpleado("cod_sub_ba") = "" Then
                cmbsubmotivo.SelectedIndex = -1
            Else
                cmbsubmotivo.SelectedValue = drEmpleado("cod_sub_ba")
            End If

            'REINGRESOS
            Cadena = "SELECT reingresos.fecha AS 'FECHA',reingresos.alta as 'ALTA', reingresos.alta_ant AS 'ALTA ANTERIOR', reingresos.baja_ant AS 'BAJA ANTERIOR', cod_mot_baj.NOMBRE AS 'MOTIVO INTERNO', cod_mot_baj_imss.MOTIVO AS 'MOTIVO IMSS'"
            Cadena = Cadena & "FROM reingresos LEFT OUTER JOIN cod_mot_baj ON reingresos.cod_mot_ba = cod_mot_baj.COD_MOT_BA"
            Cadena = Cadena & " LEFT OUTER JOIN cod_mot_baj_imss ON reingresos.cod_mot_im = cod_mot_baj_imss.COD_MOT WHERE reloj = '" & rl & "'"

            dtReingreso = sqlExecute(Cadena)

            Reingreso = dtReingreso.Rows.Count > 0
            gpReingreso.Visible = Reingreso

            dgReingreso.DataSource = dtReingreso
            For x = 0 To 3
                dgReingreso.Columns.Item(x).Width = 75
            Next
            dgReingreso.Columns.Item(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            dgReingreso.Columns.Item(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            '*******************************************

            '* Expediente\tarjetas
            cmbBancoExp.SelectedValue = IIf(IsDBNull(drEmpleado("banco")), "", drEmpleado("banco"))
            txtCuentaExp.Text = IIf(IsDBNull(drEmpleado("cuenta_banco")), "", drEmpleado("cuenta_banco").ToString.Trim)
            txtTarjeta.Text = IIf(IsDBNull(drEmpleado("tarjeta_banco")), "", drEmpleado("tarjeta_banco").ToString.Trim)
            txtClabe.Text = IIf(IsDBNull(drEmpleado("clabe")), "", drEmpleado("clabe").ToString.Trim)
            'txtNombre1.Text = IIf(IsDBNull(drEmpleado("beneficiario1")), "", drEmpleado("beneficiario1"))
            'cmbParentesco1.SelectedValue = IIf(IsDBNull(drEmpleado("parentesco_ben1")), "", drEmpleado("parentesco_ben1"))
            'dblPorcentaje1.Value = IIf(IsDBNull(drEmpleado("porcentaje_ben1")), 0, drEmpleado("porcentaje_ben1"))
            'txtNombre2.Text = IIf(IsDBNull(drEmpleado("beneficiario2")), "", drEmpleado("beneficiario2"))
            'cmbParentesco2.SelectedValue = IIf(IsDBNull(drEmpleado("parentesco_ben2")), "", drEmpleado("parentesco_ben2"))
            'dblPorcentaje2.Value = IIf(IsDBNull(drEmpleado("porcentaje_ben2")), 0, drEmpleado("porcentaje_ben2"))
            'txtNombre3.Text = IIf(IsDBNull(drEmpleado("beneficiario3")), "", drEmpleado("beneficiario3"))
            'cmbParentesco3.SelectedValue = IIf(IsDBNull(drEmpleado("parentesco_ben3")), "", drEmpleado("parentesco_ben3"))
            'dblPorcentaje3.Value = IIf(IsDBNull(drEmpleado("porcentaje_ben3")), 0, drEmpleado("porcentaje_ben3"))
            'txtNombre4.Text = IIf(IsDBNull(drEmpleado("beneficiario4")), "", drEmpleado("beneficiario4"))
            'cmbParentesco4.SelectedValue = IIf(IsDBNull(drEmpleado("parentesco_ben4")), "", drEmpleado("parentesco_ben4"))
            'dblPorcentaje4.Value = IIf(IsDBNull(drEmpleado("porcentaje_ben4")), 0, drEmpleado("porcentaje_ben4"))

            txtIDBonos.Text = IIf(IsDBNull(drEmpleado("id_bonos")), "", drEmpleado("id_bonos"))
            txtCuentaBonos.Text = IIf(IsDBNull(drEmpleado("cuenta_bonos")), "", drEmpleado("cuenta_bonos"))
            txtTarjetaBonos.Text = IIf(IsDBNull(drEmpleado("tarjeta_bonos")), "", drEmpleado("tarjeta_bonos"))
            txtTarjetaAdicBonos.Text = IIf(IsDBNull(drEmpleado("adicional_bonos")), "", drEmpleado("adicional_bonos"))

            '* Pantalla de vacaciones
            txtPlanta.Text = IIf(IsDBNull(drEmpleado("cod_planta")), "", drEmpleado("cod_planta"))
            txtTipoEmp.Text = IIf(IsDBNull(drEmpleado("cod_tipo")), "", drEmpleado("cod_tipo"))
            txtDepto.Text = IIf(IsDBNull(drEmpleado("cod_depto")), "", drEmpleado("cod_depto"))
            txtSupervisor.Text = IIf(IsDBNull(drEmpleado("cod_super")), "", drEmpleado("cod_super"))
            txtClase.Text = IIf(IsDBNull(drEmpleado("cod_clase")), "", drEmpleado("cod_clase"))
            txtTurno.Text = IIf(IsDBNull(drEmpleado("cod_turno")), "", drEmpleado("cod_turno"))
            txtPuesto.Text = IIf(IsDBNull(drEmpleado("cod_puesto")), "", drEmpleado("cod_puesto"))

            txtHorario.Text = IIf(IsDBNull(drEmpleado("cod_hora")), "", drEmpleado("cod_hora"))

            '* Pantallas adicionales
            RefrescaFamiliares(rl)
            RefrescaEscolaridad(rl)
            RefrescaAuxiliares(rl)
            RefrescaInfonavit(rl)
            Try
                RefrescaVacaciones(rl)
            Catch ex As Exception

            End Try


            '* Contratos generados
            dgContratos.DataSource = sqlExecute("select contratos_generados.tipo_contrato,contrato.nombre,fecha,contratos_generados.vigencia,fecha_vencimiento,usuario " & _
                                                "FROM contratos_generados LEFT JOIN contrato ON contratos_generados.tipo_contrato=CONTRATO.TIPO_CONT " & _
                                                "WHERE RELOJ = '" & rl & "' ORDER BY fecha_vencimiento DESC")

            Cadena = "SELECT tipo_mod_sal.nombre 'TIPO MOD.',"
            Cadena = Cadena & "cambio_de AS 'CAMBIO DE',mod_sal.nivel as 'NIVEL',cambio_a AS 'CAMBIO A',"
            Cadena = Cadena & "provar AS 'PROM.VAR.',mod_sal.fact_int AS 'FACT.INT.',mod_sal.integrado as 'INTEGRADO'"
            Cadena = Cadena & ",mod_sal.fecha as 'FECHA MOV.',mod_sal.fecha_aplicacion as 'FECHA APLICACION',mod_sal.notas as 'NOTAS' "
            Cadena = Cadena & " FROM mod_sal FULL OUTER JOIN personalvw ON personalvw.reloj = mod_sal.reloj FULL OUTER JOIN tipo_mod_sal on tipo_mod_sal.cod_tipo_mod = mod_sal.cod_tipo_mod WHERE aplicado=1 AND personalvw.reloj = '" & rl & "' ORDER BY HOY"
            dtModSal = sqlExecute(Cadena)
            dgSueldos.DataSource = dtModSal

            RefrescaHistorialCambios(rl)

            ' *** PROCESO PARA CARGAR FOTOGRAFIA ***
            Try
                ArchivoFoto = PathFoto & rl.Trim & ".jpg"
                If Dir(ArchivoFoto) = "" Then
                    picFoto.Image = My.Resources.NoFoto
                Else
                    picFoto.ImageLocation = ArchivoFoto
                End If

            Catch
                picFoto.Image = picFoto.ErrorImage
                picFoto.SizeMode = PictureBoxSizeMode.Zoom
            End Try

            '****************************************

            '**** PROCESO PARA MOSTRAR/OCULTAR SUELDO, DE ACUERDO AL NIVEL
            gpSueldos.Visible = IIf(IsDBNull(drEmpleado("nivel_seguridad")), 0, drEmpleado("nivel_seguridad")) <= NivelSueldos
            tabHistorial.Visible = IIf(IsDBNull(drEmpleado("nivel_seguridad")), 0, drEmpleado("nivel_seguridad")) <= NivelSueldos And AccesoHistorial
            tbInfo.SelectedTabIndex = SI
            tbInfo.Refresh()
            ' *****************************************************************

            '**** PROCESO PARA MOSTRAR/OCULTAR BOTONES DE EDICION, DE ACUERDO AL NIVEL
            PermisoEdicion = IIf(IsDBNull(drEmpleado("nivel_seguridad")), 0, drEmpleado("nivel_seguridad")) <= NivelEdicion
            'btnNuevo.Visible = PermisoEdicion And Not tbVac
            btnEditar.Visible = PermisoEdicion And Not tbVac
            'btnBorrar.Visible = PermisoEdicion And Not tbVac

            btnNuevo.Visible = Not tbVac And ((tbGral And PermisoEdicion) Or (Not tbGral And (Editar Or Nuevo)))
            btnCapturar.Visible = tbVac And PermisoEdicion

            ' *****************************************************************

            '***** PROCESO PARA CARGAR AUXILIARES SELECCIONADOS PARA MOSTRARSE EN PANTALLA DE PERSONAL *****
            dtAuxiliaresSeleccionados = New DataTable
            dtAuxiliaresSeleccionados = sqlExecute("SELECT auxiliares.campo AS codigo,auxiliares.nombre as campo," & _
                                                   "(SELECT contenido FROM detalle_auxiliares WHERE reloj = '" & rl & "' AND campo = auxiliares.campo) " & _
                                                   "AS contenido from auxiliares WHERE mostrar_personal = 1")
            dgAuxiliaresSeleccionados.DataSource = dtAuxiliaresSeleccionados
            '***********************************************************************************************


            '*** Cambios en bajas ****
            txtBaja.Visible = EsBaja
            lblBaja.Visible = EsBaja

            lblRecontrata.Visible = EsBaja And (sbrecontrata.Value = False)

            btnBaja.Text = IIf(EsBaja, "&Procesar reingreso", "&Dar de baja")
            lblEstado.Text = IIf(EsBaja, "INACTIVO", "ACTIVO")
            lblEstado.BackColor = IIf(EsBaja, Color.IndianRed, Color.LimeGreen)
            If EsBaja Then
                Highlighter1.SetHighlightColor(txtReloj, DevComponents.DotNetBar.Validator.eHighlightColor.Red)
            Else
                Highlighter1.SetHighlightColor(txtReloj, DevComponents.DotNetBar.Validator.eHighlightColor.Green)
            End If

            txtReloj.BackColor = lblEstado.BackColor

            gbReloj.Refresh()

            lblReingreso.Visible = Not EsBaja And Reingreso

            '*************************

            RefrescaFamiliares(txtReloj.Text)
            CrearDTCambiosFamilia()
            RefrescaEscolaridad(txtReloj.Text)
            CrearDTCambiosEscolaridad()
            RefrescaAuxiliares(txtReloj.Text)
            CrearDTCambiosAuxiliares()
            RefrescaInfonavit(txtReloj.Text)

            '----Refresca los cambios referente a los documentos del empleado
            RefrescaDocumentos(txtReloj.Text)

            ''********************
            CargarPrestaciones(txtReloj.Text)

            'Mostrar siempre los controles del perfil		linea:1973
            revisarPerfiles(Perfil, Me, Editar, cmbCia.SelectedValue, txtReloj.Text.ToString.Trim)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("La información no pudo ser cargada exitosamente. Si el problema persiste, contacte al administrador del sistema." & _
                            vbCrLf & vbCrLf & "Err.- " & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub RefrescaHistorialCambios(ByVal rl As String, Optional Filtro As String = "")
        Try
            If Filtro <> "" Then
                Filtro = " AND (" & Filtro & ")"
            End If
            Filtro = " WHERE reloj = '" & rl & "' AND campo NOT IN ('sal_ant','sactual','integrado','nivel','fha_ult_mo','pro_var','factor_int')" & Filtro
            dtCambios = sqlExecute("SELECT UPPER(CAMPO) AS 'CAMPO',valoranterior AS 'VALOR ANTERIOR',valornuevo AS 'VALOR NUEVO',USUARIO,FECHA,tipo_movimiento AS 'TIPO DE MOV.' FROM bitacora_personal " & Filtro & " ORDER BY fecha DESC")
            dgCambios.DataSource = dtCambios
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub ActualizaVacaciones()
        Dim rl As String
        Dim cm As String
        Dim tp As String
        Dim an As Integer
        Dim dtPersonalVac As New DataTable
        Dim _diasVac As Integer = 0
        Dim _Prima As Decimal = 0
        Dim _cadena As String

        Dim Antiguedad As Integer = DateDiff(DateInterval.Year, txtAlta.Value, Now)
        Dim _alta As Date = txtAlta.Value
        Dim _f_aniversario As Date
        Dim _f_anterior As Date
        Dim _dinero As Double = 0
        Dim _tiempo As Double = 0

        Try
            'Seleccionar los empleados que tengan más de 1 año trabajando, y su fecha de aniversario sea el día de hoy o antes
            '_cadena = "SELECT cod_comp,cod_tipo,reloj,alta,CAST((STR(YEAR(GETDATE()))+ '-' + STR(MONTH(alta),2) + '-' + STR(DAY(alta),2)) AS DATE) AS aniversario,CAST((STR(YEAR(GETDATE())-1)+ '-' + STR(MONTH(alta),2) + '-' + STR(DAY(alta),2)) AS DATE) AS anteriorAniv from personalvw "
            '_cadena = _cadena & " WHERE baja IS NULL AND CAST((STR(YEAR(GETDATE()))+ '-' + STR(MONTH(alta),2) + '-' + STR(DAY(alta),2)) AS DATE)<=GETDATE()"
            '_cadena = _cadena & " AND DATEDIFF(YEAR,alta,GETDATE())>0"
            _cadena = "SELECT cod_comp,cod_tipo,reloj,alta,DATEADD(YEAR,DATEDIFF(YEAR,ALTA,GETDATE()),ALTA)  AS aniversario," & _
                "DATEADD(YEAR,DATEDIFF(YEAR,ALTA,GETDATE())-1,ALTA)  AS anteriorAniv from personalvw " & _
                "WHERE baja Is NULL And NOT cod_tipo IS NULL and " & _
                "DateAdd(Year, DateDiff(Year, ALTA, GETDATE()), ALTA) <= GETDATE() And DateDiff(Year, alta, GETDATE()) > 0 " & _
                "ORDER BY ANIVERSARIO"
            dtPersonalVac = sqlExecute(_cadena)

            '***** PARA ACTUALIZAR SALDOS CUANDO CUMPLEN ANIVERSARIO
            For Each dVac As DataRow In dtPersonalVac.Rows
                rl = dVac("reloj")
                cm = dVac("cod_comp")
                tp = dVac("cod_tipo")
                an = DateDiff(DateInterval.Year, dVac("alta"), Now)

                _f_aniversario = dVac("aniversario")
                _f_anterior = dVac("anteriorAniv")
                _diasVac = 0
                _Prima = 0
                dtTemp = sqlExecute("SELECT reloj FROM saldos_vacaciones WHERE reloj = '" & rl & "' AND ano = '" & Year(_f_aniversario) & "' AND aniversario = 1")

                '*** Si ya pasó su aniversario, y no se le han actualizado los saldos, crear registro de aniversario
                If dtTemp.Rows.Count = 0 Then
                    '*** Tomar los saldos anteriores
                    dtTemp = sqlExecute("SELECT TOP 1 saldo_dinero, saldo_tiempo FROM saldos_vacaciones WHERE " & _
                                        "reloj = '" & rl & "' ORDER BY fecha_captura DESC,fecha_fin DESC")
                    If dtTemp.Rows.Count > 0 Then
                        _dinero = dtTemp.Rows.Item(0).Item("saldo_dinero")
                        _tiempo = dtTemp.Rows.Item(0).Item("saldo_tiempo")
                    End If

                    dtTemp = sqlExecute("SELECT dias, por_prima FROM vacaciones WHERE " & _
                                        "cod_comp = '" & cm & "' AND cod_tipo = '" & tp & "' AND anos = " & an)

                    If dtTemp.Rows.Count > 0 Then
                        _diasVac = dtTemp.Rows.Item(0).Item("dias")
                        _Prima = dtTemp.Rows.Item(0).Item("por_prima")

                        '---Para que no actualice vacaciones por aniv antes de la fecha de carga inicial de vacaciones
                        If FechaSQL(_f_aniversario) > "2024-04-06" Then

                            sqlExecute("INSERT INTO saldos_vacaciones (reloj,ano,dias,prima,saldo_dinero,saldo_tiempo,comentario,aniversario," & _
                                       "fecha_ini,fecha_fin,fecha_captura) VALUES ('" & _
                                       rl & "','" & _
                                       Year(_f_aniversario) & "'," & _
                                       _diasVac & "," & _
                                       _Prima & "," & _
                                       (_dinero + _diasVac) & "," & _
                                       (_tiempo + _diasVac) & _
                                       ",'ANIVERSARIO " & Year(_f_aniversario) & "'," & _
                                       "1,'" & _
                                       FechaSQL(_f_anterior) & "','" & _
                                       FechaSQL(_f_aniversario) & "','" & _
                                       FechaHoraSQL(Now) & "')")

                        End If
                        '---END: Para que no actualice vacaciones por aniv antes d ela fecha de la carga inicial de vacaciones en PIDA
                    End If

                End If
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub InfoEnBlanco(Optional BorrarNombreYRelojCapturados As Boolean = True)
        Dim dtInfo As New DataTable
        Dim dtPredeterminados As New DataTable
        'Dim ArchivoFoto As String
        Try
            lblEstado.Text = "ALTA  NVA."
            lblReingreso.Visible = False

            If BorrarNombreYRelojCapturados Then
                txtReloj.Text = ""
                txtNombre.Text = ""
                txtApaterno.Text = ""
                txtAmaterno.Text = ""
            End If

            txtAlta.Value = Now
            EsBaja = False
            txtBaja.Value = Nothing
            txtIMSS.Text = ""
            txtIMSSdv.Text = ""
            btnSexo.Value = False
            sbInactivo.Value = False
            txtRFC.Text = ""
            txtGafete.Text = ""
            txtCpSAT.Text = ""
            txtCurp.Text = ""
            txtCuenta.Text = ""
            txtEmail_empl.Text = ""
            txtEmailEmpresa.Text = ""
            If gpSueldos.Visible = False Then
                'Si el GroupBox del sueldo está invisible, indica que el empleado que estábamos consultando tiene nivel mayor al permitido
                'Poner los datos de sueldo en blanco para el nuevo empleado
                txtSActual.Text = FormatCurrency(0)
                txtFactorInt.Text = 0
                txtProVar.Text = FormatCurrency(0)
                txtIntegrado.Text = FormatCurrency(0)
                txtUltimaMod.Text = Nothing
                txtSAnterior.Text = FormatCurrency(0)
            End If

            'chkChecaTarjeta.Checked = True

            txtDireccion.Text = ""
            txtTelefono.Text = ""
            txtTelefono2.Text = ""
            txtTelefono3.Text = ""
            txtTelefono4.Text = ""
            txtTelefono5.Text = ""
            txtAccidente.Text = ""

            'MCR 1/Dic/2015
            DevComponents.DotNetBar.ToastNotification.Close(pnlEncabezado)


            'MCR 18/NOV/2015
            If Not CiaEditable And Nuevo Then
                dtTemp = sqlExecute("SELECT TOP 1 cod_comp FROM cias WHERE editable = 1 ORDER BY cod_comp")
                If dtTemp.Rows.Count > 0 Then
                    cmbCia.SelectedValue = dtTemp.Rows(0)("cod_comp")
                    'MCR 1/Dic/2015
                    CiaEditable = True
                    HabilitarMaestro()

                    DevComponents.DotNetBar.ToastNotification.ToastBackColor = Color.Yellow
                    DevComponents.DotNetBar.ToastNotification.ToastForeColor = Color.Black

                    DevComponents.DotNetBar.ToastNotification.Show(Me.pnlEncabezado, "Note, por favor, que la compañía fue reemplazada dado que la anterior no es editable." _
                                                                   , My.Resources.Information48, 10000, DevComponents.DotNetBar.eToastGlowColor.Blue, _
                                                                   DevComponents.DotNetBar.eToastPosition.BottomCenter)

                Else

                End If
            End If

            'MCR 19/NOV/2015
            txtLocker.Text = ""
            txtCandado.Text = ""
            txtCombinacion.Text = ""

            '* Pantalla de expediente\infonavit

            'btnCredito.Value = False
            'txtInfonavit.Text = ""
            'txtInfonavitDV.Text = ""
            'txtPagoInfonavit.Text = 0

            '**** Información Expediente\Comentarios
            txtComentarios.Text = ""

            ' *** Expediente\ información de baja - reingresos ***
            txtEAlta.Text = txtAlta.Text
            txtEBaja.Text = txtBaja.Text
            txtAntiguedad.Text = ""
            txtNotasBaja.Text = "" ' 2022-06-24 Sergio Núñez

            cmbBajaInterno.SelectedIndex = -1
            cmbBajaIMSS.SelectedIndex = -1

            sbrecontrata.Value = True

            cmbsubmotivo.SelectedIndex = -1

            'REINGRESOS

            gpReingreso.Visible = False

            '* Expediente\tarjetas
            txtCuentaExp.Text = ""
            txtTarjeta.Text = ""
            txtClabe.Text = ""

            txtIDBonos.Text = ""
            txtCuentaBonos.Text = ""
            txtTarjetaBonos.Text = ""
            txtTarjetaAdicBonos.Text = ""


            txtFechaNac.ValueObject = Nothing
            '* Pantallas adicionales            
            dgContratos.DataSource = Nothing
            RefrescaFamiliares(-1)
            RefrescaEscolaridad(-1)
            RefrescaAuxiliares(-1)
            RefrescaInfonavit(-1)


            ' *** PROCESO PARA CARGAR FOTOGRAFIA ***
            picFoto.Image = picFoto.ErrorImage
            '****************************************

            '*** Cambios en bajas ****
            txtBaja.Visible = False
            lblBaja.Visible = False

            lblEstado.BackColor = Color.SlateBlue
            '*************************

            If DateDiff(DateInterval.Day, txtAlta.ValueObject, Now) > 15 Then
                txtAlta.Value = Now
            End If

            If Nuevo Then
                cmbColonia.SelectedValue = ""
                cmbEdoCivil.SelectedValue = ""



                dtPredeterminados = sqlExecute("SELECT * FROM predeterminados WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
                If dtPredeterminados.Rows.Count > 0 Then
                    Dim row As DataRow = dtPredeterminados.Rows(0)
                    cmbCia.SelectedValue = IIf(IsDBNull(row("cod_comp")), "", row("cod_comp"))

                    cmbPlanta.SelectedValue = ""
                    cmbArea.SelectedValue = ""

                    cmbDepto.SelectedValue = IIf(IsDBNull(row("cod_depto")), "", row("cod_depto"))
                    '  cmbRegFiscSAT.SelectedValue = IIf(IsDBNull(row("COD_REG_SAT")), "", row("COD_REG_SAT"))

                    cmbRegFiscSAT.SelectedValue = "605" ' AO 2024-03-21

                    chkChecaTarjeta.Checked = IIf(IsDBNull(row("checa_tarjeta")), 1, row("checa_tarjeta"))

                    cmbTipo.SelectedValue = IIf(IsDBNull(row("cod_tipo")), "", row("cod_tipo"))
                    cmbSuper.SelectedValue = IIf(IsDBNull(row("cod_super")), "", row("cod_super"))

                    '==LIDER DE EMPLEADO            10Dic2021           Ernesto
                    ' cmbLider.SelectedValue = IIf(IsDBNull(row("cod_linea")), "", row("cod_linea"))

                    cmbClase.SelectedValue = IIf(IsDBNull(row("cod_clase")), "", row("cod_clase"))
                    cmbTurno.SelectedValue = IIf(IsDBNull(row("cod_turno")), "", row("cod_turno"))
                    cmbPuesto.SelectedValue = IIf(IsDBNull(row("cod_puesto")), "", row("cod_puesto"))
                    cmbHorario.SelectedValue = IIf(IsDBNull(row("cod_hora")), "", row("cod_hora"))
                    txtSActual.Text = IIf(IsDBNull(row("sactual")), 0, row("sactual"))
                    txtFactorInt.Text = IIf(IsDBNull(row("factor_int")), 0, row("factor_int"))
                    txtProVar.Text = 0
                    txtIntegrado.Text = (Double.Parse(txtSActual.Text) * Double.Parse(txtFactorInt.Text)) + Double.Parse(txtProVar.Text)
                    txtAlta.Value = Date.Now
                    txtUltimaMod.Text = FechaSQL(txtAlta.Value) ' 2024-03-21

                    'MCR 20/OCT/15
                    'Asignar número de reloj hasta que guarda el nuevo registro, para evitar confusiones

                    'Dim dtReloj As DataTable = sqlExecute("select top 1 reloj from personalvw where reloj > '" & row("minimo_rango").ToString.PadLeft(6, "0") & "' and reloj < '" & row("maximo_rango").ToString.PadLeft(6, "0") & "' and cod_comp = '" & cmbCia.SelectedValue & "' order by reloj desc")
                    'If dtReloj.Rows.Count Then
                    '    txtReloj.Text = (Integer.Parse(dtReloj.Rows(0)("reloj")) + 1).ToString.PadLeft(6, "0")
                    'End If

                    ''If (cmbCia.SelectedValue = "090") Then
                    ''    If cmbTipo.SelectedValue = "A" Then
                    ''        dtReloj = sqlExecute("select top 1 reloj from personalvw where reloj > '020000' and reloj < '030000' and cod_comp = '" & cmbCia.SelectedValue & "' order by reloj desc")
                    ''    Else
                    ''        dtReloj = sqlExecute("select top 1 reloj from personalvw where reloj > '030000' and reloj < '070000' and cod_comp = '" & cmbCia.SelectedValue & "' order by reloj desc")
                    ''    End If

                    ''    If dtReloj.Rows.Count Then
                    ''        txtReloj.Text = (Integer.Parse(dtReloj.Rows(0)("reloj")) + 1).ToString.PadLeft(6, "0")
                    ''    End If

                    ''    txtReloj.Enabled = False
                    ''Else
                    ''    txtReloj.Enabled = Nuevo
                    ''End If

                End If
            End If
            gpSueldos.Visible = True
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            txtNombre.Text = " - ERROR -"
        End Try
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        Dim reloj As String
        Try
            reloj = txtReloj.Text
            dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * from personalvw WHERE reloj >'" & reloj & "' ORDER BY reloj ASC")
            If dtPersonal.Rows.Count < 1 Then
                btnLast.PerformClick()
            Else
                reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
                MostrarInformacion(reloj)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        Dim reloj As String
        Try
            reloj = txtReloj.Text
            dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * from personalvw ORDER BY reloj DESC")
            If dtPersonal.Rows.Count > 0 Then
                'EmpIdx = dtPersonal.Rows.Count - 1
                reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
                MostrarInformacion(reloj)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        Dim reloj As String
        Try
            reloj = txtReloj.Text
            dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * from personalvw ORDER BY reloj ASC")
            If dtPersonal.Rows.Count > 0 Then
                reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
                MostrarInformacion(reloj)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        Dim reloj As String
        Try
            reloj = txtReloj.Text
            dtPersonal = ConsultaPersonalVW("SELECT TOP 1 * from personalvw WHERE reloj <'" & reloj & "' ORDER BY reloj DESC")
            If dtPersonal.Rows.Count < 1 Then
                btnFirst.PerformClick()
            Else
                reloj = dtPersonal.Rows.Item(0).Item("RELOJ")

                MostrarInformacion(reloj)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub
    'Private Sub btnCredito_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '   gpCredito.Enabled = (btnCredito.Value)

    'End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        dtTemp = dtPersonal
        Try
            frmBuscar.ShowDialog(Me)
            If Reloj <> "CANCEL" Then
                MostrarInformacion(Reloj)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            dtPersonal = dtTemp
        End Try
    End Sub

    Private Sub cmbColonia_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbColonia.SelectedIndexChanged
        Dim cl As String
        Try
            cl = cmbColonia.SelectedValue
            Dim dtcp As DataTable = sqlExecute("select * from colonias where cod_col = '" & cl & "'")
            If dtcp.Rows.Count > 0 Then
                txtCP.Text = dtcp.Rows(0)("cp")
            Else
                txtCP.Text = "N/A"
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub RefrescaVacaciones(ByVal rl As String)
        Dim _diasVac As Integer = 0
        Dim _Prima As Integer = 0

        Dim Antiguedad As Integer = DateDiff(DateInterval.Year, txtAlta.Value, Now)
        Dim _alta As Date = txtAlta.Value
        Dim _f_aniversario As New Date(Year(Now), txtAlta.Value.Month, txtAlta.Value.Day)
        Dim _f_anterior As New Date(Year(Now) - 1, txtAlta.Value.Month, txtAlta.Value.Day)
        Dim _dinero As Double = 0
        Dim _tiempo As Double = 0
        Dim _dDias As Double

        Try
            txtProyVacas.Value = Date.Now
            '***** PARA ACTUALIZAR SALDOS CUANDO CUMPLEN ANIVERSARIO
            If Antiguedad >= 1 And Not EsBaja And Now >= _f_aniversario Then
                _diasVac = 0
                _Prima = 0
                dtTemp = sqlExecute("SELECT reloj FROM saldos_vacaciones WHERE reloj = '" & rl & "' AND ano = '" & Year(_f_aniversario) & "' AND aniversario = 1")

                '*** Si ya pasó su aniversario, y no se le han actualizado los saldos, crear registro de aniversario
                If dtTemp.Rows.Count = 0 Then
                    '*** Tomar los saldos anteriores
                    dtTemp = sqlExecute("SELECT TOP 1 saldo_dinero, saldo_tiempo FROM saldos_vacaciones WHERE reloj = '" & rl & "' ORDER BY fecha_captura DESC,fecha_fin DESC")
                    If dtTemp.Rows.Count > 0 Then
                        _dinero = dtTemp.Rows.Item(0).Item("saldo_dinero")
                        _tiempo = dtTemp.Rows.Item(0).Item("saldo_tiempo")
                    End If

                    dtTemp = sqlExecute("SELECT dias, por_prima FROM vacaciones WHERE cod_comp = '" & Compania & "' AND cod_tipo = '" & txtTipoEmp.Text & "' AND anos = " & Antiguedad)

                    If dtTemp.Rows.Count > 0 Then
                        _diasVac = dtTemp.Rows.Item(0).Item("dias")
                        _Prima = dtTemp.Rows.Item(0).Item("por_prima")

                        '--AOS: 03/04/2020 -  A solicitud del cliente,  cada vez que se cumpla aniversario, se reinicia el saldo y se deja solamente lo ganado, pero que pasa si trae saldo negativo, si debe de restarlo
                        If (_dinero >= 0) Then
                            _dinero = 0
                            _tiempo = 0
                        End If


                        '---Para que no actualice vacaciones por aniv antes de la fecha de carga inicial de vacaciones
                        If FechaSQL(_f_aniversario) > "2024-04-06" Then
                            sqlExecute("INSERT INTO saldos_vacaciones (reloj,ano,dias,prima,saldo_dinero,saldo_tiempo,dinero,tiempo,comentario,aniversario," & _
           "fecha_ini,fecha_fin,fecha_captura) VALUES ('" & _
           rl & "','" & _
           Year(_f_aniversario) & "'," & _
           _diasVac & "," & _
           _Prima & "," & _
           (_dinero + _diasVac) & "," & _
           (_tiempo + _diasVac) & _
           ",0,0,'ANIVERSARIO " & Year(_f_aniversario) & "',1,'" & _
           FechaSQL(_f_anterior) & "','" & _
           FechaSQL(_f_aniversario) & "','" & _
           FechaHoraSQL(Now) & "')")
                        End If
                        '----END: Para que no actualice vacaciones por aniv antes de la fecha de la carga inicial de vacaciones

                    End If

                End If
            End If

            '**** CALCULAR DIAS DEVENGADOS A LA FECHA
            _dDias = VacacionesDevengadas(rl, Now.Date)

            '===== MOSTRAR DATOS Y SALDOS======================
            '--Agregado dias ganados y dias tomados, asi como el saldo a la fecha actual        marzo/21        Ernesto
            Dim dtTotalesGanados As New DataTable : Dim dias_ganados As Integer = 0 : Dim dias_tomados As Integer = 0
            dtTotalesGanados = sqlExecute("select reloj,SUM(CAST(dias as int)) as dias_ganados, SUM(CAST(tiempo as int)) as dias_tomados  from saldos_vacaciones " & _
                                                         "where RELOJ= '" & rl & "' group by RELOJ ")

            If dtTotalesGanados.Rows.Count > 0 Then
                '--txtSaldoPagar
                dias_ganados = IIf(IsDBNull(dtTotalesGanados.Rows(0)("dias_ganados")), 0, dtTotalesGanados.Rows(0)("dias_ganados"))
                txtSaldoPagar.Text = dias_ganados
                '--txtSaldoTomar
                dias_tomados = IIf(IsDBNull(dtTotalesGanados.Rows(0)("dias_tomados")), 0, dtTotalesGanados.Rows(0)("dias_tomados"))
                txtSaldoTomar.Text = dias_tomados
            Else
                txtSaldoPagar.Text = 0
                txtSaldoTomar.Text = 0
            End If

            '--Comentado    Ernesto     marzo/21
            'dtTemp = sqlExecute("SELECT TOP 1 saldo_dinero, saldo_tiempo FROM saldos_vacaciones WHERE reloj = '" & rl & _
            '                    "' ORDER BY fecha_captura DESC,fecha_fin DESC")
            'If dtTemp.Rows.Count > 0 Then
            '    txtSaldoPagar.Text = dtTemp.Rows.Item(0).Item("saldo_dinero")
            '    txtSaldoTomar.Text = dtTemp.Rows.Item(0).Item("saldo_tiempo")
            'Else
            '    txtSaldoPagar.Text = 0
            '    txtSaldoTomar.Text = 0
            'End If

            '--Vacaciones devengadas
            txtDevengadas.Text = _dDias

            '--Saldo actual
            Dim tipo_emp As String = cmbTipo.SelectedValue
            Dim cod_comp As String = cmbCia.SelectedValue
            '  txtSaldoActual.Text = Double.Parse(dias_ganados - dias_tomados + _dDias) ' AOS 2022-11-25
            txtSaldoActual.Text = Double.Parse(dias_ganados - dias_tomados) '== 2024-10-01: Solicitan de CTE, se muestre solo el subtotal, no incluyendo los días devengados
            '     txtSaldoActual.Text = CalcSaldoFinVacas(txtReloj.Text, txtAlta.Value, Date.Now, tipo_emp, cod_comp)
            '==============================================
            'DÍAS
            dtVacaciones = sqlExecute("SELECT ANO,dias,prima,saldo_dinero,saldo_tiempo,dinero,tiempo,fecha_ini,fecha_fin,comentario," & _
                                      "aniversario,fecha_captura FROM saldos_vacaciones WHERE reloj = '" & rl & "' ORDER BY fecha_captura DESC,fecha_fin DESC")
            dgVacaciones.DataSource = dtVacaciones
            txtFechaDe.Value = Now

            btnCapturar.Enabled = Not EsBaja
            txtPagar.Enabled = False
            txtTomar.Enabled = False
            txtFechaDe.Enabled = False
            cmbPeriodos.Enabled = False
            cmbPeriodos.SelectedIndex = -1


            btnAplicarVac.Enabled = False
            btnCancelarVac.Enabled = False
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub HabilitarMaestro()
        Try
            'MCR 1/dic/2015
            'Revertir excepciones primero
            RevisaExcepciones(Me, "", True)
            'chkShowSalary.Enabled = True

            If Nuevo Or Editar Then
                btnNuevo.Image = My.Resources.Ok16
                btnEditar.Image = My.Resources.Cancel16

                btnNuevo.Text = "Aceptar"
                btnEditar.Text = "Cancelar"
            Else
                btnNuevo.Image = My.Resources.NewRecord
                btnEditar.Image = My.Resources.Edit

                btnNuevo.Text = "Agregar"
                btnEditar.Text = "Editar"
            End If

            'Definir desde aquí la disponibilidad de los controles de acuerdo al perfil de usuario
            btnNuevo.Visible = Not tbVac And ((tbGral And PermisoEdicion) Or (Not tbGral And (Editar Or Nuevo)))

            '18/dic/2020
            If perfilesDetallados And (Perfil.Contains("SUPERV") Or Perfil.Contains("GER_AREA")) Then
                Editar = revisarPerfiles(Perfil, Me, Editar, cmbCia.SelectedValue, txtReloj.Text.ToString.Trim)
            End If

            btnFoto.Visible = Editar Or Nuevo
            btnCapturar.Visible = tbVac And PermisoEdicion

            btnBorrar.Visible = tbGral And PermisoEdicion
            'pnlGeneral.Enabled = (Nuevo Or Editar)
            For Each c As Control In pnlGeneral.Controls
                c.Enabled = Nuevo Or Editar Or (c.Name = "pnlAuxiliaresSeleccionados")
            Next
            pnlPersonalDomicilio.Enabled = (Nuevo Or Editar)
            pnlPersonalInfoNac.Enabled = (Nuevo Or Editar)
            cmbEdoCivil.Enabled = (Nuevo Or Editar)
            btnEdoCivil.Enabled = (Nuevo Or Editar)

            txtLocker.Enabled = (Nuevo Or Editar)
            txtCandado.Enabled = (Nuevo Or Editar)
            txtCombinacion.Enabled = (Nuevo Or Editar)

            txtAccidente.Enabled = (Nuevo Or Editar)
            txtEmail_empl.Enabled = (Nuevo Or Editar)
            txtEmailEmpresa.Enabled = (Nuevo Or Editar)
            pnlInfonavit.Enabled = (Nuevo Or Editar)
            pnlBaja.Enabled = False
            pnlComentarios.Enabled = (Nuevo Or Editar)
            dgFamiliares.ReadOnly = Not (Nuevo Or Editar)
            dgEscolaridad.ReadOnly = Not (Nuevo Or Editar)
            dgAuxiliares.ReadOnly = Not (Nuevo Or Editar)
            'dgAuxiliaresSeleccionados.EditMode = DataGridViewEditMode.EditOnEnter
            dgAuxiliaresSeleccionados.Columns("colContenido").ReadOnly = Not (Nuevo Or Editar)
            dgBeneficiarios.ReadOnly = Not (Nuevo Or Editar)
            dgBeneficiarios.AllowUserToDeleteRows = Nuevo Or Editar
            dgBeneficiarios.AllowUserToAddRows = Nuevo Or Editar

            'pnlReportes.Enabled = (Nuevo Or Editar)
            dgReportes.Enabled = True
            pnlTarjetas.Enabled = (Nuevo Or Editar)

            '******Habilitar infonavit
            cmbTipoInfonavit.Enabled = (Nuevo Or Editar)
            txtNumeroCredito.Enabled = (Nuevo Or Editar)
            dtpFechaInicioCreditoInfonavit.Enabled = (Nuevo Or Editar)
            txtFactorDeDescuentoInfonavit.Enabled = (Nuevo Or Editar)

            '**** Habilitar sueldos solo si es alta. Integrado y Variables no se pueden modificar *****
            '  txtSActual.Enabled = Nuevo
            txtSActual.Enabled = (Nuevo Or Editar)
            txtFactorInt.Enabled = False
            txtProVar.Enabled = False
            txtIntegrado.Enabled = False
            txtUltimaMod.Enabled = False
            txtSAnterior.Enabled = False

            cmbNivel.Enabled = Nuevo
            ' btnNivel.Enabled = Nuevo
            '********************************************

            '***** CP, UMF y estado del domicilio son solo informativos, no se modifican ***
            txtCP.Enabled = False
            ' cambio abraham
            ' txtUMF.Enabled = False
            txtEstado.Enabled = False
            '*******************************************************************************

            pnlVacaciones.Enabled = (Nuevo Or Editar)

            txtApaterno.ReadOnly = Not (Nuevo Or Editar)
            txtAmaterno.ReadOnly = Not (Nuevo Or Editar)
            txtNombre.ReadOnly = Not (Nuevo Or Editar)
            'El número de reloj se asigna automáticamente
            txtReloj.ReadOnly = Not Nuevo
            txtReloj.Enabled = True
            txtAlta.Enabled = (Nuevo Or Editar)
            txtBaja.Enabled = (Nuevo Or Editar)

            btnBaja.Visible = (Editar Or Nuevo)
            btnFirst.Enabled = Not (Nuevo Or Editar)
            btnPrev.Enabled = Not (Nuevo Or Editar)
            btnNext.Enabled = Not (Nuevo Or Editar)
            btnLast.Enabled = Not (Nuevo Or Editar)
            btnBorrar.Enabled = Not (Nuevo Or Editar)
            btnBuscar.Enabled = Not (Nuevo Or Editar)
            btnReporte.Enabled = Not (Nuevo Or Editar)
            btnCerrar.Enabled = Not (Nuevo Or Editar)

            '    gpCredito.Enabled = btnCredito.Value

            'cmbCCostos.Enabled = False
            'cmbArea.Enabled = False


            If nReingresos <= NivelSueldos Then
                btnBaja.Visible = (Editar Or Nuevo)
            Else
                btnBaja.Visible = False
            End If

            'MCR 1/Dic/2015
            DevComponents.DotNetBar.ToastNotification.Close(pnlEncabezado)

            'MCR 18/NOV/2015
            'Utilizar proceso para bloquear campos según SuccessFactor
            RevisaExcepciones(Me, cmbCia.SelectedValue)

            pnlBaja.Enabled = Editar            'Motivos de baja no se podían modificar despues de la baja      04/dic/20

            '18 de diciembre de 2020            perfiles	linea:2598
            If perfilesDetallados And (Perfil.Contains("SUPERV") Or Perfil.Contains("GER_AREA")) Then
                Editar = Not revisarPerfiles(Perfil, Me, True, cmbCia.SelectedValue, txtReloj.Text.ToString.Trim)
                perfilesDetallados = False
                'revisarPerfiles("SUPERV", Me, True, cmbCia.SelectedValue)
            ElseIf (Perfil.Contains("SUPERV") Or Perfil.Contains("GER_AREA")) Then
                revisarPerfiles(Perfil, Me, Editar, cmbCia.SelectedValue, txtReloj.Text.ToString.Trim)
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub


    Private Sub picFoto_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles picFoto.DoubleClick
        Try
            frmFoto.picFoto.Image = picFoto.Image
            frmFoto.Text = txtReloj.Text
            frmFoto.ShowDialog(Me)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnBaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBaja.Click
        Try
            If EsBaja Then
                Dim dtInfo As New DataTable

                '*** Si ya es baja, capturar reingreso
                txtAlta.Enabled = False
                txtEBaja.Value = Nothing

                dtInfo = sqlExecute("SELECT alta,baja from personalvw WHERE reloj = '" & txtReloj.Text & "'")
                DarReingreso = True
                DarDeBaja = False
                AltaAnt = dtInfo.Rows(0).Item("alta")
                BajaAnt = dtInfo.Rows(0).Item("baja")
                txtAlta.Focus()

                'MCR 27/OCT/2015
                'Indicar reingreso en barra de estado, y poner invisible botón de reingreso
                btnBaja.Visible = False
                lblEstado.Text = "REINGRESO"
                lblEstado.BackColor = Color.FromArgb(117, 191, 202)
                txtReloj.BackColor = Color.FromArgb(117, 191, 202)
                Highlighter1.SetHighlightColor(txtReloj, DevComponents.DotNetBar.Validator.eHighlightColor.Blue)
                '**************************************

                If nReingresos <= NivelEdicion Then
                    cmbNivel.Enabled = True
                    ' btnNivel.Enabled = True
                    gpSueldos.Visible = True
                    gpSueldos.Enabled = True
                    txtSActual.Enabled = True
                End If

                '--- 2024-04-17: Que coloque fecha de alta al dia actual, que limpie baja y que permita modificar la fecha de alta
                If DarReingreso Then
                    txtAlta.Value = Date.Now()
                    txtAlta.Enabled = True
                    txtBaja.Value = Nothing
                End If
                '----END

            Else
                '*** Si aún está activo, capturar baja.
                tbInfo.SelectedTabIndex = 1
                tbExpediente.SelectedTabIndex = 2
                pnlBaja.Enabled = True
                DarDeBaja = True
                DarReingreso = False
                'Activar el subTab de Auxiliares
                'frmCias.subTabOtros.SelectedTabIndex = 0
                txtAlta.Enabled = False
                txtEAlta.Enabled = False
                txtEBaja.Value = Today
                txtEBaja.Focus()
            End If

            txtEBaja.Enabled = DarDeBaja
            cmbBajaInterno.Enabled = DarDeBaja
            cmbBajaIMSS.Enabled = DarDeBaja
            txtBaja.Enabled = False

            '---AOS - 01/11/2019 Colocar valores de DIAS_AGUI, DIAS_VAC y DIAS_PRIMA_VAC
            '-- NOTA: Se deja en false para que no actualice aun los campos en la tabla personal
            Reloj = txtReloj.Text.Trim
            CalcDAgDVacDPvac(Reloj, txtEBaja.Value, False)


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditar.Click
        Try
            If Nuevo Or Editar Then
                perfilesDetallados = False              '18/dic/2020
                CancelarCambios()
            ElseIf tbExpediente.SelectedTab.Name = "tabBaja" And Perfil.Contains("OH") Then
                If cmbCia.Text.Contains("002") Then
                    If txtBaja.Visible Then
                        reloj_mot_baj = txtReloj.Text
                        frmEditarMotBaj.ShowDialog()
                        MostrarInformacion(reloj_mot_baj)
                    Else
                        MessageBox.Show("El empleado no esta dado de baja", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
            Else
                If CiaEditable Then
                    perfilesDetallados = True              '18/dic/2020
                    Nuevo = False
                    Editar = True
                    HabilitarMaestro()
                    txtNombre.Focus()
                Else
                    Nuevo = False
                    Editar = True
                    If Nuevo Or Editar Then
                        btnNuevo.Image = My.Resources.Ok16
                        btnEditar.Image = My.Resources.Cancel16

                        btnNuevo.Text = "Aceptar"
                        btnEditar.Text = "Cancelar"
                    Else
                        btnNuevo.Image = My.Resources.NewRecord
                        btnEditar.Image = My.Resources.Edit

                        btnNuevo.Text = "Agregar"
                        btnEditar.Text = "Editar"
                    End If
                    btnFoto.Visible = Editar Or Nuevo


                    'MessageBox.Show("Compañía no editable", "Compañía no editable", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub CancelarCambios()
        Try
            Nuevo = False
            Editar = False
            btnBaja.Visible = False
            CambiaFoto = False ' 2024-04-18
            dtCambiosAuxiliares.Rows.Clear()
            dtCambiosEscolaridad.Rows.Clear()
            dtCambiosFamilia.Rows.Clear()
            HabilitarMaestro()
            Reloj = dtPersonal.Rows.Item(0).Item("RELOJ")
            MostrarInformacion(Reloj)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
        Try
            Dim Compara As String
            Dim Reloj As String = ""
            Dim Porcentajes As Double
            Dim Duplicar As Boolean = False 'Bandera para que, si ya se seleccionó que repita el nombre, no revise IMSS ni RFC, que serían los mismos


            Dim dtNCEmpl As DataTable = sqlExecute("SELECT nc_empl as NumConsec from parametros", "PERSONAL")
            If (Not dtNCEmpl.Columns.Contains("ERROR") And dtNCEmpl.Rows.Count > 0) Then
                NCEmpl = IIf(IsDBNull(dtNCEmpl.Rows(0).Item("NumConsec")), 0, Convert.ToInt32(dtNCEmpl.Rows(0).Item("NumConsec")))
            End If



            If Nuevo Or Editar Then
                Dim datos_completos As Boolean = False
                Try
                    datos_completos = sqlExecute("select datos_completos from cias where cod_comp = '" & _
                                                 cmbCia.SelectedValue & "'").Rows(0)("datos_completos")
                Catch ex As Exception
                    datos_completos = False
                End Try


                'MCR 26/OCT/2015
                'Validar primero los campos que no implican el número de reloj, para luego asignarlo

                'Validar que nombre no quede en blanco
                If txtNombre.TextLength = 0 Then
                    MessageBox.Show("El nombre no puede quedar en blanco. Favor de verificar.", "Nombre en blanco", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    txtNombre.Focus()
                    Exit Sub
                End If

                'Validar que apellido paterno no quede en blanco
                If txtApaterno.TextLength = 0 Then
                    MessageBox.Show("El apellido paterno no puede quedar en blanco. Favor de verificar.", "Apellido en blanco", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    txtApaterno.Focus()
                    Exit Sub
                    dgBeneficiarios.Columns.Clear()
                End If


                If datos_completos Then
                    'Validar RFC
                    If Not ValidaRFC(txtRFC.Text) Then
                        MessageBox.Show("El RFC no es válido. Favor de verificar.", "RFC inválido", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        txtRFC.Focus()
                        Exit Sub
                    End If
                End If

                If datos_completos Then
                    'Validar RFC
                    If Not ValidaCURP(txtCurp.Text) Then
                        MessageBox.Show("La CURP no es válida. Favor de verificar.", "CURP inválida", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        txtCurp.Focus()
                        Exit Sub
                    End If
                End If

                If datos_completos Then
                    'Validar RFC vs Fecha de nacimiento
                    If txtFechaNac.ValueObject = Nothing Then
                        txtFechaNac.ValueObject = RFCaFechaNac(txtRFC.Text)
                    ElseIf RFCaFechaNac(txtRFC.Text) <> txtFechaNac.Value Then
                        MessageBox.Show("La fecha de nacimiento no coincide con el RFC. Favor de verificar.", "Fecha de nacimiento inválida", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        txtFechaNac.Focus()
                        Exit Sub
                    End If
                End If




                If datos_completos Then
                    'Validar suma de porcentajes en beneficiarios
                    Porcentajes = 0
                    For Each dBenef As DataRow In dtBeneficiarios.Select("movimiento<>'B'")
                        Porcentajes = Porcentajes + IIf(IsDBNull(dBenef("porcentaje")), 0, dBenef("porcentaje"))
                    Next

                    'If Porcentajes <> 0 And Porcentajes Mod 100 <> 0 Then '--------------------Se comento por Antonio
                    '    MessageBox.Show("La distribución de porcentajes para los beneficiarios no es del 100%. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    '    dgBeneficiarios.Focus()
                    '    Exit Sub
                    'End If
                End If

                Dim dtSueldo As DataTable
                '  dtSueldo = sqlExecute("SELECT SUELDO_BLANCO FROM CIAS WHERE COD_COMP='" & cmbCia.SelectedValue & "'")   *** select isnull(SUELDO_BLANCO,0) as 'SUELDO_BLANCO' from cias
                dtSueldo = sqlExecute("SELECT isnull(SUELDO_BLANCO,0) as 'SUELDO_BLANCO' FROM CIAS WHERE COD_COMP='" & cmbCia.SelectedValue & "'")
                If dtSueldo.Rows(0).Item("SUELDO_BLANCO") = False Then
                    If Val(txtSActual.Text.Replace("$", "")) = 0 And nReingresos <= NivelSueldos And (Nuevo Or Reingreso) Then
                        MessageBox.Show("El sueldo no puede quedar en blanco. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtSActual.Focus()
                        Exit Sub
                    End If
                End If


                'MCR 20/OCT/15
                'El número de reloj se asigna automáticamente

                If Nuevo Then
                    'MCR 20/OCT/15
                    'Asignar número de reloj, de acuerdo a código de compañía --- NO APLICA PARA WME
                    Dim dtPredeterminados As DataTable = sqlExecute("select minimo_rango,maximo_rango from tipo_emp where cod_comp = '" & cmbCia.SelectedValue & "'" & _
                                                                    " AND cod_tipo ='" & cmbTipo.SelectedValue & "'")

                    dtPredeterminados.Clear() ' --- NO APLICA PARA WME, dejar el # Reloj que ya trae, es decir que reloj=txtReloj.text que es el que no. consecoutivo

                    If dtPredeterminados.Rows.Count = 0 Then
                        Reloj = txtReloj.Text
                    Else
                        Dim row As DataRow = dtPredeterminados.Rows(0)

                        If IsDBNull(row("minimo_rango")) Or IsDBNull(row("maximo_rango")) Then
                            Reloj = txtReloj.Text
                        Else
                            Dim dtReloj As DataTable
                            dtReloj = sqlExecute("select top 1 reloj from personalvw where " & _
                                                                  "reloj > '" & row("minimo_rango").ToString.PadLeft(6, "0") & _
                                                                  "' and reloj < '" & row("maximo_rango").ToString.PadLeft(6, "0") & _
                                                                  "' and cod_comp = '" & cmbCia.SelectedValue & "' order by reloj desc")
                            If dtReloj.Rows.Count Then
                                Reloj = (Integer.Parse(dtReloj.Rows(0)("reloj")) + 1).ToString.PadLeft(LongReloj, "0")
                            Else
                                Reloj = row("minimo_rango").ToString.PadLeft(6, "0")
                            End If

                            'Validar que el número de reloj no exista
                            dtReloj = sqlExecute("SELECT reloj FROM personal WHERE reloj = '" & Reloj & "'")
                            Do Until dtReloj.Rows.Count = 0
                                Reloj = (Integer.Parse(dtReloj.Rows(0)("reloj")) + 1).ToString.PadLeft(LongReloj, "0")
                                dtReloj = sqlExecute("SELECT reloj FROM personal WHERE reloj = '" & Reloj & "'")
                            Loop

                            'Si el rango ya está completo, notificar al usuario, luego salir
                            If Reloj > row("maximo_rango").ToString.PadLeft(6, "0") Then
                                MessageBox.Show("No hay números de reloj disponibles en el rango indicado, del " & _
                                                row("minimo_rango").ToString.PadLeft(6, "0") & " al " & row("maximo_rango").ToString.PadLeft(6, "0"), _
                                                "Rango completo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                txtReloj.Text = ""
                                Exit Sub
                            End If

                        End If 'IsDBNull(row("minimo_rango")) Or IsDBNull(row("maximo_rango"))

                        'Si el número de reloj está en blanco, salir
                        If Val(Reloj) = 0 Then
                            MessageBox.Show("El número de reloj no puede quedar en blanco." & vbCrLf & "Favor de verificar.", "Reloj en blanco", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            txtReloj.Focus()
                            Exit Sub
                        End If

                        If sqlExecute("SELECT reloj FROM personal WHERE reloj = '" & Reloj & "'").Rows.Count > 0 Then
                            MessageBox.Show("El número de reloj ya se encuentra asignado a otro empleado." & vbCrLf & "Favor de verificar.", "Reloj duplicado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            If Not txtReloj.Enabled And Nuevo Then
                                txtReloj.Text = ""
                            End If
                            txtReloj.Focus()
                            Exit Sub
                        End If

                        'Buscar si el nombre existe (en otro número de reloj)
                        Compara = txtApaterno.Text.Trim & "," & txtAmaterno.Text.Trim & "," & txtNombre.Text.Trim
                        dtTemp = sqlExecute("SELECT reloj from personalvw WHERE nombres = '" & Compara & "'")
                        If dtTemp.Rows.Count > 0 Then
                            If dtTemp.Rows(0).Item("reloj") <> Reloj Then
                                If MessageBox.Show("El empleado " & Compara & " ya se encuentra asignado al número de reloj " & _
                                                   dtTemp.Rows(0).Item("reloj") & ". ¿Desea continuar?", "Nombre duplicado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                                    If Not txtReloj.Enabled And Nuevo Then
                                        txtReloj.Text = ""
                                    End If
                                    Exit Sub
                                Else
                                    Duplicar = True
                                End If
                            End If
                        End If 'Si se seleccionó no duplicar...
                        If Not Duplicar Then
                            Compara = txtIMSS.Text & txtIMSSdv.Text
                            'BERE
                            'dtTemp = sqlExecute("SELECT reloj from personalvw WHERE CONCAT(imss,dig_ver) = '" & Compara & "'")
                            dtTemp = sqlExecute("SELECT reloj from personalvw WHERE (imss + dig_ver) = '" & Compara & "'")
                            If dtTemp.Rows.Count > 0 And Compara > "" Then
                                If dtTemp.Rows(0).Item("reloj") <> Reloj Then
                                    If MessageBox.Show("El número de IMSS " & Compara & " ya se encuentra asignado al número de reloj " & dtTemp.Rows(0).Item("reloj") & ". ¿Desea continuar?", "IMSS duplicado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                                        If Not txtReloj.Enabled And Nuevo Then
                                            txtReloj.Text = ""
                                        End If
                                        tbInfo.SelectedTabIndex = 0
                                        txtIMSS.Focus()
                                        Exit Sub
                                    Else
                                        Duplicar = True
                                    End If
                                End If
                            End If
                        End If

                        If Not Duplicar Then
                            Compara = txtRFC.Text
                            dtTemp = sqlExecute("SELECT reloj from personalvw WHERE RFC = '" & Compara & "'")
                            If dtTemp.Rows.Count > 0 Then
                                If dtTemp.Rows(0).Item("reloj") <> Reloj Then
                                    If MessageBox.Show("El RFC " & Compara & " ya se encuentra asignado al número de reloj " & dtTemp.Rows(0).Item("reloj") & ". ¿Desea continuar?", "IMSS duplicado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                                        If Not txtReloj.Enabled And Nuevo Then
                                            txtReloj.Text = ""
                                        End If
                                        tbInfo.SelectedTabIndex = 0
                                        txtRFC.Focus()
                                        Exit Sub
                                    Else
                                        Duplicar = True
                                    End If
                                End If
                            End If
                        End If

                        If Not Duplicar And datos_completos Then
                            'Validar que la cuenta bancaria no esté en blanco ni duplicada, si es depósito
                            If cmbCodPago.SelectedValue = "D" Then
                                If txtCuenta.Text.Trim.Length = 0 Then
                                    MessageBox.Show("El número de cuenta no puede estar en blanco si la forma de pago es por depósito. Favor de verificar.", "Cuenta en blanco", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    If Not txtReloj.Enabled And Nuevo Then
                                        txtReloj.Text = ""
                                    End If
                                    txtCuenta.Focus()
                                    Exit Sub
                                End If
                                'Validar que la cuenta bancaria no esté duplicada
                                dtTemp = sqlExecute("SELECT reloj from personalvw WHERE cuenta_banco = '" & txtCuenta.Text & "' AND reloj <> '" & Reloj & "' and baja is null")
                                If dtTemp.Rows.Count > 0 Then
                                    MessageBox.Show("El número de cuenta se encuentra asignado al empleado " & dtTemp.Rows(0).Item("reloj") & ", y no puede duplicarse. Favor de verificar.", "Cuenta duplicada", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                                    If Not txtReloj.Enabled And Nuevo Then
                                        txtReloj.Text = ""
                                    End If
                                    txtApaterno.Focus()
                                    Exit Sub
                                End If
                            End If
                        End If

                    End If ' If dtPredeterminados.Rows.Count = 0 
                Else
                    Reloj = txtReloj.Text
                End If  'If nuevo

                '----Guardar foto en la ruta de fotos para mostrarse en pantalla
                If CambiaFoto Then
                    Dim Foto As String
                    Try
                        Foto = PathFoto & Reloj.Trim & ".jpg"
                        If Dir(Foto).Length <> 0 Then
                            My.Computer.FileSystem.DeleteFile(Foto)
                        End If

                        ' cambiar a 320 x 240 y guardar
                        Dim smImage As Image = Image.FromFile(picFoto.ImageLocation)
                        '  Dim smImg As Image = New Bitmap(smImage, 320, 240)
                        Dim smImg As Image = New Bitmap(smImage, 700, 900)
                        smImg.Save(Foto)



                        'My.Computer.FileSystem.CopyFile(picFoto.ImageLocation, Foto)
                        'My.Computer.FileSystem.DeleteFile(picFoto.ImageLocation)

                        picFoto.ImageLocation = Foto
                        CambiaFoto = False

                    Catch ex As Exception
                        Dim R As Windows.Forms.DialogResult
                        R = MessageBox.Show("La fotografía seleccionada no pudo ser asignada al empleado. ¿Desea continuar guardando los cambios?", "Fotografía", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        If R = Windows.Forms.DialogResult.No Then
                            If Not txtReloj.Enabled And Nuevo Then
                                txtReloj.Text = ""
                            End If
                            Exit Sub
                        End If
                    End Try
                End If

                txtReloj.Text = Reloj

                If AceptarCambios() Then
                    Nuevo = False
                    Editar = False

                    If ActualizarCambiosFamilia() Then
                        dtCambiosFamilia.Rows.Clear()
                        'CrearDTCambiosFamilia()
                        'RefrescaFamiliares(txtReloj.Text)
                    End If

                    If ActualizarCambiosEscolaridad() Then
                        dtCambiosEscolaridad.Rows.Clear()
                        'CrearDTCambiosEscolaridad()
                        'RefrescaEscolaridad(txtReloj.Text)
                    End If

                    If ActualizarCambiosAuxiliares() Then
                        dtCambiosAuxiliares.Rows.Clear()
                        'CrearDTCambiosAuxiliares()
                        'RefrescaAuxiliares(txtReloj.Text)
                    End If

                    If ActualizarBeneficiarios() Then
                        dtBeneficiarios.Rows.Clear()
                        'CrearDTCambiosAuxiliares()
                        'RefrescaAuxiliares(txtReloj.Text)
                    End If

                    HabilitarMaestro()
                    MostrarInformacion(txtReloj.Text)
                ElseIf Nuevo And Not txtReloj.Enabled Then
                    'MCR 26/OCT/205
                    'Si no se pudo insertar, está agregando nuevo registro, y el txtReloj está inhabilitado (asignación automática)
                    'Poner el # de reloj en blanco.
                    txtReloj.Text = ""
                End If
            Else
                Nuevo = True
                Editar = False
                HabilitarMaestro()
                InfoEnBlanco()

                btnBaja.Visible = False
                txtNombre.Focus()

                '--Cargar numero consec automatico o colocarlo manual en base a la config establecida solo si es un nuevo registro
                If Nuevo Then
                    If (NCEmpl = 1) Then
                        Dim dtUltRj As DataTable = sqlExecute("SELECT  TOP 1 MAX(reloj) AS ult_reloj  FROM personal", "PERSONAL")
                        If (Not dtUltRj.Columns.Contains("ERROR") And dtUltRj.Rows.Count > 0) Then
                            Dim UltRStr As String = IIf(IsDBNull(dtUltRj.Rows(0).Item("ult_reloj")), "", dtUltRj.Rows(0).Item("ult_reloj"))
                            Dim NCSig As Integer = IIf(UltRStr.Trim = "", 0, Convert.ToInt32(UltRStr)) + 1
                            Dim CerosAdd As String = AddZeros(Len(UltRStr.Trim), Len(NCSig.ToString.Trim))
                            txtReloj.Text = CerosAdd & NCSig.ToString.Trim
                            txtAlta.Focus()
                        End If
                    End If
                Else
                    txtReloj.Focus()
                End If
                '---End Carga NumConsec

            End If



        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub EditaPersonal(ByVal Reloj As String, ByVal Campo As String, ByVal Valor As Object)
        Dim TipoMovimiento As String
        Dim AnoPeriodo As String

        If Nuevo Then
            TipoMovimiento = "A"
        ElseIf DarDeBaja Then
            If Array.IndexOf(New String() {"cod_mot_ba", "cod_mot_im", "baja", "dias_aguinaldo", "dias_vacaciones"}, Campo.ToLower) >= 0 Then
                TipoMovimiento = "B"
            Else
                TipoMovimiento = "C"
            End If
        ElseIf DarReingreso Then
            TipoMovimiento = "R"
        ElseIf Editar Then
            TipoMovimiento = "C"
        Else
            TipoMovimiento = "X"
        End If
        Dim Cadena As String

        '---Valida
        If fecha_bitacora_wme = "" Or fecha_bitacora_wme Is Nothing Then fecha_bitacora_wme = FechaSQL(Date.Now)


        Try
            If Campo = "inactivo" Then
                Dim ValAnt As Double
                'dtTemp = sqlExecute("SELECT " & Campo & " from personalvw WHERE reloj = '" & Reloj & "'")
                dtTemp = sqlExecute("select isnull(" & Campo & ",0) as '" & Campo & "' from personalvw WHERE reloj = '" & Reloj & "'")
                ValAnt = IIf(IsDBNull(dtTemp.Rows.Item(0).Item(0)), -1, dtTemp.Rows.Item(0).Item(0))
                If ValAnt <> -1 And Valor <> ValAnt Then
                    If Valor = 1 Then
                        ' msginactivo = "Selecciona última fecha activo"
                        '   frmSeleccionarFecha.ShowDialog()

                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,fecha_mantenimiento) VALUES ('"
                        Cadena = Cadena & Reloj & "','" & Campo & "'," & ValAnt & "," & Valor & ",'" & Usuario & "','" & FechaSQL(fecha_bitacora_wme) & "','" & TipoMovimiento & "',getdate())"
                        sqlExecute(Cadena)

                        sqlExecute("UPDATE personal SET " & Campo & " = " & Valor & " WHERE reloj = '" & Reloj & "'")


                        'If fechaultimo.Date <> Nothing Then

                        '    sqlExecute("update detalle_auxiliares set contenido = '" & FechaSQL(fechaultimo).ToString & "' where reloj = '" & Reloj & "' and campo = 'FHA_INACTI'")
                        '    fechaultimo = Nothing
                        '    Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                        '    Cadena = Cadena & Reloj & "','" & Campo & "'," & ValAnt & "," & Valor & ",'" & Usuario & "','" & FechaSQL(fecha_bitacora_wme) & "','" & TipoMovimiento & "')"
                        '    sqlExecute(Cadena)

                        '    sqlExecute("UPDATE personal SET " & Campo & " = " & Valor & " WHERE reloj = '" & Reloj & "'")
                        'End If

                    ElseIf Valor = 0 Then
                        ' msginactivo = "Selecciona última fecha inactivo"
                        ' frmSeleccionarFecha.ShowDialog()

                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,fecha_mantenimiento) VALUES ('"
                        Cadena = Cadena & Reloj & "','" & Campo & "'," & ValAnt & "," & Valor & ",'" & Usuario & "','" & FechaSQL(fecha_bitacora_wme) & "','" & TipoMovimiento & "',getdate())"
                        sqlExecute(Cadena)

                        sqlExecute("UPDATE personal SET " & Campo & " = " & Valor & " WHERE reloj = '" & Reloj & "'")

                        'If fechaultimo <> Nothing Then
                        '    sqlExecute("update detalle_auxiliares set contenido = '" & FechaSQL(fechaultimo).ToString & "' where reloj = '" & Reloj & "' and campo = 'FHA_ACTIVO'")
                        '    fechaultimo = Nothing
                        '    Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento) VALUES ('"
                        '    Cadena = Cadena & Reloj & "','" & Campo & "'," & ValAnt & "," & Valor & ",'" & Usuario & "','" & FechaSQL(fecha_bitacora_wme) & "','" & TipoMovimiento & "')"
                        '    sqlExecute(Cadena)

                        '    sqlExecute("UPDATE personal SET " & Campo & " = " & Valor & " WHERE reloj = '" & Reloj & "'")
                        'End If
                    End If


                End If


            ElseIf TypeOf Valor Is Double Or TypeOf Valor Is Integer Then
                '*** Si el valor recibido es de tipo numérico
                Dim ValAnt As Double, esrecontratable As Boolean = False
                dtTemp = sqlExecute("SELECT " & Campo & " from personalvw WHERE reloj = '" & Reloj & "'")


                If Campo = "recontrata" Then
                    esrecontratable = IIf(IsDBNull(dtTemp.Rows.Item(0).Item(0)), False, dtTemp.Rows.Item(0).Item(0))
                    If esrecontratable Then ValAnt = 1 Else ValAnt = 0
                Else
                    ValAnt = IIf(IsDBNull(dtTemp.Rows.Item(0).Item(0)), -1, dtTemp.Rows.Item(0).Item(0))
                End If

                If Valor <> ValAnt Then
                    Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,fecha_mantenimiento) VALUES ('"
                    Cadena = Cadena & Reloj & "','" & Campo & "'," & ValAnt & "," & Valor & ",'" & Usuario & "','" & FechaSQL(fecha_bitacora_wme) & "','" & TipoMovimiento & "',getdate())"
                    sqlExecute(Cadena)

                    sqlExecute("UPDATE personal SET " & Campo & " = " & Valor & " WHERE reloj = '" & Reloj & "'")

                End If
            ElseIf TypeOf Valor Is Boolean Then
                '*** Si el valor recibido es de tipo numérico
                Dim ValAnt As Boolean
                dtTemp = sqlExecute("SELECT " & Campo & " from personalvw WHERE reloj = '" & Reloj & "'")
                ValAnt = IIf(IsDBNull(dtTemp.Rows.Item(0).Item(0)), False, dtTemp.Rows.Item(0).Item(0))

                If Valor <> ValAnt Then
                    Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,fecha_mantenimiento) VALUES ('"
                    Cadena = Cadena & Reloj & "','" & Campo & "'," & IIf(ValAnt, 1, 0) & "," & IIf(Valor, 1, 0) & ",'" & Usuario & "','" & FechaSQL(fecha_bitacora_wme) & "','" & TipoMovimiento & "',getdate())"
                    sqlExecute(Cadena)

                    sqlExecute("UPDATE personal SET " & Campo & " = " & IIf(Valor, 1, 0) & " WHERE reloj = '" & Reloj & "'")
                End If
            ElseIf TypeOf Valor Is Date Then
                '*** Si el valor recibido es de tipo fecha
                Dim ValAnt As Date
                Dim ValAntSTR As String
                dtTemp = sqlExecute("SELECT " & Campo & " from personalvw WHERE reloj = '" & Reloj & "'")
                ValAnt = IIf(IsDBNull(dtTemp.Rows.Item(0).Item(0)), Nothing, dtTemp.Rows.Item(0).Item(0))
                ValAntSTR = FechaSQL(ValAnt)

                If ValAnt <> Valor Then
                    Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,fecha_mantenimiento) VALUES ('"
                    Cadena = Cadena & Reloj & "','" & Campo & "','" & FechaSQL(ValAntSTR) & "','" & FechaSQL(Valor) & "','" & Usuario & "','" & FechaSQL(fecha_bitacora_wme) & "','" & TipoMovimiento & "',getdate())"
                    sqlExecute(Cadena)

                    Dim ValorFecha As String
                    ValorFecha = FechaSQL(Valor)
                    sqlExecute("UPDATE personal SET " & Campo & " = '" & ValorFecha & "' WHERE reloj = '" & Reloj & "'")
                End If
            Else
                '*** Si el valor recibido es de cualquier otro tipo, lo maneja como String
                Dim ValAnt As String

                ' Si el valor a editar es el imss, insertar también el dígito verificador en la bitácora
                If Campo.ToUpper = "IMSS" Then
                    dtTemp = sqlExecute("SELECT imss,dig_ver from personalvw WHERE reloj = '" & Reloj & "'")
                    ValAnt = IIf(IsDBNull(dtTemp.Rows.Item(0).Item(0)), "", dtTemp.Rows.Item(0).Item(0)) & "-" & IIf(IsDBNull(dtTemp.Rows.Item(0).Item(0)), "", dtTemp.Rows.Item(0).Item(1))

                    If Valor Is Nothing Then
                        Valor = ""
                    End If

                    If ValAnt.Trim <> Valor.ToString.Trim Then
                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,fecha_mantenimiento) VALUES ('"
                        Cadena = Cadena & Reloj & "','" & Campo & "','" & ValAnt & "','" & Valor & "','" & Usuario & "','" & FechaSQL(fecha_bitacora_wme) & "','" & TipoMovimiento & "',getdate())"
                        sqlExecute(Cadena)

                        If Valor = "NULL" Then
                            sqlExecute("UPDATE personal SET " & Campo & " = NULL WHERE reloj = '" & Reloj & "'")
                        Else
                            Dim i As Integer
                            i = Valor.ToString.IndexOf("-")
                            sqlExecute("UPDATE personal SET IMSS = '" & Valor.ToString.Substring(0, i) & "', dig_ver = '" & Valor.ToString.Substring(i + 1, 1) & "' WHERE reloj = '" & Reloj & "'")
                        End If
                    End If

                ElseIf Campo = "notas_baja" Then ' 2022-06-24 Sergio Núñez
                    If Valor = "NULL" Then
                        sqlExecute("UPDATE personal SET " & Campo & " = NULL WHERE reloj = '" & Reloj & "'")
                    Else
                        sqlExecute("UPDATE personal SET " & Campo & " = '" & Valor & "' WHERE reloj = '" & Reloj & "'")
                    End If

                ElseIf Campo.ToUpper = "NOMBRES" Then
                    dtTemp = sqlExecute("SELECT nombres from personalvw WHERE reloj = '" & Reloj & "'")
                    ValAnt = ""
                    If dtTemp.Rows.Count > 0 Then
                        ValAnt = IIf(IsDBNull(dtTemp.Rows(0)("nombres")), "", dtTemp.Rows(0)("nombres"))
                    End If

                    If Valor Is Nothing Then
                        Valor = ""
                    End If

                    If ValAnt.Trim <> Valor.ToString.Trim Then
                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,fecha_mantenimiento) VALUES ('"
                        Cadena = Cadena & Reloj & "','" & Campo & "','" & ValAnt & "','" & Valor & "','" & Usuario & "','" & FechaSQL(fecha_bitacora_wme) & "','" & TipoMovimiento & "',getdate())"
                        sqlExecute(Cadena)
                    End If

                ElseIf Campo.ToUpper = "COD_PUESTO" Then
                    'Periodos de prueba en BRP - ABRAHAM
                    dtTemp = sqlExecute("SELECT " & Campo & " from personalvw WHERE reloj = '" & Reloj & "'")
                    ValAnt = IIf(IsDBNull(dtTemp.Rows.Item(0).Item(0)), "", dtTemp.Rows.Item(0).Item(0))
                    If Valor Is Nothing Then
                        Valor = ""
                    End If

                    If ValAnt.Trim <> Valor.ToString.Trim Then
                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,fecha_mantenimiento) VALUES ('"
                        Cadena = Cadena & Reloj & "','" & Campo & "','" & ValAnt & "','" & Valor & "','" & Usuario & "','" & FechaSQL(fecha_bitacora_wme) & "','" & TipoMovimiento & "',getdate())"
                        sqlExecute(Cadena)

                        If Valor = "NULL" Then
                            sqlExecute("UPDATE personal SET " & Campo & " = NULL WHERE reloj = '" & Reloj & "'")
                        Else
                            sqlExecute("UPDATE personal SET " & Campo & " = '" & Valor & "' WHERE reloj = '" & Reloj & "'")
                        End If

                        'If TipoMovimiento = "C" Then
                        '    Dim dtPersonal As DataTable = sqlExecute("select * from personal where reloj = '" & Reloj & "'")

                        '    If dtPersonal.Rows.Count > 0 Then

                        '        Dim drPersonal As DataRow = dtPersonal.Rows(0)

                        '        Dim dtNuevoPuesto As DataTable = sqlExecute("select * from puestos where cod_puesto = '" & Valor & "' and cod_comp = '" & drPersonal("cod_comp") & "' ")
                        '        If dtNuevoPuesto.Rows.Count > 0 Then
                        '            Dim drPuesto As DataRow = dtNuevoPuesto.Rows(0)
                        '            Dim dlg As Windows.Forms.DialogResult
                        '            'MCR 27/OCT/2015
                        '            'Permitir modificar fecha de inicio periodo de pruebas
                        '            frmPeriodoPruebas.txtReloj.Text = Reloj
                        '            frmPeriodoPruebas.txtPuesto.Text = RTrim(drPuesto("nombre")).ToUpper
                        '            frmPeriodoPruebas.txtFecha.Value = Now
                        '            dlg = frmPeriodoPruebas.ShowDialog


                        '            'If MsgBox("Se detectó un cambio de puesto, ¿Desea dar inicio al siguiente periodo de pruebas?" & vbCrLf &
                        '            '          "Reloj:" & vbTab & Reloj & vbCrLf &
                        '            '          "Puesto: " & vbTab & RTrim(drPuesto("nombre")).ToUpper & vbCrLf &
                        '            '          "Fecha:" & vbTab & FechaSQL(Now) & vbCrLf &
                        '            '          "Duración:" & vbTab & "30 Días", MsgBoxStyle.YesNo, "Inicio de periodo de pruebas") = MsgBoxResult.Yes Then

                        '            If dlg = Windows.Forms.DialogResult.Yes Then
                        '                sqlExecute("insert into mod_sal " & _
                        '                           "(cod_comp, reloj, cod_tipo_mod, cambio_de, cambio_a, provar, fact_int, fecha, notas, nivel, integrado, hoy, " & _
                        '                           "aplicado, fecha_aplicacion, usuario_aplicacion) " & _
                        '                           "values ('" & _
                        '                           drPersonal("cod_comp") & "', '" & _
                        '                           Reloj & "', '" & _
                        '                           "IPP" & "', " & _
                        '                           IIf(IsDBNull(drPersonal("sactual")), 0, drPersonal("sactual")) & ", " & _
                        '                           IIf(IsDBNull(drPersonal("sactual")), 0, drPersonal("sactual")) & ", " & _
                        '                           IIf(IsDBNull(drPersonal("pro_var")), 0, drPersonal("pro_var")) & ", " & _
                        '                           IIf(IsDBNull(drPersonal("factor_int")), 0, drPersonal("factor_int")) & ", '" & _
                        '                           strRespuesta & "', " & _
                        '                           "'CAMBIO DE PUESTO APLICADO DESDE EL MAESTRO " & Valor & "', '" & _
                        '                           drPersonal("nivel") & "', " & _
                        '                           IIf(IsDBNull(drPersonal("integrado")), 0, drPersonal("integrado")) & ", '" & _
                        '                           FechaSQL(Now) & "', " & _
                        '                           "'1', '" & _
                        '                           FechaSQL(Now) & "', '" & _
                        '                           Usuario & "')")
                        '            End If
                        '        End If

                        '    End If

                        'End If

                    End If

                ElseIf Campo.ToUpper = "LOCKER" Then
                    Dim locker As String = RTrim(txtLocker.Text)
                    Dim candado As String = RTrim(txtCandado.Text)
                    Dim combinacion As String = RTrim(txtCombinacion.Text)

                    If locker <> "" Then

                        Dim locker_ant As String = ""
                        Dim candado_ant As String = ""
                        Dim combinacion_ant As String = ""

                        Dim dtAnt As DataTable = sqlExecute("select reloj, rtrim(isnull(locker, '')) as locker,  rtrim(isnull(candado, '')) as candado,  rtrim(isnull(combinacion, '')) as combinacion from personal where reloj = '" & Reloj & "'")
                        If dtAnt.Rows.Count > 0 Then
                            locker_ant = dtAnt.Rows(0)("locker")
                            candado_ant = dtAnt.Rows(0)("candado")
                            combinacion_ant = dtAnt.Rows(0)("combinacion")
                        End If

                        Dim dtExiste As DataTable = sqlExecute("select reloj, nombres, baja, rtrim(isnull(locker, '')) as locker, rtrim(isnull(candado, '')) as candado, rtrim(isnull(combinacion, '')) as combinacion from personalvw where locker = '" & locker & "' and reloj <> '" & Reloj & "'")
                        If dtExiste.Rows.Count > 0 Then

                            Dim mensaje As String = ""

                            If dtExiste.Rows.Count = 1 Then
                                mensaje = "El siguiente empleado tiene asignado el locker " & locker & ":" & vbCrLf & vbCrLf
                            Else
                                mensaje = "Los siguientes empleados tienen asignado el locker " & locker & ":" & vbCrLf & vbCrLf
                            End If

                            Dim todos_bajas As Boolean = True

                            For Each row As DataRow In dtExiste.Rows

                                Dim _r As String = row("reloj")
                                Dim _n As String = row("nombres")
                                Dim _estatus As String = "INACTIVO"
                                If IsDBNull(row("baja")) Then
                                    todos_bajas = False
                                    _estatus = "estatus"
                                End If

                                mensaje &= _r & " | " & _n & " | " & _estatus & vbCrLf

                            Next

                            If todos_bajas Then
                                mensaje &= vbCrLf & "¿Desea reasignar el locker al empleado " & Reloj & " ?"
                            Else
                                If dtExiste.Rows.Count = 1 Then
                                    mensaje &= vbCrLf & "El empleado sigue activo, no es posible hacer esta asignación"
                                Else
                                    mensaje &= vbCrLf & "Los empleados siguen activos, no es posible hacer esta asignación"
                                End If
                            End If

                            If todos_bajas Then
                                If MessageBox.Show(mensaje, "Locker asignado", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.Yes Then
                                    For Each row As DataRow In dtExiste.Rows
                                        Dim _locker_r As String = row("locker")
                                        Dim _candado_r As String = row("candado")
                                        Dim _combinacion_r As String = row("combinacion")

                                        sqlExecute("update personal set locker = null, candado = null, combinacion = null where reloj = '" & row("reloj") & "'")
                                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,fecha_mantenimiento) VALUES ('"
                                        Cadena = Cadena & row("reloj") & "','locker','" & _locker_r & "','','" & Usuario & "','" & FechaSQL(fecha_bitacora_wme) & "','C',getdate())"
                                        sqlExecute(Cadena)

                                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,fecha_mantenimiento) VALUES ('"
                                        Cadena = Cadena & row("reloj") & "','candado','" & _candado_r & "','','" & Usuario & "','" & FechaSQL(fecha_bitacora_wme) & "','C',getdate())"
                                        sqlExecute(Cadena)

                                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,fecha_mantenimiento) VALUES ('"
                                        Cadena = Cadena & row("reloj") & "','combinacion','" & _combinacion_r & "','','" & Usuario & "','" & FechaSQL(fecha_bitacora_wme) & "','C',getdate())"
                                        sqlExecute(Cadena)

                                    Next

                                    If locker_ant <> locker Then
                                        sqlExecute("update personal set locker = '" & locker & "' where reloj = '" & Reloj & "'")

                                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,fecha_mantenimiento) VALUES ('"
                                        Cadena = Cadena & Reloj & "','locker','" & locker_ant & "','" & locker & "','" & Usuario & "','" & FechaSQL(fecha_bitacora_wme) & "','C',getdate())"
                                        sqlExecute(Cadena)
                                    End If

                                    If candado_ant <> candado Then
                                        sqlExecute("update personal set candado = '" & candado & "' where reloj = '" & Reloj & "'")

                                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,fecha_mantenimiento) VALUES ('"
                                        Cadena = Cadena & Reloj & "','candado','" & candado_ant & "','" & candado & "','" & Usuario & "','" & FechaSQL(fecha_bitacora_wme) & "','C',getdate())"
                                        sqlExecute(Cadena)
                                    End If

                                    If combinacion_ant <> combinacion Then
                                        sqlExecute("update personal set combinacion = '" & combinacion & "' where reloj = '" & Reloj & "'")

                                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,fecha_mantenimiento) VALUES ('"
                                        Cadena = Cadena & Reloj & "','combinacion','" & combinacion_ant & "','" & combinacion & "','" & Usuario & "','" & FechaSQL(fecha_bitacora_wme) & "','C',getdate())"
                                        sqlExecute(Cadena)
                                    End If

                                End If
                            Else
                                MessageBox.Show(mensaje, "Locker asignado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If

                        Else
                            If locker_ant <> locker Then
                                sqlExecute("update personal set locker = '" & locker & "' where reloj = '" & Reloj & "'")

                                Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,fecha_mantenimiento) VALUES ('"
                                Cadena = Cadena & Reloj & "','locker','" & locker_ant & "','" & locker & "','" & Usuario & "','" & FechaSQL(fecha_bitacora_wme) & "','C',getdate())"
                                sqlExecute(Cadena)
                            End If

                            If candado_ant <> candado Then
                                sqlExecute("update personal set candado = '" & candado & "' where reloj = '" & Reloj & "'")

                                Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,fecha_mantenimiento) VALUES ('"
                                Cadena = Cadena & Reloj & "','candado','" & candado_ant & "','" & candado & "','" & Usuario & "','" & FechaSQL(fecha_bitacora_wme) & "','C',getdate())"
                                sqlExecute(Cadena)
                            End If

                            If combinacion_ant <> combinacion Then
                                sqlExecute("update personal set combinacion = '" & combinacion & "' where reloj = '" & Reloj & "'")

                                Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,fecha_mantenimiento) VALUES ('"
                                Cadena = Cadena & Reloj & "','combinacion','" & combinacion_ant & "','" & combinacion & "','" & Usuario & "','" & FechaSQL(fecha_bitacora_wme) & "','C',getdate())"
                                sqlExecute(Cadena)
                            End If

                        End If
                    End If

                ElseIf Campo.ToUpper = "COD_HORA" Then '-- AOS: 13/04/2021: Para el cod_hora actualizar en bitacora personal de manera diferente

                    If Valor Is Nothing Then Valor = ""

                    '******************---------------**************************-----PROCESO DE WOLLSDORF PARA PROGRAMAR HORARIOS ***************-------*************-------------*-****************

                    '1-- Ver que periodo es de acuerdo a la fecha en donde estan aplicando el cambio, donde se le va a sumar 1 día**/
                    'Dim dtFecFin As DataTable = sqlExecute("select  DATEADD(DD, 1, FECHA_FIN) as fecha_fin from TA.dbo.periodos where '" & FechaSQL(fecha_bitacora_wme) & "' BETWEEN FECHA_INI and FECHA_FIN and ISNULL(periodo_especial,0)=0", "TA")
                    'Dim fecFin As String = ""
                    'If (Not dtFecFin.Columns.Contains("Error") And dtFecFin.Rows.Count > 0) Then
                    '    Try : fecFin = FechaSQL(dtFecFin.Rows(0).Item("fecha_fin").ToString.Trim) : Catch ex As Exception : fecFin = "" : End Try
                    'End If

                    ''2-- Borrar de bitacora_personal donde estén esos campos
                    'sqlExecute("delete from bitacora_personal where reloj='" & Reloj & "' and fecha='" & fecFin & "' and campo in('cod_hora','cod_turno')", "PERSONAL")

                    ''3-- Insertarlo en bitacora_personal ya con los valores correctos
                    'sqlExecute("insert into bitacora_personal (reloj,campo,ValorAnterior,ValorNuevo,usuario,fecha,tipo_movimiento) values ('" & Reloj & "','cod_hora','" & Valor & "','','Pida','" & fecFin & "','C')", "PERSONAL")
                    'sqlExecute("insert into bitacora_personal (reloj,campo,ValorAnterior,ValorNuevo,usuario,fecha,tipo_movimiento) values ('" & Reloj & "','cod_turno','" & cmbTurno.SelectedValue & "','','Pida','" & fecFin & "','C')", "PERSONAL")

                    '-----------************************------------------------------**********END: PROCESO DE WOLLSDORF PARA PROGRAMAR HORARIOS**********************------------------------*******************------

                    '**************************************------------------------PROCESO NORMAL ******************************--------------------------************************
                    dtTemp = sqlExecute("SELECT cod_hora from personalvw WHERE reloj = '" & Reloj & "'")
                    ValAnt = ""
                    If dtTemp.Rows.Count > 0 Then ValAnt = IIf(IsDBNull(dtTemp.Rows(0)("cod_hora")), "", dtTemp.Rows(0)("cod_hora"))
                    If Valor Is Nothing Then Valor = ""
                    If ValAnt.Trim <> Valor.ToString.Trim Then
                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,fecha_mantenimiento) VALUES ('"
                        Cadena = Cadena & Reloj & "','" & Campo & "','" & ValAnt & "','" & Valor & "','" & Usuario & "','" & FechaSQL(fecha_bitacora_wme) & "','" & TipoMovimiento & "',getdate())"
                        sqlExecute(Cadena)
                    End If
                    '**************************************------------------------ENDS PROCESO NORMAL ******************************--------------------------************************


                    If Valor = "NULL" Then
                        sqlExecute("UPDATE personal SET " & Campo & " = NULL WHERE reloj = '" & Reloj & "'")
                    Else
                        sqlExecute("UPDATE personal SET " & Campo & " = '" & Valor & "' WHERE reloj = '" & Reloj & "'")
                    End If

                ElseIf Campo.ToUpper = "COD_TURNO" Then '
                    dtTemp = sqlExecute("SELECT cod_turno from personalvw WHERE reloj = '" & Reloj & "'")
                    ValAnt = ""
                    If dtTemp.Rows.Count > 0 Then ValAnt = IIf(IsDBNull(dtTemp.Rows(0)("cod_turno")), "", dtTemp.Rows(0)("cod_turno"))
                    If Valor Is Nothing Then Valor = ""
                    If ValAnt.Trim <> Valor.ToString.Trim Then
                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,fecha_mantenimiento) VALUES ('"
                        Cadena = Cadena & Reloj & "','" & Campo & "','" & ValAnt & "','" & Valor & "','" & Usuario & "','" & FechaSQL(fecha_bitacora_wme) & "','" & TipoMovimiento & "',getdate())"
                        sqlExecute(Cadena)
                    End If


                    If Valor = "NULL" Then
                        sqlExecute("UPDATE personal SET " & Campo & " = NULL WHERE reloj = '" & Reloj & "'")
                    Else
                        sqlExecute("UPDATE personal SET " & Campo & " = '" & Valor & "' WHERE reloj = '" & Reloj & "'")
                    End If

                Else
                    Dim campo2 As String = ""
                    If (Campo = "cod_costos") Then
                        campo2 = "CENTRO_COSTOS"
                    Else
                        campo2 = Campo
                    End If

                    dtTemp = sqlExecute("SELECT " & campo2 & " from personalvw WHERE reloj = '" & Reloj & "'")
                    ValAnt = IIf(IsDBNull(dtTemp.Rows.Item(0).Item(0)), "", dtTemp.Rows.Item(0).Item(0))
                    If Valor Is Nothing Then
                        Valor = ""
                    End If

                    If ValAnt.Trim <> Valor.ToString.Trim Then
                        Cadena = "INSERT INTO bitacora_personal (reloj,campo,valorAnterior,valorNuevo,usuario,fecha,tipo_movimiento,fecha_mantenimiento) VALUES ('"
                        Cadena = Cadena & Reloj & "','" & Campo & "','" & ValAnt & "','" & Valor & "','" & Usuario & "','" & FechaSQL(fecha_bitacora_wme) & "','" & TipoMovimiento & "',getdate())"
                        sqlExecute(Cadena)

                        If Valor = "NULL" Then
                            sqlExecute("UPDATE personal SET " & Campo & " = NULL WHERE reloj = '" & Reloj & "'")
                        Else
                            sqlExecute("UPDATE personal SET " & Campo & " = '" & Valor & "' WHERE reloj = '" & Reloj & "'")
                        End If

                        'MCR (6-OCT-2015)
                        'Si el campo es cod_depto o cod_super, modificar asist en el periodo actual
                        If Campo.Trim.ToUpper = "COD_DEPTO" Or Campo.Trim.ToUpper = "COD_SUPER" Then
                            AnoPeriodo = ObtenerAnoPeriodo(Now)
                            sqlExecute("UPDATE asist SET " & Campo & " = '" & Valor & "' WHERE reloj = '" & Reloj & _
                                       "' AND ano = '" & AnoPeriodo.Substring(0, 4) & "' AND periodo = '" & AnoPeriodo.Substring(4, 2) & "'", "TA")
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Function AceptarCambios() As Boolean
        Dim Reloj As String, Nombres As String
        Dim alta As Date
        'Dim Ano As String, Periodo As String
        'Dim Cadena As String
        'Dim ClaveVA As String, ClaveAG As String

        Try
            alta = txtAlta.Value
            Reloj = txtReloj.Text
            Nombres = txtApaterno.Text.Trim & "," & txtAmaterno.Text.Trim & "," & txtNombre.Text.Trim

            If Nuevo Then

                'If (cmbCia.SelectedValue = "090") Then

                '    Dim dtReloj As New DataTable

                '    If cmbTipo.SelectedValue = "A" Then
                '        dtReloj = sqlExecute("select top 1 reloj from personalvw where reloj > '020000' and reloj < '030000' and cod_comp = '" & cmbCia.SelectedValue & "' order by reloj desc")
                '    Else
                '        dtReloj = sqlExecute("select top 1 reloj from personalvw where reloj > '030000' and reloj < '070000' and cod_comp = '" & cmbCia.SelectedValue & "' order by reloj desc")
                '    End If

                '    If dtReloj.Rows.Count Then
                '        txtReloj.Text = (Integer.Parse(dtReloj.Rows(0)("reloj")) + 1).ToString.PadLeft(6, "0")
                '    End If

                '    txtReloj.Enabled = False
                'Else
                '    txtReloj.Enabled = Nuevo
                'End If

                dtTemporal = sqlExecute("INSERT INTO personal (reloj) VALUES ('" & Reloj & "')")
                'MCR 26/OCT/2015
                'Si se genera un error al insertar, avisar al usuario y salir de la función
                If dtTemporal.Columns.Contains("ERROR") Then
                    Err.Raise(0, "AceptarCambios", "Se detectó un error al insertar el número de reloj <" & Reloj & ">. Favor de verificar.")
                End If
            End If

            '---- 2024-03-26: Se desactiva poner una fecha en los cambios o guardados
            'Dim frmfecha As New frmSeleccionarFecha
            'frmfecha.ReflectionLabel1.Text = "Seleccionar fecha de cambio"
            'frmfecha.ShowDialog()
            'frmfecha.ReflectionLabel1.Text = "Seleccionar fecha"

            '------------Insertar o actualizar campos referente a la carga de documentos
            ActualizaDocumentos(txtReloj.Text, txtDescArch1.Text, lblTpoDoc1.Text, "01")
            ActualizaDocumentos(txtReloj.Text, txtDescArch2.Text, lblTpoDoc2.Text, "02")
            ActualizaDocumentos(txtReloj.Text, txtDescArch3.Text, lblTpoDoc3.Text, "03")
            ActualizaDocumentos(txtReloj.Text, txtDescArch4.Text, lblTpoDoc4.Text, "04")
            ActualizaDocumentos(txtReloj.Text, txtDescArch5.Text, lblTpoDoc1.Text, "05")
            ActualizaDocumentos(txtReloj.Text, txtDescArch6.Text, lblTpoDoc1.Text, "06")
            ActualizaDocumentos(txtReloj.Text, txtDescArch7.Text, lblTpoDoc1.Text, "07")
            ActualizaDocumentos(txtReloj.Text, txtDescArch8.Text, lblTpoDoc1.Text, "08")


            EditaPersonal(Reloj, "nombres", txtApaterno.Text.Trim & "," & txtAmaterno.Text.Trim & "," & txtNombre.Text.Trim)

            EditaPersonal(Reloj, "nombre", txtNombre.Text)
            EditaPersonal(Reloj, "apaterno", txtApaterno.Text)
            EditaPersonal(Reloj, "amaterno", txtAmaterno.Text)
            EditaPersonal(Reloj, "sexo", IIf(btnSexo.Value, "F", "M"))
            EditaPersonal(Reloj, "inactivo", IIf(sbInactivo.Value, 1, 0))
            EditaPersonal(Reloj, "alta", txtAlta.Value)
            EditaPersonal(Reloj, "alta_vacacion", txtAlta.Value)
            EditaPersonal(Reloj, "baja", txtBaja.Value)

            EditaPersonal(Reloj, "cod_comp", cmbCia.SelectedValue)
            EditaPersonal(Reloj, "cod_planta", cmbPlanta.SelectedValue)

            EditaPersonal(Reloj, "cod_area", cmbArea.SelectedValue)

            EditaPersonal(Reloj, "cod_depto", cmbDepto.SelectedValue)
            EditaPersonal(Reloj, "cod_costos", cmbCCostos.SelectedValue)

            '  EditaPersonal(Reloj, "sindicalizado", cmbSindicalizado.SelectedValue)
            EditaPersonal(Reloj, "tipo_periodo", cmbTipoPeriodo.SelectedValue)

            EditaPersonal(Reloj, "cod_super", cmbSuper.SelectedValue)

            '==HACER CAMBIOS EN LIDER               10Dic2021           Ernesto
            EditaPersonal(Reloj, "cod_linea", cmbLider.SelectedValue)


            EditaPersonal(Reloj, "cod_puesto", cmbPuesto.SelectedValue)
            EditaPersonal(Reloj, "cod_tipo", cmbTipo.SelectedValue)
            EditaPersonal(Reloj, "cod_clase", cmbClase.SelectedValue)
            EditaPersonal(Reloj, "cod_turno", cmbTurno.SelectedValue)
            EditaPersonal(Reloj, "cod_hora", cmbHorario.SelectedValue)
            'EditaPersonal(Reloj, "cod_cate", cmbCategoria.SelectedValue)
            'EditaPersonal(Reloj, "cod_celula", cmbCelula.SelectedValue)
            'EditaPersonal(Reloj, "cod_hyperion", cmbHyperion.SelectedValue)

            EditaPersonal(Reloj, "imss", txtIMSS.Text & "-" & IIf(txtIMSSdv.Text = "", 0, txtIMSSdv.Text))
            'EditaPersonal(Reloj, "dig_ver", txtIMSSdv.Text)
            EditaPersonal(Reloj, "rfc", txtRFC.Text)
            EditaPersonal(Reloj, "curp", txtCurp.Text)
            EditaPersonal(Reloj, "sexo", IIf(btnSexo.Value, "F", "M"))
            'EditaPersonal(Reloj, "inactivo", IIf(sbInactivo.Value, 1, 0))
            EditaPersonal(Reloj, "gafete", txtGafete.Text)
            EditaPersonal(Reloj, "checa_tarjeta", chkChecaTarjeta.Checked)
            EditaPersonal(Reloj, "tipo_pago", cmbCodPago.SelectedValue)
            EditaPersonal(Reloj, "banco", cmbBanco.SelectedValue)
            EditaPersonal(Reloj, "cuenta_banco", txtCuenta.Text)

            EditaPersonal(Reloj, "cp_sat", txtCpSAT.Text)
            EditaPersonal(Reloj, "COD_REG_SAT", cmbRegFiscSAT.SelectedValue)

            If nReingresos <= NivelSueldos And (Nuevo Or Reingreso Or Editar) Then
                EditaPersonal(Reloj, "nivel", cmbNivel.SelectedValue)
                EditaPersonal(Reloj, "sactual", CDbl(txtSActual.Text))
                EditaPersonal(Reloj, "factor_int", CDbl(txtFactorInt.Text))
                EditaPersonal(Reloj, "pro_var", CDbl(txtProVar.Text))
                EditaPersonal(Reloj, "integrado", CDbl(txtIntegrado.Text))
            End If

            '**** Información Expediente\Personal
            EditaPersonal(Reloj, "direccion", txtDireccion.Text)
            EditaPersonal(Reloj, "telefono", txtTelefono.Text)
            EditaPersonal(Reloj, "telefono2", txtTelefono2.Text)
            EditaPersonal(Reloj, "telefono3", txtTelefono3.Text)
            EditaPersonal(Reloj, "telefono4", txtTelefono2.Text)
            EditaPersonal(Reloj, "telefono5", txtTelefono3.Text)
            EditaPersonal(Reloj, "umf", txtUMF.Text)
            EditaPersonal(Reloj, "cod_col", cmbColonia.SelectedValue)
            EditaPersonal(Reloj, "cod_cd", cmbCd.SelectedValue)
            EditaPersonal(Reloj, "lugarn", cmbLugarNac.SelectedValue)
            EditaPersonal(Reloj, "fha_nac", txtFechaNac.Value)
            EditaPersonal(Reloj, "cod_civil", cmbEdoCivil.SelectedValue)
            EditaPersonal(Reloj, "email", txtEmail_empl.Text)
            EditaPersonal(Reloj, "email_empresa", txtEmailEmpresa.Text)

            EditaPersonal(Reloj, "locker", txtLocker.Text)

            SaveInfoLocker(Reloj, txtLocker.Text)  '---2023-09: Solicita Christian que al actualizar el locker, se actualice también en la tabla de lockers

            EditaPersonal(Reloj, "aviso_acc", txtAccidente.Text)

            '***** Información del banco y cuentas
            EditaPersonal(Reloj, "BANCO", cmbBancoExp.SelectedValue) ' 
            EditaPersonal(Reloj, "CUENTA_BANCO", txtCuentaExp.Text.Trim)
            EditaPersonal(Reloj, "TARJETA_BANCO", txtTarjeta.Text.Trim)
            EditaPersonal(Reloj, "CLABE", txtClabe.Text.Trim)

            '**** Información Expediente\INFONAVIT
            'EditaPersonal(Reloj, "credito_in", IIf(btnCredito.Value = True, 1, 0))
            'EditaPersonal(Reloj, "tipo_cre", cmbTipoCredito.SelectedValue)
            'EditaPersonal(Reloj, "infonavit", txtInfonavit.Text)
            'EditaPersonal(Reloj, "dig_ver_in", txtInfonavitDV.Text)
            'EditaPersonal(Reloj, "fecha_cre", dtFechaInfonavit.Value.Date)
            'EditaPersonal(Reloj, "pago_inf", CDbl(txtPagoInfonavit.Text))

            '************Editar Infonavit
            Dim infonavit As String = ""
            infonavit = txtNumeroCredito.Text.Trim
            'tipo_cred = cmbTipoInfonavit.SelectedValue
            'cuota_cred = txtFactorDeDescuentoInfonavit.Text
            'inicio_cre = FechaSQL(dtpFechaInicioCreditoInfonavit.Value)

            '=============== Validar si el mov es 99, eliminar el actual, y dejar como activo el ultimo


            If cmbTipoMovInfonavit.SelectedValue = "99" Then

                Dim dtRecInfoExistente = sqlExecute("select  top 1 *  from infonavit where reloj='" & txtReloj.Text.Trim & "' order by fechahora desc", "PERSONAL")
                If dtRecInfoExistente.Rows.Count > 0 Then
                    Dim _info As String = "", cuota_cre As String = "", tipo_cre As String = "", cod_movimiento As String = ""
                    Try : _info = dtRecInfoExistente.Rows(0).Item("infonavit").ToString.Trim : Catch ex As Exception : _info = "" : End Try
                    Try : cuota_cre = dtRecInfoExistente.Rows(0).Item("cuota_cred").ToString.Trim : Catch ex As Exception : cuota_cre = "0.00" : End Try
                    Try : tipo_cre = dtRecInfoExistente.Rows(0).Item("tipo_cred").ToString.Trim : Catch ex As Exception : tipo_cre = "" : End Try
                    Try : cod_movimiento = dtRecInfoExistente.Rows(0).Item("cod_movimiento").ToString.Trim : Catch ex As Exception : cod_movimiento = "" : End Try

                    sqlExecute("delete from infonavit where reloj='" & txtReloj.Text.Trim & "' and infonavit='" & _info & "'  and tipo_cred='" & tipo_cre & "' and cuota_cred=" & cuota_cre & " and cod_movimiento='" & cod_movimiento & "'", "PERSONAL")

                    '---Dejar como activo el ultimo
                    dtRecInfoExistente = sqlExecute("select  top 1 *  from infonavit where reloj='" & txtReloj.Text.Trim & "' order by fechahora desc", "PERSONAL")
                    If dtRecInfoExistente.Rows.Count > 0 Then
                        Try : _info = dtRecInfoExistente.Rows(0).Item("infonavit").ToString.Trim : Catch ex As Exception : _info = "" : End Try
                        Try : cuota_cre = dtRecInfoExistente.Rows(0).Item("cuota_cred").ToString.Trim : Catch ex As Exception : cuota_cre = "0.00" : End Try
                        Try : tipo_cre = dtRecInfoExistente.Rows(0).Item("tipo_cred").ToString.Trim : Catch ex As Exception : tipo_cre = "" : End Try
                        Try : cod_movimiento = dtRecInfoExistente.Rows(0).Item("cod_movimiento").ToString.Trim : Catch ex As Exception : cod_movimiento = "" : End Try

                        sqlExecute("update infonavit set activo=1 where reloj='" & txtReloj.Text.Trim & "' and infonavit='" & _info & "'  and tipo_cred='" & tipo_cre & "' and cuota_cred=" & cuota_cre & " and cod_movimiento='" & cod_movimiento & "'", "PERSONAL")
                    End If

                End If
                GoTo salirEdicionInfonavit
            End If


            '==============Preguntar si desea editar el existente o agregar un nuevo registro, siempre y cuando no sea la primera vez que se agregue un 1er registro y que no sea el movimeinto de suspension
            If cmbTipoMovInfonavit.SelectedValue <> "" Then
                If Not addInfoFirstTime And cmbTipoMovInfonavit.SelectedValue <> "16" Then
                    ' If MessageBox.Show("¿Desea editar el registro existente?, al colocar 'NO',es decir, no editar el registro, se agregaría un movimiento nuevo que afectaría al historial y al SUA", "Editar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                    Dim dtRecInfoExistente = sqlExecute("select  top 1 *  from infonavit where reloj='" & txtReloj.Text.Trim & "' order by fechahora desc", "PERSONAL")
                    If dtRecInfoExistente.Rows.Count > 0 Then
                        Dim _info As String = "", cuota_cre As String = "", tipo_cre As String = "", cod_movimiento As String = ""
                        Try : _info = dtRecInfoExistente.Rows(0).Item("infonavit").ToString.Trim : Catch ex As Exception : _info = "" : End Try
                        Try : cuota_cre = dtRecInfoExistente.Rows(0).Item("cuota_cred").ToString.Trim : Catch ex As Exception : cuota_cre = "0.00" : End Try
                        Try : tipo_cre = dtRecInfoExistente.Rows(0).Item("tipo_cred").ToString.Trim : Catch ex As Exception : tipo_cre = "" : End Try
                        Try : cod_movimiento = dtRecInfoExistente.Rows(0).Item("cod_movimiento").ToString.Trim : Catch ex As Exception : cod_movimiento = "" : End Try

                        '===== Hacer pregunta si se desea editar
                        Dim _cod_mov_edit As String = "", infonavit_edit As String = "", tipo_cre_edit As String = "", cuota_cre_edit As Double = 0.0, cambio_info As Boolean = False

                        Try : _cod_mov_edit = cmbTipoMovInfonavit.SelectedValue.ToString.Trim : Catch ex As Exception : _cod_mov_edit = "" : End Try
                        Try : infonavit_edit = txtNumeroCredito.Text.Trim : Catch ex As Exception : infonavit_edit = "" : End Try
                        Try : tipo_cre_edit = cmbTipoInfonavit.SelectedValue.ToString.Trim : Catch ex As Exception : tipo_cre_edit = "" : End Try
                        Try : cuota_cre_edit = Double.Parse(txtFactorDeDescuentoInfonavit.Text) : Catch ex As Exception : cuota_cre_edit = 0.0 : End Try

                        If (cod_movimiento <> _cod_mov_edit) Or (_info <> infonavit_edit) Or (tipo_cre <> tipo_cre_edit) Or (Double.Parse(cuota_cre) <> cuota_cre_edit) Then
                            cambio_info = True
                        End If


                        If cambio_info Then

                            If MessageBox.Show("¿Desea editar el registro existente?, al colocar 'NO',es decir, no editar el registro, se agregaría un movimiento nuevo que afectaría al historial y al SUA", "Editar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                                If cod_movimiento = "30" Then
                                    Try : _finicio_cred_infonavit = FechaSQL(dtRecInfoExistente.Rows(0).Item("inicio_cre").ToString.Trim) : Catch ex As Exception : _finicio_cred_infonavit = "" = "" : End Try
                                End If

                                sqlExecute("delete from infonavit where reloj='" & txtReloj.Text.Trim & "' and infonavit='" & _info & "'  and tipo_cred='" & tipo_cre & "' and cuota_cred=" & cuota_cre & " and cod_movimiento='" & cod_movimiento & "'", "PERSONAL")
                            End If
                        End If


                    End If

                    '  End If
                End If
            End If

            EditaInfonavit(Reloj, infonavit, "tipo_cred", cmbTipoInfonavit.SelectedValue)
            EditaInfonavit(Reloj, infonavit, "cuota_cred", txtFactorDeDescuentoInfonavit.Text)
            EditaInfonavit(Reloj, infonavit, "inicio_cre", FechaSQL(dtpFechaInicioCreditoInfonavit.Value))
            EditaInfonavit(Reloj, infonavit, "cod_movimiento", cmbTipoMovInfonavit.SelectedValue)
            addInfoFirstTime = False

salirEdicionInfonavit:

            '**** Información Expediente\Comentarios
            EditaPersonal(Reloj, "comentario", txtComentarios.Text)

            '**** Información Expediente\Tarjetas
            EditaPersonal(Reloj, "tarjeta_banco", txtTarjeta.Text.Trim)
            EditaPersonal(Reloj, "clabe", txtClabe.Text.Trim)

            EditaPersonal(Reloj, "id_bonos", txtIDBonos.Text)
            EditaPersonal(Reloj, "cuenta_bonos", txtCuentaBonos.Text)
            EditaPersonal(Reloj, "tarjeta_bonos", txtTarjetaBonos.Text)
            EditaPersonal(Reloj, "adicional_bonos", txtTarjetaAdicBonos.Text)


            '******* Información de baja
            EditaPersonal(Reloj, "recontrata", IIf(sbrecontrata.Value = True, 1, 0))
            EditaPersonal(Reloj, "notas_baja", txtNotasBaja.Text) ' 2022-06-24 Sergio Núñez

            '--AOS 11/11/2019
            Dim txBja As String = ""
            Try : txBja = FechaSQL(txtBaja.Value) : Catch ex As Exception : txBja = "" : End Try

            If (txBja.Trim <> "" And txBja.Trim <> "0001-01-01") Then
                CalcDAgDVacDPvac(Reloj, txtBaja.Value, True) ' 22/10/2019 - AOS calcular dias de agui, vac y de prima vac cuando sean baja
            End If


            If (DarDeBaja Or (txBja.Trim <> "" And txBja.Trim <> "0001-01-01")) Then

                If cmbBajaInterno.SelectedValue = Nothing Then
                    MessageBox.Show("No se a capturado un motivo de baja, seleccione uno y vuelva a intentarlo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False

                End If
                If txtEBaja.Value > Now Then
                    If txtEBaja.Value.Subtract(Now).Days > 15 Then
                        If MsgBox("La fecha esta fuera del periodo actual, ¿Desea continuar aún así?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            Return False
                        End If
                    End If
                ElseIf txtEBaja.Value < Now Then
                    If Now.Subtract(txtEBaja.Value).Days > 15 Then
                        If MsgBox("La fecha esta fuera del periodo actual, ¿Desea continuar aún así?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            Return False
                        End If
                    End If
                End If

                CalcDAgDVacDPvac(Reloj, txtEBaja.Value, True) ' 22/10/2019 - AOS calcular dias de agui, vac y de prima vac cuando sean baja

                EditaPersonal(Reloj, "baja", txtEBaja.Value)
                EditaPersonal(Reloj, "cod_mot_ba", cmbBajaInterno.SelectedValue)
                EditaPersonal(Reloj, "cod_mot_im", cmbBajaIMSS.SelectedValue)
                EditaPersonal(Reloj, "cod_sub_ba", cmbsubmotivo.SelectedValue)

                '---AO 2023-03-14 Actualizar mtro_ded suspendiendo el saldo del fondo de ahorro
                sqlExecute("update mtro_ded set STATUS=0 where reloj='" & Reloj & "' and concepto in ('SAFAHC','SAFAHE')", "NOMINA")

                'Transferencias desde la baja hacia un empleado existente
                Try
                    Dim dtAplica As DataTable = sqlExecute("select reloj, (imss + dig_ver) as imss, cod_comp, alta, baja from personal where reloj = '" & Reloj & "' and cod_mot_ba = '06' and baja is not null and cod_comp in ('002')", "personal")
                    If dtAplica.Rows.Count > 0 Then

                        Dim imss_transferencia As String = dtAplica.Rows(0)("imss")
                        Dim cod_comp_transferencia As String = dtAplica.Rows(0)("cod_comp")

                        Dim alta_transferencia As Date = dtAplica.Rows(0)("alta")
                        Dim baja_transferencia As Date = dtAplica.Rows(0)("baja")

                        Dim dtNuevo As DataTable = sqlExecute("select reloj, nombres, alta from personalvw where cod_comp = '610' and imss + dig_ver  = '" & imss_transferencia & "'", "personal")
                        If dtNuevo.Rows.Count > 0 Then
                            Dim reloj_nuevo As String = dtNuevo.Rows(0)("reloj")
                            Dim nombres_nuevo As String = dtNuevo.Rows(0)("nombres")
                            Dim alta_nuevo As Date = dtNuevo.Rows(0)("alta")

                            Dim dtexiste As DataTable = sqlExecute("select * from transferencias where reloj_anterior = '" & Reloj & "' and reloj_nuevo = '" & reloj_nuevo & "'", "personal")
                            If dtexiste.Rows.Count <= 0 Then

                                If MessageBox.Show("¿Desea marcar como transferencia el empleado " & Reloj & " al empleado " & reloj_nuevo & ", " & nombres_nuevo & "", "Transferencia a BRP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                                    sqlExecute("insert into transferencias (reloj_anterior, cod_comp_anterior, imss, alta_anterior, baja_anterior, reloj_nuevo, cod_comp_nuevo, alta) values (" & _
                                               "'" & Reloj & "', '" & cod_comp_transferencia & "', '" & imss_transferencia & "', '" & FechaSQL(alta_transferencia) & "', '" & FechaSQL(baja_transferencia) & "', '" & reloj_nuevo & "', '610', '" & FechaSQL(alta_nuevo) & "')", "personal")
                                End If


                            End If
                        End If


                    End If
                Catch ex As Exception
                    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
                End Try

                'If MessageBox.Show("¿Calcular días de vacaciones y aguinaldo para finiquito?", "Dar de baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                '    ' VACACIONES
                '    dtTemp = sqlExecute("SELECT TOP 1 saldo_dinero FROM saldos_vacaciones WHERE reloj = '" & Reloj & "' ORDER BY fecha_fin DESC")
                '    If dtTemp.Rows.Count > 0 Then
                '        SaldoVacaciones = dtTemp.Rows.Item(0).Item("saldo_dinero")
                '    Else
                '        SaldoVacaciones = 0
                '    End If
                '    SaldoVacaciones = SaldoVacaciones + ProporcionVacaciones(txtEAlta.Value, txtEBaja.Value, txtTipoEmp.Text, cmbCia.SelectedValue)

                '    ' AGUINALDO 
                '    Aguinaldo = ProporcionAguinaldo(txtEAlta.Value, txtEBaja.Value, txtTipoEmp.Text, cmbCia.SelectedValue)

                '    EditaPersonal(Reloj, "dias_vacaciones", SaldoVacaciones)
                '    EditaPersonal(Reloj, "dias_aguinaldo", Aguinaldo)
                'End If

                ''**** PROCESO PARA APLICAR VACACIONES EN MISCELANEOS DE NOMINA *******
                'dtTemp = sqlExecute("SELECT ano, periodo FROM periodos WHERE GETDATE() BETWEEN fecha_ini AND fecha_fin AND periodo_especial IS NULL OR periodo_especial = 0", "ta")
                'If dtTemp.Rows.Count > 0 Then
                '    Ano = dtTemp.Rows.Item(0).Item("ano")
                '    Periodo = dtTemp.Rows.Item(0).Item("periodo")
                'Else
                '    Ano = "XXXX"
                '    Periodo = "XX"
                'End If

                'dtTemp = sqlExecute("SELECT misce_clave FROM conceptos WHERE concepto = 'DIASVA'", "NOMINA")
                'If dtTemp.Rows.Count > 0 Then
                '    ClaveVA = dtTemp.Rows.Item(0).Item("misce_clave")
                'Else
                '    ClaveVA = ""
                'End If

                'dtTemp = sqlExecute("SELECT misce_clave FROM conceptos WHERE concepto = 'DIASAG'", "NOMINA")
                'If dtTemp.Rows.Count > 0 Then
                '    ClaveAG = dtTemp.Rows.Item(0).Item("misce_clave")
                'Else
                '    ClaveAG = ""
                'End If

                'Cadena = "INSERT INTO ajustes_nom (reloj,ano,periodo,per_ded,clave,monto,comentario,concepto,usuario,fecha) VALUES ('"
                'Cadena = Cadena & Reloj & "','" & Ano & "','" & Periodo & "','P','" & ClaveVA & "'," & SaldoVacaciones & ",'Días de vacaciones por finiquito','DIASVA','"
                'Cadena = Cadena & Usuario & "', GETDATE())"
                'sqlExecute(Cadena, "Nomina")

                'Cadena = "INSERT INTO ajustes_nom (reloj,ano,periodo,per_ded,clave,monto,comentario,concepto,usuario,fecha) VALUES ('"
                'Cadena = Cadena & Reloj & "','" & Ano & "','" & Periodo & "','P','" & ClaveAG & "'," & Aguinaldo & ",'Días de aguinaldo por finiquito','DIASAG','"
                'Cadena = Cadena & Usuario & "', GETDATE())"
                'sqlExecute(Cadena, "Nomina")

                'BORRAR CURSOS PROGRAMADOS, NO TOMADOS
                sqlExecute("DELETE FROM planeacion_empleados WHERE reloj = '" & Reloj & "' AND fecha_curso IS NULL", "capacitacion")
            End If

            '**** Información de reingreso
            If DarReingreso Then
                sqlExecute("INSERT INTO reingresos (reloj,fecha,alta,alta_ant,baja_ant,cod_mot_ba,cod_mot_im) VALUES ('" & Reloj & "','" & _
                           FechaSQL(Now) & "','" & FechaSQL(alta) & "','" & FechaSQL(AltaAnt) & "','" & FechaSQL(BajaAnt) & "','" & _
                           cmbBajaInterno.SelectedValue & "','" & cmbBajaIMSS.SelectedValue & "')")
                EditaPersonal(Reloj, "reingreso", 1)
                EditaPersonal(Reloj, "alta", alta)
                EditaPersonal(Reloj, "baja", "NULL")
                EditaPersonal(Reloj, "cod_mot_ba", "NULL")
                EditaPersonal(Reloj, "cod_mot_im", "NULL")
                sqlExecute("delete from saldos_vacaciones where reloj='" & Reloj & "'", "PERSONAL") '====Limpiar saldos de vacaciones
                sqlExecute("update personal.dbo.personal set PRO_VAR=0.00 where reloj='" & Reloj & "'", "PERSONAL")
            End If

            DarDeBaja = False
            DarReingreso = False
            Nuevo = False
            Editar = False
            Return True
            'HabilitarMaestro()
            'MostrarInformacion(Reloj)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnVerCias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim c As String = cmbCia.SelectedValue
            frmCias.ShowDialog(Me)
            dtCias = sqlExecute("SELECT * FROM CIAS order by CIA_DEFAULT desc")
            cmbCia.DataSource = dtCias
            If Not c = Nothing Then cmbCia.SelectedValue = c
            MostrarInformacion(txtReloj.Text)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            frmParametros.Focus()
        End Try
    End Sub

    Private Sub btnVerDeptos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim c As String = cmbDepto.SelectedValue
        Try
            frmDeptos.ShowDialog(Me)
            dtDeptos = sqlExecute("SELECT cod_depto,NOMBRE FROM deptos WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbDepto.DataSource = dtDeptos
            If Not c = Nothing Then cmbDepto.SelectedValue = c
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            frmDeptos.Focus()
        End Try
    End Sub

    Private Sub btnVerPlantas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim c As String = cmbPlanta.SelectedValue
            frmPlantas.ShowDialog()
            dtPlantas = sqlExecute("SELECT COD_PLANTA,NOMBRE FROM plantas WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbPlanta.DataSource = dtPlantas
            If Not c = Nothing Then cmbPlanta.SelectedValue = c
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            frmPlantas.Focus()
        End Try
    End Sub

    Private Sub btnVerAreas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim c As String = cmbArea.SelectedValue
            frmAreas.ShowDialog()
            dtAreas = sqlExecute("SELECT cod_area,NOMBRE FROM areas WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbArea.DataSource = dtAreas
            If Not c = Nothing Then cmbArea.SelectedValue = c
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            frmAreas.Focus()
        End Try
    End Sub


    Private Sub btnVerSupervisores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim c As String = cmbSuper.SelectedValue
            frmSuper.ShowDialog(Me)
            dtSuper = sqlExecute("SELECT cod_super,nombre FROM super WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbSuper.DataSource = dtSuper
            If Not c = Nothing Then cmbSuper.SelectedValue = c
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            frmSuper.Focus()
        End Try
    End Sub

    Private Sub btnVerPuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim c As String = cmbPuesto.SelectedValue
            frmPuestos.ShowDialog(Me)
            dtPuestos = sqlExecute("SELECT cod_puesto,nombre,(CASE activo WHEN 1 THEN '   *' ELSE '' END) as activo, rtrim(isnull(cod_sf, '')) as cod_sf FROM puestos WHERE cod_comp = '" & cmbCia.SelectedValue & "' and activo=1")
            cmbPuesto.DataSource = dtPuestos
            If Not c = Nothing Then cmbPuesto.SelectedValue = c
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            frmPuestos.Focus()
        End Try
    End Sub

    Private Sub btnVerTipoEmp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim c As String = cmbTipo.SelectedValue
            frmTipoEmp.ShowDialog(Me)
            dtTipos = sqlExecute("SELECT cod_tipo,nombre FROM tipo_emp WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbTipo.DataSource = dtTipos
            If Not c = Nothing Then cmbTipo.SelectedValue = c
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            frmTipoEmp.Focus()
        End Try
    End Sub

    Private Sub btnVerClases_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim c As String = cmbClase.SelectedValue
            frmClase.ShowDialog(Me)
            dtClases = sqlExecute("SELECT cod_clase,nombre FROM clase WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbClase.DataSource = dtClases
            If Not c = Nothing Then cmbClase.SelectedValue = c
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            frmClase.Focus()
        End Try
    End Sub

    Private Sub btnVerTurnos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim c As String = cmbTurno.SelectedValue
            frmTurnos.ShowDialog(Me)
            dtTurnos = sqlExecute("SELECT cod_turno,nombre FROM turnos WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbTurno.DataSource = dtTurnos
            If Not c = Nothing Then cmbTurno.SelectedValue = c
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            frmTurnos.Focus()
        End Try
    End Sub

    Private Sub btnVerHorarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim c As String = cmbHorario.SelectedValue
            frmHorarios.ShowDialog(Me)
            dtHorarios = sqlExecute("SELECT rtrim(cod_hora) as cod_hora ,nombre FROM horarios WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbHorario.DataSource = dtHorarios
            If Not c = Nothing Then cmbHorario.SelectedValue = c
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            frmHorarios.Focus()
        End Try
    End Sub
    Private Sub btnVerCodPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerCodPago.Click
        Try
            Dim c As String = cmbCodPago.SelectedValue
            frmFormaPago.ShowDialog(Me)
            dtCodPago = sqlExecute("SELECT tipo_pago,nombre FROM tipo_pago")
            cmbCodPago.DataSource = dtCodPago
            If Not c = Nothing Then cmbCodPago.SelectedValue = c
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            frmFormaPago.Focus()
        End Try
    End Sub

    Private Sub btnVerBanco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerBanco.Click
        Try
            Dim c As String = cmbBanco.SelectedValue
            frmBanco.ShowDialog(Me)
            dtBancos = sqlExecute("SELECT * FROM bancos")
            cmbBanco.DataSource = dtBancos
            cmbBanco.ValueMember = "banco"
            If Not c = Nothing Then
                cmbBanco.SelectedValue = c
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            frmBanco.Focus()
        End Try
    End Sub

    'Private Sub btnNivel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim c As String = cmbNivel.SelectedValue
    '        frmNivel.ShowDialog(Me)
    '        dtNivel = sqlExecute("SELECT nivel,nombre,sueldo FROM niveles WHERE cod_comp = '" & cmbCia.SelectedValue & "' AND cod_tipo = '" & cmbTipo.SelectedValue & "'")
    '        cmbNivel.DataSource = dtNivel
    '        If Not c = Nothing Then cmbNivel.SelectedValue = c
    '    Catch ex As Exception
    '        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
    '    Finally
    '        frmNivel.Focus()
    '    End Try
    'End Sub

    Private Sub btnVerCiudades_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerCiudades.Click
        Try
            Dim c As String = cmbCd.SelectedValue
            frmCiudades.ShowDialog(Me)
            dtCiudad = sqlExecute("SELECT cod_cd,nombre FROM ciudad")
            cmbCd.DataSource = dtCiudad
            If Not c = Nothing Then cmbCd.SelectedValue = c
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            frmCiudades.Focus()
        End Try
    End Sub

    Private Sub btnVerColonias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerColonias.Click
        Try
            Dim c As String = cmbColonia.SelectedValue
            frmColonias.ShowDialog(Me)
            dtColonia = sqlExecute("SELECT cod_col,nombre FROM colonias")
            cmbColonia.DataSource = dtColonia
            If Not c = Nothing Then cmbColonia.SelectedValue = c
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            frmColonias.Focus()
        End Try
    End Sub

    Private Sub btnLugarNac_Click(sender As System.Object, e As System.EventArgs) Handles btnLugarNac.Click
        Try
            Dim c As String = cmbLugarNac.SelectedValue
            frmEstados.ShowDialog(Me)
            dtEstado = sqlExecute("SELECT cod_edo,nombre FROM estados")
            cmbLugarNac.DataSource = dtEstado
            If Not c = Nothing Then cmbLugarNac.SelectedValue = c
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            frmEstados.Focus()
        End Try
    End Sub

    Private Sub btnEdocivil_Click(sender As System.Object, e As System.EventArgs) Handles btnEdoCivil.Click
        Try
            Dim c As String = cmbEdoCivil.SelectedValue
            frmCivil.ShowDialog(Me)
            dtCivil = sqlExecute("SELECT cod_civil,nombre FROM civil")
            cmbEdoCivil.DataSource = dtCivil
            If Not c = Nothing Then cmbEdoCivil.SelectedValue = c
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            frmCivil.Focus()
        End Try
    End Sub

    Private Sub GroupPanel6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnCapturar_Click(sender As Object, e As EventArgs)

        txtPagar.Enabled = True
        txtTomar.Enabled = True
        txtFechaDe.Enabled = True
        cmbPeriodos.Enabled = True

        btnCapturar.Enabled = False
        btnAplicarVac.Enabled = True
        btnCancelarVac.Enabled = True
        txtPagar.Focus()

    End Sub

    Private Sub btnAplicarVac_Click(sender As Object, e As EventArgs)
        Dim _fecha As Date
        Dim _fecha_fin As Date
        Dim _fecha_ini As Date
        Dim rl As String = txtReloj.Text
        Dim _dinero As Double = 0
        Dim _tiempo As Double = 0
        Dim _ano As String = ""
        Dim _prima As Double = 0
        Dim _diasDinero As Double = txtPagar.Value
        Dim _diasTiempo As Double = txtTomar.Value
        Dim ClaveVA As String
        Dim x As Integer
        Dim AusVac As String = ""
        Dim InsertaVac As Boolean = True
        Dim Respuesta As DialogResult
        Dim _aus_natural As String = ""
        Dim _devengadas As Double = txtDevengadas.Text
        Dim _semana_captura As Boolean = False

        Dim _dd As Double
        Dim _dt As Double
        Dim _d As Double
        Dim _t As Double
        Dim _sd As Double
        Dim _st As Double

        Dim AnoPerVac As String

        '**** VACACIONES PARA SALDOS Y PAGOS *****
        dtTemp = sqlExecute("SELECT TOP 1 ano,prima,saldo_dinero, saldo_tiempo FROM saldos_vacaciones WHERE reloj = '" & rl & _
         "' ORDER BY fecha_captura DESC,fecha_fin DESC")
        If dtTemp.Rows.Count > 0 Then
            Try : _dinero = dtTemp.Rows.Item(0).Item("saldo_dinero") : Catch ex As Exception : _dinero = 0 : End Try
            Try : _tiempo = dtTemp.Rows.Item(0).Item("saldo_tiempo") : Catch ex As Exception : _tiempo = 0 : End Try
            Try : _ano = dtTemp.Rows.Item(0).Item("ano") : Catch ex As Exception : _ano = Date.Now.Year.ToString : End Try
            Try : _prima = dtTemp.Rows.Item(0).Item("prima") : Catch ex As Exception : _prima = 25 : End Try
        End If

        Try
            If _diasDinero > _devengadas + _dinero Or _diasTiempo > _devengadas + _tiempo Then
                MessageBox.Show("Los días a tomar o a pagar no pueden ser mayores que los disponibles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                _fecha_ini = txtFechaDe.Value
                _fecha_fin = DateAdd(DateInterval.Day, CDbl(txtTomar.Value), _fecha_ini)

                '***** PROCESO PARA APLICAR VACACIONES EN AUSENTISMO *******
                dtTemp = sqlExecute("SELECT tipo_aus FROM tipo_ausentismo WHERE tipo_naturaleza = 'V'", "TA")
                If dtTemp.Rows.Count = 0 Then
                    AusVac = "VAC"
                Else
                    AusVac = dtTemp.Rows(0).Item("tipo_aus")
                End If

                'Revisar ausentismo default y tipo de pago para vacaciones
                dtTemp = sqlExecute("SELECT ausentismo,pago_vacaciones_semana_captura FROM parametros")
                If dtTemp.Rows.Count = 0 Then
                    _aus_natural = "FI"
                Else
                    _aus_natural = IIf(IsDBNull(dtTemp.Rows(0).Item("ausentismo")), "FI", dtTemp.Rows(0).Item("ausentismo")).ToString.Trim
                    _semana_captura = IIf(IsDBNull(dtTemp.Rows(0).Item("pago_vacaciones_semana_captura")), False, dtTemp.Rows(0).Item("pago_vacaciones_semana_captura"))
                End If

                _fecha = _fecha_ini
                x = 1
                Do Until x > _diasTiempo
                    If Not (Festivo(_fecha, rl) Or DiaDescanso(_fecha, rl)) Then
                        dtTemp = sqlExecute("SELECT TIPO_NATURALEZA,ausentismo.TIPO_AUS,NOMBRE FROM AUSENTISMO LEFT JOIN TIPO_AUSENTISMO ON ausentismo.TIPO_AUS = tipo_ausentismo.TIPO_AUS WHERE RELOJ = '" & rl & "' AND fecha = '" & FechaSQL(_fecha) & "'", "TA")
                        If dtTemp.Rows.Count > 0 Then
                            If dtTemp.Rows(0).Item("tipo_aus") = _aus_natural Then
                                sqlExecute("DELETE FROM ausentismo  WHERE RELOJ = '" & rl & "' AND fecha = '" & FechaSQL(_fecha) & "'", "TA")
                                InsertaVac = True
                            Else
                                Respuesta = MessageBox.Show("Existe ausentismo registrado para el día " & FechaMediaLetra(_fecha) & " (" & dtTemp.Rows(0).Item("nombre") & "). ¿Desea sobrescribirlo?", "Ausentismo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
                                If Respuesta = Windows.Forms.DialogResult.Yes Then
                                    sqlExecute("DELETE FROM ausentismo  WHERE RELOJ = '" & rl & "' AND fecha = '" & FechaSQL(_fecha) & "'", "TA")
                                    InsertaVac = True
                                ElseIf Respuesta = Windows.Forms.DialogResult.No Then
                                    InsertaVac = False
                                Else
                                    Exit Sub
                                End If
                            End If
                        End If
                        If InsertaVac Then
                            sqlExecute("INSERT INTO ausentismo (COD_COMP,RELOJ,FECHA,TIPO_AUS,PERIODO) VALUES ('" & _
                                       cmbCia.SelectedValue & "','" & _
                                       rl & "','" & _
                                       FechaSQL(_fecha) & "','" & _
                                       AusVac & "','" & _
                                       ObtenerPeriodo(_fecha) & "')", "TA")
                            _fecha_fin = _fecha
                            x = x + 1
                        End If
                    End If
                    _fecha = _fecha.AddDays(1)
                    InsertaVac = True
                Loop

                '****************************************************************

                '**** VACACIONES PARA SALDOS Y PAGOS *****
                dtTemp = sqlExecute("SELECT TOP 1 ano,prima,saldo_dinero, saldo_tiempo FROM saldos_vacaciones WHERE reloj = '" & rl & _
                 "' ORDER BY fecha_captura DESC,fecha_fin DESC")
                If dtTemp.Rows.Count > 0 Then
                    Try : _dinero = dtTemp.Rows.Item(0).Item("saldo_dinero") : Catch ex As Exception : _dinero = 0 : End Try
                    Try : _tiempo = dtTemp.Rows.Item(0).Item("saldo_tiempo") : Catch ex As Exception : _tiempo = 0 : End Try
                    Try : _ano = dtTemp.Rows.Item(0).Item("ano") : Catch ex As Exception : _ano = Date.Now.Year.ToString : End Try
                    Try : _prima = dtTemp.Rows.Item(0).Item("prima") : Catch ex As Exception : _prima = 25 : End Try
                End If



                dtTemp = sqlExecute("SELECT misce_clave FROM conceptos WHERE concepto = 'DIASVA'", "Nomina")
                If dtTemp.Rows.Count > 0 Then
                    ClaveVA = dtTemp.Rows.Item(0).Item("misce_clave")
                Else
                    ClaveVA = ""
                End If


                'Si las vacaciones se pagan de acuerdo a la semana en que se captura
                If _semana_captura Then
                    _dinero = _dinero - _diasDinero
                    _tiempo = _tiempo - _diasTiempo

                    sqlExecute("INSERT INTO saldos_vacaciones (reloj,ano,prima,saldo_dinero,saldo_tiempo,dinero,tiempo,comentario," & _
                               "fecha_ini,fecha_fin,fecha_captura) VALUES ('" & _
                               rl & "','" & _
                               _ano & "'," & _
                               _prima & "," & _
                               _dinero & "," & _
                               _tiempo & "," & _
                               _diasDinero & "," & _
                               _diasTiempo & _
                               ",'VACACIONES','" & _
                               FechaSQL(_fecha_ini) & "','" & _
                               FechaSQL(_fecha_fin) & "','" & _
                               FechaHoraSQL(Now) & "')")

                    '**** PROCESO PARA APLICAR VACACIONES EN MISCELANEOS DE NOMINA ******* 

                    sqlExecute("INSERT INTO ajustes_nom (reloj,ano,periodo,per_ded,clave,monto,comentario,concepto,usuario,fecha) VALUES ('" & _
                               rl & "','" & _
                               ObtenerAnoPeriodo(Now).Substring(0, 4) & "','" & _
                               ObtenerAnoPeriodo(Now).Substring(4, 2) & "','P','" & _
                               ClaveVA & "'," & _
                               _diasDinero & _
                               ",'Días de vacaciones capturados desde MAESTRO','DIASVA','" & Usuario & "', GETDATE())", "Nomina")
                    '*********************************************************************
                Else
                    'Si las vacaciones se pagan de acuerdo a la fecha en que suceden
                    _fecha = _fecha_ini
                    x = 0
                    AnoPerVac = ObtenerAnoPeriodo(_fecha)


                    _dd = 0   'Días a pagar
                    _dt = 0   'Días a disfrutar
                    _sd = _dinero       'Saldo para pago
                    _st = _tiempo       'Saldo para disfrutar

                    _d = 0
                    _t = 0
                    Do Until x >= _diasDinero And x >= _diasTiempo
                        If Not (Festivo(_fecha, rl) Or DiaDescanso(_fecha, rl)) Then

                            If ObtenerAnoPeriodo(_fecha) <> AnoPerVac Then
                                _sd = _sd - _d
                                _st = _st - _t

                                sqlExecute("INSERT INTO saldos_vacaciones (reloj,ano,prima,saldo_dinero,saldo_tiempo,dinero,tiempo,comentario," & _
                                   "fecha_ini,fecha_fin,fecha_captura) VALUES ('" & _
                                   rl & "','" & _
                                   _ano & "'," & _
                                   _prima & "," & _
                                   _sd & "," & _
                                   _st & "," & _
                                   _d & "," & _
                                   _t & _
                                   ",'VACACIONES','" & _
                                   FechaSQL(_fecha_ini) & "','" & _
                                   FechaSQL(_fecha_fin) & "','" & _
                                   FechaHoraSQL(Now) & "')")

                                '**** PROCESO PARA APLICAR VACACIONES EN MISCELANEOS DE NOMINA ******* 

                                sqlExecute("INSERT INTO ajustes_nom (reloj,ano,periodo,per_ded,clave,monto,comentario,concepto,usuario,fecha) VALUES ('" & _
                                           rl & "','" & _
                                           ObtenerAnoPeriodo(_fecha_ini).Substring(0, 4) & "','" & _
                                           ObtenerAnoPeriodo(_fecha_ini).Substring(4, 2) & "','P','" & _
                                           ClaveVA & "'," & _
                                           _d & _
                                           ",'Días de vacaciones capturados desde MAESTRO','DIASVA','" & Usuario & "', GETDATE())", "Nomina")
                                '*********************************************************************
                                _d = 0
                                _t = 0
                                AnoPerVac = ObtenerAnoPeriodo(_fecha)
                                _fecha_ini = _fecha
                            End If


                            If _dd < _diasDinero Then
                                _d += 1
                                _dd += 1
                                _fecha_fin = _fecha
                            End If
                            If _dt < _diasTiempo Then
                                _t += 1
                                _dt += 1
                                _fecha_fin = _fecha
                            End If

                            x = x + 1

                        End If
                        _fecha = _fecha.AddDays(1)
                    Loop

                End If

                If _d > 0 And _t > 0 Then
                    _sd = _sd - _d
                    _st = _st - _t

                    sqlExecute("INSERT INTO saldos_vacaciones (reloj,ano,prima,saldo_dinero,saldo_tiempo,dinero,tiempo,comentario," & _
                       "fecha_ini,fecha_fin,fecha_captura) VALUES ('" & _
                       rl & "','" & _
                       _ano & "'," & _
                       _prima & "," & _
                       _sd & "," & _
                       _st & "," & _
                       _d & "," & _
                       _t & _
                       ",'VACACIONES','" & _
                       FechaSQL(_fecha_ini) & "','" & _
                       FechaSQL(_fecha_fin) & "','" & _
                       FechaHoraSQL(Now) & "')")

                    '**** PROCESO PARA APLICAR VACACIONES EN MISCELANEOS DE NOMINA ******* 

                    sqlExecute("INSERT INTO ajustes_nom (reloj,ano,periodo,per_ded,clave,monto,comentario,concepto,usuario,fecha) VALUES ('" & _
                               rl & "','" & _
                               ObtenerAnoPeriodo(_fecha_ini).Substring(0, 4) & "','" & _
                               ObtenerAnoPeriodo(_fecha_ini).Substring(4, 2) & "','P','" & _
                               ClaveVA & "'," & _
                               _d & _
                               ",'Días de vacaciones capturados desde MAESTRO','DIASVA','" & Usuario & "', GETDATE())", "Nomina")
                    '*********************************************************************
                End If
            End If
            RefrescaVacaciones(rl)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub btnCancelarVac_Click(sender As Object, e As EventArgs)
        txtPagar.Text = 0
        txtTomar.Text = 0
        btnCapturar.Enabled = Not EsBaja
        btnAplicarVac.Enabled = False
        btnCancelarVac.Enabled = False

        txtPagar.Enabled = False
        txtTomar.Enabled = False
        txtFechaDe.Enabled = False
        cmbPeriodos.Enabled = False
        cmbPeriodos.SelectedIndex = -1
    End Sub

    Private Sub cmbNivel_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbNivel.SelectedValueChanged
        ActualizaSueldo()
    End Sub

    Private Sub ActualizaSueldo()
        Try
            Dim dtSdo As New DataTable
            Dim sdo As Double
            Dim Factor As Double
            Dim Integrado As Double

            If Nuevo Or DarReingreso Then
                If cmbNivel.SelectedValue Is Nothing Then
                    sdo = 0
                Else
                    dtSdo = sqlExecute("SELECT sueldo FROM niveles WHERE cod_comp = '" & Compania & "' AND nivel = '" & cmbNivel.SelectedValue & "'")
                    If dtSdo.Rows.Count > 0 Then
                        sdo = IIf(IsDBNull(dtSdo.Rows.Item(0).Item("sueldo")), 0, dtSdo.Rows.Item(0).Item("sueldo"))
                    Else
                        sdo = 0
                    End If
                End If

                '---  2024-03-21 Como no hay niveles, dejar uno x default
                If txtSActual.Text <> "" Then
                    If Double.Parse(txtSActual.Text) > 0.0 Then
                        sdo = Double.Parse(txtSActual.Text)
                    Else
                        sdo = 374.89
                    End If
                End If

                'If sdo <> 0 Then
                txtSActual.Text = FormatCurrency(sdo)
                'End If

                ' txtSActual.Enabled = (sdo = 0)
                txtSActual.Enabled = (sdo >= 0) ' 2024-03-21 dejarlo habilitado siempre
                Factor = Format(FactorIntegracion(cmbCia.SelectedValue, cmbTipo.SelectedValue, DateDiff(DateInterval.Year, txtAlta.Value, UltimoDiaBimestre(Today))), "0.0000")
                Integrado = (txtSActual.Text * Factor) + txtProVar.Text

                txtFactorInt.Text = Factor
                txtIntegrado.Text = FormatCurrency(Integrado)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            txtSActual.Text = FormatCurrency(0)
            txtSActual.Enabled = True
            txtFactorInt.Text = Format(0, "0.0000")
            txtIntegrado.Text = FormatCurrency(0)
        End Try
    End Sub
    Private Sub cmbNivel_Validated(sender As Object, e As EventArgs) Handles cmbNivel.Validated
        ActualizaSueldo()
    End Sub


    Private Sub txtCurp_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtCurp.Validating
        Dim RFC As String
        Try
            RFC = txtRFC.Text.Trim
            If RFC.Length >= 10 And txtCurp.Text.Trim.Length >= 10 Then
                If RFC.Substring(0, 10) <> txtCurp.Text.Substring(0, 10) Then
                    If MessageBox.Show("El RFC no concuerda con la CURP. ¿Desea continuar así?", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Cancel Then
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub txtRFC_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtRFC.Validating
        Dim RFC As String
        Try
            RFC = txtRFC.Text.Trim
            If RFC.Length >= 10 And txtCurp.Text.Trim.Length >= 10 Then
                If RFC.Substring(0, 10) <> txtCurp.Text.Substring(0, 10) Then
                    If MessageBox.Show("El RFC no concuerda con la CURP. ¿Desea continuar así?", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Cancel Then
                        e.Cancel = True
                    End If
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtReloj_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtReloj.Validating
        Try
            Dim dtReloj As New DataTable
            If Nuevo And txtReloj.Enabled = True Then
                txtReloj.Text = txtReloj.Text.PadLeft(LongReloj, "0")
                'Si el número de reloj está en blanco, salir
                If Val(txtReloj.Text) = 0 Then
                    'Si la validación se mandó llamar por presionar el botón de cancelar, no avisar, pues se está cancelando edición
                    If Me.ActiveControl.Name = "btnEditar" Then
                        e.Cancel = False
                    Else
                        'Si salió del textbox por cualquier otro motivo, avisar del reloj en blanco
                        e.Cancel = MessageBox.Show("El número de reloj no puede quedar en blanco." & vbCrLf & "Favor de verificar.", "Reloj en blanco", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop) = Windows.Forms.DialogResult.Retry
                    End If
                End If

                'Si se canceló, salir del procedimiento
                If Not e.Cancel Then Exit Sub

                'Si el gafete está en blanco, igualarlo al reloj
                If txtGafete.Text = "" Then
                    txtGafete.Text = txtReloj.Text
                End If

                'Revisar que no exista el número de reloj
                dtReloj = sqlExecute("SELECT cod_comp from personalvw WHERE reloj = '" & txtReloj.Text & "'")
                If dtReloj.Rows.Count > 0 Then
                    MessageBox.Show("El número de reloj " & txtReloj.Text & " está asignado a la compañía " & dtReloj.Rows(0).Item("cod_comp") & "." & vbCrLf & "Favor de verificar.", "Reloj duplicado", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    e.Cancel = True
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtIMSSdv_MouseDown(sender As Object, e As MouseEventArgs) Handles txtIMSSdv.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            txtIMSSdv.Text = DigitoVerificador(txtIMSS.Text)
        End If
    End Sub


    Private Sub txtIMSSdv_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtIMSSdv.Validating

        Dim datos_completos As Boolean = False
        Try
            datos_completos = sqlExecute("select datos_completos from cias where cod_comp = '" & cmbCia.SelectedValue & "'").Rows(0)("datos_completos")
        Catch ex As Exception
            datos_completos = False
        End Try

        If datos_completos Then
            Dim dv As String
            dv = DigitoVerificador(txtIMSS.Text)
            If txtIMSSdv.Text <> dv Then
                If MessageBox.Show("El número de afiliación y/o el dígito verificador son incorrectos." & vbCrLf & "Al registro " & txtIMSS.Text & " le corresponde el dígito verificador " & dv & ".", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Retry Then
                    e.Cancel = True
                End If
            End If
        End If
    End Sub

    Private Sub txtAlta_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtAlta.Validating
        ValidaIntegrado()
    End Sub
    Private Sub ValidaIntegrado()
        Try
            Dim Factor As Decimal
            Dim Integrado As Decimal
            If Nuevo Or Editar Then
                Factor = Format(FactorIntegracion(cmbCia.SelectedValue, cmbTipo.SelectedValue, DateDiff(DateInterval.Year, txtAlta.Value, UltimoDiaBimestre(Today))), "0.0000")
                Integrado = (txtSActual.Text * Factor) + txtProVar.Text

                txtFactorInt.Text = Factor
                txtIntegrado.Text = FormatCurrency(Integrado)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub tbInfo_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles tbInfo.SelectedTabChanged
        Try
            tbVac = True
            tbVac = tbInfo.SelectedTab.Name = "tabVacaciones"

            btnCapturar.Visible = tbVac And PermisoEdicion
            btnAplicarVac.Visible = tbVac And PermisoEdicion
            btnCancelarVac.Visible = tbVac And PermisoEdicion
            btnBorrarVac.Visible = tbVac And PermisoEdicion

            tbGral = tbInfo.SelectedTab.Name = "tabGeneral"
            btnNuevo.Visible = Not tbVac And ((tbGral And PermisoEdicion) Or (Not tbGral And (Editar Or Nuevo)))
            btnEditar.Visible = Not tbVac And PermisoEdicion
            btnBorrar.Visible = tbGral And PermisoEdicion
            ' btnReporte.Visible = Not tbVac And PermisoEdicion
            btnReporte.Visible = False

            pnlVacaciones.Enabled = tbVac
            If tbVac Then
                Me.AcceptButton = btnAplicarVac
                Me.CancelButton = btnCancelarVac
            Else
                Me.AcceptButton = Nothing
                Me.CancelButton = Nothing
            End If

            '17/dic/2020        Mostrar siempre los controles del perfil		linea:4540
            revisarPerfiles(Perfil, Me, Editar, cmbCia.SelectedValue, txtReloj.Text.ToString.Trim)

            '-- Si se selecciona el tabVacaciones deshabilitar el boton editar      Abril 8
            '== COMENTADO PARA DESHABILITAR EL BOTON DE EDITAR                  27SEP2021
            'If Perfil.Contains("SUPERV") Then
            '    If tbInfo.SelectedTab.Name = "tabVacaciones" Then
            '        btnEditar.Visible = False
            '        btnEditar.Enabled = False
            '    Else
            '        btnEditar.Visible = True
            '        btnEditar.Enabled = True
            '    End If
            'End If

            '== Visualizar el botón de reportes             19nov2021
            If Perfil.Contains("SUPERV") Or Perfil.Contains("SERV_MED") Or Perfil.Contains("GERENTE_MEDICO") Then
                If tbInfo.SelectedTab.Name = "tabReportes" Then
                    ' btnReporte.Visible = True
                    ' btnReporte.Enabled = True
                    btnReporte.Visible = False
                Else
                    btnReporte.Visible = False
                    btnReporte.Enabled = False
                End If
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cmbColonia_SystemColorsChanged(sender As Object, e As EventArgs) Handles cmbColonia.SystemColorsChanged

    End Sub

    Private Sub cmbColonia_TextChanged(sender As Object, e As EventArgs) Handles cmbColonia.TextChanged

    End Sub

    Private Sub cmbCd_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCd.SelectedIndexChanged
        Try
            Dim cd As String
            Dim ix As Integer
            cd = IIf(IsDBNull(cmbCd.SelectedValue), "", cmbCd.SelectedValue)
            Dim dtEdo As New DataTable
            dtEdo = sqlExecute("SELECT estados.nombre FROM estados LEFT JOIN ciudad ON estados.cod_edo = ciudad.cod_edo WHERE ciudad.cod_cd = '" & cd & "'")
            If dtEdo.Rows.Count > 0 Then
                txtEstado.Text = IIf(IsDBNull(dtEdo.Rows.Item(ix).Item("nombre")), "", dtEdo.Rows.Item(ix).Item("nombre"))
            Else
                txtEstado.Text = "NO CAPTURADO"
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtNombre_LostFocus(sender As Object, e As EventArgs) Handles txtNombre.LostFocus
        txtNombre.Text = txtNombre.Text.ToUpper.Trim
    End Sub


    Private Sub txtApaterno_LostFocus(sender As Object, e As EventArgs) Handles txtApaterno.LostFocus
        txtApaterno.Text = txtApaterno.Text.ToUpper
    End Sub


    Private Sub txtAmaterno_LostFocus(sender As Object, e As EventArgs) Handles txtAmaterno.LostFocus
        txtAmaterno.Text = txtAmaterno.Text.ToUpper
        If tbInfo.SelectedTabIndex = 0 Then
            cmbCia.Focus()
        End If
    End Sub


    Private Sub cmbTipo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipo.SelectedValueChanged
        Dim Factor As Decimal
        Dim Integrado As Decimal
        Try
            If cmbTipo.SelectedValue Is Nothing Then Exit Sub
            If cmbCia.SelectedValue Is Nothing Then Exit Sub

            'MCR 4/nov/2015
            'Cambiar el datasource siempre que se cambie, para que pueda tomar el valor correcto al mostrar información
            dtNivel = sqlExecute("SELECT * FROM niveles WHERE cod_comp = '" & cmbCia.SelectedValue & "' AND cod_tipo = '" & cmbTipo.SelectedValue & "'")
            cmbNivel.DataSource = dtNivel

            If Nuevo Or DarReingreso Then
                'MCR 27/OCT/2015
                'No cambiar los factores e integrado, a menos que sea alta o reingreso
                cmbNivel.SelectedIndex = 0
                Factor = Format(FactorIntegracion(cmbCia.SelectedValue, IIf(cmbTipo.SelectedValue Is Nothing, "", cmbTipo.SelectedValue), _
                                                  DateDiff(DateInterval.Year, txtAlta.Value, UltimoDiaBimestre(Today))), "0.0000")
                Integrado = (txtSActual.Text * Factor) + txtProVar.Text

                txtFactorInt.Text = Factor
                txtIntegrado.Text = FormatCurrency(Integrado)

                '   HabilitaReloj() ' 2024-04-11: Se deshabilita ya que solo hace la consulta en tipo_emp de minimos y maximos de rangos, que no se usan en la mayoria de las empresas

            End If

            'If Nuevo Then
            '    Dim dtReloj As DataTable = New DataTable
            '    If (cmbCia.SelectedValue = "090") Then
            '        If cmbTipo.SelectedValue = "A" Then
            '            dtReloj = sqlExecute("select top 1 reloj from personalvw where reloj > '020000' and reloj < '030000' and cod_comp = '" & cmbCia.SelectedValue & "' order by reloj desc")
            '        Else
            '            dtReloj = sqlExecute("select top 1 reloj from personalvw where reloj > '030000' and reloj < '070000' and cod_comp = '" & cmbCia.SelectedValue & "' order by reloj desc")
            '        End If

            '        If dtReloj.Rows.Count Then
            '            txtReloj.Text = (Integer.Parse(dtReloj.Rows(0)("reloj")) + 1).ToString.PadLeft(6, "0")
            '        End If

            '        txtReloj.Enabled = False
            '    Else
            '        txtReloj.Enabled = Nuevo
            '    End If


            'End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub HabilitaReloj()
        Try
            'MCR 27/OCT/2015
            'Buscar rango de # de reloj por compañía y # de empleado
            Dim dtPredeterminados As DataTable = sqlExecute("select minimo_rango,maximo_rango from tipo_emp where cod_comp = '" & _
                                                            cmbCia.SelectedValue & "'" & " AND cod_tipo ='" & cmbTipo.SelectedValue & "'")
            If dtPredeterminados.Rows.Count = 0 Then
                txtReloj.Enabled = True
                txtReloj.BackColor = Color.White
            Else
                If IsDBNull(dtPredeterminados.Rows(0)("minimo_rango")) Or IsDBNull(dtPredeterminados.Rows(0)("maximo_rango")) Then
                    txtReloj.Enabled = True
                    txtReloj.BackColor = Color.White
                Else
                    'No permitir modificar número de reloj cuando hay parámetros de rango
                    txtReloj.Enabled = False
                    txtReloj.Text = ""
                    txtReloj.BackColor = SystemColors.ControlDark
                End If
            End If
            '*******
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkCampo_CheckedChanged(sender As Object, e As EventArgs) Handles chkCampo.CheckedChanged
        cmbHCCampo.Enabled = chkCampo.Checked
        cmbHCCampo.Focus()
    End Sub

    Private Sub chkUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chkUsuario.CheckedChanged
        cmbHCUsuario.Enabled = chkUsuario.Checked
        cmbHCUsuario.Focus()
    End Sub

    Private Sub chkMovimiento_CheckedChanged(sender As Object, e As EventArgs) Handles chkMovimiento.CheckedChanged
        cmbHCTipoMovimiento.Enabled = chkMovimiento.Checked
        cmbHCTipoMovimiento.Focus()
    End Sub

    Private Sub chkFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chkFecha.CheckedChanged
        dtHCFechaIni.Enabled = chkFecha.Checked
        dtHCFechaFin.Enabled = chkFecha.Checked
        dtHCFechaIni.Focus()
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Try
            Dim Filtro As String = ""

            If chkCampo.Checked Then
                Filtro = " UPPER(campo) = '" & cmbHCCampo.SelectedValue.ToString.ToUpper.Trim & "'"
            End If

            If chkUsuario.Checked Then
                If Not IsNothing(cmbHCUsuario.SelectedValue) Then
                    Filtro = Filtro & IIf(Filtro.Length > 0, " AND ", "")
                    Filtro = Filtro & " UPPER(usuario) = '" & cmbHCUsuario.SelectedValue.ToString.ToUpper.Trim & "'"
                End If
            End If

            If chkMovimiento.Checked Then
                If Not IsNothing(cmbHCTipoMovimiento.SelectedValue) Then
                    Filtro = Filtro & IIf(Filtro.Length > 0, " AND ", "")
                    Filtro = Filtro & " UPPER(tipo_movimiento) = '" & cmbHCTipoMovimiento.SelectedValue.ToString.ToUpper.Trim & "'"
                End If
            End If

            If chkFecha.Checked Then
                Filtro = Filtro & IIf(Filtro.Length > 0, " AND ", "")
                Filtro = Filtro & " CAST(fecha AS DATE) BETWEEN '" & FechaSQL(dtHCFechaIni.Value) & "' AND '" & FechaSQL(dtHCFechaIni.Value) & "'"
            End If

            RefrescaHistorialCambios(txtReloj.Text, Filtro)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnLimpiarFiltros_Click(sender As Object, e As EventArgs) Handles btnLimpiarFiltros.Click
        chkCampo.Checked = False
        chkFecha.Checked = False
        chkUsuario.Checked = False
        chkMovimiento.Checked = False
        RefrescaHistorialCambios(txtReloj.Text)
    End Sub

    Private Sub dgReportes_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgReportes.CellDoubleClick
        GenerarReporte()
    End Sub

    Private Sub btnGenerar_Click(sender As Object, e As EventArgs)
        GenerarReporte()
    End Sub
    Private Sub GenerarReporte()
        Dim dtReporte As New DataTable
        Dim dtInfo As New DataTable
        Dim dtDatosPersonal As New DataTable
        Dim r As Integer
        Dim i As Integer
        Dim Nombre As String
        Dim Tipo As String
        Dim ArchivoFoto As String
        Try

            '---------------------------------------Modificacion para generar reporte de beneficiarios en su misma pantalla    -   Ernesto     -   23/dic/2020
            'If tabBeneficiarios.IsSelected Then
            '    Dim indice As Integer
            '    Dim celda As String
            '    Tipo = "No_existe"

            '    'Agrega los valores necesarios por default del reporte "Beneficiarios"
            '    Nombre = "Beneficiarios"
            '    'Busca el indice del reporte en la tabla del reporteador individual
            '    For Each vFila As DataGridViewRow In dgReportes.Rows
            '        celda = RTrim(vFila.Cells(0).Value.ToString)
            '        If celda = Nombre Then
            '            r = indice
            '            Tipo = vFila.Cells(1).Value.ToString
            '        End If
            '        indice += 1
            '    Next
            '    'En caso de que no encuestre el reporte, salirse de la funcion y mandar aviso
            '    If Tipo = "No_existe" Then
            '        MessageBox.Show("El reporte de Beneficiarios no se encuentra, favor de contactarse con el administrador")
            '        Exit Sub
            '    End If
            'Else
            '    'Significa que solo se esta utilizando el reporteador individual en su respectiva tab
            '    r = dgReportes.CurrentCell.RowIndex
            '    If r < 0 Then Exit Sub
            '    Nombre = dgReportes.Item("colNombre", r).Value.ToString.Trim
            '    Tipo = dgReportes.Item("tipo", r).Value
            'End If
            '---------------------------------------Fin modificacion

            r = dgReportes.CurrentCell.RowIndex
            If r < 0 Then Exit Sub
            Nombre = dgReportes.Item("colNombre", r).Value.ToString.Trim
            Tipo = dgReportes.Item("tipo", r).Value

            sqlExecute("UPDATE reportes SET veces_acceso = veces_acceso + 1, fecha = GETDATE()   WHERE nombre = '" & Nombre & "'")

            dtTemporal = sqlExecute("SELECT COUNT(nombre) AS cuantos FROM reportes_recientes WHERE usuario = '" & Usuario & "'")
            If dtTemporal.Rows.Item(0).Item("cuantos") = 10 Then
                sqlExecute("DELETE FROM reportes_recientes WHERE fecha = (SELECT MIN(fecha) FROM reportes_recientes WHERE usuario = '" & Usuario & "') AND usuario = '" & Usuario & "'")
            End If

            dtTemporal = sqlExecute("SELECT nombre FROM reportes_recientes WHERE usuario = '" & Usuario & "' AND nombre = '" & Nombre & "'")
            If dtTemporal.Rows.Count > 0 Then
                sqlExecute("UPDATE reportes_recientes SET fecha = GETDATE() WHERE usuario = '" & Usuario & "' AND nombre = '" & Nombre & "'")
            Else
                sqlExecute("INSERT INTO reportes_recientes (usuario,fecha,nombre) VALUES ('" & Usuario & "',GETDATE(),'" & Nombre & "')")
            End If

            '**** CARGAR PERSONALVW PARA ESTE EMPLEADO
            dtDatosPersonal = sqlExecute("EXEC MaestroPersonal @Nivel = '" & NivelConsulta & "', @Reloj = '" & txtReloj.Text & "'")
            dtInfo = dtDatosPersonal.Clone
            Dim dRow As DataRow
            'dtInfo.Columns(0).ColumnName = dtInfo.Columns(0).ColumnName.ToLower
            dRow = dtDatosPersonal.Rows(0)
            frmTrabajando.lblAvance.Text = "Reloj " & dRow.Item("reloj")
            Application.DoEvents()

            For Each dRow In dtDatosPersonal.Select(FiltroXUsuario)
                dRow.Item("sactual") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("sactual"), 0)
                dRow.Item("integrado") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("integrado"), 0)
                dRow.Item("pro_var") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("pro_var"), 0)
                dRow.Item("factor_int") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("factor_int"), 0)
                dRow.Item("sal_ant") = IIf(IIf(IsDBNull(dRow.Item("nivel_seguridad")), 0, dRow.Item("nivel_seguridad")) <= NivelSueldos, dRow.Item("sal_ant"), 0)

                dtInfo.ImportRow(dRow)
            Next

            'Agregar fotografías
            ArchivoFoto = dRow("foto").ToString.Trim
            If Dir(ArchivoFoto) = "" Then
                ArchivoFoto = ArchivoFoto.Replace(dRow("Reloj") & ".jpg", "nofoto.png")
            End If
            'ArchivoFoto = "FOTOS\nofoto.png"
            dRow("foto") = ArchivoFoto
            '**************************************************************
            dtFiltroPersonal = dtInfo.Copy

            If Tipo = "U" Then
                dtReporte = sqlExecute("SELECT * FROM reportes WHERE nombre = '" & Nombre & "'")
                If dtReporte.Rows.Count < 1 Then Exit Sub
                frmVistaPrevia.ReporteDinamico(dtReporte.Rows(0), dtInfo, Nombre)
            ElseIf Nombre.ToUpper = "CARTAS GENERALES" Then
                frmCartasGenerales.ShowDialog()
            ElseIf Nombre.ToUpper = "CONTRATOS" Then
                Dim ContratosNew As frmContratos = New frmContratos("Reporteador")
                ContratosNew.ShowDialog()
            ElseIf Tipo = "Z" Then
                Dim frm As New frmCondensados
                frm.condensado = Nombre.Trim
                frm.dtInfo = dtInfo
                frm.ShowDialog()
            Else
                ReporteadorFuente = "Personal"

                frmVistaPrevia.vwrReportes.LocalReport.EnableExternalImages = True

                frmVistaPrevia.LlamarReporte(Nombre, dtInfo)
                frmVistaPrevia.ShowDialog()
            End If

            CargarReportes()
            For i = 0 To dgReportes.Rows.Count - 1
                If dgReportes.Item("colNombre", i).Value = NombreReporte Then
                    r = i
                    Exit For
                End If
            Next
            dgReportes.CurrentCell = dgReportes.Item(1, r)


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    '---Modif. Ernesto.     22/dic/2020
    Private Sub btnReporte_Click(sender As Object, e As EventArgs) Handles btnReporte.Click
        If (tbInfo.SelectedTab.Name = "tabReportes" And dgReportes.SelectedCells.Count > 0) Or (tbInfo.SelectedTab.Name = "tabExpediente" And tabBeneficiarios.IsSelected) Then
            GenerarReporte()
        End If
    End Sub

    Private Sub refrescar_cia()
        'If Cargando Then Exit Sub
        Try
            If cmbCia.SelectedValue Is Nothing Then Exit Sub
            'MCR 18/NOV/2015
            dtTemp = sqlExecute("SELECT ISNULL(editable,1) AS editable FROM cias WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            CiaEditable = dtTemp.Rows(0)("editable")

            dtDeptos = sqlExecute("SELECT * from deptos WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbDepto.DataSource = dtDeptos

            dtSuper = sqlExecute("SELECT * FROM super WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbSuper.DataSource = dtSuper

            '== CARGAR LOS LIDERES              10Dic2021           Ernesto
            dtLider = sqlExecute("SELECT * FROM lideres WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbLider.DataSource = dtLider

            ' dtClerk = sqlExecute("SELECT * FROM clerks")
            'cmbClerk.DataSource = dtClerk

            '  dtSindicalizado = sqlExecute("SELECT * FROM sindicalizado")
            '  cmbSindicalizado.DataSource = dtSindicalizado

            dtTipoPeriodo = sqlExecute("SELECT * FROM tipo_periodo")
            cmbTipoPeriodo.DataSource = dtTipoPeriodo

            dtTurnos = sqlExecute("SELECT * FROM turnos WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbTurno.DataSource = dtTurnos

            dtTipos = sqlExecute("SELECT * FROM tipo_emp WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbTipo.DataSource = dtTipos

            dtPuestos = sqlExecute("SELECT cod_puesto,nombre,(CASE activo WHEN 1 THEN '   *' ELSE '' END) as activo, rtrim(isnull(cod_sf, '')) as cod_sf  FROM puestos WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbPuesto.DataSource = dtPuestos

            dtPlantas = sqlExecute("SELECT cod_planta,nombre FROM plantas WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbPlanta.DataSource = dtPlantas

            dtAreas = sqlExecute("SELECT cod_area,nombre FROM areas WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbArea.DataSource = dtAreas

            dtRegFiscSAT = sqlExecute("select COD_REG_SAT,DESCRIPCION from regimenfisc_sat where cod_comp='" & cmbCia.SelectedValue & "'", "PERSONAL")
            cmbRegFiscSAT.DataSource = dtRegFiscSAT

            dtClases = sqlExecute("SELECT cod_clase,nombre FROM clase WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbClase.DataSource = dtClases

            dtHorarios = sqlExecute("SELECT rtrim(cod_hora) as cod_hora, nombre FROM horarios WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
            cmbHorario.DataSource = dtHorarios

            dtCCostos = sqlExecute("SELECT centro_costos,nombre FROM c_costos where cod_comp='" & cmbCia.SelectedValue.ToString.Trim & "'")
            cmbCCostos.DataSource = dtCCostos

            Dim Factor As Decimal
            Dim Integrado As Decimal
            If Nuevo Or Editar Then
                Factor = Format(FactorIntegracion(cmbCia.SelectedValue, cmbTipo.SelectedValue, DateDiff(DateInterval.Year, txtAlta.Value, UltimoDiaBimestre(Today))), "0.0000")
                Integrado = (txtSActual.Text * Factor) + txtProVar.Text

                txtFactorInt.Text = Factor
                txtIntegrado.Text = FormatCurrency(Integrado)
                If Not cmbTipo.SelectedValue Is Nothing Then
                    InfoEnBlanco(False)
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub cmbCia_SelectedValueChanged1(sender As Object, e As EventArgs) Handles cmbCia.SelectedValueChanged
        refrescar_cia()
    End Sub

    Private Sub txtSActual_Validated(sender As Object, e As EventArgs) Handles txtSActual.Validated
        Try
            txtSActual.Text = FormatCurrency(txtSActual.Text)
            ValidaIntegrado()
        Catch
            MessageBox.Show("El sueldo no es válido. Favor de verificar.", "Sueldo inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSActual.Focus()
        End Try
    End Sub

    Private Sub btnFoto_Click(sender As Object, e As EventArgs) Handles btnFoto.Click
        Dim Archivo As String = ""
        Dim Foto As String = ""
        Try
            'Dim q As String = "", dtParamFotos As New DataTable
            'q = "select path_foto from parametros"
            'dtParamFotos = sqlExecute(q, "PERSONAL")

            'If Not dtParamFotos.Columns.Contains("Error") And dtParamFotos.Rows.Count > 0 Then

            ' End If

  
            '---Proceso original
            'Dim x As String = picFoto.ImageLocation
            'Dim z As String = Dir(picFoto.ImageLocation)
            'Dim y As String = Dir(picFoto.ImageLocation).Length

            'If Not picFoto.ImageLocation Is Nothing Then
            '    If Dir(picFoto.ImageLocation).Length > 0 And Not picFoto.ImageLocation.ToUpper.Contains("NOFOTO") Then
            '        If MessageBox.Show("El empleado ya tiene una fotografía asignada. ¿Desea cambiarla?", "Buscar fotografía", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            '            Exit Sub
            '        End If
            '    End If
            'End If


            Dim ruta_foto_1 As String = PathFoto & txtReloj.Text.Trim & ".jpg"
            Dim ruta_foto_2 As String = PathFoto & txtReloj.Text.Trim & ".jpeg"
            '---Si realmente ya existe la foto, preguntar si se va a sobrrescribir
            If (System.IO.File.Exists(ruta_foto_1) Or System.IO.File.Exists(ruta_foto_2)) Then
                If MessageBox.Show("El empleado ya tiene una fotografía asignada. ¿Desea cambiarla?", "Buscar fotografía", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            End If




            dlgBuscarFoto.FileName = IIf(txtReloj.TextLength = 0, "", txtReloj.Text.Trim & ".jpg")
            dlgBuscarFoto.Filter = "JPEG files (*.jpg)|*.jpg| All Files|*.*"
            dlgBuscarFoto.CheckFileExists = True
            Dim lDialogResult As DialogResult = dlgBuscarFoto.ShowDialog()

            If lDialogResult = Windows.Forms.DialogResult.Cancel Then
                'Si seleccionan "CANCEL", salir del procedimiento
                Exit Sub
            Else
                Archivo = dlgBuscarFoto.FileName
                CambiaFoto = True
            End If
            picFoto.ImageLocation = Archivo

        Catch ex As Exception
            MessageBox.Show("Se detectó un error. La fotografía " & Archivo & " no pudo ser cargada." & vbCrLf & ex.Message, "Cargar fotografía", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    '--- 
    '---TEST
    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        Dim Cadena As String = ""
        Dim codigo As String
        Dim Borrar As Boolean = True
        codigo = txtReloj.Text

        Try
            'MCR 18/NOV/2015
            If Not CiaEditable Then
                MessageBox.Show("No puede borrarse un empleado que pertenezca a una compañía no editable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            '***********

            dtTemporal = sqlExecute("SELECT reloj FROM nomina WHERE reloj = '" & codigo & "'", "nomina")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("No puede borrarse un empleado que tenga datos en nómina.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            dtTemporal = sqlExecute("SELECT reloj FROM bitacora_personal WHERE reloj = '" & codigo & "' and mantenimiento = 1")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("No puede borrarse un empleado cuya información ya haya sido enviada en el mantenimiento.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            dtTemporal = sqlExecute("SELECT cod_super FROM super WHERE reloj = '" & codigo & "'")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("El empleado está asignado como supervisor; para poder eliminarlo, debe dejar de ser supervisor.", "Borrar", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            '==VALIDACION PARA LIDERES
            dtTemporal = sqlExecute("SELECT cod_lider FROM lideres WHERE reloj = '" & codigo & "'")
            If dtTemporal.Rows.Count > 0 Then
                MessageBox.Show("El empleado está asignado como lider; para poder eliminarlo, debe dejar de ser lider.", "Borrar", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Borrar = MessageBox.Show("Si elimina al empleado " & codigo & ", su información no podrá ser recuperada ¿Está seguro de continuar?", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes

            If Borrar Then
                sqlExecute("DELETE FROM detalle_auxiliares WHERE reloj = '" & codigo & "'")
                sqlExecute("DELETE FROM escolaridad WHERE reloj = '" & codigo & "'")
                sqlExecute("DELETE FROM familiares WHERE reloj = '" & codigo & "'")
                sqlExecute("DELETE from personal WHERE reloj = '" & codigo & "'")

                sqlExecute("DELETE FROM cursos_empleado WHERE reloj = '" & codigo & "'", "CAPACITACION")

                sqlExecute("DELETE FROM hrs_brt WHERE reloj = '" & codigo & "'", "TA")
                sqlExecute("DELETE FROM asist WHERE reloj = '" & codigo & "'", "TA")
                sqlExecute("DELETE FROM ausentismo WHERE reloj = '" & codigo & "'", "TA")
                sqlExecute("DELETE FROM nomsem WHERE reloj = '" & codigo & "'", "TA")

                'Utilizar tipo de movimiento =  'E' (Eliminar), porque 'B' es para bajas
                Cadena = "INSERT INTO bitacora_personal (reloj,usuario,fecha,tipo_movimiento) VALUES ('"
                Cadena = Cadena & Reloj & "','" & Usuario & "',GETDATE(),'E')"
                sqlExecute(Cadena)
                btnNext.PerformClick()

            End If

        Catch ex As Exception
            MessageBox.Show("El empleado no pudo ser borrado. Favor de verificar" & vbCrLf & "Error.-" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub cmbClase_Validated(sender As Object, e As EventArgs) Handles cmbClase.Validated
        Try
            Dim nvoNivel As Integer
            If Editar Or Nuevo Then
                dtTemp = sqlExecute("SELECT nivel_seguridad FROM clase WHERE cod_clase = '" & cmbClase.SelectedValue & "'")
                If dtTemp.Rows.Count > 0 Then
                    nvoNivel = dtTemp.Rows(0).Item("nivel_seguridad")
                Else
                    nvoNivel = 0
                End If

                gpSueldos.Visible = nvoNivel <= NivelSueldos

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtCuentaExp_TextChanged(sender As Object, e As EventArgs) Handles txtCuentaExp.TextChanged
        txtCuenta.Text = txtCuentaExp.Text
    End Sub

    Private Sub txtCuenta_TextChanged(sender As Object, e As EventArgs) Handles txtCuenta.TextChanged
        Try
            txtCuentaExp.Text = txtCuenta.Text

            If txtCuenta.Text.Length > 0 Then
                cmbCodPago.SelectedValue = "D"
            Else
                cmbCodPago.SelectedValue = "C"
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnAsignacion_Click(sender As Object, e As EventArgs) Handles btnAsignacion.Click
        Try
            Dim dtSiVale As New DataTable
            Dim Fecha As Date
            Dim GuardaArchivo As Boolean
            Dim strFileName As String = ""

            frmFecha.ShowDialog()
            If FechaInicial = Nothing Then Exit Sub
            Fecha = FechaInicial

            Dim oWrite As System.IO.StreamWriter
            Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog

            PreguntaArchivo.Filter = "Text file|*.txt"
            PreguntaArchivo.FileName = "Asignación tarjetas TITULARES " & Fecha.Year & Fecha.Month & Fecha.Day & ".txt"
            If PreguntaArchivo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                strFileName = PreguntaArchivo.FileName
            End If
            Try
                oWrite = File.CreateText(strFileName)
                GuardaArchivo = True
            Catch ex As Exception
                oWrite = Nothing
                GuardaArchivo = False
            End Try

            dtSiVale = ConsultaPersonalVW("SELECT personalvw.reloj,id_bonos,tarjeta_bonos," & _
                                        "RTRIM(personalvw.nombre) + ' '+RTRIM(apaterno) + ' ' + RTRIM(amaterno) as nombre from personalvw " & _
                                        "LEFT JOIN bitacora_personal on personalvw.reloj = bitacora_personal.reloj WHERE " & _
                                        "CAST(bitacora_personal.fecha AS date) = '" & FechaSQL(Fecha) & _
                                        "' AND campo = 'tarjeta_bonos' and (valoranterior IS NULL OR valorAnterior = '') " &
                                        "AND NOT (ValorNuevo IS NULL OR ValorNuevo = '')")

            Dim Texto As String = ""
            Dim Consecutivo As Integer = 1
            If GuardaArchivo And dtSiVale.Rows.Count > 0 Then
                Texto = "STK.ASGTIT.MIS" + Chr(13) + Chr(10)
                Texto = Texto & "05" & "10206060" & dtSiVale.Rows.Count.ToString.PadLeft(7, "0") & "48"

                For Each dRow As DataRow In dtSiVale.Rows
                    oWrite.WriteLine("06" & _
                                     "00001" & _
                                     Consecutivo.ToString.PadLeft(7, "0") & _
                                     dRow("id_bonos").ToString.PadLeft(10, "0").Substring(0, 10) & _
                                     dRow("nombre").ToString.PadRight(24).Substring(0, 24) & _
                                     Space(6) & _
                                     dRow("tarjeta_bonos").ToString.Trim.PadRight(16) & _
                                     Microsoft.VisualBasic.Strings.StrDup(16, "0"))
                    Consecutivo += 1
                Next
                oWrite.Close()
                MessageBox.Show("Archivo " & strFileName.Trim & " guardado exitosamente.", "Asignación tarjetas de bonos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf dtSiVale.Rows.Count = 0 Then
                MessageBox.Show("No se encontraron tarjetas pendientes de asignar para la fecha indicada. Favor de verificar.", "No tarjetas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Se detectó un error durante el proceso, y no pudo ser concluido. Si el problema persiste, contacte al administrador del sistema." & vbCrLf & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub btnAsignacionAdicionales_Click(sender As Object, e As EventArgs) Handles btnAsignacionAdicionales.Click
        Try
            Dim dtSiVale As New DataTable
            Dim Fecha As Date
            Dim GuardaArchivo As Boolean
            Dim strFileName As String = ""

            frmFecha.ShowDialog()
            If FechaInicial = Nothing Then Exit Sub
            Fecha = FechaInicial

            Dim oWrite As System.IO.StreamWriter
            Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog

            PreguntaArchivo.Filter = "Text file|*.txt"
            PreguntaArchivo.FileName = "Asignación tarjetas ADICIONALES " & Fecha.Year & Fecha.Month & Fecha.Day & ".txt"
            If PreguntaArchivo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                strFileName = PreguntaArchivo.FileName
            End If
            Try
                oWrite = File.CreateText(strFileName)
                GuardaArchivo = True
            Catch ex As Exception
                oWrite = Nothing
                GuardaArchivo = False
            End Try

            dtSiVale = ConsultaPersonalVW("SELECT personalvw.reloj,id_bonos,tarjeta_bonos,adicional_bonos," & _
                                        "RTRIM(personalvw.nombre) + ' '+RTRIM(apaterno) + ' ' + RTRIM(amaterno) as nombre from personalvw " & _
                                        "LEFT JOIN bitacora_personal on personalvw.reloj = bitacora_personal.reloj WHERE " & _
                                        "CAST(bitacora_personal.fecha AS date) = '" & FechaSQL(Fecha) & _
                                        "' AND campo = 'adicional_bonos' and (valoranterior IS NULL OR valorAnterior = '') " &
                                        "AND NOT (ValorNuevo IS NULL OR ValorNuevo = '')")

            Dim Texto As String = ""
            Dim Consecutivo As Integer = 1
            If GuardaArchivo And dtSiVale.Rows.Count > 0 Then
                Texto = "STK.ASGADI.MIS" + Chr(13) + Chr(10)
                Texto = Texto & "05" & "10206060" & dtSiVale.Rows.Count.ToString.PadLeft(7, "0") & "48"

                For Each dRow As DataRow In dtSiVale.Rows
                    oWrite.WriteLine("06" & _
                                     "00001" & _
                                     Consecutivo.ToString.PadLeft(7, "0") & _
                                     dRow("id_bonos").ToString.PadLeft(10, "0").Substring(0, 10) & _
                                     dRow("nombre").ToString.PadRight(24).Substring(0, 24) & _
                                     Space(6) & _
                                     dRow("tarjeta_bonos").ToString.Trim.PadRight(16) & _
                                     dRow("adicional_bonos").ToString.Trim.PadRight(16))
                    Consecutivo += 1
                Next
                oWrite.Close()
                MessageBox.Show("Archivo " & strFileName.Trim & " guardado exitosamente.", "Asignación tarjetas de bonos adicionales", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf dtSiVale.Rows.Count = 0 Then
                MessageBox.Show("No se encontraron tarjetas pendientes de asignar para la fecha indicada. Favor de verificar.", "No tarjetas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Se detectó un error durante el proceso, y no pudo ser concluido. Si el problema persiste, contacte al administrador del sistema." & vbCrLf & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


    End Sub

    Private Sub btnReasignacion_Click(sender As Object, e As EventArgs) Handles btnReasignacion.Click
        Try
            Dim dtSiVale As New DataTable
            Dim Fecha As Date
            Dim GuardaArchivo As Boolean
            Dim strFileName As String = ""

            frmFecha.ShowDialog()
            If FechaInicial = Nothing Then Exit Sub
            Fecha = FechaInicial

            Dim oWrite As System.IO.StreamWriter
            Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog

            PreguntaArchivo.Filter = "Text file|*.txt"
            PreguntaArchivo.FileName = "Reasignación tarjetas " & Fecha.Year & Fecha.Month & Fecha.Day & ".txt"
            If PreguntaArchivo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                strFileName = PreguntaArchivo.FileName
            End If
            Try
                oWrite = File.CreateText(strFileName)
                GuardaArchivo = True
            Catch ex As Exception
                oWrite = Nothing
                GuardaArchivo = False
            End Try

            dtSiVale = ConsultaPersonalVW("SELECT personalvw.reloj,id_bonos,tarjeta_bonos,adicional_bonos," & _
                                        "RTRIM(personalvw.nombre) + ' '+RTRIM(apaterno) + ' ' + RTRIM(amaterno) as nombre from personalvw " & _
                                        "LEFT JOIN bitacora_personal on personalvw.reloj = bitacora_personal.reloj WHERE " & _
                                        "CAST(bitacora_personal.fecha AS date) = '" & FechaSQL(Fecha) & "' AND " & _
                                        "((campo = 'tarjeta_bonos' and NOT (valoranterior IS NULL OR valorAnterior = '') AND " & _
                                        "NOT (ValorNuevo IS NULL OR ValorNuevo = '')) " & _
                                        "OR (campo = 'adicional_bonos' AND NOT (valoranterior IS NULL OR valorAnterior = '') AND " & _
                                        "NOT (ValorNuevo IS NULL OR ValorNuevo = '')))")

            Dim Texto As String = ""
            Dim Consecutivo As Integer = 1
            If GuardaArchivo And dtSiVale.Rows.Count > 0 Then
                Texto = "STK.REAALL.MIS" + Chr(13) + Chr(10)
                Texto = Texto & "05" & "10206060" & dtSiVale.Rows.Count.ToString.PadLeft(7, "0") & "48"

                For Each dRow As DataRow In dtSiVale.Rows
                    oWrite.WriteLine("06" & _
                                     Consecutivo.ToString.PadLeft(7, "0") & _
                                     dRow("tarjeta_bonos").ToString.Trim.PadRight(16) & _
                                     dRow("adicional_bonos").ToString.Trim.PadRight(16))
                    Consecutivo += 1
                Next
                oWrite.Close()
                MessageBox.Show("Archivo " & strFileName.Trim & " guardado exitosamente.", "Asignación tarjetas de bonos adicionales", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf dtSiVale.Rows.Count = 0 Then
                MessageBox.Show("No se encontraron tarjetas pendientes de asignar para la fecha indicada. Favor de verificar.", "No tarjetas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("Se detectó un error durante el proceso, y no pudo ser concluido. Si el problema persiste, contacte al administrador del sistema." & vbCrLf & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmMaestro_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        pnlCentrarControles.Left = (Me.Width - pnlCentrarControles.Size.Width) / 2
    End Sub

    Private Sub dgBeneficiarios_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgBeneficiarios.CellContentClick

    End Sub

    Private Sub dgBeneficiarios_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgBeneficiarios.CellEndEdit
        Dim id As Integer
        Dim dBen As DataRow
        Try
            id = IIf(IsDBNull(dgBeneficiarios.Item(0, e.RowIndex).Value), 0, dgBeneficiarios.Item(0, e.RowIndex).Value)
            dBen = dtBeneficiarios.Rows.Find(id)
            If Not dBen Is Nothing Then
                If dBen("movimiento") <> "A" Then
                    dBen("movimiento") = "C"
                End If
                dBen("nombre") = IIf(IsDBNull(dgBeneficiarios.Item("colBeneficiario", e.RowIndex).Value), "", dgBeneficiarios.Item("colBeneficiario", e.RowIndex).Value)
                dBen("parentesco") = IIf(IsDBNull(dgBeneficiarios.Item("colParentesco", e.RowIndex).Value), "", dgBeneficiarios.Item("colParentesco", e.RowIndex).Value)
                dBen("nacimiento") = IIf(IsDBNull(dgBeneficiarios.Item("colNacimiento", e.RowIndex).Value), Date.Now, dgBeneficiarios.Item("colNacimiento", e.RowIndex).Value)
                dBen("porcentaje") = IIf(IsDBNull(dgBeneficiarios.Item("colPorcentaje", e.RowIndex).Value), 0, dgBeneficiarios.Item("colPorcentaje", e.RowIndex).Value)

            End If
            ActualizaPorcentajes()
            ActualizaPorcentajeBanco()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub dgBeneficiarios_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgBeneficiarios.UserAddedRow
        Dim id As Integer
        Dim dBen As DataRow
        Try
            id = CInt(TimeOfDay.Hour.ToString.Trim & TimeOfDay.Minute.ToString.Trim & TimeOfDay.Second.ToString.Trim)
            dBen = dtBeneficiarios.NewRow
            dBen("idFld") = id
            dBen("movimiento") = "A"
            dBen("nombre") = IIf(IsDBNull(dgBeneficiarios.Item("colBeneficiario", e.Row.Index).Value), "", dgBeneficiarios.Item("colBeneficiario", e.Row.Index).Value)
            dBen("parentesco") = IIf(IsDBNull(dgBeneficiarios.Item("colParentesco", e.Row.Index).Value), "", dgBeneficiarios.Item("colParentesco", e.Row.Index).Value)
            dBen("nacimiento") = IIf(dgBeneficiarios.Item("colNacimiento", e.Row.Index).Value Is Nothing, Date.Now, dgBeneficiarios.Item("colNacimiento", e.Row.Index).Value)
            dBen("porcentaje") = IIf(dgBeneficiarios.Item("colPorcentaje", e.Row.Index).Value Is Nothing, 0, dgBeneficiarios.Item("colPorcentaje", e.Row.Index).Value)
            dBen("cod_prestacion") = dgBeneficiarios.Tag
            dtBeneficiarios.Rows.Add(dBen)

            dgBeneficiarios.Item("colID", e.Row.Index - 1).Value = id
            ActualizaPorcentajes()
            ActualizaPorcentajeBanco()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgBeneficiarios_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgBeneficiarios.UserDeletingRow
        Dim id As Integer
        Dim dBen As DataRow
        Try
            If MessageBox.Show("¿Está seguro de que desea eliminar el beneficiario " & dgBeneficiarios.Item("colBeneficiario", e.Row.Index).Value.ToString.Trim & _
                                " del registro del empleado?", "Eliminar beneficiario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                            = Windows.Forms.DialogResult.Yes Then

                id = dgBeneficiarios.Item(0, e.Row.Index).Value
                dBen = dtBeneficiarios.Rows.Find(id)
                If Not dBen Is Nothing Then
                    dBen("movimiento") = "B"
                End If
                ActualizaPorcentajes()
                ActualizaPorcentajeBanco()
            Else
                e.Cancel = True
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub ActualizaPorcentajes()
        Dim P As Double = 0
        Dim v As Double = 0
        Try
            For Each dReg As DataGridViewRow In dgBeneficiarios.Rows
                If dgBeneficiarios.Item("colPorcentaje", dReg.Index).Value Is Nothing Then
                    v = 0
                ElseIf IsDBNull(dgBeneficiarios.Item("colPorcentaje", dReg.Index).Value) Then
                    v = 0
                Else
                    v = dgBeneficiarios.Item("colPorcentaje", dReg.Index).Value
                End If
                P = P + v
            Next
            lblPorcentaje.Text = "TOTAL: " & Math.Round(P, 2) & "%"

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            lblPorcentaje.Text = "ERROR"
            P = -1
        End Try

        Try
            If P < 0 Then
                lblPorcentaje.BackColor = Color.Red
                lblPorcentaje.ForeColor = Color.White
            ElseIf P = 0 Then
                lblPorcentaje.BackColor = SystemColors.InactiveBorder
                lblPorcentaje.ForeColor = SystemColors.InactiveCaptionText
            ElseIf P = 100 Then
                lblPorcentaje.BackColor = SystemColors.Window
                lblPorcentaje.ForeColor = SystemColors.WindowText
            Else
                lblPorcentaje.BackColor = Color.Yellow
                lblPorcentaje.ForeColor = Color.Black
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub


    Private Sub ActualizaPorcentajeBanco()
        Dim P As Double = 0
        Dim v As Double = 0
        Try
            For Each dReg As DataGridViewRow In dgBeneficiariosBanco.Rows
                If dgBeneficiariosBanco.Item("colPorcentajeBanco", dReg.Index).Value Is Nothing Then
                    v = 0
                ElseIf IsDBNull(dgBeneficiariosBanco.Item("colPorcentajeBanco", dReg.Index).Value) Then
                    v = 0
                Else
                    v = dgBeneficiariosBanco.Item("colPorcentajeBanco", dReg.Index).Value
                End If
                P = P + v
            Next
            lblPorcentajeBanco.Text = "TOTAL: " & Math.Round(P, 2) & "%"

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            lblPorcentajeBanco.Text = "ERROR"
            P = -1
        End Try
        Try
            If P < 0 Then
                lblPorcentajeBanco.BackColor = Color.Red
                lblPorcentajeBanco.ForeColor = Color.White
            ElseIf P = 0 Then
                lblPorcentajeBanco.BackColor = SystemColors.InactiveBorder
                lblPorcentajeBanco.ForeColor = SystemColors.InactiveCaptionText
            ElseIf P = 100 Then
                lblPorcentajeBanco.BackColor = SystemColors.Window
                lblPorcentajeBanco.ForeColor = SystemColors.WindowText
            Else
                lblPorcentajeBanco.BackColor = Color.Yellow
                lblPorcentajeBanco.ForeColor = Color.Black
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub
    Private Sub dgBeneficiariosBanco_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgBeneficiariosBanco.CellContentClick

    End Sub

    Private Sub dgBeneficiariosBanco_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgBeneficiariosBanco.CellEndEdit
        Dim id As Integer
        Dim dBen As DataRow
        Try
            id = IIf(IsDBNull(dgBeneficiariosBanco.Item(0, e.RowIndex).Value), -1, dgBeneficiariosBanco.Item(0, e.RowIndex).Value)
            dBen = dtBeneficiarios.Rows.Find(id)
            If Not dBen Is Nothing Then
                If dBen("movimiento") = "X" Then
                    dBen("movimiento") = "C"
                End If
                dBen("nombre") = IIf(IsDBNull(dgBeneficiariosBanco.Item("colBeneficiarioBanco", e.RowIndex).Value), "", dgBeneficiariosBanco.Item("colBeneficiarioBanco", e.RowIndex).Value)
                dBen("parentesco") = IIf(IsDBNull(dgBeneficiariosBanco.Item("colParentesco", e.RowIndex).Value), "", dgBeneficiariosBanco.Item("colParentesco", e.RowIndex).Value)
                dBen("nacimiento") = IIf(IsDBNull(dgBeneficiariosBanco.Item("colNacimiento", e.RowIndex).Value), "", dgBeneficiariosBanco.Item("colNacimiento", e.RowIndex).Value)
                dBen("porcentaje") = IIf(IsDBNull(dgBeneficiariosBanco.Item("colPorcentajeBanco", e.RowIndex).Value), 0, dgBeneficiariosBanco.Item("colPorcentajeBanco", e.RowIndex).Value)

            End If
            If dgBeneficiarios.Tag = "BANCO" Then ActualizaPorcentajes()
            ActualizaPorcentajeBanco()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgBeneficiariosBanco_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgBeneficiariosBanco.UserAddedRow
        Dim id As Integer
        Dim dBen As DataRow
        Try
            id = CInt(TimeOfDay.Hour.ToString.Trim & TimeOfDay.Minute.ToString.Trim & TimeOfDay.Second.ToString.Trim)
            dBen = dtBeneficiarios.NewRow
            dBen("idFld") = id
            dBen("movimiento") = "A"
            dBen("nombre") = IIf(IsDBNull(dgBeneficiariosBanco.Item("colBeneficiarioBanco", e.Row.Index).Value), "", dgBeneficiariosBanco.Item("colBeneficiarioBanco", e.Row.Index).Value)
            dBen("parentesco") = IIf(IsDBNull(dgBeneficiariosBanco.Item("colParentesco", e.Row.Index).Value), "", dgBeneficiariosBanco.Item("colParentesco", e.Row.Index).Value)
            dBen("nacimiento") = Now
            dBen("porcentaje") = IIf(dgBeneficiariosBanco.Item("colPorcentajeBanco", e.Row.Index).Value Is Nothing, 0, dgBeneficiariosBanco.Item("colPorcentajeBanco", e.Row.Index).Value)
            dBen("cod_prestacion") = "BANCO"
            dtBeneficiarios.Rows.Add(dBen)

            dgBeneficiariosBanco.Item("colIDBanco", e.Row.Index - 1).Value = id
            If dgBeneficiarios.Tag = "BANCO" Then ActualizaPorcentajes()
            ActualizaPorcentajeBanco()
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgBeneficiariosBanco_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dgBeneficiariosBanco.UserDeletingRow
        Dim id As Integer
        Dim dBen As DataRow
        Try
            If MessageBox.Show("¿Está seguro de que desea eliminar el beneficiario " & dgBeneficiariosBanco.Item("colBeneficiarioBanco", e.Row.Index).Value.ToString.Trim & _
                                " del registro del empleado?", "Eliminar beneficiario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                            = Windows.Forms.DialogResult.Yes Then

                id = dgBeneficiariosBanco.Item(0, e.Row.Index).Value
                dBen = dtBeneficiarios.Rows.Find(id)
                If Not dBen Is Nothing Then
                    dBen("movimiento") = "B"
                End If
                If dgBeneficiarios.Tag = "BANCO" Then ActualizaPorcentajes()
                ActualizaPorcentajeBanco()
            Else
                e.Cancel = True
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgFamiliares_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgFamiliares.CellContentClick

    End Sub

    Private Sub pnlEncabezado_Paint(sender As Object, e As PaintEventArgs) Handles pnlEncabezado.Paint

    End Sub

    Private Sub cmbColonia_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbColonia.ButtonCustomClick
        Dim Cod As String
        Cod = Buscar("colonias", "cod_col", "colonias", False)
        If Cod <> "CANCELAR" Then
            'Dim dtCol As DataTable = sqlExecute("SELECT * from colonias WHERE cod_col = '" & Cod & "'")            
            cmbColonia.SelectedValue = Cod
        End If
    End Sub

    Private Sub cmbCd_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbCd.ButtonCustomClick
        Dim Cod As String
        Cod = Buscar("ciudad", "cod_cd", "ciudad", False)
        If Cod <> "CANCELAR" Then
            cmbCd.SelectedValue = Cod
        End If
    End Sub

    Private Sub cmbLugarNac_ButtonCustomClick(sender As Object, e As EventArgs) Handles cmbLugarNac.ButtonCustomClick
        Dim Cod As String
        Cod = Buscar("estados", "cod_edo", "estados", False)
        If Cod <> "CANCELAR" Then
            cmbLugarNac.SelectedValue = Cod
        End If
    End Sub


    Private Sub dgAuxiliaresSeleccionados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAuxiliaresSeleccionados.CellContentClick

    End Sub

    Private Sub txtCurp_TextChanged(sender As Object, e As EventArgs) Handles txtCurp.TextChanged
        Try
            If txtCurp.Text.Length > 13 Then
                Dim cod_estado As String = txtCurp.Text.Substring(11, 2)

                Dim fha_nac As String = txtCurp.Text.Substring(4, 6)

                Dim sexo As String = txtCurp.Text.Substring(10, 1)

                cmbLugarNac.SelectedValue = cod_estado

                txtFechaNac.Value = RFCaFechaNac(txtCurp.Text)

                If sexo.Equals("H") Then
                    btnSexo.Value = False
                ElseIf sexo.Equals("M") Then
                    btnSexo.Value = True
                End If

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtRFC_TextChanged(sender As Object, e As EventArgs) Handles txtRFC.TextChanged
        Try
            If txtCurp.Text.Length < 10 Then
                txtCurp.Text = txtRFC.Text
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub cmbHorario_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbHorario.SelectedValueChanged
        Try
            Dim dtTurno As DataTable = sqlExecute("select * from horarios where cod_hora = '" & cmbHorario.SelectedValue & "'")
            If dtTurno.Rows.Count Then
                cmbTurno.SelectedValue = dtTurno.Rows(0)("cod_turno")
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub


    Private Sub txtFechaNac_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaNac.ValueChanged
        Try
            'MCR 5/NOV/2015
            'Cambiar procedimiento para utilizar el mismo que en el view
            Dim fha_nac As Date
            Dim edad As String
            fha_nac = txtFechaNac.Value
            If (Month(fha_nac) > Month(Now) Or (Month(fha_nac) = Month(Now) And DatePart(DateInterval.Day, fha_nac) > DatePart(DateInterval.Day, Now))) Then
                edad = DateDiff(DateInterval.Year, fha_nac, Now) - 1
            Else
                edad = DateDiff(DateInterval.Year, fha_nac, Now)
            End If

            txtEdadEnAños.Text = edad.Trim & " Años de edad"
        Catch ex As Exception
            txtEdadEnAños.Text = "ERROR"
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try


    End Sub

    Private Sub cmbClase_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbClase.SelectedValueChanged
        Try
            dtTemp = sqlExecute("SELECT nivel_seguridad FROM clase WHERE cod_clase = '" & cmbClase.SelectedValue & "'")
            If dtTemp.Rows.Count > 0 Then
                nReingresos = dtTemp.Rows(0).Item("nivel_seguridad")
            Else
                nReingresos = 0
            End If

            gpSueldos.Visible = nReingresos <= NivelSueldos

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtCuentaBonos_TextChanged(sender As Object, e As EventArgs) Handles txtCuentaBonos.TextChanged
        Try
            If Nuevo Or Editar Then
                txtTarjetaBonos.Text = txtCuentaBonos.Text
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtEBaja_ValueChanged(sender As Object, e As EventArgs) Handles txtEBaja.ValueChanged
        Try
            Dim FBaja As String = ""
            Try : FBaja = FechaSQL(txtEBaja.Value) : Catch ex As Exception : FBaja = "" : End Try
            txtAntiguedad.Text = AntiguedadExacta(txtEAlta.Value, txtEAlta.Value)
            If (FBaja <> "" And FBaja <> "0001-01-01") Then
                CalcDAgDVacDPvac(txtReloj.Text, txtEBaja.Value, False)
            Else
                txtDiasAgui.Text = "0.00"
                txtDiasVac.Text = "0.00"
                txtDiasPrimaVac.Text = "0.00"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnBorrarVac_Click(sender As Object, e As EventArgs)
        Dim idx As Integer
        Dim Aniv As Boolean = False
        Dim rl As String
        Dim FechaCaptura As Date
        Dim FechaEnvio As Date
        Dim Ano As String
        Dim BorrarVacaciones As Boolean = True
        Dim ClaveVA As String
        Dim _dinero As Double
        Dim _tiempo As Double

        Dim _saldo_dinero As Double
        Dim _saldo_tiempo As Double
        Dim _fecha_ini As Date
        Dim _fecha_fin As Date
        Dim _prima As Double
        Dim _fecha As Date
        Dim _dias As Double

        Try
            idx = 0
            Aniv = IIf(IsDBNull(dgVacaciones.Item("colAniversario", idx).Value), 0, dgVacaciones.Item("colAniversario", idx).Value) = 1

            If Aniv Then
                MessageBox.Show("No es posible borrar las vacaciones asignadas por aniversario.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            rl = txtReloj.Text.Trim
            FechaCaptura = dgVacaciones.Item("colFechaCaptura", idx).Value
            Ano = dgVacaciones.Item("colAno", idx).Value
            _dias = dgVacaciones.Item("colTomadosDinero", idx).Value
            dtTemp = sqlExecute("SELECT envio_date FROM ajustes_nom WHERE ano = '" & Ano & "' AND reloj = '" & rl & _
                                "' AND concepto = 'DIASVA' AND fecha = '" & FechaSQL(FechaCaptura) & "' AND monto = " & _dias & _
                                " ORDER BY envio_date", "nomina")
            If dtTemp.Rows.Count > 0 Then
                FechaEnvio = IIf(IsDBNull(dtTemp.Rows(0).Item("envio_date")), Nothing, dtTemp.Rows(0).Item("envio_date"))
                If Not FechaEnvio = Nothing Then
                    If DateDiff(DateInterval.Day, FechaEnvio, Now) > 3 Then
                        MessageBox.Show("Este registro de vacaciones fue enviado a pago, por lo que ya no puede ser modificado.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    Else
                        If MessageBox.Show("Ya se envió a nómina el registro de estas vacaciones." & vbCrLf & "¿Está seguro de querer continuar?", "PIDA", _
                                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                            Exit Sub
                        Else
                            BorrarVacaciones = False
                        End If
                    End If
                ElseIf MessageBox.Show("¿Está seguro de querer borrar el registro de " & _dias & IIf(_dias = 1, " día", " días") & " de vacaciones?", "Borrar vacaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            ElseIf MessageBox.Show("¿Está seguro de querer borrar el registro de " & _dias & IIf(_dias = 1, " día", " días") & " de vacaciones?", "Borrar vacaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            dtTemp = sqlExecute("SELECT * FROM saldos_vacaciones WHERE " & _
                    "RELOJ = '" & rl & "' AND ano = '" & Ano & "' AND fecha_captura = '" & FechaHoraSQL(FechaCaptura) & "'")
            _dinero = dtTemp.Rows(0).Item("dinero")
            _tiempo = dtTemp.Rows(0).Item("tiempo")
            _saldo_dinero = dtTemp.Rows(0).Item("saldo_dinero")
            _saldo_tiempo = dtTemp.Rows(0).Item("saldo_tiempo")
            _prima = dtTemp.Rows(0).Item("prima")
            _fecha_ini = dtTemp.Rows(0).Item("fecha_ini")
            _fecha_fin = dtTemp.Rows(0).Item("fecha_fin")

            Dim QBorrarAus As String = "Delete from TA.dbo.ausentismo where reloj='" & rl & "' and tipo_aus='VAC' and periodo=25 and cod_comp='" & cmbCia.SelectedValue & "'"

            Dim QBorrarMisc As String = "DELETE TOP (1) FROM ajustes_nom WHERE " & _
                "RELOJ = '" & rl & "' AND ano = '" & Ano & "' AND concepto = 'DIASVA' AND fecha = '" & _
                FechaSQL(FechaCaptura) & "' AND monto = " & _dias & " AND periodo = (SELECT MAX(Periodo) FROM ajustes_nom WHERE " & _
                "RELOJ = '" & rl & "' AND ano = '" & Ano & "' AND concepto = 'DIASVA' AND fecha = '" & _
                FechaSQL(FechaCaptura) & "' AND monto = " & _dias & ")"

            If BorrarVacaciones Then
                sqlExecute("DELETE FROM saldos_vacaciones WHERE " & _
                         "RELOJ = '" & rl & "' AND ano = '" & Ano & "' AND fecha_captura = '" & FechaHoraSQL(FechaCaptura) & "'")
                sqlExecute(QBorrarMisc, "nomina")
            Else
                sqlExecute("INSERT INTO saldos_vacaciones (reloj,ano,prima,saldo_dinero,saldo_tiempo,dinero,tiempo,comentario," & _
                           "fecha_ini,fecha_fin,fecha_captura) VALUES ('" & _
                           rl & "','" & _
                           Ano & "'," & _
                           _prima & "," & _
                           _saldo_dinero + _dinero & "," & _
                           _saldo_tiempo + _tiempo & "," & _
                           -_dinero & "," & _
                           -_tiempo & _
                           ",'CANCELAR VACACIONES CAPTURADAS EL DIA " & FechaCaptura & "','" & _
                           FechaSQL(_fecha_ini) & "','" & _
                           FechaSQL(_fecha_fin) & "','" & _
                           FechaHoraSQL(Now) & "')")

                dtTemp = sqlExecute("SELECT misce_clave FROM conceptos WHERE concepto = 'DIASVA'", "NOMINA")
                If dtTemp.Rows.Count > 0 Then
                    ClaveVA = dtTemp.Rows.Item(0).Item("misce_clave")
                Else
                    ClaveVA = ""
                End If

                Ano = ObtenerAnoPeriodo(FechaCaptura)
                Periodo = Ano.Substring(4, 2)
                Ano = Ano.Substring(0, 4)

                sqlExecute("INSERT INTO ajustes_nom (reloj,ano,periodo,per_ded,clave,monto,envio_nom,envio_date,envio_usu,comentario,concepto,usuario,fecha) VALUES ('" & _
                          rl & "','" & _
                          Ano & "','" & _
                          Periodo & "','P','" & _
                          ClaveVA & "'," & _
                          -_dinero & _
                          ",1," & _
                          "'" & FechaSQL(Now) & "'," & _
                          "'" & Usuario & "'," & _
                          "'Días de vacaciones CANCELADOS desde MAESTRO','DIASVA','" & Usuario & "', GETDATE())", "Nomina")
                MessageBox.Show("Es necesario avisar directamente a la persona responsable del cálculo de nómina sobre esta cancelación " & _
                                "posterior al envío de información.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            Dim AusVac As String

            '***** PROCESO PARA ELIMINAR VACACIONES EN AUSENTISMO *******
            dtTemp = sqlExecute("SELECT tipo_aus FROM tipo_ausentismo WHERE tipo_naturaleza = 'V'", "TA")
            If dtTemp.Rows.Count = 0 Then
                AusVac = "VAC"
            Else
                AusVac = dtTemp.Rows(0).Item("tipo_aus")
            End If

            _fecha = _fecha_ini
            Do Until _fecha > _fecha_fin
                sqlExecute("DELETE FROM ausentismo WHERE reloj = '" & Reloj & "' AND fecha = '" & FechaSQL(_fecha) & _
                           "' AND tipo_aus = '" & AusVac & "'", "TA")
                _fecha = DateAdd(DateInterval.Day, 1, _fecha)
            Loop
            '**************************************
            RefrescaVacaciones(rl)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("El registro de vacaciones no pudo ser borrado. Si el problema persiste, consulte al administrador del sistema." & _
                            vbCrLf & vbCrLf & "Err.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgVacaciones_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub dgVacaciones_CellEnter(sender As Object, e As DataGridViewCellEventArgs)
        btnBorrarVac.Enabled = (e.RowIndex = 0)
    End Sub

    Private Sub cmbBajaInterno_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbBajaInterno.SelectedValueChanged
        Try
            Dim dtBajIMSS As DataTable = sqlExecute("select * from cod_mot_baj where cod_mot_ba = '" & cmbBajaInterno.SelectedValue & "'")
            If dtBajIMSS.Rows.Count Then
                cmbBajaIMSS.SelectedValue = dtBajIMSS.Rows(0)("cod_mot_im")
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtAlta_Click(sender As Object, e As EventArgs) Handles txtAlta.Click

    End Sub

    Private Sub txtAlta_ValueChanged(sender As Object, e As EventArgs) Handles txtAlta.ValueChanged
        If Editar Or Nuevo Then
            'If Math.Abs(DateDiff(DateInterval.Day, txtAlta.Value, Now)) > 15 Then
            '    MessageBox.Show("Hay una diferencia mayor a 15 días entre la fecha de alta y el día de hoy.", _
            '                    "Fecha de alta", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            'End If
        End If
    End Sub



    Private Sub cmbHorario_TextChanged(sender As Object, e As EventArgs) Handles cmbHorario.TextChanged

    End Sub

    Private Sub cmbDepto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDepto.SelectedValueChanged
        'Try
        '    If Editar Or Nuevo Then
        '        Dim dtCCostos As New DataTable
        '        dtCCostos = sqlExecute("select centro_costos,cod_super from deptos where cod_comp = '" & cmbCia.SelectedValue & _
        '                               "' AND cod_depto= '" & cmbDepto.SelectedValue & "'")
        '        If dtCCostos.Rows.Count > 0 Then
        '            cmbCCostos.SelectedValue = dtCCostos.Rows(0)("centro_costos")
        '            cmbSuper.SelectedValue = dtCCostos.Rows(0)("cod_super")
        '        Else
        '            cmbCCostos.SelectedValue = ""
        '            cmbSuper.SelectedValue = ""
        '        End If
        '    End If
        'Catch ex As Exception
        '    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        'End Try
    End Sub


    Private Sub dgBeneficiarios_KeyDown(sender As Object, e As KeyEventArgs) Handles dgBeneficiarios.KeyDown
        Try
            If Editar Then
                If e.KeyCode = Keys.Delete Then
                    Dim idfld As String = dgBeneficiarios.Rows(dgBeneficiarios.SelectedCells(0).RowIndex).Cells("colID").Value.ToString.Trim
                    If MsgBox("¿Desea borrar al beneficiario " & dgBeneficiarios.Rows(dgBeneficiarios.SelectedCells(0).RowIndex).Cells("colBeneficiario").Value.ToString.Trim & " de la lista de beneficiarios del empleado " & txtReloj.Text & "?", MsgBoxStyle.OkCancel, "Borrar Beneficiario") = MsgBoxResult.Ok Then
                        sqlExecute("delete from beneficiarios where idfld = '" & idfld & "'")
                        dgBeneficiarios.Rows.RemoveAt(dgBeneficiarios.SelectedCells(0).RowIndex)
                    End If
                End If
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgFamiliares_KeyDown(sender As Object, e As KeyEventArgs) Handles dgFamiliares.KeyDown
        Try
            If Editar Then
                If e.KeyCode = Keys.Delete Then
                    Dim idfld As String = dgFamiliares.Rows(dgFamiliares.SelectedCells(0).RowIndex).Cells("idfld").Value

                    Dim dtFamiliarABorrar As DataTable = sqlExecute("select * from familiares where idfld = '" & idfld & "'")
                    If dtFamiliarABorrar.Rows.Count > 0 Then
                        Dim dr As DataRow = dtFamiliarABorrar.Rows(0)

                        If MsgBox("¿Desea borrar a " & dr("nombre").ToString.ToUpper.Trim & " de la lista de familiares del empleado " & txtReloj.Text & "?", MsgBoxStyle.OkCancel, "Borrar Familiar") = MsgBoxResult.Ok Then
                            sqlExecute("delete from familiares where idfld = '" & idfld & "'")
                            dgFamiliares.AutoGenerateColumns = False
                            dgFamiliares.DataSource = sqlExecute("SELECT familiares.idfld, familiares.COD_FAMILIA + ' - ' + familia.nombre as 'CÓD.FAMILIA', familiares.NOMBRE AS '" & encabezado_nombre & "', familiares.FECHA_NAC AS '" & encabezado_fechas & "' FROM familiares INNER JOIN familia ON familiares.COD_FAMILIA = familia.COD_FAMILIA WHERE reloj = '" & txtReloj.Text & "'")
                        End If
                    End If
                End If
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub dgEscolaridad_KeyDown(sender As Object, e As KeyEventArgs) Handles dgEscolaridad.KeyDown
        Try
            If Editar Then
                If e.KeyCode = Keys.Delete Then
                    Dim idfld As String = dgEscolaridad.Rows(dgEscolaridad.SelectedCells(0).RowIndex).Cells("idfld").Value

                    Dim dtEscolaridadABorrar As DataTable = sqlExecute("SELECT escolaridad.*, escuelas.NOMBRE FROM [dbo].[escolaridad] left join escuelas on escuelas.COD_ESCUELA = escolaridad.COD_ESCUELA where idfld = '" & idfld & "'")
                    If dtEscolaridadABorrar.Rows.Count > 0 Then
                        Dim dr As DataRow = dtEscolaridadABorrar.Rows(0)

                        If MsgBox("¿Desea borrar " & RTrim(dr("nombre").ToString.ToUpper) & " - " & RTrim(IIf(IsDBNull(dr("nombre_escuela")), "", dr("nombre_escuela")).ToString).ToUpper & " de la lista de escolaridad del empleado " & txtReloj.Text & "?", MsgBoxStyle.OkCancel, "Borrar Escolaridad") = MsgBoxResult.Ok Then
                            sqlExecute("delete from escolaridad where idfld = '" & idfld & "'")
                            dgEscolaridad.AutoGenerateColumns = False
                            dgEscolaridad.DataSource = sqlExecute("SELECT escolaridad.idFld,escolaridad.cod_escuela + ' - ' + escuelas.nombre as 'NIVEL ESC.',escolaridad.nombre_escuela as 'NOMBRE/DESCRIPCIÓN', escolaridad.anos as 'AÑOS',finalizo AS 'FINALIZÓ' FROM escolaridad FULL OUTER JOIN escuelas ON escuelas.cod_escuela=escolaridad.cod_escuela WHERE reloj = '" & txtReloj.Text & "'")
                        End If
                    End If
                End If
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub cmbCCostos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCCostos.SelectedValueChanged
        'Try
        '    If Nuevo Or Editar Then
        '        Dim dtAreas As DataTable = sqlExecute("select cod_area from c_costos where centro_costos= '" & cmbCCostos.SelectedValue & "'")
        '        If dtAreas.Rows.Count Then
        '            cmbArea.SelectedValue = dtAreas.Rows(0)("cod_area")
        '        End If
        '    End If
        'Catch ex As Exception
        '    ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        'End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Me.Activate()
        Timer1.Stop()
    End Sub

    Private Sub cmbTipo_TextChanged(sender As Object, e As EventArgs) Handles cmbTipo.TextChanged

    End Sub

    Private Sub cmbPuesto_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPuesto.SelectedValueChanged
        Try
            If cmbPuesto.SelectedValue Is Nothing Then Exit Sub
            Dim dtPuestoActivo As DataTable = sqlExecute("SELECT * FROM puestos WHERE cod_puesto = '" & cmbPuesto.SelectedValue & "'")
            PuestoActivo = dtPuestoActivo.Rows(0)("activo")
            'MCR 27/OCT/2015
            'Asignar nivel de acuerdo al puesto cuando se está agregando o reingreso
            If Nuevo Or DarReingreso Then
                If cmbCia.SelectedValue Is Nothing Or cmbPuesto.SelectedValue Is Nothing Then Exit Sub
                Dim dtNivel As New DataTable
                dtNivel = sqlExecute("SELECT nivel FROM puestos WHERE cod_comp = '" & cmbCia.SelectedValue & "' AND cod_puesto = '" & _
                                              cmbPuesto.SelectedValue & "'")
                If dtNivel.Rows.Count > 0 Then
                    If Not IsDBNull(dtNivel.Rows(0)("nivel")) Then
                        cmbNivel.SelectedValue = dtNivel.Rows(0)("nivel").ToString.Trim
                    End If
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

        End Try

    End Sub

    Private Sub cmbPuesto_TextChanged(sender As Object, e As EventArgs) Handles cmbPuesto.TextChanged

    End Sub

    Private Sub Label32_Click(sender As Object, e As EventArgs) Handles Label32.Click

    End Sub

    Private Sub cmbCia_TextChanged(sender As Object, e As EventArgs) Handles cmbCia.TextChanged

    End Sub

    Private Sub cmbCia_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbCia.Validating
        If (Nuevo Or Editar) And Not CiaEditable Then
            MessageBox.Show("No se puede asignar un empleado a una compañía que no es editable. Favor de verificar.", "Compañía no editable", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If
    End Sub

    Private Sub cmbPuesto_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbPuesto.Validating
        If (Nuevo Or Editar) And Not PuestoActivo Then
            MessageBox.Show("No se puede asignar un empleado a un puesto inactivo. Favor de verificar.", "Puesto inactivo", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            e.Cancel = True
        End If
    End Sub

    Private Sub btnEditaAuxiliares_Click(sender As Object, e As EventArgs) Handles btnEditaAuxiliares.Click
        Try
            Dim frm As New frmEditaAuxiliares
            frm.reloj_ = txtReloj.Text
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                MostrarInformacion(txtReloj.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgAuxiliares_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgAuxiliares.CellDoubleClick

        Dim bonorecom As String = ""
        If IsDBNull(dgAuxiliares.Item("CAMPO", e.RowIndex).Value) Then
            bonorecom = ""
        Else
            bonorecom = dgAuxiliares.Item("CAMPO", e.RowIndex).Value
        End If
        If bonorecom = "RECOMEN" Then
            dtTemp = dtPersonal
            Try
                frmBuscar.ShowDialog(Me)
                If Reloj <> "CANCEL" Then
                    dgAuxiliares.Item(e.ColumnIndex, e.RowIndex).Value = Reloj
                    Reloj = txtReloj.Text
                Else
                    dgAuxiliares.Item(e.ColumnIndex, e.RowIndex).Value = ""
                End If

            Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
                dtPersonal = dtTemp
            End Try
        End If

        Dim NewVal As String
        Dim ID As String
        Dim dR As DataRow
        Static NvoID As Integer = 999000
        Try
            NvoID = NvoID + 1

            ID = IIf(IsDBNull(dgAuxiliares.Item("idfld", e.RowIndex).Value), NvoID, dgAuxiliares.Item("idfld", e.RowIndex).Value)

            NewVal = IIf(IsDBNull(dgAuxiliares.Item(e.ColumnIndex, e.RowIndex).Value), "", dgAuxiliares.Item(e.ColumnIndex, e.RowIndex).Value)

            If AuxAnt <> NewVal Then
                dR = dtCambiosAuxiliares.Rows.Find(ID)
                If IsNothing(dR) Then
                    dtCambiosAuxiliares.Rows.Add(ID, IIf(ID > 999000, "A", "C"), dgAuxiliares.Item("CAMPO", e.RowIndex).Value, dgAuxiliares.Item("CONTENIDO", e.RowIndex).Value)
                    dgAuxiliares.Item("idfld", e.RowIndex).Value = ID
                Else

                    dR.Item("CAMPO") = dgAuxiliares.Item("CAMPO", e.RowIndex).Value
                    dR.Item("CONTENIDO") = dgAuxiliares.Item("CONTENIDO", e.RowIndex).Value
                End If

                AgregarAux = False
            End If

            If NewVal = "RECOMEN" Then
                dgAuxiliares.Item("CONTENIDO", e.RowIndex).ReadOnly = True
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try


    End Sub

    Private Sub btCargaMasivaTargeta_Click(sender As Object, e As EventArgs) Handles btCargaMasivaTargeta.Click
        On Error Resume Next
        frmCargaMasivaTarjetas.ShowDialog()
    End Sub

    Private Sub txtEmail_empl_Leave(sender As Object, e As EventArgs) Handles txtEmail_empl.Leave
        '---Validar que el EMAIL del empleado esté en el formato correcto
        If Not IsValidEmail(txtEmail_empl.Text.Trim) Then ' Si no esta en el formato correcto:
            If MessageBox.Show("El correo electrónico tecleado no está en el formato correcto, desea así continuar?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                ' Si no desea continuar y capturarlo correctamente, entonces nos volvemos al control TEXT:
                txtEmail_empl.Focus()
            End If
        End If
    End Sub

    Private Function IsValidEmail(ByVal _email As String) As Boolean
        Return Regex.IsMatch(_email, "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
    End Function

    Private Sub txtProyVacas_ValueChanged(sender As Object, e As EventArgs) Handles txtProyVacas.ValueChanged
        Try

            Dim FPryVac As String = ""
            Dim tipo_emp As String = cmbTipo.SelectedValue
            Dim cod_comp As String = cmbCia.SelectedValue
            Dim esFiniquito As Boolean = False, vieneProyVac As Boolean = True

            Try : FPryVac = FechaSQL(txtProyVacas.Value) : Catch ex As Exception : FPryVac = "" : End Try
            If (FPryVac <> "" And FPryVac <> "0001-01-01") Then
                '--Proyectar vacaciones         
                txtSaldoFinalVacs.Text = Double.Parse(CalcSaldoFinVacas(txtReloj.Text, txtAlta.Value, txtProyVacas.Value, tipo_emp, cod_comp, esFiniquito, vieneProyVac))
            Else
                txtSaldoFinalVacs.Text = "0.00"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Function CalcSaldoFinVacas(ByVal Rj As String, FAlta As Date, FVacs As Date, TipoEmp As String, CodComp As String, Optional ByVal EsFiniquito As Boolean = False, Optional ByVal vieneProyVac As Boolean = False) As Double
        Dim dtVac As New DataTable
        Dim _anos As Integer
        Dim Resultado As Double = 0.0
        Try
            Dim _aniv As New Date(FVacs.Year, FAlta.Month, FAlta.Day)
            Dim _aniv_Ant As New Date(FVacs.Year - 1, FAlta.Month, FAlta.Day) ' Aniv del anio anterior si aplica
            Dim AntigDias As Double = 0.0
            Dim dias_vac As Double = 0.0
            Dim _dias As Double = 0.0
            Dim SaldoPendPagar As Double = 0.0

            '---AOS 2023-07-25 :: Que sea en base a lo último
            '            Dim QSaldoDin As String = "SELECT TOP 1 saldo_dinero " & _
            '  "FROM saldos_vacaciones WHERE reloj = '" & Rj.Trim & _
            '"' ORDER BY fecha_captura DESC,fecha_fin DESC"

            '            Dim dtSaldoDin As DataTable = sqlExecute(QSaldoDin, "PERSONAL")
            '            If ((dtSaldoDin.Columns.Contains("Error")) Or (Not dtSaldoDin.Columns.Contains("Error") And dtSaldoDin.Rows.Count = 0)) Then
            '                SaldoPendPagar = 0.0
            '            Else

            '                'SaldoPendPagar = IIf(IsDBNull(dtSaldoDin.Rows(0).Item("saldo_dinero")), 0.0, dtSaldoDin.Rows(0).Item("saldo_dinero")) + _
            '                '    IIf(IsDBNull(dtSaldoDin.Rows(0).Item("saldo_dinero_anterior")), 0.0, dtSaldoDin.Rows(0).Item("saldo_dinero_anterior")) + _
            '                '    IIf(IsDBNull(dtSaldoDin.Rows(0).Item("saldo_dinero_anterior2")), 0.0, dtSaldoDin.Rows(0).Item("saldo_dinero_anterior2"))

            '                SaldoPendPagar = IIf(IsDBNull(dtSaldoDin.Rows(0).Item("saldo_dinero")), 0.0, dtSaldoDin.Rows(0).Item("saldo_dinero"))
            '            End If

            '===2024-12-18: Obtener saldo pendiente de pagar (Nueva forma)
            Dim dtGanadas As New DataTable, dtPagadas As New DataTable, query As String = "", ganadas As Double = 0.0, pagadas As Double = 0.0

            '==Ganadas
            query = "SELECT ISNULL(SUM(convert(float,DIAS)),0) AS 'GANADAS' FROM saldos_vacaciones  where reloj='" & Rj & "'"
            dtGanadas = sqlExecute(query, "PERSONAL")
            If Not dtGanadas.Columns.Contains("Error") And dtGanadas.Rows.Count > 0 Then
                Try : ganadas = Double.Parse(dtGanadas.Rows(0).Item("GANADAS")) : Catch ex As Exception : ganadas = 0.0 : End Try
            End If

            '===Pagadas
            query = "SELECT ISNULL(SUM(convert(float,dinero)),0) AS 'PAGADAS' FROM saldos_vacaciones where reloj='" & Rj & "'"
            dtPagadas = sqlExecute(query, "PERSONAL")
            If Not dtPagadas.Columns.Contains("Error") And dtPagadas.Rows.Count > 0 Then
                Try : pagadas = Double.Parse(dtPagadas.Rows(0).Item("PAGADAS")) : Catch ex As Exception : pagadas = 0.0 : End Try
            End If

            SaldoPendPagar = ganadas - pagadas



            '*** LUA 2021-20-07
            Dim SaldoCancelado As Double = 0
            If EsFiniquito Then

                ' HERE AOS 2023-01-06 Revisar
                Dim QSaldoDinFin As String = "SELECT TOP 1 dinero,saldo_dinero, saldo_tiempo, " & _
                    "rtrim(ltrim(comentario)) as comentario FROM saldos_vacaciones WHERE reloj = '" & Rj.Trim & _
                    "' and fecha_fin<='" & FechaSQL(FVacs) & "'  ORDER BY fecha_captura DESC,fecha_fin DESC"

                Dim dtSaldoDinCance As DataTable = sqlExecute(QSaldoDinFin, "PERSONAL")

                If ((dtSaldoDinCance.Columns.Contains("Error")) Or (Not dtSaldoDinCance.Columns.Contains("Error") And dtSaldoDinCance.Rows.Count = 0)) Then
                    SaldoCancelado = 0.0
                Else

                    If dtSaldoDinCance.Rows.Count > 0 Then

                        Dim _comentario As String = Trim(IIf(IsDBNull(dtSaldoDinCance.Rows(0)("comentario")), "", dtSaldoDinCance.Rows(0)("comentario")))

                        If _comentario.ToLower.Replace("ó", "o") = "cancelacion de saldos por baja" Then
                            SaldoCancelado = IIf(IsDBNull(dtSaldoDinCance.Rows(0).Item("dinero")), 0.0, dtSaldoDinCance.Rows(0).Item("dinero"))
                        Else
                            SaldoCancelado = 0.0
                        End If
                    Else
                        SaldoCancelado = 0.0
                    End If

                End If

            End If

            '****2023-01-09: Validar que ese saldo cancelado no sea producto de un aniversario que aun no le corresponde, ya que la fecha del finiquito o de baja es menor a la del aniversario
            Dim QValidaSaldoCanceladoXAniv As String = "select top 1 * from saldos_vacaciones where reloj='" & Rj.Trim & "'   and SALDO_DINERO=" & SaldoCancelado & " and COMENTARIO like '%ANIV%' and FECHA_FIN>'" & FechaSQL(FVacs) & "'"
            Dim dtQValidaSaldoCanc As DataTable = sqlExecute(QValidaSaldoCanceladoXAniv, "PERSONAL")
            If (Not dtQValidaSaldoCanc.Columns.Contains("Error") And dtQValidaSaldoCanc.Rows.Count > 0) Then SaldoCancelado = 0
            SaldoPendPagar = SaldoPendPagar + SaldoCancelado


            'MCR 20210907 - Considerar si entre el día de hoy y la fecha de proyección cumple aniversario

            If vieneProyVac Then
                dias_vac = ProporcionVacas2(FAlta, FVacs, TipoEmp, CodComp, Now.Date()) ' Que calcule a partir del dia en que se está consultando
            Else
                dias_vac = ProporcionVacaciones(FAlta, FVacs, TipoEmp, CodComp) ' Func Orginal
            End If

            '---AO 2023-12-06: Sumarle las devengadas al dia de hoy:
            Dim _diasDevFecActual As Double = 0.0
            _diasDevFecActual = VacacionesDevengadas(Rj.Trim, Now.Date)

            If FVacs.ToShortDateString <> Now.Date Then
                dias_vac += _diasDevFecActual ' Solo si la fecha de proy es diferente al dia de hoy, sumarle las devengadas
            Else
                dias_vac = _diasDevFecActual ' si es el mismo dia a conosultar, dejar las proporcionales calculadas x default
            End If


            '---******-----****---AO 2023-12-06: Validar si sumar o no los nuevos dias de aniversario
            'Dim dtDiasVacAnivAct As New DataTable
            'dtDiasVacAnivAct = sqlExecute("select * from saldos_vacaciones where reloj='" & Rj & "' and COMENTARIO like '%ANIV%' and FECHA_FIN='" & FechaSQL(FVacs) & "'", "PERSONAL")
            'If dtDiasVacAnivAct.Rows.Count <= 0 Then ' si no estan los dias en pantalla, sumarlos
            '    ' If _aniv <= FVacs And _aniv >= Now.Date Then

            '    If _aniv <= FVacs.ToShortDateString And _aniv > Now.Date Then

            '        _anos = AntiguedadVac(FAlta, _aniv_Ant)

            '        dtVac = sqlExecute("SELECT * FROM vacaciones WHERE cod_comp = '" & CodComp & "' AND cod_tipo = '" & TipoEmp & "' AND anos = " & _anos + 1, "PERSONAL")

            '        If dtVac.Rows.Count > 0 Then
            '            _dias = dtVac.Rows.Item(0).Item("dias")
            '        Else
            '            _dias = 0
            '        End If

            '        dias_vac = dias_vac + _dias
            '    End If
            'End If
            '---******----END Valida si sumar o no los nuevos dias de aniv


            '*******------------SOLICITUD DE QUE LAS VACS AFECTEN DEL KARDEX
            Dim vacAus As Double = 0.0
            ' AO 2023-05-23: Que descuente los dias de vacaciones proyectadas que estan en el Kardex, solicitado por Marisa
            'Dim fHoy As Date = Date.Now(), vacAus As Double = 0.0, QueryConsultaKardex As String = "", dtVacasKardex As New DataTable
            'If FVacs > fHoy Then
            '    QueryConsultaKardex = "SELECT * from ausentismo where reloj='" & Rj & "' and TIPO_AUS in ('VAC') and fecha between '" & FechaSQL(fHoy) & "' and '" & FechaSQL(FVacs) & "'"
            '    dtVacasKardex = sqlExecute(QueryConsultaKardex, "TA")
            '    If Not dtVacasKardex.Columns.Contains("Error") And dtVacasKardex.Rows.Count > 0 Then vacAus = dtVacasKardex.Rows.Count
            'End If
            '************-----------END SOLICITUD DE QUE LAS VACS AFECTEN AL KARDEX

            Resultado = Math.Round((SaldoPendPagar + dias_vac - vacAus), 2)
            Return Resultado

        Catch ex As Exception
            Return Resultado
        End Try

    End Function

    Private Sub CalcDAgDVacDPvac(ByVal Rj As String, ByVal FBaja As Date, ByVal ActTblPers As Boolean)
        Try
            Dim valor As String = FechaSQL(FBaja)
            If (Rj <> "" And valor <> "") Then
                '-----Datos Generales
                Dim dtEmp As New DataTable
                dtEmp = sqlExecute("SELECT alta,baja,cod_comp,ISNULL(cod_tipo,'') AS cod_tipo,ISNULL(tipo_periodo,'') AS tipo_periodo FROM personal WHERE reloj = '" & Rj & "'")


                '*****************Días de vacaciones
                Dim Campo As String = ""
                Dim saldo_dinero As Double = 0.0
                Dim saldo_devengado As Double = 0.0
                Dim DiasVac As Double = 0.0
                Dim QSaldoDin As String = "SELECT TOP 1 saldo_dinero, saldo_tiempo FROM saldos_vacaciones WHERE reloj = '" & Rj.Trim & _
                        "' ORDER BY fecha_captura DESC,fecha_fin DESC"
                Dim dtSaldoDin As DataTable = sqlExecute(QSaldoDin, "PERSONAL")

                If ((dtSaldoDin.Columns.Contains("Error")) Or (Not dtSaldoDin.Columns.Contains("Error") And dtSaldoDin.Rows.Count = 0)) Then
                    saldo_dinero = 0.0
                    GoTo CalcSaldoDev
                End If
                saldo_dinero = IIf(IsDBNull(dtSaldoDin.Rows(0).Item("saldo_dinero")), 0.0, dtSaldoDin.Rows(0).Item("saldo_dinero"))
CalcSaldoDev:
                '   saldo_devengado = VacacionesDevengadas(Rj.Trim, FBaja)
                saldo_devengado = CalculoDAgDVacDPrVac(dtEmp.Rows(0).Item("alta"), FBaja, dtEmp.Rows(0).Item("cod_tipo"), dtEmp.Rows(0).Item("cod_comp"), 1)
                DiasVac = Math.Round(saldo_dinero + saldo_devengado, 2)
                txtDiasVac.Text = DiasVac.ToString
                Campo = "dias_vac"
                If (ActTblPers) Then sqlExecute("UPDATE personal SET " & Campo & " = '" & DiasVac & "' WHERE reloj = '" & Rj & "'")

                '******************Dias de prima vacacional
                Dim dias_prima_vac As Double = 0.0
                dias_prima_vac = CalculoDAgDVacDPrVac(dtEmp.Rows(0).Item("alta"), FBaja, dtEmp.Rows(0).Item("cod_tipo"), dtEmp.Rows(0).Item("cod_comp"), 2)
                txtDiasPrimaVac.Text = dias_prima_vac.ToString
                Campo = "dias_prima_vac"
                If (ActTblPers) Then sqlExecute("UPDATE personal SET " & Campo & " = '" & dias_prima_vac & "' WHERE reloj = '" & Rj & "'")


                '-----Días de Aguinaldo
                Dim dias_Aguinaldo As Double = 0.0
                dias_Aguinaldo = CalculoDAgDVacDPrVac(dtEmp.Rows(0).Item("alta"), FBaja, dtEmp.Rows(0).Item("cod_tipo"), dtEmp.Rows(0).Item("cod_comp"), 3)
                txtDiasAgui.Text = dias_Aguinaldo.ToString
                Campo = "dias_agui"
                If (ActTblPers) Then sqlExecute("UPDATE personal SET " & Campo & " = '" & dias_Aguinaldo & "' WHERE reloj = '" & Rj & "'")

                '************************AOS:: 06/08/2020  - Mandar esos días de agui, vac y privac a Miscelaneos, junto si es Finiquito o no
                If (ActTblPers) Then
                    Dim tipo_periodo As String = dtEmp.Rows(0).Item("tipo_periodo").ToString.Trim
                    EnvioMiscDatosBaja(Rj, tipo_periodo, FBaja, DiasVac, dias_prima_vac, dias_Aguinaldo, Usuario)
                End If

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCapturar_Click_1(sender As Object, e As EventArgs)

        txtTomar.Value = 1

        'txtPagar.Enabled = True
        txtTomar.Enabled = True
        txtFechaDe.Enabled = True
        cmbPeriodos.Enabled = True

        btnCapturar.Enabled = False
        btnAplicarVac.Enabled = True
        btnCancelarVac.Enabled = True
        txtPagar.Focus()
    End Sub

    Private Sub btnAplicarVac_Click_1(sender As Object, e As EventArgs)
        Dim _fecha As Date
        Dim _fecha_fin As Date
        Dim _fecha_ini As Date
        Dim rl As String = txtReloj.Text
        Dim _dinero As Double = 0
        Dim _tiempo As Double = 0
        Dim _ano As String = ""
        Dim _prima As Double = 0
        Dim _diasDinero As Double = txtPagar.Value
        Dim _diasTiempo As Double = txtTomar.Value

        Dim _diasDineroConvertidos As Double = _diasDinero
        Dim _diasTiempoConvertidos As Double = _diasTiempo

        Dim ClaveVA As String
        Dim x As Integer
        Dim AusVac As String = ""
        Dim InsertaVac As Boolean = True
        Dim Respuesta As DialogResult
        Dim _aus_natural As String = ""
        Dim _devengadas As Double = txtDevengadas.Text
        Dim _semana_captura As Boolean = False

        Dim _dd As Double
        Dim _dt As Double
        Dim _d As Double
        Dim _t As Double
        Dim _sd As Double
        Dim _st As Double

        Dim AnoPerVac As String

        '**** VACACIONES PARA SALDOS Y PAGOS *****
        dtTemp = sqlExecute("SELECT TOP 1 ano,prima,saldo_dinero, saldo_tiempo FROM saldos_vacaciones WHERE reloj = '" & rl & _
         "' ORDER BY fecha_captura DESC,fecha_fin DESC")
        If dtTemp.Rows.Count > 0 Then
            Try : _dinero = dtTemp.Rows.Item(0).Item("saldo_dinero") : Catch ex As Exception : _dinero = 0 : End Try
            Try : _tiempo = dtTemp.Rows.Item(0).Item("saldo_tiempo") : Catch ex As Exception : _tiempo = 0 : End Try
            Try : _ano = dtTemp.Rows.Item(0).Item("ano") : Catch ex As Exception : _ano = Date.Now.Year.ToString : End Try
            Try : _prima = dtTemp.Rows.Item(0).Item("prima") : Catch ex As Exception : _prima = 25 : End Try
        End If

        Try

            _fecha_ini = txtFechaDe.Value
            _fecha_fin = DateAdd(DateInterval.Day, CDbl(txtTomar.Value), _fecha_ini)

            '***** PROCESO PARA APLICAR VACACIONES EN AUSENTISMO *******
            dtTemp = sqlExecute("SELECT tipo_aus FROM tipo_ausentismo WHERE tipo_naturaleza = 'V'", "TA")
            If dtTemp.Rows.Count = 0 Then
                AusVac = "VAC"
            Else
                AusVac = dtTemp.Rows(0).Item("tipo_aus")
            End If

            'Revisar ausentismo default y tipo de pago para vacaciones
            dtTemp = sqlExecute("SELECT ausentismo,pago_vacaciones_semana_captura FROM parametros")
            If dtTemp.Rows.Count = 0 Then
                _aus_natural = "AUS"
            Else
                _aus_natural = IIf(IsDBNull(dtTemp.Rows(0).Item("ausentismo")), "AUS", dtTemp.Rows(0).Item("ausentismo")).ToString.Trim
                _semana_captura = IIf(IsDBNull(dtTemp.Rows(0).Item("pago_vacaciones_semana_captura")), False, dtTemp.Rows(0).Item("pago_vacaciones_semana_captura"))
            End If

            _fecha = _fecha_ini


            Dim dtperiodo_ajustesnom As New DataTable
            dtperiodo_ajustesnom.Columns.Add("ano")
            dtperiodo_ajustesnom.Columns.Add("periodo")
            dtperiodo_ajustesnom.Columns.Add("dias")
            dtperiodo_ajustesnom.PrimaryKey = New DataColumn() {dtperiodo_ajustesnom.Columns("ano"), dtperiodo_ajustesnom.Columns("periodo")}

            x = 1
            Do Until x > _diasTiempo
                If Not (Festivo(_fecha, rl) Or DiaDescanso(_fecha, rl)) Then
                    dtTemp = sqlExecute("SELECT TIPO_NATURALEZA,ausentismo.TIPO_AUS,NOMBRE FROM AUSENTISMO LEFT JOIN TIPO_AUSENTISMO ON ausentismo.TIPO_AUS = tipo_ausentismo.TIPO_AUS WHERE RELOJ = '" & rl & "' AND fecha = '" & FechaSQL(_fecha) & "'", "TA")
                    If dtTemp.Rows.Count > 0 Then
                        If dtTemp.Rows(0).Item("tipo_aus") = _aus_natural Then
                            sqlExecute("DELETE FROM ausentismo  WHERE RELOJ = '" & rl & "' AND fecha = '" & FechaSQL(_fecha) & "'", "TA")
                            InsertaVac = True
                        Else
                            Respuesta = MessageBox.Show("Existe ausentismo registrado para el día " & FechaMediaLetra(_fecha) & " (" & dtTemp.Rows(0).Item("nombre") & "). ¿Desea sobrescribirlo?", "Ausentismo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
                            If Respuesta = Windows.Forms.DialogResult.Yes Then
                                sqlExecute("DELETE FROM ausentismo  WHERE RELOJ = '" & rl & "' AND fecha = '" & FechaSQL(_fecha) & "'", "TA")
                                InsertaVac = True
                            ElseIf Respuesta = Windows.Forms.DialogResult.No Then
                                InsertaVac = False
                            Else
                                Exit Sub
                            End If
                        End If
                    End If

                    If InsertaVac Then
                        sqlExecute("INSERT INTO ausentismo (COD_COMP,RELOJ,FECHA,TIPO_AUS,PERIODO) VALUES ('" & _
                                   cmbCia.SelectedValue & "','" & _
                                   rl & "','" & _
                                   FechaSQL(_fecha) & "','" & _
                                   AusVac & "','" & _
                                   ObtenerPeriodo(_fecha) & "')", "TA")
                        _fecha_fin = _fecha
                        x = x + 1


                        Dim ano_pago As String = _fecha.Year
                        Dim periodo_pago As String = _fecha.Month.ToString.PadLeft(2, "0")

                        Dim dtFechaCorte As DataTable = sqlExecute("select * from periodos where ano = '" & ano_pago & "' and periodo = '" & periodo_pago & "' and fecha_fin <= '" & FechaSQL(Now.Date) & "' and isnull(periodo_especial, 0) = 0", "ta")
                        If dtFechaCorte.Rows.Count <= 0 Then
                            '  Dim dtSiguiente As DataTable = sqlExecute("select * from periodos where fecha_corte > '" & FechaSQL(Now.Date) & "' and isnull(periodo_especial, 0) = 0 order by ano, periodo", "ta")
                            Dim dtSiguiente As DataTable = sqlExecute("select * from periodos where fecha_fin > '" & FechaSQL(Now.Date) & "' and isnull(periodo_especial, 0) = 0 order by ano, periodo", "ta")
                            If dtSiguiente.Rows.Count > 0 Then
                                ano_pago = dtSiguiente.Rows(0)("ano")
                                periodo_pago = dtSiguiente.Rows(0)("periodo")
                            Else
                                MessageBox.Show("Es necesario dar de alta los periodos de pago faltantes, si recibe este mensaje por favor contacte a PIDA", "Faltan periodos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If

                        Dim drPeriodoPago As DataRow = dtperiodo_ajustesnom.Rows.Find({ano_pago, periodo_pago})
                        If drPeriodoPago Is Nothing Then
                            drPeriodoPago = dtperiodo_ajustesnom.NewRow
                            drPeriodoPago("ano") = ano_pago
                            drPeriodoPago("periodo") = periodo_pago
                            drPeriodoPago("dias") = 0
                            dtperiodo_ajustesnom.Rows.Add(drPeriodoPago)
                        End If

                        Dim dias_ As Integer = drPeriodoPago("dias")
                        drPeriodoPago("dias") = dias_ + 1

                    End If

                End If
                _fecha = _fecha.AddDays(1)
                InsertaVac = True
            Loop



            '**** VACACIONES PARA SALDOS Y PAGOS *****
            dtTemp = sqlExecute("SELECT TOP 1 ano,prima,saldo_dinero, saldo_tiempo FROM saldos_vacaciones WHERE reloj = '" & rl & _
             "' ORDER BY fecha_captura DESC,fecha_fin DESC")
            If dtTemp.Rows.Count > 0 Then
                Try : _dinero = dtTemp.Rows.Item(0).Item("saldo_dinero") : Catch ex As Exception : _dinero = 0 : End Try
                Try : _tiempo = dtTemp.Rows.Item(0).Item("saldo_tiempo") : Catch ex As Exception : _tiempo = 0 : End Try
                Try : _ano = dtTemp.Rows.Item(0).Item("ano") : Catch ex As Exception : _ano = Date.Now.Year.ToString : End Try
                Try : _prima = dtTemp.Rows.Item(0).Item("prima") : Catch ex As Exception : _prima = 25 : End Try
            End If



            dtTemp = sqlExecute("SELECT misce_clave FROM conceptos WHERE concepto = 'DIASVA'", "Nomina")
            If dtTemp.Rows.Count > 0 Then
                ClaveVA = dtTemp.Rows.Item(0).Item("misce_clave")
            Else
                ClaveVA = ""
            End If

            _dinero = _dinero - _diasDineroConvertidos
            _tiempo = _tiempo - _diasTiempoConvertidos

            sqlExecute("INSERT INTO saldos_vacaciones (reloj,ano,prima,saldo_dinero,saldo_tiempo,dinero,tiempo,comentario," & _
                       "fecha_ini,fecha_fin,fecha_captura) VALUES ('" & _
                       rl & "','" & _
                       _fecha.Year & "'," & _
                       _prima & "," & _
                       _dinero & "," & _
                       _tiempo & "," & _
                       _diasDineroConvertidos & "," & _
                       _diasTiempoConvertidos & _
                       ",'VACACIONES','" & _
                       FechaSQL(_fecha_ini) & "','" & _
                       FechaSQL(_fecha_fin) & "','" & _
                       FechaHoraSQL(Now) & "')")

            '**** PROCESO PARA APLICAR VACACIONES EN MISCELANEOS DE NOMINA ******* 

            For Each row As DataRow In dtperiodo_ajustesnom.Rows
                sqlExecute("INSERT INTO ajustes_nom (reloj,ano,periodo,per_ded,clave,monto,comentario,concepto,usuario,fecha) VALUES ('" & _
                           rl & "','" & _
                           row("ano") & "','" & _
                           row("periodo") & "','P','" & _
                           ClaveVA & "'," & _
                           row("dias") & _
                           ",'Días de vacaciones capturados desde MAESTRO','DIASVA','" & Usuario & "', GETDATE())", "Nomina")
            Next


            '*********************************************************************

            RefrescaVacaciones(rl)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCancelarVac_Click_1(sender As Object, e As EventArgs)
        txtPagar.Text = 0
        txtTomar.Text = 0
        btnCapturar.Enabled = Not EsBaja
        btnAplicarVac.Enabled = False
        btnCancelarVac.Enabled = False

        txtPagar.Enabled = False
        txtTomar.Enabled = False
        txtFechaDe.Enabled = False
        cmbPeriodos.Enabled = False
        cmbPeriodos.SelectedIndex = -1
    End Sub

    Private Sub btnBorrarVac_Click_1(sender As Object, e As EventArgs)
        Dim idx As Integer
        Dim Aniv As Boolean = False
        Dim rl As String
        Dim FechaCaptura As Date
        Dim FechaEnvio As Date
        Dim Ano As String
        Dim BorrarVacaciones As Boolean = True
        Dim ClaveVA As String
        Dim _dinero As Double
        Dim _tiempo As Double

        Dim _saldo_dinero As Double
        Dim _saldo_tiempo As Double
        Dim _fecha_ini As Date
        Dim _fecha_fin As Date
        Dim _prima As Double
        Dim _fecha As Date
        Dim _dias As Double

        Try
            idx = 0
            Aniv = IIf(IsDBNull(dgVacaciones.Item("colAniversario", idx).Value), 0, dgVacaciones.Item("colAniversario", idx).Value) = 1

            If Aniv Then
                MessageBox.Show("No es posible borrar las vacaciones asignadas por aniversario.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            rl = txtReloj.Text.Trim
            FechaCaptura = dgVacaciones.Item("colFechaCaptura", idx).Value
            Ano = dgVacaciones.Item("colAno", idx).Value
            _dias = dgVacaciones.Item("colTomadosDinero", idx).Value
            dtTemp = sqlExecute("SELECT envio_date FROM ajustes_nom WHERE ano = '" & Ano & "' AND reloj = '" & rl & _
                                "' AND concepto = 'DIASVA' AND fecha = '" & FechaSQL(FechaCaptura) & "' AND monto = " & _dias & _
                                " ORDER BY envio_date", "nomina")
            If dtTemp.Rows.Count > 0 Then
                FechaEnvio = IIf(IsDBNull(dtTemp.Rows(0).Item("envio_date")), Nothing, dtTemp.Rows(0).Item("envio_date"))
                If Not FechaEnvio = Nothing Then
                    If DateDiff(DateInterval.Day, FechaEnvio, Now) > 3 Then
                        MessageBox.Show("Este registro de vacaciones fue enviado a pago, por lo que ya no puede ser modificado.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    Else
                        If MessageBox.Show("Ya se envió a nómina el registro de estas vacaciones." & vbCrLf & "¿Está seguro de querer continuar?", "PIDA", _
                                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                            Exit Sub
                        Else
                            BorrarVacaciones = False
                        End If
                    End If
                ElseIf MessageBox.Show("¿Está seguro de querer borrar el registro de " & _dias & IIf(_dias = 1, " día", " días") & " de vacaciones?", "Borrar vacaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            ElseIf MessageBox.Show("¿Está seguro de querer borrar el registro de " & _dias & IIf(_dias = 1, " día", " días") & " de vacaciones?", "Borrar vacaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            dtTemp = sqlExecute("SELECT * FROM saldos_vacaciones WHERE " & _
                    "RELOJ = '" & rl & "' AND ano = '" & Ano & "' AND fecha_captura = '" & FechaHoraSQL(FechaCaptura) & "'")
            _dinero = dtTemp.Rows(0).Item("dinero")
            _tiempo = dtTemp.Rows(0).Item("tiempo")
            _saldo_dinero = dtTemp.Rows(0).Item("saldo_dinero")
            _saldo_tiempo = dtTemp.Rows(0).Item("saldo_tiempo")
            _prima = dtTemp.Rows(0).Item("prima")
            _fecha_ini = dtTemp.Rows(0).Item("fecha_ini")
            _fecha_fin = dtTemp.Rows(0).Item("fecha_fin")


            If BorrarVacaciones Then
                sqlExecute("DELETE FROM saldos_vacaciones WHERE " & _
                         "RELOJ = '" & rl & "' AND ano = '" & Ano & "' AND fecha_captura = '" & FechaHoraSQL(FechaCaptura) & "'")
                sqlExecute("DELETE TOP (1) FROM ajustes_nom WHERE " & _
                           "RELOJ = '" & rl & "' AND ano = '" & Ano & "' AND concepto = 'DIASVA' AND fecha = '" & _
                           FechaSQL(FechaCaptura) & "' AND monto = " & _dias & " AND periodo = (SELECT MAX(Periodo) FROM ajustes_nom WHERE " & _
                           "RELOJ = '" & rl & "' AND ano = '" & Ano & "' AND concepto = 'DIASVA' AND fecha = '" & _
                           FechaSQL(FechaCaptura) & "' AND monto = " & _dias & ")", "nomina")
            Else
                sqlExecute("INSERT INTO saldos_vacaciones (reloj,ano,prima,saldo_dinero,saldo_tiempo,dinero,tiempo,comentario," & _
                           "fecha_ini,fecha_fin,fecha_captura) VALUES ('" & _
                           rl & "','" & _
                           Ano & "'," & _
                           _prima & "," & _
                           _saldo_dinero + _dinero & "," & _
                           _saldo_tiempo + _tiempo & "," & _
                           -_dinero & "," & _
                           -_tiempo & _
                           ",'CANCELAR VACACIONES CAPTURADAS EL DIA " & FechaCaptura & "','" & _
                           FechaSQL(_fecha_ini) & "','" & _
                           FechaSQL(_fecha_fin) & "','" & _
                           FechaHoraSQL(Now) & "')")

                dtTemp = sqlExecute("SELECT misce_clave FROM conceptos WHERE concepto = 'DIASVA'", "NOMINA")
                If dtTemp.Rows.Count > 0 Then
                    ClaveVA = dtTemp.Rows.Item(0).Item("misce_clave")
                Else
                    ClaveVA = ""
                End If

                Ano = ObtenerAnoPeriodo(FechaCaptura)
                Periodo = Ano.Substring(4, 2)
                Ano = Ano.Substring(0, 4)

                sqlExecute("INSERT INTO ajustes_nom (reloj,ano,periodo,per_ded,clave,monto,envio_nom,envio_date,envio_usu,comentario,concepto,usuario,fecha) VALUES ('" & _
                          rl & "','" & _
                          Ano & "','" & _
                          Periodo & "','P','" & _
                          ClaveVA & "'," & _
                          -_dinero & _
                          ",1," & _
                          "'" & FechaSQL(Now) & "'," & _
                          "'" & Usuario & "'," & _
                          "'Días de vacaciones CANCELADOS desde MAESTRO','DIASVA','" & Usuario & "', GETDATE())", "Nomina")
                MessageBox.Show("Es necesario avisar directamente a la persona responsable del cálculo de nómina sobre esta cancelación " & _
                                "posterior al envío de información.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            Dim AusVac As String

            '***** PROCESO PARA ELIMINAR VACACIONES EN AUSENTISMO *******
            dtTemp = sqlExecute("SELECT tipo_aus FROM tipo_ausentismo WHERE tipo_naturaleza = 'V'", "TA")
            If dtTemp.Rows.Count = 0 Then
                AusVac = "VAC"
            Else
                AusVac = dtTemp.Rows(0).Item("tipo_aus")
            End If

            _fecha = _fecha_ini
            Do Until _fecha > _fecha_fin
                sqlExecute("DELETE FROM ausentismo WHERE reloj = '" & Reloj & "' AND fecha = '" & FechaSQL(_fecha) & _
                           "' AND tipo_aus = '" & AusVac & "'", "TA")
                _fecha = DateAdd(DateInterval.Day, 1, _fecha)
            Loop
            '**************************************
            RefrescaVacaciones(rl)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("El registro de vacaciones no pudo ser borrado. Si el problema persiste, consulte al administrador del sistema." & _
                            vbCrLf & vbCrLf & "Err.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCapturar_Click_2(sender As Object, e As EventArgs) Handles btnCapturar.Click

        txtTomar.Value = 1

        'txtPagar.Enabled = True
        txtTomar.Enabled = True
        txtFechaDe.Enabled = True
        cmbPeriodos.Enabled = True
        CargarPeriodos() ' Cargar los periodos al cmbPeriodos para pago de nómina

        btnCapturar.Enabled = False
        btnAplicarVac.Enabled = True
        btnCancelarVac.Enabled = True
        txtPagar.Focus()
    End Sub
    '--AOS Aqui es donde inserta las vacaciones en ausentismo, ajustes_nom y saldos_vacaciones
    Private Sub btnAplicarVac_Click_2(sender As Object, e As EventArgs) Handles btnAplicarVac.Click
        Dim _fecha As Date
        Dim _fecha_fin As Date
        Dim _fecha_ini As Date
        Dim rl As String = txtReloj.Text
        Dim _dinero As Double = 0
        Dim _tiempo As Double = 0
        Dim _ano As String = ""
        Dim _prima As Double = 0
        Dim _diasDinero As Double = txtPagar.Value
        Dim _diasTiempo As Double = txtTomar.Value

        Dim _diasDineroConvertidos As Double = _diasDinero
        Dim _diasTiempoConvertidos As Double = _diasTiempo

        Dim ClaveVA As String
        Dim x As Integer
        Dim AusVac As String = ""
        Dim InsertaVac As Boolean = True
        Dim insertaDetalleAus As Boolean = False
        Dim Respuesta As DialogResult
        Dim _aus_natural As String = ""
        Dim _devengadas As Double = txtDevengadas.Text
        Dim _semana_captura As Boolean = False

        Dim _dd As Double
        Dim _dt As Double
        Dim _d As Double
        Dim _t As Double
        Dim _sd As Double
        Dim _st As Double

        Dim AnoPerVac As String

        '----2024-05-15: VALIDAR que el periodo seleccionado no esté ya como pagado
        seleccionado = cmbPeriodos.SelectedValue
        Dim _anoPagaNom As String = "", _perPagaNom As String = ""
        If seleccionado.ToString.Trim <> "" Then
            _anoPagaNom = seleccionado.Substring(0, 4)
            _perPagaNom = seleccionado.Substring(4, 2)
            Dim dtNomPag As DataTable = sqlExecute("select TOP 1 * from NOMINA.dbo.nomina where ano+periodo='" & _anoPagaNom & _perPagaNom & "'", "NOMINA")
            If Not dtNomPag.Columns.Contains("Error") And dtNomPag.Rows.Count > 0 Then
                MessageBox.Show("El periodo seleccionado para pago de nómina ya se encuentra cerrado y pagado, favor de seleccionar otro", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If
    

        '**** VACACIONES PARA SALDOS Y PAGOS *****
        dtTemp = sqlExecute("SELECT TOP 1 ano,prima,saldo_dinero, saldo_tiempo FROM saldos_vacaciones WHERE reloj = '" & rl & _
         "' ORDER BY fecha_captura DESC,fecha_fin DESC")
        If dtTemp.Rows.Count > 0 Then
            Try : _dinero = dtTemp.Rows.Item(0).Item("saldo_dinero") : Catch ex As Exception : _dinero = 0 : End Try
            Try : _tiempo = dtTemp.Rows.Item(0).Item("saldo_tiempo") : Catch ex As Exception : _tiempo = 0 : End Try
            Try : _ano = dtTemp.Rows.Item(0).Item("ano") : Catch ex As Exception : _ano = "2000" : End Try
            Try : _prima = dtTemp.Rows.Item(0).Item("prima") : Catch ex As Exception : _prima = 25 : End Try
        End If

        Try

            _fecha_ini = txtFechaDe.Value
            _fecha_fin = DateAdd(DateInterval.Day, CDbl(txtTomar.Value), _fecha_ini)

            '----AO: 2023-11-28: Validar que en las fechas seleccionadas, no haya ya días capturados en saldos_vacaciones
            Dim dtVacExiste As New DataTable

            Do While _fecha_fin > _fecha_ini
                dtVacExiste = sqlExecute("select * from saldos_vacaciones where reloj='" & rl & "' and COMENTARIO like '%VACACI%'  and FECHA_INI<='" & FechaSQL(_fecha_ini) & "' and FECHA_FIN>='" & FechaSQL(_fecha_ini) & "'", "PERSONAL")

                If dtVacExiste.rows.count > 0 Then
                    MessageBox.Show("Ya existe vacaciones capturados en la fecha:" & FechaSQL(_fecha_ini) & " , favor de agregar otro rango de fechas", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    InsertaVac = False
                    Exit Sub
                End If
                _fecha_ini = DateAdd(DateInterval.Day, 1, _fecha_ini)
            Loop
            _fecha_ini = txtFechaDe.Value
            '-----End validar fechas seleccionadas

            '***** PROCESO PARA APLICAR VACACIONES EN AUSENTISMO *******
            dtTemp = sqlExecute("SELECT tipo_aus FROM tipo_ausentismo WHERE tipo_naturaleza = 'V'", "TA")
            If dtTemp.Rows.Count = 0 Then
                AusVac = "VAC"
            Else
                AusVac = dtTemp.Rows(0).Item("tipo_aus")
            End If

            'Revisar ausentismo default y tipo de pago para vacaciones
            dtTemp = sqlExecute("SELECT ausentismo,pago_vacaciones_semana_captura FROM parametros")
            If dtTemp.Rows.Count = 0 Then
                _aus_natural = "AUS"
            Else
                _aus_natural = IIf(IsDBNull(dtTemp.Rows(0).Item("ausentismo")), "AUS", dtTemp.Rows(0).Item("ausentismo")).ToString.Trim
                _semana_captura = IIf(IsDBNull(dtTemp.Rows(0).Item("pago_vacaciones_semana_captura")), False, dtTemp.Rows(0).Item("pago_vacaciones_semana_captura"))
            End If

            _fecha = _fecha_ini


            Dim dtperiodo_ajustesnom As New DataTable
            dtperiodo_ajustesnom.Columns.Add("ano")
            dtperiodo_ajustesnom.Columns.Add("periodo")
            dtperiodo_ajustesnom.Columns.Add("dias")
            dtperiodo_ajustesnom.PrimaryKey = New DataColumn() {dtperiodo_ajustesnom.Columns("ano"), dtperiodo_ajustesnom.Columns("periodo")}

            x = 1
            Do Until x > _diasTiempo
                If Not (Festivo(_fecha, rl) Or DiaDescanso(_fecha, rl)) Then
                    dtTemp = sqlExecute("SELECT TIPO_NATURALEZA,ausentismo.TIPO_AUS,NOMBRE FROM AUSENTISMO LEFT JOIN TIPO_AUSENTISMO ON ausentismo.TIPO_AUS = tipo_ausentismo.TIPO_AUS WHERE RELOJ = '" & rl & "' AND fecha = '" & FechaSQL(_fecha) & "'", "TA")
                    If dtTemp.Rows.Count > 0 Then
                        Dim _tipo_aus As String = "", _fecha_hoy As Date = Now()
                        Try : _tipo_aus = dtTemp.Rows(0).Item("tipo_aus").ToString.Trim : Catch ex As Exception : _tipo_aus = "" : End Try


                        If dtTemp.Rows(0).Item("tipo_aus") = _aus_natural Then
                            sqlExecute("DELETE FROM ausentismo  WHERE RELOJ = '" & rl & "' AND fecha = '" & FechaSQL(_fecha) & "'", "TA")
                            InsertaVac = True

                            '==CTE: AO: Validar si es tipo FI, y si la fecha en la que se va a cambiar por vacación, es menor al día en que se está capturando, si insertar que se cambió FI por VAC para el reporte
                            If _tipo_aus = "FI" Then
                                If _fecha.ToShortDateString() < _fecha_hoy.ToShortDateString() Then insertaDetalleAus = True
                            End If

                        Else
                            Respuesta = MessageBox.Show("Existe ausentismo registrado para el día " & FechaMediaLetra(_fecha) & " (" & dtTemp.Rows(0).Item("nombre") & "). ¿Desea sobrescribirlo?", "Ausentismo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)
                            If Respuesta = Windows.Forms.DialogResult.Yes Then
                                sqlExecute("DELETE FROM ausentismo  WHERE RELOJ = '" & rl & "' AND fecha = '" & FechaSQL(_fecha) & "'", "TA")
                                InsertaVac = True

                                '==CTE: AO: Validar si es tipo FI, y si la fecha en la que se va a cambiar por vacación, es menor al día en que se está capturando, si insertar que se cambió FI por VAC para el reporte
                                If _tipo_aus = "FI" Then
                                    If _fecha.ToShortDateString() < _fecha_hoy.ToShortDateString() Then insertaDetalleAus = True
                                End If

                            ElseIf Respuesta = Windows.Forms.DialogResult.No Then
                                InsertaVac = False
                            Else
                                Exit Sub
                            End If
                        End If
                    End If

                    '--HERE INSERTA EL AUS - AOS
                    If InsertaVac Then

                        '--- AO 2023-12-15: Agregar usuario y fecha hora de registro
                        '===Agregar detalle aus como FI si aneriormente era FI y se cambió por VAC
                        Dim _detalle_aus As String = ""
                        If insertaDetalleAus Then _detalle_aus = "FI"
                        sqlExecute("INSERT INTO ausentismo (COD_COMP,RELOJ,FECHA,TIPO_AUS,PERIODO,USUARIO,FECHA_HORA,DETALLE_AUS) VALUES ('" & _
                  cmbCia.SelectedValue & "','" & _
                  rl & "','" & _
                  FechaSQL(_fecha) & "','" & _
                  AusVac & "','" & _
                  ObtenerPeriodo(_fecha) & "','" & Usuario & "',getdate(),'" & _detalle_aus & "')", "TA")


                        _fecha_fin = _fecha
                        x = x + 1


                        Dim ano_pago As String = _fecha.Year
                        Dim periodo_pago As String = _fecha.Month.ToString.PadLeft(2, "0")

                        Dim dtFechaCorte As DataTable = sqlExecute("select * from periodos where ano = '" & ano_pago & "' and periodo = '" & periodo_pago & "' and fecha_fin <= '" & FechaSQL(Now.Date) & "' and isnull(periodo_especial, 0) = 0", "ta")
                        If dtFechaCorte.Rows.Count <= 0 Then
                            Dim dtSiguiente As DataTable = sqlExecute("select * from periodos where fecha_fin > '" & FechaSQL(Now.Date) & "' and isnull(periodo_especial, 0) = 0 order by ano, periodo", "ta")
                            If dtSiguiente.Rows.Count > 0 Then
                                ano_pago = dtSiguiente.Rows(0)("ano")
                                periodo_pago = dtSiguiente.Rows(0)("periodo")
                            Else
                                MessageBox.Show("Es necesario dar de alta los periodos de pago faltantes, si recibe este mensaje por favor contacte a PIDA", "Faltan periodos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If

                        Dim drPeriodoPago As DataRow = dtperiodo_ajustesnom.Rows.Find({ano_pago, periodo_pago})
                        If drPeriodoPago Is Nothing Then
                            drPeriodoPago = dtperiodo_ajustesnom.NewRow
                            drPeriodoPago("ano") = ano_pago
                            drPeriodoPago("periodo") = periodo_pago
                            drPeriodoPago("dias") = 0
                            dtperiodo_ajustesnom.Rows.Add(drPeriodoPago)
                        End If

                        Dim dias_ As Integer = drPeriodoPago("dias")
                        drPeriodoPago("dias") = dias_ + 1

                    End If

                End If
                _fecha = _fecha.AddDays(1)
                InsertaVac = True
            Loop

            '===Hacer lo mismo para Miscelaneos (Ajustes_nom), registrar por día
            _fecha = _fecha_ini
            x = 1
            Do Until x > _diasTiempo
                If Not (Festivo(_fecha, rl) Or DiaDescanso(_fecha, rl)) Then

                    dtTemp = sqlExecute("select * from nomina.dbo.ajustes_nom  where reloj='" & rl & "'  and CONCEPTO='DIASVA' and fecha='" & FechaSQL(_fecha) & "'", "NOMINA")
                    If dtTemp.Rows.Count > 0 Then
                        sqlExecute("DELETE FROM nomina.dbo.ajustes_nom  WHERE RELOJ = '" & rl & "' and CONCEPTO='DIASVA' AND fecha = '" & FechaSQL(_fecha) & "'", "NOMINA")
                    End If

                    '====Insertar en Miscelaneos detalle x dia
                    Dim _diasPag_ As Double = 1.0, _comentario_ As String = "Días de vacaciones capturados desde MAESTRO"
                    ProcInsDiasVaAjNom(rl, _diasPag_, FechaSQL(_fecha), FechaSQL(_fecha), cmbTipoPeriodo.SelectedValue, seleccionado, _comentario_, _fecha_ini, _fecha_fin)

                    x = x + 1
                End If

                _fecha = _fecha.AddDays(1)
            Loop



            '**** VACACIONES PARA SALDOS Y PAGOS *****
            dtTemp = sqlExecute("SELECT TOP 1 ano,prima,saldo_dinero, saldo_tiempo FROM saldos_vacaciones WHERE reloj = '" & rl & _
             "' ORDER BY fecha_captura DESC,fecha_fin DESC")
            If dtTemp.Rows.Count > 0 Then
                Try : _dinero = dtTemp.Rows.Item(0).Item("saldo_dinero") : Catch ex As Exception : _dinero = 0 : End Try
                Try : _tiempo = dtTemp.Rows.Item(0).Item("saldo_tiempo") : Catch ex As Exception : _tiempo = 0 : End Try
                Try : _ano = dtTemp.Rows.Item(0).Item("ano") : Catch ex As Exception : _ano = Date.Now.Year.ToString : End Try
                Try : _prima = dtTemp.Rows.Item(0).Item("prima") : Catch ex As Exception : _prima = 25 : End Try
            End If



            dtTemp = sqlExecute("SELECT misce_clave FROM conceptos WHERE concepto = 'DIASVA'", "Nomina")
            If dtTemp.Rows.Count > 0 Then
                ClaveVA = dtTemp.Rows.Item(0).Item("misce_clave")
            Else
                ClaveVA = ""
            End If

            _dinero = _dinero - _diasDineroConvertidos
            _tiempo = _tiempo - _diasTiempoConvertidos

            '--- AO 2023-12: Registrar el usuairo que las está ingresando
            Dim comentario As String = "VACACIONES"
            sqlExecute("INSERT INTO saldos_vacaciones (reloj,ano,prima,saldo_dinero,saldo_tiempo,dinero,tiempo,comentario," & _
                       "fecha_ini,fecha_fin,fecha_captura) VALUES ('" & _
                       rl & "','" & _
                       _fecha.Year & "'," & _
                       _prima & "," & _
                       _dinero & "," & _
                       _tiempo & "," & _
                       _diasDineroConvertidos & "," & _
                       _diasTiempoConvertidos & _
                       ",'" & comentario & "','" & _
                       FechaSQL(_fecha_ini) & "','" & _
                       FechaSQL(_fecha_fin) & "','" & _
                       FechaHoraSQL(Now) & "')")

            '---AO 2023-12: Registrar en bitacora_vacaciones para tener mayor detalle:
            Dim Q As String = ""
            Q = "insert into bitacora_vacaciones (RELOJ,FECHA_INI,FECHA_FIN,COMENTARIO,USUARIO,FECHA_CAPTURA) VALUES" & _
                "('" & rl & "','" & FechaSQL(_fecha_ini) & "','" & FechaSQL(_fecha_fin) & "','AGREGADO DESDE MTRO_EMPLEADOS','" & Usuario & "',GETDATE())"
            sqlExecute(Q, "PERSONAL")

            '**** PROCESO PARA APLICAR VACACIONES EN MISCELANEOS DE NOMINA ******* 
            '--- AOS: Proceso nuevo que evalua dia a dia e inserta de acuerdo a las fechas ini y fin en ajustes_nom (Miscelaneos), ya que puede abarcar uno o mas periodos
            '--- NOTA: Para los 14nales igual lo registra en periodo semanal en ajustes_nom
            Dim diasPag As Double = 0.0
            Try : diasPag = txtPagar.Value : Catch ex As Exception : diasPag = 0.0 : End Try

            '==Periodo del empleado     junio2021       Ernesto
            tipo_per = cmbTipoPeriodo.SelectedValue


            '=== Proceso Original Anterior donde registra por fechas
            'ProcInsDiasVaAjNom(rl, diasPag, _fecha_ini, _fecha_fin, cmbTipoPeriodo.SelectedValue, seleccionado)

            '===2024-12-09:: Proceso para registrar en miscelaneos (ajustes_nom) un dia por vacación
            'Dim f_dia As Date = Date.Parse(_fecha_ini)

            'Do While f_dia <= Date.Parse(_fecha_fin)
            '    _fecha_ini = f_dia
            '    ProcInsDiasVaAjNom(rl, diasPag, _fecha_ini, _fecha_ini, cmbTipoPeriodo.SelectedValue, seleccionado)
            '    f_dia = f_dia.AddDays(1)
            'Loop


            '*********************************************************************

            RefrescaVacaciones(rl)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnCancelarVac_Click_2(sender As Object, e As EventArgs) Handles btnCancelarVac.Click
        txtPagar.Text = 0
        txtTomar.Text = 0
        btnCapturar.Enabled = Not EsBaja
        btnAplicarVac.Enabled = False
        btnCancelarVac.Enabled = False

        txtPagar.Enabled = False
        txtTomar.Enabled = False
        txtFechaDe.Enabled = False
        cmbPeriodos.Enabled = False
        cmbPeriodos.SelectedIndex = -1
    End Sub

    '-- AOS - Aqui es donde borra las vacaciones
    Private Sub btnBorrarVac_Click_2(sender As Object, e As EventArgs) Handles btnBorrarVac.Click
        Dim idx As Integer
        Dim Aniv As Boolean = False
        Dim rl As String
        Dim FechaCaptura As Date
        Dim FechaEnvio As Date
        Dim Ano As String
        Dim BorrarVacaciones As Boolean = True
        Dim ClaveVA As String
        Dim _dinero As Double
        Dim _tiempo As Double

        Dim _saldo_dinero As Double
        Dim _saldo_tiempo As Double
        Dim _fecha_ini As Date
        Dim _fecha_fin As Date
        Dim _prima As Double
        Dim _fecha As Date
        Dim _dias As Double

        Try
            idx = 0
            Aniv = IIf(IsDBNull(dgVacaciones.Item("colAniversario", idx).Value), 0, dgVacaciones.Item("colAniversario", idx).Value) = 1

            If Aniv Then
                MessageBox.Show("No es posible borrar las vacaciones asignadas por aniversario.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            rl = txtReloj.Text.Trim
            FechaCaptura = dgVacaciones.Item("colFechaCaptura", idx).Value
            Ano = dgVacaciones.Item("colAno", idx).Value
            _dias = dgVacaciones.Item("colTomadosDinero", idx).Value
            dtTemp = sqlExecute("SELECT envio_date FROM ajustes_nom WHERE ano = '" & Ano & "' AND reloj = '" & rl & _
                                "' AND concepto = 'DIASVA' AND fecha = '" & FechaSQL(FechaCaptura) & "' AND monto = " & _dias & _
                                " ORDER BY envio_date", "nomina")
            If dtTemp.Rows.Count > 0 Then
                FechaEnvio = IIf(IsDBNull(dtTemp.Rows(0).Item("envio_date")), Nothing, dtTemp.Rows(0).Item("envio_date"))
                If Not FechaEnvio = Nothing Then
                    If DateDiff(DateInterval.Day, FechaEnvio, Now) > 3 Then
                        MessageBox.Show("Este registro de vacaciones fue enviado a pago, por lo que ya no puede ser modificado.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    Else
                        If MessageBox.Show("Ya se envió a nómina el registro de estas vacaciones." & vbCrLf & "¿Está seguro de querer continuar?", "PIDA", _
                                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.No Then
                            Exit Sub
                        Else
                            BorrarVacaciones = False
                        End If
                    End If
                ElseIf MessageBox.Show("¿Está seguro de querer borrar el registro de " & _dias & IIf(_dias = 1, " día", " días") & " de vacaciones?", "Borrar vacaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                    Exit Sub
                End If
            ElseIf MessageBox.Show("¿Está seguro de querer borrar el registro de " & _dias & IIf(_dias = 1, " día", " días") & " de vacaciones?", "Borrar vacaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If

            dtTemp = sqlExecute("SELECT * FROM saldos_vacaciones WHERE " & _
                    "RELOJ = '" & rl & "' AND ano = '" & Ano & "' AND fecha_captura = '" & FechaHoraSQL(FechaCaptura) & "'")
            _dinero = dtTemp.Rows(0).Item("dinero")
            _tiempo = dtTemp.Rows(0).Item("tiempo")
            _saldo_dinero = dtTemp.Rows(0).Item("saldo_dinero")
            _saldo_tiempo = dtTemp.Rows(0).Item("saldo_tiempo")
            _prima = dtTemp.Rows(0).Item("prima")
            _fecha_ini = dtTemp.Rows(0).Item("fecha_ini")
            _fecha_fin = dtTemp.Rows(0).Item("fecha_fin")

            '---Se agregó la fecha de inicio y fin de las vacaciones en el campo de ajustes_nom llamado "numcredito con fines informativos      30/ene/21   Ernesto
            Dim cadenaVac As String
            cadenaVac = FechaSQL(_fecha_ini) & " al " & FechaSQL(_fecha_fin)

            '----AOS: Borrar vacs capturadas de Saldos_vacaciones, ausentismo y ajustes_nom (Miscelaneos)

            Dim QBorrarSalVac As String = "DELETE FROM saldos_vacaciones WHERE " & _
                         "RELOJ = '" & rl & "' AND ano = '" & Ano & "' AND fecha_captura = '" & FechaHoraSQL(FechaCaptura) & "'"

            Dim QBorrarAus As String = "Delete from TA.dbo.ausentismo where reloj='" & rl & "' and tipo_aus='VAC' and cod_comp='" & cmbCia.SelectedValue & "' and periodo=(SELECT MAX(Periodo) FROM NOMINA.dbo.ajustes_nom WHERE " & _
    "RELOJ = '" & rl & "' AND ano = '" & Ano & "' AND concepto = 'DIASVA' AND fecha = '" & _
    FechaSQL(FechaCaptura) & "' AND monto = " & _dias & ")"

            '---Modif.   30/ene/21     Ernesto
            Dim QBorrarMisc As String = "DELETE TOP (1) FROM ajustes_nom WHERE " & _
                           "RELOJ = '" & rl & "' AND ano = '" & Ano & "' AND concepto = 'DIASVA' AND fecha = '" & _
                           FechaSQL(FechaCaptura) & "' AND monto = " & _dias & " AND numcredito='" & cadenaVac & "' AND periodo = (SELECT MAX(Periodo) FROM ajustes_nom WHERE " & _
                           "RELOJ = '" & rl & "' AND ano = '" & Ano & "' AND concepto = 'DIASVA' AND fecha = '" & _
                           FechaSQL(FechaCaptura) & "' AND monto = " & _dias & ")"

            If BorrarVacaciones Then
                sqlExecute(QBorrarSalVac)
                sqlExecute(QBorrarAus, "TA")
                sqlExecute(QBorrarMisc, "nomina")
            Else
                sqlExecute("INSERT INTO saldos_vacaciones (reloj,ano,prima,saldo_dinero,saldo_tiempo,dinero,tiempo,comentario," & _
                           "fecha_ini,fecha_fin,fecha_captura) VALUES ('" & _
                           rl & "','" & _
                           Ano & "'," & _
                           _prima & "," & _
                           _saldo_dinero + _dinero & "," & _
                           _saldo_tiempo + _tiempo & "," & _
                           -_dinero & "," & _
                           -_tiempo & _
                           ",'CANCELAR VACACIONES CAPTURADAS EL DIA " & FechaCaptura & "','" & _
                           FechaSQL(_fecha_ini) & "','" & _
                           FechaSQL(_fecha_fin) & "','" & _
                           FechaHoraSQL(Now) & "')")

                dtTemp = sqlExecute("SELECT misce_clave FROM conceptos WHERE concepto = 'DIASVA'", "NOMINA")
                If dtTemp.Rows.Count > 0 Then
                    ClaveVA = dtTemp.Rows.Item(0).Item("misce_clave")
                Else
                    ClaveVA = ""
                End If

                Ano = ObtenerAnoPeriodo(FechaCaptura)
                Periodo = Ano.Substring(4, 2)
                Ano = Ano.Substring(0, 4)

                sqlExecute("INSERT INTO ajustes_nom (reloj,ano,periodo,per_ded,clave,monto,envio_nom,envio_date,envio_usu,comentario,concepto,usuario,fecha) VALUES ('" & _
                          rl & "','" & _
                          Ano & "','" & _
                          Periodo & "','P','" & _
                          ClaveVA & "'," & _
                          -_dinero & _
                          ",1," & _
                          "'" & FechaSQL(Now) & "'," & _
                          "'" & Usuario & "'," & _
                          "'Días de vacaciones CANCELADOS desde MAESTRO','DIASVA','" & Usuario & "', GETDATE())", "Nomina")
                MessageBox.Show("Es necesario avisar directamente a la persona responsable del cálculo de nómina sobre esta cancelación " & _
                                "posterior al envío de información.", "PIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            Dim AusVac As String

            '***** PROCESO PARA ELIMINAR VACACIONES EN AUSENTISMO *******
            dtTemp = sqlExecute("SELECT tipo_aus FROM tipo_ausentismo WHERE tipo_naturaleza = 'V'", "TA")
            If dtTemp.Rows.Count = 0 Then
                AusVac = "VAC"
            Else
                AusVac = dtTemp.Rows(0).Item("tipo_aus")
            End If

            _fecha = _fecha_ini
            '===2024-12-20
            Do Until _fecha > _fecha_fin
                sqlExecute("DELETE FROM ausentismo WHERE reloj = '" & rl & "' AND fecha = '" & FechaSQL(_fecha) & _
                           "' AND tipo_aus = '" & AusVac & "'", "TA")
                _fecha = DateAdd(DateInterval.Day, 1, _fecha)
            Loop
            '**************************************

            '---Modif.   30/ene/21     Ernesto
            '**********************AOS: Eliminar las vacaciones para el pago de nomina de Miscelaneos(de Ajustes_nom) (Funcionando actualmente)
            'Dim QElimVacAjnom As String = "delete from ajustes_nom where reloj='" & rl & "' and concepto='DIASVA' and comentario='Días de vacaciones capturados desde MAESTRO' and fecha='" & FechaSQL(FechaCaptura) & "' AND numcredito='" & cadenaVac & "'"
            'sqlExecute(QElimVacAjnom, "NOMINA")

            '===AO 2024-12-20: Eliminar en base al # de crédito
            Dim QElimVacAjnom As String = "delete from ajustes_nom where reloj='" & rl & "' and concepto='DIASVA' and comentario='Días de vacaciones capturados desde MAESTRO' AND numcredito='" & cadenaVac & "'"
            sqlExecute(QElimVacAjnom, "NOMINA")

            '====2024-09-06: Tambien eliminar los comentarios de cancelados:
            QElimVacAjnom = "delete from ajustes_nom where reloj='" & rl & "' and concepto='DIASVA' and comentario='Días de vacaciones CANCELADOS desde MAESTRO' and fecha='" & FechaSQL(FechaCaptura) & "'"
            sqlExecute(QElimVacAjnom, "NOMINA")

            '***************************************
            RefrescaVacaciones(rl)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("El registro de vacaciones no pudo ser borrado. Si el problema persiste, consulte al administrador del sistema." & _
                            vbCrLf & vbCrLf & "Err.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtTomar_ValueChanged(sender As Object, e As EventArgs) Handles txtTomar.ValueChanged
        txtPagar.Value = txtTomar.Value
        calcular_(True)
    End Sub

    Private Function calcular_(aplicar As Boolean) As String
        Dim detalle As String = ""
        Try
            Dim f_ini As Date = txtFechaDe.Value
            Dim dias_naturales As Double = txtTomar.Value
            Dim dias_proporcionados As Double = 0

            Dim f As Date = f_ini
            Dim i As Double = 0
            Dim r As String = txtReloj.Text

            While i < dias_naturales
                Dim proporcion As Double = 0
                Dim dtPeriodo As DataTable = sqlExecute("select ano+periodo as ano_periodo from periodos where '" & FechaSQL(f) & "' between fecha_ini and fecha_fin and isnull(periodo_especial, '0') = '0'", "TA")

                If Not DiaDescanso(f, r) Then
                    If dtPeriodo.Rows.Count > 0 Then
                        Dim ano_periodo As String = dtPeriodo.Rows(0)("ano_periodo")
                        Dim s As DetalleSemana = SemanaHorarioMixto(ano_periodo, r)

                        ' Dias trabajo de acuerdo al horario
                        Dim dthorario As DataTable = sqlExecute("select * from dias where cod_hora = '" & cmbHorario.SelectedValue & "' and cod_comp = '" & cmbCia.SelectedValue & "' and semana = '" & s.NumSemana & "' and isnull(descanso, 0) = 0")
                        Dim dias_semana = dthorario.Rows.Count

                        ' Dias para calculo vacaciones
                        Dim dias_calculo_vacaciones As Integer = 5
                        Dim dtDiasCalculo As DataTable = sqlExecute("select * from parametros where dias_calculo_vacaciones is not null")
                        If dtDiasCalculo.Rows.Count > 0 Then
                            dias_calculo_vacaciones = dtDiasCalculo.Rows(0)("dias_calculo_vacaciones")
                        End If

                        'Proporcion
                        proporcion = dias_calculo_vacaciones / dias_semana
                    End If
                    i += 1
                    detalle &= "+" & "    " & String.Format("{0:0.00}", proporcion) & "   " & "//" & FechaSQL(f) & vbCrLf
                End If

                dias_proporcionados += proporcion
                f = f.AddDays(1)
            End While

            detalle &= "=" & "    " & String.Format("{0:0.00}", dias_proporcionados)



        Catch ex As Exception

        End Try

        Return detalle
    End Function

    Private Function EnvioMiscDatosBaja(ByRef Reloj As String, tipoPer As String, Baja As Date, diasVac As Double, diasPriVac As Double, diasAgi As Double, _usuario As String)
        Try
            Dim QInsert As String = ""
            Dim _dtPeriodo As New DataTable
            Dim Anio As String = ""
            Dim Periodo As String = ""

            '----Buscar el próximo periodo de nómina  para ingresar los datos del finiquito de acuerdo al tipo de periodo
            If (tipoPer = "S") Then
                '_dtPeriodo = sqlExecute("SELECT * from periodos where FECHA_INI<='" & FechaSQL(Baja) & "' and FECHA_FIN>='" & FechaSQL(Baja) & "' and ISNULL(acumula,0)=1 and ISNULL(PERIODO_ESPECIAL,0)=0", "TA")
                _dtPeriodo = sqlExecute("select top 1 * from TA.dbo.periodos  where isnull(asentado,0)=0 and ISNULL(acumula,0)=1 and ISNULL(PERIODO_ESPECIAL,0)=0")
            ElseIf (tipoPer = "C") Then
                '  _dtPeriodo = sqlExecute("SELECT * from periodos_catorcenal where FECHA_INI<='" & FechaSQL(Baja) & "' and FECHA_FIN>='" & FechaSQL(Baja) & "' and ISNULL(acumula,0)=1 and ISNULL(PERIODO_ESPECIAL,0)=0", "TA")
                _dtPeriodo = sqlExecute("select top 1 * from TA.dbo.periodos  where isnull(asentado,0)=0 and isnull(nom_cat,0)=1 and ISNULL(acumula,0)=1 and ISNULL(PERIODO_ESPECIAL,0)=0")
            End If

            If (Not _dtPeriodo.Columns.Contains("Error") And _dtPeriodo.Rows.Count > 0) Then
                Try : Anio = _dtPeriodo.Rows(0).Item("ANO").ToString.Trim : Catch ex As Exception : Anio = "" : End Try
                Try : Periodo = _dtPeriodo.Rows(0).Item("PERIODO").ToString.Trim : Catch ex As Exception : Periodo = "" : End Try
            End If

            If (diasVac <> 0) Then
                QInsert = "INSERT INTO ajustes_nom (reloj,ano,periodo,per_ded,clave,monto,comentario,concepto,usuario,fecha) VALUES ('" & _
                    Reloj & "','" & Anio & "','" & Periodo & "','P','000'," & diasVac & ",'Enviado desde Mtro.Empleados al dar su baja','DIASVA','" & _usuario & "',GETDATE())"
                sqlExecute(QInsert, "NOMINA")
            End If

            If (diasPriVac <> 0) Then
                QInsert = "INSERT INTO ajustes_nom (reloj,ano,periodo,per_ded,clave,monto,comentario,concepto,usuario,fecha) VALUES ('" & _
                    Reloj & "','" & Anio & "','" & Periodo & "','P','000'," & diasPriVac & ",'Enviado desde Mtro.Empleados al dar su baja','DIASPV','" & _usuario & "',GETDATE())"
                sqlExecute(QInsert, "NOMINA")
            End If

            If (diasAgi <> 0) Then
                QInsert = "INSERT INTO ajustes_nom (reloj,ano,periodo,per_ded,clave,monto,comentario,concepto,usuario,fecha) VALUES ('" & _
                    Reloj & "','" & Anio & "','" & Periodo & "','P','000'," & diasAgi & ",'Enviado desde Mtro.Empleados al dar su baja','DIASAG','" & _usuario & "',GETDATE())"
                sqlExecute(QInsert, "NOMINA")
            End If

            '---Indicar que es baja
            Dim _mntBaja As Double = 0.0
            QInsert = "INSERT INTO ajustes_nom (reloj,ano,periodo,per_ded,clave,monto,comentario,concepto,usuario,fecha) VALUES ('" & _
               Reloj & "','" & Anio & "','" & Periodo & "','P','000'," & _mntBaja & ",'Enviado desde Mtro.Empleados al dar su baja','ESBAJA','" & _usuario & "',GETDATE())"
            sqlExecute(QInsert, "NOMINA")

        Catch ex As Exception

        End Try
    End Function


    Private Sub pnlCentrarControles_Paint(sender As Object, e As PaintEventArgs) Handles pnlCentrarControles.Paint

    End Sub

    Private Sub btnAgregarSuspenderCreditoInfonavit_Click(sender As Object, e As EventArgs) Handles btnAgregarSuspenderCreditoInfonavit.Click
        Try
            Dim rj As String = ""
            If btnAgregarSuspenderCreditoInfonavit.Text.Contains("Agregar") Then

                '===============ANTERIOR
                'Dim frm As New frmAgregarCreditoInfonavit

                'rj = txtReloj.Text.Trim
                'frm._reloj_agregar_infonavit = rj
                'frm._nombres_agregar_infonavit = txtNombre.Text.Trim & " " & txtApaterno.Text.Trim & " " & txtAmaterno.Text.Trim
                'frm._fecha_alta = txtAlta.Value

                'frm.ShowDialog()

                '======Activar controles
                cmbTipoMovInfonavit.Visible = True
                txtNumeroCredito.Visible = True
                txtNumeroCredito.Text = ""
                cmbTipoInfonavit.Visible = True
                txtFactorDeDescuentoInfonavit.Visible = True
                dtpFechaInicioCreditoInfonavit.Visible = True
                addInfoFirstTime = True
                cmbTipoMovInfonavit.SelectedValue = "15"

            ElseIf btnAgregarSuspenderCreditoInfonavit.Text.Contains("Suspender") Then
                Dim frm As New frmSuspenderCreditoInfonavit
                rj = txtReloj.Text.Trim
                frm._reloj_suspender_infonavit = rj
                frm._nombres_suspender_infonavit = txtNombre.Text.Trim & " " & txtApaterno.Text.Trim & " " & txtAmaterno.Text.Trim
                frm._fecha_alta = txtAlta.Value
                frm._numero_credito_suspender = txtNumeroCredito.Text

                frm.ShowDialog()
            End If
            rj = txtReloj.Text.Trim
            sqlExecute("update nomina_pro set infonavit_credito = null, tipo_credito = null, cuota_credito = null, inicio_credito = null, cobro_segviv = 0 where reloj = '" & rj & "'", "nomina")

            Dim dtInfonavit As DataTable = sqlExecute("select * from infonavit where activo = 1 and reloj = '" & rj & "' order by inicio_cre asc")
            For Each row_infonavit As DataRow In dtInfonavit.Rows

                sqlExecute("update nomina_pro set infonavit_credito = '" & row_infonavit("infonavit") & "' where reloj = '" & row_infonavit("reloj") & "'", "nomina")
                sqlExecute("update nomina_pro set tipo_credito = '" & row_infonavit("tipo_cred") & "' where reloj = '" & row_infonavit("reloj") & "'", "nomina")
                sqlExecute("update nomina_pro set cuota_credito = '" & row_infonavit("cuota_cred") & "' where reloj = '" & row_infonavit("reloj") & "'", "nomina")
                sqlExecute("update nomina_pro set inicio_credito = '" & row_infonavit("inicio_cre") & "' where reloj = '" & row_infonavit("reloj") & "'", "nomina")
                sqlExecute("update nomina_pro set cobro_segviv= '" & row_infonavit("cobro_segv") & "' where reloj = '" & row_infonavit("reloj") & "'", "nomina")

            Next

            MostrarInformacion(rj)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargaTipoCredInfonavit()
        Dim dtTipoInfonavit As New DataTable
        dtTipoInfonavit.Columns.Add("tipo")
        dtTipoInfonavit.Columns.Add("nombre")

        dtTipoInfonavit.Rows.Add({"1", "Porcentaje"})
        dtTipoInfonavit.Rows.Add({"2", "Cuota fija"})
        dtTipoInfonavit.Rows.Add({"3", "VSM"})

        cmbTipoInfonavit.DataSource = dtTipoInfonavit
        cmbTipoInfonavit.ValueMember = "tipo"
    End Sub

    Private Sub EditaInfonavit(ByVal _rj As String, _infonavit As String, ByVal Campo As String, ByVal Valor As Object)
        Try
            Dim cadena As String = ""
            Dim TipoMovimiento As String = "C"
            '    Dim anioPer As String = anio & periodo
            Dim campo_nomPro As String = ""

            Select Case Campo
                Case "tipo_cred"
                    campo_nomPro = "tipo_credito"
                Case "cuota_cred"
                    campo_nomPro = "cuota_credito"
                Case "inicio_cre"
                    campo_nomPro = "inicio_credito"
            End Select
            Dim _nombres_agregar_infonavit As String = "", alta As String = ""
            Dim dtPersonalNomb As DataTable = sqlExecute("select reloj,nombres,alta from personalvw where reloj='" & _rj & "'", "PERSONAL")
            If (Not dtPersonalNomb.Columns.Contains("Error") And dtPersonalNomb.Rows.Count > 0) Then
                Try : _nombres_agregar_infonavit = dtPersonalNomb.Rows(0).Item("nombres").ToString.Trim : Catch ex As Exception : _nombres_agregar_infonavit = "" : End Try
                Try : alta = FechaSQL(dtPersonalNomb.Rows(0).Item("alta")) : Catch ex As Exception : alta = "" : End Try
            End If


            If TypeOf Valor Is Double Or TypeOf Valor Is Integer Then ' Si es tipo double o Integer
            ElseIf TypeOf Valor Is Boolean Then ' Si es bOOLEANO
            ElseIf TypeOf Valor Is Date Then ' Si es tipo fecha

            Else ' Cualquier otro, va  ser tpo String
                Dim ValAnt As String = "" ' Guarda el val anterior para meterlo a bitácora
                dtTemp = sqlExecute("SELECT " & campo_nomPro & " from nomina_pro WHERE reloj = '" & _rj & "'", "NOMINA")
                Try : ValAnt = dtTemp.Rows.Item(0).Item(0) : Catch ex As Exception : ValAnt = "" : End Try
                If (Valor Is Nothing Or Valor = "") Then Valor = ""

                If (ValAnt.Trim <> Valor.ToString.Trim) Then

                    If Valor = "NULL" Then
                        sqlExecute("UPDATE nomina_pro SET " & campo_nomPro & " = NULL WHERE reloj = '" & _rj & "' and infonavit_credito='" & _infonavit & "'", "NOMINA")
                    Else

                        '---Validar si existe
                        Dim dtExistInfo As DataTable = sqlExecute("select * from infonavit where reloj='" & _rj & "' and infonavit='" & _infonavit & "' and tipo_cred='" & cmbTipoInfonavit.SelectedValue & "' and cuota_cred=" & txtFactorDeDescuentoInfonavit.Text & " and inicio_cre='" & FechaSQL(dtpFechaInicioCreditoInfonavit.Value) & "'", "PERSONAL")
                        If (Not dtExistInfo.Columns.Contains("Error") And dtExistInfo.Rows.Count > 0) Then
                            '  GoTo SaltaInsertInfo
                            '---AOS : 2022-02-22 Eliminar dicho registro para que vuelva a ser reinsertado
                            sqlExecute("delete from infonavit where reloj='" & _rj & "' and infonavit='" & _infonavit & "' and tipo_cred='" & cmbTipoInfonavit.SelectedValue & "' and cuota_cred=" & txtFactorDeDescuentoInfonavit.Text & " and inicio_cre='" & FechaSQL(dtpFechaInicioCreditoInfonavit.Value) & "'", "PERSONAL")
                        End If

                        '---AOS 2022-02-22 - Eliminar todos los registros con valor a cero
                        sqlExecute("delete from infonavit where reloj='" & _rj & "' and isnull(cuota_cred,0.00)=0.00", "PERSONAL")

                        sqlExecute("UPDATE nomina_pro SET " & campo_nomPro & " = '" & Valor & "' WHERE reloj = '" & _rj & "' and infonavit_credito='" & _infonavit & "'", "NOMINA")
                        '   sqlExecute("UPDATE infonavit SET " & Campo & " = '" & Valor & "' WHERE reloj = '" & _rj & "' and infonavit='" & _infonavit & "'", "PERSONAL") ' También actualizamos la tabla principal que es PERSONAL
                        '----AOS: 10/06/2021 : Agregamos el nuevo registro con el dato cambiado

                        '---- Proceso para insertar el nuevo registro con el cambio:

                        '---AO HERE 2024-04-05 Para mandar el cobro_segv de acuerdo al ultimo registro que esta activo, ya sera 0 o 1
                        '-***NOTA: es tipo BIT , ponerlo como string o si no, como Boolean, hacer pruebas con el empleado 00220
                        Dim _cobrosegv As Boolean = False, dtCobroSeg As DataTable, _cobroSegVivInt As Integer = 0, cod_movimiento As String = ""
                        Dim Q As String = "select top 1 cobro_segv,cod_movimiento from infonavit where reloj='" & _rj & "' order by fechahora desc"
                        dtCobroSeg = sqlExecute(Q, "PERSONAL")
                        If Not dtCobroSeg.Columns.Contains("Error") And dtCobroSeg.Rows.Count > 0 Then
                            Try : _cobrosegv = dtCobroSeg.Rows(0).Item("cobro_segv") : Catch ex As Exception : _cobrosegv = False : End Try
                            Try : cod_movimiento = dtCobroSeg.Rows(0).Item("cod_movimiento") : Catch ex As Exception : cod_movimiento = "" : End Try
                        End If

                        If _cobrosegv Then _cobroSegVivInt = 1
                        If Not _cobrosegv Then _cobroSegVivInt = 0



                        'Si no existe aun el movimiento, insertarlo
                        Dim dtExisteMov As DataTable = sqlExecute("select * from infonavit where reloj='" & _rj & "' and infonavit='" & _infonavit & "' and tipo_cred='" & cmbTipoInfonavit.SelectedValue & "' and cuota_cred='" & txtFactorDeDescuentoInfonavit.Text & "' and cod_movimiento='" & cmbTipoMovInfonavit.SelectedValue & "'", "PERSONAL")
                        If dtExisteMov.Rows.Count <= 0 Then
                            sqlExecute("update infonavit set activo=0 where reloj='" & _rj & "'", "PERSONAL") ' Actualizamos todos los infonavit como no activos, para dejar el que se va agregar como activo
                            Q = "insert into infonavit (reloj, infonavit, activo, cobro_segv,usuario,fechahora) values ('" & _rj & "', '" & _infonavit & "', 1, " & _cobroSegVivInt & ",'" & Usuario & "',getdate())"
                            sqlExecute(Q, "PERSONAL")
                        End If

                       

                    sqlExecute("update infonavit set nombres = '" & _nombres_agregar_infonavit & "' where reloj = '" & _rj & "' and infonavit = '" & _infonavit & "' and activo=1", "PERSONAL")
                    sqlExecute("update infonavit set alta = '" & alta & "' where reloj = '" & _rj & "' and infonavit = '" & _infonavit & "' and activo=1", "PERSONAL")
                    sqlExecute("update infonavit set tipo_cred = '" & cmbTipoInfonavit.SelectedValue & "' where reloj = '" & _rj & "' and infonavit = '" & _infonavit & "' and activo=1", "PERSONAL")
                        sqlExecute("update infonavit set cuota_cred = '" & txtFactorDeDescuentoInfonavit.Text & "' where reloj = '" & _rj & "' and infonavit = '" & _infonavit & "' and activo=1", "PERSONAL")

                        '=====Fecha de inicio de credito, ,mantener la misma que el movimiento 15
                        Dim _fec_Inic_Cred_Info As String = ""
                        If cmbTipoMovInfonavit.SelectedValue <> "15" Then ' Si no es inicio de credito de la vivienda, colocar la fecha de inicio de credito del mov 15

                            Dim dtFecIniCred As DataTable = sqlExecute("select  top 1 inicio_cre  from infonavit where reloj='" & _rj & "' and cod_movimiento in('15','30') order by fecha_aplicacion desc", "PERSONAL")
                            If Not dtFecIniCred.Columns.Contains("Error") And dtFecIniCred.Rows.Count > 0 Then
                                Try : _fec_Inic_Cred_Info = FechaSQL(dtFecIniCred.Rows(0).Item("inicio_cre").ToString.Trim) : Catch ex As Exception : _fec_Inic_Cred_Info = "" : End Try
                            End If

                            If _fec_Inic_Cred_Info = "" Then _fec_Inic_Cred_Info = _finicio_cred_infonavit

                            sqlExecute("update infonavit set inicio_cre = '" & _fec_Inic_Cred_Info & "',fecha_aplicacion='" & FechaSQL(dtpFechaInicioCreditoInfonavit.Value) & "' where reloj = '" & _rj & "' and infonavit = '" & _infonavit & "' and activo=1", "PERSONAL")
                        Else ' si el mov es 15 Inicio de cred de vienda, poner ambas fechas iguales
                            sqlExecute("update infonavit set inicio_cre = '" & FechaSQL(dtpFechaInicioCreditoInfonavit.Value) & "',fecha_aplicacion='" & FechaSQL(dtpFechaInicioCreditoInfonavit.Value) & "' where reloj = '" & _rj & "' and infonavit = '" & _infonavit & "' and activo=1", "PERSONAL")
                        End If

                    '=====Tipo de movimiento
                        If cmbTipoMovInfonavit.SelectedValue = "" Then cmbTipoMovInfonavit.SelectedValue = cod_movimiento

                        If cmbTipoMovInfonavit.SelectedValue = "16" Then ' Si es suspension, desactivarlo, y poner su fecha de suspension
                            sqlExecute("update infonavit set cod_movimiento = '" & cmbTipoMovInfonavit.SelectedValue & "',activo=0,suspension='" & FechaSQL(dtpFechaInicioCreditoInfonavit.Value) & "' where reloj = '" & _rj & "' and infonavit = '" & _infonavit & "' and activo=1", "PERSONAL")
                        Else
                            sqlExecute("update infonavit set cod_movimiento = '" & cmbTipoMovInfonavit.SelectedValue & "' where reloj = '" & _rj & "' and infonavit = '" & _infonavit & "' and activo=1", "PERSONAL")
                        End If



                    '--- Actualizar en PERSONAL  ::   update personal set INFONAVIT='',DIG_VER_IN='',FECHA_CRE='',TIPO_CRE='',PAGO_INF=0.0,PAGO_SEGVI=1,CREDITO_IN=1 where reloj='00002'
                    Dim DIG_VER_IN As String = "", PAGO_SEGVI As Integer = 0, CREDITO_IN As Integer = 0
                    PAGO_SEGVI = 1
                    CREDITO_IN = 1
                    Try : DIG_VER_IN = _infonavit.Substring(10, 1).ToString.Trim : Catch ex As Exception : DIG_VER_IN = "" : End Try
                    Dim QUp As String = "update personal set INFONAVIT='" & _infonavit & "',DIG_VER_IN='" & DIG_VER_IN & "',FECHA_CRE='" & FechaSQL(dtpFechaInicioCreditoInfonavit.Value) & "',TIPO_CRE='" & cmbTipoInfonavit.SelectedValue & "',PAGO_INF=" & Double.Parse(txtFactorDeDescuentoInfonavit.Text) & ",PAGO_SEGVI=" & PAGO_SEGVI & ",CREDITO_IN=" & CREDITO_IN & " where reloj='" & _rj & "'"
                    sqlExecute(QUp, "PERSONAL")

                    'SaltaInsertInfo: ' AOS - 2022-02-22 Se comenta esta linea

                    End If

                End If

            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkShowSalary_CheckStateChanged(sender As Object, e As EventArgs) Handles chkShowSalary.CheckStateChanged
        If (chkShowSalary.Checked) Then
            ' pnlSueldos1.Visible = True
            pnlSueldos2.Visible = True
        End If

        If (chkShowSalary.Checked = False) Then
            '  pnlSueldos1.Visible = False
            pnlSueldos2.Visible = False
        End If
    End Sub

    Private Sub txtCpSAT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCpSAT.KeyPress
        If Not Char.IsDigit(e.KeyChar) And e.KeyChar <> vbBack Then e.Handled = True
    End Sub

    Private Sub txtEmailEmpresa_Leave(sender As Object, e As EventArgs) Handles txtEmailEmpresa.Leave
        '---Validar que el EMAIL del empleado esté en el formato correcto
        If Not IsValidEmail(txtEmailEmpresa.Text.Trim) Then ' Si no esta en el formato correcto:
            If MessageBox.Show("El correo electrónico de la empresa no está en el formato correcto, desea así continuar?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                ' Si no desea continuar y capturarlo correctamente, entonces nos volvemos al control TEXT:
                txtEmailEmpresa.Focus()
            End If
        End If
    End Sub

    Private Sub SaveInfoLocker(ByVal _rj As String, _locker As String)
        Dim Lock As String = "", tipo_sex As String = "", grupoLocker As String = "", detalle As String = ""
        Try
            If Len(_locker.Trim) > 4 Then
                MessageBox.Show("La cantidad de dígitos para el locker debe de ser máximo de 4", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                sqlExecute("update personal set LOCKER=null where reloj='" & _rj & "'", "PERSONAL")
                txtLocker.Text = ""
                Exit Sub
            End If

            If _locker.Trim <> "" Then
                Lock = _locker.ToString.Trim.PadLeft(4, "0")
                tipo_sex = btnSexo.Value
                If tipo_sex = "False" Then
                    grupoLocker = "MAS"
                    detalle = "DISPONIBLE MASCULINOS"
                Else
                    grupoLocker = "FEM"
                    detalle = "DISPONIBLE FEMENINOS"
                End If

                ' Validar si está disponible    
                Dim dtExist As DataTable = sqlExecute("select * from lockers where LOCKER='" & Lock & "' and isnull(STATUS,0)=0 and isnull(reloj,'')='' and GRUPO='" & grupoLocker & "'", "PERSONAL")

                If Not dtExist.Columns.Contains("Error") And dtExist.Rows.Count > 0 Then
                    Dim nombres As String = txtApaterno.Text.Trim & "," & txtAmaterno.Text.Trim & "," & txtNombre.Text.Trim
                    '---Liberar el que ya tiene, si es que tiene ya uno asignado
                    sqlExecute("update lockers set CANDADO=null,STATUS=0,RELOJ=null,DETALLE='" & detalle & "' where reloj='" & _rj & "' and GRUPO='" & grupoLocker & "'", "PERSONAL")
                    '---Agregarle el nuevo
                    sqlExecute("update lockers set reloj='" & _rj & "',DETALLE='" & nombres & "',STATUS=1,CANDADO='" & Lock & "' where LOCKER='" & Lock & "' and GRUPO='" & grupoLocker & "'", "PERSONAL")

                Else ' Está ya asignado
                    MessageBox.Show("El locker ya se encuentra asignado a otro empleado", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    sqlExecute("update personal set LOCKER=null where reloj='" & _rj & "'", "PERSONAL")
                    txtLocker.Text = ""
                    Exit Sub
                End If

            End If

            'If _locker.Trim = "" Then
            '    ' Borrar locker
            'End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 'Método para exportar el detalle del empleado de vacaciones a excel
    ''' </summary>
    ''' <remarks></remarks> 
    Private Sub btnExpExcelDetVac_Click(sender As Object, e As EventArgs) Handles btnExpExcelDetVac.Click
        Try
            Dim query As String = "", dtInfoVacEmpl As New DataTable, _rj As String = ""
            _rj = txtReloj.Text.ToString.Trim
            query = "select sv.reloj,p.nombres,sv.comentario,sv.ano,isnull(sv.dias,0) as 'dias_ganados', sv.SALDO_DINERO as 'saldo',isnull(sv.dinero,0) as 'dias_tomados' ,CAST(sv.FECHA_INI AS varchar) as 'fecha_inicial',CAST(sv.FECHA_FIN AS varchar) as 'fecha_final' " & _
                "from saldos_vacaciones sv left outer join personalvw p on sv.RELOJ=p.RELOJ  where sv.reloj='" & _rj & "' order by sv.FECHA_CAPTURA desc, sv.FECHA_FIN desc"
            dtInfoVacEmpl = sqlExecute(query, "PERSONAL")

            If Not dtInfoVacEmpl.Columns.Contains("Error") And dtInfoVacEmpl.Rows.Count > 0 Then
                '---Generar detalle en excel de los que si fueron aplicados
                Dim sfd As New SaveFileDialog
                sfd.Filter = "Archivo de excel|*.xlsx"
                sfd.Title = "Detalle de vacaciones"
                sfd.FileName = "Detalle de vacaciones_" & _rj & "_" & FechaSQL(Now.Date).Replace("-", "")
                If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                    If ExportaExcelOpenXML(dtInfoVacEmpl, sfd.FileName, "Detalle de vacaciones_" & _rj & ", " & FechaSQL(Now.Date)) Then
                        MessageBox.Show("Archivo generado en " & sfd.FileName, "Detalle de vacaciones", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Exporta detalle vacaciones a excel x empl", ex.HResult, ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 'Método para generar detalle en excel a partir de datos en un datatable
    ''' </summary>
    ''' <remarks></remarks> 
    Private Function ExportaExcelOpenXML(dtDatos As DataTable, file_name As String, titulo As String) As Boolean

        Dim frm As New frmTrabajando
        frm.Show()

        Try

            Dim archivo As ExcelPackage = New ExcelPackage()
            Dim wb As ExcelWorkbook = archivo.Workbook

            Dim hoja_personal As ExcelWorksheet = wb.Worksheets.Add("Sistema PIDA")

            Dim row As Integer = 3
            Dim col As Integer = 1

            For Each column As DataColumn In dtDatos.Columns
                Application.DoEvents()

                hoja_personal.Cells(row, col).Value = column.ColumnName
                hoja_personal.Cells(row, col).Style.Font.Bold = True
                col += 1
            Next
            row += 1

            For Each drow As DataRow In dtDatos.Rows
                col = 1
                For Each column As DataColumn In dtDatos.Columns
                    Application.DoEvents()
                    hoja_personal.Cells(row, col).Value = drow(column.ColumnName)
                    col += 1
                Next
                row += 1
            Next


            hoja_personal.Cells(hoja_personal.Dimension.Address).AutoFitColumns()

            hoja_personal.Cells(1, 1).Value = titulo
            hoja_personal.Cells(1, 1).Style.Font.Bold = True
            hoja_personal.Cells(1, 1).Style.Font.Size = 14


            archivo.SaveAs(New System.IO.FileInfo(file_name))

            ActivoTrabajando = False
            frm.Close()

            Return True

        Catch ex As Exception

            ActivoTrabajando = False
            frmTrabajando.Close()

            Return False
        End Try

    End Function

    '---Cargar Documentos
    Private Sub btnAgregarDocumento_Click(sender As Object, e As EventArgs) Handles btnAgregarDocumento.Click
        Dim GuardaArchivo As String
        Dim NombreArchivo As String
        Dim NoSigArch As String = ""
        Dim TotRecs As Integer

        Dim i As Integer
        Dim btnArchivo As New DevComponents.DotNetBar.ButtonItem

        Reloj = txtReloj.Text

        If Reloj.Trim <> "" Then

            Dim TotElementos As Integer = itmDocs.SubItems.Count
            Dim dtTotRecs As DataTable = sqlExecute("Select count (reloj) AS totRecs from ARCHIVOS  where reloj='" & Reloj.Trim & "'", "PERSONAL")
            If (Not dtTotRecs.Columns.Contains("Error") And dtTotRecs.Rows.Count > 0) Then
                TotRecs = Convert.ToInt32(IIf(IsDBNull(dtTotRecs.Rows(0).Item("totRecs")), "0", dtTotRecs.Rows(0).Item("totRecs")))
            End If
            If (TotRecs >= 8 Or TotElementos >= 8) Then
                MessageBox.Show("El máximo de archivos a agregar son 8 por empleado, favor de eliminar uno para poder agregar un nuevo archivo", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Exit Sub
            End If

            Try
                opnArchivo.FileName = ""
                opnArchivo.Filter = FiltroArchivos

                If opnArchivo.ShowDialog <> DialogResult.Cancel Then
                    Dim Archivo As String
                    Archivo = opnArchivo.FileName
                    i = Archivo.LastIndexOf("\")
                    If i < 0 Then
                        MessageBox.Show("El nombre de archivo es incorrecto. Favor de verificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End If

                    Dim f As New FileInfo(Archivo)
                    Dim Extension As String = f.Extension

                    Dim fecha As Date = Date.Now
                    Dim fecha_completa As String = fecha.Year & fecha.Month & fecha.Day & fecha.Hour & fecha.Minute & Reloj & Extension

                    '--Validar si existe ruta donde se van a guardar los archivos del personal
                    If Not Directory.Exists(PathArchivos & "PERSONAL\") Then
                        MkDir(PathArchivos & "PERSONAL\")
                    End If

                    NoSigArch = ObtNumConsecArch(Reloj)
                    NoSigArch = IIf(NoSigArch.Trim = "", "01", NoSigArch.Trim)
                    NombreArchivo = fecha_completa
                    GuardaArchivo = PathArchivos & "PERSONAL\" & NombreArchivo      'Nombre de archivo a guardar

                    Try
                        FileCopy(Archivo, GuardaArchivo)
                    Catch ex As Exception
                        MessageBox.Show("El archivo no puede ser insertado. Favor de verificar." & vbCrLf & vbCrLf & "Err.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Sub
                    End Try

                    btnArchivo = NuevoArchivo(GuardaArchivo)
                    If btnArchivo Is Nothing Then MessageBox.Show("El archivo no puede ser insertado. Favor de verificar." & vbCrLf & vbCrLf & "Err.- " & MsjErr, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    If btnArchivo Is Nothing Then Exit Sub

                    itmDocs.SubItems.Add(btnArchivo)
                    pnlDocs.Refresh()

                End If
            Catch ex As Exception
                ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            End Try
        Else
            MessageBox.Show("Para insertar un archivo seleccione un empleado", "Terminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub

    '--- Función que devuelve el nuevo archivo en formato de lista con su cono, es donde se personaliza el nuevo archivo
    Private Function NuevoArchivo(ByVal Archivo As String) As DevComponents.DotNetBar.ButtonItem
        Dim btnArchivo As New DevComponents.DotNetBar.ButtonItem
        Dim btnMenu As New DevComponents.DotNetBar.ButtonItem

        Try
            Dim i As Integer

            If File.Exists(Archivo) = False Then
                Return Nothing
            End If

            i = Archivo.LastIndexOf("\")
            If i < 0 Then
                Return Nothing
            End If

            If Archivo.Contains(".pdf") Then
                btnArchivo.Image = My.Resources.PDFima
            ElseIf (Archivo.Contains(".xls") Or Archivo.Contains(".xlsx") Or Archivo.Contains(".xl5")) Then
                btnArchivo.Image = My.Resources.ExcelFirma
            ElseIf (Archivo.Contains(".docx") Or Archivo.Contains(".docm") Or Archivo.Contains(".dotx") Or Archivo.Contains(".rtf") Or Archivo.Contains(".doc") Or Archivo.Contains(".dot")) Then
                btnArchivo.Image = My.Resources.WordFirma
                'ElseIf (Archivo.Contains(".zip") Or Archivo.Contains(".rar")) Then
                '    btnArchivo.Image = My.Resources.ZIP
            Else
                btnArchivo.Image = CType(Image.FromFile(Archivo, True), Bitmap)

            End If

            btnArchivo.ImageFixedSize = New System.Drawing.Size(40, 40)
            btnArchivo.Name = "btn" & itmDocs.SubItems.Count
            btnArchivo.OptionGroup = "chart"
            btnArchivo.Tooltip = Archivo.Substring(i + 1)
            btnArchivo.ImagePaddingHorizontal = 10
            btnArchivo.ImagePaddingHorizontal = 10
            btnArchivo.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat
            btnArchivo.AutoCheckOnClick = True

            'btnMenu = New DevComponents.DotNetBar.ButtonItem
            'btnMenu.Text = "Copiar"
            'btnMenu.Image = My.Resources.copy_16
            'AddHandler btnMenu.Click, AddressOf CopyImage
            'btnArchivo.SubItems.Add(btnMenu)

            btnMenu = New DevComponents.DotNetBar.ButtonItem
            btnMenu.Text = "Borrar"
            btnMenu.Image = My.Resources.DeleteRec
            AddHandler btnMenu.Click, AddressOf Borrar
            btnArchivo.SubItems.Add(btnMenu)

            btnMenu = New DevComponents.DotNetBar.ButtonItem
            btnMenu.Text = "Guardar como..."
            btnMenu.Image = My.Resources.Save_as16
            AddHandler btnMenu.Click, AddressOf GuardarComo
            btnArchivo.SubItems.Add(btnMenu)

            btnMenu = New DevComponents.DotNetBar.ButtonItem
            btnMenu.Text = "Cerrar"
            btnMenu.BeginGroup = True
            btnArchivo.SubItems.Add(btnMenu)

            AddHandler btnArchivo.DoubleClick, AddressOf ZoomImagen
            AddHandler btnArchivo.PopupOpen, AddressOf btnPopupOpen
            Return btnArchivo

        Catch ex As Exception
            MsjErr = ex.Message
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            Return Nothing
        End Try
    End Function

    '---Metodo para copiar imagen
    Private Sub CopyImage(sender As Object, e As EventArgs)
        Clipboard.Clear()
        Clipboard.SetImage(sender.parent.Image)
    End Sub

    '---Proceso para borrar / ELiminar la imagen
    Private Sub Borrar(sender As Object, e As EventArgs)
        Dim selItem As New DevComponents.DotNetBar.ButtonItem
        Try


            selItem = sender.parent
            If selItem.Tooltip.Trim <> "" Then
                If MessageBox.Show("¿Está seguro de remover el archivo " & selItem.Tooltip.Trim & " del empleado con número de reloj '" & txtReloj.Text.Trim & "' ?", "Remover archivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                    itmDocs.SubItems.Remove(selItem)
                    '--Proceso para eliminarlo de la base de datos, renumerar los archivos, que ordene de menor a mayor, que haga no visible los controles, y eliminar el archivo físicamente de la carpeta
                    DeleteDoc(txtReloj.Text.Trim, selItem.Tooltip.Trim)
                    My.Computer.FileSystem.DeleteFile(PathArchivos & "PERSONAL\" & selItem.Tooltip.Trim) ' Elimina el archivo físicamente
                    pnlDocs.Refresh() ' Refrescamos el panel
                End If
            Else
                Stop
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    '----- Función que elimina el nuevo archivo como tal, y renumera los anteriores para dejarlos en modo lista
    Private Sub DeleteDoc(ByRef Reloj As String, NombreArch As String)
        Try
            If (Reloj <> "" And NombreArch <> "") Then
                Dim dtBuscarRec As DataTable = sqlExecute("SELECT * from ARCHIVOS where reloj='" & Reloj & "' and nombre_arch='" & NombreArch & "'", "PERSONAL")
                If (Not dtBuscarRec.Columns.Contains("Error") And dtBuscarRec.Rows.Count > 0) Then
                    Dim NoConsec As String = IIf(IsDBNull(dtBuscarRec.Rows(0).Item("consec")), "", dtBuscarRec.Rows(0).Item("consec"))
                    If (NoConsec.Trim <> "") Then
                        ' Eliminar registro
                        sqlExecute("delete from archivos where reloj='" & Reloj & "' and consec='" & NoConsec.Trim & "'", "PERSONAL")

                        ' Renumerar los siguientes consecutivos (Hacer el update a los registros que quedaron)
                        Dim dtSigRecs As DataTable = sqlExecute("SELECT * from ARCHIVOS where reloj='" & Reloj & "' and consec>'" & NoConsec.Trim & "' order by consec asc", "PERSONAL")
                        If (Not dtSigRecs.Columns.Contains("Error") And dtSigRecs.Rows.Count > 0) Then

                            Dim dtUltimo As DataTable = sqlExecute("select max(consec) AS ULTIMO from ARCHIVOS", "PERSONAL")
                            Dim Ultimo As Integer = Convert.ToInt32(IIf(IsDBNull(dtUltimo.Rows(0).Item("ULTIMO")), "0", dtUltimo.Rows(0).Item("ULTIMO")))

                            For Each drow As DataRow In dtSigRecs.Rows

                                Dim NoConsViejo As String = IIf(IsDBNull(drow("consec")), "", drow("consec"))
                                Dim NoConsNewInt As Integer = Convert.ToInt32(NoConsViejo.Trim) - 1
                                Dim NoConsNewStr As String = IIf(NoConsNewInt > 0 And NoConsNewInt <= 9, "0" & Convert.ToString(NoConsNewInt), Convert.ToString(NoConsNewInt))
                                sqlExecute("UPDATE ARCHIVOS set consec='" & NoConsNewStr.Trim & "' where reloj='" & Reloj.Trim & "' AND consec='" & NoConsViejo.Trim & "'", "PERSONAL")

                                '---Renumerar controles con la descripcion
                                Select Case NoConsNewInt
                                    Case 1
                                        txtDescArch1.Text = txtDescArch2.Text
                                        lblTpoDoc1.Text = lblTpoDoc2.Text
                                        If (Ultimo = (NoConsNewInt + 1)) Then
                                            txtDescArch2.Text = ""
                                            lblTpoDoc2.Text = ""
                                        End If
                                    Case 2
                                        txtDescArch2.Text = txtDescArch3.Text
                                        lblTpoDoc2.Text = lblTpoDoc3.Text
                                        If (Ultimo = (NoConsNewInt + 1)) Then
                                            txtDescArch3.Text = ""
                                            lblTpoDoc3.Text = ""
                                        End If
                                    Case 3
                                        txtDescArch3.Text = txtDescArch4.Text
                                        lblTpoDoc3.Text = lblTpoDoc4.Text
                                        If (Ultimo = (NoConsNewInt + 1)) Then
                                            txtDescArch4.Text = ""
                                            lblTpoDoc4.Text = ""
                                        End If
                                    Case 4
                                        txtDescArch4.Text = txtDescArch5.Text
                                        lblTpoDoc4.Text = lblTpoDoc5.Text
                                        If (Ultimo = (NoConsNewInt + 1)) Then
                                            txtDescArch5.Text = ""
                                            lblTpoDoc5.Text = ""
                                        End If
                                    Case 5
                                        txtDescArch5.Text = txtDescArch6.Text
                                        lblTpoDoc5.Text = lblTpoDoc6.Text
                                        If (Ultimo = (NoConsNewInt + 1)) Then
                                            txtDescArch6.Text = ""
                                            lblTpoDoc6.Text = ""
                                        End If
                                    Case 6
                                        txtDescArch6.Text = txtDescArch7.Text
                                        lblTpoDoc6.Text = lblTpoDoc7.Text
                                        If (Ultimo = (NoConsNewInt + 1)) Then
                                            txtDescArch7.Text = ""
                                            lblTpoDoc7.Text = ""
                                        End If
                                    Case 7
                                        txtDescArch7.Text = txtDescArch8.Text
                                        lblTpoDoc7.Text = lblTpoDoc8.Text
                                        If (Ultimo = (NoConsNewInt + 1)) Then
                                            txtDescArch8.Text = ""
                                            lblTpoDoc8.Text = ""
                                        End If

                                End Select
                            Next

                        Else ' Si es el ultimo registro que hay y no tiene consecutivos, que limpe  sus control
                            Select Case NoConsec.Trim
                                Case "01"
                                    txtDescArch1.Text = ""
                                    lblTpoDoc1.Text = ""
                                Case "02"
                                    txtDescArch2.Text = ""
                                    lblTpoDoc2.Text = ""
                                Case "03"
                                    txtDescArch3.Text = ""
                                    lblTpoDoc3.Text = ""
                                Case "04"
                                    txtDescArch4.Text = ""
                                    lblTpoDoc4.Text = ""
                                Case "05"
                                    txtDescArch5.Text = ""
                                    lblTpoDoc5.Text = ""
                                Case "06"
                                    txtDescArch6.Text = ""
                                    lblTpoDoc6.Text = ""
                                Case "07"
                                    txtDescArch7.Text = ""
                                    lblTpoDoc7.Text = ""
                                Case "08"
                                    txtDescArch8.Text = ""
                                    lblTpoDoc8.Text = ""
                            End Select
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    '----Función para obtener el número consecutivo para asignárselo al archivo
    Private Function ObtNumConsecArch(ByRef R As String) As String
        Dim NumConsec As String = ""
        'Dim strArch As String = ""
        'Dim Archivos() As String
        Try
            If (R.Trim <> "") Then
                Dim dtBuscarArch As DataTable = sqlExecute("select consec from archivos where RELOJ='" & R.Trim & "' order by consec desc", "PERSONAL")
                If (Not dtBuscarArch.Columns.Contains("Error") And dtBuscarArch.Rows.Count > 0) Then
                    Dim NoConInt As Integer = Convert.ToInt32(IIf(IsDBNull(dtBuscarArch.Rows(0).Item("consec")), "0", dtBuscarArch.Rows(0).Item("consec")))
                    NoConInt = NoConInt + 1
                    NumConsec = IIf(NoConInt >= 1 And NoConInt <= 9, "0" & Convert.ToString(NoConInt), Convert.ToString(NoConInt))
                Else
                    NumConsec = "01"
                End If
            End If
            Return NumConsec
        Catch ex As Exception
            Return NumConsec
        End Try
    End Function
    ' 17731312
    Private Sub GuardarComo(sender As Object, e As EventArgs)
        Dim Archivo As String, ArchivoLargo As String
        Try
            Dim NewFltArch As String = ""
            Dim tpoArch As String = ""
            Archivo = sender.parent.ToolTip
            tpoArch = Archivo.Trim.Split(".")(1).ToUpper
            Select Case tpoArch
                Case "XLS", "XLSX", "XLS5"
                    ' NewFltArch = "Archivos Excel|*.xls;*.xls5;*.xlsx"
                    NewFltArch = "Archivos Excel|*.xlsx;*.xls;*.xls5"
                Case "PDF"
                    NewFltArch = "Archivos PDF (*.pdf)|*.pdf"
                Case "DOCX", "DOCM", "DOTX", "RTF", "DOC", "DOT"
                    NewFltArch = "Archivos Word|*.docx;*.docm;*.dotx;*.rtf;*.doc;*.dot"
                Case "ZIP", "RAR"
                    NewFltArch = "Archivos ZIP|*.zip;*.rar"
                Case Else
                    NewFltArch = FiltroArchivos
            End Select
            ArchivoLargo = Archivo
            Archivo = Archivo.Trim ' Quitar espacio
            Archivo = Archivo.Split(".")(0).Trim  ' Quitamos extension del archivo 

            sveDialog.FileName = Archivo
            ' sveDialog.Filter = FiltroArchivos
            sveDialog.Filter = NewFltArch
            If sveDialog.ShowDialog <> DialogResult.Cancel Then
                FileCopy(PathArchivos & "PERSONAL\" & ArchivoLargo, sveDialog.FileName)
                MessageBox.Show("El documento se guardó exitosamente en la ruta seleccionada", "P.I.D.A.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ZoomImagen(sender As Object, e As EventArgs)

        Try

            If (sender.tooltip.ToString.Contains(".pdf") Or sender.tooltip.ToString.Contains(".xlsx") Or sender.tooltip.ToString.Contains(".xls") Or sender.tooltip.ToString.Contains(".xls5")) Then
                Process.Start(PathArchivos & "PERSONAL\" & sender.tooltip.ToString)
            ElseIf (sender.tooltip.ToString.Contains(".docx") Or sender.tooltip.ToString.Contains(".doc") Or sender.tooltip.ToString.Contains(".docm") Or sender.tooltip.ToString.Contains(".dotx") Or sender.tooltip.ToString.Contains(".dot") Or sender.tooltip.ToString.Contains(".rtf")) Then
                Process.Start(PathArchivos & "PERSONAL\" & sender.tooltip.ToString)
            Else

                'frmZoom.Text = "Idea " & txtFolio.Text
                frmZoom.Text = "pendiente"
                frmZoom.picImagen.ImageLocation = PathArchivos & "PERSONAL\" & sender.tooltip

                If Application.OpenForms().OfType(Of frmZoom).Any Then
                    frmZoom.Show()
                Else
                    frmZoom.ShowDialog(Me)
                End If

            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnPopupOpen(sender As Object, e As DevComponents.DotNetBar.PopupOpenEventArgs)
        For Each it In sender.subitems
            If it.text = "Borrar" Then
                ' it.enabled = AgregarAux Or Editar 'PENDIENTE
                it.enabled = True
            End If
        Next
    End Sub

    '--Borrar archivo
    Private Sub btnBorrarDoc_Click(sender As Object, e As EventArgs)
        For Each it In sender.subitems
            If it.text = "Borrar" Then
                ' it.enabled = Agregar Or Editar 'PENDIENTE
                it.enabled = True
            End If
        Next
    End Sub
    Private Sub LimpiarCtrlDocs()
        txtDescArch1.Text = ""
        lblTpoDoc1.Text = ""
        txtDescArch2.Text = ""
        lblTpoDoc2.Text = ""
        txtDescArch3.Text = ""
        lblTpoDoc3.Text = ""
        txtDescArch4.Text = ""
        lblTpoDoc4.Text = ""
        txtDescArch5.Text = ""
        lblTpoDoc5.Text = ""
        txtDescArch6.Text = ""
        lblTpoDoc6.Text = ""
        txtDescArch7.Text = ""
        lblTpoDoc7.Text = ""
        txtDescArch8.Text = ""
        lblTpoDoc8.Text = ""
        itmDocs.SubItems.Clear() ' Limpia los items
    End Sub

    '---Proceso para actualizar los documentos del personal
    Public Sub ActualizaDocumentos(ByVal Reloj As String, ByVal ValorDesc As String, ByVal ValorTipo As String, ByVal Consec As String)
        Try
            Dim Archivos As String = ""
            Dim tipoArch As String = ValorTipo.Trim
            Dim dtExisteRec As DataTable = sqlExecute("select  top 1 * from ARCHIVOS where reloj='" & Reloj.Trim & "' and consec='" & Consec.Trim & "'", "PERSONAL")
            If (Not dtExisteRec.Columns.Contains("Error") And dtExisteRec.Rows.Count >= 1) Then
                '----------------UPDATE
                Archivos = ""
                'For Each sit As DevComponents.DotNetBar.ButtonItem In itmDocs.SubItems
                '    Archivos = Archivos & sit.Tooltip & ";"
                'Next
                Dim Z As Integer = 0
                Dim NoConsec As Integer = Convert.ToInt32(Consec)
                For Each sit As DevComponents.DotNetBar.ButtonItem In itmDocs.SubItems
                    Archivos = Archivos & sit.Tooltip
                    Z += 1
                    If (Z <> NoConsec) Then
                        Archivos = ""
                    Else
                        Archivos = Archivos
                        GoTo SalirCicloUpdate
                    End If
                Next
SalirCicloUpdate:
                If (Archivos.Trim <> "") Then 'Actualizar solo si hay un archivo
                    tipoArch = Archivos.Split(".")(1).ToUpper ' Obtenemos el tipo de archivo
                    Dim QueryUpdate As String = "Update ARCHIVOS set nombre_arch='" & Archivos.Trim & "',desc_arch='" & ValorDesc.Trim & "',tipo_arch='" & tipoArch.Trim & "' where reloj='" & Reloj.Trim & "' AND consec='" & Consec.Trim & "'"
                    sqlExecute(QueryUpdate, "PERSONAL")
                End If
            Else
                '----------------INSERTAR
                Archivos = ""
                'For Each sit As DevComponents.DotNetBar.ButtonItem In itmDocs.SubItems
                '    Archivos = Archivos & sit.Tooltip & ";"
                'Next
                Dim Z As Integer = 0
                Dim NoConsec As Integer = Convert.ToInt32(Consec)
                For Each sit As DevComponents.DotNetBar.ButtonItem In itmDocs.SubItems
                    Archivos = Archivos & sit.Tooltip
                    Z += 1
                    If (Z <> NoConsec) Then
                        Archivos = ""
                    Else
                        Archivos = Archivos
                        GoTo SalirCicloInsert
                    End If
                Next
SalirCicloInsert:
                If (Archivos.Trim <> "") Then ' Insertar solo si hay un archivo
                    tipoArch = Archivos.Split(".")(1).ToUpper '---Obtener el tipo de archivo
                    Dim QueryInsert As String = "INSERT into ARCHIVOS VALUES('" & Reloj.Trim & "','" & Consec & "','" & Archivos.Trim & "','" & ValorDesc.ToString.Trim & "','" & tipoArch.Trim & "')"
                    sqlExecute(QueryInsert, "PERSONAL")
                End If

            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnEditaEscolaridad_Click(sender As Object, e As EventArgs) Handles btnEditaEscolaridad.Click

    End Sub

    Private Sub btnEditaFamilia_Click(sender As Object, e As EventArgs) Handles btnEditaFamilia.Click

    End Sub

    Private Sub dgFamiliares_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgFamiliares.CellDoubleClick
        '---- Editar ó Eliminar registro seleccionado 
        If Not Editar Then
            Dim Respuesta As Windows.Forms.DialogResult
            Respuesta = frmEditaFaEsDA.ShowDialog(Me)

            RefrescaFamiliares(txtReloj.Text.Trim) ' Actualiza dgv

            If Respuesta = Windows.Forms.DialogResult.Abort Then
                MessageBox.Show("Hubo un error durante el proceso, y los cambios no pudieron ser guardados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf Respuesta = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        End If

    End Sub

    Private Sub dgEscolaridad_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgEscolaridad.CellDoubleClick
        '----Editar o elminar registro seleccionado de escolaridad

        If Not Editar Then
            Dim Respuesta As Windows.Forms.DialogResult
            Reloj2 = txtReloj.Text.Trim
            Respuesta = frmEditaEscolaridad.ShowDialog(Me)

            RefrescaEscolaridad(txtReloj.Text.Trim) ' Actualiza dgv

            If Respuesta = Windows.Forms.DialogResult.Abort Then
                MessageBox.Show("Hubo un error durante el proceso, y los cambios no pudieron ser guardados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            ElseIf Respuesta = Windows.Forms.DialogResult.Cancel Then
                Exit Sub
            End If
        End If

    End Sub

    ''' <summary>
    ''' 'Método para cargar periodos al comboBox en la captura de vacaciones para el pago de la nómina
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Private Sub CargarPeriodos(Optional ByVal fecha As Date = Nothing)
        Try
            Dim fHoy As Date = Date.Now, Query As String = "", dtTemp As New DataTable, dtPeriodos As New DataTable

            If fecha = Nothing Then fecha = fHoy

            Query = "select top 1 ANO+PERIODO as 'seleccionado' from TA.dbo.periodos where FECHA_INI<='" & FechaSQL(fecha) & "' and FECHA_FIN>='" & FechaSQL(fecha) & "'"
            dtTemp = sqlExecute(Query, "TA")

            If Not dtTemp.Columns.Contains("Error") And dtTemp.Rows.Count > 0 Then

                Query = "select distinct ano+periodo as seleccionado,ANO,PERIODO,FECHA_INI,FECHA_FIN from periodos order by ANO desc,periodo"
                dtPeriodos = sqlExecute(Query, "TA")
                cmbPeriodos.DataSource = dtPeriodos

                cmbPeriodos.SelectedValue = dtTemp.Rows(0).Item("seleccionado")
                seleccionado = dtTemp.Rows(0).Item("seleccionado")
            Else
                cmbPeriodos.SelectedIndex = 0
                seleccionado = Nothing
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub txtFechaDe_ValueChanged(sender As Object, e As EventArgs) Handles txtFechaDe.ValueChanged
        CargarPeriodos(txtFechaDe.Value)
    End Sub

    Private Sub cmbPeriodos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPeriodos.SelectedValueChanged

    End Sub

    Private Sub cmbPeriodos_SelectionChanging(sender As Object, e As DevComponents.AdvTree.AdvTreeNodeCancelEventArgs) Handles cmbPeriodos.SelectionChanging

    End Sub

    Private Sub cmbTipoMovInfonavit_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipoMovInfonavit.SelectedValueChanged

        Dim Mov As String
        Dim Cred As String
        Dim Activo As Boolean
        Dim Inicio As Date
        Dim fecha_aplicacion As Date
        Dim Mensaje As String

        ' afectaCredInfoActivo = False ' AOS: Indica si va a afectar al credito info actual
        ' editaInfo = False ' AOS Indica que no va a editar el infonavit

        '== Para cálculo de recuperación de infonavit           Ernesto         01-feb-2023
        'diccionarioInfonavit("TipoMovimiento") = 0
        ' pnlRecuperacion.Enabled = False
        'pnlRecuperacion.Visible = False

        Try
            If Not (Editar Or Nuevo) Or cmbTipoMovInfonavit.SelectedValue Is Nothing Then Exit Sub
            'BorraInfonavit = False
            Mov = cmbTipoMovInfonavit.SelectedValue
            'MCR 20210629
            If Mov = "99" Then
                dtTemp = sqlExecute("SELECT TOP 2 * FROM INFONAVIT WHERE reloj = '" & txtReloj.Text & "' ORDER BY ACTIVO DESC,fecha_aplicacion DESC,fechahora DESC")
                If dtTemp.Rows.Count > 1 Then
                    If dtTemp.Rows(1)("cod_movimiento") = "16" Then
                        Mensaje = "El movimiento anterior al del día " & _
                                           FechaCortaLetra(dtTemp.Rows(0)("fecha_aplicacion")) & ", " & vbCrLf & _
                                           " es una suspensión, por lo que el crédito no quedará activo. " & _
                                           "¿Desea continuar?"
                    Else
                        Mensaje = "Al borrar el movimiento de Infonavit del día " & _
                                           FechaCortaLetra(dtTemp.Rows(0)("fecha_aplicacion")) & ", " & vbCrLf & "el movimiento " & _
                                           dtTemp.Rows(1)("cod_movimiento") & " del día " & _
                                           FechaCortaLetra(dtTemp.Rows(1)("fecha_aplicacion")) & ", será el nuevo registro activo. " & _
                                           "¿Desea continuar?"
                    End If

                ElseIf dtTemp.Rows.Count > 0 Then
                    Mensaje = "Al borrar el movimiento de Infonavit del día " & _
                                       FechaMediaLetra(dtTemp.Rows(0)("fecha_aplicacion")) & ", no quedará registro activo. ¿Desea continuar?"
                End If

                If dtTemp.Rows.Count = 0 Then
                    MessageBox.Show("No hay movimientos de Infonavit a borrar", "Borrar registro Infonavit")
                Else
                    If MessageBox.Show(Mensaje, "Borrar registro Infonavit", MessageBoxButtons.OKCancel, _
                                           MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then

                        'BorraInfonavit = True
                        dgvInfonavit.Rows.RemoveAt(0)
                        If dgvInfonavit.Rows.Count > 0 Then
                            dgvInfonavit.Rows(0).Cells("colActivoCred").Value = IsDBNull(dgvInfonavit.Rows(0).Cells("colSuspensionCred").Value)
                        End If
                    Else
                        cmbTipoMovInfonavit.SelectedValue = ""
                    End If
                    Exit Sub
                End If
            End If
            '***** MCR 20210629

            'MCR 20210519
            ' pnlFechaAplicacion.Visible = Mov <> 0
            ' pnlInfoFactor.Visible = Mov <> 0
            ' pnlInfoTipoCred.Visible = Mov <> 0

            ' pnlInfoFInicio.Visible = False ' AOS 2022-05-18: Para que no se muestre la fecha de inicio de crédito
            ' pnlInfoFSuspension.Visible = False ' Aos 2022-06-02: Para que no muestre tampoco la fecha de suspension, solo la de aplicación


            '***** MCR 20210519
            Dim HayRegistro As Boolean = True ' AOS 2022-06-02
            '  dtpFechaSuspensionCreditoInfonavit.Value = Nothing
            dtTemp = sqlExecute("SELECT top 1 infonavit,activo,inicio_cre,fecha_aplicacion FROM infonavit WHERE reloj = '" & txtReloj.Text & "' ORDER BY activo DESC,fecha_aplicacion DESC,fechahora DESC")
            If dtTemp.Rows.Count > 0 Then
                Cred = dtTemp.Rows(0)("infonavit")
                Activo = dtTemp.Rows(0)("activo")
                Inicio = dtTemp.Rows(0)("inicio_cre")
                fecha_aplicacion = dtTemp.Rows(0)("fecha_aplicacion")

            Else
                txtNumeroCredito.Text = ""
                Activo = False
                HayRegistro = False
            End If

            Select Case Mov
                Case 15
                    'Nuevo crédito
                    If Activo Then
                        MessageBox.Show("No se puede agregar un nuevo crédito cuando hay uno activo.", "Pida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        cmbTipoMovInfonavit.SelectedValue = ""
                        Exit Sub
                    End If

                    '----AOS 2022-02-06: Se agrega validacion para que no permita un inicio de credito (15) cuando ya hay uno previamente
                    Dim dtValidaIniCred As DataTable = sqlExecute("SELECT top 1 infonavit,activo,inicio_cre,cod_movimiento FROM infonavit WHERE reloj = '" & txtReloj.Text & "' and cod_movimiento in('15','30') ORDER BY activo DESC,fecha_aplicacion DESC,fechahora DESC", "PERSONAL")
                    If (Not dtValidaIniCred.Columns.Contains("Error") And dtValidaIniCred.Rows.Count > 0) Then
                        Dim incio_cred As String = ""
                        Try : incio_cred = FechaSQL(dtValidaIniCred.Rows(0).Item("inicio_cre")) : Catch ex As Exception : incio_cred = "" : End Try
                        If incio_cred <> "" Then
                            MessageBox.Show("No se puede agregar un inicio de crédito (15), cuando ya existe un inicio de crédito con fecha del '" & incio_cred & "'", "Pida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            cmbTipoMovInfonavit.SelectedValue = ""
                            Exit Sub
                        End If
                    End If

                    txtNumeroCredito.Text = ""
                    cmbTipoInfonavit.SelectedValue = 0
                    txtFactorDeDescuentoInfonavit.Text = 0
                    dtpFechaInicioCreditoInfonavit.Value = Now.Date


                    txtNumeroCredito.Focus()

                    'Label38.Text = "Fecha de inicio de crédito"

                    '== Para cálculo de recuperación de infonavit           Ernesto         01-feb-2023
                    'diccionarioInfonavit("TipoMovimiento") = cmbTipoMovInfonavit.SelectedValue
                    'CalculoRecuperacionesInfonavit(False)
                    'pnlRecuperacion.Enabled = True
                    'pnlRecuperacion.Visible = True
                Case 16
                    'Suspensión
                    If Not Activo Then
                        MessageBox.Show("No hay crédito activo para suspender.", "Pida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        cmbTipoMovInfonavit.SelectedValue = ""
                        Exit Sub
                    End If

                    txtNumeroCredito.Text = Cred
                    ' Label38.Text = "Fecha de suspensión"
                    'dtpFechaSuspensionCreditoInfonavit.Enabled = True
                    'dtpFechaSuspensionCreditoInfonavit.Value = Today.Date

                    'dtpFechaSuspensionCreditoInfonavit.Focus()
                Case 17
                    'Reinicio
                    If Activo Then
                        MessageBox.Show("Ya hay un crédito activo, no se puede reiniciar.", "Pida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        cmbTipoMovInfonavit.SelectedValue = ""
                        Exit Sub
                    End If

                    If (Not HayRegistro) Then
                        MessageBox.Show("No se puede agregar un reinicio de descuento ya que no hay un inicio de crédito previamente.", "Pida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        cmbTipoMovInfonavit.SelectedValue = ""
                        Exit Sub
                    End If
                    txtNumeroCredito.Text = Cred
                    dtpFechaInicioCreditoInfonavit.Value = Inicio
                    cmbTipoInfonavit.Focus()
                    ' Label38.Text = "Fecha de aplicación"

                    '== Para cálculo de recuperación de infonavit           Ernesto         01-feb-2023
                    'diccionarioInfonavit("TipoMovimiento") = cmbTipoMovInfonavit.SelectedValue
                    'CalculoRecuperacionesInfonavit(False)
                    'pnlRecuperacion.Enabled = True
                    'pnlRecuperacion.Visible = True

                Case 18
                    'Modif. tipo descuento
                    If Not Activo Then
                        MessageBox.Show("No hay crédito activo para modificar.", "Pida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        cmbTipoMovInfonavit.SelectedValue = ""
                        Exit Sub
                    End If

                    If (Activo) Then ' AO : 12/05/2022 Preguntar si desean afectar al mismo registro activo
                        'If MessageBox.Show("¿Al editar el tipo de descuento, estaría agregando un nuevo registro para informar al SUA, esta de acuerdo?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then afectaCredInfoActivo = True
                    End If

                    cmbTipoInfonavit.Focus()
                    ' Label38.Text = "Fecha de aplicación"
                Case 19
                    'Modif. valor descuento
                    If Not Activo Then
                        MessageBox.Show("No hay crédito activo para modificar.", "Pida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        cmbTipoMovInfonavit.SelectedValue = ""
                        Exit Sub
                    End If

                    If (Activo) Then ' AO : 12/05/2022 Preguntar si desean afectar al mismo registro activo
                        '  If MessageBox.Show("¿Al editar el valor de descuento, estaría agregando un nuevo registro para informar al SUA, esta de acuerdo?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then afectaCredInfoActivo = True
                    End If

                    txtFactorDeDescuentoInfonavit.Focus()
                    ' Label38.Text = "Fecha de aplicación"
                Case 20
                    'Modif. núm. crédito
                    If Not Activo Then
                        MessageBox.Show("No hay crédito activo para modificar.", "Pida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        cmbTipoMovInfonavit.SelectedValue = ""
                        Exit Sub
                    End If

                    If (Activo) Then ' AO : 12/05/2022 Preguntar si desean afectar al mismo registro activo
                        ' If MessageBox.Show("¿Al editar el número de crédito de infonavit, estaría agregando un nuevo registro para informar al SUA, esta de acuerdo?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then afectaCredInfoActivo = True
                    End If

                    txtNumeroCredito.Focus()
                    ' Label38.Text = "Fecha de aplicación"
            End Select

            '---Aos cargar el valor predeterminado que trae la fecha de aplicación que es la correcta
            'Try
            '    dtpFechaAplicacion.Value = fecha_aplicacion
            'Catch ex As Exception
            '    dtpFechaAplicacion.Value = Now.Date
            'End Try


            'pnlInfoFInicio.Enabled = (Mov = 15 Or Mov = 17)
            'pnlInfoTipoCred.Enabled = (Mov = 15 Or Mov = 17 Or Mov = 18)
            'pnlInfoFactor.Enabled = (Mov = 15 Or Mov = 17 Or Mov = 18 Or Mov = 19)
            'pnlFechaAplicacion.Enabled = (Mov <> 0)


            txtNumeroCredito.Enabled = (Mov = 15 Or Mov = 17 Or Mov = 20)

            txtNumeroCredito.ReadOnly = Not (Mov = 15 Or Mov = 17 Or Mov = 20) '2024-01-04: Se pueda editar el #Cred en el Reinicio de descuento (tipoMov= 17)

            ' editaInfo = True ' AOS 2022-06-14 Indica si va a editar el infonavit

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub

    '====Mostrar periodo de pago programado
    Private Sub dgVacaciones_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgVacaciones.CellDoubleClick
        Dim _rj As String = "", comentario As String = "", fecha_ini As String = "", fecha_fin As String = "", NUMCREDITO As String = "", query As String = "", dtAnioPer As New DataTable
        Dim _anio_per As String = "", dtFechasPeriodo As New DataTable, _mensaje_final As String = ""
        Dim ano As String = "", periodo As String = "", fecha_ini_per As String = "", fecha_fin_per As String = "", fecha_pago_per As String = ""

        _rj = txtReloj.Text.Trim
        Try : comentario = dgVacaciones.Item("colComentario", dgVacaciones.CurrentRow.Index).Value.ToString.Trim : Catch ex As Exception : comentario = "" : End Try
        Try : fecha_ini = FechaSQL(dgVacaciones.Item("colFechaIni", dgVacaciones.CurrentRow.Index).Value.ToString.Trim) : Catch ex As Exception : fecha_ini = "" : End Try
        Try : fecha_fin = FechaSQL(dgVacaciones.Item("colFechaFin", dgVacaciones.CurrentRow.Index).Value.ToString.Trim) : Catch ex As Exception : fecha_fin = "" : End Try

        If comentario = "VACACIONES" Then
            '===Buscar en miscelaneos el anio y periodo que se mandó para pago:
            NUMCREDITO = fecha_ini & " al " & fecha_fin
            query = "select top 1 ano+PERIODO as 'ano_per' from nomina.dbo.ajustes_nom where reloj ='" & _rj & "' and CONCEPTO='DIASVA' and NUMCREDITO='" & NUMCREDITO & "'"
            dtAnioPer = sqlExecute(query, "NOMINA")
            If Not dtAnioPer.Columns.Contains("Error") And dtAnioPer.Rows.Count > 0 Then
                Try : _anio_per = dtAnioPer.Rows(0).Item("ano_per").ToString.Trim : Catch ex As Exception : _anio_per = "" : End Try

                '==Buscar fechas del periodo en el que se programó para pago
                query = "select ano,periodo,FECHA_INI,FECHA_FIN,FECHA_PAGO from ta.dbo.periodos where ano+periodo='" & _anio_per & "'"
                dtFechasPeriodo = sqlExecute(query, "TA")
                If Not dtFechasPeriodo.Columns.Contains("Error") And dtFechasPeriodo.Rows.Count > 0 Then
                    Try : ano = dtFechasPeriodo.Rows(0).Item("ano").ToString.Trim : Catch ex As Exception : ano = "" : End Try
                    Try : periodo = dtFechasPeriodo.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : periodo = "" : End Try
                    Try : fecha_ini_per = FechaSQL(dtFechasPeriodo.Rows(0).Item("FECHA_INI").ToString.Trim) : Catch ex As Exception : fecha_ini_per = "" : End Try
                    Try : fecha_fin_per = FechaSQL(dtFechasPeriodo.Rows(0).Item("FECHA_FIN").ToString.Trim) : Catch ex As Exception : fecha_fin_per = "" : End Try
                    Try : fecha_pago_per = FechaSQL(dtFechasPeriodo.Rows(0).Item("FECHA_PAGO").ToString.Trim) : Catch ex As Exception : fecha_pago_per = "" : End Try

                End If

                _mensaje_final = "Periodo programado para pago: " & ano & "-" & periodo & vbCrLf
                _mensaje_final &= "Del " & fecha_ini_per & " al " & fecha_fin_per & ", fecha de pago: " & fecha_pago_per & ""


                MessageBox.Show(_mensaje_final, "P.I.D.A.", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                MessageBox.Show("No se encontró el periodo para pago de estas vacaciones seleccionadas", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End If

        End If

    End Sub
End Class