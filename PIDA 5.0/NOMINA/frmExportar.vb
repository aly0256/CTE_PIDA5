Imports System.IO

Public Class frmExportar
    Dim dtPeriodos As New DataTable
    Dim dtCias As New DataTable

    Private Sub frmExportar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtCias = sqlExecute("SELECT cod_comp,RTRIM(nombre) AS nombre FROM cias ORDER BY cia_default DESC")
        cmbCia.DataSource = dtCias
        cmbTipoPeriodo.SelectedIndex = 0
    End Sub

    Private Function ExportarAjustes(definitiva As Boolean) As Windows.Forms.DialogResult
        Try
            Dim dtDed2 As New DataTable
            Dim dtAjustesNom As New DataTable
            Dim dtMtroDed As New DataTable
            Dim dtConceptos As New DataTable
            Dim SinSaldo As Integer = 0
            Dim Inicializa As Windows.Forms.DialogResult
            Dim Archivo As String = ""
            Dim Clave As String
            Dim HoraInicial As DateTime = Now

            Dim tipo As String
            Dim strFechasSab As String ' AOS
            Dim strFechasDom As String ' AOS

            AnoSelec = cmbAnoPeriodo.SelectedValue.ToString.Substring(0, 4)
            PeriodoSelec = cmbAnoPeriodo.SelectedValue.ToString.Substring(4, 2)

            tipo = cmbTipoPeriodo.Text.Substring(0, 1)
            TipoPeriodo = tipo.Trim

            If definitiva Then
                'Solicitar periodo y año para exportación
                'Ubicar el archivo en C: y nombrarlo OTAMISC_PP por default
                dlgArchivo.InitialDirectory = "C:\"
                dlgArchivo.FileName = cmbCia.SelectedValue & "MISC_" & tipo & PeriodoSelec & ".TXT"
                dlgArchivo.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
                dlgArchivo.OverwritePrompt = True

                'Solicitar nombre de archivo para exportación
                Dim lDialogResult As DialogResult = dlgArchivo.ShowDialog()

                If lDialogResult = Windows.Forms.DialogResult.Cancel Then
                    'Si seleccionan "CANCEL", salir del procedimiento
                    Return lDialogResult
                Else
                    Archivo = dlgArchivo.FileName
                End If
            End If



            'Obtener los registros activos del maestro de deducciones, que aún tengan saldo, 
            'y se registraron para cobro antes del periodo elegido

            If definitiva Then
                dtMtroDed = sqlExecute("SELECT * FROM mtro_ded WHERE status = 1 AND saldo_act > 0 AND ano+periodo<= '" & AnoSelec & _
                                   PeriodoSelec & "'", "nomina")

                If dtMtroDed.Rows.Count > 0 Then

                    'Obtener cuántos registros están activos, pero su saldo ya es <=0
                    dtTemporal = sqlExecute("SELECT SUM(1) FROM mtro_ded where status = 1 AND prorratear_mes = 1 AND saldo_mes<=0", "nomina")
                    If dtTemporal.Rows.Count > 0 Then
                        SinSaldo = IIf(IsDBNull(dtTemporal.Rows(0).Item(0)), 0, dtTemporal.Rows(0).Item(0))
                    End If

                    'Pregunta para inicializar saldos
                    Inicializa = MessageBox.Show("¿Desea inicializar los saldo mensuales para los conceptos que aplique?" & _
                                                 IIf(SinSaldo > 0, vbCrLf & vbCrLf & _
                                                    "(Existen " & SinSaldo & " créditos que ya completaron su abono mensual)", "") & _
                                                "", "Inicializar saldos", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

                    frmTrabajando.Text = "Exportando ajustes"
                    frmTrabajando.lblAvance.Text = "Preparar datos"
                    frmTrabajando.Avance.IsRunning = True
                    frmTrabajando.Show(Me)

                    If Inicializa = Windows.Forms.DialogResult.Cancel Then
                        'Si se elige cancelar, salir del proceso
                        'A este punto, no se ha hecho ningún movimiento en la base de datos
                        Return Inicializa
                    ElseIf Inicializa = Windows.Forms.DialogResult.Yes Then
                        'Si se eligió inicializar, poner saldo mensual de acuerdo a lo que corresponda, 
                        'si se prorratea por mes y está activo
                        sqlExecute("UPDATE mtro_ded SET saldo_mes = ROUND(abono_mes +.05,2),sem_restan = 4,abono_act = ROUND(ROUND(abono_mes +.05,2)/4,2) " & _
                                    "WHERE status = 1 AND prorratear_mes = 1", "nomina")
                    End If

                End If

                'Para cada registro activo del maestro de deducciones


                For Each dRow As DataRow In dtMtroDed.Rows
                    '** PROGRESS BAR AQUI ***
                    frmTrabajando.lblAvance.Text = "Mtro.Ded. " & dRow("reloj")
                    Application.DoEvents()

                    'Obtener ajuste para esta deducción
                    'BERE
                    'dtAjustesNom = sqlExecute("SELECT reloj FROM ajustes_nom WHERE CONCAT(ano,periodo,reloj,RTRIM(concepto),RTRIM(numcredito)) = '" & _
                    '                          AnoSelec & PeriodoSelec & dRow("reloj") & dRow("concepto").ToString.Trim & _
                    '                          dRow("numcredito").ToString.Trim & "'", "nomina")
                    dtAjustesNom = sqlExecute("SELECT reloj FROM ajustes_nom WHERE (ano + periodo + reloj + RTRIM(concepto) + RTRIM(numcredito)) = '" & _
                                              AnoSelec & PeriodoSelec & dRow("reloj") & dRow("concepto").ToString.Trim & _
                                              dRow("numcredito").ToString.Trim & "'", "nomina")
                    If dtAjustesNom.Rows.Count = 0 Then
                        'Si no existe en ajustes_nom, insertarlo
                        dtDed2 = sqlExecute("SELECT misce_clave FROM conceptos WHERE concepto = '" & dRow("concepto") & "'", "nomina")
                        If dtDed2.Rows.Count = 0 Then
                            Clave = "XX"
                        Else
                            Clave = IIf(IsDBNull(dtDed2.Rows(0).Item("misce_clave")), "XX", dtDed2.Rows(0).Item("misce_clave")).ToString.Trim
                        End If
                        sqlExecute("INSERT INTO ajustes_nom (ano,periodo,reloj,concepto,clave,per_ded,numcredito,mtro_ded) " & _
                                   "VALUES ('" & AnoSelec & "','" & PeriodoSelec & "','" & dRow("RELOJ") & "','" & dRow("concepto") & "','" & Clave & _
                                   "',(SELECT cod_naturaleza FROM conceptos WHERE conceptos.concepto = '" & dRow("concepto").ToString.Trim & _
                                   "'),'" & dRow("numcredito").ToString.Trim & "',1)", "nomina")

                    End If
                    'BERE
                    'sqlExecute("UPDATE ajustes_nom SET monto = ROUND(" & dRow("abono_act") & ",2), " & _
                    '    "usuario = '" & Usuario & "', " & _
                    '    "fecha = '" & FechaSQL(Now.Date) & "'," & _
                    '    "saldo_act = " & dRow("saldo_act") & " WHERE CONCAT(ano,periodo,reloj,RTRIM(concepto),RTRIM(numcredito)) = '" & _
                    '    AnoSelec & PeriodoSelec & dRow("reloj") & dRow("concepto").ToString.Trim & _
                    '    dRow("numcredito").ToString.Trim & "'", "nomina")
                    sqlExecute("UPDATE ajustes_nom SET monto = ROUND(" & dRow("abono_act") & ",2), " & _
                        "usuario = '" & Usuario & "', " & _
                        "fecha = '" & FechaSQL(Now.Date) & "'," & _
                        "saldo_act = " & dRow("saldo_act") & " WHERE (ano + periodo + reloj + RTRIM(concepto) + RTRIM(numcredito)) = '" & _
                        AnoSelec & PeriodoSelec & dRow("reloj") & dRow("concepto").ToString.Trim & _
                        dRow("numcredito").ToString.Trim & "'", "nomina")
                Next

            End If


            Dim dtConceptosMiscelaneos As DataTable = sqlExecute("select * from conceptos where misce_clave is not null", "NOMINA")
            If dtConceptosMiscelaneos.Rows.Count Then
                For Each row_i As DataRow In dtConceptosMiscelaneos.Rows
                    Try
                        Dim dtDetalleMiscelaneos As DataTable = FuncionConcepto(row_i("concepto"), cmbCia.SelectedValue, AnoSelec, PeriodoSelec, IIf(IsDBNull(row_i("misce_monto")), 0, row_i("misce_monto")), tipo)
                        If dtDetalleMiscelaneos.Rows.Count Then
                            For Each row_j As DataRow In dtDetalleMiscelaneos.Rows

                                sqlExecute("insert into ajustes_nom (reloj, ano, periodo,per_ded, clave, monto, comentario, concepto, usuario, fecha, tipo_periodo) " & _
                                       " values ('" & row_j("reloj") & "', '" & row_j("ano") & "', '" & row_j("periodo") & "', '" & row_j("per_ded") & "', '" & row_j("clave") & "', '" & row_j("monto") & "', '" & row_j("comentario") & "', '" & row_j("concepto") & "', '" & row_j("usuario") & "', '" & FechaSQL(Date.Parse(row_j("fecha"))) & "', '" & tipo & "')", "NOMINA")

                            Next
                        End If
                    Catch ex As Exception
                        MsgBox("Error en la exportación del concepto " & row_i("concepto"), MsgBoxStyle.OkOnly, "Error en exportación de misceláneos")
                        ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
                        ActivoTrabajando = False
                        Return Windows.Forms.DialogResult.Abort
                        frmTrabajando.Close()
                        frmTrabajando.Dispose()
                    End Try

                Next
            End If

            Try
                Dim dtVacTrab As DataTable = sqlExecute("select reloj, isnull(comentario, '') as comentario from ajustes_nom where " & _
                                                        "concepto = 'DIASVA' AND tipo_periodo = '" & tipo & "' and ano = '" & AnoSelec & _
                                                        "' and periodo = '" & PeriodoSelec & "'", "NOMINA")
                Dim mensaje_trabajadas As String = ""
                For Each row As DataRow In dtVacTrab.Rows
                    Dim comentario As String = RTrim(row("comentario"))
                    Try
                        Dim _r_trab As String = row("reloj")
                        Dim fecha As String = comentario.Split(",")(1)

                        Dim dtAsist As DataTable = sqlExecute("select reloj, fha_ent_hor, comentario from asist where reloj = '" & _r_trab & "' and fha_ent_hor = '" & FechaSQL(Date.Parse(fecha)) & "' and comentario like '%VAC%' and comentario like '%TRAB%'", "TA")
                        If dtAsist.Rows.Count > 0 Then
                            mensaje_trabajadas &= vbCrLf & _r_trab & ", " & "Vacaciones no exportadas, " & fecha
                            sqlExecute("update ajustes_nom set cancelado = 1 where reloj = '" & _r_trab & "' and comentario = '" & comentario & "' and ano = '" & AnoSelec & "' and periodo = '" & PeriodoSelec & "' and concepto = 'DIASVA'", "nomina")
                        Else
                            sqlExecute("update ajustes_nom set cancelado = 0 where reloj = '" & _r_trab & "' and comentario = '" & comentario & "' and ano = '" & AnoSelec & "' and periodo = '" & PeriodoSelec & "' and concepto = 'DIASVA'", "nomina")
                        End If

                    Catch ex As Exception

                    End Try
                Next
                If mensaje_trabajadas <> "" Then
                    MessageBox.Show("No se exportarán vacaciones en semana de baja para empleados administrativos con alta anterior al 14 de Noviembre:" & mensaje_trabajadas, "Vacaciones finiquitos", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If


            Catch ex As Exception

            End Try

            If definitiva Then
                Dim dtRecib As New DataTable
                Dim dRecib As DataRow
                Dim wrArchivo As New StreamWriter(Archivo)

                dtRecib.Columns.Add("reloj")
                dtRecib.Columns.Add("clave")
                dtRecib.Columns.Add("fecha_incidencia", System.Type.GetType("System.String"))
                dtRecib.Columns.Add("cantidad", System.Type.GetType("System.Double"))
                dtRecib.Columns.Add("negativo")
                dtRecib.Columns.Add("tipo")
                dtRecib.Columns.Add("concepto")
                dtRecib.Columns.Add("numcredito")
                dtRecib.Columns.Add("numperiodos")
                dtRecib.Columns.Add("saldo_act", System.Type.GetType("System.Double"))
                dtRecib.Columns.Add("factor")
                dtRecib.Columns.Add("hrs_dobles", System.Type.GetType("System.Double"))
                dtRecib.Columns.Add("hrs_triples", System.Type.GetType("System.Double"))
                dtRecib.Columns.Add("semana_pago")


                dtRecib.PrimaryKey = New DataColumn() {dtRecib.Columns("reloj"), dtRecib.Columns("clave"), dtRecib.Columns("fecha_incidencia")}

                Dim QAN As String = "SELECT ajustes_nom.reloj, conceptos.misce_clave as clave, monto,saldo_act,numcredito,cod_naturaleza,ajustes_nom.concepto, " & _
                                          "fecha_incidencia,numperiodos, hrs_dobles, hrs_triples, semana_pago " & _
                                          "FROM ajustes_nom LEFT JOIN personal.dbo.personal ON ajustes_nom.reloj = personal.reloj " & _
                                          "LEFT JOIN conceptos ON ajustes_nom.concepto = conceptos.concepto WHERE cod_comp = '" & _
                                          cmbCia.SelectedValue & "' AND ajustes_nom.tipo_periodo = '" & tipo & "' AND ano = '" & AnoSelec & "' AND " & _
                                          "periodo = '" & PeriodoSelec & "' and isnull(cancelado, '0') = '0'" ' AOS

                dtAjustesNom = sqlExecute(QAN, "nomina")

                '---------------------Proceso para insertar las primas sabatinas, dominical,  y cantidad de comedores  (Solo cuando sea QUINCENAL) al archivo de Texto .txt **Por Adrian Ortega (AOS) 13/05/2019
                If (tipo.Trim = "Q") Then
                    '--Obtener fechas de incidencia en base al periodo
                    Dim dtFechasIniFin As DataTable = sqlExecute("SELECT top 1 * from periodos_quincenal where ANO='" & AnoSelec & "' and periodo='" & PeriodoSelec & "'  and PERIODO_ESPECIAL=0 order by periodo desc", "TA")
                    Dim FIniInci As String = ""
                    Dim FFinInci As String = ""
                    If (Not dtFechasIniFin.Columns.Contains("Error") And dtFechasIniFin.Rows.Count > 0) Then
                        FIniInci = IIf(IsDBNull(dtFechasIniFin.Rows(0).Item("fecha_ini_incidencia")), "", dtFechasIniFin.Rows(0).Item("fecha_ini_incidencia"))
                        FFinInci = IIf(IsDBNull(dtFechasIniFin.Rows(0).Item("fecha_fin_incidencia")), "", dtFechasIniFin.Rows(0).Item("fecha_fin_incidencia"))
                    End If

                    strFechasSab = ObtFecSabado(FechaSQL(FIniInci.Trim), FechaSQL(FFinInci.Trim))
                    strFechasDom = ObtFecDomingo(FechaSQL(FIniInci.Trim), FechaSQL(FFinInci.Trim))

                    '-----Suponiendo que ya las se, correr querys; Quedaria PEND poner las fechas qeu son sab y domingo
                    Dim dtPrimSab As DataTable = sqlExecute("select reloj,fecha,count(reloj) as cuantos from hrs_brt where fecha in (" & strFechasSab & ") and hora>='06:00' and reloj in (select reloj from personal.dbo.personal where cod_tipo<>'O' and ISNULL(inactivo,0)=0) group by reloj,fecha having count(reloj)>=2 order by fecha ", "TA")
                    Dim dtPrimDom As DataTable = sqlExecute("select distinct reloj,fecha from hrs_brt where fecha in (" & strFechasDom & ")  and reloj in (select reloj from personal.dbo.personal where cod_tipo<>'O' and ISNULL(inactivo,0)=0)  order by fecha", "TA")
                    Dim dtComedores As DataTable = sqlExecute("select reloj,subsidio,count(reloj) as monto from hrs_brt_cafeteria where fecha between '" & FechaSQL(FIniInci.Trim) & "' and '" & FechaSQL(FFinInci.Trim) & "' and reloj in (select reloj from personal.dbo.personal where cod_tipo<>'O' and ISNULL(inactivo,0)=0) and subsidio in ('C','S','Z') group by reloj,subsidio", "TA")

                    '----Meter al dtAjustesNom los empleados del sabado (Prima Sabatina)
                    If (Not dtPrimSab.Columns.Contains("Error") And dtPrimSab.Rows.Count > 0) Then
                        For Each dRowSab As DataRow In dtPrimSab.Rows
                            Dim Rj As String = IIf(IsDBNull(dRowSab("reloj")), "", dRowSab("reloj"))
                            Dim fecha As String = IIf(IsDBNull(dRowSab("fecha")), "", dRowSab("fecha"))
                            Dim cve As String = "53"
                            If (Rj.Trim <> "" And fecha.Trim <> "") Then
                                'Agregar al Dt ese registro manualmente, NOTA: tiene que ser tal y el orden de los campos vienen y su tipo de dato, si es double, y es vacio, poner un cero
                                dtAjustesNom.Rows.Add({Rj.Trim, cve, "1", 0, "", "I", "DIASAB", FechaSQL(fecha), 0, 0, 0, ""})
                            End If
                        Next
                    End If

                    '----Meter al dtAjustesNom los empleados del domingo (Prima Dominical)
                    If (Not dtPrimDom.Columns.Contains("Error") And dtPrimDom.Rows.Count > 0) Then
                        For Each dRowDom As DataRow In dtPrimDom.Rows
                            Dim Rj As String = IIf(IsDBNull(dRowDom("reloj")), "", dRowDom("reloj"))
                            Dim fecha As String = IIf(IsDBNull(dRowDom("fecha")), "", dRowDom("fecha"))
                            Dim cve As String = "52"
                            If (Rj.Trim <> "" And fecha.Trim <> "") Then
                                dtAjustesNom.Rows.Add({Rj.Trim, cve, "1", 0, "", "I", "DIADOM", FechaSQL(fecha), 0, 0, 0, ""})
                            End If
                        Next
                    End If

                    '----Insertar los comedores por empleado, fecha y monto
                    If (Not dtComedores.Columns.Contains("Error") And dtComedores.Rows.Count > 0) Then
                        For Each dRowCom As DataRow In dtComedores.Rows
                            Dim Rj As String = IIf(IsDBNull(dRowCom("reloj")), "", dRowCom("reloj"))
                            Dim TipoSub As String = IIf(IsDBNull(dRowCom("subsidio")), "", dRowCom("subsidio"))
                            Dim cve As String = IIf(TipoSub.Trim = "C", "18", IIf(TipoSub.Trim = "S", "29", "30"))
                            Dim monto As String = IIf(IsDBNull(dRowCom("monto")), "0", dRowCom("monto"))
                            Dim Concepto As String = IIf(TipoSub.Trim = "C", "DIACON", IIf(TipoSub.Trim = "S", "DIASIN", "DIADES"))
                            If (Rj.Trim <> "") Then
                                dtAjustesNom.Rows.Add({Rj.Trim, cve, monto, 0, "", "I", Concepto, FechaSQL(FFinInci.Trim), 0, 0, 0, ""})
                            End If
                        Next
                    End If

                End If
                '---------------------------------------------------------Ends Proceso

                If dtAjustesNom.Rows.Count = 0 Then
                    Return Windows.Forms.DialogResult.Cancel
                End If


                Dim dtRequiereFecha As DataTable = sqlExecute("select distinct rtrim(concepto) as concepto from conceptos where misce_fecha = '1' and cod_naturaleza not in ('P', 'D')", "nomina")
                dtRequiereFecha.PrimaryKey = New DataColumn() {dtRequiereFecha.Columns("concepto")}

                For Each dAjuste As DataRow In dtAjustesNom.Rows

                    '*** PROGRESS BAR AQUI ***

                    '-----------------Proceso para agrupar el concepto HRSEXT cuando el reloj, clave y Fecha de incidencia son el mismo dia,para Totalizar las hrs dobles y triples para mandarlo en un solo registro (AOS) ya que asi se manda en el archivo .TXT
                    Dim RJ As String = dAjuste("reloj")
                    Dim HRSDOB As Double = IIf(IsDBNull(dAjuste("hrs_dobles")), 0, dAjuste("hrs_dobles"))
                    Dim HRSTRIP As Double = IIf(IsDBNull(dAjuste("hrs_triples")), 0, dAjuste("hrs_triples"))
                    Dim CONC As String = dAjuste("concepto")
                    Dim Fec_Inci As String = IIf(IsDBNull(dAjuste("fecha_incidencia")), "", dAjuste("fecha_incidencia"))

                    If (CONC.Trim = "HRSEXA" Or CONC.Trim = "HRSEXT") Then '' Cambiar el total de hrsdob y hrsTrip para conceptos HRSEXA agruparlos x reloj, clave y fecha de incidencia
                        Dim QAN_2 As String = "SELECT ajustes_nom.reloj,isnull(sum(hrs_dobles),0) as hrs_dobles, isnull(sum(hrs_triples),0) as hrs_triples " & _
                                          "FROM ajustes_nom LEFT JOIN personal.dbo.personal ON ajustes_nom.reloj = personal.reloj " & _
                                          "LEFT JOIN conceptos ON ajustes_nom.concepto = conceptos.concepto WHERE cod_comp = '" & _
                                          cmbCia.SelectedValue & "' AND ajustes_nom.tipo_periodo = '" & tipo & "' AND ano = '" & AnoSelec & "' AND " & _
                                          "periodo = '" & PeriodoSelec & "' and isnull(cancelado, '0') = '0' AND ajustes_nom.reloj='" & RJ.Trim & "' and fecha_incidencia='" & FechaSQL(Fec_Inci.Trim) & "' " & _
                                          "GROUP by ajustes_nom.reloj,fecha_incidencia"

                        Dim dtAjustHrsExt As DataTable = sqlExecute(QAN_2, "nomina")
                        If (Not dtAjustHrsExt.Columns.Contains("Error") And dtAjustHrsExt.Rows.Count > 0) Then
                            HRSDOB = Double.Parse(IIf(IsDBNull(dtAjustHrsExt.Rows(0).Item("hrs_dobles")), "0", dtAjustHrsExt.Rows(0).Item("hrs_dobles")))
                            HRSTRIP = Double.Parse(IIf(IsDBNull(dtAjustHrsExt.Rows(0).Item("hrs_triples")), "0", dtAjustHrsExt.Rows(0).Item("hrs_triples")))

                        End If
                    End If

                    If Not (CONC.Trim = "HRSEX2" Or CONC.Trim = "HRSEX3" Or CONC.Trim = "HRSEXA" Or CONC.Trim = "HRSEXT") Then
                        HRSDOB = 0.0
                        HRSTRIP = 0.0
                    End If

                    '--------ENDS Proceso

                    frmTrabajando.lblAvance.Text = "Ajustes " & dAjuste("reloj")
                    Application.DoEvents()

                    'Buscar en la tabla de recibos si ya exise el registro en base a (RELOJ - CLAVE - FECHA_INCIDENCIA)
                    dRecib = dtRecib.Rows.Find({dAjuste("RELOJ"), IIf(IsDBNull(dAjuste("clave")), "", dAjuste("clave")), IIf(IsDBNull(dAjuste("fecha_incidencia")), "", dAjuste("fecha_incidencia"))})
                    If IsNothing(dRecib) Then
                        'Si no existe, crearlo
                        dtRecib.Rows.Add({dAjuste("reloj"), IIf(IsDBNull(dAjuste("clave")), "", dAjuste("clave")), IIf(IsDBNull(dAjuste("fecha_incidencia")), "", dAjuste("fecha_incidencia"))})
                        dRecib = dtRecib.Rows.Find({dAjuste("RELOJ"), IIf(IsDBNull(dAjuste("clave")), "", dAjuste("clave")), IIf(IsDBNull(dAjuste("fecha_incidencia")), "", dAjuste("fecha_incidencia"))})
                    End If

                    dRecib("cantidad") = Math.Round(IIf(IsDBNull(dRecib("cantidad")), 0, dRecib("cantidad")) + dAjuste("monto"), 2)
                    dRecib("negativo") = IIf(dRecib("cantidad") < 0, "*", " ")
                    dRecib("tipo") = IIf(dAjuste("cod_naturaleza").ToString.Trim = "D", "D", "P")
                    '  dRecib("concepto") = dAjuste("concepto")
                    dRecib("concepto") = CONC.Trim
                    dRecib("numcredito") = IIf(IsDBNull(dAjuste("numcredito")), "", dAjuste("numcredito"))
                    dRecib("numperiodos") = IIf(IsDBNull(dAjuste("numperiodos")), "", dAjuste("numperiodos"))
                    dRecib("saldo_act") = IIf(IsDBNull(dAjuste("saldo_act")), 0, dAjuste("saldo_act"))
                    dRecib("fecha_incidencia") = IIf(IsDBNull(dAjuste("fecha_incidencia")), "", dAjuste("fecha_incidencia"))
                    '  dRecib("hrs_dobles") = IIf(IsDBNull(dAjuste("hrs_dobles")), 0, dAjuste("hrs_dobles"))
                    dRecib("hrs_dobles") = HRSDOB
                    ' dRecib("hrs_triples") = IIf(IsDBNull(dAjuste("hrs_triples")), 0, dAjuste("hrs_triples"))
                    dRecib("hrs_triples") = HRSTRIP
                    dRecib("semana_pago") = IIf(IsDBNull(dAjuste("semana_pago")), "", dAjuste("semana_pago"))

                    If Not IsDBNull(dAjuste("fecha_incidencia")) Then


                        Dim concepto As String = RTrim(dRecib("concepto"))

                        If Not dtRequiereFecha.Rows.Find({concepto}) Is Nothing Then
                            Dim dtper As New DataTable
                            dtper = sqlExecute("select * from personal where reloj = '" & dRecib("reloj") & "'")
                            ConsultaBitacora(dtper, dtper.Rows(0), dRecib("fecha_incidencia"))
                            dRecib("factor") = ObtenerFactor(dtper.Rows(0).Item("cod_hora"), ObtenerAnoPeriodo(dRecib("fecha_incidencia"), "S").ToString.Substring(0, 4), ObtenerAnoPeriodo(dRecib("fecha_incidencia"), tipo).ToString.Substring(4, 2))
                        End If

                    End If



                    Clave = IIf(dAjuste("clave").ToString.Trim = "", "(clave = '' OR clave IS NULL)", " clave = '" & dAjuste("clave").ToString.Trim & "'")
                    'En ajustes_nom, indicar quién y cuándo hizo la exportación
                    sqlExecute("UPDATE ajustes_nom SET envio_nom = 1,envio_date = '" & FechaHoraSQL(Now) & "', " & _
                               "envio_usu = '" & Usuario & "' WHERE ano = '" & AnoSelec & "' AND periodo = '" & PeriodoSelec & "' AND reloj= '" & dAjuste("reloj") & _
                               "' AND " & Clave & _
                               " AND " & IIf(IsDBNull(dAjuste("numcredito")), "numcredito IS NULL", " numcredito = '" & dAjuste("numcredito").ToString.Trim & "'"), "nomina")
                Next

                frmTrabajando.lblAvance.Text = "Escribir archivo"
                Application.DoEvents()

                wrArchivo.Write("reloj")
                wrArchivo.Write(",")
                wrArchivo.Write("concepto")
                wrArchivo.Write(",")
                wrArchivo.Write("cantidad")
                wrArchivo.Write(",")
                wrArchivo.Write("tipo")
                wrArchivo.Write(",")
                wrArchivo.Write("numcredito")
                wrArchivo.Write(",")
                wrArchivo.Write("numperiodos")
                wrArchivo.Write(",")
                wrArchivo.Write("saldo_act")
                wrArchivo.Write(",")
                wrArchivo.Write("fecha_incidencia")
                wrArchivo.Write(",")
                wrArchivo.Write("factor")
                wrArchivo.Write(",")
                wrArchivo.Write("hrs_dobles")
                wrArchivo.Write(",")
                wrArchivo.Write("hrs_triples")
                wrArchivo.Write(",")
                wrArchivo.Write("semana_pago")

                wrArchivo.WriteLine()
                'Enviar los datos al archivo seleccionado
                For Each dRecib In dtRecib.Rows
                    'Escribir todos los campos
                    frmTrabajando.lblAvance.Text = "Archivo " & dRecib("reloj")
                    Application.DoEvents()

                    'MCR 2017-10-13
                    'Exportar formato CSV
                    wrArchivo.Write(dRecib("reloj").ToString.Trim.PadLeft(6))
                    wrArchivo.Write(",")
                    wrArchivo.Write(dRecib("concepto").ToString.PadRight(2, " "))
                    wrArchivo.Write(",")
                    wrArchivo.Write(dRecib("cantidad").ToString.Trim)
                    wrArchivo.Write(",")
                    wrArchivo.Write(dRecib("tipo").ToString)
                    wrArchivo.Write(",")
                    wrArchivo.Write(dRecib("numcredito").ToString)
                    wrArchivo.Write(",")
                    wrArchivo.Write(dRecib("numperiodos").ToString)
                    wrArchivo.Write(",")
                    wrArchivo.Write(dRecib("saldo_act").ToString)
                    wrArchivo.Write(",")
                    wrArchivo.Write(dRecib("fecha_incidencia").ToString)
                    wrArchivo.Write(",")
                    wrArchivo.Write(dRecib("factor").ToString)
                    wrArchivo.Write(",")
                    wrArchivo.Write(dRecib("hrs_dobles").ToString)
                    wrArchivo.Write(",")
                    wrArchivo.Write(dRecib("hrs_triples").ToString)
                    wrArchivo.Write(",")
                    wrArchivo.Write(dRecib("semana_pago").ToString)

                    'Indicar fin de línea
                    wrArchivo.WriteLine()
                Next
                'Cerrar el archivo
                wrArchivo.Close()


                Try
                    Dim archivo_copia As String = DireccionReportes & "archivos_nomina\ajustes_" & Usuario.Trim
                    archivo_copia &= FechaHoraSQL(Now, True, False).Replace(":", "").Replace(Space(1), "").Replace("-", "") & ".txt"

                    File.Copy(Archivo, archivo_copia)
                Catch ex As Exception

                End Try
            End If

            Dim QANFinal As String = ""
            If definitiva Then
                QANFinal = "SELECT ANO,PERIODO,ajustes_nom.numcredito AS numcredito,conceptos.NOMBRE AS CONCEPTO,conceptos.concepto as clave, naturalezas.NOMBRE AS NATURALEZA,ajustes_nom.RELOJ,NOMBRES," & _
                                      "MONTO, fecha_incidencia FROM ajustes_nom LEFT JOIN personal.dbo.personalvw ON ajustes_nom.reloj = personalvw.reloj " & _
                                      "LEFT JOIN conceptos ON ajustes_nom.concepto = conceptos.concepto " & _
                                      "LEFT JOIN naturalezas ON conceptos.cod_naturaleza = naturalezas.cod_naturaleza " & _
                                      "WHERE ano = '" & AnoSelec & "' and periodo = '" & PeriodoSelec & "' and ajustes_nom.tipo_periodo = '" & tipo & "' AND envio_usu = '" & Usuario & _
                                      "' AND envio_date >= '" & FechaHoraSQL(HoraInicial, False, False) & "'"

                dtAjustesNom = sqlExecute(QANFinal, "nomina")
            Else
                QANFinal = "SELECT ANO,PERIODO,ajustes_nom.numcredito AS numcredito,conceptos.NOMBRE AS CONCEPTO,conceptos.concepto as clave, naturalezas.NOMBRE AS NATURALEZA,ajustes_nom.RELOJ,NOMBRES," & _
                                      "MONTO, fecha_incidencia FROM ajustes_nom LEFT JOIN personal.dbo.personalvw ON ajustes_nom.reloj = personalvw.reloj " & _
                                      "LEFT JOIN conceptos ON ajustes_nom.concepto = conceptos.concepto " & _
                                      "LEFT JOIN naturalezas ON conceptos.cod_naturaleza = naturalezas.cod_naturaleza " & _
                                      "WHERE ano = '" & AnoSelec & "' and periodo = '" & PeriodoSelec & "' and ajustes_nom.tipo_periodo = '" & tipo & "'"
                dtAjustesNom = sqlExecute(QANFinal, "nomina")
            End If

            '----------------------Proc para agregar Prima sab, prima dom, y cantidad de comedores al Reporte final (NOTA: Solo para Administrativos (Per Quincenales)) por AOS 13/05/2019
            If (tipo.Trim = "Q") Then
                Dim dtFecIncidencia As DataTable = sqlExecute("SELECT top 1 * from periodos_quincenal where ANO='" & AnoSelec & "' and periodo='" & PeriodoSelec & "'  and PERIODO_ESPECIAL=0 order by periodo desc", "TA")
                Dim F1Inci As String = ""
                Dim F2Inci As String = ""
                If (Not dtFecIncidencia.Columns.Contains("Error") And dtFecIncidencia.Rows.Count > 0) Then
                    F1Inci = IIf(IsDBNull(dtFecIncidencia.Rows(0).Item("fecha_ini_incidencia")), "", dtFecIncidencia.Rows(0).Item("fecha_ini_incidencia"))
                    F2Inci = IIf(IsDBNull(dtFecIncidencia.Rows(0).Item("fecha_fin_incidencia")), "", dtFecIncidencia.Rows(0).Item("fecha_fin_incidencia"))
                End If
                strFechasSab = ObtFecSabado(FechaSQL(F1Inci.Trim), FechaSQL(F2Inci.Trim))
                strFechasDom = ObtFecDomingo(FechaSQL(F1Inci.Trim), FechaSQL(F2Inci.Trim))

                Dim RjFinal As String = ""
                Dim NbFinal As String = ""
                Dim Fecha_Inci_Final As String = ""
                Dim ConcFinal As String = ""
                Dim CveFinal As String = ""
                Dim MontoFinal As String = ""
                Dim Naturaleza As String = ""
                Dim TipoSub As String = ""

                '----Prima Sab
                Dim QTPS As String = " select hb.reloj,hb.fecha,count(hb.reloj) as cuantos, psw.nombres,n.NOMBRE AS NATURALEZA from hrs_brt hb left join PERSONAL.dbo.personalvw psw  on hb.RELOJ = psw.RELOJ  LEFT JOIN NOMINA.dbo.naturalezas n on n.COD_NATURALEZA='I' " & _
                    "where hb.fecha in (" & strFechasSab & ") and hb.hora>='06:00' and hb.reloj in (select reloj from personal.dbo.personal where cod_tipo<>'O' and ISNULL(inactivo,0)=0) " & _
                    "group by hb.reloj,hb.fecha,psw.nombres,n.NOMBRE having count(hb.reloj)>=2 order by hb.fecha "
                Dim dtTotPrimSab As DataTable = sqlExecute(QTPS, "TA")
                If (Not dtTotPrimSab.Columns.Contains("Error") And dtTotPrimSab.Rows.Count > 0) Then
                    For Each dRTPS As DataRow In dtTotPrimSab.Rows
                        RjFinal = IIf(IsDBNull(dRTPS("reloj")), "", dRTPS("reloj"))
                        NbFinal = IIf(IsDBNull(dRTPS("nombres")), "", dRTPS("nombres"))
                        ConcFinal = "PRIMA SABATINA Unidad"
                        CveFinal = "DIASAB"
                        Naturaleza = IIf(IsDBNull(dRTPS("NATURALEZA")), "", dRTPS("NATURALEZA"))
                        MontoFinal = "1"
                        Fecha_Inci_Final = IIf(IsDBNull(dRTPS("fecha")), "", dRTPS("fecha"))
                        If (RjFinal.Trim <> "" And Fecha_Inci_Final.Trim <> "") Then
                            dtAjustesNom.Rows.Add({AnoSelec, PeriodoSelec, "", ConcFinal, CveFinal, Naturaleza, RjFinal.Trim, NbFinal.Trim, MontoFinal, FechaSQL(Fecha_Inci_Final.Trim)})
                        End If
                    Next
                End If

                '---Prima Dom
                Dim QTPD As String = "select distinct hb.reloj,hb.fecha,psw.nombres,n.NOMBRE AS NATURALEZA from hrs_brt hb left join PERSONAL.dbo.personalvw psw  on hb.RELOJ = psw.RELOJ  LEFT JOIN NOMINA.dbo.naturalezas n on n.COD_NATURALEZA='I' " & _
                "WHERE hb.fecha in (" & strFechasDom & ")  and hb.reloj in (select reloj from personal.dbo.personal where cod_tipo<>'O' and ISNULL(inactivo,0)=0)  order by hb.fecha"

                Dim dtTotPrimDom As DataTable = sqlExecute(QTPD, "TA")
                If (Not dtTotPrimDom.Columns.Contains("Error") And dtTotPrimDom.Rows.Count > 0) Then
                    For Each dRTPD As DataRow In dtTotPrimDom.Rows
                        RjFinal = IIf(IsDBNull(dRTPD("reloj")), "", dRTPD("reloj"))
                        NbFinal = IIf(IsDBNull(dRTPD("nombres")), "", dRTPD("nombres"))
                        ConcFinal = "PRIMA DOMINICAL Unidad"
                        CveFinal = "DIADOM"
                        Naturaleza = IIf(IsDBNull(dRTPD("NATURALEZA")), "", dRTPD("NATURALEZA"))
                        MontoFinal = "1"
                        Fecha_Inci_Final = IIf(IsDBNull(dRTPD("fecha")), "", dRTPD("fecha"))
                        If (RjFinal.Trim <> "" And Fecha_Inci_Final.Trim <> "") Then
                            dtAjustesNom.Rows.Add({AnoSelec, PeriodoSelec, "", ConcFinal, CveFinal, Naturaleza, RjFinal.Trim, NbFinal.Trim, MontoFinal, FechaSQL(Fecha_Inci_Final.Trim)})
                        End If
                    Next
                End If

                '----Comedores (Cafetería)
                Dim QTC As String = "select hb.reloj,hb.subsidio,count(hb.reloj) as monto,psw.nombres,n.NOMBRE AS NATURALEZA " & _
                    "from hrs_brt_cafeteria hb left join PERSONAL.dbo.personalvw psw  on hb.RELOJ = psw.RELOJ LEFT JOIN NOMINA.dbo.naturalezas n on n.COD_NATURALEZA='I' " & _
                    "where hb.fecha between '" & FechaSQL(F1Inci) & "' and '" & FechaSQL(F2Inci) & "' and hb.reloj in (select reloj from personal.dbo.personal where cod_tipo<>'O' and ISNULL(inactivo,0)=0) and hb.subsidio in ('C','S','Z') " & _
                    "group by hb.reloj,hb.subsidio,psw.nombres,n.NOMBRE"

                Dim dtTotComedores As DataTable = sqlExecute(QTC, "TA")
                If (Not dtTotComedores.Columns.Contains("Error") And dtTotComedores.Rows.Count > 0) Then
                    For Each dRTCom As DataRow In dtTotComedores.Rows
                        RjFinal = IIf(IsDBNull(dRTCom("reloj")), "", dRTCom("reloj"))
                        NbFinal = IIf(IsDBNull(dRTCom("nombres")), "", dRTCom("nombres"))
                        TipoSub = IIf(IsDBNull(dRTCom("subsidio")), "", dRTCom("subsidio"))
                        ConcFinal = IIf(TipoSub.Trim = "C", "COMEDOR Unidad", IIf(TipoSub.Trim = "S", "COMEDOR SIN SUBSIDIO Unidad", "COMEDOR 2 SIN SUBSIDIO UNIDAD"))
                        CveFinal = IIf(TipoSub.Trim = "C", "DIACON", IIf(TipoSub.Trim = "S", "DIASIN", "DIADES"))
                        Naturaleza = IIf(IsDBNull(dRTCom("NATURALEZA")), "", dRTCom("NATURALEZA"))
                        MontoFinal = IIf(IsDBNull(dRTCom("monto")), "", dRTCom("monto"))
                        Fecha_Inci_Final = F2Inci

                        If (RjFinal.Trim <> "" And Fecha_Inci_Final.Trim <> "") Then
                            dtAjustesNom.Rows.Add({AnoSelec, PeriodoSelec, "", ConcFinal, CveFinal, Naturaleza, RjFinal.Trim, NbFinal.Trim, MontoFinal, FechaSQL(Fecha_Inci_Final.Trim)})
                        End If
                    Next
                End If

            End If
            '----------------------End Proc
     Dim dtajustesnom_usu As DataTable = sqlExecute("SELECT ANO,PERIODO,ajustes_nom.numcredito AS numcredito,conceptos.NOMBRE AS CONCEPTO,conceptos.concepto as clave, naturalezas.NOMBRE AS NATURALEZA,ajustes_nom.RELOJ,NOMBRES," & _
                                             "MONTO, ajustes_nom.fecha, ajustes_nom.usuario FROM ajustes_nom LEFT JOIN personal.dbo.personalvw ON ajustes_nom.reloj = personalvw.reloj " & _
                                             "LEFT JOIN conceptos ON ajustes_nom.concepto = conceptos.concepto " & _
                                             "LEFT JOIN naturalezas ON conceptos.cod_naturaleza = naturalezas.cod_naturaleza " & _
                                             "WHERE CAP_NOMINA = '1' AND ano = '" & AnoSelec & "' and periodo = '" & PeriodoSelec & "' and ajustes_nom.tipo_periodo = '" & tipo & "' AND envio_usu = '" & Usuario & _
                                             "' AND envio_date >= '" & FechaHoraSQL(HoraInicial, False, False) & "'", "NOMINA")


            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()
            CiaReporteador = cmbCia.SelectedValue
            EncabezadoReporte = "PERIODO " & AnoSelec & "-" & PeriodoSelec
            frmVistaPrevia.LlamarReporte("Ajustes a nómina exportados", dtAjustesNom)
            frmVistaPrevia.ShowDialog()

            frmVistaPrevia.LlamarReporte("Ajustes a nómina exportados Detalle", dtajustesnom_usu)
            frmVistaPrevia.ShowDialog()

            Return Windows.Forms.DialogResult.OK
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            ActivoTrabajando = False
            Return Windows.Forms.DialogResult.Abort
            frmTrabajando.Close()
            frmTrabajando.Dispose()
        End Try
    End Function


    ''' <summary>
    ''' Exporta solo los ajustes que se hicieron después de la última exportación
    ''' NO INICIALIZA MAESTRO DE DEDUCCIONES, NI AFECTA SALDOS
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ExportarAjustesComplementaria() As Windows.Forms.DialogResult
        Try
            Dim dtDed2 As New DataTable
            Dim dtAjustesNom As New DataTable
            Dim dtMtroDed As New DataTable
            Dim dtConceptos As New DataTable
            Dim SinSaldo As Integer = 0
            Dim Archivo As String = ""
            Dim Clave As String = ""
            Dim HoraInicial As DateTime = Now

            AnoSelec = cmbAnoPeriodo.SelectedValue.ToString.Substring(0, 4)
            PeriodoSelec = cmbAnoPeriodo.SelectedValue.ToString.Substring(4, 2)

            'Solicitar periodo y año para exportación
            'Ubicar el archivo en C: y nombrarlo OTAMISC_PP por default
            dlgArchivo.InitialDirectory = "C:\"
            dlgArchivo.FileName = cmbCia.SelectedValue & "COMP_MISC_" & PeriodoSelec & ".TXT"
            dlgArchivo.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            dlgArchivo.OverwritePrompt = True

            'Solicitar nombre de archivo para exportación
            Dim lDialogResult As DialogResult = dlgArchivo.ShowDialog()

            If lDialogResult = Windows.Forms.DialogResult.Cancel Then
                'Si seleccionan "CANCEL", salir del procedimiento
                Return lDialogResult
            Else
                Archivo = dlgArchivo.FileName
            End If

            Dim dtRecib As New DataTable
            Dim dRecib As DataRow
            Dim wrArchivo As New StreamWriter(Archivo)

            dtRecib.Columns.Add("reloj")
            dtRecib.Columns.Add("clave")
            dtRecib.Columns.Add("cantidad", System.Type.GetType("System.Double"))
            dtRecib.Columns.Add("negativo")
            dtRecib.Columns.Add("tipo")
            dtRecib.Columns.Add("concepto")

            dtRecib.PrimaryKey = New DataColumn() {dtRecib.Columns("reloj"), dtRecib.Columns("clave")}

            dtAjustesNom = sqlExecute("SELECT ajustes_nom.reloj,clave,monto,saldo_act,numcredito,cod_naturaleza,conceptos.concepto " & _
                                      "FROM ajustes_nom LEFT JOIN personal.dbo.personal ON ajustes_nom.reloj = personal.reloj " & _
                                      "LEFT JOIN conceptos ON clave = conceptos.misce_clave WHERE cod_comp = '" & _
                                      cmbCia.SelectedValue & "' AND ano = '" & AnoSelec & "' AND " & _
                                      "periodo = '" & PeriodoSelec & "' AND (envio_nom = 0 OR envio_nom IS NULL)", "nomina")

            If dtAjustesNom.Rows.Count = 0 Then
                Return Windows.Forms.DialogResult.Cancel
            End If
            For Each dAjuste As DataRow In dtAjustesNom.Rows
                '*** PROGRESS BAR AQUI ***
                frmTrabajando.lblAvance.Text = "Ajustes " & dAjuste("reloj")
                Application.DoEvents()

                'Buscar en la tabla de recibos si ya exise el registro
                dRecib = dtRecib.Rows.Find({dAjuste("RELOJ"), IIf(IsDBNull(dAjuste("clave")), "", dAjuste("clave"))})
                If IsNothing(dRecib) Then
                    'Si no existe, crearlo
                    dtRecib.Rows.Add({dAjuste("reloj"), IIf(IsDBNull(dAjuste("clave")), "", dAjuste("clave"))})
                    dRecib = dtRecib.Rows.Find({dAjuste("RELOJ"), IIf(IsDBNull(dAjuste("clave")), "", dAjuste("clave"))})
                End If

                dRecib("cantidad") = Math.Round(IIf(IsDBNull(dRecib("cantidad")), 0, dRecib("cantidad")) + dAjuste("monto"), 2)
                dRecib("negativo") = IIf(dRecib("cantidad") < 0, "*", " ")
                dRecib("tipo") = IIf(dAjuste("cod_naturaleza").ToString.Trim = "D", "D", "P")
                dRecib("concepto") = dAjuste("concepto")

                Clave = IIf(dAjuste("clave").ToString.Trim = "", "(clave = '' OR clave IS NULL)", " clave = '" & dAjuste("clave").ToString.Trim & "'")
                'En ajustes_nom, indicar quién y cuándo hizo la exportación
                sqlExecute("UPDATE ajustes_nom SET envio_nom = 1,envio_date = '" & FechaHoraSQL(Now) & "', " & _
                           "envio_usu = '" & Usuario & "' WHERE reloj= '" & dAjuste("reloj") & "' AND " & Clave & _
                           " AND " & IIf(IsDBNull(dAjuste("numcredito")), "numcredito IS NULL", " numcredito = '" & dAjuste("numcredito").ToString.Trim & "'"), "nomina")
            Next

            frmTrabajando.lblAvance.Text = "Escribir archivo"
            Application.DoEvents()
            'Enviar los datos al archivo seleccionado
            For Each dRecib In dtRecib.Rows
                'Escribir todos los campos
                frmTrabajando.lblAvance.Text = "Archivo " & dRecib("reloj")
                Application.DoEvents()

                wrArchivo.Write(dRecib("reloj").ToString.Trim.PadLeft(6))
                wrArchivo.Write(" ")
                wrArchivo.Write(dRecib("clave").ToString.PadRight(2, " "))
                wrArchivo.Write(Space(10))
                wrArchivo.Write(Math.Abs(dRecib("cantidad") * 100).ToString.PadLeft(7))
                wrArchivo.Write(dRecib("negativo").ToString)
                wrArchivo.Write(Space(5))
                wrArchivo.Write(dRecib("tipo").ToString)
                wrArchivo.Write(" ")
                wrArchivo.Write(dRecib("concepto").ToString)

                'Indicar fin de línea
                wrArchivo.WriteLine()
            Next
            'Cerrar el archivo
            wrArchivo.Close()

            dtAjustesNom = sqlExecute("SELECT ANO,PERIODO,ajustes_nom.CLAVE AS numcredito,conceptos.NOMBRE AS CONCEPTO,naturalezas.NOMBRE,ajustes_nom.RELOJ,NOMBRES," & _
                                      "MONTO FROM ajustes_nom LEFT JOIN personal.dbo.personalvw ON ajustes_nom.reloj = personalvw.reloj " & _
                                      "LEFT JOIN conceptos ON ajustes_nom.concepto = conceptos.concepto " & _
                                      "LEFT JOIN naturalezas ON conceptos.cod_naturaleza = naturalezas.cod_naturaleza " & _
                                      "WHERE ano = '" & AnoSelec & "' and periodo = '" & PeriodoSelec & "' AND envio_usu = '" & Usuario & _
                                      "' AND envio_date >= '" & FechaHoraSQL(HoraInicial, False, False) & "'", "nomina")





            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()
            CiaReporteador = cmbCia.SelectedValue
            EncabezadoReporte = "COMPLEMENTARIA PERIODO " & AnoSelec & "-" & PeriodoSelec
            frmVistaPrevia.LlamarReporte("Ajustes a nómina exportados", dtAjustesNom)
            frmVistaPrevia.ShowDialog()



            Return Windows.Forms.DialogResult.OK
        Catch ex As Exception
            Return Windows.Forms.DialogResult.Abort
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()
        End Try
    End Function

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click

        btnExportar.Enabled = False
        btnCancelar.Enabled = False

        Dim definitiva As Boolean = sbMarcarExportados.Value

        Dim Resultado As Windows.Forms.DialogResult
        EncabezadoReporte = "PERIODO " & cmbAnoPeriodo.SelectedValue.ToString.Substring(4, 2) & " - " & cmbAnoPeriodo.SelectedValue.ToString.Substring(0, 4)
        If chkCompleta.Checked Then
            If definitiva Then
                Resultado = ExportarAjustes(definitiva)
            Else
                If MessageBox.Show("El archivo de ajustes NO será generado a menos que se marque la casilla de tipo de exportación como 'Definitiva'", "Revisión de ajustes a exportar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = Windows.Forms.DialogResult.OK Then
                    Resultado = ExportarAjustes(definitiva)
                End If
            End If

        Else
            Resultado = ExportarAjustesComplementaria()
        End If

        If definitiva Then
            If Resultado = Windows.Forms.DialogResult.OK Then
                MessageBox.Show("El archivo de exportación para la nómina fue creado exitosamente.", "Exportación de misceláneos", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ElseIf Resultado = Windows.Forms.DialogResult.Abort Then
                MessageBox.Show("Se encontraron errores durante el proceso, y el archivo de exportación para la nómina NO pudo ser creado exitosamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf Resultado = Windows.Forms.DialogResult.Cancel Then
                MessageBox.Show("No hay registros a exportar con las condiciones indicadas.", "No exportación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        
        btnExportar.Enabled = True
        btnCancelar.Enabled = True

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub cmbTipoPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoPeriodo.SelectedIndexChanged

    End Sub

    Private Sub cmbTipoPeriodo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTipoPeriodo.SelectedValueChanged
        Dim Tipo As String
        Dim tabla As String

        Try
            If cmbTipoPeriodo.Text.Length < 1 Then Exit Sub

            Tipo = cmbTipoPeriodo.Text.Substring(0, 1)
            tabla = IIf(Tipo = "Q", "periodos_quincenal", IIf(Tipo = "M", "periodos_mensual", "periodos"))

            dtPeriodos = sqlExecute("SELECT ano+periodo as 'unico',ano,periodo,fecha_ini,fecha_fin FROM " & tabla & "  ORDER BY ano DESC,periodo ASC ", "TA")
            cmbAnoPeriodo.DataSource = dtPeriodos
            cmbAnoPeriodo.SelectedIndex = 0
            'cmbAnoPeriodo.SelectedValue = ObtenerAnoPeriodo(DateAdd(DateInterval.Day, -7, Now), Tipo)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)

        End Try

    End Sub

End Class