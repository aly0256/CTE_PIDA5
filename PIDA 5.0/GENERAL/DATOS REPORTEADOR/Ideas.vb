Module Ideas


    Public Sub ParticipacionIdeasCBajas(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Dim FechaIni As Date
        Dim FechaFin As Date
        Dim ano As Integer

        Dim objetivo_anual = 8

        dtDatos = New DataTable
        dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

        dtDatos.Columns.Add("cod_super", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))

        dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_depto", Type.GetType("System.String"))

        dtDatos.Columns.Add("cod_super_actual", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_super_actual", Type.GetType("System.String"))

        dtDatos.Columns.Add("cod_depto_actual", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_depto_actual", Type.GetType("System.String"))

        dtDatos.Columns.Add("cod_area", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_area", Type.GetType("System.String"))

        dtDatos.Columns.Add("baja", Type.GetType("System.String"))
        dtDatos.Columns.Add("alta", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("feb_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_ideas", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("meses", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("objetivo_anual", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("estatus_anual", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("feb_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_obj", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("feb_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_estatus", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("feb_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_acum", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("feb_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_activo", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("alta_personal", Type.GetType("System.DateTime"))

        dtDatos.Columns.Add("transferencia", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("reloj_anterior", Type.GetType("System.String"))

        dtDatos.Columns.Add("alta_ideas", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("baja_ideas", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("mes_inicio", Type.GetType("System.String"))

        dtDatos.Columns.Add("fecha_ini", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("fecha_fin", Type.GetType("System.DateTime"))

        dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj"), dtDatos.Columns("cod_depto")}

        ano = Year(FechaFinal)
        For Each dRow As DataRow In dtInformacion.Rows
            If Not IsDBNull(dRow("fecha")) Then
                If Month(dtInformacion.Rows(0).Item("fecha")) = 1 Then
                    ano = Year(dtInformacion.Rows(0).Item("fecha")) - 1
                Else
                    ano = Year(dtInformacion.Rows(0).Item("fecha"))
                End If
                Exit For
            Else
                If Month(FechaFinal) = 1 Then
                    ano = Year(FechaFinal) - 1
                Else
                    ano = Year(FechaFinal)
                End If
                Exit For
            End If
        Next

        Dim dtperiodos As DataTable
        dtperiodos = sqlExecute("select * from periodos where periodo_especial = 0 and ano = '" & ano & "' and num_mes = '02' order by periodo asc", "ta")
        If dtperiodos.Rows.Count > 0 Then
            FechaIni = dtperiodos.Rows(0)("fecha_ini")
            Dim TempFinal As String
            Dim TempFecha As String
            TempFinal = FechaSQL(FechaFinal).ToString.Substring(5, 5)
            TempFecha = FechaSQL(FechaInicial).ToString.Substring(5, 5)
            If TempFecha <> "02-01" Or TempFinal <> "01-31" Then
                MensajeError = "Es necesario cargar el año fiscal"
                MostrarReporte = False
                Exit Sub
            End If
        End If

        dtperiodos = sqlExecute("select * from periodos where periodo_especial = 0 and ano = '" & ano + 1 & "' and num_mes = '01' order by periodo desc", "ta")
        If dtperiodos.Rows.Count > 0 Then
            FechaFin = dtperiodos.Rows(0)("fecha_fin")
        End If


        Dim dtMesesTranscurridos As DataTable = sqlExecute("select distinct(lower(substring(mes, 1, 3))) as mes, ano, num_mes from periodos where periodo_especial = 0 and ((ano = '" & ano & "' and num_mes >= '02') or (ano = '" & ano + 1 & "' and num_mes = '01')) and fecha_fin < '" & FechaSQL(Now) & "' GROUP BY ano, mes, num_mes order by ano asc, num_mes asc", "ta")

        Dim dtIdeas As DataTable = dtInformacion.Select("", "reloj,fecha").CopyToDataTable
        Dim dtIdeasTransferencia As DataTable = dtIdeas.Clone

        For Each row As DataRow In dtIdeas.Rows
            AuxiliarIdeasCbajas(row, dtDatos, True, dtMesesTranscurridos, FechaIni, FechaFin, ano, dtIdeasTransferencia, dtIdeas)
        Next

        For Each row As DataRow In dtIdeasTransferencia.Rows
            AuxiliarIdeasCbajas(row, dtDatos, False, dtMesesTranscurridos, FechaIni, FechaFin, ano, dtIdeasTransferencia, dtIdeas)
        Next



    End Sub
    Private Sub AuxiliarIdeasCbajas(row As DataRow, ByRef DtDatos As DataTable, transferencias As Boolean, dtMesesTranscurridos As DataTable, fechaini As Date, fechafin As Date, Ano As Int32, ByRef dtIdeasTransferencia As DataTable, ByVal dtIDeasDepto As DataTable)

        Try
            Dim RelojObjetivos As String = ""
            Dim Llaves(1) As Object
            Llaves(0) = row("reloj")
            Llaves(1) = row("cod_depto")
            Dim drow As DataRow = DtDatos.Rows.Find(Llaves)
            Dim MesFin As Integer = 0
            Dim MesFinal As String = ""

            If drow Is Nothing Then
                drow = DtDatos.NewRow
                RelojObjetivos = row("reloj")
                drow("reloj") = row("reloj")
                drow("cod_depto") = row("cod_depto")
                DtDatos.Rows.Add(drow)

                drow("nombres") = RTrim(row("nombres"))
                drow("cod_super") = row("cod_super")
                drow("nombre_super") = row("nombre_super")
                drow("nombre_depto") = row("nombre_depto")
                drow("cod_super_actual") = row("cod_super_actual")
                drow("cod_depto_actual") = row("cod_depto_actual")
                drow("nombre_super_actual") = row("nombre_super_actual")
                drow("nombre_depto_actual") = row("nombre_depto_actual")
                drow("alta") = row("alta")

                Dim DeptoOriginal As String = drow("cod_depto").ToString
                Dim DeptoActual As String = drow("cod_depto_actual").ToString


                If row("reloj").ToString.Trim.Equals("031175") Then
                    row("baja") = Date.Parse("2015-03-31")
                End If
                ''020158'

                If row("reloj").ToString.Trim.Equals("020158") Then
                    row("alta") = "2015-08-01"
                End If

                Try
                    drow("baja") = IIf(IsDBNull(row("baja")), "", "Baja " + FechaSQL(row("baja")))
                    'MesBaja = Month(row("baja"))

                Catch ex As Exception
                    drow("baja") = ""
                End Try
                drow("feb_ideas") = 0
                drow("mar_ideas") = 0
                drow("abr_ideas") = 0
                drow("may_ideas") = 0
                drow("jun_ideas") = 0
                drow("jul_ideas") = 0
                drow("ago_ideas") = 0
                drow("sep_ideas") = 0
                drow("oct_ideas") = 0
                drow("nov_ideas") = 0
                drow("dic_ideas") = 0
                drow("ene_ideas") = 0

                drow("estatus_anual") = 0

                drow("feb_obj") = 0
                drow("mar_obj") = 0
                drow("abr_obj") = 0
                drow("may_obj") = 0
                drow("jun_obj") = 0
                drow("jul_obj") = 0
                drow("ago_obj") = 0
                drow("sep_obj") = 0
                drow("oct_obj") = 0
                drow("nov_obj") = 0
                drow("dic_obj") = 0
                drow("ene_obj") = 0

                drow("feb_acum") = drow("feb_ideas")
                drow("mar_acum") = drow("mar_ideas") + drow("feb_ideas")
                drow("abr_acum") = drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("may_acum") = drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("jun_acum") = drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("jul_acum") = drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("ago_acum") = drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("sep_acum") = drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("oct_acum") = drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("nov_acum") = drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("dic_acum") = drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("ene_acum") = drow("ene_ideas") + drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")

                drow("feb_estatus") = -1
                drow("mar_estatus") = -1
                drow("abr_estatus") = -1
                drow("may_estatus") = -1
                drow("jun_estatus") = -1
                drow("jul_estatus") = -1
                drow("ago_estatus") = -1
                drow("sep_estatus") = -1
                drow("oct_estatus") = -1
                drow("nov_estatus") = -1
                drow("dic_estatus") = -1
                drow("ene_estatus") = -1


                drow("feb_activo") = -1
                drow("mar_activo") = -1
                drow("abr_activo") = -1
                drow("may_activo") = -1
                drow("jun_activo") = -1
                drow("jul_activo") = -1
                drow("ago_activo") = -1
                drow("sep_activo") = -1
                drow("oct_activo") = -1
                drow("nov_activo") = -1
                drow("dic_activo") = -1
                drow("ene_activo") = -1

                For Each mes As DataRow In dtMesesTranscurridos.Rows
                    drow(mes("mes") & "_activo") = 1
                Next
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                drow("alta_personal") = row("alta")
                drow("transferencia") = 0
                drow("reloj_anterior") = ""

                If transferencias Then
                    Dim dt_transferencia As DataTable = sqlExecute("select * from transferencias where reloj_nuevo = '" & row("reloj") & "' and alta > alta_anterior")
                    If dt_transferencia.Rows.Count > 0 Then
                        'If Date.Parse(dt_transferencia.Rows(0)("alta_anterior")) > FechaIni Then
                        drow("transferencia") = 1
                        drow("reloj_anterior") = dt_transferencia.Rows(0)("reloj_anterior")
                        drow("alta_personal") = row("alta")
                        drow("alta") = Date.Parse(dt_transferencia.Rows(0)("alta_anterior"))

                        'End If

                        Try
                            Dim dtIdeasAgencia As DataTable = sqlExecute("SELECT ideasVW.*,cias.nombre AS COMPANIA,deptos.nombre AS NOMBRE_DEPTO,SUPER.NOMBRE AS NOMBRE_SUPER," & _
                                                                   "AREAS.NOMBRE AS NOMBRE_AREA,puestos.nombre as 'nombre_puesto' FROM IDEASVW " & _
                                                                   "LEFT JOIN personal.dbo.cias ON ideasVW.cod_comp = cias.cod_comp " & _
                                                                   "LEFT JOIN personal.dbo.deptos ON ideasVW.cod_comp = deptos.cod_comp AND ideasVW.cod_depto = deptos.cod_depto " & _
                                                                   "LEFT JOIN personal.dbo.super ON ideasVW.cod_comp = super.cod_comp AND ideasVW.cod_super = super.cod_super " & _
                                                                   "LEFT JOIN personal.dbo.puestos ON ideasVW.cod_comp = puestos.cod_comp AND ideasVW.cod_puesto = puestos.cod_puesto " & _
                                                                   "LEFT JOIN personal.dbo.areas ON ideasVW.cod_comp = areas.cod_comp AND ideasVW.cod_area = areas.cod_area " & _
                                                                   "WHERE fecha BETWEEN '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "' and ideasvw.reloj = '" & dt_transferencia.Rows(0)("reloj_anterior") & "' and cod_depto = '" & row("cod_depto") & "'", "IDEAS")

                            For Each row_agencia As DataRow In dtIdeasAgencia.Rows
                                row_agencia("reloj") = row("reloj")
                                row_agencia("cod_depto") = row("cod_depto")
                                dtIdeasTransferencia.ImportRow(row_agencia)
                            Next

                        Catch ex As Exception
                            Debug.Print(ex.Message)
                        End Try


                    End If
                End If
                ' ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If DeptoOriginal <> DeptoActual Then
                    Try

                        Dim dtCambiosDepto As New DataTable
                        dtCambiosDepto = sqlExecute("select MIN(cast(FECHA as date)) AS FECHA_CAMBIO from bitacora_personal where reloj in ('" & drow("reloj") & "','" & drow("reloj_anterior") & "')and (valorAnterior is not null and valorAnterior <> '') and campo = 'COD_DEPTO' and valorNuevo='" & DeptoOriginal & "' and (cast(FECHA as date) between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "')")
                        If dtCambiosDepto.Rows.Count > 0 Then
                            drow("alta_ideas") = IIf(IsDBNull(dtCambiosDepto.Rows(0).Item("FECHA_CAMBIO")), drow("alta"), dtCambiosDepto.Rows(0).Item("FECHA_CAMBIO"))
                            Dim d As Date = drow("alta_ideas")
                            Dim e As Date = drow("alta")
                            If d > e Then
                                drow("alta_ideas") = drow("alta")
                            End If

                        End If
                        Dim dtTempIDeasDepto As New DataTable
                        dtCambiosDepto = sqlExecute("select MAX(cast(FECHA as date)) AS FECHA_CAMBIO from bitacora_personal where reloj in ('" & drow("reloj") & "','" & drow("reloj_anterior") & "') and (valorAnterior is not null and valorAnterior <> '') and campo = 'COD_DEPTO' and valorAnterior='" & DeptoOriginal & "' and (cast(FECHA as date) between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "')")
                        If dtCambiosDepto.Rows.Count > 0 Then
                            drow("baja_ideas") = dtCambiosDepto.Rows(0).Item(("FECHA_CAMBIO"))
                        Else
                            dtTempIDeasDepto = dtIDeasDepto.Select("(reloj='" & row("reloj") & "')  and (cod_depto ='" & DeptoOriginal & "')", "fecha desc").CopyToDataTable()
                            If dtTempIDeasDepto.Rows.Count > 0 Then
                                drow("baja_ideas") = dtTempIDeasDepto.Rows(0).Item("fecha")
                            Else
                                drow("baja_ideas") = row("baja")
                            End If

                        End If

                    Catch ex As Exception
                        Debug.Print(ex.Message)
                    End Try
                Else
                    Try
                        Dim dtCambiosDepto As New DataTable
                        dtCambiosDepto = sqlExecute("select MIN(cast(FECHA as date)) AS FECHA_CAMBIO from bitacora_personal where reloj in ('" & drow("reloj") & "','" & drow("reloj_anterior") & "') and (valorAnterior is not null and valorAnterior <> '') and campo = 'COD_DEPTO' and valorNuevo='" & DeptoOriginal & "' and (cast(FECHA as date) between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "')")
                        If dtCambiosDepto.Rows.Count > 0 Then
                            If IsDBNull(dtCambiosDepto.Rows(0).Item(("FECHA_CAMBIO"))) Then
                                Debug.Print("")
                            End If
                            drow("alta_ideas") = IIf(IsDBNull(dtCambiosDepto.Rows(0).Item(("FECHA_CAMBIO"))), drow("alta"), dtCambiosDepto.Rows(0).Item(("FECHA_CAMBIO")))
                        Else
                            drow("alta_ideas") = row("alta_personal")
                        End If
                        ' drow("alta_ideas") = drow("alta_personal")
                        drow("baja_ideas") = row("baja")
                    Catch ex As Exception
                        Debug.Print(ex.Message)
                    End Try

                End If


                ' -----------------------------------------------------------------------------------------------------
                Dim dtObjetivos As DataTable = sqlExecute("select  * from tabulacion_objetivos where ano = '" + (Ano + 1).ToString + "' and reloj='" + RelojObjetivos + "'", "IDEAS")
                If Not dtObjetivos.Rows.Count > 0 Then
                    dtObjetivos = sqlExecute("select  * from tabulacion_objetivos where ano = '" + (Ano + 1).ToString + "' and reloj is null", "IDEAS")
                End If

                ' -----------------------------------------------------------------------------------------------------

                If Date.Parse(drow("alta_ideas")) < fechaini Then
                    drow("mes_inicio") = "feb"
                    drow("meses") = 12
                    drow("objetivo_anual") = dtObjetivos.Rows(0).Item("ene")
                Else
                    Dim mes_inicio As Integer = 0
                    mes_inicio = Date.Parse(drow("alta_ideas")).Month

                    Select Case mes_inicio
                        Case 2
                            drow("mes_inicio") = "feb"
                            drow("meses") = 12
                            'drow("objetivo_anual") = 8
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("feb")
                        Case 3
                            drow("mes_inicio") = "mar"
                            drow("meses") = 11
                            'drow("objetivo_anual") = 7
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("mar")
                        Case 4
                            drow("mes_inicio") = "abr"
                            drow("meses") = 10
                            'drow("objetivo_anual") = 7
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("abr")
                        Case 5
                            drow("mes_inicio") = "may"
                            drow("meses") = 9
                            'drow("objetivo_anual") = 6
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("may")
                        Case 6
                            drow("mes_inicio") = "jun"
                            drow("meses") = 8
                            'drow("objetivo_anual") = 5
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("jun")
                        Case 7
                            drow("mes_inicio") = "jul"
                            drow("meses") = 7
                            'drow("objetivo_anual") = 5
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("jul")
                        Case 8
                            drow("mes_inicio") = "ago"
                            drow("meses") = 6
                            'drow("objetivo_anual") = 4
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("ago")
                        Case 9
                            drow("mes_inicio") = "sep"
                            drow("meses") = 5
                            'drow("objetivo_anual") = 3
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("sep")
                        Case 10
                            drow("mes_inicio") = "oct"
                            drow("meses") = 4
                            'drow("objetivo_anual") = 3
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("oct")
                        Case 11
                            drow("mes_inicio") = "nov"
                            drow("meses") = 3
                            'drow("objetivo_anual") = 2
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("nov")
                        Case 12
                            drow("mes_inicio") = "dic"
                            drow("meses") = 2
                            'drow("objetivo_anual") = 1
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("dic")
                    End Select
                End If


                ' ---------------------------
                Select Case drow("mes_inicio").ToString
                    Case "feb"
                        drow("feb_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("mar_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("abr_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("may_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("jun_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("jul_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("ago_obj") = dtObjetivos.Rows(0).Item("Bjun") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bmay") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Babr") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bmar") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bfeb") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bene")
                    Case "mar"
                        drow("feb_obj") = 0 : drow("mar_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("abr_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("may_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("jun_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("jul_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("ago_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bjun") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bmay") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Babr") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bmar") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bfeb")
                    Case "abr"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("may_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("jun_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("jul_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("ago_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bjun") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bmay") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Babr") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bmar")
                    Case "may"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("jun_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("jul_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("ago_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bjun") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bmay") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Babr")
                    Case "jun"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("jul_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("ago_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bjun") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bmay")
                    Case "jul"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("ago_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bjun")
                    Case "ago"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bjul")
                    Case "sep"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bago")
                    Case "oct"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bsep")
                    Case "nov"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Boct")
                    Case "dic"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("ene_obj") = dtObjetivos.Rows(0).Item("nov")
                    Case "ene"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bdic")
                End Select
                ' ---------------------------


                If Not IsDBNull(drow("baja_ideas")) Then
                    MesFin = Date.Parse(drow("baja_ideas")).Month
                    Select Case MesFin
                        Case 2
                            MesFinal = "feb"
                            drow("meses") = drow("meses") - 11
                            'drow("meses") = 12
                            'drow("objetivo_anual") = drow("objetivo_anual") 
                            'drow("objetivo_anual") = drow("objetivo_anual") - 7
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bfeb")
                        Case 3
                            MesFinal = "mar"
                            drow("meses") = drow("meses") - 10
                            'drow("meses") = 11
                            ' drow("objetivo_anual") = drow("objetivo_anual") - 7
                            'drow("objetivo_anual") = 7
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bmar")
                        Case 4
                            MesFinal = "abr"
                            drow("meses") = drow("meses") - 9
                            'drow("meses") = 10
                            'drow("objetivo_anual") = drow("objetivo_anual") - 6
                            'drow("objetivo_anual") = 7
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Babr")
                        Case 5
                            MesFinal = "may"
                            drow("meses") = drow("meses") - 8
                            'drow("meses") = 9
                            ' drow("objetivo_anual") = drow("objetivo_anual") - 5
                            'drow("objetivo_anual") = 6
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bmay")
                        Case 6
                            MesFinal = "jun"
                            drow("meses") = drow("meses") - 7
                            'drow("meses") = 8
                            'drow("objetivo_anual") = drow("objetivo_anual") - 5
                            'drow("objetivo_anual") = 5
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bjun")
                        Case 7
                            MesFinal = "jul"
                            drow("meses") = drow("meses") - 6
                            'drow("meses") = 7
                            'drow("objetivo_anual") = drow("objetivo_anual") - 4
                            'drow("objetivo_anual") = 5
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bjul")
                        Case 8
                            MesFinal = "ago"
                            drow("meses") = drow("meses") - 5
                            'drow("meses") = 6
                            'drow("objetivo_anual") = drow("objetivo_anual") - 3
                            'drow("objetivo_anual") = 4
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bago")
                        Case 9
                            MesFinal = "sep"
                            drow("meses") = drow("meses") - 4
                            'drow("meses") = 5
                            'drow("objetivo_anual") = drow("objetivo_anual") - 3
                            'drow("objetivo_anual") = 3
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bsep")
                        Case 10
                            MesFinal = "oct"
                            drow("meses") = drow("meses") - 3
                            'drow("meses") = 4
                            'drow("objetivo_anual") = drow("objetivo_anual") - 2
                            'drow("objetivo_anual") = 3
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Boct")
                        Case 11
                            MesFinal = "nov"
                            drow("meses") = drow("meses") - 2
                            'drow("meses") = 3
                            'drow("objetivo_anual") = drow("objetivo_anual") - 1
                            'drow("objetivo_anual") = 2
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bnov")
                        Case 12
                            MesFinal = "dic"
                            drow("meses") = drow("meses") - 1
                            'drow("meses") = 
                            'drow("objetivo_anual") = drow("objetivo_anual") - 1
                            'drow("objetivo_anual") = 1
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bdic")
                    End Select
                    Select Case MesFinal
                        Case "feb"
                            drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
                        Case "mar"
                            drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
                        Case "abr"
                            drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
                        Case "may"
                            drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
                        Case "jun"
                            drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
                        Case "jul"
                            drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
                        Case "ago"
                            drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
                        Case "sep"
                            drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
                        Case "oct"
                            drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
                        Case "nov"
                            drow("dic_obj") = 0 : drow("ene_obj") = 0
                        Case "dic"
                            drow("ene_obj") = 0

                    End Select

                End If

                ' ---------------------------

                drow("fecha_ini") = fechaini
                drow("fecha_fin") = fechafin
            End If

            ' ---------------------------

            'drow("feb_estatus") = IIf((drow("feb_activo") = 1 And drow("feb_acum") >= drow("feb_obj") And drow("feb_obj") > 0) Or drow("feb_obj") = 1, 1, -1)
            'drow("mar_estatus") = IIf((drow("mar_activo") = 1 And drow("mar_acum") >= drow("mar_obj") And drow("mar_obj") > 0) Or drow("mar_obj") = 1, 1, -1)
            'drow("abr_estatus") = IIf((drow("abr_activo") = 1 And drow("abr_acum") >= drow("abr_obj") And drow("abr_obj") > 0) Or drow("abr_obj") = 1, 1, -1)
            'drow("may_estatus") = IIf((drow("may_activo") = 1 And drow("may_acum") >= drow("may_obj") And drow("may_obj") > 0) Or drow("may_obj") = 1, 1, -1)
            'drow("jun_estatus") = IIf((drow("jun_activo") = 1 And drow("jun_acum") >= drow("jun_obj") And drow("jun_obj") > 0) Or drow("jun_obj") = 1, 1, -1)
            'drow("jul_estatus") = IIf((drow("jul_activo") = 1 And drow("jul_acum") >= drow("jul_obj") And drow("jul_obj") > 0) Or drow("jul_obj") = 1, 1, -1)
            'drow("ago_estatus") = IIf((drow("ago_activo") = 1 And drow("ago_acum") >= drow("ago_obj") And drow("ago_obj") > 0) Or drow("ago_obj") = 1, 1, -1)
            'drow("sep_estatus") = IIf((drow("sep_activo") = 1 And drow("sep_acum") >= drow("sep_obj") And drow("sep_obj") > 0) Or drow("sep_obj") = 1, 1, -1)
            'drow("oct_estatus") = IIf((drow("oct_activo") = 1 And drow("oct_acum") >= drow("oct_obj") And drow("oct_obj") > 0) Or drow("oct_obj") = 1, 1, -1)
            'drow("nov_estatus") = IIf((drow("nov_activo") = 1 And drow("nov_acum") >= drow("nov_obj") And drow("nov_obj") > 0) Or drow("nov_obj") = 1, 1, -1)
            'drow("dic_estatus") = IIf((drow("dic_activo") = 1 And drow("dic_acum") >= drow("dic_obj") And drow("dic_obj") > 0) Or drow("dic_obj") = 1, 1, -1)
            'drow("ene_estatus") = IIf((drow("ene_activo") = 1 And drow("ene_acum") >= drow("ene_obj") And drow("ene_obj") > 0) Or drow("ene_obj") = 1, 1, -1)


            drow(row("mes_implementacion") & "_ideas") = drow(row("mes_implementacion") & "_ideas") + 1

            drow("estatus_anual") =
            drow("feb_ideas") +
            drow("mar_ideas") +
            drow("abr_ideas") +
            drow("may_ideas") +
            drow("jun_ideas") +
            drow("jul_ideas") +
            drow("ago_ideas") +
            drow("sep_ideas") +
            drow("oct_ideas") +
            drow("nov_ideas") +
            drow("dic_ideas") +
            drow("ene_ideas")


            drow("feb_acum") = drow("feb_ideas")
            drow("mar_acum") = drow("mar_ideas") + drow("feb_ideas")
            drow("abr_acum") = drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("may_acum") = drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("jun_acum") = drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("jul_acum") = drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("ago_acum") = drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("sep_acum") = drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("oct_acum") = drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("nov_acum") = drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("dic_acum") = drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("ene_acum") = drow("ene_ideas") + drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")



            drow("feb_estatus") = IIf(drow("feb_activo") = 1 And drow("feb_acum") >= drow("feb_obj") And drow("feb_obj") > 0, 1, -1)
            drow("mar_estatus") = IIf(drow("mar_activo") = 1 And drow("mar_acum") >= drow("mar_obj") And drow("mar_obj") > 0, 1, -1)
            drow("abr_estatus") = IIf(drow("abr_activo") = 1 And drow("abr_acum") >= drow("abr_obj") And drow("abr_obj") > 0, 1, -1)
            drow("may_estatus") = IIf(drow("may_activo") = 1 And drow("may_acum") >= drow("may_obj") And drow("may_obj") > 0, 1, -1)
            drow("jun_estatus") = IIf(drow("jun_activo") = 1 And drow("jun_acum") >= drow("jun_obj") And drow("jun_obj") > 0, 1, -1)
            drow("jul_estatus") = IIf(drow("jul_activo") = 1 And drow("jul_acum") >= drow("jul_obj") And drow("jul_obj") > 0, 1, -1)
            drow("ago_estatus") = IIf(drow("ago_activo") = 1 And drow("ago_acum") >= drow("ago_obj") And drow("ago_obj") > 0, 1, -1)
            drow("sep_estatus") = IIf(drow("sep_activo") = 1 And drow("sep_acum") >= drow("sep_obj") And drow("sep_obj") > 0, 1, -1)
            drow("oct_estatus") = IIf(drow("oct_activo") = 1 And drow("oct_acum") >= drow("oct_obj") And drow("oct_obj") > 0, 1, -1)
            drow("nov_estatus") = IIf(drow("nov_activo") = 1 And drow("nov_acum") >= drow("nov_obj") And drow("nov_obj") > 0, 1, -1)
            drow("dic_estatus") = IIf(drow("dic_activo") = 1 And drow("dic_acum") >= drow("dic_obj") And drow("dic_obj") > 0, 1, -1)
            drow("ene_estatus") = IIf(drow("ene_activo") = 1 And drow("ene_acum") >= drow("ene_obj") And drow("ene_obj") > 0, 1, -1)



            'drow("feb_estatus") = IIf((drow("feb_activo") = 1 And drow("feb_acum") >= drow("feb_obj") And drow("feb_obj") > 0) Or drow("feb_obj") = 1, 1, -1)
            'drow("mar_estatus") = IIf((drow("mar_activo") = 1 And drow("mar_acum") >= drow("mar_obj") And drow("mar_obj") > 0) Or drow("mar_obj") = 1, 1, -1)
            'drow("abr_estatus") = IIf((drow("abr_activo") = 1 And drow("abr_acum") >= drow("abr_obj") And drow("abr_obj") > 0) Or drow("abr_obj") = 1, 1, -1)
            'drow("may_estatus") = IIf((drow("may_activo") = 1 And drow("may_acum") >= drow("may_obj") And drow("may_obj") > 0) Or drow("may_obj") = 1, 1, -1)
            'drow("jun_estatus") = IIf((drow("jun_activo") = 1 And drow("jun_acum") >= drow("jun_obj") And drow("jun_obj") > 0) Or drow("jun_obj") = 1, 1, -1)
            'drow("jul_estatus") = IIf((drow("jul_activo") = 1 And drow("jul_acum") >= drow("jul_obj") And drow("jul_obj") > 0) Or drow("jul_obj") = 1, 1, -1)
            'drow("ago_estatus") = IIf((drow("ago_activo") = 1 And drow("ago_acum") >= drow("ago_obj") And drow("ago_obj") > 0) Or drow("ago_obj") = 1, 1, -1)
            'drow("sep_estatus") = IIf((drow("sep_activo") = 1 And drow("sep_acum") >= drow("sep_obj") And drow("sep_obj") > 0) Or drow("sep_obj") = 1, 1, -1)
            'drow("oct_estatus") = IIf((drow("oct_activo") = 1 And drow("oct_acum") >= drow("oct_obj") And drow("oct_obj") > 0) Or drow("oct_obj") = 1, 1, -1)
            'drow("nov_estatus") = IIf((drow("nov_activo") = 1 And drow("nov_acum") >= drow("nov_obj") And drow("nov_obj") > 0) Or drow("nov_obj") = 1, 1, -1)
            'drow("dic_estatus") = IIf((drow("dic_activo") = 1 And drow("dic_acum") >= drow("dic_obj") And drow("dic_obj") > 0) Or drow("dic_obj") = 1, 1, -1)
            'drow("ene_estatus") = IIf((drow("ene_activo") = 1 And drow("ene_acum") >= drow("ene_obj") And drow("ene_obj") > 0) Or drow("ene_obj") = 1, 1, -1)



        Catch ex As Exception
            Debug.Print(ex.Message)

        End Try
    End Sub



    Public Sub ParticipacionIndividualIdeasCBajas(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Dim FechaIni As Date
        Dim FechaFin As Date
        Dim ano As Integer

        Dim objetivo_anual = 8

        dtDatos = New DataTable
        dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

        dtDatos.Columns.Add("cod_super", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))

        dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_depto", Type.GetType("System.String"))

        dtDatos.Columns.Add("cod_super_actual", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_super_actual", Type.GetType("System.String"))

        dtDatos.Columns.Add("cod_depto_actual", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_depto_actual", Type.GetType("System.String"))

        dtDatos.Columns.Add("baja", Type.GetType("System.String"))
        dtDatos.Columns.Add("alta", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("feb_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_ideas", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("meses", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("objetivo_anual", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("estatus_anual", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("feb_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_obj", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("feb_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_estatus", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("feb_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_acum", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("feb_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_activo", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("feb_mob", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_mob", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_mob", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_mob", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_mob", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_mob", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_mob", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_mob", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_mob", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_mob", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_mob", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_mob", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("alta_personal", Type.GetType("System.DateTime"))

        dtDatos.Columns.Add("transferencia", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("reloj_anterior", Type.GetType("System.String"))

        dtDatos.Columns.Add("alta_ideas", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("baja_ideas", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("mes_inicio", Type.GetType("System.String"))

        dtDatos.Columns.Add("fecha_ini", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("fecha_fin", Type.GetType("System.DateTime"))

        dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj"), dtDatos.Columns("cod_depto")}

        ano = Year(FechaFinal)
        For Each dRow As DataRow In dtInformacion.Rows
            If Not IsDBNull(dRow("fecha")) Then
                If Month(dtInformacion.Rows(0).Item("fecha")) = 1 Then
                    ano = Year(dtInformacion.Rows(0).Item("fecha")) - 1
                Else
                    ano = Year(dtInformacion.Rows(0).Item("fecha"))
                End If
                Exit For
            Else
                If Month(FechaFinal) = 1 Then
                    ano = Year(FechaFinal) - 1
                Else
                    ano = Year(FechaFinal)
                End If
                Exit For
            End If
        Next

        Dim dtperiodos As DataTable
        dtperiodos = sqlExecute("select * from periodos where periodo_especial = 0 and ano = '" & ano & "' and num_mes = '02' order by periodo asc", "ta")
        If dtperiodos.Rows.Count > 0 Then
            FechaIni = dtperiodos.Rows(0)("fecha_ini")
            Dim TempFinal As String
            Dim TempFecha As String
            TempFinal = FechaSQL(FechaFinal).ToString.Substring(5, 5)
            TempFecha = FechaSQL(FechaInicial).ToString.Substring(5, 5)
            If TempFecha <> "02-01" Or TempFinal <> "01-31" Then
                MensajeError = "Es necesario cargar el año fiscal"
                MostrarReporte = False
                Exit Sub
            End If
        End If

        dtperiodos = sqlExecute("select * from periodos where periodo_especial = 0 and ano = '" & ano + 1 & "' and num_mes = '01' order by periodo desc", "ta")
        If dtperiodos.Rows.Count > 0 Then
            FechaFin = dtperiodos.Rows(0)("fecha_fin")
        End If


        Dim dtMesesTranscurridos As DataTable = sqlExecute("select distinct(lower(substring(mes, 1, 3))) as mes, ano, num_mes from periodos where periodo_especial = 0 and ((ano = '" & ano & "' and num_mes >= '02') or (ano = '" & ano + 1 & "' and num_mes = '01')) and fecha_fin < '" & FechaSQL(Now) & "' GROUP BY ano, mes, num_mes order by ano asc, num_mes asc", "ta")

        Dim dtIdeas As DataTable = dtInformacion.Select("", "reloj,fecha").CopyToDataTable
        Dim dtIdeasTransferencia As DataTable = dtIdeas.Clone

        For Each row As DataRow In dtIdeas.Rows
            AuxiliarIndividualIdeasCbajas(row, dtDatos, True, dtMesesTranscurridos, FechaIni, FechaFin, ano, dtIdeasTransferencia, dtIdeas)
        Next

        For Each row As DataRow In dtIdeasTransferencia.Rows
            AuxiliarIndividualIdeasCbajas(row, dtDatos, False, dtMesesTranscurridos, FechaIni, FechaFin, ano, dtIdeasTransferencia, dtIdeas)
        Next



    End Sub
    Private Sub AuxiliarIndividualIdeasCbajas(row As DataRow, ByRef DtDatos As DataTable, transferencias As Boolean, dtMesesTranscurridos As DataTable, fechaini As Date, fechafin As Date, Ano As Int32, ByRef dtIdeasTransferencia As DataTable, ByVal dtIDeasDepto As DataTable)

        Try
            Dim RelojObjetivos As String = ""
            Dim Llaves(1) As Object
            Llaves(0) = row("reloj")
            Llaves(1) = row("cod_depto")
            Dim drow As DataRow = DtDatos.Rows.Find(Llaves)
            Dim MesFin As Integer = 0
            Dim MesFinal As String = ""

            If drow Is Nothing Then
                drow = DtDatos.NewRow
                RelojObjetivos = row("reloj")
                drow("reloj") = row("reloj")
                drow("cod_depto") = row("cod_depto")
                DtDatos.Rows.Add(drow)

                drow("nombres") = RTrim(row("nombres"))
                drow("cod_super") = row("cod_super")
                drow("nombre_super") = row("nombre_super")
                drow("nombre_depto") = row("nombre_depto")
                drow("cod_super_actual") = row("cod_super_actual")
                drow("cod_depto_actual") = row("cod_depto_actual")
                drow("nombre_super_actual") = row("nombre_super_actual")
                drow("nombre_depto_actual") = row("nombre_depto_actual")
                drow("alta") = row("alta")

                Dim DeptoOriginal As String = drow("cod_depto").ToString
                Dim DeptoActual As String = drow("cod_depto_actual").ToString


                If row("reloj").ToString.Trim.Equals("031175") Then
                    row("baja") = Date.Parse("2015-03-31")
                End If
                ''020158'

                If row("reloj").ToString.Trim.Equals("020158") Then
                    row("alta") = "2015-08-01"
                End If

                Try
                    drow("baja") = IIf(IsDBNull(row("baja")), "", "Baja " + FechaSQL(row("baja")))
                    'MesBaja = Month(row("baja"))

                Catch ex As Exception
                    drow("baja") = ""
                End Try
                drow("feb_ideas") = 0
                drow("mar_ideas") = 0
                drow("abr_ideas") = 0
                drow("may_ideas") = 0
                drow("jun_ideas") = 0
                drow("jul_ideas") = 0
                drow("ago_ideas") = 0
                drow("sep_ideas") = 0
                drow("oct_ideas") = 0
                drow("nov_ideas") = 0
                drow("dic_ideas") = 0
                drow("ene_ideas") = 0

                drow("estatus_anual") = 0


                drow("feb_obj") = -1
                drow("mar_obj") = -1
                drow("abr_obj") = -1
                drow("may_obj") = -1
                drow("jun_obj") = -1
                drow("jul_obj") = -1
                drow("ago_obj") = -1
                drow("sep_obj") = -1
                drow("oct_obj") = -1
                drow("nov_obj") = -1
                drow("dic_obj") = -1
                drow("ene_obj") = -1

                drow("feb_acum") = drow("feb_ideas")
                drow("mar_acum") = drow("mar_ideas") + drow("feb_ideas")
                drow("abr_acum") = drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("may_acum") = drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("jun_acum") = drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("jul_acum") = drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("ago_acum") = drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("sep_acum") = drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("oct_acum") = drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("nov_acum") = drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("dic_acum") = drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("ene_acum") = drow("ene_ideas") + drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")

                drow("feb_estatus") = -1
                drow("mar_estatus") = -1
                drow("abr_estatus") = -1
                drow("may_estatus") = -1
                drow("jun_estatus") = -1
                drow("jul_estatus") = -1
                drow("ago_estatus") = -1
                drow("sep_estatus") = -1
                drow("oct_estatus") = -1
                drow("nov_estatus") = -1
                drow("dic_estatus") = -1
                drow("ene_estatus") = -1


                drow("feb_activo") = -1
                drow("mar_activo") = -1
                drow("abr_activo") = -1
                drow("may_activo") = -1
                drow("jun_activo") = -1
                drow("jul_activo") = -1
                drow("ago_activo") = -1
                drow("sep_activo") = -1
                drow("oct_activo") = -1
                drow("nov_activo") = -1
                drow("dic_activo") = -1
                drow("ene_activo") = -1



                drow("feb_mob") = 1
                drow("mar_mob") = 1
                drow("abr_mob") = 1
                drow("may_mob") = 1
                drow("jun_mob") = 1
                drow("jul_mob") = 1
                drow("ago_mob") = 1
                drow("sep_mob") = 1
                drow("oct_mob") = 1
                drow("nov_mob") = 1
                drow("dic_mob") = 1
                drow("ene_mob") = 1

                For Each mes As DataRow In dtMesesTranscurridos.Rows
                    drow(mes("mes") & "_activo") = 1
                Next
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                drow("alta_personal") = row("alta")
                drow("transferencia") = 0
                drow("reloj_anterior") = ""

                If transferencias Then
                    Dim dt_transferencia As DataTable = sqlExecute("select * from transferencias where reloj_nuevo = '" & row("reloj") & "' and alta > alta_anterior")
                    If dt_transferencia.Rows.Count > 0 Then
                        'If Date.Parse(dt_transferencia.Rows(0)("alta_anterior")) > FechaIni Then
                        drow("transferencia") = 1
                        drow("reloj_anterior") = dt_transferencia.Rows(0)("reloj_anterior")
                        drow("alta_personal") = row("alta")
                        drow("alta") = Date.Parse(dt_transferencia.Rows(0)("alta_anterior"))

                        'End If

                        Try
                            Dim dtIdeasAgencia As DataTable = sqlExecute("SELECT ideasVW.*,cias.nombre AS COMPANIA,deptos.nombre AS NOMBRE_DEPTO,SUPER.NOMBRE AS NOMBRE_SUPER," & _
                                                                   "AREAS.NOMBRE AS NOMBRE_AREA,puestos.nombre as 'nombre_puesto' FROM IDEASVW " & _
                                                                   "LEFT JOIN personal.dbo.cias ON ideasVW.cod_comp = cias.cod_comp " & _
                                                                   "LEFT JOIN personal.dbo.deptos ON ideasVW.cod_comp = deptos.cod_comp AND ideasVW.cod_depto = deptos.cod_depto " & _
                                                                   "LEFT JOIN personal.dbo.super ON ideasVW.cod_comp = super.cod_comp AND ideasVW.cod_super = super.cod_super " & _
                                                                   "LEFT JOIN personal.dbo.puestos ON ideasVW.cod_comp = puestos.cod_comp AND ideasVW.cod_puesto = puestos.cod_puesto " & _
                                                                   "LEFT JOIN personal.dbo.areas ON ideasVW.cod_comp = areas.cod_comp AND ideasVW.cod_area = areas.cod_area " & _
                                                                   "WHERE fecha BETWEEN '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "' and ideasvw.reloj = '" & dt_transferencia.Rows(0)("reloj_anterior") & "' and cod_depto = '" & row("cod_depto") & "'", "IDEAS")

                            For Each row_agencia As DataRow In dtIdeasAgencia.Rows
                                row_agencia("reloj") = row("reloj")
                                row_agencia("cod_depto") = row("cod_depto")
                                dtIdeasTransferencia.ImportRow(row_agencia)
                            Next

                        Catch ex As Exception
                            Debug.Print(ex.Message)
                        End Try


                    End If
                End If
                ' ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If DeptoOriginal <> DeptoActual Then
                    Try

                        Dim dtCambiosDepto As New DataTable
                        dtCambiosDepto = sqlExecute("select MIN(cast(FECHA as date)) AS FECHA_CAMBIO from bitacora_personal where reloj in ('" & drow("reloj") & "','" & drow("reloj_anterior") & "')and (valorAnterior is not null and valorAnterior <> '') and campo = 'COD_DEPTO' and valorNuevo='" & DeptoOriginal & "' and (cast(FECHA as date) between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "')")
                        If dtCambiosDepto.Rows.Count > 0 Then
                            drow("alta_ideas") = IIf(IsDBNull(dtCambiosDepto.Rows(0).Item("FECHA_CAMBIO")), drow("alta"), dtCambiosDepto.Rows(0).Item("FECHA_CAMBIO"))
                            Dim d As Date = drow("alta_ideas")
                            Dim e As Date = drow("alta")
                            If d > e Then
                                drow("alta_ideas") = drow("alta")
                            End If

                        End If
                        Dim dtTempIDeasDepto As New DataTable
                        dtCambiosDepto = sqlExecute("select MAX(cast(FECHA as date)) AS FECHA_CAMBIO from bitacora_personal where reloj in ('" & drow("reloj") & "','" & drow("reloj_anterior") & "') and (valorAnterior is not null and valorAnterior <> '') and campo = 'COD_DEPTO' and valorAnterior='" & DeptoOriginal & "' and (cast(FECHA as date) between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "')")
                        If dtCambiosDepto.Rows.Count > 0 Then
                            drow("baja_ideas") = dtCambiosDepto.Rows(0).Item(("FECHA_CAMBIO"))
                        Else
                            dtTempIDeasDepto = dtIDeasDepto.Select("(reloj='" & row("reloj") & "')  and (cod_depto ='" & DeptoOriginal & "')", "fecha desc").CopyToDataTable()
                            If dtTempIDeasDepto.Rows.Count > 0 Then
                                drow("baja_ideas") = dtTempIDeasDepto.Rows(0).Item("fecha")
                            Else
                                drow("baja_ideas") = row("baja")
                            End If

                        End If

                    Catch ex As Exception
                        Debug.Print(ex.Message)
                    End Try
                Else
                    Try
                        Dim dtCambiosDepto As New DataTable
                        dtCambiosDepto = sqlExecute("select MIN(cast(FECHA as date)) AS FECHA_CAMBIO from bitacora_personal where reloj in ('" & drow("reloj") & "','" & drow("reloj_anterior") & "') and (valorAnterior is not null and valorAnterior <> '') and campo = 'COD_DEPTO' and valorNuevo='" & DeptoOriginal & "' and (cast(FECHA as date) between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "')")
                        If dtCambiosDepto.Rows.Count > 0 Then
                            If IsDBNull(dtCambiosDepto.Rows(0).Item(("FECHA_CAMBIO"))) Then
                                Debug.Print("")
                            End If
                            drow("alta_ideas") = IIf(IsDBNull(dtCambiosDepto.Rows(0).Item(("FECHA_CAMBIO"))), drow("alta"), dtCambiosDepto.Rows(0).Item(("FECHA_CAMBIO")))
                        Else
                            drow("alta_ideas") = row("alta_personal")
                        End If
                        ' drow("alta_ideas") = drow("alta_personal")
                        drow("baja_ideas") = row("baja")
                    Catch ex As Exception
                        Debug.Print(ex.Message)
                    End Try

                End If


                ' -----------------------------------------------------------------------------------------------------
                Dim dtObjetivos As DataTable = sqlExecute("select  * from tabulacion_objetivos where ano = '" + (Ano + 1).ToString + "' and reloj='" + RelojObjetivos + "'", "IDEAS")
                If Not dtObjetivos.Rows.Count > 0 Then
                    dtObjetivos = sqlExecute("select  * from tabulacion_objetivos where ano = '" + (Ano + 1).ToString + "' and reloj is null", "IDEAS")
                End If

                ' -----------------------------------------------------------------------------------------------------

                If Date.Parse(drow("alta_ideas")) < fechaini Then
                    drow("mes_inicio") = "feb"
                    drow("meses") = 12
                    drow("objetivo_anual") = dtObjetivos.Rows(0).Item("ene")
                Else
                    Dim mes_inicio As Integer = 0
                    mes_inicio = Date.Parse(drow("alta_ideas")).Month

                    Select Case mes_inicio
                        Case 2
                            drow("mes_inicio") = "feb"
                            drow("meses") = 12
                            'drow("objetivo_anual") = 8
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("feb")
                        Case 3
                            drow("mes_inicio") = "mar"
                            drow("meses") = 11
                            'drow("objetivo_anual") = 7
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("mar")
                        Case 4
                            drow("mes_inicio") = "abr"
                            drow("meses") = 10
                            'drow("objetivo_anual") = 7
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("abr")
                        Case 5
                            drow("mes_inicio") = "may"
                            drow("meses") = 9
                            'drow("objetivo_anual") = 6
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("may")
                        Case 6
                            drow("mes_inicio") = "jun"
                            drow("meses") = 8
                            'drow("objetivo_anual") = 5
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("jun")
                        Case 7
                            drow("mes_inicio") = "jul"
                            drow("meses") = 7
                            'drow("objetivo_anual") = 5
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("jul")
                        Case 8
                            drow("mes_inicio") = "ago"
                            drow("meses") = 6
                            'drow("objetivo_anual") = 4
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("ago")
                        Case 9
                            drow("mes_inicio") = "sep"
                            drow("meses") = 5
                            'drow("objetivo_anual") = 3
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("sep")
                        Case 10
                            drow("mes_inicio") = "oct"
                            drow("meses") = 4
                            'drow("objetivo_anual") = 3
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("oct")
                        Case 11
                            drow("mes_inicio") = "nov"
                            drow("meses") = 3
                            'drow("objetivo_anual") = 2
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("nov")
                        Case 12
                            drow("mes_inicio") = "dic"
                            drow("meses") = 2
                            'drow("objetivo_anual") = 1
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("dic")
                    End Select
                End If

                Dim Minicio As Integer = Date.Parse(drow("alta_ideas")).Month
                Dim Ainicio As Integer = Date.Parse(drow("alta_ideas")).Year
                ' ---------------------------
                If (Ainicio = Date.Now.Year And Minicio > 2) Or (Ainicio = Date.Now.Year + 1 And Minicio = 1) Then
                    Select Case drow("mes_inicio").ToString
                        Case "feb"
                            drow("feb_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("mar_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("abr_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("may_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("jun_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("jul_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("ago_obj") = dtObjetivos.Rows(0).Item("Bjun") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bmay") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Babr") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bmar") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bfeb") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bene")
                        Case "mar"
                            drow("feb_obj") = -1 : drow("mar_obj") = -1 : drow("abr_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("may_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("jun_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("jul_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("ago_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bjun") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bmay") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Babr") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bmar") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bfeb")
                        Case "abr"
                            drow("feb_obj") = -1 : drow("mar_obj") = -1 : drow("abr_obj") = -1 : drow("may_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("jun_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("jul_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("ago_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bjun") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bmay") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Babr") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bmar")
                        Case "may"
                            drow("feb_obj") = -1 : drow("mar_obj") = -1 : drow("abr_obj") = -1 : drow("may_obj") = -1 : drow("jun_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("jul_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("ago_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bjun") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bmay") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Babr")
                        Case "jun"
                            drow("feb_obj") = -1 : drow("mar_obj") = -1 : drow("abr_obj") = -1 : drow("may_obj") = -1 : drow("jun_obj") = -1 : drow("jul_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("ago_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bjun") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bmay")
                        Case "jul"
                            drow("feb_obj") = -1 : drow("mar_obj") = -1 : drow("abr_obj") = -1 : drow("may_obj") = -1 : drow("jun_obj") = -1 : drow("jul_obj") = -1 : drow("ago_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bjun")
                        Case "ago"
                            drow("feb_obj") = -1 : drow("mar_obj") = -1 : drow("abr_obj") = -1 : drow("may_obj") = -1 : drow("jun_obj") = -1 : drow("jul_obj") = -1 : drow("ago_obj") = -1 : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bjul")
                        Case "sep"
                            drow("feb_obj") = -1 : drow("mar_obj") = -1 : drow("abr_obj") = -1 : drow("may_obj") = -1 : drow("jun_obj") = -1 : drow("jul_obj") = -1 : drow("ago_obj") = -1 : drow("sep_obj") = -1 : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bago")
                        Case "oct"
                            drow("feb_obj") = -1 : drow("mar_obj") = -1 : drow("abr_obj") = -1 : drow("may_obj") = -1 : drow("jun_obj") = -1 : drow("jul_obj") = -1 : drow("ago_obj") = -1 : drow("sep_obj") = -1 : drow("oct_obj") = -1 : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bsep")
                        Case "nov"
                            drow("feb_obj") = -1 : drow("mar_obj") = -1 : drow("abr_obj") = -1 : drow("may_obj") = -1 : drow("jun_obj") = -1 : drow("jul_obj") = -1 : drow("ago_obj") = -1 : drow("sep_obj") = -1 : drow("oct_obj") = -1 : drow("nov_obj") = -1 : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Boct")
                        Case "dic"
                            drow("feb_obj") = -1 : drow("mar_obj") = -1 : drow("abr_obj") = -1 : drow("may_obj") = -1 : drow("jun_obj") = -1 : drow("jul_obj") = -1 : drow("ago_obj") = -1 : drow("sep_obj") = -1 : drow("oct_obj") = -1 : drow("nov_obj") = -1 : drow("dic_obj") = -1 : drow("ene_obj") = dtObjetivos.Rows(0).Item("nov")
                        Case "ene"
                            drow("feb_obj") = -1 : drow("mar_obj") = -1 : drow("abr_obj") = -1 : drow("may_obj") = -1 : drow("jun_obj") = -1 : drow("jul_obj") = -1 : drow("ago_obj") = -1 : drow("sep_obj") = -1 : drow("oct_obj") = -1 : drow("nov_obj") = -1 : drow("dic_obj") = -1 : drow("ene_obj") = -1
                    End Select

                    Select Case drow("mes_inicio").ToString
                        Case "mar"
                            drow("feb_mob") = 0 : drow("mar_mob") = 0
                        Case "abr"
                            drow("feb_mob") = 0 : drow("mar_mob") = 0 : drow("abr_mob") = 0
                        Case "may"
                            drow("feb_mob") = 0 : drow("mar_mob") = 0 : drow("abr_mob") = 0 : drow("may_mob") = 0
                        Case "jun"
                            drow("feb_mob") = 0 : drow("mar_mob") = 0 : drow("abr_mob") = 0 : drow("may_mob") = 0 : drow("jun_mob") = 0
                        Case "jul"
                            drow("feb_mob") = 0 : drow("mar_mob") = 0 : drow("abr_mob") = 0 : drow("may_mob") = 0 : drow("jun_mob") = 0 : drow("jul_mob") = 0
                        Case "ago"
                            drow("feb_mob") = 0 : drow("mar_mob") = 0 : drow("abr_mob") = 0 : drow("may_mob") = 0 : drow("jun_mob") = 0 : drow("jul_mob") = 0 : drow("ago_mob") = 0
                        Case "sep"
                            drow("feb_mob") = 0 : drow("mar_mob") = 0 : drow("abr_mob") = 0 : drow("may_mob") = 0 : drow("jun_mob") = 0 : drow("jul_mob") = 0 : drow("ago_mob") = 0 : drow("sep_mob") = 0
                        Case "oct"
                            drow("feb_mob") = 0 : drow("mar_mob") = 0 : drow("abr_mob") = 0 : drow("may_mob") = 0 : drow("jun_mob") = 0 : drow("jul_mob") = 0 : drow("ago_mob") = 0 : drow("sep_mob") = 0 : drow("oct_mob") = 0
                        Case "nov"
                            drow("feb_mob") = 0 : drow("mar_mob") = 0 : drow("abr_mob") = 0 : drow("may_mob") = 0 : drow("jun_mob") = 0 : drow("jul_mob") = 0 : drow("ago_mob") = 0 : drow("sep_mob") = 0 : drow("oct_mob") = 0 : drow("nov_mob") = 0
                        Case "dic"
                            drow("feb_mob") = 0 : drow("mar_mob") = 0 : drow("abr_mob") = 0 : drow("may_mob") = 0 : drow("jun_mob") = 0 : drow("jul_mob") = 0 : drow("ago_mob") = 0 : drow("sep_mob") = 0 : drow("oct_mob") = 0 : drow("nov_mob") = 0 : drow("dic_mob") = 0
                        Case "ene"
                            drow("feb_mob") = 0 : drow("mar_mob") = 0 : drow("abr_mob") = 0 : drow("may_mob") = 0 : drow("jun_mob") = 0 : drow("jul_mob") = 0 : drow("ago_mob") = 0 : drow("sep_mob") = 0 : drow("oct_mob") = 0 : drow("nov_mob") = 0 : drow("dic_mob") = 0 : drow("ene_mob") = 0
                    End Select

                Else
                    Select Case drow("mes_inicio").ToString
                        Case "feb"
                            drow("feb_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("mar_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("abr_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("may_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("jun_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("jul_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("ago_obj") = dtObjetivos.Rows(0).Item("Bjun") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bmay") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Babr") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bmar") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bfeb") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bene")
                        Case "mar"
                            drow("feb_obj") = -1 : drow("mar_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("abr_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("may_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("jun_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("jul_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("ago_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bjun") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bmay") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Babr") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bmar") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bfeb")
                        Case "abr"
                            drow("feb_obj") = -1 : drow("mar_obj") = -1 : drow("abr_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("may_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("jun_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("jul_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("ago_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bjun") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bmay") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Babr") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bmar")
                        Case "may"
                            drow("feb_obj") = -1 : drow("mar_obj") = -1 : drow("abr_obj") = -1 : drow("may_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("jun_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("jul_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("ago_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bjun") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bmay") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Babr")
                        Case "jun"
                            drow("feb_obj") = -1 : drow("mar_obj") = -1 : drow("abr_obj") = -1 : drow("may_obj") = -1 : drow("jun_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("jul_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("ago_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bjun") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bmay")
                        Case "jul"
                            drow("feb_obj") = -1 : drow("mar_obj") = -1 : drow("abr_obj") = -1 : drow("may_obj") = -1 : drow("jun_obj") = -1 : drow("jul_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("ago_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bjun")
                        Case "ago"
                            drow("feb_obj") = -1 : drow("mar_obj") = -1 : drow("abr_obj") = -1 : drow("may_obj") = -1 : drow("jun_obj") = -1 : drow("jul_obj") = -1 : drow("ago_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bjul")
                        Case "sep"
                            drow("feb_obj") = -1 : drow("mar_obj") = -1 : drow("abr_obj") = -1 : drow("may_obj") = -1 : drow("jun_obj") = -1 : drow("jul_obj") = -1 : drow("ago_obj") = -1 : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bago")
                        Case "oct"
                            drow("feb_obj") = -1 : drow("mar_obj") = -1 : drow("abr_obj") = -1 : drow("may_obj") = -1 : drow("jun_obj") = -1 : drow("jul_obj") = -1 : drow("ago_obj") = -1 : drow("sep_obj") = -1 : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bsep")
                        Case "nov"
                            drow("feb_obj") = -1 : drow("mar_obj") = -1 : drow("abr_obj") = -1 : drow("may_obj") = -1 : drow("jun_obj") = -1 : drow("jul_obj") = -1 : drow("ago_obj") = -1 : drow("sep_obj") = -1 : drow("oct_obj") = -1 : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Boct")
                        Case "dic"
                            drow("feb_obj") = -1 : drow("mar_obj") = -1 : drow("abr_obj") = -1 : drow("may_obj") = -1 : drow("jun_obj") = -1 : drow("jul_obj") = -1 : drow("ago_obj") = -1 : drow("sep_obj") = -1 : drow("oct_obj") = -1 : drow("nov_obj") = -1 : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("ene_obj") = dtObjetivos.Rows(0).Item("nov")
                        Case "ene"
                            drow("feb_obj") = -1 : drow("mar_obj") = -1 : drow("abr_obj") = -1 : drow("may_obj") = -1 : drow("jun_obj") = -1 : drow("jul_obj") = -1 : drow("ago_obj") = -1 : drow("sep_obj") = -1 : drow("oct_obj") = -1 : drow("nov_obj") = -1 : drow("dic_obj") = -1 : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bdic")
                    End Select



                    Select Case drow("mes_inicio").ToString
                        Case "mar"
                            drow("feb_mob") = 0
                        Case "abr"
                            drow("feb_mob") = 0 : drow("mar_mob") = 0
                        Case "may"
                            drow("feb_mob") = 0 : drow("mar_mob") = 0 : drow("abr_mob") = 0
                        Case "jun"
                            drow("feb_mob") = 0 : drow("mar_mob") = 0 : drow("abr_mob") = 0 : drow("may_mob") = 0
                        Case "jul"
                            drow("feb_mob") = 0 : drow("mar_mob") = 0 : drow("abr_mob") = 0 : drow("may_mob") = 0 : drow("jun_mob") = 0
                        Case "ago"
                            drow("feb_mob") = 0 : drow("mar_mob") = 0 : drow("abr_mob") = 0 : drow("may_mob") = 0 : drow("jun_mob") = 0 : drow("jul_mob") = 0
                        Case "sep"
                            drow("feb_mob") = 0 : drow("mar_mob") = 0 : drow("abr_mob") = 0 : drow("may_mob") = 0 : drow("jun_mob") = 0 : drow("jul_mob") = 0 : drow("ago_mob") = 0
                        Case "oct"
                            drow("feb_mob") = 0 : drow("mar_mob") = 0 : drow("abr_mob") = 0 : drow("may_mob") = 0 : drow("jun_mob") = 0 : drow("jul_mob") = 0 : drow("ago_mob") = 0 : drow("sep_mob") = 0
                        Case "nov"
                            drow("feb_mob") = 0 : drow("mar_mob") = 0 : drow("abr_mob") = 0 : drow("may_mob") = 0 : drow("jun_mob") = 0 : drow("jul_mob") = 0 : drow("ago_mob") = 0 : drow("sep_mob") = 0 : drow("oct_mob") = 0
                        Case "dic"
                            drow("feb_mob") = 0 : drow("mar_mob") = 0 : drow("abr_mob") = 0 : drow("may_mob") = 0 : drow("jun_mob") = 0 : drow("jul_mob") = 0 : drow("ago_mob") = 0 : drow("sep_mob") = 0 : drow("oct_mob") = 0 : drow("nov_mob") = 0
                        Case "ene"
                            drow("feb_mob") = 0 : drow("mar_mob") = 0 : drow("abr_mob") = 0 : drow("may_mob") = 0 : drow("jun_mob") = 0 : drow("jul_mob") = 0 : drow("ago_mob") = 0 : drow("sep_mob") = 0 : drow("oct_mob") = 0 : drow("nov_mob") = 0 : drow("dic_mob") = 0
                    End Select

                End If
                ' ---------------------------


                If Not IsDBNull(drow("baja_ideas")) Then
                    MesFin = Date.Parse(drow("baja_ideas")).Month
                    Select Case MesFin
                        Case 2
                            MesFinal = "feb"
                            drow("meses") = drow("meses") - 11
                            'drow("meses") = 12
                            'drow("objetivo_anual") = drow("objetivo_anual") 
                            'drow("objetivo_anual") = drow("objetivo_anual") - 7
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bfeb")
                        Case 3
                            MesFinal = "mar"
                            drow("meses") = drow("meses") - 10
                            'drow("meses") = 11
                            ' drow("objetivo_anual") = drow("objetivo_anual") - 7
                            'drow("objetivo_anual") = 7
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bmar")
                        Case 4
                            MesFinal = "abr"
                            drow("meses") = drow("meses") - 9
                            'drow("meses") = 10
                            'drow("objetivo_anual") = drow("objetivo_anual") - 6
                            'drow("objetivo_anual") = 7
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Babr")
                        Case 5
                            MesFinal = "may"
                            drow("meses") = drow("meses") - 8
                            'drow("meses") = 9
                            ' drow("objetivo_anual") = drow("objetivo_anual") - 5
                            'drow("objetivo_anual") = 6
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bmay")
                        Case 6
                            MesFinal = "jun"
                            drow("meses") = drow("meses") - 7
                            'drow("meses") = 8
                            'drow("objetivo_anual") = drow("objetivo_anual") - 5
                            'drow("objetivo_anual") = 5
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bjun")
                        Case 7
                            MesFinal = "jul"
                            drow("meses") = drow("meses") - 6
                            'drow("meses") = 7
                            'drow("objetivo_anual") = drow("objetivo_anual") - 4
                            'drow("objetivo_anual") = 5
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bjul")
                        Case 8
                            MesFinal = "ago"
                            drow("meses") = drow("meses") - 5
                            'drow("meses") = 6
                            'drow("objetivo_anual") = drow("objetivo_anual") - 3
                            'drow("objetivo_anual") = 4
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bago")
                        Case 9
                            MesFinal = "sep"
                            drow("meses") = drow("meses") - 4
                            'drow("meses") = 5
                            'drow("objetivo_anual") = drow("objetivo_anual") - 3
                            'drow("objetivo_anual") = 3
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bsep")
                        Case 10
                            MesFinal = "oct"
                            drow("meses") = drow("meses") - 3
                            'drow("meses") = 4
                            'drow("objetivo_anual") = drow("objetivo_anual") - 2
                            'drow("objetivo_anual") = 3
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Boct")
                        Case 11
                            MesFinal = "nov"
                            drow("meses") = drow("meses") - 2
                            'drow("meses") = 3
                            'drow("objetivo_anual") = drow("objetivo_anual") - 1
                            'drow("objetivo_anual") = 2
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bnov")
                        Case 12
                            MesFinal = "dic"
                            drow("meses") = drow("meses") - 1
                            'drow("meses") = 
                            'drow("objetivo_anual") = drow("objetivo_anual") - 1
                            'drow("objetivo_anual") = 1
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bdic")
                    End Select
                    Select Case MesFinal
                        Case "feb"
                            drow("mar_obj") = -1 : drow("abr_obj") = -1 : drow("may_obj") = -1 : drow("jun_obj") = -1 : drow("jul_obj") = -1 : drow("ago_obj") = -1 : drow("sep_obj") = -1 : drow("oct_obj") = -1 : drow("nov_obj") = -1 : drow("dic_obj") = -1 : drow("ene_obj") = -1
                        Case "mar"
                            drow("abr_obj") = -1 : drow("may_obj") = -1 : drow("jun_obj") = -1 : drow("jul_obj") = -1 : drow("ago_obj") = -1 : drow("sep_obj") = -1 : drow("oct_obj") = -1 : drow("nov_obj") = -1 : drow("dic_obj") = -1 : drow("ene_obj") = -1
                        Case "abr"
                            drow("may_obj") = -1 : drow("jun_obj") = -1 : drow("jul_obj") = -1 : drow("ago_obj") = -1 : drow("sep_obj") = -1 : drow("oct_obj") = -1 : drow("nov_obj") = -1 : drow("dic_obj") = -1 : drow("ene_obj") = -1
                        Case "may"
                            drow("jun_obj") = -1 : drow("jul_obj") = -1 : drow("ago_obj") = -1 : drow("sep_obj") = -1 : drow("oct_obj") = -1 : drow("nov_obj") = -1 : drow("dic_obj") = -1 : drow("ene_obj") = -1
                        Case "jun"
                            drow("jul_obj") = -1 : drow("ago_obj") = -1 : drow("sep_obj") = -1 : drow("oct_obj") = -1 : drow("nov_obj") = -1 : drow("dic_obj") = -1 : drow("ene_obj") = -1
                        Case "jul"
                            drow("ago_obj") = -1 : drow("sep_obj") = -1 : drow("oct_obj") = -1 : drow("nov_obj") = -1 : drow("dic_obj") = -1 : drow("ene_obj") = -1
                        Case "ago"
                            drow("sep_obj") = -1 : drow("oct_obj") = -1 : drow("nov_obj") = -1 : drow("dic_obj") = -1 : drow("ene_obj") = -1
                        Case "sep"
                            drow("oct_obj") = -1 : drow("nov_obj") = -1 : drow("dic_obj") = -1 : drow("ene_obj") = -1
                        Case "oct"
                            drow("nov_obj") = -1 : drow("dic_obj") = -1 : drow("ene_obj") = -1
                        Case "nov"
                            drow("dic_obj") = -1 : drow("ene_obj") = -1
                        Case "dic"
                            drow("ene_obj") = -1
                    End Select

                    Select Case MesFinal
                        Case "feb"
                            drow("mar_mob") = 0 : drow("abr_mob") = 0 : drow("may_mob") = 0 : drow("jun_mob") = 0 : drow("jul_mob") = 0 : drow("ago_mob") = 0 : drow("sep_mob") = 0 : drow("oct_mob") = 0 : drow("nov_mob") = 0 : drow("dic_mob") = 0 : drow("ene_mob") = 0
                        Case "mar"
                            drow("abr_mob") = 0 : drow("may_mob") = 0 : drow("jun_mob") = 0 : drow("jul_mob") = 0 : drow("ago_mob") = 0 : drow("sep_mob") = 0 : drow("oct_mob") = 0 : drow("nov_mob") = 0 : drow("dic_mob") = 0 : drow("ene_mob") = 0
                        Case "abr"
                            drow("may_mob") = 0 : drow("jun_mob") = 0 : drow("jul_mob") = 0 : drow("ago_mob") = 0 : drow("sep_mob") = 0 : drow("oct_mob") = 0 : drow("nov_mob") = 0 : drow("dic_mob") = 0 : drow("ene_mob") = 0
                        Case "may"
                            drow("jun_mob") = 0 : drow("jul_mob") = 0 : drow("ago_mob") = 0 : drow("sep_mob") = 0 : drow("oct_mob") = 0 : drow("nov_mob") = 0 : drow("dic_mob") = 0 : drow("ene_mob") = 0
                        Case "jun"
                            drow("jul_mob") = 0 : drow("ago_mob") = 0 : drow("sep_mob") = 0 : drow("oct_mob") = 0 : drow("nov_mob") = 0 : drow("dic_mob") = 0 : drow("ene_mob") = 0
                        Case "jul"
                            drow("ago_mob") = 0 : drow("sep_mob") = 0 : drow("oct_mob") = 0 : drow("nov_mob") = 0 : drow("dic_mob") = 0 : drow("ene_mob") = 0
                        Case "ago"
                            drow("sep_mob") = 0 : drow("oct_mob") = 0 : drow("nov_mob") = 0 : drow("dic_mob") = 0 : drow("ene_mob") = 0
                        Case "sep"
                            drow("oct_mob") = 0 : drow("nov_mob") = 0 : drow("dic_mob") = 0 : drow("ene_mob") = 0
                        Case "oct"
                            drow("nov_mob") = 0 : drow("dic_mob") = 0 : drow("ene_mob") = 0
                        Case "nov"
                            drow("dic_mob") = 0 : drow("ene_mob") = 0
                        Case "dic"
                            drow("ene_mob") = 0
                    End Select

                End If

                ' ---------------------------

                drow("fecha_ini") = fechaini
                drow("fecha_fin") = fechafin
            End If

            ' ---------------------------

            'drow("feb_estatus") = IIf((drow("feb_activo") = 1 And drow("feb_acum") >= drow("feb_obj") And drow("feb_obj") > 0) Or drow("feb_obj") = 1, 1, -1)
            'drow("mar_estatus") = IIf((drow("mar_activo") = 1 And drow("mar_acum") >= drow("mar_obj") And drow("mar_obj") > 0) Or drow("mar_obj") = 1, 1, -1)
            'drow("abr_estatus") = IIf((drow("abr_activo") = 1 And drow("abr_acum") >= drow("abr_obj") And drow("abr_obj") > 0) Or drow("abr_obj") = 1, 1, -1)
            'drow("may_estatus") = IIf((drow("may_activo") = 1 And drow("may_acum") >= drow("may_obj") And drow("may_obj") > 0) Or drow("may_obj") = 1, 1, -1)
            'drow("jun_estatus") = IIf((drow("jun_activo") = 1 And drow("jun_acum") >= drow("jun_obj") And drow("jun_obj") > 0) Or drow("jun_obj") = 1, 1, -1)
            'drow("jul_estatus") = IIf((drow("jul_activo") = 1 And drow("jul_acum") >= drow("jul_obj") And drow("jul_obj") > 0) Or drow("jul_obj") = 1, 1, -1)
            'drow("ago_estatus") = IIf((drow("ago_activo") = 1 And drow("ago_acum") >= drow("ago_obj") And drow("ago_obj") > 0) Or drow("ago_obj") = 1, 1, -1)
            'drow("sep_estatus") = IIf((drow("sep_activo") = 1 And drow("sep_acum") >= drow("sep_obj") And drow("sep_obj") > 0) Or drow("sep_obj") = 1, 1, -1)
            'drow("oct_estatus") = IIf((drow("oct_activo") = 1 And drow("oct_acum") >= drow("oct_obj") And drow("oct_obj") > 0) Or drow("oct_obj") = 1, 1, -1)
            'drow("nov_estatus") = IIf((drow("nov_activo") = 1 And drow("nov_acum") >= drow("nov_obj") And drow("nov_obj") > 0) Or drow("nov_obj") = 1, 1, -1)
            'drow("dic_estatus") = IIf((drow("dic_activo") = 1 And drow("dic_acum") >= drow("dic_obj") And drow("dic_obj") > 0) Or drow("dic_obj") = 1, 1, -1)
            'drow("ene_estatus") = IIf((drow("ene_activo") = 1 And drow("ene_acum") >= drow("ene_obj") And drow("ene_obj") > 0) Or drow("ene_obj") = 1, 1, -1)



            Try
                drow(row("mes_implementacion") & "_ideas") = drow(row("mes_implementacion") & "_ideas") + 1

                drow("estatus_anual") =
                drow("feb_ideas") +
                drow("mar_ideas") +
                drow("abr_ideas") +
                drow("may_ideas") +
                drow("jun_ideas") +
                drow("jul_ideas") +
                drow("ago_ideas") +
                drow("sep_ideas") +
                drow("oct_ideas") +
                drow("nov_ideas") +
                drow("dic_ideas") +
                drow("ene_ideas")


                drow("feb_acum") = drow("feb_ideas")
                drow("mar_acum") = drow("mar_ideas") + drow("feb_ideas")
                drow("abr_acum") = drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("may_acum") = drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("jun_acum") = drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("jul_acum") = drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("ago_acum") = drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("sep_acum") = drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("oct_acum") = drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("nov_acum") = drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("dic_acum") = drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("ene_acum") = drow("ene_ideas") + drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")

            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try

            If Ano + 1 = Date.Now.Year + 1 Then
                Dim objetivoTemp As Integer = 0

                If drow("feb_activo") = 1 Then
                    If drow("feb_obj") > -1 Then

                        objetivoTemp = drow("mar_obj")
                        'If drow("feb_obj") <> drow("mar_obj") Then
                        '    objetivoTemp = drow("mar_obj")
                        'Else
                        '    drow("feb_mob") = 0
                        'End If
                        If drow("feb_obj") = 0 Then
                            drow("feb_estatus") = 1
                        Else
                            If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
                                drow("feb_estatus") = 1
                            Else
                                drow("feb_estatus") = 0
                            End If
                        End If

                    Else
                        drow("feb_mob") = 0
                        drow("feb_estatus") = -2
                    End If
                Else
                    If drow("feb_obj") > -1 Then
                        drow("feb_estatus") = -1
                        'If drow("feb_obj") = drow("mar_obj") Then
                        '    drow("feb_mob") = 0
                        'End If
                    Else
                        drow("feb_mob") = 0
                        drow("feb_estatus") = -2
                    End If
                End If


                If drow("mar_activo") = 1 Then
                    If drow("mar_obj") > -1 Then
                        If drow("mar_obj") <> drow("feb_obj") Then
                            objetivoTemp = drow("mar_obj")
                        Else
                            drow("mar_mob") = 0
                        End If
                        If drow("mar_obj") = 0 Then
                            drow("mar_estatus") = 1
                        Else
                            If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
                                drow("mar_estatus") = 1
                            Else
                                drow("mar_estatus") = 0
                            End If
                        End If

                    Else
                        drow("mar_mob") = 0
                        drow("mar_estatus") = -2
                    End If
                Else
                    If drow("mar_obj") > -1 Then
                        drow("mar_estatus") = -1
                        If drow("mar_obj") = drow("feb_obj") Then
                            drow("mar_mob") = 0
                        End If
                    Else
                        drow("mar_mob") = 0
                        drow("mar_estatus") = -2
                    End If
                End If


                If drow("abr_activo") = 1 Then
                    If drow("abr_obj") > -1 Then
                        If drow("abr_obj") <> drow("mar_obj") Then
                            objetivoTemp = drow("abr_obj")
                        Else
                            drow("abr_mob") = 0
                        End If
                        If drow("abr_obj") = 0 Then
                            drow("abr_estatus") = 1
                        Else
                            If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
                                drow("abr_estatus") = 1
                            Else
                                drow("abr_estatus") = 0
                            End If
                        End If

                    Else
                        drow("abr_mob") = 0
                        drow("abr_estatus") = -2
                    End If
                Else
                    If drow("abr_obj") > -1 Then
                        drow("abr_estatus") = -1
                        If drow("abr_obj") = drow("mar_obj") Then
                            drow("abr_mob") = 0
                        End If
                    Else
                        drow("abr_mob") = 0
                        drow("abr_estatus") = -2
                    End If
                End If


                If drow("may_activo") = 1 Then
                    If drow("may_obj") > -1 Then
                        If drow("may_obj") <> drow("abr_obj") Then
                            objetivoTemp = drow("may_obj")
                        Else
                            drow("may_mob") = 0
                        End If
                        If drow("may_obj") = 0 Then
                            drow("may_estatus") = 1
                        Else
                            If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
                                drow("may_estatus") = 1
                            Else
                                drow("may_estatus") = 0
                            End If
                        End If

                    Else
                        drow("may_mob") = 0
                        drow("may_estatus") = -2
                    End If

                Else
                    If drow("may_obj") > -1 Then
                        drow("may_estatus") = -1
                        If drow("may_obj") = drow("abr_obj") Then
                            drow("may_mob") = 0
                        End If
                    Else
                        drow("may_mob") = 0
                        drow("may_estatus") = -2
                    End If
                End If



                If drow("jun_activo") = 1 Then
                    If drow("jun_obj") > -1 Then
                        If drow("jun_obj") <> drow("may_obj") Then
                            objetivoTemp = drow("jun_obj")
                        Else
                            drow("jun_mob") = 0
                        End If
                        If drow("jun_obj") = 0 Then
                            drow("jun_estatus") = 1
                        Else
                            If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
                                drow("jun_estatus") = 1
                            Else
                                drow("jun_estatus") = 0
                            End If
                        End If

                    Else
                        drow("jun_mob") = 0
                        drow("jun_estatus") = -2
                    End If
                Else
                    If drow("jun_obj") > -1 Then
                        drow("jun_estatus") = -1
                        If drow("jun_obj") = drow("may_obj") Then
                            drow("jun_mob") = 0
                        End If
                    Else
                        drow("jun_mob") = 0
                        drow("jun_estatus") = -2
                    End If
                End If


                If drow("jul_activo") = 1 Then
                    If drow("jul_obj") > -1 Then
                        If drow("jul_obj") <> drow("jun_obj") Then
                            objetivoTemp = drow("jul_obj")
                        Else
                            drow("jul_mob") = 0
                        End If
                        If drow("jul_obj") = 0 Then
                            drow("jul_estatus") = 1
                        Else
                            If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
                                drow("jul_estatus") = 1
                            Else
                                drow("jul_estatus") = 0
                            End If
                        End If

                    Else
                        drow("jul_mob") = 0
                        drow("jul_estatus") = -2
                    End If
                Else
                    If drow("jul_obj") > -1 Then
                        drow("jul_estatus") = -1
                        If drow("jul_obj") = drow("jun_obj") Then
                            drow("jul_mob") = 0
                        End If
                    Else
                        drow("jul_mob") = 0
                        drow("jul_estatus") = -2
                    End If
                End If


                If drow("ago_activo") = 1 Then
                    If drow("ago_obj") > -1 Then
                        If drow("ago_obj") <> drow("jul_obj") Then
                            objetivoTemp = drow("ago_obj")
                        Else
                            drow("ago_mob") = 0

                        End If
                        If drow("ago_obj") = 0 Then
                            drow("ago_estatus") = 1
                        Else
                            If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
                                drow("ago_estatus") = 1
                            Else
                                drow("ago_estatus") = 0
                            End If
                        End If

                    Else
                        drow("ago_mob") = 0
                        drow("ago_estatus") = -2
                    End If
                Else
                    If drow("ago_obj") > -1 Then
                        drow("ago_estatus") = -1
                        If drow("ago_obj") = drow("jul_obj") Then
                            drow("ago_mob") = 0
                        End If
                    Else
                        drow("ago_mob") = 0
                        drow("ago_estatus") = -2
                    End If
                End If


                If drow("sep_activo") = 1 Then
                    If drow("sep_obj") > -1 Then
                        If drow("sep_obj") <> drow("ago_obj") Then
                            objetivoTemp = drow("sep_obj")
                        Else
                            drow("sep_mob") = 0
                        End If
                        If drow("sep_obj") = 0 Then
                            drow("sep_estatus") = 1
                        Else
                            If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
                                drow("sep_estatus") = 1
                            Else
                                drow("sep_estatus") = 0
                            End If
                        End If

                    Else
                        drow("sep_mob") = 0
                        drow("sep_estatus") = -2
                    End If
                Else

                    If drow("sep_obj") > -1 Then
                        drow("sep_estatus") = -1
                        If drow("sep_obj") = drow("ago_obj") Then
                            drow("sep_mob") = 0
                        End If
                    Else
                        drow("sep_mob") = 0
                        drow("sep_estatus") = -2
                    End If
                End If




                If drow("oct_activo") = 1 Then
                    If drow("oct_obj") > -1 Then
                        If drow("oct_obj") <> drow("sep_obj") Then
                            objetivoTemp = drow("oct_obj")
                        Else
                            drow("oct_mob") = 0
                        End If
                        If drow("oct_obj") = 0 Then
                            drow("oct_estatus") = 1
                        Else
                            If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
                                drow("oct_estatus") = 1
                            Else
                                drow("oct_estatus") = 0
                            End If
                        End If

                    Else
                        drow("oct_mob") = 0
                        drow("oct_estatus") = -2
                    End If
                Else
                    If drow("oct_obj") > -1 Then
                        drow("oct_estatus") = -1
                        If drow("oct_obj") = drow("sep_obj") Then
                            drow("oct_mob") = 0
                        End If
                    Else
                        drow("oct_mob") = 0
                        drow("oct_estatus") = -2
                    End If
                End If

                If drow("nov_activo") = 1 Then
                    If drow("nov_obj") > -1 Then
                        If drow("nov_obj") <> drow("oct_obj") Then
                            objetivoTemp = drow("nov_obj")
                        Else
                            drow("nov_mob") = 0
                        End If
                        If drow("nov_obj") = 0 Then
                            drow("nov_estatus") = 1
                        Else
                            If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
                                drow("nov_estatus") = 1
                            Else
                                drow("nov_estatus") = 0
                            End If
                        End If
                    Else
                        drow("nov_mob") = 0
                        drow("nov_estatus") = -2
                    End If
                Else
                    If drow("nov_obj") > -1 Then
                        drow("nov_estatus") = -1
                        If drow("nov_obj") = drow("oct_obj") Then
                            drow("nov_mob") = 0
                        End If
                    Else
                        drow("nov_mob") = 0
                        drow("nov_estatus") = -2
                    End If
                End If

                If drow("dic_activo") = 1 Then
                    If drow("dic_obj") > -1 Then
                        If drow("dic_obj") <> drow("nov_obj") Then
                            objetivoTemp = drow("dic_obj")
                        Else
                            drow("dic_mob") = 0
                        End If
                        If drow("dic_obj") = 0 Then
                            drow("dic_estatus") = 1
                        Else
                            If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
                                drow("dic_estatus") = 1
                            Else
                                drow("dic_estatus") = 0
                            End If
                        End If

                    Else
                        drow("dic_mob") = 0
                        drow("dic_estatus") = -2
                    End If
                Else
                    If drow("dic_obj") > -1 Then
                        drow("dic_estatus") = -1
                        If drow("dic_obj") = drow("nov_obj") Then
                            drow("dic_mob") = 0
                        End If
                    Else
                        drow("dic_mob") = 0
                        drow("dic_estatus") = -2
                    End If
                End If

                If drow("ene_activo") = 1 Then
                    If drow("ene_obj") > -1 Then
                        If drow("ene_obj") <> drow("dic_obj") Then
                            objetivoTemp = drow("ene_obj")
                        Else
                            drow("dic_mob") = 0
                        End If
                        'objetivoTemp = drow("ene_obj")
                        If drow("ene_obj") = 0 Then
                            drow("ene_estatus") = 1
                        Else
                            If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
                                drow("ene_estatus") = 1
                            Else
                                drow("ene_estatus") = 0
                            End If
                        End If
                    Else
                        drow("ene_mob") = 0
                    End If
                Else
                    If drow("ene_obj") > -1 Then
                        drow("ene_estatus") = -1
                        If drow("ene_obj") = drow("dic_obj") Then
                            drow("ene_mob") = 0
                        End If
                    Else
                        drow("ene_estatus") = -2
                    End If
                End If
            Else '========================================================================================================
                Dim objetivoTemp As Integer = 0
                If drow("feb_activo") = 1 Then
                    If drow("feb_obj") > -1 Then
                        If drow("feb_acum") >= drow("feb_obj") Then
                            drow("feb_estatus") = 1
                        Else
                            drow("feb_estatus") = 0
                        End If
                    Else
                        drow("feb_mob") = 0
                        drow("feb_estatus") = -2
                    End If
                Else
                    If drow("feb_obj") > -1 Then
                        drow("feb_estatus") = -1
                    Else
                        drow("feb_mob") = 0
                        drow("feb_estatus") = -2
                    End If
                End If


                If drow("mar_activo") = 1 Then
                    If drow("mar_obj") > -1 Then
                        If drow("mar_acum") >= drow("mar_obj") Then
                            drow("mar_estatus") = 1
                        Else
                            drow("mar_estatus") = 0
                        End If
                    Else
                        drow("mar_mob") = 0
                        drow("mar_estatus") = -2
                    End If
                Else
                    If drow("mar_obj") > -1 Then
                        drow("mar_estatus") = -1
                    Else
                        drow("mar_mob") = 0
                        drow("mar_estatus") = -2
                    End If
                End If


                If drow("abr_activo") = 1 Then
                    If drow("abr_obj") > -1 Then
                        If drow("abr_acum") >= drow("abr_obj") Then
                            drow("abr_estatus") = 1
                        Else
                            drow("abr_estatus") = 0
                        End If
                    Else
                        drow("abr_mob") = 0
                        drow("abr_estatus") = -2
                    End If
                Else
                    If drow("abr_obj") > -1 Then
                        drow("abr_estatus") = -1
                    Else
                        drow("abr_mob") = 0
                        drow("abr_estatus") = -2
                    End If
                End If


                If drow("may_activo") = 1 Then
                    If drow("may_obj") > -1 Then
                        If drow("may_acum") >= drow("may_obj") Then
                            drow("may_estatus") = 1
                        Else
                            drow("may_estatus") = 0
                        End If
                    Else
                        drow("may_mob") = 0
                        drow("may_estatus") = -2
                    End If

                Else
                    If drow("may_obj") > -1 Then
                        drow("may_estatus") = -1
                    Else
                        drow("may_mob") = 0
                        drow("may_estatus") = -2
                    End If
                End If



                If drow("jun_activo") = 1 Then
                    If drow("jun_obj") > -1 Then
                        If drow("jun_acum") >= drow("jun_obj") Then
                            drow("jun_estatus") = 1
                        Else
                            drow("jun_estatus") = 0
                        End If
                    Else
                        drow("jun_mob") = 0
                        drow("jun_estatus") = -2
                    End If
                Else
                    If drow("jun_obj") > -1 Then
                        drow("jun_estatus") = -1
                    Else
                        drow("jun_mob") = 0
                        drow("jun_estatus") = -2
                    End If
                End If


                If drow("jul_activo") = 1 Then
                    If drow("jul_obj") > -1 Then
                        If drow("jul_acum") >= drow("jul_obj") Then
                            drow("jul_estatus") = 1
                        Else
                            drow("jul_estatus") = 0
                        End If
                    Else
                        drow("jul_mob") = 0
                        drow("jul_estatus") = -2
                    End If
                Else
                    If drow("jul_obj") > -1 Then
                        drow("jul_estatus") = -1
                    Else
                        drow("jul_mob") = 0
                        drow("jul_estatus") = -2
                    End If
                End If


                If drow("ago_activo") = 1 Then
                    If drow("ago_obj") > -1 Then
                        If drow("ago_acum") >= drow("ago_obj") Then
                            drow("ago_estatus") = 1
                        Else
                            drow("ago_estatus") = 0
                        End If
                    Else
                        drow("ago_mob") = 0
                        drow("ago_estatus") = -2
                    End If
                Else
                    If drow("ago_obj") > -1 Then
                        drow("ago_estatus") = -1
                    Else
                        drow("ago_mob") = 0
                        drow("ago_estatus") = -2
                    End If
                End If


                If drow("sep_activo") = 1 Then
                    If drow("sep_obj") > -1 Then
                        If drow("sep_acum") >= drow("sep_obj") Then
                            drow("sep_estatus") = 1
                        Else
                            drow("sep_estatus") = 0
                        End If
                    Else
                        drow("sep_mob") = 0
                        drow("sep_estatus") = -2
                    End If
                Else

                    If drow("sep_obj") > -1 Then
                        drow("sep_estatus") = -1
                    Else
                        drow("sep_mob") = 0
                        drow("sep_estatus") = -2
                    End If
                End If




                If drow("oct_activo") = 1 Then
                    If drow("oct_obj") > -1 Then
                        If drow("oct_acum") >= drow("oct_obj") Then
                            drow("oct_estatus") = 1
                        Else
                            drow("oct_estatus") = 0
                        End If
                    Else
                        drow("oct_mob") = 0
                        drow("oct_estatus") = -2
                    End If
                Else
                    If drow("oct_obj") > -1 Then
                        drow("oct_estatus") = -1
                    Else
                        drow("oct_mob") = 0
                        drow("oct_estatus") = -2
                    End If
                End If

                If drow("nov_activo") = 1 Then
                    If drow("nov_obj") > -1 Then
                        If drow("nov_acum") >= drow("nov_obj") Then
                            drow("nov_estatus") = 1
                        Else
                            drow("nov_estatus") = 0
                        End If
                    Else
                        drow("nov_mob") = 0
                        drow("nov_estatus") = -2
                    End If
                Else
                    If drow("nov_obj") > -1 Then
                        drow("nov_estatus") = -1
                    Else
                        drow("nov_mob") = 0
                        drow("nov_estatus") = -2
                    End If
                End If

                If drow("dic_activo") = 1 Then
                    If drow("dic_obj") > -1 Then
                        If drow("dic_acum") >= drow("dic_obj") Then
                            drow("dic_estatus") = 1
                        Else
                            drow("dic_estatus") = 0
                        End If
                    Else
                        drow("dic_mob") = 0
                        drow("dic_estatus") = -2
                    End If
                Else
                    If drow("dic_obj") > -1 Then
                        drow("dic_estatus") = -1
                    Else
                        drow("dic_mob") = 0
                        drow("dic_estatus") = -2
                    End If
                End If

                If drow("ene_activo") = 1 Then
                    If drow("ene_obj") > -1 Then
                        If drow("ene_acum") >= drow("ene_obj") Then
                            drow("ene_estatus") = 1
                        Else
                            drow("ene_estatus") = 0
                        End If
                    Else
                        drow("ene_mob") = 0
                        drow("ene_estatus") = -2
                    End If
                Else
                    If drow("ene_obj") > -1 Then
                        drow("ene_estatus") = -1
                    Else
                        drow("ene_estatus") = -2
                    End If
                End If
            End If



            'drow("feb_estatus") = IIf(drow("feb_activo") = 1 And drow("feb_acum") >= drow("feb_obj") And drow("feb_obj") > 0, 1, -1)
            'drow("mar_estatus") = IIf(drow("mar_activo") = 1 And drow("mar_acum") >= drow("mar_obj") And drow("mar_obj") > 0, 1, -1)
            'drow("abr_estatus") = IIf(drow("abr_activo") = 1 And drow("abr_acum") >= drow("abr_obj") And drow("abr_obj") > 0, 1, -1)
            'drow("may_estatus") = IIf(drow("may_activo") = 1 And drow("may_acum") >= drow("may_obj") And drow("may_obj") > 0, 1, -1)
            'drow("jun_estatus") = IIf(drow("jun_activo") = 1 And drow("jun_acum") >= drow("jun_obj") And drow("jun_obj") > 0, 1, -1)
            'drow("jul_estatus") = IIf(drow("jul_activo") = 1 And drow("jul_acum") >= drow("jul_obj") And drow("jul_obj") > 0, 1, -1)
            'drow("ago_estatus") = IIf(drow("ago_activo") = 1 And drow("ago_acum") >= drow("ago_obj") And drow("ago_obj") > 0, 1, -1)
            'drow("sep_estatus") = IIf(drow("sep_activo") = 1 And drow("sep_acum") >= drow("sep_obj") And drow("sep_obj") > 0, 1, -1)
            'drow("oct_estatus") = IIf(drow("oct_activo") = 1 And drow("oct_acum") >= drow("oct_obj") And drow("oct_obj") > 0, 1, -1)
            'drow("nov_estatus") = IIf(drow("nov_activo") = 1 And drow("nov_acum") >= drow("nov_obj") And drow("nov_obj") > 0, 1, -1)
            'drow("dic_estatus") = IIf(drow("dic_activo") = 1 And drow("dic_acum") >= drow("dic_obj") And drow("dic_obj") > 0, 1, -1)
            'drow("ene_estatus") = IIf(drow("ene_activo") = 1 And drow("ene_acum") >= drow("ene_obj") And drow("ene_obj") > 0, 1, -1)



            'drow("feb_estatus") = IIf((drow("feb_activo") = 1 And drow("feb_acum") >= drow("feb_obj") And drow("feb_obj") > 0) Or drow("feb_obj") = 1, 1, -1)
            'drow("mar_estatus") = IIf((drow("mar_activo") = 1 And drow("mar_acum") >= drow("mar_obj") And drow("mar_obj") > 0) Or drow("mar_obj") = 1, 1, -1)
            'drow("abr_estatus") = IIf((drow("abr_activo") = 1 And drow("abr_acum") >= drow("abr_obj") And drow("abr_obj") > 0) Or drow("abr_obj") = 1, 1, -1)
            'drow("may_estatus") = IIf((drow("may_activo") = 1 And drow("may_acum") >= drow("may_obj") And drow("may_obj") > 0) Or drow("may_obj") = 1, 1, -1)
            'drow("jun_estatus") = IIf((drow("jun_activo") = 1 And drow("jun_acum") >= drow("jun_obj") And drow("jun_obj") > 0) Or drow("jun_obj") = 1, 1, -1)
            'drow("jul_estatus") = IIf((drow("jul_activo") = 1 And drow("jul_acum") >= drow("jul_obj") And drow("jul_obj") > 0) Or drow("jul_obj") = 1, 1, -1)
            'drow("ago_estatus") = IIf((drow("ago_activo") = 1 And drow("ago_acum") >= drow("ago_obj") And drow("ago_obj") > 0) Or drow("ago_obj") = 1, 1, -1)
            'drow("sep_estatus") = IIf((drow("sep_activo") = 1 And drow("sep_acum") >= drow("sep_obj") And drow("sep_obj") > 0) Or drow("sep_obj") = 1, 1, -1)
            'drow("oct_estatus") = IIf((drow("oct_activo") = 1 And drow("oct_acum") >= drow("oct_obj") And drow("oct_obj") > 0) Or drow("oct_obj") = 1, 1, -1)
            'drow("nov_estatus") = IIf((drow("nov_activo") = 1 And drow("nov_acum") >= drow("nov_obj") And drow("nov_obj") > 0) Or drow("nov_obj") = 1, 1, -1)
            'drow("dic_estatus") = IIf((drow("dic_activo") = 1 And drow("dic_acum") >= drow("dic_obj") And drow("dic_obj") > 0) Or drow("dic_obj") = 1, 1, -1)
            'drow("ene_estatus") = IIf((drow("ene_activo") = 1 And drow("ene_acum") >= drow("ene_obj") And drow("ene_obj") > 0) Or drow("ene_obj") = 1, 1, -1)



            'drow("feb_estatus") = IIf((drow("feb_activo") = 1 And drow("feb_acum") >= drow("feb_obj") And drow("feb_obj") > 0) Or drow("feb_obj") = 1, 1, -1)
            'drow("mar_estatus") = IIf((drow("mar_activo") = 1 And drow("mar_acum") >= drow("mar_obj") And drow("mar_obj") > 0) Or drow("mar_obj") = 1, 1, -1)
            'drow("abr_estatus") = IIf((drow("abr_activo") = 1 And drow("abr_acum") >= drow("abr_obj") And drow("abr_obj") > 0) Or drow("abr_obj") = 1, 1, -1)
            'drow("may_estatus") = IIf((drow("may_activo") = 1 And drow("may_acum") >= drow("may_obj") And drow("may_obj") > 0) Or drow("may_obj") = 1, 1, -1)
            'drow("jun_estatus") = IIf((drow("jun_activo") = 1 And drow("jun_acum") >= drow("jun_obj") And drow("jun_obj") > 0) Or drow("jun_obj") = 1, 1, -1)
            'drow("jul_estatus") = IIf((drow("jul_activo") = 1 And drow("jul_acum") >= drow("jul_obj") And drow("jul_obj") > 0) Or drow("jul_obj") = 1, 1, -1)
            'drow("ago_estatus") = IIf((drow("ago_activo") = 1 And drow("ago_acum") >= drow("ago_obj") And drow("ago_obj") > 0) Or drow("ago_obj") = 1, 1, -1)
            'drow("sep_estatus") = IIf((drow("sep_activo") = 1 And drow("sep_acum") >= drow("sep_obj") And drow("sep_obj") > 0) Or drow("sep_obj") = 1, 1, -1)
            'drow("oct_estatus") = IIf((drow("oct_activo") = 1 And drow("oct_acum") >= drow("oct_obj") And drow("oct_obj") > 0) Or drow("oct_obj") = 1, 1, -1)
            'drow("nov_estatus") = IIf((drow("nov_activo") = 1 And drow("nov_acum") >= drow("nov_obj") And drow("nov_obj") > 0) Or drow("nov_obj") = 1, 1, -1)
            'drow("dic_estatus") = IIf((drow("dic_activo") = 1 And drow("dic_acum") >= drow("dic_obj") And drow("dic_obj") > 0) Or drow("dic_obj") = 1, 1, -1)
            'drow("ene_estatus") = IIf((drow("ene_activo") = 1 And drow("ene_acum") >= drow("ene_obj") And drow("ene_obj") > 0) Or drow("ene_obj") = 1, 1, -1)



        Catch ex As Exception
            Debug.Print(ex.Message)

        End Try
    End Sub




    Public Sub ParticipacionIndividualIdeas(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, Optional planta_obj As String = "")

          ' ya nadamas hay que poner esto en donde decidas que no se quiere generar el reporte, en el catch de la excepcion o en algun IF o asi
        'MensajeError = "Ocurrió un error al generar el reporte de participacion individual"
        'MostrarReporte = False
        Try
            Dim FechaIni As Date
            Dim FechaFin As Date
            Dim ano As Integer

            Dim objetivo_anual = 8

            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_super", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_depto", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_area", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_area", Type.GetType("System.String"))

            dtDatos.Columns.Add("feb_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("mar_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("abr_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("may_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jun_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jul_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ago_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("sep_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("oct_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("nov_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("dic_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ene_ideas", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("meses", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("objetivo_anual", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("estatus_anual", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("feb_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("mar_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("abr_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("may_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jun_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jul_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ago_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("sep_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("oct_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("nov_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("dic_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ene_obj", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("feb_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("mar_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("abr_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("may_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jun_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jul_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ago_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("sep_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("oct_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("nov_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("dic_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ene_estatus", Type.GetType("System.Int32"))


            dtDatos.Columns.Add("feb_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("mar_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("abr_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("may_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jun_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jul_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ago_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("sep_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("oct_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("nov_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("dic_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ene_acum", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("feb_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("mar_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("abr_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("may_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jun_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jul_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ago_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("sep_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("oct_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("nov_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("dic_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ene_activo", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("feb_mob", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("mar_mob", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("abr_mob", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("may_mob", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jun_mob", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jul_mob", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ago_mob", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("sep_mob", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("oct_mob", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("nov_mob", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("dic_mob", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ene_mob", Type.GetType("System.Int32"))


            dtDatos.Columns.Add("alta_personal", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("baja", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("transferencia", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("reloj_anterior", Type.GetType("System.String"))

            dtDatos.Columns.Add("alta_ideas", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("mes_inicio", Type.GetType("System.String"))

            dtDatos.Columns.Add("fecha_ini", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("fecha_fin", Type.GetType("System.DateTime"))

            dtDatos.Columns.Add("anofiscal", Type.GetType("System.Int32"))
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj")}



            Dim relojexclu As String = ""
            Dim dtreloj_exclu As New DataTable
            dtreloj_exclu = sqlExecute("select * from reloj_exclu", "IDEAS")

            For Each dRe As DataRow In dtreloj_exclu.Rows

                relojexclu = relojexclu & dRe("reloj") & ","
            Next

            relojexclu = relojexclu.Remove(relojexclu.Length - 1)


            ano = Year(FechaFinal)
            For Each dRow As DataRow In dtInformacion.Rows
                If Not IsDBNull(dRow("fecha")) Then
                    If Month(dtInformacion.Rows(0).Item("fecha")) = 1 Then
                        ano = Year(dtInformacion.Rows(0).Item("fecha")) - 1
                    Else
                        ano = Year(dtInformacion.Rows(0).Item("fecha"))
                    End If
                    Exit For
                Else
                    If Month(FechaFinal) = 1 Then
                        ano = Year(FechaFinal) - 1
                    Else
                        ano = Year(FechaFinal)
                    End If
                    Exit For
                End If
            Next


            Dim dtperiodos As DataTable
            dtperiodos = sqlExecute("select * from periodos where periodo_especial = 0 and ano = '" & ano & "' and num_mes = '02' order by periodo asc", "ta")
            If dtperiodos.Rows.Count > 0 Then

                Dim TempFinal As String
                Dim TempFecha As String

                TempFinal = FechaSQL(FechaFinal).ToString.Substring(5, 5)
                TempFecha = FechaSQL(FechaInicial).ToString.Substring(5, 5)
                If TempFecha <> "02-01" Or TempFinal <> "01-31" Then
                    MensajeError = "Es necesario cargar el año fiscal"
                    MostrarReporte = False
                    Exit Sub
                End If
            End If

            dtperiodos = sqlExecute("select * from periodos where periodo_especial = 0 and ano = '" & ano + 1 & "' and num_mes = '01' order by periodo desc", "ta")
            If dtperiodos.Rows.Count > 0 Then
                FechaFin = dtperiodos.Rows(0)("fecha_fin")
            End If


            Dim dtMesesTranscurridos As DataTable = sqlExecute("select distinct(lower(substring(mes, 1, 3))) as mes, ano, num_mes from periodos where periodo_especial = 0 and ((ano = '" & ano & "' and num_mes >= '02') or (ano = '" & ano + 1 & "' and num_mes = '01')) and fecha_fin < '" & FechaSQL(Now) & "' and fecha_ini > '" & ano & "-01-01'  GROUP BY ano, mes, num_mes order by ano asc, num_mes asc", "ta")

            Dim dtIdeas As DataTable = dtInformacion.Select("reloj not in(" & relojexclu & ")", "reloj").CopyToDataTable
            Dim dtIdeasTransferencia As DataTable = dtIdeas.Clone

            For Each row As DataRow In dtIdeas.Rows
                AuxiliarIdeas(row, dtDatos, True, dtMesesTranscurridos, FechaInicial, FechaFinal, ano, dtIdeasTransferencia, planta_obj)
            Next

            For Each row As DataRow In dtIdeasTransferencia.Rows
                AuxiliarIdeas(row, dtDatos, False, dtMesesTranscurridos, FechaInicial, FechaFinal, ano, dtIdeasTransferencia, planta_obj)
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try

    End Sub
    Public Sub ParticipacionIdeas(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Dim FechaIni As Date
        Dim FechaFin As Date
        Dim ano As Integer

        Dim objetivo_anual = 8

        dtDatos = New DataTable
        dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

        dtDatos.Columns.Add("cod_super", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))

        dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_depto", Type.GetType("System.String"))

        dtDatos.Columns.Add("feb_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_ideas", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("meses", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("objetivo_anual", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("estatus_anual", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("feb_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_obj", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("feb_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_estatus", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("feb_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_acum", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("feb_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_activo", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("alta_personal", Type.GetType("System.DateTime"))

        dtDatos.Columns.Add("transferencia", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("reloj_anterior", Type.GetType("System.String"))

        dtDatos.Columns.Add("alta_ideas", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("mes_inicio", Type.GetType("System.String"))

        dtDatos.Columns.Add("fecha_ini", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("fecha_fin", Type.GetType("System.DateTime"))

        dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj")}


        ano = Year(FechaFinal)
        For Each dRow As DataRow In dtInformacion.Rows
            If Not IsDBNull(dRow("fecha")) Then
                If Month(dtInformacion.Rows(0).Item("fecha")) = 1 Then
                    ano = Year(dtInformacion.Rows(0).Item("fecha")) - 1
                Else
                    ano = Year(dtInformacion.Rows(0).Item("fecha"))
                End If
                Exit For
            Else
                If Month(FechaFinal) = 1 Then
                    ano = Year(FechaFinal) - 1
                Else
                    ano = Year(FechaFinal)
                End If
                Exit For
            End If
        Next

        Dim dtperiodos As DataTable
        dtperiodos = sqlExecute("select * from periodos where periodo_especial = 0 and ano = '" & ano & "' and num_mes = '02' order by periodo asc", "ta")
        If dtperiodos.Rows.Count > 0 Then
            FechaIni = dtperiodos.Rows(0)("fecha_ini")
        End If

        dtperiodos = sqlExecute("select * from periodos where periodo_especial = 0 and ano = '" & ano + 1 & "' and num_mes = '01' order by periodo desc", "ta")
        If dtperiodos.Rows.Count > 0 Then
            FechaFin = dtperiodos.Rows(0)("fecha_fin")
        End If


        Dim dtMesesTranscurridos As DataTable = sqlExecute("select distinct(lower(substring(mes, 1, 3))) as mes, ano, num_mes from periodos where periodo_especial = 0 and ((ano = '" & ano & "' and num_mes >= '02') or (ano = '" & ano + 1 & "' and num_mes = '01')) and fecha_fin < '" & FechaSQL(Now) & "' GROUP BY ano, mes, num_mes order by ano asc, num_mes asc", "ta")

        Dim dtIdeas As DataTable = dtInformacion.Select("", "reloj").CopyToDataTable
        Dim dtIdeasTransferencia As DataTable = dtIdeas.Clone

        For Each row As DataRow In dtIdeas.Rows
            AuxiliarIdeas(row, dtDatos, True, dtMesesTranscurridos, FechaIni, FechaFin, ano, dtIdeasTransferencia)
        Next

        For Each row As DataRow In dtIdeasTransferencia.Rows
            AuxiliarIdeas(row, dtDatos, False, dtMesesTranscurridos, FechaIni, FechaFin, ano, dtIdeasTransferencia)
        Next




    End Sub
    Private Sub AuxiliarIdeas(row As DataRow, ByRef DtDatos As DataTable, transferencias As Boolean, dtMesesTranscurridos As DataTable, fechaini As Date, fechafin As Date, Ano As Int32, ByRef dtIdeasTransferencia As DataTable, Optional planta_obj As String = "001")
        Try
            Dim RelojObjetivos As String = ""
            Dim drow As DataRow = DtDatos.Rows.Find(row("reloj"))
            Dim AltaIdeas As Date = Now
            Dim BajaIdeas As Date = Now
            Dim MesFin As Integer = 0
            Dim MesFinal As String = ""
            If drow Is Nothing Then
                drow = DtDatos.NewRow
                RelojObjetivos = row("reloj")
                drow("reloj") = row("reloj")
                drow("anofiscal") = Ano
                DtDatos.Rows.Add(drow)

                drow("nombres") = RTrim(row("nombres"))

                drow("cod_super") = row("cod_super_actual")
                drow("cod_depto") = row("cod_depto_actual")
                drow("cod_area") = row("cod_area_actual")

                drow("nombre_super") = row("nombre_super_actual")
                drow("nombre_depto") = row("nombre_depto_actual")
                drow("nombre_area") = row("nombre_area_actual")

                drow("feb_ideas") = 0
                drow("mar_ideas") = 0
                drow("abr_ideas") = 0
                drow("may_ideas") = 0
                drow("jun_ideas") = 0
                drow("jul_ideas") = 0
                drow("ago_ideas") = 0
                drow("sep_ideas") = 0
                drow("oct_ideas") = 0
                drow("nov_ideas") = 0
                drow("dic_ideas") = 0
                drow("ene_ideas") = 0

                drow("estatus_anual") = 0

                drow("feb_obj") = 0
                drow("mar_obj") = 0
                drow("abr_obj") = 0
                drow("may_obj") = 0
                drow("jun_obj") = 0
                drow("jul_obj") = 0
                drow("ago_obj") = 0
                drow("sep_obj") = 0
                drow("oct_obj") = 0
                drow("nov_obj") = 0
                drow("dic_obj") = 0
                drow("ene_obj") = 0

                drow("feb_acum") = drow("feb_ideas")
                drow("mar_acum") = drow("mar_ideas") + drow("feb_ideas")
                drow("abr_acum") = drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("may_acum") = drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("jun_acum") = drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("jul_acum") = drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("ago_acum") = drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("sep_acum") = drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("oct_acum") = drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("nov_acum") = drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("dic_acum") = drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("ene_acum") = drow("ene_ideas") + drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")

                drow("feb_estatus") = -1
                drow("mar_estatus") = -1
                drow("abr_estatus") = -1
                drow("may_estatus") = -1
                drow("jun_estatus") = -1
                drow("jul_estatus") = -1
                drow("ago_estatus") = -1
                drow("sep_estatus") = -1
                drow("oct_estatus") = -1
                drow("nov_estatus") = -1
                drow("dic_estatus") = -1
                drow("ene_estatus") = -1


                drow("feb_activo") = -1
                drow("mar_activo") = -1
                drow("abr_activo") = -1
                drow("may_activo") = -1
                drow("jun_activo") = -1
                drow("jul_activo") = -1
                drow("ago_activo") = -1
                drow("sep_activo") = -1
                drow("oct_activo") = -1
                drow("nov_activo") = -1
                drow("dic_activo") = -1
                drow("ene_activo") = -1


                drow("feb_mob") = 1
                drow("mar_mob") = 1
                drow("abr_mob") = 1
                drow("may_mob") = 1
                drow("jun_mob") = 1
                drow("jul_mob") = 1
                drow("ago_mob") = 1
                drow("sep_mob") = 1
                drow("oct_mob") = 1
                drow("nov_mob") = 1
                drow("dic_mob") = 1
                drow("ene_mob") = 1
                drow("objetivo_anual") = 0

                For Each mes As DataRow In dtMesesTranscurridos.Rows
                    drow(mes("mes") & "_activo") = 1
                Next

                ' ---------------------------
                drow("baja") = row("baja")
                drow("alta_personal") = row("alta")
                drow("alta_ideas") = row("alta")

                drow("transferencia") = 0
                drow("reloj_anterior") = ""

                If transferencias Then
                    Dim dt_transferencia As DataTable = sqlExecute("select * from transferencias where reloj_nuevo = '" & row("reloj") & "' and alta > alta_anterior")
                    If dt_transferencia.Rows.Count > 0 Then
                        'If Date.Parse(dt_transferencia.Rows(0)("alta_anterior")) > FechaIni Then
                        drow("transferencia") = 1
                        drow("reloj_anterior") = dt_transferencia.Rows(0)("reloj_anterior")
                        drow("alta_ideas") = Date.Parse(dt_transferencia.Rows(0)("alta_anterior"))
                        'End If
                        Dim dtReingreso As DataTable = sqlExecute("select top 1 * from reingresos where reloj =  '" & row("reloj") & "' and alta > '" + FechaSQL(drow("alta_ideas")) + "' order by alta desc")
                        If dtReingreso.Rows.Count > 0 Then
                            drow("alta_ideas") = IIf(IsDBNull(dtReingreso.Rows(0).Item("alta")), drow("alta_ideas"), dtReingreso.Rows(0).Item("alta"))
                        End If

                        Try
                            Dim dtIdeasAgencia As DataTable = sqlExecute("SELECT ideasVW.*,cias.nombre AS COMPANIA,deptos.nombre AS NOMBRE_DEPTO,SUPER.NOMBRE AS NOMBRE_SUPER," & _
                                                                   "AREAS.NOMBRE AS NOMBRE_AREA,puestos.nombre as 'nombre_puesto' FROM IDEASVW " & _
                                                                   "LEFT JOIN personal.dbo.cias ON ideasVW.cod_comp = cias.cod_comp " & _
                                                                   "LEFT JOIN personal.dbo.deptos ON ideasVW.cod_comp = deptos.cod_comp AND ideasVW.cod_depto = deptos.cod_depto " & _
                                                                   "LEFT JOIN personal.dbo.super ON ideasVW.cod_comp = super.cod_comp AND ideasVW.cod_super = super.cod_super " & _
                                                                   "LEFT JOIN personal.dbo.puestos ON ideasVW.cod_comp = puestos.cod_comp AND ideasVW.cod_puesto = puestos.cod_puesto " & _
                                                                   "LEFT JOIN personal.dbo.areas ON ideasVW.cod_comp = areas.cod_comp AND ideasVW.cod_area = areas.cod_area " & _
                                                                   "WHERE fecha BETWEEN '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "' and ideasvw.reloj = '" & dt_transferencia.Rows(0)("reloj_anterior") & "'", "IDEAS")

                            For Each row_agencia As DataRow In dtIdeasAgencia.Rows
                                row_agencia("reloj") = row("reloj")
                                dtIdeasTransferencia.ImportRow(row_agencia)
                            Next

                        Catch ex As Exception

                        End Try


                    End If
                End If
                Dim dtObjetivos As DataTable = sqlExecute("select  * from tabulacion_objetivos where ano = '" + (Ano + 1).ToString + "' and reloj='" + RelojObjetivos + "' and planta = '001'", "IDEAS")
                If Not dtObjetivos.Rows.Count > 0 Then
                    dtObjetivos = sqlExecute("select  * from tabulacion_objetivos where ano = '" + (Ano + 1).ToString + "' and reloj is null and planta = '001'", "IDEAS")
                End If

                If Date.Parse(drow("alta_ideas")) < fechaini Then
                    drow("mes_inicio") = "feb"
                    drow("meses") = 12
                    drow("objetivo_anual") = dtObjetivos.Rows(0).Item("ene")
                Else
                    Dim mes_inicio As Integer = Date.Parse(drow("alta_ideas")).Month
                    Dim dias As Integer = Date.Parse(Ano + 1.ToString & "-01-31").Subtract(Date.Parse(drow("alta_ideas"))).Days
                    ' Dim dias As Integer = Date.Parse(Ano).Subtract(Date.Par se(drow("alta_ideas"))).Days
                    'Seleccion de mes en base a la cantidad de ideas que el empleado tiene activo en el año fiscal
                    If dias <= 60 Then
                        drow("mes_inicio") = "ene"
                        drow("meses") = 0
                        drow("objetivo_anual") = 0
                    ElseIf dias > 60 And dias <= 120 Then
                        drow("mes_inicio") = "oct"
                        drow("meses") = 3
                        drow("objetivo_anual") = 1
                    ElseIf dias > 120 And dias <= 211 Then
                        drow("mes_inicio") = "jul"
                        drow("meses") = 6
                        drow("objetivo_anual") = 2
                    ElseIf dias > 211 And dias <= 302 Then
                        drow("mes_inicio") = "abr"
                        drow("meses") = 9
                        drow("objetivo_anual") = 3
                    ElseIf dias > 302 Then
                        drow("mes_inicio") = "feb"
                        drow("meses") = 12
                        drow("objetivo_anual") = 4
                    End If


                    'Select Case mes_inicio
                    '    Case 2
                    '        '   drow("mes_inicio") = "feb"
                    '        drow("meses") = 12
                    '        'drow("objetivo_anual") = 8
                    '        drow("objetivo_anual") = 4
                    '    Case 3
                    '        '   drow("mes_inicio") = "mar"
                    '        drow("meses") = 12
                    '        'drow("objetivo_anual") = 7
                    '        drow("objetivo_anual") = 4
                    '    Case 4
                    '        '    drow("mes_inicio") = "abr"
                    '        drow("meses") = 9
                    '        'drow("objetivo_anual") = 7
                    '        drow("objetivo_anual") = 3
                    '    Case 5
                    '        '    drow("mes_inicio") = "may"
                    '        drow("meses") = 9
                    '        'drow("objetivo_anual") = 6
                    '        drow("objetivo_anual") = 3
                    '    Case 6
                    '        '   drow("mes_inicio") = "jun"
                    '        drow("meses") = 9
                    '        'drow("objetivo_anual") = 5
                    '        drow("objetivo_anual") = 3
                    '    Case 7
                    '        '  drow("mes_inicio") = "jul"
                    '        drow("meses") = 6
                    '        'drow("objetivo_anual") = 5
                    '        drow("objetivo_anual") = 2
                    '    Case 8
                    '        '   drow("mes_inicio") = "ago"
                    '        drow("meses") = 6
                    '        'drow("objetivo_anual") = 4
                    '        drow("objetivo_anual") = 2
                    '    Case 9
                    '        '   drow("mes_inicio") = "sep"
                    '        drow("meses") = 6
                    '        'drow("objetivo_anual") = 3
                    '        drow("objetivo_anual") = 2
                    '    Case 10
                    '        '   drow("mes_inicio") = "oct"
                    '        drow("meses") = 3
                    '        'drow("objetivo_anual") = 3
                    '        drow("objetivo_anual") = 1
                    '    Case 11
                    '        '   drow("mes_inicio") = "nov"
                    '        drow("meses") = 3
                    '        'drow("objetivo_anual") = 2
                    '        drow("objetivo_anual") = 1
                    '    Case 12
                    '        '   drow("mes_inicio") = "dic"
                    '        drow("meses") = 3
                    '        'drow("objetivo_anual") = 1
                    '        drow("objetivo_anual") = 1
                    'End Select
                End If

                ' ---------------------------
                Dim prueba1 = drow("alta_ideas")
                Dim Minicio As Integer = Date.Parse(drow("alta_ideas")).Month
                Dim Ainicio As Integer = Date.Parse(drow("alta_ideas")).Year


                If Minicio >= 2 Or Minicio = 1 Then
                    Select Case drow("mes_inicio").ToString
                        Case "feb"
                            drow("feb_obj") = dtObjetivos.Rows(0).Item("feb")
                            drow("mar_obj") = dtObjetivos.Rows(0).Item("mar")
                            drow("abr_obj") = dtObjetivos.Rows(0).Item("abr")
                            drow("may_obj") = dtObjetivos.Rows(0).Item("may")
                            drow("jun_obj") = dtObjetivos.Rows(0).Item("jun")
                            drow("jul_obj") = dtObjetivos.Rows(0).Item("jul")
                            drow("ago_obj") = dtObjetivos.Rows(0).Item("ago")
                            drow("sep_obj") = dtObjetivos.Rows(0).Item("sep")
                            drow("oct_obj") = dtObjetivos.Rows(0).Item("oct")
                            drow("nov_obj") = dtObjetivos.Rows(0).Item("nov")
                            drow("dic_obj") = dtObjetivos.Rows(0).Item("dic")
                            drow("ene_obj") = dtObjetivos.Rows(0).Item("ene")
                        Case "mar"
                            drow("feb_obj") = -1
                            drow("mar_obj") = -1
                            drow("abr_obj") = dtObjetivos.Rows(0).Item("feb")
                            drow("may_obj") = dtObjetivos.Rows(0).Item("mar")
                            drow("jun_obj") = dtObjetivos.Rows(0).Item("abr")
                            drow("jul_obj") = dtObjetivos.Rows(0).Item("may")
                            drow("ago_obj") = dtObjetivos.Rows(0).Item("jun")
                            drow("sep_obj") = dtObjetivos.Rows(0).Item("jul")
                            drow("oct_obj") = dtObjetivos.Rows(0).Item("ago")
                            drow("nov_obj") = dtObjetivos.Rows(0).Item("sep")
                            drow("dic_obj") = dtObjetivos.Rows(0).Item("oct")
                            drow("ene_obj") = dtObjetivos.Rows(0).Item("nov")
                        Case "abr"
                            drow("feb_obj") = -1
                            drow("mar_obj") = -1
                            drow("abr_obj") = -1
                            drow("may_obj") = dtObjetivos.Rows(0).Item("feb")
                            drow("jun_obj") = dtObjetivos.Rows(0).Item("mar")
                            drow("jul_obj") = dtObjetivos.Rows(0).Item("abr")
                            drow("ago_obj") = dtObjetivos.Rows(0).Item("may")
                            drow("sep_obj") = dtObjetivos.Rows(0).Item("jun")
                            drow("oct_obj") = dtObjetivos.Rows(0).Item("jul")
                            drow("nov_obj") = dtObjetivos.Rows(0).Item("ago")
                            drow("dic_obj") = dtObjetivos.Rows(0).Item("sep")
                            drow("ene_obj") = dtObjetivos.Rows(0).Item("oct")
                        Case "may"
                            drow("feb_obj") = -1
                            drow("mar_obj") = -1
                            drow("abr_obj") = -1
                            drow("may_obj") = -1
                            drow("jun_obj") = dtObjetivos.Rows(0).Item("feb")
                            drow("jul_obj") = dtObjetivos.Rows(0).Item("mar")
                            drow("ago_obj") = dtObjetivos.Rows(0).Item("abr")
                            drow("sep_obj") = dtObjetivos.Rows(0).Item("may")
                            drow("oct_obj") = dtObjetivos.Rows(0).Item("jun")
                            drow("nov_obj") = dtObjetivos.Rows(0).Item("jul")
                            drow("dic_obj") = dtObjetivos.Rows(0).Item("ago")
                            drow("ene_obj") = dtObjetivos.Rows(0).Item("sep")
                        Case "jun"
                            drow("feb_obj") = -1
                            drow("mar_obj") = -1
                            drow("abr_obj") = -1
                            drow("may_obj") = -1
                            drow("jun_obj") = -1
                            drow("jul_obj") = dtObjetivos.Rows(0).Item("feb")
                            drow("ago_obj") = dtObjetivos.Rows(0).Item("mar")
                            drow("sep_obj") = dtObjetivos.Rows(0).Item("abr")
                            drow("oct_obj") = dtObjetivos.Rows(0).Item("may")
                            drow("nov_obj") = dtObjetivos.Rows(0).Item("jun")
                            drow("dic_obj") = dtObjetivos.Rows(0).Item("jul")
                            drow("ene_obj") = dtObjetivos.Rows(0).Item("ago")
                        Case "jul"
                            drow("feb_obj") = -1
                            drow("mar_obj") = -1
                            drow("abr_obj") = -1
                            drow("may_obj") = -1
                            drow("jun_obj") = -1
                            drow("jul_obj") = -1
                            drow("ago_obj") = dtObjetivos.Rows(0).Item("feb")
                            drow("sep_obj") = dtObjetivos.Rows(0).Item("mar")
                            drow("oct_obj") = dtObjetivos.Rows(0).Item("abr")
                            drow("nov_obj") = dtObjetivos.Rows(0).Item("may")
                            drow("dic_obj") = dtObjetivos.Rows(0).Item("jun")
                            drow("ene_obj") = dtObjetivos.Rows(0).Item("jul")
                        Case "ago"
                            drow("feb_obj") = -1
                            drow("mar_obj") = -1
                            drow("abr_obj") = -1
                            drow("may_obj") = -1
                            drow("jun_obj") = -1
                            drow("jul_obj") = -1
                            drow("ago_obj") = -1
                            drow("sep_obj") = dtObjetivos.Rows(0).Item("feb")
                            drow("oct_obj") = dtObjetivos.Rows(0).Item("mar")
                            drow("nov_obj") = dtObjetivos.Rows(0).Item("abr")
                            drow("dic_obj") = dtObjetivos.Rows(0).Item("may")
                            drow("ene_obj") = dtObjetivos.Rows(0).Item("jun")
                        Case "sep"
                            drow("feb_obj") = -1
                            drow("mar_obj") = -1
                            drow("abr_obj") = -1
                            drow("may_obj") = -1
                            drow("jun_obj") = -1
                            drow("jul_obj") = -1
                            drow("ago_obj") = -1
                            drow("sep_obj") = -1
                            drow("oct_obj") = dtObjetivos.Rows(0).Item("feb")
                            drow("nov_obj") = dtObjetivos.Rows(0).Item("mar")
                            drow("dic_obj") = dtObjetivos.Rows(0).Item("abr")
                            drow("ene_obj") = dtObjetivos.Rows(0).Item("may")
                        Case "oct"
                            drow("feb_obj") = -1
                            drow("mar_obj") = -1
                            drow("abr_obj") = -1
                            drow("may_obj") = -1
                            drow("jun_obj") = -1
                            drow("jul_obj") = -1
                            drow("ago_obj") = -1
                            drow("sep_obj") = -1
                            drow("oct_obj") = -1
                            drow("nov_obj") = dtObjetivos.Rows(0).Item("feb")
                            drow("dic_obj") = dtObjetivos.Rows(0).Item("mar")
                            drow("ene_obj") = dtObjetivos.Rows(0).Item("abr")
                        Case "nov"
                            drow("feb_obj") = -1
                            drow("mar_obj") = -1
                            drow("abr_obj") = -1
                            drow("may_obj") = -1
                            drow("jun_obj") = -1
                            drow("jul_obj") = -1
                            drow("ago_obj") = -1
                            drow("sep_obj") = -1
                            drow("oct_obj") = -1
                            drow("nov_obj") = -1
                            drow("dic_obj") = dtObjetivos.Rows(0).Item("feb")
                            drow("ene_obj") = dtObjetivos.Rows(0).Item("mar")
                        Case "dic"
                            drow("feb_obj") = -1
                            drow("mar_obj") = -1
                            drow("abr_obj") = -1
                            drow("may_obj") = -1
                            drow("jun_obj") = -1
                            drow("jul_obj") = -1
                            drow("ago_obj") = -1
                            drow("sep_obj") = -1
                            drow("oct_obj") = -1
                            drow("nov_obj") = -1
                            drow("dic_obj") = -1
                            drow("ene_obj") = dtObjetivos.Rows(0).Item("feb")
                        Case "ene"
                            drow("feb_obj") = -1
                            drow("mar_obj") = -1
                            drow("abr_obj") = -1
                            drow("may_obj") = -1
                            drow("jun_obj") = -1
                            drow("jul_obj") = -1
                            drow("ago_obj") = -1
                            drow("sep_obj") = -1
                            drow("oct_obj") = -1
                            drow("nov_obj") = -1
                            drow("dic_obj") = -1
                            drow("ene_obj") = -1
                    End Select


                Else
                    drow("feb_obj") = dtObjetivos.Rows(0).Item("feb")
                    drow("mar_obj") = dtObjetivos.Rows(0).Item("mar")
                    drow("abr_obj") = dtObjetivos.Rows(0).Item("abr")
                    drow("may_obj") = dtObjetivos.Rows(0).Item("may")
                    drow("jun_obj") = dtObjetivos.Rows(0).Item("jun")
                    drow("jul_obj") = dtObjetivos.Rows(0).Item("jul")
                    drow("ago_obj") = dtObjetivos.Rows(0).Item("ago")
                    drow("sep_obj") = dtObjetivos.Rows(0).Item("sep")
                    drow("oct_obj") = dtObjetivos.Rows(0).Item("oct")
                    drow("nov_obj") = dtObjetivos.Rows(0).Item("nov")
                    drow("dic_obj") = dtObjetivos.Rows(0).Item("dic")
                    drow("ene_obj") = dtObjetivos.Rows(0).Item("ene")

                End If

                Dim mes_actual As Integer = 0
                If Date.Now > Date.Parse(Ano + 1 & "-01-31") Then
                    mes_actual = 1
                Else
                    mes_actual = Date.Parse(Date.Now).Month
                End If

                Select Case mes_actual
                    Case 2
                        drow("feb_activo") = 1
                        drow("mar_activo") = 0
                        drow("abr_activo") = 0
                        drow("may_activo") = 0
                        drow("jun_activo") = 0
                        drow("jul_activo") = 0
                        drow("ago_activo") = 0
                        drow("sep_activo") = 0
                        drow("oct_activo") = 0
                        drow("nov_activo") = 0
                        drow("dic_activo") = 0
                        drow("ene_activo") = 0
                    Case 3
                        drow("feb_activo") = 1
                        drow("mar_activo") = 1
                        drow("abr_activo") = 0
                        drow("may_activo") = 0
                        drow("jun_activo") = 0
                        drow("jul_activo") = 0
                        drow("ago_activo") = 0
                        drow("sep_activo") = 0
                        drow("oct_activo") = 0
                        drow("nov_activo") = 0
                        drow("dic_activo") = 0
                        drow("ene_activo") = 0
                    Case 4
                        drow("feb_activo") = 1
                        drow("mar_activo") = 1
                        drow("abr_activo") = 1
                        drow("may_activo") = 0
                        drow("jun_activo") = 0
                        drow("jul_activo") = 0
                        drow("ago_activo") = 0
                        drow("sep_activo") = 0
                        drow("oct_activo") = 0
                        drow("nov_activo") = 0
                        drow("dic_activo") = 0
                        drow("ene_activo") = 0
                    Case 5
                        drow("feb_activo") = 1
                        drow("mar_activo") = 1
                        drow("abr_activo") = 1
                        drow("may_activo") = 1
                        drow("jun_activo") = 0
                        drow("jul_activo") = 0
                        drow("ago_activo") = 0
                        drow("sep_activo") = 0
                        drow("oct_activo") = 0
                        drow("nov_activo") = 0
                        drow("dic_activo") = 0
                        drow("ene_activo") = 0
                    Case 6
                        drow("feb_activo") = 1
                        drow("mar_activo") = 1
                        drow("abr_activo") = 1
                        drow("may_activo") = 1
                        drow("jun_activo") = 1
                        drow("jul_activo") = 0
                        drow("ago_activo") = 0
                        drow("sep_activo") = 0
                        drow("oct_activo") = 0
                        drow("nov_activo") = 0
                        drow("dic_activo") = 0
                        drow("ene_activo") = 0
                    Case 7
                        drow("feb_activo") = 1
                        drow("mar_activo") = 1
                        drow("abr_activo") = 1
                        drow("may_activo") = 1
                        drow("jun_activo") = 1
                        drow("jul_activo") = 1
                        drow("ago_activo") = 0
                        drow("sep_activo") = 0
                        drow("oct_activo") = 0
                        drow("nov_activo") = 0
                        drow("dic_activo") = 0
                        drow("ene_activo") = 0
                    Case 8
                        drow("feb_activo") = 1
                        drow("mar_activo") = 1
                        drow("abr_activo") = 1
                        drow("may_activo") = 1
                        drow("jun_activo") = 1
                        drow("jul_activo") = 1
                        drow("ago_activo") = 1
                        drow("sep_activo") = 0
                        drow("oct_activo") = 0
                        drow("nov_activo") = 0
                        drow("dic_activo") = 0
                        drow("ene_activo") = 0
                    Case 9
                        drow("feb_activo") = 1
                        drow("mar_activo") = 1
                        drow("abr_activo") = 1
                        drow("may_activo") = 1
                        drow("jun_activo") = 1
                        drow("jul_activo") = 1
                        drow("ago_activo") = 1
                        drow("sep_activo") = 1
                        drow("oct_activo") = 0
                        drow("nov_activo") = 0
                        drow("dic_activo") = 0
                        drow("ene_activo") = 0
                    Case 10
                        drow("feb_activo") = 1
                        drow("mar_activo") = 1
                        drow("abr_activo") = 1
                        drow("may_activo") = 1
                        drow("jun_activo") = 1
                        drow("jul_activo") = 1
                        drow("ago_activo") = 1
                        drow("sep_activo") = 1
                        drow("oct_activo") = 1
                        drow("nov_activo") = 0
                        drow("dic_activo") = 0
                        drow("ene_activo") = 0
                    Case 11
                        drow("feb_activo") = 1
                        drow("mar_activo") = 1
                        drow("abr_activo") = 1
                        drow("may_activo") = 1
                        drow("jun_activo") = 1
                        drow("jul_activo") = 1
                        drow("ago_activo") = 1
                        drow("sep_activo") = 1
                        drow("oct_activo") = 1
                        drow("nov_activo") = 1
                        drow("dic_activo") = 0
                        drow("ene_activo") = 0
                    Case 12
                        drow("feb_activo") = 1
                        drow("mar_activo") = 1
                        drow("abr_activo") = 1
                        drow("may_activo") = 1
                        drow("jun_activo") = 1
                        drow("jul_activo") = 1
                        drow("ago_activo") = 1
                        drow("sep_activo") = 1
                        drow("oct_activo") = 1
                        drow("nov_activo") = 1
                        drow("dic_activo") = 1
                        drow("ene_activo") = 0
                    Case 1
                        drow("feb_activo") = 1
                        drow("mar_activo") = 1
                        drow("abr_activo") = 1
                        drow("may_activo") = 1
                        drow("jun_activo") = 1
                        drow("jul_activo") = 1
                        drow("ago_activo") = 1
                        drow("sep_activo") = 1
                        drow("oct_activo") = 1
                        drow("nov_activo") = 1
                        drow("dic_activo") = 1
                        drow("ene_activo") = 1
                End Select


                '-----------------------------
                'If Not IsDBNull(drow("baja")) Then
                '    MesFin = Date.Parse(drow("baja")).Month


                '    Select Case MesFin
                '        Case 2
                '            MesFinal = "feb"
                '            drow("meses") = drow("meses") - 11
                '            'drow("meses") = 12
                '            'drow("objetivo_anual") = drow("objetivo_anual") 
                '            'drow("objetivo_anual") = drow("objetivo_anual") - 7
                '            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bfeb")
                '        Case 3
                '            MesFinal = "mar"
                '            drow("meses") = drow("meses") - 10
                '            'drow("meses") = 11
                '            ' drow("objetivo_anual") = drow("objetivo_anual") - 7
                '            'drow("objetivo_anual") = 7
                '            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bmar")
                '        Case 4
                '            MesFinal = "abr"
                '            drow("meses") = drow("meses") - 9
                '            'drow("meses") = 10
                '            'drow("objetivo_anual") = drow("objetivo_anual") - 6
                '            'drow("objetivo_anual") = 7
                '            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Babr")
                '        Case 5
                '            MesFinal = "may"
                '            drow("meses") = drow("meses") - 8
                '            'drow("meses") = 9
                '            ' drow("objetivo_anual") = drow("objetivo_anual") - 5
                '            'drow("objetivo_anual") = 6
                '            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bmay")
                '        Case 6
                '            MesFinal = "jun"
                '            drow("meses") = drow("meses") - 7
                '            'drow("meses") = 8
                '            'drow("objetivo_anual") = drow("objetivo_anual") - 5
                '            'drow("objetivo_anual") = 5
                '            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bjun")
                '        Case 7
                '            MesFinal = "jul"
                '            drow("meses") = drow("meses") - 6
                '            'drow("meses") = 7
                '            'drow("objetivo_anual") = drow("objetivo_anual") - 4
                '            'drow("objetivo_anual") = 5
                '            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bjul")
                '        Case 8
                '            MesFinal = "ago"
                '            drow("meses") = drow("meses") - 5
                '            'drow("meses") = 6
                '            'drow("objetivo_anual") = drow("objetivo_anual") - 3
                '            'drow("objetivo_anual") = 4
                '            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bago")
                '        Case 9
                '            MesFinal = "sep"
                '            drow("meses") = drow("meses") - 4
                '            'drow("meses") = 5
                '            'drow("objetivo_anual") = drow("objetivo_anual") - 3
                '            'drow("objetivo_anual") = 3
                '            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bsep")
                '        Case 10
                '            MesFinal = "oct"
                '            drow("meses") = drow("meses") - 3
                '            'drow("meses") = 4
                '            'drow("objetivo_anual") = drow("objetivo_anual") - 2
                '            'drow("objetivo_anual") = 3
                '            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Boct")
                '        Case 11
                '            MesFinal = "nov"
                '            drow("meses") = drow("meses") - 2
                '            'drow("meses") = 3
                '            'drow("objetivo_anual") = drow("objetivo_anual") - 1
                '            'drow("objetivo_anual") = 2
                '            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bnov")
                '        Case 12
                '            MesFinal = "dic"
                '            drow("meses") = drow("meses") - 1
                '            'drow("meses") = 
                '            'drow("objetivo_anual") = drow("objetivo_anual") - 1
                '            'drow("objetivo_anual") = 1
                '            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bdic")
                '    End Select


                '    Select Case MesFinal
                '        Case "feb"
                '            drow("mar_obj") = -1 : drow("abr_obj") = -1 : drow("may_obj") = -1 : drow("jun_obj") = -1 : drow("jul_obj") = -1 : drow("ago_obj") = -1 : drow("sep_obj") = -1 : drow("oct_obj") = -1 : drow("nov_obj") = -1 : drow("dic_obj") = -1 : drow("ene_obj") = -1
                '        Case "mar"
                '            drow("abr_obj") = -1 : drow("may_obj") = -1 : drow("jun_obj") = -1 : drow("jul_obj") = -1 : drow("ago_obj") = -1 : drow("sep_obj") = -1 : drow("oct_obj") = -1 : drow("nov_obj") = -1 : drow("dic_obj") = -1 : drow("ene_obj") = -1
                '        Case "abr"
                '            drow("may_obj") = -1 : drow("jun_obj") = -1 : drow("jul_obj") = -1 : drow("ago_obj") = -1 : drow("sep_obj") = -1 : drow("oct_obj") = -1 : drow("nov_obj") = -1 : drow("dic_obj") = -1 : drow("ene_obj") = -1
                '        Case "may"
                '            drow("jun_obj") = -1 : drow("jul_obj") = -1 : drow("ago_obj") = -1 : drow("sep_obj") = -1 : drow("oct_obj") = -1 : drow("nov_obj") = -1 : drow("dic_obj") = -1 : drow("ene_obj") = -1
                '        Case "jun"
                '            drow("jul_obj") = -1 : drow("ago_obj") = -1 : drow("sep_obj") = -1 : drow("oct_obj") = -1 : drow("nov_obj") = -1 : drow("dic_obj") = -1 : drow("ene_obj") = -1
                '        Case "jul"
                '            drow("ago_obj") = -1 : drow("sep_obj") = -1 : drow("oct_obj") = -1 : drow("nov_obj") = -1 : drow("dic_obj") = -1 : drow("ene_obj") = -1
                '        Case "ago"
                '            drow("sep_obj") = -1 : drow("oct_obj") = -1 : drow("nov_obj") = -1 : drow("dic_obj") = -1 : drow("ene_obj") = -1
                '        Case "sep"
                '            drow("oct_obj") = -1 : drow("nov_obj") = -1 : drow("dic_obj") = -1 : drow("ene_obj") = -1
                '        Case "oct"
                '            drow("nov_obj") = -1 : drow("dic_obj") = -1 : drow("ene_obj") = -1
                '        Case "nov"
                '            drow("dic_obj") = -1 : drow("ene_obj") = -1
                '        Case "dic"
                '            drow("ene_obj") = -1
                '    End Select

                '    Select Case MesFinal
                '        Case "feb"
                '            drow("mar_mob") = 0 : drow("abr_mob") = 0 : drow("may_mob") = 0 : drow("jun_mob") = 0 : drow("jul_mob") = 0 : drow("ago_mob") = 0 : drow("sep_mob") = 0 : drow("oct_mob") = 0 : drow("nov_mob") = 0 : drow("dic_mob") = 0 : drow("ene_mob") = 0
                '        Case "mar"
                '            drow("abr_mob") = 0 : drow("may_mob") = 0 : drow("jun_mob") = 0 : drow("jul_mob") = 0 : drow("ago_mob") = 0 : drow("sep_mob") = 0 : drow("oct_mob") = 0 : drow("nov_mob") = 0 : drow("dic_mob") = 0 : drow("ene_mob") = 0
                '        Case "abr"
                '            drow("may_mob") = 0 : drow("jun_mob") = 0 : drow("jul_mob") = 0 : drow("ago_mob") = 0 : drow("sep_mob") = 0 : drow("oct_mob") = 0 : drow("nov_mob") = 0 : drow("dic_mob") = 0 : drow("ene_mob") = 0
                '        Case "may"
                '            drow("jun_mob") = 0 : drow("jul_mob") = 0 : drow("ago_mob") = 0 : drow("sep_mob") = 0 : drow("oct_mob") = 0 : drow("nov_mob") = 0 : drow("dic_mob") = 0 : drow("ene_mob") = 0
                '        Case "jun"
                '            drow("jul_mob") = 0 : drow("ago_mob") = 0 : drow("sep_mob") = 0 : drow("oct_mob") = 0 : drow("nov_mob") = 0 : drow("dic_mob") = 0 : drow("ene_mob") = 0
                '        Case "jul"
                '            drow("ago_mob") = 0 : drow("sep_mob") = 0 : drow("oct_mob") = 0 : drow("nov_mob") = 0 : drow("dic_mob") = 0 : drow("ene_mob") = 0
                '        Case "ago"
                '            drow("sep_mob") = 0 : drow("oct_mob") = 0 : drow("nov_mob") = 0 : drow("dic_mob") = 0 : drow("ene_mob") = 0
                '        Case "sep"
                '            drow("oct_mob") = 0 : drow("nov_mob") = 0 : drow("dic_mob") = 0 : drow("ene_mob") = 0
                '        Case "oct"
                '            drow("nov_mob") = 0 : drow("dic_mob") = 0 : drow("ene_mob") = 0
                '        Case "nov"
                '            drow("dic_mob") = 0 : drow("ene_mob") = 0
                '        Case "dic"
                '            drow("ene_mob") = 0
                '    End Select
                'End If
                '------------------------------------------------------------------------------------------------------------------------------------------
                drow("fecha_ini") = fechaini
                drow("fecha_fin") = fechafin
            End If

            ' ------------------------------------------------------------------------------------------------------------------------------------------------------


            Try
                If Not IsDBNull(row("fecha")) Then
                    Dim mesidea As String = Date.Parse(row("fecha")).Month.ToString
                    Dim anoidea As String = Date.Parse(row("fecha")).Year.ToString
                    Dim mesletra As String = ""
                    Select Case mesidea
                        Case "2"
                            mesletra = "feb"
                        Case "3"
                            mesletra = "mar"
                        Case "4"
                            mesletra = "abr"
                        Case "5"
                            mesletra = "may"
                        Case "6"
                            mesletra = "jun"
                        Case "7"
                            mesletra = "jul"
                        Case "8"
                            mesletra = "ago"
                        Case "9"
                            mesletra = "sep"
                        Case "10"
                            mesletra = "oct"
                        Case "11"
                            mesletra = "nov"
                        Case "12"
                            mesletra = "dic"
                        Case "1"
                            mesletra = "ene"
                    End Select

                    drow(mesletra & "_ideas") = drow(mesletra & "_ideas") + 1
                Else
                    drow(row("mes_implementacion") & "_ideas") = drow(row("mes_implementacion") & "_ideas") + 1
                End If







                drow("estatus_anual") =
                drow("feb_ideas") +
                drow("mar_ideas") +
                drow("abr_ideas") +
                drow("may_ideas") +
                drow("jun_ideas") +
                drow("jul_ideas") +
                drow("ago_ideas") +
                drow("sep_ideas") +
                drow("oct_ideas") +
                drow("nov_ideas") +
                drow("dic_ideas") +
                drow("ene_ideas")


                drow("feb_acum") = drow("feb_ideas")
                drow("mar_acum") = drow("mar_ideas") + drow("feb_ideas")
                drow("abr_acum") = drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("may_acum") = drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("jun_acum") = drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("jul_acum") = drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("ago_acum") = drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("sep_acum") = drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("oct_acum") = drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("nov_acum") = drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("dic_acum") = drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("ene_acum") = drow("ene_ideas") + drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try

            ' Dim ano_act As Integer = Date.Now.Year + 1

            'If Ano + 1 = Date.Now.Year + 1 Then

            'End If

            'If Ano + 1 = Date.Now.Year + 1 Then
            '    Dim objetivoTemp As Integer = 0

            '    If drow("feb_activo") = 1 Then
            '        If drow("feb_obj") > -1 Then

            '            objetivoTemp = drow("mar_obj")
            '            'If drow("feb_obj") <> drow("mar_obj") Then
            '            '    objetivoTemp = drow("mar_obj")
            '            'Else
            '            '    drow("feb_mob") = 0
            '            'End If
            '            If drow("feb_obj") = 0 Then
            '                drow("feb_estatus") = 1
            '            Else
            '                If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
            '                    drow("feb_estatus") = 1
            '                Else
            '                    drow("feb_estatus") = 0
            '                End If
            '            End If

            '        Else
            '            drow("feb_mob") = 0
            '            drow("feb_estatus") = -2
            '        End If
            '    Else
            '        If drow("feb_obj") > -1 Then
            '            drow("feb_estatus") = -1
            '            'If drow("feb_obj") = drow("mar_obj") Then
            '            '    drow("feb_mob") = 0
            '            'End If
            '        Else
            '            drow("feb_mob") = 0
            '            drow("feb_estatus") = -2
            '        End If
            '    End If


            '    If drow("mar_activo") = 1 Then
            '        If drow("mar_obj") > -1 Then
            '            If drow("mar_obj") <> drow("feb_obj") Then
            '                objetivoTemp = drow("mar_obj")
            '            Else
            '                drow("mar_mob") = 0
            '            End If
            '            If drow("mar_obj") = 0 Then
            '                drow("mar_estatus") = 1
            '            Else
            '                If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
            '                    drow("mar_estatus") = 1
            '                Else
            '                    drow("mar_estatus") = 0
            '                End If
            '            End If

            '        Else
            '            drow("mar_mob") = 0
            '            drow("mar_estatus") = -2
            '        End If
            '    Else
            '        If drow("mar_obj") > -1 Then
            '            drow("mar_estatus") = -1
            '            If drow("mar_obj") = drow("feb_obj") Then
            '                drow("mar_mob") = 0
            '            End If
            '        Else
            '            drow("mar_mob") = 0
            '            drow("mar_estatus") = -2
            '        End If
            '    End If


            '    If drow("abr_activo") = 1 Then
            '        If drow("abr_obj") > -1 Then
            '            If drow("abr_obj") <> drow("mar_obj") Then
            '                objetivoTemp = drow("abr_obj")
            '            Else
            '                drow("abr_mob") = 0
            '            End If
            '            If drow("abr_obj") = 0 Then
            '                drow("abr_estatus") = 1
            '            Else
            '                If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
            '                    drow("abr_estatus") = 1
            '                Else
            '                    drow("abr_estatus") = 0
            '                End If
            '            End If

            '        Else
            '            drow("abr_mob") = 0
            '            drow("abr_estatus") = -2
            '        End If
            '    Else
            '        If drow("abr_obj") > -1 Then
            '            drow("abr_estatus") = -1
            '            If drow("abr_obj") = drow("mar_obj") Then
            '                drow("abr_mob") = 0
            '            End If
            '        Else
            '            drow("abr_mob") = 0
            '            drow("abr_estatus") = -2
            '        End If
            '    End If


            '    If drow("may_activo") = 1 Then
            '        If drow("may_obj") > -1 Then
            '            If drow("may_obj") <> drow("abr_obj") Then
            '                objetivoTemp = drow("may_obj")
            '            Else
            '                drow("may_mob") = 0
            '            End If
            '            If drow("may_obj") = 0 Then
            '                drow("may_estatus") = 1
            '            Else
            '                If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
            '                    drow("may_estatus") = 1
            '                Else
            '                    drow("may_estatus") = 0
            '                End If
            '            End If

            '        Else
            '            drow("may_mob") = 0
            '            drow("may_estatus") = -2
            '        End If

            '    Else
            '        If drow("may_obj") > -1 Then
            '            drow("may_estatus") = -1
            '            If drow("may_obj") = drow("abr_obj") Then
            '                drow("may_mob") = 0
            '            End If
            '        Else
            '            drow("may_mob") = 0
            '            drow("may_estatus") = -2
            '        End If
            '    End If



            '    If drow("jun_activo") = 1 Then
            '        If drow("jun_obj") > -1 Then
            '            If drow("jun_obj") <> drow("may_obj") Then
            '                objetivoTemp = drow("jun_obj")
            '            Else
            '                drow("jun_mob") = 0
            '            End If
            '            If drow("jun_obj") = 0 Then
            '                drow("jun_estatus") = 1
            '            Else
            '                If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
            '                    drow("jun_estatus") = 1
            '                Else
            '                    drow("jun_estatus") = 0
            '                End If
            '            End If

            '        Else
            '            drow("jun_mob") = 0
            '            drow("jun_estatus") = -2
            '        End If
            '    Else
            '        If drow("jun_obj") > -1 Then
            '            drow("jun_estatus") = -1
            '            If drow("jun_obj") = drow("may_obj") Then
            '                drow("jun_mob") = 0
            '            End If
            '        Else
            '            drow("jun_mob") = 0
            '            drow("jun_estatus") = -2
            '        End If
            '    End If


            '    If drow("jul_activo") = 1 Then
            '        If drow("jul_obj") > -1 Then
            '            If drow("jul_obj") <> drow("jun_obj") Then
            '                objetivoTemp = drow("jul_obj")
            '            Else
            '                drow("jul_mob") = 0
            '            End If
            '            If drow("jul_obj") = 0 Then
            '                drow("jul_estatus") = 1
            '            Else
            '                If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
            '                    drow("jul_estatus") = 1
            '                Else
            '                    drow("jul_estatus") = 0
            '                End If
            '            End If

            '        Else
            '            drow("jul_mob") = 0
            '            drow("jul_estatus") = -2
            '        End If
            '    Else
            '        If drow("jul_obj") > -1 Then
            '            drow("jul_estatus") = -1
            '            If drow("jul_obj") = drow("jun_obj") Then
            '                drow("jul_mob") = 0
            '            End If
            '        Else
            '            drow("jul_mob") = 0
            '            drow("jul_estatus") = -2
            '        End If
            '    End If


            '    If drow("ago_activo") = 1 Then
            '        If drow("ago_obj") > -1 Then
            '            If drow("ago_obj") <> drow("jul_obj") Then
            '                objetivoTemp = drow("ago_obj")
            '            Else
            '                drow("ago_mob") = 0

            '            End If
            '            If drow("ago_obj") = 0 Then
            '                drow("ago_estatus") = 1
            '            Else
            '                If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
            '                    drow("ago_estatus") = 1
            '                Else
            '                    drow("ago_estatus") = 0
            '                End If
            '            End If

            '        Else
            '            drow("ago_mob") = 0
            '            drow("ago_estatus") = -2
            '        End If
            '    Else
            '        If drow("ago_obj") > -1 Then
            '            drow("ago_estatus") = -1
            '            If drow("ago_obj") = drow("jul_obj") Then
            '                drow("ago_mob") = 0
            '            End If
            '        Else
            '            drow("ago_mob") = 0
            '            drow("ago_estatus") = -2
            '        End If
            '    End If


            '    If drow("sep_activo") = 1 Then
            '        If drow("sep_obj") > -1 Then
            '            If drow("sep_obj") <> drow("ago_obj") Then
            '                objetivoTemp = drow("sep_obj")
            '            Else
            '                drow("sep_mob") = 0
            '            End If
            '            If drow("sep_obj") = 0 Then
            '                drow("sep_estatus") = 1
            '            Else
            '                If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
            '                    drow("sep_estatus") = 1
            '                Else
            '                    drow("sep_estatus") = 0
            '                End If
            '            End If

            '        Else
            '            drow("sep_mob") = 0
            '            drow("sep_estatus") = -2
            '        End If
            '    Else

            '        If drow("sep_obj") > -1 Then
            '            drow("sep_estatus") = -1
            '            If drow("sep_obj") = drow("ago_obj") Then
            '                drow("sep_mob") = 0
            '            End If
            '        Else
            '            drow("sep_mob") = 0
            '            drow("sep_estatus") = -2
            '        End If
            '    End If




            '    If drow("oct_activo") = 1 Then
            '        If drow("oct_obj") > -1 Then
            '            If drow("oct_obj") <> drow("sep_obj") Then
            '                objetivoTemp = drow("oct_obj")
            '            Else
            '                drow("oct_mob") = 0
            '            End If
            '            If drow("oct_obj") = 0 Then
            '                drow("oct_estatus") = 1
            '            Else
            '                If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
            '                    drow("oct_estatus") = 1
            '                Else
            '                    drow("oct_estatus") = 0
            '                End If
            '            End If

            '        Else
            '            drow("oct_mob") = 0
            '            drow("oct_estatus") = -2
            '        End If
            '    Else
            '        If drow("oct_obj") > -1 Then
            '            drow("oct_estatus") = -1
            '            If drow("oct_obj") = drow("sep_obj") Then
            '                drow("oct_mob") = 0
            '            End If
            '        Else
            '            drow("oct_mob") = 0
            '            drow("oct_estatus") = -2
            '        End If
            '    End If

            '    If drow("nov_activo") = 1 Then
            '        If drow("nov_obj") > -1 Then
            '            If drow("nov_obj") <> drow("oct_obj") Then
            '                objetivoTemp = drow("nov_obj")
            '            Else
            '                drow("nov_mob") = 0
            '            End If
            '            If drow("nov_obj") = 0 Then
            '                drow("nov_estatus") = 1
            '            Else
            '                If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
            '                    drow("nov_estatus") = 1
            '                Else
            '                    drow("nov_estatus") = 0
            '                End If
            '            End If
            '        Else
            '            drow("nov_mob") = 0
            '            drow("nov_estatus") = -2
            '        End If
            '    Else
            '        If drow("nov_obj") > -1 Then
            '            drow("nov_estatus") = -1
            '            If drow("nov_obj") = drow("oct_obj") Then
            '                drow("nov_mob") = 0
            '            End If
            '        Else
            '            drow("nov_mob") = 0
            '            drow("nov_estatus") = -2
            '        End If
            '    End If

            '    If drow("dic_activo") = 1 Then
            '        If drow("dic_obj") > -1 Then
            '            If drow("dic_obj") <> drow("nov_obj") Then
            '                objetivoTemp = drow("dic_obj")
            '            Else
            '                drow("dic_mob") = 0
            '            End If
            '            If drow("dic_obj") = 0 Then
            '                drow("dic_estatus") = 1
            '            Else
            '                If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
            '                    drow("dic_estatus") = 1
            '                Else
            '                    drow("dic_estatus") = 0
            '                End If
            '            End If

            '        Else
            '            drow("dic_mob") = 0
            '            drow("dic_estatus") = -2
            '        End If
            '    Else
            '        If drow("dic_obj") > -1 Then
            '            drow("dic_estatus") = -1
            '            If drow("dic_obj") = drow("nov_obj") Then
            '                drow("dic_mob") = 0
            '            End If
            '        Else
            '            drow("dic_mob") = 0
            '            drow("dic_estatus") = -2
            '        End If
            '    End If

            '    If drow("ene_activo") = 1 Then
            '        If drow("ene_obj") > -1 Then
            '            If drow("ene_obj") <> drow("dic_obj") Then
            '                objetivoTemp = drow("ene_obj")
            '            Else
            '                drow("dic_mob") = 0
            '            End If
            '            'objetivoTemp = drow("ene_obj")
            '            If drow("ene_obj") = 0 Then
            '                drow("ene_estatus") = 1
            '            Else
            '                If (drow("estatus_anual") / objetivoTemp) > 0.75 Then
            '                    drow("ene_estatus") = 1
            '                Else
            '                    drow("ene_estatus") = 0
            '                End If
            '            End If
            '        Else
            '            drow("ene_mob") = 0
            '        End If
            '    Else
            '        If drow("ene_obj") > -1 Then
            '            drow("ene_estatus") = -1
            '            If drow("ene_obj") = drow("dic_obj") Then
            '                drow("ene_mob") = 0
            '            End If
            '        Else
            '            drow("ene_estatus") = -2
            '        End If
            '    End If
            'Else '========================================================================================================
            '    Dim objetivoTemp As Integer = 0
            '    If drow("feb_activo") = 1 Then
            '        If drow("feb_obj") > -1 Then
            '            If drow("feb_acum") >= drow("feb_obj") Then
            '                drow("feb_estatus") = 1
            '            Else
            '                drow("feb_estatus") = 0
            '            End If
            '        Else
            '            drow("feb_mob") = 0
            '            drow("feb_estatus") = -2
            '        End If
            '    Else
            '        If drow("feb_obj") > -1 Then
            '            drow("feb_estatus") = -1
            '        Else
            '            drow("feb_mob") = 0
            '            drow("feb_estatus") = -2
            '        End If
            '    End If


            '    If drow("mar_activo") = 1 Then
            '        If drow("mar_obj") > -1 Then
            '            If drow("mar_acum") >= drow("mar_obj") Then
            '                drow("mar_estatus") = 1
            '            Else
            '                drow("mar_estatus") = 0
            '            End If
            '        Else
            '            drow("mar_mob") = 0
            '            drow("mar_estatus") = -2
            '        End If
            '    Else
            '        If drow("mar_obj") > -1 Then
            '            drow("mar_estatus") = -1
            '        Else
            '            drow("mar_mob") = 0
            '            drow("mar_estatus") = -2
            '        End If
            '    End If


            '    If drow("abr_activo") = 1 Then
            '        If drow("abr_obj") > -1 Then
            '            If drow("abr_acum") >= drow("abr_obj") Then
            '                drow("abr_estatus") = 1
            '            Else
            '                drow("abr_estatus") = 0
            '            End If
            '        Else
            '            drow("abr_mob") = 0
            '            drow("abr_estatus") = -2
            '        End If
            '    Else
            '        If drow("abr_obj") > -1 Then
            '            drow("abr_estatus") = -1
            '        Else
            '            drow("abr_mob") = 0
            '            drow("abr_estatus") = -2
            '        End If
            '    End If


            '    If drow("may_activo") = 1 Then
            '        If drow("may_obj") > -1 Then
            '            If drow("may_acum") >= drow("may_obj") Then
            '                drow("may_estatus") = 1
            '            Else
            '                drow("may_estatus") = 0
            '            End If
            '        Else
            '            drow("may_mob") = 0
            '            drow("may_estatus") = -2
            '        End If

            '    Else
            '        If drow("may_obj") > -1 Then
            '            drow("may_estatus") = -1
            '        Else
            '            drow("may_mob") = 0
            '            drow("may_estatus") = -2
            '        End If
            '    End If



            '    If drow("jun_activo") = 1 Then
            '        If drow("jun_obj") > -1 Then
            '            If drow("jun_acum") >= drow("jun_obj") Then
            '                drow("jun_estatus") = 1
            '            Else
            '                drow("jun_estatus") = 0
            '            End If
            '        Else
            '            drow("jun_mob") = 0
            '            drow("jun_estatus") = -2
            '        End If
            '    Else
            '        If drow("jun_obj") > -1 Then
            '            drow("jun_estatus") = -1
            '        Else
            '            drow("jun_mob") = 0
            '            drow("jun_estatus") = -2
            '        End If
            '    End If


            '    If drow("jul_activo") = 1 Then
            '        If drow("jul_obj") > -1 Then
            '            If drow("jul_acum") >= drow("jul_obj") Then
            '                drow("jul_estatus") = 1
            '            Else
            '                drow("jul_estatus") = 0
            '            End If
            '        Else
            '            drow("jul_mob") = 0
            '            drow("jul_estatus") = -2
            '        End If
            '    Else
            '        If drow("jul_obj") > -1 Then
            '            drow("jul_estatus") = -1
            '        Else
            '            drow("jul_mob") = 0
            '            drow("jul_estatus") = -2
            '        End If
            '    End If


            '    If drow("ago_activo") = 1 Then
            '        If drow("ago_obj") > -1 Then
            '            If drow("ago_acum") >= drow("ago_obj") Then
            '                drow("ago_estatus") = 1
            '            Else
            '                drow("ago_estatus") = 0
            '            End If
            '        Else
            '            drow("ago_mob") = 0
            '            drow("ago_estatus") = -2
            '        End If
            '    Else
            '        If drow("ago_obj") > -1 Then
            '            drow("ago_estatus") = -1
            '        Else
            '            drow("ago_mob") = 0
            '            drow("ago_estatus") = -2
            '        End If
            '    End If


            '    If drow("sep_activo") = 1 Then
            '        If drow("sep_obj") > -1 Then
            '            If drow("sep_acum") >= drow("sep_obj") Then
            '                drow("sep_estatus") = 1
            '            Else
            '                drow("sep_estatus") = 0
            '            End If
            '        Else
            '            drow("sep_mob") = 0
            '            drow("sep_estatus") = -2
            '        End If
            '    Else

            '        If drow("sep_obj") > -1 Then
            '            drow("sep_estatus") = -1
            '        Else
            '            drow("sep_mob") = 0
            '            drow("sep_estatus") = -2
            '        End If
            '    End If




            '    If drow("oct_activo") = 1 Then
            '        If drow("oct_obj") > -1 Then
            '            If drow("oct_acum") >= drow("oct_obj") Then
            '                drow("oct_estatus") = 1
            '            Else
            '                drow("oct_estatus") = 0
            '            End If
            '        Else
            '            drow("oct_mob") = 0
            '            drow("oct_estatus") = -2
            '        End If
            '    Else
            '        If drow("oct_obj") > -1 Then
            '            drow("oct_estatus") = -1
            '        Else
            '            drow("oct_mob") = 0
            '            drow("oct_estatus") = -2
            '        End If
            '    End If

            '    If drow("nov_activo") = 1 Then
            '        If drow("nov_obj") > -1 Then
            '            If drow("nov_acum") >= drow("nov_obj") Then
            '                drow("nov_estatus") = 1
            '            Else
            '                drow("nov_estatus") = 0
            '            End If
            '        Else
            '            drow("nov_mob") = 0
            '            drow("nov_estatus") = -2
            '        End If
            '    Else
            '        If drow("nov_obj") > -1 Then
            '            drow("nov_estatus") = -1
            '        Else
            '            drow("nov_mob") = 0
            '            drow("nov_estatus") = -2
            '        End If
            '    End If

            '    If drow("dic_activo") = 1 Then
            '        If drow("dic_obj") > -1 Then
            '            If drow("dic_acum") >= drow("dic_obj") Then
            '                drow("dic_estatus") = 1
            '            Else
            '                drow("dic_estatus") = 0
            '            End If
            '        Else
            '            drow("dic_mob") = 0
            '            drow("dic_estatus") = -2
            '        End If
            '    Else
            '        If drow("dic_obj") > -1 Then
            '            drow("dic_estatus") = -1
            '        Else
            '            drow("dic_mob") = 0
            '            drow("dic_estatus") = -2
            '        End If
            '    End If

            '    If drow("ene_activo") = 1 Then
            '        If drow("ene_obj") > -1 Then
            '            If drow("ene_acum") >= drow("ene_obj") Then
            '                drow("ene_estatus") = 1
            '            Else
            '                drow("ene_estatus") = 0
            '            End If
            '        Else
            '            drow("ene_mob") = 0
            '            drow("ene_estatus") = -2
            '        End If
            '    Else
            '        If drow("ene_obj") > -1 Then
            '            drow("ene_estatus") = -1
            '        Else
            '            drow("ene_estatus") = -2
            '        End If
            '    End If
            'End If



            'drow("feb_estatus") = IIf(drow("feb_activo") = 1 And drow("feb_acum") >= drow("feb_obj") And drow("feb_obj") > 0, 1, -1)
            'drow("mar_estatus") = IIf(drow("mar_activo") = 1 And drow("mar_acum") >= drow("mar_obj") And drow("mar_obj") > 0, 1, -1)
            'drow("abr_estatus") = IIf(drow("abr_activo") = 1 And drow("abr_acum") >= drow("abr_obj") And drow("abr_obj") > 0, 1, -1)
            'drow("may_estatus") = IIf(drow("may_activo") = 1 And drow("may_acum") >= drow("may_obj") And drow("may_obj") > 0, 1, -1)
            'drow("jun_estatus") = IIf(drow("jun_activo") = 1 And drow("jun_acum") >= drow("jun_obj") And drow("jun_obj") > 0, 1, -1)
            'drow("jul_estatus") = IIf(drow("jul_activo") = 1 And drow("jul_acum") >= drow("jul_obj") And drow("jul_obj") > 0, 1, -1)
            'drow("ago_estatus") = IIf(drow("ago_activo") = 1 And drow("ago_acum") >= drow("ago_obj") And drow("ago_obj") > 0, 1, -1)
            'drow("sep_estatus") = IIf(drow("sep_activo") = 1 And drow("sep_acum") >= drow("sep_obj") And drow("sep_obj") > 0, 1, -1)
            'drow("oct_estatus") = IIf(drow("oct_activo") = 1 And drow("oct_acum") >= drow("oct_obj") And drow("oct_obj") > 0, 1, -1)
            'drow("nov_estatus") = IIf(drow("nov_activo") = 1 And drow("nov_acum") >= drow("nov_obj") And drow("nov_obj") > 0, 1, -1)
            'drow("dic_estatus") = IIf(drow("dic_activo") = 1 And drow("dic_acum") >= drow("dic_obj") And drow("dic_obj") > 0, 1, -1)
            'drow("ene_estatus") = IIf(drow("ene_activo") = 1 And drow("ene_acum") >= drow("ene_obj") And drow("ene_obj") > 0, 1, -1)



            'drow("feb_estatus") = IIf((drow("feb_activo") = 1 And drow("feb_acum") >= drow("feb_obj") And drow("feb_obj") > 0) Or drow("feb_obj") = 1, 1, -1)
            'drow("mar_estatus") = IIf((drow("mar_activo") = 1 And drow("mar_acum") >= drow("mar_obj") And drow("mar_obj") > 0) Or drow("mar_obj") = 1, 1, -1)
            'drow("abr_estatus") = IIf((drow("abr_activo") = 1 And drow("abr_acum") >= drow("abr_obj") And drow("abr_obj") > 0) Or drow("abr_obj") = 1, 1, -1)
            'drow("may_estatus") = IIf((drow("may_activo") = 1 And drow("may_acum") >= drow("may_obj") And drow("may_obj") > 0) Or drow("may_obj") = 1, 1, -1)
            'drow("jun_estatus") = IIf((drow("jun_activo") = 1 And drow("jun_acum") >= drow("jun_obj") And drow("jun_obj") > 0) Or drow("jun_obj") = 1, 1, -1)
            'drow("jul_estatus") = IIf((drow("jul_activo") = 1 And drow("jul_acum") >= drow("jul_obj") And drow("jul_obj") > 0) Or drow("jul_obj") = 1, 1, -1)
            'drow("ago_estatus") = IIf((drow("ago_activo") = 1 And drow("ago_acum") >= drow("ago_obj") And drow("ago_obj") > 0) Or drow("ago_obj") = 1, 1, -1)
            'drow("sep_estatus") = IIf((drow("sep_activo") = 1 And drow("sep_acum") >= drow("sep_obj") And drow("sep_obj") > 0) Or drow("sep_obj") = 1, 1, -1)
            'drow("oct_estatus") = IIf((drow("oct_activo") = 1 And drow("oct_acum") >= drow("oct_obj") And drow("oct_obj") > 0) Or drow("oct_obj") = 1, 1, -1)
            'drow("nov_estatus") = IIf((drow("nov_activo") = 1 And drow("nov_acum") >= drow("nov_obj") And drow("nov_obj") > 0) Or drow("nov_obj") = 1, 1, -1)
            'drow("dic_estatus") = IIf((drow("dic_activo") = 1 And drow("dic_acum") >= drow("dic_obj") And drow("dic_obj") > 0) Or drow("dic_obj") = 1, 1, -1)
            'drow("ene_estatus") = IIf((drow("ene_activo") = 1 And drow("ene_acum") >= drow("ene_obj") And drow("ene_obj") > 0) Or drow("ene_obj") = 1, 1, -1)



        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub


    Public Sub ParticipacionDepartamento(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Dim FechaIni As Date
        Dim FechaFin As Date
        Dim ano As Integer

        Dim objetivo_anual = 8

        dtDatos = New DataTable
        dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

        dtDatos.Columns.Add("cod_super", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))

        dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_depto", Type.GetType("System.String"))

        dtDatos.Columns.Add("cod_super_actual", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_super_actual", Type.GetType("System.String"))

        dtDatos.Columns.Add("cod_depto_actual", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_depto_actual", Type.GetType("System.String"))

        dtDatos.Columns.Add("cod_planta_actual", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_planta_actual", Type.GetType("System.String"))

        dtDatos.Columns.Add("baja", Type.GetType("System.String"))
        dtDatos.Columns.Add("alta", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("feb_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_ideas", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("meses", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("objetivo_anual", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("estatus_anual", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("feb_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_obj", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("feb_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_estatus", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("feb_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_acum", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("feb_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_activo", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("alta_personal", Type.GetType("System.DateTime"))

        dtDatos.Columns.Add("transferencia", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("reloj_anterior", Type.GetType("System.String"))

        dtDatos.Columns.Add("alta_ideas", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("baja_ideas", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("mes_inicio", Type.GetType("System.String"))

        dtDatos.Columns.Add("fecha_ini", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("fecha_fin", Type.GetType("System.DateTime"))

        dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj"), dtDatos.Columns("cod_depto")}

        ano = Year(FechaFinal)
        For Each dRow As DataRow In dtInformacion.Rows
            If Not IsDBNull(dRow("fecha")) Then
                If Month(dtInformacion.Rows(0).Item("fecha")) = 1 Then
                    ano = Year(dtInformacion.Rows(0).Item("fecha")) - 1
                Else
                    ano = Year(dtInformacion.Rows(0).Item("fecha"))
                End If
                Exit For
            Else
                If Month(FechaFinal) = 1 Then
                    ano = Year(FechaFinal) - 1
                Else
                    ano = Year(FechaFinal)
                End If
                Exit For
            End If
        Next

        Dim dtperiodos As DataTable
        dtperiodos = sqlExecute("select * from periodos where periodo_especial = 0 and ano = '" & ano & "' and num_mes = '02' order by periodo asc", "ta")
        If dtperiodos.Rows.Count > 0 Then
            FechaIni = dtperiodos.Rows(0)("fecha_ini")

            Dim TempFinal As String
            Dim TempFecha As String
            TempFinal = FechaSQL(FechaFinal).ToString.Substring(5, 5)
            TempFecha = FechaSQL(FechaInicial).ToString.Substring(5, 5)
            If TempFecha <> "02-01" Or TempFinal <> "01-31" Then
                MensajeError = "Es necesario cargar el año fiscal"
                MostrarReporte = False
                Exit Sub
            End If
        End If

        dtperiodos = sqlExecute("select * from periodos where periodo_especial = 0 and ano = '" & ano + 1 & "' and num_mes = '01' order by periodo desc", "ta")
        If dtperiodos.Rows.Count > 0 Then
            FechaFin = dtperiodos.Rows(0)("fecha_fin")
        End If


        Dim dtMesesTranscurridos As DataTable = sqlExecute("select distinct(lower(substring(mes, 1, 3))) as mes, ano, num_mes from periodos where periodo_especial = 0 and ((ano = '" & ano & "' and num_mes >= '02') or (ano = '" & ano + 1 & "' and num_mes = '01')) and fecha_fin < '" & FechaSQL(Now) & "' GROUP BY ano, mes, num_mes order by ano asc, num_mes asc", "ta")

        Dim dtIdeas As DataTable = dtInformacion.Select("", "reloj,fecha").CopyToDataTable
        Dim dtIdeasTransferencia As DataTable = dtIdeas.Clone

        For Each row As DataRow In dtIdeas.Rows
            AuxiliarParticipacionDepto(row, dtDatos, True, dtMesesTranscurridos, FechaIni, FechaFin, ano, dtIdeasTransferencia, dtIdeas)
        Next

        For Each row As DataRow In dtIdeasTransferencia.Rows
            AuxiliarParticipacionDepto(row, dtDatos, False, dtMesesTranscurridos, FechaIni, FechaFin, ano, dtIdeasTransferencia, dtIdeas)
        Next



    End Sub
    Private Sub AuxiliarParticipacionDepto(row As DataRow, ByRef DtDatos As DataTable, transferencias As Boolean, dtMesesTranscurridos As DataTable, fechaini As Date, fechafin As Date, Ano As Int32, ByRef dtIdeasTransferencia As DataTable, ByVal dtIDeasDepto As DataTable)
        Try
            Dim Llaves(1) As Object
            Llaves(0) = row("reloj")
            Llaves(1) = row("cod_depto")
            Dim RelojObjetivos As String = ""
            Dim drow As DataRow = DtDatos.Rows.Find(Llaves)
            Dim MesFin As Integer = 0
            Dim MesFinal As String = ""

            If drow Is Nothing Then
                drow = DtDatos.NewRow
                RelojObjetivos = row("reloj")
                drow("reloj") = row("reloj")
                drow("cod_depto") = row("cod_depto")
                DtDatos.Rows.Add(drow)

                drow("nombres") = RTrim(row("nombres"))
                drow("cod_super") = row("cod_super")
                drow("nombre_super") = row("nombre_super")
                drow("nombre_depto") = row("nombre_depto")
                drow("cod_super_actual") = row("cod_super_actual")
                drow("cod_depto_actual") = row("cod_depto_actual")
                drow("nombre_super_actual") = row("nombre_super_actual")
                drow("nombre_depto_actual") = row("nombre_depto_actual")
                drow("alta") = row("alta")

                drow("cod_planta_actual") = row("cod_planta_actual")
                drow("nombre_planta_actual") = row("nombre_planta_actual")

                Dim DeptoOriginal As String = drow("cod_depto").ToString
                Dim DeptoActual As String = drow("cod_depto_actual").ToString



                If row("reloj").ToString.Trim.Equals("031175") Then
                    row("baja") = Date.Parse("2015-03-31")
                End If
                If row("reloj").ToString.Trim.Equals("020158") Then
                    row("alta") = "2015-08-01"
                End If

                Try
                    drow("baja") = IIf(IsDBNull(row("baja")), "", "Baja " + FechaSQL(row("baja")))
                    'MesBaja = Month(row("baja"))

                Catch ex As Exception
                    drow("baja") = ""
                End Try
                drow("feb_ideas") = 0
                drow("mar_ideas") = 0
                drow("abr_ideas") = 0
                drow("may_ideas") = 0
                drow("jun_ideas") = 0
                drow("jul_ideas") = 0
                drow("ago_ideas") = 0
                drow("sep_ideas") = 0
                drow("oct_ideas") = 0
                drow("nov_ideas") = 0
                drow("dic_ideas") = 0
                drow("ene_ideas") = 0

                drow("estatus_anual") = 0

                drow("feb_obj") = 0
                drow("mar_obj") = 0
                drow("abr_obj") = 0
                drow("may_obj") = 0
                drow("jun_obj") = 0
                drow("jul_obj") = 0
                drow("ago_obj") = 0
                drow("sep_obj") = 0
                drow("oct_obj") = 0
                drow("nov_obj") = 0
                drow("dic_obj") = 0
                drow("ene_obj") = 0

                drow("feb_acum") = drow("feb_ideas")
                drow("mar_acum") = drow("mar_ideas") + drow("feb_ideas")
                drow("abr_acum") = drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("may_acum") = drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("jun_acum") = drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("jul_acum") = drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("ago_acum") = drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("sep_acum") = drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("oct_acum") = drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("nov_acum") = drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("dic_acum") = drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("ene_acum") = drow("ene_ideas") + drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")

                drow("feb_estatus") = -1
                drow("mar_estatus") = -1
                drow("abr_estatus") = -1
                drow("may_estatus") = -1
                drow("jun_estatus") = -1
                drow("jul_estatus") = -1
                drow("ago_estatus") = -1
                drow("sep_estatus") = -1
                drow("oct_estatus") = -1
                drow("nov_estatus") = -1
                drow("dic_estatus") = -1
                drow("ene_estatus") = -1


                drow("feb_activo") = -1
                drow("mar_activo") = -1
                drow("abr_activo") = -1
                drow("may_activo") = -1
                drow("jun_activo") = -1
                drow("jul_activo") = -1
                drow("ago_activo") = -1
                drow("sep_activo") = -1
                drow("oct_activo") = -1
                drow("nov_activo") = -1
                drow("dic_activo") = -1
                drow("ene_activo") = -1

                For Each mes As DataRow In dtMesesTranscurridos.Rows
                    drow(mes("mes") & "_activo") = 1
                Next
                '-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                '   drow("alta_ideas") = row("alta")

                'If AltaDepartamento Then
                '    drow("alta_ideas") = row("fecha")
                'Else
                '    drow("alta_ideas") = row("alta")
                'End If

                drow("alta_personal") = row("alta")
                drow("transferencia") = 0
                drow("reloj_anterior") = ""

                If transferencias Then
                    Dim dt_transferencia As DataTable = sqlExecute("select * from transferencias where reloj_nuevo = '" & row("reloj") & "' and alta > alta_anterior")
                    If dt_transferencia.Rows.Count > 0 Then
                        'If Date.Parse(dt_transferencia.Rows(0)("alta_anterior")) > FechaIni Then
                        drow("transferencia") = 1
                        drow("reloj_anterior") = dt_transferencia.Rows(0)("reloj_anterior")
                        drow("alta_personal") = row("alta")
                        drow("alta") = Date.Parse(dt_transferencia.Rows(0)("alta_anterior"))

                        'End If

                        Try
                            Dim dtIdeasAgencia As DataTable = sqlExecute("SELECT ideasVW.*,cias.nombre AS COMPANIA,deptos.nombre AS NOMBRE_DEPTO,SUPER.NOMBRE AS NOMBRE_SUPER," & _
                                                                   "AREAS.NOMBRE AS NOMBRE_AREA,puestos.nombre as 'nombre_puesto' FROM IDEASVW " & _
                                                                   "LEFT JOIN personal.dbo.cias ON ideasVW.cod_comp = cias.cod_comp " & _
                                                                   "LEFT JOIN personal.dbo.deptos ON ideasVW.cod_comp = deptos.cod_comp AND ideasVW.cod_depto = deptos.cod_depto " & _
                                                                   "LEFT JOIN personal.dbo.super ON ideasVW.cod_comp = super.cod_comp AND ideasVW.cod_super = super.cod_super " & _
                                                                   "LEFT JOIN personal.dbo.puestos ON ideasVW.cod_comp = puestos.cod_comp AND ideasVW.cod_puesto = puestos.cod_puesto " & _
                                                                   "LEFT JOIN personal.dbo.areas ON ideasVW.cod_comp = areas.cod_comp AND ideasVW.cod_area = areas.cod_area " & _
                                                                   "WHERE fecha BETWEEN '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "' and ideasvw.reloj = '" & dt_transferencia.Rows(0)("reloj_anterior") & "' and cod_depto = '" & row("cod_depto") & "'", "IDEAS")

                            For Each row_agencia As DataRow In dtIdeasAgencia.Rows
                                row_agencia("reloj") = row("reloj")
                                row_agencia("cod_depto") = row("cod_depto")
                                dtIdeasTransferencia.ImportRow(row_agencia)
                            Next

                        Catch ex As Exception
                            Debug.Print(ex.Message)
                        End Try


                    End If
                End If

                ' ---------------------------
                ' ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                If DeptoOriginal <> DeptoActual Then
                    Try

                        Dim dtCambiosDepto As New DataTable
                        dtCambiosDepto = sqlExecute("select MIN(cast(FECHA as date)) AS FECHA_CAMBIO from bitacora_personal where reloj in ('" & drow("reloj") & "','" & drow("reloj_anterior") & "')and (valorAnterior is not null and valorAnterior <> '') and campo = 'COD_DEPTO' and valorNuevo='" & DeptoOriginal & "' and (cast(FECHA as date) between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "')")
                        If dtCambiosDepto.Rows.Count > 0 Then
                            drow("alta_ideas") = IIf(IsDBNull(dtCambiosDepto.Rows(0).Item("FECHA_CAMBIO")), drow("alta"), dtCambiosDepto.Rows(0).Item("FECHA_CAMBIO"))
                            Dim d As Date = drow("alta_ideas")
                            Dim e As Date = drow("alta")
                            If d > e Then
                                drow("alta_ideas") = drow("alta")
                            End If

                        End If
                        Dim dtTempIDeasDepto As New DataTable
                        dtCambiosDepto = sqlExecute("select MAX(cast(FECHA as date)) AS FECHA_CAMBIO from bitacora_personal where reloj in ('" & drow("reloj") & "','" & drow("reloj_anterior") & "') and (valorAnterior is not null and valorAnterior <> '') and campo = 'COD_DEPTO' and valorAnterior='" & DeptoOriginal & "' and (cast(FECHA as date) between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "')")
                        If dtCambiosDepto.Rows.Count > 0 Then
                            drow("baja_ideas") = dtCambiosDepto.Rows(0).Item(("FECHA_CAMBIO"))
                        Else
                            dtTempIDeasDepto = dtIDeasDepto.Select("(reloj='" & row("reloj") & "')  and (cod_depto ='" & DeptoOriginal & "')", "fecha desc").CopyToDataTable()
                            If dtTempIDeasDepto.Rows.Count > 0 Then
                                drow("baja_ideas") = dtTempIDeasDepto.Rows(0).Item("fecha")
                            Else
                                drow("baja_ideas") = row("baja")
                            End If

                        End If

                    Catch ex As Exception
                        Debug.Print(ex.Message)
                    End Try
                Else
                    Try
                        Dim dtCambiosDepto As New DataTable
                        dtCambiosDepto = sqlExecute("select MIN(cast(FECHA as date)) AS FECHA_CAMBIO from bitacora_personal where reloj in ('" & drow("reloj") & "','" & drow("reloj_anterior") & "') and (valorAnterior is not null and valorAnterior <> '') and campo = 'COD_DEPTO' and valorNuevo='" & DeptoOriginal & "' and (cast(FECHA as date) between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "')")
                        If dtCambiosDepto.Rows.Count > 0 Then
                            If IsDBNull(dtCambiosDepto.Rows(0).Item(("FECHA_CAMBIO"))) Then
                                Debug.Print("")
                            End If
                            drow("alta_ideas") = IIf(IsDBNull(dtCambiosDepto.Rows(0).Item(("FECHA_CAMBIO"))), drow("alta"), dtCambiosDepto.Rows(0).Item(("FECHA_CAMBIO")))
                        Else
                            drow("alta_ideas") = row("alta_personal")
                        End If
                        ' drow("alta_ideas") = drow("alta_personal")
                        drow("baja_ideas") = row("baja")
                    Catch ex As Exception
                        Debug.Print(ex.Message)
                    End Try

                End If

                ' -----------------------------------------------------------------------------------------------------
                Dim dtObjetivos As DataTable = sqlExecute("select  * from tabulacion_objetivos where ano = '" + (Ano + 1).ToString + "' and reloj='" + RelojObjetivos + "'", "IDEAS")
                If Not dtObjetivos.Rows.Count > 0 Then
                    dtObjetivos = sqlExecute("select  * from tabulacion_objetivos where ano = '" + (Ano + 1).ToString + "' and reloj is null", "IDEAS")
                End If
                ' ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

                If Date.Parse(drow("alta_ideas")) < fechaini Then
                    drow("mes_inicio") = "feb"
                    drow("meses") = 12
                    drow("objetivo_anual") = dtObjetivos.Rows(0).Item("ene")
                Else
                    Dim mes_inicio As Integer = 0
                    mes_inicio = Date.Parse(drow("alta_ideas")).Month

                    Select Case mes_inicio
                        Case 2
                            drow("mes_inicio") = "feb"
                            drow("meses") = 12
                            'drow("objetivo_anual") = 8
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("feb")
                        Case 3
                            drow("mes_inicio") = "mar"
                            drow("meses") = 11
                            'drow("objetivo_anual") = 7
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("mar")
                        Case 4
                            drow("mes_inicio") = "abr"
                            drow("meses") = 10
                            'drow("objetivo_anual") = 7
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("abr")
                        Case 5
                            drow("mes_inicio") = "may"
                            drow("meses") = 9
                            'drow("objetivo_anual") = 6
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("may")
                        Case 6
                            drow("mes_inicio") = "jun"
                            drow("meses") = 8
                            'drow("objetivo_anual") = 5
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("jun")
                        Case 7
                            drow("mes_inicio") = "jul"
                            drow("meses") = 7
                            'drow("objetivo_anual") = 5
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("jul")
                        Case 8
                            drow("mes_inicio") = "ago"
                            drow("meses") = 6
                            'drow("objetivo_anual") = 4
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("ago")
                        Case 9
                            drow("mes_inicio") = "sep"
                            drow("meses") = 5
                            'drow("objetivo_anual") = 3
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("sep")
                        Case 10
                            drow("mes_inicio") = "oct"
                            drow("meses") = 4
                            'drow("objetivo_anual") = 3
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("oct")
                        Case 11
                            drow("mes_inicio") = "nov"
                            drow("meses") = 3
                            'drow("objetivo_anual") = 2
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("nov")
                        Case 12
                            drow("mes_inicio") = "dic"
                            drow("meses") = 2
                            'drow("objetivo_anual") = 1
                            drow("objetivo_anual") = dtObjetivos.Rows(0).Item("dic")
                    End Select
                End If
                ' ---------------------------

                ' ---------------------------
                Select Case drow("mes_inicio").ToString
                    Case "feb"
                        drow("feb_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("mar_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("abr_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("may_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("jun_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("jul_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("ago_obj") = dtObjetivos.Rows(0).Item("Bjun") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bmay") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Babr") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bmar") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bfeb") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bene")
                    Case "mar"
                        drow("feb_obj") = 0 : drow("mar_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("abr_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("may_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("jun_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("jul_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("ago_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bjun") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bmay") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Babr") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bmar") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bfeb")
                    Case "abr"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("may_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("jun_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("jul_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("ago_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bjun") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bmay") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Babr") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bmar")
                    Case "may"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("jun_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("jul_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("ago_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bjun") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bmay") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Babr")
                    Case "jun"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("jul_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("ago_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bjun") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bmay")
                    Case "jul"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("ago_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bjul") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bjun")
                    Case "ago"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bago") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bjul")
                    Case "sep"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bsep") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bago")
                    Case "oct"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Boct") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bsep")
                    Case "nov"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bnov") : drow("ene_obj") = dtObjetivos.Rows(0).Item("Boct")
                    Case "dic"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = dtObjetivos.Rows(0).Item("Bdic") : drow("ene_obj") = dtObjetivos.Rows(0).Item("nov")
                    Case "ene"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = dtObjetivos.Rows(0).Item("Bdic")
                End Select
                ' ---------------------------


                If Not IsDBNull(drow("baja_ideas")) Then
                    MesFin = Date.Parse(drow("baja_ideas")).Month
                    Select Case MesFin
                        Case 2
                            MesFinal = "feb"
                            drow("meses") = drow("meses") - 11
                            'drow("meses") = 12
                            'drow("objetivo_anual") = drow("objetivo_anual") 
                            'drow("objetivo_anual") = drow("objetivo_anual") - 7
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bfeb")
                        Case 3
                            MesFinal = "mar"
                            drow("meses") = drow("meses") - 10
                            'drow("meses") = 11
                            ' drow("objetivo_anual") = drow("objetivo_anual") - 7
                            'drow("objetivo_anual") = 7
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bmar")
                        Case 4
                            MesFinal = "abr"
                            drow("meses") = drow("meses") - 9
                            'drow("meses") = 10
                            'drow("objetivo_anual") = drow("objetivo_anual") - 6
                            'drow("objetivo_anual") = 7
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Babr")
                        Case 5
                            MesFinal = "may"
                            drow("meses") = drow("meses") - 8
                            'drow("meses") = 9
                            ' drow("objetivo_anual") = drow("objetivo_anual") - 5
                            'drow("objetivo_anual") = 6
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bmay")
                        Case 6
                            MesFinal = "jun"
                            drow("meses") = drow("meses") - 7
                            'drow("meses") = 8
                            'drow("objetivo_anual") = drow("objetivo_anual") - 5
                            'drow("objetivo_anual") = 5
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bjun")
                        Case 7
                            MesFinal = "jul"
                            drow("meses") = drow("meses") - 6
                            'drow("meses") = 7
                            'drow("objetivo_anual") = drow("objetivo_anual") - 4
                            'drow("objetivo_anual") = 5
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bjul")
                        Case 8
                            MesFinal = "ago"
                            drow("meses") = drow("meses") - 5
                            'drow("meses") = 6
                            'drow("objetivo_anual") = drow("objetivo_anual") - 3
                            'drow("objetivo_anual") = 4
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bago")
                        Case 9
                            MesFinal = "sep"
                            drow("meses") = drow("meses") - 4
                            'drow("meses") = 5
                            'drow("objetivo_anual") = drow("objetivo_anual") - 3
                            'drow("objetivo_anual") = 3
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bsep")
                        Case 10
                            MesFinal = "oct"
                            drow("meses") = drow("meses") - 3
                            'drow("meses") = 4
                            'drow("objetivo_anual") = drow("objetivo_anual") - 2
                            'drow("objetivo_anual") = 3
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Boct")
                        Case 11
                            MesFinal = "nov"
                            drow("meses") = drow("meses") - 2
                            'drow("meses") = 3
                            'drow("objetivo_anual") = drow("objetivo_anual") - 1
                            'drow("objetivo_anual") = 2
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bnov")
                        Case 12
                            MesFinal = "dic"
                            drow("meses") = drow("meses") - 1
                            'drow("meses") = 
                            'drow("objetivo_anual") = drow("objetivo_anual") - 1
                            'drow("objetivo_anual") = 1
                            drow("objetivo_anual") = drow("objetivo_anual") - dtObjetivos.Rows(0).Item("Bdic")
                    End Select
                    Select Case MesFinal
                        Case "feb"
                            drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
                        Case "mar"
                            drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
                        Case "abr"
                            drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
                        Case "may"
                            drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
                        Case "jun"
                            drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
                        Case "jul"
                            drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
                        Case "ago"
                            drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
                        Case "sep"
                            drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
                        Case "oct"
                            drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
                        Case "nov"
                            drow("dic_obj") = 0 : drow("ene_obj") = 0
                        Case "dic"
                            drow("ene_obj") = 0

                    End Select

                End If

                ' ---------------------------

                drow("fecha_ini") = fechaini
                drow("fecha_fin") = fechafin
            End If

            ' ---------------------------


            'drow("feb_estatus") = IIf((drow("feb_activo") = 1 And drow("feb_acum") >= drow("feb_obj") And drow("feb_obj") > 0) Or drow("feb_obj") = 1, 1, -1)
            'drow("mar_estatus") = IIf((drow("mar_activo") = 1 And drow("mar_acum") >= drow("mar_obj") And drow("mar_obj") > 0) Or drow("mar_obj") = 1, 1, -1)
            'drow("abr_estatus") = IIf((drow("abr_activo") = 1 And drow("abr_acum") >= drow("abr_obj") And drow("abr_obj") > 0) Or drow("abr_obj") = 1, 1, -1)
            'drow("may_estatus") = IIf((drow("may_activo") = 1 And drow("may_acum") >= drow("may_obj") And drow("may_obj") > 0) Or drow("may_obj") = 1, 1, -1)
            'drow("jun_estatus") = IIf((drow("jun_activo") = 1 And drow("jun_acum") >= drow("jun_obj") And drow("jun_obj") > 0) Or drow("jun_obj") = 1, 1, -1)
            'drow("jul_estatus") = IIf((drow("jul_activo") = 1 And drow("jul_acum") >= drow("jul_obj") And drow("jul_obj") > 0) Or drow("jul_obj") = 1, 1, -1)
            'drow("ago_estatus") = IIf((drow("ago_activo") = 1 And drow("ago_acum") >= drow("ago_obj") And drow("ago_obj") > 0) Or drow("ago_obj") = 1, 1, -1)
            'drow("sep_estatus") = IIf((drow("sep_activo") = 1 And drow("sep_acum") >= drow("sep_obj") And drow("sep_obj") > 0) Or drow("sep_obj") = 1, 1, -1)
            'drow("oct_estatus") = IIf((drow("oct_activo") = 1 And drow("oct_acum") >= drow("oct_obj") And drow("oct_obj") > 0) Or drow("oct_obj") = 1, 1, -1)
            'drow("nov_estatus") = IIf((drow("nov_activo") = 1 And drow("nov_acum") >= drow("nov_obj") And drow("nov_obj") > 0) Or drow("nov_obj") = 1, 1, -1)
            'drow("dic_estatus") = IIf((drow("dic_activo") = 1 And drow("dic_acum") >= drow("dic_obj") And drow("dic_obj") > 0) Or drow("dic_obj") = 1, 1, -1)
            'drow("ene_estatus") = IIf((drow("ene_activo") = 1 And drow("ene_acum") >= drow("ene_obj") And drow("ene_obj") > 0) Or drow("ene_obj") = 1, 1, -1)




            drow(row("mes_implementacion") & "_ideas") = drow(row("mes_implementacion") & "_ideas") + 1

            drow("estatus_anual") =
            drow("feb_ideas") +
            drow("mar_ideas") +
            drow("abr_ideas") +
            drow("may_ideas") +
            drow("jun_ideas") +
            drow("jul_ideas") +
            drow("ago_ideas") +
            drow("sep_ideas") +
            drow("oct_ideas") +
            drow("nov_ideas") +
            drow("dic_ideas") +
            drow("ene_ideas")


            drow("feb_acum") = drow("feb_ideas")
            drow("mar_acum") = drow("mar_ideas") + drow("feb_ideas")
            drow("abr_acum") = drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("may_acum") = drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("jun_acum") = drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("jul_acum") = drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("ago_acum") = drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("sep_acum") = drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("oct_acum") = drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("nov_acum") = drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("dic_acum") = drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("ene_acum") = drow("ene_ideas") + drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")


            drow("feb_estatus") = IIf(drow("feb_activo") = 1 And drow("feb_acum") >= drow("feb_obj") And drow("feb_obj") > 0, 1, -1)
            drow("mar_estatus") = IIf(drow("mar_activo") = 1 And drow("mar_acum") >= drow("mar_obj") And drow("mar_obj") > 0, 1, -1)
            drow("abr_estatus") = IIf(drow("abr_activo") = 1 And drow("abr_acum") >= drow("abr_obj") And drow("abr_obj") > 0, 1, -1)
            drow("may_estatus") = IIf(drow("may_activo") = 1 And drow("may_acum") >= drow("may_obj") And drow("may_obj") > 0, 1, -1)
            drow("jun_estatus") = IIf(drow("jun_activo") = 1 And drow("jun_acum") >= drow("jun_obj") And drow("jun_obj") > 0, 1, -1)
            drow("jul_estatus") = IIf(drow("jul_activo") = 1 And drow("jul_acum") >= drow("jul_obj") And drow("jul_obj") > 0, 1, -1)
            drow("ago_estatus") = IIf(drow("ago_activo") = 1 And drow("ago_acum") >= drow("ago_obj") And drow("ago_obj") > 0, 1, -1)
            drow("sep_estatus") = IIf(drow("sep_activo") = 1 And drow("sep_acum") >= drow("sep_obj") And drow("sep_obj") > 0, 1, -1)
            drow("oct_estatus") = IIf(drow("oct_activo") = 1 And drow("oct_acum") >= drow("oct_obj") And drow("oct_obj") > 0, 1, -1)
            drow("nov_estatus") = IIf(drow("nov_activo") = 1 And drow("nov_acum") >= drow("nov_obj") And drow("nov_obj") > 0, 1, -1)
            drow("dic_estatus") = IIf(drow("dic_activo") = 1 And drow("dic_acum") >= drow("dic_obj") And drow("dic_obj") > 0, 1, -1)
            drow("ene_estatus") = IIf(drow("ene_activo") = 1 And drow("ene_acum") >= drow("ene_obj") And drow("ene_obj") > 0, 1, -1)


            'drow("feb_estatus") = IIf((drow("feb_activo") = 1 And drow("feb_acum") >= drow("feb_obj") And drow("feb_obj") > 0) Or drow("feb_obj") = 1, 1, -1)
            'drow("mar_estatus") = IIf((drow("mar_activo") = 1 And drow("mar_acum") >= drow("mar_obj") And drow("mar_obj") > 0) Or drow("mar_obj") = 1, 1, -1)
            'drow("abr_estatus") = IIf((drow("abr_activo") = 1 And drow("abr_acum") >= drow("abr_obj") And drow("abr_obj") > 0) Or drow("abr_obj") = 1, 1, -1)
            'drow("may_estatus") = IIf((drow("may_activo") = 1 And drow("may_acum") >= drow("may_obj") And drow("may_obj") > 0) Or drow("may_obj") = 1, 1, -1)
            'drow("jun_estatus") = IIf((drow("jun_activo") = 1 And drow("jun_acum") >= drow("jun_obj") And drow("jun_obj") > 0) Or drow("jun_obj") = 1, 1, -1)
            'drow("jul_estatus") = IIf((drow("jul_activo") = 1 And drow("jul_acum") >= drow("jul_obj") And drow("jul_obj") > 0) Or drow("jul_obj") = 1, 1, -1)
            'drow("ago_estatus") = IIf((drow("ago_activo") = 1 And drow("ago_acum") >= drow("ago_obj") And drow("ago_obj") > 0) Or drow("ago_obj") = 1, 1, -1)
            'drow("sep_estatus") = IIf((drow("sep_activo") = 1 And drow("sep_acum") >= drow("sep_obj") And drow("sep_obj") > 0) Or drow("sep_obj") = 1, 1, -1)
            'drow("oct_estatus") = IIf((drow("oct_activo") = 1 And drow("oct_acum") >= drow("oct_obj") And drow("oct_obj") > 0) Or drow("oct_obj") = 1, 1, -1)
            'drow("nov_estatus") = IIf((drow("nov_activo") = 1 And drow("nov_acum") >= drow("nov_obj") And drow("nov_obj") > 0) Or drow("nov_obj") = 1, 1, -1)
            'drow("dic_estatus") = IIf((drow("dic_activo") = 1 And drow("dic_acum") >= drow("dic_obj") And drow("dic_obj") > 0) Or drow("dic_obj") = 1, 1, -1)
            'drow("ene_estatus") = IIf((drow("ene_activo") = 1 And drow("ene_acum") >= drow("ene_obj") And drow("ene_obj") > 0) Or drow("ene_obj") = 1, 1, -1)




        Catch ex As Exception
            Debug.Print(ex.Message)

        End Try
    End Sub


#Region "Funcional"
    Public Sub DetalleCumplimiento(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        ' ya nadamas hay que poner esto en donde decidas que no se quiere generar el reporte, en el catch de la excepcion o en algun IF o asi
        'MensajeError = "Ocurrió un error al generar el reporte de participacion individual"
        'MostrarReporte = False
        Try
            Dim FechaIni As Date
            Dim FechaFin As Date
            Dim ano As Integer

            Dim objetivo_anual = 8

            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_super", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_depto", Type.GetType("System.String"))


            dtDatos.Columns.Add("cod_planta_actual", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_planta_actual", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_area", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_area", Type.GetType("System.String"))

            dtDatos.Columns.Add("feb_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("mar_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("abr_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("may_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jun_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jul_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ago_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("sep_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("oct_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("nov_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("dic_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ene_ideas", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("meses", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("objetivo_anual", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("estatus_anual", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("feb_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("mar_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("abr_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("may_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jun_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jul_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ago_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("sep_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("oct_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("nov_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("dic_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ene_obj", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("feb_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("mar_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("abr_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("may_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jun_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jul_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ago_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("sep_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("oct_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("nov_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("dic_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ene_estatus", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("feb_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("mar_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("abr_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("may_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jun_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jul_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ago_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("sep_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("oct_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("nov_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("dic_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ene_acum", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("feb_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("mar_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("abr_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("may_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jun_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jul_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ago_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("sep_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("oct_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("nov_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("dic_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ene_activo", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("alta_personal", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("baja", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("transferencia", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("reloj_anterior", Type.GetType("System.String"))

            dtDatos.Columns.Add("alta_ideas", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("mes_inicio", Type.GetType("System.String"))

            dtDatos.Columns.Add("fecha_ini", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("fecha_fin", Type.GetType("System.DateTime"))

            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj")}


            ano = Year(FechaFinal)
            For Each dRow As DataRow In dtInformacion.Rows
                If Not IsDBNull(dRow("fecha")) Then
                    If Month(dtInformacion.Rows(0).Item("fecha")) = 1 Then
                        ano = Year(dtInformacion.Rows(0).Item("fecha")) - 1
                    Else
                        ano = Year(dtInformacion.Rows(0).Item("fecha"))
                    End If
                    Exit For
                Else
                    If Month(FechaFinal) = 1 Then
                        ano = Year(FechaFinal) - 1
                    Else
                        ano = Year(FechaFinal)
                    End If
                    Exit For
                End If
            Next

            Dim dtperiodos As DataTable
            dtperiodos = sqlExecute("select * from periodos where periodo_especial = 0 and ano = '" & ano & "' and num_mes = '02' order by periodo asc", "ta")
            If dtperiodos.Rows.Count > 0 Then

                Dim TempFinal As String
                Dim TempFecha As String

                TempFinal = FechaSQL(FechaFinal).ToString.Substring(5, 5)
                TempFecha = FechaSQL(FechaInicial).ToString.Substring(5, 5)
                If TempFecha <> "02-01" Or TempFinal <> "01-31" Then
                    MensajeError = "Es necesario cargar el año fiscal"
                    MostrarReporte = False
                    Exit Sub
                End If
            End If

            dtperiodos = sqlExecute("select * from periodos where periodo_especial = 0 and ano = '" & ano + 1 & "' and num_mes = '01' order by periodo desc", "ta")
            If dtperiodos.Rows.Count > 0 Then
                FechaFin = dtperiodos.Rows(0)("fecha_fin")
            End If


            Dim dtMesesTranscurridos As DataTable = sqlExecute("select distinct(lower(substring(mes, 1, 3))) as mes, ano, num_mes from periodos where periodo_especial = 0 and ((ano = '" & ano & "' and num_mes >= '02') or (ano = '" & ano + 1 & "' and num_mes = '01')) and fecha_fin < '" & FechaSQL(Now) & "' GROUP BY ano, mes, num_mes order by ano asc, num_mes asc", "ta")

            Dim dtIdeas As DataTable = dtInformacion.Select("", "reloj").CopyToDataTable
            Dim dtIdeasTransferencia As DataTable = dtIdeas.Clone

            For Each row As DataRow In dtIdeas.Rows
                AuxiliarDetalle(row, dtDatos, True, dtMesesTranscurridos, FechaInicial, FechaFinal, objetivo_anual, dtIdeasTransferencia)
            Next

            For Each row As DataRow In dtIdeasTransferencia.Rows
                AuxiliarDetalle(row, dtDatos, False, dtMesesTranscurridos, FechaInicial, FechaFinal, objetivo_anual, dtIdeasTransferencia)
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try


    End Sub
    Private Sub AuxiliarDetalle(row As DataRow, ByRef DtDatos As DataTable, transferencias As Boolean, dtMesesTranscurridos As DataTable, fechaini As Date, fechafin As Date, objetivo_anual As Int32, ByRef dtIdeasTransferencia As DataTable)
        Try
            Dim drow As DataRow = DtDatos.Rows.Find(row("reloj"))

            If drow Is Nothing Then
                drow = DtDatos.NewRow

                drow("reloj") = row("reloj")
                DtDatos.Rows.Add(drow)

                drow("nombres") = RTrim(row("nombres"))

                drow("cod_super") = row("cod_super")
                drow("cod_depto") = row("cod_depto")

                drow("nombre_super") = row("nombre_super")
                drow("nombre_depto") = row("nombre_depto")

                drow("cod_planta_actual") = row("cod_planta_actual")
                drow("nombre_planta_actual") = row("nombre_planta_actual")

                drow("feb_ideas") = 0
                drow("mar_ideas") = 0
                drow("abr_ideas") = 0
                drow("may_ideas") = 0
                drow("jun_ideas") = 0
                drow("jul_ideas") = 0
                drow("ago_ideas") = 0
                drow("sep_ideas") = 0
                drow("oct_ideas") = 0
                drow("nov_ideas") = 0
                drow("dic_ideas") = 0
                drow("ene_ideas") = 0

                drow("estatus_anual") = 0

                drow("feb_obj") = 0
                drow("mar_obj") = 0
                drow("abr_obj") = 0
                drow("may_obj") = 0
                drow("jun_obj") = 0
                drow("jul_obj") = 0
                drow("ago_obj") = 0
                drow("sep_obj") = 0
                drow("oct_obj") = 0
                drow("nov_obj") = 0
                drow("dic_obj") = 0
                drow("ene_obj") = 0

                drow("feb_acum") = drow("feb_ideas")
                drow("mar_acum") = drow("mar_ideas") + drow("feb_ideas")
                drow("abr_acum") = drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("may_acum") = drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("jun_acum") = drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("jul_acum") = drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("ago_acum") = drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("sep_acum") = drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("oct_acum") = drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("nov_acum") = drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("dic_acum") = drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("ene_acum") = drow("ene_ideas") + drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")

                drow("feb_estatus") = -1
                drow("mar_estatus") = -1
                drow("abr_estatus") = -1
                drow("may_estatus") = -1
                drow("jun_estatus") = -1
                drow("jul_estatus") = -1
                drow("ago_estatus") = -1
                drow("sep_estatus") = -1
                drow("oct_estatus") = -1
                drow("nov_estatus") = -1
                drow("dic_estatus") = -1
                drow("ene_estatus") = -1


                drow("feb_activo") = -1
                drow("mar_activo") = -1
                drow("abr_activo") = -1
                drow("may_activo") = -1
                drow("jun_activo") = -1
                drow("jul_activo") = -1
                drow("ago_activo") = -1
                drow("sep_activo") = -1
                drow("oct_activo") = -1
                drow("nov_activo") = -1
                drow("dic_activo") = -1
                drow("ene_activo") = -1

                For Each mes As DataRow In dtMesesTranscurridos.Rows
                    drow(mes("mes") & "_activo") = 1
                Next

                ' ---------------------------
                drow("baja") = row("baja")
                drow("alta_personal") = row("alta")
                drow("alta_ideas") = row("alta")

                drow("transferencia") = 0
                drow("reloj_anterior") = ""

                If transferencias Then
                    Dim dt_transferencia As DataTable = sqlExecute("select * from transferencias where reloj_nuevo = '" & row("reloj") & "' and alta > alta_anterior")
                    If dt_transferencia.Rows.Count > 0 Then
                        'If Date.Parse(dt_transferencia.Rows(0)("alta_anterior")) > FechaIni Then
                        drow("transferencia") = 1
                        drow("reloj_anterior") = dt_transferencia.Rows(0)("reloj_anterior")
                        drow("alta_ideas") = Date.Parse(dt_transferencia.Rows(0)("alta_anterior"))
                        'End If

                        Try
                            Dim dtIdeasAgencia As DataTable = sqlExecute("SELECT ideasVW.*,cias.nombre AS COMPANIA,deptos.nombre AS NOMBRE_DEPTO,SUPER.NOMBRE AS NOMBRE_SUPER," & _
                                                                   "AREAS.NOMBRE AS NOMBRE_AREA,puestos.nombre as 'nombre_puesto' FROM IDEASVW " & _
                                                                   "LEFT JOIN personal.dbo.cias ON ideasVW.cod_comp = cias.cod_comp " & _
                                                                   "LEFT JOIN personal.dbo.deptos ON ideasVW.cod_comp = deptos.cod_comp AND ideasVW.cod_depto = deptos.cod_depto " & _
                                                                   "LEFT JOIN personal.dbo.super ON ideasVW.cod_comp = super.cod_comp AND ideasVW.cod_super = super.cod_super " & _
                                                                   "LEFT JOIN personal.dbo.puestos ON ideasVW.cod_comp = puestos.cod_comp AND ideasVW.cod_puesto = puestos.cod_puesto " & _
                                                                   "LEFT JOIN personal.dbo.areas ON ideasVW.cod_comp = areas.cod_comp AND ideasVW.cod_area = areas.cod_area " & _
                                                                   "WHERE fecha BETWEEN '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "' and ideasvw.reloj = '" & dt_transferencia.Rows(0)("reloj_anterior") & "'", "IDEAS")

                            For Each row_agencia As DataRow In dtIdeasAgencia.Rows
                                row_agencia("reloj") = row("reloj")
                                dtIdeasTransferencia.ImportRow(row_agencia)
                            Next

                        Catch ex As Exception

                        End Try


                    End If
                End If

                ' ---------------------------

                If Date.Parse(drow("alta_ideas")) < fechaini Then
                    drow("mes_inicio") = "feb"
                    drow("meses") = 12
                    drow("objetivo_anual") = objetivo_anual
                Else
                    Dim mes_inicio As Integer = Date.Parse(drow("alta_ideas")).Month + 1
                    Select Case mes_inicio
                        Case 2
                            drow("mes_inicio") = "feb"
                            drow("meses") = 12
                            drow("objetivo_anual") = 8
                        Case 3
                            drow("mes_inicio") = "mar"
                            drow("meses") = 11
                            drow("objetivo_anual") = 7
                        Case 4
                            drow("mes_inicio") = "abr"
                            drow("meses") = 10
                            drow("objetivo_anual") = 7
                        Case 5
                            drow("mes_inicio") = "may"
                            drow("meses") = 9
                            drow("objetivo_anual") = 6
                        Case 6
                            drow("mes_inicio") = "jun"
                            drow("meses") = 8
                            drow("objetivo_anual") = 5
                        Case 7
                            drow("mes_inicio") = "jul"
                            drow("meses") = 7
                            drow("objetivo_anual") = 5
                        Case 8
                            drow("mes_inicio") = "ago"
                            drow("meses") = 6
                            drow("objetivo_anual") = 4
                        Case 9
                            drow("mes_inicio") = "sep"
                            drow("meses") = 5
                            drow("objetivo_anual") = 3
                        Case 10
                            drow("mes_inicio") = "oct"
                            drow("meses") = 4
                            drow("objetivo_anual") = 3
                        Case 11
                            drow("mes_inicio") = "nov"
                            drow("meses") = 3
                            drow("objetivo_anual") = 2
                        Case 12
                            drow("mes_inicio") = "dic"
                            drow("meses") = 2
                            drow("objetivo_anual") = 1
                    End Select
                End If

                ' ---------------------------

                Select Case drow("mes_inicio").ToString
                    Case "feb"
                        drow("feb_obj") = 1 : drow("mar_obj") = 1 : drow("abr_obj") = 2 : drow("may_obj") = 3 : drow("jun_obj") = 3 : drow("jul_obj") = 4 : drow("ago_obj") = 5 : drow("sep_obj") = 5 : drow("oct_obj") = 6 : drow("nov_obj") = 7 : drow("dic_obj") = 7 : drow("ene_obj") = 8
                    Case "mar"
                        drow("feb_obj") = 0 : drow("mar_obj") = 1 : drow("abr_obj") = 1 : drow("may_obj") = 2 : drow("jun_obj") = 3 : drow("jul_obj") = 3 : drow("ago_obj") = 4 : drow("sep_obj") = 5 : drow("oct_obj") = 5 : drow("nov_obj") = 6 : drow("dic_obj") = 7 : drow("ene_obj") = 7
                    Case "abr"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 1 : drow("may_obj") = 1 : drow("jun_obj") = 2 : drow("jul_obj") = 3 : drow("ago_obj") = 3 : drow("sep_obj") = 4 : drow("oct_obj") = 5 : drow("nov_obj") = 5 : drow("dic_obj") = 6 : drow("ene_obj") = 7
                    Case "may"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 1 : drow("jun_obj") = 1 : drow("jul_obj") = 2 : drow("ago_obj") = 3 : drow("sep_obj") = 3 : drow("oct_obj") = 4 : drow("nov_obj") = 5 : drow("dic_obj") = 5 : drow("ene_obj") = 6
                    Case "jun"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 1 : drow("jul_obj") = 1 : drow("ago_obj") = 2 : drow("sep_obj") = 3 : drow("oct_obj") = 3 : drow("nov_obj") = 4 : drow("dic_obj") = 5 : drow("ene_obj") = 5
                    Case "jul"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 1 : drow("ago_obj") = 1 : drow("sep_obj") = 2 : drow("oct_obj") = 3 : drow("nov_obj") = 3 : drow("dic_obj") = 4 : drow("ene_obj") = 5
                    Case "ago"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 1 : drow("sep_obj") = 1 : drow("oct_obj") = 2 : drow("nov_obj") = 3 : drow("dic_obj") = 3 : drow("ene_obj") = 4
                    Case "sep"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 1 : drow("oct_obj") = 1 : drow("nov_obj") = 2 : drow("dic_obj") = 3 : drow("ene_obj") = 3
                    Case "oct"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 1 : drow("nov_obj") = 1 : drow("dic_obj") = 2 : drow("ene_obj") = 3
                    Case "nov"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 1 : drow("dic_obj") = 1 : drow("ene_obj") = 2
                    Case "dic"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 1 : drow("ene_obj") = 1
                    Case "ene"
                        drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 1
                End Select


                ' ---------------------------

                drow("fecha_ini") = fechaini
                drow("fecha_fin") = fechafin
            End If

            ' ---------------------------

            drow(row("mes_implementacion") & "_ideas") = drow(row("mes_implementacion") & "_ideas") + 1

            drow("estatus_anual") =
            drow("feb_ideas") +
            drow("mar_ideas") +
            drow("abr_ideas") +
            drow("may_ideas") +
            drow("jun_ideas") +
            drow("jul_ideas") +
            drow("ago_ideas") +
            drow("sep_ideas") +
            drow("oct_ideas") +
            drow("nov_ideas") +
            drow("dic_ideas") +
            drow("ene_ideas")


            drow("feb_acum") = drow("feb_ideas")
            drow("mar_acum") = drow("mar_ideas") + drow("feb_ideas")
            drow("abr_acum") = drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("may_acum") = drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("jun_acum") = drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("jul_acum") = drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("ago_acum") = drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("sep_acum") = drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("oct_acum") = drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("nov_acum") = drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("dic_acum") = drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            drow("ene_acum") = drow("ene_ideas") + drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")


            drow("feb_estatus") = IIf(drow("feb_acum") >= drow("feb_obj"), IIf(drow("feb_obj") > 0, 1, -1), 0)
            drow("mar_estatus") = IIf(drow("mar_acum") >= drow("mar_obj"), IIf(drow("mar_obj") > 0, 1, -1), 0)
            drow("abr_estatus") = IIf(drow("abr_acum") >= drow("abr_obj"), IIf(drow("abr_obj") > 0, 1, -1), 0)
            drow("may_estatus") = IIf(drow("may_acum") >= drow("may_obj"), IIf(drow("may_obj") > 0, 1, -1), 0)
            drow("jun_estatus") = IIf(drow("jun_acum") >= drow("jun_obj"), IIf(drow("jun_obj") > 0, 1, -1), 0)
            drow("jul_estatus") = IIf(drow("jul_acum") >= drow("jul_obj"), IIf(drow("jul_obj") > 0, 1, -1), 0)
            drow("ago_estatus") = IIf(drow("ago_acum") >= drow("ago_obj"), IIf(drow("ago_obj") > 0, 1, -1), 0)
            drow("sep_estatus") = IIf(drow("sep_acum") >= drow("sep_obj"), IIf(drow("sep_obj") > 0, 1, -1), 0)
            drow("oct_estatus") = IIf(drow("oct_acum") >= drow("oct_obj"), IIf(drow("oct_obj") > 0, 1, -1), 0)
            drow("nov_estatus") = IIf(drow("nov_acum") >= drow("nov_obj"), IIf(drow("nov_obj") > 0, 1, -1), 0)
            drow("dic_estatus") = IIf(drow("dic_acum") >= drow("dic_obj"), IIf(drow("dic_obj") > 0, 1, -1), 0)
            drow("ene_estatus") = IIf(drow("ene_acum") >= drow("ene_obj"), IIf(drow("ene_obj") > 0, 1, -1), 0)

        Catch ex As Exception

        End Try
    End Sub
    Public Sub FormatoIdeasVacio(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim Obj() As String
        Dim dInfo As DataRow
        Try
            dtDatos.Columns.Add("folio")
            dtDatos.Columns.Add("apellidos")
            dtDatos.Columns.Add("nombre_empleado")
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("nombre_puesto")
            dtDatos.Columns.Add("fecha", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("cod_super")
            dtDatos.Columns.Add("nombre_super")
            dtDatos.Columns.Add("estacion")
            dtDatos.Columns.Add("aprobacion", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("implementacion", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("descripcion")

            dtDatos.Columns.Add("o_prev")
            dtDatos.Columns.Add("califica")
            dtDatos.Columns.Add("objetivo_idea")

            dtDatos.Columns.Add("op")
            dtDatos.Columns.Add("id")
            dtDatos.Columns.Add("pr")
            dtDatos.Columns.Add("ca")
            dtDatos.Columns.Add("co")
            dtDatos.Columns.Add("se")
            dtDatos.Columns.Add("ot")

            dtDatos.Columns.Add("movimi")
            dtDatos.Columns.Add("espera")
            dtDatos.Columns.Add("proces")
            dtDatos.Columns.Add("sobrep")
            dtDatos.Columns.Add("sobrei")
            dtDatos.Columns.Add("transp")
            dtDatos.Columns.Add("correc")

            ' For Each dRow As DataRow In dtInformacion.Rows

            dInfo = dtDatos.NewRow
            dInfo("folio") = ""
            dInfo("reloj") = ""
            'dInfo("fecha") = Nothing
            dInfo("cod_super") = ""
            'dInfo("aprobacion") = Nothing
            'dInfo("implementacion") = Nothing
            dInfo("descripcion") = ""
            dInfo("nombre_puesto") = ""
            dInfo("estacion") = ""

            dInfo("apellidos") = ""
            dInfo("apellidos") = ""
            dInfo("nombre_empleado") = ""

            'dInfo("objetivo_idea") = Split(IIf(Not IsDBNull(dRow("nombre_objetivos")), dRow("nombre_objetivos"), ",,"), ",")(0)

            Dim desperdicios As String() = Split(IIf(Not IsDBNull(dtInformacion.Rows(0).Item("nombre_desperdicios")), dtInformacion.Rows(0).Item("nombre_desperdicios"), ""), ",")

            For i As Integer = 0 To desperdicios.Length - 1
                If desperdicios(i).Length >= 6 Then
                    Select Case desperdicios(i).ToUpper.Trim.Substring(0, 6)
                        Case "MOVIMI"
                            dInfo("MOVIMI") = 1
                        Case "ESPERA"
                            dInfo("ESPERA") = 1
                        Case "PROCES"
                            dInfo("PROCES") = 1
                        Case "SOBREP"
                            dInfo("SOBREP") = 1
                        Case "SOBREI"
                            dInfo("SOBREI") = 1
                        Case "TRANSP"
                            dInfo("TRANSP") = 1
                        Case "CORREC"
                            dInfo("CORREC") = 1
                    End Select
                End If
            Next

            Dim objetivos As String() = Split(IIf(Not IsDBNull(dtInformacion.Rows(0).Item("nombre_objetivos")), dtInformacion.Rows(0).Item("nombre_objetivos"), ""), ",")

            For j As Integer = 0 To objetivos.Length - 1
                If objetivos(j).Length >= 3 Then
                    Select Case objetivos(j).ToUpper.Trim.Substring(0, 2)
                        Case "ID"
                            dInfo("ID") = 1
                        Case "SA"
                            dInfo("SE") = 1
                        Case "CO"
                            dInfo("CO") = 1
                        Case "CA"
                            dInfo("CA") = 1
                        Case "OP"
                            dInfo("OP") = 1
                        Case "PR"
                            dInfo("PR") = 1
                        Case "OT"
                            dInfo("OT") = 1
                    End Select
                End If
            Next

            'dInfo("fecha") = Nothing
            dInfo("nombre_super") = IIf(Not IsDBNull(dtInformacion.Rows(0).Item("nombre_super")), dtInformacion.Rows(0).Item("nombre_super"), "")
            'Letra P para que en el reporte, con el font Wingdings2, se vuelva palomita
            dInfo("o_prev") = IIf(Not IsDBNull(dtInformacion.Rows(0).Item("tipo")), dtInformacion.Rows(0).Item("tipo"), "X")
            dInfo("califica") = IIf(Not IsDBNull(dtInformacion.Rows(0).Item("calificacion")), dtInformacion.Rows(0).Item("calificacion"), "X")
            dtDatos.Rows.Add(dInfo)
            ' Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try
    End Sub
    Public Sub ParticipacionIDOO(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable, Optional planta_obj As String = "")

        ' ya nadamas hay que poner esto en donde decidas que no se quiere generar el reporte, en el catch de la excepcion o en algun IF o asi
        'MensajeError = "Ocurrió un error al generar el reporte de participacion individual"
        'MostrarReporte = False
        Try

            frmSeleccionaMes.ShowDialog()
            Dim FechaIni As Date
            Dim FechaFin As Date
            Dim ano As Integer

            Dim objetivo_anual = 8

            dtDatos = New DataTable
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_super", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_depto", Type.GetType("System.String"))

            dtDatos.Columns.Add("cod_area", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_area", Type.GetType("System.String"))

            dtDatos.Columns.Add("feb_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("mar_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("abr_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("may_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jun_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jul_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ago_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("sep_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("oct_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("nov_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("dic_ideas", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ene_ideas", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("meses", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("objetivo_anual", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("estatus_anual", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("feb_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("mar_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("abr_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("may_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jun_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jul_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ago_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("sep_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("oct_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("nov_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("dic_obj", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ene_obj", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("feb_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("mar_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("abr_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("may_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jun_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jul_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ago_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("sep_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("oct_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("nov_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("dic_estatus", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ene_estatus", Type.GetType("System.Int32"))


            dtDatos.Columns.Add("feb_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("mar_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("abr_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("may_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jun_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jul_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ago_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("sep_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("oct_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("nov_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("dic_acum", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ene_acum", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("feb_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("mar_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("abr_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("may_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jun_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jul_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ago_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("sep_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("oct_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("nov_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("dic_activo", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ene_activo", Type.GetType("System.Int32"))

            dtDatos.Columns.Add("feb_mob", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("mar_mob", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("abr_mob", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("may_mob", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jun_mob", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("jul_mob", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ago_mob", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("sep_mob", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("oct_mob", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("nov_mob", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("dic_mob", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("ene_mob", Type.GetType("System.Int32"))


            dtDatos.Columns.Add("alta_personal", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("baja", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("transferencia", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("reloj_anterior", Type.GetType("System.String"))

            dtDatos.Columns.Add("alta_ideas", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("mes_inicio", Type.GetType("System.String"))

            dtDatos.Columns.Add("fecha_ini", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("fecha_fin", Type.GetType("System.DateTime"))

            dtDatos.Columns.Add("anofiscal", Type.GetType("System.Int32"))
            dtDatos.Columns.Add("mes_proceso", Type.GetType("System.String"))




            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj")}



            Dim relojexclu As String = ""
            Dim dtreloj_exclu As New DataTable
            dtreloj_exclu = sqlExecute("select * from reloj_exclu", "IDEAS")

            For Each dRe As DataRow In dtreloj_exclu.Rows

                relojexclu = relojexclu & dRe("reloj") & ","
            Next

            relojexclu = relojexclu.Remove(relojexclu.Length - 1)


            ano = Year(FechaFinal)
            For Each dRow As DataRow In dtInformacion.Rows
                If Not IsDBNull(dRow("fecha")) Then
                    If Month(dtInformacion.Rows(0).Item("fecha")) = 1 Then
                        ano = Year(dtInformacion.Rows(0).Item("fecha")) - 1
                    Else
                        ano = Year(dtInformacion.Rows(0).Item("fecha"))
                    End If
                    Exit For
                Else
                    If Month(FechaFinal) = 1 Then
                        ano = Year(FechaFinal) - 1
                    Else
                        ano = Year(FechaFinal)
                    End If
                    Exit For
                End If
            Next


            Dim dtperiodos As DataTable
            dtperiodos = sqlExecute("select * from periodos where periodo_especial = 0 and ano = '" & ano & "' and num_mes = '02' order by periodo asc", "ta")
            If dtperiodos.Rows.Count > 0 Then

                Dim TempFinal As String
                Dim TempFecha As String

                TempFinal = FechaSQL(FechaFinal).ToString.Substring(5, 5)
                TempFecha = FechaSQL(FechaInicial).ToString.Substring(5, 5)
                If TempFecha <> "02-01" Or TempFinal <> "01-31" Then
                    MensajeError = "Es necesario cargar el año fiscal"
                    MostrarReporte = False
                    Exit Sub
                End If
            End If

            dtperiodos = sqlExecute("select * from periodos where periodo_especial = 0 and ano = '" & ano + 1 & "' and num_mes = '01' order by periodo desc", "ta")
            If dtperiodos.Rows.Count > 0 Then
                FechaFin = dtperiodos.Rows(0)("fecha_fin")
            End If


            Dim dtMesesTranscurridos As DataTable = sqlExecute("select distinct(lower(substring(mes, 1, 3))) as mes, ano, num_mes from periodos where periodo_especial = 0 and ((ano = '" & ano & "' and num_mes >= '02') or (ano = '" & ano + 1 & "' and num_mes = '01')) and fecha_fin < '" & FechaSQL(Now) & "' and fecha_ini > '" & ano & "-01-01'  GROUP BY ano, mes, num_mes order by ano asc, num_mes asc", "ta")

            Dim dtIdeas As DataTable = dtInformacion.Select("reloj not in(" & relojexclu & ")", "reloj").CopyToDataTable
            Dim dtIdeasTransferencia As DataTable = dtIdeas.Clone

            For Each row As DataRow In dtIdeas.Rows
                AuxiliarIdeasIDOO(row, dtDatos, True, dtMesesTranscurridos, FechaInicial, FechaFinal, ano, dtIdeasTransferencia, planta_obj)
            Next

            For Each row As DataRow In dtIdeasTransferencia.Rows
                AuxiliarIdeasIDOO(row, dtDatos, False, dtMesesTranscurridos, FechaInicial, FechaFinal, ano, dtIdeasTransferencia, planta_obj)
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try

    End Sub

    Private Sub AuxiliarIdeasIDOO(row As DataRow, ByRef DtDatos As DataTable, transferencias As Boolean, dtMesesTranscurridos As DataTable, fechaini As Date, fechafin As Date, Ano As Int32, ByRef dtIdeasTransferencia As DataTable, Optional planta_obj As String = "001")
        Try
            Dim RelojObjetivos As String = ""
            Dim drow As DataRow = DtDatos.Rows.Find(row("reloj"))
            Dim AltaIdeas As Date = Now
            Dim BajaIdeas As Date = Now
            Dim MesFin As Integer = 0
            Dim MesFinal As String = ""
            If drow Is Nothing Then
                drow = DtDatos.NewRow
                RelojObjetivos = row("reloj")
                drow("reloj") = row("reloj")
                drow("anofiscal") = Ano
                drow("mes_proceso") = mesideas.Substring(0, 3)
                DtDatos.Rows.Add(drow)

                drow("nombres") = RTrim(row("nombres"))

                drow("cod_super") = row("cod_super_actual")
                drow("cod_depto") = row("cod_depto_actual")
                drow("cod_area") = row("cod_area_actual")

                drow("nombre_super") = row("nombre_super_actual")
                drow("nombre_depto") = row("nombre_depto_actual")
                drow("nombre_area") = row("nombre_area_actual")

                drow("feb_ideas") = 0
                drow("mar_ideas") = 0
                drow("abr_ideas") = 0
                drow("may_ideas") = 0
                drow("jun_ideas") = 0
                drow("jul_ideas") = 0
                drow("ago_ideas") = 0
                drow("sep_ideas") = 0
                drow("oct_ideas") = 0
                drow("nov_ideas") = 0
                drow("dic_ideas") = 0
                drow("ene_ideas") = 0

                drow("estatus_anual") = 0

                drow("feb_obj") = 0
                drow("mar_obj") = 0
                drow("abr_obj") = 0
                drow("may_obj") = 0
                drow("jun_obj") = 0
                drow("jul_obj") = 0
                drow("ago_obj") = 0
                drow("sep_obj") = 0
                drow("oct_obj") = 0
                drow("nov_obj") = 0
                drow("dic_obj") = 0
                drow("ene_obj") = 0

                drow("feb_acum") = drow("feb_ideas")
                drow("mar_acum") = drow("mar_ideas") + drow("feb_ideas")
                drow("abr_acum") = drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("may_acum") = drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("jun_acum") = drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("jul_acum") = drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("ago_acum") = drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("sep_acum") = drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("oct_acum") = drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("nov_acum") = drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("dic_acum") = drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("ene_acum") = drow("ene_ideas") + drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")

                drow("feb_estatus") = -1
                drow("mar_estatus") = -1
                drow("abr_estatus") = -1
                drow("may_estatus") = -1
                drow("jun_estatus") = -1
                drow("jul_estatus") = -1
                drow("ago_estatus") = -1
                drow("sep_estatus") = -1
                drow("oct_estatus") = -1
                drow("nov_estatus") = -1
                drow("dic_estatus") = -1
                drow("ene_estatus") = -1


                drow("feb_activo") = -1
                drow("mar_activo") = -1
                drow("abr_activo") = -1
                drow("may_activo") = -1
                drow("jun_activo") = -1
                drow("jul_activo") = -1
                drow("ago_activo") = -1
                drow("sep_activo") = -1
                drow("oct_activo") = -1
                drow("nov_activo") = -1
                drow("dic_activo") = -1
                drow("ene_activo") = -1


                drow("feb_mob") = 1
                drow("mar_mob") = 1
                drow("abr_mob") = 1
                drow("may_mob") = 1
                drow("jun_mob") = 1
                drow("jul_mob") = 1
                drow("ago_mob") = 1
                drow("sep_mob") = 1
                drow("oct_mob") = 1
                drow("nov_mob") = 1
                drow("dic_mob") = 1
                drow("ene_mob") = 1
                drow("objetivo_anual") = 0

                For Each mes As DataRow In dtMesesTranscurridos.Rows
                    drow(mes("mes") & "_activo") = 1
                Next

                ' ---------------------------
                drow("baja") = row("baja")
                drow("alta_personal") = row("alta")
                drow("alta_ideas") = row("alta")

                drow("transferencia") = 0
                drow("reloj_anterior") = ""

                If transferencias Then
                    Dim dt_transferencia As DataTable = sqlExecute("select * from transferencias where reloj_nuevo = '" & row("reloj") & "' and alta > alta_anterior")
                    If dt_transferencia.Rows.Count > 0 Then
                        'If Date.Parse(dt_transferencia.Rows(0)("alta_anterior")) > FechaIni Then
                        drow("transferencia") = 1
                        drow("reloj_anterior") = dt_transferencia.Rows(0)("reloj_anterior")
                        drow("alta_ideas") = Date.Parse(dt_transferencia.Rows(0)("alta_anterior"))
                        'End If
                        Dim dtReingreso As DataTable = sqlExecute("select top 1 * from reingresos where reloj =  '" & row("reloj") & "' and alta > '" + FechaSQL(drow("alta_ideas")) + "' order by alta desc")
                        If dtReingreso.Rows.Count > 0 Then
                            drow("alta_ideas") = IIf(IsDBNull(dtReingreso.Rows(0).Item("alta")), drow("alta_ideas"), dtReingreso.Rows(0).Item("alta"))
                        End If

                        Try
                            Dim dtIdeasAgencia As DataTable = sqlExecute("SELECT ideasVW.*,cias.nombre AS COMPANIA,deptos.nombre AS NOMBRE_DEPTO,SUPER.NOMBRE AS NOMBRE_SUPER," & _
                                                                   "AREAS.NOMBRE AS NOMBRE_AREA,puestos.nombre as 'nombre_puesto' FROM IDEASVW " & _
                                                                   "LEFT JOIN personal.dbo.cias ON ideasVW.cod_comp = cias.cod_comp " & _
                                                                   "LEFT JOIN personal.dbo.deptos ON ideasVW.cod_comp = deptos.cod_comp AND ideasVW.cod_depto = deptos.cod_depto " & _
                                                                   "LEFT JOIN personal.dbo.super ON ideasVW.cod_comp = super.cod_comp AND ideasVW.cod_super = super.cod_super " & _
                                                                   "LEFT JOIN personal.dbo.puestos ON ideasVW.cod_comp = puestos.cod_comp AND ideasVW.cod_puesto = puestos.cod_puesto " & _
                                                                   "LEFT JOIN personal.dbo.areas ON ideasVW.cod_comp = areas.cod_comp AND ideasVW.cod_area = areas.cod_area " & _
                                                                   "WHERE fecha BETWEEN '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "' and ideasvw.reloj = '" & dt_transferencia.Rows(0)("reloj_anterior") & "'", "IDEAS")

                            For Each row_agencia As DataRow In dtIdeasAgencia.Rows
                                row_agencia("reloj") = row("reloj")
                                dtIdeasTransferencia.ImportRow(row_agencia)
                            Next

                        Catch ex As Exception

                        End Try


                    End If
                End If
                Dim dtObjetivos As DataTable = sqlExecute("select  * from tabulacion_objetivos where ano = '" + (Ano + 1).ToString + "' and reloj='" + RelojObjetivos + "' and planta = '001'", "IDEAS")
                If Not dtObjetivos.Rows.Count > 0 Then
                    dtObjetivos = sqlExecute("select  * from tabulacion_objetivos where ano = '" + (Ano + 1).ToString + "' and reloj is null and planta = '001'", "IDEAS")
                End If

                If Date.Parse(drow("alta_ideas")) < fechaini Then
                    drow("mes_inicio") = "feb"
                    drow("meses") = 12
                    drow("objetivo_anual") = dtObjetivos.Rows(0).Item("ene")
                Else
                    Dim mes_inicio As Integer = Date.Parse(drow("alta_ideas")).Month
                    Dim dias As Integer = Date.Parse(Ano + 1.ToString & "-01-31").Subtract(Date.Parse(drow("alta_ideas"))).Days
                    ' Dim dias As Integer = Date.Parse(Ano).Subtract(Date.Parse(drow("alta_ideas"))).Days
                    'If dias <= 120 Then
                    '    drow("mes_inicio") = "oct"
                    'ElseIf dias > 120 And dias <= 211 Then
                    '    drow("mes_inicio") = "jul"
                    'ElseIf dias > 211 And dias <= 302 Then
                    '    drow("mes_inicio") = "abr"
                    'ElseIf dias > 302 Then
                    '    drow("mes_inicio") = "feb"
                    'End If
                    If dias <= 60 Then
                        drow("mes_inicio") = "ene"
                        drow("meses") = 0
                        drow("objetivo_anual") = 0
                    ElseIf dias > 60 And dias <= 120 Then
                        drow("mes_inicio") = "oct"
                        drow("meses") = 3
                        drow("objetivo_anual") = 1
                    ElseIf dias > 120 And dias <= 211 Then
                        drow("mes_inicio") = "jul"
                        drow("meses") = 6
                        drow("objetivo_anual") = 2
                    ElseIf dias > 211 And dias <= 302 Then
                        drow("mes_inicio") = "abr"
                        drow("meses") = 9
                        drow("objetivo_anual") = 3
                    ElseIf dias > 302 Then
                        drow("mes_inicio") = "feb"
                        drow("meses") = 12
                        drow("objetivo_anual") = 4
                    End If

                End If

                ' ---------------------------
                Dim prueba1 = drow("alta_ideas")
                Dim Minicio As Integer = Date.Parse(drow("alta_ideas")).Month
                Dim Ainicio As Integer = Date.Parse(drow("alta_ideas")).Year


                If Minicio >= 2 Or Minicio = 1 Then
                    Select Case drow("mes_inicio").ToString
                        Case "feb"
                            drow("feb_obj") = dtObjetivos.Rows(0).Item("feb")
                            drow("mar_obj") = dtObjetivos.Rows(0).Item("mar")
                            drow("abr_obj") = dtObjetivos.Rows(0).Item("abr")
                            drow("may_obj") = dtObjetivos.Rows(0).Item("may")
                            drow("jun_obj") = dtObjetivos.Rows(0).Item("jun")
                            drow("jul_obj") = dtObjetivos.Rows(0).Item("jul")
                            drow("ago_obj") = dtObjetivos.Rows(0).Item("ago")
                            drow("sep_obj") = dtObjetivos.Rows(0).Item("sep")
                            drow("oct_obj") = dtObjetivos.Rows(0).Item("oct")
                            drow("nov_obj") = dtObjetivos.Rows(0).Item("nov")
                            drow("dic_obj") = dtObjetivos.Rows(0).Item("dic")
                            drow("ene_obj") = dtObjetivos.Rows(0).Item("ene")
                        Case "mar"
                            drow("feb_obj") = -1
                            drow("mar_obj") = -1
                            drow("abr_obj") = dtObjetivos.Rows(0).Item("feb")
                            drow("may_obj") = dtObjetivos.Rows(0).Item("mar")
                            drow("jun_obj") = dtObjetivos.Rows(0).Item("abr")
                            drow("jul_obj") = dtObjetivos.Rows(0).Item("may")
                            drow("ago_obj") = dtObjetivos.Rows(0).Item("jun")
                            drow("sep_obj") = dtObjetivos.Rows(0).Item("jul")
                            drow("oct_obj") = dtObjetivos.Rows(0).Item("ago")
                            drow("nov_obj") = dtObjetivos.Rows(0).Item("sep")
                            drow("dic_obj") = dtObjetivos.Rows(0).Item("oct")
                            drow("ene_obj") = dtObjetivos.Rows(0).Item("nov")
                        Case "abr"
                            drow("feb_obj") = -1
                            drow("mar_obj") = -1
                            drow("abr_obj") = -1
                            drow("may_obj") = dtObjetivos.Rows(0).Item("feb")
                            drow("jun_obj") = dtObjetivos.Rows(0).Item("mar")
                            drow("jul_obj") = dtObjetivos.Rows(0).Item("abr")
                            drow("ago_obj") = dtObjetivos.Rows(0).Item("may")
                            drow("sep_obj") = dtObjetivos.Rows(0).Item("jun")
                            drow("oct_obj") = dtObjetivos.Rows(0).Item("jul")
                            drow("nov_obj") = dtObjetivos.Rows(0).Item("ago")
                            drow("dic_obj") = dtObjetivos.Rows(0).Item("sep")
                            drow("ene_obj") = dtObjetivos.Rows(0).Item("oct")
                        Case "may"
                            drow("feb_obj") = -1
                            drow("mar_obj") = -1
                            drow("abr_obj") = -1
                            drow("may_obj") = -1
                            drow("jun_obj") = dtObjetivos.Rows(0).Item("feb")
                            drow("jul_obj") = dtObjetivos.Rows(0).Item("mar")
                            drow("ago_obj") = dtObjetivos.Rows(0).Item("abr")
                            drow("sep_obj") = dtObjetivos.Rows(0).Item("may")
                            drow("oct_obj") = dtObjetivos.Rows(0).Item("jun")
                            drow("nov_obj") = dtObjetivos.Rows(0).Item("jul")
                            drow("dic_obj") = dtObjetivos.Rows(0).Item("ago")
                            drow("ene_obj") = dtObjetivos.Rows(0).Item("sep")
                        Case "jun"
                            drow("feb_obj") = -1
                            drow("mar_obj") = -1
                            drow("abr_obj") = -1
                            drow("may_obj") = -1
                            drow("jun_obj") = -1
                            drow("jul_obj") = dtObjetivos.Rows(0).Item("feb")
                            drow("ago_obj") = dtObjetivos.Rows(0).Item("mar")
                            drow("sep_obj") = dtObjetivos.Rows(0).Item("abr")
                            drow("oct_obj") = dtObjetivos.Rows(0).Item("may")
                            drow("nov_obj") = dtObjetivos.Rows(0).Item("jun")
                            drow("dic_obj") = dtObjetivos.Rows(0).Item("jul")
                            drow("ene_obj") = dtObjetivos.Rows(0).Item("ago")
                        Case "jul"
                            drow("feb_obj") = -1
                            drow("mar_obj") = -1
                            drow("abr_obj") = -1
                            drow("may_obj") = -1
                            drow("jun_obj") = -1
                            drow("jul_obj") = -1
                            drow("ago_obj") = dtObjetivos.Rows(0).Item("feb")
                            drow("sep_obj") = dtObjetivos.Rows(0).Item("mar")
                            drow("oct_obj") = dtObjetivos.Rows(0).Item("abr")
                            drow("nov_obj") = dtObjetivos.Rows(0).Item("may")
                            drow("dic_obj") = dtObjetivos.Rows(0).Item("jun")
                            drow("ene_obj") = dtObjetivos.Rows(0).Item("jul")
                        Case "ago"
                            drow("feb_obj") = -1
                            drow("mar_obj") = -1
                            drow("abr_obj") = -1
                            drow("may_obj") = -1
                            drow("jun_obj") = -1
                            drow("jul_obj") = -1
                            drow("ago_obj") = -1
                            drow("sep_obj") = dtObjetivos.Rows(0).Item("feb")
                            drow("oct_obj") = dtObjetivos.Rows(0).Item("mar")
                            drow("nov_obj") = dtObjetivos.Rows(0).Item("abr")
                            drow("dic_obj") = dtObjetivos.Rows(0).Item("may")
                            drow("ene_obj") = dtObjetivos.Rows(0).Item("jun")
                        Case "sep"
                            drow("feb_obj") = -1
                            drow("mar_obj") = -1
                            drow("abr_obj") = -1
                            drow("may_obj") = -1
                            drow("jun_obj") = -1
                            drow("jul_obj") = -1
                            drow("ago_obj") = -1
                            drow("sep_obj") = -1
                            drow("oct_obj") = dtObjetivos.Rows(0).Item("feb")
                            drow("nov_obj") = dtObjetivos.Rows(0).Item("mar")
                            drow("dic_obj") = dtObjetivos.Rows(0).Item("abr")
                            drow("ene_obj") = dtObjetivos.Rows(0).Item("may")
                        Case "oct"
                            drow("feb_obj") = -1
                            drow("mar_obj") = -1
                            drow("abr_obj") = -1
                            drow("may_obj") = -1
                            drow("jun_obj") = -1
                            drow("jul_obj") = -1
                            drow("ago_obj") = -1
                            drow("sep_obj") = -1
                            drow("oct_obj") = -1
                            drow("nov_obj") = dtObjetivos.Rows(0).Item("feb")
                            drow("dic_obj") = dtObjetivos.Rows(0).Item("mar")
                            drow("ene_obj") = dtObjetivos.Rows(0).Item("abr")
                        Case "nov"
                            drow("feb_obj") = -1
                            drow("mar_obj") = -1
                            drow("abr_obj") = -1
                            drow("may_obj") = -1
                            drow("jun_obj") = -1
                            drow("jul_obj") = -1
                            drow("ago_obj") = -1
                            drow("sep_obj") = -1
                            drow("oct_obj") = -1
                            drow("nov_obj") = -1
                            drow("dic_obj") = dtObjetivos.Rows(0).Item("feb")
                            drow("ene_obj") = dtObjetivos.Rows(0).Item("mar")
                        Case "dic"
                            drow("feb_obj") = -1
                            drow("mar_obj") = -1
                            drow("abr_obj") = -1
                            drow("may_obj") = -1
                            drow("jun_obj") = -1
                            drow("jul_obj") = -1
                            drow("ago_obj") = -1
                            drow("sep_obj") = -1
                            drow("oct_obj") = -1
                            drow("nov_obj") = -1
                            drow("dic_obj") = -1
                            drow("ene_obj") = dtObjetivos.Rows(0).Item("feb")
                        Case "ene"
                            drow("feb_obj") = -1
                            drow("mar_obj") = -1
                            drow("abr_obj") = -1
                            drow("may_obj") = -1
                            drow("jun_obj") = -1
                            drow("jul_obj") = -1
                            drow("ago_obj") = -1
                            drow("sep_obj") = -1
                            drow("oct_obj") = -1
                            drow("nov_obj") = -1
                            drow("dic_obj") = -1
                            drow("ene_obj") = -1
                    End Select


                Else
                    drow("feb_obj") = dtObjetivos.Rows(0).Item("feb")
                    drow("mar_obj") = dtObjetivos.Rows(0).Item("mar")
                    drow("abr_obj") = dtObjetivos.Rows(0).Item("abr")
                    drow("may_obj") = dtObjetivos.Rows(0).Item("may")
                    drow("jun_obj") = dtObjetivos.Rows(0).Item("jun")
                    drow("jul_obj") = dtObjetivos.Rows(0).Item("jul")
                    drow("ago_obj") = dtObjetivos.Rows(0).Item("ago")
                    drow("sep_obj") = dtObjetivos.Rows(0).Item("sep")
                    drow("oct_obj") = dtObjetivos.Rows(0).Item("oct")
                    drow("nov_obj") = dtObjetivos.Rows(0).Item("nov")
                    drow("dic_obj") = dtObjetivos.Rows(0).Item("dic")
                    drow("ene_obj") = dtObjetivos.Rows(0).Item("ene")

                End If


                Dim mes_actual As Integer = 0
                If Date.Now > Date.Parse(Ano + 1 & "-01-31") Then
                    mes_actual = 1
                Else
                    mes_actual = Date.Parse(Date.Now).Month
                End If


                Select Case mes_actual
                    Case 2
                        drow("feb_activo") = 1
                        drow("mar_activo") = 0
                        drow("abr_activo") = 0
                        drow("may_activo") = 0
                        drow("jun_activo") = 0
                        drow("jul_activo") = 0
                        drow("ago_activo") = 0
                        drow("sep_activo") = 0
                        drow("oct_activo") = 0
                        drow("nov_activo") = 0
                        drow("dic_activo") = 0
                        drow("ene_activo") = 0
                    Case 3
                        drow("feb_activo") = 1
                        drow("mar_activo") = 1
                        drow("abr_activo") = 0
                        drow("may_activo") = 0
                        drow("jun_activo") = 0
                        drow("jul_activo") = 0
                        drow("ago_activo") = 0
                        drow("sep_activo") = 0
                        drow("oct_activo") = 0
                        drow("nov_activo") = 0
                        drow("dic_activo") = 0
                        drow("ene_activo") = 0
                    Case 4
                        drow("feb_activo") = 1
                        drow("mar_activo") = 1
                        drow("abr_activo") = 1
                        drow("may_activo") = 0
                        drow("jun_activo") = 0
                        drow("jul_activo") = 0
                        drow("ago_activo") = 0
                        drow("sep_activo") = 0
                        drow("oct_activo") = 0
                        drow("nov_activo") = 0
                        drow("dic_activo") = 0
                        drow("ene_activo") = 0
                    Case 5
                        drow("feb_activo") = 1
                        drow("mar_activo") = 1
                        drow("abr_activo") = 1
                        drow("may_activo") = 1
                        drow("jun_activo") = 0
                        drow("jul_activo") = 0
                        drow("ago_activo") = 0
                        drow("sep_activo") = 0
                        drow("oct_activo") = 0
                        drow("nov_activo") = 0
                        drow("dic_activo") = 0
                        drow("ene_activo") = 0
                    Case 6
                        drow("feb_activo") = 1
                        drow("mar_activo") = 1
                        drow("abr_activo") = 1
                        drow("may_activo") = 1
                        drow("jun_activo") = 1
                        drow("jul_activo") = 0
                        drow("ago_activo") = 0
                        drow("sep_activo") = 0
                        drow("oct_activo") = 0
                        drow("nov_activo") = 0
                        drow("dic_activo") = 0
                        drow("ene_activo") = 0
                    Case 7
                        drow("feb_activo") = 1
                        drow("mar_activo") = 1
                        drow("abr_activo") = 1
                        drow("may_activo") = 1
                        drow("jun_activo") = 1
                        drow("jul_activo") = 1
                        drow("ago_activo") = 0
                        drow("sep_activo") = 0
                        drow("oct_activo") = 0
                        drow("nov_activo") = 0
                        drow("dic_activo") = 0
                        drow("ene_activo") = 0
                    Case 8
                        drow("feb_activo") = 1
                        drow("mar_activo") = 1
                        drow("abr_activo") = 1
                        drow("may_activo") = 1
                        drow("jun_activo") = 1
                        drow("jul_activo") = 1
                        drow("ago_activo") = 1
                        drow("sep_activo") = 0
                        drow("oct_activo") = 0
                        drow("nov_activo") = 0
                        drow("dic_activo") = 0
                        drow("ene_activo") = 0
                    Case 9
                        drow("feb_activo") = 1
                        drow("mar_activo") = 1
                        drow("abr_activo") = 1
                        drow("may_activo") = 1
                        drow("jun_activo") = 1
                        drow("jul_activo") = 1
                        drow("ago_activo") = 1
                        drow("sep_activo") = 1
                        drow("oct_activo") = 0
                        drow("nov_activo") = 0
                        drow("dic_activo") = 0
                        drow("ene_activo") = 0
                    Case 10
                        drow("feb_activo") = 1
                        drow("mar_activo") = 1
                        drow("abr_activo") = 1
                        drow("may_activo") = 1
                        drow("jun_activo") = 1
                        drow("jul_activo") = 1
                        drow("ago_activo") = 1
                        drow("sep_activo") = 1
                        drow("oct_activo") = 1
                        drow("nov_activo") = 0
                        drow("dic_activo") = 0
                        drow("ene_activo") = 0
                    Case 11
                        drow("feb_activo") = 1
                        drow("mar_activo") = 1
                        drow("abr_activo") = 1
                        drow("may_activo") = 1
                        drow("jun_activo") = 1
                        drow("jul_activo") = 1
                        drow("ago_activo") = 1
                        drow("sep_activo") = 1
                        drow("oct_activo") = 1
                        drow("nov_activo") = 1
                        drow("dic_activo") = 0
                        drow("ene_activo") = 0
                    Case 12
                        drow("feb_activo") = 1
                        drow("mar_activo") = 1
                        drow("abr_activo") = 1
                        drow("may_activo") = 1
                        drow("jun_activo") = 1
                        drow("jul_activo") = 1
                        drow("ago_activo") = 1
                        drow("sep_activo") = 1
                        drow("oct_activo") = 1
                        drow("nov_activo") = 1
                        drow("dic_activo") = 1
                        drow("ene_activo") = 0
                    Case 1
                        drow("feb_activo") = 1
                        drow("mar_activo") = 1
                        drow("abr_activo") = 1
                        drow("may_activo") = 1
                        drow("jun_activo") = 1
                        drow("jul_activo") = 1
                        drow("ago_activo") = 1
                        drow("sep_activo") = 1
                        drow("oct_activo") = 1
                        drow("nov_activo") = 1
                        drow("dic_activo") = 1
                        drow("ene_activo") = 1
                End Select


                '------------------------------------------------------------------------------------------------------------------------------------------
                drow("fecha_ini") = fechaini
                drow("fecha_fin") = fechafin
            End If

            ' ------------------------------------------------------------------------------------------------------------------------------------------------------


            Try
                If Not IsDBNull(row("fecha")) Then
                    Dim mesidea As String = Date.Parse(row("fecha")).Month.ToString
                    Dim anoidea As String = Date.Parse(row("fecha")).Year.ToString
                    Dim mesletra As String = ""
                    Select Case mesidea
                        Case "2"
                            mesletra = "feb"
                        Case "3"
                            mesletra = "mar"
                        Case "4"
                            mesletra = "abr"
                        Case "5"
                            mesletra = "may"
                        Case "6"
                            mesletra = "jun"
                        Case "7"
                            mesletra = "jul"
                        Case "8"
                            mesletra = "ago"
                        Case "9"
                            mesletra = "sep"
                        Case "10"
                            mesletra = "oct"
                        Case "11"
                            mesletra = "nov"
                        Case "12"
                            mesletra = "dic"
                        Case "1"
                            mesletra = "ene"
                    End Select

                    drow(mesletra & "_ideas") = drow(mesletra & "_ideas") + 1
                Else
                    drow(row("mes_implementacion") & "_ideas") = drow(row("mes_implementacion") & "_ideas") + 1
                End If







                drow("estatus_anual") =
                drow("feb_ideas") +
                drow("mar_ideas") +
                drow("abr_ideas") +
                drow("may_ideas") +
                drow("jun_ideas") +
                drow("jul_ideas") +
                drow("ago_ideas") +
                drow("sep_ideas") +
                drow("oct_ideas") +
                drow("nov_ideas") +
                drow("dic_ideas") +
                drow("ene_ideas")


                drow("feb_acum") = drow("feb_ideas")
                drow("mar_acum") = drow("mar_ideas") + drow("feb_ideas")
                drow("abr_acum") = drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("may_acum") = drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("jun_acum") = drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("jul_acum") = drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("ago_acum") = drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("sep_acum") = drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("oct_acum") = drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("nov_acum") = drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("dic_acum") = drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
                drow("ene_acum") = drow("ene_ideas") + drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try


        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
    End Sub

    Public Sub SugerenciasObjetivos(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim Obj() As String
        Dim dInfo As DataRow
        Try
            dtDatos.Columns.Add("folio")
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("cod_depto")
            dtDatos.Columns.Add("cod_puesto")
            dtDatos.Columns.Add("cod_super")
            dtDatos.Columns.Add("nombre_estacion")
            dtDatos.Columns.Add("implementacion", GetType(System.DateTime))
            dtDatos.Columns.Add("envio_nomina", GetType(System.DateTime))
            dtDatos.Columns.Add("estatus")
            dtDatos.Columns.Add("nombre_objetivo")
            dtDatos.Columns.Add("objetivo")

            For Each dRow As DataRow In dtInformacion.Rows
                Obj = dRow("nombre_objetivos").ToString.Split(",")
                For Each ob In Obj
                    If ob.Trim <> "" Then
                        dInfo = dtDatos.NewRow
                        dInfo("folio") = dRow("folio")
                        dInfo("reloj") = dRow("reloj")
                        dInfo("nombres") = dRow("nombres")
                        dInfo("cod_depto") = dRow("cod_depto")
                        dInfo("cod_puesto") = dRow("cod_puesto")
                        dInfo("cod_super") = dRow("cod_super")
                        dInfo("nombre_estacion") = dRow("nombre_estacion")
                        dInfo("implementacion") = dRow("implementacion")
                        dInfo("envio_nomina") = dRow("envio_nomina")
                        dInfo("estatus") = dRow("estatus")

                        dInfo("nombre_objetivo") = ob.Trim
                        'Letra P para que en el reporte, con el font Wingdings2, se vuelva palomita
                        dInfo("objetivo") = "P"
                        dtDatos.Rows.Add(dInfo)
                    End If
                Next
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try
    End Sub
    Public Sub FormatoIdeas(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim Obj() As String
        Dim dInfo As DataRow
        Try
            dtDatos.Columns.Add("folio")
            dtDatos.Columns.Add("apellidos")
            dtDatos.Columns.Add("nombre_empleado")
            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("nombre_puesto")
            dtDatos.Columns.Add("fecha", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("cod_super")
            dtDatos.Columns.Add("nombre_super")
            dtDatos.Columns.Add("estacion")
            dtDatos.Columns.Add("aprobacion", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("implementacion", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("descripcion")

            dtDatos.Columns.Add("IDEA")
            dtDatos.Columns.Add("PROBLEMA")
            dtDatos.Columns.Add("RESULTADO")

            dtDatos.Columns.Add("o_prev")
            dtDatos.Columns.Add("califica")
            dtDatos.Columns.Add("objetivo_idea")

            dtDatos.Columns.Add("op")
            dtDatos.Columns.Add("id")
            dtDatos.Columns.Add("pr")
            dtDatos.Columns.Add("ca")
            dtDatos.Columns.Add("co")
            dtDatos.Columns.Add("se")
            dtDatos.Columns.Add("ot")

            dtDatos.Columns.Add("movimi")
            dtDatos.Columns.Add("espera")
            dtDatos.Columns.Add("proces")
            dtDatos.Columns.Add("sobrep")
            dtDatos.Columns.Add("sobrei")
            dtDatos.Columns.Add("transp")
            dtDatos.Columns.Add("correc")

            dtDatos.Columns.Add("calif")
            dtDatos.Columns.Add("area_a")

            For Each dRow As DataRow In dtInformacion.Rows

                dInfo = dtDatos.NewRow
                dInfo("folio") = dRow("folio")
                dInfo("reloj") = dRow("reloj")
                dInfo("fecha") = dRow("fecha")
                dInfo("cod_super") = dRow("cod_super")
                dInfo("aprobacion") = dRow("aprobacion")
                dInfo("implementacion") = dRow("implementacion")
                dInfo("descripcion") = IIf(Not IsDBNull(dRow("descripcion")), dRow("descripcion"), "")

                dInfo("IDEA") = IIf(Not IsDBNull(dRow("IDEA")), dRow("IDEA"), "")
                dInfo("PROBLEMA") = IIf(Not IsDBNull(dRow("PROBLEMA")), dRow("PROBLEMA"), "")
                dInfo("RESULTADO") = IIf(Not IsDBNull(dRow("RESULTADO")), dRow("RESULTADO"), "")

                dInfo("nombre_puesto") = dRow("nombre_puesto")
                dInfo("estacion") = IIf(Not IsDBNull(dRow("nombre_estacion")), dRow("nombre_estacion"), "")

                dInfo("apellidos") = Split(IIf(Not IsDBNull(dRow("nombres")), dRow("nombres"), ",,"), ",")(0)
                dInfo("apellidos") = dInfo("apellidos") & " " & Split(IIf(Not IsDBNull(dRow("nombres")), dRow("nombres"), ",,"), ",")(1)
                dInfo("nombre_empleado") = Split(IIf(Not IsDBNull(dRow("nombres")), dRow("nombres"), ",,"), ",")(2)



                If Not IsDBNull(dRow("cod_area_a")) Then
                    Dim dttemp As New DataTable
                    dttemp = sqlExecute("select nombre from areas where cod_area = '" & dRow("cod_area_a") & "' and cod_comp = '090'")
                    If dttemp.Rows.Count > 0 Then
                        dInfo("area_a") = dttemp.Rows(0).Item("nombre")
                    Else
                        dInfo("area_a") = "X"
                    End If

                End If




                'dInfo("objetivo_idea") = Split(IIf(Not IsDBNull(dRow("nombre_objetivos")), dRow("nombre_objetivos"), ",,"), ",")(0)

                Dim desperdicios As String() = Split(IIf(Not IsDBNull(dRow("nombre_desperdicios")), dRow("nombre_desperdicios"), ""), ",")

                For i As Integer = 0 To desperdicios.Length - 1
                    If desperdicios(i).Length >= 6 Then
                        Select Case desperdicios(i).ToUpper.Trim.Substring(0, 6)
                            Case "MOVIMI"
                                dInfo("MOVIMI") = 1
                            Case "ESPERA"
                                dInfo("ESPERA") = 1
                            Case "PROCES"
                                dInfo("PROCES") = 1
                            Case "SOBREP"
                                dInfo("SOBREP") = 1
                            Case "SOBREI"
                                dInfo("SOBREI") = 1
                            Case "TRANSP"
                                dInfo("TRANSP") = 1
                            Case "CORREC"
                                dInfo("CORREC") = 1
                        End Select
                    End If
                Next

                Dim objetivos As String() = Split(IIf(Not IsDBNull(dRow("nombre_objetivos")), dRow("nombre_objetivos"), ""), ",")

                For j As Integer = 0 To objetivos.Length - 1
                    If objetivos(j).Length >= 3 Then
                        Select Case objetivos(j).ToUpper.Trim.Substring(0, 2)
                            Case "ID"
                                dInfo("ID") = 1
                            Case "SA"
                                dInfo("SE") = 1
                            Case "CO"
                                dInfo("CO") = 1
                            Case "CA"
                                dInfo("CA") = 1
                            Case "OP"
                                dInfo("OP") = 1
                            Case "PR"
                                dInfo("PR") = 1
                            Case "OT"
                                dInfo("OT") = 1
                        End Select
                    End If
                Next

                dInfo("fecha") = dRow("fecha")
                dInfo("nombre_super") = IIf(Not IsDBNull(dRow("nombre_super")), dRow("nombre_super"), "")
                'Letra P para que en el reporte, con el font Wingdings2, se vuelva palomita
                dInfo("o_prev") = IIf(Not IsDBNull(dRow("tipo")), dRow("tipo"), "X")
                dInfo("califica") = IIf(Not IsDBNull(dRow("calificacion")), dRow("calificacion"), "X")
                dInfo("calif") = IIf(Not IsDBNull(dRow("calif")), dRow("calif"), "0")
                dtDatos.Rows.Add(dInfo)
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try
    End Sub
    Public Sub IdeasPagadas(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Dim dIdea As DataRow
        Try

            dtDatos.Columns.Add("reloj")
            dtDatos.Columns.Add("nombres")
            dtDatos.Columns.Add("folio")
            dtDatos.Columns.Add("monto", GetType(System.Double))

            For Each dRow As DataRow In dtInformacion.Select("NOT pagada IS NULL")
                dIdea = dtDatos.NewRow
                dIdea("reloj") = dRow("reloj")
                dIdea("nombres") = dRow("nombres")
                dIdea("folio") = dRow("folio")
                dtTemporal = sqlExecute("SELECT monto FROM ajustes_nom WHERE ajustes_nom.reloj = '" & dRow("RELOJ").ToString.Trim & _
                                        "' and ano+periodo = '" & dRow("pagada") & "' and concepto = 'IDEAS' AND ajustes_nom.numcredito = '" & dRow("FOLIO") & "'", "nomina")
                If dtTemporal.Rows.Count = 0 Then
                    dIdea("monto") = 0
                Else
                    dIdea("monto") = IIf(IsDBNull(dtTemporal.Rows(0).Item("monto")), 0, dtTemporal.Rows(0).Item("monto"))
                End If

                dtDatos.Rows.Add(dIdea)
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
            dtDatos = New DataTable
        End Try
    End Sub

#End Region


#Region "Omitir"

    Public Sub ParticipacionIdeasBAk(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

        Dim FechaIni As Date
        Dim FechaFin As Date
        Dim ano As Integer

        Dim objetivo_anual = 8

        dtDatos = New DataTable
        dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

        dtDatos.Columns.Add("cod_super", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))

        dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
        dtDatos.Columns.Add("nombre_depto", Type.GetType("System.String"))

        dtDatos.Columns.Add("feb_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_ideas", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_ideas", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("meses", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("objetivo_anual", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("estatus_anual", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("feb_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_obj", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_obj", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("feb_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_estatus", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_estatus", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("feb_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_acum", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_acum", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("feb_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("mar_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("abr_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("may_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jun_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("jul_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ago_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("sep_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("oct_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("nov_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("dic_activo", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("ene_activo", Type.GetType("System.Int32"))

        dtDatos.Columns.Add("alta_personal", Type.GetType("System.DateTime"))

        dtDatos.Columns.Add("transferencia", Type.GetType("System.Int32"))
        dtDatos.Columns.Add("reloj_anterior", Type.GetType("System.String"))

        dtDatos.Columns.Add("alta_ideas", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("mes_inicio", Type.GetType("System.String"))

        dtDatos.Columns.Add("fecha_ini", Type.GetType("System.DateTime"))
        dtDatos.Columns.Add("fecha_fin", Type.GetType("System.DateTime"))

        dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj")}


        ano = Year(FechaFinal)
        For Each dRow As DataRow In dtInformacion.Rows
            If Not IsDBNull(dRow("fecha")) Then
                If Month(dtInformacion.Rows(0).Item("fecha")) = 1 Then
                    ano = Year(dtInformacion.Rows(0).Item("fecha")) - 1
                Else
                    ano = Year(dtInformacion.Rows(0).Item("fecha"))
                End If
                Exit For
            Else
                If Month(FechaFinal) = 1 Then
                    ano = Year(FechaFinal) - 1
                Else
                    ano = Year(FechaFinal)
                End If
                Exit For
            End If
        Next

        Dim dtperiodos As DataTable
        dtperiodos = sqlExecute("select * from periodos where periodo_especial = 0 and ano = '" & ano & "' and num_mes = '02' order by periodo asc", "ta")
        If dtperiodos.Rows.Count > 0 Then
            FechaIni = dtperiodos.Rows(0)("fecha_ini")
        End If

        dtperiodos = sqlExecute("select * from periodos where periodo_especial = 0 and ano = '" & ano + 1 & "' and num_mes = '01' order by periodo desc", "ta")
        If dtperiodos.Rows.Count > 0 Then
            FechaFin = dtperiodos.Rows(0)("fecha_fin")
        End If


        Dim dtMesesTranscurridos As DataTable = sqlExecute("select distinct(lower(substring(mes, 1, 3))) as mes, ano, num_mes from periodos where periodo_especial = 0 and ((ano = '" & ano & "' and num_mes >= '02') or (ano = '" & ano + 1 & "' and num_mes = '01')) and fecha_fin < '" & FechaSQL(Now) & "' GROUP BY ano, mes, num_mes order by ano asc, num_mes asc", "ta")

        Dim dtIdeas As DataTable = dtInformacion.Select("", "reloj").CopyToDataTable
        Dim dtIdeasTransferencia As DataTable = dtIdeas.Clone

        For Each row As DataRow In dtIdeas.Rows
            AuxiliarIdeas(row, dtDatos, True, dtMesesTranscurridos, FechaIni, FechaFin, objetivo_anual, dtIdeasTransferencia)
        Next

        For Each row As DataRow In dtIdeasTransferencia.Rows
            AuxiliarIdeas(row, dtDatos, False, dtMesesTranscurridos, FechaIni, FechaFin, objetivo_anual, dtIdeasTransferencia)
        Next




    End Sub

#Region "Backup Procedimientos"
    'Public Sub ParticipacionIdeasCBajas(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)

    '    Dim FechaIni As Date
    '    Dim FechaFin As Date
    '    Dim ano As Integer

    '    Dim objetivo_anual = 8

    '    dtDatos = New DataTable
    '    dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
    '    dtDatos.Columns.Add("nombres", Type.GetType("System.String"))

    '    dtDatos.Columns.Add("cod_super", Type.GetType("System.String"))
    '    dtDatos.Columns.Add("nombre_super", Type.GetType("System.String"))

    '    dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
    '    dtDatos.Columns.Add("nombre_depto", Type.GetType("System.String"))

    '    dtDatos.Columns.Add("cod_super_original", Type.GetType("System.String"))
    '    dtDatos.Columns.Add("nombre_super_origina", Type.GetType("System.String"))

    '    dtDatos.Columns.Add("cod_depto_original", Type.GetType("System.String"))
    '    dtDatos.Columns.Add("nombre_depto_origina", Type.GetType("System.String"))

    '    dtDatos.Columns.Add("baja", Type.GetType("System.String"))

    '    dtDatos.Columns.Add("feb_ideas", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("mar_ideas", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("abr_ideas", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("may_ideas", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("jun_ideas", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("jul_ideas", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("ago_ideas", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("sep_ideas", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("oct_ideas", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("nov_ideas", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("dic_ideas", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("ene_ideas", Type.GetType("System.Int32"))

    '    dtDatos.Columns.Add("meses", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("objetivo_anual", Type.GetType("System.Int32"))

    '    dtDatos.Columns.Add("estatus_anual", Type.GetType("System.Int32"))

    '    dtDatos.Columns.Add("feb_obj", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("mar_obj", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("abr_obj", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("may_obj", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("jun_obj", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("jul_obj", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("ago_obj", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("sep_obj", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("oct_obj", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("nov_obj", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("dic_obj", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("ene_obj", Type.GetType("System.Int32"))

    '    dtDatos.Columns.Add("feb_estatus", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("mar_estatus", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("abr_estatus", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("may_estatus", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("jun_estatus", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("jul_estatus", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("ago_estatus", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("sep_estatus", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("oct_estatus", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("nov_estatus", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("dic_estatus", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("ene_estatus", Type.GetType("System.Int32"))

    '    dtDatos.Columns.Add("feb_acum", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("mar_acum", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("abr_acum", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("may_acum", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("jun_acum", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("jul_acum", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("ago_acum", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("sep_acum", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("oct_acum", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("nov_acum", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("dic_acum", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("ene_acum", Type.GetType("System.Int32"))

    '    dtDatos.Columns.Add("feb_activo", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("mar_activo", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("abr_activo", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("may_activo", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("jun_activo", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("jul_activo", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("ago_activo", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("sep_activo", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("oct_activo", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("nov_activo", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("dic_activo", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("ene_activo", Type.GetType("System.Int32"))

    '    dtDatos.Columns.Add("alta_personal", Type.GetType("System.DateTime"))

    '    dtDatos.Columns.Add("transferencia", Type.GetType("System.Int32"))
    '    dtDatos.Columns.Add("reloj_anterior", Type.GetType("System.String"))

    '    dtDatos.Columns.Add("alta_ideas", Type.GetType("System.DateTime"))
    '    dtDatos.Columns.Add("mes_inicio", Type.GetType("System.String"))

    '    dtDatos.Columns.Add("fecha_ini", Type.GetType("System.DateTime"))
    '    dtDatos.Columns.Add("fecha_fin", Type.GetType("System.DateTime"))

    '    dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj")}

    '    ano = Year(Now)
    '    For Each dRow As DataRow In dtInformacion.Rows
    '        If Not IsDBNull(dRow("fecha")) Then
    '            If Month(dtInformacion.Rows(0).Item("fecha")) = 1 Then
    '                ano = Year(dtInformacion.Rows(0).Item("fecha")) - 1
    '            Else
    '                ano = Year(dtInformacion.Rows(0).Item("fecha"))
    '            End If
    '            Exit For
    '        Else
    '            If Month(Now) = 1 Then
    '                ano = Year(Now) - 1
    '            Else
    '                ano = Year(Now)
    '            End If
    '            Exit For
    '        End If
    '    Next

    '    Dim dtperiodos As DataTable
    '    dtperiodos = sqlExecute("select * from periodos where periodo_especial = 0 and ano = '" & ano & "' and num_mes = '02' order by periodo asc", "ta")
    '    If dtperiodos.Rows.Count > 0 Then
    '        FechaIni = dtperiodos.Rows(0)("fecha_ini")
    '    End If

    '    dtperiodos = sqlExecute("select * from periodos where periodo_especial = 0 and ano = '" & ano + 1 & "' and num_mes = '01' order by periodo desc", "ta")
    '    If dtperiodos.Rows.Count > 0 Then
    '        FechaFin = dtperiodos.Rows(0)("fecha_fin")
    '    End If


    '    Dim dtMesesTranscurridos As DataTable = sqlExecute("select distinct(lower(substring(mes, 1, 3))) as mes, ano, num_mes from periodos where periodo_especial = 0 and ((ano = '" & ano & "' and num_mes >= '02') or (ano = '" & ano + 1 & "' and num_mes = '" & 1 & "')) and fecha_fin < '" & FechaSQL(Now) & "' GROUP BY ano, mes, num_mes order by ano asc, num_mes asc", "ta")

    '    Dim dtIdeas As DataTable = dtInformacion.Select("", "reloj").CopyToDataTable
    '    Dim dtIdeasTransferencia As DataTable = dtIdeas.Clone

    '    For Each row As DataRow In dtIdeas.Rows
    '        AuxiliarIdeasCbajas(row, dtDatos, True, dtMesesTranscurridos, FechaIni, FechaFin, objetivo_anual, dtIdeasTransferencia)
    '    Next

    '    For Each row As DataRow In dtIdeasTransferencia.Rows
    '        AuxiliarIdeasCbajas(row, dtDatos, False, dtMesesTranscurridos, FechaIni, FechaFin, objetivo_anual, dtIdeasTransferencia)
    '    Next




    'End Sub

    'Private Sub AuxiliarIdeas(row As DataRow, ByRef DtDatos As DataTable, transferencias As Boolean, dtMesesTranscurridos As DataTable, fechaini As Date, fechafin As Date, objetivo_anual As Int32, ByRef dtIdeasTransferencia As DataTable)
    '    Try
    '        Dim Llaves(1) As Object
    '        Llaves(0) = row("reloj")
    '        Llaves(1) = row("cod_depto")

    '        Dim drow As DataRow = DtDatos.Rows.Find(Llaves)
    '        Dim AltaIdeas As Date = Nothing
    '        Dim BajaIdeas As Date = Nothing
    '        Dim MesFin As Integer = 0
    '        Dim MesFinal As String = ""
    '        If drow Is Nothing Then
    '            drow = DtDatos.NewRow

    '            drow("reloj") = row("reloj")
    '            drow("cod_depto") = row("cod_depto")
    '            DtDatos.Rows.Add(drow)

    '            drow("nombres") = RTrim(row("nombres"))

    '            drow("cod_super") = row("cod_super")


    '            drow("nombre_super") = row("nombre_super")
    '            drow("nombre_depto") = row("nombre_depto")

    '            drow("feb_ideas") = 0
    '            drow("mar_ideas") = 0
    '            drow("abr_ideas") = 0
    '            drow("may_ideas") = 0
    '            drow("jun_ideas") = 0
    '            drow("jul_ideas") = 0
    '            drow("ago_ideas") = 0
    '            drow("sep_ideas") = 0
    '            drow("oct_ideas") = 0
    '            drow("nov_ideas") = 0
    '            drow("dic_ideas") = 0
    '            drow("ene_ideas") = 0

    '            drow("estatus_anual") = 0

    '            drow("feb_obj") = 0
    '            drow("mar_obj") = 0
    '            drow("abr_obj") = 0
    '            drow("may_obj") = 0
    '            drow("jun_obj") = 0
    '            drow("jul_obj") = 0
    '            drow("ago_obj") = 0
    '            drow("sep_obj") = 0
    '            drow("oct_obj") = 0
    '            drow("nov_obj") = 0
    '            drow("dic_obj") = 0
    '            drow("ene_obj") = 0

    '            drow("feb_acum") = drow("feb_ideas")
    '            drow("mar_acum") = drow("mar_ideas") + drow("feb_ideas")
    '            drow("abr_acum") = drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '            drow("may_acum") = drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '            drow("jun_acum") = drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '            drow("jul_acum") = drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '            drow("ago_acum") = drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '            drow("sep_acum") = drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '            drow("oct_acum") = drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '            drow("nov_acum") = drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '            drow("dic_acum") = drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '            drow("ene_acum") = drow("ene_ideas") + drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")

    '            drow("feb_estatus") = -1
    '            drow("mar_estatus") = -1
    '            drow("abr_estatus") = -1
    '            drow("may_estatus") = -1
    '            drow("jun_estatus") = -1
    '            drow("jul_estatus") = -1
    '            drow("ago_estatus") = -1
    '            drow("sep_estatus") = -1
    '            drow("oct_estatus") = -1
    '            drow("nov_estatus") = -1
    '            drow("dic_estatus") = -1
    '            drow("ene_estatus") = -1


    '            drow("feb_activo") = -1
    '            drow("mar_activo") = -1
    '            drow("abr_activo") = -1
    '            drow("may_activo") = -1
    '            drow("jun_activo") = -1
    '            drow("jul_activo") = -1
    '            drow("ago_activo") = -1
    '            drow("sep_activo") = -1
    '            drow("oct_activo") = -1
    '            drow("nov_activo") = -1
    '            drow("dic_activo") = -1
    '            drow("ene_activo") = -1

    '            For Each mes As DataRow In dtMesesTranscurridos.Rows
    '                drow(mes("mes") & "_activo") = 1
    '            Next

    '            ' ---------------------------
    '            drow("baja") = row("baja")
    '            drow("alta_personal") = row("alta")
    '            drow("alta_ideas") = row("alta")

    '            drow("transferencia") = 0
    '            drow("reloj_anterior") = ""

    '            If transferencias Then
    '                Dim dt_transferencia As DataTable = sqlExecute("select * from transferencias where reloj_nuevo = '" & row("reloj") & "' and alta > alta_anterior")
    '                If dt_transferencia.Rows.Count > 0 Then
    '                    'If Date.Parse(dt_transferencia.Rows(0)("alta_anterior")) > FechaIni Then
    '                    drow("transferencia") = 1
    '                    drow("reloj_anterior") = dt_transferencia.Rows(0)("reloj_anterior")
    '                    drow("alta_ideas") = Date.Parse(dt_transferencia.Rows(0)("alta_anterior"))
    '                    'End If

    '                    Try
    '                        Dim dtIdeasAgencia As DataTable = sqlExecute("SELECT ideasVW.*,cias.nombre AS COMPANIA,deptos.nombre AS NOMBRE_DEPTO,SUPER.NOMBRE AS NOMBRE_SUPER," & _
    '                                                               "AREAS.NOMBRE AS NOMBRE_AREA,puestos.nombre as 'nombre_puesto' FROM IDEASVW " & _
    '                                                               "LEFT JOIN personal.dbo.cias ON ideasVW.cod_comp = cias.cod_comp " & _
    '                                                               "LEFT JOIN personal.dbo.deptos ON ideasVW.cod_comp = deptos.cod_comp AND ideasVW.cod_depto = deptos.cod_depto " & _
    '                                                               "LEFT JOIN personal.dbo.super ON ideasVW.cod_comp = super.cod_comp AND ideasVW.cod_super = super.cod_super " & _
    '                                                               "LEFT JOIN personal.dbo.puestos ON ideasVW.cod_comp = puestos.cod_comp AND ideasVW.cod_puesto = puestos.cod_puesto " & _
    '                                                               "LEFT JOIN personal.dbo.areas ON ideasVW.cod_comp = areas.cod_comp AND ideasVW.cod_area = areas.cod_area " & _
    '                                                               "WHERE fecha BETWEEN '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "' and ideasvw.reloj = '" & dt_transferencia.Rows(0)("reloj_anterior") & "'", "IDEAS")

    '                        For Each row_agencia As DataRow In dtIdeasAgencia.Rows
    '                            row_agencia("reloj") = row("reloj")
    '                            dtIdeasTransferencia.ImportRow(row_agencia)
    '                        Next

    '                    Catch ex As Exception

    '                    End Try


    '                End If
    '            End If


    '            '---------------------------------


    '            Dim dtCambiosDepto As New DataTable
    '            dtCambiosDepto = sqlExecute("select MAX(cast(FECHA as date)) AS FECHA_CAMBIO from bitacora_personal where reloj in ('" & drow("reloj") & "','" & drow("reloj_anterior") & "')and (valorAnterior is not null and valorAnterior <> '') and campo = 'COD_DEPTO' and valorAnterior='" & row("COD_DEPTO") & "' and (cast(FECHA as date) between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "')")
    '            If IsDBNull(dtCambiosDepto.Rows(0).Item("FECHA_CAMBIO")) Then
    '                If IsDBNull(row("baja")) Then
    '                    BajaIdeas = Nothing
    '                Else
    '                    BajaIdeas = row("baja")
    '                End If
    '            Else
    '                BajaIdeas = dtCambiosDepto.Rows(0).Item("FECHA_CAMBIO")
    '            End If

    '            ' BajaIdeas = IIf(IsDBNull(dtCambiosDepto.Rows(0).Item("FECHA_CAMBIO")), IIf(IsDBNull(row("baja")), Nothing, row("baja")), dtCambiosDepto.Rows(0).Item("FECHA_CAMBIO"))
    '            dtCambiosDepto = sqlExecute("select MIN(cast(FECHA as date)) AS FECHA_CAMBIO from bitacora_personal where reloj in ('" & drow("reloj") & "','" & drow("reloj_anterior") & "')and (valorAnterior is not null and valorAnterior <> '') and campo = 'COD_DEPTO' and valorNuevo='" & row("COD_DEPTO") & "' and (cast(FECHA as date) between '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "')")
    '            If IsDBNull(dtCambiosDepto.Rows(0).Item("FECHA_CAMBIO")) Then
    '                If IsDBNull(row("alta")) Then
    '                    AltaIdeas = Nothing
    '                Else
    '                    AltaIdeas = row("alta")
    '                End If
    '            Else
    '                AltaIdeas = dtCambiosDepto.Rows(0).Item("FECHA_CAMBIO")
    '            End If

    '            ' ---------------------------


    '            If Date.Parse(AltaIdeas) < fechaini Then
    '                drow("mes_inicio") = "feb"
    '                drow("meses") = 12
    '                drow("objetivo_anual") = objetivo_anual
    '            Else
    '                Dim mes_inicio As Integer = Date.Parse(AltaIdeas).Month + 1
    '                Select Case mes_inicio
    '                    Case 2
    '                        drow("mes_inicio") = "feb"
    '                        drow("meses") = 12
    '                        drow("objetivo_anual") = 8
    '                    Case 3
    '                        drow("mes_inicio") = "mar"
    '                        drow("meses") = 11
    '                        drow("objetivo_anual") = 7
    '                    Case 4
    '                        drow("mes_inicio") = "abr"
    '                        drow("meses") = 10
    '                        drow("objetivo_anual") = 7
    '                    Case 5
    '                        drow("mes_inicio") = "may"
    '                        drow("meses") = 9
    '                        drow("objetivo_anual") = 6
    '                    Case 6
    '                        drow("mes_inicio") = "jun"
    '                        drow("meses") = 8
    '                        drow("objetivo_anual") = 5
    '                    Case 7
    '                        drow("mes_inicio") = "jul"
    '                        drow("meses") = 7
    '                        drow("objetivo_anual") = 5
    '                    Case 8
    '                        drow("mes_inicio") = "ago"
    '                        drow("meses") = 6
    '                        drow("objetivo_anual") = 4
    '                    Case 9
    '                        drow("mes_inicio") = "sep"
    '                        drow("meses") = 5
    '                        drow("objetivo_anual") = 3
    '                    Case 10
    '                        drow("mes_inicio") = "oct"
    '                        drow("meses") = 4
    '                        drow("objetivo_anual") = 3
    '                    Case 11
    '                        drow("mes_inicio") = "nov"
    '                        drow("meses") = 3
    '                        drow("objetivo_anual") = 2
    '                    Case 12
    '                        drow("mes_inicio") = "dic"
    '                        drow("meses") = 2
    '                        drow("objetivo_anual") = 1
    '                End Select
    '            End If

    '            ' ---------------------------

    '            Select Case drow("mes_inicio").ToString
    '                Case "feb"
    '                    drow("feb_obj") = 1 : drow("mar_obj") = 1 : drow("abr_obj") = 2 : drow("may_obj") = 3 : drow("jun_obj") = 3 : drow("jul_obj") = 4 : drow("ago_obj") = 5 : drow("sep_obj") = 5 : drow("oct_obj") = 6 : drow("nov_obj") = 7 : drow("dic_obj") = 7 : drow("ene_obj") = 8
    '                Case "mar"
    '                    drow("feb_obj") = 0 : drow("mar_obj") = 1 : drow("abr_obj") = 1 : drow("may_obj") = 2 : drow("jun_obj") = 3 : drow("jul_obj") = 3 : drow("ago_obj") = 4 : drow("sep_obj") = 5 : drow("oct_obj") = 5 : drow("nov_obj") = 6 : drow("dic_obj") = 7 : drow("ene_obj") = 7
    '                Case "abr"
    '                    drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 1 : drow("may_obj") = 1 : drow("jun_obj") = 2 : drow("jul_obj") = 3 : drow("ago_obj") = 3 : drow("sep_obj") = 4 : drow("oct_obj") = 5 : drow("nov_obj") = 5 : drow("dic_obj") = 6 : drow("ene_obj") = 7
    '                Case "may"
    '                    drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 1 : drow("jun_obj") = 1 : drow("jul_obj") = 2 : drow("ago_obj") = 3 : drow("sep_obj") = 3 : drow("oct_obj") = 4 : drow("nov_obj") = 5 : drow("dic_obj") = 5 : drow("ene_obj") = 6
    '                Case "jun"
    '                    drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 1 : drow("jul_obj") = 1 : drow("ago_obj") = 2 : drow("sep_obj") = 3 : drow("oct_obj") = 3 : drow("nov_obj") = 4 : drow("dic_obj") = 5 : drow("ene_obj") = 5
    '                Case "jul"
    '                    drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 1 : drow("ago_obj") = 1 : drow("sep_obj") = 2 : drow("oct_obj") = 3 : drow("nov_obj") = 3 : drow("dic_obj") = 4 : drow("ene_obj") = 5
    '                Case "ago"
    '                    drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 1 : drow("sep_obj") = 1 : drow("oct_obj") = 2 : drow("nov_obj") = 3 : drow("dic_obj") = 3 : drow("ene_obj") = 4
    '                Case "sep"
    '                    drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 1 : drow("oct_obj") = 1 : drow("nov_obj") = 2 : drow("dic_obj") = 3 : drow("ene_obj") = 3
    '                Case "oct"
    '                    drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 1 : drow("nov_obj") = 1 : drow("dic_obj") = 2 : drow("ene_obj") = 3
    '                Case "nov"
    '                    drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 1 : drow("dic_obj") = 1 : drow("ene_obj") = 2
    '                Case "dic"
    '                    drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 1 : drow("ene_obj") = 1
    '                Case "ene"
    '                    drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 1
    '            End Select


    '            '-----------------------------

    '            If Not IsNothing(BajaIdeas) Then
    '                MesFin = BajaIdeas.Month
    '                'If DeptoOriginal <> DeptoActual Then
    '                '    MesFin = Date.Parse(drow("baja_ideas")).Month - 1
    '                'Else
    '                '    MesFin = Date.Parse(drow("baja_ideas")).Month
    '                'End If

    '                Select Case MesFin
    '                    Case 2
    '                        MesFinal = "feb"
    '                        drow("meses") = drow("meses") - 11
    '                        'drow("meses") = 12
    '                        'drow("objetivo_anual") = drow("objetivo_anual") 
    '                        drow("objetivo_anual") = drow("objetivo_anual") - 7

    '                    Case 3
    '                        MesFinal = "mar"
    '                        drow("meses") = drow("meses") - 10
    '                        'drow("meses") = 11
    '                        drow("objetivo_anual") = drow("objetivo_anual") - 7
    '                        'drow("objetivo_anual") = 7
    '                    Case 4
    '                        MesFinal = "abr"
    '                        drow("meses") = drow("meses") - 9
    '                        'drow("meses") = 10
    '                        drow("objetivo_anual") = drow("objetivo_anual") - 6
    '                        'drow("objetivo_anual") = 7
    '                    Case 5
    '                        MesFinal = "may"
    '                        drow("meses") = drow("meses") - 8
    '                        'drow("meses") = 9
    '                        drow("objetivo_anual") = drow("objetivo_anual") - 5
    '                        'drow("objetivo_anual") = 6
    '                    Case 6
    '                        MesFinal = "jun"
    '                        drow("meses") = drow("meses") - 7
    '                        'drow("meses") = 8
    '                        drow("objetivo_anual") = drow("objetivo_anual") - 5
    '                        'drow("objetivo_anual") = 5
    '                    Case 7
    '                        MesFinal = "jul"
    '                        drow("meses") = drow("meses") - 6
    '                        'drow("meses") = 7
    '                        drow("objetivo_anual") = drow("objetivo_anual") - 4
    '                        'drow("objetivo_anual") = 5
    '                    Case 8
    '                        MesFinal = "ago"
    '                        drow("meses") = drow("meses") - 5
    '                        'drow("meses") = 6
    '                        drow("objetivo_anual") = drow("objetivo_anual") - 3
    '                        'drow("objetivo_anual") = 4
    '                    Case 9
    '                        MesFinal = "sep"
    '                        drow("meses") = drow("meses") - 4
    '                        'drow("meses") = 5
    '                        drow("objetivo_anual") = drow("objetivo_anual") - 3
    '                        'drow("objetivo_anual") = 3
    '                    Case 10
    '                        MesFinal = "oct"
    '                        drow("meses") = drow("meses") - 3
    '                        'drow("meses") = 4
    '                        drow("objetivo_anual") = drow("objetivo_anual") - 2
    '                        'drow("objetivo_anual") = 3
    '                    Case 11
    '                        MesFinal = "nov"
    '                        drow("meses") = drow("meses") - 2
    '                        'drow("meses") = 3
    '                        drow("objetivo_anual") = drow("objetivo_anual") - 1
    '                        'drow("objetivo_anual") = 2
    '                    Case 12
    '                        MesFinal = "dic"
    '                        drow("meses") = drow("meses") - 1
    '                        'drow("meses") = 
    '                        drow("objetivo_anual") = drow("objetivo_anual") - 1
    '                        'drow("objetivo_anual") = 1
    '                End Select
    '                Select Case MesFinal
    '                    Case "feb"
    '                        drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
    '                    Case "mar"
    '                        drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
    '                    Case "abr"
    '                        drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
    '                    Case "may"
    '                        drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
    '                    Case "jun"
    '                        drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
    '                    Case "jul"
    '                        drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
    '                    Case "ago"
    '                        drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
    '                    Case "sep"
    '                        drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
    '                    Case "oct"
    '                        drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 0
    '                    Case "nov"
    '                        drow("dic_obj") = 0 : drow("ene_obj") = 0
    '                    Case "dic"
    '                        drow("ene_obj") = 0
    '                End Select
    '            End If

    '            '--------------------------------------------------------
    '            ' ---------------------------

    '            drow("fecha_ini") = fechaini
    '            drow("fecha_fin") = fechafin
    '        End If

    '        ' ---------------------------

    '        drow(row("mes_implementacion") & "_ideas") = drow(row("mes_implementacion") & "_ideas") + 1

    '        drow("estatus_anual") =
    '        drow("feb_ideas") +
    '        drow("mar_ideas") +
    '        drow("abr_ideas") +
    '        drow("may_ideas") +
    '        drow("jun_ideas") +
    '        drow("jul_ideas") +
    '        drow("ago_ideas") +
    '        drow("sep_ideas") +
    '        drow("oct_ideas") +
    '        drow("nov_ideas") +
    '        drow("dic_ideas") +
    '        drow("ene_ideas")


    '        drow("feb_acum") = drow("feb_ideas")
    '        drow("mar_acum") = drow("mar_ideas") + drow("feb_ideas")
    '        drow("abr_acum") = drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '        drow("may_acum") = drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '        drow("jun_acum") = drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '        drow("jul_acum") = drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '        drow("ago_acum") = drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '        drow("sep_acum") = drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '        drow("oct_acum") = drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '        drow("nov_acum") = drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '        drow("dic_acum") = drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '        drow("ene_acum") = drow("ene_ideas") + drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")


    '        'drow("feb_estatus") = IIf(drow("feb_acum") >= drow("feb_obj"), IIf(drow("feb_obj") > 0, 1, -1), 0)
    '        'drow("mar_estatus") = IIf(drow("mar_acum") >= drow("mar_obj"), IIf(drow("mar_obj") > 0, 1, -1), 0)
    '        'drow("abr_estatus") = IIf(drow("abr_acum") >= drow("abr_obj"), IIf(drow("abr_obj") > 0, 1, -1), 0)
    '        'drow("may_estatus") = IIf(drow("may_acum") >= drow("may_obj"), IIf(drow("may_obj") > 0, 1, -1), 0)
    '        'drow("jun_estatus") = IIf(drow("jun_acum") >= drow("jun_obj"), IIf(drow("jun_obj") > 0, 1, -1), 0)
    '        'drow("jul_estatus") = IIf(drow("jul_acum") >= drow("jul_obj"), IIf(drow("jul_obj") > 0, 1, -1), 0)
    '        'drow("ago_estatus") = IIf(drow("ago_acum") >= drow("ago_obj"), IIf(drow("ago_obj") > 0, 1, -1), 0)
    '        'drow("sep_estatus") = IIf(drow("sep_acum") >= drow("sep_obj"), IIf(drow("sep_obj") > 0, 1, -1), 0)
    '        'drow("oct_estatus") = IIf(drow("oct_acum") >= drow("oct_obj"), IIf(drow("oct_obj") > 0, 1, -1), 0)
    '        'drow("nov_estatus") = IIf(drow("nov_acum") >= drow("nov_obj"), IIf(drow("nov_obj") > 0, 1, -1), 0)
    '        'drow("dic_estatus") = IIf(drow("dic_acum") >= drow("dic_obj"), IIf(drow("dic_obj") > 0, 1, -1), 0)
    '        'drow("ene_estatus") = IIf(drow("ene_acum") >= drow("ene_obj"), IIf(drow("ene_obj") > 0, 1, -1), 0)

    '        drow("feb_estatus") = IIf(drow("feb_activo") = 1 And drow("feb_acum") >= drow("feb_obj") And drow("feb_obj") > 0, 1, -1)
    '        drow("mar_estatus") = IIf(drow("mar_activo") = 1 And drow("mar_acum") >= drow("mar_obj") And drow("mar_obj") > 0, 1, -1)
    '        drow("abr_estatus") = IIf(drow("abr_activo") = 1 And drow("abr_acum") >= drow("abr_obj") And drow("abr_obj") > 0, 1, -1)
    '        drow("may_estatus") = IIf(drow("may_activo") = 1 And drow("may_acum") >= drow("may_obj") And drow("may_obj") > 0, 1, -1)
    '        drow("jun_estatus") = IIf(drow("jun_activo") = 1 And drow("jun_acum") >= drow("jun_obj") And drow("jun_obj") > 0, 1, -1)
    '        drow("jul_estatus") = IIf(drow("jul_activo") = 1 And drow("jul_acum") >= drow("jul_obj") And drow("jul_obj") > 0, 1, -1)
    '        drow("ago_estatus") = IIf(drow("ago_activo") = 1 And drow("ago_acum") >= drow("ago_obj") And drow("ago_obj") > 0, 1, -1)
    '        drow("sep_estatus") = IIf(drow("sep_activo") = 1 And drow("sep_acum") >= drow("sep_obj") And drow("sep_obj") > 0, 1, -1)
    '        drow("oct_estatus") = IIf(drow("oct_activo") = 1 And drow("oct_acum") >= drow("oct_obj") And drow("oct_obj") > 0, 1, -1)
    '        drow("nov_estatus") = IIf(drow("nov_activo") = 1 And drow("nov_acum") >= drow("nov_obj") And drow("nov_obj") > 0, 1, -1)
    '        drow("dic_estatus") = IIf(drow("dic_activo") = 1 And drow("dic_acum") >= drow("dic_obj") And drow("dic_obj") > 0, 1, -1)
    '        drow("ene_estatus") = IIf(drow("ene_activo") = 1 And drow("ene_acum") >= drow("ene_obj") And drow("ene_obj") > 0, 1, -1)


    '    Catch ex As Exception

    '    End Try
    'End Sub

#End Region


    'Private Sub AuxiliarIdeasCbajas(row As DataRow, ByRef DtDatos As DataTable, transferencias As Boolean, dtMesesTranscurridos As DataTable, fechaini As Date, fechafin As Date, objetivo_anual As Int32, ByRef dtIdeasTransferencia As DataTable)
    '    Try
    '        Dim drow As DataRow = DtDatos.Rows.Find(row("reloj"))

    '        If drow Is Nothing Then
    '            drow = DtDatos.NewRow

    '            drow("reloj") = row("reloj")
    '            DtDatos.Rows.Add(drow)

    '            drow("nombres") = RTrim(row("nombres"))

    '            drow("cod_super") = row("cod_super")
    '            drow("cod_depto") = row("cod_depto")

    '            drow("nombre_super") = row("nombre_super")
    '            drow("nombre_depto") = row("nombre_depto")

    '            drow("cod_super_original") = row("cod_super_original")
    '            drow("cod_depto_original") = row("cod_depto_original")

    '            drow("nombre_super_origina") = row("nombre_super_origina")
    '            drow("nombre_depto_origina") = row("nombre_depto_origina")
    '            Try
    '                drow("baja") = IIf(IsDBNull(row("baja")), "", "Fecha de baja: " + FechaMediaLetra(row("baja")))
    '            Catch ex As Exception
    '                drow("baja") = ""
    '            End Try
    '            drow("feb_ideas") = 0
    '            drow("mar_ideas") = 0
    '            drow("abr_ideas") = 0
    '            drow("may_ideas") = 0
    '            drow("jun_ideas") = 0
    '            drow("jul_ideas") = 0
    '            drow("ago_ideas") = 0
    '            drow("sep_ideas") = 0
    '            drow("oct_ideas") = 0
    '            drow("nov_ideas") = 0
    '            drow("dic_ideas") = 0
    '            drow("ene_ideas") = 0

    '            drow("estatus_anual") = 0

    '            drow("feb_obj") = 0
    '            drow("mar_obj") = 0
    '            drow("abr_obj") = 0
    '            drow("may_obj") = 0
    '            drow("jun_obj") = 0
    '            drow("jul_obj") = 0
    '            drow("ago_obj") = 0
    '            drow("sep_obj") = 0
    '            drow("oct_obj") = 0
    '            drow("nov_obj") = 0
    '            drow("dic_obj") = 0
    '            drow("ene_obj") = 0

    '            drow("feb_acum") = drow("feb_ideas")
    '            drow("mar_acum") = drow("mar_ideas") + drow("feb_ideas")
    '            drow("abr_acum") = drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '            drow("may_acum") = drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '            drow("jun_acum") = drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '            drow("jul_acum") = drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '            drow("ago_acum") = drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '            drow("sep_acum") = drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '            drow("oct_acum") = drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '            drow("nov_acum") = drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '            drow("dic_acum") = drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '            drow("ene_acum") = drow("ene_ideas") + drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")

    '            drow("feb_estatus") = -1
    '            drow("mar_estatus") = -1
    '            drow("abr_estatus") = -1
    '            drow("may_estatus") = -1
    '            drow("jun_estatus") = -1
    '            drow("jul_estatus") = -1
    '            drow("ago_estatus") = -1
    '            drow("sep_estatus") = -1
    '            drow("oct_estatus") = -1
    '            drow("nov_estatus") = -1
    '            drow("dic_estatus") = -1
    '            drow("ene_estatus") = -1


    '            drow("feb_activo") = -1
    '            drow("mar_activo") = -1
    '            drow("abr_activo") = -1
    '            drow("may_activo") = -1
    '            drow("jun_activo") = -1
    '            drow("jul_activo") = -1
    '            drow("ago_activo") = -1
    '            drow("sep_activo") = -1
    '            drow("oct_activo") = -1
    '            drow("nov_activo") = -1
    '            drow("dic_activo") = -1
    '            drow("ene_activo") = -1

    '            For Each mes As DataRow In dtMesesTranscurridos.Rows
    '                drow(mes("mes") & "_activo") = 1
    '            Next

    '            ' ---------------------------

    '            drow("alta_personal") = row("alta")
    '            drow("alta_ideas") = row("alta")

    '            drow("transferencia") = 0
    '            drow("reloj_anterior") = ""

    '            If transferencias Then
    '                Dim dt_transferencia As DataTable = sqlExecute("select * from transferencias where reloj_nuevo = '" & row("reloj") & "' and alta > alta_anterior")
    '                If dt_transferencia.Rows.Count > 0 Then
    '                    'If Date.Parse(dt_transferencia.Rows(0)("alta_anterior")) > FechaIni Then
    '                    drow("transferencia") = 1
    '                    drow("reloj_anterior") = dt_transferencia.Rows(0)("reloj_anterior")
    '                    drow("alta_ideas") = Date.Parse(dt_transferencia.Rows(0)("alta_anterior"))
    '                    'End If

    '                    Try
    '                        Dim dtIdeasAgencia As DataTable = sqlExecute("SELECT ideasVW.*,cias.nombre AS COMPANIA,deptos.nombre AS NOMBRE_DEPTO,SUPER.NOMBRE AS NOMBRE_SUPER," & _
    '                                                               "AREAS.NOMBRE AS NOMBRE_AREA,puestos.nombre as 'nombre_puesto' FROM IDEASVW " & _
    '                                                               "LEFT JOIN personal.dbo.cias ON ideasVW.cod_comp = cias.cod_comp " & _
    '                                                               "LEFT JOIN personal.dbo.deptos ON ideasVW.cod_comp = deptos.cod_comp AND ideasVW.cod_depto = deptos.cod_depto " & _
    '                                                               "LEFT JOIN personal.dbo.super ON ideasVW.cod_comp = super.cod_comp AND ideasVW.cod_super = super.cod_super " & _
    '                                                               "LEFT JOIN personal.dbo.puestos ON ideasVW.cod_comp = puestos.cod_comp AND ideasVW.cod_puesto = puestos.cod_puesto " & _
    '                                                               "LEFT JOIN personal.dbo.areas ON ideasVW.cod_comp = areas.cod_comp AND ideasVW.cod_area = areas.cod_area " & _
    '                                                               "WHERE fecha BETWEEN '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "' and ideasvw.reloj = '" & dt_transferencia.Rows(0)("reloj_anterior") & "'", "IDEAS")

    '                        For Each row_agencia As DataRow In dtIdeasAgencia.Rows
    '                            row_agencia("reloj") = row("reloj")
    '                            dtIdeasTransferencia.ImportRow(row_agencia)
    '                        Next

    '                    Catch ex As Exception
    '                        Debug.Print(ex.Message)
    '                    End Try


    '                End If
    '            End If




    '            ' ---------------------------

    '            If Date.Parse(drow("alta_ideas")) < fechaini Then
    '                drow("mes_inicio") = "feb"
    '                drow("meses") = 12
    '                drow("objetivo_anual") = objetivo_anual
    '            Else
    '                Dim mes_inicio As Integer = Date.Parse(drow("alta_ideas")).Month + 1
    '                Select Case mes_inicio
    '                    Case 2
    '                        drow("mes_inicio") = "feb"
    '                        drow("meses") = 12
    '                        drow("objetivo_anual") = 8
    '                    Case 3
    '                        drow("mes_inicio") = "mar"
    '                        drow("meses") = 11
    '                        drow("objetivo_anual") = 7
    '                    Case 4
    '                        drow("mes_inicio") = "abr"
    '                        drow("meses") = 10
    '                        drow("objetivo_anual") = 7
    '                    Case 5
    '                        drow("mes_inicio") = "may"
    '                        drow("meses") = 9
    '                        drow("objetivo_anual") = 6
    '                    Case 6
    '                        drow("mes_inicio") = "jun"
    '                        drow("meses") = 8
    '                        drow("objetivo_anual") = 5
    '                    Case 7
    '                        drow("mes_inicio") = "jul"
    '                        drow("meses") = 7
    '                        drow("objetivo_anual") = 5
    '                    Case 8
    '                        drow("mes_inicio") = "ago"
    '                        drow("meses") = 6
    '                        drow("objetivo_anual") = 4
    '                    Case 9
    '                        drow("mes_inicio") = "sep"
    '                        drow("meses") = 5
    '                        drow("objetivo_anual") = 3
    '                    Case 10
    '                        drow("mes_inicio") = "oct"
    '                        drow("meses") = 4
    '                        drow("objetivo_anual") = 3
    '                    Case 11
    '                        drow("mes_inicio") = "nov"
    '                        drow("meses") = 3
    '                        drow("objetivo_anual") = 2
    '                    Case 12
    '                        drow("mes_inicio") = "dic"
    '                        drow("meses") = 2
    '                        drow("objetivo_anual") = 1
    '                End Select
    '            End If

    '            ' ---------------------------

    '            Select Case drow("mes_inicio").ToString
    '                Case "feb"
    '                    drow("feb_obj") = 1 : drow("mar_obj") = 1 : drow("abr_obj") = 2 : drow("may_obj") = 3 : drow("jun_obj") = 3 : drow("jul_obj") = 4 : drow("ago_obj") = 5 : drow("sep_obj") = 5 : drow("oct_obj") = 6 : drow("nov_obj") = 7 : drow("dic_obj") = 7 : drow("ene_obj") = 8
    '                Case "mar"
    '                    drow("feb_obj") = 0 : drow("mar_obj") = 1 : drow("abr_obj") = 1 : drow("may_obj") = 2 : drow("jun_obj") = 3 : drow("jul_obj") = 3 : drow("ago_obj") = 4 : drow("sep_obj") = 5 : drow("oct_obj") = 5 : drow("nov_obj") = 6 : drow("dic_obj") = 7 : drow("ene_obj") = 7
    '                Case "abr"
    '                    drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 1 : drow("may_obj") = 1 : drow("jun_obj") = 2 : drow("jul_obj") = 3 : drow("ago_obj") = 3 : drow("sep_obj") = 4 : drow("oct_obj") = 5 : drow("nov_obj") = 5 : drow("dic_obj") = 6 : drow("ene_obj") = 7
    '                Case "may"
    '                    drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 1 : drow("jun_obj") = 1 : drow("jul_obj") = 2 : drow("ago_obj") = 3 : drow("sep_obj") = 3 : drow("oct_obj") = 4 : drow("nov_obj") = 5 : drow("dic_obj") = 5 : drow("ene_obj") = 6
    '                Case "jun"
    '                    drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 1 : drow("jul_obj") = 1 : drow("ago_obj") = 2 : drow("sep_obj") = 3 : drow("oct_obj") = 3 : drow("nov_obj") = 4 : drow("dic_obj") = 5 : drow("ene_obj") = 5
    '                Case "jul"
    '                    drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 1 : drow("ago_obj") = 1 : drow("sep_obj") = 2 : drow("oct_obj") = 3 : drow("nov_obj") = 3 : drow("dic_obj") = 4 : drow("ene_obj") = 5
    '                Case "ago"
    '                    drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 1 : drow("sep_obj") = 1 : drow("oct_obj") = 2 : drow("nov_obj") = 3 : drow("dic_obj") = 3 : drow("ene_obj") = 4
    '                Case "sep"
    '                    drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 1 : drow("oct_obj") = 1 : drow("nov_obj") = 2 : drow("dic_obj") = 3 : drow("ene_obj") = 3
    '                Case "oct"
    '                    drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 1 : drow("nov_obj") = 1 : drow("dic_obj") = 2 : drow("ene_obj") = 3
    '                Case "nov"
    '                    drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 1 : drow("dic_obj") = 1 : drow("ene_obj") = 2
    '                Case "dic"
    '                    drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 1 : drow("ene_obj") = 1
    '                Case "ene"
    '                    drow("feb_obj") = 0 : drow("mar_obj") = 0 : drow("abr_obj") = 0 : drow("may_obj") = 0 : drow("jun_obj") = 0 : drow("jul_obj") = 0 : drow("ago_obj") = 0 : drow("sep_obj") = 0 : drow("oct_obj") = 0 : drow("nov_obj") = 0 : drow("dic_obj") = 0 : drow("ene_obj") = 1
    '            End Select


    '            ' ---------------------------

    '            drow("fecha_ini") = fechaini
    '            drow("fecha_fin") = fechafin
    '        End If

    '        ' ---------------------------

    '        drow(row("mes_implementacion") & "_ideas") = drow(row("mes_implementacion") & "_ideas") + 1

    '        drow("estatus_anual") =
    '        drow("feb_ideas") +
    '        drow("mar_ideas") +
    '        drow("abr_ideas") +
    '        drow("may_ideas") +
    '        drow("jun_ideas") +
    '        drow("jul_ideas") +
    '        drow("ago_ideas") +
    '        drow("sep_ideas") +
    '        drow("oct_ideas") +
    '        drow("nov_ideas") +
    '        drow("dic_ideas") +
    '        drow("ene_ideas")


    '        drow("feb_acum") = drow("feb_ideas")
    '        drow("mar_acum") = drow("mar_ideas") + drow("feb_ideas")
    '        drow("abr_acum") = drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '        drow("may_acum") = drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '        drow("jun_acum") = drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '        drow("jul_acum") = drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '        drow("ago_acum") = drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '        drow("sep_acum") = drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '        drow("oct_acum") = drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '        drow("nov_acum") = drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '        drow("dic_acum") = drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")
    '        drow("ene_acum") = drow("ene_ideas") + drow("dic_ideas") + drow("nov_ideas") + drow("oct_ideas") + drow("sep_ideas") + drow("ago_ideas") + drow("jul_ideas") + drow("jun_ideas") + drow("may_ideas") + drow("abr_ideas") + drow("mar_ideas") + drow("feb_ideas")


    '        drow("feb_estatus") = IIf(drow("feb_acum") >= drow("feb_obj"), IIf(drow("feb_obj") > 0, 1, -1), 0)
    '        drow("mar_estatus") = IIf(drow("mar_acum") >= drow("mar_obj"), IIf(drow("mar_obj") > 0, 1, -1), 0)
    '        drow("abr_estatus") = IIf(drow("abr_acum") >= drow("abr_obj"), IIf(drow("abr_obj") > 0, 1, -1), 0)
    '        drow("may_estatus") = IIf(drow("may_acum") >= drow("may_obj"), IIf(drow("may_obj") > 0, 1, -1), 0)
    '        drow("jun_estatus") = IIf(drow("jun_acum") >= drow("jun_obj"), IIf(drow("jun_obj") > 0, 1, -1), 0)
    '        drow("jul_estatus") = IIf(drow("jul_acum") >= drow("jul_obj"), IIf(drow("jul_obj") > 0, 1, -1), 0)
    '        drow("ago_estatus") = IIf(drow("ago_acum") >= drow("ago_obj"), IIf(drow("ago_obj") > 0, 1, -1), 0)
    '        drow("sep_estatus") = IIf(drow("sep_acum") >= drow("sep_obj"), IIf(drow("sep_obj") > 0, 1, -1), 0)
    '        drow("oct_estatus") = IIf(drow("oct_acum") >= drow("oct_obj"), IIf(drow("oct_obj") > 0, 1, -1), 0)
    '        drow("nov_estatus") = IIf(drow("nov_acum") >= drow("nov_obj"), IIf(drow("nov_obj") > 0, 1, -1), 0)
    '        drow("dic_estatus") = IIf(drow("dic_acum") >= drow("dic_obj"), IIf(drow("dic_obj") > 0, 1, -1), 0)
    '        drow("ene_estatus") = IIf(drow("ene_acum") >= drow("ene_obj"), IIf(drow("ene_obj") > 0, 1, -1), 0)

    '    Catch ex As Exception
    '        Debug.Print(ex.Message)
    '        'Stop
    '    End Try
    'End Sub
#End Region

End Module
