Imports System.IO



Public Class frmProcesarHoras

    Private Sub frmProcesarHoras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim dtCia As New DataTable
        Dim dtAno As New DataTable

        Try
            dtCia = sqlExecute("SELECT cod_comp,RTRIM(nombre) AS nombre FROM cias ORDER BY cia_default DESC,cod_comp")
            cmbCia.DataSource = dtCia

            dtAno = sqlExecute("select distinct ano from (SELECT ano from periodos union all select ano from periodos_quincenal union all select ano from periodos_mensual) as ano ", "TA")
            cmbAno.DataSource = dtAno

            Dim dtTipo As New DataTable
            dtTipo.Columns.Add("Tipo")
            dtTipo.Columns.Add("Nombre")

            dtTipo.Rows.Add({"S", "Semanal"})
            dtTipo.Rows.Add({"Q", "Quincenal"})
            dtTipo.Rows.Add({"M", "Mensual"})
            cmbTipo.DataSource = dtTipo
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub
    Dim dtPeriodos As New DataTable
    Dim perActivo As String = ""
    Private Sub cmbAno_SelectionChanged(sender As Object, e As DevComponents.AdvTree.AdvTreeNodeEventArgs) Handles cmbAno.SelectionChanged


        Try
            dtPeriodos = sqlExecute("SELECT TOP 1 periodo, fecha_ini, fecha_fin FROM " & tipo_periodo & " WHERE ano = '" & cmbAno.SelectedValue & "' AND activo = 1 ORDER BY periodo DESC", "TA")
            If dtPeriodos.Rows.Count > 0 Then
                perActivo = dtPeriodos.Rows(0).Item("periodo")
            End If

            dtPeriodos = sqlExecute("SELECT periodo,fecha_ini,fecha_fin FROM " & tipo_periodo & " WHERE ano = '" & cmbAno.SelectedValue & "' ORDER BY periodo", "TA")
            cmbPeriodo.DataSource = dtPeriodos
            If perActivo.Length > 0 Then
                cmbPeriodo.SelectedValue = perActivo
            Else
                cmbPeriodo.SelectedIndex = 0
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        End Try
    End Sub
    Dim tipo_periodo As String = "periodos"
    Private Sub cmbTipo_SelectionChanged(sender As Object, e As DevComponents.AdvTree.AdvTreeNodeEventArgs) Handles cmbTipo.SelectionChanged


        If cmbTipo.SelectedValue = "S" Then
            tipo_periodo = "periodos"
        ElseIf cmbTipo.SelectedValue = "Q" Then
            tipo_periodo = "periodos_quincenal"
        ElseIf cmbTipo.SelectedValue = "M" Then
            tipo_periodo = "periodos_mensual"
        End If


        Try
            dtPeriodos = sqlExecute("SELECT TOP 1 periodo, fecha_ini, fecha_fin FROM " & tipo_periodo & " WHERE ano = '" & cmbAno.SelectedValue & "' AND activo = 1 ORDER BY periodo DESC", "TA")
            If dtPeriodos.Rows.Count > 0 Then
                perActivo = dtPeriodos.Rows(0).Item("periodo")
            End If

            dtPeriodos = sqlExecute("SELECT periodo,fecha_ini,fecha_fin FROM " & tipo_periodo & " WHERE ano = '" & cmbAno.SelectedValue & "' ORDER BY periodo", "TA")
            cmbPeriodo.DataSource = dtPeriodos
            If perActivo.Length > 0 Then
                cmbPeriodo.SelectedValue = perActivo
            Else
                cmbPeriodo.SelectedIndex = 0
            End If

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try

    End Sub
    Private Sub cmbAno_TextChanged(sender As Object, e As EventArgs) Handles cmbAno.TextChanged

    End Sub

    Private Sub btnPrenominaOperativa_Click(sender As Object, e As EventArgs) Handles btnPrenominaOperativa.Click
        Dim Ano As String
        Dim Per As String
        Dim Cia As String
        Try
            Me.Cursor = Cursors.WaitCursor
            Ano = cmbAno.SelectedValue
            Per = cmbPeriodo.SelectedValue
            Cia = cmbCia.SelectedValue
            dtFiltroTA = sqlExecute("SELECT asist.*,personalvw.cod_comp, personalvw.compania, personalvw.nombre_depto, personalvw.nombres,cod_hora,personalvw.cod_planta,alta,rfc,curp,nombre_super,sactual," & _
                                    "hrs_normales,hrs_dobles,hrs_triples,hrs_tarde,hrs_prim_dom,hrs_descanso,hrs_festivo,hrs_convenio," & _
                                    "bono_puntualidad,bono_asistencia,asistencia_perfecta,nomsem.bono01, nomsem.bono02, nomsem.bono03, nomsem.bono04, nomsem.bono05, nomsem.bono06, nomsem.bono07, nomsem.bono08, nomsem.bono09, nomsem.bono10 " & _
                                    "FROM TA.DBO.ASIST LEFT JOIN personal.dbo.PERSONALVW ON PERSONALVW.RELOJ= ASIST.RELOJ " & _
                                    "LEFT JOIN TA.DBO.NOMSEM ON ASIST.RELOJ = NOMSEM.RELOJ AND ASIST.PERIODO = NOMSEM.PERIODO AND " & _
                                    "ASIST.ANO = NOMSEM.ANO WHERE asist.ano = '" & Ano & "' AND asist.periodo = '" & Per & _
                                    "' AND personalvw.cod_comp = '" & Cia & "'" & _
                                    IIf(cmbTipoEmpleado.SelectedValue <> "***", " AND asist.cod_tipo = '" & cmbTipoEmpleado.SelectedValue & "'", "") & IIf(cmbPlanta.SelectedValue <> "***", " AND personalvw.cod_planta = '" & cmbPlanta.SelectedValue & "'", ""), "TA")
            frmVistaPrevia.LlamarReporte("Prenómina semanal", dtFiltroTA)
            frmVistaPrevia.Show(Me)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.hResult, ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnPrenominaAdmva_Click(sender As Object, e As EventArgs) Handles btnPrenominaAdmva.Click
        Dim Ano As String
        Dim Per As String
        Dim Cia As String
        Try
            Me.Cursor = Cursors.WaitCursor
            Ano = cmbAno.SelectedValue
            Per = cmbPeriodo.SelectedValue
            Cia = cmbCia.SelectedValue
            dtFiltroTA = sqlExecute("SELECT asist.*,personalvw.cod_comp, personalvw.compania, personalvw.nombre_depto, personalvw.nombres,cod_hora,personalvw.cod_planta,alta,rfc,curp,nombre_super,sactual," & _
                                    "hrs_normales,hrs_dobles,hrs_triples,hrs_tarde,hrs_prim_dom,hrs_descanso,hrs_festivo,hrs_convenio," & _
                                    "bono_puntualidad,bono_asistencia,asistencia_perfecta,nomsem.bono01, nomsem.bono02, nomsem.bono03, nomsem.bono04, nomsem.bono05, nomsem.bono06, nomsem.bono07, nomsem.bono08, nomsem.bono09, nomsem.bono10 " & _
                                    "FROM TA.DBO.ASIST LEFT JOIN personal.dbo.PERSONALVW ON PERSONALVW.RELOJ= ASIST.RELOJ " & _
                                    "LEFT JOIN TA.DBO.NOMSEM ON ASIST.RELOJ = NOMSEM.RELOJ AND ASIST.PERIODO = NOMSEM.PERIODO AND " & _
                                    "ASIST.ANO = NOMSEM.ANO WHERE asist.ano = '" & Ano & "' AND asist.periodo = '" & Per & _
                                    "' AND personalvw.cod_comp = '" & Cia & "' " & _
                                    "AND asist.reloj in ( select distinct reloj from asist where ano = '" & Ano & "' and periodo = '" & Per & "' and (" & _
                                        "(" & _
                                            " comentario like  '%RETARDO%' " & _
                                            " OR comentario like  '%FALTA ENTRADA%' " & _
                                            " OR comentario like  '%FALTA SALIDA%' " & _
                                            " OR comentario like  '%ANTICIPADA%' " & _
                                        ") OR ( " & _
                                            " rtrim(replace(isnull(tipo_aus, ''), 'FES', '')) <> ''" & _
                                        ") OR ( " & _
                                            " EXTRAS_AUTORIZADAS <> '00:00'" & _
                                        ") " & _
                                    ")) " & _
                                    IIf(cmbTipoEmpleado.SelectedValue <> "***", " AND asist.cod_tipo = '" & cmbTipoEmpleado.SelectedValue & "'", "") & IIf(cmbPlanta.SelectedValue <> "***", " AND personalvw.cod_planta = '" & cmbPlanta.SelectedValue & "'", ""), "TA")
            frmVistaPrevia.LlamarReporte("Prenómina semanal", dtFiltroTA)
            frmVistaPrevia.Show(Me)
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnRevisionHoras_Click(sender As Object, e As EventArgs) Handles btnRevisionHoras.Click
        Dim Ano As String
        Dim Per As String
        Dim Cia As String

        Dim dtPeriodo As New DataTable
        Dim dtDatos As New DataTable
        Dim dtInfoPersonal As New DataTable
        Dim dtInfoAsist As New DataTable
        Dim dtInfoNomsem As New DataTable
        Dim dtInfoHrsBrt As New DataTable
        Dim dRow As DataRow

        Try
            Me.Cursor = Cursors.WaitCursor
            Ano = cmbAno.SelectedValue
            Per = cmbPeriodo.SelectedValue
            Cia = cmbCia.SelectedValue

            frmTrabajando.Show(Me)
            frmTrabajando.Avance.Value = 0
            frmTrabajando.Avance.IsRunning = True
            frmTrabajando.lblAvance.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
            frmTrabajando.lblAvance.Text = "Preparando datos..."
            Application.DoEvents()

            dtDatos = New DataTable

            dtDatos.Columns.Add("COD_PLANTA")
            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("NOMBRES")
            dtDatos.Columns.Add("COD_DEPTO")
            dtDatos.Columns.Add("nombre_depto")
            dtDatos.Columns.Add("COD_TURNO")
            dtDatos.Columns.Add("COD_TIPO")
            dtDatos.Columns.Add("COMENTARIO")
            dtDatos.Columns.Add("FECHA", System.Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("HORA")
            dtDatos.Columns.Add("PERIODO")
            dtDatos.Columns.Add("HRS_NORMALES_ASIST")
            dtDatos.Columns.Add("HRS_NORMALES_NOMSEM")
            dtDatos.Columns.Add("HRS_EXTRAS_ASIST")
            dtDatos.Columns.Add("HRS_EXTRAS_NOMSEM")



            frmTrabajando.lblAvance.Text = "Horas no analizadas"
            Application.DoEvents()
            'Revisar horas en bruto contra asist
            dtInfoHrsBrt = sqlExecute("SELECT hrs_brt.reloj,hrs_brt.fecha,hrs_brt.hora,hrs_brt.preus,nombres,cod_depto,cod_turno,cod_tipo,personalvw.nombre_depto, personalvw.cod_planta " & _
                                      "FROM hrs_brt left join ta.dbo.periodos on periodos.ano = '" & Ano & "' and periodos.periodo = '" & Per & "' LEFT JOIN personal.dbo.personalvw ON hrs_brt.reloj= personalvw.reloj " & _
                                      "WHERE hrs_brt.fecha between periodos.fecha_ini and periodos.fecha_fin AND personalvw.tipo_periodo = '" & cmbTipo.SelectedValue & "' AND personalvw.cod_comp = '" & Cia & "'" & _
                                      IIf(cmbTipoEmpleado.SelectedValue <> "***", " AND cod_tipo = '" & cmbTipoEmpleado.SelectedValue & "'", "") & IIf(cmbPlanta.SelectedValue <> "***", " AND personalvw.cod_planta = '" & cmbPlanta.SelectedValue & "'", ""), "TA")

            For Each dRow In dtInfoHrsBrt.Rows
                Application.DoEvents()

                dtInfoAsist = sqlExecute("SELECT reloj FROM asist WHERE reloj = '" & dRow("reloj") & _
                                         "' AND ((fecha_entro = '" & FechaSQL(dRow("fecha")) & _
                                         "' AND entro = '" & MilitarMer(dRow("hora")) & "') OR (fecha_salio = '" & FechaSQL(dRow("fecha")) & _
                                         "' AND salio = '" & MilitarMer(dRow("hora")) & "'))", "TA")
                If dtInfoAsist.Rows.Count = 0 And IIf(IsDBNull(dRow("PREUS")), 0, dRow("PREUS")) = 0 Then
                    'No se encontró el registro en asist, y no se corrió bajo PREUS
                    dtDatos.Rows.Add({dRow("cod_planta"), dRow("reloj"), dRow("nombres"), dRow("cod_depto"), dRow("nombre_depto"), dRow("cod_turno"), dRow("cod_tipo"), "Horas en bruto no analizadas", dRow("fecha"), dRow("hora"), Per})
                End If
            Next

            '' *** REVISAR IVETTE
            'scan()
            'If errores.cod_turno = "3".and._htos(errores.hora) >= 72000 Then
            '    delete()
            'End If
            'endscan()
            'go Top
            '*****************

            frmTrabajando.lblAvance.Text = "Suma de horas no coincide"
            Application.DoEvents()
            Dim HrsNormales As Double
            Dim HrsExtras As Double
            'Revisión de horas de asist VS nomsem
            'Tomar los datos de nomsem, filtrando solo operativos, del periodo, año y compañía seleccionadas
            dtInfoNomsem = sqlExecute("SELECT nomsem.*,nombres,personalvw.cod_planta, personalvw.cod_comp,cod_turno,cod_tipo,cod_depto, personalvw.nombre_depto, personalvw.cod_planta " & _
                                      "FROM nomsem LEFT JOIN personal.dbo.personalvw ON nomsem.reloj= personalvw.reloj " & _
                                      "WHERE periodo = '" & Per & "' AND ano = '" & Ano & "'AND personalvw.tipo_periodo = '" & cmbTipo.SelectedValue & "' AND personalvw.cod_comp = '" & Cia & "'" & _
                                      IIf(cmbTipoEmpleado.SelectedValue <> "***", " AND cod_tipo = '" & cmbTipoEmpleado.SelectedValue & "'", "") & IIf(cmbPlanta.SelectedValue <> "***", " AND personalvw.cod_planta = '" & cmbPlanta.SelectedValue & "'", ""), "TA")

            For Each dRow In dtInfoNomsem.Rows
                Application.DoEvents()

                dtInfoAsist = sqlExecute("SELECT horas_normales,horas_extras FROM asist WHERE reloj = '" & dRow("reloj") & "' AND periodo = '" & Per & _
                                         "' AND ano = '" & Ano & "'", "TA")
                HrsNormales = 0
                HrsExtras = 0
                For Each drAsist As DataRow In dtInfoAsist.Rows
                    HrsNormales += HtoD(IIf(IsDBNull(drAsist("horas_normales")), "00:00", drAsist("horas_normales")))
                    HrsExtras += HtoD(IIf(IsDBNull(drAsist("horas_extras")), "00:00", drAsist("horas_extras")))
                Next
                HrsNormales = HrsNormales * SemanaHorarioMixto(Ano & Per, dRow("reloj")).Factor

                Dim hrs_normales As Double = 0
                Dim hrs_festivo As Double = 0
                Dim hrs_dobles As Double = 0
                Dim hrs_triples As Double = 0

                hrs_normales = IIf(IsDBNull(dRow("hrs_normales")), 0, dRow("hrs_normales"))
                hrs_festivo = IIf(IsDBNull(dRow("hrs_festivo")), 0, dRow("hrs_festivo"))
                hrs_dobles = IIf(IsDBNull(dRow("hrs_dobles")), 0, dRow("hrs_dobles"))
                hrs_triples = IIf(IsDBNull(dRow("hrs_triples")), 0, dRow("hrs_triples"))

                If Math.Abs(hrs_normales + hrs_festivo - HrsNormales) > 0.03 Or (dRow("cod_tipo") = "O" And Math.Abs(hrs_dobles + hrs_triples - HrsExtras) > 0.03) Then
                    'Si la diferencia entre las horas normales o las festivas es mayor a .02 (1 minuto)
                    dtDatos.Rows.Add({dRow("cod_planta"), dRow("reloj"), dRow("nombres"), dRow("cod_depto"), dRow("nombre_depto"), dRow("cod_turno"), dRow("cod_tipo"), _
                                      "No suma registro diario con horas totales en nómina", Nothing, "", dRow("periodo"), HrsNormales, hrs_normales + hrs_festivo, HrsExtras, hrs_dobles + hrs_triples})
                End If
            Next

            frmTrabajando.lblAvance.Text = "Extras mayores a 30"
            Application.DoEvents()
            'Revisión de horas extras>30
            dtInfoNomsem = sqlExecute("SELECT nomsem.*,nombres,personalvw.cod_comp,cod_turno,cod_tipo,cod_depto, nombre_depto, personalvw.cod_planta FROM nomsem " & _
                                      "LEFT JOIN personal.dbo.personalvw ON nomsem.reloj= personalvw.reloj " & _
                                      "WHERE (hrs_dobles + hrs_triples)> 30 AND periodo = '" & Per & "' AND ano = '" & Ano & _
                                      "'  AND personalvw.tipo_periodo = '" & cmbTipo.SelectedValue & "' AND personalvw.cod_comp = '" & Cia & "'" & _
                                      IIf(cmbTipoEmpleado.SelectedValue <> "***", " AND cod_tipo = '" & cmbTipoEmpleado.SelectedValue & "'", "") & IIf(cmbPlanta.SelectedValue <> "***", " AND personalvw.cod_planta = '" & cmbPlanta.SelectedValue & "'", ""), "TA")
            For Each dRow In dtInfoNomsem.Rows
                dtDatos.Rows.Add({dRow("cod_planta"), dRow("reloj"), dRow("nombres"), dRow("cod_depto"), dRow("nombre_depto"), dRow("cod_turno"), dRow("cod_tipo"), "Extras mayores a 30", _
                                  Nothing, "", dRow("periodo"), "", dRow("hrs_normales"), "", dRow("hrs_dobles") + dRow("hrs_triples")})
            Next

            Try
                frmTrabajando.lblAvance.Text = "Nivel 14 con más de 8 hrs. extra"
                Application.DoEvents()
                dtInfoNomsem = sqlExecute("SELECT distinct reloj, nombres, cod_depto, nombre_depto, cod_turno, cod_tipo, ano, periodo, cod_planta FROM tavw " & _
                                          "WHERE cod_tipo = 'A' and nivel >= '14' and (hrs_dobles + hrs_triples) > 8 AND periodo = '" & Per & "' AND ano = '" & Ano & _
                                          "'  AND personalvw.tipo_periodo = '" & cmbTipo.SelectedValue & "' AND  cod_comp = '" & Cia & "'" & _
                                          IIf(cmbTipoEmpleado.SelectedValue <> "***", " AND cod_tipo = '" & cmbTipoEmpleado.SelectedValue & "'", "") & IIf(cmbPlanta.SelectedValue <> "***", " AND personalvw.cod_planta = '" & cmbPlanta.SelectedValue & "'", ""), "TA")
                For Each dRow In dtInfoNomsem.Rows
                    dtDatos.Rows.Add({dRow("cod_planta"), dRow("reloj"), dRow("nombres"), dRow("cod_depto"), dRow("nombre_depto"), dRow("cod_turno"), dRow("cod_tipo"), "Nivel 14 con más de 8 hrs. extra", _
                                      Nothing, "", dRow("periodo"), "", 0, "", 0})
                Next
            Catch ex As Exception

            End Try


            Try
                frmTrabajando.lblAvance.Text = "Vacaciones trabajadas"
                Application.DoEvents()
                dtInfoNomsem = sqlExecute("SELECT * FROM tavw " & _
                                          "WHERE (tavw.comentario like '%VAC%' and tavw.comentario like '%TRAB%') AND periodo = '" & Per & "' AND ano = '" & Ano & _
                                          "'  AND personalvw.tipo_periodo = '" & cmbTipo.SelectedValue & "' AND cod_comp = '" & Cia & "'" & _
                                          IIf(cmbTipoEmpleado.SelectedValue <> "***", " AND cod_tipo = '" & cmbTipoEmpleado.SelectedValue & "'", "") & IIf(cmbPlanta.SelectedValue <> "***", " AND personalvw.cod_planta = '" & cmbPlanta.SelectedValue & "'", ""), "TA")
                For Each dRow In dtInfoNomsem.Rows
                    dtDatos.Rows.Add({dRow("cod_planta"), dRow("reloj"), dRow("nombres"), dRow("cod_depto"), dRow("nombre_depto"), dRow("cod_turno"), dRow("cod_tipo"), "Vacaciones trabajadas", _
                                      Nothing, "", dRow("periodo"), "", 0, "", 0})
                Next
            Catch ex As Exception

            End Try

            frmTrabajando.lblAvance.Text = "Normales mayores al turno"
            Application.DoEvents()
            'Revisión de horas normales mayores al turno
            dtInfoNomsem = sqlExecute("SELECT nomsem.*,nombres,personalvw.cod_comp,cod_turno,personalvw.nombre_depto,cod_tipo,cod_depto,personalVW.horas AS horas_turno, personalvw.cod_planta " & _
                                      "FROM nomsem LEFT JOIN personal.dbo.personalvw ON nomsem.reloj= personalvw.reloj " & _
                                      "WHERE ROUND(hrs_normales,2) > ROUND(personalvw.horas,2) + .01 AND periodo = '" & Per & "' AND ano = '" & Ano & _
                                      "' AND personalvw.tipo_periodo = '" & cmbTipo.SelectedValue & "' AND personalvw.cod_comp = '" & Cia & "'" & _
                                      IIf(cmbTipoEmpleado.SelectedValue <> "***", " AND cod_tipo = '" & cmbTipoEmpleado.SelectedValue & "'", "") & IIf(cmbPlanta.SelectedValue <> "***", " AND personalvw.cod_planta = '" & cmbPlanta.SelectedValue & "'", ""), "TA")
            For Each dRow In dtInfoNomsem.Rows
                dtDatos.Rows.Add({dRow("cod_planta"), dRow("reloj"), dRow("nombres"), dRow("cod_depto"), dRow("nombre_depto"), dRow("cod_turno"), dRow("cod_tipo"), "Horas normales mayores al turno", Nothing, "", dRow("periodo"), "", dRow("hrs_normales")})
            Next

            frmTrabajando.lblAvance.Text = "Sin pareja"
            Application.DoEvents()
            'Revisión de transacciones sin pareja
            dtInfoAsist = sqlExecute("SELECT asist.*,personalvw.cod_comp,nombres, personalvw.nombre_depto, personalvw.cod_planta FROM asist LEFT JOIN personal.dbo.personalvw ON asist.reloj= personalvw.reloj " & _
                                     "WHERE (pareja IS NULL or pareja = 0) AND NOT ausentismo = 1  AND periodo = '" & Per & "' AND ano = '" & Ano & _
                                     "' AND personalvw.tipo_periodo = '" & cmbTipo.SelectedValue & "' AND personalvw.cod_comp = '" & Cia & "'" & _
                                     IIf(cmbTipoEmpleado.SelectedValue <> "***", " AND cod_tipo = '" & cmbTipoEmpleado.SelectedValue & "'", "") & IIf(cmbPlanta.SelectedValue <> "***", " AND personalvw.cod_planta = '" & cmbPlanta.SelectedValue & "'", ""), "TA")
            For Each dRow In dtInfoAsist.Rows
                Application.DoEvents()
                dtDatos.Rows.Add({dRow("cod_planta"), dRow("reloj"), dRow("nombres"), dRow("cod_depto"), dRow("nombre_depto"), dRow("cod_turno"), dRow("cod_tipo"), "Transacción sin pareja", _
                                  dRow("fecha_entro"), IIf(IIf(IsDBNull(dRow("entro")), "", dRow("entro")).ToString.Trim = "", dRow("salio"), dRow("entro")), dRow("periodo")})
            Next

            frmTrabajando.lblAvance.Text = "Horas negativas"
            Application.DoEvents()
            'Revisión de horas negativas
            dtInfoAsist = sqlExecute("SELECT asist.*,personalvw.cod_comp,nombres,personalvw.nombre_depto, personalvw.cod_planta FROM asist LEFT JOIN personal.dbo.personalvw ON asist.reloj= personalvw.reloj " & _
                                     "WHERE LEFT(asist.horas,1) = '-'   AND periodo = '" & Per & "' AND ano = '" & Ano & "' AND personalvw.tipo_periodo = '" & cmbTipo.SelectedValue & "' AND personalvw.cod_comp = '" & Cia & _
                                     "'" & _
                                     IIf(cmbTipoEmpleado.SelectedValue <> "***", " AND cod_tipo = '" & cmbTipoEmpleado.SelectedValue & "'", "") & IIf(cmbPlanta.SelectedValue <> "***", " AND personalvw.cod_planta = '" & cmbPlanta.SelectedValue & "'", ""), "TA")
            For Each dRow In dtInfoAsist.Rows
                Application.DoEvents()
                dtDatos.Rows.Add({dRow("cod_planta"), dRow("reloj"), dRow("nombres"), dRow("cod_depto"), dRow("nombre_depto"), dRow("cod_turno"), dRow("cod_tipo"), "Horas negativas", dRow("fecha_entro"), dRow("hora"), dRow("periodo")})
            Next

            frmTrabajando.lblAvance.Text = "Extras mayores a normales"
            Application.DoEvents()
            'Revisión de horas normales < horas extras, mientras no sea festivo o descanso
            dtInfoAsist = sqlExecute("SELECT asist.*,personalvw.cod_comp,nombres,personalvw.nombre_depto, personalvw.cod_planta FROM asist LEFT JOIN personal.dbo.personalvw ON asist.reloj= personalvw.reloj " & _
                                     "WHERE horas_normales < horas_extras AND NOT horas_normales LIKE '-%' AND NOT LOWER(asist.comentario) LIKE '%festivo%' AND " & _
                                     "NOT LOWER(asist.comentario) LIKE '%descanso%'  AND periodo = '" & Per & "' AND ano = '" & Ano & _
                                     "' AND personalvw.tipo_periodo = '" & cmbTipo.SelectedValue & "' AND personalvw.cod_comp = '" & Cia & "'" & _
                                     IIf(cmbTipoEmpleado.SelectedValue <> "***", " AND cod_tipo = '" & cmbTipoEmpleado.SelectedValue & "'", "") & IIf(cmbPlanta.SelectedValue <> "***", " AND personalvw.cod_planta = '" & cmbPlanta.SelectedValue & "'", ""), "TA")
            For Each dRow In dtInfoAsist.Rows
                Application.DoEvents()
                dtDatos.Rows.Add({dRow("cod_planta"), dRow("reloj"), dRow("nombres"), dRow("cod_depto"), dRow("nombre_depto"), dRow("cod_turno"), dRow("cod_tipo"), _
                                  "Horas extras mayores a normales", dRow("fecha_entro"), _
                                  IIf(IIf(IsDBNull(dRow("entro")), "", dRow("entro")).ToString.Trim = "", dRow("salio"), dRow("entro")), dRow("periodo")})
            Next


            ActivoTrabajando = False

            frmTrabajando.Close()
            frmTrabajando.Dispose()
            If dtDatos.Rows.Count = 0 Then
                MessageBox.Show("No se detectaron errores en las horas.", "Revisión", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                dtFiltroTA = dtDatos.Copy
                frmVistaPrevia.LlamarReporte("Resultado revisión de horas", dtFiltroTA)
                frmVistaPrevia.Show(Me)
            End If


        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub exportacion_quincenal(ByRef dtDatos As DataTable, oWrite As System.IO.StreamWriter)

        Dim dtPeriodoQuincenal As DataTable = sqlExecute("select * from periodos_quincenal where ano+periodo = '" & cmbAno.SelectedValue & cmbPeriodo.SelectedValue & "'", "TA")
        Dim f_ini_q As Date = dtPeriodoQuincenal.Rows(0)("fecha_ini")
        Dim f_fin_q As Date = dtPeriodoQuincenal.Rows(0)("fecha_fin")

        Try
            'Tomar los datos de nomsem, filtrando solo operativos, del periodo, año y compañía seleccionadas

            oWrite.WriteLine("Reloj, Concepto, Valor, Fecha, Factor")
            Dim dtPersonalQuincenal As DataTable = sqlExecute("select * from personal where alta < '" & FechaSQL(f_fin_q) & "' and (baja is null or baja >= '" & FechaSQL(f_ini_q) & "') and tipo_periodo = 'Q'")
            For Each row_personalQuicenal As DataRow In dtPersonalQuincenal.Rows

                Dim hrs_nor As Double = 0
                Dim hrs_extras As Double = 0
                Dim hrs_nopag As Double = 0
                Dim hrs_tarde As Double = 0

                Dim hrs_dobles As Double = 0
                Dim hrs_triples As Double = 0

                Dim primas_dom As Integer = 0
                Dim primas_sab As Integer = 0

                Dim diastr As Integer = 0

                Dim fecha As Date = f_ini_q.AddDays(-1)

                Application.DoEvents()

                '-----Validar Cambio de sueldo con incapacidad
                Dim dtmodsue As New DataTable
                dtmodsue = sqlExecute("select * from personal where reloj = '" & row_personalQuicenal("reloj") & "'")
                If dtmodsue.Rows.Count > 0 Then
                    Dim fha_ult_mod As String = IIf(IsDBNull(dtmodsue.Rows(0).Item("FHA_ULT_MO")), "", dtmodsue.Rows(0).Item("FHA_ULT_MO").ToString)
                    If fha_ult_mod <> "" Then
                        Dim dttemp As DataTable = sqlExecute("select " & _
                                                    "ausentismo.reloj, ausentismo.tipo_aus, ausentismo.fecha, tipo_ausentismo.TIPO_NATURALEZA, " & _
                                                    "periodos_quincenal.ano, periodos_quincenal.periodo from ausentismo left join periodos_quincenal on ausentismo.fecha between " & _
                                                    "fecha_ini and fecha_fin left join tipo_ausentismo on tipo_ausentismo.tipo_aus = ausentismo.tipo_aus " & _
                                                    "where TIPO_NATURALEZA = 'I' and isnull(PERIODO_ESPECIAL, 0) = 0 and '" & FechaSQL(fha_ult_mod) & "' between fecha_ini and fecha_fin and reloj = '" & row_personalQuicenal("reloj") & "'", "TA")
                        If dttemp.Rows.Count > 0 Then
                            MessageBox.Show("El empleado " & row_personalQuicenal("reloj") & " cuenta con incapacidad en la quincena que se aplicó cambio de sueldo. Favor de verificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                    Dim fha_baja As String = IIf(IsDBNull(dtmodsue.Rows(0).Item("baja")), "", dtmodsue.Rows(0).Item("baja").ToString)
                    If fha_baja <> "" Then
                        Dim dttemp As DataTable = sqlExecute("select " & _
                                                "ausentismo.reloj, ausentismo.tipo_aus, ausentismo.fecha, tipo_ausentismo.TIPO_NATURALEZA, " & _
                                                "periodos.ano, periodos.periodo from ausentismo left join periodos on ausentismo.fecha between " & _
                                                "fecha_ini and fecha_fin left join tipo_ausentismo on tipo_ausentismo.tipo_aus = ausentismo.tipo_aus left join PERSONAL.dbo.personal on ausentismo.RELOJ = personal.reloj  " & _
                                                "where TIPO_NATURALEZA = 'I' and isnull(PERIODO_ESPECIAL, 0) = 0 and '" & FechaSQL(fha_baja) & "' between fecha_ini and fecha_fin and ausentismo.reloj = '" & row_personalQuicenal("reloj") & "' and periodos.ano+periodos.periodo = '" & cmbAno.SelectedValue & cmbPeriodo.SelectedValue & "' and baja is not null", "TA")
                        If dttemp.Rows.Count > 0 Then
                            MessageBox.Show("El empleado " & row_personalQuicenal("reloj") & " se encuentra dado de baja y cuenta con una incapacidad en la semana. Favor de verificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End If
                End If




                Dim dtAsistQuincenal As DataTable = sqlExecute("select * from asist where reloj = '" & row_personalQuicenal("reloj") & "' and fha_ent_hor between '" & FechaSQL(f_ini_q) & "' and '" & FechaSQL(f_fin_q) & "'", "ta")
                For Each drAsist In dtAsistQuincenal.Rows

                    Dim EsDomingo As Boolean = False
                    Dim EsSabado As Boolean = False

                    If Date.Parse(drAsist("fha_ent_hor")).Date <> fecha.Date Then
                        diastr += 1
                    End If

                    fecha = drAsist("fha_ent_hor")

                    'Definir si esta fecha corresponde a un día festivo, domingo o descanso                
                    EsDomingo = DiaSem(fecha).ToLower = "domingo"
                    EsSabado = DiaSem(fecha).ToLower = "sábado"
                    'EsDescanso = DiaDescanso(Fecha, R)
                    'EsFestivo = Festivo(Fecha, R)

                    'Sumar horas

                    hrs_nor = hrs_nor + HtoD(drAsist("horas_normales"))
                    hrs_tarde = hrs_tarde + HtoD(drAsist("horas_tarde"))


                    If HtoD(drAsist("horas_anticipadas")) < 0 Then
                        hrs_nopag += HtoD(drAsist("horas_anticipadas")) * -1
                    End If

                    If HtoD(drAsist("horas_tarde")) > 0 Then
                        hrs_nopag += HtoD(drAsist("horas_tarde"))
                    End If

                    hrs_extras = hrs_extras + HtoD(drAsist("extras_autorizadas"))

                    'Contabilizar horas extras



                    'Si es domingo
                    Try
                        If EsDomingo Then

                            Dim hrs_prim_dom As Double = drAsist("extras_autorizadas") + drAsist("horas_normales")

                            If hrs_prim_dom > 0 Then
                                primas_dom += 1
                            Else
                                Dim dtComentario As DataTable = sqlExecute("select * from asist where reloj = '" & row_personalQuicenal("reloj") & "' and fha_ent_hor = '" & FechaSQL(drAsist("fha_ent_hor")) & "'", "TA")
                                For Each r_comentario As DataRow In dtComentario.Rows
                                    Dim comentario As String = r_comentario("comentario")
                                    If comentario.ToUpper.Contains("FALTA") Then
                                        If (comentario.ToUpper.Contains("SALIDA") Or comentario.ToUpper.Contains("ENTRADA")) Then
                                            primas_dom += 1
                                        End If
                                    End If
                                Next

                            End If
                        End If


                    Catch ex As Exception

                    End Try


                    Try
                        If EsSabado Then

                            Dim hrs_prim_sab As Double = drAsist("extras_autorizadas") + drAsist("horas_normales")

                            If hrs_prim_sab > 0 Then
                                primas_sab += 1
                            Else
                                Dim dtComentario As DataTable = sqlExecute("select * from asist where reloj = '" & row_personalQuicenal("reloj") & "' and fha_ent_hor = '" & FechaSQL(drAsist("fha_ent_hor")) & "'", "TA")
                                For Each r_comentario As DataRow In dtComentario.Rows
                                    Dim comentario As String = r_comentario("comentario")
                                    If comentario.ToUpper.Contains("FALTA") Then
                                        If (comentario.ToUpper.Contains("SALIDA") Or comentario.ToUpper.Contains("ENTRADA")) Then
                                            primas_sab += 1

                                        End If
                                    End If
                                Next

                            End If
                        End If


                    Catch ex As Exception

                    End Try


                Next

                If hrs_extras >= 9 Then
                    hrs_dobles = 9
                    hrs_triples = hrs_extras - 9
                Else
                    hrs_dobles = hrs_extras
                    hrs_triples = 0
                End If

                Dim dDato As DataRow = dtDatos.NewRow
                dDato("reloj") = row_personalQuicenal("reloj")
                dDato("cod_tipo") = ""
                dDato("cod_depto") = ""
                dDato("nombre_depto") = ""
                dDato("cod_super") = ""
                dDato("super") = ""
                dDato("HRSNOR") = hrs_nor
                dDato("HRSFES") = 0
                dDato("HORDOB") = hrs_dobles
                dDato("HORTRI") = hrs_triples
                dDato("HORDOM") = 0
                dDato("DIVACA") = 0 '
                dDato("DIAGUI") = 0 ' IIf(IsDBNull(dRow("dias_aguinaldo")), 0, dRow("dias_aguinaldo"))
                dDato("BONO01") = 0
                dDato("BONO02") = 0
                dDato("BONO03") = 0
                dDato("BONO04") = 0
                dDato("BONO05") = 0
                dDato("bono06") = 0
                dDato("bono07") = 0
                dDato("bono08") = 0
                dDato("bono09") = 0
                dDato("bono10") = 0

                dDato("PRIMA_DOM") = primas_dom
                dDato("PRIMA_SAB") = primas_sab

                dDato("HORDIN") = 0
                dDato("HORTIN") = 0
                dDato("DIASTR") = diastr

                dDato("DIASCM") = 0

                dDato("HRS_NOPAG") = hrs_nopag
                dDato("HRS_RETARDO") = hrs_tarde

                dtDatos.Rows.Add(dDato)


                If dDato("HRSNOR") > 0 Then
                    'oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",HRSNOR," & String.Format("{0:0.00}", dDato("HRSNOR")))
                End If
                If dDato("HORDOB") > 0 Then
                    oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",HRSEX2," & String.Format("{0:0.00}", dDato("HORDOB")))
                End If
                If dDato("HORTRI") > 0 Then
                    oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",HRSEX3," & String.Format("{0:0.00}", dDato("HORTRI")))
                End If
                If dDato("HRS_RETARDO") > 0 Then
                    oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",HRSRET," & String.Format("{0:0.00}", dDato("HRS_RETARDO")))
                End If
                If dDato("HRS_NOPAG") > 0 Then
                    oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",HRSPSG," & String.Format("{0:0.00}", dDato("HRS_NOPAG")))
                End If

                If dDato("PRIMA_DOM") > 0 Then
                    oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",DIADOM," & String.Format("{0:0.00}", dDato("PRIMA_DOM")))
                End If

                If dDato("PRIMA_SAB") > 0 Then
                    oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",DIASAB," & String.Format("{0:0.00}", dDato("PRIMA_SAB")))
                End If

                If dDato("DIASTR") > 0 Then
                    oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",DIASTR," & String.Format("{0:0.00}", dDato("DIASTR")))
                End If

                Dim q_ausentismo As String = "select ausentismo.reloj, ausentismo.fecha, ausentismo.tipo_aus, tipo_ausentismo.NOMBRE, percepcion, cancelacion, deduccion, devolucion " & _
                    "from ausentismo left join periodos_quincenal on ausentismo.fecha between periodos_quincenal.fecha_ini and periodos_quincenal.fecha_fin " & _
                    "left join tipo_ausentismo on tipo_ausentismo.tipo_aus = ausentismo.tipo_aus " & _
                    "where periodos_quincenal.ano = '" & cmbAno.SelectedValue & "' and periodos_quincenal.periodo = '" & cmbPeriodo.SelectedValue & "' and reloj = '" & dDato("reloj").ToString.Trim.PadLeft(6) & "'"

                Dim dtAus As DataTable = sqlExecute(q_ausentismo, "TA")




                If dtAus.Rows.Count > 0 Then
                    For Each row As DataRow In dtAus.Select("tipo_aus in ('FI', 'C50')")
                        Dim percepcion_aus As Boolean = Not IsDBNull(row("percepcion"))
                        Dim deduccion_aus As Boolean = Not IsDBNull(row("deduccion"))
                        If percepcion_aus Then
                            oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & "," & row("percepcion") & "," & 1 & "," & FechaSQL(row("fecha")))
                            dDato(row("percepcion")) = 1
                        ElseIf deduccion_aus Then
                            oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & "," & row("deduccion") & "," & 1 & "," & FechaSQL(row("fecha")))
                            dDato(row("deduccion")) = 1
                        Else
                            oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",ERROR," & 1 & "," & FechaSQL(row("fecha")))
                        End If

                    Next
                End If




                

                Dim dtComedor As DataTable = sqlExecute("select reloj, sum(case when subsidio = 'C' then 1 else 0 end) as CON_SUBSIDIO, " & _
                "sum(case when subsidio = 'S' then 1 else 0 end) as SIN_SUBSIDIO from hrs_brt_cafeteria " & _
                "left join periodos_quincenal on hrs_brt_cafeteria.fecha between periodos_quincenal.fecha_ini and periodos_quincenal.FECHA_FIN " & _
                "where periodos_quincenal.ano + periodos_quincenal.periodo = '" & cmbAno.SelectedValue & cmbPeriodo.SelectedValue & "' and hrs_brt_cafeteria.reloj = '" & dDato("reloj").ToString.Trim.PadLeft(6) & "'" & _
                "group by  reloj", "TA")
                If dtComedor.Rows.Count > 0 Then
                    If dtComedor.Rows(0)("CON_SUBSIDIO") > 0 Then
                        oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",DIACON," & dtComedor.Rows(0)("CON_SUBSIDIO"))
                        dDato("DIACON") = dtComedor.Rows(0)("CON_SUBSIDIO")
                    End If
                    If dtComedor.Rows(0)("SIN_SUBSIDIO") > 0 Then
                        oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",DIASIN," & dtComedor.Rows(0)("SIN_SUBSIDIO"))
                        dDato("DIASIN") = dtComedor.Rows(0)("SIN_SUBSIDIO")
                    End If
                End If


            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        End Try
    End Sub

    Private Sub btnTransferencia_Click(sender As Object, e As EventArgs) Handles btnTransferencia.Click
        If cmbTipoEmpleado.SelectedValue <> "***" Or cmbPlanta.SelectedValue <> "***" Then
            Dim m As String = "Se realizará la exportación aplicando los siguientes filtros"
            m &= IIf(cmbTipoEmpleado.SelectedValue <> "***", vbCrLf & "- Tipo de empleado= '" & cmbTipoEmpleado.SelectedValue & "'", "")
            m &= IIf(cmbPlanta.SelectedValue <> "***", vbCrLf & "- Planta = '" & cmbPlanta.SelectedValue & "'", "")
            MessageBox.Show(m, "Filtros al exportar", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        Try
            Dim dtVacTrab As DataTable = sqlExecute("select reloj, isnull(comentario, '') as comentario from ajustes_nom where concepto = 'DIASVA' and ano = '" & cmbAno.SelectedValue & "' and tipo_periodo = '" & cmbTipo.SelectedValue & "' and periodo = '" & cmbPeriodo.SelectedValue & "'", "NOMINA")
            Dim mensaje_trabajadas As String = ""
            For Each row As DataRow In dtVacTrab.Rows
                Dim comentario As String = RTrim(row("comentario"))
                Try
                    Dim _r_trab As String = row("reloj")
                    Dim fecha As String = comentario.Split(",")(1)

                    Dim dtTrab As DataTable = sqlExecute("select * from asist where reloj = '" & _r_trab & "' and fha_ent_hor = '" & FechaSQL(fecha) & "' and (comentario like '%VAC%' and comentario like '%TRAB%')", "TA")
                    If dtTrab.Rows.Count > 0 Then
                        mensaje_trabajadas &= vbCrLf & _r_trab & ", " & "Vacaciones trabajadas, " & fecha
                    End If
                Catch ex As Exception

                End Try
            Next
            If mensaje_trabajadas <> "" Then
                MessageBox.Show("Advertencia. Existen vacaciones trabajadas" & mensaje_trabajadas, "Vacaciones trabajadas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If


        Catch ex As Exception

        End Try


        Dim dtDatos As New DataTable
        Dim dtInfoNomsem As New DataTable
        Dim dRow As DataRow
        Dim Ano As String
        Dim Per As String
        Dim Cia As String

        Dim strFileName As String = ""
        Dim oWrite As System.IO.StreamWriter
        Dim GuardaArchivo As Boolean = True

        Try
            Me.Cursor = Cursors.WaitCursor
            Ano = cmbAno.SelectedValue
            Per = cmbPeriodo.SelectedValue
            Cia = cmbCia.SelectedValue

            Dim c As Integer = 0
            Dim dDato As DataRow

            Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog

            PreguntaArchivo.Filter = "Archivo CSV|*.csv"
            PreguntaArchivo.FileName = Cia & "hrspc " & Ano & "-" & Per & ".csv"
            If PreguntaArchivo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                strFileName = PreguntaArchivo.FileName
            Else
                Exit Sub
            End If
            Try
                oWrite = File.CreateText(strFileName)
                GuardaArchivo = True
            Catch ex As Exception
                oWrite = Nothing
                GuardaArchivo = False
                MessageBox.Show("El archivo no pudo ser creado." & vbCrLf & vbCrLf & "Err.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try

            frmTrabajando.Show(Me)
            frmTrabajando.Avance.Value = 0
            frmTrabajando.Avance.IsRunning = False
            frmTrabajando.lblAvance.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
            frmTrabajando.lblAvance.Text = "Preparando datos..."
            Application.DoEvents()

            dtDatos.Columns.Add("grupo")
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("cod_tipo")
            dtDatos.Columns.Add("cod_depto")
            dtDatos.Columns.Add("nombre_depto")
            dtDatos.Columns.Add("cod_super")
            dtDatos.Columns.Add("super")
            dtDatos.Columns.Add("HRSNOR", GetType(System.Double))
            dtDatos.Columns.Add("HORFES", GetType(System.Double))
            dtDatos.Columns.Add("HRSFEL", GetType(System.Double))
            dtDatos.Columns.Add("HORDOB", GetType(System.Double))
            dtDatos.Columns.Add("HORTRI", GetType(System.Double))
            dtDatos.Columns.Add("HORDOM", GetType(System.Double))
            dtDatos.Columns.Add("DIVACA", GetType(System.Double))
            dtDatos.Columns.Add("DIAGUI", GetType(System.Double))
            dtDatos.Columns.Add("BONO01", GetType(System.Double))
            dtDatos.Columns.Add("BONO02", GetType(System.Double))
            dtDatos.Columns.Add("BONO03", GetType(System.Double))
            dtDatos.Columns.Add("BONO04", GetType(System.Double))
            dtDatos.Columns.Add("BONO05", GetType(System.Double))
            dtDatos.Columns.Add("BONO06", GetType(System.Double))
            dtDatos.Columns.Add("BONO07", GetType(System.Double))
            dtDatos.Columns.Add("BONO08", GetType(System.Double))
            dtDatos.Columns.Add("BONO09", GetType(System.Double))
            dtDatos.Columns.Add("BONO10", GetType(System.Double))
            dtDatos.Columns.Add("HORDIN", GetType(System.Double))
            dtDatos.Columns.Add("HORTIN", GetType(System.Double))
            dtDatos.Columns.Add("DIASTR", GetType(System.Double))

            dtDatos.Columns.Add("PRIMA_DOM", GetType(System.Double))
            dtDatos.Columns.Add("PRIMA_SAB", GetType(System.Double))

            dtDatos.Columns.Add("DIASCM", GetType(System.Double))

            dtDatos.Columns.Add("HRS_NOPAG", GetType(System.Double))
            dtDatos.Columns.Add("HRS_RETARDO", GetType(System.Double))

            dtDatos.Columns.Add("NOMBRES", GetType(System.String))
            dtDatos.Columns.Add("NOMBRE_AREA", GetType(System.String))
            dtDatos.Columns.Add("NOMBRE_CLERK", GetType(System.String))

            Dim dttiposausper As DataTable = sqlExecute("select distinct percepcion from tipo_ausentismo where percepcion is not null", "TA")
            Dim dttiposausded As DataTable = sqlExecute("select distinct deduccion from tipo_ausentismo where deduccion is not null", "TA")


            For Each trowp As DataRow In dttiposausper.Rows
                dtDatos.Columns.Add(Trim(trowp("percepcion")), GetType(System.Double))
            Next
            For Each trowd As DataRow In dttiposausded.Rows
                dtDatos.Columns.Add(Trim(trowd("deduccion")), GetType(System.Double))
            Next

            dtDatos.Columns.Add("DIACON", GetType(System.Double))
            dtDatos.Columns.Add("DIASIN", GetType(System.Double))
            dtDatos.Columns.Add("DIADES", GetType(System.Double))
            dtDatos.Columns.Add("ANO")
            dtDatos.Columns.Add("PERIODO")


            '***************************************

            If cmbTipo.SelectedValue = "Q" Then
                exportacion_quincenal(dtDatos, oWrite)
            Else
                Dim dtPeriodoSemanal As DataTable = sqlExecute("select * from periodos where ano+periodo = '" & cmbAno.SelectedValue & cmbPeriodo.SelectedValue & "'", "TA")
                Dim f_ini_s As Date = dtPeriodoSemanal.Rows(0)("fecha_ini")
                Dim f_fin_s As Date = dtPeriodoSemanal.Rows(0)("fecha_fin")
                dtInfoNomsem = sqlExecute("SELECT nomsem.*, personalvw.nombres,personalvw.nombre_area,personalvw.nombre_clerk,personalvw.alta, personalvw.baja, personalvw.cod_planta,cod_tipo, cod_depto,personalvw.nombre_depto,cod_super,dias_vacaciones,dias_aguinaldo,nombre_super AS super FROM ta.dbo.nomsem " & _
                                     "LEFT JOIN personal.dbo.personalvw ON nomsem.reloj = personalvw.reloj " & _
                                     "WHERE nomsem.periodo = '" & Per & "' AND ano = '" & Ano & "' AND personalvw.tipo_periodo = '" & cmbTipo.SelectedValue & "' AND personalvw.cod_comp = '" & Cia & "' " & _
                                     IIf(cmbTipoEmpleado.SelectedValue <> "***", " AND cod_tipo = '" & cmbTipoEmpleado.SelectedValue & "'", "") & IIf(cmbPlanta.SelectedValue <> "***", " AND personalvw.cod_planta = '" & cmbPlanta.SelectedValue & "'", ""), "TA")



                If dtInfoNomsem.Rows.Count = 0 Then
                    MessageBox.Show("No se localizaron registros correspondientes a los parámetros indicados. Favor de verificar.", "Procesar horas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                frmTrabajando.Avance.Maximum = dtInfoNomsem.Rows.Count

                Dim mensaje_bajas As String = ""
                oWrite.WriteLine("Reloj, Concepto, Valor, Fecha, Factor")
                '------Recorrer a cada empleado 
                For Each dRow In dtInfoNomsem.Rows
                    If Not ActivoTrabajando Then
                        oWrite.Close()
                        Exit Sub
                    End If
                    frmTrabajando.lblAvance.Text = dRow("reloj")
                    frmTrabajando.Avance.Value += 1
                    Application.DoEvents()

                    '-----Validar Cambio de sueldo con incapacidad
                    Dim dtmodsue As New DataTable
                    dtmodsue = sqlExecute("select * from personal where reloj = '" & dRow("reloj") & "'")
                    If dtmodsue.Rows.Count > 0 Then
                        Dim fha_ult_mod As String = IIf(IsDBNull(dtmodsue.Rows(0).Item("FHA_ULT_MO")), "", dtmodsue.Rows(0).Item("FHA_ULT_MO").ToString)
                        If fha_ult_mod <> "" Then
                            Dim dttemp As DataTable = sqlExecute("select " & _
                                                     "ausentismo.reloj, ausentismo.tipo_aus, ausentismo.fecha, tipo_ausentismo.TIPO_NATURALEZA, " & _
                                                     "periodos.ano, periodos.periodo from ausentismo left join periodos on ausentismo.fecha between " & _
                                                     "fecha_ini and fecha_fin left join tipo_ausentismo on tipo_ausentismo.tipo_aus = ausentismo.tipo_aus " & _
                                                     "where TIPO_NATURALEZA = 'I' and isnull(PERIODO_ESPECIAL, 0) = 0 and '" & FechaSQL(fha_ult_mod) & "' between fecha_ini and fecha_fin and reloj = '" & dRow("reloj") & "' and periodos.ano+periodos.periodo = '" & Ano + Per & "'", "TA")
                            If dttemp.Rows.Count > 0 Then
                                MessageBox.Show("El empleado " & dRow("reloj") & " cuenta con incapacidad en la semana que se aplicó cambio de sueldo. Favor de verificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If
                        Dim fha_baja As String = IIf(IsDBNull(dtmodsue.Rows(0).Item("baja")), "", dtmodsue.Rows(0).Item("baja").ToString)
                        If fha_baja <> "" Then
                            Dim dttemp As DataTable = sqlExecute("select " & _
                                                    "ausentismo.reloj, ausentismo.tipo_aus, ausentismo.fecha, tipo_ausentismo.TIPO_NATURALEZA, " & _
                                                    "periodos.ano, periodos.periodo from ausentismo left join periodos on ausentismo.fecha between " & _
                                                    "fecha_ini and fecha_fin left join tipo_ausentismo on tipo_ausentismo.tipo_aus = ausentismo.tipo_aus left join PERSONAL.dbo.personal on ausentismo.RELOJ = personal.reloj  " & _
                                                    "where TIPO_NATURALEZA = 'I' and isnull(PERIODO_ESPECIAL, 0) = 0 and '" & FechaSQL(fha_baja) & "' between fecha_ini and fecha_fin and ausentismo.reloj = '" & dRow("reloj") & "' and periodos.ano+periodos.periodo = '" & Ano + Per & "' and baja is not null", "TA")
                            If dttemp.Rows.Count > 0 Then
                                MessageBox.Show("El empleado " & dRow("reloj") & " se encuentra dado de baja y cuenta con una incapacidad en la semana. Favor de verificar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            End If
                        End If
                    End If

                    '----Validar un solo registro en nomsem 
                    Dim dtchecknomsem As New DataTable
                    dtchecknomsem = sqlExecute("select * from nomsem where reloj = '" & dRow("reloj") & "' and periodo = '" & Per & "' and ano = '" & Ano & "'", "TA")
                    If dtchecknomsem.Rows.Count > 1 Then
                        frmTrabajando.Hide()
                        MessageBox.Show("Se detectó una discrepancia en el análisis del empleado " & dRow("reloj") & ". Favor de contactar a PIDA", "Procesar horas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Exit Sub
                    End If


                    dDato = dtDatos.NewRow
                    dDato("reloj") = dRow("reloj")
                    dDato("cod_tipo") = dRow("cod_tipo")
                    dDato("cod_depto") = dRow("cod_depto")
                    dDato("nombre_depto") = dRow("nombre_depto")
                    dDato("cod_super") = dRow("cod_super")
                    dDato("super") = dRow("super")
                    dDato("HRSNOR") = IIf(IsDBNull(dRow("hrs_normales")), 0, dRow("hrs_normales"))
                    ' dDato("HRSFES") = IIf(IsDBNull(dRow("hrs_festivo")), 0, dRow("hrs_festivo"))
                    dDato("HORFES") = IIf(IsDBNull(dRow("hrs_fel")), 0, dRow("hrs_fel"))
                    dDato("HRSFEL") = IIf(IsDBNull(dRow("hrs_fel")), 0, dRow("hrs_fel"))
                    dDato("HORDOB") = IIf(IsDBNull(dRow("hrs_dobles")), 0, dRow("hrs_dobles"))
                    dDato("HORTRI") = IIf(IsDBNull(dRow("hrs_triples")), 0, dRow("hrs_triples"))
                    dDato("HORDOM") = IIf(IsDBNull(dRow("hrs_prim_dom")), 0, dRow("hrs_prim_dom"))
                    dDato("DIVACA") = 0 ' IIf(IsDBNull(dRow("dias_vacaciones")), 0, dRow("dias_vacaciones"))
                    dDato("DIAGUI") = 0 ' IIf(IsDBNull(dRow("dias_aguinaldo")), 0, dRow("dias_aguinaldo"))
                    dDato("BONO01") = IIf(IsDBNull(dRow("bono01")), 0, dRow("bono01"))
                    dDato("BONO02") = IIf(IsDBNull(dRow("bono02")), 0, dRow("bono02"))
                    dDato("BONO03") = IIf(IsDBNull(dRow("bono03")), 0, dRow("bono03"))
                    dDato("BONO04") = IIf(IsDBNull(dRow("bono04")), 0, dRow("bono04"))
                    dDato("BONO05") = IIf(IsDBNull(dRow("bono05")), 0, dRow("bono05"))
                    dDato("bono06") = IIf(IsDBNull(dRow("bono06")), 0, dRow("bono06"))
                    dDato("bono07") = IIf(IsDBNull(dRow("bono07")), 0, dRow("bono07"))
                    dDato("bono08") = IIf(IsDBNull(dRow("bono08")), 0, dRow("bono08"))
                    dDato("bono09") = IIf(IsDBNull(dRow("bono09")), 0, dRow("bono09"))
                    dDato("bono10") = IIf(IsDBNull(dRow("bono10")), 0, dRow("bono10"))

                    dDato("PRIMA_DOM") = IIf(IsDBNull(dRow("PRIMA_DOM")), 0, dRow("PRIMA_DOM"))
                    dDato("PRIMA_SAB") = IIf(IsDBNull(dRow("PRIMA_SAB")), 0, dRow("PRIMA_SAB"))

                    dDato("HORDIN") = IIf(IsDBNull(dRow("dobles_33")), 0, dRow("dobles_33"))
                    dDato("HORTIN") = IIf(IsDBNull(dRow("triples_33")), 0, dRow("triples_33"))
                    'dDato("DIASTR") = IIf(IsDBNull(dRow("dias_trabajados")), 0, dRow("dias_trabajados"))
                    dDato("DIASTR") = 0
                    dDato("DIASCM") = 0  'dias_comida(dRow("reloj"), Ano & Per)

                    dDato("HRS_NOPAG") = IIf(IsDBNull(dRow("HRS_NOPAG")), 0, dRow("HRS_NOPAG"))
                    dDato("HRS_RETARDO") = IIf(IsDBNull(dRow("HRS_RETARDO")), 0, dRow("HRS_RETARDO"))

                    dDato("NOMBRES") = IIf(IsDBNull(dRow("NOMBRES")), "", dRow("NOMBRES"))
                    dDato("NOMBRE_AREA") = IIf(IsDBNull(dRow("NOMBRE_AREA")), "", dRow("NOMBRE_AREA"))
                    dDato("NOMBRE_CLERK") = IIf(IsDBNull(dRow("NOMBRE_CLERK")), "", dRow("NOMBRE_CLERK"))

                    dtDatos.Rows.Add(dDato)

                    'nomsem_ref_horas se utiliza solamente para saber qué registros se modifican, 
                    'y poder crear el archivo de correciones
                    dtTemporal = sqlExecute("SELECT reloj FROM nomsem_ref_horas WHERE ano = '" & Ano & "' AND periodo= '" & _
                                            Per & "' AND reloj = '" & dRow("reloj") & "'", "TA")
                    If dtTemporal.Rows.Count = 0 Then
                        'Si no existe el registro, crearlo
                        sqlExecute("INSERT INTO nomsem_ref_horas (ano,periodo,reloj) VALUES ('" & Ano & "','" & Per & "','" & _
                                   dRow("reloj") & "')", "TA")
                    End If

                    sqlExecute("UPDATE nomsem_ref_horas SET " & _
                               "HRSNOR = " & dDato("HRSNOR") & _
                               ",HORFES = " & dDato("HORFES") & _
                               ",HORDOB = " & dDato("HORDOB") & _
                               ",HORTRI = " & dDato("HORTRI") & _
                               ",HORDOM = " & dDato("HORDOM") & _
                               ",DIVACA = " & dDato("DIVACA") & _
                               ",DIAGUI = " & dDato("DIAGUI") & _
                               ",BONO01 = " & dDato("BONO01") & _
                               ",BONO02 = " & dDato("BONO02") & _
                               ",BONO03 = " & dDato("BONO03") & _
                               ",BONO04 = " & dDato("BONO04") & _
                               ",BONO05 = " & dDato("BONO05") & _
                               ",BONO06 = " & dDato("BONO06") & _
                               ",BONO07 = " & dDato("BONO07") & _
                               ",BONO08 = " & dDato("BONO08") & _
                               ",BONO09 = " & dDato("BONO09") & _
                               ",BONO10 = " & dDato("BONO10") & _
                               ",HORDIN = " & dDato("HORDIN") & _
                               ",HORTIN = " & dDato("HORTIN") & _
                               ",DIASTR = " & dDato("DIASTR") & _
                               " WHERE ano = '" & Ano & "' AND periodo= '" & Per & "' AND reloj = '" & dRow("reloj") & "'", "TA")

                    If dDato("HRSNOR") > 0 Then
                        oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",HRSNOR," & String.Format("{0:0.00}", dDato("HRSNOR")))
                    End If
                    If dDato("HORDOB") > 0 Then
                        oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",HRSEX2," & String.Format("{0:0.00}", dDato("HORDOB")))
                    End If
                    If dDato("HORTRI") > 0 Then
                        oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",HRSEX3," & String.Format("{0:0.00}", dDato("HORTRI")))
                    End If
                    If dDato("HRS_RETARDO") > 0 Then
                        Dim factor As String = ""
                        Dim fecha_hrs As Date
                        Dim fecha_fin As Date
                        Dim dtTempP As New DataTable
                        dtTempP = sqlExecute("select * from periodos where ano = '" & Ano & "' and periodo = '" & Per & "' and isnull(periodo_especial,0)=0", "TA") ' AOS: 2022-12-14
                        If dtTempP.Rows.Count > 0 Then
                            fecha_hrs = dtTempP.Rows(0).Item("fecha_ini")
                            fecha_fin = dtTempP.Rows(0).Item("fecha_fin")
                            Dim dtper As New DataTable

                            dtper = sqlExecute("select * from personal where reloj = '" & dDato("reloj").ToString.Trim.PadLeft(6) & "'")
                            Dim cod_hora As String = "", cod_turno As String = "" ' AOS 2022-02-10
                            If dtper.Rows.Count > 0 Then
                                ConsultaBitacora(dtper, dtper.Rows(0), fecha_hrs)
                                cod_turno = ConsultaBitacoraHorarios(dtper, dtper.Rows(0), fecha_fin, "cod_turno") ' AOS 2022-02-10
                                cod_hora = ConsultaBitacoraHorarios(dtper, dtper.Rows(0), fecha_fin, "cod_hora") ' AOS 2022-02-10
                                dtper.Rows(0).Item("cod_hora") = cod_hora ' AOS 2022-02-10
                                dtper.Rows(0).Item("cod_turno") = cod_turno ' AOS 2022-02-10
                                factor = ObtenerFactor(dtper.Rows(0).Item("cod_hora"), ObtenerAnoPeriodo(fecha_hrs, "S").ToString.Substring(0, 4), ObtenerAnoPeriodo(fecha_hrs, "S").ToString.Substring(4, 2))

                            End If
                        End If
                        oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",HRSRET," & String.Format("{0:0.00}", dDato("HRS_RETARDO")) & "," & FechaSQL(fecha_hrs) & "," & factor)
                    End If
                    If dDato("HRS_NOPAG") > 0 Then
                        Dim factor As String = ""
                        Dim dtTempP As New DataTable
                        Dim fecha_hrs As Date
                        Dim fecha_fin As Date ' AOS 2022-02-10
                        dtTempP = sqlExecute("select * from periodos where ano = '" & Ano & "' and periodo = '" & Per & "'", "TA")
                        If dtTempP.Rows.Count > 0 Then
                            fecha_hrs = dtTempP.Rows(0).Item("fecha_ini")
                            fecha_fin = dtTempP.Rows(0).Item("fecha_fin")
                            Dim dtper As New DataTable

                            dtper = sqlExecute("select * from personal where reloj = '" & dDato("reloj").ToString.Trim.PadLeft(6) & "'")
                            Dim cod_hora As String = "", cod_turno As String = "" ' AOS 2022-02-10
                            If dtper.Rows.Count > 0 Then
                                ConsultaBitacora(dtper, dtper.Rows(0), fecha_hrs)
                                cod_turno = ConsultaBitacoraHorarios(dtper, dtper.Rows(0), fecha_fin, "cod_turno") ' AOS 2022-02-10
                                cod_hora = ConsultaBitacoraHorarios(dtper, dtper.Rows(0), fecha_fin, "cod_hora") ' AOS 2022-02-10
                                dtper.Rows(0).Item("cod_hora") = cod_hora ' AOS 2022-02-10
                                dtper.Rows(0).Item("cod_turno") = cod_turno ' AOS 2022-02-10
                                factor = ObtenerFactor(dtper.Rows(0).Item("cod_hora"), ObtenerAnoPeriodo(fecha_hrs, "S").ToString.Substring(0, 4), ObtenerAnoPeriodo(fecha_hrs, "S").ToString.Substring(4, 2))

                            End If
                        End If
                        oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",HRSPSG," & String.Format("{0:0.00}", dDato("HRS_NOPAG")) & "," & FechaSQL(fecha_hrs) & "," & factor)
                    End If

                    If dDato("PRIMA_DOM") > 0 Then
                        oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",DIADOM," & String.Format("{0:0.00}", dDato("PRIMA_DOM")))
                    End If

                    If dDato("PRIMA_SAB") > 0 Then
                        oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",DIASAB," & String.Format("{0:0.00}", dDato("PRIMA_SAB")))
                    End If

                    If dDato("HRSFEL") > 0 Then
                        oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",HRSFEL," & String.Format("{0:0.00}", dDato("HRSFEL")))
                    End If
                    Dim q_ausentismo As String = "select ausentismo.reloj, ausentismo.fecha, ausentismo.tipo_aus, tipo_ausentismo.NOMBRE, percepcion, cancelacion, deduccion, devolucion " & _
                        "from ausentismo left join periodos on ausentismo.fecha between periodos.fecha_ini and periodos.fecha_fin " & _
                        "left join tipo_ausentismo on tipo_ausentismo.tipo_aus = ausentismo.tipo_aus " & _
                        "where periodos.ano = '" & Ano & "' and periodos.periodo = '" & Per & "' and reloj = '" & dDato("reloj").ToString.Trim.PadLeft(6) & "'"

                    Dim dtAus As DataTable = sqlExecute(q_ausentismo, "TA")




                    If dtAus.Rows.Count > 0 Then
                        'For Each row As DataRow In dtAus.Rows
                        For Each row As DataRow In dtAus.Select("tipo_aus in ('FI', 'C50')")


                            Dim dtTempfi As DataTable = sqlExecute("select * from asist where reloj = '" & row("reloj") & "' and fha_ent_hor = '" & FechaSQL(row("fecha")) & "' AND tipo_aus = '" & row("tipo_aus") & "'", "TA")


                            If dtTempfi.Rows.Count > 0 Then
                                Dim dtper As New DataTable
                                Dim factor As String = ""
                                dtper = sqlExecute("select * from personal where reloj = '" & row("reloj") & "'")
                                If dtper.Rows.Count > 0 Then
                                    ConsultaBitacora(dtper, dtper.Rows(0), row("fecha"))
                                    factor = ObtenerFactor(dtper.Rows(0).Item("cod_hora"), ObtenerAnoPeriodo(row("fecha"), "S").ToString.Substring(0, 4), ObtenerAnoPeriodo(row("fecha"), "S").ToString.Substring(4, 2))

                                End If
                                Dim percepcion_aus As Boolean = Not IsDBNull(row("percepcion"))
                                Dim deduccion_aus As Boolean = Not IsDBNull(row("deduccion"))
                                If percepcion_aus Then
                                    oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & "," & row("percepcion") & "," & 1 & "," & FechaSQL(row("fecha")) & "," & factor)
                                    If IsDBNull(dDato(row("percepcion"))) Then
                                        dDato(row("percepcion")) = 1
                                    Else
                                        dDato(row("percepcion")) += 1
                                    End If
                                ElseIf deduccion_aus Then
                                    oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & "," & row("deduccion") & "," & 1 & "," & FechaSQL(row("fecha")) & "," & factor)
                                    If IsDBNull(dDato(row("deduccion"))) Then
                                        dDato(row("deduccion")) = 1
                                    Else
                                        dDato(row("deduccion")) += 1
                                    End If
                                Else
                                    oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",ERROR," & 1 & "," & FechaSQL(row("fecha")) & "," & factor)
                                End If
                            End If

                        Next
                    End If


                    Try
                        Dim dtIntegrables As DataTable = sqlExecute("select reloj, sum(dobles_33) as dobles_33, sum(triples_33) as triples_33 from asist where fha_ent_hor between '" & FechaSQL(f_ini_s) & "' and '" & FechaSQL(f_fin_s) & "' and reloj = '" & dDato("reloj").ToString.Trim.PadLeft(6) & "' group by reloj", "ta")
                        For Each row As DataRow In dtIntegrables.Rows
                            Dim hrs233 As Double = 0
                            Dim hrs333 As Double = 0

                            Try
                                hrs233 = row("dobles_33")
                            Catch ex As Exception

                            End Try
                            Try
                                hrs333 = row("triples_33")
                            Catch ex As Exception

                            End Try

                            If hrs233 > 0 Then
                                oWrite.WriteLine(row("reloj") & ",HRS233," & hrs233)
                            End If

                            If hrs333 > 0 Then
                                oWrite.WriteLine(row("reloj") & ",HRS333," & hrs333)
                            End If

                        Next
                    Catch ex As Exception

                    End Try
                    

                    Dim dtComedor As DataTable = sqlExecute("select reloj, sum(case when subsidio = 'C' then 1 else 0 end) as CON_SUBSIDIO, " & _
                    "sum(case when subsidio = 'S' then 1 else 0 end) as SIN_SUBSIDIO, sum(case when subsidio = 'Z' then 1 else 0 end) as SIN_SUBSIDIO_D from hrs_brt_cafeteria " & _
                    "left join periodos on hrs_brt_cafeteria.fecha between periodos.fecha_ini and periodos.FECHA_FIN " & _
                    "where periodos.ano + periodos.periodo = '" & Ano & Per & "' and hrs_brt_cafeteria.reloj = '" & dDato("reloj").ToString.Trim.PadLeft(6) & "'" & _
                    "group by  reloj", "TA")
                    If dtComedor.Rows.Count > 0 Then
                        If dtComedor.Rows(0)("CON_SUBSIDIO") > 0 Then
                            oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",DIACON," & dtComedor.Rows(0)("CON_SUBSIDIO"))
                            dDato("DIACON") = dtComedor.Rows(0)("CON_SUBSIDIO")
                        End If
                        If dtComedor.Rows(0)("SIN_SUBSIDIO") > 0 Then
                            oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",DIASIN," & dtComedor.Rows(0)("SIN_SUBSIDIO"))
                            dDato("DIASIN") = dtComedor.Rows(0)("SIN_SUBSIDIO")
                        End If
                        If dtComedor.Rows(0)("SIN_SUBSIDIO_D") > 0 Then
                            oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & ",DIADES," & dtComedor.Rows(0)("SIN_SUBSIDIO_D"))
                            dDato("DIADES") = dtComedor.Rows(0)("SIN_SUBSIDIO_D")
                        End If
                    End If


                Next
            End If

            '***************************************


            oWrite.Close()

            frmTrabajando.Hide()

            Try
                Dim archivo_copia As String = DireccionReportes & "archivos_nomina\horas_" & Usuario.Trim
                archivo_copia &= FechaHoraSQL(Now, True, False).Replace(":", "").Replace(Space(1), "").Replace("-", "") & ".txt"

                File.Copy(strFileName, archivo_copia)
            Catch ex As Exception

            End Try

            '--Para mostrar info de quienes tienen mas de 5 horas de retardo o de pemiso sin goce
            dtTAFiltroTA_2 = dtDatos.Clone
            For Each dRow In dtDatos.Select("HRS_NOPAG>=5 Or HRS_RETARDO>=5")
                dtTAFiltroTA_2.ImportRow(dRow)
            Next

            dtFiltroTA = dtDatos.Copy
            Dim dOp As DataRow
            Dim dAd As DataRow
            Dim dTt As DataRow

            dOp = dtFiltroTA.NewRow
            dOp("grupo") = "0"
            dOp("reloj") = 0
            dOp("ANO") = cmbAno.SelectedValue.ToString.Trim
            dOp("PERIODO") = cmbPeriodo.SelectedValue.ToString.Trim

            dAd = dtFiltroTA.NewRow
            dAd("grupo") = "0"
            dAd("reloj") = 0
            dAd("ANO") = cmbAno.SelectedValue.ToString.Trim
            dAd("PERIODO") = cmbPeriodo.SelectedValue.ToString.Trim

            dTt = dtFiltroTA.NewRow
            dTt("grupo") = "0"
            dTt("reloj") = 0
            dTt("ANO") = cmbAno.SelectedValue.ToString.Trim
            dTt("PERIODO") = cmbPeriodo.SelectedValue.ToString.Trim

            For Each dIt As DataRow In dtFiltroTA.Rows
                If dIt("cod_tipo").ToString.Trim = "O" Then
                    dOp("reloj") = Val(dOp("reloj")) + 1
                Else
                    dAd("reloj") = Val(dAd("reloj")) + 1
                End If
                dTt("reloj") = Val(dTt("reloj")) + 1


                For Each dCol As DataColumn In dtFiltroTA.Columns
                    If dCol.DataType Is GetType(System.Double) Or dCol.DataType Is GetType(System.Int32) Then
                        If dIt("cod_tipo").ToString.Trim = "O" Then
                            dOp(dCol.ColumnName) = IIf(IsDBNull(dOp(dCol.ColumnName)), 0, dOp(dCol.ColumnName)) + IIf(IsDBNull(dIt(dCol.ColumnName)), 0, dIt(dCol.ColumnName))
                        Else
                            dAd(dCol.ColumnName) = IIf(IsDBNull(dAd(dCol.ColumnName)), 0, dAd(dCol.ColumnName)) + IIf(IsDBNull(dIt(dCol.ColumnName)), 0, dIt(dCol.ColumnName))
                        End If
                        dTt(dCol.ColumnName) = IIf(IsDBNull(dTt(dCol.ColumnName)), 0, dTt(dCol.ColumnName)) + IIf(IsDBNull(dIt(dCol.ColumnName)), 0, dIt(dCol.ColumnName))
                    End If
                Next

            Next

            dAd("reloj") = "Admin. " & dAd("reloj")
            dOp("reloj") = "Prod. " & dOp("reloj")
            dTt("reloj") = "Total " & dTt("reloj")

            dtFiltroTA.Rows.Add(dAd)
            dtFiltroTA.Rows.Add(dOp)
            dtFiltroTA.Rows.Add(dTt)

            'frmVistaPrevia.LlamarReporte("Revisión de horas antes de envío de información", dtFiltroTA)
            'frmVistaPrevia.ShowDialog(Me)

            Dim dtTotales As New DataTable
            dtTotales = dtFiltroTA.Clone
            dtTotales.ImportRow(dAd)
            dtTotales.ImportRow(dOp)
            dtTotales.ImportRow(dTt)

            frmVistaPrevia.LlamarReporte("Revisión de horas antes de envío de información TOTALES", dtTotales, "", Nothing, True, "", True, "", False, dtTAFiltroTA_2)
            frmVistaPrevia.Show(Me)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()
            Application.DoEvents()
        End Try

    End Sub

    Private Sub btnCorreciones_Click(sender As Object, e As EventArgs) Handles btnCorreciones.Click
        Dim dtDatos As New DataTable
        Dim dtInfoNomsem As New DataTable
        Dim dRow As DataRow
        Dim dAnt As DataRow
        Dim Ano As String
        Dim Per As String
        Dim Cia As String
        Dim Igual As Boolean = True

        Dim strFileName As String = ""
        Dim oWrite As System.IO.StreamWriter
        Dim GuardaArchivo As Boolean = True

        Try
            Me.Cursor = Cursors.WaitCursor
            Ano = cmbAno.SelectedValue
            Per = cmbPeriodo.SelectedValue
            Cia = cmbCia.SelectedValue

            Dim c As Integer = 0
            Dim dDato As DataRow

            Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog

            PreguntaArchivo.Filter = "Text file|*.txt"
            PreguntaArchivo.FileName = Cia & "hrspc COR" & Ano & "-" & Per & ".txt"
            If PreguntaArchivo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                strFileName = PreguntaArchivo.FileName
            Else
                Exit Sub
            End If
            Try
                oWrite = File.CreateText(strFileName)
                GuardaArchivo = True
            Catch ex As Exception
                oWrite = Nothing
                GuardaArchivo = False
                MessageBox.Show("El archivo no pudo ser creado." & vbCrLf & vbCrLf & "Err.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End Try
            frmTrabajando.Show(Me)
            frmTrabajando.Avance.Value = 0
            frmTrabajando.Avance.IsRunning = False
            frmTrabajando.lblAvance.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
            frmTrabajando.lblAvance.Text = "Preparando datos..."
            Application.DoEvents()


            dtDatos.Columns.Add("grupo")
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("cod_tipo")
            dtDatos.Columns.Add("cod_depto")
            dtDatos.Columns.Add("cod_super")
            dtDatos.Columns.Add("super")
            dtDatos.Columns.Add("HRSNOR", GetType(System.Double))
            dtDatos.Columns.Add("HRSFES", GetType(System.Double))
            dtDatos.Columns.Add("HORDOB", GetType(System.Double))
            dtDatos.Columns.Add("HORTRI", GetType(System.Double))
            dtDatos.Columns.Add("HORDOM", GetType(System.Double))
            dtDatos.Columns.Add("DIVACA", GetType(System.Double))
            dtDatos.Columns.Add("DIAGUI", GetType(System.Double))
            dtDatos.Columns.Add("BONO01", GetType(System.Double))
            dtDatos.Columns.Add("BONO02", GetType(System.Double))
            dtDatos.Columns.Add("BONO03", GetType(System.Double))
            dtDatos.Columns.Add("BONO04", GetType(System.Double))
            dtDatos.Columns.Add("BONO05", GetType(System.Double))
            dtDatos.Columns.Add("BONO06", GetType(System.Double))
            dtDatos.Columns.Add("BONO07", GetType(System.Double))
            dtDatos.Columns.Add("BONO08", GetType(System.Double))
            dtDatos.Columns.Add("BONO09", GetType(System.Double))
            dtDatos.Columns.Add("BONO10", GetType(System.Double))
            dtDatos.Columns.Add("HORDIN", GetType(System.Double))
            dtDatos.Columns.Add("HORTIN", GetType(System.Double))
            dtDatos.Columns.Add("DIASTR", GetType(System.Double))

            'Tomar los datos de nomsem, filtrando solo operativos, del periodo, año y compañía seleccionadas
            dtInfoNomsem = sqlExecute("SELECT nomsem.*, personalvw.cod_planta, cod_tipo,cod_depto,cod_super,dias_vacaciones,dias_aguinaldo,nombre_super AS super FROM ta.dbo.nomsem " & _
                                      "LEFT JOIN personal.dbo.personalvw ON nomsem.reloj = personalvw.reloj " & _
                                      "WHERE nomsem.periodo = '" & Per & "' AND ano = '" & Ano & "' AND personalvw.cod_comp = '" & Cia & "' " & _
                                      IIf(cmbTipoEmpleado.SelectedValue <> "***", " AND cod_tipo = '" & cmbTipoEmpleado.SelectedValue & "'", "") & IIf(cmbPlanta.SelectedValue <> "***", " AND personalvw.cod_planta = '" & cmbPlanta.SelectedValue & "'", ""), "TA")

            If dtInfoNomsem.Rows.Count = 0 Then
                MessageBox.Show("No se localizaron registros correspondientes a los parámetros indicados. Favor de verificar.", "Procesar horas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            frmTrabajando.Avance.Maximum = dtInfoNomsem.Rows.Count
            For Each dRow In dtInfoNomsem.Rows
                If Not ActivoTrabajando Then
                    oWrite.Close()
                    Exit Sub
                End If
                frmTrabajando.lblAvance.Text = dRow("reloj")
                frmTrabajando.Avance.Value += 1
                Application.DoEvents()


                dtTemporal = sqlExecute("SELECT * FROM nomsem_ref_horas WHERE ano = '" & Ano & "' AND periodo= '" & _
                                       Per & "' AND reloj = '" & dRow("reloj") & "'", "TA")
                If dtTemporal.Rows.Count > 0 Then
                    dAnt = dtTemporal.Rows.Item(0)
                Else
                    dAnt = dtTemporal.NewRow
                End If

                Igual = True
                Igual = Igual And Math.Round(IIf(IsDBNull(dRow("hrs_normales")), 0, dRow("hrs_normales")), 2, MidpointRounding.AwayFromZero) = Math.Round(IIf(IsDBNull(dAnt("HRSNOR")), 0, dAnt("HRSNOR")), 2)
                Igual = Igual And Math.Round(IIf(IsDBNull(dRow("hrs_festivo")), 0, dRow("hrs_festivo")), 2, MidpointRounding.AwayFromZero) = Math.Round(IIf(IsDBNull(dAnt("HRSFES")), 0, dAnt("HRSFES")), 2)
                Igual = Igual And Math.Round(IIf(IsDBNull(dRow("hrs_dobles")), 0, dRow("hrs_dobles")), 2, MidpointRounding.AwayFromZero) = Math.Round(IIf(IsDBNull(dAnt("HORDOB")), 0, dAnt("HORDOB")), 2)
                Igual = Igual And Math.Round(IIf(IsDBNull(dRow("hrs_triples")), 0, dRow("hrs_triples")), 2, MidpointRounding.AwayFromZero) = Math.Round(IIf(IsDBNull(dAnt("HORTRI")), 0, dAnt("HORTRI")), 2)
                Igual = Igual And Math.Round(IIf(IsDBNull(dRow("hrs_prim_dom")), 0, dRow("hrs_prim_dom")), 2, MidpointRounding.AwayFromZero) = Math.Round(IIf(IsDBNull(dAnt("HORDOM")), 0, dAnt("HORDOM")), 2)
                'Igual = Igual And Math.Round(IIf(IsDBNull(dRow("dias_vacaciones")), 0, dRow("dias_vacaciones")), 2, MidpointRounding.AwayFromZero) = Math.Round(IIf(IsDBNull(dAnt("DIVACA")), 0, dAnt("DIVACA")), 2)
                'Igual = Igual And Math.Round(IIf(IsDBNull(dRow("dias_aguinaldo")), 0, dRow("dias_aguinaldo")), 2, MidpointRounding.AwayFromZero) = Math.Round(IIf(IsDBNull(dAnt("DIAGUI")), 0, dAnt("DIAGUI")), 2)
                Igual = Igual And IIf(IsDBNull(dRow("bono01")), 0, dRow("bono01")) = IIf(IsDBNull(dAnt("BONO01")), 0, dAnt("BONO01"))
                Igual = Igual And IIf(IsDBNull(dRow("bono02")), 0, dRow("bono02")) = IIf(IsDBNull(dAnt("BONO02")), 0, dAnt("BONO02"))
                Igual = Igual And IIf(IsDBNull(dRow("bono03")), 0, dRow("bono03")) = IIf(IsDBNull(dAnt("BONO03")), 0, dAnt("BONO03"))
                Igual = Igual And IIf(IsDBNull(dRow("bono04")), 0, dRow("bono04")) = IIf(IsDBNull(dAnt("BONO04")), 0, dAnt("BONO04"))
                Igual = Igual And IIf(IsDBNull(dRow("bono05")), 0, dRow("bono05")) = IIf(IsDBNull(dAnt("bono05")), 0, dAnt("BONO04"))
                Igual = Igual And IIf(IsDBNull(dRow("bono06")), 0, dRow("bono06")) = IIf(IsDBNull(dAnt("bono06")), 0, dAnt("bono06"))
                Igual = Igual And IIf(IsDBNull(dRow("bono07")), 0, dRow("bono07")) = IIf(IsDBNull(dAnt("bono07")), 0, dAnt("bono07"))
                Igual = Igual And IIf(IsDBNull(dRow("bono08")), 0, dRow("bono08")) = IIf(IsDBNull(dAnt("bono08")), 0, dAnt("bono08"))
                Igual = Igual And IIf(IsDBNull(dRow("bono09")), 0, dRow("bono09")) = IIf(IsDBNull(dAnt("bono09")), 0, dAnt("bono09"))
                Igual = Igual And IIf(IsDBNull(dRow("bono10")), 0, dRow("bono10")) = IIf(IsDBNull(dAnt("bono10")), 0, dAnt("bono10"))
                Igual = Igual And Math.Round(IIf(IsDBNull(dRow("dobles_33")), 0, dRow("dobles_33")), 2, MidpointRounding.AwayFromZero) = Math.Round(IIf(IsDBNull(dAnt("HORDIN")), 0, dAnt("HORDIN")), 2)
                Igual = Igual And Math.Round(IIf(IsDBNull(dRow("triples_33")), 0, dRow("triples_33")), 2, MidpointRounding.AwayFromZero) = Math.Round(IIf(IsDBNull(dAnt("HORTIN")), 0, dAnt("HORTIN")), 2)
                Igual = Igual And Math.Round(IIf(IsDBNull(dRow("dias_trabajados")), 0, dRow("dias_trabajados")), 2, MidpointRounding.AwayFromZero) = Math.Round(IIf(IsDBNull(dAnt("DIASTR")), 0, dAnt("DIASTR")), 2)

                If Not Igual Then
                    dDato = dtDatos.NewRow
                    dDato("reloj") = dRow("reloj")
                    dDato("cod_tipo") = dRow("cod_tipo")
                    dDato("cod_depto") = dRow("cod_depto")
                    dDato("cod_super") = dRow("cod_super")
                    dDato("super") = dRow("super")
                    dDato("HRSNOR") = IIf(IsDBNull(dRow("hrs_normales")), 0, dRow("hrs_normales"))
                    dDato("HRSFES") = IIf(IsDBNull(dRow("hrs_festivo")), 0, dRow("hrs_festivo"))
                    dDato("HORDOB") = IIf(IsDBNull(dRow("hrs_dobles")), 0, dRow("hrs_dobles"))
                    dDato("HORTRI") = IIf(IsDBNull(dRow("hrs_triples")), 0, dRow("hrs_triples"))
                    dDato("HORDOM") = IIf(IsDBNull(dRow("hrs_prim_dom")), 0, dRow("hrs_prim_dom"))
                    dDato("DIVACA") = IIf(IsDBNull(dRow("dias_vacaciones")), 0, dRow("dias_vacaciones"))
                    dDato("DIAGUI") = IIf(IsDBNull(dRow("dias_aguinaldo")), 0, dRow("dias_aguinaldo"))
                    dDato("BONO01") = IIf(IsDBNull(dRow("bono01")), 0, dRow("bono01"))
                    dDato("BONO02") = IIf(IsDBNull(dRow("bono02")), 0, dRow("bono02"))
                    dDato("BONO03") = IIf(IsDBNull(dRow("bono03")), 0, dRow("bono03"))
                    dDato("BONO04") = IIf(IsDBNull(dRow("bono04")), 0, dRow("bono04"))
                    dDato("BONO05") = IIf(IsDBNull(dRow("bono05")), 0, dRow("bono05"))
                    dDato("bono06") = IIf(IsDBNull(dRow("bono06")), 0, dRow("bono06"))
                    dDato("bono07") = IIf(IsDBNull(dRow("bono07")), 0, dRow("bono07"))
                    dDato("bono08") = IIf(IsDBNull(dRow("bono08")), 0, dRow("bono08"))
                    dDato("bono09") = IIf(IsDBNull(dRow("bono09")), 0, dRow("bono09"))
                    dDato("bono10") = IIf(IsDBNull(dRow("bono10")), 0, dRow("bono10"))
                    dDato("HORDIN") = IIf(IsDBNull(dRow("dobles_33")), 0, dRow("dobles_33"))
                    dDato("HORTIN") = IIf(IsDBNull(dRow("triples_33")), 0, dRow("triples_33"))
                    dDato("DIASTR") = IIf(IsDBNull(dRow("dias_trabajados")), 0, dRow("dias_trabajados"))
                    dtDatos.Rows.Add(dDato)

                    'dtTemporal = sqlExecute("SELECT reloj FROM nomsem_ref_horas WHERE ano = '" & Ano & "' AND periodo= '" & _
                    '                        Per & "' AND reloj = '" & dRow("reloj") & "'", "TA")
                    'If dtTemporal.Rows.Count = 0 Then
                    '    sqlExecute("INSERT INTO nomsem_ref_horas (ano,periodo,reloj) VALUES ('" & Ano & "','" & Per & "','" & _
                    '               dRow("reloj") & "')", "TA")
                    'End If

                    'sqlExecute("UPDATE nomsem_ref_horas SET " & _
                    '           "HRSNOR = " & dDato("HRSNOR") & _
                    '           ",HRSFES = " & dDato("HRSFES") & _
                    '           ",HORDOB = " & dDato("HORDOB") & _
                    '           ",HORTRI = " & dDato("HORTRI") & _
                    '           ",HORDOM = " & dDato("HORDOM") & _
                    '           ",DIVACA = " & dDato("DIVACA") & _
                    '           ",DIAGUI = " & dDato("DIAGUI") & _
                    '           ",BONO01 = " & dDato("BONO01") & _
                    '           ",BONO02 = " & dDato("BONO02") & _
                    '           ",BONO03 = " & dDato("BONO03") & _
                    '           ",HORDIN = " & dDato("HORDIN") & _
                    '           ",HORTIN = " & dDato("HORTIN") & _
                    '           ",DIASTR = " & dDato("DIASTR") & _
                    '           " WHERE ano = '" & Ano & "' AND periodo= '" & Per & "' AND reloj = '" & dRow("reloj") & "'", "TA")


                    oWrite.WriteLine(dDato("reloj").ToString.Trim.PadLeft(6) & _
                                 Math.Round(dDato("HRSNOR") * 100).ToString.Trim.PadLeft(4) & _
                                 Math.Round(dDato("HRSFES") * 100).ToString.Trim.PadLeft(4) & _
                                 Math.Round(dDato("HORDOB") * 100).ToString.Trim.PadLeft(4) & _
                                 Math.Round(dDato("HORTRI") * 100).ToString.Trim.PadLeft(4) & _
                                 Math.Round(dDato("HORDOM") * 100).ToString.Trim.PadLeft(4) & _
                                 Math.Round(dDato("DIVACA") * 100).ToString.Trim.PadLeft(4) & _
                                 Math.Round(dDato("DIAGUI") * 100).ToString.Trim.PadLeft(4) & _
                                 Math.Round(dDato("BONO01") * 100).ToString.Trim.PadLeft(7) & _
                                 Math.Round(dDato("BONO02") * 100).ToString.Trim.PadLeft(7) & _
                                 Math.Round(dDato("BONO03") * 100).ToString.Trim.PadLeft(7) & _
                                 Math.Round(dDato("BONO04") * 100).ToString.Trim.PadLeft(7) & _
                                 Math.Round(dDato("BONO05") * 100).ToString.Trim.PadLeft(7) & _
                                 Math.Round(dDato("BONO06") * 100).ToString.Trim.PadLeft(7) & _
                                 Math.Round(dDato("BONO07") * 100).ToString.Trim.PadLeft(7) & _
                                 Math.Round(dDato("BONO08") * 100).ToString.Trim.PadLeft(7) & _
                                 Math.Round(dDato("BONO09") * 100).ToString.Trim.PadLeft(7) & _
                                 Math.Round(dDato("BONO10") * 100).ToString.Trim.PadLeft(7) & _
                                 Math.Round(dDato("HORDIN") * 100).ToString.Trim.PadLeft(4) & _
                                 Math.Round(dDato("HORTIN") * 100).ToString.Trim.PadLeft(4) & _
                                 Math.Round(dDato("DIASTR") * 100).ToString.Trim.PadLeft(4))
                End If
            Next
            oWrite.Close()

            If dtDatos.Rows.Count = 0 Then
                MessageBox.Show("No se localizaron correcciones que correspondan a los parámetros indicados. Favor de verificar.", "Procesar horas", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            dtFiltroTA = dtDatos.Copy
            Dim dOp As DataRow
            Dim dAd As DataRow
            Dim dTt As DataRow

            dOp = dtFiltroTA.NewRow
            dOp("grupo") = "0"
            dOp("reloj") = 0

            dAd = dtFiltroTA.NewRow
            dAd("grupo") = "0"
            dAd("reloj") = 0

            dTt = dtFiltroTA.NewRow
            dTt("grupo") = "0"
            dTt("reloj") = 0

            For Each dIt As DataRow In dtFiltroTA.Rows
                If dIt("cod_tipo").ToString.Trim = "O" Then
                    dOp("reloj") = Val(dOp("reloj")) + 1
                Else
                    dAd("reloj") = Val(dAd("reloj")) + 1
                End If
                dTt("reloj") = Val(dTt("reloj")) + 1


                For Each dCol As DataColumn In dtFiltroTA.Columns
                    If dCol.DataType Is GetType(System.Double) Then
                        If dIt("cod_tipo").ToString.Trim = "O" Then
                            dOp(dCol.ColumnName) = IIf(IsDBNull(dOp(dCol.ColumnName)), 0, dOp(dCol.ColumnName)) + IIf(IsDBNull(dIt(dCol.ColumnName)), 0, dIt(dCol.ColumnName))
                        Else
                            dAd(dCol.ColumnName) = IIf(IsDBNull(dAd(dCol.ColumnName)), 0, dAd(dCol.ColumnName)) + IIf(IsDBNull(dIt(dCol.ColumnName)), 0, dIt(dCol.ColumnName))
                        End If
                        dTt(dCol.ColumnName) = IIf(IsDBNull(dTt(dCol.ColumnName)), 0, dTt(dCol.ColumnName)) + IIf(IsDBNull(dIt(dCol.ColumnName)), 0, dIt(dCol.ColumnName))
                    End If
                Next

            Next
            dAd("reloj") = "Admin. " & dAd("reloj")
            dOp("reloj") = "Prod. " & dOp("reloj")
            dTt("reloj") = "Total " & dTt("reloj")
            dtFiltroTA.Rows.Add(dAd)
            dtFiltroTA.Rows.Add(dOp)
            dtFiltroTA.Rows.Add(dTt)

            frmVistaPrevia.LlamarReporte("Revisión de horas antes de envío de información", dtFiltroTA)
            frmVistaPrevia.ShowDialog(Me)

            Dim dtTotales As New DataTable
            dtTotales = dtFiltroTA.Clone
            dtTotales.ImportRow(dAd)
            dtTotales.ImportRow(dOp)
            dtTotales.ImportRow(dTt)

            frmVistaPrevia.LlamarReporte("Revisión de horas antes de envío de información", dtTotales)
            frmVistaPrevia.Show(Me)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
            MessageBox.Show("El archivo no pudo ser creado, debido a que se encontraron errores durante el proceso. Si el problema persiste, contacte al administrador del sistema." & _
                            vbCrLf & vbCrLf & "Err.- " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
            ActivoTrabajando = False
            frmTrabajando.Close()
            frmTrabajando.Dispose()
            Application.DoEvents()
        End Try
    End Sub
    Private Sub CorrecionesANT()
        Dim dtDatos As New DataTable
        Dim dtInfoNomsem As New DataTable
        Dim dtInfoNomsemREF As New DataTable
        Dim dRow As DataRow
        Dim dRowREF As DataRow
        Dim Ano As String
        Dim Per As String
        Dim Cia As String

        Dim Inserta As Boolean = False

        Dim Normales As String = ""
        Dim Festivo As String = ""
        Dim Dobles As String = ""
        Dim Triples As String = ""
        Dim Vac As String = ""
        Dim Punt As String = ""
        Dim Asist As String = ""
        Dim Dom As String = ""
        Dim Perfecta As String = ""

        Dim strFileName As String = ""
        Dim oWrite As System.IO.StreamWriter
        Dim GuardaArchivo As Boolean = True

        Try
            Me.Cursor = Cursors.WaitCursor
            Ano = cmbAno.SelectedValue
            Per = cmbPeriodo.SelectedValue
            Cia = cmbCia.SelectedValue

            dtDatos.Columns.Add("RELOJ")
            dtDatos.Columns.Add("COD_COMP")
            dtDatos.Columns.Add("COD_DEPTO")
            dtDatos.Columns.Add("COD_SUPER")
            dtDatos.Columns.Add("SUPER")
            dtDatos.Columns.Add("COD_TIPO")
            dtDatos.Columns.Add("PERIODO")

            dtDatos.Columns.Add("NORMALES", System.Type.GetType("System.Double"))
            dtDatos.Columns.Add("DOBLES", System.Type.GetType("System.Double"))
            dtDatos.Columns.Add("TRIPLES", System.Type.GetType("System.Double"))
            dtDatos.Columns.Add("VAC", System.Type.GetType("System.Double"))
            dtDatos.Columns.Add("FESTIVO", System.Type.GetType("System.Double"))
            dtDatos.Columns.Add("PUNT", System.Type.GetType("System.Int16"))
            dtDatos.Columns.Add("ASIST", System.Type.GetType("System.Int16"))
            dtDatos.Columns.Add("DOM", System.Type.GetType("System.Double"))

            dtDatos.Columns.Add("PERFECTA")
            dtDatos.Columns.Add("COMENTARIO")
            Dim c As Integer = 0
            'Tomar los datos de nomsem, filtrando solo operativos, del periodo, año y compañía seleccionadas
            dtInfoNomsem = sqlExecute("SELECT nomsem.*,nombres,personalvw.cod_comp,cod_tipo,cod_depto,cod_super,nombre_super,cod_tipo FROM ta.dbo.nomsem LEFT JOIN personal.dbo.personalvw ON nomsem.reloj = personalvw.reloj WHERE cod_tipo = 'O'  AND personalvw.cod_comp = '" & Cia & "' AND nomsem.periodo = '" & Per & "' AND ano = '" & Ano & "'", "TA")
            For Each dRow In dtInfoNomsem.Rows
                Inserta = False
                c = c + 1
                'Buscar si existe el registro en nomsem_ref_horas
                dtInfoNomsemREF = sqlExecute("SELECT * FROM nomsem_ref_horas WHERE reloj = '" & dRow("reloj") & "' AND periodo = '" & Per & "' AND ano = '" & Ano & "'", "TA")
                'Si no lo localiza, insertar completo
                If dtInfoNomsemREF.Rows.Count = 0 Then
                    Inserta = True
                    Perfecta = dRow("asistencia_perfecta")

                    Normales = FormatNumber(dRow("hrs_normales"), 2)
                    Festivo = FormatNumber(dRow("hrs_festivo"), 2)
                    Dobles = FormatNumber(dRow("hrs_dobles"), 2)
                    Triples = FormatNumber(dRow("hrs_triples"), 2)
                    Dom = FormatNumber(dRow("hrs_prim_dom"), 2).ToString
                    Punt = dRow("bono_puntualidad")
                    Asist = dRow("bono_asistencia")
                    Vac = 0
                Else
                    'Si lo localiza, comparar si hay diferencias
                    dRowREF = dtInfoNomsemREF.Rows(0)
                    If (dRow("hrs_normales") <> dRowREF("hrs_normales") Or dRow("hrs_dobles") <> dRowREF("hrs_dobles") Or dRow("hrs_triples") <> dRowREF("hrs_triples") Or dRow("hrs_festivo") <> dRowREF("hrs_festivo") Or dRow("hrs_prim_dom") <> dRowREF("hrs_prim_dom") Or dRow("asistencia_perfecta") <> dRowREF("asistencia")) Then
                        Inserta = True

                        If dRow("asistencia_perfecta") = 0 And dRowREF("asistencia") = 1 Then
                            Perfecta = 2
                        Else
                            Perfecta = dRowREF("asistencia_perfecta")
                        End If

                        Normales = FormatNumber(dRowREF("hrs_normales"), 2)
                        Festivo = FormatNumber(dRowREF("hrs_festivo"), 2)
                        Dobles = FormatNumber(dRowREF("hrs_dobles"), 2)
                        Triples = FormatNumber(dRowREF("hrs_triples"), 2)
                        Dom = FormatNumber(dRowREF("hrs_prim_dom"), 2).ToString
                        Punt = IIf(IsDBNull(dRowREF("bono_puntualidad")), 0, dRowREF("bono_puntualidad"))
                        Asist = IIf(IsDBNull(dRowREF("bono_asistencia")), 0, dRowREF("bono_asistencia"))
                        Vac = 0
                    End If
                End If

                If Inserta Then
                    dtDatos.Rows.Add({dRow("reloj"), dRow("cod_comp"), dRow("cod_depto"), dRow("cod_super"), dRow("nombre_super"), dRow("cod_tipo"), Per, Normales, Dobles, Triples, Vac, Festivo, Punt, Asist, Dom, Perfecta, "CORRECCIONES"})
                End If
            Next

            Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog

            PreguntaArchivo.Filter = "Text file|*.txt"
            PreguntaArchivo.FileName = Cia & "CorPC.txt"
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

            If GuardaArchivo Then
                For Each dRow In dtDatos.Rows
                    oWrite.WriteLine(dRow("reloj").ToString.Trim.PadLeft(10) & " " & _
                                     FormatNumber(dRow("normales"), 2).ToString.Trim.PadLeft(9) & _
                                     FormatNumber(dRow("festivo"), 2).ToString.Trim.PadLeft(12) & _
                                     FormatNumber(dRow("dobles") + dRow("triples"), 2).ToString.Trim.PadLeft(7) & _
                                     FormatNumber(dRow("dom"), 2).ToString.Trim.PadLeft(10) & _
                                     dRow("perfecta").ToString.Trim.PadLeft(1))
                Next
            End If
            oWrite.Close()
            dtFiltroTA = dtDatos.Copy
            frmVistaPrevia.LlamarReporte("Revisión de horas antes de envío de información", dtFiltroTA)
            frmVistaPrevia.Show(Me)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs)
        Dim dtDatos As New DataTable
        Dim dtInfoNomsem As New DataTable
        Dim rsDatos As New ADODB.Recordset

        Dim dRow As DataRow
        Dim Ano As String
        Dim Per As String
        Dim Cia As String

        Dim Normales As String = ""
        Dim Festivo As String = ""
        Dim Dobles As String = ""
        Dim Triples As String = ""
        Dim Extras As String = ""
        Dim Vac As String = ""
        Dim Punt As String = ""
        Dim Asist As String = ""
        Dim Dom As String = ""
        Dim Perfecta As String = ""
        Dim FondoUnido As String = ""

        Dim TotalNormales As Double = 0
        Dim TotalFestivo As Double = 0
        Dim TotalDobles As Double = 0
        Dim TotalTriples As Double = 0
        Dim TotalExtras As Double = 0
        Dim TotalVac As Double = 0
        Dim TotalPunt As Double = 0
        Dim TotalAsist As Double = 0
        Dim TotalDom As Double = 0
        Dim TotalFondoUnido As Double = 0

        Dim strFileName As String = ""
        Dim GuardaArchivo As Boolean = True

        Try
            Me.Cursor = Cursors.WaitCursor
            Ano = cmbAno.SelectedValue
            Per = cmbPeriodo.SelectedValue
            Cia = cmbCia.SelectedValue

            dtDatos.Columns.Add("NORMALES", System.Type.GetType("System.Double"))
            dtDatos.Columns.Add("FESTIVO", System.Type.GetType("System.Double"))
            dtDatos.Columns.Add("DOBLES", System.Type.GetType("System.Double"))
            dtDatos.Columns.Add("TRIPLES", System.Type.GetType("System.Double"))
            dtDatos.Columns.Add("EXTRAS", System.Type.GetType("System.Double"))
            dtDatos.Columns.Add("DOM", System.Type.GetType("System.Double"))
            dtDatos.Columns.Add("PERFECTA")
            dtDatos.Columns.Add("FONDO_UNIDO", System.Type.GetType("System.Double"))

            rsDatos.Fields.Append("RELOJ", ADODB.DataTypeEnum.adChar, 10)
            rsDatos.Fields.Append("COD_TURNO", ADODB.DataTypeEnum.adChar, 10)
            rsDatos.Fields.Append("NOMBRE", ADODB.DataTypeEnum.adChar, 50)
            rsDatos.Fields.Append("NORMALES", ADODB.DataTypeEnum.adDouble)
            rsDatos.Fields.Append("FESTIVO", ADODB.DataTypeEnum.adDouble)
            rsDatos.Fields.Append("DOBLES", ADODB.DataTypeEnum.adDouble)
            rsDatos.Fields.Append("TRIPLES", ADODB.DataTypeEnum.adDouble)
            rsDatos.Fields.Append("EXTRAS", ADODB.DataTypeEnum.adDouble)
            rsDatos.Fields.Append("DOM", ADODB.DataTypeEnum.adDouble)
            rsDatos.Fields.Append("FONDO_UNIDO", ADODB.DataTypeEnum.adDouble)
            rsDatos.Fields.Append("PERFECTA", ADODB.DataTypeEnum.adBoolean)

            rsDatos.Open()
            Dim c As Integer = 0
            'Tomar los datos de nomsem, filtrando solo operativos, del periodo, año y compañía seleccionadas
            dtInfoNomsem = sqlExecute("SELECT nomsem.*,nombres,personalvw.cod_comp,cod_tipo,cod_depto,cod_super,nombre_super,cod_tipo,cod_turno FROM ta.dbo.nomsem LEFT JOIN personal.dbo.personalvw ON nomsem.reloj = personalvw.reloj WHERE cod_tipo = 'O' AND personalvw.cod_comp = '" & Cia & "' AND nomsem.periodo = '" & Per & "' AND ano = '" & Ano & "'", "TA")
            For Each dRow In dtInfoNomsem.Rows
                c = c + 1

                Normales = FormatNumber(dRow("hrs_normales"), 2)
                Festivo = FormatNumber(dRow("hrs_festivo"), 2)
                Dobles = FormatNumber(dRow("hrs_dobles"), 2)
                Triples = FormatNumber(dRow("hrs_triples"), 2)
                Extras = FormatNumber(dRow("hrs_triples") + dRow("hrs_dobles"), 2)
                Dom = FormatNumber(dRow("hrs_prim_dom"), 2).ToString
                Perfecta = dRow("asistencia_perfecta")
                Punt = dRow("bono_puntualidad")
                Asist = dRow("bono_asistencia")
                Vac = 0

                '**** OJO Para el 6o. turno trabajara solo 24 pero el equivalente sera a 40 horas
                '**** por eso se multiplica por el factor 1.6667 (40/24)	IVO 12 Ago 06
                If dRow("cod_turno") = "6" Then
                    Normales = FormatNumber(Val(Normales) * (40 / 24), 2)
                    Festivo = FormatNumber(Val(Festivo) * (40 / 24), 2)
                    Dom = FormatNumber(Val(Dom) * (40 / 24), 2)
                End If

                'Buscar Fondo Unido
                dtTemporal = sqlExecute("SELECT contenido FROM detalle_auxiliares WHERE reloj = '" & dRow("reloj") & "' AND campo = 'FONDOUNIDO'")
                If dtTemporal.Rows.Count > 0 Then
                    FondoUnido = Val(dtTemporal.Rows(0).Item("contenido"))
                Else
                    FondoUnido = 0
                End If

                TotalNormales += dRow("hrs_normales")
                TotalFestivo += dRow("hrs_festivo")
                TotalDobles += dRow("hrs_dobles")
                TotalTriples += dRow("hrs_triples")
                TotalExtras += dRow("hrs_triples") + dRow("hrs_dobles")
                TotalDom += dRow("hrs_prim_dom")
                TotalFondoUnido += FondoUnido


                'Insertar en rsDatos para exportar a excel
                rsDatos.AddNew()
                rsDatos.Fields("reloj").Value = dRow("reloj")
                rsDatos.Fields("cod_turno").Value = dRow("cod_turno")
                rsDatos.Fields("nombre").Value = dRow("nombres")
                rsDatos.Fields("Normales").Value = Normales
                rsDatos.Fields("Festivo").Value = Festivo
                rsDatos.Fields("Dobles").Value = Dobles
                rsDatos.Fields("Triples").Value = Triples
                rsDatos.Fields("Extras").Value = Extras
                rsDatos.Fields("Dom").Value = Dom
                rsDatos.Fields("Perfecta").Value = Perfecta
                rsDatos.Fields("Fondo_Unido").Value = FondoUnido
                rsDatos.Update()

            Next

            'Insertar en dtDatos para reporte
            dtDatos.Rows.Add({TotalNormales, TotalFestivo, TotalDobles, TotalTriples, TotalExtras, TotalDom, TotalFondoUnido})

            Dim PreguntaArchivo As New Windows.Forms.SaveFileDialog
            PreguntaArchivo.Filter = "Excel|*.xls"
            PreguntaArchivo.FileName = Cia & "hrspc AGENCIA.xls"
            If PreguntaArchivo.ShowDialog() = Windows.Forms.DialogResult.OK Then
                strFileName = PreguntaArchivo.FileName
            End If

            If strFileName.Length <> 0 Then
                ExportaExcel(rsDatos, strFileName)
            End If

            frmVistaPrevia.LlamarReporte("Resumen de horas a exportar", dtDatos)
            frmVistaPrevia.Show(Me)

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), Me.Name, ex.HResult, ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            rsDatos.Close()
        End Try
    End Sub

    Private Sub cmbCia_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbCia.SelectedValueChanged
        Dim dtTipo As New DataTable
        dtTipo = sqlExecute("SELECT cod_tipo,RTRIM(nombre) AS nombre FROM tipo_emp WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
        dtTipo.Rows.Add({"***", "Todos"})
        cmbTipoEmpleado.DataSource = dtTipo
        cmbTipoEmpleado.SelectedValue = "***"

        Dim dtPlanta As New DataTable
        dtPlanta = sqlExecute("SELECT cod_planta,RTRIM(nombre) AS nombre FROM plantas WHERE cod_comp = '" & cmbCia.SelectedValue & "'")
        dtPlanta.Rows.Add({"***", "Todos"})
        cmbPlanta.DataSource = dtPlanta
        cmbPlanta.SelectedValue = "***"

    End Sub

    Private Sub cmbCia_TextChanged(sender As Object, e As EventArgs) Handles cmbCia.TextChanged

    End Sub
End Class
