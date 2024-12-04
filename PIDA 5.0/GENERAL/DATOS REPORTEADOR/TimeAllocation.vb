Module TimeAllocation
Public Sub AuditoriaHoras(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try

            ' ******************** NUEVO PROCEDIMIENTO ************************

            'Dim dtCentro_costos As DataTable = sqlExecute("select * from c_costos where distribuible = '1'")

            'dtDatos = New DataTable
            'dtDatos.Columns.Add("fecha", Type.GetType("System.String"))
            'dtDatos.Columns.Add("trabajadas", Type.GetType("System.Double"))
            'dtDatos.Columns.Add("asignadas", Type.GetType("System.Double"))
            'dtDatos.Columns.Add("centro_costos", Type.GetType("System.String"))
            'dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
            'dtDatos.Columns.Add("nombre_depto", Type.GetType("System.String"))
            'dtDatos.Columns.Add("empleados_inicio", Type.GetType("System.String"))
            'dtDatos.Columns.Add("empleados_corte", Type.GetType("System.String"))
            'dtDatos.Columns.Add("empleados_diferentes", Type.GetType("System.String"))

            'dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("cod_depto")}

            'Dim trabajadas_totales As Double = 0
            'Dim asignadas_totales As Double = 0

            'For Each rowCC As DataRow In dtCentro_costos.Rows
            '    Try

            '        Dim centro_costos As String = rowCC("centro_costos")

            '        Dim dtAsist As DataTable = sqlExecute("select distinct reloj, FHA_ENT_HOR from asist where FHA_ENT_HOR between  '" & FechaSQL(RangoFInicial) & "' and '" & FechaSQL(RangoFFinal) & "' and cod_clase = 'D' and cod_depto in (select cod_depto from personal.dbo.deptos where centro_costos = '" & centro_costos & "'  and cod_depto <> centro_costos ) order by reloj asc, FHA_ENT_HOR asc", "TA")
            '        If dtAsist.Rows.Count > 0 Then
            '            For Each row As DataRow In dtAsist.Rows
            '                Dim reloj As String = row("reloj")
            '                Dim fecha As Date = row("FHA_ENT_HOR")

            '                Dim trabajadas As Double = 0
            '                Dim asignadas As Double = 0
            '                Dim cod_depto As String = ""
            '                Dim nombre_depto As String = ""

            '                Dim inicio As Integer = 0
            '                Dim corte As Integer = 0

            '                Try
            '                    Dim dtTrabajadas As DataTable = sqlExecute("select top 1 horas_normales, horas_extras from asist where reloj = '" & reloj & "' and FHA_ENT_HOR = '" & FechaSQL(fecha) & "'", "TA")
            '                    If dtTrabajadas.Rows.Count > 0 Then
            '                        trabajadas = HtoD(dtTrabajadas.Rows(0)("horas_normales")) + HtoD(dtTrabajadas.Rows(0)("horas_extras"))
            '                    End If

            '                    Dim dtAsignadas As DataTable = sqlExecute("select isnull(sum(horas), 0) as horas from time_allocation where reloj = '" & reloj & "' and fecha = '" & FechaSQL(fecha) & "' ", "TA")
            '                    If dtAsignadas.Rows.Count > 0 Then
            '                        asignadas = dtAsignadas.Rows(0)("horas")
            '                    End If

            '                    Dim dtDepto As DataTable = sqlExecute("select cod_depto from asist where reloj = '" & reloj & "' and FHA_ENT_HOR = '" & FechaSQL(fecha) & "' ", "TA")
            '                    If dtDepto.Rows.Count > 0 Then
            '                        cod_depto = dtDepto.Rows(0)("cod_depto")
            '                    End If

            '                    Dim dtCorte As DataTable = sqlExecute("select alta, baja from personal where reloj = '" & reloj & "'")
            '                    If dtCorte.Rows.Count > 0 Then
            '                        If IsDBNull(dtCorte.Rows(0)("baja")) Then
            '                            corte = 1
            '                        Else
            '                            corte = IIf(Date.Parse(dtCorte.Rows(0)("baja")).Date > RangoFFinal, 1, 0)
            '                        End If

            '                        If IsDBNull(dtCorte.Rows(0)("alta")) Then
            '                            MsgBox("EL EMPLEADO " & reloj & " NO TIENE FECHA DE ALTA, LA INFORMACION NO SERA CORRECTA HASTA VALIDAR ESTE DATO CON EL DEPARTAMENTO DE RECURSOS HUMANOS", MsgBoxStyle.Critical)
            '                            Exit Sub
            '                        Else
            '                            inicio = IIf(Date.Parse(dtCorte.Rows(0)("alta")).Date > RangoFInicial, 0, 1)
            '                        End If

            '                    End If

            '                    Dim dRow As DataRow = dtDatos.Rows.Find({cod_depto})

            '                    If dRow Is Nothing Then
            '                        dRow = dtDatos.NewRow
            '                        dRow("cod_depto") = cod_depto
            '                        dRow("nombre_depto") = cod_depto
            '                        dRow("centro_costos") = centro_costos
            '                        dRow("trabajadas") = 0
            '                        dRow("asignadas") = 0
            '                        dRow("empleados_corte") = 0
            '                        dRow("empleados_inicio") = 0
            '                        dRow("empleados_diferentes") = 0
            '                        dtDatos.Rows.Add(dRow)

            '                    End If

            '                    Try
            '                        dRow("trabajadas") += trabajadas
            '                        dRow("asignadas") += asignadas
            '                        dRow("empleados_corte") += corte
            '                        dRow("empleados_inicio") += inicio
            '                        dRow("empleados_diferentes") += 0
            '                    Catch ex As Exception

            '                    End Try

            '                Catch ex As Exception

            '                End Try

            '            Next

            '        End If

            '    Catch ex As Exception

            '    End Try

            'Next

            'Dim i As Integer = 1

            'dtDatos = dtDatos.Select("", "cod_depto").CopyToDataTable


            '**** PROCEDIMIENTO MIRIAM
            Dim drEmp As DataRow

            dtDatos = New DataTable
            dtDatos.Columns.Add("fecha", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombres", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_depto", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_depto", Type.GetType("System.String"))
            dtDatos.Columns.Add("centro_costos", Type.GetType("System.String"))
            dtDatos.Columns.Add("asignadas", Type.GetType("System.Double"))
            dtDatos.Columns.Add("trabajadas", Type.GetType("System.Double"))
            dtDatos.Columns.Add("diferencia", Type.GetType("System.Double"))
            dtDatos.Columns.Add("empleados_corte", Type.GetType("System.String"))

            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj"), dtDatos.Columns("fecha"), dtDatos.Columns("cod_depto")}

            For Each dRow As DataRow In dtInformacion.Select("", "reloj,fecha")
                drEmp = dtDatos.Rows.Find({dRow("reloj"), dRow("fecha"), dRow("cod_deptota")})
                'If dRow("reloj") = "032744" Then Stop
                If drEmp Is Nothing Then
                    My.Application.DoEvents()
                    drEmp = dtDatos.NewRow
                    drEmp("reloj") = dRow("reloj")
                    drEmp("fecha") = dRow("fecha")
                    drEmp("nombres") = dRow("nombres")
                    drEmp("cod_depto") = dRow("cod_deptota")
                    drEmp("nombre_depto") = dRow("nombre_deptota")
                    drEmp("centro_costos") = dRow("centro_costosta")
                    'MCR 2/Feb/2016
                    'En día de descanso o festivo, no considerar las horas normales, solamente las extras

                    Dim festivo_asist As Boolean = False

                    Dim dtFesAsist As DataTable = sqlExecute("select * from asist where reloj = '" & dRow("reloj") & "' and fha_ent_hor = '" & FechaSQL(dRow("fecha")) & "' and tipo_aus = 'FES'", "TA")
                    If dtFesAsist.Rows.Count > 0 Then
                        festivo_asist = True
                    End If

                    If DiaDescanso(dRow("fecha")) Or festivo_asist Then
                        drEmp("trabajadas") = IIf(IsDBNull(dRow("extras")), 0, dRow("extras"))
                    Else
                        drEmp("trabajadas") = IIf(IsDBNull(dRow("trabajadas")), 0, dRow("trabajadas"))
                        'If drEmp("trabajadas") > 0 Then Stop
                    End If
                    drEmp("asignadas") = 0
                    drEmp("diferencia") = 0

                    If IsDBNull(dRow("alta")) Then
                        MsgBox("EL EMPLEADO " & dRow("Reloj") & " NO TIENE FECHA DE ALTA, LA INFORMACIÓN NO SERÁ CORRECTA HASTA VALIDAR ESTE DATO CON EL DEPARTAMENTO DE RECURSOS HUMANOS.", MsgBoxStyle.Critical)
                        dtDatos.Rows.Clear()
                        Exit Sub
                    End If

                    If IsDBNull(dRow("baja")) Then
                        If dRow("alta") <= RangoFFinal Then
                            drEmp("empleados_corte") = dRow("reloj")
                        End If
                    Else
                        If dRow("baja") > RangoFFinal And dRow("alta") <= RangoFFinal Then
                            drEmp("empleados_corte") = dRow("reloj")
                        End If
                    End If
                    dtDatos.Rows.Add(drEmp)
                End If
                drEmp("asignadas") += IIf(IsDBNull(dRow("asignadas")), 0, dRow("asignadas"))
                drEmp("diferencia") = Math.Round(drEmp("trabajadas") - drEmp("asignadas"), 2)
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub

    Public Sub DiferenciasTAlloc(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            Dim dtTemp As New DataTable
            Dim drEmp As DataRow

            dtDatos = New DataTable
            dtDatos.Columns.Add("fecha", Type.GetType("System.DateTime"))
            dtDatos.Columns.Add("reloj", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombres", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_deptota", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_deptota", Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_superta", Type.GetType("System.String"))
            dtDatos.Columns.Add("nombre_superta", Type.GetType("System.String"))
            dtDatos.Columns.Add("asignadas", Type.GetType("System.Double"))
            dtDatos.Columns.Add("trabajadas", Type.GetType("System.Double"))
            dtDatos.Columns.Add("diferencia", Type.GetType("System.Double"))

            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("reloj"), dtDatos.Columns("fecha"), dtDatos.Columns("cod_deptota")}
            dtTemp = dtDatos.Clone

            For Each dRow As DataRow In dtInformacion.Rows
                drEmp = dtTemp.Rows.Find({dRow("reloj"), dRow("fecha"), dRow("cod_deptota")})
                ' If dRow("reloj") = "032744" Then Stop
                If drEmp Is Nothing Then
                    My.Application.DoEvents()
                    drEmp = dtTemp.NewRow
                    drEmp("reloj") = dRow("reloj")
                    drEmp("fecha") = dRow("fecha")
                    drEmp("nombres") = dRow("nombres")
                    drEmp("cod_deptota") = dRow("cod_deptota")
                    drEmp("nombre_deptota") = dRow("nombre_deptota")
                    drEmp("cod_superta") = dRow("cod_superta")
                    drEmp("nombre_superta") = dRow("nombre_superta")
                    'MCR 2/Feb/2016
                    'En día de descanso o festivo, no considerar las horas normales, solamente las extras
                    If DiaDescanso(dRow("fecha")) Or Festivo(dRow("fecha")) Then
                        drEmp("trabajadas") = IIf(IsDBNull(dRow("extras")), 0, dRow("extras"))
                    Else
                        drEmp("trabajadas") = IIf(IsDBNull(dRow("trabajadas")), 0, dRow("trabajadas"))
                    End If
                    drEmp("asignadas") = 0
                    drEmp("diferencia") = 0
                    dtTemp.Rows.Add(drEmp)
                End If
                drEmp("asignadas") += IIf(IsDBNull(dRow("asignadas")), 0, dRow("asignadas"))
                drEmp("diferencia") = Math.Round(drEmp("trabajadas") - drEmp("asignadas"), 2)
            Next

            For Each dRow In dtTemp.Select("diferencia <> 0")
                dtDatos.ImportRow(dRow)
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub
    Public Sub DistribucionHorasAusentismo(ByRef dtDatos As DataTable, ByVal dtInformacion As DataTable)
        Try
            'MCR 
            'Versión al día 4-Feb-2016
            Dim dtTemp As New DataTable
            Dim drResumen As DataRow

            Dim dtDistribucion As New DataTable
            Dim FechaInicio As Date
            Dim FechaFin As Date
            Dim dDistAus As DataRow
            Dim HorasAus As Double
            Dim Activo As Boolean
            Dim Horas As Double
            Dim Factor As Double
            Dim Habil As Boolean

            Dim r As String = ""
            Dim Normales As Double
            Dim Extras As Double
            Dim Asignadas As Double

            Dim Filtro2Talloc As String
            Dim FiltroPersonal As String
            Dim FiltroTAlloc As String = ""

            Dim fr As New frmRangoFechas
            fr.frmRangoFechas_fecha_ini = DateAdd(DateInterval.Month, -1, DateSerial(Now.Year, Now.Month, 1))
            fr.frmRangoFechas_fecha_fin = DateAdd(DateInterval.Day, -1, DateSerial(Now.Year, Now.Month, 1))
            fr.ShowDialog()

            If FechaInicial = Nothing Or FechaFinal = Nothing Then
                Exit Sub
            End If


            FechaInicio = FechaInicial
            FechaFin = FechaFinal

            dtTemp = sqlExecute("SELECT fecha_corte_tAlloc,filtro_tAlloc FROM parametros")
            If dtTemp.Rows.Count > 0 Then
                FiltroTAlloc = IIf(IsDBNull(dtTemp.Rows(0).Item("filtro_tAlloc")), "", dtTemp.Rows(0).Item("filtro_tAlloc"))
            End If
            FiltroTAlloc = FiltroTAlloc.Replace("[", "tavw.[")

            'MCR 4/FEB/2016
            Filtro2Talloc = FiltroXUsuario
            Dim dtFiltro2 As DataTable = sqlExecute("select isnull(filtro2, '') as filtro2 from seguridad.dbo.appuser where username = '" & Usuario & "'")
            If dtFiltro2.Rows.Count Then
                If dtFiltro2.Rows(0)("filtro2").ToString.Trim <> "" Then
                    Filtro2Talloc = dtFiltro2.Rows(0)("filtro2").ToString.Trim
                End If
            End If
            FiltroPersonal = IIf(Filtro2Talloc.Length > 0, " AND " & Filtro2Talloc, "")
            FiltroPersonal = FiltroPersonal & IIf(FiltroTAlloc.Length > 0, " AND " & FiltroTAlloc, "")
            '*************** 4/feb/2016

            'Obtener información basado en TA, incluyendo horas asignadas en TAlloc
            'y finalmente fechas de alta/baja para reingresos (por si se dieron de alta/baja en el periodo)
            dtDistribucion = sqlExecute("SELECT DatosTA.*,ALTA_ANT,BAJA_ANT,CENTRO_COSTOS FROM (" & _
                                        "SELECT tavw.reloj,max(alta) as alta,max(baja) as baja,MAX(tavw.cod_turno) AS turno,fha_ent_hor AS fecha," & _
                                        "MAX(centro_costos) AS CENTRO_COSTOS,ROUND(SUM(dbo.HToD(horas_normales)),4) AS normales," & _
                                        "round(SUM(dbo.HToD(horas_extras)),4) AS extras," & _
                                        "MAX(ausentismo_real) AS ausentismo," & _
                                        "MAX(goce_sdo) AS goce_sdo" & _
                                        ",MAX(nombre_aus) AS nombre_aus," & _
                                        "(SELECT round(SUM(time_allocation.horas),4) AS asignadas FROM " & _
                                            "time_allocation WHERE tavw.reloj = time_allocation.reloj	" & _
                                            "AND tavw.FHA_ENT_HOR = time_allocation.fecha) AS asignadas " & _
                                        "FROM tavw WHERE fha_ent_hor BETWEEN '" & FechaSQL(FechaInicio) & "' and '" & FechaSQL(FechaFin) & "' " & _
                                        FiltroPersonal & _
                                        "GROUP BY tavw.reloj,fha_ent_hor " & _
                                        ") as DatosTA " & _
                                        "LEFT JOIN PERSONAL.DBO.REINGRESOS " & _
                                        "ON REINGRESOS.RELOJ = DatosTA.RELOJ  order by reloj,fecha", "TA")

            'Estructura a regresar para reporte

            dtDatos = New DataTable
            dtDatos.Columns.Add("rango")
            'MCR 2/FEB/2016
            dtDatos.Columns.Add("centro_costos")
            '**************
            dtDatos.Columns.Add("horas_totales", Type.GetType("System.Double"))
            dtDatos.Columns.Add("horas_distribuidas", Type.GetType("System.Double"))
            dtDatos.Columns.Add("ausentismo_distribuido", Type.GetType("System.Double"))
            dtDatos.Columns.Add("horas_extra", Type.GetType("System.Double"))
            dtDatos.Columns.Add("horas_ausentismo", Type.GetType("System.Double"))
            dtDatos.Columns.Add("horas_normales", Type.GetType("System.Double"))
            dtDatos.Columns.Add("horas_NOdistribuidas", Type.GetType("System.Double"))
            dtDatos.Columns.Add("horas_detalle_aus", Type.GetType("System.Double"))
            dtDatos.Columns.Add("tipo_ausentismo", Type.GetType("System.String"))
            dtDatos.PrimaryKey = New DataColumn() {dtDatos.Columns("centro_costos"), dtDatos.Columns("tipo_ausentismo")}




            'Detalle de ausentismo
            Dim dtDistAusentismo As New DataTable
            dtDistAusentismo.Columns.Add("tipo_aus", Type.GetType("System.String"))
            dtDistAusentismo.Columns.Add("horas", Type.GetType("System.Double"))
            dtDistAusentismo.Columns.Add("centro_costos")
            dtDistAusentismo.PrimaryKey = New DataColumn() {dtDistAusentismo.Columns("centro_costos"), dtDistAusentismo.Columns("tipo_aus")}


            For Each dEmp In dtDistribucion.Select("", "reloj,fecha")
                If r <> dEmp("RELOJ") Then
                    My.Application.DoEvents()
                End If
                r = dEmp("RELOJ")

                drResumen = dtDatos.Rows.Find({dEmp("centro_costos").ToString.Trim, "NO_AUS"})
                If drResumen Is Nothing Then
                    'Inicializar campos
                    drResumen = dtDatos.NewRow
                    drResumen("rango") = FechaCortaLetra(FechaInicio) & " a " & FechaCortaLetra(FechaFin)
                    drResumen("centro_costos") = dEmp("centro_costos").ToString.Trim
                    drResumen("horas_totales") = 0
                    drResumen("horas_distribuidas") = 0
                    drResumen("ausentismo_distribuido") = 0
                    drResumen("horas_extra") = 0
                    drResumen("horas_normales") = 0
                    drResumen("horas_ausentismo") = 0
                    drResumen("horas_NOdistribuidas") = 0
                    drResumen("horas_detalle_aus") = 0
                    drResumen("tipo_ausentismo") = "NO_AUS"
                    dtDatos.Rows.Add(drResumen)
                End If


                'Considerar si es día hábil
                Habil = Not DiaDescanso(dEmp("fecha")) And Not Festivo(dEmp("fecha"))
                'Si el empleado estuvo activo ese día, de acuerdo a RH
                Activo = dEmp("alta") <= dEmp("fecha") And IIf(IsDBNull(dEmp("baja")), DateSerial(2099, 12, 12), dEmp("baja")) >= dEmp("fecha")
                'Buscar registro de reingreso, para determinar si estuvo activo
                Activo = Activo Or (IIf(IsDBNull(dEmp("alta_ant")), dEmp("alta"), dEmp("alta_ant")) <= dEmp("fecha") _
                                    And IIf(IsDBNull(dEmp("baja_ant")), DateSerial(2099, 12, 12), dEmp("baja_ant")) >= dEmp("fecha"))
                'Solo considerar activo si es día hábil
                Activo = Activo And Habil

                If dEmp("fecha") >= DateSerial(2016, 1, 4) Then
                    'A partir del 4-Enero-2016, a todos los empleados se les consideran 9 horas para efectos de tAlloc
                    'Hay que determinar el factor para convertir las horas de empleados que no sean de 1er turno
                    'Horas normales y extras trabajadas, deberán multiplicarse por el factor, para obtener equivalencia
                    Horas = 9
                    'Factor = IIf(dEmp("turno").ToString.Trim = "1", 1, IIf(dEmp("turno").ToString.Trim = "2", 9 / 8.4, 9 / 7))
                    Factor = IIf(dEmp("turno").ToString.Trim = "1", 1, IIf(dEmp("turno").ToString.Trim = "2", 1.071428, 9 / 7))
                Else
                    'Si el reporte emite datos anteriores al 4-Ene-16
                    'Utilizar las horas de acuerdo al turno
                    Horas = IIf(dEmp("turno").ToString.Trim = "1", 9, IIf(dEmp("turno").ToString.Trim = "2", 8.4, 7))
                    Factor = 1
                End If

                Normales = IIf(IsDBNull(dEmp("normales")), 0, dEmp("normales"))
                Extras = IIf(IsDBNull(dEmp("extras")), 0, dEmp("extras"))
                Asignadas = IIf(IsDBNull(dEmp("asignadas")), 0, dEmp("asignadas"))

                'Horas que se espera sean trabajadas
                drResumen("horas_totales") += IIf(Activo, Horas, 0)
                'Horas que ya fueron distribuidas
                drResumen("horas_distribuidas") += Asignadas
                'Tiempo extra
                drResumen("horas_extra") += Math.Round(Extras * Factor, 4)

                If Not IsDBNull(dEmp("ausentismo")) And Activo Then
                    'Si hubo ausentismo en un día que el empleado estuvo activo (y hábil)
                    If IIf(IsDBNull(dEmp("goce_sdo")), 0, dEmp("goce_sdo")) = 0 Then
                        'Considerar solamente si es ausentismo sin goce de sueldo
                        'Restar las horas normales, por los ausentismos parciales,  
                        'o que fueron a trabajar al menos un rato
                        HorasAus = Math.Round(Horas - Normales, 4)
                        drResumen("horas_ausentismo") += HorasAus

                        dDistAus = dtDistAusentismo.Rows.Find({IIf(IsDBNull(dEmp("centro_costos")), "NO IDENTIFICADO", dEmp("centro_costos")).ToString.Trim, _
                                                               IIf(IsDBNull(dEmp("nombre_aus")), "NO IDENTIFICADO", dEmp("nombre_aus")).ToString.Trim})
                        If dDistAus Is Nothing Then
                            'Insertar en la tabla de detalle de ausentismo
                            dDistAus = dtDistAusentismo.NewRow
                            dDistAus("tipo_aus") = IIf(IsDBNull(dEmp("nombre_aus")), "NO IDENTIFICADO", dEmp("nombre_aus"))
                            dDistAus("horas") = 0
                            dDistAus("centro_costos") = dEmp("centro_costos").ToString.Trim
                            dtDistAusentismo.Rows.Add(dDistAus)
                        End If
                        dDistAus("horas") += HorasAus
                        drResumen("ausentismo_distribuido") += Asignadas
                    Else
                        'ACasas Si es habil, acumular las horas normales para al final obtener las parciales
                        drResumen("horas_normales") += Math.Round((Normales * Factor), 4)
                    End If
                Else
                    If Habil Then
                        'Si es día hábil, restar las horas trabajadas a las que debió trabajar, 
                        'para obtener ausentismo parcial (retardos, salidas anticipadas, etc...)


                        'ACasas Si es habil, acumular las horas normales para al final obtener las parciales
                        drResumen("horas_normales") += Math.Round((Normales * Factor), 4)
                    End If
                End If
                If Habil Then
                    'Las horas que no se han distribuido, en día hábil
                    drResumen("horas_NOdistribuidas") += Math.Round(((Normales + Extras) * Factor) - Asignadas, 4)
                Else
                    'Si el día no es hábil, ignorar las horas normales
                    drResumen("horas_NOdistribuidas") += Math.Round((Extras * Factor) - Asignadas, 4)

                End If
            Next
            'dtDatos.Rows.Add(drResumen)

            'Agregar el detalle de ausentismo a la tabla general
            'para mostrar en el reporte
            For Each dDistAus In dtDistAusentismo.Select("", "tipo_aus")
                drResumen = dtDatos.NewRow
                drResumen("tipo_ausentismo") = dDistAus("tipo_aus")
                drResumen("horas_detalle_aus") = dDistAus("horas")
                drResumen("centro_costos") = dDistAus("centro_costos")
                dtDatos.Rows.Add(drResumen)
            Next

        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        End Try
    End Sub
    Sub DataTable2CSV(ByVal table As DataTable, ByVal filename As String, ByVal sepChar As String)
        Dim writer As System.IO.StreamWriter

        Try
            writer = New System.IO.StreamWriter(filename)
        Catch
            writer = Nothing
        End Try

        Try
            ' first write a line with the columns name
            Dim sep As String = ""
            Dim builder As New System.Text.StringBuilder
            For Each col As DataColumn In table.Columns
                builder.Append(sep).Append(col.ColumnName)
                sep = sepChar
            Next
            writer.WriteLine(builder.ToString())

            ' then write all the rows
            For Each row As DataRow In table.Rows
                sep = ""
                builder = New System.Text.StringBuilder

                For Each col As DataColumn In table.Columns
                    builder.Append(sep).Append(row(col.ColumnName))
                    sep = sepChar
                Next
                writer.WriteLine(builder.ToString())
            Next
        Catch ex As Exception
            ErrorLog(Usuario, System.Reflection.MethodBase.GetCurrentMethod.Name(), "Reportes", ex.HResult, ex.Message)
        Finally
            If Not writer Is Nothing Then writer.Close()
        End Try
    End Sub

End Module

