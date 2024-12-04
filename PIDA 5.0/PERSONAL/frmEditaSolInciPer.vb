Public Class frmEditaSolInciPer

    Dim query As String = "", reloj As String = "", tipo_mov As Integer = -1, rest_query As String = ""
    Dim _chkSup_antes As Boolean = False, _chk_Rh_antes As Boolean = False, _chk_GteOp_antes As Boolean = False, _chkGteGral_antes As Boolean = False
    Dim dtInfoReporte As New DataTable, fecha_inicio As String = "", cod_comp As String = ""

    Private Sub frmEditaSolInciPer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            '=====HERE AOS 2024-08-30
            '===Para traerse los datos:
            Dim _usuario_ As String = "", nombre As String = "", movimiento As String = ""
            Dim aprob_sup As Integer = 0, aprob_rh As Integer = 0, aprob_gteop As Integer = 0, aprob_gtegral As Integer = 0
            Dim dtInfoAprobraciones As New DataTable

            Try : _usuario_ = frmListInciPers.dgvPendInci.Item("col_usuario", frmListInciPers.dgvPendInci.CurrentRow.Index).Value.ToString.Trim : Catch ex As Exception : _usuario_ = "" : End Try
            Try : reloj = frmListInciPers.dgvPendInci.Item("col_reloj", frmListInciPers.dgvPendInci.CurrentRow.Index).Value.ToString.Trim : Catch ex As Exception : reloj = "" : End Try
            Try : nombre = frmListInciPers.dgvPendInci.Item("col_nombre", frmListInciPers.dgvPendInci.CurrentRow.Index).Value.ToString.Trim : Catch ex As Exception : nombre = "" : End Try
            Try : movimiento = frmListInciPers.dgvPendInci.Item("col_tipo_mov", frmListInciPers.dgvPendInci.CurrentRow.Index).Value.ToString.Trim : Catch ex As Exception : movimiento = "" : End Try
            Try : fecha_inicio = FechaSQL(frmListInciPers.dgvPendInci.Item("col_fini", frmListInciPers.dgvPendInci.CurrentRow.Index).Value.ToString.Trim) : Catch ex As Exception : fecha_inicio = "" : End Try

            '===Obtener tipo de perfil de acuerdo al usuario que ingresó
            Dim _perfil As String = Perfil.ToString.ToUpper.Trim

            If _perfil.Contains("SUPERV") Then ' SUPERVISOR
                chkSuperv.Enabled = True : chkRH.Enabled = False : chkGteOP.Enabled = False : chkGteGral.Enabled = False
            ElseIf _perfil.Contains("SUPRH") Then ' RH
                chkSuperv.Enabled = False : chkRH.Enabled = True : chkGteOP.Enabled = True : chkGteGral.Enabled = False
            ElseIf (_perfil.Contains("CTE") Or Usuario = "mcampos_sup") Then ' GTE GRAL 
                chkSuperv.Enabled = False : chkRH.Enabled = False : chkGteOP.Enabled = False : chkGteGral.Enabled = True
            ElseIf _perfil.Contains("ADMINISTRADOR") Then ' Administrador
                chkSuperv.Enabled = True : chkRH.Enabled = True : chkGteOP.Enabled = True : chkGteGral.Enabled = True
            Else ' Ninguno de los anteriores
                chkSuperv.Enabled = False : chkRH.Enabled = False : chkGteOP.Enabled = False : chkGteGral.Enabled = False
            End If

            '===Obtenido el tipo de perfil, obtener las aprobaciones: aprob_sup, aprob_rh, aprob_gteop y aprob_gtegral para saber que ya está aprobado y que no
            If movimiento.ToString.ToUpper.Trim.Contains("VACACI") Then
                tipo_mov = 0
                rest_query = " and f_ini_vac='" & fecha_inicio & "'"
            ElseIf movimiento.ToString.ToUpper.Trim.Contains("CON GOCE") Then
                tipo_mov = 1
                rest_query = " and f_ini='" & fecha_inicio & "'"
            ElseIf movimiento.ToString.ToUpper.Trim.Contains("SIN GOCE") Then
                tipo_mov = 2
                rest_query = " and f_ini='" & fecha_inicio & "'"
            ElseIf movimiento.ToString.ToUpper.Trim.Contains("TOLERAN") Then
                tipo_mov = 3
                rest_query = " and f_ini='" & fecha_inicio & "'"
            ElseIf movimiento.ToString.ToUpper.Trim.Contains("FALTA INJUSTIFICADA") Then
                tipo_mov = 4
                rest_query = " and f_ini='" & fecha_inicio & "'"
            ElseIf movimiento.ToString.ToUpper.Trim.Contains("FALTA JUSTIFICADA") Then
                tipo_mov = 5
                rest_query = " and f_ini='" & fecha_inicio & "'"
            End If

            query = "select * from solicitud_incidencias_personal where reloj='" & reloj & "' and tipo_movimiento=" & tipo_mov & rest_query
            dtInfoAprobraciones = sqlExecute(query, "PERSONAL")
            If Not dtInfoAprobraciones.Columns.Contains("Error") And dtInfoAprobraciones.Rows.Count > 0 Then
                Try : aprob_sup = dtInfoAprobraciones.Rows(0).Item("aprob_sup") : Catch ex As Exception : aprob_sup = 0 : End Try
                Try : aprob_rh = dtInfoAprobraciones.Rows(0).Item("aprob_rh") : Catch ex As Exception : aprob_rh = 0 : End Try
                Try : aprob_gteop = dtInfoAprobraciones.Rows(0).Item("aprob_gteop") : Catch ex As Exception : aprob_gteop = 0 : End Try
                Try : aprob_gtegral = dtInfoAprobraciones.Rows(0).Item("aprob_gtegral") : Catch ex As Exception : aprob_gtegral = 0 : End Try
                Try : cod_comp = dtInfoAprobraciones.Rows(0).Item("cod_comp") : Catch ex As Exception : cod_comp = "" : End Try
            End If


            '===Mostrar habilitados los checks de acuerdo al perfil, ejempo, si entra el usario con perfil superv, solo puede activar el check de superv, y los otros tienen que aparecer deshabilitados
            If aprob_sup = 1 Then chkSuperv.Enabled = False : chkSuperv.Checked = True Else chkSuperv.Checked = False
            If aprob_rh = 1 Then chkRH.Enabled = False : chkRH.Checked = True Else chkRH.Checked = False
            If aprob_gteop = 1 Then chkGteOP.Enabled = False : chkGteOP.Checked = True Else chkGteOP.Checked = False
            If aprob_gtegral = 1 Then chkGteGral.Enabled = False : chkGteGral.Checked = True Else chkGteGral.Checked = False


            '====Obtener estados de checks
            _chkSup_antes = chkSuperv.CheckState
            _chk_Rh_antes = chkRH.CheckState
            _chk_GteOp_antes = chkGteOP.CheckState
            _chkGteGral_antes = chkGteGral.CheckState

            btnAceptar.Enabled = False


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub ButtonX2_Click(sender As Object, e As EventArgs) Handles ButtonX2.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            '===== Guardar aprobación de acuerdo al perfil
            Dim _chkSup_Desp As Boolean = chkSuperv.CheckState, _chk_Rh_Desp As Boolean = chkRH.CheckState, _chk_GteOp_Desp As Boolean = chkGteOP.CheckState, _chkGteGral_Desp As Boolean = chkGteGral.CheckState
            Dim query_campo_apro As String = "", dtAllAprob As New DataTable

            If _chkSup_antes <> _chkSup_Desp Then query_campo_apro = "aprob_sup=1"
            If _chk_Rh_antes <> _chk_Rh_Desp Then query_campo_apro = "aprob_rh=1"
            If _chk_GteOp_antes <> _chk_GteOp_Desp Then query_campo_apro = "aprob_gteop=1"
            If _chkGteGral_antes <> _chkGteGral_Desp Then query_campo_apro = "aprob_gtegral=1"

            If (_chk_Rh_antes <> _chk_Rh_Desp) And (_chk_GteOp_antes <> _chk_GteOp_Desp) Then
                query_campo_apro = "aprob_rh=1,aprob_gteop=1"
            End If



            If query_campo_apro <> "" Then
                If MessageBox.Show("¿Está seguro de realizar esta aprobación?", "P.I.D.A", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    query = "update solicitud_incidencias_personal set " & query_campo_apro & " where reloj='" & reloj & "' and tipo_movimiento=" & tipo_mov & rest_query
                    sqlExecute(query, "PERSONAL")
                    MessageBox.Show("Se guardó aprobación correctamente", "P.I.D.A.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Ya se había aprobado anteriormente esta solicitud", "P.I.D.A.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Me.Close()
                Exit Sub
            End If


            '=====Validar si ya fueron aprobados por todos, para actualizar aplicado= 1
            query = "select * from solicitud_incidencias_personal where isnull(aprob_sup,0)=1 and isnull(aprob_rh,0)=1 and isnull(aprob_gteop,0)=1 and isnull(aprob_gtegral,0)=1 " & _
                " and reloj='" & reloj & "' and tipo_movimiento=" & tipo_mov & rest_query
            dtAllAprob = sqlExecute(query, "PERSONAL")
            If Not dtAllAprob.Columns.Contains("Error") And dtAllAprob.Rows.Count > 0 Then

                '====HERE 2024-09-02
                '====Actualizar aplicado=1
                query = "update solicitud_incidencias_personal set aplicado=1 where reloj='" & reloj & "' and tipo_movimiento=" & tipo_mov & rest_query
                sqlExecute(query, "PERSONAL")

                '=====Preguntar si se desea mandar a imprimir formato, y actualizar impreso= 1
                If MessageBox.Show("¿Esta incidencia ya ha sido aprobada por todos los niveles, desea generar el formato para su impresión o guardado?", "P.I.D.A", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then

                    '====Probar reporte
                    Dim fecha_ini As Date = Date.Parse(fecha_inicio)
                    dtInfoReporte.Clear() 'Limpiar dtInfoReporte
                    GenDataRepInciPers(reloj, tipo_mov, fecha_ini, cod_comp, dtInfoReporte)
                    frmVistaPrevia.LlamarReporte("Reporte para incidencias del personal", dtInfoReporte)
                    frmVistaPrevia.ShowDialog()

                    query = "update solicitud_incidencias_personal set impreso=1 where reloj='" & reloj & "' and tipo_movimiento=" & tipo_mov & rest_query
                    sqlExecute(query, "PERSONAL")


                    Me.Close()
                    Exit Sub

                Else
                    Me.Close()
                    Exit Sub
                End If

            Else
                Me.Close()
                Exit Sub
            End If



        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub chkSuperv_CheckedChanged(sender As Object, e As EventArgs) Handles chkSuperv.CheckedChanged
        If chkSuperv.CheckState = CheckState.Checked Then btnAceptar.Enabled = True Else btnAceptar.Enabled = False
    End Sub

    Private Sub chkSuperv_CheckStateChanged(sender As Object, e As EventArgs) Handles chkSuperv.CheckStateChanged
    End Sub

    Private Sub chkRH_CheckedChanged(sender As Object, e As EventArgs) Handles chkRH.CheckedChanged
        If chkRH.CheckState = CheckState.Checked Then btnAceptar.Enabled = True Else btnAceptar.Enabled = False
    End Sub

    Private Sub chkGteOP_CheckedChanged(sender As Object, e As EventArgs) Handles chkGteOP.CheckedChanged
        If chkGteOP.CheckState = CheckState.Checked Then btnAceptar.Enabled = True Else btnAceptar.Enabled = False
    End Sub

    Private Sub chkGteGral_CheckedChanged(sender As Object, e As EventArgs) Handles chkGteGral.CheckedChanged
        If chkGteGral.CheckState = CheckState.Checked Then btnAceptar.Enabled = True Else btnAceptar.Enabled = False
    End Sub

    ''' <summary>
    ''' 'Método para generar información para mostrar reporte de incidencias del personal
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub GenDataRepInciPers(ByVal _rj As String, _tipo_mov As String, _fini As Date, _cod_comp As String, dtInfoReporte As DataTable)
        ' _tipo_mov = 0 --> Vacacion ; 1 --> PCG ; 2 --> PSG ; 3 --> Tolerancia ; 4--> FInj ; 5--> FJ
        Try
            Dim Query As String = "", dtInfoRegistro As New DataTable, dtPathFirmas As New DataTable, path_firmas As String = "", QSQL As String = "", dtRjSuperv As New DataTable

            If _tipo_mov = 0 Then
                QSQL = "f_ini_vac='" & FechaSQL(_fini) & "'"
            Else
                QSQL = "f_ini='" & FechaSQL(_fini) & "'"
            End If

            Query = "select * from solicitud_incidencias_personal where cod_comp='" & _cod_comp & "' and reloj='" & _rj & "' and tipo_movimiento=" & _tipo_mov & " and " & QSQL
            dtInfoRegistro = sqlExecute(Query, "PERSONAL")


            If Not dtInfoRegistro.Columns.Contains("Error") And dtInfoRegistro.Rows.Count > 0 Then

                '====Firmas
                dtPathFirmas = sqlExecute("SELECT path_firmas_inci_pers from parametros", "PERSONAL")
                If dtPathFirmas.Rows.Count > 0 Then Try : path_firmas = dtPathFirmas.Rows(0).Item("path_firmas_inci_pers").ToString.Trim : Catch ex As Exception : path_firmas = "" : End Try


                If Not dtInfoReporte.Columns.Contains("reloj") Then dtInfoReporte.Columns.Add("reloj", Type.GetType("System.String"))
                If Not dtInfoReporte.Columns.Contains("nombre_empleado") Then dtInfoReporte.Columns.Add("nombre_empleado", Type.GetType("System.String"))
                If Not dtInfoReporte.Columns.Contains("depto") Then dtInfoReporte.Columns.Add("depto", Type.GetType("System.String"))
                If Not dtInfoReporte.Columns.Contains("alta") Then dtInfoReporte.Columns.Add("alta", Type.GetType("System.String"))
                If Not dtInfoReporte.Columns.Contains("puesto") Then dtInfoReporte.Columns.Add("puesto", Type.GetType("System.String"))
                If Not dtInfoReporte.Columns.Contains("tipo_movimiento") Then dtInfoReporte.Columns.Add("tipo_movimiento", Type.GetType("System.Int32"))
                If Not dtInfoReporte.Columns.Contains("periodo") Then dtInfoReporte.Columns.Add("periodo", Type.GetType("System.String"))
                If Not dtInfoReporte.Columns.Contains("dias") Then dtInfoReporte.Columns.Add("dias", Type.GetType("System.String"))
                If Not dtInfoReporte.Columns.Contains("f_ini") Then dtInfoReporte.Columns.Add("f_ini", Type.GetType("System.String"))
                If Not dtInfoReporte.Columns.Contains("f_fin") Then dtInfoReporte.Columns.Add("f_fin", Type.GetType("System.String"))
                If Not dtInfoReporte.Columns.Contains("dias_vac_pend_gozar") Then dtInfoReporte.Columns.Add("dias_vac_pend_gozar", Type.GetType("System.String"))
                If Not dtInfoReporte.Columns.Contains("motivo") Then dtInfoReporte.Columns.Add("motivo", Type.GetType("System.String"))
                If Not dtInfoReporte.Columns.Contains("fecha_registro") Then dtInfoReporte.Columns.Add("fecha_registro", Type.GetType("System.String"))
                If Not dtInfoReporte.Columns.Contains("firma_empleado") Then dtInfoReporte.Columns.Add("firma_empleado", Type.GetType("System.String"))
                If Not dtInfoReporte.Columns.Contains("firma_superv") Then dtInfoReporte.Columns.Add("firma_superv", Type.GetType("System.String"))
                If Not dtInfoReporte.Columns.Contains("firma_rh") Then dtInfoReporte.Columns.Add("firma_rh", Type.GetType("System.String"))
                If Not dtInfoReporte.Columns.Contains("firma_gte_op") Then dtInfoReporte.Columns.Add("firma_gte_op", Type.GetType("System.String"))
                If Not dtInfoReporte.Columns.Contains("firma_gte_gral") Then dtInfoReporte.Columns.Add("firma_gte_gral", Type.GetType("System.String"))
                If Not dtInfoReporte.Columns.Contains("periodo_vac") Then dtInfoReporte.Columns.Add("periodo_vac", Type.GetType("System.String"))
                If Not dtInfoReporte.Columns.Contains("dias_vac") Then dtInfoReporte.Columns.Add("dias_vac", Type.GetType("System.String"))
                If Not dtInfoReporte.Columns.Contains("f_ini_vac") Then dtInfoReporte.Columns.Add("f_ini_vac", Type.GetType("System.String"))
                If Not dtInfoReporte.Columns.Contains("f_fin_vac") Then dtInfoReporte.Columns.Add("f_fin_vac", Type.GetType("System.String"))
                If Not dtInfoReporte.Columns.Contains("fecha_falta") Then dtInfoReporte.Columns.Add("fecha_falta", Type.GetType("System.String"))
                If Not dtInfoReporte.Columns.Contains("motivo_falta") Then dtInfoReporte.Columns.Add("motivo_falta", Type.GetType("System.String"))


                Dim nombre_empleado As String = "", depto As String = "", alta As String = "", puesto As String = "", tipo_movimiento As Integer = -1, periodo As String = "", dias As String = ""
                Dim f_ini As String = "", f_fin As String = "", dias_vac_pend_gozar As String = "", motivo As String = "", fecha_registro As String = ""
                Dim firma_empleado As String = "", firma_superv As String = "", firma_rh As String = "", firma_gte_op As String = "", firma_gte_gral As String = ""
                Dim periodo_vac As String = "", dias_vac As String = "", f_ini_vac As String = "", f_fin_vac As String = "", fecha_falta As String = ""
                Dim motivo_falta As String = "", rj_superv As String = ""


                Try : nombre_empleado = dtInfoRegistro.Rows(0).Item("nombre").ToString.Trim : Catch ex As Exception : nombre_empleado = "" : End Try
                Try : depto = dtInfoRegistro.Rows(0).Item("depto").ToString.Trim : Catch ex As Exception : depto = "" : End Try
                Try : alta = FechaSQL(dtInfoRegistro.Rows(0).Item("alta")) : Catch ex As Exception : alta = "" : End Try
                Try : puesto = dtInfoRegistro.Rows(0).Item("puesto").ToString.Trim : Catch ex As Exception : puesto = "" : End Try
                Try : tipo_movimiento = dtInfoRegistro.Rows(0).Item("tipo_movimiento") : Catch ex As Exception : tipo_movimiento = -1 : End Try
                Try : periodo = dtInfoRegistro.Rows(0).Item("periodo").ToString.Trim : Catch ex As Exception : periodo = "" : End Try
                Try : dias = dtInfoRegistro.Rows(0).Item("dias").ToString : Catch ex As Exception : dias = "" : End Try
                Try : f_ini = FechaSQL(dtInfoRegistro.Rows(0).Item("f_ini")) : Catch ex As Exception : f_ini = "" : End Try
                Try : f_fin = FechaSQL(dtInfoRegistro.Rows(0).Item("f_fin")) : Catch ex As Exception : f_fin = "" : End Try
                Try : dias_vac_pend_gozar = dtInfoRegistro.Rows(0).Item("dias_vac_pend_gozar").ToString : Catch ex As Exception : dias_vac_pend_gozar = "" : End Try
                Try : motivo = dtInfoRegistro.Rows(0).Item("motivo").ToString.Trim : Catch ex As Exception : motivo = "" : End Try
                Try : fecha_registro = FechaSQL(dtInfoRegistro.Rows(0).Item("f_captura")) : Catch ex As Exception : fecha_registro = "" : End Try
                Try : periodo_vac = dtInfoRegistro.Rows(0).Item("periodo_vac").ToString.Trim : Catch ex As Exception : periodo_vac = "" : End Try
                Try : dias_vac = dtInfoRegistro.Rows(0).Item("dias_vac").ToString : Catch ex As Exception : dias_vac = "" : End Try
                Try : f_ini_vac = FechaSQL(dtInfoRegistro.Rows(0).Item("f_ini_vac")) : Catch ex As Exception : f_ini_vac = "" : End Try
                Try : f_fin_vac = FechaSQL(dtInfoRegistro.Rows(0).Item("f_fin_vac")) : Catch ex As Exception : f_fin_vac = "" : End Try

                '===Cuando sea una incidencia de falta , solo fecha_falta debe de tener valor
                If (tipo_movimiento = 3 Or tipo_movimiento = 4 Or tipo_movimiento = 5) Then
                    Try : fecha_falta = FechaSQL(dtInfoRegistro.Rows(0).Item("f_ini")) : Catch ex As Exception : fecha_falta = "" : End Try
                    motivo_falta = motivo
                    f_ini = "" : f_fin = "" : motivo = "" : dias = "" : periodo = ""
                End If

                '===Firmas

                '===Obtener el reloj del supervisor
                Query = "select reloj from super where COD_SUPER in(select cod_super from personal where reloj='" & _rj & "' and COD_COMP='" & _cod_comp & "' ) and COD_COMP='" & _cod_comp & "'"
                dtRjSuperv = sqlExecute(Query, "PERSONAL")
                If dtRjSuperv.Rows.Count > 0 Then Try : rj_superv = dtRjSuperv.Rows(0).Item("reloj").ToString.Trim : Catch ex As Exception : rj_superv = "" : End Try


                '====Confirman que la firma del empleado debe de salir en blanco ya que se firmará manualmente
                firma_empleado = ""
                '  
                If System.IO.File.Exists(path_firmas & rj_superv & ".jpg") Then firma_superv = path_firmas & rj_superv & ".jpg" Else firma_superv = "" ' Firma de acuerdo al num de reloj del superv
                If System.IO.File.Exists(path_firmas & "rh.jpg") Then firma_rh = path_firmas & "rh.jpg" Else firma_rh = "" ' Firma fija
                If System.IO.File.Exists(path_firmas & "gte_op.jpg") Then firma_gte_op = path_firmas & "gte_op.jpg" Else firma_gte_op = "" ' Firma fija
                If System.IO.File.Exists(path_firmas & "gte_gral.jpg") Then firma_gte_gral = path_firmas & "gte_gral.jpg" Else firma_gte_gral = "" ' Firma fija

                '====NOTA: PEND, de las firmas que pasaron, que definan cual seria la de rh, ya que la de gte_op es la de gaby y ya está, la de gte_gral es la de martin campos y ya está, y que 
                '          estén todas las firmas de supervisores posibles, ya que es depende del empleado cual es su cod_super, y que en la tabla de super ese supervisor el reloj que esté ahí, que la firma se llame de acuerdo a su # de reloj


                dtInfoReporte.Rows.Add({_rj, nombre_empleado, depto, alta, puesto, tipo_movimiento, periodo, dias, f_ini, f_fin, dias_vac_pend_gozar, motivo, fecha_registro, firma_empleado,
                                        firma_superv, firma_rh, firma_gte_op, firma_gte_gral, periodo_vac, dias_vac, f_ini_vac, f_fin_vac, fecha_falta, motivo_falta})


            Else
                MessageBox.Show("No hay información a mostrar", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub

            End If


        Catch ex As Exception

            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("La carga de información generó errores. Si el problema persiste, contacte al administrador del sistema." & _
                             vbCrLf & vbCrLf & "Err.- " & ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

End Class